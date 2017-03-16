Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptSlsCustomerBalanceReport
    Private Sub rptSlsCustomerBalanceReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpFrom.Value = DateSerial(Year(Now()), 1, 1)

        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
        dtpFrom.Value = Now()

        cbStatus.Items.Insert(0, "All")
        cbStatus.Items.Insert(1, "Unpaid")
        cbStatus.Items.Insert(2, "Fully Paid")
        cbStatus.SelectedIndex = 0


        pLoadComboMonth()

        '----------------------------------------------------'
        'Default Year
        Dim iDefaultYear As Integer
        iDefaultYear = Year(Now())
        iYear.Text = iDefaultYear
        '----------------------------------------------------'

    End Sub
    Public Property SNoFrom() As String
        Get
            Return txtSNoFrom.Text
        End Get
        Set(ByVal Value As String)
            txtSNoFrom.Text = Value
        End Set
    End Property
    Public Property SNoTo() As String
        Get
            Return txtSNoTo.Text
        End Get
        Set(ByVal Value As String)
            txtSNoTo.Text = Value
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


    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom1 As Date
        Dim dateTo1 As Date
        Dim SNoFrom1 As String
        Dim SNoTo1 As String
        Dim CCodeFrom1 As String
        Dim CCodeTo1 As String
        Dim Status As String


        dateFrom1 = dtpFrom.Value
        dateTo1 = dtpTo.Value
        SNoFrom1 = txtSNoFrom.Text
        SNoTo1 = txtSNoTo.Text
        CCodeFrom1 = txtCCodeFrom.Text
        CCodeTo1 = txtCCodeTo.Text


        '---- Year and Month
        If Trim(iYear.Text) = "" Then
            MsgBox("Please input year!")
            Exit Sub
        End If

        If IsNumeric(Trim(iYear.Text)) = False Then
            MsgBox("Please input numeric on year!")
            Exit Sub
        End If

        Dim iInvoiceDate As Integer
        If rbInvoiceDate.Checked = True Then
            iInvoiceDate = 1
        Else
            iInvoiceDate = 0
        End If

        Dim iExcludeZero As Integer
        If cbExcludeZero.Checked = True Then
            iExcludeZero = 1
        Else
            iExcludeZero = 0
        End If

        If cbStatus.SelectedIndex = 0 Then
            Status = ""
        ElseIf cbStatus.SelectedIndex = 1 Then
            Status = "UP"
        Else
            Status = "FP"
        End If

        strSQL = "exec RPT_Sls_Customer_Balance_Report " & iInvoiceDate & ", " & _
                                                        "'" & Format(dateFrom1, "yyyy/MM/dd") & "' , " & _
                                                        "'" & Format(dateTo1, "yyyy/MM/dd") & "' , " & _
                                                        "" & iYear.Text & " , " & _
                                                        "" & Trim(cmbMonth.SelectedItem.Value()) & ", " & _
                                                        "'" & SNoFrom1 & "', '" & SNoTo1 & "', '" & CCodeFrom1 & "', '" & CCodeTo1 & "', '" & Status & "', " & _
                                                        "" & iExcludeZero & ""

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SlsCustomerBalanceRpt_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_Customer_Balance_Report.rpt"

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
        NewMDIChild.Text = "Sales Customer Balance Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("SlsCustomerBalanceRpt_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
        '-----------------MENAMBAH PARAMETER FILTER KE CR--------------------------
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"

        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterdate As String
        Dim filtersno As String
        Dim filterccode As String
        Dim filterstatus As String

        If iInvoiceDate = 1 Then
            filterdate = "Invoice Date From : " & Format(dtpFrom.Value, "dd-MMM-yyyy") & " To " & Format(dtpTo.Value, "dd-MMM-yyyy")
        Else
            filterdate = "Balance Until : " & cmbMonth.Text & " - " & iYear.Text
        End If


        If txtSNoFrom.Text = "" And txtSNoTo.Text = "" Then
            filtersno = "Sales Invoice No. : All"
        Else
            filtersno = "Sales Invoice No. : " & txtSNoFrom.Text & " - " & txtSNoTo.Text
        End If
        If txtCCodeFrom.Text = "" And txtCCodeTo.Text = "" Then
            filterccode = "Customer Code : All"
        Else
            filterccode = "Customer Code : " & txtCCodeFrom.Text & " - " & txtCCodeTo.Text
        End If
        If cbStatus.SelectedIndex = 0 Then
            filterstatus = "Status : All"
        Else
            filterstatus = "Status : " & cbStatus.SelectedItem
        End If


        Dim filter As String = filterdate + vbCrLf + filtersno + vbCrLf + filterccode + vbCrLf + filterstatus

        crParameterDiscreteValue.Value = filter
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filter")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtCCodeFrom.Text = ""
        txtCCodeTo.Text = ""
        txtSNoFrom.Text = ""
        txtSNoTo.Text = ""
        cbStatus.SelectedIndex = 0
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnCustCodeFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustCodeFrom.Click
        Dim NewFormDialog As New fdlCustomerFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnCustCodeTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustCodeTo.Click
        Dim NewFormDialog As New fdlCustomerTo
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub


    Private Sub btnSNoFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSNoFrom.Click
        Dim NewFormDialog As New fdlSInvoiceFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSNoTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSNoTo.Click
        Dim NewFormDialog As New fdlSInvoiceTo
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub pLoadComboMonth()
        '----------------------------------------------------'
        'Combo Status
        '----------------------------------------------------'
        Dim iDefaultMonth As Integer
        cmbMonth.Items.Clear()

        cmbMonth.DisplayMember = "Key"
        cmbMonth.ValueMember = "Value"

        cmbMonth.Items.Add(New DictionaryEntry("Jan", "1"))
        cmbMonth.Items.Add(New DictionaryEntry("Feb", "2"))
        cmbMonth.Items.Add(New DictionaryEntry("Mar", "3"))
        cmbMonth.Items.Add(New DictionaryEntry("Apr", "4"))
        cmbMonth.Items.Add(New DictionaryEntry("May", "5"))
        cmbMonth.Items.Add(New DictionaryEntry("Jun", "6"))
        cmbMonth.Items.Add(New DictionaryEntry("Jul", "7"))
        cmbMonth.Items.Add(New DictionaryEntry("Aug", "8"))
        cmbMonth.Items.Add(New DictionaryEntry("Sep", "9"))
        cmbMonth.Items.Add(New DictionaryEntry("Oct", "10"))
        cmbMonth.Items.Add(New DictionaryEntry("Nov", "11"))
        cmbMonth.Items.Add(New DictionaryEntry("Dec", "12"))

        cmbMonth.SelectedIndex = 0
        'Default data
        iDefaultMonth = Month(Now())
        cmbMonth.SelectedIndex = iDefaultMonth - 1
        '----------------------------------------------------'
    End Sub

    Private Sub pDisableFilterDate()
        If rbInvoiceDate.Checked = True Then
            dtpFrom.Enabled = True
            dtpTo.Enabled = True
            cmbMonth.Enabled = False
            iYear.Enabled = False
        Else
            dtpFrom.Enabled = False
            dtpTo.Enabled = False
            cmbMonth.Enabled = True
            iYear.Enabled = True
        End If
    End Sub


    Private Sub rbInvoiceDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbInvoiceDate.CheckedChanged
        pDisableFilterDate()
    End Sub

    Private Sub rbBalanceUntil_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBalanceUntil.CheckedChanged
        pDisableFilterDate()
    End Sub

    Private Sub btnPrintWithBeginning_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintWithBeginning.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom1 As Date
        Dim dateTo1 As Date
        Dim SNoFrom1 As String
        Dim SNoTo1 As String
        Dim CCodeFrom1 As String
        Dim CCodeTo1 As String
        Dim Status As String


        dateFrom1 = dtpFrom.Value
        dateTo1 = dtpTo.Value
        SNoFrom1 = txtSNoFrom.Text
        SNoTo1 = txtSNoTo.Text
        CCodeFrom1 = txtCCodeFrom.Text
        CCodeTo1 = txtCCodeTo.Text


        '---- Year and Month
        If Trim(iYear.Text) = "" Then
            MsgBox("Please input year!")
            Exit Sub
        End If

        If IsNumeric(Trim(iYear.Text)) = False Then
            MsgBox("Please input numeric on year!")
            Exit Sub
        End If

        Dim iInvoiceDate As Integer
        If rbInvoiceDate.Checked = True Then
            iInvoiceDate = 1
        Else
            iInvoiceDate = 0
        End If

        Dim iExcludeZero As Integer
        If cbExcludeZero.Checked = True Then
            iExcludeZero = 1
        Else
            iExcludeZero = 0
        End If

        If cbStatus.SelectedIndex = 0 Then
            Status = ""
        ElseIf cbStatus.SelectedIndex = 1 Then
            Status = "UP"
        Else
            Status = "FP"
        End If

        strSQL = "exec RPT_Sls_Customer_Beginning_Balance_Report " & iInvoiceDate & ", " & _
                                                        "'" & Format(dateFrom1, "yyyy/MM/dd") & "' , " & _
                                                        "'" & Format(dateTo1, "yyyy/MM/dd") & "' , " & _
                                                        "" & iYear.Text & " , " & _
                                                        "" & Trim(cmbMonth.SelectedItem.Value()) & ", " & _
                                                        "'" & SNoFrom1 & "', '" & SNoTo1 & "', '" & CCodeFrom1 & "', '" & CCodeTo1 & "', '" & Status & "'"

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SlsCustomerBeginningBalanceRpt_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_Customer_Beginning_Balance_Report.rpt"

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
        NewMDIChild.Text = "Sales Customer Beginnning Balance Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("SlsCustomerBeginningBalanceRpt_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
        '-----------------MENAMBAH PARAMETER FILTER KE CR--------------------------
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"

        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterdate As String
        Dim filtersno As String
        Dim filterccode As String
        Dim filterstatus As String

        If iInvoiceDate = 1 Then
            filterdate = "Invoice Date From : " & Format(dtpFrom.Value, "dd-MMM-yyyy") & " To " & Format(dtpTo.Value, "dd-MMM-yyyy")
        Else
            filterdate = "Balance Until : " & cmbMonth.Text & " - " & iYear.Text
        End If


        If txtSNoFrom.Text = "" And txtSNoTo.Text = "" Then
            filtersno = "Sales Invoice No. : All"
        Else
            filtersno = "Sales Invoice No. : " & txtSNoFrom.Text & " - " & txtSNoTo.Text
        End If
        If txtCCodeFrom.Text = "" And txtCCodeTo.Text = "" Then
            filterccode = "Customer Code : All"
        Else
            filterccode = "Customer Code : " & txtCCodeFrom.Text & " - " & txtCCodeTo.Text
        End If
        If cbStatus.SelectedIndex = 0 Then
            filterstatus = "Status : All"
        Else
            filterstatus = "Status : " & cbStatus.SelectedItem
        End If


        Dim filter As String = filterdate + vbCrLf + filtersno + vbCrLf + filterccode + vbCrLf + filterstatus

        crParameterDiscreteValue.Value = filter
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filter")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
    End Sub
End Class