<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExpenseR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExpenseR))
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbFilterBy = New System.Windows.Forms.ComboBox()
        Me.txtCodeTo = New System.Windows.Forms.TextBox()
        Me.BtnFilterTo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnFilterFrom = New System.Windows.Forms.Button()
        Me.txtCodeFrom = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DataSet = New System.Data.DataSet()
        Me.DataTable1 = New System.Data.DataTable()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel1.SuspendLayout()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnPrint
        '
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrint.Location = New System.Drawing.Point(438, 10)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(86, 21)
        Me.BtnPrint.TabIndex = 29
        Me.BtnPrint.Text = "    &Generate"
        Me.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmbFilterBy)
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
        Me.Panel1.Size = New System.Drawing.Size(805, 47)
        Me.Panel1.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Type"
        '
        'cmbFilterBy
        '
        Me.cmbFilterBy.FormattingEnabled = True
        Me.cmbFilterBy.Items.AddRange(New Object() {"All", "Expense", "Income"})
        Me.cmbFilterBy.Location = New System.Drawing.Point(40, 11)
        Me.cmbFilterBy.Name = "cmbFilterBy"
        Me.cmbFilterBy.Size = New System.Drawing.Size(79, 21)
        Me.cmbFilterBy.TabIndex = 34
        '
        'txtCodeTo
        '
        Me.txtCodeTo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCodeTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodeTo.Location = New System.Drawing.Point(322, 12)
        Me.txtCodeTo.Name = "txtCodeTo"
        Me.txtCodeTo.Size = New System.Drawing.Size(71, 21)
        Me.txtCodeTo.TabIndex = 30
        '
        'BtnFilterTo
        '
        Me.BtnFilterTo.Image = CType(resources.GetObject("BtnFilterTo.Image"), System.Drawing.Image)
        Me.BtnFilterTo.Location = New System.Drawing.Point(399, 11)
        Me.BtnFilterTo.Name = "BtnFilterTo"
        Me.BtnFilterTo.Size = New System.Drawing.Size(35, 21)
        Me.BtnFilterTo.TabIndex = 28
        Me.BtnFilterTo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(295, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "To"
        '
        'BtnFilterFrom
        '
        Me.BtnFilterFrom.Image = CType(resources.GetObject("BtnFilterFrom.Image"), System.Drawing.Image)
        Me.BtnFilterFrom.Location = New System.Drawing.Point(244, 11)
        Me.BtnFilterFrom.Name = "BtnFilterFrom"
        Me.BtnFilterFrom.Size = New System.Drawing.Size(35, 21)
        Me.BtnFilterFrom.TabIndex = 25
        Me.BtnFilterFrom.UseVisualStyleBackColor = True
        '
        'txtCodeFrom
        '
        Me.txtCodeFrom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtCodeFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodeFrom.Location = New System.Drawing.Point(167, 12)
        Me.txtCodeFrom.Name = "txtCodeFrom"
        Me.txtCodeFrom.Size = New System.Drawing.Size(71, 21)
        Me.txtCodeFrom.TabIndex = 24
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(125, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "From"
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
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        'Me.CrystalReportViewer1.CachedPageNumberPerDoc = 10
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 47)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(805, 531)
        Me.CrystalReportViewer1.TabIndex = 10
        '
        'frmExpenseR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 578)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmExpenseR"
        Me.Text = "Income/Expense"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtCodeTo As System.Windows.Forms.TextBox
    Friend WithEvents BtnFilterTo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnFilterFrom As System.Windows.Forms.Button
    Friend WithEvents txtCodeFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents DataSet As System.Data.DataSet
    Friend WithEvents DataTable1 As System.Data.DataTable
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbFilterBy As System.Windows.Forms.ComboBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
