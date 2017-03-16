Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptGLJournalTrans
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim Connection As New SqlConnection(strConnection)
    Dim strSQL As String

    Private Sub rptGLJournalTrans_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"

        'Add item cmbJournalType
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "journal_trans_type"

        cn.Open()
        Dim myReader = cmd.ExecuteReader

        cmbJournalTransTypeFrom.Items.Add(New clsMyListStr("All", ""))
        cmbJournalTransTypeTo.Items.Add(New clsMyListStr("All", ""))
        While myReader.Read
            cmbJournalTransTypeFrom.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
            cmbJournalTransTypeTo.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While

        myReader.Close()
        cn.Close()

        cmbJournalTransTypeFrom.SelectedIndex = 0
        cmbJournalTransTypeTo.SelectedIndex = 0

        cbDate.Checked = False
        dtpFrom.Enabled = False
        dtpTo.Enabled = False

        cmbOrderBy.Items.Insert(0, "Journal No.")
        cmbOrderBy.Items.Insert(1, "Journal Type")
        cmbOrderBy.SelectedIndex = 0
    End Sub

    Public Property JournalNoFrom() As String
        Get
            Return txtJournalFrom.Text
        End Get
        Set(ByVal Value As String)
            txtJournalFrom.Text = Value
        End Set
    End Property
    Public Property JournalNoTo() As String
        Get
            Return txtJournalTo.Text()
        End Get
        Set(ByVal Value As String)
            txtJournalTo.Text() = Value
        End Set
    End Property

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

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim TypeFrom1 As String
        Dim TypeTo1 As String
        Dim dateFrom As String
        Dim dateTo As String
        Dim JournalFrom1 As String
        Dim JournalTo1 As String
        Dim AccountFrom1 As String
        Dim AccountTo1 As String
        Dim OrderBy As String
        
        'cmbJournalTransType.Items(cmbJournalTransType.SelectedIndex).ItemData()
        If cmbJournalTransTypeFrom.SelectedIndex = 0 Then
            TypeFrom1 = ""
        Else
            TypeFrom1 = cmbJournalTransTypeFrom.Items(cmbJournalTransTypeFrom.SelectedIndex).ItemData
        End If
        If cmbJournalTransTypeTo.SelectedIndex = 0 Then
            TypeTo1 = ""
        Else
            TypeTo1 = cmbJournalTransTypeTo.Items(cmbJournalTransTypeTo.SelectedIndex).ItemData
        End If

        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "yyyy/MM/dd"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "yyyy/MM/dd"

        If cbDate.Checked = True Then
            dateFrom = dtpFrom.Text
            dateTo = dtpTo.Text
        Else
            dateFrom = ""
            dateTo = ""
        End If


        If txtJournalFrom.Text <> "" And txtJournalTo.Text <> "" Then
            JournalFrom1 = txtJournalFrom.Text
            JournalTo1 = txtJournalTo.Text
            If txtJournalFrom.Text = "" And txtJournalTo.Text <> "" Then
                JournalFrom1 = txtJournalTo.Text
                JournalTo1 = txtJournalTo.Text
            ElseIf txtJournalFrom.Text <> "" And txtJournalTo.Text = "" Then
                JournalFrom1 = txtJournalFrom.Text
                JournalTo1 = txtJournalFrom.Text
            End If
        Else
            JournalFrom1 = ""
            JournalTo1 = ""
        End If

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

        If cmbOrderBy.SelectedIndex = 1 Then
            OrderBy = "C.journal_trans_type"
        Else
            OrderBy = "A.journal_no"
        End If

        strSQL = "exec RPT_GL_JournalTrans_Report '" & TypeFrom1 & "' , '" & TypeTo1 & "','" & dateFrom & "' , '" & dateTo & "', '" & JournalFrom1 & "', '" & JournalTo1 & "', '" & AccountFrom1 & "', '" & AccountTo1 & "', '" & OrderBy & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "Journal_Trans_Report_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_GL_JournalTrans.rpt"

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
        NewMDIChild.Text = "Journal Transaction Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("Journal_Trans_Report_"))

        '-----------------MENAMBAH PARAMETER FILTER DATE--------------------------
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filtertype As String
        Dim filterdate As String
        Dim filterjournalno As String
        Dim filteraccountcode As String
        Dim filterorderby As String = OrderBy

        If cmbJournalTransTypeFrom.SelectedIndex = 0 And cmbJournalTransTypeTo.SelectedIndex = 0 Then
            filtertype = "Journal Transaction Type : All"
        Else
            filtertype = "Journal Transaction Type :" & TypeFrom1 & "-" & TypeTo1
        End If

        If cbDate.Checked = True Then
            filterdate = "Journal Transaction Date : " & dtpFrom.Text & "-" & dtpTo.Text
        Else
            filterdate = "Journal Transaction Date : All"
        End If

        If txtJournalFrom.Text = "" And txtJournalTo.Text = "" Then
            filterjournalno = "Journal No. : All"
        Else
            filterjournalno = "Journal No. : " & txtJournalFrom.Text & "-" & txtJournalTo.Text
        End If

        If txtAccountFrom.Text = "" And txtAccountTo.Text = "" Then
            filteraccountcode = "Account Code : All"
        Else
            filteraccountcode = "Account Code : " & txtAccountFrom.Text & "-" & txtAccountTo.Text
        End If

        Dim filter As String = filtertype + vbCrLf + filterdate + vbCrLf + filterjournalno + vbCrLf + filteraccountcode + vbCrLf + filterorderby
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
        txtJournalFrom.Text = ""
        txtJournalTo.Text = ""
        txtAccountFrom.Text = ""
        txtAccountTo.Text = ""
        cbDate.Checked = False
        cmbJournalTransTypeFrom.SelectedIndex = 0
        cmbJournalTransTypeTo.SelectedIndex = 0
        cmbOrderBy.SelectedIndex = 0
    End Sub

    Private Sub btnPchCodeFrom_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoFrom.Click
        Dim NewFormDialog As New fdlJournal
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPchCodeTo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoTo.Click
        Dim NewFormDialog As New fdlJournal
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub cbDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDate.CheckedChanged
        If cbDate.Checked = True Then
            dtpFrom.Enabled = True
            dtpTo.Enabled = True
        Else
            dtpFrom.Enabled = False
            dtpTo.Enabled = False
        End If
    End Sub

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
End Class