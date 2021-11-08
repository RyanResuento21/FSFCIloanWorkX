<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptPerformanceReport
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
        Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary9 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.lblPenalties_4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInterest_4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrincipal_4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblReleases_3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmount_3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblClient_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRatio_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmount_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblClients_1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblOutstanding_1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountOfficer = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.lblFSFC = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBranch = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAsOf = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountH = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblOutstanding_1T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblClients_1T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmount_2T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblRatio_2T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblClient_2T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmount_3T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblReleases_3T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrincipal_4T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInterest_4T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPenalties_4T = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblPenalties_4, Me.lblInterest_4, Me.lblPrincipal_4, Me.lblReleases_3, Me.lblAmount_3, Me.lblClient_2, Me.lblRatio_2, Me.lblAmount_2, Me.lblClients_1, Me.lblOutstanding_1, Me.lblAccountOfficer})
        Me.Detail.HeightF = 20.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblPenalties_4
        '
        Me.lblPenalties_4.BackColor = System.Drawing.Color.White
        Me.lblPenalties_4.BorderColor = System.Drawing.Color.Black
        Me.lblPenalties_4.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPenalties_4.CanGrow = False
        Me.lblPenalties_4.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPenalties_4.ForeColor = System.Drawing.Color.Black
        Me.lblPenalties_4.LocationFloat = New DevExpress.Utils.PointFloat(980.0!, 0.0!)
        Me.lblPenalties_4.Name = "lblPenalties_4"
        Me.lblPenalties_4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPenalties_4.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblPenalties_4.StylePriority.UseBackColor = False
        Me.lblPenalties_4.StylePriority.UseBorderColor = False
        Me.lblPenalties_4.StylePriority.UseBorders = False
        Me.lblPenalties_4.StylePriority.UseFont = False
        Me.lblPenalties_4.StylePriority.UseForeColor = False
        Me.lblPenalties_4.StylePriority.UseTextAlignment = False
        Me.lblPenalties_4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPenalties_4.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblInterest_4
        '
        Me.lblInterest_4.BackColor = System.Drawing.Color.White
        Me.lblInterest_4.BorderColor = System.Drawing.Color.Black
        Me.lblInterest_4.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblInterest_4.CanGrow = False
        Me.lblInterest_4.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterest_4.ForeColor = System.Drawing.Color.Black
        Me.lblInterest_4.LocationFloat = New DevExpress.Utils.PointFloat(910.0!, 0.0!)
        Me.lblInterest_4.Name = "lblInterest_4"
        Me.lblInterest_4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInterest_4.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblInterest_4.StylePriority.UseBackColor = False
        Me.lblInterest_4.StylePriority.UseBorderColor = False
        Me.lblInterest_4.StylePriority.UseBorders = False
        Me.lblInterest_4.StylePriority.UseFont = False
        Me.lblInterest_4.StylePriority.UseForeColor = False
        Me.lblInterest_4.StylePriority.UseTextAlignment = False
        Me.lblInterest_4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblInterest_4.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPrincipal_4
        '
        Me.lblPrincipal_4.BackColor = System.Drawing.Color.White
        Me.lblPrincipal_4.BorderColor = System.Drawing.Color.Black
        Me.lblPrincipal_4.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPrincipal_4.CanGrow = False
        Me.lblPrincipal_4.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipal_4.ForeColor = System.Drawing.Color.Black
        Me.lblPrincipal_4.LocationFloat = New DevExpress.Utils.PointFloat(835.0!, 0.0!)
        Me.lblPrincipal_4.Name = "lblPrincipal_4"
        Me.lblPrincipal_4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrincipal_4.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.lblPrincipal_4.StylePriority.UseBackColor = False
        Me.lblPrincipal_4.StylePriority.UseBorderColor = False
        Me.lblPrincipal_4.StylePriority.UseBorders = False
        Me.lblPrincipal_4.StylePriority.UseFont = False
        Me.lblPrincipal_4.StylePriority.UseForeColor = False
        Me.lblPrincipal_4.StylePriority.UseTextAlignment = False
        Me.lblPrincipal_4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPrincipal_4.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblReleases_3
        '
        Me.lblReleases_3.BackColor = System.Drawing.Color.White
        Me.lblReleases_3.BorderColor = System.Drawing.Color.Black
        Me.lblReleases_3.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblReleases_3.CanGrow = False
        Me.lblReleases_3.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReleases_3.ForeColor = System.Drawing.Color.Black
        Me.lblReleases_3.LocationFloat = New DevExpress.Utils.PointFloat(755.0!, 0.0!)
        Me.lblReleases_3.Name = "lblReleases_3"
        Me.lblReleases_3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblReleases_3.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.lblReleases_3.StylePriority.UseBackColor = False
        Me.lblReleases_3.StylePriority.UseBorderColor = False
        Me.lblReleases_3.StylePriority.UseBorders = False
        Me.lblReleases_3.StylePriority.UseFont = False
        Me.lblReleases_3.StylePriority.UseForeColor = False
        Me.lblReleases_3.StylePriority.UseTextAlignment = False
        Me.lblReleases_3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAmount_3
        '
        Me.lblAmount_3.BackColor = System.Drawing.Color.White
        Me.lblAmount_3.BorderColor = System.Drawing.Color.Black
        Me.lblAmount_3.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmount_3.CanGrow = False
        Me.lblAmount_3.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount_3.ForeColor = System.Drawing.Color.Black
        Me.lblAmount_3.LocationFloat = New DevExpress.Utils.PointFloat(620.0!, 0.0!)
        Me.lblAmount_3.Name = "lblAmount_3"
        Me.lblAmount_3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount_3.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.lblAmount_3.StylePriority.UseBackColor = False
        Me.lblAmount_3.StylePriority.UseBorderColor = False
        Me.lblAmount_3.StylePriority.UseBorders = False
        Me.lblAmount_3.StylePriority.UseFont = False
        Me.lblAmount_3.StylePriority.UseForeColor = False
        Me.lblAmount_3.StylePriority.UseTextAlignment = False
        Me.lblAmount_3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmount_3.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblClient_2
        '
        Me.lblClient_2.BackColor = System.Drawing.Color.White
        Me.lblClient_2.BorderColor = System.Drawing.Color.Black
        Me.lblClient_2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblClient_2.CanGrow = False
        Me.lblClient_2.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClient_2.ForeColor = System.Drawing.Color.Black
        Me.lblClient_2.LocationFloat = New DevExpress.Utils.PointFloat(555.0!, 0.0!)
        Me.lblClient_2.Name = "lblClient_2"
        Me.lblClient_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblClient_2.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblClient_2.StylePriority.UseBackColor = False
        Me.lblClient_2.StylePriority.UseBorderColor = False
        Me.lblClient_2.StylePriority.UseBorders = False
        Me.lblClient_2.StylePriority.UseFont = False
        Me.lblClient_2.StylePriority.UseForeColor = False
        Me.lblClient_2.StylePriority.UseTextAlignment = False
        Me.lblClient_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblRatio_2
        '
        Me.lblRatio_2.BackColor = System.Drawing.Color.White
        Me.lblRatio_2.BorderColor = System.Drawing.Color.Black
        Me.lblRatio_2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblRatio_2.CanGrow = False
        Me.lblRatio_2.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRatio_2.ForeColor = System.Drawing.Color.Black
        Me.lblRatio_2.LocationFloat = New DevExpress.Utils.PointFloat(490.0!, 0.0!)
        Me.lblRatio_2.Name = "lblRatio_2"
        Me.lblRatio_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRatio_2.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblRatio_2.StylePriority.UseBackColor = False
        Me.lblRatio_2.StylePriority.UseBorderColor = False
        Me.lblRatio_2.StylePriority.UseBorders = False
        Me.lblRatio_2.StylePriority.UseFont = False
        Me.lblRatio_2.StylePriority.UseForeColor = False
        Me.lblRatio_2.StylePriority.UseTextAlignment = False
        Me.lblRatio_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAmount_2
        '
        Me.lblAmount_2.BackColor = System.Drawing.Color.White
        Me.lblAmount_2.BorderColor = System.Drawing.Color.Black
        Me.lblAmount_2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmount_2.CanGrow = False
        Me.lblAmount_2.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount_2.ForeColor = System.Drawing.Color.Black
        Me.lblAmount_2.LocationFloat = New DevExpress.Utils.PointFloat(405.0!, 0.0!)
        Me.lblAmount_2.Name = "lblAmount_2"
        Me.lblAmount_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount_2.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.lblAmount_2.StylePriority.UseBackColor = False
        Me.lblAmount_2.StylePriority.UseBorderColor = False
        Me.lblAmount_2.StylePriority.UseBorders = False
        Me.lblAmount_2.StylePriority.UseFont = False
        Me.lblAmount_2.StylePriority.UseForeColor = False
        Me.lblAmount_2.StylePriority.UseTextAlignment = False
        Me.lblAmount_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmount_2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblClients_1
        '
        Me.lblClients_1.BackColor = System.Drawing.Color.White
        Me.lblClients_1.BorderColor = System.Drawing.Color.Black
        Me.lblClients_1.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblClients_1.CanGrow = False
        Me.lblClients_1.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClients_1.ForeColor = System.Drawing.Color.Black
        Me.lblClients_1.LocationFloat = New DevExpress.Utils.PointFloat(340.0!, 0.0!)
        Me.lblClients_1.Name = "lblClients_1"
        Me.lblClients_1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblClients_1.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblClients_1.StylePriority.UseBackColor = False
        Me.lblClients_1.StylePriority.UseBorderColor = False
        Me.lblClients_1.StylePriority.UseBorders = False
        Me.lblClients_1.StylePriority.UseFont = False
        Me.lblClients_1.StylePriority.UseForeColor = False
        Me.lblClients_1.StylePriority.UseTextAlignment = False
        Me.lblClients_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblOutstanding_1
        '
        Me.lblOutstanding_1.BackColor = System.Drawing.Color.White
        Me.lblOutstanding_1.BorderColor = System.Drawing.Color.Black
        Me.lblOutstanding_1.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblOutstanding_1.CanGrow = False
        Me.lblOutstanding_1.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutstanding_1.ForeColor = System.Drawing.Color.Black
        Me.lblOutstanding_1.LocationFloat = New DevExpress.Utils.PointFloat(190.0!, 0.0!)
        Me.lblOutstanding_1.Name = "lblOutstanding_1"
        Me.lblOutstanding_1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblOutstanding_1.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.lblOutstanding_1.StylePriority.UseBackColor = False
        Me.lblOutstanding_1.StylePriority.UseBorderColor = False
        Me.lblOutstanding_1.StylePriority.UseBorders = False
        Me.lblOutstanding_1.StylePriority.UseFont = False
        Me.lblOutstanding_1.StylePriority.UseForeColor = False
        Me.lblOutstanding_1.StylePriority.UseTextAlignment = False
        Me.lblOutstanding_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblOutstanding_1.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblAccountOfficer
        '
        Me.lblAccountOfficer.BackColor = System.Drawing.Color.White
        Me.lblAccountOfficer.BorderColor = System.Drawing.Color.Black
        Me.lblAccountOfficer.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccountOfficer.CanGrow = False
        Me.lblAccountOfficer.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountOfficer.ForeColor = System.Drawing.Color.Black
        Me.lblAccountOfficer.LocationFloat = New DevExpress.Utils.PointFloat(0.00001843771!, 0.0!)
        Me.lblAccountOfficer.Name = "lblAccountOfficer"
        Me.lblAccountOfficer.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountOfficer.SizeF = New System.Drawing.SizeF(190.0!, 20.0!)
        Me.lblAccountOfficer.StylePriority.UseBackColor = False
        Me.lblAccountOfficer.StylePriority.UseBorderColor = False
        Me.lblAccountOfficer.StylePriority.UseBorders = False
        Me.lblAccountOfficer.StylePriority.UseFont = False
        Me.lblAccountOfficer.StylePriority.UseForeColor = False
        Me.lblAccountOfficer.StylePriority.UseTextAlignment = False
        Me.lblAccountOfficer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
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
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblFSFC, Me.lblBranch, Me.lblTitle, Me.lblAsOf})
        Me.ReportHeader.HeightF = 70.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'lblFSFC
        '
        Me.lblFSFC.BackColor = System.Drawing.Color.White
        Me.lblFSFC.BorderColor = System.Drawing.Color.Black
        Me.lblFSFC.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblFSFC.CanGrow = False
        Me.lblFSFC.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFSFC.ForeColor = System.Drawing.Color.Black
        Me.lblFSFC.LocationFloat = New DevExpress.Utils.PointFloat(0.00001843771!, 0.0!)
        Me.lblFSFC.Name = "lblFSFC"
        Me.lblFSFC.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFSFC.SizeF = New System.Drawing.SizeF(1050.0!, 20.0!)
        Me.lblFSFC.StylePriority.UseBackColor = False
        Me.lblFSFC.StylePriority.UseBorderColor = False
        Me.lblFSFC.StylePriority.UseBorders = False
        Me.lblFSFC.StylePriority.UseFont = False
        Me.lblFSFC.StylePriority.UseForeColor = False
        Me.lblFSFC.StylePriority.UseTextAlignment = False
        Me.lblFSFC.Text = "FIRST STANDARD FINANCE CORPORATION"
        Me.lblFSFC.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblBranch
        '
        Me.lblBranch.BackColor = System.Drawing.Color.White
        Me.lblBranch.BorderColor = System.Drawing.Color.Black
        Me.lblBranch.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblBranch.CanGrow = False
        Me.lblBranch.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranch.ForeColor = System.Drawing.Color.Black
        Me.lblBranch.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 20.0!)
        Me.lblBranch.Name = "lblBranch"
        Me.lblBranch.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBranch.SizeF = New System.Drawing.SizeF(1050.0!, 15.0!)
        Me.lblBranch.StylePriority.UseBackColor = False
        Me.lblBranch.StylePriority.UseBorderColor = False
        Me.lblBranch.StylePriority.UseBorders = False
        Me.lblBranch.StylePriority.UseFont = False
        Me.lblBranch.StylePriority.UseForeColor = False
        Me.lblBranch.StylePriority.UseTextAlignment = False
        Me.lblBranch.Text = "ILOILO BRANCH"
        Me.lblBranch.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.White
        Me.lblTitle.BorderColor = System.Drawing.Color.Black
        Me.lblTitle.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblTitle.CanGrow = False
        Me.lblTitle.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTitle.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 40.0!)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTitle.SizeF = New System.Drawing.SizeF(1050.0!, 15.0!)
        Me.lblTitle.StylePriority.UseBackColor = False
        Me.lblTitle.StylePriority.UseBorderColor = False
        Me.lblTitle.StylePriority.UseBorders = False
        Me.lblTitle.StylePriority.UseFont = False
        Me.lblTitle.StylePriority.UseForeColor = False
        Me.lblTitle.StylePriority.UseTextAlignment = False
        Me.lblTitle.Text = "PERFORMANCE REPORT PER ACCOUNT OFFICER"
        Me.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAsOf
        '
        Me.lblAsOf.BackColor = System.Drawing.Color.White
        Me.lblAsOf.BorderColor = System.Drawing.Color.Black
        Me.lblAsOf.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblAsOf.CanGrow = False
        Me.lblAsOf.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAsOf.ForeColor = System.Drawing.Color.Black
        Me.lblAsOf.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 55.0!)
        Me.lblAsOf.Name = "lblAsOf"
        Me.lblAsOf.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAsOf.SizeF = New System.Drawing.SizeF(1050.0!, 15.0!)
        Me.lblAsOf.StylePriority.UseBackColor = False
        Me.lblAsOf.StylePriority.UseBorderColor = False
        Me.lblAsOf.StylePriority.UseBorders = False
        Me.lblAsOf.StylePriority.UseFont = False
        Me.lblAsOf.StylePriority.UseForeColor = False
        Me.lblAsOf.StylePriority.UseTextAlignment = False
        Me.lblAsOf.Text = "As Of June 30, 2020"
        Me.lblAsOf.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel14, Me.XrLabel13, Me.XrLabel12, Me.XrLabel10, Me.XrLabel11, Me.XrLabel9, Me.XrLabel7, Me.XrLabel8, Me.XrLabel6, Me.XrLabel5, Me.XrLabel4, Me.XrLabel2, Me.XrLabel1, Me.lblAccountH, Me.XrLabel3})
        Me.PageHeader.HeightF = 40.00002!
        Me.PageHeader.Name = "PageHeader"
        '
        'XrLabel14
        '
        Me.XrLabel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel14.BorderColor = System.Drawing.Color.Black
        Me.XrLabel14.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel14.CanGrow = False
        Me.XrLabel14.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel14.ForeColor = System.Drawing.Color.White
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(980.0!, 20.00002!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.XrLabel14.StylePriority.UseBackColor = False
        Me.XrLabel14.StylePriority.UseBorderColor = False
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.StylePriority.UseForeColor = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = "Penalties"
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel13
        '
        Me.XrLabel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel13.BorderColor = System.Drawing.Color.Black
        Me.XrLabel13.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel13.CanGrow = False
        Me.XrLabel13.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel13.ForeColor = System.Drawing.Color.White
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(910.0!, 20.00001!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.XrLabel13.StylePriority.UseBackColor = False
        Me.XrLabel13.StylePriority.UseBorderColor = False
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.StylePriority.UseFont = False
        Me.XrLabel13.StylePriority.UseForeColor = False
        Me.XrLabel13.StylePriority.UseTextAlignment = False
        Me.XrLabel13.Text = "Interest"
        Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel12
        '
        Me.XrLabel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel12.BorderColor = System.Drawing.Color.Black
        Me.XrLabel12.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel12.CanGrow = False
        Me.XrLabel12.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel12.ForeColor = System.Drawing.Color.White
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(835.0!, 20.00001!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.XrLabel12.StylePriority.UseBackColor = False
        Me.XrLabel12.StylePriority.UseBorderColor = False
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseForeColor = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = "Principal"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel10
        '
        Me.XrLabel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel10.BorderColor = System.Drawing.Color.Black
        Me.XrLabel10.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel10.CanGrow = False
        Me.XrLabel10.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel10.ForeColor = System.Drawing.Color.White
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(755.0!, 20.00001!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.XrLabel10.StylePriority.UseBackColor = False
        Me.XrLabel10.StylePriority.UseBorderColor = False
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseForeColor = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = "No. of Releases"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel11
        '
        Me.XrLabel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel11.BorderColor = System.Drawing.Color.Black
        Me.XrLabel11.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel11.CanGrow = False
        Me.XrLabel11.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel11.ForeColor = System.Drawing.Color.White
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(620.0!, 20.00001!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.XrLabel11.StylePriority.UseBackColor = False
        Me.XrLabel11.StylePriority.UseBorderColor = False
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseForeColor = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = "Amount"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel9
        '
        Me.XrLabel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel9.BorderColor = System.Drawing.Color.Black
        Me.XrLabel9.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel9.CanGrow = False
        Me.XrLabel9.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.ForeColor = System.Drawing.Color.White
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(490.0!, 20.0!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.XrLabel9.StylePriority.UseBackColor = False
        Me.XrLabel9.StylePriority.UseBorderColor = False
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseForeColor = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = "Ratio"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel7
        '
        Me.XrLabel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel7.BorderColor = System.Drawing.Color.Black
        Me.XrLabel7.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel7.CanGrow = False
        Me.XrLabel7.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.ForeColor = System.Drawing.Color.White
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(405.0!, 20.0!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.XrLabel7.StylePriority.UseBackColor = False
        Me.XrLabel7.StylePriority.UseBorderColor = False
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseForeColor = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "Amount"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel8
        '
        Me.XrLabel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel8.BorderColor = System.Drawing.Color.Black
        Me.XrLabel8.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel8.CanGrow = False
        Me.XrLabel8.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.ForeColor = System.Drawing.Color.White
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(555.0!, 20.0!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.XrLabel8.StylePriority.UseBackColor = False
        Me.XrLabel8.StylePriority.UseBorderColor = False
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseForeColor = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "No. of Client"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel6
        '
        Me.XrLabel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel6.BorderColor = System.Drawing.Color.Black
        Me.XrLabel6.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel6.CanGrow = False
        Me.XrLabel6.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.ForeColor = System.Drawing.Color.White
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(340.0!, 20.0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.XrLabel6.StylePriority.UseBackColor = False
        Me.XrLabel6.StylePriority.UseBorderColor = False
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseForeColor = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "No. of Client"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel5
        '
        Me.XrLabel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel5.BorderColor = System.Drawing.Color.Black
        Me.XrLabel5.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel5.CanGrow = False
        Me.XrLabel5.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.ForeColor = System.Drawing.Color.White
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(835.0!, 0.0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(215.0!, 20.0!)
        Me.XrLabel5.StylePriority.UseBackColor = False
        Me.XrLabel5.StylePriority.UseBorderColor = False
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseForeColor = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "Collections"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel4
        '
        Me.XrLabel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel4.BorderColor = System.Drawing.Color.Black
        Me.XrLabel4.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel4.CanGrow = False
        Me.XrLabel4.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.ForeColor = System.Drawing.Color.White
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(620.0!, 0.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(215.0!, 20.0!)
        Me.XrLabel4.StylePriority.UseBackColor = False
        Me.XrLabel4.StylePriority.UseBorderColor = False
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseForeColor = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "Releases"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel2
        '
        Me.XrLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel2.BorderColor = System.Drawing.Color.Black
        Me.XrLabel2.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel2.CanGrow = False
        Me.XrLabel2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.ForeColor = System.Drawing.Color.White
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(405.0!, 0.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(215.0!, 20.0!)
        Me.XrLabel2.StylePriority.UseBackColor = False
        Me.XrLabel2.StylePriority.UseBorderColor = False
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseForeColor = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "PAST DUE (Arrears)"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel1
        '
        Me.XrLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel1.BorderColor = System.Drawing.Color.Black
        Me.XrLabel1.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel1.CanGrow = False
        Me.XrLabel1.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.ForeColor = System.Drawing.Color.White
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(190.0!, 20.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.XrLabel1.StylePriority.UseBackColor = False
        Me.XrLabel1.StylePriority.UseBorderColor = False
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseForeColor = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Principal + Interest Outstanding"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAccountH
        '
        Me.lblAccountH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblAccountH.BorderColor = System.Drawing.Color.Black
        Me.lblAccountH.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccountH.CanGrow = False
        Me.lblAccountH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountH.ForeColor = System.Drawing.Color.White
        Me.lblAccountH.LocationFloat = New DevExpress.Utils.PointFloat(0.00001843771!, 0.0!)
        Me.lblAccountH.Name = "lblAccountH"
        Me.lblAccountH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountH.SizeF = New System.Drawing.SizeF(190.0!, 40.0!)
        Me.lblAccountH.StylePriority.UseBackColor = False
        Me.lblAccountH.StylePriority.UseBorderColor = False
        Me.lblAccountH.StylePriority.UseBorders = False
        Me.lblAccountH.StylePriority.UseFont = False
        Me.lblAccountH.StylePriority.UseForeColor = False
        Me.lblAccountH.StylePriority.UseTextAlignment = False
        Me.lblAccountH.Text = "Account Officer"
        Me.lblAccountH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(190.0!, 0.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(215.0!, 20.0!)
        Me.XrLabel3.StylePriority.UseBackColor = False
        Me.XrLabel3.StylePriority.UseBorderColor = False
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseForeColor = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "Portfolio"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1, Me.XrPageInfo2})
        Me.PageFooter.HeightF = 20.0!
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
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
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
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 0.0!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.XrPageInfo2.StylePriority.UseBackColor = False
        Me.XrPageInfo2.StylePriority.UseFont = False
        Me.XrPageInfo2.StylePriority.UseTextAlignment = False
        Me.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel15, Me.lblOutstanding_1T, Me.lblClients_1T, Me.lblAmount_2T, Me.lblRatio_2T, Me.lblClient_2T, Me.lblAmount_3T, Me.lblReleases_3T, Me.lblPrincipal_4T, Me.lblInterest_4T, Me.lblPenalties_4T})
        Me.ReportFooter.HeightF = 20.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrLabel15
        '
        Me.XrLabel15.BackColor = System.Drawing.Color.White
        Me.XrLabel15.BorderColor = System.Drawing.Color.Black
        Me.XrLabel15.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel15.CanGrow = False
        Me.XrLabel15.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel15.ForeColor = System.Drawing.Color.Black
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(190.0!, 20.0!)
        Me.XrLabel15.StylePriority.UseBackColor = False
        Me.XrLabel15.StylePriority.UseBorderColor = False
        Me.XrLabel15.StylePriority.UseBorders = False
        Me.XrLabel15.StylePriority.UseFont = False
        Me.XrLabel15.StylePriority.UseForeColor = False
        Me.XrLabel15.StylePriority.UseTextAlignment = False
        Me.XrLabel15.Text = "TOTAL"
        Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblOutstanding_1T
        '
        Me.lblOutstanding_1T.BackColor = System.Drawing.Color.White
        Me.lblOutstanding_1T.BorderColor = System.Drawing.Color.Black
        Me.lblOutstanding_1T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblOutstanding_1T.CanGrow = False
        Me.lblOutstanding_1T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutstanding_1T.ForeColor = System.Drawing.Color.Black
        Me.lblOutstanding_1T.LocationFloat = New DevExpress.Utils.PointFloat(190.0!, 0.0!)
        Me.lblOutstanding_1T.Name = "lblOutstanding_1T"
        Me.lblOutstanding_1T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblOutstanding_1T.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.lblOutstanding_1T.StylePriority.UseBackColor = False
        Me.lblOutstanding_1T.StylePriority.UseBorderColor = False
        Me.lblOutstanding_1T.StylePriority.UseBorders = False
        Me.lblOutstanding_1T.StylePriority.UseFont = False
        Me.lblOutstanding_1T.StylePriority.UseForeColor = False
        Me.lblOutstanding_1T.StylePriority.UseTextAlignment = False
        XrSummary1.FormatString = "{0:n2}"
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.lblOutstanding_1T.Summary = XrSummary1
        Me.lblOutstanding_1T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblOutstanding_1T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblClients_1T
        '
        Me.lblClients_1T.BackColor = System.Drawing.Color.White
        Me.lblClients_1T.BorderColor = System.Drawing.Color.Black
        Me.lblClients_1T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblClients_1T.CanGrow = False
        Me.lblClients_1T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClients_1T.ForeColor = System.Drawing.Color.Black
        Me.lblClients_1T.LocationFloat = New DevExpress.Utils.PointFloat(340.0!, 0.0!)
        Me.lblClients_1T.Name = "lblClients_1T"
        Me.lblClients_1T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblClients_1T.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblClients_1T.StylePriority.UseBackColor = False
        Me.lblClients_1T.StylePriority.UseBorderColor = False
        Me.lblClients_1T.StylePriority.UseBorders = False
        Me.lblClients_1T.StylePriority.UseFont = False
        Me.lblClients_1T.StylePriority.UseForeColor = False
        Me.lblClients_1T.StylePriority.UseTextAlignment = False
        XrSummary2.FormatString = "{0:n0}"
        XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.lblClients_1T.Summary = XrSummary2
        Me.lblClients_1T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAmount_2T
        '
        Me.lblAmount_2T.BackColor = System.Drawing.Color.White
        Me.lblAmount_2T.BorderColor = System.Drawing.Color.Black
        Me.lblAmount_2T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmount_2T.CanGrow = False
        Me.lblAmount_2T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount_2T.ForeColor = System.Drawing.Color.Black
        Me.lblAmount_2T.LocationFloat = New DevExpress.Utils.PointFloat(405.0!, 0.0!)
        Me.lblAmount_2T.Name = "lblAmount_2T"
        Me.lblAmount_2T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount_2T.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.lblAmount_2T.StylePriority.UseBackColor = False
        Me.lblAmount_2T.StylePriority.UseBorderColor = False
        Me.lblAmount_2T.StylePriority.UseBorders = False
        Me.lblAmount_2T.StylePriority.UseFont = False
        Me.lblAmount_2T.StylePriority.UseForeColor = False
        Me.lblAmount_2T.StylePriority.UseTextAlignment = False
        XrSummary3.FormatString = "{0:n2}"
        XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.lblAmount_2T.Summary = XrSummary3
        Me.lblAmount_2T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmount_2T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblRatio_2T
        '
        Me.lblRatio_2T.BackColor = System.Drawing.Color.White
        Me.lblRatio_2T.BorderColor = System.Drawing.Color.Black
        Me.lblRatio_2T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblRatio_2T.CanGrow = False
        Me.lblRatio_2T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRatio_2T.ForeColor = System.Drawing.Color.Black
        Me.lblRatio_2T.LocationFloat = New DevExpress.Utils.PointFloat(490.0!, 0.0!)
        Me.lblRatio_2T.Name = "lblRatio_2T"
        Me.lblRatio_2T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRatio_2T.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblRatio_2T.StylePriority.UseBackColor = False
        Me.lblRatio_2T.StylePriority.UseBorderColor = False
        Me.lblRatio_2T.StylePriority.UseBorders = False
        Me.lblRatio_2T.StylePriority.UseFont = False
        Me.lblRatio_2T.StylePriority.UseForeColor = False
        Me.lblRatio_2T.StylePriority.UseTextAlignment = False
        Me.lblRatio_2T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblClient_2T
        '
        Me.lblClient_2T.BackColor = System.Drawing.Color.White
        Me.lblClient_2T.BorderColor = System.Drawing.Color.Black
        Me.lblClient_2T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblClient_2T.CanGrow = False
        Me.lblClient_2T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClient_2T.ForeColor = System.Drawing.Color.Black
        Me.lblClient_2T.LocationFloat = New DevExpress.Utils.PointFloat(555.0!, 0.0!)
        Me.lblClient_2T.Name = "lblClient_2T"
        Me.lblClient_2T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblClient_2T.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblClient_2T.StylePriority.UseBackColor = False
        Me.lblClient_2T.StylePriority.UseBorderColor = False
        Me.lblClient_2T.StylePriority.UseBorders = False
        Me.lblClient_2T.StylePriority.UseFont = False
        Me.lblClient_2T.StylePriority.UseForeColor = False
        Me.lblClient_2T.StylePriority.UseTextAlignment = False
        XrSummary4.FormatString = "{0:n0}"
        XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.lblClient_2T.Summary = XrSummary4
        Me.lblClient_2T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAmount_3T
        '
        Me.lblAmount_3T.BackColor = System.Drawing.Color.White
        Me.lblAmount_3T.BorderColor = System.Drawing.Color.Black
        Me.lblAmount_3T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmount_3T.CanGrow = False
        Me.lblAmount_3T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount_3T.ForeColor = System.Drawing.Color.Black
        Me.lblAmount_3T.LocationFloat = New DevExpress.Utils.PointFloat(620.0!, 0.0!)
        Me.lblAmount_3T.Name = "lblAmount_3T"
        Me.lblAmount_3T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount_3T.SizeF = New System.Drawing.SizeF(135.0!, 20.0!)
        Me.lblAmount_3T.StylePriority.UseBackColor = False
        Me.lblAmount_3T.StylePriority.UseBorderColor = False
        Me.lblAmount_3T.StylePriority.UseBorders = False
        Me.lblAmount_3T.StylePriority.UseFont = False
        Me.lblAmount_3T.StylePriority.UseForeColor = False
        Me.lblAmount_3T.StylePriority.UseTextAlignment = False
        XrSummary5.FormatString = "{0:n2}"
        XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.lblAmount_3T.Summary = XrSummary5
        Me.lblAmount_3T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmount_3T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblReleases_3T
        '
        Me.lblReleases_3T.BackColor = System.Drawing.Color.White
        Me.lblReleases_3T.BorderColor = System.Drawing.Color.Black
        Me.lblReleases_3T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblReleases_3T.CanGrow = False
        Me.lblReleases_3T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReleases_3T.ForeColor = System.Drawing.Color.Black
        Me.lblReleases_3T.LocationFloat = New DevExpress.Utils.PointFloat(755.0!, 0.0!)
        Me.lblReleases_3T.Name = "lblReleases_3T"
        Me.lblReleases_3T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblReleases_3T.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.lblReleases_3T.StylePriority.UseBackColor = False
        Me.lblReleases_3T.StylePriority.UseBorderColor = False
        Me.lblReleases_3T.StylePriority.UseBorders = False
        Me.lblReleases_3T.StylePriority.UseFont = False
        Me.lblReleases_3T.StylePriority.UseForeColor = False
        Me.lblReleases_3T.StylePriority.UseTextAlignment = False
        XrSummary6.FormatString = "{0:n0}"
        XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.lblReleases_3T.Summary = XrSummary6
        Me.lblReleases_3T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblPrincipal_4T
        '
        Me.lblPrincipal_4T.BackColor = System.Drawing.Color.White
        Me.lblPrincipal_4T.BorderColor = System.Drawing.Color.Black
        Me.lblPrincipal_4T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPrincipal_4T.CanGrow = False
        Me.lblPrincipal_4T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipal_4T.ForeColor = System.Drawing.Color.Black
        Me.lblPrincipal_4T.LocationFloat = New DevExpress.Utils.PointFloat(835.0!, 0.0!)
        Me.lblPrincipal_4T.Name = "lblPrincipal_4T"
        Me.lblPrincipal_4T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrincipal_4T.SizeF = New System.Drawing.SizeF(75.0!, 20.0!)
        Me.lblPrincipal_4T.StylePriority.UseBackColor = False
        Me.lblPrincipal_4T.StylePriority.UseBorderColor = False
        Me.lblPrincipal_4T.StylePriority.UseBorders = False
        Me.lblPrincipal_4T.StylePriority.UseFont = False
        Me.lblPrincipal_4T.StylePriority.UseForeColor = False
        Me.lblPrincipal_4T.StylePriority.UseTextAlignment = False
        XrSummary7.FormatString = "{0:n2}"
        XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.lblPrincipal_4T.Summary = XrSummary7
        Me.lblPrincipal_4T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPrincipal_4T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblInterest_4T
        '
        Me.lblInterest_4T.BackColor = System.Drawing.Color.White
        Me.lblInterest_4T.BorderColor = System.Drawing.Color.Black
        Me.lblInterest_4T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblInterest_4T.CanGrow = False
        Me.lblInterest_4T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterest_4T.ForeColor = System.Drawing.Color.Black
        Me.lblInterest_4T.LocationFloat = New DevExpress.Utils.PointFloat(910.0!, 0.0!)
        Me.lblInterest_4T.Name = "lblInterest_4T"
        Me.lblInterest_4T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInterest_4T.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblInterest_4T.StylePriority.UseBackColor = False
        Me.lblInterest_4T.StylePriority.UseBorderColor = False
        Me.lblInterest_4T.StylePriority.UseBorders = False
        Me.lblInterest_4T.StylePriority.UseFont = False
        Me.lblInterest_4T.StylePriority.UseForeColor = False
        Me.lblInterest_4T.StylePriority.UseTextAlignment = False
        XrSummary8.FormatString = "{0:n2}"
        XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.lblInterest_4T.Summary = XrSummary8
        Me.lblInterest_4T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblInterest_4T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPenalties_4T
        '
        Me.lblPenalties_4T.BackColor = System.Drawing.Color.White
        Me.lblPenalties_4T.BorderColor = System.Drawing.Color.Black
        Me.lblPenalties_4T.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPenalties_4T.CanGrow = False
        Me.lblPenalties_4T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPenalties_4T.ForeColor = System.Drawing.Color.Black
        Me.lblPenalties_4T.LocationFloat = New DevExpress.Utils.PointFloat(980.0!, 0.0!)
        Me.lblPenalties_4T.Name = "lblPenalties_4T"
        Me.lblPenalties_4T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPenalties_4T.SizeF = New System.Drawing.SizeF(70.0!, 20.0!)
        Me.lblPenalties_4T.StylePriority.UseBackColor = False
        Me.lblPenalties_4T.StylePriority.UseBorderColor = False
        Me.lblPenalties_4T.StylePriority.UseBorders = False
        Me.lblPenalties_4T.StylePriority.UseFont = False
        Me.lblPenalties_4T.StylePriority.UseForeColor = False
        Me.lblPenalties_4T.StylePriority.UseTextAlignment = False
        XrSummary9.FormatString = "{0:n2}"
        XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.lblPenalties_4T.Summary = XrSummary9
        Me.lblPenalties_4T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPenalties_4T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'rptPerformanceReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.PageHeader, Me.PageFooter, Me.ReportFooter})
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
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents lblFSFC As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBranch As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAsOf As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPenalties_4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInterest_4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrincipal_4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblReleases_3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmount_3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblClient_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRatio_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmount_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblClients_1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblOutstanding_1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountOfficer As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblOutstanding_1T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblClients_1T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmount_2T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRatio_2T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblClient_2T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmount_3T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblReleases_3T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrincipal_4T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInterest_4T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPenalties_4T As DevExpress.XtraReports.UI.XRLabel
End Class
