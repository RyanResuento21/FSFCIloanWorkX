<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptDealerProfile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptDealerProfile))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFaxNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblWebsite = New DevExpress.XtraReports.UI.XRLabel()
        Me.cbxCar = New DevExpress.XtraReports.UI.XRCheckBox()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTradeN = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel33 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel26 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel35 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMobile = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel28 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel30 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTelephone = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTIN = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblSSS = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblEmail = New DevExpress.XtraReports.UI.XRLabel()
        Me.p_Borrower = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.lblCompleteAdd = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBorrowerID = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBorrower = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo2, Me.XrLabel11, Me.lblFaxNo, Me.XrLabel9, Me.lblWebsite, Me.cbxCar, Me.XrLabel7, Me.lblTradeN, Me.XrLabel33, Me.XrLabel26, Me.XrLabel35, Me.lblMobile, Me.XrLabel28, Me.XrLabel30, Me.lblTelephone, Me.lblTIN, Me.lblSSS, Me.lblEmail, Me.p_Borrower, Me.lblCompleteAdd, Me.XrLabel14, Me.XrLabel4, Me.XrLabel6, Me.lblBorrowerID, Me.lblBorrower, Me.XrLabel3, Me.XrLabel2, Me.XrLabel1, Me.XrPictureBox1})
        Me.Detail.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.Detail.HeightF = 1000.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.StylePriority.UseFont = False
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.BackColor = System.Drawing.Color.White
        Me.XrPageInfo2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo2.Format = "{0:dddd, MMMM d, yyyy h:mm tt}"
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(392.6297!, 980.0!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.XrPageInfo2.StylePriority.UseBackColor = False
        Me.XrPageInfo2.StylePriority.UseFont = False
        Me.XrPageInfo2.StylePriority.UseTextAlignment = False
        Me.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel11
        '
        Me.XrLabel11.BackColor = System.Drawing.Color.White
        Me.XrLabel11.BorderColor = System.Drawing.Color.Black
        Me.XrLabel11.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel11.CanGrow = False
        Me.XrLabel11.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel11.ForeColor = System.Drawing.Color.Black
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(310.0!, 165.0!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(90.0!, 15.0!)
        Me.XrLabel11.StylePriority.UseBackColor = False
        Me.XrLabel11.StylePriority.UseBorderColor = False
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseForeColor = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = "Fax No. :"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblFaxNo
        '
        Me.lblFaxNo.BackColor = System.Drawing.Color.White
        Me.lblFaxNo.BorderColor = System.Drawing.Color.Black
        Me.lblFaxNo.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFaxNo.CanGrow = False
        Me.lblFaxNo.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFaxNo.ForeColor = System.Drawing.Color.Black
        Me.lblFaxNo.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 165.0!)
        Me.lblFaxNo.Name = "lblFaxNo"
        Me.lblFaxNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFaxNo.SizeF = New System.Drawing.SizeF(220.0!, 15.0!)
        Me.lblFaxNo.StylePriority.UseBackColor = False
        Me.lblFaxNo.StylePriority.UseBorderColor = False
        Me.lblFaxNo.StylePriority.UseBorders = False
        Me.lblFaxNo.StylePriority.UseFont = False
        Me.lblFaxNo.StylePriority.UseForeColor = False
        Me.lblFaxNo.StylePriority.UseTextAlignment = False
        Me.lblFaxNo.Text = "123-456789"
        Me.lblFaxNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel9
        '
        Me.XrLabel9.BackColor = System.Drawing.Color.White
        Me.XrLabel9.BorderColor = System.Drawing.Color.Black
        Me.XrLabel9.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel9.CanGrow = False
        Me.XrLabel9.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.ForeColor = System.Drawing.Color.Black
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 180.0!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(110.0!, 15.0!)
        Me.XrLabel9.StylePriority.UseBackColor = False
        Me.XrLabel9.StylePriority.UseBorderColor = False
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseForeColor = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = "Website :"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblWebsite
        '
        Me.lblWebsite.BackColor = System.Drawing.Color.White
        Me.lblWebsite.BorderColor = System.Drawing.Color.Black
        Me.lblWebsite.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblWebsite.CanGrow = False
        Me.lblWebsite.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWebsite.ForeColor = System.Drawing.Color.Black
        Me.lblWebsite.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 180.0!)
        Me.lblWebsite.Name = "lblWebsite"
        Me.lblWebsite.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblWebsite.SizeF = New System.Drawing.SizeF(500.0!, 15.0!)
        Me.lblWebsite.StylePriority.UseBackColor = False
        Me.lblWebsite.StylePriority.UseBorderColor = False
        Me.lblWebsite.StylePriority.UseBorders = False
        Me.lblWebsite.StylePriority.UseFont = False
        Me.lblWebsite.StylePriority.UseForeColor = False
        Me.lblWebsite.StylePriority.UseTextAlignment = False
        Me.lblWebsite.Text = "google.com"
        Me.lblWebsite.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'cbxCar
        '
        Me.cbxCar.BackColor = System.Drawing.Color.White
        Me.cbxCar.BorderColor = System.Drawing.Color.Black
        Me.cbxCar.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.cbxCar.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCar.ForeColor = System.Drawing.Color.Black
        Me.cbxCar.LocationFloat = New DevExpress.Utils.PointFloat(515.0!, 105.0!)
        Me.cbxCar.Name = "cbxCar"
        Me.cbxCar.SizeF = New System.Drawing.SizeF(105.0!, 15.0!)
        Me.cbxCar.StylePriority.UseBackColor = False
        Me.cbxCar.StylePriority.UseBorderColor = False
        Me.cbxCar.StylePriority.UseBorders = False
        Me.cbxCar.StylePriority.UseFont = False
        Me.cbxCar.StylePriority.UseForeColor = False
        Me.cbxCar.Text = "Car Dealer"
        '
        'XrLabel7
        '
        Me.XrLabel7.BackColor = System.Drawing.Color.White
        Me.XrLabel7.BorderColor = System.Drawing.Color.Black
        Me.XrLabel7.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel7.CanGrow = False
        Me.XrLabel7.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.ForeColor = System.Drawing.Color.Black
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 105.0!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(110.0!, 15.0!)
        Me.XrLabel7.StylePriority.UseBackColor = False
        Me.XrLabel7.StylePriority.UseBorderColor = False
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseForeColor = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "Trade Name :"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblTradeN
        '
        Me.lblTradeN.BackColor = System.Drawing.Color.White
        Me.lblTradeN.BorderColor = System.Drawing.Color.Black
        Me.lblTradeN.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTradeN.CanGrow = False
        Me.lblTradeN.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTradeN.ForeColor = System.Drawing.Color.Black
        Me.lblTradeN.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 105.0!)
        Me.lblTradeN.Name = "lblTradeN"
        Me.lblTradeN.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTradeN.SizeF = New System.Drawing.SizeF(395.0!, 15.0!)
        Me.lblTradeN.StylePriority.UseBackColor = False
        Me.lblTradeN.StylePriority.UseBorderColor = False
        Me.lblTradeN.StylePriority.UseBorders = False
        Me.lblTradeN.StylePriority.UseFont = False
        Me.lblTradeN.StylePriority.UseForeColor = False
        Me.lblTradeN.StylePriority.UseTextAlignment = False
        Me.lblTradeN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel33
        '
        Me.XrLabel33.BackColor = System.Drawing.Color.White
        Me.XrLabel33.BorderColor = System.Drawing.Color.Black
        Me.XrLabel33.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel33.CanGrow = False
        Me.XrLabel33.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel33.ForeColor = System.Drawing.Color.Black
        Me.XrLabel33.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 150.0!)
        Me.XrLabel33.Name = "XrLabel33"
        Me.XrLabel33.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel33.SizeF = New System.Drawing.SizeF(110.0!, 15.0!)
        Me.XrLabel33.StylePriority.UseBackColor = False
        Me.XrLabel33.StylePriority.UseBorderColor = False
        Me.XrLabel33.StylePriority.UseBorders = False
        Me.XrLabel33.StylePriority.UseFont = False
        Me.XrLabel33.StylePriority.UseForeColor = False
        Me.XrLabel33.StylePriority.UseTextAlignment = False
        Me.XrLabel33.Text = "Mobile No. :"
        Me.XrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel26
        '
        Me.XrLabel26.BackColor = System.Drawing.Color.White
        Me.XrLabel26.BorderColor = System.Drawing.Color.Black
        Me.XrLabel26.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel26.CanGrow = False
        Me.XrLabel26.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel26.ForeColor = System.Drawing.Color.Black
        Me.XrLabel26.LocationFloat = New DevExpress.Utils.PointFloat(310.0!, 135.0!)
        Me.XrLabel26.Name = "XrLabel26"
        Me.XrLabel26.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel26.SizeF = New System.Drawing.SizeF(90.0!, 15.0!)
        Me.XrLabel26.StylePriority.UseBackColor = False
        Me.XrLabel26.StylePriority.UseBorderColor = False
        Me.XrLabel26.StylePriority.UseBorders = False
        Me.XrLabel26.StylePriority.UseFont = False
        Me.XrLabel26.StylePriority.UseForeColor = False
        Me.XrLabel26.StylePriority.UseTextAlignment = False
        Me.XrLabel26.Text = "TIN No. :"
        Me.XrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel35
        '
        Me.XrLabel35.BackColor = System.Drawing.Color.White
        Me.XrLabel35.BorderColor = System.Drawing.Color.Black
        Me.XrLabel35.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel35.CanGrow = False
        Me.XrLabel35.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel35.ForeColor = System.Drawing.Color.Black
        Me.XrLabel35.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 165.0!)
        Me.XrLabel35.Name = "XrLabel35"
        Me.XrLabel35.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel35.SizeF = New System.Drawing.SizeF(110.0!, 15.0!)
        Me.XrLabel35.StylePriority.UseBackColor = False
        Me.XrLabel35.StylePriority.UseBorderColor = False
        Me.XrLabel35.StylePriority.UseBorders = False
        Me.XrLabel35.StylePriority.UseFont = False
        Me.XrLabel35.StylePriority.UseForeColor = False
        Me.XrLabel35.StylePriority.UseTextAlignment = False
        Me.XrLabel35.Text = "Email :"
        Me.XrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblMobile
        '
        Me.lblMobile.BackColor = System.Drawing.Color.White
        Me.lblMobile.BorderColor = System.Drawing.Color.Black
        Me.lblMobile.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMobile.CanGrow = False
        Me.lblMobile.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMobile.ForeColor = System.Drawing.Color.Black
        Me.lblMobile.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 150.0!)
        Me.lblMobile.Name = "lblMobile"
        Me.lblMobile.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMobile.SizeF = New System.Drawing.SizeF(190.0!, 15.0!)
        Me.lblMobile.StylePriority.UseBackColor = False
        Me.lblMobile.StylePriority.UseBorderColor = False
        Me.lblMobile.StylePriority.UseBorders = False
        Me.lblMobile.StylePriority.UseFont = False
        Me.lblMobile.StylePriority.UseForeColor = False
        Me.lblMobile.StylePriority.UseTextAlignment = False
        Me.lblMobile.Text = "0912-34567890"
        Me.lblMobile.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel28
        '
        Me.XrLabel28.BackColor = System.Drawing.Color.White
        Me.XrLabel28.BorderColor = System.Drawing.Color.Black
        Me.XrLabel28.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel28.CanGrow = False
        Me.XrLabel28.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel28.ForeColor = System.Drawing.Color.Black
        Me.XrLabel28.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 135.0!)
        Me.XrLabel28.Name = "XrLabel28"
        Me.XrLabel28.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel28.SizeF = New System.Drawing.SizeF(110.0!, 15.0!)
        Me.XrLabel28.StylePriority.UseBackColor = False
        Me.XrLabel28.StylePriority.UseBorderColor = False
        Me.XrLabel28.StylePriority.UseBorders = False
        Me.XrLabel28.StylePriority.UseFont = False
        Me.XrLabel28.StylePriority.UseForeColor = False
        Me.XrLabel28.StylePriority.UseTextAlignment = False
        Me.XrLabel28.Text = "Telephone No. :"
        Me.XrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel30
        '
        Me.XrLabel30.BackColor = System.Drawing.Color.White
        Me.XrLabel30.BorderColor = System.Drawing.Color.Black
        Me.XrLabel30.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel30.CanGrow = False
        Me.XrLabel30.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel30.ForeColor = System.Drawing.Color.Black
        Me.XrLabel30.LocationFloat = New DevExpress.Utils.PointFloat(310.0!, 150.0!)
        Me.XrLabel30.Name = "XrLabel30"
        Me.XrLabel30.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel30.SizeF = New System.Drawing.SizeF(90.0!, 15.0!)
        Me.XrLabel30.StylePriority.UseBackColor = False
        Me.XrLabel30.StylePriority.UseBorderColor = False
        Me.XrLabel30.StylePriority.UseBorders = False
        Me.XrLabel30.StylePriority.UseFont = False
        Me.XrLabel30.StylePriority.UseForeColor = False
        Me.XrLabel30.StylePriority.UseTextAlignment = False
        Me.XrLabel30.Text = "SSS No. :"
        Me.XrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblTelephone
        '
        Me.lblTelephone.BackColor = System.Drawing.Color.White
        Me.lblTelephone.BorderColor = System.Drawing.Color.Black
        Me.lblTelephone.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTelephone.CanGrow = False
        Me.lblTelephone.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelephone.ForeColor = System.Drawing.Color.Black
        Me.lblTelephone.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 135.0!)
        Me.lblTelephone.Name = "lblTelephone"
        Me.lblTelephone.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTelephone.SizeF = New System.Drawing.SizeF(190.0!, 15.0!)
        Me.lblTelephone.StylePriority.UseBackColor = False
        Me.lblTelephone.StylePriority.UseBorderColor = False
        Me.lblTelephone.StylePriority.UseBorders = False
        Me.lblTelephone.StylePriority.UseFont = False
        Me.lblTelephone.StylePriority.UseForeColor = False
        Me.lblTelephone.StylePriority.UseTextAlignment = False
        Me.lblTelephone.Text = "123-456789"
        Me.lblTelephone.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblTIN
        '
        Me.lblTIN.BackColor = System.Drawing.Color.White
        Me.lblTIN.BorderColor = System.Drawing.Color.Black
        Me.lblTIN.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTIN.CanGrow = False
        Me.lblTIN.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTIN.ForeColor = System.Drawing.Color.Black
        Me.lblTIN.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 135.0!)
        Me.lblTIN.Name = "lblTIN"
        Me.lblTIN.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTIN.SizeF = New System.Drawing.SizeF(220.0!, 15.0!)
        Me.lblTIN.StylePriority.UseBackColor = False
        Me.lblTIN.StylePriority.UseBorderColor = False
        Me.lblTIN.StylePriority.UseBorders = False
        Me.lblTIN.StylePriority.UseFont = False
        Me.lblTIN.StylePriority.UseForeColor = False
        Me.lblTIN.StylePriority.UseTextAlignment = False
        Me.lblTIN.Text = "123-456789"
        Me.lblTIN.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblSSS
        '
        Me.lblSSS.BackColor = System.Drawing.Color.White
        Me.lblSSS.BorderColor = System.Drawing.Color.Black
        Me.lblSSS.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblSSS.CanGrow = False
        Me.lblSSS.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSSS.ForeColor = System.Drawing.Color.Black
        Me.lblSSS.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 150.0!)
        Me.lblSSS.Name = "lblSSS"
        Me.lblSSS.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblSSS.SizeF = New System.Drawing.SizeF(220.0!, 15.0!)
        Me.lblSSS.StylePriority.UseBackColor = False
        Me.lblSSS.StylePriority.UseBorderColor = False
        Me.lblSSS.StylePriority.UseBorders = False
        Me.lblSSS.StylePriority.UseFont = False
        Me.lblSSS.StylePriority.UseForeColor = False
        Me.lblSSS.StylePriority.UseTextAlignment = False
        Me.lblSSS.Text = "123-456789"
        Me.lblSSS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblEmail
        '
        Me.lblEmail.BackColor = System.Drawing.Color.White
        Me.lblEmail.BorderColor = System.Drawing.Color.Black
        Me.lblEmail.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblEmail.CanGrow = False
        Me.lblEmail.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.Color.Black
        Me.lblEmail.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 165.0!)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblEmail.SizeF = New System.Drawing.SizeF(190.0!, 15.0!)
        Me.lblEmail.StylePriority.UseBackColor = False
        Me.lblEmail.StylePriority.UseBorderColor = False
        Me.lblEmail.StylePriority.UseBorders = False
        Me.lblEmail.StylePriority.UseFont = False
        Me.lblEmail.StylePriority.UseForeColor = False
        Me.lblEmail.StylePriority.UseTextAlignment = False
        Me.lblEmail.Text = "mkevgotico@gmail.com / mgotico@ymail.com"
        Me.lblEmail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'p_Borrower
        '
        Me.p_Borrower.BackColor = System.Drawing.Color.White
        Me.p_Borrower.BorderColor = System.Drawing.Color.Black
        Me.p_Borrower.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.p_Borrower.Image = CType(resources.GetObject("p_Borrower.Image"), System.Drawing.Image)
        Me.p_Borrower.LocationFloat = New DevExpress.Utils.PointFloat(620.0!, 60.0!)
        Me.p_Borrower.Name = "p_Borrower"
        Me.p_Borrower.SizeF = New System.Drawing.SizeF(170.0!, 135.0!)
        Me.p_Borrower.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        Me.p_Borrower.StylePriority.UseBackColor = False
        Me.p_Borrower.StylePriority.UseBorderColor = False
        Me.p_Borrower.StylePriority.UseBorders = False
        '
        'lblCompleteAdd
        '
        Me.lblCompleteAdd.BackColor = System.Drawing.Color.White
        Me.lblCompleteAdd.BorderColor = System.Drawing.Color.Black
        Me.lblCompleteAdd.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCompleteAdd.CanGrow = False
        Me.lblCompleteAdd.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompleteAdd.ForeColor = System.Drawing.Color.Black
        Me.lblCompleteAdd.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 120.0!)
        Me.lblCompleteAdd.Name = "lblCompleteAdd"
        Me.lblCompleteAdd.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCompleteAdd.SizeF = New System.Drawing.SizeF(500.0!, 15.0!)
        Me.lblCompleteAdd.StylePriority.UseBackColor = False
        Me.lblCompleteAdd.StylePriority.UseBorderColor = False
        Me.lblCompleteAdd.StylePriority.UseBorders = False
        Me.lblCompleteAdd.StylePriority.UseFont = False
        Me.lblCompleteAdd.StylePriority.UseForeColor = False
        Me.lblCompleteAdd.StylePriority.UseTextAlignment = False
        Me.lblCompleteAdd.Text = "Kingswood Village, Upper Lipata, Minglanilla, Cebu City"
        Me.lblCompleteAdd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel14
        '
        Me.XrLabel14.BackColor = System.Drawing.Color.White
        Me.XrLabel14.BorderColor = System.Drawing.Color.Black
        Me.XrLabel14.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel14.CanGrow = False
        Me.XrLabel14.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel14.ForeColor = System.Drawing.Color.Black
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 120.0!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(110.0!, 15.0!)
        Me.XrLabel14.StylePriority.UseBackColor = False
        Me.XrLabel14.StylePriority.UseBorderColor = False
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.StylePriority.UseForeColor = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = "Complete Address :"
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel4
        '
        Me.XrLabel4.BackColor = System.Drawing.Color.White
        Me.XrLabel4.BorderColor = System.Drawing.Color.Black
        Me.XrLabel4.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel4.CanGrow = False
        Me.XrLabel4.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.ForeColor = System.Drawing.Color.Black
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 75.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(110.0!, 15.0!)
        Me.XrLabel4.StylePriority.UseBackColor = False
        Me.XrLabel4.StylePriority.UseBorderColor = False
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseForeColor = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "Dealer ID : "
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLabel6
        '
        Me.XrLabel6.BackColor = System.Drawing.Color.White
        Me.XrLabel6.BorderColor = System.Drawing.Color.Black
        Me.XrLabel6.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel6.CanGrow = False
        Me.XrLabel6.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.ForeColor = System.Drawing.Color.Black
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 90.0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(110.0!, 15.0!)
        Me.XrLabel6.StylePriority.UseBackColor = False
        Me.XrLabel6.StylePriority.UseBorderColor = False
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseForeColor = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "Dealer Name :"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblBorrowerID
        '
        Me.lblBorrowerID.BackColor = System.Drawing.Color.White
        Me.lblBorrowerID.BorderColor = System.Drawing.Color.Black
        Me.lblBorrowerID.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBorrowerID.CanGrow = False
        Me.lblBorrowerID.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrowerID.ForeColor = System.Drawing.Color.Black
        Me.lblBorrowerID.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 75.0!)
        Me.lblBorrowerID.Name = "lblBorrowerID"
        Me.lblBorrowerID.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBorrowerID.SizeF = New System.Drawing.SizeF(500.0!, 15.0!)
        Me.lblBorrowerID.StylePriority.UseBackColor = False
        Me.lblBorrowerID.StylePriority.UseBorderColor = False
        Me.lblBorrowerID.StylePriority.UseBorders = False
        Me.lblBorrowerID.StylePriority.UseFont = False
        Me.lblBorrowerID.StylePriority.UseForeColor = False
        Me.lblBorrowerID.StylePriority.UseTextAlignment = False
        Me.lblBorrowerID.Text = "001-0000000001"
        Me.lblBorrowerID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblBorrower
        '
        Me.lblBorrower.BackColor = System.Drawing.Color.White
        Me.lblBorrower.BorderColor = System.Drawing.Color.Black
        Me.lblBorrower.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBorrower.CanGrow = False
        Me.lblBorrower.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBorrower.ForeColor = System.Drawing.Color.Black
        Me.lblBorrower.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 90.0!)
        Me.lblBorrower.Name = "lblBorrower"
        Me.lblBorrower.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBorrower.SizeF = New System.Drawing.SizeF(500.0!, 15.0!)
        Me.lblBorrower.StylePriority.UseBackColor = False
        Me.lblBorrower.StylePriority.UseBorderColor = False
        Me.lblBorrower.StylePriority.UseBorders = False
        Me.lblBorrower.StylePriority.UseFont = False
        Me.lblBorrower.StylePriority.UseForeColor = False
        Me.lblBorrower.StylePriority.UseTextAlignment = False
        Me.lblBorrower.Text = "Mark Kevin M. Gotico"
        Me.lblBorrower.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel3.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.ForeColor = System.Drawing.Color.White
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 60.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(610.0!, 15.0!)
        Me.XrLabel3.StylePriority.UseBackColor = False
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseForeColor = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "INFORMATION"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel2
        '
        Me.XrLabel2.BackColor = System.Drawing.Color.White
        Me.XrLabel2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.ForeColor = System.Drawing.Color.Black
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(410.0!, 30.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(380.0!, 30.0!)
        Me.XrLabel2.StylePriority.UseBackColor = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseForeColor = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Company Policy strictly prohibits employees from soliciting or receiving any comp" &
    "ensation in the processing of loan applications."
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify
        '
        'XrLabel1
        '
        Me.XrLabel1.BackColor = System.Drawing.Color.White
        Me.XrLabel1.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.ForeColor = System.Drawing.Color.Black
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(410.0!, 0.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(380.0!, 30.0!)
        Me.XrLabel1.StylePriority.UseBackColor = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseForeColor = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "DEALER PROFILE"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.BackColor = System.Drawing.Color.White
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(10.0!, 0.0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(300.0!, 60.0!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        Me.XrPictureBox1.StylePriority.UseBackColor = False
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
        'rptDealerProfile
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents cbxCar As DevExpress.XtraReports.UI.XRCheckBox
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTradeN As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel33 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel26 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel35 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMobile As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel28 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel30 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTelephone As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTIN As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblSSS As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblEmail As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents p_Borrower As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents lblCompleteAdd As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBorrowerID As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBorrower As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFaxNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblWebsite As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
End Class
