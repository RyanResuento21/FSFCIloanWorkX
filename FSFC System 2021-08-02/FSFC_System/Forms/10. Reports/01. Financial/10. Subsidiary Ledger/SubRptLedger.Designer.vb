<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class SubRptLedger
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
        Me.lblAR_B = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPenalties_B = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRPPD_B = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInterest_B = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrincipal_B = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrincipal_P = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInterest_P = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRPPD_P = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPenalties_P = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAR_P = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblOR = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmountPaid = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRemarks = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotal_B = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPenalties_W = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRPPD_F = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.BorderColor = System.Drawing.Color.Black
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblAR_B, Me.lblPenalties_B, Me.lblRPPD_B, Me.lblInterest_B, Me.lblPrincipal_B, Me.lblPrincipal_P, Me.lblInterest_P, Me.lblRPPD_P, Me.lblPenalties_P, Me.lblAR_P, Me.lblOR, Me.lblAmountPaid, Me.lblDate, Me.lblRemarks, Me.lblTotal_B, Me.lblPenalties_W, Me.lblRPPD_F})
        Me.Detail.HeightF = 15.00002!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.StylePriority.UseBorderColor = False
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblAR_B
        '
        Me.lblAR_B.BackColor = System.Drawing.Color.White
        Me.lblAR_B.BorderColor = System.Drawing.Color.Black
        Me.lblAR_B.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAR_B.CanGrow = False
        Me.lblAR_B.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAR_B.ForeColor = System.Drawing.Color.Black
        Me.lblAR_B.LocationFloat = New DevExpress.Utils.PointFloat(685.0!, 0.0!)
        Me.lblAR_B.Name = "lblAR_B"
        Me.lblAR_B.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAR_B.SizeF = New System.Drawing.SizeF(55.0!, 15.0!)
        Me.lblAR_B.StylePriority.UseBackColor = False
        Me.lblAR_B.StylePriority.UseBorderColor = False
        Me.lblAR_B.StylePriority.UseBorders = False
        Me.lblAR_B.StylePriority.UseFont = False
        Me.lblAR_B.StylePriority.UseForeColor = False
        Me.lblAR_B.StylePriority.UseTextAlignment = False
        Me.lblAR_B.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAR_B.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPenalties_B
        '
        Me.lblPenalties_B.BackColor = System.Drawing.Color.White
        Me.lblPenalties_B.BorderColor = System.Drawing.Color.Black
        Me.lblPenalties_B.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPenalties_B.CanGrow = False
        Me.lblPenalties_B.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPenalties_B.ForeColor = System.Drawing.Color.Black
        Me.lblPenalties_B.LocationFloat = New DevExpress.Utils.PointFloat(740.0!, 0.0!)
        Me.lblPenalties_B.Name = "lblPenalties_B"
        Me.lblPenalties_B.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPenalties_B.SizeF = New System.Drawing.SizeF(60.0!, 15.0!)
        Me.lblPenalties_B.StylePriority.UseBackColor = False
        Me.lblPenalties_B.StylePriority.UseBorderColor = False
        Me.lblPenalties_B.StylePriority.UseBorders = False
        Me.lblPenalties_B.StylePriority.UseFont = False
        Me.lblPenalties_B.StylePriority.UseForeColor = False
        Me.lblPenalties_B.StylePriority.UseTextAlignment = False
        Me.lblPenalties_B.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPenalties_B.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblRPPD_B
        '
        Me.lblRPPD_B.BackColor = System.Drawing.Color.White
        Me.lblRPPD_B.BorderColor = System.Drawing.Color.Black
        Me.lblRPPD_B.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblRPPD_B.CanGrow = False
        Me.lblRPPD_B.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRPPD_B.ForeColor = System.Drawing.Color.Black
        Me.lblRPPD_B.LocationFloat = New DevExpress.Utils.PointFloat(800.0!, 0.0!)
        Me.lblRPPD_B.Name = "lblRPPD_B"
        Me.lblRPPD_B.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRPPD_B.SizeF = New System.Drawing.SizeF(55.0!, 15.0!)
        Me.lblRPPD_B.StylePriority.UseBackColor = False
        Me.lblRPPD_B.StylePriority.UseBorderColor = False
        Me.lblRPPD_B.StylePriority.UseBorders = False
        Me.lblRPPD_B.StylePriority.UseFont = False
        Me.lblRPPD_B.StylePriority.UseForeColor = False
        Me.lblRPPD_B.StylePriority.UseTextAlignment = False
        Me.lblRPPD_B.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblRPPD_B.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblInterest_B
        '
        Me.lblInterest_B.BackColor = System.Drawing.Color.White
        Me.lblInterest_B.BorderColor = System.Drawing.Color.Black
        Me.lblInterest_B.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblInterest_B.CanGrow = False
        Me.lblInterest_B.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterest_B.ForeColor = System.Drawing.Color.Black
        Me.lblInterest_B.LocationFloat = New DevExpress.Utils.PointFloat(855.0!, 0.0!)
        Me.lblInterest_B.Name = "lblInterest_B"
        Me.lblInterest_B.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInterest_B.SizeF = New System.Drawing.SizeF(65.0!, 15.0!)
        Me.lblInterest_B.StylePriority.UseBackColor = False
        Me.lblInterest_B.StylePriority.UseBorderColor = False
        Me.lblInterest_B.StylePriority.UseBorders = False
        Me.lblInterest_B.StylePriority.UseFont = False
        Me.lblInterest_B.StylePriority.UseForeColor = False
        Me.lblInterest_B.StylePriority.UseTextAlignment = False
        Me.lblInterest_B.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblInterest_B.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPrincipal_B
        '
        Me.lblPrincipal_B.BackColor = System.Drawing.Color.White
        Me.lblPrincipal_B.BorderColor = System.Drawing.Color.Black
        Me.lblPrincipal_B.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPrincipal_B.CanGrow = False
        Me.lblPrincipal_B.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipal_B.ForeColor = System.Drawing.Color.Black
        Me.lblPrincipal_B.LocationFloat = New DevExpress.Utils.PointFloat(920.0!, 0.0!)
        Me.lblPrincipal_B.Name = "lblPrincipal_B"
        Me.lblPrincipal_B.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrincipal_B.SizeF = New System.Drawing.SizeF(65.0!, 15.0!)
        Me.lblPrincipal_B.StylePriority.UseBackColor = False
        Me.lblPrincipal_B.StylePriority.UseBorderColor = False
        Me.lblPrincipal_B.StylePriority.UseBorders = False
        Me.lblPrincipal_B.StylePriority.UseFont = False
        Me.lblPrincipal_B.StylePriority.UseForeColor = False
        Me.lblPrincipal_B.StylePriority.UseTextAlignment = False
        Me.lblPrincipal_B.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPrincipal_B.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPrincipal_P
        '
        Me.lblPrincipal_P.BackColor = System.Drawing.Color.White
        Me.lblPrincipal_P.BorderColor = System.Drawing.Color.Black
        Me.lblPrincipal_P.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPrincipal_P.CanGrow = False
        Me.lblPrincipal_P.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipal_P.ForeColor = System.Drawing.Color.Black
        Me.lblPrincipal_P.LocationFloat = New DevExpress.Utils.PointFloat(620.0!, 0.0!)
        Me.lblPrincipal_P.Name = "lblPrincipal_P"
        Me.lblPrincipal_P.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrincipal_P.SizeF = New System.Drawing.SizeF(65.0!, 15.0!)
        Me.lblPrincipal_P.StylePriority.UseBackColor = False
        Me.lblPrincipal_P.StylePriority.UseBorderColor = False
        Me.lblPrincipal_P.StylePriority.UseBorders = False
        Me.lblPrincipal_P.StylePriority.UseFont = False
        Me.lblPrincipal_P.StylePriority.UseForeColor = False
        Me.lblPrincipal_P.StylePriority.UseTextAlignment = False
        Me.lblPrincipal_P.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPrincipal_P.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblInterest_P
        '
        Me.lblInterest_P.BackColor = System.Drawing.Color.White
        Me.lblInterest_P.BorderColor = System.Drawing.Color.Black
        Me.lblInterest_P.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblInterest_P.CanGrow = False
        Me.lblInterest_P.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterest_P.ForeColor = System.Drawing.Color.Black
        Me.lblInterest_P.LocationFloat = New DevExpress.Utils.PointFloat(560.0!, 0.0!)
        Me.lblInterest_P.Name = "lblInterest_P"
        Me.lblInterest_P.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInterest_P.SizeF = New System.Drawing.SizeF(60.0!, 15.0!)
        Me.lblInterest_P.StylePriority.UseBackColor = False
        Me.lblInterest_P.StylePriority.UseBorderColor = False
        Me.lblInterest_P.StylePriority.UseBorders = False
        Me.lblInterest_P.StylePriority.UseFont = False
        Me.lblInterest_P.StylePriority.UseForeColor = False
        Me.lblInterest_P.StylePriority.UseTextAlignment = False
        Me.lblInterest_P.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblInterest_P.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblRPPD_P
        '
        Me.lblRPPD_P.BackColor = System.Drawing.Color.White
        Me.lblRPPD_P.BorderColor = System.Drawing.Color.Black
        Me.lblRPPD_P.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblRPPD_P.CanGrow = False
        Me.lblRPPD_P.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRPPD_P.ForeColor = System.Drawing.Color.Black
        Me.lblRPPD_P.LocationFloat = New DevExpress.Utils.PointFloat(450.0!, 0.00001525879!)
        Me.lblRPPD_P.Name = "lblRPPD_P"
        Me.lblRPPD_P.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRPPD_P.SizeF = New System.Drawing.SizeF(55.0!, 15.0!)
        Me.lblRPPD_P.StylePriority.UseBackColor = False
        Me.lblRPPD_P.StylePriority.UseBorderColor = False
        Me.lblRPPD_P.StylePriority.UseBorders = False
        Me.lblRPPD_P.StylePriority.UseFont = False
        Me.lblRPPD_P.StylePriority.UseForeColor = False
        Me.lblRPPD_P.StylePriority.UseTextAlignment = False
        Me.lblRPPD_P.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblRPPD_P.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPenalties_P
        '
        Me.lblPenalties_P.BackColor = System.Drawing.Color.White
        Me.lblPenalties_P.BorderColor = System.Drawing.Color.Black
        Me.lblPenalties_P.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPenalties_P.CanGrow = False
        Me.lblPenalties_P.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPenalties_P.ForeColor = System.Drawing.Color.Black
        Me.lblPenalties_P.LocationFloat = New DevExpress.Utils.PointFloat(330.0!, 0.00001525879!)
        Me.lblPenalties_P.Name = "lblPenalties_P"
        Me.lblPenalties_P.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPenalties_P.SizeF = New System.Drawing.SizeF(60.0!, 15.0!)
        Me.lblPenalties_P.StylePriority.UseBackColor = False
        Me.lblPenalties_P.StylePriority.UseBorderColor = False
        Me.lblPenalties_P.StylePriority.UseBorders = False
        Me.lblPenalties_P.StylePriority.UseFont = False
        Me.lblPenalties_P.StylePriority.UseForeColor = False
        Me.lblPenalties_P.StylePriority.UseTextAlignment = False
        Me.lblPenalties_P.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPenalties_P.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblAR_P
        '
        Me.lblAR_P.BackColor = System.Drawing.Color.White
        Me.lblAR_P.BorderColor = System.Drawing.Color.Black
        Me.lblAR_P.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAR_P.CanGrow = False
        Me.lblAR_P.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAR_P.ForeColor = System.Drawing.Color.Black
        Me.lblAR_P.LocationFloat = New DevExpress.Utils.PointFloat(275.0!, 0.00001525879!)
        Me.lblAR_P.Name = "lblAR_P"
        Me.lblAR_P.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAR_P.SizeF = New System.Drawing.SizeF(55.0!, 15.0!)
        Me.lblAR_P.StylePriority.UseBackColor = False
        Me.lblAR_P.StylePriority.UseBorderColor = False
        Me.lblAR_P.StylePriority.UseBorders = False
        Me.lblAR_P.StylePriority.UseFont = False
        Me.lblAR_P.StylePriority.UseForeColor = False
        Me.lblAR_P.StylePriority.UseTextAlignment = False
        Me.lblAR_P.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAR_P.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblOR
        '
        Me.lblOR.BackColor = System.Drawing.Color.White
        Me.lblOR.BorderColor = System.Drawing.Color.Black
        Me.lblOR.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblOR.CanGrow = False
        Me.lblOR.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOR.ForeColor = System.Drawing.Color.Black
        Me.lblOR.LocationFloat = New DevExpress.Utils.PointFloat(155.0!, 0.0!)
        Me.lblOR.Name = "lblOR"
        Me.lblOR.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblOR.SizeF = New System.Drawing.SizeF(60.0!, 15.0!)
        Me.lblOR.StylePriority.UseBackColor = False
        Me.lblOR.StylePriority.UseBorderColor = False
        Me.lblOR.StylePriority.UseBorders = False
        Me.lblOR.StylePriority.UseFont = False
        Me.lblOR.StylePriority.UseForeColor = False
        Me.lblOR.StylePriority.UseTextAlignment = False
        Me.lblOR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAmountPaid
        '
        Me.lblAmountPaid.BackColor = System.Drawing.Color.White
        Me.lblAmountPaid.BorderColor = System.Drawing.Color.Black
        Me.lblAmountPaid.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmountPaid.CanGrow = False
        Me.lblAmountPaid.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmountPaid.ForeColor = System.Drawing.Color.Black
        Me.lblAmountPaid.LocationFloat = New DevExpress.Utils.PointFloat(215.0!, 0.0!)
        Me.lblAmountPaid.Name = "lblAmountPaid"
        Me.lblAmountPaid.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmountPaid.SizeF = New System.Drawing.SizeF(60.0!, 15.0!)
        Me.lblAmountPaid.StylePriority.UseBackColor = False
        Me.lblAmountPaid.StylePriority.UseBorderColor = False
        Me.lblAmountPaid.StylePriority.UseBorders = False
        Me.lblAmountPaid.StylePriority.UseFont = False
        Me.lblAmountPaid.StylePriority.UseForeColor = False
        Me.lblAmountPaid.StylePriority.UseTextAlignment = False
        Me.lblAmountPaid.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmountPaid.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.Color.White
        Me.lblDate.BorderColor = System.Drawing.Color.Black
        Me.lblDate.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDate.CanGrow = False
        Me.lblDate.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.00001525879!)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDate.SizeF = New System.Drawing.SizeF(55.0!, 15.0!)
        Me.lblDate.StylePriority.UseBackColor = False
        Me.lblDate.StylePriority.UseBorderColor = False
        Me.lblDate.StylePriority.UseBorders = False
        Me.lblDate.StylePriority.UseFont = False
        Me.lblDate.StylePriority.UseForeColor = False
        Me.lblDate.StylePriority.UseTextAlignment = False
        Me.lblDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblDate.XlsxFormatString = "mm/dd/yyyy"
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.Color.White
        Me.lblRemarks.BorderColor = System.Drawing.Color.Black
        Me.lblRemarks.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblRemarks.CanGrow = False
        Me.lblRemarks.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.LocationFloat = New DevExpress.Utils.PointFloat(55.0!, 0.00001525879!)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRemarks.SizeF = New System.Drawing.SizeF(100.0!, 15.0!)
        Me.lblRemarks.StylePriority.UseBackColor = False
        Me.lblRemarks.StylePriority.UseBorderColor = False
        Me.lblRemarks.StylePriority.UseBorders = False
        Me.lblRemarks.StylePriority.UseFont = False
        Me.lblRemarks.StylePriority.UseForeColor = False
        Me.lblRemarks.StylePriority.UseTextAlignment = False
        Me.lblRemarks.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblTotal_B
        '
        Me.lblTotal_B.BackColor = System.Drawing.Color.White
        Me.lblTotal_B.BorderColor = System.Drawing.Color.Black
        Me.lblTotal_B.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotal_B.CanGrow = False
        Me.lblTotal_B.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal_B.ForeColor = System.Drawing.Color.Black
        Me.lblTotal_B.LocationFloat = New DevExpress.Utils.PointFloat(985.0!, 0.0!)
        Me.lblTotal_B.Name = "lblTotal_B"
        Me.lblTotal_B.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotal_B.SizeF = New System.Drawing.SizeF(65.0!, 15.0!)
        Me.lblTotal_B.StylePriority.UseBackColor = False
        Me.lblTotal_B.StylePriority.UseBorderColor = False
        Me.lblTotal_B.StylePriority.UseBorders = False
        Me.lblTotal_B.StylePriority.UseFont = False
        Me.lblTotal_B.StylePriority.UseForeColor = False
        Me.lblTotal_B.StylePriority.UseTextAlignment = False
        Me.lblTotal_B.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblTotal_B.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPenalties_W
        '
        Me.lblPenalties_W.BackColor = System.Drawing.Color.White
        Me.lblPenalties_W.BorderColor = System.Drawing.Color.Black
        Me.lblPenalties_W.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPenalties_W.CanGrow = False
        Me.lblPenalties_W.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPenalties_W.ForeColor = System.Drawing.Color.Black
        Me.lblPenalties_W.LocationFloat = New DevExpress.Utils.PointFloat(390.0!, 0.00001589457!)
        Me.lblPenalties_W.Name = "lblPenalties_W"
        Me.lblPenalties_W.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPenalties_W.SizeF = New System.Drawing.SizeF(60.0!, 15.0!)
        Me.lblPenalties_W.StylePriority.UseBackColor = False
        Me.lblPenalties_W.StylePriority.UseBorderColor = False
        Me.lblPenalties_W.StylePriority.UseBorders = False
        Me.lblPenalties_W.StylePriority.UseFont = False
        Me.lblPenalties_W.StylePriority.UseForeColor = False
        Me.lblPenalties_W.StylePriority.UseTextAlignment = False
        Me.lblPenalties_W.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPenalties_W.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblRPPD_F
        '
        Me.lblRPPD_F.BackColor = System.Drawing.Color.White
        Me.lblRPPD_F.BorderColor = System.Drawing.Color.Black
        Me.lblRPPD_F.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblRPPD_F.CanGrow = False
        Me.lblRPPD_F.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRPPD_F.ForeColor = System.Drawing.Color.Black
        Me.lblRPPD_F.LocationFloat = New DevExpress.Utils.PointFloat(505.0!, 0.0!)
        Me.lblRPPD_F.Name = "lblRPPD_F"
        Me.lblRPPD_F.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRPPD_F.SizeF = New System.Drawing.SizeF(55.0!, 15.0!)
        Me.lblRPPD_F.StylePriority.UseBackColor = False
        Me.lblRPPD_F.StylePriority.UseBorderColor = False
        Me.lblRPPD_F.StylePriority.UseBorders = False
        Me.lblRPPD_F.StylePriority.UseFont = False
        Me.lblRPPD_F.StylePriority.UseForeColor = False
        Me.lblRPPD_F.StylePriority.UseTextAlignment = False
        Me.lblRPPD_F.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblRPPD_F.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'TopMargin
        '
        Me.TopMargin.BorderColor = System.Drawing.Color.Black
        Me.TopMargin.HeightF = 25.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.StylePriority.UseBorderColor = False
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.BorderColor = System.Drawing.Color.Black
        Me.BottomMargin.HeightF = 25.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.StylePriority.UseBorderColor = False
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'subRpt_Ledger
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.PageHeight = 850
        Me.PageWidth = 1100
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents lblAR_B As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPenalties_B As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRPPD_B As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInterest_B As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrincipal_B As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrincipal_P As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInterest_P As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRPPD_P As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPenalties_P As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAR_P As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblOR As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmountPaid As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRemarks As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotal_B As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPenalties_W As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRPPD_F As DevExpress.XtraReports.UI.XRLabel
End Class
