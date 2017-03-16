Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptPnLReport
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim Connection As New SqlConnection(strConnection)
    Dim strSQL As String

    Private Sub rptPnLReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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


    End Sub

    Public Property PeriodFrom() As String
        Get
            Return txtPeriodFrom.Text()
        End Get
        Set(ByVal Value As String)
            txtPeriodFrom.Text() = Value
        End Set
    End Property

    Public Property PeriodTo() As String
        Get
            Return txtPeriodTo.Text()
        End Get
        Set(ByVal Value As String)
            txtPeriodTo.Text() = Value
        End Set
    End Property

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Dim PeriodFrom1 As String
        Dim PeriodTo1 As String
        Dim AccountFrom1 As String
        Dim AccountTo1 As String
        Dim AccCatFrom1 As String
        Dim AccCatTo1 As String
        Dim AccSubCatFrom1 As String
        Dim AccSubCatTo1 As String



        'Period
        If txtPeriodFrom.Text <> "" And txtPeriodTo.Text <> "" Then
            PeriodFrom1 = txtPeriodFrom.Text
            PeriodTo1 = txtPeriodTo.Text
            If txtPeriodFrom.Text = "" And txtPeriodTo.Text <> "" Then
                PeriodFrom1 = txtPeriodTo.Text
                PeriodTo1 = txtPeriodTo.Text
            ElseIf txtPeriodFrom.Text <> "" And txtPeriodTo.Text = "" Then
                PeriodFrom1 = txtPeriodFrom.Text
                PeriodTo1 = txtPeriodFrom.Text
            End If
        Else
            PeriodFrom1 = ""
            PeriodTo1 = ""
        End If

        

        strSQL = "exec RPT_GL_PNL_Report '" & PeriodFrom1 & "' , '" & PeriodTo1 & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        'DA.Fill(DS, "Journal_Trans_Report_")
        DA.Fill(DS, "Profit_And_Loss_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_GL_PnL_Report.rpt"

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

        NewMDIChild.Text = "Profilt & Loss"
        NewMDIChild.Show()

        cr.Load(strReportPath)

        cr.SetDataSource(DS.Tables("Profit_And_Loss_"))

        '-----------------MENAMBAH PARAMETER FILTER DATE--------------------------
        
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
       
        Dim filterperiod As String
        Dim MyPeriodFrom As String
        Dim MyPeriodTo As String


        If txtPeriodFrom.Text = "" And txtPeriodTo.Text = "" Then
            filterperiod = "Period No. : All"
        Else

            'Get Name for PeriodFrom
            cmd = New SqlCommand("SELECT top 1 period_name FROM sys_period WHERE period_id = '" & CInt(txtPeriodFrom.Text) & "'", cn)
            cn.Open()
            Dim myReader2 As SqlDataReader = cmd.ExecuteReader()
            While myReader2.Read
                MyPeriodFrom = CStr(myReader2.Item(0))
            End While
            myReader2.Close()
            cn.Close()

            'Get Name for PeriodTo
            cmd = New SqlCommand("SELECT top 1 period_name FROM sys_period WHERE period_id = '" & CInt(txtPeriodTo.Text) & "'", cn)
            cn.Open()
            Dim myReader3 As SqlDataReader = cmd.ExecuteReader()
            While myReader3.Read
                MyPeriodTo = CStr(myReader3.Item(0))
            End While
            myReader3.Close()
            cn.Close()


            filterperiod = "Period : " & MyPeriodFrom & "-" & MyPeriodTo
        End If


        Dim filter As String = filterperiod
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
        txtPeriodFrom.Text = ""
        txtPeriodTo.Text = ""
        'cbDate.Checked = False
        'cmbJournalTransTypeFrom.SelectedIndex = 0
        'cmbJournalTransTypeTo.SelectedIndex = 0
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

    Private Sub btnCodeFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim NewFormDialog As New fdlAccount
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnCodeTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim NewFormDialog As New fdlAccount
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPchCodeFrom_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim NewFormDialog As New fdlJournal
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub


    Private Sub btnAccCatFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim newformdialog As New fdlAccCat
        newformdialog.FrmCallerId = Me.Name + "From"
        newformdialog.ShowDialog()
    End Sub

    Private Sub btnAccCatTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim newformdialog As New fdlAccCat
        newformdialog.FrmCallerId = Me.Name + "To"
        newformdialog.ShowDialog()
    End Sub

    Private Sub btnAccSubCatFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim newformdialog As New fdlAccSubCat
        newformdialog.FrmCallerId = Me.Name + "From"
        newformdialog.ShowDialog()
    End Sub

    Private Sub btnAccSubCatTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim newformdialog As New fdlAccSubCat
        newformdialog.FrmCallerId = Me.Name + "To"
        newformdialog.ShowDialog()
    End Sub

    Private Sub btnPeriodFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodFrom.Click
        Dim NewFormDialog As New fdlPeriod
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPeriodTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodTo.Click
        Dim NewFormDialog As New fdlPeriod
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub
End Class