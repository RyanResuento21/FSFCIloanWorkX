Imports DevExpress.XtraReports.UI
Public Class FrmCIApproved

    Public BorrowerID As String
    Public CreditNumber As String
    Public CINumber As String
    Public TotalImage As Integer
    Public Corporate As Boolean
    Public ApproveStatus As String
    Public CollateralFromROPOA As Boolean

    Private Sub FrmCIApproved_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        FixPictureEdit(pb_B, 255, 256, 6, 7, False)
        If TotalImage Then
            btnApproved.Enabled = True
            btnDisapproved.Enabled = True
        End If
        dtpApproved.Value = Date.Now
        dtpApproved.CustomFormat = ""

        If ApproveStatus = "For ReApprove" Or ApproveStatus = "For Special" Then
            btnBOLA.Enabled = True
        Else
            btnBOLA.Enabled = False
        End If

        If Corporate Then
            LabelX43.Text = "Trade Name :"
            TxtFirstN_B.Size = New Point(739, 23)
            TxtFirstN_B.Location = New Point(406, 7)

            CbxPrefix_B.Visible = False
            TxtMiddleN_B.Visible = False
            TxtLastN_B.Visible = False
            cbxSuffix_B.Visible = False
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetDoubleInputFontSettings({dLoanable, dPrincipal, dPrincipalA, dInterestRate, dServiceCharge, dInterestRateA, dServiceChargeA, dTotalDisposable, dTotalExpenses, dNetDisposable, dTMFI, dTMDI})

            GetRickTextBoxFontSettings({rNarrative})

            GetIntegerInputFontSettings({iTerms, iTermsA})

            GetLabelWithBackgroundFontSettings({LabelX6, LabelX11})

            GetLabelFontSettings({LabelX95, LabelX2, lblInterest, LabelX4, LabelX3, LabelX12, LabelX43, LabelX7, LabelX8, LabelX9, LabelX10, LabelX82, LabelX5, LabelX68, LabelX97, LabelX119, LabelX121, LabelX124, LabelX126, LabelX98, LabelX118, LabelX120, LabelX123, LabelX125})

            GetLabelFontSettingsRed({LabelX100})

            GetTextBoxFontSettings({TxtFirstN_B, TxtMiddleN_B, TxtLastN_B})

            GetComboBoxFontSettings({CbxPrefix_B, cbxSuffix_B, cbxTerms, cbxTermsA, cbxProduct})

            GetLabelFontSettingsDefaultSize({lblCINumber})

            GetDoubleInputFontSettings({dNetProceeds_C})

            GetCheckBoxFontSettingsDefault({cbxGood, cbxFair, cbxPoor})

            GetDateTimeInputFontSettings({dtpApproved})

            GetButtonFontSettings({btnUpdate, btnApproved, btnDisapproved, btnBOLA, btnAttach, btnCancel, btnRequirements, btnPrint})
        Catch ex As Exception
            TriggerBugReport("CI Approved - FixUI", ex.Message.ToString)
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
        OpenFormHistory("CI Approve", lblTitle.Text)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub FrmCIApproved_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.A Then
            btnApproved.Focus()
            btnApproved.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            btnDisapproved.Focus()
            btnDisapproved.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnApproved_Click(sender As Object, e As EventArgs) Handles btnApproved.Click
        If btnApproved.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If dtpApproved.CustomFormat = "" Then
            MsgBox("Please fill the approved date.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If MsgBoxYes("Are you sure you want to approve this credit investigation?") = MsgBoxResult.Yes Then
            Dim Reason As String = "" 'Reason for change
            Dim Note As New FrmReason
            With Note
                .lblReason.Text = "Note :"
                .Text = "N O T E   F O R   A P P R O V E"
                .LabelX3.Visible = False
                .LabelX2.Visible = False
                .txtNo.Visible = False
                .LabelX4.Visible = False
                If .ShowDialog = DialogResult.OK Then
                    Reason = .txtReason.Text
                    'Else
                    '    Exit Sub
                End If
            End With

            Notify("Approval")

            DataObject(String.Format("UPDATE credit_investigation SET CI_status = 'APPROVED', ApprovedID = '{2}' WHERE CINumber = '{0}';", lblCINumber.Text, Reason.Trim, Empl_ID))
            If ApproveStatus = "Pending" Or ApproveStatus = "For ReApprove" Then
                DataObject(String.Format("UPDATE credit_application SET CI_status = 'APPROVED', CI_ApprovedDate = '{1}', ForLP_Note = '{2}', ApprovedAmount_Crecomm = {3}, ApprovedTerm_Crecomm = {4}, ApprovedInterest_Crecomm = {5}, ApprovedSC_Crecomm = {6}, ApproveStatus = 'APPROVED', OldApproveStatus = 'APPROVED', CrecommTimestamp = CURRENT_TIMESTAMP, Release_OTAC = IF({7} = 0,Release_OTAC,'{8}') WHERE CreditNumber = '{0}';", CreditNumber, Format(dtpApproved.Value, "yyyy-MM-dd"), Reason.Trim, dPrincipalA.Value, iTermsA.Value, dInterestRateA.Value, dServiceChargeA.Value, CollateralFromROPOA, GenerateOTAC))
            Else
                DataObject(String.Format("UPDATE credit_application SET CI_status = 'APPROVED', CI_ApprovedDate = '{1}', ForLP_Note = '{2}', ApprovedAmount_President = {3}, ApprovedTerm_President = {4}, ApprovedInterest_President = {5}, ApprovedSC_President = {6}, ApproveStatus = 'APPROVED', OldApproveStatus = 'APPROVED', PresidentTimestamp = CURRENT_TIMESTAMP, Release_OTAC = IF({7} = 0,Release_OTAC,'{8}') WHERE CreditNumber = '{0}';", CreditNumber, Format(dtpApproved.Value, "yyyy-MM-dd"), Reason.Trim, dPrincipalA.Value, iTermsA.Value, dInterestRateA.Value, dServiceChargeA.Value, CollateralFromROPOA, GenerateOTAC))
            End If
            If CollateralFromROPOA Then
                'SOLD ROPOA
                Dim SQL_Sold As String = ""
                For x As Integer = 0 To FrmCreditInvestigation.GridView1.RowCount - 1
                    Dim Sell_Status As String = DataObject(String.Format("SELECT sell_status FROM ropoa_vehicle WHERE AssetNumber = '{0}';", FrmCreditInvestigation.GridView1.GetRowCellValue(x, "AssetNumber")))
                    If Sell_Status = "SELL" Then
                        'C A N C E L   I M P A I R M E N T   S C H E D U L E **********************************************
                        SQL_Sold &= String.Format("UPDATE tbl_impairment SET impairment_status = 'CANCELLED' WHERE impairment_status = 'PENDING' AND `status` = 'ACTIVE' AND ReferenceN = '{0}';", DataObject(String.Format("SELECT Get_ROPOA_Reference('{0}');", FrmCreditInvestigation.GridView1.GetRowCellValue(x, "AssetNumber"))))
                        'C A N C E L   I M P A I R M E N T   S C H E D U L E **********************************************
                        SQL_Sold &= String.Format("UPDATE ropoa_vehicle SET sell_status = 'SOLD' WHERE AssetNumber = '{0}';", FrmCreditInvestigation.GridView1.GetRowCellValue(x, "AssetNumber"))
                        SQL_Sold &= "INSERT INTO sold_ropoa SET"
                        SQL_Sold &= String.Format(" AssetNumber = '{0}', ", FrmCreditInvestigation.GridView1.GetRowCellValue(x, "AssetNumber"))
                        SQL_Sold &= String.Format(" Prefix_B = '{0}', ", CbxPrefix_B.Text)
                        SQL_Sold &= String.Format(" FirstN_B = '{0}', ", TxtFirstN_B.Text)
                        SQL_Sold &= String.Format(" MiddleN_B = '{0}', ", TxtMiddleN_B.Text)
                        SQL_Sold &= String.Format(" LastN_B = '{0}', ", TxtLastN_B.Text)
                        SQL_Sold &= String.Format(" Suffix_B = '{0}', ", cbxSuffix_B.Text)
                        With FrmCreditInvestigation
                            SQL_Sold &= String.Format(" NoC_B = '{0}', ", .txtNoC_B.Text)
                            SQL_Sold &= String.Format(" StreetC_B = '{0}', ", .txtStreetC_B.Text)
                            SQL_Sold &= String.Format(" BarangayC_B = '{0}', ", .txtBarangayC_B.Text)
                            SQL_Sold &= String.Format(" AddressC_B = '{0}', ", .cbxAddressC_B.Text)
                            SQL_Sold &= " Contact_N = '', "
                            SQL_Sold &= String.Format(" Amount = '{0}', ", .GridView1.GetRowCellValue(x, "SellingPrice"))
                        End With
                        SQL_Sold &= String.Format(" user_id = '{0}', ", User_ID)
                        SQL_Sold &= " reserved_days = 0, "
                        SQL_Sold &= " reserved_status = 'NO', "
                        SQL_Sold &= " Remarks = '', "
                        SQL_Sold &= " Referral = '', "
                        SQL_Sold &= " Referral_ID = 0, "
                        SQL_Sold &= " ReferenceN = '', "
                        SQL_Sold &= " BankID = 0, "
                        SQL_Sold &= " MultipleA = 0, "
                        SQL_Sold &= String.Format(" branch_id = '{0}';", Branch_ID)
                    Else
                        SQL_Sold &= String.Format("UPDATE ropoa_vehicle SET sell_status = 'SOLD' WHERE AssetNumber = '{0}';", FrmCreditInvestigation.GridView1.GetRowCellValue(x, "AssetNumber"))
                    End If
                Next
                For x As Integer = 0 To FrmCreditInvestigation.GridView2.RowCount - 1
                    Dim Sell_Status As String = DataObject(String.Format("SELECT sell_status FROM ropoa_realestate WHERE AssetNumber = '{0}';", FrmCreditInvestigation.GridView2.GetRowCellValue(x, "AssetNumber")))
                    If Sell_Status = "SELL" Then
                        'C A N C E L   I M P A I R M E N T   S C H E D U L E **********************************************
                        SQL_Sold &= String.Format("UPDATE tbl_impairment SET impairment_status = 'CANCELLED' WHERE impairment_status = 'PENDING' AND `status` = 'ACTIVE' AND ReferenceN = '{0}';", DataObject(String.Format("SELECT Get_ROPOA_Reference('{0}');", FrmCreditInvestigation.GridView2.GetRowCellValue(x, "AssetNumber"))))
                        'C A N C E L   I M P A I R M E N T   S C H E D U L E **********************************************
                        SQL_Sold &= String.Format("UPDATE ropoa_realestate SET sell_status = 'SOLD' WHERE AssetNumber = '{0}';", FrmCreditInvestigation.GridView2.GetRowCellValue(x, "AssetNumber"))
                        SQL_Sold &= "INSERT INTO sold_ropoa SET"
                        SQL_Sold &= String.Format(" AssetNumber = '{0}', ", FrmCreditInvestigation.GridView2.GetRowCellValue(x, "AssetNumber"))
                        SQL_Sold &= String.Format(" Prefix_B = '{0}', ", CbxPrefix_B.Text)
                        SQL_Sold &= String.Format(" FirstN_B = '{0}', ", TxtFirstN_B.Text)
                        SQL_Sold &= String.Format(" MiddleN_B = '{0}', ", TxtMiddleN_B.Text)
                        SQL_Sold &= String.Format(" LastN_B = '{0}', ", TxtLastN_B.Text)
                        SQL_Sold &= String.Format(" Suffix_B = '{0}', ", cbxSuffix_B.Text)
                        With FrmCreditInvestigation
                            SQL_Sold &= String.Format(" NoC_B = '{0}', ", .txtNoC_B.Text)
                            SQL_Sold &= String.Format(" StreetC_B = '{0}', ", .txtStreetC_B.Text)
                            SQL_Sold &= String.Format(" BarangayC_B = '{0}', ", .txtBarangayC_B.Text)
                            SQL_Sold &= String.Format(" AddressC_B = '{0}', ", .cbxAddressC_B.Text)
                            SQL_Sold &= " Contact_N = '', "
                            SQL_Sold &= String.Format(" Amount = '{0}', ", .GridView2.GetRowCellValue(x, "SellingPrice"))
                        End With
                        SQL_Sold &= String.Format(" user_id = '{0}', ", User_ID)
                        SQL_Sold &= String.Format(" ReferenceN = '{0}', ", CreditNumber)
                        SQL_Sold &= " reserved_days = 0, "
                        SQL_Sold &= " reserved_status = 'NO', "
                        SQL_Sold &= " Remarks = '', "
                        SQL_Sold &= " Referral = '', "
                        SQL_Sold &= " Referral_ID = 0, "
                        SQL_Sold &= " BankID = 0, "
                        SQL_Sold &= " MultipleA = 0, "
                        SQL_Sold &= String.Format(" branch_id = '{0}';", Branch_ID)
                    Else
                        SQL_Sold &= String.Format("UPDATE ropoa_realestate SET sell_status = 'SOLD' WHERE AssetNumber = '{0}';", FrmCreditInvestigation.GridView2.GetRowCellValue(x, "AssetNumber"))
                    End If
                Next
                If SQL_Sold = "" Then
                Else
                    DataObject(SQL_Sold)
                End If
            End If
            Logs("CI Approve", "Approve", "Approved Credit Investigation", String.Format("Approved credit investigation {0} of {1} with a principal of {2}.", lblCINumber.Text, If(CbxPrefix_B.Text = "", "", CbxPrefix_B.Text & " ") & If(TxtFirstN_B.Text = "", "", TxtFirstN_B.Text & " ") & If(TxtMiddleN_B.Text = "", "", TxtMiddleN_B.Text & " ") & If(TxtLastN_B.Text = "", "", TxtLastN_B.Text & " ") & If(cbxSuffix_B.Text = "", "", cbxSuffix_B.Text), dPrincipalA.Text), "", "", CreditNumber)
            MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
            btnApproved.DialogResult = DialogResult.OK
            btnApproved.PerformClick()
        End If
    End Sub

    Private Sub Notify(Trigger As String)
        Dim BM As DataTable = GetBM(Branch_ID)
        Dim Msg As String
        Dim Subject As String
        Dim EmailTo As String = ""
        For x As Integer = 0 To BM.Rows.Count - 1
            Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee")) & "<br><br>"
            Msg &= String.Format(" {0} for {1}." & vbCrLf, Trigger, TxtFirstN_B.Text & " " & TxtLastN_B.Text) & "<br>"
            Msg &= "Principal : <b>P" & dPrincipal.Text & "</b><br>"
            Msg &= "Terms : <b>" & iTermsA.Value & " " & cbxTermsA.Text & "</b><br>"
            Msg &= "Interest Rate : <b>" & dInterestRateA.Text & "% / annum" & "</b><br>"
            Msg &= "Service Charge : <b>" & dServiceChargeA.Text & "%" & "</b><br>"
            Msg &= "Approved Date : <b>" & dtpApproved.Text & "</b><br>"
            Msg &= "Thank you!"
            '******* SEND SMS *********************************************************************************
            If BM(x)("Phone") = "" Then
            Else
                SendSMS(BM(x)("Phone"), Msg, True)
            End If
            '******* SEND EMAIL *********************************************************************************
            If BM(x)("EmailAdd") = "" Then
            Else
                EmailTo = EmailTo & BM(x)("EmailAdd") & ", "
            End If

            If EmailTo = "" Then
            Else
                Subject = String.Format("{5} for [{4}] {0}-{1}-{2} {3}", Branch_Code, DataObject(String.Format("SELECT `code` FROM product_setup WHERE Product = '{0}';", cbxProduct.Text)), TxtFirstN_B.Text & " " & TxtLastN_B.Text, dPrincipalA.Text, CreditNumber, Trigger)
                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
            End If
        Next
    End Sub

    Private Sub BtnDisapproved_Click(sender As Object, e As EventArgs) Handles btnDisapproved.Click
        If btnDisapproved.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If MsgBoxYes("Are you sure you want to disapprove this credit investigation?") = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            Dim Note As New FrmReason
            With Note
                .lblReason.Text = "Note :"
                .Text = "N O T E   F O R   D I S A P P R O V E"
                .LabelX3.Visible = False
                .LabelX2.Visible = False
                .txtNo.Visible = False
                .LabelX4.Visible = False
                If .ShowDialog = DialogResult.OK Then
                    Reason = .txtReason.Text
                Else
                    Exit Sub
                End If
            End With

            Notify("Disapproval")

            DataObject(String.Format("UPDATE credit_investigation SET CI_status = 'DISAPPROVED', ApprovedID = '{2}' WHERE CINumber = '{0}'", lblCINumber.Text, Reason.Trim, Empl_ID))
            If ApproveStatus = "Pending" Or ApproveStatus = "For ReApprove" Then
                DataObject(String.Format("UPDATE credit_application SET CI_status = 'DISAPPROVED', OldApproveStatus = 'DISAPPROVED', ApproveStatus = 'DISAPPROVED', CrecommTimestamp = CURRENT_TIMESTAMP WHERE CreditNumber = '{0}';", CreditNumber))
            Else
                DataObject(String.Format("UPDATE credit_application SET CI_status = 'DISAPPROVED', OldApproveStatus = 'DISAPPROVED', ApproveStatus = 'DISAPPROVED', PresidentTimestamp = CURRENT_TIMESTAMP WHERE CreditNumber = '{0}';", CreditNumber))
            End If
            Logs("CI Approve", "Disapprove", Reason, String.Format("Disapproved credit investigation {0} of {1} with a principal of {2}.", lblCINumber.Text, If(CbxPrefix_B.Text = "", "", CbxPrefix_B.Text & " ") & If(TxtFirstN_B.Text = "", "", TxtFirstN_B.Text & " ") & If(TxtMiddleN_B.Text = "", "", TxtMiddleN_B.Text & " ") & If(TxtLastN_B.Text = "", "", TxtLastN_B.Text & " ") & If(cbxSuffix_B.Text = "", "", cbxSuffix_B.Text), dPrincipalA.Text), "", "", CreditNumber)
            MsgBox("Successfully Disapproved!", MsgBoxStyle.Information, "Info")
            btnDisapproved.DialogResult = DialogResult.OK
            btnDisapproved.PerformClick()
        End If
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If FrmMain.lblDate.Text.Contains("Disconnected") Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim Calculator As New FrmLoanApplication
        With Calculator
            .Tag = 26
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

            Logs("CI Approval", "Open", "Amortization Calculators", "", "", "", CreditNumber)
            .lblTitle.Text = "AMORTIZATION CALCULATOR"
            .ControlBox = False
            .FormBorderStyle = FormBorderStyle.FixedDialog
            .WindowState = FormWindowState.Normal
            .From_CI = True
            .CreditNumber = CreditNumber

            .ShowDialog()
            FrmLoanApplication.LoadData()
            .Dispose()
        End With

        Dim DT As DataTable = DataSource(String.Format("SELECT AmountApplied, Terms, TermType, Product, interest_rate, service_charge, net_proceeds FROM credit_application WHERE CreditNumber = '{0}';", CreditNumber))
        If DT.Rows.Count > 0 Then
            dPrincipal.Value = DT(0)("AmountApplied")
            iTerms.Value = DT(0)("Terms")
            cbxTerms.Text = DT(0)("TermType")
            cbxProduct.Text = DT(0)("Product")
            dInterestRate.Value = DT(0)("interest_rate") / (DT(0)("Terms") / 12)
            dServiceCharge.Value = DT(0)("service_charge")
            dNetProceeds_C.Value = DT(0)("net_proceeds")
        End If
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "CI Approval"
            .Type = "CI Approval"
            .TotalImage = TotalImage
            .CINumber = CINumber
            .ID = CINumber
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                TotalImage = .TotalImage
                FrmCreditInvestigation.TotalImage_Approval = TotalImage
                FrmCreditInvestigation.GridView5.SetFocusedRowCellValue("Attach_Approval", TotalImage)
            ElseIf Result = DialogResult.Yes Then
                TotalImage = .TotalImage
                FrmCreditInvestigation.TotalImage_Approval = TotalImage
                FrmCreditInvestigation.GridView5.SetFocusedRowCellValue("Attach_Approval", TotalImage)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub DtpApproved_Click(sender As Object, e As EventArgs) Handles dtpApproved.Click
        dtpApproved.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub BtnRequirements_Click(sender As Object, e As EventArgs) Handles btnRequirements.Click
        Dim Requirements As New FrmRequirementsMonitoring
        With Requirements
            .For_Viewing = True
            .CreditNumber = CreditNumber
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnBOLA_Click(sender As Object, e As EventArgs) Handles btnBOLA.Click
        If btnBOLA.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If MsgBoxYes("Are you sure you want set the approval Base On Last Approval?") = MsgBoxResult.Yes Then
            Dim SQL As String = ""
            If ApproveStatus = "For ReApprove" Then
                SQL = String.Format("UPDATE credit_application SET ApproveStatus = OldApproveStatus, CrecommTimestamp = CURRENT_TIMESTAMP WHERE CreditNumber = '{0}'", CreditNumber)
            ElseIf ApproveStatus = "For Special" Then
                SQL = String.Format("UPDATE credit_application SET ApproveStatus = OldApproveStatus, PresidentTimestamp = CURRENT_TIMESTAMP WHERE CreditNumber = '{0}'", CreditNumber)
            End If
            Logs("Credit Approve", "BOLA", "", String.Format("Base on last approval credit application {0} of {1} with a principal of {2}.", CreditNumber, If(CbxPrefix_B.Text = "", "", CbxPrefix_B.Text & " ") & If(TxtFirstN_B.Text = "", "", TxtFirstN_B.Text & " ") & If(TxtMiddleN_B.Text = "", "", TxtMiddleN_B.Text & " ") & If(TxtLastN_B.Text = "", "", TxtLastN_B.Text & " ") & If(cbxSuffix_B.Text = "", "", cbxSuffix_B.Text), dPrincipal.Text), "", "", CreditNumber)

            DataObject(SQL)

            MsgBox("Successfully BOLA!", MsgBoxStyle.Information, "Info")
            btnBOLA.DialogResult = DialogResult.OK
            btnBOLA.PerformClick()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Cursor = Cursors.WaitCursor
        Dim Report As New RptRequestLoanApproval
        With Report
            .Name = "Request Loan Approval " & CreditNumber
            .p_Borrower.Image = pb_B.Image.Clone
            .lblBorrower.Text = If(CbxPrefix_B.Text.Trim = "", "", CbxPrefix_B.Text.Trim & " ") & If(TxtFirstN_B.Text.Trim = "", "", TxtFirstN_B.Text.Trim & " ") & If(TxtMiddleN_B.Text.Trim = "", "", TxtMiddleN_B.Text.Trim & " ") & If(TxtLastN_B.Text.Trim = "", "", TxtLastN_B.Text.Trim & " ") & If(cbxSuffix_B.Text.Trim = "", "", cbxSuffix_B.Text.Trim & " ")
            .lblPrincipal_R.Text = dPrincipal.Text
            .lblTerm_R.Text = iTerms.Text
            .lblTermType_R.Text = cbxTerms.Text
            .lblInterest_R.Text = dInterestRate.Text
            .lblService_R.Text = dServiceCharge.Text
            .lblPrincipal_A.Text = dPrincipalA.Text
            .lblTerm_A.Text = iTermsA.Text
            .lblTermType_A.Text = cbxTermsA.Text
            .lblInterest_A.Text = dInterestRateA.Text
            .lblService_A.Text = dServiceChargeA.Text
            .lblProduct.Text = cbxProduct.Text
            .lblLoanable.Text = dLoanable.Text
            .lblNetProceeds.Text = dNetProceeds_C.Text
            .cbxGood.Checked = cbxGood.Checked
            .cbxFair.Checked = cbxFair.Checked
            .cbxPoor.Checked = cbxPoor.Checked
            .lblApprovedDate.Text = dtpApproved.Text
            .lblCreditNumber.Text = lblCINumber.Text
            .lblNarrative.Text = rNarrative.Text
            .lblTotalMonthly.Text = dTotalDisposable.Text
            .lblTotalExpenses.Text = dTotalExpenses.Text
            .lblDisposable.Text = dNetDisposable.Text
            .lblTMFI.Text = dTMFI.Text
            .lblTMDI.Text = dTMDI.Text
            .ShowPreview()
        End With
        Cursor = Cursors.Default
    End Sub
End Class