<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSYSSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSYSSetting))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbDecimal = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbRound = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbPlay = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtStockImagePath = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ntbTaxPercent = New levate.NumericTextBox()
        Me.chbStockMinusSetting = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbFirstFiscalMonth = New System.Windows.Forms.ComboBox()
        Me.cbAllowBankMinus = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabSystem = New System.Windows.Forms.TabPage()
        Me.cbConfirmOutCheckRequiredDate = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbTruncateSalesVAT = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbTruncatePurchaseVAT = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbDate = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tabMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabSystem.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(206, 2)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(197, 19)
        Me.Label8.TabIndex = 164
        Me.Label8.Text = "Background Parameter"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(614, 392)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(533, 392)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.TabPage1)
        Me.tabMain.Controls.Add(Me.tabSystem)
        Me.tabMain.Location = New System.Drawing.Point(12, 31)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(684, 350)
        Me.tabMain.TabIndex = 178
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(676, 324)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General and Sales"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbDate)
        Me.GroupBox2.Controls.Add(Me.cbDecimal)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cmbRound)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 199)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(660, 119)
        Me.GroupBox2.TabIndex = 179
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sales"
        '
        'cbDecimal
        '
        Me.cbDecimal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDecimal.FormattingEnabled = True
        Me.cbDecimal.Location = New System.Drawing.Point(183, 29)
        Me.cbDecimal.Name = "cbDecimal"
        Me.cbDecimal.Size = New System.Drawing.Size(55, 21)
        Me.cbDecimal.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 170
        Me.Label2.Text = "Decimal digit for price"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(153, 13)
        Me.Label4.TabIndex = 175
        Me.Label4.Text = "Local Currency Total Rounding"
        '
        'cmbRound
        '
        Me.cmbRound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRound.FormattingEnabled = True
        Me.cmbRound.Location = New System.Drawing.Point(183, 56)
        Me.cmbRound.Name = "cmbRound"
        Me.cmbRound.Size = New System.Drawing.Size(110, 21)
        Me.cmbRound.TabIndex = 174
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbPlay)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtStockImagePath)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.ntbTaxPercent)
        Me.GroupBox1.Controls.Add(Me.chbStockMinusSetting)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cmbFirstFiscalMonth)
        Me.GroupBox1.Controls.Add(Me.cbAllowBankMinus)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(660, 191)
        Me.GroupBox1.TabIndex = 178
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "General"
        '
        'cbPlay
        '
        Me.cbPlay.AutoSize = True
        Me.cbPlay.Location = New System.Drawing.Point(180, 162)
        Me.cbPlay.Name = "cbPlay"
        Me.cbPlay.Size = New System.Drawing.Size(15, 14)
        Me.cbPlay.TabIndex = 178
        Me.cbPlay.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 162)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 179
        Me.Label7.Text = "PLAY Database"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(407, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(180, 13)
        Me.Label6.TabIndex = 177
        Me.Label6.Text = "ex: \\SERVERNAME\SHAREFOLDER\"
        '
        'txtStockImagePath
        '
        Me.txtStockImagePath.Location = New System.Drawing.Point(180, 129)
        Me.txtStockImagePath.MaxLength = 150
        Me.txtStockImagePath.Name = "txtStockImagePath"
        Me.txtStockImagePath.Size = New System.Drawing.Size(221, 20)
        Me.txtStockImagePath.TabIndex = 176
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 175
        Me.Label5.Text = "Stock Image Path"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Tax Setting (%)"
        '
        'ntbTaxPercent
        '
        Me.ntbTaxPercent.AllowSpace = False
        Me.ntbTaxPercent.Location = New System.Drawing.Point(180, 24)
        Me.ntbTaxPercent.MaxLength = 3
        Me.ntbTaxPercent.Name = "ntbTaxPercent"
        Me.ntbTaxPercent.Size = New System.Drawing.Size(55, 20)
        Me.ntbTaxPercent.TabIndex = 0
        Me.ntbTaxPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbStockMinusSetting
        '
        Me.chbStockMinusSetting.AutoSize = True
        Me.chbStockMinusSetting.Location = New System.Drawing.Point(180, 50)
        Me.chbStockMinusSetting.Name = "chbStockMinusSetting"
        Me.chbStockMinusSetting.Size = New System.Drawing.Size(15, 14)
        Me.chbStockMinusSetting.TabIndex = 2
        Me.chbStockMinusSetting.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 173
        Me.Label3.Text = "First Fiscal Month"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(131, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Allow Minus Stock Balance"
        '
        'cmbFirstFiscalMonth
        '
        Me.cmbFirstFiscalMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFirstFiscalMonth.FormattingEnabled = True
        Me.cmbFirstFiscalMonth.Location = New System.Drawing.Point(180, 102)
        Me.cmbFirstFiscalMonth.Name = "cmbFirstFiscalMonth"
        Me.cmbFirstFiscalMonth.Size = New System.Drawing.Size(110, 21)
        Me.cmbFirstFiscalMonth.TabIndex = 4
        '
        'cbAllowBankMinus
        '
        Me.cbAllowBankMinus.AutoSize = True
        Me.cbAllowBankMinus.Location = New System.Drawing.Point(180, 77)
        Me.cbAllowBankMinus.Name = "cbAllowBankMinus"
        Me.cbAllowBankMinus.Size = New System.Drawing.Size(15, 14)
        Me.cbAllowBankMinus.TabIndex = 3
        Me.cbAllowBankMinus.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 13)
        Me.Label1.TabIndex = 168
        Me.Label1.Text = "Allow Minus Bank Balance"
        '
        'tabSystem
        '
        Me.tabSystem.BackColor = System.Drawing.SystemColors.Control
        Me.tabSystem.Controls.Add(Me.cbConfirmOutCheckRequiredDate)
        Me.tabSystem.Controls.Add(Me.Label13)
        Me.tabSystem.Controls.Add(Me.cbTruncateSalesVAT)
        Me.tabSystem.Controls.Add(Me.Label11)
        Me.tabSystem.Controls.Add(Me.cbTruncatePurchaseVAT)
        Me.tabSystem.Controls.Add(Me.Label10)
        Me.tabSystem.Location = New System.Drawing.Point(4, 22)
        Me.tabSystem.Name = "tabSystem"
        Me.tabSystem.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSystem.Size = New System.Drawing.Size(676, 324)
        Me.tabSystem.TabIndex = 1
        Me.tabSystem.Text = "System"
        '
        'cbConfirmOutCheckRequiredDate
        '
        Me.cbConfirmOutCheckRequiredDate.AutoSize = True
        Me.cbConfirmOutCheckRequiredDate.Location = New System.Drawing.Point(268, 74)
        Me.cbConfirmOutCheckRequiredDate.Name = "cbConfirmOutCheckRequiredDate"
        Me.cbConfirmOutCheckRequiredDate.Size = New System.Drawing.Size(15, 14)
        Me.cbConfirmOutCheckRequiredDate.TabIndex = 186
        Me.cbConfirmOutCheckRequiredDate.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(17, 74)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(233, 13)
        Me.Label13.TabIndex = 187
        Me.Label13.Text = "Confirm Out Date must <= than Required Date"
        '
        'cbTruncateSalesVAT
        '
        Me.cbTruncateSalesVAT.AutoSize = True
        Me.cbTruncateSalesVAT.Location = New System.Drawing.Point(268, 47)
        Me.cbTruncateSalesVAT.Name = "cbTruncateSalesVAT"
        Me.cbTruncateSalesVAT.Size = New System.Drawing.Size(15, 14)
        Me.cbTruncateSalesVAT.TabIndex = 184
        Me.cbTruncateSalesVAT.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(17, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(215, 13)
        Me.Label11.TabIndex = 185
        Me.Label11.Text = "Truncate decimal Sales Invoice amount VAT"
        '
        'cbTruncatePurchaseVAT
        '
        Me.cbTruncatePurchaseVAT.AutoSize = True
        Me.cbTruncatePurchaseVAT.Location = New System.Drawing.Point(268, 23)
        Me.cbTruncatePurchaseVAT.Name = "cbTruncatePurchaseVAT"
        Me.cbTruncatePurchaseVAT.Size = New System.Drawing.Size(15, 14)
        Me.cbTruncatePurchaseVAT.TabIndex = 182
        Me.cbTruncatePurchaseVAT.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(17, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(234, 13)
        Me.Label10.TabIndex = 183
        Me.Label10.Text = "Truncate decimal Purchase Invoice amount VAT"
        '
        'cbDate
        '
        Me.cbDate.AutoSize = True
        Me.cbDate.Location = New System.Drawing.Point(180, 89)
        Me.cbDate.Name = "cbDate"
        Me.cbDate.Size = New System.Drawing.Size(15, 14)
        Me.cbDate.TabIndex = 178
        Me.cbDate.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 89)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(167, 13)
        Me.Label14.TabIndex = 168
        Me.Label14.Text = "Sales Order Nutrify Delivery Date"
        '
        'frmSYSSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 427)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label8)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSYSSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Background Parameter"
        Me.tabMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabSystem.ResumeLayout(False)
        Me.tabSystem.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbDecimal As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbRound As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbPlay As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtStockImagePath As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ntbTaxPercent As levate.NumericTextBox
    Friend WithEvents chbStockMinusSetting As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbFirstFiscalMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cbAllowBankMinus As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabSystem As System.Windows.Forms.TabPage
    Friend WithEvents cbConfirmOutCheckRequiredDate As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbTruncateSalesVAT As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbTruncatePurchaseVAT As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbDate As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
