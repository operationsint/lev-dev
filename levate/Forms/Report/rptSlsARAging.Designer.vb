<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptSlsARAging
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptSlsARAging))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.txtCCodeFrom = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnCustFrom = New System.Windows.Forms.Button()
        Me.btnCustTo = New System.Windows.Forms.Button()
        Me.txtCCodeTo = New System.Windows.Forms.TextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.btnCurrency = New System.Windows.Forms.Button()
        Me.txtCurrCode = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(245, 103)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 13)
        Me.Label7.TabIndex = 207
        Me.Label7.Text = "Leave blank to select all"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 13)
        Me.Label8.TabIndex = 201
        Me.Label8.Text = "From Customer Code"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(284, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(145, 20)
        Me.Label6.TabIndex = 211
        Me.Label6.Text = "AR Aging Report"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 13)
        Me.Label9.TabIndex = 202
        Me.Label9.Text = "To Customer Code"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(19, 190)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'txtCCodeFrom
        '
        Me.txtCCodeFrom.Location = New System.Drawing.Point(127, 83)
        Me.txtCCodeFrom.MaxLength = 50
        Me.txtCCodeFrom.Name = "txtCCodeFrom"
        Me.txtCCodeFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtCCodeFrom.TabIndex = 1
        Me.txtCCodeFrom.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(100, 190)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnCustFrom
        '
        Me.btnCustFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustFrom.ImageIndex = 0
        Me.btnCustFrom.Location = New System.Drawing.Point(210, 80)
        Me.btnCustFrom.Name = "btnCustFrom"
        Me.btnCustFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnCustFrom.TabIndex = 2
        Me.btnCustFrom.Text = "..."
        Me.btnCustFrom.UseVisualStyleBackColor = True
        '
        'btnCustTo
        '
        Me.btnCustTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustTo.ImageIndex = 0
        Me.btnCustTo.Location = New System.Drawing.Point(210, 114)
        Me.btnCustTo.Name = "btnCustTo"
        Me.btnCustTo.Size = New System.Drawing.Size(29, 25)
        Me.btnCustTo.TabIndex = 4
        Me.btnCustTo.Text = "..."
        Me.btnCustTo.UseVisualStyleBackColor = True
        '
        'txtCCodeTo
        '
        Me.txtCCodeTo.Location = New System.Drawing.Point(127, 117)
        Me.txtCCodeTo.MaxLength = 50
        Me.txtCCodeTo.Name = "txtCCodeTo"
        Me.txtCCodeTo.Size = New System.Drawing.Size(80, 20)
        Me.txtCCodeTo.TabIndex = 3
        Me.txtCCodeTo.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(181, 190)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 9
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 200
        Me.Label2.Text = "Date"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(127, 52)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(87, 20)
        Me.dtpFrom.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(246, 151)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 13)
        Me.Label4.TabIndex = 199
        Me.Label4.Text = "Leave blank to select all"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(16, 151)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(77, 13)
        Me.Label27.TabIndex = 196
        Me.Label27.Text = "Currency Code"
        '
        'btnCurrency
        '
        Me.btnCurrency.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCurrency.ImageIndex = 0
        Me.btnCurrency.Location = New System.Drawing.Point(210, 145)
        Me.btnCurrency.Name = "btnCurrency"
        Me.btnCurrency.Size = New System.Drawing.Size(29, 25)
        Me.btnCurrency.TabIndex = 6
        Me.btnCurrency.Text = "..."
        Me.btnCurrency.UseVisualStyleBackColor = True
        '
        'txtCurrCode
        '
        Me.txtCurrCode.Location = New System.Drawing.Point(127, 148)
        Me.txtCurrCode.MaxLength = 50
        Me.txtCurrCode.Name = "txtCurrCode"
        Me.txtCurrCode.Size = New System.Drawing.Size(80, 20)
        Me.txtCurrCode.TabIndex = 5
        Me.txtCurrCode.TabStop = False
        '
        'rptSlsARAging
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 231)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.txtCCodeFrom)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnCustFrom)
        Me.Controls.Add(Me.btnCustTo)
        Me.Controls.Add(Me.txtCCodeTo)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.btnCurrency)
        Me.Controls.Add(Me.txtCurrCode)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptSlsARAging"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AR Aging"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents txtCCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnCustFrom As System.Windows.Forms.Button
    Friend WithEvents btnCustTo As System.Windows.Forms.Button
    Friend WithEvents txtCCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents btnCurrency As System.Windows.Forms.Button
    Friend WithEvents txtCurrCode As System.Windows.Forms.TextBox
End Class
