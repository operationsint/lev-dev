<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSReturn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSReturn))
        Me.txtSInvoiceNo = New System.Windows.Forms.TextBox()
        Me.dtpSInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.txtSName = New System.Windows.Forms.TextBox()
        Me.txtCCode = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.txtSInvoiceRemarks = New System.Windows.Forms.TextBox()
        Me.txtSInvoiceSubtotal = New System.Windows.Forms.TextBox()
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
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnDeleteD = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnSaveD = New System.Windows.Forms.Button()
        Me.btnSKU = New System.Windows.Forms.Button()
        Me.btnCustomer = New System.Windows.Forms.Button()
        Me.cmbSODtlType = New System.Windows.Forms.ComboBox()
        Me.txtSKUCode = New System.Windows.Forms.TextBox()
        Me.txtSInvoiceDtlDesc = New System.Windows.Forms.TextBox()
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
        Me.txtSInvoiceGrossAmt = New System.Windows.Forms.TextBox()
        Me.txtSInvoiceTaxAmt = New System.Windows.Forms.TextBox()
        Me.txtSInvoiceNetAmt = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtCurrCode = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtLocationCode = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtLocalSInvoiceTotal = New System.Windows.Forms.TextBox()
        Me.txtLocalSInvoiceTax = New System.Windows.Forms.TextBox()
        Me.txtLocalSInvoiceSubTotal = New System.Windows.Forms.TextBox()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSlsCode = New System.Windows.Forms.Button()
        Me.txtSlsCode = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtSInvStatus = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnLocation = New System.Windows.Forms.Button()
        Me.ntbSInvCurrRate = New levate.NumericTextBox()
        Me.ntbSInvoiceTaxPercent = New levate.NumericTextBox()
        Me.ntbSInvoicePrice = New levate.NumericTextBox()
        Me.ntbSInvoiceQty = New levate.NumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpSInvoiceDueDate = New System.Windows.Forms.DateTimePicker()
        Me.ntbSInvoiceTerms = New levate.NumericTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ntbReturnCost = New levate.NumericTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPeriodId = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtSInvoiceNo
        '
        Me.txtSInvoiceNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSInvoiceNo.Location = New System.Drawing.Point(147, 12)
        Me.txtSInvoiceNo.MaxLength = 10
        Me.txtSInvoiceNo.Name = "txtSInvoiceNo"
        Me.txtSInvoiceNo.Size = New System.Drawing.Size(127, 21)
        Me.txtSInvoiceNo.TabIndex = 0
        '
        'dtpSInvoiceDate
        '
        Me.dtpSInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSInvoiceDate.Location = New System.Drawing.Point(147, 40)
        Me.dtpSInvoiceDate.Name = "dtpSInvoiceDate"
        Me.dtpSInvoiceDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpSInvoiceDate.TabIndex = 1
        '
        'txtSName
        '
        Me.txtSName.Location = New System.Drawing.Point(563, 41)
        Me.txtSName.Name = "txtSName"
        Me.txtSName.ReadOnly = True
        Me.txtSName.Size = New System.Drawing.Size(217, 21)
        Me.txtSName.TabIndex = 6
        Me.txtSName.TabStop = False
        '
        'txtCCode
        '
        Me.txtCCode.Location = New System.Drawing.Point(563, 13)
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
        Me.ListView1.Location = New System.Drawing.Point(12, 217)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1259, 198)
        Me.ListView1.TabIndex = 31
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'txtSInvoiceRemarks
        '
        Me.txtSInvoiceRemarks.Location = New System.Drawing.Point(75, 449)
        Me.txtSInvoiceRemarks.MaxLength = 255
        Me.txtSInvoiceRemarks.Multiline = True
        Me.txtSInvoiceRemarks.Name = "txtSInvoiceRemarks"
        Me.txtSInvoiceRemarks.Size = New System.Drawing.Size(318, 59)
        Me.txtSInvoiceRemarks.TabIndex = 32
        '
        'txtSInvoiceSubtotal
        '
        Me.txtSInvoiceSubtotal.Location = New System.Drawing.Point(1112, 447)
        Me.txtSInvoiceSubtotal.Name = "txtSInvoiceSubtotal"
        Me.txtSInvoiceSubtotal.ReadOnly = True
        Me.txtSInvoiceSubtotal.Size = New System.Drawing.Size(118, 21)
        Me.txtSInvoiceSubtotal.TabIndex = 36
        Me.txtSInvoiceSubtotal.TabStop = False
        Me.txtSInvoiceSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSInvoiceTax
        '
        Me.txtSInvoiceTax.Location = New System.Drawing.Point(1112, 474)
        Me.txtSInvoiceTax.Name = "txtSInvoiceTax"
        Me.txtSInvoiceTax.ReadOnly = True
        Me.txtSInvoiceTax.Size = New System.Drawing.Size(118, 21)
        Me.txtSInvoiceTax.TabIndex = 37
        Me.txtSInvoiceTax.TabStop = False
        Me.txtSInvoiceTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSInvoiceTotal
        '
        Me.txtSInvoiceTotal.Location = New System.Drawing.Point(1112, 503)
        Me.txtSInvoiceTotal.Name = "txtSInvoiceTotal"
        Me.txtSInvoiceTotal.ReadOnly = True
        Me.txtSInvoiceTotal.Size = New System.Drawing.Size(118, 21)
        Me.txtSInvoiceTotal.TabIndex = 38
        Me.txtSInvoiceTotal.TabStop = False
        Me.txtSInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(1097, 556)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 26)
        Me.btnCancel.TabIndex = 43
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(827, 556)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(84, 26)
        Me.btnEdit.TabIndex = 40
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(917, 556)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnAdd.TabIndex = 41
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(737, 556)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 26)
        Me.btnDelete.TabIndex = 39
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(1007, 556)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 26)
        Me.btnSave.TabIndex = 42
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(458, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Customer Code *"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(1047, 450)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Subtotal"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(1047, 478)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Tax"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(1047, 506)
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
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Sales Return No.*"
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
        Me.btnDeleteD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteD.ImageIndex = 2
        Me.btnDeleteD.ImageList = Me.ImageList1
        Me.btnDeleteD.Location = New System.Drawing.Point(1211, 143)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 29
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
        Me.btnSaveD.Location = New System.Drawing.Point(1179, 143)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 28
        Me.btnSaveD.UseVisualStyleBackColor = True
        '
        'btnSKU
        '
        Me.btnSKU.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSKU.ImageIndex = 1
        Me.btnSKU.ImageList = Me.ImageList1
        Me.btnSKU.Location = New System.Drawing.Point(190, 188)
        Me.btnSKU.Name = "btnSKU"
        Me.btnSKU.Size = New System.Drawing.Size(29, 25)
        Me.btnSKU.TabIndex = 16
        Me.btnSKU.UseVisualStyleBackColor = True
        '
        'btnCustomer
        '
        Me.btnCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomer.ImageIndex = 0
        Me.btnCustomer.ImageList = Me.ImageList1
        Me.btnCustomer.Location = New System.Drawing.Point(646, 10)
        Me.btnCustomer.Name = "btnCustomer"
        Me.btnCustomer.Size = New System.Drawing.Size(29, 25)
        Me.btnCustomer.TabIndex = 5
        Me.btnCustomer.UseVisualStyleBackColor = True
        '
        'cmbSODtlType
        '
        Me.cmbSODtlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSODtlType.Enabled = False
        Me.cmbSODtlType.FormattingEnabled = True
        Me.cmbSODtlType.Location = New System.Drawing.Point(15, 190)
        Me.cmbSODtlType.Name = "cmbSODtlType"
        Me.cmbSODtlType.Size = New System.Drawing.Size(88, 21)
        Me.cmbSODtlType.TabIndex = 14
        '
        'txtSKUCode
        '
        Me.txtSKUCode.Location = New System.Drawing.Point(108, 190)
        Me.txtSKUCode.MaxLength = 50
        Me.txtSKUCode.Name = "txtSKUCode"
        Me.txtSKUCode.ReadOnly = True
        Me.txtSKUCode.Size = New System.Drawing.Size(80, 21)
        Me.txtSKUCode.TabIndex = 15
        Me.txtSKUCode.TabStop = False
        '
        'txtSInvoiceDtlDesc
        '
        Me.txtSInvoiceDtlDesc.Location = New System.Drawing.Point(222, 190)
        Me.txtSInvoiceDtlDesc.MaxLength = 100
        Me.txtSInvoiceDtlDesc.Name = "txtSInvoiceDtlDesc"
        Me.txtSInvoiceDtlDesc.Size = New System.Drawing.Size(209, 21)
        Me.txtSInvoiceDtlDesc.TabIndex = 17
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(1187, 556)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 26)
        Me.btnPrint.TabIndex = 44
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 171)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 13)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "Line Type"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(109, 171)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(32, 13)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Code"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(219, 171)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "Line Description"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(584, 171)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(29, 13)
        Me.Label19.TabIndex = 60
        Me.Label19.Text = "Qty."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(827, 171)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 13)
        Me.Label20.TabIndex = 61
        Me.Label20.Text = "Unit Price"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(458, 42)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 13)
        Me.Label21.TabIndex = 62
        Me.Label21.Text = "Customer Name"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(1011, 171)
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
        Me.btnAddD.Location = New System.Drawing.Point(1242, 143)
        Me.btnAddD.Name = "btnAddD"
        Me.btnAddD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD.TabIndex = 30
        Me.btnAddD.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(1094, 171)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 13)
        Me.Label23.TabIndex = 67
        Me.Label23.Text = "Tax Amount"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(927, 171)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(74, 13)
        Me.Label24.TabIndex = 69
        Me.Label24.Text = "Gross Amount"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(1207, 171)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(64, 13)
        Me.Label25.TabIndex = 71
        Me.Label25.Text = "Net Amount"
        '
        'txtSKUUoM
        '
        Me.txtSKUUoM.Location = New System.Drawing.Point(619, 190)
        Me.txtSKUUoM.Name = "txtSKUUoM"
        Me.txtSKUUoM.ReadOnly = True
        Me.txtSKUUoM.Size = New System.Drawing.Size(53, 21)
        Me.txtSKUUoM.TabIndex = 21
        Me.txtSKUUoM.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(619, 171)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(28, 13)
        Me.Label26.TabIndex = 73
        Me.Label26.Text = "UoM"
        '
        'txtSInvoiceGrossAmt
        '
        Me.txtSInvoiceGrossAmt.Location = New System.Drawing.Point(885, 190)
        Me.txtSInvoiceGrossAmt.Name = "txtSInvoiceGrossAmt"
        Me.txtSInvoiceGrossAmt.ReadOnly = True
        Me.txtSInvoiceGrossAmt.Size = New System.Drawing.Size(118, 21)
        Me.txtSInvoiceGrossAmt.TabIndex = 24
        Me.txtSInvoiceGrossAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSInvoiceTaxAmt
        '
        Me.txtSInvoiceTaxAmt.Location = New System.Drawing.Point(1056, 190)
        Me.txtSInvoiceTaxAmt.Name = "txtSInvoiceTaxAmt"
        Me.txtSInvoiceTaxAmt.ReadOnly = True
        Me.txtSInvoiceTaxAmt.Size = New System.Drawing.Size(97, 21)
        Me.txtSInvoiceTaxAmt.TabIndex = 26
        Me.txtSInvoiceTaxAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSInvoiceNetAmt
        '
        Me.txtSInvoiceNetAmt.Location = New System.Drawing.Point(1159, 190)
        Me.txtSInvoiceNetAmt.Name = "txtSInvoiceNetAmt"
        Me.txtSInvoiceNetAmt.ReadOnly = True
        Me.txtSInvoiceNetAmt.Size = New System.Drawing.Size(112, 21)
        Me.txtSInvoiceNetAmt.TabIndex = 27
        Me.txtSInvoiceNetAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(458, 71)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(79, 13)
        Me.Label27.TabIndex = 79
        Me.Label27.Text = "Currency Code"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(668, 70)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(30, 13)
        Me.Label28.TabIndex = 81
        Me.Label28.Text = "Rate"
        '
        'txtCurrCode
        '
        Me.txtCurrCode.Location = New System.Drawing.Point(563, 67)
        Me.txtCurrCode.Name = "txtCurrCode"
        Me.txtCurrCode.ReadOnly = True
        Me.txtCurrCode.Size = New System.Drawing.Size(50, 21)
        Me.txtCurrCode.TabIndex = 7
        Me.txtCurrCode.TabStop = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(437, 171)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(47, 13)
        Me.Label31.TabIndex = 91
        Me.Label31.Text = "Location"
        '
        'txtLocationCode
        '
        Me.txtLocationCode.Location = New System.Drawing.Point(437, 190)
        Me.txtLocationCode.Name = "txtLocationCode"
        Me.txtLocationCode.ReadOnly = True
        Me.txtLocationCode.Size = New System.Drawing.Size(80, 21)
        Me.txtLocationCode.TabIndex = 18
        Me.txtLocationCode.TabStop = False
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(765, 506)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(58, 13)
        Me.Label34.TabIndex = 102
        Me.Label34.Text = "Local Total"
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(765, 478)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(52, 13)
        Me.Label35.TabIndex = 101
        Me.Label35.Text = "Local Tax"
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(765, 450)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(74, 13)
        Me.Label36.TabIndex = 100
        Me.Label36.Text = "Local Subtotal"
        '
        'txtLocalSInvoiceTotal
        '
        Me.txtLocalSInvoiceTotal.Location = New System.Drawing.Point(859, 503)
        Me.txtLocalSInvoiceTotal.Name = "txtLocalSInvoiceTotal"
        Me.txtLocalSInvoiceTotal.ReadOnly = True
        Me.txtLocalSInvoiceTotal.Size = New System.Drawing.Size(118, 21)
        Me.txtLocalSInvoiceTotal.TabIndex = 35
        Me.txtLocalSInvoiceTotal.TabStop = False
        Me.txtLocalSInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLocalSInvoiceTax
        '
        Me.txtLocalSInvoiceTax.Location = New System.Drawing.Point(859, 474)
        Me.txtLocalSInvoiceTax.Name = "txtLocalSInvoiceTax"
        Me.txtLocalSInvoiceTax.ReadOnly = True
        Me.txtLocalSInvoiceTax.Size = New System.Drawing.Size(118, 21)
        Me.txtLocalSInvoiceTax.TabIndex = 34
        Me.txtLocalSInvoiceTax.TabStop = False
        Me.txtLocalSInvoiceTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLocalSInvoiceSubTotal
        '
        Me.txtLocalSInvoiceSubTotal.Location = New System.Drawing.Point(859, 447)
        Me.txtLocalSInvoiceSubTotal.Name = "txtLocalSInvoiceSubTotal"
        Me.txtLocalSInvoiceSubTotal.ReadOnly = True
        Me.txtLocalSInvoiceSubTotal.Size = New System.Drawing.Size(118, 21)
        Me.txtLocalSInvoiceSubTotal.TabIndex = 33
        Me.txtLocalSInvoiceSubTotal.TabStop = False
        Me.txtLocalSInvoiceSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRefNo
        '
        Me.txtRefNo.Location = New System.Drawing.Point(147, 94)
        Me.txtRefNo.MaxLength = 50
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(127, 21)
        Me.txtRefNo.TabIndex = 3
        Me.txtRefNo.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "Ref. No."
        Me.Label9.Visible = False
        '
        'btnSlsCode
        '
        Me.btnSlsCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSlsCode.ImageIndex = 0
        Me.btnSlsCode.ImageList = Me.ImageList1
        Me.btnSlsCode.Location = New System.Drawing.Point(1140, 8)
        Me.btnSlsCode.Name = "btnSlsCode"
        Me.btnSlsCode.Size = New System.Drawing.Size(29, 25)
        Me.btnSlsCode.TabIndex = 12
        Me.btnSlsCode.UseVisualStyleBackColor = True
        '
        'txtSlsCode
        '
        Me.txtSlsCode.Location = New System.Drawing.Point(1057, 11)
        Me.txtSlsCode.Name = "txtSlsCode"
        Me.txtSlsCode.ReadOnly = True
        Me.txtSlsCode.Size = New System.Drawing.Size(80, 21)
        Me.txtSlsCode.TabIndex = 11
        Me.txtSlsCode.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(948, 14)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(60, 13)
        Me.Label37.TabIndex = 113
        Me.Label37.Text = "Sales Code"
        '
        'txtSInvStatus
        '
        Me.txtSInvStatus.Location = New System.Drawing.Point(1055, 68)
        Me.txtSInvStatus.Name = "txtSInvStatus"
        Me.txtSInvStatus.ReadOnly = True
        Me.txtSInvStatus.Size = New System.Drawing.Size(153, 21)
        Me.txtSInvStatus.TabIndex = 13
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(948, 71)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 116
        Me.Label14.Text = "Status"
        '
        'btnLocation
        '
        Me.btnLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLocation.ImageIndex = 1
        Me.btnLocation.ImageList = Me.ImageList1
        Me.btnLocation.Location = New System.Drawing.Point(521, 188)
        Me.btnLocation.Name = "btnLocation"
        Me.btnLocation.Size = New System.Drawing.Size(29, 25)
        Me.btnLocation.TabIndex = 19
        Me.btnLocation.UseVisualStyleBackColor = True
        '
        'ntbSInvCurrRate
        '
        Me.ntbSInvCurrRate.AllowSpace = False
        Me.ntbSInvCurrRate.Location = New System.Drawing.Point(704, 68)
        Me.ntbSInvCurrRate.MaxLength = 10
        Me.ntbSInvCurrRate.Name = "ntbSInvCurrRate"
        Me.ntbSInvCurrRate.Size = New System.Drawing.Size(76, 21)
        Me.ntbSInvCurrRate.TabIndex = 8
        Me.ntbSInvCurrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSInvoiceTaxPercent
        '
        Me.ntbSInvoiceTaxPercent.AllowSpace = False
        Me.ntbSInvoiceTaxPercent.Location = New System.Drawing.Point(1009, 190)
        Me.ntbSInvoiceTaxPercent.MaxLength = 3
        Me.ntbSInvoiceTaxPercent.Name = "ntbSInvoiceTaxPercent"
        Me.ntbSInvoiceTaxPercent.Size = New System.Drawing.Size(41, 21)
        Me.ntbSInvoiceTaxPercent.TabIndex = 25
        Me.ntbSInvoiceTaxPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSInvoicePrice
        '
        Me.ntbSInvoicePrice.AllowSpace = False
        Me.ntbSInvoicePrice.Location = New System.Drawing.Point(782, 190)
        Me.ntbSInvoicePrice.MaxLength = 18
        Me.ntbSInvoicePrice.Name = "ntbSInvoicePrice"
        Me.ntbSInvoicePrice.Size = New System.Drawing.Size(97, 21)
        Me.ntbSInvoicePrice.TabIndex = 23
        Me.ntbSInvoicePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSInvoiceQty
        '
        Me.ntbSInvoiceQty.AllowSpace = False
        Me.ntbSInvoiceQty.Location = New System.Drawing.Point(556, 190)
        Me.ntbSInvoiceQty.MaxLength = 8
        Me.ntbSInvoiceQty.Name = "ntbSInvoiceQty"
        Me.ntbSInvoiceQty.Size = New System.Drawing.Size(57, 21)
        Me.ntbSInvoiceQty.TabIndex = 20
        Me.ntbSInvoiceQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(460, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 127
        Me.Label2.Text = "Payment Due Date"
        '
        'dtpSInvoiceDueDate
        '
        Me.dtpSInvoiceDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSInvoiceDueDate.Location = New System.Drawing.Point(563, 120)
        Me.dtpSInvoiceDueDate.Name = "dtpSInvoiceDueDate"
        Me.dtpSInvoiceDueDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpSInvoiceDueDate.TabIndex = 10
        '
        'ntbSInvoiceTerms
        '
        Me.ntbSInvoiceTerms.AllowSpace = False
        Me.ntbSInvoiceTerms.Location = New System.Drawing.Point(563, 93)
        Me.ntbSInvoiceTerms.MaxLength = 3
        Me.ntbSInvoiceTerms.Name = "ntbSInvoiceTerms"
        Me.ntbSInvoiceTerms.Size = New System.Drawing.Size(50, 21)
        Me.ntbSInvoiceTerms.TabIndex = 9
        Me.ntbSInvoiceTerms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(619, 98)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 13)
        Me.Label15.TabIndex = 125
        Me.Label15.Text = "days"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(460, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 124
        Me.Label11.Text = "Payment Terms"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(746, 171)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 129
        Me.Label8.Text = "Cost"
        '
        'ntbReturnCost
        '
        Me.ntbReturnCost.AllowSpace = False
        Me.ntbReturnCost.Location = New System.Drawing.Point(678, 190)
        Me.ntbReturnCost.MaxLength = 18
        Me.ntbReturnCost.Name = "ntbReturnCost"
        Me.ntbReturnCost.Size = New System.Drawing.Size(97, 21)
        Me.ntbReturnCost.TabIndex = 22
        Me.ntbReturnCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 70)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 182
        Me.Label10.Text = "Period"
        '
        'txtPeriodId
        '
        Me.txtPeriodId.Location = New System.Drawing.Point(147, 68)
        Me.txtPeriodId.Name = "txtPeriodId"
        Me.txtPeriodId.ReadOnly = True
        Me.txtPeriodId.Size = New System.Drawing.Size(97, 21)
        Me.txtPeriodId.TabIndex = 2
        '
        'frmSReturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1279, 594)
        Me.Controls.Add(Me.txtPeriodId)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ntbReturnCost)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpSInvoiceDueDate)
        Me.Controls.Add(Me.ntbSInvoiceTerms)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnLocation)
        Me.Controls.Add(Me.txtSInvStatus)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnSlsCode)
        Me.Controls.Add(Me.txtSlsCode)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.txtLocalSInvoiceTotal)
        Me.Controls.Add(Me.txtLocalSInvoiceTax)
        Me.Controls.Add(Me.txtLocalSInvoiceSubTotal)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtLocationCode)
        Me.Controls.Add(Me.txtCurrCode)
        Me.Controls.Add(Me.ntbSInvCurrRate)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.txtSInvoiceNetAmt)
        Me.Controls.Add(Me.txtSInvoiceTaxAmt)
        Me.Controls.Add(Me.txtSInvoiceGrossAmt)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtSKUUoM)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.btnAddD)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.ntbSInvoiceTaxPercent)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.ntbSInvoicePrice)
        Me.Controls.Add(Me.ntbSInvoiceQty)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.txtSInvoiceDtlDesc)
        Me.Controls.Add(Me.txtSKUCode)
        Me.Controls.Add(Me.cmbSODtlType)
        Me.Controls.Add(Me.btnSKU)
        Me.Controls.Add(Me.btnCustomer)
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
        Me.Controls.Add(Me.txtSInvoiceTotal)
        Me.Controls.Add(Me.txtSInvoiceTax)
        Me.Controls.Add(Me.txtSInvoiceSubtotal)
        Me.Controls.Add(Me.txtSInvoiceRemarks)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.txtCCode)
        Me.Controls.Add(Me.txtSName)
        Me.Controls.Add(Me.txtRefNo)
        Me.Controls.Add(Me.dtpSInvoiceDate)
        Me.Controls.Add(Me.txtSInvoiceNo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSReturn"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Return"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpSInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSName As System.Windows.Forms.TextBox
    Friend WithEvents txtCCode As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents txtSInvoiceRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtSInvoiceSubtotal As System.Windows.Forms.TextBox
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
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnDeleteD As System.Windows.Forms.Button
    Friend WithEvents btnSaveD As System.Windows.Forms.Button
    Friend WithEvents btnSKU As System.Windows.Forms.Button
    Friend WithEvents btnCustomer As System.Windows.Forms.Button
    Friend WithEvents cmbSODtlType As System.Windows.Forms.ComboBox
    Friend WithEvents txtSKUCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSInvoiceDtlDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents ntbSInvoiceQty As levate.NumericTextBox
    Friend WithEvents ntbSInvoicePrice As levate.NumericTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ntbSInvoiceTaxPercent As levate.NumericTextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtSKUUoM As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtSInvoiceGrossAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtSInvoiceTaxAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtSInvoiceNetAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents ntbSInvCurrRate As levate.NumericTextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtCurrCode As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtLocationCode As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtLocalSInvoiceTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalSInvoiceTax As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalSInvoiceSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnSlsCode As System.Windows.Forms.Button
    Friend WithEvents txtSlsCode As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtSInvStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnLocation As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpSInvoiceDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ntbSInvoiceTerms As levate.NumericTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ntbReturnCost As levate.NumericTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodId As System.Windows.Forms.TextBox

End Class
