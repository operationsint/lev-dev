<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptStkLocation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptStkLocation))
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnLocation = New System.Windows.Forms.Button()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnStkCat = New System.Windows.Forms.Button()
        Me.txtStkCat = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(238, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Leave blank to select all"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(180, 221)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Clear"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "From Stock Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "To Stock Code"
        '
        'txtStkCodeFrom
        '
        Me.txtStkCodeFrom.Location = New System.Drawing.Point(117, 52)
        Me.txtStkCodeFrom.Name = "txtStkCodeFrom"
        Me.txtStkCodeFrom.Size = New System.Drawing.Size(80, 20)
        Me.txtStkCodeFrom.TabIndex = 0
        Me.txtStkCodeFrom.TabStop = False
        '
        'btnStkFrom
        '
        Me.btnStkFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStkFrom.ImageIndex = 0
        Me.btnStkFrom.Location = New System.Drawing.Point(203, 49)
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
        Me.btnStkTo.Location = New System.Drawing.Point(203, 83)
        Me.btnStkTo.Name = "btnStkTo"
        Me.btnStkTo.Size = New System.Drawing.Size(29, 25)
        Me.btnStkTo.TabIndex = 3
        Me.btnStkTo.Text = "..."
        Me.btnStkTo.UseVisualStyleBackColor = True
        '
        'txtStkCodeTo
        '
        Me.txtStkCodeTo.Location = New System.Drawing.Point(117, 86)
        Me.txtStkCodeTo.Name = "txtStkCodeTo"
        Me.txtStkCodeTo.Size = New System.Drawing.Size(80, 20)
        Me.txtStkCodeTo.TabIndex = 2
        Me.txtStkCodeTo.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(94, 221)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 23)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(8, 221)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(80, 23)
        Me.btnPrint.TabIndex = 8
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 59
        Me.Label4.Text = "Location Code"
        '
        'btnLocation
        '
        Me.btnLocation.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLocation.ImageIndex = 0
        Me.btnLocation.Location = New System.Drawing.Point(203, 173)
        Me.btnLocation.Name = "btnLocation"
        Me.btnLocation.Size = New System.Drawing.Size(29, 25)
        Me.btnLocation.TabIndex = 7
        Me.btnLocation.Text = "..."
        Me.btnLocation.UseVisualStyleBackColor = True
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(117, 176)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(80, 20)
        Me.txtLocation.TabIndex = 6
        Me.txtLocation.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.Location = New System.Drawing.Point(238, 179)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 13)
        Me.Label5.TabIndex = 62
        Me.Label5.Text = "Leave blank to select all"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.Location = New System.Drawing.Point(238, 135)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 13)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "Leave blank to select all"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Stock Category"
        '
        'btnStkCat
        '
        Me.btnStkCat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStkCat.ImageIndex = 0
        Me.btnStkCat.Location = New System.Drawing.Point(203, 129)
        Me.btnStkCat.Name = "btnStkCat"
        Me.btnStkCat.Size = New System.Drawing.Size(29, 25)
        Me.btnStkCat.TabIndex = 5
        Me.btnStkCat.Text = "..."
        Me.btnStkCat.UseVisualStyleBackColor = True
        '
        'txtStkCat
        '
        Me.txtStkCat.Location = New System.Drawing.Point(117, 132)
        Me.txtStkCat.Name = "txtStkCat"
        Me.txtStkCat.Size = New System.Drawing.Size(80, 20)
        Me.txtStkCat.TabIndex = 4
        Me.txtStkCat.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(343, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 20)
        Me.Label8.TabIndex = 151
        Me.Label8.Text = "Stock Location"
        '
        'rptStkLocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 251)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnStkCat)
        Me.Controls.Add(Me.txtStkCat)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnLocation)
        Me.Controls.Add(Me.txtLocation)
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
        Me.Name = "rptStkLocation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Location"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnLocation As System.Windows.Forms.Button
    Friend WithEvents txtLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnStkCat As System.Windows.Forms.Button
    Friend WithEvents txtStkCat As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
