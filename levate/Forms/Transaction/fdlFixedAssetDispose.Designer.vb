<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fdlFixedAssetDispose
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fdlFixedAssetDispose))
        Me.ntbBookValue = New levate.NumericTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFixedAssetCode = New System.Windows.Forms.TextBox()
        Me.txtFixedAssetName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ntbDisposeValue = New levate.NumericTextBox()
        Me.dtpDisposeDate = New System.Windows.Forms.DateTimePicker()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btnDispose = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ntbBookValue
        '
        Me.ntbBookValue.AllowSpace = False
        Me.ntbBookValue.Location = New System.Drawing.Point(128, 65)
        Me.ntbBookValue.MaxLength = 18
        Me.ntbBookValue.Name = "ntbBookValue"
        Me.ntbBookValue.ReadOnly = True
        Me.ntbBookValue.Size = New System.Drawing.Size(249, 20)
        Me.ntbBookValue.TabIndex = 166
        Me.ntbBookValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 167
        Me.Label7.Text = "Book Value"
        '
        'txtFixedAssetCode
        '
        Me.txtFixedAssetCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFixedAssetCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFixedAssetCode.Location = New System.Drawing.Point(129, 11)
        Me.txtFixedAssetCode.MaxLength = 50
        Me.txtFixedAssetCode.Name = "txtFixedAssetCode"
        Me.txtFixedAssetCode.ReadOnly = True
        Me.txtFixedAssetCode.Size = New System.Drawing.Size(249, 21)
        Me.txtFixedAssetCode.TabIndex = 168
        '
        'txtFixedAssetName
        '
        Me.txtFixedAssetName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFixedAssetName.Location = New System.Drawing.Point(129, 38)
        Me.txtFixedAssetName.MaxLength = 50
        Me.txtFixedAssetName.Name = "txtFixedAssetName"
        Me.txtFixedAssetName.ReadOnly = True
        Me.txtFixedAssetName.Size = New System.Drawing.Size(249, 21)
        Me.txtFixedAssetName.TabIndex = 169
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Fixed Asset Code*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 171
        Me.Label2.Text = "Fixed Asset Name *"
        '
        'ntbDisposeValue
        '
        Me.ntbDisposeValue.AllowSpace = False
        Me.ntbDisposeValue.Location = New System.Drawing.Point(128, 117)
        Me.ntbDisposeValue.MaxLength = 18
        Me.ntbDisposeValue.Name = "ntbDisposeValue"
        Me.ntbDisposeValue.Size = New System.Drawing.Size(249, 20)
        Me.ntbDisposeValue.TabIndex = 173
        Me.ntbDisposeValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpDisposeDate
        '
        Me.dtpDisposeDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDisposeDate.Location = New System.Drawing.Point(128, 91)
        Me.dtpDisposeDate.Name = "dtpDisposeDate"
        Me.dtpDisposeDate.Size = New System.Drawing.Size(97, 20)
        Me.dtpDisposeDate.TabIndex = 172
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(5, 120)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(73, 13)
        Me.Label18.TabIndex = 175
        Me.Label18.Text = "Dispose Value"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 96)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(70, 13)
        Me.Label17.TabIndex = 174
        Me.Label17.Text = "Dispose Date"
        '
        'btnDispose
        '
        Me.btnDispose.Location = New System.Drawing.Point(221, 160)
        Me.btnDispose.Name = "btnDispose"
        Me.btnDispose.Size = New System.Drawing.Size(75, 23)
        Me.btnDispose.TabIndex = 176
        Me.btnDispose.Text = "Dispose"
        Me.btnDispose.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(302, 160)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 177
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'fdlFixedAssetDispose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 211)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDispose)
        Me.Controls.Add(Me.ntbDisposeValue)
        Me.Controls.Add(Me.dtpDisposeDate)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtFixedAssetCode)
        Me.Controls.Add(Me.txtFixedAssetName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ntbBookValue)
        Me.Controls.Add(Me.Label7)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "fdlFixedAssetDispose"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fixed Asset Dispose"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ntbBookValue As levate.NumericTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFixedAssetCode As System.Windows.Forms.TextBox
    Friend WithEvents txtFixedAssetName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ntbDisposeValue As levate.NumericTextBox
    Friend WithEvents dtpDisposeDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnDispose As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
