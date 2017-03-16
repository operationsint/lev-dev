<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPO))
        Me.txtPONo = New System.Windows.Forms.TextBox()
        Me.dtpPODate = New System.Windows.Forms.DateTimePicker()
        Me.dtpDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.txtShipVia = New System.Windows.Forms.TextBox()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.txtSName = New System.Windows.Forms.TextBox()
        Me.txtSCode = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.txtPORemarks = New System.Windows.Forms.TextBox()
        Me.txtPOSubtotal = New System.Windows.Forms.TextBox()
        Me.txtPOTax = New System.Windows.Forms.TextBox()
        Me.txtPOTotal = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnDeleteD = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnSaveD = New System.Windows.Forms.Button()
        Me.btnSKU = New System.Windows.Forms.Button()
        Me.btnSupplier = New System.Windows.Forms.Button()
        Me.cmbPODtlType = New System.Windows.Forms.ComboBox()
        Me.txtSKUCode = New System.Windows.Forms.TextBox()
        Me.txtPODtlDesc = New System.Windows.Forms.TextBox()
        Me.cmbPaymentMethod = New System.Windows.Forms.ComboBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.cmbPOType = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAddD = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtSKUUoM = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPOStatus = New System.Windows.Forms.TextBox()
        Me.txtPOGrossAmt = New System.Windows.Forms.TextBox()
        Me.txtPOTaxAmt = New System.Windows.Forms.TextBox()
        Me.txtPONetAmt = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtPRequestNo = New System.Windows.Forms.TextBox()
        Me.btnPRequest = New System.Windows.Forms.Button()
        Me.txtCurrCode = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtLocationCode = New System.Windows.Forms.TextBox()
        Me.btnLocation = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtLocalPOTotal = New System.Windows.Forms.TextBox()
        Me.txtLocalPOTax = New System.Windows.Forms.TextBox()
        Me.txtLocalPOSubTotal = New System.Windows.Forms.TextBox()
        Me.txtRevise = New System.Windows.Forms.TextBox()
        Me.txtPrinted = New System.Windows.Forms.TextBox()
        Me.btnPchCode = New System.Windows.Forms.Button()
        Me.txtPchCode = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.cbIncludeTax = New System.Windows.Forms.CheckBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ntbPOPriceIncludeTax = New levate.NumericTextBox()
        Me.ntbPOCurrRate = New levate.NumericTextBox()
        Me.ntbPOTaxPercent = New levate.NumericTextBox()
        Me.ntbPaymentTerms = New levate.NumericTextBox()
        Me.ntbPOPrice = New levate.NumericTextBox()
        Me.ntbPOQty = New levate.NumericTextBox()
        Me.SuspendLayout()
        '
        'txtPONo
        '
        Me.txtPONo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPONo.Location = New System.Drawing.Point(139, 12)
        Me.txtPONo.MaxLength = 12
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.Size = New System.Drawing.Size(127, 21)
        Me.txtPONo.TabIndex = 0
        '
        'dtpPODate
        '
        Me.dtpPODate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPODate.Location = New System.Drawing.Point(139, 40)
        Me.dtpPODate.Name = "dtpPODate"
        Me.dtpPODate.Size = New System.Drawing.Size(97, 21)
        Me.dtpPODate.TabIndex = 2
        '
        'dtpDeliveryDate
        '
        Me.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDeliveryDate.Location = New System.Drawing.Point(139, 95)
        Me.dtpDeliveryDate.Name = "dtpDeliveryDate"
        Me.dtpDeliveryDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpDeliveryDate.TabIndex = 4
        '
        'txtShipVia
        '
        Me.txtShipVia.Location = New System.Drawing.Point(936, 39)
        Me.txtShipVia.MaxLength = 50
        Me.txtShipVia.Name = "txtShipVia"
        Me.txtShipVia.Size = New System.Drawing.Size(219, 21)
        Me.txtShipVia.TabIndex = 14
        '
        'txtRefNo
        '
        Me.txtRefNo.Location = New System.Drawing.Point(936, 66)
        Me.txtRefNo.MaxLength = 50
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(155, 21)
        Me.txtRefNo.TabIndex = 15
        '
        'txtSName
        '
        Me.txtSName.Location = New System.Drawing.Point(540, 41)
        Me.txtSName.Name = "txtSName"
        Me.txtSName.ReadOnly = True
        Me.txtSName.Size = New System.Drawing.Size(217, 21)
        Me.txtSName.TabIndex = 7
        Me.txtSName.TabStop = False
        '
        'txtSCode
        '
        Me.txtSCode.Location = New System.Drawing.Point(540, 13)
        Me.txtSCode.Name = "txtSCode"
        Me.txtSCode.ReadOnly = True
        Me.txtSCode.Size = New System.Drawing.Size(80, 21)
        Me.txtSCode.TabIndex = 5
        Me.txtSCode.TabStop = False
        '
        'ListView1
        '
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 235)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1151, 198)
        Me.ListView1.TabIndex = 36
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'txtPORemarks
        '
        Me.txtPORemarks.Location = New System.Drawing.Point(75, 449)
        Me.txtPORemarks.MaxLength = 255
        Me.txtPORemarks.Multiline = True
        Me.txtPORemarks.Name = "txtPORemarks"
        Me.txtPORemarks.Size = New System.Drawing.Size(318, 59)
        Me.txtPORemarks.TabIndex = 37
        '
        'txtPOSubtotal
        '
        Me.txtPOSubtotal.Location = New System.Drawing.Point(1014, 446)
        Me.txtPOSubtotal.Name = "txtPOSubtotal"
        Me.txtPOSubtotal.ReadOnly = True
        Me.txtPOSubtotal.Size = New System.Drawing.Size(118, 21)
        Me.txtPOSubtotal.TabIndex = 41
        Me.txtPOSubtotal.TabStop = False
        Me.txtPOSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPOTax
        '
        Me.txtPOTax.Location = New System.Drawing.Point(1014, 473)
        Me.txtPOTax.Name = "txtPOTax"
        Me.txtPOTax.ReadOnly = True
        Me.txtPOTax.Size = New System.Drawing.Size(118, 21)
        Me.txtPOTax.TabIndex = 42
        Me.txtPOTax.TabStop = False
        Me.txtPOTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPOTotal
        '
        Me.txtPOTotal.Location = New System.Drawing.Point(1014, 502)
        Me.txtPOTotal.Name = "txtPOTotal"
        Me.txtPOTotal.ReadOnly = True
        Me.txtPOTotal.Size = New System.Drawing.Size(118, 21)
        Me.txtPOTotal.TabIndex = 43
        Me.txtPOTotal.TabStop = False
        Me.txtPOTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(899, 556)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 26)
        Me.btnCancel.TabIndex = 48
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(629, 556)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(84, 26)
        Me.btnEdit.TabIndex = 45
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(719, 556)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnAdd.TabIndex = 46
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(539, 556)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 26)
        Me.btnDelete.TabIndex = 44
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(809, 556)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 26)
        Me.btnSave.TabIndex = 47
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(443, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Supplier Code*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(443, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Payment Method"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(949, 449)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Subtotal"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(949, 477)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Tax"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(949, 505)
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
        Me.Label6.Size = New System.Drawing.Size(121, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Purchase Order No.*"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Date"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 98)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Required Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(842, 70)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Ref. No."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(842, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Ship via"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 449)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Remarks"
        '
        'btnDeleteD
        '
        Me.btnDeleteD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteD.ImageIndex = 2
        Me.btnDeleteD.ImageList = Me.ImageList1
        Me.btnDeleteD.Location = New System.Drawing.Point(1101, 164)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 34
        Me.btnDeleteD.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Search.png")
        Me.ImageList1.Images.SetKeyName(1, "Box.png")
        Me.ImageList1.Images.SetKeyName(2, "Remove.png")
        Me.ImageList1.Images.SetKeyName(3, "Checkmark.png")
        Me.ImageList1.Images.SetKeyName(4, "Add_Symbol.png")
        '
        'btnSaveD
        '
        Me.btnSaveD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveD.ImageIndex = 3
        Me.btnSaveD.ImageList = Me.ImageList1
        Me.btnSaveD.Location = New System.Drawing.Point(1070, 164)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 33
        Me.btnSaveD.UseVisualStyleBackColor = True
        '
        'btnSKU
        '
        Me.btnSKU.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSKU.ImageIndex = 1
        Me.btnSKU.ImageList = Me.ImageList1
        Me.btnSKU.Location = New System.Drawing.Point(190, 206)
        Me.btnSKU.Name = "btnSKU"
        Me.btnSKU.Size = New System.Drawing.Size(29, 25)
        Me.btnSKU.TabIndex = 22
        Me.btnSKU.UseVisualStyleBackColor = True
        '
        'btnSupplier
        '
        Me.btnSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupplier.ImageIndex = 0
        Me.btnSupplier.ImageList = Me.ImageList1
        Me.btnSupplier.Location = New System.Drawing.Point(623, 10)
        Me.btnSupplier.Name = "btnSupplier"
        Me.btnSupplier.Size = New System.Drawing.Size(29, 25)
        Me.btnSupplier.TabIndex = 6
        Me.btnSupplier.UseVisualStyleBackColor = True
        '
        'cmbPODtlType
        '
        Me.cmbPODtlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPODtlType.FormattingEnabled = True
        Me.cmbPODtlType.Location = New System.Drawing.Point(15, 208)
        Me.cmbPODtlType.Name = "cmbPODtlType"
        Me.cmbPODtlType.Size = New System.Drawing.Size(88, 21)
        Me.cmbPODtlType.TabIndex = 20
        '
        'txtSKUCode
        '
        Me.txtSKUCode.Location = New System.Drawing.Point(108, 208)
        Me.txtSKUCode.MaxLength = 50
        Me.txtSKUCode.Name = "txtSKUCode"
        Me.txtSKUCode.ReadOnly = True
        Me.txtSKUCode.Size = New System.Drawing.Size(80, 21)
        Me.txtSKUCode.TabIndex = 21
        Me.txtSKUCode.TabStop = False
        '
        'txtPODtlDesc
        '
        Me.txtPODtlDesc.Location = New System.Drawing.Point(222, 208)
        Me.txtPODtlDesc.MaxLength = 100
        Me.txtPODtlDesc.Name = "txtPODtlDesc"
        Me.txtPODtlDesc.Size = New System.Drawing.Size(209, 21)
        Me.txtPODtlDesc.TabIndex = 23
        '
        'cmbPaymentMethod
        '
        Me.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaymentMethod.FormattingEnabled = True
        Me.cmbPaymentMethod.Location = New System.Drawing.Point(540, 125)
        Me.cmbPaymentMethod.Name = "cmbPaymentMethod"
        Me.cmbPaymentMethod.Size = New System.Drawing.Size(112, 21)
        Me.cmbPaymentMethod.TabIndex = 11
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(1082, 556)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 26)
        Me.btnPrint.TabIndex = 50
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'cmbPOType
        '
        Me.cmbPOType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPOType.FormattingEnabled = True
        Me.cmbPOType.Location = New System.Drawing.Point(139, 67)
        Me.cmbPOType.Name = "cmbPOType"
        Me.cmbPOType.Size = New System.Drawing.Size(112, 21)
        Me.cmbPOType.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 70)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(109, 13)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "Purchase Order Type"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(842, 125)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "Status"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(596, 99)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 13)
        Me.Label15.TabIndex = 52
        Me.Label15.Text = "days"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(14, 191)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 13)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "Line Type"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(109, 192)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 13)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Code*"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(226, 191)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "Line Description"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(580, 189)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(29, 13)
        Me.Label19.TabIndex = 60
        Me.Label19.Text = "Qty."
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(443, 42)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(75, 13)
        Me.Label21.TabIndex = 62
        Me.Label21.Text = "Supplier Name"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(904, 189)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(39, 13)
        Me.Label22.TabIndex = 64
        Me.Label22.Text = "Tax %"
        '
        'btnAddD
        '
        Me.btnAddD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD.ImageIndex = 4
        Me.btnAddD.ImageList = Me.ImageList1
        Me.btnAddD.Location = New System.Drawing.Point(1132, 164)
        Me.btnAddD.Name = "btnAddD"
        Me.btnAddD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD.TabIndex = 35
        Me.btnAddD.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(978, 189)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 13)
        Me.Label23.TabIndex = 67
        Me.Label23.Text = "Tax Amount"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(819, 189)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(74, 13)
        Me.Label24.TabIndex = 69
        Me.Label24.Text = "Gross Amount"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(1097, 189)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 13)
        Me.Label25.TabIndex = 71
        Me.Label25.Text = "Net Amount"
        '
        'txtSKUUoM
        '
        Me.txtSKUUoM.Location = New System.Drawing.Point(615, 208)
        Me.txtSKUUoM.Name = "txtSKUUoM"
        Me.txtSKUUoM.ReadOnly = True
        Me.txtSKUUoM.Size = New System.Drawing.Size(53, 21)
        Me.txtSKUUoM.TabIndex = 27
        Me.txtSKUUoM.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(615, 189)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(28, 13)
        Me.Label26.TabIndex = 73
        Me.Label26.Text = "UoM"
        '
        'txtPOStatus
        '
        Me.txtPOStatus.Location = New System.Drawing.Point(936, 121)
        Me.txtPOStatus.Name = "txtPOStatus"
        Me.txtPOStatus.ReadOnly = True
        Me.txtPOStatus.Size = New System.Drawing.Size(153, 21)
        Me.txtPOStatus.TabIndex = 17
        '
        'txtPOGrossAmt
        '
        Me.txtPOGrossAmt.Location = New System.Drawing.Point(775, 208)
        Me.txtPOGrossAmt.Name = "txtPOGrossAmt"
        Me.txtPOGrossAmt.ReadOnly = True
        Me.txtPOGrossAmt.Size = New System.Drawing.Size(118, 21)
        Me.txtPOGrossAmt.TabIndex = 29
        Me.txtPOGrossAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPOTaxAmt
        '
        Me.txtPOTaxAmt.Location = New System.Drawing.Point(946, 208)
        Me.txtPOTaxAmt.Name = "txtPOTaxAmt"
        Me.txtPOTaxAmt.ReadOnly = True
        Me.txtPOTaxAmt.Size = New System.Drawing.Size(97, 21)
        Me.txtPOTaxAmt.TabIndex = 31
        Me.txtPOTaxAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPONetAmt
        '
        Me.txtPONetAmt.Location = New System.Drawing.Point(1049, 208)
        Me.txtPONetAmt.Name = "txtPONetAmt"
        Me.txtPONetAmt.ReadOnly = True
        Me.txtPONetAmt.Size = New System.Drawing.Size(112, 21)
        Me.txtPONetAmt.TabIndex = 32
        Me.txtPONetAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(443, 71)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(79, 13)
        Me.Label27.TabIndex = 79
        Me.Label27.Text = "Currency Code"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(443, 100)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Payment Terms"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(645, 71)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(30, 13)
        Me.Label28.TabIndex = 81
        Me.Label28.Text = "Rate"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(12, 149)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(114, 13)
        Me.Label29.TabIndex = 83
        Me.Label29.Text = "Purchase Request No."
        '
        'txtPRequestNo
        '
        Me.txtPRequestNo.Location = New System.Drawing.Point(14, 168)
        Me.txtPRequestNo.Name = "txtPRequestNo"
        Me.txtPRequestNo.ReadOnly = True
        Me.txtPRequestNo.Size = New System.Drawing.Size(127, 21)
        Me.txtPRequestNo.TabIndex = 18
        '
        'btnPRequest
        '
        Me.btnPRequest.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPRequest.ImageIndex = 0
        Me.btnPRequest.ImageList = Me.ImageList1
        Me.btnPRequest.Location = New System.Drawing.Point(144, 166)
        Me.btnPRequest.Name = "btnPRequest"
        Me.btnPRequest.Size = New System.Drawing.Size(29, 25)
        Me.btnPRequest.TabIndex = 19
        Me.btnPRequest.UseVisualStyleBackColor = True
        '
        'txtCurrCode
        '
        Me.txtCurrCode.Location = New System.Drawing.Point(540, 68)
        Me.txtCurrCode.Name = "txtCurrCode"
        Me.txtCurrCode.ReadOnly = True
        Me.txtCurrCode.Size = New System.Drawing.Size(50, 21)
        Me.txtCurrCode.TabIndex = 8
        Me.txtCurrCode.TabStop = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(437, 189)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(53, 13)
        Me.Label31.TabIndex = 91
        Me.Label31.Text = "Location*"
        '
        'txtLocationCode
        '
        Me.txtLocationCode.Location = New System.Drawing.Point(437, 208)
        Me.txtLocationCode.Name = "txtLocationCode"
        Me.txtLocationCode.ReadOnly = True
        Me.txtLocationCode.Size = New System.Drawing.Size(80, 21)
        Me.txtLocationCode.TabIndex = 24
        Me.txtLocationCode.TabStop = False
        '
        'btnLocation
        '
        Me.btnLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLocation.ImageIndex = 1
        Me.btnLocation.ImageList = Me.ImageList1
        Me.btnLocation.Location = New System.Drawing.Point(519, 206)
        Me.btnLocation.Name = "btnLocation"
        Me.btnLocation.Size = New System.Drawing.Size(29, 25)
        Me.btnLocation.TabIndex = 25
        Me.btnLocation.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(272, 16)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(47, 13)
        Me.Label32.TabIndex = 94
        Me.Label32.Text = "Revision"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(842, 96)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(41, 13)
        Me.Label33.TabIndex = 96
        Me.Label33.Text = "Printed"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(667, 505)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(58, 13)
        Me.Label34.TabIndex = 102
        Me.Label34.Text = "Local Total"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(667, 477)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(52, 13)
        Me.Label35.TabIndex = 101
        Me.Label35.Text = "Local Tax"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(667, 449)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(74, 13)
        Me.Label36.TabIndex = 100
        Me.Label36.Text = "Local Subtotal"
        '
        'txtLocalPOTotal
        '
        Me.txtLocalPOTotal.Location = New System.Drawing.Point(761, 502)
        Me.txtLocalPOTotal.Name = "txtLocalPOTotal"
        Me.txtLocalPOTotal.ReadOnly = True
        Me.txtLocalPOTotal.Size = New System.Drawing.Size(118, 21)
        Me.txtLocalPOTotal.TabIndex = 40
        Me.txtLocalPOTotal.TabStop = False
        Me.txtLocalPOTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLocalPOTax
        '
        Me.txtLocalPOTax.Location = New System.Drawing.Point(761, 473)
        Me.txtLocalPOTax.Name = "txtLocalPOTax"
        Me.txtLocalPOTax.ReadOnly = True
        Me.txtLocalPOTax.Size = New System.Drawing.Size(118, 21)
        Me.txtLocalPOTax.TabIndex = 39
        Me.txtLocalPOTax.TabStop = False
        Me.txtLocalPOTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLocalPOSubTotal
        '
        Me.txtLocalPOSubTotal.Location = New System.Drawing.Point(761, 446)
        Me.txtLocalPOSubTotal.Name = "txtLocalPOSubTotal"
        Me.txtLocalPOSubTotal.ReadOnly = True
        Me.txtLocalPOSubTotal.Size = New System.Drawing.Size(118, 21)
        Me.txtLocalPOSubTotal.TabIndex = 38
        Me.txtLocalPOSubTotal.TabStop = False
        Me.txtLocalPOSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRevise
        '
        Me.txtRevise.Location = New System.Drawing.Point(325, 14)
        Me.txtRevise.Name = "txtRevise"
        Me.txtRevise.ReadOnly = True
        Me.txtRevise.Size = New System.Drawing.Size(50, 21)
        Me.txtRevise.TabIndex = 1
        Me.txtRevise.TabStop = False
        '
        'txtPrinted
        '
        Me.txtPrinted.Location = New System.Drawing.Point(936, 94)
        Me.txtPrinted.Name = "txtPrinted"
        Me.txtPrinted.ReadOnly = True
        Me.txtPrinted.Size = New System.Drawing.Size(50, 21)
        Me.txtPrinted.TabIndex = 16
        Me.txtPrinted.TabStop = False
        '
        'btnPchCode
        '
        Me.btnPchCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPchCode.ImageIndex = 0
        Me.btnPchCode.ImageList = Me.ImageList1
        Me.btnPchCode.Location = New System.Drawing.Point(1019, 10)
        Me.btnPchCode.Name = "btnPchCode"
        Me.btnPchCode.Size = New System.Drawing.Size(29, 25)
        Me.btnPchCode.TabIndex = 13
        Me.btnPchCode.UseVisualStyleBackColor = True
        '
        'txtPchCode
        '
        Me.txtPchCode.Location = New System.Drawing.Point(936, 12)
        Me.txtPchCode.Name = "txtPchCode"
        Me.txtPchCode.ReadOnly = True
        Me.txtPchCode.Size = New System.Drawing.Size(80, 21)
        Me.txtPchCode.TabIndex = 12
        Me.txtPchCode.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(843, 15)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(85, 13)
        Me.Label37.TabIndex = 107
        Me.Label37.Text = "Purchase Code*"
        '
        'btnPreview
        '
        Me.btnPreview.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreview.Location = New System.Drawing.Point(992, 556)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(84, 26)
        Me.btnPreview.TabIndex = 49
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'cbIncludeTax
        '
        Me.cbIncludeTax.AutoSize = True
        Me.cbIncludeTax.Location = New System.Drawing.Point(670, 152)
        Me.cbIncludeTax.Name = "cbIncludeTax"
        Me.cbIncludeTax.Size = New System.Drawing.Size(116, 17)
        Me.cbIncludeTax.TabIndex = 108
        Me.cbIncludeTax.Text = "Price Including Tax"
        Me.cbIncludeTax.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(673, 191)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 13)
        Me.Label20.TabIndex = 61
        Me.Label20.Text = "Unit Price"
        '
        'ntbPOPriceIncludeTax
        '
        Me.ntbPOPriceIncludeTax.AllowSpace = False
        Me.ntbPOPriceIncludeTax.Location = New System.Drawing.Point(672, 169)
        Me.ntbPOPriceIncludeTax.MaxLength = 18
        Me.ntbPOPriceIncludeTax.Name = "ntbPOPriceIncludeTax"
        Me.ntbPOPriceIncludeTax.Size = New System.Drawing.Size(97, 21)
        Me.ntbPOPriceIncludeTax.TabIndex = 109
        Me.ntbPOPriceIncludeTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbPOCurrRate
        '
        Me.ntbPOCurrRate.AllowSpace = False
        Me.ntbPOCurrRate.Location = New System.Drawing.Point(681, 68)
        Me.ntbPOCurrRate.MaxLength = 10
        Me.ntbPOCurrRate.Name = "ntbPOCurrRate"
        Me.ntbPOCurrRate.Size = New System.Drawing.Size(76, 21)
        Me.ntbPOCurrRate.TabIndex = 9
        Me.ntbPOCurrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbPOTaxPercent
        '
        Me.ntbPOTaxPercent.AllowSpace = False
        Me.ntbPOTaxPercent.Location = New System.Drawing.Point(899, 208)
        Me.ntbPOTaxPercent.MaxLength = 3
        Me.ntbPOTaxPercent.Name = "ntbPOTaxPercent"
        Me.ntbPOTaxPercent.Size = New System.Drawing.Size(41, 21)
        Me.ntbPOTaxPercent.TabIndex = 30
        Me.ntbPOTaxPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbPaymentTerms
        '
        Me.ntbPaymentTerms.AllowSpace = False
        Me.ntbPaymentTerms.Location = New System.Drawing.Point(540, 96)
        Me.ntbPaymentTerms.MaxLength = 3
        Me.ntbPaymentTerms.Name = "ntbPaymentTerms"
        Me.ntbPaymentTerms.Size = New System.Drawing.Size(50, 21)
        Me.ntbPaymentTerms.TabIndex = 10
        Me.ntbPaymentTerms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbPOPrice
        '
        Me.ntbPOPrice.AllowSpace = False
        Me.ntbPOPrice.Location = New System.Drawing.Point(672, 208)
        Me.ntbPOPrice.MaxLength = 18
        Me.ntbPOPrice.Name = "ntbPOPrice"
        Me.ntbPOPrice.Size = New System.Drawing.Size(97, 21)
        Me.ntbPOPrice.TabIndex = 28
        Me.ntbPOPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbPOQty
        '
        Me.ntbPOQty.AllowSpace = False
        Me.ntbPOQty.Location = New System.Drawing.Point(552, 208)
        Me.ntbPOQty.MaxLength = 12
        Me.ntbPOQty.Name = "ntbPOQty"
        Me.ntbPOQty.Size = New System.Drawing.Size(57, 21)
        Me.ntbPOQty.TabIndex = 26
        Me.ntbPOQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmPO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1178, 594)
        Me.Controls.Add(Me.ntbPOPriceIncludeTax)
        Me.Controls.Add(Me.cbIncludeTax)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.btnPchCode)
        Me.Controls.Add(Me.txtPchCode)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.txtPrinted)
        Me.Controls.Add(Me.txtRevise)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.txtLocalPOTotal)
        Me.Controls.Add(Me.txtLocalPOTax)
        Me.Controls.Add(Me.txtLocalPOSubTotal)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtLocationCode)
        Me.Controls.Add(Me.btnLocation)
        Me.Controls.Add(Me.txtCurrCode)
        Me.Controls.Add(Me.btnPRequest)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.txtPRequestNo)
        Me.Controls.Add(Me.ntbPOCurrRate)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.txtPONetAmt)
        Me.Controls.Add(Me.txtPOTaxAmt)
        Me.Controls.Add(Me.txtPOGrossAmt)
        Me.Controls.Add(Me.txtPOStatus)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtSKUUoM)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.btnAddD)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.ntbPOTaxPercent)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.ntbPaymentTerms)
        Me.Controls.Add(Me.ntbPOPrice)
        Me.Controls.Add(Me.ntbPOQty)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cmbPOType)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.cmbPaymentMethod)
        Me.Controls.Add(Me.txtPODtlDesc)
        Me.Controls.Add(Me.txtSKUCode)
        Me.Controls.Add(Me.cmbPODtlType)
        Me.Controls.Add(Me.btnSKU)
        Me.Controls.Add(Me.btnSupplier)
        Me.Controls.Add(Me.btnDeleteD)
        Me.Controls.Add(Me.btnSaveD)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtPOTotal)
        Me.Controls.Add(Me.txtPOTax)
        Me.Controls.Add(Me.txtPOSubtotal)
        Me.Controls.Add(Me.txtPORemarks)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.txtSCode)
        Me.Controls.Add(Me.txtSName)
        Me.Controls.Add(Me.txtRefNo)
        Me.Controls.Add(Me.txtShipVia)
        Me.Controls.Add(Me.dtpDeliveryDate)
        Me.Controls.Add(Me.dtpPODate)
        Me.Controls.Add(Me.txtPONo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPO"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Order"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPONo As System.Windows.Forms.TextBox
    Friend WithEvents dtpPODate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtShipVia As System.Windows.Forms.TextBox
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents txtSName As System.Windows.Forms.TextBox
    Friend WithEvents txtSCode As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents txtPORemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtPOSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents txtPOTax As System.Windows.Forms.TextBox
    Friend WithEvents txtPOTotal As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnDeleteD As System.Windows.Forms.Button
    Friend WithEvents btnSaveD As System.Windows.Forms.Button
    Friend WithEvents btnSKU As System.Windows.Forms.Button
    Friend WithEvents btnSupplier As System.Windows.Forms.Button
    Friend WithEvents cmbPODtlType As System.Windows.Forms.ComboBox
    Friend WithEvents txtSKUCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPODtlDesc As System.Windows.Forms.TextBox
    Friend WithEvents cmbPaymentMethod As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents cmbPOType As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ntbPOQty As levate.NumericTextBox
    Friend WithEvents ntbPOPrice As levate.NumericTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ntbPOTaxPercent As levate.NumericTextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtSKUUoM As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtPOStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtPOGrossAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtPOTaxAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtPONetAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ntbPaymentTerms As levate.NumericTextBox
    Friend WithEvents ntbPOCurrRate As levate.NumericTextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtPRequestNo As System.Windows.Forms.TextBox
    Friend WithEvents btnPRequest As System.Windows.Forms.Button
    Friend WithEvents txtCurrCode As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtLocationCode As System.Windows.Forms.TextBox
    Friend WithEvents btnLocation As System.Windows.Forms.Button
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtLocalPOTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalPOTax As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalPOSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtRevise As System.Windows.Forms.TextBox
    Friend WithEvents txtPrinted As System.Windows.Forms.TextBox
    Friend WithEvents btnPchCode As System.Windows.Forms.Button
    Friend WithEvents txtPchCode As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents cbIncludeTax As System.Windows.Forms.CheckBox
    Friend WithEvents ntbPOPriceIncludeTax As levate.NumericTextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label

End Class
