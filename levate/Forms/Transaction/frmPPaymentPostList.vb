Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmPPaymentPostList
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_BankAccountId As Integer
    Dim m_ExpenseAccountId As Integer
    Dim m_RealizedGainLossAccountId As Integer
    Dim m_APAccountId As Integer
    Dim m_SuspenseAccountId As Integer
    Dim m_AdvancePaymentId As Integer
    Dim isShowAll As Boolean = False

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Cursor = Cursors.WaitCursor 'change pointer/cursor into hourglass
        If m_BankAccountId = 0 Or m_RealizedGainLossAccountId = 0 Or m_APAccountId = 0 Or m_SuspenseAccountId = 0 Or m_AdvancePaymentId = 0 Then
            MsgBox("Transaction cannot be posted. Please make sure you have defined the System account before posting.", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If
        If ListView1.CheckedItems.Count > 0 Then
            For i = 1 To ListView1.Items.Count
                If ListView1.Items(i - 1).Checked = True Then
                    cmd = New SqlCommand("usp_tr_ppayment_POST", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppayment_id", SqlDbType.Int, 255)
                    prm1.Value = LeftSplitUF(ListView1.Items(i - 1).Tag)
                    Dim prm2 As SqlParameter = cmd.Parameters.Add("@ppayment_no", SqlDbType.NVarChar)
                    prm2.Value = ListView1.Items(i - 1).SubItems.Item(0).Text

                    Dim prm11 As SqlParameter = cmd.Parameters.Add("@bank_account_id2", SqlDbType.Int)
                    prm11.Value = m_BankAccountId
                    Dim prm12 As SqlParameter = cmd.Parameters.Add("@realized_gainloss_account_id", SqlDbType.Int)
                    prm12.Value = m_RealizedGainLossAccountId
                    Dim prm14 As SqlParameter = cmd.Parameters.Add("@ap_account_id", SqlDbType.Int)
                    prm14.Value = m_APAccountId
                    Dim prm15 As SqlParameter = cmd.Parameters.Add("@suspense_account_id", SqlDbType.Int)
                    prm15.Value = m_SuspenseAccountId

                    Dim prm21 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                    prm21.Value = My.Settings.UserName

                    Dim prm16 As SqlParameter = cmd.Parameters.Add("@advance_payment_account_id", SqlDbType.Int)
                    prm16.Value = m_AdvancePaymentId

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
        m_BankAccountId = GetSysAccount("bank")
        m_RealizedGainLossAccountId = GetSysAccount("forex_gain_loss")
        m_APAccountId = GetSysAccount("supplier_ap")
        m_SuspenseAccountId = GetSysAccount("suspense")
        m_AdvancePaymentId = GetSysAccount("advance_payment")
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

    Private Sub txtPONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAPNo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then btnFilter_Click(sender, e)
    End Sub

    Private Sub txtSName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSName.KeyPress
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
        'Dim sum As String
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            dtpAPDateFrom.Enabled = False
            dtpAPDateTo.Enabled = False
            'txtPONo.Text = ""
            'txtSName.Text = ""
            'cmbStatus.SelectedIndex = -1
            isShowAll = True
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            dtpAPDateFrom.Enabled = True
            dtpAPDateTo.Enabled = True
            dtpAPDateFrom.Value = Now
            dtpAPDateTo.Value = Now
            isShowAll = False
        End If
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Purchase Payment No.", 130)
            .Columns.Add("dDate", "Date", 90)
            .Columns.Add("s_id", 0)
            .Columns.Add("Supplier Code", 90)
            .Columns.Add("Supplier Name", 300)
            .Columns.Add("Local Total", 120, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("usp_tr_ppayment_POST_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppayment_no", SqlDbType.NVarChar, 50)
        prm1.Value = IIf(txtAPNo.Text = "", DBNull.Value, txtAPNo.Text)
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@ppayment_date1", SqlDbType.SmallDateTime)
        prm2.Value = IIf(isShowAll = False, dtpAPDateFrom.Value.Date, DBNull.Value)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@ppayment_date2", SqlDbType.SmallDateTime)
        prm3.Value = IIf(isShowAll = False, dtpAPDateTo.Value.Date, DBNull.Value)
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@s_name", SqlDbType.NVarChar, 50)
        prm4.Value = IIf(txtSName.Text = "", DBNull.Value, txtSName.Text)
        Dim prm7 As SqlParameter = cmd.Parameters.Add("@is_posted", SqlDbType.Bit)
        prm7.Value = 0

        cn.Open()
        cmd.CommandTimeout = CInt(GetSysInit("db_timeout"))
        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 5, 1)

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            lvItem.SubItems.Add(myReader.Item(2))
            lvItem.SubItems.Add(myReader.GetInt32(3)) 's_id
            lvItem.SubItems.Add(myReader.GetString(4)) 's_code
            lvItem.SubItems.Add(myReader.GetString(5)) 's_name
            lvItem.SubItems.Add(FormatNumber(myReader.Item(25))) 'local_ppayment_total_paid

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
