Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmBank
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_Bank_Id As Integer
    Dim m_CurrId As Integer
    Dim m_Bank_Account_Id As Integer
    Dim isAllowDelete As Boolean

    Private Sub frmBank_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        isAllowDelete = canDelete(Me.Name)

        getBankAccountId()

        clear_obj()
        lock_obj(True)

        cmbFilterBy.Items.Add("<All>")
        cmbFilterBy.Items.Add("Bank Code")
        cmbFilterBy.Items.Add("Bank Name")
        cmbFilterBy.SelectedIndex = 0

        'If ListView1.Items.Count > 0 Then
        '    ListView1.Items.Item(0).Selected = True
        '    ListView1_Click(sender, e)
        'End If
    End Sub
    Public Property CurrId() As Integer
        Get
            Return m_CurrId
        End Get
        Set(ByVal Value As Integer)
            m_CurrId = Value
        End Set
    End Property

    Public Property CurrCode() As String
        Get
            Return txtBankCurrCode.Text
        End Get
        Set(ByVal Value As String)
            txtBankCurrCode.Text = Value
        End Set
    End Property

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        If m_Bank_Id = 0 And btnAdd.Enabled = False Then lock_obj(True)
        With ListView1.SelectedItems.Item(0)
            'txtCID.Text = Strings.Mid(ListView1.SelectedItems(0).Tag, 2, Len(ListView1.SelectedItems(0).Tag) - 1)
            lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1)) + " of " + ListView1.Items.Count.ToString
            m_Bank_Id = LeftSplitUF(.Tag)
            txtBankCode.Text = .SubItems.Item(0).Text
            txtBankName.Text = .SubItems.Item(1).Text
            txtBankAccountNo.Text = .SubItems.Item(2).Text
            m_CurrId = .SubItems.Item(3).Text
            txtBankCurrCode.Text = .SubItems.Item(4).Text
            txtBankRemarks.Text = .SubItems.Item(5).Text
            txtBankInfo1.Text = .SubItems.Item(6).Text
            txtBankInfo2.Text = .SubItems.Item(7).Text
            txtBankInfo3.Text = .SubItems.Item(8).Text
            txtBankBalance.Text = FormatNumber(.SubItems.Item(9).Text)
            txtBankLocalBalance.Text = FormatNumber(.SubItems.Item(10).Text)
            '20160821 gl account code
            txtAccountCode.Text = .SubItems.Item(13).Text

            clear_lvw2()
        End With
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then clear_lvw()
    End Sub

    Private Sub cmbFilterBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFilterBy.SelectedIndexChanged
        If cmbFilterBy.SelectedItem.ToString = "<All>" Then
            txtFilter.Text = ""
            If m_Bank_Id <> 0 Then clear_obj()
            clear_lvw()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        clear_obj()
        lock_obj(False)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
        If m_Bank_Id <> 0 Then txtBankCode.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo err_btnSave_Click

        If txtBankCode.Text = "" Or txtBankName.Text = "" Or txtBankCurrCode.Text = "" Then
            MsgBox("Please enter the fields marked with * before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtBankCode.Focus()
            Exit Sub
        End If

        cmd = New SqlCommand(IIf(m_Bank_Id = 0, "sp_mt_bank_INS", "sp_mt_bank_UPD"), cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm2 As SqlParameter = cmd.Parameters.Add("@bank_code", SqlDbType.NVarChar, 50)
        prm2.Value = txtBankCode.Text
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@bank_name", SqlDbType.NVarChar, 255)
        prm3.Value = txtBankName.Text
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@bank_account_no", SqlDbType.NVarChar, 255)
        prm4.Value = IIf(txtBankAccountNo.Text = "", DBNull.Value, txtBankAccountNo.Text)
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@bank_curr_id", SqlDbType.Int)
        prm5.Value = m_CurrId
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@bank_remarks", SqlDbType.NVarChar, 255)
        prm6.Value = IIf(txtBankRemarks.Text = "", DBNull.Value, txtBankRemarks.Text)
        Dim prm7 As SqlParameter = cmd.Parameters.Add("@bank_info1", SqlDbType.NVarChar, 255)
        prm7.Value = IIf(txtBankInfo1.Text = "", DBNull.Value, txtBankInfo1.Text)
        Dim prm8 As SqlParameter = cmd.Parameters.Add("@bank_info2", SqlDbType.NVarChar, 255)
        prm8.Value = IIf(txtBankInfo2.Text = "", DBNull.Value, txtBankInfo2.Text)
        Dim prm9 As SqlParameter = cmd.Parameters.Add("@bank_info3", SqlDbType.NVarChar, 255)
        prm9.Value = IIf(txtBankInfo3.Text = "", DBNull.Value, txtBankInfo3.Text)
        Dim prm11 As SqlParameter = cmd.Parameters.Add("@bank_account_id", SqlDbType.Int)
        prm11.Value = m_Bank_Account_Id
        Dim prm10 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
        prm10.Value = My.Settings.UserName

        '20160821 gl account code
        Dim prm12 As SqlParameter = cmd.Parameters.Add("@account_code", SqlDbType.NVarChar, 50)
        prm12.Value = txtAccountCode.Text

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@bank_id", SqlDbType.Int, 255)
        prm1.Value = m_Bank_Id

        If m_Bank_Id = 0 Then
            prm1.Direction = ParameterDirection.Output
            cn.Open()
            cmd.ExecuteReader()
            m_Bank_Id = prm1.Value
            cn.Close()
        Else
            prm1.Value = m_Bank_Id
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
        End If
        clear_lvw()
        lock_obj(True)

exit_btnSave_Click:
        If ConnectionState.Open = 1 Then cn.Close()
        Exit Sub

err_btnSave_Click:
        'If Err.Number = 5 Then
        '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
        'Else
        MsgBox(Err.Description)
        'End If
        Resume exit_btnSave_Click
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Bank Code", 150)
            .Columns.Add("Bank Name", 200)
            .Columns.Add("Bank Account No", 200)
            .Columns.Add("curr_id", 0)
            .Columns.Add("Currency", 100)
            .Columns.Add("Bank Remarks", 0)
            .Columns.Add("Bank Info1", 0)
            .Columns.Add("Bank Info2", 0)
            .Columns.Add("Bank Info3", 0)
            .Columns.Add("balance", 0)
            .Columns.Add("local_balance", 0)
            .Columns.Add("base_currency", 0)
            .Columns.Add("rates", 0)
            .Columns.Add("account_code", 0)
        End With

        cmd = New SqlCommand("sp_mt_bank_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@bank_id", SqlDbType.Int, 255)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@bank_code", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(cmbFilterBy.Text = "Bank Code", txtFilter.Text, DBNull.Value)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@bank_name", SqlDbType.NVarChar, 50)
        prm3.Value = IIf(cmbFilterBy.Text = "Bank Name", txtFilter.Text, DBNull.Value)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 14, 1)
        myReader.Close()
        cn.Close()
    End Sub

    Sub clear_lvw2()
        With ListView2
            .Clear()
            .View = View.Details
            .Columns.Add("period_id", 0)
            .Columns.Add("Period Name", 120)
            .Columns.Add("Beginning Balance", 120, HorizontalAlignment.Right)
            .Columns.Add("Total Trans", 120, HorizontalAlignment.Right)
            .Columns.Add("Ending Balance", 120, HorizontalAlignment.Right)
            .Columns.Add("Base Beginning Balance", 120, HorizontalAlignment.Right)
            .Columns.Add("Base Total Trans", 120, HorizontalAlignment.Right)
            .Columns.Add("Base Ending Balance", 120, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("sp_mt_bank_balance_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@bank_id", SqlDbType.Int, 255)
        prm1.Value = m_Bank_Id

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView2, 6, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1))) 'period_id
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow ''bank_balance_id
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            lvItem.SubItems.Add(myReader.Item(2)) 'period_name
            lvItem.SubItems.Add(FormatNumber(myReader.Item(3))) 'bal_begin
            lvItem.SubItems.Add(FormatNumber(myReader.Item(4))) 'total_trans
            lvItem.SubItems.Add(FormatNumber(myReader.Item(5))) 'bal_ending
            lvItem.SubItems.Add(FormatNumber(myReader.Item(6))) 'base_bal_ending
            lvItem.SubItems.Add(FormatNumber(myReader.Item(7))) 'base_total_trans
            lvItem.SubItems.Add(FormatNumber(myReader.Item(8))) 'base_bal_ending
            If intCurrRow Mod 2 = 0 Then
                lvItem.BackColor = Color.Lavender
            Else
                lvItem.BackColor = Color.White
            End If
            lvItem.UseItemStyleForSubItems = True

            ListView2.Items.Add(lvItem)
            intCurrRow += 1
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Sub clear_obj()
        m_Bank_Id = 0
        m_CurrId = 0
        txtBankCode.Text = ""
        txtBankName.Text = ""
        txtBankAccountNo.Text = ""
        txtBankRemarks.Text = ""
        txtBankInfo1.Text = ""
        txtBankInfo2.Text = ""
        txtBankInfo3.Text = ""
        txtBankCurrCode.Text = ""
        txtBankLocalBalance.Text = ""
        txtBankBalance.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtBankCode.ReadOnly = isLock
        txtBankName.ReadOnly = isLock
        txtBankAccountNo.ReadOnly = isLock
        txtBankRemarks.ReadOnly = isLock
        txtBankInfo1.ReadOnly = isLock
        txtBankInfo2.ReadOnly = isLock
        txtBankInfo3.ReadOnly = isLock

        btnCurrency.Enabled = Not isLock
        If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        If m_Bank_Id <> 0 Then
            btnCurrency.Enabled = False
        End If

        btnAccount.Enabled = Not isLock

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("sp_mt_bank_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@bank_id", SqlDbType.Int, 255)
            prm1.Value = m_Bank_Id
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm2.Value = My.Settings.UserName
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int)
            prm3.Direction = ParameterDirection.Output
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            If prm3.Value = 1 Then
                MsgBox("You can't delete this record because it's already used in transaction.", vbCritical, Me.Text)
            Else
                clear_lvw()
                clear_obj()
            End If
            lock_obj(True)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
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

    Private Sub btnCurrency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCurrency.Click
        Dim NewFormDialog As New fdlCurrency
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnCurrency_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnCurrency.KeyPress
        Dim NewFormDialog As New fdlCurrency
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Sub getBankAccountId() 'Temporary fix for get bank account id from ledger account setting - hendra
        cmd = New SqlCommand("select sys_account_id from sys_account where sys_account_type = 'bank' ", cn)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            m_Bank_Account_Id = myReader.GetInt32(0)
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Private Sub btnAccount_Click(sender As System.Object, e As System.EventArgs) Handles btnAccount.Click
        Dim NewFormDialog As New fdlAccount
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub
End Class