Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptPTransaction
    Public Property RequestFrom() As String
        Get
            Return txtRequest.Text
        End Get
        Set(ByVal Value As String)
            txtRequest.Text = Value
        End Set
    End Property
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
            Return txtIncoming.Text
        End Get
        Set(ByVal Value As String)
            txtIncoming.Text = Value
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
            Return txtPayment.Text
        End Get
        Set(ByVal Value As String)
            txtPayment.Text = Value
        End Set
    End Property

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtRequest.Text = ""
        txtOrder.Text = ""
        txtIncoming.Text = ""
        txtInvoice.Text = ""
        txtPayment.Text = ""
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequest.Click
        Dim NewFormDialog As New fdlPRequestFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrder.Click
        Dim NewFormDialog As New fdlPOFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnIncoming_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncoming.Click
        Dim NewFormDialog As New fdlPIncomingFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvoice.Click
        Dim NewFormDialog As New fdlPInvoiceFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayment.Click
        Dim NewFormDialog As New fdlPPaymentFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim RequestNo As String = txtRequest.Text
        Dim OrderNo As String = txtOrder.Text
        Dim IncomingNo As String = txtIncoming.Text
        Dim InvoiceNo As String = txtInvoice.Text
        Dim PaymentNo As String = txtPayment.Text

        strSQL = "exec RPT_Pch_Transaction_Report '" & RequestNo & "' , '" & OrderNo & "', '" & IncomingNo & "', '" & InvoiceNo & "', '" & PaymentNo & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "PTransactionRpt_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Pch_Transaction_Report.rpt"

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
        NewMDIChild.Text = "Purchase Transaction Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("PTransactionRpt_"))
        
        '-----------------MENAMBAH PARAMETER FILTER KE CR--------------------------
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterRequestNo As String
        Dim filterOrderNo As String
        Dim filterIncomingNo As String
        Dim filterInvoiceNo As String
        Dim filterPaymentNo As String

        If txtRequest.Text <> "" Then
            filterRequestNo = "Purchase Request No : " & txtRequest.Text
        Else
            filterRequestNo = "Purchase Request No : -"
        End If

        If txtOrder.Text <> "" Then
            filterOrderNo = "Purchase Order No : " & txtOrder.Text
        Else
            filterOrderNo = "Purchase Order No : -"
        End If

        If txtIncoming.Text <> "" Then
            filterIncomingNo = "Purchase Incoming No : " & txtIncoming.Text
        Else
            filterIncomingNo = "Purchase Incoming No : -"
        End If

        If txtInvoice.Text <> "" Then
            filterInvoiceNo = "Purchase Invoice No : " & txtInvoice.Text
        Else
            filterInvoiceNo = "Purchase Invoice No : -"
        End If

        If txtPayment.Text <> "" Then
            filterPaymentNo = "Purchase Payment No : " & txtPayment.Text
        Else
            filterPaymentNo = "Purchase Payment No : -"
        End If

        Dim filter As String = filterRequestNo + vbCrLf + filterOrderNo + vbCrLf + filterIncomingNo + vbCrLf + filterInvoiceNo + vbCrLf + filterPaymentNo

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