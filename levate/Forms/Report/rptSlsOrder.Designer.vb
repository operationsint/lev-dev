<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptSlsOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptSlsOrder))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCurrency = New System.Windows.Forms.Button()
        Me.txtCurrCode = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnSONOTo = New System.Windows.Forms.Button()
        Me.txtSONOTo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnSONOFrom = New System.Windows.Forms.Button()
        Me.txtSONOFrom = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCCodeFrom = New System.Windows.Forms.TextBox()
        Me.btnCustFrom = New System.Windows.Forms.Button()
        Me.btnCustTo = New System.Windows.Forms.Button()
        Me.txtCCodeTo = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.btnSlsCodeTo = New System.Windows.Forms.Button()
        Me.txtSlsCodeTo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSlsCodeFrom = New System.Windows.Forms.Button()
        Me.txtSlsCodeFrom = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.rbPeriod = New System.Windows.Forms.RadioButton()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnPrintDetail = New System.Windows.Forms.Button()
        Me.cbReqDeliveryDate = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpReqDelDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpReqDelDateTo = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(207, 16)
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(240, 164)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 13)
        Me.Label4.TabIndex = 155
        Me.Label4.Text = "Leave blank to select all"
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Location = New System.Drawing.Point(252, 423)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(240, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 13)
        Me.Label3.TabIndex = 154
        Me.Label3.Text = "Leave blank to select all"
        '
        'btnCurrency
        '
        Me.btnCurrency.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCurrency.ImageIndex = 0
        Me.btnCurrency.Location = New System.Drawing.Point(204, 158)
        Me.btnCurrency.Name = "btnCurrency"
        Me.btnCurrency.Size = New System.Drawing.Size(29, 25)
        Me.btnCurrency.TabIndex = 11
        Me.btnCurrency.Text = "..."
        Me.btnCurrency.UseVisualStyleBackColor = True
        '
        'txtCurrCode
        '
        Me.txtCurrCode.Location = New System.Drawing.Point(121, 161)
        Me.txtCurrCode.MaxLength = 50
        Me.txtCurrCode.Name = "txtCurrCode"
        Me.txtCurrCode.Size = New System.Drawing.Size(80, 20)
        Me.txtCurrCode.TabIndex = 10
        Me.txtCurrCode.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.dtpReqDelDateFrom)
        Me.GroupBox1.Controls.Add(Me.dtpReqDelDateTo)
        Me.GroupBox1.Controls.Add(Me.cbReqDeliveryDate)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.btnSONOTo)
        Me.GroupBox1.Controls.Add(Me.txtSONOTo)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.btnSONOFrom)
        Me.GroupBox1.Controls.Add(Me.txtSONOFrom)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cbStatus)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtCCodeFrom)
        Me.GroupBox1.Controls.Add(Me.btnCustFrom)
        Me.GroupBox1.Controls.Add(Me.btnCustTo)
        Me.GroupBox1.Controls.Add(Me.txtCCodeTo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnCurrency)
        Me.GroupBox1.Controls.Add(Me.txtCurrCode)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.btnSlsCodeTo)
        Me.GroupBox1.Controls.Add(Me.txtSlsCodeTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnSlsCodeFrom)
        Me.GroupBox1.Controls.Add(Me.txtSlsCodeFrom)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 356)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label13.Location = New System.Drawing.Point(240, 56)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 13)
        Me.Label13.TabIndex = 178
        Me.Label13.Text = "Leave blank to select all"
        '
        'btnSONOTo
        '
        Me.btnSONOTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSONOTo.ImageIndex = 0
        Me.btnSONOTo.Location = New System.Drawing.Point(204, 63)
        Me.btnSONOTo.Name = "btnSONOTo"
        Me.btnSONOTo.Size = New System.Drawing.Size(29, 25)
        Me.btnSONOTo.TabIndex = 5
        Me.btnSONOTo.Text = "..."
        Me.btnSONOTo.UseVisualStyleBackColor = True
        '
        'txtSONOTo
        '
        Me.txtSONOTo.Location = New System.Drawing.Point(121, 65)
        Me.txtSONOTo.MaxLength = 50
        Me.txtSONOTo.Name = "txtSONOTo"
        Me.txtSONOTo.Size = New System.Drawing.Size(80, 20)
        Me.txtSONOTo.TabIndex = 4
        Me.txtSONOTo.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 69)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 13)
        Me.Label11.TabIndex = 175
        Me.Label11.Text = "To Sales Order No."
        '
        'btnSONOFrom
        '
        Me.btnSONOFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSONOFrom.ImageIndex = 0
        Me.btnSONOFrom.Location = New System.Drawing.Point(204, 34)
        Me.btnSONOFrom.Name = "btnSONOFrom"
        Me.btnSONOFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnSONOFrom.TabIndex = 3
        Me.btnSONOFrom.Text = "..."
        Me.btnSONOFrom.UseVisualStyleBackColor = True
        '
        'txtSONOFrom
        '
        Me.txtSONOFrom.Location = New System.Drawing.Point(121, 36)
        Me.txtSONOFrom.MaxLength = 50
        Me.txtSONOFrom.Name = "txtSONOFrom"
        Me.txtSONOFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtSONOFrom.TabIndex = 2
        Me.txtSONOFrom.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(108, 13)
        Me.Label12.TabIndex = 172
        Me.Label12.Text = "From Sales Order No."
        '
        'cbStatus
        '
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Location = New System.Drawing.Point(116, 273)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(117, 21)
        Me.cbStatus.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 276)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 170
        Me.Label10.Text = "Status"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(239, 225)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 13)
        Me.Label7.TabIndex = 169
        Me.Label7.Text = "Leave blank to select all"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 208)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 13)
        Me.Label8.TabIndex = 163
        Me.Label8.Text = "From Customer Code"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 242)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 13)
        Me.Label9.TabIndex = 164
        Me.Label9.Text = "To Customer Code"
        '
        'txtCCodeFrom
        '
        Me.txtCCodeFrom.Location = New System.Drawing.Point(121, 205)
        Me.txtCCodeFrom.MaxLength = 50
        Me.txtCCodeFrom.Name = "txtCCodeFrom"
        Me.txtCCodeFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtCCodeFrom.TabIndex = 12
        Me.txtCCodeFrom.TabStop = False
        '
        'btnCustFrom
        '
        Me.btnCustFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustFrom.ImageIndex = 0
        Me.btnCustFrom.Location = New System.Drawing.Point(204, 202)
        Me.btnCustFrom.Name = "btnCustFrom"
        Me.btnCustFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnCustFrom.TabIndex = 13
        Me.btnCustFrom.Text = "..."
        Me.btnCustFrom.UseVisualStyleBackColor = True
        '
        'btnCustTo
        '
        Me.btnCustTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustTo.ImageIndex = 0
        Me.btnCustTo.Location = New System.Drawing.Point(204, 236)
        Me.btnCustTo.Name = "btnCustTo"
        Me.btnCustTo.Size = New System.Drawing.Size(29, 25)
        Me.btnCustTo.TabIndex = 15
        Me.btnCustTo.Text = "..."
        Me.btnCustTo.UseVisualStyleBackColor = True
        '
        'txtCCodeTo
        '
        Me.txtCCodeTo.Location = New System.Drawing.Point(121, 239)
        Me.txtCCodeTo.MaxLength = 50
        Me.txtCCodeTo.Name = "txtCCodeTo"
        Me.txtCCodeTo.Size = New System.Drawing.Size(80, 20)
        Me.txtCCodeTo.TabIndex = 14
        Me.txtCCodeTo.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(10, 164)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(77, 13)
        Me.Label27.TabIndex = 151
        Me.Label27.Text = "Currency Code"
        '
        'btnSlsCodeTo
        '
        Me.btnSlsCodeTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSlsCodeTo.ImageIndex = 0
        Me.btnSlsCodeTo.Location = New System.Drawing.Point(204, 122)
        Me.btnSlsCodeTo.Name = "btnSlsCodeTo"
        Me.btnSlsCodeTo.Size = New System.Drawing.Size(29, 25)
        Me.btnSlsCodeTo.TabIndex = 9
        Me.btnSlsCodeTo.Text = "..."
        Me.btnSlsCodeTo.UseVisualStyleBackColor = True
        '
        'txtSlsCodeTo
        '
        Me.txtSlsCodeTo.Location = New System.Drawing.Point(121, 124)
        Me.txtSlsCodeTo.MaxLength = 50
        Me.txtSlsCodeTo.Name = "txtSlsCodeTo"
        Me.txtSlsCodeTo.Size = New System.Drawing.Size(80, 20)
        Me.txtSlsCodeTo.TabIndex = 8
        Me.txtSlsCodeTo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "To Sales Code"
        '
        'btnSlsCodeFrom
        '
        Me.btnSlsCodeFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSlsCodeFrom.ImageIndex = 0
        Me.btnSlsCodeFrom.Location = New System.Drawing.Point(204, 93)
        Me.btnSlsCodeFrom.Name = "btnSlsCodeFrom"
        Me.btnSlsCodeFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnSlsCodeFrom.TabIndex = 7
        Me.btnSlsCodeFrom.Text = "..."
        Me.btnSlsCodeFrom.UseVisualStyleBackColor = True
        '
        'txtSlsCodeFrom
        '
        Me.txtSlsCodeFrom.Location = New System.Drawing.Point(121, 95)
        Me.txtSlsCodeFrom.MaxLength = 50
        Me.txtSlsCodeFrom.Name = "txtSlsCodeFrom"
        Me.txtSlsCodeFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtSlsCodeFrom.TabIndex = 6
        Me.txtSlsCodeFrom.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(6, 99)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(87, 13)
        Me.Label37.TabIndex = 145
        Me.Label37.Text = "From Sales Code"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(114, 10)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(87, 20)
        Me.dtpFrom.TabIndex = 0
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(233, 9)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(87, 20)
        Me.dtpTo.TabIndex = 1
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Checked = True
        Me.rbAll.Location = New System.Drawing.Point(12, 15)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(68, 17)
        Me.rbAll.TabIndex = 0
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "Select all"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'rbPeriod
        '
        Me.rbPeriod.AutoSize = True
        Me.rbPeriod.Location = New System.Drawing.Point(12, 38)
        Me.rbPeriod.Name = "rbPeriod"
        Me.rbPeriod.Size = New System.Drawing.Size(47, 17)
        Me.rbPeriod.TabIndex = 1
        Me.rbPeriod.Text = "Filter"
        Me.rbPeriod.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(12, 423)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(171, 423)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(351, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(164, 20)
        Me.Label6.TabIndex = 186
        Me.Label6.Text = "Sales Order Report"
        '
        'btnPrintDetail
        '
        Me.btnPrintDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintDetail.Location = New System.Drawing.Point(93, 423)
        Me.btnPrintDetail.Name = "btnPrintDetail"
        Me.btnPrintDetail.Size = New System.Drawing.Size(75, 23)
        Me.btnPrintDetail.TabIndex = 4
        Me.btnPrintDetail.Text = "Print Detail"
        Me.btnPrintDetail.UseVisualStyleBackColor = True
        '
        'cbReqDeliveryDate
        '
        Me.cbReqDeliveryDate.AutoSize = True
        Me.cbReqDeliveryDate.Location = New System.Drawing.Point(7, 310)
        Me.cbReqDeliveryDate.Name = "cbReqDeliveryDate"
        Me.cbReqDeliveryDate.Size = New System.Drawing.Size(90, 17)
        Me.cbReqDeliveryDate.TabIndex = 179
        Me.cbReqDeliveryDate.Text = "Delivery Date"
        Me.cbReqDeliveryDate.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(202, 312)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(20, 13)
        Me.Label14.TabIndex = 182
        Me.Label14.Text = "To"
        '
        'dtpReqDelDateFrom
        '
        Me.dtpReqDelDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReqDelDateFrom.Location = New System.Drawing.Point(109, 306)
        Me.dtpReqDelDateFrom.Name = "dtpReqDelDateFrom"
        Me.dtpReqDelDateFrom.Size = New System.Drawing.Size(87, 20)
        Me.dtpReqDelDateFrom.TabIndex = 180
        '
        'dtpReqDelDateTo
        '
        Me.dtpReqDelDateTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReqDelDateTo.Location = New System.Drawing.Point(228, 305)
        Me.dtpReqDelDateTo.Name = "dtpReqDelDateTo"
        Me.dtpReqDelDateTo.Size = New System.Drawing.Size(87, 20)
        Me.dtpReqDelDateTo.TabIndex = 181
        '
        'rptSlsOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 456)
        Me.Controls.Add(Me.btnPrintDetail)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.rbAll)
        Me.Controls.Add(Me.rbPeriod)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label6)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptSlsOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Order"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCurrency As System.Windows.Forms.Button
    Friend WithEvents txtCurrCode As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents btnSlsCodeTo As System.Windows.Forms.Button
    Friend WithEvents txtSlsCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSlsCodeFrom As System.Windows.Forms.Button
    Friend WithEvents txtSlsCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbPeriod As System.Windows.Forms.RadioButton
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents btnCustFrom As System.Windows.Forms.Button
    Friend WithEvents btnCustTo As System.Windows.Forms.Button
    Friend WithEvents txtCCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnPrintDetail As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnSONOTo As System.Windows.Forms.Button
    Friend WithEvents txtSONOTo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnSONOFrom As System.Windows.Forms.Button
    Friend WithEvents txtSONOFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpReqDelDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpReqDelDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbReqDeliveryDate As System.Windows.Forms.CheckBox
End Class
