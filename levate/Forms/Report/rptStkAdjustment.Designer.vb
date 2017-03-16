<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptStkAdjustment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptStkAdjustment))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnStkAdjustmentTo = New System.Windows.Forms.Button()
        Me.txtStkAdjustmentTo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnStkAdjustmentFrom = New System.Windows.Forms.Button()
        Me.txtStkAdjustmentFrom = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnStkCodeTo = New System.Windows.Forms.Button()
        Me.txtSCodeTo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnStkCodeFrom = New System.Windows.Forms.Button()
        Me.txtSCodeFrom = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.rbPeriod = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnStkAdjustmentTo)
        Me.GroupBox1.Controls.Add(Me.txtStkAdjustmentTo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnStkAdjustmentFrom)
        Me.GroupBox1.Controls.Add(Me.txtStkAdjustmentFrom)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnStkCodeTo)
        Me.GroupBox1.Controls.Add(Me.txtSCodeTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnStkCodeFrom)
        Me.GroupBox1.Controls.Add(Me.txtSCodeFrom)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 67)
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
        'btnStkAdjustmentTo
        '
        Me.btnStkAdjustmentTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStkAdjustmentTo.ImageIndex = 0
        Me.btnStkAdjustmentTo.Location = New System.Drawing.Point(217, 67)
        Me.btnStkAdjustmentTo.Name = "btnStkAdjustmentTo"
        Me.btnStkAdjustmentTo.Size = New System.Drawing.Size(29, 25)
        Me.btnStkAdjustmentTo.TabIndex = 5
        Me.btnStkAdjustmentTo.Text = "..."
        Me.btnStkAdjustmentTo.UseVisualStyleBackColor = True
        '
        'txtStkAdjustmentTo
        '
        Me.txtStkAdjustmentTo.Location = New System.Drawing.Point(134, 69)
        Me.txtStkAdjustmentTo.Name = "txtStkAdjustmentTo"
        Me.txtStkAdjustmentTo.Size = New System.Drawing.Size(80, 20)
        Me.txtStkAdjustmentTo.TabIndex = 4
        Me.txtStkAdjustmentTo.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 13)
        Me.Label8.TabIndex = 164
        Me.Label8.Text = "To Stk Adjustment No."
        '
        'btnStkAdjustmentFrom
        '
        Me.btnStkAdjustmentFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStkAdjustmentFrom.ImageIndex = 0
        Me.btnStkAdjustmentFrom.Location = New System.Drawing.Point(217, 38)
        Me.btnStkAdjustmentFrom.Name = "btnStkAdjustmentFrom"
        Me.btnStkAdjustmentFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnStkAdjustmentFrom.TabIndex = 3
        Me.btnStkAdjustmentFrom.Text = "..."
        Me.btnStkAdjustmentFrom.UseVisualStyleBackColor = True
        '
        'txtStkAdjustmentFrom
        '
        Me.txtStkAdjustmentFrom.Location = New System.Drawing.Point(134, 40)
        Me.txtStkAdjustmentFrom.Name = "txtStkAdjustmentFrom"
        Me.txtStkAdjustmentFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtStkAdjustmentFrom.TabIndex = 2
        Me.txtStkAdjustmentFrom.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(124, 13)
        Me.Label9.TabIndex = 161
        Me.Label9.Text = "From Stk Adjustment No."
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
        'txtSCodeTo
        '
        Me.txtSCodeTo.Location = New System.Drawing.Point(134, 138)
        Me.txtSCodeTo.Name = "txtSCodeTo"
        Me.txtSCodeTo.Size = New System.Drawing.Size(80, 20)
        Me.txtSCodeTo.TabIndex = 8
        Me.txtSCodeTo.TabStop = False
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
        'txtSCodeFrom
        '
        Me.txtSCodeFrom.Location = New System.Drawing.Point(134, 109)
        Me.txtSCodeFrom.Name = "txtSCodeFrom"
        Me.txtSCodeFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtSCodeFrom.TabIndex = 6
        Me.txtSCodeFrom.TabStop = False
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
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Checked = True
        Me.rbAll.Location = New System.Drawing.Point(15, 21)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(68, 17)
        Me.rbAll.TabIndex = 0
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "Select all"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(177, 260)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(15, 260)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'rbPeriod
        '
        Me.rbPeriod.AutoSize = True
        Me.rbPeriod.Location = New System.Drawing.Point(15, 44)
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
        Me.Label6.Location = New System.Drawing.Point(362, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(151, 20)
        Me.Label6.TabIndex = 172
        Me.Label6.Text = "Stock Adjustment"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(96, 260)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'rptStkAdjustment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 299)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.rbAll)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.rbPeriod)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptStkAdjustment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Adjustment"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnStkAdjustmentTo As System.Windows.Forms.Button
    Friend WithEvents txtStkAdjustmentTo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnStkAdjustmentFrom As System.Windows.Forms.Button
    Friend WithEvents txtStkAdjustmentFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnStkCodeTo As System.Windows.Forms.Button
    Friend WithEvents txtSCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnStkCodeFrom As System.Windows.Forms.Button
    Friend WithEvents txtSCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbAll As System.Windows.Forms.RadioButton
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents rbPeriod As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
