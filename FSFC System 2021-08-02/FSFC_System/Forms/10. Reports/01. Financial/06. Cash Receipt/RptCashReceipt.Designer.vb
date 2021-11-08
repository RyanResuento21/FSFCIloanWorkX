<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptCashReceipt
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
        Dim PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.lblRemarks = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCredit = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDebit = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDepartment = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountCode = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblMotherAccount = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPayment = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDocumentNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPayor = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblPostingDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDateDeposited = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDocumentDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTransactionType = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDepositStatus = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblEntryStatus = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.lblAsOf = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTitle = New DevExpress.XtraReports.UI.XRLabel()
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
        Me.lblAccountH = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrLabel34 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblDebitT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCreditT = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel31 = New DevExpress.XtraReports.UI.XRLabel()
        PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageFooter
        '
        PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo2, Me.XrPageInfo1})
        PageFooter.HeightF = 20.0!
        PageFooter.Name = "PageFooter"
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.BackColor = System.Drawing.Color.White
        Me.XrPageInfo2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo2.Format = "{0:dddd, MMMM d, yyyy h:mm tt}"
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(850.0!, 0.0!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.XrPageInfo2.StylePriority.UseBackColor = False
        Me.XrPageInfo2.StylePriority.UseFont = False
        Me.XrPageInfo2.StylePriority.UseTextAlignment = False
        Me.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.BackColor = System.Drawing.Color.White
        Me.XrPageInfo1.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(850.0!, 20.0!)
        Me.XrPageInfo1.StylePriority.UseBackColor = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblRemarks, Me.lblCredit, Me.lblDebit, Me.lblDepartment, Me.lblAccountCode, Me.lblMotherAccount, Me.lblPayment, Me.lblDocumentNumber, Me.lblAccountNumber, Me.lblPayor, Me.lblPostingDate, Me.lblDateDeposited, Me.lblDocumentDate, Me.lblTransactionType, Me.lblDepositStatus, Me.lblEntryStatus})
        Me.Detail.HeightF = 20.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.Color.White
        Me.lblRemarks.BorderColor = System.Drawing.Color.Black
        Me.lblRemarks.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblRemarks.CanGrow = False
        Me.lblRemarks.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.LocationFloat = New DevExpress.Utils.PointFloat(1110.0!, 0.0!)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblRemarks.SizeF = New System.Drawing.SizeF(140.0!, 20.0!)
        Me.lblRemarks.StylePriority.UseBackColor = False
        Me.lblRemarks.StylePriority.UseBorderColor = False
        Me.lblRemarks.StylePriority.UseBorders = False
        Me.lblRemarks.StylePriority.UseFont = False
        Me.lblRemarks.StylePriority.UseForeColor = False
        Me.lblRemarks.StylePriority.UseTextAlignment = False
        Me.lblRemarks.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblCredit
        '
        Me.lblCredit.BackColor = System.Drawing.Color.White
        Me.lblCredit.BorderColor = System.Drawing.Color.Black
        Me.lblCredit.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCredit.CanGrow = False
        Me.lblCredit.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCredit.ForeColor = System.Drawing.Color.Black
        Me.lblCredit.LocationFloat = New DevExpress.Utils.PointFloat(1060.0!, 0.0!)
        Me.lblCredit.Name = "lblCredit"
        Me.lblCredit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCredit.SizeF = New System.Drawing.SizeF(50.0!, 20.0!)
        Me.lblCredit.StylePriority.UseBackColor = False
        Me.lblCredit.StylePriority.UseBorderColor = False
        Me.lblCredit.StylePriority.UseBorders = False
        Me.lblCredit.StylePriority.UseFont = False
        Me.lblCredit.StylePriority.UseForeColor = False
        Me.lblCredit.StylePriority.UseTextAlignment = False
        Me.lblCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblCredit.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblDebit
        '
        Me.lblDebit.BackColor = System.Drawing.Color.White
        Me.lblDebit.BorderColor = System.Drawing.Color.Black
        Me.lblDebit.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDebit.CanGrow = False
        Me.lblDebit.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDebit.ForeColor = System.Drawing.Color.Black
        Me.lblDebit.LocationFloat = New DevExpress.Utils.PointFloat(1010.0!, 0.0!)
        Me.lblDebit.Name = "lblDebit"
        Me.lblDebit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDebit.SizeF = New System.Drawing.SizeF(50.0!, 20.0!)
        Me.lblDebit.StylePriority.UseBackColor = False
        Me.lblDebit.StylePriority.UseBorderColor = False
        Me.lblDebit.StylePriority.UseBorders = False
        Me.lblDebit.StylePriority.UseFont = False
        Me.lblDebit.StylePriority.UseForeColor = False
        Me.lblDebit.StylePriority.UseTextAlignment = False
        Me.lblDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblDebit.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblDepartment
        '
        Me.lblDepartment.BackColor = System.Drawing.Color.White
        Me.lblDepartment.BorderColor = System.Drawing.Color.Black
        Me.lblDepartment.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDepartment.CanGrow = False
        Me.lblDepartment.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartment.ForeColor = System.Drawing.Color.Black
        Me.lblDepartment.LocationFloat = New DevExpress.Utils.PointFloat(930.0!, 0.0!)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDepartment.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.lblDepartment.StylePriority.UseBackColor = False
        Me.lblDepartment.StylePriority.UseBorderColor = False
        Me.lblDepartment.StylePriority.UseBorders = False
        Me.lblDepartment.StylePriority.UseFont = False
        Me.lblDepartment.StylePriority.UseForeColor = False
        Me.lblDepartment.StylePriority.UseTextAlignment = False
        Me.lblDepartment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAccountCode
        '
        Me.lblAccountCode.BackColor = System.Drawing.Color.White
        Me.lblAccountCode.BorderColor = System.Drawing.Color.Black
        Me.lblAccountCode.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccountCode.CanGrow = False
        Me.lblAccountCode.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountCode.ForeColor = System.Drawing.Color.Black
        Me.lblAccountCode.LocationFloat = New DevExpress.Utils.PointFloat(830.0!, 0.0!)
        Me.lblAccountCode.Name = "lblAccountCode"
        Me.lblAccountCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountCode.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblAccountCode.StylePriority.UseBackColor = False
        Me.lblAccountCode.StylePriority.UseBorderColor = False
        Me.lblAccountCode.StylePriority.UseBorders = False
        Me.lblAccountCode.StylePriority.UseFont = False
        Me.lblAccountCode.StylePriority.UseForeColor = False
        Me.lblAccountCode.StylePriority.UseTextAlignment = False
        Me.lblAccountCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblMotherAccount
        '
        Me.lblMotherAccount.BackColor = System.Drawing.Color.White
        Me.lblMotherAccount.BorderColor = System.Drawing.Color.Black
        Me.lblMotherAccount.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblMotherAccount.CanGrow = False
        Me.lblMotherAccount.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotherAccount.ForeColor = System.Drawing.Color.Black
        Me.lblMotherAccount.LocationFloat = New DevExpress.Utils.PointFloat(730.0!, 0.0!)
        Me.lblMotherAccount.Name = "lblMotherAccount"
        Me.lblMotherAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblMotherAccount.SizeF = New System.Drawing.SizeF(100.0!, 20.0!)
        Me.lblMotherAccount.StylePriority.UseBackColor = False
        Me.lblMotherAccount.StylePriority.UseBorderColor = False
        Me.lblMotherAccount.StylePriority.UseBorders = False
        Me.lblMotherAccount.StylePriority.UseFont = False
        Me.lblMotherAccount.StylePriority.UseForeColor = False
        Me.lblMotherAccount.StylePriority.UseTextAlignment = False
        Me.lblMotherAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblPayment
        '
        Me.lblPayment.BackColor = System.Drawing.Color.White
        Me.lblPayment.BorderColor = System.Drawing.Color.Black
        Me.lblPayment.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPayment.CanGrow = False
        Me.lblPayment.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPayment.ForeColor = System.Drawing.Color.Black
        Me.lblPayment.LocationFloat = New DevExpress.Utils.PointFloat(680.0!, 0.0!)
        Me.lblPayment.Name = "lblPayment"
        Me.lblPayment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPayment.SizeF = New System.Drawing.SizeF(50.0!, 20.0!)
        Me.lblPayment.StylePriority.UseBackColor = False
        Me.lblPayment.StylePriority.UseBorderColor = False
        Me.lblPayment.StylePriority.UseBorders = False
        Me.lblPayment.StylePriority.UseFont = False
        Me.lblPayment.StylePriority.UseForeColor = False
        Me.lblPayment.StylePriority.UseTextAlignment = False
        Me.lblPayment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblDocumentNumber
        '
        Me.lblDocumentNumber.BackColor = System.Drawing.Color.White
        Me.lblDocumentNumber.BorderColor = System.Drawing.Color.Black
        Me.lblDocumentNumber.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDocumentNumber.CanGrow = False
        Me.lblDocumentNumber.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumentNumber.ForeColor = System.Drawing.Color.Black
        Me.lblDocumentNumber.LocationFloat = New DevExpress.Utils.PointFloat(615.0!, 0.0!)
        Me.lblDocumentNumber.Name = "lblDocumentNumber"
        Me.lblDocumentNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDocumentNumber.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblDocumentNumber.StylePriority.UseBackColor = False
        Me.lblDocumentNumber.StylePriority.UseBorderColor = False
        Me.lblDocumentNumber.StylePriority.UseBorders = False
        Me.lblDocumentNumber.StylePriority.UseFont = False
        Me.lblDocumentNumber.StylePriority.UseForeColor = False
        Me.lblDocumentNumber.StylePriority.UseTextAlignment = False
        Me.lblDocumentNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAccountNumber
        '
        Me.lblAccountNumber.BackColor = System.Drawing.Color.White
        Me.lblAccountNumber.BorderColor = System.Drawing.Color.Black
        Me.lblAccountNumber.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccountNumber.CanGrow = False
        Me.lblAccountNumber.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountNumber.ForeColor = System.Drawing.Color.Black
        Me.lblAccountNumber.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 0.0!)
        Me.lblAccountNumber.Name = "lblAccountNumber"
        Me.lblAccountNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountNumber.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblAccountNumber.StylePriority.UseBackColor = False
        Me.lblAccountNumber.StylePriority.UseBorderColor = False
        Me.lblAccountNumber.StylePriority.UseBorders = False
        Me.lblAccountNumber.StylePriority.UseFont = False
        Me.lblAccountNumber.StylePriority.UseForeColor = False
        Me.lblAccountNumber.StylePriority.UseTextAlignment = False
        Me.lblAccountNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblPayor
        '
        Me.lblPayor.BackColor = System.Drawing.Color.White
        Me.lblPayor.BorderColor = System.Drawing.Color.Black
        Me.lblPayor.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPayor.CanGrow = False
        Me.lblPayor.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPayor.ForeColor = System.Drawing.Color.Black
        Me.lblPayor.LocationFloat = New DevExpress.Utils.PointFloat(390.0!, 0.0!)
        Me.lblPayor.Name = "lblPayor"
        Me.lblPayor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPayor.SizeF = New System.Drawing.SizeF(160.0!, 20.0!)
        Me.lblPayor.StylePriority.UseBackColor = False
        Me.lblPayor.StylePriority.UseBorderColor = False
        Me.lblPayor.StylePriority.UseBorders = False
        Me.lblPayor.StylePriority.UseFont = False
        Me.lblPayor.StylePriority.UseForeColor = False
        Me.lblPayor.StylePriority.UseTextAlignment = False
        Me.lblPayor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblPostingDate
        '
        Me.lblPostingDate.BackColor = System.Drawing.Color.White
        Me.lblPostingDate.BorderColor = System.Drawing.Color.Black
        Me.lblPostingDate.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblPostingDate.CanGrow = False
        Me.lblPostingDate.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPostingDate.ForeColor = System.Drawing.Color.Black
        Me.lblPostingDate.LocationFloat = New DevExpress.Utils.PointFloat(325.0!, 0.0!)
        Me.lblPostingDate.Name = "lblPostingDate"
        Me.lblPostingDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblPostingDate.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblPostingDate.StylePriority.UseBackColor = False
        Me.lblPostingDate.StylePriority.UseBorderColor = False
        Me.lblPostingDate.StylePriority.UseBorders = False
        Me.lblPostingDate.StylePriority.UseFont = False
        Me.lblPostingDate.StylePriority.UseForeColor = False
        Me.lblPostingDate.StylePriority.UseTextAlignment = False
        Me.lblPostingDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblDateDeposited
        '
        Me.lblDateDeposited.BackColor = System.Drawing.Color.White
        Me.lblDateDeposited.BorderColor = System.Drawing.Color.Black
        Me.lblDateDeposited.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDateDeposited.CanGrow = False
        Me.lblDateDeposited.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateDeposited.ForeColor = System.Drawing.Color.Black
        Me.lblDateDeposited.LocationFloat = New DevExpress.Utils.PointFloat(260.0!, 0.0!)
        Me.lblDateDeposited.Name = "lblDateDeposited"
        Me.lblDateDeposited.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDateDeposited.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblDateDeposited.StylePriority.UseBackColor = False
        Me.lblDateDeposited.StylePriority.UseBorderColor = False
        Me.lblDateDeposited.StylePriority.UseBorders = False
        Me.lblDateDeposited.StylePriority.UseFont = False
        Me.lblDateDeposited.StylePriority.UseForeColor = False
        Me.lblDateDeposited.StylePriority.UseTextAlignment = False
        Me.lblDateDeposited.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblDateDeposited.XlsxFormatString = "mm/dd/yyyy"
        '
        'lblDocumentDate
        '
        Me.lblDocumentDate.BackColor = System.Drawing.Color.White
        Me.lblDocumentDate.BorderColor = System.Drawing.Color.Black
        Me.lblDocumentDate.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDocumentDate.CanGrow = False
        Me.lblDocumentDate.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocumentDate.ForeColor = System.Drawing.Color.Black
        Me.lblDocumentDate.LocationFloat = New DevExpress.Utils.PointFloat(195.0!, 0.0!)
        Me.lblDocumentDate.Name = "lblDocumentDate"
        Me.lblDocumentDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDocumentDate.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblDocumentDate.StylePriority.UseBackColor = False
        Me.lblDocumentDate.StylePriority.UseBorderColor = False
        Me.lblDocumentDate.StylePriority.UseBorders = False
        Me.lblDocumentDate.StylePriority.UseFont = False
        Me.lblDocumentDate.StylePriority.UseForeColor = False
        Me.lblDocumentDate.StylePriority.UseTextAlignment = False
        Me.lblDocumentDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        Me.lblDocumentDate.XlsxFormatString = "mm/dd/yyyy"
        '
        'lblTransactionType
        '
        Me.lblTransactionType.BackColor = System.Drawing.Color.White
        Me.lblTransactionType.BorderColor = System.Drawing.Color.Black
        Me.lblTransactionType.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTransactionType.CanGrow = False
        Me.lblTransactionType.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransactionType.ForeColor = System.Drawing.Color.Black
        Me.lblTransactionType.LocationFloat = New DevExpress.Utils.PointFloat(130.0!, 0.0!)
        Me.lblTransactionType.Name = "lblTransactionType"
        Me.lblTransactionType.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTransactionType.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblTransactionType.StylePriority.UseBackColor = False
        Me.lblTransactionType.StylePriority.UseBorderColor = False
        Me.lblTransactionType.StylePriority.UseBorders = False
        Me.lblTransactionType.StylePriority.UseFont = False
        Me.lblTransactionType.StylePriority.UseForeColor = False
        Me.lblTransactionType.StylePriority.UseTextAlignment = False
        Me.lblTransactionType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblDepositStatus
        '
        Me.lblDepositStatus.BackColor = System.Drawing.Color.White
        Me.lblDepositStatus.BorderColor = System.Drawing.Color.Black
        Me.lblDepositStatus.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDepositStatus.CanGrow = False
        Me.lblDepositStatus.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepositStatus.ForeColor = System.Drawing.Color.Black
        Me.lblDepositStatus.LocationFloat = New DevExpress.Utils.PointFloat(65.0!, 0.0!)
        Me.lblDepositStatus.Name = "lblDepositStatus"
        Me.lblDepositStatus.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDepositStatus.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblDepositStatus.StylePriority.UseBackColor = False
        Me.lblDepositStatus.StylePriority.UseBorderColor = False
        Me.lblDepositStatus.StylePriority.UseBorders = False
        Me.lblDepositStatus.StylePriority.UseFont = False
        Me.lblDepositStatus.StylePriority.UseForeColor = False
        Me.lblDepositStatus.StylePriority.UseTextAlignment = False
        Me.lblDepositStatus.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblEntryStatus
        '
        Me.lblEntryStatus.BackColor = System.Drawing.Color.White
        Me.lblEntryStatus.BorderColor = System.Drawing.Color.Black
        Me.lblEntryStatus.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblEntryStatus.CanGrow = False
        Me.lblEntryStatus.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEntryStatus.ForeColor = System.Drawing.Color.Black
        Me.lblEntryStatus.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblEntryStatus.Name = "lblEntryStatus"
        Me.lblEntryStatus.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblEntryStatus.SizeF = New System.Drawing.SizeF(65.0!, 20.0!)
        Me.lblEntryStatus.StylePriority.UseBackColor = False
        Me.lblEntryStatus.StylePriority.UseBorderColor = False
        Me.lblEntryStatus.StylePriority.UseBorders = False
        Me.lblEntryStatus.StylePriority.UseFont = False
        Me.lblEntryStatus.StylePriority.UseForeColor = False
        Me.lblEntryStatus.StylePriority.UseTextAlignment = False
        Me.lblEntryStatus.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblAsOf, Me.lblTitle, Me.XrLabel15, Me.XrLabel14, Me.XrLabel13, Me.XrLabel12, Me.XrLabel11, Me.XrLabel10, Me.XrLabel9, Me.XrLabel8, Me.XrLabel7, Me.XrLabel6, Me.XrLabel5, Me.XrLabel4, Me.XrLabel3, Me.XrLabel2, Me.XrLabel1, Me.lblAccountH})
        Me.PageHeader.HeightF = 75.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'lblAsOf
        '
        Me.lblAsOf.BackColor = System.Drawing.Color.White
        Me.lblAsOf.BorderColor = System.Drawing.Color.Black
        Me.lblAsOf.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblAsOf.CanGrow = False
        Me.lblAsOf.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAsOf.ForeColor = System.Drawing.Color.Black
        Me.lblAsOf.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 20.0!)
        Me.lblAsOf.Name = "lblAsOf"
        Me.lblAsOf.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAsOf.SizeF = New System.Drawing.SizeF(1250.0!, 15.0!)
        Me.lblAsOf.StylePriority.UseBackColor = False
        Me.lblAsOf.StylePriority.UseBorderColor = False
        Me.lblAsOf.StylePriority.UseBorders = False
        Me.lblAsOf.StylePriority.UseFont = False
        Me.lblAsOf.StylePriority.UseForeColor = False
        Me.lblAsOf.StylePriority.UseTextAlignment = False
        Me.lblAsOf.Text = "As of August 08, 2018"
        Me.lblAsOf.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.White
        Me.lblTitle.BorderColor = System.Drawing.Color.Black
        Me.lblTitle.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblTitle.CanGrow = False
        Me.lblTitle.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTitle.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTitle.SizeF = New System.Drawing.SizeF(1250.0!, 20.0!)
        Me.lblTitle.StylePriority.UseBackColor = False
        Me.lblTitle.StylePriority.UseBorderColor = False
        Me.lblTitle.StylePriority.UseBorders = False
        Me.lblTitle.StylePriority.UseFont = False
        Me.lblTitle.StylePriority.UseForeColor = False
        Me.lblTitle.StylePriority.UseTextAlignment = False
        Me.lblTitle.Text = "Cash Receipts Book"
        Me.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(1110.0!, 40.0!)
        Me.XrLabel15.Name = "XrLabel15"
        Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel15.SizeF = New System.Drawing.SizeF(140.0!, 35.0!)
        Me.XrLabel15.StylePriority.UseBackColor = False
        Me.XrLabel15.StylePriority.UseBorderColor = False
        Me.XrLabel15.StylePriority.UseBorders = False
        Me.XrLabel15.StylePriority.UseFont = False
        Me.XrLabel15.StylePriority.UseForeColor = False
        Me.XrLabel15.StylePriority.UseTextAlignment = False
        Me.XrLabel15.Text = "Remarks"
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
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(1060.0!, 40.0!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(50.0!, 35.0!)
        Me.XrLabel14.StylePriority.UseBackColor = False
        Me.XrLabel14.StylePriority.UseBorderColor = False
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.StylePriority.UseForeColor = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = "Credit"
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
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(1010.0!, 40.0!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(50.0!, 35.0!)
        Me.XrLabel13.StylePriority.UseBackColor = False
        Me.XrLabel13.StylePriority.UseBorderColor = False
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.StylePriority.UseFont = False
        Me.XrLabel13.StylePriority.UseForeColor = False
        Me.XrLabel13.StylePriority.UseTextAlignment = False
        Me.XrLabel13.Text = "Debit"
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
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(930.0!, 40.0!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(80.0!, 35.0!)
        Me.XrLabel12.StylePriority.UseBackColor = False
        Me.XrLabel12.StylePriority.UseBorderColor = False
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseForeColor = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = "Department"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel11
        '
        Me.XrLabel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel11.BorderColor = System.Drawing.Color.Black
        Me.XrLabel11.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel11.CanGrow = False
        Me.XrLabel11.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel11.ForeColor = System.Drawing.Color.White
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(830.0!, 40.0!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(100.0!, 35.0!)
        Me.XrLabel11.StylePriority.UseBackColor = False
        Me.XrLabel11.StylePriority.UseBorderColor = False
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseForeColor = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = "Account Code"
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
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(730.0!, 40.0!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(100.0!, 35.0!)
        Me.XrLabel10.StylePriority.UseBackColor = False
        Me.XrLabel10.StylePriority.UseBorderColor = False
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseForeColor = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = "Mother Account"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel9
        '
        Me.XrLabel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel9.BorderColor = System.Drawing.Color.Black
        Me.XrLabel9.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel9.CanGrow = False
        Me.XrLabel9.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.ForeColor = System.Drawing.Color.White
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(680.0!, 40.0!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(50.0!, 35.0!)
        Me.XrLabel9.StylePriority.UseBackColor = False
        Me.XrLabel9.StylePriority.UseBorderColor = False
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseForeColor = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = "Payment"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel8
        '
        Me.XrLabel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel8.BorderColor = System.Drawing.Color.Black
        Me.XrLabel8.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel8.CanGrow = False
        Me.XrLabel8.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.ForeColor = System.Drawing.Color.White
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(615.0!, 40.0!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(65.0!, 35.0!)
        Me.XrLabel8.StylePriority.UseBackColor = False
        Me.XrLabel8.StylePriority.UseBorderColor = False
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseForeColor = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "Document Number"
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
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 40.0!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(65.0!, 35.0!)
        Me.XrLabel7.StylePriority.UseBackColor = False
        Me.XrLabel7.StylePriority.UseBorderColor = False
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseForeColor = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "Account Number"
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
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(390.0!, 40.0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(160.0!, 35.0!)
        Me.XrLabel6.StylePriority.UseBackColor = False
        Me.XrLabel6.StylePriority.UseBorderColor = False
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseForeColor = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "Payor"
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
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(325.0!, 40.0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(65.0!, 35.0!)
        Me.XrLabel5.StylePriority.UseBackColor = False
        Me.XrLabel5.StylePriority.UseBorderColor = False
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseForeColor = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "Posting Date"
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
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(260.0!, 40.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(65.0!, 35.0!)
        Me.XrLabel4.StylePriority.UseBackColor = False
        Me.XrLabel4.StylePriority.UseBorderColor = False
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseForeColor = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "Date Deposited"
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
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(195.0!, 40.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(65.0!, 35.0!)
        Me.XrLabel3.StylePriority.UseBackColor = False
        Me.XrLabel3.StylePriority.UseBorderColor = False
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseForeColor = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "Document Date"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(130.0!, 40.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(65.0!, 35.0!)
        Me.XrLabel2.StylePriority.UseBackColor = False
        Me.XrLabel2.StylePriority.UseBorderColor = False
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseForeColor = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Transaction Type"
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
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(65.0!, 40.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(65.0!, 35.0!)
        Me.XrLabel1.StylePriority.UseBackColor = False
        Me.XrLabel1.StylePriority.UseBorderColor = False
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseForeColor = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Deposit Status"
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
        Me.lblAccountH.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 40.0!)
        Me.lblAccountH.Name = "lblAccountH"
        Me.lblAccountH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountH.SizeF = New System.Drawing.SizeF(65.0!, 35.0!)
        Me.lblAccountH.StylePriority.UseBackColor = False
        Me.lblAccountH.StylePriority.UseBorderColor = False
        Me.lblAccountH.StylePriority.UseBorders = False
        Me.lblAccountH.StylePriority.UseFont = False
        Me.lblAccountH.StylePriority.UseForeColor = False
        Me.lblAccountH.StylePriority.UseTextAlignment = False
        Me.lblAccountH.Text = "Entry Status"
        Me.lblAccountH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel34, Me.lblDebitT, Me.lblCreditT, Me.XrLabel31})
        Me.ReportFooter.HeightF = 20.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrLabel34
        '
        Me.XrLabel34.BackColor = System.Drawing.Color.White
        Me.XrLabel34.BorderColor = System.Drawing.Color.Black
        Me.XrLabel34.Borders = DevExpress.XtraPrinting.BorderSide.Left
        Me.XrLabel34.CanGrow = False
        Me.XrLabel34.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel34.ForeColor = System.Drawing.Color.Black
        Me.XrLabel34.LocationFloat = New DevExpress.Utils.PointFloat(1110.0!, 0.0!)
        Me.XrLabel34.Name = "XrLabel34"
        Me.XrLabel34.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel34.SizeF = New System.Drawing.SizeF(140.0!, 20.0!)
        Me.XrLabel34.StylePriority.UseBackColor = False
        Me.XrLabel34.StylePriority.UseBorderColor = False
        Me.XrLabel34.StylePriority.UseBorders = False
        Me.XrLabel34.StylePriority.UseFont = False
        Me.XrLabel34.StylePriority.UseForeColor = False
        Me.XrLabel34.StylePriority.UseTextAlignment = False
        Me.XrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblDebitT
        '
        Me.lblDebitT.BackColor = System.Drawing.Color.White
        Me.lblDebitT.BorderColor = System.Drawing.Color.Black
        Me.lblDebitT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDebitT.CanGrow = False
        Me.lblDebitT.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDebitT.ForeColor = System.Drawing.Color.Black
        Me.lblDebitT.LocationFloat = New DevExpress.Utils.PointFloat(1010.0!, 0.0!)
        Me.lblDebitT.Name = "lblDebitT"
        Me.lblDebitT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDebitT.SizeF = New System.Drawing.SizeF(50.0!, 20.0!)
        Me.lblDebitT.StylePriority.UseBackColor = False
        Me.lblDebitT.StylePriority.UseBorderColor = False
        Me.lblDebitT.StylePriority.UseBorders = False
        Me.lblDebitT.StylePriority.UseFont = False
        Me.lblDebitT.StylePriority.UseForeColor = False
        Me.lblDebitT.StylePriority.UseTextAlignment = False
        Me.lblDebitT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblDebitT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblCreditT
        '
        Me.lblCreditT.BackColor = System.Drawing.Color.White
        Me.lblCreditT.BorderColor = System.Drawing.Color.Black
        Me.lblCreditT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCreditT.CanGrow = False
        Me.lblCreditT.Font = New System.Drawing.Font("Century Gothic", 5.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreditT.ForeColor = System.Drawing.Color.Black
        Me.lblCreditT.LocationFloat = New DevExpress.Utils.PointFloat(1060.0!, 0.0!)
        Me.lblCreditT.Name = "lblCreditT"
        Me.lblCreditT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCreditT.SizeF = New System.Drawing.SizeF(50.0!, 20.0!)
        Me.lblCreditT.StylePriority.UseBackColor = False
        Me.lblCreditT.StylePriority.UseBorderColor = False
        Me.lblCreditT.StylePriority.UseBorders = False
        Me.lblCreditT.StylePriority.UseFont = False
        Me.lblCreditT.StylePriority.UseForeColor = False
        Me.lblCreditT.StylePriority.UseTextAlignment = False
        Me.lblCreditT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblCreditT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'XrLabel31
        '
        Me.XrLabel31.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel31.BorderColor = System.Drawing.Color.Black
        Me.XrLabel31.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel31.CanGrow = False
        Me.XrLabel31.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel31.ForeColor = System.Drawing.Color.White
        Me.XrLabel31.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrLabel31.Name = "XrLabel31"
        Me.XrLabel31.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel31.SizeF = New System.Drawing.SizeF(1010.0!, 20.0!)
        Me.XrLabel31.StylePriority.UseBackColor = False
        Me.XrLabel31.StylePriority.UseBorderColor = False
        Me.XrLabel31.StylePriority.UseBorders = False
        Me.XrLabel31.StylePriority.UseFont = False
        Me.XrLabel31.StylePriority.UseForeColor = False
        Me.XrLabel31.StylePriority.UseTextAlignment = False
        Me.XrLabel31.Text = "T O T A L "
        Me.XrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'rptCashReceipt
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, PageFooter, Me.PageHeader, Me.ReportFooter})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.PageHeight = 850
        Me.PageWidth = 1300
        Me.PaperKind = System.Drawing.Printing.PaperKind.GermanLegalFanfold
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
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
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblRemarks As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCredit As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDebit As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDepartment As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountCode As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblMotherAccount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPayment As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDocumentNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPayor As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblPostingDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDateDeposited As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDocumentDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTransactionType As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDepositStatus As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblEntryStatus As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrLabel34 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDebitT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCreditT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel31 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAsOf As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
End Class
