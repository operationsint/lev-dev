<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptPIncoming
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptPIncoming))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnPIncTo = New System.Windows.Forms.Button()
        Me.txtPIncTo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnPIncFrom = New System.Windows.Forms.Button()
        Me.txtPIncFrom = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnPchCode = New System.Windows.Forms.Button()
        Me.txtPchCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSupCodeTo = New System.Windows.Forms.Button()
        Me.txtSCodeTo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSupCodeFrom = New System.Windows.Forms.Button()
        Me.txtSCodeFrom = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.rbPeriod = New System.Windows.Forms.RadioButton()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnPIncTo)
        Me.GroupBox1.Controls.Add(Me.txtPIncTo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnPIncFrom)
        Me.GroupBox1.Controls.Add(Me.txtPIncFrom)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.btnPchCode)
        Me.GroupBox1.Controls.Add(Me.txtPchCode)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnSupCodeTo)
        Me.GroupBox1.Controls.Add(Me.txtSCodeTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnSupCodeFrom)
        Me.GroupBox1.Controls.Add(Me.txtSCodeFrom)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 62)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 217)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(241, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 13)
        Me.Label7.TabIndex = 167
        Me.Label7.Text = "Leave blank to select all"
        '
        'btnPIncTo
        '
        Me.btnPIncTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPIncTo.ImageIndex = 0
        Me.btnPIncTo.Location = New System.Drawing.Point(205, 67)
        Me.btnPIncTo.Name = "btnPIncTo"
        Me.btnPIncTo.Size = New System.Drawing.Size(29, 25)
        Me.btnPIncTo.TabIndex = 5
        Me.btnPIncTo.Text = "..."
        Me.btnPIncTo.UseVisualStyleBackColor = True
        '
        'txtPIncTo
        '
        Me.txtPIncTo.Location = New System.Drawing.Point(122, 69)
        Me.txtPIncTo.Name = "txtPIncTo"
        Me.txtPIncTo.Size = New System.Drawing.Size(80, 20)
        Me.txtPIncTo.TabIndex = 4
        Me.txtPIncTo.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 164
        Me.Label8.Text = "To P.Incoming No."
        '
        'btnPIncFrom
        '
        Me.btnPIncFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPIncFrom.ImageIndex = 0
        Me.btnPIncFrom.Location = New System.Drawing.Point(205, 38)
        Me.btnPIncFrom.Name = "btnPIncFrom"
        Me.btnPIncFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnPIncFrom.TabIndex = 3
        Me.btnPIncFrom.Text = "..."
        Me.btnPIncFrom.UseVisualStyleBackColor = True
        '
        'txtPIncFrom
        '
        Me.txtPIncFrom.Location = New System.Drawing.Point(122, 40)
        Me.txtPIncFrom.Name = "txtPIncFrom"
        Me.txtPIncFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtPIncFrom.TabIndex = 2
        Me.txtPIncFrom.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 13)
        Me.Label9.TabIndex = 161
        Me.Label9.Text = "From P.Incoming No."
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(241, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 13)
        Me.Label3.TabIndex = 154
        Me.Label3.Text = "Leave blank to select all"
        '
        'btnSupCodeTo
        '
        Me.btnSupCodeTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupCodeTo.ImageIndex = 0
        Me.btnSupCodeTo.Location = New System.Drawing.Point(205, 136)
        Me.btnSupCodeTo.Name = "btnSupCodeTo"
        Me.btnSupCodeTo.Size = New System.Drawing.Size(29, 25)
        Me.btnSupCodeTo.TabIndex = 9
        Me.btnSupCodeTo.Text = "..."
        Me.btnSupCodeTo.UseVisualStyleBackColor = True
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
        'btnSupCodeFrom
        '
        Me.btnSupCodeFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupCodeFrom.ImageIndex = 0
        Me.btnSupCodeFrom.Location = New System.Drawing.Point(205, 107)
        Me.btnSupCodeFrom.Name = "btnSupCodeFrom"
        Me.btnSupCodeFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnSupCodeFrom.TabIndex = 7
        Me.btnSupCodeFrom.Text = "..."
        Me.btnSupCodeFrom.UseVisualStyleBackColor = True
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
        'rbPeriod
        '
        Me.rbPeriod.AutoSize = True
        Me.rbPeriod.Location = New System.Drawing.Point(8, 39)
        Me.rbPeriod.Name = "rbPeriod"
        Me.rbPeriod.Size = New System.Drawing.Size(47, 17)
        Me.rbPeriod.TabIndex = 1
        Me.rbPeriod.Text = "Filter"
        Me.rbPeriod.UseVisualStyleBackColor = True
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Checked = True
        Me.rbAll.Location = New System.Drawing.Point(8, 16)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(68, 17)
        Me.rbAll.TabIndex = 0
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "Select all"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(89, 285)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(8, 285)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(170, 285)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(294, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(222, 20)
        Me.Label6.TabIndex = 157
        Me.Label6.Text = "Purchase Incoming Report"
        '
        'rptPIncoming
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 338)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.rbPeriod)
        Me.Controls.Add(Me.rbAll)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Label6)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptPIncoming"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Incoming"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPchCode As System.Windows.Forms.Button
    Friend WithEvents txtPchCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSupCodeTo As System.Windows.Forms.Button
    Friend WithEvents txtSCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSupCodeFrom As System.Windows.Forms.Button
    Friend WithEvents txtSCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbPeriod As System.Windows.Forms.RadioButton
    Friend WithEvents rbAll As System.Windows.Forms.RadioButton
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnPIncTo As System.Windows.Forms.Button
    Friend WithEvents txtPIncTo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnPIncFrom As System.Windows.Forms.Button
    Friend WithEvents txtPIncFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
