Public Class FrmImportBooks

    Dim Temp_DT As DataTable
    Private Sub FrmImportBooks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetBandedGridApperance({BandedGridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        Temp_DT = DataSource(String.Format("SELECT DATE(NOW()) AS 'OR/Passbook Date',DATE(NOW()) AS 'Posting Date','' AS 'Client Name','' AS 'Loan Account No','' AS 'Particulars','' AS 'OR No', '' AS 'Passbook Code/Bank Ref No',0.0 AS 'DR Cash in Bank',0.0 AS 'CR Cash in Bank',0.0 AS 'DR Loans Receivable',0.0 AS 'CR Loans Receivable', 0.0 AS 'DR Interest Income Current',0.0 AS 'CR Interest Income Current',0.0 AS 'DR Interest Income Past Due',0.0 AS 'CR Interest Income Past Due','' AS 'Sundries Account','' AS 'Department Code','' AS 'Department','' AS 'Payor/Note',0.0 AS 'DR',0.0 AS 'CR',0.0 AS 'DR UDI Application of Payment',0.0 AS 'CR UDI Application of Payment',0.0 AS 'DR RPPD Application of Payment',0.0 AS 'CR RPPD Application of Payment','' AS 'Business Center Code','' AS 'Business Center' LIMIT 0"))
        LoadData()
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

            GetButtonFontSettings({btnSave, btnVerify, btnRefresh, btnCancel, btnImport})
        Catch ex As Exception
            TriggerBugReport("Import Books - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Import Books of Account", lblTitle.Text)
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
                        Using cmd As New OleDb.OleDbCommand("SELECT * FROM [CRB$]", con)
                            Using da As New OleDb.OleDbDataAdapter(cmd)
                                con.Open()
                                da.Fill(DT_Excel)
                                con.Close()
                            End Using
                        End Using
                        For x As Integer = 0 To DT_Excel.Rows.Count - 1
                            If DT_Excel(x)("OR/Passbook Date").ToString <> "" Then
                                Temp_DT.Rows.Add(DT_Excel(x)("OR/Passbook Date"), DT_Excel(x)("Posting Date"), DT_Excel(x)("Client Name"), DT_Excel(x)("Loan Account No"), DT_Excel(x)("Particulars"), DT_Excel(x)("OR No"), DT_Excel(x)("Passbook Code/Bank Ref No"), DT_Excel(x)("DR Cash in Bank"), DT_Excel(x)("CR Cash in Bank"), DT_Excel(x)("DR Loans Receivable"), DT_Excel(x)("CR Loans Receivable"), DT_Excel(x)("DR Interest Income Current"), DT_Excel(x)("CR Interest Income Current"), DT_Excel(x)("DR Interest Income Past Due"), DT_Excel(x)("CR Interest Income Past Due"), DT_Excel(x)("SUNDRIES ACCOUNT"), DT_Excel(x)("Department Code"), DT_Excel(x)("Department"), DT_Excel(x)("Payor/Note"), DT_Excel(x)("DR"), DT_Excel(x)("CR"), DT_Excel(x)("DR UDI"), DT_Excel(x)("CR UDI"), DT_Excel(x)("DR RPPD"), DT_Excel(x)("CR RPPD"), DT_Excel(x)("Business Center Code"), DT_Excel(x)("Business Center"))
                            End If
                        Next
                        GridControl1.DataSource = Temp_DT.Copy
                        'BandedGridView1.BestFitColumns()
                        btnVerify.Enabled = True
                        btnSave.Enabled = False
                        Cursor = Cursors.Default
                        btnVerify.PerformClick()
                    Catch ex As Exception
                        Cursor = Cursors.Default
                        TriggerBugReport("Import Books - Import", ex.Message.ToString)
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
        'Dim ErrorX As String
        'Dim Num As Integer = 1
        'If MsgBoxYes("Are you sure you want to Validate this data?") = MsgBoxResult.Yes Then
        '    Cursor = Cursors.WaitCursor

        'For x As Integer = 0 To GridView2.RowCount - 1
        '    If GridView2.GetRowCellDisplayText(x, "CreditNumber") = "" Then
        '        ErrorX &= Num & ".) Account Number does not exist under row " & x + 1 & vbCrLf
        '        Num = Num + 1
        '    End If
        '    If GridView2.GetRowCellDisplayText(x, "Borrower") = "" Then
        '        ErrorX &= Num & ".) Please check your data under column Borrower and row " & x + 1 & vbCrLf
        '        Num = Num + 1
        '    End If
        '    If GridView2.GetRowCellValue(x, "Borrower").ToString.Length > 100 Then
        '        ErrorX &= Num & ".) Please check your data under column Borrower and row " & x + 1 & " (Maximum Length is up to 100 characters only)" & vbCrLf
        '        Num = Num + 1
        '    End If
        '    If GridView2.GetRowCellDisplayText(x, "Account Number") = "" Then
        '        ErrorX &= Num & ".) Please check your data under column Account Number and row " & x + 1 & vbCrLf
        '        Num = Num + 1
        '    End If
        '    If GridView2.GetRowCellDisplayText(x, "Bank") = "" Then
        '        ErrorX &= Num & ".) Please check your data under column Bank and row " & x + 1 & vbCrLf
        '        Num = Num + 1
        '    End If
        '    If GridView2.GetRowCellValue(x, "Bank").ToString.Length > 150 Then
        '        ErrorX &= Num & ".) Please check your data under column Bank and row " & x + 1 & " (Maximum Length is up to 150 characters only)" & vbCrLf
        '        Num = Num + 1
        '    End If
        '    If GridView2.GetRowCellDisplayText(x, "Branch") = "" Then
        '        ErrorX &= Num & ".) Please check your data under column Branch and row " & x + 1 & vbCrLf
        '        Num = Num + 1
        '    End If
        '    If GridView2.GetRowCellValue(x, "Branch").ToString.Length > 255 Then
        '        ErrorX &= Num & ".) Please check your data under column Branch and row " & x + 1 & " (Maximum Length is up to 255 characters only)" & vbCrLf
        '        Num = Num + 1
        '    End If
        '    If GridView2.GetRowCellDisplayText(x, "Check No") = "" Then
        '        ErrorX &= Num & ".) Please check your data under column Check No and row " & x + 1 & vbCrLf
        '        Num = Num + 1
        '    End If
        '    If GridView2.GetRowCellValue(x, "Check No").ToString.Length > 25 Then
        '        ErrorX &= Num & ".) Please check your data under column Check No and row " & x + 1 & " (Maximum Length is up to 25 characters only)" & vbCrLf
        '        Num = Num + 1
        '    End If
        '    If GridView2.GetRowCellDisplayText(x, "Date") = "" Then
        '        ErrorX &= Num & ".) Please check your data under column Date and row " & x + 1 & vbCrLf
        '        Num = Num + 1
        '    End If
        '    If GridView2.GetRowCellDisplayText(x, "Amount") = "" Then
        '        ErrorX &= Num & ".) Please check your data under column Amount and row " & x + 1 & vbCrLf
        '        Num = Num + 1
        '    End If
        '    If GridView2.GetRowCellDisplayText(x, "Bank Account No") = "" Then
        '        ErrorX &= Num & ".) Please check your data under column Bank Account No and row " & x + 1 & vbCrLf
        '        Num = Num + 1
        '    End If
        '    If GridView2.GetRowCellValue(x, "Bank Account No").ToString.Length > 20 Then
        '        ErrorX &= Num & ".) Please check your data under column Bank Account No and row " & x + 1 & " (Maximum Length is up to 20 characters only)" & vbCrLf
        '        Num = Num + 1
        '    End If
        'Next

        'Cursor = Cursors.Default
        'If ErrorX = "" Then
        '    MsgBox("Successfully Validated!", MsgBoxStyle.Information, "Info")
        '    GridView2.OptionsBehavior.Editable = False
        '    btnSave.Enabled = True
        'Else
        '    Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Import PDC Error Log-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".txt"
        '    IO.File.AppendAllText(FName, "*** E R R O R   I N   I M P O R T   P D C ***" & vbCrLf & vbCrLf & ErrorX & vbCrLf & vbCrLf & "*** E R R O R   I N   I M P O R T   P D C ***", System.Text.Encoding.UTF8)
        '    Process.Start(FName)

        '    btnSave.Enabled = False
        'End If
        'End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor

                'Dim SQL As String
                'For x As Integer = 0 To GridView2.RowCount - 1
                '    SQL &= "INSERT INTO check_received SET"
                '    SQL &= String.Format(" AssetNumber = '{0}', ", GridView2.GetRowCellValue(x, "CreditNumber"))
                '    SQL &= " ORNumber = '', "
                '    SQL &= " Sold_ID = '', "
                '    SQL &= " DateRequest = DATE(NOW()), "
                '    SQL &= String.Format(" Buyer = '{0}', ", GridView2.GetRowCellValue(x, "Borrower").ToString.InsertQuote)
                '    SQL &= String.Format(" Bank = '{0}', ", GridView2.GetRowCellValue(x, "Bank").ToString.InsertQuote)
                '    SQL &= String.Format(" Branch = '{0}', ", GridView2.GetRowCellValue(x, "Branch").ToString.InsertQuote)
                '    SQL &= String.Format(" `Check` = '{0}', ", GridView2.GetRowCellValue(x, "Check No"))
                '    SQL &= String.Format(" `Date` = '{0}', ", Format(CDate(GridView2.GetRowCellValue(x, "Date")), "yyyy-MM-dd"))
                '    SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount")))
                '    SQL &= String.Format(" Remarks = '{0}', ", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                '    SQL &= String.Format(" AccountNum = '{0}', ", GridView2.GetRowCellValue(x, "Bank Account No"))
                '    SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                '    SQL &= String.Format(" user_code = '{0}', ", User_Code)
                '    SQL &= " check_type = 'R', "
                '    SQL &= " BankID = 0, "
                '    SQL &= " CVNumber = '', "
                '    SQL &= " CVDate = '', "
                '    SQL &= " CVNumber_2 = '', "
                '    SQL &= " Hold = 0, "
                '    SQL &= " Checked = 0;"
                'Next

                'DataObject(SQL)
                'Logs("Import Books", "Save", String.Format("Import {0} PDC(s).", GridView2.RowCount), "", "", "", "")
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

    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            Clear()
        End If
    End Sub
End Class