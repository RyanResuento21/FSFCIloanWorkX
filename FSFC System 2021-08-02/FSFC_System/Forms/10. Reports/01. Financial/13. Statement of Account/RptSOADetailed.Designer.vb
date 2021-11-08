<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptSOADetailed
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptSOADetailed))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.lblChecked = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblChecked_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDiscount = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDiscount_3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDiscount_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDiscount_4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel81 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNoted = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblReceived = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel78 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrepared = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel80 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel76 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotal = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel73 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblOverdue = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRebateD = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRebate = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRebateA = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblOthersAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel65 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblOthers = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblUnpaidPenalties = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel64 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPenalties = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblArrears = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel61 = New DevExpress.XtraReports.UI.XRLabel()
        Me.subRpt_SOA = New DevExpress.XtraReports.UI.XRSubreport()
        Me.lblDaysDelayed = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblHangingP = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblHangingA = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblUpdatedP = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblUpdatedA = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBalanceP = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBalance = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel53 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel52 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel49 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel48 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel47 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel43 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel41 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAsOf = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel39 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMonthsMD = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel37 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMaturityD = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel35 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblLastP = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel33 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDateAvailed = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel30 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMonthlyA = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel27 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDueDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel25 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotalPayments = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFaceAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrincipal = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCollateral = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblContact = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.lblAddress = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblReceived_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNoted_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel51 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel50 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel45 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel44 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrepared_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel46 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotal_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel42 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblOthersAmount_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRebate_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblOverdue_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRebateA_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblUnpaidDate_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBalance_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel32 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblUnpaidPenalties_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblOthers_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPenalties_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPenaltyDates_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMonthlyA_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrincipal_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblLastP_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel28 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDateAvailed_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblName_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountNumber_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCollateral_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAsOf_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblContact_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAddress_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox2 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel84 = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo2, Me.lblChecked, Me.XrLabel9, Me.XrLabel11, Me.lblChecked_2, Me.lblDiscount, Me.lblDiscount_3, Me.lblDiscount_2, Me.lblDiscount_4, Me.XrLabel1, Me.XrLabel81, Me.lblNoted, Me.lblReceived, Me.XrLabel78, Me.lblPrepared, Me.XrLabel80, Me.XrLabel76, Me.lblTotal, Me.XrLabel73, Me.lblOverdue, Me.lblRebateD, Me.lblRebate, Me.lblRebateA, Me.lblOthersAmount, Me.XrLabel65, Me.lblOthers, Me.lblUnpaidPenalties, Me.XrLabel64, Me.lblPenalties, Me.lblArrears, Me.XrLabel61, Me.subRpt_SOA, Me.lblDaysDelayed, Me.lblHangingP, Me.lblHangingA, Me.lblUpdatedP, Me.lblUpdatedA, Me.lblBalanceP, Me.lblBalance, Me.XrLabel53, Me.XrLabel52, Me.XrLabel49, Me.XrLabel48, Me.XrLabel47, Me.XrLabel43, Me.XrLabel41, Me.lblAsOf, Me.XrLabel39, Me.lblMonthsMD, Me.XrLabel37, Me.lblMaturityD, Me.XrLabel35, Me.lblLastP, Me.XrLabel33, Me.lblDateAvailed, Me.XrLabel30, Me.lblMonthlyA, Me.XrLabel27, Me.lblDueDate, Me.XrLabel25, Me.lblTotalPayments, Me.XrLabel21, Me.lblFaceAmount, Me.XrLabel18, Me.lblPrincipal, Me.XrLabel15, Me.lblCollateral, Me.XrLabel13, Me.lblAccountNumber, Me.XrLabel10, Me.lblName, Me.XrLabel7, Me.XrLabel4, Me.lblContact, Me.XrPictureBox1, Me.lblAddress, Me.lblReceived_2, Me.lblNoted_2, Me.XrLabel51, Me.XrLabel50, Me.XrLabel45, Me.XrLabel44, Me.lblPrepared_2, Me.XrLabel46, Me.lblTotal_2, Me.XrLabel42, Me.lblOthersAmount_2, Me.lblRebate_2, Me.lblOverdue_2, Me.XrLabel3, Me.lblRebateA_2, Me.lblUnpaidDate_2, Me.lblBalance_2, Me.XrLabel32, Me.lblUnpaidPenalties_2, Me.lblOthers_2, Me.lblPenalties_2, Me.lblPenaltyDates_2, Me.lblMonthlyA_2, Me.XrLabel22, Me.lblPrincipal_2, Me.XrLabel24, Me.lblLastP_2, Me.XrLabel28, Me.lblDateAvailed_2, Me.XrLabel12, Me.lblName_2, Me.XrLabel8, Me.lblAccountNumber_2, Me.XrLabel20, Me.lblCollateral_2, Me.XrLabel16, Me.lblAsOf_2, Me.XrLabel5, Me.lblContact_2, Me.lblAddress_2, Me.XrPictureBox2, Me.XrLine1, Me.XrLabel84})
        Me.Detail.HeightF = 781.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.BackColor = System.Drawing.Color.White
        Me.XrPageInfo2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo2.Format = "{0:dddd, MMMM d, yyyy h:mm tt}"
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 694.9999!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.XrPageInfo2.StylePriority.UseBackColor = False
        Me.XrPageInfo2.StylePriority.UseFont = False
        Me.XrPageInfo2.StylePriority.UseTextAlignment = False
        Me.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblChecked
        '
        Me.lblChecked.BackColor = System.Drawing.Color.White
        Me.lblChecked.BorderColor = System.Drawing.Color.Black
        Me.lblChecked.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblChecked.CanGrow = False
        Me.lblChecked.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.lblChecked.ForeColor = System.Drawing.Color.Black
        Me.lblChecked.LocationFloat = New DevExpress.Utils.PointFloat(130.0!, 731.0!)
        Me.lblChecked.Name = "lblChecked"
        Me.lblChecked.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblChecked.SizeF = New System.Drawing.SizeF(130.0!, 30.0!)
        Me.lblChecked.StylePriority.UseBackColor = False
        Me.lblChecked.StylePriority.UseBorderColor = False
        Me.lblChecked.StylePriority.UseBorders = False
        Me.lblChecked.StylePriority.UseFont = False
        Me.lblChecked.StylePriority.UseForeColor = False
        Me.lblChecked.StylePriority.UseTextAlignment = False
        Me.lblChecked.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'XrLabel9
        '
        Me.XrLabel9.BackColor = System.Drawing.Color.White
        Me.XrLabel9.BorderColor = System.Drawing.Color.Black
        Me.XrLabel9.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel9.CanGrow = False
        Me.XrLabel9.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.ForeColor = System.Drawing.Color.Black
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(130.0!, 711.0!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(130.0!, 20.0!)
        Me.XrLabel9.StylePriority.UseBackColor = False
        Me.XrLabel9.StylePriority.UseBorderColor = False
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseForeColor = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = "Checked By :"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel11
        '
        Me.XrLabel11.BackColor = System.Drawing.Color.White
        Me.XrLabel11.BorderColor = System.Drawing.Color.Black
        Me.XrLabel11.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel11.CanGrow = False
        Me.XrLabel11.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel11.ForeColor = System.Drawing.Color.Black
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(660.0001!, 530.0!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(130.0!, 25.0!)
        Me.XrLabel11.StylePriority.UseBackColor = False
        Me.XrLabel11.StylePriority.UseBorderColor = False
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseForeColor = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = "Checked By :"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblChecked_2
        '
        Me.lblChecked_2.BackColor = System.Drawing.Color.White
        Me.lblChecked_2.BorderColor = System.Drawing.Color.Black
        Me.lblChecked_2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblChecked_2.CanGrow = False
        Me.lblChecked_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChecked_2.ForeColor = System.Drawing.Color.Black
        Me.lblChecked_2.LocationFloat = New DevExpress.Utils.PointFloat(660.0001!, 555.0!)
        Me.lblChecked_2.Name = "lblChecked_2"
        Me.lblChecked_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblChecked_2.SizeF = New System.Drawing.SizeF(130.0!, 80.0!)
        Me.lblChecked_2.StylePriority.UseBackColor = False
        Me.lblChecked_2.StylePriority.UseBorderColor = False
        Me.lblChecked_2.StylePriority.UseBorders = False
        Me.lblChecked_2.StylePriority.UseFont = False
        Me.lblChecked_2.StylePriority.UseForeColor = False
        Me.lblChecked_2.StylePriority.UseTextAlignment = False
        Me.lblChecked_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'lblDiscount
        '
        Me.lblDiscount.BackColor = System.Drawing.Color.White
        Me.lblDiscount.BorderColor = System.Drawing.Color.Black
        Me.lblDiscount.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblDiscount.CanGrow = False
        Me.lblDiscount.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiscount.ForeColor = System.Drawing.Color.Black
        Me.lblDiscount.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 580.9999!)
        Me.lblDiscount.Name = "lblDiscount"
        Me.lblDiscount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDiscount.SizeF = New System.Drawing.SizeF(270.0!, 20.0!)
        Me.lblDiscount.StylePriority.UseBackColor = False
        Me.lblDiscount.StylePriority.UseBorderColor = False
        Me.lblDiscount.StylePriority.UseBorders = False
        Me.lblDiscount.StylePriority.UseFont = False
        Me.lblDiscount.StylePriority.UseForeColor = False
        Me.lblDiscount.StylePriority.UseTextAlignment = False
        Me.lblDiscount.Text = "1,000,000.00"
        Me.lblDiscount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblDiscount.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblDiscount_3
        '
        Me.lblDiscount_3.BackColor = System.Drawing.Color.White
        Me.lblDiscount_3.BorderColor = System.Drawing.Color.Black
        Me.lblDiscount_3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblDiscount_3.CanGrow = False
        Me.lblDiscount_3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiscount_3.ForeColor = System.Drawing.Color.Black
        Me.lblDiscount_3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 580.9999!)
        Me.lblDiscount_3.Name = "lblDiscount_3"
        Me.lblDiscount_3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDiscount_3.SizeF = New System.Drawing.SizeF(250.0!, 20.0!)
        Me.lblDiscount_3.StylePriority.UseBackColor = False
        Me.lblDiscount_3.StylePriority.UseBorderColor = False
        Me.lblDiscount_3.StylePriority.UseBorders = False
        Me.lblDiscount_3.StylePriority.UseFont = False
        Me.lblDiscount_3.StylePriority.UseForeColor = False
        Me.lblDiscount_3.StylePriority.UseTextAlignment = False
        Me.lblDiscount_3.Text = "Penalty Discount :"
        Me.lblDiscount_3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblDiscount_2
        '
        Me.lblDiscount_2.BackColor = System.Drawing.Color.White
        Me.lblDiscount_2.BorderColor = System.Drawing.Color.Black
        Me.lblDiscount_2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblDiscount_2.CanGrow = False
        Me.lblDiscount_2.Font = New System.Drawing.Font("Century Gothic", 11.25!)
        Me.lblDiscount_2.ForeColor = System.Drawing.Color.Black
        Me.lblDiscount_2.LocationFloat = New DevExpress.Utils.PointFloat(880.0!, 350.0!)
        Me.lblDiscount_2.Name = "lblDiscount_2"
        Me.lblDiscount_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDiscount_2.SizeF = New System.Drawing.SizeF(170.0!, 25.0!)
        Me.lblDiscount_2.StylePriority.UseBackColor = False
        Me.lblDiscount_2.StylePriority.UseBorderColor = False
        Me.lblDiscount_2.StylePriority.UseBorders = False
        Me.lblDiscount_2.StylePriority.UseFont = False
        Me.lblDiscount_2.StylePriority.UseForeColor = False
        Me.lblDiscount_2.StylePriority.UseTextAlignment = False
        Me.lblDiscount_2.Text = "100.00"
        Me.lblDiscount_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblDiscount_2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblDiscount_4
        '
        Me.lblDiscount_4.BackColor = System.Drawing.Color.White
        Me.lblDiscount_4.BorderColor = System.Drawing.Color.Black
        Me.lblDiscount_4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblDiscount_4.CanGrow = False
        Me.lblDiscount_4.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiscount_4.ForeColor = System.Drawing.Color.Black
        Me.lblDiscount_4.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 350.0!)
        Me.lblDiscount_4.Name = "lblDiscount_4"
        Me.lblDiscount_4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDiscount_4.SizeF = New System.Drawing.SizeF(350.0!, 25.0!)
        Me.lblDiscount_4.StylePriority.UseBackColor = False
        Me.lblDiscount_4.StylePriority.UseBorderColor = False
        Me.lblDiscount_4.StylePriority.UseBorders = False
        Me.lblDiscount_4.StylePriority.UseFont = False
        Me.lblDiscount_4.StylePriority.UseForeColor = False
        Me.lblDiscount_4.StylePriority.UseTextAlignment = False
        Me.lblDiscount_4.Text = "Penalty Discount :"
        Me.lblDiscount_4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.BackColor = System.Drawing.Color.White
        Me.XrLabel1.BorderColor = System.Drawing.Color.Black
        Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.XrLabel1.CanGrow = False
        Me.XrLabel1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.ForeColor = System.Drawing.Color.Black
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 395.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.XrLabel1.StylePriority.UseBackColor = False
        Me.XrLabel1.StylePriority.UseBorderColor = False
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseForeColor = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel81
        '
        Me.XrLabel81.BackColor = System.Drawing.Color.White
        Me.XrLabel81.BorderColor = System.Drawing.Color.Black
        Me.XrLabel81.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel81.CanGrow = False
        Me.XrLabel81.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.XrLabel81.ForeColor = System.Drawing.Color.Black
        Me.XrLabel81.LocationFloat = New DevExpress.Utils.PointFloat(260.0!, 711.0!)
        Me.XrLabel81.Name = "XrLabel81"
        Me.XrLabel81.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel81.SizeF = New System.Drawing.SizeF(130.0!, 20.0!)
        Me.XrLabel81.StylePriority.UseBackColor = False
        Me.XrLabel81.StylePriority.UseBorderColor = False
        Me.XrLabel81.StylePriority.UseBorders = False
        Me.XrLabel81.StylePriority.UseFont = False
        Me.XrLabel81.StylePriority.UseForeColor = False
        Me.XrLabel81.StylePriority.UseTextAlignment = False
        Me.XrLabel81.Text = "Noted By :"
        Me.XrLabel81.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblNoted
        '
        Me.lblNoted.BackColor = System.Drawing.Color.White
        Me.lblNoted.BorderColor = System.Drawing.Color.Black
        Me.lblNoted.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblNoted.CanGrow = False
        Me.lblNoted.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.lblNoted.ForeColor = System.Drawing.Color.Black
        Me.lblNoted.LocationFloat = New DevExpress.Utils.PointFloat(260.0!, 731.0!)
        Me.lblNoted.Name = "lblNoted"
        Me.lblNoted.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNoted.SizeF = New System.Drawing.SizeF(130.0!, 30.0!)
        Me.lblNoted.StylePriority.UseBackColor = False
        Me.lblNoted.StylePriority.UseBorderColor = False
        Me.lblNoted.StylePriority.UseBorders = False
        Me.lblNoted.StylePriority.UseFont = False
        Me.lblNoted.StylePriority.UseForeColor = False
        Me.lblNoted.StylePriority.UseTextAlignment = False
        Me.lblNoted.Text = "Mark Kevin M. Gotico"
        Me.lblNoted.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'lblReceived
        '
        Me.lblReceived.BackColor = System.Drawing.Color.White
        Me.lblReceived.BorderColor = System.Drawing.Color.Black
        Me.lblReceived.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblReceived.CanGrow = False
        Me.lblReceived.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.lblReceived.ForeColor = System.Drawing.Color.Black
        Me.lblReceived.LocationFloat = New DevExpress.Utils.PointFloat(390.0!, 731.0!)
        Me.lblReceived.Name = "lblReceived"
        Me.lblReceived.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblReceived.SizeF = New System.Drawing.SizeF(130.0!, 30.0!)
        Me.lblReceived.StylePriority.UseBackColor = False
        Me.lblReceived.StylePriority.UseBorderColor = False
        Me.lblReceived.StylePriority.UseBorders = False
        Me.lblReceived.StylePriority.UseFont = False
        Me.lblReceived.StylePriority.UseForeColor = False
        Me.lblReceived.StylePriority.UseTextAlignment = False
        Me.lblReceived.Text = "Mark Kevin M. Gotico"
        Me.lblReceived.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'XrLabel78
        '
        Me.XrLabel78.BackColor = System.Drawing.Color.White
        Me.XrLabel78.BorderColor = System.Drawing.Color.Black
        Me.XrLabel78.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel78.CanGrow = False
        Me.XrLabel78.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.XrLabel78.ForeColor = System.Drawing.Color.Black
        Me.XrLabel78.LocationFloat = New DevExpress.Utils.PointFloat(390.0!, 711.0!)
        Me.XrLabel78.Name = "XrLabel78"
        Me.XrLabel78.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel78.SizeF = New System.Drawing.SizeF(130.0!, 20.0!)
        Me.XrLabel78.StylePriority.UseBackColor = False
        Me.XrLabel78.StylePriority.UseBorderColor = False
        Me.XrLabel78.StylePriority.UseBorders = False
        Me.XrLabel78.StylePriority.UseFont = False
        Me.XrLabel78.StylePriority.UseForeColor = False
        Me.XrLabel78.StylePriority.UseTextAlignment = False
        Me.XrLabel78.Text = "Received By :"
        Me.XrLabel78.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblPrepared
        '
        Me.lblPrepared.BackColor = System.Drawing.Color.White
        Me.lblPrepared.BorderColor = System.Drawing.Color.Black
        Me.lblPrepared.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPrepared.CanGrow = False
        Me.lblPrepared.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.lblPrepared.ForeColor = System.Drawing.Color.Black
        Me.lblPrepared.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 731.0!)
        Me.lblPrepared.Name = "lblPrepared"
        Me.lblPrepared.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrepared.SizeF = New System.Drawing.SizeF(130.0!, 30.0!)
        Me.lblPrepared.StylePriority.UseBackColor = False
        Me.lblPrepared.StylePriority.UseBorderColor = False
        Me.lblPrepared.StylePriority.UseBorders = False
        Me.lblPrepared.StylePriority.UseFont = False
        Me.lblPrepared.StylePriority.UseForeColor = False
        Me.lblPrepared.StylePriority.UseTextAlignment = False
        Me.lblPrepared.Text = "Mark Kevin M. Gotico"
        Me.lblPrepared.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'XrLabel80
        '
        Me.XrLabel80.BackColor = System.Drawing.Color.White
        Me.XrLabel80.BorderColor = System.Drawing.Color.Black
        Me.XrLabel80.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel80.CanGrow = False
        Me.XrLabel80.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel80.ForeColor = System.Drawing.Color.Black
        Me.XrLabel80.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 711.0!)
        Me.XrLabel80.Name = "XrLabel80"
        Me.XrLabel80.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel80.SizeF = New System.Drawing.SizeF(130.0!, 20.0!)
        Me.XrLabel80.StylePriority.UseBackColor = False
        Me.XrLabel80.StylePriority.UseBorderColor = False
        Me.XrLabel80.StylePriority.UseBorders = False
        Me.XrLabel80.StylePriority.UseFont = False
        Me.XrLabel80.StylePriority.UseForeColor = False
        Me.XrLabel80.StylePriority.UseTextAlignment = False
        Me.XrLabel80.Text = "Prepared By :"
        Me.XrLabel80.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel76
        '
        Me.XrLabel76.BackColor = System.Drawing.Color.White
        Me.XrLabel76.BorderColor = System.Drawing.Color.Black
        Me.XrLabel76.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel76.CanGrow = False
        Me.XrLabel76.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel76.ForeColor = System.Drawing.Color.Black
        Me.XrLabel76.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 686.0!)
        Me.XrLabel76.Name = "XrLabel76"
        Me.XrLabel76.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel76.SizeF = New System.Drawing.SizeF(250.0!, 25.0!)
        Me.XrLabel76.StylePriority.UseBackColor = False
        Me.XrLabel76.StylePriority.UseBorderColor = False
        Me.XrLabel76.StylePriority.UseBorders = False
        Me.XrLabel76.StylePriority.UseFont = False
        Me.XrLabel76.StylePriority.UseForeColor = False
        Me.XrLabel76.StylePriority.UseTextAlignment = False
        Me.XrLabel76.Text = "Total Amount Due :"
        Me.XrLabel76.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.BorderColor = System.Drawing.Color.Black
        Me.lblTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblTotal.CanGrow = False
        Me.lblTotal.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Black
        Me.lblTotal.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 686.0!)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotal.SizeF = New System.Drawing.SizeF(270.0!, 25.0!)
        Me.lblTotal.StylePriority.UseBackColor = False
        Me.lblTotal.StylePriority.UseBorderColor = False
        Me.lblTotal.StylePriority.UseBorders = False
        Me.lblTotal.StylePriority.UseFont = False
        Me.lblTotal.StylePriority.UseForeColor = False
        Me.lblTotal.StylePriority.UseTextAlignment = False
        Me.lblTotal.Text = "1,000,000.00"
        Me.lblTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblTotal.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel73
        '
        Me.XrLabel73.BackColor = System.Drawing.Color.White
        Me.XrLabel73.BorderColor = System.Drawing.Color.Black
        Me.XrLabel73.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel73.CanGrow = False
        Me.XrLabel73.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel73.ForeColor = System.Drawing.Color.Black
        Me.XrLabel73.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 661.0!)
        Me.XrLabel73.Name = "XrLabel73"
        Me.XrLabel73.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel73.SizeF = New System.Drawing.SizeF(250.0!, 25.0!)
        Me.XrLabel73.StylePriority.UseBackColor = False
        Me.XrLabel73.StylePriority.UseBorderColor = False
        Me.XrLabel73.StylePriority.UseBorders = False
        Me.XrLabel73.StylePriority.UseFont = False
        Me.XrLabel73.StylePriority.UseForeColor = False
        Me.XrLabel73.StylePriority.UseTextAlignment = False
        Me.XrLabel73.Text = "Overdue (to update) :"
        Me.XrLabel73.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblOverdue
        '
        Me.lblOverdue.BackColor = System.Drawing.Color.White
        Me.lblOverdue.BorderColor = System.Drawing.Color.Black
        Me.lblOverdue.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblOverdue.CanGrow = False
        Me.lblOverdue.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverdue.ForeColor = System.Drawing.Color.Black
        Me.lblOverdue.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 661.0!)
        Me.lblOverdue.Name = "lblOverdue"
        Me.lblOverdue.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblOverdue.SizeF = New System.Drawing.SizeF(270.0!, 25.0!)
        Me.lblOverdue.StylePriority.UseBackColor = False
        Me.lblOverdue.StylePriority.UseBorderColor = False
        Me.lblOverdue.StylePriority.UseBorders = False
        Me.lblOverdue.StylePriority.UseFont = False
        Me.lblOverdue.StylePriority.UseForeColor = False
        Me.lblOverdue.StylePriority.UseTextAlignment = False
        Me.lblOverdue.Text = "1,000,000.00"
        Me.lblOverdue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblOverdue.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblRebateD
        '
        Me.lblRebateD.BackColor = System.Drawing.Color.White
        Me.lblRebateD.BorderColor = System.Drawing.Color.Black
        Me.lblRebateD.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblRebateD.CanGrow = False
        Me.lblRebateD.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRebateD.ForeColor = System.Drawing.Color.Black
        Me.lblRebateD.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 641.0001!)
        Me.lblRebateD.Name = "lblRebateD"
        Me.lblRebateD.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRebateD.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.lblRebateD.StylePriority.UseBackColor = False
        Me.lblRebateD.StylePriority.UseBorderColor = False
        Me.lblRebateD.StylePriority.UseBorders = False
        Me.lblRebateD.StylePriority.UseFont = False
        Me.lblRebateD.StylePriority.UseForeColor = False
        Me.lblRebateD.StylePriority.UseTextAlignment = False
        Me.lblRebateD.Text = "[December 04, 2017]"
        Me.lblRebateD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblRebateD.Visible = False
        Me.lblRebateD.XlsxFormatString = "mm/dd/yyyy"
        '
        'lblRebate
        '
        Me.lblRebate.BackColor = System.Drawing.Color.White
        Me.lblRebate.BorderColor = System.Drawing.Color.Black
        Me.lblRebate.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblRebate.CanGrow = False
        Me.lblRebate.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRebate.ForeColor = System.Drawing.Color.Black
        Me.lblRebate.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 641.0001!)
        Me.lblRebate.Name = "lblRebate"
        Me.lblRebate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRebate.SizeF = New System.Drawing.SizeF(250.0!, 20.0!)
        Me.lblRebate.StylePriority.UseBackColor = False
        Me.lblRebate.StylePriority.UseBorderColor = False
        Me.lblRebate.StylePriority.UseBorders = False
        Me.lblRebate.StylePriority.UseFont = False
        Me.lblRebate.StylePriority.UseForeColor = False
        Me.lblRebate.StylePriority.UseTextAlignment = False
        Me.lblRebate.Text = "Rebate :"
        Me.lblRebate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblRebate.Visible = False
        '
        'lblRebateA
        '
        Me.lblRebateA.BackColor = System.Drawing.Color.White
        Me.lblRebateA.BorderColor = System.Drawing.Color.Black
        Me.lblRebateA.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblRebateA.CanGrow = False
        Me.lblRebateA.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRebateA.ForeColor = System.Drawing.Color.Black
        Me.lblRebateA.LocationFloat = New DevExpress.Utils.PointFloat(385.0!, 641.0!)
        Me.lblRebateA.Name = "lblRebateA"
        Me.lblRebateA.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRebateA.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.lblRebateA.StylePriority.UseBackColor = False
        Me.lblRebateA.StylePriority.UseBorderColor = False
        Me.lblRebateA.StylePriority.UseBorders = False
        Me.lblRebateA.StylePriority.UseFont = False
        Me.lblRebateA.StylePriority.UseForeColor = False
        Me.lblRebateA.StylePriority.UseTextAlignment = False
        Me.lblRebateA.Text = "1,000,000.00"
        Me.lblRebateA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblRebateA.Visible = False
        Me.lblRebateA.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblOthersAmount
        '
        Me.lblOthersAmount.BackColor = System.Drawing.Color.White
        Me.lblOthersAmount.BorderColor = System.Drawing.Color.Black
        Me.lblOthersAmount.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblOthersAmount.CanGrow = False
        Me.lblOthersAmount.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOthersAmount.ForeColor = System.Drawing.Color.Black
        Me.lblOthersAmount.LocationFloat = New DevExpress.Utils.PointFloat(385.0!, 621.0!)
        Me.lblOthersAmount.Name = "lblOthersAmount"
        Me.lblOthersAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblOthersAmount.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.lblOthersAmount.StylePriority.UseBackColor = False
        Me.lblOthersAmount.StylePriority.UseBorderColor = False
        Me.lblOthersAmount.StylePriority.UseBorders = False
        Me.lblOthersAmount.StylePriority.UseFont = False
        Me.lblOthersAmount.StylePriority.UseForeColor = False
        Me.lblOthersAmount.StylePriority.UseTextAlignment = False
        Me.lblOthersAmount.Text = "1,000,000.00"
        Me.lblOthersAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblOthersAmount.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel65
        '
        Me.XrLabel65.BackColor = System.Drawing.Color.White
        Me.XrLabel65.BorderColor = System.Drawing.Color.Black
        Me.XrLabel65.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel65.CanGrow = False
        Me.XrLabel65.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel65.ForeColor = System.Drawing.Color.Black
        Me.XrLabel65.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 621.0!)
        Me.XrLabel65.Name = "XrLabel65"
        Me.XrLabel65.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel65.SizeF = New System.Drawing.SizeF(250.0!, 20.0!)
        Me.XrLabel65.StylePriority.UseBackColor = False
        Me.XrLabel65.StylePriority.UseBorderColor = False
        Me.XrLabel65.StylePriority.UseBorders = False
        Me.XrLabel65.StylePriority.UseFont = False
        Me.XrLabel65.StylePriority.UseForeColor = False
        Me.XrLabel65.StylePriority.UseTextAlignment = False
        Me.XrLabel65.Text = "Others :"
        Me.XrLabel65.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblOthers
        '
        Me.lblOthers.BackColor = System.Drawing.Color.White
        Me.lblOthers.BorderColor = System.Drawing.Color.Black
        Me.lblOthers.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblOthers.CanGrow = False
        Me.lblOthers.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOthers.ForeColor = System.Drawing.Color.Black
        Me.lblOthers.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 621.0!)
        Me.lblOthers.Name = "lblOthers"
        Me.lblOthers.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblOthers.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.lblOthers.StylePriority.UseBackColor = False
        Me.lblOthers.StylePriority.UseBorderColor = False
        Me.lblOthers.StylePriority.UseBorders = False
        Me.lblOthers.StylePriority.UseFont = False
        Me.lblOthers.StylePriority.UseForeColor = False
        Me.lblOthers.StylePriority.UseTextAlignment = False
        Me.lblOthers.Text = "[Payment]"
        Me.lblOthers.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblUnpaidPenalties
        '
        Me.lblUnpaidPenalties.BackColor = System.Drawing.Color.White
        Me.lblUnpaidPenalties.BorderColor = System.Drawing.Color.Black
        Me.lblUnpaidPenalties.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblUnpaidPenalties.CanGrow = False
        Me.lblUnpaidPenalties.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnpaidPenalties.ForeColor = System.Drawing.Color.Black
        Me.lblUnpaidPenalties.LocationFloat = New DevExpress.Utils.PointFloat(385.0!, 600.9999!)
        Me.lblUnpaidPenalties.Name = "lblUnpaidPenalties"
        Me.lblUnpaidPenalties.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblUnpaidPenalties.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.lblUnpaidPenalties.StylePriority.UseBackColor = False
        Me.lblUnpaidPenalties.StylePriority.UseBorderColor = False
        Me.lblUnpaidPenalties.StylePriority.UseBorders = False
        Me.lblUnpaidPenalties.StylePriority.UseFont = False
        Me.lblUnpaidPenalties.StylePriority.UseForeColor = False
        Me.lblUnpaidPenalties.StylePriority.UseTextAlignment = False
        Me.lblUnpaidPenalties.Text = "1,000,000.00"
        Me.lblUnpaidPenalties.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblUnpaidPenalties.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel64
        '
        Me.XrLabel64.BackColor = System.Drawing.Color.White
        Me.XrLabel64.BorderColor = System.Drawing.Color.Black
        Me.XrLabel64.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel64.CanGrow = False
        Me.XrLabel64.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel64.ForeColor = System.Drawing.Color.Black
        Me.XrLabel64.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 601.0!)
        Me.XrLabel64.Name = "XrLabel64"
        Me.XrLabel64.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel64.SizeF = New System.Drawing.SizeF(250.0!, 20.0!)
        Me.XrLabel64.StylePriority.UseBackColor = False
        Me.XrLabel64.StylePriority.UseBorderColor = False
        Me.XrLabel64.StylePriority.UseBorders = False
        Me.XrLabel64.StylePriority.UseFont = False
        Me.XrLabel64.StylePriority.UseForeColor = False
        Me.XrLabel64.StylePriority.UseTextAlignment = False
        Me.XrLabel64.Text = "Unpaid Penalties :"
        Me.XrLabel64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblPenalties
        '
        Me.lblPenalties.BackColor = System.Drawing.Color.White
        Me.lblPenalties.BorderColor = System.Drawing.Color.Black
        Me.lblPenalties.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblPenalties.CanGrow = False
        Me.lblPenalties.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPenalties.ForeColor = System.Drawing.Color.Black
        Me.lblPenalties.LocationFloat = New DevExpress.Utils.PointFloat(385.0!, 560.0!)
        Me.lblPenalties.Name = "lblPenalties"
        Me.lblPenalties.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPenalties.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.lblPenalties.StylePriority.UseBackColor = False
        Me.lblPenalties.StylePriority.UseBorderColor = False
        Me.lblPenalties.StylePriority.UseBorders = False
        Me.lblPenalties.StylePriority.UseFont = False
        Me.lblPenalties.StylePriority.UseForeColor = False
        Me.lblPenalties.StylePriority.UseTextAlignment = False
        Me.lblPenalties.Text = "1,000,000.00"
        Me.lblPenalties.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPenalties.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblArrears
        '
        Me.lblArrears.BackColor = System.Drawing.Color.White
        Me.lblArrears.BorderColor = System.Drawing.Color.Black
        Me.lblArrears.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblArrears.CanGrow = False
        Me.lblArrears.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArrears.ForeColor = System.Drawing.Color.Black
        Me.lblArrears.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 560.0!)
        Me.lblArrears.Name = "lblArrears"
        Me.lblArrears.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblArrears.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.lblArrears.StylePriority.UseBackColor = False
        Me.lblArrears.StylePriority.UseBorderColor = False
        Me.lblArrears.StylePriority.UseBorders = False
        Me.lblArrears.StylePriority.UseFont = False
        Me.lblArrears.StylePriority.UseForeColor = False
        Me.lblArrears.StylePriority.UseTextAlignment = False
        Me.lblArrears.Text = "1,000,000.00"
        Me.lblArrears.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblArrears.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel61
        '
        Me.XrLabel61.BackColor = System.Drawing.Color.White
        Me.XrLabel61.BorderColor = System.Drawing.Color.Black
        Me.XrLabel61.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel61.CanGrow = False
        Me.XrLabel61.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel61.ForeColor = System.Drawing.Color.Black
        Me.XrLabel61.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 560.0!)
        Me.XrLabel61.Name = "XrLabel61"
        Me.XrLabel61.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel61.SizeF = New System.Drawing.SizeF(250.0!, 20.0!)
        Me.XrLabel61.StylePriority.UseBackColor = False
        Me.XrLabel61.StylePriority.UseBorderColor = False
        Me.XrLabel61.StylePriority.UseBorders = False
        Me.XrLabel61.StylePriority.UseFont = False
        Me.XrLabel61.StylePriority.UseForeColor = False
        Me.XrLabel61.StylePriority.UseTextAlignment = False
        Me.XrLabel61.Text = "Total :"
        Me.XrLabel61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'subRpt_SOA
        '
        Me.subRpt_SOA.CanShrink = True
        Me.subRpt_SOA.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 415.0!)
        Me.subRpt_SOA.Name = "subRpt_SOA"
        Me.subRpt_SOA.SizeF = New System.Drawing.SizeF(520.0!, 145.0!)
        '
        'lblDaysDelayed
        '
        Me.lblDaysDelayed.BackColor = System.Drawing.Color.White
        Me.lblDaysDelayed.BorderColor = System.Drawing.Color.Black
        Me.lblDaysDelayed.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDaysDelayed.CanGrow = False
        Me.lblDaysDelayed.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDaysDelayed.ForeColor = System.Drawing.Color.Black
        Me.lblDaysDelayed.LocationFloat = New DevExpress.Utils.PointFloat(150.0!, 395.0!)
        Me.lblDaysDelayed.Name = "lblDaysDelayed"
        Me.lblDaysDelayed.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDaysDelayed.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblDaysDelayed.StylePriority.UseBackColor = False
        Me.lblDaysDelayed.StylePriority.UseBorderColor = False
        Me.lblDaysDelayed.StylePriority.UseBorders = False
        Me.lblDaysDelayed.StylePriority.UseFont = False
        Me.lblDaysDelayed.StylePriority.UseForeColor = False
        Me.lblDaysDelayed.StylePriority.UseTextAlignment = False
        Me.lblDaysDelayed.Text = "15"
        Me.lblDaysDelayed.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblHangingP
        '
        Me.lblHangingP.BackColor = System.Drawing.Color.White
        Me.lblHangingP.BorderColor = System.Drawing.Color.Black
        Me.lblHangingP.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblHangingP.CanGrow = False
        Me.lblHangingP.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHangingP.ForeColor = System.Drawing.Color.Black
        Me.lblHangingP.LocationFloat = New DevExpress.Utils.PointFloat(385.0!, 395.0!)
        Me.lblHangingP.Name = "lblHangingP"
        Me.lblHangingP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblHangingP.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.lblHangingP.StylePriority.UseBackColor = False
        Me.lblHangingP.StylePriority.UseBorderColor = False
        Me.lblHangingP.StylePriority.UseBorders = False
        Me.lblHangingP.StylePriority.UseFont = False
        Me.lblHangingP.StylePriority.UseForeColor = False
        Me.lblHangingP.StylePriority.UseTextAlignment = False
        Me.lblHangingP.Text = "1,000,000.00"
        Me.lblHangingP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblHangingP.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblHangingA
        '
        Me.lblHangingA.BackColor = System.Drawing.Color.White
        Me.lblHangingA.BorderColor = System.Drawing.Color.Black
        Me.lblHangingA.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblHangingA.CanGrow = False
        Me.lblHangingA.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHangingA.ForeColor = System.Drawing.Color.Black
        Me.lblHangingA.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 395.0!)
        Me.lblHangingA.Name = "lblHangingA"
        Me.lblHangingA.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblHangingA.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.lblHangingA.StylePriority.UseBackColor = False
        Me.lblHangingA.StylePriority.UseBorderColor = False
        Me.lblHangingA.StylePriority.UseBorders = False
        Me.lblHangingA.StylePriority.UseFont = False
        Me.lblHangingA.StylePriority.UseForeColor = False
        Me.lblHangingA.StylePriority.UseTextAlignment = False
        Me.lblHangingA.Text = "1,000,000.00"
        Me.lblHangingA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblHangingA.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblUpdatedP
        '
        Me.lblUpdatedP.BackColor = System.Drawing.Color.White
        Me.lblUpdatedP.BorderColor = System.Drawing.Color.Black
        Me.lblUpdatedP.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblUpdatedP.CanGrow = False
        Me.lblUpdatedP.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdatedP.ForeColor = System.Drawing.Color.Black
        Me.lblUpdatedP.LocationFloat = New DevExpress.Utils.PointFloat(385.0!, 375.0!)
        Me.lblUpdatedP.Name = "lblUpdatedP"
        Me.lblUpdatedP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblUpdatedP.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.lblUpdatedP.StylePriority.UseBackColor = False
        Me.lblUpdatedP.StylePriority.UseBorderColor = False
        Me.lblUpdatedP.StylePriority.UseBorders = False
        Me.lblUpdatedP.StylePriority.UseFont = False
        Me.lblUpdatedP.StylePriority.UseForeColor = False
        Me.lblUpdatedP.StylePriority.UseTextAlignment = False
        Me.lblUpdatedP.Text = "1,000,000.00"
        Me.lblUpdatedP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblUpdatedP.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblUpdatedA
        '
        Me.lblUpdatedA.BackColor = System.Drawing.Color.White
        Me.lblUpdatedA.BorderColor = System.Drawing.Color.Black
        Me.lblUpdatedA.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblUpdatedA.CanGrow = False
        Me.lblUpdatedA.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdatedA.ForeColor = System.Drawing.Color.Black
        Me.lblUpdatedA.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 375.0!)
        Me.lblUpdatedA.Name = "lblUpdatedA"
        Me.lblUpdatedA.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblUpdatedA.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.lblUpdatedA.StylePriority.UseBackColor = False
        Me.lblUpdatedA.StylePriority.UseBorderColor = False
        Me.lblUpdatedA.StylePriority.UseBorders = False
        Me.lblUpdatedA.StylePriority.UseFont = False
        Me.lblUpdatedA.StylePriority.UseForeColor = False
        Me.lblUpdatedA.StylePriority.UseTextAlignment = False
        Me.lblUpdatedA.Text = "1,000,000.00"
        Me.lblUpdatedA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblUpdatedA.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblBalanceP
        '
        Me.lblBalanceP.BackColor = System.Drawing.Color.White
        Me.lblBalanceP.BorderColor = System.Drawing.Color.Black
        Me.lblBalanceP.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblBalanceP.CanGrow = False
        Me.lblBalanceP.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBalanceP.ForeColor = System.Drawing.Color.Black
        Me.lblBalanceP.LocationFloat = New DevExpress.Utils.PointFloat(385.0!, 355.0!)
        Me.lblBalanceP.Name = "lblBalanceP"
        Me.lblBalanceP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBalanceP.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.lblBalanceP.StylePriority.UseBackColor = False
        Me.lblBalanceP.StylePriority.UseBorderColor = False
        Me.lblBalanceP.StylePriority.UseBorders = False
        Me.lblBalanceP.StylePriority.UseFont = False
        Me.lblBalanceP.StylePriority.UseForeColor = False
        Me.lblBalanceP.StylePriority.UseTextAlignment = False
        Me.lblBalanceP.Text = "1,000,000.00"
        Me.lblBalanceP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblBalanceP.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblBalance
        '
        Me.lblBalance.BackColor = System.Drawing.Color.White
        Me.lblBalance.BorderColor = System.Drawing.Color.Black
        Me.lblBalance.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblBalance.CanGrow = False
        Me.lblBalance.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBalance.ForeColor = System.Drawing.Color.Black
        Me.lblBalance.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 355.0!)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBalance.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.lblBalance.StylePriority.UseBackColor = False
        Me.lblBalance.StylePriority.UseBorderColor = False
        Me.lblBalance.StylePriority.UseBorders = False
        Me.lblBalance.StylePriority.UseFont = False
        Me.lblBalance.StylePriority.UseForeColor = False
        Me.lblBalance.StylePriority.UseTextAlignment = False
        Me.lblBalance.Text = "1,000,000.00"
        Me.lblBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblBalance.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel53
        '
        Me.XrLabel53.BackColor = System.Drawing.Color.White
        Me.XrLabel53.BorderColor = System.Drawing.Color.Black
        Me.XrLabel53.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel53.CanGrow = False
        Me.XrLabel53.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel53.ForeColor = System.Drawing.Color.Black
        Me.XrLabel53.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 375.0!)
        Me.XrLabel53.Name = "XrLabel53"
        Me.XrLabel53.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel53.SizeF = New System.Drawing.SizeF(210.0!, 20.0!)
        Me.XrLabel53.StylePriority.UseBackColor = False
        Me.XrLabel53.StylePriority.UseBorderColor = False
        Me.XrLabel53.StylePriority.UseBorders = False
        Me.XrLabel53.StylePriority.UseFont = False
        Me.XrLabel53.StylePriority.UseForeColor = False
        Me.XrLabel53.StylePriority.UseTextAlignment = False
        Me.XrLabel53.Text = "Balance if account is updated :"
        Me.XrLabel53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel52
        '
        Me.XrLabel52.BackColor = System.Drawing.Color.White
        Me.XrLabel52.BorderColor = System.Drawing.Color.Black
        Me.XrLabel52.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel52.CanGrow = False
        Me.XrLabel52.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel52.ForeColor = System.Drawing.Color.Black
        Me.XrLabel52.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 355.0!)
        Me.XrLabel52.Name = "XrLabel52"
        Me.XrLabel52.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel52.SizeF = New System.Drawing.SizeF(210.0!, 20.0!)
        Me.XrLabel52.StylePriority.UseBackColor = False
        Me.XrLabel52.StylePriority.UseBorderColor = False
        Me.XrLabel52.StylePriority.UseBorders = False
        Me.XrLabel52.StylePriority.UseFont = False
        Me.XrLabel52.StylePriority.UseForeColor = False
        Me.XrLabel52.StylePriority.UseTextAlignment = False
        Me.XrLabel52.Text = "Balance per Ledger :"
        Me.XrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel49
        '
        Me.XrLabel49.BackColor = System.Drawing.Color.White
        Me.XrLabel49.BorderColor = System.Drawing.Color.Black
        Me.XrLabel49.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel49.CanGrow = False
        Me.XrLabel49.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel49.ForeColor = System.Drawing.Color.Black
        Me.XrLabel49.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 335.0!)
        Me.XrLabel49.Name = "XrLabel49"
        Me.XrLabel49.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel49.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.XrLabel49.StylePriority.UseBackColor = False
        Me.XrLabel49.StylePriority.UseBorderColor = False
        Me.XrLabel49.StylePriority.UseBorders = False
        Me.XrLabel49.StylePriority.UseFont = False
        Me.XrLabel49.StylePriority.UseForeColor = False
        Me.XrLabel49.StylePriority.UseTextAlignment = False
        Me.XrLabel49.Text = "Balance of arrears :"
        Me.XrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel48
        '
        Me.XrLabel48.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel48.BorderColor = System.Drawing.Color.Black
        Me.XrLabel48.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel48.CanGrow = False
        Me.XrLabel48.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel48.ForeColor = System.Drawing.Color.White
        Me.XrLabel48.LocationFloat = New DevExpress.Utils.PointFloat(385.0!, 315.0!)
        Me.XrLabel48.Name = "XrLabel48"
        Me.XrLabel48.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel48.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.XrLabel48.StylePriority.UseBackColor = False
        Me.XrLabel48.StylePriority.UseBorderColor = False
        Me.XrLabel48.StylePriority.UseBorders = False
        Me.XrLabel48.StylePriority.UseFont = False
        Me.XrLabel48.StylePriority.UseForeColor = False
        Me.XrLabel48.StylePriority.UseTextAlignment = False
        Me.XrLabel48.Text = "Penalty"
        Me.XrLabel48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel47
        '
        Me.XrLabel47.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel47.BorderColor = System.Drawing.Color.Black
        Me.XrLabel47.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel47.CanGrow = False
        Me.XrLabel47.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel47.ForeColor = System.Drawing.Color.White
        Me.XrLabel47.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 315.0!)
        Me.XrLabel47.Name = "XrLabel47"
        Me.XrLabel47.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel47.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.XrLabel47.StylePriority.UseBackColor = False
        Me.XrLabel47.StylePriority.UseBorderColor = False
        Me.XrLabel47.StylePriority.UseBorders = False
        Me.XrLabel47.StylePriority.UseFont = False
        Me.XrLabel47.StylePriority.UseForeColor = False
        Me.XrLabel47.StylePriority.UseTextAlignment = False
        Me.XrLabel47.Text = "Arrears"
        Me.XrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel43
        '
        Me.XrLabel43.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel43.BorderColor = System.Drawing.Color.Black
        Me.XrLabel43.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel43.CanGrow = False
        Me.XrLabel43.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel43.ForeColor = System.Drawing.Color.White
        Me.XrLabel43.LocationFloat = New DevExpress.Utils.PointFloat(150.0!, 315.0!)
        Me.XrLabel43.Name = "XrLabel43"
        Me.XrLabel43.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel43.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.XrLabel43.StylePriority.UseBackColor = False
        Me.XrLabel43.StylePriority.UseBorderColor = False
        Me.XrLabel43.StylePriority.UseBorders = False
        Me.XrLabel43.StylePriority.UseFont = False
        Me.XrLabel43.StylePriority.UseForeColor = False
        Me.XrLabel43.StylePriority.UseTextAlignment = False
        Me.XrLabel43.Text = "Days Delayed"
        Me.XrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel41
        '
        Me.XrLabel41.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel41.BorderColor = System.Drawing.Color.Black
        Me.XrLabel41.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel41.CanGrow = False
        Me.XrLabel41.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel41.ForeColor = System.Drawing.Color.White
        Me.XrLabel41.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 315.0!)
        Me.XrLabel41.Name = "XrLabel41"
        Me.XrLabel41.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel41.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.XrLabel41.StylePriority.UseBackColor = False
        Me.XrLabel41.StylePriority.UseBorderColor = False
        Me.XrLabel41.StylePriority.UseBorders = False
        Me.XrLabel41.StylePriority.UseFont = False
        Me.XrLabel41.StylePriority.UseForeColor = False
        Me.XrLabel41.StylePriority.UseTextAlignment = False
        Me.XrLabel41.Text = "Monthly Due Date"
        Me.XrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAsOf
        '
        Me.lblAsOf.BackColor = System.Drawing.Color.White
        Me.lblAsOf.BorderColor = System.Drawing.Color.Black
        Me.lblAsOf.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblAsOf.CanGrow = False
        Me.lblAsOf.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAsOf.ForeColor = System.Drawing.Color.Black
        Me.lblAsOf.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 295.0!)
        Me.lblAsOf.Name = "lblAsOf"
        Me.lblAsOf.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAsOf.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.lblAsOf.StylePriority.UseBackColor = False
        Me.lblAsOf.StylePriority.UseBorderColor = False
        Me.lblAsOf.StylePriority.UseBorders = False
        Me.lblAsOf.StylePriority.UseFont = False
        Me.lblAsOf.StylePriority.UseForeColor = False
        Me.lblAsOf.StylePriority.UseTextAlignment = False
        Me.lblAsOf.Text = "December 04, 2017"
        Me.lblAsOf.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblAsOf.XlsxFormatString = "mm/dd/yyyy"
        '
        'XrLabel39
        '
        Me.XrLabel39.BackColor = System.Drawing.Color.White
        Me.XrLabel39.BorderColor = System.Drawing.Color.Black
        Me.XrLabel39.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel39.CanGrow = False
        Me.XrLabel39.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel39.ForeColor = System.Drawing.Color.Black
        Me.XrLabel39.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 295.0!)
        Me.XrLabel39.Name = "XrLabel39"
        Me.XrLabel39.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel39.SizeF = New System.Drawing.SizeF(120.0!, 20.0!)
        Me.XrLabel39.StylePriority.UseBackColor = False
        Me.XrLabel39.StylePriority.UseBorderColor = False
        Me.XrLabel39.StylePriority.UseBorders = False
        Me.XrLabel39.StylePriority.UseFont = False
        Me.XrLabel39.StylePriority.UseForeColor = False
        Me.XrLabel39.StylePriority.UseTextAlignment = False
        Me.XrLabel39.Text = "As of :"
        Me.XrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblMonthsMD
        '
        Me.lblMonthsMD.BackColor = System.Drawing.Color.White
        Me.lblMonthsMD.BorderColor = System.Drawing.Color.Black
        Me.lblMonthsMD.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblMonthsMD.CanGrow = False
        Me.lblMonthsMD.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthsMD.ForeColor = System.Drawing.Color.Black
        Me.lblMonthsMD.LocationFloat = New DevExpress.Utils.PointFloat(380.0!, 275.0!)
        Me.lblMonthsMD.Name = "lblMonthsMD"
        Me.lblMonthsMD.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMonthsMD.SizeF = New System.Drawing.SizeF(140.0!, 20.0!)
        Me.lblMonthsMD.StylePriority.UseBackColor = False
        Me.lblMonthsMD.StylePriority.UseBorderColor = False
        Me.lblMonthsMD.StylePriority.UseBorders = False
        Me.lblMonthsMD.StylePriority.UseFont = False
        Me.lblMonthsMD.StylePriority.UseForeColor = False
        Me.lblMonthsMD.StylePriority.UseTextAlignment = False
        Me.lblMonthsMD.Text = "5"
        Me.lblMonthsMD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel37
        '
        Me.XrLabel37.BackColor = System.Drawing.Color.White
        Me.XrLabel37.BorderColor = System.Drawing.Color.Black
        Me.XrLabel37.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel37.CanGrow = False
        Me.XrLabel37.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel37.ForeColor = System.Drawing.Color.Black
        Me.XrLabel37.LocationFloat = New DevExpress.Utils.PointFloat(260.0!, 275.0!)
        Me.XrLabel37.Name = "XrLabel37"
        Me.XrLabel37.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel37.SizeF = New System.Drawing.SizeF(120.0!, 20.0!)
        Me.XrLabel37.StylePriority.UseBackColor = False
        Me.XrLabel37.StylePriority.UseBorderColor = False
        Me.XrLabel37.StylePriority.UseBorders = False
        Me.XrLabel37.StylePriority.UseFont = False
        Me.XrLabel37.StylePriority.UseForeColor = False
        Me.XrLabel37.StylePriority.UseTextAlignment = False
        Me.XrLabel37.Text = "Months to MD :"
        Me.XrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblMaturityD
        '
        Me.lblMaturityD.BackColor = System.Drawing.Color.White
        Me.lblMaturityD.BorderColor = System.Drawing.Color.Black
        Me.lblMaturityD.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblMaturityD.CanGrow = False
        Me.lblMaturityD.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaturityD.ForeColor = System.Drawing.Color.Black
        Me.lblMaturityD.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 275.0!)
        Me.lblMaturityD.Name = "lblMaturityD"
        Me.lblMaturityD.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMaturityD.SizeF = New System.Drawing.SizeF(140.0!, 20.0!)
        Me.lblMaturityD.StylePriority.UseBackColor = False
        Me.lblMaturityD.StylePriority.UseBorderColor = False
        Me.lblMaturityD.StylePriority.UseBorders = False
        Me.lblMaturityD.StylePriority.UseFont = False
        Me.lblMaturityD.StylePriority.UseForeColor = False
        Me.lblMaturityD.StylePriority.UseTextAlignment = False
        Me.lblMaturityD.Text = "December 04, 2017"
        Me.lblMaturityD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblMaturityD.XlsxFormatString = "mm/dd/yyyy"
        '
        'XrLabel35
        '
        Me.XrLabel35.BackColor = System.Drawing.Color.White
        Me.XrLabel35.BorderColor = System.Drawing.Color.Black
        Me.XrLabel35.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel35.CanGrow = False
        Me.XrLabel35.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel35.ForeColor = System.Drawing.Color.Black
        Me.XrLabel35.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 275.0!)
        Me.XrLabel35.Name = "XrLabel35"
        Me.XrLabel35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel35.SizeF = New System.Drawing.SizeF(120.0!, 20.0!)
        Me.XrLabel35.StylePriority.UseBackColor = False
        Me.XrLabel35.StylePriority.UseBorderColor = False
        Me.XrLabel35.StylePriority.UseBorders = False
        Me.XrLabel35.StylePriority.UseFont = False
        Me.XrLabel35.StylePriority.UseForeColor = False
        Me.XrLabel35.StylePriority.UseTextAlignment = False
        Me.XrLabel35.Text = "Maturity Date :"
        Me.XrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblLastP
        '
        Me.lblLastP.BackColor = System.Drawing.Color.White
        Me.lblLastP.BorderColor = System.Drawing.Color.Black
        Me.lblLastP.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblLastP.CanGrow = False
        Me.lblLastP.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastP.ForeColor = System.Drawing.Color.Black
        Me.lblLastP.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 255.0!)
        Me.lblLastP.Name = "lblLastP"
        Me.lblLastP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblLastP.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.lblLastP.StylePriority.UseBackColor = False
        Me.lblLastP.StylePriority.UseBorderColor = False
        Me.lblLastP.StylePriority.UseBorders = False
        Me.lblLastP.StylePriority.UseFont = False
        Me.lblLastP.StylePriority.UseForeColor = False
        Me.lblLastP.StylePriority.UseTextAlignment = False
        Me.lblLastP.Text = "December 04, 2017"
        Me.lblLastP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblLastP.XlsxFormatString = "mm/dd/yyyy"
        '
        'XrLabel33
        '
        Me.XrLabel33.BackColor = System.Drawing.Color.White
        Me.XrLabel33.BorderColor = System.Drawing.Color.Black
        Me.XrLabel33.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel33.CanGrow = False
        Me.XrLabel33.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel33.ForeColor = System.Drawing.Color.Black
        Me.XrLabel33.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 255.0!)
        Me.XrLabel33.Name = "XrLabel33"
        Me.XrLabel33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel33.SizeF = New System.Drawing.SizeF(120.0!, 20.0!)
        Me.XrLabel33.StylePriority.UseBackColor = False
        Me.XrLabel33.StylePriority.UseBorderColor = False
        Me.XrLabel33.StylePriority.UseBorders = False
        Me.XrLabel33.StylePriority.UseFont = False
        Me.XrLabel33.StylePriority.UseForeColor = False
        Me.XrLabel33.StylePriority.UseTextAlignment = False
        Me.XrLabel33.Text = "Last Payment Date :"
        Me.XrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblDateAvailed
        '
        Me.lblDateAvailed.BackColor = System.Drawing.Color.White
        Me.lblDateAvailed.BorderColor = System.Drawing.Color.Black
        Me.lblDateAvailed.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblDateAvailed.CanGrow = False
        Me.lblDateAvailed.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateAvailed.ForeColor = System.Drawing.Color.Black
        Me.lblDateAvailed.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 235.0!)
        Me.lblDateAvailed.Name = "lblDateAvailed"
        Me.lblDateAvailed.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDateAvailed.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.lblDateAvailed.StylePriority.UseBackColor = False
        Me.lblDateAvailed.StylePriority.UseBorderColor = False
        Me.lblDateAvailed.StylePriority.UseBorders = False
        Me.lblDateAvailed.StylePriority.UseFont = False
        Me.lblDateAvailed.StylePriority.UseForeColor = False
        Me.lblDateAvailed.StylePriority.UseTextAlignment = False
        Me.lblDateAvailed.Text = "December 04, 2017"
        Me.lblDateAvailed.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblDateAvailed.XlsxFormatString = "mm/dd/yyyy"
        '
        'XrLabel30
        '
        Me.XrLabel30.BackColor = System.Drawing.Color.White
        Me.XrLabel30.BorderColor = System.Drawing.Color.Black
        Me.XrLabel30.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel30.CanGrow = False
        Me.XrLabel30.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel30.ForeColor = System.Drawing.Color.Black
        Me.XrLabel30.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 235.0!)
        Me.XrLabel30.Name = "XrLabel30"
        Me.XrLabel30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel30.SizeF = New System.Drawing.SizeF(120.0!, 20.0!)
        Me.XrLabel30.StylePriority.UseBackColor = False
        Me.XrLabel30.StylePriority.UseBorderColor = False
        Me.XrLabel30.StylePriority.UseBorders = False
        Me.XrLabel30.StylePriority.UseFont = False
        Me.XrLabel30.StylePriority.UseForeColor = False
        Me.XrLabel30.StylePriority.UseTextAlignment = False
        Me.XrLabel30.Text = "Date Availed :"
        Me.XrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblMonthlyA
        '
        Me.lblMonthlyA.BackColor = System.Drawing.Color.White
        Me.lblMonthlyA.BorderColor = System.Drawing.Color.Black
        Me.lblMonthlyA.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblMonthlyA.CanGrow = False
        Me.lblMonthlyA.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthlyA.ForeColor = System.Drawing.Color.Black
        Me.lblMonthlyA.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 215.0!)
        Me.lblMonthlyA.Name = "lblMonthlyA"
        Me.lblMonthlyA.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMonthlyA.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.lblMonthlyA.StylePriority.UseBackColor = False
        Me.lblMonthlyA.StylePriority.UseBorderColor = False
        Me.lblMonthlyA.StylePriority.UseBorders = False
        Me.lblMonthlyA.StylePriority.UseFont = False
        Me.lblMonthlyA.StylePriority.UseForeColor = False
        Me.lblMonthlyA.StylePriority.UseTextAlignment = False
        Me.lblMonthlyA.Text = "P100.00"
        Me.lblMonthlyA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblMonthlyA.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel27
        '
        Me.XrLabel27.BackColor = System.Drawing.Color.White
        Me.XrLabel27.BorderColor = System.Drawing.Color.Black
        Me.XrLabel27.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel27.CanGrow = False
        Me.XrLabel27.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel27.ForeColor = System.Drawing.Color.Black
        Me.XrLabel27.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 215.0!)
        Me.XrLabel27.Name = "XrLabel27"
        Me.XrLabel27.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel27.SizeF = New System.Drawing.SizeF(120.0!, 20.0!)
        Me.XrLabel27.StylePriority.UseBackColor = False
        Me.XrLabel27.StylePriority.UseBorderColor = False
        Me.XrLabel27.StylePriority.UseBorders = False
        Me.XrLabel27.StylePriority.UseFont = False
        Me.XrLabel27.StylePriority.UseForeColor = False
        Me.XrLabel27.StylePriority.UseTextAlignment = False
        Me.XrLabel27.Text = "Monthly Amort :"
        Me.XrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblDueDate
        '
        Me.lblDueDate.BackColor = System.Drawing.Color.White
        Me.lblDueDate.BorderColor = System.Drawing.Color.Black
        Me.lblDueDate.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblDueDate.CanGrow = False
        Me.lblDueDate.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDueDate.ForeColor = System.Drawing.Color.Black
        Me.lblDueDate.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 195.0!)
        Me.lblDueDate.Name = "lblDueDate"
        Me.lblDueDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDueDate.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.lblDueDate.StylePriority.UseBackColor = False
        Me.lblDueDate.StylePriority.UseBorderColor = False
        Me.lblDueDate.StylePriority.UseBorders = False
        Me.lblDueDate.StylePriority.UseFont = False
        Me.lblDueDate.StylePriority.UseForeColor = False
        Me.lblDueDate.StylePriority.UseTextAlignment = False
        Me.lblDueDate.Text = "5"
        Me.lblDueDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel25
        '
        Me.XrLabel25.BackColor = System.Drawing.Color.White
        Me.XrLabel25.BorderColor = System.Drawing.Color.Black
        Me.XrLabel25.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel25.CanGrow = False
        Me.XrLabel25.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel25.ForeColor = System.Drawing.Color.Black
        Me.XrLabel25.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 195.0!)
        Me.XrLabel25.Name = "XrLabel25"
        Me.XrLabel25.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel25.SizeF = New System.Drawing.SizeF(120.0!, 20.0!)
        Me.XrLabel25.StylePriority.UseBackColor = False
        Me.XrLabel25.StylePriority.UseBorderColor = False
        Me.XrLabel25.StylePriority.UseBorders = False
        Me.XrLabel25.StylePriority.UseFont = False
        Me.XrLabel25.StylePriority.UseForeColor = False
        Me.XrLabel25.StylePriority.UseTextAlignment = False
        Me.XrLabel25.Text = "Due Date :"
        Me.XrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblTotalPayments
        '
        Me.lblTotalPayments.BackColor = System.Drawing.Color.White
        Me.lblTotalPayments.BorderColor = System.Drawing.Color.Black
        Me.lblTotalPayments.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblTotalPayments.CanGrow = False
        Me.lblTotalPayments.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPayments.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPayments.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 175.0!)
        Me.lblTotalPayments.Name = "lblTotalPayments"
        Me.lblTotalPayments.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotalPayments.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.lblTotalPayments.StylePriority.UseBackColor = False
        Me.lblTotalPayments.StylePriority.UseBorderColor = False
        Me.lblTotalPayments.StylePriority.UseBorders = False
        Me.lblTotalPayments.StylePriority.UseFont = False
        Me.lblTotalPayments.StylePriority.UseForeColor = False
        Me.lblTotalPayments.StylePriority.UseTextAlignment = False
        Me.lblTotalPayments.Text = "P200.00"
        Me.lblTotalPayments.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblTotalPayments.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel21
        '
        Me.XrLabel21.BackColor = System.Drawing.Color.White
        Me.XrLabel21.BorderColor = System.Drawing.Color.Black
        Me.XrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel21.CanGrow = False
        Me.XrLabel21.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel21.ForeColor = System.Drawing.Color.Black
        Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 175.0!)
        Me.XrLabel21.Name = "XrLabel21"
        Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel21.SizeF = New System.Drawing.SizeF(120.0!, 20.0!)
        Me.XrLabel21.StylePriority.UseBackColor = False
        Me.XrLabel21.StylePriority.UseBorderColor = False
        Me.XrLabel21.StylePriority.UseBorders = False
        Me.XrLabel21.StylePriority.UseFont = False
        Me.XrLabel21.StylePriority.UseForeColor = False
        Me.XrLabel21.StylePriority.UseTextAlignment = False
        Me.XrLabel21.Text = "Total Payments :"
        Me.XrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblFaceAmount
        '
        Me.lblFaceAmount.BackColor = System.Drawing.Color.White
        Me.lblFaceAmount.BorderColor = System.Drawing.Color.Black
        Me.lblFaceAmount.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblFaceAmount.CanGrow = False
        Me.lblFaceAmount.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFaceAmount.ForeColor = System.Drawing.Color.Black
        Me.lblFaceAmount.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 155.0!)
        Me.lblFaceAmount.Name = "lblFaceAmount"
        Me.lblFaceAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFaceAmount.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.lblFaceAmount.StylePriority.UseBackColor = False
        Me.lblFaceAmount.StylePriority.UseBorderColor = False
        Me.lblFaceAmount.StylePriority.UseBorders = False
        Me.lblFaceAmount.StylePriority.UseFont = False
        Me.lblFaceAmount.StylePriority.UseForeColor = False
        Me.lblFaceAmount.StylePriority.UseTextAlignment = False
        Me.lblFaceAmount.Text = "P1,000,500,000.00"
        Me.lblFaceAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblFaceAmount.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel18
        '
        Me.XrLabel18.BackColor = System.Drawing.Color.White
        Me.XrLabel18.BorderColor = System.Drawing.Color.Black
        Me.XrLabel18.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel18.CanGrow = False
        Me.XrLabel18.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel18.ForeColor = System.Drawing.Color.Black
        Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 155.0!)
        Me.XrLabel18.Name = "XrLabel18"
        Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel18.SizeF = New System.Drawing.SizeF(120.0!, 20.0!)
        Me.XrLabel18.StylePriority.UseBackColor = False
        Me.XrLabel18.StylePriority.UseBorderColor = False
        Me.XrLabel18.StylePriority.UseBorders = False
        Me.XrLabel18.StylePriority.UseFont = False
        Me.XrLabel18.StylePriority.UseForeColor = False
        Me.XrLabel18.StylePriority.UseTextAlignment = False
        Me.XrLabel18.Text = "Face Amount :"
        Me.XrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblPrincipal
        '
        Me.lblPrincipal.BackColor = System.Drawing.Color.White
        Me.lblPrincipal.BorderColor = System.Drawing.Color.Black
        Me.lblPrincipal.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblPrincipal.CanGrow = False
        Me.lblPrincipal.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipal.ForeColor = System.Drawing.Color.Black
        Me.lblPrincipal.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 135.0!)
        Me.lblPrincipal.Name = "lblPrincipal"
        Me.lblPrincipal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrincipal.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.lblPrincipal.StylePriority.UseBackColor = False
        Me.lblPrincipal.StylePriority.UseBorderColor = False
        Me.lblPrincipal.StylePriority.UseBorders = False
        Me.lblPrincipal.StylePriority.UseFont = False
        Me.lblPrincipal.StylePriority.UseForeColor = False
        Me.lblPrincipal.StylePriority.UseTextAlignment = False
        Me.lblPrincipal.Text = "P1,000,000,000.00"
        Me.lblPrincipal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblPrincipal.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel15
        '
        Me.XrLabel15.BackColor = System.Drawing.Color.White
        Me.XrLabel15.BorderColor = System.Drawing.Color.Black
        Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel15.CanGrow = False
        Me.XrLabel15.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel15.ForeColor = System.Drawing.Color.Black
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 135.0!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(120.0!, 20.0!)
        Me.XrLabel15.StylePriority.UseBackColor = False
        Me.XrLabel15.StylePriority.UseBorderColor = False
        Me.XrLabel15.StylePriority.UseBorders = False
        Me.XrLabel15.StylePriority.UseFont = False
        Me.XrLabel15.StylePriority.UseForeColor = False
        Me.XrLabel15.StylePriority.UseTextAlignment = False
        Me.XrLabel15.Text = "Principal :"
        Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblCollateral
        '
        Me.lblCollateral.BackColor = System.Drawing.Color.White
        Me.lblCollateral.BorderColor = System.Drawing.Color.Black
        Me.lblCollateral.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblCollateral.CanGrow = False
        Me.lblCollateral.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCollateral.ForeColor = System.Drawing.Color.Black
        Me.lblCollateral.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 115.0!)
        Me.lblCollateral.Name = "lblCollateral"
        Me.lblCollateral.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCollateral.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.lblCollateral.StylePriority.UseBackColor = False
        Me.lblCollateral.StylePriority.UseBorderColor = False
        Me.lblCollateral.StylePriority.UseBorders = False
        Me.lblCollateral.StylePriority.UseFont = False
        Me.lblCollateral.StylePriority.UseForeColor = False
        Me.lblCollateral.StylePriority.UseTextAlignment = False
        Me.lblCollateral.Text = "2010 Toyota Avanze YJD597"
        Me.lblCollateral.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel13
        '
        Me.XrLabel13.BackColor = System.Drawing.Color.White
        Me.XrLabel13.BorderColor = System.Drawing.Color.Black
        Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel13.CanGrow = False
        Me.XrLabel13.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel13.ForeColor = System.Drawing.Color.Black
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 115.0!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(120.0!, 20.0!)
        Me.XrLabel13.StylePriority.UseBackColor = False
        Me.XrLabel13.StylePriority.UseBorderColor = False
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.StylePriority.UseFont = False
        Me.XrLabel13.StylePriority.UseForeColor = False
        Me.XrLabel13.StylePriority.UseTextAlignment = False
        Me.XrLabel13.Text = "Collateral :"
        Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblAccountNumber
        '
        Me.lblAccountNumber.BackColor = System.Drawing.Color.White
        Me.lblAccountNumber.BorderColor = System.Drawing.Color.Black
        Me.lblAccountNumber.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblAccountNumber.CanGrow = False
        Me.lblAccountNumber.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountNumber.ForeColor = System.Drawing.Color.Black
        Me.lblAccountNumber.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 95.0!)
        Me.lblAccountNumber.Name = "lblAccountNumber"
        Me.lblAccountNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountNumber.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.lblAccountNumber.StylePriority.UseBackColor = False
        Me.lblAccountNumber.StylePriority.UseBorderColor = False
        Me.lblAccountNumber.StylePriority.UseBorders = False
        Me.lblAccountNumber.StylePriority.UseFont = False
        Me.lblAccountNumber.StylePriority.UseForeColor = False
        Me.lblAccountNumber.StylePriority.UseTextAlignment = False
        Me.lblAccountNumber.Text = "VL-1000"
        Me.lblAccountNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel10
        '
        Me.XrLabel10.BackColor = System.Drawing.Color.White
        Me.XrLabel10.BorderColor = System.Drawing.Color.Black
        Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel10.CanGrow = False
        Me.XrLabel10.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel10.ForeColor = System.Drawing.Color.Black
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 95.0!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(120.0!, 20.0!)
        Me.XrLabel10.StylePriority.UseBackColor = False
        Me.XrLabel10.StylePriority.UseBorderColor = False
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseForeColor = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = "Account Number :"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.White
        Me.lblName.BorderColor = System.Drawing.Color.Black
        Me.lblName.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblName.CanGrow = False
        Me.lblName.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.Black
        Me.lblName.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 75.0!)
        Me.lblName.Name = "lblName"
        Me.lblName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblName.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.lblName.StylePriority.UseBackColor = False
        Me.lblName.StylePriority.UseBorderColor = False
        Me.lblName.StylePriority.UseBorders = False
        Me.lblName.StylePriority.UseFont = False
        Me.lblName.StylePriority.UseForeColor = False
        Me.lblName.StylePriority.UseTextAlignment = False
        Me.lblName.Text = "Mark Kevin M. Gotico"
        Me.lblName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel7
        '
        Me.XrLabel7.BackColor = System.Drawing.Color.White
        Me.XrLabel7.BorderColor = System.Drawing.Color.Black
        Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel7.CanGrow = False
        Me.XrLabel7.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.ForeColor = System.Drawing.Color.Black
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 75.0!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(120.0!, 20.0!)
        Me.XrLabel7.StylePriority.UseBackColor = False
        Me.XrLabel7.StylePriority.UseBorderColor = False
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseForeColor = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "Name :"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel4
        '
        Me.XrLabel4.BackColor = System.Drawing.Color.White
        Me.XrLabel4.BorderColor = System.Drawing.Color.Black
        Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel4.CanGrow = False
        Me.XrLabel4.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.ForeColor = System.Drawing.Color.Black
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 50.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(520.0!, 25.0!)
        Me.XrLabel4.StylePriority.UseBackColor = False
        Me.XrLabel4.StylePriority.UseBorderColor = False
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseForeColor = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "Statement of Account"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblContact
        '
        Me.lblContact.BackColor = System.Drawing.Color.White
        Me.lblContact.BorderColor = System.Drawing.Color.Black
        Me.lblContact.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblContact.CanGrow = False
        Me.lblContact.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContact.ForeColor = System.Drawing.Color.Black
        Me.lblContact.LocationFloat = New DevExpress.Utils.PointFloat(200.0!, 30.0!)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblContact.SizeF = New System.Drawing.SizeF(320.0!, 20.0!)
        Me.lblContact.StylePriority.UseBackColor = False
        Me.lblContact.StylePriority.UseBorderColor = False
        Me.lblContact.StylePriority.UseBorders = False
        Me.lblContact.StylePriority.UseFont = False
        Me.lblContact.StylePriority.UseForeColor = False
        Me.lblContact.StylePriority.UseTextAlignment = False
        Me.lblContact.Text = "(032) 3455493-95, 238-8737, 0922-8654506, 0917-3084823"
        Me.lblContact.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.BackColor = System.Drawing.Color.White
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(200.0!, 50.0!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        Me.XrPictureBox1.StylePriority.UseBackColor = False
        '
        'lblAddress
        '
        Me.lblAddress.BackColor = System.Drawing.Color.White
        Me.lblAddress.BorderColor = System.Drawing.Color.Black
        Me.lblAddress.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblAddress.CanGrow = False
        Me.lblAddress.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress.ForeColor = System.Drawing.Color.Black
        Me.lblAddress.LocationFloat = New DevExpress.Utils.PointFloat(200.0!, 0.0!)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAddress.SizeF = New System.Drawing.SizeF(320.0!, 30.0!)
        Me.lblAddress.StylePriority.UseBackColor = False
        Me.lblAddress.StylePriority.UseBorderColor = False
        Me.lblAddress.StylePriority.UseBorders = False
        Me.lblAddress.StylePriority.UseFont = False
        Me.lblAddress.StylePriority.UseForeColor = False
        Me.lblAddress.StylePriority.UseTextAlignment = False
        Me.lblAddress.Text = "Sheridan Bldg. Ouano Ave., NRA Subangdaku, Mandaue City 6014, PH"
        Me.lblAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblReceived_2
        '
        Me.lblReceived_2.BackColor = System.Drawing.Color.White
        Me.lblReceived_2.BorderColor = System.Drawing.Color.Black
        Me.lblReceived_2.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblReceived_2.CanGrow = False
        Me.lblReceived_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceived_2.ForeColor = System.Drawing.Color.Black
        Me.lblReceived_2.LocationFloat = New DevExpress.Utils.PointFloat(920.0!, 555.0!)
        Me.lblReceived_2.Name = "lblReceived_2"
        Me.lblReceived_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblReceived_2.SizeF = New System.Drawing.SizeF(130.0!, 80.0!)
        Me.lblReceived_2.StylePriority.UseBackColor = False
        Me.lblReceived_2.StylePriority.UseBorderColor = False
        Me.lblReceived_2.StylePriority.UseBorders = False
        Me.lblReceived_2.StylePriority.UseFont = False
        Me.lblReceived_2.StylePriority.UseForeColor = False
        Me.lblReceived_2.StylePriority.UseTextAlignment = False
        Me.lblReceived_2.Text = "Mark Kevin M. Gotico"
        Me.lblReceived_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'lblNoted_2
        '
        Me.lblNoted_2.BackColor = System.Drawing.Color.White
        Me.lblNoted_2.BorderColor = System.Drawing.Color.Black
        Me.lblNoted_2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblNoted_2.CanGrow = False
        Me.lblNoted_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoted_2.ForeColor = System.Drawing.Color.Black
        Me.lblNoted_2.LocationFloat = New DevExpress.Utils.PointFloat(790.0!, 555.0!)
        Me.lblNoted_2.Name = "lblNoted_2"
        Me.lblNoted_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNoted_2.SizeF = New System.Drawing.SizeF(130.0!, 80.0!)
        Me.lblNoted_2.StylePriority.UseBackColor = False
        Me.lblNoted_2.StylePriority.UseBorderColor = False
        Me.lblNoted_2.StylePriority.UseBorders = False
        Me.lblNoted_2.StylePriority.UseFont = False
        Me.lblNoted_2.StylePriority.UseForeColor = False
        Me.lblNoted_2.StylePriority.UseTextAlignment = False
        Me.lblNoted_2.Text = "Mark Kevin M. Gotico"
        Me.lblNoted_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'XrLabel51
        '
        Me.XrLabel51.BackColor = System.Drawing.Color.White
        Me.XrLabel51.BorderColor = System.Drawing.Color.Black
        Me.XrLabel51.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel51.CanGrow = False
        Me.XrLabel51.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel51.ForeColor = System.Drawing.Color.Black
        Me.XrLabel51.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 670.0!)
        Me.XrLabel51.Name = "XrLabel51"
        Me.XrLabel51.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel51.SizeF = New System.Drawing.SizeF(520.0!, 25.0!)
        Me.XrLabel51.StylePriority.UseBackColor = False
        Me.XrLabel51.StylePriority.UseBorderColor = False
        Me.XrLabel51.StylePriority.UseBorders = False
        Me.XrLabel51.StylePriority.UseFont = False
        Me.XrLabel51.StylePriority.UseForeColor = False
        Me.XrLabel51.StylePriority.UseTextAlignment = False
        Me.XrLabel51.Text = "         Above figures are subject to audit and, therefore, are not final."
        Me.XrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel50
        '
        Me.XrLabel50.BackColor = System.Drawing.Color.White
        Me.XrLabel50.BorderColor = System.Drawing.Color.Black
        Me.XrLabel50.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel50.CanGrow = False
        Me.XrLabel50.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel50.ForeColor = System.Drawing.Color.Black
        Me.XrLabel50.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 645.0!)
        Me.XrLabel50.Name = "XrLabel50"
        Me.XrLabel50.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel50.SizeF = New System.Drawing.SizeF(520.0!, 25.0!)
        Me.XrLabel50.StylePriority.UseBackColor = False
        Me.XrLabel50.StylePriority.UseBorderColor = False
        Me.XrLabel50.StylePriority.UseBorders = False
        Me.XrLabel50.StylePriority.UseFont = False
        Me.XrLabel50.StylePriority.UseForeColor = False
        Me.XrLabel50.StylePriority.UseTextAlignment = False
        Me.XrLabel50.Text = "Note :  Penalties are computed as of the date of this statement."
        Me.XrLabel50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel45
        '
        Me.XrLabel45.BackColor = System.Drawing.Color.White
        Me.XrLabel45.BorderColor = System.Drawing.Color.Black
        Me.XrLabel45.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel45.CanGrow = False
        Me.XrLabel45.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel45.ForeColor = System.Drawing.Color.Black
        Me.XrLabel45.LocationFloat = New DevExpress.Utils.PointFloat(790.0!, 530.0!)
        Me.XrLabel45.Name = "XrLabel45"
        Me.XrLabel45.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel45.SizeF = New System.Drawing.SizeF(130.0!, 25.0!)
        Me.XrLabel45.StylePriority.UseBackColor = False
        Me.XrLabel45.StylePriority.UseBorderColor = False
        Me.XrLabel45.StylePriority.UseBorders = False
        Me.XrLabel45.StylePriority.UseFont = False
        Me.XrLabel45.StylePriority.UseForeColor = False
        Me.XrLabel45.StylePriority.UseTextAlignment = False
        Me.XrLabel45.Text = "Noted By :"
        Me.XrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel44
        '
        Me.XrLabel44.BackColor = System.Drawing.Color.White
        Me.XrLabel44.BorderColor = System.Drawing.Color.Black
        Me.XrLabel44.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel44.CanGrow = False
        Me.XrLabel44.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel44.ForeColor = System.Drawing.Color.Black
        Me.XrLabel44.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 530.0!)
        Me.XrLabel44.Name = "XrLabel44"
        Me.XrLabel44.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel44.SizeF = New System.Drawing.SizeF(130.0!, 25.0!)
        Me.XrLabel44.StylePriority.UseBackColor = False
        Me.XrLabel44.StylePriority.UseBorderColor = False
        Me.XrLabel44.StylePriority.UseBorders = False
        Me.XrLabel44.StylePriority.UseFont = False
        Me.XrLabel44.StylePriority.UseForeColor = False
        Me.XrLabel44.StylePriority.UseTextAlignment = False
        Me.XrLabel44.Text = "Prepared By :"
        Me.XrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblPrepared_2
        '
        Me.lblPrepared_2.BackColor = System.Drawing.Color.White
        Me.lblPrepared_2.BorderColor = System.Drawing.Color.Black
        Me.lblPrepared_2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPrepared_2.CanGrow = False
        Me.lblPrepared_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrepared_2.ForeColor = System.Drawing.Color.Black
        Me.lblPrepared_2.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 555.0!)
        Me.lblPrepared_2.Name = "lblPrepared_2"
        Me.lblPrepared_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrepared_2.SizeF = New System.Drawing.SizeF(130.0!, 80.0!)
        Me.lblPrepared_2.StylePriority.UseBackColor = False
        Me.lblPrepared_2.StylePriority.UseBorderColor = False
        Me.lblPrepared_2.StylePriority.UseBorders = False
        Me.lblPrepared_2.StylePriority.UseFont = False
        Me.lblPrepared_2.StylePriority.UseForeColor = False
        Me.lblPrepared_2.StylePriority.UseTextAlignment = False
        Me.lblPrepared_2.Text = "Mark Kevin M. Gotico"
        Me.lblPrepared_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'XrLabel46
        '
        Me.XrLabel46.BackColor = System.Drawing.Color.White
        Me.XrLabel46.BorderColor = System.Drawing.Color.Black
        Me.XrLabel46.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel46.CanGrow = False
        Me.XrLabel46.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel46.ForeColor = System.Drawing.Color.Black
        Me.XrLabel46.LocationFloat = New DevExpress.Utils.PointFloat(920.0!, 530.0!)
        Me.XrLabel46.Name = "XrLabel46"
        Me.XrLabel46.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel46.SizeF = New System.Drawing.SizeF(130.0!, 25.0!)
        Me.XrLabel46.StylePriority.UseBackColor = False
        Me.XrLabel46.StylePriority.UseBorderColor = False
        Me.XrLabel46.StylePriority.UseBorders = False
        Me.XrLabel46.StylePriority.UseFont = False
        Me.XrLabel46.StylePriority.UseForeColor = False
        Me.XrLabel46.StylePriority.UseTextAlignment = False
        Me.XrLabel46.Text = "Received By :"
        Me.XrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblTotal_2
        '
        Me.lblTotal_2.BackColor = System.Drawing.Color.White
        Me.lblTotal_2.BorderColor = System.Drawing.Color.Black
        Me.lblTotal_2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblTotal_2.BorderWidth = 3.0!
        Me.lblTotal_2.CanGrow = False
        Me.lblTotal_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal_2.ForeColor = System.Drawing.Color.Black
        Me.lblTotal_2.LocationFloat = New DevExpress.Utils.PointFloat(880.0!, 500.0!)
        Me.lblTotal_2.Name = "lblTotal_2"
        Me.lblTotal_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotal_2.SizeF = New System.Drawing.SizeF(170.0!, 25.0!)
        Me.lblTotal_2.StylePriority.UseBackColor = False
        Me.lblTotal_2.StylePriority.UseBorderColor = False
        Me.lblTotal_2.StylePriority.UseBorders = False
        Me.lblTotal_2.StylePriority.UseBorderWidth = False
        Me.lblTotal_2.StylePriority.UseFont = False
        Me.lblTotal_2.StylePriority.UseForeColor = False
        Me.lblTotal_2.StylePriority.UseTextAlignment = False
        Me.lblTotal_2.Text = "300.00"
        Me.lblTotal_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblTotal_2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel42
        '
        Me.XrLabel42.BackColor = System.Drawing.Color.White
        Me.XrLabel42.BorderColor = System.Drawing.Color.Black
        Me.XrLabel42.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel42.CanGrow = False
        Me.XrLabel42.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel42.ForeColor = System.Drawing.Color.Black
        Me.XrLabel42.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 500.0!)
        Me.XrLabel42.Name = "XrLabel42"
        Me.XrLabel42.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel42.SizeF = New System.Drawing.SizeF(350.0!, 25.0!)
        Me.XrLabel42.StylePriority.UseBackColor = False
        Me.XrLabel42.StylePriority.UseBorderColor = False
        Me.XrLabel42.StylePriority.UseBorders = False
        Me.XrLabel42.StylePriority.UseFont = False
        Me.XrLabel42.StylePriority.UseForeColor = False
        Me.XrLabel42.StylePriority.UseTextAlignment = False
        Me.XrLabel42.Text = "Total Amount Due :"
        Me.XrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblOthersAmount_2
        '
        Me.lblOthersAmount_2.BackColor = System.Drawing.Color.White
        Me.lblOthersAmount_2.BorderColor = System.Drawing.Color.Black
        Me.lblOthersAmount_2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblOthersAmount_2.CanGrow = False
        Me.lblOthersAmount_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOthersAmount_2.ForeColor = System.Drawing.Color.Black
        Me.lblOthersAmount_2.LocationFloat = New DevExpress.Utils.PointFloat(880.0!, 425.0!)
        Me.lblOthersAmount_2.Name = "lblOthersAmount_2"
        Me.lblOthersAmount_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblOthersAmount_2.SizeF = New System.Drawing.SizeF(170.0!, 25.0!)
        Me.lblOthersAmount_2.StylePriority.UseBackColor = False
        Me.lblOthersAmount_2.StylePriority.UseBorderColor = False
        Me.lblOthersAmount_2.StylePriority.UseBorders = False
        Me.lblOthersAmount_2.StylePriority.UseFont = False
        Me.lblOthersAmount_2.StylePriority.UseForeColor = False
        Me.lblOthersAmount_2.StylePriority.UseTextAlignment = False
        Me.lblOthersAmount_2.Text = "0.00"
        Me.lblOthersAmount_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblOthersAmount_2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblRebate_2
        '
        Me.lblRebate_2.BackColor = System.Drawing.Color.White
        Me.lblRebate_2.BorderColor = System.Drawing.Color.Black
        Me.lblRebate_2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblRebate_2.CanGrow = False
        Me.lblRebate_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRebate_2.ForeColor = System.Drawing.Color.Black
        Me.lblRebate_2.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 450.0!)
        Me.lblRebate_2.Name = "lblRebate_2"
        Me.lblRebate_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRebate_2.SizeF = New System.Drawing.SizeF(350.0!, 25.0!)
        Me.lblRebate_2.StylePriority.UseBackColor = False
        Me.lblRebate_2.StylePriority.UseBorderColor = False
        Me.lblRebate_2.StylePriority.UseBorders = False
        Me.lblRebate_2.StylePriority.UseFont = False
        Me.lblRebate_2.StylePriority.UseForeColor = False
        Me.lblRebate_2.StylePriority.UseTextAlignment = False
        Me.lblRebate_2.Text = "Rebate as of 12.13.17 :"
        Me.lblRebate_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblRebate_2.Visible = False
        '
        'lblOverdue_2
        '
        Me.lblOverdue_2.BackColor = System.Drawing.Color.White
        Me.lblOverdue_2.BorderColor = System.Drawing.Color.Black
        Me.lblOverdue_2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblOverdue_2.BorderWidth = 3.0!
        Me.lblOverdue_2.CanGrow = False
        Me.lblOverdue_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverdue_2.ForeColor = System.Drawing.Color.Black
        Me.lblOverdue_2.LocationFloat = New DevExpress.Utils.PointFloat(880.0!, 475.0!)
        Me.lblOverdue_2.Name = "lblOverdue_2"
        Me.lblOverdue_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblOverdue_2.SizeF = New System.Drawing.SizeF(170.0!, 25.0!)
        Me.lblOverdue_2.StylePriority.UseBackColor = False
        Me.lblOverdue_2.StylePriority.UseBorderColor = False
        Me.lblOverdue_2.StylePriority.UseBorders = False
        Me.lblOverdue_2.StylePriority.UseBorderWidth = False
        Me.lblOverdue_2.StylePriority.UseFont = False
        Me.lblOverdue_2.StylePriority.UseForeColor = False
        Me.lblOverdue_2.StylePriority.UseTextAlignment = False
        Me.lblOverdue_2.Text = "300.00"
        Me.lblOverdue_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblOverdue_2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel3
        '
        Me.XrLabel3.BackColor = System.Drawing.Color.White
        Me.XrLabel3.BorderColor = System.Drawing.Color.Black
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.CanGrow = False
        Me.XrLabel3.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.ForeColor = System.Drawing.Color.Black
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 475.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(350.0!, 25.0!)
        Me.XrLabel3.StylePriority.UseBackColor = False
        Me.XrLabel3.StylePriority.UseBorderColor = False
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseForeColor = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "Overdue (to update) :"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblRebateA_2
        '
        Me.lblRebateA_2.BackColor = System.Drawing.Color.White
        Me.lblRebateA_2.BorderColor = System.Drawing.Color.Black
        Me.lblRebateA_2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblRebateA_2.CanGrow = False
        Me.lblRebateA_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRebateA_2.ForeColor = System.Drawing.Color.Black
        Me.lblRebateA_2.LocationFloat = New DevExpress.Utils.PointFloat(880.0!, 450.0!)
        Me.lblRebateA_2.Name = "lblRebateA_2"
        Me.lblRebateA_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRebateA_2.SizeF = New System.Drawing.SizeF(170.0!, 25.0!)
        Me.lblRebateA_2.StylePriority.UseBackColor = False
        Me.lblRebateA_2.StylePriority.UseBorderColor = False
        Me.lblRebateA_2.StylePriority.UseBorders = False
        Me.lblRebateA_2.StylePriority.UseFont = False
        Me.lblRebateA_2.StylePriority.UseForeColor = False
        Me.lblRebateA_2.StylePriority.UseTextAlignment = False
        Me.lblRebateA_2.Text = "0.00"
        Me.lblRebateA_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblRebateA_2.Visible = False
        Me.lblRebateA_2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblUnpaidDate_2
        '
        Me.lblUnpaidDate_2.BackColor = System.Drawing.Color.White
        Me.lblUnpaidDate_2.BorderColor = System.Drawing.Color.Black
        Me.lblUnpaidDate_2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblUnpaidDate_2.CanGrow = False
        Me.lblUnpaidDate_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnpaidDate_2.ForeColor = System.Drawing.Color.Black
        Me.lblUnpaidDate_2.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 375.0!)
        Me.lblUnpaidDate_2.Name = "lblUnpaidDate_2"
        Me.lblUnpaidDate_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblUnpaidDate_2.SizeF = New System.Drawing.SizeF(350.0!, 25.0!)
        Me.lblUnpaidDate_2.StylePriority.UseBackColor = False
        Me.lblUnpaidDate_2.StylePriority.UseBorderColor = False
        Me.lblUnpaidDate_2.StylePriority.UseBorders = False
        Me.lblUnpaidDate_2.StylePriority.UseFont = False
        Me.lblUnpaidDate_2.StylePriority.UseForeColor = False
        Me.lblUnpaidDate_2.StylePriority.UseTextAlignment = False
        Me.lblUnpaidDate_2.Text = "Unpaid Penalties (5% from 12.23.17–10.31.17) :"
        Me.lblUnpaidDate_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblBalance_2
        '
        Me.lblBalance_2.BackColor = System.Drawing.Color.White
        Me.lblBalance_2.BorderColor = System.Drawing.Color.Black
        Me.lblBalance_2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblBalance_2.CanGrow = False
        Me.lblBalance_2.Font = New System.Drawing.Font("Century Gothic", 11.25!)
        Me.lblBalance_2.ForeColor = System.Drawing.Color.Black
        Me.lblBalance_2.LocationFloat = New DevExpress.Utils.PointFloat(880.0!, 325.0!)
        Me.lblBalance_2.Name = "lblBalance_2"
        Me.lblBalance_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBalance_2.SizeF = New System.Drawing.SizeF(170.0!, 25.0!)
        Me.lblBalance_2.StylePriority.UseBackColor = False
        Me.lblBalance_2.StylePriority.UseBorderColor = False
        Me.lblBalance_2.StylePriority.UseBorders = False
        Me.lblBalance_2.StylePriority.UseFont = False
        Me.lblBalance_2.StylePriority.UseForeColor = False
        Me.lblBalance_2.StylePriority.UseTextAlignment = False
        Me.lblBalance_2.Text = "100.00"
        Me.lblBalance_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblBalance_2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel32
        '
        Me.XrLabel32.BackColor = System.Drawing.Color.White
        Me.XrLabel32.BorderColor = System.Drawing.Color.Black
        Me.XrLabel32.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel32.CanGrow = False
        Me.XrLabel32.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel32.ForeColor = System.Drawing.Color.Black
        Me.XrLabel32.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 325.0!)
        Me.XrLabel32.Name = "XrLabel32"
        Me.XrLabel32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel32.SizeF = New System.Drawing.SizeF(350.0!, 25.0!)
        Me.XrLabel32.StylePriority.UseBackColor = False
        Me.XrLabel32.StylePriority.UseBorderColor = False
        Me.XrLabel32.StylePriority.UseBorders = False
        Me.XrLabel32.StylePriority.UseFont = False
        Me.XrLabel32.StylePriority.UseForeColor = False
        Me.XrLabel32.StylePriority.UseTextAlignment = False
        Me.XrLabel32.Text = "Balance per Ledger :"
        Me.XrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblUnpaidPenalties_2
        '
        Me.lblUnpaidPenalties_2.BackColor = System.Drawing.Color.White
        Me.lblUnpaidPenalties_2.BorderColor = System.Drawing.Color.Black
        Me.lblUnpaidPenalties_2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblUnpaidPenalties_2.CanGrow = False
        Me.lblUnpaidPenalties_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnpaidPenalties_2.ForeColor = System.Drawing.Color.Black
        Me.lblUnpaidPenalties_2.LocationFloat = New DevExpress.Utils.PointFloat(880.0!, 375.0!)
        Me.lblUnpaidPenalties_2.Name = "lblUnpaidPenalties_2"
        Me.lblUnpaidPenalties_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblUnpaidPenalties_2.SizeF = New System.Drawing.SizeF(170.0!, 25.0!)
        Me.lblUnpaidPenalties_2.StylePriority.UseBackColor = False
        Me.lblUnpaidPenalties_2.StylePriority.UseBorderColor = False
        Me.lblUnpaidPenalties_2.StylePriority.UseBorders = False
        Me.lblUnpaidPenalties_2.StylePriority.UseFont = False
        Me.lblUnpaidPenalties_2.StylePriority.UseForeColor = False
        Me.lblUnpaidPenalties_2.StylePriority.UseTextAlignment = False
        Me.lblUnpaidPenalties_2.Text = "100.00"
        Me.lblUnpaidPenalties_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblUnpaidPenalties_2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblOthers_2
        '
        Me.lblOthers_2.BackColor = System.Drawing.Color.White
        Me.lblOthers_2.BorderColor = System.Drawing.Color.Black
        Me.lblOthers_2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblOthers_2.CanGrow = False
        Me.lblOthers_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOthers_2.ForeColor = System.Drawing.Color.Black
        Me.lblOthers_2.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 425.0!)
        Me.lblOthers_2.Name = "lblOthers_2"
        Me.lblOthers_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblOthers_2.SizeF = New System.Drawing.SizeF(350.0!, 25.0!)
        Me.lblOthers_2.StylePriority.UseBackColor = False
        Me.lblOthers_2.StylePriority.UseBorderColor = False
        Me.lblOthers_2.StylePriority.UseBorders = False
        Me.lblOthers_2.StylePriority.UseFont = False
        Me.lblOthers_2.StylePriority.UseForeColor = False
        Me.lblOthers_2.StylePriority.UseTextAlignment = False
        Me.lblOthers_2.Text = "Others :"
        Me.lblOthers_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblPenalties_2
        '
        Me.lblPenalties_2.BackColor = System.Drawing.Color.White
        Me.lblPenalties_2.BorderColor = System.Drawing.Color.Black
        Me.lblPenalties_2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblPenalties_2.CanGrow = False
        Me.lblPenalties_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPenalties_2.ForeColor = System.Drawing.Color.Black
        Me.lblPenalties_2.LocationFloat = New DevExpress.Utils.PointFloat(880.0!, 400.0!)
        Me.lblPenalties_2.Name = "lblPenalties_2"
        Me.lblPenalties_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPenalties_2.SizeF = New System.Drawing.SizeF(170.0!, 25.0!)
        Me.lblPenalties_2.StylePriority.UseBackColor = False
        Me.lblPenalties_2.StylePriority.UseBorderColor = False
        Me.lblPenalties_2.StylePriority.UseBorders = False
        Me.lblPenalties_2.StylePriority.UseFont = False
        Me.lblPenalties_2.StylePriority.UseForeColor = False
        Me.lblPenalties_2.StylePriority.UseTextAlignment = False
        Me.lblPenalties_2.Text = "100.00"
        Me.lblPenalties_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPenalties_2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPenaltyDates_2
        '
        Me.lblPenaltyDates_2.BackColor = System.Drawing.Color.White
        Me.lblPenaltyDates_2.BorderColor = System.Drawing.Color.Black
        Me.lblPenaltyDates_2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblPenaltyDates_2.CanGrow = False
        Me.lblPenaltyDates_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPenaltyDates_2.ForeColor = System.Drawing.Color.Black
        Me.lblPenaltyDates_2.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 400.0!)
        Me.lblPenaltyDates_2.Name = "lblPenaltyDates_2"
        Me.lblPenaltyDates_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPenaltyDates_2.SizeF = New System.Drawing.SizeF(350.0!, 25.0!)
        Me.lblPenaltyDates_2.StylePriority.UseBackColor = False
        Me.lblPenaltyDates_2.StylePriority.UseBorderColor = False
        Me.lblPenaltyDates_2.StylePriority.UseBorders = False
        Me.lblPenaltyDates_2.StylePriority.UseFont = False
        Me.lblPenaltyDates_2.StylePriority.UseForeColor = False
        Me.lblPenaltyDates_2.StylePriority.UseTextAlignment = False
        Me.lblPenaltyDates_2.Text = "Penalties (5% from 12.23.17–10.31.17) :"
        Me.lblPenaltyDates_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblMonthlyA_2
        '
        Me.lblMonthlyA_2.BackColor = System.Drawing.Color.White
        Me.lblMonthlyA_2.BorderColor = System.Drawing.Color.Black
        Me.lblMonthlyA_2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblMonthlyA_2.CanGrow = False
        Me.lblMonthlyA_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthlyA_2.ForeColor = System.Drawing.Color.Black
        Me.lblMonthlyA_2.LocationFloat = New DevExpress.Utils.PointFloat(720.0!, 220.0!)
        Me.lblMonthlyA_2.Name = "lblMonthlyA_2"
        Me.lblMonthlyA_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMonthlyA_2.SizeF = New System.Drawing.SizeF(330.0!, 25.0!)
        Me.lblMonthlyA_2.StylePriority.UseBackColor = False
        Me.lblMonthlyA_2.StylePriority.UseBorderColor = False
        Me.lblMonthlyA_2.StylePriority.UseBorders = False
        Me.lblMonthlyA_2.StylePriority.UseFont = False
        Me.lblMonthlyA_2.StylePriority.UseForeColor = False
        Me.lblMonthlyA_2.StylePriority.UseTextAlignment = False
        Me.lblMonthlyA_2.Text = "P100.00"
        Me.lblMonthlyA_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblMonthlyA_2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel22
        '
        Me.XrLabel22.BackColor = System.Drawing.Color.White
        Me.XrLabel22.BorderColor = System.Drawing.Color.Black
        Me.XrLabel22.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel22.CanGrow = False
        Me.XrLabel22.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel22.ForeColor = System.Drawing.Color.Black
        Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 220.0!)
        Me.XrLabel22.Name = "XrLabel22"
        Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel22.SizeF = New System.Drawing.SizeF(190.0!, 25.0!)
        Me.XrLabel22.StylePriority.UseBackColor = False
        Me.XrLabel22.StylePriority.UseBorderColor = False
        Me.XrLabel22.StylePriority.UseBorders = False
        Me.XrLabel22.StylePriority.UseFont = False
        Me.XrLabel22.StylePriority.UseForeColor = False
        Me.XrLabel22.StylePriority.UseTextAlignment = False
        Me.XrLabel22.Text = "Monthly Amortization :"
        Me.XrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblPrincipal_2
        '
        Me.lblPrincipal_2.BackColor = System.Drawing.Color.White
        Me.lblPrincipal_2.BorderColor = System.Drawing.Color.Black
        Me.lblPrincipal_2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblPrincipal_2.CanGrow = False
        Me.lblPrincipal_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipal_2.ForeColor = System.Drawing.Color.Black
        Me.lblPrincipal_2.LocationFloat = New DevExpress.Utils.PointFloat(720.0!, 195.0!)
        Me.lblPrincipal_2.Name = "lblPrincipal_2"
        Me.lblPrincipal_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrincipal_2.SizeF = New System.Drawing.SizeF(330.0!, 25.0!)
        Me.lblPrincipal_2.StylePriority.UseBackColor = False
        Me.lblPrincipal_2.StylePriority.UseBorderColor = False
        Me.lblPrincipal_2.StylePriority.UseBorders = False
        Me.lblPrincipal_2.StylePriority.UseFont = False
        Me.lblPrincipal_2.StylePriority.UseForeColor = False
        Me.lblPrincipal_2.StylePriority.UseTextAlignment = False
        Me.lblPrincipal_2.Text = "P1,000,000,000.00"
        Me.lblPrincipal_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblPrincipal_2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel24
        '
        Me.XrLabel24.BackColor = System.Drawing.Color.White
        Me.XrLabel24.BorderColor = System.Drawing.Color.Black
        Me.XrLabel24.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel24.CanGrow = False
        Me.XrLabel24.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel24.ForeColor = System.Drawing.Color.Black
        Me.XrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 245.0!)
        Me.XrLabel24.Name = "XrLabel24"
        Me.XrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel24.SizeF = New System.Drawing.SizeF(190.0!, 25.0!)
        Me.XrLabel24.StylePriority.UseBackColor = False
        Me.XrLabel24.StylePriority.UseBorderColor = False
        Me.XrLabel24.StylePriority.UseBorders = False
        Me.XrLabel24.StylePriority.UseFont = False
        Me.XrLabel24.StylePriority.UseForeColor = False
        Me.XrLabel24.StylePriority.UseTextAlignment = False
        Me.XrLabel24.Text = "Date Availed :"
        Me.XrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblLastP_2
        '
        Me.lblLastP_2.BackColor = System.Drawing.Color.White
        Me.lblLastP_2.BorderColor = System.Drawing.Color.Black
        Me.lblLastP_2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblLastP_2.CanGrow = False
        Me.lblLastP_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastP_2.ForeColor = System.Drawing.Color.Black
        Me.lblLastP_2.LocationFloat = New DevExpress.Utils.PointFloat(720.0!, 270.0!)
        Me.lblLastP_2.Name = "lblLastP_2"
        Me.lblLastP_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblLastP_2.SizeF = New System.Drawing.SizeF(330.0!, 25.0!)
        Me.lblLastP_2.StylePriority.UseBackColor = False
        Me.lblLastP_2.StylePriority.UseBorderColor = False
        Me.lblLastP_2.StylePriority.UseBorders = False
        Me.lblLastP_2.StylePriority.UseFont = False
        Me.lblLastP_2.StylePriority.UseForeColor = False
        Me.lblLastP_2.StylePriority.UseTextAlignment = False
        Me.lblLastP_2.Text = "December 04, 2017"
        Me.lblLastP_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblLastP_2.XlsxFormatString = "mm/dd/yyyy"
        '
        'XrLabel28
        '
        Me.XrLabel28.BackColor = System.Drawing.Color.White
        Me.XrLabel28.BorderColor = System.Drawing.Color.Black
        Me.XrLabel28.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel28.CanGrow = False
        Me.XrLabel28.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel28.ForeColor = System.Drawing.Color.Black
        Me.XrLabel28.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 270.0!)
        Me.XrLabel28.Name = "XrLabel28"
        Me.XrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel28.SizeF = New System.Drawing.SizeF(190.0!, 25.0!)
        Me.XrLabel28.StylePriority.UseBackColor = False
        Me.XrLabel28.StylePriority.UseBorderColor = False
        Me.XrLabel28.StylePriority.UseBorders = False
        Me.XrLabel28.StylePriority.UseFont = False
        Me.XrLabel28.StylePriority.UseForeColor = False
        Me.XrLabel28.StylePriority.UseTextAlignment = False
        Me.XrLabel28.Text = "Last Payment Date :"
        Me.XrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblDateAvailed_2
        '
        Me.lblDateAvailed_2.BackColor = System.Drawing.Color.White
        Me.lblDateAvailed_2.BorderColor = System.Drawing.Color.Black
        Me.lblDateAvailed_2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblDateAvailed_2.CanGrow = False
        Me.lblDateAvailed_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateAvailed_2.ForeColor = System.Drawing.Color.Black
        Me.lblDateAvailed_2.LocationFloat = New DevExpress.Utils.PointFloat(720.0!, 245.0!)
        Me.lblDateAvailed_2.Name = "lblDateAvailed_2"
        Me.lblDateAvailed_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDateAvailed_2.SizeF = New System.Drawing.SizeF(330.0!, 25.0!)
        Me.lblDateAvailed_2.StylePriority.UseBackColor = False
        Me.lblDateAvailed_2.StylePriority.UseBorderColor = False
        Me.lblDateAvailed_2.StylePriority.UseBorders = False
        Me.lblDateAvailed_2.StylePriority.UseFont = False
        Me.lblDateAvailed_2.StylePriority.UseForeColor = False
        Me.lblDateAvailed_2.StylePriority.UseTextAlignment = False
        Me.lblDateAvailed_2.Text = "December 04, 2017"
        Me.lblDateAvailed_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.lblDateAvailed_2.XlsxFormatString = "mm/dd/yyyy"
        '
        'XrLabel12
        '
        Me.XrLabel12.BackColor = System.Drawing.Color.White
        Me.XrLabel12.BorderColor = System.Drawing.Color.Black
        Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel12.CanGrow = False
        Me.XrLabel12.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel12.ForeColor = System.Drawing.Color.Black
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 145.0!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(190.0!, 25.0!)
        Me.XrLabel12.StylePriority.UseBackColor = False
        Me.XrLabel12.StylePriority.UseBorderColor = False
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseForeColor = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = "Account Number :"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblName_2
        '
        Me.lblName_2.BackColor = System.Drawing.Color.White
        Me.lblName_2.BorderColor = System.Drawing.Color.Black
        Me.lblName_2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblName_2.CanGrow = False
        Me.lblName_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName_2.ForeColor = System.Drawing.Color.Black
        Me.lblName_2.LocationFloat = New DevExpress.Utils.PointFloat(720.0!, 120.0!)
        Me.lblName_2.Name = "lblName_2"
        Me.lblName_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblName_2.SizeF = New System.Drawing.SizeF(330.0!, 25.0!)
        Me.lblName_2.StylePriority.UseBackColor = False
        Me.lblName_2.StylePriority.UseBorderColor = False
        Me.lblName_2.StylePriority.UseBorders = False
        Me.lblName_2.StylePriority.UseFont = False
        Me.lblName_2.StylePriority.UseForeColor = False
        Me.lblName_2.StylePriority.UseTextAlignment = False
        Me.lblName_2.Text = "Mark Kevin M. Gotico"
        Me.lblName_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel8
        '
        Me.XrLabel8.BackColor = System.Drawing.Color.White
        Me.XrLabel8.BorderColor = System.Drawing.Color.Black
        Me.XrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel8.CanGrow = False
        Me.XrLabel8.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.ForeColor = System.Drawing.Color.Black
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 120.0!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(190.0!, 25.0!)
        Me.XrLabel8.StylePriority.UseBackColor = False
        Me.XrLabel8.StylePriority.UseBorderColor = False
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseForeColor = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "Name :"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblAccountNumber_2
        '
        Me.lblAccountNumber_2.BackColor = System.Drawing.Color.White
        Me.lblAccountNumber_2.BorderColor = System.Drawing.Color.Black
        Me.lblAccountNumber_2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblAccountNumber_2.CanGrow = False
        Me.lblAccountNumber_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountNumber_2.ForeColor = System.Drawing.Color.Black
        Me.lblAccountNumber_2.LocationFloat = New DevExpress.Utils.PointFloat(720.0!, 145.0!)
        Me.lblAccountNumber_2.Name = "lblAccountNumber_2"
        Me.lblAccountNumber_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountNumber_2.SizeF = New System.Drawing.SizeF(330.0!, 25.0!)
        Me.lblAccountNumber_2.StylePriority.UseBackColor = False
        Me.lblAccountNumber_2.StylePriority.UseBorderColor = False
        Me.lblAccountNumber_2.StylePriority.UseBorders = False
        Me.lblAccountNumber_2.StylePriority.UseFont = False
        Me.lblAccountNumber_2.StylePriority.UseForeColor = False
        Me.lblAccountNumber_2.StylePriority.UseTextAlignment = False
        Me.lblAccountNumber_2.Text = "VL-1000"
        Me.lblAccountNumber_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel20
        '
        Me.XrLabel20.BackColor = System.Drawing.Color.White
        Me.XrLabel20.BorderColor = System.Drawing.Color.Black
        Me.XrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel20.CanGrow = False
        Me.XrLabel20.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel20.ForeColor = System.Drawing.Color.Black
        Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 195.0!)
        Me.XrLabel20.Name = "XrLabel20"
        Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel20.SizeF = New System.Drawing.SizeF(190.0!, 25.0!)
        Me.XrLabel20.StylePriority.UseBackColor = False
        Me.XrLabel20.StylePriority.UseBorderColor = False
        Me.XrLabel20.StylePriority.UseBorders = False
        Me.XrLabel20.StylePriority.UseFont = False
        Me.XrLabel20.StylePriority.UseForeColor = False
        Me.XrLabel20.StylePriority.UseTextAlignment = False
        Me.XrLabel20.Text = "Total Loan Amount :"
        Me.XrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblCollateral_2
        '
        Me.lblCollateral_2.BackColor = System.Drawing.Color.White
        Me.lblCollateral_2.BorderColor = System.Drawing.Color.Black
        Me.lblCollateral_2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblCollateral_2.CanGrow = False
        Me.lblCollateral_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCollateral_2.ForeColor = System.Drawing.Color.Black
        Me.lblCollateral_2.LocationFloat = New DevExpress.Utils.PointFloat(720.0!, 170.0!)
        Me.lblCollateral_2.Name = "lblCollateral_2"
        Me.lblCollateral_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCollateral_2.SizeF = New System.Drawing.SizeF(330.0!, 25.0!)
        Me.lblCollateral_2.StylePriority.UseBackColor = False
        Me.lblCollateral_2.StylePriority.UseBorderColor = False
        Me.lblCollateral_2.StylePriority.UseBorders = False
        Me.lblCollateral_2.StylePriority.UseFont = False
        Me.lblCollateral_2.StylePriority.UseForeColor = False
        Me.lblCollateral_2.StylePriority.UseTextAlignment = False
        Me.lblCollateral_2.Text = "2010 Toyota Avanze YJD597"
        Me.lblCollateral_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel16
        '
        Me.XrLabel16.BackColor = System.Drawing.Color.White
        Me.XrLabel16.BorderColor = System.Drawing.Color.Black
        Me.XrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel16.CanGrow = False
        Me.XrLabel16.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel16.ForeColor = System.Drawing.Color.Black
        Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 170.0!)
        Me.XrLabel16.Name = "XrLabel16"
        Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel16.SizeF = New System.Drawing.SizeF(190.0!, 25.0!)
        Me.XrLabel16.StylePriority.UseBackColor = False
        Me.XrLabel16.StylePriority.UseBorderColor = False
        Me.XrLabel16.StylePriority.UseBorders = False
        Me.XrLabel16.StylePriority.UseFont = False
        Me.XrLabel16.StylePriority.UseForeColor = False
        Me.XrLabel16.StylePriority.UseTextAlignment = False
        Me.XrLabel16.Text = "Collateral :"
        Me.XrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblAsOf_2
        '
        Me.lblAsOf_2.BackColor = System.Drawing.Color.White
        Me.lblAsOf_2.BorderColor = System.Drawing.Color.Black
        Me.lblAsOf_2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblAsOf_2.CanGrow = False
        Me.lblAsOf_2.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAsOf_2.ForeColor = System.Drawing.Color.Black
        Me.lblAsOf_2.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 85.0!)
        Me.lblAsOf_2.Name = "lblAsOf_2"
        Me.lblAsOf_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAsOf_2.SizeF = New System.Drawing.SizeF(520.0!, 20.0!)
        Me.lblAsOf_2.StylePriority.UseBackColor = False
        Me.lblAsOf_2.StylePriority.UseBorderColor = False
        Me.lblAsOf_2.StylePriority.UseBorders = False
        Me.lblAsOf_2.StylePriority.UseFont = False
        Me.lblAsOf_2.StylePriority.UseForeColor = False
        Me.lblAsOf_2.StylePriority.UseTextAlignment = False
        Me.lblAsOf_2.Text = "June 23, 2017"
        Me.lblAsOf_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblAsOf_2.XlsxFormatString = "mm/dd/yyyy"
        '
        'XrLabel5
        '
        Me.XrLabel5.BackColor = System.Drawing.Color.White
        Me.XrLabel5.BorderColor = System.Drawing.Color.Black
        Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel5.CanGrow = False
        Me.XrLabel5.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.ForeColor = System.Drawing.Color.Black
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 60.0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(520.0!, 25.0!)
        Me.XrLabel5.StylePriority.UseBackColor = False
        Me.XrLabel5.StylePriority.UseBorderColor = False
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseForeColor = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "Statement of Account"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblContact_2
        '
        Me.lblContact_2.BackColor = System.Drawing.Color.White
        Me.lblContact_2.BorderColor = System.Drawing.Color.Black
        Me.lblContact_2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblContact_2.CanGrow = False
        Me.lblContact_2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContact_2.ForeColor = System.Drawing.Color.Black
        Me.lblContact_2.LocationFloat = New DevExpress.Utils.PointFloat(730.0!, 30.0!)
        Me.lblContact_2.Name = "lblContact_2"
        Me.lblContact_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblContact_2.SizeF = New System.Drawing.SizeF(320.0!, 20.0!)
        Me.lblContact_2.StylePriority.UseBackColor = False
        Me.lblContact_2.StylePriority.UseBorderColor = False
        Me.lblContact_2.StylePriority.UseBorders = False
        Me.lblContact_2.StylePriority.UseFont = False
        Me.lblContact_2.StylePriority.UseForeColor = False
        Me.lblContact_2.StylePriority.UseTextAlignment = False
        Me.lblContact_2.Text = "(032) 3455493-95, 238-8737, 0922-8654506, 0917-3084823"
        Me.lblContact_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblAddress_2
        '
        Me.lblAddress_2.BackColor = System.Drawing.Color.White
        Me.lblAddress_2.BorderColor = System.Drawing.Color.Black
        Me.lblAddress_2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblAddress_2.CanGrow = False
        Me.lblAddress_2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress_2.ForeColor = System.Drawing.Color.Black
        Me.lblAddress_2.LocationFloat = New DevExpress.Utils.PointFloat(730.0!, 0.0!)
        Me.lblAddress_2.Name = "lblAddress_2"
        Me.lblAddress_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAddress_2.SizeF = New System.Drawing.SizeF(320.0!, 30.0!)
        Me.lblAddress_2.StylePriority.UseBackColor = False
        Me.lblAddress_2.StylePriority.UseBorderColor = False
        Me.lblAddress_2.StylePriority.UseBorders = False
        Me.lblAddress_2.StylePriority.UseFont = False
        Me.lblAddress_2.StylePriority.UseForeColor = False
        Me.lblAddress_2.StylePriority.UseTextAlignment = False
        Me.lblAddress_2.Text = "Sheridan Bldg. Ouano Ave., NRA Subangdaku, Mandaue City 6014, PH"
        Me.lblAddress_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrPictureBox2
        '
        Me.XrPictureBox2.BackColor = System.Drawing.Color.White
        Me.XrPictureBox2.Image = CType(resources.GetObject("XrPictureBox2.Image"), System.Drawing.Image)
        Me.XrPictureBox2.LocationFloat = New DevExpress.Utils.PointFloat(530.0!, 0.0!)
        Me.XrPictureBox2.Name = "XrPictureBox2"
        Me.XrPictureBox2.SizeF = New System.Drawing.SizeF(200.0!, 50.0!)
        Me.XrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        Me.XrPictureBox2.StylePriority.UseBackColor = False
        '
        'XrLine1
        '
        Me.XrLine1.BackColor = System.Drawing.Color.White
        Me.XrLine1.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical
        Me.XrLine1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.XrLine1.LineWidth = 2
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(520.0!, 0.0!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(10.0!, 779.0!)
        Me.XrLine1.StylePriority.UseBackColor = False
        '
        'XrLabel84
        '
        Me.XrLabel84.BackColor = System.Drawing.Color.White
        Me.XrLabel84.BorderColor = System.Drawing.Color.Black
        Me.XrLabel84.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel84.CanGrow = False
        Me.XrLabel84.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel84.ForeColor = System.Drawing.Color.Black
        Me.XrLabel84.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 761.0!)
        Me.XrLabel84.Name = "XrLabel84"
        Me.XrLabel84.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel84.SizeF = New System.Drawing.SizeF(520.0!, 12.0!)
        Me.XrLabel84.StylePriority.UseBackColor = False
        Me.XrLabel84.StylePriority.UseBorderColor = False
        Me.XrLabel84.StylePriority.UseBorders = False
        Me.XrLabel84.StylePriority.UseFont = False
        Me.XrLabel84.StylePriority.UseForeColor = False
        Me.XrLabel84.StylePriority.UseTextAlignment = False
        Me.XrLabel84.Text = "Note :  Penalties are computed as of the date of this statement. Above figures ar" &
    "e subject to audit and, therefore, are not final."
        Me.XrLabel84.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 25.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 25.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'rptSOA_Detailed
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.PageHeight = 850
        Me.PageWidth = 1100
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents lblContact_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAddress_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox2 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents lblAsOf_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMonthlyA_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrincipal_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblLastP_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel28 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDateAvailed_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblName_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountNumber_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCollateral_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotal_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel42 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblOthersAmount_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRebate_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblOverdue_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRebateA_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblUnpaidDate_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBalance_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel32 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblUnpaidPenalties_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblOthers_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPenalties_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPenaltyDates_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblReceived_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNoted_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel51 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel50 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel45 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel44 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrepared_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel46 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblContact As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents lblAddress As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDateAvailed As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel30 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMonthlyA As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel27 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDueDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel25 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotalPayments As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFaceAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrincipal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCollateral As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAsOf As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel39 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMonthsMD As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel37 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMaturityD As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel35 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblLastP As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel33 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel48 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel47 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel43 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel41 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblUpdatedP As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblUpdatedA As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBalanceP As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBalance As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel53 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel52 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel49 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDaysDelayed As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblHangingP As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblHangingA As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents subRpt_SOA As DevExpress.XtraReports.UI.XRSubreport
    Friend WithEvents lblPenalties As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblArrears As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel61 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblUnpaidPenalties As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel64 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRebate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRebateA As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblOthersAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel65 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblOthers As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRebateD As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel76 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel73 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblOverdue As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel81 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNoted As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblReceived As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel78 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrepared As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel80 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel84 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDiscount_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDiscount_4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDiscount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDiscount_3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblChecked_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblChecked As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
End Class
