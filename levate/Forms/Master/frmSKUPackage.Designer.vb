<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSKUPackage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSKUPackage))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmbSKUCatID = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSKUUoM = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSKUBarcode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSKUName1 = New System.Windows.Forms.TextBox()
        Me.txtSKUCode1 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSKUInfo3 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSKUInfo2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSKUInfo1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSKURemarks = New System.Windows.Forms.TextBox()
        Me.btnSKU1 = New System.Windows.Forms.Button()
        Me.ntbSalesPrice = New levate.NumericTextBox()
        Me.ntbSalesDiscPercent = New levate.NumericTextBox()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabMaterial = New System.Windows.Forms.TabPage()
        Me.ntbSKUPackageQty = New levate.NumericTextBox()
        Me.btnAddD = New System.Windows.Forms.Button()
        Me.txtSKUName2 = New System.Windows.Forms.TextBox()
        Me.txtSKUCode2 = New System.Windows.Forms.TextBox()
        Me.btnSKU = New System.Windows.Forms.Button()
        Me.btnDeleteD = New System.Windows.Forms.Button()
        Me.btnSaveD = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tabLabour = New System.Windows.Forms.TabPage()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.ntbProcessCost = New levate.NumericTextBox()
        Me.btnLabour = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtLabourName = New System.Windows.Forms.TextBox()
        Me.txtLabourCode = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnAddProcessD = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtProcessName = New System.Windows.Forms.TextBox()
        Me.txtProcessCode = New System.Windows.Forms.TextBox()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.btnDeleteProcessD = New System.Windows.Forms.Button()
        Me.btnSaveProcessD = New System.Windows.Forms.Button()
        Me.ntbProcessQty = New levate.NumericTextBox()
        Me.lsvProcess = New System.Windows.Forms.ListView()
        Me.sCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chbFinishGoods = New System.Windows.Forms.CheckBox()
        Me.tabMain.SuspendLayout()
        Me.tabMaterial.SuspendLayout()
        Me.tabLabour.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(398, 598)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 26)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(128, 598)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(84, 26)
        Me.btnEdit.TabIndex = 19
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(218, 598)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnAdd.TabIndex = 20
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(38, 598)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 26)
        Me.btnDelete.TabIndex = 18
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(308, 598)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 26)
        Me.btnSave.TabIndex = 21
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
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
        'cmbSKUCatID
        '
        Me.cmbSKUCatID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSKUCatID.FormattingEnabled = True
        Me.cmbSKUCatID.Location = New System.Drawing.Point(142, 64)
        Me.cmbSKUCatID.Name = "cmbSKUCatID"
        Me.cmbSKUCatID.Size = New System.Drawing.Size(148, 21)
        Me.cmbSKUCatID.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(14, 67)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 13)
        Me.Label15.TabIndex = 116
        Me.Label15.Text = "Stock Set Category *"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(554, 130)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 13)
        Me.Label10.TabIndex = 115
        Me.Label10.Text = "Sales Discount %"
        Me.Label10.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(554, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 13)
        Me.Label8.TabIndex = 114
        Me.Label8.Text = "Unit of Measurement"
        Me.Label8.Visible = False
        '
        'txtSKUUoM
        '
        Me.txtSKUUoM.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUUoM.Location = New System.Drawing.Point(683, 103)
        Me.txtSKUUoM.MaxLength = 50
        Me.txtSKUUoM.Name = "txtSKUUoM"
        Me.txtSKUUoM.Size = New System.Drawing.Size(131, 21)
        Me.txtSKUUoM.TabIndex = 5
        Me.txtSKUUoM.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(346, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 113
        Me.Label7.Text = "Barcode"
        Me.Label7.Visible = False
        '
        'txtSKUBarcode
        '
        Me.txtSKUBarcode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUBarcode.Location = New System.Drawing.Point(398, 67)
        Me.txtSKUBarcode.MaxLength = 50
        Me.txtSKUBarcode.Name = "txtSKUBarcode"
        Me.txtSKUBarcode.Size = New System.Drawing.Size(259, 21)
        Me.txtSKUBarcode.TabIndex = 4
        Me.txtSKUBarcode.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(554, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Sales Price"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "Stock Set Name *"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 13)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "Stock Set Code *"
        '
        'txtSKUName1
        '
        Me.txtSKUName1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUName1.Location = New System.Drawing.Point(142, 37)
        Me.txtSKUName1.MaxLength = 50
        Me.txtSKUName1.Name = "txtSKUName1"
        Me.txtSKUName1.Size = New System.Drawing.Size(259, 21)
        Me.txtSKUName1.TabIndex = 2
        '
        'txtSKUCode1
        '
        Me.txtSKUCode1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUCode1.Location = New System.Drawing.Point(142, 10)
        Me.txtSKUCode1.MaxLength = 10
        Me.txtSKUCode1.Name = "txtSKUCode1"
        Me.txtSKUCode1.Size = New System.Drawing.Size(100, 21)
        Me.txtSKUCode1.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(15, 566)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 124
        Me.Label13.Text = "Other Info 3"
        '
        'txtSKUInfo3
        '
        Me.txtSKUInfo3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUInfo3.Location = New System.Drawing.Point(143, 566)
        Me.txtSKUInfo3.MaxLength = 50
        Me.txtSKUInfo3.Name = "txtSKUInfo3"
        Me.txtSKUInfo3.Size = New System.Drawing.Size(260, 21)
        Me.txtSKUInfo3.TabIndex = 17
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(15, 539)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 13)
        Me.Label12.TabIndex = 123
        Me.Label12.Text = "Other Info 2"
        '
        'txtSKUInfo2
        '
        Me.txtSKUInfo2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUInfo2.Location = New System.Drawing.Point(143, 539)
        Me.txtSKUInfo2.MaxLength = 50
        Me.txtSKUInfo2.Name = "txtSKUInfo2"
        Me.txtSKUInfo2.Size = New System.Drawing.Size(260, 21)
        Me.txtSKUInfo2.TabIndex = 16
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(15, 515)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 122
        Me.Label11.Text = "Other Info 1"
        '
        'txtSKUInfo1
        '
        Me.txtSKUInfo1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUInfo1.Location = New System.Drawing.Point(143, 512)
        Me.txtSKUInfo1.MaxLength = 50
        Me.txtSKUInfo1.Name = "txtSKUInfo1"
        Me.txtSKUInfo1.Size = New System.Drawing.Size(260, 21)
        Me.txtSKUInfo1.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 485)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 121
        Me.Label9.Text = "Remarks"
        '
        'txtSKURemarks
        '
        Me.txtSKURemarks.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKURemarks.Location = New System.Drawing.Point(142, 485)
        Me.txtSKURemarks.MaxLength = 50
        Me.txtSKURemarks.Name = "txtSKURemarks"
        Me.txtSKURemarks.Size = New System.Drawing.Size(260, 21)
        Me.txtSKURemarks.TabIndex = 14
        '
        'btnSKU1
        '
        Me.btnSKU1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSKU1.ImageIndex = 0
        Me.btnSKU1.Location = New System.Drawing.Point(246, 8)
        Me.btnSKU1.Name = "btnSKU1"
        Me.btnSKU1.Size = New System.Drawing.Size(29, 25)
        Me.btnSKU1.TabIndex = 1
        Me.btnSKU1.Text = "..."
        Me.btnSKU1.UseVisualStyleBackColor = True
        Me.btnSKU1.Visible = False
        '
        'ntbSalesPrice
        '
        Me.ntbSalesPrice.AllowSpace = False
        Me.ntbSalesPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ntbSalesPrice.Location = New System.Drawing.Point(683, 157)
        Me.ntbSalesPrice.Name = "ntbSalesPrice"
        Me.ntbSalesPrice.Size = New System.Drawing.Size(131, 21)
        Me.ntbSalesPrice.TabIndex = 7
        Me.ntbSalesPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ntbSalesPrice.Visible = False
        '
        'ntbSalesDiscPercent
        '
        Me.ntbSalesDiscPercent.AllowSpace = False
        Me.ntbSalesDiscPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ntbSalesDiscPercent.Location = New System.Drawing.Point(683, 130)
        Me.ntbSalesDiscPercent.MaxLength = 3
        Me.ntbSalesDiscPercent.Name = "ntbSalesDiscPercent"
        Me.ntbSalesDiscPercent.Size = New System.Drawing.Size(131, 21)
        Me.ntbSalesDiscPercent.TabIndex = 6
        Me.ntbSalesDiscPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ntbSalesDiscPercent.Visible = False
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tabMaterial)
        Me.tabMain.Controls.Add(Me.tabLabour)
        Me.tabMain.Location = New System.Drawing.Point(16, 130)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(645, 339)
        Me.tabMain.TabIndex = 129
        '
        'tabMaterial
        '
        Me.tabMaterial.BackColor = System.Drawing.SystemColors.Control
        Me.tabMaterial.Controls.Add(Me.ntbSKUPackageQty)
        Me.tabMaterial.Controls.Add(Me.btnAddD)
        Me.tabMaterial.Controls.Add(Me.txtSKUName2)
        Me.tabMaterial.Controls.Add(Me.txtSKUCode2)
        Me.tabMaterial.Controls.Add(Me.btnSKU)
        Me.tabMaterial.Controls.Add(Me.btnDeleteD)
        Me.tabMaterial.Controls.Add(Me.btnSaveD)
        Me.tabMaterial.Controls.Add(Me.ListView1)
        Me.tabMaterial.Controls.Add(Me.Label3)
        Me.tabMaterial.Controls.Add(Me.Label4)
        Me.tabMaterial.Controls.Add(Me.Label5)
        Me.tabMaterial.Location = New System.Drawing.Point(4, 22)
        Me.tabMaterial.Name = "tabMaterial"
        Me.tabMaterial.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMaterial.Size = New System.Drawing.Size(637, 313)
        Me.tabMaterial.TabIndex = 0
        Me.tabMaterial.Text = "Material"
        '
        'ntbSKUPackageQty
        '
        Me.ntbSKUPackageQty.AllowSpace = False
        Me.ntbSKUPackageQty.Location = New System.Drawing.Point(345, 29)
        Me.ntbSKUPackageQty.MaxLength = 5
        Me.ntbSKUPackageQty.Name = "ntbSKUPackageQty"
        Me.ntbSKUPackageQty.Size = New System.Drawing.Size(40, 21)
        Me.ntbSKUPackageQty.TabIndex = 140
        Me.ntbSKUPackageQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAddD
        '
        Me.btnAddD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD.ImageIndex = 4
        Me.btnAddD.ImageList = Me.ImageList1
        Me.btnAddD.Location = New System.Drawing.Point(600, 26)
        Me.btnAddD.Name = "btnAddD"
        Me.btnAddD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD.TabIndex = 143
        Me.btnAddD.UseVisualStyleBackColor = True
        '
        'txtSKUName2
        '
        Me.txtSKUName2.Location = New System.Drawing.Point(130, 29)
        Me.txtSKUName2.MaxLength = 50
        Me.txtSKUName2.Name = "txtSKUName2"
        Me.txtSKUName2.ReadOnly = True
        Me.txtSKUName2.Size = New System.Drawing.Size(209, 21)
        Me.txtSKUName2.TabIndex = 144
        '
        'txtSKUCode2
        '
        Me.txtSKUCode2.Location = New System.Drawing.Point(13, 29)
        Me.txtSKUCode2.Name = "txtSKUCode2"
        Me.txtSKUCode2.ReadOnly = True
        Me.txtSKUCode2.Size = New System.Drawing.Size(80, 21)
        Me.txtSKUCode2.TabIndex = 146
        Me.txtSKUCode2.TabStop = False
        '
        'btnSKU
        '
        Me.btnSKU.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSKU.ImageIndex = 1
        Me.btnSKU.ImageList = Me.ImageList1
        Me.btnSKU.Location = New System.Drawing.Point(95, 27)
        Me.btnSKU.Name = "btnSKU"
        Me.btnSKU.Size = New System.Drawing.Size(29, 25)
        Me.btnSKU.TabIndex = 139
        Me.btnSKU.UseVisualStyleBackColor = True
        '
        'btnDeleteD
        '
        Me.btnDeleteD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteD.ImageIndex = 2
        Me.btnDeleteD.ImageList = Me.ImageList1
        Me.btnDeleteD.Location = New System.Drawing.Point(569, 26)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 142
        Me.btnDeleteD.UseVisualStyleBackColor = True
        '
        'btnSaveD
        '
        Me.btnSaveD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveD.ImageIndex = 3
        Me.btnSaveD.ImageList = Me.ImageList1
        Me.btnSaveD.Location = New System.Drawing.Point(538, 26)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 141
        Me.btnSaveD.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 56)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(619, 251)
        Me.ListView1.TabIndex = 145
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(357, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 138
        Me.Label3.Text = "Qty."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(135, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 137
        Me.Label4.Text = "Stock Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "Stock Code *"
        '
        'tabLabour
        '
        Me.tabLabour.BackColor = System.Drawing.SystemColors.Control
        Me.tabLabour.Controls.Add(Me.Label39)
        Me.tabLabour.Controls.Add(Me.ntbProcessCost)
        Me.tabLabour.Controls.Add(Me.btnLabour)
        Me.tabLabour.Controls.Add(Me.Label27)
        Me.tabLabour.Controls.Add(Me.Label28)
        Me.tabLabour.Controls.Add(Me.txtLabourName)
        Me.tabLabour.Controls.Add(Me.txtLabourCode)
        Me.tabLabour.Controls.Add(Me.Label14)
        Me.tabLabour.Controls.Add(Me.btnAddProcessD)
        Me.tabLabour.Controls.Add(Me.Label16)
        Me.tabLabour.Controls.Add(Me.Label19)
        Me.tabLabour.Controls.Add(Me.txtProcessName)
        Me.tabLabour.Controls.Add(Me.txtProcessCode)
        Me.tabLabour.Controls.Add(Me.btnProcess)
        Me.tabLabour.Controls.Add(Me.btnDeleteProcessD)
        Me.tabLabour.Controls.Add(Me.btnSaveProcessD)
        Me.tabLabour.Controls.Add(Me.ntbProcessQty)
        Me.tabLabour.Controls.Add(Me.lsvProcess)
        Me.tabLabour.Location = New System.Drawing.Point(4, 22)
        Me.tabLabour.Name = "tabLabour"
        Me.tabLabour.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLabour.Size = New System.Drawing.Size(637, 313)
        Me.tabLabour.TabIndex = 1
        Me.tabLabour.Text = "Process"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(291, 14)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(51, 13)
        Me.Label39.TabIndex = 208
        Me.Label39.Text = "Unit Cost"
        '
        'ntbProcessCost
        '
        Me.ntbProcessCost.AllowSpace = False
        Me.ntbProcessCost.Location = New System.Drawing.Point(288, 30)
        Me.ntbProcessCost.MaxLength = 8
        Me.ntbProcessCost.Name = "ntbProcessCost"
        Me.ntbProcessCost.Size = New System.Drawing.Size(100, 21)
        Me.ntbProcessCost.TabIndex = 207
        Me.ntbProcessCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnLabour
        '
        Me.btnLabour.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLabour.ImageIndex = 1
        Me.btnLabour.ImageList = Me.ImageList1
        Me.btnLabour.Location = New System.Drawing.Point(507, 28)
        Me.btnLabour.Name = "btnLabour"
        Me.btnLabour.Size = New System.Drawing.Size(29, 25)
        Me.btnLabour.TabIndex = 203
        Me.btnLabour.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(392, 14)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(70, 13)
        Me.Label27.TabIndex = 206
        Me.Label27.Text = "Labour Name"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(534, 6)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(77, 13)
        Me.Label28.TabIndex = 205
        Me.Label28.Text = "Labour Code *"
        Me.Label28.Visible = False
        '
        'txtLabourName
        '
        Me.txtLabourName.Location = New System.Drawing.Point(390, 30)
        Me.txtLabourName.MaxLength = 100
        Me.txtLabourName.Name = "txtLabourName"
        Me.txtLabourName.ReadOnly = True
        Me.txtLabourName.Size = New System.Drawing.Size(116, 21)
        Me.txtLabourName.TabIndex = 204
        '
        'txtLabourCode
        '
        Me.txtLabourCode.Location = New System.Drawing.Point(529, 3)
        Me.txtLabourCode.MaxLength = 50
        Me.txtLabourCode.Name = "txtLabourCode"
        Me.txtLabourCode.ReadOnly = True
        Me.txtLabourCode.Size = New System.Drawing.Size(54, 21)
        Me.txtLabourCode.TabIndex = 202
        Me.txtLabourCode.TabStop = False
        Me.txtLabourCode.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(253, 13)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 13)
        Me.Label14.TabIndex = 149
        Me.Label14.Text = "Qty."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnAddProcessD
        '
        Me.btnAddProcessD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddProcessD.ImageIndex = 4
        Me.btnAddProcessD.ImageList = Me.ImageList1
        Me.btnAddProcessD.Location = New System.Drawing.Point(599, 27)
        Me.btnAddProcessD.Name = "btnAddProcessD"
        Me.btnAddProcessD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddProcessD.TabIndex = 143
        Me.btnAddProcessD.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(114, 13)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 13)
        Me.Label16.TabIndex = 148
        Me.Label16.Text = "Process Name"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(14, 14)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(81, 13)
        Me.Label19.TabIndex = 147
        Me.Label19.Text = "Process Code *"
        '
        'txtProcessName
        '
        Me.txtProcessName.Location = New System.Drawing.Point(114, 30)
        Me.txtProcessName.MaxLength = 50
        Me.txtProcessName.Name = "txtProcessName"
        Me.txtProcessName.ReadOnly = True
        Me.txtProcessName.Size = New System.Drawing.Size(131, 21)
        Me.txtProcessName.TabIndex = 145
        '
        'txtProcessCode
        '
        Me.txtProcessCode.Location = New System.Drawing.Point(13, 30)
        Me.txtProcessCode.Name = "txtProcessCode"
        Me.txtProcessCode.ReadOnly = True
        Me.txtProcessCode.Size = New System.Drawing.Size(69, 21)
        Me.txtProcessCode.TabIndex = 146
        Me.txtProcessCode.TabStop = False
        '
        'btnProcess
        '
        Me.btnProcess.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcess.ImageIndex = 1
        Me.btnProcess.ImageList = Me.ImageList1
        Me.btnProcess.Location = New System.Drawing.Point(83, 28)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(29, 25)
        Me.btnProcess.TabIndex = 139
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'btnDeleteProcessD
        '
        Me.btnDeleteProcessD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteProcessD.ImageIndex = 2
        Me.btnDeleteProcessD.ImageList = Me.ImageList1
        Me.btnDeleteProcessD.Location = New System.Drawing.Point(568, 27)
        Me.btnDeleteProcessD.Name = "btnDeleteProcessD"
        Me.btnDeleteProcessD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteProcessD.TabIndex = 142
        Me.btnDeleteProcessD.UseVisualStyleBackColor = True
        '
        'btnSaveProcessD
        '
        Me.btnSaveProcessD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveProcessD.ImageIndex = 3
        Me.btnSaveProcessD.ImageList = Me.ImageList1
        Me.btnSaveProcessD.Location = New System.Drawing.Point(537, 27)
        Me.btnSaveProcessD.Name = "btnSaveProcessD"
        Me.btnSaveProcessD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveProcessD.TabIndex = 141
        Me.btnSaveProcessD.UseVisualStyleBackColor = True
        '
        'ntbProcessQty
        '
        Me.ntbProcessQty.AllowSpace = False
        Me.ntbProcessQty.Location = New System.Drawing.Point(248, 30)
        Me.ntbProcessQty.MaxLength = 5
        Me.ntbProcessQty.Name = "ntbProcessQty"
        Me.ntbProcessQty.Size = New System.Drawing.Size(37, 21)
        Me.ntbProcessQty.TabIndex = 140
        Me.ntbProcessQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lsvProcess
        '
        Me.lsvProcess.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.sCode})
        Me.lsvProcess.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvProcess.FullRowSelect = True
        Me.lsvProcess.GridLines = True
        Me.lsvProcess.Location = New System.Drawing.Point(12, 57)
        Me.lsvProcess.MultiSelect = False
        Me.lsvProcess.Name = "lsvProcess"
        Me.lsvProcess.Size = New System.Drawing.Size(619, 250)
        Me.lsvProcess.TabIndex = 144
        Me.lsvProcess.TabStop = False
        Me.lsvProcess.UseCompatibleStateImageBehavior = False
        Me.lsvProcess.View = System.Windows.Forms.View.List
        '
        'sCode
        '
        Me.sCode.Text = "Code"
        '
        'chbFinishGoods
        '
        Me.chbFinishGoods.AutoSize = True
        Me.chbFinishGoods.Location = New System.Drawing.Point(143, 91)
        Me.chbFinishGoods.Name = "chbFinishGoods"
        Me.chbFinishGoods.Size = New System.Drawing.Size(86, 17)
        Me.chbFinishGoods.TabIndex = 130
        Me.chbFinishGoods.Text = "Finish Goods"
        Me.chbFinishGoods.UseVisualStyleBackColor = True
        '
        'frmSKUPackage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 627)
        Me.Controls.Add(Me.chbFinishGoods)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.btnSKU1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtSKUInfo3)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtSKUInfo2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtSKUInfo1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtSKURemarks)
        Me.Controls.Add(Me.ntbSalesPrice)
        Me.Controls.Add(Me.ntbSalesDiscPercent)
        Me.Controls.Add(Me.cmbSKUCatID)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtSKUUoM)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSKUBarcode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSKUName1)
        Me.Controls.Add(Me.txtSKUCode1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSKUPackage"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Set Formula"
        Me.tabMain.ResumeLayout(False)
        Me.tabMaterial.ResumeLayout(False)
        Me.tabMaterial.PerformLayout()
        Me.tabLabour.ResumeLayout(False)
        Me.tabLabour.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ntbSalesPrice As levate.NumericTextBox
    Friend WithEvents ntbSalesDiscPercent As levate.NumericTextBox
    Friend WithEvents cmbSKUCatID As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSKUUoM As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSKUBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSKUName1 As System.Windows.Forms.TextBox
    Friend WithEvents txtSKUCode1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSKUInfo3 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSKUInfo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSKUInfo1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSKURemarks As System.Windows.Forms.TextBox
    Friend WithEvents btnSKU1 As System.Windows.Forms.Button
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabMaterial As System.Windows.Forms.TabPage
    Friend WithEvents ntbSKUPackageQty As levate.NumericTextBox
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents txtSKUName2 As System.Windows.Forms.TextBox
    Friend WithEvents txtSKUCode2 As System.Windows.Forms.TextBox
    Friend WithEvents btnSKU As System.Windows.Forms.Button
    Friend WithEvents btnDeleteD As System.Windows.Forms.Button
    Friend WithEvents btnSaveD As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tabLabour As System.Windows.Forms.TabPage
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnAddProcessD As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtProcessName As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessCode As System.Windows.Forms.TextBox
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents btnDeleteProcessD As System.Windows.Forms.Button
    Friend WithEvents btnSaveProcessD As System.Windows.Forms.Button
    Friend WithEvents ntbProcessQty As levate.NumericTextBox
    Friend WithEvents lsvProcess As System.Windows.Forms.ListView
    Friend WithEvents sCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnLabour As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtLabourName As System.Windows.Forms.TextBox
    Friend WithEvents txtLabourCode As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents ntbProcessCost As levate.NumericTextBox
    Friend WithEvents chbFinishGoods As System.Windows.Forms.CheckBox

End Class
