Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptBankList
    Private Sub btnSupplierFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankFrom.Click
        Dim NewFormDialog As New fdlBank
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSupplierTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankTo.Click
        Dim NewFormDialog As New fdlBank
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
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
            Return txtBankCodeTo.Text
        End Get
        Set(ByVal Value As String)
            txtBankCodeTo.Text = Value
        End Set
    End Property

    Public Property CurrCode() As String
        Get
            Return txtCurrency.Text
        End Get
        Set(ByVal Value As String)
            txtCurrency.Text = Value
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim BankCodeFrom1 As String
        Dim BankCodeTo1 As String
        Dim CurrCode1 As String

        If txtBankCodeFrom.Text = "" And txtBankCodeTo.Text = "" Then
            BankCodeFrom1 = ""
            BankCodeTo1 = ""
            If txtBankCodeFrom.Text = "" And txtBankCodeTo.Text <> "" Then
                BankCodeFrom1 = txtBankCodeTo.Text
                BankCodeTo1 = txtBankCodeTo.Text
            ElseIf txtBankCodeTo.Text = "" And txtBankCodeFrom.Text <> "" Then
                BankCodeFrom1 = txtBankCodeFrom.Text
                BankCodeTo1 = txtBankCodeFrom.Text
            End If
        Else
            BankCodeFrom1 = txtBankCodeFrom.Text
            BankCodeTo1 = txtBankCodeTo.Text
        End If

        If txtCurrency.Text = "" Then
            CurrCode1 = ""
        Else
            CurrCode1 = txtCurrency.Text
        End If

        strSQL = "exec RPT_Bank_List_Report '" & BankCodeFrom1 & "' , '" & BankCodeTo1 & "', '" & CurrCode1 & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "BankList_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Bank_List_Report.rpt"

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
        NewMDIChild.Text = "Bank List"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("BankList_"))

        '-----------------MENAMBAH PARAMETER PCH--------------------------
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterscode As String
        Dim filtersbank As String
        Dim filterscurr As String

        If txtBankCodeFrom.Text = "" And txtBankCodeTo.Text = "" Then
            filtersbank = "Bank Code : All"
        Else
            filtersbank = "Bank Code : " + txtBankCodeFrom.Text + " - " + txtBankCodeTo.Text
        End If

        If txtCurrency.Text = "" Then
            filterscurr = "Currency Code : All"
        Else
            filterscurr = "Currency Code :" + txtCurrency.Text
        End If

        filterscode = filtersbank + vbCrLf + filterscurr

        crParameterDiscreteValue.Value = filterscode
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filterscode")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
        '----------------------------------------------------------------------------------------

        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtBankCodeFrom.Text = ""
        txtBankCodeTo.Text = ""
        txtCurrency.Text = ""
    End Sub

    Private Sub btnCurrency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCurrency.Click
        Dim NewFormDialog As New fdlCurrency
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub
End Class