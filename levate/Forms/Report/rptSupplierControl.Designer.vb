<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptSupplierControl
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSCode = New System.Windows.Forms.TextBox()
        Me.btnSupplierFrom = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnSearchPeriodTo = New System.Windows.Forms.Button()
        Me.txtPeriodTo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSearchPeriodFrom = New System.Windows.Forms.Button()
        Me.txtPeriodFrom = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(210, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(198, 20)
        Me.Label8.TabIndex = 159
        Me.Label8.Text = "Supplier Control Report"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(188, 137)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 23)
        Me.Button1.TabIndex = 157
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 158
        Me.Label1.Text = "Supplier Code*"
        '
        'txtSCode
        '
        Me.txtSCode.Location = New System.Drawing.Point(105, 46)
        Me.txtSCode.Name = "txtSCode"
        Me.txtSCode.Size = New System.Drawing.Size(117, 20)
        Me.txtSCode.TabIndex = 153
        Me.txtSCode.TabStop = False
        '
        'btnSupplierFrom
        '
        Me.btnSupplierFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupplierFrom.ImageIndex = 0
        Me.btnSupplierFrom.Location = New System.Drawing.Point(232, 43)
        Me.btnSupplierFrom.Name = "btnSupplierFrom"
        Me.btnSupplierFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnSupplierFrom.TabIndex = 154
        Me.btnSupplierFrom.Text = "..."
        Me.btnSupplierFrom.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(102, 137)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 23)
        Me.btnClose.TabIndex = 156
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(16, 137)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(80, 23)
        Me.btnPrint.TabIndex = 155
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnSearchPeriodTo
        '
        Me.btnSearchPeriodTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchPeriodTo.ImageIndex = 0
        Me.btnSearchPeriodTo.Location = New System.Drawing.Point(232, 95)
        Me.btnSearchPeriodTo.Name = "btnSearchPeriodTo"
        Me.btnSearchPeriodTo.Size = New System.Drawing.Size(29, 25)
        Me.btnSearchPeriodTo.TabIndex = 193
        Me.btnSearchPeriodTo.Text = "..."
        Me.btnSearchPeriodTo.UseVisualStyleBackColor = True
        '
        'txtPeriodTo
        '
        Me.txtPeriodTo.Location = New System.Drawing.Point(106, 98)
        Me.txtPeriodTo.Name = "txtPeriodTo"
        Me.txtPeriodTo.Size = New System.Drawing.Size(116, 20)
        Me.txtPeriodTo.TabIndex = 192
        Me.txtPeriodTo.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 195
        Me.Label2.Text = "To Period"
        '
        'btnSearchPeriodFrom
        '
        Me.btnSearchPeriodFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchPeriodFrom.ImageIndex = 0
        Me.btnSearchPeriodFrom.Location = New System.Drawing.Point(232, 69)
        Me.btnSearchPeriodFrom.Name = "btnSearchPeriodFrom"
        Me.btnSearchPeriodFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnSearchPeriodFrom.TabIndex = 191
        Me.btnSearchPeriodFrom.Text = "..."
        Me.btnSearchPeriodFrom.UseVisualStyleBackColor = True
        '
        'txtPeriodFrom
        '
        Me.txtPeriodFrom.Location = New System.Drawing.Point(105, 72)
        Me.txtPeriodFrom.Name = "txtPeriodFrom"
        Me.txtPeriodFrom.Size = New System.Drawing.Size(117, 20)
        Me.txtPeriodFrom.TabIndex = 190
        Me.txtPeriodFrom.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 194
        Me.Label7.Text = "From Period"
        '
        'rptSupplierControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 175)
        Me.Controls.Add(Me.btnSearchPeriodTo)
        Me.Controls.Add(Me.txtPeriodTo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSearchPeriodFrom)
        Me.Controls.Add(Me.txtPeriodFrom)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSCode)
        Me.Controls.Add(Me.btnSupplierFrom)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPrint)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "rptSupplierControl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Supplier Control Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSCode As System.Windows.Forms.TextBox
    Friend WithEvents btnSupplierFrom As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnSearchPeriodTo As System.Windows.Forms.Button
    Friend WithEvents txtPeriodTo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSearchPeriodFrom As System.Windows.Forms.Button
    Friend WithEvents txtPeriodFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
