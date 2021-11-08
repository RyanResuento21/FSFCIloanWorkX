<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReason
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblReason = New DevComponents.DotNetBar.LabelX()
        Me.txtReason = New DevComponents.DotNetBar.Controls.RichTextBoxEx()
        Me.btnSelect = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtNo = New DevComponents.Editors.DoubleInput()
        Me.Highlighter1 = New DevComponents.DotNetBar.Validator.Highlighter()
        CType(Me.txtNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblReason
        '
        '
        '
        '
        Me.lblReason.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblReason.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReason.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblReason.Location = New System.Drawing.Point(22, 30)
        Me.lblReason.Name = "lblReason"
        Me.lblReason.Size = New System.Drawing.Size(66, 17)
        Me.lblReason.TabIndex = 715
        Me.lblReason.Text = "Reason :"
        '
        'txtReason
        '
        '
        '
        '
        Me.txtReason.BackgroundStyle.Class = "RichTextBoxBorder"
        Me.txtReason.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReason.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Highlighter1.SetHighlightOnFocus(Me.txtReason, True)
        Me.txtReason.Location = New System.Drawing.Point(78, 30)
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Rtf = "{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang13321{\fonttbl{\f0\fnil\fcharset0" &
    " Century Gothic;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{\*\generator Riched20 10.0.19041}\viewkind4\uc1 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\pard\f0\" &
    "fs17\par" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtReason.Size = New System.Drawing.Size(537, 100)
        Me.txtReason.TabIndex = 1
        '
        'btnSelect
        '
        Me.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSelect.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnSelect.Image = Global.FSFC_System.My.Resources.Resources.Save
        Me.btnSelect.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnSelect.Location = New System.Drawing.Point(78, 132)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(120, 30)
        Me.btnSelect.TabIndex = 2
        Me.btnSelect.Text = "&Save"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX2.Location = New System.Drawing.Point(118, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(162, 17)
        Me.LabelX2.TabIndex = 718
        Me.LabelX2.Text = "Reason must contain at least"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Red
        Me.LabelX3.Location = New System.Drawing.Point(78, 4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(49, 17)
        Me.LabelX3.TabIndex = 719
        Me.LabelX3.Text = "*Note :"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(327, 4)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(64, 17)
        Me.LabelX4.TabIndex = 721
        Me.LabelX4.Text = "characters"
        '
        'txtNo
        '
        '
        '
        '
        Me.txtNo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtNo.DisplayFormat = "0"
        Me.txtNo.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNo.ForeColor = System.Drawing.Color.Red
        Me.Highlighter1.SetHighlightOnFocus(Me.txtNo, True)
        Me.txtNo.Increment = 1.0R
        Me.txtNo.Location = New System.Drawing.Point(276, 3)
        Me.txtNo.Name = "txtNo"
        Me.txtNo.ShowUpDown = True
        Me.txtNo.Size = New System.Drawing.Size(46, 21)
        Me.txtNo.TabIndex = 722
        Me.txtNo.Value = 255.0R
        '
        'Highlighter1
        '
        Me.Highlighter1.ContainerControl = Me
        '
        'FrmReason
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(677, 168)
        Me.Controls.Add(Me.txtNo)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.lblReason)
        Me.Controls.Add(Me.LabelX3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Name = "FrmReason"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.txtNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblReason As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReason As DevComponents.DotNetBar.Controls.RichTextBoxEx
    Friend WithEvents btnSelect As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNo As DevComponents.Editors.DoubleInput
    Friend WithEvents Highlighter1 As DevComponents.DotNetBar.Validator.Highlighter
End Class
