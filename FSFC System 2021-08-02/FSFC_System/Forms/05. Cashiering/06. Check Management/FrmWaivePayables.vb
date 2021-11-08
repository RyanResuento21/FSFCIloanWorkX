Public Class FrmWaivePayables

    Public BorrowerName As String
    Public CreditNumber As String
    Dim Code As String
    Dim Old_Code As String
    Public ORNumber As String
    Public ORDate As Date
    Public BankID As Integer
    Private Sub FrmWaivePayables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        'Generate Code **************

        Code = GenerateOTAC()
        LoadCompanyMode()

        Dim SQL As String = "SELECT "
        SQL &= "    CONCAT(IF(Prefix = '', '', CONCAT(Prefix, ' ')),IF(First_Name = '','',CONCAT(First_Name, ' ')),IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')),IF(Last_Name = '','',CONCAT(Last_Name, ' ')),Suffix) AS 'Name',"
        SQL &= "    EmailAdd AS 'Email Address',"
        SQL &= "    IF(EmailAdd = '','False','True') AS 'Email',"
        SQL &= "    CONCAT('+63',Phone) AS 'Mobile Number',"
        SQL &= "    IF(Phone = '','False','True') AS 'SMS'"
        SQL &= "  FROM employee_setup"
        SQL &= String.Format("  WHERE (`position` = 'BRANCH MANAGER' OR `position` = 'OFFICER-IN-CHARGE')  AND branch_id = '{0}' AND `status` = 'ACTIVE' ORDER BY `Name` ;", Branch_ID)

        GridControl1.DataSource = DataSource(SQL)

        dPenalty.MaxValue = dPenalty_P.Value
        dRPPD.MaxValue = dRPPD_P.Value
        Timer_Date.Start()
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

            GetLabelFontSettings({lblPenalty, lblRPPD, LabelX2, LabelX1, LabelX7, LabelX6})

            GetLabelWithBackgroundFontSettings({LabelX3, LabelX4, LabelX5})

            GetDoubleInputFontSettings({dPenalty_P, dRPPD_P, dPenalty, dRPPD, dPenalty_D, dRPPD_D, dPenalty_Percent, dRPPD_Percent})

            GetButtonFontSettings({btnWaive, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Waive Payables - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Waive Payables", lblTitle.Text)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub FrmWaivePayables_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub DPenalty_ValueChanged(sender As Object, e As EventArgs) Handles dPenalty.ValueChanged
        dPenalty_D.Value = dPenalty_P.Value - dPenalty.Value
        dPenalty_Percent.Value = (dPenalty_D.Value / dPenalty_P.Value) * 100
    End Sub

    Private Sub DRPPD_ValueChanged(sender As Object, e As EventArgs) Handles dRPPD.ValueChanged
        dRPPD_D.Value = dRPPD_P.Value - dRPPD.Value
        dRPPD_Percent.Value = (dRPPD_D.Value / dRPPD_P.Value) * 100
    End Sub

    Private Sub BtnWaive_Click(sender As Object, e As EventArgs) Handles btnWaive.Click
        If btnWaive.DialogResult = DialogResult.OK Then
        Else
            If dPenalty_Percent.Value > 0 Or dRPPD_Percent.Value > 0 Then
            Else
                MsgBox("Please fill the new payable to be waive.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Dim Msg As String = "Are you sure you want to waive this payables? This will send an Email or SMS to authorized personnel and please wait for their code."
            If Code = Old_Code Then
                Msg = "Would you like to enter the code now?"
            ElseIf Old_Code = "" Then
                Msg = "Are you sure you want to waive this payables? This will send an Email or SMS to authorized personnel and please wait for their code."
            Else
                Msg = "Are you sure you want to waive this payables? This will send a NEW Email or SMS to authorized personnel and please wait for their code."
            End If
            If MsgBoxYes(Msg) = MsgBoxResult.Yes Then
                dPenalty.Enabled = False
                dRPPD.Enabled = False
                If Code = Old_Code Then
                Else
                    Old_Code = Code
                    For x As Integer = 0 To GridView1.RowCount - 1
                        'Email*******************************************
                        If GridView1.GetRowCellValue(x, "Email") = True Then
                            Cursor = Cursors.WaitCursor

                            Dim Subject As String = "One Time Authorization Code " & Code & " [" & CreditNumber & "]"
                            Dim Body As String = String.Format("Good day {0}," & vbCrLf, UpperCaseFirst(GridView1.GetRowCellValue(x, "Name")))
                            Body &= String.Format(" One Time Authorization Code is <b>{0}</b> for waiving the", Code)
                            If dPenalty_Percent.Value > 0 And dRPPD_Percent.Value > 0 Then
                                Body &= String.Format(" Penalty from P{0} to P{1} and RPPD from P{2} to P{3}", dPenalty_P.Text, dPenalty.Text, dRPPD_P.Text, dRPPD.Text)
                            ElseIf dPenalty_Percent.Value > 0 Then
                                Body &= String.Format(" Penalty from P{0} to P{1}", dPenalty_P.Text, dPenalty.Text)
                            ElseIf dRPPD_Percent.Value > 0 Then
                                Body &= String.Format(" RPPD from P{0} to P{1}", dRPPD_P.Text, dRPPD.Text)
                            End If
                            Body &= String.Format(" for the account of {0}.", BorrowerName)
                            If CreditNumber <> "" Then
                                AttachmentFiles = New ArrayList()
                                Dim Ledger As New FrmAccountLedger
                                Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & CreditNumber & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                With Ledger
                                    .CreditNumber = CreditNumber
                                    .WindowState = FormWindowState.Minimized
                                    .Show()
                                    .PrintLedger(False, FName)
                                    .Dispose()
                                End With
                                AttachmentFiles.Add(FName)
                                AttachmentFiles.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & ORNumber & ".pdf")
                            End If
                            SendEmail(GridView1.GetRowCellValue(x, "Email Address"), Subject, Body, False, False, False, 0, "", "")

                            Cursor = Cursors.Default
                        End If

                        'SMS*******************************************
                        If GridView1.GetRowCellValue(x, "SMS") = True Then
                            Dim Body As String = String.Format("Good day {0}," & vbCrLf, UpperCaseFirst(GridView1.GetRowCellValue(x, "Name")))
                            Body &= String.Format(" One Time Authorization Code is <b>{0}</b> for waiving the", Code)
                            If dPenalty_Percent.Value > 0 And dRPPD_Percent.Value > 0 Then
                                Body &= String.Format(" Penalty from P{0} to P{1} and RPPD from P{2} to P{3}", dPenalty_P.Text, dPenalty.Text, dRPPD_P.Text, dRPPD.Text)
                            ElseIf dPenalty_Percent.Value > 0 Then
                                Body &= String.Format(" Penalty from P{0} to P{1}", dPenalty_P.Text, dPenalty.Text)
                            ElseIf dRPPD_Percent.Value > 0 Then
                                Body &= String.Format(" RPPD from P{0} to P{1}", dRPPD_P.Text, dRPPD.Text)
                            End If
                            Body &= String.Format(" for the account of {0}.", BorrowerName)

                            SendSMS(GridView1.GetRowCellValue(x, "Mobile Number").ToString.Substring(3), Body, True)
                        End If
                    Next
                End If

                Timer1.Start()
                Dim OTP As New FrmOneTimePassword
                With OTP
                    .OTP = Code
                    If .ShowDialog = DialogResult.OK Then
                        If dPenalty_Percent.Value > 0 Then
                            Logs("Waive Payables", "Waive", String.Format("Waive Penalty of {0} From P{1} to P{2}.", BorrowerName, dPenalty_P.Text, dPenalty.Text), "", "", "", CreditNumber)
                        End If
                        If dRPPD_Percent.Value > 0 Then
                            Logs("Waive Payables", "Waive", String.Format("Waive RPPD of {0} From P{1} to P{2}.", BorrowerName, dRPPD_P.Text, dRPPD.Text), "", "", "", CreditNumber)
                        End If
                        Dim SQL As String = String.Format("UPDATE accounting_entry SET `status` = 'CANCELLED', PostStatus = 'CANCELLED' WHERE `status` = 'WAITING' AND PostStatus = IF(PaidFor = 'Penalty-W','PENDING','POSTED') AND PaidFor IN ('Penalty-W','RPPD-W') AND CVNumber = '' AND ReferenceN = '{0}';", CreditNumber)
                        If dPenalty_Percent.Value > 0 Then
                            SQL &= "INSERT INTO accounting_entry SET"
                            SQL &= String.Format(" ORNum = '{0}', ", ORNumber)
                            'SQL &= " ORDate = '', "
                            SQL &= String.Format(" ORDate = '{0}', ", Format(ORDate, "yyyy-MM-dd"))
                            SQL &= String.Format(" ReferenceN = '{0}', ", CreditNumber)
                            SQL &= " EntryType = 'CREDIT',"
                            SQL &= " AccountCode = '', " 'Waived Penalty
                            SQL &= " MotherCode = '', " 'Waived Penalty
                            SQL &= String.Format(" Payable = '{0}', ", dPenalty_P.Value)
                            SQL &= String.Format(" Amount = '{0}', ", dPenalty_D.Value)
                            SQL &= String.Format(" PaidFor = '{0}', ", "Penalty-W")
                            SQL &= String.Format(" Remarks = '{0}', ", "Waive for Penalty")
                            SQL &= String.Format(" `Status` = '{0}', ", "WAITING")
                            SQL &= String.Format(" PostStatus = '{0}', ", "PENDING")
                            SQL &= String.Format(" PenaltyPayable = '{0}', ", dPenalty.Value)
                            SQL &= String.Format(" BankID = '{0}', ", BankID)
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        End If
                        If dRPPD_Percent.Value > 0 Then
                            SQL &= "INSERT INTO accounting_entry SET"
                            SQL &= String.Format(" ORNum = '{0}', ", ORNumber)
                            'SQL &= " ORDate = '', "
                            SQL &= String.Format(" ORDate = '{0}', ", Format(ORDate, "yyyy-MM-dd"))
                            SQL &= String.Format(" ReferenceN = '{0}', ", CreditNumber)
                            SQL &= " EntryType = 'CREDIT',"
                            SQL &= " AccountCode = '', " 'Waived RPPD
                            SQL &= " MotherCode = '', " 'Waived Penalty
                            SQL &= String.Format(" Amount = '{0}', ", dRPPD_D.Value)
                            SQL &= String.Format(" PaidFor = '{0}', ", "RPPD-W")
                            SQL &= String.Format(" Remarks = '{0}', ", "Waive for RPPD")
                            SQL &= String.Format(" `Status` = '{0}', ", "WAITING")
                            SQL &= String.Format(" PostStatus = '{0}', ", "POSTED")
                            SQL &= String.Format(" BankID = '{0}', ", BankID)
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        End If
                        If SQL = "" Then
                        Else
                            DataObject(SQL)
                            btnWaive.DialogResult = DialogResult.OK
                            btnWaive.PerformClick()
                        End If
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Generate Code **************

        Code = GenerateOTAC()
        Timer1.Stop()
        dPenalty.Enabled = True
        dRPPD.Enabled = True
    End Sub

    Private Sub Timer_Date_Tick(sender As Object, e As EventArgs) Handles Timer_Date.Tick
        LoadCompanyMode()
    End Sub

    Private Sub LoadCompanyMode()
        If Prev_CompanyMode = CompanyMode Then
            Exit Sub
        Else
            Prev_CompanyMode = CompanyMode
        End If
        If CompanyMode = 0 Then
            lblRPPD.Visible = False
            dRPPD_P.Visible = False
            dRPPD.Visible = False
            LabelX1.Visible = False
            dRPPD_D.Visible = False
            dRPPD_Percent.Visible = False
            LabelX6.Visible = False
        Else
            lblRPPD.Visible = True
            dRPPD_P.Visible = True
            dRPPD.Visible = True
            LabelX1.Visible = True
            dRPPD_D.Visible = True
            dRPPD_Percent.Visible = True
            LabelX6.Visible = True
        End If
    End Sub
End Class