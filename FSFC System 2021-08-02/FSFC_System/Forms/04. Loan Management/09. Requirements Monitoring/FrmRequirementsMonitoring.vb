Public Class FrmRequirementsMonitoring

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Dim TotalImage As Integer
    Public For_Viewing As Boolean
    Public CreditNumber As String
    Private Sub FrmRequirementsMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView3})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        If For_Viewing Then
            cbxAll.Checked = True
        End If
        cbxDisplay.SelectedIndex = 0
        SuperTabControl1.SelectedTab = tabList

        LoadData()
        FirstLoad = False

        If For_Viewing Then
            Dim i As Integer = 0
            For x As Integer = 0 To GridView3.RowCount - 1
                If GridView3.GetRowCellValue(x, "Credit Number") = CreditNumber Then
                    i = x
                    Exit For
                End If
            Next
            GridView3.OptionsSelection.MultiSelect = False
            GridView3.FocusedRowHandle = i
            GridView3_DoubleClick(sender, e)
            tabList.Visible = False
            btnBack.Enabled = False
            btnNext.Enabled = False
            btnRefresh.Enabled = False
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX2, LabelX3, LabelX4, LabelX85, LabelX87, LabelX86})

            GetLabelFontSettingsDefaultSize({LabelX5, LabelX6})

            GetLabelWithBackgroundFontSettings({LabelX1, lblLoanRequirements})

            GetTextBoxFontSettings({txtName, txtCreditNumber, txtBorrowerNumber})

            GetCheckBoxFontSettings({cbxAll})

            GetComboBoxFontSettings({cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetButtonFontSettings({btnRefresh, btnCancel, btnPrint, btnAttach, btnSearch})

            GetTabControlFontSettings({SuperTabControl1})

            GetContextMenuBarFontSettings({ContextMenuBar1, ContextMenuBar2})
        Catch ex As Exception
            TriggerBugReport("Requirements Monitoring - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Requirement", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    credit_application.ID, credit_application.BorrowerID,"
        SQL &= "    DATE_FORMAT(trans_date,'%m.%d.%Y') AS 'Date',"
        SQL &= "    credit_application.CreditNumber AS 'Credit Number',"
        SQL &= "    IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)) AS 'Borrower',"
        SQL &= "    COUNT(CASE WHEN S.is_complete = 'YES' THEN S.ID END) AS 'Submitted',"
        SQL &= "    COUNT(CASE WHEN S.is_complete = 'NO' THEN S.ID END) AS 'Remaining',"
        SQL &= "    AmountApplied AS 'Principal',"
        SQL &= "    Product,"
        SQL &= "    IF(PaymentRequest = 'CLOSED','CLOSED ACCOUNT',IF(ApproveStatus = 'For ReApprove','FOR REAPPROVAL',IF(ApproveStatus = 'For Special','FOR SPECIAL APPROVAL',IF(PaymentRequest = 'RELEASED' AND `status` = 'ACTIVE','BOOKED',IF(PaymentRequest = 'APPROVED REQUEST' AND `status` = 'ACTIVE','FOR RELEASING',IF(PaymentRequest = 'CHECKED REQUEST' AND `status` = 'ACTIVE' AND CI_Status = 'APPROVED','CV FOR APPROVAL',IF(PaymentRequest = 'REQUESTED' AND `status` = 'ACTIVE' AND CI_Status = 'APPROVED',CONCAT(IF(CVforJV,'JV','CV'),' FOR CHECKING'),IF(PaymentRequest = 'PENDING' AND CI_Status = 'APPROVED' AND `status` = 'ACTIVE' AND loan_type != 'RESTRUCTURE' AND (From_ROPOA = 1 OR CVforJV = 1),'FOR JOURNAL VOUCHER',IF(application_status = 'PENDING' AND `status` = 'ACTIVE','FOR BM/OIC APPROVAL',IF(PaymentRequest = 'PENDING' AND CI_Status = 'APPROVED' AND `status` = 'ACTIVE' AND loan_type != 'RESTRUCTURE','FOR PAYMENT REQUEST',IF(PaymentRequest = 'REQUEST' AND CI_Status = 'APPROVED' AND `status` = 'ACTIVE' AND loan_type != 'RESTRUCTURE','FOR CHECK PREPARATION',IF(PaymentRequest = 'PENDING' AND CI_Status = 'APPROVED' AND `status` = 'ACTIVE' AND loan_type = 'RESTRUCTURE','FOR JOURNAL VOUCHER',IF(CI_Status = 'CHECKED' AND application_status = 'APPROVED' AND `status` = 'ACTIVE' AND ForCI_Product(Product_ID) = 'Yes','FOR CRECOMM APPROVAL',IF(CI_Status = 'ONGOING' AND application_status = 'APPROVED' AND `status` = 'ACTIVE' AND ForCI_Product(Product_ID) = 'Yes','CREDIT INVESTIGATION STARTED',IF(CI_Status = 'PENDING' AND application_status = 'APPROVED' AND `status` = 'ACTIVE' AND ForCI_Product(Product_ID) = 'No','FOR CRECOMM APPROVAL',IF(CI_Status = 'PENDING' AND application_status = 'APPROVED' AND `status` = 'ACTIVE' AND ForCI_Product(Product_ID) = 'Yes','FOR CREDIT INVESTIGATION',IF(application_status = 'PENDING' AND `status` = 'ACTIVE','FOR BM/OIC APPROVAL',IF(`status` = 'HOLD','HOLD',IF(`status` = 'CANCELLED' OR `status` = 'DELETED','CANCELLED',IF(CI_Status = 'DISAPPROVED','DISAPPROVED',IF(PaymentRequest = 'JV Request','CURRENTLY ON JV','DRAFT'))))))))))))))))))))) AS 'Application Status',"
        SQL &= "    (SELECT Employee(empl_id) FROM users WHERE users.user_code = credit_application.user_code LIMIT 1) AS 'Loans Processor',"
        SQL &= "    Employee(Assigned_CI) AS 'Credit Investigator',"
        SQL &= "    Attach, Branch(Branch_ID) AS 'Branch' "
        SQL &= " FROM credit_application LEFT JOIN (SELECT ID, is_complete, BorrowerID, CreditNumber FROM submit_documents WHERE `status` = 'ACTIVE') S ON S.BorrowerID = credit_application.BorrowerID AND S.CreditNumber = credit_application.CreditNumber"
        SQL &= String.Format("    WHERE Branch_ID IN ({0})", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(trans_date) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        SQL &= " AND (`status` = 'ACTIVE' OR `status` = 'HOLD' OR `status` = 'CANCELLED' OR `status` = 'DELETED') AND application_status != 'DISAPPROVED' AND CI_Status != 'DISAPPROVED' GROUP BY credit_application.CreditNumber ORDER BY trans_date DESC, credit_application.CreditNumber DESC;"

        GridControl3.DataSource = DataSource(SQL)
        If Multiple_ID.Contains(",") Then
            GridColumn28.Visible = True
            GridColumn28.VisibleIndex = 10
        End If
        GridView3.Columns("Borrower").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView3.Columns("Borrower").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView3.RowCount > 18 Then
            GridColumn23.Width = 140
        Else
            GridColumn23.Width = 140 + 17
        End If
        Cursor = Cursors.Default
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

    Private Sub GeneralRequirements()
        Dim SQL As String = "SELECT "
        SQL &= "    S.doc_ID AS 'ID',"
        SQL &= "    IFNULL(S.ID,0) AS 'S_ID',"
        SQL &= "    IF(S.doc_id IS NOT NULL AND S.is_complete = 'YES','True','False') AS 'RECEIVED',"
        SQL &= "    S.document AS 'DOCUMENT NAME',"
        SQL &= "    IFNULL(DATE_FORMAT(S.date_received,'%b.%d.%Y'),'') AS 'DATE RECEIVED',"
        SQL &= "    IFNULL(S.received_by,'') AS 'RECEIVED BY',"
        SQL &= "    IFNULL(S.remarks,'') AS 'REMARKS',"
        SQL &= "    IFNULL(S.Attach,0) AS 'ATTACH', (SELECT mandatory  FROM document_setup WHERE ID = S.doc_ID) AS 'MANDATORY'"
        SQL &= " FROM submit_documents S"
        SQL &= String.Format("    WHERE S.is_genreq = 'YES' AND S.CreditNumber = '{0}' AND S.BorrowerID = '{1}' AND S.status = 'ACTIVE'", txtCreditNumber.Text, txtBorrowerNumber.Text)
        GridControl1.DataSource = DataSource(SQL)

        If GridView1.RowCount > 7 Then
            GridColumn18.Width = 352
        Else
            GridColumn18.Width = 369
        End If
    End Sub

    Private Sub LoadRequirements()
        Dim SQL As String = "SELECT "
        SQL &= "    S.doc_ID AS 'ID',"
        SQL &= "    IFNULL(S.ID,0) AS 'S_ID',"
        SQL &= "    IF(S.doc_id IS NOT NULL AND S.is_complete = 'YES','True','False') AS 'RECEIVED',"
        SQL &= "    S.document AS 'DOCUMENT NAME',"
        SQL &= "    IFNULL(DATE_FORMAT(S.date_received,'%b.%d.%Y'),'') AS 'DATE RECEIVED',"
        SQL &= "    IFNULL(S.received_by,'') AS 'RECEIVED BY',"
        SQL &= "    IFNULL(S.remarks,'') AS 'REMARKS',"
        SQL &= "    IFNULL(S.Attach,0) AS 'ATTACH', (SELECT mandatory  FROM document_setup WHERE ID = S.doc_ID) AS 'MANDATORY'"
        SQL &= " FROM submit_documents S"
        SQL &= String.Format("    WHERE S.is_genreq = 'NO' AND S.CreditNumber = '{0}' AND S.BorrowerID = '{1}' AND S.status = 'ACTIVE'", txtCreditNumber.Text, txtBorrowerNumber.Text)
        GridControl2.DataSource = DataSource(SQL)

        If GridView2.RowCount > 7 Then
            GridColumn14.Width = 352
        Else
            GridColumn14.Width = 369
        End If
    End Sub

    Private Sub IAttach_Click(sender As Object, e As EventArgs) Handles iAttach.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Requirement As New FrmRequirements
        With Requirement
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            .txtDocument.Text = GridView1.Columns.View.GetFocusedRow("DOCUMENT NAME")
            .txtRemarks.Text = GridView1.Columns.View.GetFocusedRow("REMARKS")
            .CreditNumber = txtCreditNumber.Text
            .BorrowerID = txtBorrowerNumber.Text
            .DocID = GridView1.Columns.View.GetFocusedRow("ID")
            .ID = GridView1.Columns.View.GetFocusedRow("S_ID")
            If GridView1.GetFocusedRow("ATTACH") > 0 Then
                .btnSave.Enabled = True
            End If
            If GridView1.GetFocusedRow("RECEIVED") = True Then
                .cbxComplete.Checked = True
            Else
                .cbxComplete.Checked = False
            End If
            .TotalImage = GridView1.Columns.View.GetFocusedRow("ATTACH")
            If .ShowDialog = DialogResult.OK Then
                If .cbxComplete.Checked = True Then
                    GridView1.SetFocusedRowCellValue("RECEIVED", True)
                Else
                    GridView1.SetFocusedRowCellValue("RECEIVED", False)
                End If
                GridView1.SetFocusedRowCellValue("DATE RECEIVED", Format(.dtpReceived.Value, "MMM.dd.yyyy"))
                GridView1.SetFocusedRowCellValue("RECEIVED BY", Empl_Name)
                GridView1.SetFocusedRowCellValue("REMARKS", .txtRemarks.Text)
                GridView1.SetFocusedRowCellValue("ATTACH", .TotalImage)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub IView_Click(sender As Object, e As EventArgs) Handles iView.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Requirements-" & GridView1.Columns.View.GetFocusedRow("ID")
            .Type = GridView1.Columns.View.GetFocusedRow("ID")
            .TotalImage = GridView1.Columns.View.GetFocusedRow("ATTACH")
            .CreditNumber = txtCreditNumber.Text
            .ID = txtCreditNumber.Text
            .btnBrowse.Enabled = False
            Dim Result = .ShowDialog
            .Dispose()
        End With
    End Sub

    Private Sub IView_2_Click(sender As Object, e As EventArgs) Handles iView_2.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Requirements-" & GridView2.Columns.View.GetFocusedRow("ID")
            .Type = GridView2.Columns.View.GetFocusedRow("ID")
            .TotalImage = GridView2.Columns.View.GetFocusedRow("ATTACH")
            .CreditNumber = txtCreditNumber.Text
            .ID = txtCreditNumber.Text
            .btnBrowse.Enabled = False
            Dim Result = .ShowDialog
            .Dispose()
        End With
    End Sub

    Private Sub IAddReq_Click(sender As Object, e As EventArgs) Handles iAddReq.Click
        Dim AddR As New FrmAddRequirement
        If AddR.ShowDialog = DialogResult.OK Then
            For x As Integer = 0 To GridView1.RowCount - 1
                If AddR.cbxDocument.Text = GridView1.GetRowCellValue(x, "DOCUMENT NAME") Then
                    MsgBox(String.Format("Document {0} already exist in the requirements, please check your data.", AddR.cbxDocument.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Next

            Dim SQL As String = "INSERT INTO submit_documents SET "
            SQL &= String.Format("BorrowerID = '{0}', ", txtBorrowerNumber.Text)
            SQL &= String.Format("CreditNumber = '{0}', ", txtCreditNumber.Text)
            SQL &= String.Format("doc_id = '{0}', ", AddR.cbxDocument.SelectedValue)
            SQL &= String.Format("document = '{0}', ", AddR.cbxDocument.Text)
            SQL &= String.Format("date_received = '{0}', ", "")
            SQL &= String.Format("received_code = '{0}', ", "")
            SQL &= String.Format("received_by = '{0}', ", "")
            SQL &= String.Format("is_complete = '{0}', ", "NO")
            SQL &= String.Format("remarks = '{0}', ", "")
            SQL &= String.Format("branch_id = '{0}', ", Branch_ID)
            SQL &= String.Format("Attach = '{0}', ", 0)
            SQL &= "is_genreq = 'YES', "
            SQL &= String.Format("Branch_Code = '{0}';", Branch_Code)
            DataObject(SQL)
            GeneralRequirements()
            MsgBox("Successfully Added!", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub IRemoveReq_Click(sender As Object, e As EventArgs) Handles iRemoveReq.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.GetFocusedRowCellValue("S_ID") = 0 Then
            Dim DT As DataTable = GridControl1.DataSource
            Dim Rows As New ArrayList()
            Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
            If selectedRowHandles.Length > 1 Then
                Dim I As Integer
                For I = 0 To selectedRowHandles.Length - 1
                    Dim selectedRowHandle As Integer = selectedRowHandles(I)
                    If (selectedRowHandle >= 0) Then
                        DT.Rows.RemoveAt(selectedRowHandle - I)
                    End If
                Next
            Else
                DT.Rows.RemoveAt(GridView1.FocusedRowHandle)
            End If
            GridControl1.DataSource = DT
            MsgBox("Successfully Removed", MsgBoxStyle.Information, "Info")
        Else
            If MsgBoxYes("Are you sure you want to remove this requirement?") = MsgBoxResult.Yes Then
                If GridView1.GetFocusedRow("RECEIVED") = True Then
                    If MsgBoxYes("Requirement is already received completely, would you really want to remove this requirement?") = MsgBoxResult.Yes Then
                    Else
                        Exit Sub
                    End If
                End If
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Dim DT As DataTable = GridControl1.DataSource
                Dim Rows As New ArrayList()
                Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
                If selectedRowHandles.Length > 1 Then
                    Dim I As Integer
                    For I = 0 To selectedRowHandles.Length - 1
                        Dim selectedRowHandle As Integer = selectedRowHandles(I)
                        If (selectedRowHandle >= 0) Then
                            DataObject(String.Format("UPDATE submit_documents SET `status` = 'DELETED' WHERE ID = '{0}'", DT(selectedRowHandle)("S_ID")))
                        End If
                    Next
                Else
                    DataObject(String.Format("UPDATE submit_documents SET `status` = 'DELETED' WHERE ID = '{0}'", GridView1.GetFocusedRowCellValue("S_ID")))
                End If
                Logs("Requirement", "Remove", Reason, String.Format("Remove Requirement for Credit Number {0}", txtCreditNumber.Text), "", "", txtCreditNumber.Text)
                GeneralRequirements()
                MsgBox("Successfully Removed", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Sub IAttach_2_Click(sender As Object, e As EventArgs) Handles iAttach_2.Click
        Try
            If GridView2.GetFocusedRowCellValue("ID").ToString = "" Or GridView2.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Requirement As New FrmRequirements
        With Requirement
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            .txtDocument.Text = GridView2.Columns.View.GetFocusedRow("DOCUMENT NAME")
            .txtRemarks.Text = GridView2.Columns.View.GetFocusedRow("REMARKS")
            .CreditNumber = txtCreditNumber.Text
            .BorrowerID = txtBorrowerNumber.Text
            .DocID = GridView2.Columns.View.GetFocusedRow("ID")
            .ID = GridView2.Columns.View.GetFocusedRow("S_ID")
            If GridView2.GetFocusedRow("ATTACH") > 0 Then
                .btnSave.Enabled = True
            End If
            If GridView2.GetFocusedRow("RECEIVED") = True Then
                .cbxComplete.Checked = True
            Else
                .cbxComplete.Checked = False
            End If
            .TotalImage = GridView2.Columns.View.GetFocusedRow("ATTACH")
            If .ShowDialog = DialogResult.OK Then
                If .cbxComplete.Checked = True Then
                    GridView2.SetFocusedRowCellValue("RECEIVED", True)
                Else
                    GridView2.SetFocusedRowCellValue("RECEIVED", False)
                End If
                GridView2.SetFocusedRowCellValue("DATE RECEIVED", Format(.dtpReceived.Value, "MMM.dd.yyyy"))
                GridView2.SetFocusedRowCellValue("RECEIVED BY", Empl_Name)
                GridView2.SetFocusedRowCellValue("REMARKS", .txtRemarks.Text)
                GridView2.SetFocusedRowCellValue("ATTACH", .TotalImage)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub IAddReq_2_Click(sender As Object, e As EventArgs) Handles iAddReq_2.Click
        Dim AddR As New FrmAddRequirement
        If AddR.ShowDialog = DialogResult.OK Then
            For x As Integer = 0 To GridView2.RowCount - 1
                If AddR.cbxDocument.Text = GridView2.GetRowCellValue(x, "DOCUMENT NAME") Then
                    MsgBox(String.Format("Document {0} already exist in the requirements, please check your data.", AddR.cbxDocument.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Next

            Dim SQL As String = "INSERT INTO submit_documents SET "
            SQL &= String.Format("BorrowerID = '{0}', ", txtBorrowerNumber.Text)
            SQL &= String.Format("CreditNumber = '{0}', ", txtCreditNumber.Text)
            SQL &= String.Format("doc_id = '{0}', ", AddR.cbxDocument.SelectedValue)
            SQL &= String.Format("document = '{0}', ", AddR.cbxDocument.Text)
            SQL &= String.Format("date_received = '{0}', ", "")
            SQL &= String.Format("received_code = '{0}', ", "")
            SQL &= String.Format("received_by = '{0}', ", "")
            SQL &= String.Format("is_complete = '{0}', ", "NO")
            SQL &= String.Format("remarks = '{0}', ", "")
            SQL &= String.Format("branch_id = '{0}', ", Branch_ID)
            SQL &= String.Format("Attach = '{0}', ", 0)
            SQL &= "is_genreq = 'NO', "
            SQL &= String.Format("Branch_Code = '{0}';", Branch_Code)
            DataObject(SQL)
            LoadRequirements()
            MsgBox("Successfully Added!", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub IRemoveReq_2_Click(sender As Object, e As EventArgs) Handles iRemoveReq_2.Click
        Try
            If GridView2.GetFocusedRowCellValue("ID").ToString = "" Or GridView2.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView2.GetFocusedRowCellValue("S_ID") = 0 Then
            Dim DT As DataTable = GridControl2.DataSource
            Dim Rows As New ArrayList()
            Dim selectedRowHandles As Integer() = GridView2.GetSelectedRows()
            If selectedRowHandles.Length > 1 Then
                Dim I As Integer
                For I = 0 To selectedRowHandles.Length - 1
                    Dim selectedRowHandle As Integer = selectedRowHandles(I)
                    If (selectedRowHandle >= 0) Then
                        DT.Rows.RemoveAt(selectedRowHandle - I)
                    End If
                Next
            Else
                DT.Rows.RemoveAt(GridView2.FocusedRowHandle)
            End If
            GridControl2.DataSource = DT
            MsgBox("Successfully Removed", MsgBoxStyle.Information, "Info")
        Else
            If MsgBoxYes("Are you sure you want to remove this requirement?") = MsgBoxResult.Yes Then
                If GridView2.GetFocusedRow("RECEIVED") = True Then
                    If MsgBoxYes("Requirement is already received completely, would you really want to remove this requirement?") = MsgBoxResult.Yes Then
                    Else
                        Exit Sub
                    End If
                End If
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Dim DT As DataTable = GridControl2.DataSource
                Dim Rows As New ArrayList()
                Dim selectedRowHandles As Integer() = GridView2.GetSelectedRows()
                If selectedRowHandles.Length > 1 Then
                    Dim I As Integer
                    For I = 0 To selectedRowHandles.Length - 1
                        Dim selectedRowHandle As Integer = selectedRowHandles(I)
                        If (selectedRowHandle >= 0) Then
                            DataObject(String.Format("UPDATE submit_documents SET `status` = 'DELETED' WHERE ID = '{0}'", DT(selectedRowHandle)("S_ID")))
                        End If
                    Next
                Else
                    DataObject(String.Format("UPDATE submit_documents SET `status` = 'DELETED' WHERE ID = '{0}'", GridView2.GetFocusedRowCellValue("S_ID")))
                End If
                Logs("Requirement", "Remove", Reason, String.Format("Remove Requirement for Credit Number {0}", txtCreditNumber.Text), "", "", txtCreditNumber.Text)
                LoadRequirements()
                MsgBox("Successfully Removed", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If FirstLoad Then
            Exit Sub
        End If

        LoadData()
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment"
            .Type = "Credit App Attachment"
            .TotalImage = TotalImage
            .CreditNumber = txtCreditNumber.Text
            .ID = txtCreditNumber.Text
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage = .TotalImage
            End If
            .Dispose()
        End With
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Then
            btnBack.Enabled = False
            btnPrint.Enabled = False
            btnNext.Enabled = True
            If txtCreditNumber.Text = "" Then
            Else
                btnAttach.Enabled = True
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Clear(False)
            btnBack.Enabled = True
            btnPrint.Enabled = True
            btnNext.Enabled = False
            btnAttach.Enabled = False
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes("Are you sure you want to close this form?") = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SuperTabControl1.SelectedTab = tabList
        End If
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabRequirements
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
                Clear(False)
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            LoadData()
        End If
    End Sub

    Private Sub Clear(TriggerLoadData As Boolean)
        TotalImage = 0
        txtName.Text = ""
        txtCreditNumber.Text = ""
        txtBorrowerNumber.Text = ""
        GridControl1.Enabled = False
        GridControl2.Enabled = False
        GridControl1.DataSource = Nothing
        GridControl2.DataSource = Nothing

        If TriggerLoadData Then
            LoadData()
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
        StandardPrinting("REQUIREMENT LIST", GridControl1)
        Logs("Requirements Monitoring", "Print", "[SENSITIVE] Print Requirements Monitoring List", "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        IAttach_Click(sender, e)
    End Sub

    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        Try
            If GridView2.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        IAttach_2_Click(sender, e)
    End Sub

    Private Sub GridView3_DoubleClick(sender As Object, e As EventArgs) Handles GridView3.DoubleClick
        Try
            If GridView3.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Cursor = Cursors.WaitCursor
        With GridView3
            txtName.Text = .GetFocusedRowCellValue("Borrower")
            txtCreditNumber.Text = .GetFocusedRowCellValue("Credit Number")
            txtBorrowerNumber.Text = .GetFocusedRowCellValue("BorrowerID")
            TotalImage = .GetFocusedRowCellValue("Attach")
        End With
        GridControl1.Enabled = True
        GridControl2.Enabled = True
        GeneralRequirements()
        LoadRequirements()

        SuperTabControl1.SelectedTab = tabRequirements
        Cursor = Cursors.Default
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.B Then
            btnBack.Focus()
            btnBack.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.N Then
            btnNext.Focus()
            btnNext.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.Left) Or (e.Control And e.KeyCode = Keys.Down) Then
            btnBack.Focus()
            btnBack.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.Right) Or (e.Control And e.KeyCode = Keys.Up) Then
            btnNext.Focus()
            btnNext.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub GridView3_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView3.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView3_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub BtnPDC_Click(sender As Object, e As EventArgs) Handles btnPDC.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim PDC As New FrmPDCReceipt
        With PDC
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            .CreditNumber = txtCreditNumber.Text
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnPDC_2_Click(sender As Object, e As EventArgs) Handles btnPDC_2.Click
        Try
            If GridView2.GetFocusedRowCellValue("ID").ToString = "" Or GridView2.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim PDC As New FrmPDCReceipt
        With PDC
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            .CreditNumber = txtCreditNumber.Text
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("MANDATORY"))
            If Status = "YES" Then
                e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Bold)
            End If
        End If
    End Sub

    Private Sub GridView2_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        If GridView2.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("MANDATORY"))
            If Status = "YES" Then
                e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Bold)
            End If
        End If
    End Sub
End Class