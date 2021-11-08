Imports DevExpress.XtraReports.UI
Public Class FrmAgingNew

    Public vPrint As Boolean
    Dim FirstLoad As Boolean = True
    Dim DT_Schedule As DataTable
    Dim DT_Topsheet As DataTable
    Dim DT_TopsheetProcedure As DataTable
    Private Sub FrmAgingNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView4})
        FixUI(AllowStandardUI)
        GetBandedGridApperance({BandedGridView1, BandedGridView2, BandedGridView3})
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dtpAsOf.Value = Date.Now

        DT_Topsheet = DataSource("SELECT '' AS 'Product', '' AS 'Sub-Categories', '' AS 'Code', 0.00 AS 'Outstanding Balance', 0.00 AS 'Current', 0.00 AS '1-30 Days', 0.00 AS '31-60 Days', 0.00 AS '61-90 Days', 0.00 AS '91-120 Days', 0.00 AS 'Over 120 Days' LIMIT 0")

        With cbxBranch
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            .DataSource = DataSource(String.Format("SELECT ID, Branch FROM branch WHERE `status` = 'ACTIVE' AND ID IN ({0}) ORDER BY BranchID;", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            .SelectedValue = Branch_ID
            If Branch_ID = 0 And MultipleBranch Then
            Else
                cbxAllB.Visible = False
                .Enabled = False
            End If
        End With

        With cbxBusinessCenter
            .ValueMember = "ID"
            .DisplayMember = "BusinessCenter"
            .SelectedIndex = -1
        End With

        With cbxBook
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            FirstLoad = False
            .DataSource = DataSource("SELECT 1 AS 'ID', 'Bank 1' AS 'Bank' UNION ALL SELECT 2 AS 'ID', 'Bank 2' AS 'Bank';")
        End With
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

            GetLabelFontSettings({LabelX1, LabelX4, LabelX42})

            GetCheckBoxFontSettings({cbxMerge, cbxAllB, cbxAllBank})

            GetComboBoxFontSettings({cbxBranch, cbxBusinessCenter, cbxBook, cbxBank})

            GetDateTimeInputFontSettings({dtpAsOf})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint, btnPrintCustomized})

            GetTabControlFontSettings({SuperTabControl1})

            GetContextMenuBarFontSettings({ContextMenuBar3})
        Catch ex As Exception
            TriggerBugReport("Aging New - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Aging", lblTitle.Text)
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles BandedGridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblTitle.Focus()
            Dim Old_Remarks As String = DataObject(String.Format("SELECT AgingRemarks FROM credit_application WHERE CreditNumber = '{0}';", BandedGridView1.GetFocusedRowCellValue("CreditNumber")))
            If BandedGridView1.GetFocusedRowCellValue("Remarks") <> Old_Remarks Then
                If MsgBoxYes(String.Format("Are you sure you want to update the remarks for this aging from {1} to {0}?", BandedGridView1.GetFocusedRowCellValue("Remarks"), Old_Remarks)) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE credit_application SET AgingRemarks = '{1}' WHERE CreditNumber = '{0}';", BandedGridView1.GetFocusedRowCellValue("CreditNumber"), BandedGridView1.GetFocusedRowCellValue("Remarks")))
                    Logs("Aging", "Remarks", String.Format("Change remarks for Credit Number {0} from {1} to {2}.", BandedGridView1.GetFocusedRowCellValue("CreditNumber"), Old_Remarks, BandedGridView1.GetFocusedRowCellValue("Remarks")), "", "", "", "")
                    MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            ElseIf e.Control And e.KeyCode = Keys.S Then
                If MsgBoxYes("Are you sure you want to save this Table Display") = MsgBoxResult.Yes Then
                    Dim SQL As String
                    If GridControl1.Tag = 1 Then
                        SQL = "UPDATE column_settings SET"
                    Else
                        SQL = "INSERT INTO column_settings SET"
                    End If
                    SQL &= String.Format(" UserID = '{0}', ", User_ID)
                    SQL &= String.Format(" FormID = '{0}', ", Tag)
                    SQL &= String.Format(" Column1V = '{0}', ", GridColumn1.VisibleIndex)
                    SQL &= String.Format(" Column2V = '{0}', ", GridColumn2.VisibleIndex)
                    SQL &= String.Format(" Column3V = '{0}', ", GridColumn3.VisibleIndex)
                    SQL &= String.Format(" Column4V = '{0}', ", GridColumn4.VisibleIndex)
                    SQL &= String.Format(" Column5V = '{0}', ", GridColumn5.VisibleIndex)
                    SQL &= String.Format(" Column6V = '{0}', ", GridColumn6.VisibleIndex)
                    SQL &= String.Format(" Column7V = '{0}', ", GridColumn7.VisibleIndex)
                    SQL &= String.Format(" Column8V = '{0}', ", GridColumn8.VisibleIndex)
                    SQL &= String.Format(" Column9V = '{0}', ", GridColumn9.VisibleIndex)
                    SQL &= String.Format(" Column10V = '{0}', ", GridColumn10.VisibleIndex)
                    SQL &= String.Format(" Column11V = '{0}', ", GridColumn11.VisibleIndex)
                    SQL &= String.Format(" Column12V = '{0}', ", GridColumn12.VisibleIndex)
                    SQL &= String.Format(" Column13V = '{0}', ", GridColumn13.VisibleIndex)
                    SQL &= String.Format(" Column14V = '{0}', ", GridColumn14.VisibleIndex)
                    SQL &= String.Format(" Column15V = '{0}', ", GridColumn15.VisibleIndex)
                    SQL &= String.Format(" Column16V = '{0}', ", GridColumn16.VisibleIndex)
                    SQL &= String.Format(" Column17V = '{0}', ", GridColumn17.VisibleIndex)
                    SQL &= String.Format(" Column18V = '{0}', ", GridColumn18.VisibleIndex)
                    SQL &= String.Format(" Column19V = '{0}', ", GridColumn19.VisibleIndex)
                    SQL &= String.Format(" Column20V = '{0}', ", GridColumn20.VisibleIndex)
                    SQL &= String.Format(" Column21V = '{0}', ", GridColumn21.VisibleIndex)
                    SQL &= String.Format(" Column22V = '{0}', ", GridColumn22.VisibleIndex)
                    SQL &= String.Format(" Column23V = '{0}', ", GridColumn23.VisibleIndex)
                    SQL &= String.Format(" Column24V = '{0}', ", GridColumn24.VisibleIndex)
                    SQL &= String.Format(" Column25V = '{0}', ", GridColumn25.VisibleIndex)
                    SQL &= String.Format(" Column26V = '{0}', ", GridColumn26.VisibleIndex)
                    SQL &= String.Format(" Column27V = '{0}', ", GridColumn27.VisibleIndex)
                    SQL &= String.Format(" Column28V = '{0}', ", GridColumn28.VisibleIndex)
                    SQL &= String.Format(" Column29V = '{0}', ", GridColumn29.VisibleIndex)
                    SQL &= String.Format(" Column30V = '{0}', ", GridColumn30.VisibleIndex)
                    SQL &= String.Format(" Column31V = '{0}', ", GridColumn31.VisibleIndex)
                    SQL &= String.Format(" Column32V = '{0}', ", GridColumn32.VisibleIndex)
                    SQL &= String.Format(" Column33V = '{0}', ", GridColumn33.VisibleIndex)
                    SQL &= String.Format(" Column1W = '{0}', ", GridColumn1.Width)
                    SQL &= String.Format(" Column2W = '{0}', ", GridColumn2.Width)
                    SQL &= String.Format(" Column3W = '{0}', ", GridColumn3.Width)
                    SQL &= String.Format(" Column4W = '{0}', ", GridColumn4.Width)
                    SQL &= String.Format(" Column5W = '{0}', ", GridColumn5.Width)
                    SQL &= String.Format(" Column6W = '{0}', ", GridColumn6.Width)
                    SQL &= String.Format(" Column7W = '{0}', ", GridColumn7.Width)
                    SQL &= String.Format(" Column8W = '{0}', ", GridColumn8.Width)
                    SQL &= String.Format(" Column9W = '{0}', ", GridColumn9.Width)
                    SQL &= String.Format(" Column10W = '{0}', ", GridColumn10.Width)
                    SQL &= String.Format(" Column11W = '{0}', ", GridColumn11.Width)
                    SQL &= String.Format(" Column12W = '{0}', ", GridColumn12.Width)
                    SQL &= String.Format(" Column13W = '{0}', ", GridColumn13.Width)
                    SQL &= String.Format(" Column14W = '{0}', ", GridColumn14.Width)
                    SQL &= String.Format(" Column15W = '{0}', ", GridColumn15.Width)
                    SQL &= String.Format(" Column16W = '{0}', ", GridColumn16.Width)
                    SQL &= String.Format(" Column17W = '{0}', ", GridColumn17.Width)
                    SQL &= String.Format(" Column18W = '{0}', ", GridColumn18.Width)
                    SQL &= String.Format(" Column19W = '{0}', ", GridColumn19.Width)
                    SQL &= String.Format(" Column20W = '{0}', ", GridColumn20.Width)
                    SQL &= String.Format(" Column21W = '{0}', ", GridColumn21.Width)
                    SQL &= String.Format(" Column22W = '{0}', ", GridColumn22.Width)
                    SQL &= String.Format(" Column23W = '{0}', ", GridColumn23.Width)
                    SQL &= String.Format(" Column24W = '{0}', ", GridColumn24.Width)
                    SQL &= String.Format(" Column25W = '{0}', ", GridColumn25.Width)
                    SQL &= String.Format(" Column26W = '{0}', ", GridColumn26.Width)
                    SQL &= String.Format(" Column27W = '{0}', ", GridColumn27.Width)
                    SQL &= String.Format(" Column28W = '{0}', ", GridColumn28.Width)
                    SQL &= String.Format(" Column29W = '{0}', ", GridColumn29.Width)
                    SQL &= String.Format(" Column30W = '{0}', ", GridColumn30.Width)
                    SQL &= String.Format(" Column31W = '{0}', ", GridColumn31.Width)
                    SQL &= String.Format(" Column32W = '{0}', ", GridColumn32.Width)
                    SQL &= String.Format(" Column33W = '{0}' ", GridColumn33.Width)
                    If GridControl1.Tag = 1 Then
                        SQL &= String.Format(" WHERE FormID = '{0}' AND `status` = 'ACTIVE';", Tag)
                    End If
                    DataObject(SQL)
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                End If
            End If
        End If
    End Sub

    Private Sub Load_Topsheet()
        DT_Topsheet.Rows.Clear()
        Dim Outstanding As Double
        Dim Current As Double
        Dim Day1_30 As Double
        Dim Day31_60 As Double
        Dim Day61_90 As Double
        Dim Day91_120 As Double
        Dim Day120Over As Double
        Dim CurrentProduct As String = ""
        For x As Integer = 0 To BandedGridView5.RowCount - 1
            Current += CDbl(If(IsNumeric(BandedGridView5.GetRowCellValue(x, "CURRENT")), BandedGridView5.GetRowCellValue(x, "CURRENT"), 0))
            Day1_30 += CDbl(BandedGridView5.GetRowCellValue(x, "1-30 Days"))
            Day31_60 += CDbl(BandedGridView5.GetRowCellValue(x, "31-60 Days"))
            Day61_90 += CDbl(BandedGridView5.GetRowCellValue(x, "61-90 Days"))
            Day91_120 += CDbl(BandedGridView5.GetRowCellValue(x, "91-120 Days"))
            Day120Over += CDbl(BandedGridView5.GetRowCellValue(x, "Over 120 Days"))
            If BandedGridView5.GetRowCellValue(x, "Product") <> If(BandedGridView5.RowCount - 1 > x, BandedGridView5.GetRowCellValue(x + 1, "Product"), If(x = BandedGridView5.RowCount - 1, BandedGridView5.GetRowCellValue(x - 1, "Product"), BandedGridView5.GetRowCellValue(x, "Product"))) Or (x = BandedGridView5.RowCount - 1 And BandedGridView5.GetRowCellValue(x, "Product") <> CurrentProduct) Then
                Outstanding = Current + Day1_30 + Day31_60 + Day61_90 + Day91_120 + Day120Over
                DT_Topsheet.Rows.Add(BandedGridView5.GetRowCellValue(x, "Product Type"), BandedGridView5.GetRowCellValue(x, "Product"), BandedGridView5.GetRowCellValue(x, "Product Code"), Outstanding, Current, Day1_30, Day31_60, Day61_90, Day91_120, Day120Over)
                CurrentProduct = BandedGridView5.GetRowCellValue(x, "Product")
                Current = 0
                Day1_30 = 0
                Day31_60 = 0
                Day61_90 = 0
                Day91_120 = 0
                Day120Over = 0
            End If
        Next
        GridControl2.DataSource = DT_Topsheet
    End Sub

    Private Sub Load_TopsheetProcedure()
        DT_TopsheetProcedure = DataSource("SELECT ID, Remedial AS 'Collection Procedure', RemedialCode AS 'Code', 0.00 AS 'Outstanding Balance', 0.00 AS 'Current', 0.00 AS '1-30 Days', 0.00 AS '31-60 Days', 0.00 AS '61-90 Days', 0.00 AS '91-120 Days', 0.00 AS 'Over 120 Days' FROM remedial_setup WHERE `status` = 'ACTIVE' ORDER BY RemedialCode")
        For x As Integer = 0 To BandedGridView5.RowCount - 1
            For y As Integer = 0 To DT_TopsheetProcedure.Rows.Count - 1
                If BandedGridView5.GetRowCellValue(x, "RemedyAppliedID") = DT_TopsheetProcedure(y)("ID") Then
                    DT_TopsheetProcedure(y)("Current") += CDbl(BandedGridView5.GetRowCellValue(x, "CURRENT"))
                    DT_TopsheetProcedure(y)("1-30 Days") += CDbl(BandedGridView5.GetRowCellValue(x, "1-30 Days"))
                    DT_TopsheetProcedure(y)("31-60 Days") += CDbl(BandedGridView5.GetRowCellValue(x, "31-60 Days"))
                    DT_TopsheetProcedure(y)("61-90 Days") += CDbl(BandedGridView5.GetRowCellValue(x, "61-90 Days"))
                    DT_TopsheetProcedure(y)("91-120 Days") += CDbl(BandedGridView5.GetRowCellValue(x, "91-120 Days"))
                    DT_TopsheetProcedure(y)("Over 120 Days") += CDbl(BandedGridView5.GetRowCellValue(x, "Over 120 Days"))
                    DT_TopsheetProcedure(y)("Outstanding Balance") += CDbl(BandedGridView5.GetRowCellValue(x, "CURRENT")) + CDbl(BandedGridView5.GetRowCellValue(x, "1-30 Days")) + CDbl(BandedGridView5.GetRowCellValue(x, "31-60 Days")) + CDbl(BandedGridView5.GetRowCellValue(x, "61-90 Days")) + CDbl(BandedGridView5.GetRowCellValue(x, "91-120 Days")) + CDbl(BandedGridView5.GetRowCellValue(x, "Over 120 Days"))
                End If
            Next
        Next
        GridControl3.DataSource = DT_TopsheetProcedure
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim DT As DataTable = DataSource(String.Format("CALL Aging('{0}','{1}',{2},{3},{4},'{5}',{6},{7},{8})", Format(dtpAsOf.Value, "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-dd"), cbxAllB.Checked, ValidateComboBox(cbxBranch), ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook)))
        For x As Integer = 0 To DT.Rows.Count - 1
            If DT(x)("Gross Monthly Amortization") = DT(x)("Monthly") Then
                DT(x)("CURRENT") = If(DT(x)("Gross Monthly Amortization") * DT(x)("Remaining Months") > 0, DT(x)("Gross Monthly Amortization") * DT(x)("Remaining Months"), 0) - If(DT(x)("Gross Monthly Amortization") * DT(x)("Remaining Months") > DT(x)("END_Face Amount"), (DT(x)("Gross Monthly Amortization") * DT(x)("Remaining Months")) - DT(x)("END_Face Amount"), 0)
                DT(x)("1-30 Days") = If(DT(x)("END_Face Amount") - DT(x)("CURRENT") > 0 And DT(x)("Remaining Months in Days") >= -30, DT(x)("Gross Monthly Amortization"), 0) - If(DT(x)("Remaining Months in Days") >= -30 And DT(x)("END_Face Amount") - DT(x)("CURRENT") < DT(x)("Gross Monthly Amortization") And DT(x)("END_Face Amount") - DT(x)("CURRENT") > 0, DT(x)("Gross Monthly Amortization") - (DT(x)("END_Face Amount") - DT(x)("CURRENT")), 0)
                DT(x)("31-60 Days") = If(((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) > 0 And DT(x)("Remaining Months in Days") >= -60, DT(x)("Gross Monthly Amortization"), 0) - If(DT(x)("Remaining Months in Days") >= -60 And ((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) < DT(x)("Gross Monthly Amortization") And ((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) > 0, DT(x)("Gross Monthly Amortization") - ((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")), 0)
                DT(x)("61-90 Days") = If((((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) - DT(x)("31-60 Days")) > 0 And DT(x)("Remaining Months in Days") >= -90, DT(x)("Gross Monthly Amortization"), 0) - If(DT(x)("Remaining Months in Days") >= -90 And (((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) - DT(x)("31-60 Days")) < DT(x)("Gross Monthly Amortization") And (((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) - DT(x)("31-60 Days")) > 0, DT(x)("Gross Monthly Amortization") - (((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) - DT(x)("31-60 Days")), 0)
                DT(x)("91-120 Days") = If((((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) - DT(x)("31-60 Days")) - DT(x)("61-90 Days") > 0 And DT(x)("Remaining Months in Days") >= -120, DT(x)("Gross Monthly Amortization"), 0) - If(DT(x)("Remaining Months in Days") >= -120 And ((((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) - DT(x)("31-60 Days")) - DT(x)("61-90 Days")) < DT(x)("Gross Monthly Amortization") And ((((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) - DT(x)("31-60 Days")) - DT(x)("61-90 Days")) > 0, DT(x)("Gross Monthly Amortization") - ((((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) - DT(x)("31-60 Days")) - DT(x)("61-90 Days")), 0)
                DT(x)("Total Past Due") = NegativeNotAllowed(DT(x)("END_Face Amount") - DT(x)("CURRENT"))
                DT(x)("Over 120 Days") = NegativeNotAllowed(DT(x)("Total Past Due") - (DT(x)("1-30 Days") + DT(x)("31-60 Days") + DT(x)("61-90 Days") + DT(x)("91-120 Days")))
            Else
                LoadAmortizationBasic(DT(x)("CreditNumber"), GridControl4)
                For y As Integer = 1 To GridView4.RowCount - 1
                    If If(GridView4.GetRowCellValue(y, "Due Date").ToString = "TOTAL", 0, CDate(GridView4.GetRowCellValue(y, "Due Date")) <= dtpAsOf.Value) And y < GridView4.RowCount - 1 Then
                    Else
                        DT(x)("CURRENT") = If(CDbl(GridView4.GetRowCellValue(y - 1, "Loans Receivable")) > 0, CDbl(GridView4.GetRowCellValue(y - 1, "Loans Receivable")), 0) - If(CDbl(GridView4.GetRowCellValue(y - 1, "Loans Receivable")) > DT(x)("END_Face Amount"), (CDbl(GridView4.GetRowCellValue(y - 1, "Loans Receivable"))) - DT(x)("END_Face Amount"), 0)
                        If DT(x)("FACE AMOUNT") = DT(x)("CURRENT") Then
                            Exit For
                        End If
                        DT(x)("1-30 Days") = If(DT(x)("END_Face Amount") - DT(x)("CURRENT") > 0 And DT(x)("Remaining Months in Days") >= -30, CDbl(MustBeNumeric(GridView4.GetRowCellValue(y - 1, "Monthly"))), 0) - If(DT(x)("Remaining Months in Days") >= -30 And DT(x)("END_Face Amount") - DT(x)("CURRENT") < CDbl(MustBeNumeric(GridView4.GetRowCellValue(y - 1, "Monthly"))) And DT(x)("END_Face Amount") - DT(x)("CURRENT") > 0, CDbl(MustBeNumeric(GridView4.GetRowCellValue(y - 1, "Monthly"))) - (DT(x)("END_Face Amount") - DT(x)("CURRENT")), 0)
                        DT(x)("31-60 Days") = If((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days") > 0 And DT(x)("Remaining Months in Days") >= -60, CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 2 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("1-30 Days")) > 0, y - 2, y - 1), "Monthly"))), 0) - If(DT(x)("Remaining Months in Days") >= -60 And (DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days") < CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 2 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("1-30 Days")) > 0, y - 2, y - 1), "Monthly"))) And (DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days") > 0, CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 2 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("1-30 Days")) > 0, y - 2, y - 1), "Monthly"))) - ((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")), 0)
                        Dim DownSchedule As Integer = 0
                        If CDbl(DT(x)("CURRENT")) = 0 And CDbl(DT(x)("1-30 Days")) = 0 Then
                            DownSchedule += 1
                        End If
                        DT(x)("61-90 Days") = If(((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) - DT(x)("31-60 Days") > 0 And DT(x)("Remaining Months in Days") >= -90, CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 3 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("31-60 Days")) > 0, y - (3 - DownSchedule), y - 1), "Monthly"))), 0) - If(DT(x)("Remaining Months in Days") >= -90 And ((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) - DT(x)("31-60 Days") < CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 3 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("31-60 Days")) > 0, y - (3 - DownSchedule), y - 1), "Monthly"))) And ((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) - DT(x)("31-60 Days") > 0, CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 3 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("31-60 Days")) > 0, y - (3 - DownSchedule), y - 1), "Monthly"))) - (((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) - DT(x)("31-60 Days")), 0)
                        If CDbl(DT(x)("CURRENT")) = 0 And CDbl(DT(x)("31-60 Days")) = 0 Then
                            DownSchedule += 1
                        End If
                        DT(x)("91-120 Days") = If(((((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) - DT(x)("31-60 Days")) - DT(x)("61-90 Days")) > 0 And DT(x)("Remaining Months in Days") >= -120, CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 4 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("61-90 Days")) > 0, y - (4 - DownSchedule), y - 1), "Monthly"))), 0) - If(DT(x)("Remaining Months in Days") >= -120 And ((((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) - DT(x)("31-60 Days")) - DT(x)("61-90 Days")) < CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 4 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("61-90 Days")) > 0, y - (4 - DownSchedule), y - 1), "Monthly"))) And ((((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) - DT(x)("31-60 Days")) - DT(x)("61-90 Days")) > 0, CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 4 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("61-90 Days")) > 0, y - (4 - DownSchedule), y - 1), "Monthly"))) - ((((DT(x)("END_Face Amount") - DT(x)("CURRENT")) - DT(x)("1-30 Days")) - DT(x)("31-60 Days")) - DT(x)("61-90 Days")), 0)
                        DT(x)("Total Past Due") = NegativeNotAllowed(DT(x)("END_Face Amount") - DT(x)("CURRENT"))
                        DT(x)("Over 120 Days") = NegativeNotAllowed(DT(x)("Total Past Due") - (DT(x)("1-30 Days") + DT(x)("31-60 Days") + DT(x)("61-90 Days") + DT(x)("91-120 Days")))
                        Exit For
                    End If
                Next
            End If
        Next

        Dim DT_WithTotal As DataTable = DT.Copy
        DT_WithTotal.Rows.Clear()

        Dim T_Principal_BEG As Double
        Dim T_UDI_BEG As Double
        Dim T_RPPD_BEG As Double
        Dim T_FaceAmount_BEG As Double
        Dim T_Principal_CRB As Double
        Dim T_UDI_CRB As Double
        Dim T_RPPD_CRB As Double
        Dim T_FaceAmount_CRB As Double
        Dim T_Principal_CDB As Double
        Dim T_UDI_CDB As Double
        Dim T_RPPD_CDB As Double
        Dim T_FaceAmount_CDB As Double
        Dim T_Principal_GJB As Double
        Dim T_UDI_GJB As Double
        Dim T_RPPD_GJB As Double
        Dim T_FaceAmount_GJB As Double
        Dim T_Principal_END As Double
        Dim T_UDI_END As Double
        Dim T_RPPD_END As Double
        Dim T_FaceAmount_END As Double
        Dim T_CURRENT As Double
        Dim T_1_30 As Double
        Dim T_31_60 As Double
        Dim T_61_90 As Double
        Dim T_91_120 As Double
        Dim T_Over120 As Double
        Dim T_PassDue As Double

        Dim OT_Principal_BEG As Double
        Dim OT_UDI_BEG As Double
        Dim OT_RPPD_BEG As Double
        Dim OT_FaceAmount_BEG As Double
        Dim OT_Principal_CRB As Double
        Dim OT_UDI_CRB As Double
        Dim OT_RPPD_CRB As Double
        Dim OT_FaceAmount_CRB As Double
        Dim OT_Principal_CDB As Double
        Dim OT_UDI_CDB As Double
        Dim OT_RPPD_CDB As Double
        Dim OT_FaceAmount_CDB As Double
        Dim OT_Principal_GJB As Double
        Dim OT_UDI_GJB As Double
        Dim OT_RPPD_GJB As Double
        Dim OT_FaceAmount_GJB As Double
        Dim OT_Principal_END As Double
        Dim OT_UDI_END As Double
        Dim OT_RPPD_END As Double
        Dim OT_FaceAmount_END As Double
        Dim OT_CURRENT As Double
        Dim OT_1_30 As Double
        Dim OT_31_60 As Double
        Dim OT_61_90 As Double
        Dim OT_91_120 As Double
        Dim OT_Over120 As Double
        Dim OT_PassDue As Double
        For x As Integer = 0 To DT.Rows.Count - 1
            If x = 0 Then
                DT_WithTotal.Rows.Add(DT(x)("Product"), DT(x)("CreditNumber"), DT(x)("Product Type"), DT(x)("Product Code"), DT(x)("Account No."), DT(x)("Borrowers Name"), DT(x)("CI"), DT(x)("AO"), DT(x)("Address"), DT(x)("Area"), DT(x)("Contact Number"), DT(x)("Collateral Description"), DT(x)("Date Granted"), DT(x)("Type"), DT(x)("Monthly Due Date"), DT(x)("Term"), DT(x)("Monthly Interest Rate"), DT(x)("Principal"), DT(x)("UDI"), DT(x)("RPPD"), DT(x)("Face Amount"), DT(x)("Plate Number"), DT(x)("Mode of Payment"), DT(x)("Term in Days"), DT(x)("Maturity Date"), DT(x)("Net Monthly Amortization"), DT(x)("Gross Monthly Amortization"), DT(x)("Months Lapsed"), DT(x)("Days Lapsed"), DT(x)("Remaining Months"), DT(x)("Remaining Months in Days"), DT(x)("Beg_Principal"), DT(x)("Beg_UDI"), DT(x)("Beg_RPPD"), DT(x)("Beg_Face Amount"), DT(x)("CRB_Principal"), DT(x)("CRB_UDI"), DT(x)("CRB_RPPD"), DT(x)("CRB_Face Amount"), DT(x)("CDB_Principal"), DT(x)("CDB_UDI"), DT(x)("CDB_RPPD"), DT(x)("CDB_Face Amount"), DT(x)("GJB_Principal"), DT(x)("GJB_UDI"), DT(x)("GJB_RPPD"), DT(x)("GJB_Face Amount"), DT(x)("END_Principal"), DT(x)("END_UDI"), DT(x)("END_RPPD"), DT(x)("END_Face Amount"), DT(x)("CURRENT"), DT(x)("1-30 Days"), DT(x)("31-60 Days"), DT(x)("61-90 Days"), DT(x)("91-120 Days"), DT(x)("Over 120 Days"), DT(x)("Total Past Due"), DT(x)("Last Payment Date"), DT(x)("Remedy Applied"), DT(x)("Remarks"), DT(x)("RemedyAppliedID"), DT(x)("Monthly"))
                If DT.Rows.Count > 1 Then
                    If DT(x)("Product") = DT(x + 1)("Product") Then
                        T_Principal_BEG += DT(x)("Beg_Principal")
                        T_UDI_BEG += DT(x)("Beg_UDI")
                        T_RPPD_BEG += DT(x)("Beg_RPPD")
                        T_FaceAmount_BEG += DT(x)("Beg_Face Amount")
                        T_Principal_CRB += DT(x)("CRB_Principal")
                        T_UDI_CRB += DT(x)("CRB_UDI")
                        T_RPPD_CRB += DT(x)("CRB_RPPD")
                        T_FaceAmount_CRB += DT(x)("CRB_Face Amount")
                        T_Principal_CDB += DT(x)("CDB_Principal")
                        T_UDI_CDB += DT(x)("CDB_UDI")
                        T_RPPD_CDB += DT(x)("CDB_RPPD")
                        T_FaceAmount_CDB += DT(x)("CDB_Face Amount")
                        T_Principal_GJB += DT(x)("GJB_Principal")
                        T_UDI_GJB += DT(x)("GJB_UDI")
                        T_RPPD_GJB += DT(x)("GJB_RPPD")
                        T_FaceAmount_GJB += DT(x)("GJB_Face Amount")
                        T_Principal_END += DT(x)("END_Principal")
                        T_UDI_END += DT(x)("END_UDI")
                        T_RPPD_END += DT(x)("END_RPPD")
                        T_FaceAmount_END += DT(x)("END_Face Amount")
                        T_CURRENT += DT(x)("CURRENT")
                        T_1_30 += DT(x)("1-30 Days")
                        T_31_60 += DT(x)("31-60 Days")
                        T_61_90 += DT(x)("61-90 Days")
                        T_91_120 += DT(x)("91-120 Days")
                        T_Over120 += DT(x)("Over 120 Days")
                        T_PassDue += DT(x)("Total Past Due")
                    End If
                Else
                    T_Principal_BEG += DT(x)("Beg_Principal")
                    T_UDI_BEG += DT(x)("Beg_UDI")
                    T_RPPD_BEG += DT(x)("Beg_RPPD")
                    T_FaceAmount_BEG += DT(x)("Beg_Face Amount")
                    T_Principal_CRB += DT(x)("CRB_Principal")
                    T_UDI_CRB += DT(x)("CRB_UDI")
                    T_RPPD_CRB += DT(x)("CRB_RPPD")
                    T_FaceAmount_CRB += DT(x)("CRB_Face Amount")
                    T_Principal_CDB += DT(x)("CDB_Principal")
                    T_UDI_CDB += DT(x)("CDB_UDI")
                    T_RPPD_CDB += DT(x)("CDB_RPPD")
                    T_FaceAmount_CDB += DT(x)("CDB_Face Amount")
                    T_Principal_GJB += DT(x)("GJB_Principal")
                    T_UDI_GJB += DT(x)("GJB_UDI")
                    T_RPPD_GJB += DT(x)("GJB_RPPD")
                    T_FaceAmount_GJB += DT(x)("GJB_Face Amount")
                    T_Principal_END += DT(x)("END_Principal")
                    T_UDI_END += DT(x)("END_UDI")
                    T_RPPD_END += DT(x)("END_RPPD")
                    T_FaceAmount_END += DT(x)("END_Face Amount")
                    T_CURRENT += DT(x)("CURRENT")
                    T_1_30 += DT(x)("1-30 Days")
                    T_31_60 += DT(x)("31-60 Days")
                    T_61_90 += DT(x)("61-90 Days")
                    T_91_120 += DT(x)("91-120 Days")
                    T_Over120 += DT(x)("Over 120 Days")
                    T_PassDue += DT(x)("Total Past Due")

                    DT_WithTotal.Rows.Add("SUB-TOTAL", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "", 0.0, 0.0, 0.0, 0.0, "", "", 0, "", 0.0, 0.0, 0, 0, 0, 0, T_Principal_BEG, T_UDI_BEG, T_RPPD_BEG, T_FaceAmount_BEG, T_Principal_CRB, T_UDI_CRB, T_RPPD_CRB, T_FaceAmount_CRB, T_Principal_CDB, T_UDI_CDB, T_RPPD_CDB, T_FaceAmount_CDB, T_Principal_GJB, T_UDI_GJB, T_RPPD_GJB, T_FaceAmount_GJB, T_Principal_END, T_UDI_END, T_RPPD_END, T_FaceAmount_END, T_CURRENT, T_1_30, T_31_60, T_61_90, T_91_120, T_Over120, T_PassDue, "", "", "", 0, 0)
                    DT_WithTotal.Rows.Add()
                End If
            Else
                If x = DT.Rows.Count - 1 Then
                    DT_WithTotal.Rows.Add(DT(x)("Product"), DT(x)("CreditNumber"), DT(x)("Product Type"), DT(x)("Product Code"), DT(x)("Account No."), DT(x)("Borrowers Name"), DT(x)("CI"), DT(x)("AO"), DT(x)("Address"), DT(x)("Area"), DT(x)("Contact Number"), DT(x)("Collateral Description"), DT(x)("Date Granted"), DT(x)("Type"), DT(x)("Monthly Due Date"), DT(x)("Term"), DT(x)("Monthly Interest Rate"), DT(x)("Principal"), DT(x)("UDI"), DT(x)("RPPD"), DT(x)("Face Amount"), DT(x)("Plate Number"), DT(x)("Mode of Payment"), DT(x)("Term in Days"), DT(x)("Maturity Date"), DT(x)("Net Monthly Amortization"), DT(x)("Gross Monthly Amortization"), DT(x)("Months Lapsed"), DT(x)("Days Lapsed"), DT(x)("Remaining Months"), DT(x)("Remaining Months in Days"), DT(x)("Beg_Principal"), DT(x)("Beg_UDI"), DT(x)("Beg_RPPD"), DT(x)("Beg_Face Amount"), DT(x)("CRB_Principal"), DT(x)("CRB_UDI"), DT(x)("CRB_RPPD"), DT(x)("CRB_Face Amount"), DT(x)("CDB_Principal"), DT(x)("CDB_UDI"), DT(x)("CDB_RPPD"), DT(x)("CDB_Face Amount"), DT(x)("GJB_Principal"), DT(x)("GJB_UDI"), DT(x)("GJB_RPPD"), DT(x)("GJB_Face Amount"), DT(x)("END_Principal"), DT(x)("END_UDI"), DT(x)("END_RPPD"), DT(x)("END_Face Amount"), DT(x)("CURRENT"), DT(x)("1-30 Days"), DT(x)("31-60 Days"), DT(x)("61-90 Days"), DT(x)("91-120 Days"), DT(x)("Over 120 Days"), DT(x)("Total Past Due"), DT(x)("Last Payment Date"), DT(x)("Remedy Applied"), DT(x)("Remarks"), DT(x)("RemedyAppliedID"), DT(x)("Monthly"))
                End If
                If DT(x)("Product") = DT(x - 1)("Product") Then
                    T_Principal_BEG += DT(x)("Beg_Principal")
                    T_UDI_BEG += DT(x)("Beg_UDI")
                    T_RPPD_BEG += DT(x)("Beg_RPPD")
                    T_FaceAmount_BEG += DT(x)("Beg_Face Amount")
                    T_Principal_CRB += DT(x)("CRB_Principal")
                    T_UDI_CRB += DT(x)("CRB_UDI")
                    T_RPPD_CRB += DT(x)("CRB_RPPD")
                    T_FaceAmount_CRB += DT(x)("CRB_Face Amount")
                    T_Principal_CDB += DT(x)("CDB_Principal")
                    T_UDI_CDB += DT(x)("CDB_UDI")
                    T_RPPD_CDB += DT(x)("CDB_RPPD")
                    T_FaceAmount_CDB += DT(x)("CDB_Face Amount")
                    T_Principal_GJB += DT(x)("GJB_Principal")
                    T_UDI_GJB += DT(x)("GJB_UDI")
                    T_RPPD_GJB += DT(x)("GJB_RPPD")
                    T_FaceAmount_GJB += DT(x)("GJB_Face Amount")
                    T_Principal_END += DT(x)("END_Principal")
                    T_UDI_END += DT(x)("END_UDI")
                    T_RPPD_END += DT(x)("END_RPPD")
                    T_FaceAmount_END += DT(x)("END_Face Amount")
                    T_CURRENT += DT(x)("CURRENT")
                    T_1_30 += DT(x)("1-30 Days")
                    T_31_60 += DT(x)("31-60 Days")
                    T_61_90 += DT(x)("61-90 Days")
                    T_91_120 += DT(x)("91-120 Days")
                    T_Over120 += DT(x)("Over 120 Days")
                    T_PassDue += DT(x)("Total Past Due")
                    If x = DT.Rows.Count - 1 Then
                        DT_WithTotal.Rows.Add("SUB-TOTAL", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "", 0.0, 0.0, 0.0, 0.0, "", "", 0, "", 0.0, 0.0, 0, 0, 0, 0, T_Principal_BEG, T_UDI_BEG, T_RPPD_BEG, T_FaceAmount_BEG, T_Principal_CRB, T_UDI_CRB, T_RPPD_CRB, T_FaceAmount_CRB, T_Principal_CDB, T_UDI_CDB, T_RPPD_CDB, T_FaceAmount_CDB, T_Principal_GJB, T_UDI_GJB, T_RPPD_GJB, T_FaceAmount_GJB, T_Principal_END, T_UDI_END, T_RPPD_END, T_FaceAmount_END, T_CURRENT, T_1_30, T_31_60, T_61_90, T_91_120, T_Over120, T_PassDue, "", "", "", 0, 0)
                        DT_WithTotal.Rows.Add()
                    End If
                Else
                    DT_WithTotal.Rows.Add("SUB-TOTAL", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "", 0.0, 0.0, 0.0, 0.0, "", "", 0, "", 0.0, 0.0, 0, 0, 0, 0, T_Principal_BEG, T_UDI_BEG, T_RPPD_BEG, T_FaceAmount_BEG, T_Principal_CRB, T_UDI_CRB, T_RPPD_CRB, T_FaceAmount_CRB, T_Principal_CDB, T_UDI_CDB, T_RPPD_CDB, T_FaceAmount_CDB, T_Principal_GJB, T_UDI_GJB, T_RPPD_GJB, T_FaceAmount_GJB, T_Principal_END, T_UDI_END, T_RPPD_END, T_FaceAmount_END, T_CURRENT, T_1_30, T_31_60, T_61_90, T_91_120, T_Over120, T_PassDue, "", "", "", 0, 0)
                    DT_WithTotal.Rows.Add()

                    T_Principal_BEG = DT(x)("Beg_Principal")
                    T_UDI_BEG = DT(x)("Beg_UDI")
                    T_RPPD_BEG = DT(x)("Beg_RPPD")
                    T_FaceAmount_BEG = DT(x)("Beg_Face Amount")
                    T_Principal_CRB = DT(x)("CRB_Principal")
                    T_UDI_CRB = DT(x)("CRB_UDI")
                    T_RPPD_CRB = DT(x)("CRB_RPPD")
                    T_FaceAmount_CRB = DT(x)("CRB_Face Amount")
                    T_Principal_CDB = DT(x)("CDB_Principal")
                    T_UDI_CDB = DT(x)("CDB_UDI")
                    T_RPPD_CDB = DT(x)("CDB_RPPD")
                    T_FaceAmount_CDB = DT(x)("CDB_Face Amount")
                    T_Principal_GJB = DT(x)("GJB_Principal")
                    T_UDI_GJB = DT(x)("GJB_UDI")
                    T_RPPD_GJB = DT(x)("GJB_RPPD")
                    T_FaceAmount_GJB = DT(x)("GJB_Face Amount")
                    T_Principal_END = DT(x)("END_Principal")
                    T_UDI_END = DT(x)("END_UDI")
                    T_RPPD_END = DT(x)("END_RPPD")
                    T_FaceAmount_END = DT(x)("END_Face Amount")
                    T_CURRENT = DT(x)("CURRENT")
                    T_1_30 = DT(x)("1-30 Days")
                    T_31_60 = DT(x)("31-60 Days")
                    T_61_90 = DT(x)("61-90 Days")
                    T_91_120 = DT(x)("91-120 Days")
                    T_Over120 = DT(x)("Over 120 Days")
                    T_PassDue = DT(x)("Total Past Due")
                End If
                If x = DT.Rows.Count - 1 Then
                Else
                    DT_WithTotal.Rows.Add(DT(x)("Product"), DT(x)("CreditNumber"), DT(x)("Product Type"), DT(x)("Product Code"), DT(x)("Account No."), DT(x)("Borrowers Name"), DT(x)("CI"), DT(x)("AO"), DT(x)("Address"), DT(x)("Area"), DT(x)("Contact Number"), DT(x)("Collateral Description"), DT(x)("Date Granted"), DT(x)("Type"), DT(x)("Monthly Due Date"), DT(x)("Term"), DT(x)("Monthly Interest Rate"), DT(x)("Principal"), DT(x)("UDI"), DT(x)("RPPD"), DT(x)("Face Amount"), DT(x)("Plate Number"), DT(x)("Mode of Payment"), DT(x)("Term in Days"), DT(x)("Maturity Date"), DT(x)("Net Monthly Amortization"), DT(x)("Gross Monthly Amortization"), DT(x)("Months Lapsed"), DT(x)("Days Lapsed"), DT(x)("Remaining Months"), DT(x)("Remaining Months in Days"), DT(x)("Beg_Principal"), DT(x)("Beg_UDI"), DT(x)("Beg_RPPD"), DT(x)("Beg_Face Amount"), DT(x)("CRB_Principal"), DT(x)("CRB_UDI"), DT(x)("CRB_RPPD"), DT(x)("CRB_Face Amount"), DT(x)("CDB_Principal"), DT(x)("CDB_UDI"), DT(x)("CDB_RPPD"), DT(x)("CDB_Face Amount"), DT(x)("GJB_Principal"), DT(x)("GJB_UDI"), DT(x)("GJB_RPPD"), DT(x)("GJB_Face Amount"), DT(x)("END_Principal"), DT(x)("END_UDI"), DT(x)("END_RPPD"), DT(x)("END_Face Amount"), DT(x)("CURRENT"), DT(x)("1-30 Days"), DT(x)("31-60 Days"), DT(x)("61-90 Days"), DT(x)("91-120 Days"), DT(x)("Over 120 Days"), DT(x)("Total Past Due"), DT(x)("Last Payment Date"), DT(x)("Remedy Applied"), DT(x)("Remarks"), DT(x)("RemedyAppliedID"), DT(x)("Monthly"))
                End If
            End If

            OT_Principal_BEG += DT(x)("Beg_Principal")
            OT_UDI_BEG += DT(x)("Beg_UDI")
            OT_RPPD_BEG += DT(x)("Beg_RPPD")
            OT_FaceAmount_BEG += DT(x)("Beg_Face Amount")
            OT_Principal_CRB += DT(x)("CRB_Principal")
            OT_UDI_CRB += DT(x)("CRB_UDI")
            OT_RPPD_CRB += DT(x)("CRB_RPPD")
            OT_FaceAmount_CRB += DT(x)("CRB_Face Amount")
            OT_Principal_CDB += DT(x)("CDB_Principal")
            OT_UDI_CDB += DT(x)("CDB_UDI")
            OT_RPPD_CDB += DT(x)("CDB_RPPD")
            OT_FaceAmount_CDB += DT(x)("CDB_Face Amount")
            OT_Principal_GJB += DT(x)("GJB_Principal")
            OT_UDI_GJB += DT(x)("GJB_UDI")
            OT_RPPD_GJB += DT(x)("GJB_RPPD")
            OT_FaceAmount_GJB += DT(x)("GJB_Face Amount")
            OT_Principal_END += DT(x)("END_Principal")
            OT_UDI_END += DT(x)("END_UDI")
            OT_RPPD_END += DT(x)("END_RPPD")
            OT_FaceAmount_END += DT(x)("END_Face Amount")
            OT_CURRENT += DT(x)("CURRENT")
            OT_1_30 += DT(x)("1-30 Days")
            OT_31_60 += DT(x)("31-60 Days")
            OT_61_90 += DT(x)("61-90 Days")
            OT_91_120 += DT(x)("91-120 Days")
            OT_Over120 += DT(x)("Over 120 Days")
            OT_PassDue += DT(x)("Total Past Due")
        Next
        DT_WithTotal.Rows.Add("TOTAL", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 0, "", 0.0, 0.0, 0.0, 0.0, "", "", 0, "", 0.0, 0.0, 0, 0, 0, 0, OT_Principal_BEG, OT_UDI_BEG, OT_RPPD_BEG, OT_FaceAmount_BEG, OT_Principal_CRB, OT_UDI_CRB, OT_RPPD_CRB, OT_FaceAmount_CRB, OT_Principal_CDB, OT_UDI_CDB, OT_RPPD_CDB, OT_FaceAmount_CDB, OT_Principal_GJB, OT_UDI_GJB, OT_RPPD_GJB, OT_FaceAmount_GJB, OT_Principal_END, OT_UDI_END, OT_RPPD_END, OT_FaceAmount_END, OT_CURRENT, OT_1_30, OT_31_60, OT_61_90, OT_91_120, OT_Over120, OT_PassDue, "", "", "", 0, 0)

        GridControl1.DataSource = DT_WithTotal
        GridControl5.DataSource = DT
        Dim DT_ColumnSettings As DataTable = DataSource(String.Format("SELECT * FROM column_settings WHERE UserID = '{0}' AND FormID = '{1}' AND `status` = 'ACTIVE';", User_ID, Tag))
        If DT_ColumnSettings.Rows.Count > 0 Then
            GridControl1.Tag = 1
            GridColumn1.VisibleIndex = DT_ColumnSettings(0)("Column1V")
            GridColumn2.VisibleIndex = DT_ColumnSettings(0)("Column2V")
            GridColumn3.VisibleIndex = DT_ColumnSettings(0)("Column3V")
            GridColumn4.VisibleIndex = DT_ColumnSettings(0)("Column4V")
            GridColumn5.VisibleIndex = DT_ColumnSettings(0)("Column5V")
            GridColumn6.VisibleIndex = DT_ColumnSettings(0)("Column6V")
            GridColumn7.VisibleIndex = DT_ColumnSettings(0)("Column7V")
            GridColumn8.VisibleIndex = DT_ColumnSettings(0)("Column8V")
            GridColumn9.VisibleIndex = DT_ColumnSettings(0)("Column9V")
            GridColumn10.VisibleIndex = DT_ColumnSettings(0)("Column10V")
            GridColumn11.VisibleIndex = DT_ColumnSettings(0)("Column11V")
            GridColumn12.VisibleIndex = DT_ColumnSettings(0)("Column12V")
            GridColumn13.VisibleIndex = DT_ColumnSettings(0)("Column13V")
            GridColumn14.VisibleIndex = DT_ColumnSettings(0)("Column14V")
            GridColumn15.VisibleIndex = DT_ColumnSettings(0)("Column15V")
            GridColumn16.VisibleIndex = DT_ColumnSettings(0)("Column16V")
            GridColumn17.VisibleIndex = DT_ColumnSettings(0)("Column17V")
            GridColumn18.VisibleIndex = DT_ColumnSettings(0)("Column18V")
            GridColumn19.VisibleIndex = DT_ColumnSettings(0)("Column19V")
            GridColumn20.VisibleIndex = DT_ColumnSettings(0)("Column20V")
            GridColumn21.VisibleIndex = DT_ColumnSettings(0)("Column21V")
            GridColumn22.VisibleIndex = DT_ColumnSettings(0)("Column22V")
            GridColumn23.VisibleIndex = DT_ColumnSettings(0)("Column23V")
            GridColumn24.VisibleIndex = DT_ColumnSettings(0)("Column24V")
            GridColumn25.VisibleIndex = DT_ColumnSettings(0)("Column25V")
            GridColumn26.VisibleIndex = DT_ColumnSettings(0)("Column26V")
            GridColumn27.VisibleIndex = DT_ColumnSettings(0)("Column27V")
            GridColumn28.VisibleIndex = DT_ColumnSettings(0)("Column28V")
            GridColumn29.VisibleIndex = DT_ColumnSettings(0)("Column29V")
            GridColumn30.VisibleIndex = DT_ColumnSettings(0)("Column30V")
            GridColumn31.VisibleIndex = DT_ColumnSettings(0)("Column31V")
            GridColumn32.VisibleIndex = DT_ColumnSettings(0)("Column32V")
            GridColumn33.VisibleIndex = DT_ColumnSettings(0)("Column33V")

            GridColumn1.Width = DT_ColumnSettings(0)("Column1W")
            GridColumn2.Width = DT_ColumnSettings(0)("Column2W")
            GridColumn3.Width = DT_ColumnSettings(0)("Column3W")
            GridColumn4.Width = DT_ColumnSettings(0)("Column4W")
            GridColumn5.Width = DT_ColumnSettings(0)("Column5W")
            GridColumn6.Width = DT_ColumnSettings(0)("Column6W")
            GridColumn7.Width = DT_ColumnSettings(0)("Column7W")
            GridColumn8.Width = DT_ColumnSettings(0)("Column8W")
            GridColumn9.Width = DT_ColumnSettings(0)("Column9W")
            GridColumn10.Width = DT_ColumnSettings(0)("Column10W")
            GridColumn11.Width = DT_ColumnSettings(0)("Column11W")
            GridColumn12.Width = DT_ColumnSettings(0)("Column12W")
            GridColumn13.Width = DT_ColumnSettings(0)("Column13W")
            GridColumn14.Width = DT_ColumnSettings(0)("Column14W")
            GridColumn15.Width = DT_ColumnSettings(0)("Column15W")
            GridColumn16.Width = DT_ColumnSettings(0)("Column16W")
            GridColumn17.Width = DT_ColumnSettings(0)("Column17W")
            GridColumn18.Width = DT_ColumnSettings(0)("Column18W")
            GridColumn19.Width = DT_ColumnSettings(0)("Column19W")
            GridColumn20.Width = DT_ColumnSettings(0)("Column20W")
            GridColumn21.Width = DT_ColumnSettings(0)("Column21W")
            GridColumn22.Width = DT_ColumnSettings(0)("Column22W")
            GridColumn23.Width = DT_ColumnSettings(0)("Column23W")
            GridColumn24.Width = DT_ColumnSettings(0)("Column24W")
            GridColumn25.Width = DT_ColumnSettings(0)("Column25W")
            GridColumn26.Width = DT_ColumnSettings(0)("Column26W")
            GridColumn27.Width = DT_ColumnSettings(0)("Column27W")
            GridColumn28.Width = DT_ColumnSettings(0)("Column28W")
            GridColumn29.Width = DT_ColumnSettings(0)("Column29W")
            GridColumn30.Width = DT_ColumnSettings(0)("Column30W")
            GridColumn31.Width = DT_ColumnSettings(0)("Column31W")
            GridColumn32.Width = DT_ColumnSettings(0)("Column32W")
            GridColumn33.Width = DT_ColumnSettings(0)("Column33W")
        Else
            GridView4.BestFitColumns()
            GridControl1.Tag = 0
        End If
        'BandedGridView1.ClearColumnsFilter()
        Load_Topsheet()
        Load_TopsheetProcedure()
        Cursor = Cursors.Default
    End Sub

    Public Sub LoadAmortizationBasic(CreditNumber As String, Grid As DevExpress.XtraGrid.GridControl)
        Dim Temp_DT As DataTable = DataSource(String.Format("SELECT IFNULL(DATE_FORMAT(DueDate,'%m.%d.%Y'),'') AS 'Due Date', IF(`No` = '','',FORMAT(Monthly,2)) AS 'Monthly', FORMAT(LoansReceivable,2) AS 'Loans Receivable' FROM credit_schedule WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", CreditNumber))
        If Temp_DT.Rows.Count > 0 Then
            Dim T_Monthly As Double
            For x As Integer = 1 To Temp_DT.Rows.Count - 1
                T_Monthly += CDbl(Temp_DT(x)("Monthly"))
            Next
            Temp_DT.Rows.Add("TOTAL", FormatNumber(T_Monthly, 2), 0)
            Grid.DataSource = Temp_DT
        End If
    End Sub

    Private Sub GridView_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles BandedGridView1.SelectionChanged
        Dim Rows As New ArrayList()
        Dim selectedRowHandles As Integer() = BandedGridView1.GetSelectedRows()
        If selectedRowHandles.Length > 1 Then
            Dim Total_1 As Double
            Dim Total_2 As Double
            Dim Total_3 As Double
            Dim Total_4 As Double
            Dim Total_5 As Double
            Dim Total_6 As Double
            Dim Total_7 As Double
            Dim Total_8 As Double
            Dim Total_9 As Double
            Dim Total_10 As Double
            Dim Total_11 As Double
            Dim Total_12 As Double
            Dim Total_13 As Double
            Dim Total_14 As Double
            Dim Total_15 As Double
            Dim Total_16 As Double
            Dim Total_17 As Double
            Dim Total_18 As Double
            Dim Total_19 As Double
            Dim Total_20 As Double
            Dim Total_21 As Double
            Dim Total_22 As Double
            Dim Total_23 As Double
            Dim Total_24 As Double
            Dim Total_25 As Double
            Dim Total_26 As Double
            Dim Total_27 As Double
            Dim Total_28 As Double
            Dim Total_29 As Double
            Dim Total_30 As Double
            Dim Total_31 As Double
            Dim Total_32 As Double
            Dim Total_33 As Double
            With BandedGridView1
                For x As Integer = 0 To selectedRowHandles.Length - 1
                    Dim selectedRowHandle As Integer = selectedRowHandles(x)
                    Total_1 += .GetRowCellValue(selectedRowHandle, "Principal")
                    Total_2 += .GetRowCellValue(selectedRowHandle, "UDI")
                    Total_3 += .GetRowCellValue(selectedRowHandle, "RPPD")
                    Total_4 += .GetRowCellValue(selectedRowHandle, "Face Amount")
                    Total_5 += .GetRowCellValue(selectedRowHandle, "Net Monthly Amortization")
                    Total_6 += .GetRowCellValue(selectedRowHandle, "Gross Monthly Amortization")
                    Total_7 += .GetRowCellValue(selectedRowHandle, "Beg_Principal")
                    Total_8 += .GetRowCellValue(selectedRowHandle, "Beg_UDI")
                    Total_9 += .GetRowCellValue(selectedRowHandle, "Beg_RPPD")
                    Total_10 += .GetRowCellValue(selectedRowHandle, "Beg_Face Amount")
                    Total_11 += .GetRowCellValue(selectedRowHandle, "CRB_Principal")
                    Total_12 += .GetRowCellValue(selectedRowHandle, "CRB_UDI")
                    Total_13 += .GetRowCellValue(selectedRowHandle, "CRB_RPPD")
                    Total_14 += .GetRowCellValue(selectedRowHandle, "CRB_Face Amount")
                    Total_15 += .GetRowCellValue(selectedRowHandle, "CDB_Principal")
                    Total_16 += .GetRowCellValue(selectedRowHandle, "CDB_UDI")
                    Total_17 += .GetRowCellValue(selectedRowHandle, "CDB_RPPD")
                    Total_18 += .GetRowCellValue(selectedRowHandle, "CDB_Face Amount")
                    Total_19 += .GetRowCellValue(selectedRowHandle, "GJB_Principal")
                    Total_20 += .GetRowCellValue(selectedRowHandle, "GJB_UDI")
                    Total_21 += .GetRowCellValue(selectedRowHandle, "GJB_RPPD")
                    Total_22 += .GetRowCellValue(selectedRowHandle, "GJB_Face Amount")
                    Total_23 += .GetRowCellValue(selectedRowHandle, "END_Principal")
                    Total_24 += .GetRowCellValue(selectedRowHandle, "END_UDI")
                    Total_25 += .GetRowCellValue(selectedRowHandle, "END_RPPD")
                    Total_26 += .GetRowCellValue(selectedRowHandle, "END_Face Amount")
                    Total_27 += .GetRowCellValue(selectedRowHandle, "CURRENT")
                    Total_28 += .GetRowCellValue(selectedRowHandle, "1-30 Days")
                    Total_29 += .GetRowCellValue(selectedRowHandle, "31-60 Days")
                    Total_30 += .GetRowCellValue(selectedRowHandle, "61-90 Days")
                    Total_31 += .GetRowCellValue(selectedRowHandle, "91-120 Days")
                    Total_32 += .GetRowCellValue(selectedRowHandle, "Over 120 Days")
                    Total_33 += .GetRowCellValue(selectedRowHandle, "Total Past Due")
                Next
                .Columns("Principal").SummaryItem.DisplayFormat = FormatNumber(Total_1, 2)
                .Columns("UDI").SummaryItem.DisplayFormat = FormatNumber(Total_2, 2)
                .Columns("RPPD").SummaryItem.DisplayFormat = FormatNumber(Total_3, 2)
                .Columns("Face Amount").SummaryItem.DisplayFormat = FormatNumber(Total_4, 2)
                .Columns("Net Monthly Amortization").SummaryItem.DisplayFormat = FormatNumber(Total_5, 2)
                .Columns("Gross Monthly Amortization").SummaryItem.DisplayFormat = FormatNumber(Total_6, 2)
                .Columns("Beg_Principal").SummaryItem.DisplayFormat = FormatNumber(Total_7, 2)
                .Columns("Beg_UDI").SummaryItem.DisplayFormat = FormatNumber(Total_8, 2)
                .Columns("Beg_RPPD").SummaryItem.DisplayFormat = FormatNumber(Total_9, 2)
                .Columns("Beg_Face Amount").SummaryItem.DisplayFormat = FormatNumber(Total_10, 2)
                .Columns("CRB_Principal").SummaryItem.DisplayFormat = FormatNumber(Total_11, 2)
                .Columns("CRB_UDI").SummaryItem.DisplayFormat = FormatNumber(Total_12, 2)
                .Columns("CRB_RPPD").SummaryItem.DisplayFormat = FormatNumber(Total_13, 2)
                .Columns("CRB_Face Amount").SummaryItem.DisplayFormat = FormatNumber(Total_14, 2)
                .Columns("CDB_Principal").SummaryItem.DisplayFormat = FormatNumber(Total_15, 2)
                .Columns("CDB_UDI").SummaryItem.DisplayFormat = FormatNumber(Total_16, 2)
                .Columns("CDB_RPPD").SummaryItem.DisplayFormat = FormatNumber(Total_17, 2)
                .Columns("CDB_Face Amount").SummaryItem.DisplayFormat = FormatNumber(Total_18, 2)
                .Columns("GJB_Principal").SummaryItem.DisplayFormat = FormatNumber(Total_19, 2)
                .Columns("GJB_UDI").SummaryItem.DisplayFormat = FormatNumber(Total_20, 2)
                .Columns("GJB_RPPD").SummaryItem.DisplayFormat = FormatNumber(Total_21, 2)
                .Columns("GJB_Face Amount").SummaryItem.DisplayFormat = FormatNumber(Total_22, 2)
                .Columns("END_Principal").SummaryItem.DisplayFormat = FormatNumber(Total_23, 2)
                .Columns("END_UDI").SummaryItem.DisplayFormat = FormatNumber(Total_24, 2)
                .Columns("END_RPPD").SummaryItem.DisplayFormat = FormatNumber(Total_25, 2)
                .Columns("END_Face Amount").SummaryItem.DisplayFormat = FormatNumber(Total_26, 2)
                .Columns("CURRENT").SummaryItem.DisplayFormat = FormatNumber(Total_27, 2)
                .Columns("1-30 Days").SummaryItem.DisplayFormat = FormatNumber(Total_28, 2)
                .Columns("31-60 Days").SummaryItem.DisplayFormat = FormatNumber(Total_29, 2)
                .Columns("61-90 Days").SummaryItem.DisplayFormat = FormatNumber(Total_30, 2)
                .Columns("91-120 Days").SummaryItem.DisplayFormat = FormatNumber(Total_31, 2)
                .Columns("Over 120 Days").SummaryItem.DisplayFormat = FormatNumber(Total_32, 2)
                .Columns("Total Past Due").SummaryItem.DisplayFormat = FormatNumber(Total_33, 2)
            End With
        Else
            With BandedGridView1
                .Columns("Principal").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("UDI").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("RPPD").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Face Amount").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Net Monthly Amortization").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Gross Monthly Amortization").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Beg_Principal").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Beg_UDI").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Beg_RPPD").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Beg_Face Amount").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("CRB_Principal").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("CRB_UDI").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("CRB_RPPD").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("CRB_Face Amount").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("CDB_Principal").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("CDB_UDI").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("CDB_RPPD").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("CDB_Face Amount").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("GJB_Principal").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("GJB_UDI").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("GJB_RPPD").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("GJB_Face Amount").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("END_Principal").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("END_UDI").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("END_RPPD").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("END_Face Amount").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("CURRENT").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("1-30 Days").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("31-60 Days").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("61-90 Days").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("91-120 Days").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Over 120 Days").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Total Past Due").SummaryItem.DisplayFormat = "{0:n2}"
            End With
        End If
    End Sub

    '***BUTTON CLICK
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
        Dim TopSheet As New RptAgingTopsheet
        With TopSheet
            .Name = String.Format("Aging of {0} - Per Product As of {1}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text), dtpAsOf.Text)
            .lblBranch.Text = If(cbxAllB.Checked, "ALL BRANCHES", cbxBranch.Text)
            .lblAsOf.Text = "As of " & dtpAsOf.Text
            .DataSource = GridControl2.DataSource
            Dim groupField As New GroupField("Product")
            .GroupHeader1.GroupFields.Add(groupField)
            .lblProduct.DataBindings.Add("Text", GridControl2.DataSource, "Product")
            .lblSub.DataBindings.Add("Text", GridControl2.DataSource, "Sub-Categories")
            .lblCode.DataBindings.Add("Text", GridControl2.DataSource, "Code")
            .lblOutstanding.DataBindings.Add("Text", GridControl2.DataSource, "Outstanding Balance")
            .lblCurrent.DataBindings.Add("Text", GridControl2.DataSource, "Current")
            .lbl1_30.DataBindings.Add("Text", GridControl2.DataSource, "1-30 Days")
            .lbl31_60.DataBindings.Add("Text", GridControl2.DataSource, "31-60 Days")
            .lbl61_90.DataBindings.Add("Text", GridControl2.DataSource, "61-90 Days")
            .lbl91_120.DataBindings.Add("Text", GridControl2.DataSource, "91-120 Days")
            .lblOver120.DataBindings.Add("Text", GridControl2.DataSource, "Over 120 Days")

            .lblOutstandingT1.DataBindings.Add("Text", GridControl2.DataSource, "Outstanding Balance")
            .lblCurrentT1.DataBindings.Add("Text", GridControl2.DataSource, "Current")
            .lbl1_30T1.DataBindings.Add("Text", GridControl2.DataSource, "1-30 Days")
            .lbl31_60T1.DataBindings.Add("Text", GridControl2.DataSource, "31-60 Days")
            .lbl61_90T1.DataBindings.Add("Text", GridControl2.DataSource, "61-90 Days")
            .lbl91_120T1.DataBindings.Add("Text", GridControl2.DataSource, "91-120 Days")
            .lblOver120T1.DataBindings.Add("Text", GridControl2.DataSource, "Over 120 Days")

            .lblOutstandingT2.DataBindings.Add("Text", GridControl2.DataSource, "Outstanding Balance")
            .lblCurrentT2.DataBindings.Add("Text", GridControl2.DataSource, "Current")
            .lbl1_30T2.DataBindings.Add("Text", GridControl2.DataSource, "1-30 Days")
            .lbl31_60T2.DataBindings.Add("Text", GridControl2.DataSource, "31-60 Days")
            .lbl61_90T2.DataBindings.Add("Text", GridControl2.DataSource, "61-90 Days")
            .lbl91_120T2.DataBindings.Add("Text", GridControl2.DataSource, "91-120 Days")
            .lblOver120T2.DataBindings.Add("Text", GridControl2.DataSource, "Over 120 Days")

            'PERCENTAGE ********************************************************************************************************************
            Dim CurrentP As New CalculatedField()
            .CalculatedFields.Add(CurrentP)
            With CurrentP
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "CurrentP"
                .Expression = "([Current] / [Outstanding Balance])"
            End With
            .lblCurrentP.DataBindings.Add("Text", Nothing, "CurrentP")

            Dim CurrentP1 As New CalculatedField()
            .CalculatedFields.Add(CurrentP1)
            With CurrentP1
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "CurrentP1"
                .Expression = "([][[Product] == [^.Product]].SUM([Current]) / [][[Product] == [^.Product]].SUM([Outstanding Balance]))"
            End With
            .lblCurrentPT1.DataBindings.Add("Text", Nothing, "CurrentP1")

            Dim CurrentP2 As New CalculatedField()
            .CalculatedFields.Add(CurrentP2)
            With CurrentP2
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "CurrentP2"
                .Expression = "(SUM([Current]) / SUM([Outstanding Balance]))"
            End With
            .lblCurrentPT2.DataBindings.Add("Text", Nothing, "CurrentP2")

            Dim V1_30P As New CalculatedField()
            .CalculatedFields.Add(V1_30P)
            With V1_30P
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "V1_30P"
                .Expression = "([1-30 Days] / [Outstanding Balance])"
            End With
            .lbl1_30P.DataBindings.Add("Text", Nothing, "V1_30P")

            Dim V1_30P1 As New CalculatedField()
            .CalculatedFields.Add(V1_30P1)
            With V1_30P1
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "V1_30P1"
                .Expression = "([][[Product] == [^.Product]].SUM([1-30 Days]) / [][[Product] == [^.Product]].SUM([Outstanding Balance]))"
            End With
            .lbl1_30PT1.DataBindings.Add("Text", Nothing, "V1_30P1")

            Dim V1_30P2 As New CalculatedField()
            .CalculatedFields.Add(V1_30P2)
            With V1_30P2
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "V1_30P2"
                .Expression = "(SUM([1-30 Days]) / SUM([Outstanding Balance]))"
            End With
            .lbl1_30PT2.DataBindings.Add("Text", Nothing, "V1_30P2")

            Dim V31_60P As New CalculatedField()
            .CalculatedFields.Add(V31_60P)
            With V31_60P
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "V31_60P"
                .Expression = "([31-60 Days] / [Outstanding Balance])"
            End With
            .lbl31_60P.DataBindings.Add("Text", Nothing, "V31_60P")

            Dim V31_60P1 As New CalculatedField()
            .CalculatedFields.Add(V31_60P1)
            With V31_60P1
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "V31_60P1"
                .Expression = "([][[Product] == [^.Product]].SUM([31-60 Days]) / [][[Product] == [^.Product]].SUM([Outstanding Balance]))"
            End With
            .lbl31_60PT1.DataBindings.Add("Text", Nothing, "V31_60P1")

            Dim V31_60P2 As New CalculatedField()
            .CalculatedFields.Add(V31_60P2)
            With V31_60P2
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "V31_60P2"
                .Expression = "(SUM([31-60 Days]) / SUM([Outstanding Balance]))"
            End With
            .lbl31_60PT2.DataBindings.Add("Text", Nothing, "V31_60P2")

            Dim V61_90P As New CalculatedField()
            .CalculatedFields.Add(V61_90P)
            With V61_90P
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "V61_90P"
                .Expression = "([61-90 Days] / [Outstanding Balance])"
            End With
            .lbl61_90P.DataBindings.Add("Text", Nothing, "V61_90P")

            Dim V61_90P1 As New CalculatedField()
            .CalculatedFields.Add(V61_90P1)
            With V61_90P1
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "V61_90P1"
                .Expression = "([][[Product] == [^.Product]].SUM([61-90 Days]) / [][[Product] == [^.Product]].SUM([Outstanding Balance]))"
            End With
            .lbl61_90PT1.DataBindings.Add("Text", Nothing, "V61_90P1")

            Dim V61_90P2 As New CalculatedField()
            .CalculatedFields.Add(V61_90P2)
            With V61_90P2
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "V61_90P2"
                .Expression = "(SUM([61-90 Days]) / SUM([Outstanding Balance]))"
            End With
            .lbl61_90PT2.DataBindings.Add("Text", Nothing, "V61_90P2")

            Dim V91_120P As New CalculatedField()
            .CalculatedFields.Add(V91_120P)
            With V91_120P
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "V91_120P"
                .Expression = "([91-120 Days] / [Outstanding Balance])"
            End With
            .lbl91_120P.DataBindings.Add("Text", Nothing, "V91_120P")

            Dim V91_120P1 As New CalculatedField()
            .CalculatedFields.Add(V91_120P1)
            With V91_120P1
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "V91_120P1"
                .Expression = "([][[Product] == [^.Product]].SUM([91-120 Days]) / [][[Product] == [^.Product]].SUM([Outstanding Balance]))"
            End With
            .lbl91_120PT1.DataBindings.Add("Text", Nothing, "V91_120P1")

            Dim V91_120P2 As New CalculatedField()
            .CalculatedFields.Add(V91_120P2)
            With V91_120P2
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "V91_120P2"
                .Expression = "(SUM([91-120 Days]) / SUM([Outstanding Balance]))"
            End With
            .lbl91_120PT2.DataBindings.Add("Text", Nothing, "V91_120P2")

            Dim VOver120P As New CalculatedField()
            .CalculatedFields.Add(VOver120P)
            With VOver120P
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "VOver120P"
                .Expression = "([Over 120 Days] / [Outstanding Balance])"
            End With
            .lblOver120P.DataBindings.Add("Text", Nothing, "VOver120P")

            Dim VOver120P1 As New CalculatedField()
            .CalculatedFields.Add(VOver120P1)
            With VOver120P1
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "VOver120P1"
                .Expression = "([][[Product] == [^.Product]].SUM([Over 120 Days]) / [][[Product] == [^.Product]].SUM([Outstanding Balance]))"
            End With
            .lblOver120PT1.DataBindings.Add("Text", Nothing, "VOver120P1")

            Dim VOver120P2 As New CalculatedField()
            .CalculatedFields.Add(VOver120P2)
            With VOver120P2
                .DataSource = TopSheet.DataSource
                .DataMember = TopSheet.DataMember
                .FieldType = FieldType.Double
                .Name = "VOver120P2"
                .Expression = "(SUM([Over 120 Days]) / SUM([Outstanding Balance]))"
            End With
            .lblOver120PT2.DataBindings.Add("Text", Nothing, "VOver120P2")
            If cbxMerge.Checked Then
                .CreateDocument()
            Else
                .ShowPreview()
            End If
        End With

        Dim TopSheetPerProcedure As New RptAgingTopSheetPerProcedure
        With TopSheetPerProcedure
            .Name = String.Format("Aging of {0} - Per Collection Procedure As of {1}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text), dtpAsOf.Text)
            .lblBranch.Text = If(cbxAllB.Checked, "ALL BRANCHES", cbxBranch.Text)
            .lblAsOf.Text = "As of " & dtpAsOf.Text
            .DataSource = GridControl3.DataSource
            .lblCollectionProcedure.DataBindings.Add("Text", GridControl3.DataSource, "Collection Procedure")
            .lblCode.DataBindings.Add("Text", GridControl3.DataSource, "Code")
            .lblOutstanding.DataBindings.Add("Text", GridControl3.DataSource, "Outstanding Balance")
            .lblCurrent.DataBindings.Add("Text", GridControl3.DataSource, "Current")
            .lbl1_30.DataBindings.Add("Text", GridControl3.DataSource, "1-30 Days")
            .lbl31_60.DataBindings.Add("Text", GridControl3.DataSource, "31-60 Days")
            .lbl61_90.DataBindings.Add("Text", GridControl3.DataSource, "61-90 Days")
            .lbl91_120.DataBindings.Add("Text", GridControl3.DataSource, "91-120 Days")
            .lblOver120.DataBindings.Add("Text", GridControl3.DataSource, "Over 120 Days")

            .lblOutstandingT2.DataBindings.Add("Text", GridControl3.DataSource, "Outstanding Balance")
            .lblCurrentT2.DataBindings.Add("Text", GridControl3.DataSource, "Current")
            .lbl1_30T2.DataBindings.Add("Text", GridControl3.DataSource, "1-30 Days")
            .lbl31_60T2.DataBindings.Add("Text", GridControl3.DataSource, "31-60 Days")
            .lbl61_90T2.DataBindings.Add("Text", GridControl3.DataSource, "61-90 Days")
            .lbl91_120T2.DataBindings.Add("Text", GridControl3.DataSource, "91-120 Days")
            .lblOver120T2.DataBindings.Add("Text", GridControl3.DataSource, "Over 120 Days")

            'PERCENTAGE ********************************************************************************************************************
            Dim CurrentP As New CalculatedField()
            .CalculatedFields.Add(CurrentP)
            With CurrentP
                .DataSource = TopSheetPerProcedure.DataSource
                .DataMember = TopSheetPerProcedure.DataMember
                .FieldType = FieldType.Double
                .Name = "CurrentP"
                .Expression = "([Current] / [Outstanding Balance])"
            End With
            .lblCurrentP.DataBindings.Add("Text", Nothing, "CurrentP")

            Dim CurrentP2 As New CalculatedField()
            .CalculatedFields.Add(CurrentP2)
            With CurrentP2
                .DataSource = TopSheetPerProcedure.DataSource
                .DataMember = TopSheetPerProcedure.DataMember
                .FieldType = FieldType.Double
                .Name = "CurrentP2"
                .Expression = "(SUM([Current]) / SUM([Outstanding Balance]))"
            End With
            .lblCurrentPT2.DataBindings.Add("Text", Nothing, "CurrentP2")

            Dim V1_30P As New CalculatedField()
            .CalculatedFields.Add(V1_30P)
            With V1_30P
                .DataSource = TopSheetPerProcedure.DataSource
                .DataMember = TopSheetPerProcedure.DataMember
                .FieldType = FieldType.Double
                .Name = "V1_30P"
                .Expression = "([1-30 Days] / [Outstanding Balance])"
            End With
            .lbl1_30P.DataBindings.Add("Text", Nothing, "V1_30P")

            Dim V1_30P2 As New CalculatedField()
            .CalculatedFields.Add(V1_30P2)
            With V1_30P2
                .DataSource = TopSheetPerProcedure.DataSource
                .DataMember = TopSheetPerProcedure.DataMember
                .FieldType = FieldType.Double
                .Name = "V1_30P2"
                .Expression = "(SUM([1-30 Days]) / SUM([Outstanding Balance]))"
            End With
            .lbl1_30PT2.DataBindings.Add("Text", Nothing, "V1_30P2")

            Dim V31_60P As New CalculatedField()
            .CalculatedFields.Add(V31_60P)
            With V31_60P
                .DataSource = TopSheetPerProcedure.DataSource
                .DataMember = TopSheetPerProcedure.DataMember
                .FieldType = FieldType.Double
                .Name = "V31_60P"
                .Expression = "([31-60 Days] / [Outstanding Balance])"
            End With
            .lbl31_60P.DataBindings.Add("Text", Nothing, "V31_60P")

            Dim V31_60P2 As New CalculatedField()
            .CalculatedFields.Add(V31_60P2)
            With V31_60P2
                .DataSource = TopSheetPerProcedure.DataSource
                .DataMember = TopSheetPerProcedure.DataMember
                .FieldType = FieldType.Double
                .Name = "V31_60P2"
                .Expression = "(SUM([31-60 Days]) / SUM([Outstanding Balance]))"
            End With
            .lbl31_60PT2.DataBindings.Add("Text", Nothing, "V31_60P2")

            Dim V61_90P As New CalculatedField()
            .CalculatedFields.Add(V61_90P)
            With V61_90P
                .DataSource = TopSheetPerProcedure.DataSource
                .DataMember = TopSheetPerProcedure.DataMember
                .FieldType = FieldType.Double
                .Name = "V61_90P"
                .Expression = "([61-90 Days] / [Outstanding Balance])"
            End With
            .lbl61_90P.DataBindings.Add("Text", Nothing, "V61_90P")

            Dim V61_90P2 As New CalculatedField()
            .CalculatedFields.Add(V61_90P2)
            With V61_90P2
                .DataSource = TopSheetPerProcedure.DataSource
                .DataMember = TopSheetPerProcedure.DataMember
                .FieldType = FieldType.Double
                .Name = "V61_90P2"
                .Expression = "(SUM([61-90 Days]) / SUM([Outstanding Balance]))"
            End With
            .lbl61_90PT2.DataBindings.Add("Text", Nothing, "V61_90P2")

            Dim V91_120P As New CalculatedField()
            .CalculatedFields.Add(V91_120P)
            With V91_120P
                .DataSource = TopSheetPerProcedure.DataSource
                .DataMember = TopSheetPerProcedure.DataMember
                .FieldType = FieldType.Double
                .Name = "V91_120P"
                .Expression = "([91-120 Days] / [Outstanding Balance])"
            End With
            .lbl91_120P.DataBindings.Add("Text", Nothing, "V91_120P")

            Dim V91_120P2 As New CalculatedField()
            .CalculatedFields.Add(V91_120P2)
            With V91_120P2
                .DataSource = TopSheetPerProcedure.DataSource
                .DataMember = TopSheetPerProcedure.DataMember
                .FieldType = FieldType.Double
                .Name = "V91_120P2"
                .Expression = "(SUM([91-120 Days]) / SUM([Outstanding Balance]))"
            End With
            .lbl91_120PT2.DataBindings.Add("Text", Nothing, "V91_120P2")

            Dim VOver120P As New CalculatedField()
            .CalculatedFields.Add(VOver120P)
            With VOver120P
                .DataSource = TopSheetPerProcedure.DataSource
                .DataMember = TopSheetPerProcedure.DataMember
                .FieldType = FieldType.Double
                .Name = "VOver120P"
                .Expression = "([Over 120 Days] / [Outstanding Balance])"
            End With
            .lblOver120P.DataBindings.Add("Text", Nothing, "VOver120P")

            Dim VOver120P2 As New CalculatedField()
            .CalculatedFields.Add(VOver120P2)
            With VOver120P2
                .DataSource = TopSheetPerProcedure.DataSource
                .DataMember = TopSheetPerProcedure.DataMember
                .FieldType = FieldType.Double
                .Name = "VOver120P2"
                .Expression = "(SUM([Over 120 Days]) / SUM([Outstanding Balance]))"
            End With
            .lblOver120PT2.DataBindings.Add("Text", Nothing, "VOver120P2")
            If cbxMerge.Checked Then
                .CreateDocument()
            Else
                .ShowPreview()
            End If
        End With

        Dim Report As New RptAgingNew
        With Report
            .Name = String.Format("Aging of {0} As of {1}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text), dtpAsOf.Text)
            .lblBranch.Text = If(cbxAllB.Checked, "ALL BRANCHES", cbxBranch.Text)
            .lblAsOf.Text = "As of " & dtpAsOf.Text
            .lblBEG_AsOf.Text = "AS OF " & dtpAsOf.Text.ToUpper
            .lblEND_AsOf.Text = "AS OF " & dtpAsOf.Text.ToUpper
            .DataSource = GridControl5.DataSource
            Dim groupField As New GroupField("Product")
            .GroupHeader1.GroupFields.Add(groupField)
            Dim groupField2 As New GroupField("Product Type")
            .GroupHeader2.GroupFields.Add(groupField2)

            .lblProductType.DataBindings.Add("Text", GridControl5.DataSource, "Product Type")
            .lblProductTypeT.DataBindings.Add("Text", GridControl5.DataSource, "Product Type", "TOTAL {0}")
            .lblProductTypeP.DataBindings.Add("Text", GridControl5.DataSource, "Product Type", "TOTAL {0} AGING PERCENTAGE")
            .lblProductTypeN.DataBindings.Add("Text", GridControl5.DataSource, "Product Type", "TOTAL NO. OF {0} ACCOUNTS")
            .lblProduct.DataBindings.Add("Text", GridControl5.DataSource, "Product")
            .lblProductCode.DataBindings.Add("Text", GridControl5.DataSource, "Product Code")
            .lblAccountNo.DataBindings.Add("Text", GridControl5.DataSource, "Account No.")
            .lblBorrower.DataBindings.Add("Text", GridControl5.DataSource, "Borrowers Name")
            .lblCI.DataBindings.Add("Text", GridControl5.DataSource, "CI")
            .lblAO.DataBindings.Add("Text", GridControl5.DataSource, "AO")
            .lblAddress.DataBindings.Add("Text", GridControl5.DataSource, "Address")
            .lblArea.DataBindings.Add("Text", GridControl5.DataSource, "Area")
            .lblContactNumber.DataBindings.Add("Text", GridControl5.DataSource, "Contact Number")
            .lblCollateral.DataBindings.Add("Text", GridControl5.DataSource, "Collateral Description")
            .lblDateGranted.DataBindings.Add("Text", GridControl5.DataSource, "Date Granted")
            .lblType.DataBindings.Add("Text", GridControl5.DataSource, "Type")
            .lblMonthlyDueDate.DataBindings.Add("Text", GridControl5.DataSource, "Monthly Due Date")
            .lblTerm.DataBindings.Add("Text", GridControl5.DataSource, "Term")
            .lblMonthlyInterestRate.DataBindings.Add("Text", GridControl5.DataSource, "Monthly Interest Rate")
            .lblPrincipal.DataBindings.Add("Text", GridControl5.DataSource, "Principal")
            .lblUDI.DataBindings.Add("Text", GridControl5.DataSource, "UDI")
            .lblRPPD.DataBindings.Add("Text", GridControl5.DataSource, "RPPD")
            .lblFaceAmount.DataBindings.Add("Text", GridControl5.DataSource, "Face Amount")
            .lblPlateNumber.DataBindings.Add("Text", GridControl5.DataSource, "Plate Number")
            .lblModeOfPayment.DataBindings.Add("Text", GridControl5.DataSource, "Mode of Payment")
            .lblTermInDays.DataBindings.Add("Text", GridControl5.DataSource, "Mode of Payment")
            .lblMaturityDate.DataBindings.Add("Text", GridControl5.DataSource, "Maturity Date")
            .lblNMA.DataBindings.Add("Text", GridControl5.DataSource, "Net Monthly Amortization")
            .lblGMA.DataBindings.Add("Text", GridControl5.DataSource, "Gross Monthly Amortization")
            .lblMonthsLapsed.DataBindings.Add("Text", GridControl5.DataSource, "Months Lapsed")
            .lblDaysLapsed.DataBindings.Add("Text", GridControl5.DataSource, "Days Lapsed")
            .lblRemainingMonths.DataBindings.Add("Text", GridControl5.DataSource, "Remaining Months")
            .lblRemainingDays.DataBindings.Add("Text", GridControl5.DataSource, "Remaining Months in Days")
            .lblBEG_Principal.DataBindings.Add("Text", GridControl5.DataSource, "Beg_Principal")
            .lblBEG_UDI.DataBindings.Add("Text", GridControl5.DataSource, "Beg_UDI")
            .lblBEG_RPPD.DataBindings.Add("Text", GridControl5.DataSource, "Beg_RPPD")
            .lblBEG_FA.DataBindings.Add("Text", GridControl5.DataSource, "Beg_Face Amount")
            .lblCRB_Principal.DataBindings.Add("Text", GridControl5.DataSource, "CRB_Principal")
            .lblCRB_UDI.DataBindings.Add("Text", GridControl5.DataSource, "CRB_UDI")
            .lblCRB_RPPD.DataBindings.Add("Text", GridControl5.DataSource, "CRB_RPPD")
            .lblCRB_FA.DataBindings.Add("Text", GridControl5.DataSource, "CRB_Face Amount")
            .lblCDB_Principal.DataBindings.Add("Text", GridControl5.DataSource, "CDB_Principal")
            .lblCDB_UDI.DataBindings.Add("Text", GridControl5.DataSource, "CDB_UDI")
            .lblCDB_RPPD.DataBindings.Add("Text", GridControl5.DataSource, "CDB_RPPD")
            .lblCDB_FA.DataBindings.Add("Text", GridControl5.DataSource, "CDB_Face Amount")
            .lblGJB_Principal.DataBindings.Add("Text", GridControl5.DataSource, "GJB_Principal")
            .lblGJB_UDI.DataBindings.Add("Text", GridControl5.DataSource, "GJB_UDI")
            .lblGJB_RPPD.DataBindings.Add("Text", GridControl5.DataSource, "GJB_RPPD")
            .lblGJB_FA.DataBindings.Add("Text", GridControl5.DataSource, "GJB_Face Amount")
            .lblEND_Principal.DataBindings.Add("Text", GridControl5.DataSource, "END_Principal")
            .lblEND_UDI.DataBindings.Add("Text", GridControl5.DataSource, "END_UDI")
            .lblEND_RPPD.DataBindings.Add("Text", GridControl5.DataSource, "END_RPPD")
            .lblEND_FA.DataBindings.Add("Text", GridControl5.DataSource, "END_Face Amount")
            .lblCurrent.DataBindings.Add("Text", GridControl5.DataSource, "CURRENT")
            .lbl1_30.DataBindings.Add("Text", GridControl5.DataSource, "1-30 Days")
            .lbl31_60.DataBindings.Add("Text", GridControl5.DataSource, "31-60 Days")
            .lbl61_90.DataBindings.Add("Text", GridControl5.DataSource, "61-90 Days")
            .lbl91_120.DataBindings.Add("Text", GridControl5.DataSource, "91-120 Days")
            .lblOver120.DataBindings.Add("Text", GridControl5.DataSource, "Over 120 Days")
            .lblTotalPastDue.DataBindings.Add("Text", GridControl5.DataSource, "Total Past Due")
            .lblLastPaymentDate.DataBindings.Add("Text", GridControl5.DataSource, "Last Payment Date")
            .lblRemedyApplied.DataBindings.Add("Text", GridControl5.DataSource, "Remedy Applied")
            .lblRemarks.DataBindings.Add("Text", GridControl5.DataSource, "Remarks")

            .lblCurrentP.DataBindings.Add("Text", GridControl5.DataSource, "CURRENT")
            .lbl1_30P.DataBindings.Add("Text", GridControl5.DataSource, "1-30 Days")
            .lbl31_60P.DataBindings.Add("Text", GridControl5.DataSource, "31-60 Days")
            .lbl61_90P.DataBindings.Add("Text", GridControl5.DataSource, "61-90 Days")
            .lbl91_120P.DataBindings.Add("Text", GridControl5.DataSource, "91-120 Days")
            .lblOver120P.DataBindings.Add("Text", GridControl5.DataSource, "Over 120 Days")
            .lblTotalPastDueP.DataBindings.Add("Text", GridControl5.DataSource, "Total Past Due")

            .lblBEG_PrincipalT.DataBindings.Add("Text", GridControl5.DataSource, "Beg_Principal")
            .lblBEG_UDIT.DataBindings.Add("Text", GridControl5.DataSource, "Beg_UDI")
            .lblBEG_RPPDT.DataBindings.Add("Text", GridControl5.DataSource, "Beg_RPPD")
            .lblBEG_FAT.DataBindings.Add("Text", GridControl5.DataSource, "Beg_Face Amount")
            .lblCRB_PrincipalT.DataBindings.Add("Text", GridControl5.DataSource, "CRB_Principal")
            .lblCRB_UDIT.DataBindings.Add("Text", GridControl5.DataSource, "CRB_UDI")
            .lblCRB_RPPDT.DataBindings.Add("Text", GridControl5.DataSource, "CRB_RPPD")
            .lblCRB_FAT.DataBindings.Add("Text", GridControl5.DataSource, "CRB_Face Amount")
            .lblCDB_PrincipalT.DataBindings.Add("Text", GridControl5.DataSource, "CDB_Principal")
            .lblCDB_UDIT.DataBindings.Add("Text", GridControl5.DataSource, "CDB_UDI")
            .lblCDB_RPPDT.DataBindings.Add("Text", GridControl5.DataSource, "CDB_RPPD")
            .lblCDB_FAT.DataBindings.Add("Text", GridControl5.DataSource, "CDB_Face Amount")
            .lblGJB_PrincipalT.DataBindings.Add("Text", GridControl5.DataSource, "GJB_Principal")
            .lblGJB_UDIT.DataBindings.Add("Text", GridControl5.DataSource, "GJB_UDI")
            .lblGJB_RPPDT.DataBindings.Add("Text", GridControl5.DataSource, "GJB_RPPD")
            .lblGJB_FAT.DataBindings.Add("Text", GridControl5.DataSource, "GJB_Face Amount")
            .lblEND_PrincipalT.DataBindings.Add("Text", GridControl5.DataSource, "END_Principal")
            .lblEND_UDIT.DataBindings.Add("Text", GridControl5.DataSource, "END_UDI")
            .lblEND_RPPDT.DataBindings.Add("Text", GridControl5.DataSource, "END_RPPD")
            .lblEND_FAT.DataBindings.Add("Text", GridControl5.DataSource, "END_Face Amount")
            .lblCurrentT.DataBindings.Add("Text", GridControl5.DataSource, "CURRENT")
            .lbl1_30T.DataBindings.Add("Text", GridControl5.DataSource, "1-30 Days")
            .lbl31_60T.DataBindings.Add("Text", GridControl5.DataSource, "31-60 Days")
            .lbl61_90T.DataBindings.Add("Text", GridControl5.DataSource, "61-90 Days")
            .lbl91_120T.DataBindings.Add("Text", GridControl5.DataSource, "91-120 Days")
            .lblOver120T.DataBindings.Add("Text", GridControl5.DataSource, "Over 120 Days")
            .lblTotalPastDueT.DataBindings.Add("Text", GridControl5.DataSource, "Total Past Due")

            .lblBEG_PrincipalTT.DataBindings.Add("Text", GridControl5.DataSource, "Beg_Principal")
            .lblBEG_UDITT.DataBindings.Add("Text", GridControl5.DataSource, "Beg_UDI")
            .lblBEG_RPPDTT.DataBindings.Add("Text", GridControl5.DataSource, "Beg_RPPD")
            .lblBEG_FATT.DataBindings.Add("Text", GridControl5.DataSource, "Beg_Face Amount")
            .lblCRB_PrincipalTT.DataBindings.Add("Text", GridControl5.DataSource, "CRB_Principal")
            .lblCRB_UDITT.DataBindings.Add("Text", GridControl5.DataSource, "CRB_UDI")
            .lblCRB_RPPDTT.DataBindings.Add("Text", GridControl5.DataSource, "CRB_RPPD")
            .lblCRB_FATT.DataBindings.Add("Text", GridControl5.DataSource, "CRB_Face Amount")
            .lblCDB_PrincipalTT.DataBindings.Add("Text", GridControl5.DataSource, "CDB_Principal")
            .lblCDB_UDITT.DataBindings.Add("Text", GridControl5.DataSource, "CDB_UDI")
            .lblCDB_RPPDTT.DataBindings.Add("Text", GridControl5.DataSource, "CDB_RPPD")
            .lblCDB_FATT.DataBindings.Add("Text", GridControl5.DataSource, "CDB_Face Amount")
            .lblGJB_PrincipalTT.DataBindings.Add("Text", GridControl5.DataSource, "GJB_Principal")
            .lblGJB_UDITT.DataBindings.Add("Text", GridControl5.DataSource, "GJB_UDI")
            .lblGJB_RPPDTT.DataBindings.Add("Text", GridControl5.DataSource, "GJB_RPPD")
            .lblGJB_FATT.DataBindings.Add("Text", GridControl5.DataSource, "GJB_Face Amount")
            .lblEND_PrincipalTT.DataBindings.Add("Text", GridControl5.DataSource, "END_Principal")
            .lblEND_UDITT.DataBindings.Add("Text", GridControl5.DataSource, "END_UDI")
            .lblEND_RPPDTT.DataBindings.Add("Text", GridControl5.DataSource, "END_RPPD")
            .lblEND_FATT.DataBindings.Add("Text", GridControl5.DataSource, "END_Face Amount")
            .lblCurrentTT.DataBindings.Add("Text", GridControl5.DataSource, "CURRENT")
            .lbl1_30TT.DataBindings.Add("Text", GridControl5.DataSource, "1-30 Days")
            .lbl31_60TT.DataBindings.Add("Text", GridControl5.DataSource, "31-60 Days")
            .lbl61_90TT.DataBindings.Add("Text", GridControl5.DataSource, "61-90 Days")
            .lbl91_120TT.DataBindings.Add("Text", GridControl5.DataSource, "91-120 Days")
            .lblOver120TT.DataBindings.Add("Text", GridControl5.DataSource, "Over 120 Days")
            .lblTotalPastDueTT.DataBindings.Add("Text", GridControl5.DataSource, "Total Past Due")

            .lblBEG_PrincipalGT.DataBindings.Add("Text", GridControl5.DataSource, "Beg_Principal")
            .lblBEG_UDIGT.DataBindings.Add("Text", GridControl5.DataSource, "Beg_UDI")
            .lblBEG_RPPDGT.DataBindings.Add("Text", GridControl5.DataSource, "Beg_RPPD")
            .lblBEG_FAGT.DataBindings.Add("Text", GridControl5.DataSource, "Beg_Face Amount")
            .lblCRB_PrincipalGT.DataBindings.Add("Text", GridControl5.DataSource, "CRB_Principal")
            .lblCRB_UDIGT.DataBindings.Add("Text", GridControl5.DataSource, "CRB_UDI")
            .lblCRB_RPPDGT.DataBindings.Add("Text", GridControl5.DataSource, "CRB_RPPD")
            .lblCRB_FAGT.DataBindings.Add("Text", GridControl5.DataSource, "CRB_Face Amount")
            .lblCDB_PrincipalGT.DataBindings.Add("Text", GridControl5.DataSource, "CDB_Principal")
            .lblCDB_UDIGT.DataBindings.Add("Text", GridControl5.DataSource, "CDB_UDI")
            .lblCDB_RPPDGT.DataBindings.Add("Text", GridControl5.DataSource, "CDB_RPPD")
            .lblCDB_FAGT.DataBindings.Add("Text", GridControl5.DataSource, "CDB_Face Amount")
            .lblGJB_PrincipalGT.DataBindings.Add("Text", GridControl5.DataSource, "GJB_Principal")
            .lblGJB_UDIGT.DataBindings.Add("Text", GridControl5.DataSource, "GJB_UDI")
            .lblGJB_RPPDGT.DataBindings.Add("Text", GridControl5.DataSource, "GJB_RPPD")
            .lblGJB_FAGT.DataBindings.Add("Text", GridControl5.DataSource, "GJB_Face Amount")
            .lblEND_PrincipalGT.DataBindings.Add("Text", GridControl5.DataSource, "END_Principal")
            .lblEND_UDIGT.DataBindings.Add("Text", GridControl5.DataSource, "END_UDI")
            .lblEND_RPPDGT.DataBindings.Add("Text", GridControl5.DataSource, "END_RPPD")
            .lblEND_FAGT.DataBindings.Add("Text", GridControl5.DataSource, "END_Face Amount")
            .lblCurrentGT.DataBindings.Add("Text", GridControl5.DataSource, "CURRENT")
            .lbl1_30GT.DataBindings.Add("Text", GridControl5.DataSource, "1-30 Days")
            .lbl31_60GT.DataBindings.Add("Text", GridControl5.DataSource, "31-60 Days")
            .lbl61_90GT.DataBindings.Add("Text", GridControl5.DataSource, "61-90 Days")
            .lbl91_120GT.DataBindings.Add("Text", GridControl5.DataSource, "91-120 Days")
            .lblOver120GT.DataBindings.Add("Text", GridControl5.DataSource, "Over 120 Days")
            .lblTotalPastDueGT.DataBindings.Add("Text", GridControl5.DataSource, "Total Past Due")

            'PERCENTAGE ********************************************************************************************************************
            Dim CurrentP As New CalculatedField()
            .CalculatedFields.Add(CurrentP)
            With CurrentP
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "CurrentP"
                '.Expression = "([CURRENT] / [END_Face Amount])"
                .Expression = "([][[Product] == [^.Product]].SUM([CURRENT]) / [][[Product] == [^.Product]].SUM([END_Face Amount]))"
            End With
            .lblCurrentP.DataBindings.Add("Text", Nothing, "CurrentP")

            Dim CurrentP1 As New CalculatedField()
            .CalculatedFields.Add(CurrentP1)
            With CurrentP1
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "CurrentP1"
                .Expression = "([][[Product Type] == [^.Product Type]].SUM([CURRENT]) / [][[Product Type] == [^.Product Type]].SUM([END_Face Amount]))"
            End With
            .lblCurrentTP.DataBindings.Add("Text", Nothing, "CurrentP1")

            Dim CurrentP2 As New CalculatedField()
            .CalculatedFields.Add(CurrentP2)
            With CurrentP2
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "CurrentP2"
                .Expression = "(SUM([CURRENT]) / SUM([END_Face Amount]))"
            End With
            .lblCurrentGP.DataBindings.Add("Text", Nothing, "CurrentP2")

            Dim V1_30P As New CalculatedField()
            .CalculatedFields.Add(V1_30P)
            With V1_30P
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "V1_30P"
                ' .Expression = "([1-30 Days] / [END_Face Amount])"
                .Expression = "([][[Product] == [^.Product]].SUM([1-30 Days]) / [][[Product] == [^.Product]].SUM([END_Face Amount]))"
            End With
            .lbl1_30P.DataBindings.Add("Text", Nothing, "V1_30P")

            Dim V1_30P1 As New CalculatedField()
            .CalculatedFields.Add(V1_30P1)
            With V1_30P1
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "V1_30P1"
                .Expression = "([][[Product Type] == [^.Product Type]].SUM([1-30 Days]) / [][[Product Type] == [^.Product Type]].SUM([END_Face Amount]))"
            End With
            .lbl1_30TP.DataBindings.Add("Text", Nothing, "V1_30P1")

            Dim V1_30P2 As New CalculatedField()
            .CalculatedFields.Add(V1_30P2)
            With V1_30P2
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "V1_30P2"
                .Expression = "(SUM([1-30 Days]) / SUM([END_Face Amount]))"
            End With
            .lbl1_30GP.DataBindings.Add("Text", Nothing, "V1_30P2")

            Dim V31_60P As New CalculatedField()
            .CalculatedFields.Add(V31_60P)
            With V31_60P
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "V31_60P"
                '.Expression = "([31-60 Days] / [END_Face Amount])"
                .Expression = "([][[Product] == [^.Product]].SUM([31-60 Days]) / [][[Product] == [^.Product]].SUM([END_Face Amount]))"
            End With
            .lbl31_60P.DataBindings.Add("Text", Nothing, "V31_60P")

            Dim V31_60P1 As New CalculatedField()
            .CalculatedFields.Add(V31_60P1)
            With V31_60P1
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "V31_60P1"
                .Expression = "([][[Product Type] == [^.Product Type]].SUM([31-60 Days]) / [][[Product Type] == [^.Product Type]].SUM([END_Face Amount]))"
            End With
            .lbl31_60TP.DataBindings.Add("Text", Nothing, "V31_60P1")

            Dim V31_60P2 As New CalculatedField()
            .CalculatedFields.Add(V31_60P2)
            With V31_60P2
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "V31_60P2"
                .Expression = "(SUM([31-60 Days]) / SUM([END_Face Amount]))"
            End With
            .lbl31_60GP.DataBindings.Add("Text", Nothing, "V31_60P2")

            Dim V61_90P As New CalculatedField()
            .CalculatedFields.Add(V61_90P)
            With V61_90P
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "V61_90P"
                '.Expression = "([61-90 Days] / [END_Face Amount])"
                .Expression = "([][[Product] == [^.Product]].SUM([61-90 Days]) / [][[Product] == [^.Product]].SUM([END_Face Amount]))"
            End With
            .lbl61_90P.DataBindings.Add("Text", Nothing, "V61_90P")

            Dim V61_90P1 As New CalculatedField()
            .CalculatedFields.Add(V61_90P1)
            With V61_90P1
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "V61_90P1"
                .Expression = "([][[Product Type] == [^.Product Type]].SUM([61-90 Days]) / [][[Product Type] == [^.Product Type]].SUM([END_Face Amount]))"
            End With
            .lbl61_90TP.DataBindings.Add("Text", Nothing, "V61_90P1")

            Dim V61_90P2 As New CalculatedField()
            .CalculatedFields.Add(V61_90P2)
            With V61_90P2
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "V61_90P2"
                .Expression = "(SUM([61-90 Days]) / SUM([END_Face Amount]))"
            End With
            .lbl61_90GP.DataBindings.Add("Text", Nothing, "V61_90P2")

            Dim V91_120P As New CalculatedField()
            .CalculatedFields.Add(V91_120P)
            With V91_120P
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "V91_120P"
                '.Expression = "([91-120 Days] / [END_Face Amount])"
                .Expression = "([][[Product] == [^.Product]].SUM([91-120 Days]) / [][[Product] == [^.Product]].SUM([END_Face Amount]))"
            End With
            .lbl91_120P.DataBindings.Add("Text", Nothing, "V91_120P")

            Dim V91_120P1 As New CalculatedField()
            .CalculatedFields.Add(V91_120P1)
            With V91_120P1
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "V91_120P1"
                .Expression = "([][[Product Type] == [^.Product Type]].SUM([91-120 Days]) / [][[Product Type] == [^.Product Type]].SUM([END_Face Amount]))"
            End With
            .lbl91_120TP.DataBindings.Add("Text", Nothing, "V91_120P1")

            Dim V91_120P2 As New CalculatedField()
            .CalculatedFields.Add(V91_120P2)
            With V91_120P2
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "V91_120P2"
                .Expression = "(SUM([91-120 Days]) / SUM([END_Face Amount]))"
            End With
            .lbl91_120GP.DataBindings.Add("Text", Nothing, "V91_120P2")

            Dim VOver120P As New CalculatedField()
            .CalculatedFields.Add(VOver120P)
            With VOver120P
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "VOver120P"
                '.Expression = "([Over 120 Days] / [END_Face Amount])"
                .Expression = "([][[Product] == [^.Product]].SUM([Over 120 Days]) / [][[Product] == [^.Product]].SUM([END_Face Amount]))"
            End With
            .lblOver120P.DataBindings.Add("Text", Nothing, "VOver120P")

            Dim VOver120P1 As New CalculatedField()
            .CalculatedFields.Add(VOver120P1)
            With VOver120P1
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "VOver120P1"
                .Expression = "([][[Product Type] == [^.Product Type]].SUM([Over 120 Days]) / [][[Product Type] == [^.Product Type]].SUM([END_Face Amount]))"
            End With
            .lblOver120TP.DataBindings.Add("Text", Nothing, "VOver120P1")

            Dim VOver120P2 As New CalculatedField()
            .CalculatedFields.Add(VOver120P2)
            With VOver120P2
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "VOver120P2"
                .Expression = "(SUM([Over 120 Days]) / SUM([END_Face Amount]))"
            End With
            .lblOver120GP.DataBindings.Add("Text", Nothing, "VOver120P2")

            Dim VTotalPastDueP As New CalculatedField()
            .CalculatedFields.Add(VTotalPastDueP)
            With VTotalPastDueP
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "VTotalPastDueP"
                .Expression = "[V1_30P] + [V31_60P] + [V61_90P] + [V91_120P] + [VOver120P]"
            End With
            .lblTotalPastDueP.DataBindings.Add("Text", Nothing, "VTotalPastDueP")

            Dim VTotalPastDueP1 As New CalculatedField()
            .CalculatedFields.Add(VTotalPastDueP1)
            With VTotalPastDueP1
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "VTotalPastDueP1"
                .Expression = "[V1_30P1] + [V31_60P1] + [V61_90P1] + [V91_120P1] + [VOver120P1]"
            End With
            .lblTotalPastDueTP.DataBindings.Add("Text", Nothing, "VTotalPastDueP1")

            Dim VTotalPastDueP2 As New CalculatedField()
            .CalculatedFields.Add(VTotalPastDueP2)
            With VTotalPastDueP2
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Double
                .Name = "VTotalPastDueP2"
                .Expression = "[V1_30P2] + [V31_60P2] + [V61_90P2] + [V91_120P2] + [VOver120P2]"
            End With
            .lblTotalPastDueGP.DataBindings.Add("Text", Nothing, "VTotalPastDueP2")

            'NUMBER ********************************************************************************************************************
            Dim CurrentN As New CalculatedField()
            .CalculatedFields.Add(CurrentN)
            With CurrentN
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Int16
                .Name = "CurrentN"
                .Expression = "[CURRENT] > 0 && [1-30 Days] = 0 && [31-60 Days] = 0 && [61-90 Days] = 0 && [91-120 Days] = 0 && [Over 120 Days] = 0"
            End With
            .lblCurrentN.DataBindings.Add("Text", Nothing, "CurrentN", "{0:#,#}")
            .lblCurrentTN.DataBindings.Add("Text", Nothing, "CurrentN", "{0:#,#}")
            .lblCurrentGN.DataBindings.Add("Text", Nothing, "CurrentN", "{0:#,#}")

            Dim V1_30N As New CalculatedField()
            .CalculatedFields.Add(V1_30N)
            With V1_30N
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Int16
                .Name = "V1_30N"
                .Expression = "[1-30 Days] > 0 && [31-60 Days] = 0 && [61-90 Days] = 0 && [91-120 Days] = 0 && [Over 120 Days] = 0"
            End With
            .lbl1_30N.DataBindings.Add("Text", Nothing, "V1_30N", "{0:#,#}")
            .lbl1_30TN.DataBindings.Add("Text", Nothing, "V1_30N", "{0:#,#}")
            .lbl1_30GN.DataBindings.Add("Text", Nothing, "V1_30N", "{0:#,#}")

            Dim V31_60N As New CalculatedField()
            .CalculatedFields.Add(V31_60N)
            With V31_60N
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Int16
                .Name = "V31_60N"
                .Expression = "[31-60 Days] > 0 && [61-90 Days] = 0 && [91-120 Days] = 0 && [Over 120 Days] = 0"
            End With
            .lbl31_60N.DataBindings.Add("Text", Nothing, "V31_60N", "{0:#,#}")
            .lbl31_60TN.DataBindings.Add("Text", Nothing, "V31_60N", "{0:#,#}")
            .lbl31_60GN.DataBindings.Add("Text", Nothing, "V31_60N", "{0:#,#}")

            Dim V61_90N As New CalculatedField()
            .CalculatedFields.Add(V61_90N)
            With V61_90N
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Int16
                .Name = "V61_90N"
                .Expression = "[61-90 Days] > 0 && [91-120 Days] = 0 && [Over 120 Days] = 0"
            End With
            .lbl61_90N.DataBindings.Add("Text", Nothing, "V61_90N", "{0:#,#}")
            .lbl61_90TN.DataBindings.Add("Text", Nothing, "V61_90N", "{0:#,#}")
            .lbl61_90GN.DataBindings.Add("Text", Nothing, "V61_90N", "{0:#,#}")

            Dim V91_120N As New CalculatedField()
            .CalculatedFields.Add(V91_120N)
            With V91_120N
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Int16
                .Name = "V91_120N"
                .Expression = "[91-120 Days] > 0 && [Over 120 Days] = 0"
            End With
            .lbl91_120N.DataBindings.Add("Text", Nothing, "V91_120N", "{0:#,#}")
            .lbl91_120TN.DataBindings.Add("Text", Nothing, "V91_120N", "{0:#,#}")
            .lbl91_120GN.DataBindings.Add("Text", Nothing, "V91_120N", "{0:#,#}")

            Dim VOver120N As New CalculatedField()
            .CalculatedFields.Add(VOver120N)
            With VOver120N
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Int16
                .Name = "VOver120N"
                .Expression = "[Over 120 Days] > 0"
            End With
            .lblOver120N.DataBindings.Add("Text", Nothing, "VOver120N", "{0:#,#}")
            .lblOver120TN.DataBindings.Add("Text", Nothing, "VOver120N", "{0:#,#}")
            .lblOver120GN.DataBindings.Add("Text", Nothing, "VOver120N", "{0:#,#}")

            Dim VTotalPastDueN As New CalculatedField()
            .CalculatedFields.Add(VTotalPastDueN)
            With VTotalPastDueN
                .DataSource = Report.DataSource
                .DataMember = Report.DataMember
                .FieldType = FieldType.Int16
                .Name = "VTotalPastDueN"
                .Expression = "[V1_30N] + [V31_60N] + [V61_90N] + [V91_120N] + [VOver120N]"
            End With
            .lblTotalPastDueN.DataBindings.Add("Text", Nothing, "VTotalPastDueN", "{0:#,#}")
            .lblTotalPastDueTN.DataBindings.Add("Text", Nothing, "VTotalPastDueN", "{0:#,#}")
            .lblTotalPastDueGN.DataBindings.Add("Text", Nothing, "VTotalPastDueN", "{0:#,#}")

            'Default Visible ang Current Month nga Column
            If gridBand4.Visible Then
            Else
                'Dim MinusPoint As Integer = 720
                '.XrLabel55.LocationF = New Point(3125 - MinusPoint, 0)
                '.lblEND_AsOf.LocationF = New Point(3125 - MinusPoint, 15)

                '.XrLabel54.LocationF = New Point(3125 - MinusPoint, 30)
                '.XrLabel56.LocationF = New Point(3185 - MinusPoint, 30)
                '.XrLabel57.LocationF = New Point(3245 - MinusPoint, 30)
                '.XrLabel58.LocationF = New Point(3305 - MinusPoint, 30)

                '.XrLabel119.LocationF = New Point(3125 - MinusPoint, 55)
                '.XrLabel120.LocationF = New Point(3185 - MinusPoint, 55)
                '.XrLabel121.LocationF = New Point(3245 - MinusPoint, 55)
                '.XrLabel122.LocationF = New Point(3305 - MinusPoint, 55)

                '.lblEND_Principal.LocationF = New Point(3125 - MinusPoint, 0)
                '.lblEND_UDI.LocationF = New Point(3185 - MinusPoint, 0)
                '.lblEND_RPPD.LocationF = New Point(3245 - MinusPoint, 0)
                '.lblEND_FA.LocationF = New Point(3305 - MinusPoint, 0)

                '.lblEND_PrincipalT.LocationF = New Point(3125 - MinusPoint, 0)
                '.lblEND_UDIT.LocationF = New Point(3185 - MinusPoint, 0)
                '.lblEND_RPPDT.LocationF = New Point(3245 - MinusPoint, 0)
                '.lblEND_FAT.LocationF = New Point(3305 - MinusPoint, 0)

                '.XrLabel160.LocationF = New Point(3125 - MinusPoint, 15)
                '.XrLabel162.LocationF = New Point(3185 - MinusPoint, 15)
                '.XrLabel163.LocationF = New Point(3245 - MinusPoint, 15)
                '.lblEND_FAP.LocationF = New Point(3305 - MinusPoint, 15)

                '.XrLabel177.LocationF = New Point(3125 - MinusPoint, 30)
                '.XrLabel179.LocationF = New Point(3185 - MinusPoint, 30)
                '.XrLabel180.LocationF = New Point(3245 - MinusPoint, 30)
                '.lblEND_FAN.LocationF = New Point(3305 - MinusPoint, 30)

                '.lblEND_PrincipalTT.LocationF = New Point(3125 - MinusPoint, 0)
                '.lblEND_UDITT.LocationF = New Point(3185 - MinusPoint, 0)
                '.lblEND_RPPDTT.LocationF = New Point(3245 - MinusPoint, 0)
                '.lblEND_FATT.LocationF = New Point(3305 - MinusPoint, 0)

                '.XrLabel228.LocationF = New Point(3125 - MinusPoint, 15)
                '.XrLabel226.LocationF = New Point(3185 - MinusPoint, 15)
                '.XrLabel225.LocationF = New Point(3245 - MinusPoint, 15)
                '.lblEND_FATP.LocationF = New Point(3305 - MinusPoint, 15)

                '.XrLabel236.LocationF = New Point(3125 - MinusPoint, 30)
                '.XrLabel234.LocationF = New Point(3185 - MinusPoint, 30)
                '.XrLabel233.LocationF = New Point(3245 - MinusPoint, 30)
                '.lblEND_FATN.LocationF = New Point(3305 - MinusPoint, 30)

                '.lblEND_PrincipalGT.LocationF = New Point(3125 - MinusPoint, 0)
                '.lblEND_UDIGT.LocationF = New Point(3185 - MinusPoint, 0)
                '.lblEND_RPPDGT.LocationF = New Point(3245 - MinusPoint, 0)
                '.lblEND_FAGT.LocationF = New Point(3305 - MinusPoint, 0)

                '.XrLabel312.LocationF = New Point(3125 - MinusPoint, 15)
                '.XrLabel314.LocationF = New Point(3185 - MinusPoint, 15)
                '.XrLabel315.LocationF = New Point(3245 - MinusPoint, 15)
                '.lblEND_FAGP.LocationF = New Point(3305 - MinusPoint, 15)

                '.XrLabel304.LocationF = New Point(3125 - MinusPoint, 30)
                '.XrLabel306.LocationF = New Point(3185 - MinusPoint, 30)
                '.XrLabel307.LocationF = New Point(3245 - MinusPoint, 30)
                '.lblEND_FAGN.LocationF = New Point(3305 - MinusPoint, 30)

                '.XrLabel60.LocationF = New Point(3365 - MinusPoint, 0)
                '.XrLabel66.LocationF = New Point(3425 - MinusPoint, 0)
                '.XrLabel62.LocationF = New Point(3425 - MinusPoint, 15)
                '.XrLabel69.LocationF = New Point(3725 - MinusPoint, 0)

                '.XrLabel61.LocationF = New Point(3365 - MinusPoint, 30)
                '.XrLabel67.LocationF = New Point(3425 - MinusPoint, 30)
                '.XrLabel65.LocationF = New Point(3485 - MinusPoint, 30)
                '.XrLabel64.LocationF = New Point(3545 - MinusPoint, 30)
                '.XrLabel63.LocationF = New Point(3605 - MinusPoint, 30)
                '.XrLabel68.LocationF = New Point(3665 - MinusPoint, 30)
                '.XrLabel70.LocationF = New Point(3725 - MinusPoint, 30)

                '.XrLabel123.LocationF = New Point(3365 - MinusPoint, 0)
                '.XrLabel124.LocationF = New Point(3425 - MinusPoint, 0)
                '.XrLabel125.LocationF = New Point(3485 - MinusPoint, 0)
                '.XrLabel126.LocationF = New Point(3545 - MinusPoint, 0)
                '.XrLabel127.LocationF = New Point(3605 - MinusPoint, 0)
                '.XrLabel128.LocationF = New Point(3665 - MinusPoint, 0)
                '.XrLabel129.LocationF = New Point(3725 - MinusPoint, 0)

                '.lblCurrent.LocationF = New Point(3365 - MinusPoint, 0)
                '.lbl1_30.LocationF = New Point(3425 - MinusPoint, 0)
                '.lbl31_60.LocationF = New Point(3485 - MinusPoint, 0)
                '.lbl61_90.LocationF = New Point(3545 - MinusPoint, 0)
                '.lbl91_120.LocationF = New Point(3605 - MinusPoint, 0)
                '.lblOver120.LocationF = New Point(3665 - MinusPoint, 0)
                '.lblTotalPastDue.LocationF = New Point(3725 - MinusPoint, 0)

                '.lblCurrentT.LocationF = New Point(3365 - MinusPoint, 0)
                '.lbl1_30T.LocationF = New Point(3425 - MinusPoint, 0)
                '.lbl31_60T.LocationF = New Point(3485 - MinusPoint, 0)
                '.lbl61_90T.LocationF = New Point(3545 - MinusPoint, 0)
                '.lbl91_120T.LocationF = New Point(3605 - MinusPoint, 0)
                '.lblOver120T.LocationF = New Point(3665 - MinusPoint, 0)
                '.lblTotalPastDueT.LocationF = New Point(3725 - MinusPoint, 0)

                '.lblCurrentP.LocationF = New Point(3365 - MinusPoint, 15)
                '.lbl1_30P.LocationF = New Point(3425 - MinusPoint, 15)
                '.lbl31_60P.LocationF = New Point(3485 - MinusPoint, 15)
                '.lbl61_90P.LocationF = New Point(3545 - MinusPoint, 15)
                '.lbl91_120P.LocationF = New Point(3605 - MinusPoint, 15)
                '.lblOver120P.LocationF = New Point(3665 - MinusPoint, 15)
                '.lblTotalPastDueP.LocationF = New Point(3725 - MinusPoint, 15)

                '.lblCurrentN.LocationF = New Point(3365 - MinusPoint, 30)
                '.lbl1_30N.LocationF = New Point(3425 - MinusPoint, 30)
                '.lbl31_60N.LocationF = New Point(3485 - MinusPoint, 30)
                '.lbl61_90N.LocationF = New Point(3545 - MinusPoint, 30)
                '.lbl91_120N.LocationF = New Point(3605 - MinusPoint, 30)
                '.lblOver120N.LocationF = New Point(3665 - MinusPoint, 30)
                '.lblTotalPastDueN.LocationF = New Point(3725 - MinusPoint, 30)

                '.lblCurrentTT.LocationF = New Point(3365 - MinusPoint, 0)
                '.lbl1_30TT.LocationF = New Point(3425 - MinusPoint, 0)
                '.lbl31_60TT.LocationF = New Point(3485 - MinusPoint, 0)
                '.lbl61_90TT.LocationF = New Point(3545 - MinusPoint, 0)
                '.lbl91_120TT.LocationF = New Point(3605 - MinusPoint, 0)
                '.lblOver120TT.LocationF = New Point(3665 - MinusPoint, 0)
                '.lblTotalPastDueTT.LocationF = New Point(3725 - MinusPoint, 0)

                '.lblCurrentTP.LocationF = New Point(3365 - MinusPoint, 15)
                '.lbl1_30TP.LocationF = New Point(3425 - MinusPoint, 15)
                '.lbl31_60TP.LocationF = New Point(3485 - MinusPoint, 15)
                '.lbl61_90TP.LocationF = New Point(3545 - MinusPoint, 15)
                '.lbl91_120TP.LocationF = New Point(3605 - MinusPoint, 15)
                '.lblOver120TP.LocationF = New Point(3665 - MinusPoint, 15)
                '.lblTotalPastDueTP.LocationF = New Point(3725 - MinusPoint, 15)

                '.lblCurrentTN.LocationF = New Point(3365 - MinusPoint, 30)
                '.lbl1_30TN.LocationF = New Point(3425 - MinusPoint, 30)
                '.lbl31_60TN.LocationF = New Point(3485 - MinusPoint, 30)
                '.lbl61_90TN.LocationF = New Point(3545 - MinusPoint, 30)
                '.lbl91_120TN.LocationF = New Point(3605 - MinusPoint, 30)
                '.lblOver120TN.LocationF = New Point(3665 - MinusPoint, 30)
                '.lblTotalPastDueTN.LocationF = New Point(3725 - MinusPoint, 30)

                '.lblCurrentGT.LocationF = New Point(3365 - MinusPoint, 0)
                '.lbl1_30GT.LocationF = New Point(3425 - MinusPoint, 0)
                '.lbl31_60GT.LocationF = New Point(3485 - MinusPoint, 0)
                '.lbl61_90GT.LocationF = New Point(3545 - MinusPoint, 0)
                '.lbl91_120GT.LocationF = New Point(3605 - MinusPoint, 0)
                '.lblOver120GT.LocationF = New Point(3665 - MinusPoint, 0)
                '.lblTotalPastDueGT.LocationF = New Point(3725 - MinusPoint, 0)

                '.lblCurrentGP.LocationF = New Point(3365 - MinusPoint, 15)
                '.lbl1_30GP.LocationF = New Point(3425 - MinusPoint, 15)
                '.lbl31_60GP.LocationF = New Point(3485 - MinusPoint, 15)
                '.lbl61_90GP.LocationF = New Point(3545 - MinusPoint, 15)
                '.lbl91_120GP.LocationF = New Point(3605 - MinusPoint, 15)
                '.lblOver120GP.LocationF = New Point(3665 - MinusPoint, 15)
                '.lblTotalPastDueGP.LocationF = New Point(3725 - MinusPoint, 15)

                '.lblCurrentGN.LocationF = New Point(3365 - MinusPoint, 30)
                '.lbl1_30GN.LocationF = New Point(3425 - MinusPoint, 30)
                '.lbl31_60GN.LocationF = New Point(3485 - MinusPoint, 30)
                '.lbl61_90GN.LocationF = New Point(3545 - MinusPoint, 30)
                '.lbl91_120GN.LocationF = New Point(3605 - MinusPoint, 30)
                '.lblOver120GN.LocationF = New Point(3665 - MinusPoint, 30)
                '.lblTotalPastDueGN.LocationF = New Point(3725 - MinusPoint, 30)

                '.XrLabel72.LocationF = New Point(3785 - MinusPoint, 0)
                '.XrLabel71.LocationF = New Point(3785 - MinusPoint, 30)
                '.XrLabel73.LocationF = New Point(3845 - MinusPoint, 30)
                '.XrLabel74.LocationF = New Point(3905 - MinusPoint, 30)

                '.XrLabel130.LocationF = New Point(3785 - MinusPoint, 55)
                '.XrLabel132.LocationF = New Point(3845 - MinusPoint, 55)
                '.XrLabel131.LocationF = New Point(3905 - MinusPoint, 55)

                '.lblLastPaymentDate.LocationF = New Point(3785 - MinusPoint, 0)
                '.lblRemedyApplied.LocationF = New Point(3845 - MinusPoint, 0)
                '.lblRemarks.LocationF = New Point(3905 - MinusPoint, 0)

                '.XrLabel191.LocationF = New Point(3785 - MinusPoint, 0)
                '.XrLabel172.LocationF = New Point(3785 - MinusPoint, 15)
                '.XrLabel189.LocationF = New Point(3785 - MinusPoint, 30)

                '.XrLabel245.LocationF = New Point(3785 - MinusPoint, 0)
                '.XrLabel248.LocationF = New Point(3785 - MinusPoint, 15)
                '.XrLabel256.LocationF = New Point(3785 - MinusPoint, 30)

                '.XrLabel343.LocationF = New Point(3785 - MinusPoint, 0)
                '.XrLabel340.LocationF = New Point(3785 - MinusPoint, 15)
                '.XrLabel332.LocationF = New Point(3785 - MinusPoint, 30)

                '.XrPageInfo2.LocationF = New Point(3650 - MinusPoint, 0)

                '.XrLabel39.Visible = False
                '.XrLabel43.Visible = False
                '.XrLabel38.Visible = False
                '.XrLabel40.Visible = False
                '.XrLabel41.Visible = False
                '.XrLabel42.Visible = False
                '.XrLabel107.Visible = False
                '.XrLabel108.Visible = False
                '.XrLabel109.Visible = False
                '.XrLabel110.Visible = False
                '.lblCRB_Principal.Visible = False
                '.lblCRB_UDI.Visible = False
                '.lblCRB_RPPD.Visible = False
                '.lblCRB_FA.Visible = False
                '.lblCRB_PrincipalT.Visible = False
                '.lblCRB_UDIT.Visible = False
                '.lblCRB_RPPDT.Visible = False
                '.lblCRB_FAT.Visible = False
                '.XrLabel136.Visible = False
                '.XrLabel137.Visible = False
                '.XrLabel138.Visible = False
                '.XrLabel139.Visible = False
                '.XrLabel149.Visible = False
                '.XrLabel150.Visible = False
                '.XrLabel151.Visible = False
                '.XrLabel152.Visible = False
                '.lblCRB_PrincipalTT.Visible = False
                '.lblCRB_UDITT.Visible = False
                '.lblCRB_RPPDTT.Visible = False
                '.lblCRB_FATT.Visible = False
                '.XrLabel205.Visible = False
                '.XrLabel204.Visible = False
                '.XrLabel203.Visible = False
                '.XrLabel202.Visible = False
                '.XrLabel218.Visible = False
                '.XrLabel217.Visible = False
                '.XrLabel216.Visible = False
                '.XrLabel215.Visible = False
                '.lblCRB_PrincipalGT.Visible = False
                '.lblCRB_UDIGT.Visible = False
                '.lblCRB_RPPDGT.Visible = False
                '.lblCRB_FAGT.Visible = False
                '.XrLabel280.Visible = False
                '.XrLabel267.Visible = False
                '.XrLabel281.Visible = False
                '.XrLabel268.Visible = False
                '.XrLabel282.Visible = False
                '.XrLabel269.Visible = False
                '.XrLabel283.Visible = False
                '.XrLabel270.Visible = False
                '.XrLabel44.Visible = False
                '.XrLabel48.Visible = False
                '.XrLabel47.Visible = False
                '.XrLabel46.Visible = False
                '.XrLabel45.Visible = False
                '.XrLabel53.Visible = False
                '.XrLabel49.Visible = False
                '.XrLabel50.Visible = False
                '.XrLabel51.Visible = False
                '.XrLabel52.Visible = False
                '.XrLabel115.Visible = False
                '.XrLabel116.Visible = False
                '.XrLabel117.Visible = False
                '.XrLabel118.Visible = False
                '.lblCDB_Principal.Visible = False
                '.lblCDB_UDI.Visible = False
                '.lblCDB_RPPD.Visible = False
                '.lblCDB_FA.Visible = False
                '.lblGJB_Principal.Visible = False
                '.lblGJB_UDI.Visible = False
                '.lblGJB_RPPD.Visible = False
                '.lblGJB_FA.Visible = False
                '.lblCDB_PrincipalT.Visible = False
                '.lblCDB_UDIT.Visible = False
                '.lblCDB_RPPDT.Visible = False
                '.lblCDB_FAT.Visible = False
                '.lblGJB_PrincipalT.Visible = False
                '.lblGJB_UDIT.Visible = False
                '.lblGJB_RPPDT.Visible = False
                '.lblGJB_FAT.Visible = False
                '.lblCDB_PrincipalTT.Visible = False
                '.lblCDB_UDITT.Visible = False
                '.lblCDB_RPPDTT.Visible = False
                '.lblCDB_FATT.Visible = False
                '.lblGJB_PrincipalTT.Visible = False
                '.lblGJB_UDITT.Visible = False
                '.lblGJB_RPPDTT.Visible = False
                '.lblGJB_FATT.Visible = False
                '.lblCDB_PrincipalGT.Visible = False
                '.lblCDB_UDIGT.Visible = False
                '.lblCDB_RPPDGT.Visible = False
                '.lblCDB_FAGT.Visible = False
                '.lblGJB_PrincipalGT.Visible = False
                '.lblGJB_UDIGT.Visible = False
                '.lblGJB_RPPDGT.Visible = False
                '.lblGJB_FAGT.Visible = False
                '.XrLabel140.Visible = False
                '.XrLabel142.Visible = False
                '.XrLabel141.Visible = False
                '.XrLabel143.Visible = False
                '.XrLabel171.Visible = False
                '.XrLabel170.Visible = False
                '.XrLabel159.Visible = False
                '.XrLabel161.Visible = False
                '.XrLabel155.Visible = False
                '.XrLabel154.Visible = False
                '.XrLabel156.Visible = False
                '.XrLabel188.Visible = False
                '.XrLabel187.Visible = False
                '.XrLabel176.Visible = False
                '.XrLabel178.Visible = False
                '.XrLabel201.Visible = False
                '.XrLabel199.Visible = False
                '.XrLabel200.Visible = False
                '.XrLabel198.Visible = False
                '.XrLabel223.Visible = False
                '.XrLabel224.Visible = False
                '.XrLabel229.Visible = False
                '.XrLabel227.Visible = False
                '.XrLabel214.Visible = False
                '.XrLabel212.Visible = False
                '.XrLabel213.Visible = False
                '.XrLabel211.Visible = False
                '.XrLabel231.Visible = False
                '.XrLabel232.Visible = False
                '.XrLabel237.Visible = False
                '.XrLabel235.Visible = False
                '.XrLabel284.Visible = False
                '.XrLabel286.Visible = False
                '.XrLabel285.Visible = False
                '.XrLabel287.Visible = False
                '.XrLabel317.Visible = False
                '.XrLabel316.Visible = False
                '.XrLabel311.Visible = False
                '.XrLabel313.Visible = False
                '.XrLabel271.Visible = False
                '.XrLabel273.Visible = False
                '.XrLabel272.Visible = False
                '.XrLabel274.Visible = False
                '.XrLabel309.Visible = False
                '.XrLabel308.Visible = False
                '.XrLabel303.Visible = False
                '.XrLabel305.Visible = False
            End If
            If cbxMerge.Checked Then
                .CreateDocument()
            Else
                .ShowPreview()
            End If
        End With

        If cbxMerge.Checked Then
            With TopSheet
                .Pages.AddRange(TopSheetPerProcedure.Pages)
                .Pages.AddRange(Report.Pages)
                .ShowPreview()
            End With
        End If
        Logs("Aging", "Print", "[SENSITIVE] Print Aging", "", "", "", "")

        'Dim Merge As New RptAgingMerged
        'With Merge
        '    .subRptTopSheet.ReportSource = TopSheet
        '    .subRptTopSheetProcedure.ReportSource = TopSheetPerProcedure
        '    .subRptAging.ReportSource = Report
        '    Logs("Aging", "Print", "[SENSITIVE] Print Aging", "", "", "", "")
        '    .ShowPreview()
        'End With
        Cursor = Cursors.Default
    End Sub
    '***BUTTON CLICK

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

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If FirstLoad Then
            Exit Sub
        End If
        If (cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "") And cbxAllB.Checked = False Then
            MsgBox("Please select a branch.", MsgBoxStyle.Information, "Info")
            cbxBranch.DroppedDown = True
        End If

        LoadData()
    End Sub

    Private Sub CbxAllB_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAllB.CheckedChanged
        If cbxAllB.Checked Then
            cbxBranch.Enabled = False
            cbxBranch.SelectedIndex = -1
            cbxBusinessCenter.Enabled = False
            cbxBusinessCenter.Text = ""
        Else
            cbxBranch.Enabled = True
            cbxBranch.SelectedValue = Branch_ID
            cbxBusinessCenter.Enabled = True
        End If
    End Sub

    Private Sub BtnPrintCustomized_Click(sender As Object, e As EventArgs) Handles btnPrintCustomized.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        BandedGridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting("AGING REPORT", GridControl1)
        Logs("Aging", "Print", "[SENSITIVE] Print Aging", "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBranch.SelectedIndexChanged
        cbxBusinessCenter.DataSource = DataSource(String.Format("SELECT ID, BusinessCode, BusinessCenter FROM business_center WHERE `status` = 'ACTIVE' AND BranchID = '{0}';", cbxBranch.SelectedValue))
        If cbxBusinessCenter.Items.Count > 0 Then
            cbxBusinessCenter.Enabled = True
        Else
            cbxBusinessCenter.Enabled = False
        End If
        cbxBusinessCenter.SelectedIndex = -1
    End Sub

    Private Sub CbxBranch_TextChanged(sender As Object, e As EventArgs) Handles cbxBranch.TextChanged
        If cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "" Then
            cbxBusinessCenter.Text = ""
            cbxBusinessCenter.Enabled = False
        End If
    End Sub

    Private Sub CbxBook_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBook.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        With cbxBank
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank', (SELECT B.bank FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_1', Branch FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' AND IF({1} > 0,ID = {1},TRUE) AND Book = '{2}' ORDER BY `Code`;", Branch_ID, DefaultBankID, cbxBook.SelectedValue))
        End With
    End Sub

    Private Sub CbxAllBank_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAllBank.CheckedChanged
        If cbxAllBank.Checked Then
            cbxBook.Enabled = False
            cbxBook.SelectedIndex = -1
            cbxBank.Enabled = False
            cbxBank.Text = ""
        Else
            cbxBook.Enabled = True
            cbxBook.SelectedIndex = 0
            cbxBank.Enabled = True
        End If
    End Sub

    Private Sub ILedger_Click(sender As Object, e As EventArgs) Handles iLedger.Click
        Try
            If BandedGridView1.GetFocusedRowCellValue("CreditNumber") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = BandedGridView1.GetFocusedRowCellValue("CreditNumber")
            .Show()
        End With
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles BandedGridView1.DoubleClick
        Try
            If BandedGridView1.GetFocusedRowCellValue("CreditNumber") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = BandedGridView1.GetFocusedRowCellValue("CreditNumber")
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub ITagRemedial_Click(sender As Object, e As EventArgs) Handles iTagRemedial.Click
        Try
            If BandedGridView1.GetFocusedRowCellValue("CreditNumber") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Remedial As New FrmRemedialTagging
        With Remedial
            .Remedial = BandedGridView1.GetFocusedRowCellValue("RemedyAppliedID")
            If .ShowDialog = DialogResult.OK Then
                DataObject(String.Format("UPDATE credit_application SET RemedyAppliedID = {1} WHERE CreditNumber = '{0}';", BandedGridView1.GetFocusedRowCellValue("CreditNumber"), .cbxRemedial.SelectedValue))
                Logs("Aging", "Remedial Tag", String.Format("Update Tagged Remedial of {0} {1} to {2}", BandedGridView1.GetFocusedRowCellValue("Borrowers Name"), BandedGridView1.GetFocusedRowCellValue("Account No."), .cbxRemedial.Text), "", "", "", "")
                'LoadData()
                BandedGridView1.SetFocusedRowCellValue("RemedyAppliedID", .cbxRemedial.SelectedValue)
                MsgBox("Successfully Tagged!", MsgBoxStyle.Information, "Info")
            End If
            .Dispose()
        End With
    End Sub

    Private Sub IAmortizationSchedule_Click(sender As Object, e As EventArgs) Handles iAmortizationSchedule.Click
        Try
            If BandedGridView1.GetFocusedRowCellValue("CreditNumber") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If MsgBoxYes("Are you sure you want to open the amortization schedule?") = MsgBoxResult.Yes Then
            Dim Monatorium As New FrmMonatorium
            With Monatorium
                .lblTitle.Text = "AMORTIZATION SCHEDULE"
                .PanelEx5.Visible = False
                .iTerms_C.MinValue = 0
                .iTerms_C.MaxValue = 0
                .LabelX81.Text = "Term :"
                .LabelX9.Visible = False
                .dtpStart.Visible = False
                .LabelX47.Visible = True
                .cbxType.Visible = True
                .cbxType.SelectedIndex = 0
                LoadAmortization(BandedGridView1.GetFocusedRowCellValue("CreditNumber"))
                .Original_Amortization = DT_Schedule
                .CreditNumber = BandedGridView1.GetFocusedRowCellValue("CreditNumber")
                .Borrower = BandedGridView1.GetFocusedRowCellValue("Borrowers Name")
                .btnSave.Visible = False
                .btnResend.Visible = False
                .btnSave.Enabled = False
                .btnResend.Enabled = False
                .btnCancel.Location = New Point(6, 3)
                .btnPrint.Location = New Point(119, 3)
                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub

    Private Sub LoadAmortization(CreditNumber As String)
        Dim Temp_DT As DataTable = DataSource(String.Format("SELECT `No`, IFNULL(DATE_FORMAT(DueDate,'%m.%d.%Y'),'') AS 'Due Date', IF(`No` = '','',FORMAT(Monthly,2)) AS 'Monthly', IF(`No` = '','',FORMAT(InterestIncome,2)) AS 'Interest Income', IF(`No` = '','',FORMAT(RPPD,2)) AS 'RPPD', IF(`No` = '','',FORMAT(PrincipalAllocation,2)) AS 'Principal Allocation', FORMAT(OutstandingPrincipal,2) AS 'Outstanding Principal', FORMAT(Total_RPPD,2) AS 'Total_RPPD', FORMAT(UnearnIncome,2) AS 'Unearn Income', FORMAT(LoansReceivable,2) AS 'Loans Receivable', FORMAT(Penalty,2) AS 'Penalty', FORMAT(PenaltyBalance,2) AS 'Penalty Balance' FROM credit_schedule WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", CreditNumber))
        Dim T_Monthly As Double
        Dim T_Interest As Double
        Dim T_RPPD As Double
        Dim T_Principal As Double
        Dim T_Penalty As Double
        For x As Integer = 1 To Temp_DT.Rows.Count - 1
            T_Monthly += CDbl(Temp_DT(x)("Monthly"))
            T_Interest += CDbl(Temp_DT(x)("Interest Income"))
            T_RPPD += CDbl(Temp_DT(x)("RPPD"))
            T_Principal += CDbl(Temp_DT(x)("Principal Allocation"))
            T_Penalty += CDbl(Temp_DT(x)("Penalty"))
        Next
        If T_Penalty > 0 Then
            GridColumn6.VisibleIndex = 0
            GridColumn10.VisibleIndex = 1
            GridColumn27.VisibleIndex = 2
            GridColumn11.VisibleIndex = 3
            GridColumn12.VisibleIndex = 4
            GridColumn7.VisibleIndex = 5
            GridColumn8.VisibleIndex = 6

            GridColumn6.Width = 22
            GridColumn10.Width = 54
            GridColumn11.Width = 54
            GridColumn12.Width = 54
            GridColumn7.Width = 62
            GridColumn27.Width = 52
            GridColumn8.Width = 62
        End If
        Temp_DT.Rows.Add("", "TOTAL", FormatNumber(T_Monthly, 2), FormatNumber(T_Interest, 2), FormatNumber(T_RPPD, 2), FormatNumber(T_Principal, 2), "", "", "", "", FormatNumber(T_Penalty, 2), "")
        DT_Schedule = Temp_DT
    End Sub
End Class