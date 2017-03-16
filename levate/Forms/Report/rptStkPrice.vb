Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptStkPrice
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
    Public Property StkCategory() As String
        Get
            Return txtCategory.Text
        End Get
        Set(ByVal Value As String)
            txtCategory.Text = Value
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
        Dim stkCat As String

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
        If txtCategory.Text <> "" Then
            stkCat = txtCategory.Text
        Else
            stkCat = ""
        End If

        strSQL = "exec RPT_Stk_List_Report '" & stkCodeFrom & "' , '" & stkCodeTo & "', '" & stkCat & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "StkPrice_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Stk_Price_Report.rpt"

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
        NewMDIChild.Text = "Stock Price"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("StkPrice_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With

        '-----------------MENAMBAH PARAMETER PCH--------------------------
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterscode As String
        Dim filtersku As String
        Dim filtercat As String

        If txtStkCodeFrom.Text = "" And txtStkCodeTo.Text = "" Then
            filtersku = "Stock Code : All"
        Else
            filtersku = "Stock Code : " + txtStkCodeFrom.Text + " - " + txtStkCodeTo.Text
        End If

        If txtCategory.Text = "" Then
            filtercat = "Stock Category : All"
        Else
            filtercat = txtCategory.Text
        End If

        filterscode = filtersku + vbCrLf + filtercat


        crParameterDiscreteValue.Value = filterscode
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filterscode")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtStkCodeFrom.Text = ""
        txtStkCodeTo.Text = ""
        txtCategory.Text = ""
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

    Private Sub btnCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCategory.Click
        Dim NewFormDialog As New fdlSKUCat
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub
End Class