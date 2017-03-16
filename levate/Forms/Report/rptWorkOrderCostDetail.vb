Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class rptWorkOrderCostDetail

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub rptWorkOrderCostDetail_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"

    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        txtCostCodeFrom.Text = ""
        txtCostCodeTo.Text = ""
    End Sub

    Private Sub btnExpIncFrom_Click(sender As System.Object, e As System.EventArgs) Handles btnExpIncFrom.Click
        Dim NewFormDialog As New fdlCost
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnExpIncTo_Click(sender As System.Object, e As System.EventArgs) Handles btnExpIncTo.Click
        Dim NewFormDialog As New fdlCost
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        If chkConfirmInDate.Checked = True Then
            pPrintWorkOrderCostDetailPartiall()
        Else
            pPrintWorkOrderCostDetail()
        End If

        

    End Sub

    Private Sub pPrintWorkOrderCostDetail()
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)

        Dim costcodefrom As String
        Dim costcodeto As String

        costcodefrom = txtCostCodeFrom.Text

        If txtCostCodeTo.Text.Length = 0 Then
            costcodeto = "ZZZZZZZZZZ"
        Else
            costcodeto = txtCostCodeTo.Text
        End If

        Dim cm As SqlCommand = New SqlCommand("exec RPT_WO_Cost_Dtl_Report @dtfrom,@dtto,@costfrom,@costto ", Connection)
        cm.Parameters.AddWithValue("@dtfrom", dtpFrom.Value)
        cm.Parameters.AddWithValue("@dtto", dtpTo.Value)
        cm.Parameters.AddWithValue("@costfrom", costcodefrom)
        cm.Parameters.AddWithValue("@costto", costcodeto)

        Connection.Open()

        Dim da As New SqlDataAdapter(cm)
        Dim dt As New DataTable

        da.Fill(dt)

        Connection.Close()

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_WO_Cost_Dtl_Report.rpt"

        'load custom rpt if available
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
        NewMDIChild.Text = "Work Order Cost Detail Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(dt)
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With

        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterdate As String
        Dim filtercostcode As String

        filterdate = "Transaction Date : " & dtpFrom.Text & " - " & dtpTo.Text

        If txtCostCodeFrom.Text = "" And txtCostCodeTo.Text = "" Then
            filtercostcode = "Cost Code : All"
        Else
            filtercostcode = "Cost Code : " & txtCostCodeFrom.Text & " - " & txtCostCodeTo.Text
        End If

        Dim filter As String = filterdate + vbCrLf + filtercostcode

        crParameterDiscreteValue.Value = filter
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filter")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
    End Sub

    Private Sub pPrintWorkOrderCostDetailPartiall()
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        Dim costcodefrom As String
        Dim costcodeto As String

        costcodefrom = txtCostCodeFrom.Text

        If txtCostCodeTo.Text.Length = 0 Then
            costcodeto = "ZZZZZZZZZZ"
        Else
            costcodeto = txtCostCodeTo.Text
        End If

        strSQL = "exec RPT_WO_Cost_Dtl_Partiall_Report '" & Format(dtpFrom.Value, "yyyy/MM/dd") & "' , " & _
                    "'" & Format(dtpTo.Value, "yyyy/MM/dd") & "', '" & costcodefrom & "', '" & costcodeto & "'"


        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "WOCost_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_WO_Cost_Dtl_Partiall_Report.rpt"

        'load custom rpt if available
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
        NewMDIChild.Text = "Work Order Cost Detail Report by Confirm In"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("WOCost_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With

        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterdate As String
        Dim filtercostcode As String

        filterdate = "Transaction Date : " & dtpFrom.Text & " - " & dtpTo.Text

        If txtCostCodeFrom.Text = "" And txtCostCodeTo.Text = "" Then
            filtercostcode = "Cost Code : All"
        Else
            filtercostcode = "Cost Code : " & txtCostCodeFrom.Text & " - " & txtCostCodeTo.Text
        End If

        Dim filter As String = filterdate + vbCrLf + filtercostcode

        crParameterDiscreteValue.Value = filter
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filter")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
    End Sub

End Class