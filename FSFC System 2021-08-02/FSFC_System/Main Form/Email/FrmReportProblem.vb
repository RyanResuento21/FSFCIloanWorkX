Public Class FrmReportProblem
    Public FName As String
    Public AutoSend As Boolean
    Private Sub FrmReportProblem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 6, 1, True)
        If AutoSend Then
            txtSubject.Text = "Auto Generated Bug Report " & Format(Date.Now, "MMMM dd, yyyy hh:mm:ss") & " [" & Branch & "]"
        Else
            txtSubject.Text = "System Concern " & Format(Date.Now, "MMMM dd, yyyy hh:mm:ss") & " [" & Branch & "]"
        End If
        txtTo.Text = ASG_Email
        If User_Type = "ADMIN" Then
            txtTo.Enabled = True
        End If
        If AutoSend Then
            btnEmail.PerformClick()
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX11})

            GetLabelWithBackgroundFontSettings({LabelX10})

            GetTextBoxFontSettings({txtTo, txtSubject})

            GetButtonFontSettings({btnEmail, btnCancel})

            GetRickTextBoxFontSettings({txtBody})
        Catch ex As Exception
            TriggerBugReport("Report Problem - Fix UI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.E Then
            btnEmail.Focus()
            btnEmail.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub TxtSubject_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSubject.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBody.Focus()
        End If
    End Sub

    Private Sub TxtBody_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBody.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnEmail.Focus()
            btnEmail.PerformClick()
        End If
    End Sub

    Private Sub BtnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        If txtSubject.Text.Trim = "" Then
            MsgBox("Please fill the subject.", MsgBoxStyle.Information, "Info")
            txtSubject.Focus()
            Exit Sub
        End If

        If AutoSend Then
            GoTo Here
        End If
        If MsgBox("Are you sure you want to send this email?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
Here:
            Dim Message As String = txtBody.Text & "<br><br>"
            Message &= "Name: " & UpperCaseFirst(Empl_Name) & "<br>"
            Message &= "Branch: " & UpperCaseFirst(Branch) & "<br>"
            Message &= "Position: " & UpperCaseFirst(Empl_Position) & "<br>"
            Message &= "Department: " & UpperCaseFirst(Department) & "<br>"
            Message &= "Email: " & Empl_Email & "<br>"
            Message &= "Mobile: (+63)" & Empl_Phone & "<br>"
            Message &= "Extension: " & Empl_Extension & "<br>"
            Message &= "Date: " & Format(Date.Now, "MMMM dd, yyyy [dddd]") & "<br>"
            Message &= "Time: " & Format(Date.Now, "hh:mm:ss") & "<br>"
            Message &= "Computer Username: " & Environment.UserName & "<br>"

            Dim arrayList As New ArrayList()
            AttachmentFiles = arrayList
            AttachmentFiles.Add(FName)
            SendEmail(txtTo.Text & If(Empl_Email = "", "", ", " & Empl_Email), txtSubject.Text, Message, False, Not AutoSend, False, 0, "", "")
            Close()
        End If
    End Sub

    Private Sub PbMain_Click(sender As Object, e As MouseEventArgs) Handles pbMain.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim b As DevExpress.XtraEditors.PictureEdit = CType(sender, DevExpress.XtraEditors.PictureEdit)
            Dim Zoom As New FrmZoomImage
            With Zoom
                .TotalImage = 1
                .Type = "Attach File"
                .CurrentImage = b.Tag + 1
                .pbZoom.Image = b.Image.Clone
                .ShowDialog()
                If b.Tag = .CurrentImage Then
                    b.Image = .pbZoom.Image.Clone
                End If
                .Dispose()
            End With
        End If
    End Sub
End Class