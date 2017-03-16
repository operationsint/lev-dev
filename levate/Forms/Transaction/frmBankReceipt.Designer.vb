<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBankReceipt
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBankReceipt))
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtLocalTotal = New System.Windows.Forms.TextBox()
        Me.txtLocalTax = New System.Windows.Forms.TextBox()
        Me.txtLocalSubTotal = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtTax = New System.Windows.Forms.TextBox()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtInfo3 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtInfo2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtInfo1 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPayee = New System.Windows.Forms.TextBox()
        Me.txtBankTransNetAmt = New System.Windows.Forms.TextBox()
        Me.txtBankTransTaxAmt = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.btnBank = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtBankDetail = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBankCode = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.cmbPaymentMethod = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtCurrencyCode = New System.Windows.Forms.TextBox()
        Me.btnAddD = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtLineDesc = New System.Windows.Forms.TextBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.txtExpincCode = New System.Windows.Forms.TextBox()
        Me.btnExpinc = New System.Windows.Forms.Button()
        Me.btnDeleteD = New System.Windows.Forms.Button()
        Me.btnSaveD = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.dtpBankAdjDate = New System.Windows.Forms.DateTimePicker()
        Me.txtBankTransNo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbPeriodId = New System.Windows.Forms.ComboBox()
        Me.ntbBankTransTaxPercent = New levate.NumericTextBox()
        Me.ntbBankTransAmount = New levate.NumericTextBox()
        Me.ntbRate = New levate.NumericTextBox()
        Me.SuspendLayout()
        '
        'Label34
        '
        Me.Label34.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(509, 493)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(60, 13)
        Me.Label34.TabIndex = 271
        Me.Label34.Text = "Local Total"
        '
        'Label35
        '
        Me.Label35.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(509, 465)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(54, 13)
        Me.Label35.TabIndex = 270
        Me.Label35.Text = "Local Tax"
        '
        'Label36
        '
        Me.Label36.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(509, 437)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(75, 13)
        Me.Label36.TabIndex = 269
        Me.Label36.Text = "Local Subtotal"
        '
        'txtLocalTotal
        '
        Me.txtLocalTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLocalTotal.Location = New System.Drawing.Point(603, 490)
        Me.txtLocalTotal.Name = "txtLocalTotal"
        Me.txtLocalTotal.ReadOnly = True
        Me.txtLocalTotal.Size = New System.Drawing.Size(118, 20)
        Me.txtLocalTotal.TabIndex = 28
        Me.txtLocalTotal.TabStop = False
        Me.txtLocalTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLocalTax
        '
        Me.txtLocalTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLocalTax.Location = New System.Drawing.Point(603, 461)
        Me.txtLocalTax.Name = "txtLocalTax"
        Me.txtLocalTax.ReadOnly = True
        Me.txtLocalTax.Size = New System.Drawing.Size(118, 20)
        Me.txtLocalTax.TabIndex = 27
        Me.txtLocalTax.TabStop = False
        Me.txtLocalTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLocalSubTotal
        '
        Me.txtLocalSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLocalSubTotal.Location = New System.Drawing.Point(603, 434)
        Me.txtLocalSubTotal.Name = "txtLocalSubTotal"
        Me.txtLocalSubTotal.ReadOnly = True
        Me.txtLocalSubTotal.Size = New System.Drawing.Size(118, 20)
        Me.txtLocalSubTotal.TabIndex = 26
        Me.txtLocalSubTotal.TabStop = False
        Me.txtLocalSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(791, 493)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 265
        Me.Label12.Text = "Total"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(791, 465)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(25, 13)
        Me.Label13.TabIndex = 264
        Me.Label13.Text = "Tax"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(791, 437)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 13)
        Me.Label14.TabIndex = 263
        Me.Label14.Text = "Subtotal"
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.Location = New System.Drawing.Point(856, 490)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(118, 20)
        Me.txtTotal.TabIndex = 31
        Me.txtTotal.TabStop = False
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTax
        '
        Me.txtTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTax.Location = New System.Drawing.Point(856, 461)
        Me.txtTax.Name = "txtTax"
        Me.txtTax.ReadOnly = True
        Me.txtTax.Size = New System.Drawing.Size(118, 20)
        Me.txtTax.TabIndex = 30
        Me.txtTax.TabStop = False
        Me.txtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubtotal.Location = New System.Drawing.Point(856, 434)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.ReadOnly = True
        Me.txtSubtotal.Size = New System.Drawing.Size(118, 20)
        Me.txtSubtotal.TabIndex = 29
        Me.txtSubtotal.TabStop = False
        Me.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(757, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 259
        Me.Label11.Text = "Info 3"
        '
        'txtInfo3
        '
        Me.txtInfo3.Location = New System.Drawing.Point(810, 94)
        Me.txtInfo3.MaxLength = 50
        Me.txtInfo3.Name = "txtInfo3"
        Me.txtInfo3.Size = New System.Drawing.Size(164, 20)
        Me.txtInfo3.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(757, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 257
        Me.Label8.Text = "Info 2"
        '
        'txtInfo2
        '
        Me.txtInfo2.Location = New System.Drawing.Point(810, 65)
        Me.txtInfo2.MaxLength = 50
        Me.txtInfo2.Name = "txtInfo2"
        Me.txtInfo2.Size = New System.Drawing.Size(164, 20)
        Me.txtInfo2.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(757, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 255
        Me.Label4.Text = "Info 1"
        '
        'txtInfo1
        '
        Me.txtInfo1.Location = New System.Drawing.Point(810, 36)
        Me.txtInfo1.MaxLength = 50
        Me.txtInfo1.Name = "txtInfo1"
        Me.txtInfo1.Size = New System.Drawing.Size(164, 20)
        Me.txtInfo1.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(757, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 253
        Me.Label5.Text = "Payee"
        '
        'txtPayee
        '
        Me.txtPayee.Location = New System.Drawing.Point(810, 10)
        Me.txtPayee.MaxLength = 50
        Me.txtPayee.Name = "txtPayee"
        Me.txtPayee.Size = New System.Drawing.Size(164, 20)
        Me.txtPayee.TabIndex = 11
        '
        'txtBankTransNetAmt
        '
        Me.txtBankTransNetAmt.Location = New System.Drawing.Point(767, 166)
        Me.txtBankTransNetAmt.Name = "txtBankTransNetAmt"
        Me.txtBankTransNetAmt.ReadOnly = True
        Me.txtBankTransNetAmt.Size = New System.Drawing.Size(112, 20)
        Me.txtBankTransNetAmt.TabIndex = 21
        Me.txtBankTransNetAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBankTransTaxAmt
        '
        Me.txtBankTransTaxAmt.Location = New System.Drawing.Point(664, 166)
        Me.txtBankTransTaxAmt.Name = "txtBankTransTaxAmt"
        Me.txtBankTransTaxAmt.ReadOnly = True
        Me.txtBankTransTaxAmt.Size = New System.Drawing.Size(97, 20)
        Me.txtBankTransTaxAmt.TabIndex = 20
        Me.txtBankTransTaxAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(815, 147)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(63, 13)
        Me.Label25.TabIndex = 249
        Me.Label25.Text = "Net Amount"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(696, 147)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(64, 13)
        Me.Label23.TabIndex = 248
        Me.Label23.Text = "Tax Amount"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(622, 147)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(36, 13)
        Me.Label22.TabIndex = 247
        Me.Label22.Text = "Tax %"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(399, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 245
        Me.Label3.Text = "Bank Name"
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(485, 37)
        Me.txtBankName.MaxLength = 50
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.ReadOnly = True
        Me.txtBankName.Size = New System.Drawing.Size(199, 20)
        Me.txtBankName.TabIndex = 7
        '
        'btnBank
        '
        Me.btnBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBank.ImageIndex = 0
        Me.btnBank.ImageList = Me.ImageList1
        Me.btnBank.Location = New System.Drawing.Point(655, 10)
        Me.btnBank.Name = "btnBank"
        Me.btnBank.Size = New System.Drawing.Size(29, 25)
        Me.btnBank.TabIndex = 6
        Me.btnBank.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Box.png")
        Me.ImageList1.Images.SetKeyName(1, "add.png")
        Me.ImageList1.Images.SetKeyName(2, "Checkmark.png")
        Me.ImageList1.Images.SetKeyName(3, "Remove.png")
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(399, 98)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(62, 13)
        Me.Label32.TabIndex = 242
        Me.Label32.Text = "Bank Detail"
        '
        'txtBankDetail
        '
        Me.txtBankDetail.Location = New System.Drawing.Point(485, 94)
        Me.txtBankDetail.Multiline = True
        Me.txtBankDetail.Name = "txtBankDetail"
        Me.txtBankDetail.Size = New System.Drawing.Size(199, 42)
        Me.txtBankDetail.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(399, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 240
        Me.Label1.Text = "Bank Code"
        '
        'txtBankCode
        '
        Me.txtBankCode.Location = New System.Drawing.Point(485, 11)
        Me.txtBankCode.MaxLength = 50
        Me.txtBankCode.Name = "txtBankCode"
        Me.txtBankCode.ReadOnly = True
        Me.txtBankCode.Size = New System.Drawing.Size(164, 20)
        Me.txtBankCode.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 125)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 238
        Me.Label9.Text = "Ref. No."
        '
        'txtRefNo
        '
        Me.txtRefNo.Location = New System.Drawing.Point(153, 121)
        Me.txtRefNo.MaxLength = 50
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(127, 20)
        Me.txtRefNo.TabIndex = 4
        '
        'cmbPaymentMethod
        '
        Me.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaymentMethod.FormattingEnabled = True
        Me.cmbPaymentMethod.Location = New System.Drawing.Point(153, 92)
        Me.cmbPaymentMethod.Name = "cmbPaymentMethod"
        Me.cmbPaymentMethod.Size = New System.Drawing.Size(112, 21)
        Me.cmbPaymentMethod.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 235
        Me.Label2.Text = "Receipt Method"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(399, 68)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(77, 13)
        Me.Label31.TabIndex = 234
        Me.Label31.Text = "Currency Code"
        '
        'txtCurrencyCode
        '
        Me.txtCurrencyCode.Location = New System.Drawing.Point(485, 65)
        Me.txtCurrencyCode.Name = "txtCurrencyCode"
        Me.txtCurrencyCode.ReadOnly = True
        Me.txtCurrencyCode.Size = New System.Drawing.Size(58, 20)
        Me.txtCurrencyCode.TabIndex = 8
        Me.txtCurrencyCode.TabStop = False
        '
        'btnAddD
        '
        Me.btnAddD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD.ImageIndex = 1
        Me.btnAddD.ImageList = Me.ImageList1
        Me.btnAddD.Location = New System.Drawing.Point(945, 161)
        Me.btnAddD.Name = "btnAddD"
        Me.btnAddD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD.TabIndex = 24
        Me.btnAddD.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(505, 150)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(43, 13)
        Me.Label21.TabIndex = 231
        Me.Label21.Text = "Amount"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(558, 68)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 13)
        Me.Label20.TabIndex = 230
        Me.Label20.Text = "Rate"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(132, 150)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(83, 13)
        Me.Label19.TabIndex = 229
        Me.Label19.Text = "Line Description"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(11, 150)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 13)
        Me.Label18.TabIndex = 228
        Me.Label18.Text = "Inc/Exp Code *"
        '
        'txtLineDesc
        '
        Me.txtLineDesc.Location = New System.Drawing.Point(132, 166)
        Me.txtLineDesc.MaxLength = 100
        Me.txtLineDesc.Name = "txtLineDesc"
        Me.txtLineDesc.Size = New System.Drawing.Size(370, 20)
        Me.txtLineDesc.TabIndex = 17
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(890, 526)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 26)
        Me.btnPrint.TabIndex = 37
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'txtExpincCode
        '
        Me.txtExpincCode.Location = New System.Drawing.Point(14, 166)
        Me.txtExpincCode.MaxLength = 50
        Me.txtExpincCode.Name = "txtExpincCode"
        Me.txtExpincCode.ReadOnly = True
        Me.txtExpincCode.Size = New System.Drawing.Size(80, 20)
        Me.txtExpincCode.TabIndex = 15
        '
        'btnExpinc
        '
        Me.btnExpinc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpinc.ImageIndex = 0
        Me.btnExpinc.ImageList = Me.ImageList1
        Me.btnExpinc.Location = New System.Drawing.Point(97, 163)
        Me.btnExpinc.Name = "btnExpinc"
        Me.btnExpinc.Size = New System.Drawing.Size(29, 25)
        Me.btnExpinc.TabIndex = 16
        Me.btnExpinc.UseVisualStyleBackColor = True
        '
        'btnDeleteD
        '
        Me.btnDeleteD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteD.ImageIndex = 3
        Me.btnDeleteD.ImageList = Me.ImageList1
        Me.btnDeleteD.Location = New System.Drawing.Point(915, 161)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 23
        Me.btnDeleteD.UseVisualStyleBackColor = True
        '
        'btnSaveD
        '
        Me.btnSaveD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveD.ImageIndex = 2
        Me.btnSaveD.ImageList = Me.ImageList1
        Me.btnSaveD.Location = New System.Drawing.Point(885, 161)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 22
        Me.btnSaveD.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 434)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 223
        Me.Label10.Text = "Remarks"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 222
        Me.Label7.Text = "Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 13)
        Me.Label6.TabIndex = 221
        Me.Label6.Text = "Bank Receipt No. *"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(800, 526)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 26)
        Me.btnCancel.TabIndex = 36
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(530, 526)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(84, 26)
        Me.btnEdit.TabIndex = 33
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(620, 526)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnAdd.TabIndex = 34
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(440, 526)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 26)
        Me.btnDelete.TabIndex = 32
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(710, 526)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 26)
        Me.btnSave.TabIndex = 35
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(14, 191)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(960, 237)
        Me.ListView1.TabIndex = 211
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'txtRemarks
        '
        Me.txtRemarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtRemarks.Location = New System.Drawing.Point(71, 434)
        Me.txtRemarks.MaxLength = 255
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(337, 57)
        Me.txtRemarks.TabIndex = 25
        '
        'dtpBankAdjDate
        '
        Me.dtpBankAdjDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBankAdjDate.Location = New System.Drawing.Point(153, 37)
        Me.dtpBankAdjDate.Name = "dtpBankAdjDate"
        Me.dtpBankAdjDate.Size = New System.Drawing.Size(97, 20)
        Me.dtpBankAdjDate.TabIndex = 1
        '
        'txtBankTransNo
        '
        Me.txtBankTransNo.Location = New System.Drawing.Point(153, 11)
        Me.txtBankTransNo.MaxLength = 10
        Me.txtBankTransNo.Name = "txtBankTransNo"
        Me.txtBankTransNo.Size = New System.Drawing.Size(153, 20)
        Me.txtBankTransNo.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 68)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 13)
        Me.Label15.TabIndex = 273
        Me.Label15.Text = "Period"
        '
        'cmbPeriodId
        '
        Me.cmbPeriodId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodId.Enabled = False
        Me.cmbPeriodId.FormattingEnabled = True
        Me.cmbPeriodId.Location = New System.Drawing.Point(153, 64)
        Me.cmbPeriodId.Name = "cmbPeriodId"
        Me.cmbPeriodId.Size = New System.Drawing.Size(97, 21)
        Me.cmbPeriodId.TabIndex = 2
        '
        'ntbBankTransTaxPercent
        '
        Me.ntbBankTransTaxPercent.AllowSpace = False
        Me.ntbBankTransTaxPercent.Location = New System.Drawing.Point(615, 166)
        Me.ntbBankTransTaxPercent.MaxLength = 3
        Me.ntbBankTransTaxPercent.Name = "ntbBankTransTaxPercent"
        Me.ntbBankTransTaxPercent.Size = New System.Drawing.Size(41, 20)
        Me.ntbBankTransTaxPercent.TabIndex = 19
        Me.ntbBankTransTaxPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbBankTransAmount
        '
        Me.ntbBankTransAmount.AllowSpace = False
        Me.ntbBankTransAmount.Location = New System.Drawing.Point(508, 166)
        Me.ntbBankTransAmount.MaxLength = 18
        Me.ntbBankTransAmount.Name = "ntbBankTransAmount"
        Me.ntbBankTransAmount.Size = New System.Drawing.Size(101, 20)
        Me.ntbBankTransAmount.TabIndex = 18
        Me.ntbBankTransAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbRate
        '
        Me.ntbRate.AllowSpace = False
        Me.ntbRate.Location = New System.Drawing.Point(602, 65)
        Me.ntbRate.MaxLength = 20
        Me.ntbRate.Name = "ntbRate"
        Me.ntbRate.Size = New System.Drawing.Size(80, 20)
        Me.ntbRate.TabIndex = 9
        Me.ntbRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmBankReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(984, 562)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmbPeriodId)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.txtLocalTotal)
        Me.Controls.Add(Me.txtLocalTax)
        Me.Controls.Add(Me.txtLocalSubTotal)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtTax)
        Me.Controls.Add(Me.txtSubtotal)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtInfo3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtInfo2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtInfo1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPayee)
        Me.Controls.Add(Me.txtBankTransNetAmt)
        Me.Controls.Add(Me.txtBankTransTaxAmt)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.ntbBankTransTaxPercent)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBankName)
        Me.Controls.Add(Me.btnBank)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.txtBankDetail)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBankCode)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtRefNo)
        Me.Controls.Add(Me.cmbPaymentMethod)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtCurrencyCode)
        Me.Controls.Add(Me.btnAddD)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtLineDesc)
        Me.Controls.Add(Me.ntbBankTransAmount)
        Me.Controls.Add(Me.ntbRate)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.txtExpincCode)
        Me.Controls.Add(Me.btnExpinc)
        Me.Controls.Add(Me.btnDeleteD)
        Me.Controls.Add(Me.btnSaveD)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.dtpBankAdjDate)
        Me.Controls.Add(Me.txtBankTransNo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBankReceipt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bank Receipt"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtLocalTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalTax As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtTax As System.Windows.Forms.TextBox
    Friend WithEvents txtSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtInfo3 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtInfo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtInfo1 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPayee As System.Windows.Forms.TextBox
    Friend WithEvents txtBankTransNetAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtBankTransTaxAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ntbBankTransTaxPercent As levate.NumericTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents btnBank As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtBankDetail As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents cmbPaymentMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtCurrencyCode As System.Windows.Forms.TextBox
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtLineDesc As System.Windows.Forms.TextBox
    Friend WithEvents ntbBankTransAmount As levate.NumericTextBox
    Friend WithEvents ntbRate As levate.NumericTextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents txtExpincCode As System.Windows.Forms.TextBox
    Friend WithEvents btnExpinc As System.Windows.Forms.Button
    Friend WithEvents btnDeleteD As System.Windows.Forms.Button
    Friend WithEvents btnSaveD As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents dtpBankAdjDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtBankTransNo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbPeriodId As System.Windows.Forms.ComboBox
End Class
