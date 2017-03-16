Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptSlsMonthlyStatement

    Private Sub rptSlsMonthlyStatement_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
    End Sub
    Public Property CustCodeFrom() As String
        Get
            Return txtCustCodeFrom.Text
        End Get
        Set(ByVal Value As String)
            txtCustCodeFrom.Text = Value
        End Set
    End Property
    Public Property CustCodeTo() As String
        Get
            Return txtCustCodeTo.Text()
        End Get
        Set(ByVal Value As String)
            txtCustCodeTo.Text() = Value
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
        Dim dateTo As String
        Dim CustCodeFrom1 As String
        Dim CustCodeTo1 As String
        Dim CurrCode1 As String

        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "yyyy/MM/dd"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "yyyy/MM/dd"

        dateFrom = dtpFrom.Text
        dateTo = dtpTo.Text

        If txtCustCodeFrom.Text <> "" And txtCustCodeTo.Text <> "" Then
            CustCodeFrom1 = txtCustCodeFrom.Text
            CustCodeTo1 = txtCustCodeTo.Text
            If txtCustCodeFrom.Text = "" And txtCustCodeTo.Text <> "" Then
                CustCodeFrom1 = txtCustCodeTo.Text
                CustCodeTo1 = txtCustCodeTo.Text
            ElseIf txtCustCodeFrom.Text <> "" And txtCustCodeTo.Text = "" Then
                CustCodeFrom1 = txtCustCodeFrom.Text
                CustCodeTo1 = txtCustCodeFrom.Text
            End If
        Else
            CustCodeFrom1 = ""
            CustCodeTo1 = ""
        End If

        If txtCurrCode.Text <> "" Then
            CurrCode1 = txtCurrCode.Text
        Else
            CurrCode1 = ""
        End If

        strSQL = "exec RPT_Sls_Monthly_Statement '" & dateFrom & "' , '" & dateTo & "', '" & CustCodeFrom1 & "', '" & CustCodeTo1 & "', '" & CurrCode1 & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "Sls_Monthly_Report_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_MonthlyDeliveryStatement_Report.rpt"

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
        NewMDIChild.Text = "Sales Monthly Statement Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("Sls_Monthly_Report_"))

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
        Dim filtercustcode As String
        Dim filtercurrcode As String

        filterdate = "Transaction Date : " & dtpFrom.Text & "-" & dtpTo.Text

        If txtCustCodeFrom.Text = "" And txtCustCodeTo.Text = "" Then
            filtercustcode = "Customer Code : All"
        Else
            filtercustcode = "Customer Code : " & txtCustCodeFrom.Text & "-" & txtCustCodeTo.Text
        End If

        If txtCurrCode.Text = "" Then
            filtercurrcode = "Currency Code : All"
        Else
            filtercurrcode = "Currency Code : " & txtCurrCode.Text
        End If

        Dim filter As String = filterdate + vbCrLf + filtercustcode + vbCrLf + filtercurrcode
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
        txtCustCodeFrom.Text = ""
        txtCustCodeTo.Text = ""
        txtCurrCode.Text = ""
    End Sub

    Private Sub btnPchCodeFrom_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankCodeFrom.Click
        Dim NewFormDialog As New fdlCustomerFrom
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPchCodeTo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankCodeTo.Click
        Dim NewFormDialog As New fdlCustomerFrom
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnCurr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCurr.Click
        Dim NewFormDialog As New fdlCurrency
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub
End Class