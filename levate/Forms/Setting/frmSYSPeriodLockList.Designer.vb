<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSYSPeriodLockList
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnLockAP = New System.Windows.Forms.Button()
        Me.lblRecordCountAP = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAPLocked = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnLockAR = New System.Windows.Forms.Button()
        Me.lblRecordCountAR = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtARLocked = New System.Windows.Forms.TextBox()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnLockSKU = New System.Windows.Forms.Button()
        Me.lblRecordCountSKU = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSKULocked = New System.Windows.Forms.TextBox()
        Me.ListView3 = New System.Windows.Forms.ListView()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.btnLockBANK = New System.Windows.Forms.Button()
        Me.lblRecordCountBANK = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtBANKLocked = New System.Windows.Forms.TextBox()
        Me.ListView4 = New System.Windows.Forms.ListView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.btnLockGL = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtGLLocked = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEndDate = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtStartDate = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPeriodName = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(467, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(271, 25)
        Me.Label6.TabIndex = 78
        Me.Label6.Text = "Close Transaction Period"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(12, 106)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(719, 395)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnLockAP)
        Me.TabPage1.Controls.Add(Me.lblRecordCountAP)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtAPLocked)
        Me.TabPage1.Controls.Add(Me.ListView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(711, 369)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Purchase Transaction"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnLockAP
        '
        Me.btnLockAP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLockAP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLockAP.Location = New System.Drawing.Point(231, 11)
        Me.btnLockAP.Name = "btnLockAP"
        Me.btnLockAP.Size = New System.Drawing.Size(95, 26)
        Me.btnLockAP.TabIndex = 1
        Me.btnLockAP.Text = "Close"
        Me.btnLockAP.UseVisualStyleBackColor = True
        '
        'lblRecordCountAP
        '
        Me.lblRecordCountAP.AutoSize = True
        Me.lblRecordCountAP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordCountAP.Location = New System.Drawing.Point(7, 66)
        Me.lblRecordCountAP.Name = "lblRecordCountAP"
        Me.lblRecordCountAP.Size = New System.Drawing.Size(139, 13)
        Me.lblRecordCountAP.TabIndex = 89
        Me.lblRecordCountAP.Text = "Open Purchase Transaction"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Close status"
        '
        'txtAPLocked
        '
        Me.txtAPLocked.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAPLocked.Location = New System.Drawing.Point(104, 15)
        Me.txtAPLocked.MaxLength = 50
        Me.txtAPLocked.Name = "txtAPLocked"
        Me.txtAPLocked.ReadOnly = True
        Me.txtAPLocked.Size = New System.Drawing.Size(121, 21)
        Me.txtAPLocked.TabIndex = 0
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(6, 82)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(699, 281)
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnLockAR)
        Me.TabPage2.Controls.Add(Me.lblRecordCountAR)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.txtARLocked)
        Me.TabPage2.Controls.Add(Me.ListView2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(711, 369)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Sales Transaction"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnLockAR
        '
        Me.btnLockAR.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLockAR.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLockAR.Location = New System.Drawing.Point(231, 11)
        Me.btnLockAR.Name = "btnLockAR"
        Me.btnLockAR.Size = New System.Drawing.Size(95, 26)
        Me.btnLockAR.TabIndex = 96
        Me.btnLockAR.Text = "Close"
        Me.btnLockAR.UseVisualStyleBackColor = True
        '
        'lblRecordCountAR
        '
        Me.lblRecordCountAR.AutoSize = True
        Me.lblRecordCountAR.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordCountAR.Location = New System.Drawing.Point(7, 66)
        Me.lblRecordCountAR.Name = "lblRecordCountAR"
        Me.lblRecordCountAR.Size = New System.Drawing.Size(120, 13)
        Me.lblRecordCountAR.TabIndex = 95
        Me.lblRecordCountAR.Text = "Open Sales Transaction"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 94
        Me.Label7.Text = "Close status"
        '
        'txtARLocked
        '
        Me.txtARLocked.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtARLocked.Location = New System.Drawing.Point(104, 15)
        Me.txtARLocked.MaxLength = 50
        Me.txtARLocked.Name = "txtARLocked"
        Me.txtARLocked.ReadOnly = True
        Me.txtARLocked.Size = New System.Drawing.Size(121, 21)
        Me.txtARLocked.TabIndex = 93
        '
        'ListView2
        '
        Me.ListView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView2.FullRowSelect = True
        Me.ListView2.GridLines = True
        Me.ListView2.Location = New System.Drawing.Point(6, 82)
        Me.ListView2.MultiSelect = False
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(699, 281)
        Me.ListView2.TabIndex = 92
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.View = System.Windows.Forms.View.List
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnLockSKU)
        Me.TabPage3.Controls.Add(Me.lblRecordCountSKU)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Controls.Add(Me.txtSKULocked)
        Me.TabPage3.Controls.Add(Me.ListView3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(711, 369)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Stock Transaction"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnLockSKU
        '
        Me.btnLockSKU.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLockSKU.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLockSKU.Location = New System.Drawing.Point(231, 11)
        Me.btnLockSKU.Name = "btnLockSKU"
        Me.btnLockSKU.Size = New System.Drawing.Size(95, 26)
        Me.btnLockSKU.TabIndex = 101
        Me.btnLockSKU.Text = "Close"
        Me.btnLockSKU.UseVisualStyleBackColor = True
        '
        'lblRecordCountSKU
        '
        Me.lblRecordCountSKU.AutoSize = True
        Me.lblRecordCountSKU.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordCountSKU.Location = New System.Drawing.Point(7, 66)
        Me.lblRecordCountSKU.Name = "lblRecordCountSKU"
        Me.lblRecordCountSKU.Size = New System.Drawing.Size(121, 13)
        Me.lblRecordCountSKU.TabIndex = 100
        Me.lblRecordCountSKU.Text = "Open Stock Transaction"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 99
        Me.Label9.Text = "Close status"
        '
        'txtSKULocked
        '
        Me.txtSKULocked.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSKULocked.Location = New System.Drawing.Point(104, 15)
        Me.txtSKULocked.MaxLength = 50
        Me.txtSKULocked.Name = "txtSKULocked"
        Me.txtSKULocked.ReadOnly = True
        Me.txtSKULocked.Size = New System.Drawing.Size(121, 21)
        Me.txtSKULocked.TabIndex = 98
        '
        'ListView3
        '
        Me.ListView3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView3.FullRowSelect = True
        Me.ListView3.GridLines = True
        Me.ListView3.Location = New System.Drawing.Point(6, 82)
        Me.ListView3.MultiSelect = False
        Me.ListView3.Name = "ListView3"
        Me.ListView3.Size = New System.Drawing.Size(699, 281)
        Me.ListView3.TabIndex = 97
        Me.ListView3.UseCompatibleStateImageBehavior = False
        Me.ListView3.View = System.Windows.Forms.View.List
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.btnLockBANK)
        Me.TabPage5.Controls.Add(Me.lblRecordCountBANK)
        Me.TabPage5.Controls.Add(Me.Label10)
        Me.TabPage5.Controls.Add(Me.txtBANKLocked)
        Me.TabPage5.Controls.Add(Me.ListView4)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(711, 369)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Bank Transaction"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'btnLockBANK
        '
        Me.btnLockBANK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLockBANK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLockBANK.Location = New System.Drawing.Point(231, 8)
        Me.btnLockBANK.Name = "btnLockBANK"
        Me.btnLockBANK.Size = New System.Drawing.Size(95, 26)
        Me.btnLockBANK.TabIndex = 96
        Me.btnLockBANK.Text = "Close"
        Me.btnLockBANK.UseVisualStyleBackColor = True
        '
        'lblRecordCountBANK
        '
        Me.lblRecordCountBANK.AutoSize = True
        Me.lblRecordCountBANK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordCountBANK.Location = New System.Drawing.Point(7, 63)
        Me.lblRecordCountBANK.Name = "lblRecordCountBANK"
        Me.lblRecordCountBANK.Size = New System.Drawing.Size(118, 13)
        Me.lblRecordCountBANK.TabIndex = 95
        Me.lblRecordCountBANK.Text = "Open Bank Transaction"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 94
        Me.Label10.Text = "Close status"
        '
        'txtBANKLocked
        '
        Me.txtBANKLocked.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBANKLocked.Location = New System.Drawing.Point(104, 12)
        Me.txtBANKLocked.MaxLength = 50
        Me.txtBANKLocked.Name = "txtBANKLocked"
        Me.txtBANKLocked.ReadOnly = True
        Me.txtBANKLocked.Size = New System.Drawing.Size(121, 21)
        Me.txtBANKLocked.TabIndex = 93
        '
        'ListView4
        '
        Me.ListView4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView4.FullRowSelect = True
        Me.ListView4.GridLines = True
        Me.ListView4.Location = New System.Drawing.Point(6, 79)
        Me.ListView4.MultiSelect = False
        Me.ListView4.Name = "ListView4"
        Me.ListView4.Size = New System.Drawing.Size(699, 281)
        Me.ListView4.TabIndex = 92
        Me.ListView4.UseCompatibleStateImageBehavior = False
        Me.ListView4.View = System.Windows.Forms.View.List
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.btnLockGL)
        Me.TabPage4.Controls.Add(Me.Label8)
        Me.TabPage4.Controls.Add(Me.txtGLLocked)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(711, 369)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Ledger Transaction"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'btnLockGL
        '
        Me.btnLockGL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLockGL.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLockGL.Location = New System.Drawing.Point(231, 11)
        Me.btnLockGL.Name = "btnLockGL"
        Me.btnLockGL.Size = New System.Drawing.Size(95, 26)
        Me.btnLockGL.TabIndex = 99
        Me.btnLockGL.Text = "Close"
        Me.btnLockGL.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 98
        Me.Label8.Text = "Close status"
        '
        'txtGLLocked
        '
        Me.txtGLLocked.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGLLocked.Location = New System.Drawing.Point(104, 15)
        Me.txtGLLocked.MaxLength = 50
        Me.txtGLLocked.Name = "txtGLLocked"
        Me.txtGLLocked.ReadOnly = True
        Me.txtGLLocked.Size = New System.Drawing.Size(121, 21)
        Me.txtGLLocked.TabIndex = 97
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(501, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "End Date"
        '
        'txtEndDate
        '
        Me.txtEndDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndDate.Location = New System.Drawing.Point(606, 79)
        Me.txtEndDate.MaxLength = 50
        Me.txtEndDate.Name = "txtEndDate"
        Me.txtEndDate.ReadOnly = True
        Me.txtEndDate.Size = New System.Drawing.Size(121, 21)
        Me.txtEndDate.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(501, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "Start Date"
        '
        'txtStartDate
        '
        Me.txtStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartDate.Location = New System.Drawing.Point(606, 52)
        Me.txtStartDate.MaxLength = 50
        Me.txtStartDate.Name = "txtStartDate"
        Me.txtStartDate.ReadOnly = True
        Me.txtStartDate.Size = New System.Drawing.Size(121, 21)
        Me.txtStartDate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Period Name"
        '
        'txtPeriodName
        '
        Me.txtPeriodName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodName.Location = New System.Drawing.Point(120, 52)
        Me.txtPeriodName.MaxLength = 50
        Me.txtPeriodName.Name = "txtPeriodName"
        Me.txtPeriodName.ReadOnly = True
        Me.txtPeriodName.Size = New System.Drawing.Size(121, 21)
        Me.txtPeriodName.TabIndex = 0
        '
        'frmSYSPeriodLockList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 537)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtEndDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtStartDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPeriodName)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label6)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSYSPeriodLockList"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Close Transaction Period"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAPLocked As System.Windows.Forms.TextBox
    Friend WithEvents lblRecordCountAP As System.Windows.Forms.Label
    Friend WithEvents btnLockAP As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEndDate As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtStartDate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodName As System.Windows.Forms.TextBox
    Friend WithEvents btnLockAR As System.Windows.Forms.Button
    Friend WithEvents lblRecordCountAR As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtARLocked As System.Windows.Forms.TextBox
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents btnLockGL As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtGLLocked As System.Windows.Forms.TextBox
    Friend WithEvents btnLockSKU As System.Windows.Forms.Button
    Friend WithEvents lblRecordCountSKU As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSKULocked As System.Windows.Forms.TextBox
    Friend WithEvents ListView3 As System.Windows.Forms.ListView
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents btnLockBANK As System.Windows.Forms.Button
    Friend WithEvents lblRecordCountBANK As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtBANKLocked As System.Windows.Forms.TextBox
    Friend WithEvents ListView4 As System.Windows.Forms.ListView
End Class
