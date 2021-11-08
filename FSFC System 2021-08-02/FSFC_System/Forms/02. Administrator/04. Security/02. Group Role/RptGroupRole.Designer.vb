<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptGroupRole
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
        Me.cbxApprove = New DevExpress.XtraReports.UI.XRCheckBox()
        Me.cbxPrint = New DevExpress.XtraReports.UI.XRCheckBox()
        Me.cbxDelete = New DevExpress.XtraReports.UI.XRCheckBox()
        Me.cbxUpdate = New DevExpress.XtraReports.UI.XRCheckBox()
        Me.cbxSave = New DevExpress.XtraReports.UI.XRCheckBox()
        Me.cbxView = New DevExpress.XtraReports.UI.XRCheckBox()
        Me.lblForm = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblGroupRole = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountH = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFinancialH = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.cbxCheck = New DevExpress.XtraReports.UI.XRCheckBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.cbxCheck, Me.cbxApprove, Me.cbxPrint, Me.cbxDelete, Me.cbxUpdate, Me.cbxSave, Me.cbxView, Me.lblForm})
        Me.Detail.HeightF = 20.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'cbxApprove
        '
        Me.cbxApprove.BackColor = System.Drawing.Color.White
        Me.cbxApprove.BorderColor = System.Drawing.Color.Black
        Me.cbxApprove.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.cbxApprove.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.cbxApprove.ForeColor = System.Drawing.Color.Black
        Me.cbxApprove.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cbxApprove.LocationFloat = New DevExpress.Utils.PointFloat(750.0!, 0.0!)
        Me.cbxApprove.Name = "cbxApprove"
        Me.cbxApprove.SizeF = New System.Drawing.SizeF(50.0!, 20.0!)
        Me.cbxApprove.StylePriority.UseBackColor = False
        Me.cbxApprove.StylePriority.UseBorderColor = False
        Me.cbxApprove.StylePriority.UseBorders = False
        Me.cbxApprove.StylePriority.UseFont = False
        Me.cbxApprove.StylePriority.UseForeColor = False
        Me.cbxApprove.StylePriority.UseTextAlignment = False
        Me.cbxApprove.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'cbxPrint
        '
        Me.cbxPrint.BackColor = System.Drawing.Color.White
        Me.cbxPrint.BorderColor = System.Drawing.Color.Black
        Me.cbxPrint.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.cbxPrint.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.cbxPrint.ForeColor = System.Drawing.Color.Black
        Me.cbxPrint.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cbxPrint.LocationFloat = New DevExpress.Utils.PointFloat(670.0!, 0.0!)
        Me.cbxPrint.Name = "cbxPrint"
        Me.cbxPrint.SizeF = New System.Drawing.SizeF(40.0!, 20.0!)
        Me.cbxPrint.StylePriority.UseBackColor = False
        Me.cbxPrint.StylePriority.UseBorderColor = False
        Me.cbxPrint.StylePriority.UseBorders = False
        Me.cbxPrint.StylePriority.UseFont = False
        Me.cbxPrint.StylePriority.UseForeColor = False
        Me.cbxPrint.StylePriority.UseTextAlignment = False
        Me.cbxPrint.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'cbxDelete
        '
        Me.cbxDelete.BackColor = System.Drawing.Color.White
        Me.cbxDelete.BorderColor = System.Drawing.Color.Black
        Me.cbxDelete.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.cbxDelete.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.cbxDelete.ForeColor = System.Drawing.Color.Black
        Me.cbxDelete.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cbxDelete.LocationFloat = New DevExpress.Utils.PointFloat(630.0!, 0.0!)
        Me.cbxDelete.Name = "cbxDelete"
        Me.cbxDelete.SizeF = New System.Drawing.SizeF(40.0!, 20.0!)
        Me.cbxDelete.StylePriority.UseBackColor = False
        Me.cbxDelete.StylePriority.UseBorderColor = False
        Me.cbxDelete.StylePriority.UseBorders = False
        Me.cbxDelete.StylePriority.UseFont = False
        Me.cbxDelete.StylePriority.UseForeColor = False
        Me.cbxDelete.StylePriority.UseTextAlignment = False
        Me.cbxDelete.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'cbxUpdate
        '
        Me.cbxUpdate.BackColor = System.Drawing.Color.White
        Me.cbxUpdate.BorderColor = System.Drawing.Color.Black
        Me.cbxUpdate.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.cbxUpdate.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.cbxUpdate.ForeColor = System.Drawing.Color.Black
        Me.cbxUpdate.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cbxUpdate.LocationFloat = New DevExpress.Utils.PointFloat(590.0!, 0.0!)
        Me.cbxUpdate.Name = "cbxUpdate"
        Me.cbxUpdate.SizeF = New System.Drawing.SizeF(40.0!, 20.0!)
        Me.cbxUpdate.StylePriority.UseBackColor = False
        Me.cbxUpdate.StylePriority.UseBorderColor = False
        Me.cbxUpdate.StylePriority.UseBorders = False
        Me.cbxUpdate.StylePriority.UseFont = False
        Me.cbxUpdate.StylePriority.UseForeColor = False
        Me.cbxUpdate.StylePriority.UseTextAlignment = False
        Me.cbxUpdate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'cbxSave
        '
        Me.cbxSave.BackColor = System.Drawing.Color.White
        Me.cbxSave.BorderColor = System.Drawing.Color.Black
        Me.cbxSave.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.cbxSave.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.cbxSave.ForeColor = System.Drawing.Color.Black
        Me.cbxSave.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cbxSave.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 0.0!)
        Me.cbxSave.Name = "cbxSave"
        Me.cbxSave.SizeF = New System.Drawing.SizeF(40.0!, 20.0!)
        Me.cbxSave.StylePriority.UseBackColor = False
        Me.cbxSave.StylePriority.UseBorderColor = False
        Me.cbxSave.StylePriority.UseBorders = False
        Me.cbxSave.StylePriority.UseFont = False
        Me.cbxSave.StylePriority.UseForeColor = False
        Me.cbxSave.StylePriority.UseTextAlignment = False
        Me.cbxSave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'cbxView
        '
        Me.cbxView.BackColor = System.Drawing.Color.White
        Me.cbxView.BorderColor = System.Drawing.Color.Black
        Me.cbxView.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.cbxView.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.cbxView.ForeColor = System.Drawing.Color.Black
        Me.cbxView.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cbxView.LocationFloat = New DevExpress.Utils.PointFloat(510.0!, 0.0!)
        Me.cbxView.Name = "cbxView"
        Me.cbxView.SizeF = New System.Drawing.SizeF(40.0!, 20.0!)
        Me.cbxView.StylePriority.UseBackColor = False
        Me.cbxView.StylePriority.UseBorderColor = False
        Me.cbxView.StylePriority.UseBorders = False
        Me.cbxView.StylePriority.UseFont = False
        Me.cbxView.StylePriority.UseForeColor = False
        Me.cbxView.StylePriority.UseTextAlignment = False
        Me.cbxView.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblForm
        '
        Me.lblForm.BackColor = System.Drawing.Color.White
        Me.lblForm.BorderColor = System.Drawing.Color.Black
        Me.lblForm.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblForm.CanGrow = False
        Me.lblForm.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForm.ForeColor = System.Drawing.Color.Black
        Me.lblForm.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblForm.Name = "lblForm"
        Me.lblForm.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblForm.SizeF = New System.Drawing.SizeF(510.0!, 20.0!)
        Me.lblForm.StylePriority.UseBackColor = False
        Me.lblForm.StylePriority.UseBorderColor = False
        Me.lblForm.StylePriority.UseBorders = False
        Me.lblForm.StylePriority.UseFont = False
        Me.lblForm.StylePriority.UseForeColor = False
        Me.lblForm.StylePriority.UseTextAlignment = False
        Me.lblForm.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
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
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel3, Me.XrLabel2, Me.XrLabel7, Me.lblGroupRole, Me.XrLabel1, Me.lblAccountH, Me.XrLabel4, Me.XrLabel5, Me.XrLabel6, Me.lblFinancialH, Me.lblTitle})
        Me.PageHeader.HeightF = 85.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'XrLabel2
        '
        Me.XrLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel2.BorderColor = System.Drawing.Color.Black
        Me.XrLabel2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel2.CanGrow = False
        Me.XrLabel2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.ForeColor = System.Drawing.Color.White
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(750.0!, 50.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(50.0!, 35.0!)
        Me.XrLabel2.StylePriority.UseBackColor = False
        Me.XrLabel2.StylePriority.UseBorderColor = False
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseForeColor = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Approve"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel7
        '
        Me.XrLabel7.BackColor = System.Drawing.Color.White
        Me.XrLabel7.BorderColor = System.Drawing.Color.Black
        Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel7.CanGrow = False
        Me.XrLabel7.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.ForeColor = System.Drawing.Color.Black
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 25.0!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(120.0!, 20.0!)
        Me.XrLabel7.StylePriority.UseBackColor = False
        Me.XrLabel7.StylePriority.UseBorderColor = False
        Me.XrLabel7.StylePriority.UseBorders = False
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseForeColor = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "Position / Group Role :"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'lblGroupRole
        '
        Me.lblGroupRole.BackColor = System.Drawing.Color.White
        Me.lblGroupRole.BorderColor = System.Drawing.Color.Black
        Me.lblGroupRole.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
        Me.lblGroupRole.CanGrow = False
        Me.lblGroupRole.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupRole.ForeColor = System.Drawing.Color.Black
        Me.lblGroupRole.LocationFloat = New DevExpress.Utils.PointFloat(120.0!, 25.0!)
        Me.lblGroupRole.Name = "lblGroupRole"
        Me.lblGroupRole.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblGroupRole.SizeF = New System.Drawing.SizeF(270.0!, 20.0!)
        Me.lblGroupRole.StylePriority.UseBackColor = False
        Me.lblGroupRole.StylePriority.UseBorderColor = False
        Me.lblGroupRole.StylePriority.UseBorders = False
        Me.lblGroupRole.StylePriority.UseFont = False
        Me.lblGroupRole.StylePriority.UseForeColor = False
        Me.lblGroupRole.StylePriority.UseTextAlignment = False
        Me.lblGroupRole.Text = "Mark Kevin M. Gotico"
        Me.lblGroupRole.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(670.0!, 50.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(40.0!, 35.0!)
        Me.XrLabel1.StylePriority.UseBackColor = False
        Me.XrLabel1.StylePriority.UseBorderColor = False
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseForeColor = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Print"
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
        Me.lblAccountH.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 50.0!)
        Me.lblAccountH.Name = "lblAccountH"
        Me.lblAccountH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountH.SizeF = New System.Drawing.SizeF(510.0!, 35.0!)
        Me.lblAccountH.StylePriority.UseBackColor = False
        Me.lblAccountH.StylePriority.UseBorderColor = False
        Me.lblAccountH.StylePriority.UseBorders = False
        Me.lblAccountH.StylePriority.UseFont = False
        Me.lblAccountH.StylePriority.UseForeColor = False
        Me.lblAccountH.StylePriority.UseTextAlignment = False
        Me.lblAccountH.Text = "Form"
        Me.lblAccountH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(550.0!, 50.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(40.0!, 35.0!)
        Me.XrLabel4.StylePriority.UseBackColor = False
        Me.XrLabel4.StylePriority.UseBorderColor = False
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseForeColor = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "Save"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(590.0!, 50.0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(40.0!, 35.0!)
        Me.XrLabel5.StylePriority.UseBackColor = False
        Me.XrLabel5.StylePriority.UseBorderColor = False
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseForeColor = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "Update"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(630.0!, 50.0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(40.0!, 35.0!)
        Me.XrLabel6.StylePriority.UseBackColor = False
        Me.XrLabel6.StylePriority.UseBorderColor = False
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseForeColor = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "Cancel"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblFinancialH
        '
        Me.lblFinancialH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblFinancialH.BorderColor = System.Drawing.Color.Black
        Me.lblFinancialH.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFinancialH.CanGrow = False
        Me.lblFinancialH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinancialH.ForeColor = System.Drawing.Color.White
        Me.lblFinancialH.LocationFloat = New DevExpress.Utils.PointFloat(510.0!, 50.0!)
        Me.lblFinancialH.Name = "lblFinancialH"
        Me.lblFinancialH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFinancialH.SizeF = New System.Drawing.SizeF(40.0!, 35.0!)
        Me.lblFinancialH.StylePriority.UseBackColor = False
        Me.lblFinancialH.StylePriority.UseBorderColor = False
        Me.lblFinancialH.StylePriority.UseBorders = False
        Me.lblFinancialH.StylePriority.UseFont = False
        Me.lblFinancialH.StylePriority.UseForeColor = False
        Me.lblFinancialH.StylePriority.UseTextAlignment = False
        Me.lblFinancialH.Text = "View"
        Me.lblFinancialH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.lblTitle.SizeF = New System.Drawing.SizeF(800.0!, 20.0!)
        Me.lblTitle.StylePriority.UseBackColor = False
        Me.lblTitle.StylePriority.UseBorderColor = False
        Me.lblTitle.StylePriority.UseBorders = False
        Me.lblTitle.StylePriority.UseFont = False
        Me.lblTitle.StylePriority.UseForeColor = False
        Me.lblTitle.StylePriority.UseTextAlignment = False
        Me.lblTitle.Text = "Group Role"
        Me.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo2, Me.XrPageInfo1})
        Me.PageFooter.HeightF = 20.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.BackColor = System.Drawing.Color.White
        Me.XrPageInfo2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo2.Format = "{0:dddd, MMMM d, yyyy h:mm tt}"
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(600.0!, 0.0!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(200.0!, 20.0!)
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
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(600.0!, 20.0!)
        Me.XrPageInfo1.StylePriority.UseBackColor = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
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
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(710.0001!, 50.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(40.0!, 35.0!)
        Me.XrLabel3.StylePriority.UseBackColor = False
        Me.XrLabel3.StylePriority.UseBorderColor = False
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseForeColor = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "Check"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'cbxCheck
        '
        Me.cbxCheck.BackColor = System.Drawing.Color.White
        Me.cbxCheck.BorderColor = System.Drawing.Color.Black
        Me.cbxCheck.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.cbxCheck.Font = New System.Drawing.Font("Century Gothic", 6.75!)
        Me.cbxCheck.ForeColor = System.Drawing.Color.Black
        Me.cbxCheck.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cbxCheck.LocationFloat = New DevExpress.Utils.PointFloat(710.0!, 0.0!)
        Me.cbxCheck.Name = "cbxCheck"
        Me.cbxCheck.SizeF = New System.Drawing.SizeF(40.0!, 20.0!)
        Me.cbxCheck.StylePriority.UseBackColor = False
        Me.cbxCheck.StylePriority.UseBorderColor = False
        Me.cbxCheck.StylePriority.UseBorders = False
        Me.cbxCheck.StylePriority.UseFont = False
        Me.cbxCheck.StylePriority.UseForeColor = False
        Me.cbxCheck.StylePriority.UseTextAlignment = False
        Me.cbxCheck.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'rptGroupRole
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents lblTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFinancialH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblForm As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents cbxPrint As DevExpress.XtraReports.UI.XRCheckBox
    Friend WithEvents cbxDelete As DevExpress.XtraReports.UI.XRCheckBox
    Friend WithEvents cbxUpdate As DevExpress.XtraReports.UI.XRCheckBox
    Friend WithEvents cbxSave As DevExpress.XtraReports.UI.XRCheckBox
    Friend WithEvents cbxView As DevExpress.XtraReports.UI.XRCheckBox
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblGroupRole As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents cbxApprove As DevExpress.XtraReports.UI.XRCheckBox
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents cbxCheck As DevExpress.XtraReports.UI.XRCheckBox
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
End Class
