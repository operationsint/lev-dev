<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptBankList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptBankList))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBankCodeFrom = New System.Windows.Forms.TextBox()
        Me.btnBankFrom = New System.Windows.Forms.Button()
        Me.btnBankTo = New System.Windows.Forms.Button()
        Me.txtBankCodeTo = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCurrency = New System.Windows.Forms.Button()
        Me.txtCurrency = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(388, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 20)
        Me.Label8.TabIndex = 163
        Me.Label8.Text = "Bank List"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(243, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 13)
        Me.Label3.TabIndex = 162
        Me.Label3.Text = "Leave the field blank to select all"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(184, 168)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = "From Bank Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 154
        Me.Label2.Text = "To Bank Code"
        '
        'txtBankCodeFrom
        '
        Me.txtBankCodeFrom.Location = New System.Drawing.Point(107, 43)
        Me.txtBankCodeFrom.MaxLength = 50
        Me.txtBankCodeFrom.Name = "txtBankCodeFrom"
        Me.txtBankCodeFrom.Size = New System.Drawing.Size(95, 20)
        Me.txtBankCodeFrom.TabIndex = 0
        Me.txtBankCodeFrom.TabStop = False
        '
        'btnBankFrom
        '
        Me.btnBankFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBankFrom.ImageIndex = 0
        Me.btnBankFrom.Location = New System.Drawing.Point(208, 40)
        Me.btnBankFrom.Name = "btnBankFrom"
        Me.btnBankFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnBankFrom.TabIndex = 1
        Me.btnBankFrom.Text = "..."
        Me.btnBankFrom.UseVisualStyleBackColor = True
        '
        'btnBankTo
        '
        Me.btnBankTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBankTo.ImageIndex = 0
        Me.btnBankTo.Location = New System.Drawing.Point(208, 74)
        Me.btnBankTo.Name = "btnBankTo"
        Me.btnBankTo.Size = New System.Drawing.Size(29, 25)
        Me.btnBankTo.TabIndex = 3
        Me.btnBankTo.Text = "..."
        Me.btnBankTo.UseVisualStyleBackColor = True
        '
        'txtBankCodeTo
        '
        Me.txtBankCodeTo.Location = New System.Drawing.Point(107, 77)
        Me.txtBankCodeTo.MaxLength = 50
        Me.txtBankCodeTo.Name = "txtBankCodeTo"
        Me.txtBankCodeTo.Size = New System.Drawing.Size(95, 20)
        Me.txtBankCodeTo.TabIndex = 2
        Me.txtBankCodeTo.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(98, 168)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(12, 168)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(80, 23)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 164
        Me.Label4.Text = "Currency"
        '
        'btnCurrency
        '
        Me.btnCurrency.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCurrency.ImageIndex = 0
        Me.btnCurrency.Location = New System.Drawing.Point(208, 110)
        Me.btnCurrency.Name = "btnCurrency"
        Me.btnCurrency.Size = New System.Drawing.Size(29, 25)
        Me.btnCurrency.TabIndex = 5
        Me.btnCurrency.Text = "..."
        Me.btnCurrency.UseVisualStyleBackColor = True
        '
        'txtCurrency
        '
        Me.txtCurrency.Location = New System.Drawing.Point(107, 113)
        Me.txtCurrency.MaxLength = 50
        Me.txtCurrency.Name = "txtCurrency"
        Me.txtCurrency.Size = New System.Drawing.Size(95, 20)
        Me.txtCurrency.TabIndex = 4
        Me.txtCurrency.TabStop = False
        '
        'rptBankList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 203)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnCurrency)
        Me.Controls.Add(Me.txtCurrency)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBankCodeFrom)
        Me.Controls.Add(Me.btnBankFrom)
        Me.Controls.Add(Me.btnBankTo)
        Me.Controls.Add(Me.txtBankCodeTo)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPrint)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptBankList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bank List"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBankCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents btnBankFrom As System.Windows.Forms.Button
    Friend WithEvents btnBankTo As System.Windows.Forms.Button
    Friend WithEvents txtBankCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCurrency As System.Windows.Forms.Button
    Friend WithEvents txtCurrency As System.Windows.Forms.TextBox
End Class
