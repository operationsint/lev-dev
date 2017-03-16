<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSO))
        Me.txtSONo = New System.Windows.Forms.TextBox()
        Me.dtpSODate = New System.Windows.Forms.DateTimePicker()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.txtCName = New System.Windows.Forms.TextBox()
        Me.txtCCode = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.txtSORemarks = New System.Windows.Forms.TextBox()
        Me.txtSOGross = New System.Windows.Forms.TextBox()
        Me.txtSOTax = New System.Windows.Forms.TextBox()
        Me.txtSOTotal = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnDeleteD = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnSaveD = New System.Windows.Forms.Button()
        Me.btnSKU = New System.Windows.Forms.Button()
        Me.btnCustomer = New System.Windows.Forms.Button()
        Me.cmbSODtlType = New System.Windows.Forms.ComboBox()
        Me.txtSKUCode = New System.Windows.Forms.TextBox()
        Me.txtSODtlDesc = New System.Windows.Forms.TextBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.cmbSOType = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSOSubtotal = New System.Windows.Forms.TextBox()
        Me.txtSODiscount = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btnAddD = New System.Windows.Forms.Button()
        Me.txtSOStatus = New System.Windows.Forms.TextBox()
        Me.txtSONetAmt = New System.Windows.Forms.TextBox()
        Me.txtSOTaxAmt = New System.Windows.Forms.TextBox()
        Me.txtSOGrossAmt = New System.Windows.Forms.TextBox()
        Me.txtSOGrossAfterDiscAmt = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtSKUBarcode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCContact = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtLotJobNo = New System.Windows.Forms.TextBox()
        Me.txtCurrCode = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtLocalSOTotal = New System.Windows.Forms.TextBox()
        Me.txtLocalSOTax = New System.Windows.Forms.TextBox()
        Me.txtLocalSOSubTotal = New System.Windows.Forms.TextBox()
        Me.btnSlsCode = New System.Windows.Forms.Button()
        Me.txtSlsCode = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtLocationCode = New System.Windows.Forms.TextBox()
        Me.btnLocation = New System.Windows.Forms.Button()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.dtpRequiredDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.btnCloseSO = New System.Windows.Forms.Button()
        Me.lblClosedDescription = New System.Windows.Forms.Label()
        Me.txtSInvoiceNo = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.btnInvoiceNo = New System.Windows.Forms.Button()
        Me.ntbSOCurrRate = New levate.NumericTextBox()
        Me.ntbSOTaxPercent = New levate.NumericTextBox()
        Me.ntbSODiscAmt = New levate.NumericTextBox()
        Me.ntbSODiscPercent = New levate.NumericTextBox()
        Me.ntbPaymentTerms = New levate.NumericTextBox()
        Me.ntbSOPrice = New levate.NumericTextBox()
        Me.ntbSOQty = New levate.NumericTextBox()
        Me.btnPrintSInv = New System.Windows.Forms.Button()
        Me.ntbSOPriceIncludeTax = New levate.NumericTextBox()
        Me.cbIncludeTax = New System.Windows.Forms.CheckBox()
        Me.btnPrintPackingSlip = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtSONo
        '
        Me.txtSONo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSONo.Location = New System.Drawing.Point(113, 12)
        Me.txtSONo.MaxLength = 50
        Me.txtSONo.Name = "txtSONo"
        Me.txtSONo.Size = New System.Drawing.Size(127, 21)
        Me.txtSONo.TabIndex = 0
        '
        'dtpSODate
        '
        Me.dtpSODate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSODate.Location = New System.Drawing.Point(113, 39)
        Me.dtpSODate.Name = "dtpSODate"
        Me.dtpSODate.Size = New System.Drawing.Size(97, 21)
        Me.dtpSODate.TabIndex = 1
        '
        'txtRefNo
        '
        Me.txtRefNo.Location = New System.Drawing.Point(113, 66)
        Me.txtRefNo.MaxLength = 50
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(127, 21)
        Me.txtRefNo.TabIndex = 2
        '
        'txtCName
        '
        Me.txtCName.Location = New System.Drawing.Point(546, 39)
        Me.txtCName.Name = "txtCName"
        Me.txtCName.ReadOnly = True
        Me.txtCName.Size = New System.Drawing.Size(217, 21)
        Me.txtCName.TabIndex = 7
        Me.txtCName.TabStop = False
        '
        'txtCCode
        '
        Me.txtCCode.Location = New System.Drawing.Point(546, 11)
        Me.txtCCode.Name = "txtCCode"
        Me.txtCCode.ReadOnly = True
        Me.txtCCode.Size = New System.Drawing.Size(80, 21)
        Me.txtCCode.TabIndex = 5
        Me.txtCCode.TabStop = False
        '
        'ListView1
        '
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(10, 241)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1241, 206)
        Me.ListView1.TabIndex = 36
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'txtSORemarks
        '
        Me.txtSORemarks.Location = New System.Drawing.Point(64, 536)
        Me.txtSORemarks.MaxLength = 255
        Me.txtSORemarks.Multiline = True
        Me.txtSORemarks.Name = "txtSORemarks"
        Me.txtSORemarks.Size = New System.Drawing.Size(458, 59)
        Me.txtSORemarks.TabIndex = 38
        '
        'txtSOGross
        '
        Me.txtSOGross.Location = New System.Drawing.Point(1110, 458)
        Me.txtSOGross.Name = "txtSOGross"
        Me.txtSOGross.ReadOnly = True
        Me.txtSOGross.Size = New System.Drawing.Size(140, 21)
        Me.txtSOGross.TabIndex = 42
        Me.txtSOGross.TabStop = False
        Me.txtSOGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSOTax
        '
        Me.txtSOTax.Location = New System.Drawing.Point(1110, 539)
        Me.txtSOTax.Name = "txtSOTax"
        Me.txtSOTax.ReadOnly = True
        Me.txtSOTax.Size = New System.Drawing.Size(140, 21)
        Me.txtSOTax.TabIndex = 45
        Me.txtSOTax.TabStop = False
        Me.txtSOTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSOTotal
        '
        Me.txtSOTotal.Location = New System.Drawing.Point(1110, 568)
        Me.txtSOTotal.Name = "txtSOTotal"
        Me.txtSOTotal.ReadOnly = True
        Me.txtSOTotal.Size = New System.Drawing.Size(140, 21)
        Me.txtSOTotal.TabIndex = 46
        Me.txtSOTotal.TabStop = False
        Me.txtSOTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(900, 601)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 26)
        Me.btnCancel.TabIndex = 53
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(630, 601)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(84, 26)
        Me.btnEdit.TabIndex = 50
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(720, 601)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnAdd.TabIndex = 51
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(540, 601)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 26)
        Me.btnDelete.TabIndex = 49
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(810, 601)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 26)
        Me.btnSave.TabIndex = 52
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(452, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Customer Code*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1004, 458)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Subtotal"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1003, 539)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Tax"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1004, 568)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Total"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Sales Order No.*"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 70)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Ref. No."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(452, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Payment Terms"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 536)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Remarks"
        '
        'btnDeleteD
        '
        Me.btnDeleteD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteD.ImageIndex = 1
        Me.btnDeleteD.ImageList = Me.ImageList1
        Me.btnDeleteD.Location = New System.Drawing.Point(1190, 169)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 34
        Me.btnDeleteD.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Checkmark.png")
        Me.ImageList1.Images.SetKeyName(1, "Remove.png")
        Me.ImageList1.Images.SetKeyName(2, "Box.png")
        Me.ImageList1.Images.SetKeyName(3, "Search.png")
        Me.ImageList1.Images.SetKeyName(4, "add.png")
        '
        'btnSaveD
        '
        Me.btnSaveD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveD.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSaveD.ImageIndex = 0
        Me.btnSaveD.ImageList = Me.ImageList1
        Me.btnSaveD.Location = New System.Drawing.Point(1158, 169)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 33
        Me.btnSaveD.UseVisualStyleBackColor = True
        '
        'btnSKU
        '
        Me.btnSKU.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSKU.ImageIndex = 2
        Me.btnSKU.ImageList = Me.ImageList1
        Me.btnSKU.Location = New System.Drawing.Point(138, 211)
        Me.btnSKU.Name = "btnSKU"
        Me.btnSKU.Size = New System.Drawing.Size(29, 25)
        Me.btnSKU.TabIndex = 18
        Me.btnSKU.UseVisualStyleBackColor = True
        '
        'btnCustomer
        '
        Me.btnCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomer.ImageIndex = 3
        Me.btnCustomer.ImageList = Me.ImageList1
        Me.btnCustomer.Location = New System.Drawing.Point(630, 9)
        Me.btnCustomer.Name = "btnCustomer"
        Me.btnCustomer.Size = New System.Drawing.Size(29, 25)
        Me.btnCustomer.TabIndex = 6
        Me.btnCustomer.UseVisualStyleBackColor = True
        '
        'cmbSODtlType
        '
        Me.cmbSODtlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSODtlType.FormattingEnabled = True
        Me.cmbSODtlType.Location = New System.Drawing.Point(10, 214)
        Me.cmbSODtlType.Name = "cmbSODtlType"
        Me.cmbSODtlType.Size = New System.Drawing.Size(52, 21)
        Me.cmbSODtlType.TabIndex = 16
        '
        'txtSKUCode
        '
        Me.txtSKUCode.Location = New System.Drawing.Point(66, 214)
        Me.txtSKUCode.MaxLength = 50
        Me.txtSKUCode.Name = "txtSKUCode"
        Me.txtSKUCode.ReadOnly = True
        Me.txtSKUCode.Size = New System.Drawing.Size(70, 21)
        Me.txtSKUCode.TabIndex = 17
        '
        'txtSODtlDesc
        '
        Me.txtSODtlDesc.Location = New System.Drawing.Point(170, 215)
        Me.txtSODtlDesc.MaxLength = 100
        Me.txtSODtlDesc.Name = "txtSODtlDesc"
        Me.txtSODtlDesc.Size = New System.Drawing.Size(148, 21)
        Me.txtSODtlDesc.TabIndex = 19
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(1084, 601)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 26)
        Me.btnPrint.TabIndex = 54
        Me.btnPrint.Text = "Print SO"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'cmbSOType
        '
        Me.cmbSOType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSOType.FormattingEnabled = True
        Me.cmbSOType.Location = New System.Drawing.Point(113, 93)
        Me.cmbSOType.Name = "cmbSOType"
        Me.cmbSOType.Size = New System.Drawing.Size(112, 21)
        Me.cmbSOType.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 96)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 13)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "Sales Order Type"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(925, 94)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "Status"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1003, 512)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Subtotal After Disc."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(1004, 485)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "Discount"
        '
        'txtSOSubtotal
        '
        Me.txtSOSubtotal.Location = New System.Drawing.Point(1110, 512)
        Me.txtSOSubtotal.Name = "txtSOSubtotal"
        Me.txtSOSubtotal.ReadOnly = True
        Me.txtSOSubtotal.Size = New System.Drawing.Size(140, 21)
        Me.txtSOSubtotal.TabIndex = 44
        Me.txtSOSubtotal.TabStop = False
        Me.txtSOSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSODiscount
        '
        Me.txtSODiscount.Location = New System.Drawing.Point(1110, 485)
        Me.txtSODiscount.Name = "txtSODiscount"
        Me.txtSODiscount.ReadOnly = True
        Me.txtSODiscount.Size = New System.Drawing.Size(140, 21)
        Me.txtSODiscount.TabIndex = 43
        Me.txtSODiscount.TabStop = False
        Me.txtSODiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(600, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(30, 13)
        Me.Label16.TabIndex = 59
        Me.Label16.Text = "days"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(9, 198)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 13)
        Me.Label17.TabIndex = 60
        Me.Label17.Text = "Line Type"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(63, 197)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 13)
        Me.Label18.TabIndex = 61
        Me.Label18.Text = "Code*"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(167, 197)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(82, 13)
        Me.Label19.TabIndex = 62
        Me.Label19.Text = "Line Description"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(431, 198)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(29, 13)
        Me.Label20.TabIndex = 63
        Me.Label20.Text = "Qty."
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(658, 199)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(52, 13)
        Me.Label21.TabIndex = 64
        Me.Label21.Text = "Unit Price"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(806, 197)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(44, 13)
        Me.Label22.TabIndex = 65
        Me.Label22.Text = "Disc. %"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(452, 42)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(83, 13)
        Me.Label23.TabIndex = 66
        Me.Label23.Text = "Customer Name"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(861, 197)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(70, 13)
        Me.Label24.TabIndex = 69
        Me.Label24.Text = "Disc. Amount"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(1033, 197)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(39, 13)
        Me.Label25.TabIndex = 70
        Me.Label25.Text = "Tax %"
        '
        'btnAddD
        '
        Me.btnAddD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD.ImageIndex = 4
        Me.btnAddD.ImageList = Me.ImageList1
        Me.btnAddD.Location = New System.Drawing.Point(1221, 169)
        Me.btnAddD.Name = "btnAddD"
        Me.btnAddD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD.TabIndex = 35
        Me.btnAddD.UseVisualStyleBackColor = True
        '
        'txtSOStatus
        '
        Me.txtSOStatus.Location = New System.Drawing.Point(1019, 91)
        Me.txtSOStatus.Name = "txtSOStatus"
        Me.txtSOStatus.ReadOnly = True
        Me.txtSOStatus.Size = New System.Drawing.Size(112, 21)
        Me.txtSOStatus.TabIndex = 15
        '
        'txtSONetAmt
        '
        Me.txtSONetAmt.Location = New System.Drawing.Point(1158, 215)
        Me.txtSONetAmt.Name = "txtSONetAmt"
        Me.txtSONetAmt.ReadOnly = True
        Me.txtSONetAmt.Size = New System.Drawing.Size(93, 21)
        Me.txtSONetAmt.TabIndex = 32
        Me.txtSONetAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSOTaxAmt
        '
        Me.txtSOTaxAmt.Location = New System.Drawing.Point(1078, 215)
        Me.txtSOTaxAmt.Name = "txtSOTaxAmt"
        Me.txtSOTaxAmt.ReadOnly = True
        Me.txtSOTaxAmt.Size = New System.Drawing.Size(76, 21)
        Me.txtSOTaxAmt.TabIndex = 31
        Me.txtSOTaxAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSOGrossAmt
        '
        Me.txtSOGrossAmt.Location = New System.Drawing.Point(715, 215)
        Me.txtSOGrossAmt.Name = "txtSOGrossAmt"
        Me.txtSOGrossAmt.ReadOnly = True
        Me.txtSOGrossAmt.Size = New System.Drawing.Size(82, 21)
        Me.txtSOGrossAmt.TabIndex = 26
        Me.txtSOGrossAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSOGrossAfterDiscAmt
        '
        Me.txtSOGrossAfterDiscAmt.Location = New System.Drawing.Point(933, 215)
        Me.txtSOGrossAfterDiscAmt.Name = "txtSOGrossAfterDiscAmt"
        Me.txtSOGrossAfterDiscAmt.ReadOnly = True
        Me.txtSOGrossAfterDiscAmt.Size = New System.Drawing.Size(97, 21)
        Me.txtSOGrossAfterDiscAmt.TabIndex = 29
        Me.txtSOGrossAfterDiscAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(725, 198)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(74, 13)
        Me.Label26.TabIndex = 82
        Me.Label26.Text = "Gross Amount"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(942, 197)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(88, 13)
        Me.Label27.TabIndex = 83
        Me.Label27.Text = "Gross After Disc."
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(1089, 197)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(65, 13)
        Me.Label28.TabIndex = 84
        Me.Label28.Text = "Tax Amount"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(1187, 197)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(64, 13)
        Me.Label29.TabIndex = 85
        Me.Label29.Text = "Net Amount"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(11, 483)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(75, 13)
        Me.Label30.TabIndex = 87
        Me.Label30.Text = "Stock Barcode"
        Me.Label30.Visible = False
        '
        'txtSKUBarcode
        '
        Me.txtSKUBarcode.Location = New System.Drawing.Point(9, 499)
        Me.txtSKUBarcode.MaxLength = 50
        Me.txtSKUBarcode.Name = "txtSKUBarcode"
        Me.txtSKUBarcode.Size = New System.Drawing.Size(235, 21)
        Me.txtSKUBarcode.TabIndex = 37
        Me.txtSKUBarcode.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(925, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "Required Date"
        '
        'dtpDeliveryDate
        '
        Me.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDeliveryDate.Location = New System.Drawing.Point(1019, 38)
        Me.dtpDeliveryDate.Name = "dtpDeliveryDate"
        Me.dtpDeliveryDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpDeliveryDate.TabIndex = 13
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(925, 66)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(45, 13)
        Me.Label15.TabIndex = 91
        Me.Label15.Text = "Contact"
        '
        'txtCContact
        '
        Me.txtCContact.Location = New System.Drawing.Point(1019, 64)
        Me.txtCContact.Name = "txtCContact"
        Me.txtCContact.Size = New System.Drawing.Size(217, 21)
        Me.txtCContact.TabIndex = 14
        Me.txtCContact.TabStop = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(651, 69)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(30, 13)
        Me.Label31.TabIndex = 95
        Me.Label31.Text = "Rate"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(452, 67)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(79, 13)
        Me.Label32.TabIndex = 93
        Me.Label32.Text = "Currency Code"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(569, 199)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(62, 13)
        Me.Label33.TabIndex = 97
        Me.Label33.Text = "Lot Job No."
        '
        'txtLotJobNo
        '
        Me.txtLotJobNo.Location = New System.Drawing.Point(568, 215)
        Me.txtLotJobNo.MaxLength = 50
        Me.txtLotJobNo.Name = "txtLotJobNo"
        Me.txtLotJobNo.Size = New System.Drawing.Size(58, 21)
        Me.txtLotJobNo.TabIndex = 24
        '
        'txtCurrCode
        '
        Me.txtCurrCode.Location = New System.Drawing.Point(546, 66)
        Me.txtCurrCode.Name = "txtCurrCode"
        Me.txtCurrCode.ReadOnly = True
        Me.txtCurrCode.Size = New System.Drawing.Size(50, 21)
        Me.txtCurrCode.TabIndex = 8
        Me.txtCurrCode.TabStop = False
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(757, 568)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(58, 13)
        Me.Label34.TabIndex = 108
        Me.Label34.Text = "Local Total"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(757, 540)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(52, 13)
        Me.Label35.TabIndex = 107
        Me.Label35.Text = "Local Tax"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(757, 512)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(74, 13)
        Me.Label36.TabIndex = 106
        Me.Label36.Text = "Local Subtotal"
        '
        'txtLocalSOTotal
        '
        Me.txtLocalSOTotal.Location = New System.Drawing.Point(851, 565)
        Me.txtLocalSOTotal.Name = "txtLocalSOTotal"
        Me.txtLocalSOTotal.ReadOnly = True
        Me.txtLocalSOTotal.Size = New System.Drawing.Size(118, 21)
        Me.txtLocalSOTotal.TabIndex = 41
        Me.txtLocalSOTotal.TabStop = False
        Me.txtLocalSOTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLocalSOTax
        '
        Me.txtLocalSOTax.Location = New System.Drawing.Point(851, 536)
        Me.txtLocalSOTax.Name = "txtLocalSOTax"
        Me.txtLocalSOTax.ReadOnly = True
        Me.txtLocalSOTax.Size = New System.Drawing.Size(118, 21)
        Me.txtLocalSOTax.TabIndex = 40
        Me.txtLocalSOTax.TabStop = False
        Me.txtLocalSOTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLocalSOSubTotal
        '
        Me.txtLocalSOSubTotal.Location = New System.Drawing.Point(851, 509)
        Me.txtLocalSOSubTotal.Name = "txtLocalSOSubTotal"
        Me.txtLocalSOSubTotal.ReadOnly = True
        Me.txtLocalSOSubTotal.Size = New System.Drawing.Size(118, 21)
        Me.txtLocalSOSubTotal.TabIndex = 39
        Me.txtLocalSOSubTotal.TabStop = False
        Me.txtLocalSOSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSlsCode
        '
        Me.btnSlsCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSlsCode.ImageIndex = 3
        Me.btnSlsCode.ImageList = Me.ImageList1
        Me.btnSlsCode.Location = New System.Drawing.Point(1103, 9)
        Me.btnSlsCode.Name = "btnSlsCode"
        Me.btnSlsCode.Size = New System.Drawing.Size(29, 25)
        Me.btnSlsCode.TabIndex = 12
        Me.btnSlsCode.UseVisualStyleBackColor = True
        '
        'txtSlsCode
        '
        Me.txtSlsCode.Location = New System.Drawing.Point(1019, 11)
        Me.txtSlsCode.Name = "txtSlsCode"
        Me.txtSlsCode.ReadOnly = True
        Me.txtSlsCode.Size = New System.Drawing.Size(80, 21)
        Me.txtSlsCode.TabIndex = 11
        Me.txtSlsCode.TabStop = False
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(925, 16)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(66, 13)
        Me.Label37.TabIndex = 110
        Me.Label37.Text = "Sales Code*"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(323, 196)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(53, 13)
        Me.Label38.TabIndex = 115
        Me.Label38.Text = "Location*"
        '
        'txtLocationCode
        '
        Me.txtLocationCode.Location = New System.Drawing.Point(323, 215)
        Me.txtLocationCode.Name = "txtLocationCode"
        Me.txtLocationCode.ReadOnly = True
        Me.txtLocationCode.Size = New System.Drawing.Size(60, 21)
        Me.txtLocationCode.TabIndex = 20
        Me.txtLocationCode.TabStop = False
        '
        'btnLocation
        '
        Me.btnLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLocation.ImageIndex = 2
        Me.btnLocation.ImageList = Me.ImageList1
        Me.btnLocation.Location = New System.Drawing.Point(388, 213)
        Me.btnLocation.Name = "btnLocation"
        Me.btnLocation.Size = New System.Drawing.Size(29, 25)
        Me.btnLocation.TabIndex = 21
        Me.btnLocation.UseVisualStyleBackColor = True
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(466, 199)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(98, 13)
        Me.Label39.TabIndex = 117
        Me.Label39.Text = "Req. Delivery Date"
        '
        'dtpRequiredDeliveryDate
        '
        Me.dtpRequiredDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRequiredDeliveryDate.Location = New System.Drawing.Point(466, 215)
        Me.dtpRequiredDeliveryDate.Name = "dtpRequiredDeliveryDate"
        Me.dtpRequiredDeliveryDate.ShowCheckBox = True
        Me.dtpRequiredDeliveryDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpRequiredDeliveryDate.TabIndex = 23
        '
        'btnCloseSO
        '
        Me.btnCloseSO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseSO.Location = New System.Drawing.Point(450, 601)
        Me.btnCloseSO.Name = "btnCloseSO"
        Me.btnCloseSO.Size = New System.Drawing.Size(84, 26)
        Me.btnCloseSO.TabIndex = 48
        Me.btnCloseSO.Text = "Close SO"
        Me.btnCloseSO.UseVisualStyleBackColor = True
        '
        'lblClosedDescription
        '
        Me.lblClosedDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClosedDescription.Location = New System.Drawing.Point(925, 134)
        Me.lblClosedDescription.Name = "lblClosedDescription"
        Me.lblClosedDescription.Size = New System.Drawing.Size(311, 16)
        Me.lblClosedDescription.TabIndex = 119
        Me.lblClosedDescription.Text = "This SO was CLOSED by"
        Me.lblClosedDescription.Visible = False
        '
        'txtSInvoiceNo
        '
        Me.txtSInvoiceNo.Location = New System.Drawing.Point(113, 120)
        Me.txtSInvoiceNo.Name = "txtSInvoiceNo"
        Me.txtSInvoiceNo.ReadOnly = True
        Me.txtSInvoiceNo.Size = New System.Drawing.Size(127, 21)
        Me.txtSInvoiceNo.TabIndex = 4
        Me.txtSInvoiceNo.TabStop = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(11, 123)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(86, 13)
        Me.Label41.TabIndex = 121
        Me.Label41.Text = "Invoice No. Ref."
        '
        'btnInvoiceNo
        '
        Me.btnInvoiceNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInvoiceNo.Location = New System.Drawing.Point(321, 601)
        Me.btnInvoiceNo.Name = "btnInvoiceNo"
        Me.btnInvoiceNo.Size = New System.Drawing.Size(123, 26)
        Me.btnInvoiceNo.TabIndex = 47
        Me.btnInvoiceNo.Text = "Invoice No. Booking"
        Me.btnInvoiceNo.UseVisualStyleBackColor = True
        '
        'ntbSOCurrRate
        '
        Me.ntbSOCurrRate.AllowSpace = False
        Me.ntbSOCurrRate.Location = New System.Drawing.Point(687, 66)
        Me.ntbSOCurrRate.MaxLength = 10
        Me.ntbSOCurrRate.Name = "ntbSOCurrRate"
        Me.ntbSOCurrRate.Size = New System.Drawing.Size(76, 21)
        Me.ntbSOCurrRate.TabIndex = 9
        Me.ntbSOCurrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSOTaxPercent
        '
        Me.ntbSOTaxPercent.AllowSpace = False
        Me.ntbSOTaxPercent.Location = New System.Drawing.Point(1033, 215)
        Me.ntbSOTaxPercent.MaxLength = 3
        Me.ntbSOTaxPercent.Name = "ntbSOTaxPercent"
        Me.ntbSOTaxPercent.Size = New System.Drawing.Size(40, 21)
        Me.ntbSOTaxPercent.TabIndex = 30
        Me.ntbSOTaxPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSODiscAmt
        '
        Me.ntbSODiscAmt.AllowSpace = False
        Me.ntbSODiscAmt.Location = New System.Drawing.Point(848, 215)
        Me.ntbSODiscAmt.MaxLength = 14
        Me.ntbSODiscAmt.Name = "ntbSODiscAmt"
        Me.ntbSODiscAmt.Size = New System.Drawing.Size(81, 21)
        Me.ntbSODiscAmt.TabIndex = 28
        Me.ntbSODiscAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSODiscPercent
        '
        Me.ntbSODiscPercent.AllowSpace = False
        Me.ntbSODiscPercent.Location = New System.Drawing.Point(802, 215)
        Me.ntbSODiscPercent.MaxLength = 3
        Me.ntbSODiscPercent.Name = "ntbSODiscPercent"
        Me.ntbSODiscPercent.Size = New System.Drawing.Size(40, 21)
        Me.ntbSODiscPercent.TabIndex = 27
        Me.ntbSODiscPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbPaymentTerms
        '
        Me.ntbPaymentTerms.AllowSpace = False
        Me.ntbPaymentTerms.Location = New System.Drawing.Point(546, 93)
        Me.ntbPaymentTerms.MaxLength = 3
        Me.ntbPaymentTerms.Name = "ntbPaymentTerms"
        Me.ntbPaymentTerms.Size = New System.Drawing.Size(49, 21)
        Me.ntbPaymentTerms.TabIndex = 10
        Me.ntbPaymentTerms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSOPrice
        '
        Me.ntbSOPrice.AllowSpace = False
        Me.ntbSOPrice.Location = New System.Drawing.Point(630, 215)
        Me.ntbSOPrice.MaxLength = 18
        Me.ntbSOPrice.Name = "ntbSOPrice"
        Me.ntbSOPrice.Size = New System.Drawing.Size(80, 21)
        Me.ntbSOPrice.TabIndex = 25
        Me.ntbSOPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSOQty
        '
        Me.ntbSOQty.AllowSpace = False
        Me.ntbSOQty.Location = New System.Drawing.Point(420, 215)
        Me.ntbSOQty.MaxLength = 12
        Me.ntbSOQty.Name = "ntbSOQty"
        Me.ntbSOQty.Size = New System.Drawing.Size(40, 21)
        Me.ntbSOQty.TabIndex = 22
        Me.ntbSOQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPrintSInv
        '
        Me.btnPrintSInv.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintSInv.Location = New System.Drawing.Point(1174, 601)
        Me.btnPrintSInv.Name = "btnPrintSInv"
        Me.btnPrintSInv.Size = New System.Drawing.Size(84, 26)
        Me.btnPrintSInv.TabIndex = 55
        Me.btnPrintSInv.Text = "Print S. Inv."
        Me.btnPrintSInv.UseVisualStyleBackColor = True
        '
        'ntbSOPriceIncludeTax
        '
        Me.ntbSOPriceIncludeTax.AllowSpace = False
        Me.ntbSOPriceIncludeTax.Location = New System.Drawing.Point(630, 172)
        Me.ntbSOPriceIncludeTax.MaxLength = 18
        Me.ntbSOPriceIncludeTax.Name = "ntbSOPriceIncludeTax"
        Me.ntbSOPriceIncludeTax.Size = New System.Drawing.Size(80, 21)
        Me.ntbSOPriceIncludeTax.TabIndex = 123
        Me.ntbSOPriceIncludeTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbIncludeTax
        '
        Me.cbIncludeTax.AutoSize = True
        Me.cbIncludeTax.Location = New System.Drawing.Point(630, 154)
        Me.cbIncludeTax.Name = "cbIncludeTax"
        Me.cbIncludeTax.Size = New System.Drawing.Size(116, 17)
        Me.cbIncludeTax.TabIndex = 122
        Me.cbIncludeTax.Text = "Price Including Tax"
        Me.cbIncludeTax.UseVisualStyleBackColor = True
        '
        'btnPrintPackingSlip
        '
        Me.btnPrintPackingSlip.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintPackingSlip.Location = New System.Drawing.Point(994, 601)
        Me.btnPrintPackingSlip.Name = "btnPrintPackingSlip"
        Me.btnPrintPackingSlip.Size = New System.Drawing.Size(84, 26)
        Me.btnPrintPackingSlip.TabIndex = 124
        Me.btnPrintPackingSlip.Text = "Packing Slip"
        Me.btnPrintPackingSlip.UseVisualStyleBackColor = True
        '
        'frmSO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1262, 632)
        Me.Controls.Add(Me.btnPrintPackingSlip)
        Me.Controls.Add(Me.ntbSOPriceIncludeTax)
        Me.Controls.Add(Me.cbIncludeTax)
        Me.Controls.Add(Me.btnPrintSInv)
        Me.Controls.Add(Me.btnInvoiceNo)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.txtSInvoiceNo)
        Me.Controls.Add(Me.lblClosedDescription)
        Me.Controls.Add(Me.btnCloseSO)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.dtpRequiredDeliveryDate)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.txtLocationCode)
        Me.Controls.Add(Me.btnLocation)
        Me.Controls.Add(Me.btnSlsCode)
        Me.Controls.Add(Me.txtSlsCode)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.txtLocalSOTotal)
        Me.Controls.Add(Me.txtLocalSOTax)
        Me.Controls.Add(Me.txtLocalSOSubTotal)
        Me.Controls.Add(Me.txtCurrCode)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.txtLotJobNo)
        Me.Controls.Add(Me.ntbSOCurrRate)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtCContact)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtpDeliveryDate)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtSKUBarcode)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtSOGrossAfterDiscAmt)
        Me.Controls.Add(Me.txtSONetAmt)
        Me.Controls.Add(Me.txtSOTaxAmt)
        Me.Controls.Add(Me.txtSOGrossAmt)
        Me.Controls.Add(Me.txtSOStatus)
        Me.Controls.Add(Me.btnAddD)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.ntbSOTaxPercent)
        Me.Controls.Add(Me.ntbSODiscAmt)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtSOSubtotal)
        Me.Controls.Add(Me.txtSODiscount)
        Me.Controls.Add(Me.ntbSODiscPercent)
        Me.Controls.Add(Me.ntbPaymentTerms)
        Me.Controls.Add(Me.ntbSOPrice)
        Me.Controls.Add(Me.ntbSOQty)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cmbSOType)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.txtSODtlDesc)
        Me.Controls.Add(Me.txtSKUCode)
        Me.Controls.Add(Me.cmbSODtlType)
        Me.Controls.Add(Me.btnSKU)
        Me.Controls.Add(Me.btnCustomer)
        Me.Controls.Add(Me.btnDeleteD)
        Me.Controls.Add(Me.btnSaveD)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtSOTotal)
        Me.Controls.Add(Me.txtSOTax)
        Me.Controls.Add(Me.txtSOGross)
        Me.Controls.Add(Me.txtSORemarks)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.txtCCode)
        Me.Controls.Add(Me.txtCName)
        Me.Controls.Add(Me.txtRefNo)
        Me.Controls.Add(Me.dtpSODate)
        Me.Controls.Add(Me.txtSONo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSO"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Order"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSONo As System.Windows.Forms.TextBox
    Friend WithEvents dtpSODate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCName As System.Windows.Forms.TextBox
    Friend WithEvents txtCCode As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents txtSORemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtSOGross As System.Windows.Forms.TextBox
    Friend WithEvents txtSOTax As System.Windows.Forms.TextBox
    Friend WithEvents txtSOTotal As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnDeleteD As System.Windows.Forms.Button
    Friend WithEvents btnSaveD As System.Windows.Forms.Button
    Friend WithEvents btnSKU As System.Windows.Forms.Button
    Friend WithEvents btnCustomer As System.Windows.Forms.Button
    Friend WithEvents cmbSODtlType As System.Windows.Forms.ComboBox
    Friend WithEvents txtSKUCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSODtlDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents cmbSOType As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ntbSOQty As levate.NumericTextBox
    Friend WithEvents ntbSOPrice As levate.NumericTextBox
    Friend WithEvents ntbPaymentTerms As levate.NumericTextBox
    Friend WithEvents ntbSODiscPercent As levate.NumericTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSOSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents txtSODiscount As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ntbSODiscAmt As levate.NumericTextBox
    Friend WithEvents ntbSOTaxPercent As levate.NumericTextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents txtSOStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtSONetAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtSOTaxAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtSOGrossAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtSOGrossAfterDiscAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtSKUBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCContact As System.Windows.Forms.TextBox
    Friend WithEvents ntbSOCurrRate As levate.NumericTextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtLotJobNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrCode As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtLocalSOTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalSOTax As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalSOSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents btnSlsCode As System.Windows.Forms.Button
    Friend WithEvents txtSlsCode As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtLocationCode As System.Windows.Forms.TextBox
    Friend WithEvents btnLocation As System.Windows.Forms.Button
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents dtpRequiredDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCloseSO As System.Windows.Forms.Button
    Friend WithEvents lblClosedDescription As System.Windows.Forms.Label
    Friend WithEvents txtSInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents btnInvoiceNo As System.Windows.Forms.Button
    Friend WithEvents btnPrintSInv As System.Windows.Forms.Button
    Friend WithEvents ntbSOPriceIncludeTax As levate.NumericTextBox
    Friend WithEvents cbIncludeTax As System.Windows.Forms.CheckBox
    Friend WithEvents btnPrintPackingSlip As System.Windows.Forms.Button

End Class
