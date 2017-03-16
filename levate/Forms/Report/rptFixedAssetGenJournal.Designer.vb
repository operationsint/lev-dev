<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptFixedAssetGenJournal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptFixedAssetGenJournal))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnFixedAssetCatCodeTo = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFixedAssetCatCodeTo = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFixedAssetCatCodeFrom = New System.Windows.Forms.Button()
        Me.txtFixedAssetCatCodeFrom = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(309, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 13)
        Me.Label3.TabIndex = 154
        Me.Label3.Text = "Leave blank to select all"
        '
        'btnFixedAssetCatCodeTo
        '
        Me.btnFixedAssetCatCodeTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFixedAssetCatCodeTo.ImageIndex = 0
        Me.btnFixedAssetCatCodeTo.Location = New System.Drawing.Point(273, 65)
        Me.btnFixedAssetCatCodeTo.Name = "btnFixedAssetCatCodeTo"
        Me.btnFixedAssetCatCodeTo.Size = New System.Drawing.Size(29, 25)
        Me.btnFixedAssetCatCodeTo.TabIndex = 4
        Me.btnFixedAssetCatCodeTo.Text = "..."
        Me.btnFixedAssetCatCodeTo.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(241, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(270, 20)
        Me.Label6.TabIndex = 208
        Me.Label6.Text = "Fixed Asset Depreciation Report"
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
        'txtFixedAssetCatCodeTo
        '
        Me.txtFixedAssetCatCodeTo.Location = New System.Drawing.Point(147, 67)
        Me.txtFixedAssetCatCodeTo.Name = "txtFixedAssetCatCodeTo"
        Me.txtFixedAssetCatCodeTo.Size = New System.Drawing.Size(117, 20)
        Me.txtFixedAssetCatCodeTo.TabIndex = 3
        Me.txtFixedAssetCatCodeTo.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(436, 145)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 207
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnFixedAssetCatCodeTo)
        Me.GroupBox1.Controls.Add(Me.txtFixedAssetCatCodeTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnFixedAssetCatCodeFrom)
        Me.GroupBox1.Controls.Add(Me.txtFixedAssetCatCodeFrom)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(499, 104)
        Me.GroupBox1.TabIndex = 204
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 13)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "To Fixed Asset Cat. Code"
        '
        'btnFixedAssetCatCodeFrom
        '
        Me.btnFixedAssetCatCodeFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFixedAssetCatCodeFrom.ImageIndex = 0
        Me.btnFixedAssetCatCodeFrom.Location = New System.Drawing.Point(273, 36)
        Me.btnFixedAssetCatCodeFrom.Name = "btnFixedAssetCatCodeFrom"
        Me.btnFixedAssetCatCodeFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnFixedAssetCatCodeFrom.TabIndex = 2
        Me.btnFixedAssetCatCodeFrom.Text = "..."
        Me.btnFixedAssetCatCodeFrom.UseVisualStyleBackColor = True
        '
        'txtFixedAssetCatCodeFrom
        '
        Me.txtFixedAssetCatCodeFrom.Location = New System.Drawing.Point(147, 38)
        Me.txtFixedAssetCatCodeFrom.Name = "txtFixedAssetCatCodeFrom"
        Me.txtFixedAssetCatCodeFrom.Size = New System.Drawing.Size(117, 20)
        Me.txtFixedAssetCatCodeFrom.TabIndex = 1
        Me.txtFixedAssetCatCodeFrom.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(6, 42)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(137, 13)
        Me.Label37.TabIndex = 145
        Me.Label37.Text = "From Fixed Asset Cat. Code"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(146, 10)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(87, 20)
        Me.dtpFrom.TabIndex = 0
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(355, 145)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 206
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(274, 145)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 205
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'rptFixedAssetGenJournal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 181)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnPrint)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptFixedAssetGenJournal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fixed Asset Depreciation Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnFixedAssetCatCodeTo As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFixedAssetCatCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFixedAssetCatCodeFrom As System.Windows.Forms.Button
    Friend WithEvents txtFixedAssetCatCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
End Class
