Imports DevExpress.XtraReports.UI
Public Class FrmBookingAndCollection

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Dim DT_BookingSummary As DataTable
    Dim DT_ClientType As DataTable
    Dim DT_BusinessCenter As DataTable
    Dim DT_SourceOfIncome As DataTable
    Dim DT_BookingDetailed As DataTable
    Dim DT_BookingDetailedPrint As DataTable
    Dim DT_CollectionSummary As DataTable
    Dim DT_CollectionDetailed As DataTable

    Dim FirstLoad As Boolean = True
    Dim DT_Products As DataTable

    Private Sub FrmBookingAndCollection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetBandedGridApperance({BandedGridView1, BandedGridView2, BandedGridView3, BandedGridView4, BandedGridView5, BandedGridView6, BandedGridView7})
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dtpPeriod.Value = Date.Now

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
        DT_Products = DataSource("SELECT ID, ProductType, ProductTypeCode FROM product_type WHERE `status` = 'ACTIVE';")
        DT_BookingSummary = DataSource("SELECT '' AS 'ID', '' AS 'PRODUCT', '' AS 'Product Code', 0.0 AS '1', 0.0 AS '2', 0.0 AS '3', 0.0 AS '4', 0.0 AS '5', 0.0 AS 'TOTAL','' AS '%', 0.0 AS 'Processing Fee', 0.0 AS 'Service Charge', 0.0 AS 'Insurance', 0.0 AS 'Miscellaneous' LIMIT 0")
        DT_ClientType = DataSource("SELECT '' AS 'ID', '' AS 'PRODUCT', '' AS 'Product Code', 0.0 AS 'NEW', 0.0 AS 'REPEAT', 0.0 AS 'TOTAL', '' AS '% NEW', '' AS '% REPEAT', '' AS '% TOTAL' LIMIT 0")
        DT_BusinessCenter = DataSource("SELECT '' AS 'ID', '' AS 'PRODUCT', '' AS 'Product Code', 0.0 AS 'TOTAL', 0.0 AS '1', 0.0 AS '2', 0.0 AS '3', 0.0 AS '4', 0.0 AS '5', 0.0 AS '6', 0.0 AS '7', 0.0 AS '8', 0.0 AS '9', 0.0 AS '10' LIMIT 0")
        DT_SourceOfIncome = DataSource("SELECT '' AS 'ID', '' AS 'PRODUCT', '' AS 'Product Code', 0.0 AS 'TOTAL', 0.0 AS '1', 0.0 AS '2', 0.0 AS '3', 0.0 AS '4', 0.0 AS '5', 0.0 AS '6', 0.0 AS '7', 0.0 AS '8', 0.0 AS '9', 0.0 AS '10', 0.0 AS '11', 0.0 AS '12', 0.0 AS '13', 0.0 AS '14', 0.0 AS '15', 0.0 AS '16', 0.0 AS '17', 0.0 AS '18', 0.0 AS '19', 0.0 AS '20', 0.0 AS '21', 0.0 AS '22', 0.0 AS '23', 0.0 AS '24', 0.0 AS '25', 0.0 AS '26', 0.0 AS '27', 0.0 AS '28', 0.0 AS '29', 0.0 AS '30' LIMIT 0")
        DT_CollectionSummary = DataSource("SELECT '' AS 'ID', '' AS 'PRODUCT', '' AS 'Product Code', 0.0 AS '1', 0.0 AS '2', 0.0 AS '3', 0.0 AS '4', 0.0 AS '5', 0.0 AS 'TOTAL' LIMIT 0")
        DT_CollectionDetailed = DataSource("SELECT '' AS 'ID', '' AS 'PRODUCT', '' AS 'Product Code', 0.0 AS 'Loans Receivable_1', 0.0 AS 'Interest Income-Current_1', 0.0 AS 'Interest Income-Past Due_1', 0.0 AS 'Others_1', 0.0 AS 'Loans Receivable_2', 0.0 AS 'Interest Income-Current_2', 0.0 AS 'Interest Income-Past Due_2', 0.0 AS 'Others_2', 0.0 AS 'Loans Receivable_3', 0.0 AS 'Interest Income-Current_3', 0.0 AS 'Interest Income-Past Due_3', 0.0 AS 'Others_3', 0.0 AS 'Loans Receivable_4', 0.0 AS 'Interest Income-Current_4', 0.0 AS 'Interest Income-Past Due_4', 0.0 AS 'Others_4', 0.0 AS 'Loans Receivable_5', 0.0 AS 'Interest Income-Current_5', 0.0 AS 'Interest Income-Past Due_5', 0.0 AS 'Others_5' LIMIT 0")
        With cbxBook
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            FirstLoad = False
            .DataSource = DataSource("SELECT 1 AS 'ID', 'Bank 1' AS 'Bank' UNION ALL SELECT 2 AS 'ID', 'Bank 2' AS 'Bank';")
        End With
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX1, LabelX2, LabelX42})

            GetCheckBoxFontSettings({cbxAllB, cbxAllBank})

            GetComboBoxFontSettings({cbxBranch, cbxBook, cbxBank})

            GetDateTimeInputFontSettings({dtpPeriod})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint, btnPrintCustomized, btnCollectionDetails})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Booking and Collection - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Booking and Collection", lblTitle.Text)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadBookingSummary()
        LoadClientType()
        LoadBusinessCenter()
        LoadSourceOfIncome()
        LoadBookingDetailed()
        LoadCollectionSummary()
        LoadCollectionDetailed()
    End Sub

    Private Sub LoadBookingSummary()
        Cursor = Cursors.WaitCursor
        Dim B1_T As Double
        Dim B2_T As Double
        Dim B3_T As Double
        Dim B4_T As Double
        Dim B5_T As Double
        Dim Total_T As Double
        Dim Processing_T As Double
        Dim Service_T As Double
        Dim Insurance_T As Double
        Dim Miscellaneous_T As Double
        Dim B1_G As Double
        Dim B2_G As Double
        Dim B3_G As Double
        Dim B4_G As Double
        Dim B5_G As Double
        Dim Total_G As Double
        Dim Processing_G As Double
        Dim Service_G As Double
        Dim Insurance_G As Double
        Dim Miscellaneous_G As Double
        Dim DT_Temp As DataTable
        DT_BookingSummary.Rows.Clear()
        For x As Integer = 0 To DT_Products.Rows.Count - 1
            DT_Temp = DataSource(String.Format("CALL BookingAndCollection_Summary('{0}',{1},{2},'{3}',{4},{5},{6},{7})", Format(dtpPeriod.Value, "yyyy-MM-dd"), cbxAllB.Checked, cbxBranch.SelectedValue, Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook), DT_Products(x)("ID")))
            B1_T = 0
            B2_T = 0
            B3_T = 0
            B4_T = 0
            B5_T = 0
            Total_T = 0
            Processing_T = 0
            Service_T = 0
            Insurance_T = 0
            Miscellaneous_T = 0
            For y As Integer = 0 To DT_Temp.Rows.Count - 1
                B1_T += DT_Temp(y)("1")
                B2_T += DT_Temp(y)("2")
                B3_T += DT_Temp(y)("3")
                B4_T += DT_Temp(y)("4")
                B5_T += DT_Temp(y)("5")
                Total_T += DT_Temp(y)("TOTAL")
                Processing_T += DT_Temp(y)("Processing Fee")
                Service_T += DT_Temp(y)("Service Charge")
                Insurance_T += DT_Temp(y)("Insurance")
                Miscellaneous_T += DT_Temp(y)("Miscellaneous")

                B1_G += DT_Temp(y)("1")
                B2_G += DT_Temp(y)("2")
                B3_G += DT_Temp(y)("3")
                B4_G += DT_Temp(y)("4")
                B5_G += DT_Temp(y)("5")
                Total_G += DT_Temp(y)("TOTAL")
                Processing_G += DT_Temp(y)("Processing Fee")
                Service_G += DT_Temp(y)("Service Charge")
                Insurance_G += DT_Temp(y)("Insurance")
                Miscellaneous_G += DT_Temp(y)("Miscellaneous")
            Next
            DT_BookingSummary.Rows.Add(-1, DT_Products(x)("ProductType"), DT_Products(x)("ProductTypeCode"), B1_T, B2_T, B3_T, B4_T, B5_T, Total_T, If(Total_T > 0, Math.Round((Total_T / Total_G) * 100, 0) & "%", ""), Processing_T, Service_T, Insurance_T, Miscellaneous_T)
            For y As Integer = 0 To DT_Temp.Rows.Count - 1
                DT_BookingSummary.Rows.Add(DT_Temp(y)("ID"), "              " & DT_Temp(y)("PRODUCT"), DT_Temp(y)("Code"), DT_Temp(y)("1"), DT_Temp(y)("2"), DT_Temp(y)("3"), DT_Temp(y)("4"), DT_Temp(y)("5"), DT_Temp(y)("TOTAL"), "", DT_Temp(y)("Processing Fee"), DT_Temp(y)("Service Charge"), DT_Temp(y)("Insurance"), DT_Temp(y)("Miscellaneous"))
            Next
        Next
        DT_BookingSummary.Rows.Add(0)
        DT_BookingSummary.Rows.Add(0, "GRAND TOTAL", "", B1_G, B2_G, B3_G, B4_G, B5_G, Total_G, If(Total_G > 0, Math.Round((Total_G / Total_G) * 100, 0) & "%", ""), Processing_G, Service_G, Insurance_G, Miscellaneous_G)

        GridControl1.DataSource = DT_BookingSummary
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadClientType()
        Cursor = Cursors.WaitCursor
        Dim New_T As Double
        Dim Repeat_T As Double
        Dim Total_T As Double
        Dim New_G As Double
        Dim Repeat_G As Double
        Dim Total_G As Double
        Dim DT_Temp As DataTable
        DT_ClientType.Rows.Clear()
        For x As Integer = 0 To DT_Products.Rows.Count - 1
            DT_Temp = DataSource(String.Format("CALL BookingAndCollection_ClientType('{0}',{1},{2},'{3}',{4},{5},{6},{7})", Format(dtpPeriod.Value, "yyyy-MM-dd"), cbxAllB.Checked, cbxBranch.SelectedValue, Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook), DT_Products(x)("ID")))
            New_T = 0
            Repeat_T = 0
            Total_T = 0
            For y As Integer = 0 To DT_Temp.Rows.Count - 1
                New_T += DT_Temp(y)("NEW")
                Repeat_T += DT_Temp(y)("REPEAT")
                Total_T += DT_Temp(y)("TOTAL")

                New_G += DT_Temp(y)("NEW")
                Repeat_G += DT_Temp(y)("REPEAT")
                Total_G += DT_Temp(y)("TOTAL")
            Next
            DT_ClientType.Rows.Add(-1, DT_Products(x)("ProductType"), DT_Products(x)("ProductTypeCode"), New_T, Repeat_T, Total_T, FormatNumber(If(New_T > 0, (New_T / Total_T) * 100, 0), 0) & "%", FormatNumber(If(Repeat_T > 0, (Repeat_T / Total_T) * 100, 0), 0) & "%", FormatNumber(If(Total_T > 0, (Total_T / Total_T) * 100, 0), 0) & "%")
            For y As Integer = 0 To DT_Temp.Rows.Count - 1
                DT_ClientType.Rows.Add(DT_Temp(y)("ID"), "              " & DT_Temp(y)("PRODUCT"), DT_Temp(y)("Code"), DT_Temp(y)("NEW"), DT_Temp(y)("REPEAT"), DT_Temp(y)("TOTAL"), DT_Temp(y)("% NEW"), DT_Temp(y)("% REPEAT"), DT_Temp(y)("% TOTAL"))
            Next
        Next
        DT_ClientType.Rows.Add(0)
        DT_ClientType.Rows.Add(0, "GRAND TOTAL", "", New_G, Repeat_G, Total_G, FormatNumber(If(New_G > 0, (New_G / Total_G) * 100, 0), 0) & "%", FormatNumber(If(Repeat_G > 0, (Repeat_G / Total_G) * 100, 0), 0) & "%", FormatNumber(If(Total_G > 0, (Total_G / Total_G) * 100, 0), 0) & "%")

        GridControl2.DataSource = DT_ClientType
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadBusinessCenter()
        Cursor = Cursors.WaitCursor
        Dim SQL As String
        Dim Total_T As Double
        Dim Branch1_T As Double
        Dim B2_T As Double
        Dim B3_T As Double
        Dim B4_T As Double
        Dim B5_T As Double
        Dim B6_T As Double
        Dim B7_T As Double
        Dim B8_T As Double
        Dim B9_T As Double
        Dim B10_T As Double
        Dim Total_G As Double
        Dim Branch1_G As Double
        Dim B2_G As Double
        Dim B3_G As Double
        Dim B4_G As Double
        Dim B5_G As Double
        Dim B6_G As Double
        Dim B7_G As Double
        Dim B8_G As Double
        Dim B9_G As Double
        Dim B10_G As Double
        Dim DT_BC As DataTable
        Dim DT_Temp As DataTable
        DT_BusinessCenter.Rows.Clear()
        DT_BC = DataSource(String.Format("SELECT ID, BusinessCenter FROM business_center WHERE BranchID = '{0}';", cbxBranch.SelectedValue))
        For x As Integer = 0 To DT_Products.Rows.Count - 1
            SQL = "SELECT P.ID, P.Product, P.Code, IFNULL(C.TOTAL,0) AS 'TOTAL', IFNULL(C.Branch,0) AS '1', IFNULL(C.`2`,0) AS '2', IFNULL(C.`3`,0) AS '3', IFNULL(C.`4`,0) AS '4', IFNULL(C.`5`,0) AS '5', IFNULL(C.`6`,0) AS '6', IFNULL(C.`7`,0) AS '7', IFNULL(C.`8`,0) AS '8', IFNULL(C.`9`,0) AS '9', IFNULL(C.`10`,0) AS '10' FROM product_setup P LEFT JOIN (SELECT "
            SQL &= "  product_id AS 'ID',"
            SQL &= "  IFNULL(SUM(AmountApplied),0) AS 'TOTAL',"
            SQL &= "  IFNULL(SUM(CASE WHEN BusinessID = 0 THEN AmountApplied END),0) AS 'Branch',"
            For y As Integer = 0 To 8
                If DT_BC.Rows.Count - 1 >= y Then
                    SQL &= String.Format("  IFNULL(SUM(CASE WHEN BusinessID = '{0}' THEN AmountApplied END),0) AS '{1}',", DT_BC(y)("ID"), y + 2)
                    If y = 0 Then
                        BandedGridColumn89.Caption = DT_BC(y)("BusinessCenter")
                    ElseIf y = 1 Then
                        BandedGridColumn90.Caption = DT_BC(y)("BusinessCenter")
                    ElseIf y = 2 Then
                        BandedGridColumn91.Caption = DT_BC(y)("BusinessCenter")
                    ElseIf y = 3 Then
                        BandedGridColumn92.Caption = DT_BC(y)("BusinessCenter")
                    ElseIf y = 4 Then
                        BandedGridColumn93.Caption = DT_BC(y)("BusinessCenter")
                    ElseIf y = 5 Then
                        BandedGridColumn94.Caption = DT_BC(y)("BusinessCenter")
                    ElseIf y = 6 Then
                        BandedGridColumn95.Caption = DT_BC(y)("BusinessCenter")
                    ElseIf y = 7 Then
                        BandedGridColumn96.Caption = DT_BC(y)("BusinessCenter")
                    ElseIf y = 8 Then
                        BandedGridColumn97.Caption = DT_BC(y)("BusinessCenter")
                    End If
                Else
                    SQL &= String.Format("  0 AS '{0}',", y + 2)
                End If
            Next
            SQL = SQL.Substring(0, SQL.Length - 1)
            SQL &= String.Format("  FROM credit_application C WHERE `status` = 'ACTIVE' AND loan_type != 'RESTRUCTURE' AND MONTH(Released) = MONTH('{0}') AND YEAR(Released) = YEAR('{0}') AND PaymentRequest IN ('RELEASED','CLOSED') AND IF({1} = 1,Branch_ID IN ({3}),Branch_ID = '{2}') AND IF('{4}' = 'True',TRUE,IF('{5}' = 0,Book(BankID) = '{6}',BankID = '{5}')) GROUP BY product_id) C ON P.ID = C.ID WHERE Branch_ID = '{2}' AND Product_Type = '{7}';", Format(dtpPeriod.Value, "yyyy-MM-dd"), cbxAllB.Checked, cbxBranch.SelectedValue, Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook), DT_Products(x)("ID"))
            DT_Temp = DataSource(SQL)
            Total_T = 0
            Branch1_T = 0
            B2_T = 0
            B3_T = 0
            B4_T = 0
            B5_T = 0
            B6_T = 0
            B7_T = 0
            B8_T = 0
            B9_T = 0
            B10_T = 0
            For y As Integer = 0 To DT_Temp.Rows.Count - 1
                Total_T += DT_Temp(y)("TOTAL")
                Branch1_T += DT_Temp(y)("1")
                B2_T += DT_Temp(y)("2")
                B3_T += DT_Temp(y)("3")
                B4_T += DT_Temp(y)("4")
                B5_T += DT_Temp(y)("5")
                B6_T += DT_Temp(y)("6")
                B7_T += DT_Temp(y)("7")
                B8_T += DT_Temp(y)("8")
                B9_T += DT_Temp(y)("9")
                B10_T += DT_Temp(y)("10")

                Total_G += DT_Temp(y)("TOTAL")
                Branch1_G += DT_Temp(y)("1")
                B2_G += DT_Temp(y)("2")
                B3_G += DT_Temp(y)("3")
                B4_G += DT_Temp(y)("4")
                B5_G += DT_Temp(y)("5")
                B6_G += DT_Temp(y)("6")
                B7_G += DT_Temp(y)("7")
                B8_G += DT_Temp(y)("8")
                B9_G += DT_Temp(y)("9")
                B10_G += DT_Temp(y)("10")
            Next
            DT_BusinessCenter.Rows.Add(-1, DT_Products(x)("ProductType"), DT_Products(x)("ProductTypeCode"), Total_T, Branch1_T, B2_T, B3_T, B4_T, B5_T, B6_T, B7_T, B8_T, B9_T, B10_T)
            For y As Integer = 0 To DT_Temp.Rows.Count - 1
                DT_BusinessCenter.Rows.Add(DT_Temp(y)("ID"), "              " & DT_Temp(y)("PRODUCT"), DT_Temp(y)("Code"), DT_Temp(y)("TOTAL"), DT_Temp(y)("1"), DT_Temp(y)("2"), DT_Temp(y)("3"), DT_Temp(y)("4"), DT_Temp(y)("5"), DT_Temp(y)("6"), DT_Temp(y)("7"), DT_Temp(y)("8"), DT_Temp(y)("9"), DT_Temp(y)("10"))
            Next
        Next
        DT_BusinessCenter.Rows.Add(0)
        DT_BusinessCenter.Rows.Add(0, "GRAND TOTAL", "", Total_G, Branch1_G, B2_G, B3_G, B4_G, B5_G, B6_G, B7_G, B8_G, B9_G, B10_G)

        GridControl3.DataSource = DT_BusinessCenter
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadSourceOfIncome()
        Cursor = Cursors.WaitCursor
        Dim SQL As String
        Dim Total_T As Double
        Dim Branch1_T As Double
        Dim B2_T As Double
        Dim B3_T As Double
        Dim B4_T As Double
        Dim B5_T As Double
        Dim B6_T As Double
        Dim B7_T As Double
        Dim B8_T As Double
        Dim B9_T As Double
        Dim B10_T As Double
        Dim B11_T As Double
        Dim B12_T As Double
        Dim B13_T As Double
        Dim B14_T As Double
        Dim B15_T As Double
        Dim B16_T As Double
        Dim B17_T As Double
        Dim B18_T As Double
        Dim B19_T As Double
        Dim B20_T As Double
        Dim B21_T As Double
        Dim B22_T As Double
        Dim B23_T As Double
        Dim B24_T As Double
        Dim B25_T As Double
        Dim B26_T As Double
        Dim B27_T As Double
        Dim B28_T As Double
        Dim B29_T As Double
        Dim B30_T As Double
        Dim Total_G As Double
        Dim Branch1_G As Double
        Dim B2_G As Double
        Dim B3_G As Double
        Dim B4_G As Double
        Dim B5_G As Double
        Dim B6_G As Double
        Dim B7_G As Double
        Dim B8_G As Double
        Dim B9_G As Double
        Dim B10_G As Double
        Dim B11_G As Double
        Dim B12_G As Double
        Dim B13_G As Double
        Dim B14_G As Double
        Dim B15_G As Double
        Dim B16_G As Double
        Dim B17_G As Double
        Dim B18_G As Double
        Dim B19_G As Double
        Dim B20_G As Double
        Dim B21_G As Double
        Dim B22_G As Double
        Dim B23_G As Double
        Dim B24_G As Double
        Dim B25_G As Double
        Dim B26_G As Double
        Dim B27_G As Double
        Dim B28_G As Double
        Dim B29_G As Double
        Dim B30_G As Double
        DT_SourceOfIncome.Rows.Clear()
        Dim DT_Temp As DataTable
        Dim DT_BC As DataTable = DataSource(String.Format("SELECT DISTINCT(I.Industry) AS 'Industry', Industry_ID FROM credit_application C INNER JOIN (SELECT CreditNumber, Industry, Industry_ID FROM credit_application_industry WHERE `status` = 'ACTIVE' AND `Type` = 'Borrower') I ON I.CreditNumber = C.CreditNumber WHERE `status` = 'ACTIVE' AND Employer_B = '' AND MONTH(Released) = MONTH('{0}') AND YEAR(Released) = YEAR('{0}') AND PaymentRequest IN ('RELEASED','CLOSED') AND IF({1} = 1,Branch_ID IN ({3}),Branch_ID = '{2}') AND IF('{4}' = 'True',TRUE,IF('{5}' = 0,Book(BankID) = '{6}',BankID = '{5}'));", Format(dtpPeriod.Value, "yyyy-MM-dd"), cbxAllB.Checked, cbxBranch.SelectedValue, Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook)))
        For x As Integer = 0 To DT_Products.Rows.Count - 1
            SQL = "SELECT P.ID, P.Product, P.Code, IFNULL(C.TOTAL,0) AS 'TOTAL', IFNULL(C.Employed,0) AS '1', IFNULL(C.`Self-Employed`,0) AS '2', IFNULL(C.`3`,0) AS '3', IFNULL(C.`4`,0) AS '4', IFNULL(C.`5`,0) AS '5', IFNULL(C.`6`,0) AS '6', IFNULL(C.`7`,0) AS '7', IFNULL(C.`8`,0) AS '8', IFNULL(C.`9`,0) AS '9', IFNULL(C.`10`,0) AS '10', IFNULL(C.`11`,0) AS '11', IFNULL(C.`12`,0) AS '12', IFNULL(C.`13`,0) AS '13', IFNULL(C.`14`,0) AS '14', IFNULL(C.`15`,0) AS '15', IFNULL(C.`16`,0) AS '16', IFNULL(C.`17`,0) AS '17', IFNULL(C.`18`,0) AS '18', IFNULL(C.`19`,0) AS '19', IFNULL(C.`20`,0) AS '20', IFNULL(C.`21`,0) AS '21', IFNULL(C.`22`,0) AS '22', IFNULL(C.`23`,0) AS '23', IFNULL(C.`24`,0) AS '24', IFNULL(C.`25`,0) AS '25', IFNULL(C.`26`,0) AS '26', IFNULL(C.`27`,0) AS '27', IFNULL(C.`28`,0) AS '28', IFNULL(C.`29`,0) AS '29', IFNULL(C.`30`,0) AS '30' FROM product_setup P LEFT JOIN (SELECT "
            SQL &= "  product_id AS 'ID',"
            SQL &= "  IFNULL(SUM(AmountApplied),0) AS 'TOTAL',"
            SQL &= "  IFNULL(SUM(CASE WHEN Employer_B != '' THEN AmountApplied END),0) AS 'Employed',"
            SQL &= "  IFNULL(SUM(CASE WHEN Employer_B = '' AND NatureBusiness_B = '' THEN AmountApplied END),0) AS 'Self-Employed',"
            For y As Integer = 0 To 28
                If DT_BC.Rows.Count - 1 >= y Then
                    SQL &= String.Format("  IFNULL(SUM(CASE WHEN Employer_B = '' AND Industry_ID = '{0}' THEN AmountApplied END),0) AS '{1}',", DT_BC(y)("Industry_ID"), y + 3)
                    If y = 0 Then
                        BandedGridColumn116.Caption = DT_BC(y)("Industry")
                    ElseIf y = 1 Then
                        BandedGridColumn117.Caption = DT_BC(y)("Industry")
                    ElseIf y = 2 Then
                        BandedGridColumn118.Caption = DT_BC(y)("Industry")
                    ElseIf y = 3 Then
                        BandedGridColumn119.Caption = DT_BC(y)("Industry")
                    ElseIf y = 4 Then
                        BandedGridColumn120.Caption = DT_BC(y)("Industry")
                    ElseIf y = 5 Then
                        BandedGridColumn121.Caption = DT_BC(y)("Industry")
                    ElseIf y = 6 Then
                        BandedGridColumn122.Caption = DT_BC(y)("Industry")
                    ElseIf y = 7 Then
                        BandedGridColumn123.Caption = DT_BC(y)("Industry")
                    ElseIf y = 8 Then
                        BandedGridColumn133.Caption = DT_BC(y)("Industry")
                    ElseIf y = 9 Then
                        BandedGridColumn132.Caption = DT_BC(y)("Industry")
                    ElseIf y = 10 Then
                        BandedGridColumn131.Caption = DT_BC(y)("Industry")
                    ElseIf y = 11 Then
                        BandedGridColumn130.Caption = DT_BC(y)("Industry")
                    ElseIf y = 12 Then
                        BandedGridColumn129.Caption = DT_BC(y)("Industry")
                    ElseIf y = 13 Then
                        BandedGridColumn128.Caption = DT_BC(y)("Industry")
                    ElseIf y = 14 Then
                        BandedGridColumn127.Caption = DT_BC(y)("Industry")
                    ElseIf y = 15 Then
                        BandedGridColumn126.Caption = DT_BC(y)("Industry")
                    ElseIf y = 16 Then
                        BandedGridColumn125.Caption = DT_BC(y)("Industry")
                    ElseIf y = 17 Then
                        BandedGridColumn134.Caption = DT_BC(y)("Industry")
                    ElseIf y = 18 Then
                        BandedGridColumn144.Caption = DT_BC(y)("Industry")
                    ElseIf y = 19 Then
                        BandedGridColumn143.Caption = DT_BC(y)("Industry")
                    ElseIf y = 20 Then
                        BandedGridColumn142.Caption = DT_BC(y)("Industry")
                    ElseIf y = 21 Then
                        BandedGridColumn141.Caption = DT_BC(y)("Industry")
                    ElseIf y = 22 Then
                        BandedGridColumn140.Caption = DT_BC(y)("Industry")
                    ElseIf y = 23 Then
                        BandedGridColumn139.Caption = DT_BC(y)("Industry")
                    ElseIf y = 24 Then
                        BandedGridColumn138.Caption = DT_BC(y)("Industry")
                    ElseIf y = 25 Then
                        BandedGridColumn137.Caption = DT_BC(y)("Industry")
                    ElseIf y = 26 Then
                        BandedGridColumn136.Caption = DT_BC(y)("Industry")
                    ElseIf y = 27 Then
                        BandedGridColumn135.Caption = DT_BC(y)("Industry")
                    End If
                Else
                    SQL &= String.Format("  0 AS '{0}',", y + 3)
                End If
            Next
            SQL = SQL.Substring(0, SQL.Length - 1)
            SQL &= String.Format("  FROM credit_application C LEFT JOIN (SELECT CreditNumber, Industry_ID, Industry FROM credit_application_industry WHERE `status` = 'ACTIVE' AND `Type` = 'Borrower' GROUP BY CreditNumber) I ON I.CreditNumber = C.CreditNumber WHERE `status` = 'ACTIVE' AND loan_type != 'RESTRUCTURE' AND MONTH(Released) = MONTH('{0}') AND YEAR(Released) = YEAR('{0}') AND PaymentRequest IN ('RELEASED','CLOSED') AND IF({1} = 1,Branch_ID IN ({3}),Branch_ID = '{2}') AND IF('{4}' = 'True',TRUE,IF('{5}' = 0,Book(BankID) = '{6}',BankID = '{5}')) GROUP BY product_id) C ON P.ID = C.ID WHERE Branch_ID = '{2}' AND Product_Type = '{7}';", Format(dtpPeriod.Value, "yyyy-MM-dd"), cbxAllB.Checked, cbxBranch.SelectedValue, Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook), DT_Products(x)("ID"))
            DT_Temp = DataSource(SQL)
            Total_T = 0
            Branch1_T = 0
            B2_T = 0
            B3_T = 0
            B4_T = 0
            B5_T = 0
            B6_T = 0
            B7_T = 0
            B8_T = 0
            B9_T = 0
            B10_T = 0
            B11_T = 0
            B12_T = 0
            B13_T = 0
            B14_T = 0
            B15_T = 0
            B16_T = 0
            B17_T = 0
            B18_T = 0
            B19_T = 0
            B20_T = 0
            B21_T = 0
            B22_T = 0
            B23_T = 0
            B24_T = 0
            B25_T = 0
            B26_T = 0
            B27_T = 0
            B28_T = 0
            B29_T = 0
            B30_T = 0
            For y As Integer = 0 To DT_Temp.Rows.Count - 1
                Total_T += DT_Temp(y)("TOTAL")
                Branch1_T += DT_Temp(y)("1")
                B2_T += DT_Temp(y)("2")
                B3_T += DT_Temp(y)("3")
                B4_T += DT_Temp(y)("4")
                B5_T += DT_Temp(y)("5")
                B6_T += DT_Temp(y)("6")
                B7_T += DT_Temp(y)("7")
                B8_T += DT_Temp(y)("8")
                B9_T += DT_Temp(y)("9")
                B10_T += DT_Temp(y)("10")
                B11_T += DT_Temp(y)("11")
                B12_T += DT_Temp(y)("12")
                B13_T += DT_Temp(y)("13")
                B14_T += DT_Temp(y)("14")
                B15_T += DT_Temp(y)("15")
                B16_T += DT_Temp(y)("16")
                B17_T += DT_Temp(y)("17")
                B18_T += DT_Temp(y)("18")
                B19_T += DT_Temp(y)("19")
                B20_T += DT_Temp(y)("20")
                B21_T += DT_Temp(y)("21")
                B22_T += DT_Temp(y)("22")
                B23_T += DT_Temp(y)("23")
                B24_T += DT_Temp(y)("24")
                B25_T += DT_Temp(y)("25")
                B26_T += DT_Temp(y)("26")
                B27_T += DT_Temp(y)("27")
                B28_T += DT_Temp(y)("28")
                B29_T += DT_Temp(y)("29")
                B30_T += DT_Temp(y)("30")

                Total_G += DT_Temp(y)("TOTAL")
                Branch1_G += DT_Temp(y)("1")
                B2_G += DT_Temp(y)("2")
                B3_G += DT_Temp(y)("3")
                B4_G += DT_Temp(y)("4")
                B5_G += DT_Temp(y)("5")
                B6_G += DT_Temp(y)("6")
                B7_G += DT_Temp(y)("7")
                B8_G += DT_Temp(y)("8")
                B9_G += DT_Temp(y)("9")
                B10_G += DT_Temp(y)("10")
                B11_G += DT_Temp(y)("11")
                B12_G += DT_Temp(y)("12")
                B13_G += DT_Temp(y)("13")
                B14_G += DT_Temp(y)("14")
                B15_G += DT_Temp(y)("15")
                B16_G += DT_Temp(y)("16")
                B17_G += DT_Temp(y)("17")
                B18_G += DT_Temp(y)("18")
                B19_G += DT_Temp(y)("19")
                B20_G += DT_Temp(y)("20")
                B21_G += DT_Temp(y)("21")
                B22_G += DT_Temp(y)("22")
                B23_G += DT_Temp(y)("23")
                B24_G += DT_Temp(y)("24")
                B25_G += DT_Temp(y)("25")
                B26_G += DT_Temp(y)("26")
                B27_G += DT_Temp(y)("27")
                B28_G += DT_Temp(y)("28")
                B29_G += DT_Temp(y)("29")
                B30_G += DT_Temp(y)("30")
            Next
            DT_SourceOfIncome.Rows.Add(-1, DT_Products(x)("ProductType"), DT_Products(x)("ProductTypeCode"), Total_T, Branch1_T, B2_T, B3_T, B4_T, B5_T, B6_T, B7_T, B8_T, B9_T, B10_T, B11_T, B12_T, B13_T, B14_T, B15_T, B16_T, B17_T, B18_T, B19_T, B20_T, B21_T, B22_T, B23_T, B24_T, B25_T, B26_T, B27_T, B28_T, B29_T, B30_T)
            For y As Integer = 0 To DT_Temp.Rows.Count - 1
                DT_SourceOfIncome.Rows.Add(DT_Temp(y)("ID"), "              " & DT_Temp(y)("PRODUCT"), DT_Temp(y)("Code"), DT_Temp(y)("TOTAL"), DT_Temp(y)("1"), DT_Temp(y)("2"), DT_Temp(y)("3"), DT_Temp(y)("4"), DT_Temp(y)("5"), DT_Temp(y)("6"), DT_Temp(y)("7"), DT_Temp(y)("8"), DT_Temp(y)("9"), DT_Temp(y)("10"), DT_Temp(y)("11"), DT_Temp(y)("12"), DT_Temp(y)("13"), DT_Temp(y)("14"), DT_Temp(y)("15"), DT_Temp(y)("16"), DT_Temp(y)("17"), DT_Temp(y)("18"), DT_Temp(y)("19"), DT_Temp(y)("20"), DT_Temp(y)("21"), DT_Temp(y)("22"), DT_Temp(y)("23"), DT_Temp(y)("24"), DT_Temp(y)("25"), DT_Temp(y)("26"), DT_Temp(y)("27"), DT_Temp(y)("28"), DT_Temp(y)("29"), DT_Temp(y)("30"))
            Next
        Next
        DT_SourceOfIncome.Rows.Add(0)
        DT_SourceOfIncome.Rows.Add(0, "GRAND TOTAL", "", Total_G, Branch1_G, B2_G, B3_G, B4_G, B5_G, B6_G, B7_G, B8_G, B9_G, B10_G, B11_G, B12_G, B13_G, B14_G, B15_G, B16_G, B17_G, B18_G, B19_G, B20_G, B21_G, B22_G, B23_G, B24_G, B25_G, B26_G, B27_G, B28_G, B29_G, B30_G)

        GridControl7.DataSource = DT_SourceOfIncome
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadBookingDetailed()
        Cursor = Cursors.WaitCursor
        Dim Principal As Double
        Dim UDI As Double
        Dim RPPD As Double
        Dim FA As Double
        Dim MonthlyAmort As Double
        Dim Rebate As Double
        Dim ProcessingFee As Double
        Dim ServiceCharge As Double
        Dim Insurance As Double
        Dim MiscellaneousIncome As Double
        Dim OtherFees As Double
        Dim AdvanceAmortization As Double
        Dim Interest As Double
        Dim DeductBalance As Double
        Dim NetProceeds As Double
        Dim Premium As Double
        Dim WithHoldingTax As Double
        Dim NetInsuranceCommission As Double
        DT_BookingDetailed = DataSource(String.Format("CALL BookingAndCollection_BookingDetailed('{0}',{1},{2},'{3}',{4},{5},{6})", Format(dtpPeriod.Value, "yyyy-MM-dd"), cbxAllB.Checked, cbxBranch.SelectedValue, Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook)))
        DT_BookingDetailedPrint = DT_BookingDetailed.Copy
        GridControl4.DataSource = DT_BookingDetailed
        For x As Integer = 1 To BandedGridView4.RowCount
            DT_BookingDetailedPrint(x - 1)("NO.") = x
            BandedGridView4.SetRowCellValue(x - 1, "NO.", x)
            Principal += DT_BookingDetailed(x - 1)("PRINCIPAL")
            UDI += DT_BookingDetailed(x - 1)("UDI")
            RPPD += DT_BookingDetailed(x - 1)("RPPD")
            FA += DT_BookingDetailed(x - 1)("FA")
            MonthlyAmort += DT_BookingDetailed(x - 1)("MONTHLY AMORT.")
            Rebate += DT_BookingDetailed(x - 1)("REBATE")
            ProcessingFee += DT_BookingDetailed(x - 1)("PROCESSING FEE")
            ServiceCharge += DT_BookingDetailed(x - 1)("SERVICE CHARGE")
            Insurance += DT_BookingDetailed(x - 1)("INSURANCE")
            MiscellaneousIncome += DT_BookingDetailed(x - 1)("MISCELLANEOUS INCOME")
            OtherFees += DT_BookingDetailed(x - 1)("OTHER FEES")
            AdvanceAmortization += DT_BookingDetailed(x - 1)("ADVANCE AMORTIZATION")
            Interest += DT_BookingDetailed(x - 1)("INTEREST")
            DeductBalance += DT_BookingDetailed(x - 1)("DEDUCT BALANCE")
            NetProceeds += DT_BookingDetailed(x - 1)("NET PROCEEDS")
            Premium += If(IsNumeric(DT_BookingDetailed(x - 1)("PREMIUM")), DT_BookingDetailed(x - 1)("PREMIUM"), 0)
            WithHoldingTax += If(IsNumeric(DT_BookingDetailed(x - 1)("WITHHOLDING TAX")), DT_BookingDetailed(x - 1)("WITHHOLDING TAX"), 0)
            NetInsuranceCommission += If(IsNumeric(DT_BookingDetailed(x - 1)("NET INSURANCE COMMISSION")), DT_BookingDetailed(x - 1)("NET INSURANCE COMMISSION"), 0)
        Next

        DT_BookingDetailed.Rows.Add(0)
        DT_BookingDetailed.Rows.Add(0, "", "TOTAL", 0, "", "", Principal, UDI, RPPD, FA, "", 0, MonthlyAmort, Rebate, ProcessingFee, ServiceCharge, Insurance, MiscellaneousIncome, OtherFees, AdvanceAmortization, Interest, DeductBalance, NetProceeds, "", "", "", "", "", "", "", "", Premium, WithHoldingTax, NetInsuranceCommission, 0, "")

        Cursor = Cursors.Default
    End Sub

    Private Sub LoadCollectionSummary()
        Cursor = Cursors.WaitCursor
        Dim B1_T As Double
        Dim B2_T As Double
        Dim B3_T As Double
        Dim B4_T As Double
        Dim B5_T As Double
        Dim Total_T As Double
        Dim B1_G As Double
        Dim B2_G As Double
        Dim B3_G As Double
        Dim B4_G As Double
        Dim B5_G As Double
        Dim Total_G As Double
        Dim DT_Temp As DataTable
        Dim DT_Add As DataTable
        Dim DT_Less As DataTable
        DT_CollectionSummary.Rows.Clear()
        For x As Integer = 0 To DT_Products.Rows.Count - 1
            DT_Temp = DataSource(String.Format("CALL BookingAndCollection_CollectionSummary('{0}',{1},{2},'{3}',{4},{5},{6},{7})", Format(dtpPeriod.Value, "yyyy-MM-dd"), cbxAllB.Checked, cbxBranch.SelectedValue, Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook), DT_Products(x)("ID")))
            B1_T = 0
            B2_T = 0
            B3_T = 0
            B4_T = 0
            B5_T = 0
            Total_T = 0
            For y As Integer = 0 To DT_Temp.Rows.Count - 1
                B1_T += DT_Temp(y)("1")
                B2_T += DT_Temp(y)("2")
                B3_T += DT_Temp(y)("3")
                B4_T += DT_Temp(y)("4")
                B5_T += DT_Temp(y)("5")
                Total_T += DT_Temp(y)("TOTAL")
                B1_G += DT_Temp(y)("1")
                B2_G += DT_Temp(y)("2")
                B3_G += DT_Temp(y)("3")
                B4_G += DT_Temp(y)("4")
                B5_G += DT_Temp(y)("5")
                Total_G += DT_Temp(y)("TOTAL")
            Next

            '**** ADD DEDUCT BALANCE **************************************************************************************************
            DT_Add = DataSource(String.Format("CALL BookingAndCollection_CollectionSummaryAdd('{0}',{1},{2},'{3}',{4},{5},{6},{7})", Format(dtpPeriod.Value, "yyyy-MM-dd"), cbxAllB.Checked, cbxBranch.SelectedValue, Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook), DT_Products(x)("ID")))
            If DT_Add.Rows.Count > 0 Then
                B1_T += DT_Add(0)("1")
                B2_T += DT_Add(0)("2")
                B3_T += DT_Add(0)("3")
                B4_T += DT_Add(0)("4")
                B5_T += DT_Add(0)("5")
                Total_T += DT_Add(0)("TOTAL")
                B1_G += DT_Add(0)("1")
                B2_G += DT_Add(0)("2")
                B3_G += DT_Add(0)("3")
                B4_G += DT_Add(0)("4")
                B5_G += DT_Add(0)("5")
                Total_G += DT_Add(0)("TOTAL")
            End If

            '**** LESS RETURNED **************************************************************************************************
            DT_Less = DataSource(String.Format("CALL BookingAndCollection_CollectionSummaryLess('{0}',{1},{2},'{3}',{4},{5},{6},{7})", Format(dtpPeriod.Value, "yyyy-MM-dd"), cbxAllB.Checked, cbxBranch.SelectedValue, Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook), DT_Products(x)("ID")))
            If DT_Less.Rows.Count > 0 Then
                B1_T -= DT_Less(0)("1")
                B2_T -= DT_Less(0)("2")
                B3_T -= DT_Less(0)("3")
                B4_T -= DT_Less(0)("4")
                B5_T -= DT_Less(0)("5")
                Total_T -= DT_Less(0)("TOTAL")
                B1_G -= DT_Less(0)("1")
                B2_G -= DT_Less(0)("2")
                B3_G -= DT_Less(0)("3")
                B4_G -= DT_Less(0)("4")
                B5_G -= DT_Less(0)("5")
                Total_G -= DT_Less(0)("TOTAL")
            End If

            DT_CollectionSummary.Rows.Add(-1, DT_Products(x)("ProductType"), DT_Products(x)("ProductTypeCode"), B1_T, B2_T, B3_T, B4_T, B5_T, Total_T)
            For y As Integer = 0 To DT_Temp.Rows.Count - 1
                DT_CollectionSummary.Rows.Add(DT_Temp(y)("ID"), "              " & DT_Temp(y)("PRODUCT"), DT_Temp(y)("Code"), DT_Temp(y)("1"), DT_Temp(y)("2"), DT_Temp(y)("3"), DT_Temp(y)("4"), DT_Temp(y)("5"), DT_Temp(y)("TOTAL"))
            Next
            If DT_Add.Rows.Count > 0 Then
                DT_CollectionSummary.Rows.Add(-2, "              ADD:DEDUCT BALANCE", "", DT_Add(0)("1"), DT_Add(0)("2"), DT_Add(0)("3"), DT_Add(0)("4"), DT_Add(0)("5"), DT_Add(0)("TOTAL"))
            Else
                DT_CollectionSummary.Rows.Add(-2, "              ADD:DEDUCT BALANCE")
            End If
            If DT_Less.Rows.Count > 0 Then
                DT_CollectionSummary.Rows.Add(-3, "              LESS:RETURNED CHECKS/(ADJ)", "", DT_Less(0)("1"), DT_Less(0)("2"), DT_Less(0)("3"), DT_Less(0)("4"), DT_Less(0)("5"), DT_Less(0)("TOTAL"))
            Else
                DT_CollectionSummary.Rows.Add(-3, "              LESS:RETURNED CHECKS/(ADJ)")
            End If
        Next
        DT_CollectionSummary.Rows.Add(0)
        DT_CollectionSummary.Rows.Add(0, "GRAND TOTAL", "", B1_G, B2_G, B3_G, B4_G, B5_G, Total_G)

        GridControl5.DataSource = DT_CollectionSummary
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadCollectionDetailed()
        Cursor = Cursors.WaitCursor
        Dim Receivable_1 As Double
        Dim Current_1 As Double
        Dim PastDue_1 As Double
        Dim Others_1 As Double
        Dim Receivable_2 As Double
        Dim Current_2 As Double
        Dim PastDue_2 As Double
        Dim Others_2 As Double
        Dim Receivable_3 As Double
        Dim Current_3 As Double
        Dim PastDue_3 As Double
        Dim Others_3 As Double
        Dim Receivable_4 As Double
        Dim Current_4 As Double
        Dim PastDue_4 As Double
        Dim Others_4 As Double
        Dim Receivable_5 As Double
        Dim Current_5 As Double
        Dim PastDue_5 As Double
        Dim Others_5 As Double

        Dim Receivable_1G As Double
        Dim Current_1G As Double
        Dim PastDue_1G As Double
        Dim Others_1G As Double
        Dim Receivable_2G As Double
        Dim Current_2G As Double
        Dim PastDue_2G As Double
        Dim Others_2G As Double
        Dim Receivable_3G As Double
        Dim Current_3G As Double
        Dim PastDue_3G As Double
        Dim Others_3G As Double
        Dim Receivable_4G As Double
        Dim Current_4G As Double
        Dim PastDue_4G As Double
        Dim Others_4G As Double
        Dim Receivable_5G As Double
        Dim Current_5G As Double
        Dim PastDue_5G As Double
        Dim Others_5G As Double
        Dim DT_Temp As DataTable
        Dim DT_Add As DataTable
        Dim DT_Less As DataTable
        DT_CollectionDetailed.Rows.Clear()
        For x As Integer = 0 To DT_Products.Rows.Count - 1
            DT_Temp = DataSource(String.Format("CALL BookingAndCollection_CollectionDetailed('{0}',{1},{2},'{3}',{4},{5},{6},{7})", Format(dtpPeriod.Value, "yyyy-MM-dd"), cbxAllB.Checked, cbxBranch.SelectedValue, Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook), DT_Products(x)("ID")))
            Receivable_1 = 0
            Current_1 = 0
            PastDue_1 = 0
            Others_1 = 0
            Receivable_2 = 0
            Current_2 = 0
            PastDue_2 = 0
            Others_2 = 0
            Receivable_3 = 0
            Current_3 = 0
            PastDue_3 = 0
            Others_3 = 0
            Receivable_4 = 0
            Current_4 = 0
            PastDue_4 = 0
            Others_4 = 0
            Receivable_5 = 0
            Current_5 = 0
            PastDue_5 = 0
            Others_5 = 0
            For y As Integer = Receivable_1 To DT_Temp.Rows.Count - 1
                Receivable_1 += DT_Temp(y)("Loans Receivable_1")
                Current_1 += DT_Temp(y)("Interest Income-Current_1")
                PastDue_1 += DT_Temp(y)("Interest Income-Past Due_1")
                Others_1 += DT_Temp(y)("Others_1")
                Receivable_2 += DT_Temp(y)("Loans Receivable_2")
                Current_2 += DT_Temp(y)("Interest Income-Current_2")
                PastDue_2 += DT_Temp(y)("Interest Income-Past Due_2")
                Others_2 += DT_Temp(y)("Others_2")
                Receivable_3 += DT_Temp(y)("Loans Receivable_3")
                Current_3 += DT_Temp(y)("Interest Income-Current_3")
                PastDue_3 += DT_Temp(y)("Interest Income-Past Due_3")
                Others_3 += DT_Temp(y)("Others_3")
                Receivable_4 += DT_Temp(y)("Loans Receivable_4")
                Current_4 += DT_Temp(y)("Interest Income-Current_4")
                PastDue_4 += DT_Temp(y)("Interest Income-Past Due_4")
                Others_4 += DT_Temp(y)("Others_4")
                Receivable_5 += DT_Temp(y)("Loans Receivable_5")
                Current_5 += DT_Temp(y)("Interest Income-Current_5")
                PastDue_5 += DT_Temp(y)("Interest Income-Past Due_5")
                Others_5 += DT_Temp(y)("Others_5")

                Receivable_1G += DT_Temp(y)("Loans Receivable_1")
                Current_1G += DT_Temp(y)("Interest Income-Current_1")
                PastDue_1G += DT_Temp(y)("Interest Income-Past Due_1")
                Others_1G += DT_Temp(y)("Others_1")
                Receivable_2G += DT_Temp(y)("Loans Receivable_2")
                Current_2G += DT_Temp(y)("Interest Income-Current_2")
                PastDue_2G += DT_Temp(y)("Interest Income-Past Due_2")
                Others_2G += DT_Temp(y)("Others_2")
                Receivable_3G += DT_Temp(y)("Loans Receivable_3")
                Current_3G += DT_Temp(y)("Interest Income-Current_3")
                PastDue_3G += DT_Temp(y)("Interest Income-Past Due_3")
                Others_3G += DT_Temp(y)("Others_3")
                Receivable_4G += DT_Temp(y)("Loans Receivable_4")
                Current_4G += DT_Temp(y)("Interest Income-Current_4")
                PastDue_4G += DT_Temp(y)("Interest Income-Past Due_4")
                Others_4G += DT_Temp(y)("Others_4")
                Receivable_5G += DT_Temp(y)("Loans Receivable_5")
                Current_5G += DT_Temp(y)("Interest Income-Current_5")
                PastDue_5G += DT_Temp(y)("Interest Income-Past Due_5")
                Others_5G += DT_Temp(y)("Others_5")
            Next

            '**** ADD DEDUCT BALANCE **************************************************************************************************
            DT_Add = DataSource(String.Format("CALL BookingAndCollection_CollectionDetailedAdd('{0}',{1},{2},'{3}',{4},{5},{6},{7})", Format(dtpPeriod.Value, "yyyy-MM-dd"), cbxAllB.Checked, cbxBranch.SelectedValue, Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook), DT_Products(x)("ID")))
            If DT_Add.Rows.Count > 0 Then
                Receivable_1 += DT_Add(0)("Loans Receivable_1")
                Current_1 += DT_Add(0)("Interest Income-Current_1")
                PastDue_1 += DT_Add(0)("Interest Income-Past Due_1")
                Others_1 += DT_Add(0)("Others_1")
                Receivable_2 += DT_Add(0)("Loans Receivable_2")
                Current_2 += DT_Add(0)("Interest Income-Current_2")
                PastDue_2 += DT_Add(0)("Interest Income-Past Due_2")
                Others_2 += DT_Add(0)("Others_2")
                Receivable_3 += DT_Add(0)("Loans Receivable_3")
                Current_3 += DT_Add(0)("Interest Income-Current_3")
                PastDue_3 += DT_Add(0)("Interest Income-Past Due_3")
                Others_3 += DT_Add(0)("Others_3")
                Receivable_4 += DT_Add(0)("Loans Receivable_4")
                Current_4 += DT_Add(0)("Interest Income-Current_4")
                PastDue_4 += DT_Add(0)("Interest Income-Past Due_4")
                Others_4 += DT_Add(0)("Others_4")
                Receivable_5 += DT_Add(0)("Loans Receivable_5")
                Current_5 += DT_Add(0)("Interest Income-Current_5")
                PastDue_5 += DT_Add(0)("Interest Income-Past Due_5")
                Others_5 += DT_Add(0)("Others_5")

                Receivable_1G += DT_Add(0)("Loans Receivable_1")
                Current_1G += DT_Add(0)("Interest Income-Current_1")
                PastDue_1G += DT_Add(0)("Interest Income-Past Due_1")
                Others_1G += DT_Add(0)("Others_1")
                Receivable_2G += DT_Add(0)("Loans Receivable_2")
                Current_2G += DT_Add(0)("Interest Income-Current_2")
                PastDue_2G += DT_Add(0)("Interest Income-Past Due_2")
                Others_2G += DT_Add(0)("Others_2")
                Receivable_3G += DT_Add(0)("Loans Receivable_3")
                Current_3G += DT_Add(0)("Interest Income-Current_3")
                PastDue_3G += DT_Add(0)("Interest Income-Past Due_3")
                Others_3G += DT_Add(0)("Others_3")
                Receivable_4G += DT_Add(0)("Loans Receivable_4")
                Current_4G += DT_Add(0)("Interest Income-Current_4")
                PastDue_4G += DT_Add(0)("Interest Income-Past Due_4")
                Others_4G += DT_Add(0)("Others_4")
                Receivable_5G += DT_Add(0)("Loans Receivable_5")
                Current_5G += DT_Add(0)("Interest Income-Current_5")
                PastDue_5G += DT_Add(0)("Interest Income-Past Due_5")
                Others_5G += DT_Add(0)("Others_5")
            End If

            '**** LESS RETURNED **************************************************************************************************
            DT_Less = DataSource(String.Format("CALL BookingAndCollection_CollectionDetailedLess('{0}',{1},{2},'{3}',{4},{5},{6},{7})", Format(dtpPeriod.Value, "yyyy-MM-dd"), cbxAllB.Checked, cbxBranch.SelectedValue, Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook), DT_Products(x)("ID")))
            If DT_Less.Rows.Count > 0 Then
                Receivable_1 -= DT_Less(0)("Loans Receivable_1")
                Current_1 -= DT_Less(0)("Interest Income-Current_1")
                PastDue_1 -= DT_Less(0)("Interest Income-Past Due_1")
                Others_1 -= DT_Less(0)("Others_1")
                Receivable_2 -= DT_Less(0)("Loans Receivable_2")
                Current_2 -= DT_Less(0)("Interest Income-Current_2")
                PastDue_2 -= DT_Less(0)("Interest Income-Past Due_2")
                Others_2 -= DT_Less(0)("Others_2")
                Receivable_3 -= DT_Less(0)("Loans Receivable_3")
                Current_3 -= DT_Less(0)("Interest Income-Current_3")
                PastDue_3 -= DT_Less(0)("Interest Income-Past Due_3")
                Others_3 -= DT_Less(0)("Others_3")
                Receivable_4 -= DT_Less(0)("Loans Receivable_4")
                Current_4 -= DT_Less(0)("Interest Income-Current_4")
                PastDue_4 -= DT_Less(0)("Interest Income-Past Due_4")
                Others_4 -= DT_Less(0)("Others_4")
                Receivable_5 -= DT_Less(0)("Loans Receivable_5")
                Current_5 -= DT_Less(0)("Interest Income-Current_5")
                PastDue_5 -= DT_Less(0)("Interest Income-Past Due_5")
                Others_5 -= DT_Less(0)("Others_5")

                Receivable_1G -= DT_Less(0)("Loans Receivable_1")
                Current_1G -= DT_Less(0)("Interest Income-Current_1")
                PastDue_1G -= DT_Less(0)("Interest Income-Past Due_1")
                Others_1G -= DT_Less(0)("Others_1")
                Receivable_2G -= DT_Less(0)("Loans Receivable_2")
                Current_2G -= DT_Less(0)("Interest Income-Current_2")
                PastDue_2G -= DT_Less(0)("Interest Income-Past Due_2")
                Others_2G -= DT_Less(0)("Others_2")
                Receivable_3G -= DT_Less(0)("Loans Receivable_3")
                Current_3G -= DT_Less(0)("Interest Income-Current_3")
                PastDue_3G -= DT_Less(0)("Interest Income-Past Due_3")
                Others_3G -= DT_Less(0)("Others_3")
                Receivable_4G -= DT_Less(0)("Loans Receivable_4")
                Current_4G -= DT_Less(0)("Interest Income-Current_4")
                PastDue_4G -= DT_Less(0)("Interest Income-Past Due_4")
                Others_4G -= DT_Less(0)("Others_4")
                Receivable_5G -= DT_Less(0)("Loans Receivable_5")
                Current_5G -= DT_Less(0)("Interest Income-Current_5")
                PastDue_5G -= DT_Less(0)("Interest Income-Past Due_5")
                Others_5G -= DT_Less(0)("Others_5")
            End If

            DT_CollectionDetailed.Rows.Add(-1, DT_Products(x)("ProductType"), DT_Products(x)("ProductTypeCode"), Receivable_1, Current_1, PastDue_1, Others_1, Receivable_2, Current_2, PastDue_2, Others_2, Receivable_3, Current_3, PastDue_3, Others_3, Receivable_4, Current_4, PastDue_4, Others_4, Receivable_5, Current_5, PastDue_5, Others_5)
            For y As Integer = 0 To DT_Temp.Rows.Count - 1
                DT_CollectionDetailed.Rows.Add(DT_Temp(y)("ID"), "              " & DT_Temp(y)("PRODUCT"), DT_Temp(y)("Code"), DT_Temp(y)("Loans Receivable_1"), DT_Temp(y)("Interest Income-Current_1"), DT_Temp(y)("Interest Income-Past Due_1"), DT_Temp(y)("Others_1"), DT_Temp(y)("Loans Receivable_2"), DT_Temp(y)("Interest Income-Current_2"), DT_Temp(y)("Interest Income-Past Due_2"), DT_Temp(y)("Others_2"), DT_Temp(y)("Loans Receivable_3"), DT_Temp(y)("Interest Income-Current_3"), DT_Temp(y)("Interest Income-Past Due_3"), DT_Temp(y)("Others_3"), DT_Temp(y)("Loans Receivable_4"), DT_Temp(y)("Interest Income-Current_4"), DT_Temp(y)("Interest Income-Past Due_4"), DT_Temp(y)("Others_4"), DT_Temp(y)("Loans Receivable_5"), DT_Temp(y)("Interest Income-Current_5"), DT_Temp(y)("Interest Income-Past Due_5"), DT_Temp(y)("Others_5"))
            Next
            If DT_Add.Rows.Count > 0 Then
                DT_CollectionDetailed.Rows.Add(-2, "              ADD:DEDUCT BALANCE", "", DT_Add(0)("Loans Receivable_1"), DT_Add(0)("Interest Income-Current_1"), DT_Add(0)("Interest Income-Past Due_1"), DT_Add(0)("Others_1"), DT_Add(0)("Loans Receivable_2"), DT_Add(0)("Interest Income-Current_2"), DT_Add(0)("Interest Income-Past Due_2"), DT_Add(0)("Others_2"), DT_Add(0)("Loans Receivable_3"), DT_Add(0)("Interest Income-Current_3"), DT_Add(0)("Interest Income-Past Due_3"), DT_Add(0)("Others_3"), DT_Add(0)("Loans Receivable_4"), DT_Add(0)("Interest Income-Current_4"), DT_Add(0)("Interest Income-Past Due_4"), DT_Add(0)("Others_4"), DT_Add(0)("Loans Receivable_5"), DT_Add(0)("Interest Income-Current_5"), DT_Add(0)("Interest Income-Past Due_5"), DT_Add(0)("Others_5"))
            Else
                DT_CollectionDetailed.Rows.Add(-2, "              ADD:DEDUCT BALANCE")
            End If
            If DT_Less.Rows.Count > 0 Then
                DT_CollectionDetailed.Rows.Add(-3, "              LESS:RETURNED CHECKS/(ADJ)", "", DT_Less(0)("Loans Receivable_1"), DT_Less(0)("Interest Income-Current_1"), DT_Less(0)("Interest Income-Past Due_1"), DT_Less(0)("Others_1"), DT_Less(0)("Loans Receivable_2"), DT_Less(0)("Interest Income-Current_2"), DT_Less(0)("Interest Income-Past Due_2"), DT_Less(0)("Others_2"), DT_Less(0)("Loans Receivable_3"), DT_Less(0)("Interest Income-Current_3"), DT_Less(0)("Interest Income-Past Due_3"), DT_Less(0)("Others_3"), DT_Less(0)("Loans Receivable_4"), DT_Less(0)("Interest Income-Current_4"), DT_Less(0)("Interest Income-Past Due_4"), DT_Less(0)("Others_4"), DT_Less(0)("Loans Receivable_5"), DT_Less(0)("Interest Income-Current_5"), DT_Less(0)("Interest Income-Past Due_5"), DT_Less(0)("Others_5"))
            Else
                DT_CollectionDetailed.Rows.Add(-3, "              LESS:RETURNED CHECKS/(ADJ)")
            End If
        Next
        DT_CollectionDetailed.Rows.Add(0)
        DT_CollectionDetailed.Rows.Add(0, "GRAND TOTAL", "", Receivable_1G, Current_1G, PastDue_1G, Others_1G, Receivable_2G, Current_2G, PastDue_2G, Others_2G, Receivable_3G, Current_3G, PastDue_3G, Others_3G, Receivable_4G, Current_4G, PastDue_4G, Others_4G, Receivable_5G, Current_5G, PastDue_5G, Others_5G)

        GridControl6.DataSource = DT_CollectionDetailed
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
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
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

    Private Sub CbxAllB_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAllB.CheckedChanged
        If cbxAllB.Checked Then
            cbxBranch.Enabled = False
            cbxBranch.SelectedIndex = -1
        Else
            cbxBranch.Enabled = True
            cbxBranch.SelectedValue = Branch_ID
        End If
    End Sub

    Private Sub BandedGridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BandedGridView1.RowCellStyle
        If BandedGridView1.RowCount > 0 Then
            Try
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim ForBold As Integer = View.GetRowCellValue(e.RowHandle, View.Columns("ID"))
                If ForBold > 0 Then
                    e.Appearance.Font = New Font(OfficialFont, CSng(6.75), FontStyle.Regular)
                Else
                    e.Appearance.Font = New Font(OfficialFont, CSng(6.75), FontStyle.Bold)
                    If ForBold = -1 Then
                        e.Appearance.BackColor = Color.LightCoral
                    ElseIf ForBold = -2 Then
                        e.Appearance.BackColor = Color.PaleGoldenrod
                    ElseIf ForBold = -3 Then
                        e.Appearance.ForeColor = OfficialColor2 'Color.Red
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BandedGridView2_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BandedGridView2.RowCellStyle
        If BandedGridView2.RowCount > 0 Then
            Try
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim ForBold As Integer = View.GetRowCellValue(e.RowHandle, View.Columns("ID"))
                If ForBold > 0 Then
                    e.Appearance.Font = New Font(OfficialFont, 6.75, FontStyle.Regular)
                Else
                    e.Appearance.Font = New Font(OfficialFont, 6.75, FontStyle.Bold)
                    If ForBold = -1 Then
                        e.Appearance.BackColor = Color.LightCoral
                    ElseIf ForBold = -2 Then
                        e.Appearance.BackColor = Color.PaleGoldenrod
                    ElseIf ForBold = -3 Then
                        e.Appearance.ForeColor = OfficialColor2 'Color.Red
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BandedGridView3_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BandedGridView3.RowCellStyle
        If BandedGridView3.RowCount > 0 Then
            Try
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim ForBold As Integer = View.GetRowCellValue(e.RowHandle, View.Columns("ID"))
                If ForBold > 0 Then
                    e.Appearance.Font = New Font(OfficialFont, 6.75, FontStyle.Regular)
                Else
                    e.Appearance.Font = New Font(OfficialFont, 6.75, FontStyle.Bold)
                    If ForBold = -1 Then
                        e.Appearance.BackColor = Color.LightCoral
                    ElseIf ForBold = -2 Then
                        e.Appearance.BackColor = Color.PaleGoldenrod
                    ElseIf ForBold = -3 Then
                        e.Appearance.ForeColor = OfficialColor2 'Color.Red
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BandedGridView7_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BandedGridView7.RowCellStyle
        If BandedGridView7.RowCount > 0 Then
            Try
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim ForBold As Integer = View.GetRowCellValue(e.RowHandle, View.Columns("ID"))
                If ForBold > 0 Then
                    e.Appearance.Font = New Font(OfficialFont, 6.75, FontStyle.Regular)
                Else
                    e.Appearance.Font = New Font(OfficialFont, 6.75, FontStyle.Bold)
                    If ForBold = -1 Then
                        e.Appearance.BackColor = Color.LightCoral
                    ElseIf ForBold = -2 Then
                        e.Appearance.BackColor = Color.PaleGoldenrod
                    ElseIf ForBold = -3 Then
                        e.Appearance.ForeColor = OfficialColor2 'Color.Red
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BandedGridView4_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BandedGridView4.RowCellStyle
        If BandedGridView5.RowCount > 0 Then
            Try
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim ForBold As Integer = View.GetRowCellValue(e.RowHandle, View.Columns("NO."))
                If ForBold > 0 Then
                    e.Appearance.Font = New Font(OfficialFont, 6.75, FontStyle.Regular)
                Else
                    e.Appearance.Font = New Font(OfficialFont, 6.75, FontStyle.Bold)
                    'If ForBold = -1 Then
                    '    e.Appearance.BackColor = Color.LightCoral
                    'ElseIf ForBold = -2 Then
                    '    e.Appearance.BackColor = Color.PaleGoldenrod
                    'ElseIf ForBold = -3 Then
                    '    e.Appearance.ForeColor = OfficialColor2 'Color.Red
                    'End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BandedGridView5_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BandedGridView5.RowCellStyle
        If BandedGridView5.RowCount > 0 Then
            Try
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim ForBold As Integer = View.GetRowCellValue(e.RowHandle, View.Columns("ID"))
                If ForBold > 0 Then
                    e.Appearance.Font = New Font(OfficialFont, 6.75, FontStyle.Regular)
                Else
                    e.Appearance.Font = New Font(OfficialFont, 6.75, FontStyle.Bold)
                    If ForBold = -1 Then
                        e.Appearance.BackColor = Color.LightCoral
                    ElseIf ForBold = -2 Then
                        e.Appearance.BackColor = Color.PaleGoldenrod
                    ElseIf ForBold = -3 Then
                        e.Appearance.ForeColor = OfficialColor2 'Color.Red
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BandedGridView6_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BandedGridView6.RowCellStyle
        If BandedGridView6.RowCount > 0 Then
            Try
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim ForBold As Integer = View.GetRowCellValue(e.RowHandle, View.Columns("ID"))
                If ForBold > 0 Then
                    e.Appearance.Font = New Font(OfficialFont, 6.75, FontStyle.Regular)
                Else
                    e.Appearance.Font = New Font(OfficialFont, 6.75, FontStyle.Bold)
                    If ForBold = -1 Then
                        e.Appearance.BackColor = Color.LightCoral
                    ElseIf ForBold = -2 Then
                        e.Appearance.BackColor = Color.PaleGoldenrod
                    ElseIf ForBold = -3 Then
                        e.Appearance.ForeColor = OfficialColor2 'Color.Red
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BtnPrintCustomized_Click(sender As Object, e As EventArgs) Handles btnPrintCustomized.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If SuperTabControl1.SelectedTabIndex = 0 Then
            BandedGridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("Booking Summary", GridControl1)
            Logs("Booking and Collection", "Print", "[SENSITIVE] Print Booking Summary", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            BandedGridView2.OptionsPrint.UsePrintStyles = False
            StandardPrinting("Client Type", GridControl2)
            Logs("Booking and Collection", "Print", "[SENSITIVE] Print Client Type", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            BandedGridView3.OptionsPrint.UsePrintStyles = False
            StandardPrinting("Business Center", GridControl3)
            Logs("Booking and Collection", "Print", "[SENSITIVE] Print Business Center", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            BandedGridView7.OptionsPrint.UsePrintStyles = False
            StandardPrinting("Source of Income", GridControl7)
            Logs("Booking and Collection", "Print", "[SENSITIVE] Print Source of Income", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            BandedGridView4.OptionsPrint.UsePrintStyles = False
            StandardPrinting("Booking Detailed", GridControl4)
            Logs("Booking and Collection", "Print", "[SENSITIVE] Print Booking Detailed", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
            BandedGridView5.OptionsPrint.UsePrintStyles = False
            StandardPrinting("Collection Summary", GridControl5)
            Logs("Booking and Collection", "Print", "[SENSITIVE] Print Collection Summary", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 6 Then
            BandedGridView6.OptionsPrint.UsePrintStyles = False
            StandardPrinting("Collection Detailed", GridControl6)
            Logs("Booking and Collection", "Print", "[SENSITIVE] Print Collection Detailed", "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim BookingSummary As New Rpt1BookingSummary
        With BookingSummary
            .Name = "Booking and Collection"
            .DataSource = GridControl1.DataSource
            .lblID.DataBindings.Add("Tag", GridControl1.DataSource, "ID")
            .lblProduct.DataBindings.Add("Text", GridControl1.DataSource, "PRODUCT")
            .lblProductCode.DataBindings.Add("Text", GridControl1.DataSource, "Product Code")
            .lblWeek1.DataBindings.Add("Text", GridControl1.DataSource, "1")
            .lblWeek2.DataBindings.Add("Text", GridControl1.DataSource, "2")
            .lblWeek3.DataBindings.Add("Text", GridControl1.DataSource, "3")
            .lblWeek4.DataBindings.Add("Text", GridControl1.DataSource, "4")
            .lblWeek5.DataBindings.Add("Text", GridControl1.DataSource, "5")
            .lblWeekT.DataBindings.Add("Text", GridControl1.DataSource, "TOTAL")
            .lblWeekP.DataBindings.Add("Text", GridControl1.DataSource, "%")
            .lblProcessing.DataBindings.Add("Text", GridControl1.DataSource, "Processing Fee")
            .lblService.DataBindings.Add("Text", GridControl1.DataSource, "Service Charge")
            .lblInsurance.DataBindings.Add("Text", GridControl1.DataSource, "Insurance")
            .lblMiscellaneous.DataBindings.Add("Text", GridControl1.DataSource, "Miscellaneous")
            .CreateDocument()
        End With

        Dim ClientType As New Rpt2ClientType
        With ClientType
            .Name = "Client Type"
            .DataSource = GridControl2.DataSource
            .lblProduct.DataBindings.Add("Tag", GridControl2.DataSource, "ID")
            .lblProduct.DataBindings.Add("Text", GridControl2.DataSource, "PRODUCT")
            .lblProductCode.DataBindings.Add("Text", GridControl2.DataSource, "Product Code")
            .lblNew.DataBindings.Add("Text", GridControl2.DataSource, "NEW")
            .lblRepeat.DataBindings.Add("Text", GridControl2.DataSource, "REPEAT")
            .lblTotal.DataBindings.Add("Text", GridControl2.DataSource, "TOTAL")
            .lblNewP.DataBindings.Add("Text", GridControl2.DataSource, "% NEW")
            .lblRepeatP.DataBindings.Add("Text", GridControl2.DataSource, "% REPEAT")
            .lblTotalP.DataBindings.Add("Text", GridControl2.DataSource, "% TOTAL")
            .CreateDocument()
        End With

        Dim BusinessCenter As New Rpt3BusinessCenter
        With BusinessCenter
            .Name = "Business Center"
            .lbl2H.Text = If(BandedGridColumn89.Caption.ToString = "2", "", BandedGridColumn89.Caption.ToString)
            .lbl3H.Text = If(BandedGridColumn90.Caption.ToString = "3", "", BandedGridColumn90.Caption.ToString)
            .lbl4H.Text = If(BandedGridColumn91.Caption.ToString = "4", "", BandedGridColumn91.Caption.ToString)
            .lbl5H.Text = If(BandedGridColumn92.Caption.ToString = "5", "", BandedGridColumn92.Caption.ToString)
            .lbl6H.Text = If(BandedGridColumn93.Caption.ToString = "6", "", BandedGridColumn93.Caption.ToString)
            .lbl7H.Text = If(BandedGridColumn94.Caption.ToString = "7", "", BandedGridColumn94.Caption.ToString)
            .lbl8H.Text = If(BandedGridColumn95.Caption.ToString = "8", "", BandedGridColumn95.Caption.ToString)
            .lbl9H.Text = If(BandedGridColumn96.Caption.ToString = "9", "", BandedGridColumn96.Caption.ToString)
            .lbl10H.Text = If(BandedGridColumn97.Caption.ToString = "10", "", BandedGridColumn97.Caption.ToString)

            .DataSource = GridControl3.DataSource
            .lblProduct.DataBindings.Add("Tag", GridControl3.DataSource, "ID")
            .lblProduct.DataBindings.Add("Text", GridControl3.DataSource, "PRODUCT")
            .lblProductCode.DataBindings.Add("Text", GridControl3.DataSource, "Product Code")
            .lblTotal.DataBindings.Add("Text", GridControl3.DataSource, "TOTAL")
            .lbl1.DataBindings.Add("Text", GridControl3.DataSource, "1")
            .lbl2.DataBindings.Add("Text", GridControl3.DataSource, "2")
            .lbl3.DataBindings.Add("Text", GridControl3.DataSource, "3")
            .lbl4.DataBindings.Add("Text", GridControl3.DataSource, "4")
            .lbl5.DataBindings.Add("Text", GridControl3.DataSource, "5")
            .lbl6.DataBindings.Add("Text", GridControl3.DataSource, "6")
            .lbl7.DataBindings.Add("Text", GridControl3.DataSource, "7")
            .lbl8.DataBindings.Add("Text", GridControl3.DataSource, "8")
            .lbl9.DataBindings.Add("Text", GridControl3.DataSource, "9")
            .lbl10.DataBindings.Add("Text", GridControl3.DataSource, "10")
            .CreateDocument()
        End With

        Dim SourceOfIncome As New Rpt4SourceOfIncome
        With SourceOfIncome
            .Name = "Source of Income"
            .lbl3H.Text = If(BandedGridColumn116.Caption.ToString = "3", "", BandedGridColumn116.Caption.ToString)
            .lbl4H.Text = If(BandedGridColumn117.Caption.ToString = "4", "", BandedGridColumn117.Caption.ToString)
            .lbl5H.Text = If(BandedGridColumn118.Caption.ToString = "5", "", BandedGridColumn118.Caption.ToString)
            .lbl6H.Text = If(BandedGridColumn119.Caption.ToString = "6", "", BandedGridColumn119.Caption.ToString)
            .lbl7H.Text = If(BandedGridColumn120.Caption.ToString = "7", "", BandedGridColumn120.Caption.ToString)
            .lbl8H.Text = If(BandedGridColumn121.Caption.ToString = "8", "", BandedGridColumn121.Caption.ToString)
            .lbl9H.Text = If(BandedGridColumn122.Caption.ToString = "9", "", BandedGridColumn122.Caption.ToString)
            .lbl10H.Text = If(BandedGridColumn123.Caption.ToString = "10", "", BandedGridColumn123.Caption.ToString)
            .lbl11H.Text = If(BandedGridColumn133.Caption.ToString = "11", "", BandedGridColumn133.Caption.ToString)
            .lbl12H.Text = If(BandedGridColumn132.Caption.ToString = "12", "", BandedGridColumn132.Caption.ToString)

            .DataSource = GridControl7.DataSource
            .lblProduct.DataBindings.Add("Tag", GridControl7.DataSource, "ID")
            .lblProduct.DataBindings.Add("Text", GridControl7.DataSource, "PRODUCT")
            .lblProductCode.DataBindings.Add("Text", GridControl7.DataSource, "Product Code")
            .lblTotal.DataBindings.Add("Text", GridControl7.DataSource, "TOTAL")
            .lbl1.DataBindings.Add("Text", GridControl7.DataSource, "1")
            .lbl2.DataBindings.Add("Text", GridControl7.DataSource, "2")
            .lbl3.DataBindings.Add("Text", GridControl7.DataSource, "3")
            .lbl4.DataBindings.Add("Text", GridControl7.DataSource, "4")
            .lbl5.DataBindings.Add("Text", GridControl7.DataSource, "5")
            .lbl6.DataBindings.Add("Text", GridControl7.DataSource, "6")
            .lbl7.DataBindings.Add("Text", GridControl7.DataSource, "7")
            .lbl8.DataBindings.Add("Text", GridControl7.DataSource, "8")
            .lbl9.DataBindings.Add("Text", GridControl7.DataSource, "9")
            .lbl10.DataBindings.Add("Text", GridControl7.DataSource, "10")
            .lbl11.DataBindings.Add("Text", GridControl7.DataSource, "11")
            .lbl12.DataBindings.Add("Text", GridControl7.DataSource, "12")
            .CreateDocument()
        End With

        Dim BookingDetailed As New Rpt5BookingsDetailed
        With BookingDetailed
            .Name = "Booking Detailed"
            .lblBranch.Text = Branch
            .lblLoanReleases.Text = ""
            .lblPeriodCovered.Text = dtpPeriod.Text
            .DataSource = DT_BookingDetailedPrint
            .lblProduct.DataBindings.Add("Tag", DT_BookingDetailedPrint, "ID")
            .lblNo.DataBindings.Add("Text", DT_BookingDetailedPrint, "NO.")
            .lblDate.DataBindings.Add("Text", DT_BookingDetailedPrint, "DATE")
            .lblWeek.DataBindings.Add("Text", DT_BookingDetailedPrint, "WEEK")
            .lblClient.DataBindings.Add("Text", DT_BookingDetailedPrint, "CLIENT NAME")
            .lblAccountNo.DataBindings.Add("Text", DT_BookingDetailedPrint, "ACCOUNT NO.")
            .lblPrincipal.DataBindings.Add("Text", DT_BookingDetailedPrint, "PRINCIPAL")
            .lblUDI.DataBindings.Add("Text", DT_BookingDetailedPrint, "UDI")
            .lblRPPD.DataBindings.Add("Text", DT_BookingDetailedPrint, "RPPD")
            .lblFA.DataBindings.Add("Text", DT_BookingDetailedPrint, "FA")
            .lblRate.DataBindings.Add("Text", DT_BookingDetailedPrint, "RATE")
            .lblTerms.DataBindings.Add("Text", DT_BookingDetailedPrint, "TERMS")
            .lblMonthlyAmort.DataBindings.Add("Text", DT_BookingDetailedPrint, "MONTHLY AMORT.")
            .lblRebate.DataBindings.Add("Text", DT_BookingDetailedPrint, "REBATE")
            .lblProcessingFee.DataBindings.Add("Text", DT_BookingDetailedPrint, "PROCESSING FEE")
            .lblServiceCharge.DataBindings.Add("Text", DT_BookingDetailedPrint, "SERVICE CHARGE")
            .lblInsurance.DataBindings.Add("Text", DT_BookingDetailedPrint, "INSURANCE")
            .lblMiscellaneous.DataBindings.Add("Text", DT_BookingDetailedPrint, "MISCELLANEOUS INCOME")
            .lblOtherFees.DataBindings.Add("Text", DT_BookingDetailedPrint, "OTHER FEES")
            .lblAdvanceAmortization.DataBindings.Add("Text", DT_BookingDetailedPrint, "ADVANCE AMORTIZATION")
            .lblInterest.DataBindings.Add("Text", DT_BookingDetailedPrint, "INTEREST")
            .lblDeductBalance.DataBindings.Add("Text", DT_BookingDetailedPrint, "DEDUCT BALANCE")
            .lblNetProceeds.DataBindings.Add("Text", DT_BookingDetailedPrint, "NET PROCEEDS")
            .lblCheckNo.DataBindings.Add("Text", DT_BookingDetailedPrint, "CHECK NO.")
            .lblCollateral.DataBindings.Add("Text", DT_BookingDetailedPrint, "COLLATERAL")
            .lblProductCode.DataBindings.Add("Text", DT_BookingDetailedPrint, "PRODUCT CODE")
            .lblTypeOfLoan.DataBindings.Add("Text", DT_BookingDetailedPrint, "TYPE OF LOAN")
            .lblRemarks.DataBindings.Add("Text", DT_BookingDetailedPrint, "REMARKS")
            .lblCI.DataBindings.Add("Text", DT_BookingDetailedPrint, "CI")
            .lblInsuranceProvider.DataBindings.Add("Text", DT_BookingDetailedPrint, "INSURANCE PROVIDER")
            .lblInsuranceRate.DataBindings.Add("Text", DT_BookingDetailedPrint, "INSURANCE COMMISSION RATE")
            .lblPremium.DataBindings.Add("Text", DT_BookingDetailedPrint, "PREMIUM")
            .lblWithholdingTax.DataBindings.Add("Text", DT_BookingDetailedPrint, "WITHHOLDING TAX")
            .lblInsuranceCommission.DataBindings.Add("Text", DT_BookingDetailedPrint, "NET INSURANCE COMMISSION")
            .lblReasonDiff.DataBindings.Add("Text", DT_BookingDetailedPrint, "REASON IF DIFFERENT INSURANCE PROVIDER")
            .lblBusinessCenter.DataBindings.Add("Text", DT_BookingDetailedPrint, "BUSINESS CENTER")
            .lblSourceIncome.DataBindings.Add("Text", DT_BookingDetailedPrint, "SOURCE OF INCOME")

            .lblPrincipalT.DataBindings.Add("Text", DT_BookingDetailedPrint, "PRINCIPAL")
            .lblUDIT.DataBindings.Add("Text", DT_BookingDetailedPrint, "UDI")
            .lblRPPDT.DataBindings.Add("Text", DT_BookingDetailedPrint, "RPPD")
            .lblFAT.DataBindings.Add("Text", DT_BookingDetailedPrint, "FA")
            .lblMonthlyAmortT.DataBindings.Add("Text", DT_BookingDetailedPrint, "MONTHLY AMORT.")
            .lblRebateT.DataBindings.Add("Text", DT_BookingDetailedPrint, "REBATE")
            .lblProcessingFeeT.DataBindings.Add("Text", DT_BookingDetailedPrint, "PROCESSING FEE")
            .lblServiceChargeT.DataBindings.Add("Text", DT_BookingDetailedPrint, "SERVICE CHARGE")
            .lblInsuranceT.DataBindings.Add("Text", DT_BookingDetailedPrint, "INSURANCE")
            .lblMiscellaneousT.DataBindings.Add("Text", DT_BookingDetailedPrint, "MISCELLANEOUS INCOME")
            .lblOtherFeesT.DataBindings.Add("Text", DT_BookingDetailedPrint, "OTHER FEES")
            .lblAdvanceAmortizationT.DataBindings.Add("Text", DT_BookingDetailedPrint, "ADVANCE AMORTIZATION")
            .lblInterestT.DataBindings.Add("Text", DT_BookingDetailedPrint, "INTEREST")
            .lblDeductBalanceT.DataBindings.Add("Text", DT_BookingDetailedPrint, "DEDUCT BALANCE")
            .lblNetProceedsT.DataBindings.Add("Text", DT_BookingDetailedPrint, "NET PROCEEDS")
            .lblPremiumT.DataBindings.Add("Text", DT_BookingDetailedPrint, "PREMIUM")
            .lblWithholdingTaxT.DataBindings.Add("Text", DT_BookingDetailedPrint, "WITHHOLDING TAX")
            .lblInsuranceCommissionT.DataBindings.Add("Text", DT_BookingDetailedPrint, "NET INSURANCE COMMISSION")
            .CreateDocument()
        End With

        Dim CollectionSummary As New Rpt6CollectionSummary
        With CollectionSummary
            .Name = "Collection Summary"
            .DataSource = GridControl5.DataSource
            .lblProduct.DataBindings.Add("Tag", GridControl5.DataSource, "ID")
            .lblProduct.DataBindings.Add("Text", GridControl5.DataSource, "PRODUCT")
            .lblProductCode.DataBindings.Add("Text", GridControl5.DataSource, "Product Code")
            .lblWeek1.DataBindings.Add("Text", GridControl5.DataSource, "1")
            .lblWeek2.DataBindings.Add("Text", GridControl5.DataSource, "2")
            .lblWeek3.DataBindings.Add("Text", GridControl5.DataSource, "3")
            .lblWeek4.DataBindings.Add("Text", GridControl5.DataSource, "4")
            .lblWeek5.DataBindings.Add("Text", GridControl5.DataSource, "5")
            .lblWeekT.DataBindings.Add("Text", GridControl5.DataSource, "TOTAL")
            .CreateDocument()
        End With

        Dim CollectionDetailed As New Rpt7CollectionDetailed
        With CollectionDetailed
            .Name = "Collection Detailed"
            .DataSource = GridControl6.DataSource
            .lblProduct.DataBindings.Add("Tag", GridControl6.DataSource, "ID")
            .lblProduct.DataBindings.Add("Text", GridControl6.DataSource, "PRODUCT")
            .lblProductCode.DataBindings.Add("Text", GridControl6.DataSource, "Product Code")
            .lblLR1.DataBindings.Add("Text", GridControl6.DataSource, "Loans Receivable_1")
            .lblCurrent1.DataBindings.Add("Text", GridControl6.DataSource, "Interest Income-Current_1")
            .lblPastDue1.DataBindings.Add("Text", GridControl6.DataSource, "Interest Income-Past Due_1")
            .lblOthers1.DataBindings.Add("Text", GridControl6.DataSource, "Others_1")
            .lblLR2.DataBindings.Add("Text", GridControl6.DataSource, "Loans Receivable_2")
            .lblCurrent2.DataBindings.Add("Text", GridControl6.DataSource, "Interest Income-Current_2")
            .lblPastDue2.DataBindings.Add("Text", GridControl6.DataSource, "Interest Income-Past Due_2")
            .lblOthers2.DataBindings.Add("Text", GridControl6.DataSource, "Others_2")
            .lblLR3.DataBindings.Add("Text", GridControl6.DataSource, "Loans Receivable_3")
            .lblCurrent3.DataBindings.Add("Text", GridControl6.DataSource, "Interest Income-Current_3")
            .lblPastDue3.DataBindings.Add("Text", GridControl6.DataSource, "Interest Income-Past Due_3")
            .lblOthers3.DataBindings.Add("Text", GridControl6.DataSource, "Others_3")
            .lblLR4.DataBindings.Add("Text", GridControl6.DataSource, "Loans Receivable_4")
            .lblCurrent4.DataBindings.Add("Text", GridControl6.DataSource, "Interest Income-Current_4")
            .lblPastDue4.DataBindings.Add("Text", GridControl6.DataSource, "Interest Income-Past Due_4")
            .lblOthers4.DataBindings.Add("Text", GridControl6.DataSource, "Others_4")
            .lblLR5.DataBindings.Add("Text", GridControl6.DataSource, "Loans Receivable_5")
            .lblCurrent5.DataBindings.Add("Text", GridControl6.DataSource, "Interest Income-Current_5")
            .lblPastDue5.DataBindings.Add("Text", GridControl6.DataSource, "Interest Income-Past Due_5")
            .lblOthers5.DataBindings.Add("Text", GridControl6.DataSource, "Others_5")
            .CreateDocument()
        End With

        With BookingSummary
            .Pages.AddRange(ClientType.Pages)
            .Pages.AddRange(BusinessCenter.Pages)
            .Pages.AddRange(SourceOfIncome.Pages)
            .Pages.AddRange(BookingDetailed.Pages)
            .Pages.AddRange(CollectionSummary.Pages)
            .Pages.AddRange(CollectionDetailed.Pages)
            Logs("Booking and Collection", "Print", "[SENSITIVE] Print Booking and Collection", "", "", "", "")
            .ShowPreview()
        End With
    End Sub

    Private Sub ILedger_Click(sender As Object, e As EventArgs) Handles iLedger.Click
        Try
            If BandedGridView4.GetFocusedRowCellValue("CreditNumber") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = BandedGridView4.GetFocusedRowCellValue("CreditNumber")
            .Show()
        End With
    End Sub

    Private Sub BandedGridView4_DoubleClick(sender As Object, e As EventArgs) Handles BandedGridView4.DoubleClick
        ILedger_Click(sender, e)
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 5 Or SuperTabControl1.SelectedTabIndex = 6 Then
            btnCollectionDetails.Visible = True
        Else
            btnCollectionDetails.Visible = False
        End If
    End Sub

    Private Sub BtnCollectionDetails_Click(sender As Object, e As EventArgs) Handles btnCollectionDetails.Click
        Dim Details As New FrmCollectionDetails
        With Details
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class