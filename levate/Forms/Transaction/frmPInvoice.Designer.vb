<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPInvoice))
        Me.txtPInvoiceNo = New System.Windows.Forms.TextBox()
        Me.dtpPInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.txtSName = New System.Windows.Forms.TextBox()
        Me.txtSCode = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.txtPInvoiceRemarks = New System.Windows.Forms.TextBox()
        Me.txtPInvoiceSubtotal = New System.Windows.Forms.TextBox()
        Me.txtPInvoiceTax = New System.Windows.Forms.TextBox()
        Me.txtPInvoiceTotal = New System.Windows.Forms.TextBox()
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
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnDeleteD = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnSaveD = New System.Windows.Forms.Button()
        Me.btnSKU = New System.Windows.Forms.Button()
        Me.btnSupplier = New System.Windows.Forms.Button()
        Me.cmbPODtlType = New System.Windows.Forms.ComboBox()
        Me.txtSKUCode = New System.Windows.Forms.TextBox()
        Me.txtPInvoiceDtlDesc = New System.Windows.Forms.TextBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAddD = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtSKUUoM = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPInvoiceGrossAmt = New System.Windows.Forms.TextBox()
        Me.txtPInvoiceTaxAmt = New System.Windows.Forms.TextBox()
        Me.txtPInvoiceNetAmt = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtPReceiveNo = New System.Windows.Forms.TextBox()
        Me.btnPReceive = New System.Windows.Forms.Button()
        Me.txtCurrCode = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtLocationCode = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtLocalPInvoiceTotal = New System.Windows.Forms.TextBox()
        Me.txtLocalPInvoiceTax = New System.Windows.Forms.TextBox()
        Me.txtLocalPInvoiceSubTotal = New System.Windows.Forms.TextBox()
        Me.btnPO = New System.Windows.Forms.Button()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtPONo = New System.Windows.Forms.TextBox()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnPchCode = New System.Windows.Forms.Button()
        Me.txtPchCode = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtPOStatus = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpPInvoiceDueDate = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPeriodId = New System.Windows.Forms.TextBox()
        Me.ntbPInvoiceTerms = New levate.NumericTextBox()
        Me.ntbPInvCurrRate = New levate.NumericTextBox()
        Me.ntbPInvoiceTaxPercent = New levate.NumericTextBox()
        Me.ntbPInvoicePrice = New levate.NumericTextBox()
        Me.ntbPInvoiceQty = New levate.NumericTextBox()
        Me.btnWorkOrder = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtWorkOrderNo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtPInvoiceNo
        '
        Me.txtPInvoiceNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPInvoiceNo.Location = New System.Drawing.Point(147, 12)
        Me.txtPInvoiceNo.MaxLength = 12
        Me.txtPInvoiceNo.Name = "txtPInvoiceNo"
        Me.txtPInvoiceNo.Size = New System.Drawing.Size(127, 21)
        Me.txtPInvoiceNo.TabIndex = 0
        '
        'dtpPInvoiceDate
        '
        Me.dtpPInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPInvoiceDate.Location = New System.Drawing.Point(147, 40)
        Me.dtpPInvoiceDate.Name = "dtpPInvoiceDate"
        Me.dtpPInvoiceDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpPInvoiceDate.TabIndex = 1
        '
        'txtSName
        '
        Me.txtSName.Location = New System.Drawing.Point(516, 39)
        Me.txtSName.Name = "txtSName"
        Me.txtSName.ReadOnly = True
        Me.txtSName.Size = New System.Drawing.Size(217, 21)
        Me.txtSName.TabIndex = 6
        Me.txtSName.TabStop = False
        '
        'txtSCode
        '
        Me.txtSCode.Location = New System.Drawing.Point(516, 11)
        Me.txtSCode.Name = "txtSCode"
        Me.txtSCode.ReadOnly = True
        Me.txtSCode.Size = New System.Drawing.Size(80, 21)
        Me.txtSCode.TabIndex = 4
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
        Me.ListView1.Size = New System.Drawing.Size(1120, 198)
        Me.ListView1.TabIndex = 30
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'txtPInvoiceRemarks
        '
        Me.txtPInvoiceRemarks.Location = New System.Drawing.Point(75, 449)
        Me.txtPInvoiceRemarks.MaxLength = 255
        Me.txtPInvoiceRemarks.Multiline = True
        Me.txtPInvoiceRemarks.Name = "txtPInvoiceRemarks"
        Me.txtPInvoiceRemarks.Size = New System.Drawing.Size(318, 59)
        Me.txtPInvoiceRemarks.TabIndex = 31
        '
        'txtPInvoiceSubtotal
        '
        Me.txtPInvoiceSubtotal.Location = New System.Drawing.Point(1014, 446)
        Me.txtPInvoiceSubtotal.Name = "txtPInvoiceSubtotal"
        Me.txtPInvoiceSubtotal.ReadOnly = True
        Me.txtPInvoiceSubtotal.Size = New System.Drawing.Size(118, 21)
        Me.txtPInvoiceSubtotal.TabIndex = 35
        Me.txtPInvoiceSubtotal.TabStop = False
        Me.txtPInvoiceSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPInvoiceTax
        '
        Me.txtPInvoiceTax.Location = New System.Drawing.Point(1014, 473)
        Me.txtPInvoiceTax.Name = "txtPInvoiceTax"
        Me.txtPInvoiceTax.ReadOnly = True
        Me.txtPInvoiceTax.Size = New System.Drawing.Size(118, 21)
        Me.txtPInvoiceTax.TabIndex = 36
        Me.txtPInvoiceTax.TabStop = False
        Me.txtPInvoiceTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPInvoiceTotal
        '
        Me.txtPInvoiceTotal.Location = New System.Drawing.Point(1014, 502)
        Me.txtPInvoiceTotal.Name = "txtPInvoiceTotal"
        Me.txtPInvoiceTotal.ReadOnly = True
        Me.txtPInvoiceTotal.Size = New System.Drawing.Size(118, 21)
        Me.txtPInvoiceTotal.TabIndex = 37
        Me.txtPInvoiceTotal.TabStop = False
        Me.txtPInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(954, 556)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 26)
        Me.btnCancel.TabIndex = 42
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(684, 556)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(84, 26)
        Me.btnEdit.TabIndex = 39
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(774, 556)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnAdd.TabIndex = 40
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(594, 556)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 26)
        Me.btnDelete.TabIndex = 38
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(864, 556)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 26)
        Me.btnSave.TabIndex = 41
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(413, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Supplier Code *"
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
        Me.Label6.Location = New System.Drawing.Point(11, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(131, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Purchase Invoice No.*"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Date"
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
        Me.btnDeleteD.Location = New System.Drawing.Point(1068, 161)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 19
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
        Me.btnSaveD.Location = New System.Drawing.Point(1037, 161)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 18
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
        Me.btnSKU.TabIndex = 20
        Me.btnSKU.UseVisualStyleBackColor = True
        '
        'btnSupplier
        '
        Me.btnSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupplier.ImageIndex = 0
        Me.btnSupplier.ImageList = Me.ImageList1
        Me.btnSupplier.Location = New System.Drawing.Point(599, 8)
        Me.btnSupplier.Name = "btnSupplier"
        Me.btnSupplier.Size = New System.Drawing.Size(29, 25)
        Me.btnSupplier.TabIndex = 5
        Me.btnSupplier.UseVisualStyleBackColor = True
        '
        'cmbPODtlType
        '
        Me.cmbPODtlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPODtlType.FormattingEnabled = True
        Me.cmbPODtlType.Location = New System.Drawing.Point(15, 208)
        Me.cmbPODtlType.Name = "cmbPODtlType"
        Me.cmbPODtlType.Size = New System.Drawing.Size(88, 21)
        Me.cmbPODtlType.TabIndex = 18
        '
        'txtSKUCode
        '
        Me.txtSKUCode.Location = New System.Drawing.Point(108, 208)
        Me.txtSKUCode.MaxLength = 50
        Me.txtSKUCode.Name = "txtSKUCode"
        Me.txtSKUCode.ReadOnly = True
        Me.txtSKUCode.Size = New System.Drawing.Size(80, 21)
        Me.txtSKUCode.TabIndex = 19
        Me.txtSKUCode.TabStop = False
        '
        'txtPInvoiceDtlDesc
        '
        Me.txtPInvoiceDtlDesc.Location = New System.Drawing.Point(222, 208)
        Me.txtPInvoiceDtlDesc.MaxLength = 100
        Me.txtPInvoiceDtlDesc.Name = "txtPInvoiceDtlDesc"
        Me.txtPInvoiceDtlDesc.Size = New System.Drawing.Size(209, 21)
        Me.txtPInvoiceDtlDesc.TabIndex = 21
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(1044, 556)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 26)
        Me.btnPrint.TabIndex = 43
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 189)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 13)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "Line Type"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(109, 189)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(32, 13)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Code"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(219, 189)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "Line Description"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(550, 189)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(29, 13)
        Me.Label19.TabIndex = 60
        Me.Label19.Text = "Qty."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(692, 189)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 13)
        Me.Label20.TabIndex = 61
        Me.Label20.Text = "Unit Price"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(413, 42)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(75, 13)
        Me.Label21.TabIndex = 62
        Me.Label21.Text = "Supplier Name"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(874, 189)
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
        Me.btnAddD.Location = New System.Drawing.Point(1099, 161)
        Me.btnAddD.Name = "btnAddD"
        Me.btnAddD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD.TabIndex = 20
        Me.btnAddD.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(948, 189)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 13)
        Me.Label23.TabIndex = 67
        Me.Label23.Text = "Tax Amount"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(789, 189)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(74, 13)
        Me.Label24.TabIndex = 69
        Me.Label24.Text = "Gross Amount"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(1067, 189)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 13)
        Me.Label25.TabIndex = 71
        Me.Label25.Text = "Net Amount"
        '
        'txtSKUUoM
        '
        Me.txtSKUUoM.Location = New System.Drawing.Point(585, 208)
        Me.txtSKUUoM.Name = "txtSKUUoM"
        Me.txtSKUUoM.ReadOnly = True
        Me.txtSKUUoM.Size = New System.Drawing.Size(53, 21)
        Me.txtSKUUoM.TabIndex = 24
        Me.txtSKUUoM.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(585, 189)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(28, 13)
        Me.Label26.TabIndex = 73
        Me.Label26.Text = "UoM"
        '
        'txtPInvoiceGrossAmt
        '
        Me.txtPInvoiceGrossAmt.Location = New System.Drawing.Point(745, 208)
        Me.txtPInvoiceGrossAmt.Name = "txtPInvoiceGrossAmt"
        Me.txtPInvoiceGrossAmt.ReadOnly = True
        Me.txtPInvoiceGrossAmt.Size = New System.Drawing.Size(118, 21)
        Me.txtPInvoiceGrossAmt.TabIndex = 26
        Me.txtPInvoiceGrossAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPInvoiceTaxAmt
        '
        Me.txtPInvoiceTaxAmt.Location = New System.Drawing.Point(916, 208)
        Me.txtPInvoiceTaxAmt.Name = "txtPInvoiceTaxAmt"
        Me.txtPInvoiceTaxAmt.ReadOnly = True
        Me.txtPInvoiceTaxAmt.Size = New System.Drawing.Size(97, 21)
        Me.txtPInvoiceTaxAmt.TabIndex = 28
        Me.txtPInvoiceTaxAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPInvoiceNetAmt
        '
        Me.txtPInvoiceNetAmt.Location = New System.Drawing.Point(1019, 208)
        Me.txtPInvoiceNetAmt.Name = "txtPInvoiceNetAmt"
        Me.txtPInvoiceNetAmt.ReadOnly = True
        Me.txtPInvoiceNetAmt.Size = New System.Drawing.Size(112, 21)
        Me.txtPInvoiceNetAmt.TabIndex = 29
        Me.txtPInvoiceNetAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(413, 69)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(79, 13)
        Me.Label27.TabIndex = 79
        Me.Label27.Text = "Currency Code"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(621, 68)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(30, 13)
        Me.Label28.TabIndex = 81
        Me.Label28.Text = "Rate"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(12, 141)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(126, 13)
        Me.Label29.TabIndex = 83
        Me.Label29.Text = "Purchase Incoming No. *"
        '
        'txtPReceiveNo
        '
        Me.txtPReceiveNo.Location = New System.Drawing.Point(147, 138)
        Me.txtPReceiveNo.Name = "txtPReceiveNo"
        Me.txtPReceiveNo.ReadOnly = True
        Me.txtPReceiveNo.Size = New System.Drawing.Size(127, 21)
        Me.txtPReceiveNo.TabIndex = 16
        '
        'btnPReceive
        '
        Me.btnPReceive.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPReceive.ImageIndex = 0
        Me.btnPReceive.ImageList = Me.ImageList1
        Me.btnPReceive.Location = New System.Drawing.Point(280, 135)
        Me.btnPReceive.Name = "btnPReceive"
        Me.btnPReceive.Size = New System.Drawing.Size(29, 25)
        Me.btnPReceive.TabIndex = 17
        Me.btnPReceive.UseVisualStyleBackColor = True
        '
        'txtCurrCode
        '
        Me.txtCurrCode.Location = New System.Drawing.Point(516, 65)
        Me.txtCurrCode.Name = "txtCurrCode"
        Me.txtCurrCode.ReadOnly = True
        Me.txtCurrCode.Size = New System.Drawing.Size(50, 21)
        Me.txtCurrCode.TabIndex = 7
        Me.txtCurrCode.TabStop = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(437, 189)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(47, 13)
        Me.Label31.TabIndex = 91
        Me.Label31.Text = "Location"
        '
        'txtLocationCode
        '
        Me.txtLocationCode.Location = New System.Drawing.Point(437, 208)
        Me.txtLocationCode.Name = "txtLocationCode"
        Me.txtLocationCode.ReadOnly = True
        Me.txtLocationCode.Size = New System.Drawing.Size(80, 21)
        Me.txtLocationCode.TabIndex = 22
        Me.txtLocationCode.TabStop = False
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
        'txtLocalPInvoiceTotal
        '
        Me.txtLocalPInvoiceTotal.Location = New System.Drawing.Point(761, 502)
        Me.txtLocalPInvoiceTotal.Name = "txtLocalPInvoiceTotal"
        Me.txtLocalPInvoiceTotal.ReadOnly = True
        Me.txtLocalPInvoiceTotal.Size = New System.Drawing.Size(118, 21)
        Me.txtLocalPInvoiceTotal.TabIndex = 34
        Me.txtLocalPInvoiceTotal.TabStop = False
        Me.txtLocalPInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLocalPInvoiceTax
        '
        Me.txtLocalPInvoiceTax.Location = New System.Drawing.Point(761, 473)
        Me.txtLocalPInvoiceTax.Name = "txtLocalPInvoiceTax"
        Me.txtLocalPInvoiceTax.ReadOnly = True
        Me.txtLocalPInvoiceTax.Size = New System.Drawing.Size(118, 21)
        Me.txtLocalPInvoiceTax.TabIndex = 33
        Me.txtLocalPInvoiceTax.TabStop = False
        Me.txtLocalPInvoiceTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLocalPInvoiceSubTotal
        '
        Me.txtLocalPInvoiceSubTotal.Location = New System.Drawing.Point(761, 446)
        Me.txtLocalPInvoiceSubTotal.Name = "txtLocalPInvoiceSubTotal"
        Me.txtLocalPInvoiceSubTotal.ReadOnly = True
        Me.txtLocalPInvoiceSubTotal.Size = New System.Drawing.Size(118, 21)
        Me.txtLocalPInvoiceSubTotal.TabIndex = 32
        Me.txtLocalPInvoiceSubTotal.TabStop = False
        Me.txtLocalPInvoiceSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPO
        '
        Me.btnPO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPO.ImageIndex = 0
        Me.btnPO.ImageList = Me.ImageList1
        Me.btnPO.Location = New System.Drawing.Point(280, 110)
        Me.btnPO.Name = "btnPO"
        Me.btnPO.Size = New System.Drawing.Size(29, 25)
        Me.btnPO.TabIndex = 15
        Me.btnPO.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(12, 115)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(111, 13)
        Me.Label38.TabIndex = 111
        Me.Label38.Text = "Purchase Order No. *"
        '
        'txtPONo
        '
        Me.txtPONo.Location = New System.Drawing.Point(147, 113)
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.ReadOnly = True
        Me.txtPONo.Size = New System.Drawing.Size(127, 21)
        Me.txtPONo.TabIndex = 14
        '
        'txtRefNo
        '
        Me.txtRefNo.Location = New System.Drawing.Point(147, 88)
        Me.txtRefNo.MaxLength = 50
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(127, 21)
        Me.txtRefNo.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Ref. No."
        '
        'btnPchCode
        '
        Me.btnPchCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPchCode.ImageIndex = 0
        Me.btnPchCode.ImageList = Me.ImageList1
        Me.btnPchCode.Location = New System.Drawing.Point(1037, 7)
        Me.btnPchCode.Name = "btnPchCode"
        Me.btnPchCode.Size = New System.Drawing.Size(29, 25)
        Me.btnPchCode.TabIndex = 12
        Me.btnPchCode.UseVisualStyleBackColor = True
        '
        'txtPchCode
        '
        Me.txtPchCode.Location = New System.Drawing.Point(954, 10)
        Me.txtPchCode.Name = "txtPchCode"
        Me.txtPchCode.ReadOnly = True
        Me.txtPchCode.Size = New System.Drawing.Size(80, 21)
        Me.txtPchCode.TabIndex = 11
        Me.txtPchCode.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(845, 13)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(88, 13)
        Me.Label37.TabIndex = 113
        Me.Label37.Text = "Purchase Code *"
        '
        'txtPOStatus
        '
        Me.txtPOStatus.Location = New System.Drawing.Point(952, 67)
        Me.txtPOStatus.Name = "txtPOStatus"
        Me.txtPOStatus.ReadOnly = True
        Me.txtPOStatus.Size = New System.Drawing.Size(153, 21)
        Me.txtPOStatus.TabIndex = 13
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(845, 70)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 116
        Me.Label14.Text = "Status"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(572, 97)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 13)
        Me.Label15.TabIndex = 120
        Me.Label15.Text = "days"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(413, 97)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 119
        Me.Label11.Text = "Payment Terms"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(413, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Payment Due Date"
        '
        'dtpPInvoiceDueDate
        '
        Me.dtpPInvoiceDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPInvoiceDueDate.Location = New System.Drawing.Point(516, 119)
        Me.dtpPInvoiceDueDate.Name = "dtpPInvoiceDueDate"
        Me.dtpPInvoiceDueDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpPInvoiceDueDate.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 124
        Me.Label8.Text = "Period"
        '
        'txtPeriodId
        '
        Me.txtPeriodId.Location = New System.Drawing.Point(147, 65)
        Me.txtPeriodId.Name = "txtPeriodId"
        Me.txtPeriodId.ReadOnly = True
        Me.txtPeriodId.Size = New System.Drawing.Size(97, 21)
        Me.txtPeriodId.TabIndex = 2
        '
        'ntbPInvoiceTerms
        '
        Me.ntbPInvoiceTerms.AllowSpace = False
        Me.ntbPInvoiceTerms.Location = New System.Drawing.Point(516, 92)
        Me.ntbPInvoiceTerms.MaxLength = 3
        Me.ntbPInvoiceTerms.Name = "ntbPInvoiceTerms"
        Me.ntbPInvoiceTerms.Size = New System.Drawing.Size(50, 21)
        Me.ntbPInvoiceTerms.TabIndex = 9
        Me.ntbPInvoiceTerms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbPInvCurrRate
        '
        Me.ntbPInvCurrRate.AllowSpace = False
        Me.ntbPInvCurrRate.Location = New System.Drawing.Point(657, 66)
        Me.ntbPInvCurrRate.MaxLength = 10
        Me.ntbPInvCurrRate.Name = "ntbPInvCurrRate"
        Me.ntbPInvCurrRate.Size = New System.Drawing.Size(76, 21)
        Me.ntbPInvCurrRate.TabIndex = 8
        Me.ntbPInvCurrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbPInvoiceTaxPercent
        '
        Me.ntbPInvoiceTaxPercent.AllowSpace = False
        Me.ntbPInvoiceTaxPercent.Location = New System.Drawing.Point(869, 208)
        Me.ntbPInvoiceTaxPercent.MaxLength = 3
        Me.ntbPInvoiceTaxPercent.Name = "ntbPInvoiceTaxPercent"
        Me.ntbPInvoiceTaxPercent.Size = New System.Drawing.Size(41, 21)
        Me.ntbPInvoiceTaxPercent.TabIndex = 27
        Me.ntbPInvoiceTaxPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbPInvoicePrice
        '
        Me.ntbPInvoicePrice.AllowSpace = False
        Me.ntbPInvoicePrice.Location = New System.Drawing.Point(642, 208)
        Me.ntbPInvoicePrice.MaxLength = 18
        Me.ntbPInvoicePrice.Name = "ntbPInvoicePrice"
        Me.ntbPInvoicePrice.Size = New System.Drawing.Size(97, 21)
        Me.ntbPInvoicePrice.TabIndex = 25
        Me.ntbPInvoicePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbPInvoiceQty
        '
        Me.ntbPInvoiceQty.AllowSpace = False
        Me.ntbPInvoiceQty.Location = New System.Drawing.Point(522, 208)
        Me.ntbPInvoiceQty.MaxLength = 8
        Me.ntbPInvoiceQty.Name = "ntbPInvoiceQty"
        Me.ntbPInvoiceQty.Size = New System.Drawing.Size(57, 21)
        Me.ntbPInvoiceQty.TabIndex = 23
        Me.ntbPInvoiceQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnWorkOrder
        '
        Me.btnWorkOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWorkOrder.ImageIndex = 0
        Me.btnWorkOrder.ImageList = Me.ImageList1
        Me.btnWorkOrder.Location = New System.Drawing.Point(279, 162)
        Me.btnWorkOrder.Name = "btnWorkOrder"
        Me.btnWorkOrder.Size = New System.Drawing.Size(29, 25)
        Me.btnWorkOrder.TabIndex = 126
        Me.btnWorkOrder.UseVisualStyleBackColor = True
        Me.btnWorkOrder.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 165)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 13)
        Me.Label10.TabIndex = 127
        Me.Label10.Text = "Work Order No. *"
        Me.Label10.Visible = False
        '
        'txtWorkOrderNo
        '
        Me.txtWorkOrderNo.Location = New System.Drawing.Point(147, 162)
        Me.txtWorkOrderNo.Name = "txtWorkOrderNo"
        Me.txtWorkOrderNo.ReadOnly = True
        Me.txtWorkOrderNo.Size = New System.Drawing.Size(127, 21)
        Me.txtWorkOrderNo.TabIndex = 125
        Me.txtWorkOrderNo.Visible = False
        '
        'frmPInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1140, 594)
        Me.Controls.Add(Me.btnWorkOrder)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtWorkOrderNo)
        Me.Controls.Add(Me.txtPeriodId)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpPInvoiceDueDate)
        Me.Controls.Add(Me.ntbPInvoiceTerms)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtPOStatus)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnPchCode)
        Me.Controls.Add(Me.txtPchCode)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.btnPO)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.txtPONo)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.txtLocalPInvoiceTotal)
        Me.Controls.Add(Me.txtLocalPInvoiceTax)
        Me.Controls.Add(Me.txtLocalPInvoiceSubTotal)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtLocationCode)
        Me.Controls.Add(Me.txtCurrCode)
        Me.Controls.Add(Me.btnPReceive)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.txtPReceiveNo)
        Me.Controls.Add(Me.ntbPInvCurrRate)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.txtPInvoiceNetAmt)
        Me.Controls.Add(Me.txtPInvoiceTaxAmt)
        Me.Controls.Add(Me.txtPInvoiceGrossAmt)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtSKUUoM)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.btnAddD)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.ntbPInvoiceTaxPercent)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.ntbPInvoicePrice)
        Me.Controls.Add(Me.ntbPInvoiceQty)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.txtPInvoiceDtlDesc)
        Me.Controls.Add(Me.txtSKUCode)
        Me.Controls.Add(Me.cmbPODtlType)
        Me.Controls.Add(Me.btnSKU)
        Me.Controls.Add(Me.btnSupplier)
        Me.Controls.Add(Me.btnDeleteD)
        Me.Controls.Add(Me.btnSaveD)
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
        Me.Controls.Add(Me.txtPInvoiceTotal)
        Me.Controls.Add(Me.txtPInvoiceTax)
        Me.Controls.Add(Me.txtPInvoiceSubtotal)
        Me.Controls.Add(Me.txtPInvoiceRemarks)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.txtSCode)
        Me.Controls.Add(Me.txtSName)
        Me.Controls.Add(Me.txtRefNo)
        Me.Controls.Add(Me.dtpPInvoiceDate)
        Me.Controls.Add(Me.txtPInvoiceNo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPInvoice"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Invoice"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpPInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSName As System.Windows.Forms.TextBox
    Friend WithEvents txtSCode As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents txtPInvoiceRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtPInvoiceSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents txtPInvoiceTax As System.Windows.Forms.TextBox
    Friend WithEvents txtPInvoiceTotal As System.Windows.Forms.TextBox
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
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnDeleteD As System.Windows.Forms.Button
    Friend WithEvents btnSaveD As System.Windows.Forms.Button
    Friend WithEvents btnSKU As System.Windows.Forms.Button
    Friend WithEvents btnSupplier As System.Windows.Forms.Button
    Friend WithEvents cmbPODtlType As System.Windows.Forms.ComboBox
    Friend WithEvents txtSKUCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPInvoiceDtlDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents ntbPInvoiceQty As levate.NumericTextBox
    Friend WithEvents ntbPInvoicePrice As levate.NumericTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ntbPInvoiceTaxPercent As levate.NumericTextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtSKUUoM As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtPInvoiceGrossAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtPInvoiceTaxAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtPInvoiceNetAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents ntbPInvCurrRate As levate.NumericTextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtPReceiveNo As System.Windows.Forms.TextBox
    Friend WithEvents btnPReceive As System.Windows.Forms.Button
    Friend WithEvents txtCurrCode As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtLocationCode As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtLocalPInvoiceTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalPInvoiceTax As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalPInvoiceSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents btnPO As System.Windows.Forms.Button
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtPONo As System.Windows.Forms.TextBox
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnPchCode As System.Windows.Forms.Button
    Friend WithEvents txtPchCode As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtPOStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ntbPInvoiceTerms As levate.NumericTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpPInvoiceDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodId As System.Windows.Forms.TextBox
    Friend WithEvents btnWorkOrder As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtWorkOrderNo As System.Windows.Forms.TextBox

End Class
