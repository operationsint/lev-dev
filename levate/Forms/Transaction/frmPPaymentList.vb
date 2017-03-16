Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmPPaymentList
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
            .Columns.Add("Purchase Payment No.", 130)
            .Columns.Add("dDate", "Date", 90)
            .Columns.Add("s_id", 0)
            .Columns.Add("Supplier Code", 90)
            .Columns.Add("Supplier Name", 300)
            .Columns.Add("Posted Status", 90)
        End With

        cmd = New SqlCommand("usp_tr_ppayment_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppayment_no", SqlDbType.NVarChar, 50)
        prm1.Value = IIf(txtAPNo.Text = "", DBNull.Value, txtAPNo.Text)
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@ppayment_date1", SqlDbType.SmallDateTime)
        prm2.Value = IIf(isShowAll = False, dtpAPDateFrom.Value.Date, DBNull.Value)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@ppayment_date2", SqlDbType.SmallDateTime)
        prm3.Value = IIf(isShowAll = False, dtpAPDateTo.Value.Date, DBNull.Value)
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@s_name", SqlDbType.NVarChar, 50)
        prm4.Value = IIf(txtSName.Text = "", DBNull.Value, txtSName.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 5, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            lvItem.SubItems.Add(myReader.Item(2))
            lvItem.SubItems.Add(myReader.GetInt32(3))
            lvItem.SubItems.Add(myReader.GetString(4))
            lvItem.SubItems.Add(myReader.GetString(5))
            lvItem.SubItems.Add(IIf(myReader.GetBoolean(29) = m_PostedStatusArr(0, 0), m_PostedStatusArr(0, 1), m_PostedStatusArr(1, 1))) 'is_posted
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
        With frmPPayment
            .PPaymentId = 0
            .MdiParent = frmMAIN
            .Show()
        End With
    End Sub

    Private Sub frmPPaymentList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Add item is_posted
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "is_posted"

        cn.Open()
        Dim myReader = cmd.ExecuteReader

        Dim i As Integer
        i = 0
        While myReader.Read
            m_PostedStatusArr(i, 0) = myReader.GetString(0)
            m_PostedStatusArr(i, 1) = myReader.GetString(1)
            i += 1
        End While

        myReader.Close()
        cn.Close()

        '20160626 enable date filter onload
        chbDate.Checked = True
        dtpAPDateFrom.Value = Today.AddDays(-GetListDateFilterDays())
        dtpAPDateTo.Value = Today

        chbDate_CheckedChanged(sender, e)

        btnFilter_Click(sender, e)
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
        If Not isDeletedRecord("usp_tr_ppayment_SEL", "ppayment_id", LeftSplitUF(ListView1.SelectedItems.Item(0).Tag), Me.Text) = False Then
            btnFilter_Click(sender, e)
        ElseIf Not Application.OpenForms().OfType(Of frmPPayment).Any Then
            With frmPPayment
                .PPaymentId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                .MdiParent = frmMAIN
                .Show()
            End With
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub txtPONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAPNo.KeyPress
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

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If RadioButton2.Checked = True Then
        '    dtpAPDateFrom.Enabled = True
        '    dtpAPDateTo.Enabled = True
        '    dtpAPDateFrom.Value = Now
        '    dtpAPDateTo.Value = Now
        '    isShowAll = False
        'End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If RadioButton1.Checked = True Then
        '    dtpAPDateFrom.Enabled = False
        '    dtpAPDateTo.Enabled = False
        '    isShowAll = True
        'End If
    End Sub

    Private Sub chbDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbDate.CheckedChanged
        If chbDate.Checked = True Then
            dtpAPDateFrom.Enabled = True
            dtpAPDateTo.Enabled = True
            isShowAll = False
        Else
            dtpAPDateFrom.Enabled = False
            dtpAPDateTo.Enabled = False
            dtpAPDateFrom.Value = Today.AddDays(-GetListDateFilterDays())
            dtpAPDateTo.Value = Now
            isShowAll = True
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        chbDate.Checked = False
        txtAPNo.Text = ""
        txtSName.Text = ""
    End Sub

    'Autorefresh---Hendra
    Public Sub frmPPaymentListShow(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub
End Class