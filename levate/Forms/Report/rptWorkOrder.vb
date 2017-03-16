Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptWorkOrder

    Private Sub rptWorkOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"

        cbType.Items.Insert(0, "All")
        cbType.Items.Insert(1, "Stock")
        cbType.Items.Insert(2, "Cost")
        cbType.SelectedIndex = 0

        cbStatus.Items.Insert(0, "All")
        cbStatus.Items.Insert(1, "Outstanding")
        cbStatus.Items.Insert(2, "Partial")
        cbStatus.Items.Insert(3, "Completed")
        cbStatus.SelectedIndex = 0

        cbDate.Checked = False
        dtpFrom.Enabled = False
        dtpTo.Enabled = False
    End Sub
    Public Property WONoFrom() As String
        Get
            Return txtWOFrom.Text
        End Get
        Set(ByVal Value As String)
            txtWOFrom.Text = Value
        End Set
    End Property
    Public Property WONoTo() As String
        Get
            Return txtWOTo.Text()
        End Get
        Set(ByVal Value As String)
            txtWOTo.Text() = Value
        End Set
    End Property

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom As String
        Dim dateTo As String
        Dim WOFrom1 As String
        Dim WOTo1 As String
        Dim Type As String
        Dim Status As String

        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "yyyy/MM/dd"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "yyyy/MM/dd"

        If cbDate.Checked = True Then
            dateFrom = dtpFrom.Text
            dateTo = dtpTo.Text
        Else
            dateFrom = ""
            dateTo = ""
        End If


        If txtWOFrom.Text <> "" And txtWOTo.Text <> "" Then
            WOFrom1 = txtWOFrom.Text
            WOTo1 = txtWOTo.Text
            If txtWOFrom.Text = "" And txtWOTo.Text <> "" Then
                WOFrom1 = txtWOTo.Text
                WOTo1 = txtWOTo.Text
            ElseIf txtWOFrom.Text <> "" And txtWOTo.Text = "" Then
                WOFrom1 = txtWOFrom.Text
                WOTo1 = txtWOFrom.Text
            End If
        Else
            WOFrom1 = ""
            WOTo1 = ""
        End If

        If cbType.SelectedIndex = 1 Then
            Type = "In"
        ElseIf cbType.SelectedIndex = 2 Then
            Type = "Out"
        Else
            Type = ""
        End If

        If cbStatus.SelectedIndex = 1 Then
            Status = "Outstanding"
        ElseIf cbStatus.SelectedIndex = 2 Then
            Status = "Partial"
        ElseIf cbStatus.SelectedIndex = 3 Then
            Status = "Completed"
        Else
            Status = ""
        End If


        strSQL = "exec RPT_Work_Order_Report '" & dateFrom & "' , '" & dateTo & "', '" & WOFrom1 & "', '" & WOTo1 & "', '" & Type & "', '" & Status & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "Work_Order_Report_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Work_Order_Report.rpt"

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
        NewMDIChild.Text = "Work Order Production Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("Work_Order_Report_"))

        '-----------------MENAMBAH PARAMETER FILTER DATE--------------------------
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterdate As String
        Dim filterwono As String
        Dim filtertype As String
        Dim filterstatus As String

        If cbDate.Checked = True Then
            filterdate = "Work Order Date : " & dtpFrom.Text & "-" & dtpTo.Text
        Else
            filterdate = "Work Order Date : All"
        End If

        If txtWOFrom.Text = "" And txtWOTo.Text = "" Then
            filterwono = "Work Order No : All"
        Else
            filterwono = "Work Order No : " & txtWOFrom.Text & "-" & txtWOTo.Text
        End If

        If cbType.SelectedIndex = 0 Then
            filtertype = "Type : All"
        Else
            filtertype = "Type : " & cbType.SelectedItem
        End If

        If cbStatus.SelectedIndex = 0 Then
            filterstatus = "Status : All"
        Else
            filterstatus = "Status : " & cbStatus.SelectedItem
        End If


        Dim filter As String = filterdate + vbCrLf + filterwono + vbCrLf + filtertype + vbCrLf + filterstatus
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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtWOFrom.Text = ""
        txtWOTo.Text = ""
        cbStatus.SelectedIndex = 0
        cbType.SelectedIndex = 0
        cbDate.Checked = False
    End Sub

    Private Sub btnPchCodeFrom_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankCodeFrom.Click
        Dim NewFormDialog As New fdlWorkOrder
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPchCodeTo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankCodeTo.Click
        Dim NewFormDialog As New fdlWorkOrder
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub cbDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDate.CheckedChanged
        If cbDate.Checked = True Then
            dtpFrom.Enabled = True
            dtpTo.Enabled = True
        Else
            dtpFrom.Enabled = False
            dtpTo.Enabled = False
        End If
    End Sub
End Class