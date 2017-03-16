<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptGeneralLedgerReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptGeneralLedgerReport))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSearchPeriod = New System.Windows.Forms.Button()
        Me.txtPeriod = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbOrderBy = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCodeTo = New System.Windows.Forms.Button()
        Me.txtAccountTo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCodeFrom = New System.Windows.Forms.Button()
        Me.txtAccountFrom = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtAccCatFrom = New System.Windows.Forms.TextBox()
        Me.txtAccCatTo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAccCatFrom = New System.Windows.Forms.Button()
        Me.btnAccCatTo = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtAccSubCatFrom = New System.Windows.Forms.TextBox()
        Me.txtAccSubCatTo = New System.Windows.Forms.TextBox()
        Me.btnAccSubCatFrom = New System.Windows.Forms.Button()
        Me.btnAccSubCatTo = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(374, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 20)
        Me.Label6.TabIndex = 203
        Me.Label6.Text = "General Ledger"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(176, 289)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 202
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(14, 289)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 200
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.btnAccSubCatTo)
        Me.GroupBox1.Controls.Add(Me.btnAccSubCatFrom)
        Me.GroupBox1.Controls.Add(Me.txtAccSubCatTo)
        Me.GroupBox1.Controls.Add(Me.txtAccSubCatFrom)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnAccCatTo)
        Me.GroupBox1.Controls.Add(Me.btnAccCatFrom)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtAccCatTo)
        Me.GroupBox1.Controls.Add(Me.txtAccCatFrom)
        Me.GroupBox1.Controls.Add(Me.btnSearchPeriod)
        Me.GroupBox1.Controls.Add(Me.txtPeriod)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cmbOrderBy)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnCodeTo)
        Me.GroupBox1.Controls.Add(Me.txtAccountTo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnCodeFrom)
        Me.GroupBox1.Controls.Add(Me.txtAccountFrom)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 255)
        Me.GroupBox1.TabIndex = 199
        Me.GroupBox1.TabStop = False
        '
        'btnSearchPeriod
        '
        Me.btnSearchPeriod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchPeriod.ImageIndex = 0
        Me.btnSearchPeriod.Location = New System.Drawing.Point(293, 12)
        Me.btnSearchPeriod.Name = "btnSearchPeriod"
        Me.btnSearchPeriod.Size = New System.Drawing.Size(29, 25)
        Me.btnSearchPeriod.TabIndex = 188
        Me.btnSearchPeriod.Text = "..."
        Me.btnSearchPeriod.UseVisualStyleBackColor = True
        '
        'txtPeriod
        '
        Me.txtPeriod.Location = New System.Drawing.Point(166, 15)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(117, 20)
        Me.txtPeriod.TabIndex = 187
        Me.txtPeriod.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 225)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 186
        Me.Label10.Text = "Order By"
        Me.Label10.Visible = False
        '
        'cmbOrderBy
        '
        Me.cmbOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrderBy.FormattingEnabled = True
        Me.cmbOrderBy.Location = New System.Drawing.Point(166, 222)
        Me.cmbOrderBy.Name = "cmbOrderBy"
        Me.cmbOrderBy.Size = New System.Drawing.Size(110, 21)
        Me.cmbOrderBy.TabIndex = 185
        Me.cmbOrderBy.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(329, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 13)
        Me.Label2.TabIndex = 184
        Me.Label2.Text = "Leave blank to select all"
        '
        'btnCodeTo
        '
        Me.btnCodeTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCodeTo.ImageIndex = 0
        Me.btnCodeTo.Location = New System.Drawing.Point(293, 72)
        Me.btnCodeTo.Name = "btnCodeTo"
        Me.btnCodeTo.Size = New System.Drawing.Size(29, 25)
        Me.btnCodeTo.TabIndex = 181
        Me.btnCodeTo.Text = "..."
        Me.btnCodeTo.UseVisualStyleBackColor = True
        '
        'txtAccountTo
        '
        Me.txtAccountTo.Location = New System.Drawing.Point(167, 74)
        Me.txtAccountTo.Name = "txtAccountTo"
        Me.txtAccountTo.Size = New System.Drawing.Size(117, 20)
        Me.txtAccountTo.TabIndex = 180
        Me.txtAccountTo.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 13)
        Me.Label8.TabIndex = 183
        Me.Label8.Text = "To Account Code"
        '
        'btnCodeFrom
        '
        Me.btnCodeFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCodeFrom.ImageIndex = 0
        Me.btnCodeFrom.Location = New System.Drawing.Point(293, 43)
        Me.btnCodeFrom.Name = "btnCodeFrom"
        Me.btnCodeFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnCodeFrom.TabIndex = 179
        Me.btnCodeFrom.Text = "..."
        Me.btnCodeFrom.UseVisualStyleBackColor = True
        '
        'txtAccountFrom
        '
        Me.txtAccountFrom.Location = New System.Drawing.Point(167, 45)
        Me.txtAccountFrom.Name = "txtAccountFrom"
        Me.txtAccountFrom.Size = New System.Drawing.Size(117, 20)
        Me.txtAccountFrom.TabIndex = 178
        Me.txtAccountFrom.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 13)
        Me.Label9.TabIndex = 182
        Me.Label9.Text = "From Account Code"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 175
        Me.Label7.Text = "Period"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(95, 289)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 201
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtAccCatFrom
        '
        Me.txtAccCatFrom.Location = New System.Drawing.Point(167, 100)
        Me.txtAccCatFrom.Name = "txtAccCatFrom"
        Me.txtAccCatFrom.Size = New System.Drawing.Size(117, 20)
        Me.txtAccCatFrom.TabIndex = 204
        Me.txtAccCatFrom.TabStop = False
        '
        'txtAccCatTo
        '
        Me.txtAccCatTo.Location = New System.Drawing.Point(167, 126)
        Me.txtAccCatTo.Name = "txtAccCatTo"
        Me.txtAccCatTo.Size = New System.Drawing.Size(117, 20)
        Me.txtAccCatTo.TabIndex = 205
        Me.txtAccCatTo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 206
        Me.Label1.Text = "From Acc Cat Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 207
        Me.Label3.Text = "To Acc Cat Code"
        '
        'btnAccCatFrom
        '
        Me.btnAccCatFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAccCatFrom.ImageIndex = 0
        Me.btnAccCatFrom.Location = New System.Drawing.Point(293, 100)
        Me.btnAccCatFrom.Name = "btnAccCatFrom"
        Me.btnAccCatFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnAccCatFrom.TabIndex = 208
        Me.btnAccCatFrom.Text = "..."
        Me.btnAccCatFrom.UseVisualStyleBackColor = True
        '
        'btnAccCatTo
        '
        Me.btnAccCatTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAccCatTo.ImageIndex = 0
        Me.btnAccCatTo.Location = New System.Drawing.Point(293, 127)
        Me.btnAccCatTo.Name = "btnAccCatTo"
        Me.btnAccCatTo.Size = New System.Drawing.Size(29, 25)
        Me.btnAccCatTo.TabIndex = 209
        Me.btnAccCatTo.Text = "..."
        Me.btnAccCatTo.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(329, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 13)
        Me.Label4.TabIndex = 210
        Me.Label4.Text = "Leave blank to select all"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 13)
        Me.Label5.TabIndex = 211
        Me.Label5.Text = "From Acc Sub Cat Code"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 186)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(111, 13)
        Me.Label11.TabIndex = 212
        Me.Label11.Text = "To Acc Sub Cat Code"
        '
        'txtAccSubCatFrom
        '
        Me.txtAccSubCatFrom.Location = New System.Drawing.Point(167, 155)
        Me.txtAccSubCatFrom.Name = "txtAccSubCatFrom"
        Me.txtAccSubCatFrom.Size = New System.Drawing.Size(117, 20)
        Me.txtAccSubCatFrom.TabIndex = 213
        Me.txtAccSubCatFrom.TabStop = False
        '
        'txtAccSubCatTo
        '
        Me.txtAccSubCatTo.Location = New System.Drawing.Point(167, 181)
        Me.txtAccSubCatTo.Name = "txtAccSubCatTo"
        Me.txtAccSubCatTo.Size = New System.Drawing.Size(117, 20)
        Me.txtAccSubCatTo.TabIndex = 214
        Me.txtAccSubCatTo.TabStop = False
        '
        'btnAccSubCatFrom
        '
        Me.btnAccSubCatFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAccSubCatFrom.ImageIndex = 0
        Me.btnAccSubCatFrom.Location = New System.Drawing.Point(293, 153)
        Me.btnAccSubCatFrom.Name = "btnAccSubCatFrom"
        Me.btnAccSubCatFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnAccSubCatFrom.TabIndex = 215
        Me.btnAccSubCatFrom.Text = "..."
        Me.btnAccSubCatFrom.UseVisualStyleBackColor = True
        '
        'btnAccSubCatTo
        '
        Me.btnAccSubCatTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAccSubCatTo.ImageIndex = 0
        Me.btnAccSubCatTo.Location = New System.Drawing.Point(293, 178)
        Me.btnAccSubCatTo.Name = "btnAccSubCatTo"
        Me.btnAccSubCatTo.Size = New System.Drawing.Size(29, 25)
        Me.btnAccSubCatTo.TabIndex = 216
        Me.btnAccSubCatTo.Text = "..."
        Me.btnAccSubCatTo.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label12.Location = New System.Drawing.Point(329, 168)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(122, 13)
        Me.Label12.TabIndex = 217
        Me.Label12.Text = "Leave blank to select all"
        '
        'rptGeneralLedgerReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 324)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptGeneralLedgerReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "General Ledger"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCodeTo As System.Windows.Forms.Button
    Friend WithEvents txtAccountTo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnCodeFrom As System.Windows.Forms.Button
    Friend WithEvents txtAccountFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbOrderBy As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearchPeriod As System.Windows.Forms.Button
    Friend WithEvents txtPeriod As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAccCatTo As System.Windows.Forms.Button
    Friend WithEvents btnAccCatFrom As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAccCatTo As System.Windows.Forms.TextBox
    Friend WithEvents txtAccCatFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnAccSubCatTo As System.Windows.Forms.Button
    Friend WithEvents btnAccSubCatFrom As System.Windows.Forms.Button
    Friend WithEvents txtAccSubCatTo As System.Windows.Forms.TextBox
    Friend WithEvents txtAccSubCatFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
