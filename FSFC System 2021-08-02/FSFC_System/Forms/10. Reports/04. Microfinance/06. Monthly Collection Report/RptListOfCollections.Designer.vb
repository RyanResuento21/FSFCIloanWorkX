<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptListOfCollections
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
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.lblTotalCollection = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInterestAfterMaturity = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInterest = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPenalty = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrincipal = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblORNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBorrower = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPostingDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.lblFSFC = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBranch = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAsOf = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
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
        Me.GroupHeader1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.lblBorrowerH = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPrincipalT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPenaltyT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInterestT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblInterestAfterMaturityT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotalCollectionT = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblTotalCollection, Me.lblInterestAfterMaturity, Me.lblInterest, Me.lblPenalty, Me.lblPrincipal, Me.lblORNumber, Me.lblBorrower, Me.lblPostingDate})
        Me.Detail.HeightF = 20.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblTotalCollection
        '
        Me.lblTotalCollection.BackColor = System.Drawing.Color.White
        Me.lblTotalCollection.BorderColor = System.Drawing.Color.Black
        Me.lblTotalCollection.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotalCollection.CanGrow = False
        Me.lblTotalCollection.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCollection.ForeColor = System.Drawing.Color.Black
        Me.lblTotalCollection.LocationFloat = New DevExpress.Utils.PointFloat(715.0!, 0.0!)
        Me.lblTotalCollection.Name = "lblTotalCollection"
        Me.lblTotalCollection.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotalCollection.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.lblTotalCollection.StylePriority.UseBackColor = False
        Me.lblTotalCollection.StylePriority.UseBorderColor = False
        Me.lblTotalCollection.StylePriority.UseBorders = False
        Me.lblTotalCollection.StylePriority.UseFont = False
        Me.lblTotalCollection.StylePriority.UseForeColor = False
        Me.lblTotalCollection.StylePriority.UseTextAlignment = False
        Me.lblTotalCollection.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblTotalCollection.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblInterestAfterMaturity
        '
        Me.lblInterestAfterMaturity.BackColor = System.Drawing.Color.White
        Me.lblInterestAfterMaturity.BorderColor = System.Drawing.Color.Black
        Me.lblInterestAfterMaturity.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblInterestAfterMaturity.CanGrow = False
        Me.lblInterestAfterMaturity.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterestAfterMaturity.ForeColor = System.Drawing.Color.Black
        Me.lblInterestAfterMaturity.LocationFloat = New DevExpress.Utils.PointFloat(630.0!, 0.0!)
        Me.lblInterestAfterMaturity.Name = "lblInterestAfterMaturity"
        Me.lblInterestAfterMaturity.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInterestAfterMaturity.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.lblInterestAfterMaturity.StylePriority.UseBackColor = False
        Me.lblInterestAfterMaturity.StylePriority.UseBorderColor = False
        Me.lblInterestAfterMaturity.StylePriority.UseBorders = False
        Me.lblInterestAfterMaturity.StylePriority.UseFont = False
        Me.lblInterestAfterMaturity.StylePriority.UseForeColor = False
        Me.lblInterestAfterMaturity.StylePriority.UseTextAlignment = False
        Me.lblInterestAfterMaturity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblInterestAfterMaturity.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblInterest
        '
        Me.lblInterest.BackColor = System.Drawing.Color.White
        Me.lblInterest.BorderColor = System.Drawing.Color.Black
        Me.lblInterest.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblInterest.CanGrow = False
        Me.lblInterest.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterest.ForeColor = System.Drawing.Color.Black
        Me.lblInterest.LocationFloat = New DevExpress.Utils.PointFloat(460.0!, 0.0!)
        Me.lblInterest.Name = "lblInterest"
        Me.lblInterest.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInterest.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.lblInterest.StylePriority.UseBackColor = False
        Me.lblInterest.StylePriority.UseBorderColor = False
        Me.lblInterest.StylePriority.UseBorders = False
        Me.lblInterest.StylePriority.UseFont = False
        Me.lblInterest.StylePriority.UseForeColor = False
        Me.lblInterest.StylePriority.UseTextAlignment = False
        Me.lblInterest.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblInterest.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPenalty
        '
        Me.lblPenalty.BackColor = System.Drawing.Color.White
        Me.lblPenalty.BorderColor = System.Drawing.Color.Black
        Me.lblPenalty.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPenalty.CanGrow = False
        Me.lblPenalty.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPenalty.ForeColor = System.Drawing.Color.Black
        Me.lblPenalty.LocationFloat = New DevExpress.Utils.PointFloat(545.0!, 0.0!)
        Me.lblPenalty.Name = "lblPenalty"
        Me.lblPenalty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPenalty.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.lblPenalty.StylePriority.UseBackColor = False
        Me.lblPenalty.StylePriority.UseBorderColor = False
        Me.lblPenalty.StylePriority.UseBorders = False
        Me.lblPenalty.StylePriority.UseFont = False
        Me.lblPenalty.StylePriority.UseForeColor = False
        Me.lblPenalty.StylePriority.UseTextAlignment = False
        Me.lblPenalty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPenalty.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPrincipal
        '
        Me.lblPrincipal.BackColor = System.Drawing.Color.White
        Me.lblPrincipal.BorderColor = System.Drawing.Color.Black
        Me.lblPrincipal.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPrincipal.CanGrow = False
        Me.lblPrincipal.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipal.ForeColor = System.Drawing.Color.Black
        Me.lblPrincipal.LocationFloat = New DevExpress.Utils.PointFloat(375.0!, 0.0!)
        Me.lblPrincipal.Name = "lblPrincipal"
        Me.lblPrincipal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrincipal.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.lblPrincipal.StylePriority.UseBackColor = False
        Me.lblPrincipal.StylePriority.UseBorderColor = False
        Me.lblPrincipal.StylePriority.UseBorders = False
        Me.lblPrincipal.StylePriority.UseFont = False
        Me.lblPrincipal.StylePriority.UseForeColor = False
        Me.lblPrincipal.StylePriority.UseTextAlignment = False
        Me.lblPrincipal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPrincipal.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblORNumber
        '
        Me.lblORNumber.BackColor = System.Drawing.Color.White
        Me.lblORNumber.BorderColor = System.Drawing.Color.Black
        Me.lblORNumber.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblORNumber.CanGrow = False
        Me.lblORNumber.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblORNumber.ForeColor = System.Drawing.Color.Black
        Me.lblORNumber.LocationFloat = New DevExpress.Utils.PointFloat(290.0!, 0.0!)
        Me.lblORNumber.Name = "lblORNumber"
        Me.lblORNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblORNumber.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.lblORNumber.StylePriority.UseBackColor = False
        Me.lblORNumber.StylePriority.UseBorderColor = False
        Me.lblORNumber.StylePriority.UseBorders = False
        Me.lblORNumber.StylePriority.UseFont = False
        Me.lblORNumber.StylePriority.UseForeColor = False
        Me.lblORNumber.StylePriority.UseTextAlignment = False
        Me.lblORNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblBorrower
        '
        Me.lblBorrower.BackColor = System.Drawing.Color.White
        Me.lblBorrower.BorderColor = System.Drawing.Color.Black
        Me.lblBorrower.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBorrower.CanGrow = False
        Me.lblBorrower.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrower.ForeColor = System.Drawing.Color.Black
        Me.lblBorrower.LocationFloat = New DevExpress.Utils.PointFloat(0.00001843771!, 0.0!)
        Me.lblBorrower.Name = "lblBorrower"
        Me.lblBorrower.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBorrower.SizeF = New System.Drawing.SizeF(205.0!, 20.0!)
        Me.lblBorrower.StylePriority.UseBackColor = False
        Me.lblBorrower.StylePriority.UseBorderColor = False
        Me.lblBorrower.StylePriority.UseBorders = False
        Me.lblBorrower.StylePriority.UseFont = False
        Me.lblBorrower.StylePriority.UseForeColor = False
        Me.lblBorrower.StylePriority.UseTextAlignment = False
        Me.lblBorrower.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblPostingDate
        '
        Me.lblPostingDate.BackColor = System.Drawing.Color.White
        Me.lblPostingDate.BorderColor = System.Drawing.Color.Black
        Me.lblPostingDate.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPostingDate.CanGrow = False
        Me.lblPostingDate.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPostingDate.ForeColor = System.Drawing.Color.Black
        Me.lblPostingDate.LocationFloat = New DevExpress.Utils.PointFloat(205.0!, 0.0!)
        Me.lblPostingDate.Name = "lblPostingDate"
        Me.lblPostingDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPostingDate.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.lblPostingDate.StylePriority.UseBackColor = False
        Me.lblPostingDate.StylePriority.UseBorderColor = False
        Me.lblPostingDate.StylePriority.UseBorders = False
        Me.lblPostingDate.StylePriority.UseFont = False
        Me.lblPostingDate.StylePriority.UseForeColor = False
        Me.lblPostingDate.StylePriority.UseTextAlignment = False
        Me.lblPostingDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblPostingDate.XlsxFormatString = "mm/dd/yyyy"
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
        Me.lblFSFC.SizeF = New System.Drawing.SizeF(800.0!, 20.0!)
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
        Me.lblBranch.SizeF = New System.Drawing.SizeF(800.0!, 15.0!)
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
        Me.lblTitle.SizeF = New System.Drawing.SizeF(800.0!, 15.0!)
        Me.lblTitle.StylePriority.UseBackColor = False
        Me.lblTitle.StylePriority.UseBorderColor = False
        Me.lblTitle.StylePriority.UseBorders = False
        Me.lblTitle.StylePriority.UseFont = False
        Me.lblTitle.StylePriority.UseForeColor = False
        Me.lblTitle.StylePriority.UseTextAlignment = False
        Me.lblTitle.Text = "LIST OF COLLECTIONS"
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
        Me.lblAsOf.SizeF = New System.Drawing.SizeF(800.0!, 15.0!)
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
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel7, Me.XrLabel6, Me.XrLabel5, Me.XrLabel4, Me.XrLabel2, Me.XrLabel1, Me.lblAccountH, Me.XrLabel3})
        Me.PageHeader.HeightF = 35.0!
        Me.PageHeader.Name = "PageHeader"
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
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(205.0!, 0.0!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(85.0!, 35.0!)
        Me.XrLabel7.StylePriority.UseBackColor = False
        Me.XrLabel7.StylePriority.UseBorderColor = False
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseForeColor = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "Posting Date"
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
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(290.0!, 0.0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(85.0!, 35.0!)
        Me.XrLabel6.StylePriority.UseBackColor = False
        Me.XrLabel6.StylePriority.UseBorderColor = False
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseForeColor = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "OR Number"
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
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(715.0!, 0.0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(85.0!, 35.0!)
        Me.XrLabel5.StylePriority.UseBackColor = False
        Me.XrLabel5.StylePriority.UseBorderColor = False
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseForeColor = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "Total Collections"
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
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(630.0!, 0.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(85.0!, 35.0!)
        Me.XrLabel4.StylePriority.UseBackColor = False
        Me.XrLabel4.StylePriority.UseBorderColor = False
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseForeColor = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "Interest After Maturity"
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
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(545.0!, 0.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(85.0!, 35.0!)
        Me.XrLabel2.StylePriority.UseBackColor = False
        Me.XrLabel2.StylePriority.UseBorderColor = False
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseForeColor = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Penalty"
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
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(460.0!, 0.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(85.0!, 35.0!)
        Me.XrLabel1.StylePriority.UseBackColor = False
        Me.XrLabel1.StylePriority.UseBorderColor = False
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseForeColor = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Interest"
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
        Me.lblAccountH.SizeF = New System.Drawing.SizeF(205.0!, 35.0!)
        Me.lblAccountH.StylePriority.UseBackColor = False
        Me.lblAccountH.StylePriority.UseBorderColor = False
        Me.lblAccountH.StylePriority.UseBorders = False
        Me.lblAccountH.StylePriority.UseFont = False
        Me.lblAccountH.StylePriority.UseForeColor = False
        Me.lblAccountH.StylePriority.UseTextAlignment = False
        Me.lblAccountH.Text = "Borrower"
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
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(375.0!, 0.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(85.0!, 35.0!)
        Me.XrLabel3.StylePriority.UseBackColor = False
        Me.XrLabel3.StylePriority.UseBorderColor = False
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseForeColor = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "Principal"
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
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 0.0!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.XrPageInfo2.StylePriority.UseBackColor = False
        Me.XrPageInfo2.StylePriority.UseFont = False
        Me.XrPageInfo2.StylePriority.UseTextAlignment = False
        Me.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblBorrowerH})
        Me.GroupHeader1.HeightF = 20.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'lblBorrowerH
        '
        Me.lblBorrowerH.BackColor = System.Drawing.Color.White
        Me.lblBorrowerH.BorderColor = System.Drawing.Color.Black
        Me.lblBorrowerH.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBorrowerH.CanGrow = False
        Me.lblBorrowerH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrowerH.ForeColor = System.Drawing.Color.Black
        Me.lblBorrowerH.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblBorrowerH.Name = "lblBorrowerH"
        Me.lblBorrowerH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBorrowerH.SizeF = New System.Drawing.SizeF(800.0!, 20.0!)
        Me.lblBorrowerH.StylePriority.UseBackColor = False
        Me.lblBorrowerH.StylePriority.UseBorderColor = False
        Me.lblBorrowerH.StylePriority.UseBorders = False
        Me.lblBorrowerH.StylePriority.UseFont = False
        Me.lblBorrowerH.StylePriority.UseForeColor = False
        Me.lblBorrowerH.StylePriority.UseTextAlignment = False
        Me.lblBorrowerH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel8, Me.XrLabel9, Me.XrLabel10, Me.lblPrincipalT, Me.lblPenaltyT, Me.lblInterestT, Me.lblInterestAfterMaturityT, Me.lblTotalCollectionT})
        Me.GroupFooter1.HeightF = 20.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'XrLabel8
        '
        Me.XrLabel8.BackColor = System.Drawing.Color.White
        Me.XrLabel8.BorderColor = System.Drawing.Color.Black
        Me.XrLabel8.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel8.CanGrow = False
        Me.XrLabel8.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.ForeColor = System.Drawing.Color.Black
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(205.0!, 0.0!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.XrLabel8.StylePriority.UseBackColor = False
        Me.XrLabel8.StylePriority.UseBorderColor = False
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseForeColor = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel9
        '
        Me.XrLabel9.BackColor = System.Drawing.Color.White
        Me.XrLabel9.BorderColor = System.Drawing.Color.Black
        Me.XrLabel9.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel9.CanGrow = False
        Me.XrLabel9.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.ForeColor = System.Drawing.Color.Black
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(205.0!, 20.0!)
        Me.XrLabel9.StylePriority.UseBackColor = False
        Me.XrLabel9.StylePriority.UseBorderColor = False
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseForeColor = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel10
        '
        Me.XrLabel10.BackColor = System.Drawing.Color.White
        Me.XrLabel10.BorderColor = System.Drawing.Color.Black
        Me.XrLabel10.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel10.CanGrow = False
        Me.XrLabel10.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel10.ForeColor = System.Drawing.Color.Black
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(290.0!, 0.0!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.XrLabel10.StylePriority.UseBackColor = False
        Me.XrLabel10.StylePriority.UseBorderColor = False
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseForeColor = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblPrincipalT
        '
        Me.lblPrincipalT.BackColor = System.Drawing.Color.White
        Me.lblPrincipalT.BorderColor = System.Drawing.Color.Black
        Me.lblPrincipalT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPrincipalT.CanGrow = False
        Me.lblPrincipalT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipalT.ForeColor = System.Drawing.Color.Black
        Me.lblPrincipalT.LocationFloat = New DevExpress.Utils.PointFloat(375.0!, 0.0!)
        Me.lblPrincipalT.Name = "lblPrincipalT"
        Me.lblPrincipalT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPrincipalT.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.lblPrincipalT.StylePriority.UseBackColor = False
        Me.lblPrincipalT.StylePriority.UseBorderColor = False
        Me.lblPrincipalT.StylePriority.UseBorders = False
        Me.lblPrincipalT.StylePriority.UseFont = False
        Me.lblPrincipalT.StylePriority.UseForeColor = False
        Me.lblPrincipalT.StylePriority.UseTextAlignment = False
        XrSummary1.FormatString = "{0:n2}"
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.lblPrincipalT.Summary = XrSummary1
        Me.lblPrincipalT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPrincipalT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblPenaltyT
        '
        Me.lblPenaltyT.BackColor = System.Drawing.Color.White
        Me.lblPenaltyT.BorderColor = System.Drawing.Color.Black
        Me.lblPenaltyT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPenaltyT.CanGrow = False
        Me.lblPenaltyT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPenaltyT.ForeColor = System.Drawing.Color.Black
        Me.lblPenaltyT.LocationFloat = New DevExpress.Utils.PointFloat(545.0!, 0.0!)
        Me.lblPenaltyT.Name = "lblPenaltyT"
        Me.lblPenaltyT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPenaltyT.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.lblPenaltyT.StylePriority.UseBackColor = False
        Me.lblPenaltyT.StylePriority.UseBorderColor = False
        Me.lblPenaltyT.StylePriority.UseBorders = False
        Me.lblPenaltyT.StylePriority.UseFont = False
        Me.lblPenaltyT.StylePriority.UseForeColor = False
        Me.lblPenaltyT.StylePriority.UseTextAlignment = False
        XrSummary2.FormatString = "{0:n2}"
        XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.lblPenaltyT.Summary = XrSummary2
        Me.lblPenaltyT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblPenaltyT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblInterestT
        '
        Me.lblInterestT.BackColor = System.Drawing.Color.White
        Me.lblInterestT.BorderColor = System.Drawing.Color.Black
        Me.lblInterestT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblInterestT.CanGrow = False
        Me.lblInterestT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterestT.ForeColor = System.Drawing.Color.Black
        Me.lblInterestT.LocationFloat = New DevExpress.Utils.PointFloat(460.0!, 0.0!)
        Me.lblInterestT.Name = "lblInterestT"
        Me.lblInterestT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInterestT.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.lblInterestT.StylePriority.UseBackColor = False
        Me.lblInterestT.StylePriority.UseBorderColor = False
        Me.lblInterestT.StylePriority.UseBorders = False
        Me.lblInterestT.StylePriority.UseFont = False
        Me.lblInterestT.StylePriority.UseForeColor = False
        Me.lblInterestT.StylePriority.UseTextAlignment = False
        XrSummary3.FormatString = "{0:n2}"
        XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.lblInterestT.Summary = XrSummary3
        Me.lblInterestT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblInterestT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblInterestAfterMaturityT
        '
        Me.lblInterestAfterMaturityT.BackColor = System.Drawing.Color.White
        Me.lblInterestAfterMaturityT.BorderColor = System.Drawing.Color.Black
        Me.lblInterestAfterMaturityT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblInterestAfterMaturityT.CanGrow = False
        Me.lblInterestAfterMaturityT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterestAfterMaturityT.ForeColor = System.Drawing.Color.Black
        Me.lblInterestAfterMaturityT.LocationFloat = New DevExpress.Utils.PointFloat(630.0!, 0.0!)
        Me.lblInterestAfterMaturityT.Name = "lblInterestAfterMaturityT"
        Me.lblInterestAfterMaturityT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblInterestAfterMaturityT.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.lblInterestAfterMaturityT.StylePriority.UseBackColor = False
        Me.lblInterestAfterMaturityT.StylePriority.UseBorderColor = False
        Me.lblInterestAfterMaturityT.StylePriority.UseBorders = False
        Me.lblInterestAfterMaturityT.StylePriority.UseFont = False
        Me.lblInterestAfterMaturityT.StylePriority.UseForeColor = False
        Me.lblInterestAfterMaturityT.StylePriority.UseTextAlignment = False
        XrSummary4.FormatString = "{0:n2}"
        XrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.lblInterestAfterMaturityT.Summary = XrSummary4
        Me.lblInterestAfterMaturityT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblInterestAfterMaturityT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblTotalCollectionT
        '
        Me.lblTotalCollectionT.BackColor = System.Drawing.Color.White
        Me.lblTotalCollectionT.BorderColor = System.Drawing.Color.Black
        Me.lblTotalCollectionT.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotalCollectionT.CanGrow = False
        Me.lblTotalCollectionT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCollectionT.ForeColor = System.Drawing.Color.Black
        Me.lblTotalCollectionT.LocationFloat = New DevExpress.Utils.PointFloat(715.0!, 0.0!)
        Me.lblTotalCollectionT.Name = "lblTotalCollectionT"
        Me.lblTotalCollectionT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotalCollectionT.SizeF = New System.Drawing.SizeF(85.0!, 20.0!)
        Me.lblTotalCollectionT.StylePriority.UseBackColor = False
        Me.lblTotalCollectionT.StylePriority.UseBorderColor = False
        Me.lblTotalCollectionT.StylePriority.UseBorders = False
        Me.lblTotalCollectionT.StylePriority.UseFont = False
        Me.lblTotalCollectionT.StylePriority.UseForeColor = False
        Me.lblTotalCollectionT.StylePriority.UseTextAlignment = False
        XrSummary5.FormatString = "{0:n2}"
        XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.lblTotalCollectionT.Summary = XrSummary5
        Me.lblTotalCollectionT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblTotalCollectionT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'rptListOfCollections
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.PageHeader, Me.PageFooter, Me.GroupHeader1, Me.GroupFooter1})
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents lblFSFC As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBranch As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAsOf As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents GroupHeader1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBorrowerH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotalCollection As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInterestAfterMaturity As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInterest As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPenalty As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrincipal As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblORNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBorrower As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPostingDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPrincipalT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPenaltyT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInterestT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblInterestAfterMaturityT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTotalCollectionT As DevExpress.XtraReports.UI.XRLabel
End Class
