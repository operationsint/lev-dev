Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmExpInc
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_ExpIncId As Integer
    Dim m_AccountId As Integer
    Dim isAllowDelete As Boolean

    Public Property AccountId() As Integer
        Get
            Return m_AccountId
        End Get
        Set(ByVal Value As Integer)
            m_AccountId = Value
        End Set
    End Property

    Public Property AccountCode() As String
        Get
            Return txtAccountCode.Text
        End Get
        Set(ByVal Value As String)
            txtAccountCode.Text = Value
        End Set
    End Property

    Private Sub frmExpInc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isAllowDelete = canDelete(Me.Name)

        cmbItemType.Items.Add(New clsMyListStr("Expense", "E"))
        cmbItemType.Items.Add(New clsMyListStr("Income", "I"))

        clear_obj()
        'lock_obj(True)
        clear_lvw()
        btnCancel_Click(sender, e)
        'If ListView1.Items.Count > 0 Then
        '    ListView1.Items.Item(0).Selected = True
        '    ListView1_Click(sender, e)
        'End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        'If m_ExpIncId = 0 And btnAdd.Enabled = False Then lock_obj(True)
        With ListView1.SelectedItems.Item(0)
            'txtSKUID.Text = Strings.Mid(ListView1.SelectedItems(0).Tag, 2, Len(ListView1.SelectedItems(0).Tag) - 1)
            lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1)) + " of " + ListView1.Items.Count.ToString
            m_ExpIncId = LeftSplitUF(.Tag)

            Dim mList As clsMyListStr
            Dim i As Integer
            For i = 1 To cmbItemType.Items.Count
                mList = cmbItemType.Items(i - 1)
                If .SubItems.Item(2).Text = mList.ItemData Then
                    cmbItemType.SelectedIndex = i - 1
                    Exit For
                End If
            Next

            txtSKUCode.Text = .SubItems.Item(0).Text
            txtSKUName.Text = .SubItems.Item(1).Text
            m_AccountId = CInt(.SubItems.Item(3).Text)
            txtAccountCode.Text = .SubItems.Item(4).Text
        End With
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then clear_lvw()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        clear_obj()
        lock_obj(False)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
        If m_ExpIncId <> 0 Then txtSKUCode.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_ExpIncId = 0 And ListView1.Items.Count > 0 Then
            ListView1.Items.Item(0).Selected = True
            ListView1_Click(sender, e)
        End If
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo err_btnSave_Click

        If txtSKUCode.Text = "" Or txtSKUName.Text = "" Or cmbItemType.SelectedIndex = -1 Then
            MsgBox("Code, Name and Type are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtSKUCode.Focus()
            Exit Sub
        End If

        cmd = New SqlCommand(IIf(m_ExpIncId = 0, "usp_mt_expinc_INS", "usp_mt_expinc_UPD"), cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm2 As SqlParameter = cmd.Parameters.Add("@expinc_type", SqlDbType.NVarChar)
        prm2.Value = cmbItemType.Items(cmbItemType.SelectedIndex).ItemData
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@expinc_code", SqlDbType.NVarChar, 50)
        prm3.Value = txtSKUCode.Text
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@expinc_name", SqlDbType.NVarChar, 255)
        prm4.Value = txtSKUName.Text
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@account_id", SqlDbType.Int)
        prm5.Value = m_AccountId
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
        prm6.Value = My.Settings.UserName
        Dim prm1 As SqlParameter = cmd.Parameters.Add("@expinc_id", SqlDbType.Int, 255)
        prm1.Value = m_ExpIncId

        If m_ExpIncId = 0 Then
            prm1.Direction = ParameterDirection.Output
            cn.Open()
            cmd.ExecuteReader()
            m_ExpIncId = prm1.Value
            cn.Close()
        Else
            prm1.Value = m_ExpIncId
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            'clear_lvw()
        End If
        clear_lvw()
        lock_obj(True)

exit_btnSave_Click:
        If ConnectionState.Open = 1 Then cn.Close()
        Exit Sub

err_btnSave_Click:
        If Err.Number = 5 Then
            MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
        Else
            MsgBox(Err.Description)
        End If
        Resume exit_btnSave_Click
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Code", 90)
            .Columns.Add("Description", 300)
            .Columns.Add("Type", 90)
            .Columns.Add("account_id", 0)
            .Columns.Add("Account Code", 90)
        End With

        cmd = New SqlCommand("usp_mt_expinc_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@expinc_id", SqlDbType.Int, 50)
        prm1.Value = 0

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 5, 1)
        myReader.Close()
        cn.Close()
    End Sub

    Sub clear_obj()
        m_ExpIncId = 0
        m_AccountId = 0
        txtSKUCode.Text = ""
        txtSKUName.Text = ""
        cmbItemType.SelectedIndex = 0
        txtAccountCode.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtSKUCode.ReadOnly = isLock
        txtSKUName.ReadOnly = isLock
        cmbItemType.Enabled = Not isLock
        btnAccount.Enabled = Not isLock
        If m_ExpIncId = 0 Then
            btnDelete.Enabled = isLock
        Else
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
    End Sub

    Private Sub cmbSKUCatID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim mList As clsMyList
        'mList = cmbSKUCatID.Items(cmbSKUCatID.SelectedIndex)
        'In the following statement, you can either use mList.ToString or
        'mList.Name. They both return the Name property.
        'Label1.Text = mList.ItemData & "  " & mList.Name
        'Alternately, you can use the following syntax.
        'Label1.Text = ComboBox1.Items(ComboBox1.SelectedIndex).ItemData _
        ' & "  " & ComboBox1.Items(ComboBox1.SelectedIndex).ToString
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_mt_expinc_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@expinc_id", SqlDbType.Int, 50)
            prm1.Value = m_ExpIncId
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

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        m_AccountId = 0
        txtAccountCode.Text = ""
    End Sub

    Private Sub btnAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccount.Click
        Dim NewFormDialog As New fdlAccount
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub
End Class