Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmSOList
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim isShowAll As Boolean = False

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Sales Order No.", 120)
            .Columns.Add("Ref No.", 200)
            .Columns.Add("dDate", "Date", 90)
            .Columns.Add("c_id", 0)
            .Columns.Add("Customer Code", 90)
            .Columns.Add("Customer Name", 200)
            .Columns.Add("so_type", 0)
            .Columns.Add("so_status", 0)
            .Columns.Add("Status", 100)
        End With

        cmd = New SqlCommand("usp_tr_so_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int, 255)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@so_no", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtSONo.Text = "", DBNull.Value, txtSONo.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@so_date1", SqlDbType.SmallDateTime)
        prm3.Value = IIf(isShowAll = False, dtpSODateFrom.Value.Date, DBNull.Value)
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@so_date2", SqlDbType.SmallDateTime)
        prm4.Value = IIf(isShowAll = False, dtpSODateTo.Value.Date, DBNull.Value)
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@c_name", SqlDbType.NVarChar, 50)
        prm5.Value = IIf(txtCName.Text = "", DBNull.Value, txtCName.Text)
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@so_stat1", SqlDbType.NVarChar, 50)
        If cmbStatus.SelectedIndex = 0 Or cmbStatus.Text = "" Then
            prm6.Value = DBNull.Value
        Else
            prm6.Value = cmbStatus.Items(cmbStatus.SelectedIndex).ItemData
        End If
        Dim prm7 As SqlParameter = cmd.Parameters.Add("@so_ref_no", SqlDbType.NVarChar, 50)
        prm7.Value = IIf(txtSORefNo.Text = "", DBNull.Value, txtSORefNo.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 8, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            lvItem.SubItems.Add(IIf(myReader.Item(11) Is DBNull.Value, "", myReader.Item(11))) 'ref_no
            lvItem.SubItems.Add(myReader.Item(2)) 'so_date
            lvItem.SubItems.Add(myReader.GetInt32(3)) 'c_id
            lvItem.SubItems.Add(myReader.GetString(4)) 'c_code
            lvItem.SubItems.Add(myReader.GetString(5)) 'c_name
            lvItem.SubItems.Add(myReader.GetString(6)) 'so_type
            lvItem.SubItems.Add(myReader.GetString(7)) 'so_status
            lvItem.SubItems.Add(myReader.GetString(8)) 'so_status_val

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

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        With frmSO
            .SOId = 0
            'frmSO.ShowDialog()
            .MdiParent = frmMAIN
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub frmSOList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Add item cmbSOStatus
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "so_status"

        cn.Open()
        Dim myReader = cmd.ExecuteReader

        cmbStatus.Items.Add(New clsMyListStr("All", ""))
        While myReader.Read
            cmbStatus.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While

        '20160629 enable date filter on load
        chbDate.Checked = True
        dtpSODateFrom.Value = Today.AddDays(-GetListDateFilterDays())
        dtpSODateTo.Value = Today

        chbDate_CheckedChanged(sender, e)

        myReader.Close()
        cn.Close()

        btnFilter_Click(sender, e)
        cmbStatus.SelectedIndex = 0
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
        If Not isDeletedRecord("usp_tr_so_SEL", "so_id", LeftSplitUF(ListView1.SelectedItems.Item(0).Tag), Me.Text) = False Then
            btnFilter_Click(sender, e)
        ElseIf Not Application.OpenForms().OfType(Of frmSO).Any Then
            With frmSO
                .SOId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                .MdiParent = frmMAIN
                .WindowState = FormWindowState.Maximized
                .Show()
            End With
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub txtPONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSONo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub txtSName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCName.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If ListView1.SelectedItems.Count > 0 Then
            ListView1_DoubleClick(sender, e)
        Else
            MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        btnFilter_Click(sender, e)
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If RadioButton2.Checked = True Then
        '    dtpSODateFrom.Enabled = True
        '    dtpSODateTo.Enabled = True
        '    dtpSODateFrom.Value = Now
        '    dtpSODateTo.Value = Now
        '    isShowAll = False
        'End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If RadioButton1.Checked = True Then
        '    dtpSODateFrom.Enabled = False
        '    dtpSODateTo.Enabled = False
        '    isShowAll = True
        'End If
    End Sub

    Private Sub chbDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbDate.CheckedChanged
        If chbDate.Checked = True Then
            dtpSODateFrom.Enabled = True
            dtpSODateTo.Enabled = True
            isShowAll = False
        Else
            dtpSODateFrom.Enabled = False
            dtpSODateTo.Enabled = False
            dtpSODateFrom.Value = Today.AddDays(-GetListDateFilterDays())
            dtpSODateTo.Value = Now
            isShowAll = True
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        chbDate.Checked = False
        txtSONo.Text = ""
        txtCName.Text = ""
        txtSORefNo.Text = ""
        cmbStatus.SelectedIndex = 0
    End Sub
    'Autorefresh---Hendra
    Public Sub frmSOListShow(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub
End Class