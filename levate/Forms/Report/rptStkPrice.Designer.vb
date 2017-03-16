<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptStkPrice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptStkPrice))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCategory = New System.Windows.Forms.Button()
        Me.txtCategory = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtStkCodeFrom = New System.Windows.Forms.TextBox()
        Me.btnStkFrom = New System.Windows.Forms.Button()
        Me.btnStkTo = New System.Windows.Forms.Button()
        Me.txtStkCodeTo = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 167
        Me.Label4.Text = "Category"
        '
        'btnCategory
        '
        Me.btnCategory.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCategory.ImageIndex = 0
        Me.btnCategory.Location = New System.Drawing.Point(209, 135)
        Me.btnCategory.Name = "btnCategory"
        Me.btnCategory.Size = New System.Drawing.Size(29, 25)
        Me.btnCategory.TabIndex = 5
        Me.btnCategory.Text = "..."
        Me.btnCategory.UseVisualStyleBackColor = True
        '
        'txtCategory
        '
        Me.txtCategory.Location = New System.Drawing.Point(123, 138)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(80, 20)
        Me.txtCategory.TabIndex = 4
        Me.txtCategory.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(381, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 166
        Me.Label8.Text = "Stock Price"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(244, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(162, 13)
        Me.Label3.TabIndex = 165
        Me.Label3.Text = "To select all leave the field blank"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(186, 180)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 156
        Me.Label1.Text = "From Stock Code*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 157
        Me.Label2.Text = "To Stock Code*"
        '
        'txtStkCodeFrom
        '
        Me.txtStkCodeFrom.Location = New System.Drawing.Point(123, 63)
        Me.txtStkCodeFrom.Name = "txtStkCodeFrom"
        Me.txtStkCodeFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtStkCodeFrom.TabIndex = 0
        Me.txtStkCodeFrom.TabStop = False
        '
        'btnStkFrom
        '
        Me.btnStkFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStkFrom.ImageIndex = 0
        Me.btnStkFrom.Location = New System.Drawing.Point(209, 60)
        Me.btnStkFrom.Name = "btnStkFrom"
        Me.btnStkFrom.Size = New System.Drawing.Size(29, 25)
        Me.btnStkFrom.TabIndex = 1
        Me.btnStkFrom.Text = "..."
        Me.btnStkFrom.UseVisualStyleBackColor = True
        '
        'btnStkTo
        '
        Me.btnStkTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStkTo.ImageIndex = 0
        Me.btnStkTo.Location = New System.Drawing.Point(209, 94)
        Me.btnStkTo.Name = "btnStkTo"
        Me.btnStkTo.Size = New System.Drawing.Size(29, 25)
        Me.btnStkTo.TabIndex = 3
        Me.btnStkTo.Text = "..."
        Me.btnStkTo.UseVisualStyleBackColor = True
        '
        'txtStkCodeTo
        '
        Me.txtStkCodeTo.Location = New System.Drawing.Point(123, 97)
        Me.txtStkCodeTo.Name = "txtStkCodeTo"
        Me.txtStkCodeTo.Size = New System.Drawing.Size(80, 20)
        Me.txtStkCodeTo.TabIndex = 2
        Me.txtStkCodeTo.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(100, 180)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(14, 180)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(80, 23)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'rptStkPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 213)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnCategory)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtStkCodeFrom)
        Me.Controls.Add(Me.btnStkFrom)
        Me.Controls.Add(Me.btnStkTo)
        Me.Controls.Add(Me.txtStkCodeTo)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPrint)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "rptStkPrice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Price"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCategory As System.Windows.Forms.Button
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStkCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents btnStkFrom As System.Windows.Forms.Button
    Friend WithEvents btnStkTo As System.Windows.Forms.Button
    Friend WithEvents txtStkCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
End Class
