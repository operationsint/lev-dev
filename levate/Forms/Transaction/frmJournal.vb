Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmJournal
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_JournalId As Integer
    Dim m_JournalType As String
    Dim m_PaymentMethod As String
    Dim m_PeriodId As Integer
    Dim m_PeriodArr(0, 0) As String
    Dim m_PeriodArrSelected As Integer
    Dim m_TransType As String
    Dim m_JournalTypeArr(15, 1) As String
    Dim m_JournalDId As Integer
    Dim m_AccountId As Integer
    Dim m_POTaxPercent As Single
    Dim m_CurrId As Integer
    Dim m_CurrBaseId As Integer
    Dim m_CurrBaseCode As String
    Dim m_JournalCurrRateBefore As Double
    Dim m_LocalDBBefore As Double
    Dim m_LocalCRBefore As Double
    Dim isGetNum As Boolean
    Dim isAllowDelete As Boolean
    Dim isPosted As Boolean
    Private docPO As ReportDocument
    Dim Dec As Integer = 2

    Private Sub frmPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolTip1.SetToolTip(btnCurrency, "Search Currency")
        ToolTip1.SetToolTip(btnAccount, "Search Account")
        ToolTip1.SetToolTip(btnSaveD, "Save Line")
        ToolTip1.SetToolTip(btnDeleteD, "Delete Line")
        ToolTip1.SetToolTip(btnAddD, "Add Line")

        isAllowDelete = canDelete(Me.Name + "List")
        m_POTaxPercent = GetSysInit("tax_percent") * 100

        Dim prm1 As SqlParameter
        Dim prm2 As SqlParameter
        Dim myReader As SqlDataReader

        'Base Currency
        cmd = New SqlCommand("usp_mt_curr_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@base_curr", SqlDbType.Bit)
        prm1.Value = 1

        cn.Open()
        myReader = cmd.ExecuteReader

        While myReader.Read
            m_CurrBaseId = myReader.GetInt32(0)
            m_CurrBaseCode = myReader.GetString(1)
        End While

        myReader.Close()
        cn.Close()

        Dim i As Integer = 0

        'Add item cmbClosingPeriod
        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@period_type", SqlDbType.NVarChar, 50)
        prm1.Value = "month_period"
        prm2 = cmd.Parameters.Add("@is_locked_gl", SqlDbType.Bit)
        prm2.Value = 0

        cn.Open()
        myReader = cmd.ExecuteReader

        'cmbJournalPeriodId.Items.Clear()
        While myReader.Read
            'cmbJournalPeriodId.Items.Add(New clsMyListInt(myReader.GetString(1), myReader.GetInt32(0)))
            i += 1
        End While
        'If cmbJournalPeriodId.Items.Count > 0 Then cmbJournalPeriodId.SelectedIndex = 0

        myReader.Close()
        cn.Close()

        'Add Period Array

        ReDim m_PeriodArr(i - 1, 3)

        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@period_type", SqlDbType.NVarChar, 50)
        prm1.Value = "month_period"
        prm2 = cmd.Parameters.Add("@is_locked_gl", SqlDbType.Bit)
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

        'Add item txtJournalType
        i = 0
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "journal_trans_type"

        cn.Open()
        myReader = cmd.ExecuteReader

        While myReader.Read
            m_JournalTypeArr(i, 0) = myReader.GetString(0)
            m_JournalTypeArr(i, 1) = myReader.GetString(1)
            i += 1
        End While

        myReader.Close()
        cn.Close()

        If m_JournalId = 0 Then
            btnAdd_Click(sender, e)
        Else
            m_JournalDId = 0
            view_record()
            clear_lvw()
            'btnEdit_Click(sender, e)
            clear_objD()
            lock_obj(True)
            lock_objD(True)
            'If m_JournalTypeArr(i, 1) = "AUTO" Then btnEdit.Enabled = False
        End If
    End Sub

    Public Property JournalId() As Integer
        Get
            Return m_JournalId
        End Get
        Set(ByVal Value As Integer)
            m_JournalId = Value
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
            Return ntbJournalCurrRate.Text
        End Get
        Set(ByVal Value As String)
            ntbJournalCurrRate.Text = Value
        End Set
    End Property

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
            Return txtSKUCode.Text
        End Get
        Set(ByVal Value As String)
            txtSKUCode.Text = Value
        End Set
    End Property

    Public Property AccountName() As String
        Get
            Return txtJournalDtlDesc.Text
        End Get
        Set(ByVal Value As String)
            txtJournalDtlDesc.Text = Value
        End Set
    End Property

    Private Sub btnSKU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccount.Click
        Dim NewFormDialog As New fdlAccount
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Sub clear_obj()
        m_JournalId = 0
        m_CurrId = m_CurrBaseId
        m_JournalCurrRateBefore = 0
        txtJournalNo.Text = ""
        dtpJournalDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtJournalRefNo.Text = ""
        txtCurrCode.Text = m_CurrBaseCode
        ntbJournalCurrRate.Text = FormatNumber("1")
        txtJournalRemarks.Text = ""
        m_JournalType = m_JournalTypeArr(0, 0)
        txtJournalType.Text = m_JournalTypeArr(0, 1)
        txtJournalTotalDB.Text = FormatNumber("0")
        txtJournalTotalCR.Text = FormatNumber("0")
        txtLocalJournalTotalDB.Text = FormatNumber("0")
        txtLocalJournalTotalCR.Text = FormatNumber("0")
        isGetNum = True
        isPosted = False
    End Sub

    Sub clear_objD()
        m_JournalDId = 0
        m_LocalDBBefore = 0
        m_LocalCRBefore = 0
        txtSKUCode.Text = ""
        txtJournalDtlDesc.Text = ""
        ntbDBValue.Text = FormatNumber(0)
        ntbCRValue.Text = FormatNumber(0)
        ntbLocalDB.Text = FormatNumber(0)
        ntbLocalCR.Text = FormatNumber(0)
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        dtpJournalDate.Enabled = Not isLock
        txtJournalRefNo.ReadOnly = isLock
        ntbJournalCurrRate.ReadOnly = isLock
        txtJournalRemarks.ReadOnly = isLock
        'cmbJournalPeriodId.Enabled = Not isLock
        btnCurrency.Enabled = Not isLock
        If m_JournalType = "journal" Then btnEdit.Enabled = isLock Else btnEdit.Enabled = False
        If isPosted = True Then btnEdit.Enabled = False
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnPrint.Enabled = isLock

        If m_JournalId = 0 Then
            txtJournalNo.ReadOnly = False
            ntbJournalCurrRate.ReadOnly = False
            btnCurrency.Enabled = True
            btnDelete.Enabled = isLock
        Else
            txtJournalNo.ReadOnly = True
            ntbJournalCurrRate.ReadOnly = True
            btnCurrency.Enabled = False
            'If p_UserLevel = 1 Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
            'If canDelete(p_UserLevel, Me.Name + "List") = True Then
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        txtJournalDtlDesc.ReadOnly = isLock
        ntbDBValue.ReadOnly = isLock
        ntbCRValue.ReadOnly = isLock
        btnAccount.Enabled = Not isLock
        btnSaveD.Enabled = Not isLock
        btnDeleteD.Enabled = Not isLock
        btnAddD.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("account_id", 0)
            .Columns.Add("Account Code", 170)
            .Columns.Add("Line Description", 300)
            .Columns.Add("Debit Value", 130, HorizontalAlignment.Right)
            .Columns.Add("Credit Value", 130, HorizontalAlignment.Right)
            .Columns.Add("Local Debit", 130, HorizontalAlignment.Right)
            .Columns.Add("Local Credit", 130, HorizontalAlignment.Right)
            '.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
            '.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize)
            '.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.ColumnContent)
        End With

        If m_JournalId <> 0 Then
            cmd = New SqlCommand("usp_tr_journal_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@journal_id", SqlDbType.Int)
            prm2.Value = m_JournalId

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(1))) 'account_id
                lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                lvItem.SubItems.Add(myReader.GetString(2)) 'account_code
                lvItem.SubItems.Add(myReader.GetString(3)) 'journal_dtl_desc
                For i = 4 To 7 'db_value, cr_value, local_db, local_cr
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
        cmd = New SqlCommand("usp_tr_journal_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@journal_id", SqlDbType.Int)
        prm1.Value = m_JournalId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtJournalNo.Text = myReader.GetString(1)
            dtpJournalDate.Value = myReader.GetDateTime(2)
            m_PeriodId = myReader.GetInt32(3)
            'm_PaymentMethod = myReader.GetString(13)

            If Not myReader.IsDBNull(myReader.GetOrdinal("journal_ref_no")) Then
                txtJournalRefNo.Text = myReader.GetString(myReader.GetOrdinal("journal_ref_no"))
            Else
                txtJournalRefNo.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("journal_remarks")) Then
                txtJournalRemarks.Text = myReader.GetString(myReader.GetOrdinal("journal_remarks"))
            Else
                txtJournalRemarks.Text = ""
            End If
            m_JournalType = myReader.GetString(6)
            m_CurrId = myReader.GetInt32(8)
            txtCurrCode.Text = myReader.GetString(9)
            ntbJournalCurrRate.Text = FormatNumber(myReader.GetValue(10))
            m_JournalCurrRateBefore = myReader.GetValue(10)
            txtJournalTotalDB.Text = FormatNumber(myReader.GetValue(11))
            txtJournalTotalCR.Text = FormatNumber(myReader.GetValue(12))
            txtLocalJournalTotalDB.Text = FormatNumber(myReader.GetValue(13))
            txtLocalJournalTotalCR.Text = FormatNumber(myReader.GetValue(14))
            isPosted = myReader.GetBoolean(15)
        End While

        myReader.Close()
        cn.Close()

        If isPosted = True Then txtPeriodId.Text = GetPeriodName(m_PeriodId)

        'Dim mList As clsMyListInt
        'For i = 1 To cmbJournalPeriodId.Items.Count
        '    mList = cmbJournalPeriodId.Items(i - 1)
        '    If m_PeriodId = mList.ItemData Then
        '        cmbJournalPeriodId.SelectedIndex = i - 1
        '        Exit For
        '    End If
        'Next

        For i = 0 To m_JournalTypeArr.GetUpperBound(0)
            If m_JournalType = m_JournalTypeArr(i, 0) Then
                txtJournalType.Text = m_JournalTypeArr(i, 1)
                Exit For
            End If
        Next
    End Sub

    Sub refresh_total()
        cmd = New SqlCommand("usp_tr_journal_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@journal_id", SqlDbType.Int)
        prm1.Value = m_JournalId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtJournalTotalDB.Text = FormatNumber(myReader.GetValue(11))
            txtJournalTotalCR.Text = FormatNumber(myReader.GetValue(12))
            txtLocalJournalTotalDB.Text = FormatNumber(myReader.GetValue(13))
            txtLocalJournalTotalCR.Text = FormatNumber(myReader.GetValue(14))
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_JournalId = 0
        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_JournalId = 0 Then
            Me.Close()
        Else
            'Check Total
            If isBalance(CDbl(txtJournalTotalDB.Text), CDbl(txtJournalTotalCR.Text)) = False Then Exit Sub

            lock_obj(True)
            lock_objD(True)
            clear_objD()
            m_JournalDId = 0
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            'If m_PeriodId <> cmbJournalPeriodId.Items(cmbJournalPeriodId.SelectedIndex).ItemData Then
            If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
                MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                Exit Sub
            End If

            'Check total
            If isBalance(CDbl(txtJournalTotalDB.Text), CDbl(txtJournalTotalCR.Text)) = False Then Exit Sub

            If m_JournalId = 0 Then
                If txtJournalNo.Text = "" Then
                    txtJournalNo.Text = GetSysNumber("journal_entry", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If
            End If

            cmd = New SqlCommand(IIf(m_JournalId = 0, "usp_tr_journal_INS", "usp_tr_journal_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@journal_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtJournalNo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@journal_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpJournalDate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@journal_period_id", SqlDbType.Int)
            'prm3.Value = cmbJournalPeriodId.Items(cmbJournalPeriodId.SelectedIndex).ItemData
            prm3.Value = m_PeriodArr(m_PeriodArrSelected, 0)
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@journal_ref_no", SqlDbType.NVarChar)
            prm4.Value = IIf(txtJournalRefNo.Text = "", DBNull.Value, txtJournalRefNo.Text)
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@journal_remarks", SqlDbType.NVarChar)
            prm5.Value = IIf(txtJournalRemarks.Text = "", DBNull.Value, txtJournalRemarks.Text)
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@trans_type", SqlDbType.NVarChar, 50)
            prm6.Value = m_JournalType

            Dim prm11 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm11.Value = m_CurrId
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@journal_curr_rate", SqlDbType.Money)
            prm12.Value = FormatNumber(ntbJournalCurrRate.Text)

            Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm15.Value = My.Settings.UserName
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@journal_id", SqlDbType.Int)

            If m_JournalId = 0 Then
                prm16.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_JournalId = prm16.Value
                'MessageBox.Show(m_JournalId)
                cn.Close()
                If isGetNum = True Then UpdSysNumber("journal_entry")
            Else
                prm16.Value = m_JournalId

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                'clear_lvw()
                If CDbl(ntbJournalCurrRate.Text) <> m_JournalCurrRateBefore Then refresh_total()
            End If

            lock_obj(True)
            lock_objD(True)
            m_JournalCurrRateBefore = CDbl(ntbJournalCurrRate.Text)

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
        If UCase(m_JournalType) = "JOURNAL" Then
            If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
                cmd = New SqlCommand("usp_tr_journal_DEL", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@journal_id", SqlDbType.Int)
                prm1.Value = m_JournalId
                Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                prm2.Value = My.Settings.UserName

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                btnAdd_Click(sender, e)
            End If
        Else
            MsgBox("You can't delete this transaction record", vbCritical, Me.Text)
        End If
    End Sub

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        Try
            'If m_PeriodId <> cmbJournalPeriodId.Items(cmbJournalPeriodId.SelectedIndex).ItemData Then
            If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
                MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                Exit Sub
            End If

            If m_JournalId = 0 Then
                SaveJournalHeader()
            End If

            If txtJournalDtlDesc.Text = "" Then
                MsgBox("Line Description are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtJournalDtlDesc.Focus()
                Exit Sub
            End If

            cmd = New SqlCommand(IIf(m_JournalDId = 0, "usp_tr_journal_dtl_INS", "usp_tr_journal_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm17 As SqlParameter = cmd.Parameters.Add("@journal_id", SqlDbType.Int)
            prm17.Value = m_JournalId
            Dim prm18 As SqlParameter = cmd.Parameters.Add("@account_id", SqlDbType.Int)
            prm18.Value = m_AccountId
            Dim prm20 As SqlParameter = cmd.Parameters.Add("@journal_dtl_description", SqlDbType.NVarChar, 255)
            prm20.Value = IIf(txtJournalDtlDesc.Text = "", DBNull.Value, txtJournalDtlDesc.Text)
            Dim prm22 As SqlParameter = cmd.Parameters.Add("@db_value", SqlDbType.Money)
            prm22.Value = FormatNumber(ntbDBValue.Text)
            Dim prm23 As SqlParameter = cmd.Parameters.Add("@cr_value", SqlDbType.Money)
            prm23.Value = FormatNumber(ntbCRValue.Text)
            Dim prm24 As SqlParameter = cmd.Parameters.Add("@journal_curr_rate", SqlDbType.Money)
            prm24.Value = FormatNumber(ntbJournalCurrRate.Text)

            If m_JournalDId <> 0 Then
                Dim prm31 As SqlParameter = cmd.Parameters.Add("@journal_dtl_id", SqlDbType.Int)
                prm31.Value = m_JournalDId
                Dim prm32 As SqlParameter = cmd.Parameters.Add("@local_db_before", SqlDbType.Decimal)
                prm32.Value = m_LocalDBBefore
                Dim prm33 As SqlParameter = cmd.Parameters.Add("@local_cr_before", SqlDbType.Decimal)
                prm33.Value = m_LocalCRBefore
            End If
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()
            refresh_total()

        Catch ex As Exception
            'If Err.Number = 5 Then
            '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
            'Else
            MsgBox(ex.Message)
            'End If
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Sub SaveJournalHeader()
        Try
            If txtJournalNo.Text = "" Then
                txtJournalNo.Text = GetSysNumber("journal_entry", Now.Date)
                isGetNum = True
            Else
                isGetNum = False
            End If

            cmd = New SqlCommand("usp_tr_journal_INS", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@journal_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtJournalNo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@journal_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpJournalDate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@journal_period_id", SqlDbType.Int)
            prm3.Value = m_PeriodId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@journal_ref_no", SqlDbType.NVarChar)
            prm4.Value = IIf(txtJournalRefNo.Text = "", DBNull.Value, txtJournalRefNo.Text)
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@journal_remarks", SqlDbType.NVarChar)
            prm5.Value = IIf(txtJournalRemarks.Text = "", DBNull.Value, txtJournalRemarks.Text)
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@trans_type", SqlDbType.NVarChar, 50)
            prm6.Value = "journal"

            Dim prm11 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm11.Value = m_CurrId
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@journal_curr_rate", SqlDbType.Money)
            prm12.Value = FormatNumber(ntbJournalCurrRate.Text)

            Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm15.Value = My.Settings.UserName
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@journal_id", SqlDbType.Int)
            prm16.Direction = ParameterDirection.Output

            cn.Open()
            cmd.ExecuteReader()
            m_JournalId = prm16.Value
            cn.Close()
            If isGetNum = True Then UpdSysNumber("journal_entry")
            txtJournalNo.ReadOnly = True
            btnCurrency.Enabled = False
            ntbJournalCurrRate.ReadOnly = True
            m_JournalCurrRateBefore = CDbl(ntbJournalCurrRate.Text)

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
        If m_JournalDId = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_tr_journal_dtl_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@journal_dtl_id", SqlDbType.Int, 50)
            prm1.Value = m_JournalDId

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
            m_JournalDId = LeftSplitUF(.Tag)
            m_AccountId = .SubItems.Item(0).Text
            txtSKUCode.Text = .SubItems.Item(1).Text
            txtJournalDtlDesc.Text = .SubItems.Item(2).Text
            ntbDBValue.Text = FormatNumber(.SubItems.Item(3).Text)
            ntbCRValue.Text = FormatNumber(.SubItems.Item(4).Text)
            ntbLocalDB.Text = FormatNumber(.SubItems.Item(5).Text)
            m_LocalDBBefore = CDbl(.SubItems.Item(5).Text)
            ntbLocalCR.Text = FormatNumber(.SubItems.Item(6).Text)
            m_LocalCRBefore = CDbl(.SubItems.Item(6).Text)
        End With
    End Sub

    Private Sub ntbDBValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbDBValue.LostFocus
        ntbDBValue.Text = FormatNumber(IIf(ntbDBValue.Text = "", 0, ntbDBValue.Text))
        ntbDBValue.Text = IIf(CDbl(ntbDBValue.Text) < 0, CDbl(ntbDBValue.Text) * -1, ntbDBValue.Text)
        ntbCRValue.Text = IIf(CDbl(ntbDBValue.Text) > 0, FormatNumber(0), ntbCRValue.Text)
        ntbLocalDB.Text = FormatNumber(CDbl(ntbDBValue.Text) * CDbl(ntbJournalCurrRate.Text))
        ntbLocalCR.Text = FormatNumber(CDbl(ntbCRValue.Text) * CDbl(ntbJournalCurrRate.Text))
    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        clear_objD()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

    End Sub

    Private Sub ntbJournalCurrRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbJournalCurrRate.LostFocus
        'ntbJournalCurrRate.Text = FormatNumber(IIf(ntbJournalCurrRate.Text = "", 1, ntbJournalCurrRate.Text))
        If ntbJournalCurrRate.Text.Length = 0 Then ntbJournalCurrRate.Undo()
        If m_JournalId = 0 Then
            If m_CurrId = m_CurrBaseId Then
                ntbJournalCurrRate.Text = "1"
            Else
                If ntbJournalCurrRate.DecimalValue = 0 Then ntbJournalCurrRate.Undo()
            End If
        End If
        ntbJournalCurrRate.Text = FormatNumber(ntbJournalCurrRate.Text)
    End Sub

    Private Sub btnCurrency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCurrency.Click
        Dim NewFormDialog As New fdlCurrency
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub ntbCRValue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbCRValue.GotFocus
        If m_JournalDId = 0 And CDbl(ntbDBValue.Text) = 0 Then
            ntbCRValue.Text = CDbl(txtJournalTotalDB.Text) - CDbl(txtJournalTotalCR.Text)
            ntbLocalCR.Text = FormatNumber(CDbl(ntbCRValue.Text) * CDbl(ntbJournalCurrRate.Text))
        End If
    End Sub

    Private Sub ntbCRValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbCRValue.LostFocus
        ntbCRValue.Text = FormatNumber(IIf(ntbCRValue.Text = "", 0, ntbCRValue.Text))
        ntbCRValue.Text = IIf(CDbl(ntbCRValue.Text) < 0, CDbl(ntbCRValue.Text) * -1, ntbCRValue.Text)
        ntbDBValue.Text = IIf(CDbl(ntbCRValue.Text) > 0, FormatNumber(0), ntbDBValue.Text)
        ntbLocalDB.Text = FormatNumber(CDbl(ntbDBValue.Text) * CDbl(ntbJournalCurrRate.Text))
        ntbLocalCR.Text = FormatNumber(CDbl(ntbCRValue.Text) * CDbl(ntbJournalCurrRate.Text))
    End Sub

    Private Sub ntbCRValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbCRValue.TextChanged

    End Sub

    Private Sub frmJournal_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If isBalance(CDbl(txtJournalTotalDB.Text), CDbl(txtJournalTotalCR.Text)) = False Then e.Cancel = True
        'If CDbl(txtJournalTotalDB.Text) <> CDbl(txtJournalTotalCR.Text) Then
        '    MsgBox("Total DB must equal with Total CR.", vbExclamation + vbOKOnly, Me.Text)
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub ntbDBValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbDBValue.TextChanged

    End Sub

    Private Sub dtpJournalDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpJournalDate.ValueChanged
        Dim isCheckIn As Boolean
        For i = 0 To m_PeriodArr.GetUpperBound(0)
            If dtpJournalDate.Value >= m_PeriodArr(i, 2) AndAlso dtpJournalDate.Value <= m_PeriodArr(i, 3) Then
                'cmbJournalPeriodId.SelectedIndex = i
                'm_PeriodId = cmbJournalPeriodId.Items(cmbJournalPeriodId.SelectedIndex).ItemData
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

    Private Function isBalance(ByVal DBAmount As Decimal, ByVal CRAmount As Decimal) As Boolean
        If CDbl(txtJournalTotalDB.Text) <> CDbl(txtJournalTotalCR.Text) Then
            MsgBox("Total DB must equal with Total CR.", vbExclamation + vbOKOnly, Me.Text)
            isBalance = False
        Else
            isBalance = True
        End If
    End Function
End Class
