﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptWorkOrderCostDetail
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnExpIncTo = New System.Windows.Forms.Button()
        Me.txtCostCodeTo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnExpIncFrom = New System.Windows.Forms.Button()
        Me.txtCostCodeFrom = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.chkConfirmInDate = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(177, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(254, 20)
        Me.Label6.TabIndex = 179
        Me.Label6.Text = "Work Order Cost Detail Report"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(220, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 200
        Me.Label5.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 199
        Me.Label2.Text = "From Date"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(127, 73)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(87, 20)
        Me.dtpFrom.TabIndex = 197
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(246, 72)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(87, 20)
        Me.dtpTo.TabIndex = 198
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(269, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(162, 13)
        Me.Label7.TabIndex = 213
        Me.Label7.Text = "To select all leave the field blank"
        '
        'btnExpIncTo
        '
        Me.btnExpIncTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpIncTo.ImageIndex = 0
        Me.btnExpIncTo.Location = New System.Drawing.Point(233, 130)
        Me.btnExpIncTo.Name = "btnExpIncTo"
        Me.btnExpIncTo.Size = New System.Drawing.Size(29, 25)
        Me.btnExpIncTo.TabIndex = 210
        Me.btnExpIncTo.Text = "..."
        Me.btnExpIncTo.UseVisualStyleBackColor = True
        '
        'txtCostCodeTo
        '
        Me.txtCostCodeTo.Location = New System.Drawing.Point(127, 132)
        Me.txtCostCodeTo.Name = "txtCostCodeTo"
        Me.txtCostCodeTo.Size = New System.Drawing.Size(100, 20)
        Me.txtCostCodeTo.TabIndex = 209
        Me.txtCostCodeTo.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(27, 136)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 212
        Me.Label8.Text = "To Cost Code"
        '
        'btnExpIncFrom
        '
        Me.btnExpIncFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpIncFrom.ImageIndex = 0
        Me.btnExpIncFrom.Location = New System.Drawing.Point(233, 101)
        Me.btnExpIncFrom.Name = "btnExpIncFrom"
        Me.btnExpIncFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnExpIncFrom.TabIndex = 208
        Me.btnExpIncFrom.Text = "..."
        Me.btnExpIncFrom.UseVisualStyleBackColor = True
        '
        'txtCostCodeFrom
        '
        Me.txtCostCodeFrom.Location = New System.Drawing.Point(127, 103)
        Me.txtCostCodeFrom.Name = "txtCostCodeFrom"
        Me.txtCostCodeFrom.Size = New System.Drawing.Size(100, 20)
        Me.txtCostCodeFrom.TabIndex = 207
        Me.txtCostCodeFrom.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(27, 107)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 13)
        Me.Label9.TabIndex = 211
        Me.Label9.Text = "From Cost Code"
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(208, 180)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 217
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(127, 180)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 216
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(33, 180)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 23)
        Me.btnPrint.TabIndex = 214
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'chkConfirmInDate
        '
        Me.chkConfirmInDate.AutoSize = True
        Me.chkConfirmInDate.Location = New System.Drawing.Point(340, 73)
        Me.chkConfirmInDate.Name = "chkConfirmInDate"
        Me.chkConfirmInDate.Size = New System.Drawing.Size(99, 17)
        Me.chkConfirmInDate.TabIndex = 218
        Me.chkConfirmInDate.Text = "Confirm In Date"
        Me.chkConfirmInDate.UseVisualStyleBackColor = True
        '
        'rptWorkOrderCostDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 219)
        Me.Controls.Add(Me.chkConfirmInDate)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnExpIncTo)
        Me.Controls.Add(Me.txtCostCodeTo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnExpIncFrom)
        Me.Controls.Add(Me.txtCostCodeFrom)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "rptWorkOrderCostDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Work Order Cost Detail Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnExpIncTo As System.Windows.Forms.Button
    Friend WithEvents txtCostCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnExpIncFrom As System.Windows.Forms.Button
    Friend WithEvents txtCostCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents chkConfirmInDate As System.Windows.Forms.CheckBox
End Class
