<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptPAPAging
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptPAPAging))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSCodeFrom = New System.Windows.Forms.TextBox()
        Me.btnCustFrom = New System.Windows.Forms.Button()
        Me.txtSCodeTo = New System.Windows.Forms.TextBox()
        Me.btnCustTo = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCurrency = New System.Windows.Forms.Button()
        Me.txtCurrCode = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(291, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(143, 20)
        Me.Label6.TabIndex = 194
        Me.Label6.Text = "AP Aging Report"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(26, 182)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(107, 182)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(252, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 13)
        Me.Label7.TabIndex = 169
        Me.Label7.Text = "Leave blank to select all"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 13)
        Me.Label8.TabIndex = 163
        Me.Label8.Text = "From Supplier Code"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(19, 112)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 13)
        Me.Label9.TabIndex = 164
        Me.Label9.Text = "To Supplier Code"
        '
        'txtSCodeFrom
        '
        Me.txtSCodeFrom.Location = New System.Drawing.Point(134, 75)
        Me.txtSCodeFrom.MaxLength = 50
        Me.txtSCodeFrom.Name = "txtSCodeFrom"
        Me.txtSCodeFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtSCodeFrom.TabIndex = 1
        Me.txtSCodeFrom.TabStop = False
        '
        'btnCustFrom
        '
        Me.btnCustFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustFrom.ImageIndex = 0
        Me.btnCustFrom.Location = New System.Drawing.Point(217, 72)
        Me.btnCustFrom.Name = "btnCustFrom"
        Me.btnCustFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnCustFrom.TabIndex = 2
        Me.btnCustFrom.Text = "..."
        Me.btnCustFrom.UseVisualStyleBackColor = True
        '
        'txtSCodeTo
        '
        Me.txtSCodeTo.Location = New System.Drawing.Point(134, 109)
        Me.txtSCodeTo.MaxLength = 50
        Me.txtSCodeTo.Name = "txtSCodeTo"
        Me.txtSCodeTo.Size = New System.Drawing.Size(80, 20)
        Me.txtSCodeTo.TabIndex = 3
        Me.txtSCodeTo.TabStop = False
        '
        'btnCustTo
        '
        Me.btnCustTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustTo.ImageIndex = 0
        Me.btnCustTo.Location = New System.Drawing.Point(217, 106)
        Me.btnCustTo.Name = "btnCustTo"
        Me.btnCustTo.Size = New System.Drawing.Size(29, 25)
        Me.btnCustTo.TabIndex = 4
        Me.btnCustTo.Text = "..."
        Me.btnCustTo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(253, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 13)
        Me.Label4.TabIndex = 155
        Me.Label4.Text = "Leave blank to select all"
        '
        'btnCurrency
        '
        Me.btnCurrency.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCurrency.ImageIndex = 0
        Me.btnCurrency.Location = New System.Drawing.Point(217, 137)
        Me.btnCurrency.Name = "btnCurrency"
        Me.btnCurrency.Size = New System.Drawing.Size(29, 25)
        Me.btnCurrency.TabIndex = 6
        Me.btnCurrency.Text = "..."
        Me.btnCurrency.UseVisualStyleBackColor = True
        '
        'txtCurrCode
        '
        Me.txtCurrCode.Location = New System.Drawing.Point(134, 140)
        Me.txtCurrCode.MaxLength = 50
        Me.txtCurrCode.Name = "txtCurrCode"
        Me.txtCurrCode.Size = New System.Drawing.Size(80, 20)
        Me.txtCurrCode.TabIndex = 5
        Me.txtCurrCode.TabStop = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(23, 143)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(77, 13)
        Me.Label27.TabIndex = 151
        Me.Label27.Text = "Currency Code"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(134, 44)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(87, 20)
        Me.dtpFrom.TabIndex = 0
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(188, 182)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 9
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'rptPAPAging
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 231)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.txtSCodeFrom)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnCustFrom)
        Me.Controls.Add(Me.btnCustTo)
        Me.Controls.Add(Me.txtSCodeTo)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.btnCurrency)
        Me.Controls.Add(Me.txtCurrCode)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptPAPAging"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AP Aging"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents btnCustFrom As System.Windows.Forms.Button
    Friend WithEvents txtSCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents btnCustTo As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCurrency As System.Windows.Forms.Button
    Friend WithEvents txtCurrCode As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnClear As System.Windows.Forms.Button
End Class
