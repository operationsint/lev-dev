Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmBankReceiptList
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim isShowAll As Boolean = False
    Dim m_PostedStatusArr(1, 1) As String

    Private Sub frmBankReceiptList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        chbDate.Checked = False
        chbDate_CheckedChanged(sender, e)
        btnFilter_Click(sender, e)
    End Sub
    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Bank Receipt No.", 120)
            .Columns.Add("dDate", "Date", 90)
            .Columns.Add("Ref No", 120)
            .Columns.Add("Bank Code", 120)
            .Columns.Add("Currency", 70)
            .Columns.Add("Total", 170, HorizontalAlignment.Right)
            .Columns.Add("Posted Status", 90)
        End With

        cmd = New SqlCommand("usp_tr_bank_trans_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@bank_trans_id", SqlDbType.Int)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@bank_trans_no", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtBankReceiptNo.Text = "", DBNull.Value, txtBankReceiptNo.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@bank_trans_date1", SqlDbType.SmallDateTime)
        prm3.Value = IIf(isShowAll = False, dtpStockAdjDateFrom.Value.Date, DBNull.Value)
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@bank_trans_date2", SqlDbType.SmallDateTime)
        prm4.Value = IIf(isShowAll = False, dtpStockAdjDateTo.Value.Date, DBNull.Value)
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@bank_trans_type", SqlDbType.NVarChar, 5)
        prm5.Value = "BNREC"
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@bank_code", SqlDbType.NVarChar, 50)
        prm6.Value = IIf(txtBankCode.Text = "", DBNull.Value, txtBankCode.Text)
        Dim prm7 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
        prm7.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0)))
            lvItem.Tag = intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            'lvItem.SubItems.Add(myReader.GetString(0))
            lvItem.SubItems.Add(myReader.Item(2))
            If Not myReader.IsDBNull(myReader.GetOrdinal("ref_no")) Then
                lvItem.SubItems.Add(myReader.GetString(4))
            Else
                lvItem.SubItems.Add("")
            End If
            lvItem.SubItems.Add(myReader.GetString(5))
            lvItem.SubItems.Add(myReader.GetString(7))
            lvItem.SubItems.Add(myReader.Item(12))
            If myReader.GetBoolean(22) = True Then 'is_posted
                lvItem.SubItems.Add("Posted")
            Else
                lvItem.SubItems.Add("Not Posted")
            End If

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
        frmBankReceipt.BankTransId = 0
        frmBankReceipt.MdiParent = frmMAIN
        frmBankReceipt.Show()
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        lblCurrentRecord.Text = "Selected record: " + ListView1.SelectedItems.Item(0).SubItems.Item(0).Text + "of" + ListView1.Items.Count.ToString
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
        'If Not isDeletedRecord("usp_tr_stock_adj_SEL", "stock_adj_id", LeftSplitUF(ListView1.SelectedItems.Item(0).Tag), Me.Text) = False Then
        '    btnFilter_Click(sender, e)
        'Else
        With frmBankReceipt
            .BankTransId = 1
            .BankTransNo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
            .MdiParent = frmMAIN
            .Show()
        End With
        'End If
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
        '    dtpStockAdjDateFrom.Enabled = True
        '    dtpStockAdjDateTo.Enabled = True
        '    dtpStockAdjDateFrom.Value = Now
        '    dtpStockAdjDateTo.Value = Now
        '    isShowAll = False
        'End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If RadioButton1.Checked = True Then
        '    dtpStockAdjDateFrom.Enabled = False
        '    dtpStockAdjDateTo.Enabled = False
        '    isShowAll = True
        'End If
    End Sub

    Private Sub txtBankPaymentNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBankReceiptNo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub txtBankCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBankCode.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub txtRefNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRefNo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        chbDate.Checked = False
        txtBankCode.Text = ""
        txtBankReceiptNo.Text = ""
        txtRefNo.Text = ""
    End Sub

    Private Sub chbDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbDate.CheckedChanged
        If chbDate.Checked = True Then
            dtpStockAdjDateFrom.Enabled = True
            dtpStockAdjDateTo.Enabled = True
            isShowAll = False
        Else
            dtpStockAdjDateFrom.Enabled = False
            dtpStockAdjDateTo.Enabled = False
            dtpStockAdjDateFrom.Value = Now
            dtpStockAdjDateTo.Value = Now
            isShowAll = True
        End If
    End Sub
    'Autorefresh---Hendra
    Public Sub frmBankReceiptListShow(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub
End Class