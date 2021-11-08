Public Class FrmAdvanceSearchAppraisal

    Private Sub FrmAdvancedSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        With cbxAppraisedBy
            If .Items.Count = 0 Then
                .ValueMember = "ID"
                .DisplayMember = "CI"
                .DataSource = DataSource("SELECT ID, CONCAT(IF(First_Name = '','',CONCAT(First_Name, ' ')), IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')), Last_Name) AS 'CI' FROM employee_setup WHERE (position LIKE '%CREDIT INVESTIGATOR%' OR can_appraise = 1) AND `status` = 'ACTIVE' ORDER BY `CI`;")
                .SelectedIndex = -1
            End If
        End With
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSearch.Focus()
            btnSearch.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub IFrom_ValueChanged(sender As Object, e As EventArgs)
        iTo.MinValue = iFrom.Value
        If iTo.Value < iFrom.Value Then
            iTo.Value = iFrom.Value
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        FrmAppraisalManagement.LoadData()
        Hide()
    End Sub

    Private Sub TxtKeyword_Leave(sender As Object, e As EventArgs) Handles txtKeyword.Leave
        txtKeyword.Text = ReplaceText(txtKeyword.Text)
    End Sub

    Private Sub TxtKeyword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKeyword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.Focus()
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub IFrom_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            iTo.PerformClick()
        End If
    End Sub

    Private Sub ITo_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnSearch.Focus()
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX11})

            GetLabelFontSettings({LabelX17, lblAge, lblTo, LabelX155})

            GetComboBoxFontSettings({cbxAppraisedBy})

            GetTextBoxFontSettings({txtKeyword})

            GetDoubleInputFontSettings({iFrom, iTo})

            GetButtonFontSettings({btnSearch, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Advance Search Appraisal - FixUI", ex.Message.ToString)
        End Try
    End Sub
End Class