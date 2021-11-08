Imports Microsoft.Office.Interop
Public Class FrmCrecomList
    Public IncludeCrecomm As Boolean = True
    Public IncludeDM As Boolean
    Public IncludeRM As Boolean
    Public For_Signatory As Boolean
    Public DocumentNumber As String
    ReadOnly DT As New DataTable

    Private Sub FrmCrecomList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        If For_Signatory Then
            LabelX1.Text = "FOR SIGNATORY"
            Exit Sub
        End If
        Dim SQL As String = "SELECT "
        SQL &= String.Format("  IF({0} OR {1},IF(UPPER(Position) = 'DISTRICT MANAGER' OR UPPER(Position) = 'REGIONAL MANAGER','True','False'),'False') AS 'Include',", IncludeDM, IncludeRM)
        SQL &= "  CONCAT(IF(Prefix = '', '', CONCAT(Prefix, ' ')),IF(First_Name = '','',CONCAT(First_Name, ' ')),IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')),IF(Last_Name = '','',CONCAT(Last_Name, ' ')),Suffix) AS 'Name',"
        SQL &= "  CONCAT('+63',Phone) AS 'Phone',"
        SQL &= "  EmailAdd AS 'Email Address', `Position`, 'False' AS 'CC Only'"
        SQL &= "  FROM employee_setup"
        SQL &= String.Format("  WHERE (department = IF({2},'CREDIT COMMITTEE',FALSE) OR IF({0}, UPPER(Position) = 'DISTRICT MANAGER' AND FIND_IN_SET(branch_id, (SELECT GROUP_CONCAT(UB.branchid)  FROM user_branch UB WHERE UB.status = 'ACTIVE' AND FIND_IN_SET(UB.user_code, (SELECT GROUP_CONCAT(user_code) FROM users WHERE empl_id = employee_setup.ID AND `status` = 'ACTIVE')))),False) OR IF({1}, UPPER(Position) = 'REGIONAL MANAGER' AND FIND_IN_SET(branch_id, (SELECT GROUP_CONCAT(UB.branchid)  FROM user_branch UB WHERE UB.status = 'ACTIVE' AND FIND_IN_SET(UB.user_code, (SELECT GROUP_CONCAT(user_code) FROM users WHERE empl_id = employee_setup.ID AND `status` = 'ACTIVE')))),False)) AND `status` = 'ACTIVE'", IncludeDM, IncludeRM, IncludeCrecomm)
        SQL &= " ORDER BY `Name` ;"

        GridControl1.DataSource = DataSource(SQL)
        If GridView1.RowCount > 5 Then
            GridColumn2.Width = 270 - 17
        End If
        DT.Columns.Add("Path")
        DT.Columns.Add("Files")

        AttachmentFiles = New ArrayList()
        If AttachmentFiles.Count > 0 Then
            btnView.Visible = True
        Else
            btnView.Visible = False
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetButtonFontSettings({btnSend, btnCancel, btnAttachments, btnView})
        Catch ex As Exception
            TriggerBugReport("Credit Committee - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If btnSend.DialogResult = DialogResult.OK Then
        Else
            Dim ZeroSelected As Boolean = True
            For x As Integer = 0 To GridView1.RowCount - 1
                If CBool(GridView1.GetRowCellValue(x, "Include")) = True Then
                    ZeroSelected = False
                End If
            Next
            If ZeroSelected = True Then
                If For_Signatory Then
                    MsgBox("Please select for signatory.", MsgBoxStyle.Information, "Info")
                Else
                    MsgBox("Please select credit committee.", MsgBoxStyle.Information, "Info")
                End If
                Exit Sub
            End If

            If MsgBoxYes("Are you sure you want to send this email?") = MsgBoxResult.Yes Then
                If DocumentNumber = "" Then
                Else
                    For x As Integer = 0 To DT.Rows.Count - 1
                        FrmCreditInvestigation.WebAttachments(DocumentNumber, DT(x)("Path"), DT(x)("Files"))
                    Next
                End If
                btnSend.DialogResult = DialogResult.OK
                btnSend.PerformClick()
            End If
        End If
    End Sub

    Private Sub FrmCrecomList_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.S Then
            btnSend.Focus()
            btnSend.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.FieldName = "Include" And GridView1.GetFocusedRowCellValue("Include").ToString = "False" And IncludeDM And GridView1.GetFocusedRowCellValue("Position").ToString.ToUpper = "DISTRICT MANAGER" Then
            GridView1.SetFocusedRowCellValue("Include", True)
        End If
    End Sub

    Private Sub BtnAttachments_Click(sender As Object, e As EventArgs) Handles btnAttachments.Click
        Dim OpenFileDialog As New OpenFileDialog
        Dim x As Integer
        OpenFileDialog.Multiselect = True
        If (OpenFileDialog.ShowDialog(Me) = DialogResult.OK) Then
            For Each sFile As String In OpenFileDialog.FileNames
                If sFile.ToString.Contains(".doc") Then
                    Dim MyApp As New Word.Application
                    Dim MyWordDoc As Word.Document = MyApp.Documents.Add(sFile)
                    MyApp.Visible = False
                    MyWordDoc = MyApp.ActiveDocument
                    Dim WordToPDF As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\WordToPDF-" & DocumentNumber & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    MyWordDoc.SaveAs(WordToPDF, Word.WdSaveFormat.wdFormatPDF)
                    sFile = WordToPDF
                End If
                AttachmentFiles.Add(sFile)
                DT.Rows.Add(sFile, OpenFileDialog.SafeFileNames(x).ToString)
                x += 1
            Next
            MsgBox("Attachment Added!", MsgBoxStyle.Information, "Info")
            If AttachmentFiles.Count > 0 Then
                btnView.Visible = True
            Else
                btnView.Visible = False
            End If
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim View As New FrmAttachmentList
        With View
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class