<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptExpInc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptExpInc))
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnExpIncTo = New System.Windows.Forms.Button()
        Me.txtExpIncTo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnExpIncFrom = New System.Windows.Forms.Button()
        Me.txtExpIncFrom = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.cbFilter = New System.Windows.Forms.ComboBox()
        Me.btnPrintRecap = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(292, 208)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 10
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(211, 208)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(15, 208)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 23)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "Print Detail"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(314, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(202, 20)
        Me.Label6.TabIndex = 185
        Me.Label6.Text = "Expense Income Report"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(292, 107)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(162, 13)
        Me.Label7.TabIndex = 206
        Me.Label7.Text = "To select all leave the field blank"
        '
        'btnExpIncTo
        '
        Me.btnExpIncTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpIncTo.ImageIndex = 0
        Me.btnExpIncTo.Location = New System.Drawing.Point(256, 116)
        Me.btnExpIncTo.Name = "btnExpIncTo"
        Me.btnExpIncTo.Size = New System.Drawing.Size(29, 25)
        Me.btnExpIncTo.TabIndex = 5
        Me.btnExpIncTo.Text = "..."
        Me.btnExpIncTo.UseVisualStyleBackColor = True
        '
        'txtExpIncTo
        '
        Me.txtExpIncTo.Location = New System.Drawing.Point(173, 118)
        Me.txtExpIncTo.Name = "txtExpIncTo"
        Me.txtExpIncTo.Size = New System.Drawing.Size(80, 20)
        Me.txtExpIncTo.TabIndex = 4
        Me.txtExpIncTo.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(138, 13)
        Me.Label8.TabIndex = 203
        Me.Label8.Text = "To Expense / Income Code"
        '
        'btnExpIncFrom
        '
        Me.btnExpIncFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpIncFrom.ImageIndex = 0
        Me.btnExpIncFrom.Location = New System.Drawing.Point(256, 87)
        Me.btnExpIncFrom.Name = "btnExpIncFrom"
        Me.btnExpIncFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnExpIncFrom.TabIndex = 3
        Me.btnExpIncFrom.Text = "..."
        Me.btnExpIncFrom.UseVisualStyleBackColor = True
        '
        'txtExpIncFrom
        '
        Me.txtExpIncFrom.Location = New System.Drawing.Point(173, 89)
        Me.txtExpIncFrom.Name = "txtExpIncFrom"
        Me.txtExpIncFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtExpIncFrom.TabIndex = 2
        Me.txtExpIncFrom.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(148, 13)
        Me.Label9.TabIndex = 200
        Me.Label9.Text = "From Expense / Income Code"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 13)
        Me.Label4.TabIndex = 197
        Me.Label4.Text = "Filter Expense / Income"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(266, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 196
        Me.Label5.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 195
        Me.Label2.Text = "From Date"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(173, 59)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(87, 20)
        Me.dtpFrom.TabIndex = 0
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(292, 58)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(87, 20)
        Me.dtpTo.TabIndex = 1
        '
        'cbFilter
        '
        Me.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFilter.FormattingEnabled = True
        Me.cbFilter.Location = New System.Drawing.Point(173, 146)
        Me.cbFilter.Name = "cbFilter"
        Me.cbFilter.Size = New System.Drawing.Size(113, 21)
        Me.cbFilter.TabIndex = 6
        '
        'btnPrintRecap
        '
        Me.btnPrintRecap.Location = New System.Drawing.Point(105, 208)
        Me.btnPrintRecap.Name = "btnPrintRecap"
        Me.btnPrintRecap.Size = New System.Drawing.Size(95, 23)
        Me.btnPrintRecap.TabIndex = 8
        Me.btnPrintRecap.Text = "Print Summary"
        Me.btnPrintRecap.UseVisualStyleBackColor = True
        '
        'rptExpInc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 246)
        Me.Controls.Add(Me.btnPrintRecap)
        Me.Controls.Add(Me.cbFilter)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnExpIncTo)
        Me.Controls.Add(Me.txtExpIncTo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnExpIncFrom)
        Me.Controls.Add(Me.txtExpIncFrom)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label6)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptExpInc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Expense Income"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnExpIncTo As System.Windows.Forms.Button
    Friend WithEvents txtExpIncTo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnExpIncFrom As System.Windows.Forms.Button
    Friend WithEvents txtExpIncFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbFilter As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrintRecap As System.Windows.Forms.Button
End Class
