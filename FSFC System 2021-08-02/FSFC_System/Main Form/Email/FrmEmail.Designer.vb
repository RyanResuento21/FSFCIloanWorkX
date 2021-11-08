<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEmail
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
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.txtSubject = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtBody = New DevComponents.DotNetBar.Controls.RichTextBoxEx()
        Me.btnSend = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'LabelX14
        '
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelX14.Font = New System.Drawing.Font("Century Gothic", 20.25!, System.Drawing.FontStyle.Bold)
        Me.LabelX14.Location = New System.Drawing.Point(0, 0)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(628, 46)
        Me.LabelX14.TabIndex = 1323
        Me.LabelX14.Text = "EMAIL"
        Me.LabelX14.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'txtSubject
        '
        Me.txtSubject.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtSubject.Border.Class = "TextBoxBorder"
        Me.txtSubject.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSubject.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSubject.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubject.ForeColor = System.Drawing.Color.Black
        Me.txtSubject.Location = New System.Drawing.Point(66, 61)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(550, 21)
        Me.txtSubject.TabIndex = 1
        Me.txtSubject.WatermarkText = "eg. THIS IS URGENT"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 62)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(83, 19)
        Me.LabelX2.TabIndex = 1351
        Me.LabelX2.Text = "SUBJECT:"
        Me.LabelX2.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX2.WordWrap = True
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 88)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(83, 19)
        Me.LabelX1.TabIndex = 1352
        Me.LabelX1.Text = "BODY:"
        Me.LabelX1.TextLineAlignment = System.Drawing.StringAlignment.Near
        Me.LabelX1.WordWrap = True
        '
        'txtBody
        '
        '
        '
        '
        Me.txtBody.BackgroundStyle.Class = "RichTextBoxBorder"
        Me.txtBody.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBody.Location = New System.Drawing.Point(66, 88)
        Me.txtBody.Name = "txtBody"
        Me.txtBody.Rtf = "{\rtf1\ansi\ansicpg1252\deff0\deflang13321{\fonttbl{\f0\fnil\fcharset0 Century Go" &
    "thic;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\viewkind4\uc1\pard\f0\fs17\par" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.txtBody.Size = New System.Drawing.Size(550, 192)
        Me.txtBody.TabIndex = 2
        '
        'btnSend
        '
        Me.btnSend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSend.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSend.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.Image = Global.FSFC_System.My.Resources.Resources.Email
        Me.btnSend.Location = New System.Drawing.Point(509, 286)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(107, 30)
        Me.btnSend.TabIndex = 3
        Me.btnSend.Text = "&SEND"
        '
        'FrmEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(628, 322)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.txtBody)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.LabelX14)
        Me.Controls.Add(Me.LabelX2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmEmail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtSubject As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtBody As DevComponents.DotNetBar.Controls.RichTextBoxEx
    Friend WithEvents btnSend As DevComponents.DotNetBar.ButtonX
End Class
