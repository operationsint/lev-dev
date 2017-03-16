Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmStockCostAdj
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_StockAdjId As Integer
    Dim m_StockAdjDId As Integer
    Dim m_StockAdjValueBefore As Double
    Dim isGetNum As Boolean
    Dim isAllowDelete As Boolean
    Dim isAllowStockMinus As Boolean = GetSysInit("sku_qty_minus")
    Dim m_PeriodId As Integer
    Dim m_PeriodArr(0, 0) As String
    Dim m_PeriodArrSelected As Integer
    Dim isPosted As Boolean
    Private docStockAdj As ReportDocument

    Private Sub frmStockCostAdj_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
    Public Property StockAdjNo() As String
        Get
            Return txtStockAdjNo.Text
        End Get
        Set(ByVal Value As String)
            txtStockAdjNo.Text = Value
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

    Public Property StockAdjCost() As String
        Get
            Return ntbStockAdjValue.Text
        End Get
        Set(ByVal Value As String)
            ntbStockAdjValue.Text = Value
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
        m_StockAdjValueBefore = 0
        txtSKUCode.Text = ""
        txtStockAdjDesc.Text = ""
        ntbStockAdjValue.Text = FormatNumber(0, 2)
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
        ntbStockAdjValue.ReadOnly = isLock
        btnSKU.Enabled = Not isLock
        btnSaveD.Enabled = Not isLock
        btnDeleteD.Enabled = Not isLock
        btnAddD.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("stock_cost_adj_id", 0)
            .Columns.Add("Stock Code", 170)
            .Columns.Add("Line Description", 430)
            .Columns.Add("Value", 170, HorizontalAlignment.Right)
        End With

        If m_StockAdjId <> 0 Then
            cmd = New SqlCommand("usp_tr_stock_cost_adj_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@stock_cost_adj_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtStockAdjNo.Text

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(0))) 'sku_id
                lvItem.Tag = intCurrRow 'ID
                For i = 1 To 2
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next
                lvItem.SubItems.Add(myReader.GetValue(3)) 'stock_balance
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
    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        'With ListView1.SelectedItems.Item(0)
        '    m_StockAdjDId = .SubItems.Item(0).Text
        '    txtSKUCode.Text = .SubItems.Item(1).Text
        '    txtStockAdjDesc.Text = .SubItems.Item(2).Text
        '    ntbStockAdjValue.Text = FormatNumber(.SubItems.Item(3).Text, 2)
        '    m_StockAdjValueBefore = CDbl(.SubItems.Item(3).Text)

        '    If btnSaveD.Enabled = True Then
        '        btnSKU.Enabled = False
        '        btnDeleteD.Enabled = False
        '    End If
        'End With
    End Sub

    Sub view_record()
        cmd = New SqlCommand("usp_tr_stock_cost_adj_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@stock_cost_adj_id", SqlDbType.Int)
        prm1.Value = m_StockAdjId
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@stock_cost_adj_no", SqlDbType.NVarChar, 50)
        prm2.Value = txtStockAdjNo.Text

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtStockAdjNo.Text = myReader.GetString(0)
            dtpStockAdjDate.Value = myReader.GetDateTime(2)

            If Not myReader.IsDBNull(myReader.GetOrdinal("stock_cost_adj_remarks")) Then
                txtStockAdjRemarks.Text = myReader.GetString(myReader.GetOrdinal("stock_cost_adj_remarks"))
            Else
                txtStockAdjRemarks.Text = ""
            End If

            m_PeriodId = myReader.GetInt32(12)
            isPosted = myReader.GetBoolean(9)
        End While

        myReader.Close()
        cn.Close()
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
            If m_StockAdjId = 0 Then
                If txtStockAdjNo.Text = "" Then
                    txtStockAdjNo.Text = GetSysNumber("stock_cost", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If
            End If

            AppLock.GetLock()

            cmd = New SqlCommand(IIf(m_StockAdjId = 0, "usp_tr_stock_cost_adj_INS", "usp_tr_stock_cost_adj_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@trans_type", SqlDbType.NVarChar, 5)
            prm1.Value = "STCST"
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@stock_cost_adj_no", SqlDbType.NVarChar, 50)
            prm2.Value = txtStockAdjNo.Text
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@stock_cost_adj_date", SqlDbType.SmallDateTime)
            prm3.Value = dtpStockAdjDate.Value.Date
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@stock_cost_adj_remarks", SqlDbType.NVarChar, 255)
            prm4.Value = IIf(txtStockAdjRemarks.Text = "", "-", txtStockAdjRemarks.Text)
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm5.Value = My.Settings.UserName
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@stock_cost_adj_period_id", SqlDbType.Int)
            prm14.Value = m_PeriodArr(m_PeriodArrSelected, 0)

            If m_StockAdjId = 0 Then
                cn.Open()
                cmd.ExecuteReader()
                m_StockAdjId = 1
                cn.Close()
                If isGetNum = True Then UpdSysNumber("stock_cost")
                txtStockAdjNo.ReadOnly = True
            Else
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

            If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
                MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                Exit Sub
            End If

            SaveStockAdjHeader()

            If txtSKUCode.Text = "" Then
                MsgBox("Please insert Stock Code!", vbCritical + vbOKOnly, Me.Text)
                txtSKUCode.Focus()
                Exit Sub
            End If

            If txtStockAdjDesc.Text = "" Then
                MsgBox("Line description cannot empty !", vbCritical + vbOKOnly, Me.Text)
                txtStockAdjDesc.Focus()
                Exit Sub
            End If

            If CDbl(ntbStockAdjValue.Text) = 0 Then
                If MsgBox("Value is 0.00 ," + vbCrLf + "Are you sure want to insert Stock Cost Adjustment ?", vbYesNo + vbCritical, Me.Text) = vbNo Then
                    Exit Sub
                End If
            End If

            AppLock.GetLock()

            cmd = New SqlCommand("usp_tr_stock_cost_adj_dtl_INS", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm11 As SqlParameter = cmd.Parameters.Add("@stock_cost_adj_no", SqlDbType.NVarChar, 50)
            prm11.Value = txtStockAdjNo.Text
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@stock_code", SqlDbType.NVarChar, 50)
            prm12.Value = txtSKUCode.Text
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@stock_cost_adj_desc", SqlDbType.NVarChar, 255)
            prm13.Value = txtStockAdjDesc.Text
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@stock_adj_value", SqlDbType.Decimal)
            prm16.Value = FormatNumber(ntbStockAdjValue.Text, 2)
            'If m_StockAdjDId <> 0 Then
            '    Dim prm17 As SqlParameter = cmd.Parameters.Add("@stock_cost_adj_dtl_id", SqlDbType.Int)
            '    prm17.Value = m_StockAdjDId
            '    Dim prm20 As SqlParameter = cmd.Parameters.Add("@stock_adj_value_before", SqlDbType.Decimal)
            '    prm20.Value = m_StockAdjValueBefore
            'End If
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

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Stk_Cost_Adj_Form '" & txtStockAdjNo.Text & "'"
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "Stk_Cost_Adj")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Stk_Cost_Adj_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Stock Cost Adjustment"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("Stk_Cost_Adj"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub ntbStockAdjCost_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbStockAdjValue.LostFocus
        ntbStockAdjValue.Text = FormatNumber(ntbStockAdjValue.Text)
    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        btnSKU.Enabled = True
        clear_objD()
    End Sub
    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmStockCostAdjList).Any Then
            Call frmStockCostAdjList.frmStockCostAdjListShow(Nothing, EventArgs.Empty)
        End If
    End Sub

    Private Sub dtpStockAdjDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpStockAdjDate.ValueChanged
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
End Class