Public Class FrmCollectionDetails

    Private Sub FrmCollectionDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        LoadData()
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

            GetButtonFontSettings({btnCancel, btnView})
        Catch ex As Exception
            TriggerBugReport("Collection Details - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Colelction Details", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        GridControl1.DataSource = DataSource(String.Format("CALL BookingAndCollection_Collection('{0}',{1},{2},'{3}',{4},{5},{6})", Format(FrmBookingAndCollection.dtpPeriod.Value, "yyyy-MM-dd"), FrmBookingAndCollection.cbxAllB.Checked, FrmBookingAndCollection.cbxBranch.SelectedValue, Multiple_ID, FrmBookingAndCollection.cbxAllBank.Checked, ValidateComboBox(FrmBookingAndCollection.cbxBank), ValidateComboBox(FrmBookingAndCollection.cbxBook)))
        For x As Integer = 1 To GridView1.RowCount
            GridView1.SetRowCellValue(x - 1, "NO.", x)
        Next

        If GridView1.RowCount > 23 Then
            GridColumn6.Width = 375 - 17
        Else
            GridColumn6.Width = 375
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("Document Number") = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        btnView.PerformClick()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim AR As New FrmOfficialReceipt
        With AR
            .Tag = 99
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

            Logs("Colelction Details", "View", "Official Receipt", "", "", "", "")
            .From_GL = True
            .Skip_FilterLoadData = True
            .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("Document Number")
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class