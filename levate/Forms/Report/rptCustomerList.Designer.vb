<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptCustomerList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptCustomerList))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCCodeFrom = New System.Windows.Forms.TextBox()
        Me.btnCustFrom = New System.Windows.Forms.Button()
        Me.btnCustTo = New System.Windows.Forms.Button()
        Me.txtCCodeTo = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(352, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 20)
        Me.Label8.TabIndex = 163
        Me.Label8.Text = "Customer List"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(243, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 13)
        Me.Label3.TabIndex = 162
        Me.Label3.Text = "Leave the field blank to select all"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(185, 121)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = "From Customer Code*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 154
        Me.Label2.Text = "To Customer Code*"
        '
        'txtCCodeFrom
        '
        Me.txtCCodeFrom.Location = New System.Drawing.Point(122, 43)
        Me.txtCCodeFrom.MaxLength = 50
        Me.txtCCodeFrom.Name = "txtCCodeFrom"
        Me.txtCCodeFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtCCodeFrom.TabIndex = 0
        Me.txtCCodeFrom.TabStop = False
        '
        'btnCustFrom
        '
        Me.btnCustFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustFrom.ImageIndex = 0
        Me.btnCustFrom.Location = New System.Drawing.Point(208, 40)
        Me.btnCustFrom.Name = "btnCustFrom"
        Me.btnCustFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnCustFrom.TabIndex = 1
        Me.btnCustFrom.Text = "..."
        Me.btnCustFrom.UseVisualStyleBackColor = True
        '
        'btnCustTo
        '
        Me.btnCustTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustTo.ImageIndex = 0
        Me.btnCustTo.Location = New System.Drawing.Point(208, 74)
        Me.btnCustTo.Name = "btnCustTo"
        Me.btnCustTo.Size = New System.Drawing.Size(29, 25)
        Me.btnCustTo.TabIndex = 3
        Me.btnCustTo.Text = "..."
        Me.btnCustTo.UseVisualStyleBackColor = True
        '
        'txtCCodeTo
        '
        Me.txtCCodeTo.Location = New System.Drawing.Point(122, 77)
        Me.txtCCodeTo.MaxLength = 50
        Me.txtCCodeTo.Name = "txtCCodeTo"
        Me.txtCCodeTo.Size = New System.Drawing.Size(80, 20)
        Me.txtCCodeTo.TabIndex = 2
        Me.txtCCodeTo.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(99, 121)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 23)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(13, 121)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(80, 23)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'rptCustomerList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 153)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCCodeFrom)
        Me.Controls.Add(Me.btnCustFrom)
        Me.Controls.Add(Me.btnCustTo)
        Me.Controls.Add(Me.txtCCodeTo)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPrint)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptCustomerList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer List"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents btnCustFrom As System.Windows.Forms.Button
    Friend WithEvents btnCustTo As System.Windows.Forms.Button
    Friend WithEvents txtCCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
End Class
