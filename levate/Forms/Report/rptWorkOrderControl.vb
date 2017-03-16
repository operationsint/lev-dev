Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptWorkOrderControl

    Private Sub rptWorkOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"

        '20160801 add filter status
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
    Public Property LocationCode() As String
        Get
            Return txtLocation.Text()
        End Get
        Set(ByVal Value As String)
            txtLocation.Text() = Value
        End Set
    End Property
    Public Property StkCodeFrom() As String
        Get
            Return txtStkCodeFrom.Text
        End Get
        Set(ByVal Value As String)
            txtStkCodeFrom.Text = Value
        End Set
    End Property
    Public Property StkCodeTo() As String
        Get
            Return txtStkCodeTo.Text
        End Get
        Set(ByVal Value As String)
            txtStkCodeTo.Text = Value
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

        Dim skuFrom1 As String
        Dim skuTo1 As String

        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "yyyy/MM/dd"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "yyyy/MM/dd"

        If cbDate.Checked = True Then
            dateFrom = dtpFrom.Text
            dateTo = dtpTo.Text
        Else
            dateFrom = "1900-01-01"
            dateTo = "9999-01-01"
        End If


        If txtWOFrom.Text <> "" And txtWOTo.Text <> "" Then
            WOFrom1 = txtWOFrom.Text
            WOTo1 = txtWOTo.Text
        ElseIf txtWOFrom.Text = "" And txtWOTo.Text <> "" Then
            WOFrom1 = txtWOTo.Text
            WOTo1 = txtWOTo.Text
        ElseIf txtWOFrom.Text <> "" And txtWOTo.Text = "" Then
            WOFrom1 = txtWOFrom.Text
            WOTo1 = txtWOFrom.Text
        Else
            WOFrom1 = ""
            WOTo1 = "ZZZZZZZZZZZZZZZZZZZZZZ"
        End If

        If txtStkCodeFrom.Text <> "" And txtStkCodeTo.Text <> "" Then
            skuFrom1 = txtStkCodeFrom.Text
            skuTo1 = txtStkCodeTo.Text
        ElseIf txtStkCodeFrom.Text = "" And txtStkCodeTo.Text <> "" Then
            skuFrom1 = txtStkCodeTo.Text
            skuTo1 = txtStkCodeTo.Text
        ElseIf txtStkCodeFrom.Text <> "" And txtStkCodeTo.Text = "" Then
            skuFrom1 = txtStkCodeFrom.Text
            skuTo1 = txtStkCodeFrom.Text
        Else
            skuFrom1 = ""
            skuTo1 = "ZZZZZZZZZZZZZZZ"
        End If

        '20160801 add filter status
        Dim status As String
        If cbStatus.SelectedIndex = 1 Then
            status = "O%"
        ElseIf cbStatus.SelectedIndex = 2 Then
            status = "P%"
        ElseIf cbStatus.SelectedIndex = 3 Then
            status = "C%"
        Else
            status = "%"
        End If

        strSQL = "exec RPT_Work_Order_Stk_Control '" & dateFrom & "' , '" & dateTo & "', '" & skuFrom1 & "', '" & skuTo1 & "', '" & WOFrom1 & "', '" & WOTo1 & "', '" & txtLocation.Text & "', '" & status & "'"

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "Work_Order_Report_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Work_Order_Control.rpt"

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
        NewMDIChild.Text = "Work Order Stock Control Report"
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
        Dim filtersku As String
        Dim filterloc As String

        Dim filterstatus As String
        If cbStatus.SelectedIndex = 1 Then
            filterstatus = "Status : Outstanding"
        ElseIf cbStatus.SelectedIndex = 2 Then
            filterstatus = "Status : Partial"
        ElseIf cbStatus.SelectedIndex = 3 Then
            filterstatus = "Status : Completed"
        Else
            filterstatus = "Status : All"
        End If

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

        If txtStkCodeFrom.Text = "" And txtStkCodeTo.Text = "" Then
            filtersku = "Stock Code : All"
        Else
            filtersku = "Stock Code : " & txtStkCodeFrom.Text & "-" & txtStkCodeTo.Text
        End If

        filterloc = "Location : " & IIf(txtLocation.Text.Length = 0, "All", txtLocation.Text)

        Dim filter As String = filterdate + vbCrLf + filterwono + vbCrLf + filtersku + vbCrLf + filterloc + vbTab + filterstatus
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
        txtLocation.Text = ""
        txtStkCodeFrom.Text = ""
        txtStkCodeTo.Text = ""
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

    Private Sub btnLocation_Click(sender As System.Object, e As System.EventArgs) Handles btnLocation.Click
        Dim NewFormDialog As New fdlLocation
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnStkCodeFrom_Click(sender As System.Object, e As System.EventArgs) Handles btnStkCodeFrom.Click
        Dim NewFormDialog As New fdlSKUFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()

    End Sub

    Private Sub btnStkCodeTo_Click(sender As System.Object, e As System.EventArgs) Handles btnStkCodeTo.Click
        Dim NewFormDialog As New fdlSKUTo
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub ButtonPrint2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonPrint2.Click
        ' 20160512 daniel s : same with print1 only different rpt grouping
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom As String
        Dim dateTo As String
        Dim WOFrom1 As String
        Dim WOTo1 As String

        Dim skuFrom1 As String
        Dim skuTo1 As String

        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "yyyy/MM/dd"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "yyyy/MM/dd"

        If cbDate.Checked = True Then
            dateFrom = dtpFrom.Text
            dateTo = dtpTo.Text
        Else
            dateFrom = "1900-01-01"
            dateTo = "9999-01-01"
        End If


        If txtWOFrom.Text <> "" And txtWOTo.Text <> "" Then
            WOFrom1 = txtWOFrom.Text
            WOTo1 = txtWOTo.Text
        ElseIf txtWOFrom.Text = "" And txtWOTo.Text <> "" Then
            WOFrom1 = txtWOTo.Text
            WOTo1 = txtWOTo.Text
        ElseIf txtWOFrom.Text <> "" And txtWOTo.Text = "" Then
            WOFrom1 = txtWOFrom.Text
            WOTo1 = txtWOFrom.Text
        Else
            WOFrom1 = ""
            WOTo1 = "ZZZZZZZZZZZZZZZZZZZZZZ"
        End If

        If txtStkCodeFrom.Text <> "" And txtStkCodeTo.Text <> "" Then
            skuFrom1 = txtStkCodeFrom.Text
            skuTo1 = txtStkCodeTo.Text
        ElseIf txtStkCodeFrom.Text = "" And txtStkCodeTo.Text <> "" Then
            skuFrom1 = txtStkCodeTo.Text
            skuTo1 = txtStkCodeTo.Text
        ElseIf txtStkCodeFrom.Text <> "" And txtStkCodeTo.Text = "" Then
            skuFrom1 = txtStkCodeFrom.Text
            skuTo1 = txtStkCodeFrom.Text
        Else
            skuFrom1 = ""
            skuTo1 = "ZZZZZZZZZZZZZZZ"
        End If

        '20160801 add filter status
        Dim status As String
        If cbStatus.SelectedIndex = 1 Then
            status = "O%"
        ElseIf cbStatus.SelectedIndex = 2 Then
            status = "P%"
        ElseIf cbStatus.SelectedIndex = 3 Then
            status = "C%"
        Else
            status = "%"
        End If

        strSQL = "exec RPT_Work_Order_Stk_Control '" & dateFrom & "' , '" & dateTo & "', '" & skuFrom1 & "', '" & skuTo1 & "', '" & WOFrom1 & "', '" & WOTo1 & "', '" & txtLocation.Text & "', '" & status & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "Work_Order_Report_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Work_Order_Control2.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Work Order Stock Control Report"
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
        Dim filtersku As String
        Dim filterloc As String

        Dim filterstatus As String
        If cbStatus.SelectedIndex = 1 Then
            filterstatus = "Status : Outstanding"
        ElseIf cbStatus.SelectedIndex = 2 Then
            filterstatus = "Status : Partial"
        ElseIf cbStatus.SelectedIndex = 3 Then
            filterstatus = "Status : Completed"
        Else
            filterstatus = "Status : All"
        End If

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

        If txtStkCodeFrom.Text = "" And txtStkCodeTo.Text = "" Then
            filtersku = "Stock Code : All"
        Else
            filtersku = "Stock Code : " & txtStkCodeFrom.Text & "-" & txtStkCodeTo.Text
        End If

        filterloc = "Location : " & IIf(txtLocation.Text.Length = 0, "All", txtLocation.Text)

        Dim filter As String = filterdate + vbCrLf + filterwono + vbCrLf + filtersku + vbCrLf + filterloc + vbTab + filterstatus
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