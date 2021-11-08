<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptBulkMigration
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
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.lblIndustry = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBorrowerID = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBusinessCenter = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblProduct = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCollateral = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTerms = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInterestRate = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDateAvailed = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRPPDRate = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblLastPayment = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrincipal = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDueDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrincipalBalance = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblUDI = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblUDIBalance = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRPPD = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRPPDBalance = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblUnpaidPenalty = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblGMA = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMonthlyRabate = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBank = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrLabel84 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel23 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel19 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblIndustry, Me.lblBorrowerID, Me.lblBusinessCenter, Me.lblProduct, Me.lblAccountNumber, Me.lblCollateral, Me.lblTerms, Me.lblInterestRate, Me.lblDateAvailed, Me.lblRPPDRate, Me.lblLastPayment, Me.lblPrincipal, Me.lblDueDate, Me.lblPrincipalBalance, Me.lblUDI, Me.lblUDIBalance, Me.lblRPPD, Me.lblRPPDBalance, Me.lblUnpaidPenalty, Me.lblGMA, Me.lblMonthlyRabate, Me.lblBank})
        Me.Detail.HeightF = 20.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblIndustry
        '
        Me.lblIndustry.BackColor = System.Drawing.Color.White
        Me.lblIndustry.BorderColor = System.Drawing.Color.Black
        Me.lblIndustry.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblIndustry.CanGrow = False
        Me.lblIndustry.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIndustry.ForeColor = System.Drawing.Color.Black
        Me.lblIndustry.LocationFloat = New DevExpress.Utils.PointFloat(2305.0!, 0!)
        Me.lblIndustry.Name = "lblIndustry"
        Me.lblIndustry.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblIndustry.SizeF = New System.Drawing.SizeF(90.0!, 20.0!)
        Me.lblIndustry.StylePriority.UseBackColor = False
        Me.lblIndustry.StylePriority.UseBorderColor = False
        Me.lblIndustry.StylePriority.UseBorders = False
        Me.lblIndustry.StylePriority.UseFont = False
        Me.lblIndustry.StylePriority.UseForeColor = False
        Me.lblIndustry.StylePriority.UseTextAlignment = False
        Me.lblIndustry.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblBorrowerID
        '
        Me.lblBorrowerID.BackColor = System.Drawing.Color.White
        Me.lblBorrowerID.BorderColor = System.Drawing.Color.Black
        Me.lblBorrowerID.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBorrowerID.CanGrow = False
        Me.lblBorrowerID.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrowerID.ForeColor = System.Drawing.Color.Black
        Me.lblBorrowerID.LocationFloat = New DevExpress.Utils.PointFloat(0.0002441406!, 0!)
        Me.lblBorrowerID.Name = "lblBorrowerID"
        Me.lblBorrowerID.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBorrowerID.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.lblBorrowerID.StylePriority.UseBackColor = False
        Me.lblBorrowerID.StylePriority.UseBorderColor = False
        Me.lblBorrowerID.StylePriority.UseBorders = False
        Me.lblBorrowerID.StylePriority.UseFont = False
        Me.lblBorrowerID.StylePriority.UseForeColor = False
        Me.lblBorrowerID.StylePriority.UseTextAlignment = False
        Me.lblBorrowerID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblBusinessCenter
        '
        Me.lblBusinessCenter.BackColor = System.Drawing.Color.White
        Me.lblBusinessCenter.BorderColor = System.Drawing.Color.Black
        Me.lblBusinessCenter.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBusinessCenter.CanGrow = False
        Me.lblBusinessCenter.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBusinessCenter.ForeColor = System.Drawing.Color.Black
        Me.lblBusinessCenter.LocationFloat = New DevExpress.Utils.PointFloat(125.0002!, 0!)
        Me.lblBusinessCenter.Name = "lblBusinessCenter"
        Me.lblBusinessCenter.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBusinessCenter.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.lblBusinessCenter.StylePriority.UseBackColor = False
        Me.lblBusinessCenter.StylePriority.UseBorderColor = False
        Me.lblBusinessCenter.StylePriority.UseBorders = False
        Me.lblBusinessCenter.StylePriority.UseFont = False
        Me.lblBusinessCenter.StylePriority.UseForeColor = False
        Me.lblBusinessCenter.StylePriority.UseTextAlignment = False
        Me.lblBusinessCenter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblProduct
        '
        Me.lblProduct.BackColor = System.Drawing.Color.White
        Me.lblProduct.BorderColor = System.Drawing.Color.Black
        Me.lblProduct.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblProduct.CanGrow = False
        Me.lblProduct.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduct.ForeColor = System.Drawing.Color.Black
        Me.lblProduct.LocationFloat = New DevExpress.Utils.PointFloat(250.0002!, 0!)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblProduct.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.lblProduct.StylePriority.UseBackColor = False
        Me.lblProduct.StylePriority.UseBorderColor = False
        Me.lblProduct.StylePriority.UseBorders = False
        Me.lblProduct.StylePriority.UseFont = False
        Me.lblProduct.StylePriority.UseForeColor = False
        Me.lblProduct.StylePriority.UseTextAlignment = False
        Me.lblProduct.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAccountNumber
        '
        Me.lblAccountNumber.BackColor = System.Drawing.Color.White
        Me.lblAccountNumber.BorderColor = System.Drawing.Color.Black
        Me.lblAccountNumber.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccountNumber.CanGrow = False
        Me.lblAccountNumber.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountNumber.ForeColor = System.Drawing.Color.Black
        Me.lblAccountNumber.LocationFloat = New DevExpress.Utils.PointFloat(375.0002!, 0!)
        Me.lblAccountNumber.Name = "lblAccountNumber"
        Me.lblAccountNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountNumber.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.lblAccountNumber.StylePriority.UseBackColor = False
        Me.lblAccountNumber.StylePriority.UseBorderColor = False
        Me.lblAccountNumber.StylePriority.UseBorders = False
        Me.lblAccountNumber.StylePriority.UseFont = False
        Me.lblAccountNumber.StylePriority.UseForeColor = False
        Me.lblAccountNumber.StylePriority.UseTextAlignment = False
        Me.lblAccountNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCollateral
        '
        Me.lblCollateral.BackColor = System.Drawing.Color.White
        Me.lblCollateral.BorderColor = System.Drawing.Color.Black
        Me.lblCollateral.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCollateral.CanGrow = False
        Me.lblCollateral.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCollateral.ForeColor = System.Drawing.Color.Black
        Me.lblCollateral.LocationFloat = New DevExpress.Utils.PointFloat(500.0002!, 0!)
        Me.lblCollateral.Name = "lblCollateral"
        Me.lblCollateral.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCollateral.SizeF = New System.Drawing.SizeF(280.0!, 20.0!)
        Me.lblCollateral.StylePriority.UseBackColor = False
        Me.lblCollateral.StylePriority.UseBorderColor = False
        Me.lblCollateral.StylePriority.UseBorders = False
        Me.lblCollateral.StylePriority.UseFont = False
        Me.lblCollateral.StylePriority.UseForeColor = False
        Me.lblCollateral.StylePriority.UseTextAlignment = False
        Me.lblCollateral.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblTerms
        '
        Me.lblTerms.BackColor = System.Drawing.Color.White
        Me.lblTerms.BorderColor = System.Drawing.Color.Black
        Me.lblTerms.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTerms.CanGrow = False
        Me.lblTerms.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTerms.ForeColor = System.Drawing.Color.Black
        Me.lblTerms.LocationFloat = New DevExpress.Utils.PointFloat(780.0002!, 0!)
        Me.lblTerms.Name = "lblTerms"
        Me.lblTerms.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTerms.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.lblTerms.StylePriority.UseBackColor = False
        Me.lblTerms.StylePriority.UseBorderColor = False
        Me.lblTerms.StylePriority.UseBorders = False
        Me.lblTerms.StylePriority.UseFont = False
        Me.lblTerms.StylePriority.UseForeColor = False
        Me.lblTerms.StylePriority.UseTextAlignment = False
        Me.lblTerms.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblInterestRate
        '
        Me.lblInterestRate.BackColor = System.Drawing.Color.White
        Me.lblInterestRate.BorderColor = System.Drawing.Color.Black
        Me.lblInterestRate.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblInterestRate.CanGrow = False
        Me.lblInterestRate.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterestRate.ForeColor = System.Drawing.Color.Black
        Me.lblInterestRate.LocationFloat = New DevExpress.Utils.PointFloat(840.0005!, 0!)
        Me.lblInterestRate.Name = "lblInterestRate"
        Me.lblInterestRate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInterestRate.SizeF = New System.Drawing.SizeF(69.99976!, 20.0!)
        Me.lblInterestRate.StylePriority.UseBackColor = False
        Me.lblInterestRate.StylePriority.UseBorderColor = False
        Me.lblInterestRate.StylePriority.UseBorders = False
        Me.lblInterestRate.StylePriority.UseFont = False
        Me.lblInterestRate.StylePriority.UseForeColor = False
        Me.lblInterestRate.StylePriority.UseTextAlignment = False
        Me.lblInterestRate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblDateAvailed
        '
        Me.lblDateAvailed.BackColor = System.Drawing.Color.White
        Me.lblDateAvailed.BorderColor = System.Drawing.Color.Black
        Me.lblDateAvailed.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDateAvailed.CanGrow = False
        Me.lblDateAvailed.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateAvailed.ForeColor = System.Drawing.Color.Black
        Me.lblDateAvailed.LocationFloat = New DevExpress.Utils.PointFloat(980.0!, 0!)
        Me.lblDateAvailed.Name = "lblDateAvailed"
        Me.lblDateAvailed.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDateAvailed.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.lblDateAvailed.StylePriority.UseBackColor = False
        Me.lblDateAvailed.StylePriority.UseBorderColor = False
        Me.lblDateAvailed.StylePriority.UseBorders = False
        Me.lblDateAvailed.StylePriority.UseFont = False
        Me.lblDateAvailed.StylePriority.UseForeColor = False
        Me.lblDateAvailed.StylePriority.UseTextAlignment = False
        Me.lblDateAvailed.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblDateAvailed.XlsxFormatString = "mm/dd/yyyy"
        '
        'lblRPPDRate
        '
        Me.lblRPPDRate.BackColor = System.Drawing.Color.White
        Me.lblRPPDRate.BorderColor = System.Drawing.Color.Black
        Me.lblRPPDRate.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblRPPDRate.CanGrow = False
        Me.lblRPPDRate.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRPPDRate.ForeColor = System.Drawing.Color.Black
        Me.lblRPPDRate.LocationFloat = New DevExpress.Utils.PointFloat(910.0!, 0!)
        Me.lblRPPDRate.Name = "lblRPPDRate"
        Me.lblRPPDRate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRPPDRate.SizeF = New System.Drawing.SizeF(69.99976!, 20.0!)
        Me.lblRPPDRate.StylePriority.UseBackColor = False
        Me.lblRPPDRate.StylePriority.UseBorderColor = False
        Me.lblRPPDRate.StylePriority.UseBorders = False
        Me.lblRPPDRate.StylePriority.UseFont = False
        Me.lblRPPDRate.StylePriority.UseForeColor = False
        Me.lblRPPDRate.StylePriority.UseTextAlignment = False
        Me.lblRPPDRate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblLastPayment
        '
        Me.lblLastPayment.BackColor = System.Drawing.Color.White
        Me.lblLastPayment.BorderColor = System.Drawing.Color.Black
        Me.lblLastPayment.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblLastPayment.CanGrow = False
        Me.lblLastPayment.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastPayment.ForeColor = System.Drawing.Color.Black
        Me.lblLastPayment.LocationFloat = New DevExpress.Utils.PointFloat(1105.0!, 0!)
        Me.lblLastPayment.Name = "lblLastPayment"
        Me.lblLastPayment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblLastPayment.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.lblLastPayment.StylePriority.UseBackColor = False
        Me.lblLastPayment.StylePriority.UseBorderColor = False
        Me.lblLastPayment.StylePriority.UseBorders = False
        Me.lblLastPayment.StylePriority.UseFont = False
        Me.lblLastPayment.StylePriority.UseForeColor = False
        Me.lblLastPayment.StylePriority.UseTextAlignment = False
        Me.lblLastPayment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblLastPayment.XlsxFormatString = "mm/dd/yyyy"
        '
        'lblPrincipal
        '
        Me.lblPrincipal.BackColor = System.Drawing.Color.White
        Me.lblPrincipal.BorderColor = System.Drawing.Color.Black
        Me.lblPrincipal.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPrincipal.CanGrow = False
        Me.lblPrincipal.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipal.ForeColor = System.Drawing.Color.Black
        Me.lblPrincipal.LocationFloat = New DevExpress.Utils.PointFloat(1280.0!, 0!)
        Me.lblPrincipal.Name = "lblPrincipal"
        Me.lblPrincipal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrincipal.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblPrincipal.StylePriority.UseBackColor = False
        Me.lblPrincipal.StylePriority.UseBorderColor = False
        Me.lblPrincipal.StylePriority.UseBorders = False
        Me.lblPrincipal.StylePriority.UseFont = False
        Me.lblPrincipal.StylePriority.UseForeColor = False
        Me.lblPrincipal.StylePriority.UseTextAlignment = False
        Me.lblPrincipal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPrincipal.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblDueDate
        '
        Me.lblDueDate.BackColor = System.Drawing.Color.White
        Me.lblDueDate.BorderColor = System.Drawing.Color.Black
        Me.lblDueDate.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDueDate.CanGrow = False
        Me.lblDueDate.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDueDate.ForeColor = System.Drawing.Color.Black
        Me.lblDueDate.LocationFloat = New DevExpress.Utils.PointFloat(1230.0!, 0!)
        Me.lblDueDate.Name = "lblDueDate"
        Me.lblDueDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDueDate.SizeF = New System.Drawing.SizeF(50.0!, 20.0!)
        Me.lblDueDate.StylePriority.UseBackColor = False
        Me.lblDueDate.StylePriority.UseBorderColor = False
        Me.lblDueDate.StylePriority.UseBorders = False
        Me.lblDueDate.StylePriority.UseFont = False
        Me.lblDueDate.StylePriority.UseForeColor = False
        Me.lblDueDate.StylePriority.UseTextAlignment = False
        Me.lblDueDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblPrincipalBalance
        '
        Me.lblPrincipalBalance.BackColor = System.Drawing.Color.White
        Me.lblPrincipalBalance.BorderColor = System.Drawing.Color.Black
        Me.lblPrincipalBalance.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPrincipalBalance.CanGrow = False
        Me.lblPrincipalBalance.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipalBalance.ForeColor = System.Drawing.Color.Black
        Me.lblPrincipalBalance.LocationFloat = New DevExpress.Utils.PointFloat(1380.0!, 0!)
        Me.lblPrincipalBalance.Name = "lblPrincipalBalance"
        Me.lblPrincipalBalance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrincipalBalance.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblPrincipalBalance.StylePriority.UseBackColor = False
        Me.lblPrincipalBalance.StylePriority.UseBorderColor = False
        Me.lblPrincipalBalance.StylePriority.UseBorders = False
        Me.lblPrincipalBalance.StylePriority.UseFont = False
        Me.lblPrincipalBalance.StylePriority.UseForeColor = False
        Me.lblPrincipalBalance.StylePriority.UseTextAlignment = False
        Me.lblPrincipalBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPrincipalBalance.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblUDI
        '
        Me.lblUDI.BackColor = System.Drawing.Color.White
        Me.lblUDI.BorderColor = System.Drawing.Color.Black
        Me.lblUDI.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblUDI.CanGrow = False
        Me.lblUDI.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUDI.ForeColor = System.Drawing.Color.Black
        Me.lblUDI.LocationFloat = New DevExpress.Utils.PointFloat(1480.0!, 0!)
        Me.lblUDI.Name = "lblUDI"
        Me.lblUDI.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblUDI.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblUDI.StylePriority.UseBackColor = False
        Me.lblUDI.StylePriority.UseBorderColor = False
        Me.lblUDI.StylePriority.UseBorders = False
        Me.lblUDI.StylePriority.UseFont = False
        Me.lblUDI.StylePriority.UseForeColor = False
        Me.lblUDI.StylePriority.UseTextAlignment = False
        Me.lblUDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblUDI.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblUDIBalance
        '
        Me.lblUDIBalance.BackColor = System.Drawing.Color.White
        Me.lblUDIBalance.BorderColor = System.Drawing.Color.Black
        Me.lblUDIBalance.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblUDIBalance.CanGrow = False
        Me.lblUDIBalance.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUDIBalance.ForeColor = System.Drawing.Color.Black
        Me.lblUDIBalance.LocationFloat = New DevExpress.Utils.PointFloat(1580.0!, 0!)
        Me.lblUDIBalance.Name = "lblUDIBalance"
        Me.lblUDIBalance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblUDIBalance.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblUDIBalance.StylePriority.UseBackColor = False
        Me.lblUDIBalance.StylePriority.UseBorderColor = False
        Me.lblUDIBalance.StylePriority.UseBorders = False
        Me.lblUDIBalance.StylePriority.UseFont = False
        Me.lblUDIBalance.StylePriority.UseForeColor = False
        Me.lblUDIBalance.StylePriority.UseTextAlignment = False
        Me.lblUDIBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblUDIBalance.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblRPPD
        '
        Me.lblRPPD.BackColor = System.Drawing.Color.White
        Me.lblRPPD.BorderColor = System.Drawing.Color.Black
        Me.lblRPPD.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblRPPD.CanGrow = False
        Me.lblRPPD.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRPPD.ForeColor = System.Drawing.Color.Black
        Me.lblRPPD.LocationFloat = New DevExpress.Utils.PointFloat(1680.0!, 0!)
        Me.lblRPPD.Name = "lblRPPD"
        Me.lblRPPD.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRPPD.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblRPPD.StylePriority.UseBackColor = False
        Me.lblRPPD.StylePriority.UseBorderColor = False
        Me.lblRPPD.StylePriority.UseBorders = False
        Me.lblRPPD.StylePriority.UseFont = False
        Me.lblRPPD.StylePriority.UseForeColor = False
        Me.lblRPPD.StylePriority.UseTextAlignment = False
        Me.lblRPPD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblRPPD.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblRPPDBalance
        '
        Me.lblRPPDBalance.BackColor = System.Drawing.Color.White
        Me.lblRPPDBalance.BorderColor = System.Drawing.Color.Black
        Me.lblRPPDBalance.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblRPPDBalance.CanGrow = False
        Me.lblRPPDBalance.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRPPDBalance.ForeColor = System.Drawing.Color.Black
        Me.lblRPPDBalance.LocationFloat = New DevExpress.Utils.PointFloat(1780.0!, 0!)
        Me.lblRPPDBalance.Name = "lblRPPDBalance"
        Me.lblRPPDBalance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRPPDBalance.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblRPPDBalance.StylePriority.UseBackColor = False
        Me.lblRPPDBalance.StylePriority.UseBorderColor = False
        Me.lblRPPDBalance.StylePriority.UseBorders = False
        Me.lblRPPDBalance.StylePriority.UseFont = False
        Me.lblRPPDBalance.StylePriority.UseForeColor = False
        Me.lblRPPDBalance.StylePriority.UseTextAlignment = False
        Me.lblRPPDBalance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblRPPDBalance.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblUnpaidPenalty
        '
        Me.lblUnpaidPenalty.BackColor = System.Drawing.Color.White
        Me.lblUnpaidPenalty.BorderColor = System.Drawing.Color.Black
        Me.lblUnpaidPenalty.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblUnpaidPenalty.CanGrow = False
        Me.lblUnpaidPenalty.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnpaidPenalty.ForeColor = System.Drawing.Color.Black
        Me.lblUnpaidPenalty.LocationFloat = New DevExpress.Utils.PointFloat(1880.0!, 0!)
        Me.lblUnpaidPenalty.Name = "lblUnpaidPenalty"
        Me.lblUnpaidPenalty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblUnpaidPenalty.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblUnpaidPenalty.StylePriority.UseBackColor = False
        Me.lblUnpaidPenalty.StylePriority.UseBorderColor = False
        Me.lblUnpaidPenalty.StylePriority.UseBorders = False
        Me.lblUnpaidPenalty.StylePriority.UseFont = False
        Me.lblUnpaidPenalty.StylePriority.UseForeColor = False
        Me.lblUnpaidPenalty.StylePriority.UseTextAlignment = False
        Me.lblUnpaidPenalty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblUnpaidPenalty.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblGMA
        '
        Me.lblGMA.BackColor = System.Drawing.Color.White
        Me.lblGMA.BorderColor = System.Drawing.Color.Black
        Me.lblGMA.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblGMA.CanGrow = False
        Me.lblGMA.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGMA.ForeColor = System.Drawing.Color.Black
        Me.lblGMA.LocationFloat = New DevExpress.Utils.PointFloat(1980.0!, 0!)
        Me.lblGMA.Name = "lblGMA"
        Me.lblGMA.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblGMA.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblGMA.StylePriority.UseBackColor = False
        Me.lblGMA.StylePriority.UseBorderColor = False
        Me.lblGMA.StylePriority.UseBorders = False
        Me.lblGMA.StylePriority.UseFont = False
        Me.lblGMA.StylePriority.UseForeColor = False
        Me.lblGMA.StylePriority.UseTextAlignment = False
        Me.lblGMA.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblGMA.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblMonthlyRabate
        '
        Me.lblMonthlyRabate.BackColor = System.Drawing.Color.White
        Me.lblMonthlyRabate.BorderColor = System.Drawing.Color.Black
        Me.lblMonthlyRabate.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMonthlyRabate.CanGrow = False
        Me.lblMonthlyRabate.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthlyRabate.ForeColor = System.Drawing.Color.Black
        Me.lblMonthlyRabate.LocationFloat = New DevExpress.Utils.PointFloat(2080.0!, 0!)
        Me.lblMonthlyRabate.Name = "lblMonthlyRabate"
        Me.lblMonthlyRabate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMonthlyRabate.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblMonthlyRabate.StylePriority.UseBackColor = False
        Me.lblMonthlyRabate.StylePriority.UseBorderColor = False
        Me.lblMonthlyRabate.StylePriority.UseBorders = False
        Me.lblMonthlyRabate.StylePriority.UseFont = False
        Me.lblMonthlyRabate.StylePriority.UseForeColor = False
        Me.lblMonthlyRabate.StylePriority.UseTextAlignment = False
        Me.lblMonthlyRabate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblMonthlyRabate.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblBank
        '
        Me.lblBank.BackColor = System.Drawing.Color.White
        Me.lblBank.BorderColor = System.Drawing.Color.Black
        Me.lblBank.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBank.CanGrow = False
        Me.lblBank.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBank.ForeColor = System.Drawing.Color.Black
        Me.lblBank.LocationFloat = New DevExpress.Utils.PointFloat(2180.0!, 0!)
        Me.lblBank.Name = "lblBank"
        Me.lblBank.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBank.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.lblBank.StylePriority.UseBackColor = False
        Me.lblBank.StylePriority.UseBorderColor = False
        Me.lblBank.StylePriority.UseBorders = False
        Me.lblBank.StylePriority.UseFont = False
        Me.lblBank.StylePriority.UseForeColor = False
        Me.lblBank.StylePriority.UseTextAlignment = False
        Me.lblBank.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel84, Me.XrLabel24, Me.XrLabel23, Me.XrLabel22, Me.XrLabel21, Me.XrLabel19, Me.XrLabel20, Me.XrLabel17, Me.XrLabel18, Me.XrLabel16, Me.XrLabel14, Me.XrLabel12, Me.XrLabel11, Me.XrLabel9, Me.XrLabel8, Me.XrLabel7, Me.XrLabel6, Me.XrLabel2, Me.XrLabel15, Me.XrLabel5, Me.XrLabel1, Me.XrLabel3})
        Me.PageHeader.HeightF = 20.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'XrLabel84
        '
        Me.XrLabel84.BackColor = System.Drawing.Color.White
        Me.XrLabel84.BorderColor = System.Drawing.Color.Black
        Me.XrLabel84.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel84.CanGrow = False
        Me.XrLabel84.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel84.ForeColor = System.Drawing.Color.Black
        Me.XrLabel84.LocationFloat = New DevExpress.Utils.PointFloat(2305.0!, 0!)
        Me.XrLabel84.Name = "XrLabel84"
        Me.XrLabel84.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel84.SizeF = New System.Drawing.SizeF(90.0!, 20.0!)
        Me.XrLabel84.StylePriority.UseBackColor = False
        Me.XrLabel84.StylePriority.UseBorderColor = False
        Me.XrLabel84.StylePriority.UseBorders = False
        Me.XrLabel84.StylePriority.UseFont = False
        Me.XrLabel84.StylePriority.UseForeColor = False
        Me.XrLabel84.StylePriority.UseTextAlignment = False
        Me.XrLabel84.Text = "Industry"
        Me.XrLabel84.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel24
        '
        Me.XrLabel24.BackColor = System.Drawing.Color.White
        Me.XrLabel24.BorderColor = System.Drawing.Color.Black
        Me.XrLabel24.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel24.CanGrow = False
        Me.XrLabel24.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel24.ForeColor = System.Drawing.Color.Black
        Me.XrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(2180.0!, 0!)
        Me.XrLabel24.Name = "XrLabel24"
        Me.XrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel24.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.XrLabel24.StylePriority.UseBackColor = False
        Me.XrLabel24.StylePriority.UseBorderColor = False
        Me.XrLabel24.StylePriority.UseBorders = False
        Me.XrLabel24.StylePriority.UseFont = False
        Me.XrLabel24.StylePriority.UseForeColor = False
        Me.XrLabel24.StylePriority.UseTextAlignment = False
        Me.XrLabel24.Text = "Bank"
        Me.XrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel23
        '
        Me.XrLabel23.BackColor = System.Drawing.Color.White
        Me.XrLabel23.BorderColor = System.Drawing.Color.Black
        Me.XrLabel23.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel23.CanGrow = False
        Me.XrLabel23.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel23.ForeColor = System.Drawing.Color.Black
        Me.XrLabel23.LocationFloat = New DevExpress.Utils.PointFloat(2080.0!, 0!)
        Me.XrLabel23.Name = "XrLabel23"
        Me.XrLabel23.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel23.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.XrLabel23.StylePriority.UseBackColor = False
        Me.XrLabel23.StylePriority.UseBorderColor = False
        Me.XrLabel23.StylePriority.UseBorders = False
        Me.XrLabel23.StylePriority.UseFont = False
        Me.XrLabel23.StylePriority.UseForeColor = False
        Me.XrLabel23.StylePriority.UseTextAlignment = False
        Me.XrLabel23.Text = "Monthly Rebate"
        Me.XrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel22
        '
        Me.XrLabel22.BackColor = System.Drawing.Color.White
        Me.XrLabel22.BorderColor = System.Drawing.Color.Black
        Me.XrLabel22.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel22.CanGrow = False
        Me.XrLabel22.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel22.ForeColor = System.Drawing.Color.Black
        Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(1980.0!, 0!)
        Me.XrLabel22.Name = "XrLabel22"
        Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel22.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.XrLabel22.StylePriority.UseBackColor = False
        Me.XrLabel22.StylePriority.UseBorderColor = False
        Me.XrLabel22.StylePriority.UseBorders = False
        Me.XrLabel22.StylePriority.UseFont = False
        Me.XrLabel22.StylePriority.UseForeColor = False
        Me.XrLabel22.StylePriority.UseTextAlignment = False
        Me.XrLabel22.Text = "GMA"
        Me.XrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel21
        '
        Me.XrLabel21.BackColor = System.Drawing.Color.White
        Me.XrLabel21.BorderColor = System.Drawing.Color.Black
        Me.XrLabel21.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel21.CanGrow = False
        Me.XrLabel21.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel21.ForeColor = System.Drawing.Color.Black
        Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(1880.0!, 0!)
        Me.XrLabel21.Name = "XrLabel21"
        Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel21.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.XrLabel21.StylePriority.UseBackColor = False
        Me.XrLabel21.StylePriority.UseBorderColor = False
        Me.XrLabel21.StylePriority.UseBorders = False
        Me.XrLabel21.StylePriority.UseFont = False
        Me.XrLabel21.StylePriority.UseForeColor = False
        Me.XrLabel21.StylePriority.UseTextAlignment = False
        Me.XrLabel21.Text = "Unpaid Penalty"
        Me.XrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel19
        '
        Me.XrLabel19.BackColor = System.Drawing.Color.White
        Me.XrLabel19.BorderColor = System.Drawing.Color.Black
        Me.XrLabel19.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel19.CanGrow = False
        Me.XrLabel19.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel19.ForeColor = System.Drawing.Color.Black
        Me.XrLabel19.LocationFloat = New DevExpress.Utils.PointFloat(1780.0!, 0!)
        Me.XrLabel19.Name = "XrLabel19"
        Me.XrLabel19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel19.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.XrLabel19.StylePriority.UseBackColor = False
        Me.XrLabel19.StylePriority.UseBorderColor = False
        Me.XrLabel19.StylePriority.UseBorders = False
        Me.XrLabel19.StylePriority.UseFont = False
        Me.XrLabel19.StylePriority.UseForeColor = False
        Me.XrLabel19.StylePriority.UseTextAlignment = False
        Me.XrLabel19.Text = "RPPD Balance"
        Me.XrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel20
        '
        Me.XrLabel20.BackColor = System.Drawing.Color.White
        Me.XrLabel20.BorderColor = System.Drawing.Color.Black
        Me.XrLabel20.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel20.CanGrow = False
        Me.XrLabel20.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel20.ForeColor = System.Drawing.Color.Black
        Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(1680.0!, 0!)
        Me.XrLabel20.Name = "XrLabel20"
        Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel20.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.XrLabel20.StylePriority.UseBackColor = False
        Me.XrLabel20.StylePriority.UseBorderColor = False
        Me.XrLabel20.StylePriority.UseBorders = False
        Me.XrLabel20.StylePriority.UseFont = False
        Me.XrLabel20.StylePriority.UseForeColor = False
        Me.XrLabel20.StylePriority.UseTextAlignment = False
        Me.XrLabel20.Text = "RPPD"
        Me.XrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel17
        '
        Me.XrLabel17.BackColor = System.Drawing.Color.White
        Me.XrLabel17.BorderColor = System.Drawing.Color.Black
        Me.XrLabel17.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel17.CanGrow = False
        Me.XrLabel17.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel17.ForeColor = System.Drawing.Color.Black
        Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(1480.0!, 0!)
        Me.XrLabel17.Name = "XrLabel17"
        Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel17.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.XrLabel17.StylePriority.UseBackColor = False
        Me.XrLabel17.StylePriority.UseBorderColor = False
        Me.XrLabel17.StylePriority.UseBorders = False
        Me.XrLabel17.StylePriority.UseFont = False
        Me.XrLabel17.StylePriority.UseForeColor = False
        Me.XrLabel17.StylePriority.UseTextAlignment = False
        Me.XrLabel17.Text = "UDI"
        Me.XrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel18
        '
        Me.XrLabel18.BackColor = System.Drawing.Color.White
        Me.XrLabel18.BorderColor = System.Drawing.Color.Black
        Me.XrLabel18.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel18.CanGrow = False
        Me.XrLabel18.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel18.ForeColor = System.Drawing.Color.Black
        Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(1580.0!, 0!)
        Me.XrLabel18.Name = "XrLabel18"
        Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel18.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.XrLabel18.StylePriority.UseBackColor = False
        Me.XrLabel18.StylePriority.UseBorderColor = False
        Me.XrLabel18.StylePriority.UseBorders = False
        Me.XrLabel18.StylePriority.UseFont = False
        Me.XrLabel18.StylePriority.UseForeColor = False
        Me.XrLabel18.StylePriority.UseTextAlignment = False
        Me.XrLabel18.Text = "UDI Balance"
        Me.XrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel16
        '
        Me.XrLabel16.BackColor = System.Drawing.Color.White
        Me.XrLabel16.BorderColor = System.Drawing.Color.Black
        Me.XrLabel16.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel16.CanGrow = False
        Me.XrLabel16.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel16.ForeColor = System.Drawing.Color.Black
        Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(1380.0!, 0!)
        Me.XrLabel16.Name = "XrLabel16"
        Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel16.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.XrLabel16.StylePriority.UseBackColor = False
        Me.XrLabel16.StylePriority.UseBorderColor = False
        Me.XrLabel16.StylePriority.UseBorders = False
        Me.XrLabel16.StylePriority.UseFont = False
        Me.XrLabel16.StylePriority.UseForeColor = False
        Me.XrLabel16.StylePriority.UseTextAlignment = False
        Me.XrLabel16.Text = "Principal Balance"
        Me.XrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel14
        '
        Me.XrLabel14.BackColor = System.Drawing.Color.White
        Me.XrLabel14.BorderColor = System.Drawing.Color.Black
        Me.XrLabel14.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel14.CanGrow = False
        Me.XrLabel14.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel14.ForeColor = System.Drawing.Color.Black
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(1280.0!, 0!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.XrLabel14.StylePriority.UseBackColor = False
        Me.XrLabel14.StylePriority.UseBorderColor = False
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.StylePriority.UseForeColor = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = "Principal"
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel12
        '
        Me.XrLabel12.BackColor = System.Drawing.Color.White
        Me.XrLabel12.BorderColor = System.Drawing.Color.Black
        Me.XrLabel12.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel12.CanGrow = False
        Me.XrLabel12.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel12.ForeColor = System.Drawing.Color.Black
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(1230.0!, 0!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(50.0!, 20.0!)
        Me.XrLabel12.StylePriority.UseBackColor = False
        Me.XrLabel12.StylePriority.UseBorderColor = False
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseForeColor = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = "Due Date"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel11
        '
        Me.XrLabel11.BackColor = System.Drawing.Color.White
        Me.XrLabel11.BorderColor = System.Drawing.Color.Black
        Me.XrLabel11.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel11.CanGrow = False
        Me.XrLabel11.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel11.ForeColor = System.Drawing.Color.Black
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(1105.0!, 0!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.XrLabel11.StylePriority.UseBackColor = False
        Me.XrLabel11.StylePriority.UseBorderColor = False
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseForeColor = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = "Last Payment"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel9
        '
        Me.XrLabel9.BackColor = System.Drawing.Color.White
        Me.XrLabel9.BorderColor = System.Drawing.Color.Black
        Me.XrLabel9.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel9.CanGrow = False
        Me.XrLabel9.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.ForeColor = System.Drawing.Color.Black
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(980.0001!, 0!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.XrLabel9.StylePriority.UseBackColor = False
        Me.XrLabel9.StylePriority.UseBorderColor = False
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseForeColor = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = "Date Availed"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel8
        '
        Me.XrLabel8.BackColor = System.Drawing.Color.White
        Me.XrLabel8.BorderColor = System.Drawing.Color.Black
        Me.XrLabel8.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel8.CanGrow = False
        Me.XrLabel8.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.ForeColor = System.Drawing.Color.Black
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(910.0001!, 0!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(69.99976!, 20.0!)
        Me.XrLabel8.StylePriority.UseBackColor = False
        Me.XrLabel8.StylePriority.UseBorderColor = False
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseForeColor = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "RPPD %"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel7
        '
        Me.XrLabel7.BackColor = System.Drawing.Color.White
        Me.XrLabel7.BorderColor = System.Drawing.Color.Black
        Me.XrLabel7.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel7.CanGrow = False
        Me.XrLabel7.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.ForeColor = System.Drawing.Color.Black
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(840.0002!, 0!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.XrLabel7.StylePriority.UseBackColor = False
        Me.XrLabel7.StylePriority.UseBorderColor = False
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseForeColor = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "Interest %"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel6
        '
        Me.XrLabel6.BackColor = System.Drawing.Color.White
        Me.XrLabel6.BorderColor = System.Drawing.Color.Black
        Me.XrLabel6.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel6.CanGrow = False
        Me.XrLabel6.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.ForeColor = System.Drawing.Color.Black
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(780.0002!, 0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.XrLabel6.StylePriority.UseBackColor = False
        Me.XrLabel6.StylePriority.UseBorderColor = False
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseForeColor = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "Terms"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel2
        '
        Me.XrLabel2.BackColor = System.Drawing.Color.White
        Me.XrLabel2.BorderColor = System.Drawing.Color.Black
        Me.XrLabel2.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel2.CanGrow = False
        Me.XrLabel2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.ForeColor = System.Drawing.Color.Black
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(500.0002!, 0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(280.0!, 20.0!)
        Me.XrLabel2.StylePriority.UseBackColor = False
        Me.XrLabel2.StylePriority.UseBorderColor = False
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseForeColor = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Collateral"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel15
        '
        Me.XrLabel15.BackColor = System.Drawing.Color.White
        Me.XrLabel15.BorderColor = System.Drawing.Color.Black
        Me.XrLabel15.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel15.CanGrow = False
        Me.XrLabel15.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel15.ForeColor = System.Drawing.Color.Black
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(375.0!, 0!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.XrLabel15.StylePriority.UseBackColor = False
        Me.XrLabel15.StylePriority.UseBorderColor = False
        Me.XrLabel15.StylePriority.UseBorders = False
        Me.XrLabel15.StylePriority.UseFont = False
        Me.XrLabel15.StylePriority.UseForeColor = False
        Me.XrLabel15.StylePriority.UseTextAlignment = False
        Me.XrLabel15.Text = "Account Number"
        Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel5
        '
        Me.XrLabel5.BackColor = System.Drawing.Color.White
        Me.XrLabel5.BorderColor = System.Drawing.Color.Black
        Me.XrLabel5.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel5.CanGrow = False
        Me.XrLabel5.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.ForeColor = System.Drawing.Color.Black
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.XrLabel5.StylePriority.UseBackColor = False
        Me.XrLabel5.StylePriority.UseBorderColor = False
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseForeColor = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "Product"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel1
        '
        Me.XrLabel1.BackColor = System.Drawing.Color.White
        Me.XrLabel1.BorderColor = System.Drawing.Color.Black
        Me.XrLabel1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel1.CanGrow = False
        Me.XrLabel1.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.ForeColor = System.Drawing.Color.Black
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.XrLabel1.StylePriority.UseBackColor = False
        Me.XrLabel1.StylePriority.UseBorderColor = False
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseForeColor = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "BorrowerID"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel3
        '
        Me.XrLabel3.BackColor = System.Drawing.Color.White
        Me.XrLabel3.BorderColor = System.Drawing.Color.Black
        Me.XrLabel3.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel3.CanGrow = False
        Me.XrLabel3.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.ForeColor = System.Drawing.Color.Black
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(125.0!, 0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.XrLabel3.StylePriority.UseBackColor = False
        Me.XrLabel3.StylePriority.UseBorderColor = False
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseForeColor = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "Business Center"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'RptBulkMigration
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
        Me.PageHeight = 800
        Me.PageWidth = 2395
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBorrowerID As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBusinessCenter As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblProduct As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCollateral As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTerms As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInterestRate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDateAvailed As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRPPDRate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblLastPayment As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrincipal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDueDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrincipalBalance As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblUDI As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblUDIBalance As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRPPD As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRPPDBalance As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblUnpaidPenalty As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblGMA As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMonthlyRabate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBank As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel23 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel19 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel84 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblIndustry As DevExpress.XtraReports.UI.XRLabel
End Class
