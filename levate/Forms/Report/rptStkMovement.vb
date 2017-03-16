Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptStkMovement
    Private Sub rptStkMovement_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
        GroupBox1.Enabled = False
    End Sub
    Public Property StkMovementFrom() As String
        Get
            Return txtStkMovementFrom.Text
        End Get
        Set(ByVal Value As String)
            txtStkMovementFrom.Text = Value
        End Set
    End Property
    Public Property StkMovementTo() As String
        Get
            Return txtStkMovementTo.Text
        End Get
        Set(ByVal Value As String)
            txtStkMovementTo.Text = Value
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
        txtStkCodeFrom.Text = ""
        txtStkCodeTo.Text = ""
        txtStkMovementFrom.Text = ""
        txtStkMovementTo.Text = ""
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnStkMovementFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStkMovementFrom.Click
        fdlStkMovementFrom.Show()
    End Sub

    Private Sub btnStkMovementTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStkMovementTo.Click
        fdlStkMovementTo.Show()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom1 As String
        Dim dateTo1 As String
        Dim StkMovementFrom1 As String
        Dim StkMovementTo1 As String
        Dim stkCodeFrom1 As String
        Dim stkCodeTo1 As String

        If rbAll.Checked = True Then
            dateFrom1 = ""
            dateTo1 = ""
            StkMovementFrom1 = ""
            StkMovementTo1 = ""
            stkCodeFrom1 = ""
            stkCodeTo1 = ""
        Else
            dtpFrom.Format = DateTimePickerFormat.Custom
            dtpFrom.CustomFormat = "yyyy/MM/dd"
            dtpTo.Format = DateTimePickerFormat.Custom
            dtpTo.CustomFormat = "yyyy/MM/dd"
            dateFrom1 = dtpFrom.Text
            dateTo1 = dtpTo.Text
            If txtStkMovementFrom.Text <> "" And txtStkMovementTo.Text <> "" Then
                StkMovementFrom1 = txtStkMovementFrom.Text
                StkMovementTo1 = txtStkMovementTo.Text
                If txtStkMovementFrom.Text = "" And txtStkMovementTo.Text <> "" Then
                    StkMovementFrom1 = txtStkMovementTo.Text
                    StkMovementTo1 = txtStkMovementTo.Text
                ElseIf txtStkMovementFrom.Text <> "" And txtStkMovementTo.Text = "" Then
                    StkMovementFrom1 = txtStkMovementFrom.Text
                    StkMovementTo1 = txtStkMovementFrom.Text
                End If
            Else
                StkMovementFrom1 = ""
                StkMovementTo1 = ""
            End If
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
        End If

        strSQL = "exec RPT_Stk_Movement_Report '" & dateFrom1 & "' , '" & dateTo1 & "', '" & StkMovementFrom1 & "', '" & StkMovementTo1 & "', '" & stkCodeFrom1 & "', '" & stkCodeTo1 & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "StkMovementRpt_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Stk_Movement_Report.rpt"

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
        NewMDIChild.Text = "Stock Movement Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("StkMovementRpt_"))
        
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
        Dim filterstkmovementno As String
        Dim filterstkcode As String
        If rbAll.Checked = True Then
            filterdate = "Transaction Date : All"
            filterstkmovementno = "Stock Movement No. : All"
            filterstkcode = "Stock Code : All"
        Else
            filterdate = "Transaction Date : " & dtpFrom.Text & " - " & dtpTo.Text
            If txtStkMovementFrom.Text = "" And txtStkMovementTo.Text = "" Then
                filterstkmovementno = "Stock Movement No. : All"
            Else
                filterstkmovementno = "Stock Movement No. : " & txtStkMovementFrom.Text & " - " & txtStkMovementTo.Text
            End If
            If txtStkCodeFrom.Text = "" And txtStkCodeTo.Text = "" Then
                filterstkcode = "Stock Code : All"
            Else
                filterstkcode = "Stock Code : " & txtStkCodeFrom.Text & " - " & txtStkCodeTo.Text
            End If

        End If
        Dim filter As String = filterdate + vbCrLf + filterstkmovementno + vbCrLf + filterstkcode

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

    Private Sub txtStkCodeFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStkCodeFrom.TextChanged

    End Sub
End Class