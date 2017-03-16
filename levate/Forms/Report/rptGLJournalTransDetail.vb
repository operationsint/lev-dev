Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

'20160714 daniel s

Public Class rptGLJournalTransDetail

    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Public Property AccountCodeFrom() As String
        Get
            Return txtAccountFrom.Text
        End Get
        Set(ByVal Value As String)
            txtAccountFrom.Text = Value
        End Set
    End Property
    Public Property AccountCodeTo() As String
        Get
            Return txtAccountTo.Text()
        End Get
        Set(ByVal Value As String)
            txtAccountTo.Text() = Value
        End Set
    End Property

    Public Property PeriodFrom() As String
        Get
            Return txtPeriodFrom.Text()
        End Get
        Set(ByVal Value As String)
            txtPeriodFrom.Text() = Value
        End Set
    End Property
    Public Property PeriodTo() As String
        Get
            Return txtPeriodTo.Text()
        End Get
        Set(ByVal Value As String)
            txtPeriodTo.Text() = Value
        End Set
    End Property


    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        txtPeriodFrom.Text = ""
        txtPeriodTo.Text = ""
        txtAccountFrom.Text = ""
        txtAccountTo.Text = ""
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        If txtPeriodFrom.Text.Length = 0 Then
            MessageBox.Show("Please fill From Period", "Error")
            Exit Sub
        End If
        If txtPeriodTo.Text.Length = 0 Then
            MessageBox.Show("Please fill To Period", "Error")
            Exit Sub
        End If
        If txtAccountFrom.Text.Length = 0 Then
            MessageBox.Show("Please fill From Account", "Error")
            Exit Sub
        End If
        If txtAccountTo.Text.Length = 0 Then
            MessageBox.Show("Please fill To Account", "Error")
            Exit Sub
        End If

        Try
            'get period name
            Dim period_from_name As String = ""
            Dim period_to_name As String = ""

            cn.Open()

            cmd = New SqlCommand("select period_name from sys_period where period_id=@id", cn)
            cmd.Parameters.AddWithValue("@id", txtPeriodFrom.Text)

            Dim dr As SqlDataReader = cmd.ExecuteReader
            If dr.Read Then
                period_from_name = dr.GetString(0)
            End If
            dr.Close()

            cmd = New SqlCommand("select period_name from sys_period where period_id=@id", cn)
            cmd.Parameters.AddWithValue("@id", txtPeriodTo.Text)

            dr = cmd.ExecuteReader
            If dr.Read Then
                period_to_name = dr.GetString(0)
            End If
            dr.Close()

            'get report data

            cmd = New SqlCommand("exec RPT_GL_JournalTransDetail_Report @p1,@p2,@a1,@a2 ", cn)
            cmd.Parameters.AddWithValue("@p1", txtPeriodFrom.Text)
            cmd.Parameters.AddWithValue("@p2", txtPeriodTo.Text)
            cmd.Parameters.AddWithValue("@a1", txtAccountFrom.Text)
            cmd.Parameters.AddWithValue("@a2", txtAccountTo.Text)

            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            cn.Close()

            Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_GL_TransDetail.rpt"

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

            NewMDIChild.Text = "Journal Transaction Detail"
            NewMDIChild.Show()

            cr.Load(strReportPath)
            cr.SetDataSource(dt)

            'filter parameter untuk header report
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldDefinition As ParameterFieldDefinition
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue

            Dim filterperiod As String
            Dim filteraccountcode As String

            filterperiod = "Period : " & period_from_name & " - " & period_to_name
            filteraccountcode = "Account Code : " & txtAccountFrom.Text & " - " & txtAccountTo.Text

            Dim filter As String = filterperiod + vbCrLf + filteraccountcode
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

        Catch ex As Exception
            MessageBox.Show(ex.Message, "System Error")
        End Try


    End Sub

    Private Sub btnSearchPeriodFrom_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchPeriodFrom.Click
        Dim NewFormDialog As New fdlPeriod
        NewFormDialog.FrmCallerId = Me.Name & "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSearchPeriodTo_Click(sender As System.Object, e As System.EventArgs) Handles btnSearchPeriodTo.Click
        Dim NewFormDialog As New fdlPeriod
        NewFormDialog.FrmCallerId = Me.Name & "To"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnCodeFrom_Click(sender As System.Object, e As System.EventArgs) Handles btnCodeFrom.Click
        Dim NewFormDialog As New fdlAccount
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnCodeTo_Click(sender As System.Object, e As System.EventArgs) Handles btnCodeTo.Click
        Dim NewFormDialog As New fdlAccount
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub
End Class