Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmBankAdj
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_BankAdjId As Integer
    Dim m_BankAdjDId As Integer

    Dim m_BankBalance As Double
    Dim m_BankAdjDtlAmountBefore As Double
    Dim m_BankAdjDtlLocalAmountBefore As Double

    Dim m_CurrId As Integer
    Dim isGetNum As Boolean
    Dim isAllowDelete As Boolean
    Dim isAllowBankMinus As Boolean = GetSysInit("bank_amount_minus")
    Private docStockAdj As ReportDocument

    Dim m_PeriodId As Integer
    Dim m_PeriodArr(0, 0) As String
    Dim isPosted As Boolean

    Private Sub frmBankAdj_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim prm1 As SqlParameter
        Dim prm2 As SqlParameter
        Dim myReader As SqlDataReader
        Dim i As Integer = 0

        isAllowDelete = canDelete(Me.Name + "List")

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

        If m_BankAdjId = 0 Then
            btnAdd_Click(sender, e)
        Else
            m_BankAdjDId = 0
            view_record()
            clear_lvw()
            'btnEdit_Click(sender, e)
            lock_obj(True)
            lock_objD(True)
        End If
    End Sub

    Public Property BankAdjId() As Integer
        Get
            Return m_BankAdjId
        End Get
        Set(ByVal Value As Integer)
            m_BankAdjId = Value
        End Set
    End Property

    Public Property BankAdjNo() As String
        Get
            Return txtBankAdjNo.Text
        End Get
        Set(ByVal Value As String)
            txtBankAdjNo.Text = Value
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
            Return txtBankAdjDesc.Text
        End Get
        Set(ByVal Value As String)
            txtBankAdjDesc.Text = Value
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

    Private Sub btnSKU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBank.Click
        Dim NewFormDialog As New fdlBank
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Sub clear_obj()
        m_BankAdjId = 0
        txtBankAdjNo.Text = ""
        txtBankAdjRemarks.Text = ""
        dtpBankAdjDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        isGetNum = True
        isPosted = False
        chbAffectedToGL.Checked = True
    End Sub

    Sub clear_objD()
        m_BankAdjDId = 0
        m_CurrId = 0
        m_BankAdjDtlAmountBefore = 0
        m_BankAdjDtlLocalAmountBefore = 0
        txtBankCode.Text = ""
        txtBankAdjDesc.Text = ""
        txtCurrencyCode.Text = ""
        ntbRate.Text = FormatNumber(0, 2)
        ntbBankAdjAmount.Text = FormatNumber(0, 2)

    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtBankAdjNo.ReadOnly = isLock
        dtpBankAdjDate.Enabled = Not isLock
        txtBankAdjRemarks.ReadOnly = isLock
        chbAffectedToGL.Enabled = Not isLock

        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnPrint.Enabled = isLock

        If isPosted = True Then btnEdit.Enabled = False

        If m_BankAdjId = 0 Then
            txtBankAdjNo.ReadOnly = False
            btnDelete.Enabled = isLock
        Else
            txtBankAdjNo.ReadOnly = True
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        txtBankAdjDesc.ReadOnly = isLock
        ntbRate.ReadOnly = isLock
        ntbBankAdjAmount.ReadOnly = isLock

        btnBank.Enabled = Not isLock
        btnSaveD.Enabled = Not isLock
        btnDeleteD.Enabled = Not isLock
        btnAddD.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("bank_adj_dtl_id", 0)
            .Columns.Add("Bank Code", 120)
            .Columns.Add("Bank Adj. Description", 330)
            .Columns.Add("currency_id", 0)
            .Columns.Add("Currency", 80)
            .Columns.Add("Rate", 100, HorizontalAlignment.Right)
            .Columns.Add("Amount", 200, HorizontalAlignment.Right)
            .Columns.Add("local_amount", 200, HorizontalAlignment.Right)
            .Columns.Add("bank_balance", 0, HorizontalAlignment.Right)
        End With

        If m_BankAdjId <> 0 Then
            cmd = New SqlCommand("usp_tr_bank_adj_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@bank_adj_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtBankAdjNo.Text

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(0))) 'sku_id
                lvItem.Tag = intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                For i = 1 To 4
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next

                For i = 5 To 8
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
            m_BankAdjDId = .SubItems.Item(0).Text
            txtBankCode.Text = .SubItems.Item(1).Text
            txtBankAdjDesc.Text = .SubItems.Item(2).Text
            m_CurrId = CInt(.SubItems.Item(3).Text)
            txtCurrencyCode.Text = .SubItems.Item(4).Text
            ntbRate.Text = FormatNumber(.SubItems.Item(5).Text, 2)
            ntbBankAdjAmount.Text = FormatNumber(.SubItems.Item(6).Text, 2)
            m_BankAdjDtlAmountBefore = CDbl(.SubItems.Item(6).Text)
            m_BankAdjDtlLocalAmountBefore = CDbl(.SubItems.Item(7).Text)
            m_BankBalance = CDbl(.SubItems.Item(8).Text)

            If .SubItems.Item(4).Text = "IDR" Then
                ntbRate.ReadOnly = True
            Else
                ntbRate.ReadOnly = False
            End If

            If btnSaveD.Enabled = True Then
                btnBank.Enabled = False
            End If

            'Button1_Click(sender, e)
        End With
    End Sub

    Sub view_record()
        cmd = New SqlCommand("usp_tr_bank_adj_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@bank_adj_id", SqlDbType.Int)
        prm1.Value = m_BankAdjId
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@bank_adj_no", SqlDbType.NVarChar, 50)
        prm2.Value = txtBankAdjNo.Text

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtBankAdjNo.Text = myReader.GetString(0)
            dtpBankAdjDate.Value = myReader.GetDateTime(1)

            If Not myReader.IsDBNull(myReader.GetOrdinal("remarks")) Then
                txtBankAdjRemarks.Text = myReader.GetString(myReader.GetOrdinal("remarks"))
            Else
                txtBankAdjRemarks.Text = ""
            End If

            isPosted = myReader.GetBoolean(8)
            m_PeriodId = myReader.GetInt32(11)

            chbAffectedToGL.Checked = myReader.GetBoolean(12)
        End While

        myReader.Close()
        cn.Close()

        Dim mList As clsMyListInt
        For i = 1 To cmbPeriodId.Items.Count
            mList = cmbPeriodId.Items(i - 1)
            If m_PeriodId = mList.ItemData Then
                cmbPeriodId.SelectedIndex = i - 1
                Exit For
            End If
        Next

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_BankAdjId = 0
        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_BankAdjId = 0 Then
            Me.Close()
        Else
            lock_obj(True)
            lock_objD(True)
            clear_objD()
            m_BankAdjDId = 0
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If m_PeriodId <> cmbPeriodId.Items(cmbPeriodId.SelectedIndex).ItemData Then
            MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If

        If ListView1.Items.Count = 0 Then
            MsgBox("This bank adjustment has no detail rows!", vbInformation, "Warning")
        End If

        Try
            '20160607 daniel s : applock
            AppLock.GetLock()

            SaveBankAdjHeader()

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
            cmd = New SqlCommand("usp_tr_bank_adj_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@bank_adj_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtBankAdjNo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm2.Value = My.Settings.UserName

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            btnAdd_Click(sender, e)
        End If
        autoRefresh()
    End Sub

    Sub SaveBankAdjHeader()
        Try
            If m_BankAdjId = 0 Then
                If txtBankAdjNo.Text = "" Then
                    txtBankAdjNo.Text = GetSysNumber("bank_adj", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If
            End If

            cmd = New SqlCommand(IIf(m_BankAdjId = 0, "usp_tr_bank_adj_INS", "usp_tr_bank_adj_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@bank_adj_no", SqlDbType.NVarChar, 50)
            prm2.Value = txtBankAdjNo.Text
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@bank_adj_date", SqlDbType.SmallDateTime)
            prm3.Value = dtpBankAdjDate.Value.Date
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@remarks", SqlDbType.NVarChar, 255)
            prm4.Value = IIf(txtBankAdjRemarks.Text = "", DBNull.Value, txtBankAdjRemarks.Text)
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm5.Value = My.Settings.UserName
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@bank_adj_period_id", SqlDbType.Int)
            prm6.Value = cmbPeriodId.Items(cmbPeriodId.SelectedIndex).ItemData

            Dim prmIsAffectedGL As SqlParameter = cmd.Parameters.Add("@is_affected_gl", SqlDbType.Bit)
            prmIsAffectedGL.Value = IIf(chbAffectedToGL.Checked = True, 1, 0)

            If m_BankAdjId = 0 Then
                cn.Open()
                cmd.ExecuteReader()
                m_BankAdjId = 1
                cn.Close()
                If isGetNum = True Then UpdSysNumber("bank_adj")
                txtBankAdjNo.ReadOnly = True
            Else
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                'clear_lvw()
            End If
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

            SaveBankAdjHeader()

            If txtBankCode.Text = "" Then
                MsgBox("Please insert bank code!", vbCritical + vbOKOnly, Me.Text)
                txtBankAdjDesc.Focus()
                Exit Sub
            End If

            If isAllowBankMinus = False Then
                If (m_BankBalance - m_BankAdjDtlAmountBefore) + CDbl(ntbBankAdjAmount.Text) < 0 Then
                    MsgBox("Bank adjustment out amount > Bank balance amount!", vbCritical + vbOKOnly, Me.Text)
                    ntbBankAdjAmount.Focus()

                    '20160607 daniel s : applock
                    AppLock.ReleaseLock()

                    Exit Sub
                End If
            End If

            cmd = New SqlCommand(IIf(m_BankAdjDId = 0, "usp_tr_bank_adj_dtl_INS", "usp_tr_bank_adj_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm11 As SqlParameter = cmd.Parameters.Add("@bank_adj_no", SqlDbType.NVarChar, 50)
            prm11.Value = txtBankAdjNo.Text
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@bank_adj_type", SqlDbType.NVarChar, 5)
            prm12.Value = "BNADJ"
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@bank_adj_description", SqlDbType.NVarChar, 255)
            prm13.Value = IIf(txtBankAdjDesc.Text = "", DBNull.Value, txtBankAdjDesc.Text)
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@bank_code", SqlDbType.NVarChar, 50)
            prm14.Value = txtBankCode.Text
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@bank_curr_id", SqlDbType.Int)
            prm15.Value = m_CurrId
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@bank_adj_dtl_rate", SqlDbType.Decimal)
            prm16.Value = FormatNumber(ntbRate.Text, 2)
            Dim prm17 As SqlParameter = cmd.Parameters.Add("@bank_adj_amount", SqlDbType.Decimal)
            prm17.Value = FormatNumber(ntbBankAdjAmount.Text, 2)
            Dim prm18 As SqlParameter = cmd.Parameters.Add("@bank_adj_local_amount", SqlDbType.Decimal)
            prm18.Value = FormatNumber(CDbl(ntbRate.Text) * CDbl(ntbBankAdjAmount.Text), 2)

            If m_BankAdjDId <> 0 Then
                Dim prm21 As SqlParameter = cmd.Parameters.Add("@bank_adj_dtl_id", SqlDbType.Int)
                prm21.Value = m_BankAdjDId
                Dim prm22 As SqlParameter = cmd.Parameters.Add("@bank_adj_amount_before", SqlDbType.Decimal)
                prm22.Value = m_BankAdjDtlAmountBefore
                Dim prm23 As SqlParameter = cmd.Parameters.Add("@bank_adj_local_amount_before", SqlDbType.Decimal)
                prm23.Value = m_BankAdjDtlLocalAmountBefore
            End If
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()

            '20160607 daniel s : applock
            AppLock.ReleaseLock()

        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD.Click
        If m_BankAdjDId = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then

            '20160607 daniel s : applock
            AppLock.GetLock()

            cmd = New SqlCommand("usp_tr_bank_adj_dtl_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@bank_adj_dtl_id", SqlDbType.Int)
            prm1.Value = m_BankAdjDId

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()

            btnBank.Enabled = True

            '20160607 daniel s : applock
            AppLock.ReleaseLock()

        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Bank_Adj_Form '" & txtBankAdjNo.Text & "'"
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "Bank_Adj")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Bank_Adj_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Bank Adjustment"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("Bank_Adj"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub ntbStockAdjCost_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbBankAdjAmount.LostFocus
        If ntbBankAdjAmount.Text = "" Then ntbBankAdjAmount.Text = FormatNumber(0, 2)
    End Sub

    Private Sub ntbStockAdjQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbRate.LostFocus
        If ntbRate.Text = "" Then ntbRate.Text = FormatNumber(0, 2)
        If CDbl(ntbRate.Text) < 0 Then ntbRate.Text = CDbl(ntbRate.Text) * -1
    End Sub

    Private Sub ntbStockAdjQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbRate.TextChanged

    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        btnBank.Enabled = True
        clear_objD()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'lblm_BankAdjDId.Text = CStr(m_BankAdjDId)
        'lblm_BankAdjId.Text = CStr(m_BankAdjId)
        'lblm_CurrId.Text = CStr(m_CurrId)
        'lblm_BankBalance.Text = CStr(m_BankBalance)
        'm_m_BankAdjDtlAmountBefore.Text = CStr(m_BankAdjDtlAmountBefore)
        'm_m_BankAdjDtlLocalAmountBefore.Text = CStr(m_BankAdjDtlAmountBefore)
    End Sub
    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmBankAdjList).Any Then
            Call frmBankAdjList.frmBankAdjListShow(Nothing, EventArgs.Empty)
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