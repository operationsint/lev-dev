<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptSlsStockSales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptSlsStockSales))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnStockCategory = New System.Windows.Forms.Button()
        Me.txtStockCategory = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBankCodeTo = New System.Windows.Forms.Button()
        Me.txtStockCodeTo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBankCodeFrom = New System.Windows.Forms.Button()
        Me.txtStockCodeFrom = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.chkEnabledDtp = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(344, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 20)
        Me.Label6.TabIndex = 203
        Me.Label6.Text = "Stock Sales Report"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkEnabledDtp)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Controls.Add(Me.btnStockCategory)
        Me.GroupBox1.Controls.Add(Me.txtStockCategory)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnBankCodeTo)
        Me.GroupBox1.Controls.Add(Me.txtStockCodeTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnBankCodeFrom)
        Me.GroupBox1.Controls.Add(Me.txtStockCodeFrom)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 130)
        Me.GroupBox1.TabIndex = 199
        Me.GroupBox1.TabStop = False
        '
        'btnStockCategory
        '
        Me.btnStockCategory.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockCategory.ImageIndex = 0
        Me.btnStockCategory.Location = New System.Drawing.Point(246, 98)
        Me.btnStockCategory.Name = "btnStockCategory"
        Me.btnStockCategory.Size = New System.Drawing.Size(29, 25)
        Me.btnStockCategory.TabIndex = 6
        Me.btnStockCategory.Text = "..."
        Me.btnStockCategory.UseVisualStyleBackColor = True
        '
        'txtStockCategory
        '
        Me.txtStockCategory.Location = New System.Drawing.Point(120, 100)
        Me.txtStockCategory.Name = "txtStockCategory"
        Me.txtStockCategory.Size = New System.Drawing.Size(117, 20)
        Me.txtStockCategory.TabIndex = 5
        Me.txtStockCategory.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 107)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 13)
        Me.Label10.TabIndex = 170
        Me.Label10.Text = "Stock Category"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "Period From"
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
        Me.btnBankCodeTo.TabIndex = 4
        Me.btnBankCodeTo.Text = "..."
        Me.btnBankCodeTo.UseVisualStyleBackColor = True
        '
        'txtStockCodeTo
        '
        Me.txtStockCodeTo.Location = New System.Drawing.Point(121, 67)
        Me.txtStockCodeTo.Name = "txtStockCodeTo"
        Me.txtStockCodeTo.Size = New System.Drawing.Size(117, 20)
        Me.txtStockCodeTo.TabIndex = 3
        Me.txtStockCodeTo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "To Stock Code"
        '
        'btnBankCodeFrom
        '
        Me.btnBankCodeFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBankCodeFrom.ImageIndex = 0
        Me.btnBankCodeFrom.Location = New System.Drawing.Point(247, 36)
        Me.btnBankCodeFrom.Name = "btnBankCodeFrom"
        Me.btnBankCodeFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnBankCodeFrom.TabIndex = 2
        Me.btnBankCodeFrom.Text = "..."
        Me.btnBankCodeFrom.UseVisualStyleBackColor = True
        '
        'txtStockCodeFrom
        '
        Me.txtStockCodeFrom.Location = New System.Drawing.Point(121, 38)
        Me.txtStockCodeFrom.Name = "txtStockCodeFrom"
        Me.txtStockCodeFrom.Size = New System.Drawing.Size(117, 20)
        Me.txtStockCodeFrom.TabIndex = 1
        Me.txtStockCodeFrom.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(6, 42)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(89, 13)
        Me.Label37.TabIndex = 145
        Me.Label37.Text = "From Stock Code"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(122, 10)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(87, 20)
        Me.dtpFrom.TabIndex = 0
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(22, 186)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 200
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(184, 186)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 202
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(103, 186)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 201
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(220, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 13)
        Me.Label4.TabIndex = 172
        Me.Label4.Text = "To"
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(246, 11)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(87, 20)
        Me.dtpTo.TabIndex = 171
        '
        'chkEnabledDtp
        '
        Me.chkEnabledDtp.AutoSize = True
        Me.chkEnabledDtp.Checked = True
        Me.chkEnabledDtp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEnabledDtp.Location = New System.Drawing.Point(20, 15)
        Me.chkEnabledDtp.Name = "chkEnabledDtp"
        Me.chkEnabledDtp.Size = New System.Drawing.Size(15, 14)
        Me.chkEnabledDtp.TabIndex = 173
        Me.chkEnabledDtp.UseVisualStyleBackColor = True
        '
        'rptSlsStockSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 226)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptSlsStockSales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Sales Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStockCategory As System.Windows.Forms.Button
    Friend WithEvents txtStockCategory As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBankCodeTo As System.Windows.Forms.Button
    Friend WithEvents txtStockCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBankCodeFrom As System.Windows.Forms.Button
    Friend WithEvents txtStockCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkEnabledDtp As System.Windows.Forms.CheckBox
End Class
