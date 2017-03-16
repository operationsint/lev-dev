<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSKU
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
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.txtSKUCode = New System.Windows.Forms.TextBox()
        Me.txtSKUName = New System.Windows.Forms.TextBox()
        Me.txtStockValue = New System.Windows.Forms.TextBox()
        Me.txtStockBalance = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLastCost = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cmbFilterBy = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.txtSKUBarcode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSKURemarks = New System.Windows.Forms.TextBox()
        Me.txtSKUUoM = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSKUInfo1 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSKUInfo2 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSKUInfo3 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtAvgCost = New System.Windows.Forms.TextBox()
        Me.cmbSKUCatID = New System.Windows.Forms.ComboBox()
        Me.lblCurrentRecord = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cbCategory = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chbStockSet = New System.Windows.Forms.CheckBox()
        Me.ntbBeratBersih = New levate.NumericTextBox()
        Me.ntbBeratKotor = New levate.NumericTextBox()
        Me.ntbVolume = New levate.NumericTextBox()
        Me.ntbJumlahKemasan = New levate.NumericTextBox()
        Me.ntbSalesPrice = New levate.NumericTextBox()
        Me.ntbSalesDiscPercent = New levate.NumericTextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.lblUpload = New System.Windows.Forms.LinkLabel()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.pbUpload = New System.Windows.Forms.PictureBox()
        Me.OFDLampiran = New System.Windows.Forms.OpenFileDialog()
        Me.chbFinishGoods = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.pbUpload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 33)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(716, 642)
        Me.ListView1.TabIndex = 4
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(1022, 686)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(779, 686)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'txtSKUCode
        '
        Me.txtSKUCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUCode.Location = New System.Drawing.Point(140, 6)
        Me.txtSKUCode.MaxLength = 50
        Me.txtSKUCode.Name = "txtSKUCode"
        Me.txtSKUCode.Size = New System.Drawing.Size(148, 21)
        Me.txtSKUCode.TabIndex = 0
        '
        'txtSKUName
        '
        Me.txtSKUName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUName.Location = New System.Drawing.Point(140, 33)
        Me.txtSKUName.MaxLength = 255
        Me.txtSKUName.Name = "txtSKUName"
        Me.txtSKUName.Size = New System.Drawing.Size(254, 21)
        Me.txtSKUName.TabIndex = 1
        '
        'txtStockValue
        '
        Me.txtStockValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockValue.Location = New System.Drawing.Point(140, 277)
        Me.txtStockValue.Name = "txtStockValue"
        Me.txtStockValue.ReadOnly = True
        Me.txtStockValue.Size = New System.Drawing.Size(131, 21)
        Me.txtStockValue.TabIndex = 10
        Me.txtStockValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtStockBalance
        '
        Me.txtStockBalance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockBalance.Location = New System.Drawing.Point(140, 303)
        Me.txtStockBalance.Name = "txtStockBalance"
        Me.txtStockBalance.ReadOnly = True
        Me.txtStockBalance.Size = New System.Drawing.Size(131, 21)
        Me.txtStockBalance.TabIndex = 11
        Me.txtStockBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Stock Code *"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Stock Name *"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 253)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Last Cost"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 280)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Stock Value"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 521)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Sales Price"
        Me.Label5.Visible = False
        '
        'txtLastCost
        '
        Me.txtLastCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastCost.Location = New System.Drawing.Point(140, 250)
        Me.txtLastCost.Name = "txtLastCost"
        Me.txtLastCost.ReadOnly = True
        Me.txtLastCost.Size = New System.Drawing.Size(131, 21)
        Me.txtLastCost.TabIndex = 9
        Me.txtLastCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(941, 686)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(860, 686)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 7
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(1101, 686)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cmbFilterBy
        '
        Me.cmbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilterBy.FormattingEnabled = True
        Me.cmbFilterBy.Location = New System.Drawing.Point(64, 6)
        Me.cmbFilterBy.Name = "cmbFilterBy"
        Me.cmbFilterBy.Size = New System.Drawing.Size(136, 21)
        Me.cmbFilterBy.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Filter By"
        '
        'txtFilter
        '
        Me.txtFilter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFilter.Location = New System.Drawing.Point(206, 6)
        Me.txtFilter.MaxLength = 50
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(323, 21)
        Me.txtFilter.TabIndex = 1
        '
        'txtSKUBarcode
        '
        Me.txtSKUBarcode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUBarcode.Location = New System.Drawing.Point(140, 87)
        Me.txtSKUBarcode.MaxLength = 50
        Me.txtSKUBarcode.Name = "txtSKUBarcode"
        Me.txtSKUBarcode.Size = New System.Drawing.Size(254, 21)
        Me.txtSKUBarcode.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Barcode"
        '
        'txtSKURemarks
        '
        Me.txtSKURemarks.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKURemarks.Location = New System.Drawing.Point(140, 357)
        Me.txtSKURemarks.MaxLength = 50
        Me.txtSKURemarks.Name = "txtSKURemarks"
        Me.txtSKURemarks.Size = New System.Drawing.Size(254, 21)
        Me.txtSKURemarks.TabIndex = 13
        '
        'txtSKUUoM
        '
        Me.txtSKUUoM.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUUoM.Location = New System.Drawing.Point(140, 114)
        Me.txtSKUUoM.MaxLength = 50
        Me.txtSKUUoM.Name = "txtSKUUoM"
        Me.txtSKUUoM.Size = New System.Drawing.Size(131, 21)
        Me.txtSKUUoM.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 114)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Unit of Measurement"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 360)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Remarks"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 492)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Sales Discount %"
        Me.Label10.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 387)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Other Info 1"
        '
        'txtSKUInfo1
        '
        Me.txtSKUInfo1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUInfo1.Location = New System.Drawing.Point(140, 384)
        Me.txtSKUInfo1.MaxLength = 50
        Me.txtSKUInfo1.Name = "txtSKUInfo1"
        Me.txtSKUInfo1.Size = New System.Drawing.Size(254, 21)
        Me.txtSKUInfo1.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 414)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 13)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Other Info 2"
        '
        'txtSKUInfo2
        '
        Me.txtSKUInfo2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUInfo2.Location = New System.Drawing.Point(140, 411)
        Me.txtSKUInfo2.MaxLength = 50
        Me.txtSKUInfo2.Name = "txtSKUInfo2"
        Me.txtSKUInfo2.Size = New System.Drawing.Size(254, 21)
        Me.txtSKUInfo2.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 441)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Other Info 3"
        '
        'txtSKUInfo3
        '
        Me.txtSKUInfo3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKUInfo3.Location = New System.Drawing.Point(140, 438)
        Me.txtSKUInfo3.MaxLength = 50
        Me.txtSKUInfo3.Name = "txtSKUInfo3"
        Me.txtSKUInfo3.Size = New System.Drawing.Size(254, 21)
        Me.txtSKUInfo3.TabIndex = 16
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 63)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 13)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Stock Category *"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(10, 306)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 13)
        Me.Label16.TabIndex = 38
        Me.Label16.Text = "Stock Balance"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(10, 333)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 13)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "Average Cost"
        '
        'txtAvgCost
        '
        Me.txtAvgCost.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvgCost.Location = New System.Drawing.Point(140, 330)
        Me.txtAvgCost.Name = "txtAvgCost"
        Me.txtAvgCost.ReadOnly = True
        Me.txtAvgCost.Size = New System.Drawing.Size(131, 21)
        Me.txtAvgCost.TabIndex = 12
        Me.txtAvgCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbSKUCatID
        '
        Me.cmbSKUCatID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSKUCatID.FormattingEnabled = True
        Me.cmbSKUCatID.Location = New System.Drawing.Point(140, 60)
        Me.cmbSKUCatID.Name = "cmbSKUCatID"
        Me.cmbSKUCatID.Size = New System.Drawing.Size(148, 21)
        Me.cmbSKUCatID.TabIndex = 2
        '
        'lblCurrentRecord
        '
        Me.lblCurrentRecord.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCurrentRecord.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentRecord.Location = New System.Drawing.Point(12, 696)
        Me.lblCurrentRecord.Name = "lblCurrentRecord"
        Me.lblCurrentRecord.Size = New System.Drawing.Size(177, 13)
        Me.lblCurrentRecord.TabIndex = 45
        Me.lblCurrentRecord.Text = "Selected record:"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1110, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(71, 25)
        Me.Label14.TabIndex = 62
        Me.Label14.Text = "Stock"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(10, 142)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(86, 13)
        Me.Label18.TabIndex = 64
        Me.Label18.Text = "Jumlah Kemasan"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(10, 169)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(41, 13)
        Me.Label19.TabIndex = 66
        Me.Label19.Text = "Volume"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(10, 196)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(84, 13)
        Me.Label20.TabIndex = 68
        Me.Label20.Text = "Berat Kotor (kg)"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(10, 223)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(87, 13)
        Me.Label21.TabIndex = 70
        Me.Label21.Text = "Berat Bersih (kg)"
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(706, 4)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(75, 23)
        Me.btnFilter.TabIndex = 3
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(540, 8)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(52, 13)
        Me.Label22.TabIndex = 72
        Me.Label22.Text = "Category"
        '
        'cbCategory
        '
        Me.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategory.FormattingEnabled = True
        Me.cbCategory.Location = New System.Drawing.Point(594, 5)
        Me.cbCategory.Name = "cbCategory"
        Me.cbCategory.Size = New System.Drawing.Size(106, 21)
        Me.cbCategory.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(734, 33)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(438, 642)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chbFinishGoods)
        Me.TabPage1.Controls.Add(Me.chbStockSet)
        Me.TabPage1.Controls.Add(Me.txtStockBalance)
        Me.TabPage1.Controls.Add(Me.txtSKUCode)
        Me.TabPage1.Controls.Add(Me.txtSKUName)
        Me.TabPage1.Controls.Add(Me.txtStockValue)
        Me.TabPage1.Controls.Add(Me.ntbBeratBersih)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.ntbBeratKotor)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.ntbVolume)
        Me.TabPage1.Controls.Add(Me.txtLastCost)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.ntbJumlahKemasan)
        Me.TabPage1.Controls.Add(Me.txtSKUBarcode)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtSKURemarks)
        Me.TabPage1.Controls.Add(Me.txtSKUUoM)
        Me.TabPage1.Controls.Add(Me.ntbSalesPrice)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.ntbSalesDiscPercent)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.cmbSKUCatID)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.txtSKUInfo1)
        Me.TabPage1.Controls.Add(Me.txtAvgCost)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.txtSKUInfo2)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtSKUInfo3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(430, 616)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Primary Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chbStockSet
        '
        Me.chbStockSet.AutoSize = True
        Me.chbStockSet.Location = New System.Drawing.Point(140, 469)
        Me.chbStockSet.Name = "chbStockSet"
        Me.chbStockSet.Size = New System.Drawing.Size(85, 17)
        Me.chbStockSet.TabIndex = 71
        Me.chbStockSet.Text = "Has Formula"
        Me.chbStockSet.UseVisualStyleBackColor = True
        '
        'ntbBeratBersih
        '
        Me.ntbBeratBersih.AllowSpace = False
        Me.ntbBeratBersih.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ntbBeratBersih.Location = New System.Drawing.Point(140, 223)
        Me.ntbBeratBersih.MaxLength = 10
        Me.ntbBeratBersih.Name = "ntbBeratBersih"
        Me.ntbBeratBersih.Size = New System.Drawing.Size(131, 21)
        Me.ntbBeratBersih.TabIndex = 8
        Me.ntbBeratBersih.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbBeratKotor
        '
        Me.ntbBeratKotor.AllowSpace = False
        Me.ntbBeratKotor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ntbBeratKotor.Location = New System.Drawing.Point(140, 196)
        Me.ntbBeratKotor.MaxLength = 10
        Me.ntbBeratKotor.Name = "ntbBeratKotor"
        Me.ntbBeratKotor.Size = New System.Drawing.Size(131, 21)
        Me.ntbBeratKotor.TabIndex = 7
        Me.ntbBeratKotor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbVolume
        '
        Me.ntbVolume.AllowSpace = False
        Me.ntbVolume.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ntbVolume.Location = New System.Drawing.Point(140, 169)
        Me.ntbVolume.MaxLength = 10
        Me.ntbVolume.Name = "ntbVolume"
        Me.ntbVolume.Size = New System.Drawing.Size(131, 21)
        Me.ntbVolume.TabIndex = 6
        Me.ntbVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbJumlahKemasan
        '
        Me.ntbJumlahKemasan.AllowSpace = False
        Me.ntbJumlahKemasan.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ntbJumlahKemasan.Location = New System.Drawing.Point(140, 142)
        Me.ntbJumlahKemasan.MaxLength = 10
        Me.ntbJumlahKemasan.Name = "ntbJumlahKemasan"
        Me.ntbJumlahKemasan.Size = New System.Drawing.Size(131, 21)
        Me.ntbJumlahKemasan.TabIndex = 5
        Me.ntbJumlahKemasan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSalesPrice
        '
        Me.ntbSalesPrice.AllowSpace = False
        Me.ntbSalesPrice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ntbSalesPrice.Location = New System.Drawing.Point(140, 518)
        Me.ntbSalesPrice.Name = "ntbSalesPrice"
        Me.ntbSalesPrice.Size = New System.Drawing.Size(131, 21)
        Me.ntbSalesPrice.TabIndex = 18
        Me.ntbSalesPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ntbSalesPrice.Visible = False
        '
        'ntbSalesDiscPercent
        '
        Me.ntbSalesDiscPercent.AllowSpace = False
        Me.ntbSalesDiscPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ntbSalesDiscPercent.Location = New System.Drawing.Point(140, 492)
        Me.ntbSalesDiscPercent.MaxLength = 3
        Me.ntbSalesDiscPercent.Name = "ntbSalesDiscPercent"
        Me.ntbSalesDiscPercent.Size = New System.Drawing.Size(131, 21)
        Me.ntbSalesDiscPercent.TabIndex = 17
        Me.ntbSalesDiscPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ntbSalesDiscPercent.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ListView2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(430, 616)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Balance"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ListView2
        '
        Me.ListView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView2.FullRowSelect = True
        Me.ListView2.GridLines = True
        Me.ListView2.Location = New System.Drawing.Point(15, 18)
        Me.ListView2.MultiSelect = False
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(397, 581)
        Me.ListView2.TabIndex = 4
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.List
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnUpload)
        Me.TabPage3.Controls.Add(Me.lblUpload)
        Me.TabPage3.Controls.Add(Me.Label23)
        Me.TabPage3.Controls.Add(Me.ProgressBar1)
        Me.TabPage3.Controls.Add(Me.pbUpload)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(430, 616)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Image"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(58, 10)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(29, 25)
        Me.btnUpload.TabIndex = 358
        Me.btnUpload.Text = "..."
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'lblUpload
        '
        Me.lblUpload.AutoSize = True
        Me.lblUpload.Location = New System.Drawing.Point(95, 15)
        Me.lblUpload.Name = "lblUpload"
        Me.lblUpload.Size = New System.Drawing.Size(0, 13)
        Me.lblUpload.TabIndex = 360
        Me.lblUpload.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(10, 15)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 13)
        Me.Label23.TabIndex = 359
        Me.Label23.Text = "Upload"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(9, 41)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(415, 23)
        Me.ProgressBar1.TabIndex = 357
        Me.ProgressBar1.Visible = False
        '
        'pbUpload
        '
        Me.pbUpload.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbUpload.Location = New System.Drawing.Point(6, 148)
        Me.pbUpload.Name = "pbUpload"
        Me.pbUpload.Size = New System.Drawing.Size(418, 286)
        Me.pbUpload.TabIndex = 73
        Me.pbUpload.TabStop = False
        '
        'OFDLampiran
        '
        '
        'chbFinishGoods
        '
        Me.chbFinishGoods.AutoSize = True
        Me.chbFinishGoods.Location = New System.Drawing.Point(299, 469)
        Me.chbFinishGoods.Name = "chbFinishGoods"
        Me.chbFinishGoods.Size = New System.Drawing.Size(86, 17)
        Me.chbFinishGoods.TabIndex = 131
        Me.chbFinishGoods.Text = "Finish Goods"
        Me.chbFinishGoods.UseVisualStyleBackColor = True
        Me.chbFinishGoods.Visible = False
        '
        'frmSKU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1184, 714)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.cbCategory)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblCurrentRecord)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbFilterBy)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.ListView1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSKU"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.pbUpload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents txtSKUCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSKUName As System.Windows.Forms.TextBox
    Friend WithEvents txtStockValue As System.Windows.Forms.TextBox
    Friend WithEvents txtStockBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLastCost As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cmbFilterBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents txtSKUBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSKURemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtSKUUoM As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSKUInfo1 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSKUInfo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSKUInfo3 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtAvgCost As System.Windows.Forms.TextBox
    Friend WithEvents cmbSKUCatID As System.Windows.Forms.ComboBox
    Friend WithEvents ntbSalesDiscPercent As levate.NumericTextBox
    Friend WithEvents ntbSalesPrice As levate.NumericTextBox
    Friend WithEvents lblCurrentRecord As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ntbJumlahKemasan As levate.NumericTextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ntbVolume As levate.NumericTextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ntbBeratKotor As levate.NumericTextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ntbBeratBersih As levate.NumericTextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents pbUpload As System.Windows.Forms.PictureBox
    Friend WithEvents OFDLampiran As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents lblUpload As System.Windows.Forms.LinkLabel
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents chbStockSet As System.Windows.Forms.CheckBox
    Friend WithEvents chbFinishGoods As System.Windows.Forms.CheckBox
End Class
