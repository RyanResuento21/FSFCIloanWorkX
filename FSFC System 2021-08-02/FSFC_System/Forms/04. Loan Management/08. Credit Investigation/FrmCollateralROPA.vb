Public Class FrmCollateralROPA

    Public ROPA As String
    Public AssetNumber_1 As String
    Public AssetNumber_2 As String
    Public AssetNumber_3 As String
    Public AssetNumber_4 As String
    Public AssetNumber_5 As String
    Public From_Application As Boolean
    Dim AddNew As Boolean
    Private Sub FrmCollateralROPA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        LoadData()

        If GridView1.RowCount = 0 Then
            MsgBox("No ROPA available to select", MsgBoxStyle.Information, "Info")
            Close()
        End If

        If From_Application = False Then
            btnAdd.Visible = False
            btnRemove.Visible = False
        Else
            If AssetNumber_1 = "" Then
                btnAdd.Enabled = False
                btnRemove.Enabled = False
            Else
                btnSelect.Enabled = False
            End If
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetButtonFontSettings({btnSelect, btnCancel, btnAdd, btnRemove})
        Catch ex As Exception
            TriggerBugReport("Collateral ROPA - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadData()
        Dim SQL As String = ""
        If ROPA = "VL" Then
            SQL = "SELECT R.ID, "
            SQL &= "    R.AssetNumber AS 'Asset Number',"
            SQL &= "    IFNULL(ROPOA_Buyer(R.AssetNumber),'') AS 'Buyer',"
            SQL &= "    CONCAT(R.Make, ' ', R.`Type`, ' Plate Number ', R.PlateNum) AS 'Description',"
            SQL &= "    IF(IFNULL(S.ID,0) > 0,'Reserved','Available') AS 'Status',"
            SQL &= "    Running_Balance(R.AssetNumber) 'Balance Ledger', IF(AppraiseSellingPrice = 0,IFNULL(S.Amount,Price),AppraiseSellingPrice) AS 'Price'"
            SQL &= " FROM ropoa_vehicle R"
            SQL &= " LEFT JOIN (SELECT ID, Amount, AssetNumber FROM sold_ropoa WHERE `status` = 'ACTIVE' AND SUBSTRING(AssetNumber,1,3) = 'ANV') S"
            SQL &= "    ON S.AssetNumber = R.AssetNumber"
        ElseIf ROPA = "RE" Then
            SQL = "SELECT R.ID, "
            SQL &= "    R.AssetNumber AS 'Asset Number',"
            SQL &= "    IFNULL(ROPOA_Buyer(R.AssetNumber),'') AS 'Buyer',"
            SQL &= "    CONCAT(R.TCT, ' ', R.`Classification`, ' Area of ', FORMAT(R.Area,0)) AS 'Description',"
            SQL &= "    IF(IFNULL(S.ID,0) > 0,'Reserved','Available') AS 'Status',"
            SQL &= "    Running_Balance(R.AssetNumber) 'Balance Ledger', IF(AppraiseSellingPrice = 0,IFNULL(S.Amount,Price),AppraiseSellingPrice) AS 'Price'"
            SQL &= " FROM ropoa_realestate R"
            SQL &= " LEFT JOIN (SELECT ID, Amount, AssetNumber FROM sold_ropoa WHERE `status` = 'ACTIVE' AND SUBSTRING(AssetNumber,1,3) = 'ANR') S"
            SQL &= "    ON S.AssetNumber = R.AssetNumber"
        End If
        SQL &= String.Format(" WHERE (R.sell_status = 'RESERVED' OR R.sell_status = 'SELL') AND `status` = 'ACTIVE' AND FIND_IN_SET(R.Branch_ID,'{0}')", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        If AssetNumber_1 = "" Then
        Else
            SQL &= String.Format(" AND R.AssetNumber {5} IN ('{0}','{1}','{2}','{3}','{4}')", AssetNumber_1, AssetNumber_2, AssetNumber_3, AssetNumber_4, AssetNumber_5, If(AddNew, "NOT", ""))
        End If
        If DefaultBankID > 0 Then
            SQL &= String.Format(" AND R.BankID = '{0}'", DefaultBankID)
        End If
        SQL &= " GROUP BY Description ORDER BY `Description` DESC;"
        GridControl1.DataSource = DataSource(SQL)
        If GridView1.RowCount > 5 Then
            GridColumn2.Width = 260 - 17
        Else
            GridColumn2.Width = 260
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub FrmCollateralROPA_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.S Then
            btnSelect.Focus()
            btnSelect.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If btnSelect.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If MsgBoxYes(String.Format("Are you sure you want to select the ROPA {0} for collateral?", GridView1.GetFocusedRowCellValue("Description"))) = MsgBoxResult.Yes Then
            btnSelect.DialogResult = DialogResult.OK
            btnSelect.PerformClick()
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            If Status = "Reserved" Then
                e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Bold)
            Else
                e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Regular)
            End If
        End If
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        btnSelect.PerformClick()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If MsgBox("Are you sure you want to add more ROPA?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            AddNew = True
            btnSelect.Enabled = True
            btnAdd.Enabled = False
            btnRemove.Enabled = False
            LoadData()
        End If
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If btnRemove.DialogResult = DialogResult.Cancel Then
        Else
            If MsgBox(String.Format("Are you sure you want to remove {0}?", GridView1.GetFocusedRowCellValue("Description")), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                Dim DT As DataTable = GridControl1.DataSource
                If GridView1.GetFocusedRowCellValue("Asset Number") = AssetNumber_1 Then
                    AssetNumber_1 = ""
                ElseIf GridView1.GetFocusedRowCellValue("Asset Number") = AssetNumber_2 Then
                    AssetNumber_2 = ""
                ElseIf GridView1.GetFocusedRowCellValue("Asset Number") = AssetNumber_3 Then
                    AssetNumber_3 = ""
                ElseIf GridView1.GetFocusedRowCellValue("Asset Number") = AssetNumber_4 Then
                    AssetNumber_4 = ""
                ElseIf GridView1.GetFocusedRowCellValue("Asset Number") = AssetNumber_5 Then
                    AssetNumber_5 = ""
                End If
                DT.Rows.RemoveAt(GridView1.FocusedRowHandle)
                MsgBox("Successfully Removed!", MsgBoxStyle.Information, "Info")
                btnRemove.DialogResult = DialogResult.Cancel
                btnRemove.DialogResult = DialogResult.Cancel
                btnRemove.PerformClick()
            End If
        End If
    End Sub
End Class