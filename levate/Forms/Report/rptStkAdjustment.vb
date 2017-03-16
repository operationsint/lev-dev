Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptStkAdjustment
    Private Sub rptStkAdjustment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
        GroupBox1.Enabled = False
    End Sub
    Public Property NoFrom() As String
        Get
            Return txtStkAdjustmentFrom.Text
        End Get
        Set(ByVal Value As String)
            txtStkAdjustmentFrom.Text = Value
        End Set
    End Property
    Public Property NoTo() As String
        Get
            Return txtStkAdjustmentTo.Text
        End Get
        Set(ByVal Value As String)
            txtStkAdjustmentTo.Text = Value
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

    Private Sub rbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAll.CheckedChanged
        GroupBox1.Enabled = False
    End Sub

    Private Sub rbPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPeriod.CheckedChanged
        GroupBox1.Enabled = True
    End Sub

    Private Sub btnStkCodeFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStkCodeFrom.Click
        Dim NewFormDialog As New fdlSKUFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnStkCodeTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStkCodeTo.Click
        Dim NewFormDialog As New fdlSKUTo
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtSCodeFrom.Text = ""
        txtSCodeTo.Text = ""
        txtStkAdjustmentFrom.Text = ""
        txtStkAdjustmentTo.Text = ""
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
        Dim NoFrom1 As String
        Dim NoTo1 As String
        Dim sCodeFrom1 As String
        Dim sCodeTo1 As String

        If rbAll.Checked = True Then
            dateFrom1 = ""
            dateTo1 = ""
            NoFrom1 = ""
            NoTo1 = ""
            sCodeFrom1 = ""
            sCodeTo1 = ""
        Else
            dtpFrom.Format = DateTimePickerFormat.Custom
            dtpFrom.CustomFormat = "yyyy/MM/dd"
            dtpTo.Format = DateTimePickerFormat.Custom
            dtpTo.CustomFormat = "yyyy/MM/dd"
            dateFrom1 = dtpFrom.Text
            dateTo1 = dtpTo.Text
            If txtStkAdjustmentFrom.Text <> "" And txtStkAdjustmentTo.Text <> "" Then
                NoFrom1 = txtStkAdjustmentFrom.Text
                NoTo1 = txtStkAdjustmentTo.Text
                If txtStkAdjustmentFrom.Text = "" And txtStkAdjustmentTo.Text <> "" Then
                    NoFrom1 = txtStkAdjustmentTo.Text
                    NoTo1 = txtStkAdjustmentTo.Text
                ElseIf txtStkAdjustmentFrom.Text <> "" And txtStkAdjustmentTo.Text = "" Then
                    NoFrom1 = txtStkAdjustmentFrom.Text
                    NoTo1 = txtStkAdjustmentFrom.Text
                End If
            Else
                NoFrom1 = ""
                NoTo1 = ""
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
        End If

        strSQL = "exec RPT_Stk_Adj_Report '" & dateFrom1 & "' , '" & dateTo1 & "', '" & NoFrom1 & "', '" & NoTo1 & "', '" & sCodeFrom1 & "', '" & sCodeTo1 & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "StkAdjRpt_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Stk_Adj_Report.rpt"

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
        NewMDIChild.Text = "Stock Adjustment Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("StkAdjRpt_"))
        
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
        Dim filterno As String
        Dim filterscode As String
        If rbAll.Checked = True Then
            filterdate = "Transaction Date : All"
            filterno = "Stock Adjustment No. : All"
            filterscode = "Stock Code : All"
        Else
            filterdate = "Transaction Date : " & dtpFrom.Text & " - " & dtpTo.Text
            If txtStkAdjustmentFrom.Text = "" And txtStkAdjustmentTo.Text = "" Then
                filterno = "Stock Adjustment No. : All"
            Else
                filterno = "Stock Adjustment No. : " & txtStkAdjustmentFrom.Text & " - " & txtStkAdjustmentTo.Text
            End If
            If txtSCodeFrom.Text = "" And txtSCodeTo.Text = "" Then
                filterscode = "Stock Code : All"
            Else
                filterscode = "Stock Code : " & txtSCodeFrom.Text & " - " & txtSCodeTo.Text
            End If

        End If
        Dim filter As String = filterdate + vbCrLf + filterno + vbCrLf + filterscode

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

    Private Sub btnStkAdjustmentFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStkAdjustmentFrom.Click
        Dim NewFormDialog As New fdlStkAdjustmentFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnStkAdjustmentTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStkAdjustmentTo.Click
        Dim NewFormDialog As New fdlStkAdjustmentTo
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub
End Class