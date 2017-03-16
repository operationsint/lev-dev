<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSupplierR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSupplierR))
        Me.txtCodeTo = New System.Windows.Forms.TextBox()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.BtnFilterTo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnFilterFrom = New System.Windows.Forms.Button()
        Me.txtCodeFrom = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DataSet = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.Panel1.SuspendLayout()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCodeTo
        '
        Me.txtCodeTo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCodeTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodeTo.Location = New System.Drawing.Point(344, 9)
        Me.txtCodeTo.Name = "txtCodeTo"
        Me.txtCodeTo.Size = New System.Drawing.Size(71, 21)
        Me.txtCodeTo.TabIndex = 30
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
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(855, 425)
        Me.CrystalReportViewer1.TabIndex = 7
        '
        'BtnPrint
        '
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrint.Location = New System.Drawing.Point(460, 8)
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
        Me.BtnFilterTo.Location = New System.Drawing.Point(421, 8)
        Me.BtnFilterTo.Name = "BtnFilterTo"
        Me.BtnFilterTo.Size = New System.Drawing.Size(35, 21)
        Me.BtnFilterTo.TabIndex = 28
        Me.BtnFilterTo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(256, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Supp.Code To"
        '
        'BtnFilterFrom
        '
        Me.BtnFilterFrom.Image = CType(resources.GetObject("BtnFilterFrom.Image"), System.Drawing.Image)
        Me.BtnFilterFrom.Location = New System.Drawing.Point(193, 8)
        Me.BtnFilterFrom.Name = "BtnFilterFrom"
        Me.BtnFilterFrom.Size = New System.Drawing.Size(35, 21)
        Me.BtnFilterFrom.TabIndex = 25
        Me.BtnFilterFrom.UseVisualStyleBackColor = True
        '
        'txtCodeFrom
        '
        Me.txtCodeFrom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCodeFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodeFrom.Location = New System.Drawing.Point(113, 8)
        Me.txtCodeFrom.Name = "txtCodeFrom"
        Me.txtCodeFrom.Size = New System.Drawing.Size(71, 21)
        Me.txtCodeFrom.TabIndex = 24
        '
        'Panel1
        '
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
        Me.Panel1.Size = New System.Drawing.Size(855, 54)
        Me.Panel1.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Supp.Code From"
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
        'frmSupplierR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 479)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmSupplierR"
        Me.Text = "Supplier Master List"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnFilterTo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnFilterFrom As System.Windows.Forms.Button
    Friend WithEvents txtCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents DataSet As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
End Class
