<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class SubRptCollectionReport
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
        Me.lblDocumentNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblIssuedTo = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCash = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCheck = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmount = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCheckNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCheckDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblLoans = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblOthers = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrLabel32 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCashT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCheckT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmountT = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblLoansT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblOthersT = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblDocumentNumber, Me.lblIssuedTo, Me.lblAccountNumber, Me.lblCash, Me.lblCheck, Me.lblAmount, Me.lblCheckNumber, Me.lblCheckDate, Me.lblLoans, Me.lblOthers})
        Me.Detail.HeightF = 20.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblDocumentNumber
        '
        Me.lblDocumentNumber.BackColor = System.Drawing.Color.White
        Me.lblDocumentNumber.BorderColor = System.Drawing.Color.Black
        Me.lblDocumentNumber.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDocumentNumber.CanGrow = False
        Me.lblDocumentNumber.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumentNumber.ForeColor = System.Drawing.Color.Red
        Me.lblDocumentNumber.LocationFloat = New DevExpress.Utils.PointFloat(0.00006103516!, 0.0!)
        Me.lblDocumentNumber.Name = "lblDocumentNumber"
        Me.lblDocumentNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDocumentNumber.SizeF = New System.Drawing.SizeF(90.0!, 20.0!)
        Me.lblDocumentNumber.StylePriority.UseBackColor = False
        Me.lblDocumentNumber.StylePriority.UseBorderColor = False
        Me.lblDocumentNumber.StylePriority.UseBorders = False
        Me.lblDocumentNumber.StylePriority.UseFont = False
        Me.lblDocumentNumber.StylePriority.UseForeColor = False
        Me.lblDocumentNumber.StylePriority.UseTextAlignment = False
        Me.lblDocumentNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblIssuedTo
        '
        Me.lblIssuedTo.BackColor = System.Drawing.Color.White
        Me.lblIssuedTo.BorderColor = System.Drawing.Color.Black
        Me.lblIssuedTo.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblIssuedTo.CanGrow = False
        Me.lblIssuedTo.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIssuedTo.ForeColor = System.Drawing.Color.Red
        Me.lblIssuedTo.LocationFloat = New DevExpress.Utils.PointFloat(90.00006!, 0.0!)
        Me.lblIssuedTo.Name = "lblIssuedTo"
        Me.lblIssuedTo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblIssuedTo.SizeF = New System.Drawing.SizeF(160.0!, 20.0!)
        Me.lblIssuedTo.StylePriority.UseBackColor = False
        Me.lblIssuedTo.StylePriority.UseBorderColor = False
        Me.lblIssuedTo.StylePriority.UseBorders = False
        Me.lblIssuedTo.StylePriority.UseFont = False
        Me.lblIssuedTo.StylePriority.UseForeColor = False
        Me.lblIssuedTo.StylePriority.UseTextAlignment = False
        Me.lblIssuedTo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblAccountNumber
        '
        Me.lblAccountNumber.BackColor = System.Drawing.Color.White
        Me.lblAccountNumber.BorderColor = System.Drawing.Color.Black
        Me.lblAccountNumber.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccountNumber.CanGrow = False
        Me.lblAccountNumber.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountNumber.ForeColor = System.Drawing.Color.Red
        Me.lblAccountNumber.LocationFloat = New DevExpress.Utils.PointFloat(250.0001!, 0.0!)
        Me.lblAccountNumber.Name = "lblAccountNumber"
        Me.lblAccountNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountNumber.SizeF = New System.Drawing.SizeF(90.0!, 20.0!)
        Me.lblAccountNumber.StylePriority.UseBackColor = False
        Me.lblAccountNumber.StylePriority.UseBorderColor = False
        Me.lblAccountNumber.StylePriority.UseBorders = False
        Me.lblAccountNumber.StylePriority.UseFont = False
        Me.lblAccountNumber.StylePriority.UseForeColor = False
        Me.lblAccountNumber.StylePriority.UseTextAlignment = False
        Me.lblAccountNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCash
        '
        Me.lblCash.BackColor = System.Drawing.Color.White
        Me.lblCash.BorderColor = System.Drawing.Color.Black
        Me.lblCash.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCash.CanGrow = False
        Me.lblCash.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCash.ForeColor = System.Drawing.Color.Red
        Me.lblCash.LocationFloat = New DevExpress.Utils.PointFloat(340.0001!, 0.0!)
        Me.lblCash.Name = "lblCash"
        Me.lblCash.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCash.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.lblCash.StylePriority.UseBackColor = False
        Me.lblCash.StylePriority.UseBorderColor = False
        Me.lblCash.StylePriority.UseBorders = False
        Me.lblCash.StylePriority.UseFont = False
        Me.lblCash.StylePriority.UseForeColor = False
        Me.lblCash.StylePriority.UseTextAlignment = False
        Me.lblCash.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblCash.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblCheck
        '
        Me.lblCheck.BackColor = System.Drawing.Color.White
        Me.lblCheck.BorderColor = System.Drawing.Color.Black
        Me.lblCheck.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCheck.CanGrow = False
        Me.lblCheck.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheck.ForeColor = System.Drawing.Color.Red
        Me.lblCheck.LocationFloat = New DevExpress.Utils.PointFloat(400.0001!, 0.0!)
        Me.lblCheck.Name = "lblCheck"
        Me.lblCheck.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCheck.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.lblCheck.StylePriority.UseBackColor = False
        Me.lblCheck.StylePriority.UseBorderColor = False
        Me.lblCheck.StylePriority.UseBorders = False
        Me.lblCheck.StylePriority.UseFont = False
        Me.lblCheck.StylePriority.UseForeColor = False
        Me.lblCheck.StylePriority.UseTextAlignment = False
        Me.lblCheck.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblCheck.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblAmount
        '
        Me.lblAmount.BackColor = System.Drawing.Color.White
        Me.lblAmount.BorderColor = System.Drawing.Color.Black
        Me.lblAmount.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmount.CanGrow = False
        Me.lblAmount.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.ForeColor = System.Drawing.Color.Red
        Me.lblAmount.LocationFloat = New DevExpress.Utils.PointFloat(460.0001!, 0.0!)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.lblAmount.StylePriority.UseBackColor = False
        Me.lblAmount.StylePriority.UseBorderColor = False
        Me.lblAmount.StylePriority.UseBorders = False
        Me.lblAmount.StylePriority.UseFont = False
        Me.lblAmount.StylePriority.UseForeColor = False
        Me.lblAmount.StylePriority.UseTextAlignment = False
        Me.lblAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmount.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblCheckNumber
        '
        Me.lblCheckNumber.BackColor = System.Drawing.Color.White
        Me.lblCheckNumber.BorderColor = System.Drawing.Color.Black
        Me.lblCheckNumber.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCheckNumber.CanGrow = False
        Me.lblCheckNumber.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckNumber.ForeColor = System.Drawing.Color.Red
        Me.lblCheckNumber.LocationFloat = New DevExpress.Utils.PointFloat(520.0001!, 0.0!)
        Me.lblCheckNumber.Name = "lblCheckNumber"
        Me.lblCheckNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCheckNumber.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.lblCheckNumber.StylePriority.UseBackColor = False
        Me.lblCheckNumber.StylePriority.UseBorderColor = False
        Me.lblCheckNumber.StylePriority.UseBorders = False
        Me.lblCheckNumber.StylePriority.UseFont = False
        Me.lblCheckNumber.StylePriority.UseForeColor = False
        Me.lblCheckNumber.StylePriority.UseTextAlignment = False
        Me.lblCheckNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCheckDate
        '
        Me.lblCheckDate.BackColor = System.Drawing.Color.White
        Me.lblCheckDate.BorderColor = System.Drawing.Color.Black
        Me.lblCheckDate.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCheckDate.CanGrow = False
        Me.lblCheckDate.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckDate.ForeColor = System.Drawing.Color.Red
        Me.lblCheckDate.LocationFloat = New DevExpress.Utils.PointFloat(599.9999!, 0.0!)
        Me.lblCheckDate.Name = "lblCheckDate"
        Me.lblCheckDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCheckDate.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.lblCheckDate.StylePriority.UseBackColor = False
        Me.lblCheckDate.StylePriority.UseBorderColor = False
        Me.lblCheckDate.StylePriority.UseBorders = False
        Me.lblCheckDate.StylePriority.UseFont = False
        Me.lblCheckDate.StylePriority.UseForeColor = False
        Me.lblCheckDate.StylePriority.UseTextAlignment = False
        Me.lblCheckDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblCheckDate.XlsxFormatString = "mm/dd/yyyy"
        '
        'lblLoans
        '
        Me.lblLoans.BackColor = System.Drawing.Color.White
        Me.lblLoans.BorderColor = System.Drawing.Color.Black
        Me.lblLoans.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblLoans.CanGrow = False
        Me.lblLoans.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoans.ForeColor = System.Drawing.Color.Red
        Me.lblLoans.LocationFloat = New DevExpress.Utils.PointFloat(679.9999!, 0.0!)
        Me.lblLoans.Name = "lblLoans"
        Me.lblLoans.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblLoans.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.lblLoans.StylePriority.UseBackColor = False
        Me.lblLoans.StylePriority.UseBorderColor = False
        Me.lblLoans.StylePriority.UseBorders = False
        Me.lblLoans.StylePriority.UseFont = False
        Me.lblLoans.StylePriority.UseForeColor = False
        Me.lblLoans.StylePriority.UseTextAlignment = False
        Me.lblLoans.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblLoans.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblOthers
        '
        Me.lblOthers.BackColor = System.Drawing.Color.White
        Me.lblOthers.BorderColor = System.Drawing.Color.Black
        Me.lblOthers.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblOthers.CanGrow = False
        Me.lblOthers.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOthers.ForeColor = System.Drawing.Color.Red
        Me.lblOthers.LocationFloat = New DevExpress.Utils.PointFloat(739.9999!, 0.0!)
        Me.lblOthers.Name = "lblOthers"
        Me.lblOthers.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblOthers.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.lblOthers.StylePriority.UseBackColor = False
        Me.lblOthers.StylePriority.UseBorderColor = False
        Me.lblOthers.StylePriority.UseBorders = False
        Me.lblOthers.StylePriority.UseFont = False
        Me.lblOthers.StylePriority.UseForeColor = False
        Me.lblOthers.StylePriority.UseTextAlignment = False
        Me.lblOthers.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblOthers.XlsxFormatString = "#,##0.00_);(#,##0.00)"
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
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel32, Me.lblCashT, Me.lblCheckT, Me.lblAmountT, Me.XrLabel20, Me.lblLoansT, Me.lblOthersT})
        Me.ReportFooter.HeightF = 20.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrLabel32
        '
        Me.XrLabel32.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel32.BorderColor = System.Drawing.Color.Black
        Me.XrLabel32.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel32.CanGrow = False
        Me.XrLabel32.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel32.ForeColor = System.Drawing.Color.White
        Me.XrLabel32.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel32.Name = "XrLabel32"
        Me.XrLabel32.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel32.SizeF = New System.Drawing.SizeF(340.0!, 20.0!)
        Me.XrLabel32.StylePriority.UseBackColor = False
        Me.XrLabel32.StylePriority.UseBorderColor = False
        Me.XrLabel32.StylePriority.UseBorders = False
        Me.XrLabel32.StylePriority.UseFont = False
        Me.XrLabel32.StylePriority.UseForeColor = False
        Me.XrLabel32.StylePriority.UseTextAlignment = False
        Me.XrLabel32.Text = "T O T A L   C A N C E L L E D"
        Me.XrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblCashT
        '
        Me.lblCashT.BackColor = System.Drawing.Color.White
        Me.lblCashT.BorderColor = System.Drawing.Color.Black
        Me.lblCashT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCashT.CanGrow = False
        Me.lblCashT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCashT.ForeColor = System.Drawing.Color.Red
        Me.lblCashT.LocationFloat = New DevExpress.Utils.PointFloat(340.0!, 0.0!)
        Me.lblCashT.Name = "lblCashT"
        Me.lblCashT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCashT.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.lblCashT.StylePriority.UseBackColor = False
        Me.lblCashT.StylePriority.UseBorderColor = False
        Me.lblCashT.StylePriority.UseBorders = False
        Me.lblCashT.StylePriority.UseFont = False
        Me.lblCashT.StylePriority.UseForeColor = False
        Me.lblCashT.StylePriority.UseTextAlignment = False
        Me.lblCashT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblCashT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblCheckT
        '
        Me.lblCheckT.BackColor = System.Drawing.Color.White
        Me.lblCheckT.BorderColor = System.Drawing.Color.Black
        Me.lblCheckT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCheckT.CanGrow = False
        Me.lblCheckT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckT.ForeColor = System.Drawing.Color.Red
        Me.lblCheckT.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 0.0!)
        Me.lblCheckT.Name = "lblCheckT"
        Me.lblCheckT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCheckT.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.lblCheckT.StylePriority.UseBackColor = False
        Me.lblCheckT.StylePriority.UseBorderColor = False
        Me.lblCheckT.StylePriority.UseBorders = False
        Me.lblCheckT.StylePriority.UseFont = False
        Me.lblCheckT.StylePriority.UseForeColor = False
        Me.lblCheckT.StylePriority.UseTextAlignment = False
        Me.lblCheckT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblCheckT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblAmountT
        '
        Me.lblAmountT.BackColor = System.Drawing.Color.White
        Me.lblAmountT.BorderColor = System.Drawing.Color.Black
        Me.lblAmountT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmountT.CanGrow = False
        Me.lblAmountT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmountT.ForeColor = System.Drawing.Color.Red
        Me.lblAmountT.LocationFloat = New DevExpress.Utils.PointFloat(460.0!, 0.0!)
        Me.lblAmountT.Name = "lblAmountT"
        Me.lblAmountT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmountT.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.lblAmountT.StylePriority.UseBackColor = False
        Me.lblAmountT.StylePriority.UseBorderColor = False
        Me.lblAmountT.StylePriority.UseBorders = False
        Me.lblAmountT.StylePriority.UseFont = False
        Me.lblAmountT.StylePriority.UseForeColor = False
        Me.lblAmountT.StylePriority.UseTextAlignment = False
        Me.lblAmountT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmountT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel20
        '
        Me.XrLabel20.BackColor = System.Drawing.Color.White
        Me.XrLabel20.BorderColor = System.Drawing.Color.Black
        Me.XrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.Left
        Me.XrLabel20.CanGrow = False
        Me.XrLabel20.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel20.ForeColor = System.Drawing.Color.Red
        Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(520.0!, 0.0!)
        Me.XrLabel20.Name = "XrLabel20"
        Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel20.SizeF = New System.Drawing.SizeF(159.9999!, 20.0!)
        Me.XrLabel20.StylePriority.UseBackColor = False
        Me.XrLabel20.StylePriority.UseBorderColor = False
        Me.XrLabel20.StylePriority.UseBorders = False
        Me.XrLabel20.StylePriority.UseFont = False
        Me.XrLabel20.StylePriority.UseForeColor = False
        Me.XrLabel20.StylePriority.UseTextAlignment = False
        Me.XrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblLoansT
        '
        Me.lblLoansT.BackColor = System.Drawing.Color.White
        Me.lblLoansT.BorderColor = System.Drawing.Color.Black
        Me.lblLoansT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblLoansT.CanGrow = False
        Me.lblLoansT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoansT.ForeColor = System.Drawing.Color.Red
        Me.lblLoansT.LocationFloat = New DevExpress.Utils.PointFloat(679.9999!, 0.0!)
        Me.lblLoansT.Name = "lblLoansT"
        Me.lblLoansT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblLoansT.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.lblLoansT.StylePriority.UseBackColor = False
        Me.lblLoansT.StylePriority.UseBorderColor = False
        Me.lblLoansT.StylePriority.UseBorders = False
        Me.lblLoansT.StylePriority.UseFont = False
        Me.lblLoansT.StylePriority.UseForeColor = False
        Me.lblLoansT.StylePriority.UseTextAlignment = False
        Me.lblLoansT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblLoansT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblOthersT
        '
        Me.lblOthersT.BackColor = System.Drawing.Color.White
        Me.lblOthersT.BorderColor = System.Drawing.Color.Black
        Me.lblOthersT.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblOthersT.CanGrow = False
        Me.lblOthersT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOthersT.ForeColor = System.Drawing.Color.Red
        Me.lblOthersT.LocationFloat = New DevExpress.Utils.PointFloat(740.0!, 0.0!)
        Me.lblOthersT.Name = "lblOthersT"
        Me.lblOthersT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblOthersT.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.lblOthersT.StylePriority.UseBackColor = False
        Me.lblOthersT.StylePriority.UseBorderColor = False
        Me.lblOthersT.StylePriority.UseBorders = False
        Me.lblOthersT.StylePriority.UseFont = False
        Me.lblOthersT.StylePriority.UseForeColor = False
        Me.lblOthersT.StylePriority.UseTextAlignment = False
        Me.lblOthersT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblOthersT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1, Me.XrLabel2, Me.XrLabel3, Me.XrLabel4, Me.XrLabel5, Me.XrLabel6, Me.XrLabel7, Me.XrLabel8, Me.XrLabel9, Me.XrLabel10})
        Me.ReportHeader.HeightF = 20.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrLabel1
        '
        Me.XrLabel1.BackColor = System.Drawing.Color.White
        Me.XrLabel1.BorderColor = System.Drawing.Color.Black
        Me.XrLabel1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel1.CanGrow = False
        Me.XrLabel1.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.ForeColor = System.Drawing.Color.Black
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(739.9999!, 0.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.XrLabel1.StylePriority.UseBackColor = False
        Me.XrLabel1.StylePriority.UseBorderColor = False
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseForeColor = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrLabel1.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel2
        '
        Me.XrLabel2.BackColor = System.Drawing.Color.White
        Me.XrLabel2.BorderColor = System.Drawing.Color.Black
        Me.XrLabel2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel2.CanGrow = False
        Me.XrLabel2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.ForeColor = System.Drawing.Color.Black
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(679.9999!, 0.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.XrLabel2.StylePriority.UseBackColor = False
        Me.XrLabel2.StylePriority.UseBorderColor = False
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseForeColor = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrLabel2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel3
        '
        Me.XrLabel3.BackColor = System.Drawing.Color.White
        Me.XrLabel3.BorderColor = System.Drawing.Color.Black
        Me.XrLabel3.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel3.CanGrow = False
        Me.XrLabel3.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.ForeColor = System.Drawing.Color.Black
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(599.9999!, 0.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.XrLabel3.StylePriority.UseBackColor = False
        Me.XrLabel3.StylePriority.UseBorderColor = False
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseForeColor = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.XrLabel3.XlsxFormatString = "mm/dd/yyyy"
        '
        'XrLabel4
        '
        Me.XrLabel4.BackColor = System.Drawing.Color.White
        Me.XrLabel4.BorderColor = System.Drawing.Color.Black
        Me.XrLabel4.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel4.CanGrow = False
        Me.XrLabel4.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.ForeColor = System.Drawing.Color.Black
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(520.0001!, 0.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.XrLabel4.StylePriority.UseBackColor = False
        Me.XrLabel4.StylePriority.UseBorderColor = False
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseForeColor = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel5
        '
        Me.XrLabel5.BackColor = System.Drawing.Color.White
        Me.XrLabel5.BorderColor = System.Drawing.Color.Black
        Me.XrLabel5.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel5.CanGrow = False
        Me.XrLabel5.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.ForeColor = System.Drawing.Color.Black
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(460.0001!, 0.0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.XrLabel5.StylePriority.UseBackColor = False
        Me.XrLabel5.StylePriority.UseBorderColor = False
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseForeColor = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrLabel5.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel6
        '
        Me.XrLabel6.BackColor = System.Drawing.Color.White
        Me.XrLabel6.BorderColor = System.Drawing.Color.Black
        Me.XrLabel6.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel6.CanGrow = False
        Me.XrLabel6.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.ForeColor = System.Drawing.Color.Black
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(400.0001!, 0.0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.XrLabel6.StylePriority.UseBackColor = False
        Me.XrLabel6.StylePriority.UseBorderColor = False
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseForeColor = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrLabel6.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel7
        '
        Me.XrLabel7.BackColor = System.Drawing.Color.White
        Me.XrLabel7.BorderColor = System.Drawing.Color.Black
        Me.XrLabel7.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel7.CanGrow = False
        Me.XrLabel7.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.ForeColor = System.Drawing.Color.Black
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(340.0001!, 0.0!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.XrLabel7.StylePriority.UseBackColor = False
        Me.XrLabel7.StylePriority.UseBorderColor = False
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseForeColor = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrLabel7.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel8
        '
        Me.XrLabel8.BackColor = System.Drawing.Color.White
        Me.XrLabel8.BorderColor = System.Drawing.Color.Black
        Me.XrLabel8.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel8.CanGrow = False
        Me.XrLabel8.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.ForeColor = System.Drawing.Color.Black
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(250.0001!, 0.0!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(90.0!, 20.0!)
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
        Me.XrLabel9.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.ForeColor = System.Drawing.Color.Black
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(90.00009!, 0.0!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(160.0!, 20.0!)
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
        Me.XrLabel10.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel10.ForeColor = System.Drawing.Color.Black
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(0.00009155273!, 0.0!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(90.0!, 20.0!)
        Me.XrLabel10.StylePriority.UseBackColor = False
        Me.XrLabel10.StylePriority.UseBorderColor = False
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseForeColor = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'subRptCollectionReport
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportFooter, Me.ReportHeader})
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents lblDocumentNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblIssuedTo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCash As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCheck As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCheckNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCheckDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblLoans As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblOthers As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrLabel32 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCashT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCheckT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmountT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblLoansT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblOthersT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
End Class
