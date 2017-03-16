Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Form1
    Private northwindCustomersReport As ReportDocument
    Private Const PARAMETER_FIELD_NAME As String = "@po_id"

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim reportPath As String = Application.StartupPath & "\" & "NorthwindCustomers.rpt"
        'Non-embedded reports
        'option 1
        'CrystalReportViewer1.ReportSource = reportPath

        'option 2
        'Dim rd As ReportDocument = New ReportDocument()
        'rd.Load(reportPath)

        'CrystalReportViewer1.ReportSource = rd

        'test
        'ConfigureCrystalReports()
    End Sub

    Private Sub ReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SetDBLogonForReport(ByVal myConnectionInfo As ConnectionInfo, ByVal myReportDocument As ReportDocument)
        Dim myTables As Tables = myReportDocument.Database.Tables
        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            myTableLogonInfo.ConnectionInfo = myConnectionInfo
            myTable.ApplyLogOnInfo(myTableLogonInfo)
        Next
    End Sub

    Private Sub ConfigureCrystalReports()

        '==== using sql auth ====
        'Dim reportPath As String = Application.StartupPath & "\" & "NorthwindCustomers.rpt"
        'CrystalReportViewer1.ReportSource = reportPath
        'Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        'SetDBLogonForReport(myConnectionInfo)
        'myConnectionInfo.ServerName = "localhost"
        'myConnectionInfo.DatabaseName = "Northwind"
        'myConnectionInfo.UserID = "i822460"
        'myConnectionInfo.Password = ""

        northwindCustomersReport = New ReportDocument()
        Dim reportPath As String = Application.StartupPath & "\" & "docPO.rpt"
        northwindCustomersReport.Load(reportPath)

        Dim myConnectionInfo As ConnectionInfo = New ConnectionInfo()
        myConnectionInfo.ServerName = My.Settings.SvrName
        myConnectionInfo.DatabaseName = My.Settings.DBName
        myConnectionInfo.IntegratedSecurity = True
        SetDBLogonForReport(myConnectionInfo, northwindCustomersReport)

        'Dim myArrayList As ArrayList = New ArrayList()
        'myArrayList.Add("3")
        'myArrayList.Add("4")

        'defaultParameterValuesList.DataSource = GetDefaultValuesFromParameterField(northwindCustomersReport)

        'SetCurrentValuesForParameterField(northwindCustomersReport, myArrayList)

        'myCrystalReportViewer.ReportSource = reportPath
        myCrystalReportViewer.ReportSource = northwindCustomersReport

        '--tambahan parameter
        Dim field1 As ParameterField = Me.myCrystalReportViewer.ParameterFieldInfo(0)
        Dim val1 As New ParameterDiscreteValue()
        val1.Value = "4"
        field1.CurrentValues.Add(val1)
    End Sub

    Private Sub SetCurrentValuesForParameterField(ByVal myReportDocument As ReportDocument, ByVal myArrayList As ArrayList)
        Dim currentParameterValues As ParameterValues = New ParameterValues()
        For Each submittedValue As Object In myArrayList
            Dim myParameterDiscreteValue As ParameterDiscreteValue = New ParameterDiscreteValue()
            myParameterDiscreteValue.Value = submittedValue.ToString()
            currentParameterValues.Add(myParameterDiscreteValue)
        Next

        Dim myParameterFieldDefinitions As ParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields
        Dim myParameterFieldDefinition As ParameterFieldDefinition = myParameterFieldDefinitions(PARAMETER_FIELD_NAME)
        myParameterFieldDefinition.ApplyCurrentValues(currentParameterValues)
    End Sub

    Private Function GetDefaultValuesFromParameterField(ByVal myReportDocument As ReportDocument) As ArrayList
        Dim myParameterFieldDefinitions As ParameterFieldDefinitions = myReportDocument.DataDefinition.ParameterFields
        Dim myParameterFieldDefinition As ParameterFieldDefinition = myParameterFieldDefinitions(PARAMETER_FIELD_NAME)
        Dim defaultParameterValues As ParameterValues = myParameterFieldDefinition.DefaultValues
        Dim myArrayList As ArrayList = New ArrayList()

        For Each myParameterValue As ParameterValue In defaultParameterValues
            If (Not myParameterValue.IsRange) Then
                Dim myParameterDiscreteValue As ParameterDiscreteValue = CType(myParameterValue, ParameterDiscreteValue)
                myArrayList.Add(myParameterDiscreteValue.Value.ToString())
            End If
        Next

        Return myArrayList
    End Function


    Private Sub redisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles redisplay.Click
        Dim myArrayList As ArrayList = New ArrayList()
        For Each item As String In defaultParameterValuesList.SelectedItems
            myArrayList.Add(item)
        Next

        SetCurrentValuesForParameterField(northwindCustomersReport, myArrayList)
        myCrystalReportViewer.ReportSource = northwindCustomersReport
    End Sub
End Class