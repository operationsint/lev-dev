Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class frmSKU
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_SKUId As Integer
    Dim isAllowDelete As Boolean
    Dim Dec As Integer = GetSysInit("decimal_digit")
    Dim m_loadFlag As Boolean = False

    'Untuk slideshow
    Dim extension As String
    Dim original As Image
    Dim resized As Image
    Dim memStream As MemoryStream

    Private Sub frmSKU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isAllowDelete = canDelete(Me.Name)

        clear_obj()

        cmbFilterBy.Items.Add("<All>")
        cmbFilterBy.Items.Add("Stock Code")
        cmbFilterBy.Items.Add("Stock Name")

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

        cmbFilterBy.SelectedIndex = 0

        populateCbCategory()
        cbCategory.SelectedIndex = 0

        clear_lvw()
        m_loadFlag = True
        'If ListView1.Items.Count > 0 Then
        '    ListView1.Items.Item(0).Selected = True
        '    ListView1_Click(sender, e)
        'End If

        'lock_obj(True)
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then clear_lvw()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        clear_obj()
        lock_obj(False)
        clear_lvw2()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
        If m_SKUId <> 0 Then txtSKUCode.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_SKUId = 0 And ListView1.Items.Count > 0 Then
            ListView1.Items.Item(0).Selected = True
            ListView1_Click(sender, e)
        End If
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
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
        prm9.Value = CDbl(ntbJumlahKemasan.Text)
        Dim prm10 As SqlParameter = cmd.Parameters.Add("@sku_volume", SqlDbType.Decimal)
        prm10.Value = CDbl(ntbVolume.Text)
        Dim prm11 As SqlParameter = cmd.Parameters.Add("@gross_weight", SqlDbType.Decimal)
        prm11.Value = CDbl(ntbBeratKotor.Text)
        Dim prm12 As SqlParameter = cmd.Parameters.Add("@net_weight", SqlDbType.Decimal)
        prm12.Value = CDbl(ntbBeratBersih.Text)

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
        Dim prm18 As SqlParameter = cmd.Parameters.Add("@image_link", SqlDbType.NVarChar, 50)
        prm18.Value = IIf(lblUpload.Text = "", DBNull.Value, lblUpload.Text)

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

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        'If m_SKUId = 0 And btnAdd.Enabled = False Then lock_obj(True)
        With ListView1.SelectedItems.Item(0)
            'txtSKUID.Text = Strings.Mid(ListView1.SelectedItems(0).Tag, 2, Len(ListView1.SelectedItems(0).Tag) - 1)
            lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1)) + " of " + ListView1.Items.Count.ToString
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
            ntbJumlahKemasan.Text = FormatNumber(.SubItems.Item(7).Text)
            ntbVolume.Text = FormatNumber(.SubItems.Item(8).Text)
            ntbBeratKotor.Text = FormatNumber(.SubItems.Item(9).Text)
            ntbBeratBersih.Text = FormatNumber(.SubItems.Item(10).Text)
            txtLastCost.Text = FormatNumber(.SubItems.Item(11).Text)
            txtStockValue.Text = FormatNumber(.SubItems.Item(12).Text)
            txtStockBalance.Text = .SubItems.Item(13).Text
            txtAvgCost.Text = FormatNumber(.SubItems.Item(14).Text)
            txtSKURemarks.Text = .SubItems.Item(15).Text
            txtSKUInfo1.Text = .SubItems.Item(16).Text
            txtSKUInfo2.Text = .SubItems.Item(17).Text
            txtSKUInfo3.Text = .SubItems.Item(18).Text
            chbStockSet.Checked = IIf(Trim(.SubItems.Item(19).Text) = "True", True, False)
            lblUpload.Text = .SubItems.Item(20).Text
            chbFinishGoods.Checked = IIf(Trim(.SubItems.Item(21).Text) = "True", True, False)

            clear_lvw2()
            loadImage()
        End With
    End Sub

    Sub clear_lvw()
        Try
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
                .Columns.Add("Stock Bal", 90).TextAlign = HorizontalAlignment.Right
                .Columns.Add("Avg Cost", 0).TextAlign = HorizontalAlignment.Right
                .Columns.Add("Remarks", 0)
                .Columns.Add("Info1", 0)
                .Columns.Add("Info2", 0)
                .Columns.Add("Info3", 0)
                .Columns.Add("Is Formula", 100)
                .Columns.Add("Image Link", 0)
                .Columns.Add("Is FG", 100)
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
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@sku_cat_id", SqlDbType.Int)
            prm5.Value = cbCategory.SelectedValue

            cn.Open()

            '[sku_id],0
            '[sku_cat_id],1
            '[sku_code],2
            '[sku_name],3
            '[sku_barcode],4
            '[sku_uom],5
            '[sales_discount],6
            '[sales_price],7
            '[pack_qty],8
            '[sku_volume],9
            '[gross_weight],10
            '[net_weight],11
            '[last_cost],12
            '[stock_value],13
            '[stock_balance],14
            '[avg_cost],15
            '[sku_remarks],16
            '[sku_info1],17
            '[sku_info2],18
            '[sku_info3],19
            '[is_package],20
            '[AC],21
            '[CO],22
            '[CB],23
            '[MO],24
            '[MB],25
            '[image_link],26
            '[is_finish_goods],27

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

                If myReader.Item(26) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(26))
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
            loadImage()
            myReader.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        
    End Sub

    Sub clear_lvw2()
        Try
            With ListView2
                .Clear()
                .View = View.Details
                .Columns.Add("period_id", 0)
                .Columns.Add("Period Name", 120)
                .Columns.Add("Beginning Qty", 90, HorizontalAlignment.Right)
                .Columns.Add("Incoming Qty", 90, HorizontalAlignment.Right)
                .Columns.Add("Outgoing Qty", 90, HorizontalAlignment.Right)
                .Columns.Add("Ending Qty", 90, HorizontalAlignment.Right)
                .Columns.Add("Beginning Value", 120, HorizontalAlignment.Right)
                .Columns.Add("Incoming Value", 120, HorizontalAlignment.Right)
                .Columns.Add("Outgoing Value", 120, HorizontalAlignment.Right)
                .Columns.Add("Ending Value", 120, HorizontalAlignment.Right)
            End With

            cmd = New SqlCommand("sp_mt_sku_balance_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int, 255)
            prm1.Value = m_SKUId

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView2, 6, 1)
            Dim lvItem As ListViewItem
            Dim intCurrRow As Integer
            'sku_balance_id,0
            'mt_sku_balance.period_id,1
            'sys_period.period_name,2
            'qty_begin,3
            'qty_in,4
            'qty_out,5
            'qty_ending,6
            'val_begin,7
            'val_in,8
            'val_out,9
            'val_ending,10
            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(1))) 'period_id
                lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'balance_id
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                lvItem.SubItems.Add(myReader.Item(2)) 'period_name
                lvItem.SubItems.Add(FormatNumber(myReader.Item(3))) 'qty_begin
                lvItem.SubItems.Add(FormatNumber(myReader.Item(4))) 'qty_in
                lvItem.SubItems.Add(FormatNumber(myReader.Item(5))) 'qty_out
                lvItem.SubItems.Add(FormatNumber(myReader.Item(6))) 'qty_ending
                lvItem.SubItems.Add(FormatNumber(myReader.Item(7))) 'val_begin
                lvItem.SubItems.Add(FormatNumber(myReader.Item(8))) 'val_in
                lvItem.SubItems.Add(FormatNumber(myReader.Item(9))) 'val_out
                lvItem.SubItems.Add(FormatNumber(myReader.Item(10))) 'val_ending
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
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        
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
        ntbJumlahKemasan.Text = FormatNumber(0)
        ntbVolume.Text = FormatNumber(0)
        ntbBeratKotor.Text = FormatNumber(0)
        ntbBeratBersih.Text = FormatNumber(0)
        txtLastCost.Text = FormatNumber(0)
        txtStockValue.Text = FormatNumber(0)
        txtStockBalance.Text = 0
        txtAvgCost.Text = FormatNumber(0)
        txtSKURemarks.Text = ""
        txtSKUInfo1.Text = ""
        txtSKUInfo2.Text = ""
        txtSKUInfo3.Text = ""
        lblUpload.Text = ""
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
        ntbJumlahKemasan.ReadOnly = isLock
        ntbVolume.ReadOnly = isLock
        ntbBeratKotor.ReadOnly = isLock
        ntbBeratBersih.ReadOnly = isLock

        txtSKURemarks.ReadOnly = isLock
        txtSKUInfo1.ReadOnly = isLock
        txtSKUInfo2.ReadOnly = isLock
        txtSKUInfo3.ReadOnly = isLock
        chbStockSet.Enabled = Not isLock
        chbFinishGoods.Enabled = Not isLock

        If m_SKUId = 0 Then
            btnDelete.Enabled = isLock
        Else
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
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
        btnCancel_Click(sender, e)
    End Sub

    Private Sub ntbSalesPrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSalesPrice.LostFocus
        ntbSalesPrice.Text = FormatNumber(ntbSalesPrice.Text, Dec)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("sp_mt_sku_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
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

    Private Sub NumericTextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbJumlahKemasan.LostFocus
        If ntbJumlahKemasan.Text = "" Then ntbJumlahKemasan.Text = FormatNumber(0)
        ntbJumlahKemasan.Text = FormatNumber(ntbJumlahKemasan.Text)
    End Sub

    Private Sub NumericTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbJumlahKemasan.TextChanged

    End Sub

    Private Sub NumericTextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbVolume.LostFocus
        If ntbVolume.Text = "" Then ntbVolume.Text = FormatNumber(0)
        ntbVolume.Text = FormatNumber(ntbVolume.Text)
    End Sub

    Private Sub NumericTextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbBeratKotor.LostFocus
        If ntbBeratKotor.Text = "" Then ntbBeratKotor.Text = FormatNumber(0)
        ntbBeratKotor.Text = FormatNumber(ntbBeratKotor.Text)
    End Sub

    Private Sub NumericTextBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbBeratBersih.LostFocus
        If ntbBeratBersih.Text = "" Then ntbBeratBersih.Text = FormatNumber(0)
        ntbBeratBersih.Text = FormatNumber(ntbBeratBersih.Text)
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        clear_lvw()
    End Sub

    Private _category As New List(Of clsMyListInt)

    Sub populateCbCategory()
        Try
            cmd = New SqlCommand("sp_mt_sku_cat_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_cat_id", SqlDbType.Int)
            prm1.Value = 0

            cn.Open()
            Dim myReader As SqlDataReader = cmd.ExecuteReader

            _category.Add(New clsMyListInt With {.Name = "All", .ItemData = 0})
            Do While myReader.Read
                _category.Add(New clsMyListInt(myReader.GetString(1), myReader.GetInt32(0)))
            Loop
            myReader.Close()
            cn.Close()

            cbCategory.DataSource = _category
            cbCategory.ValueMember = "ItemData"
            cbCategory.DisplayMember = "Name"
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try

    End Sub

    Private Sub cbCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCategory.SelectedIndexChanged
        If m_loadFlag = True Then
            clear_lvw()
        End If
    End Sub

    Private Sub btnBefore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OFDLampiran.ShowDialog()
    End Sub

    Private Sub OFDLampiran_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OFDLampiran.FileOk
        ProgressBar1.Visible = True
        If OFDLampiran.FileName <> "" Then
            Try
                Dim FileName As String = CStr(System.IO.Path.GetFileName(OFDLampiran.FileName))
                'Dim Path As String = Application.StartupPath & "\Lampiran\"
                Dim DestinationPath As String = GetSysInit("stock_image_path") + FileName
                Dim SourcePath As String = OFDLampiran.FileName

                If System.IO.File.Exists(DestinationPath) Then
                    If MsgBox("Lampiran dengan nama yang sama sudah ada, apakah mau diganti?", vbYesNo + vbCritical, Me.Text) = vbYes Then
                        System.IO.File.Delete(DestinationPath)
                    Else
                        MsgBox("Upload lampiran dibatalkan!", vbCritical)
                        Exit Sub
                    End If
                End If

                Dim CF As New IO.FileStream(SourcePath, IO.FileMode.Open)
                Dim CT As New IO.FileStream(DestinationPath, IO.FileMode.Create)
                Dim len As Long = CF.Length - 1
                Dim buffer(1024) As Byte
                Dim byteCFead As Integer
                While CF.Position < len
                    byteCFead = (CF.Read(buffer, 0, 1024))
                    CT.Write(buffer, 0, byteCFead)
                    ProgressBar1.Value = CInt(CF.Position / len * 100)
                    Application.DoEvents()
                End While
                CT.Flush()
                CT.Close()
                CF.Close()

                MsgBox("Upload lampiran berhasil!", vbInformation)

                Dim link_after As String
                link_after = "link_after1"
                lblUpload.Text = DestinationPath


                If m_SKUId <> 0 Then
                    Try
                        cmd = New SqlCommand("update mt_sku set image_link = '" + DestinationPath + "' where sku_code = '" + txtSKUCode.Text + "' ", cn)
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        If ConnectionState.Open = 1 Then cn.Close()
                    End Try
                End If

            Catch ex As Exception
                MsgBox("Upload file gagal silahkan coba kembali!" + vbCrLf + "Error message :" + vbCrLf + ex.Message, vbCritical)
                Exit Sub
            End Try
        End If
        ProgressBar1.Visible = False
        loadImage()
    End Sub

    Sub loadImage()
        Try
            If returnImage(lblUpload.Text) = "1" Then
                original = Image.FromFile(lblUpload.Text)
                resized = ResizeImage(original, New Size(pbUpload.Size))
                pbUpload.Image = resized
            Else
                pbUpload.Image = Nothing
            End If
        Catch ex As Exception
            pbUpload.Image = Nothing
        End Try
    End Sub

    Function returnImage(ByVal ext As String) As String
        extension = Path.GetExtension(ext)
        If extension = ".jpg" Or extension = ".png" Or extension = "jpeg" Then
            Return "1"
        Else
            Return Nothing
        End If
    End Function

    Private Sub btnAfter1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        OFDLampiran.ShowDialog()
    End Sub
End Class