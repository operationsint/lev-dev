<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptSlsInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptSlsInvoice))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSNoTo = New System.Windows.Forms.Button()
        Me.txtSNoTo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnSNoFrom = New System.Windows.Forms.Button()
        Me.txtSNoFrom = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSlsCode = New System.Windows.Forms.Button()
        Me.txtSlsCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCustCodeTo = New System.Windows.Forms.Button()
        Me.txtCCodeTo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCustCodeFrom = New System.Windows.Forms.Button()
        Me.txtCCodeFrom = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.rbPeriod = New System.Windows.Forms.RadioButton()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cbStatus)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnSNoTo)
        Me.GroupBox1.Controls.Add(Me.txtSNoTo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnSNoFrom)
        Me.GroupBox1.Controls.Add(Me.txtSNoFrom)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.btnSlsCode)
        Me.GroupBox1.Controls.Add(Me.txtSlsCode)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnCustCodeTo)
        Me.GroupBox1.Controls.Add(Me.txtCCodeTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnCustCodeFrom)
        Me.GroupBox1.Controls.Add(Me.txtCCodeFrom)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 260)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label11.Location = New System.Drawing.Point(241, 188)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(122, 13)
        Me.Label11.TabIndex = 174
        Me.Label11.Text = "Leave blank to select all"
        '
        'cbStatus
        '
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Location = New System.Drawing.Point(121, 222)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(113, 21)
        Me.cbStatus.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 225)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 172
        Me.Label10.Text = "Status"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(241, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 13)
        Me.Label7.TabIndex = 167
        Me.Label7.Text = "Leave blank to select all"
        '
        'btnSNoTo
        '
        Me.btnSNoTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSNoTo.ImageIndex = 0
        Me.btnSNoTo.Location = New System.Drawing.Point(205, 73)
        Me.btnSNoTo.Name = "btnSNoTo"
        Me.btnSNoTo.Size = New System.Drawing.Size(29, 25)
        Me.btnSNoTo.TabIndex = 5
        Me.btnSNoTo.Text = "..."
        Me.btnSNoTo.UseVisualStyleBackColor = True
        '
        'txtSNoTo
        '
        Me.txtSNoTo.Location = New System.Drawing.Point(122, 75)
        Me.txtSNoTo.Name = "txtSNoTo"
        Me.txtSNoTo.Size = New System.Drawing.Size(80, 20)
        Me.txtSNoTo.TabIndex = 4
        Me.txtSNoTo.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 164
        Me.Label8.Text = "To S.Invoice No."
        '
        'btnSNoFrom
        '
        Me.btnSNoFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSNoFrom.ImageIndex = 0
        Me.btnSNoFrom.Location = New System.Drawing.Point(205, 44)
        Me.btnSNoFrom.Name = "btnSNoFrom"
        Me.btnSNoFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnSNoFrom.TabIndex = 3
        Me.btnSNoFrom.Text = "..."
        Me.btnSNoFrom.UseVisualStyleBackColor = True
        '
        'txtSNoFrom
        '
        Me.txtSNoFrom.Location = New System.Drawing.Point(122, 46)
        Me.txtSNoFrom.Name = "txtSNoFrom"
        Me.txtSNoFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtSNoFrom.TabIndex = 2
        Me.txtSNoFrom.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 161
        Me.Label9.Text = "From S.Invoice No."
        '
        'btnSlsCode
        '
        Me.btnSlsCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSlsCode.ImageIndex = 0
        Me.btnSlsCode.Location = New System.Drawing.Point(205, 182)
        Me.btnSlsCode.Name = "btnSlsCode"
        Me.btnSlsCode.Size = New System.Drawing.Size(29, 25)
        Me.btnSlsCode.TabIndex = 11
        Me.btnSlsCode.Text = "..."
        Me.btnSlsCode.UseVisualStyleBackColor = True
        '
        'txtSlsCode
        '
        Me.txtSlsCode.Location = New System.Drawing.Point(122, 184)
        Me.txtSlsCode.Name = "txtSlsCode"
        Me.txtSlsCode.Size = New System.Drawing.Size(80, 20)
        Me.txtSlsCode.TabIndex = 10
        Me.txtSlsCode.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 188)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 158
        Me.Label4.Text = "Sales Code"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(214, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 157
        Me.Label5.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "From Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(241, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 13)
        Me.Label3.TabIndex = 154
        Me.Label3.Text = "Leave blank to select all"
        '
        'btnCustCodeTo
        '
        Me.btnCustCodeTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustCodeTo.ImageIndex = 0
        Me.btnCustCodeTo.Location = New System.Drawing.Point(205, 142)
        Me.btnCustCodeTo.Name = "btnCustCodeTo"
        Me.btnCustCodeTo.Size = New System.Drawing.Size(29, 25)
        Me.btnCustCodeTo.TabIndex = 9
        Me.btnCustCodeTo.Text = "..."
        Me.btnCustCodeTo.UseVisualStyleBackColor = True
        '
        'txtCCodeTo
        '
        Me.txtCCodeTo.Location = New System.Drawing.Point(122, 144)
        Me.txtCCodeTo.Name = "txtCCodeTo"
        Me.txtCCodeTo.Size = New System.Drawing.Size(80, 20)
        Me.txtCCodeTo.TabIndex = 8
        Me.txtCCodeTo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "To Customer Code"
        '
        'btnCustCodeFrom
        '
        Me.btnCustCodeFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustCodeFrom.ImageIndex = 0
        Me.btnCustCodeFrom.Location = New System.Drawing.Point(205, 113)
        Me.btnCustCodeFrom.Name = "btnCustCodeFrom"
        Me.btnCustCodeFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnCustCodeFrom.TabIndex = 7
        Me.btnCustCodeFrom.Text = "..."
        Me.btnCustCodeFrom.UseVisualStyleBackColor = True
        '
        'txtCCodeFrom
        '
        Me.txtCCodeFrom.Location = New System.Drawing.Point(122, 115)
        Me.txtCCodeFrom.Name = "txtCCodeFrom"
        Me.txtCCodeFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtCCodeFrom.TabIndex = 6
        Me.txtCCodeFrom.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(7, 119)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(105, 13)
        Me.Label37.TabIndex = 145
        Me.Label37.Text = "From Customer Code"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(121, 16)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(87, 20)
        Me.dtpFrom.TabIndex = 0
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(240, 15)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(87, 20)
        Me.dtpTo.TabIndex = 1
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Checked = True
        Me.rbAll.Location = New System.Drawing.Point(11, 10)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(68, 17)
        Me.rbAll.TabIndex = 0
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "Select all"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(173, 325)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(11, 325)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'rbPeriod
        '
        Me.rbPeriod.AutoSize = True
        Me.rbPeriod.Location = New System.Drawing.Point(11, 33)
        Me.rbPeriod.Name = "rbPeriod"
        Me.rbPeriod.Size = New System.Drawing.Size(47, 17)
        Me.rbPeriod.TabIndex = 1
        Me.rbPeriod.Text = "Filter"
        Me.rbPeriod.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(92, 325)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(340, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(176, 20)
        Me.Label6.TabIndex = 171
        Me.Label6.Text = "Sales Invoice Report"
        '
        'rptSlsInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 360)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.rbAll)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.rbPeriod)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label6)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptSlsInvoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Invoice"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSNoTo As System.Windows.Forms.Button
    Friend WithEvents txtSNoTo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnSNoFrom As System.Windows.Forms.Button
    Friend WithEvents txtSNoFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnSlsCode As System.Windows.Forms.Button
    Friend WithEvents txtSlsCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCustCodeTo As System.Windows.Forms.Button
    Friend WithEvents txtCCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCustCodeFrom As System.Windows.Forms.Button
    Friend WithEvents txtCCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbAll As System.Windows.Forms.RadioButton
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents rbPeriod As System.Windows.Forms.RadioButton
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
