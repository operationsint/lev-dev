Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmFixedAssetCat
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_fixed_asset_cat_id As Integer
    Dim isAllowDelete As Boolean

    Private Sub frmFixedAssetCat_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        isAllowDelete = canDelete(Me.Name)

        clear_obj()
        lock_obj(True)
        clear_lvw()
        'btnCancel_Click(sender, e)
        If ListView1.Items.Count > 0 Then
            ListView1.Items.Item(0).Selected = True
            ListView1_Click(sender, e)
        End If
    End Sub

    Public Property AccumulateAccountCode() As String
        Get
            Return txtAccumulateAccount.Text
        End Get
        Set(ByVal Value As String)
            txtAccumulateAccount.Text = Value
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

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        'If m_fixed_asset_cat_id = 0 And btnAdd.Enabled = False Then lock_obj(True)
        With ListView1.SelectedItems.Item(0)
            lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1)) + " of " + ListView1.Items.Count.ToString
            m_fixed_asset_cat_id = LeftSplitUF(.Tag)
            txtFixedAssetCatCode.Text = .SubItems.Item(0).Text
            txtFixedAssetCatName.Text = .SubItems.Item(1).Text
            'm_AccountId = CInt(.SubItems.Item(2).Text)
            txtAccountCode.Text = .SubItems.Item(2).Text
            txtAccumulateAccount.Text = .SubItems.Item(3).Text
        End With
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        clear_obj()
        lock_obj(False)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_fixed_asset_cat_id = 0 Then
            clear_obj()
        End If
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtFixedAssetCatCode.Text = "" Then
            MsgBox("Please fill fixed asset category code!", vbCritical, Me.Text)
            txtFixedAssetCatCode.Focus()
            Exit Sub
        End If

        If txtAccountCode.Text = "" Then
            MsgBox("Please fill depreciation account code!", vbCritical, Me.Text)
            btnAccount.Focus()
            Exit Sub
        End If

        If txtAccumulateAccount.Text = "" Then
            MsgBox("Please fill accumulate depreciation account code!", vbCritical, Me.Text)
            btnAccumulateAccount.Focus()
            Exit Sub
        End If

        Try
            cmd = New SqlCommand(IIf(m_fixed_asset_cat_id = 0, "sp_mt_fixed_asset_cat_INS", "sp_mt_fixed_asset_cat_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@fixed_asset_cat_code", SqlDbType.NVarChar, 50)
            prm2.Value = txtFixedAssetCatCode.Text
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@fixed_asset_cat_name", SqlDbType.NVarChar, 50)
            prm3.Value = IIf(txtFixedAssetCatName.Text = "", DBNull.Value, txtFixedAssetCatName.Text)
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@account_id", SqlDbType.NVarChar, 50)
            prm4.Value = txtAccountCode.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@accumulate_account_id", SqlDbType.NVarChar, 50)
            prm5.Value = txtAccumulateAccount.Text
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm6.Value = My.Settings.UserName

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@fixed_asset_cat_id", SqlDbType.Int)
            prm1.Value = m_fixed_asset_cat_id

            If m_fixed_asset_cat_id = 0 Then
                prm1.Direction = ParameterDirection.Output
                cn.Open()
                cmd.ExecuteReader()
                m_fixed_asset_cat_id = prm1.Value
                cn.Close()
            Else
                prm1.Value = m_fixed_asset_cat_id
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                'clear_lvw()
            End If
            clear_lvw()
            lock_obj(True)
        Catch ex As Exception
            MsgBox("Error code: " + ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Fixed Asset Cat. Code", 250)
            .Columns.Add("Fixe Asset Cat. Name", 200)
            .Columns.Add("account_id", 0)
            .Columns.Add("accumulate account id", 0)
        End With

        cmd = New SqlCommand("sp_mt_fixed_asset_cat_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@fixed_asset_cat_id", SqlDbType.Int, 255)
        prm1.Value = 0

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 4, 1)
        myReader.Close()
        cn.Close()
    End Sub

    Sub clear_obj()
        m_fixed_asset_cat_id = 0
        'm_AccountId = 0
        txtFixedAssetCatCode.Text = ""
        txtFixedAssetCatName.Text = ""
        txtAccountCode.Text = ""
        txtAccumulateAccount.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtFixedAssetCatCode.ReadOnly = isLock
        txtFixedAssetCatName.ReadOnly = isLock
        btnAccount.Enabled = Not isLock
        btnAccumulateAccount.Enabled = Not isLock

        If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock

        If m_fixed_asset_cat_id <> 0 Then
            txtFixedAssetCatCode.ReadOnly = True
        Else
            btnDelete.Enabled = False
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("sp_mt_fixed_asset_cat_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@fixed_asset_cat_code", SqlDbType.NVarChar, 50)
            prm1.Value = txtFixedAssetCatCode.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm2.Value = My.Settings.UserName
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int)
            prm3.Direction = ParameterDirection.Output
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            If prm3.Value = 1 Then
                MsgBox("You can't delete this record because it's already used!", vbCritical, Me.Text)
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

    Private Sub btnAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccount.Click
        'Dikman - 20161020
        'Dim NewFormDialog As New fdlTenciaAccount
        'NewFormDialog.FrmCallerId = Me.Name
        'NewFormDialog.ShowDialog()

        Dim NewFormDialog As New fdlAccount
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()

    End Sub

    
    Private Sub btnAccumulateAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccumulateAccount.Click
        'Dim NewFormDialog As New fdlTenciaAccount
        'NewFormDialog.FrmCallerId = Me.Name + "Accumulate"
        'NewFormDialog.ShowDialog()

        Dim NewFormDialog As New fdlAccount
        NewFormDialog.FrmCallerId = Me.Name + "Accumulate"
        NewFormDialog.ShowDialog()
    End Sub
End Class