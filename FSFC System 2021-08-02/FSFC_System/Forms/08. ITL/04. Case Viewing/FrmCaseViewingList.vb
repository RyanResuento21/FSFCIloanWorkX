Public Class FrmCaseViewingList

    Private Sub FrmCaseViewingList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetButtonFontSettings({btnCancel, btnPrint, btnLedger})
        Catch ex As Exception
            TriggerBugReport("Cash Viewing List - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Case Viewing", lblTitle.Text)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Cursor = Cursors.WaitCursor

        GridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting(lblTitle.Text, GridControl1)
        Logs("Case Viewing", "Print", "[SENSITIVE] Print Case Viewing List", "", "", "", "")

        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim ID As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ID"))
            Dim Branch As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Branch"))
            With e.Appearance
                If ID = "0" And Branch <> "" Then
                    .BackColor = Color.SeaGreen
                    .BackColor2 = Color.SeaGreen
                    .Font = New Font("Century Gothic", 8.25, FontStyle.Bold)
                    .ForeColor = Color.White
                Else
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .ForeColor = Color.Black
                End If
            End With
        End If
    End Sub

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

    Private Sub BtnLedger_Click(sender As Object, e As EventArgs) Handles btnLedger.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.GetFocusedRowCellValue("ID") = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmCaseLedger
        With Ledger
            .txtCaseNumber.Text = GridView1.GetFocusedRowCellValue("Case Number")
            .dtpDateFilled.Value = GridView1.GetFocusedRowCellValue("Date Filed")
            .txtDefendant.Text = GridView1.GetFocusedRowCellValue("Defendant")
            .dBookValue.Value = GridView1.GetFocusedRowCellValue("Book Value")
            .dDecisionValue.Value = GridView1.GetFocusedRowCellValue("Decision Value")
            .txtCollateral.Text = GridView1.GetFocusedRowCellValue("Collateral")
            .txtAccountNumber.Text = GridView1.GetFocusedRowCellValue("AccountN")
            .txtMobileNumber.Text = GridView1.GetFocusedRowCellValue("Mobile")
            If GridView1.GetFocusedRowCellValue("DueRP") = "" Then
                .dtpDueRP.CustomFormat = ""
            Else
                .dtpDueRP.CustomFormat = "MMMM dd, yyyy"
                .dtpDueRP.Value = GridView1.GetFocusedRowCellValue("DueRP")
            End If
            .CaseNumber = GridView1.GetFocusedRowCellValue("AccountNumber")
            .CaseID = GridView1.GetFocusedRowCellValue("ID")
            .CategoryID = GridView1.GetFocusedRowCellValue("CategoryID")

            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Public Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.GetFocusedRowCellValue("ID") = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Detailed As New FrmCaseDetailed
        With Detailed
            .CaseNumber = GridView1.GetFocusedRowCellValue("AccountNumber")
            .txtCaseNumber.Text = GridView1.GetFocusedRowCellValue("Case Number")
            .dtpDateFilled.Value = GridView1.GetFocusedRowCellValue("Date Filed")
            .txtDefendant.Text = GridView1.GetFocusedRowCellValue("Defendant")
            .dBookValue.Value = GridView1.GetFocusedRowCellValue("Book Value")
            .dDecisionValue.Value = GridView1.GetFocusedRowCellValue("Decision Value")
            .txtPrepared.Text = GridView1.GetFocusedRowCellValue("Prepared By")
            .txtLegal.Text = GridView1.GetFocusedRowCellValue("Counsel")
            .dtpLastModified.Value = GridView1.GetFocusedRowCellValue("LastModified")
            .lblStatus.Text = GridView1.GetFocusedRowCellValue("Case_Status")
            .vDelete = True
            .vPrint = True

            If GridView1.GetFocusedRowCellValue("Case_Status") = "ACTIVE" Then
                .lblStatus.ForeColor = Color.SeaGreen
            ElseIf GridView1.GetFocusedRowCellValue("Case_Status") = "DISMISSED" Then
                .lblStatus.ForeColor = Color.IndianRed
            ElseIf GridView1.GetFocusedRowCellValue("Case_Status") = "ARCHIVED" Then
                .lblStatus.ForeColor = Color.Orange
            ElseIf GridView1.GetFocusedRowCellValue("Case_Status") = "WRITTEN OFF" Then
                .lblStatus.ForeColor = Color.RoyalBlue
            End If

            .CaseID = GridView1.GetFocusedRowCellValue("ID")
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class