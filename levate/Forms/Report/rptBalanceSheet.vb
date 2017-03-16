Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class rptBalanceSheet

    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Public Property Period() As String
        Get
            Return txtPeriod.Text()
        End Get
        Set(ByVal Value As String)
            txtPeriod.Text() = Value
        End Set
    End Property

    Private Sub btnSearchPeriod_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchPeriod.Click
        Dim NewFormDialog As New fdlPeriod
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub rptBalanceSheet_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        txtPeriod.Text = ""
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click

        Dim Period1 As String

        'Period
        If txtPeriod.Text <> "" Then
            Period1 = txtPeriod.Text
        Else
            MessageBox.Show("Please select a Period !", "Error")
            Return
        End If

        Dim strSQL As String = "exec RPT_GL_BalanceSheet_Report '" & Period1 & "' "

        Dim DA As New SqlDataAdapter(strSQL, cn)
        Dim DS As New DataSet

        DA.Fill(DS, "Balance_Sheet_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Balance_Sheet.rpt"

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
        NewMDIChild.Text = "Balance Sheet"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("Balance_Sheet_"))

        '-----------------MENAMBAH PARAMETER FILTER DATE--------------------------
        'dtpFrom.Format = DateTimePickerFormat.Custom
        'dtpFrom.CustomFormat = "dd/MM/yyyy"
        'dtpTo.Format = DateTimePickerFormat.Custom
        'dtpTo.CustomFormat = "dd/MM/yyyy"
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue

        Dim filterperiod As String

        filterperiod = "Period : "


        If IsNumeric(txtPeriod.Text) = True Then

            cmd = New SqlCommand("SELECT top 1 period_name FROM sys_period WHERE period_id = '" & CInt(txtPeriod.Text) & "'", cn)
            cn.Open()

            Dim myReader2 As SqlDataReader = cmd.ExecuteReader()

            While myReader2.Read
                filterperiod = filterperiod & CStr(myReader2.Item(0))
            End While

            myReader2.Close()

            cn.Close()
            'filterperiod = "Periode : " & txtPeriod.Text
        Else
            filterperiod = filterperiod & "All"
        End If

        Dim filter As String = filterperiod + vbCrLf
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
End Class