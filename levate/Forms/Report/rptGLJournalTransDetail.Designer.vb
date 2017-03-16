<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptGLJournalTransDetail
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptGLJournalTransDetail))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSearchPeriodFrom = New System.Windows.Forms.Button()
        Me.txtPeriodFrom = New System.Windows.Forms.TextBox()
        Me.btnCodeTo = New System.Windows.Forms.Button()
        Me.txtAccountTo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCodeFrom = New System.Windows.Forms.Button()
        Me.txtAccountFrom = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSearchPeriodTo = New System.Windows.Forms.Button()
        Me.txtPeriodTo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(232, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(279, 20)
        Me.Label6.TabIndex = 208
        Me.Label6.Text = "Journal Transaction Detail Report"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(175, 211)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 26)
        Me.btnClear.TabIndex = 207
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(13, 211)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 26)
        Me.btnPrint.TabIndex = 205
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSearchPeriodTo)
        Me.GroupBox1.Controls.Add(Me.txtPeriodTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnSearchPeriodFrom)
        Me.GroupBox1.Controls.Add(Me.txtPeriodFrom)
        Me.GroupBox1.Controls.Add(Me.btnCodeTo)
        Me.GroupBox1.Controls.Add(Me.txtAccountTo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnCodeFrom)
        Me.GroupBox1.Controls.Add(Me.txtAccountFrom)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 171)
        Me.GroupBox1.TabIndex = 204
        Me.GroupBox1.TabStop = False
        '
        'btnSearchPeriodFrom
        '
        Me.btnSearchPeriodFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchPeriodFrom.ImageIndex = 0
        Me.btnSearchPeriodFrom.Location = New System.Drawing.Point(315, 21)
        Me.btnSearchPeriodFrom.Name = "btnSearchPeriodFrom"
        Me.btnSearchPeriodFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnSearchPeriodFrom.TabIndex = 2
        Me.btnSearchPeriodFrom.Text = "..."
        Me.btnSearchPeriodFrom.UseVisualStyleBackColor = True
        '
        'txtPeriodFrom
        '
        Me.txtPeriodFrom.Location = New System.Drawing.Point(188, 24)
        Me.txtPeriodFrom.Name = "txtPeriodFrom"
        Me.txtPeriodFrom.Size = New System.Drawing.Size(117, 20)
        Me.txtPeriodFrom.TabIndex = 1
        Me.txtPeriodFrom.TabStop = False
        '
        'btnCodeTo
        '
        Me.btnCodeTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCodeTo.ImageIndex = 0
        Me.btnCodeTo.Location = New System.Drawing.Point(315, 119)
        Me.btnCodeTo.Name = "btnCodeTo"
        Me.btnCodeTo.Size = New System.Drawing.Size(29, 25)
        Me.btnCodeTo.TabIndex = 8
        Me.btnCodeTo.Text = "..."
        Me.btnCodeTo.UseVisualStyleBackColor = True
        '
        'txtAccountTo
        '
        Me.txtAccountTo.Location = New System.Drawing.Point(189, 121)
        Me.txtAccountTo.Name = "txtAccountTo"
        Me.txtAccountTo.Size = New System.Drawing.Size(117, 20)
        Me.txtAccountTo.TabIndex = 7
        Me.txtAccountTo.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(28, 125)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 13)
        Me.Label8.TabIndex = 183
        Me.Label8.Text = "To Account Code"
        '
        'btnCodeFrom
        '
        Me.btnCodeFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCodeFrom.ImageIndex = 0
        Me.btnCodeFrom.Location = New System.Drawing.Point(315, 90)
        Me.btnCodeFrom.Name = "btnCodeFrom"
        Me.btnCodeFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnCodeFrom.TabIndex = 6
        Me.btnCodeFrom.Text = "..."
        Me.btnCodeFrom.UseVisualStyleBackColor = True
        '
        'txtAccountFrom
        '
        Me.txtAccountFrom.Location = New System.Drawing.Point(189, 92)
        Me.txtAccountFrom.Name = "txtAccountFrom"
        Me.txtAccountFrom.Size = New System.Drawing.Size(117, 20)
        Me.txtAccountFrom.TabIndex = 5
        Me.txtAccountFrom.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(28, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 13)
        Me.Label9.TabIndex = 182
        Me.Label9.Text = "From Account Code"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(29, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 175
        Me.Label7.Text = "From Period"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(94, 211)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 26)
        Me.btnClose.TabIndex = 206
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSearchPeriodTo
        '
        Me.btnSearchPeriodTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchPeriodTo.ImageIndex = 0
        Me.btnSearchPeriodTo.Location = New System.Drawing.Point(316, 47)
        Me.btnSearchPeriodTo.Name = "btnSearchPeriodTo"
        Me.btnSearchPeriodTo.Size = New System.Drawing.Size(29, 25)
        Me.btnSearchPeriodTo.TabIndex = 4
        Me.btnSearchPeriodTo.Text = "..."
        Me.btnSearchPeriodTo.UseVisualStyleBackColor = True
        '
        'txtPeriodTo
        '
        Me.txtPeriodTo.Location = New System.Drawing.Point(189, 50)
        Me.txtPeriodTo.Name = "txtPeriodTo"
        Me.txtPeriodTo.Size = New System.Drawing.Size(117, 20)
        Me.txtPeriodTo.TabIndex = 3
        Me.txtPeriodTo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 189
        Me.Label1.Text = "To Period"
        '
        'rptGLJournalTransDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 249)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "rptGLJournalTransDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Journal Transaction Detail Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearchPeriodTo As System.Windows.Forms.Button
    Friend WithEvents txtPeriodTo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSearchPeriodFrom As System.Windows.Forms.Button
    Friend WithEvents txtPeriodFrom As System.Windows.Forms.TextBox
    Friend WithEvents btnCodeTo As System.Windows.Forms.Button
    Friend WithEvents txtAccountTo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnCodeFrom As System.Windows.Forms.Button
    Friend WithEvents txtAccountFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
