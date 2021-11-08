<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUserAgreement
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUserAgreement))
        Me.lblTitle = New DevComponents.DotNetBar.LabelX()
        Me.lblAgreement = New DevComponents.DotNetBar.LabelX()
        Me.cbxAgreement = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.btnOK = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.Timer_Date = New System.Windows.Forms.Timer(Me.components)
        Me.lblTimer = New DevComponents.DotNetBar.LabelX()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTitle.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(12, 13)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(836, 38)
        Me.lblTitle.TabIndex = 96
        Me.lblTitle.Text = "DATA PRIVACY AGREEMENT"
        Me.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblAgreement
        '
        Me.lblAgreement.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblAgreement.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblAgreement.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgreement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblAgreement.Location = New System.Drawing.Point(12, 59)
        Me.lblAgreement.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblAgreement.Name = "lblAgreement"
        Me.lblAgreement.Size = New System.Drawing.Size(836, 382)
        Me.lblAgreement.TabIndex = 97
        Me.lblAgreement.Text = resources.GetString("lblAgreement.Text")
        Me.lblAgreement.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.lblAgreement.WordWrap = True
        '
        'cbxAgreement
        '
        Me.cbxAgreement.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxAgreement.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxAgreement.Enabled = False
        Me.cbxAgreement.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAgreement.Location = New System.Drawing.Point(12, 461)
        Me.cbxAgreement.Name = "cbxAgreement"
        Me.cbxAgreement.Size = New System.Drawing.Size(336, 23)
        Me.cbxAgreement.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxAgreement.TabIndex = 98
        Me.cbxAgreement.Text = "I Agree to the terms and conditions of the privacy policy"
        '
        'btnOK
        '
        Me.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnOK.Enabled = False
        Me.btnOK.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Image)
        Me.btnOK.Location = New System.Drawing.Point(12, 491)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(155, 32)
        Me.btnOK.TabIndex = 99
        Me.btnOK.Text = "Sign In"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.DialogResult = DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(173, 491)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(155, 32)
        Me.btnCancel.TabIndex = 100
        Me.btnCancel.Text = "Exit"
        '
        'Timer_Date
        '
        Me.Timer_Date.Interval = 1000
        '
        'lblTimer
        '
        Me.lblTimer.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblTimer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTimer.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimer.ForeColor = System.Drawing.Color.Red
        Me.lblTimer.Location = New System.Drawing.Point(334, 491)
        Me.lblTimer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New System.Drawing.Size(316, 23)
        Me.lblTimer.TabIndex = 101
        Me.lblTimer.Text = "I Agree will be open in 10 second(s)"
        '
        'FrmUserAgreement
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 529)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblTimer)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cbxAgreement)
        Me.Controls.Add(Me.lblAgreement)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmUserAgreement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblAgreement As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxAgreement As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents btnOK As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Timer_Date As Timer
    Friend WithEvents lblTimer As DevComponents.DotNetBar.LabelX
End Class
