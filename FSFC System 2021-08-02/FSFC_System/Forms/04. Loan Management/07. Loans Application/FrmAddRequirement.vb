Public Class FrmAddRequirement

    Private Sub CbxDocument_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDocument.SelectedIndexChanged
        FixUI(AllowStandardUI)
        If cbxDocument.SelectedIndex = -1 Then
            txtRemarks.Text = ""
            cbxGen.Checked = False
            cbxForProduct.Checked = False
            cbxProduct.Text = ""
            cbxYes.Checked = False
            cbxNo.Checked = False
        Else
            Dim drv As DataRowView = DirectCast(cbxDocument.SelectedItem, DataRowView)
            txtRemarks.Text = drv("Remarks")
            If drv("is_genreq") = "YES" Then
                cbxGen.Checked = True
                cbxForProduct.Checked = False
                cbxProduct.Text = ""
            Else
                cbxGen.Checked = False
                cbxForProduct.Checked = True
                cbxProduct.Text = drv("product_code")
            End If
            If drv("is_married") = "YES" Then
                cbxYes.Checked = True
                cbxNo.Checked = False
            Else
                cbxYes.Checked = False
                cbxNo.Checked = True
            End If
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX155, LabelX1, LabelX2, LabelX3})

            GetTextBoxFontSettings({txtRemarks})

            GetCheckBoxFontSettings({cbxGen, cbxForProduct, cbxYes, cbxNo})

            GetButtonFontSettings({btnSelect, btnCancel})

            GetComboBoxFontSettings({cbxDocument, cbxProduct})
        Catch ex As Exception
            TriggerBugReport("Add Requirement - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub FrmAddRequirement_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub FrmAddRequirement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        With cbxDocument
            .DisplayMember = "Document"
            .ValueMember = "ID"
            .DataSource = DataSource(String.Format("SELECT ID, doc_name AS 'Document', Remarks, is_genreq, is_married, product_code FROM document_setup WHERE `status` = 'ACTIVE' ORDER BY doc_name;"))
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If cbxDocument.Text = "" Or cbxDocument.SelectedIndex = -1 Then
            MsgBox("Please select document to add.", MsgBoxStyle.Information, "Info")
            cbxDocument.DroppedDown = True
            Exit Sub
        End If

        If btnSelect.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes("Are you sure you want to add this requirement?") = MsgBoxResult.Yes Then
                btnSelect.DialogResult = DialogResult.OK
                btnSelect.PerformClick()
            End If
        End If
    End Sub
End Class