Public Class FrmDocumentNumber

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Dim FirstLoad As Boolean = True
    Private Sub FrmDocumentNumber_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        With cbxBranch
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            .DataSource = DataSource("SELECT ID, Branch FROM branch WHERE `status` = 'ACTIVE' ORDER BY BranchID;")
            .SelectedValue = Branch_ID
            If Branch_ID = 0 And MultipleBranch Then
            Else
                .Enabled = False
            End If
        End With

        FirstLoad = False
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

            GetLabelFontSettings({LabelX1})

            GetComboBoxFontSettings({cbxBranch})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint})
        Catch ex As Exception
            TriggerBugReport("Document Number - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Document Number", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = String.Format("    SELECT 'OR' AS 'Document Type', 'Official Receipt' AS 'Description', IFNULL(MIN(DocumentNumber),'') AS 'From', IFNULL(MAX(DocumentNumber),'') AS 'Current' FROM official_receipt WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'ACR' AS 'Document Type', 'Acknowledgement Receipt' AS 'Description', IFNULL(MIN(DocumentNumber),'') AS 'From', IFNULL(MAX(DocumentNumber),'') AS 'Current' FROM acknowledgement_receipt WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'CCC' AS 'Document Type', 'Collection Cash Count' AS 'Description', IFNULL(MIN(DocumentNumber),'') AS 'From', IFNULL(MAX(DocumentNumber),'') AS 'Current' FROM collection_cashcount WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'CV' AS 'Document Type', 'Check Voucher' AS 'Description', IFNULL(MIN(DocumentNumber),'') AS 'From', IFNULL(MAX(DocumentNumber),'') AS 'Current' FROM check_voucher WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'JV' AS 'Document Type', 'Journal Voucher' AS 'Description', IFNULL(MIN(DocumentNumber),'') AS 'From', IFNULL(MAX(DocumentNumber),'') AS 'Current' FROM journal_voucher WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'AP' AS 'Document Type', 'Accounts Payable' AS 'Description', IFNULL(MIN(DocumentNumber),'') AS 'From', IFNULL(MAX(DocumentNumber),'') AS 'Current' FROM accounts_payable WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'AR' AS 'Document Type', 'Accounts Receivable' AS 'Description', IFNULL(MIN(DocumentNumber),'') AS 'From', IFNULL(MAX(DocumentNumber),'') AS 'Current' FROM accounts_receivable WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'DF' AS 'Document Type', 'Due From' AS 'Description', IFNULL(MIN(DocumentNumber),'') AS 'From', IFNULL(MAX(DocumentNumber),'') AS 'Current' FROM due_from WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'DT' AS 'Document Type', 'Due To' AS 'Description', IFNULL(MIN(DocumentNumber),'') AS 'From', IFNULL(MAX(DocumentNumber),'') AS 'Current' FROM due_to WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'PDC' AS 'Document Type', 'PDC' AS 'Description', IFNULL(MIN(DocumentNumber),'') AS 'From', IFNULL(MAX(DocumentNumber),'') AS 'Current' FROM pdc_others WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'CAS' AS 'Document Type', 'Cash Advance' AS 'Description', IFNULL(MIN(AccountNumber),'') AS 'From', IFNULL(MAX(AccountNumber),'') AS 'Current' FROM cash_advance WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'PCV' AS 'Document Type', 'Petty Cash' AS 'Description', IFNULL(MIN(AccountNumber),'') AS 'From', IFNULL(MAX(AccountNumber),'') AS 'Current' FROM petty_cash WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'PCC' AS 'Document Type', 'Petty Cash Count' AS 'Description', IFNULL(MIN(DocumentNumber),'') AS 'From', IFNULL(MAX(DocumentNumber),'') AS 'Current' FROM cash_count WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'LOE' AS 'Document Type', 'Liquidation of Expenses' AS 'Description', IFNULL(MIN(AccountNumber),'') AS 'From', IFNULL(MAX(AccountNumber),'') AS 'Current' FROM liquidation_main WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'PCR' AS 'Document Type', 'Petty Cash Replenishment' AS 'Description', IFNULL(MIN(DocumentNumber),'') AS 'From', IFNULL(MAX(DocumentNumber),'') AS 'Current' FROM replenishment_cash WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'ANV' AS 'Document Type', 'Asset Number Vehicle' AS 'Description', IFNULL(MIN(AssetNumber),'') AS 'From', IFNULL(MAX(AssetNumber),'') AS 'Current' FROM ropoa_vehicle WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'ANR' AS 'Document Type', 'Asset Number Real Estate' AS 'Description', IFNULL(MIN(AssetNumber),'') AS 'From', IFNULL(MAX(AssetNumber),'') AS 'Current' FROM ropoa_realestate WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'CA' AS 'Document Type', 'Credit Application' AS 'Description', IFNULL(MIN(CreditNumber),'') AS 'From', IFNULL(MAX(CreditNumber),'') AS 'Current' FROM credit_application WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'CI' AS 'Document Type', 'Credit Investigation' AS 'Description', IFNULL(MIN(CINumber),'') AS 'From', IFNULL(MAX(CINumber),'') AS 'Current' FROM credit_investigation WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'I' AS 'Document Type', 'Individual' AS 'Description', IFNULL(MIN(BorrowerID),'') AS 'From', IFNULL(MAX(BorrowerID),'') AS 'Current' FROM profile_borrower WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'C' AS 'Document Type', 'Corporate' AS 'Description', IFNULL(MIN(BorrowerID),'') AS 'From', IFNULL(MAX(BorrowerID),'') AS 'Current' FROM profile_corporation WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'A' AS 'Document Type', 'Agent' AS 'Description', IFNULL(MIN(AgentID),'') AS 'From', IFNULL(MAX(AgentID),'') AS 'Current' FROM profile_agent WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'D' AS 'Document Type', 'Dealer' AS 'Description', IFNULL(MIN(DealerID),'') AS 'From', IFNULL(MAX(DealerID),'') AS 'Current' FROM profile_dealer WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'APV' AS 'Document Type', 'Appraise Vehicle' AS 'Description', IFNULL(MIN(Appraise_Num),'') AS 'From', IFNULL(MAX(Appraise_Num),'') AS 'Current' FROM appraise_ve WHERE Branch_ID = '{0}' UNION ALL", cbxBranch.SelectedValue)
        SQL &= String.Format("    SELECT 'APR' AS 'Document Type', 'Appraise Real Estate' AS 'Description', IFNULL(MIN(Appraise_Num),'') AS 'From', IFNULL(MAX(Appraise_Num),'') AS 'Current' FROM appraise_re WHERE Branch_ID = '{0}'", cbxBranch.SelectedValue)

        GridControl1.DataSource = DataSource(SQL)
        GridColumn2.Width = 721 - 17
        Cursor = Cursors.Default
    End Sub

    '***BUTTON CLICK
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
        StandardPrinting("DOCUMENT NUMBER LIST", GridControl1)
        Logs("Document Number", "Print", "[SENSITIVE] Print Document Number List", "", "", "", "")
        Cursor = Cursors.Default
    End Sub
    '***BUTTON CLICK

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
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
        If (cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "") Then
            MsgBox("Please select a branch.", MsgBoxStyle.Information, "Info")
            cbxBranch.DroppedDown = True
        End If

        LoadData()
    End Sub
End Class