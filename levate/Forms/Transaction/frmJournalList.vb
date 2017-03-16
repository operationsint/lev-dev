Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmJournalList
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim isShowAll As Boolean = False
    Dim m_ClosedStatusArr(1, 1) As String

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        With frmJournal
            .JournalId = 0
            'frmPO.ShowDialog()
            .MdiParent = frmMAIN
            .Show()
        End With
    End Sub

    Private Sub frmJournalList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Add item cmbJournalType
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "journal_trans_type"

        cn.Open()
        Dim myReader = cmd.ExecuteReader

        cmbJournalTransType.Items.Add(New clsMyListStr("All", ""))
        While myReader.Read
            cmbJournalTransType.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While

        myReader.Close()
        cn.Close()

        'Add item is_posted
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "is_closed"

        cn.Open()
        myReader = cmd.ExecuteReader

        Dim i As Integer
        i = 0
        While myReader.Read
            m_ClosedStatusArr(i, 0) = myReader.GetString(0)
            m_ClosedStatusArr(i, 1) = myReader.GetString(1)
            i += 1
        End While

        myReader.Close()
        cn.Close()

        '20160711 daniel s : enable date filter onload
        RadioButton2.Checked = True
        dtpPODateFrom.Value = Today.AddDays(-GetListDateFilterDays())
        dtpPODateTo.Value = Today

        RadioButton2_CheckedChanged(Me, Nothing)

        btnFilter_Click(sender, e)
        cmbJournalTransType.SelectedIndex = 0
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1))
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

        '20160928 Dikman : Sort Date ListView
        If e.Column = ListView1.Columns("dDate").Index Then
            ListView1Sorter.DateColumn = 1
        Else
            ListView1Sorter.DateColumn = 0
        End If

        ' Perform the sort with these new sort options.
        ListView1.Sort()
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If Not isDeletedRecord("usp_tr_journal_SEL", "journal_id", LeftSplitUF(ListView1.SelectedItems.Item(0).Tag), Me.Text) = False Then
            btnFilter_Click(sender, e)
        ElseIf Not Application.OpenForms().OfType(Of frmJournal).Any Then
            With frmJournal
                .JournalId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                .MdiParent = frmMAIN
                .AutoSizeMode = Windows.Forms.AutoSizeMode.GrowAndShrink
                .Show()
            End With
        End If
    End Sub

    Private Sub txtPONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtJournalNo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub txtSName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSName.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If ListView1.SelectedItems.Count > 0 Then
            ListView1_DoubleClick(sender, e)
        Else
            MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub cmbStatus_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJournalTransType.SelectedIndexChanged
        btnFilter_Click(sender, e)
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            dtpPODateFrom.Enabled = False
            dtpPODateTo.Enabled = False
            'txtPONo.Text = ""
            'txtSName.Text = ""
            'cmbStatus.SelectedIndex = -1
            isShowAll = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            dtpPODateFrom.Enabled = True
            dtpPODateTo.Enabled = True
            dtpPODateFrom.Value = Today.AddDays(-GetListDateFilterDays())
            dtpPODateTo.Value = Now
            isShowAll = False
        End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Journal No.", 120)
            .Columns.Add("dDate", "Date", 90)
            .Columns.Add("closing_period", 0)
            .Columns.Add("Ref No.", 90)
            .Columns.Add("Remarks", 250)
            .Columns.Add("trans_type", 0)
            .Columns.Add("curr_code", 0)
            .Columns.Add("Local Total", 120, HorizontalAlignment.Right)
            .Columns.Add("Closed Status", 90)
        End With

        cmd = New SqlCommand("usp_tr_journal_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@journal_id", SqlDbType.Int)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@journal_no", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtJournalNo.Text = "", DBNull.Value, txtJournalNo.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@journal_date1", SqlDbType.SmallDateTime)
        prm3.Value = IIf(isShowAll = False, dtpPODateFrom.Value.Date, DBNull.Value)
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@journal_date2", SqlDbType.SmallDateTime)
        prm4.Value = IIf(isShowAll = False, dtpPODateTo.Value.Date, DBNull.Value)
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@trans_type", SqlDbType.NVarChar, 50)
        If cmbJournalTransType.SelectedIndex = 0 Or cmbJournalTransType.Text = "" Then
            prm6.Value = DBNull.Value
        Else
            prm6.Value = cmbJournalTransType.Items(cmbJournalTransType.SelectedIndex).ItemData
        End If

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 4, 1)

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1))) 'journal_no
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            lvItem.SubItems.Add(myReader.Item(2)) 'journal_date
            lvItem.SubItems.Add(myReader.Item(3)) 'journal_period_id
            lvItem.SubItems.Add(IIf(myReader.Item(4) Is DBNull.Value, "", myReader.Item(4))) 'journal_ref_no
            lvItem.SubItems.Add(IIf(myReader.Item(5) Is DBNull.Value, "", myReader.Item(5))) 'journal_remarks
            lvItem.SubItems.Add(myReader.Item(6)) 'trans_type
            lvItem.SubItems.Add(myReader.Item(9)) 'curr_code
            lvItem.SubItems.Add(FormatNumber(myReader.Item(13))) 'local_db
            lvItem.SubItems.Add(IIf(myReader.GetBoolean(15) = m_ClosedStatusArr(0, 0), m_ClosedStatusArr(0, 1), m_ClosedStatusArr(1, 1))) 'is_closed
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
End Class
