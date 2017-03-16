<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSDelivery
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSDelivery))
        Me.txtSDeliveryNo = New System.Windows.Forms.TextBox()
        Me.dtpSDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.txtCName = New System.Windows.Forms.TextBox()
        Me.txtCCode = New System.Windows.Forms.TextBox()
        Me.txtSDeliveryRemarks = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSO = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtSONo = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPaymentDueDate = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSODtlDesc = New System.Windows.Forms.TextBox()
        Me.txtSKUCode = New System.Windows.Forms.TextBox()
        Me.btnAddD = New System.Windows.Forms.Button()
        Me.btnDeleteD = New System.Windows.Forms.Button()
        Me.btnSaveD = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSOQty = New System.Windows.Forms.TextBox()
        Me.txtSODtlType = New System.Windows.Forms.TextBox()
        Me.btnSKU = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPreviousQty = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtLocationCode = New System.Windows.Forms.TextBox()
        Me.btnLocation = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSKUUoM = New System.Windows.Forms.TextBox()
        Me.txtSDeliveryStatus = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRemainQty = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtVehicleNumber = New System.Windows.Forms.TextBox()
        Me.ntbSDeliveryQty = New levate.NumericTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPeriodId = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtSDeliveryNo
        '
        Me.txtSDeliveryNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSDeliveryNo.Location = New System.Drawing.Point(143, 12)
        Me.txtSDeliveryNo.MaxLength = 50
        Me.txtSDeliveryNo.Name = "txtSDeliveryNo"
        Me.txtSDeliveryNo.Size = New System.Drawing.Size(127, 21)
        Me.txtSDeliveryNo.TabIndex = 0
        '
        'dtpSDeliveryDate
        '
        Me.dtpSDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSDeliveryDate.Location = New System.Drawing.Point(143, 39)
        Me.dtpSDeliveryDate.Name = "dtpSDeliveryDate"
        Me.dtpSDeliveryDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpSDeliveryDate.TabIndex = 1
        '
        'txtCName
        '
        Me.txtCName.Location = New System.Drawing.Point(462, 67)
        Me.txtCName.Name = "txtCName"
        Me.txtCName.ReadOnly = True
        Me.txtCName.Size = New System.Drawing.Size(217, 21)
        Me.txtCName.TabIndex = 6
        '
        'txtCCode
        '
        Me.txtCCode.Location = New System.Drawing.Point(462, 40)
        Me.txtCCode.Name = "txtCCode"
        Me.txtCCode.ReadOnly = True
        Me.txtCCode.Size = New System.Drawing.Size(80, 21)
        Me.txtCCode.TabIndex = 5
        '
        'txtSDeliveryRemarks
        '
        Me.txtSDeliveryRemarks.Location = New System.Drawing.Point(72, 413)
        Me.txtSDeliveryRemarks.MaxLength = 255
        Me.txtSDeliveryRemarks.Multiline = True
        Me.txtSDeliveryRemarks.Name = "txtSDeliveryRemarks"
        Me.txtSDeliveryRemarks.Size = New System.Drawing.Size(318, 59)
        Me.txtSDeliveryRemarks.TabIndex = 25
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(835, 487)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 26)
        Me.btnCancel.TabIndex = 30
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(567, 487)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(84, 26)
        Me.btnEdit.TabIndex = 27
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(655, 487)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnAdd.TabIndex = 28
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(477, 487)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 26)
        Me.btnDelete.TabIndex = 26
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(745, 487)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 26)
        Me.btnSave.TabIndex = 29
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(355, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Customer Code"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(117, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Sales Delivery No. *"
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
        Me.Label12.Location = New System.Drawing.Point(12, 413)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Remarks"
        '
        'btnSO
        '
        Me.btnSO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSO.ImageIndex = 0
        Me.btnSO.ImageList = Me.ImageList1
        Me.btnSO.Location = New System.Drawing.Point(593, 9)
        Me.btnSO.Name = "btnSO"
        Me.btnSO.Size = New System.Drawing.Size(29, 25)
        Me.btnSO.TabIndex = 4
        Me.btnSO.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Search.png")
        Me.ImageList1.Images.SetKeyName(1, "Box.png")
        Me.ImageList1.Images.SetKeyName(2, "Remove.png")
        Me.ImageList1.Images.SetKeyName(3, "Checkmark.png")
        Me.ImageList1.Images.SetKeyName(4, "add.png")
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(930, 487)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 26)
        Me.btnPrint.TabIndex = 31
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(355, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(92, 13)
        Me.Label15.TabIndex = 56
        Me.Label15.Text = "Sales Order No. *"
        '
        'txtSONo
        '
        Me.txtSONo.Location = New System.Drawing.Point(462, 12)
        Me.txtSONo.Name = "txtSONo"
        Me.txtSONo.ReadOnly = True
        Me.txtSONo.Size = New System.Drawing.Size(127, 21)
        Me.txtSONo.TabIndex = 3
        '
        'ListView1
        '
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 162)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(993, 233)
        Me.ListView1.TabIndex = 24
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(355, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Customer Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(742, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Payment Due Date"
        '
        'txtPaymentDueDate
        '
        Me.txtPaymentDueDate.Location = New System.Drawing.Point(851, 12)
        Me.txtPaymentDueDate.Name = "txtPaymentDueDate"
        Me.txtPaymentDueDate.ReadOnly = True
        Me.txtPaymentDueDate.Size = New System.Drawing.Size(80, 21)
        Me.txtPaymentDueDate.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(695, 118)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 82
        Me.Label19.Text = "Delivery Qty"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(221, 118)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 81
        Me.Label18.Text = "Line Description"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(104, 118)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 80
        Me.Label17.Text = "Stock Code *"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 118)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 13)
        Me.Label16.TabIndex = 79
        Me.Label16.Text = "Line Type"
        '
        'txtSODtlDesc
        '
        Me.txtSODtlDesc.Location = New System.Drawing.Point(224, 134)
        Me.txtSODtlDesc.MaxLength = 100
        Me.txtSODtlDesc.Name = "txtSODtlDesc"
        Me.txtSODtlDesc.ReadOnly = True
        Me.txtSODtlDesc.Size = New System.Drawing.Size(209, 21)
        Me.txtSODtlDesc.TabIndex = 13
        '
        'txtSKUCode
        '
        Me.txtSKUCode.Location = New System.Drawing.Point(105, 133)
        Me.txtSKUCode.MaxLength = 50
        Me.txtSKUCode.Name = "txtSKUCode"
        Me.txtSKUCode.ReadOnly = True
        Me.txtSKUCode.Size = New System.Drawing.Size(80, 21)
        Me.txtSKUCode.TabIndex = 11
        Me.txtSKUCode.TabStop = False
        '
        'btnAddD
        '
        Me.btnAddD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD.ImageIndex = 4
        Me.btnAddD.ImageList = Me.ImageList1
        Me.btnAddD.Location = New System.Drawing.Point(976, 131)
        Me.btnAddD.Name = "btnAddD"
        Me.btnAddD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD.TabIndex = 23
        Me.btnAddD.UseVisualStyleBackColor = True
        '
        'btnDeleteD
        '
        Me.btnDeleteD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteD.ImageIndex = 2
        Me.btnDeleteD.ImageList = Me.ImageList1
        Me.btnDeleteD.Location = New System.Drawing.Point(945, 131)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 22
        Me.btnDeleteD.UseVisualStyleBackColor = True
        '
        'btnSaveD
        '
        Me.btnSaveD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveD.ImageIndex = 3
        Me.btnSaveD.ImageList = Me.ImageList1
        Me.btnSaveD.Location = New System.Drawing.Point(914, 131)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 21
        Me.btnSaveD.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(558, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 91
        Me.Label4.Text = "Order Qty"
        '
        'txtSOQty
        '
        Me.txtSOQty.Location = New System.Drawing.Point(558, 133)
        Me.txtSOQty.Name = "txtSOQty"
        Me.txtSOQty.ReadOnly = True
        Me.txtSOQty.Size = New System.Drawing.Size(65, 21)
        Me.txtSOQty.TabIndex = 16
        Me.txtSOQty.TabStop = False
        Me.txtSOQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSODtlType
        '
        Me.txtSODtlType.Location = New System.Drawing.Point(12, 133)
        Me.txtSODtlType.Name = "txtSODtlType"
        Me.txtSODtlType.ReadOnly = True
        Me.txtSODtlType.Size = New System.Drawing.Size(87, 21)
        Me.txtSODtlType.TabIndex = 10
        Me.txtSODtlType.TabStop = False
        '
        'btnSKU
        '
        Me.btnSKU.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSKU.ImageIndex = 1
        Me.btnSKU.ImageList = Me.ImageList1
        Me.btnSKU.Location = New System.Drawing.Point(189, 131)
        Me.btnSKU.Name = "btnSKU"
        Me.btnSKU.Size = New System.Drawing.Size(29, 25)
        Me.btnSKU.TabIndex = 12
        Me.btnSKU.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(624, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 105
        Me.Label8.Text = "Prior Delivery"
        '
        'txtPreviousQty
        '
        Me.txtPreviousQty.Location = New System.Drawing.Point(629, 133)
        Me.txtPreviousQty.Name = "txtPreviousQty"
        Me.txtPreviousQty.ReadOnly = True
        Me.txtPreviousQty.Size = New System.Drawing.Size(65, 21)
        Me.txtPreviousQty.TabIndex = 17
        Me.txtPreviousQty.TabStop = False
        Me.txtPreviousQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(436, 118)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(56, 13)
        Me.Label31.TabIndex = 108
        Me.Label31.Text = "Location *"
        '
        'txtLocationCode
        '
        Me.txtLocationCode.Location = New System.Drawing.Point(439, 134)
        Me.txtLocationCode.Name = "txtLocationCode"
        Me.txtLocationCode.ReadOnly = True
        Me.txtLocationCode.Size = New System.Drawing.Size(80, 21)
        Me.txtLocationCode.TabIndex = 14
        Me.txtLocationCode.TabStop = False
        '
        'btnLocation
        '
        Me.btnLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLocation.ImageIndex = 1
        Me.btnLocation.ImageList = Me.ImageList1
        Me.btnLocation.Location = New System.Drawing.Point(523, 131)
        Me.btnLocation.Name = "btnLocation"
        Me.btnLocation.Size = New System.Drawing.Size(29, 25)
        Me.btnLocation.TabIndex = 15
        Me.btnLocation.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(846, 118)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 110
        Me.Label9.Text = "UoM"
        '
        'txtSKUUoM
        '
        Me.txtSKUUoM.Location = New System.Drawing.Point(843, 133)
        Me.txtSKUUoM.Name = "txtSKUUoM"
        Me.txtSKUUoM.ReadOnly = True
        Me.txtSKUUoM.Size = New System.Drawing.Size(65, 21)
        Me.txtSKUUoM.TabIndex = 20
        Me.txtSKUUoM.TabStop = False
        '
        'txtSDeliveryStatus
        '
        Me.txtSDeliveryStatus.Location = New System.Drawing.Point(851, 67)
        Me.txtSDeliveryStatus.Name = "txtSDeliveryStatus"
        Me.txtSDeliveryStatus.ReadOnly = True
        Me.txtSDeliveryStatus.Size = New System.Drawing.Size(153, 21)
        Me.txtSDeliveryStatus.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(757, 70)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 120
        Me.Label14.Text = "Status"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(771, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 123
        Me.Label5.Text = "Remaining"
        '
        'txtRemainQty
        '
        Me.txtRemainQty.Location = New System.Drawing.Point(772, 133)
        Me.txtRemainQty.Name = "txtRemainQty"
        Me.txtRemainQty.ReadOnly = True
        Me.txtRemainQty.Size = New System.Drawing.Size(65, 21)
        Me.txtRemainQty.TabIndex = 19
        Me.txtRemainQty.TabStop = False
        Me.txtRemainQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(757, 46)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 13)
        Me.Label10.TabIndex = 124
        Me.Label10.Text = "Vehicle Number"
        '
        'txtVehicleNumber
        '
        Me.txtVehicleNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVehicleNumber.Location = New System.Drawing.Point(851, 40)
        Me.txtVehicleNumber.MaxLength = 50
        Me.txtVehicleNumber.Name = "txtVehicleNumber"
        Me.txtVehicleNumber.Size = New System.Drawing.Size(153, 21)
        Me.txtVehicleNumber.TabIndex = 8
        '
        'ntbSDeliveryQty
        '
        Me.ntbSDeliveryQty.AllowSpace = False
        Me.ntbSDeliveryQty.Location = New System.Drawing.Point(699, 133)
        Me.ntbSDeliveryQty.MaxLength = 8
        Me.ntbSDeliveryQty.Name = "ntbSDeliveryQty"
        Me.ntbSDeliveryQty.Size = New System.Drawing.Size(67, 21)
        Me.ntbSDeliveryQty.TabIndex = 18
        Me.ntbSDeliveryQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 70)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 128
        Me.Label11.Text = "Period"
        '
        'txtPeriodId
        '
        Me.txtPeriodId.Location = New System.Drawing.Point(143, 67)
        Me.txtPeriodId.Name = "txtPeriodId"
        Me.txtPeriodId.ReadOnly = True
        Me.txtPeriodId.Size = New System.Drawing.Size(97, 21)
        Me.txtPeriodId.TabIndex = 2
        '
        'frmSDelivery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1021, 526)
        Me.Controls.Add(Me.txtPeriodId)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtVehicleNumber)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtRemainQty)
        Me.Controls.Add(Me.txtSDeliveryStatus)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtSKUUoM)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtLocationCode)
        Me.Controls.Add(Me.btnLocation)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPreviousQty)
        Me.Controls.Add(Me.btnSKU)
        Me.Controls.Add(Me.txtSODtlType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSOQty)
        Me.Controls.Add(Me.btnAddD)
        Me.Controls.Add(Me.btnDeleteD)
        Me.Controls.Add(Me.btnSaveD)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.ntbSDeliveryQty)
        Me.Controls.Add(Me.txtSODtlDesc)
        Me.Controls.Add(Me.txtSKUCode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPaymentDueDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtSONo)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnSO)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtSDeliveryRemarks)
        Me.Controls.Add(Me.txtCCode)
        Me.Controls.Add(Me.txtCName)
        Me.Controls.Add(Me.dtpSDeliveryDate)
        Me.Controls.Add(Me.txtSDeliveryNo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSDelivery"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Delivery"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSDeliveryNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpSDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCName As System.Windows.Forms.TextBox
    Friend WithEvents txtCCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSDeliveryRemarks As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnSO As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSONo As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentDueDate As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ntbSDeliveryQty As levate.NumericTextBox
    Friend WithEvents txtSODtlDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtSKUCode As System.Windows.Forms.TextBox
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents btnDeleteD As System.Windows.Forms.Button
    Friend WithEvents btnSaveD As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSOQty As System.Windows.Forms.TextBox
    Friend WithEvents txtSODtlType As System.Windows.Forms.TextBox
    Friend WithEvents btnSKU As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPreviousQty As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtLocationCode As System.Windows.Forms.TextBox
    Friend WithEvents btnLocation As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSKUUoM As System.Windows.Forms.TextBox
    Friend WithEvents txtSDeliveryStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtRemainQty As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtVehicleNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodId As System.Windows.Forms.TextBox

End Class
