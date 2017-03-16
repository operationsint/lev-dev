<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptSlsCustomerBalanceReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptSlsCustomerBalanceReport))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbBalanceUntil = New System.Windows.Forms.RadioButton()
        Me.rbInvoiceDate = New System.Windows.Forms.RadioButton()
        Me.cbExcludeZero = New System.Windows.Forms.CheckBox()
        Me.iYear = New System.Windows.Forms.TextBox()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSNoTo = New System.Windows.Forms.Button()
        Me.txtSNoTo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnSNoFrom = New System.Windows.Forms.Button()
        Me.txtSNoFrom = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCustCodeTo = New System.Windows.Forms.Button()
        Me.txtCCodeTo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCustCodeFrom = New System.Windows.Forms.Button()
        Me.txtCCodeFrom = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnPrintWithBeginning = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbBalanceUntil)
        Me.GroupBox1.Controls.Add(Me.rbInvoiceDate)
        Me.GroupBox1.Controls.Add(Me.cbExcludeZero)
        Me.GroupBox1.Controls.Add(Me.iYear)
        Me.GroupBox1.Controls.Add(Me.cmbMonth)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.cbStatus)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnSNoTo)
        Me.GroupBox1.Controls.Add(Me.txtSNoTo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnSNoFrom)
        Me.GroupBox1.Controls.Add(Me.txtSNoFrom)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnCustCodeTo)
        Me.GroupBox1.Controls.Add(Me.txtCCodeTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnCustCodeFrom)
        Me.GroupBox1.Controls.Add(Me.txtCCodeFrom)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 295)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'rbBalanceUntil
        '
        Me.rbBalanceUntil.AutoSize = True
        Me.rbBalanceUntil.Location = New System.Drawing.Point(10, 48)
        Me.rbBalanceUntil.Name = "rbBalanceUntil"
        Me.rbBalanceUntil.Size = New System.Drawing.Size(91, 17)
        Me.rbBalanceUntil.TabIndex = 181
        Me.rbBalanceUntil.Text = "Balance Until:"
        Me.rbBalanceUntil.UseVisualStyleBackColor = True
        '
        'rbInvoiceDate
        '
        Me.rbInvoiceDate.AutoSize = True
        Me.rbInvoiceDate.Checked = True
        Me.rbInvoiceDate.Location = New System.Drawing.Point(10, 18)
        Me.rbInvoiceDate.Name = "rbInvoiceDate"
        Me.rbInvoiceDate.Size = New System.Drawing.Size(115, 17)
        Me.rbInvoiceDate.TabIndex = 180
        Me.rbInvoiceDate.TabStop = True
        Me.rbInvoiceDate.Text = "Invoice Date From:"
        Me.rbInvoiceDate.UseVisualStyleBackColor = True
        '
        'cbExcludeZero
        '
        Me.cbExcludeZero.AutoSize = True
        Me.cbExcludeZero.Location = New System.Drawing.Point(10, 256)
        Me.cbExcludeZero.Name = "cbExcludeZero"
        Me.cbExcludeZero.Size = New System.Drawing.Size(131, 17)
        Me.cbExcludeZero.TabIndex = 179
        Me.cbExcludeZero.Text = "Exclude Zero Balance"
        Me.cbExcludeZero.UseVisualStyleBackColor = True
        '
        'iYear
        '
        Me.iYear.Location = New System.Drawing.Point(249, 45)
        Me.iYear.MaxLength = 4
        Me.iYear.Name = "iYear"
        Me.iYear.Size = New System.Drawing.Size(49, 20)
        Me.iYear.TabIndex = 178
        '
        'cmbMonth
        '
        Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Location = New System.Drawing.Point(142, 45)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(101, 21)
        Me.cmbMonth.TabIndex = 177
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(237, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 13)
        Me.Label4.TabIndex = 174
        Me.Label4.Text = "To"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(144, 16)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(87, 20)
        Me.dtpFrom.TabIndex = 173
        '
        'cbStatus
        '
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Location = New System.Drawing.Point(142, 213)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(113, 21)
        Me.cbStatus.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 221)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 172
        Me.Label10.Text = "Status"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(262, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 13)
        Me.Label7.TabIndex = 167
        Me.Label7.Text = "Leave blank to select all"
        '
        'btnSNoTo
        '
        Me.btnSNoTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSNoTo.ImageIndex = 0
        Me.btnSNoTo.Location = New System.Drawing.Point(226, 108)
        Me.btnSNoTo.Name = "btnSNoTo"
        Me.btnSNoTo.Size = New System.Drawing.Size(29, 25)
        Me.btnSNoTo.TabIndex = 5
        Me.btnSNoTo.Text = "..."
        Me.btnSNoTo.UseVisualStyleBackColor = True
        '
        'txtSNoTo
        '
        Me.txtSNoTo.Location = New System.Drawing.Point(143, 110)
        Me.txtSNoTo.Name = "txtSNoTo"
        Me.txtSNoTo.Size = New System.Drawing.Size(80, 20)
        Me.txtSNoTo.TabIndex = 4
        Me.txtSNoTo.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 114)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 164
        Me.Label8.Text = "To S.Invoice No."
        '
        'btnSNoFrom
        '
        Me.btnSNoFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSNoFrom.ImageIndex = 0
        Me.btnSNoFrom.Location = New System.Drawing.Point(226, 79)
        Me.btnSNoFrom.Name = "btnSNoFrom"
        Me.btnSNoFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnSNoFrom.TabIndex = 3
        Me.btnSNoFrom.Text = "..."
        Me.btnSNoFrom.UseVisualStyleBackColor = True
        '
        'txtSNoFrom
        '
        Me.txtSNoFrom.Location = New System.Drawing.Point(143, 81)
        Me.txtSNoFrom.Name = "txtSNoFrom"
        Me.txtSNoFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtSNoFrom.TabIndex = 2
        Me.txtSNoFrom.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 161
        Me.Label9.Text = "From S.Invoice No."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(262, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 13)
        Me.Label3.TabIndex = 154
        Me.Label3.Text = "Leave blank to select all"
        '
        'btnCustCodeTo
        '
        Me.btnCustCodeTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustCodeTo.ImageIndex = 0
        Me.btnCustCodeTo.Location = New System.Drawing.Point(226, 177)
        Me.btnCustCodeTo.Name = "btnCustCodeTo"
        Me.btnCustCodeTo.Size = New System.Drawing.Size(29, 25)
        Me.btnCustCodeTo.TabIndex = 9
        Me.btnCustCodeTo.Text = "..."
        Me.btnCustCodeTo.UseVisualStyleBackColor = True
        '
        'txtCCodeTo
        '
        Me.txtCCodeTo.Location = New System.Drawing.Point(143, 179)
        Me.txtCCodeTo.Name = "txtCCodeTo"
        Me.txtCCodeTo.Size = New System.Drawing.Size(80, 20)
        Me.txtCCodeTo.TabIndex = 8
        Me.txtCCodeTo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 183)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "To Customer Code"
        '
        'btnCustCodeFrom
        '
        Me.btnCustCodeFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustCodeFrom.ImageIndex = 0
        Me.btnCustCodeFrom.Location = New System.Drawing.Point(226, 148)
        Me.btnCustCodeFrom.Name = "btnCustCodeFrom"
        Me.btnCustCodeFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnCustCodeFrom.TabIndex = 7
        Me.btnCustCodeFrom.Text = "..."
        Me.btnCustCodeFrom.UseVisualStyleBackColor = True
        '
        'txtCCodeFrom
        '
        Me.txtCCodeFrom.Location = New System.Drawing.Point(143, 150)
        Me.txtCCodeFrom.Name = "txtCCodeFrom"
        Me.txtCCodeFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtCCodeFrom.TabIndex = 6
        Me.txtCCodeFrom.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(7, 154)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(105, 13)
        Me.Label37.TabIndex = 145
        Me.Label37.Text = "From Customer Code"
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(259, 16)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(87, 20)
        Me.dtpTo.TabIndex = 1
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(323, 335)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(12, 335)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(242, 335)
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
        Me.Label6.Location = New System.Drawing.Point(244, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(266, 20)
        Me.Label6.TabIndex = 171
        Me.Label6.Text = "Sales Customer Balance Report"
        '
        'btnPrintWithBeginning
        '
        Me.btnPrintWithBeginning.Location = New System.Drawing.Point(93, 335)
        Me.btnPrintWithBeginning.Name = "btnPrintWithBeginning"
        Me.btnPrintWithBeginning.Size = New System.Drawing.Size(141, 23)
        Me.btnPrintWithBeginning.TabIndex = 172
        Me.btnPrintWithBeginning.Text = "Print With Beginning"
        Me.btnPrintWithBeginning.UseVisualStyleBackColor = True
        '
        'rptSlsCustomerBalanceReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 370)
        Me.Controls.Add(Me.btnPrintWithBeginning)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label6)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptSlsCustomerBalanceReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Customer Balance Report"
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCustCodeTo As System.Windows.Forms.Button
    Friend WithEvents txtCCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCustCodeFrom As System.Windows.Forms.Button
    Friend WithEvents txtCCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbExcludeZero As System.Windows.Forms.CheckBox
    Friend WithEvents iYear As System.Windows.Forms.TextBox
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents rbBalanceUntil As System.Windows.Forms.RadioButton
    Friend WithEvents rbInvoiceDate As System.Windows.Forms.RadioButton
    Friend WithEvents btnPrintWithBeginning As System.Windows.Forms.Button
End Class
