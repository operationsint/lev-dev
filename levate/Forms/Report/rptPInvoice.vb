Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptPInvoice
    Private Sub rptPInvoice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
        GroupBox1.Enabled = False

        cbStatus.Items.Insert(0, "All")
        cbStatus.Items.Insert(1, "Unpaid")
        cbStatus.Items.Insert(2, "Partially Paid")
        cbStatus.Items.Insert(3, "Fully Paid")
        cbStatus.SelectedIndex = 0
    End Sub
    Public Property PNoFrom() As String
        Get
            Return txtPNoFrom.Text
        End Get
        Set(ByVal Value As String)
            txtPNoFrom.Text = Value
        End Set
    End Property
    Public Property PNoTo() As String
        Get
            Return txtPNoTo.Text
        End Get
        Set(ByVal Value As String)
            txtPNoTo.Text = Value
        End Set
    End Property
    Public Property SCodeFrom() As String
        Get
            Return txtSCodeFrom.Text
        End Get
        Set(ByVal Value As String)
            txtSCodeFrom.Text = Value
        End Set
    End Property
    Public Property SCodeTo() As String
        Get
            Return txtSCodeTo.Text
        End Get
        Set(ByVal Value As String)
            txtSCodeTo.Text = Value
        End Set
    End Property
    Public Property PchCode() As String
        Get
            Return txtPchCode.Text
        End Get
        Set(ByVal Value As String)
            txtPchCode.Text = Value
        End Set
    End Property

    Private Sub rbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GroupBox1.Enabled = False
    End Sub

    Private Sub rbPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GroupBox1.Enabled = True
    End Sub

    Private Sub btnClear_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtSCodeFrom.Text = ""
        txtSCodeTo.Text = ""
        txtPchCode.Text = ""
        txtPNoFrom.Text = ""
        txtPNoTo.Text = ""
        cbStatus.SelectedIndex = 0
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSCodeFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSCodeFrom.Click
        Dim NewFormDialog As New fdlSupplierFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub
    Private Sub btnSCodeTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSCodeTo.Click
        Dim NewFormDialog As New fdlSupplierTo
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom1 As String
        Dim dateTo1 As String
        Dim pNoFrom1 As String
        Dim pNoTo1 As String
        Dim sCodeFrom1 As String
        Dim sCodeTo1 As String
        Dim pchCode1 As String
        Dim Status As String

        If rbAll.Checked = True Then
            dateFrom1 = ""
            dateTo1 = ""
            pNoFrom1 = ""
            pNoTo1 = ""
            sCodeFrom1 = ""
            sCodeTo1 = ""
            pchCode1 = ""
            Status = ""
        Else
            dtpFrom.Format = DateTimePickerFormat.Custom
            dtpFrom.CustomFormat = "yyyy/MM/dd"
            dtpTo.Format = DateTimePickerFormat.Custom
            dtpTo.CustomFormat = "yyyy/MM/dd"
            dateFrom1 = dtpFrom.Text
            dateTo1 = dtpTo.Text
            If txtPNoFrom.Text <> "" And txtPNoTo.Text <> "" Then
                pNoFrom1 = txtPNoFrom.Text
                pNoTo1 = txtPNoTo.Text
                If txtPNoFrom.Text = "" And txtPNoTo.Text <> "" Then
                    pNoFrom1 = txtPNoTo.Text
                    pNoTo1 = txtPNoTo.Text
                ElseIf txtPNoFrom.Text <> "" And txtPNoTo.Text = "" Then
                    pNoFrom1 = txtPNoFrom.Text
                    pNoTo1 = txtPNoFrom.Text
                End If
            Else
                pNoFrom1 = ""
                pNoTo1 = ""
            End If
            If txtSCodeFrom.Text <> "" And txtSCodeTo.Text <> "" Then
                sCodeFrom1 = txtSCodeFrom.Text
                sCodeTo1 = txtSCodeTo.Text
                If txtSCodeFrom.Text = "" And txtSCodeTo.Text <> "" Then
                    sCodeFrom1 = txtSCodeTo.Text
                    sCodeTo1 = txtSCodeTo.Text
                ElseIf txtSCodeFrom.Text <> "" And txtSCodeTo.Text = "" Then
                    sCodeFrom1 = txtSCodeFrom.Text
                    sCodeTo1 = txtSCodeFrom.Text
                End If
            Else
                sCodeFrom1 = ""
                sCodeTo1 = ""
            End If
            If txtPchCode.Text <> "" Then
                pchCode1 = txtPchCode.Text
            Else
                pchCode1 = ""
            End If
            If cbStatus.SelectedIndex = 0 Then
                Status = ""
            ElseIf cbStatus.SelectedIndex = 1 Then
                Status = "UP"
            ElseIf cbStatus.SelectedIndex = 2 Then
                Status = "PP"
            Else
                Status = "FP"
            End If
        End If

        strSQL = "exec RPT_Pch_Invoice_Report '" & dateFrom1 & "' , '" & dateTo1 & "', '" & pNoFrom1 & "', '" & pNoTo1 & "', '" & sCodeFrom1 & "', '" & sCodeTo1 & "', '" & pchCode1 & "', '" & Status & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "PInvRpt_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Pch_Invoice_Report.rpt"

        '20160627 load custom rpt if available
        Dim strReportPathCustom As String = strReportPath.Substring(0, strReportPath.Length - 4) & "_Custom.rpt"
        If IO.File.Exists(strReportPathCustom) Then
            strReportPath = strReportPathCustom
        End If

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Purchase Invoice Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("PInvRpt_"))
        
        '-----------------MENAMBAH PARAMETER FILTER KE CR--------------------------
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterdate As String
        Dim filterpno As String
        Dim filterscode As String
        Dim filterpch As String
        Dim filterstatus As String

        If rbAll.Checked = True Then
            filterdate = "Transaction Date : All"
            filterpno = "Purchase Invoice No. : All"
            filterscode = "Supplier Code : All"
            filterpch = "Purchase Code : All"
            filterstatus = "Status : All"
        Else
            filterdate = "Transaction Date : " & dtpFrom.Text & " - " & dtpTo.Text
            If txtPNoFrom.Text = "" And txtPNoTo.Text = "" Then
                filterpno = "Purchase Invoice No. : All"
            Else
                filterpno = "Purchase Invoice No. : " & txtPNoFrom.Text & " - " & txtPNoTo.Text
            End If
            If txtSCodeFrom.Text = "" And txtSCodeTo.Text = "" Then
                filterscode = "Supplier Code : All"
            Else
                filterscode = "Supplier Code : " & txtSCodeFrom.Text & " - " & txtSCodeTo.Text
            End If
            If txtPchCode.Text = "" Then
                filterpch = "Purchase Code : All"
            Else
                filterpch = "Purchase Code : " & txtPchCode.Text
            End If
            If cbStatus.SelectedIndex = 0 Then
                filterstatus = "Status : All"
            Else
                filterstatus = "Status : " & cbStatus.SelectedItem
            End If
        End If
        Dim filter As String = filterdate + vbCrLf + filterpno + vbCrLf + filterscode + vbCrLf + filterpch + vbCrLf + filterstatus

        crParameterDiscreteValue.Value = filter
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filter")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub btnPchCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPchCode.Click
        Dim NewFormDialog As New fdlPchCodeFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPNoFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPNoFrom.Click
        Dim NewFormDialog As New fdlPInvoiceFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPNoTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPNoTo.Click
        Dim NewFormDialog As New fdlPInvoiceTo
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub rbAll_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAll.CheckedChanged
        GroupBox1.Enabled = False
    End Sub

    Private Sub rbPeriod_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPeriod.CheckedChanged
        GroupBox1.Enabled = True
    End Sub
End Class