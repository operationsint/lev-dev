Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmAccount
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cn1 As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_AccountId As Integer
    Dim m_AccountType As String
    Dim m_AcountSubCat As String
    Dim m_CurrId As Integer
    Dim isAllowDelete As Boolean

    Private Sub frmAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isAllowDelete = canDelete(Me.Name)

        DefineComboItem()
        DefineComboItemSubCategory("")

        clear_obj()

        cmbFilterBy.Items.Add("<All>")
        cmbFilterBy.Items.Add("Account Code")
        cmbFilterBy.Items.Add("Account Name")
        cmbFilterBy.SelectedIndex = 0

        'cmd = New SqlCommand("usp_mt_account_category_SEL", cn)
        'cmd.CommandType = CommandType.StoredProcedure

        'cn.Open()
        'Dim myReader As SqlDataReader = cmd.ExecuteReader

        'Do While myReader.Read
        '    cmbAccountType.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        'Loop
        'myReader.Close()
        'cn.Close()

        'If ListView1.Items.Count > 0 Then
        '    ListView1.Items.Item(0).Selected = True
        '    ListView1_Click(sender, e)
        'End If

        'lock_obj(True)
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        'If m_AccountId = 0 And btnAdd.Enabled = False Then lock_obj(True)
        With ListView1.SelectedItems.Item(0)
            'txtCID.Text = Strings.Mid(ListView1.SelectedItems(0).Tag, 2, Len(ListView1.SelectedItems(0).Tag) - 1)
            lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1)) + " of " + ListView1.Items.Count.ToString
            m_AccountId = LeftSplitUF(.Tag)
            m_AccountType = .SubItems.Item(2).Text
            m_AcountSubCat = .SubItems.Item(5).Text

            Dim mList As clsMyListStr
            Dim i As Integer
            For i = 1 To cmbAccountCategory.Items.Count
                mList = cmbAccountCategory.Items(i - 1)
                If m_AccountType = mList.ItemData Then
                    cmbAccountCategory.SelectedIndex = i - 1
                    Exit For
                End If
            Next

            Dim mListsubcat As clsMyListStr
            Dim j As Integer
            For j = 1 To cmbAccountSubCategory.Items.Count
                mListsubcat = cmbAccountSubCategory.Items(j - 1)
                If m_AcountSubCat = mListsubcat.ItemData Then
                    cmbAccountSubCategory.SelectedIndex = j - 1
                    Exit For
                End If
            Next

            mtbAccountCode.Text = .SubItems.Item(0).Text
            txtAccountName.Text = .SubItems.Item(1).Text

            txtAccountBalance.Text = FormatNumber(.SubItems.Item(4).Text)

            clear_lvw2()
        End With
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then clear_lvw()
    End Sub

    Private Sub cmbFilterBy_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbFilterBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFilterBy.SelectedIndexChanged
        If cmbFilterBy.SelectedItem.ToString = "<All>" Then
            txtFilter.Text = ""
            If m_AccountId <> 0 Then clear_obj()
            clear_lvw()
        End If
        btnCancel_Click(sender, e)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        clear_obj()
        lock_obj(False)
        clear_lvw2()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
        If m_AccountId <> 0 Then mtbAccountCode.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_AccountId = 0 And ListView1.Items.Count > 0 Then
            ListView1.Items.Item(0).Selected = True
            ListView1_Click(sender, e)
        End If
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo err_btnSave_Click

        If mtbAccountCode.Text = "" Or txtAccountName.Text = "" Or cmbAccountCategory.Text = "" Or cmbAccountSubCategory.Text = "" Then
            MsgBox("Account Code, Account Name, Account Category, and Account Sub-Category are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            mtbAccountCode.Focus()
            Exit Sub
        End If

        cmd = New SqlCommand(IIf(m_AccountId = 0, "usp_mt_account_INS", "usp_mt_account_UPD"), cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm2 As SqlParameter = cmd.Parameters.Add("@account_code", SqlDbType.NVarChar, 50)
        prm2.Value = mtbAccountCode.Text
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@account_name", SqlDbType.NVarChar, 255)
        prm3.Value = txtAccountName.Text
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@account_category_id", SqlDbType.NVarChar, 50)
        prm4.Value = cmbAccountCategory.Items(cmbAccountCategory.SelectedIndex).ItemData

        Dim prm18 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
        prm18.Value = My.Settings.UserName
        Dim prm1 As SqlParameter = cmd.Parameters.Add("@account_id", SqlDbType.Int)

        Dim prm19 As SqlParameter = cmd.Parameters.Add("@account_sub_category_id", SqlDbType.NVarChar, 50)
        prm19.Value = cmbAccountSubCategory.Items(cmbAccountSubCategory.SelectedIndex).ItemData

        If m_AccountId = 0 Then
            prm1.Direction = ParameterDirection.Output
            cn.Open()
            cmd.ExecuteReader()
            m_AccountId = prm1.Value
            cn.Close()
        Else
            prm1.Value = m_AccountId
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
        'DefineComboItem()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Account Code", 90)
            .Columns.Add("Account Name", 150)
            .Columns.Add("account_type_id", 0)
            .Columns.Add("Account Category", 100)
            .Columns.Add("account_balance", 0)
            .Columns.Add("sub_id", 0)
            .Columns.Add("Sub Account Name", 250)
        End With

        cmd = New SqlCommand("usp_mt_account_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@account_id", SqlDbType.Int)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@account_code", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(cmbFilterBy.Text = "Account Code", txtFilter.Text, DBNull.Value)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@account_name", SqlDbType.NVarChar, 50)
        prm3.Value = IIf(cmbFilterBy.Text = "Account Name", txtFilter.Text, DBNull.Value)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 7, 1)
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
            .Columns.Add("Total Trans DB", 120, HorizontalAlignment.Right)
            .Columns.Add("Total Trans CR", 120, HorizontalAlignment.Right)
            .Columns.Add("Ending Balance", 120, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("usp_mt_account_balance_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@account_id", SqlDbType.Int)
        prm1.Value = m_AccountId

        cn.Open()
        cmd.CommandTimeout = CInt(GetSysInit("db_timeout"))
        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView2, 6, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1))) 'period_id
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'balance_id
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            lvItem.SubItems.Add(myReader.Item(2)) 'period_name
            lvItem.SubItems.Add(FormatNumber(myReader.Item(3))) 'bal_begin
            lvItem.SubItems.Add(FormatNumber(myReader.Item(4))) 'total_db
            lvItem.SubItems.Add(FormatNumber(myReader.Item(5))) 'total_cr
            lvItem.SubItems.Add(FormatNumber(myReader.Item(6))) 'bal_begin

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
        m_AccountId = 0
        m_CurrId = 0
        mtbAccountCode.Text = ""
        txtAccountName.Text = ""

        txtAccountBalance.Text = ""

        'cmbAccountCategory.Text = ""
        cmbAccountCategory.SelectedIndex = 0

        'cmbAccountSubCategory.Text = ""
        cmbAccountSubCategory.SelectedIndex = 0
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        mtbAccountCode.ReadOnly = isLock
        txtAccountName.ReadOnly = isLock
        cmbAccountCategory.Enabled = Not isLock
        cmbAccountSubCategory.Enabled = Not isLock
        'If m_AccountId > 0 Then btnCurrency.Enabled = False Else btnCurrency.Enabled = Not isLock
        If m_AccountId = 0 Then
            btnDelete.Enabled = isLock
        Else
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_mt_account_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@account_id", SqlDbType.Int, 255)
            prm1.Value = m_AccountId
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

    Private Sub txtCPaymentTerm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim key As Integer = Asc(e.KeyChar)
        If Not ((key >= 48 And key <= 57) Or key = 8) Then
            e.Handled = True
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

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Sub DefineComboItem()
        cmbAccountCategory.Items.Clear()
        cmd = New SqlCommand("usp_mt_account_category_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            cmbAccountCategory.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While

        myReader.Close()
        cn.Close()

    End Sub

    Sub DefineComboItemSubCategory(ByVal account_category_id As String)
        cmbAccountSubCategory.Items.Clear()
        cmd = New SqlCommand("usp_mt_account_sub_category_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure
        Dim prm1 As SqlParameter = cmd.Parameters.Add("@account_category_id", SqlDbType.NVarChar, 50)
        prm1.Value = IIf(account_category_id = "", DBNull.Value, account_category_id)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            cmbAccountSubCategory.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetInt32(0)))
        End While

        myReader.Close()
        cn.Close()
    End Sub

    'Private Sub cmbAccountCategory_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAccountCategory.LostFocus
    '    DefineComboItemSubCategory(cmbAccountCategory.Items(cmbAccountCategory.SelectedIndex).ItemData)
    'End Sub

    Private Sub cmbAccountCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAccountCategory.SelectedIndexChanged
        DefineComboItemSubCategory(cmbAccountCategory.Items(cmbAccountCategory.SelectedIndex).ItemData)
    End Sub
End Class