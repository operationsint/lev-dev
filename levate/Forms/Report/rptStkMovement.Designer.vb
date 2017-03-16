<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptStkMovement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptStkMovement))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnStkMovementTo = New System.Windows.Forms.Button()
        Me.txtStkMovementTo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnStkMovementFrom = New System.Windows.Forms.Button()
        Me.txtStkMovementFrom = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnStkCodeTo = New System.Windows.Forms.Button()
        Me.txtStkCodeTo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnStkCodeFrom = New System.Windows.Forms.Button()
        Me.txtStkCodeFrom = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.rbPeriod = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPIncFrom = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnStkMovementTo)
        Me.GroupBox1.Controls.Add(Me.txtStkMovementTo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnStkMovementFrom)
        Me.GroupBox1.Controls.Add(Me.txtStkMovementFrom)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnStkCodeTo)
        Me.GroupBox1.Controls.Add(Me.txtStkCodeTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnStkCodeFrom)
        Me.GroupBox1.Controls.Add(Me.txtStkCodeFrom)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 179)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(253, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 13)
        Me.Label7.TabIndex = 167
        Me.Label7.Text = "Leave blank to select all"
        '
        'btnStkMovementTo
        '
        Me.btnStkMovementTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStkMovementTo.ImageIndex = 0
        Me.btnStkMovementTo.Location = New System.Drawing.Point(217, 67)
        Me.btnStkMovementTo.Name = "btnStkMovementTo"
        Me.btnStkMovementTo.Size = New System.Drawing.Size(29, 25)
        Me.btnStkMovementTo.TabIndex = 5
        Me.btnStkMovementTo.Text = "..."
        Me.btnStkMovementTo.UseVisualStyleBackColor = True
        '
        'txtStkMovementTo
        '
        Me.txtStkMovementTo.Location = New System.Drawing.Point(134, 69)
        Me.txtStkMovementTo.Name = "txtStkMovementTo"
        Me.txtStkMovementTo.Size = New System.Drawing.Size(80, 20)
        Me.txtStkMovementTo.TabIndex = 4
        Me.txtStkMovementTo.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 13)
        Me.Label8.TabIndex = 164
        Me.Label8.Text = "To Stk Movement No."
        '
        'btnStkMovementFrom
        '
        Me.btnStkMovementFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStkMovementFrom.ImageIndex = 0
        Me.btnStkMovementFrom.Location = New System.Drawing.Point(217, 38)
        Me.btnStkMovementFrom.Name = "btnStkMovementFrom"
        Me.btnStkMovementFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnStkMovementFrom.TabIndex = 3
        Me.btnStkMovementFrom.Text = "..."
        Me.btnStkMovementFrom.UseVisualStyleBackColor = True
        '
        'txtStkMovementFrom
        '
        Me.txtStkMovementFrom.Location = New System.Drawing.Point(134, 40)
        Me.txtStkMovementFrom.Name = "txtStkMovementFrom"
        Me.txtStkMovementFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtStkMovementFrom.TabIndex = 2
        Me.txtStkMovementFrom.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 13)
        Me.Label9.TabIndex = 161
        Me.Label9.Text = "From Stk Movement No."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(227, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 157
        Me.Label5.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "From Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(253, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 13)
        Me.Label3.TabIndex = 154
        Me.Label3.Text = "Leave blank to select all"
        '
        'btnStkCodeTo
        '
        Me.btnStkCodeTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStkCodeTo.ImageIndex = 0
        Me.btnStkCodeTo.Location = New System.Drawing.Point(217, 136)
        Me.btnStkCodeTo.Name = "btnStkCodeTo"
        Me.btnStkCodeTo.Size = New System.Drawing.Size(29, 25)
        Me.btnStkCodeTo.TabIndex = 9
        Me.btnStkCodeTo.Text = "..."
        Me.btnStkCodeTo.UseVisualStyleBackColor = True
        '
        'txtStkCodeTo
        '
        Me.txtStkCodeTo.Location = New System.Drawing.Point(134, 138)
        Me.txtStkCodeTo.Name = "txtStkCodeTo"
        Me.txtStkCodeTo.Size = New System.Drawing.Size(80, 20)
        Me.txtStkCodeTo.TabIndex = 8
        Me.txtStkCodeTo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 142)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "To StockCode"
        '
        'btnStkCodeFrom
        '
        Me.btnStkCodeFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStkCodeFrom.ImageIndex = 0
        Me.btnStkCodeFrom.Location = New System.Drawing.Point(217, 107)
        Me.btnStkCodeFrom.Name = "btnStkCodeFrom"
        Me.btnStkCodeFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnStkCodeFrom.TabIndex = 7
        Me.btnStkCodeFrom.Text = "..."
        Me.btnStkCodeFrom.UseVisualStyleBackColor = True
        '
        'txtStkCodeFrom
        '
        Me.txtStkCodeFrom.Location = New System.Drawing.Point(134, 109)
        Me.txtStkCodeFrom.Name = "txtStkCodeFrom"
        Me.txtStkCodeFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtStkCodeFrom.TabIndex = 6
        Me.txtStkCodeFrom.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(7, 113)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(89, 13)
        Me.Label37.TabIndex = 145
        Me.Label37.Text = "From Stock Code"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(134, 10)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(87, 20)
        Me.dtpFrom.TabIndex = 0
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(253, 9)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(87, 20)
        Me.dtpTo.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(91, 265)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(10, 265)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Checked = True
        Me.rbAll.Location = New System.Drawing.Point(10, 26)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(68, 17)
        Me.rbAll.TabIndex = 0
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "Select all"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(172, 265)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'rbPeriod
        '
        Me.rbPeriod.AutoSize = True
        Me.rbPeriod.Location = New System.Drawing.Point(10, 49)
        Me.rbPeriod.Name = "rbPeriod"
        Me.rbPeriod.Size = New System.Drawing.Size(47, 17)
        Me.rbPeriod.TabIndex = 1
        Me.rbPeriod.Text = "Filter"
        Me.rbPeriod.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(357, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(142, 20)
        Me.Label6.TabIndex = 164
        Me.Label6.Text = "Stock Movement"
        '
        'txtPIncFrom
        '
        Me.txtPIncFrom.Location = New System.Drawing.Point(134, 40)
        Me.txtPIncFrom.Name = "txtPIncFrom"
        Me.txtPIncFrom.ReadOnly = True
        Me.txtPIncFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtPIncFrom.TabIndex = 162
        Me.txtPIncFrom.TabStop = False
        '
        'rptStkMovement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 299)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.rbAll)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.rbPeriod)
        Me.Controls.Add(Me.Label6)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptStkMovement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Movement"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnStkMovementTo As System.Windows.Forms.Button
    Friend WithEvents txtStkMovementTo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnStkMovementFrom As System.Windows.Forms.Button
    Friend WithEvents txtStkMovementFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnStkCodeTo As System.Windows.Forms.Button
    Friend WithEvents txtStkCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnStkCodeFrom As System.Windows.Forms.Button
    Friend WithEvents txtStkCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents rbAll As System.Windows.Forms.RadioButton
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents rbPeriod As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPIncFrom As System.Windows.Forms.TextBox
End Class
