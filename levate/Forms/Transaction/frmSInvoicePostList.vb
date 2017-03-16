Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmSInvoicePostList
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_RevenueAccountId As Integer
    Dim m_IncomeAccountId As Integer
    Dim m_TaxAccountId As Integer
    Dim m_ARAccountId As Integer
    Dim m_SuspenseAccountId As Integer
    Dim isShowAll As Boolean = False

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Cursor = Cursors.WaitCursor 'change pointer/cursor into hourglass
        If m_ARAccountId = 0 Or m_RevenueAccountId = 0 Or m_IncomeAccountId = 0 Or m_TaxAccountId = 0 Or m_SuspenseAccountId = 0 Then
            MsgBox("Transaction cannot be posted. Please make sure you have defined the System account before posting.", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If
        If ListView1.CheckedItems.Count > 0 Then
            For i = 1 To ListView1.Items.Count
                If ListView1.Items(i - 1).Checked = True Then
                    cmd = New SqlCommand("usp_tr_sinvoice_POST", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int, 255)
                    prm1.Value = LeftSplitUF(ListView1.Items(i - 1).Tag)
                    Dim prm2 As SqlParameter = cmd.Parameters.Add("@sinvoice_no", SqlDbType.NVarChar)
                    prm2.Value = ListView1.Items(i - 1).SubItems.Item(0).Text
                    'Dim prm3 As SqlParameter = cmd.Parameters.Add("@journal_no", SqlDbType.NVarChar)
                    'prm3.Value = GetSysNumber("journal_auto", Now.Date)

                    Dim prm11 As SqlParameter = cmd.Parameters.Add("@revenue_account_id", SqlDbType.Int)
                    prm11.Value = m_RevenueAccountId
                    Dim prm12 As SqlParameter = cmd.Parameters.Add("@income_account_id2", SqlDbType.Int)
                    prm12.Value = m_IncomeAccountId
                    Dim prm13 As SqlParameter = cmd.Parameters.Add("@tax_account_id", SqlDbType.Int)
                    prm13.Value = m_TaxAccountId
                    Dim prm14 As SqlParameter = cmd.Parameters.Add("@ar_account_id", SqlDbType.Int)
                    prm14.Value = m_ARAccountId
                    Dim prm15 As SqlParameter = cmd.Parameters.Add("@suspense_account_id", SqlDbType.Int)
                    prm15.Value = m_SuspenseAccountId

                    Dim prm21 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                    prm21.Value = My.Settings.UserName

                    cn.Open()
                    cmd.CommandTimeout = CInt(GetSysInit("db_timeout"))
                    cmd.ExecuteReader()
                    cn.Close()
                End If
            Next
            btnFilter_Click(sender, e)
        Else
            MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub frmPInvoicePostList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_ARAccountId = GetSysAccount("customer_ar")
        m_RevenueAccountId = GetSysAccount("sales_revenue")
        m_IncomeAccountId = GetSysAccount("income")
        m_TaxAccountId = GetSysAccount("sales_tax")
        m_SuspenseAccountId = GetSysAccount("suspense")
        btnFilter_Click(sender, e)
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        'lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1))
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

    Private Sub txtPONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSInvoiceNo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub txtSName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCName.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
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

    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            dtpSInvoiceDateFrom.Enabled = False
            dtpSInvoiceDateTo.Enabled = False
            'txtPONo.Text = ""
            'txtSName.Text = ""
            'cmbStatus.SelectedIndex = -1
            isShowAll = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            dtpSInvoiceDateFrom.Enabled = True
            dtpSInvoiceDateTo.Enabled = True
            dtpSInvoiceDateFrom.Value = Now
            dtpSInvoiceDateTo.Value = Now
            isShowAll = False
        End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Sales Invoice No.", 120)
            .Columns.Add("dDate", "Date", 90)
            .Columns.Add("c_id", 0)
            .Columns.Add("Customer Code", 90)
            .Columns.Add("Customer Name", 230)
            .Columns.Add("Local Total", 120, HorizontalAlignment.Right)
            .Columns.Add("sinvoice_status", 0)
            .Columns.Add("Status", 90)
        End With

        cmd = New SqlCommand("usp_tr_sinvoice_POST_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@sinvoice_no", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtSInvoiceNo.Text = "", DBNull.Value, txtSInvoiceNo.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@sinvoice_date1", SqlDbType.SmallDateTime)
        prm3.Value = IIf(isShowAll = False, dtpSInvoiceDateFrom.Value.Date, DBNull.Value)
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@sinvoice_date2", SqlDbType.SmallDateTime)
        prm4.Value = IIf(isShowAll = False, dtpSInvoiceDateTo.Value.Date, DBNull.Value)
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@c_name", SqlDbType.NVarChar, 50)
        prm5.Value = IIf(txtCName.Text = "", DBNull.Value, txtCName.Text)
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@is_return", SqlDbType.Bit)
        prm6.Value = 0
        Dim prm7 As SqlParameter = cmd.Parameters.Add("@is_posted", SqlDbType.Bit)
        prm7.Value = 0

        cn.Open()
        cmd.CommandTimeout = CInt(GetSysInit("db_timeout"))
        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            lvItem.SubItems.Add(myReader.Item(2))
            lvItem.SubItems.Add(myReader.GetInt32(3)) 'c_id
            lvItem.SubItems.Add(myReader.GetString(4)) 'c_code
            lvItem.SubItems.Add(myReader.GetString(5)) 'c_name
            lvItem.SubItems.Add(FormatNumber(myReader.Item(25))) 'local_total
            lvItem.SubItems.Add(myReader.GetString(26)) 'sinvoice_status
            lvItem.SubItems.Add(myReader.GetString(27)) 'sinvoice_status_val
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

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        If Not isDeletedRecord("usp_tr_sinvoice_SEL", "sinvoice_id", LeftSplitUF(ListView1.SelectedItems.Item(0).Tag), Me.Text) = False Then
            btnFilter_Click(sender, e)
        ElseIf Not Application.OpenForms().OfType(Of frmSInvoice).Any Then
            With frmSInvoice
                .SInvoiceId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                .MdiParent = frmMAIN
                .Show()
            End With
        End If
    End Sub

    Private Sub chbSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSelectAll.CheckedChanged
        If chbSelectAll.Checked = True Then
            With ListView1
                For i = 1 To .Items.Count
                    .Items.Item(i - 1).Checked = True
                Next
            End With
        Else
            With ListView1
                For i = 1 To .Items.Count
                    .Items.Item(i - 1).Checked = False
                Next
            End With
        End If
    End Sub
End Class
