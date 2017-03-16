Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptStkTransaction
    Private Sub rptStkTransaction_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
        GroupBox1.Enabled = False
    End Sub
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
    Public Property StkCat() As String
        Get
            Return txtStkCategory.Text
        End Get
        Set(ByVal Value As String)
            txtStkCategory.Text = Value
        End Set
    End Property
    Public Property LocationCode() As String
        Get
            Return txtLocation.Text
        End Get
        Set(ByVal Value As String)
            txtLocation.Text = Value
        End Set
    End Property

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom1 As String
        Dim dateTo1 As String
        Dim stkCodeFrom1 As String
        Dim stkCodeTo1 As String
        Dim stkCat1 As String
        Dim loc1 As String

        If rbAll.Checked = True Then
            dateFrom1 = ""
            dateTo1 = ""
            stkCodeFrom1 = ""
            stkCodeTo1 = ""
            stkCat1 = ""
            loc1 = ""
        Else
            dtpFrom.Format = DateTimePickerFormat.Custom
            dtpFrom.CustomFormat = "yyyy/MM/dd"
            dtpTo.Format = DateTimePickerFormat.Custom
            dtpTo.CustomFormat = "yyyy/MM/dd"
            dateFrom1 = dtpFrom.Text
            dateTo1 = dtpTo.Text
            If txtStkCodeFrom.Text <> "" And txtStkCodeTo.Text <> "" Then
                stkCodeFrom1 = txtStkCodeFrom.Text
                stkCodeTo1 = txtStkCodeTo.Text
                If txtStkCodeFrom.Text = "" And txtStkCodeTo.Text <> "" Then
                    stkCodeFrom1 = txtStkCodeTo.Text
                    stkCodeTo1 = txtStkCodeTo.Text
                ElseIf txtStkCodeFrom.Text <> "" And txtStkCodeTo.Text = "" Then
                    stkCodeFrom1 = txtStkCodeFrom.Text
                    stkCodeTo1 = txtStkCodeFrom.Text
                End If
            Else
                stkCodeFrom1 = ""
                stkCodeTo1 = ""
            End If
            If txtStkCategory.Text <> "" Then
                stkCat1 = txtStkCategory.Text
            Else
                stkCat1 = ""
            End If
            If txtLocation.Text <> "" Then
                loc1 = txtLocation.Text
            Else
                loc1 = ""
            End If
        End If

        strSQL = "exec RPT_Stk_Transaction_Report '" & dateFrom1 & "' , '" & dateTo1 & "', '" & stkCodeFrom1 & "', '" & stkCodeTo1 & "', '" & stkCat1 & "', '" & loc1 & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "StkTrans_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Stk_Transaction_Report.rpt"

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
        NewMDIChild.Text = "Stock Transaction"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("StkTrans_"))
        
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
        Dim filterstkcode As String
        Dim filtercat As String
        Dim filterloc As String
        If rbAll.Checked = True Then
            filterdate = "Transaction Date : All"
            filterstkcode = "Stock Code : All"
            filtercat = "Category : All"
            filterloc = "Location : All"
        Else
            filterdate = "Transaction Date : " & dtpFrom.Text & " - " & dtpTo.Text
            If txtStkCodeFrom.Text = "" And txtStkCodeTo.Text = "" Then
                filterstkcode = "Stock Code : All"
            Else
                filterstkcode = "Stock Code : " & txtStkCodeFrom.Text & " - " & txtStkCodeTo.Text
            End If
            If txtStkCategory.Text = "" Then
                filtercat = "Category : All"
            Else
                filtercat = "Category : " & txtStkCategory.Text
            End If
            If txtLocation.Text = "" Then
                filterloc = "Location : All"
            Else
                filterloc = "Location : " & txtLocation.Text
            End If

        End If
        Dim filter As String = filterdate + vbCrLf + filterstkcode + vbCrLf + filtercat + vbCrLf + filterloc

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

    Private Sub btnPrint2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint2.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom1 As String
        Dim dateTo1 As String
        Dim stkCodeFrom1 As String
        Dim stkCodeTo1 As String
        Dim stkCat1 As String
        Dim loc1 As String

        If rbAll.Checked = True Then
            dateFrom1 = ""
            dateTo1 = ""
            stkCodeFrom1 = ""
            stkCodeTo1 = ""
            stkCat1 = ""
            loc1 = ""
        Else
            dtpFrom.Format = DateTimePickerFormat.Custom
            dtpFrom.CustomFormat = "yyyy/MM/dd"
            dtpTo.Format = DateTimePickerFormat.Custom
            dtpTo.CustomFormat = "yyyy/MM/dd"
            dateFrom1 = dtpFrom.Text
            dateTo1 = dtpTo.Text
            If txtStkCodeFrom.Text <> "" And txtStkCodeTo.Text <> "" Then
                stkCodeFrom1 = txtStkCodeFrom.Text
                stkCodeTo1 = txtStkCodeTo.Text
                If txtStkCodeFrom.Text = "" And txtStkCodeTo.Text <> "" Then
                    stkCodeFrom1 = txtStkCodeTo.Text
                    stkCodeTo1 = txtStkCodeTo.Text
                ElseIf txtStkCodeFrom.Text <> "" And txtStkCodeTo.Text = "" Then
                    stkCodeFrom1 = txtStkCodeFrom.Text
                    stkCodeTo1 = txtStkCodeFrom.Text
                End If
            Else
                stkCodeFrom1 = ""
                stkCodeTo1 = ""
            End If
            If txtStkCategory.Text <> "" Then
                stkCat1 = txtStkCategory.Text
            Else
                stkCat1 = ""
            End If
            If txtLocation.Text <> "" Then
                loc1 = txtLocation.Text
            Else
                loc1 = ""
            End If
        End If

        strSQL = "exec RPT_Stk_Transaction_Report '" & dateFrom1 & "' , '" & dateTo1 & "', '" & stkCodeFrom1 & "', '" & stkCodeTo1 & "', '" & stkCat1 & "', '" & loc1 & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "StkTrans2_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Stk_Transaction_Report_NoCurr.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Stock Transaction"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("StkTrans2_"))

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
        Dim filterstkcode As String
        Dim filtercat As String
        Dim filterloc As String
        If rbAll.Checked = True Then
            filterdate = "Transaction Date : All"
            filterstkcode = "Stock Code : All"
            filtercat = "Category : All"
            filterloc = "Location : All"
        Else
            filterdate = "Transaction Date : " & dtpFrom.Text & " - " & dtpTo.Text
            If txtStkCodeFrom.Text = "" And txtStkCodeTo.Text = "" Then
                filterstkcode = "Stock Code : All"
            Else
                filterstkcode = "Stock Code : " & txtStkCodeFrom.Text & " - " & txtStkCodeTo.Text
            End If
            If txtStkCategory.Text = "" Then
                filtercat = "Category : All"
            Else
                filtercat = "Category : " & txtStkCategory.Text
            End If
            If txtLocation.Text = "" Then
                filterloc = "Location : All"
            Else
                filterloc = "Location : " & txtLocation.Text
            End If

        End If
        Dim filter As String = filterdate + vbCrLf + filterstkcode + vbCrLf + filtercat + vbCrLf + filterloc

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

    Private Sub rbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAll.CheckedChanged
        GroupBox1.Enabled = False
    End Sub

    Private Sub rbPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPeriod.CheckedChanged
        GroupBox1.Enabled = True
    End Sub

    Private Sub btnStockCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStockCategory.Click
        Dim NewFormDialog As New fdlSKUCat
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtStkCodeFrom.Text = ""
        txtStkCodeTo.Text = ""
        txtStkCategory.Text = ""
        txtLocation.Text = ""
    End Sub

    Private Sub btnLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocation.Click
        Dim NewFormDialog As New fdlLocation
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    
End Class