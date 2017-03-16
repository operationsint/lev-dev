Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptExpInc
    Private Sub rptExpInc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"

        cbFilter.Items.Add("All")
        cbFilter.Items.Add("Expense")
        cbFilter.Items.Add("Income")
        cbFilter.SelectedIndex = 0
    End Sub

    Public Property ExpIncFrom() As String
        Get
            Return txtExpIncFrom.Text
        End Get
        Set(ByVal Value As String)
            txtExpIncFrom.Text = Value
        End Set
    End Property
    Public Property ExpIncTo() As String
        Get
            Return txtExpIncTo.Text
        End Get
        Set(ByVal Value As String)
            txtExpIncTo.Text = Value
        End Set
    End Property

    Private Sub btnClear_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtExpIncFrom.Text = ""
        txtExpIncTo.Text = ""
        cbFilter.SelectedIndex = 0
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom1 As String
        Dim dateTo1 As String
        Dim expincFrom1 As String
        Dim expincTo1 As String
        Dim filter1 As String

        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "yyyy/MM/dd"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "yyyy/MM/dd"
        dateFrom1 = dtpFrom.Text
        dateTo1 = dtpTo.Text

        If txtExpIncFrom.Text <> "" Then
            expincFrom1 = txtExpIncFrom.Text
        Else
            expincFrom1 = ""
        End If

        If txtExpIncTo.Text <> "" Then
            expincTo1 = txtExpIncTo.Text
        Else
            expincTo1 = ""
        End If

        If cbFilter.SelectedIndex = 0 Then
            filter1 = ""
        ElseIf cbFilter.SelectedIndex = 1 Then
            filter1 = "E"
        Else
            filter1 = "I"
        End If


        strSQL = "exec RPT_OTH_ExpInc_Dtl_Report '" & dateFrom1 & "' , '" & dateTo1 & "', '" & expincFrom1 & "', '" & expincTo1 & "', '" & filter1 & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "ExpIncDetailRpt_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_ExpInc_Dtl_Report.rpt"

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
        NewMDIChild.Text = "Expense Income Detail Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("ExpIncDetailRpt_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
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
        Dim filterexpinc As String
        Dim filterfilter As String


        filterdate = "Transaction Date : " & dtpFrom.Text & " - " & dtpTo.Text

        If txtExpIncFrom.Text = "" And txtExpIncTo.Text = "" Then
            filterexpinc = "Expense Income Code : All"
        Else
            filterexpinc = "Expense Income Code : " & txtExpIncFrom.Text & " - " & txtExpIncTo.Text
        End If

        If cbFilter.SelectedIndex = 0 Then
            filterfilter = "Filter : All"
        ElseIf cbFilter.SelectedIndex = 1 Then
            filterfilter = "Filter : Expense"
        Else
            filterfilter = "Filter : Income"
        End If

        Dim filter As String = filterdate + vbCrLf + filterexpinc + vbCrLf + filterfilter

        crParameterDiscreteValue.Value = filter
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filter")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
    End Sub
    
    Private Sub btnExpIncFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpIncFrom.Click
        Dim NewFormDialog As New fdlExpenseIncome
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnExpIncTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpIncTo.Click
        Dim NewFormDialog As New fdlExpenseIncome
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPrintRecap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintRecap.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom1 As String
        Dim dateTo1 As String
        Dim expincFrom1 As String
        Dim expincTo1 As String
        Dim filter1 As String

        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "yyyy/MM/dd"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "yyyy/MM/dd"
        dateFrom1 = dtpFrom.Text
        dateTo1 = dtpTo.Text

        If txtExpIncFrom.Text <> "" Then
            expincFrom1 = txtExpIncFrom.Text
        Else
            expincFrom1 = ""
        End If

        If txtExpIncTo.Text <> "" Then
            expincTo1 = txtExpIncTo.Text
        Else
            expincTo1 = ""
        End If

        If cbFilter.SelectedIndex = 0 Then
            filter1 = ""
        ElseIf cbFilter.SelectedIndex = 1 Then
            filter1 = "E"
        Else
            filter1 = "I"
        End If


        strSQL = "exec RPT_OTH_ExpInc_SUM_Report '" & dateFrom1 & "' , '" & dateTo1 & "', '" & expincFrom1 & "', '" & expincTo1 & "', '" & filter1 & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "ExpIncSummaryRpt_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_ExpInc_Sum_Report.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Expense Income Summary Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("ExpIncSummaryRpt_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
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
        Dim filterexpinc As String
        Dim filterfilter As String


        filterdate = "Transaction Date : " & dtpFrom.Text & " - " & dtpTo.Text

        If txtExpIncFrom.Text = "" And txtExpIncTo.Text = "" Then
            filterexpinc = "Expense Income Code : All"
        Else
            filterexpinc = "Expense Income Code : " & txtExpIncFrom.Text & " - " & txtExpIncTo.Text
        End If

        If cbFilter.SelectedIndex = 0 Then
            filterfilter = "Filter : All"
        ElseIf cbFilter.SelectedIndex = 1 Then
            filterfilter = "Filter : Expense"
        Else
            filterfilter = "Filter : Income"
        End If

        Dim filter As String = filterdate + vbCrLf + filterexpinc + vbCrLf + filterfilter

        crParameterDiscreteValue.Value = filter
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filter")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
    End Sub
End Class