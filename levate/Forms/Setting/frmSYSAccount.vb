Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmSYSAccount
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_AccountId As Integer
    Dim m_AccountType As String

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

    Private Sub frmSYSAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clear_lvw()
        clear_obj()
        lock_obj(True)

        If ListView1.Items.Count > 0 Then
            ListView1.Items.Item(0).Selected = True
            ListView1_Click(sender, e)
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        'If m_AccountId = 0 And btnAdd.Enabled = False Then lock_obj(True)
        With ListView1.SelectedItems.Item(0)
            txtSysAccountType.Text = .SubItems.Item(0).Text
            txtSYSAccountName.Text = .SubItems.Item(1).Text
            m_AccountId = .SubItems.Item(2).Text
            txtAccountCode.Text = .SubItems.Item(3).Text
        End With
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then clear_lvw()
    End Sub

    Private Sub cmbFilterBy_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        clear_obj()
        lock_obj(False)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
        If m_AccountId <> 0 Then txtSysAccountType.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo err_btnSave_Click

        If txtSysAccountType.Text = "" Or txtSYSAccountName.Text = "" Then
            MsgBox("Account Code, Account Name and Account Type are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtSysAccountType.Focus()
            Exit Sub
        End If

        cmd = New SqlCommand("usp_sys_account_UPD", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm2 As SqlParameter = cmd.Parameters.Add("@sys_account_type", SqlDbType.NVarChar, 50)
        prm2.Value = txtSysAccountType.Text
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@sys_account_name", SqlDbType.NVarChar, 50)
        prm3.Value = txtSYSAccountName.Text
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@sys_account_id", SqlDbType.Int)
        prm4.Value = m_AccountId

        cn.Open()
        cmd.ExecuteReader()
        cn.Close()

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
            .Columns.Add("Ledger Trx Code", 0)
            .Columns.Add("Ledger Trx Name", 150)
            .Columns.Add("account_id", 0)
            .Columns.Add("Account Code", 100)
        End With

        cmd = New SqlCommand("usp_sys_account_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sys_account_type", SqlDbType.NVarChar)
        prm1.Value = DBNull.Value

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            Dim lvw As ListViewItem
            lvw = ListView1.Items.Add(myReader.GetString(0))
            For i = 1 To 3
                If myReader.Item(i) Is System.DBNull.Value Then
                    lvw.SubItems.Add("")
                Else
                    lvw.SubItems.Add(myReader.Item(i))
                End If
            Next
            'lvw.Items.Add(lvItem)
        End While
        myReader.Close()
        cn.Close()
    End Sub

    Sub clear_obj()
        m_AccountId = 0
        txtSysAccountType.Text = ""
        txtSYSAccountName.Text = ""
        txtAccountCode.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        'txtSYSAccountName.ReadOnly = isLock
        btnAccount.Enabled = Not isLock
        btnEdit.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
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

    Private Sub btnAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccount.Click
        Dim NewFormDialog As New fdlAccount
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub
End Class