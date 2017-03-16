Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptGeneralLedgerReport
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim Connection As New SqlConnection(strConnection)
    Dim strSQL As String

    Private Sub rptGeneralLedgerReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'dtpFrom.Format = DateTimePickerFormat.Custom
        'dtpFrom.CustomFormat = "dd/MM/yyyy"
        'dtpTo.Format = DateTimePickerFormat.Custom
        'dtpTo.CustomFormat = "dd/MM/yyyy"

        'Add item cmbJournalType
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "journal_trans_type"

        cn.Open()
        Dim myReader = cmd.ExecuteReader

        'cmbJournalTransTypeFrom.Items.Add(New clsMyListStr("All", ""))
        'cmbJournalTransTypeTo.Items.Add(New clsMyListStr("All", ""))
        'While myReader.Read
        ' cmbJournalTransTypeFrom.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        'cmbJournalTransTypeTo.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        'End While

        myReader.Close()
        cn.Close()

        'cmbJournalTransTypeFrom.SelectedIndex = 0
        'cmbJournalTransTypeTo.SelectedIndex = 0

        'cbDate.Checked = False
        'dtpFrom.Enabled = False
        'dtpTo.Enabled = False

        cmbOrderBy.Items.Insert(0, "Account Code")
        cmbOrderBy.SelectedIndex = 0
    End Sub

   

    Public Property AccountCodeFrom() As String
        Get
            Return txtAccountFrom.Text
        End Get
        Set(ByVal Value As String)
            txtAccountFrom.Text = Value
        End Set
    End Property
    Public Property AccountCodeTo() As String
        Get
            Return txtAccountTo.Text()
        End Get
        Set(ByVal Value As String)
            txtAccountTo.Text() = Value
        End Set
    End Property


    Public Property AccountCatCodeFrom() As String
        Get
            Return txtAccCatFrom.Text
        End Get
        Set(ByVal Value As String)
            txtAccCatFrom.Text = Value
        End Set
    End Property
    Public Property AccountCatCodeTo() As String
        Get
            Return txtAccCatTo.Text()
        End Get
        Set(ByVal Value As String)
            txtAccCatTo.Text() = Value
        End Set
    End Property

    Public Property AccountSubCatCodeFrom() As String
        Get
            Return txtAccSubCatFrom.Text
        End Get
        Set(ByVal Value As String)
            txtAccSubCatFrom.Text = Value
        End Set
    End Property
    Public Property AccountSubCatCodeTo() As String
        Get
            Return txtAccSubCatTo.Text()
        End Get
        Set(ByVal Value As String)
            txtAccSubCatTo.Text() = Value
        End Set
    End Property

    Public Property Period() As String
        Get
            Return txtPeriod.Text()
        End Get
        Set(ByVal Value As String)
            txtPeriod.Text() = Value
        End Set
    End Property


    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Dim Period1 As String
        Dim AccountFrom1 As String
        Dim AccountTo1 As String
        Dim AccCatFrom1 As String
        Dim AccCatTo1 As String
        Dim AccSubCatFrom1 As String
        Dim AccSubCatTo1 As String



        'Period
        If txtPeriod.Text <> "" Then
            Period1 = txtPeriod.Text
        Else
            Period1 = ""
        End If

        'Acc From & To
        If txtAccountFrom.Text <> "" And txtAccountTo.Text <> "" Then
            AccountFrom1 = txtAccountFrom.Text
            AccountTo1 = txtAccountTo.Text
            If txtAccountFrom.Text = "" And txtAccountTo.Text <> "" Then
                AccountFrom1 = txtAccountTo.Text
                AccountTo1 = txtAccountTo.Text
            ElseIf txtAccountFrom.Text <> "" And txtAccountTo.Text = "" Then
                AccountFrom1 = txtAccountFrom.Text
                AccountTo1 = txtAccountFrom.Text
            End If
        Else
            AccountFrom1 = ""
            AccountTo1 = ""
        End If

        'Acc Cat From & To
        If txtAccCatFrom.Text <> "" And txtAccCatTo.Text <> "" Then
            AccCatFrom1 = txtAccCatFrom.Text
            AccCatTo1 = txtAccCatTo.Text
            If txtAccCatFrom.Text = "" And txtAccCatTo.Text <> "" Then
                AccCatFrom1 = txtAccCatTo.Text
                AccCatTo1 = txtAccCatTo.Text
            ElseIf txtAccCatFrom.Text <> "" And txtAccCatTo.Text = "" Then
                AccCatFrom1 = txtAccCatFrom.Text
                AccCatTo1 = txtAccCatFrom.Text
            End If
        Else
            AccCatFrom1 = ""
            AccCatTo1 = ""
        End If

        'Acc Sub Cat From & To
        If txtAccSubCatFrom.Text <> "" And txtAccSubCatTo.Text <> "" Then
            AccSubCatFrom1 = txtAccSubCatFrom.Text
            AccSubCatTo1 = txtAccSubCatTo.Text
            If txtAccSubCatFrom.Text = "" And txtAccSubCatTo.Text <> "" Then
                AccSubCatFrom1 = txtAccSubCatTo.Text
                AccSubCatTo1 = txtAccSubCatTo.Text
            ElseIf txtAccSubCatFrom.Text <> "" And txtAccSubCatTo.Text = "" Then
                AccSubCatFrom1 = txtAccSubCatFrom.Text
                AccSubCatTo1 = txtAccSubCatFrom.Text
            End If
        Else
            AccSubCatFrom1 = ""
            AccSubCatTo1 = ""
        End If

        'OrderBy = "Account_Code"

        'If cmbOrderBy.SelectedIndex = 1 Then
        '    OrderBy = "C.journal_trans_type"
        'Else
        '    OrderBy = "A.journal_no"
        'End If

        strSQL = "exec RPT_GL_GeneralLedger_Report '" & Period1 & "' , '" & AccountFrom1 & "','" & AccountTo1 & "' , '" & AccCatFrom1 & "', '" & AccCatTo1 & "', '" & AccSubCatFrom1 & "', '" & AccSubCatTo1 & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        'DA.Fill(DS, "Journal_Trans_Report_")
        DA.Fill(DS, "General_Ledger_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_GL_GeneralLedger.rpt"

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
        'NewMDIChild.Text = "Journal Transaction Report"
        NewMDIChild.Text = "General Ledger"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        'cr.SetDataSource(DS.Tables("Journal_Trans_Report_"))
        cr.SetDataSource(DS.Tables("General_Ledger_"))

        '-----------------MENAMBAH PARAMETER FILTER DATE--------------------------
        'dtpFrom.Format = DateTimePickerFormat.Custom
        'dtpFrom.CustomFormat = "dd/MM/yyyy"
        'dtpTo.Format = DateTimePickerFormat.Custom
        'dtpTo.CustomFormat = "dd/MM/yyyy"
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        'Dim filtertype As String
        'Dim filterdate As String
        'Dim filterjournalno As String
        Dim filterperiod As String
        Dim filteraccountcode As String
        Dim filteracccatcode As String
        Dim filteraccsubcatcode As String
        'Dim filterorderby As String = OrderBy

        'If cmbJournalTransTypeFrom.SelectedIndex = 0 And cmbJournalTransTypeTo.SelectedIndex = 0 Then
        'filtertype = "Journal Transaction Type : All"
        'Else
        'filtertype = "Journal Transaction Type :" & TypeFrom1 & "-" & TypeTo1
        'End If

        'If cbDate.Checked = True Then
        '    filterdate = "Journal Transaction Date : " & dtpFrom.Text & "-" & dtpTo.Text
        'Else
        '    filterdate = "Journal Transaction Date : All"
        'End If

        'If txtJournalFrom.Text = "" And txtJournalTo.Text = "" Then
        '    filterjournalno = "Journal No. : All"
        'Else
        '    filterjournalno = "Journal No. : " & txtJournalFrom.Text & "-" & txtJournalTo.Text
        'End If

        filterperiod = "Period : "


        If IsNumeric(txtPeriod.Text) = True Then

            cmd = New SqlCommand("SELECT top 1 period_name FROM sys_period WHERE period_id = '" & CInt(txtPeriod.Text) & "'", cn)
            cn.Open()

            Dim myReader2 As SqlDataReader = cmd.ExecuteReader()

            While myReader2.Read
                filterperiod = filterperiod & CStr(myReader2.Item(0))
            End While

            myReader2.Close()

            cn.Close()
            'filterperiod = "Periode : " & txtPeriod.Text
        Else
            filterperiod = filterperiod & "All"
        End If

        If txtAccountFrom.Text = "" And txtAccountTo.Text = "" Then
            filteraccountcode = "Account Code : All"
        Else
            filteraccountcode = "Account Code : " & txtAccountFrom.Text & "-" & txtAccountTo.Text
        End If

        If txtAccCatFrom.Text = "" And txtAccCatTo.Text = "" Then
            filteracccatcode = "Account Cat Code : All"
        Else
            filteracccatcode = "Account Cat Code : " & txtAccCatFrom.Text & "-" & txtAccCatTo.Text
        End If

        If txtAccSubCatFrom.Text = "" And txtAccSubCatTo.Text = "" Then
            filteraccsubcatcode = "Account Sub Cat Code : All"
        Else
            filteraccsubcatcode = "Account Sub Cat Code : " & txtAccSubCatFrom.Text & "-" & txtAccSubCatTo.Text
        End If

        Dim filter As String = filterperiod + vbCrLf + filteraccountcode + vbCrLf + filteracccatcode + vbCrLf + filteraccsubcatcode
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
        'txtJournalFrom.Text = ""
        'txtJournalTo.Text = ""
        txtPeriod.Text = ""
        txtAccountFrom.Text = ""
        txtAccountTo.Text = ""
        txtAccCatFrom.Text = ""
        txtAccCatTo.Text = ""
        txtAccSubCatFrom.Text = ""
        txtAccSubCatTo.Text = ""
        'cbDate.Checked = False
        'cmbJournalTransTypeFrom.SelectedIndex = 0
        'cmbJournalTransTypeTo.SelectedIndex = 0
        cmbOrderBy.SelectedIndex = 0
    End Sub



    Private Sub btnPchCodeTo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim NewFormDialog As New fdlJournal
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub

    'Private Sub cbDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cbDate.Checked = True Then
    '        dtpFrom.Enabled = True
    '        dtpTo.Enabled = True
    '    Else
    '        dtpFrom.Enabled = False
    '        dtpTo.Enabled = False
    '    End If
    'End Sub

    Private Sub btnCodeFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCodeFrom.Click
        Dim NewFormDialog As New fdlAccount
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnCodeTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCodeTo.Click
        Dim NewFormDialog As New fdlAccount
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPchCodeFrom_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim NewFormDialog As New fdlJournal
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSearchPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchPeriod.Click
        Dim NewFormDialog As New fdlPeriod
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnAccCatFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccCatFrom.Click
        Dim newformdialog As New fdlAccCat
        newformdialog.FrmCallerId = Me.Name + "From"
        newformdialog.ShowDialog()
    End Sub

    Private Sub btnAccCatTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccCatTo.Click
        Dim newformdialog As New fdlAccCat
        newformdialog.FrmCallerId = Me.Name + "To"
        newformdialog.ShowDialog()
    End Sub

    Private Sub btnAccSubCatFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccSubCatFrom.Click
        Dim newformdialog As New fdlAccSubCat
        newformdialog.FrmCallerId = Me.Name + "From"
        newformdialog.ShowDialog()
    End Sub

    Private Sub btnAccSubCatTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccSubCatTo.Click
        Dim newformdialog As New fdlAccSubCat
        newformdialog.FrmCallerId = Me.Name + "To"
        newformdialog.ShowDialog()
    End Sub
End Class