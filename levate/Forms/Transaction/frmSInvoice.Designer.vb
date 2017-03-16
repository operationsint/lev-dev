<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSInvoice))
        Me.txtSInvoiceNo = New System.Windows.Forms.TextBox()
        Me.dtpSInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.txtCName = New System.Windows.Forms.TextBox()
        Me.txtCCode = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.txtSInvoiceRemarks = New System.Windows.Forms.TextBox()
        Me.txtSInvoiceGross = New System.Windows.Forms.TextBox()
        Me.txtSInvoiceTax = New System.Windows.Forms.TextBox()
        Me.txtSInvoiceTotal = New System.Windows.Forms.TextBox()
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
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnCustomer = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSInvoiceSubtotal = New System.Windows.Forms.TextBox()
        Me.txtSInvoiceDiscount = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtSInvoiceNetAmt = New System.Windows.Forms.TextBox()
        Me.txtSInvoiceTaxAmt = New System.Windows.Forms.TextBox()
        Me.txtSInvoiceGrossAmt = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.btnAddD = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtSInvoiceDtlDesc = New System.Windows.Forms.TextBox()
        Me.txtSKUCode = New System.Windows.Forms.TextBox()
        Me.cmbSODtlType = New System.Windows.Forms.ComboBox()
        Me.btnSKU = New System.Windows.Forms.Button()
        Me.btnDeleteD = New System.Windows.Forms.Button()
        Me.btnSaveD = New System.Windows.Forms.Button()
        Me.btnSlsCode = New System.Windows.Forms.Button()
        Me.txtSlsCode = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.btnSO = New System.Windows.Forms.Button()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtSONo = New System.Windows.Forms.TextBox()
        Me.btnSDelivery = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtSDeliveryNo = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtLocationCode = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtLocalSInvoiceTotal = New System.Windows.Forms.TextBox()
        Me.txtLocalSInvoiceTax = New System.Windows.Forms.TextBox()
        Me.txtLocalSInvoiceSubTotal = New System.Windows.Forms.TextBox()
        Me.txtCurrCode = New System.Windows.Forms.TextBox()
        Me.txtSInvoiceStatus = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtSInvoiceGrossAfterDiscAmt = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dtpSInvoiceDueDate = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.ntbSInvoiceTerms = New levate.NumericTextBox()
        Me.ntbSInvoiceDiscAmt = New levate.NumericTextBox()
        Me.ntbSInvoiceDiscPercent = New levate.NumericTextBox()
        Me.ntbSInvoiceTaxPercent = New levate.NumericTextBox()
        Me.ntbSInvoicePrice = New levate.NumericTextBox()
        Me.ntbSInvoiceQty = New levate.NumericTextBox()
        Me.ntbSInvCurrRate = New levate.NumericTextBox()
        Me.btnPrintGroup = New System.Windows.Forms.Button()
        Me.btnFaktur = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPeriodId = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtSInvoiceNo
        '
        Me.txtSInvoiceNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSInvoiceNo.Location = New System.Drawing.Point(130, 12)
        Me.txtSInvoiceNo.MaxLength = 12
        Me.txtSInvoiceNo.Name = "txtSInvoiceNo"
        Me.txtSInvoiceNo.Size = New System.Drawing.Size(127, 21)
        Me.txtSInvoiceNo.TabIndex = 0
        '
        'dtpSInvoiceDate
        '
        Me.dtpSInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSInvoiceDate.Location = New System.Drawing.Point(130, 38)
        Me.dtpSInvoiceDate.Name = "dtpSInvoiceDate"
        Me.dtpSInvoiceDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpSInvoiceDate.TabIndex = 1
        '
        'txtRefNo
        '
        Me.txtRefNo.Location = New System.Drawing.Point(130, 91)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(127, 21)
        Me.txtRefNo.TabIndex = 3
        '
        'txtCName
        '
        Me.txtCName.Location = New System.Drawing.Point(575, 40)
        Me.txtCName.Name = "txtCName"
        Me.txtCName.ReadOnly = True
        Me.txtCName.Size = New System.Drawing.Size(217, 21)
        Me.txtCName.TabIndex = 6
        Me.txtCName.TabStop = False
        '
        'txtCCode
        '
        Me.txtCCode.Location = New System.Drawing.Point(575, 13)
        Me.txtCCode.Name = "txtCCode"
        Me.txtCCode.ReadOnly = True
        Me.txtCCode.Size = New System.Drawing.Size(80, 21)
        Me.txtCCode.TabIndex = 4
        Me.txtCCode.TabStop = False
        '
        'ListView1
        '
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(11, 228)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1256, 198)
        Me.ListView1.TabIndex = 35
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'txtSInvoiceRemarks
        '
        Me.txtSInvoiceRemarks.Location = New System.Drawing.Point(69, 464)
        Me.txtSInvoiceRemarks.MaxLength = 255
        Me.txtSInvoiceRemarks.Multiline = True
        Me.txtSInvoiceRemarks.Name = "txtSInvoiceRemarks"
        Me.txtSInvoiceRemarks.Size = New System.Drawing.Size(318, 59)
        Me.txtSInvoiceRemarks.TabIndex = 36
        '
        'txtSInvoiceGross
        '
        Me.txtSInvoiceGross.Location = New System.Drawing.Point(1149, 442)
        Me.txtSInvoiceGross.Name = "txtSInvoiceGross"
        Me.txtSInvoiceGross.ReadOnly = True
        Me.txtSInvoiceGross.Size = New System.Drawing.Size(118, 21)
        Me.txtSInvoiceGross.TabIndex = 40
        Me.txtSInvoiceGross.TabStop = False
        Me.txtSInvoiceGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSInvoiceTax
        '
        Me.txtSInvoiceTax.Location = New System.Drawing.Point(1149, 523)
        Me.txtSInvoiceTax.Name = "txtSInvoiceTax"
        Me.txtSInvoiceTax.ReadOnly = True
        Me.txtSInvoiceTax.Size = New System.Drawing.Size(118, 21)
        Me.txtSInvoiceTax.TabIndex = 43
        Me.txtSInvoiceTax.TabStop = False
        Me.txtSInvoiceTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSInvoiceTotal
        '
        Me.txtSInvoiceTotal.Location = New System.Drawing.Point(1149, 552)
        Me.txtSInvoiceTotal.Name = "txtSInvoiceTotal"
        Me.txtSInvoiceTotal.ReadOnly = True
        Me.txtSInvoiceTotal.Size = New System.Drawing.Size(118, 21)
        Me.txtSInvoiceTotal.TabIndex = 44
        Me.txtSInvoiceTotal.TabStop = False
        Me.txtSInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(901, 588)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 26)
        Me.btnCancel.TabIndex = 49
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(631, 588)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(84, 26)
        Me.btnEdit.TabIndex = 46
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(721, 588)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnAdd.TabIndex = 47
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(541, 588)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 26)
        Me.btnDelete.TabIndex = 45
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(811, 588)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 26)
        Me.btnSave.TabIndex = 48
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(472, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Customer Code *"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(1043, 442)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Subtotal"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(1042, 523)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Tax"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(1043, 552)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Total"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Sales Invoice No. *"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Ref. No."
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(9, 464)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Remarks"
        '
        'btnCustomer
        '
        Me.btnCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomer.ImageIndex = 0
        Me.btnCustomer.ImageList = Me.ImageList1
        Me.btnCustomer.Location = New System.Drawing.Point(659, 10)
        Me.btnCustomer.Name = "btnCustomer"
        Me.btnCustomer.Size = New System.Drawing.Size(29, 25)
        Me.btnCustomer.TabIndex = 5
        Me.btnCustomer.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Search.png")
        Me.ImageList1.Images.SetKeyName(1, "Box.png")
        Me.ImageList1.Images.SetKeyName(2, "Remove.png")
        Me.ImageList1.Images.SetKeyName(3, "add.png")
        Me.ImageList1.Images.SetKeyName(4, "Checkmark.png")
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(989, 588)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(99, 26)
        Me.btnPrint.TabIndex = 50
        Me.btnPrint.Text = "Print by Delivery"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(1042, 496)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Subtotal After Disc."
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(1043, 469)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "Discount"
        '
        'txtSInvoiceSubtotal
        '
        Me.txtSInvoiceSubtotal.Location = New System.Drawing.Point(1149, 496)
        Me.txtSInvoiceSubtotal.Name = "txtSInvoiceSubtotal"
        Me.txtSInvoiceSubtotal.ReadOnly = True
        Me.txtSInvoiceSubtotal.Size = New System.Drawing.Size(118, 21)
        Me.txtSInvoiceSubtotal.TabIndex = 42
        Me.txtSInvoiceSubtotal.TabStop = False
        Me.txtSInvoiceSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSInvoiceDiscount
        '
        Me.txtSInvoiceDiscount.Location = New System.Drawing.Point(1149, 469)
        Me.txtSInvoiceDiscount.Name = "txtSInvoiceDiscount"
        Me.txtSInvoiceDiscount.ReadOnly = True
        Me.txtSInvoiceDiscount.Size = New System.Drawing.Size(118, 21)
        Me.txtSInvoiceDiscount.TabIndex = 41
        Me.txtSInvoiceDiscount.TabStop = False
        Me.txtSInvoiceDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(472, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 13)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Customer Name"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(680, 71)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(30, 13)
        Me.Label28.TabIndex = 85
        Me.Label28.Text = "Rate"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(472, 70)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(79, 13)
        Me.Label27.TabIndex = 83
        Me.Label27.Text = "Currency Code"
        '
        'txtSInvoiceNetAmt
        '
        Me.txtSInvoiceNetAmt.Location = New System.Drawing.Point(1155, 201)
        Me.txtSInvoiceNetAmt.Name = "txtSInvoiceNetAmt"
        Me.txtSInvoiceNetAmt.ReadOnly = True
        Me.txtSInvoiceNetAmt.Size = New System.Drawing.Size(112, 21)
        Me.txtSInvoiceNetAmt.TabIndex = 31
        Me.txtSInvoiceNetAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSInvoiceTaxAmt
        '
        Me.txtSInvoiceTaxAmt.Location = New System.Drawing.Point(1057, 201)
        Me.txtSInvoiceTaxAmt.Name = "txtSInvoiceTaxAmt"
        Me.txtSInvoiceTaxAmt.ReadOnly = True
        Me.txtSInvoiceTaxAmt.Size = New System.Drawing.Size(92, 21)
        Me.txtSInvoiceTaxAmt.TabIndex = 30
        Me.txtSInvoiceTaxAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSInvoiceGrossAmt
        '
        Me.txtSInvoiceGrossAmt.Location = New System.Drawing.Point(654, 201)
        Me.txtSInvoiceGrossAmt.Name = "txtSInvoiceGrossAmt"
        Me.txtSInvoiceGrossAmt.ReadOnly = True
        Me.txtSInvoiceGrossAmt.Size = New System.Drawing.Size(92, 21)
        Me.txtSInvoiceGrossAmt.TabIndex = 25
        Me.txtSInvoiceGrossAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(1207, 182)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 13)
        Me.Label25.TabIndex = 105
        Me.Label25.Text = "Net Amount"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(672, 182)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(74, 13)
        Me.Label24.TabIndex = 104
        Me.Label24.Text = "Gross Amount"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(1084, 183)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 13)
        Me.Label23.TabIndex = 103
        Me.Label23.Text = "Tax Amount"
        '
        'btnAddD
        '
        Me.btnAddD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD.ImageIndex = 3
        Me.btnAddD.ImageList = Me.ImageList1
        Me.btnAddD.Location = New System.Drawing.Point(1238, 157)
        Me.btnAddD.Name = "btnAddD"
        Me.btnAddD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD.TabIndex = 34
        Me.btnAddD.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(1012, 182)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(39, 13)
        Me.Label22.TabIndex = 102
        Me.Label22.Text = "Tax %"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(599, 182)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 13)
        Me.Label20.TabIndex = 101
        Me.Label20.Text = "Unit Price"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(527, 182)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(29, 13)
        Me.Label19.TabIndex = 100
        Me.Label19.Text = "Qty."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(104, 182)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 13)
        Me.Label14.TabIndex = 98
        Me.Label14.Text = "Code *"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(12, 182)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 13)
        Me.Label21.TabIndex = 97
        Me.Label21.Text = "Line Type"
        '
        'txtSInvoiceDtlDesc
        '
        Me.txtSInvoiceDtlDesc.Location = New System.Drawing.Point(221, 201)
        Me.txtSInvoiceDtlDesc.MaxLength = 100
        Me.txtSInvoiceDtlDesc.Name = "txtSInvoiceDtlDesc"
        Me.txtSInvoiceDtlDesc.Size = New System.Drawing.Size(187, 21)
        Me.txtSInvoiceDtlDesc.TabIndex = 21
        '
        'txtSKUCode
        '
        Me.txtSKUCode.Location = New System.Drawing.Point(107, 201)
        Me.txtSKUCode.MaxLength = 50
        Me.txtSKUCode.Name = "txtSKUCode"
        Me.txtSKUCode.ReadOnly = True
        Me.txtSKUCode.Size = New System.Drawing.Size(80, 21)
        Me.txtSKUCode.TabIndex = 19
        Me.txtSKUCode.TabStop = False
        '
        'cmbSODtlType
        '
        Me.cmbSODtlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSODtlType.FormattingEnabled = True
        Me.cmbSODtlType.Location = New System.Drawing.Point(14, 201)
        Me.cmbSODtlType.Name = "cmbSODtlType"
        Me.cmbSODtlType.Size = New System.Drawing.Size(88, 21)
        Me.cmbSODtlType.TabIndex = 18
        '
        'btnSKU
        '
        Me.btnSKU.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSKU.ImageIndex = 1
        Me.btnSKU.ImageList = Me.ImageList1
        Me.btnSKU.Location = New System.Drawing.Point(189, 199)
        Me.btnSKU.Name = "btnSKU"
        Me.btnSKU.Size = New System.Drawing.Size(29, 25)
        Me.btnSKU.TabIndex = 20
        Me.btnSKU.UseVisualStyleBackColor = True
        '
        'btnDeleteD
        '
        Me.btnDeleteD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteD.ImageIndex = 2
        Me.btnDeleteD.ImageList = Me.ImageList1
        Me.btnDeleteD.Location = New System.Drawing.Point(1207, 157)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 33
        Me.btnDeleteD.UseVisualStyleBackColor = True
        '
        'btnSaveD
        '
        Me.btnSaveD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveD.ImageIndex = 4
        Me.btnSaveD.ImageList = Me.ImageList1
        Me.btnSaveD.Location = New System.Drawing.Point(1176, 157)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 32
        Me.btnSaveD.UseVisualStyleBackColor = True
        '
        'btnSlsCode
        '
        Me.btnSlsCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSlsCode.ImageIndex = 0
        Me.btnSlsCode.ImageList = Me.ImageList1
        Me.btnSlsCode.Location = New System.Drawing.Point(1142, 10)
        Me.btnSlsCode.Name = "btnSlsCode"
        Me.btnSlsCode.Size = New System.Drawing.Size(29, 25)
        Me.btnSlsCode.TabIndex = 12
        Me.btnSlsCode.UseVisualStyleBackColor = True
        '
        'txtSlsCode
        '
        Me.txtSlsCode.Location = New System.Drawing.Point(1058, 12)
        Me.txtSlsCode.Name = "txtSlsCode"
        Me.txtSlsCode.ReadOnly = True
        Me.txtSlsCode.Size = New System.Drawing.Size(80, 21)
        Me.txtSlsCode.TabIndex = 11
        Me.txtSlsCode.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(963, 12)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(69, 13)
        Me.Label37.TabIndex = 122
        Me.Label37.Text = "Sales Code *"
        '
        'btnSO
        '
        Me.btnSO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSO.ImageIndex = 0
        Me.btnSO.ImageList = Me.ImageList1
        Me.btnSO.Location = New System.Drawing.Point(145, 154)
        Me.btnSO.Name = "btnSO"
        Me.btnSO.Size = New System.Drawing.Size(29, 25)
        Me.btnSO.TabIndex = 15
        Me.btnSO.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(12, 142)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(92, 13)
        Me.Label38.TabIndex = 120
        Me.Label38.Text = "Sales Order No. *"
        '
        'txtSONo
        '
        Me.txtSONo.Location = New System.Drawing.Point(14, 157)
        Me.txtSONo.Name = "txtSONo"
        Me.txtSONo.ReadOnly = True
        Me.txtSONo.Size = New System.Drawing.Size(127, 21)
        Me.txtSONo.TabIndex = 14
        '
        'btnSDelivery
        '
        Me.btnSDelivery.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSDelivery.ImageIndex = 0
        Me.btnSDelivery.ImageList = Me.ImageList1
        Me.btnSDelivery.Location = New System.Drawing.Point(313, 154)
        Me.btnSDelivery.Name = "btnSDelivery"
        Me.btnSDelivery.Size = New System.Drawing.Size(29, 25)
        Me.btnSDelivery.TabIndex = 17
        Me.btnSDelivery.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(179, 142)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(103, 13)
        Me.Label29.TabIndex = 117
        Me.Label29.Text = "Sales Delivery No. *"
        '
        'txtSDeliveryNo
        '
        Me.txtSDeliveryNo.Location = New System.Drawing.Point(182, 157)
        Me.txtSDeliveryNo.Name = "txtSDeliveryNo"
        Me.txtSDeliveryNo.ReadOnly = True
        Me.txtSDeliveryNo.Size = New System.Drawing.Size(127, 21)
        Me.txtSDeliveryNo.TabIndex = 16
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(413, 182)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(56, 13)
        Me.Label31.TabIndex = 126
        Me.Label31.Text = "Location *"
        '
        'txtLocationCode
        '
        Me.txtLocationCode.Location = New System.Drawing.Point(413, 201)
        Me.txtLocationCode.Name = "txtLocationCode"
        Me.txtLocationCode.ReadOnly = True
        Me.txtLocationCode.Size = New System.Drawing.Size(80, 21)
        Me.txtLocationCode.TabIndex = 22
        Me.txtLocationCode.TabStop = False
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(787, 555)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(58, 13)
        Me.Label34.TabIndex = 132
        Me.Label34.Text = "Local Total"
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(787, 527)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(52, 13)
        Me.Label35.TabIndex = 131
        Me.Label35.Text = "Local Tax"
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(787, 499)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(74, 13)
        Me.Label36.TabIndex = 130
        Me.Label36.Text = "Local Subtotal"
        '
        'txtLocalSInvoiceTotal
        '
        Me.txtLocalSInvoiceTotal.Location = New System.Drawing.Point(881, 552)
        Me.txtLocalSInvoiceTotal.Name = "txtLocalSInvoiceTotal"
        Me.txtLocalSInvoiceTotal.ReadOnly = True
        Me.txtLocalSInvoiceTotal.Size = New System.Drawing.Size(118, 21)
        Me.txtLocalSInvoiceTotal.TabIndex = 39
        Me.txtLocalSInvoiceTotal.TabStop = False
        Me.txtLocalSInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLocalSInvoiceTax
        '
        Me.txtLocalSInvoiceTax.Location = New System.Drawing.Point(881, 523)
        Me.txtLocalSInvoiceTax.Name = "txtLocalSInvoiceTax"
        Me.txtLocalSInvoiceTax.ReadOnly = True
        Me.txtLocalSInvoiceTax.Size = New System.Drawing.Size(118, 21)
        Me.txtLocalSInvoiceTax.TabIndex = 38
        Me.txtLocalSInvoiceTax.TabStop = False
        Me.txtLocalSInvoiceTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLocalSInvoiceSubTotal
        '
        Me.txtLocalSInvoiceSubTotal.Location = New System.Drawing.Point(881, 496)
        Me.txtLocalSInvoiceSubTotal.Name = "txtLocalSInvoiceSubTotal"
        Me.txtLocalSInvoiceSubTotal.ReadOnly = True
        Me.txtLocalSInvoiceSubTotal.Size = New System.Drawing.Size(118, 21)
        Me.txtLocalSInvoiceSubTotal.TabIndex = 37
        Me.txtLocalSInvoiceSubTotal.TabStop = False
        Me.txtLocalSInvoiceSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCurrCode
        '
        Me.txtCurrCode.Location = New System.Drawing.Point(575, 67)
        Me.txtCurrCode.Name = "txtCurrCode"
        Me.txtCurrCode.ReadOnly = True
        Me.txtCurrCode.Size = New System.Drawing.Size(50, 21)
        Me.txtCurrCode.TabIndex = 7
        Me.txtCurrCode.TabStop = False
        '
        'txtSInvoiceStatus
        '
        Me.txtSInvoiceStatus.Location = New System.Drawing.Point(1058, 91)
        Me.txtSInvoiceStatus.Name = "txtSInvoiceStatus"
        Me.txtSInvoiceStatus.ReadOnly = True
        Me.txtSInvoiceStatus.Size = New System.Drawing.Size(153, 21)
        Me.txtSInvoiceStatus.TabIndex = 13
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(963, 94)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 13)
        Me.Label17.TabIndex = 134
        Me.Label17.Text = "Status"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(917, 183)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(88, 13)
        Me.Label30.TabIndex = 141
        Me.Label30.Text = "Gross After Disc."
        '
        'txtSInvoiceGrossAfterDiscAmt
        '
        Me.txtSInvoiceGrossAfterDiscAmt.Location = New System.Drawing.Point(893, 201)
        Me.txtSInvoiceGrossAfterDiscAmt.Name = "txtSInvoiceGrossAfterDiscAmt"
        Me.txtSInvoiceGrossAfterDiscAmt.ReadOnly = True
        Me.txtSInvoiceGrossAfterDiscAmt.Size = New System.Drawing.Size(112, 21)
        Me.txtSInvoiceGrossAfterDiscAmt.TabIndex = 28
        Me.txtSInvoiceGrossAfterDiscAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(824, 183)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(70, 13)
        Me.Label32.TabIndex = 140
        Me.Label32.Text = "Disc. Amount"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(758, 183)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(44, 13)
        Me.Label33.TabIndex = 139
        Me.Label33.Text = "Disc. %"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(218, 182)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 142
        Me.Label8.Text = "Line Description"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(472, 125)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(97, 13)
        Me.Label15.TabIndex = 147
        Me.Label15.Text = "Payment Due Date"
        '
        'dtpSInvoiceDueDate
        '
        Me.dtpSInvoiceDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSInvoiceDueDate.Location = New System.Drawing.Point(575, 121)
        Me.dtpSInvoiceDueDate.Name = "dtpSInvoiceDueDate"
        Me.dtpSInvoiceDueDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpSInvoiceDueDate.TabIndex = 10
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(631, 99)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(30, 13)
        Me.Label26.TabIndex = 145
        Me.Label26.Text = "days"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(472, 99)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(81, 13)
        Me.Label39.TabIndex = 144
        Me.Label39.Text = "Payment Terms"
        '
        'ntbSInvoiceTerms
        '
        Me.ntbSInvoiceTerms.AllowSpace = False
        Me.ntbSInvoiceTerms.Location = New System.Drawing.Point(575, 94)
        Me.ntbSInvoiceTerms.MaxLength = 3
        Me.ntbSInvoiceTerms.Name = "ntbSInvoiceTerms"
        Me.ntbSInvoiceTerms.Size = New System.Drawing.Size(50, 21)
        Me.ntbSInvoiceTerms.TabIndex = 9
        Me.ntbSInvoiceTerms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSInvoiceDiscAmt
        '
        Me.ntbSInvoiceDiscAmt.AllowSpace = False
        Me.ntbSInvoiceDiscAmt.Location = New System.Drawing.Point(797, 201)
        Me.ntbSInvoiceDiscAmt.MaxLength = 14
        Me.ntbSInvoiceDiscAmt.Name = "ntbSInvoiceDiscAmt"
        Me.ntbSInvoiceDiscAmt.Size = New System.Drawing.Size(92, 21)
        Me.ntbSInvoiceDiscAmt.TabIndex = 27
        Me.ntbSInvoiceDiscAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSInvoiceDiscPercent
        '
        Me.ntbSInvoiceDiscPercent.AllowSpace = False
        Me.ntbSInvoiceDiscPercent.Location = New System.Drawing.Point(751, 201)
        Me.ntbSInvoiceDiscPercent.MaxLength = 3
        Me.ntbSInvoiceDiscPercent.Name = "ntbSInvoiceDiscPercent"
        Me.ntbSInvoiceDiscPercent.Size = New System.Drawing.Size(40, 21)
        Me.ntbSInvoiceDiscPercent.TabIndex = 26
        Me.ntbSInvoiceDiscPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSInvoiceTaxPercent
        '
        Me.ntbSInvoiceTaxPercent.AllowSpace = False
        Me.ntbSInvoiceTaxPercent.Location = New System.Drawing.Point(1010, 201)
        Me.ntbSInvoiceTaxPercent.MaxLength = 3
        Me.ntbSInvoiceTaxPercent.Name = "ntbSInvoiceTaxPercent"
        Me.ntbSInvoiceTaxPercent.Size = New System.Drawing.Size(41, 21)
        Me.ntbSInvoiceTaxPercent.TabIndex = 29
        Me.ntbSInvoiceTaxPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSInvoicePrice
        '
        Me.ntbSInvoicePrice.AllowSpace = False
        Me.ntbSInvoicePrice.Location = New System.Drawing.Point(562, 201)
        Me.ntbSInvoicePrice.MaxLength = 18
        Me.ntbSInvoicePrice.Name = "ntbSInvoicePrice"
        Me.ntbSInvoicePrice.Size = New System.Drawing.Size(86, 21)
        Me.ntbSInvoicePrice.TabIndex = 24
        Me.ntbSInvoicePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSInvoiceQty
        '
        Me.ntbSInvoiceQty.AllowSpace = False
        Me.ntbSInvoiceQty.Location = New System.Drawing.Point(499, 201)
        Me.ntbSInvoiceQty.MaxLength = 8
        Me.ntbSInvoiceQty.Name = "ntbSInvoiceQty"
        Me.ntbSInvoiceQty.Size = New System.Drawing.Size(57, 21)
        Me.ntbSInvoiceQty.TabIndex = 23
        Me.ntbSInvoiceQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSInvCurrRate
        '
        Me.ntbSInvCurrRate.AllowSpace = False
        Me.ntbSInvCurrRate.Location = New System.Drawing.Point(716, 67)
        Me.ntbSInvCurrRate.MaxLength = 10
        Me.ntbSInvCurrRate.Name = "ntbSInvCurrRate"
        Me.ntbSInvCurrRate.Size = New System.Drawing.Size(76, 21)
        Me.ntbSInvCurrRate.TabIndex = 8
        Me.ntbSInvCurrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPrintGroup
        '
        Me.btnPrintGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintGroup.Location = New System.Drawing.Point(1092, 588)
        Me.btnPrintGroup.Name = "btnPrintGroup"
        Me.btnPrintGroup.Size = New System.Drawing.Size(84, 26)
        Me.btnPrintGroup.TabIndex = 51
        Me.btnPrintGroup.Text = "Print By Stock"
        Me.btnPrintGroup.UseVisualStyleBackColor = True
        '
        'btnFaktur
        '
        Me.btnFaktur.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFaktur.Location = New System.Drawing.Point(1180, 588)
        Me.btnFaktur.Name = "btnFaktur"
        Me.btnFaktur.Size = New System.Drawing.Size(84, 26)
        Me.btnFaktur.TabIndex = 52
        Me.btnFaktur.Text = "Print F. Pajak"
        Me.btnFaktur.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 65)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 151
        Me.Label11.Text = "Period"
        '
        'txtPeriodId
        '
        Me.txtPeriodId.Location = New System.Drawing.Point(130, 64)
        Me.txtPeriodId.Name = "txtPeriodId"
        Me.txtPeriodId.ReadOnly = True
        Me.txtPeriodId.Size = New System.Drawing.Size(97, 21)
        Me.txtPeriodId.TabIndex = 2
        '
        'frmSInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1279, 622)
        Me.Controls.Add(Me.txtPeriodId)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnFaktur)
        Me.Controls.Add(Me.btnPrintGroup)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.dtpSInvoiceDueDate)
        Me.Controls.Add(Me.ntbSInvoiceTerms)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtSInvoiceGrossAfterDiscAmt)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.ntbSInvoiceDiscAmt)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.ntbSInvoiceDiscPercent)
        Me.Controls.Add(Me.txtSInvoiceStatus)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtCurrCode)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.txtLocalSInvoiceTotal)
        Me.Controls.Add(Me.txtLocalSInvoiceTax)
        Me.Controls.Add(Me.txtLocalSInvoiceSubTotal)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtLocationCode)
        Me.Controls.Add(Me.btnSlsCode)
        Me.Controls.Add(Me.txtSlsCode)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.btnSO)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.txtSONo)
        Me.Controls.Add(Me.btnSDelivery)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.txtSDeliveryNo)
        Me.Controls.Add(Me.txtSInvoiceNetAmt)
        Me.Controls.Add(Me.txtSInvoiceTaxAmt)
        Me.Controls.Add(Me.txtSInvoiceGrossAmt)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.btnAddD)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.ntbSInvoiceTaxPercent)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.ntbSInvoicePrice)
        Me.Controls.Add(Me.ntbSInvoiceQty)
        Me.Controls.Add(Me.txtSInvoiceDtlDesc)
        Me.Controls.Add(Me.txtSKUCode)
        Me.Controls.Add(Me.cmbSODtlType)
        Me.Controls.Add(Me.btnSKU)
        Me.Controls.Add(Me.btnDeleteD)
        Me.Controls.Add(Me.btnSaveD)
        Me.Controls.Add(Me.ntbSInvCurrRate)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtSInvoiceSubtotal)
        Me.Controls.Add(Me.txtSInvoiceDiscount)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnCustomer)
        Me.Controls.Add(Me.Label12)
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
        Me.Controls.Add(Me.txtSInvoiceTotal)
        Me.Controls.Add(Me.txtSInvoiceTax)
        Me.Controls.Add(Me.txtSInvoiceGross)
        Me.Controls.Add(Me.txtSInvoiceRemarks)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.txtCCode)
        Me.Controls.Add(Me.txtCName)
        Me.Controls.Add(Me.txtRefNo)
        Me.Controls.Add(Me.dtpSInvoiceDate)
        Me.Controls.Add(Me.txtSInvoiceNo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSInvoice"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Invoice"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpSInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents txtCName As System.Windows.Forms.TextBox
    Friend WithEvents txtCCode As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents txtSInvoiceRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtSInvoiceGross As System.Windows.Forms.TextBox
    Friend WithEvents txtSInvoiceTax As System.Windows.Forms.TextBox
    Friend WithEvents txtSInvoiceTotal As System.Windows.Forms.TextBox
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
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnCustomer As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSInvoiceSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents txtSInvoiceDiscount As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ntbSInvCurrRate As levate.NumericTextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtSInvoiceNetAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtSInvoiceTaxAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtSInvoiceGrossAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ntbSInvoiceTaxPercent As levate.NumericTextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ntbSInvoicePrice As levate.NumericTextBox
    Friend WithEvents ntbSInvoiceQty As levate.NumericTextBox
    Friend WithEvents txtSInvoiceDtlDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtSKUCode As System.Windows.Forms.TextBox
    Friend WithEvents cmbSODtlType As System.Windows.Forms.ComboBox
    Friend WithEvents btnSKU As System.Windows.Forms.Button
    Friend WithEvents btnDeleteD As System.Windows.Forms.Button
    Friend WithEvents btnSaveD As System.Windows.Forms.Button
    Friend WithEvents btnSlsCode As System.Windows.Forms.Button
    Friend WithEvents txtSlsCode As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents btnSO As System.Windows.Forms.Button
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtSONo As System.Windows.Forms.TextBox
    Friend WithEvents btnSDelivery As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtSDeliveryNo As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtLocationCode As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtLocalSInvoiceTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalSInvoiceTax As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalSInvoiceSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSInvoiceStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtSInvoiceGrossAfterDiscAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents ntbSInvoiceDiscAmt As levate.NumericTextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents ntbSInvoiceDiscPercent As levate.NumericTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dtpSInvoiceDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ntbSInvoiceTerms As levate.NumericTextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents btnPrintGroup As System.Windows.Forms.Button
    Friend WithEvents btnFaktur As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodId As System.Windows.Forms.TextBox

End Class
