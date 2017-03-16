Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptBankTransaction

    Private Sub rptBankTransaction_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"

        cbStatus.Items.Insert(0, "ALL")
        cbStatus.Items.Insert(1, "OUT")
        cbStatus.Items.Insert(2, "IN")
        cbStatus.SelectedIndex = 0
    End Sub

    Public Property BankCodeFrom() As String
        Get
            Return txtBankCodeFrom.Text
        End Get
        Set(ByVal Value As String)
            txtBankCodeFrom.Text = Value
        End Set
    End Property
    Public Property BankCodeTo() As String
        Get
            Return txtBankCodeTo.Text()
        End Get
        Set(ByVal Value As String)
            txtBankCodeTo.Text() = Value
        End Set
    End Property
    
    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom As String
        Dim dateTo As String
        Dim BankCodeFrom1 As String
        Dim BankCodeTo1 As String
        Dim Status As String

        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "yyyy/MM/dd"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "yyyy/MM/dd"
        dateFrom = dtpFrom.Text
        dateTo = dtpTo.Text
            
        If txtBankCodeFrom.Text <> "" And txtBankCodeTo.Text <> "" Then
            BankCodeFrom1 = txtBankCodeFrom.Text
            BankCodeTo1 = txtBankCodeTo.Text
            If txtBankCodeFrom.Text = "" And txtBankCodeTo.Text <> "" Then
                BankCodeFrom1 = txtBankCodeTo.Text
                BankCodeTo1 = txtBankCodeTo.Text
            ElseIf txtBankCodeFrom.Text <> "" And txtBankCodeTo.Text = "" Then
                BankCodeFrom1 = txtBankCodeFrom.Text
                BankCodeTo1 = txtBankCodeFrom.Text
            End If
        Else
            BankCodeFrom1 = ""
            BankCodeTo1 = ""
        End If

        If cbStatus.SelectedIndex = 1 Then
            Status = "OUT"
        ElseIf cbStatus.SelectedIndex = 2 Then
            Status = "IN"
        Else
            Status = ""
        End If
        

        strSQL = "exec RPT_Bank_Transaction_Report '" & dateFrom & "' , '" & dateTo & "', '" & BankCodeFrom1 & "', '" & BankCodeTo1 & "', '" & Status & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "Bank_Transaction_Report_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Bank_Transaction_Report.rpt"

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
        NewMDIChild.Text = "Bank Transaction Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("Bank_Transaction_Report_"))

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
        Dim filterbank As String
        Dim filterstatus As String

        filterdate = "Transaction Date : " & dtpFrom.Text & "-" & dtpTo.Text
        If txtBankCodeFrom.Text = "" And txtBankCodeTo.Text = "" Then
            filterbank = "Bank Code : All"
        Else
            filterbank = "Bank Code : " & txtBankCodeFrom.Text & "-" & txtBankCodeTo.Text
        End If

        If cbStatus.SelectedIndex = 0 Then
            filterstatus = "Type : All"
        Else
            filterstatus = "Type : " & cbStatus.SelectedItem
        End If


        Dim filter As String = filterdate + vbCrLf + filterbank + vbCrLf + filterstatus
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
        txtBankCodeFrom.Text = ""
        txtBankCodeTo.Text = ""
        cbStatus.SelectedIndex = 0
    End Sub

    Private Sub btnPchCodeFrom_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankCodeFrom.Click
        Dim NewFormDialog As New fdlBank
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPchCodeTo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankCodeTo.Click
        Dim NewFormDialog As New fdlBank
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub

End Class