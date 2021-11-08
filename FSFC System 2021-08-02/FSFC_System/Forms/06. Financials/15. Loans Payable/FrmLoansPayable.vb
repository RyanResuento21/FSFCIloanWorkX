Public Class FrmLoansPayable

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Public From_GL As Boolean
    Public GL_DocumentNumber As String
    Private Sub FrmLoansPayable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        If From_GL Then
            cbxAll.Checked = True
        End If
        cbxDisplay.SelectedIndex = 0
        If From_GL Then
            Dim i As Integer = 0
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Document Number") = GL_DocumentNumber Then
                    i = x
                    Exit For
                End If
            Next
            GridView1.FocusedRowHandle = i
        End If

        Dim DT_Status As DataTable = DataSource("SELECT 'For Checking' AS 'Status' UNION SELECT 'For Approval' UNION SELECT 'For Check Voucher' UNION SELECT 'Partially Paid' UNION SELECT 'Fully Paid' UNION SELECT 'Non Payable' UNION SELECT 'Cancelled'")
        With cbxStatus
            .Location = New Point(553, 6)
            .Size = New Point(183, 26)
            .Properties.LookAndFeel.SkinName = "Blue"
            .Properties.Items.Clear()
            For x As Integer = 0 To DT_Status.Rows.Count - 1
                .Properties.Items.Add(DT_Status(x)("Status"), DT_Status(x)("Status"), If(DT_Status(x)("Status") = "Cancelled", CheckState.Unchecked, CheckState.Checked), True)
            Next
            .Properties.SeparatorChar = ";"
        End With
        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX40, LabelX42, LabelX41, LabelX39})

            GetCheckBoxFontSettings({cbxAll})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint, btnAttach})

            GetComboBoxFontSettings({cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetCheckComboBoxFontSettings({cbxStatus})
        Catch ex As Exception
            TriggerBugReport("Loans Payable - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        LblTitle_Click(sender, e)
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Loans Payable", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    LP.ID,"
        SQL &= "    LP.PayeeID,"
        SQL &= "    LP.Payee,"
        SQL &= "    Payee_Type,"
        SQL &= "    (SELECT CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank' FROM branch_bank WHERE ID = LP.BankID) AS 'Bank', LP.BankID, "
        SQL &= "    LP.Terms AS 'Terms',"
        SQL &= "    DATE_FORMAT(LP.DocumentDate,'%M %d, %Y') AS 'Document Date',"
        SQL &= "    LP.DocumentNumber AS 'Document Number',"
        SQL &= "    DATE_FORMAT(PostingDate,'%M %d, %Y') AS 'Posting Date',"
        SQL &= "    LP.ReferenceNumber AS 'Reference Number',"
        SQL &= "    DATE_FORMAT(Delivery_Date,'%M %d, %Y') AS 'Delivery Date',"
        SQL &= "    Explanation,"
        SQL &= "    Amount AS 'Total Payable',"
        SQL &= "    Paid AS 'Total Payment',"
        SQL &= "    Employee(PreparedID) AS 'Prepared By', PreparedID, "
        SQL &= "    BRANCH(branch_id) AS 'Branch', User_EmplID, Branch_ID, IF(NotAP = 1,'NON PAYABLE',IF(JVNumber != '','REVERSED',IF(`Status` IN ('DELETED','CANCELLED','DISAPPROVED'),`status`,IF(AP_Status='PENDING','FOR CHECKING',IF(AP_Status='CHECKED','FOR APPROVAL',IF(AP_Status='APPROVED','FOR CHECK VOUCHER',AP_Status)))))) AS 'AP_Status', Employee(CheckedID) AS 'Checked By', Employee(ApprovedID) AS 'Approved By', OTAC_Check, OTAC_Approve, Attach, JVNumberV2, NotAP, "
        SQL &= "    IFNULL(DC.DocumentDate,'') AS 'DocumentDate_DC', IFNULL(DC.ReceivedDate,'') AS 'ReceivedDate_DC', IFNULL(DC.ReferenceNumber,'') AS 'ReferenceNumber_DC', IFNULL(DC.DocumentNumber,'') AS 'DocumentNumber_DC', IFNULL(DC.BankID,'') AS 'BankID_DC', IFNULL(DC.Principal,0) AS 'Principal_DC', IFNULL(DC.Terms,0) AS 'Terms_DC', IFNULL(DC.InterestRate,0) AS 'InterestRate_DC', IFNULL(DC.UDI,0) AS 'UDI_DC', LastCheck, ForRollOver, DC.ID AS 'DC_ID', IFNULL(DueStatus,'') AS 'DueStatus', DC.DocumentNumber AS 'DC_DocumentNumber', Multiple"
        SQL &= "  FROM loans_payable LP LEFT JOIN (SELECT ID, DocumentDate, ReceivedDate, ReferenceNumber, DocumentNumber, BankID, DueStatus, Principal, Terms, InterestRate, UDI, (SELECT MAX(CheckDate) FROM dc_details WHERE DocumentNumber = due_check.DocumentNumber AND `status` = 'ACTIVE') AS 'LastCheck', ForRollOver, Multiple FROM due_check WHERE `status` = 'ACTIVE' AND SUBSTRING(DocumentNumber,1,2) = 'LP') DC ON DC.DocumentNumber = LP.DocumentNumber WHERE"
        Dim ForChecking As Boolean
        Dim ForApproval As Boolean
        Dim ForCV As Boolean
        Dim PartiallyPaid As Boolean
        Dim FullyPaid As Boolean
        Dim NonPayable As Boolean
        Dim Cancelled As Boolean
        For x As Integer = 0 To cbxStatus.Properties.Items.Count - 1
            If cbxStatus.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Checking" Then
                    ForChecking = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Approval" Then
                    ForApproval = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Check Voucher" Then
                    ForCV = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Partially Paid" Then
                    PartiallyPaid = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Fully Paid" Then
                    FullyPaid = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Non Payable" Then
                    NonPayable = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Cancelled" Then
                    Cancelled = True
                End If
            End If
        Next
        If Cancelled Then
            If ForChecking = False And ForApproval = False And ForCV = False And PartiallyPaid = False And FullyPaid = False And NonPayable = False Then
                SQL &= " (`status` IN ('CANCELLED','DELETED','DISAPPROVED'))"
            Else
                SQL &= " `status` IN ('ACTIVE','CANCELLED','DELETED','DISAPPROVED') AND (IF(NotAP = 1,'NOT PAYABLE',AP_Status) = 'DISAPPROVED' "
                If ForChecking Or ForApproval Or ForCV Or PartiallyPaid Or FullyPaid Or NonPayable Then
                    SQL &= " OR "
                End If
                If ForChecking Then
                    SQL &= " IF(`status` = 'ACTIVE',IF(NotAP = 1,'NOT PAYABLE',AP_Status) = 'PENDING',TRUE)"
                    If ForApproval Or ForCV Or PartiallyPaid Or FullyPaid Or NonPayable Then
                        SQL &= " OR "
                    End If
                End If
                If ForApproval Then
                    SQL &= " IF(`status` = 'ACTIVE',IF(NotAP = 1,'NOT PAYABLE',AP_Status) = 'CHECKED',TRUE)"
                    If ForCV Or PartiallyPaid Or FullyPaid Or NonPayable Then
                        SQL &= " OR "
                    End If
                End If
                If ForCV Then
                    SQL &= " IF(`status` = 'ACTIVE',IF(NotAP = 1,'NOT PAYABLE',AP_Status) = 'APPROVED',TRUE)"
                    If PartiallyPaid Or FullyPaid Or NonPayable Then
                        SQL &= " OR "
                    End If
                End If
                If PartiallyPaid Then
                    SQL &= " IF(`status` = 'ACTIVE',IF(NotAP = 1,'NOT PAYABLE',AP_Status) = 'PARTIALLY PAID',TRUE)"
                    If FullyPaid Or NonPayable Then
                        SQL &= " OR "
                    End If
                End If
                If FullyPaid Then
                    SQL &= " IF(`status` = 'ACTIVE',IF(NotAP = 1,'NOT PAYABLE',AP_Status) = 'FULLY PAID',TRUE)"
                    If NonPayable Then
                        SQL &= " OR "
                    End If
                End If
                If NonPayable Then
                    SQL &= " IF(`status` = 'ACTIVE',IF(NotAP = 1,'NOT PAYABLE',AP_Status) = 'NOT PAYABLE',TRUE)"
                End If
                SQL &= ")"
            End If
        Else
            SQL &= " `status` = 'ACTIVE'"
            If ForChecking = False And ForApproval = False And ForCV = False And PartiallyPaid = False And FullyPaid = False And NonPayable = False Then
            Else
                SQL &= " AND ("
                If ForChecking Then
                    SQL &= " IF(NotAP = 1,'NOT PAYABLE',AP_Status) = 'PENDING'"
                    If ForApproval Or ForCV Or PartiallyPaid Or FullyPaid Or NonPayable Then
                        SQL &= " OR "
                    End If
                End If
                If ForApproval Then
                    SQL &= " IF(NotAP = 1,'NOT PAYABLE',AP_Status) = 'CHECKED'"
                    If ForCV Or PartiallyPaid Or FullyPaid Or NonPayable Then
                        SQL &= " OR "
                    End If
                End If
                If ForCV Then
                    SQL &= " IF(NotAP = 1,'NOT PAYABLE',AP_Status) = 'APPROVED'"
                    If PartiallyPaid Or FullyPaid Or NonPayable Then
                        SQL &= " OR "
                    End If
                End If
                If PartiallyPaid Then
                    SQL &= " IF(NotAP = 1,'NOT PAYABLE',AP_Status) = 'PARTIALLY PAID'"
                    If FullyPaid Or NonPayable Then
                        SQL &= " OR "
                    End If
                End If
                If FullyPaid Then
                    SQL &= " IF(NotAP = 1,'NOT PAYABLE',AP_Status) = 'FULLY PAID'"
                    If NonPayable Then
                        SQL &= " OR "
                    End If
                End If
                If NonPayable Then
                    SQL &= " IF(NotAP = 1,'NOT PAYABLE',AP_Status) = 'NOT PAYABLE'"
                End If
                SQL &= ")"
            End If
        End If
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(LP.DocumentDate) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        If DefaultBankID > 0 Then
            SQL &= String.Format(" AND LP.BankID = '{0}'", DefaultBankID)
        End If
        SQL &= String.Format("  AND FIND_IN_SET(LP.Branch_ID,'{0}') ORDER BY LP.DocumentNumber DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        GridControl1.DataSource = DataSource(SQL)
        If Multiple_ID.Contains(",") Then
            GridColumn7.Visible = True
            GridColumn7.VisibleIndex = 9
        End If
        With GridView1
            .Columns("Payee").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("Payee").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            .Columns("Total Payable").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Total Payable").SummaryItem.DisplayFormat = "{0:n2}"
            .Columns("Total Payment").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Total Payment").SummaryItem.DisplayFormat = "{0:n2}"
        End With

        If GridView1.RowCount > 19 Then
            GridColumn3.Width = 245 - 17
        Else
            GridColumn3.Width = 245
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        GridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting("LOANS PAYABLE LIST", GridControl1)
        Logs("Loans Payable", "Print", "[SENSITIVE] Print Loans Payable List", "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If FirstLoad Then
            Exit Sub
        End If

        LoadData()
    End Sub

    Private Sub CbxDisplay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDisplay.SelectedIndexChanged
        If cbxDisplay.SelectedIndex = 0 Then
            dtpFrom.Value = Date.Now
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = Date.Now
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 1 Then
            Dim today As Date = Date.Today
            Dim dayDiff As Integer = today.DayOfWeek - DayOfWeek.Monday
            Dim monday As Date = today.AddDays(-dayDiff)

            dtpFrom.Value = monday
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = monday.AddDays(6)
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 2 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-MM-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, String.Format("yyyy-MM-{0}", Date.DaysInMonth(Format(Date.Now, "yyyy"), Format(Date.Now, "MM")))))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 3 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-01-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, "yyyy-12-31"))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 4 Then
            dtpFrom.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Enabled = True
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub DtpFrom_Leave(sender As Object, e As EventArgs) Handles dtpFrom.Leave
        dtpTo.MinDate = dtpFrom.Value
    End Sub

    Private Sub CbxAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAll.CheckedChanged
        If cbxAll.Checked Then
            cbxDisplay.SelectedIndex = -1
            cbxDisplay.Enabled = False
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = ""
            dtpTo.Enabled = False
            dtpTo.CustomFormat = ""
        Else
            cbxDisplay.SelectedIndex = 0
            cbxDisplay.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Loans Payable-" & GridView1.GetFocusedRowCellValue("Document Number")
            .LPNumber = GridView1.GetFocusedRowCellValue("Document Number")
            .TotalImage = GridView1.GetFocusedRowCellValue("Attach")
            .ID = GridView1.GetFocusedRowCellValue("Document Number")
            .Type = "Loans Payable"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                GridView1.SetFocusedRowCellValue("Attach", .TotalImage)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("AP_Status"))
            If Status = "DELETED" Or Status = "CANCELLED" Or Status = "DISAPPROVED" Or Status = "REVERSED" Then
                e.Appearance.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub INotAP_Click(sender As Object, e As EventArgs) Handles iNotAP.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("JVNumberV2") = "" Then
                MsgBox("Loans Payable is not auto generated.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AP_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("AP_Status") = "FOR APPROVAL" Then
                MsgBox("Loans Payable is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AP_Status") = "FULLY PAID" Or GridView1.GetFocusedRowCellValue("AP_Status") = "PARTIALLY PAID" Then
                MsgBox("Loans Payable already have a transaction.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AP_Status") = "CANCELLED" Or GridView1.GetFocusedRowCellValue("AP_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("AP_Status") = "DISAPPROVED" Then
                MsgBox(String.Format("Loans Payable is already {0}.", GridView1.GetFocusedRowCellValue("AP_Status")), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If MsgBoxYes(String.Format("Are you sure you want to set this as {0}Loans Payable?", If(GridView1.GetFocusedRowCellValue("NotAP") = 0, "Not ", ""))) = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Dim SQL As String = String.Format("UPDATE loans_payable SET NotAP = {1} WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID"), If(GridView1.GetFocusedRowCellValue("NotAP") = 0, 1, 0))
            DataObject(SQL)
            Logs("Loans Payable", "Not LP", Reason, "", "", "", "")
            LoadData()
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AP_Status") = "FULLY PAID" Or GridView1.GetFocusedRowCellValue("AP_Status") = "PARTIALLY PAID" Then
                MsgBox("Loans Payable already have a transaction.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("JVNumberV2") = "" Then
                If GridView1.GetFocusedRowCellValue("Payee_Type") = "B" Then
                Else
                    MsgBox("Loans Payable is not auto generated.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Rename As New FrmRenamePayee
        With Rename
            .txtPayee.Text = GridView1.GetFocusedRowCellValue("Payee")
            If .ShowDialog = DialogResult.OK Then
                Dim SQL As String = String.Format("UPDATE loans_payable SET Payee = '{1}' WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID"), .txtPayee.Text.InsertQuote)
                DataObject(SQL)
                Logs("Loans Payable", "Change Payee", String.Format("Changed Payee for {0} from {1} to {2}", GridView1.GetFocusedRowCellValue("Payee").ToString.InsertQuote & " - " & GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Payee").ToString.InsertQuote, .txtPayee.Text.InsertQuote), "", "", "", "")
                LoadData()
                MsgBox("Successfully Changed!", MsgBoxStyle.Information, "Info")
            End If
        End With
    End Sub

    Private Sub GridView1_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        Dim Rows As New ArrayList()
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length > 1 Then
            Dim TotalR As Double
            Dim TotalP As Double
            For x As Integer = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Integer = selectedRowHandles(x)
                TotalR += GridView1.GetRowCellValue(selectedRowHandle, "Total Payable")
                TotalP += GridView1.GetRowCellValue(selectedRowHandle, "Total Payment")
            Next
            GridView1.Columns("Total Payable").SummaryItem.DisplayFormat = FormatNumber(TotalR, 2)
            GridView1.Columns("Total Payment").SummaryItem.DisplayFormat = FormatNumber(TotalP, 2)
        Else
            GridView1.Columns("Total Payable").SummaryItem.DisplayFormat = "{0:n2}"
            GridView1.Columns("Total Payment").SummaryItem.DisplayFormat = "{0:n2}"
        End If
    End Sub

    Private Sub ICheckRegistry_Click(sender As Object, e As EventArgs) Handles iCheckRegistry.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AP_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("AP_Status") = "FOR APPROVAL" Then
                MsgBox("Loans Payable is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim PDC As New FrmDueCheckRegistry
        With PDC
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            .cbxBank.Enabled = False
            .cbxPayor.Enabled = False
            .txtDocumentNumber.Text = GridView1.GetFocusedRowCellValue("Document Number")
            .Payor = GridView1.GetFocusedRowCellValue("Payee")
            .lblPayor.Text = "<span align='right'><font color='red'>*</font>Payee :</span>"
            If GridView1.GetFocusedRowCellValue("DocumentNumber_DC") = "" Then
                .btnDelete.Enabled = False
                .DefaultBank = GridView1.GetFocusedRowCellValue("BankID")
                .dPrincipal.Value = CDbl(GridView1.GetFocusedRowCellValue("Total Payable")) - CDbl(GridView1.GetFocusedRowCellValue("Total Payment"))
                .iTerms_C.Value = GridView1.GetFocusedRowCellValue("Terms")
            Else
                .btnDelete.Enabled = True
                .btnSave.Enabled = False
                .btnAddC.Enabled = False
                .btnRemoveC.Enabled = False
                .btnRefresh.Enabled = False
                .dtpReceivedDate.Enabled = False
                .txtReferenceNumber.Enabled = False
                .dPrincipal.Enabled = False
                .iTerms_C.Enabled = False
                .dInterest_T.Enabled = False
                .dUDI_C.Enabled = False

                .DefaultBank = GridView1.GetFocusedRowCellValue("BankID_DC")
                .dtpReceivedDate.Value = GridView1.GetFocusedRowCellValue("ReceivedDate_DC")
                .txtReferenceNumber.Text = GridView1.GetFocusedRowCellValue("ReferenceNumber_DC")
                .dPrincipal.Value = CDbl(GridView1.GetFocusedRowCellValue("Principal_DC"))
                .iTerms_C.Value = CDbl(GridView1.GetFocusedRowCellValue("Terms_DC"))
                .dInterest_T.Value = CDbl(GridView1.GetFocusedRowCellValue("InterestRate_DC"))
                .dUDI_C.Value = CDbl(GridView1.GetFocusedRowCellValue("UDI_DC"))
            End If
            .btnVerify.Visible = True
            If GridView1.GetFocusedRowCellValue("DueStatus") = "PENDING" Then
                .btnVerify.Enabled = True
            Else
                .btnVerify.Enabled = False
            End If
            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnRollOver_Click(sender As Object, e As EventArgs) Handles btnRollOver.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AP_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("AP_Status") = "FOR APPROVAL" Then
                MsgBox("Loans Payable is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("DocumentNumber_DC") = "" Then
                MsgBox("Loans Payable does not have a Check Registry yet, No need for Roll Over.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim PDC As New FrmDueCheckRegistry
        With PDC
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            .cbxBank.Enabled = False
            .cbxPayor.Enabled = False
            .txtDocumentNumber.Text = GridView1.GetFocusedRowCellValue("Document Number")
            .Payor = GridView1.GetFocusedRowCellValue("Payee")
            .RollOver = True

            .btnDelete.Enabled = False
            .btnSave.Enabled = True
            .btnRefresh.Enabled = False

            .DefaultBank = GridView1.GetFocusedRowCellValue("BankID_DC")
            .dtpReceivedDate.Value = GridView1.GetFocusedRowCellValue("ReceivedDate_DC")
            .txtReferenceNumber.Text = GridView1.GetFocusedRowCellValue("ReferenceNumber_DC")
            .dPrincipal.Value = CDbl(GridView1.GetFocusedRowCellValue("Total Payable")) - CDbl(GridView1.GetFocusedRowCellValue("Total Payment"))
            .iTerms_C.Value = CDbl(GridView1.GetFocusedRowCellValue("Terms_DC"))
            .dInterest_T.Value = CDbl(GridView1.GetFocusedRowCellValue("InterestRate_DC"))
            .dUDI_C.Value = CDbl(GridView1.GetFocusedRowCellValue("UDI_DC"))
            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnForRollOver_Click(sender As Object, e As EventArgs) Handles btnForRollOver.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AP_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("AP_Status") = "FOR APPROVAL" Then
                MsgBox("Loans Payable is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("DocumentNumber_DC") = "" Then
                MsgBox("Loans Payable does not have a Check Registry yet, No need for Roll Over.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Message As String = "Are you sure you want to set this Loans Payable for Roll Over?"
        If GridView1.GetFocusedRowCellValue("ForRollOver") = 1 Then
            Message = "Are you sure you want to cancel the For Roll Over for this Loans Payable "
        End If
        If MsgBoxYes(Message) = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Dim SQL As String = String.Format("UPDATE due_check SET ForRollOver = {1} WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE';", GridView1.GetFocusedRowCellValue("Document Number"), If(GridView1.GetFocusedRowCellValue("ForRollOver") = 0, 1, 0))
            DataObject(SQL)
            Logs("Loans Payable", "For Roll Over", Reason, "", "", "", "")
            LoadData()
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnCheckManagement_Click(sender As Object, e As EventArgs) Handles btnCheckManagement.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AP_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("AP_Status") = "FOR APPROVAL" Then
                MsgBox("Loans Payable is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("DocumentNumber_DC") = "" Then
                MsgBox("Loans Payable does not have a Check Registry yet.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        With FrmPDCManagement
            .Tag = 22
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Logs("Loans Payable", "Open", "PDC Management", "", "", "", "")
            Forms(FrmPDCManagement, FrmMain.PanelControl3)

            .SuperTabControl1.SelectedTabIndex = 4
            .cbxPayeeV5.SelectedValue = GridView1.GetFocusedRowCellValue("DC_ID")
            .GridView11.OptionsSelection.MultiSelect = False
        End With
    End Sub

    Private Sub BtnReference_Click(sender As Object, e As EventArgs) Handles btnReference.Click
        GridView1.SetFocusedRowCellValue("Reference Number", UpdateReferenceNumber("Loans Payable", "loans_payable", GridView1.GetFocusedRowCellValue("Reference Number"), GridView1.GetFocusedRowCellValue("ID"), GridView1.GetFocusedRowCellValue("Document Number")))
    End Sub
End Class