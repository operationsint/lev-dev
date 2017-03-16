Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmBankReceiptPostList
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_BankAccountId As Integer
    Dim m_ExpIncAccountId As Integer
    Dim m_TaxAccountId As Integer
    Dim m_SuspenseAccountId As Integer
    Dim isShowAll As Boolean = False

    Private Sub frmBankReceiptPostList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_BankAccountId = GetSysAccount("bank")
        m_ExpIncAccountId = GetSysAccount("income")
        m_TaxAccountId = GetSysAccount("sales_tax")
        m_SuspenseAccountId = GetSysAccount("suspense")
        btnFilter_Click(sender, e)
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Cursor = Cursors.WaitCursor 'change pointer/cursor into hourglass
        If m_BankAccountId = 0 Or m_ExpIncAccountId = 0 Or m_TaxAccountId = 0 Or m_SuspenseAccountId = 0 Then
            MsgBox("Transaction cannot be posted. Please make sure you have defined the System account before posting.", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If
        If ListView1.CheckedItems.Count > 0 Then
            For i = 1 To ListView1.Items.Count
                If ListView1.Items(i - 1).Checked = True Then
                    cmd = New SqlCommand("usp_tr_bank_trans_rec_POST", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm1 As SqlParameter = cmd.Parameters.Add("@trans_type", SqlDbType.NVarChar)
                    prm1.Value = "BNREC"
                    Dim prm2 As SqlParameter = cmd.Parameters.Add("@bank_trans_no", SqlDbType.NVarChar)
                    prm2.Value = ListView1.Items(i - 1).SubItems.Item(0).Text
                    Dim prm11 As SqlParameter = cmd.Parameters.Add("@bank_account_id2", SqlDbType.Int)
                    prm11.Value = m_BankAccountId
                    Dim prm12 As SqlParameter = cmd.Parameters.Add("@expinc_account_id2", SqlDbType.Int)
                    prm12.Value = m_ExpIncAccountId
                    Dim prm13 As SqlParameter = cmd.Parameters.Add("@tax_account_id", SqlDbType.Int)
                    prm13.Value = m_TaxAccountId
                    Dim prm14 As SqlParameter = cmd.Parameters.Add("@suspense_account_id", SqlDbType.Int)
                    prm14.Value = m_SuspenseAccountId

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

    Private Sub txtPONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBankPaymentNo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub txtSName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBankName.KeyPress
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
            dtpBankPaymentDateFrom.Enabled = False
            dtpBankPaymentDateTo.Enabled = False
            'txtPONo.Text = ""
            'txtSName.Text = ""
            'cmbStatus.SelectedIndex = -1
            isShowAll = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            dtpBankPaymentDateFrom.Enabled = True
            dtpBankPaymentDateTo.Enabled = True
            dtpBankPaymentDateFrom.Value = Now
            dtpBankPaymentDateTo.Value = Now
            isShowAll = False
        End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Bank Payment No.", 120)
            .Columns.Add("dDate", "Date", 90)
            .Columns.Add("Bank Code", 120)
            .Columns.Add("Currency", 70)
            .Columns.Add("Total", 170, HorizontalAlignment.Right)
            .Columns.Add("Total Local", 170, HorizontalAlignment.Right)
            .Columns.Add("Posted Status", 90)
        End With

        cmd = New SqlCommand("usp_tr_bank_trans_POST_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@bank_trans_id", SqlDbType.Int)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@bank_trans_no", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtBankPaymentNo.Text = "", DBNull.Value, txtBankPaymentNo.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@bank_trans_date1", SqlDbType.SmallDateTime)
        prm3.Value = IIf(isShowAll = False, dtpBankPaymentDateFrom.Value.Date, DBNull.Value)
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@bank_trans_date2", SqlDbType.SmallDateTime)
        prm4.Value = IIf(isShowAll = False, dtpBankPaymentDateTo.Value.Date, DBNull.Value)
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@bank_trans_type", SqlDbType.NVarChar, 5)
        prm5.Value = "BNREC"
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@bank_code", SqlDbType.NVarChar, 50)
        prm6.Value = IIf(txtBankName.Text = "", DBNull.Value, txtBankName.Text)
        Dim prm7 As SqlParameter = cmd.Parameters.Add("@is_posted", SqlDbType.Bit)
        prm7.Value = 0

        cn.Open()
        cmd.CommandTimeout = CInt(GetSysInit("db_timeout"))
        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            'lvItem.SubItems.Add(myReader.GetString(0))
            lvItem.SubItems.Add(myReader.Item(2))
            lvItem.SubItems.Add(myReader.GetString(5))
            lvItem.SubItems.Add(myReader.GetString(7))
            lvItem.SubItems.Add(myReader.Item(12))
            lvItem.SubItems.Add(myReader.Item(15))
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

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        'If Not isDeletedRecord("usp_tr_pinvoice_SEL", "pinvoice_id", LeftSplitUF(ListView1.SelectedItems.Item(0).Tag), Me.Text) = False Then
        '    btnFilter_Click(sender, e)
        'Else
        With frmBankReceipt
            .BankTransId = 1
            .BankTransNo = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
            .MdiParent = frmMAIN
            .Show()
        End With
        'End If
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