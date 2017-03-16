Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptSlsTransaction
    Public Property OrderFrom() As String
        Get
            Return txtOrder.Text
        End Get
        Set(ByVal Value As String)
            txtOrder.Text = Value
        End Set
    End Property
    Public Property IncomingFrom() As String
        Get
            Return txtDelivery.Text
        End Get
        Set(ByVal Value As String)
            txtDelivery.Text = Value
        End Set
    End Property
    Public Property InvoiceFrom() As String
        Get
            Return txtInvoice.Text
        End Get
        Set(ByVal Value As String)
            txtInvoice.Text = Value
        End Set
    End Property
    Public Property PaymentFrom() As String
        Get
            Return txtReceipt.Text
        End Get
        Set(ByVal Value As String)
            txtReceipt.Text = Value
        End Set
    End Property

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

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtOrder.Text = ""
        txtDelivery.Text = ""
        txtInvoice.Text = ""
        txtReceipt.Text = ""
        txtCCodeFrom.Text = ""
        txtCCodeTo.Text = ""
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrder.Click
        Dim NewFormDialog As New fdlSOrderFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnIncoming_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncoming.Click
        Dim NewFormDialog As New fdlSDeliveryFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvoice.Click
        Dim NewFormDialog As New fdlSInvoiceFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayment.Click
        Dim NewFormDialog As New fdlSReceiptFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim OrderNo As String = txtOrder.Text
        Dim IncomingNo As String = txtDelivery.Text
        Dim InvoiceNo As String = txtInvoice.Text
        Dim PaymentNo As String = txtReceipt.Text

        strSQL = "exec RPT_Sls_Transaction_Report '" & OrderNo & "', '" & IncomingNo & "', '" & InvoiceNo & "', '" & PaymentNo & "', '" & CCodeFrom & "', '" & CCodeTo & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "STransactionRpt_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_Transaction_Report.rpt"

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
        NewMDIChild.Text = "Sales Transaction Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("STransactionRpt_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
        '-----------------MENAMBAH PARAMETER FILTER KE CR--------------------------
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterOrderNo As String
        Dim filterIncomingNo As String
        Dim filterInvoiceNo As String
        Dim filterPaymentNo As String
        Dim filterCCode As String

        If txtOrder.Text <> "" Then
            filterOrderNo = "Sales Order No : " & txtOrder.Text
        Else
            filterOrderNo = "Sales Order No : -"
        End If

        If txtDelivery.Text <> "" Then
            filterIncomingNo = "Sales Delivery No : " & txtDelivery.Text
        Else
            filterIncomingNo = "Sales Delivery No : -"
        End If

        If txtInvoice.Text <> "" Then
            filterInvoiceNo = "Sales Invoice No : " & txtInvoice.Text
        Else
            filterInvoiceNo = "Sales Invoice No : -"
        End If

        If txtReceipt.Text <> "" Then
            filterPaymentNo = "Sales Receipt No : " & txtReceipt.Text
        Else
            filterPaymentNo = "Sales Receipt No : -"
        End If

        If txtCCodeFrom.Text <> "" And txtCCodeTo.Text <> "" Then
            filterCCode = "Customer Code : " & txtCCodeFrom.Text & " to " & txtCCodeTo.Text
        ElseIf txtCCodeFrom.Text <> "" Then
            filterCCode = "Customer Code : " & txtCCodeFrom.Text
        ElseIf txtCCodeTo.Text <> "" Then
            filterCCode = "Customer Code : " & txtCCodeTo.Text
        Else
            filterCCode = "Customer Code : All"
        End If

        Dim filter As String = filterCCode + vbCrLf + filterOrderNo + vbCrLf + filterIncomingNo + vbCrLf + filterInvoiceNo + vbCrLf + filterPaymentNo

        crParameterDiscreteValue.Value = filter
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filter")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
    End Sub

    Private Sub btnCustCodeFrom_Click(sender As System.Object, e As System.EventArgs) Handles btnCustCodeFrom.Click
        Dim NewFormDialog As New fdlCustomerFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnCustCodeTo_Click(sender As System.Object, e As System.EventArgs) Handles btnCustCodeTo.Click
        Dim NewFormDialog As New fdlCustomerTo
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub rptSlsTransaction_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class