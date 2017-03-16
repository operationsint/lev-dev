<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBC))
        Me.txtBCNo = New System.Windows.Forms.TextBox()
        Me.dtpBCDate = New System.Windows.Forms.DateTimePicker()
        Me.txtCName = New System.Windows.Forms.TextBox()
        Me.txtCCode = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.txtBCRemarks = New System.Windows.Forms.TextBox()
        Me.txtBCTrfPriceTotal = New System.Windows.Forms.TextBox()
        Me.txtBCSumPackQty = New System.Windows.Forms.TextBox()
        Me.txtBCSumGrossWeight = New System.Windows.Forms.TextBox()
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
        Me.btnCustomer = New System.Windows.Forms.Button()
        Me.txtBCDtlDesc = New System.Windows.Forms.TextBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAddD = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtSDeliveryNo = New System.Windows.Forms.TextBox()
        Me.btnSDelivery = New System.Windows.Forms.Button()
        Me.txtCurrCode = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtBCNetWeight = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBCContractNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpBCContractDate = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtBCDtlPackQty = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBCDtlGrossWeight = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtBCDtlNetWeight = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbBCProcessType = New System.Windows.Forms.ComboBox()
        Me.txtSKUUoM = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.ntbBCCurrRate = New levate.NumericTextBox()
        Me.ntbBCDtlPrice = New levate.NumericTextBox()
        Me.ntbSDeliveryQty = New levate.NumericTextBox()
        Me.btnPrintGroup = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtBCNo
        '
        Me.txtBCNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBCNo.Location = New System.Drawing.Point(139, 12)
        Me.txtBCNo.MaxLength = 10
        Me.txtBCNo.Name = "txtBCNo"
        Me.txtBCNo.Size = New System.Drawing.Size(127, 21)
        Me.txtBCNo.TabIndex = 0
        '
        'dtpBCDate
        '
        Me.dtpBCDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBCDate.Location = New System.Drawing.Point(139, 40)
        Me.dtpBCDate.Name = "dtpBCDate"
        Me.dtpBCDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpBCDate.TabIndex = 1
        '
        'txtCName
        '
        Me.txtCName.Location = New System.Drawing.Point(462, 39)
        Me.txtCName.Name = "txtCName"
        Me.txtCName.ReadOnly = True
        Me.txtCName.Size = New System.Drawing.Size(217, 21)
        Me.txtCName.TabIndex = 6
        Me.txtCName.TabStop = False
        '
        'txtCCode
        '
        Me.txtCCode.Location = New System.Drawing.Point(462, 12)
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
        Me.ListView1.Location = New System.Drawing.Point(10, 195)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1010, 198)
        Me.ListView1.TabIndex = 22
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'txtBCRemarks
        '
        Me.txtBCRemarks.Location = New System.Drawing.Point(74, 404)
        Me.txtBCRemarks.MaxLength = 255
        Me.txtBCRemarks.Multiline = True
        Me.txtBCRemarks.Name = "txtBCRemarks"
        Me.txtBCRemarks.Size = New System.Drawing.Size(318, 59)
        Me.txtBCRemarks.TabIndex = 23
        '
        'txtBCTrfPriceTotal
        '
        Me.txtBCTrfPriceTotal.Location = New System.Drawing.Point(902, 402)
        Me.txtBCTrfPriceTotal.Name = "txtBCTrfPriceTotal"
        Me.txtBCTrfPriceTotal.ReadOnly = True
        Me.txtBCTrfPriceTotal.Size = New System.Drawing.Size(118, 21)
        Me.txtBCTrfPriceTotal.TabIndex = 24
        Me.txtBCTrfPriceTotal.TabStop = False
        Me.txtBCTrfPriceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBCSumPackQty
        '
        Me.txtBCSumPackQty.Location = New System.Drawing.Point(902, 429)
        Me.txtBCSumPackQty.Name = "txtBCSumPackQty"
        Me.txtBCSumPackQty.ReadOnly = True
        Me.txtBCSumPackQty.Size = New System.Drawing.Size(118, 21)
        Me.txtBCSumPackQty.TabIndex = 25
        Me.txtBCSumPackQty.TabStop = False
        Me.txtBCSumPackQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBCSumGrossWeight
        '
        Me.txtBCSumGrossWeight.Location = New System.Drawing.Point(902, 456)
        Me.txtBCSumGrossWeight.Name = "txtBCSumGrossWeight"
        Me.txtBCSumGrossWeight.ReadOnly = True
        Me.txtBCSumGrossWeight.Size = New System.Drawing.Size(118, 21)
        Me.txtBCSumGrossWeight.TabIndex = 26
        Me.txtBCSumGrossWeight.TabStop = False
        Me.txtBCSumGrossWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(755, 537)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 26)
        Me.btnCancel.TabIndex = 32
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(485, 537)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(84, 26)
        Me.btnEdit.TabIndex = 29
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(575, 537)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnAdd.TabIndex = 30
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(395, 537)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 26)
        Me.btnDelete.TabIndex = 28
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(665, 537)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 26)
        Me.btnSave.TabIndex = 31
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(365, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Customer Code *"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(751, 405)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Total Harga Penyerahan"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(751, 432)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Total Jumlah Kemasan"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(751, 459)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Total Berat Kotor (Kg)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "BC No. *"
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
        Me.Label12.Location = New System.Drawing.Point(14, 404)
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
        Me.btnDeleteD.Location = New System.Drawing.Point(958, 164)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 20
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
        Me.btnSaveD.Location = New System.Drawing.Point(927, 164)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 19
        Me.btnSaveD.UseVisualStyleBackColor = True
        '
        'btnCustomer
        '
        Me.btnCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomer.ImageIndex = 0
        Me.btnCustomer.ImageList = Me.ImageList1
        Me.btnCustomer.Location = New System.Drawing.Point(545, 9)
        Me.btnCustomer.Name = "btnCustomer"
        Me.btnCustomer.Size = New System.Drawing.Size(29, 25)
        Me.btnCustomer.TabIndex = 5
        Me.btnCustomer.UseVisualStyleBackColor = True
        '
        'txtBCDtlDesc
        '
        Me.txtBCDtlDesc.Location = New System.Drawing.Point(179, 168)
        Me.txtBCDtlDesc.MaxLength = 100
        Me.txtBCDtlDesc.Name = "txtBCDtlDesc"
        Me.txtBCDtlDesc.ReadOnly = True
        Me.txtBCDtlDesc.Size = New System.Drawing.Size(209, 21)
        Me.txtBCDtlDesc.TabIndex = 12
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(845, 537)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 26)
        Me.btnPrint.TabIndex = 33
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(176, 149)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "Line Description"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(422, 149)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(29, 13)
        Me.Label19.TabIndex = 60
        Me.Label19.Text = "Qty."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(514, 149)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(97, 13)
        Me.Label20.TabIndex = 61
        Me.Label20.Text = "Harga Penyerahan"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(365, 41)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 13)
        Me.Label21.TabIndex = 62
        Me.Label21.Text = "Customer Name"
        '
        'btnAddD
        '
        Me.btnAddD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD.ImageIndex = 4
        Me.btnAddD.ImageList = Me.ImageList1
        Me.btnAddD.Location = New System.Drawing.Point(989, 164)
        Me.btnAddD.Name = "btnAddD"
        Me.btnAddD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD.TabIndex = 21
        Me.btnAddD.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(365, 68)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(79, 13)
        Me.Label27.TabIndex = 79
        Me.Label27.Text = "Currency Code"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(567, 68)
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
        Me.Label29.Size = New System.Drawing.Size(103, 13)
        Me.Label29.TabIndex = 83
        Me.Label29.Text = "Sales Delivery No. *"
        '
        'txtSDeliveryNo
        '
        Me.txtSDeliveryNo.Location = New System.Drawing.Point(10, 168)
        Me.txtSDeliveryNo.Name = "txtSDeliveryNo"
        Me.txtSDeliveryNo.ReadOnly = True
        Me.txtSDeliveryNo.Size = New System.Drawing.Size(127, 21)
        Me.txtSDeliveryNo.TabIndex = 10
        '
        'btnSDelivery
        '
        Me.btnSDelivery.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSDelivery.ImageIndex = 0
        Me.btnSDelivery.ImageList = Me.ImageList1
        Me.btnSDelivery.Location = New System.Drawing.Point(144, 166)
        Me.btnSDelivery.Name = "btnSDelivery"
        Me.btnSDelivery.Size = New System.Drawing.Size(29, 25)
        Me.btnSDelivery.TabIndex = 11
        Me.btnSDelivery.UseVisualStyleBackColor = True
        '
        'txtCurrCode
        '
        Me.txtCurrCode.Location = New System.Drawing.Point(462, 65)
        Me.txtCurrCode.Name = "txtCurrCode"
        Me.txtCurrCode.ReadOnly = True
        Me.txtCurrCode.Size = New System.Drawing.Size(50, 21)
        Me.txtCurrCode.TabIndex = 7
        Me.txtCurrCode.TabStop = False
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(751, 485)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(115, 13)
        Me.Label36.TabIndex = 100
        Me.Label36.Text = "Total Berat Bersih (Kg)"
        '
        'txtBCNetWeight
        '
        Me.txtBCNetWeight.Location = New System.Drawing.Point(902, 482)
        Me.txtBCNetWeight.Name = "txtBCNetWeight"
        Me.txtBCNetWeight.ReadOnly = True
        Me.txtBCNetWeight.Size = New System.Drawing.Size(118, 21)
        Me.txtBCNetWeight.TabIndex = 27
        Me.txtBCNetWeight.TabStop = False
        Me.txtBCNetWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 104
        Me.Label9.Text = "Contract No."
        '
        'txtBCContractNo
        '
        Me.txtBCContractNo.Location = New System.Drawing.Point(139, 68)
        Me.txtBCContractNo.MaxLength = 50
        Me.txtBCContractNo.Name = "txtBCContractNo"
        Me.txtBCContractNo.Size = New System.Drawing.Size(155, 21)
        Me.txtBCContractNo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Contract Date"
        '
        'dtpBCContractDate
        '
        Me.dtpBCContractDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBCContractDate.Location = New System.Drawing.Point(139, 95)
        Me.dtpBCContractDate.Name = "dtpBCContractDate"
        Me.dtpBCContractDate.ShowCheckBox = True
        Me.dtpBCContractDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpBCContractDate.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(632, 150)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 13)
        Me.Label8.TabIndex = 108
        Me.Label8.Text = "Jumlah Kemasan"
        '
        'txtBCDtlPackQty
        '
        Me.txtBCDtlPackQty.Location = New System.Drawing.Point(617, 168)
        Me.txtBCDtlPackQty.Name = "txtBCDtlPackQty"
        Me.txtBCDtlPackQty.ReadOnly = True
        Me.txtBCDtlPackQty.Size = New System.Drawing.Size(97, 21)
        Me.txtBCDtlPackQty.TabIndex = 16
        Me.txtBCDtlPackQty.TabStop = False
        Me.txtBCDtlPackQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(733, 150)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 110
        Me.Label10.Text = "Berat Kotor (Kg)"
        '
        'txtBCDtlGrossWeight
        '
        Me.txtBCDtlGrossWeight.Location = New System.Drawing.Point(720, 168)
        Me.txtBCDtlGrossWeight.Name = "txtBCDtlGrossWeight"
        Me.txtBCDtlGrossWeight.ReadOnly = True
        Me.txtBCDtlGrossWeight.Size = New System.Drawing.Size(97, 21)
        Me.txtBCDtlGrossWeight.TabIndex = 17
        Me.txtBCDtlGrossWeight.TabStop = False
        Me.txtBCDtlGrossWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(842, 149)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 13)
        Me.Label11.TabIndex = 112
        Me.Label11.Text = "Berat Bersih (Kg)"
        '
        'txtBCDtlNetWeight
        '
        Me.txtBCDtlNetWeight.Location = New System.Drawing.Point(823, 168)
        Me.txtBCDtlNetWeight.Name = "txtBCDtlNetWeight"
        Me.txtBCDtlNetWeight.ReadOnly = True
        Me.txtBCDtlNetWeight.Size = New System.Drawing.Size(98, 21)
        Me.txtBCDtlNetWeight.TabIndex = 18
        Me.txtBCDtlNetWeight.TabStop = False
        Me.txtBCDtlNetWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(778, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 114
        Me.Label13.Text = "Process Type"
        '
        'cmbBCProcessType
        '
        Me.cmbBCProcessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBCProcessType.FormattingEnabled = True
        Me.cmbBCProcessType.Location = New System.Drawing.Point(875, 12)
        Me.cmbBCProcessType.Name = "cmbBCProcessType"
        Me.cmbBCProcessType.Size = New System.Drawing.Size(112, 21)
        Me.cmbBCProcessType.TabIndex = 9
        '
        'txtSKUUoM
        '
        Me.txtSKUUoM.Location = New System.Drawing.Point(455, 168)
        Me.txtSKUUoM.Name = "txtSKUUoM"
        Me.txtSKUUoM.ReadOnly = True
        Me.txtSKUUoM.Size = New System.Drawing.Size(53, 21)
        Me.txtSKUUoM.TabIndex = 14
        Me.txtSKUUoM.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(452, 149)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(28, 13)
        Me.Label26.TabIndex = 73
        Me.Label26.Text = "UoM"
        '
        'ntbBCCurrRate
        '
        Me.ntbBCCurrRate.AllowSpace = False
        Me.ntbBCCurrRate.Location = New System.Drawing.Point(603, 66)
        Me.ntbBCCurrRate.MaxLength = 10
        Me.ntbBCCurrRate.Name = "ntbBCCurrRate"
        Me.ntbBCCurrRate.Size = New System.Drawing.Size(76, 21)
        Me.ntbBCCurrRate.TabIndex = 8
        Me.ntbBCCurrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbBCDtlPrice
        '
        Me.ntbBCDtlPrice.AllowSpace = False
        Me.ntbBCDtlPrice.Location = New System.Drawing.Point(514, 168)
        Me.ntbBCDtlPrice.MaxLength = 18
        Me.ntbBCDtlPrice.Name = "ntbBCDtlPrice"
        Me.ntbBCDtlPrice.ReadOnly = True
        Me.ntbBCDtlPrice.Size = New System.Drawing.Size(97, 21)
        Me.ntbBCDtlPrice.TabIndex = 15
        Me.ntbBCDtlPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSDeliveryQty
        '
        Me.ntbSDeliveryQty.AllowSpace = False
        Me.ntbSDeliveryQty.Location = New System.Drawing.Point(394, 168)
        Me.ntbSDeliveryQty.MaxLength = 8
        Me.ntbSDeliveryQty.Name = "ntbSDeliveryQty"
        Me.ntbSDeliveryQty.ReadOnly = True
        Me.ntbSDeliveryQty.Size = New System.Drawing.Size(57, 21)
        Me.ntbSDeliveryQty.TabIndex = 13
        Me.ntbSDeliveryQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPrintGroup
        '
        Me.btnPrintGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintGroup.Location = New System.Drawing.Point(934, 537)
        Me.btnPrintGroup.Name = "btnPrintGroup"
        Me.btnPrintGroup.Size = New System.Drawing.Size(84, 26)
        Me.btnPrintGroup.TabIndex = 34
        Me.btnPrintGroup.Text = "Print By Group"
        Me.btnPrintGroup.UseVisualStyleBackColor = True
        '
        'frmBC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1030, 575)
        Me.Controls.Add(Me.btnPrintGroup)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cmbBCProcessType)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtBCDtlNetWeight)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtBCDtlGrossWeight)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtBCDtlPackQty)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpBCContractDate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtBCContractNo)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.txtBCNetWeight)
        Me.Controls.Add(Me.txtCurrCode)
        Me.Controls.Add(Me.btnSDelivery)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.txtSDeliveryNo)
        Me.Controls.Add(Me.ntbBCCurrRate)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtSKUUoM)
        Me.Controls.Add(Me.btnAddD)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.ntbBCDtlPrice)
        Me.Controls.Add(Me.ntbSDeliveryQty)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.txtBCDtlDesc)
        Me.Controls.Add(Me.btnCustomer)
        Me.Controls.Add(Me.btnDeleteD)
        Me.Controls.Add(Me.btnSaveD)
        Me.Controls.Add(Me.Label12)
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
        Me.Controls.Add(Me.txtBCSumGrossWeight)
        Me.Controls.Add(Me.txtBCSumPackQty)
        Me.Controls.Add(Me.txtBCTrfPriceTotal)
        Me.Controls.Add(Me.txtBCRemarks)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.txtCCode)
        Me.Controls.Add(Me.txtCName)
        Me.Controls.Add(Me.dtpBCDate)
        Me.Controls.Add(Me.txtBCNo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmBC"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BC 4.0"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBCNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpBCDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCName As System.Windows.Forms.TextBox
    Friend WithEvents txtCCode As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents txtBCRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtBCTrfPriceTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtBCSumPackQty As System.Windows.Forms.TextBox
    Friend WithEvents txtBCSumGrossWeight As System.Windows.Forms.TextBox
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
    Friend WithEvents btnCustomer As System.Windows.Forms.Button
    Friend WithEvents txtBCDtlDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents ntbSDeliveryQty As levate.NumericTextBox
    Friend WithEvents ntbBCDtlPrice As levate.NumericTextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents ntbBCCurrRate As levate.NumericTextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtSDeliveryNo As System.Windows.Forms.TextBox
    Friend WithEvents btnSDelivery As System.Windows.Forms.Button
    Friend WithEvents txtCurrCode As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtBCNetWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBCContractNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpBCContractDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBCDtlPackQty As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBCDtlGrossWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtBCDtlNetWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbBCProcessType As System.Windows.Forms.ComboBox
    Friend WithEvents txtSKUUoM As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents btnPrintGroup As System.Windows.Forms.Button

End Class
