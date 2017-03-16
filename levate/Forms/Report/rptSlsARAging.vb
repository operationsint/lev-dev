Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptSlsARAging
    Dim m_SlsCodeIdFrom As Integer
    Dim m_SlsCodeIdTo As Integer

    Private Sub rptSlsARAging_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
    End Sub

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

    Public Property CurrCode() As String
        Get
            Return txtCurrCode.Text()
        End Get
        Set(ByVal Value As String)
            txtCurrCode.Text() = Value
        End Set
    End Property

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom As String
        Dim currCode As String
        Dim CustCodeFrom As String
        Dim CustCodeTo As String


        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "yyyy/MM/dd"
        dateFrom = dtpFrom.Text

        If txtCCodeFrom.Text <> "" And txtCCodeTo.Text <> "" Then
            CustCodeFrom = txtCCodeFrom.Text
            CustCodeTo = txtCCodeTo.Text
            If txtCCodeFrom.Text = "" And txtCCodeTo.Text <> "" Then
                CustCodeFrom = txtCCodeTo.Text
                CustCodeTo = txtCCodeTo.Text
            ElseIf txtCCodeFrom.Text <> "" And txtCCodeTo.Text = "" Then
                CustCodeFrom = txtCCodeFrom.Text
                CustCodeTo = txtCCodeFrom.Text
            End If
        Else
            CustCodeFrom = ""
            CustCodeTo = ""
        End If

        If txtCurrCode.Text = "" Then
            currCode = ""
        Else
            currCode = txtCurrCode.Text
        End If

        strSQL = "RPT_Sls_ARAging_Report '" & dateFrom & "' , '" & CustCodeFrom & "', '" & CustCodeTo & "', '" & currCode & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "ARAgingReport_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_ARAging_Report.rpt"

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
        NewMDIChild.Text = "AR Aging Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("ARAgingReport_"))

        '-----------------MENAMBAH PARAMETER FILTER DATE--------------------------
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"

        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterdate As String
        Dim filtercurr As String
        Dim filtercustomer As String

        filterdate = "Date : " & dtpFrom.Text

        If txtCCodeFrom.Text = "" And txtCCodeTo.Text = "" Then
            filtercustomer = "Customer Code : All"
        Else
            filtercustomer = "Customer Code : " & txtCCodeFrom.Text & "-" & txtCCodeTo.Text
        End If

        If txtCurrCode.Text = "" Then
            filtercurr = "Currency Code : All"
        Else
            filtercurr = "Currency Code : " & txtCurrCode.Text
        End If

        Dim filter As String = filterdate + vbCrLf + filtercustomer + vbCrLf + filtercurr
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
        txtCurrCode.Text = ""
        txtCCodeFrom.Text = ""
        txtCCodeTo.Text = ""
    End Sub

    Private Sub btnCurrency_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCurrency.Click
        Dim NewFormDialog As New fdlCurrency
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnCustFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustFrom.Click
        Dim NewFormDialog As New fdlCustomerFrom
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnCustTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustTo.Click
        Dim NewFormDialog As New fdlCustomerFrom
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub
End Class