<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptPInvoiceSum
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptPInvoiceSum))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chbDate = New System.Windows.Forms.CheckBox()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnPNoTo = New System.Windows.Forms.Button()
        Me.txtPNoTo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnPNoFrom = New System.Windows.Forms.Button()
        Me.txtPNoFrom = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnPchCode = New System.Windows.Forms.Button()
        Me.txtPchCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSCodeTo = New System.Windows.Forms.Button()
        Me.txtSCodeTo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSCodeFrom = New System.Windows.Forms.Button()
        Me.txtSCodeFrom = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chbDate)
        Me.GroupBox1.Controls.Add(Me.cbStatus)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnPNoTo)
        Me.GroupBox1.Controls.Add(Me.txtPNoTo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnPNoFrom)
        Me.GroupBox1.Controls.Add(Me.txtPNoFrom)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.btnPchCode)
        Me.GroupBox1.Controls.Add(Me.txtPchCode)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnSCodeTo)
        Me.GroupBox1.Controls.Add(Me.txtSCodeTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnSCodeFrom)
        Me.GroupBox1.Controls.Add(Me.txtSCodeFrom)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 277)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'chbDate
        '
        Me.chbDate.AutoSize = True
        Me.chbDate.Location = New System.Drawing.Point(10, 13)
        Me.chbDate.Name = "chbDate"
        Me.chbDate.Size = New System.Drawing.Size(75, 17)
        Me.chbDate.TabIndex = 175
        Me.chbDate.Text = "From Date"
        Me.chbDate.UseVisualStyleBackColor = True
        '
        'cbStatus
        '
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Location = New System.Drawing.Point(122, 211)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(112, 21)
        Me.cbStatus.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 214)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 172
        Me.Label10.Text = "Status"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(241, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(162, 13)
        Me.Label7.TabIndex = 167
        Me.Label7.Text = "To select all leave the field blank"
        '
        'btnPNoTo
        '
        Me.btnPNoTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPNoTo.ImageIndex = 0
        Me.btnPNoTo.Location = New System.Drawing.Point(205, 67)
        Me.btnPNoTo.Name = "btnPNoTo"
        Me.btnPNoTo.Size = New System.Drawing.Size(29, 25)
        Me.btnPNoTo.TabIndex = 5
        Me.btnPNoTo.Text = "..."
        Me.btnPNoTo.UseVisualStyleBackColor = True
        '
        'txtPNoTo
        '
        Me.txtPNoTo.Location = New System.Drawing.Point(122, 69)
        Me.txtPNoTo.Name = "txtPNoTo"
        Me.txtPNoTo.Size = New System.Drawing.Size(80, 20)
        Me.txtPNoTo.TabIndex = 4
        Me.txtPNoTo.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 164
        Me.Label8.Text = "To P.Invoice No."
        '
        'btnPNoFrom
        '
        Me.btnPNoFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPNoFrom.ImageIndex = 0
        Me.btnPNoFrom.Location = New System.Drawing.Point(205, 38)
        Me.btnPNoFrom.Name = "btnPNoFrom"
        Me.btnPNoFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnPNoFrom.TabIndex = 3
        Me.btnPNoFrom.Text = "..."
        Me.btnPNoFrom.UseVisualStyleBackColor = True
        '
        'txtPNoFrom
        '
        Me.txtPNoFrom.Location = New System.Drawing.Point(122, 40)
        Me.txtPNoFrom.Name = "txtPNoFrom"
        Me.txtPNoFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtPNoFrom.TabIndex = 2
        Me.txtPNoFrom.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 161
        Me.Label9.Text = "From P.Invoice No."
        '
        'btnPchCode
        '
        Me.btnPchCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPchCode.ImageIndex = 0
        Me.btnPchCode.Location = New System.Drawing.Point(205, 176)
        Me.btnPchCode.Name = "btnPchCode"
        Me.btnPchCode.Size = New System.Drawing.Size(29, 25)
        Me.btnPchCode.TabIndex = 11
        Me.btnPchCode.Text = "..."
        Me.btnPchCode.UseVisualStyleBackColor = True
        '
        'txtPchCode
        '
        Me.txtPchCode.Location = New System.Drawing.Point(122, 178)
        Me.txtPchCode.Name = "txtPchCode"
        Me.txtPchCode.Size = New System.Drawing.Size(80, 20)
        Me.txtPchCode.TabIndex = 10
        Me.txtPchCode.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 158
        Me.Label4.Text = "Purchase Code"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(215, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 157
        Me.Label5.Text = "To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(241, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 13)
        Me.Label3.TabIndex = 154
        Me.Label3.Text = "To select all leave the field blank"
        '
        'btnSCodeTo
        '
        Me.btnSCodeTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSCodeTo.ImageIndex = 0
        Me.btnSCodeTo.Location = New System.Drawing.Point(205, 136)
        Me.btnSCodeTo.Name = "btnSCodeTo"
        Me.btnSCodeTo.Size = New System.Drawing.Size(29, 25)
        Me.btnSCodeTo.TabIndex = 9
        Me.btnSCodeTo.Text = "..."
        Me.btnSCodeTo.UseVisualStyleBackColor = True
        '
        'txtSCodeTo
        '
        Me.txtSCodeTo.Location = New System.Drawing.Point(122, 138)
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
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "To Supplier Code"
        '
        'btnSCodeFrom
        '
        Me.btnSCodeFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSCodeFrom.ImageIndex = 0
        Me.btnSCodeFrom.Location = New System.Drawing.Point(205, 107)
        Me.btnSCodeFrom.Name = "btnSCodeFrom"
        Me.btnSCodeFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnSCodeFrom.TabIndex = 7
        Me.btnSCodeFrom.Text = "..."
        Me.btnSCodeFrom.UseVisualStyleBackColor = True
        '
        'txtSCodeFrom
        '
        Me.txtSCodeFrom.Location = New System.Drawing.Point(122, 109)
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
        Me.Label37.Size = New System.Drawing.Size(99, 13)
        Me.Label37.TabIndex = 145
        Me.Label37.Text = "From Supplier Code"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(122, 10)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(87, 20)
        Me.dtpFrom.TabIndex = 0
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(241, 9)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(87, 20)
        Me.dtpTo.TabIndex = 1
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(15, 325)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(177, 325)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(96, 325)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(291, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(225, 20)
        Me.Label6.TabIndex = 178
        Me.Label6.Text = "Purchase Invoice Summary"
        '
        'rptPInvoiceSum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 366)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label6)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptPInvoiceSum"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Invoice Summary"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnPNoTo As System.Windows.Forms.Button
    Friend WithEvents txtPNoTo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnPNoFrom As System.Windows.Forms.Button
    Friend WithEvents txtPNoFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnPchCode As System.Windows.Forms.Button
    Friend WithEvents txtPchCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSCodeTo As System.Windows.Forms.Button
    Friend WithEvents txtSCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSCodeFrom As System.Windows.Forms.Button
    Friend WithEvents txtSCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chbDate As System.Windows.Forms.CheckBox
End Class
