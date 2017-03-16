Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmBC
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_BCId As Integer
    Dim m_CId As Integer
    Dim m_BCProcessType As String
    Dim m_BCDId As Integer
    Dim m_SDeliveryDId As Integer
    Dim m_CurrId As Integer
    Dim isGetNum As Boolean
    Dim isAllowDelete As Boolean
    Private docPO As ReportDocument

    Private Sub frmPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolTip1.SetToolTip(btnCustomer, "Search Supplier")
        ToolTip1.SetToolTip(btnSaveD, "Save Line")
        ToolTip1.SetToolTip(btnDeleteD, "Delete Line")
        ToolTip1.SetToolTip(btnAddD, "Add Line")

        isAllowDelete = canDelete(Me.Name + "List")

        Dim prm1 As SqlParameter
        Dim myReader As SqlDataReader

        'Add item cmbPOType
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "bc_process_type"

        cn.Open()
        myReader = cmd.ExecuteReader

        cmbBCProcessType.Items.Clear()
        While myReader.Read
            cmbBCProcessType.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While
        cmbBCProcessType.SelectedIndex = 0

        myReader.Close()
        cn.Close()

        If m_BCId = 0 Then
            btnAdd_Click(sender, e)
        Else
            m_BCDId = 0
            view_record()
            clear_lvw()
            'btnEdit_Click(sender, e)
            clear_objD()
            lock_obj(True)
            lock_objD(True)
        End If
    End Sub

    Private Sub btnSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomer.Click
        Dim NewFormDialog As New fdlCustomer
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Public Property BCId() As Integer
        Get
            Return m_BCId
        End Get
        Set(ByVal Value As Integer)
            m_BCId = Value
        End Set
    End Property

    Public Property CId() As Integer
        Get
            Return m_CId
        End Get
        Set(ByVal Value As Integer)
            m_CId = Value
        End Set
    End Property

    Public Property CCode() As String
        Get
            Return txtCCode.Text
        End Get
        Set(ByVal Value As String)
            txtCCode.Text = Value
        End Set
    End Property

    Public Property CName() As String
        Get
            Return txtCName.Text
        End Get
        Set(ByVal Value As String)
            txtCName.Text = Value
        End Set
    End Property

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
            Return txtCurrCode.Text
        End Get
        Set(ByVal Value As String)
            txtCurrCode.Text = Value
        End Set
    End Property

    Public Property CurrRate() As String
        Get
            Return ntbBCCurrRate.Text
        End Get
        Set(ByVal Value As String)
            ntbBCCurrRate.Text = Value
        End Set
    End Property

    Public Property GetNumCheck() As Boolean
        Get
            Return isGetNum
        End Get
        Set(ByVal Value As Boolean)
            isGetNum = Value
        End Set
    End Property

    Public Property SKUName() As String
        Get
            Return txtBCDtlDesc.Text
        End Get
        Set(ByVal Value As String)
            txtBCDtlDesc.Text = Value
        End Set
    End Property

    Public Property SKUUoM() As String
        Get
            Return txtSKUUoM.Text
        End Get
        Set(ByVal Value As String)
            txtSKUUoM.Text = Value
        End Set
    End Property

    Public Property PRequestId() As Integer
        Get
            Return m_SDeliveryDId
        End Get
        Set(ByVal Value As Integer)
            m_SDeliveryDId = Value
        End Set
    End Property

    Public Property PRequestNo() As String
        Get
            Return txtSDeliveryNo.Text
        End Get
        Set(ByVal Value As String)
            txtSDeliveryNo.Text = Value
        End Set
    End Property

    Public Property POQty() As Integer
        Get
            Return ntbSDeliveryQty.Text
        End Get
        Set(ByVal Value As Integer)
            ntbSDeliveryQty.Text = Value
        End Set
    End Property

    Public Property UnitPrice() As String
        Get
            Return ntbBCDtlPrice.Text
        End Get
        Set(ByVal Value As String)
            ntbBCDtlPrice.Text = Value
        End Set
    End Property

    Sub clear_obj()
        m_BCId = 0
        m_CId = 0
        m_CurrId = 0
        txtBCNo.Text = ""
        dtpBCDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        dtpBCContractDate.Checked = True
        dtpBCContractDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtCCode.Text = ""
        txtCName.Text = ""
        txtCurrCode.Text = ""
        ntbBCCurrRate.Text = FormatNumber("1")
        txtBCRemarks.Text = ""
        txtBCTrfPriceTotal.Text = FormatNumber("0")
        txtBCSumPackQty.Text = FormatNumber("0")
        txtBCSumGrossWeight.Text = FormatNumber("0")
        txtBCNetWeight.Text = FormatNumber("0")
        isGetNum = True

        ''Add item cmbCurrId
        'Dim prm1 As SqlParameter
        'Dim myReader As SqlDataReader
        'cmd = New SqlCommand("usp_mt_curr_SEL", cn)
        'cmd.CommandType = CommandType.StoredProcedure

        'prm1 = cmd.Parameters.Add("@base_curr", SqlDbType.Bit)
        'prm1.Value = 1

        'cn.Open()
        'myReader = cmd.ExecuteReader
        'While myReader.Read
        '    m_CurrId = myReader.GetInt32(0)
        '    txtCurrCode.Text = myReader.GetString(1)
        '    ntbPOCurrRate.Text = FormatNumber(myReader.Item(4))
        'End While
        'myReader.Close()
        'cn.Close()
    End Sub

    Sub clear_objD()
        m_BCDId = 0
        m_SDeliveryDId = 0
        txtSDeliveryNo.Text = ""
        txtBCDtlDesc.Text = ""
        ntbSDeliveryQty.Text = FormatNumber(0)
        txtSKUUoM.Text = ""
        ntbBCDtlPrice.Text = FormatNumber(0)
        txtBCDtlPackQty.Text = FormatNumber(0)
        txtBCDtlGrossWeight.Text = FormatNumber(0)
        txtBCDtlNetWeight.Text = FormatNumber(0)
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        dtpBCDate.Enabled = Not isLock
        txtBCContractNo.ReadOnly = isLock
        dtpBCContractDate.Enabled = Not isLock
        cmbBCProcessType.Enabled = Not isLock
        ntbBCCurrRate.ReadOnly = isLock
        txtBCRemarks.ReadOnly = isLock
        btnCustomer.Enabled = Not isLock

        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnPrint.Enabled = isLock
        btnPrintGroup.Enabled = isLock

        If m_BCId = 0 Then
            txtBCNo.ReadOnly = False
            btnCustomer.Enabled = True
            btnDelete.Enabled = isLock
        Else
            txtBCNo.ReadOnly = True
            btnCustomer.Enabled = False
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        'txtBCDtlDesc.ReadOnly = isLock
        btnSDelivery.Enabled = Not isLock
        btnSaveD.Enabled = Not isLock
        btnDeleteD.Enabled = Not isLock
        btnAddD.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("bc_id", 0)
            .Columns.Add("sdelivery_dtl_id", 0)
            .Columns.Add("Sales Delivery No.", 120)
            .Columns.Add("sku_code", 0)
            .Columns.Add("Line Description", 250)
            .Columns.Add("Delivered Qty", 90, HorizontalAlignment.Right)
            .Columns.Add("UoM", 60)
            .Columns.Add("Harga Penyerahan", 120, HorizontalAlignment.Right)
            .Columns.Add("Jumlah Kemasan", 100, HorizontalAlignment.Right)
            .Columns.Add("Berat Kotor (Kg)", 100, HorizontalAlignment.Right)
            .Columns.Add("Berat Bersih (Kg)", 100, HorizontalAlignment.Right)

            '.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
            '.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize)
            '.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.ColumnContent)
        End With

        If m_BCId <> 0 Then
            cmd = New SqlCommand("usp_tr_bc_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@bc_id", SqlDbType.Int)
            prm1.Value = m_BCId

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(1)))
                lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                For i = 2 To 5
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next
                lvItem.SubItems.Add(myReader.GetValue(6)) 'sdelivery_qty
                If myReader.Item(7) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(7)) 'sku_uom
                End If
                For i = 8 To 11
                    lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
                    'If i = 5 Then
                    '    lvItem.SubItems.Add(FormatNumber(myReader.Item(i), 0))
                    'Else
                    '    lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
                    'End If
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
        cmd = New SqlCommand("usp_tr_bc_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@bc_id", SqlDbType.Int)
        prm1.Value = m_BCId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtBCNo.Text = myReader.GetString(1)
            dtpBCDate.Value = myReader.GetDateTime(2)
            m_CId = myReader.GetInt32(3)
            txtCCode.Text = myReader.GetString(4)
            txtCName.Text = myReader.GetString(5)
            m_BCProcessType = myReader.GetString(6)
            If Not myReader.IsDBNull(myReader.GetOrdinal("bc_contract_no")) Then
                txtBCContractNo.Text = myReader.GetString(myReader.GetOrdinal("bc_contract_no"))
            Else
                txtBCContractNo.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("bc_contract_date")) Then
                dtpBCContractDate.Checked = True
                dtpBCContractDate.Value = myReader.GetDateTime(myReader.GetOrdinal("bc_contract_date"))
            Else
                dtpBCContractDate.Checked = False
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("bc_remarks")) Then
                txtBCRemarks.Text = myReader.GetString(myReader.GetOrdinal("bc_remarks"))
            Else
                txtBCRemarks.Text = ""
            End If
            m_CurrId = myReader.GetInt32(11)
            txtCurrCode.Text = myReader.GetString(12)
            ntbBCCurrRate.Text = FormatNumber(myReader.GetValue(13))
            txtBCTrfPriceTotal.Text = FormatNumber(myReader.GetValue(14))
            txtBCSumPackQty.Text = FormatNumber(myReader.GetValue(15))
            txtBCSumGrossWeight.Text = FormatNumber(myReader.GetValue(16))
            txtBCNetWeight.Text = FormatNumber(myReader.GetValue(17))
        End While

        myReader.Close()
        cn.Close()

        Dim mList As clsMyListStr
        Dim i As Integer
        For i = 1 To cmbBCProcessType.Items.Count
            mList = cmbBCProcessType.Items(i - 1)
            If m_BCProcessType = mList.ItemData Then
                cmbBCProcessType.SelectedIndex = i - 1
                Exit For
            End If
        Next
    End Sub

    Sub refresh_total()
        cmd = New SqlCommand("usp_tr_bc_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@bc_id", SqlDbType.Int)
        prm1.Value = m_BCId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtBCTrfPriceTotal.Text = FormatNumber(myReader.GetValue(14))
            txtBCSumPackQty.Text = FormatNumber(myReader.GetValue(15))
            txtBCSumGrossWeight.Text = FormatNumber(myReader.GetValue(16))
            txtBCNetWeight.Text = FormatNumber(myReader.GetValue(17))
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_BCId = 0
        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_BCId = 0 Then
            Me.Close()
        Else
            lock_obj(True)
            lock_objD(True)
            clear_objD()
            m_BCDId = 0
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If m_CId = 0 Then
                MsgBox("Customer Code and Customer Name are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtCCode.Focus()
                Exit Sub
            End If

            If m_BCId = 0 Then
                If txtBCNo.Text = "" Then
                    txtBCNo.Text = GetSysNumber("bc", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If
            End If

            cmd = New SqlCommand(IIf(m_BCId = 0, "usp_tr_bc_INS", "usp_tr_bc_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@bc_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtBCNo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@bc_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpBCDate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm3.Value = m_CId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@bc_process_type", SqlDbType.NVarChar, 50)
            prm4.Value = cmbBCProcessType.Items(cmbBCProcessType.SelectedIndex).ItemData()
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@bc_contract_no", SqlDbType.NVarChar, 50)
            prm5.Value = IIf(txtBCContractNo.Text = "", DBNull.Value, txtBCContractNo.Text)
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@bc_contract_date", SqlDbType.SmallDateTime)
            prm6.Value = IIf(dtpBCContractDate.Checked = True, dtpBCContractDate.Value, DBNull.Value)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@bc_remarks", SqlDbType.NVarChar, 255)
            prm7.Value = IIf(txtBCRemarks.Text = "", DBNull.Value, txtBCRemarks.Text)
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm11.Value = m_CurrId
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@bc_curr_rate", SqlDbType.Money)
            prm12.Value = FormatNumber(ntbBCCurrRate.Text)
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm15.Value = My.Settings.UserName
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@bc_id", SqlDbType.Int)

            If m_BCId = 0 Then
                prm16.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_BCId = prm16.Value
                'MessageBox.Show(m_BCId)
                cn.Close()
                If isGetNum = True Then UpdSysNumber("bc")
            Else
                prm16.Value = m_BCId
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                'clear_lvw()
            End If

            lock_obj(True)
            lock_objD(True)
            autoRefresh()
        Catch ex As Exception
            'If Err.Number = 5 Then
            '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
            'Else
            MsgBox(ex.Message)
            'End If
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        clear_objD()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_tr_bc_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@bc_id", SqlDbType.Int)
            prm1.Value = m_BCId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm2.Value = My.Settings.UserName

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            btnAdd_Click(sender, e)
        End If
        autoRefresh()
    End Sub

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        Try
            If m_BCId = 0 Then
                If m_CId = 0 Then
                    MsgBox("Customer Code and Customer Name are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                    txtCCode.Focus()
                    Exit Sub
                End If
                SaveBCHeader()
            End If

            If txtBCDtlDesc.Text = "" Then
                MsgBox("Line Description are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtBCDtlDesc.Focus()
                Exit Sub
            End If

            cmd = New SqlCommand(IIf(m_BCDId = 0, "usp_tr_bc_dtl_INS", "usp_tr_bc_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm17 As SqlParameter = cmd.Parameters.Add("@bc_id", SqlDbType.Int)
            prm17.Value = m_BCId
            Dim prm18 As SqlParameter = cmd.Parameters.Add("@sdelivery_dtl_id", SqlDbType.Int)
            prm18.Value = m_SDeliveryDId
            Dim prm19 As SqlParameter = cmd.Parameters.Add("@bc_dtl_desc", SqlDbType.NVarChar, 255)
            prm19.Value = IIf(txtBCDtlDesc.Text = "", DBNull.Value, txtBCDtlDesc.Text)
            Dim prm20 As SqlParameter = cmd.Parameters.Add("@bc_dtl_price", SqlDbType.Money)
            prm20.Value = IIf(ntbBCDtlPrice.Text = "0", 0, ntbBCDtlPrice.Text)
            Dim prm21 As SqlParameter = cmd.Parameters.Add("@bc_dtl_pack_qty", SqlDbType.NChar)
            prm21.Value = txtBCDtlPackQty.Text
            Dim prm22 As SqlParameter = cmd.Parameters.Add("@bc_dtl_gross_weight", SqlDbType.NChar)
            prm22.Value = txtBCDtlGrossWeight.Text
            Dim prm23 As SqlParameter = cmd.Parameters.Add("@bc_dtl_net_weight", SqlDbType.NChar)
            prm23.Value = txtBCDtlNetWeight.Text

            If m_BCDId <> 0 Then
                Dim prm24 As SqlParameter = cmd.Parameters.Add("@bc_dtl_id", SqlDbType.Int)
                prm24.Value = m_BCDId
            End If
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()
            refresh_total()
            autoRefresh()
        Catch ex As Exception
            'If Err.Number = 5 Then
            '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
            'Else
            MsgBox(ex.Message)
            'End If
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Sub SaveBCHeader()
        Try
            If txtBCNo.Text = "" Then
                txtBCNo.Text = GetSysNumber("bc", Now.Date)
                isGetNum = True
            Else
                isGetNum = False
            End If

            cmd = New SqlCommand("usp_tr_bc_INS", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@bc_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtBCNo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@bc_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpBCDate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm3.Value = m_CId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@bc_process_type", SqlDbType.NVarChar, 50)
            prm4.Value = cmbBCProcessType.Items(cmbBCProcessType.SelectedIndex).ItemData()
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@bc_contract_no", SqlDbType.NVarChar, 50)
            prm5.Value = IIf(txtBCContractNo.Text = "", DBNull.Value, txtBCContractNo.Text)
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@bc_contract_date", SqlDbType.SmallDateTime)
            prm6.Value = IIf(dtpBCContractDate.Checked = True, dtpBCContractDate.Value, DBNull.Value)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@bc_remarks", SqlDbType.NVarChar, 255)
            prm7.Value = IIf(txtBCRemarks.Text = "", DBNull.Value, txtBCRemarks.Text)
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm11.Value = m_CurrId
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@bc_curr_rate", SqlDbType.Money)
            prm12.Value = FormatNumber(ntbBCCurrRate.Text)
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm15.Value = My.Settings.UserName
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@bc_id", SqlDbType.Int)
            prm16.Direction = ParameterDirection.Output

            cn.Open()
            cmd.ExecuteReader()
            m_BCId = prm16.Value
            cn.Close()
            If isGetNum = True Then UpdSysNumber("bc")
            txtBCNo.ReadOnly = True

        Catch ex As Exception
            'If Err.Number = 5 Then
            '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
            'Else
            MsgBox(ex.Message)
            'End If
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD.Click
        If m_BCDId = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_tr_bc_dtl_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@bc_dtl_id", SqlDbType.Int)
            prm1.Value = m_BCDId

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()
            refresh_total()
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1.SelectedItems.Item(0)
            m_BCDId = LeftSplitUF(.Tag)
            m_SDeliveryDId = .SubItems.Item(1).Text
            txtSDeliveryNo.Text = .SubItems.Item(2).Text
            txtBCDtlDesc.Text = .SubItems.Item(4).Text
            ntbSDeliveryQty.Text = .SubItems.Item(5).Text
            txtSKUUoM.Text = IIf(.SubItems.Item(6).Text = "", "", .SubItems.Item(6).Text)
            ntbBCDtlPrice.Text = FormatNumber(.SubItems.Item(7).Text)
            txtBCDtlPackQty.Text = FormatNumber(.SubItems.Item(8).Text)
            txtBCDtlGrossWeight.Text = .SubItems.Item(9).Text
            txtBCDtlNetWeight.Text = .SubItems.Item(10).Text
        End With
    End Sub

    Private Sub ntbPOPrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbBCDtlPrice.LostFocus
        ntbBCDtlPrice.Text = FormatNumber(ntbBCDtlPrice.Text)
    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        clear_objD()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_BC40_Form '" & txtBCNo.Text & "' "
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "BC40_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_BC40_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "BC 4.0"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("BC40_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub btnSDelivery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSDelivery.Click
        If m_CId = 0 Then
            MsgBox("Customer information are primary fields that should be entered. Please enter those fields before you do the selection.", vbCritical + vbOKOnly, Me.Text)
            txtCCode.Focus()
            Exit Sub
        End If
        Dim NewFormDialog As New fdlSDeliveryOutBC
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub ntbPOCurrRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbBCCurrRate.LostFocus
        ntbBCCurrRate.Text = FormatNumber(ntbBCCurrRate.Text)
    End Sub

    Private Sub ntbPOQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbSDeliveryQty.TextChanged

    End Sub

    Private Sub ntbPOTaxPercent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnPrintGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintGroup.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_BC40_Form_Group '" & txtBCNo.Text & "' "
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "BC40Group_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_BC40_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "BC 4.0"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("BC40Group_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub
    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmBCList).Any Then
            Call frmBCList.frmBCListShow(Nothing, EventArgs.Empty)
        End If
    End Sub
End Class
