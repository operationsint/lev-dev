<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSPayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSPayment))
        Me.txtSPaymentNo = New System.Windows.Forms.TextBox()
        Me.dtpSPaymentDate = New System.Windows.Forms.DateTimePicker()
        Me.txtCName = New System.Windows.Forms.TextBox()
        Me.txtCCode = New System.Windows.Forms.TextBox()
        Me.txtSPaymentRemarks = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnCustomer = New System.Windows.Forms.Button()
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
        Me.txtSPaymentTotalOutstanding = New System.Windows.Forms.TextBox()
        Me.chbIsPaymentBaseCurr = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtSPaymentTotalAllocation = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtSPaymentAdvanceAmount = New System.Windows.Forms.TextBox()
        Me.txtSPaymentTotalAdvance = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtSPaymentConversionValue = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ntbSPaymentDtlCurrRate = New levate.NumericTextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ntbSPaymentAdvanceAllocation = New levate.NumericTextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSInvoiceCurrRate = New System.Windows.Forms.TextBox()
        Me.txtSInvoiceCurrCode = New System.Windows.Forms.TextBox()
        Me.txtCurrGainLossValue = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLocalSInvoiceTotal = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSInvoiceTotal = New System.Windows.Forms.TextBox()
        Me.btnSInvoice = New System.Windows.Forms.Button()
        Me.btnAddD1 = New System.Windows.Forms.Button()
        Me.btnDeleteD1 = New System.Windows.Forms.Button()
        Me.btnSaveD1 = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ntbSPaymentDtlValue = New levate.NumericTextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtSInvoiceNo = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtSPaymentPreviousAdvance = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtSPaymentAdvanceCurrRate = New System.Windows.Forms.TextBox()
        Me.txtSPaymentAdvanceCurrCode = New System.Windows.Forms.TextBox()
        Me.btnAddD2 = New System.Windows.Forms.Button()
        Me.btnDeleteD2 = New System.Windows.Forms.Button()
        Me.btnSaveD2 = New System.Windows.Forms.Button()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtSPaymentAdvanceTotal = New System.Windows.Forms.TextBox()
        Me.btnAdvance = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtSPaymentAdvanceNo = New System.Windows.Forms.TextBox()
        Me.ntbSPaymentAdvanceValue = New levate.NumericTextBox()
        Me.ntbSPaymentCurrRate = New levate.NumericTextBox()
        Me.ntbSPaymentTotalPaid = New levate.NumericTextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtCBankDetail = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtBankCode = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtPPaymentTotalConversion = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtLocalPPaymentTotalOutstanding = New System.Windows.Forms.TextBox()
        Me.txtLocalPPaymentTotalPaid = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.btnBank = New System.Windows.Forms.Button()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtPeriodId = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSPaymentNo
        '
        Me.txtSPaymentNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSPaymentNo.Location = New System.Drawing.Point(158, 12)
        Me.txtSPaymentNo.MaxLength = 12
        Me.txtSPaymentNo.Name = "txtSPaymentNo"
        Me.txtSPaymentNo.Size = New System.Drawing.Size(127, 21)
        Me.txtSPaymentNo.TabIndex = 0
        '
        'dtpSPaymentDate
        '
        Me.dtpSPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSPaymentDate.Location = New System.Drawing.Point(158, 39)
        Me.dtpSPaymentDate.Name = "dtpSPaymentDate"
        Me.dtpSPaymentDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpSPaymentDate.TabIndex = 1
        '
        'txtCName
        '
        Me.txtCName.Location = New System.Drawing.Point(560, 39)
        Me.txtCName.Name = "txtCName"
        Me.txtCName.ReadOnly = True
        Me.txtCName.Size = New System.Drawing.Size(217, 21)
        Me.txtCName.TabIndex = 8
        '
        'txtCCode
        '
        Me.txtCCode.Location = New System.Drawing.Point(560, 12)
        Me.txtCCode.Name = "txtCCode"
        Me.txtCCode.ReadOnly = True
        Me.txtCCode.Size = New System.Drawing.Size(80, 21)
        Me.txtCCode.TabIndex = 5
        '
        'txtSPaymentRemarks
        '
        Me.txtSPaymentRemarks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtSPaymentRemarks.Location = New System.Drawing.Point(75, 457)
        Me.txtSPaymentRemarks.MaxLength = 255
        Me.txtSPaymentRemarks.Multiline = True
        Me.txtSPaymentRemarks.Name = "txtSPaymentRemarks"
        Me.txtSPaymentRemarks.Size = New System.Drawing.Size(318, 59)
        Me.txtSPaymentRemarks.TabIndex = 17
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(1077, 590)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 26)
        Me.btnCancel.TabIndex = 30
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(807, 590)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(84, 26)
        Me.btnEdit.TabIndex = 27
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(897, 590)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnAdd.TabIndex = 28
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(717, 590)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 26)
        Me.btnDelete.TabIndex = 26
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(987, 590)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 26)
        Me.btnSave.TabIndex = 29
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(451, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Customer Code*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Sales Receipt No.*"
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
        Me.Label12.Location = New System.Drawing.Point(15, 457)
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
        Me.btnCustomer.Location = New System.Drawing.Point(646, 9)
        Me.btnCustomer.Name = "btnCustomer"
        Me.btnCustomer.Size = New System.Drawing.Size(29, 25)
        Me.btnCustomer.TabIndex = 6
        Me.btnCustomer.UseVisualStyleBackColor = True
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
        Me.btnPrint.Location = New System.Drawing.Point(1167, 590)
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
        Me.Label2.Location = New System.Drawing.Point(15, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Payment Method"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 120)
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
        Me.Label3.Location = New System.Drawing.Point(451, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Customer Name"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(452, 95)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(77, 13)
        Me.Label28.TabIndex = 85
        Me.Label28.Text = "Currency Rate"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(452, 70)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(79, 13)
        Me.Label27.TabIndex = 83
        Me.Label27.Text = "Currency Code"
        '
        'chbIsPaymentAdvance
        '
        Me.chbIsPaymentAdvance.AutoSize = True
        Me.chbIsPaymentAdvance.Location = New System.Drawing.Point(683, 14)
        Me.chbIsPaymentAdvance.Name = "chbIsPaymentAdvance"
        Me.chbIsPaymentAdvance.Size = New System.Drawing.Size(107, 17)
        Me.chbIsPaymentAdvance.TabIndex = 7
        Me.chbIsPaymentAdvance.Text = "Advance Receipt"
        Me.chbIsPaymentAdvance.UseVisualStyleBackColor = True
        '
        'txtCurrCode
        '
        Me.txtCurrCode.Location = New System.Drawing.Point(560, 67)
        Me.txtCurrCode.Name = "txtCurrCode"
        Me.txtCurrCode.ReadOnly = True
        Me.txtCurrCode.Size = New System.Drawing.Size(50, 21)
        Me.txtCurrCode.TabIndex = 9
        Me.txtCurrCode.TabStop = False
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(931, 499)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 13)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "Total Invoice Allocated"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(891, 525)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(162, 13)
        Me.Label14.TabIndex = 114
        Me.Label14.Text = "Total Advance Receipt Allocated"
        '
        'txtCurrGainLossTotal
        '
        Me.txtCurrGainLossTotal.Location = New System.Drawing.Point(696, 525)
        Me.txtCurrGainLossTotal.Name = "txtCurrGainLossTotal"
        Me.txtCurrGainLossTotal.ReadOnly = True
        Me.txtCurrGainLossTotal.Size = New System.Drawing.Size(140, 21)
        Me.txtCurrGainLossTotal.TabIndex = 20
        Me.txtCurrGainLossTotal.TabStop = False
        Me.txtCurrGainLossTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(549, 528)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(127, 13)
        Me.Label20.TabIndex = 116
        Me.Label20.Text = "Currency Gain/Loss Total"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(911, 473)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 13)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "Outstanding Invoice Amount"
        '
        'txtSPaymentTotalOutstanding
        '
        Me.txtSPaymentTotalOutstanding.Location = New System.Drawing.Point(1065, 470)
        Me.txtSPaymentTotalOutstanding.Name = "txtSPaymentTotalOutstanding"
        Me.txtSPaymentTotalOutstanding.ReadOnly = True
        Me.txtSPaymentTotalOutstanding.Size = New System.Drawing.Size(140, 21)
        Me.txtSPaymentTotalOutstanding.TabIndex = 22
        Me.txtSPaymentTotalOutstanding.TabStop = False
        Me.txtSPaymentTotalOutstanding.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbIsPaymentBaseCurr
        '
        Me.chbIsPaymentBaseCurr.AutoSize = True
        Me.chbIsPaymentBaseCurr.Location = New System.Drawing.Point(616, 70)
        Me.chbIsPaymentBaseCurr.Name = "chbIsPaymentBaseCurr"
        Me.chbIsPaymentBaseCurr.Size = New System.Drawing.Size(152, 17)
        Me.chbIsPaymentBaseCurr.TabIndex = 10
        Me.chbIsPaymentBaseCurr.Text = "Payment in Base Currency"
        Me.chbIsPaymentBaseCurr.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(931, 552)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(125, 13)
        Me.Label21.TabIndex = 149
        Me.Label21.Text = "TOTAL AMOUNT PAID"
        '
        'txtSPaymentTotalAllocation
        '
        Me.txtSPaymentTotalAllocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSPaymentTotalAllocation.Location = New System.Drawing.Point(1065, 496)
        Me.txtSPaymentTotalAllocation.Name = "txtSPaymentTotalAllocation"
        Me.txtSPaymentTotalAllocation.ReadOnly = True
        Me.txtSPaymentTotalAllocation.Size = New System.Drawing.Size(140, 21)
        Me.txtSPaymentTotalAllocation.TabIndex = 23
        Me.txtSPaymentTotalAllocation.TabStop = False
        Me.txtSPaymentTotalAllocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(401, 125)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(142, 13)
        Me.Label22.TabIndex = 151
        Me.Label22.Text = "Advance Receipt to Allocate"
        '
        'txtSPaymentAdvanceAmount
        '
        Me.txtSPaymentAdvanceAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSPaymentAdvanceAmount.Location = New System.Drawing.Point(560, 122)
        Me.txtSPaymentAdvanceAmount.Name = "txtSPaymentAdvanceAmount"
        Me.txtSPaymentAdvanceAmount.ReadOnly = True
        Me.txtSPaymentAdvanceAmount.Size = New System.Drawing.Size(140, 21)
        Me.txtSPaymentAdvanceAmount.TabIndex = 12
        Me.txtSPaymentAdvanceAmount.TabStop = False
        Me.txtSPaymentAdvanceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSPaymentTotalAdvance
        '
        Me.txtSPaymentTotalAdvance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSPaymentTotalAdvance.Location = New System.Drawing.Point(1065, 522)
        Me.txtSPaymentTotalAdvance.Name = "txtSPaymentTotalAdvance"
        Me.txtSPaymentTotalAdvance.ReadOnly = True
        Me.txtSPaymentTotalAdvance.Size = New System.Drawing.Size(140, 21)
        Me.txtSPaymentTotalAdvance.TabIndex = 24
        Me.txtSPaymentTotalAdvance.TabStop = False
        Me.txtSPaymentTotalAdvance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 149)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1239, 306)
        Me.TabControl1.TabIndex = 16
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtSPaymentConversionValue)
        Me.TabPage1.Controls.Add(Me.Label33)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.ntbSPaymentDtlCurrRate)
        Me.TabPage1.Controls.Add(Me.Label23)
        Me.TabPage1.Controls.Add(Me.ntbSPaymentAdvanceAllocation)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtSInvoiceCurrRate)
        Me.TabPage1.Controls.Add(Me.txtSInvoiceCurrCode)
        Me.TabPage1.Controls.Add(Me.txtCurrGainLossValue)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtLocalSInvoiceTotal)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtSInvoiceTotal)
        Me.TabPage1.Controls.Add(Me.btnSInvoice)
        Me.TabPage1.Controls.Add(Me.btnAddD1)
        Me.TabPage1.Controls.Add(Me.btnDeleteD1)
        Me.TabPage1.Controls.Add(Me.btnSaveD1)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.ntbSPaymentDtlValue)
        Me.TabPage1.Controls.Add(Me.ListView1)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.txtSInvoiceNo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1231, 280)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Line"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtSPaymentConversionValue
        '
        Me.txtSPaymentConversionValue.Location = New System.Drawing.Point(888, 34)
        Me.txtSPaymentConversionValue.Name = "txtSPaymentConversionValue"
        Me.txtSPaymentConversionValue.ReadOnly = True
        Me.txtSPaymentConversionValue.Size = New System.Drawing.Size(120, 21)
        Me.txtSPaymentConversionValue.TabIndex = 9
        Me.txtSPaymentConversionValue.TabStop = False
        Me.txtSPaymentConversionValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(898, 6)
        Me.Label33.Name = "Label33"
        Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label33.Size = New System.Drawing.Size(106, 26)
        Me.Label33.TabIndex = 183
        Me.Label33.Text = "Payment Conversion" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Value"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(678, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(77, 26)
        Me.Label17.TabIndex = 182
        Me.Label17.Text = "Payment" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Currency Rate"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ntbSPaymentDtlCurrRate
        '
        Me.ntbSPaymentDtlCurrRate.AllowSpace = False
        Me.ntbSPaymentDtlCurrRate.Location = New System.Drawing.Point(661, 34)
        Me.ntbSPaymentDtlCurrRate.MaxLength = 10
        Me.ntbSPaymentDtlCurrRate.Name = "ntbSPaymentDtlCurrRate"
        Me.ntbSPaymentDtlCurrRate.ReadOnly = True
        Me.ntbSPaymentDtlCurrRate.Size = New System.Drawing.Size(94, 21)
        Me.ntbSPaymentDtlCurrRate.TabIndex = 7
        Me.ntbSPaymentDtlCurrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(567, 5)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(88, 26)
        Me.Label23.TabIndex = 175
        Me.Label23.Text = "Advance Receipt" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Allocation"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ntbSPaymentAdvanceAllocation
        '
        Me.ntbSPaymentAdvanceAllocation.AllowSpace = False
        Me.ntbSPaymentAdvanceAllocation.Location = New System.Drawing.Point(535, 34)
        Me.ntbSPaymentAdvanceAllocation.Name = "ntbSPaymentAdvanceAllocation"
        Me.ntbSPaymentAdvanceAllocation.Size = New System.Drawing.Size(120, 21)
        Me.ntbSPaymentAdvanceAllocation.TabIndex = 6
        Me.ntbSPaymentAdvanceAllocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(240, 18)
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
        'txtSInvoiceCurrRate
        '
        Me.txtSInvoiceCurrRate.Location = New System.Drawing.Point(234, 34)
        Me.txtSInvoiceCurrRate.Name = "txtSInvoiceCurrRate"
        Me.txtSInvoiceCurrRate.ReadOnly = True
        Me.txtSInvoiceCurrRate.Size = New System.Drawing.Size(74, 21)
        Me.txtSInvoiceCurrRate.TabIndex = 3
        Me.txtSInvoiceCurrRate.TabStop = False
        Me.txtSInvoiceCurrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSInvoiceCurrCode
        '
        Me.txtSInvoiceCurrCode.Location = New System.Drawing.Point(178, 34)
        Me.txtSInvoiceCurrCode.Name = "txtSInvoiceCurrCode"
        Me.txtSInvoiceCurrCode.ReadOnly = True
        Me.txtSInvoiceCurrCode.Size = New System.Drawing.Size(50, 21)
        Me.txtSInvoiceCurrCode.TabIndex = 2
        Me.txtSInvoiceCurrCode.TabStop = False
        '
        'txtCurrGainLossValue
        '
        Me.txtCurrGainLossValue.Location = New System.Drawing.Point(1014, 34)
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
        Me.Label4.Location = New System.Drawing.Point(1024, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 168
        Me.Label4.Text = "Currency Gain/Loss"
        '
        'txtLocalSInvoiceTotal
        '
        Me.txtLocalSInvoiceTotal.Location = New System.Drawing.Point(425, 34)
        Me.txtLocalSInvoiceTotal.Name = "txtLocalSInvoiceTotal"
        Me.txtLocalSInvoiceTotal.ReadOnly = True
        Me.txtLocalSInvoiceTotal.Size = New System.Drawing.Size(105, 21)
        Me.txtLocalSInvoiceTotal.TabIndex = 5
        Me.txtLocalSInvoiceTotal.TabStop = False
        Me.txtLocalSInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(437, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 13)
        Me.Label13.TabIndex = 166
        Me.Label13.Text = "Local Outstanding"
        '
        'txtSInvoiceTotal
        '
        Me.txtSInvoiceTotal.Location = New System.Drawing.Point(314, 34)
        Me.txtSInvoiceTotal.Name = "txtSInvoiceTotal"
        Me.txtSInvoiceTotal.ReadOnly = True
        Me.txtSInvoiceTotal.Size = New System.Drawing.Size(105, 21)
        Me.txtSInvoiceTotal.TabIndex = 4
        Me.txtSInvoiceTotal.TabStop = False
        Me.txtSInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSInvoice
        '
        Me.btnSInvoice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSInvoice.ImageIndex = 1
        Me.btnSInvoice.ImageList = Me.ImageList1
        Me.btnSInvoice.Location = New System.Drawing.Point(145, 32)
        Me.btnSInvoice.Name = "btnSInvoice"
        Me.btnSInvoice.Size = New System.Drawing.Size(29, 25)
        Me.btnSInvoice.TabIndex = 1
        Me.btnSInvoice.UseVisualStyleBackColor = True
        '
        'btnAddD1
        '
        Me.btnAddD1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD1.ImageIndex = 4
        Me.btnAddD1.ImageList = Me.ImageList1
        Me.btnAddD1.Location = New System.Drawing.Point(1194, 31)
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
        Me.btnDeleteD1.Location = New System.Drawing.Point(1162, 31)
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
        Me.btnSaveD1.Location = New System.Drawing.Point(1130, 31)
        Me.btnSaveD1.Name = "btnSaveD1"
        Me.btnSaveD1.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD1.TabIndex = 11
        Me.btnSaveD1.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(326, 19)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(93, 13)
        Me.Label19.TabIndex = 160
        Me.Label19.Text = "Total Outstanding"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(804, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 13)
        Me.Label11.TabIndex = 159
        Me.Label11.Text = "Payment Value"
        '
        'ntbSPaymentDtlValue
        '
        Me.ntbSPaymentDtlValue.AllowSpace = False
        Me.ntbSPaymentDtlValue.Location = New System.Drawing.Point(762, 34)
        Me.ntbSPaymentDtlValue.Name = "ntbSPaymentDtlValue"
        Me.ntbSPaymentDtlValue.Size = New System.Drawing.Size(120, 21)
        Me.ntbSPaymentDtlValue.TabIndex = 8
        Me.ntbSPaymentDtlValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ListView1
        '
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 62)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1211, 206)
        Me.ListView1.TabIndex = 14
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 13)
        Me.Label15.TabIndex = 156
        Me.Label15.Text = "Sales Invoice No."
        '
        'txtSInvoiceNo
        '
        Me.txtSInvoiceNo.Location = New System.Drawing.Point(12, 35)
        Me.txtSInvoiceNo.Name = "txtSInvoiceNo"
        Me.txtSInvoiceNo.ReadOnly = True
        Me.txtSInvoiceNo.Size = New System.Drawing.Size(127, 21)
        Me.txtSInvoiceNo.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtSPaymentPreviousAdvance)
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.Label29)
        Me.TabPage2.Controls.Add(Me.Label30)
        Me.TabPage2.Controls.Add(Me.txtSPaymentAdvanceCurrRate)
        Me.TabPage2.Controls.Add(Me.txtSPaymentAdvanceCurrCode)
        Me.TabPage2.Controls.Add(Me.btnAddD2)
        Me.TabPage2.Controls.Add(Me.btnDeleteD2)
        Me.TabPage2.Controls.Add(Me.btnSaveD2)
        Me.TabPage2.Controls.Add(Me.ListView2)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.txtSPaymentAdvanceTotal)
        Me.TabPage2.Controls.Add(Me.btnAdvance)
        Me.TabPage2.Controls.Add(Me.Label25)
        Me.TabPage2.Controls.Add(Me.Label26)
        Me.TabPage2.Controls.Add(Me.txtSPaymentAdvanceNo)
        Me.TabPage2.Controls.Add(Me.ntbSPaymentAdvanceValue)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1231, 280)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Advance Receipt Allocation"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtSPaymentPreviousAdvance
        '
        Me.txtSPaymentPreviousAdvance.Location = New System.Drawing.Point(459, 35)
        Me.txtSPaymentPreviousAdvance.Name = "txtSPaymentPreviousAdvance"
        Me.txtSPaymentPreviousAdvance.ReadOnly = True
        Me.txtSPaymentPreviousAdvance.Size = New System.Drawing.Size(139, 21)
        Me.txtSPaymentPreviousAdvance.TabIndex = 194
        Me.txtSPaymentPreviousAdvance.TabStop = False
        Me.txtSPaymentPreviousAdvance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtSPaymentAdvanceCurrRate
        '
        Me.txtSPaymentAdvanceCurrRate.Location = New System.Drawing.Point(234, 35)
        Me.txtSPaymentAdvanceCurrRate.Name = "txtSPaymentAdvanceCurrRate"
        Me.txtSPaymentAdvanceCurrRate.ReadOnly = True
        Me.txtSPaymentAdvanceCurrRate.Size = New System.Drawing.Size(74, 21)
        Me.txtSPaymentAdvanceCurrRate.TabIndex = 190
        Me.txtSPaymentAdvanceCurrRate.TabStop = False
        Me.txtSPaymentAdvanceCurrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSPaymentAdvanceCurrCode
        '
        Me.txtSPaymentAdvanceCurrCode.Location = New System.Drawing.Point(178, 35)
        Me.txtSPaymentAdvanceCurrCode.Name = "txtSPaymentAdvanceCurrCode"
        Me.txtSPaymentAdvanceCurrCode.ReadOnly = True
        Me.txtSPaymentAdvanceCurrCode.Size = New System.Drawing.Size(50, 21)
        Me.txtSPaymentAdvanceCurrCode.TabIndex = 189
        Me.txtSPaymentAdvanceCurrCode.TabStop = False
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
        'txtSPaymentAdvanceTotal
        '
        Me.txtSPaymentAdvanceTotal.Location = New System.Drawing.Point(314, 35)
        Me.txtSPaymentAdvanceTotal.Name = "txtSPaymentAdvanceTotal"
        Me.txtSPaymentAdvanceTotal.ReadOnly = True
        Me.txtSPaymentAdvanceTotal.Size = New System.Drawing.Size(139, 21)
        Me.txtSPaymentAdvanceTotal.TabIndex = 180
        Me.txtSPaymentAdvanceTotal.TabStop = False
        Me.txtSPaymentAdvanceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.Label25.Size = New System.Drawing.Size(88, 13)
        Me.Label25.TabIndex = 178
        Me.Label25.Text = "Advance Receipt"
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
        'txtSPaymentAdvanceNo
        '
        Me.txtSPaymentAdvanceNo.Location = New System.Drawing.Point(12, 35)
        Me.txtSPaymentAdvanceNo.Name = "txtSPaymentAdvanceNo"
        Me.txtSPaymentAdvanceNo.ReadOnly = True
        Me.txtSPaymentAdvanceNo.Size = New System.Drawing.Size(127, 21)
        Me.txtSPaymentAdvanceNo.TabIndex = 176
        '
        'ntbSPaymentAdvanceValue
        '
        Me.ntbSPaymentAdvanceValue.AllowSpace = False
        Me.ntbSPaymentAdvanceValue.Location = New System.Drawing.Point(604, 35)
        Me.ntbSPaymentAdvanceValue.Name = "ntbSPaymentAdvanceValue"
        Me.ntbSPaymentAdvanceValue.Size = New System.Drawing.Size(140, 21)
        Me.ntbSPaymentAdvanceValue.TabIndex = 183
        Me.ntbSPaymentAdvanceValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSPaymentCurrRate
        '
        Me.ntbSPaymentCurrRate.AllowSpace = False
        Me.ntbSPaymentCurrRate.Location = New System.Drawing.Point(560, 94)
        Me.ntbSPaymentCurrRate.MaxLength = 10
        Me.ntbSPaymentCurrRate.Name = "ntbSPaymentCurrRate"
        Me.ntbSPaymentCurrRate.Size = New System.Drawing.Size(76, 21)
        Me.ntbSPaymentCurrRate.TabIndex = 11
        Me.ntbSPaymentCurrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbSPaymentTotalPaid
        '
        Me.ntbSPaymentTotalPaid.AllowSpace = False
        Me.ntbSPaymentTotalPaid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ntbSPaymentTotalPaid.Location = New System.Drawing.Point(1065, 549)
        Me.ntbSPaymentTotalPaid.Name = "ntbSPaymentTotalPaid"
        Me.ntbSPaymentTotalPaid.ReadOnly = True
        Me.ntbSPaymentTotalPaid.Size = New System.Drawing.Size(140, 21)
        Me.ntbSPaymentTotalPaid.TabIndex = 25
        Me.ntbSPaymentTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(903, 41)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(109, 13)
        Me.Label32.TabIndex = 164
        Me.Label32.Text = "Customer Bank Detail"
        '
        'txtCBankDetail
        '
        Me.txtCBankDetail.Location = New System.Drawing.Point(1017, 37)
        Me.txtCBankDetail.Multiline = True
        Me.txtCBankDetail.Name = "txtCBankDetail"
        Me.txtCBankDetail.Size = New System.Drawing.Size(217, 46)
        Me.txtCBankDetail.TabIndex = 15
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(939, 14)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(58, 13)
        Me.Label31.TabIndex = 162
        Me.Label31.Text = "Bank Code"
        '
        'txtBankCode
        '
        Me.txtBankCode.Location = New System.Drawing.Point(1017, 9)
        Me.txtBankCode.Name = "txtBankCode"
        Me.txtBankCode.ReadOnly = True
        Me.txtBankCode.Size = New System.Drawing.Size(127, 21)
        Me.txtBankCode.TabIndex = 13
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(549, 502)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(133, 13)
        Me.Label36.TabIndex = 174
        Me.Label36.Text = "Total Payment Conversion"
        '
        'txtPPaymentTotalConversion
        '
        Me.txtPPaymentTotalConversion.Location = New System.Drawing.Point(696, 499)
        Me.txtPPaymentTotalConversion.Name = "txtPPaymentTotalConversion"
        Me.txtPPaymentTotalConversion.ReadOnly = True
        Me.txtPPaymentTotalConversion.Size = New System.Drawing.Size(140, 21)
        Me.txtPPaymentTotalConversion.TabIndex = 19
        Me.txtPPaymentTotalConversion.TabStop = False
        Me.txtPPaymentTotalConversion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(511, 473)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(171, 13)
        Me.Label34.TabIndex = 172
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
        'txtLocalPPaymentTotalPaid
        '
        Me.txtLocalPPaymentTotalPaid.Location = New System.Drawing.Point(696, 552)
        Me.txtLocalPPaymentTotalPaid.Name = "txtLocalPPaymentTotalPaid"
        Me.txtLocalPPaymentTotalPaid.ReadOnly = True
        Me.txtLocalPPaymentTotalPaid.Size = New System.Drawing.Size(140, 21)
        Me.txtLocalPPaymentTotalPaid.TabIndex = 21
        Me.txtLocalPPaymentTotalPaid.TabStop = False
        Me.txtLocalPPaymentTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(518, 555)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(157, 13)
        Me.Label35.TabIndex = 176
        Me.Label35.Text = "Local TOTAL AMOUNT PAID"
        '
        'btnBank
        '
        Me.btnBank.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBank.ImageIndex = 0
        Me.btnBank.ImageList = Me.ImageList1
        Me.btnBank.Location = New System.Drawing.Point(1151, 6)
        Me.btnBank.Name = "btnBank"
        Me.btnBank.Size = New System.Drawing.Size(29, 25)
        Me.btnBank.TabIndex = 14
        Me.btnBank.UseVisualStyleBackColor = True
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(15, 70)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(37, 13)
        Me.Label37.TabIndex = 180
        Me.Label37.Text = "Period"
        '
        'txtPeriodId
        '
        Me.txtPeriodId.Location = New System.Drawing.Point(158, 66)
        Me.txtPeriodId.Name = "txtPeriodId"
        Me.txtPeriodId.ReadOnly = True
        Me.txtPeriodId.Size = New System.Drawing.Size(97, 21)
        Me.txtPeriodId.TabIndex = 2
        '
        'frmSPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1263, 628)
        Me.Controls.Add(Me.txtPeriodId)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.btnBank)
        Me.Controls.Add(Me.txtLocalPPaymentTotalPaid)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.txtPPaymentTotalConversion)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.txtLocalPPaymentTotalOutstanding)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtSPaymentTotalAdvance)
        Me.Controls.Add(Me.txtCBankDetail)
        Me.Controls.Add(Me.txtSPaymentAdvanceAmount)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtBankCode)
        Me.Controls.Add(Me.txtSPaymentTotalAllocation)
        Me.Controls.Add(Me.chbIsPaymentBaseCurr)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSPaymentTotalOutstanding)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtCurrGainLossTotal)
        Me.Controls.Add(Me.txtCurrCode)
        Me.Controls.Add(Me.chbIsPaymentAdvance)
        Me.Controls.Add(Me.ntbSPaymentCurrRate)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ntbSPaymentTotalPaid)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtRefNo)
        Me.Controls.Add(Me.cmbPaymentMethod)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnCustomer)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtSPaymentRemarks)
        Me.Controls.Add(Me.txtCCode)
        Me.Controls.Add(Me.txtCName)
        Me.Controls.Add(Me.dtpSPaymentDate)
        Me.Controls.Add(Me.txtSPaymentNo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSPayment"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Receipt"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSPaymentNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpSPaymentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCName As System.Windows.Forms.TextBox
    Friend WithEvents txtCCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSPaymentRemarks As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnCustomer As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents cmbPaymentMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ntbSPaymentCurrRate As levate.NumericTextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents chbIsPaymentAdvance As System.Windows.Forms.CheckBox
    Friend WithEvents txtCurrCode As System.Windows.Forms.TextBox
    Friend WithEvents ntbSPaymentTotalPaid As levate.NumericTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtCurrGainLossTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSPaymentTotalOutstanding As System.Windows.Forms.TextBox
    Friend WithEvents chbIsPaymentBaseCurr As System.Windows.Forms.CheckBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtSPaymentTotalAllocation As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtSPaymentAdvanceAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtSPaymentTotalAdvance As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ntbSPaymentAdvanceAllocation As levate.NumericTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSInvoiceCurrRate As System.Windows.Forms.TextBox
    Friend WithEvents txtSInvoiceCurrCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrGainLossValue As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLocalSInvoiceTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSInvoiceTotal As System.Windows.Forms.TextBox
    Friend WithEvents btnSInvoice As System.Windows.Forms.Button
    Friend WithEvents btnAddD1 As System.Windows.Forms.Button
    Friend WithEvents btnDeleteD1 As System.Windows.Forms.Button
    Friend WithEvents btnSaveD1 As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ntbSPaymentDtlValue As levate.NumericTextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnAddD2 As System.Windows.Forms.Button
    Friend WithEvents btnDeleteD2 As System.Windows.Forms.Button
    Friend WithEvents btnSaveD2 As System.Windows.Forms.Button
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ntbSPaymentAdvanceValue As levate.NumericTextBox
    Friend WithEvents txtSPaymentAdvanceTotal As System.Windows.Forms.TextBox
    Friend WithEvents btnAdvance As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtSPaymentAdvanceNo As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtSPaymentAdvanceCurrRate As System.Windows.Forms.TextBox
    Friend WithEvents txtSPaymentAdvanceCurrCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSPaymentPreviousAdvance As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtCBankDetail As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSPaymentConversionValue As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ntbSPaymentDtlCurrRate As levate.NumericTextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtPPaymentTotalConversion As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtLocalPPaymentTotalOutstanding As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalPPaymentTotalPaid As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents btnBank As System.Windows.Forms.Button
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodId As System.Windows.Forms.TextBox

End Class
