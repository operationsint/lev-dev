Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmSDeliveryList
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim isShowAll As Boolean = False
    Dim m_PostedStatusArr(1, 1) As String

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Sales Delivery No.", 120)
            .Columns.Add("dDate", "Date", 90)
            .Columns.Add("C Id", 0)
            .Columns.Add("Customer Code", 90)
            .Columns.Add("Customer Name", 270)
            .Columns.Add("sdelivery_status", 0)
            .Columns.Add("Status", 90)
            .Columns.Add("Posted Status", 90)
        End With

        cmd = New SqlCommand("usp_tr_sdelivery_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sdelivery_id", SqlDbType.Int, 255)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@sdelivery_no", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtPRNo.Text = "", DBNull.Value, txtPRNo.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@sdelivery_date1", SqlDbType.SmallDateTime)
        prm3.Value = IIf(isShowAll = False, dtpPRDateFrom.Value.Date, DBNull.Value)
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@sdelivery_date2", SqlDbType.SmallDateTime)
        prm4.Value = IIf(isShowAll = False, dtpPRDateTo.Value.Date, DBNull.Value)
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@c_name", SqlDbType.NVarChar, 50)
        prm5.Value = IIf(txtSName.Text = "", DBNull.Value, txtSName.Text)
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@sdelivery_stat", SqlDbType.NVarChar, 50)
        If cmbStatus.SelectedIndex = 0 Or cmbStatus.Text = "" Then
            prm6.Value = DBNull.Value
        Else
            prm6.Value = cmbStatus.Items(cmbStatus.SelectedIndex).ItemData
        End If

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            lvItem.SubItems.Add(myReader.Item(2))
            lvItem.SubItems.Add(myReader.GetInt32(5))
            lvItem.SubItems.Add(myReader.GetString(6))
            lvItem.SubItems.Add(myReader.GetString(7))
            lvItem.SubItems.Add(myReader.GetString(12))
            lvItem.SubItems.Add(myReader.GetString(13))
            lvItem.SubItems.Add(IIf(myReader.GetBoolean(15) = m_PostedStatusArr(0, 0), m_PostedStatusArr(0, 1), m_PostedStatusArr(1, 1))) 'is_posted
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
        frmSDelivery.SDeliveryId = 0
        frmSDelivery.MdiParent = frmMAIN
        frmSDelivery.Show()
    End Sub

    Private Sub frmSDeliveryList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Add item cmbPRStatus
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "sdelivery_status"

        cn.Open()
        Dim myReader = cmd.ExecuteReader

        cmbStatus.Items.Add(New clsMyListStr("All", ""))
        While myReader.Read
            cmbStatus.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While

        '20160629 enable date filter onload
        chbDate.Checked = True
        dtpPRDateFrom.Value = Today.AddDays(-GetListDateFilterDays())
        dtpPRDateTo.Value = Today

        chbDate_CheckedChanged(sender, e)

        myReader.Close()
        cn.Close()

        'Add item is_posted
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "is_posted"

        cn.Open()
        myReader = cmd.ExecuteReader

        Dim i As Integer
        i = 0
        While myReader.Read
            m_PostedStatusArr(i, 0) = myReader.GetString(0)
            m_PostedStatusArr(i, 1) = myReader.GetString(1)
            i += 1
        End While

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
        If Not isDeletedRecord("usp_tr_sdelivery_SEL", "sdelivery_id", LeftSplitUF(ListView1.SelectedItems.Item(0).Tag), Me.Text) = False Then
            btnFilter_Click(sender, e)
        ElseIf Not Application.OpenForms().OfType(Of frmSDelivery).Any Then
            With frmSDelivery
                .SDeliveryId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                .MdiParent = frmMAIN
                .Show()
            End With
        End If
    End Sub

    Private Sub txtPRNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPRNo.KeyPress
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

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If RadioButton2.Checked = True Then
        '    dtpPRDateFrom.Enabled = True
        '    dtpPRDateTo.Enabled = True
        '    dtpPRDateFrom.Value = Now
        '    dtpPRDateTo.Value = Now
        '    isShowAll = False
        'End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If RadioButton1.Checked = True Then
        '    dtpPRDateFrom.Enabled = False
        '    dtpPRDateTo.Enabled = False
        '    isShowAll = True
        'End If
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        btnFilter_Click(sender, e)
    End Sub

    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        chbDate.Checked = False
        txtPRNo.Text = ""
        txtSName.Text = ""
        cmbStatus.SelectedIndex = 0
    End Sub

    Private Sub chbDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbDate.CheckedChanged
        If chbDate.Checked = True Then
            dtpPRDateFrom.Enabled = True
            dtpPRDateTo.Enabled = True
            isShowAll = False
        Else
            dtpPRDateFrom.Enabled = False
            dtpPRDateTo.Enabled = False
            dtpPRDateFrom.Value = Today.AddDays(-GetListDateFilterDays())
            dtpPRDateTo.Value = Now
            isShowAll = True
        End If
    End Sub
    'Autorefresh---Hendra
    Public Sub frmSDeliveryListShow(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub
End Class