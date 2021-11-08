<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class RptSubScheduleVL
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.lblClassification = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblOver3Years = New DevExpress.XtraReports.UI.XRLabel()
        Me.lbl1Year_3Years = New DevExpress.XtraReports.UI.XRLabel()
        Me.lbl90Days_1Year = New DevExpress.XtraReports.UI.XRLabel()
        Me.lbl1_90Days = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInspection = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblObservation = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNetBook = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblSelling = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNature = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBookValue = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblImpairment = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPlateNum = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDescription = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountName = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblClassification, Me.lblOver3Years, Me.lbl1Year_3Years, Me.lbl90Days_1Year, Me.lbl1_90Days, Me.lblInspection, Me.lblObservation, Me.lblNetBook, Me.lblSelling, Me.lblNature, Me.lblDate, Me.lblBookValue, Me.lblImpairment, Me.lblPlateNum, Me.lblAccountNo, Me.lblDescription, Me.lblNo, Me.lblAccountName})
        Me.Detail.HeightF = 35.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblClassification
        '
        Me.lblClassification.BackColor = System.Drawing.Color.White
        Me.lblClassification.BorderColor = System.Drawing.Color.Black
        Me.lblClassification.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblClassification.BorderWidth = 1.0!
        Me.lblClassification.CanGrow = False
        Me.lblClassification.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClassification.ForeColor = System.Drawing.Color.Black
        Me.lblClassification.LocationFloat = New DevExpress.Utils.PointFloat(1080.0!, 0.0!)
        Me.lblClassification.Name = "lblClassification"
        Me.lblClassification.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblClassification.SizeF = New System.Drawing.SizeF(70.0!, 35.0!)
        Me.lblClassification.StylePriority.UseBackColor = False
        Me.lblClassification.StylePriority.UseBorderColor = False
        Me.lblClassification.StylePriority.UseBorders = False
        Me.lblClassification.StylePriority.UseBorderWidth = False
        Me.lblClassification.StylePriority.UseFont = False
        Me.lblClassification.StylePriority.UseForeColor = False
        Me.lblClassification.StylePriority.UseTextAlignment = False
        Me.lblClassification.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblOver3Years
        '
        Me.lblOver3Years.BackColor = System.Drawing.Color.White
        Me.lblOver3Years.BorderColor = System.Drawing.Color.Black
        Me.lblOver3Years.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblOver3Years.BorderWidth = 1.0!
        Me.lblOver3Years.CanGrow = False
        Me.lblOver3Years.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOver3Years.ForeColor = System.Drawing.Color.Black
        Me.lblOver3Years.LocationFloat = New DevExpress.Utils.PointFloat(884.9999!, 0.0!)
        Me.lblOver3Years.Name = "lblOver3Years"
        Me.lblOver3Years.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblOver3Years.SizeF = New System.Drawing.SizeF(70.0!, 35.0!)
        Me.lblOver3Years.StylePriority.UseBackColor = False
        Me.lblOver3Years.StylePriority.UseBorderColor = False
        Me.lblOver3Years.StylePriority.UseBorders = False
        Me.lblOver3Years.StylePriority.UseBorderWidth = False
        Me.lblOver3Years.StylePriority.UseFont = False
        Me.lblOver3Years.StylePriority.UseForeColor = False
        Me.lblOver3Years.StylePriority.UseTextAlignment = False
        Me.lblOver3Years.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblOver3Years.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lbl1Year_3Years
        '
        Me.lbl1Year_3Years.BackColor = System.Drawing.Color.White
        Me.lbl1Year_3Years.BorderColor = System.Drawing.Color.Black
        Me.lbl1Year_3Years.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lbl1Year_3Years.BorderWidth = 1.0!
        Me.lbl1Year_3Years.CanGrow = False
        Me.lbl1Year_3Years.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1Year_3Years.ForeColor = System.Drawing.Color.Black
        Me.lbl1Year_3Years.LocationFloat = New DevExpress.Utils.PointFloat(814.9999!, 0.0!)
        Me.lbl1Year_3Years.Name = "lbl1Year_3Years"
        Me.lbl1Year_3Years.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lbl1Year_3Years.SizeF = New System.Drawing.SizeF(70.0!, 35.0!)
        Me.lbl1Year_3Years.StylePriority.UseBackColor = False
        Me.lbl1Year_3Years.StylePriority.UseBorderColor = False
        Me.lbl1Year_3Years.StylePriority.UseBorders = False
        Me.lbl1Year_3Years.StylePriority.UseBorderWidth = False
        Me.lbl1Year_3Years.StylePriority.UseFont = False
        Me.lbl1Year_3Years.StylePriority.UseForeColor = False
        Me.lbl1Year_3Years.StylePriority.UseTextAlignment = False
        Me.lbl1Year_3Years.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lbl1Year_3Years.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lbl90Days_1Year
        '
        Me.lbl90Days_1Year.BackColor = System.Drawing.Color.White
        Me.lbl90Days_1Year.BorderColor = System.Drawing.Color.Black
        Me.lbl90Days_1Year.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lbl90Days_1Year.BorderWidth = 1.0!
        Me.lbl90Days_1Year.CanGrow = False
        Me.lbl90Days_1Year.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl90Days_1Year.ForeColor = System.Drawing.Color.Black
        Me.lbl90Days_1Year.LocationFloat = New DevExpress.Utils.PointFloat(745.0!, 0.0!)
        Me.lbl90Days_1Year.Name = "lbl90Days_1Year"
        Me.lbl90Days_1Year.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lbl90Days_1Year.SizeF = New System.Drawing.SizeF(70.0!, 35.0!)
        Me.lbl90Days_1Year.StylePriority.UseBackColor = False
        Me.lbl90Days_1Year.StylePriority.UseBorderColor = False
        Me.lbl90Days_1Year.StylePriority.UseBorders = False
        Me.lbl90Days_1Year.StylePriority.UseBorderWidth = False
        Me.lbl90Days_1Year.StylePriority.UseFont = False
        Me.lbl90Days_1Year.StylePriority.UseForeColor = False
        Me.lbl90Days_1Year.StylePriority.UseTextAlignment = False
        Me.lbl90Days_1Year.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lbl90Days_1Year.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lbl1_90Days
        '
        Me.lbl1_90Days.BackColor = System.Drawing.Color.White
        Me.lbl1_90Days.BorderColor = System.Drawing.Color.Black
        Me.lbl1_90Days.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lbl1_90Days.BorderWidth = 1.0!
        Me.lbl1_90Days.CanGrow = False
        Me.lbl1_90Days.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1_90Days.ForeColor = System.Drawing.Color.Black
        Me.lbl1_90Days.LocationFloat = New DevExpress.Utils.PointFloat(675.0!, 0.0!)
        Me.lbl1_90Days.Name = "lbl1_90Days"
        Me.lbl1_90Days.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lbl1_90Days.SizeF = New System.Drawing.SizeF(70.0!, 35.0!)
        Me.lbl1_90Days.StylePriority.UseBackColor = False
        Me.lbl1_90Days.StylePriority.UseBorderColor = False
        Me.lbl1_90Days.StylePriority.UseBorders = False
        Me.lbl1_90Days.StylePriority.UseBorderWidth = False
        Me.lbl1_90Days.StylePriority.UseFont = False
        Me.lbl1_90Days.StylePriority.UseForeColor = False
        Me.lbl1_90Days.StylePriority.UseTextAlignment = False
        Me.lbl1_90Days.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lbl1_90Days.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblInspection
        '
        Me.lblInspection.BackColor = System.Drawing.Color.White
        Me.lblInspection.BorderColor = System.Drawing.Color.Black
        Me.lblInspection.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblInspection.BorderWidth = 1.0!
        Me.lblInspection.CanGrow = False
        Me.lblInspection.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInspection.ForeColor = System.Drawing.Color.Black
        Me.lblInspection.LocationFloat = New DevExpress.Utils.PointFloat(1025.0!, 0.0!)
        Me.lblInspection.Name = "lblInspection"
        Me.lblInspection.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInspection.SizeF = New System.Drawing.SizeF(55.0!, 35.0!)
        Me.lblInspection.StylePriority.UseBackColor = False
        Me.lblInspection.StylePriority.UseBorderColor = False
        Me.lblInspection.StylePriority.UseBorders = False
        Me.lblInspection.StylePriority.UseBorderWidth = False
        Me.lblInspection.StylePriority.UseFont = False
        Me.lblInspection.StylePriority.UseForeColor = False
        Me.lblInspection.StylePriority.UseTextAlignment = False
        Me.lblInspection.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblObservation
        '
        Me.lblObservation.BackColor = System.Drawing.Color.White
        Me.lblObservation.BorderColor = System.Drawing.Color.Black
        Me.lblObservation.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblObservation.BorderWidth = 1.0!
        Me.lblObservation.CanGrow = False
        Me.lblObservation.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservation.ForeColor = System.Drawing.Color.Black
        Me.lblObservation.LocationFloat = New DevExpress.Utils.PointFloat(1150.0!, 0.0!)
        Me.lblObservation.Name = "lblObservation"
        Me.lblObservation.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblObservation.SizeF = New System.Drawing.SizeF(100.0!, 35.0!)
        Me.lblObservation.StylePriority.UseBackColor = False
        Me.lblObservation.StylePriority.UseBorderColor = False
        Me.lblObservation.StylePriority.UseBorders = False
        Me.lblObservation.StylePriority.UseBorderWidth = False
        Me.lblObservation.StylePriority.UseFont = False
        Me.lblObservation.StylePriority.UseForeColor = False
        Me.lblObservation.StylePriority.UseTextAlignment = False
        Me.lblObservation.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblNetBook
        '
        Me.lblNetBook.BackColor = System.Drawing.Color.White
        Me.lblNetBook.BorderColor = System.Drawing.Color.Black
        Me.lblNetBook.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblNetBook.BorderWidth = 1.0!
        Me.lblNetBook.CanGrow = False
        Me.lblNetBook.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNetBook.ForeColor = System.Drawing.Color.Black
        Me.lblNetBook.LocationFloat = New DevExpress.Utils.PointFloat(605.0!, 0.0!)
        Me.lblNetBook.Name = "lblNetBook"
        Me.lblNetBook.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNetBook.SizeF = New System.Drawing.SizeF(70.0!, 35.0!)
        Me.lblNetBook.StylePriority.UseBackColor = False
        Me.lblNetBook.StylePriority.UseBorderColor = False
        Me.lblNetBook.StylePriority.UseBorders = False
        Me.lblNetBook.StylePriority.UseBorderWidth = False
        Me.lblNetBook.StylePriority.UseFont = False
        Me.lblNetBook.StylePriority.UseForeColor = False
        Me.lblNetBook.StylePriority.UseTextAlignment = False
        Me.lblNetBook.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblNetBook.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblSelling
        '
        Me.lblSelling.BackColor = System.Drawing.Color.White
        Me.lblSelling.BorderColor = System.Drawing.Color.Black
        Me.lblSelling.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblSelling.BorderWidth = 1.0!
        Me.lblSelling.CanGrow = False
        Me.lblSelling.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelling.ForeColor = System.Drawing.Color.Black
        Me.lblSelling.LocationFloat = New DevExpress.Utils.PointFloat(954.9999!, 0.0!)
        Me.lblSelling.Name = "lblSelling"
        Me.lblSelling.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblSelling.SizeF = New System.Drawing.SizeF(70.0!, 35.0!)
        Me.lblSelling.StylePriority.UseBackColor = False
        Me.lblSelling.StylePriority.UseBorderColor = False
        Me.lblSelling.StylePriority.UseBorders = False
        Me.lblSelling.StylePriority.UseBorderWidth = False
        Me.lblSelling.StylePriority.UseFont = False
        Me.lblSelling.StylePriority.UseForeColor = False
        Me.lblSelling.StylePriority.UseTextAlignment = False
        Me.lblSelling.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblSelling.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblNature
        '
        Me.lblNature.BackColor = System.Drawing.Color.White
        Me.lblNature.BorderColor = System.Drawing.Color.Black
        Me.lblNature.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblNature.BorderWidth = 1.0!
        Me.lblNature.CanGrow = False
        Me.lblNature.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNature.ForeColor = System.Drawing.Color.Black
        Me.lblNature.LocationFloat = New DevExpress.Utils.PointFloat(75.0!, 0.0!)
        Me.lblNature.Name = "lblNature"
        Me.lblNature.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNature.SizeF = New System.Drawing.SizeF(70.0!, 35.0!)
        Me.lblNature.StylePriority.UseBackColor = False
        Me.lblNature.StylePriority.UseBorderColor = False
        Me.lblNature.StylePriority.UseBorders = False
        Me.lblNature.StylePriority.UseBorderWidth = False
        Me.lblNature.StylePriority.UseFont = False
        Me.lblNature.StylePriority.UseForeColor = False
        Me.lblNature.StylePriority.UseTextAlignment = False
        Me.lblNature.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.Color.White
        Me.lblDate.BorderColor = System.Drawing.Color.Black
        Me.lblDate.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDate.BorderWidth = 1.0!
        Me.lblDate.CanGrow = False
        Me.lblDate.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.LocationFloat = New DevExpress.Utils.PointFloat(20.0!, 0.0!)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDate.SizeF = New System.Drawing.SizeF(55.0!, 35.0!)
        Me.lblDate.StylePriority.UseBackColor = False
        Me.lblDate.StylePriority.UseBorderColor = False
        Me.lblDate.StylePriority.UseBorders = False
        Me.lblDate.StylePriority.UseBorderWidth = False
        Me.lblDate.StylePriority.UseFont = False
        Me.lblDate.StylePriority.UseForeColor = False
        Me.lblDate.StylePriority.UseTextAlignment = False
        Me.lblDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblDate.XlsxFormatString = "mm/dd/yyyy"
        '
        'lblBookValue
        '
        Me.lblBookValue.BackColor = System.Drawing.Color.White
        Me.lblBookValue.BorderColor = System.Drawing.Color.Black
        Me.lblBookValue.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBookValue.BorderWidth = 1.0!
        Me.lblBookValue.CanGrow = False
        Me.lblBookValue.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBookValue.ForeColor = System.Drawing.Color.Black
        Me.lblBookValue.LocationFloat = New DevExpress.Utils.PointFloat(465.0!, 0.0!)
        Me.lblBookValue.Name = "lblBookValue"
        Me.lblBookValue.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBookValue.SizeF = New System.Drawing.SizeF(70.0!, 35.0!)
        Me.lblBookValue.StylePriority.UseBackColor = False
        Me.lblBookValue.StylePriority.UseBorderColor = False
        Me.lblBookValue.StylePriority.UseBorders = False
        Me.lblBookValue.StylePriority.UseBorderWidth = False
        Me.lblBookValue.StylePriority.UseFont = False
        Me.lblBookValue.StylePriority.UseForeColor = False
        Me.lblBookValue.StylePriority.UseTextAlignment = False
        Me.lblBookValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblBookValue.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblImpairment
        '
        Me.lblImpairment.BackColor = System.Drawing.Color.White
        Me.lblImpairment.BorderColor = System.Drawing.Color.Black
        Me.lblImpairment.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblImpairment.BorderWidth = 1.0!
        Me.lblImpairment.CanGrow = False
        Me.lblImpairment.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpairment.ForeColor = System.Drawing.Color.Black
        Me.lblImpairment.LocationFloat = New DevExpress.Utils.PointFloat(535.0!, 0.0!)
        Me.lblImpairment.Name = "lblImpairment"
        Me.lblImpairment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblImpairment.SizeF = New System.Drawing.SizeF(70.0!, 35.0!)
        Me.lblImpairment.StylePriority.UseBackColor = False
        Me.lblImpairment.StylePriority.UseBorderColor = False
        Me.lblImpairment.StylePriority.UseBorders = False
        Me.lblImpairment.StylePriority.UseBorderWidth = False
        Me.lblImpairment.StylePriority.UseFont = False
        Me.lblImpairment.StylePriority.UseForeColor = False
        Me.lblImpairment.StylePriority.UseTextAlignment = False
        Me.lblImpairment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblImpairment.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPlateNum
        '
        Me.lblPlateNum.BackColor = System.Drawing.Color.White
        Me.lblPlateNum.BorderColor = System.Drawing.Color.Black
        Me.lblPlateNum.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPlateNum.BorderWidth = 1.0!
        Me.lblPlateNum.CanGrow = False
        Me.lblPlateNum.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlateNum.ForeColor = System.Drawing.Color.Black
        Me.lblPlateNum.LocationFloat = New DevExpress.Utils.PointFloat(310.0!, 0.0!)
        Me.lblPlateNum.Name = "lblPlateNum"
        Me.lblPlateNum.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPlateNum.SizeF = New System.Drawing.SizeF(55.0!, 35.0!)
        Me.lblPlateNum.StylePriority.UseBackColor = False
        Me.lblPlateNum.StylePriority.UseBorderColor = False
        Me.lblPlateNum.StylePriority.UseBorders = False
        Me.lblPlateNum.StylePriority.UseBorderWidth = False
        Me.lblPlateNum.StylePriority.UseFont = False
        Me.lblPlateNum.StylePriority.UseForeColor = False
        Me.lblPlateNum.StylePriority.UseTextAlignment = False
        Me.lblPlateNum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAccountNo
        '
        Me.lblAccountNo.BackColor = System.Drawing.Color.White
        Me.lblAccountNo.BorderColor = System.Drawing.Color.Black
        Me.lblAccountNo.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccountNo.BorderWidth = 1.0!
        Me.lblAccountNo.CanGrow = False
        Me.lblAccountNo.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountNo.ForeColor = System.Drawing.Color.Black
        Me.lblAccountNo.LocationFloat = New DevExpress.Utils.PointFloat(245.0!, 0.0!)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountNo.SizeF = New System.Drawing.SizeF(65.0!, 35.0!)
        Me.lblAccountNo.StylePriority.UseBackColor = False
        Me.lblAccountNo.StylePriority.UseBorderColor = False
        Me.lblAccountNo.StylePriority.UseBorders = False
        Me.lblAccountNo.StylePriority.UseBorderWidth = False
        Me.lblAccountNo.StylePriority.UseFont = False
        Me.lblAccountNo.StylePriority.UseForeColor = False
        Me.lblAccountNo.StylePriority.UseTextAlignment = False
        Me.lblAccountNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblDescription
        '
        Me.lblDescription.BackColor = System.Drawing.Color.White
        Me.lblDescription.BorderColor = System.Drawing.Color.Black
        Me.lblDescription.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDescription.BorderWidth = 1.0!
        Me.lblDescription.CanGrow = False
        Me.lblDescription.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.Color.Black
        Me.lblDescription.LocationFloat = New DevExpress.Utils.PointFloat(365.0!, 0.0!)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDescription.SizeF = New System.Drawing.SizeF(100.0!, 35.0!)
        Me.lblDescription.StylePriority.UseBackColor = False
        Me.lblDescription.StylePriority.UseBorderColor = False
        Me.lblDescription.StylePriority.UseBorders = False
        Me.lblDescription.StylePriority.UseBorderWidth = False
        Me.lblDescription.StylePriority.UseFont = False
        Me.lblDescription.StylePriority.UseForeColor = False
        Me.lblDescription.StylePriority.UseTextAlignment = False
        Me.lblDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblNo
        '
        Me.lblNo.BackColor = System.Drawing.Color.White
        Me.lblNo.BorderColor = System.Drawing.Color.Black
        Me.lblNo.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblNo.BorderWidth = 1.0!
        Me.lblNo.CanGrow = False
        Me.lblNo.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNo.ForeColor = System.Drawing.Color.Black
        Me.lblNo.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblNo.Name = "lblNo"
        Me.lblNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNo.SizeF = New System.Drawing.SizeF(20.0!, 35.0!)
        Me.lblNo.StylePriority.UseBackColor = False
        Me.lblNo.StylePriority.UseBorderColor = False
        Me.lblNo.StylePriority.UseBorders = False
        Me.lblNo.StylePriority.UseBorderWidth = False
        Me.lblNo.StylePriority.UseFont = False
        Me.lblNo.StylePriority.UseForeColor = False
        Me.lblNo.StylePriority.UseTextAlignment = False
        Me.lblNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAccountName
        '
        Me.lblAccountName.BackColor = System.Drawing.Color.White
        Me.lblAccountName.BorderColor = System.Drawing.Color.Black
        Me.lblAccountName.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccountName.BorderWidth = 1.0!
        Me.lblAccountName.CanGrow = False
        Me.lblAccountName.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountName.ForeColor = System.Drawing.Color.Black
        Me.lblAccountName.LocationFloat = New DevExpress.Utils.PointFloat(145.0!, 0.0!)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountName.SizeF = New System.Drawing.SizeF(100.0!, 35.0!)
        Me.lblAccountName.StylePriority.UseBackColor = False
        Me.lblAccountName.StylePriority.UseBorderColor = False
        Me.lblAccountName.StylePriority.UseBorders = False
        Me.lblAccountName.StylePriority.UseBorderWidth = False
        Me.lblAccountName.StylePriority.UseFont = False
        Me.lblAccountName.StylePriority.UseForeColor = False
        Me.lblAccountName.StylePriority.UseTextAlignment = False
        Me.lblAccountName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
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
        'rptSubSchedule_VL
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.PageHeight = 850
        Me.PageWidth = 1300
        Me.PaperKind = System.Drawing.Printing.PaperKind.GermanLegalFanfold
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents lblNature As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBookValue As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblImpairment As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPlateNum As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDescription As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInspection As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblObservation As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNetBook As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblSelling As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblOver3Years As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lbl1Year_3Years As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lbl90Days_1Year As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lbl1_90Days As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblClassification As DevExpress.XtraReports.UI.XRLabel
End Class
