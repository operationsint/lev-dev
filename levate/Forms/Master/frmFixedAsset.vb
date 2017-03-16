Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmFixedAsset
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_fixed_asset_id As Integer
    Dim m_depreciate_id As Integer
    Dim isAllowDelete As Boolean

    Private Sub frmFixedAsset_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        isAllowDelete = canDelete(Me.Name)

        cmbFilterBy.Items.Add("All")
        cmbFilterBy.Items.Add("Fixed Asset Code")
        cmbFilterBy.Items.Add("Fixed Asset Name")
        cmbFilterBy.SelectedIndex = 0

        cmbDepreciationMethod.Items.Add("Straight Line")
        'cmbDepreciationMethod.Items.Add("Double Declining")
        cmbDepreciationMethod.SelectedIndex = 0

        clear_obj()
        lock_obj(True)

        If ListView1.Items.Count > 0 Then
            ListView1.Items.Item(0).Selected = True
            ListView1_Click(sender, e)
        End If
    End Sub

    Public Property FixedAssetCatCode() As String
        Get
            Return txtFixedAssetCat.Text
        End Get
        Set(ByVal Value As String)
            txtFixedAssetCat.Text = Value
        End Set
    End Property

    Sub clear_obj()
        m_fixed_asset_id = 0
        m_depreciate_id = 0
        txtFixedAssetCode.Text = ""
        txtFixedAssetCode2.Text = ""
        txtFixedAssetName.Text = ""
        txtFixedAssetName2.Text = ""
        txtFixedAssetCat.Text = ""
        cmbDepreciationMethod.SelectedIndex = 0
        dtpAcqDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        ntbDepreciationYear.Text = 0
        ntbDepreciationFactor.Text = 2
        ntbAcqValue.Text = FormatNumber("0")
        ntbSalvageValue.Text = FormatNumber("0", 2)
        ntbBookValue.Text = FormatNumber("0", 2)
        ntbQty.Text = "0"

        txtLocation.Text = ""
        txtInfo1.Text = ""
        txtInfo2.Text = ""
        txtInfo3.Text = ""

    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtFixedAssetCode.ReadOnly = isLock
        txtFixedAssetName.ReadOnly = isLock

        btnFixAssetCategory.Enabled = Not isLock
        cmbDepreciationMethod.Enabled = Not isLock
        dtpAcqDate.Enabled = Not isLock
        ntbDepreciationYear.ReadOnly = isLock
        ntbDepreciationFactor.ReadOnly = isLock
        ntbAcqValue.ReadOnly = isLock
        ntbSalvageValue.ReadOnly = isLock
        ntbDepreciationFactor.ReadOnly = True

        ntbQty.ReadOnly = isLock

        txtLocation.ReadOnly = isLock
        txtInfo1.ReadOnly = isLock
        txtInfo2.ReadOnly = isLock
        txtInfo3.ReadOnly = isLock

        If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnDispose.Enabled = Not isLock

        If m_fixed_asset_id <> 0 Then
            cmbDepreciationMethod.Enabled = False
            dtpAcqDate.Enabled = False
            ntbDepreciationYear.ReadOnly = True
            ntbDepreciationFactor.ReadOnly = True
            ntbAcqValue.ReadOnly = True
            ntbSalvageValue.ReadOnly = True
            ntbQty.ReadOnly = True
        Else
            btnDelete.Enabled = False
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click

        If m_fixed_asset_id = 0 And btnAdd.Enabled = False Then lock_obj(True)
        With ListView1.SelectedItems.Item(0)
            'txtCID.Text = Strings.Mid(ListView1.SelectedItems(0).Tag, 2, Len(ListView1.SelectedItems(0).Tag) - 1)
            lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1)) + " of " + ListView1.Items.Count.ToString
            m_fixed_asset_id = LeftSplitUF(.Tag)
            m_depreciate_id = 1
            txtFixedAssetCode.Text = .SubItems.Item(0).Text
            txtFixedAssetCode2.Text = .SubItems.Item(0).Text
            txtFixedAssetName.Text = .SubItems.Item(1).Text
            txtFixedAssetName2.Text = .SubItems.Item(1).Text
            txtFixedAssetCat.Text = .SubItems.Item(2).Text

            If .SubItems.Item(3).Text = "Straight Line" Then
                cmbDepreciationMethod.SelectedIndex = 0
            Else
                cmbDepreciationMethod.SelectedIndex = 1
            End If

            dtpAcqDate.Value = .SubItems.Item(4).Text
            ntbDepreciationYear.Text = .SubItems.Item(5).Text
            ntbDepreciationFactor.Text = .SubItems.Item(6).Text
            ntbAcqValue.Text = FormatNumber(.SubItems.Item(7).Text, 2)
            ntbSalvageValue.Text = FormatNumber(.SubItems.Item(8).Text, 2)
            ntbBookValue.Text = FormatNumber(.SubItems.Item(9).Text, 2)
            ntbQty.Text = FormatNumber(.SubItems.Item(10).Text, 2)
            txtLocation.Text = .SubItems.Item(11).Text
            txtInfo1.Text = .SubItems.Item(12).Text
            txtInfo2.Text = .SubItems.Item(13).Text
            txtInfo3.Text = .SubItems.Item(14).Text

            clear_lvw2()
        End With
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then clear_lvw()
    End Sub

    Private Sub cmbFilterBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFilterBy.SelectedIndexChanged
        If cmbFilterBy.SelectedItem.ToString = "All" Then
            txtFilter.Text = ""
            If m_fixed_asset_id <> 0 Then clear_obj()
            clear_lvw()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        clear_obj()
        lock_obj(False)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
        If m_fixed_asset_id <> 0 Then txtFixedAssetCode.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_fixed_asset_id = 0 Then
            clear_obj()
        End If
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtFixedAssetCode.Text = "" Then
            MsgBox("Please fill fixed asset code!", vbCritical + vbOKOnly, Me.Text)
            txtFixedAssetCode.Focus()
            Exit Sub
        End If

        If txtFixedAssetName.Text = "" Then
            MsgBox("Please fill fixed asset name!", vbCritical + vbOKOnly, Me.Text)
            txtFixedAssetName.Focus()
            Exit Sub
        End If

        If txtFixedAssetCat.Text = "" Then
            MsgBox("Please fill fixed asset category!", vbCritical + vbOKOnly, Me.Text)
            btnFixAssetCategory.Focus()
            Exit Sub
        End If

        If CInt(ntbDepreciationYear.Text) = 0 Then
            MsgBox("Please fill depreciation year!", vbCritical + vbOKOnly, Me.Text)
            ntbDepreciationYear.Focus()
            Exit Sub
        End If

        If CInt(ntbAcqValue.Text) = 0 Then
            MsgBox("Please fill acquisition value!", vbCritical + vbOKOnly, Me.Text)
            ntbAcqValue.Focus()
            Exit Sub
        End If

        'If CInt(ntbSalvageValue.Text) = 0 Then
        '    MsgBox("Please fill salvage value!", vbCritical + vbOKOnly, Me.Text)
        '    ntbSalvageValue.Focus()
        '    Exit Sub
        'End If

        Cursor = Cursors.WaitCursor 'change pointer/cursor into hourglass
        Try
            cmd = New SqlCommand(IIf(m_fixed_asset_id = 0, "sp_mt_fixed_asset_INS", "sp_mt_fixed_asset_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@fixed_asset_code", SqlDbType.NVarChar, 50)
            prm2.Value = txtFixedAssetCode.Text
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@fixed_asset_name", SqlDbType.NVarChar, 50)
            prm3.Value = txtFixedAssetName.Text
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@fixed_asset_cat", SqlDbType.NVarChar, 50)
            prm4.Value = txtFixedAssetCat.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@depreciation_method", SqlDbType.NVarChar, 50)
            prm5.Value = cmbDepreciationMethod.SelectedItem.ToString
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@acq_date", SqlDbType.SmallDateTime)
            prm6.Value = dtpAcqDate.Value.Date
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@depreciation_year", SqlDbType.NVarChar, 5)
            prm7.Value = ntbDepreciationYear.Text
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@depreciation_factor", SqlDbType.NVarChar, 5)
            prm8.Value = "2"
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@acq_value", SqlDbType.Decimal, 18.2)
            prm9.Value = FormatNumber(IIf(ntbAcqValue.Text = "", 0, ntbAcqValue.Text), 2)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@salvage_value", SqlDbType.Decimal, 18.2)
            prm10.Value = FormatNumber(IIf(ntbSalvageValue.Text = "", 0, ntbSalvageValue.Text), 2)
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@location", SqlDbType.NVarChar, 50)
            prm11.Value = txtLocation.Text
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@other_info1", SqlDbType.NVarChar, 50)
            prm12.Value = txtInfo1.Text
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@other_info2", SqlDbType.NVarChar, 50)
            prm13.Value = txtInfo2.Text
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@other_info3", SqlDbType.NVarChar, 50)
            prm14.Value = txtInfo3.Text
            Dim prm19 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm19.Value = My.Settings.UserName


            Dim prm1 As SqlParameter = cmd.Parameters.Add("@fixed_asset_id", SqlDbType.Int)
            prm1.Value = m_fixed_asset_id

            If m_fixed_asset_id = 0 Then
                prm1.Direction = ParameterDirection.Output
                cn.Open()
                cmd.ExecuteReader()
                m_fixed_asset_id = prm1.Value
                cn.Close()
                m_depreciate_id = 0
            Else
                prm1.Value = m_fixed_asset_id
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                m_depreciate_id = 1
            End If
            save_Fixed_Asset_Depreciation()
            clear_lvw()
            lock_obj(True)
            clear_obj()
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        Cursor = Cursors.Default
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Fixed Asset Code", 100)
            .Columns.Add("Fixed Asset Name", 200)
            .Columns.Add("Fixed Asset Category", 100)
            .Columns.Add("depreciation_method", 0)
            .Columns.Add("acquisition_date", 0)
            .Columns.Add("depreciation_year", 0)
            .Columns.Add("depreciation_factor", 0)
            .Columns.Add("acquisition_value", 0)
            .Columns.Add("salvage_value", 0)
            .Columns.Add("Book Value", 200, HorizontalAlignment.Right)
            .Columns.Add("Qty", 50, HorizontalAlignment.Right)
            .Columns.Add("Location", 0)
            .Columns.Add("Other_info1", 0)
            .Columns.Add("Other_info2", 0)
            .Columns.Add("Other_info3", 0)
        End With

        'a.fixed_asset_id,0
        'a.fixed_asset_code,1
        'a.fixed_asset_name,2
        'a.fixed_asset_cat_code,3
        'a.depreciation_method,4
        'a.acquisition_date,5
        'a.depreciation_year,6
        'a.depreciation_factor,7
        'a.acquisition_value,8
        'a.salvage_value,9
        'a.book_value,10
        'a.qty,11
        'a.location,12
        'a.other_info1,13
        'a.other_info2,14
        'a.other_info3,15

        cmd = New SqlCommand("sp_mt_fixed_asset_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@fixed_asset_id", SqlDbType.Int, 255)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@fixed_asset_code", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(cmbFilterBy.Text = "Fixed Asset Code", txtFilter.Text, DBNull.Value)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@fixed_asset_name", SqlDbType.NVarChar, 50)
        prm3.Value = IIf(cmbFilterBy.Text = "Fixed Asset Name", txtFilter.Text, DBNull.Value)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 15, 1)
        cn.Close()
    End Sub

    Sub clear_lvw2()
        With ListView2
            .Clear()
            .View = View.Details
            .Columns.Add("Depreciation Date", 80)
            .Columns.Add("Depreciation Amount", 120, HorizontalAlignment.Right)
            .Columns.Add("Accumulate Depr. Value", 120, HorizontalAlignment.Right)
            .Columns.Add("Running Book Value", 120, HorizontalAlignment.Right)
            .Columns.Add("Journal Flag", 80, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("sp_mt_fixed_asset_depreciation_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@fixed_asset_code", SqlDbType.NVarChar, 50)
        prm1.Value = txtFixedAssetCode2.Text

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView2, 6, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0))) 'Depreciation_Date
            lvItem.Tag = intCurrRow 
            lvItem.SubItems.Add(FormatNumber(myReader.Item(1), 2)) 'Depreciation Amount
            lvItem.SubItems.Add(FormatNumber(myReader.Item(3), 2)) 'Accumulate Depr. Value
            lvItem.SubItems.Add(FormatNumber(myReader.Item(2), 2)) 'Running Book Value
            If myReader.Item(4) = "True" Then
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

            ListView2.Items.Add(lvItem)
            intCurrRow += 1
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("sp_mt_fixed_asset_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@fixed_asset_code", SqlDbType.NVarChar, 50)
            prm1.Value = txtFixedAssetCode.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm2.Value = My.Settings.UserName
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int)
            prm3.Direction = ParameterDirection.Output
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            If prm3.Value = 1 Then
                MsgBox("You can't delete fixed asset code : " + txtFixedAssetCode.Text + " because already depreciated!", vbCritical, Me.Text)
            Else
                clear_lvw()
                clear_lvw2()
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

    Private Sub btnCurrency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFixAssetCategory.Click
        Dim NewFormDialog As New fdlFixedAssetCat
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnCurrency_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnFixAssetCategory.KeyPress
        Dim NewFormDialog As New fdlFixedAssetCat
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub ntbDepreciationYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ntbDepreciationYear.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ntbDepreciationYear_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbDepreciationYear.LostFocus
        If ntbDepreciationYear.Text = "" Then
            ntbDepreciationYear.Text = 0
        End If

        If CInt(ntbDepreciationYear.Text) < 0 Then
            ntbDepreciationYear.Text = CInt(ntbDepreciationYear.Text) * -1
        End If
    End Sub

    Private Sub ntbAcqValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbAcqValue.LostFocus
        If ntbAcqValue.Text = "" Then
            ntbAcqValue.Text = 0
        End If

        If ntbAcqValue.DecimalValue < 0 Then
            ntbAcqValue.Text = ntbAcqValue.DecimalValue * -1
        End If

        ntbAcqValue.Text = FormatNumber(ntbAcqValue.Text, 2)
    End Sub

    Private Sub ntbSalvageValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSalvageValue.LostFocus
        If ntbSalvageValue.Text = "" Then
            ntbSalvageValue.Text = 0
        End If

        If ntbSalvageValue.DecimalValue < 0 Then
            ntbSalvageValue.Text = ntbSalvageValue.DecimalValue * -1
        End If

        ntbSalvageValue.Text = FormatNumber(ntbSalvageValue.Text, 2)
    End Sub

    Sub save_Fixed_Asset_Depreciation()
        Try
            Dim m_date As Date = dtpAcqDate.Value
            Dim i As Integer
            Dim MonthCount As Integer = CInt(ntbDepreciationYear.Text) * 12
            Dim DepreciationValue As Decimal = CInt(ntbAcqValue.Text) - CInt(ntbSalvageValue.Text)
            Dim AmountValue As Decimal = DepreciationValue / MonthCount
            Dim BookValue As Decimal = FormatNumber(ntbAcqValue.Text)
            Dim AccumulateValue As Decimal = 0

            If m_depreciate_id = 0 Then
                For i = 1 To MonthCount
                    cmd = New SqlCommand("sp_mt_fixed_asset_depreciation_INS", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm31 As SqlParameter = cmd.Parameters.Add("@fixed_asset_code", SqlDbType.NVarChar, 50)
                    prm31.Value = txtFixedAssetCode.Text
                    Dim prm32 As SqlParameter = cmd.Parameters.Add("@day", SqlDbType.NVarChar, 2)
                    prm32.Value = GetLastDayOfMonth(m_date.Month, m_date.Year).Day
                    Dim prm33 As SqlParameter = cmd.Parameters.Add("@month", SqlDbType.NVarChar, 2)
                    prm33.Value = m_date.Month
                    Dim prm34 As SqlParameter = cmd.Parameters.Add("@year", SqlDbType.NVarChar, 4)
                    prm34.Value = m_date.Year
                    Dim prm35 As SqlParameter = cmd.Parameters.Add("@amount", SqlDbType.Decimal, 18.2)
                    prm35.Value = AmountValue
                    Dim prm36 As SqlParameter = cmd.Parameters.Add("@book_value", SqlDbType.Decimal, 18.2)
                    BookValue = BookValue - AmountValue
                    prm36.Value = BookValue
                    Dim prm37 As SqlParameter = cmd.Parameters.Add("@accumulate_value", SqlDbType.Decimal, 18.2)
                    AccumulateValue = AccumulateValue + AmountValue
                    prm37.Value = AccumulateValue
                    Dim prm40 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                    prm40.Value = My.Settings.UserName

                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()

                    m_date = m_date.AddMonths(1)
                Next
            Else
                'cmd = New SqlCommand("sp_mt_fixed_asset_depreciation_UPD", cn)
                'cmd.CommandType = CommandType.StoredProcedure

                'Dim prm41 As SqlParameter = cmd.Parameters.Add("@fixed_asset_code", SqlDbType.NVarChar, 50)
                'prm41.Value = txtFixedAssetCode.Text
                'Dim prm42 As SqlParameter = cmd.Parameters.Add("@acq_date", SqlDbType.SmallDateTime)
                'prm42.Value = dtpAcqDate.Value
                'Dim prm43 As SqlParameter = cmd.Parameters.Add("@acq_value", SqlDbType.Decimal, 18.2)
                'prm43.Value = FormatNumber(IIf(ntbAcqValue.Text = "", 0, ntbAcqValue.Text), 2)
                'Dim prm44 As SqlParameter = cmd.Parameters.Add("@salvage_value", SqlDbType.Decimal, 18.2)
                'prm44.Value = FormatNumber(IIf(ntbSalvageValue.Text = "", 0, ntbSalvageValue.Text), 2)
                'Dim prm46 As SqlParameter = cmd.Parameters.Add("@depreciation_year", SqlDbType.Int)
                'prm46.Value = CInt(ntbDepreciationYear.Text)
                'Dim prm50 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                'prm50.Value = My.Settings.UserName

                'cn.Open()
                'cmd.ExecuteNonQuery()
                'cn.Close()
            End If

            m_depreciate_id = 1

        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()

            ''Begin reversing process
            'cmd = New SqlCommand("sp_mt_fixed_asset_depreciation_DEL", cn)
            'cmd.CommandType = CommandType.StoredProcedure

            'Dim prm1 As SqlParameter = cmd.Parameters.Add("@fixed_asset_code", SqlDbType.NVarChar, 50)
            'prm1.Value = m_fixed_asset_id
            'Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            'prm2.Value = My.Settings.UserName
            'Dim prm3 As SqlParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int)
            'prm3.Direction = ParameterDirection.Output
            'cn.Open()
            'cmd.ExecuteNonQuery()
            'cn.Close()
            'If prm3.Value = 1 Then
            '    MsgBox("You can't delete this record because it's already used in transaction.", vbCritical, Me.Text)
            'Else
            '    clear_lvw()
            '    clear_obj()
            'End If
            'lock_obj(True)
        End Try
    End Sub

    Private Sub btnDispose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDispose.Click
        If MsgBox("Are you sure you want to dispose this fixed asset?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            'With fdlFixedAssetDispose
            '    .FixedAssetCode = txtFixedAssetCode.Text
            '    .FixedAssetName = txtFixedAssetName.Text
            '    .BookValue = ntbBookValue.Text
            '    .DisposeValue = ntbBookValue.Text
            '    .ShowDialog()
            'End With
            cmd = New SqlCommand("sp_mt_fixed_asset_DISPOSE", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@fixed_asset_code", SqlDbType.NVarChar, 50)
            prm1.Value = txtFixedAssetCode.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm2.Value = My.Settings.UserName
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            MsgBox("Fixed Asset Code : " + txtFixedAssetCode.Text + " has been disposed!", vbInformation)

            clear_lvw()
            clear_lvw2()
            clear_obj()

            lock_obj(True)
        End If
    End Sub

    'Autorefresh---Hendra
    Public Sub frmFixedAssetShow(ByVal sender As System.Object, ByVal e As System.EventArgs)
        btnFilter_Click(sender, e)
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        clear_lvw()
        clear_obj()
        lock_obj(True)

        If ListView1.Items.Count > 0 Then
            ListView1.Items.Item(0).Selected = True
            ListView1_Click(sender, e)
        End If
    End Sub

    Public Function GetLastDayOfMonth(ByVal intMonth, ByVal intYear) As Date
        GetLastDayOfMonth = DateSerial(intYear, intMonth + 1, 0)
    End Function
End Class