Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmStockAdj
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_StockAdjId As Integer
    Dim m_StockAdjDId As Integer
    Dim m_SKUId As Integer
    Dim m_LocationId As Integer
    Dim m_LocationIdBefore As Integer
    Dim m_SKUQtyBalance As Double
    Dim m_LocationQty As Double
    Dim m_StockAdjQtyBefore As Double
    Dim m_StockAdjCostBefore As Double
    Dim m_PeriodId As Integer
    Dim m_PeriodArr(0, 0) As String
    Dim m_PeriodArrSelected As Integer
    Dim isGetNum As Boolean
    Dim isAllowDelete As Boolean
    Dim isAllowStockMinus As Boolean = GetSysInit("sku_qty_minus")
    Dim isPosted As Boolean
    Private docStockAdj As ReportDocument

    Private Sub frmStockAdj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isAllowDelete = canDelete(Me.Name + "List")

        Dim prm1 As SqlParameter
        Dim prm2 As SqlParameter
        Dim myReader As SqlDataReader
        Dim i As Integer

        'Add item cmbPeriodId
        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@period_type", SqlDbType.NVarChar, 50)
        prm1.Value = "month_period"
        prm2 = cmd.Parameters.Add("@is_locked_sku", SqlDbType.Bit)
        prm2.Value = 0

        cn.Open()
        myReader = cmd.ExecuteReader

        While myReader.Read
            i += 1
        End While
        
        myReader.Close()
        cn.Close()

        'Add Period Array
        ReDim m_PeriodArr(i - 1, 3)

        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@period_type", SqlDbType.NVarChar, 50)
        prm1.Value = "month_period"
        prm2 = cmd.Parameters.Add("@is_locked_sku", SqlDbType.Bit)
        prm2.Value = 0

        cn.Open()
        myReader = cmd.ExecuteReader

        i = 0
        While myReader.Read
            m_PeriodArr(i, 0) = myReader.GetInt32(0)
            m_PeriodArr(i, 1) = myReader.GetString(1)
            m_PeriodArr(i, 2) = myReader.GetDateTime(2)
            m_PeriodArr(i, 3) = myReader.GetDateTime(3)
            i += 1
        End While

        myReader.Close()
        cn.Close()

        If i > 0 Then
            m_PeriodArrSelected = 0
            txtPeriodId.Text = m_PeriodArr(0, 1)
        End If

        If m_StockAdjId = 0 Then
            btnAdd_Click(sender, e)
        Else
            m_StockAdjDId = 0
            view_record()
            clear_lvw()
            'btnEdit_Click(sender, e)
            lock_obj(True)
            lock_objD(True)
        End If
    End Sub

    Public Property StockAdjId() As Integer
        Get
            Return m_StockAdjId
        End Get
        Set(ByVal Value As Integer)
            m_StockAdjId = Value
        End Set
    End Property

    Public Property SKUId() As Integer
        Get
            Return m_SKUId
        End Get
        Set(ByVal Value As Integer)
            m_SKUId = Value
        End Set
    End Property

    Public Property SKUCode() As String
        Get
            Return txtSKUCode.Text
        End Get
        Set(ByVal Value As String)
            txtSKUCode.Text = Value
        End Set
    End Property

    Public Property SKUName() As String
        Get
            Return txtStockAdjDesc.Text
        End Get
        Set(ByVal Value As String)
            txtStockAdjDesc.Text = Value
        End Set
    End Property

    Public Property SKUQtyBalance() As Double
        Get
            Return m_SKUQtyBalance
        End Get
        Set(ByVal Value As Double)
            m_SKUQtyBalance = Value
        End Set
    End Property

    Public Property StockAdjQty() As String
        Get
            Return ntbStockAdjQty.Text
        End Get
        Set(ByVal Value As String)
            ntbStockAdjQty.Text = Value
        End Set
    End Property

    Public Property StockAdjCost() As String
        Get
            Return ntbStockAdjCost.Text
        End Get
        Set(ByVal Value As String)
            ntbStockAdjCost.Text = Value
        End Set
    End Property

    Public Property LocationId() As Integer
        Get
            Return m_LocationId
        End Get
        Set(ByVal Value As Integer)
            m_LocationId = Value
        End Set
    End Property

    Public Property LocationCode() As String
        Get
            Return txtLocationCode.Text
        End Get
        Set(ByVal Value As String)
            txtLocationCode.Text = Value
        End Set
    End Property

    Private Sub btnSKU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSKU.Click
        Dim NewFormDialog As New fdlSKUAdj
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Sub clear_obj()
        m_StockAdjId = 0
        m_PeriodId = 0
        txtStockAdjNo.Text = ""
        txtStockAdjRemarks.Text = ""
        dtpStockAdjDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        isGetNum = True
        isPosted = False
    End Sub

    Sub clear_objD()
        m_StockAdjDId = 0
        m_SKUId = 0
        m_LocationId = 0
        m_LocationIdBefore = 0
        m_SKUQtyBalance = 0
        m_LocationQty = 0
        m_StockAdjQtyBefore = 0
        m_StockAdjCostBefore = 0
        txtSKUCode.Text = ""
        txtStockAdjDesc.Text = ""
        txtLocationCode.Text = ""
        ntbStockAdjQty.Text = 0
        ntbStockAdjCost.Text = FormatNumber(0)
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtStockAdjNo.ReadOnly = isLock
        dtpStockAdjDate.Enabled = Not isLock
        txtStockAdjRemarks.ReadOnly = isLock

        btnEdit.Enabled = isLock
        If isPosted = True Then btnEdit.Enabled = False
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnPrint.Enabled = isLock

        If m_StockAdjId = 0 Then
            txtStockAdjNo.ReadOnly = False
            btnDelete.Enabled = isLock
        Else
            txtStockAdjNo.ReadOnly = True
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        txtStockAdjDesc.ReadOnly = isLock
        ntbStockAdjQty.ReadOnly = isLock
        ntbStockAdjCost.ReadOnly = isLock

        btnLocation.Enabled = Not isLock
        btnSKU.Enabled = Not isLock
        btnSaveD.Enabled = Not isLock
        btnDeleteD.Enabled = Not isLock
        btnAddD.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("sku_id", 0)
            .Columns.Add("Stock Code", 120)
            .Columns.Add("Line Description", 330)
            .Columns.Add("location_id", 0)
            .Columns.Add("Location", 80)
            .Columns.Add("stock_balance", 0, HorizontalAlignment.Right)
            .Columns.Add("Qty", 60, HorizontalAlignment.Right)
            .Columns.Add("UoM", 50)
            .Columns.Add("Cost", 90, HorizontalAlignment.Right)
            .Columns.Add("Total Cost", 120, HorizontalAlignment.Right)
        End With

        If m_StockAdjId <> 0 Then
            cmd = New SqlCommand("usp_tr_stock_adj_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@stock_adj_id", SqlDbType.Int)
            prm1.Value = m_StockAdjId

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(2))) 'sku_id
                lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                For i = 3 To 6 'sku_code, stock_adj_description, location_id, location_code
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next
                lvItem.SubItems.Add(myReader.GetValue(7)) 'stock_balance
                lvItem.SubItems.Add(myReader.GetValue(8)) 'stock_adj_qty
                lvItem.SubItems.Add(IIf(myReader.Item(9) Is System.DBNull.Value, "", myReader.Item(9))) 'sku_uom
                For i = 10 To 11 'stock_adj_cost, stock_adj_value
                    lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
                Next
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
        End If
    End Sub

    Sub view_record()
        cmd = New SqlCommand("usp_tr_stock_adj_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@stock_adj_id", SqlDbType.Int)
        prm1.Value = m_StockAdjId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtStockAdjNo.Text = myReader.GetString(2)
            dtpStockAdjDate.Value = myReader.GetDateTime(3)

            If Not myReader.IsDBNull(myReader.GetOrdinal("stock_adj_remarks")) Then
                txtStockAdjRemarks.Text = myReader.GetString(myReader.GetOrdinal("stock_adj_remarks"))
            Else
                txtStockAdjRemarks.Text = ""
            End If

            m_PeriodId = myReader.GetInt32(11)
            isPosted = myReader.GetBoolean(12)
        End While

        myReader.Close()
        cn.Close()

        If isPosted = True Then txtPeriodId.Text = GetPeriodName(m_PeriodId)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_StockAdjId = 0
        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_StockAdjId = 0 Then
            Me.Close()
        Else
            lock_obj(True)
            lock_objD(True)
            clear_objD()
            m_StockAdjDId = 0
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
                MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                Exit Sub
            End If

            SaveStockAdjHeader()

            lock_obj(True)
            lock_objD(True)

        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        autoRefresh()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        clear_objD()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then

            AppLock.GetLock()

            cmd = New SqlCommand("usp_tr_stock_adj_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@stock_adj_id", SqlDbType.Int)
            prm1.Value = m_StockAdjId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm2.Value = My.Settings.UserName

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            AppLock.ReleaseLock()

            btnAdd_Click(sender, e)
        End If
        autoRefresh()
    End Sub

    Sub SaveStockAdjHeader()
        Try

            AppLock.GetLock()

            If ValidateCost() = False Then
                Exit Sub
            End If

            If m_StockAdjId = 0 Then
                If txtStockAdjNo.Text = "" Then
                    txtStockAdjNo.Text = GetSysNumber("stock_adjustment", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If
            End If

            cmd = New SqlCommand(IIf(m_StockAdjId = 0, "usp_tr_stock_adj_INS", "usp_tr_stock_adj_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@trans_type", SqlDbType.NVarChar, 50)
            prm1.Value = "STADJ"
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@stock_adj_no", SqlDbType.NVarChar, 50)
            prm2.Value = txtStockAdjNo.Text
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@stock_adj_date", SqlDbType.SmallDateTime)
            prm3.Value = dtpStockAdjDate.Value.Date
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@stock_adj_period_id", SqlDbType.Int)
            prm4.Value = m_PeriodArr(m_PeriodArrSelected, 0)
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@stock_adj_remarks", SqlDbType.NVarChar, 255)
            prm6.Value = IIf(txtStockAdjRemarks.Text = "", DBNull.Value, txtStockAdjRemarks.Text)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm7.Value = My.Settings.UserName
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@stock_adj_id", SqlDbType.Int)

            If m_StockAdjId = 0 Then
                prm11.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_StockAdjId = prm11.Value
                'MessageBox.Show(m_StockAdjId)
                cn.Close()
                If isGetNum = True Then UpdSysNumber("stock_adjustment")
                txtStockAdjNo.ReadOnly = True
            Else
                prm11.Value = m_StockAdjId
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                'clear_lvw()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        Finally
            AppLock.ReleaseLock()
        End Try
    End Sub

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        Try
            '#RK - 20160205_03 - Bug Fix Cost pada Stock Adjustment tidak boleh negative. bila negative gunakan average cost
            If ValidateCost() = False Then Exit Sub
            '#RK - 20160205_03 - End

            If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
                MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                Exit Sub
            End If

            SaveStockAdjHeader()

            If txtStockAdjDesc.Text = "" Then
                MsgBox("Line Description are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtStockAdjDesc.Focus()
                Exit Sub
            End If

            If m_SKUId = 0 Or m_LocationId = 0 Then
                MsgBox("Stock and Location are primary fields that should be entered. Please select before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtStockAdjDesc.Focus()
                Exit Sub
            End If

            'Check stock location
            If CDbl(ntbStockAdjQty.Text) < 0 Then
                If isAllowStockMinus = False Then
                    cmd = New SqlCommand("usp_mt_sku_location_SEL", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm21 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
                    prm21.Value = m_SKUId
                    Dim prm22 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int)
                    prm22.Value = m_LocationId

                    cn.Open()
                    Dim myReader As SqlDataReader = cmd.ExecuteReader()

                    If Not myReader.HasRows Then
                        m_LocationQty = 0
                    Else
                        myReader.Read()
                        m_LocationQty = myReader.GetValue(7) 'sku_qty
                    End If
                    myReader.Close()
                    cn.Close()
                End If
            End If
            If CDbl(ntbStockAdjQty.Text) < 0 And isAllowStockMinus = False And (CDbl(ntbStockAdjQty.Text) * -1 > m_LocationQty) Then
                MsgBox("Stock Adjustment Qty Out > Stock Location Balance", vbExclamation + vbOKOnly, Me.Text)
                ntbStockAdjQty.Text = FormatNumber(m_LocationQty * -1)
                Exit Sub
            End If

            AppLock.GetLock()

            cmd = New SqlCommand(IIf(m_StockAdjDId = 0, "usp_tr_stock_adj_dtl_INS", "usp_tr_stock_adj_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm11 As SqlParameter = cmd.Parameters.Add("@stock_adj_id", SqlDbType.Int)
            prm11.Value = m_StockAdjId
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
            prm12.Value = m_SKUId
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@stock_adj_desc", SqlDbType.NVarChar, 255)
            prm13.Value = IIf(txtStockAdjDesc.Text = "", DBNull.Value, txtStockAdjDesc.Text)
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int)
            prm14.Value = m_LocationId
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@stock_adj_qty", SqlDbType.Decimal)
            prm15.Value = CDbl(ntbStockAdjQty.Text)
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@stock_adj_cost", SqlDbType.Money)
            prm16.Value = FormatNumber(ntbStockAdjCost.Text)
            If m_StockAdjDId <> 0 Then
                Dim prm17 As SqlParameter = cmd.Parameters.Add("@stock_adj_dtl_id", SqlDbType.Int)
                prm17.Value = m_StockAdjDId
                Dim prm18 As SqlParameter = cmd.Parameters.Add("@location_id_before", SqlDbType.Int)
                prm18.Value = m_LocationIdBefore
                Dim prm19 As SqlParameter = cmd.Parameters.Add("@stock_adj_qty_before", SqlDbType.Decimal)
                prm19.Value = m_StockAdjQtyBefore
                Dim prm20 As SqlParameter = cmd.Parameters.Add("@stock_adj_cost_before", SqlDbType.Money)
                prm20.Value = m_StockAdjCostBefore
            End If
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        Finally
            AppLock.ReleaseLock()
        End Try
        autoRefresh()
    End Sub

    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD.Click
        If m_StockAdjDId = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then

            AppLock.GetLock()

            cmd = New SqlCommand("usp_tr_stock_adj_dtl_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@stock_adj_dtl_id", SqlDbType.Int)
            prm1.Value = m_StockAdjDId

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            AppLock.ReleaseLock()

            clear_lvw()
            clear_objD()

            btnSKU.Enabled = True
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1.SelectedItems.Item(0)
            m_StockAdjDId = LeftSplitUF(.Tag)
            m_SKUId = .SubItems.Item(0).Text
            txtSKUCode.Text = .SubItems.Item(1).Text
            txtStockAdjDesc.Text = .SubItems.Item(2).Text
            m_LocationId = CInt(.SubItems.Item(3).Text)
            m_LocationIdBefore = CInt(.SubItems.Item(3).Text)
            txtLocationCode.Text = .SubItems.Item(4).Text
            'm_SKUQtyBalance = .SubItems.Item(5).Text
            ntbStockAdjQty.Text = .SubItems.Item(6).Text
            m_StockAdjQtyBefore = CDbl(.SubItems.Item(6).Text)
            ntbStockAdjCost.Text = FormatNumber(.SubItems.Item(8).Text)
            m_StockAdjCostBefore = CDbl(.SubItems.Item(8).Text)

            If btnSaveD.Enabled = True Then
                btnSKU.Enabled = False
            End If
        End With
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Stk_Adj_Form '" & txtStockAdjNo.Text & "'"
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "Stk_Adj")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Stk_Adj_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Stock Adjustment"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("Stk_Adj"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub btnLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocation.Click
        If m_SKUId = 0 Then
            MsgBox("Stock information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            btnSKU.Focus()
            Exit Sub
        End If
        Dim NewFormDialog As New fdlLocation
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.SKUId = m_SKUId
        NewFormDialog.ShowDialog()
    End Sub

    Private Function ValidateCost() As Boolean
        '#RK - 20160205_03 - Bug Fix Cost pada Stock Adjustment tidak boleh negative. bila negative gunakan average cost

        If CDbl(ntbStockAdjCost.Text) < 0 Then
            'MsgBox("Cost cannot be negative", vbCritical + vbOKOnly, Me.Text)
            'get Average Cost 

            cmd = New SqlCommand("select avg_cost from mt_sku where ac ='0' and sku_code = '" & txtSKUCode.Text & "'", cn)

            cn.Open()
            Dim myReader = cmd.ExecuteReader

            While myReader.Read
                ntbStockAdjCost.Text = FormatNumber(myReader.GetValue(0))
            End While

            myReader.Close()
            cn.Close()

            ntbStockAdjCost.Focus()
            Return False
        End If

        Return True

        '#RK - 20160205_03 - End
    End Function

    Private Sub ntbStockAdjCost_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbStockAdjCost.LostFocus

        '#RK - 20160205_03 - Bug Fix Cost pada Stock Adjustment tidak boleh negative. bila negative gunakan average cost
        If ValidateCost() = False Then Exit Sub
        '#RK - 20160205_03 - End

        ntbStockAdjCost.Text = FormatNumber(ntbStockAdjCost.Text)
    End Sub

    Private Sub ntbStockAdjQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbStockAdjQty.LostFocus
        If ntbStockAdjQty.Text = "" Then ntbStockAdjQty.Text = FormatNumber(1, 0)
        If ntbStockAdjQty.DecimalValue = 0 Then ntbStockAdjQty.Text = FormatNumber(1, 0)
        'If ntbStockAdjQty.Text < 0 Then
        '    If isAllowStockMinus = False And m_SKUQtyBalance * -1 > CDbl(ntbStockAdjQty.Text) Then
        '        MsgBox("Stock Balance > Adjustment Qty minus", vbExclamation + vbOK, Me.Text)
        '        ntbStockAdjQty.Text = m_SKUQtyBalance * -1
        '    End If
        'End If
    End Sub

    Private Sub ntbStockAdjQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbStockAdjQty.TextChanged

    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        btnSKU.Enabled = True
        clear_objD()
    End Sub

    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmStockAdjList).Any Then
            Call frmStockAdjList.frmStockAdjListShow(Nothing, EventArgs.Empty)
        End If
    End Sub

    Private Sub dtpStockAdjDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpStockAdjDate.ValueChanged
        Dim isCheckIn As Boolean
        For i As Integer = 0 To m_PeriodArr.GetUpperBound(0)
            If dtpStockAdjDate.Value >= m_PeriodArr(i, 2) AndAlso dtpStockAdjDate.Value <= m_PeriodArr(i, 3) Then
                m_PeriodArrSelected = i
                m_PeriodId = m_PeriodArr(i, 0)
                txtPeriodId.Text = m_PeriodArr(i, 1)
                isCheckIn = True
                Exit For
            End If
        Next
        If isCheckIn = False Then
            m_PeriodId = 0
            txtPeriodId.Text = m_PeriodArr(0, 1)
        End If
    End Sub

    Private Sub ntbStockAdjCost_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbStockAdjCost.TextChanged

    End Sub

    Private Sub ProcessImportFromCsv(filename As String)
        '20160711 daniel s

        Dim lines As String() = System.IO.File.ReadAllLines(filename)
        Dim i As Integer = 0
        Dim ErrorMsg As String = ""
        For Each line As String In lines
            i += 1
            'validate data
            Dim kol As String() = line.Split(",".ToCharArray())

            If kol.Length < 5 Then
                ErrorMsg &= "line " & i.ToString & " : invalid line format" & vbCrLf
                Continue For
            End If

            Dim sku_code As String = kol(0)
            Dim sku_desc As String = kol(1)
            Dim loc As String = kol(2)
            Dim qty As String = kol(3)
            Dim cost As String = kol(4)

            'validate sku code
            cmd = New SqlCommand("select * from mt_sku where ac ='0' and sku_code = @param", cn)
            cmd.Parameters.AddWithValue("@param", sku_code)
            cn.Open()

            Dim dr = cmd.ExecuteReader
            If Not dr.Read Then
                'sku code not exist
                ErrorMsg &= "line " & i.ToString & " : invalid stock code" & vbCrLf
            End If
            dr.Close()
            cn.Close()

            'validate location code
            cmd = New SqlCommand("select * from mt_location where ac ='0' and location_code = @param", cn)
            cmd.Parameters.AddWithValue("@param", loc)
            cn.Open()

            dr = cmd.ExecuteReader
            If Not dr.Read Then
                'location code not exist
                ErrorMsg &= "line " & i.ToString & " : invalid location code" & vbCrLf
            End If
            dr.Close()
            cn.Close()

            'validate desc
            If sku_desc.Length = 0 Then
                ErrorMsg &= "line " & i.ToString & " : invalid description" & vbCrLf
            End If

            'validate qty
            Dim x As Double
            If Double.TryParse(qty, x) = False Then
                ErrorMsg &= "line " & i.ToString & " : invalid quantity" & vbCrLf
            Else
                If x = 0 Then
                    ErrorMsg &= "line " & i.ToString & " : quantity must be <> 0" & vbCrLf
                End If
            End If

            'validate cost
            If Double.TryParse(cost, x) = False Then
                ErrorMsg &= "line " & i.ToString & " : invalid cost" & vbCrLf
            Else
                If x < 0 Then
                    ErrorMsg &= "line " & i.ToString & " : cost must be > 0" & vbCrLf
                End If
            End If

        Next

        If ErrorMsg.Length > 0 Then
            MessageBox.Show(ErrorMsg, "Please Fix All Error Then Import Again")
            Exit Sub
        End If

        If MessageBox.Show(i & " line from " + OpenCsvFileDialog.FileName & " validated OK, continue to save to database ?", "Import Csv File Confirmation", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        'save to database
        'save header first
        SaveStockAdjHeader()

        AppLock.GetLock()

        'save detail
        i = 0
        For Each line As String In lines
            i += 1

            Dim kol As String() = line.Split(",".ToCharArray())

            Dim sku_code As String = kol(0)
            Dim sku_desc As String = kol(1)
            Dim loc As String = kol(2)
            Dim qty As String = kol(3)
            Dim cost As String = kol(4)

            'get sku id
            Dim sku_id As Object
            cmd = New SqlCommand("select sku_id from mt_sku where ac ='0' and sku_code = @param", cn)
            cmd.Parameters.AddWithValue("@param", sku_code)
            cn.Open()

            Dim dr = cmd.ExecuteReader
            If dr.Read Then
                sku_id = dr.GetValue(0)
            End If
            dr.Close()
            cn.Close()

            'get location id
            Dim loc_id As Object
            cmd = New SqlCommand("select location_id from mt_location where ac ='0' and location_code = @param", cn)
            cmd.Parameters.AddWithValue("@param", loc)
            cn.Open()

            dr = cmd.ExecuteReader
            If dr.Read Then
                loc_id = dr.GetValue(0)
            End If
            dr.Close()
            cn.Close()



            cmd = New SqlCommand("usp_tr_stock_adj_dtl_INS", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm11 As SqlParameter = cmd.Parameters.Add("@stock_adj_id", SqlDbType.Int)
            prm11.Value = m_StockAdjId

            Dim prm12 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
            prm12.Value = sku_id

            Dim prm13 As SqlParameter = cmd.Parameters.Add("@stock_adj_desc", SqlDbType.NVarChar, 255)
            prm13.Value = sku_desc

            Dim prm14 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int)
            prm14.Value = loc_id

            Dim prm15 As SqlParameter = cmd.Parameters.Add("@stock_adj_qty", SqlDbType.Decimal)
            prm15.Value = CDbl(qty)

            Dim prm16 As SqlParameter = cmd.Parameters.Add("@stock_adj_cost", SqlDbType.Money)
            prm16.Value = FormatNumber(cost)

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

        Next

        AppLock.ReleaseLock()

    End Sub

    Private Sub btn_import_from_csv_Click(sender As System.Object, e As System.EventArgs) Handles btn_import_from_csv.Click
        '20160712 daniel s : help user to insert bulk stock adjust via csv file
        If OpenCsvFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                ProcessImportFromCsv(OpenCsvFileDialog.FileName)

                clear_lvw()
                clear_objD()
                autoRefresh()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "System Error")
            Finally
                AppLock.ReleaseLock()
            End Try
        End If
    End Sub
End Class
