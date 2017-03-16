<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSYSPeriod
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
        Me.txtPeriodName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cmbSubPeriodId = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpPeriodEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpPeriodStartDate = New System.Windows.Forms.DateTimePicker()
        Me.btnLockPeriod = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPeriodClose = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtLockedAP = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtLockedAR = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtLockedGL = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtLockedSKU = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtLockedBANK = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtPeriodName
        '
        Me.txtPeriodName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodName.Location = New System.Drawing.Point(149, 12)
        Me.txtPeriodName.MaxLength = 50
        Me.txtPeriodName.Name = "txtPeriodName"
        Me.txtPeriodName.ReadOnly = True
        Me.txtPeriodName.Size = New System.Drawing.Size(121, 21)
        Me.txtPeriodName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Period Name"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(287, 294)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(113, 294)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        Me.btnSave.Visible = False
        '
        'cmbSubPeriodId
        '
        Me.cmbSubPeriodId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubPeriodId.Enabled = False
        Me.cmbSubPeriodId.FormattingEnabled = True
        Me.cmbSubPeriodId.Location = New System.Drawing.Point(149, 93)
        Me.cmbSubPeriodId.Name = "cmbSubPeriodId"
        Me.cmbSubPeriodId.Size = New System.Drawing.Size(121, 21)
        Me.cmbSubPeriodId.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Sub period of"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "End Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Start Date"
        '
        'dtpPeriodEndDate
        '
        Me.dtpPeriodEndDate.Enabled = False
        Me.dtpPeriodEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPeriodEndDate.Location = New System.Drawing.Point(149, 66)
        Me.dtpPeriodEndDate.Name = "dtpPeriodEndDate"
        Me.dtpPeriodEndDate.Size = New System.Drawing.Size(121, 21)
        Me.dtpPeriodEndDate.TabIndex = 2
        '
        'dtpPeriodStartDate
        '
        Me.dtpPeriodStartDate.Enabled = False
        Me.dtpPeriodStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPeriodStartDate.Location = New System.Drawing.Point(149, 39)
        Me.dtpPeriodStartDate.Name = "dtpPeriodStartDate"
        Me.dtpPeriodStartDate.Size = New System.Drawing.Size(121, 21)
        Me.dtpPeriodStartDate.TabIndex = 1
        '
        'btnLockPeriod
        '
        Me.btnLockPeriod.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLockPeriod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLockPeriod.Location = New System.Drawing.Point(191, 294)
        Me.btnLockPeriod.Name = "btnLockPeriod"
        Me.btnLockPeriod.Size = New System.Drawing.Size(90, 23)
        Me.btnLockPeriod.TabIndex = 11
        Me.btnLockPeriod.Text = "Close Period"
        Me.btnLockPeriod.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Period Close"
        '
        'txtPeriodClose
        '
        Me.txtPeriodClose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodClose.Location = New System.Drawing.Point(149, 120)
        Me.txtPeriodClose.MaxLength = 50
        Me.txtPeriodClose.Name = "txtPeriodClose"
        Me.txtPeriodClose.ReadOnly = True
        Me.txtPeriodClose.Size = New System.Drawing.Size(121, 21)
        Me.txtPeriodClose.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 150)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "A/P Transaction"
        '
        'txtLockedAP
        '
        Me.txtLockedAP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLockedAP.Location = New System.Drawing.Point(149, 147)
        Me.txtLockedAP.MaxLength = 50
        Me.txtLockedAP.Name = "txtLockedAP"
        Me.txtLockedAP.ReadOnly = True
        Me.txtLockedAP.Size = New System.Drawing.Size(121, 21)
        Me.txtLockedAP.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 177)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "A/R Transaction"
        '
        'txtLockedAR
        '
        Me.txtLockedAR.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLockedAR.Location = New System.Drawing.Point(149, 174)
        Me.txtLockedAR.MaxLength = 50
        Me.txtLockedAR.Name = "txtLockedAR"
        Me.txtLockedAR.ReadOnly = True
        Me.txtLockedAR.Size = New System.Drawing.Size(121, 21)
        Me.txtLockedAR.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(15, 260)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 13)
        Me.Label8.TabIndex = 90
        Me.Label8.Text = "Ledger Transaction"
        '
        'txtLockedGL
        '
        Me.txtLockedGL.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLockedGL.Location = New System.Drawing.Point(149, 257)
        Me.txtLockedGL.MaxLength = 50
        Me.txtLockedGL.Name = "txtLockedGL"
        Me.txtLockedGL.ReadOnly = True
        Me.txtLockedGL.Size = New System.Drawing.Size(121, 21)
        Me.txtLockedGL.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 204)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 13)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "Stock Transaction"
        '
        'txtLockedSKU
        '
        Me.txtLockedSKU.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLockedSKU.Location = New System.Drawing.Point(149, 201)
        Me.txtLockedSKU.MaxLength = 50
        Me.txtLockedSKU.Name = "txtLockedSKU"
        Me.txtLockedSKU.ReadOnly = True
        Me.txtLockedSKU.Size = New System.Drawing.Size(121, 21)
        Me.txtLockedSKU.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 231)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 13)
        Me.Label10.TabIndex = 94
        Me.Label10.Text = "Bank Transaction"
        '
        'txtLockedBANK
        '
        Me.txtLockedBANK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLockedBANK.Location = New System.Drawing.Point(149, 228)
        Me.txtLockedBANK.MaxLength = 50
        Me.txtLockedBANK.Name = "txtLockedBANK"
        Me.txtLockedBANK.ReadOnly = True
        Me.txtLockedBANK.Size = New System.Drawing.Size(121, 21)
        Me.txtLockedBANK.TabIndex = 8
        '
        'frmSYSPeriod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(374, 329)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtLockedBANK)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtLockedSKU)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtLockedGL)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtLockedAR)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtLockedAP)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPeriodClose)
        Me.Controls.Add(Me.btnLockPeriod)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpPeriodEndDate)
        Me.Controls.Add(Me.dtpPeriodStartDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbSubPeriodId)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPeriodName)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSYSPeriod"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Accounting Periods"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPeriodName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cmbSubPeriodId As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpPeriodEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpPeriodStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnLockPeriod As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodClose As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtLockedAP As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLockedAR As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtLockedGL As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtLockedSKU As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtLockedBANK As System.Windows.Forms.TextBox
End Class
