<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSupplierAdj
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSupplierAdj))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtCurrCode = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnSupplier = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.txtSCode = New System.Windows.Forms.TextBox()
        Me.txtSName = New System.Windows.Forms.TextBox()
        Me.txtRefNo = New System.Windows.Forms.TextBox()
        Me.dtpSupplierAdjDate = New System.Windows.Forms.DateTimePicker()
        Me.txtSupplierAdjNo = New System.Windows.Forms.TextBox()
        Me.cbRevaluation = New System.Windows.Forms.CheckBox()
        Me.ntbLocalAmount = New levate.NumericTextBox()
        Me.ntbAmount = New levate.NumericTextBox()
        Me.ntbPInvCurrRate = New levate.NumericTextBox()
        Me.SuspendLayout()
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
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(11, 211)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(72, 13)
        Me.Label34.TabIndex = 187
        Me.Label34.Text = "Local Amount"
        '
        'txtCurrCode
        '
        Me.txtCurrCode.Location = New System.Drawing.Point(181, 152)
        Me.txtCurrCode.Name = "txtCurrCode"
        Me.txtCurrCode.ReadOnly = True
        Me.txtCurrCode.Size = New System.Drawing.Size(50, 20)
        Me.txtCurrCode.TabIndex = 6
        Me.txtCurrCode.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(286, 155)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(30, 13)
        Me.Label28.TabIndex = 175
        Me.Label28.Text = "Rate"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(11, 156)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(77, 13)
        Me.Label27.TabIndex = 173
        Me.Label27.Text = "Currency Code"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(11, 129)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(76, 13)
        Me.Label21.TabIndex = 163
        Me.Label21.Text = "Supplier Name"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(465, 326)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 26)
        Me.btnPrint.TabIndex = 17
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnSupplier
        '
        Me.btnSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupplier.ImageIndex = 0
        Me.btnSupplier.ImageList = Me.ImageList1
        Me.btnSupplier.Location = New System.Drawing.Point(264, 95)
        Me.btnSupplier.Name = "btnSupplier"
        Me.btnSupplier.Size = New System.Drawing.Size(29, 25)
        Me.btnSupplier.TabIndex = 4
        Me.btnSupplier.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 243)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 155
        Me.Label12.Text = "Remarks"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 154
        Me.Label9.Text = "Ref. No."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 153
        Me.Label7.Text = "Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(150, 13)
        Me.Label6.TabIndex = 152
        Me.Label6.Text = "Supplier Adjustment No.*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 151
        Me.Label5.Text = "Amount"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "Supplier Code *"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(375, 326)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 26)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(105, 326)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(84, 26)
        Me.btnEdit.TabIndex = 13
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(195, 326)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnAdd.TabIndex = 14
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(15, 326)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 26)
        Me.btnDelete.TabIndex = 12
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(285, 326)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 26)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(181, 240)
        Me.txtRemarks.MaxLength = 255
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(365, 59)
        Me.txtRemarks.TabIndex = 11
        '
        'txtSCode
        '
        Me.txtSCode.Location = New System.Drawing.Point(181, 98)
        Me.txtSCode.Name = "txtSCode"
        Me.txtSCode.ReadOnly = True
        Me.txtSCode.Size = New System.Drawing.Size(80, 20)
        Me.txtSCode.TabIndex = 3
        Me.txtSCode.TabStop = False
        '
        'txtSName
        '
        Me.txtSName.Location = New System.Drawing.Point(181, 126)
        Me.txtSName.Name = "txtSName"
        Me.txtSName.ReadOnly = True
        Me.txtSName.Size = New System.Drawing.Size(217, 20)
        Me.txtSName.TabIndex = 5
        Me.txtSName.TabStop = False
        '
        'txtRefNo
        '
        Me.txtRefNo.Location = New System.Drawing.Point(181, 71)
        Me.txtRefNo.MaxLength = 50
        Me.txtRefNo.Name = "txtRefNo"
        Me.txtRefNo.Size = New System.Drawing.Size(365, 20)
        Me.txtRefNo.TabIndex = 2
        '
        'dtpSupplierAdjDate
        '
        Me.dtpSupplierAdjDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSupplierAdjDate.Location = New System.Drawing.Point(181, 43)
        Me.dtpSupplierAdjDate.Name = "dtpSupplierAdjDate"
        Me.dtpSupplierAdjDate.Size = New System.Drawing.Size(97, 20)
        Me.dtpSupplierAdjDate.TabIndex = 1
        '
        'txtSupplierAdjNo
        '
        Me.txtSupplierAdjNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplierAdjNo.Location = New System.Drawing.Point(181, 15)
        Me.txtSupplierAdjNo.MaxLength = 12
        Me.txtSupplierAdjNo.Name = "txtSupplierAdjNo"
        Me.txtSupplierAdjNo.Size = New System.Drawing.Size(365, 21)
        Me.txtSupplierAdjNo.TabIndex = 0
        '
        'cbRevaluation
        '
        Me.cbRevaluation.AutoSize = True
        Me.cbRevaluation.Location = New System.Drawing.Point(405, 211)
        Me.cbRevaluation.Name = "cbRevaluation"
        Me.cbRevaluation.Size = New System.Drawing.Size(112, 17)
        Me.cbRevaluation.TabIndex = 10
        Me.cbRevaluation.Text = "Local Revaluation"
        Me.cbRevaluation.UseVisualStyleBackColor = True
        '
        'ntbLocalAmount
        '
        Me.ntbLocalAmount.AllowSpace = False
        Me.ntbLocalAmount.Location = New System.Drawing.Point(181, 208)
        Me.ntbLocalAmount.MaxLength = 18
        Me.ntbLocalAmount.Name = "ntbLocalAmount"
        Me.ntbLocalAmount.Size = New System.Drawing.Size(217, 20)
        Me.ntbLocalAmount.TabIndex = 9
        Me.ntbLocalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbAmount
        '
        Me.ntbAmount.AllowSpace = False
        Me.ntbAmount.Location = New System.Drawing.Point(181, 181)
        Me.ntbAmount.MaxLength = 18
        Me.ntbAmount.Name = "ntbAmount"
        Me.ntbAmount.Size = New System.Drawing.Size(217, 20)
        Me.ntbAmount.TabIndex = 8
        Me.ntbAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ntbPInvCurrRate
        '
        Me.ntbPInvCurrRate.AllowSpace = False
        Me.ntbPInvCurrRate.Location = New System.Drawing.Point(322, 153)
        Me.ntbPInvCurrRate.MaxLength = 10
        Me.ntbPInvCurrRate.Name = "ntbPInvCurrRate"
        Me.ntbPInvCurrRate.Size = New System.Drawing.Size(76, 20)
        Me.ntbPInvCurrRate.TabIndex = 7
        Me.ntbPInvCurrRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmSupplierAdj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 364)
        Me.Controls.Add(Me.cbRevaluation)
        Me.Controls.Add(Me.ntbLocalAmount)
        Me.Controls.Add(Me.ntbAmount)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.txtCurrCode)
        Me.Controls.Add(Me.ntbPInvCurrRate)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnSupplier)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.txtSCode)
        Me.Controls.Add(Me.txtSName)
        Me.Controls.Add(Me.txtRefNo)
        Me.Controls.Add(Me.dtpSupplierAdjDate)
        Me.Controls.Add(Me.txtSupplierAdjNo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSupplierAdj"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Supplier Adjustment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtCurrCode As System.Windows.Forms.TextBox
    Friend WithEvents ntbPInvCurrRate As levate.NumericTextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnSupplier As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtSCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSName As System.Windows.Forms.TextBox
    Friend WithEvents txtRefNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpSupplierAdjDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSupplierAdjNo As System.Windows.Forms.TextBox
    Friend WithEvents ntbAmount As levate.NumericTextBox
    Friend WithEvents ntbLocalAmount As levate.NumericTextBox
    Friend WithEvents cbRevaluation As System.Windows.Forms.CheckBox
End Class
