<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptWorkOrderControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptWorkOrderControl))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnLocation = New System.Windows.Forms.Button()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnStkCodeTo = New System.Windows.Forms.Button()
        Me.txtStkCodeTo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnStkCodeFrom = New System.Windows.Forms.Button()
        Me.txtStkCodeFrom = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbDate = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBankCodeTo = New System.Windows.Forms.Button()
        Me.txtWOTo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBankCodeFrom = New System.Windows.Forms.Button()
        Me.txtWOFrom = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ButtonPrint2 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(324, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(163, 20)
        Me.Label6.TabIndex = 198
        Me.Label6.Text = "Work Order Control"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cbStatus)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnLocation)
        Me.GroupBox1.Controls.Add(Me.txtLocation)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnStkCodeTo)
        Me.GroupBox1.Controls.Add(Me.txtStkCodeTo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnStkCodeFrom)
        Me.GroupBox1.Controls.Add(Me.txtStkCodeFrom)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbDate)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnBankCodeTo)
        Me.GroupBox1.Controls.Add(Me.txtWOTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnBankCodeFrom)
        Me.GroupBox1.Controls.Add(Me.txtWOFrom)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 219)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 157)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 182
        Me.Label8.Text = "Location Code"
        '
        'btnLocation
        '
        Me.btnLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLocation.ImageIndex = 0
        Me.btnLocation.Location = New System.Drawing.Point(203, 152)
        Me.btnLocation.Name = "btnLocation"
        Me.btnLocation.Size = New System.Drawing.Size(29, 25)
        Me.btnLocation.TabIndex = 181
        Me.btnLocation.Text = "..."
        Me.btnLocation.UseVisualStyleBackColor = True
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(120, 154)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(80, 20)
        Me.txtLocation.TabIndex = 180
        Me.txtLocation.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(239, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(223, 13)
        Me.Label2.TabIndex = 179
        Me.Label2.Text = "To select all stock code do not enter the field "
        '
        'btnStkCodeTo
        '
        Me.btnStkCodeTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStkCodeTo.ImageIndex = 0
        Me.btnStkCodeTo.Location = New System.Drawing.Point(203, 122)
        Me.btnStkCodeTo.Name = "btnStkCodeTo"
        Me.btnStkCodeTo.Size = New System.Drawing.Size(29, 25)
        Me.btnStkCodeTo.TabIndex = 176
        Me.btnStkCodeTo.Text = "..."
        Me.btnStkCodeTo.UseVisualStyleBackColor = True
        '
        'txtStkCodeTo
        '
        Me.txtStkCodeTo.Location = New System.Drawing.Point(120, 124)
        Me.txtStkCodeTo.Name = "txtStkCodeTo"
        Me.txtStkCodeTo.Size = New System.Drawing.Size(80, 20)
        Me.txtStkCodeTo.TabIndex = 175
        Me.txtStkCodeTo.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 178
        Me.Label4.Text = "To Stock Code"
        '
        'btnStkCodeFrom
        '
        Me.btnStkCodeFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStkCodeFrom.ImageIndex = 0
        Me.btnStkCodeFrom.Location = New System.Drawing.Point(203, 93)
        Me.btnStkCodeFrom.Name = "btnStkCodeFrom"
        Me.btnStkCodeFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnStkCodeFrom.TabIndex = 174
        Me.btnStkCodeFrom.Text = "..."
        Me.btnStkCodeFrom.UseVisualStyleBackColor = True
        '
        'txtStkCodeFrom
        '
        Me.txtStkCodeFrom.Location = New System.Drawing.Point(120, 95)
        Me.txtStkCodeFrom.Name = "txtStkCodeFrom"
        Me.txtStkCodeFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtStkCodeFrom.TabIndex = 173
        Me.txtStkCodeFrom.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 177
        Me.Label7.Text = "From Stock Code"
        '
        'cbDate
        '
        Me.cbDate.AutoSize = True
        Me.cbDate.Location = New System.Drawing.Point(10, 15)
        Me.cbDate.Name = "cbDate"
        Me.cbDate.Size = New System.Drawing.Size(75, 17)
        Me.cbDate.TabIndex = 172
        Me.cbDate.Text = "From Date"
        Me.cbDate.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(213, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 157
        Me.Label5.Text = "To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(283, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 13)
        Me.Label3.TabIndex = 154
        Me.Label3.Text = "Leave blank to select all"
        '
        'btnBankCodeTo
        '
        Me.btnBankCodeTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBankCodeTo.ImageIndex = 0
        Me.btnBankCodeTo.Location = New System.Drawing.Point(247, 65)
        Me.btnBankCodeTo.Name = "btnBankCodeTo"
        Me.btnBankCodeTo.Size = New System.Drawing.Size(29, 25)
        Me.btnBankCodeTo.TabIndex = 5
        Me.btnBankCodeTo.Text = "..."
        Me.btnBankCodeTo.UseVisualStyleBackColor = True
        '
        'txtWOTo
        '
        Me.txtWOTo.Location = New System.Drawing.Point(121, 67)
        Me.txtWOTo.Name = "txtWOTo"
        Me.txtWOTo.Size = New System.Drawing.Size(117, 20)
        Me.txtWOTo.TabIndex = 4
        Me.txtWOTo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "To Work Order No."
        '
        'btnBankCodeFrom
        '
        Me.btnBankCodeFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBankCodeFrom.ImageIndex = 0
        Me.btnBankCodeFrom.Location = New System.Drawing.Point(247, 36)
        Me.btnBankCodeFrom.Name = "btnBankCodeFrom"
        Me.btnBankCodeFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnBankCodeFrom.TabIndex = 3
        Me.btnBankCodeFrom.Text = "..."
        Me.btnBankCodeFrom.UseVisualStyleBackColor = True
        '
        'txtWOFrom
        '
        Me.txtWOFrom.Location = New System.Drawing.Point(121, 38)
        Me.txtWOFrom.Name = "txtWOFrom"
        Me.txtWOFrom.Size = New System.Drawing.Size(117, 20)
        Me.txtWOFrom.TabIndex = 2
        Me.txtWOFrom.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(6, 42)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(108, 13)
        Me.Label37.TabIndex = 145
        Me.Label37.Text = "From Work Order No."
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(120, 10)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(87, 20)
        Me.dtpFrom.TabIndex = 0
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(239, 9)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(87, 20)
        Me.dtpTo.TabIndex = 1
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(11, 263)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(98, 23)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "Print by Stock"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(317, 263)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(236, 263)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'ButtonPrint2
        '
        Me.ButtonPrint2.Location = New System.Drawing.Point(115, 263)
        Me.ButtonPrint2.Name = "ButtonPrint2"
        Me.ButtonPrint2.Size = New System.Drawing.Size(98, 23)
        Me.ButtonPrint2.TabIndex = 199
        Me.ButtonPrint2.Text = "Print by Location"
        Me.ButtonPrint2.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 186)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 184
        Me.Label9.Text = "Status"
        '
        'cbStatus
        '
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Location = New System.Drawing.Point(120, 183)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(118, 21)
        Me.cbStatus.TabIndex = 183
        '
        'rptWorkOrderControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 299)
        Me.Controls.Add(Me.ButtonPrint2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptWorkOrderControl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Work Order Control"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBankCodeTo As System.Windows.Forms.Button
    Friend WithEvents txtWOTo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBankCodeFrom As System.Windows.Forms.Button
    Friend WithEvents txtWOFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cbDate As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnStkCodeTo As System.Windows.Forms.Button
    Friend WithEvents txtStkCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnStkCodeFrom As System.Windows.Forms.Button
    Friend WithEvents txtStkCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnLocation As System.Windows.Forms.Button
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents ButtonPrint2 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
End Class
