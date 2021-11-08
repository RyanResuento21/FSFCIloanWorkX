Imports DevExpress.XtraReports.UI
Public Class FrmImportBooksGJ

    Dim Temp_DT As DataTable
    Public BankID As Integer
    Public xBranchID As String
    Public xBranchCode As String
    Private Sub FrmImportBooks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetBandedGridApperance({BandedGridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        Temp_DT = DataSource(String.Format("SELECT DATE(NOW()) AS 'JV Date',DATE(NOW()) AS 'Posting Date','' AS 'Client Name','' AS 'Loan Account No','' AS 'Particulars','' AS 'JV No', '' AS 'Passbook Code/Bank Ref No',0.0 AS 'DR Cash in Bank',0.0 AS 'CR Cash in Bank',0.0 AS 'DR Loans Receivable',0.0 AS 'CR Loans Receivable', 0.0 AS 'DR Interest Income Current',0.0 AS 'CR Interest Income Current',0.0 AS 'DR Interest Income Past Due',0.0 AS 'CR Interest Income Past Due','' AS 'Sundries Account','' AS 'Department Code','' AS 'Department','' AS 'Payor/Note',0.0 AS 'DR',0.0 AS 'CR',0.0 AS 'DR UDI Application of Payment',0.0 AS 'CR UDI Application of Payment',0.0 AS 'DR RPPD Application of Payment',0.0 AS 'CR RPPD Application of Payment','' AS 'Business Center','' AS 'Business Center Code','' AS 'Account Code','' AS 'Mother Code' LIMIT 0"))
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

            GetButtonFontSettings({btnSave, btnVerify, btnRefresh, btnCancel, btnImport, btnExport})
        Catch ex As Exception
            TriggerBugReport("Import Book GJ - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Import Books of Account [General Journal]", lblTitle.Text)
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
            FrmMain.btnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim OFD As New OpenFileDialog With {
            .Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.)|*.*"
        }
        If OFD.ShowDialog = DialogResult.OK Then
            Using con As New OleDb.OleDbConnection()
                Try
                    Cursor = Cursors.WaitCursor
                    Temp_DT.Rows.Clear()
                    Dim DT_Excel As New DataTable
                    con.ConnectionString = String.Format("Provider={0};Data Source={1};Extended Properties=""Excel 12.0 XML;HDR=Yes;""", "Microsoft.ACE.OLEDB.12.0", OFD.FileName)
                    Using cmd As New OleDb.OleDbCommand("SELECT * FROM [GJ$]", con)
                        Using da As New OleDb.OleDbDataAdapter(cmd)
                            con.Open()
                            da.Fill(DT_Excel)
                            con.Close()
                        End Using
                    End Using
                    For x As Integer = 0 To DT_Excel.Rows.Count - 1
                        If DT_Excel(x)("JV No").ToString <> "" Then
                            Temp_DT.Rows.Add(If(DT_Excel(x)("JV Date").ToString = "" And DT_Excel(x)("JV No").ToString <> "", Temp_DT(Temp_DT.Rows.Count - 1)("JV Date").ToString, DT_Excel(x)("JV Date").ToString), DT_Excel(x)("Posting Date"), If(DT_Excel(x)("Loan Account No").ToString = "", "", DataObject(String.Format("GET Borrower_Credit_Account('{0}')", DT_Excel(x)("Loan Account No")))), DT_Excel(x)("Loan Account No"), If(DT_Excel(x)("Particulars/Explanation").ToString = "" And DT_Excel(x)("JV No").ToString <> "", Temp_DT(Temp_DT.Rows.Count - 1)("Particulars").ToString, DT_Excel(x)("Particulars/Explanation")), DT_Excel(x)("JV No"), "", DT_Excel(x)("DR Cash in Bank"), DT_Excel(x)("CR Cash in Bank"), DT_Excel(x)("DR Loans Receivable"), DT_Excel(x)("CR Loans Receivable"), DT_Excel(x)("DR Interest Income Current"), DT_Excel(x)("CR Interest Income Current"), DT_Excel(x)("DR Interest Income Past Due"), DT_Excel(x)("CR Interest Income Past Due"), DT_Excel(x)("SUNDRIES ACCOUNT"), DT_Excel(x)("Department Code"), DT_Excel(x)("Department"), DT_Excel(x)("Payor2/Note"), DT_Excel(x)("DR"), DT_Excel(x)("CR"), DT_Excel(x)("DR UDI"), DT_Excel(x)("CR UDI"), DT_Excel(x)("DR RPPD"), DT_Excel(x)("CR RPPD"), DT_Excel(x)("Business Center"), If(DT_Excel(x)("Business Center").ToString = "", "", DataObject(String.Format("SELECT BusinessCode FROM business_center WHERE BusinessCenter = '{1}' AND `status` = 'ACTIVE' AND BranchID = '{0}' LIMIT 1;", xBranchID, DT_Excel(x)("Business Center")))), DT_Excel(x)("Account Code"), DataObject(String.Format("SELECT MotherCode('{0}')", DT_Excel(x)("Account Code"))))
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
                    TriggerBugReport("Import Books GJ - Import", ex.Message.ToString)
                Finally
                    If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Try
            End Using
        End If
        OFD.Dispose()
    End Sub

    Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        Dim ErrorX As String = ""
        Dim WarningX As String = ""
        Dim Num As Integer = 1
        Dim WarningNum As Integer = 1
        If MsgBoxYes("Are you sure you want to Validate this data?") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor

            Dim TotalDR As Double
            Dim TotalCR As Double
            Dim PrevJV As String = ""
            For x As Integer = 0 To BandedGridView1.RowCount - 1
                If x = 0 Then
                    PrevJV = BandedGridView1.GetRowCellDisplayText(x, "JV No")
                    TotalDR = If(IsNumeric(BandedGridView1.GetRowCellDisplayText(x, "DR")), BandedGridView1.GetRowCellDisplayText(x, "DR"), 0)
                    TotalCR = If(IsNumeric(BandedGridView1.GetRowCellDisplayText(x, "CR")), BandedGridView1.GetRowCellDisplayText(x, "CR"), 0)
                Else
                    If PrevJV = BandedGridView1.GetRowCellDisplayText(x, "JV No") Then
                        TotalDR += If(IsNumeric(BandedGridView1.GetRowCellDisplayText(x, "DR")), BandedGridView1.GetRowCellDisplayText(x, "DR"), 0)
                        TotalCR += If(IsNumeric(BandedGridView1.GetRowCellDisplayText(x, "CR")), BandedGridView1.GetRowCellDisplayText(x, "CR"), 0)
                    Else
                        If TotalDR = TotalCR Then
                        Else
                            ErrorX &= Num & ".) Total DR and CR is not equal for JV No " & PrevJV & " at row " & x + 1 & vbCrLf
                            Num += 1
                        End If
                        TotalDR = If(IsNumeric(BandedGridView1.GetRowCellDisplayText(x, "DR")), BandedGridView1.GetRowCellDisplayText(x, "DR"), 0)
                        TotalCR = If(IsNumeric(BandedGridView1.GetRowCellDisplayText(x, "CR")), BandedGridView1.GetRowCellDisplayText(x, "CR"), 0)
                        PrevJV = BandedGridView1.GetRowCellDisplayText(x, "JV No")
                    End If
                End If
                If BandedGridView1.GetRowCellDisplayText(x, "JV No") = "" Then
                    ErrorX &= Num & ".) JV No is empty at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If BandedGridView1.GetRowCellDisplayText(x, "JV Date") = "" Then
                    ErrorX &= Num & ".) JV Date is empty at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If BandedGridView1.GetRowCellValue(x, "Account Code").ToString = "" And BandedGridView1.GetRowCellValue(x, "Sundries Account").ToString <> "" Then
                    ErrorX &= Num & ".) Account Code is empty at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If DataObject(String.Format("SELECT IFNULL(`Code`,'') FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", BandedGridView1.GetRowCellValue(x, "Account Code").ToString)) <> BandedGridView1.GetRowCellValue(x, "Account Code").ToString Then
                    ErrorX &= Num & ".) Account Code does not exist at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If BandedGridView1.GetRowCellValue(x, "Account Code").ToString <> "" And BandedGridView1.GetRowCellValue(x, "Mother Code").ToString = "" Then
                    ErrorX &= Num & ".) Please check your account code at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If BandedGridView1.GetRowCellValue(x, "Business Center Code").ToString = "" And BandedGridView1.GetRowCellValue(x, "Business Center").ToString <> "" Then
                    ErrorX &= Num & ".) Please check your business center data, no code found in the system at row " & x + 1 & vbCrLf
                    Num += 1
                End If

                'WARNING
                If DataObject(String.Format("SELECT IFNULL(ReferenceNumber,'') FROM journal_voucher WHERE ReferenceNumber = '{0}' AND DocumentDate = '{1}' AND Branch_ID = '{2}' AND `status` = 'ACTIVE'", BandedGridView1.GetRowCellValue(x, "JV No").ToString, Format(DateValue(BandedGridView1.GetRowCellValue(x, "JV Date")), "yyyy-MM-dd"), Branch_ID)) = BandedGridView1.GetRowCellValue(x, "JV No").ToString Then
                    WarningX &= WarningNum & ".) JV No " & BandedGridView1.GetRowCellValue(x, "JV No").ToString & " might already exist in the system, please check your data at row " & x + 1 & vbCrLf
                    WarningNum += 1
                End If
            Next

            Cursor = Cursors.Default
            If ErrorX = "" Then
                If WarningX = "" Then
                Else
                    Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Import General Journal Warning Log-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".txt"
                    IO.File.AppendAllText(FName, "*** W A R N I N G   I N   I M P O R T   G E N E R A L   J O U R N A L ***" & vbCrLf & vbCrLf & WarningX & vbCrLf & vbCrLf & "*** W A R N I N G   I N   I M P O R T   G E N E R A L   J O U R N A L ***", System.Text.Encoding.UTF8)
                    Process.Start(FName)
                End If
                MsgBox("Successfully Validated!", MsgBoxStyle.Information, "Info")
                BandedGridView1.OptionsBehavior.Editable = False
                btnSave.Enabled = True
            Else
                Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Import General Journal Error Log-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".txt"
                IO.File.AppendAllText(FName, "*** E R R O R   I N   I M P O R T   G E N E R A L   J O U R N A L ***" & vbCrLf & vbCrLf & ErrorX & vbCrLf & vbCrLf & "*** E R R O R   I N   I M P O R T   G E N E R A L   J O U R N A L ***", System.Text.Encoding.UTF8)
                Process.Start(FName)

                btnSave.Enabled = False
            End If
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor

                Dim SQL As String = ""
                Dim PrevJV As String = ""
                Dim DocumentNumber As String = ""
                Dim PrevDocumentNumber As String = ""
                For x As Integer = 0 To BandedGridView1.RowCount - 1
                    If x = 0 Then
                        PrevJV = BandedGridView1.GetRowCellDisplayText(x, "JV No")
                        DocumentNumber = DataObject(String.Format("SELECT CONCAT('JV-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,5,'0')) FROM journal_voucher WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", xBranchID, xBranchCode, Format(DateValue(BandedGridView1.GetRowCellDisplayText(x, "JV Date")), "yy"), Format(DateValue(BandedGridView1.GetRowCellDisplayText(x, "JV Date")), "yyyy-MM-dd")))
                    Else
                        If PrevJV = BandedGridView1.GetRowCellDisplayText(x, "JV No") Then
                            PrevDocumentNumber = DocumentNumber
                        Else
                            DataObject(SQL)
                            PrevJV = BandedGridView1.GetRowCellDisplayText(x, "JV No")
                            DocumentNumber = DataObject(String.Format("SELECT CONCAT('JV-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,5,'0')) FROM journal_voucher WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", xBranchID, xBranchCode, Format(DateValue(BandedGridView1.GetRowCellDisplayText(x, "JV Date")), "yy"), Format(DateValue(BandedGridView1.GetRowCellDisplayText(x, "JV Date")), "yyyy-MM-dd")))
                        End If
                    End If

                    If DocumentNumber <> PrevDocumentNumber Then
                        SQL = "INSERT INTO journal_voucher SET"
                        SQL &= String.Format(" Payee_ID = '{0}', ", "")
                        SQL &= String.Format(" Payee = '{0}', ", BandedGridView1.GetRowCellDisplayText(x, "Client Name"))
                        SQL &= String.Format(" DocumentDate = '{0}', ", Format(DateValue(BandedGridView1.GetRowCellDisplayText(x, "JV Date")), "yyyy-MM-dd"))
                        SQL &= String.Format(" DocumentNumber = '{0}', ", DocumentNumber)
                        SQL &= String.Format(" PostingDate = '{0}', ", Format(If(BandedGridView1.GetRowCellDisplayText(x, "Posting Date") = "", DateValue(BandedGridView1.GetRowCellDisplayText(x, "JV Date")), DateValue(BandedGridView1.GetRowCellDisplayText(x, "Posting Date"))), "yyyy-MM-dd"))
                        SQL &= String.Format(" ReferenceNumber = '{0}', ", BandedGridView1.GetRowCellDisplayText(x, "JV No"))
                        SQL &= String.Format(" BankID = '{0}', ", BankID)
                        SQL &= String.Format(" ORNum = '{0}', ", "")
                        SQL &= String.Format(" ORDate = '{0}', ", "")
                        SQL &= " JVFrom = '', "
                        SQL &= String.Format(" Explanation = '{0}', ", BandedGridView1.GetRowCellDisplayText(x, "Client Name"))
                        SQL &= String.Format(" PreparedID = '{0}', ", Empl_ID)
                        SQL &= String.Format(" CheckedID = '{0}', ", Empl_ID)
                        SQL &= String.Format(" ApprovedID = '{0}', ", Empl_ID)
                        SQL &= String.Format(" OTAC_Approve = '{0}', ", Format(Date.Now, "MMddHHmm"))
                        SQL &= " voucher_status = 'APPROVED', "
                        SQL &= String.Format(" OTAC_Check = '{0}', ", "")
                        SQL &= String.Format(" User_Code = '{0}', ", User_Code)
                        SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                        SQL &= String.Format(" BounceID = '{0}', ", 0)
                        SQL &= String.Format(" Bounce = '{0}', ", "")
                        SQL &= String.Format(" BounceRemarks = '{0}', ", "")
                        SQL &= String.Format(" ReferenceID = '{0}', ", 0)
                        SQL &= String.Format(" Branch_ID = '{0}';", xBranchID)
                    End If

                    SQL &= "INSERT INTO jv_details SET"
                    SQL &= String.Format(" DocumentNumber = '{0}', ", DocumentNumber)
                    SQL &= String.Format(" AccountCode = '{0}', ", BandedGridView1.GetRowCellValue(x, "Account Code"))
                    SQL &= String.Format(" MotherCode = '{0}', ", BandedGridView1.GetRowCellValue(x, "MotherCode"))
                    SQL &= String.Format(" BusinessCode = '{0}', ", If(BandedGridView1.GetRowCellValue(x, "Business Center Code").ToString = "", 0, BandedGridView1.GetRowCellValue(x, "Business Center Code")))
                    SQL &= String.Format(" DepartmentCode = '{0}', ", "000")
                    SQL &= String.Format(" Debit = '{0}', ", CDbl(If(BandedGridView1.GetRowCellValue(x, "DR").ToString = "", 0, BandedGridView1.GetRowCellValue(x, "DR"))))
                    SQL &= String.Format(" Credit = '{0}', ", CDbl(If(BandedGridView1.GetRowCellValue(x, "CR").ToString = "", 0, BandedGridView1.GetRowCellValue(x, "CR"))))
                    SQL &= String.Format(" Remarks = '{0}';", BandedGridView1.GetRowCellValue(x, "Sundries Account"))
                Next

                If SQL = "" Then
                Else
                    DataObject(SQL)
                End If
                Logs("Import Books [General Journal]", "Save", "Import [General Journal].", "", "", "", "")
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

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If MsgBoxYes("Are you sure you want to export this to Excel Format?") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & "Import Format" & "-" & Format(Date.Now, "yyyy-MM-dd_HHmmss") & ".xlsx"
            Dim Report As New RptExportToXlsx
            With Report
                Dim DT As New DataTable
                With DT
                    .Columns.Add("Account Code")
                    .Columns.Add("Business Code")
                    .Columns.Add("Department Code")
                    .Columns.Add("Debit")
                    .Columns.Add("Credit")
                    .Columns.Add("Remarks")
                    For x As Integer = 0 To 15
                        .Rows.Add("", "", "", 0, 0, "")
                    Next
                End With
                .DataSource = DT
                .lblAccountCode.DataBindings.Add("Text", DT, "Account Code")
                .lblBusinessCode.DataBindings.Add("Text", DT, "Business Code")
                .lblDepartmentCode.DataBindings.Add("Text", DT, "Department Code")
                .lblDebit.DataBindings.Add("Text", DT, "Debit")
                .lblCredit.DataBindings.Add("Text", DT, "Credit")
                .lblRemarks.DataBindings.Add("Text", DT, "Remarks")
                .ExportToXlsx(FName)
                Process.Start(FName)
            End With

            Dim COA As New RptChartOfAccountsV2
            With COA
                Dim DT As New DataTable
                DT = DataSource("SELECT IF(Main_ID = 0,`Code`,'') AS 'Code', IF(Main_ID = 0,Title,'') AS 'Mother Account', IF(Main_ID = 0,'',`Code`) AS 'Sub-Account Code', IF(Main_ID = 0,'',Title) AS 'Sub-Account' FROM account_chart WHERE `status` = 'ACTIVE' ORDER BY account_chart.`Code`")

                .DataSource = DT
                .lblMotherCode.DataBindings.Add("Text", DT, "Code")
                .lblMotherAccount.DataBindings.Add("Text", DT, "Mother Account")
                .lblSubcode.DataBindings.Add("Text", DT, "Sub-Account Code")
                .lblSubaccount.DataBindings.Add("Text", DT, "Sub-Account")
                .ShowPreview()
            End With
            Cursor = Cursors.Default
        End If
    End Sub
End Class