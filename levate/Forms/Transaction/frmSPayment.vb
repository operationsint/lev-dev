Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmSPayment
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_SPaymentId As Integer
    Dim m_CId As Integer
    Dim m_CurrId As Integer
    Dim m_BankId As Integer
    Dim m_CurrCustId As Integer
    Dim m_CurrCustCode As String
    Dim m_CurrBaseId As Integer
    Dim m_CurrBaseCode As String
    Dim m_CurrRate As String
    Dim m_PaymentType As String
    Dim m_SumSPaymentAdvance As Double
    Dim m_SPaymentTotalPaidBefore As Double
    Dim m_SPaymentAdvanceAllocationBefore As Double
    Dim m_SPaymentDId1 As Integer
    Dim m_SPaymentDId2 As Integer
    Dim m_SInvoiceId As Integer
    Dim m_SInvoiceCurrId As Integer
    Dim m_SPaymentAdvanceId As Integer
    'Dim m_CIdBefore As Integer
    'Dim m_SCodeTemp As String
    'Dim m_SNameTemp As String
    Dim m_SPaymentDtlValueBefore As Double
    Dim m_SPaymentAdvanceValue As Double
    Dim m_SPaymentAdvanceValueBefore As Double
    Dim m_PPaymentConversionValueBefore As Double
    Dim m_PeriodId As Integer
    Dim m_PeriodArr(0, 0) As String
    Dim m_PeriodArrSelected As Integer
    Dim isGetNum As Boolean
    Dim isPosted As Boolean
    Dim isAllowDelete As Boolean
    Private docAP As ReportDocument

    Private Sub frmSPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim prm1 As SqlParameter
        Dim prm2 As SqlParameter
        Dim myReader As SqlDataReader

        isAllowDelete = canDelete(Me.Name + "List")

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

        Dim i As Integer

        'Add item cmbPeriodId
        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@period_type", SqlDbType.NVarChar, 50)
        prm1.Value = "month_period"
        prm2 = cmd.Parameters.Add("@is_locked_ar", SqlDbType.Bit)
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
        prm2 = cmd.Parameters.Add("@is_locked_ar", SqlDbType.Bit)
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

        'Add item cmbPaymentType
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "payment_type"

        cn.Open()
        myReader = cmd.ExecuteReader

        cmbPaymentMethod.Items.Clear()
        While myReader.Read
            cmbPaymentMethod.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While
        cmbPaymentMethod.SelectedIndex = 0

        myReader.Close()
        cn.Close()

        If m_SPaymentId = 0 Then
            btnAdd_Click(sender, e)
        Else
            m_SPaymentDId1 = 0
            view_record()
            clear_lvw()
            clear_lvw2()
            'btnEdit_Click(sender, e)
            clear_objD()
            lock_obj(True)
            lock_objD(True)
            ntbSPaymentTotalPaid.ReadOnly = True
            'ntbSPaymentAdvanceTotal.ReadOnly = True
        End If
    End Sub

    Private Sub btnCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomer.Click
        txtBankCode.Text = ""
        If chbIsPaymentBaseCurr.Checked = True Then chbIsPaymentBaseCurr.Checked = False
        Dim NewFormDialog As New fdlCustomer
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
        If m_CurrCustId = m_CurrBaseId Or chbIsPaymentAdvance.Checked = True Then chbIsPaymentBaseCurr.Enabled = False Else chbIsPaymentBaseCurr.Enabled = True
    End Sub

    Public Property SPaymentId() As Integer
        Get
            Return m_SPaymentId
        End Get
        Set(ByVal Value As Integer)
            m_SPaymentId = Value
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
            Return ntbSPaymentCurrRate.Text
        End Get
        Set(ByVal Value As String)
            ntbSPaymentCurrRate.Text = Value
        End Set
    End Property

    Public Property CurrPaymentRate() As String
        Get
            Return m_CurrRate
        End Get
        Set(ByVal Value As String)
            m_CurrRate = Value
        End Set
    End Property

    Public Property CurrCustId() As Integer
        Get
            Return m_CurrCustId
        End Get
        Set(ByVal Value As Integer)
            m_CurrCustId = Value
        End Set
    End Property

    Public Property CurrCustCode() As String
        Get
            Return m_CurrCustCode
        End Get
        Set(ByVal Value As String)
            m_CurrCustCode = Value
        End Set
    End Property

    Public Property SORefNo() As String
        Get
            Return txtRefNo.Text
        End Get
        Set(ByVal Value As String)
            txtRefNo.Text = Value
        End Set
    End Property

    Public Property SPaymentRemarks() As String
        Get
            Return txtSPaymentRemarks.Text
        End Get
        Set(ByVal Value As String)
            txtSPaymentRemarks.Text = Value
        End Set
    End Property

    Public Property SAdvancePayment() As String
        Get
            Return txtSPaymentAdvanceAmount.Text
        End Get
        Set(ByVal Value As String)
            txtSPaymentAdvanceAmount.Text = Value
        End Set
    End Property

    Public Property SInvoiceId() As Integer
        Get
            Return m_SInvoiceId
        End Get
        Set(ByVal Value As Integer)
            m_SInvoiceId = Value
        End Set
    End Property

    Public Property SInvoiceCurrId() As Integer
        Get
            Return m_SInvoiceCurrId
        End Get
        Set(ByVal Value As Integer)
            m_SInvoiceCurrId = Value
        End Set
    End Property

    Public Property SInvoiceCurrCode() As String
        Get
            Return txtSInvoiceCurrCode.Text
        End Get
        Set(ByVal Value As String)
            txtSInvoiceCurrCode.Text = Value
        End Set
    End Property

    Public Property SInvoiceCurrRate() As String
        Get
            Return txtSInvoiceCurrRate.Text
        End Get
        Set(ByVal Value As String)
            txtSInvoiceCurrRate.Text = Value
        End Set
    End Property

    Public Property SInvoiceOutstanding() As String
        Get
            Return txtSInvoiceTotal.Text
        End Get
        Set(ByVal Value As String)
            txtSInvoiceTotal.Text = Value
        End Set
    End Property

    Public Property SInvoiceLocalOutstanding() As String
        Get
            Return txtLocalSInvoiceTotal.Text
        End Get
        Set(ByVal Value As String)
            txtLocalSInvoiceTotal.Text = Value
        End Set
    End Property

    Public Property SPaymentDtlValue() As String
        Get
            Return ntbSPaymentDtlValue.Text
        End Get
        Set(ByVal Value As String)
            ntbSPaymentDtlValue.Text = Value
        End Set
    End Property
    Public Property BankId() As Integer
        Get
            Return m_BankId
        End Get
        Set(ByVal Value As Integer)
            m_BankId = Value
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

    Sub clear_obj()
        m_SPaymentId = 0
        m_CId = 0
        m_CurrId = 0
        m_CurrCustId = 0
        m_CurrCustCode = ""
        m_SPaymentTotalPaidBefore = 0
        m_SumSPaymentAdvance = 0

        txtSPaymentNo.Text = ""
        dtpSPaymentDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtCCode.Text = ""
        txtCName.Text = ""
        txtCurrCode.Text = ""
        txtRefNo.Text = ""
        txtBankCode.Text = ""
        txtCBankDetail.Text = ""
        txtSPaymentRemarks.Text = ""
        chbIsPaymentAdvance.Checked = False
        chbIsPaymentBaseCurr.Checked = False
        ntbSPaymentCurrRate.Text = FormatNumber("1")
        'ntbSPaymentCrossRate.Text = FormatNumber("1")
        txtSPaymentTotalOutstanding.Text = FormatNumber("0")
        ntbSPaymentTotalPaid.Text = FormatNumber("0")
        txtSPaymentAdvanceAmount.Text = FormatNumber("0")
        txtSPaymentTotalAdvance.Text = FormatNumber("0")
        txtSPaymentTotalAllocation.Text = FormatNumber("0")
        txtPPaymentTotalConversion.Text = FormatNumber("0")
        txtCurrGainLossTotal.Text = FormatNumber("0")
        txtLocalPPaymentTotalOutstanding.Text = FormatNumber("0")
        txtLocalPPaymentTotalPaid.Text = FormatNumber("0")
        isGetNum = True
        isPosted = False
    End Sub

    Sub clear_objD()
        m_SPaymentDId1 = 0
        m_SInvoiceId = 0
        m_SInvoiceCurrId = 0
        m_SPaymentDtlValueBefore = 0
        m_PPaymentConversionValueBefore = 0
        txtSInvoiceNo.Text = ""
        txtSInvoiceCurrCode.Text = ""
        txtSInvoiceCurrRate.Text = ""
        txtSInvoiceTotal.Text = ""
        txtLocalSInvoiceTotal.Text = ""
        ntbSPaymentDtlCurrRate.Text = ""
        ntbSPaymentAdvanceAllocation.Text = ""
        ntbSPaymentDtlValue.Text = ""
        txtCurrGainLossValue.Text = ""
        txtSPaymentConversionValue.Text = ""

        m_SPaymentDId2 = 0
        m_SPaymentAdvanceId = 0
        m_SPaymentAdvanceValue = 0
        m_SPaymentAdvanceValueBefore = 0
        txtSPaymentAdvanceNo.Text = ""
        txtSPaymentAdvanceCurrCode.Text = ""
        txtSPaymentAdvanceCurrRate.Text = ""
        txtSPaymentAdvanceTotal.Text = ""
        txtSPaymentPreviousAdvance.Text = ""
        ntbSPaymentAdvanceValue.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        dtpSPaymentDate.Enabled = Not isLock
        cmbPaymentMethod.Enabled = Not isLock
        txtRefNo.ReadOnly = isLock
        txtCBankDetail.ReadOnly = isLock
        ntbSPaymentDtlCurrRate.ReadOnly = isLock
        txtSPaymentRemarks.ReadOnly = isLock
        btnCustomer.Enabled = Not isLock
        btnEdit.Enabled = isLock
        If isPosted = True Then btnEdit.Enabled = False
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnPrint.Enabled = isLock
        btnBank.Enabled = Not isLock
        If m_SPaymentId = 0 Then
            txtSPaymentNo.ReadOnly = False
            ntbSPaymentCurrRate.ReadOnly = False
            chbIsPaymentAdvance.Enabled = Not isLock
            chbIsPaymentBaseCurr.Enabled = Not isLock
            btnCustomer.Enabled = True
            btnDelete.Enabled = isLock
            btnBank.Enabled = True
        Else
            txtSPaymentNo.ReadOnly = True
            ntbSPaymentCurrRate.ReadOnly = True
            chbIsPaymentAdvance.Enabled = False
            chbIsPaymentBaseCurr.Enabled = False
            btnCustomer.Enabled = False
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
            btnBank.Enabled = False
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        ntbSPaymentAdvanceAllocation.ReadOnly = isLock
        ntbSPaymentDtlValue.ReadOnly = isLock
        btnSInvoice.Enabled = Not isLock
        btnSaveD1.Enabled = Not isLock
        btnDeleteD1.Enabled = Not isLock
        btnAddD1.Enabled = Not isLock

        ntbSPaymentAdvanceValue.ReadOnly = isLock
        btnAdvance.Enabled = Not isLock
        btnSaveD2.Enabled = Not isLock
        btnDeleteD2.Enabled = Not isLock
        btnAddD2.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("sinvoice_id", 0)
            .Columns.Add("Sales Invoice No.", 120)
            .Columns.Add("curr_id", 0)
            .Columns.Add("Currency", 90)
            .Columns.Add("Rate", 90, HorizontalAlignment.Right)
            .Columns.Add("Total Outstanding", 110, HorizontalAlignment.Right)
            .Columns.Add("Local Outstanding", 110, HorizontalAlignment.Right)
            .Columns.Add("Payment Currency Rate", 140, HorizontalAlignment.Right)
            .Columns.Add("Adv. Payment Allocation", 140, HorizontalAlignment.Right)
            .Columns.Add("Payment Value", 110, HorizontalAlignment.Right)
            .Columns.Add("Payment Conversion Value", 150, HorizontalAlignment.Right)
            .Columns.Add("Currency Gain/Loss", 110, HorizontalAlignment.Right)
            .Columns.Add("local_ppayment_advance_allocation", 0, HorizontalAlignment.Right)
            .Columns.Add("local_spayment_dtl_value", 0, HorizontalAlignment.Right)
        End With

        If m_SPaymentId <> 0 Then
            cmd = New SqlCommand("usp_tr_spayment_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@spayment_id", SqlDbType.Int)
            prm1.Value = m_SPaymentId

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(2)))
                lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                lvItem.SubItems.Add(myReader.GetString(3)) 'sinvoice_no
                lvItem.SubItems.Add(FormatNumber(myReader.GetInt32(4))) 'curr_id
                lvItem.SubItems.Add(myReader.GetString(5)) 'curr_code
                For i = 6 To 15
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

    Sub clear_lvw2()
        With ListView2
            .Clear()
            .View = View.Details
            .Columns.Add("spayment_advance_id", 0)
            .Columns.Add("Advance No.", 120)
            .Columns.Add("curr_id", 0)
            .Columns.Add("Currency", 90)
            .Columns.Add("Rate", 90, HorizontalAlignment.Right)
            .Columns.Add("Advance Payment", 140, HorizontalAlignment.Right)
            .Columns.Add("Previous Advance", 140, HorizontalAlignment.Right)
            .Columns.Add("Advance Value Allocation", 140, HorizontalAlignment.Right)
        End With

        If m_SPaymentId <> 0 Then
            cmd = New SqlCommand("usp_tr_spayment_advance_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@spayment_id", SqlDbType.Int)
            prm1.Value = m_SPaymentId

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(1)))
                lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                lvItem.SubItems.Add(myReader.GetString(2))
                lvItem.SubItems.Add(myReader.GetInt32(3))
                lvItem.SubItems.Add(myReader.GetString(4))
                For i = 5 To 8
                    lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
                Next
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
        End If
    End Sub

    Sub view_record()
        cmd = New SqlCommand("usp_tr_spayment_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@spayment_id", SqlDbType.Int)
        prm1.Value = m_SPaymentId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtSPaymentNo.Text = myReader.GetString(1)
            dtpSPaymentDate.Value = myReader.GetDateTime(2)
            m_CId = myReader.GetInt32(3)
            txtCCode.Text = myReader.GetString(4)
            txtCName.Text = myReader.GetString(5)
            m_PaymentType = myReader.GetString(6)
            If Not myReader.IsDBNull(myReader.GetOrdinal("spayment_ref_no")) Then
                txtRefNo.Text = myReader.GetString(myReader.GetOrdinal("spayment_ref_no"))
            Else
                txtRefNo.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("bank_code")) Then
                txtBankCode.Text = myReader.GetString(myReader.GetOrdinal("bank_code"))
            Else
                txtBankCode.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("c_bank_detail")) Then
                txtCBankDetail.Text = myReader.GetString(myReader.GetOrdinal("c_bank_detail"))
            Else
                txtCBankDetail.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("spayment_remarks")) Then
                txtSPaymentRemarks.Text = myReader.GetString(myReader.GetOrdinal("spayment_remarks"))
            Else
                txtSPaymentRemarks.Text = ""
            End If
            m_CurrId = myReader.GetInt32(11)
            txtCurrCode.Text = myReader.GetString(12)
            ntbSPaymentCurrRate.Text = FormatNumber(myReader.GetValue(13))
            'ntbSPaymentdtlcurrRate.Text = FormatNumber(myReader.GetValue(14))
            txtSPaymentTotalOutstanding.Text = FormatNumber(myReader.GetValue(15))
            txtSPaymentTotalAllocation.Text = FormatNumber(myReader.GetValue(16))
            txtSPaymentTotalAdvance.Text = FormatNumber(myReader.GetValue(17))
            m_SPaymentTotalPaidBefore = myReader.GetValue(18)
            ntbSPaymentTotalPaid.Text = FormatNumber(myReader.GetValue(18))
            txtSPaymentAdvanceAmount.Text = FormatNumber(myReader.GetValue(19))
            txtPPaymentTotalConversion.Text = FormatNumber(myReader.GetValue(20))
            txtCurrGainLossTotal.Text = FormatNumber(myReader.GetValue(21))
            m_SumSPaymentAdvance = myReader.GetValue(22)
            txtLocalPPaymentTotalOutstanding.Text = FormatNumber(myReader.GetValue(24))
            txtLocalPPaymentTotalPaid.Text = FormatNumber(myReader.GetValue(25))
            chbIsPaymentAdvance.Checked = myReader.GetBoolean(26)
            chbIsPaymentBaseCurr.Checked = myReader.GetBoolean(27)
            isPosted = myReader.GetBoolean(28)
            m_PeriodId = myReader.GetInt32(29)
        End While

        myReader.Close()
        cn.Close()

        If isPosted = True Then txtPeriodId.Text = GetPeriodName(m_PeriodId)

        Dim mList As clsMyListStr
        For i As Integer = 1 To cmbPaymentMethod.Items.Count
            mList = cmbPaymentMethod.Items(i - 1)
            If m_PaymentType = mList.ItemData Then
                cmbPaymentMethod.SelectedIndex = i - 1
                Exit For
            End If
        Next
    End Sub

    Sub refresh_total()
        cmd = New SqlCommand("usp_tr_spayment_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@spayment_id", SqlDbType.Int)
        prm1.Value = m_SPaymentId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtSPaymentTotalOutstanding.Text = FormatNumber(myReader.GetValue(15))
            txtSPaymentTotalAllocation.Text = FormatNumber(myReader.GetValue(16))
            txtSPaymentTotalAdvance.Text = FormatNumber(myReader.GetValue(17))
            ntbSPaymentTotalPaid.Text = FormatNumber(myReader.GetValue(18))
            txtSPaymentAdvanceAmount.Text = FormatNumber(myReader.GetValue(19))
            txtPPaymentTotalConversion.Text = FormatNumber(myReader.GetValue(20))
            txtCurrGainLossTotal.Text = FormatNumber(myReader.GetValue(21))
            txtLocalPPaymentTotalOutstanding.Text = FormatNumber(myReader.GetValue(24))
            txtLocalPPaymentTotalPaid.Text = FormatNumber(myReader.GetValue(25))
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_SPaymentId = 0

        clear_obj()
        clear_objD()
        clear_lvw()
        clear_lvw2()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_SPaymentId = 0 Then
            Me.Close()
        Else
            lock_obj(True)
            lock_objD(True)
            clear_objD()
            m_SPaymentDId1 = 0
            ntbSPaymentTotalPaid.ReadOnly = True
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If m_CId = 0 Or m_CurrId = 0 Then
                MsgBox("Customer Code and Customer Name are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtCCode.Focus()
                Exit Sub
            End If

            If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
                MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                Exit Sub
            End If

            If txtBankCode.Text = "" Then
                MsgBox("Please insert Bank Code!", vbCritical + vbOKOnly, Me.Text)
                txtBankCode.Focus()
                Exit Sub
            End If

            If CDbl(txtSPaymentAdvanceAmount.Text) > CDbl(txtSPaymentTotalAdvance.Text) Then
                MsgBox("Advance Receipt to Allocate does not equal Total Advance Receipt Allocated", vbExclamation + vbOKOnly, Me.Text)
                Exit Sub
            End If

            If CDbl(ntbSPaymentTotalPaid.Text) = 0 Then
                MsgBox("Warning,Sales Receipt total is 0 !", vbInformation, Me.Text)
            End If

            SaveSPaymentHeader()

            m_SPaymentTotalPaidBefore = CDbl(ntbSPaymentTotalPaid.Text)

            lock_obj(True)
            lock_objD(True)
            refresh_total()
            ntbSPaymentTotalPaid.ReadOnly = True

        Catch ex As Exception
            'If Err.Number = 5 Then
            '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
            'Else
            MsgBox(ex.Message)
            'End If
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Sub SaveSPaymentHeader()
        Try
            If m_SPaymentId = 0 Then
                If txtSPaymentNo.Text = "" Then
                    txtSPaymentNo.Text = GetSysNumber("spay", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If
            End If

            cmd = New SqlCommand(IIf(m_SPaymentId = 0, "usp_tr_spayment_INS", "usp_tr_spayment_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@spayment_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtSPaymentNo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@spayment_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpSPaymentDate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm3.Value = m_CId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@spayment_period_id", SqlDbType.Int)
            prm4.Value = m_PeriodArr(m_PeriodArrSelected, 0)
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@spayment_method", SqlDbType.NVarChar, 50)
            prm5.Value = cmbPaymentMethod.Items(cmbPaymentMethod.SelectedIndex).ItemData
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@spayment_ref_no", SqlDbType.NVarChar, 50)
            prm6.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@bank_code", SqlDbType.NVarChar, 50)
            prm7.Value = IIf(txtBankCode.Text = "", DBNull.Value, txtBankCode.Text)
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@c_bank_detail", SqlDbType.NVarChar)
            prm8.Value = IIf(txtCBankDetail.Text = "", DBNull.Value, txtCBankDetail.Text)
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@spayment_remarks", SqlDbType.NVarChar)
            prm9.Value = IIf(txtSPaymentRemarks.Text = "", DBNull.Value, txtSPaymentRemarks.Text)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm10.Value = m_CurrId
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@spayment_curr_rate", SqlDbType.Money)
            prm11.Value = IIf(chbIsPaymentBaseCurr.Checked = True, 1, FormatNumber(ntbSPaymentCurrRate.Text))
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@spayment_cross_rate", SqlDbType.Money)
            'prm12.Value = IIf(chbIsPaymentBaseCurr.Checked = False, 1, FormatNumber(ntbSPaymentCrossRate.Text))
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@spayment_total_paid", SqlDbType.Money)
            prm13.Value = FormatNumber(ntbSPaymentTotalPaid.Text)
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@is_payment_advance", SqlDbType.Bit)
            prm15.Value = chbIsPaymentAdvance.Checked
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@is_payment_base_curr", SqlDbType.Bit)
            prm16.Value = chbIsPaymentBaseCurr.Checked
            Dim prm17 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm17.Value = My.Settings.UserName
            Dim prm18 As SqlParameter = cmd.Parameters.Add("@spayment_id", SqlDbType.Int)

            If m_SPaymentId = 0 Then
                prm18.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_SPaymentId = prm18.Value
                'MessageBox.Show(m_SPaymentId)
                cn.Close()
                If isGetNum = True Then UpdSysNumber("spay")
                txtSPaymentNo.ReadOnly = True
                ntbSPaymentCurrRate.ReadOnly = True
                chbIsPaymentAdvance.Enabled = False
                chbIsPaymentBaseCurr.Enabled = False
                btnCustomer.Enabled = False
                btnBank.Enabled = False
            Else
                prm18.Value = m_SPaymentId
                'Dim prm18 As SqlParameter = cmd.Parameters.Add("@s_id_before", SqlDbType.Int)
                'prm18.Value = m_CIdBefore
                'Dim prm19 As SqlParameter = cmd.Parameters.Add("@ppayment_curr_rate_before", SqlDbType.Money)
                'prm19.Value = m_SPaymentAdvanceAllocationBefore
                Dim prm20 As SqlParameter = cmd.Parameters.Add("@spayment_total_paid_before", SqlDbType.Money)
                prm20.Value = m_SPaymentTotalPaidBefore

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
            End If
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
        If chbIsPaymentAdvance.Checked = True Then
            ntbSPaymentTotalPaid.ReadOnly = False
            lock_objD(True)
        Else
            ntbSPaymentTotalPaid.ReadOnly = True
        End If
        If chbIsPaymentBaseCurr.Checked = True Then
            ntbSPaymentDtlCurrRate.ReadOnly = False
            ntbSPaymentAdvanceAllocation.ReadOnly = True
        Else
            ntbSPaymentDtlCurrRate.ReadOnly = True
            If chbIsPaymentAdvance.Checked = True Then ntbSPaymentAdvanceAllocation.ReadOnly = True Else ntbSPaymentAdvanceAllocation.ReadOnly = False
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
                If chbIsPaymentAdvance.Checked = False Then
                    cmd = New SqlCommand("usp_tr_spayment_DEL", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm1 As SqlParameter = cmd.Parameters.Add("@spayment_id", SqlDbType.Int)
                    prm1.Value = m_SPaymentId
                    Dim prm2 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
                    prm2.Value = m_CId
                    Dim prm3 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
                    prm3.Value = m_CurrId
                    Dim prm4 As SqlParameter = cmd.Parameters.Add("@spayment_curr_rate", SqlDbType.Money)
                    prm4.Value = ntbSPaymentCurrRate.Text
                    Dim prm5 As SqlParameter = cmd.Parameters.Add("@spayment_total_allocation", SqlDbType.Money)
                    prm5.Value = FormatNumber(txtSPaymentTotalAllocation.Text)
                    Dim prm6 As SqlParameter = cmd.Parameters.Add("@spayment_total_advance", SqlDbType.Money)
                    prm6.Value = FormatNumber(txtSPaymentTotalAdvance.Text)
                    Dim prm7 As SqlParameter = cmd.Parameters.Add("@spayment_advance_amount", SqlDbType.Money)
                    prm7.Value = FormatNumber(txtSPaymentAdvanceAmount.Text)
                    Dim prm8 As SqlParameter = cmd.Parameters.Add("@spayment_total_conversion", SqlDbType.Money)
                    prm8.Value = txtPPaymentTotalConversion.Text
                    Dim prm9 As SqlParameter = cmd.Parameters.Add("@local_spayment_total_paid", SqlDbType.Money)
                    prm9.Value = txtLocalPPaymentTotalPaid.Text
                    Dim prm10 As SqlParameter = cmd.Parameters.Add("@is_payment_base_curr", SqlDbType.Bit)
                    prm10.Value = chbIsPaymentBaseCurr.Checked
                    Dim prm11 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                    prm11.Value = My.Settings.UserName
                    'Hendra
                    Dim prm12 As SqlParameter = cmd.Parameters.Add("@bank_code", SqlDbType.NVarChar, 50)
                    prm12.Value = txtBankCode.Text

                    cn.Open()
                    cmd.ExecuteReader()
                    cn.Close()
                    btnAdd_Click(sender, e)
                Else
                    cmd = New SqlCommand("usp_tr_spayment_DEL_ByAdvance", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm1 As SqlParameter = cmd.Parameters.Add("@spayment_id", SqlDbType.Int)
                    prm1.Value = m_SPaymentId
                    Dim prm2 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
                    prm2.Value = m_CId
                    Dim prm3 As SqlParameter = cmd.Parameters.Add("@spayment_total_paid", SqlDbType.Money)
                    prm3.Value = m_SPaymentTotalPaidBefore
                    Dim prm4 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                    prm4.Value = My.Settings.UserName
                    Dim prm5 As SqlParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int)
                    prm5.Direction = ParameterDirection.Output
                    'Hendra
                    Dim prm6 As SqlParameter = cmd.Parameters.Add("@bank_code", SqlDbType.NVarChar, 50)
                    prm6.Value = txtBankCode.Text
                    cn.Open()
                    cmd.ExecuteReader()
                    cn.Close()
                    If prm5.Value = 1 Then
                        MsgBox("You can't delete this record because it's already used in transaction.", vbCritical, Me.Text)
                    Else
                        clear_lvw()
                        clear_lvw2()
                        clear_obj()
                    End If
                    lock_obj(True)
                End If
            End If
        Catch ex As Exception
            'If Err.Number = 5 Then
            '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
            'Else
            MsgBox(ex.Message)
            'End If
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        autoRefresh()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Sls_Rcpt_Form '" & txtSPaymentNo.Text & "' "
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SRcpt_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_Rcpt_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Sales Receipt"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("SRcpt_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub ntbSPaymentTotal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSPaymentTotalPaid.LostFocus
        If ntbSPaymentTotalPaid.Text = "" Then ntbSPaymentTotalPaid.Text = FormatNumber(0)
        If m_SPaymentId <> 0 And chbIsPaymentAdvance.Checked = True And CDbl(ntbSPaymentTotalPaid.Text) < m_SumSPaymentAdvance Then
            MsgBox("Payment Advance Used is " & FormatNumber(m_SumSPaymentAdvance), vbInformation + vbOKOnly, Me.Text)
            ntbSPaymentTotalPaid.Text = FormatNumber(m_SumSPaymentAdvance)
        Else
            ntbSPaymentTotalPaid.Text = FormatNumber(ntbSPaymentTotalPaid.Text)
        End If
    End Sub

    Private Sub btnSInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSInvoice.Click
        If m_CId = 0 Or txtBankCode.Text = "" Then
            MsgBox("Customer & Bank information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtCCode.Focus()
            Exit Sub
        End If
        If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
            MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If
        Dim NewFormDialog As New fdlSInvoiceOut
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub chbIsPaymentAdvance_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbIsPaymentAdvance.CheckedChanged
        If chbIsPaymentAdvance.Checked = True Then
            chbIsPaymentBaseCurr.Checked = False
            chbIsPaymentBaseCurr.Enabled = False
            txtSPaymentAdvanceAmount.Text = FormatNumber(0)
            ntbSPaymentTotalPaid.ReadOnly = False
            clear_objD()
            lock_objD(True)
        Else
            chbIsPaymentBaseCurr.Enabled = True
            ntbSPaymentTotalPaid.ReadOnly = True
            lock_objD(False)
        End If
    End Sub

    Private Sub ntbSPaymentDtlValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSPaymentDtlValue.LostFocus
        If m_SPaymentDId1 > 0 Then
            If ntbSPaymentDtlValue.Text = "" Then ntbSPaymentDtlValue.Text = "0"
            If CDbl(txtSInvoiceTotal.Text) > 0 Then
                If CDbl(ntbSPaymentDtlValue.Text) < 0 Then ntbSPaymentDtlValue.Text = ntbSPaymentDtlValue.Text * -1
                If m_CurrId = m_SInvoiceCurrId And CDbl(ntbSPaymentDtlValue.Text) > CDbl(txtSInvoiceTotal.Text) Then
                    ntbSPaymentDtlValue.Text = txtSInvoiceTotal.Text
                    ntbSPaymentAdvanceAllocation.Text = FormatNumber(0)
                    'ElseIf m_CurrId <> m_SInvoiceCurrId And CDbl(ntbSPaymentDtlValue.Text) / CDbl(ntbPPaymentDtlCurrRate.Text) > CDbl(txtSInvoiceTotal.Text) Then
                    '    ntbSPaymentDtlValue.Text = CDbl(txtLocalSInvoiceTotal.Text) / CDbl(ntbPPaymentDtlCurrRate.Text)
                    '    ntbSPaymentAdvanceAllocation.Text = FormatNumber(0)
                    'End If
                ElseIf m_CurrId <> m_SInvoiceCurrId And CDbl(ntbSPaymentDtlValue.Text) / CDbl(ntbSPaymentDtlCurrRate.Text) > CDbl(txtSInvoiceTotal.Text) Then
                    ntbSPaymentDtlValue.Text = FormatNumber(CDbl(txtSInvoiceTotal.Text) * CDbl(ntbSPaymentDtlCurrRate.Text))
                    ntbSPaymentAdvanceAllocation.Text = FormatNumber(0)
                End If
            Else
                If CDbl(ntbSPaymentDtlValue.Text) > 0 Then ntbSPaymentDtlValue.Text = ntbSPaymentDtlValue.Text * -1
                If m_CurrId = m_SInvoiceCurrId And CDbl(ntbSPaymentDtlValue.Text) < CDbl(txtSInvoiceTotal.Text) Then
                    ntbSPaymentDtlValue.Text = txtSInvoiceTotal.Text
                    ntbSPaymentAdvanceAllocation.Text = FormatNumber(0)
                    'ElseIf m_CurrId <> m_SInvoiceCurrId And CDbl(ntbSPaymentDtlValue.Text) > CDbl(txtLocalSInvoiceTotal.Text) Then
                    '    ntbSPaymentDtlValue.Text = txtLocalSInvoiceTotal.Text
                    '    ntbSPaymentAdvanceAllocation.Text = FormatNumber(0)
                    'End If
                ElseIf m_CurrId <> m_SInvoiceCurrId And CDbl(ntbSPaymentDtlValue.Text) > CDbl(txtLocalSInvoiceTotal.Text) Then
                    ntbSPaymentDtlValue.Text = txtLocalSInvoiceTotal.Text
                    ntbSPaymentAdvanceAllocation.Text = FormatNumber(0)
                End If
            End If
            ntbSPaymentDtlValue.Text = FormatNumber(ntbSPaymentDtlValue.Text)
            If m_CurrId <> m_SInvoiceCurrId Then txtSPaymentConversionValue.Text = CDbl(ntbSPaymentDtlValue.Text) / CDbl(ntbSPaymentDtlCurrRate.Text)
        End If
    End Sub

    Private Sub ntbSPaymentCurrRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSPaymentCurrRate.LostFocus
        If ntbSPaymentCurrRate.Text.Length = 0 Then ntbSPaymentCurrRate.Undo()
        If m_SPaymentId = 0 Then
            If m_CurrId = m_CurrBaseId Then
                ntbSPaymentCurrRate.Text = "1"
            Else
                If ntbSPaymentCurrRate.DecimalValue = 0 Then ntbSPaymentCurrRate.Undo()
            End If
        End If
        ntbSPaymentCurrRate.Text = FormatNumber(ntbSPaymentCurrRate.Text)
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1.SelectedItems.Item(0)
            m_SPaymentDId1 = LeftSplitUF(.Tag)
            m_SInvoiceId = .SubItems.Item(0).Text
            txtSInvoiceNo.Text = .SubItems.Item(1).Text
            m_SInvoiceCurrId = .SubItems.Item(2).Text
            txtSInvoiceCurrCode.Text = .SubItems.Item(3).Text
            txtSInvoiceCurrRate.Text = FormatNumber(.SubItems.Item(4).Text)
            txtSInvoiceTotal.Text = FormatNumber(.SubItems.Item(5).Text)
            txtLocalSInvoiceTotal.Text = FormatNumber(.SubItems.Item(6).Text)
            ntbSPaymentDtlCurrRate.Text = FormatNumber(.SubItems.Item(7).Text)
            ntbSPaymentAdvanceAllocation.Text = FormatNumber(.SubItems.Item(8).Text)
            m_SPaymentAdvanceAllocationBefore = FormatNumber(.SubItems.Item(8).Text)
            ntbSPaymentDtlValue.Text = FormatNumber(.SubItems.Item(9).Text)
            m_SPaymentDtlValueBefore = FormatNumber(.SubItems.Item(9).Text)
            txtSPaymentConversionValue.Text = FormatNumber(.SubItems.Item(10).Text)
            m_PPaymentConversionValueBefore = FormatNumber(.SubItems.Item(10).Text)
            txtCurrGainLossValue.Text = FormatNumber(.SubItems.Item(11).Text)
        End With
    End Sub

    Private Sub btnSaveD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD1.Click
        Try
            If m_SPaymentId = 0 Then
                If m_CId = 0 Then
                    MsgBox("Customer Code and Customer Name are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                    txtCCode.Focus()
                    Exit Sub
                End If
            End If

            If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
                MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                Exit Sub
            End If

            If txtBankCode.Text = "" Then
                MsgBox("Please insert Bank Code!", vbCritical + vbOKOnly, Me.Text)
                txtBankCode.Focus()
                Exit Sub
            End If

            SaveSPaymentHeader()

            If m_SInvoiceId = 0 Then
                MsgBox("Please press the Sales Invoice button to select the Sales Invoice or at least select an item if you want to update.", vbCritical + vbOKOnly, Me.Text)
                txtSInvoiceNo.Focus()
                Exit Sub
            End If

            If m_SPaymentDId1 <> 0 Then
                If (m_CurrId = m_SInvoiceCurrId And CDbl(ntbSPaymentDtlValue.Text) + CDbl(ntbSPaymentAdvanceAllocation.Text) > CDbl(txtSInvoiceTotal.Text)) Or
                    (m_CurrId <> m_SInvoiceCurrId And CDbl(txtSPaymentConversionValue.Text) > CDbl(txtSInvoiceTotal.Text)) Then
                    MsgBox("Advance Payment Allocation + Payment Value > Total Outstanding. Please adjust", vbExclamation + vbOK, Me.Text)
                    ntbSPaymentDtlValue.Focus()
                    Exit Sub
                End If
                If CDbl(txtSPaymentTotalAdvance.Text) - m_SPaymentAdvanceAllocationBefore + CDbl(ntbSPaymentAdvanceAllocation.Text) > CDbl(txtSPaymentAdvanceAmount.Text) Then
                    MsgBox("Total Advance Payment Allocated + Advance Payment Allocation > Advance Payment to Allocate", vbExclamation + vbOK, Me.Text)
                    ntbSPaymentDtlValue.Focus()
                    Exit Sub
                End If
            End If

            cmd = New SqlCommand(IIf(m_SPaymentDId1 = 0, "usp_tr_spayment_dtl_INS", "usp_tr_spayment_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@spayment_id", SqlDbType.Int)
            prm1.Value = m_SPaymentId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm2.Value = m_CurrId
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@sinvoice_curr_id", SqlDbType.Int)
            prm3.Value = m_SInvoiceCurrId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int)
            prm4.Value = m_SInvoiceId
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@outstanding_value", SqlDbType.Money)
            prm5.Value = txtSInvoiceTotal.Text
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@spayment_advance_allocation", SqlDbType.Money)
            prm6.Value = ntbSPaymentAdvanceAllocation.Text
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@spayment_dtl_value", SqlDbType.Money)
            prm7.Value = FormatNumber(ntbSPaymentDtlValue.Text)
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@local_outstanding_value", SqlDbType.Money)
            prm8.Value = txtLocalSInvoiceTotal.Text
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@sinvoice_curr_rate", SqlDbType.Money)
            prm9.Value = FormatNumber(txtSInvoiceCurrRate.Text)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@spayment_curr_rate", SqlDbType.Money)
            prm10.Value = ntbSPaymentCurrRate.Text
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@spayment_dtl_curr_rate", SqlDbType.Money)
            prm11.Value = ntbSPaymentDtlCurrRate.Text
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm12.Value = CId

            If m_SPaymentDId1 <> 0 Then
                Dim prm14 As SqlParameter = cmd.Parameters.Add("@spayment_dtl_value_before", SqlDbType.Money)
                prm14.Value = m_SPaymentDtlValueBefore
                Dim prm15 As SqlParameter = cmd.Parameters.Add("@spayment_advance_allocation_before", SqlDbType.Money)
                prm15.Value = m_SPaymentAdvanceAllocationBefore
                Dim prm16 As SqlParameter = cmd.Parameters.Add("@spayment_conversion_value_before", SqlDbType.Money)
                prm16.Value = FormatNumber(m_PPaymentConversionValueBefore)
                Dim prm17 As SqlParameter = cmd.Parameters.Add("@spayment_dtl_id", SqlDbType.Int)
                prm17.Value = m_SPaymentDId1
            End If

            'Hendra
            Dim prm18 As SqlParameter = cmd.Parameters.Add("@bank_code", SqlDbType.NVarChar, 50)
            prm18.Value = txtBankCode.Text

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

    Private Sub btnDeleteD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD1.Click
        If m_SPaymentDId1 = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_tr_spayment_dtl_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@spayment_dtl_id", SqlDbType.Int, 50)
            prm1.Value = m_SPaymentDId1
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int, 50)
            prm2.Value = m_SInvoiceId
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm3.Value = m_CurrId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@sinvoice_curr_id", SqlDbType.Int)
            prm4.Value = m_SInvoiceCurrId
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@spayment_dtl_value", SqlDbType.Money)
            prm5.Value = m_SPaymentDtlValueBefore
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@spayment_advance_allocation", SqlDbType.Money)
            prm6.Value = m_SPaymentAdvanceAllocationBefore
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@spayment_conversion_value", SqlDbType.Money)
            prm7.Value = m_PPaymentConversionValueBefore
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@sinvoice_curr_rate", SqlDbType.Money)
            prm8.Value = txtSInvoiceCurrRate.Text
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm9.Value = CId
            'Hendra
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@bank_code", SqlDbType.NVarChar, 50)
            prm10.Value = txtBankCode.Text

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()
            refresh_total()
        End If
    End Sub

    Private Sub btnAdvance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdvance.Click
        If m_CId = 0 Or txtBankCode.Text = "" Then
            MsgBox("Customer & Bank information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtCCode.Focus()
            Exit Sub
        End If
        If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
            MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If
        Dim NewFormDialog As New fdlSPaymentAdvance
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSaveD2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD2.Click
        Try
            If m_SPaymentId = 0 Then
                If m_CId = 0 Then
                    MsgBox("Customer Code and Customer Name are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                    txtCCode.Focus()
                    Exit Sub
                End If
            End If

            If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
                MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                Exit Sub
            End If

            SaveSPaymentHeader()

            If m_SPaymentAdvanceId = 0 Then
                MsgBox("Please press the Advance Transaction button to select the Advance Transaction or at least select an item if you want to update.", vbCritical + vbOKOnly, Me.Text)
                txtSPaymentAdvanceNo.Focus()
                Exit Sub
            End If

            If m_SPaymentDId2 <> 0 Then
                'Validation script to check the total allocation with total value
            End If

            cmd = New SqlCommand(IIf(m_SPaymentDId2 = 0, "usp_tr_spayment_advance_INS", "usp_tr_spayment_advance_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@spayment_id", SqlDbType.Int)
            prm1.Value = m_SPaymentId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm2.Value = m_CId
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@spayment_advance_id", SqlDbType.Int)
            prm3.Value = m_SPaymentAdvanceId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@spayment_advance_value", SqlDbType.Money)
            prm4.Value = CDbl(ntbSPaymentAdvanceValue.Text)

            If m_SPaymentDId2 <> 0 Then
                Dim prm15 As SqlParameter = cmd.Parameters.Add("@spayment_advance_value_before", SqlDbType.Money)
                prm15.Value = m_SPaymentAdvanceValueBefore
                Dim prm16 As SqlParameter = cmd.Parameters.Add("@spayment_dtl_id2", SqlDbType.Int)
                prm16.Value = m_SPaymentDId2
            End If
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw2()
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

    Private Sub ListView2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.Click
        With ListView2.SelectedItems.Item(0)
            m_SPaymentDId2 = LeftSplitUF(.Tag)
            m_SPaymentAdvanceId = .SubItems.Item(0).Text
            txtSPaymentAdvanceNo.Text = .SubItems.Item(1).Text
            'm_SInvoiceCurrId = .SubItems.Item(2).Text
            txtSPaymentAdvanceCurrCode.Text = .SubItems.Item(3).Text
            txtSPaymentAdvanceCurrRate.Text = FormatNumber(.SubItems.Item(4).Text)
            txtSPaymentAdvanceTotal.Text = FormatNumber(.SubItems.Item(5).Text)
            txtSPaymentPreviousAdvance.Text = FormatNumber(.SubItems.Item(6).Text)
            ntbSPaymentAdvanceValue.Text = FormatNumber(.SubItems.Item(7).Text)
            m_SPaymentAdvanceValue = CDbl(.SubItems.Item(7).Text)
            m_SPaymentAdvanceValueBefore = FormatNumber(.SubItems.Item(7).Text)
        End With
    End Sub

    Private Sub btnDeleteD2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD2.Click
        If m_SPaymentDId2 = 0 Then Exit Sub
        If CDbl(txtSPaymentAdvanceAmount.Text) - CDbl(ntbSPaymentAdvanceValue.Text) < CDbl(txtSPaymentTotalAdvance.Text) Then
            MsgBox("Total Payment Advance Allocated > Advance Payment to allocate - Advance Value Allocation", vbExclamation + vbOKOnly, Me.Text)
            Exit Sub
        End If
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_tr_spayment_advance_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@spayment_dtl_id2", SqlDbType.Int, 50)
            prm1.Value = m_SPaymentDId2
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int, 50)
            prm2.Value = m_CId
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@spayment_advance_value", SqlDbType.Money)
            prm3.Value = m_SPaymentAdvanceValue

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw2()
            clear_objD()
            refresh_total()
        End If
    End Sub

    Private Sub ntbSPaymentAdvanceAllocation_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSPaymentAdvanceAllocation.LostFocus
        If m_SPaymentDId1 > 0 Then
            If ntbSPaymentAdvanceAllocation.Text = "" Then ntbSPaymentAdvanceAllocation.Text = "0"
            If CDbl(txtSInvoiceTotal.Text) > 0 Then
                If m_CurrId = m_SInvoiceCurrId Then
                    If CDbl(ntbSPaymentAdvanceAllocation.Text) > CDbl(txtSInvoiceTotal.Text) Then
                        ntbSPaymentAdvanceAllocation.Text = txtSInvoiceTotal.Text
                        ntbSPaymentDtlValue.Text = FormatNumber(0)
                    Else
                        ntbSPaymentDtlValue.Text = FormatNumber(CDbl(txtSInvoiceTotal.Text) - CDbl(ntbSPaymentAdvanceAllocation.Text))
                    End If
                End If
            Else
                If m_CurrId = m_SInvoiceCurrId Then
                    If CDbl(txtSInvoiceTotal.Text) < 0 And CDbl(ntbSPaymentAdvanceAllocation.Text) > 0 Then ntbSPaymentAdvanceAllocation.Text = ntbSPaymentAdvanceAllocation.Text * -1
                    If CDbl(ntbSPaymentAdvanceAllocation.Text) < CDbl(txtSInvoiceTotal.Text) Then
                        ntbSPaymentAdvanceAllocation.Text = txtSInvoiceTotal.Text
                        ntbSPaymentDtlValue.Text = FormatNumber(0)
                    Else
                        ntbSPaymentDtlValue.Text = FormatNumber(CDbl(txtSInvoiceTotal.Text) - CDbl(ntbSPaymentAdvanceAllocation.Text))
                    End If
                End If
            End If
            ntbSPaymentAdvanceAllocation.Text = FormatNumber(ntbSPaymentAdvanceAllocation.Text)
        End If
    End Sub

    Private Sub frmSPayment_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If CDbl(txtSPaymentAdvanceAmount.Text) > CDbl(txtSPaymentTotalAdvance.Text) Then
            MsgBox("Advance Payment to Allocate doest not equal Total Advance Payment Allocated", vbExclamation + vbOKOnly, Me.Text)
            e.Cancel = True
        End If
    End Sub

    Private Sub btnAddD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD1.Click
        clear_objD()
    End Sub

    Private Sub btnAddD2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD2.Click
        clear_objD()
    End Sub

    Private Sub ntbSPaymentAdvanceValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSPaymentAdvanceValue.LostFocus
        If m_SPaymentDId2 > 0 Then
            If ntbSPaymentAdvanceValue.Text = "" Then ntbSPaymentAdvanceValue.Text = "0"
            If CDbl(txtSPaymentAdvanceTotal.Text) - CDbl(txtSPaymentPreviousAdvance.Text) - CDbl(ntbSPaymentAdvanceValue.Text) < 0 Then
                MsgBox("Advance value that you enter just now are higher than suppose to be. Please enter it with the same total or less.", vbInformation, Me.Text)
                ntbSPaymentAdvanceValue.Text = FormatNumber(m_SPaymentAdvanceValueBefore)
            Else
                ntbSPaymentAdvanceValue.Text = FormatNumber(ntbSPaymentAdvanceValue.Text)
            End If
        End If
    End Sub

    Private Sub chbIsPaymentBaseCurr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbIsPaymentBaseCurr.CheckedChanged
        txtBankCode.Text = ""
        If chbIsPaymentBaseCurr.Checked = True Then
            txtCurrCode.Text = m_CurrBaseCode
            ntbSPaymentCurrRate.Text = FormatNumber(1)
            m_CurrId = m_CurrBaseId
            ntbSPaymentCurrRate.ReadOnly = True
            ntbSPaymentDtlCurrRate.ReadOnly = False
            ntbSPaymentAdvanceAllocation.ReadOnly = True
        Else
            txtCurrCode.Text = m_CurrCustCode
            ntbSPaymentCurrRate.Text = 1
            m_CurrId = m_CurrCustId
            ntbSPaymentCurrRate.Text = m_CurrRate
            ntbSPaymentCurrRate.ReadOnly = False
            ntbSPaymentDtlCurrRate.ReadOnly = True
            ntbSPaymentAdvanceAllocation.ReadOnly = False
        End If
    End Sub

    Private Sub ntbPPaymentDtlCurrRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSPaymentDtlCurrRate.LostFocus
        If m_SPaymentDId1 > 0 Then
            ntbSPaymentDtlCurrRate.Text = FormatNumber(IIf(ntbSPaymentDtlCurrRate.Text = "", IIf(m_CurrId = m_SInvoiceCurrId, 1, txtSInvoiceCurrRate.Text), ntbSPaymentDtlCurrRate.Text))
            ntbSPaymentDtlValue.Text = IIf(m_CurrId <> m_SInvoiceCurrId, FormatNumber(CDbl(txtSInvoiceTotal.Text) * CDbl(ntbSPaymentDtlCurrRate.Text)), ntbSPaymentDtlValue.Text)
            txtSPaymentConversionValue.Text = IIf(m_CurrId <> m_SInvoiceCurrId, FormatNumber(CDbl(ntbSPaymentDtlValue.Text) / CDbl(ntbSPaymentDtlCurrRate.Text)), txtSPaymentConversionValue.Text)
        End If
    End Sub

    Private Sub ntbPPaymentDtlCurrRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbSPaymentDtlCurrRate.TextChanged

    End Sub

    Private Sub btnBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBank.Click
        If txtCurrCode.Text <> "" Then
            Dim NewFormDialog As New fdlBank
            NewFormDialog.FrmCallerId = Me.Name
            NewFormDialog.ShowDialog()
        Else
            MsgBox("Please insert customer code first !.", vbCritical + vbOKOnly, Me.Text)
            txtCCode.Focus()
        End If
    End Sub

    Private Sub dtpSPaymentDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSPaymentDate.ValueChanged
        Dim isCheckIn As Boolean
        For i As Integer = 0 To m_PeriodArr.GetUpperBound(0)
            If dtpSPaymentDate.Value >= m_PeriodArr(i, 2) AndAlso dtpSPaymentDate.Value <= m_PeriodArr(i, 3) Then
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
    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmSPaymentList).Any Then
            Call frmSPaymentList.frmSPaymentListShow(Nothing, EventArgs.Empty)
        End If
    End Sub
End Class
