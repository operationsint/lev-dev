Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptStkControl

    Private Sub rptStkControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "MM/yyyy"
    End Sub

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

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom As String
        Dim StockCodeFrom1 As String
        Dim StockCodeTo1 As String
        Dim StockCat1 As String

        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "yyyy/MM"
        dateFrom = dtpFrom.Text + "/1"

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

        'cbUnitCostPerToday
        Dim iUnitCostPerToday As Integer

        If cbUnitCostPerToday.Checked = True Then
            iUnitCostPerToday = 1
        Else
            iUnitCostPerToday = 0
        End If


        strSQL = "exec RPT_Stk_Control_Report '" & dateFrom & "' , '" & StockCodeFrom1 & "', " & _
                                                "'" & StockCodeTo1 & "', '" & StockCat1 & "', " & _
                                                "" & iUnitCostPerToday & ""

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "Stock_Control_Report_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Stk_Control_Report.rpt"

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
        NewMDIChild.Text = "Stock Control Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("Stock_Control_Report_"))

        '-----------------MENAMBAH PARAMETER FILTER DATE--------------------------
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "MM/yyyy"
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterdate As String
        Dim filterstockcode As String
        Dim filterstockcat As String
        Dim filtercostpertoday As String

        filterdate = "Period : " & dtpFrom.Text
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

        If cbUnitCostPerToday.Checked = True Then
            filtercostpertoday = "Unit Cost as Per Today"
        Else
            filtercostpertoday = "Unit Cost as Per Period"
        End If



        Dim filter As String = filterdate + vbCrLf + filterstockcode + vbCrLf + filterstockcat + vbCrLf + filtercostpertoday
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
        txtStockCodeFrom.Text = ""
        txtStockCodeTo.Text = ""
        txtStockCategory.Text = ""
    End Sub

    Private Sub btnPchCodeFrom_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankCodeFrom.Click
        Dim NewFormDialog As New fdlSKUFrom
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPchCodeTo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankCodeTo.Click
        Dim NewFormDialog As New fdlSKUFrom
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnStockCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStockCategory.Click
        Dim NewFormDialog As New fdlSKUCat
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    
End Class