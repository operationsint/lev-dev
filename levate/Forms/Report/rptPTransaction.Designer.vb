<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptPTransaction
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptPTransaction))
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtRequest = New System.Windows.Forms.TextBox()
        Me.btnRequest = New System.Windows.Forms.Button()
        Me.btnOrder = New System.Windows.Forms.Button()
        Me.txtOrder = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnInvoice = New System.Windows.Forms.Button()
        Me.txtInvoice = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnIncoming = New System.Windows.Forms.Button()
        Me.txtIncoming = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnPayment = New System.Windows.Forms.Button()
        Me.txtPayment = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(174, 252)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(12, 252)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 10
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(93, 252)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(140, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(243, 20)
        Me.Label6.TabIndex = 171
        Me.Label6.Text = "Purchase Transaction Report"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 13)
        Me.Label9.TabIndex = 161
        Me.Label9.Text = "Purchase Request No."
        '
        'txtRequest
        '
        Me.txtRequest.Location = New System.Drawing.Point(144, 64)
        Me.txtRequest.Name = "txtRequest"
        Me.txtRequest.Size = New System.Drawing.Size(194, 20)
        Me.txtRequest.TabIndex = 0
        Me.txtRequest.TabStop = False
        '
        'btnRequest
        '
        Me.btnRequest.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRequest.ImageIndex = 0
        Me.btnRequest.Location = New System.Drawing.Point(346, 62)
        Me.btnRequest.Name = "btnRequest"
        Me.btnRequest.Size = New System.Drawing.Size(29, 25)
        Me.btnRequest.TabIndex = 1
        Me.btnRequest.Text = "..."
        Me.btnRequest.UseVisualStyleBackColor = True
        '
        'btnOrder
        '
        Me.btnOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrder.ImageIndex = 0
        Me.btnOrder.Location = New System.Drawing.Point(346, 97)
        Me.btnOrder.Name = "btnOrder"
        Me.btnOrder.Size = New System.Drawing.Size(29, 25)
        Me.btnOrder.TabIndex = 3
        Me.btnOrder.Text = "..."
        Me.btnOrder.UseVisualStyleBackColor = True
        '
        'txtOrder
        '
        Me.txtOrder.Location = New System.Drawing.Point(144, 99)
        Me.txtOrder.Name = "txtOrder"
        Me.txtOrder.Size = New System.Drawing.Size(194, 20)
        Me.txtOrder.TabIndex = 2
        Me.txtOrder.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "Purchase Order No."
        '
        'btnInvoice
        '
        Me.btnInvoice.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInvoice.ImageIndex = 0
        Me.btnInvoice.Location = New System.Drawing.Point(346, 169)
        Me.btnInvoice.Name = "btnInvoice"
        Me.btnInvoice.Size = New System.Drawing.Size(29, 25)
        Me.btnInvoice.TabIndex = 7
        Me.btnInvoice.Text = "..."
        Me.btnInvoice.UseVisualStyleBackColor = True
        '
        'txtInvoice
        '
        Me.txtInvoice.Location = New System.Drawing.Point(144, 171)
        Me.txtInvoice.Name = "txtInvoice"
        Me.txtInvoice.Size = New System.Drawing.Size(194, 20)
        Me.txtInvoice.TabIndex = 6
        Me.txtInvoice.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 178
        Me.Label2.Text = "Purchase Invoice No."
        '
        'btnIncoming
        '
        Me.btnIncoming.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncoming.ImageIndex = 0
        Me.btnIncoming.Location = New System.Drawing.Point(346, 134)
        Me.btnIncoming.Name = "btnIncoming"
        Me.btnIncoming.Size = New System.Drawing.Size(29, 25)
        Me.btnIncoming.TabIndex = 5
        Me.btnIncoming.Text = "..."
        Me.btnIncoming.UseVisualStyleBackColor = True
        '
        'txtIncoming
        '
        Me.txtIncoming.Location = New System.Drawing.Point(144, 136)
        Me.txtIncoming.Name = "txtIncoming"
        Me.txtIncoming.Size = New System.Drawing.Size(194, 20)
        Me.txtIncoming.TabIndex = 4
        Me.txtIncoming.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 13)
        Me.Label3.TabIndex = 175
        Me.Label3.Text = "Purchase Incoming No."
        '
        'btnPayment
        '
        Me.btnPayment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPayment.ImageIndex = 0
        Me.btnPayment.Location = New System.Drawing.Point(346, 206)
        Me.btnPayment.Name = "btnPayment"
        Me.btnPayment.Size = New System.Drawing.Size(29, 25)
        Me.btnPayment.TabIndex = 9
        Me.btnPayment.Text = "..."
        Me.btnPayment.UseVisualStyleBackColor = True
        '
        'txtPayment
        '
        Me.txtPayment.Location = New System.Drawing.Point(144, 208)
        Me.txtPayment.Name = "txtPayment"
        Me.txtPayment.Size = New System.Drawing.Size(194, 20)
        Me.txtPayment.TabIndex = 8
        Me.txtPayment.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 181
        Me.Label4.Text = "Purchase Payment No."
        '
        'rptPTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 279)
        Me.Controls.Add(Me.btnPayment)
        Me.Controls.Add(Me.txtPayment)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnInvoice)
        Me.Controls.Add(Me.txtInvoice)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnIncoming)
        Me.Controls.Add(Me.txtIncoming)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnOrder)
        Me.Controls.Add(Me.txtOrder)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnRequest)
        Me.Controls.Add(Me.txtRequest)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label6)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptPTransaction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Transaction"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRequest As System.Windows.Forms.TextBox
    Friend WithEvents btnRequest As System.Windows.Forms.Button
    Friend WithEvents btnOrder As System.Windows.Forms.Button
    Friend WithEvents txtOrder As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnInvoice As System.Windows.Forms.Button
    Friend WithEvents txtInvoice As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnIncoming As System.Windows.Forms.Button
    Friend WithEvents txtIncoming As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnPayment As System.Windows.Forms.Button
    Friend WithEvents txtPayment As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
