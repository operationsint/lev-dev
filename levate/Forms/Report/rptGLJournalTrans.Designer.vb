<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptGLJournalTrans
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptGLJournalTrans))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.cbDate = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnNoTo = New System.Windows.Forms.Button()
        Me.txtJournalTo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnNoFrom = New System.Windows.Forms.Button()
        Me.txtJournalFrom = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cmbJournalTransTypeFrom = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbJournalTransTypeTo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCodeTo = New System.Windows.Forms.Button()
        Me.txtAccountTo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCodeFrom = New System.Windows.Forms.Button()
        Me.txtAccountFrom = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbOrderBy = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(348, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(167, 20)
        Me.Label6.TabIndex = 203
        Me.Label6.Text = "Journal Transaction"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(176, 269)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 202
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'cbDate
        '
        Me.cbDate.AutoSize = True
        Me.cbDate.Location = New System.Drawing.Point(10, 55)
        Me.cbDate.Name = "cbDate"
        Me.cbDate.Size = New System.Drawing.Size(75, 17)
        Me.cbDate.TabIndex = 172
        Me.cbDate.Text = "From Date"
        Me.cbDate.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(259, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 157
        Me.Label5.Text = "To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(329, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 13)
        Me.Label3.TabIndex = 154
        Me.Label3.Text = "Leave blank to select all"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(14, 269)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 200
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cmbOrderBy)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnCodeTo)
        Me.GroupBox1.Controls.Add(Me.txtAccountTo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnCodeFrom)
        Me.GroupBox1.Controls.Add(Me.txtAccountFrom)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbJournalTransTypeTo)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cmbJournalTransTypeFrom)
        Me.GroupBox1.Controls.Add(Me.cbDate)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnNoTo)
        Me.GroupBox1.Controls.Add(Me.txtJournalTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnNoFrom)
        Me.GroupBox1.Controls.Add(Me.txtJournalFrom)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 233)
        Me.GroupBox1.TabIndex = 199
        Me.GroupBox1.TabStop = False
        '
        'btnNoTo
        '
        Me.btnNoTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNoTo.ImageIndex = 0
        Me.btnNoTo.Location = New System.Drawing.Point(293, 105)
        Me.btnNoTo.Name = "btnNoTo"
        Me.btnNoTo.Size = New System.Drawing.Size(29, 25)
        Me.btnNoTo.TabIndex = 5
        Me.btnNoTo.Text = "..."
        Me.btnNoTo.UseVisualStyleBackColor = True
        '
        'txtJournalTo
        '
        Me.txtJournalTo.Location = New System.Drawing.Point(167, 107)
        Me.txtJournalTo.Name = "txtJournalTo"
        Me.txtJournalTo.Size = New System.Drawing.Size(117, 20)
        Me.txtJournalTo.TabIndex = 4
        Me.txtJournalTo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "To Journal No."
        '
        'btnNoFrom
        '
        Me.btnNoFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNoFrom.ImageIndex = 0
        Me.btnNoFrom.Location = New System.Drawing.Point(293, 76)
        Me.btnNoFrom.Name = "btnNoFrom"
        Me.btnNoFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnNoFrom.TabIndex = 3
        Me.btnNoFrom.Text = "..."
        Me.btnNoFrom.UseVisualStyleBackColor = True
        '
        'txtJournalFrom
        '
        Me.txtJournalFrom.Location = New System.Drawing.Point(167, 78)
        Me.txtJournalFrom.Name = "txtJournalFrom"
        Me.txtJournalFrom.Size = New System.Drawing.Size(117, 20)
        Me.txtJournalFrom.TabIndex = 2
        Me.txtJournalFrom.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(6, 82)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(87, 13)
        Me.Label37.TabIndex = 145
        Me.Label37.Text = "From Journal No."
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(166, 50)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(87, 20)
        Me.dtpFrom.TabIndex = 0
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(285, 49)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(87, 20)
        Me.dtpTo.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(95, 269)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 201
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cmbJournalTransTypeFrom
        '
        Me.cmbJournalTransTypeFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJournalTransTypeFrom.FormattingEnabled = True
        Me.cmbJournalTransTypeFrom.Location = New System.Drawing.Point(166, 19)
        Me.cmbJournalTransTypeFrom.Name = "cmbJournalTransTypeFrom"
        Me.cmbJournalTransTypeFrom.Size = New System.Drawing.Size(110, 21)
        Me.cmbJournalTransTypeFrom.TabIndex = 174
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 13)
        Me.Label7.TabIndex = 175
        Me.Label7.Text = "From Journal Trans Type"
        '
        'cmbJournalTransTypeTo
        '
        Me.cmbJournalTransTypeTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJournalTransTypeTo.FormattingEnabled = True
        Me.cmbJournalTransTypeTo.Location = New System.Drawing.Point(306, 19)
        Me.cmbJournalTransTypeTo.Name = "cmbJournalTransTypeTo"
        Me.cmbJournalTransTypeTo.Size = New System.Drawing.Size(110, 21)
        Me.cmbJournalTransTypeTo.TabIndex = 176
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(282, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 13)
        Me.Label4.TabIndex = 177
        Me.Label4.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(329, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 13)
        Me.Label2.TabIndex = 184
        Me.Label2.Text = "Leave blank to select all"
        '
        'btnCodeTo
        '
        Me.btnCodeTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCodeTo.ImageIndex = 0
        Me.btnCodeTo.Location = New System.Drawing.Point(293, 164)
        Me.btnCodeTo.Name = "btnCodeTo"
        Me.btnCodeTo.Size = New System.Drawing.Size(29, 25)
        Me.btnCodeTo.TabIndex = 181
        Me.btnCodeTo.Text = "..."
        Me.btnCodeTo.UseVisualStyleBackColor = True
        '
        'txtAccountTo
        '
        Me.txtAccountTo.Location = New System.Drawing.Point(167, 166)
        Me.txtAccountTo.Name = "txtAccountTo"
        Me.txtAccountTo.Size = New System.Drawing.Size(117, 20)
        Me.txtAccountTo.TabIndex = 180
        Me.txtAccountTo.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 170)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 13)
        Me.Label8.TabIndex = 183
        Me.Label8.Text = "To Account Code"
        '
        'btnCodeFrom
        '
        Me.btnCodeFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCodeFrom.ImageIndex = 0
        Me.btnCodeFrom.Location = New System.Drawing.Point(293, 135)
        Me.btnCodeFrom.Name = "btnCodeFrom"
        Me.btnCodeFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnCodeFrom.TabIndex = 179
        Me.btnCodeFrom.Text = "..."
        Me.btnCodeFrom.UseVisualStyleBackColor = True
        '
        'txtAccountFrom
        '
        Me.txtAccountFrom.Location = New System.Drawing.Point(167, 137)
        Me.txtAccountFrom.Name = "txtAccountFrom"
        Me.txtAccountFrom.Size = New System.Drawing.Size(117, 20)
        Me.txtAccountFrom.TabIndex = 178
        Me.txtAccountFrom.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 141)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 13)
        Me.Label9.TabIndex = 182
        Me.Label9.Text = "From Account Code"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 200)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 186
        Me.Label10.Text = "Order By"
        '
        'cmbOrderBy
        '
        Me.cmbOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrderBy.FormattingEnabled = True
        Me.cmbOrderBy.Location = New System.Drawing.Point(166, 197)
        Me.cmbOrderBy.Name = "cmbOrderBy"
        Me.cmbOrderBy.Size = New System.Drawing.Size(110, 21)
        Me.cmbOrderBy.TabIndex = 185
        '
        'rptGLJournalTrans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 302)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptGLJournalTrans"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Journal Transaction"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents cbDate As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNoTo As System.Windows.Forms.Button
    Friend WithEvents txtJournalTo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnNoFrom As System.Windows.Forms.Button
    Friend WithEvents txtJournalFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbJournalTransTypeTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbJournalTransTypeFrom As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCodeTo As System.Windows.Forms.Button
    Friend WithEvents txtAccountTo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnCodeFrom As System.Windows.Forms.Button
    Friend WithEvents txtAccountFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbOrderBy As System.Windows.Forms.ComboBox
End Class
