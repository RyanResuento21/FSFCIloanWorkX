<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class RptPDCReceipt
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
        Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.lblCheckD = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRemarksC = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCheckN = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBank = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBranch = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblContactN = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBorrower = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblReceivedFrom = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotal = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblConfirmed = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBorrower2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBorrowerType = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblConfirmedD = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel30 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblReceivedBy = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAuthorized = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblReceivedD = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrLabel111 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblCheckD, Me.lblAmount, Me.lblRemarksC, Me.lblCheckN, Me.lblNo, Me.lblBank, Me.lblBranch})
        Me.Detail.HeightF = 20.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblCheckD
        '
        Me.lblCheckD.BackColor = System.Drawing.Color.White
        Me.lblCheckD.BorderColor = System.Drawing.Color.Black
        Me.lblCheckD.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCheckD.BorderWidth = 1.0!
        Me.lblCheckD.CanGrow = False
        Me.lblCheckD.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckD.ForeColor = System.Drawing.Color.Black
        Me.lblCheckD.LocationFloat = New DevExpress.Utils.PointFloat(424.9999!, 0.0!)
        Me.lblCheckD.Name = "lblCheckD"
        Me.lblCheckD.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCheckD.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.lblCheckD.StylePriority.UseBackColor = False
        Me.lblCheckD.StylePriority.UseBorderColor = False
        Me.lblCheckD.StylePriority.UseBorders = False
        Me.lblCheckD.StylePriority.UseBorderWidth = False
        Me.lblCheckD.StylePriority.UseFont = False
        Me.lblCheckD.StylePriority.UseForeColor = False
        Me.lblCheckD.StylePriority.UseTextAlignment = False
        Me.lblCheckD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblCheckD.XlsxFormatString = "mm/dd/yyyy"
        '
        'lblAmount
        '
        Me.lblAmount.BackColor = System.Drawing.Color.White
        Me.lblAmount.BorderColor = System.Drawing.Color.Black
        Me.lblAmount.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmount.BorderWidth = 1.0!
        Me.lblAmount.CanGrow = False
        Me.lblAmount.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.ForeColor = System.Drawing.Color.Black
        Me.lblAmount.LocationFloat = New DevExpress.Utils.PointFloat(499.9999!, 0.0!)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblAmount.StylePriority.UseBackColor = False
        Me.lblAmount.StylePriority.UseBorderColor = False
        Me.lblAmount.StylePriority.UseBorders = False
        Me.lblAmount.StylePriority.UseBorderWidth = False
        Me.lblAmount.StylePriority.UseFont = False
        Me.lblAmount.StylePriority.UseForeColor = False
        Me.lblAmount.StylePriority.UseTextAlignment = False
        Me.lblAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmount.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblRemarksC
        '
        Me.lblRemarksC.BackColor = System.Drawing.Color.White
        Me.lblRemarksC.BorderColor = System.Drawing.Color.Black
        Me.lblRemarksC.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblRemarksC.BorderWidth = 1.0!
        Me.lblRemarksC.CanGrow = False
        Me.lblRemarksC.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarksC.ForeColor = System.Drawing.Color.Black
        Me.lblRemarksC.LocationFloat = New DevExpress.Utils.PointFloat(599.9999!, 0.0!)
        Me.lblRemarksC.Name = "lblRemarksC"
        Me.lblRemarksC.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRemarksC.SizeF = New System.Drawing.SizeF(200.0!, 20.0!)
        Me.lblRemarksC.StylePriority.UseBackColor = False
        Me.lblRemarksC.StylePriority.UseBorderColor = False
        Me.lblRemarksC.StylePriority.UseBorders = False
        Me.lblRemarksC.StylePriority.UseBorderWidth = False
        Me.lblRemarksC.StylePriority.UseFont = False
        Me.lblRemarksC.StylePriority.UseForeColor = False
        Me.lblRemarksC.StylePriority.UseTextAlignment = False
        Me.lblRemarksC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblCheckN
        '
        Me.lblCheckN.BackColor = System.Drawing.Color.White
        Me.lblCheckN.BorderColor = System.Drawing.Color.Black
        Me.lblCheckN.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCheckN.BorderWidth = 1.0!
        Me.lblCheckN.CanGrow = False
        Me.lblCheckN.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckN.ForeColor = System.Drawing.Color.Black
        Me.lblCheckN.LocationFloat = New DevExpress.Utils.PointFloat(335.0!, 0.0!)
        Me.lblCheckN.Name = "lblCheckN"
        Me.lblCheckN.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCheckN.SizeF = New System.Drawing.SizeF(90.0!, 20.0!)
        Me.lblCheckN.StylePriority.UseBackColor = False
        Me.lblCheckN.StylePriority.UseBorderColor = False
        Me.lblCheckN.StylePriority.UseBorders = False
        Me.lblCheckN.StylePriority.UseBorderWidth = False
        Me.lblCheckN.StylePriority.UseFont = False
        Me.lblCheckN.StylePriority.UseForeColor = False
        Me.lblCheckN.StylePriority.UseTextAlignment = False
        Me.lblCheckN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblNo
        '
        Me.lblNo.BackColor = System.Drawing.Color.White
        Me.lblNo.BorderColor = System.Drawing.Color.Black
        Me.lblNo.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblNo.BorderWidth = 1.0!
        Me.lblNo.CanGrow = False
        Me.lblNo.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNo.ForeColor = System.Drawing.Color.Black
        Me.lblNo.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblNo.Name = "lblNo"
        Me.lblNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNo.SizeF = New System.Drawing.SizeF(20.0!, 20.0!)
        Me.lblNo.StylePriority.UseBackColor = False
        Me.lblNo.StylePriority.UseBorderColor = False
        Me.lblNo.StylePriority.UseBorders = False
        Me.lblNo.StylePriority.UseBorderWidth = False
        Me.lblNo.StylePriority.UseFont = False
        Me.lblNo.StylePriority.UseForeColor = False
        Me.lblNo.StylePriority.UseTextAlignment = False
        XrSummary1.FormatString = "{0:n}"
        XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Count
        Me.lblNo.Summary = XrSummary1
        Me.lblNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblBank
        '
        Me.lblBank.BackColor = System.Drawing.Color.White
        Me.lblBank.BorderColor = System.Drawing.Color.Black
        Me.lblBank.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBank.BorderWidth = 1.0!
        Me.lblBank.CanGrow = False
        Me.lblBank.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBank.ForeColor = System.Drawing.Color.Black
        Me.lblBank.LocationFloat = New DevExpress.Utils.PointFloat(20.0!, 0.0!)
        Me.lblBank.Name = "lblBank"
        Me.lblBank.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBank.SizeF = New System.Drawing.SizeF(125.0!, 20.0!)
        Me.lblBank.StylePriority.UseBackColor = False
        Me.lblBank.StylePriority.UseBorderColor = False
        Me.lblBank.StylePriority.UseBorders = False
        Me.lblBank.StylePriority.UseBorderWidth = False
        Me.lblBank.StylePriority.UseFont = False
        Me.lblBank.StylePriority.UseForeColor = False
        Me.lblBank.StylePriority.UseTextAlignment = False
        Me.lblBank.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblBranch
        '
        Me.lblBranch.BackColor = System.Drawing.Color.White
        Me.lblBranch.BorderColor = System.Drawing.Color.Black
        Me.lblBranch.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBranch.BorderWidth = 1.0!
        Me.lblBranch.CanGrow = False
        Me.lblBranch.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranch.ForeColor = System.Drawing.Color.Black
        Me.lblBranch.LocationFloat = New DevExpress.Utils.PointFloat(145.0!, 0.0!)
        Me.lblBranch.Name = "lblBranch"
        Me.lblBranch.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBranch.SizeF = New System.Drawing.SizeF(190.0!, 20.0!)
        Me.lblBranch.StylePriority.UseBackColor = False
        Me.lblBranch.StylePriority.UseBorderColor = False
        Me.lblBranch.StylePriority.UseBorders = False
        Me.lblBranch.StylePriority.UseBorderWidth = False
        Me.lblBranch.StylePriority.UseFont = False
        Me.lblBranch.StylePriority.UseForeColor = False
        Me.lblBranch.StylePriority.UseTextAlignment = False
        Me.lblBranch.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
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
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel14, Me.XrLabel13, Me.XrLabel12, Me.XrLabel11, Me.XrLabel10, Me.XrLabel9, Me.XrLabel8, Me.lblContactN, Me.XrLabel6, Me.lblBorrower, Me.lblReceivedFrom, Me.lblTitle})
        Me.ReportHeader.HeightF = 110.0!
        Me.ReportHeader.Name = "ReportHeader"
        Me.ReportHeader.StylePriority.UseTextAlignment = False
        Me.ReportHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify
        '
        'XrLabel14
        '
        Me.XrLabel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel14.BorderColor = System.Drawing.Color.Black
        Me.XrLabel14.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel14.BorderWidth = 1.0!
        Me.XrLabel14.CanGrow = False
        Me.XrLabel14.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel14.ForeColor = System.Drawing.Color.White
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(599.9999!, 80.0!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(200.0!, 30.0!)
        Me.XrLabel14.StylePriority.UseBackColor = False
        Me.XrLabel14.StylePriority.UseBorderColor = False
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.StylePriority.UseBorderWidth = False
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.StylePriority.UseForeColor = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = "Remarks"
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel13
        '
        Me.XrLabel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel13.BorderColor = System.Drawing.Color.Black
        Me.XrLabel13.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel13.BorderWidth = 1.0!
        Me.XrLabel13.CanGrow = False
        Me.XrLabel13.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel13.ForeColor = System.Drawing.Color.White
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(499.9999!, 80.0!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(100.0!, 30.0!)
        Me.XrLabel13.StylePriority.UseBackColor = False
        Me.XrLabel13.StylePriority.UseBorderColor = False
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.StylePriority.UseBorderWidth = False
        Me.XrLabel13.StylePriority.UseFont = False
        Me.XrLabel13.StylePriority.UseForeColor = False
        Me.XrLabel13.StylePriority.UseTextAlignment = False
        Me.XrLabel13.Text = "Amount"
        Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel12
        '
        Me.XrLabel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel12.BorderColor = System.Drawing.Color.Black
        Me.XrLabel12.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel12.BorderWidth = 1.0!
        Me.XrLabel12.CanGrow = False
        Me.XrLabel12.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel12.ForeColor = System.Drawing.Color.White
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(424.9999!, 80.0!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(75.0!, 30.0!)
        Me.XrLabel12.StylePriority.UseBackColor = False
        Me.XrLabel12.StylePriority.UseBorderColor = False
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseBorderWidth = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseForeColor = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = "Date"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel11
        '
        Me.XrLabel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel11.BorderColor = System.Drawing.Color.Black
        Me.XrLabel11.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel11.BorderWidth = 1.0!
        Me.XrLabel11.CanGrow = False
        Me.XrLabel11.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel11.ForeColor = System.Drawing.Color.White
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(335.0!, 80.0!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(90.0!, 30.0!)
        Me.XrLabel11.StylePriority.UseBackColor = False
        Me.XrLabel11.StylePriority.UseBorderColor = False
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.StylePriority.UseBorderWidth = False
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseForeColor = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = "Check No"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel10
        '
        Me.XrLabel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel10.BorderColor = System.Drawing.Color.Black
        Me.XrLabel10.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel10.BorderWidth = 1.0!
        Me.XrLabel10.CanGrow = False
        Me.XrLabel10.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel10.ForeColor = System.Drawing.Color.White
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(145.0!, 80.0!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(190.0!, 30.0!)
        Me.XrLabel10.StylePriority.UseBackColor = False
        Me.XrLabel10.StylePriority.UseBorderColor = False
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseBorderWidth = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseForeColor = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = "Branch"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel9
        '
        Me.XrLabel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel9.BorderColor = System.Drawing.Color.Black
        Me.XrLabel9.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel9.BorderWidth = 1.0!
        Me.XrLabel9.CanGrow = False
        Me.XrLabel9.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.ForeColor = System.Drawing.Color.White
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(20.0!, 80.0!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(125.0!, 30.0!)
        Me.XrLabel9.StylePriority.UseBackColor = False
        Me.XrLabel9.StylePriority.UseBorderColor = False
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.StylePriority.UseBorderWidth = False
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseForeColor = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = "Bank"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel8
        '
        Me.XrLabel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel8.BorderColor = System.Drawing.Color.Black
        Me.XrLabel8.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel8.BorderWidth = 1.0!
        Me.XrLabel8.CanGrow = False
        Me.XrLabel8.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.ForeColor = System.Drawing.Color.White
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 80.0!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(20.0!, 30.0!)
        Me.XrLabel8.StylePriority.UseBackColor = False
        Me.XrLabel8.StylePriority.UseBorderColor = False
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseBorderWidth = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseForeColor = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "No"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblContactN
        '
        Me.lblContactN.BackColor = System.Drawing.Color.White
        Me.lblContactN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblContactN.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblContactN.CanGrow = False
        Me.lblContactN.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblContactN.ForeColor = System.Drawing.Color.Black
        Me.lblContactN.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 55.0!)
        Me.lblContactN.Name = "lblContactN"
        Me.lblContactN.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblContactN.SizeF = New System.Drawing.SizeF(450.0!, 20.0!)
        Me.lblContactN.StylePriority.UseBackColor = False
        Me.lblContactN.StylePriority.UseBorderColor = False
        Me.lblContactN.StylePriority.UseBorders = False
        Me.lblContactN.StylePriority.UseFont = False
        Me.lblContactN.StylePriority.UseForeColor = False
        Me.lblContactN.StylePriority.UseTextAlignment = False
        Me.lblContactN.Text = "09273819436"
        Me.lblContactN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel6
        '
        Me.XrLabel6.BackColor = System.Drawing.Color.White
        Me.XrLabel6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel6.CanGrow = False
        Me.XrLabel6.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.ForeColor = System.Drawing.Color.Black
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 55.0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.XrLabel6.StylePriority.UseBackColor = False
        Me.XrLabel6.StylePriority.UseBorderColor = False
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseForeColor = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "Contact Num :"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblBorrower
        '
        Me.lblBorrower.BackColor = System.Drawing.Color.White
        Me.lblBorrower.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBorrower.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblBorrower.CanGrow = False
        Me.lblBorrower.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.lblBorrower.ForeColor = System.Drawing.Color.Black
        Me.lblBorrower.LocationFloat = New DevExpress.Utils.PointFloat(100.4399!, 35.0!)
        Me.lblBorrower.Name = "lblBorrower"
        Me.lblBorrower.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBorrower.SizeF = New System.Drawing.SizeF(450.0!, 20.0!)
        Me.lblBorrower.StylePriority.UseBackColor = False
        Me.lblBorrower.StylePriority.UseBorderColor = False
        Me.lblBorrower.StylePriority.UseBorders = False
        Me.lblBorrower.StylePriority.UseFont = False
        Me.lblBorrower.StylePriority.UseForeColor = False
        Me.lblBorrower.StylePriority.UseTextAlignment = False
        Me.lblBorrower.Text = "Mark Kevin M. Gotico"
        Me.lblBorrower.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblReceivedFrom
        '
        Me.lblReceivedFrom.BackColor = System.Drawing.Color.White
        Me.lblReceivedFrom.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblReceivedFrom.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblReceivedFrom.CanGrow = False
        Me.lblReceivedFrom.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceivedFrom.ForeColor = System.Drawing.Color.Black
        Me.lblReceivedFrom.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 35.0!)
        Me.lblReceivedFrom.Name = "lblReceivedFrom"
        Me.lblReceivedFrom.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblReceivedFrom.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblReceivedFrom.StylePriority.UseBackColor = False
        Me.lblReceivedFrom.StylePriority.UseBorderColor = False
        Me.lblReceivedFrom.StylePriority.UseBorders = False
        Me.lblReceivedFrom.StylePriority.UseFont = False
        Me.lblReceivedFrom.StylePriority.UseForeColor = False
        Me.lblReceivedFrom.StylePriority.UseTextAlignment = False
        Me.lblReceivedFrom.Text = "Received From :"
        Me.lblReceivedFrom.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.White
        Me.lblTitle.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTitle.LocationFloat = New DevExpress.Utils.PointFloat(250.0!, 0.0!)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTitle.SizeF = New System.Drawing.SizeF(300.0!, 30.0!)
        Me.lblTitle.StylePriority.UseBackColor = False
        Me.lblTitle.StylePriority.UseFont = False
        Me.lblTitle.StylePriority.UseForeColor = False
        Me.lblTitle.StylePriority.UseTextAlignment = False
        Me.lblTitle.Text = "POST DATED CHECK RECEIPT"
        Me.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel24
        '
        Me.XrLabel24.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel24.BorderColor = System.Drawing.Color.Black
        Me.XrLabel24.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel24.BorderWidth = 1.0!
        Me.XrLabel24.CanGrow = False
        Me.XrLabel24.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel24.ForeColor = System.Drawing.Color.White
        Me.XrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(0.00003532127!, 0.0!)
        Me.XrLabel24.Name = "XrLabel24"
        Me.XrLabel24.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel24.SizeF = New System.Drawing.SizeF(499.9998!, 20.0!)
        Me.XrLabel24.StylePriority.UseBackColor = False
        Me.XrLabel24.StylePriority.UseBorderColor = False
        Me.XrLabel24.StylePriority.UseBorders = False
        Me.XrLabel24.StylePriority.UseBorderWidth = False
        Me.XrLabel24.StylePriority.UseFont = False
        Me.XrLabel24.StylePriority.UseForeColor = False
        Me.XrLabel24.StylePriority.UseTextAlignment = False
        Me.XrLabel24.Text = "T O T A L"
        Me.XrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.BorderColor = System.Drawing.Color.Black
        Me.lblTotal.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotal.BorderWidth = 1.0!
        Me.lblTotal.CanGrow = False
        Me.lblTotal.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Black
        Me.lblTotal.LocationFloat = New DevExpress.Utils.PointFloat(499.9999!, 0.0!)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotal.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblTotal.StylePriority.UseBackColor = False
        Me.lblTotal.StylePriority.UseBorderColor = False
        Me.lblTotal.StylePriority.UseBorders = False
        Me.lblTotal.StylePriority.UseBorderWidth = False
        Me.lblTotal.StylePriority.UseFont = False
        Me.lblTotal.StylePriority.UseForeColor = False
        Me.lblTotal.StylePriority.UseTextAlignment = False
        XrSummary2.FormatString = "{0:n}"
        Me.lblTotal.Summary = XrSummary2
        Me.lblTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblTotal.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblConfirmed
        '
        Me.lblConfirmed.BackColor = System.Drawing.Color.White
        Me.lblConfirmed.BorderColor = System.Drawing.Color.Black
        Me.lblConfirmed.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblConfirmed.CanGrow = False
        Me.lblConfirmed.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmed.ForeColor = System.Drawing.Color.Black
        Me.lblConfirmed.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 50.0!)
        Me.lblConfirmed.Name = "lblConfirmed"
        Me.lblConfirmed.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblConfirmed.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblConfirmed.StylePriority.UseBackColor = False
        Me.lblConfirmed.StylePriority.UseBorderColor = False
        Me.lblConfirmed.StylePriority.UseBorders = False
        Me.lblConfirmed.StylePriority.UseFont = False
        Me.lblConfirmed.StylePriority.UseForeColor = False
        Me.lblConfirmed.StylePriority.UseTextAlignment = False
        Me.lblConfirmed.Text = "Confirmed By :"
        Me.lblConfirmed.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblBorrower2
        '
        Me.lblBorrower2.BackColor = System.Drawing.Color.White
        Me.lblBorrower2.BorderColor = System.Drawing.Color.Black
        Me.lblBorrower2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblBorrower2.CanGrow = False
        Me.lblBorrower2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrower2.ForeColor = System.Drawing.Color.Black
        Me.lblBorrower2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 100.0!)
        Me.lblBorrower2.Name = "lblBorrower2"
        Me.lblBorrower2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBorrower2.SizeF = New System.Drawing.SizeF(350.0!, 25.0!)
        Me.lblBorrower2.StylePriority.UseBackColor = False
        Me.lblBorrower2.StylePriority.UseBorderColor = False
        Me.lblBorrower2.StylePriority.UseBorders = False
        Me.lblBorrower2.StylePriority.UseFont = False
        Me.lblBorrower2.StylePriority.UseForeColor = False
        Me.lblBorrower2.StylePriority.UseTextAlignment = False
        Me.lblBorrower2.Text = "Mark Kevin M. Gotico"
        Me.lblBorrower2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblBorrowerType
        '
        Me.lblBorrowerType.BackColor = System.Drawing.Color.White
        Me.lblBorrowerType.BorderColor = System.Drawing.Color.Black
        Me.lblBorrowerType.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.lblBorrowerType.CanGrow = False
        Me.lblBorrowerType.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrowerType.ForeColor = System.Drawing.Color.Black
        Me.lblBorrowerType.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 125.0!)
        Me.lblBorrowerType.Name = "lblBorrowerType"
        Me.lblBorrowerType.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBorrowerType.SizeF = New System.Drawing.SizeF(350.0!, 25.0!)
        Me.lblBorrowerType.StylePriority.UseBackColor = False
        Me.lblBorrowerType.StylePriority.UseBorderColor = False
        Me.lblBorrowerType.StylePriority.UseBorders = False
        Me.lblBorrowerType.StylePriority.UseFont = False
        Me.lblBorrowerType.StylePriority.UseForeColor = False
        Me.lblBorrowerType.StylePriority.UseTextAlignment = False
        Me.lblBorrowerType.Text = "Borrower / Buyer"
        Me.lblBorrowerType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblConfirmedD
        '
        Me.lblConfirmedD.BackColor = System.Drawing.Color.White
        Me.lblConfirmedD.BorderColor = System.Drawing.Color.Black
        Me.lblConfirmedD.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblConfirmedD.CanGrow = False
        Me.lblConfirmedD.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmedD.ForeColor = System.Drawing.Color.Black
        Me.lblConfirmedD.LocationFloat = New DevExpress.Utils.PointFloat(0.00003532127!, 150.0!)
        Me.lblConfirmedD.Name = "lblConfirmedD"
        Me.lblConfirmedD.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblConfirmedD.SizeF = New System.Drawing.SizeF(350.0!, 20.0!)
        Me.lblConfirmedD.StylePriority.UseBackColor = False
        Me.lblConfirmedD.StylePriority.UseBorderColor = False
        Me.lblConfirmedD.StylePriority.UseBorders = False
        Me.lblConfirmedD.StylePriority.UseFont = False
        Me.lblConfirmedD.StylePriority.UseForeColor = False
        Me.lblConfirmedD.StylePriority.UseTextAlignment = False
        Me.lblConfirmedD.Text = "12.16.2016"
        Me.lblConfirmedD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblConfirmedD.XlsxFormatString = "mm/dd/yyyy"
        '
        'XrLabel30
        '
        Me.XrLabel30.BackColor = System.Drawing.Color.White
        Me.XrLabel30.BorderColor = System.Drawing.Color.Black
        Me.XrLabel30.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel30.CanGrow = False
        Me.XrLabel30.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel30.ForeColor = System.Drawing.Color.Black
        Me.XrLabel30.LocationFloat = New DevExpress.Utils.PointFloat(450.0!, 50.0!)
        Me.XrLabel30.Name = "XrLabel30"
        Me.XrLabel30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel30.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.XrLabel30.StylePriority.UseBackColor = False
        Me.XrLabel30.StylePriority.UseBorderColor = False
        Me.XrLabel30.StylePriority.UseBorders = False
        Me.XrLabel30.StylePriority.UseFont = False
        Me.XrLabel30.StylePriority.UseForeColor = False
        Me.XrLabel30.StylePriority.UseTextAlignment = False
        Me.XrLabel30.Text = "Received By :"
        Me.XrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblReceivedBy
        '
        Me.lblReceivedBy.BackColor = System.Drawing.Color.White
        Me.lblReceivedBy.BorderColor = System.Drawing.Color.Black
        Me.lblReceivedBy.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblReceivedBy.CanGrow = False
        Me.lblReceivedBy.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceivedBy.ForeColor = System.Drawing.Color.Black
        Me.lblReceivedBy.LocationFloat = New DevExpress.Utils.PointFloat(450.0!, 100.0!)
        Me.lblReceivedBy.Name = "lblReceivedBy"
        Me.lblReceivedBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblReceivedBy.SizeF = New System.Drawing.SizeF(350.0!, 25.0!)
        Me.lblReceivedBy.StylePriority.UseBackColor = False
        Me.lblReceivedBy.StylePriority.UseBorderColor = False
        Me.lblReceivedBy.StylePriority.UseBorders = False
        Me.lblReceivedBy.StylePriority.UseFont = False
        Me.lblReceivedBy.StylePriority.UseForeColor = False
        Me.lblReceivedBy.StylePriority.UseTextAlignment = False
        Me.lblReceivedBy.Text = "Mark Kevin M. Gotico"
        Me.lblReceivedBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAuthorized
        '
        Me.lblAuthorized.BackColor = System.Drawing.Color.White
        Me.lblAuthorized.BorderColor = System.Drawing.Color.Black
        Me.lblAuthorized.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.lblAuthorized.CanGrow = False
        Me.lblAuthorized.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuthorized.ForeColor = System.Drawing.Color.Black
        Me.lblAuthorized.LocationFloat = New DevExpress.Utils.PointFloat(450.0!, 125.0!)
        Me.lblAuthorized.Name = "lblAuthorized"
        Me.lblAuthorized.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAuthorized.SizeF = New System.Drawing.SizeF(350.0!, 25.0!)
        Me.lblAuthorized.StylePriority.UseBackColor = False
        Me.lblAuthorized.StylePriority.UseBorderColor = False
        Me.lblAuthorized.StylePriority.UseBorders = False
        Me.lblAuthorized.StylePriority.UseFont = False
        Me.lblAuthorized.StylePriority.UseForeColor = False
        Me.lblAuthorized.StylePriority.UseTextAlignment = False
        Me.lblAuthorized.Text = "Authorized Representative"
        Me.lblAuthorized.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblReceivedD
        '
        Me.lblReceivedD.BackColor = System.Drawing.Color.White
        Me.lblReceivedD.BorderColor = System.Drawing.Color.Black
        Me.lblReceivedD.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblReceivedD.CanGrow = False
        Me.lblReceivedD.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceivedD.ForeColor = System.Drawing.Color.Black
        Me.lblReceivedD.LocationFloat = New DevExpress.Utils.PointFloat(449.9999!, 150.0!)
        Me.lblReceivedD.Name = "lblReceivedD"
        Me.lblReceivedD.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblReceivedD.SizeF = New System.Drawing.SizeF(350.0!, 20.0!)
        Me.lblReceivedD.StylePriority.UseBackColor = False
        Me.lblReceivedD.StylePriority.UseBorderColor = False
        Me.lblReceivedD.StylePriority.UseBorders = False
        Me.lblReceivedD.StylePriority.UseFont = False
        Me.lblReceivedD.StylePriority.UseForeColor = False
        Me.lblReceivedD.StylePriority.UseTextAlignment = False
        Me.lblReceivedD.Text = "12.16.2016"
        Me.lblReceivedD.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblReceivedD.XlsxFormatString = "mm/dd/yyyy"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo2, Me.XrLabel111, Me.XrLabel24, Me.lblTotal, Me.lblConfirmed, Me.lblBorrower2, Me.lblBorrowerType, Me.lblConfirmedD, Me.lblReceivedBy, Me.XrLabel30, Me.lblReceivedD, Me.lblAuthorized})
        Me.ReportFooter.HeightF = 190.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.BackColor = System.Drawing.Color.White
        Me.XrPageInfo2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo2.Format = "{0:dddd, MMMM d, yyyy h:mm tt}"
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 170.0!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.XrPageInfo2.StylePriority.UseBackColor = False
        Me.XrPageInfo2.StylePriority.UseFont = False
        Me.XrPageInfo2.StylePriority.UseTextAlignment = False
        Me.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel111
        '
        Me.XrLabel111.BackColor = System.Drawing.Color.White
        Me.XrLabel111.BorderColor = System.Drawing.Color.Black
        Me.XrLabel111.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel111.BorderWidth = 1.0!
        Me.XrLabel111.CanGrow = False
        Me.XrLabel111.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel111.ForeColor = System.Drawing.Color.Black
        Me.XrLabel111.LocationFloat = New DevExpress.Utils.PointFloat(599.9999!, 0.0!)
        Me.XrLabel111.Name = "XrLabel111"
        Me.XrLabel111.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel111.SizeF = New System.Drawing.SizeF(200.0!, 20.0!)
        Me.XrLabel111.StylePriority.UseBackColor = False
        Me.XrLabel111.StylePriority.UseBorderColor = False
        Me.XrLabel111.StylePriority.UseBorders = False
        Me.XrLabel111.StylePriority.UseBorderWidth = False
        Me.XrLabel111.StylePriority.UseFont = False
        Me.XrLabel111.StylePriority.UseForeColor = False
        Me.XrLabel111.StylePriority.UseTextAlignment = False
        Me.XrLabel111.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'rptPDC_Receipt
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter})
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents lblTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblReceivedFrom As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblContactN As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBorrower As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCheckD As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRemarksC As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCheckN As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBank As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBranch As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAuthorized As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblReceivedD As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel30 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblReceivedBy As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblConfirmedD As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBorrowerType As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBorrower2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblConfirmed As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrLabel111 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
End Class
