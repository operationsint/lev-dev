<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSYSCompany
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSYSCompany))
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabCompanyData = New System.Windows.Forms.TabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCompanyNPWP = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCompanyEmail2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCompanyCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCompanyWebAddress = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCompanyEmail1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCompanyFax = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCompanyPhone2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCompanyPhone1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCompanyAddress2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCompanyAddress1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.tabOthers = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCompanyBankInfo = New System.Windows.Forms.TextBox()
        Me.tabMain.SuspendLayout()
        Me.tabCompanyData.SuspendLayout()
        Me.tabOthers.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(538, 404)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(619, 404)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tabCompanyData)
        Me.tabMain.Controls.Add(Me.tabOthers)
        Me.tabMain.Location = New System.Drawing.Point(5, 4)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(699, 392)
        Me.tabMain.TabIndex = 34
        '
        'tabCompanyData
        '
        Me.tabCompanyData.BackColor = System.Drawing.SystemColors.Control
        Me.tabCompanyData.Controls.Add(Me.Label13)
        Me.tabCompanyData.Controls.Add(Me.txtCompanyNPWP)
        Me.tabCompanyData.Controls.Add(Me.Label11)
        Me.tabCompanyData.Controls.Add(Me.txtCompanyEmail2)
        Me.tabCompanyData.Controls.Add(Me.Label10)
        Me.tabCompanyData.Controls.Add(Me.txtCompanyCode)
        Me.tabCompanyData.Controls.Add(Me.Label8)
        Me.tabCompanyData.Controls.Add(Me.txtCompanyWebAddress)
        Me.tabCompanyData.Controls.Add(Me.Label7)
        Me.tabCompanyData.Controls.Add(Me.txtCompanyEmail1)
        Me.tabCompanyData.Controls.Add(Me.Label6)
        Me.tabCompanyData.Controls.Add(Me.txtCompanyFax)
        Me.tabCompanyData.Controls.Add(Me.Label5)
        Me.tabCompanyData.Controls.Add(Me.txtCompanyPhone2)
        Me.tabCompanyData.Controls.Add(Me.Label4)
        Me.tabCompanyData.Controls.Add(Me.txtCompanyPhone1)
        Me.tabCompanyData.Controls.Add(Me.Label3)
        Me.tabCompanyData.Controls.Add(Me.txtCompanyAddress2)
        Me.tabCompanyData.Controls.Add(Me.Label1)
        Me.tabCompanyData.Controls.Add(Me.txtCompanyAddress1)
        Me.tabCompanyData.Controls.Add(Me.Label2)
        Me.tabCompanyData.Controls.Add(Me.txtCompanyName)
        Me.tabCompanyData.Location = New System.Drawing.Point(4, 22)
        Me.tabCompanyData.Name = "tabCompanyData"
        Me.tabCompanyData.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCompanyData.Size = New System.Drawing.Size(691, 366)
        Me.tabCompanyData.TabIndex = 0
        Me.tabCompanyData.Text = "Company Data"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(17, 288)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 13)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "NPWP"
        '
        'txtCompanyNPWP
        '
        Me.txtCompanyNPWP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyNPWP.Location = New System.Drawing.Point(165, 285)
        Me.txtCompanyNPWP.MaxLength = 50
        Me.txtCompanyNPWP.Name = "txtCompanyNPWP"
        Me.txtCompanyNPWP.Size = New System.Drawing.Size(202, 21)
        Me.txtCompanyNPWP.TabIndex = 46
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(17, 261)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 54
        Me.Label11.Text = "Email 2"
        '
        'txtCompanyEmail2
        '
        Me.txtCompanyEmail2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyEmail2.Location = New System.Drawing.Point(165, 258)
        Me.txtCompanyEmail2.MaxLength = 50
        Me.txtCompanyEmail2.Name = "txtCompanyEmail2"
        Me.txtCompanyEmail2.Size = New System.Drawing.Size(202, 21)
        Me.txtCompanyEmail2.TabIndex = 44
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(17, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 13)
        Me.Label10.TabIndex = 53
        Me.Label10.Text = "Company Code *"
        '
        'txtCompanyCode
        '
        Me.txtCompanyCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyCode.Location = New System.Drawing.Point(165, 14)
        Me.txtCompanyCode.MaxLength = 10
        Me.txtCompanyCode.Name = "txtCompanyCode"
        Me.txtCompanyCode.Size = New System.Drawing.Size(118, 21)
        Me.txtCompanyCode.TabIndex = 34
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(17, 207)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "Web Address"
        '
        'txtCompanyWebAddress
        '
        Me.txtCompanyWebAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyWebAddress.Location = New System.Drawing.Point(165, 204)
        Me.txtCompanyWebAddress.MaxLength = 50
        Me.txtCompanyWebAddress.Name = "txtCompanyWebAddress"
        Me.txtCompanyWebAddress.Size = New System.Drawing.Size(202, 21)
        Me.txtCompanyWebAddress.TabIndex = 42
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 234)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Email 1"
        '
        'txtCompanyEmail1
        '
        Me.txtCompanyEmail1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyEmail1.Location = New System.Drawing.Point(165, 231)
        Me.txtCompanyEmail1.MaxLength = 50
        Me.txtCompanyEmail1.Name = "txtCompanyEmail1"
        Me.txtCompanyEmail1.Size = New System.Drawing.Size(202, 21)
        Me.txtCompanyEmail1.TabIndex = 43
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 177)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Fax *"
        '
        'txtCompanyFax
        '
        Me.txtCompanyFax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyFax.Location = New System.Drawing.Point(165, 177)
        Me.txtCompanyFax.MaxLength = 50
        Me.txtCompanyFax.Name = "txtCompanyFax"
        Me.txtCompanyFax.Size = New System.Drawing.Size(118, 21)
        Me.txtCompanyFax.TabIndex = 40
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Phone2"
        '
        'txtCompanyPhone2
        '
        Me.txtCompanyPhone2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyPhone2.Location = New System.Drawing.Point(165, 149)
        Me.txtCompanyPhone2.MaxLength = 50
        Me.txtCompanyPhone2.Name = "txtCompanyPhone2"
        Me.txtCompanyPhone2.Size = New System.Drawing.Size(118, 21)
        Me.txtCompanyPhone2.TabIndex = 39
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Phone1 *"
        '
        'txtCompanyPhone1
        '
        Me.txtCompanyPhone1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyPhone1.Location = New System.Drawing.Point(165, 122)
        Me.txtCompanyPhone1.MaxLength = 50
        Me.txtCompanyPhone1.Name = "txtCompanyPhone1"
        Me.txtCompanyPhone1.Size = New System.Drawing.Size(118, 21)
        Me.txtCompanyPhone1.TabIndex = 38
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Company Address2 *"
        '
        'txtCompanyAddress2
        '
        Me.txtCompanyAddress2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyAddress2.Location = New System.Drawing.Point(165, 95)
        Me.txtCompanyAddress2.MaxLength = 255
        Me.txtCompanyAddress2.Name = "txtCompanyAddress2"
        Me.txtCompanyAddress2.Size = New System.Drawing.Size(317, 21)
        Me.txtCompanyAddress2.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Company Address1 *"
        '
        'txtCompanyAddress1
        '
        Me.txtCompanyAddress1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyAddress1.Location = New System.Drawing.Point(165, 68)
        Me.txtCompanyAddress1.MaxLength = 255
        Me.txtCompanyAddress1.Name = "txtCompanyAddress1"
        Me.txtCompanyAddress1.Size = New System.Drawing.Size(317, 21)
        Me.txtCompanyAddress1.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Company Name *"
        '
        'txtCompanyName
        '
        Me.txtCompanyName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyName.Location = New System.Drawing.Point(165, 41)
        Me.txtCompanyName.MaxLength = 50
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.ReadOnly = True
        Me.txtCompanyName.Size = New System.Drawing.Size(202, 21)
        Me.txtCompanyName.TabIndex = 35
        '
        'tabOthers
        '
        Me.tabOthers.BackColor = System.Drawing.SystemColors.Control
        Me.tabOthers.Controls.Add(Me.Label12)
        Me.tabOthers.Controls.Add(Me.Label9)
        Me.tabOthers.Controls.Add(Me.txtCompanyBankInfo)
        Me.tabOthers.Location = New System.Drawing.Point(4, 22)
        Me.tabOthers.Name = "tabOthers"
        Me.tabOthers.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOthers.Size = New System.Drawing.Size(691, 366)
        Me.tabOthers.TabIndex = 1
        Me.tabOthers.Text = "Other Data"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(9, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(134, 13)
        Me.Label12.TabIndex = 54
        Me.Label12.Text = "(show at sales invoice slip)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 53
        Me.Label9.Text = "Invoice Notes :"
        '
        'txtCompanyBankInfo
        '
        Me.txtCompanyBankInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompanyBankInfo.Location = New System.Drawing.Point(157, 15)
        Me.txtCompanyBankInfo.MaxLength = 200
        Me.txtCompanyBankInfo.Multiline = True
        Me.txtCompanyBankInfo.Name = "txtCompanyBankInfo"
        Me.txtCompanyBankInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCompanyBankInfo.Size = New System.Drawing.Size(280, 76)
        Me.txtCompanyBankInfo.TabIndex = 52
        '
        'frmSYSCompany
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 433)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSYSCompany"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Company Profile Setting"
        Me.tabMain.ResumeLayout(False)
        Me.tabCompanyData.ResumeLayout(False)
        Me.tabCompanyData.PerformLayout()
        Me.tabOthers.ResumeLayout(False)
        Me.tabOthers.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabCompanyData As System.Windows.Forms.TabPage
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyNPWP As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyEmail2 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyCode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyWebAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyEmail1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyFax As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyPhone2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyPhone1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents tabOthers As System.Windows.Forms.TabPage
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCompanyBankInfo As System.Windows.Forms.TextBox
End Class
