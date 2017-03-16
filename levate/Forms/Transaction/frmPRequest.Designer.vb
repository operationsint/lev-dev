<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPRequest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPRequest))
        Me.txtPRequestNo = New System.Windows.Forms.TextBox()
        Me.dtpPRequestDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.txtPORemarks = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnDeleteD = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnSaveD = New System.Windows.Forms.Button()
        Me.btnSKU = New System.Windows.Forms.Button()
        Me.cmbPRequestDtlType = New System.Windows.Forms.ComboBox()
        Me.txtSKUCode = New System.Windows.Forms.TextBox()
        Me.txtPRequestDtlDesc = New System.Windows.Forms.TextBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAddD = New System.Windows.Forms.Button()
        Me.txtSKUUoM = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPRequestStatus = New System.Windows.Forms.TextBox()
        Me.btnSubmitApproval = New System.Windows.Forms.Button()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.btnPchCode = New System.Windows.Forms.Button()
        Me.txtPchCode = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtLocationCode = New System.Windows.Forms.TextBox()
        Me.btnLocation = New System.Windows.Forms.Button()
        Me.cmbPRequester = New System.Windows.Forms.ComboBox()
        Me.btnCloseRequest = New System.Windows.Forms.Button()
        Me.lblClosedDescription = New System.Windows.Forms.Label()
        Me.btnReject = New System.Windows.Forms.Button()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.ntbPRequestQty = New levate.NumericTextBox()
        Me.SuspendLayout()
        '
        'txtPRequestNo
        '
        Me.txtPRequestNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRequestNo.Location = New System.Drawing.Point(154, 12)
        Me.txtPRequestNo.MaxLength = 50
        Me.txtPRequestNo.Name = "txtPRequestNo"
        Me.txtPRequestNo.Size = New System.Drawing.Size(127, 21)
        Me.txtPRequestNo.TabIndex = 0
        '
        'dtpPRequestDate
        '
        Me.dtpPRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPRequestDate.Location = New System.Drawing.Point(154, 40)
        Me.dtpPRequestDate.Name = "dtpPRequestDate"
        Me.dtpPRequestDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpPRequestDate.TabIndex = 1
        '
        'dtpDeliveryDate
        '
        Me.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDeliveryDate.Location = New System.Drawing.Point(154, 66)
        Me.dtpDeliveryDate.Name = "dtpDeliveryDate"
        Me.dtpDeliveryDate.Size = New System.Drawing.Size(97, 21)
        Me.dtpDeliveryDate.TabIndex = 2
        '
        'ListView1
        '
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 200)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(792, 216)
        Me.ListView1.TabIndex = 18
        Me.ListView1.TabStop = False
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'txtPORemarks
        '
        Me.txtPORemarks.Location = New System.Drawing.Point(72, 435)
        Me.txtPORemarks.MaxLength = 255
        Me.txtPORemarks.Multiline = True
        Me.txtPORemarks.Name = "txtPORemarks"
        Me.txtPORemarks.Size = New System.Drawing.Size(318, 59)
        Me.txtPORemarks.TabIndex = 19
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(630, 540)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 26)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(360, 540)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(84, 26)
        Me.btnEdit.TabIndex = 25
        Me.btnEdit.Text = "&Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(450, 540)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnAdd.TabIndex = 26
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(270, 540)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 26)
        Me.btnDelete.TabIndex = 24
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(540, 540)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 26)
        Me.btnSave.TabIndex = 27
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Purchase Request No.*"
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
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Required Date"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 435)
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
        Me.btnDeleteD.Location = New System.Drawing.Point(744, 168)
        Me.btnDeleteD.Name = "btnDeleteD"
        Me.btnDeleteD.Size = New System.Drawing.Size(29, 25)
        Me.btnDeleteD.TabIndex = 16
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
        Me.btnSaveD.Location = New System.Drawing.Point(713, 168)
        Me.btnSaveD.Name = "btnSaveD"
        Me.btnSaveD.Size = New System.Drawing.Size(29, 25)
        Me.btnSaveD.TabIndex = 15
        Me.btnSaveD.UseVisualStyleBackColor = True
        '
        'btnSKU
        '
        Me.btnSKU.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSKU.ImageIndex = 1
        Me.btnSKU.ImageList = Me.ImageList1
        Me.btnSKU.Location = New System.Drawing.Point(187, 169)
        Me.btnSKU.Name = "btnSKU"
        Me.btnSKU.Size = New System.Drawing.Size(29, 25)
        Me.btnSKU.TabIndex = 9
        Me.btnSKU.UseVisualStyleBackColor = True
        '
        'cmbPRequestDtlType
        '
        Me.cmbPRequestDtlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPRequestDtlType.FormattingEnabled = True
        Me.cmbPRequestDtlType.Location = New System.Drawing.Point(12, 171)
        Me.cmbPRequestDtlType.Name = "cmbPRequestDtlType"
        Me.cmbPRequestDtlType.Size = New System.Drawing.Size(88, 21)
        Me.cmbPRequestDtlType.TabIndex = 7
        '
        'txtSKUCode
        '
        Me.txtSKUCode.Location = New System.Drawing.Point(105, 171)
        Me.txtSKUCode.MaxLength = 50
        Me.txtSKUCode.Name = "txtSKUCode"
        Me.txtSKUCode.ReadOnly = True
        Me.txtSKUCode.Size = New System.Drawing.Size(80, 21)
        Me.txtSKUCode.TabIndex = 8
        Me.txtSKUCode.TabStop = False
        '
        'txtPRequestDtlDesc
        '
        Me.txtPRequestDtlDesc.Location = New System.Drawing.Point(219, 171)
        Me.txtPRequestDtlDesc.MaxLength = 100
        Me.txtPRequestDtlDesc.Name = "txtPRequestDtlDesc"
        Me.txtPRequestDtlDesc.Size = New System.Drawing.Size(246, 21)
        Me.txtPRequestDtlDesc.TabIndex = 10
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(720, 540)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 26)
        Me.btnPrint.TabIndex = 29
        Me.btnPrint.Text = "&Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(360, 70)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 13)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "Status"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 154)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 13)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "Line Type"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(106, 155)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 13)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Code*"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(223, 154)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 13)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "Line Description"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(616, 152)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(29, 13)
        Me.Label19.TabIndex = 60
        Me.Label19.Text = "Qty."
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(360, 41)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 13)
        Me.Label21.TabIndex = 62
        Me.Label21.Text = "Requester*"
        '
        'btnAddD
        '
        Me.btnAddD.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddD.ImageIndex = 4
        Me.btnAddD.ImageList = Me.ImageList1
        Me.btnAddD.Location = New System.Drawing.Point(775, 168)
        Me.btnAddD.Name = "btnAddD"
        Me.btnAddD.Size = New System.Drawing.Size(29, 25)
        Me.btnAddD.TabIndex = 17
        Me.btnAddD.UseVisualStyleBackColor = True
        '
        'txtSKUUoM
        '
        Me.txtSKUUoM.Location = New System.Drawing.Point(651, 171)
        Me.txtSKUUoM.Name = "txtSKUUoM"
        Me.txtSKUUoM.ReadOnly = True
        Me.txtSKUUoM.Size = New System.Drawing.Size(53, 21)
        Me.txtSKUUoM.TabIndex = 14
        Me.txtSKUUoM.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(675, 152)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(28, 13)
        Me.Label26.TabIndex = 73
        Me.Label26.Text = "UoM"
        '
        'txtPRequestStatus
        '
        Me.txtPRequestStatus.Location = New System.Drawing.Point(457, 66)
        Me.txtPRequestStatus.Name = "txtPRequestStatus"
        Me.txtPRequestStatus.ReadOnly = True
        Me.txtPRequestStatus.Size = New System.Drawing.Size(174, 21)
        Me.txtPRequestStatus.TabIndex = 6
        '
        'btnSubmitApproval
        '
        Me.btnSubmitApproval.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmitApproval.Location = New System.Drawing.Point(583, 431)
        Me.btnSubmitApproval.Name = "btnSubmitApproval"
        Me.btnSubmitApproval.Size = New System.Drawing.Size(131, 26)
        Me.btnSubmitApproval.TabIndex = 20
        Me.btnSubmitApproval.Text = "Submit for Approval"
        Me.btnSubmitApproval.UseVisualStyleBackColor = True
        '
        'btnVoid
        '
        Me.btnVoid.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoid.Location = New System.Drawing.Point(720, 431)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(84, 26)
        Me.btnVoid.TabIndex = 76
        Me.btnVoid.Text = "Void"
        Me.btnVoid.UseVisualStyleBackColor = True
        '
        'btnPchCode
        '
        Me.btnPchCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPchCode.ImageIndex = 0
        Me.btnPchCode.ImageList = Me.ImageList1
        Me.btnPchCode.Location = New System.Drawing.Point(540, 10)
        Me.btnPchCode.Name = "btnPchCode"
        Me.btnPchCode.Size = New System.Drawing.Size(29, 25)
        Me.btnPchCode.TabIndex = 4
        Me.btnPchCode.UseVisualStyleBackColor = True
        '
        'txtPchCode
        '
        Me.txtPchCode.Location = New System.Drawing.Point(457, 12)
        Me.txtPchCode.Name = "txtPchCode"
        Me.txtPchCode.ReadOnly = True
        Me.txtPchCode.Size = New System.Drawing.Size(80, 21)
        Me.txtPchCode.TabIndex = 3
        Me.txtPchCode.TabStop = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(360, 16)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(85, 13)
        Me.Label37.TabIndex = 110
        Me.Label37.Text = "Purchase Code*"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(471, 152)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(53, 13)
        Me.Label38.TabIndex = 118
        Me.Label38.Text = "Location*"
        '
        'txtLocationCode
        '
        Me.txtLocationCode.Location = New System.Drawing.Point(471, 171)
        Me.txtLocationCode.Name = "txtLocationCode"
        Me.txtLocationCode.ReadOnly = True
        Me.txtLocationCode.Size = New System.Drawing.Size(80, 21)
        Me.txtLocationCode.TabIndex = 11
        Me.txtLocationCode.TabStop = False
        '
        'btnLocation
        '
        Me.btnLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLocation.ImageIndex = 1
        Me.btnLocation.ImageList = Me.ImageList1
        Me.btnLocation.Location = New System.Drawing.Point(553, 169)
        Me.btnLocation.Name = "btnLocation"
        Me.btnLocation.Size = New System.Drawing.Size(29, 25)
        Me.btnLocation.TabIndex = 12
        Me.btnLocation.UseVisualStyleBackColor = True
        '
        'cmbPRequester
        '
        Me.cmbPRequester.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPRequester.FormattingEnabled = True
        Me.cmbPRequester.Location = New System.Drawing.Point(457, 39)
        Me.cmbPRequester.Name = "cmbPRequester"
        Me.cmbPRequester.Size = New System.Drawing.Size(217, 21)
        Me.cmbPRequester.TabIndex = 5
        '
        'btnCloseRequest
        '
        Me.btnCloseRequest.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseRequest.Location = New System.Drawing.Point(154, 540)
        Me.btnCloseRequest.Name = "btnCloseRequest"
        Me.btnCloseRequest.Size = New System.Drawing.Size(110, 26)
        Me.btnCloseRequest.TabIndex = 23
        Me.btnCloseRequest.Text = "Close Request"
        Me.btnCloseRequest.UseVisualStyleBackColor = True
        '
        'lblClosedDescription
        '
        Me.lblClosedDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClosedDescription.Location = New System.Drawing.Point(360, 101)
        Me.lblClosedDescription.Name = "lblClosedDescription"
        Me.lblClosedDescription.Size = New System.Drawing.Size(314, 17)
        Me.lblClosedDescription.TabIndex = 121
        Me.lblClosedDescription.Text = "This Request was CLOSED by"
        Me.lblClosedDescription.Visible = False
        '
        'btnReject
        '
        Me.btnReject.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReject.Location = New System.Drawing.Point(720, 431)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(84, 26)
        Me.btnReject.TabIndex = 22
        Me.btnReject.Text = "Reject"
        Me.btnReject.UseVisualStyleBackColor = True
        '
        'btnApprove
        '
        Me.btnApprove.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApprove.Location = New System.Drawing.Point(630, 431)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(84, 26)
        Me.btnApprove.TabIndex = 21
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = True
        '
        'ntbPRequestQty
        '
        Me.ntbPRequestQty.AllowSpace = False
        Me.ntbPRequestQty.Location = New System.Drawing.Point(588, 171)
        Me.ntbPRequestQty.MaxLength = 8
        Me.ntbPRequestQty.Name = "ntbPRequestQty"
        Me.ntbPRequestQty.Size = New System.Drawing.Size(57, 21)
        Me.ntbPRequestQty.TabIndex = 13
        Me.ntbPRequestQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmPRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 578)
        Me.Controls.Add(Me.btnReject)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.lblClosedDescription)
        Me.Controls.Add(Me.btnCloseRequest)
        Me.Controls.Add(Me.cmbPRequester)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.txtLocationCode)
        Me.Controls.Add(Me.btnLocation)
        Me.Controls.Add(Me.btnPchCode)
        Me.Controls.Add(Me.txtPchCode)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.btnVoid)
        Me.Controls.Add(Me.btnSubmitApproval)
        Me.Controls.Add(Me.txtPRequestStatus)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtSKUUoM)
        Me.Controls.Add(Me.btnAddD)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.ntbPRequestQty)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.txtPRequestDtlDesc)
        Me.Controls.Add(Me.txtSKUCode)
        Me.Controls.Add(Me.cmbPRequestDtlType)
        Me.Controls.Add(Me.btnSKU)
        Me.Controls.Add(Me.btnDeleteD)
        Me.Controls.Add(Me.btnSaveD)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtPORemarks)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.dtpDeliveryDate)
        Me.Controls.Add(Me.dtpPRequestDate)
        Me.Controls.Add(Me.txtPRequestNo)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmPRequest"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Request"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPRequestNo As System.Windows.Forms.TextBox
    Friend WithEvents dtpPRequestDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents txtPORemarks As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnDeleteD As System.Windows.Forms.Button
    Friend WithEvents btnSaveD As System.Windows.Forms.Button
    Friend WithEvents btnSKU As System.Windows.Forms.Button
    Friend WithEvents cmbPRequestDtlType As System.Windows.Forms.ComboBox
    Friend WithEvents txtSKUCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPRequestDtlDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ntbPRequestQty As levate.NumericTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnAddD As System.Windows.Forms.Button
    Friend WithEvents txtSKUUoM As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtPRequestStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnSubmitApproval As System.Windows.Forms.Button
    Friend WithEvents btnVoid As System.Windows.Forms.Button
    Friend WithEvents btnPchCode As System.Windows.Forms.Button
    Friend WithEvents txtPchCode As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtLocationCode As System.Windows.Forms.TextBox
    Friend WithEvents btnLocation As System.Windows.Forms.Button
    Friend WithEvents cmbPRequester As System.Windows.Forms.ComboBox
    Friend WithEvents btnCloseRequest As System.Windows.Forms.Button
    Friend WithEvents lblClosedDescription As System.Windows.Forms.Label
    Friend WithEvents btnReject As System.Windows.Forms.Button
    Friend WithEvents btnApprove As System.Windows.Forms.Button

End Class
