Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptSupplierList
    Private Sub btnSupplierFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierFrom.Click
        Dim NewFormDialog As New fdlSupplierFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSupplierTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierTo.Click
        Dim NewFormDialog As New fdlSupplierTo
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim sCodeFrom As String
        Dim sCodeTo As String

        If txtSCodeFrom.Text = "" And txtSCodeTo.Text = "" Then
            sCodeFrom = ""
            sCodeTo = ""
            If txtSCodeFrom.Text = "" And txtSCodeTo.Text <> "" Then
                sCodeFrom = txtSCodeTo.Text
                sCodeTo = txtSCodeTo.Text
            ElseIf txtSCodeTo.Text = "" And txtSCodeFrom.Text <> "" Then
                sCodeFrom = txtSCodeFrom.Text
                sCodeTo = txtSCodeFrom.Text
            End If
        Else
            sCodeFrom = txtSCodeFrom.Text
            sCodeTo = txtSCodeTo.Text
        End If

        strSQL = "exec RPT_Sup_List_Rpt '" & sCodeFrom & "' , '" & sCodeTo & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SupList_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sup_List_Rpt.rpt"

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
        NewMDIChild.Text = "Supplier List"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("SupList_"))

        '-----------------MENAMBAH PARAMETER PCH--------------------------
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterscode As String

        
        If txtSCodeFrom.Text = "" And txtSCodeTo.Text = "" Then
            filterscode = "Supplier : All"
        Else
            filterscode = "Supplier : " + txtSCodeFrom.Text + " - " + txtSCodeTo.Text
        End If


        crParameterDiscreteValue.Value = filterscode
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filterscode")
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
        txtSCodeFrom.Text = ""
        txtSCodeTo.Text = ""
    End Sub
End Class