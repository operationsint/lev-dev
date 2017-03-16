<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptStkControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptStkControl))
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
        Me.cbUnitCostPerToday = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(337, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(178, 20)
        Me.Label6.TabIndex = 198
        Me.Label6.Text = "Stock Control Report"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbUnitCostPerToday)
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
        Me.GroupBox1.Location = New System.Drawing.Point(14, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 164)
        Me.GroupBox1.TabIndex = 0
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
        Me.Label2.Location = New System.Drawing.Point(7, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "Period"
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
        Me.dtpFrom.Location = New System.Drawing.Point(120, 10)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(87, 20)
        Me.dtpFrom.TabIndex = 0
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(13, 214)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(175, 214)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(94, 214)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cbUnitCostPerToday
        '
        Me.cbUnitCostPerToday.AutoSize = True
        Me.cbUnitCostPerToday.Location = New System.Drawing.Point(125, 133)
        Me.cbUnitCostPerToday.Name = "cbUnitCostPerToday"
        Me.cbUnitCostPerToday.Size = New System.Drawing.Size(135, 17)
        Me.cbUnitCostPerToday.TabIndex = 171
        Me.cbUnitCostPerToday.Text = "Unit Cost as Per Today"
        Me.cbUnitCostPerToday.UseVisualStyleBackColor = True
        '
        'rptStkControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 244)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptStkControl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Control"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
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
    Friend WithEvents btnStockCategory As System.Windows.Forms.Button
    Friend WithEvents txtStockCategory As System.Windows.Forms.TextBox
    Friend WithEvents cbUnitCostPerToday As System.Windows.Forms.CheckBox
End Class
