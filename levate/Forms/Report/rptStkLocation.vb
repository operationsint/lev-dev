Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptStkLocation
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
    Public Property LocationCode() As String
        Get
            Return txtLocation.Text
        End Get
        Set(ByVal Value As String)
            txtLocation.Text = Value
        End Set
    End Property
    Public Property stkCat() As String
        Get
            Return txtStkCat.Text
        End Get
        Set(ByVal Value As String)
            txtStkCat.Text = Value
        End Set
    End Property
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim stkCodeFrom As String
        Dim stkCodeTo As String
        Dim locationCode As String
        Dim stkCategory As String

        If txtStkCodeFrom.Text = "" And txtStkCodeTo.Text = "" Then
            stkCodeFrom = ""
            stkCodeTo = ""
            If txtStkCodeFrom.Text = "" And txtStkCodeTo.Text <> "" Then
                stkCodeFrom = txtStkCodeTo.Text
                stkCodeTo = txtStkCodeTo.Text
            ElseIf txtStkCodeTo.Text = "" And txtStkCodeFrom.Text <> "" Then
                stkCodeFrom = txtStkCodeFrom.Text
                stkCodeTo = txtStkCodeFrom.Text
            End If
        Else
            stkCodeFrom = txtStkCodeFrom.Text
            stkCodeTo = txtStkCodeTo.Text
        End If

        If txtLocation.Text <> "" Then
            locationCode = txtLocation.Text
        Else
            locationCode = ""
        End If

        If txtStkCat.Text <> "" Then
            stkCategory = txtStkCat.Text
        Else
            stkCategory = ""
        End If

        strSQL = "exec RPT_Stk_Location_Report '" & stkCodeFrom & "' , '" & stkCodeTo & "', '" & locationCode & "', '" & stkCategory & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "StkLocation_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Stk_Location_Report.rpt"

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
        NewMDIChild.Text = "Stock Location"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("StkLocation_"))

        '-----------------MENAMBAH PARAMETER PCH--------------------------
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filter As String
        Dim filterscode As String
        Dim filterlocation As String
        Dim filterstkcat As String

        If txtStkCodeFrom.Text = "" And txtStkCodeTo.Text = "" Then
            filterscode = "Stock Code : All"
        Else
            filterscode = "Stock Code : " + txtStkCodeFrom.Text + " - " + txtStkCodeTo.Text
        End If

        If txtLocation.Text = "" Then
            filterlocation = "Location Code : All"
        Else
            filterlocation = "Location Code : " + txtLocation.Text
        End If

        If txtStkCat.Text = "" Then
            filterstkcat = "Stock Category : All"
        Else
            filterstkcat = "Stock Category : " + txtStkCat.Text
        End If

        filter = filterscode + vbCrLf + filterlocation + vbCrLf + filterstkcat

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtStkCodeFrom.Text = ""
        txtStkCodeTo.Text = ""
        txtLocation.Text = ""
        txtStkCat.Text = ""
    End Sub

    Private Sub btnStkFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStkFrom.Click
        Dim NewFormDialog As New fdlSKUFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnStkTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStkTo.Click
        Dim NewFormDialog As New fdlSKUTo
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnStkCat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStkCat.Click
        Dim NewFormDialog As New fdlSKUCat
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocation.Click
        Dim NewFormDialog As New fdlLocation
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub
End Class