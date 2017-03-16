<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockLocationR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStockLocationR))
        Me.DataSet = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnLocationTo = New System.Windows.Forms.Button()
        Me.txtLocationTo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnLocationFrom = New System.Windows.Forms.Button()
        Me.txtLocationFrom = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodeTo = New System.Windows.Forms.TextBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnFilterTo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnFilterFrom = New System.Windows.Forms.Button()
        Me.txtCodeFrom = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataSet
        '
        Me.DataSet.DataSetName = "DataSet"
        Me.DataSet.Tables.AddRange(New System.Data.DataTable() {Me.DataTable1})
        '
        'DataTable1
        '
        Me.DataTable1.TableName = "Table1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnLocationTo)
        Me.Panel1.Controls.Add(Me.txtLocationTo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.BtnLocationFrom)
        Me.Panel1.Controls.Add(Me.txtLocationFrom)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtCodeTo)
        Me.Panel1.Controls.Add(Me.BtnPrint)
        Me.Panel1.Controls.Add(Me.BtnFilterTo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.BtnFilterFrom)
        Me.Panel1.Controls.Add(Me.txtCodeFrom)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(810, 54)
        Me.Panel1.TabIndex = 8
        '
        'BtnLocationTo
        '
        Me.BtnLocationTo.Image = CType(resources.GetObject("BtnLocationTo.Image"), System.Drawing.Image)
        Me.BtnLocationTo.Location = New System.Drawing.Point(307, 7)
        Me.BtnLocationTo.Name = "BtnLocationTo"
        Me.BtnLocationTo.Size = New System.Drawing.Size(35, 21)
        Me.BtnLocationTo.TabIndex = 36
        Me.BtnLocationTo.UseVisualStyleBackColor = True
        '
        'txtLocationTo
        '
        Me.txtLocationTo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLocationTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocationTo.Location = New System.Drawing.Point(234, 7)
        Me.txtLocationTo.Name = "txtLocationTo"
        Me.txtLocationTo.Size = New System.Drawing.Size(71, 21)
        Me.txtLocationTo.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(211, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "To"
        '
        'BtnLocationFrom
        '
        Me.BtnLocationFrom.Image = CType(resources.GetObject("BtnLocationFrom.Image"), System.Drawing.Image)
        Me.BtnLocationFrom.Location = New System.Drawing.Point(172, 6)
        Me.BtnLocationFrom.Name = "BtnLocationFrom"
        Me.BtnLocationFrom.Size = New System.Drawing.Size(35, 21)
        Me.BtnLocationFrom.TabIndex = 33
        Me.BtnLocationFrom.UseVisualStyleBackColor = True
        '
        'txtLocationFrom
        '
        Me.txtLocationFrom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtLocationFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocationFrom.Location = New System.Drawing.Point(98, 7)
        Me.txtLocationFrom.Name = "txtLocationFrom"
        Me.txtLocationFrom.Size = New System.Drawing.Size(71, 21)
        Me.txtLocationFrom.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Location From"
        '
        'txtCodeTo
        '
        Me.txtCodeTo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCodeTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodeTo.Location = New System.Drawing.Point(558, 7)
        Me.txtCodeTo.Name = "txtCodeTo"
        Me.txtCodeTo.Size = New System.Drawing.Size(71, 21)
        Me.txtCodeTo.TabIndex = 30
        '
        'BtnPrint
        '
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrint.Location = New System.Drawing.Point(665, 7)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(86, 21)
        Me.BtnPrint.TabIndex = 29
        Me.BtnPrint.Text = "    &Generate"
        Me.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnFilterTo
        '
        Me.BtnFilterTo.Image = CType(resources.GetObject("BtnFilterTo.Image"), System.Drawing.Image)
        Me.BtnFilterTo.Location = New System.Drawing.Point(630, 7)
        Me.BtnFilterTo.Name = "BtnFilterTo"
        Me.BtnFilterTo.Size = New System.Drawing.Size(35, 21)
        Me.BtnFilterTo.TabIndex = 28
        Me.BtnFilterTo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(532, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "To"
        '
        'BtnFilterFrom
        '
        Me.BtnFilterFrom.Image = CType(resources.GetObject("BtnFilterFrom.Image"), System.Drawing.Image)
        Me.BtnFilterFrom.Location = New System.Drawing.Point(492, 7)
        Me.BtnFilterFrom.Name = "BtnFilterFrom"
        Me.BtnFilterFrom.Size = New System.Drawing.Size(35, 21)
        Me.BtnFilterFrom.TabIndex = 25
        Me.BtnFilterFrom.UseVisualStyleBackColor = True
        '
        'txtCodeFrom
        '
        Me.txtCodeFrom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCodeFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodeFrom.Location = New System.Drawing.Point(420, 7)
        Me.txtCodeFrom.Name = "txtCodeFrom"
        Me.txtCodeFrom.Size = New System.Drawing.Size(71, 21)
        Me.txtCodeFrom.TabIndex = 24
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(347, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Stock From"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        'Me.CrystalReportViewer1.CachedPageNumberPerDoc = 10
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 54)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(810, 383)
        Me.CrystalReportViewer1.TabIndex = 11
        '
        'frmStockLocationR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 437)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmStockLocationR"
        Me.Text = "Form3"
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents DataSet As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnFilterTo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnFilterFrom As System.Windows.Forms.Button
    Friend WithEvents txtCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnLocationFrom As System.Windows.Forms.Button
    Friend WithEvents txtLocationFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents BtnLocationTo As System.Windows.Forms.Button
    Friend WithEvents txtLocationTo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
