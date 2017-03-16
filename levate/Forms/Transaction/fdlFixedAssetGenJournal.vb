Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class fdlFixedAssetGenJournal
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FrmCallerId As String
    Dim m_fixed_asset_code_from, m_fixed_asset_code_to, m_day, m_month, m_year As String

    Public Property FrmCallerId() As String
        Get
            Return m_FrmCallerId
        End Get
        Set(ByVal Value As String)
            m_FrmCallerId = Value
        End Set
    End Property

    Public Property FixedAssetCodeFrom() As String
        Get
            Return m_fixed_asset_code_from
        End Get
        Set(ByVal Value As String)
            m_fixed_asset_code_from = Value
        End Set
    End Property

    Public Property FixedAssetCodeTo() As String
        Get
            Return m_fixed_asset_code_To
        End Get
        Set(ByVal Value As String)
            m_fixed_asset_code_To = Value
        End Set
    End Property

    Public Property Day() As String
        Get
            Return m_day
        End Get
        Set(ByVal Value As String)
            m_day = Value
        End Set
    End Property

    Public Property Month() As String
        Get
            Return m_month
        End Get
        Set(ByVal Value As String)
            m_month = Value
        End Set
    End Property

    Public Property year() As String
        Get
            Return m_year
        End Get
        Set(ByVal Value As String)
            m_year = Value
        End Set
    End Property

    Private Sub fdlFixedAssetGenJournal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Fixed Asset Category Code", 150)
            .Columns.Add("Journal Date", 120)
            .Columns.Add("Amount", 200, HorizontalAlignment.Right)
            .Columns.Add("Account id", 0)
            .Columns.Add("Accumulate account id", 0)
        End With

        cmd = New SqlCommand("sp_mt_fixed_asset_depreciation_PREVIEW", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm2 As SqlParameter = cmd.Parameters.Add("@fixed_asset_cat_code_from", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(m_fixed_asset_code_from <> "", m_fixed_asset_code_from, DBNull.Value)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@fixed_asset_cat_code_to", SqlDbType.NVarChar, 50)
        prm3.Value = IIf(m_fixed_asset_code_to <> "", m_fixed_asset_code_to, DBNull.Value)
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@month", SqlDbType.NVarChar, 2)
        prm4.Value = m_month
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@year", SqlDbType.NVarChar, 4)
        prm5.Value = m_year

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView2, 6, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0))) 'Fixed Asset Code
            lvItem.Tag = intCurrRow
            lvItem.SubItems.Add(myReader.Item(1)) 'Journal Date
            lvItem.SubItems.Add(FormatNumber(myReader.Item(2), 2)) 'Amount
            lvItem.SubItems.Add(myReader.Item(3)) 'Account id
            lvItem.SubItems.Add(myReader.Item(4)) ' Accumulate account id

            If intCurrRow Mod 2 = 0 Then
                lvItem.BackColor = Color.Lavender
            Else
                lvItem.BackColor = Color.White
            End If
            lvItem.UseItemStyleForSubItems = True

            ListView1.Items.Add(lvItem)
            intCurrRow += 1
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Private Sub ListView1_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        If (e.Column = ListView1Sorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending) Then
                ListView1Sorter.Order = Windows.Forms.SortOrder.Descending
            Else
                ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            ListView1Sorter.SortColumn = e.Column
            ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending
        End If

        ' Perform the sort with these new sort options.
        ListView1.Sort()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If MsgBox("Are you sure you want to generate depreciation?", vbYesNo + vbInformation, Me.Text) = vbYes Then
            Cursor = Cursors.WaitCursor 'change pointer/cursor into hourglass
            Dim JournalNo, JournalDate As String
            JournalNo = GetSysNumber("journal_auto", Now.Date)
            UpdSysNumber("journal_auto")
            JournalDate = m_year + "-" + m_month + "-" + m_day

            Try
                If ListView1.Items.Count > 0 Then
                    For i = 0 To ListView1.Items.Count - 1
                        cmd = New SqlCommand("sp_GL_JOURNAL_INS", cn)
                        cmd.CommandType = CommandType.StoredProcedure

                        Dim prm1 As SqlParameter = cmd.Parameters.Add("@Reference_No", SqlDbType.NVarChar, 25)
                        prm1.Value = JournalNo
                        Dim prm2 As SqlParameter = cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 50)
                        prm2.Value = JournalDate
                        Dim prm3 As SqlParameter = cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 50)
                        prm3.Value = "-"
                        Dim prm4 As SqlParameter = cmd.Parameters.Add("@Account_Code", SqlDbType.NVarChar, 50)
                        prm4.Value = ListView1.Items(i).SubItems.Item(3).Text
                        Dim prm5 As SqlParameter = cmd.Parameters.Add("@Accumulate_Account_Code", SqlDbType.NVarChar, 50)
                        prm5.Value = ListView1.Items(i).SubItems.Item(4).Text
                        Dim prm6 As SqlParameter = cmd.Parameters.Add("@Note", SqlDbType.NVarChar, 50)
                        prm6.Value = ListView1.Items(i).SubItems.Item(0).Text
                        Dim prm7 As SqlParameter = cmd.Parameters.Add("@Value", SqlDbType.Decimal)
                        prm7.Value = FormatNumber(ListView1.Items(i).SubItems.Item(2).Text, 2)

                        cn.Open()
                        cmd.CommandTimeout = CInt(GetSysInit("db_timeout"))
                        cmd.ExecuteReader()
                        cn.Close()

                    Next
                    MsgBox("Generate depreciation journal completed", vbInformation)
                    Me.Close()
                Else
                    MsgBox("This journal has no depreciation", vbCritical)
                End If
            Catch ex As Exception
                MsgBox(ex.Message, vbCritical)
                If ConnectionState.Open = True Then cn.Close()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Fixed_Asset_Preview_Report '" & m_fixed_asset_code_from & "', '" & m_fixed_asset_code_to & "', '" & m_month & "', '" & m_year & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "FAPreviewJour_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Fixed_Asset_Preview_Report.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If
        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Fixed Asset Preview"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("FAPreviewJour_"))

        '-----------------MENAMBAH PARAMETER PCH--------------------------
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filter As String
        Dim filterscat As String
        Dim filtersperiod As String

        If m_fixed_asset_code_from = "" And m_fixed_asset_code_to = "" Then
            filterscat = "Fixed Asset Cat. Code : All"
        Else
            filterscat = "Fixed Asset Cat. Code :" + m_fixed_asset_code_from + " - " + m_fixed_asset_code_to
        End If

        filtersperiod = "Period :" + m_month + " - " + m_year

        filter = filtersperiod + vbCrLf + filterscat

        crParameterDiscreteValue.Value = filter
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filter")
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
End Class