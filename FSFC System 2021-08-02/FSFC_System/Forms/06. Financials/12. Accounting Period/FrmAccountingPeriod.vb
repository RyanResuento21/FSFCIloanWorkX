Imports DevExpress.XtraReports.UI
Public Class FrmAccountingPeriod

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Dim DT As DataTable
    Private Sub FrmAccountingPeriod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dtpYear.Value = Date.Now

        With RepositoryItemLookUpEdit2
            .DisplayMember = "Type"
            .ValueMember = "Type"
            .DataSource = DataSource("SELECT 'Open' AS 'Type' UNION ALL SELECT 'Locked' UNION ALL SELECT 'Closed'")
        End With

        LoadPeriod()

        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettingsDefaultSize({LabelIssued})

            GetLabelFontSettingsDefault({LabelX1, LabelX2, LabelX3})

            GetDateTimeInputFontSettingsDefault({dtpYear})

            GetButtonFontSettings({btnSave, btnCancel, btnPrint})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetRepositoryFontSettings({RepositoryItemLookUpEdit2})
        Catch ex As Exception
            TriggerBugReport("Accounting Period - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Accounting Period", lblTitle.Text)
    End Sub

    Private Sub LoadPeriod()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = " SELECT "
        SQL &= "    IFNULL(A.ID,0) AS 'ID',"
        SQL &= "    Branch_Code AS 'Branch', B.BranchID, "
        SQL &= "    IFNULL(A.Jan,'Open') AS 'Jan',"
        SQL &= "    IFNULL(A.Feb,'Open') AS 'Feb',"
        SQL &= "    IFNULL(A.Mar,'Open') AS 'Mar',"
        SQL &= "    IFNULL(A.Apr,'Open') AS 'Apr',"
        SQL &= "    IFNULL(A.May,'Open') AS 'May',"
        SQL &= "    IFNULL(A.Jun,'Open') AS 'Jun',"
        SQL &= "    IFNULL(A.Jul,'Open') AS 'Jul',"
        SQL &= "    IFNULL(A.Aug,'Open') AS 'Aug',"
        SQL &= "    IFNULL(A.Sep,'Open') AS 'Sep',"
        SQL &= "    IFNULL(A.Oct,'Open') AS 'Oct',"
        SQL &= "    IFNULL(A.Nov,'Open') AS 'Nov',"
        SQL &= "    IFNULL(A.Dec,'Open') AS 'Dec' "
        SQL &= String.Format(" FROM branch B LEFT JOIN accounting_period A ON B.`branch_code` = A.`Branch` AND A.`status` = 'ACTIVE'  AND A.`Year` = '{0}' WHERE B.`status` = 'ACTIVE'", Format(dtpYear.Value, "yyyy"))
        SQL &= "    ORDER BY BranchID ;"

        DT = DataSource(SQL)
        GridControl1.DataSource = DT
        GridControl2.DataSource = DT.Copy
        If DT(0)("ID") = 0 Then
            btnSave.Text = "&Save"
        Else
            btnSave.Text = "Update"
        End If

        If GridView1.RowCount > 24 Then
            GridColumn2.Width = 114 - 17
        Else
            GridColumn2.Width = 114
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        If e.Column.FieldName = "Jan" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Jan") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Jan") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Jan", "Open")
            End If
        ElseIf e.Column.FieldName = "Feb" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Feb") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Feb") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Feb", "Open")
            End If
        ElseIf e.Column.FieldName = "Mar" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Mar") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Mar") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Mar", "Open")
            End If
        ElseIf e.Column.FieldName = "Apr" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Apr") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Apr") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Apr", "Open")
            End If
        ElseIf e.Column.FieldName = "May" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "May") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "May") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("May", "Open")
            End If
        ElseIf e.Column.FieldName = "Jun" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Jun") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Jun") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Jun", "Open")
            End If
        ElseIf e.Column.FieldName = "Jul" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Jul") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Jul") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Jul", "Open")
            End If
        ElseIf e.Column.FieldName = "Aug" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Aug") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Aug") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Aug", "Open")
            End If
        ElseIf e.Column.FieldName = "Sep" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Sep") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Sep") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Sep", "Open")
            End If
        ElseIf e.Column.FieldName = "Oct" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Oct") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Oct") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Oct", "Open")
            End If
        ElseIf e.Column.FieldName = "Nov" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Nov") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Nov") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Nov", "Open")
            End If
        ElseIf e.Column.FieldName = "Dec" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Dec") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Dec") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Dec", "Open")
            End If
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If e.Column.FieldName = "Jan" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Jan") = "Locked" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Jan") = "Open" Then
                If Unposted(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID"), "01", Format(dtpYear.Value, "yyyy")) > 0 Then
                    MsgBox(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Branch") & " still have Unposted Transactions.", MsgBoxStyle.Information, "Info")
                    Dim Unposted As New FrmUnpostedList
                    With Unposted
                        .vDate = Format(dtpYear.Value, "yyyy") & "-01-01"
                        .vBranchID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID")
                        .ShowDialog()
                        .Dispose()
                    End With
                    GridView1.SetFocusedRowCellValue("Jan", "Open")
                End If
            ElseIf GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Jan") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Jan") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Jan", "Open")
            End If
        ElseIf e.Column.FieldName = "Feb" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Feb") = "Locked" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Feb") = "Open" Then
                If Unposted(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID"), "02", Format(dtpYear.Value, "yyyy")) > 0 Then
                    MsgBox(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Branch") & " still have Unposted Transactions.", MsgBoxStyle.Information, "Info")
                    Dim Unposted As New FrmUnpostedList
                    With Unposted
                        .vDate = Format(dtpYear.Value, "yyyy") & "-02-01"
                        .vBranchID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID")
                        .ShowDialog()
                        .Dispose()
                    End With
                    GridView1.SetFocusedRowCellValue("Feb", "Open")
                End If
            ElseIf GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Feb") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Feb") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Feb", "Open")
            End If
        ElseIf e.Column.FieldName = "Mar" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Mar") = "Locked" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Mar") = "Open" Then
                If Unposted(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID"), "03", Format(dtpYear.Value, "yyyy")) > 0 Then
                    MsgBox(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Branch") & " still have Unposted Transactions.", MsgBoxStyle.Information, "Info")
                    Dim Unposted As New FrmUnpostedList
                    With Unposted
                        .vDate = Format(dtpYear.Value, "yyyy") & "-03-01"
                        .vBranchID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID")
                        .ShowDialog()
                        .Dispose()
                    End With
                    GridView1.SetFocusedRowCellValue("Mar", "Open")
                End If
            ElseIf GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Mar") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Mar") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Mar", "Open")
            End If
        ElseIf e.Column.FieldName = "Apr" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Apr") = "Locked" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Apr") = "Open" Then
                If Unposted(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID"), "04", Format(dtpYear.Value, "yyyy")) > 0 Then
                    MsgBox(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Branch") & " still have Unposted Transactions.", MsgBoxStyle.Information, "Info")
                    Dim Unposted As New FrmUnpostedList
                    With Unposted
                        .vDate = Format(dtpYear.Value, "yyyy") & "-04-01"
                        .vBranchID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID")
                        .ShowDialog()
                        .Dispose()
                    End With
                    GridView1.SetFocusedRowCellValue("Apr", "Open")
                End If
            ElseIf GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Apr") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Apr") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Apr", "Open")
            End If
        ElseIf e.Column.FieldName = "May" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "May") = "Locked" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "May") = "Open" Then
                If Unposted(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID"), "05", Format(dtpYear.Value, "yyyy")) > 0 Then
                    MsgBox(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Branch") & " still have Unposted Transactions.", MsgBoxStyle.Information, "Info")
                    Dim Unposted As New FrmUnpostedList
                    With Unposted
                        .vDate = Format(dtpYear.Value, "yyyy") & "-05-01"
                        .vBranchID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID")
                        .ShowDialog()
                        .Dispose()
                    End With
                    GridView1.SetFocusedRowCellValue("May", "Open")
                End If
            ElseIf GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "May") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "May") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("May", "Open")
            End If
        ElseIf e.Column.FieldName = "Jun" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Jun") = "Locked" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Jun") = "Open" Then
                If Unposted(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID"), "06", Format(dtpYear.Value, "yyyy")) > 0 Then
                    MsgBox(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Branch") & " still have Unposted Transactions.", MsgBoxStyle.Information, "Info")
                    Dim Unposted As New FrmUnpostedList
                    With Unposted
                        .vDate = Format(dtpYear.Value, "yyyy") & "-06-01"
                        .vBranchID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID")
                        .ShowDialog()
                        .Dispose()
                    End With
                    GridView1.SetFocusedRowCellValue("Jun", "Open")
                End If
            ElseIf GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Jun") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Jun") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Jun", "Open")
            End If
        ElseIf e.Column.FieldName = "Jul" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Jul") = "Locked" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Jul") = "Open" Then
                If Unposted(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID"), "07", Format(dtpYear.Value, "yyyy")) > 0 Then
                    MsgBox(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Branch") & " still have Unposted Transactions.", MsgBoxStyle.Information, "Info")
                    Dim Unposted As New FrmUnpostedList
                    With Unposted
                        .vDate = Format(dtpYear.Value, "yyyy") & "-07-01"
                        .vBranchID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID")
                        .ShowDialog()
                        .Dispose()
                    End With
                    GridView1.SetFocusedRowCellValue("Jul", "Open")
                End If
            ElseIf GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Jul") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Jul") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Jul", "Open")
            End If
        ElseIf e.Column.FieldName = "Aug" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Aug") = "Locked" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Aug") = "Open" Then
                If Unposted(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID"), "08", Format(dtpYear.Value, "yyyy")) > 0 Then
                    MsgBox(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Branch") & " still have Unposted Transactions.", MsgBoxStyle.Information, "Info")
                    Dim Unposted As New FrmUnpostedList
                    With Unposted
                        .vDate = Format(dtpYear.Value, "yyyy") & "-08-01"
                        .vBranchID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID")
                        .ShowDialog()
                        .Dispose()
                    End With
                    GridView1.SetFocusedRowCellValue("Aug", "Open")
                End If
            ElseIf GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Aug") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Aug") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Aug", "Open")
            End If
        ElseIf e.Column.FieldName = "Sep" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Sep") = "Locked" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Sep") = "Open" Then
                If Unposted(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID"), "09", Format(dtpYear.Value, "yyyy")) > 0 Then
                    MsgBox(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Branch") & " still have Unposted Transactions.", MsgBoxStyle.Information, "Info")
                    Dim Unposted As New FrmUnpostedList
                    With Unposted
                        .vDate = Format(dtpYear.Value, "yyyy") & "-09-01"
                        .vBranchID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID")
                        .ShowDialog()
                        .Dispose()
                    End With
                    GridView1.SetFocusedRowCellValue("Sep", "Open")
                End If
            ElseIf GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Sep") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Sep") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Sep", "Open")
            End If
        ElseIf e.Column.FieldName = "Oct" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Oct") = "Locked" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Oct") = "Open" Then
                If Unposted(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID"), "10", Format(dtpYear.Value, "yyyy")) > 0 Then
                    MsgBox(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Branch") & " still have Unposted Transactions.", MsgBoxStyle.Information, "Info")
                    Dim Unposted As New FrmUnpostedList
                    With Unposted
                        .vDate = Format(dtpYear.Value, "yyyy") & "-10-01"
                        .vBranchID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID")
                        .ShowDialog()
                        .Dispose()
                    End With
                    GridView1.SetFocusedRowCellValue("Oct", "Open")
                End If
            ElseIf GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Oct") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Oct") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Oct", "Open")
            End If
        ElseIf e.Column.FieldName = "Nov" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Nov") = "Locked" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Nov") = "Open" Then
                If Unposted(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID"), "11", Format(dtpYear.Value, "yyyy")) > 0 Then
                    MsgBox(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Branch") & " still have Unposted Transactions.", MsgBoxStyle.Information, "Info")
                    Dim Unposted As New FrmUnpostedList
                    With Unposted
                        .vDate = Format(dtpYear.Value, "yyyy") & "-11-01"
                        .vBranchID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID")
                        .ShowDialog()
                        .Dispose()
                    End With
                    GridView1.SetFocusedRowCellValue("Nov", "Open")
                End If
            ElseIf GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Nov") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Nov") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Nov", "Open")
            End If
        ElseIf e.Column.FieldName = "Dec" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Dec") = "Locked" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Dec") = "Open" Then
                If Unposted(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID"), "12", Format(dtpYear.Value, "yyyy")) > 0 Then
                    MsgBox(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Branch") & " still have Unposted Transactions.", MsgBoxStyle.Information, "Info")
                    Dim Unposted As New FrmUnpostedList
                    With Unposted
                        .vDate = Format(dtpYear.Value, "yyyy") & "-12-01"
                        .vBranchID = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "BranchID")
                        .ShowDialog()
                        .Dispose()
                    End With
                    GridView1.SetFocusedRowCellValue("Dec", "Open")
                End If
            ElseIf GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Dec") = "Closed" And GridView2.GetRowCellValue(GridView1.FocusedRowHandle, "Dec") = "Open" Then
                MsgBox("Transaction is still OPEN, Please LOCK the transaction first.", MsgBoxStyle.Information, "Info")
                GridView1.SetFocusedRowCellValue("Dec", "Open")
            End If
        End If
    End Sub

    Private Sub DtpYear_ValueChanged(sender As Object, e As EventArgs) Handles dtpYear.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        LoadPeriod()
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs)
        FrmAccountingPeriod_Load(sender, e)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim Report As New RptAccountingPeriod
        With Report
            .Name = String.Format("Accounting Period for {0}", Format(dtpYear.Value, "yyyy"))
            .lblAsOf.Text = Format(Date.Now, "MMMM dd, yyyy")
            .lblYear.Text = Format(dtpYear.Value, "yyyy")

            .DataSource = GridControl1.DataSource
            .lblBranch.DataBindings.Add("Text", GridControl1.DataSource, "Branch")
            .lbl_01.DataBindings.Add("Text", GridControl1.DataSource, "Jan")
            .lbl_02.DataBindings.Add("Text", GridControl1.DataSource, "Feb")
            .lbl_03.DataBindings.Add("Text", GridControl1.DataSource, "Mar")
            .lbl_04.DataBindings.Add("Text", GridControl1.DataSource, "Apr")
            .lbl_05.DataBindings.Add("Text", GridControl1.DataSource, "May")
            .lbl_06.DataBindings.Add("Text", GridControl1.DataSource, "Jun")
            .lbl_07.DataBindings.Add("Text", GridControl1.DataSource, "Jul")
            .lbl_08.DataBindings.Add("Text", GridControl1.DataSource, "Aug")
            .lbl_09.DataBindings.Add("Text", GridControl1.DataSource, "Sep")
            .lbl_10.DataBindings.Add("Text", GridControl1.DataSource, "Oct")
            .lbl_11.DataBindings.Add("Text", GridControl1.DataSource, "Nov")
            .lbl_12.DataBindings.Add("Text", GridControl1.DataSource, "Dec")
            Logs("Accounting Period", "Print", "[SENSITIVE] Print Accounting Period for " & dtpYear.Text, "", "", "", "")

            .ShowPreview()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub IOpen_Click(sender As Object, e As EventArgs) Handles iOpen.Click
        If GridView1.FocusedColumn.ToString = "Branch" Then
        Else
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, GridView1.FocusedColumn) = "Locked" Then
                    GridView1.SetRowCellValue(x, GridView1.FocusedColumn, "Open")
                End If
            Next
        End If
    End Sub

    Private Sub ILock_Click(sender As Object, e As EventArgs) Handles iLock.Click
        If GridView1.FocusedColumn.ToString = "Branch" Then
        Else
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, GridView1.FocusedColumn) = "Open" Then
                    GridView1.SetRowCellValue(x, GridView1.FocusedColumn, "Locked")
                End If
            Next
        End If
    End Sub

    Private Sub IClose_Click(sender As Object, e As EventArgs) Handles iClose.Click
        If GridView1.FocusedColumn.ToString = "Branch" Then
        Else
            If MsgBox("Are you sure you want to close this accounting period?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                For x As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(x, GridView1.FocusedColumn) = "Locked" Then
                        GridView1.SetRowCellValue(x, GridView1.FocusedColumn, "Closed")
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Jan As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Jan"))
            Dim Feb As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Feb"))
            Dim Mar As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Mar"))
            Dim Apr As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Apr"))
            Dim May As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("May"))
            Dim Jun As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Jun"))
            Dim Jul As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Jul"))
            Dim Aug As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Aug"))
            Dim Sep As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Sep"))
            Dim Oct As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Oct"))
            Dim Nov As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Nov"))
            Dim Dec As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Dec"))
            If Jan = "Open" Then
                View.Columns("Jan").AppearanceCell.ForeColor = Color.Firebrick
            ElseIf Jan = "Locked" Then
                View.Columns("Jan").AppearanceCell.ForeColor = Color.RoyalBlue
            ElseIf Jan = "Closed" Then
                View.Columns("Jan").AppearanceCell.ForeColor = Color.SeaGreen
            End If
            If Feb = "Open" Then
                View.Columns("Feb").AppearanceCell.ForeColor = Color.Firebrick
            ElseIf Feb = "Locked" Then
                View.Columns("Feb").AppearanceCell.ForeColor = Color.RoyalBlue
            ElseIf Feb = "Closed" Then
                View.Columns("Feb").AppearanceCell.ForeColor = Color.SeaGreen
            End If
            If Mar = "Open" Then
                View.Columns("Mar").AppearanceCell.ForeColor = Color.Firebrick
            ElseIf Mar = "Locked" Then
                View.Columns("Mar").AppearanceCell.ForeColor = Color.RoyalBlue
            ElseIf Mar = "Closed" Then
                View.Columns("Mar").AppearanceCell.ForeColor = Color.SeaGreen
            End If
            If Apr = "Open" Then
                View.Columns("Apr").AppearanceCell.ForeColor = Color.Firebrick
            ElseIf Apr = "Locked" Then
                View.Columns("Apr").AppearanceCell.ForeColor = Color.RoyalBlue
            ElseIf Apr = "Closed" Then
                View.Columns("Apr").AppearanceCell.ForeColor = Color.SeaGreen
            End If
            If May = "Open" Then
                View.Columns("May").AppearanceCell.ForeColor = Color.Firebrick
            ElseIf May = "Locked" Then
                View.Columns("May").AppearanceCell.ForeColor = Color.RoyalBlue
            ElseIf May = "Closed" Then
                View.Columns("May").AppearanceCell.ForeColor = Color.SeaGreen
            End If
            If Jun = "Open" Then
                View.Columns("Jun").AppearanceCell.ForeColor = Color.Firebrick
            ElseIf Jun = "Locked" Then
                View.Columns("Jun").AppearanceCell.ForeColor = Color.RoyalBlue
            ElseIf Jun = "Closed" Then
                View.Columns("Jun").AppearanceCell.ForeColor = Color.SeaGreen
            End If
            If Jul = "Open" Then
                View.Columns("Jul").AppearanceCell.ForeColor = Color.Firebrick
            ElseIf Jul = "Locked" Then
                View.Columns("Jul").AppearanceCell.ForeColor = Color.RoyalBlue
            ElseIf Jul = "Closed" Then
                View.Columns("Jul").AppearanceCell.ForeColor = Color.SeaGreen
            End If
            If Aug = "Open" Then
                View.Columns("Aug").AppearanceCell.ForeColor = Color.Firebrick
            ElseIf Aug = "Locked" Then
                View.Columns("Aug").AppearanceCell.ForeColor = Color.RoyalBlue
            ElseIf Aug = "Closed" Then
                View.Columns("Aug").AppearanceCell.ForeColor = Color.SeaGreen
            End If
            If Sep = "Open" Then
                View.Columns("Sep").AppearanceCell.ForeColor = Color.Firebrick
            ElseIf Sep = "Locked" Then
                View.Columns("Sep").AppearanceCell.ForeColor = Color.RoyalBlue
            ElseIf Sep = "Closed" Then
                View.Columns("Sep").AppearanceCell.ForeColor = Color.SeaGreen
            End If
            If Oct = "Open" Then
                View.Columns("Oct").AppearanceCell.ForeColor = Color.Firebrick
            ElseIf Oct = "Locked" Then
                View.Columns("Oct").AppearanceCell.ForeColor = Color.RoyalBlue
            ElseIf Oct = "Closed" Then
                View.Columns("Oct").AppearanceCell.ForeColor = Color.SeaGreen
            End If
            If Nov = "Open" Then
                View.Columns("Nov").AppearanceCell.ForeColor = Color.Firebrick
            ElseIf Nov = "Locked" Then
                View.Columns("Nov").AppearanceCell.ForeColor = Color.RoyalBlue
            ElseIf Nov = "Closed" Then
                View.Columns("Nov").AppearanceCell.ForeColor = Color.SeaGreen
            End If
            If Dec = "Open" Then
                View.Columns("Dec").AppearanceCell.ForeColor = Color.Firebrick
            ElseIf Dec = "Locked" Then
                View.Columns("Dec").AppearanceCell.ForeColor = Color.RoyalBlue
            ElseIf Dec = "Closed" Then
                View.Columns("Dec").AppearanceCell.ForeColor = Color.SeaGreen
            End If
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim SQL As String = ""
                For x As Integer = 0 To GridView1.RowCount - 1
                    SQL &= "INSERT INTO accounting_period SET "
                    With GridView1
                        SQL &= String.Format(" `Year` = '{0}',", Format(dtpYear.Value, "yyyy"))
                        SQL &= String.Format(" `Branch` = '{0}',", .GetRowCellValue(x, "Branch"))
                        SQL &= String.Format(" `Jan` = '{0}',", .GetRowCellValue(x, "Jan"))
                        SQL &= String.Format(" `Feb` = '{0}',", .GetRowCellValue(x, "Feb"))
                        SQL &= String.Format(" `Mar` = '{0}',", .GetRowCellValue(x, "Mar"))
                        SQL &= String.Format(" `Apr` = '{0}',", .GetRowCellValue(x, "Apr"))
                        SQL &= String.Format(" `May` = '{0}',", .GetRowCellValue(x, "May"))
                        SQL &= String.Format(" `Jun` = '{0}',", .GetRowCellValue(x, "Jun"))
                        SQL &= String.Format(" `Jul` = '{0}',", .GetRowCellValue(x, "Jul"))
                        SQL &= String.Format(" `Aug` = '{0}',", .GetRowCellValue(x, "Aug"))
                        SQL &= String.Format(" `Sep` = '{0}',", .GetRowCellValue(x, "Sep"))
                        SQL &= String.Format(" `Oct` = '{0}',", .GetRowCellValue(x, "Oct"))
                        SQL &= String.Format(" `Nov` = '{0}',", .GetRowCellValue(x, "Nov"))
                        SQL &= String.Format(" `Dec` = '{0}',", .GetRowCellValue(x, "Dec"))
                    End With
                    SQL &= String.Format(" `PreparedID` = '{0}';", Empl_ID)
                Next
                DataObject(SQL)
                Logs("Accounting Period", "Save", "Save Accounting Period", String.Format("Save Accounting Period for {0}", Format(dtpYear.Value, "yyyy")), "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                LoadPeriod()
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim SQL As String = ""
                For x As Integer = 0 To GridView1.RowCount - 1
                    SQL &= "UPDATE accounting_period SET "
                    With GridView1
                        SQL &= String.Format(" `Jan` = '{0}',", .GetRowCellValue(x, "Jan"))
                        SQL &= String.Format(" `Feb` = '{0}',", .GetRowCellValue(x, "Feb"))
                        SQL &= String.Format(" `Mar` = '{0}',", .GetRowCellValue(x, "Mar"))
                        SQL &= String.Format(" `Apr` = '{0}',", .GetRowCellValue(x, "Apr"))
                        SQL &= String.Format(" `May` = '{0}',", .GetRowCellValue(x, "May"))
                        SQL &= String.Format(" `Jun` = '{0}',", .GetRowCellValue(x, "Jun"))
                        SQL &= String.Format(" `Jul` = '{0}',", .GetRowCellValue(x, "Jul"))
                        SQL &= String.Format(" `Aug` = '{0}',", .GetRowCellValue(x, "Aug"))
                        SQL &= String.Format(" `Sep` = '{0}',", .GetRowCellValue(x, "Sep"))
                        SQL &= String.Format(" `Oct` = '{0}',", .GetRowCellValue(x, "Oct"))
                        SQL &= String.Format(" `Nov` = '{0}',", .GetRowCellValue(x, "Nov"))
                        SQL &= String.Format(" `Dec` = '{0}'", .GetRowCellValue(x, "Dec"))
                        SQL &= String.Format(" WHERE ID = '{0}' AND `Year` = '{1}';", .GetRowCellValue(x, "ID"), Format(dtpYear.Value, "yyyy"))
                    End With
                Next
                DataObject(SQL)
                Logs("Accounting Period", "Update", String.Format("Update Accounting Period for {0}", Format(dtpYear.Value, "yyyy")), Changes(), "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                LoadPeriod()
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            With GridView1
                For x As Integer = 0 To .RowCount - 1
                    If .GetRowCellValue(x, "Jan") = GridView2.GetRowCellValue(x, "Jan") Then
                    Else
                        Change &= String.Format("Change {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Jan"), .GetRowCellValue(x, "Jan"), .GetRowCellValue(x, "Branch") & " - Jan " & Format(dtpYear.Value, "yyyy"))
                    End If
                    If .GetRowCellValue(x, "Feb") = GridView2.GetRowCellValue(x, "Feb") Then
                    Else
                        Change &= String.Format("Change {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Feb"), .GetRowCellValue(x, "Feb"), .GetRowCellValue(x, "Branch") & " - Feb " & Format(dtpYear.Value, "yyyy"))
                    End If
                    If .GetRowCellValue(x, "Mar") = GridView2.GetRowCellValue(x, "Mar") Then
                    Else
                        Change &= String.Format("Change {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Mar"), .GetRowCellValue(x, "Mar"), .GetRowCellValue(x, "Branch") & " - Mar " & Format(dtpYear.Value, "yyyy"))
                    End If
                    If .GetRowCellValue(x, "Apr") = GridView2.GetRowCellValue(x, "Apr") Then
                    Else
                        Change &= String.Format("Change {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Apr"), .GetRowCellValue(x, "Apr"), .GetRowCellValue(x, "Branch") & " - Apr " & Format(dtpYear.Value, "yyyy"))
                    End If
                    If .GetRowCellValue(x, "May") = GridView2.GetRowCellValue(x, "May") Then
                    Else
                        Change &= String.Format("Change {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "May"), .GetRowCellValue(x, "May"), .GetRowCellValue(x, "Branch") & " - May " & Format(dtpYear.Value, "yyyy"))
                    End If
                    If .GetRowCellValue(x, "Jun") = GridView2.GetRowCellValue(x, "Jun") Then
                    Else
                        Change &= String.Format("Change {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Jun"), .GetRowCellValue(x, "Jun"), .GetRowCellValue(x, "Branch") & " - Jun " & Format(dtpYear.Value, "yyyy"))
                    End If
                    If .GetRowCellValue(x, "Jul") = GridView2.GetRowCellValue(x, "Jul") Then
                    Else
                        Change &= String.Format("Change {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Jul"), .GetRowCellValue(x, "Jul"), .GetRowCellValue(x, "Branch") & " - Jul " & Format(dtpYear.Value, "yyyy"))
                    End If
                    If .GetRowCellValue(x, "Aug") = GridView2.GetRowCellValue(x, "Aug") Then
                    Else
                        Change &= String.Format("Change {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Aug"), .GetRowCellValue(x, "Aug"), .GetRowCellValue(x, "Branch") & " - Aug " & Format(dtpYear.Value, "yyyy"))
                    End If
                    If .GetRowCellValue(x, "Sep") = GridView2.GetRowCellValue(x, "Sep") Then
                    Else
                        Change &= String.Format("Change {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Sep"), .GetRowCellValue(x, "Sep"), .GetRowCellValue(x, "Branch") & " - Sep " & Format(dtpYear.Value, "yyyy"))
                    End If
                    If .GetRowCellValue(x, "Oct") = GridView2.GetRowCellValue(x, "Oct") Then
                    Else
                        Change &= String.Format("Change {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Oct"), .GetRowCellValue(x, "Oct"), .GetRowCellValue(x, "Branch") & " - Oct " & Format(dtpYear.Value, "yyyy"))
                    End If
                    If .GetRowCellValue(x, "Nov") = GridView2.GetRowCellValue(x, "Nov") Then
                    Else
                        Change &= String.Format("Change {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Nov"), .GetRowCellValue(x, "Nov"), .GetRowCellValue(x, "Branch") & " - Nov " & Format(dtpYear.Value, "yyyy"))
                    End If
                    If .GetRowCellValue(x, "Dec") = GridView2.GetRowCellValue(x, "Dec") Then
                    Else
                        Change &= String.Format("Change {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Dec"), .GetRowCellValue(x, "Dec"), .GetRowCellValue(x, "Branch") & " - Dec " & Format(dtpYear.Value, "yyyy"))
                    End If
                Next
            End With
        Catch ex As Exception
            TriggerBugReport("Accounting Period - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function
End Class