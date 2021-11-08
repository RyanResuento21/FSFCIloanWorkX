Public Class FrmBranchSelector

    Dim B_IDs As String
    Dim Firstload As Boolean = True
    Dim DT_BranchX As DataTable

    Private Sub FrmBranchSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        Firstload = True
        FixPictureEdit(PictureEdit1, 263, 64, 6, 1, True)

        If MultipleBranch Then
            B_IDs = DataObject(String.Format("SELECT IFNULL(GROUP_CONCAT(branchid),'9999') FROM user_branch WHERE user_code = '{0}' AND `status` = 'ACTIVE';", User_Code))
            DT_BranchX = DataSource(String.Format("SELECT ID, branch_code, branch, ProvinceID, RegionID FROM branch WHERE `status` = 'ACTIVE' AND FIND_IN_SET(ID,'{0}') ORDER BY Microfinance, ID * 1;", B_IDs))
        Else
            DT_BranchX = DataSource("SELECT ID, branch_code, branch, ProvinceID, RegionID FROM branch WHERE `status` = 'ACTIVE' ORDER BY Microfinance, ID * 1;")
        End If

        With cbxBranchV2
            .Properties.LookAndFeel.SkinName = "Blue"
            .Properties.Items.Clear()
            For x As Integer = 0 To DT_BranchX.Rows.Count - 1
                .Properties.Items.Add(DT_BranchX(x)("ID"), DT_BranchX(x)("branch"), CheckState.Unchecked, True)
            Next
            .Properties.SeparatorChar = ";"
            .SetEditValue(Multiple_ID.Replace(",", "; "))
        End With

        With cbxRegion
            .Properties.LookAndFeel.SkinName = "Blue"
            .Properties.Items.Clear()
            For x As Integer = 0 To DT_Region.Rows.Count - 1
                .Properties.Items.Add(DT_Region(x)("ID"), DT_Region(x)("regDesc"), CheckState.Unchecked, True)
            Next
            .Properties.SeparatorChar = ";"
            If Multiple_Region <> "" Then
                .SetEditValue(Multiple_Region.Replace(",", "; "))
            End If
        End With

        With cbxProvince
            .Properties.LookAndFeel.SkinName = "Blue"
            .Properties.Items.Clear()
            For x As Integer = 0 To DT_Province.Rows.Count - 1
                .Properties.Items.Add(DT_Province(x)("ID"), DT_Province(x)("provDesc"), CheckState.Unchecked, True)
            Next
            .Properties.SeparatorChar = ";"
            If Multiple_Province <> "" Then
                .SetEditValue(Multiple_Province.Replace(",", "; "))
            End If
        End With
        Firstload = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX4, LabelX2, LabelX3})

            GetLabelWithBackgroundFontSettings({LabelX1})

            GetCheckComboBoxFontSettings({cbxBranchV2, cbxRegion, cbxProvince})

            GetButtonFontSettings({btnSelect, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Branch Selector - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If MsgBoxYes("All opened forms will be closed, are you sure you want to continue?") = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim CheckedID As String = ""
        Dim CheckedBranch As String = ""
        Dim CountChecks As Integer = 0
        Dim CheckedBranchMessage As String = ""
        For x As Integer = 0 To cbxBranchV2.Properties.Items.Count - 1
            If cbxBranchV2.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                CountChecks += 1
                CheckedID &= cbxBranchV2.Properties.Items.Item(x).Value.ToString & ","
                CheckedBranch &= cbxBranchV2.Properties.Items.Item(x).Description.ToString & ","
                CheckedBranchMessage &= cbxBranchV2.Properties.Items.Item(x).Description.ToString & vbCrLf
            End If
        Next
        If CheckedID.Length > 0 Then
            CheckedID = CheckedID.Substring(0, CheckedID.Length - 1)
            CheckedBranch = CheckedBranch.Substring(0, CheckedBranch.Length - 1)
        End If

        If CountChecks = 0 Then
            MsgBox("Please select a Branch", MsgBoxStyle.Information, "Info")
            Exit Sub
        ElseIf CountChecks = 1 Then
            Branch_ID = CheckedID
            Branch_Code = DataObject(String.Format("SELECT branch_code FROM branch WHERE ID = '{0}';", Branch_ID))
            Branch = CheckedBranch
        Else
            Branch_ID = RealBranchID
            Branch_Code = RealBranchCode
            Branch = RealBranch
        End If
        Multiple_ID = CheckedID
        If Multiple_ID.Contains(",") Then
            MsgBox(String.Format("Branch {0} are selected. Saving/Adding new transactions in some modules are not allowed.", vbCrLf & CheckedBranchMessage), MsgBoxStyle.Information, "Info")
        Else
            MsgBox(String.Format("Branch {0} is selected.", CheckedBranch), MsgBoxStyle.Information, "Info")
        End If

        DataObject(String.Format("UPDATE users SET DefaultBranchSelected = '{1}' WHERE empl_id = '{0}';", Empl_ID, Multiple_ID))

        '***UPDATE DATATABLES ************************************************************************************
        Dim Branch_Settings As DataTable = DataSource(String.Format("CALL Login_GetBranch({0},'{1}')", Branch_ID, Branch_Code & Branch_ID))
        If Branch_Settings.Rows.Count > 0 Then
            With FrmLoanApplication
                .Interest_RPPD = Branch_Settings(0)("RPPD")
                .RPPD_Start = Branch_Settings(0)("RPPD_Start")
            End With
            Branch_IDv2 = Branch_Settings(0)("BranchID")
            Round_Up = Branch_Settings(0)("RoundUp")
            Overstayed_Months = Branch_Settings(0)("overstayed_months")
            Overstayed = Branch_Settings(0)("overstayed")
            AmountLimit = Branch_Settings(0)("transaction_amount")
            DefaultPenalty = Branch_Settings(0)("Penalty")
            DefaultReservation = Branch_Settings(0)("ReservedDays")
            RedemptionMonth = Branch_Settings(0)("RedemptionMonth")
            MFBranch_ID = Branch_Settings(0)("MFBranch")

            ConfiEmail = Branch_Settings(0)("ConfiEmail")
            ConfiPW = Branch_Settings(0)("ConfiPW")

            Approver1ID = Branch_Settings(0)("Approver1")
            Approver2ID = Branch_Settings(0)("Approver2")
            Approver3ID = Branch_Settings(0)("Approver3")
            Approver4ID = Branch_Settings(0)("Approver4")

            If Approver1ID > 0 Then
                Dim EmpDetails As DataTable = DataSource(String.Format("CALL GetEmployeeDetail({0})", Approver1ID))
                If EmpDetails.Rows.Count > 0 Then
                    Approver1Name = EmpDetails(0)("Employee")
                    Approver1Email = EmpDetails(0)("EmailAdd")
                    Approver1Phone = EmpDetails(0)("Phone")
                    Approver1_Credit = Branch_Settings(0)("OIC")
                    Approver1_CashAdvance = Branch_Settings(0)("OIC_CA")
                Else
                    Approver1Name = ""
                    Approver1Email = ""
                    Approver1Phone = ""
                    Approver1_Credit = 0
                    Approver1_CashAdvance = 0
                End If
            Else
                Approver1Name = ""
                Approver1Email = ""
                Approver1Phone = ""
                Approver1_Credit = 0
                Approver1_CashAdvance = 0
            End If
            If Approver2ID > 0 Then
                Dim EmpDetails As DataTable = DataSource(String.Format("CALL GetEmployeeDetail({0})", Approver2ID))
                If EmpDetails.Rows.Count > 0 Then
                    Approver2Name = EmpDetails(0)("Employee")
                    Approver2Email = EmpDetails(0)("EmailAdd")
                    Approver2Phone = EmpDetails(0)("Phone")
                    Approver2_Credit = Branch_Settings(0)("BM")
                    Approver2_CashAdvance = Branch_Settings(0)("BM_CA")
                Else
                    Approver2Name = ""
                    Approver2Email = ""
                    Approver2Phone = ""
                    Approver2_Credit = 0
                    Approver2_CashAdvance = 0
                End If
            Else
                Approver2Name = ""
                Approver2Email = ""
                Approver2Phone = ""
                Approver2_Credit = 0
                Approver2_CashAdvance = 0
            End If
            If Approver3ID > 0 Then
                Dim EmpDetails As DataTable = DataSource(String.Format("CALL GetEmployeeDetail({0})", Approver3ID))
                If EmpDetails.Rows.Count > 0 Then
                    Approver3Name = EmpDetails(0)("Employee")
                    Approver3Email = EmpDetails(0)("EmailAdd")
                    Approver3Phone = EmpDetails(0)("Phone")
                    Approver3_Credit = Branch_Settings(0)("DM")
                    Approver3_CashAdvance = Branch_Settings(0)("DM_CA")
                Else
                    Approver3Name = ""
                    Approver3Email = ""
                    Approver3Phone = ""
                    Approver3_Credit = 0
                    Approver3_CashAdvance = 0
                End If
            Else
                Approver3Name = ""
                Approver3Email = ""
                Approver3Phone = ""
                Approver3_Credit = 0
                Approver3_CashAdvance = 0
            End If
            If Approver4ID > 0 Then
                Dim EmpDetails As DataTable = DataSource(String.Format("CALL GetEmployeeDetail({0})", Approver4ID))
                If EmpDetails.Rows.Count > 0 Then
                    Approver4Name = EmpDetails(0)("Employee")
                    Approver4Email = EmpDetails(0)("EmailAdd")
                    Approver4Phone = EmpDetails(0)("Phone")
                    Approver4_Credit = Branch_Settings(0)("RM")
                    Approver4_CashAdvance = Branch_Settings(0)("RM_CA")
                Else
                    Approver4Name = ""
                    Approver4Email = ""
                    Approver4Phone = ""
                    Approver4_Credit = 0
                    Approver4_CashAdvance = 0
                End If
            Else
                Approver4Name = ""
                Approver4Email = ""
                Approver4Phone = ""
                Approver4_Credit = 0
                Approver4_CashAdvance = 0
            End If

            If Approver1_CashAdvance > 0 Or Approver2_CashAdvance > 0 Or Approver3_CashAdvance > 0 Or Approver4_CashAdvance > 0 Then
                CashApprovalHierarchy = True
            Else
                CashApprovalHierarchy = False
            End If
            If Approver1_Credit > 0 Or Approver2_Credit > 0 Or Approver3_Credit > 0 Or Approver4_Credit > 0 Then
                CreditApprovalHierarchy = True
            Else
                CreditApprovalHierarchy = False
            End If

            AvailedRPPD = Branch_Settings(0)("AvailedRPPD")
            AvailedPenalty = Branch_Settings(0)("AvailedPenalty")
            PettyCash = Branch_Settings(0)("PettyCash")

            Branch_Address = Branch_Settings(0)("Address")
            Branch_Contact = Branch_Settings(0)("Contact")
            Branch_BM = Branch_Settings(0)("branch_manager")
            Branch_TIN = Branch_Settings(0)("TIN")
            Branch_Email = Branch_Settings(0)("email_address")

            SMS_Notification = Branch_Settings(0)("SMS")
            Email_Notification = Branch_Settings(0)("Email")
            AppraisedPercent = Branch_Settings(0)("AppraisedPercent")
            Branch_DeferredIncome = Branch_Settings(0)("Deferred")
            Auto_Notification = Branch_Settings(0)("AutoNotification")
        End If
        Products = DataSource(String.Format("CALL Login_GetProducts('{0}')", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        Tariff = DataSource(String.Format("CALL Login_GetTariff('{0}')", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        ServiceNew = DataSource(String.Format("CALL Login_GetServiceCharge('{0}','NEW')", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        ServiceRenew = DataSource(String.Format("CALL Login_GetServiceCharge('{0}','RENEW')", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        DT_Signatory = DataSource(String.Format("CALL Login_GetSignatory({0});", Branch_ID))
        DT_Employees = DataSource(String.Format("CALL Login_GetEmployees('{0}')", If(Multiple_ID = "", Branch_ID & "," & MFBranch_ID, Multiple_ID & "," & MFBranch_ID)))
        DT_Accounts = DataSource(String.Format("CALL Login_GetAccounts({0},{1});", DefaultBankID, Branch_ID))
        DT_AccountsM = DataSource(String.Format("CALL Login_GetAccountsM({0},{1})", DefaultBankID, Branch_ID))
        DT_Holidays = DataSource(String.Format("CALL Login_GetHolidays({0})", Branch_ID))

        DT_PCV_Approver = DataSource(String.Format("CALL Login_GetApprover({0},'PCV')", Branch_ID))
        DT_CAS_Approver = DataSource(String.Format("CALL Login_GetApprover({0},'CAS')", Branch_ID))
        DT_BusinessCenter = DataSource(String.Format("CALL Login_GetBusinessCenter({0})", Branch_ID))
        DT_BusinessCenter.Rows.Add(0, "", "")
        DT_BusinessCenter_V2 = DataSource(String.Format("CALL Login_GetBusinessCenterV2({0})", Branch_ID))
        '***UPDATE DATATABLES ************************************************************************************
Here:
        For Each F As Form In My.Application.OpenForms
            If F.Name = "FrmMain" Or F.Name = "FrmLogin" Then
            Else
                F.Dispose()
                GoTo Here
            End If
        Next

        Close()
    End Sub

    Private Sub FrmBranchSelector_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSelect.Focus()
            btnSelect.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub CbxRegion_EditValueChanged(sender As Object, e As EventArgs) Handles cbxRegion.EditValueChanged
        If Firstload Then
            Exit Sub
        End If

        Dim CheckedID As String = ""
        With cbxRegion
            For x As Integer = 0 To .Properties.Items.Count - 1
                If .Properties.Items.Item(x).CheckState = CheckState.Checked Then
                    CheckedID &= .Properties.Items.Item(x).Value.ToString & ","
                End If
            Next
        End With
        If CheckedID.Length > 0 Then
            CheckedID = CheckedID.Substring(0, CheckedID.Length - 1)
        End If
        Multiple_Region = CheckedID

        cbxBranchV2.Properties.Items.Clear()
        For x As Integer = 0 To DT_BranchX.Rows.Count - 1
            Dim RegionIndex As Integer = -1
            For y As Integer = 0 To cbxRegion.Properties.Items.Count - 1
                If cbxRegion.Properties.Items.Item(y).CheckState = CheckState.Checked And y >= RegionIndex And CInt(cbxRegion.Properties.Items.Item(y).Value) = CInt(DT_BranchX(x)("RegionID")) Then
                    cbxBranchV2.Properties.Items.Add(DT_BranchX(x)("ID"), DT_BranchX(x)("branch"), CheckState.Checked, True)
                    RegionIndex = y
                    Exit For
                End If
            Next

            If CInt(cbxRegion.Properties.Items.Item(If(RegionIndex = -1, 0, RegionIndex)).Value) <> CInt(DT_BranchX(x)("RegionID")) Then
                cbxBranchV2.Properties.Items.Add(DT_BranchX(x)("ID"), DT_BranchX(x)("branch"), CheckState.Unchecked, True)
            End If
        Next

        Firstload = True
        Multiple_Province = ""
        cbxProvince.Properties.Items.Clear()
        For x As Integer = 0 To DT_Province.Rows.Count - 1
            cbxProvince.Properties.Items.Add(DT_Province(x)("ID"), DT_Province(x)("provDesc"), CheckState.Unchecked, True)
        Next
        Firstload = False
    End Sub

    Private Sub CbxProvince_EditValueChanged(sender As Object, e As EventArgs) Handles cbxProvince.EditValueChanged
        If Firstload Then
            Exit Sub
        End If

        Dim CheckedID As String = ""
        For x As Integer = 0 To cbxProvince.Properties.Items.Count - 1
            If cbxProvince.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                CheckedID &= cbxProvince.Properties.Items.Item(x).Value.ToString & ","
            End If
        Next
        If CheckedID.Length > 0 Then
            CheckedID = CheckedID.Substring(0, CheckedID.Length - 1)
        End If
        Multiple_Province = CheckedID

        cbxBranchV2.Properties.Items.Clear()
        For x As Integer = 0 To DT_BranchX.Rows.Count - 1
            Dim ProvinceIndex As Integer = -1
            For y As Integer = 0 To cbxProvince.Properties.Items.Count - 1
                If cbxProvince.Properties.Items.Item(y).CheckState = CheckState.Checked And y >= ProvinceIndex And CInt(cbxProvince.Properties.Items.Item(y).Value) = CInt(DT_BranchX(x)("ProvinceID")) Then
                    cbxBranchV2.Properties.Items.Add(DT_BranchX(x)("ID"), DT_BranchX(x)("branch"), CheckState.Checked, True)
                    ProvinceIndex = y
                    Exit For
                End If
            Next

            If CInt(cbxProvince.Properties.Items.Item(If(ProvinceIndex = -1, 0, ProvinceIndex)).Value) <> CInt(DT_BranchX(x)("ProvinceID")) Then
                cbxBranchV2.Properties.Items.Add(DT_BranchX(x)("ID"), DT_BranchX(x)("branch"), CheckState.Unchecked, True)
            End If
        Next

        Firstload = True
        Multiple_Region = ""
        cbxRegion.Properties.Items.Clear()
        For x As Integer = 0 To DT_Region.Rows.Count - 1
            cbxRegion.Properties.Items.Add(DT_Region(x)("ID"), DT_Region(x)("regDesc"), CheckState.Unchecked, True)
        Next
        Firstload = False
    End Sub

    Private Sub CbxBranchV2_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBranchV2.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSelect.PerformClick()
        End If
    End Sub
End Class