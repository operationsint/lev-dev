Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptSlsReceipt
    Private Sub rptSlsReceipt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
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


    Private Sub btnClear_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtSCodeFrom.Text = ""
        txtSCodeTo.Text = ""
        txtPNoFrom.Text = ""
        txtPNoTo.Text = ""
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSCodeFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSCodeFrom.Click
        Dim NewFormDialog As New fdlCustomerFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub
    Private Sub btnSCodeTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSCodeTo.Click
        Dim NewFormDialog As New fdlCustomerTo
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

        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "yyyy/MM/dd"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "yyyy/MM/dd"
        dateFrom1 = dtpFrom.Text
        dateTo1 = dtpTo.Text

        '--------------------Start Payment No------------------------------
        If txtPNoFrom.Text <> "" And txtPNoTo.Text <> "" Then
            pNoFrom1 = txtSCodeFrom.Text
            pNoTo1 = txtSCodeTo.Text
        End If
        If txtPNoFrom.Text = "" And txtPNoTo.Text <> "" Then
            pNoFrom1 = txtPNoTo.Text
            pNoTo1 = txtPNoTo.Text
        End If
        If txtPNoFrom.Text <> "" And txtPNoTo.Text = "" Then
            pNoFrom1 = txtPNoFrom.Text
            pNoTo1 = txtPNoFrom.Text
        End If
        If txtPNoFrom.Text = "" And txtPNoTo.Text = "" Then
            pNoFrom1 = ""
            pNoTo1 = ""
        End If
        '--------------------End Payment No------------------------------

        '--------------------Start Supplier No------------------------------
        If txtSCodeFrom.Text <> "" And txtSCodeTo.Text <> "" Then
            sCodeFrom1 = txtSCodeFrom.Text
            sCodeTo1 = txtSCodeTo.Text
        End If
        If txtSCodeFrom.Text = "" And txtSCodeTo.Text <> "" Then
            sCodeFrom1 = txtSCodeTo.Text
            sCodeTo1 = txtSCodeTo.Text
        End If
        If txtSCodeFrom.Text <> "" And txtSCodeTo.Text = "" Then
            sCodeFrom1 = txtSCodeFrom.Text
            sCodeTo1 = txtSCodeFrom.Text
        End If
        If txtSCodeFrom.Text = "" And txtSCodeTo.Text = "" Then
            sCodeFrom1 = ""
            sCodeTo1 = ""
        End If
        '--------------------End Supplier No------------------------------

        strSQL = "exec RPT_Sls_Receipt_Report '" & dateFrom1 & "' , '" & dateTo1 & "', '" & pNoFrom1 & "', '" & pNoTo1 & "', '" & sCodeFrom1 & "', '" & sCodeTo1 & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SlsRcptRpt_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_Receipt_Report.rpt"

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
        NewMDIChild.Text = "Sales Receipt Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("SlsRcptRpt_"))

        '-----------------MENAMBAH PARAMETER FILTER KE CR--------------------------
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterdate As String = "Sales Receipt Date : " + dtpFrom.Text + " - " + dtpTo.Text
        Dim filterpno As String
        Dim filterscode As String

        If txtPNoFrom.Text = "" And txtPNoTo.Text = "" Then
            filterpno = "Sales Receipt No : All"
        Else
            filterpno = "Sales Receipt No : " + pNoFrom1 + " - " + pNoTo1
        End If

        If txtSCodeFrom.Text = "" And txtSCodeTo.Text = "" Then
            filterscode = "Customer Code : All"
        Else
            filterscode = "Customer Code : " + sCodeFrom1 + " - " + sCodeTo1
        End If

        Dim filter As String = filterdate + vbCrLf + filterpno + vbCrLf + filterscode

        crParameterDiscreteValue.Value = filter
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filter")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
        '--------------------End PARAMETER CR------------------------------

        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub


    Private Sub btnPNoFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPNoFrom.Click
        Dim NewFormDialog As New fdlSReceiptFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPNoTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPNoTo.Click
        Dim NewFormDialog As New fdlSReceiptTo
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub
End Class