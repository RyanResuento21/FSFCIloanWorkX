Public Class FrmImportPDC

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim Temp_DT As New DataTable

    Private Sub FrmImportPDC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        LoadData()
        If GridView2.RowCount = 1 And GridView2.GetFocusedRowCellValue("Borrower") = "" Then
            btnImport.PerformClick()
        End If
    End Sub

    Private Sub BtnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        LblTitle_Click(sender, e)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetButtonFontSettings({btnSave, btnVerify, btnRefresh, btnCancel, btnImport, btnExport})
        Catch ex As Exception
            TriggerBugReport("Import PDC - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Import PDC", lblTitle.Text)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Using OFD As New OpenFileDialog
            OFD.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.)|*.*"
            If OFD.ShowDialog = DialogResult.OK Then
                Using con As New OleDb.OleDbConnection()
                    Try
                        Cursor = Cursors.WaitCursor
                        Temp_DT.Rows.Clear()
                        Dim DT_Excel As New DataTable
                        con.ConnectionString = String.Format("Provider={0};Data Source={1};Extended Properties=""Excel 12.0 XML;HDR=Yes;""", "Microsoft.ACE.OLEDB.12.0", OFD.FileName)
                        Using cmd As New OleDb.OleDbCommand("SELECT * FROM [Sheet$]", con)
                            Using da As New OleDb.OleDbDataAdapter(cmd)
                                con.Open()
                                da.Fill(DT_Excel)
                                con.Close()
                            End Using
                        End Using
                        For x As Integer = 0 To DT_Excel.Rows.Count - 1
                            If DT_Excel(x)("Borrower") = "" Then
                            Else
                                Temp_DT.Rows.Add(x + 1, DT_Excel(x)("Borrower"), DT_Excel(x)("Account Number"), DT_Excel(x)("Bank"), DT_Excel(x)("Branch"), DT_Excel(x)("Check Number"), If(IsDate(DT_Excel(x)("Date")) = False, "", Format(CDate(DT_Excel(x)("Date")), "MMM dd, yyyy")), DT_Excel(x)("Amount"), DT_Excel(x)("Bank Account No"), DT_Excel(x)("Remarks"), DataObject(String.Format("SELECT CreditNumber FROM credit_application WHERE AccountNumber = '{0}' AND Branch_ID = '{1}';", DT_Excel(x)("Account Number"), Branch_ID)))
                            End If
                        Next
                        GridControl2.DataSource = Temp_DT.Copy
                        GridView2.BestFitColumns()
                        btnVerify.Enabled = True
                        btnSave.Enabled = False
                        Cursor = Cursors.Default
                        btnVerify.PerformClick()
                    Catch ex As Exception
                        Cursor = Cursors.Default
                        TriggerBugReport("Import PDC - Import", ex.Message.ToString)
                    Finally
                        If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                    End Try
                End Using
            End If
        End Using
    End Sub

    Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        Dim ErrorX As String = ""
        Dim Num As Integer = 1
        If MsgBoxYes("Are you sure you want to Validate this data?") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor

            For x As Integer = 0 To GridView2.RowCount - 1
                If GridView2.GetRowCellDisplayText(x, "CreditNumber") = "" Then
                    ErrorX &= Num & ".) Account Number does not exist under row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Borrower") = "" Then
                    ErrorX &= Num & ".) Please check your data under column Borrower and row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellValue(x, "Borrower").ToString.Length > 100 Then
                    ErrorX &= Num & ".) Please check your data under column Borrower and row " & x + 1 & " (Maximum Length is up to 100 characters only)" & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Account Number") = "" Then
                    ErrorX &= Num & ".) Please check your data under column Account Number and row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Bank") = "" Then
                    ErrorX &= Num & ".) Please check your data under column Bank and row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellValue(x, "Bank").ToString.Length > 150 Then
                    ErrorX &= Num & ".) Please check your data under column Bank and row " & x + 1 & " (Maximum Length is up to 150 characters only)" & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Branch") = "" Then
                    ErrorX &= Num & ".) Please check your data under column Branch and row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellValue(x, "Branch").ToString.Length > 255 Then
                    ErrorX &= Num & ".) Please check your data under column Branch and row " & x + 1 & " (Maximum Length is up to 255 characters only)" & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Check No") = "" Then
                    ErrorX &= Num & ".) Please check your data under column Check No and row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellValue(x, "Check No").ToString.Length > 25 Then
                    ErrorX &= Num & ".) Please check your data under column Check No and row " & x + 1 & " (Maximum Length is up to 25 characters only)" & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Date") = "" Then
                    ErrorX &= Num & ".) Please check your data under column Date and row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Amount") = "" Then
                    ErrorX &= Num & ".) Please check your data under column Amount and row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Bank Account No") = "" Then
                    ErrorX &= Num & ".) Please check your data under column Bank Account No and row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellValue(x, "Bank Account No").ToString.Length > 20 Then
                    ErrorX &= Num & ".) Please check your data under column Bank Account No and row " & x + 1 & " (Maximum Length is up to 20 characters only)" & vbCrLf
                    Num += 1
                End If
            Next

            Cursor = Cursors.Default
            If ErrorX = "" Then
                MsgBox("Successfully Validated!", MsgBoxStyle.Information, "Info")
                GridView2.OptionsBehavior.Editable = False
                btnSave.Enabled = True
            Else
                Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Import PDC Error Log-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".txt"
                IO.File.AppendAllText(FName, "*** E R R O R   I N   I M P O R T   P D C ***" & vbCrLf & vbCrLf & ErrorX & vbCrLf & vbCrLf & "*** E R R O R   I N   I M P O R T   P D C ***", System.Text.Encoding.UTF8)
                Process.Start(FName)

                btnSave.Enabled = False
            End If
        End If
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If MsgBoxYes("Are you sure you want to export this to Excel Format?") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & "Import PDC Format" & "-" & Format(Date.Now, "yyyy-MM-dd_HHmmss") & ".xlsx"
            Dim Report As New RptImportPDC
            With Report
                Dim DT As DataTable
                DT = Temp_DT.Copy
                For x As Integer = 0 To 15
                    DT.Rows.Add(1, "", "", "", "", "", "", "", "", "", "")
                Next
                .DataSource = DT
                .lblBorrower.DataBindings.Add("Text", DT, "Borrower")
                .lblAccountNumber.DataBindings.Add("Text", DT, "Account Number")
                .lblBank.DataBindings.Add("Text", DT, "Bank")
                .lblBranch.DataBindings.Add("Text", DT, "Branch")
                .lblCheckNum.DataBindings.Add("Text", DT, "Check No")
                .lblAmount.DataBindings.Add("Text", DT, "Amount")
                .lblDate.DataBindings.Add("Text", DT, "Date")
                .lblBankAccountNum.DataBindings.Add("Text", DT, "Bank Account No")
                .lblRemarks.DataBindings.Add("Text", DT, "Remarks")
                .ExportToXlsx(FName)
                Process.Start(FName)
            End With
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If vSave Then
            Else
                MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor

                Dim SQL As String = ""
                For x As Integer = 0 To GridView2.RowCount - 1
                    SQL &= "INSERT INTO check_received SET"
                    SQL &= String.Format(" AssetNumber = '{0}', ", GridView2.GetRowCellValue(x, "CreditNumber"))
                    SQL &= " ORNumber = '', "
                    SQL &= " Sold_ID = '', "
                    SQL &= " DateRequest = DATE(NOW()), "
                    SQL &= String.Format(" Buyer = '{0}', ", GridView2.GetRowCellValue(x, "Borrower").ToString.InsertQuote)
                    SQL &= String.Format(" Bank = '{0}', ", GridView2.GetRowCellValue(x, "Bank").ToString.InsertQuote)
                    SQL &= String.Format(" Branch = '{0}', ", GridView2.GetRowCellValue(x, "Branch").ToString.InsertQuote)
                    SQL &= String.Format(" `Check` = '{0}', ", GridView2.GetRowCellValue(x, "Check No"))
                    SQL &= String.Format(" `Date` = '{0}', ", Format(CDate(GridView2.GetRowCellValue(x, "Date")), "yyyy-MM-dd"))
                    SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount")))
                    SQL &= String.Format(" Remarks = '{0}', ", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                    SQL &= String.Format(" AccountNum = '{0}', ", GridView2.GetRowCellValue(x, "Bank Account No"))
                    SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                    SQL &= String.Format(" user_code = '{0}', ", User_Code)
                    SQL &= " check_type = 'R', "
                    SQL &= " BankID = 0, "
                    SQL &= " CVNumber = '', "
                    SQL &= " CVDate = '', "
                    SQL &= " CVNumber_2 = '', "
                    SQL &= " Hold = 0, "
                    SQL &= " Checked = 0;"
                Next

                DataObject(SQL)
                Logs("Import PDC", "Save", String.Format("Import {0} PDC(s).", GridView2.RowCount), "", "", "", "")
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Sub Clear()
        LoadData()
        btnVerify.Enabled = False
        btnSave.Enabled = False
    End Sub

    Private Sub LoadData()
        Dim SQL As String = "SELECT "
        SQL &= "    1 AS 'No',"
        SQL &= "    '' AS 'Borrower',"
        SQL &= "    '' AS 'Account Number',"
        SQL &= "    '' AS 'Bank',"
        SQL &= "    '' AS 'Branch',"
        SQL &= "    '' AS 'Check No',"
        SQL &= "    '' AS 'Date',"
        SQL &= "    '' AS 'Amount',"
        SQL &= "    '' AS 'Bank Account No',"
        SQL &= "    '' AS 'Remarks',"
        SQL &= "    '' AS 'CreditNumber'"
        Temp_DT = DataSource(SQL)
        GridControl2.DataSource = Temp_DT.Copy
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            Clear()
        End If
    End Sub
End Class