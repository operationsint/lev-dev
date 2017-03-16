<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptSupplierList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptSupplierList))
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtSCodeTo = New System.Windows.Forms.TextBox()
        Me.btnSupplierTo = New System.Windows.Forms.Button()
        Me.btnSupplierFrom = New System.Windows.Forms.Button()
        Me.txtSCodeFrom = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(14, 121)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(80, 23)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(100, 121)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 23)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtSCodeTo
        '
        Me.txtSCodeTo.Location = New System.Drawing.Point(123, 77)
        Me.txtSCodeTo.Name = "txtSCodeTo"
        Me.txtSCodeTo.Size = New System.Drawing.Size(80, 20)
        Me.txtSCodeTo.TabIndex = 2
        Me.txtSCodeTo.TabStop = False
        '
        'btnSupplierTo
        '
        Me.btnSupplierTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupplierTo.ImageIndex = 0
        Me.btnSupplierTo.Location = New System.Drawing.Point(209, 74)
        Me.btnSupplierTo.Name = "btnSupplierTo"
        Me.btnSupplierTo.Size = New System.Drawing.Size(29, 25)
        Me.btnSupplierTo.TabIndex = 3
        Me.btnSupplierTo.Text = "..."
        Me.btnSupplierTo.UseVisualStyleBackColor = True
        '
        'btnSupplierFrom
        '
        Me.btnSupplierFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupplierFrom.ImageIndex = 0
        Me.btnSupplierFrom.Location = New System.Drawing.Point(209, 40)
        Me.btnSupplierFrom.Name = "btnSupplierFrom"
        Me.btnSupplierFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnSupplierFrom.TabIndex = 1
        Me.btnSupplierFrom.Text = "..."
        Me.btnSupplierFrom.UseVisualStyleBackColor = True
        '
        'txtSCodeFrom
        '
        Me.txtSCodeFrom.Location = New System.Drawing.Point(123, 43)
        Me.txtSCodeFrom.Name = "txtSCodeFrom"
        Me.txtSCodeFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtSCodeFrom.TabIndex = 0
        Me.txtSCodeFrom.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "To Supplier Code*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "From Supplier Code*"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(186, 121)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(244, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Leave the field blank to select all"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(363, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 20)
        Me.Label8.TabIndex = 152
        Me.Label8.Text = "Supplier List"
        '
        'rptSupplierList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 153)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSCodeFrom)
        Me.Controls.Add(Me.btnSupplierFrom)
        Me.Controls.Add(Me.btnSupplierTo)
        Me.Controls.Add(Me.txtSCodeTo)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPrint)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptSupplierList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Supplier List"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtSCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents btnSupplierTo As System.Windows.Forms.Button
    Friend WithEvents btnSupplierFrom As System.Windows.Forms.Button
    Friend WithEvents txtSCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
