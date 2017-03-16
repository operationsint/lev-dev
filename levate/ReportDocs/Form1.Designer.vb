<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.myCrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.redisplay = New System.Windows.Forms.Button()
        Me.defaultParameterValuesList = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'myCrystalReportViewer
        '
        Me.myCrystalReportViewer.ActiveViewIndex = -1
        Me.myCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.myCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.myCrystalReportViewer.Location = New System.Drawing.Point(2, 128)
        Me.myCrystalReportViewer.Name = "myCrystalReportViewer"
        Me.myCrystalReportViewer.Size = New System.Drawing.Size(496, 320)
        Me.myCrystalReportViewer.TabIndex = 0
        '
        'redisplay
        '
        Me.redisplay.Location = New System.Drawing.Point(269, 39)
        Me.redisplay.Name = "redisplay"
        Me.redisplay.Size = New System.Drawing.Size(120, 23)
        Me.redisplay.TabIndex = 4
        Me.redisplay.Text = "Redisplay Report"
        Me.redisplay.UseVisualStyleBackColor = True
        '
        'defaultParameterValuesList
        '
        Me.defaultParameterValuesList.FormattingEnabled = True
        Me.defaultParameterValuesList.Location = New System.Drawing.Point(12, 12)
        Me.defaultParameterValuesList.Name = "defaultParameterValuesList"
        Me.defaultParameterValuesList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.defaultParameterValuesList.Size = New System.Drawing.Size(210, 95)
        Me.defaultParameterValuesList.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 450)
        Me.Controls.Add(Me.redisplay)
        Me.Controls.Add(Me.defaultParameterValuesList)
        Me.Controls.Add(Me.myCrystalReportViewer)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents myCrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents redisplay As System.Windows.Forms.Button
    Friend WithEvents defaultParameterValuesList As System.Windows.Forms.ListBox
End Class
