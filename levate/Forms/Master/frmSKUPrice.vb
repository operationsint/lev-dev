Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmSKUPrice
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_SKUId As Integer
    Dim Dec As Integer = 6

    Private Sub frmSKUPrice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        clear_obj()
        lock_obj(True)

        cmbFilterBy.Items.Add("<All>")
        cmbFilterBy.Items.Add("Stock Code")
        cmbFilterBy.Items.Add("Stock Name")
        cmbFilterBy.SelectedIndex = 0

        cmd = New SqlCommand("sp_mt_sku_cat_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_cat_id", SqlDbType.Int)
        prm1.Value = 0

        cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader

        Do While myReader.Read
            cmbSKUCatID.Items.Add(New clsMyListInt(myReader.GetString(1), myReader.GetInt32(0)))
        Loop
        myReader.Close()
        cn.Close()

        If ListView1.Items.Count > 0 Then
            ListView1.Items.Item(0).Selected = True
            ListView1_Click(sender, e)
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        If m_SKUId = 0 And btnAdd.Enabled = False Then lock_obj(True)
        With ListView1.SelectedItems.Item(0)

            'txtSKUID.Text = Strings.Mid(ListView1.SelectedItems(0).Tag, 2, Len(ListView1.SelectedItems(0).Tag) - 1)
            lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1))
            m_SKUId = LeftSplitUF(.Tag)

            Dim mList As clsMyListInt
            Dim i As Integer
            For i = 1 To cmbSKUCatID.Items.Count
                mList = cmbSKUCatID.Items(i - 1)
                If CInt(.SubItems.Item(0).Text) = mList.ItemData Then
                    cmbSKUCatID.SelectedIndex = i - 1
                    Exit For
                End If
            Next

            txtSKUCode.Text = .SubItems.Item(1).Text
            txtSKUName.Text = .SubItems.Item(2).Text
            txtSKUBarcode.Text = .SubItems.Item(3).Text
            txtSKUUoM.Text = .SubItems.Item(4).Text
            ntbSalesDiscPercent.Text = FormatNumber(.SubItems.Item(5).Text) * 100
            ntbSalesPrice.Text = FormatNumber(.SubItems.Item(6).Text, Dec)
            NumericTextBox1.Text = FormatNumber(.SubItems.Item(7).Text)
            NumericTextBox2.Text = FormatNumber(.SubItems.Item(8).Text)
            NumericTextBox3.Text = FormatNumber(.SubItems.Item(9).Text)
            NumericTextBox4.Text = FormatNumber(.SubItems.Item(10).Text)
            txtLastCost.Text = FormatNumber(.SubItems.Item(11).Text)
            txtStockValue.Text = FormatNumber(.SubItems.Item(12).Text)
            txtStockBalance.Text = .SubItems.Item(13).Text
            txtAvgCost.Text = FormatNumber(.SubItems.Item(14).Text)
            txtSKURemarks.Text = .SubItems.Item(15).Text
            txtSKUInfo1.Text = .SubItems.Item(16).Text
            txtSKUInfo2.Text = .SubItems.Item(17).Text
            txtSKUInfo3.Text = .SubItems.Item(18).Text
            chbStockSet.Checked = IIf(Trim(.SubItems.Item(19).Text) = "True", True, False)
            chbFinishGoods.Checked = IIf(Trim(.SubItems.Item(20).Text) = "True", True, False)
        End With
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then clear_lvw()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        clear_obj()
        lock_obj(False)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
        If m_SKUId <> 0 Then txtSKUCode.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo err_btnSave_Click

        If txtSKUCode.Text = "" Or txtSKUName.Text = "" Or cmbSKUCatID.SelectedIndex = -1 Then
            MsgBox("Stock Code, Stock Name and Stock Category are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtSKUCode.Focus()
            Exit Sub
        End If

        cmd = New SqlCommand(IIf(m_SKUId = 0, "sp_mt_sku_INS", "sp_mt_sku_UPD"), cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm2 As SqlParameter = cmd.Parameters.Add("@sku_cat_id", SqlDbType.Int)
        prm2.Value = cmbSKUCatID.Items(cmbSKUCatID.SelectedIndex).ItemData
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@sku_code", SqlDbType.NVarChar, 50)
        prm3.Value = txtSKUCode.Text
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@sku_name", SqlDbType.NVarChar, 255)
        prm4.Value = txtSKUName.Text
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@sku_barcode", SqlDbType.NVarChar, 255)
        prm5.Value = IIf(txtSKUBarcode.Text = "", DBNull.Value, txtSKUBarcode.Text)
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@sku_uom", SqlDbType.NVarChar, 50)
        prm6.Value = IIf(txtSKUUoM.Text = "", DBNull.Value, txtSKUUoM.Text)
        Dim prm7 As SqlParameter = cmd.Parameters.Add("@sales_discount", SqlDbType.Decimal)
        prm7.Value = IIf(ntbSalesDiscPercent.Text = "", 0, ntbSalesDiscPercent.Text)
        Dim prm8 As SqlParameter = cmd.Parameters.Add("@sales_price", SqlDbType.Decimal)
        prm8.Value = IIf(ntbSalesPrice.Text = "", 0, ntbSalesPrice.Text)
        Dim prm9 As SqlParameter = cmd.Parameters.Add("@pack_qty", SqlDbType.Decimal)
        prm9.Value = CDbl(NumericTextBox1.Text)
        Dim prm10 As SqlParameter = cmd.Parameters.Add("@sku_volume", SqlDbType.Decimal)
        prm10.Value = CDbl(NumericTextBox2.Text)
        Dim prm11 As SqlParameter = cmd.Parameters.Add("@gross_weight", SqlDbType.Decimal)
        prm11.Value = CDbl(NumericTextBox3.Text)
        Dim prm12 As SqlParameter = cmd.Parameters.Add("@net_weight", SqlDbType.Decimal)
        prm12.Value = CDbl(NumericTextBox4.Text)

        Dim prm13 As SqlParameter = cmd.Parameters.Add("@sku_remarks", SqlDbType.NVarChar, 255)
        prm13.Value = IIf(txtSKURemarks.Text = "", DBNull.Value, txtSKURemarks.Text)
        Dim prm14 As SqlParameter = cmd.Parameters.Add("@sku_info1", SqlDbType.NVarChar, 255)
        prm14.Value = IIf(txtSKUInfo1.Text = "", DBNull.Value, txtSKUInfo1.Text)
        Dim prm15 As SqlParameter = cmd.Parameters.Add("@sku_info2", SqlDbType.NVarChar, 255)
        prm15.Value = IIf(txtSKUInfo2.Text = "", DBNull.Value, txtSKUInfo2.Text)
        Dim prm16 As SqlParameter = cmd.Parameters.Add("@sku_info3", SqlDbType.NVarChar, 255)
        prm16.Value = IIf(txtSKUInfo3.Text = "", DBNull.Value, txtSKUInfo3.Text)
        Dim prm17 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
        prm17.Value = My.Settings.UserName
        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int, 255)
        prm1.Value = m_SKUId

        Dim prmIsPackage As SqlParameter = cmd.Parameters.Add("@is_package", SqlDbType.Bit)
        prmIsPackage.Value = IIf(chbStockSet.Checked = True, 1, 0)

        Dim prmIsFinishGoods As SqlParameter = cmd.Parameters.Add("@is_finish_goods", SqlDbType.Bit)
        prmIsFinishGoods.Value = IIf(chbFinishGoods.Checked = True, 1, 0)

        If m_SKUId = 0 Then
            prm1.Direction = ParameterDirection.Output
            cn.Open()
            cmd.ExecuteReader()
            m_SKUId = prm1.Value
            cn.Close()
        Else
            prm1.Value = m_SKUId
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
            .Columns.Add("Category", 0)
            .Columns.Add("Stock Code", 90)
            .Columns.Add("Stock Name", 300)
            .Columns.Add("Barcode", 0)
            .Columns.Add("UoM", 0)
            .Columns.Add("Sales Disc", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("Sales Price", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("pack_qty", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("sku_volume", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("gross_weight", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("net_weight", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("Last Cost", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("Stock Val", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("Stock Bal", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("Avg Cost", 0).TextAlign = HorizontalAlignment.Right
            .Columns.Add("Remarks", 0)
            .Columns.Add("Info1", 0)
            .Columns.Add("Info2", 0)
            .Columns.Add("Info3", 0)
            .Columns.Add("Is Formula", 100)
            .Columns.Add("Is Finish Goods", 100)
        End With

        cmd = New SqlCommand("sp_mt_sku_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@sku_code", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(cmbFilterBy.Text = "Stock Code", txtFilter.Text, DBNull.Value)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@sku_name", SqlDbType.NVarChar, 50)
        prm3.Value = IIf(cmbFilterBy.Text = "Stock Name", txtFilter.Text, DBNull.Value)
        'Dim prm4 As SqlParameter = cmd.Parameters.Add("@is_package", SqlDbType.Bit)
        'prm4.Value = 0

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim i As Integer, intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1))) 'sku_id
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            For i = 2 To 19 'sku_code, stock_adj_description, location_id, location_code
                If myReader.Item(i) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(i))
                End If
            Next

            If myReader.Item(20) Is System.DBNull.Value Then
                lvItem.SubItems.Add("0")
            Else
                lvItem.SubItems.Add(myReader.Item(20))
            End If

            If myReader.Item(27) Is System.DBNull.Value Then
                lvItem.SubItems.Add("0")
            Else
                lvItem.SubItems.Add(myReader.Item(27))
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


        'Call FillList(myReader, Me.ListView1, 20, 1)


        'If myReader.Item(27) Is System.DBNull.Value Then
        '    lvItem.SubItems.Add("0")
        'Else
        '    lvItem.SubItems.Add(myReader.Item(27))
        'End If


        'myReader.Close()
        'cn.Close()
    End Sub

    Sub clear_obj()
        m_SKUId = 0
        txtSKUCode.Text = ""
        txtSKUName.Text = ""
        cmbSKUCatID.SelectedIndex = -1
        txtSKUBarcode.Text = ""
        txtSKUUoM.Text = ""
        ntbSalesDiscPercent.Text = 0
        ntbSalesPrice.Text = FormatNumber(0)
        NumericTextBox1.Text = FormatNumber(0)
        NumericTextBox2.Text = FormatNumber(0)
        NumericTextBox3.Text = FormatNumber(0)
        NumericTextBox4.Text = FormatNumber(0)
        txtLastCost.Text = FormatNumber(0)
        txtStockValue.Text = FormatNumber(0)
        txtStockBalance.Text = 0
        txtAvgCost.Text = FormatNumber(0)
        txtSKURemarks.Text = ""
        txtSKUInfo1.Text = ""
        txtSKUInfo2.Text = ""
        txtSKUInfo3.Text = ""
        chbStockSet.Checked = False
        chbFinishGoods.Checked = False
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtSKUCode.ReadOnly = isLock
        txtSKUName.ReadOnly = isLock
        cmbSKUCatID.Enabled = Not isLock
        txtSKUBarcode.ReadOnly = isLock
        txtSKUUoM.ReadOnly = isLock
        ntbSalesDiscPercent.ReadOnly = isLock
        ntbSalesPrice.ReadOnly = isLock
        NumericTextBox1.ReadOnly = isLock
        NumericTextBox2.ReadOnly = isLock
        NumericTextBox3.ReadOnly = isLock
        NumericTextBox4.ReadOnly = isLock

        txtSKURemarks.ReadOnly = isLock
        txtSKUInfo1.ReadOnly = isLock
        txtSKUInfo2.ReadOnly = isLock
        txtSKUInfo3.ReadOnly = isLock

        btnDelete.Enabled = Not isLock
        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
    End Sub

    Private Sub cmbSKUCatID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSKUCatID.SelectedIndexChanged
        'Dim mList As clsMyList
        'mList = cmbSKUCatID.Items(cmbSKUCatID.SelectedIndex)
        'In the following statement, you can either use mList.ToString or
        'mList.Name. They both return the Name property.
        'Label1.Text = mList.ItemData & "  " & mList.Name
        'Alternately, you can use the following syntax.
        'Label1.Text = ComboBox1.Items(ComboBox1.SelectedIndex).ItemData _
        ' & "  " & ComboBox1.Items(ComboBox1.SelectedIndex).ToString
    End Sub

    Private Sub cmbFilterBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFilterBy.SelectedIndexChanged
        If cmbFilterBy.SelectedItem.ToString = "<All>" Then
            txtFilter.Text = ""
            If m_SKUId <> 0 Then clear_obj()
            clear_lvw()
        End If
    End Sub

    Private Sub ntbSalesPrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSalesPrice.LostFocus
        ntbSalesPrice.Text = FormatNumber(ntbSalesPrice.Text, Dec)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("sp_mt_sku_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int, 50)
            prm1.Value = m_SKUId
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

    Private Sub ntbSalesDiscPercent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbSalesDiscPercent.TextChanged

    End Sub

    Private Sub NumericTextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericTextBox1.LostFocus
        NumericTextBox1.Text = FormatNumber(NumericTextBox1.Text, 2)
    End Sub

    Private Sub NumericTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericTextBox1.TextChanged

    End Sub

    Private Sub NumericTextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericTextBox2.LostFocus
        NumericTextBox2.Text = FormatNumber(NumericTextBox2.Text, 2)
    End Sub

    Private Sub NumericTextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericTextBox3.LostFocus
        NumericTextBox3.Text = FormatNumber(NumericTextBox3.Text, 2)
    End Sub

    Private Sub NumericTextBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NumericTextBox4.LostFocus
        NumericTextBox4.Text = FormatNumber(NumericTextBox4.Text, 2)
    End Sub
End Class