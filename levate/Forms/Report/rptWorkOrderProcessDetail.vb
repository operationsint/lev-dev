Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class rptWorkOrderProcessDetail

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub rptWorkOrderProcessDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtFinishGoods.Text = ""
        txtProcess.Text = ""
    End Sub

    Private Sub btnFinishGoods_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinishGoods.Click
        Dim NewFormDialog As New fdlSKU
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        Dim NewFormDialog As New fdlProcess
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        pPrintWorkOrderProcessDetail()
    End Sub

    Private Sub pPrintWorkOrderProcessDetail()
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        Dim sFinishGoodsP As String
        Dim sProcessP As String

        sFinishGoodsP = txtFinishGoods.Text
        sProcessP = txtProcess.Text

        strSQL = "Exec RPT_WO_Process_Detail_Report '" & Format(dtpFrom.Value, "yyyy/MM/dd") & "' , " & _
                    "'" & Format(dtpTo.Value, "yyyy/MM/dd") & "', '" & sFinishGoodsP & "', '" & sProcessP & "'"


        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "WOProcessDetail_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_WO_Process_Detail_Report.rpt"

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
        NewMDIChild.Text = "Work Order Process Detail Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("WOProcessDetail_"))
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
        Dim filterfinishgoods As String
        Dim filterprocess As String

        filterdate = "Transaction Date : " & dtpFrom.Text & " - " & dtpTo.Text

        If Trim(txtFinishGoods.Text) = "" Then
            filterfinishgoods = "Finish Goods : All"
        Else
            filterfinishgoods = "Finish Goods : " & txtFinishGoods.Text
        End If

        If Trim(txtProcess.Text) = "" Then
            filterprocess = "Process : All"
        Else
            filterprocess = "Process : " & txtProcess.Text
        End If

        Dim filter As String = filterdate + vbCrLf + filterfinishgoods + vbCrLf + filterprocess

        crParameterDiscreteValue.Value = filter
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filter")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
    End Sub

End Class