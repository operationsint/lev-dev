<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJournal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJournal))
        Me.txtJournalNo = New System.Windows.Forms.TextBox()
        Me.dtpJournalDate = New System.Windows.Forms.DateTimePicker()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.txtJournalRemarks = New System.Windows.Forms.TextBox()
        Me.txtJournalTotalDB = New System.Windows.Forms.TextBox()
        Me.txtJournalTotalCR = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnDeleteD = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnSaveD = New System.Windows.Forms.Button()
        Me.btnAccount = New System.Windows.Forms.Button()
        Me.btnCurrency = New System.Windows.Forms.Button()
        Me.txtSKUCode = New System.Windows.Forms.TextBox()
        Me.txtJournalDtlDesc = New System.Windows.Forms.TextBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAddD = New System.Windows.Forms.Button()
        Me.txtJournalType = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtCurrCode = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtLocalJournalTotalCR = New System.Windows.Forms.TextBox()
        Me.txtLocalJournalTotalDB = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbJournalPeriodId = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtJournalRefNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPeriodId = New System.Windows.Forms.TextBox()
        Me.ntbLocalCR = New levate.NumericTextBox()
        Me.ntbLocalDB = New levate.NumericTextBox()
        Me.ntbCRValue = New levate.NumericTextBox()
        Me.ntbJournalCurrRate = New levate.NumericTextBox()
        Me.ntbDBValue = New levate.NumericTextBox()
        Me.SuspendLayout()
        '
        'txtJournalNo
        '
        Me.txtJournalNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJournalNo.Location = New System.Drawing.Point(139, 12)
        Me.txtJournalNo.MaxLength = 12
        Me.txtJournalNo.Name = "txtJournalNo"
        Me.txtJournalNo.Size = New System.Drawing.Size(127, 21)
        Me.txtJournalNo.TabIndex = 0
        '
        'dtpJournalDate
        '
        Me.dtpJournalDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpJournalDate.Location = New System.Drawing.Point(139, 40)
        Me.dtpJournalDate.Name = "dtpJournalDate"
        Me.dtpJournalDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpJournalDate.TabIndex = 1
        '
        'ListView1
        '
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 196)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1002, 198)
        Me.ListView1.TabIndex = 19
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'txtJournalRemarks
        '
        Me.txtJournalRemarks.Location = New System.Drawing.Point(14, 424)
        Me.txtJournalRemarks.MaxLength = 255
        Me.txtJournalRemarks.Multiline = True
        Me.txtJournalRemarks.Name = "txtJournalRemarks"
        Me.txtJournalRemarks.Size = New System.Drawing.Size(318, 59)
        Me.txtJournalRemarks.TabIndex = 20
        '
        'txtJournalTotalDB
        '
        Me.txtJournalTotalDB.Location = New System.Drawing.Point(595, 426)
        Me.txtJournalTotalDB.Name = "txtJournalTotalDB"
        Me.txtJournalTotalDB.ReadOnly = True
        Me.txtJournalTotalDB.Size = New System.Drawing.Size(122, 21)
        Me.txtJournalTotalDB.TabIndex = 21
        Me.txtJournalTotalDB.TabStop = False
        Me.txtJournalTotalDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtJournalTotalCR
        '
        Me.txtJournalTotalCR.Location = New System.Drawing.Point(830, 426)
        Me.txtJournalTotalCR.Name = "txtJournalTotalCR"
        Me.txtJournalTotalCR.ReadOnly = True
        Me.txtJournalTotalCR.Size = New System.Drawing.Size(122, 21)
        Me.txtJournalTotalCR.TabIndex = 23
        Me.txtJournalTotalCR.TabStop = False
        Me.txtJournalTotalCR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(840, 559)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 26)
        Me.btnCancel.TabIndex = 29
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(570, 559)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(84, 26)
        Me.btnEdit.TabIndex = 26
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(660, 559)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnAdd.TabIndex = 27
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(480, 559)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 26)
        Me.btnDelete.TabIndex = 25
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(750, 559)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 26)
        Me.btnSave.TabIndex = 28
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(530, 429)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Total Debit"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(765, 430)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Total Credit"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Journal Entry No.*"
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
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 408)
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
        Me.btnDeleteD.Location = New System.Drawing.Point(954, 163)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 17
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
        Me.btnSaveD.Location = New System.Drawing.Point(923, 163)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 16
        Me.btnSaveD.UseVisualStyleBackColor = True
        '
        'btnAccount
        '
        Me.btnAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAccount.ImageIndex = 1
        Me.btnAccount.ImageList = Me.ImageList1
        Me.btnAccount.Location = New System.Drawing.Point(149, 165)
        Me.btnAccount.Name = "btnAccount"
        Me.btnAccount.Size = New System.Drawing.Size(29, 25)
        Me.btnAccount.TabIndex = 10
        Me.btnAccount.UseVisualStyleBackColor = True
        '
        'btnCurrency
        '
        Me.btnCurrency.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCurrency.ImageIndex = 0
        Me.btnCurrency.ImageList = Me.ImageList1
        Me.btnCurrency.Location = New System.Drawing.Point(827, 10)
        Me.btnCurrency.Name = "btnCurrency"
        Me.btnCurrency.Size = New System.Drawing.Size(29, 25)
        Me.btnCurrency.TabIndex = 6
        Me.btnCurrency.UseVisualStyleBackColor = True
        '
        'txtSKUCode
        '
        Me.txtSKUCode.Location = New System.Drawing.Point(12, 167)
        Me.txtSKUCode.MaxLength = 50
        Me.txtSKUCode.Name = "txtSKUCode"
        Me.txtSKUCode.ReadOnly = True
        Me.txtSKUCode.Size = New System.Drawing.Size(131, 21)
        Me.txtSKUCode.TabIndex = 9
        Me.txtSKUCode.TabStop = False
        '
        'txtJournalDtlDesc
        '
        Me.txtJournalDtlDesc.Location = New System.Drawing.Point(184, 167)
        Me.txtJournalDtlDesc.MaxLength = 100
        Me.txtJournalDtlDesc.Name = "txtJournalDtlDesc"
        Me.txtJournalDtlDesc.Size = New System.Drawing.Size(222, 21)
        Me.txtJournalDtlDesc.TabIndex = 11
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(930, 559)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 26)
        Me.btnPrint.TabIndex = 30
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(661, 70)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 13)
        Me.Label13.TabIndex = 49
        Me.Label13.Text = "Journal Type"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(13, 151)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 13)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Account Code*"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(188, 150)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "Line Description"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(505, 149)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(32, 13)
        Me.Label20.TabIndex = 61
        Me.Label20.Text = "Debit"
        '
        'btnAddD
        '
        Me.btnAddD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD.ImageIndex = 4
        Me.btnAddD.ImageList = Me.ImageList1
        Me.btnAddD.Location = New System.Drawing.Point(985, 163)
        Me.btnAddD.Name = "btnAddD"
        Me.btnAddD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD.TabIndex = 18
        Me.btnAddD.UseVisualStyleBackColor = True
        '
        'txtJournalType
        '
        Me.txtJournalType.Location = New System.Drawing.Point(772, 67)
        Me.txtJournalType.Name = "txtJournalType"
        Me.txtJournalType.ReadOnly = True
        Me.txtJournalType.Size = New System.Drawing.Size(153, 21)
        Me.txtJournalType.TabIndex = 8
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(661, 16)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(79, 13)
        Me.Label27.TabIndex = 79
        Me.Label27.Text = "Currency Code"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(661, 41)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(77, 13)
        Me.Label28.TabIndex = 81
        Me.Label28.Text = "Currency Rate"
        '
        'txtCurrCode
        '
        Me.txtCurrCode.Location = New System.Drawing.Point(772, 12)
        Me.txtCurrCode.Name = "txtCurrCode"
        Me.txtCurrCode.ReadOnly = True
        Me.txtCurrCode.Size = New System.Drawing.Size(50, 21)
        Me.txtCurrCode.TabIndex = 5
        Me.txtCurrCode.TabStop = False
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(737, 457)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(90, 13)
        Me.Label35.TabIndex = 101
        Me.Label35.Text = "Local Total Credit"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(503, 457)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(86, 13)
        Me.Label36.TabIndex = 100
        Me.Label36.Text = "Local Total Debit"
        '
        'txtLocalJournalTotalCR
        '
        Me.txtLocalJournalTotalCR.Location = New System.Drawing.Point(830, 453)
        Me.txtLocalJournalTotalCR.Name = "txtLocalJournalTotalCR"
        Me.txtLocalJournalTotalCR.ReadOnly = True
        Me.txtLocalJournalTotalCR.Size = New System.Drawing.Size(122, 21)
        Me.txtLocalJournalTotalCR.TabIndex = 24
        Me.txtLocalJournalTotalCR.TabStop = False
        Me.txtLocalJournalTotalCR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLocalJournalTotalDB
        '
        Me.txtLocalJournalTotalDB.Location = New System.Drawing.Point(595, 453)
        Me.txtLocalJournalTotalDB.Name = "txtLocalJournalTotalDB"
        Me.txtLocalJournalTotalDB.ReadOnly = True
        Me.txtLocalJournalTotalDB.Size = New System.Drawing.Size(122, 21)
        Me.txtLocalJournalTotalDB.TabIndex = 22
        Me.txtLocalJournalTotalDB.TabStop = False
        Me.txtLocalJournalTotalDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(631, 149)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Credit"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Period"
        '
        'cmbJournalPeriodId
        '
        Me.cmbJournalPeriodId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJournalPeriodId.FormattingEnabled = True
        Me.cmbJournalPeriodId.Location = New System.Drawing.Point(242, 67)
        Me.cmbJournalPeriodId.Name = "cmbJournalPeriodId"
        Me.cmbJournalPeriodId.Size = New System.Drawing.Size(97, 21)
        Me.cmbJournalPeriodId.TabIndex = 3
        Me.cmbJournalPeriodId.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "Ref No."
        '
        'txtJournalRefNo
        '
        Me.txtJournalRefNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJournalRefNo.Location = New System.Drawing.Point(139, 94)
        Me.txtJournalRefNo.MaxLength = 12
        Me.txtJournalRefNo.Name = "txtJournalRefNo"
        Me.txtJournalRefNo.Size = New System.Drawing.Size(127, 21)
        Me.txtJournalRefNo.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(859, 149)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 112
        Me.Label8.Text = "Local Credit"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(735, 149)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 13)
        Me.Label9.TabIndex = 110
        Me.Label9.Text = "Local Debit"
        '
        'txtPeriodId
        '
        Me.txtPeriodId.Location = New System.Drawing.Point(139, 67)
        Me.txtPeriodId.Name = "txtPeriodId"
        Me.txtPeriodId.ReadOnly = True
        Me.txtPeriodId.Size = New System.Drawing.Size(97, 21)
        Me.txtPeriodId.TabIndex = 2
        '
        'ntbLocalCR
        '
        Me.ntbLocalCR.AllowSpace = False
        Me.ntbLocalCR.Location = New System.Drawing.Point(795, 166)
        Me.ntbLocalCR.MaxLength = 18
        Me.ntbLocalCR.Name = "ntbLocalCR"
        Me.ntbLocalCR.ReadOnly = True
        Me.ntbLocalCR.Size = New System.Drawing.Size(122, 21)
        Me.ntbLocalCR.TabIndex = 15
        Me.ntbLocalCR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbLocalDB
        '
        Me.ntbLocalDB.AllowSpace = False
        Me.ntbLocalDB.Location = New System.Drawing.Point(668, 167)
        Me.ntbLocalDB.MaxLength = 18
        Me.ntbLocalDB.Name = "ntbLocalDB"
        Me.ntbLocalDB.ReadOnly = True
        Me.ntbLocalDB.Size = New System.Drawing.Size(122, 21)
        Me.ntbLocalDB.TabIndex = 14
        Me.ntbLocalDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbCRValue
        '
        Me.ntbCRValue.AllowSpace = False
        Me.ntbCRValue.Location = New System.Drawing.Point(540, 167)
        Me.ntbCRValue.MaxLength = 18
        Me.ntbCRValue.Name = "ntbCRValue"
        Me.ntbCRValue.Size = New System.Drawing.Size(122, 21)
        Me.ntbCRValue.TabIndex = 13
        Me.ntbCRValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbJournalCurrRate
        '
        Me.ntbJournalCurrRate.AllowSpace = False
        Me.ntbJournalCurrRate.Location = New System.Drawing.Point(772, 38)
        Me.ntbJournalCurrRate.MaxLength = 10
        Me.ntbJournalCurrRate.Name = "ntbJournalCurrRate"
        Me.ntbJournalCurrRate.Size = New System.Drawing.Size(76, 21)
        Me.ntbJournalCurrRate.TabIndex = 7
        Me.ntbJournalCurrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbDBValue
        '
        Me.ntbDBValue.AllowSpace = False
        Me.ntbDBValue.Location = New System.Drawing.Point(412, 167)
        Me.ntbDBValue.MaxLength = 18
        Me.ntbDBValue.Name = "ntbDBValue"
        Me.ntbDBValue.Size = New System.Drawing.Size(122, 21)
        Me.ntbDBValue.TabIndex = 12
        Me.ntbDBValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmJournal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1022, 597)
        Me.Controls.Add(Me.txtPeriodId)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ntbLocalCR)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ntbLocalDB)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtJournalRefNo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbJournalPeriodId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ntbCRValue)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.txtLocalJournalTotalCR)
        Me.Controls.Add(Me.txtLocalJournalTotalDB)
        Me.Controls.Add(Me.txtCurrCode)
        Me.Controls.Add(Me.ntbJournalCurrRate)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.txtJournalType)
        Me.Controls.Add(Me.btnAddD)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.ntbDBValue)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.txtJournalDtlDesc)
        Me.Controls.Add(Me.txtSKUCode)
        Me.Controls.Add(Me.btnAccount)
        Me.Controls.Add(Me.btnCurrency)
        Me.Controls.Add(Me.btnDeleteD)
        Me.Controls.Add(Me.btnSaveD)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtJournalTotalCR)
        Me.Controls.Add(Me.txtJournalTotalDB)
        Me.Controls.Add(Me.txtJournalRemarks)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.dtpJournalDate)
        Me.Controls.Add(Me.txtJournalNo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmJournal"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Journal Entry"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtJournalNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpJournalDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents txtJournalRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtJournalTotalDB As System.Windows.Forms.TextBox
    Friend WithEvents txtJournalTotalCR As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnDeleteD As System.Windows.Forms.Button
    Friend WithEvents btnSaveD As System.Windows.Forms.Button
    Friend WithEvents btnAccount As System.Windows.Forms.Button
    Friend WithEvents btnCurrency As System.Windows.Forms.Button
    Friend WithEvents txtSKUCode As System.Windows.Forms.TextBox
    Friend WithEvents txtJournalDtlDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ntbDBValue As levate.NumericTextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents txtJournalType As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents ntbJournalCurrRate As levate.NumericTextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtCurrCode As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtLocalJournalTotalCR As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalJournalTotalDB As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ntbCRValue As levate.NumericTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbJournalPeriodId As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtJournalRefNo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ntbLocalCR As levate.NumericTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ntbLocalDB As levate.NumericTextBox
    Friend WithEvents txtPeriodId As System.Windows.Forms.TextBox

End Class
