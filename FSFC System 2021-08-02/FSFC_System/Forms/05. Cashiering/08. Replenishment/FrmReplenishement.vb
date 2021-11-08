Imports DevExpress.XtraReports.UI
Public Class FrmReplenishement

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Dim DT_Particular As DataTable
    Dim Columns As Integer = 4
    Dim Code As String

    ReadOnly Dept_Head As Boolean
    Dim User_EmplID As Integer
    Dim Code_Check As String
    Dim Code_Approve As String
    Dim Draft As Boolean
    Private Sub FrmReplenishement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList
        cbxDisplay.SelectedIndex = 0

        Dim DT_Status As DataTable = DataSource("SELECT 'For Check Voucher' AS 'Status' UNION SELECT 'Replenished' UNION SELECT 'Cancelled'")
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

        dtpDate.Value = Date.Now
        LoadParticulars()
        With cbxPreparedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With
        GetAccountNumber()
        LoadData()
        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX10, LabelX4, LabelX6, LabelX2, LabelX5, LabelX1, LabelX8, LabelX7, LabelX34, LabelX35, LabelX3, LabelX9, LabelX12, LabelX14, LabelX13, LabelX40, LabelX42, LabelX41, LabelX39})

            GetTextBoxFontSettings({txtAccountNumber, txtReferenceNumber, txtRemarks, txtApprovedBy, txtCheckedBy})

            GetCheckBoxFontSettings({cbxAll})

            GetComboBoxFontSettings({cbxPreparedBy, cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo, dtpDate})

            GetDoubleInputFontSettings({dTotalExpense, dRemainingCash, dUnliquidated, dTotal})

            GetButtonFontSettings({btnUpdateCA, btnAddCol, btnRemoveCol, btnEditCol, btnSearch, btnDraft, btnSave, btnRefresh, btnCancel, btnModify, btnDisapprove, btnDelete, btnPrint, btnAttach})

            GetContextMenuBarFontSettings({ContextMenuBar3, ContextMenuBar1})

            GetTabControlFontSettings({SuperTabControl1})

            GetCheckComboBoxFontSettings({cbxStatus})
        Catch ex As Exception
            TriggerBugReport("Replenishment - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Replenishment", lblTitle.Text)
    End Sub

    Private Sub LoadParticulars()
        Dim SQL As String = "SELECT * FROM ( SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_1) AS 'Particulars',"
        SQL &= "    Amount_1 AS 'Amount', 0.00 AS 'Amount 1', 0.00 AS 'Amount 2', 0.00 AS 'Amount 3', 0.00 AS 'Amount 4', 0.00 AS 'Amount 5', 0.00 AS 'Amount 6', 0.00 AS 'Amount 7', 0.00 AS 'Amount 8', 0.00 AS 'Amount 9', 0.00 AS 'Amount 10', 0.00 AS 'Amount 11', 0.00 AS 'Amount 12', 0.00 AS 'Amount 13', 0.00 AS 'Amount 14', 0.00 AS 'Amount 15', 0.00 AS 'Amount 16', 0.00 AS 'Amount 17', 0.00 AS 'Amount 18', 0.00 AS 'Amount 19', 0.00 AS 'Amount 20', 0.00 AS 'Amount 21', 0.00 AS 'Amount 22', 0.00 AS 'Amount 23', 0.00 AS 'Amount 24', 0.00 AS 'Amount 25', 0.00 AS 'Amount 26', 0.00 AS 'Amount 27', 0.00 AS 'Amount 28', 0.00 AS 'Amount 29', 0.00 AS 'Amount 30', 0.00 AS 'Amount 31', 0.00 AS 'Amount 32', 0.00 AS 'Amount 33', 0.00 AS 'Amount 34', 0.00 AS 'Amount 35', 0.00 AS 'Amount 36', 0.00 AS 'Amount 37', 0.00 AS 'Amount 38', 0.00 AS 'Amount 39', 0.00 AS 'Amount 40', CANumber, 1 AS 'Sort', 0 AS 'No'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_2) AS 'Particulars',"
        SQL &= "    Amount_2 AS 'Amount', 0.00 AS 'Amount 1', 0.00 AS 'Amount 2', 0.00 AS 'Amount 3', 0.00 AS 'Amount 4', 0.00 AS 'Amount 5', 0.00 AS 'Amount 6', 0.00 AS 'Amount 7', 0.00 AS 'Amount 8', 0.00 AS 'Amount 9', 0.00 AS 'Amount 10', 0.00 AS 'Amount 11', 0.00 AS 'Amount 12', 0.00 AS 'Amount 13', 0.00 AS 'Amount 14', 0.00 AS 'Amount 15', 0.00 AS 'Amount 16', 0.00 AS 'Amount 17', 0.00 AS 'Amount 18', 0.00 AS 'Amount 19', 0.00 AS 'Amount 20', 0.00 AS 'Amount 21', 0.00 AS 'Amount 22', 0.00 AS 'Amount 23', 0.00 AS 'Amount 24', 0.00 AS 'Amount 25', 0.00 AS 'Amount 26', 0.00 AS 'Amount 27', 0.00 AS 'Amount 28', 0.00 AS 'Amount 29', 0.00 AS 'Amount 30', 0.00 AS 'Amount 31', 0.00 AS 'Amount 32', 0.00 AS 'Amount 33', 0.00 AS 'Amount 34', 0.00 AS 'Amount 35', 0.00 AS 'Amount 36', 0.00 AS 'Amount 37', 0.00 AS 'Amount 38', 0.00 AS 'Amount 39', 0.00 AS 'Amount 40', CANumber, 2 AS 'Sort', 0 AS 'No'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_3) AS 'Particulars',"
        SQL &= "    Amount_3 AS 'Amount', 0.00 AS 'Amount 1', 0.00 AS 'Amount 2', 0.00 AS 'Amount 3', 0.00 AS 'Amount 4', 0.00 AS 'Amount 5', 0.00 AS 'Amount 6', 0.00 AS 'Amount 7', 0.00 AS 'Amount 8', 0.00 AS 'Amount 9', 0.00 AS 'Amount 10', 0.00 AS 'Amount 11', 0.00 AS 'Amount 12', 0.00 AS 'Amount 13', 0.00 AS 'Amount 14', 0.00 AS 'Amount 15', 0.00 AS 'Amount 16', 0.00 AS 'Amount 17', 0.00 AS 'Amount 18', 0.00 AS 'Amount 19', 0.00 AS 'Amount 20', 0.00 AS 'Amount 21', 0.00 AS 'Amount 22', 0.00 AS 'Amount 23', 0.00 AS 'Amount 24', 0.00 AS 'Amount 25', 0.00 AS 'Amount 26', 0.00 AS 'Amount 27', 0.00 AS 'Amount 28', 0.00 AS 'Amount 29', 0.00 AS 'Amount 30', 0.00 AS 'Amount 31', 0.00 AS 'Amount 32', 0.00 AS 'Amount 33', 0.00 AS 'Amount 34', 0.00 AS 'Amount 35', 0.00 AS 'Amount 36', 0.00 AS 'Amount 37', 0.00 AS 'Amount 38', 0.00 AS 'Amount 39', 0.00 AS 'Amount 40', CANumber, 3 AS 'Sort', 0 AS 'No'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_4) AS 'Particulars',"
        SQL &= "    Amount_4 AS 'Amount', 0.00 AS 'Amount 1', 0.00 AS 'Amount 2', 0.00 AS 'Amount 3', 0.00 AS 'Amount 4', 0.00 AS 'Amount 5', 0.00 AS 'Amount 6', 0.00 AS 'Amount 7', 0.00 AS 'Amount 8', 0.00 AS 'Amount 9', 0.00 AS 'Amount 10', 0.00 AS 'Amount 11', 0.00 AS 'Amount 12', 0.00 AS 'Amount 13', 0.00 AS 'Amount 14', 0.00 AS 'Amount 15', 0.00 AS 'Amount 16', 0.00 AS 'Amount 17', 0.00 AS 'Amount 18', 0.00 AS 'Amount 19', 0.00 AS 'Amount 20', 0.00 AS 'Amount 21', 0.00 AS 'Amount 22', 0.00 AS 'Amount 23', 0.00 AS 'Amount 24', 0.00 AS 'Amount 25', 0.00 AS 'Amount 26', 0.00 AS 'Amount 27', 0.00 AS 'Amount 28', 0.00 AS 'Amount 29', 0.00 AS 'Amount 30', 0.00 AS 'Amount 31', 0.00 AS 'Amount 32', 0.00 AS 'Amount 33', 0.00 AS 'Amount 34', 0.00 AS 'Amount 35', 0.00 AS 'Amount 36', 0.00 AS 'Amount 37', 0.00 AS 'Amount 38', 0.00 AS 'Amount 39', 0.00 AS 'Amount 40', CANumber, 4 AS 'Sort', 0 AS 'No'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_5) AS 'Particulars',"
        SQL &= "    Amount_5 AS 'Amount', 0.00 AS 'Amount 1', 0.00 AS 'Amount 2', 0.00 AS 'Amount 3', 0.00 AS 'Amount 4', 0.00 AS 'Amount 5', 0.00 AS 'Amount 6', 0.00 AS 'Amount 7', 0.00 AS 'Amount 8', 0.00 AS 'Amount 9', 0.00 AS 'Amount 10', 0.00 AS 'Amount 11', 0.00 AS 'Amount 12', 0.00 AS 'Amount 13', 0.00 AS 'Amount 14', 0.00 AS 'Amount 15', 0.00 AS 'Amount 16', 0.00 AS 'Amount 17', 0.00 AS 'Amount 18', 0.00 AS 'Amount 19', 0.00 AS 'Amount 20', 0.00 AS 'Amount 21', 0.00 AS 'Amount 22', 0.00 AS 'Amount 23', 0.00 AS 'Amount 24', 0.00 AS 'Amount 25', 0.00 AS 'Amount 26', 0.00 AS 'Amount 27', 0.00 AS 'Amount 28', 0.00 AS 'Amount 29', 0.00 AS 'Amount 30', 0.00 AS 'Amount 31', 0.00 AS 'Amount 32', 0.00 AS 'Amount 33', 0.00 AS 'Amount 34', 0.00 AS 'Amount 35', 0.00 AS 'Amount 36', 0.00 AS 'Amount 37', 0.00 AS 'Amount 38', 0.00 AS 'Amount 39', 0.00 AS 'Amount 40', CANumber, 5 AS 'Sort', 0 AS 'No'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_6) AS 'Particulars',"
        SQL &= "    Amount_6 AS 'Amount', 0.00 AS 'Amount 1', 0.00 AS 'Amount 2', 0.00 AS 'Amount 3', 0.00 AS 'Amount 4', 0.00 AS 'Amount 5', 0.00 AS 'Amount 6', 0.00 AS 'Amount 7', 0.00 AS 'Amount 8', 0.00 AS 'Amount 9', 0.00 AS 'Amount 10', 0.00 AS 'Amount 11', 0.00 AS 'Amount 12', 0.00 AS 'Amount 13', 0.00 AS 'Amount 14', 0.00 AS 'Amount 15', 0.00 AS 'Amount 16', 0.00 AS 'Amount 17', 0.00 AS 'Amount 18', 0.00 AS 'Amount 19', 0.00 AS 'Amount 20', 0.00 AS 'Amount 21', 0.00 AS 'Amount 22', 0.00 AS 'Amount 23', 0.00 AS 'Amount 24', 0.00 AS 'Amount 25', 0.00 AS 'Amount 26', 0.00 AS 'Amount 27', 0.00 AS 'Amount 28', 0.00 AS 'Amount 29', 0.00 AS 'Amount 30', 0.00 AS 'Amount 31', 0.00 AS 'Amount 32', 0.00 AS 'Amount 33', 0.00 AS 'Amount 34', 0.00 AS 'Amount 35', 0.00 AS 'Amount 36', 0.00 AS 'Amount 37', 0.00 AS 'Amount 38', 0.00 AS 'Amount 39', 0.00 AS 'Amount 40', CANumber, 6 AS 'Sort', 0 AS 'No'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_7) AS 'Particulars',"
        SQL &= "    Amount_7 AS 'Amount', 0.00 AS 'Amount 1', 0.00 AS 'Amount 2', 0.00 AS 'Amount 3', 0.00 AS 'Amount 4', 0.00 AS 'Amount 5', 0.00 AS 'Amount 6', 0.00 AS 'Amount 7', 0.00 AS 'Amount 8', 0.00 AS 'Amount 9', 0.00 AS 'Amount 10', 0.00 AS 'Amount 11', 0.00 AS 'Amount 12', 0.00 AS 'Amount 13', 0.00 AS 'Amount 14', 0.00 AS 'Amount 15', 0.00 AS 'Amount 16', 0.00 AS 'Amount 17', 0.00 AS 'Amount 18', 0.00 AS 'Amount 19', 0.00 AS 'Amount 20', 0.00 AS 'Amount 21', 0.00 AS 'Amount 22', 0.00 AS 'Amount 23', 0.00 AS 'Amount 24', 0.00 AS 'Amount 25', 0.00 AS 'Amount 26', 0.00 AS 'Amount 27', 0.00 AS 'Amount 28', 0.00 AS 'Amount 29', 0.00 AS 'Amount 30', 0.00 AS 'Amount 31', 0.00 AS 'Amount 32', 0.00 AS 'Amount 33', 0.00 AS 'Amount 34', 0.00 AS 'Amount 35', 0.00 AS 'Amount 36', 0.00 AS 'Amount 37', 0.00 AS 'Amount 38', 0.00 AS 'Amount 39', 0.00 AS 'Amount 40', CANumber, 7 AS 'Sort', 0 AS 'No'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_8) AS 'Particulars',"
        SQL &= "    Amount_8 AS 'Amount', 0.00 AS 'Amount 1', 0.00 AS 'Amount 2', 0.00 AS 'Amount 3', 0.00 AS 'Amount 4', 0.00 AS 'Amount 5', 0.00 AS 'Amount 6', 0.00 AS 'Amount 7', 0.00 AS 'Amount 8', 0.00 AS 'Amount 9', 0.00 AS 'Amount 10', 0.00 AS 'Amount 11', 0.00 AS 'Amount 12', 0.00 AS 'Amount 13', 0.00 AS 'Amount 14', 0.00 AS 'Amount 15', 0.00 AS 'Amount 16', 0.00 AS 'Amount 17', 0.00 AS 'Amount 18', 0.00 AS 'Amount 19', 0.00 AS 'Amount 20', 0.00 AS 'Amount 21', 0.00 AS 'Amount 22', 0.00 AS 'Amount 23', 0.00 AS 'Amount 24', 0.00 AS 'Amount 25', 0.00 AS 'Amount 26', 0.00 AS 'Amount 27', 0.00 AS 'Amount 28', 0.00 AS 'Amount 29', 0.00 AS 'Amount 30', 0.00 AS 'Amount 31', 0.00 AS 'Amount 32', 0.00 AS 'Amount 33', 0.00 AS 'Amount 34', 0.00 AS 'Amount 35', 0.00 AS 'Amount 36', 0.00 AS 'Amount 37', 0.00 AS 'Amount 38', 0.00 AS 'Amount 39', 0.00 AS 'Amount 40', CANumber, 8 AS 'Sort', 0 AS 'No'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_9) AS 'Particulars',"
        SQL &= "    Amount_9 AS 'Amount', 0.00 AS 'Amount 1', 0.00 AS 'Amount 2', 0.00 AS 'Amount 3', 0.00 AS 'Amount 4', 0.00 AS 'Amount 5', 0.00 AS 'Amount 6', 0.00 AS 'Amount 7', 0.00 AS 'Amount 8', 0.00 AS 'Amount 9', 0.00 AS 'Amount 10', 0.00 AS 'Amount 11', 0.00 AS 'Amount 12', 0.00 AS 'Amount 13', 0.00 AS 'Amount 14', 0.00 AS 'Amount 15', 0.00 AS 'Amount 16', 0.00 AS 'Amount 17', 0.00 AS 'Amount 18', 0.00 AS 'Amount 19', 0.00 AS 'Amount 20', 0.00 AS 'Amount 21', 0.00 AS 'Amount 22', 0.00 AS 'Amount 23', 0.00 AS 'Amount 24', 0.00 AS 'Amount 25', 0.00 AS 'Amount 26', 0.00 AS 'Amount 27', 0.00 AS 'Amount 28', 0.00 AS 'Amount 29', 0.00 AS 'Amount 30', 0.00 AS 'Amount 31', 0.00 AS 'Amount 32', 0.00 AS 'Amount 33', 0.00 AS 'Amount 34', 0.00 AS 'Amount 35', 0.00 AS 'Amount 36', 0.00 AS 'Amount 37', 0.00 AS 'Amount 38', 0.00 AS 'Amount 39', 0.00 AS 'Amount 40', CANumber, 9 AS 'Sort', 0 AS 'No'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_10) AS 'Particulars',"
        SQL &= "    Amount_10 AS 'Amount', 0.00 AS 'Amount 1', 0.00 AS 'Amount 2', 0.00 AS 'Amount 3', 0.00 AS 'Amount 4', 0.00 AS 'Amount 5', 0.00 AS 'Amount 6', 0.00 AS 'Amount 7', 0.00 AS 'Amount 8', 0.00 AS 'Amount 9', 0.00 AS 'Amount 10', 0.00 AS 'Amount 11', 0.00 AS 'Amount 12', 0.00 AS 'Amount 13', 0.00 AS 'Amount 14', 0.00 AS 'Amount 15', 0.00 AS 'Amount 16', 0.00 AS 'Amount 17', 0.00 AS 'Amount 18', 0.00 AS 'Amount 19', 0.00 AS 'Amount 20', 0.00 AS 'Amount 21', 0.00 AS 'Amount 22', 0.00 AS 'Amount 23', 0.00 AS 'Amount 24', 0.00 AS 'Amount 25', 0.00 AS 'Amount 26', 0.00 AS 'Amount 27', 0.00 AS 'Amount 28', 0.00 AS 'Amount 29', 0.00 AS 'Amount 30', 0.00 AS 'Amount 31', 0.00 AS 'Amount 32', 0.00 AS 'Amount 33', 0.00 AS 'Amount 34', 0.00 AS 'Amount 35', 0.00 AS 'Amount 36', 0.00 AS 'Amount 37', 0.00 AS 'Amount 38', 0.00 AS 'Amount 39', 0.00 AS 'Amount 40', CANumber, 10 AS 'Sort', 0 AS 'No'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_11) AS 'Particulars',"
        SQL &= "    Amount_11 AS 'Amount', 0.00 AS 'Amount 1', 0.00 AS 'Amount 2', 0.00 AS 'Amount 3', 0.00 AS 'Amount 4', 0.00 AS 'Amount 5', 0.00 AS 'Amount 6', 0.00 AS 'Amount 7', 0.00 AS 'Amount 8', 0.00 AS 'Amount 9', 0.00 AS 'Amount 10', 0.00 AS 'Amount 11', 0.00 AS 'Amount 12', 0.00 AS 'Amount 13', 0.00 AS 'Amount 14', 0.00 AS 'Amount 15', 0.00 AS 'Amount 16', 0.00 AS 'Amount 17', 0.00 AS 'Amount 18', 0.00 AS 'Amount 19', 0.00 AS 'Amount 20', 0.00 AS 'Amount 21', 0.00 AS 'Amount 22', 0.00 AS 'Amount 23', 0.00 AS 'Amount 24', 0.00 AS 'Amount 25', 0.00 AS 'Amount 26', 0.00 AS 'Amount 27', 0.00 AS 'Amount 28', 0.00 AS 'Amount 29', 0.00 AS 'Amount 30', 0.00 AS 'Amount 31', 0.00 AS 'Amount 32', 0.00 AS 'Amount 33', 0.00 AS 'Amount 34', 0.00 AS 'Amount 35', 0.00 AS 'Amount 36', 0.00 AS 'Amount 37', 0.00 AS 'Amount 38', 0.00 AS 'Amount 39', 0.00 AS 'Amount 40', CANumber, 11 AS 'Sort', 0 AS 'No'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_12) AS 'Particulars',"
        SQL &= "    Amount_12 AS 'Amount', 0.00 AS 'Amount 1', 0.00 AS 'Amount 2', 0.00 AS 'Amount 3', 0.00 AS 'Amount 4', 0.00 AS 'Amount 5', 0.00 AS 'Amount 6', 0.00 AS 'Amount 7', 0.00 AS 'Amount 8', 0.00 AS 'Amount 9', 0.00 AS 'Amount 10', 0.00 AS 'Amount 11', 0.00 AS 'Amount 12', 0.00 AS 'Amount 13', 0.00 AS 'Amount 14', 0.00 AS 'Amount 15', 0.00 AS 'Amount 16', 0.00 AS 'Amount 17', 0.00 AS 'Amount 18', 0.00 AS 'Amount 19', 0.00 AS 'Amount 20', 0.00 AS 'Amount 21', 0.00 AS 'Amount 22', 0.00 AS 'Amount 23', 0.00 AS 'Amount 24', 0.00 AS 'Amount 25', 0.00 AS 'Amount 26', 0.00 AS 'Amount 27', 0.00 AS 'Amount 28', 0.00 AS 'Amount 29', 0.00 AS 'Amount 30', 0.00 AS 'Amount 31', 0.00 AS 'Amount 32', 0.00 AS 'Amount 33', 0.00 AS 'Amount 34', 0.00 AS 'Amount 35', 0.00 AS 'Amount 36', 0.00 AS 'Amount 37', 0.00 AS 'Amount 38', 0.00 AS 'Amount 39', 0.00 AS 'Amount 40', CANumber, 12 AS 'Sort', 0 AS 'No'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}') A WHERE Amount > 0 ORDER BY `Document Number`, `Sort`", Branch_ID)

        dUnliquidated.Value = DataObject(String.Format("SELECT IFNULL(SUM((Meals + Transportation + BIR + RD + LTO + Notarization + Others)),0) FROM cash_advance WHERE `status` = 'ACTIVE' AND slip_status IN ('RECEIVED') AND ReplenishedID = 0 AND Branch_ID = '{0}' AND (Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= 1000 AND Liquidated = 'N';", Branch_ID))

        DT_Particular = DataSource(SQL)
        GridControl2.DataSource = DT_Particular
        Dim TotalEx As Double
        Dim Total_1 As Double
        Dim Total_2 As Double
        Dim Total_3 As Double
        Dim Total_4 As Double
        Dim Total_5 As Double
        Dim Total_6 As Double
        Dim Total_7 As Double
        Dim Total_8 As Double
        Dim Total_9 As Double
        Dim Total_10 As Double
        Dim Total_11 As Double
        Dim Total_12 As Double
        Dim Total_13 As Double
        Dim Total_14 As Double
        Dim Total_15 As Double
        Dim Total_16 As Double
        Dim Total_17 As Double
        Dim Total_18 As Double
        Dim Total_19 As Double
        Dim Total_20 As Double

        Dim Total_21 As Double
        Dim Total_22 As Double
        Dim Total_23 As Double
        Dim Total_24 As Double
        Dim Total_25 As Double
        Dim Total_26 As Double
        Dim Total_27 As Double
        Dim Total_28 As Double
        Dim Total_29 As Double
        Dim Total_30 As Double
        Dim Total_31 As Double
        Dim Total_32 As Double
        Dim Total_33 As Double
        Dim Total_34 As Double
        Dim Total_35 As Double
        Dim Total_36 As Double
        Dim Total_37 As Double
        Dim Total_38 As Double
        Dim Total_39 As Double
        Dim Total_40 As Double
        Dim DT_JVNumbers As DataTable
        Dim DT_Payables As DataTable

        GridColumn21.Caption = " "
        GridColumn22.Caption = " "
        GridColumn23.Caption = " "
        GridColumn24.Caption = " "
        GridColumn25.Caption = " "
        GridColumn26.Caption = " "
        GridColumn27.Caption = " "
        GridColumn28.Caption = " "
        GridColumn29.Caption = " "
        GridColumn41.Caption = " "
        GridColumn31.Caption = " "
        GridColumn32.Caption = " "
        GridColumn33.Caption = " "
        GridColumn34.Caption = " "
        GridColumn35.Caption = " "
        GridColumn36.Caption = " "
        GridColumn37.Caption = " "
        GridColumn38.Caption = " "
        GridColumn39.Caption = " "
        GridColumn40.Caption = " "

        GridColumn15.Caption = " "
        GridColumn42.Caption = " "
        GridColumn43.Caption = " "
        GridColumn44.Caption = " "
        GridColumn45.Caption = " "
        GridColumn46.Caption = " "
        GridColumn47.Caption = " "
        GridColumn48.Caption = " "
        GridColumn49.Caption = " "
        GridColumn50.Caption = " "
        GridColumn51.Caption = " "
        GridColumn52.Caption = " "
        GridColumn53.Caption = " "
        GridColumn54.Caption = " "
        GridColumn55.Caption = " "
        GridColumn56.Caption = " "
        GridColumn57.Caption = " "
        GridColumn58.Caption = " "
        GridColumn59.Caption = " "
        GridColumn60.Caption = " "
        For x As Integer = 0 To GridView2.RowCount - 1
            DT_Particular(x)("No") = x + 1
            TotalEx += CDbl(GridView2.GetRowCellValue(x, "Amount"))
            Total_1 += CDbl(DT_Particular(x)("Amount 1"))
            Total_2 += CDbl(DT_Particular(x)("Amount 2"))
            Total_3 += CDbl(DT_Particular(x)("Amount 3"))
            Total_4 += CDbl(DT_Particular(x)("Amount 4"))
            Total_5 += CDbl(DT_Particular(x)("Amount 5"))
            Total_6 += CDbl(DT_Particular(x)("Amount 6"))
            Total_7 += CDbl(DT_Particular(x)("Amount 7"))
            Total_8 += CDbl(DT_Particular(x)("Amount 8"))
            Total_9 += CDbl(DT_Particular(x)("Amount 9"))
            Total_10 += CDbl(DT_Particular(x)("Amount 10"))
            Total_11 += CDbl(DT_Particular(x)("Amount 11"))
            Total_12 += CDbl(DT_Particular(x)("Amount 12"))
            Total_13 += CDbl(DT_Particular(x)("Amount 13"))
            Total_14 += CDbl(DT_Particular(x)("Amount 14"))
            Total_15 += CDbl(DT_Particular(x)("Amount 15"))
            Total_16 += CDbl(DT_Particular(x)("Amount 16"))
            Total_17 += CDbl(DT_Particular(x)("Amount 17"))
            Total_18 += CDbl(DT_Particular(x)("Amount 18"))
            Total_19 += CDbl(DT_Particular(x)("Amount 19"))
            Total_20 += CDbl(DT_Particular(x)("Amount 20"))

            Total_21 += CDbl(DT_Particular(x)("Amount 21"))
            Total_22 += CDbl(DT_Particular(x)("Amount 22"))
            Total_23 += CDbl(DT_Particular(x)("Amount 23"))
            Total_24 += CDbl(DT_Particular(x)("Amount 24"))
            Total_25 += CDbl(DT_Particular(x)("Amount 25"))
            Total_26 += CDbl(DT_Particular(x)("Amount 26"))
            Total_27 += CDbl(DT_Particular(x)("Amount 27"))
            Total_28 += CDbl(DT_Particular(x)("Amount 28"))
            Total_29 += CDbl(DT_Particular(x)("Amount 29"))
            Total_30 += CDbl(DT_Particular(x)("Amount 30"))
            Total_31 += CDbl(DT_Particular(x)("Amount 31"))
            Total_32 += CDbl(DT_Particular(x)("Amount 32"))
            Total_33 += CDbl(DT_Particular(x)("Amount 33"))
            Total_34 += CDbl(DT_Particular(x)("Amount 34"))
            Total_35 += CDbl(DT_Particular(x)("Amount 35"))
            Total_36 += CDbl(DT_Particular(x)("Amount 36"))
            Total_37 += CDbl(DT_Particular(x)("Amount 37"))
            Total_38 += CDbl(DT_Particular(x)("Amount 38"))
            Total_39 += CDbl(DT_Particular(x)("Amount 39"))
            Total_40 += CDbl(DT_Particular(x)("Amount 40"))
            If GridView2.GetRowCellValue(x, "CANumber") = "" Then
            Else
                DT_JVNumbers = DataSource(String.Format("SELECT DocumentNumber FROM journal_voucher WHERE `status` = 'ACTIVE' AND voucher_status = 'APPROVED' AND Payee LIKE '%{0}%';", GridView2.GetRowCellValue(x, "CANumber")))
                For y As Integer = 0 To DT_JVNumbers.Rows.Count - 1
                    DT_Payables = DataSource(String.Format("SELECT AccountTitle(AccountCode) AS 'Title', AccountCode, SUM(Credit) AS 'Amount' FROM jv_details WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE' AND MotherCode = '218000' GROUP BY AccountCode;", DT_JVNumbers(y)("DocumentNumber")))
                    For z As Integer = 0 To DT_Payables.Rows.Count - 1
                        If GridView2.GetRowCellValue(x, "Amount 1") = 0 And (GridColumn21.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 1", CDbl(GridView2.GetRowCellValue(x, "Amount 1")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn21.Caption = DT_Payables(z)("Title")
                            GridColumn21.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 2") = 0 And (GridColumn22.Caption = " " Or GridColumn22.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 2", CDbl(GridView2.GetRowCellValue(x, "Amount 2")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn22.Caption = DT_Payables(z)("Title")
                            GridColumn22.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 3") = 0 And (GridColumn23.Caption = " " Or GridColumn23.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 3", CDbl(GridView2.GetRowCellValue(x, "Amount 3")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn23.Caption = DT_Payables(z)("Title")
                            GridColumn23.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 4") = 0 And (GridColumn24.Caption = " " Or GridColumn24.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 4", CDbl(GridView2.GetRowCellValue(x, "Amount 4")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn24.Caption = DT_Payables(z)("Title")
                            GridColumn24.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 5") = 0 And (GridColumn25.Caption = " " Or GridColumn25.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 5", CDbl(GridView2.GetRowCellValue(x, "Amount 5")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn25.Caption = DT_Payables(z)("Title")
                            GridColumn25.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 6") = 0 And (GridColumn26.Caption = " " Or GridColumn26.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 6", CDbl(GridView2.GetRowCellValue(x, "Amount 6")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn26.Caption = DT_Payables(z)("Title")
                            GridColumn26.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 7") = 0 And (GridColumn27.Caption = " " Or GridColumn27.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 7", CDbl(GridView2.GetRowCellValue(x, "Amount 7")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn27.Caption = DT_Payables(z)("Title")
                            GridColumn27.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 8") = 0 And (GridColumn28.Caption = " " Or GridColumn28.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 8", CDbl(GridView2.GetRowCellValue(x, "Amount 8")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn28.Caption = DT_Payables(z)("Title")
                            GridColumn28.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 9") = 0 And (GridColumn29.Caption = " " Or GridColumn29.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 9", CDbl(GridView2.GetRowCellValue(x, "Amount 9")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn29.Caption = DT_Payables(z)("Title")
                            GridColumn29.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 10") = 0 And (GridColumn31.Caption = " " Or GridColumn31.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 10", CDbl(GridView2.GetRowCellValue(x, "Amount 10")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn31.Caption = DT_Payables(z)("Title")
                            GridColumn31.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 11") = 0 And (GridColumn41.Caption = " " Or GridColumn41.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 11", CDbl(GridView2.GetRowCellValue(x, "Amount 11")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn41.Caption = DT_Payables(z)("Title")
                            GridColumn41.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 12") = 0 And (GridColumn32.Caption = " " Or GridColumn32.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 12", CDbl(GridView2.GetRowCellValue(x, "Amount 12")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn32.Caption = DT_Payables(z)("Title")
                            GridColumn32.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 13") = 0 And (GridColumn33.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 13", CDbl(GridView2.GetRowCellValue(x, "Amount 13")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn33.Caption = DT_Payables(z)("Title")
                            GridColumn33.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 14") = 0 And (GridColumn34.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 14", CDbl(GridView2.GetRowCellValue(x, "Amount 14")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn34.Caption = DT_Payables(z)("Title")
                            GridColumn34.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 15") = 0 And (GridColumn35.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 15", CDbl(GridView2.GetRowCellValue(x, "Amount 15")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn35.Caption = DT_Payables(z)("Title")
                            GridColumn35.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 16") = 0 And (GridColumn36.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 16", CDbl(GridView2.GetRowCellValue(x, "Amount 16")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn36.Caption = DT_Payables(z)("Title")
                            GridColumn36.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 17") = 0 And (GridColumn37.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 17", CDbl(GridView2.GetRowCellValue(x, "Amount 17")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn37.Caption = DT_Payables(z)("Title")
                            GridColumn37.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 18") = 0 And (GridColumn38.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 18", CDbl(GridView2.GetRowCellValue(x, "Amount 18")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn38.Caption = DT_Payables(z)("Title")
                            GridColumn38.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 19") = 0 And (GridColumn39.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 19", CDbl(GridView2.GetRowCellValue(x, "Amount 19")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn39.Caption = DT_Payables(z)("Title")
                            GridColumn39.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 20") = 0 And (GridColumn40.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 20", CDbl(GridView2.GetRowCellValue(x, "Amount 20")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn40.Caption = DT_Payables(z)("Title")
                            GridColumn40.Tag = DT_Payables(z)("AccountCode")

                        ElseIf GridView2.GetRowCellValue(x, "Amount 21") = 0 And (GridColumn15.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 21", CDbl(GridView2.GetRowCellValue(x, "Amount 21")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn15.Caption = DT_Payables(z)("Title")
                            GridColumn15.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 22") = 0 And (GridColumn42.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 22", CDbl(GridView2.GetRowCellValue(x, "Amount 22")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn42.Caption = DT_Payables(z)("Title")
                            GridColumn42.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 23") = 0 And (GridColumn43.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 23", CDbl(GridView2.GetRowCellValue(x, "Amount 23")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn43.Caption = DT_Payables(z)("Title")
                            GridColumn43.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 24") = 0 And (GridColumn44.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 24", CDbl(GridView2.GetRowCellValue(x, "Amount 24")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn44.Caption = DT_Payables(z)("Title")
                            GridColumn44.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 25") = 0 And (GridColumn45.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 25", CDbl(GridView2.GetRowCellValue(x, "Amount 25")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn45.Caption = DT_Payables(z)("Title")
                            GridColumn45.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 26") = 0 And (GridColumn46.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 26", CDbl(GridView2.GetRowCellValue(x, "Amount 26")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn46.Caption = DT_Payables(z)("Title")
                            GridColumn46.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 27") = 0 And (GridColumn47.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 27", CDbl(GridView2.GetRowCellValue(x, "Amount 27")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn47.Caption = DT_Payables(z)("Title")
                            GridColumn47.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 28") = 0 And (GridColumn48.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 28", CDbl(GridView2.GetRowCellValue(x, "Amount 28")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn48.Caption = DT_Payables(z)("Title")
                            GridColumn48.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 29") = 0 And (GridColumn49.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 29", CDbl(GridView2.GetRowCellValue(x, "Amount 29")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn49.Caption = DT_Payables(z)("Title")
                            GridColumn49.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 30") = 0 And (GridColumn50.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 30", CDbl(GridView2.GetRowCellValue(x, "Amount 30")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn50.Caption = DT_Payables(z)("Title")
                            GridColumn50.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 31") = 0 And (GridColumn51.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 31", CDbl(GridView2.GetRowCellValue(x, "Amount 31")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn51.Caption = DT_Payables(z)("Title")
                            GridColumn51.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 32") = 0 And (GridColumn52.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 32", CDbl(GridView2.GetRowCellValue(x, "Amount 32")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn52.Caption = DT_Payables(z)("Title")
                            GridColumn52.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 33") = 0 And (GridColumn53.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 33", CDbl(GridView2.GetRowCellValue(x, "Amount 33")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn53.Caption = DT_Payables(z)("Title")
                            GridColumn53.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 34") = 0 And (GridColumn54.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 34", CDbl(GridView2.GetRowCellValue(x, "Amount 34")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn54.Caption = DT_Payables(z)("Title")
                            GridColumn54.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 35") = 0 And (GridColumn55.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 35", CDbl(GridView2.GetRowCellValue(x, "Amount 35")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn55.Caption = DT_Payables(z)("Title")
                            GridColumn55.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 36") = 0 And (GridColumn56.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 36", CDbl(GridView2.GetRowCellValue(x, "Amount 36")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn56.Caption = DT_Payables(z)("Title")
                            GridColumn56.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 37") = 0 And (GridColumn57.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 37", CDbl(GridView2.GetRowCellValue(x, "Amount 37")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn57.Caption = DT_Payables(z)("Title")
                            GridColumn57.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 38") = 0 And (GridColumn58.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 38", CDbl(GridView2.GetRowCellValue(x, "Amount 38")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn58.Caption = DT_Payables(z)("Title")
                            GridColumn58.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 39") = 0 And (GridColumn59.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 39", CDbl(GridView2.GetRowCellValue(x, "Amount 39")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn59.Caption = DT_Payables(z)("Title")
                            GridColumn59.Tag = DT_Payables(z)("AccountCode")
                        ElseIf GridView2.GetRowCellValue(x, "Amount 40") = 0 And (GridColumn60.Caption = " " Or GridColumn21.Caption = DT_Payables(z)("Title")) Then
                            GridView2.SetRowCellValue(x, "Amount 40", CDbl(GridView2.GetRowCellValue(x, "Amount 40")) + CDbl(DT_Payables(z)("Amount")))
                            GridColumn60.Caption = DT_Payables(z)("Title")
                            GridColumn60.Tag = DT_Payables(z)("AccountCode")
                        End If
                    Next
                Next
            End If
        Next
        DT_Particular.Rows.Add(0, "", "T O T A L", "", TotalEx, Total_1, Total_2, Total_3, Total_4, Total_5, Total_6, Total_7, Total_8, Total_9, Total_10, Total_11, Total_12, Total_13, Total_14, Total_15, Total_16, Total_17, Total_18, Total_19, Total_20, Total_21, Total_22, Total_23, Total_24, Total_25, Total_26, Total_27, Total_28, Total_29, Total_30, Total_31, Total_32, Total_33, Total_34, Total_35, Total_36, Total_37, Total_38, Total_39, Total_40)
        dTotalExpense.Value = TotalEx
        If GridColumn25.Caption = " " Then
            GridColumn25.Visible = False
        End If
        If GridColumn26.Caption = " " Then
            GridColumn26.Visible = False
        End If
        If GridColumn27.Caption = " " Then
            GridColumn27.Visible = False
        End If
        If GridColumn28.Caption = " " Then
            GridColumn28.Visible = False
        End If
        If GridColumn29.Caption = " " Then
            GridColumn29.Visible = False
        End If
        If GridColumn41.Caption = " " Then
            GridColumn41.Visible = False
        End If
        If GridColumn31.Caption = " " Then
            GridColumn31.Visible = False
        End If
        If GridColumn32.Caption = " " Then
            GridColumn32.Visible = False
        End If
        If GridColumn33.Caption = " " Then
            GridColumn33.Visible = False
        End If
        If GridColumn34.Caption = " " Then
            GridColumn34.Visible = False
        End If
        If GridColumn35.Caption = " " Then
            GridColumn35.Visible = False
        End If
        If GridColumn36.Caption = " " Then
            GridColumn36.Visible = False
        End If
        If GridColumn37.Caption = " " Then
            GridColumn37.Visible = False
        End If
        If GridColumn38.Caption = " " Then
            GridColumn38.Visible = False
        End If
        If GridColumn39.Caption = " " Then
            GridColumn39.Visible = False
        End If
        If GridColumn40.Caption = " " Then
            GridColumn40.Visible = False
        End If
        If GridColumn15.Caption = " " Then
            GridColumn15.Visible = False
        End If
        If GridColumn41.Caption = " " Then
            GridColumn41.Visible = False
        End If
        If GridColumn42.Caption = " " Then
            GridColumn42.Visible = False
        End If
        If GridColumn43.Caption = " " Then
            GridColumn43.Visible = False
        End If
        If GridColumn44.Caption = " " Then
            GridColumn44.Visible = False
        End If
        If GridColumn45.Caption = " " Then
            GridColumn45.Visible = False
        End If
        If GridColumn46.Caption = " " Then
            GridColumn46.Visible = False
        End If
        If GridColumn47.Caption = " " Then
            GridColumn47.Visible = False
        End If
        If GridColumn48.Caption = " " Then
            GridColumn48.Visible = False
        End If
        If GridColumn49.Caption = " " Then
            GridColumn49.Visible = False
        End If
        If GridColumn50.Caption = " " Then
            GridColumn50.Visible = False
        End If
        If GridColumn51.Caption = " " Then
            GridColumn51.Visible = False
        End If
        If GridColumn52.Caption = " " Then
            GridColumn52.Visible = False
        End If
        If GridColumn53.Caption = " " Then
            GridColumn53.Visible = False
        End If
        If GridColumn54.Caption = " " Then
            GridColumn54.Visible = False
        End If
        If GridColumn55.Caption = " " Then
            GridColumn55.Visible = False
        End If
        If GridColumn56.Caption = " " Then
            GridColumn56.Visible = False
        End If
        If GridColumn57.Caption = " " Then
            GridColumn57.Visible = False
        End If
        If GridColumn58.Caption = " " Then
            GridColumn58.Visible = False
        End If
        If GridColumn59.Caption = " " Then
            GridColumn59.Visible = False
        End If
        If GridColumn60.Caption = " " Then
            GridColumn60.Visible = False
        End If

        If GridView2.RowCount > 15 Then
            GridColumn19.Width = 412 - 17
        Else
            GridColumn19.Width = 412
        End If
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(DocumentDate,'%b %d, %Y') AS 'Document Date',"
        SQL &= "    DocumentNumber AS 'Document Number',"
        SQL &= "    ReferenceNumber AS 'Reference No',"
        SQL &= "    TotalExpenses AS 'Total Expenses',"
        SQL &= "    RemainingCash AS 'Remaining Cash',"
        SQL &= "    Unliquidated AS 'CA Unliquidated',"
        SQL &= "    Remarks AS 'Remarks',"
        SQL &= "    Employee(PreparedID) AS 'Prepared By', PreparedID, Employee(CheckedID) AS 'Checked By', Employee(ApprovedID) AS 'Approved By', ApprovedID, "
        SQL &= "    BRANCH(branch_id) AS 'Branch', Branch_ID, Cols, Caption1, Caption2, Caption3, Caption4, Caption5, Caption6, Caption7, Caption8, Caption9, Caption10, Caption11, Caption12, Caption13, Caption14, Caption15, Caption16, Caption17, Caption18, Caption19, Caption20, Caption21, Caption22, Caption23, Caption24, Caption25, Caption26, Caption27, Caption28, Caption29, Caption30, Caption31, Caption32, Caption33, Caption34, Caption35, Caption36, Caption37, Caption38, Caption39, Caption40, Caption1Tag, Caption2Tag, Caption3Tag, Caption4Tag, Caption5Tag, Caption6Tag, Caption7Tag, Caption8Tag, Caption9Tag, Caption10Tag, Caption11Tag, Caption12Tag, Caption13Tag, Caption14Tag, Caption15Tag, Caption16Tag, Caption17Tag, Caption18Tag, Caption19Tag, Caption20Tag, Caption21Tag, Caption22Tag, Caption23Tag, Caption24Tag, Caption25Tag, Caption26Tag, Caption27Tag, Caption28Tag, Caption29Tag, Caption30Tag, Caption31Tag, Caption32Tag, Caption33Tag, Caption34Tag, Caption35Tag, Caption36Tag, Caption37Tag, Caption38Tag, Caption39Tag, Caption40Tag, AccountTitle(MotherCode(Caption1Tag)) AS 'Caption1M', AccountTitle(MotherCode(Caption2Tag)) AS 'Caption2M', AccountTitle(MotherCode(Caption3Tag)) AS 'Caption3M', AccountTitle(MotherCode(Caption4Tag)) AS 'Caption4M', AccountTitle(MotherCode(Caption5Tag)) AS 'Caption5M', AccountTitle(MotherCode(Caption6Tag)) AS 'Caption6M', AccountTitle(MotherCode(Caption7Tag)) AS 'Caption7M', AccountTitle(MotherCode(Caption8Tag)) AS 'Caption8M', AccountTitle(MotherCode(Caption9Tag)) AS 'Caption9M', AccountTitle(MotherCode(Caption10Tag)) AS 'Caption10M', AccountTitle(MotherCode(Caption11Tag)) AS 'Caption11M', AccountTitle(MotherCode(Caption12Tag)) AS 'Caption12M', AccountTitle(MotherCode(Caption13Tag)) AS 'Caption13M', AccountTitle(MotherCode(Caption14Tag)) AS 'Caption14M', AccountTitle(MotherCode(Caption15Tag)) AS 'Caption15M', AccountTitle(MotherCode(Caption16Tag)) AS 'Caption16M', AccountTitle(MotherCode(Caption17Tag)) AS 'Caption17M', AccountTitle(MotherCode(Caption18Tag)) AS 'Caption18M', AccountTitle(MotherCode(Caption19Tag)) AS 'Caption19M', AccountTitle(MotherCode(Caption20Tag)) AS 'Caption20M', AccountTitle(MotherCode(Caption21Tag)) AS 'Caption21M', AccountTitle(MotherCode(Caption22Tag)) AS 'Caption22M', AccountTitle(MotherCode(Caption23Tag)) AS 'Caption23M', AccountTitle(MotherCode(Caption24Tag)) AS 'Caption24M', AccountTitle(MotherCode(Caption25Tag)) AS 'Caption25M', AccountTitle(MotherCode(Caption26Tag)) AS 'Caption26M', AccountTitle(MotherCode(Caption27Tag)) AS 'Caption27M', AccountTitle(MotherCode(Caption28Tag)) AS 'Caption28M', AccountTitle(MotherCode(Caption29Tag)) AS 'Caption29M', AccountTitle(MotherCode(Caption30Tag)) AS 'Caption30M', AccountTitle(MotherCode(Caption31Tag)) AS 'Caption31M', AccountTitle(MotherCode(Caption32Tag)) AS 'Caption32M', AccountTitle(MotherCode(Caption33Tag)) AS 'Caption33M', AccountTitle(MotherCode(Caption34Tag)) AS 'Caption34M', AccountTitle(MotherCode(Caption35Tag)) AS 'Caption35M', AccountTitle(MotherCode(Caption36Tag)) AS 'Caption36M', AccountTitle(MotherCode(Caption37Tag)) AS 'Caption37M', AccountTitle(MotherCode(Caption38Tag)) AS 'Caption38M', AccountTitle(MotherCode(Caption39Tag)) AS 'Caption39M', AccountTitle(MotherCode(Caption40Tag)) AS 'Caption40M', Check_OTAC, Approve_OTAC, ReplenishStatus, User_EmplID, Attach, IF(`Status` IN ('CANCELLED','DELETED','DISAPPROVED','DRAFT'),`status`,IF(ReplenishStatus = 'PENDING','FOR CHECK VOUCHER',ReplenishStatus)) AS 'Voucher_Status'"
        SQL &= "  FROM replenishment_cash WHERE"
        Dim ForCV As Boolean
        Dim Replenished As Boolean
        Dim Cancelled As Boolean
        For x As Integer = 0 To cbxStatus.Properties.Items.Count - 1
            If cbxStatus.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Check Voucher" Then
                    ForCV = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Replenished" Then
                    Replenished = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Cancelled" Then
                    Cancelled = True
                End If
            End If
        Next
        If Cancelled Then
            If ForCV = False And Replenished = False Then
                SQL &= " (`status` IN ('CANCELLED','DELETED','DISAPPROVED') OR ReplenishStatus = 'DISAPPROVED')"
            Else
                SQL &= " `status` IN ('DRAFT','ACTIVE','CANCELLED','DELETED','DISAPPROVED') AND (ReplenishStatus = 'DISAPPROVED' "
                If ForCV Or Replenished Then
                    SQL &= " OR "
                End If
                If ForCV Then
                    SQL &= " IF(`status` IN ('DRAFT','ACTIVE'),ReplenishStatus = 'PENDING',TRUE)"
                    If Replenished Then
                        SQL &= " OR "
                    End If
                End If
                If Replenished Then
                    SQL &= " IF(`status` IN ('DRAFT','ACTIVE'),ReplenishStatus = 'REPLENISHED',TRUE)"
                End If
                SQL &= ")"
            End If
        Else
            SQL &= " `status` IN ('DRAFT','ACTIVE')"
            If ForCV = False And Replenished = False Then
            Else
                SQL &= " AND ("
                If ForCV Then
                    SQL &= " ReplenishStatus = 'PENDING'"
                    If Replenished Then
                        SQL &= " OR "
                    End If
                End If
                If Replenished Then
                    SQL &= " ReplenishStatus = 'REPLENISHED'"
                End If
                SQL &= ")"
            End If
        End If
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(DocumentDate) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        SQL &= String.Format("  AND Branch_ID IN ({0}) ORDER BY DocumentNumber DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        GridControl1.DataSource = DataSource(SQL)
        If Multiple_ID.Contains(",") Then
            GridColumn11.Visible = True
            GridColumn11.VisibleIndex = 8
        End If
        GridView1.Columns("Remarks").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Remarks").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 19 Then
            GridColumn8.Width = 376 - 17
        Else
            GridColumn8.Width = 376
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GetAccountNumber()
        If btnSave.Text = "&Save" Then
            txtAccountNumber.Text = DataObject(String.Format("SELECT CONCAT('PCR-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM replenishment_cash WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDate.Value, "yy"), Format(dtpDate.Value, "yyyy-MM-dd")))
        End If
    End Sub

    Private Sub DtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        GetAccountNumber()
    End Sub

#Region "Keydown"
    Private Sub DtpDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtReferenceNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferenceNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
#End Region

#Region "Leave"
    Private Sub TxtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        txtRemarks.Text = ReplaceText(txtRemarks.Text)
    End Sub
#End Region

    '***BUTTON CLICK
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
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
            SuperTabControl1.SelectedTab = tabSetup
        End If
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Then
            btnBack.Enabled = False
            btnAdd.Enabled = False
            btnDraft.Visible = True
            btnSave.Enabled = True
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = True
            btnAttach.Visible = False
            If btnSave.Text = "&Save" And btnSave.Enabled Then
                btnPrint.Enabled = False
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Clear(False)
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnDraft.Visible = False
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = False
            btnAttach.Visible = True
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
        btnUpdateCA.Visible = False
        Draft = False
        btnSave.Text = "&Save"
        btnDraft.Text = "Draft"
        PanelEx10.Enabled = True
        dtpDate.Value = Date.Now
        dtpDate.Enabled = True
        cbxPreparedBy.SelectedValue = Empl_ID
        txtApprovedBy.Text = ""
        txtCheckedBy.Text = ""
        txtRemarks.Text = ""
        txtReferenceNumber.Text = ""
        dTotalExpense.Value = 0
        dRemainingCash.Value = 0
        btnAddCol.Enabled = True
        btnRemoveCol.Enabled = False

        LoadParticulars()

        Columns = 4
        User_EmplID = 0

        btnDraft.Visible = True
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        btnCheck.Visible = False
        btnApprove.Visible = False
        btnDisapprove.Visible = False
        If TriggerLoadData Then
            LoadData()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Multiple_ID.Contains(",") Then
            MsgBox("Saving transaction is not allowed because multi branch are selected.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If dtpDate.CustomFormat = "" Or Format(dtpDate.Value, "yyyy-MM-dd") = "0001-01-01" Then
            MsgBox("Please fill Document Date.", MsgBoxStyle.Information, "Info")
            dtpDate.Focus()
            Exit Sub
        End If
        If GridView2.RowCount = 0 Or dTotalExpense.Value = 0 Then
            MsgBox("Please add some petty cash or cash advance for replenishment.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If cbxPreparedBy.SelectedIndex = -1 Or cbxPreparedBy.Text = "" Then
            MsgBox("Please select prepared by.", MsgBoxStyle.Information, "Info")
            cbxPreparedBy.DroppedDown = True
            Exit Sub
        End If
        If Draft Then
            If btnSave.Text = "&Save" And btnDraft.Text = "Draft" Then
                If MsgBoxYes("Are you sure you want to save this replenishment as a draft?") = MsgBoxResult.Yes Then
                    GoTo Here
                End If
            Else
                If MsgBoxYes("Are you sure you want to update this draft replenishment?") = MsgBoxResult.Yes Then
                    GoTo HereV2
                End If
            End If
            Exit Sub
        End If
        For x As Integer = 0 To GridView2.RowCount - 1
            If FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount")), 2) = FormatNumber(CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 1")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 2")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 3")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 4")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 5")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 6")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 7")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 8")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 9")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 10")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 11")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 12")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 13")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 14")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 15")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 16")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 17")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 18")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 19")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 20")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 21")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 22")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 23")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 24")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 25")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 26")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 27")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 28")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 29")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 30")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 31")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 32")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 33")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 34")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 35")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 36")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 37")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 38")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 39")), 2)) + CDbl(FormatNumber(CDbl(GridView2.GetRowCellValue(x, "Amount 40")), 2)), 2) Then
            Else
                MsgBox("Please check your data under row " & x + 1, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Next
        For x As Integer = 1 To 40
            If CDec(GridView2.GetRowCellValue(GridView2.RowCount - 1, "Amount " & x)) > 0 And GridView2.Columns.ColumnByFieldName("Amount " & x).Tag = "" Then
                MsgBox("Please fill accounts for column " & x, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Next

        If btnSave.Text = "&Save" And btnDraft.Text = "Draft" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
Here:
                Cursor = Cursors.WaitCursor
                Code = GenerateOTAC()
                Code_Check = Code
                GetAccountNumber()

                'INSERT MAIN
                Dim SQL As String = "INSERT INTO replenishment_cash SET"
                SQL &= String.Format(" DocumentDate = '{0}', ", FormatDatePicker(dtpDate))
                SQL &= String.Format(" DocumentNumber = '{0}', ", txtAccountNumber.Text)
                SQL &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text.InsertQuote)
                SQL &= String.Format(" Cols = '{0}', ", Columns)
                SQL &= String.Format(" Caption1 = '{0}', ", GridColumn21.Caption)
                SQL &= String.Format(" Caption2 = '{0}', ", GridColumn22.Caption)
                SQL &= String.Format(" Caption3 = '{0}', ", GridColumn23.Caption)
                SQL &= String.Format(" Caption4 = '{0}', ", GridColumn24.Caption)
                SQL &= String.Format(" Caption5 = '{0}', ", GridColumn25.Caption)
                SQL &= String.Format(" Caption6 = '{0}', ", GridColumn26.Caption)
                SQL &= String.Format(" Caption7 = '{0}', ", GridColumn27.Caption)
                SQL &= String.Format(" Caption8 = '{0}', ", GridColumn28.Caption)
                SQL &= String.Format(" Caption9 = '{0}', ", GridColumn29.Caption)
                SQL &= String.Format(" Caption10 = '{0}', ", GridColumn31.Caption)
                SQL &= String.Format(" Caption11 = '{0}', ", GridColumn41.Caption)
                SQL &= String.Format(" Caption12 = '{0}', ", GridColumn32.Caption)
                SQL &= String.Format(" Caption13 = '{0}', ", GridColumn33.Caption)
                SQL &= String.Format(" Caption14 = '{0}', ", GridColumn34.Caption)
                SQL &= String.Format(" Caption15 = '{0}', ", GridColumn35.Caption)
                SQL &= String.Format(" Caption16 = '{0}', ", GridColumn36.Caption)
                SQL &= String.Format(" Caption17 = '{0}', ", GridColumn37.Caption)
                SQL &= String.Format(" Caption18 = '{0}', ", GridColumn38.Caption)
                SQL &= String.Format(" Caption19 = '{0}', ", GridColumn39.Caption)
                SQL &= String.Format(" Caption20 = '{0}', ", GridColumn40.Caption)
                SQL &= String.Format(" Caption21 = '{0}', ", GridColumn15.Caption)
                SQL &= String.Format(" Caption22 = '{0}', ", GridColumn42.Caption)
                SQL &= String.Format(" Caption23 = '{0}', ", GridColumn43.Caption)
                SQL &= String.Format(" Caption24 = '{0}', ", GridColumn44.Caption)
                SQL &= String.Format(" Caption25 = '{0}', ", GridColumn45.Caption)
                SQL &= String.Format(" Caption26 = '{0}', ", GridColumn46.Caption)
                SQL &= String.Format(" Caption27 = '{0}', ", GridColumn47.Caption)
                SQL &= String.Format(" Caption28 = '{0}', ", GridColumn48.Caption)
                SQL &= String.Format(" Caption29 = '{0}', ", GridColumn49.Caption)
                SQL &= String.Format(" Caption30 = '{0}', ", GridColumn50.Caption)
                SQL &= String.Format(" Caption31 = '{0}', ", GridColumn51.Caption)
                SQL &= String.Format(" Caption32 = '{0}', ", GridColumn52.Caption)
                SQL &= String.Format(" Caption33 = '{0}', ", GridColumn53.Caption)
                SQL &= String.Format(" Caption34 = '{0}', ", GridColumn54.Caption)
                SQL &= String.Format(" Caption35 = '{0}', ", GridColumn55.Caption)
                SQL &= String.Format(" Caption36 = '{0}', ", GridColumn56.Caption)
                SQL &= String.Format(" Caption37 = '{0}', ", GridColumn57.Caption)
                SQL &= String.Format(" Caption38 = '{0}', ", GridColumn58.Caption)
                SQL &= String.Format(" Caption39 = '{0}', ", GridColumn59.Caption)
                SQL &= String.Format(" Caption40 = '{0}', ", GridColumn60.Caption)

                SQL &= String.Format(" Caption1Tag = '{0}', ", GridColumn21.Tag)
                SQL &= String.Format(" Caption2Tag = '{0}', ", GridColumn22.Tag)
                SQL &= String.Format(" Caption3Tag = '{0}', ", GridColumn23.Tag)
                SQL &= String.Format(" Caption4Tag = '{0}', ", GridColumn24.Tag)
                SQL &= String.Format(" Caption5Tag = '{0}', ", GridColumn25.Tag)
                SQL &= String.Format(" Caption6Tag = '{0}', ", GridColumn26.Tag)
                SQL &= String.Format(" Caption7Tag = '{0}', ", GridColumn27.Tag)
                SQL &= String.Format(" Caption8Tag = '{0}', ", GridColumn28.Tag)
                SQL &= String.Format(" Caption9Tag = '{0}', ", GridColumn29.Tag)
                SQL &= String.Format(" Caption10Tag = '{0}', ", GridColumn31.Tag)
                SQL &= String.Format(" Caption11Tag = '{0}', ", GridColumn41.Tag)
                SQL &= String.Format(" Caption12Tag = '{0}', ", GridColumn32.Tag)
                SQL &= String.Format(" Caption13Tag = '{0}', ", GridColumn33.Tag)
                SQL &= String.Format(" Caption14Tag = '{0}', ", GridColumn34.Tag)
                SQL &= String.Format(" Caption15Tag = '{0}', ", GridColumn35.Tag)
                SQL &= String.Format(" Caption16Tag = '{0}', ", GridColumn36.Tag)
                SQL &= String.Format(" Caption17Tag = '{0}', ", GridColumn37.Tag)
                SQL &= String.Format(" Caption18Tag = '{0}', ", GridColumn38.Tag)
                SQL &= String.Format(" Caption19Tag = '{0}', ", GridColumn39.Tag)
                SQL &= String.Format(" Caption20Tag = '{0}', ", GridColumn40.Tag)
                SQL &= String.Format(" Caption21Tag = '{0}', ", GridColumn15.Tag)
                SQL &= String.Format(" Caption22Tag = '{0}', ", GridColumn42.Tag)
                SQL &= String.Format(" Caption23Tag = '{0}', ", GridColumn43.Tag)
                SQL &= String.Format(" Caption24Tag = '{0}', ", GridColumn44.Tag)
                SQL &= String.Format(" Caption25Tag = '{0}', ", GridColumn45.Tag)
                SQL &= String.Format(" Caption26Tag = '{0}', ", GridColumn46.Tag)
                SQL &= String.Format(" Caption27Tag = '{0}', ", GridColumn47.Tag)
                SQL &= String.Format(" Caption28Tag = '{0}', ", GridColumn48.Tag)
                SQL &= String.Format(" Caption29Tag = '{0}', ", GridColumn49.Tag)
                SQL &= String.Format(" Caption30Tag = '{0}', ", GridColumn50.Tag)
                SQL &= String.Format(" Caption31Tag = '{0}', ", GridColumn51.Tag)
                SQL &= String.Format(" Caption32Tag = '{0}', ", GridColumn52.Tag)
                SQL &= String.Format(" Caption33Tag = '{0}', ", GridColumn53.Tag)
                SQL &= String.Format(" Caption34Tag = '{0}', ", GridColumn54.Tag)
                SQL &= String.Format(" Caption35Tag = '{0}', ", GridColumn55.Tag)
                SQL &= String.Format(" Caption36Tag = '{0}', ", GridColumn56.Tag)
                SQL &= String.Format(" Caption37Tag = '{0}', ", GridColumn57.Tag)
                SQL &= String.Format(" Caption38Tag = '{0}', ", GridColumn58.Tag)
                SQL &= String.Format(" Caption39Tag = '{0}', ", GridColumn59.Tag)
                SQL &= String.Format(" Caption40Tag = '{0}', ", GridColumn60.Tag)
                SQL &= String.Format(" TotalExpenses = '{0}', ", dTotalExpense.Value)
                SQL &= String.Format(" RemainingCash = '{0}', ", dRemainingCash.Value)
                SQL &= String.Format(" Unliquidated = '{0}', ", dUnliquidated.Value)
                If Draft Then
                    SQL &= " `status` = 'DRAFT', "
                End If
                SQL &= String.Format(" PreparedID = '{0}', ", ValidateComboBox(cbxPreparedBy))
                SQL &= String.Format(" Check_OTAC = '{0}', ", Code)
                SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                SQL &= String.Format(" Branch_ID = '{0}';", Branch_ID)

                DataObject(SQL)
                SQL = ""
                ID = DataObject(String.Format("SELECT MAX(ID) FROM replenishment_cash WHERE DocumentNumber = '{0}';", txtAccountNumber.Text))
                'INSERT DETAILS
                For x As Integer = 0 To GridView2.RowCount - 2
                    SQL &= "INSERT INTO replenishment_details SET"
                    SQL &= String.Format(" RepNumber = '{0}', ", txtAccountNumber.Text)
                    SQL &= String.Format(" `Date` = '{0}', ", Format(DateValue(GridView2.GetRowCellValue(x, "Date")), "yyyy-MM-dd"))
                    SQL &= String.Format(" DocumentNumber = '{0}', ", GridView2.GetRowCellValue(x, "Document Number"))
                    SQL &= String.Format(" Particulars = '{0}', ", GridView2.GetRowCellValue(x, "Particulars").ToString.InsertQuote)
                    SQL &= String.Format(" Amount = '{0}',", CDbl(GridView2.GetRowCellValue(x, "Amount")))
                    SQL &= String.Format(" Amount1 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 1")))
                    SQL &= String.Format(" Amount2 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 2")))
                    SQL &= String.Format(" Amount3 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 3")))
                    SQL &= String.Format(" Amount4 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 4")))
                    SQL &= String.Format(" Amount5 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 5")))
                    SQL &= String.Format(" Amount6 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 6")))
                    SQL &= String.Format(" Amount7 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 7")))
                    SQL &= String.Format(" Amount8 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 8")))
                    SQL &= String.Format(" Amount9 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 9")))
                    SQL &= String.Format(" Amount10 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 10")))
                    SQL &= String.Format(" Amount11 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 11")))
                    SQL &= String.Format(" Amount12 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 12")))
                    SQL &= String.Format(" Amount13 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 13")))
                    SQL &= String.Format(" Amount14 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 14")))
                    SQL &= String.Format(" Amount15 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 15")))
                    SQL &= String.Format(" Amount16 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 16")))
                    SQL &= String.Format(" Amount17 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 17")))
                    SQL &= String.Format(" Amount18 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 18")))
                    SQL &= String.Format(" Amount19 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 19")))
                    SQL &= String.Format(" Amount20 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 20")))

                    SQL &= String.Format(" Amount21 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 21")))
                    SQL &= String.Format(" Amount22 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 22")))
                    SQL &= String.Format(" Amount23 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 23")))
                    SQL &= String.Format(" Amount24 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 24")))
                    SQL &= String.Format(" Amount25 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 25")))
                    SQL &= String.Format(" Amount26 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 26")))
                    SQL &= String.Format(" Amount27 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 27")))
                    SQL &= String.Format(" Amount28 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 28")))
                    SQL &= String.Format(" Amount29 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 29")))
                    SQL &= String.Format(" Amount30 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 30")))
                    SQL &= String.Format(" Amount31 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 31")))
                    SQL &= String.Format(" Amount32 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 32")))
                    SQL &= String.Format(" Amount33 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 33")))
                    SQL &= String.Format(" Amount34 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 34")))
                    SQL &= String.Format(" Amount35 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 35")))
                    SQL &= String.Format(" Amount36 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 36")))
                    SQL &= String.Format(" Amount37 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 37")))
                    SQL &= String.Format(" Amount38 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 38")))
                    SQL &= String.Format(" Amount39 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 39")))
                    SQL &= String.Format(" Amount40 = '{0}';", CDbl(GridView2.GetRowCellValue(x, "Amount 40")))

                    If GridView2.GetRowCellValue(x, "Document Number").ToString.Contains("CAS") Then
                        SQL &= String.Format("UPDATE cash_advance SET ReplenishedID = {0} WHERE AccountNumber = '{1}' AND ReplenishedID = 0;", ID, GridView2.GetRowCellValue(x, "Document Number"))
                    ElseIf GridView2.GetRowCellValue(x, "Document Number").ToString.Contains("PCV") Then
                        SQL &= String.Format("UPDATE petty_cash SET ReplenishedID = {0} WHERE AccountNumber = '{1}' AND ReplenishedID = 0;", ID, GridView2.GetRowCellValue(x, "Document Number"))
                    End If
                Next

                DataObject(SQL)
                Logs("Replenishment", "Save", String.Format("Add new Petty Cash Replenishment {1} with total expense {0}.", dTotalExpense.Text, txtAccountNumber), "", "", "", "")
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
HereV2:
                Dim CancelledID As Integer = DataObject(String.Format("SELECT IFNULL(ID,0) FROM replenishment_cash WHERE ID = {0} AND `status` IN ('CANCELLED','DISAPPROVED')", ID))
                If CancelledID > 0 Then
                    MsgBox("This transaction was recently CANCELLED/DISAPPROVED, modification is not allowed anymore.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                'INSERT MAIN
                Dim SQL As String = "UPDATE replenishment_cash SET"
                SQL &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text.InsertQuote)
                SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text.InsertQuote)
                SQL &= String.Format(" Cols = '{0}', ", Columns)
                SQL &= String.Format(" Caption1 = '{0}', ", GridColumn21.Caption)
                SQL &= String.Format(" Caption2 = '{0}', ", GridColumn22.Caption)
                SQL &= String.Format(" Caption3 = '{0}', ", GridColumn23.Caption)
                SQL &= String.Format(" Caption4 = '{0}', ", GridColumn24.Caption)
                SQL &= String.Format(" Caption5 = '{0}', ", GridColumn25.Caption)
                SQL &= String.Format(" Caption6 = '{0}', ", GridColumn26.Caption)
                SQL &= String.Format(" Caption7 = '{0}', ", GridColumn27.Caption)
                SQL &= String.Format(" Caption8 = '{0}', ", GridColumn28.Caption)
                SQL &= String.Format(" Caption9 = '{0}', ", GridColumn29.Caption)
                SQL &= String.Format(" Caption10 = '{0}', ", GridColumn31.Caption)
                SQL &= String.Format(" Caption11 = '{0}', ", GridColumn41.Caption)
                SQL &= String.Format(" Caption12 = '{0}', ", GridColumn32.Caption)
                SQL &= String.Format(" Caption13 = '{0}', ", GridColumn33.Caption)
                SQL &= String.Format(" Caption14 = '{0}', ", GridColumn34.Caption)
                SQL &= String.Format(" Caption15 = '{0}', ", GridColumn35.Caption)
                SQL &= String.Format(" Caption16 = '{0}', ", GridColumn36.Caption)
                SQL &= String.Format(" Caption17 = '{0}', ", GridColumn37.Caption)
                SQL &= String.Format(" Caption18 = '{0}', ", GridColumn38.Caption)
                SQL &= String.Format(" Caption19 = '{0}', ", GridColumn39.Caption)
                SQL &= String.Format(" Caption20 = '{0}', ", GridColumn40.Caption)
                SQL &= String.Format(" Caption21 = '{0}', ", GridColumn15.Caption)
                SQL &= String.Format(" Caption22 = '{0}', ", GridColumn42.Caption)
                SQL &= String.Format(" Caption23 = '{0}', ", GridColumn43.Caption)
                SQL &= String.Format(" Caption24 = '{0}', ", GridColumn44.Caption)
                SQL &= String.Format(" Caption25 = '{0}', ", GridColumn45.Caption)
                SQL &= String.Format(" Caption26 = '{0}', ", GridColumn46.Caption)
                SQL &= String.Format(" Caption27 = '{0}', ", GridColumn47.Caption)
                SQL &= String.Format(" Caption28 = '{0}', ", GridColumn48.Caption)
                SQL &= String.Format(" Caption29 = '{0}', ", GridColumn49.Caption)
                SQL &= String.Format(" Caption30 = '{0}', ", GridColumn50.Caption)
                SQL &= String.Format(" Caption31 = '{0}', ", GridColumn51.Caption)
                SQL &= String.Format(" Caption32 = '{0}', ", GridColumn52.Caption)
                SQL &= String.Format(" Caption33 = '{0}', ", GridColumn53.Caption)
                SQL &= String.Format(" Caption34 = '{0}', ", GridColumn54.Caption)
                SQL &= String.Format(" Caption35 = '{0}', ", GridColumn55.Caption)
                SQL &= String.Format(" Caption36 = '{0}', ", GridColumn56.Caption)
                SQL &= String.Format(" Caption37 = '{0}', ", GridColumn57.Caption)
                SQL &= String.Format(" Caption38 = '{0}', ", GridColumn58.Caption)
                SQL &= String.Format(" Caption39 = '{0}', ", GridColumn59.Caption)
                SQL &= String.Format(" Caption40 = '{0}', ", GridColumn60.Caption)

                SQL &= String.Format(" Caption1Tag = '{0}', ", GridColumn21.Tag)
                SQL &= String.Format(" Caption2Tag = '{0}', ", GridColumn22.Tag)
                SQL &= String.Format(" Caption3Tag = '{0}', ", GridColumn23.Tag)
                SQL &= String.Format(" Caption4Tag = '{0}', ", GridColumn24.Tag)
                SQL &= String.Format(" Caption5Tag = '{0}', ", GridColumn25.Tag)
                SQL &= String.Format(" Caption6Tag = '{0}', ", GridColumn26.Tag)
                SQL &= String.Format(" Caption7Tag = '{0}', ", GridColumn27.Tag)
                SQL &= String.Format(" Caption8Tag = '{0}', ", GridColumn28.Tag)
                SQL &= String.Format(" Caption9Tag = '{0}', ", GridColumn29.Tag)
                SQL &= String.Format(" Caption10Tag = '{0}', ", GridColumn31.Tag)
                SQL &= String.Format(" Caption11Tag = '{0}', ", GridColumn41.Tag)
                SQL &= String.Format(" Caption12Tag = '{0}', ", GridColumn32.Tag)
                SQL &= String.Format(" Caption13Tag = '{0}', ", GridColumn33.Tag)
                SQL &= String.Format(" Caption14Tag = '{0}', ", GridColumn34.Tag)
                SQL &= String.Format(" Caption15Tag = '{0}', ", GridColumn35.Tag)
                SQL &= String.Format(" Caption16Tag = '{0}', ", GridColumn36.Tag)
                SQL &= String.Format(" Caption17Tag = '{0}', ", GridColumn37.Tag)
                SQL &= String.Format(" Caption18Tag = '{0}', ", GridColumn38.Tag)
                SQL &= String.Format(" Caption19Tag = '{0}', ", GridColumn39.Tag)
                SQL &= String.Format(" Caption20Tag = '{0}', ", GridColumn40.Tag)
                SQL &= String.Format(" Caption21Tag = '{0}', ", GridColumn15.Tag)
                SQL &= String.Format(" Caption22Tag = '{0}', ", GridColumn42.Tag)
                SQL &= String.Format(" Caption23Tag = '{0}', ", GridColumn43.Tag)
                SQL &= String.Format(" Caption24Tag = '{0}', ", GridColumn44.Tag)
                SQL &= String.Format(" Caption25Tag = '{0}', ", GridColumn45.Tag)
                SQL &= String.Format(" Caption26Tag = '{0}', ", GridColumn46.Tag)
                SQL &= String.Format(" Caption27Tag = '{0}', ", GridColumn47.Tag)
                SQL &= String.Format(" Caption28Tag = '{0}', ", GridColumn48.Tag)
                SQL &= String.Format(" Caption29Tag = '{0}', ", GridColumn49.Tag)
                SQL &= String.Format(" Caption30Tag = '{0}', ", GridColumn50.Tag)
                SQL &= String.Format(" Caption31Tag = '{0}', ", GridColumn51.Tag)
                SQL &= String.Format(" Caption32Tag = '{0}', ", GridColumn52.Tag)
                SQL &= String.Format(" Caption33Tag = '{0}', ", GridColumn53.Tag)
                SQL &= String.Format(" Caption34Tag = '{0}', ", GridColumn54.Tag)
                SQL &= String.Format(" Caption35Tag = '{0}', ", GridColumn55.Tag)
                SQL &= String.Format(" Caption36Tag = '{0}', ", GridColumn56.Tag)
                SQL &= String.Format(" Caption37Tag = '{0}', ", GridColumn57.Tag)
                SQL &= String.Format(" Caption38Tag = '{0}', ", GridColumn58.Tag)
                SQL &= String.Format(" Caption39Tag = '{0}', ", GridColumn59.Tag)
                SQL &= String.Format(" Caption40Tag = '{0}', ", GridColumn60.Tag)
                If Draft = False Then
                    SQL &= " `status` = 'ACTIVE', "
                End If
                SQL &= String.Format(" TotalExpenses = '{0}', ", dTotalExpense.Value)
                SQL &= String.Format(" RemainingCash = '{0}', ", dRemainingCash.Value)
                SQL &= String.Format(" Unliquidated = '{0}' ", dUnliquidated.Value)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)

                'UPDATE DETAILS
                SQL &= String.Format("UPDATE replenishment_details SET `status` = 'CANCELLED' WHERE RepNumber = '{0}';", txtAccountNumber.Text)
                SQL &= String.Format("UPDATE cash_advance SET ReplenishedID = 0 WHERE ReplenishedID = {0};", ID)
                SQL &= String.Format("UPDATE petty_cash SET ReplenishedID = 0 WHERE ReplenishedID = {0};", ID)
                For x As Integer = 0 To GridView2.RowCount - 2
                    SQL &= "INSERT INTO replenishment_details SET"
                    SQL &= String.Format(" RepNumber = '{0}', ", txtAccountNumber.Text)
                    SQL &= String.Format(" `Date` = '{0}', ", Format(DateValue(GridView2.GetRowCellValue(x, "Date")), "yyyy-MM-dd"))
                    SQL &= String.Format(" DocumentNumber = '{0}', ", GridView2.GetRowCellValue(x, "Document Number"))
                    SQL &= String.Format(" Particulars = '{0}', ", GridView2.GetRowCellValue(x, "Particulars").ToString.InsertQuote)
                    SQL &= String.Format(" Amount = '{0}',", CDbl(GridView2.GetRowCellValue(x, "Amount")))
                    SQL &= String.Format(" Amount1 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 1")))
                    SQL &= String.Format(" Amount2 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 2")))
                    SQL &= String.Format(" Amount3 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 3")))
                    SQL &= String.Format(" Amount4 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 4")))
                    SQL &= String.Format(" Amount5 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 5")))
                    SQL &= String.Format(" Amount6 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 6")))
                    SQL &= String.Format(" Amount7 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 7")))
                    SQL &= String.Format(" Amount8 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 8")))
                    SQL &= String.Format(" Amount9 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 9")))
                    SQL &= String.Format(" Amount10 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 10")))
                    SQL &= String.Format(" Amount11 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 11")))
                    SQL &= String.Format(" Amount12 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 12")))
                    SQL &= String.Format(" Amount13 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 13")))
                    SQL &= String.Format(" Amount14 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 14")))
                    SQL &= String.Format(" Amount15 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 15")))
                    SQL &= String.Format(" Amount16 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 16")))
                    SQL &= String.Format(" Amount17 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 17")))
                    SQL &= String.Format(" Amount18 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 18")))
                    SQL &= String.Format(" Amount19 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 19")))
                    SQL &= String.Format(" Amount20 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 20")))

                    SQL &= String.Format(" Amount21 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 21")))
                    SQL &= String.Format(" Amount22 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 22")))
                    SQL &= String.Format(" Amount23 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 23")))
                    SQL &= String.Format(" Amount24 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 24")))
                    SQL &= String.Format(" Amount25 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 25")))
                    SQL &= String.Format(" Amount26 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 26")))
                    SQL &= String.Format(" Amount27 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 27")))
                    SQL &= String.Format(" Amount28 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 28")))
                    SQL &= String.Format(" Amount29 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 29")))
                    SQL &= String.Format(" Amount30 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 30")))
                    SQL &= String.Format(" Amount31 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 31")))
                    SQL &= String.Format(" Amount32 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 32")))
                    SQL &= String.Format(" Amount33 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 33")))
                    SQL &= String.Format(" Amount34 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 34")))
                    SQL &= String.Format(" Amount35 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 35")))
                    SQL &= String.Format(" Amount36 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 36")))
                    SQL &= String.Format(" Amount37 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 37")))
                    SQL &= String.Format(" Amount38 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 38")))
                    SQL &= String.Format(" Amount39 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 39")))
                    SQL &= String.Format(" Amount40 = '{0}';", CDbl(GridView2.GetRowCellValue(x, "Amount 40")))

                    If GridView2.GetRowCellValue(x, "Document Number").ToString.Contains("CAS") Then
                        SQL &= String.Format("UPDATE cash_advance SET ReplenishedID = {0} WHERE AccountNumber = '{1}' AND ReplenishedID = 0;", ID, GridView2.GetRowCellValue(x, "Document Number"))
                    ElseIf GridView2.GetRowCellValue(x, "Document Number").ToString.Contains("PCV") Then
                        SQL &= String.Format("UPDATE petty_cash SET ReplenishedID = {0} WHERE AccountNumber = '{1}' AND ReplenishedID = 0;", ID, GridView2.GetRowCellValue(x, "Document Number"))
                    End If
                Next

                DataObject(SQL)
                Logs("Replenishment", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtReferenceNumber.Text = txtReferenceNumber.Tag Then
            Else
                Change &= String.Format("Change Reference Number from {0} to {1}. ", txtReferenceNumber.Tag, txtReferenceNumber.Text)
            End If
            If dTotalExpense.Text = dTotalExpense.Tag Then
            Else
                Change &= String.Format("Change Total Expense from {0} to {1}. ", dTotalExpense.Tag, dTotalExpense.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Replenishment - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function

    Private Sub BtnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mModify) = MsgBoxResult.Yes Then
            If btnDraft.Visible Then
                btnDraft.Enabled = True
                btnDraft.Text = "Update Draft"
            Else
                btnSave.Text = "Update"
            End If
            btnUpdateCA.Visible = True
            btnSave.Enabled = True
            btnModify.Enabled = False
            btnDelete.Enabled = True
            PanelEx10.Enabled = True
            btnPrint.Enabled = False
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If vDelete Then
        Else
            MsgBox(mBox_Delete, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            DataObject(String.Format("UPDATE replenishment_cash SET `status` = 'CANCELLED' WHERE ID = '{0}'; UPDATE cash_advance SET ReplenishedID = 0 WHERE ReplenishedID = {0}; UPDATE petty_cash SET ReplenishedID = 0 WHERE ReplenishedID = {0};", ID))
            Logs("Replenishment", "Cancel", Reason, String.Format("Cancel Petty Cash Replenishment {1} with total expense of {0}.", dTotalExpense.Text, txtAccountNumber.Text), "", "", "")
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub Generate_Receipt(Show As Boolean, FName As String)
        If Columns <= 20 Then
            Dim Report As New RptReplenishment
            With Report
                .Name = String.Format("Petty Cash Replenishment {0}", txtAccountNumber.Text)
                .lblAsOf.Text = dtpDate.Text
                .lblDocumentNum.Text = txtAccountNumber.Text
                .lblReferenceNum.Text = txtReferenceNumber.Text
                .lblRemarks.Text = txtRemarks.Text

                .lblCaption1.Text = GridColumn21.Caption
                .lblCaption2.Text = GridColumn22.Caption
                .lblCaption3.Text = GridColumn23.Caption
                .lblCaption4.Text = GridColumn24.Caption
                .lblCaption5.Text = GridColumn25.Caption
                .lblCaption6.Text = GridColumn26.Caption
                .lblCaption7.Text = GridColumn27.Caption
                .lblCaption8.Text = GridColumn28.Caption
                .lblCaption9.Text = GridColumn29.Caption
                .lblCaption10.Text = GridColumn31.Caption
                .lblCaption11.Text = GridColumn41.Caption
                .lblCaption12.Text = GridColumn32.Caption
                .lblCaption13.Text = GridColumn33.Caption
                .lblCaption14.Text = GridColumn34.Caption
                .lblCaption15.Text = GridColumn35.Caption
                .lblCaption16.Text = GridColumn36.Caption
                .lblCaption17.Text = GridColumn37.Caption
                .lblCaption18.Text = GridColumn38.Caption
                .lblCaption19.Text = GridColumn39.Caption
                .lblCaption20.Text = GridColumn40.Caption

                .DataSource = GridControl2.DataSource
                .lblDate.DataBindings.Add("Text", GridControl2.DataSource, "Date")
                .lblDocumentNumber.DataBindings.Add("Text", GridControl2.DataSource, "Document Number")
                .lblParticulars.DataBindings.Add("Text", GridControl2.DataSource, "Particulars")
                .lblAmount.DataBindings.Add("Text", GridControl2.DataSource, "Amount")
                .lbl1.DataBindings.Add("Text", GridControl2.DataSource, "Amount 1")
                .lbl2.DataBindings.Add("Text", GridControl2.DataSource, "Amount 2")
                .lbl3.DataBindings.Add("Text", GridControl2.DataSource, "Amount 3")
                .lbl4.DataBindings.Add("Text", GridControl2.DataSource, "Amount 4")
                .lbl5.DataBindings.Add("Text", GridControl2.DataSource, "Amount 5")
                .lbl6.DataBindings.Add("Text", GridControl2.DataSource, "Amount 6")
                .lbl7.DataBindings.Add("Text", GridControl2.DataSource, "Amount 7")
                .lbl8.DataBindings.Add("Text", GridControl2.DataSource, "Amount 8")
                .lbl9.DataBindings.Add("Text", GridControl2.DataSource, "Amount 9")
                .lbl10.DataBindings.Add("Text", GridControl2.DataSource, "Amount 10")
                .lbl11.DataBindings.Add("Text", GridControl2.DataSource, "Amount 11")
                .lbl12.DataBindings.Add("Text", GridControl2.DataSource, "Amount 12")
                .lbl13.DataBindings.Add("Text", GridControl2.DataSource, "Amount 13")
                .lbl14.DataBindings.Add("Text", GridControl2.DataSource, "Amount 14")
                .lbl15.DataBindings.Add("Text", GridControl2.DataSource, "Amount 15")
                .lbl16.DataBindings.Add("Text", GridControl2.DataSource, "Amount 16")
                .lbl17.DataBindings.Add("Text", GridControl2.DataSource, "Amount 17")
                .lbl18.DataBindings.Add("Text", GridControl2.DataSource, "Amount 18")
                .lbl19.DataBindings.Add("Text", GridControl2.DataSource, "Amount 19")
                .lbl20.DataBindings.Add("Text", GridControl2.DataSource, "Amount 20")

                If Columns = 4 Then
                    .lblDate_C.SizeF = New Size(70 + 30, 35)
                    .lblDate.SizeF = New Size(70 + 30, 20)
                    .lblDocumentNumber_C.SizeF = New Size(85 + 30, 35)
                    .lblDocumentNumber.SizeF = New Size(85 + 30, 20)
                    .lblParticulars_C.SizeF = New Size(135 + 400, 35)
                    .lblParticulars.SizeF = New Size(135 + 400, 20)
                    .lblAmount_C.SizeF = New Size(60 + 40, 35)
                    .lblAmount.SizeF = New Size(60 + 40, 20)
                    .lblCaption1.SizeF = New Size(45 + 55, 35)
                    .lbl1.SizeF = New Size(45 + 55, 20)
                    .lblCaption2.SizeF = New Size(45 + 55, 35)
                    .lbl2.SizeF = New Size(45 + 55, 20)
                    .lblCaption3.SizeF = New Size(45 + 55, 35)
                    .lbl3.SizeF = New Size(45 + 55, 20)
                    .lblCaption4.SizeF = New Size(45 + 55, 35)
                    .lbl4.SizeF = New Size(45 + 55, 20)

                    .lblDocumentNumber_C.LocationF = New Point(70 + 30, 85)
                    .lblDocumentNumber.LocationF = New Point(70 + 30, 0)
                    .lblParticulars_C.LocationF = New Point(155 + 60, 85)
                    .lblParticulars.LocationF = New Point(155 + 60, 0)
                    .lblAmount_C.LocationF = New Point(290 + 460, 85)
                    .lblAmount.LocationF = New Point(290 + 460, 0)
                    .lblCaption1.LocationF = New Point(350 + 500, 85)
                    .lbl1.LocationF = New Point(350 + 500, 0)
                    .lblCaption2.LocationF = New Point(395 + 555, 85)
                    .lbl2.LocationF = New Point(395 + 555, 0)
                    .lblCaption3.LocationF = New Point(440 + 610, 85)
                    .lbl3.LocationF = New Point(440 + 610, 0)
                    .lblCaption4.LocationF = New Point(485 + 665, 85)
                    .lbl4.LocationF = New Point(485 + 665, 0)

                    .lblCaption4.Borders = DevExpress.XtraPrinting.BorderSide.All
                    .lbl4.Borders = DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Right
                ElseIf Columns = 5 Then
                    .lblDate_C.SizeF = New Size(70 + 30, 35)
                    .lblDate.SizeF = New Size(70 + 30, 20)
                    .lblDocumentNumber_C.SizeF = New Size(85 + 30, 35)
                    .lblDocumentNumber.SizeF = New Size(85 + 30, 20)
                    .lblParticulars_C.SizeF = New Size(135 + 300, 35)
                    .lblParticulars.SizeF = New Size(135 + 300, 20)
                    .lblAmount_C.SizeF = New Size(60 + 40, 35)
                    .lblAmount.SizeF = New Size(60 + 40, 20)
                    .lblCaption1.SizeF = New Size(45 + 55, 35)
                    .lbl1.SizeF = New Size(45 + 55, 20)
                    .lblCaption2.SizeF = New Size(45 + 55, 35)
                    .lbl2.SizeF = New Size(45 + 55, 20)
                    .lblCaption3.SizeF = New Size(45 + 55, 35)
                    .lbl3.SizeF = New Size(45 + 55, 20)
                    .lblCaption4.SizeF = New Size(45 + 55, 35)
                    .lbl4.SizeF = New Size(45 + 55, 20)
                    .lblCaption5.SizeF = New Size(45 + 55, 35)
                    .lbl5.SizeF = New Size(45 + 55, 20)

                    .lblDocumentNumber_C.LocationF = New Point(70 + 30, 85)
                    .lblDocumentNumber.LocationF = New Point(70 + 30, 0)
                    .lblParticulars_C.LocationF = New Point(155 + 60, 85)
                    .lblParticulars.LocationF = New Point(155 + 60, 0)
                    .lblAmount_C.LocationF = New Point(290 + 360, 85)
                    .lblAmount.LocationF = New Point(290 + 360, 0)
                    .lblCaption1.LocationF = New Point(350 + 400, 85)
                    .lbl1.LocationF = New Point(350 + 400, 0)
                    .lblCaption2.LocationF = New Point(395 + 455, 85)
                    .lbl2.LocationF = New Point(395 + 455, 0)
                    .lblCaption3.LocationF = New Point(440 + 510, 85)
                    .lbl3.LocationF = New Point(440 + 510, 0)
                    .lblCaption4.LocationF = New Point(485 + 565, 85)
                    .lbl4.LocationF = New Point(485 + 565, 0)
                    .lblCaption5.LocationF = New Point(530 + 620, 85)
                    .lbl5.LocationF = New Point(530 + 620, 0)

                    .lblCaption5.Visible = True
                    .lbl5.Visible = True
                    .lblCaption5.Borders = DevExpress.XtraPrinting.BorderSide.All
                    .lbl5.Borders = DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Right
                ElseIf Columns = 6 Then
                    .lblDate_C.SizeF = New Size(70 + 30, 35)
                    .lblDate.SizeF = New Size(70 + 30, 20)
                    .lblDocumentNumber_C.SizeF = New Size(85 + 30, 35)
                    .lblDocumentNumber.SizeF = New Size(85 + 30, 20)
                    .lblParticulars_C.SizeF = New Size(135 + 200, 35)
                    .lblParticulars.SizeF = New Size(135 + 200, 20)
                    .lblAmount_C.SizeF = New Size(60 + 40, 35)
                    .lblAmount.SizeF = New Size(60 + 40, 20)
                    .lblCaption1.SizeF = New Size(45 + 55, 35)
                    .lbl1.SizeF = New Size(45 + 55, 20)
                    .lblCaption2.SizeF = New Size(45 + 55, 35)
                    .lbl2.SizeF = New Size(45 + 55, 20)
                    .lblCaption3.SizeF = New Size(45 + 55, 35)
                    .lbl3.SizeF = New Size(45 + 55, 20)
                    .lblCaption4.SizeF = New Size(45 + 55, 35)
                    .lbl4.SizeF = New Size(45 + 55, 20)
                    .lblCaption5.SizeF = New Size(45 + 55, 35)
                    .lbl5.SizeF = New Size(45 + 55, 20)
                    .lblCaption6.SizeF = New Size(45 + 55, 35)
                    .lbl6.SizeF = New Size(45 + 55, 20)

                    .lblDocumentNumber_C.LocationF = New Point(70 + 30, 85)
                    .lblDocumentNumber.LocationF = New Point(70 + 30, 0)
                    .lblParticulars_C.LocationF = New Point(155 + 60, 85)
                    .lblParticulars.LocationF = New Point(155 + 60, 0)
                    .lblAmount_C.LocationF = New Point(290 + 260, 85)
                    .lblAmount.LocationF = New Point(290 + 260, 0)
                    .lblCaption1.LocationF = New Point(350 + 300, 85)
                    .lbl1.LocationF = New Point(350 + 300, 0)
                    .lblCaption2.LocationF = New Point(395 + 355, 85)
                    .lbl2.LocationF = New Point(395 + 355, 0)
                    .lblCaption3.LocationF = New Point(440 + 410, 85)
                    .lbl3.LocationF = New Point(440 + 410, 0)
                    .lblCaption4.LocationF = New Point(485 + 465, 85)
                    .lbl4.LocationF = New Point(485 + 465, 0)
                    .lblCaption5.LocationF = New Point(530 + 520, 85)
                    .lbl5.LocationF = New Point(530 + 520, 0)
                    .lblCaption6.LocationF = New Point(575 + 575, 85)
                    .lbl6.LocationF = New Point(575 + 575, 0)

                    .lblCaption5.Visible = True
                    .lbl5.Visible = True
                    .lblCaption6.Visible = True
                    .lbl6.Visible = True
                    .lblCaption6.Borders = DevExpress.XtraPrinting.BorderSide.All
                    .lbl6.Borders = DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Right
                ElseIf Columns = 7 Then
                    .lblDate_C.SizeF = New Size(70 + 30, 35)
                    .lblDate.SizeF = New Size(70 + 30, 20)
                    .lblDocumentNumber_C.SizeF = New Size(85 + 30, 35)
                    .lblDocumentNumber.SizeF = New Size(85 + 30, 20)
                    .lblParticulars_C.SizeF = New Size(135 + 100, 35)
                    .lblParticulars.SizeF = New Size(135 + 100, 20)
                    .lblAmount_C.SizeF = New Size(60 + 40, 35)
                    .lblAmount.SizeF = New Size(60 + 40, 20)
                    .lblCaption1.SizeF = New Size(45 + 55, 35)
                    .lbl1.SizeF = New Size(45 + 55, 20)
                    .lblCaption2.SizeF = New Size(45 + 55, 35)
                    .lbl2.SizeF = New Size(45 + 55, 20)
                    .lblCaption3.SizeF = New Size(45 + 55, 35)
                    .lbl3.SizeF = New Size(45 + 55, 20)
                    .lblCaption4.SizeF = New Size(45 + 55, 35)
                    .lbl4.SizeF = New Size(45 + 55, 20)
                    .lblCaption5.SizeF = New Size(45 + 55, 35)
                    .lbl5.SizeF = New Size(45 + 55, 20)
                    .lblCaption6.SizeF = New Size(45 + 55, 35)
                    .lbl6.SizeF = New Size(45 + 55, 20)
                    .lblCaption7.SizeF = New Size(45 + 55, 35)
                    .lbl7.SizeF = New Size(45 + 55, 20)

                    .lblDocumentNumber_C.LocationF = New Point(70 + 30, 85)
                    .lblDocumentNumber.LocationF = New Point(70 + 30, 0)
                    .lblParticulars_C.LocationF = New Point(155 + 60, 85)
                    .lblParticulars.LocationF = New Point(155 + 60, 0)
                    .lblAmount_C.LocationF = New Point(290 + 160, 85)
                    .lblAmount.LocationF = New Point(290 + 160, 0)
                    .lblCaption1.LocationF = New Point(350 + 200, 85)
                    .lbl1.LocationF = New Point(350 + 200, 0)
                    .lblCaption2.LocationF = New Point(395 + 255, 85)
                    .lbl2.LocationF = New Point(395 + 255, 0)
                    .lblCaption3.LocationF = New Point(440 + 310, 85)
                    .lbl3.LocationF = New Point(440 + 310, 0)
                    .lblCaption4.LocationF = New Point(485 + 365, 85)
                    .lbl4.LocationF = New Point(485 + 365, 0)
                    .lblCaption5.LocationF = New Point(530 + 420, 85)
                    .lbl5.LocationF = New Point(530 + 420, 0)
                    .lblCaption6.LocationF = New Point(575 + 475, 85)
                    .lbl6.LocationF = New Point(575 + 475, 0)
                    .lblCaption7.LocationF = New Point(620 + 530, 85)
                    .lbl7.LocationF = New Point(620 + 530, 0)

                    .lblCaption5.Visible = True
                    .lbl5.Visible = True
                    .lblCaption6.Visible = True
                    .lbl6.Visible = True
                    .lblCaption7.Visible = True
                    .lbl7.Visible = True
                    .lblCaption7.Borders = DevExpress.XtraPrinting.BorderSide.All
                    .lbl7.Borders = DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Right
                ElseIf Columns = 8 Then
                    .lblDate_C.SizeF = New Size(70 + 30, 35)
                    .lblDate.SizeF = New Size(70 + 30, 20)
                    .lblDocumentNumber_C.SizeF = New Size(85 + 30, 35)
                    .lblDocumentNumber.SizeF = New Size(85 + 30, 20)
                    .lblParticulars_C.SizeF = New Size(135 + 200, 35)
                    .lblParticulars.SizeF = New Size(135 + 200, 20)
                    .lblAmount_C.SizeF = New Size(60 + 40, 35)
                    .lblAmount.SizeF = New Size(60 + 40, 20)
                    .lblCaption1.SizeF = New Size(45 + 30, 35)
                    .lbl1.SizeF = New Size(45 + 30, 20)
                    .lblCaption2.SizeF = New Size(45 + 30, 35)
                    .lbl2.SizeF = New Size(45 + 30, 20)
                    .lblCaption3.SizeF = New Size(45 + 30, 35)
                    .lbl3.SizeF = New Size(45 + 30, 20)
                    .lblCaption4.SizeF = New Size(45 + 30, 35)
                    .lbl4.SizeF = New Size(45 + 30, 20)
                    .lblCaption5.SizeF = New Size(45 + 30, 35)
                    .lbl5.SizeF = New Size(45 + 30, 20)
                    .lblCaption6.SizeF = New Size(45 + 30, 35)
                    .lbl6.SizeF = New Size(45 + 30, 20)
                    .lblCaption7.SizeF = New Size(45 + 30, 35)
                    .lbl7.SizeF = New Size(45 + 30, 20)
                    .lblCaption8.SizeF = New Size(45 + 30, 35)
                    .lbl8.SizeF = New Size(45 + 30, 20)

                    .lblDocumentNumber_C.LocationF = New Point(70 + 30, 85)
                    .lblDocumentNumber.LocationF = New Point(70 + 30, 0)
                    .lblParticulars_C.LocationF = New Point(155 + 60, 85)
                    .lblParticulars.LocationF = New Point(155 + 60, 0)
                    .lblAmount_C.LocationF = New Point(290 + 260, 85)
                    .lblAmount.LocationF = New Point(290 + 260, 0)
                    .lblCaption1.LocationF = New Point(350 + 300, 85)
                    .lbl1.LocationF = New Point(350 + 300, 0)
                    .lblCaption2.LocationF = New Point(395 + 330, 85)
                    .lbl2.LocationF = New Point(395 + 330, 0)
                    .lblCaption3.LocationF = New Point(440 + 360, 85)
                    .lbl3.LocationF = New Point(440 + 360, 0)
                    .lblCaption4.LocationF = New Point(485 + 390, 85)
                    .lbl4.LocationF = New Point(485 + 390, 0)
                    .lblCaption5.LocationF = New Point(530 + 420, 85)
                    .lbl5.LocationF = New Point(530 + 420, 0)
                    .lblCaption6.LocationF = New Point(575 + 450, 85)
                    .lbl6.LocationF = New Point(575 + 450, 0)
                    .lblCaption7.LocationF = New Point(620 + 480, 85)
                    .lbl7.LocationF = New Point(620 + 480, 0)
                    .lblCaption8.LocationF = New Point(665 + 510, 85)
                    .lbl8.LocationF = New Point(665 + 510, 0)

                    .lblCaption5.Visible = True
                    .lbl5.Visible = True
                    .lblCaption6.Visible = True
                    .lbl6.Visible = True
                    .lblCaption7.Visible = True
                    .lbl7.Visible = True
                    .lblCaption8.Visible = True
                    .lbl8.Visible = True
                    .lblCaption8.Borders = DevExpress.XtraPrinting.BorderSide.All
                    .lbl8.Borders = DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Right
                ElseIf Columns = 9 Then
                    .lblDate_C.SizeF = New Size(70 + 30, 35)
                    .lblDate.SizeF = New Size(70 + 30, 20)
                    .lblDocumentNumber_C.SizeF = New Size(85 + 30, 35)
                    .lblDocumentNumber.SizeF = New Size(85 + 30, 20)
                    .lblParticulars_C.SizeF = New Size(135 + 125, 35)
                    .lblParticulars.SizeF = New Size(135 + 125, 20)
                    .lblAmount_C.SizeF = New Size(60 + 40, 35)
                    .lblAmount.SizeF = New Size(60 + 40, 20)
                    .lblCaption1.SizeF = New Size(45 + 30, 35)
                    .lbl1.SizeF = New Size(45 + 30, 20)
                    .lblCaption2.SizeF = New Size(45 + 30, 35)
                    .lbl2.SizeF = New Size(45 + 30, 20)
                    .lblCaption3.SizeF = New Size(45 + 30, 35)
                    .lbl3.SizeF = New Size(45 + 30, 20)
                    .lblCaption4.SizeF = New Size(45 + 30, 35)
                    .lbl4.SizeF = New Size(45 + 30, 20)
                    .lblCaption5.SizeF = New Size(45 + 30, 35)
                    .lbl5.SizeF = New Size(45 + 30, 20)
                    .lblCaption6.SizeF = New Size(45 + 30, 35)
                    .lbl6.SizeF = New Size(45 + 30, 20)
                    .lblCaption7.SizeF = New Size(45 + 30, 35)
                    .lbl7.SizeF = New Size(45 + 30, 20)
                    .lblCaption8.SizeF = New Size(45 + 30, 35)
                    .lbl8.SizeF = New Size(45 + 30, 20)
                    .lblCaption9.SizeF = New Size(45 + 30, 35)
                    .lbl9.SizeF = New Size(45 + 30, 20)

                    .lblDocumentNumber_C.LocationF = New Point(70 + 30, 85)
                    .lblDocumentNumber.LocationF = New Point(70 + 30, 0)
                    .lblParticulars_C.LocationF = New Point(155 + 60, 85)
                    .lblParticulars.LocationF = New Point(155 + 60, 0)
                    .lblAmount_C.LocationF = New Point(290 + 185, 85)
                    .lblAmount.LocationF = New Point(290 + 185, 0)
                    .lblCaption1.LocationF = New Point(350 + 225, 85)
                    .lbl1.LocationF = New Point(350 + 225, 0)
                    .lblCaption2.LocationF = New Point(395 + 255, 85)
                    .lbl2.LocationF = New Point(395 + 255, 0)
                    .lblCaption3.LocationF = New Point(440 + 285, 85)
                    .lbl3.LocationF = New Point(440 + 285, 0)
                    .lblCaption4.LocationF = New Point(485 + 315, 85)
                    .lbl4.LocationF = New Point(485 + 315, 0)
                    .lblCaption5.LocationF = New Point(530 + 345, 85)
                    .lbl5.LocationF = New Point(530 + 345, 0)
                    .lblCaption6.LocationF = New Point(575 + 375, 85)
                    .lbl6.LocationF = New Point(575 + 375, 0)
                    .lblCaption7.LocationF = New Point(620 + 405, 85)
                    .lbl7.LocationF = New Point(620 + 405, 0)
                    .lblCaption8.LocationF = New Point(665 + 435, 85)
                    .lbl8.LocationF = New Point(665 + 435, 0)
                    .lblCaption9.LocationF = New Point(710 + 465, 85)
                    .lbl9.LocationF = New Point(710 + 465, 0)

                    .lblCaption5.Visible = True
                    .lbl5.Visible = True
                    .lblCaption6.Visible = True
                    .lbl6.Visible = True
                    .lblCaption7.Visible = True
                    .lbl7.Visible = True
                    .lblCaption8.Visible = True
                    .lbl8.Visible = True
                    .lblCaption9.Visible = True
                    .lbl9.Visible = True
                    .lblCaption9.Borders = DevExpress.XtraPrinting.BorderSide.All
                    .lbl9.Borders = DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Right
                ElseIf Columns = 10 Then
                    .lblDate_C.SizeF = New Size(70 + 30, 35)
                    .lblDate.SizeF = New Size(70 + 30, 20)
                    .lblDocumentNumber_C.SizeF = New Size(85 + 30, 35)
                    .lblDocumentNumber.SizeF = New Size(85 + 30, 20)
                    .lblParticulars_C.SizeF = New Size(135 + 300, 35)
                    .lblParticulars.SizeF = New Size(135 + 300, 20)
                    .lblAmount_C.SizeF = New Size(60 + 40, 35)
                    .lblAmount.SizeF = New Size(60 + 40, 20)
                    .lblCaption1.SizeF = New Size(45 + 5, 35)
                    .lbl1.SizeF = New Size(45 + 5, 20)
                    .lblCaption2.SizeF = New Size(45 + 5, 35)
                    .lbl2.SizeF = New Size(45 + 5, 20)
                    .lblCaption3.SizeF = New Size(45 + 5, 35)
                    .lbl3.SizeF = New Size(45 + 5, 20)
                    .lblCaption4.SizeF = New Size(45 + 5, 35)
                    .lbl4.SizeF = New Size(45 + 5, 20)
                    .lblCaption5.SizeF = New Size(45 + 5, 35)
                    .lbl5.SizeF = New Size(45 + 5, 20)
                    .lblCaption6.SizeF = New Size(45 + 5, 35)
                    .lbl6.SizeF = New Size(45 + 5, 20)
                    .lblCaption7.SizeF = New Size(45 + 5, 35)
                    .lbl7.SizeF = New Size(45 + 5, 20)
                    .lblCaption8.SizeF = New Size(45 + 5, 35)
                    .lbl8.SizeF = New Size(45 + 5, 20)
                    .lblCaption9.SizeF = New Size(45 + 5, 35)
                    .lbl9.SizeF = New Size(45 + 5, 20)
                    .lblCaption10.SizeF = New Size(45 + 5, 35)
                    .lbl10.SizeF = New Size(45 + 5, 20)

                    .lblDocumentNumber_C.LocationF = New Point(70 + 30, 85)
                    .lblDocumentNumber.LocationF = New Point(70 + 30, 0)
                    .lblParticulars_C.LocationF = New Point(155 + 60, 85)
                    .lblParticulars.LocationF = New Point(155 + 60, 0)
                    .lblAmount_C.LocationF = New Point(290 + 360, 85)
                    .lblAmount.LocationF = New Point(290 + 360, 0)
                    .lblCaption1.LocationF = New Point(350 + 400, 85)
                    .lbl1.LocationF = New Point(350 + 400, 0)
                    .lblCaption2.LocationF = New Point(395 + 405, 85)
                    .lbl2.LocationF = New Point(395 + 405, 0)
                    .lblCaption3.LocationF = New Point(440 + 410, 85)
                    .lbl3.LocationF = New Point(440 + 410, 0)
                    .lblCaption4.LocationF = New Point(485 + 415, 85)
                    .lbl4.LocationF = New Point(485 + 415, 0)
                    .lblCaption5.LocationF = New Point(530 + 420, 85)
                    .lbl5.LocationF = New Point(530 + 420, 0)
                    .lblCaption6.LocationF = New Point(575 + 425, 85)
                    .lbl6.LocationF = New Point(575 + 425, 0)
                    .lblCaption7.LocationF = New Point(620 + 430, 85)
                    .lbl7.LocationF = New Point(620 + 430, 0)
                    .lblCaption8.LocationF = New Point(665 + 435, 85)
                    .lbl8.LocationF = New Point(665 + 435, 0)
                    .lblCaption9.LocationF = New Point(710 + 440, 85)
                    .lbl9.LocationF = New Point(710 + 440, 0)
                    .lblCaption10.LocationF = New Point(755 + 445, 85)
                    .lbl10.LocationF = New Point(755 + 445, 0)

                    .lblCaption5.Visible = True
                    .lbl5.Visible = True
                    .lblCaption6.Visible = True
                    .lbl6.Visible = True
                    .lblCaption7.Visible = True
                    .lbl7.Visible = True
                    .lblCaption8.Visible = True
                    .lbl8.Visible = True
                    .lblCaption9.Visible = True
                    .lbl9.Visible = True
                    .lblCaption10.Visible = True
                    .lbl10.Visible = True
                    .lblCaption10.Borders = DevExpress.XtraPrinting.BorderSide.All
                    .lbl10.Borders = DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Right
                ElseIf Columns = 11 Then
                    .lblDate_C.SizeF = New Size(70 + 30, 35)
                    .lblDate.SizeF = New Size(70 + 30, 20)
                    .lblDocumentNumber_C.SizeF = New Size(85 + 30, 35)
                    .lblDocumentNumber.SizeF = New Size(85 + 30, 20)
                    .lblParticulars_C.SizeF = New Size(135 + 250, 35)
                    .lblParticulars.SizeF = New Size(135 + 250, 20)
                    .lblAmount_C.SizeF = New Size(60 + 40, 35)
                    .lblAmount.SizeF = New Size(60 + 40, 20)
                    .lblCaption1.SizeF = New Size(45 + 5, 35)
                    .lbl1.SizeF = New Size(45 + 5, 20)
                    .lblCaption2.SizeF = New Size(45 + 5, 35)
                    .lbl2.SizeF = New Size(45 + 5, 20)
                    .lblCaption3.SizeF = New Size(45 + 5, 35)
                    .lbl3.SizeF = New Size(45 + 5, 20)
                    .lblCaption4.SizeF = New Size(45 + 5, 35)
                    .lbl4.SizeF = New Size(45 + 5, 20)
                    .lblCaption5.SizeF = New Size(45 + 5, 35)
                    .lbl5.SizeF = New Size(45 + 5, 20)
                    .lblCaption6.SizeF = New Size(45 + 5, 35)
                    .lbl6.SizeF = New Size(45 + 5, 20)
                    .lblCaption7.SizeF = New Size(45 + 5, 35)
                    .lbl7.SizeF = New Size(45 + 5, 20)
                    .lblCaption8.SizeF = New Size(45 + 5, 35)
                    .lbl8.SizeF = New Size(45 + 5, 20)
                    .lblCaption9.SizeF = New Size(45 + 5, 35)
                    .lbl9.SizeF = New Size(45 + 5, 20)
                    .lblCaption10.SizeF = New Size(45 + 5, 35)
                    .lbl10.SizeF = New Size(45 + 5, 20)
                    .lblCaption11.SizeF = New Size(45 + 5, 35)
                    .lbl11.SizeF = New Size(45 + 5, 20)

                    .lblDocumentNumber_C.LocationF = New Point(70 + 30, 85)
                    .lblDocumentNumber.LocationF = New Point(70 + 30, 0)
                    .lblParticulars_C.LocationF = New Point(155 + 60, 85)
                    .lblParticulars.LocationF = New Point(155 + 60, 0)
                    .lblAmount_C.LocationF = New Point(290 + 310, 85)
                    .lblAmount.LocationF = New Point(290 + 310, 0)
                    .lblCaption1.LocationF = New Point(350 + 350, 85)
                    .lbl1.LocationF = New Point(350 + 350, 0)
                    .lblCaption2.LocationF = New Point(395 + 355, 85)
                    .lbl2.LocationF = New Point(395 + 355, 0)
                    .lblCaption3.LocationF = New Point(440 + 360, 85)
                    .lbl3.LocationF = New Point(440 + 360, 0)
                    .lblCaption4.LocationF = New Point(485 + 365, 85)
                    .lbl4.LocationF = New Point(485 + 365, 0)
                    .lblCaption5.LocationF = New Point(530 + 370, 85)
                    .lbl5.LocationF = New Point(530 + 370, 0)
                    .lblCaption6.LocationF = New Point(575 + 375, 85)
                    .lbl6.LocationF = New Point(575 + 375, 0)
                    .lblCaption7.LocationF = New Point(620 + 380, 85)
                    .lbl7.LocationF = New Point(620 + 380, 0)
                    .lblCaption8.LocationF = New Point(665 + 385, 85)
                    .lbl8.LocationF = New Point(665 + 385, 0)
                    .lblCaption9.LocationF = New Point(710 + 390, 85)
                    .lbl9.LocationF = New Point(710 + 390, 0)
                    .lblCaption10.LocationF = New Point(755 + 395, 85)
                    .lbl10.LocationF = New Point(755 + 395, 0)
                    .lblCaption11.LocationF = New Point(800 + 400, 85)
                    .lbl11.LocationF = New Point(800 + 400, 0)

                    .lblCaption5.Visible = True
                    .lbl5.Visible = True
                    .lblCaption6.Visible = True
                    .lbl6.Visible = True
                    .lblCaption7.Visible = True
                    .lbl7.Visible = True
                    .lblCaption8.Visible = True
                    .lbl8.Visible = True
                    .lblCaption9.Visible = True
                    .lbl9.Visible = True
                    .lblCaption10.Visible = True
                    .lbl10.Visible = True
                    .lblCaption11.Visible = True
                    .lbl11.Visible = True
                    .lblCaption11.Borders = DevExpress.XtraPrinting.BorderSide.All
                    .lbl11.Borders = DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Right
                ElseIf Columns = 12 Then
                    .lblDate_C.SizeF = New Size(70 + 30, 35)
                    .lblDate.SizeF = New Size(70 + 30, 20)
                    .lblDocumentNumber_C.SizeF = New Size(85 + 30, 35)
                    .lblDocumentNumber.SizeF = New Size(85 + 30, 20)
                    .lblParticulars_C.SizeF = New Size(135 + 200, 35)
                    .lblParticulars.SizeF = New Size(135 + 200, 20)
                    .lblAmount_C.SizeF = New Size(60 + 40, 35)
                    .lblAmount.SizeF = New Size(60 + 40, 20)
                    .lblCaption1.SizeF = New Size(45 + 5, 35)
                    .lbl1.SizeF = New Size(45 + 5, 20)
                    .lblCaption2.SizeF = New Size(45 + 5, 35)
                    .lbl2.SizeF = New Size(45 + 5, 20)
                    .lblCaption3.SizeF = New Size(45 + 5, 35)
                    .lbl3.SizeF = New Size(45 + 5, 20)
                    .lblCaption4.SizeF = New Size(45 + 5, 35)
                    .lbl4.SizeF = New Size(45 + 5, 20)
                    .lblCaption5.SizeF = New Size(45 + 5, 35)
                    .lbl5.SizeF = New Size(45 + 5, 20)
                    .lblCaption6.SizeF = New Size(45 + 5, 35)
                    .lbl6.SizeF = New Size(45 + 5, 20)
                    .lblCaption7.SizeF = New Size(45 + 5, 35)
                    .lbl7.SizeF = New Size(45 + 5, 20)
                    .lblCaption8.SizeF = New Size(45 + 5, 35)
                    .lbl8.SizeF = New Size(45 + 5, 20)
                    .lblCaption9.SizeF = New Size(45 + 5, 35)
                    .lbl9.SizeF = New Size(45 + 5, 20)
                    .lblCaption10.SizeF = New Size(45 + 5, 35)
                    .lbl10.SizeF = New Size(45 + 5, 20)
                    .lblCaption11.SizeF = New Size(45 + 5, 35)
                    .lbl11.SizeF = New Size(45 + 5, 20)
                    .lblCaption12.SizeF = New Size(45 + 5, 35)
                    .lbl12.SizeF = New Size(45 + 5, 20)

                    .lblDocumentNumber_C.LocationF = New Point(70 + 30, 85)
                    .lblDocumentNumber.LocationF = New Point(70 + 30, 0)
                    .lblParticulars_C.LocationF = New Point(155 + 60, 85)
                    .lblParticulars.LocationF = New Point(155 + 60, 0)
                    .lblAmount_C.LocationF = New Point(290 + 260, 85)
                    .lblAmount.LocationF = New Point(290 + 260, 0)
                    .lblCaption1.LocationF = New Point(350 + 300, 85)
                    .lbl1.LocationF = New Point(350 + 300, 0)
                    .lblCaption2.LocationF = New Point(395 + 305, 85)
                    .lbl2.LocationF = New Point(395 + 305, 0)
                    .lblCaption3.LocationF = New Point(440 + 310, 85)
                    .lbl3.LocationF = New Point(440 + 310, 0)
                    .lblCaption4.LocationF = New Point(485 + 315, 85)
                    .lbl4.LocationF = New Point(485 + 315, 0)
                    .lblCaption5.LocationF = New Point(530 + 320, 85)
                    .lbl5.LocationF = New Point(530 + 320, 0)
                    .lblCaption6.LocationF = New Point(575 + 325, 85)
                    .lbl6.LocationF = New Point(575 + 325, 0)
                    .lblCaption7.LocationF = New Point(620 + 330, 85)
                    .lbl7.LocationF = New Point(620 + 330, 0)
                    .lblCaption8.LocationF = New Point(665 + 335, 85)
                    .lbl8.LocationF = New Point(665 + 335, 0)
                    .lblCaption9.LocationF = New Point(710 + 340, 85)
                    .lbl9.LocationF = New Point(710 + 340, 0)
                    .lblCaption10.LocationF = New Point(755 + 345, 85)
                    .lbl10.LocationF = New Point(755 + 345, 0)
                    .lblCaption11.LocationF = New Point(800 + 350, 85)
                    .lbl11.LocationF = New Point(800 + 350, 0)
                    .lblCaption12.LocationF = New Point(845 + 355, 85)
                    .lbl12.LocationF = New Point(845 + 355, 0)

                    .lblCaption5.Visible = True
                    .lbl5.Visible = True
                    .lblCaption6.Visible = True
                    .lbl6.Visible = True
                    .lblCaption7.Visible = True
                    .lbl7.Visible = True
                    .lblCaption8.Visible = True
                    .lbl8.Visible = True
                    .lblCaption9.Visible = True
                    .lbl9.Visible = True
                    .lblCaption10.Visible = True
                    .lbl10.Visible = True
                    .lblCaption11.Visible = True
                    .lbl11.Visible = True
                    .lblCaption12.Visible = True
                    .lbl12.Visible = True
                    .lblCaption12.Borders = DevExpress.XtraPrinting.BorderSide.All
                    .lbl12.Borders = DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Right
                ElseIf Columns = 13 Then
                    .lblDate_C.SizeF = New Size(70 + 30, 35)
                    .lblDate.SizeF = New Size(70 + 30, 20)
                    .lblDocumentNumber_C.SizeF = New Size(85 + 30, 35)
                    .lblDocumentNumber.SizeF = New Size(85 + 30, 20)
                    .lblParticulars_C.SizeF = New Size(135 + 150, 35)
                    .lblParticulars.SizeF = New Size(135 + 150, 20)
                    .lblAmount_C.SizeF = New Size(60 + 40, 35)
                    .lblAmount.SizeF = New Size(60 + 40, 20)
                    .lblCaption1.SizeF = New Size(45 + 5, 35)
                    .lbl1.SizeF = New Size(45 + 5, 20)
                    .lblCaption2.SizeF = New Size(45 + 5, 35)
                    .lbl2.SizeF = New Size(45 + 5, 20)
                    .lblCaption3.SizeF = New Size(45 + 5, 35)
                    .lbl3.SizeF = New Size(45 + 5, 20)
                    .lblCaption4.SizeF = New Size(45 + 5, 35)
                    .lbl4.SizeF = New Size(45 + 5, 20)
                    .lblCaption5.SizeF = New Size(45 + 5, 35)
                    .lbl5.SizeF = New Size(45 + 5, 20)
                    .lblCaption6.SizeF = New Size(45 + 5, 35)
                    .lbl6.SizeF = New Size(45 + 5, 20)
                    .lblCaption7.SizeF = New Size(45 + 5, 35)
                    .lbl7.SizeF = New Size(45 + 5, 20)
                    .lblCaption8.SizeF = New Size(45 + 5, 35)
                    .lbl8.SizeF = New Size(45 + 5, 20)
                    .lblCaption9.SizeF = New Size(45 + 5, 35)
                    .lbl9.SizeF = New Size(45 + 5, 20)
                    .lblCaption10.SizeF = New Size(45 + 5, 35)
                    .lbl10.SizeF = New Size(45 + 5, 20)
                    .lblCaption11.SizeF = New Size(45 + 5, 35)
                    .lbl11.SizeF = New Size(45 + 5, 20)
                    .lblCaption12.SizeF = New Size(45 + 5, 35)
                    .lbl12.SizeF = New Size(45 + 5, 20)
                    .lblCaption13.SizeF = New Size(45 + 5, 35)
                    .lbl13.SizeF = New Size(45 + 5, 20)

                    .lblDocumentNumber_C.LocationF = New Point(70 + 30, 85)
                    .lblDocumentNumber.LocationF = New Point(70 + 30, 0)
                    .lblParticulars_C.LocationF = New Point(155 + 60, 85)
                    .lblParticulars.LocationF = New Point(155 + 60, 0)
                    .lblAmount_C.LocationF = New Point(290 + 210, 85)
                    .lblAmount.LocationF = New Point(290 + 210, 0)
                    .lblCaption1.LocationF = New Point(350 + 250, 85)
                    .lbl1.LocationF = New Point(350 + 250, 0)
                    .lblCaption2.LocationF = New Point(395 + 255, 85)
                    .lbl2.LocationF = New Point(395 + 255, 0)
                    .lblCaption3.LocationF = New Point(440 + 260, 85)
                    .lbl3.LocationF = New Point(440 + 260, 0)
                    .lblCaption4.LocationF = New Point(485 + 265, 85)
                    .lbl4.LocationF = New Point(485 + 265, 0)
                    .lblCaption5.LocationF = New Point(530 + 270, 85)
                    .lbl5.LocationF = New Point(530 + 270, 0)
                    .lblCaption6.LocationF = New Point(575 + 275, 85)
                    .lbl6.LocationF = New Point(575 + 275, 0)
                    .lblCaption7.LocationF = New Point(620 + 280, 85)
                    .lbl7.LocationF = New Point(620 + 280, 0)
                    .lblCaption8.LocationF = New Point(665 + 285, 85)
                    .lbl8.LocationF = New Point(665 + 285, 0)
                    .lblCaption9.LocationF = New Point(710 + 290, 85)
                    .lbl9.LocationF = New Point(710 + 290, 0)
                    .lblCaption10.LocationF = New Point(755 + 295, 85)
                    .lbl10.LocationF = New Point(755 + 295, 0)
                    .lblCaption11.LocationF = New Point(800 + 300, 85)
                    .lbl11.LocationF = New Point(800 + 300, 0)
                    .lblCaption12.LocationF = New Point(845 + 305, 85)
                    .lbl12.LocationF = New Point(845 + 305, 0)
                    .lblCaption13.LocationF = New Point(890 + 310, 85)
                    .lbl13.LocationF = New Point(890 + 310, 0)

                    .lblCaption5.Visible = True
                    .lbl5.Visible = True
                    .lblCaption6.Visible = True
                    .lbl6.Visible = True
                    .lblCaption7.Visible = True
                    .lbl7.Visible = True
                    .lblCaption8.Visible = True
                    .lbl8.Visible = True
                    .lblCaption9.Visible = True
                    .lbl9.Visible = True
                    .lblCaption10.Visible = True
                    .lbl10.Visible = True
                    .lblCaption11.Visible = True
                    .lbl11.Visible = True
                    .lblCaption12.Visible = True
                    .lbl12.Visible = True
                    .lblCaption13.Visible = True
                    .lbl13.Visible = True
                    .lblCaption13.Borders = DevExpress.XtraPrinting.BorderSide.All
                    .lbl13.Borders = DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Right
                ElseIf Columns = 14 Then
                    .lblDate_C.SizeF = New Size(70 + 30, 35)
                    .lblDate.SizeF = New Size(70 + 30, 20)
                    .lblDocumentNumber_C.SizeF = New Size(85 + 30, 35)
                    .lblDocumentNumber.SizeF = New Size(85 + 30, 20)
                    .lblParticulars_C.SizeF = New Size(135 + 100, 35)
                    .lblParticulars.SizeF = New Size(135 + 100, 20)
                    .lblAmount_C.SizeF = New Size(60 + 40, 35)
                    .lblAmount.SizeF = New Size(60 + 40, 20)
                    .lblCaption1.SizeF = New Size(45 + 5, 35)
                    .lbl1.SizeF = New Size(45 + 5, 20)
                    .lblCaption2.SizeF = New Size(45 + 5, 35)
                    .lbl2.SizeF = New Size(45 + 5, 20)
                    .lblCaption3.SizeF = New Size(45 + 5, 35)
                    .lbl3.SizeF = New Size(45 + 5, 20)
                    .lblCaption4.SizeF = New Size(45 + 5, 35)
                    .lbl4.SizeF = New Size(45 + 5, 20)
                    .lblCaption5.SizeF = New Size(45 + 5, 35)
                    .lbl5.SizeF = New Size(45 + 5, 20)
                    .lblCaption6.SizeF = New Size(45 + 5, 35)
                    .lbl6.SizeF = New Size(45 + 5, 20)
                    .lblCaption7.SizeF = New Size(45 + 5, 35)
                    .lbl7.SizeF = New Size(45 + 5, 20)
                    .lblCaption8.SizeF = New Size(45 + 5, 35)
                    .lbl8.SizeF = New Size(45 + 5, 20)
                    .lblCaption9.SizeF = New Size(45 + 5, 35)
                    .lbl9.SizeF = New Size(45 + 5, 20)
                    .lblCaption10.SizeF = New Size(45 + 5, 35)
                    .lbl10.SizeF = New Size(45 + 5, 20)
                    .lblCaption11.SizeF = New Size(45 + 5, 35)
                    .lbl11.SizeF = New Size(45 + 5, 20)
                    .lblCaption12.SizeF = New Size(45 + 5, 35)
                    .lbl12.SizeF = New Size(45 + 5, 20)
                    .lblCaption13.SizeF = New Size(45 + 5, 35)
                    .lbl13.SizeF = New Size(45 + 5, 20)
                    .lblCaption14.SizeF = New Size(45 + 5, 35)
                    .lbl14.SizeF = New Size(45 + 5, 20)

                    .lblDocumentNumber_C.LocationF = New Point(70 + 30, 85)
                    .lblDocumentNumber.LocationF = New Point(70 + 30, 0)
                    .lblParticulars_C.LocationF = New Point(155 + 60, 85)
                    .lblParticulars.LocationF = New Point(155 + 60, 0)
                    .lblAmount_C.LocationF = New Point(290 + 160, 85)
                    .lblAmount.LocationF = New Point(290 + 160, 0)
                    .lblCaption1.LocationF = New Point(350 + 200, 85)
                    .lbl1.LocationF = New Point(350 + 200, 0)
                    .lblCaption2.LocationF = New Point(395 + 205, 85)
                    .lbl2.LocationF = New Point(395 + 205, 0)
                    .lblCaption3.LocationF = New Point(440 + 210, 85)
                    .lbl3.LocationF = New Point(440 + 210, 0)
                    .lblCaption4.LocationF = New Point(485 + 215, 85)
                    .lbl4.LocationF = New Point(485 + 215, 0)
                    .lblCaption5.LocationF = New Point(530 + 220, 85)
                    .lbl5.LocationF = New Point(530 + 220, 0)
                    .lblCaption6.LocationF = New Point(575 + 225, 85)
                    .lbl6.LocationF = New Point(575 + 225, 0)
                    .lblCaption7.LocationF = New Point(620 + 230, 85)
                    .lbl7.LocationF = New Point(620 + 230, 0)
                    .lblCaption8.LocationF = New Point(665 + 235, 85)
                    .lbl8.LocationF = New Point(665 + 235, 0)
                    .lblCaption9.LocationF = New Point(710 + 240, 85)
                    .lbl9.LocationF = New Point(710 + 240, 0)
                    .lblCaption10.LocationF = New Point(755 + 245, 85)
                    .lbl10.LocationF = New Point(755 + 245, 0)
                    .lblCaption11.LocationF = New Point(800 + 250, 85)
                    .lbl11.LocationF = New Point(800 + 250, 0)
                    .lblCaption12.LocationF = New Point(845 + 255, 85)
                    .lbl12.LocationF = New Point(845 + 255, 0)
                    .lblCaption13.LocationF = New Point(890 + 260, 85)
                    .lbl13.LocationF = New Point(890 + 260, 0)
                    .lblCaption14.LocationF = New Point(935 + 265, 85)
                    .lbl14.LocationF = New Point(935 + 265, 0)

                    .lblCaption5.Visible = True
                    .lbl5.Visible = True
                    .lblCaption6.Visible = True
                    .lbl6.Visible = True
                    .lblCaption7.Visible = True
                    .lbl7.Visible = True
                    .lblCaption8.Visible = True
                    .lbl8.Visible = True
                    .lblCaption9.Visible = True
                    .lbl9.Visible = True
                    .lblCaption10.Visible = True
                    .lbl10.Visible = True
                    .lblCaption11.Visible = True
                    .lbl11.Visible = True
                    .lblCaption12.Visible = True
                    .lbl12.Visible = True
                    .lblCaption13.Visible = True
                    .lbl13.Visible = True
                    .lblCaption14.Visible = True
                    .lbl14.Visible = True
                    .lblCaption14.Borders = DevExpress.XtraPrinting.BorderSide.All
                    .lbl14.Borders = DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Right
                ElseIf Columns = 15 Then
                    .lblDate_C.SizeF = New Size(70 + 30, 35)
                    .lblDate.SizeF = New Size(70 + 30, 20)
                    .lblDocumentNumber_C.SizeF = New Size(85 + 30, 35)
                    .lblDocumentNumber.SizeF = New Size(85 + 30, 20)
                    .lblParticulars_C.SizeF = New Size(135 + 50, 35)
                    .lblParticulars.SizeF = New Size(135 + 50, 20)
                    .lblAmount_C.SizeF = New Size(60 + 40, 35)
                    .lblAmount.SizeF = New Size(60 + 40, 20)
                    .lblCaption1.SizeF = New Size(45 + 5, 35)
                    .lbl1.SizeF = New Size(45 + 5, 20)
                    .lblCaption2.SizeF = New Size(45 + 5, 35)
                    .lbl2.SizeF = New Size(45 + 5, 20)
                    .lblCaption3.SizeF = New Size(45 + 5, 35)
                    .lbl3.SizeF = New Size(45 + 5, 20)
                    .lblCaption4.SizeF = New Size(45 + 5, 35)
                    .lbl4.SizeF = New Size(45 + 5, 20)
                    .lblCaption5.SizeF = New Size(45 + 5, 35)
                    .lbl5.SizeF = New Size(45 + 5, 20)
                    .lblCaption6.SizeF = New Size(45 + 5, 35)
                    .lbl6.SizeF = New Size(45 + 5, 20)
                    .lblCaption7.SizeF = New Size(45 + 5, 35)
                    .lbl7.SizeF = New Size(45 + 5, 20)
                    .lblCaption8.SizeF = New Size(45 + 5, 35)
                    .lbl8.SizeF = New Size(45 + 5, 20)
                    .lblCaption9.SizeF = New Size(45 + 5, 35)
                    .lbl9.SizeF = New Size(45 + 5, 20)
                    .lblCaption10.SizeF = New Size(45 + 5, 35)
                    .lbl10.SizeF = New Size(45 + 5, 20)
                    .lblCaption11.SizeF = New Size(45 + 5, 35)
                    .lbl11.SizeF = New Size(45 + 5, 20)
                    .lblCaption12.SizeF = New Size(45 + 5, 35)
                    .lbl12.SizeF = New Size(45 + 5, 20)
                    .lblCaption13.SizeF = New Size(45 + 5, 35)
                    .lbl13.SizeF = New Size(45 + 5, 20)
                    .lblCaption14.SizeF = New Size(45 + 5, 35)
                    .lbl14.SizeF = New Size(45 + 5, 20)
                    .lblCaption15.SizeF = New Size(45 + 5, 35)
                    .lbl15.SizeF = New Size(45 + 5, 20)

                    .lblDocumentNumber_C.LocationF = New Point(70 + 30, 85)
                    .lblDocumentNumber.LocationF = New Point(70 + 30, 0)
                    .lblParticulars_C.LocationF = New Point(155 + 60, 85)
                    .lblParticulars.LocationF = New Point(155 + 60, 0)
                    .lblAmount_C.LocationF = New Point(290 + 110, 85)
                    .lblAmount.LocationF = New Point(290 + 110, 0)
                    .lblCaption1.LocationF = New Point(350 + 150, 85)
                    .lbl1.LocationF = New Point(350 + 150, 0)
                    .lblCaption2.LocationF = New Point(395 + 155, 85)
                    .lbl2.LocationF = New Point(395 + 155, 0)
                    .lblCaption3.LocationF = New Point(440 + 160, 85)
                    .lbl3.LocationF = New Point(440 + 160, 0)
                    .lblCaption4.LocationF = New Point(485 + 165, 85)
                    .lbl4.LocationF = New Point(485 + 165, 0)
                    .lblCaption5.LocationF = New Point(530 + 170, 85)
                    .lbl5.LocationF = New Point(530 + 170, 0)
                    .lblCaption6.LocationF = New Point(575 + 175, 85)
                    .lbl6.LocationF = New Point(575 + 175, 0)
                    .lblCaption7.LocationF = New Point(620 + 180, 85)
                    .lbl7.LocationF = New Point(620 + 180, 0)
                    .lblCaption8.LocationF = New Point(665 + 185, 85)
                    .lbl8.LocationF = New Point(665 + 185, 0)
                    .lblCaption9.LocationF = New Point(710 + 190, 85)
                    .lbl9.LocationF = New Point(710 + 190, 0)
                    .lblCaption10.LocationF = New Point(755 + 195, 85)
                    .lbl10.LocationF = New Point(755 + 195, 0)
                    .lblCaption11.LocationF = New Point(800 + 200, 85)
                    .lbl11.LocationF = New Point(800 + 200, 0)
                    .lblCaption12.LocationF = New Point(845 + 205, 85)
                    .lbl12.LocationF = New Point(845 + 205, 0)
                    .lblCaption13.LocationF = New Point(890 + 210, 85)
                    .lbl13.LocationF = New Point(890 + 210, 0)
                    .lblCaption14.LocationF = New Point(935 + 215, 85)
                    .lbl14.LocationF = New Point(935 + 215, 0)
                    .lblCaption15.LocationF = New Point(980 + 220, 85)
                    .lbl15.LocationF = New Point(980 + 220, 0)

                    .lblCaption5.Visible = True
                    .lbl5.Visible = True
                    .lblCaption6.Visible = True
                    .lbl6.Visible = True
                    .lblCaption7.Visible = True
                    .lbl7.Visible = True
                    .lblCaption8.Visible = True
                    .lbl8.Visible = True
                    .lblCaption9.Visible = True
                    .lbl9.Visible = True
                    .lblCaption10.Visible = True
                    .lbl10.Visible = True
                    .lblCaption11.Visible = True
                    .lbl11.Visible = True
                    .lblCaption12.Visible = True
                    .lbl12.Visible = True
                    .lblCaption13.Visible = True
                    .lbl13.Visible = True
                    .lblCaption14.Visible = True
                    .lbl14.Visible = True
                    .lblCaption15.Visible = True
                    .lbl15.Visible = True
                    .lblCaption15.Borders = DevExpress.XtraPrinting.BorderSide.All
                    .lbl15.Borders = DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Right
                ElseIf Columns = 16 Then
                    .lblDate_C.SizeF = New Size(70 + 30, 35)
                    .lblDate.SizeF = New Size(70 + 30, 20)
                    .lblDocumentNumber_C.SizeF = New Size(85 + 30, 35)
                    .lblDocumentNumber.SizeF = New Size(85 + 30, 20)
                    .lblParticulars_C.SizeF = New Size(135, 35)
                    .lblParticulars.SizeF = New Size(135, 20)
                    .lblAmount_C.SizeF = New Size(60 + 40, 35)
                    .lblAmount.SizeF = New Size(60 + 40, 20)
                    .lblCaption1.SizeF = New Size(45 + 5, 35)
                    .lbl1.SizeF = New Size(45 + 5, 20)
                    .lblCaption2.SizeF = New Size(45 + 5, 35)
                    .lbl2.SizeF = New Size(45 + 5, 20)
                    .lblCaption3.SizeF = New Size(45 + 5, 35)
                    .lbl3.SizeF = New Size(45 + 5, 20)
                    .lblCaption4.SizeF = New Size(45 + 5, 35)
                    .lbl4.SizeF = New Size(45 + 5, 20)
                    .lblCaption5.SizeF = New Size(45 + 5, 35)
                    .lbl5.SizeF = New Size(45 + 5, 20)
                    .lblCaption6.SizeF = New Size(45 + 5, 35)
                    .lbl6.SizeF = New Size(45 + 5, 20)
                    .lblCaption7.SizeF = New Size(45 + 5, 35)
                    .lbl7.SizeF = New Size(45 + 5, 20)
                    .lblCaption8.SizeF = New Size(45 + 5, 35)
                    .lbl8.SizeF = New Size(45 + 5, 20)
                    .lblCaption9.SizeF = New Size(45 + 5, 35)
                    .lbl9.SizeF = New Size(45 + 5, 20)
                    .lblCaption10.SizeF = New Size(45 + 5, 35)
                    .lbl10.SizeF = New Size(45 + 5, 20)
                    .lblCaption11.SizeF = New Size(45 + 5, 35)
                    .lbl11.SizeF = New Size(45 + 5, 20)
                    .lblCaption12.SizeF = New Size(45 + 5, 35)
                    .lbl12.SizeF = New Size(45 + 5, 20)
                    .lblCaption13.SizeF = New Size(45 + 5, 35)
                    .lbl13.SizeF = New Size(45 + 5, 20)
                    .lblCaption14.SizeF = New Size(45 + 5, 35)
                    .lbl14.SizeF = New Size(45 + 5, 20)
                    .lblCaption15.SizeF = New Size(45 + 5, 35)
                    .lbl15.SizeF = New Size(45 + 5, 20)
                    .lblCaption16.SizeF = New Size(45 + 5, 35)
                    .lbl16.SizeF = New Size(45 + 5, 20)

                    .lblDocumentNumber_C.LocationF = New Point(70 + 30, 85)
                    .lblDocumentNumber.LocationF = New Point(70 + 30, 0)
                    .lblParticulars_C.LocationF = New Point(155 + 60, 85)
                    .lblParticulars.LocationF = New Point(155 + 60, 0)
                    .lblAmount_C.LocationF = New Point(290 + 60, 85)
                    .lblAmount.LocationF = New Point(290 + 60, 0)
                    .lblCaption1.LocationF = New Point(350 + 100, 85)
                    .lbl1.LocationF = New Point(350 + 100, 0)
                    .lblCaption2.LocationF = New Point(395 + 105, 85)
                    .lbl2.LocationF = New Point(395 + 105, 0)
                    .lblCaption3.LocationF = New Point(440 + 110, 85)
                    .lbl3.LocationF = New Point(440 + 110, 0)
                    .lblCaption4.LocationF = New Point(485 + 115, 85)
                    .lbl4.LocationF = New Point(485 + 115, 0)
                    .lblCaption5.LocationF = New Point(530 + 120, 85)
                    .lbl5.LocationF = New Point(530 + 120, 0)
                    .lblCaption6.LocationF = New Point(575 + 125, 85)
                    .lbl6.LocationF = New Point(575 + 125, 0)
                    .lblCaption7.LocationF = New Point(620 + 130, 85)
                    .lbl7.LocationF = New Point(620 + 130, 0)
                    .lblCaption8.LocationF = New Point(665 + 135, 85)
                    .lbl8.LocationF = New Point(665 + 135, 0)
                    .lblCaption9.LocationF = New Point(710 + 140, 85)
                    .lbl9.LocationF = New Point(710 + 140, 0)
                    .lblCaption10.LocationF = New Point(755 + 145, 85)
                    .lbl10.LocationF = New Point(755 + 145, 0)
                    .lblCaption11.LocationF = New Point(800 + 150, 85)
                    .lbl11.LocationF = New Point(800 + 150, 0)
                    .lblCaption12.LocationF = New Point(845 + 155, 85)
                    .lbl12.LocationF = New Point(845 + 155, 0)
                    .lblCaption13.LocationF = New Point(890 + 160, 85)
                    .lbl13.LocationF = New Point(890 + 160, 0)
                    .lblCaption14.LocationF = New Point(935 + 165, 85)
                    .lbl14.LocationF = New Point(935 + 165, 0)
                    .lblCaption15.LocationF = New Point(980 + 170, 85)
                    .lbl15.LocationF = New Point(980 + 170, 0)
                    .lblCaption16.LocationF = New Point(1025 + 175, 85)
                    .lbl16.LocationF = New Point(1025 + 175, 0)

                    .lblCaption5.Visible = True
                    .lbl5.Visible = True
                    .lblCaption6.Visible = True
                    .lbl6.Visible = True
                    .lblCaption7.Visible = True
                    .lbl7.Visible = True
                    .lblCaption8.Visible = True
                    .lbl8.Visible = True
                    .lblCaption9.Visible = True
                    .lbl9.Visible = True
                    .lblCaption10.Visible = True
                    .lbl10.Visible = True
                    .lblCaption11.Visible = True
                    .lbl11.Visible = True
                    .lblCaption12.Visible = True
                    .lbl12.Visible = True
                    .lblCaption13.Visible = True
                    .lbl13.Visible = True
                    .lblCaption14.Visible = True
                    .lbl14.Visible = True
                    .lblCaption15.Visible = True
                    .lbl15.Visible = True
                    .lblCaption16.Visible = True
                    .lbl16.Visible = True
                    .lblCaption16.Borders = DevExpress.XtraPrinting.BorderSide.All
                    .lbl16.Borders = DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Right
                ElseIf Columns = 17 Then
                    .lblDate_C.SizeF = New Size(70 + 20, 35)
                    .lblDate.SizeF = New Size(70 + 20, 20)
                    .lblDocumentNumber_C.SizeF = New Size(85 + 20, 35)
                    .lblDocumentNumber.SizeF = New Size(85 + 20, 20)
                    .lblParticulars_C.SizeF = New Size(135, 35)
                    .lblParticulars.SizeF = New Size(135, 20)
                    .lblAmount_C.SizeF = New Size(60 + 10, 35)
                    .lblAmount.SizeF = New Size(60 + 10, 20)
                    .lblCaption1.SizeF = New Size(45 + 5, 35)
                    .lbl1.SizeF = New Size(45 + 5, 20)
                    .lblCaption2.SizeF = New Size(45 + 5, 35)
                    .lbl2.SizeF = New Size(45 + 5, 20)
                    .lblCaption3.SizeF = New Size(45 + 5, 35)
                    .lbl3.SizeF = New Size(45 + 5, 20)
                    .lblCaption4.SizeF = New Size(45 + 5, 35)
                    .lbl4.SizeF = New Size(45 + 5, 20)
                    .lblCaption5.SizeF = New Size(45 + 5, 35)
                    .lbl5.SizeF = New Size(45 + 5, 20)
                    .lblCaption6.SizeF = New Size(45 + 5, 35)
                    .lbl6.SizeF = New Size(45 + 5, 20)
                    .lblCaption7.SizeF = New Size(45 + 5, 35)
                    .lbl7.SizeF = New Size(45 + 5, 20)
                    .lblCaption8.SizeF = New Size(45 + 5, 35)
                    .lbl8.SizeF = New Size(45 + 5, 20)
                    .lblCaption9.SizeF = New Size(45 + 5, 35)
                    .lbl9.SizeF = New Size(45 + 5, 20)
                    .lblCaption10.SizeF = New Size(45 + 5, 35)
                    .lbl10.SizeF = New Size(45 + 5, 20)
                    .lblCaption11.SizeF = New Size(45 + 5, 35)
                    .lbl11.SizeF = New Size(45 + 5, 20)
                    .lblCaption12.SizeF = New Size(45 + 5, 35)
                    .lbl12.SizeF = New Size(45 + 5, 20)
                    .lblCaption13.SizeF = New Size(45 + 5, 35)
                    .lbl13.SizeF = New Size(45 + 5, 20)
                    .lblCaption14.SizeF = New Size(45 + 5, 35)
                    .lbl14.SizeF = New Size(45 + 5, 20)
                    .lblCaption15.SizeF = New Size(45 + 5, 35)
                    .lbl15.SizeF = New Size(45 + 5, 20)
                    .lblCaption16.SizeF = New Size(45 + 5, 35)
                    .lbl16.SizeF = New Size(45 + 5, 20)
                    .lblCaption17.SizeF = New Size(45 + 5, 35)
                    .lbl17.SizeF = New Size(45 + 5, 20)

                    .lblDocumentNumber_C.LocationF = New Point(70 + 20, 85)
                    .lblDocumentNumber.LocationF = New Point(70 + 20, 0)
                    .lblParticulars_C.LocationF = New Point(155 + 40, 85)
                    .lblParticulars.LocationF = New Point(155 + 40, 0)
                    .lblAmount_C.LocationF = New Point(290 + 40, 85)
                    .lblAmount.LocationF = New Point(290 + 40, 0)
                    .lblCaption1.LocationF = New Point(350 + 50, 85)
                    .lbl1.LocationF = New Point(350 + 50, 0)
                    .lblCaption2.LocationF = New Point(395 + 55, 85)
                    .lbl2.LocationF = New Point(395 + 55, 0)
                    .lblCaption3.LocationF = New Point(440 + 60, 85)
                    .lbl3.LocationF = New Point(440 + 60, 0)
                    .lblCaption4.LocationF = New Point(485 + 65, 85)
                    .lbl4.LocationF = New Point(485 + 65, 0)
                    .lblCaption5.LocationF = New Point(530 + 70, 85)
                    .lbl5.LocationF = New Point(530 + 70, 0)
                    .lblCaption6.LocationF = New Point(575 + 75, 85)
                    .lbl6.LocationF = New Point(575 + 75, 0)
                    .lblCaption7.LocationF = New Point(620 + 80, 85)
                    .lbl7.LocationF = New Point(620 + 80, 0)
                    .lblCaption8.LocationF = New Point(665 + 85, 85)
                    .lbl8.LocationF = New Point(665 + 85, 0)
                    .lblCaption9.LocationF = New Point(710 + 90, 85)
                    .lbl9.LocationF = New Point(710 + 90, 0)
                    .lblCaption10.LocationF = New Point(755 + 95, 85)
                    .lbl10.LocationF = New Point(755 + 95, 0)
                    .lblCaption11.LocationF = New Point(800 + 100, 85)
                    .lbl11.LocationF = New Point(800 + 100, 0)
                    .lblCaption12.LocationF = New Point(845 + 105, 85)
                    .lbl12.LocationF = New Point(845 + 105, 0)
                    .lblCaption13.LocationF = New Point(890 + 110, 85)
                    .lbl13.LocationF = New Point(890 + 110, 0)
                    .lblCaption14.LocationF = New Point(935 + 115, 85)
                    .lbl14.LocationF = New Point(935 + 115, 0)
                    .lblCaption15.LocationF = New Point(980 + 120, 85)
                    .lbl15.LocationF = New Point(980 + 120, 0)
                    .lblCaption16.LocationF = New Point(1025 + 125, 85)
                    .lbl16.LocationF = New Point(1025 + 125, 0)
                    .lblCaption17.LocationF = New Point(1070 + 130, 85)
                    .lbl17.LocationF = New Point(1070 + 130, 0)

                    .lblCaption5.Visible = True
                    .lbl5.Visible = True
                    .lblCaption6.Visible = True
                    .lbl6.Visible = True
                    .lblCaption7.Visible = True
                    .lbl7.Visible = True
                    .lblCaption8.Visible = True
                    .lbl8.Visible = True
                    .lblCaption9.Visible = True
                    .lbl9.Visible = True
                    .lblCaption10.Visible = True
                    .lbl10.Visible = True
                    .lblCaption11.Visible = True
                    .lbl11.Visible = True
                    .lblCaption12.Visible = True
                    .lbl12.Visible = True
                    .lblCaption13.Visible = True
                    .lbl13.Visible = True
                    .lblCaption14.Visible = True
                    .lbl14.Visible = True
                    .lblCaption15.Visible = True
                    .lbl15.Visible = True
                    .lblCaption16.Visible = True
                    .lbl16.Visible = True
                    .lblCaption17.Visible = True
                    .lbl17.Visible = True
                    .lblCaption17.Borders = DevExpress.XtraPrinting.BorderSide.All
                    .lbl17.Borders = DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Right
                ElseIf Columns = 18 Then
                    .lblParticulars_C.SizeF = New Size(135 + 90, 35)
                    .lblParticulars.SizeF = New Size(135 + 90, 20)

                    .lblAmount_C.LocationF = New Point(290 + 90, 85)
                    .lblAmount.LocationF = New Point(290 + 90, 0)
                    .lblCaption1.LocationF = New Point(350 + 90, 85)
                    .lbl1.LocationF = New Point(350 + 90, 0)
                    .lblCaption2.LocationF = New Point(395 + 90, 85)
                    .lbl2.LocationF = New Point(395 + 90, 0)
                    .lblCaption3.LocationF = New Point(440 + 90, 85)
                    .lbl3.LocationF = New Point(440 + 90, 0)
                    .lblCaption4.LocationF = New Point(485 + 90, 85)
                    .lbl4.LocationF = New Point(485 + 90, 0)
                    .lblCaption5.LocationF = New Point(530 + 90, 85)
                    .lbl5.LocationF = New Point(530 + 90, 0)
                    .lblCaption6.LocationF = New Point(575 + 90, 85)
                    .lbl6.LocationF = New Point(575 + 90, 0)
                    .lblCaption7.LocationF = New Point(620 + 90, 85)
                    .lbl7.LocationF = New Point(620 + 90, 0)
                    .lblCaption8.LocationF = New Point(665 + 90, 85)
                    .lbl8.LocationF = New Point(665 + 90, 0)
                    .lblCaption9.LocationF = New Point(710 + 90, 85)
                    .lbl9.LocationF = New Point(710 + 90, 0)
                    .lblCaption10.LocationF = New Point(755 + 90, 85)
                    .lbl10.LocationF = New Point(755 + 90, 0)
                    .lblCaption11.LocationF = New Point(800 + 90, 85)
                    .lbl11.LocationF = New Point(800 + 90, 0)
                    .lblCaption12.LocationF = New Point(845 + 90, 85)
                    .lbl12.LocationF = New Point(845 + 90, 0)
                    .lblCaption13.LocationF = New Point(890 + 90, 85)
                    .lbl13.LocationF = New Point(890 + 90, 0)
                    .lblCaption14.LocationF = New Point(935 + 90, 85)
                    .lbl14.LocationF = New Point(935 + 90, 0)
                    .lblCaption15.LocationF = New Point(980 + 90, 85)
                    .lbl15.LocationF = New Point(980 + 90, 0)
                    .lblCaption16.LocationF = New Point(1025 + 90, 85)
                    .lbl16.LocationF = New Point(1025 + 90, 0)
                    .lblCaption17.LocationF = New Point(1070 + 90, 85)
                    .lbl17.LocationF = New Point(1070 + 90, 0)
                    .lblCaption18.LocationF = New Point(1115 + 90, 85)
                    .lbl18.LocationF = New Point(1115 + 90, 0)

                    .lblCaption5.Visible = True
                    .lbl5.Visible = True
                    .lblCaption6.Visible = True
                    .lbl6.Visible = True
                    .lblCaption7.Visible = True
                    .lbl7.Visible = True
                    .lblCaption8.Visible = True
                    .lbl8.Visible = True
                    .lblCaption9.Visible = True
                    .lbl9.Visible = True
                    .lblCaption10.Visible = True
                    .lbl10.Visible = True
                    .lblCaption11.Visible = True
                    .lbl11.Visible = True
                    .lblCaption12.Visible = True
                    .lbl12.Visible = True
                    .lblCaption13.Visible = True
                    .lbl13.Visible = True
                    .lblCaption14.Visible = True
                    .lbl14.Visible = True
                    .lblCaption15.Visible = True
                    .lbl15.Visible = True
                    .lblCaption16.Visible = True
                    .lbl16.Visible = True
                    .lblCaption17.Visible = True
                    .lbl17.Visible = True
                    .lblCaption18.Visible = True
                    .lbl18.Visible = True
                    .lblCaption18.Borders = DevExpress.XtraPrinting.BorderSide.All
                    .lbl18.Borders = DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Right
                ElseIf Columns = 19 Then
                    .lblParticulars_C.SizeF = New Size(135 + 45, 35)
                    .lblParticulars.SizeF = New Size(135 + 45, 20)

                    .lblAmount_C.LocationF = New Point(290 + 45, 85)
                    .lblAmount.LocationF = New Point(290 + 45, 0)
                    .lblCaption1.LocationF = New Point(350 + 45, 85)
                    .lbl1.LocationF = New Point(350 + 45, 0)
                    .lblCaption2.LocationF = New Point(395 + 45, 85)
                    .lbl2.LocationF = New Point(395 + 45, 0)
                    .lblCaption3.LocationF = New Point(440 + 45, 85)
                    .lbl3.LocationF = New Point(440 + 45, 0)
                    .lblCaption4.LocationF = New Point(485 + 45, 85)
                    .lbl4.LocationF = New Point(485 + 45, 0)
                    .lblCaption5.LocationF = New Point(530 + 45, 85)
                    .lbl5.LocationF = New Point(530 + 45, 0)
                    .lblCaption6.LocationF = New Point(575 + 45, 85)
                    .lbl6.LocationF = New Point(575 + 45, 0)
                    .lblCaption7.LocationF = New Point(620 + 45, 85)
                    .lbl7.LocationF = New Point(620 + 45, 0)
                    .lblCaption8.LocationF = New Point(665 + 45, 85)
                    .lbl8.LocationF = New Point(665 + 45, 0)
                    .lblCaption9.LocationF = New Point(710 + 45, 85)
                    .lbl9.LocationF = New Point(710 + 45, 0)
                    .lblCaption10.LocationF = New Point(755 + 45, 85)
                    .lbl10.LocationF = New Point(755 + 45, 0)
                    .lblCaption11.LocationF = New Point(800 + 45, 85)
                    .lbl11.LocationF = New Point(800 + 45, 0)
                    .lblCaption12.LocationF = New Point(845 + 45, 85)
                    .lbl12.LocationF = New Point(845 + 45, 0)
                    .lblCaption13.LocationF = New Point(890 + 45, 85)
                    .lbl13.LocationF = New Point(890 + 45, 0)
                    .lblCaption14.LocationF = New Point(935 + 45, 85)
                    .lbl14.LocationF = New Point(935 + 45, 0)
                    .lblCaption15.LocationF = New Point(980 + 45, 85)
                    .lbl15.LocationF = New Point(980 + 45, 0)
                    .lblCaption16.LocationF = New Point(1025 + 45, 85)
                    .lbl16.LocationF = New Point(1025 + 45, 0)
                    .lblCaption17.LocationF = New Point(1070 + 45, 85)
                    .lbl17.LocationF = New Point(1070 + 45, 0)
                    .lblCaption18.LocationF = New Point(1115 + 45, 85)
                    .lbl18.LocationF = New Point(1115 + 45, 0)
                    .lblCaption19.LocationF = New Point(1160 + 45, 85)
                    .lbl19.LocationF = New Point(1160 + 45, 0)

                    .lblCaption5.Visible = True
                    .lbl5.Visible = True
                    .lblCaption6.Visible = True
                    .lbl6.Visible = True
                    .lblCaption7.Visible = True
                    .lbl7.Visible = True
                    .lblCaption8.Visible = True
                    .lbl8.Visible = True
                    .lblCaption9.Visible = True
                    .lbl9.Visible = True
                    .lblCaption10.Visible = True
                    .lbl10.Visible = True
                    .lblCaption11.Visible = True
                    .lbl11.Visible = True
                    .lblCaption12.Visible = True
                    .lbl12.Visible = True
                    .lblCaption13.Visible = True
                    .lbl13.Visible = True
                    .lblCaption14.Visible = True
                    .lbl14.Visible = True
                    .lblCaption15.Visible = True
                    .lbl15.Visible = True
                    .lblCaption16.Visible = True
                    .lbl16.Visible = True
                    .lblCaption17.Visible = True
                    .lbl17.Visible = True
                    .lblCaption18.Visible = True
                    .lbl18.Visible = True
                    .lblCaption19.Visible = True
                    .lbl19.Visible = True
                    .lblCaption19.Borders = DevExpress.XtraPrinting.BorderSide.All
                    .lbl19.Borders = DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Right
                ElseIf Columns = 20 Then
                    .lblCaption5.Visible = True
                    .lbl5.Visible = True
                    .lblCaption6.Visible = True
                    .lbl6.Visible = True
                    .lblCaption7.Visible = True
                    .lbl7.Visible = True
                    .lblCaption8.Visible = True
                    .lbl8.Visible = True
                    .lblCaption9.Visible = True
                    .lbl9.Visible = True
                    .lblCaption10.Visible = True
                    .lbl10.Visible = True
                    .lblCaption11.Visible = True
                    .lbl11.Visible = True
                    .lblCaption12.Visible = True
                    .lbl12.Visible = True
                    .lblCaption13.Visible = True
                    .lbl13.Visible = True
                    .lblCaption14.Visible = True
                    .lbl14.Visible = True
                    .lblCaption15.Visible = True
                    .lbl15.Visible = True
                    .lblCaption16.Visible = True
                    .lbl16.Visible = True
                    .lblCaption17.Visible = True
                    .lbl17.Visible = True
                    .lblCaption18.Visible = True
                    .lbl18.Visible = True
                    .lblCaption19.Visible = True
                    .lbl19.Visible = True
                    .lblCaption20.Visible = True
                    .lbl20.Visible = True
                End If

                .lblTotalExpense.Text = dTotalExpense.Text
                .lblRemainingCash.Text = dRemainingCash.Text
                .lblUnliquidated.Text = dUnliquidated.Text
                .lblTotal.Text = dTotal.Text

                .lblPreparedBy.Text = cbxPreparedBy.Text
                .lblCheckedBy.Text = txtCheckedBy.Text
                .lblApprovedBy.Text = txtApprovedBy.Text

                If Show Then
                    .ShowPreview()
                Else
                    Try
                        .ExportToPdf(FName)
                    Catch ex As Exception
                    End Try
                End If
            End With
        Else
            Dim Report As New RptReplenishmentV2
            With Report
                .Name = String.Format("Petty Cash Replenishment {0}", txtAccountNumber.Text)
                .lblAsOf.Text = dtpDate.Text
                .lblDocumentNum.Text = txtAccountNumber.Text
                .lblReferenceNum.Text = txtReferenceNumber.Text
                .lblRemarks.Text = txtRemarks.Text

                .lblCaption1.Text = GridColumn21.Caption
                .lblCaption2.Text = GridColumn22.Caption
                .lblCaption3.Text = GridColumn23.Caption
                .lblCaption4.Text = GridColumn24.Caption
                .lblCaption5.Text = GridColumn25.Caption
                .lblCaption6.Text = GridColumn26.Caption
                .lblCaption7.Text = GridColumn27.Caption
                .lblCaption8.Text = GridColumn28.Caption
                .lblCaption9.Text = GridColumn29.Caption
                .lblCaption10.Text = GridColumn31.Caption
                .lblCaption11.Text = GridColumn41.Caption
                .lblCaption12.Text = GridColumn32.Caption
                .lblCaption13.Text = GridColumn33.Caption
                .lblCaption14.Text = GridColumn34.Caption
                .lblCaption15.Text = GridColumn35.Caption
                .lblCaption16.Text = GridColumn36.Caption
                .lblCaption17.Text = GridColumn37.Caption
                .lblCaption18.Text = GridColumn38.Caption
                .lblCaption19.Text = GridColumn39.Caption
                .lblCaption20.Text = GridColumn40.Caption
                .lblCaption21.Text = GridColumn15.Caption
                .lblCaption22.Text = GridColumn42.Caption
                .lblCaption23.Text = GridColumn43.Caption
                .lblCaption24.Text = GridColumn44.Caption
                .lblCaption25.Text = GridColumn45.Caption
                .lblCaption26.Text = GridColumn46.Caption
                .lblCaption27.Text = GridColumn47.Caption
                .lblCaption28.Text = GridColumn48.Caption
                .lblCaption29.Text = GridColumn49.Caption
                .lblCaption30.Text = GridColumn50.Caption
                .lblCaption31.Text = GridColumn51.Caption
                .lblCaption32.Text = GridColumn52.Caption
                .lblCaption33.Text = GridColumn53.Caption
                .lblCaption34.Text = GridColumn54.Caption
                .lblCaption35.Text = GridColumn55.Caption
                .lblCaption36.Text = GridColumn56.Caption
                .lblCaption37.Text = GridColumn57.Caption
                .lblCaption38.Text = GridColumn58.Caption
                .lblCaption39.Text = GridColumn59.Caption
                .lblCaption40.Text = GridColumn60.Caption

                .DataSource = GridControl2.DataSource
                .lblDate.DataBindings.Add("Text", GridControl2.DataSource, "Date")
                .lblDocumentNumber.DataBindings.Add("Text", GridControl2.DataSource, "Document Number")
                .lblParticulars.DataBindings.Add("Text", GridControl2.DataSource, "Particulars")
                .lblAmount.DataBindings.Add("Text", GridControl2.DataSource, "Amount")
                .lbl1.DataBindings.Add("Text", GridControl2.DataSource, "Amount 1")
                .lbl2.DataBindings.Add("Text", GridControl2.DataSource, "Amount 2")
                .lbl3.DataBindings.Add("Text", GridControl2.DataSource, "Amount 3")
                .lbl4.DataBindings.Add("Text", GridControl2.DataSource, "Amount 4")
                .lbl5.DataBindings.Add("Text", GridControl2.DataSource, "Amount 5")
                .lbl6.DataBindings.Add("Text", GridControl2.DataSource, "Amount 6")
                .lbl7.DataBindings.Add("Text", GridControl2.DataSource, "Amount 7")
                .lbl8.DataBindings.Add("Text", GridControl2.DataSource, "Amount 8")
                .lbl9.DataBindings.Add("Text", GridControl2.DataSource, "Amount 9")
                .lbl10.DataBindings.Add("Text", GridControl2.DataSource, "Amount 10")
                .lbl11.DataBindings.Add("Text", GridControl2.DataSource, "Amount 11")
                .lbl12.DataBindings.Add("Text", GridControl2.DataSource, "Amount 12")
                .lbl13.DataBindings.Add("Text", GridControl2.DataSource, "Amount 13")
                .lbl14.DataBindings.Add("Text", GridControl2.DataSource, "Amount 14")
                .lbl15.DataBindings.Add("Text", GridControl2.DataSource, "Amount 15")
                .lbl16.DataBindings.Add("Text", GridControl2.DataSource, "Amount 16")
                .lbl17.DataBindings.Add("Text", GridControl2.DataSource, "Amount 17")
                .lbl18.DataBindings.Add("Text", GridControl2.DataSource, "Amount 18")
                .lbl19.DataBindings.Add("Text", GridControl2.DataSource, "Amount 19")
                .lbl20.DataBindings.Add("Text", GridControl2.DataSource, "Amount 20")
                .lbl21.DataBindings.Add("Text", GridControl2.DataSource, "Amount 21")
                .lbl22.DataBindings.Add("Text", GridControl2.DataSource, "Amount 22")
                .lbl23.DataBindings.Add("Text", GridControl2.DataSource, "Amount 23")
                .lbl24.DataBindings.Add("Text", GridControl2.DataSource, "Amount 24")
                .lbl25.DataBindings.Add("Text", GridControl2.DataSource, "Amount 25")
                .lbl26.DataBindings.Add("Text", GridControl2.DataSource, "Amount 26")
                .lbl27.DataBindings.Add("Text", GridControl2.DataSource, "Amount 27")
                .lbl28.DataBindings.Add("Text", GridControl2.DataSource, "Amount 28")
                .lbl29.DataBindings.Add("Text", GridControl2.DataSource, "Amount 29")
                .lbl30.DataBindings.Add("Text", GridControl2.DataSource, "Amount 30")
                .lbl31.DataBindings.Add("Text", GridControl2.DataSource, "Amount 31")
                .lbl32.DataBindings.Add("Text", GridControl2.DataSource, "Amount 32")
                .lbl33.DataBindings.Add("Text", GridControl2.DataSource, "Amount 33")
                .lbl34.DataBindings.Add("Text", GridControl2.DataSource, "Amount 34")
                .lbl35.DataBindings.Add("Text", GridControl2.DataSource, "Amount 35")
                .lbl36.DataBindings.Add("Text", GridControl2.DataSource, "Amount 36")
                .lbl37.DataBindings.Add("Text", GridControl2.DataSource, "Amount 37")
                .lbl38.DataBindings.Add("Text", GridControl2.DataSource, "Amount 38")
                .lbl39.DataBindings.Add("Text", GridControl2.DataSource, "Amount 39")
                .lbl40.DataBindings.Add("Text", GridControl2.DataSource, "Amount 40")

                If Columns >= 21 Then
                    .lblCaption21.Visible = True
                    .lbl21.Visible = True

                    .XrLabel7.LocationF = New Point(965 + 45, 0)
                    .lblTotalExpense.LocationF = New Point(1100 + 45, 0)
                    .XrLabel10.LocationF = New Point(965 + 45, 25)
                    .lblRemainingCash.LocationF = New Point(1100 + 45, 25)
                    .XrLabel5.LocationF = New Point(965 + 45, 50)
                    .lblUnliquidated.LocationF = New Point(1100 + 45, 50)
                    .XrLabel8.LocationF = New Point(965 + 45, 75)
                    .lblTotal.LocationF = New Point(1100 + 45, 75)
                End If
                If Columns >= 22 Then
                    .lblCaption22.Visible = True
                    .lbl22.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 2), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 2), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 2), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 2), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 2), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 2), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 2), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 2), 75)
                End If
                If Columns >= 23 Then
                    .lblCaption23.Visible = True
                    .lbl23.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 3), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 3), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 3), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 3), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 3), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 3), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 3), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 3), 75)
                End If
                If Columns >= 24 Then
                    .lblCaption24.Visible = True
                    .lbl24.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 4), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 4), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 4), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 4), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 4), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 4), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 4), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 4), 75)
                End If
                If Columns >= 25 Then
                    .lblCaption25.Visible = True
                    .lbl25.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 5), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 5), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 5), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 5), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 5), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 5), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 5), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 5), 75)
                End If
                If Columns >= 26 Then
                    .lblCaption26.Visible = True
                    .lbl26.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 6), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 6), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 6), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 6), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 6), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 6), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 6), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 6), 75)
                End If
                If Columns >= 27 Then
                    .lblCaption27.Visible = True
                    .lbl27.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 7), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 7), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 7), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 7), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 7), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 7), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 7), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 7), 75)
                End If
                If Columns >= 28 Then
                    .lblCaption28.Visible = True
                    .lbl28.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 8), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 8), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 8), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 8), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 8), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 8), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 8), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 8), 75)
                End If
                If Columns >= 29 Then
                    .lblCaption29.Visible = True
                    .lbl29.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 9), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 9), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 9), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 9), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 9), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 9), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 9), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 9), 75)
                End If
                If Columns >= 30 Then
                    .lblCaption30.Visible = True
                    .lbl30.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 10), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 10), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 10), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 10), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 10), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 10), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 10), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 10), 75)
                End If
                If Columns >= 31 Then
                    .lblCaption31.Visible = True
                    .lbl31.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 11), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 11), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 11), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 11), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 11), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 11), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 11), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 11), 75)
                End If
                If Columns >= 32 Then
                    .lblCaption32.Visible = True
                    .lbl32.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 12), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 12), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 12), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 12), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 12), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 12), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 12), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 12), 75)
                End If
                If Columns >= 33 Then
                    .lblCaption33.Visible = True
                    .lbl33.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 13), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 13), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 13), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 13), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 13), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 13), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 13), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 13), 75)
                End If
                If Columns >= 34 Then
                    .lblCaption34.Visible = True
                    .lbl34.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 14), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 14), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 14), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 14), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 14), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 14), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 14), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 14), 75)
                End If
                If Columns >= 35 Then
                    .lblCaption35.Visible = True
                    .lbl35.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 15), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 15), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 15), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 15), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 15), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 15), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 15), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 15), 75)
                End If
                If Columns >= 36 Then
                    .lblCaption36.Visible = True
                    .lbl36.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 16), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 16), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 16), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 16), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 16), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 16), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 16), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 16), 75)
                End If
                If Columns >= 37 Then
                    .lblCaption37.Visible = True
                    .lbl37.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 17), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 17), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 17), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 17), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 17), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 17), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 17), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 17), 75)
                End If
                If Columns >= 38 Then
                    .lblCaption38.Visible = True
                    .lbl38.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 18), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 18), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 18), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 18), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 18), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 18), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 18), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 18), 75)
                End If
                If Columns >= 39 Then
                    .lblCaption39.Visible = True
                    .lbl39.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 19), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 19), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 19), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 19), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 19), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 19), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 19), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 19), 75)
                End If
                If Columns >= 40 Then
                    .lblCaption40.Visible = True
                    .lbl40.Visible = True

                    .XrLabel7.LocationF = New Point(965 + (45 * 20), 0)
                    .lblTotalExpense.LocationF = New Point(1100 + (45 * 20), 0)
                    .XrLabel10.LocationF = New Point(965 + (45 * 20), 25)
                    .lblRemainingCash.LocationF = New Point(1100 + (45 * 20), 25)
                    .XrLabel5.LocationF = New Point(965 + (45 * 20), 50)
                    .lblUnliquidated.LocationF = New Point(1100 + (45 * 20), 50)
                    .XrLabel8.LocationF = New Point(965 + (45 * 20), 75)
                    .lblTotal.LocationF = New Point(1100 + (45 * 20), 75)
                End If

                .lblTotalExpense.Text = dTotalExpense.Text
                .lblRemainingCash.Text = dRemainingCash.Text
                .lblUnliquidated.Text = dUnliquidated.Text
                .lblTotal.Text = dTotal.Text

                .lblPreparedBy.Text = cbxPreparedBy.Text
                .lblCheckedBy.Text = txtCheckedBy.Text
                .lblApprovedBy.Text = txtApprovedBy.Text

                If Show Then
                    .ShowPreview()
                Else
                    Try
                        .ExportToPdf(FName)
                    Catch ex As Exception
                    End Try
                End If
            End With
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If SuperTabControl1.SelectedTabIndex = 0 Then
            Generate_Receipt(True, "")
            Logs("Replenishment", "Print", "[SENSITIVE] Print Replenishment " & txtAccountNumber.Text, "", "", "", "")
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("REPLENISHMENT LIST", GridControl1)
            Logs("Replenishment", "Print", "[SENSITIVE] Print Replenishment List", "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub
    '***BUTTON CLICK

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.B Then
            btnBack.Focus()
            btnBack.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.N Then
            btnNext.Focus()
            btnNext.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            btnDelete.Focus()
            btnDelete.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.M Then
            btnModify.Focus()
            btnModify.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.A Then
            btnAdd.Focus()
            btnAdd.PerformClick()
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

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView1_DoubleClick(sender, e)
        End If
    End Sub

    Public Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        Cursor = Cursors.WaitCursor
        PanelEx10.Enabled = False
        dtpDate.Enabled = False
        With GridView1
            ID = .GetFocusedRowCellValue("ID")
            dtpDate.Value = .GetFocusedRowCellValue("Document Date")
            dtpDate.Tag = .GetFocusedRowCellValue("Document Date")
            txtAccountNumber.Text = .GetFocusedRowCellValue("Document Number")
            txtReferenceNumber.Text = .GetFocusedRowCellValue("Reference No")
            txtReferenceNumber.Tag = .GetFocusedRowCellValue("Reference No")
            txtRemarks.Text = .GetFocusedRowCellValue("Remarks")
            dTotalExpense.Value = .GetFocusedRowCellValue("Total Expenses")
            dRemainingCash.Value = .GetFocusedRowCellValue("Remaining Cash")
            dUnliquidated.Tag = .GetFocusedRowCellValue("CA Unliquidated")
            dUnliquidated.Value = .GetFocusedRowCellValue("CA Unliquidated")
            If CompanyMode = 0 Then
                GridColumn21.Caption = .GetFocusedRowCellValue("Caption1M")
                GridColumn22.Caption = .GetFocusedRowCellValue("Caption2M")
                GridColumn23.Caption = .GetFocusedRowCellValue("Caption3M")
                GridColumn24.Caption = .GetFocusedRowCellValue("Caption4M")
                GridColumn25.Caption = .GetFocusedRowCellValue("Caption5M")
                GridColumn26.Caption = .GetFocusedRowCellValue("Caption6M")
                GridColumn27.Caption = .GetFocusedRowCellValue("Caption7M")
                GridColumn28.Caption = .GetFocusedRowCellValue("Caption8M")
                GridColumn29.Caption = .GetFocusedRowCellValue("Caption9M")
                GridColumn31.Caption = .GetFocusedRowCellValue("Caption10M")
                GridColumn41.Caption = .GetFocusedRowCellValue("Caption11M")
                GridColumn32.Caption = .GetFocusedRowCellValue("Caption12M")
                GridColumn33.Caption = .GetFocusedRowCellValue("Caption13M")
                GridColumn34.Caption = .GetFocusedRowCellValue("Caption14M")
                GridColumn35.Caption = .GetFocusedRowCellValue("Caption15M")
                GridColumn36.Caption = .GetFocusedRowCellValue("Caption16M")
                GridColumn37.Caption = .GetFocusedRowCellValue("Caption17M")
                GridColumn38.Caption = .GetFocusedRowCellValue("Caption18M")
                GridColumn39.Caption = .GetFocusedRowCellValue("Caption19M")
                GridColumn40.Caption = .GetFocusedRowCellValue("Caption20M")

                GridColumn15.Caption = .GetFocusedRowCellValue("Caption21M")
                GridColumn42.Caption = .GetFocusedRowCellValue("Caption22M")
                GridColumn43.Caption = .GetFocusedRowCellValue("Caption23M")
                GridColumn44.Caption = .GetFocusedRowCellValue("Caption24M")
                GridColumn45.Caption = .GetFocusedRowCellValue("Caption25M")
                GridColumn46.Caption = .GetFocusedRowCellValue("Caption26M")
                GridColumn47.Caption = .GetFocusedRowCellValue("Caption27M")
                GridColumn48.Caption = .GetFocusedRowCellValue("Caption28M")
                GridColumn49.Caption = .GetFocusedRowCellValue("Caption29M")
                GridColumn50.Caption = .GetFocusedRowCellValue("Caption30M")
                GridColumn51.Caption = .GetFocusedRowCellValue("Caption31M")
                GridColumn52.Caption = .GetFocusedRowCellValue("Caption32M")
                GridColumn53.Caption = .GetFocusedRowCellValue("Caption33M")
                GridColumn54.Caption = .GetFocusedRowCellValue("Caption34M")
                GridColumn55.Caption = .GetFocusedRowCellValue("Caption35M")
                GridColumn56.Caption = .GetFocusedRowCellValue("Caption36M")
                GridColumn57.Caption = .GetFocusedRowCellValue("Caption37M")
                GridColumn58.Caption = .GetFocusedRowCellValue("Caption38M")
                GridColumn59.Caption = .GetFocusedRowCellValue("Caption39M")
                GridColumn60.Caption = .GetFocusedRowCellValue("Caption40M")
            Else
                GridColumn21.Caption = .GetFocusedRowCellValue("Caption1")
                GridColumn22.Caption = .GetFocusedRowCellValue("Caption2")
                GridColumn23.Caption = .GetFocusedRowCellValue("Caption3")
                GridColumn24.Caption = .GetFocusedRowCellValue("Caption4")
                GridColumn25.Caption = .GetFocusedRowCellValue("Caption5")
                GridColumn26.Caption = .GetFocusedRowCellValue("Caption6")
                GridColumn27.Caption = .GetFocusedRowCellValue("Caption7")
                GridColumn28.Caption = .GetFocusedRowCellValue("Caption8")
                GridColumn29.Caption = .GetFocusedRowCellValue("Caption9")
                GridColumn31.Caption = .GetFocusedRowCellValue("Caption10")
                GridColumn41.Caption = .GetFocusedRowCellValue("Caption11")
                GridColumn32.Caption = .GetFocusedRowCellValue("Caption12")
                GridColumn33.Caption = .GetFocusedRowCellValue("Caption13")
                GridColumn34.Caption = .GetFocusedRowCellValue("Caption14")
                GridColumn35.Caption = .GetFocusedRowCellValue("Caption15")
                GridColumn36.Caption = .GetFocusedRowCellValue("Caption16")
                GridColumn37.Caption = .GetFocusedRowCellValue("Caption17")
                GridColumn38.Caption = .GetFocusedRowCellValue("Caption18")
                GridColumn39.Caption = .GetFocusedRowCellValue("Caption19")
                GridColumn40.Caption = .GetFocusedRowCellValue("Caption20")

                GridColumn15.Caption = .GetFocusedRowCellValue("Caption21")
                GridColumn42.Caption = .GetFocusedRowCellValue("Caption22")
                GridColumn43.Caption = .GetFocusedRowCellValue("Caption23")
                GridColumn44.Caption = .GetFocusedRowCellValue("Caption24")
                GridColumn45.Caption = .GetFocusedRowCellValue("Caption25")
                GridColumn46.Caption = .GetFocusedRowCellValue("Caption26")
                GridColumn47.Caption = .GetFocusedRowCellValue("Caption27")
                GridColumn48.Caption = .GetFocusedRowCellValue("Caption28")
                GridColumn49.Caption = .GetFocusedRowCellValue("Caption29")
                GridColumn50.Caption = .GetFocusedRowCellValue("Caption30")
                GridColumn51.Caption = .GetFocusedRowCellValue("Caption31")
                GridColumn52.Caption = .GetFocusedRowCellValue("Caption32")
                GridColumn53.Caption = .GetFocusedRowCellValue("Caption33")
                GridColumn54.Caption = .GetFocusedRowCellValue("Caption34")
                GridColumn55.Caption = .GetFocusedRowCellValue("Caption35")
                GridColumn56.Caption = .GetFocusedRowCellValue("Caption36")
                GridColumn57.Caption = .GetFocusedRowCellValue("Caption37")
                GridColumn58.Caption = .GetFocusedRowCellValue("Caption38")
                GridColumn59.Caption = .GetFocusedRowCellValue("Caption39")
                GridColumn60.Caption = .GetFocusedRowCellValue("Caption40")
            End If
            GridColumn21.Tag = .GetFocusedRowCellValue("Caption1Tag")
            GridColumn22.Tag = .GetFocusedRowCellValue("Caption2Tag")
            GridColumn23.Tag = .GetFocusedRowCellValue("Caption3Tag")
            GridColumn24.Tag = .GetFocusedRowCellValue("Caption4Tag")
            GridColumn25.Tag = .GetFocusedRowCellValue("Caption5Tag")
            GridColumn26.Tag = .GetFocusedRowCellValue("Caption6Tag")
            GridColumn27.Tag = .GetFocusedRowCellValue("Caption7Tag")
            GridColumn28.Tag = .GetFocusedRowCellValue("Caption8Tag")
            GridColumn29.Tag = .GetFocusedRowCellValue("Caption9Tag")
            GridColumn31.Tag = .GetFocusedRowCellValue("Caption10Tag")
            GridColumn41.Tag = .GetFocusedRowCellValue("Caption11Tag")
            GridColumn32.Tag = .GetFocusedRowCellValue("Caption12Tag")
            GridColumn33.Tag = .GetFocusedRowCellValue("Caption13Tag")
            GridColumn34.Tag = .GetFocusedRowCellValue("Caption14Tag")
            GridColumn35.Tag = .GetFocusedRowCellValue("Caption15Tag")
            GridColumn36.Tag = .GetFocusedRowCellValue("Caption16Tag")
            GridColumn37.Tag = .GetFocusedRowCellValue("Caption17Tag")
            GridColumn38.Tag = .GetFocusedRowCellValue("Caption18Tag")
            GridColumn39.Tag = .GetFocusedRowCellValue("Caption19Tag")
            GridColumn40.Tag = .GetFocusedRowCellValue("Caption20Tag")

            GridColumn15.Tag = .GetFocusedRowCellValue("Caption21Tag")
            GridColumn42.Tag = .GetFocusedRowCellValue("Caption22Tag")
            GridColumn43.Tag = .GetFocusedRowCellValue("Caption23Tag")
            GridColumn44.Tag = .GetFocusedRowCellValue("Caption24Tag")
            GridColumn45.Tag = .GetFocusedRowCellValue("Caption25Tag")
            GridColumn46.Tag = .GetFocusedRowCellValue("Caption26Tag")
            GridColumn47.Tag = .GetFocusedRowCellValue("Caption27Tag")
            GridColumn48.Tag = .GetFocusedRowCellValue("Caption28Tag")
            GridColumn49.Tag = .GetFocusedRowCellValue("Caption29Tag")
            GridColumn50.Tag = .GetFocusedRowCellValue("Caption30Tag")
            GridColumn51.Tag = .GetFocusedRowCellValue("Caption31Tag")
            GridColumn52.Tag = .GetFocusedRowCellValue("Caption32Tag")
            GridColumn53.Tag = .GetFocusedRowCellValue("Caption33Tag")
            GridColumn54.Tag = .GetFocusedRowCellValue("Caption34Tag")
            GridColumn55.Tag = .GetFocusedRowCellValue("Caption35Tag")
            GridColumn56.Tag = .GetFocusedRowCellValue("Caption36Tag")
            GridColumn57.Tag = .GetFocusedRowCellValue("Caption37Tag")
            GridColumn58.Tag = .GetFocusedRowCellValue("Caption38Tag")
            GridColumn59.Tag = .GetFocusedRowCellValue("Caption39Tag")
            GridColumn60.Tag = .GetFocusedRowCellValue("Caption40Tag")
            Columns = .GetFocusedRowCellValue("Cols")
        End With

        GridColumn21.VisibleIndex = 1 + 4 '1
        GridColumn22.VisibleIndex = 1 + 5 '2
        GridColumn23.VisibleIndex = 1 + 6 '3
        GridColumn24.VisibleIndex = 1 + 7 '4
        If Columns >= 5 Then
            GridColumn25.VisibleIndex = 1 + 8 '5
            btnRemoveCol.Enabled = True
        End If
        If Columns >= 6 Then
            GridColumn26.VisibleIndex = 1 + 9 '6
        End If
        If Columns >= 7 Then
            GridColumn27.VisibleIndex = 1 + 10 '
        End If
        If Columns >= 8 Then
            GridColumn28.VisibleIndex = 1 + 11 '8
        End If
        If Columns >= 9 Then
            GridColumn29.VisibleIndex = 1 + 12 '9
        End If
        If Columns >= 10 Then
            GridColumn31.VisibleIndex = 1 + 13 '10
        End If
        If Columns >= 11 Then
            GridColumn41.VisibleIndex = 1 + 14 '11
        End If
        If Columns >= 12 Then
            GridColumn32.VisibleIndex = 1 + 15 '12
        End If
        If Columns >= 13 Then
            GridColumn33.VisibleIndex = 1 + 16 '13
        End If
        If Columns >= 14 Then
            GridColumn34.VisibleIndex = 1 + 17 '14
        End If
        If Columns >= 15 Then
            GridColumn35.VisibleIndex = 1 + 18 '15
        End If
        If Columns >= 16 Then
            GridColumn36.VisibleIndex = 1 + 19 '16
        End If
        If Columns >= 17 Then
            GridColumn37.VisibleIndex = 1 + 20 '17
        End If
        If Columns >= 18 Then
            GridColumn38.VisibleIndex = 1 + 21 '18
        End If
        If Columns >= 19 Then
            GridColumn39.VisibleIndex = 1 + 22 '19
        End If
        If Columns >= 20 Then
            GridColumn40.VisibleIndex = 1 + 23 '20
        End If
        If Columns >= 21 Then
            GridColumn15.VisibleIndex = 1 + 24 '21
        End If
        If Columns >= 22 Then
            GridColumn42.VisibleIndex = 1 + 25 '22
        End If
        If Columns >= 23 Then
            GridColumn43.VisibleIndex = 1 + 26 '23
        End If
        If Columns >= 24 Then
            GridColumn44.VisibleIndex = 1 + 27 '24
        End If
        If Columns >= 25 Then
            GridColumn45.VisibleIndex = 1 + 28 '25
        End If
        If Columns >= 26 Then
            GridColumn46.VisibleIndex = 1 + 29 '26
        End If
        If Columns >= 27 Then
            GridColumn47.VisibleIndex = 1 + 30 '27
        End If
        If Columns >= 28 Then
            GridColumn48.VisibleIndex = 1 + 31 '28
        End If
        If Columns >= 29 Then
            GridColumn49.VisibleIndex = 1 + 32 '28
        End If
        If Columns >= 30 Then
            GridColumn50.VisibleIndex = 1 + 33 '30
        End If
        If Columns >= 31 Then
            GridColumn51.VisibleIndex = 1 + 34 '31
        End If
        If Columns >= 32 Then
            GridColumn52.VisibleIndex = 1 + 35 '32
        End If
        If Columns >= 33 Then
            GridColumn53.VisibleIndex = 1 + 36 '33
        End If
        If Columns >= 34 Then
            GridColumn54.VisibleIndex = 1 + 37 '34
        End If
        If Columns >= 35 Then
            GridColumn55.VisibleIndex = 1 + 38 '35
        End If
        If Columns >= 36 Then
            GridColumn56.VisibleIndex = 1 + 39 '36
        End If
        If Columns >= 37 Then
            GridColumn57.VisibleIndex = 1 + 40 '37
        End If
        If Columns >= 38 Then
            GridColumn58.VisibleIndex = 1 + 41 '38
        End If
        If Columns >= 39 Then
            GridColumn59.VisibleIndex = 1 + 42 '39
        End If
        If Columns = 40 Then
            GridColumn60.VisibleIndex = 1 + 43 '40

            btnAddCol.Enabled = False
        End If

        DT_Particular = DataSource(String.Format("SELECT ID, DATE_FORMAT(`Date`, '%b %d, %Y') AS 'Date', DocumentNumber AS 'Document Number', Particulars, Amount, Amount1 AS 'Amount 1', Amount2 AS 'Amount 2', Amount3 AS 'Amount 3', Amount4 AS 'Amount 4', Amount5 AS 'Amount 5', Amount6 AS 'Amount 6', Amount7 AS 'Amount 7', Amount8 AS 'Amount 8', Amount9 AS 'Amount 9', Amount10 AS 'Amount 10', Amount11 AS 'Amount 11', Amount12 AS 'Amount 12', Amount13 AS 'Amount 13', Amount14 AS 'Amount 14', Amount15 AS 'Amount 15', Amount16 AS 'Amount 16', Amount17 AS 'Amount 17', Amount18 AS 'Amount 18', Amount19 AS 'Amount 19', Amount20 AS 'Amount 20', Amount21 AS 'Amount 21', Amount22 AS 'Amount 22', Amount23 AS 'Amount 23', Amount24 AS 'Amount 24', Amount25 AS 'Amount 25', Amount26 AS 'Amount 26', Amount27 AS 'Amount 27', Amount28 AS 'Amount 28', Amount29 AS 'Amount 29', Amount30 AS 'Amount 30', Amount31 AS 'Amount 31', Amount32 AS 'Amount 32', Amount33 AS 'Amount 33', Amount34 AS 'Amount 34', Amount35 AS 'Amount 35', Amount36 AS 'Amount 36', Amount37 AS 'Amount 37', Amount38 AS 'Amount 38', Amount39 AS 'Amount 39', Amount40 AS 'Amount 40', '' AS 'CANumber', 12 AS 'Sort', 0 AS 'No' FROM replenishment_details WHERE RepNumber = '{0}' AND `status` = 'ACTIVE' ORDER BY `Document Number`;", txtAccountNumber.Text))
        GridControl2.DataSource = DT_Particular
        Dim TotalEx As Double
        Dim Total_1 As Double
        Dim Total_2 As Double
        Dim Total_3 As Double
        Dim Total_4 As Double
        Dim Total_5 As Double
        Dim Total_6 As Double
        Dim Total_7 As Double
        Dim Total_8 As Double
        Dim Total_9 As Double
        Dim Total_10 As Double
        Dim Total_11 As Double
        Dim Total_12 As Double
        Dim Total_13 As Double
        Dim Total_14 As Double
        Dim Total_15 As Double
        Dim Total_16 As Double
        Dim Total_17 As Double
        Dim Total_18 As Double
        Dim Total_19 As Double
        Dim Total_20 As Double
        Dim Total_21 As Double
        Dim Total_22 As Double
        Dim Total_23 As Double
        Dim Total_24 As Double
        Dim Total_25 As Double
        Dim Total_26 As Double
        Dim Total_27 As Double
        Dim Total_28 As Double
        Dim Total_29 As Double
        Dim Total_30 As Double
        Dim Total_31 As Double
        Dim Total_32 As Double
        Dim Total_33 As Double
        Dim Total_34 As Double
        Dim Total_35 As Double
        Dim Total_36 As Double
        Dim Total_37 As Double
        Dim Total_38 As Double
        Dim Total_39 As Double
        Dim Total_40 As Double
        For x As Integer = 0 To GridView2.RowCount - 1
            DT_Particular(x)("No") = x + 1
            TotalEx += CDbl(GridView2.GetRowCellValue(x, "Amount"))
            Total_1 += CDbl(DT_Particular(x)("Amount 1"))
            Total_2 += CDbl(DT_Particular(x)("Amount 2"))
            Total_3 += CDbl(DT_Particular(x)("Amount 3"))
            Total_4 += CDbl(DT_Particular(x)("Amount 4"))
            Total_5 += CDbl(DT_Particular(x)("Amount 5"))
            Total_6 += CDbl(DT_Particular(x)("Amount 6"))
            Total_7 += CDbl(DT_Particular(x)("Amount 7"))
            Total_8 += CDbl(DT_Particular(x)("Amount 8"))
            Total_9 += CDbl(DT_Particular(x)("Amount 9"))
            Total_10 += CDbl(DT_Particular(x)("Amount 10"))
            Total_11 += CDbl(DT_Particular(x)("Amount 11"))
            Total_12 += CDbl(DT_Particular(x)("Amount 12"))
            Total_13 += CDbl(DT_Particular(x)("Amount 13"))
            Total_14 += CDbl(DT_Particular(x)("Amount 14"))
            Total_15 += CDbl(DT_Particular(x)("Amount 15"))
            Total_16 += CDbl(DT_Particular(x)("Amount 16"))
            Total_17 += CDbl(DT_Particular(x)("Amount 17"))
            Total_18 += CDbl(DT_Particular(x)("Amount 18"))
            Total_19 += CDbl(DT_Particular(x)("Amount 19"))
            Total_20 += CDbl(DT_Particular(x)("Amount 20"))
            Total_21 += CDbl(DT_Particular(x)("Amount 21"))
            Total_22 += CDbl(DT_Particular(x)("Amount 22"))
            Total_23 += CDbl(DT_Particular(x)("Amount 23"))
            Total_24 += CDbl(DT_Particular(x)("Amount 24"))
            Total_25 += CDbl(DT_Particular(x)("Amount 25"))
            Total_26 += CDbl(DT_Particular(x)("Amount 26"))
            Total_27 += CDbl(DT_Particular(x)("Amount 27"))
            Total_28 += CDbl(DT_Particular(x)("Amount 28"))
            Total_29 += CDbl(DT_Particular(x)("Amount 29"))
            Total_30 += CDbl(DT_Particular(x)("Amount 30"))
            Total_31 += CDbl(DT_Particular(x)("Amount 31"))
            Total_32 += CDbl(DT_Particular(x)("Amount 32"))
            Total_33 += CDbl(DT_Particular(x)("Amount 33"))
            Total_34 += CDbl(DT_Particular(x)("Amount 34"))
            Total_35 += CDbl(DT_Particular(x)("Amount 35"))
            Total_36 += CDbl(DT_Particular(x)("Amount 36"))
            Total_37 += CDbl(DT_Particular(x)("Amount 37"))
            Total_38 += CDbl(DT_Particular(x)("Amount 38"))
            Total_39 += CDbl(DT_Particular(x)("Amount 39"))
            Total_40 += CDbl(DT_Particular(x)("Amount 40"))
        Next
        dTotalExpense.Value = TotalEx
        DT_Particular.Rows.Add(0, "", "T O T A L", "", TotalEx, Total_1, Total_2, Total_3, Total_4, Total_5, Total_6, Total_7, Total_8, Total_9, Total_10, Total_11, Total_12, Total_13, Total_14, Total_15, Total_16, Total_17, Total_18, Total_19, Total_20, Total_21, Total_22, Total_23, Total_24, Total_25, Total_26, Total_27, Total_28, Total_29, Total_30, Total_31, Total_32, Total_33, Total_34, Total_35, Total_36, Total_37, Total_38, Total_39, Total_40)

        With GridView1
            cbxPreparedBy.Text = .GetFocusedRowCellValue("Prepared By")
            cbxPreparedBy.Tag = .GetFocusedRowCellValue("Prepared By")
            txtCheckedBy.Text = .GetFocusedRowCellValue("Checked By")
            txtApprovedBy.Text = .GetFocusedRowCellValue("Approved By")
            User_EmplID = .GetFocusedRowCellValue("User_EmplID")
            Code_Check = .GetFocusedRowCellValue("Check_OTAC")
            Code_Approve = .GetFocusedRowCellValue("Approve_OTAC")
        End With

        SuperTabControl1.SelectedTab = tabSetup
        btnDraft.Visible = False
        If GridView1.GetFocusedRowCellValue("ReplenishStatus") = "PENDING" Or GridView1.GetFocusedRowCellValue("ReplenishStatus") = "FOR CHECK VOUCHER" Then
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If ComparePosition({DT_Signatory(x)("PositionID")}, True) And btnCheck.Tag = DT_Signatory(x)("ButtonID") And DT_Signatory(x)("FormID") = Tag Then
                    'btnCheck.Visible = True
                    btnModify.Enabled = True
                    Exit For
                End If
            Next
            If User_Type = "ADMIN" Or Empl_ID = User_EmplID Or Empl_ID = GridView1.GetFocusedRowCellValue("PreparedID") Then
                btnModify.Enabled = True
                'btnCheck.Visible = True
                If GridView1.GetFocusedRowCellValue("Voucher_Status") = "DRAFT" Then
                    btnDraft.Enabled = False
                    btnDraft.Visible = True
                End If
            End If
        ElseIf GridView1.GetFocusedRowCellValue("ReplenishStatus") = "CHECKED" Then
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If ComparePosition({DT_Signatory(x)("PositionID")}, True) And btnApprove.Tag = DT_Signatory(x)("ButtonID") And DT_Signatory(x)("FormID") = Tag Then
                    'btnApprove.Visible = True
                    btnModify.Enabled = True
                    Exit For
                End If
            Next
            If User_Type = "ADMIN" Or Empl_ID = User_EmplID Or Empl_ID = GridView1.GetFocusedRowCellValue("PreparedID") Then
                'btnApprove.Visible = True
            End If
        ElseIf GridView1.GetFocusedRowCellValue("ReplenishStatus") = "APPROVED" Then
            btnCheck.Visible = False
            btnApprove.Visible = False
            btnModify.Enabled = False
        End If
        btnPrint.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
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

    Private Sub IAddRow_Click(sender As Object, e As EventArgs) Handles iAddRow.Click
        Dim PCV As New FrmAddPCV
        Dim ExcludeID As String = ""
        For x As Integer = 0 To GridView2.RowCount - 1
            ExcludeID &= "'" & GridView2.GetRowCellValue(x, "Document Number") & "',"
        Next
        With PCV
            If ExcludeID = "" Then
            Else
                .ExcludeID = ExcludeID.Substring(0, ExcludeID.Length - 1)
            End If
            If .ShowDialog = DialogResult.OK Then
                Dim IncludeID As String = ""
                Dim selectedRowHandles As Integer() = .GridView2.GetSelectedRows()
                If selectedRowHandles.Length > 1 Then
                    Dim I As Integer
                    Dim Docs As String = ""
                    For I = 0 To selectedRowHandles.Length - 1
                        Dim selectedRowHandle As Integer = selectedRowHandles(I)
                        If (selectedRowHandle >= 0) Then
                            IncludeID &= "'" & .GridView2.GetRowCellValue(selectedRowHandle, "Document Number") & "',"
                        End If
                    Next
                    If IncludeID = "" Then
                    Else
                        IncludeID = IncludeID.Substring(0, IncludeID.Length - 1)
                    End If
                Else
                    IncludeID = "'" & .GridView2.GetFocusedRowCellValue("Document Number") & "'"
                End If
                Dim SQL As String = "SELECT * FROM ( SELECT"
                SQL &= "    ID,"
                SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
                SQL &= "    AccountNumber AS 'Document Number',"
                SQL &= "    CONCAT(TRIM(Payee),'/',Particular_1) AS 'Particulars',"
                SQL &= "    Amount_1 AS 'Amount', 1 AS 'Sort'"
                SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
                SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

                SQL &= " UNION ALL SELECT"
                SQL &= "    ID,"
                SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
                SQL &= "    AccountNumber AS 'Document Number',"
                SQL &= "    CONCAT(TRIM(Payee),'/',Particular_2) AS 'Particulars',"
                SQL &= "    Amount_2 AS 'Amount', 2 AS 'Sort'"
                SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
                SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

                SQL &= " UNION ALL SELECT"
                SQL &= "    ID,"
                SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
                SQL &= "    AccountNumber AS 'Document Number',"
                SQL &= "    CONCAT(TRIM(Payee),'/',Particular_3) AS 'Particulars',"
                SQL &= "    Amount_3 AS 'Amount', 3 AS 'Sort'"
                SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
                SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

                SQL &= " UNION ALL SELECT"
                SQL &= "    ID,"
                SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
                SQL &= "    AccountNumber AS 'Document Number',"
                SQL &= "    CONCAT(TRIM(Payee),'/',Particular_4) AS 'Particulars',"
                SQL &= "    Amount_4 AS 'Amount', 4 AS 'Sort'"
                SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
                SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

                SQL &= " UNION ALL SELECT"
                SQL &= "    ID,"
                SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
                SQL &= "    AccountNumber AS 'Document Number',"
                SQL &= "    CONCAT(TRIM(Payee),'/',Particular_5) AS 'Particulars',"
                SQL &= "    Amount_5 AS 'Amount', 5 AS 'Sort'"
                SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
                SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

                SQL &= " UNION ALL SELECT"
                SQL &= "    ID,"
                SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
                SQL &= "    AccountNumber AS 'Document Number',"
                SQL &= "    CONCAT(TRIM(Payee),'/',Particular_6) AS 'Particulars',"
                SQL &= "    Amount_6 AS 'Amount', 6 AS 'Sort'"
                SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
                SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

                SQL &= " UNION ALL SELECT"
                SQL &= "    ID,"
                SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
                SQL &= "    AccountNumber AS 'Document Number',"
                SQL &= "    CONCAT(TRIM(Payee),'/',Particular_7) AS 'Particulars',"
                SQL &= "    Amount_7 AS 'Amount', 7 AS 'Sort'"
                SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
                SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

                SQL &= " UNION ALL SELECT"
                SQL &= "    ID,"
                SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
                SQL &= "    AccountNumber AS 'Document Number',"
                SQL &= "    CONCAT(TRIM(Payee),'/',Particular_8) AS 'Particulars',"
                SQL &= "    Amount_8 AS 'Amount', 8 AS 'Sort'"
                SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
                SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

                SQL &= " UNION ALL SELECT"
                SQL &= "    ID,"
                SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
                SQL &= "    AccountNumber AS 'Document Number',"
                SQL &= "    CONCAT(TRIM(Payee),'/',Particular_9) AS 'Particulars',"
                SQL &= "    Amount_9 AS 'Amount', 9 AS 'Sort'"
                SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
                SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

                SQL &= " UNION ALL SELECT"
                SQL &= "    ID,"
                SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
                SQL &= "    AccountNumber AS 'Document Number',"
                SQL &= "    CONCAT(TRIM(Payee),'/',Particular_10) AS 'Particulars',"
                SQL &= "    Amount_10 AS 'Amount', 10 AS 'Sort'"
                SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
                SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

                SQL &= " UNION ALL SELECT"
                SQL &= "    ID,"
                SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
                SQL &= "    AccountNumber AS 'Document Number',"
                SQL &= "    CONCAT(TRIM(Payee),'/',Particular_11) AS 'Particulars',"
                SQL &= "    Amount_11 AS 'Amount', 11 AS 'Sort'"
                SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
                SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

                SQL &= " UNION ALL SELECT"
                SQL &= "    ID,"
                SQL &= "    DATE_FORMAT(Trans_Date, '%b %d, %Y') AS 'Date',"
                SQL &= "    AccountNumber AS 'Document Number',"
                SQL &= "    CONCAT(TRIM(Payee),'/',Particular_12) AS 'Particulars',"
                SQL &= "    Amount_12 AS 'Amount', 12 AS 'Sort'"
                SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
                SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}') A WHERE Amount > 0 AND `Document Number` IN ({1}) ORDER BY `Document Number`, `Sort`", Branch_ID, IncludeID)

                Dim DT_New As DataTable = DataSource(SQL)
                For x As Integer = 0 To DT_New.Rows.Count - 1
                    DT_Particular.Rows.Add(DT_New(x)("ID"), DT_New(x)("Date"), DT_New(x)("Document Number"), DT_New(x)("Particulars"), DT_New(x)("Amount"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 0, DT_Particular.Rows.Count)
                Next

                Dim TotalEx As Double
                Dim Total_1 As Double
                Dim Total_2 As Double
                Dim Total_3 As Double
                Dim Total_4 As Double
                Dim Total_5 As Double
                Dim Total_6 As Double
                Dim Total_7 As Double
                Dim Total_8 As Double
                Dim Total_9 As Double
                Dim Total_10 As Double
                Dim Total_11 As Double
                Dim Total_12 As Double
                Dim Total_13 As Double
                Dim Total_14 As Double
                Dim Total_15 As Double
                Dim Total_16 As Double
                Dim Total_17 As Double
                Dim Total_18 As Double
                Dim Total_19 As Double
                Dim Total_20 As Double
                Dim Total_21 As Double
                Dim Total_22 As Double
                Dim Total_23 As Double
                Dim Total_24 As Double
                Dim Total_25 As Double
                Dim Total_26 As Double
                Dim Total_27 As Double
                Dim Total_28 As Double
                Dim Total_29 As Double
                Dim Total_30 As Double
                Dim Total_31 As Double
                Dim Total_32 As Double
                Dim Total_33 As Double
                Dim Total_34 As Double
                Dim Total_35 As Double
                Dim Total_36 As Double
                Dim Total_37 As Double
                Dim Total_38 As Double
                Dim Total_39 As Double
                Dim Total_40 As Double
                For x As Integer = 0 To GridView2.RowCount - 1
                    If x > GridView2.RowCount - 1 Then
                        GoTo Here
                    End If
                    If DT_Particular(x)("Document Number") = "T O T A L" Then
                        GoTo Here
                    End If
                    TotalEx += CDbl(GridView2.GetRowCellValue(x, "Amount"))
                    Total_1 += +CDbl(DT_Particular(x)("Amount 1"))
                    Total_2 += CDbl(DT_Particular(x)("Amount 2"))
                    Total_3 += CDbl(DT_Particular(x)("Amount 3"))
                    Total_4 += CDbl(DT_Particular(x)("Amount 4"))
                    Total_5 += CDbl(DT_Particular(x)("Amount 5"))
                    Total_6 += CDbl(DT_Particular(x)("Amount 6"))
                    Total_7 += CDbl(DT_Particular(x)("Amount 7"))
                    Total_8 += CDbl(DT_Particular(x)("Amount 8"))
                    Total_9 += CDbl(DT_Particular(x)("Amount 9"))
                    Total_10 += CDbl(DT_Particular(x)("Amount 10"))
                    Total_11 += CDbl(DT_Particular(x)("Amount 11"))
                    Total_12 += CDbl(DT_Particular(x)("Amount 12"))
                    Total_13 += CDbl(DT_Particular(x)("Amount 13"))
                    Total_14 += CDbl(DT_Particular(x)("Amount 14"))
                    Total_15 += CDbl(DT_Particular(x)("Amount 15"))
                    Total_16 += CDbl(DT_Particular(x)("Amount 16"))
                    Total_17 += CDbl(DT_Particular(x)("Amount 17"))
                    Total_18 += CDbl(DT_Particular(x)("Amount 18"))
                    Total_19 += CDbl(DT_Particular(x)("Amount 19"))
                    Total_20 += CDbl(DT_Particular(x)("Amount 20"))
                    Total_21 += CDbl(DT_Particular(x)("Amount 21"))
                    Total_22 += CDbl(DT_Particular(x)("Amount 22"))
                    Total_23 += CDbl(DT_Particular(x)("Amount 23"))
                    Total_24 += CDbl(DT_Particular(x)("Amount 24"))
                    Total_25 += CDbl(DT_Particular(x)("Amount 25"))
                    Total_26 += CDbl(DT_Particular(x)("Amount 26"))
                    Total_27 += CDbl(DT_Particular(x)("Amount 27"))
                    Total_28 += CDbl(DT_Particular(x)("Amount 28"))
                    Total_29 += CDbl(DT_Particular(x)("Amount 29"))
                    Total_30 += CDbl(DT_Particular(x)("Amount 30"))
                    Total_31 += CDbl(DT_Particular(x)("Amount 31"))
                    Total_32 += CDbl(DT_Particular(x)("Amount 32"))
                    Total_33 += CDbl(DT_Particular(x)("Amount 33"))
                    Total_34 += CDbl(DT_Particular(x)("Amount 34"))
                    Total_35 += CDbl(DT_Particular(x)("Amount 35"))
                    Total_36 += CDbl(DT_Particular(x)("Amount 36"))
                    Total_37 += CDbl(DT_Particular(x)("Amount 37"))
                    Total_38 += CDbl(DT_Particular(x)("Amount 38"))
                    Total_39 += CDbl(DT_Particular(x)("Amount 39"))
                    Total_40 += CDbl(DT_Particular(x)("Amount 40"))
Here:
                Next
                For x As Integer = 0 To GridView2.RowCount - 1
                    If DT_Particular(x)("Document Number") = "T O T A L" Then
                        DT_Particular.Rows.RemoveAt(x)
                        Exit For
                    End If
                Next
                DT_Particular.Rows.Add(0, "", "T O T A L", "", TotalEx, Total_1, Total_2, Total_3, Total_4, Total_5, Total_6, Total_7, Total_8, Total_9, Total_10, Total_11, Total_12, Total_13, Total_14, Total_15, Total_16, Total_17, Total_18, Total_19, Total_20, Total_21, Total_22, Total_23, Total_24, Total_25, Total_26, Total_27, Total_28, Total_29, Total_30, Total_31, Total_32, Total_33, Total_34, Total_35, Total_36, Total_37, Total_38, Total_39, Total_40)
                dTotalExpense.Value = TotalEx
                MsgBox("Successfully Added!", MsgBoxStyle.Information, "Info")
            End If
            .Dispose()
        End With

        If GridView2.RowCount > 15 Then
            GridColumn19.Width = 412 - 17
        Else
            GridColumn19.Width = 412
        End If
    End Sub

    Private Sub IRemoveRow_Click(sender As Object, e As EventArgs) Handles iRemoveRow.Click
        If GridView2.RowCount = 0 Or GridView2.FocusedRowHandle = GridView2.RowCount - 1 Then
            Exit Sub
        End If
        Dim DocumentNumber As String = GridView2.GetFocusedRowCellValue("Document Number")
Here:

        For x As Integer = 0 To GridView2.RowCount - 1
            If GridView2.GetRowCellValue(x, "Document Number") = DocumentNumber Then
                DT_Particular.Rows.RemoveAt(x)
                GoTo Here
            End If
        Next
        Dim TotalEx As Double
        Dim Total_1 As Double
        Dim Total_2 As Double
        Dim Total_3 As Double
        Dim Total_4 As Double
        Dim Total_5 As Double
        Dim Total_6 As Double
        Dim Total_7 As Double
        Dim Total_8 As Double
        Dim Total_9 As Double
        Dim Total_10 As Double
        Dim Total_11 As Double
        Dim Total_12 As Double
        Dim Total_13 As Double
        Dim Total_14 As Double
        Dim Total_15 As Double
        Dim Total_16 As Double
        Dim Total_17 As Double
        Dim Total_18 As Double
        Dim Total_19 As Double
        Dim Total_20 As Double
        Dim Total_21 As Double
        Dim Total_22 As Double
        Dim Total_23 As Double
        Dim Total_24 As Double
        Dim Total_25 As Double
        Dim Total_26 As Double
        Dim Total_27 As Double
        Dim Total_28 As Double
        Dim Total_29 As Double
        Dim Total_30 As Double
        Dim Total_31 As Double
        Dim Total_32 As Double
        Dim Total_33 As Double
        Dim Total_34 As Double
        Dim Total_35 As Double
        Dim Total_36 As Double
        Dim Total_37 As Double
        Dim Total_38 As Double
        Dim Total_39 As Double
        Dim Total_40 As Double
        For x As Integer = 0 To GridView2.RowCount - 2
            DT_Particular(x)("No") = x + 1
            TotalEx += CDbl(GridView2.GetRowCellValue(x, "Amount"))
            Total_1 += CDbl(DT_Particular(x)("Amount 1"))
            Total_2 += CDbl(DT_Particular(x)("Amount 2"))
            Total_3 += CDbl(DT_Particular(x)("Amount 3"))
            Total_4 += CDbl(DT_Particular(x)("Amount 4"))
            Total_5 += CDbl(DT_Particular(x)("Amount 5"))
            Total_6 += CDbl(DT_Particular(x)("Amount 6"))
            Total_7 += CDbl(DT_Particular(x)("Amount 7"))
            Total_8 += CDbl(DT_Particular(x)("Amount 8"))
            Total_9 += CDbl(DT_Particular(x)("Amount 9"))
            Total_10 += CDbl(DT_Particular(x)("Amount 10"))
            Total_11 += CDbl(DT_Particular(x)("Amount 11"))
            Total_12 += CDbl(DT_Particular(x)("Amount 12"))
            Total_13 += CDbl(DT_Particular(x)("Amount 13"))
            Total_14 += CDbl(DT_Particular(x)("Amount 14"))
            Total_15 += CDbl(DT_Particular(x)("Amount 15"))
            Total_16 += CDbl(DT_Particular(x)("Amount 16"))
            Total_17 += CDbl(DT_Particular(x)("Amount 17"))
            Total_18 += CDbl(DT_Particular(x)("Amount 18"))
            Total_19 += CDbl(DT_Particular(x)("Amount 19"))
            Total_20 += CDbl(DT_Particular(x)("Amount 20"))
            Total_21 += CDbl(DT_Particular(x)("Amount 21"))
            Total_22 += CDbl(DT_Particular(x)("Amount 22"))
            Total_23 += CDbl(DT_Particular(x)("Amount 23"))
            Total_24 += CDbl(DT_Particular(x)("Amount 24"))
            Total_25 += CDbl(DT_Particular(x)("Amount 25"))
            Total_26 += CDbl(DT_Particular(x)("Amount 26"))
            Total_27 += CDbl(DT_Particular(x)("Amount 27"))
            Total_28 += CDbl(DT_Particular(x)("Amount 28"))
            Total_29 += CDbl(DT_Particular(x)("Amount 29"))
            Total_30 += CDbl(DT_Particular(x)("Amount 30"))
            Total_31 += CDbl(DT_Particular(x)("Amount 31"))
            Total_32 += CDbl(DT_Particular(x)("Amount 32"))
            Total_33 += CDbl(DT_Particular(x)("Amount 33"))
            Total_34 += CDbl(DT_Particular(x)("Amount 34"))
            Total_35 += CDbl(DT_Particular(x)("Amount 35"))
            Total_36 += CDbl(DT_Particular(x)("Amount 36"))
            Total_37 += CDbl(DT_Particular(x)("Amount 37"))
            Total_38 += CDbl(DT_Particular(x)("Amount 38"))
            Total_39 += CDbl(DT_Particular(x)("Amount 39"))
            Total_40 += CDbl(DT_Particular(x)("Amount 40"))
        Next
        dTotalExpense.Value = TotalEx
        DT_Particular.Rows.RemoveAt(DT_Particular.Rows.Count - 1)
        DT_Particular.Rows.Add(0, "", "T O T A L", "", TotalEx, Total_1, Total_2, Total_3, Total_4, Total_5, Total_6, Total_7, Total_8, Total_9, Total_10, Total_11, Total_12, Total_13, Total_14, Total_15, Total_16, Total_17, Total_18, Total_19, Total_20, Total_21, Total_22, Total_23, Total_24, Total_25, Total_26, Total_27, Total_28, Total_29, Total_30, Total_31, Total_32, Total_33, Total_34, Total_35, Total_36, Total_37, Total_38, Total_39, Total_40)

        If GridView2.RowCount > 15 Then
            GridColumn19.Width = 412 - 17
        Else
            GridColumn19.Width = 412
        End If
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        If e.Column.FieldName = "Amount 1" Or e.Column.FieldName = "Amount 2" Or e.Column.FieldName = "Amount 3" Or e.Column.FieldName = "Amount 4" Or e.Column.FieldName = "Amount 5" Or e.Column.FieldName = "Amount 6" Or e.Column.FieldName = "Amount 7" Or e.Column.FieldName = "Amount 8" Or e.Column.FieldName = "Amount 9" Or e.Column.FieldName = "Amount 10" Or e.Column.FieldName = "Amount 11" Or e.Column.FieldName = "Amount 12" Or e.Column.FieldName = "Amount 13" Or e.Column.FieldName = "Amount 14" Or e.Column.FieldName = "Amount 15" Or e.Column.FieldName = "Amount 16" Or e.Column.FieldName = "Amount 17" Or e.Column.FieldName = "Amount 18" Or e.Column.FieldName = "Amount 19" Or e.Column.FieldName = "Amount 20" Or e.Column.FieldName = "Amount 21" Or e.Column.FieldName = "Amount 22" Or e.Column.FieldName = "Amount 23" Or e.Column.FieldName = "Amount 24" Or e.Column.FieldName = "Amount 25" Or e.Column.FieldName = "Amount 26" Or e.Column.FieldName = "Amount 27" Or e.Column.FieldName = "Amount 28" Or e.Column.FieldName = "Amount 29" Or e.Column.FieldName = "Amount 30" Or e.Column.FieldName = "Amount 31" Or e.Column.FieldName = "Amount 32" Or e.Column.FieldName = "Amount 33" Or e.Column.FieldName = "Amount 34" Or e.Column.FieldName = "Amount 35" Or e.Column.FieldName = "Amount 36" Or e.Column.FieldName = "Amount 37" Or e.Column.FieldName = "Amount 38" Or e.Column.FieldName = "Amount 39" Or e.Column.FieldName = "Amount 40" Then
            With GridView2
                If .GetRowCellValue(.FocusedRowHandle, "Amount 1").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 1", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 2").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 2", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 3").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 3", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 4").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 4", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 5").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 5", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 6").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 6", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 7").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 7", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 8").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 8", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 9").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 9", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 10").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 10", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 11").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 11", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 12").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 12", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 13").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 13", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 14").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 14", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 15").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 15", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 16").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 16", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 17").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 17", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 18").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 18", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 19").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 19", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 20").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 20", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 21").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 21", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 22").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 22", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 23").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 23", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 24").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 24", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 25").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 25", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 26").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 26", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 27").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 27", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 28").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 28", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 29").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 29", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 30").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 30", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 31").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 31", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 32").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 32", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 33").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 33", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 34").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 34", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 35").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 35", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 36").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 36", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 37").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 37", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 38").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 38", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 39").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 39", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 40").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 40", 0)
                End If
            End With

            Dim TotalEx As Double
            Dim Total_1 As Double
            Dim Total_2 As Double
            Dim Total_3 As Double
            Dim Total_4 As Double
            Dim Total_5 As Double
            Dim Total_6 As Double
            Dim Total_7 As Double
            Dim Total_8 As Double
            Dim Total_9 As Double
            Dim Total_10 As Double
            Dim Total_11 As Double
            Dim Total_12 As Double
            Dim Total_13 As Double
            Dim Total_14 As Double
            Dim Total_15 As Double
            Dim Total_16 As Double
            Dim Total_17 As Double
            Dim Total_18 As Double
            Dim Total_19 As Double
            Dim Total_20 As Double
            Dim Total_21 As Double
            Dim Total_22 As Double
            Dim Total_23 As Double
            Dim Total_24 As Double
            Dim Total_25 As Double
            Dim Total_26 As Double
            Dim Total_27 As Double
            Dim Total_28 As Double
            Dim Total_29 As Double
            Dim Total_30 As Double
            Dim Total_31 As Double
            Dim Total_32 As Double
            Dim Total_33 As Double
            Dim Total_34 As Double
            Dim Total_35 As Double
            Dim Total_36 As Double
            Dim Total_37 As Double
            Dim Total_38 As Double
            Dim Total_39 As Double
            Dim Total_40 As Double
            DT_Particular.Rows.RemoveAt(DT_Particular.Rows.Count - 1)
            For x As Integer = 0 To DT_Particular.Rows.Count - 1
                TotalEx += CDbl(DT_Particular(x)("Amount"))
                Total_1 += CDbl(DT_Particular(x)("Amount 1"))
                Total_2 += CDbl(DT_Particular(x)("Amount 2"))
                Total_3 += CDbl(DT_Particular(x)("Amount 3"))
                Total_4 += CDbl(DT_Particular(x)("Amount 4"))
                Total_5 += CDbl(DT_Particular(x)("Amount 5"))
                Total_6 += CDbl(DT_Particular(x)("Amount 6"))
                Total_7 += CDbl(DT_Particular(x)("Amount 7"))
                Total_8 += CDbl(DT_Particular(x)("Amount 8"))
                Total_9 += CDbl(DT_Particular(x)("Amount 9"))
                Total_10 += CDbl(DT_Particular(x)("Amount 10"))
                Total_11 += CDbl(DT_Particular(x)("Amount 11"))
                Total_12 += CDbl(DT_Particular(x)("Amount 12"))
                Total_13 += CDbl(DT_Particular(x)("Amount 13"))
                Total_14 += CDbl(DT_Particular(x)("Amount 14"))
                Total_15 += CDbl(DT_Particular(x)("Amount 15"))
                Total_16 += CDbl(DT_Particular(x)("Amount 16"))
                Total_17 += CDbl(DT_Particular(x)("Amount 17"))
                Total_18 += CDbl(DT_Particular(x)("Amount 18"))
                Total_19 += CDbl(DT_Particular(x)("Amount 19"))
                Total_20 += CDbl(DT_Particular(x)("Amount 20"))
                Total_21 += CDbl(DT_Particular(x)("Amount 21"))
                Total_22 += CDbl(DT_Particular(x)("Amount 22"))
                Total_23 += CDbl(DT_Particular(x)("Amount 23"))
                Total_24 += CDbl(DT_Particular(x)("Amount 24"))
                Total_25 += CDbl(DT_Particular(x)("Amount 25"))
                Total_26 += CDbl(DT_Particular(x)("Amount 26"))
                Total_27 += CDbl(DT_Particular(x)("Amount 27"))
                Total_28 += CDbl(DT_Particular(x)("Amount 28"))
                Total_29 += CDbl(DT_Particular(x)("Amount 29"))
                Total_30 += CDbl(DT_Particular(x)("Amount 30"))
                Total_31 += CDbl(DT_Particular(x)("Amount 31"))
                Total_32 += CDbl(DT_Particular(x)("Amount 32"))
                Total_33 += CDbl(DT_Particular(x)("Amount 33"))
                Total_34 += CDbl(DT_Particular(x)("Amount 34"))
                Total_35 += CDbl(DT_Particular(x)("Amount 35"))
                Total_36 += CDbl(DT_Particular(x)("Amount 36"))
                Total_37 += CDbl(DT_Particular(x)("Amount 37"))
                Total_38 += CDbl(DT_Particular(x)("Amount 38"))
                Total_39 += CDbl(DT_Particular(x)("Amount 39"))
                Total_40 += CDbl(DT_Particular(x)("Amount 40"))
            Next
            DT_Particular.Rows.Add(0, "", "T O T A L", "", TotalEx, Total_1, Total_2, Total_3, Total_4, Total_5, Total_6, Total_7, Total_8, Total_9, Total_10, Total_11, Total_12, Total_13, Total_14, Total_15, Total_16, Total_17, Total_18, Total_19, Total_20, Total_21, Total_22, Total_23, Total_24, Total_25, Total_26, Total_27, Total_28, Total_29, Total_30, Total_31, Total_32, Total_33, Total_34, Total_35, Total_36, Total_37, Total_38, Total_39, Total_40)
        End If
    End Sub

    Private Sub BtnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Dim Signatory As Boolean = False
        For x As Integer = 0 To DT_Signatory.Rows.Count - 1
            If ComparePosition({DT_Signatory(x)("PositionID")}, True) And DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                Signatory = True
                Exit For
            End If
        Next

        If (User_EmplID = Empl_ID Or cbxPreparedBy.SelectedValue = Empl_ID) And Signatory = False Then
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code_Check
                .lblBilling.Visible = False
                If .ShowDialog = DialogResult.OK Then
                    Dim Provider As New FrmOTACProvider
                    With Provider
                        .cbxProvider.DisplayMember = "Employee"
                        .cbxProvider.ValueMember = "EmplID"
                        .cbxProvider.DataSource = DataSource(String.Format("SELECT E.ID AS 'EmplID', Employee(E.ID) AS 'Employee' FROM employee_setup E INNER JOIN (SELECT * FROM signatory_setup WHERE `status` = 'ACTIVE' AND BranchID = '{2}') S ON S.PositionID = E.position_id WHERE S.ButtonID = '{0}' AND S.FormID = '{1}' AND E.Branch_ID = '{2}' AND E.`status` = 'ACTIVE';", btnCheck.Tag, Tag, Branch_ID))
                        If .ShowDialog = DialogResult.OK Then
                            Code = GenerateOTAC()
                            Code_Approve = Code
                            Dim Msg As String = ""
                            Dim EmailTo As String = ""
                            Dim Subject As String = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                            Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                                If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                                    Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Petty Cash Replenishment with the amount of {1} prepared by {2}." & vbCrLf, Code, dTotalExpense.Text, cbxPreparedBy.Text)
                                    Msg &= "Thank you!"
                                    '******* SEND SMS *********************************************************************************
                                    If DT_Signatory(x)("Phone") = "" Then
                                    Else
                                        SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                                    End If
                                    '******* SEND EMAIL *********************************************************************************
                                    If DT_Signatory(x)("EmailAdd") = "" Then
                                    Else
                                        EmailTo = EmailTo & DT_Signatory(x)("EmailAdd") & ", "
                                    End If
                                End If
                            Next
                            If EmailTo = "" Then
                            Else
                                Subject = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                                AttachmentFiles = New ArrayList()
                                FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                Generate_Receipt(False, FName)
                                AttachmentFiles.Add(FName)
                                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                            End If

                            DataObject(String.Format("UPDATE replenishment_cash SET `ReplenishStatus` = 'CHECKED', CheckedID = '{1}', Approve_OTAC = '{2}' WHERE ID = '{0}';", ID, .cbxProvider.SelectedValue, Code))
                            Logs("Replenishment", "Check", String.Format("Checked Petty Cash Replenishment {1} with the total amount of {0}. [Via OTAC]", dTotalExpense.Text, txtAccountNumber.Text), "", "", "", "")
                            MsgBox("Successfully Checked!" & mEmail, MsgBoxStyle.Information, "Info")
                            Clear(True)
                        End If
                        .Dispose()
                    End With
                End If
            End With
        Else
            If MsgBoxYes("Are you sure you check this Petty Cash Replenishment?") = MsgBoxResult.Yes Then
                Code = GenerateOTAC()
                Code_Approve = Code
                Dim Msg As String = ""
                Dim EmailTo As String = ""
                Dim Subject As String = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                    If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                        Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                        Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Petty Cash Replenishment with the amount of {1} prepared by {2}." & vbCrLf, Code, dTotalExpense.Text, cbxPreparedBy.Text)
                        Msg &= "Thank you!"
                        '******* SEND SMS *********************************************************************************
                        If DT_Signatory(x)("Phone") = "" Then
                        Else
                            SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                        End If
                        '******* SEND EMAIL *********************************************************************************
                        If DT_Signatory(x)("EmailAdd") = "" Then
                        Else
                            EmailTo = EmailTo & DT_Signatory(x)("EmailAdd") & ", "
                        End If
                    End If
                Next
                If EmailTo = "" Then
                Else
                    Subject = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                    AttachmentFiles = New ArrayList()
                    FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    Generate_Receipt(False, FName)
                    AttachmentFiles.Add(FName)
                    SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                End If

                DataObject(String.Format("UPDATE replenishment_cash SET `ReplenishStatus` = 'CHECKED', CheckedID = '{1}', Approve_OTAC = '{2}' WHERE ID = '{0}';", ID, Empl_ID, Code))
                Logs("Replenishment", "Check", String.Format("Checked Petty Cash Replenishment {1} with the total amount of {0}.", dTotalExpense.Text, txtAccountNumber.Text), "", "", "", "")
                MsgBox("Successfully Checked!" & mEmail, MsgBoxStyle.Information, "Info")
                Clear(True)
            End If
        End If
    End Sub

    Private Sub BtnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim Signatory As Boolean = False
        For x As Integer = 0 To DT_Signatory.Rows.Count - 1
            If ComparePosition({DT_Signatory(x)("PositionID")}, True) And DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                Signatory = True
                Exit For
            End If
        Next

        If (User_EmplID = Empl_ID Or cbxPreparedBy.SelectedValue = Empl_ID) And Signatory = False Then
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code_Approve
                .lblBilling.Visible = False
                If .ShowDialog = DialogResult.OK Then
                    Dim Provider As New FrmOTACProvider
                    With Provider
                        .cbxProvider.DisplayMember = "Employee"
                        .cbxProvider.ValueMember = "EmplID"
                        .cbxProvider.DataSource = DataSource(String.Format("SELECT E.ID AS 'EmplID', Employee(E.ID) AS 'Employee' FROM employee_setup E INNER JOIN (SELECT * FROM signatory_setup WHERE `status` = 'ACTIVE' AND BranchID = '{2}') S ON S.PositionID = E.position_id WHERE S.ButtonID = '{0}' AND S.FormID = '{1}' AND E.Branch_ID = '{2}' AND E.`status` = 'ACTIVE';", btnApprove.Tag, Tag, Branch_ID))
                        If .ShowDialog = DialogResult.OK Then
                            DataObject(String.Format("UPDATE replenishment_cash SET `ReplenishStatus` = 'APPROVED', ApprovedID = '{1}' WHERE ID = '{0}';", ID, .cbxProvider.SelectedValue))
                            Logs("Replenishment", "Approve", String.Format("Approved Petty Cash Replenishment {1} with the total amount of {0}. [Via OTAC]", dTotalExpense.Text, txtAccountNumber.Text), "", "", "", "")
                            MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                            Clear(True)
                        End If
                        .Dispose()
                    End With
                End If
            End With
        Else
            If MsgBoxYes("Are you sure you want to approve this Petty Cash Replenishment?") = MsgBoxResult.Yes Then
                DataObject(String.Format("UPDATE replenishment_cash SET `ReplenishStatus` = 'APPROVED', ApprovedID = '{1}' WHERE ID = '{0}';", ID, Empl_ID, Code))
                Logs("Replenishment", "Approve", String.Format("Approved Petty Cash Replenishment {1} with the total amount of {0}.", dTotalExpense.Text, txtAccountNumber.Text), "", "", "", "")
                MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                Clear(True)
            End If
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
            .FolderName = "Replenishment-" & GridView1.GetFocusedRowCellValue("Document Number")
            .RepNumber = GridView1.GetFocusedRowCellValue("Document Number")
            .TotalImage = GridView1.GetFocusedRowCellValue("Attach")
            .ID = GridView1.GetFocusedRowCellValue("Document Number")
            .Type = "Replenishment"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                GridView1.SetFocusedRowCellValue("Attach", .TotalImage)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnDisapprove_Click(sender As Object, e As EventArgs) Handles btnDisapprove.Click
        If vDelete Then
        Else
            MsgBox(mBox_Delete, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes("Are you sure you want to disapprove this Liquidation of Expenses?") = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            DataObject(String.Format("UPDATE replenishment_cash SET `status` = 'DISAPPROVED' WHERE ID = '{0}'; UPDATE cash_advance SET ReplenishedID = 0 WHERE ReplenishedID = {0}; UPDATE petty_cash SET ReplenishedID = 0 WHERE ReplenishedID = {0};", ID))
            Logs("Replenishment", "Disapprove", Reason, String.Format("Disapproved Petty Cash Replenishment {1} with total expense of {0}.", dTotalExpense.Text, txtAccountNumber.Text), "", "", "")
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Disapproved", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnAddCol_Click(sender As Object, e As EventArgs) Handles btnAddCol.Click
        Dim Caption As New FrmSelectGL
        Caption.btnAdd.Text = "Add    Account"

        If Columns = 4 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn25.Caption = Caption.cbxAccount.Text
                GridColumn25.Tag = Caption.cbxAccount.SelectedValue
                Columns = 5

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                btnRemoveCol.Enabled = True
            End If
        ElseIf Columns = 5 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn26.Caption = Caption.cbxAccount.Text
                GridColumn26.Tag = Caption.cbxAccount.SelectedValue
                Columns = 6

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
            End If
        ElseIf Columns = 6 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn27.Caption = Caption.cbxAccount.Text
                GridColumn27.Tag = Caption.cbxAccount.SelectedValue
                Columns = 7

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
            End If
        ElseIf Columns = 7 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn28.Caption = Caption.cbxAccount.Text
                GridColumn28.Tag = Caption.cbxAccount.SelectedValue
                Columns = 8

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
            End If
        ElseIf Columns = 8 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn29.Caption = Caption.cbxAccount.Text
                GridColumn29.Tag = Caption.cbxAccount.SelectedValue
                Columns = 9

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
            End If
        ElseIf Columns = 9 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn31.Caption = Caption.cbxAccount.Text
                GridColumn31.Tag = Caption.cbxAccount.SelectedValue
                Columns = 10

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
            End If
        ElseIf Columns = 10 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn41.Caption = Caption.cbxAccount.Text
                GridColumn41.Tag = Caption.cbxAccount.SelectedValue
                Columns = 11

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
            End If
        ElseIf Columns = 11 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn32.Caption = Caption.cbxAccount.Text
                GridColumn32.Tag = Caption.cbxAccount.SelectedValue
                Columns = 12

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
            End If
        ElseIf Columns = 12 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn33.Caption = Caption.cbxAccount.Text
                GridColumn33.Tag = Caption.cbxAccount.SelectedValue
                Columns = 13

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
            End If
        ElseIf Columns = 13 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn34.Caption = Caption.cbxAccount.Text
                GridColumn34.Tag = Caption.cbxAccount.SelectedValue
                Columns = 14

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
            End If
        ElseIf Columns = 14 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn35.Caption = Caption.cbxAccount.Text
                GridColumn35.Tag = Caption.cbxAccount.SelectedValue
                Columns = 15

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
            End If
        ElseIf Columns = 15 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn36.Caption = Caption.cbxAccount.Text
                GridColumn36.Tag = Caption.cbxAccount.SelectedValue
                Columns = 16

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
            End If
        ElseIf Columns = 16 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn37.Caption = Caption.cbxAccount.Text
                GridColumn37.Tag = Caption.cbxAccount.SelectedValue
                Columns = 17

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
                GridColumn37.VisibleIndex = 20 + 1 '17
            End If
        ElseIf Columns = 17 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn38.Caption = Caption.cbxAccount.Text
                GridColumn38.Tag = Caption.cbxAccount.SelectedValue
                Columns = 18

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
                GridColumn37.VisibleIndex = 20 + 1 '17
                GridColumn38.VisibleIndex = 21 + 1 '18
            End If
        ElseIf Columns = 18 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn39.Caption = Caption.cbxAccount.Text
                GridColumn39.Tag = Caption.cbxAccount.SelectedValue
                Columns = 19

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
                GridColumn37.VisibleIndex = 20 + 1 '17
                GridColumn38.VisibleIndex = 21 + 1 '18
                GridColumn39.VisibleIndex = 22 + 1 '19
            End If
        ElseIf Columns = 19 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn40.Caption = Caption.cbxAccount.Text
                GridColumn40.Tag = Caption.cbxAccount.SelectedValue
                Columns = 20

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 ' + 19
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
                GridColumn37.VisibleIndex = 20 + 1 '17
                GridColumn38.VisibleIndex = 21 + 1 '18
                GridColumn39.VisibleIndex = 22 + 1 '19
                GridColumn40.VisibleIndex = 23 + 1 '20 
            End If
        ElseIf Columns = 20 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn15.Caption = Caption.cbxAccount.Text
                GridColumn15.Tag = Caption.cbxAccount.SelectedValue
                Columns = 21

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
                GridColumn37.VisibleIndex = 20 + 1 '17
                GridColumn38.VisibleIndex = 21 + 1 '18
                GridColumn39.VisibleIndex = 22 + 1 '19
                GridColumn40.VisibleIndex = 23 + 1 '20 
                GridColumn15.VisibleIndex = 24 + 1 '21
            End If
        ElseIf Columns = 21 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn42.Caption = Caption.cbxAccount.Text
                GridColumn42.Tag = Caption.cbxAccount.SelectedValue
                Columns = 22

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
                GridColumn37.VisibleIndex = 20 + 1 '17
                GridColumn38.VisibleIndex = 21 + 1 '18
                GridColumn39.VisibleIndex = 22 + 1 '19
                GridColumn40.VisibleIndex = 23 + 1 '20 
                GridColumn15.VisibleIndex = 24 + 1 '21
                GridColumn42.VisibleIndex = 25 + 1 '22
            End If
        ElseIf Columns = 22 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn43.Caption = Caption.cbxAccount.Text
                GridColumn43.Tag = Caption.cbxAccount.SelectedValue
                Columns = 23

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
                GridColumn37.VisibleIndex = 20 + 1 '17
                GridColumn38.VisibleIndex = 21 + 1 '18
                GridColumn39.VisibleIndex = 22 + 1 '19
                GridColumn40.VisibleIndex = 23 + 1 '20 
                GridColumn15.VisibleIndex = 24 + 1 '21
                GridColumn42.VisibleIndex = 25 + 1 '22
                GridColumn43.VisibleIndex = 26 + 1 '23
            End If
        ElseIf Columns = 23 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn44.Caption = Caption.cbxAccount.Text
                GridColumn44.Tag = Caption.cbxAccount.SelectedValue
                Columns = 24

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
                GridColumn37.VisibleIndex = 20 + 1 '17
                GridColumn38.VisibleIndex = 21 + 1 '18
                GridColumn39.VisibleIndex = 22 + 1 '19
                GridColumn40.VisibleIndex = 23 + 1 '20 
                GridColumn15.VisibleIndex = 24 + 1 '21
                GridColumn42.VisibleIndex = 25 + 1 '22
                GridColumn43.VisibleIndex = 26 + 1 '23
                GridColumn44.VisibleIndex = 27 + 1 '24
            End If
        ElseIf Columns = 24 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn45.Caption = Caption.cbxAccount.Text
                GridColumn45.Tag = Caption.cbxAccount.SelectedValue
                Columns = 25

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
                GridColumn37.VisibleIndex = 20 + 1 '17
                GridColumn38.VisibleIndex = 21 + 1 '18
                GridColumn39.VisibleIndex = 22 + 1 '19
                GridColumn40.VisibleIndex = 23 + 1 '20 
                GridColumn15.VisibleIndex = 24 + 1 '21
                GridColumn42.VisibleIndex = 25 + 1 '22
                GridColumn43.VisibleIndex = 26 + 1 '23
                GridColumn44.VisibleIndex = 27 + 1 '24
                GridColumn45.VisibleIndex = 28 + 1 '25
            End If
        ElseIf Columns = 25 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn46.Caption = Caption.cbxAccount.Text
                GridColumn46.Tag = Caption.cbxAccount.SelectedValue
                Columns = 26

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
                GridColumn37.VisibleIndex = 20 + 1 '17
                GridColumn38.VisibleIndex = 21 + 1 '18
                GridColumn39.VisibleIndex = 22 + 1 '19
                GridColumn40.VisibleIndex = 23 + 1 '20 
                GridColumn15.VisibleIndex = 24 + 1 '21
                GridColumn42.VisibleIndex = 25 + 1 '22
                GridColumn43.VisibleIndex = 26 + 1 '23
                GridColumn44.VisibleIndex = 27 + 1 '24
                GridColumn45.VisibleIndex = 28 + 1 '25
                GridColumn46.VisibleIndex = 29 + 1 '26
            End If
        ElseIf Columns = 26 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn47.Caption = Caption.cbxAccount.Text
                GridColumn47.Tag = Caption.cbxAccount.SelectedValue
                Columns = 27

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
                GridColumn37.VisibleIndex = 20 + 1 '17
                GridColumn38.VisibleIndex = 21 + 1 '18
                GridColumn39.VisibleIndex = 22 + 1 '19
                GridColumn40.VisibleIndex = 23 + 1 '20 
                GridColumn15.VisibleIndex = 24 + 1 '21
                GridColumn42.VisibleIndex = 25 + 1 '22
                GridColumn43.VisibleIndex = 26 + 1 '23
                GridColumn44.VisibleIndex = 27 + 1 '24
                GridColumn45.VisibleIndex = 28 + 1 '25
                GridColumn46.VisibleIndex = 29 + 1 '26
                GridColumn47.VisibleIndex = 30 + 1 '27
            End If
        ElseIf Columns = 27 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn48.Caption = Caption.cbxAccount.Text
                GridColumn48.Tag = Caption.cbxAccount.SelectedValue
                Columns = 28

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
                GridColumn37.VisibleIndex = 20 + 1 '17
                GridColumn38.VisibleIndex = 21 + 1 '18
                GridColumn39.VisibleIndex = 22 + 1 '19
                GridColumn40.VisibleIndex = 23 + 1 '20 
                GridColumn15.VisibleIndex = 24 + 1 '21
                GridColumn42.VisibleIndex = 25 + 1 '22
                GridColumn43.VisibleIndex = 26 + 1 '23
                GridColumn44.VisibleIndex = 27 + 1 '24
                GridColumn45.VisibleIndex = 28 + 1 '25
                GridColumn46.VisibleIndex = 29 + 1 '26
                GridColumn47.VisibleIndex = 30 + 1 '27
                GridColumn48.VisibleIndex = 31 + 1 '28
            End If
        ElseIf Columns = 28 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn49.Caption = Caption.cbxAccount.Text
                GridColumn49.Tag = Caption.cbxAccount.SelectedValue
                Columns = 29

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
                GridColumn37.VisibleIndex = 20 ' + 117
                GridColumn38.VisibleIndex = 21 + 1 '18
                GridColumn39.VisibleIndex = 22 + 1 '19
                GridColumn40.VisibleIndex = 23 + 1 '20 
                GridColumn15.VisibleIndex = 24 + 1 '21
                GridColumn42.VisibleIndex = 25 + 1 '22
                GridColumn43.VisibleIndex = 26 + 1 '23
                GridColumn44.VisibleIndex = 27 + 1 '24
                GridColumn45.VisibleIndex = 28 + 1 '25
                GridColumn46.VisibleIndex = 29 + 1 '26
                GridColumn47.VisibleIndex = 30 + 1 '27
                GridColumn48.VisibleIndex = 31 + 1 '28
                GridColumn49.VisibleIndex = 32 + 1 '29
            End If
        ElseIf Columns = 29 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn50.Caption = Caption.cbxAccount.Text
                GridColumn50.Tag = Caption.cbxAccount.SelectedValue
                Columns = 30

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
                GridColumn37.VisibleIndex = 20 + 1 '17
                GridColumn38.VisibleIndex = 21 + 1 '18
                GridColumn39.VisibleIndex = 22 + 1 '19
                GridColumn40.VisibleIndex = 23 + 1 '20 
                GridColumn15.VisibleIndex = 24 + 1 '21
                GridColumn42.VisibleIndex = 25 + 1 '22
                GridColumn43.VisibleIndex = 26 + 1 '23
                GridColumn44.VisibleIndex = 27 + 1 '24
                GridColumn45.VisibleIndex = 28 + 1 '25
                GridColumn46.VisibleIndex = 29 + 1 '26
                GridColumn47.VisibleIndex = 30 + 1 '27
                GridColumn48.VisibleIndex = 31 + 1 '28
                GridColumn49.VisibleIndex = 32 + 1 '29
                GridColumn50.VisibleIndex = 33 + 1 '30
            End If
        ElseIf Columns = 30 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn51.Caption = Caption.cbxAccount.Text
                GridColumn51.Tag = Caption.cbxAccount.SelectedValue
                Columns = 31

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
                GridColumn37.VisibleIndex = 20 + 1 '17
                GridColumn38.VisibleIndex = 21 + 1 '18
                GridColumn39.VisibleIndex = 22 + 1 '19
                GridColumn40.VisibleIndex = 23 + 1 '20 
                GridColumn15.VisibleIndex = 24 + 1 '21
                GridColumn42.VisibleIndex = 25 + 1 '22
                GridColumn43.VisibleIndex = 26 + 1 '23
                GridColumn44.VisibleIndex = 27 + 1 '24
                GridColumn45.VisibleIndex = 28 + 1 '25
                GridColumn46.VisibleIndex = 29 + 1 '26
                GridColumn47.VisibleIndex = 30 + 1 '27
                GridColumn48.VisibleIndex = 31 + 1 '28
                GridColumn49.VisibleIndex = 32 + 1 '29
                GridColumn50.VisibleIndex = 33 + 1 '30
                GridColumn51.VisibleIndex = 34 + 1 '31
            End If
        ElseIf Columns = 31 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn52.Caption = Caption.cbxAccount.Text
                GridColumn52.Tag = Caption.cbxAccount.SelectedValue
                Columns = 32

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
                GridColumn37.VisibleIndex = 20 + 1 '17
                GridColumn38.VisibleIndex = 21 + 1 '18
                GridColumn39.VisibleIndex = 22 + 1 '19
                GridColumn40.VisibleIndex = 23 + 1 '20 
                GridColumn15.VisibleIndex = 24 + 1 '21
                GridColumn42.VisibleIndex = 25 + 1 '22
                GridColumn43.VisibleIndex = 26 + 1 '23
                GridColumn44.VisibleIndex = 27 + 1 '24
                GridColumn45.VisibleIndex = 28 + 1 '25
                GridColumn46.VisibleIndex = 29 + 1 '26
                GridColumn47.VisibleIndex = 30 + 1 '27
                GridColumn48.VisibleIndex = 31 + 1 '28
                GridColumn49.VisibleIndex = 32 + 1 '29
                GridColumn50.VisibleIndex = 33 + 1 '30
                GridColumn51.VisibleIndex = 34 + 1 '31
                GridColumn52.VisibleIndex = 35 + 1 '32
            End If
        ElseIf Columns = 32 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn53.Caption = Caption.cbxAccount.Text
                GridColumn53.Tag = Caption.cbxAccount.SelectedValue
                Columns = 33

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 16 + 1 '13
                GridColumn34.VisibleIndex = 17 + 1 '14
                GridColumn35.VisibleIndex = 18 + 1 '15
                GridColumn36.VisibleIndex = 19 + 1 '16
                GridColumn37.VisibleIndex = 20 + 1 '17
                GridColumn38.VisibleIndex = 21 + 1 '18
                GridColumn39.VisibleIndex = 22 + 1 '19
                GridColumn40.VisibleIndex = 23 + 1 '20 
                GridColumn15.VisibleIndex = 24 + 1 '21
                GridColumn42.VisibleIndex = 25 + 1 '22
                GridColumn43.VisibleIndex = 26 + 1 '23
                GridColumn44.VisibleIndex = 27 + 1 '24
                GridColumn45.VisibleIndex = 28 + 1 '25
                GridColumn46.VisibleIndex = 29 + 1 '26
                GridColumn47.VisibleIndex = 30 + 1 '27
                GridColumn48.VisibleIndex = 31 + 1 '28
                GridColumn49.VisibleIndex = 32 + 1 '29
                GridColumn50.VisibleIndex = 33 + 1 '30
                GridColumn51.VisibleIndex = 34 + 1 '31
                GridColumn52.VisibleIndex = 35 + 1 '32
                GridColumn53.VisibleIndex = 36 + 1 '33
            End If
        ElseIf Columns = 33 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn54.Caption = Caption.cbxAccount.Text
                GridColumn54.Tag = Caption.cbxAccount.SelectedValue
                Columns = 34

                GridColumn21.VisibleIndex = 4 + 1 '1
                GridColumn22.VisibleIndex = 5 + 1 '2
                GridColumn23.VisibleIndex = 6 + 1 '3
                GridColumn24.VisibleIndex = 7 + 1 '4
                GridColumn25.VisibleIndex = 8 + 1 '5
                GridColumn26.VisibleIndex = 9 + 1 '6
                GridColumn27.VisibleIndex = 10 + 1 '7
                GridColumn28.VisibleIndex = 11 + 1 '8
                GridColumn29.VisibleIndex = 12 + 1 '9
                GridColumn31.VisibleIndex = 13 + 1 '10
                GridColumn41.VisibleIndex = 14 + 1 '11
                GridColumn32.VisibleIndex = 15 + 1 '12
                GridColumn33.VisibleIndex = 1 + 16 '13
                GridColumn34.VisibleIndex = 1 + 17 '14
                GridColumn35.VisibleIndex = 1 + 18 '15
                GridColumn36.VisibleIndex = 1 + 19 '16
                GridColumn37.VisibleIndex = 1 + 20 '17
                GridColumn38.VisibleIndex = 1 + 21 '18
                GridColumn39.VisibleIndex = 1 + 22 '19
                GridColumn40.VisibleIndex = 1 + 23 '20 
                GridColumn15.VisibleIndex = 1 + 24 '21
                GridColumn42.VisibleIndex = 1 + 25 '22
                GridColumn43.VisibleIndex = 1 + 26 '23
                GridColumn44.VisibleIndex = 1 + 27 '24
                GridColumn45.VisibleIndex = 1 + 28 '25
                GridColumn46.VisibleIndex = 1 + 29 '26
                GridColumn47.VisibleIndex = 1 + 30 '27
                GridColumn48.VisibleIndex = 1 + 31 '28
                GridColumn49.VisibleIndex = 1 + 32 '29
                GridColumn50.VisibleIndex = 1 + 33 '30
                GridColumn51.VisibleIndex = 1 + 34 '31
                GridColumn52.VisibleIndex = 1 + 35 '32
                GridColumn53.VisibleIndex = 1 + 36 '33
                GridColumn54.VisibleIndex = 1 + 37 '34
            End If
        ElseIf Columns = 34 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn55.Caption = Caption.cbxAccount.Text
                GridColumn55.Tag = Caption.cbxAccount.SelectedValue
                Columns = 35

                GridColumn21.VisibleIndex = 1 + 4 '1
                GridColumn22.VisibleIndex = 1 + 5 '2
                GridColumn23.VisibleIndex = 1 + 6 '3
                GridColumn24.VisibleIndex = 1 + 7 '4
                GridColumn25.VisibleIndex = 1 + 8 '5
                GridColumn26.VisibleIndex = 1 + 9 '6
                GridColumn27.VisibleIndex = 1 + 10 '7
                GridColumn28.VisibleIndex = 1 + 11 '8
                GridColumn29.VisibleIndex = 1 + 12 '9
                GridColumn31.VisibleIndex = 1 + 13 '10
                GridColumn41.VisibleIndex = 1 + 14 '11
                GridColumn32.VisibleIndex = 1 + 15 '12
                GridColumn33.VisibleIndex = 1 + 16 '13
                GridColumn34.VisibleIndex = 1 + 17 '14
                GridColumn35.VisibleIndex = 1 + 18 '15
                GridColumn36.VisibleIndex = 1 + 19 '16
                GridColumn37.VisibleIndex = 1 + 20 '17
                GridColumn38.VisibleIndex = 1 + 21 '18
                GridColumn39.VisibleIndex = 1 + 22 '19
                GridColumn40.VisibleIndex = 1 + 23 '20 
                GridColumn15.VisibleIndex = 1 + 24 '21
                GridColumn42.VisibleIndex = 1 + 25 '22
                GridColumn43.VisibleIndex = 1 + 26 '23
                GridColumn44.VisibleIndex = 1 + 27 '24
                GridColumn45.VisibleIndex = 1 + 28 '25
                GridColumn46.VisibleIndex = 1 + 29 '26
                GridColumn47.VisibleIndex = 1 + 30 '27
                GridColumn48.VisibleIndex = 1 + 31 '28
                GridColumn49.VisibleIndex = 1 + 32 '29
                GridColumn50.VisibleIndex = 1 + 33 '30
                GridColumn51.VisibleIndex = 1 + 34 '31
                GridColumn52.VisibleIndex = 1 + 35 '32
                GridColumn53.VisibleIndex = 1 + 36 '33
                GridColumn54.VisibleIndex = 1 + 37 '34
                GridColumn55.VisibleIndex = 1 + 38 '35
            End If
        ElseIf Columns = 35 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn56.Caption = Caption.cbxAccount.Text
                GridColumn56.Tag = Caption.cbxAccount.SelectedValue
                Columns = 36

                GridColumn21.VisibleIndex = 1 + 4 '1
                GridColumn22.VisibleIndex = 1 + 5 '2
                GridColumn23.VisibleIndex = 1 + 6 '3
                GridColumn24.VisibleIndex = 1 + 7 '4
                GridColumn25.VisibleIndex = 1 + 8 '5
                GridColumn26.VisibleIndex = 1 + 9 '6
                GridColumn27.VisibleIndex = 1 + 10 '7
                GridColumn28.VisibleIndex = 1 + 11 '8
                GridColumn29.VisibleIndex = 1 + 12 '9
                GridColumn31.VisibleIndex = 1 + 13 '10
                GridColumn41.VisibleIndex = 1 + 14 '11
                GridColumn32.VisibleIndex = 1 + 15 '12
                GridColumn33.VisibleIndex = 1 + 16 '13
                GridColumn34.VisibleIndex = 1 + 17 '14
                GridColumn35.VisibleIndex = 1 + 18 '15
                GridColumn36.VisibleIndex = 1 + 19 '16
                GridColumn37.VisibleIndex = 1 + 20 '17
                GridColumn38.VisibleIndex = 1 + 21 '18
                GridColumn39.VisibleIndex = 1 + 22 '19
                GridColumn40.VisibleIndex = 1 + 23 '20 
                GridColumn15.VisibleIndex = 1 + 24 '21
                GridColumn42.VisibleIndex = 1 + 25 '22
                GridColumn43.VisibleIndex = 1 + 26 '23
                GridColumn44.VisibleIndex = 1 + 27 '24
                GridColumn45.VisibleIndex = 1 + 28 '25
                GridColumn46.VisibleIndex = 1 + 29 '26
                GridColumn47.VisibleIndex = 1 + 30 '27
                GridColumn48.VisibleIndex = 1 + 31 '28
                GridColumn49.VisibleIndex = 1 + 32 '29
                GridColumn50.VisibleIndex = 1 + 33 '30
                GridColumn51.VisibleIndex = 1 + 34 '31
                GridColumn52.VisibleIndex = 1 + 35 '32
                GridColumn53.VisibleIndex = 1 + 36 '33
                GridColumn54.VisibleIndex = 1 + 37 '34
                GridColumn55.VisibleIndex = 1 + 38 '35
                GridColumn56.VisibleIndex = 1 + 39 '36
            End If
        ElseIf Columns = 36 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn57.Caption = Caption.cbxAccount.Text
                GridColumn57.Tag = Caption.cbxAccount.SelectedValue
                Columns = 37

                GridColumn21.VisibleIndex = 1 + 4 '1
                GridColumn22.VisibleIndex = 1 + 5 '2
                GridColumn23.VisibleIndex = 1 + 6 '3
                GridColumn24.VisibleIndex = 1 + 7 '4
                GridColumn25.VisibleIndex = 1 + 8 '5
                GridColumn26.VisibleIndex = 1 + 9 '6
                GridColumn27.VisibleIndex = 1 + 10 '7
                GridColumn28.VisibleIndex = 1 + 11 '8
                GridColumn29.VisibleIndex = 1 + 12 '9
                GridColumn31.VisibleIndex = 1 + 13 '10
                GridColumn41.VisibleIndex = 1 + 14 '11
                GridColumn32.VisibleIndex = 1 + 15 '12
                GridColumn33.VisibleIndex = 1 + 16 '13
                GridColumn34.VisibleIndex = 1 + 17 '14
                GridColumn35.VisibleIndex = 1 + 18 '15
                GridColumn36.VisibleIndex = 1 + 19 '16
                GridColumn37.VisibleIndex = 1 + 20 '17
                GridColumn38.VisibleIndex = 1 + 21 '18
                GridColumn39.VisibleIndex = 1 + 22 '19
                GridColumn40.VisibleIndex = 1 + 23 '20 
                GridColumn15.VisibleIndex = 1 + 24 '21
                GridColumn42.VisibleIndex = 1 + 25 '22
                GridColumn43.VisibleIndex = 1 + 26 '23
                GridColumn44.VisibleIndex = 1 + 27 '24
                GridColumn45.VisibleIndex = 1 + 28 '25
                GridColumn46.VisibleIndex = 1 + 29 '26
                GridColumn47.VisibleIndex = 1 + 30 '27
                GridColumn48.VisibleIndex = 1 + 31 '28
                GridColumn49.VisibleIndex = 1 + 32 '29
                GridColumn50.VisibleIndex = 1 + 33 '30
                GridColumn51.VisibleIndex = 1 + 34 '31
                GridColumn52.VisibleIndex = 1 + 35 '32
                GridColumn53.VisibleIndex = 1 + 36 '33
                GridColumn54.VisibleIndex = 1 + 37 '34
                GridColumn55.VisibleIndex = 1 + 38 '35
                GridColumn56.VisibleIndex = 1 + 39 '36
                GridColumn57.VisibleIndex = 1 + 40 '37
            End If
        ElseIf Columns = 37 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn58.Caption = Caption.cbxAccount.Text
                GridColumn58.Tag = Caption.cbxAccount.SelectedValue
                Columns = 38

                GridColumn21.VisibleIndex = 1 + 4 '1
                GridColumn22.VisibleIndex = 1 + 5 '2
                GridColumn23.VisibleIndex = 1 + 6 '3
                GridColumn24.VisibleIndex = 1 + 7 '4
                GridColumn25.VisibleIndex = 1 + 8 '5
                GridColumn26.VisibleIndex = 1 + 9 '6
                GridColumn27.VisibleIndex = 1 + 10 '7
                GridColumn28.VisibleIndex = 1 + 11 '8
                GridColumn29.VisibleIndex = 1 + 12 '9
                GridColumn31.VisibleIndex = 1 + 13 '10
                GridColumn41.VisibleIndex = 1 + 14 '11
                GridColumn32.VisibleIndex = 1 + 15 '12
                GridColumn33.VisibleIndex = 1 + 16 '13
                GridColumn34.VisibleIndex = 1 + 17 '14
                GridColumn35.VisibleIndex = 1 + 18 '15
                GridColumn36.VisibleIndex = 1 + 19 '16
                GridColumn37.VisibleIndex = 1 + 20 '17
                GridColumn38.VisibleIndex = 1 + 21 '18
                GridColumn39.VisibleIndex = 1 + 22 '19
                GridColumn40.VisibleIndex = 1 + 23 '20 
                GridColumn15.VisibleIndex = 1 + 24 '21
                GridColumn42.VisibleIndex = 1 + 25 '22
                GridColumn43.VisibleIndex = 1 + 26 '23
                GridColumn44.VisibleIndex = 1 + 27 '24
                GridColumn45.VisibleIndex = 1 + 28 '25
                GridColumn46.VisibleIndex = 1 + 29 '26
                GridColumn47.VisibleIndex = 1 + 30 '27
                GridColumn48.VisibleIndex = 1 + 31 '28
                GridColumn49.VisibleIndex = 1 + 32 '29
                GridColumn50.VisibleIndex = 1 + 33 '30
                GridColumn51.VisibleIndex = 1 + 34 '31
                GridColumn52.VisibleIndex = 1 + 35 '32
                GridColumn53.VisibleIndex = 1 + 36 '33
                GridColumn54.VisibleIndex = 1 + 37 '34
                GridColumn55.VisibleIndex = 1 + 38 '35
                GridColumn56.VisibleIndex = 1 + 39 '36
                GridColumn57.VisibleIndex = 1 + 40 '37
                GridColumn58.VisibleIndex = 1 + 41 '38
            End If
        ElseIf Columns = 38 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn59.Caption = Caption.cbxAccount.Text
                GridColumn59.Tag = Caption.cbxAccount.SelectedValue
                Columns = 39

                GridColumn21.VisibleIndex = 1 + 4 '1
                GridColumn22.VisibleIndex = 1 + 5 '2
                GridColumn23.VisibleIndex = 1 + 6 '3
                GridColumn24.VisibleIndex = 1 + 7 '4
                GridColumn25.VisibleIndex = 1 + 8 '5
                GridColumn26.VisibleIndex = 1 + 9 '6
                GridColumn27.VisibleIndex = 1 + 10 '7
                GridColumn28.VisibleIndex = 1 + 11 '8
                GridColumn29.VisibleIndex = 1 + 12 '9
                GridColumn31.VisibleIndex = 1 + 13 '10
                GridColumn41.VisibleIndex = 1 + 14 '11
                GridColumn32.VisibleIndex = 1 + 15 '12
                GridColumn33.VisibleIndex = 1 + 16 '13
                GridColumn34.VisibleIndex = 1 + 17 '14
                GridColumn35.VisibleIndex = 1 + 18 '15
                GridColumn36.VisibleIndex = 1 + 19 '16
                GridColumn37.VisibleIndex = 1 + 20 '17
                GridColumn38.VisibleIndex = 1 + 21 '18
                GridColumn39.VisibleIndex = 1 + 22 '19
                GridColumn40.VisibleIndex = 1 + 23 '20 
                GridColumn15.VisibleIndex = 1 + 24 '21
                GridColumn42.VisibleIndex = 1 + 25 '22
                GridColumn43.VisibleIndex = 1 + 26 '23
                GridColumn44.VisibleIndex = 1 + 27 '24
                GridColumn45.VisibleIndex = 1 + 28 '25
                GridColumn46.VisibleIndex = 1 + 29 '26
                GridColumn47.VisibleIndex = 1 + 30 '27
                GridColumn48.VisibleIndex = 1 + 31 '28
                GridColumn49.VisibleIndex = 1 + 32 '29
                GridColumn50.VisibleIndex = 1 + 33 '30
                GridColumn51.VisibleIndex = 1 + 34 '31
                GridColumn52.VisibleIndex = 1 + 35 '32
                GridColumn53.VisibleIndex = 1 + 36 '33
                GridColumn54.VisibleIndex = 1 + 37 '34
                GridColumn55.VisibleIndex = 1 + 38 '35
                GridColumn56.VisibleIndex = 1 + 39 '36
                GridColumn57.VisibleIndex = 1 + 40 '37
                GridColumn58.VisibleIndex = 1 + 41 '38
                GridColumn59.VisibleIndex = 1 + 42 '39
            End If
        ElseIf Columns = 39 Then
            Caption.cbxAccount.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn60.Caption = Caption.cbxAccount.Text
                GridColumn60.Tag = Caption.cbxAccount.SelectedValue
                Columns = 40

                GridColumn21.VisibleIndex = 1 + 4 '1
                GridColumn22.VisibleIndex = 1 + 5 '2
                GridColumn23.VisibleIndex = 1 + 6 '3
                GridColumn24.VisibleIndex = 1 + 7 '4
                GridColumn25.VisibleIndex = 1 + 8 '5
                GridColumn26.VisibleIndex = 1 + 9 '6
                GridColumn27.VisibleIndex = 1 + 10 '7
                GridColumn28.VisibleIndex = 1 + 11 '8
                GridColumn29.VisibleIndex = 1 + 12 '9
                GridColumn31.VisibleIndex = 1 + 13 '10
                GridColumn41.VisibleIndex = 1 + 14 '11
                GridColumn32.VisibleIndex = 1 + 15 '12
                GridColumn33.VisibleIndex = 1 + 16 '13
                GridColumn34.VisibleIndex = 1 + 17 '14
                GridColumn35.VisibleIndex = 1 + 18 '15
                GridColumn36.VisibleIndex = 1 + 19 '16
                GridColumn37.VisibleIndex = 1 + 20 '17
                GridColumn38.VisibleIndex = 1 + 21 '18
                GridColumn39.VisibleIndex = 1 + 22 '19
                GridColumn40.VisibleIndex = 1 + 23 '20 
                GridColumn15.VisibleIndex = 1 + 24 '21
                GridColumn42.VisibleIndex = 1 + 25 '22
                GridColumn43.VisibleIndex = 1 + 26 '23
                GridColumn44.VisibleIndex = 1 + 27 '24
                GridColumn45.VisibleIndex = 1 + 28 '25
                GridColumn46.VisibleIndex = 1 + 29 '26
                GridColumn47.VisibleIndex = 1 + 30 '27
                GridColumn48.VisibleIndex = 1 + 31 '28
                GridColumn49.VisibleIndex = 1 + 32 '29
                GridColumn50.VisibleIndex = 1 + 33 '30
                GridColumn51.VisibleIndex = 1 + 34 '31
                GridColumn52.VisibleIndex = 1 + 35 '32
                GridColumn53.VisibleIndex = 1 + 36 '33
                GridColumn54.VisibleIndex = 1 + 37 '34
                GridColumn55.VisibleIndex = 1 + 38 '35
                GridColumn56.VisibleIndex = 1 + 39 '36
                GridColumn57.VisibleIndex = 1 + 40 '37
                GridColumn58.VisibleIndex = 1 + 41 '38
                GridColumn59.VisibleIndex = 1 + 42 '39
                GridColumn60.VisibleIndex = 1 + 43 '40

                btnAddCol.Enabled = False
            End If
        End If
    End Sub

    Private Sub BtnRemoveCol_Click(sender As Object, e As EventArgs) Handles btnRemoveCol.Click
        btnAddCol.Enabled = True
        If Columns = 40 Then
            GridColumn60.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 40", 0)
            Next
            Columns = 39
        ElseIf Columns = 39 Then
            GridColumn59.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 39", 0)
            Next
            Columns = 38
        ElseIf Columns = 38 Then
            GridColumn58.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 38", 0)
            Next
            Columns = 37
        ElseIf Columns = 37 Then
            GridColumn57.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 37", 0)
            Next
            Columns = 36
        ElseIf Columns = 36 Then
            GridColumn56.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 36", 0)
            Next
            Columns = 35
        ElseIf Columns = 35 Then
            GridColumn55.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 35", 0)
            Next
            Columns = 34
        ElseIf Columns = 34 Then
            GridColumn54.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 34", 0)
            Next
            Columns = 33
        ElseIf Columns = 33 Then
            GridColumn53.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 33", 0)
            Next
            Columns = 32
        ElseIf Columns = 32 Then
            GridColumn52.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 32", 0)
            Next
            Columns = 31
        ElseIf Columns = 31 Then
            GridColumn51.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 31", 0)
            Next
            Columns = 30
        ElseIf Columns = 30 Then
            GridColumn50.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 30", 0)
            Next
            Columns = 29
        ElseIf Columns = 29 Then
            GridColumn49.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 29", 0)
            Next
            Columns = 28
        ElseIf Columns = 28 Then
            GridColumn48.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 28", 0)
            Next
            Columns = 27
        ElseIf Columns = 27 Then
            GridColumn47.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 27", 0)
            Next
            Columns = 26
        ElseIf Columns = 26 Then
            GridColumn46.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 26", 0)
            Next
            Columns = 25
        ElseIf Columns = 25 Then
            GridColumn45.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 25", 0)
            Next
            Columns = 24
        ElseIf Columns = 24 Then
            GridColumn44.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 24", 0)
            Next
            Columns = 23
        ElseIf Columns = 23 Then
            GridColumn43.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 23", 0)
            Next
            Columns = 22
        ElseIf Columns = 22 Then
            GridColumn42.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 22", 0)
            Next
            Columns = 21
        ElseIf Columns = 21 Then
            GridColumn15.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 21", 0)
            Next
            Columns = 20
        ElseIf Columns = 20 Then
            GridColumn40.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 20", 0)
            Next
            Columns = 19
        ElseIf Columns = 19 Then
            GridColumn39.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 19", 0)
            Next
            Columns = 18
        ElseIf Columns = 18 Then
            GridColumn38.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 18", 0)
            Next
            Columns = 17
        ElseIf Columns = 17 Then
            GridColumn37.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 17", 0)
            Next
            Columns = 16
        ElseIf Columns = 16 Then
            GridColumn36.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 16", 0)
            Next
            Columns = 15
        ElseIf Columns = 15 Then
            GridColumn35.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 15", 0)
            Next
            Columns = 14
        ElseIf Columns = 14 Then
            GridColumn34.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 14", 0)
            Next
            Columns = 13
        ElseIf Columns = 13 Then
            GridColumn33.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 13", 0)
            Next
            Columns = 12
        ElseIf Columns = 12 Then
            GridColumn32.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 12", 0)
            Next
            Columns = 11
        ElseIf Columns = 11 Then
            GridColumn41.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 11", 0)
            Next
            Columns = 10
        ElseIf Columns = 10 Then
            GridColumn31.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 10", 0)
            Next
            Columns = 9
        ElseIf Columns = 9 Then
            GridColumn29.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 9", 0)
            Next
            Columns = 8
        ElseIf Columns = 8 Then
            GridColumn28.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 8", 0)
            Next
            Columns = 7
        ElseIf Columns = 7 Then
            GridColumn27.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 7", 0)
            Next
            Columns = 6
        ElseIf Columns = 6 Then
            GridColumn26.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 6", 0)
            Next
            Columns = 5
        ElseIf Columns = 5 Then
            GridColumn25.Visible = False
            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "Amount 5", 0)
            Next
            Columns = 4
            btnRemoveCol.Enabled = False
        End If
    End Sub

    Private Sub BtnEditCol_Click(sender As Object, e As EventArgs) Handles btnEditCol.Click
        Dim Caption As New FrmSelectGL
        With Caption
            .btnAdd.Text = "Edit    Account"
            If GridView2.FocusedColumn.FieldName.ToString = "Amount 1" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn21.Caption = .cbxAccount.Text
                    GridColumn21.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 2" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn22.Caption = .cbxAccount.Text
                    GridColumn22.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 3" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn23.Caption = .cbxAccount.Text
                    GridColumn23.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 4" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn24.Caption = .cbxAccount.Text
                    GridColumn24.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 5" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn25.Caption = .cbxAccount.Text
                    GridColumn25.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 6" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn26.Caption = .cbxAccount.Text
                    GridColumn26.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 7" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn27.Caption = .cbxAccount.Text
                    GridColumn27.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 8" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn28.Caption = .cbxAccount.Text
                    GridColumn28.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 9" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn29.Caption = .cbxAccount.Text
                    GridColumn29.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 10" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn31.Caption = .cbxAccount.Text
                    GridColumn31.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 11" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn41.Caption = .cbxAccount.Text
                    GridColumn41.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 12" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn32.Caption = .cbxAccount.Text
                    GridColumn32.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 13" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn33.Caption = .cbxAccount.Text
                    GridColumn33.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 14" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn34.Caption = .cbxAccount.Text
                    GridColumn34.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 15" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn35.Caption = .cbxAccount.Text
                    GridColumn35.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 16" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn36.Caption = .cbxAccount.Text
                    GridColumn36.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 17" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn37.Caption = .cbxAccount.Text
                    GridColumn37.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 18" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn38.Caption = .cbxAccount.Text
                    GridColumn38.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 19" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn39.Caption = .cbxAccount.Text
                    GridColumn39.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 20" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn40.Caption = .cbxAccount.Text
                    GridColumn40.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 21" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn15.Caption = .cbxAccount.Text
                    GridColumn15.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 22" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn42.Caption = .cbxAccount.Text
                    GridColumn42.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 23" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn43.Caption = .cbxAccount.Text
                    GridColumn43.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 24" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn44.Caption = .cbxAccount.Text
                    GridColumn44.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 25" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn45.Caption = .cbxAccount.Text
                    GridColumn45.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 26" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn46.Caption = .cbxAccount.Text
                    GridColumn46.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 27" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn47.Caption = .cbxAccount.Text
                    GridColumn47.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 28" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn48.Caption = .cbxAccount.Text
                    GridColumn48.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 29" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn49.Caption = .cbxAccount.Text
                    GridColumn49.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 30" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn50.Caption = .cbxAccount.Text
                    GridColumn50.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 31" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn51.Caption = .cbxAccount.Text
                    GridColumn51.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 32" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn52.Caption = .cbxAccount.Text
                    GridColumn52.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 33" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn53.Caption = .cbxAccount.Text
                    GridColumn53.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 34" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn54.Caption = .cbxAccount.Text
                    GridColumn54.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 35" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn55.Caption = .cbxAccount.Text
                    GridColumn55.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 36" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn56.Caption = .cbxAccount.Text
                    GridColumn56.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 37" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn57.Caption = .cbxAccount.Text
                    GridColumn57.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 38" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn58.Caption = .cbxAccount.Text
                    GridColumn58.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 39" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn59.Caption = .cbxAccount.Text
                    GridColumn59.Tag = .cbxAccount.SelectedValue
                End If
            ElseIf GridView2.FocusedColumn.FieldName.ToString = "Amount 40" Then
                .cbxAccount.Text = ""
                If .ShowDialog = DialogResult.OK Then
                    GridColumn60.Caption = .cbxAccount.Text
                    GridColumn60.Tag = .cbxAccount.SelectedValue
                End If
            End If
        End With
    End Sub

    Private Sub GridView2_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        If GridView2.RowCount > 0 Then
            Try
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim AmountT As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount"))
                Dim Amount1 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 1"))
                Dim Amount2 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 2"))
                Dim Amount3 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 3"))
                Dim Amount4 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 4"))
                Dim Amount5 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 5"))
                Dim Amount6 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 6"))
                Dim Amount7 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 7"))
                Dim Amount8 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 8"))
                Dim Amount9 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 9"))
                Dim Amount10 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 10"))
                Dim Amount11 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 11"))
                Dim Amount12 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 12"))
                Dim Amount13 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 13"))
                Dim Amount14 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 14"))
                Dim Amount15 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 15"))
                Dim Amount16 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 16"))
                Dim Amount17 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 17"))
                Dim Amount18 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 18"))
                Dim Amount19 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 19"))
                Dim Amount20 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 20"))
                Dim Amount21 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 21"))
                Dim Amount22 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 22"))
                Dim Amount23 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 23"))
                Dim Amount24 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 24"))
                Dim Amount25 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 25"))
                Dim Amount26 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 26"))
                Dim Amount27 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 27"))
                Dim Amount28 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 28"))
                Dim Amount29 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 29"))
                Dim Amount30 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 30"))
                Dim Amount31 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 31"))
                Dim Amount32 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 32"))
                Dim Amount33 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 33"))
                Dim Amount34 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 34"))
                Dim Amount35 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 35"))
                Dim Amount36 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 36"))
                Dim Amount37 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 37"))
                Dim Amount38 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 38"))
                Dim Amount39 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 39"))
                Dim Amount40 As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount 40"))
                If FormatNumber(AmountT, 2) = FormatNumber(Amount1 + Amount2 + Amount3 + Amount4 + Amount5 + Amount6 + Amount7 + Amount8 + Amount9 + Amount10 + Amount11 + Amount12 + Amount13 + Amount14 + Amount15 + Amount16 + Amount17 + Amount18 + Amount19 + Amount20 + Amount21 + Amount22 + Amount23 + Amount24 + Amount25 + Amount26 + Amount27 + Amount28 + Amount29 + Amount30 + Amount31 + Amount32 + Amount33 + Amount34 + Amount35 + Amount36 + Amount37 + Amount38 + Amount39 + Amount40, 2) Then
                    e.Appearance.ForeColor = Color.Black
                Else
                    e.Appearance.ForeColor = Color.Red
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Total_ValueChanged(sender As Object, e As EventArgs) Handles dTotalExpense.ValueChanged, dRemainingCash.ValueChanged, dUnliquidated.ValueChanged
        dTotal.Value = dTotalExpense.Value + (dRemainingCash.Value + dUnliquidated.Value)
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Voucher_Status"))
            If Status = "DELETED" Or Status = "CANCELLED" Or Status = "DISAPPROVED" Then
                e.Appearance.ForeColor = OfficialColor2 'Color.Red
            ElseIf Status = "DRAFT" Then
                e.Appearance.ForeColor = Color.IndianRed
            End If
        End If
    End Sub

    Private Sub TxtReferenceNumber_TextChanged(sender As Object, e As EventArgs) Handles txtReferenceNumber.TextChanged
        txtReferenceNumber.Text = ReplaceText(txtReferenceNumber.Text)
    End Sub

    Private Sub BtnDraft_Click(sender As Object, e As EventArgs) Handles btnDraft.Click
        Draft = True
        btnSave.PerformClick()
        Draft = False
    End Sub

    Private Sub BtnUpdateCA_Click(sender As Object, e As EventArgs) Handles btnUpdateCA.Click
        If MsgBoxYes("Are you sure you want to refresh the Unliquidated CA?") = MsgBoxResult.Yes Then
            dUnliquidated.Value = DataObject(String.Format("SELECT IFNULL(SUM((Meals + Transportation + BIR + RD + LTO + Notarization + Others)),0) FROM cash_advance WHERE `status` = 'ACTIVE' AND slip_status IN ('RECEIVED') AND ReplenishedID = 0 AND Branch_ID = '{0}' AND (Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= 1000 AND Liquidated = 'N';", Branch_ID))
            MsgBox(String.Format("Refreshed value from {0} to {1}.", FormatNumber(dUnliquidated.Tag, 2), dUnliquidated.Text), MsgBoxStyle.Information, "Info")
            btnUpdateCA.Visible = False
        End If
    End Sub

    Private Sub BtnCheckVoucher_Click(sender As Object, e As EventArgs) Handles btnCheckVoucher.Click
        Try
            If GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CHECK VOUCHER" Then
            Else
                If GridView1.GetFocusedRowCellValue("Voucher_Status") = "REPLENISHED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "DISAPPROVED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Then
                    MsgBox(String.Format("Replenishment is already {0}.", GridView1.GetFocusedRowCellValue("Voucher_Status")), MsgBoxStyle.Information, "Info")
                    Exit Sub
                Else
                    MsgBox("Replenishment not For Check Voucher.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim CV As New FrmCheckVoucher
        With CV
            If FrmMain.lblDate.Text.Contains("Disconnected") Then
                MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            .Tag = 80
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
            Logs("Replenishment", "Check Voucher", "Check Voucher", "", "", "", "")

            .From_Replenishment = True
            .cbxPayee.Tag = GridView1.GetFocusedRowCellValue("Document Number")

            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
        End With
    End Sub
End Class