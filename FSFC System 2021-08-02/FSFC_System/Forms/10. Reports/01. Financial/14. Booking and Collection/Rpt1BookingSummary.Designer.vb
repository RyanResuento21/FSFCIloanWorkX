<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class Rpt1BookingSummary
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
        Me.lblProduct = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblProductCode = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblWeek1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblWeek2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblWeek3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblWeek4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblWeek5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblWeekT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblWeekP = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblID = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblProcessing = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblService = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInsurance = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMiscellaneous = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblProduct, Me.lblProductCode, Me.lblWeek1, Me.lblWeek2, Me.lblWeek3, Me.lblWeek4, Me.lblWeek5, Me.lblWeekT, Me.lblWeekP, Me.lblID, Me.lblProcessing, Me.lblService, Me.lblInsurance, Me.lblMiscellaneous})
        Me.Detail.HeightF = 15.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblProduct
        '
        Me.lblProduct.BackColor = System.Drawing.Color.White
        Me.lblProduct.BorderColor = System.Drawing.Color.Black
        Me.lblProduct.Borders = DevExpress.XtraPrinting.BorderSide.Left
        Me.lblProduct.CanGrow = False
        Me.lblProduct.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProduct.ForeColor = System.Drawing.Color.Black
        Me.lblProduct.LocationFloat = New DevExpress.Utils.PointFloat(0.00006103516!, 0.0!)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblProduct.SizeF = New System.Drawing.SizeF(170.0!, 15.0!)
        Me.lblProduct.StylePriority.UseBackColor = False
        Me.lblProduct.StylePriority.UseBorderColor = False
        Me.lblProduct.StylePriority.UseBorders = False
        Me.lblProduct.StylePriority.UseFont = False
        Me.lblProduct.StylePriority.UseForeColor = False
        Me.lblProduct.StylePriority.UseTextAlignment = False
        Me.lblProduct.Text = "Vehicle Loan"
        Me.lblProduct.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblProductCode
        '
        Me.lblProductCode.BackColor = System.Drawing.Color.White
        Me.lblProductCode.BorderColor = System.Drawing.Color.Black
        Me.lblProductCode.Borders = DevExpress.XtraPrinting.BorderSide.Left
        Me.lblProductCode.CanGrow = False
        Me.lblProductCode.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold)
        Me.lblProductCode.ForeColor = System.Drawing.Color.Black
        Me.lblProductCode.LocationFloat = New DevExpress.Utils.PointFloat(170.0001!, 0.0!)
        Me.lblProductCode.Name = "lblProductCode"
        Me.lblProductCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblProductCode.SizeF = New System.Drawing.SizeF(99.99998!, 15.0!)
        Me.lblProductCode.StylePriority.UseBackColor = False
        Me.lblProductCode.StylePriority.UseBorderColor = False
        Me.lblProductCode.StylePriority.UseBorders = False
        Me.lblProductCode.StylePriority.UseFont = False
        Me.lblProductCode.StylePriority.UseForeColor = False
        Me.lblProductCode.StylePriority.UseTextAlignment = False
        Me.lblProductCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblWeek1
        '
        Me.lblWeek1.BackColor = System.Drawing.Color.White
        Me.lblWeek1.BorderColor = System.Drawing.Color.Black
        Me.lblWeek1.Borders = DevExpress.XtraPrinting.BorderSide.Left
        Me.lblWeek1.CanGrow = False
        Me.lblWeek1.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeek1.ForeColor = System.Drawing.Color.Black
        Me.lblWeek1.LocationFloat = New DevExpress.Utils.PointFloat(270.0!, 0.0!)
        Me.lblWeek1.Name = "lblWeek1"
        Me.lblWeek1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblWeek1.SizeF = New System.Drawing.SizeF(99.99998!, 15.0!)
        Me.lblWeek1.StylePriority.UseBackColor = False
        Me.lblWeek1.StylePriority.UseBorderColor = False
        Me.lblWeek1.StylePriority.UseBorders = False
        Me.lblWeek1.StylePriority.UseFont = False
        Me.lblWeek1.StylePriority.UseForeColor = False
        Me.lblWeek1.StylePriority.UseTextAlignment = False
        Me.lblWeek1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblWeek1.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblWeek2
        '
        Me.lblWeek2.BackColor = System.Drawing.Color.White
        Me.lblWeek2.BorderColor = System.Drawing.Color.Black
        Me.lblWeek2.Borders = DevExpress.XtraPrinting.BorderSide.Left
        Me.lblWeek2.CanGrow = False
        Me.lblWeek2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeek2.ForeColor = System.Drawing.Color.Black
        Me.lblWeek2.LocationFloat = New DevExpress.Utils.PointFloat(370.0!, 0.0!)
        Me.lblWeek2.Name = "lblWeek2"
        Me.lblWeek2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblWeek2.SizeF = New System.Drawing.SizeF(99.99998!, 15.0!)
        Me.lblWeek2.StylePriority.UseBackColor = False
        Me.lblWeek2.StylePriority.UseBorderColor = False
        Me.lblWeek2.StylePriority.UseBorders = False
        Me.lblWeek2.StylePriority.UseFont = False
        Me.lblWeek2.StylePriority.UseForeColor = False
        Me.lblWeek2.StylePriority.UseTextAlignment = False
        Me.lblWeek2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblWeek2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblWeek3
        '
        Me.lblWeek3.BackColor = System.Drawing.Color.White
        Me.lblWeek3.BorderColor = System.Drawing.Color.Black
        Me.lblWeek3.Borders = DevExpress.XtraPrinting.BorderSide.Left
        Me.lblWeek3.CanGrow = False
        Me.lblWeek3.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeek3.ForeColor = System.Drawing.Color.Black
        Me.lblWeek3.LocationFloat = New DevExpress.Utils.PointFloat(470.0!, 0.0!)
        Me.lblWeek3.Name = "lblWeek3"
        Me.lblWeek3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblWeek3.SizeF = New System.Drawing.SizeF(99.99998!, 15.0!)
        Me.lblWeek3.StylePriority.UseBackColor = False
        Me.lblWeek3.StylePriority.UseBorderColor = False
        Me.lblWeek3.StylePriority.UseBorders = False
        Me.lblWeek3.StylePriority.UseFont = False
        Me.lblWeek3.StylePriority.UseForeColor = False
        Me.lblWeek3.StylePriority.UseTextAlignment = False
        Me.lblWeek3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblWeek3.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblWeek4
        '
        Me.lblWeek4.BackColor = System.Drawing.Color.White
        Me.lblWeek4.BorderColor = System.Drawing.Color.Black
        Me.lblWeek4.Borders = DevExpress.XtraPrinting.BorderSide.Left
        Me.lblWeek4.CanGrow = False
        Me.lblWeek4.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeek4.ForeColor = System.Drawing.Color.Black
        Me.lblWeek4.LocationFloat = New DevExpress.Utils.PointFloat(570.0001!, 0.0!)
        Me.lblWeek4.Name = "lblWeek4"
        Me.lblWeek4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblWeek4.SizeF = New System.Drawing.SizeF(99.99998!, 15.0!)
        Me.lblWeek4.StylePriority.UseBackColor = False
        Me.lblWeek4.StylePriority.UseBorderColor = False
        Me.lblWeek4.StylePriority.UseBorders = False
        Me.lblWeek4.StylePriority.UseFont = False
        Me.lblWeek4.StylePriority.UseForeColor = False
        Me.lblWeek4.StylePriority.UseTextAlignment = False
        Me.lblWeek4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblWeek4.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblWeek5
        '
        Me.lblWeek5.BackColor = System.Drawing.Color.White
        Me.lblWeek5.BorderColor = System.Drawing.Color.Black
        Me.lblWeek5.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.lblWeek5.CanGrow = False
        Me.lblWeek5.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeek5.ForeColor = System.Drawing.Color.Black
        Me.lblWeek5.LocationFloat = New DevExpress.Utils.PointFloat(670.0001!, 0.0!)
        Me.lblWeek5.Name = "lblWeek5"
        Me.lblWeek5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblWeek5.SizeF = New System.Drawing.SizeF(99.99998!, 15.0!)
        Me.lblWeek5.StylePriority.UseBackColor = False
        Me.lblWeek5.StylePriority.UseBorderColor = False
        Me.lblWeek5.StylePriority.UseBorders = False
        Me.lblWeek5.StylePriority.UseFont = False
        Me.lblWeek5.StylePriority.UseForeColor = False
        Me.lblWeek5.StylePriority.UseTextAlignment = False
        Me.lblWeek5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblWeek5.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblWeekT
        '
        Me.lblWeekT.BackColor = System.Drawing.Color.White
        Me.lblWeekT.BorderColor = System.Drawing.Color.Black
        Me.lblWeekT.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblWeekT.CanGrow = False
        Me.lblWeekT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeekT.ForeColor = System.Drawing.Color.Black
        Me.lblWeekT.LocationFloat = New DevExpress.Utils.PointFloat(770.0!, 0.0!)
        Me.lblWeekT.Name = "lblWeekT"
        Me.lblWeekT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblWeekT.SizeF = New System.Drawing.SizeF(99.99998!, 15.0!)
        Me.lblWeekT.StylePriority.UseBackColor = False
        Me.lblWeekT.StylePriority.UseBorderColor = False
        Me.lblWeekT.StylePriority.UseBorders = False
        Me.lblWeekT.StylePriority.UseFont = False
        Me.lblWeekT.StylePriority.UseForeColor = False
        Me.lblWeekT.StylePriority.UseTextAlignment = False
        Me.lblWeekT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblWeekT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblWeekP
        '
        Me.lblWeekP.BackColor = System.Drawing.Color.White
        Me.lblWeekP.BorderColor = System.Drawing.Color.Black
        Me.lblWeekP.Borders = DevExpress.XtraPrinting.BorderSide.Left
        Me.lblWeekP.CanGrow = False
        Me.lblWeekP.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeekP.ForeColor = System.Drawing.Color.Black
        Me.lblWeekP.LocationFloat = New DevExpress.Utils.PointFloat(870.0!, 0.0!)
        Me.lblWeekP.Name = "lblWeekP"
        Me.lblWeekP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblWeekP.SizeF = New System.Drawing.SizeF(50.00006!, 15.0!)
        Me.lblWeekP.StylePriority.UseBackColor = False
        Me.lblWeekP.StylePriority.UseBorderColor = False
        Me.lblWeekP.StylePriority.UseBorders = False
        Me.lblWeekP.StylePriority.UseFont = False
        Me.lblWeekP.StylePriority.UseForeColor = False
        Me.lblWeekP.StylePriority.UseTextAlignment = False
        Me.lblWeekP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblWeekP.XlsxFormatString = "0.00%"
        '
        'lblID
        '
        Me.lblID.BackColor = System.Drawing.Color.Silver
        Me.lblID.BorderColor = System.Drawing.Color.Black
        Me.lblID.Borders = DevExpress.XtraPrinting.BorderSide.Left
        Me.lblID.CanGrow = False
        Me.lblID.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.ForeColor = System.Drawing.Color.Black
        Me.lblID.LocationFloat = New DevExpress.Utils.PointFloat(920.0!, 0.0!)
        Me.lblID.Name = "lblID"
        Me.lblID.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblID.SizeF = New System.Drawing.SizeF(10.0!, 15.0!)
        Me.lblID.StylePriority.UseBackColor = False
        Me.lblID.StylePriority.UseBorderColor = False
        Me.lblID.StylePriority.UseBorders = False
        Me.lblID.StylePriority.UseFont = False
        Me.lblID.StylePriority.UseForeColor = False
        Me.lblID.StylePriority.UseTextAlignment = False
        Me.lblID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblProcessing
        '
        Me.lblProcessing.BackColor = System.Drawing.Color.White
        Me.lblProcessing.BorderColor = System.Drawing.Color.Black
        Me.lblProcessing.Borders = DevExpress.XtraPrinting.BorderSide.Left
        Me.lblProcessing.CanGrow = False
        Me.lblProcessing.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessing.ForeColor = System.Drawing.Color.Black
        Me.lblProcessing.LocationFloat = New DevExpress.Utils.PointFloat(930.0!, 0.0!)
        Me.lblProcessing.Name = "lblProcessing"
        Me.lblProcessing.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblProcessing.SizeF = New System.Drawing.SizeF(100.0001!, 15.0!)
        Me.lblProcessing.StylePriority.UseBackColor = False
        Me.lblProcessing.StylePriority.UseBorderColor = False
        Me.lblProcessing.StylePriority.UseBorders = False
        Me.lblProcessing.StylePriority.UseFont = False
        Me.lblProcessing.StylePriority.UseForeColor = False
        Me.lblProcessing.StylePriority.UseTextAlignment = False
        Me.lblProcessing.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblProcessing.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblService
        '
        Me.lblService.BackColor = System.Drawing.Color.White
        Me.lblService.BorderColor = System.Drawing.Color.Black
        Me.lblService.Borders = DevExpress.XtraPrinting.BorderSide.Left
        Me.lblService.CanGrow = False
        Me.lblService.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblService.ForeColor = System.Drawing.Color.Black
        Me.lblService.LocationFloat = New DevExpress.Utils.PointFloat(1030.0!, 0.0!)
        Me.lblService.Name = "lblService"
        Me.lblService.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblService.SizeF = New System.Drawing.SizeF(99.99988!, 15.0!)
        Me.lblService.StylePriority.UseBackColor = False
        Me.lblService.StylePriority.UseBorderColor = False
        Me.lblService.StylePriority.UseBorders = False
        Me.lblService.StylePriority.UseFont = False
        Me.lblService.StylePriority.UseForeColor = False
        Me.lblService.StylePriority.UseTextAlignment = False
        Me.lblService.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblService.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblInsurance
        '
        Me.lblInsurance.BackColor = System.Drawing.Color.White
        Me.lblInsurance.BorderColor = System.Drawing.Color.Black
        Me.lblInsurance.Borders = DevExpress.XtraPrinting.BorderSide.Left
        Me.lblInsurance.CanGrow = False
        Me.lblInsurance.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInsurance.ForeColor = System.Drawing.Color.Black
        Me.lblInsurance.LocationFloat = New DevExpress.Utils.PointFloat(1130.0!, 0.0!)
        Me.lblInsurance.Name = "lblInsurance"
        Me.lblInsurance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInsurance.SizeF = New System.Drawing.SizeF(110.0!, 15.0!)
        Me.lblInsurance.StylePriority.UseBackColor = False
        Me.lblInsurance.StylePriority.UseBorderColor = False
        Me.lblInsurance.StylePriority.UseBorders = False
        Me.lblInsurance.StylePriority.UseFont = False
        Me.lblInsurance.StylePriority.UseForeColor = False
        Me.lblInsurance.StylePriority.UseTextAlignment = False
        Me.lblInsurance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblInsurance.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblMiscellaneous
        '
        Me.lblMiscellaneous.BackColor = System.Drawing.Color.White
        Me.lblMiscellaneous.BorderColor = System.Drawing.Color.Black
        Me.lblMiscellaneous.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.lblMiscellaneous.CanGrow = False
        Me.lblMiscellaneous.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMiscellaneous.ForeColor = System.Drawing.Color.Black
        Me.lblMiscellaneous.LocationFloat = New DevExpress.Utils.PointFloat(1240.0!, 0.0!)
        Me.lblMiscellaneous.Name = "lblMiscellaneous"
        Me.lblMiscellaneous.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMiscellaneous.SizeF = New System.Drawing.SizeF(110.0!, 15.0!)
        Me.lblMiscellaneous.StylePriority.UseBackColor = False
        Me.lblMiscellaneous.StylePriority.UseBorderColor = False
        Me.lblMiscellaneous.StylePriority.UseBorders = False
        Me.lblMiscellaneous.StylePriority.UseFont = False
        Me.lblMiscellaneous.StylePriority.UseForeColor = False
        Me.lblMiscellaneous.StylePriority.UseTextAlignment = False
        Me.lblMiscellaneous.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblMiscellaneous.XlsxFormatString = "#,##0.00_);(#,##0.00)"
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
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel15, Me.XrLabel14, Me.XrLabel13, Me.XrLabel12, Me.XrLabel11, Me.XrLabel10, Me.XrLabel9, Me.XrLabel8, Me.XrLabel7, Me.XrLabel6, Me.XrLabel5, Me.XrLabel4, Me.XrLabel3, Me.XrLabel2, Me.XrLabel1, Me.lblTitle})
        Me.ReportHeader.HeightF = 30.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrLabel15
        '
        Me.XrLabel15.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel15.BorderColor = System.Drawing.Color.Black
        Me.XrLabel15.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel15.CanGrow = False
        Me.XrLabel15.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel15.ForeColor = System.Drawing.Color.White
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(1240.0!, 14.99999!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(110.0!, 15.0!)
        Me.XrLabel15.StylePriority.UseBackColor = False
        Me.XrLabel15.StylePriority.UseBorderColor = False
        Me.XrLabel15.StylePriority.UseBorders = False
        Me.XrLabel15.StylePriority.UseFont = False
        Me.XrLabel15.StylePriority.UseForeColor = False
        Me.XrLabel15.StylePriority.UseTextAlignment = False
        Me.XrLabel15.Text = "Miscellaneous Income"
        Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel14
        '
        Me.XrLabel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel14.BorderColor = System.Drawing.Color.Black
        Me.XrLabel14.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel14.CanGrow = False
        Me.XrLabel14.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel14.ForeColor = System.Drawing.Color.White
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(1130.0!, 14.99999!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(110.0!, 15.0!)
        Me.XrLabel14.StylePriority.UseBackColor = False
        Me.XrLabel14.StylePriority.UseBorderColor = False
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.StylePriority.UseForeColor = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = "Insurance Commission"
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel13
        '
        Me.XrLabel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel13.BorderColor = System.Drawing.Color.Black
        Me.XrLabel13.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel13.CanGrow = False
        Me.XrLabel13.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel13.ForeColor = System.Drawing.Color.White
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(1030.0!, 14.99999!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(100.0!, 15.0!)
        Me.XrLabel13.StylePriority.UseBackColor = False
        Me.XrLabel13.StylePriority.UseBorderColor = False
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.StylePriority.UseFont = False
        Me.XrLabel13.StylePriority.UseForeColor = False
        Me.XrLabel13.StylePriority.UseTextAlignment = False
        Me.XrLabel13.Text = "Service Charge"
        Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel12
        '
        Me.XrLabel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel12.BorderColor = System.Drawing.Color.Black
        Me.XrLabel12.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel12.CanGrow = False
        Me.XrLabel12.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel12.ForeColor = System.Drawing.Color.White
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(930.0!, 14.99999!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(100.0!, 15.0!)
        Me.XrLabel12.StylePriority.UseBackColor = False
        Me.XrLabel12.StylePriority.UseBorderColor = False
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseForeColor = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = "Processing Fee"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel11
        '
        Me.XrLabel11.BackColor = System.Drawing.Color.Silver
        Me.XrLabel11.BorderColor = System.Drawing.Color.Black
        Me.XrLabel11.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel11.CanGrow = False
        Me.XrLabel11.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel11.ForeColor = System.Drawing.Color.Black
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(920.0!, 14.99999!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(10.0!, 15.0!)
        Me.XrLabel11.StylePriority.UseBackColor = False
        Me.XrLabel11.StylePriority.UseBorderColor = False
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseForeColor = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel10
        '
        Me.XrLabel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel10.BorderColor = System.Drawing.Color.Black
        Me.XrLabel10.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel10.CanGrow = False
        Me.XrLabel10.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel10.ForeColor = System.Drawing.Color.White
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(870.0!, 14.99999!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(50.0!, 15.0!)
        Me.XrLabel10.StylePriority.UseBackColor = False
        Me.XrLabel10.StylePriority.UseBorderColor = False
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseForeColor = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = "%"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel9
        '
        Me.XrLabel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel9.BorderColor = System.Drawing.Color.Black
        Me.XrLabel9.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel9.CanGrow = False
        Me.XrLabel9.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.ForeColor = System.Drawing.Color.White
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(770.0!, 14.99999!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(100.0!, 15.0!)
        Me.XrLabel9.StylePriority.UseBackColor = False
        Me.XrLabel9.StylePriority.UseBorderColor = False
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseForeColor = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = "TOTAL"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel8
        '
        Me.XrLabel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel8.BorderColor = System.Drawing.Color.Black
        Me.XrLabel8.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel8.CanGrow = False
        Me.XrLabel8.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.ForeColor = System.Drawing.Color.White
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(670.0!, 14.99999!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(100.0!, 15.0!)
        Me.XrLabel8.StylePriority.UseBackColor = False
        Me.XrLabel8.StylePriority.UseBorderColor = False
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseForeColor = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "5"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel7
        '
        Me.XrLabel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel7.BorderColor = System.Drawing.Color.Black
        Me.XrLabel7.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel7.CanGrow = False
        Me.XrLabel7.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.ForeColor = System.Drawing.Color.White
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(570.0!, 14.99999!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(100.0!, 15.0!)
        Me.XrLabel7.StylePriority.UseBackColor = False
        Me.XrLabel7.StylePriority.UseBorderColor = False
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseForeColor = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "4"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel6
        '
        Me.XrLabel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel6.BorderColor = System.Drawing.Color.Black
        Me.XrLabel6.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel6.CanGrow = False
        Me.XrLabel6.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.ForeColor = System.Drawing.Color.White
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(470.0!, 14.99999!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(100.0!, 15.0!)
        Me.XrLabel6.StylePriority.UseBackColor = False
        Me.XrLabel6.StylePriority.UseBorderColor = False
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseForeColor = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "3"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel5
        '
        Me.XrLabel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel5.BorderColor = System.Drawing.Color.Black
        Me.XrLabel5.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel5.CanGrow = False
        Me.XrLabel5.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.ForeColor = System.Drawing.Color.White
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(370.0!, 14.99999!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(100.0!, 15.0!)
        Me.XrLabel5.StylePriority.UseBackColor = False
        Me.XrLabel5.StylePriority.UseBorderColor = False
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseForeColor = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "2"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel4
        '
        Me.XrLabel4.BackColor = System.Drawing.Color.Yellow
        Me.XrLabel4.BorderColor = System.Drawing.Color.Black
        Me.XrLabel4.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel4.CanGrow = False
        Me.XrLabel4.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.ForeColor = System.Drawing.Color.Black
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(270.0!, 0.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(500.0!, 15.0!)
        Me.XrLabel4.StylePriority.UseBackColor = False
        Me.XrLabel4.StylePriority.UseBorderColor = False
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseForeColor = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "Week"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel3
        '
        Me.XrLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel3.BorderColor = System.Drawing.Color.Black
        Me.XrLabel3.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel3.CanGrow = False
        Me.XrLabel3.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.ForeColor = System.Drawing.Color.White
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(270.0!, 14.99999!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(100.0!, 15.0!)
        Me.XrLabel3.StylePriority.UseBackColor = False
        Me.XrLabel3.StylePriority.UseBorderColor = False
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseForeColor = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "1"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel2
        '
        Me.XrLabel2.BackColor = System.Drawing.Color.Yellow
        Me.XrLabel2.BorderColor = System.Drawing.Color.Black
        Me.XrLabel2.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel2.CanGrow = False
        Me.XrLabel2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.ForeColor = System.Drawing.Color.Black
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(170.0!, 14.99999!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(100.0!, 15.0!)
        Me.XrLabel2.StylePriority.UseBackColor = False
        Me.XrLabel2.StylePriority.UseBorderColor = False
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseForeColor = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Product Code"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel1
        '
        Me.XrLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel1.BorderColor = System.Drawing.Color.Black
        Me.XrLabel1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel1.CanGrow = False
        Me.XrLabel1.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.ForeColor = System.Drawing.Color.White
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.000007947286!, 14.99999!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(170.0!, 15.0!)
        Me.XrLabel1.StylePriority.UseBackColor = False
        Me.XrLabel1.StylePriority.UseBorderColor = False
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseForeColor = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "PRODUCT"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.White
        Me.lblTitle.BorderColor = System.Drawing.Color.Black
        Me.lblTitle.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblTitle.CanGrow = False
        Me.lblTitle.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTitle.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 0.0!)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTitle.SizeF = New System.Drawing.SizeF(269.9999!, 15.0!)
        Me.lblTitle.StylePriority.UseBackColor = False
        Me.lblTitle.StylePriority.UseBorderColor = False
        Me.lblTitle.StylePriority.UseBorders = False
        Me.lblTitle.StylePriority.UseFont = False
        Me.lblTitle.StylePriority.UseForeColor = False
        Me.lblTitle.StylePriority.UseTextAlignment = False
        Me.lblTitle.Text = "BOOKINGS"
        Me.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1, Me.XrPageInfo2})
        Me.PageFooter.HeightF = 15.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.BackColor = System.Drawing.Color.White
        Me.XrPageInfo1.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(400.0!, 15.0!)
        Me.XrPageInfo1.StylePriority.UseBackColor = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.BackColor = System.Drawing.Color.White
        Me.XrPageInfo2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo2.Format = "{0:dddd, MMMM d, yyyy h:mm tt}"
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(950.0!, 0.0!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(400.0!, 15.0!)
        Me.XrPageInfo2.StylePriority.UseBackColor = False
        Me.XrPageInfo2.StylePriority.UseFont = False
        Me.XrPageInfo2.StylePriority.UseTextAlignment = False
        Me.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel16})
        Me.ReportFooter.HeightF = 5.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrLabel16
        '
        Me.XrLabel16.BackColor = System.Drawing.Color.White
        Me.XrLabel16.BorderColor = System.Drawing.Color.Black
        Me.XrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.XrLabel16.CanGrow = False
        Me.XrLabel16.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold)
        Me.XrLabel16.ForeColor = System.Drawing.Color.Black
        Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 0.0!)
        Me.XrLabel16.Name = "XrLabel16"
        Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel16.SizeF = New System.Drawing.SizeF(1350.0!, 5.0!)
        Me.XrLabel16.StylePriority.UseBackColor = False
        Me.XrLabel16.StylePriority.UseBorderColor = False
        Me.XrLabel16.StylePriority.UseBorders = False
        Me.XrLabel16.StylePriority.UseFont = False
        Me.XrLabel16.StylePriority.UseForeColor = False
        Me.XrLabel16.StylePriority.UseTextAlignment = False
        Me.XrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'rpt1BookingSummary
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.PageFooter, Me.ReportFooter})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.PageHeight = 850
        Me.PageWidth = 1400
        Me.PaperKind = System.Drawing.Printing.PaperKind.Legal
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblProduct As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblProductCode As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblWeek1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblWeek2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblWeek3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblWeek4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblWeek5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblWeekT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblWeekP As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblID As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblProcessing As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblService As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInsurance As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMiscellaneous As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
End Class
