Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class rptSlsStockSales

    Public Property StockCodeFrom() As String
        Get
            Return txtStockCodeFrom.Text
        End Get
        Set(ByVal Value As String)
            txtStockCodeFrom.Text = Value
        End Set
    End Property
    Public Property StockCodeTo() As String
        Get
            Return txtStockCodeTo.Text()
        End Get
        Set(ByVal Value As String)
            txtStockCodeTo.Text() = Value
        End Set
    End Property

    Public Property StockCat() As String
        Get
            Return txtStockCategory.Text()
        End Get
        Set(ByVal Value As String)
            txtStockCategory.Text() = Value
        End Set
    End Property


    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        txtStockCodeFrom.Text = ""
        txtStockCodeTo.Text = ""
        txtStockCategory.Text = ""

    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub btnBankCodeFrom_Click(sender As System.Object, e As System.EventArgs) Handles btnBankCodeFrom.Click
        Dim NewFormDialog As New fdlSKUFrom
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()

    End Sub

    Private Sub btnBankCodeTo_Click(sender As System.Object, e As System.EventArgs) Handles btnBankCodeTo.Click
        Dim NewFormDialog As New fdlSKUFrom
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnStockCategory_Click(sender As System.Object, e As System.EventArgs) Handles btnStockCategory.Click
        Dim NewFormDialog As New fdlSKUCat
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()

    End Sub

    Private Sub rptSlsStockSales_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpFrom.Value = Date.Today
        dtpTo.Value = Date.Today
    End Sub

    Private Sub chkEnabledDtp_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkEnabledDtp.CheckedChanged
        If chkEnabledDtp.Checked Then
            dtpFrom.Enabled = True
            dtpTo.Enabled = True
        Else
            dtpFrom.Enabled = False
            dtpTo.Enabled = False
        End If
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click

        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom As String
        Dim dateTo As String
        Dim StockCodeFrom1 As String
        Dim StockCodeTo1 As String
        Dim StockCat1 As String

        If txtStockCodeFrom.Text <> "" And txtStockCodeTo.Text <> "" Then
            StockCodeFrom1 = txtStockCodeFrom.Text
            StockCodeTo1 = txtStockCodeTo.Text
            If txtStockCodeFrom.Text = "" And txtStockCodeTo.Text <> "" Then
                StockCodeFrom1 = txtStockCodeTo.Text
                StockCodeTo1 = txtStockCodeTo.Text
            ElseIf txtStockCodeFrom.Text <> "" And txtStockCodeTo.Text = "" Then
                StockCodeFrom1 = txtStockCodeFrom.Text
                StockCodeTo1 = txtStockCodeFrom.Text
            End If
        Else
            StockCodeFrom1 = ""
            StockCodeTo1 = ""
        End If

        If txtStockCategory.Text = "" Then
            StockCat1 = ""
        Else
            StockCat1 = txtStockCategory.Text
        End If

        dateFrom = ""
        dateTo = ""

        If chkEnabledDtp.Checked Then
            dateFrom = dtpFrom.Value.ToString("yyyy-MM-dd")
            dateTo = dtpTo.Value.ToString("yyyy-MM-dd")
        End If

        strSQL = "exec dbo.RPT_Sls_StockSales_Report '" & dateFrom & "' , '" & dateTo & "' , '" & StockCodeFrom1 & "', '" & StockCodeTo1 & "', '" & StockCat1 & "', '" & StockCat1 & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "Stock_Sales_Report_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_StockSales_Report.rpt"

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
        NewMDIChild.Text = "Stock Sales Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("Stock_Sales_Report_"))

        '-----------------MENAMBAH PARAMETER FILTER DATE--------------------------
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterdate As String
        Dim filterstockcode As String
        Dim filterstockcat As String

        filterdate = "Period : All"
        If chkEnabledDtp.Checked Then
            filterdate = "Period : " & dtpFrom.Text & " - " & dtpTo.Text
        End If

        If txtStockCodeFrom.Text = "" And txtStockCodeTo.Text = "" Then
            filterstockcode = "Stock Code : All"
        Else
            filterstockcode = "Stock Code : " & txtStockCodeFrom.Text & "-" & txtStockCodeTo.Text
        End If

        If txtStockCategory.Text = "" Then
            filterstockcat = "Stock Category : All"
        Else
            filterstockcat = "Stock Category : " & txtStockCategory.Text
        End If


        Dim filter As String = filterdate + vbCrLf + filterstockcode + vbCrLf + filterstockcat
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