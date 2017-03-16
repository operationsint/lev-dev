Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptSlsInvoiceSum
    Private Sub rptSlsInvoiceSum_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strConnection As String = My.Settings.ConnStr
        Dim cn As SqlConnection = New SqlConnection(strConnection)
        Dim cmd As SqlCommand

        'Add item cmbPOStatus
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "sinvoice_status"

        cn.Open()
        Dim myReader = cmd.ExecuteReader

        cbStatus.Items.Add(New clsMyListStr("All", ""))
        While myReader.Read
            cbStatus.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While
        cbStatus.SelectedIndex = 0

        'Set dtp
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
        chbDate.Checked = False
        chbDate_CheckedChanged(sender, e)
    End Sub
    Public Property SNoFrom() As String
        Get
            Return txtPNoFrom.Text
        End Get
        Set(ByVal Value As String)
            txtPNoFrom.Text = Value
        End Set
    End Property
    Public Property SNoTo() As String
        Get
            Return txtPNoTo.Text
        End Get
        Set(ByVal Value As String)
            txtPNoTo.Text = Value
        End Set
    End Property
    Public Property CCodeFrom() As String
        Get
            Return txtSCodeFrom.Text
        End Get
        Set(ByVal Value As String)
            txtSCodeFrom.Text = Value
        End Set
    End Property
    Public Property CCodeTo() As String
        Get
            Return txtSCodeTo.Text
        End Get
        Set(ByVal Value As String)
            txtSCodeTo.Text = Value
        End Set
    End Property
    Public Property SlsCode() As String
        Get
            Return txtPchCode.Text
        End Get
        Set(ByVal Value As String)
            txtPchCode.Text = Value
        End Set
    End Property

    Private Sub btnClear_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtSCodeFrom.Text = ""
        txtSCodeTo.Text = ""
        txtPchCode.Text = ""
        txtPNoFrom.Text = ""
        txtPNoTo.Text = ""
        cbStatus.SelectedIndex = 0
        chbDate.Checked = False
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSCodeFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSCodeFrom.Click
        Dim NewFormDialog As New fdlCustomerFrom
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub
    Private Sub btnSCodeTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSCodeTo.Click
        Dim NewFormDialog As New fdlCustomerFrom
        NewFormDialog.FrmCallerId = Me.Name + "To"
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

        If chbDate.Checked = True Then
            dtpFrom.Format = DateTimePickerFormat.Custom
            dtpFrom.CustomFormat = "yyyy/MM/dd"
            dtpTo.Format = DateTimePickerFormat.Custom
            dtpTo.CustomFormat = "yyyy/MM/dd"
            dateFrom1 = dtpFrom.Text
            dateTo1 = dtpTo.Text
        Else
            dateFrom1 = ""
            dateTo1 = ""
        End If

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
        Else
            Status = cbStatus.Items(cbStatus.SelectedIndex).ItemData
        End If

        strSQL = "exec RPT_Sls_InvoiceSummary_Report '" & dateFrom1 & "' , '" & dateTo1 & "', '" & pNoFrom1 & "', '" & pNoTo1 & "', '" & sCodeFrom1 & "', '" & sCodeTo1 & "', '" & Status & "', '" & pchCode1 & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SInvRptSum_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_InvoiceSummary_Report.rpt"

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
        NewMDIChild.Text = "Sales Invoice Report Summary"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("SInvRptSum_"))

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

        If chbDate.Checked = True Then
            filterdate = "Transaction Date : " & dtpFrom.Text & " - " & dtpTo.Text
        Else
            filterdate = "Transaction Date : All"
        End If

        If txtPNoFrom.Text = "" And txtPNoTo.Text = "" Then
            filterpno = "Sales Invoice No. : All"
        Else
            filterpno = "Sales Invoice No. : " & txtPNoFrom.Text & " - " & txtPNoTo.Text
        End If

        If txtSCodeFrom.Text = "" And txtSCodeTo.Text = "" Then
            filterscode = "Customer Code : All"
        Else
            filterscode = "Customer Code : " & txtSCodeFrom.Text & " - " & txtSCodeTo.Text
        End If

        If txtPchCode.Text = "" Then
            filterpch = "Sales Code : All"
        Else
            filterpch = "Sales Code : " & txtPchCode.Text
        End If

        If cbStatus.SelectedIndex = 0 Then
            filterstatus = "Status : All"
        Else
            filterstatus = "Status : " & cbStatus.Text
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
        Dim NewFormDialog As New fdlSlsCodeFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPNoFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPNoFrom.Click
        Dim NewFormDialog As New fdlSInvoiceFrom
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPNoTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPNoTo.Click
        Dim NewFormDialog As New fdlSInvoiceFrom
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub chbDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbDate.CheckedChanged
        If chbDate.Checked = True Then
            dtpFrom.Enabled = True
            dtpTo.Enabled = True
        Else
            dtpFrom.Enabled = False
            dtpTo.Enabled = False
            dtpFrom.Value = Now
            dtpTo.Value = Now
        End If
    End Sub
End Class