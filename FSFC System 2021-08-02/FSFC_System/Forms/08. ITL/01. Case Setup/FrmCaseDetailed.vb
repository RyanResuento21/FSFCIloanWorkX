Public Class FrmCaseDetailed

    Public vDelete As Boolean
    Public vPrint As Boolean
    Public CaseID As Integer
    Public CaseNumber As String
    Private Sub FrmCaseDetailed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        LoadData()
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX24, LabelX1, LabelX18, LabelX20, LabelX4, LabelX15, LabelX16, LabelX2, LabelX5, LabelX3})

            GetTextBoxFontSettings({txtCaseNumber, txtDefendant, txtPrepared, txtLegal, txtCaseType})

            GetGroupControlFontSettings({GroupControl2})

            GetDoubleInputFontSettings({dBookValue, dDecisionValue})

            GetLabelFontSettingsDefaultSize({lblStatus})

            GetDateTimeInputFontSettings({dtpDateFilled, dtpLastModified})

            GetButtonFontSettings({btnCancel, btnPrint, btnDelete})
        Catch ex As Exception
            TriggerBugReport("Case Detailed - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Case Details", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        GridControl1.DataSource = DataSource(String.Format("SELECT ID, CategoryID, Category, SubCategoryID, SubCategory, DATE_FORMAT(MovementDate, '%M %d, %Y') AS 'Movement Date', ActionPlan AS 'Action Plan', DATE_FORMAT(ActionDate, '%M %d, %Y') AS 'Action Date', Remarks, Reason FROM case_details WHERE CaseID = '{0}' AND `status` = 'ACTIVE' ORDER BY ActionDate;", CaseID))

        If GridView1.RowCount > 14 Then
            GridColumn3.Width = 482 - 17
        Else
            GridColumn3.Width = 482
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

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        GridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting("CASE DETAILS", GridControl1)
        Logs("Case Details", "Print", "[SENSITIVE] Print Case " & txtCaseNumber.Text, "", "", "", "")
        Cursor = Cursors.Default
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
            Dim SQL As String = String.Format("UPDATE case_details SET `status` = 'DELETED' WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID"))
            'UPDATE CREDIT APPLICATION
            DataObject(SQL)
            Logs("Case Details", "Cancel", Reason, String.Format("Cancel Case Category {0} with Subcategory {1} on Case Number {2}.", GridView1.GetFocusedRowCellValue("Category"), GridView1.GetFocusedRowCellValue("SubCategory"), txtCaseNumber.Text), "", "", CaseNumber)

            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
            LoadData()
            If GridView1.RowCount > 0 Then
                SQL = String.Format("UPDATE case_main SET CategoryID = '{1}', SubCategoryID = '{2}' WHERE ID = '{0}';", CaseID, GridView1.GetRowCellValue(GridView1.RowCount - 1, "CategoryID"), GridView1.GetRowCellValue(GridView1.RowCount - 1, "SubCategoryID"))
                DataObject(SQL)
            End If
            FrmCaseSetup.LoadData()
        End If
    End Sub
End Class