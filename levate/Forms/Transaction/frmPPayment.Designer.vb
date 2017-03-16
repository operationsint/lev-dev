<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPPayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPPayment))
        Me.txtPPaymentNo = New System.Windows.Forms.TextBox()
        Me.dtpPPaymentDate = New System.Windows.Forms.DateTimePicker()
        Me.txtSName = New System.Windows.Forms.TextBox()
        Me.txtSCode = New System.Windows.Forms.TextBox()
        Me.txtPPaymentRemarks = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSupplier = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.cmbPaymentMethod = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.chbIsPaymentAdvance = New System.Windows.Forms.CheckBox()
        Me.txtCurrCode = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCurrGainLossTotal = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPPaymentTotalOutstanding = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtPPaymentTotalAllocation = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtPPaymentAdvanceAmount = New System.Windows.Forms.TextBox()
        Me.txtPPaymentTotalAdvance = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtPPaymentConversionValue = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ntbPPaymentDtlCurrRate = New levate.NumericTextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ntbPPaymentAdvanceAllocation = New levate.NumericTextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPInvoiceCurrRate = New System.Windows.Forms.TextBox()
        Me.txtPInvoiceCurrCode = New System.Windows.Forms.TextBox()
        Me.txtCurrGainLossValue = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLocalPInvoiceTotal = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPInvoiceTotal = New System.Windows.Forms.TextBox()
        Me.btnPInvoice = New System.Windows.Forms.Button()
        Me.btnAddD1 = New System.Windows.Forms.Button()
        Me.btnDeleteD1 = New System.Windows.Forms.Button()
        Me.btnSaveD1 = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ntbPPaymentDtlValue = New levate.NumericTextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPInvoiceNo = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtPPaymentPreviousAdvance = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtPPaymentAdvanceCurrRate = New System.Windows.Forms.TextBox()
        Me.txtPPaymentAdvanceCurrCode = New System.Windows.Forms.TextBox()
        Me.btnAddD2 = New System.Windows.Forms.Button()
        Me.btnDeleteD2 = New System.Windows.Forms.Button()
        Me.btnSaveD2 = New System.Windows.Forms.Button()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtPPaymentAdvanceTotal = New System.Windows.Forms.TextBox()
        Me.btnAdvance = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPPaymentAdvanceNo = New System.Windows.Forms.TextBox()
        Me.ntbPPaymentAdvanceValue = New levate.NumericTextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtBankCode = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtSBankDetail = New System.Windows.Forms.TextBox()
        Me.chbIsPaymentBaseCurr = New System.Windows.Forms.CheckBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtLocalPPaymentTotalOutstanding = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtLocalPPaymentTotalPaid = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtPPaymentTotalConversion = New System.Windows.Forms.TextBox()
        Me.btnBank = New System.Windows.Forms.Button()
        Me.ntbPPaymentCurrRate = New levate.NumericTextBox()
        Me.ntbPPaymentTotalPaid = New levate.NumericTextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtPeriodId = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPPaymentNo
        '
        Me.txtPPaymentNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPPaymentNo.Location = New System.Drawing.Point(158, 12)
        Me.txtPPaymentNo.MaxLength = 12
        Me.txtPPaymentNo.Name = "txtPPaymentNo"
        Me.txtPPaymentNo.Size = New System.Drawing.Size(127, 21)
        Me.txtPPaymentNo.TabIndex = 0
        '
        'dtpPPaymentDate
        '
        Me.dtpPPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPPaymentDate.Location = New System.Drawing.Point(158, 39)
        Me.dtpPPaymentDate.Name = "dtpPPaymentDate"
        Me.dtpPPaymentDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpPPaymentDate.TabIndex = 1
        '
        'txtSName
        '
        Me.txtSName.Location = New System.Drawing.Point(554, 40)
        Me.txtSName.Name = "txtSName"
        Me.txtSName.ReadOnly = True
        Me.txtSName.Size = New System.Drawing.Size(217, 21)
        Me.txtSName.TabIndex = 8
        '
        'txtSCode
        '
        Me.txtSCode.Location = New System.Drawing.Point(554, 12)
        Me.txtSCode.Name = "txtSCode"
        Me.txtSCode.ReadOnly = True
        Me.txtSCode.Size = New System.Drawing.Size(80, 21)
        Me.txtSCode.TabIndex = 5
        '
        'txtPPaymentRemarks
        '
        Me.txtPPaymentRemarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPPaymentRemarks.Location = New System.Drawing.Point(75, 471)
        Me.txtPPaymentRemarks.MaxLength = 255
        Me.txtPPaymentRemarks.Multiline = True
        Me.txtPPaymentRemarks.Name = "txtPPaymentRemarks"
        Me.txtPPaymentRemarks.Size = New System.Drawing.Size(318, 59)
        Me.txtPPaymentRemarks.TabIndex = 17
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(1073, 590)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 26)
        Me.btnCancel.TabIndex = 30
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(803, 590)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(84, 26)
        Me.btnEdit.TabIndex = 27
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(893, 590)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnAdd.TabIndex = 28
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(713, 590)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 26)
        Me.btnDelete.TabIndex = 26
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(983, 590)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 26)
        Me.btnSave.TabIndex = 29
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(446, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Supplier Code*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Purchase Payment No.*"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Date"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 470)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Remarks"
        '
        'btnSupplier
        '
        Me.btnSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupplier.ImageIndex = 0
        Me.btnSupplier.ImageList = Me.ImageList1
        Me.btnSupplier.Location = New System.Drawing.Point(639, 10)
        Me.btnSupplier.Name = "btnSupplier"
        Me.btnSupplier.Size = New System.Drawing.Size(29, 25)
        Me.btnSupplier.TabIndex = 6
        Me.btnSupplier.UseVisualStyleBackColor = True
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
        Me.btnPrint.Location = New System.Drawing.Point(1163, 590)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 26)
        Me.btnPrint.TabIndex = 31
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'cmbPaymentMethod
        '
        Me.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaymentMethod.FormattingEnabled = True
        Me.cmbPaymentMethod.Location = New System.Drawing.Point(158, 93)
        Me.cmbPaymentMethod.Name = "cmbPaymentMethod"
        Me.cmbPaymentMethod.Size = New System.Drawing.Size(97, 21)
        Me.cmbPaymentMethod.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Payment Method"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 123)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 13)
        Me.Label9.TabIndex = 61
        Me.Label9.Text = "Ref. No."
        '
        'txtRefNo
        '
        Me.txtRefNo.Location = New System.Drawing.Point(158, 120)
        Me.txtRefNo.MaxLength = 50
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(127, 21)
        Me.txtRefNo.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(446, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Supplier Name"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(446, 97)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(77, 13)
        Me.Label28.TabIndex = 85
        Me.Label28.Text = "Currency Rate"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(446, 71)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(79, 13)
        Me.Label27.TabIndex = 83
        Me.Label27.Text = "Currency Code"
        '
        'chbIsPaymentAdvance
        '
        Me.chbIsPaymentAdvance.AutoSize = True
        Me.chbIsPaymentAdvance.Location = New System.Drawing.Point(674, 15)
        Me.chbIsPaymentAdvance.Name = "chbIsPaymentAdvance"
        Me.chbIsPaymentAdvance.Size = New System.Drawing.Size(113, 17)
        Me.chbIsPaymentAdvance.TabIndex = 7
        Me.chbIsPaymentAdvance.Text = "Advance Payment"
        Me.chbIsPaymentAdvance.UseVisualStyleBackColor = True
        '
        'txtCurrCode
        '
        Me.txtCurrCode.Location = New System.Drawing.Point(554, 68)
        Me.txtCurrCode.Name = "txtCurrCode"
        Me.txtCurrCode.ReadOnly = True
        Me.txtCurrCode.Size = New System.Drawing.Size(50, 21)
        Me.txtCurrCode.TabIndex = 9
        Me.txtCurrCode.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(931, 500)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(116, 13)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "Total Invoice Allocated"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(891, 526)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(168, 13)
        Me.Label14.TabIndex = 114
        Me.Label14.Text = "Total Advance Payment Allocated"
        '
        'txtCurrGainLossTotal
        '
        Me.txtCurrGainLossTotal.Location = New System.Drawing.Point(696, 523)
        Me.txtCurrGainLossTotal.Name = "txtCurrGainLossTotal"
        Me.txtCurrGainLossTotal.ReadOnly = True
        Me.txtCurrGainLossTotal.Size = New System.Drawing.Size(140, 21)
        Me.txtCurrGainLossTotal.TabIndex = 20
        Me.txtCurrGainLossTotal.TabStop = False
        Me.txtCurrGainLossTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(557, 526)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(127, 13)
        Me.Label20.TabIndex = 116
        Me.Label20.Text = "Currency Gain/Loss Total"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(915, 473)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 13)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "Outstanding Invoice Amount"
        '
        'txtPPaymentTotalOutstanding
        '
        Me.txtPPaymentTotalOutstanding.Location = New System.Drawing.Point(1065, 470)
        Me.txtPPaymentTotalOutstanding.Name = "txtPPaymentTotalOutstanding"
        Me.txtPPaymentTotalOutstanding.ReadOnly = True
        Me.txtPPaymentTotalOutstanding.Size = New System.Drawing.Size(140, 21)
        Me.txtPPaymentTotalOutstanding.TabIndex = 22
        Me.txtPPaymentTotalOutstanding.TabStop = False
        Me.txtPPaymentTotalOutstanding.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(931, 553)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(125, 13)
        Me.Label21.TabIndex = 149
        Me.Label21.Text = "TOTAL AMOUNT PAID"
        '
        'txtPPaymentTotalAllocation
        '
        Me.txtPPaymentTotalAllocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPPaymentTotalAllocation.Location = New System.Drawing.Point(1065, 497)
        Me.txtPPaymentTotalAllocation.Name = "txtPPaymentTotalAllocation"
        Me.txtPPaymentTotalAllocation.ReadOnly = True
        Me.txtPPaymentTotalAllocation.Size = New System.Drawing.Size(140, 21)
        Me.txtPPaymentTotalAllocation.TabIndex = 23
        Me.txtPPaymentTotalAllocation.TabStop = False
        Me.txtPPaymentTotalAllocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(400, 126)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(148, 13)
        Me.Label22.TabIndex = 151
        Me.Label22.Text = "Advance Payment to Allocate"
        '
        'txtPPaymentAdvanceAmount
        '
        Me.txtPPaymentAdvanceAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPPaymentAdvanceAmount.Location = New System.Drawing.Point(554, 122)
        Me.txtPPaymentAdvanceAmount.Name = "txtPPaymentAdvanceAmount"
        Me.txtPPaymentAdvanceAmount.ReadOnly = True
        Me.txtPPaymentAdvanceAmount.Size = New System.Drawing.Size(140, 21)
        Me.txtPPaymentAdvanceAmount.TabIndex = 12
        Me.txtPPaymentAdvanceAmount.TabStop = False
        Me.txtPPaymentAdvanceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPPaymentTotalAdvance
        '
        Me.txtPPaymentTotalAdvance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPPaymentTotalAdvance.Location = New System.Drawing.Point(1065, 523)
        Me.txtPPaymentTotalAdvance.Name = "txtPPaymentTotalAdvance"
        Me.txtPPaymentTotalAdvance.ReadOnly = True
        Me.txtPPaymentTotalAdvance.Size = New System.Drawing.Size(140, 21)
        Me.txtPPaymentTotalAdvance.TabIndex = 24
        Me.txtPPaymentTotalAdvance.TabStop = False
        Me.txtPPaymentTotalAdvance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 149)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1247, 306)
        Me.TabControl1.TabIndex = 16
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtPPaymentConversionValue)
        Me.TabPage1.Controls.Add(Me.Label33)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.ntbPPaymentDtlCurrRate)
        Me.TabPage1.Controls.Add(Me.Label23)
        Me.TabPage1.Controls.Add(Me.ntbPPaymentAdvanceAllocation)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtPInvoiceCurrRate)
        Me.TabPage1.Controls.Add(Me.txtPInvoiceCurrCode)
        Me.TabPage1.Controls.Add(Me.txtCurrGainLossValue)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtLocalPInvoiceTotal)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtPInvoiceTotal)
        Me.TabPage1.Controls.Add(Me.btnPInvoice)
        Me.TabPage1.Controls.Add(Me.btnAddD1)
        Me.TabPage1.Controls.Add(Me.btnDeleteD1)
        Me.TabPage1.Controls.Add(Me.btnSaveD1)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.ntbPPaymentDtlValue)
        Me.TabPage1.Controls.Add(Me.ListView1)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.txtPInvoiceNo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1239, 280)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Invoice"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtPPaymentConversionValue
        '
        Me.txtPPaymentConversionValue.Location = New System.Drawing.Point(890, 34)
        Me.txtPPaymentConversionValue.Name = "txtPPaymentConversionValue"
        Me.txtPPaymentConversionValue.ReadOnly = True
        Me.txtPPaymentConversionValue.Size = New System.Drawing.Size(120, 21)
        Me.txtPPaymentConversionValue.TabIndex = 9
        Me.txtPPaymentConversionValue.TabStop = False
        Me.txtPPaymentConversionValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(903, 6)
        Me.Label33.Name = "Label33"
        Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label33.Size = New System.Drawing.Size(106, 26)
        Me.Label33.TabIndex = 179
        Me.Label33.Text = "Payment Conversion" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Value"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(681, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(77, 26)
        Me.Label17.TabIndex = 177
        Me.Label17.Text = "Payment" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Currency Rate"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ntbPPaymentDtlCurrRate
        '
        Me.ntbPPaymentDtlCurrRate.AllowSpace = False
        Me.ntbPPaymentDtlCurrRate.Location = New System.Drawing.Point(664, 34)
        Me.ntbPPaymentDtlCurrRate.MaxLength = 10
        Me.ntbPPaymentDtlCurrRate.Name = "ntbPPaymentDtlCurrRate"
        Me.ntbPPaymentDtlCurrRate.ReadOnly = True
        Me.ntbPPaymentDtlCurrRate.Size = New System.Drawing.Size(94, 21)
        Me.ntbPPaymentDtlCurrRate.TabIndex = 7
        Me.ntbPPaymentDtlCurrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(565, 4)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(94, 26)
        Me.Label23.TabIndex = 175
        Me.Label23.Text = "Advance Payment" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Allocation"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ntbPPaymentAdvanceAllocation
        '
        Me.ntbPPaymentAdvanceAllocation.AllowSpace = False
        Me.ntbPPaymentAdvanceAllocation.Location = New System.Drawing.Point(539, 34)
        Me.ntbPPaymentAdvanceAllocation.Name = "ntbPPaymentAdvanceAllocation"
        Me.ntbPPaymentAdvanceAllocation.Size = New System.Drawing.Size(120, 21)
        Me.ntbPPaymentAdvanceAllocation.TabIndex = 6
        Me.ntbPPaymentAdvanceAllocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(240, 19)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 13)
        Me.Label16.TabIndex = 173
        Me.Label16.Text = "Invoice Rate"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(175, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 172
        Me.Label10.Text = "Currency"
        '
        'txtPInvoiceCurrRate
        '
        Me.txtPInvoiceCurrRate.Location = New System.Drawing.Point(234, 34)
        Me.txtPInvoiceCurrRate.Name = "txtPInvoiceCurrRate"
        Me.txtPInvoiceCurrRate.ReadOnly = True
        Me.txtPInvoiceCurrRate.Size = New System.Drawing.Size(74, 21)
        Me.txtPInvoiceCurrRate.TabIndex = 3
        Me.txtPInvoiceCurrRate.TabStop = False
        Me.txtPInvoiceCurrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPInvoiceCurrCode
        '
        Me.txtPInvoiceCurrCode.Location = New System.Drawing.Point(178, 34)
        Me.txtPInvoiceCurrCode.Name = "txtPInvoiceCurrCode"
        Me.txtPInvoiceCurrCode.ReadOnly = True
        Me.txtPInvoiceCurrCode.Size = New System.Drawing.Size(50, 21)
        Me.txtPInvoiceCurrCode.TabIndex = 2
        Me.txtPInvoiceCurrCode.TabStop = False
        '
        'txtCurrGainLossValue
        '
        Me.txtCurrGainLossValue.Location = New System.Drawing.Point(1016, 34)
        Me.txtCurrGainLossValue.Name = "txtCurrGainLossValue"
        Me.txtCurrGainLossValue.ReadOnly = True
        Me.txtCurrGainLossValue.Size = New System.Drawing.Size(113, 21)
        Me.txtCurrGainLossValue.TabIndex = 10
        Me.txtCurrGainLossValue.TabStop = False
        Me.txtCurrGainLossValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1025, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 168
        Me.Label4.Text = "Currency Gain/Loss"
        '
        'txtLocalPInvoiceTotal
        '
        Me.txtLocalPInvoiceTotal.Location = New System.Drawing.Point(426, 34)
        Me.txtLocalPInvoiceTotal.Name = "txtLocalPInvoiceTotal"
        Me.txtLocalPInvoiceTotal.ReadOnly = True
        Me.txtLocalPInvoiceTotal.Size = New System.Drawing.Size(105, 21)
        Me.txtLocalPInvoiceTotal.TabIndex = 5
        Me.txtLocalPInvoiceTotal.TabStop = False
        Me.txtLocalPInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(442, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 13)
        Me.Label13.TabIndex = 166
        Me.Label13.Text = "Local Outstanding"
        '
        'txtPInvoiceTotal
        '
        Me.txtPInvoiceTotal.Location = New System.Drawing.Point(314, 34)
        Me.txtPInvoiceTotal.Name = "txtPInvoiceTotal"
        Me.txtPInvoiceTotal.ReadOnly = True
        Me.txtPInvoiceTotal.Size = New System.Drawing.Size(105, 21)
        Me.txtPInvoiceTotal.TabIndex = 4
        Me.txtPInvoiceTotal.TabStop = False
        Me.txtPInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPInvoice
        '
        Me.btnPInvoice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPInvoice.ImageIndex = 1
        Me.btnPInvoice.ImageList = Me.ImageList1
        Me.btnPInvoice.Location = New System.Drawing.Point(145, 32)
        Me.btnPInvoice.Name = "btnPInvoice"
        Me.btnPInvoice.Size = New System.Drawing.Size(29, 25)
        Me.btnPInvoice.TabIndex = 1
        Me.btnPInvoice.UseVisualStyleBackColor = True
        '
        'btnAddD1
        '
        Me.btnAddD1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD1.ImageIndex = 4
        Me.btnAddD1.ImageList = Me.ImageList1
        Me.btnAddD1.Location = New System.Drawing.Point(1200, 30)
        Me.btnAddD1.Name = "btnAddD1"
        Me.btnAddD1.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD1.TabIndex = 13
        Me.btnAddD1.UseVisualStyleBackColor = True
        '
        'btnDeleteD1
        '
        Me.btnDeleteD1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteD1.ImageIndex = 2
        Me.btnDeleteD1.ImageList = Me.ImageList1
        Me.btnDeleteD1.Location = New System.Drawing.Point(1170, 30)
        Me.btnDeleteD1.Name = "btnDeleteD1"
        Me.btnDeleteD1.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD1.TabIndex = 12
        Me.btnDeleteD1.UseVisualStyleBackColor = True
        '
        'btnSaveD1
        '
        Me.btnSaveD1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveD1.ImageIndex = 3
        Me.btnSaveD1.ImageList = Me.ImageList1
        Me.btnSaveD1.Location = New System.Drawing.Point(1139, 30)
        Me.btnSaveD1.Name = "btnSaveD1"
        Me.btnSaveD1.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD1.TabIndex = 11
        Me.btnSaveD1.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(332, 19)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(93, 13)
        Me.Label19.TabIndex = 160
        Me.Label19.Text = "Total Outstanding"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(807, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 159
        Me.Label11.Text = "Payment Value"
        '
        'ntbPPaymentDtlValue
        '
        Me.ntbPPaymentDtlValue.AllowSpace = False
        Me.ntbPPaymentDtlValue.Location = New System.Drawing.Point(764, 34)
        Me.ntbPPaymentDtlValue.Name = "ntbPPaymentDtlValue"
        Me.ntbPPaymentDtlValue.Size = New System.Drawing.Size(120, 21)
        Me.ntbPPaymentDtlValue.TabIndex = 8
        Me.ntbPPaymentDtlValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ListView1
        '
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 62)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1213, 206)
        Me.ListView1.TabIndex = 14
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(109, 13)
        Me.Label15.TabIndex = 156
        Me.Label15.Text = "Purchase Invoice No."
        '
        'txtPInvoiceNo
        '
        Me.txtPInvoiceNo.Location = New System.Drawing.Point(12, 35)
        Me.txtPInvoiceNo.Name = "txtPInvoiceNo"
        Me.txtPInvoiceNo.ReadOnly = True
        Me.txtPInvoiceNo.Size = New System.Drawing.Size(127, 21)
        Me.txtPInvoiceNo.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtPPaymentPreviousAdvance)
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.Label29)
        Me.TabPage2.Controls.Add(Me.Label30)
        Me.TabPage2.Controls.Add(Me.txtPPaymentAdvanceCurrRate)
        Me.TabPage2.Controls.Add(Me.txtPPaymentAdvanceCurrCode)
        Me.TabPage2.Controls.Add(Me.btnAddD2)
        Me.TabPage2.Controls.Add(Me.btnDeleteD2)
        Me.TabPage2.Controls.Add(Me.btnSaveD2)
        Me.TabPage2.Controls.Add(Me.ListView2)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.txtPPaymentAdvanceTotal)
        Me.TabPage2.Controls.Add(Me.btnAdvance)
        Me.TabPage2.Controls.Add(Me.Label25)
        Me.TabPage2.Controls.Add(Me.Label26)
        Me.TabPage2.Controls.Add(Me.txtPPaymentAdvanceNo)
        Me.TabPage2.Controls.Add(Me.ntbPPaymentAdvanceValue)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1239, 280)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Advance Payment Allocation"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtPPaymentPreviousAdvance
        '
        Me.txtPPaymentPreviousAdvance.Location = New System.Drawing.Point(459, 35)
        Me.txtPPaymentPreviousAdvance.Name = "txtPPaymentPreviousAdvance"
        Me.txtPPaymentPreviousAdvance.ReadOnly = True
        Me.txtPPaymentPreviousAdvance.Size = New System.Drawing.Size(139, 21)
        Me.txtPPaymentPreviousAdvance.TabIndex = 194
        Me.txtPPaymentPreviousAdvance.TabStop = False
        Me.txtPPaymentPreviousAdvance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(504, 19)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(93, 13)
        Me.Label24.TabIndex = 193
        Me.Label24.Text = "Previous Advance"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(278, 19)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(30, 13)
        Me.Label29.TabIndex = 192
        Me.Label29.Text = "Rate"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(175, 19)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(51, 13)
        Me.Label30.TabIndex = 191
        Me.Label30.Text = "Currency"
        '
        'txtPPaymentAdvanceCurrRate
        '
        Me.txtPPaymentAdvanceCurrRate.Location = New System.Drawing.Point(234, 35)
        Me.txtPPaymentAdvanceCurrRate.Name = "txtPPaymentAdvanceCurrRate"
        Me.txtPPaymentAdvanceCurrRate.ReadOnly = True
        Me.txtPPaymentAdvanceCurrRate.Size = New System.Drawing.Size(74, 21)
        Me.txtPPaymentAdvanceCurrRate.TabIndex = 190
        Me.txtPPaymentAdvanceCurrRate.TabStop = False
        Me.txtPPaymentAdvanceCurrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPPaymentAdvanceCurrCode
        '
        Me.txtPPaymentAdvanceCurrCode.Location = New System.Drawing.Point(178, 35)
        Me.txtPPaymentAdvanceCurrCode.Name = "txtPPaymentAdvanceCurrCode"
        Me.txtPPaymentAdvanceCurrCode.ReadOnly = True
        Me.txtPPaymentAdvanceCurrCode.Size = New System.Drawing.Size(50, 21)
        Me.txtPPaymentAdvanceCurrCode.TabIndex = 189
        Me.txtPPaymentAdvanceCurrCode.TabStop = False
        '
        'btnAddD2
        '
        Me.btnAddD2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD2.ImageIndex = 4
        Me.btnAddD2.ImageList = Me.ImageList1
        Me.btnAddD2.Location = New System.Drawing.Point(962, 29)
        Me.btnAddD2.Name = "btnAddD2"
        Me.btnAddD2.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD2.TabIndex = 188
        Me.btnAddD2.UseVisualStyleBackColor = True
        '
        'btnDeleteD2
        '
        Me.btnDeleteD2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteD2.ImageIndex = 2
        Me.btnDeleteD2.ImageList = Me.ImageList1
        Me.btnDeleteD2.Location = New System.Drawing.Point(930, 29)
        Me.btnDeleteD2.Name = "btnDeleteD2"
        Me.btnDeleteD2.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD2.TabIndex = 187
        Me.btnDeleteD2.UseVisualStyleBackColor = True
        '
        'btnSaveD2
        '
        Me.btnSaveD2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveD2.ImageIndex = 3
        Me.btnSaveD2.ImageList = Me.ImageList1
        Me.btnSaveD2.Location = New System.Drawing.Point(898, 29)
        Me.btnSaveD2.Name = "btnSaveD2"
        Me.btnSaveD2.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD2.TabIndex = 186
        Me.btnSaveD2.UseVisualStyleBackColor = True
        '
        'ListView2
        '
        Me.ListView2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView2.FullRowSelect = True
        Me.ListView2.GridLines = True
        Me.ListView2.Location = New System.Drawing.Point(12, 62)
        Me.ListView2.MultiSelect = False
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(986, 206)
        Me.ListView2.TabIndex = 185
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.List
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(617, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(127, 13)
        Me.Label18.TabIndex = 184
        Me.Label18.Text = "Advance Value Allocation"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtPPaymentAdvanceTotal
        '
        Me.txtPPaymentAdvanceTotal.Location = New System.Drawing.Point(314, 35)
        Me.txtPPaymentAdvanceTotal.Name = "txtPPaymentAdvanceTotal"
        Me.txtPPaymentAdvanceTotal.ReadOnly = True
        Me.txtPPaymentAdvanceTotal.Size = New System.Drawing.Size(139, 21)
        Me.txtPPaymentAdvanceTotal.TabIndex = 180
        Me.txtPPaymentAdvanceTotal.TabStop = False
        Me.txtPPaymentAdvanceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAdvance
        '
        Me.btnAdvance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdvance.ImageIndex = 1
        Me.btnAdvance.ImageList = Me.ImageList1
        Me.btnAdvance.Location = New System.Drawing.Point(145, 32)
        Me.btnAdvance.Name = "btnAdvance"
        Me.btnAdvance.Size = New System.Drawing.Size(29, 25)
        Me.btnAdvance.TabIndex = 179
        Me.btnAdvance.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(359, 19)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(94, 13)
        Me.Label25.TabIndex = 178
        Me.Label25.Text = "Advance Payment"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(11, 19)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(128, 13)
        Me.Label26.TabIndex = 177
        Me.Label26.Text = "Advance Transaction No."
        '
        'txtPPaymentAdvanceNo
        '
        Me.txtPPaymentAdvanceNo.Location = New System.Drawing.Point(12, 35)
        Me.txtPPaymentAdvanceNo.Name = "txtPPaymentAdvanceNo"
        Me.txtPPaymentAdvanceNo.ReadOnly = True
        Me.txtPPaymentAdvanceNo.Size = New System.Drawing.Size(127, 21)
        Me.txtPPaymentAdvanceNo.TabIndex = 176
        '
        'ntbPPaymentAdvanceValue
        '
        Me.ntbPPaymentAdvanceValue.AllowSpace = False
        Me.ntbPPaymentAdvanceValue.Location = New System.Drawing.Point(604, 35)
        Me.ntbPPaymentAdvanceValue.Name = "ntbPPaymentAdvanceValue"
        Me.ntbPPaymentAdvanceValue.Size = New System.Drawing.Size(140, 21)
        Me.ntbPPaymentAdvanceValue.TabIndex = 183
        Me.ntbPPaymentAdvanceValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(952, 15)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(58, 13)
        Me.Label31.TabIndex = 158
        Me.Label31.Text = "Bank Code"
        '
        'txtBankCode
        '
        Me.txtBankCode.Location = New System.Drawing.Point(1030, 10)
        Me.txtBankCode.MaxLength = 50
        Me.txtBankCode.Name = "txtBankCode"
        Me.txtBankCode.ReadOnly = True
        Me.txtBankCode.Size = New System.Drawing.Size(127, 21)
        Me.txtBankCode.TabIndex = 13
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(916, 42)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(101, 13)
        Me.Label32.TabIndex = 160
        Me.Label32.Text = "Supplier Bank Detail"
        '
        'txtSBankDetail
        '
        Me.txtSBankDetail.Location = New System.Drawing.Point(1030, 38)
        Me.txtSBankDetail.Multiline = True
        Me.txtSBankDetail.Name = "txtSBankDetail"
        Me.txtSBankDetail.Size = New System.Drawing.Size(217, 51)
        Me.txtSBankDetail.TabIndex = 15
        '
        'chbIsPaymentBaseCurr
        '
        Me.chbIsPaymentBaseCurr.AutoSize = True
        Me.chbIsPaymentBaseCurr.Location = New System.Drawing.Point(611, 72)
        Me.chbIsPaymentBaseCurr.Name = "chbIsPaymentBaseCurr"
        Me.chbIsPaymentBaseCurr.Size = New System.Drawing.Size(152, 17)
        Me.chbIsPaymentBaseCurr.TabIndex = 10
        Me.chbIsPaymentBaseCurr.Text = "Payment in Base Currency"
        Me.chbIsPaymentBaseCurr.UseVisualStyleBackColor = True
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(515, 474)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(171, 13)
        Me.Label34.TabIndex = 165
        Me.Label34.Text = "Local Outstanding Invoice Amount"
        '
        'txtLocalPPaymentTotalOutstanding
        '
        Me.txtLocalPPaymentTotalOutstanding.Location = New System.Drawing.Point(696, 471)
        Me.txtLocalPPaymentTotalOutstanding.Name = "txtLocalPPaymentTotalOutstanding"
        Me.txtLocalPPaymentTotalOutstanding.ReadOnly = True
        Me.txtLocalPPaymentTotalOutstanding.Size = New System.Drawing.Size(140, 21)
        Me.txtLocalPPaymentTotalOutstanding.TabIndex = 18
        Me.txtLocalPPaymentTotalOutstanding.TabStop = False
        Me.txtLocalPPaymentTotalOutstanding.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(529, 553)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(157, 13)
        Me.Label35.TabIndex = 168
        Me.Label35.Text = "Local TOTAL AMOUNT PAID"
        '
        'txtLocalPPaymentTotalPaid
        '
        Me.txtLocalPPaymentTotalPaid.Location = New System.Drawing.Point(696, 550)
        Me.txtLocalPPaymentTotalPaid.Name = "txtLocalPPaymentTotalPaid"
        Me.txtLocalPPaymentTotalPaid.ReadOnly = True
        Me.txtLocalPPaymentTotalPaid.Size = New System.Drawing.Size(140, 21)
        Me.txtLocalPPaymentTotalPaid.TabIndex = 21
        Me.txtLocalPPaymentTotalPaid.TabStop = False
        Me.txtLocalPPaymentTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(551, 500)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(133, 13)
        Me.Label36.TabIndex = 170
        Me.Label36.Text = "Total Payment Conversion"
        '
        'txtPPaymentTotalConversion
        '
        Me.txtPPaymentTotalConversion.Location = New System.Drawing.Point(696, 497)
        Me.txtPPaymentTotalConversion.Name = "txtPPaymentTotalConversion"
        Me.txtPPaymentTotalConversion.ReadOnly = True
        Me.txtPPaymentTotalConversion.Size = New System.Drawing.Size(140, 21)
        Me.txtPPaymentTotalConversion.TabIndex = 19
        Me.txtPPaymentTotalConversion.TabStop = False
        Me.txtPPaymentTotalConversion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnBank
        '
        Me.btnBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBank.ImageIndex = 0
        Me.btnBank.ImageList = Me.ImageList1
        Me.btnBank.Location = New System.Drawing.Point(1163, 8)
        Me.btnBank.Name = "btnBank"
        Me.btnBank.Size = New System.Drawing.Size(29, 25)
        Me.btnBank.TabIndex = 14
        Me.btnBank.UseVisualStyleBackColor = True
        '
        'ntbPPaymentCurrRate
        '
        Me.ntbPPaymentCurrRate.AllowSpace = False
        Me.ntbPPaymentCurrRate.Location = New System.Drawing.Point(554, 95)
        Me.ntbPPaymentCurrRate.MaxLength = 10
        Me.ntbPPaymentCurrRate.Name = "ntbPPaymentCurrRate"
        Me.ntbPPaymentCurrRate.Size = New System.Drawing.Size(76, 21)
        Me.ntbPPaymentCurrRate.TabIndex = 11
        Me.ntbPPaymentCurrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbPPaymentTotalPaid
        '
        Me.ntbPPaymentTotalPaid.AllowSpace = False
        Me.ntbPPaymentTotalPaid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ntbPPaymentTotalPaid.Location = New System.Drawing.Point(1065, 550)
        Me.ntbPPaymentTotalPaid.Name = "ntbPPaymentTotalPaid"
        Me.ntbPPaymentTotalPaid.ReadOnly = True
        Me.ntbPPaymentTotalPaid.Size = New System.Drawing.Size(140, 21)
        Me.ntbPPaymentTotalPaid.TabIndex = 25
        Me.ntbPPaymentTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(14, 68)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(37, 13)
        Me.Label37.TabIndex = 174
        Me.Label37.Text = "Period"
        '
        'txtPeriodId
        '
        Me.txtPeriodId.Location = New System.Drawing.Point(158, 65)
        Me.txtPeriodId.Name = "txtPeriodId"
        Me.txtPeriodId.ReadOnly = True
        Me.txtPeriodId.Size = New System.Drawing.Size(97, 21)
        Me.txtPeriodId.TabIndex = 2
        '
        'frmPPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1263, 628)
        Me.Controls.Add(Me.txtPeriodId)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.btnBank)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.txtPPaymentTotalConversion)
        Me.Controls.Add(Me.txtLocalPPaymentTotalPaid)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.txtLocalPPaymentTotalOutstanding)
        Me.Controls.Add(Me.chbIsPaymentBaseCurr)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.txtSBankDetail)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtBankCode)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtPPaymentTotalAdvance)
        Me.Controls.Add(Me.txtPPaymentAdvanceAmount)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtPPaymentTotalAllocation)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPPaymentTotalOutstanding)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtCurrGainLossTotal)
        Me.Controls.Add(Me.txtCurrCode)
        Me.Controls.Add(Me.chbIsPaymentAdvance)
        Me.Controls.Add(Me.ntbPPaymentCurrRate)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ntbPPaymentTotalPaid)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtRefNo)
        Me.Controls.Add(Me.cmbPaymentMethod)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnSupplier)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtPPaymentRemarks)
        Me.Controls.Add(Me.txtSCode)
        Me.Controls.Add(Me.txtSName)
        Me.Controls.Add(Me.dtpPPaymentDate)
        Me.Controls.Add(Me.txtPPaymentNo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPPayment"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Payment"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPPaymentNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpPPaymentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSName As System.Windows.Forms.TextBox
    Friend WithEvents txtSCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPPaymentRemarks As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnSupplier As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents cmbPaymentMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ntbPPaymentCurrRate As levate.NumericTextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents chbIsPaymentAdvance As System.Windows.Forms.CheckBox
    Friend WithEvents txtCurrCode As System.Windows.Forms.TextBox
    Friend WithEvents ntbPPaymentTotalPaid As levate.NumericTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCurrGainLossTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPPaymentTotalOutstanding As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtPPaymentTotalAllocation As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtPPaymentAdvanceAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtPPaymentTotalAdvance As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ntbPPaymentAdvanceAllocation As levate.NumericTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPInvoiceCurrRate As System.Windows.Forms.TextBox
    Friend WithEvents txtPInvoiceCurrCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrGainLossValue As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLocalPInvoiceTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPInvoiceTotal As System.Windows.Forms.TextBox
    Friend WithEvents btnPInvoice As System.Windows.Forms.Button
    Friend WithEvents btnAddD1 As System.Windows.Forms.Button
    Friend WithEvents btnDeleteD1 As System.Windows.Forms.Button
    Friend WithEvents btnSaveD1 As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ntbPPaymentDtlValue As levate.NumericTextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnAddD2 As System.Windows.Forms.Button
    Friend WithEvents btnDeleteD2 As System.Windows.Forms.Button
    Friend WithEvents btnSaveD2 As System.Windows.Forms.Button
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ntbPPaymentAdvanceValue As levate.NumericTextBox
    Friend WithEvents txtPPaymentAdvanceTotal As System.Windows.Forms.TextBox
    Friend WithEvents btnAdvance As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtPPaymentAdvanceNo As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtPPaymentAdvanceCurrRate As System.Windows.Forms.TextBox
    Friend WithEvents txtPPaymentAdvanceCurrCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPPaymentPreviousAdvance As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtSBankDetail As System.Windows.Forms.TextBox
    Friend WithEvents chbIsPaymentBaseCurr As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ntbPPaymentDtlCurrRate As levate.NumericTextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtPPaymentConversionValue As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtLocalPPaymentTotalOutstanding As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtLocalPPaymentTotalPaid As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtPPaymentTotalConversion As System.Windows.Forms.TextBox
    Friend WithEvents btnBank As System.Windows.Forms.Button
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodId As System.Windows.Forms.TextBox

End Class
