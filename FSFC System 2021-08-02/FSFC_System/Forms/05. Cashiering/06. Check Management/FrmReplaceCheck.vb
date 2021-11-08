Public Class FrmReplaceCheck

    Public Buyer As String
    Public ContactN As String
    Public AssetNumber As String
    Public ORNumber As String
    Public Sold_ID As String
    Public xDate As String
    Public Bank As String
    Public Branch As String
    Public From_Credit As Boolean
    Private Sub FrmReplaceCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        With cbxBank
            .DisplayMember = "Short Name"
            .ValueMember = "ID"
            .DataSource = DataSource("SELECT ID, Bank, short_name AS 'Short Name' FROM bank_setup WHERE `status` = 'ACTIVE';")
            .Text = Bank
        End With
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX11})

            GetLabelFontSettings({LabelX6, LabelX15, LabelX1})

            GetComboBoxFontSettings({cbxBank})

            GetDoubleInputFontSettings({dAmount})

            GetIntegerInputFontSettings({iChecks})

            GetButtonFontSettings({btnReplace, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Replace Check - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub FrmCheckDue_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.R Then
            btnReplace.Focus()
            btnReplace.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnReplace_Click(sender As Object, e As EventArgs) Handles btnReplace.Click
        If btnReplace.DialogResult = DialogResult.OK Then
        Else
            If From_Credit Then
                Dim PDC As New FrmPDCReceipt
                With PDC
                    .vSave = FrmPDCManagement.vSave
                    .vUpdate = FrmPDCManagement.vUpdate
                    .vDelete = FrmPDCManagement.vDelete
                    .vPrint = FrmPDCManagement.vPrint
                    .CreditNumber = AssetNumber
                    .From_Replace = True
                    .Checks = iChecks.Value
                    .DefaultBank = cbxBank.Text
                    .DefaultBranch = Branch

                    If .ShowDialog = DialogResult.OK Then
                        btnReplace.DialogResult = DialogResult.OK
                        btnReplace.PerformClick()
                    End If
                End With
            Else
                Dim Sched As New FrmPurchaseSched
                With Sched
                    .Buyer = Buyer
                    .ContactN = ContactN
                    .Months = iChecks.Value
                    .xDate = DateValue(xDate).AddMonths(-1)
                    .Amount = dAmount.Value
                    .AssetNumber = AssetNumber
                    .ORNumber = ORNumber
                    .TotalPayable = dAmount.Value * iChecks.Value
                    .Replace = True
                    .DefaultBank = cbxBank.Text
                    .DefaultBranch = Branch
                    .Sold_ID = Sold_ID
                    If .ShowDialog = DialogResult.OK Then
                        btnReplace.DialogResult = DialogResult.OK
                        btnReplace.PerformClick()
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub CbxBank_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBank.KeyDown
        If e.KeyCode = Keys.Enter Then
            iChecks.Focus()
        End If
    End Sub

    Private Sub IChecks_KeyDown(sender As Object, e As KeyEventArgs) Handles iChecks.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount.Focus()
        End If
    End Sub

    Private Sub DAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnReplace.Focus()
        End If
    End Sub

    Private Sub CbxBank_Leave(sender As Object, e As EventArgs) Handles cbxBank.Leave
        cbxBank.Text = ReplaceText(cbxBank.Text)
    End Sub
End Class