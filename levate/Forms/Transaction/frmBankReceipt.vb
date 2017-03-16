Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmBankReceipt
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_BankTransId As Integer
    Dim m_BankTransDId As Integer

    Dim m_BankBalance As Double
    Dim m_net_amount_before_detail As Double
    Dim m_local_net_amount_before_detail As Double

    Dim m_CurrId As Integer
    Dim isGetNum As Boolean
    Dim isAllowDelete As Boolean
    Dim isAllowBankMinus As Boolean = GetSysInit("bank_amount_minus")
    Dim m_TaxPercent As Single
    Private docStockAdj As ReportDocument
    Dim m_PaymentType As String
    Dim m_CurrBaseId As Integer
    Dim m_CurrBaseCode As String

    Dim m_PeriodId As Integer
    Dim m_PeriodArr(0, 0) As String
    Dim isPosted As Boolean


    Private Sub frmBankReceipt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim prm1 As SqlParameter
        Dim prm2 As SqlParameter
        Dim prm3 As SqlParameter
        Dim prm4 As SqlParameter
        Dim myReader As SqlDataReader
        Dim i As Integer = 0

        isAllowDelete = canDelete(Me.Name + "List")
        m_TaxPercent = GetSysInit("tax_percent") * 100

        'Add item cmbPeriodId
        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@period_type", SqlDbType.NVarChar, 50)
        prm1.Value = "month_period"
        prm2 = cmd.Parameters.Add("@is_locked_bank", SqlDbType.Bit)
        prm2.Value = 0

        cn.Open()
        myReader = cmd.ExecuteReader

        cmbPeriodId.Items.Clear()
        While myReader.Read
            cmbPeriodId.Items.Add(New clsMyListInt(myReader.GetString(1), myReader.GetInt32(0)))
            i += 1
        End While
        If cmbPeriodId.Items.Count > 0 Then cmbPeriodId.SelectedIndex = 0

        myReader.Close()
        cn.Close()

        'Add Period Array
        ReDim m_PeriodArr(i - 1, 2)

        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@period_type", SqlDbType.NVarChar, 50)
        prm1.Value = "month_period"
        prm2 = cmd.Parameters.Add("@is_locked_bank", SqlDbType.Bit)
        prm2.Value = 0

        cn.Open()
        myReader = cmd.ExecuteReader

        i = 0
        While myReader.Read
            m_PeriodArr(i, 0) = myReader.GetInt32(0)
            m_PeriodArr(i, 1) = myReader.GetDateTime(2)
            m_PeriodArr(i, 2) = myReader.GetDateTime(3)
            i += 1
        End While

        myReader.Close()
        cn.Close()

        'Base Currency
        cmd = New SqlCommand("usp_mt_curr_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm3 = cmd.Parameters.Add("@base_curr", SqlDbType.Bit)
        prm3.Value = 1

        cn.Open()
        myReader = cmd.ExecuteReader

        While myReader.Read
            m_CurrBaseId = myReader.GetInt32(0)
            m_CurrBaseCode = myReader.GetString(1)
        End While

        myReader.Close()
        cn.Close()

        'Add item cmbPaymentType
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm4 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm4.Value = "payment_type"

        cn.Open()
        myReader = cmd.ExecuteReader

        cmbPaymentMethod.Items.Clear()
        While myReader.Read
            cmbPaymentMethod.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While
        cmbPaymentMethod.SelectedIndex = 0

        myReader.Close()
        cn.Close()

        If m_BankTransId = 0 Then
            btnAdd_Click(sender, e)
        Else
            m_BankTransDId = 0
            view_record()
            clear_lvw()
            'btnEdit_Click(sender, e)
            lock_obj(True)
            lock_objD(True)
        End If
    End Sub

    Public Property BankTransId() As Integer
        Get
            Return m_BankTransId
        End Get
        Set(ByVal Value As Integer)
            m_BankTransId = Value
        End Set
    End Property

    Public Property BankTransNo() As String
        Get
            Return txtBankTransNo.Text
        End Get
        Set(ByVal Value As String)
            txtBankTransNo.Text = Value
        End Set
    End Property

    Public Property BankBalance() As Double
        Get
            Return m_BankBalance
        End Get
        Set(ByVal Value As Double)
            m_BankBalance = Value
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
            Return txtCurrencyCode.Text
        End Get
        Set(ByVal Value As String)
            txtCurrencyCode.Text = Value
        End Set
    End Property

    Public Property ExpincCode() As String
        Get
            Return txtExpincCode.Text
        End Get
        Set(ByVal Value As String)
            txtExpincCode.Text = Value
        End Set
    End Property

    Public Property ExpincName() As String
        Get
            Return txtLineDesc.Text
        End Get
        Set(ByVal Value As String)
            txtLineDesc.Text = Value
        End Set
    End Property

    Public Property BankCode() As String
        Get
            Return txtBankCode.Text
        End Get
        Set(ByVal Value As String)
            txtBankCode.Text = Value
        End Set
    End Property

    Public Property BankName() As String
        Get
            Return txtBankName.Text
        End Get
        Set(ByVal Value As String)
            txtBankName.Text = Value
        End Set
    End Property

    Public Property BankAdjRate() As Double
        Get
            Return ntbRate.Text
        End Get
        Set(ByVal Value As Double)
            ntbRate.Text = Value
        End Set
    End Property

    Sub clear_obj()
        m_BankTransId = 0
        txtBankTransNo.Text = ""
        cmbPaymentMethod.SelectedIndex = 0
        txtRemarks.Text = ""
        dtpBankAdjDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtCurrencyCode.Text = ""
        ntbRate.Text = FormatNumber(0, 2)
        txtRefNo.Text = ""
        txtBankCode.Text = ""
        txtBankName.Text = ""
        txtBankDetail.Text = ""
        txtPayee.Text = ""
        txtInfo1.Text = ""
        txtInfo2.Text = ""
        txtInfo3.Text = ""
        txtLocalSubTotal.Text = FormatNumber(0, 2)
        txtLocalTax.Text = FormatNumber(0, 2)
        txtLocalTotal.Text = FormatNumber(0, 2)
        txtSubtotal.Text = FormatNumber(0, 2)
        txtTax.Text = FormatNumber(0, 2)
        txtTotal.Text = FormatNumber(0, 2)
        m_BankBalance = 0
        isGetNum = True
        isPosted = False
    End Sub

    Sub clear_objD()
        m_BankTransDId = 0
        m_CurrId = 0
        'm_gross_amount_before_detail = 0
        'm_tax_amount_before_detail = 0
        m_net_amount_before_detail = 0
        'm_local_gross_amount_before_detail = 0
        'm_local_tax_amount_before_detail = 0
        m_local_net_amount_before_detail = 0
        txtExpincCode.Text = ""
        txtLineDesc.Text = ""

        ntbBankTransAmount.Text = FormatNumber(0, 2)
        ntbBankTransTaxPercent.Text = FormatNumber(m_TaxPercent, 0)
        txtBankTransTaxAmt.Text = FormatNumber(0, 2)
        txtBankTransNetAmt.Text = FormatNumber(0, 2)
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtBankTransNo.ReadOnly = isLock
        dtpBankAdjDate.Enabled = Not isLock
        txtRemarks.ReadOnly = isLock

        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnPrint.Enabled = isLock

        If isPosted = True Then btnEdit.Enabled = False

        If m_BankTransId = 0 Then
            txtBankTransNo.ReadOnly = False
            btnDelete.Enabled = isLock
        Else
            txtBankTransNo.ReadOnly = True
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
            btnBank.Enabled = False
        End If

        If ListView1.Items.Count <> 0 Then
            ntbRate.ReadOnly = True
        Else
            ntbRate.ReadOnly = isLock
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        txtLineDesc.ReadOnly = isLock
        ntbBankTransAmount.ReadOnly = isLock

        btnExpinc.Enabled = Not isLock
        btnSaveD.Enabled = Not isLock
        btnDeleteD.Enabled = Not isLock
        btnAddD.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("bank_trans_dtl_id", 0)
            .Columns.Add("Inc/Exp Code", 120)
            .Columns.Add("Bank Receipt Description", 370)
            .Columns.Add("Amount", 150, HorizontalAlignment.Right)
            .Columns.Add("Tax", 110, HorizontalAlignment.Right)
            .Columns.Add("Total", 200, HorizontalAlignment.Right)
            .Columns.Add("Lokal Amount", 0, HorizontalAlignment.Right)
            .Columns.Add("Lokal Tax", 0, HorizontalAlignment.Right)
            .Columns.Add("Lokal Total", 0, HorizontalAlignment.Right)
            .Columns.Add("tax_percent", 0, HorizontalAlignment.Right)
        End With

        If m_BankTransId <> 0 Then
            cmd = New SqlCommand("usp_tr_bank_trans_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@bank_trans_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtBankTransNo.Text

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(0))) 'sku_id
                lvItem.Tag = intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                For i = 1 To 2
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next
                For i = 3 To 9
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
                    End If
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
    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1.SelectedItems.Item(0)
            m_BankTransDId = .SubItems.Item(0).Text
            txtExpincCode.Text = .SubItems.Item(1).Text
            txtLineDesc.Text = .SubItems.Item(2).Text
            ntbBankTransAmount.Text = .SubItems.Item(3).Text
            ntbBankTransTaxPercent.Text = .SubItems.Item(9).Text
            txtBankTransTaxAmt.Text = .SubItems.Item(4).Text
            txtBankTransNetAmt.Text = .SubItems.Item(5).Text
            m_net_amount_before_detail = .SubItems.Item(5).Text
            m_local_net_amount_before_detail = .SubItems.Item(8).Text

            If btnSaveD.Enabled = True Then
                btnExpinc.Enabled = False
            End If
        End With
    End Sub

    Sub view_record()
        cmd = New SqlCommand("usp_tr_bank_trans_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@bank_trans_id", SqlDbType.Int)
        prm1.Value = m_BankTransId
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@bank_trans_no", SqlDbType.NVarChar, 50)
        prm2.Value = txtBankTransNo.Text

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtBankTransNo.Text = myReader.GetString(0)
            dtpBankAdjDate.Value = myReader.GetDateTime(2)
            m_PaymentType = myReader.GetString(3)
            txtBankCode.Text = myReader.GetString(5)
            txtBankName.Text = myReader.GetString(6)
            txtCurrencyCode.Text = myReader.GetString(7)
            ntbRate.Text = FormatNumber(myReader.GetValue(8))
            txtSubtotal.Text = FormatNumber(myReader.GetValue(10))
            txtTax.Text = FormatNumber(myReader.GetValue(11))
            txtTotal.Text = FormatNumber(myReader.GetValue(12))
            txtLocalSubTotal.Text = FormatNumber(myReader.GetValue(13))
            txtLocalTax.Text = FormatNumber(myReader.GetValue(14))
            txtLocalTotal.Text = FormatNumber(myReader.GetValue(15))
            m_BankBalance = FormatNumber(myReader.GetValue(21))

            If Not myReader.IsDBNull(myReader.GetOrdinal("remarks")) Then
                txtRemarks.Text = myReader.GetString(myReader.GetOrdinal("remarks"))
            Else
                txtRemarks.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("ref_no")) Then
                txtRefNo.Text = myReader.GetString(myReader.GetOrdinal("ref_no"))
            Else
                txtRefNo.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("bank_detail")) Then
                txtBankDetail.Text = myReader.GetString(myReader.GetOrdinal("bank_detail"))
            Else
                txtBankDetail.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("payee")) Then
                txtPayee.Text = myReader.GetString(myReader.GetOrdinal("payee"))
            Else
                txtPayee.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("info1")) Then
                txtInfo1.Text = myReader.GetString(myReader.GetOrdinal("info1"))
            Else
                txtInfo1.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("info2")) Then
                txtInfo2.Text = myReader.GetString(myReader.GetOrdinal("info2"))
            Else
                txtInfo2.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("info3")) Then
                txtInfo3.Text = myReader.GetString(myReader.GetOrdinal("info3"))
            Else
                txtInfo3.Text = ""
            End If
            isPosted = myReader.GetBoolean(22)
            m_PeriodId = myReader.GetInt32(23)
        End While

        myReader.Close()
        cn.Close()

        Dim mList As clsMyListStr
        Dim i As Integer
        For i = 1 To cmbPaymentMethod.Items.Count
            mList = cmbPaymentMethod.Items(i - 1)
            If m_PaymentType = mList.ItemData Then
                cmbPaymentMethod.SelectedIndex = i - 1
                Exit For
            End If
        Next

        Dim nList As clsMyListInt
        For i = 1 To cmbPeriodId.Items.Count
            nList = cmbPeriodId.Items(i - 1)
            If m_PeriodId = nList.ItemData Then
                cmbPeriodId.SelectedIndex = i - 1
                Exit For
            End If
        Next
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_BankTransId = 0
        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
        btnBank.Enabled = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_BankTransId = 0 Then
            Me.Close()
        Else
            lock_obj(True)
            lock_objD(True)
            clear_objD()
            m_BankTransDId = 0
        End If
    End Sub

    Private Sub btnExpinc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpinc.Click
        If txtBankCode.Text = "" Then
            MsgBox("Please insert Bank Code !", vbCritical + vbOKOnly, Me.Text)
            btnBank.Focus()
            Exit Sub
        End If

        If m_PeriodId <> cmbPeriodId.Items(cmbPeriodId.SelectedIndex).ItemData Then
            MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If

        Dim NewFormDialog As New fdlIncome
        NewFormDialog.fdlIncomeMode = 2 'can search for income & expense code
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtBankCode.Text = "" Then
            MsgBox("Please insert Bank Code !", vbCritical + vbOKOnly, Me.Text)
            btnBank.Focus()
            Exit Sub
        End If

        If m_PeriodId <> cmbPeriodId.Items(cmbPeriodId.SelectedIndex).ItemData Then
            MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If

        If CDbl(txtTotal.Text) = 0 Then
            MsgBox("Warning,Bank Receipt total is 0 !", vbInformation, Me.Text)
        End If
        Try

            '20160607 daniel s : applock
            AppLock.GetLock()

            SaveBankTransHeader()

            lock_obj(True)
            lock_objD(True)

            '20160607 daniel s : applock
            AppLock.ReleaseLock()

        Catch ex As Exception
            MsgBox(ex.Message)
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
            cmd = New SqlCommand("usp_tr_bank_trans_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@bank_trans_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtBankTransNo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm2.Value = My.Settings.UserName
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@type", SqlDbType.NVarChar, 5)
            prm3.Value = "REC"

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            btnAdd_Click(sender, e)
        End If
        autoRefresh()
    End Sub

    Sub SaveBankTransHeader()
        Try
            If m_BankTransId = 0 Then
                If txtBankTransNo.Text = "" Then
                    txtBankTransNo.Text = GetSysNumber("bank_receipt", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If
            End If

            cmd = New SqlCommand(IIf(m_BankTransId = 0, "usp_tr_bank_trans_INS", "usp_tr_bank_trans_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@bank_trans_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtBankTransNo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@trans_type", SqlDbType.NVarChar, 5)
            prm2.Value = "BNREC"
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@bank_trans_date", SqlDbType.SmallDateTime)
            prm3.Value = dtpBankAdjDate.Value.Date
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@payment_method", SqlDbType.NVarChar, 50)
            prm4.Value = cmbPaymentMethod.Items(cmbPaymentMethod.SelectedIndex).ItemData
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
            prm5.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@bank_code", SqlDbType.NVarChar, 50)
            prm6.Value = txtBankCode.Text
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@currency_code", SqlDbType.NVarChar, 50)
            prm7.Value = txtCurrencyCode.Text
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@bank_trans_rate", SqlDbType.Decimal)
            prm8.Value = FormatNumber(ntbRate.Text)
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@bank_detail", SqlDbType.NVarChar, 50)
            prm9.Value = IIf(txtBankDetail.Text = "", DBNull.Value, txtBankDetail.Text)
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@remarks", SqlDbType.NVarChar, 255)
            prm16.Value = IIf(txtRemarks.Text = "", DBNull.Value, txtRemarks.Text)
            Dim prm17 As SqlParameter = cmd.Parameters.Add("@payee", SqlDbType.NVarChar, 50)
            prm17.Value = IIf(txtPayee.Text = "", DBNull.Value, txtPayee.Text)
            Dim prm18 As SqlParameter = cmd.Parameters.Add("@info1", SqlDbType.NVarChar, 50)
            prm18.Value = IIf(txtInfo1.Text = "", DBNull.Value, txtInfo1.Text)
            Dim prm19 As SqlParameter = cmd.Parameters.Add("@info2", SqlDbType.NVarChar, 50)
            prm19.Value = IIf(txtInfo2.Text = "", DBNull.Value, txtInfo2.Text)
            Dim prm20 As SqlParameter = cmd.Parameters.Add("@info3", SqlDbType.NVarChar, 50)
            prm20.Value = IIf(txtInfo3.Text = "", DBNull.Value, txtInfo3.Text)
            Dim prm21 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm21.Value = My.Settings.UserName
            Dim prm22 As SqlParameter = cmd.Parameters.Add("@bank_trans_period_id", SqlDbType.Int)
            prm22.Value = cmbPeriodId.Items(cmbPeriodId.SelectedIndex).ItemData

            If m_BankTransId = 0 Then
                cn.Open()
                cmd.ExecuteReader()
                m_BankTransId = 1
                cn.Close()
                If isGetNum = True Then UpdSysNumber("bank_receipt")
                txtBankTransNo.ReadOnly = True
            Else
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                'clear_lvw()
            End If
            refresh_total()
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        autoRefresh()
    End Sub

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        Try
            If m_PeriodId <> cmbPeriodId.Items(cmbPeriodId.SelectedIndex).ItemData Then
                MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                Exit Sub
            End If

            '20160607 daniel s : applock
            AppLock.GetLock()

            SaveBankTransHeader()

            If txtExpincCode.Text = "" Then
                MsgBox("Please insert bank code!", vbCritical + vbOKOnly, Me.Text)
                txtLineDesc.Focus()

                '20160607 daniel s : applock
                AppLock.ReleaseLock()

                Exit Sub
            End If

            'If isAllowBankMinus = False Then
            '    If (m_BankBalance + m_net_amount_before_detail) - CDbl(txtBankTransNetAmt.Text) < 0 Then
            '        MsgBox("Bank payment amount > Bank balance amount!", vbCritical + vbOKOnly, Me.Text)
            '        ntbBankTransAmount.Focus()
            '        Exit Sub
            '    End If
            'End If

            cmd = New SqlCommand(IIf(m_BankTransDId = 0, "usp_tr_bank_trans_dtl_INS", "usp_tr_bank_trans_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm10 As SqlParameter = cmd.Parameters.Add("@type", SqlDbType.NVarChar, 5)
            prm10.Value = "REC"
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@bank_trans_no", SqlDbType.NVarChar, 50)
            prm11.Value = txtBankTransNo.Text
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@expinc_code", SqlDbType.NVarChar, 50)
            prm12.Value = txtExpincCode.Text
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@bank_trans_desc", SqlDbType.NVarChar, 255)
            prm13.Value = IIf(txtLineDesc.Text = "", DBNull.Value, txtLineDesc.Text)
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@bank_code", SqlDbType.NVarChar, 50)
            prm14.Value = txtBankCode.Text
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@gross_amount", SqlDbType.Decimal)
            prm15.Value = FormatNumber(ntbBankTransAmount.Text, 2)
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@tax_percent", SqlDbType.Decimal)
            prm16.Value = FormatNumber(ntbBankTransTaxPercent.Text, 2)
            Dim prm17 As SqlParameter = cmd.Parameters.Add("@tax_amount", SqlDbType.Decimal)
            prm17.Value = FormatNumber(txtBankTransTaxAmt.Text, 2)
            Dim prm18 As SqlParameter = cmd.Parameters.Add("@net_amount", SqlDbType.Decimal)
            prm18.Value = FormatNumber(txtBankTransNetAmt.Text, 2)
            Dim prm19 As SqlParameter = cmd.Parameters.Add("@local_gross_amount", SqlDbType.Decimal)
            prm19.Value = FormatNumber(CDbl(ntbRate.Text) * CDbl(ntbBankTransAmount.Text), 2)
            Dim prm20 As SqlParameter = cmd.Parameters.Add("@local_tax_amount", SqlDbType.Decimal)
            prm20.Value = FormatNumber(CDbl(ntbRate.Text) * CDbl(txtBankTransTaxAmt.Text), 2)
            Dim prm21 As SqlParameter = cmd.Parameters.Add("@local_net_amount", SqlDbType.Decimal)
            prm21.Value = FormatNumber(CDbl(ntbRate.Text) * CDbl(txtBankTransNetAmt.Text), 2)

            If m_BankTransDId <> 0 Then
                Dim prm22 As SqlParameter = cmd.Parameters.Add("@bank_trans_dtl_id", SqlDbType.Int)
                prm22.Value = m_BankTransDId
                Dim prm23 As SqlParameter = cmd.Parameters.Add("@net_amount_before_detail", SqlDbType.Decimal)
                prm23.Value = m_net_amount_before_detail
                Dim prm24 As SqlParameter = cmd.Parameters.Add("@local_net_amount_before_detail", SqlDbType.Decimal)
                prm24.Value = m_local_net_amount_before_detail
            End If
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            '20160607 daniel s : applock
            AppLock.ReleaseLock()

            clear_lvw()
            clear_objD()
            lock_obj(False)
            lock_obj(False)
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        refresh_total()
    End Sub

    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD.Click
        If m_BankTransDId = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then

            '20160607 daniel s : applock
            AppLock.GetLock()

            cmd = New SqlCommand("usp_tr_bank_trans_dtl_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@bank_trans_dtl_id", SqlDbType.Int)
            prm1.Value = m_BankTransDId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@type", SqlDbType.NVarChar, 5)
            prm2.Value = "REC"
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@bank_trans_no", SqlDbType.NVarChar, 50)
            prm3.Value = txtBankTransNo.Text

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()
            refresh_total()

            btnExpinc.Enabled = True

            '20160607 daniel s : applock
            AppLock.ReleaseLock()

        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Bank_Payment_Form '" & txtBankTransNo.Text & "'"
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "Bank_Receipt")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Bank_Receipt_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Bank Receipt"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("Bank_Receipt"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub ntbStockAdjQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbRate.LostFocus
        If ntbRate.Text = "" Then ntbRate.Text = FormatNumber(0, 2)
        If CDbl(ntbRate.Text) < 0 Then ntbRate.Text = CDbl(ntbRate.Text) * -1
        If ntbRate.Text.Length = 0 Then ntbRate.Undo()
        'If m_POId = 0 Then
        If m_CurrBaseCode = txtCurrencyCode.Text Then
            ntbRate.Text = "1"
        Else
            If ntbRate.DecimalValue = 0 Then ntbRate.Undo()
            If ListView1.Items.Count > 0 Then ntbRate.Undo()
        End If
        'End If
        'ntbRate.Text = FormatNumber(IIf(ntbRate.Text = "", 1, ntbRate.Text))
        ntbRate.Text = FormatNumber(ntbRate.Text)
    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        btnExpinc.Enabled = True
        clear_objD()
    End Sub

    Private Sub btnBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBank.Click
        Dim NewFormDialog As New fdlBank
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Sub refresh_total()
        cmd = New SqlCommand("usp_tr_bank_trans_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@bank_trans_id", SqlDbType.Int)
        prm1.Value = 1
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@bank_trans_no", SqlDbType.NVarChar, 50)
        prm2.Value = txtBankTransNo.Text

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtSubtotal.Text = FormatNumber(myReader.GetValue(10))
            txtTax.Text = FormatNumber(myReader.GetValue(11))
            txtTotal.Text = FormatNumber(myReader.GetValue(12))
            txtLocalSubTotal.Text = FormatNumber(myReader.GetValue(13))
            txtLocalTax.Text = FormatNumber(myReader.GetValue(14))
            txtLocalTotal.Text = FormatNumber(myReader.GetValue(15))
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Sub refresh_totalD()
        txtBankTransTaxAmt.Text = FormatNumber((ntbBankTransAmount.Text) * CDbl(ntbBankTransTaxPercent.Text) / 100)
        txtBankTransNetAmt.Text = FormatNumber((ntbBankTransAmount.Text) + CDbl(txtBankTransTaxAmt.Text))
    End Sub

    Private Sub ntbBankTransTaxPercent_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbBankTransTaxPercent.LostFocus
        If ntbBankTransTaxPercent.Text = "" Then ntbBankTransTaxPercent.Text = FormatNumber(m_TaxPercent)
        If CDbl(ntbBankTransTaxPercent.Text) < 0 Then ntbBankTransTaxPercent.Text = CDbl(ntbBankTransTaxPercent.Text) * -1
        refresh_totalD()
        ntbBankTransTaxPercent.Text = FormatNumber(ntbBankTransTaxPercent.Text, 0)
    End Sub

    Private Sub ntbBankTransAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbBankTransAmount.LostFocus
        If ntbBankTransAmount.Text = "" Then ntbBankTransAmount.Text = FormatNumber(0, 2)
        If CDbl(ntbBankTransAmount.Text) < 0 Then ntbBankTransAmount.Text = CDbl(ntbBankTransAmount.Text) * -1
        refresh_totalD()
        ntbBankTransAmount.Text = FormatNumber(ntbBankTransAmount.Text, 2)
    End Sub
    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmBankReceiptList).Any Then
            Call frmBankReceiptList.frmBankReceiptListShow(Nothing, EventArgs.Empty)
        End If
    End Sub

    Private Sub dtpBankAdjDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpBankAdjDate.ValueChanged
        For i = 0 To m_PeriodArr.GetUpperBound(0)
            If dtpBankAdjDate.Value >= m_PeriodArr(i, 1) AndAlso dtpBankAdjDate.Value <= m_PeriodArr(i, 2) Then
                cmbPeriodId.SelectedIndex = i
                m_PeriodId = cmbPeriodId.Items(cmbPeriodId.SelectedIndex).ItemData
                Exit For
            Else
                m_PeriodId = 0
            End If
        Next
    End Sub
End Class