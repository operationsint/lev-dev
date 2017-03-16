Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptCustomerList
    Public Property CCodeFrom() As String
        Get
            Return txtCCodeFrom.Text
        End Get
        Set(ByVal Value As String)
            txtCCodeFrom.Text = Value
        End Set
    End Property
    Public Property CCodeTo() As String
        Get
            Return txtCCodeTo.Text
        End Get
        Set(ByVal Value As String)
            txtCCodeTo.Text = Value
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim cCodeFrom As String
        Dim cCodeTo As String

        If txtCCodeFrom.Text = "" And txtCCodeTo.Text = "" Then
            cCodeFrom = ""
            cCodeTo = ""
            If txtCCodeFrom.Text = "" And txtCCodeTo.Text <> "" Then
                cCodeFrom = txtCCodeTo.Text
                cCodeTo = txtCCodeTo.Text
            ElseIf txtCCodeTo.Text = "" And txtCCodeFrom.Text <> "" Then
                cCodeFrom = txtCCodeFrom.Text
                cCodeTo = txtCCodeFrom.Text
            End If
        Else
            cCodeFrom = txtCCodeFrom.Text
            cCodeTo = txtCCodeTo.Text
        End If

        strSQL = "exec RPT_Customer_List_Rpt '" & cCodeFrom & "' , '" & cCodeTo & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "CustList_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Customer_List_Rpt.rpt"

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
        NewMDIChild.Text = "Customer List"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("CustList_"))
        

        '-----------------MENAMBAH PARAMETER PCH--------------------------
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterscode As String


        If txtCCodeFrom.Text = "" And txtCCodeTo.Text = "" Then
            filterscode = "Supplier : All"
        Else
            filterscode = "Supplier : " + txtCCodeFrom.Text + " - " + txtCCodeTo.Text
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
        txtCCodeFrom.Text = ""
        txtCCodeTo.Text = ""
    End Sub

    Private Sub btnCustFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustFrom.Click
        Dim NewFormDialog As New fdlCustomerFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnCustTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustTo.Click
        Dim NewFormDialog As New fdlCustomerTo
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub
End Class