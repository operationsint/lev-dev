<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPReceive
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPReceive))
        Me.txtPReceiveNo = New System.Windows.Forms.TextBox()
        Me.dtpPReceiveDate = New System.Windows.Forms.DateTimePicker()
        Me.txtSName = New System.Windows.Forms.TextBox()
        Me.txtSCode = New System.Windows.Forms.TextBox()
        Me.txtPReceiveRemarks = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnPO = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPONo = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPaymentDueDate = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPODtlDesc = New System.Windows.Forms.TextBox()
        Me.txtSKUCode = New System.Windows.Forms.TextBox()
        Me.btnSKU = New System.Windows.Forms.Button()
        Me.btnAddD = New System.Windows.Forms.Button()
        Me.btnDeleteD = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPreviousQty = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtLocationCode = New System.Windows.Forms.TextBox()
        Me.btnLocation = New System.Windows.Forms.Button()
        Me.txtPODtlType = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPOQty = New System.Windows.Forms.TextBox()
        Me.btnSaveD = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSKUUoM = New System.Windows.Forms.TextBox()
        Me.txtPReceiveStatus = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPRRemainQty = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ntbPReceiveQty = New levate.NumericTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPeriodId = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtPReceiveNo
        '
        Me.txtPReceiveNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPReceiveNo.Location = New System.Drawing.Point(160, 13)
        Me.txtPReceiveNo.MaxLength = 12
        Me.txtPReceiveNo.Name = "txtPReceiveNo"
        Me.txtPReceiveNo.Size = New System.Drawing.Size(127, 21)
        Me.txtPReceiveNo.TabIndex = 0
        '
        'dtpPReceiveDate
        '
        Me.dtpPReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPReceiveDate.Location = New System.Drawing.Point(160, 38)
        Me.dtpPReceiveDate.Name = "dtpPReceiveDate"
        Me.dtpPReceiveDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpPReceiveDate.TabIndex = 1
        '
        'txtSName
        '
        Me.txtSName.Location = New System.Drawing.Point(467, 67)
        Me.txtSName.Name = "txtSName"
        Me.txtSName.ReadOnly = True
        Me.txtSName.Size = New System.Drawing.Size(217, 21)
        Me.txtSName.TabIndex = 7
        '
        'txtSCode
        '
        Me.txtSCode.Location = New System.Drawing.Point(467, 39)
        Me.txtSCode.Name = "txtSCode"
        Me.txtSCode.ReadOnly = True
        Me.txtSCode.Size = New System.Drawing.Size(80, 21)
        Me.txtSCode.TabIndex = 6
        '
        'txtPReceiveRemarks
        '
        Me.txtPReceiveRemarks.Location = New System.Drawing.Point(68, 428)
        Me.txtPReceiveRemarks.MaxLength = 255
        Me.txtPReceiveRemarks.Multiline = True
        Me.txtPReceiveRemarks.Name = "txtPReceiveRemarks"
        Me.txtPReceiveRemarks.Size = New System.Drawing.Size(318, 59)
        Me.txtPReceiveRemarks.TabIndex = 25
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(825, 496)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 26)
        Me.btnCancel.TabIndex = 30
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(557, 496)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(84, 26)
        Me.btnEdit.TabIndex = 27
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(645, 496)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnAdd.TabIndex = 28
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(467, 496)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 26)
        Me.btnDelete.TabIndex = 26
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(735, 496)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 26)
        Me.btnSave.TabIndex = 29
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(359, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Supplier Code"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(142, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Purchase Incoming No.*"
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
        Me.Label12.Location = New System.Drawing.Point(8, 428)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Remarks"
        '
        'btnPO
        '
        Me.btnPO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPO.ImageIndex = 0
        Me.btnPO.ImageList = Me.ImageList1
        Me.btnPO.Location = New System.Drawing.Point(598, 10)
        Me.btnPO.Name = "btnPO"
        Me.btnPO.Size = New System.Drawing.Size(29, 25)
        Me.btnPO.TabIndex = 5
        Me.btnPO.UseVisualStyleBackColor = True
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
        Me.btnPrint.Location = New System.Drawing.Point(915, 496)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 26)
        Me.btnPrint.TabIndex = 31
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(359, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(108, 13)
        Me.Label15.TabIndex = 56
        Me.Label15.Text = "Purchase Order No.*"
        '
        'txtPONo
        '
        Me.txtPONo.Location = New System.Drawing.Point(467, 12)
        Me.txtPONo.Name = "txtPONo"
        Me.txtPONo.ReadOnly = True
        Me.txtPONo.Size = New System.Drawing.Size(127, 21)
        Me.txtPONo.TabIndex = 4
        '
        'ListView1
        '
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 173)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(989, 233)
        Me.ListView1.TabIndex = 24
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(359, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Supplier Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(737, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Payment Due Date"
        '
        'txtPaymentDueDate
        '
        Me.txtPaymentDueDate.Location = New System.Drawing.Point(846, 12)
        Me.txtPaymentDueDate.Name = "txtPaymentDueDate"
        Me.txtPaymentDueDate.ReadOnly = True
        Me.txtPaymentDueDate.Size = New System.Drawing.Size(80, 21)
        Me.txtPaymentDueDate.TabIndex = 8
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(698, 124)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(71, 13)
        Me.Label19.TabIndex = 82
        Me.Label19.Text = "Incoming Qty"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(223, 125)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 81
        Me.Label18.Text = "Line Description"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(102, 125)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 13)
        Me.Label17.TabIndex = 80
        Me.Label17.Text = "Stock Code"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 125)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 13)
        Me.Label16.TabIndex = 79
        Me.Label16.Text = "Line Type"
        '
        'txtPODtlDesc
        '
        Me.txtPODtlDesc.Location = New System.Drawing.Point(224, 142)
        Me.txtPODtlDesc.MaxLength = 100
        Me.txtPODtlDesc.Name = "txtPODtlDesc"
        Me.txtPODtlDesc.ReadOnly = True
        Me.txtPODtlDesc.Size = New System.Drawing.Size(209, 21)
        Me.txtPODtlDesc.TabIndex = 13
        '
        'txtSKUCode
        '
        Me.txtSKUCode.Location = New System.Drawing.Point(105, 142)
        Me.txtSKUCode.MaxLength = 50
        Me.txtSKUCode.Name = "txtSKUCode"
        Me.txtSKUCode.ReadOnly = True
        Me.txtSKUCode.Size = New System.Drawing.Size(80, 21)
        Me.txtSKUCode.TabIndex = 11
        Me.txtSKUCode.TabStop = False
        '
        'btnSKU
        '
        Me.btnSKU.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSKU.ImageIndex = 1
        Me.btnSKU.ImageList = Me.ImageList1
        Me.btnSKU.Location = New System.Drawing.Point(189, 139)
        Me.btnSKU.Name = "btnSKU"
        Me.btnSKU.Size = New System.Drawing.Size(29, 25)
        Me.btnSKU.TabIndex = 12
        Me.btnSKU.UseVisualStyleBackColor = True
        '
        'btnAddD
        '
        Me.btnAddD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD.ImageIndex = 4
        Me.btnAddD.ImageList = Me.ImageList1
        Me.btnAddD.Location = New System.Drawing.Point(970, 140)
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
        Me.btnDeleteD.Location = New System.Drawing.Point(939, 140)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 22
        Me.btnDeleteD.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(622, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 91
        Me.Label4.Text = "Prior Incoming"
        '
        'txtPreviousQty
        '
        Me.txtPreviousQty.Location = New System.Drawing.Point(626, 142)
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
        Me.Label31.Location = New System.Drawing.Point(436, 126)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(53, 13)
        Me.Label31.TabIndex = 98
        Me.Label31.Text = "Location*"
        '
        'txtLocationCode
        '
        Me.txtLocationCode.Location = New System.Drawing.Point(439, 142)
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
        Me.btnLocation.Location = New System.Drawing.Point(523, 139)
        Me.btnLocation.Name = "btnLocation"
        Me.btnLocation.Size = New System.Drawing.Size(29, 25)
        Me.btnLocation.TabIndex = 15
        Me.btnLocation.UseVisualStyleBackColor = True
        '
        'txtPODtlType
        '
        Me.txtPODtlType.Location = New System.Drawing.Point(11, 142)
        Me.txtPODtlType.Name = "txtPODtlType"
        Me.txtPODtlType.ReadOnly = True
        Me.txtPODtlType.Size = New System.Drawing.Size(87, 21)
        Me.txtPODtlType.TabIndex = 10
        Me.txtPODtlType.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(555, 125)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 103
        Me.Label8.Text = "Order Qty"
        '
        'txtPOQty
        '
        Me.txtPOQty.Location = New System.Drawing.Point(555, 142)
        Me.txtPOQty.Name = "txtPOQty"
        Me.txtPOQty.ReadOnly = True
        Me.txtPOQty.Size = New System.Drawing.Size(65, 21)
        Me.txtPOQty.TabIndex = 16
        Me.txtPOQty.TabStop = False
        Me.txtPOQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSaveD
        '
        Me.btnSaveD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveD.ImageIndex = 3
        Me.btnSaveD.ImageList = Me.ImageList1
        Me.btnSaveD.Location = New System.Drawing.Point(908, 140)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 21
        Me.btnSaveD.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(842, 125)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 13)
        Me.Label9.TabIndex = 105
        Me.Label9.Text = "UoM"
        '
        'txtSKUUoM
        '
        Me.txtSKUUoM.Location = New System.Drawing.Point(839, 142)
        Me.txtSKUUoM.Name = "txtSKUUoM"
        Me.txtSKUUoM.ReadOnly = True
        Me.txtSKUUoM.Size = New System.Drawing.Size(65, 21)
        Me.txtSKUUoM.TabIndex = 20
        Me.txtSKUUoM.TabStop = False
        '
        'txtPReceiveStatus
        '
        Me.txtPReceiveStatus.Location = New System.Drawing.Point(846, 67)
        Me.txtPReceiveStatus.Name = "txtPReceiveStatus"
        Me.txtPReceiveStatus.ReadOnly = True
        Me.txtPReceiveStatus.Size = New System.Drawing.Size(153, 21)
        Me.txtPReceiveStatus.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(737, 70)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 118
        Me.Label14.Text = "Status"
        '
        'txtPRRemainQty
        '
        Me.txtPRRemainQty.Location = New System.Drawing.Point(769, 142)
        Me.txtPRRemainQty.Name = "txtPRRemainQty"
        Me.txtPRRemainQty.ReadOnly = True
        Me.txtPRRemainQty.Size = New System.Drawing.Size(65, 21)
        Me.txtPRRemainQty.TabIndex = 19
        Me.txtPRRemainQty.TabStop = False
        Me.txtPRRemainQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(772, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Remaining"
        '
        'ntbPReceiveQty
        '
        Me.ntbPReceiveQty.AllowSpace = False
        Me.ntbPReceiveQty.Location = New System.Drawing.Point(697, 142)
        Me.ntbPReceiveQty.MaxLength = 8
        Me.ntbPReceiveQty.Name = "ntbPReceiveQty"
        Me.ntbPReceiveQty.Size = New System.Drawing.Size(67, 21)
        Me.ntbPReceiveQty.TabIndex = 18
        Me.ntbPReceiveQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 95)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 121
        Me.Label10.Text = "Ref. No."
        '
        'txtRefNo
        '
        Me.txtRefNo.Location = New System.Drawing.Point(160, 92)
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(127, 21)
        Me.txtRefNo.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 67)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 126
        Me.Label11.Text = "Period"
        '
        'txtPeriodId
        '
        Me.txtPeriodId.Location = New System.Drawing.Point(160, 64)
        Me.txtPeriodId.Name = "txtPeriodId"
        Me.txtPeriodId.ReadOnly = True
        Me.txtPeriodId.Size = New System.Drawing.Size(97, 21)
        Me.txtPeriodId.TabIndex = 2
        '
        'frmPReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1011, 534)
        Me.Controls.Add(Me.txtPeriodId)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtRefNo)
        Me.Controls.Add(Me.txtPReceiveStatus)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtSKUUoM)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtPOQty)
        Me.Controls.Add(Me.txtPODtlType)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtLocationCode)
        Me.Controls.Add(Me.btnLocation)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPRRemainQty)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPreviousQty)
        Me.Controls.Add(Me.btnAddD)
        Me.Controls.Add(Me.btnDeleteD)
        Me.Controls.Add(Me.btnSaveD)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.ntbPReceiveQty)
        Me.Controls.Add(Me.txtPODtlDesc)
        Me.Controls.Add(Me.txtSKUCode)
        Me.Controls.Add(Me.btnSKU)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPaymentDueDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtPONo)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnPO)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtPReceiveRemarks)
        Me.Controls.Add(Me.txtSCode)
        Me.Controls.Add(Me.txtSName)
        Me.Controls.Add(Me.dtpPReceiveDate)
        Me.Controls.Add(Me.txtPReceiveNo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPReceive"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Incoming"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPReceiveNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpPReceiveDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSName As System.Windows.Forms.TextBox
    Friend WithEvents txtSCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPReceiveRemarks As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnPO As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPONo As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPaymentDueDate As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ntbPReceiveQty As levate.NumericTextBox
    Friend WithEvents txtPODtlDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtSKUCode As System.Windows.Forms.TextBox
    Friend WithEvents btnSKU As System.Windows.Forms.Button
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents btnDeleteD As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPreviousQty As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtLocationCode As System.Windows.Forms.TextBox
    Friend WithEvents btnLocation As System.Windows.Forms.Button
    Friend WithEvents txtPODtlType As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPOQty As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveD As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSKUUoM As System.Windows.Forms.TextBox
    Friend WithEvents txtPReceiveStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtPRRemainQty As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodId As System.Windows.Forms.TextBox

End Class
