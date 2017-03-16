Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmPPayment
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_PPaymentId As Integer
    Dim m_SId As Integer
    Dim m_CurrId As Integer
    Dim m_BankId As Integer
    Dim m_CurrSuppId As Integer
    Dim m_CurrSuppCode As String
    Dim m_CurrBaseId As Integer
    Dim m_CurrBaseCode As String
    Dim m_CurrRate As String
    Dim m_PaymentType As String
    Dim m_SumPPaymentAdvance As Double
    Dim m_PPaymentTotalPaidBefore As Double
    Dim m_PPaymentAdvanceAllocationBefore As Double
    Dim m_PPaymentDId1 As Integer
    Dim m_PPaymentDId2 As Integer
    Dim m_PInvoiceId As Integer
    Dim m_PInvoiceCurrId As Integer
    Dim m_PPaymentAdvanceId As Integer
    Dim m_SIdBefore As Integer
    Dim m_SCodeTemp As String
    Dim m_SNameTemp As String
    Dim m_PPaymentDtlValueBefore As Double
    Dim m_PPaymentAdvanceValue As Double
    Dim m_PPaymentAdvanceValueBefore As Double
    Dim m_PPaymentConversionValueBefore As Double
    Dim m_PInvoiceTotal As Double
    Dim m_PeriodId As Integer
    Dim m_PeriodArr(0, 0) As String
    Dim m_PeriodArrSelected As Integer
    Dim isGetNum As Boolean
    Dim isAllowDelete As Boolean
    Dim isPosted As Boolean
    Private docAP As ReportDocument
    Dim Dec As Integer = GetSysInit("decimal_digit")
    Dim isAllowBankMinus As Boolean = GetSysInit("bank_amount_minus")
    Dim m_BankBalance As Double

    Private Sub frmPPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Dim i As Integer = 0

        'Add item cmbPeriodId
        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@period_type", SqlDbType.NVarChar, 50)
        prm1.Value = "month_period"
        prm2 = cmd.Parameters.Add("@is_locked_ap", SqlDbType.Bit)
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
        prm2 = cmd.Parameters.Add("@is_locked_ap", SqlDbType.Bit)
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

        If m_PPaymentId = 0 Then
            btnAdd_Click(sender, e)
        Else
            m_PPaymentDId1 = 0
            view_record()
            clear_lvw()
            clear_lvw2()
            'btnEdit_Click(sender, e)
            clear_objD()
            lock_obj(True)
            lock_objD(True)
            ntbPPaymentTotalPaid.ReadOnly = True
            'ntbPPaymentAdvanceTotal.ReadOnly = True
        End If
    End Sub

    Private Sub btnSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplier.Click
        txtBankCode.Text = ""
        If chbIsPaymentBaseCurr.Checked = True Then chbIsPaymentBaseCurr.Checked = False
        Dim NewFormDialog As New fdlSupplier
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
        If m_CurrSuppId = m_CurrBaseId Or chbIsPaymentAdvance.Checked = True Then chbIsPaymentBaseCurr.Enabled = False Else chbIsPaymentBaseCurr.Enabled = True
    End Sub

    Public Property PPaymentId() As Integer
        Get
            Return m_PPaymentId
        End Get
        Set(ByVal Value As Integer)
            m_PPaymentId = Value
        End Set
    End Property

    Public Property SId() As Integer
        Get
            Return m_SId
        End Get
        Set(ByVal Value As Integer)
            m_SId = Value
        End Set
    End Property

    Public Property SCode() As String
        Get
            Return txtSCode.Text
        End Get
        Set(ByVal Value As String)
            txtSCode.Text = Value
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

    Public Property SName() As String
        Get
            Return txtSName.Text
        End Get
        Set(ByVal Value As String)
            txtSName.Text = Value
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
            Return ntbPPaymentCurrRate.Text
        End Get
        Set(ByVal Value As String)
            ntbPPaymentCurrRate.Text = Value
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

    Public Property CurrSuppId() As Integer
        Get
            Return m_CurrSuppId
        End Get
        Set(ByVal Value As Integer)
            m_CurrSuppId = Value
        End Set
    End Property

    Public Property CurrSuppCode() As String
        Get
            Return m_CurrSuppCode
        End Get
        Set(ByVal Value As String)
            m_CurrSuppCode = Value
        End Set
    End Property

    Public Property PORefNo() As String
        Get
            Return txtRefNo.Text
        End Get
        Set(ByVal Value As String)
            txtRefNo.Text = Value
        End Set
    End Property

    Public Property PPaymentRemarks() As String
        Get
            Return txtPPaymentRemarks.Text
        End Get
        Set(ByVal Value As String)
            txtPPaymentRemarks.Text = Value
        End Set
    End Property

    Public Property SAdvancePayment() As String
        Get
            Return txtPPaymentAdvanceAmount.Text
        End Get
        Set(ByVal Value As String)
            txtPPaymentAdvanceAmount.Text = Value
        End Set
    End Property

    Public Property PInvoiceId() As Integer
        Get
            Return m_PInvoiceId
        End Get
        Set(ByVal Value As Integer)
            m_PInvoiceId = Value
        End Set
    End Property

    Public Property PInvoiceCurrId() As Integer
        Get
            Return m_PInvoiceCurrId
        End Get
        Set(ByVal Value As Integer)
            m_PInvoiceCurrId = Value
        End Set
    End Property

    Public Property PInvoiceCurrCode() As String
        Get
            Return txtPInvoiceCurrCode.Text
        End Get
        Set(ByVal Value As String)
            txtPInvoiceCurrCode.Text = Value
        End Set
    End Property

    Public Property PInvoiceCurrRate() As String
        Get
            Return txtPInvoiceCurrRate.Text
        End Get
        Set(ByVal Value As String)
            txtPInvoiceCurrRate.Text = Value
        End Set
    End Property

    Public Property PInvoiceOutstanding() As String
        Get
            Return txtPInvoiceTotal.Text
        End Get
        Set(ByVal Value As String)
            txtPInvoiceTotal.Text = Value
        End Set
    End Property

    Public Property PInvoiceLocalOutstanding() As String
        Get
            Return txtLocalPInvoiceTotal.Text
        End Get
        Set(ByVal Value As String)
            txtLocalPInvoiceTotal.Text = Value
        End Set
    End Property

    Public Property PPaymentDtlValue() As String
        Get
            Return ntbPPaymentDtlValue.Text
        End Get
        Set(ByVal Value As String)
            ntbPPaymentDtlValue.Text = Value
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
        m_PPaymentId = 0
        m_SId = 0
        m_CurrId = 0
        m_CurrSuppId = 0
        m_CurrSuppCode = ""
        m_PPaymentTotalPaidBefore = 0
        m_SumPPaymentAdvance = 0
        txtPPaymentNo.Text = ""
        dtpPPaymentDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtSCode.Text = ""
        txtSName.Text = ""
        txtCurrCode.Text = ""
        txtRefNo.Text = ""
        txtBankCode.Text = ""
        txtSBankDetail.Text = ""
        txtPPaymentRemarks.Text = ""
        chbIsPaymentAdvance.Checked = False
        chbIsPaymentBaseCurr.Checked = False
        ntbPPaymentCurrRate.Text = FormatNumber("1")
        'ntbPPaymentDtlCurrRate.Text = FormatNumber("1")
        txtPPaymentTotalOutstanding.Text = FormatNumber("0")
        ntbPPaymentTotalPaid.Text = FormatNumber("0")
        txtPPaymentAdvanceAmount.Text = FormatNumber("0")
        txtPPaymentTotalAdvance.Text = FormatNumber("0")
        txtPPaymentTotalAllocation.Text = FormatNumber("0")
        txtPPaymentTotalConversion.Text = FormatNumber("0")
        txtCurrGainLossTotal.Text = FormatNumber("0")
        txtLocalPPaymentTotalOutstanding.Text = FormatNumber("0")
        txtLocalPPaymentTotalPaid.Text = FormatNumber("0")
        isGetNum = True
        isPosted = False
    End Sub

    Sub clear_objD()
        m_PPaymentDId1 = 0
        m_PInvoiceId = 0
        m_PInvoiceCurrId = 0
        m_PPaymentAdvanceAllocationBefore = 0
        m_PPaymentDtlValueBefore = 0
        m_PPaymentConversionValueBefore = 0
        txtPInvoiceNo.Text = ""
        txtPInvoiceCurrCode.Text = ""
        txtPInvoiceCurrRate.Text = ""
        txtPInvoiceTotal.Text = ""
        txtLocalPInvoiceTotal.Text = ""
        ntbPPaymentDtlCurrRate.Text = ""
        ntbPPaymentAdvanceAllocation.Text = ""
        ntbPPaymentDtlValue.Text = ""
        txtCurrGainLossValue.Text = ""
        txtPPaymentConversionValue.Text = ""

        m_PPaymentDId2 = 0
        m_PPaymentAdvanceId = 0
        m_PPaymentAdvanceValue = 0
        m_PPaymentAdvanceValueBefore = 0
        txtPPaymentAdvanceNo.Text = ""
        txtPPaymentAdvanceCurrCode.Text = ""
        txtPPaymentAdvanceCurrRate.Text = ""
        txtPPaymentAdvanceTotal.Text = ""
        txtPPaymentPreviousAdvance.Text = ""
        ntbPPaymentAdvanceValue.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        dtpPPaymentDate.Enabled = Not isLock
        cmbPaymentMethod.Enabled = Not isLock
        txtRefNo.ReadOnly = isLock
        txtSBankDetail.ReadOnly = isLock
        ntbPPaymentDtlCurrRate.ReadOnly = isLock
        txtPPaymentRemarks.ReadOnly = isLock
        btnSupplier.Enabled = Not isLock
        btnEdit.Enabled = isLock
        If isPosted = True Then btnEdit.Enabled = False
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnPrint.Enabled = isLock
        btnBank.Enabled = Not isLock
        If m_PPaymentId = 0 Then
            txtPPaymentNo.ReadOnly = False
            ntbPPaymentCurrRate.ReadOnly = False
            chbIsPaymentAdvance.Enabled = Not isLock
            chbIsPaymentBaseCurr.Enabled = Not isLock
            btnSupplier.Enabled = True
            btnBank.Enabled = True
            btnDelete.Enabled = isLock
        Else
            txtPPaymentNo.ReadOnly = True
            ntbPPaymentCurrRate.ReadOnly = True
            chbIsPaymentAdvance.Enabled = False
            chbIsPaymentBaseCurr.Enabled = False
            btnSupplier.Enabled = False
            btnBank.Enabled = False
            'If p_UserLevel = 1 Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        'ntbPPaymentDtlCurrRate.ReadOnly = True
        ntbPPaymentAdvanceAllocation.ReadOnly = isLock
        ntbPPaymentDtlValue.ReadOnly = isLock
        btnPInvoice.Enabled = Not isLock
        btnSaveD1.Enabled = Not isLock
        btnDeleteD1.Enabled = Not isLock
        btnAddD1.Enabled = Not isLock

        ntbPPaymentAdvanceValue.ReadOnly = isLock
        btnAdvance.Enabled = Not isLock
        btnSaveD2.Enabled = Not isLock
        btnDeleteD2.Enabled = Not isLock
        btnAddD2.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("pinvoice_id", 0)
            .Columns.Add("Purchase Invoice No.", 120)
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
            .Columns.Add("local_ppayment_dtl_value", 0, HorizontalAlignment.Right)
            .Columns.Add("outstanding_value", 0, HorizontalAlignment.Right)
            .Columns.Add("local_outstanding_value", 0, HorizontalAlignment.Right)
            .Columns.Add("ppayment_advance_allocation", 0, HorizontalAlignment.Right)
            .Columns.Add("ppayment_dtl_value", 0, HorizontalAlignment.Right)
            .Columns.Add("ppayment_conversion_value", 0, HorizontalAlignment.Right)
        End With

        If m_PPaymentId <> 0 Then
            cmd = New SqlCommand("usp_tr_ppayment_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppayment_id", SqlDbType.Int)
            prm1.Value = m_PPaymentId

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(2))) 'pinvoice_id
                lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                lvItem.SubItems.Add(myReader.GetString(3)) 'pinvoice_no
                lvItem.SubItems.Add(FormatNumber(myReader.GetInt32(4))) 'curr_id
                lvItem.SubItems.Add(myReader.GetString(5)) 'curr_code
                For i = 6 To 15
                    lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
                Next
                lvItem.SubItems.Add(myReader.Item(7)) 'outstanding_value
                lvItem.SubItems.Add(myReader.Item(8)) 'local_outstanding_value
                lvItem.SubItems.Add(myReader.Item(10)) 'ppayment_advance_allocation
                lvItem.SubItems.Add(myReader.Item(11)) 'ppayment_dtl_value
                lvItem.SubItems.Add(myReader.Item(12)) 'ppayment_conversion_value
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
            .Columns.Add("ppayment_advance_id", 0)
            .Columns.Add("Advance No.", 120)
            .Columns.Add("curr_id", 0)
            .Columns.Add("Currency", 90)
            .Columns.Add("Rate", 90, HorizontalAlignment.Right)
            .Columns.Add("Advance Payment", 140, HorizontalAlignment.Right)
            .Columns.Add("Previous Advance", 140, HorizontalAlignment.Right)
            .Columns.Add("Advance Value Allocation", 140, HorizontalAlignment.Right)
        End With

        If m_PPaymentId <> 0 Then
            cmd = New SqlCommand("usp_tr_ppayment_advance_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppayment_id", SqlDbType.Int)
            prm1.Value = m_PPaymentId

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
                lvItem.SubItems.Add(FormatNumber(myReader.Item(5)))
                For i = 6 To 8
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
        cmd = New SqlCommand("usp_tr_ppayment_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppayment_id", SqlDbType.Int)
        prm1.Value = m_PPaymentId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtPPaymentNo.Text = myReader.GetString(1)
            dtpPPaymentDate.Value = myReader.GetDateTime(2)
            m_SId = myReader.GetInt32(3)
            m_SIdBefore = myReader.GetInt32(3)
            txtSCode.Text = myReader.GetString(4)
            m_SCodeTemp = myReader.GetString(4)
            txtSName.Text = myReader.GetString(5)
            m_SNameTemp = myReader.GetString(5)
            m_PaymentType = myReader.GetString(6)
            If Not myReader.IsDBNull(myReader.GetOrdinal("ppayment_ref_no")) Then
                txtRefNo.Text = myReader.GetString(myReader.GetOrdinal("ppayment_ref_no"))
            Else
                txtRefNo.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("bank_code")) Then
                txtBankCode.Text = myReader.GetString(myReader.GetOrdinal("bank_code"))
            Else
                txtBankCode.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("s_bank_detail")) Then
                txtSBankDetail.Text = myReader.GetString(myReader.GetOrdinal("s_bank_detail"))
            Else
                txtSBankDetail.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("ppayment_remarks")) Then
                txtPPaymentRemarks.Text = myReader.GetString(myReader.GetOrdinal("ppayment_remarks"))
            Else
                txtPPaymentRemarks.Text = ""
            End If
            m_CurrId = myReader.GetInt32(11)
            txtCurrCode.Text = myReader.GetString(12)
            ntbPPaymentCurrRate.Text = FormatNumber(myReader.GetValue(13))
            'ntbPPaymentDtlCurrRate.Text = FormatNumber(myReader.GetValue(14))
            txtPPaymentTotalOutstanding.Text = FormatNumber(myReader.GetValue(15))
            txtPPaymentTotalAllocation.Text = FormatNumber(myReader.GetValue(16))
            txtPPaymentTotalAdvance.Text = FormatNumber(myReader.GetValue(17))
            m_PPaymentTotalPaidBefore = myReader.GetValue(18)
            ntbPPaymentTotalPaid.Text = FormatNumber(myReader.GetValue(18))
            txtPPaymentAdvanceAmount.Text = FormatNumber(myReader.GetValue(19))
            txtPPaymentTotalConversion.Text = FormatNumber(myReader.GetValue(20))
            txtCurrGainLossTotal.Text = FormatNumber(myReader.GetValue(21))
            m_SumPPaymentAdvance = myReader.GetValue(22)
            txtLocalPPaymentTotalOutstanding.Text = FormatNumber(myReader.GetValue(24))
            txtLocalPPaymentTotalPaid.Text = FormatNumber(myReader.GetValue(25))
            chbIsPaymentAdvance.Checked = myReader.GetBoolean(26)
            chbIsPaymentBaseCurr.Checked = myReader.GetBoolean(27)
            m_BankBalance = myReader.GetValue(28)
            isPosted = myReader.GetBoolean(29)
            m_PeriodId = myReader.GetInt32(30)
        End While

        myReader.Close()
        cn.Close()

        If isPosted = True Then txtPeriodId.Text = GetPeriodName(m_PeriodId)

        Dim i As Integer

        Dim mList2 As clsMyListStr
        For i = 1 To cmbPaymentMethod.Items.Count
            mList2 = cmbPaymentMethod.Items(i - 1)
            If m_PaymentType = mList2.ItemData Then
                cmbPaymentMethod.SelectedIndex = i - 1
                Exit For
            End If
        Next
    End Sub

    Sub refresh_total()
        cmd = New SqlCommand("usp_tr_ppayment_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppayment_id", SqlDbType.Int)
        prm1.Value = m_PPaymentId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtPPaymentTotalOutstanding.Text = FormatNumber(myReader.GetValue(15))
            txtPPaymentTotalAllocation.Text = FormatNumber(myReader.GetValue(16))
            txtPPaymentTotalAdvance.Text = FormatNumber(myReader.GetValue(17))
            ntbPPaymentTotalPaid.Text = FormatNumber(myReader.GetValue(18))
            txtPPaymentAdvanceAmount.Text = FormatNumber(myReader.GetValue(19))
            txtPPaymentTotalConversion.Text = FormatNumber(myReader.GetValue(20))
            txtCurrGainLossTotal.Text = FormatNumber(myReader.GetValue(21))
            txtLocalPPaymentTotalOutstanding.Text = FormatNumber(myReader.GetValue(24))
            txtLocalPPaymentTotalPaid.Text = FormatNumber(myReader.GetValue(25))
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_PPaymentId = 0

        clear_obj()
        clear_objD()
        clear_lvw()
        clear_lvw2()
        lock_obj(False)
        lock_objD(False)

        ntbPPaymentDtlCurrRate.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_PPaymentId = 0 Then
            Me.Close()
        Else
            lock_obj(True)
            lock_objD(True)
            clear_objD()
            m_PPaymentDId1 = 0
            ntbPPaymentTotalPaid.ReadOnly = True
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If m_SId = 0 Or m_CurrId = 0 Then
                MsgBox("Supplier Code and Supplier Name are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtSCode.Focus()
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

            If CDbl(txtPPaymentAdvanceAmount.Text) > CDbl(txtPPaymentTotalAdvance.Text) Then
                MsgBox("Advance Payment to Allocate does not equal Total Advance Payment Allocated", vbExclamation + vbOKOnly, Me.Text)
                Exit Sub
            End If

            If isAllowBankMinus = False Then
                If (m_BankBalance + m_PPaymentTotalPaidBefore) - CDbl(ntbPPaymentTotalPaid.Text) < 0 Then
                    MsgBox("Purchase payment amount > Bank balance amount!", vbCritical + vbOKOnly, Me.Text)
                    ntbPPaymentTotalPaid.Focus()
                    Exit Sub
                End If
            End If

            If CDbl(ntbPPaymentTotalPaid.Text) = 0 Then
                MsgBox("Warning,Purchase Payment total is 0 !", vbInformation, Me.Text)
            End If

            SavePPaymentHeader()

            m_PPaymentTotalPaidBefore = CDbl(ntbPPaymentTotalPaid.Text)

            lock_obj(True)
            lock_objD(True)
            refresh_total()
            ntbPPaymentTotalPaid.ReadOnly = True

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

    Sub SavePPaymentHeader()
        Try
            AppLock.GetLock()

            If m_PPaymentId = 0 Then
                If txtPPaymentNo.Text.Trim = "" Then
                    txtPPaymentNo.Text = GetSysNumber("ppay", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If
            End If

            cmd = New SqlCommand(IIf(m_PPaymentId = 0, "usp_tr_ppayment_INS", "usp_tr_ppayment_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppayment_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtPPaymentNo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@ppayment_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpPPaymentDate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
            prm3.Value = m_SId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@ppayment_period_id", SqlDbType.Int)
            prm4.Value = m_PeriodArr(m_PeriodArrSelected, 0)
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@ppayment_method", SqlDbType.NVarChar, 50)
            prm5.Value = cmbPaymentMethod.Items(cmbPaymentMethod.SelectedIndex).ItemData
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@ppayment_ref_no", SqlDbType.NVarChar, 50)
            prm6.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@bank_code", SqlDbType.NVarChar, 50)
            prm7.Value = IIf(txtBankCode.Text = "", DBNull.Value, txtBankCode.Text)
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@s_bank_detail", SqlDbType.NVarChar)
            prm8.Value = IIf(txtSBankDetail.Text = "", DBNull.Value, txtSBankDetail.Text)
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@ppayment_remarks", SqlDbType.NVarChar)
            prm9.Value = IIf(txtPPaymentRemarks.Text = "", DBNull.Value, txtPPaymentRemarks.Text)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm10.Value = m_CurrId
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@ppayment_curr_rate", SqlDbType.Money)
            prm11.Value = FormatNumber(ntbPPaymentCurrRate.Text)
            'Dim prm12 As SqlParameter = cmd.Parameters.Add("@ppayment_cross_rate", SqlDbType.Money)
            'prm12.Value = IIf(m_CurrBaseId = 0, 1, FormatNumber(ntbPPaymentDtlCurrRate.Text))
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@ppayment_total_paid", SqlDbType.Money)
            prm13.Value = FormatNumber(ntbPPaymentTotalPaid.Text)
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@is_payment_advance", SqlDbType.Bit)
            prm15.Value = chbIsPaymentAdvance.Checked
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@is_payment_base_curr", SqlDbType.Bit)
            prm16.Value = chbIsPaymentBaseCurr.Checked
            Dim prm17 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm17.Value = My.Settings.UserName
            Dim prm18 As SqlParameter = cmd.Parameters.Add("@ppayment_id", SqlDbType.Int)

            If m_PPaymentId = 0 Then
                prm18.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_PPaymentId = prm18.Value
                'MessageBox.Show(m_PPaymentId)
                cn.Close()
                If isGetNum = True Then UpdSysNumber("ppay")
                txtPPaymentNo.ReadOnly = True
                ntbPPaymentCurrRate.ReadOnly = True
                chbIsPaymentAdvance.Enabled = False
                chbIsPaymentBaseCurr.Enabled = False
                btnSupplier.Enabled = False
                btnBank.Enabled = False
            Else
                prm18.Value = m_PPaymentId
                'Dim prm18 As SqlParameter = cmd.Parameters.Add("@s_id_before", SqlDbType.Int)
                'prm18.Value = m_SIdBefore
                'Dim prm19 As SqlParameter = cmd.Parameters.Add("@ppayment_curr_rate_before", SqlDbType.Money)
                'prm19.Value = m_PPaymentAdvanceAllocationBefore
                Dim prm20 As SqlParameter = cmd.Parameters.Add("@ppayment_total_paid_before", SqlDbType.Money)
                prm20.Value = FormatNumber(m_PPaymentTotalPaidBefore)

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
            End If

        Catch ex As Exception
            'If Err.Number = 5 Then
            '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
            'Else
            MsgBox(ex.Message)
            'End If
            If ConnectionState.Open = 1 Then cn.Close()
        Finally
            AppLock.ReleaseLock()
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        clear_objD()
        lock_obj(False)
        lock_objD(False)
        If chbIsPaymentAdvance.Checked = True Then
            ntbPPaymentTotalPaid.ReadOnly = False
            lock_objD(True)
        Else
            ntbPPaymentTotalPaid.ReadOnly = True
        End If
        If chbIsPaymentBaseCurr.Checked = True Then
            ntbPPaymentDtlCurrRate.ReadOnly = False
            ntbPPaymentAdvanceAllocation.ReadOnly = True
        Else
            ntbPPaymentDtlCurrRate.ReadOnly = True
            If chbIsPaymentAdvance.Checked = True Then ntbPPaymentAdvanceAllocation.ReadOnly = True Else ntbPPaymentAdvanceAllocation.ReadOnly = False
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Try
            If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then

                AppLock.GetLock()

                If chbIsPaymentAdvance.Checked = False Then
                    cmd = New SqlCommand("usp_tr_ppayment_DEL", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppayment_id", SqlDbType.Int)
                    prm1.Value = m_PPaymentId
                    Dim prm2 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
                    prm2.Value = m_SId
                    Dim prm3 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
                    prm3.Value = m_CurrId
                    Dim prm4 As SqlParameter = cmd.Parameters.Add("@ppayment_curr_rate", SqlDbType.Money)
                    prm4.Value = ntbPPaymentCurrRate.Text
                    Dim prm5 As SqlParameter = cmd.Parameters.Add("@ppayment_total_allocation", SqlDbType.Money)
                    prm5.Value = FormatNumber(txtPPaymentTotalAllocation.Text)
                    Dim prm6 As SqlParameter = cmd.Parameters.Add("@ppayment_total_advance", SqlDbType.Money)
                    prm6.Value = FormatNumber(txtPPaymentTotalAdvance.Text)
                    Dim prm7 As SqlParameter = cmd.Parameters.Add("@ppayment_advance_amount", SqlDbType.Money)
                    prm7.Value = FormatNumber(txtPPaymentAdvanceAmount.Text)
                    Dim prm8 As SqlParameter = cmd.Parameters.Add("@ppayment_total_conversion", SqlDbType.Money)
                    prm8.Value = txtPPaymentTotalConversion.Text
                    Dim prm9 As SqlParameter = cmd.Parameters.Add("@local_ppayment_total_paid", SqlDbType.Money)
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
                    cmd = New SqlCommand("usp_tr_ppayment_DEL_ByAdvance", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppayment_id", SqlDbType.Int)
                    prm1.Value = m_PPaymentId
                    Dim prm2 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
                    prm2.Value = m_SId
                    Dim prm3 As SqlParameter = cmd.Parameters.Add("@ppayment_total_paid", SqlDbType.Money)
                    prm3.Value = FormatNumber(m_PPaymentTotalPaidBefore)
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

                    AppLock.ReleaseLock()

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
        Finally
            AppLock.ReleaseLock()
        End Try
        autoRefresh()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Pch_Payment_Form '" & txtPPaymentNo.Text & "' "
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "PPay_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Pch_Payment_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Purchase Payment"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("PPay_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub ntbPPaymentTotal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPPaymentTotalPaid.LostFocus
        If ntbPPaymentTotalPaid.Text = "" Then ntbPPaymentTotalPaid.Text = FormatNumber(0)
        If m_PPaymentId <> 0 And chbIsPaymentAdvance.Checked = True And CDbl(ntbPPaymentTotalPaid.Text) < m_SumPPaymentAdvance Then
            MsgBox("Payment Advance Used is " & FormatNumber(m_SumPPaymentAdvance), vbInformation + vbOKOnly, Me.Text)
            ntbPPaymentTotalPaid.Text = FormatNumber(m_SumPPaymentAdvance)
        Else
            ntbPPaymentTotalPaid.Text = FormatNumber(ntbPPaymentTotalPaid.Text)
        End If
    End Sub

    Private Sub btnPchCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim NewFormDialog As New fdlPchCode
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPInvoice.Click
        If m_SId = 0 Or txtBankCode.Text = "" Then
            MsgBox("Supplier & Bank information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtSCode.Focus()
            Exit Sub
        End If
        If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
            MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If
        Dim NewFormDialog As New fdlPInvoiceOut
        NewFormDialog.BankBalance = m_BankBalance
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub chbIsPaymentAdvance_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbIsPaymentAdvance.CheckedChanged
        If chbIsPaymentAdvance.Checked = True Then
            chbIsPaymentBaseCurr.Checked = False
            chbIsPaymentBaseCurr.Enabled = False
            txtPPaymentAdvanceAmount.Text = FormatNumber(0)
            ntbPPaymentTotalPaid.ReadOnly = False
            clear_objD()
            lock_objD(True)
        Else
            chbIsPaymentBaseCurr.Enabled = True
            ntbPPaymentTotalPaid.ReadOnly = True
            lock_objD(False)
        End If
    End Sub

    Private Sub ntbPPaymentDtlValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPPaymentDtlValue.LostFocus
        If m_PPaymentDId1 > 0 Then
            If ntbPPaymentDtlValue.Text = "" Then ntbPPaymentDtlValue.Text = "0"
            If CDbl(txtPInvoiceTotal.Text) > 0 Then
                If CDbl(ntbPPaymentDtlValue.Text) < 0 Then ntbPPaymentDtlValue.Text = ntbPPaymentDtlValue.Text * -1
                If m_CurrId = m_PInvoiceCurrId And CDbl(ntbPPaymentDtlValue.Text) > CDbl(txtPInvoiceTotal.Text) Then
                    ntbPPaymentDtlValue.Text = txtPInvoiceTotal.Text
                    ntbPPaymentAdvanceAllocation.Text = FormatNumber(0)
                    'ElseIf CDbl(ntbPPaymentAdvanceAllocation.Text) > 0 Then
                    '    ntbPPaymentAdvanceAllocation.Text = FormatNumber(CDbl(txtPInvoiceTotal.Text) - CDbl(ntbPPaymentDtlValue.Text))
                ElseIf m_CurrId <> m_PInvoiceCurrId And CDbl(ntbPPaymentDtlValue.Text) / CDbl(ntbPPaymentDtlCurrRate.Text) > CDbl(txtPInvoiceTotal.Text) Then
                    ntbPPaymentDtlValue.Text = CDbl(txtPInvoiceTotal.Text) * CDbl(ntbPPaymentDtlCurrRate.Text)
                    ntbPPaymentAdvanceAllocation.Text = FormatNumber(0)
                End If
            Else
                If CDbl(ntbPPaymentDtlValue.Text) > 0 Then ntbPPaymentDtlValue.Text = ntbPPaymentDtlValue.Text * -1
                If m_CurrId = m_PInvoiceCurrId And CDbl(ntbPPaymentDtlValue.Text) < CDbl(txtPInvoiceTotal.Text) Then
                    ntbPPaymentDtlValue.Text = txtPInvoiceTotal.Text
                    ntbPPaymentAdvanceAllocation.Text = FormatNumber(0)
                    'ElseIf CDbl(ntbPPaymentAdvanceAllocation.Text) < 0 Then
                    '    ntbPPaymentAdvanceAllocation.Text = FormatNumber(CDbl(txtPInvoiceTotal.Text) - CDbl(ntbPPaymentDtlValue.Text))
                ElseIf m_CurrId <> m_PInvoiceCurrId And CDbl(ntbPPaymentDtlValue.Text) > CDbl(txtLocalPInvoiceTotal.Text) Then
                    ntbPPaymentDtlValue.Text = txtLocalPInvoiceTotal.Text
                    ntbPPaymentAdvanceAllocation.Text = FormatNumber(0)
                End If
            End If
            ntbPPaymentDtlValue.Text = FormatNumber(ntbPPaymentDtlValue.Text)
            'txtPPaymentConversionValue.Text = FormatNumber(CDbl(ntbPPaymentDtlValue.Text) / CDbl(ntbPPaymentDtlCurrRate.Text))
            If m_CurrId <> m_PInvoiceCurrId Then txtPPaymentConversionValue.Text = CDbl(ntbPPaymentDtlValue.Text) / CDbl(ntbPPaymentDtlCurrRate.Text)
        End If
    End Sub

    Private Sub ntbPPaymentCurrRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPPaymentCurrRate.LostFocus
        If ntbPPaymentCurrRate.Text.Length = 0 Then ntbPPaymentCurrRate.Undo()
        If m_PPaymentId = 0 Then
            If m_CurrId = m_CurrBaseId Then
                ntbPPaymentCurrRate.Text = "1"
            Else
                If ntbPPaymentCurrRate.DecimalValue = 0 Then ntbPPaymentCurrRate.Undo()
            End If
        End If
        ntbPPaymentCurrRate.Text = FormatNumber(ntbPPaymentCurrRate.Text)
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1.SelectedItems.Item(0)
            m_PPaymentDId1 = LeftSplitUF(.Tag)
            m_PInvoiceId = .SubItems.Item(0).Text
            txtPInvoiceNo.Text = .SubItems.Item(1).Text
            m_PInvoiceCurrId = .SubItems.Item(2).Text
            txtPInvoiceCurrCode.Text = .SubItems.Item(3).Text
            txtPInvoiceCurrRate.Text = FormatNumber(.SubItems.Item(4).Text)
            txtPInvoiceTotal.Text = FormatNumber(.SubItems.Item(5).Text)
            'txtPInvoiceTotal.Text = .SubItems.Item(14).Text
            txtLocalPInvoiceTotal.Text = FormatNumber(.SubItems.Item(6).Text)
            ntbPPaymentDtlCurrRate.Text = FormatNumber(.SubItems.Item(7).Text)
            ntbPPaymentAdvanceAllocation.Text = FormatNumber(.SubItems.Item(8).Text)
            m_PPaymentAdvanceAllocationBefore = FormatNumber(.SubItems.Item(8).Text)
            ntbPPaymentDtlValue.Text = .SubItems.Item(9).Text
            m_PPaymentDtlValueBefore = CDbl(.SubItems.Item(9).Text)
            'ntbPPaymentDtlValue.Text = .SubItems.Item(17).Text
            'm_PPaymentDtlValueBefore = CDbl(.SubItems.Item(17).Text)
            txtPPaymentConversionValue.Text = FormatNumber(.SubItems.Item(10).Text)
            'txtPPaymentConversionValue.Text = .SubItems.Item(18).Text
            m_PPaymentConversionValueBefore = CDbl(.SubItems.Item(10).Text)
            txtCurrGainLossValue.Text = FormatNumber(.SubItems.Item(11).Text)
        End With
    End Sub

    Private Sub btnSaveD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD1.Click
        Try
            If m_PPaymentId = 0 Then
                If m_SId = 0 Then
                    MsgBox("Supplier Code and Supplier Name are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                    txtSCode.Focus()
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

            SavePPaymentHeader()

            If m_PInvoiceId = 0 Then
                MsgBox("Please press the Purchase Invoice button to select the Purchase Invoice or at least select an item if you want to update.", vbCritical + vbOKOnly, Me.Text)
                txtPInvoiceNo.Focus()
                Exit Sub
            End If

            If m_PPaymentDId1 <> 0 Then
                If CDbl(txtPInvoiceTotal.Text) > 0 Then
                    If (m_CurrId = m_PInvoiceCurrId And CDbl(ntbPPaymentDtlValue.Text) + CDbl(ntbPPaymentAdvanceAllocation.Text) > CDbl(txtPInvoiceTotal.Text)) Or
                        (m_CurrId <> m_PInvoiceCurrId And CDbl(txtPPaymentConversionValue.Text) > CDbl(txtPInvoiceTotal.Text)) Then
                        MsgBox("Advance Payment Allocation + Payment Value > Total Outstanding. Please adjust", vbExclamation + vbOK, Me.Text)
                        ntbPPaymentDtlValue.Focus()
                        Exit Sub
                    End If
                    If CDbl(txtPPaymentTotalAdvance.Text) - m_PPaymentAdvanceAllocationBefore + CDbl(ntbPPaymentAdvanceAllocation.Text) > CDbl(txtPPaymentAdvanceAmount.Text) Then
                        MsgBox("Total Advance Payment Allocated + Advance Payment Allocation > Advance Payment to Allocate", vbExclamation + vbOK, Me.Text)
                        ntbPPaymentAdvanceAllocation.Focus()
                        Exit Sub
                    End If
                End If
            End If

            If isAllowBankMinus = False Then
                If (m_BankBalance - m_PPaymentDtlValueBefore) + CDbl(ntbPPaymentDtlValue.Text) < 0 Then
                    MsgBox("Purchase payment amount > Bank balance amount!", vbCritical + vbOKOnly, Me.Text)
                    ntbPPaymentDtlValue.Focus()
                    Exit Sub
                End If
            End If

            AppLock.GetLock()

            cmd = New SqlCommand(IIf(m_PPaymentDId1 = 0, "usp_tr_ppayment_dtl_INS", "usp_tr_ppayment_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppayment_id", SqlDbType.Int)
            prm1.Value = m_PPaymentId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm2.Value = m_CurrId
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@pinvoice_curr_id", SqlDbType.Int)
            prm3.Value = m_PInvoiceCurrId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@pinvoice_id", SqlDbType.Int)
            prm4.Value = m_PInvoiceId
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@outstanding_value", SqlDbType.Money)
            prm5.Value = txtPInvoiceTotal.Text
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@ppayment_advance_allocation", SqlDbType.Money)
            prm6.Value = ntbPPaymentAdvanceAllocation.Text
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@ppayment_dtl_value", SqlDbType.Money)
            prm7.Value = ntbPPaymentDtlValue.Text
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@local_outstanding_value", SqlDbType.Money)
            prm8.Value = txtLocalPInvoiceTotal.Text
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@pinvoice_curr_rate", SqlDbType.Money)
            prm9.Value = FormatNumber(txtPInvoiceCurrRate.Text)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@ppayment_curr_rate", SqlDbType.Money)
            prm10.Value = ntbPPaymentCurrRate.Text
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@ppayment_dtl_curr_rate", SqlDbType.Money)
            prm11.Value = ntbPPaymentDtlCurrRate.Text
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
            prm12.Value = SId

            If m_PPaymentDId1 <> 0 Then
                Dim prm14 As SqlParameter = cmd.Parameters.Add("@ppayment_dtl_value_before", SqlDbType.Money)
                prm14.Value = m_PPaymentDtlValueBefore
                Dim prm15 As SqlParameter = cmd.Parameters.Add("@ppayment_advance_allocation_before", SqlDbType.Money)
                prm15.Value = m_PPaymentAdvanceAllocationBefore
                Dim prm16 As SqlParameter = cmd.Parameters.Add("@ppayment_conversion_value_before", SqlDbType.Money)
                prm16.Value = m_PPaymentConversionValueBefore
                Dim prm17 As SqlParameter = cmd.Parameters.Add("@ppayment_dtl_id", SqlDbType.Int)
                prm17.Value = m_PPaymentDId1
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
        Finally
            AppLock.ReleaseLock()
        End Try
    End Sub

    Private Sub btnDeleteD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD1.Click
        If m_PPaymentDId1 = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then

            AppLock.GetLock()

            cmd = New SqlCommand("usp_tr_ppayment_dtl_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppayment_dtl_id", SqlDbType.Int, 50)
            prm1.Value = m_PPaymentDId1
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@pinvoice_id", SqlDbType.Int, 50)
            prm2.Value = m_PInvoiceId
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm3.Value = m_CurrId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@pinvoice_curr_id", SqlDbType.Int)
            prm4.Value = m_PInvoiceCurrId
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@ppayment_dtl_value", SqlDbType.Money)
            prm5.Value = m_PPaymentDtlValueBefore
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@ppayment_advance_allocation", SqlDbType.Money)
            prm6.Value = m_PPaymentAdvanceAllocationBefore
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@ppayment_conversion_value", SqlDbType.Money)
            prm7.Value = m_PPaymentConversionValueBefore
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@pinvoice_curr_rate", SqlDbType.Money)
            prm8.Value = txtPInvoiceCurrRate.Text
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
            prm9.Value = SId
            'Hendra
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@bank_code", SqlDbType.NVarChar, 50)
            prm10.Value = txtBankCode.Text

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            AppLock.ReleaseLock()

            clear_lvw()
            clear_objD()
            refresh_total()
        End If
    End Sub

    Private Sub btnAdvance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdvance.Click
        If m_SId = 0 Or txtBankCode.Text = "" Then
            MsgBox("Supplier & Bank information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtSCode.Focus()
            Exit Sub
        End If
        If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
            MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If
        Dim NewFormDialog As New fdlPPaymentAdvance
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSaveD2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD2.Click
        Try
            If m_PPaymentId = 0 Then
                If m_SId = 0 Then
                    MsgBox("Supplier Code and Supplier Name are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                    txtSCode.Focus()
                    Exit Sub
                End If
            End If

            If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
                MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                Exit Sub
            End If

            SavePPaymentHeader()

            If m_PPaymentAdvanceId = 0 Then
                MsgBox("Please press the Advance Transaction button to select the Advance Transaction or at least select an item if you want to update.", vbCritical + vbOKOnly, Me.Text)
                txtPPaymentAdvanceNo.Focus()
                Exit Sub
            End If

            cmd = New SqlCommand(IIf(m_PPaymentDId2 = 0, "usp_tr_ppayment_advance_INS", "usp_tr_ppayment_advance_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppayment_id", SqlDbType.Int)
            prm1.Value = m_PPaymentId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
            prm2.Value = m_SId
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@ppayment_advance_id", SqlDbType.Int)
            prm3.Value = m_PPaymentAdvanceId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@ppayment_advance_value", SqlDbType.Money)
            prm4.Value = FormatNumber(CDbl(ntbPPaymentAdvanceValue.Text))

            If m_PPaymentDId2 <> 0 Then
                Dim prm15 As SqlParameter = cmd.Parameters.Add("@ppayment_advance_value_before", SqlDbType.Money)
                prm15.Value = m_PPaymentAdvanceValueBefore
                Dim prm16 As SqlParameter = cmd.Parameters.Add("@ppayment_dtl_id2", SqlDbType.Int)
                prm16.Value = m_PPaymentDId2
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
            m_PPaymentDId2 = LeftSplitUF(.Tag)
            m_PPaymentAdvanceId = .SubItems.Item(0).Text
            txtPPaymentAdvanceNo.Text = .SubItems.Item(1).Text
            'm_PInvoiceCurrId = .SubItems.Item(2).Text
            txtPPaymentAdvanceCurrCode.Text = .SubItems.Item(3).Text
            txtPPaymentAdvanceCurrRate.Text = FormatNumber(.SubItems.Item(4).Text)
            txtPPaymentAdvanceTotal.Text = FormatNumber(.SubItems.Item(5).Text)
            txtPPaymentPreviousAdvance.Text = FormatNumber(.SubItems.Item(6).Text)
            ntbPPaymentAdvanceValue.Text = FormatNumber(.SubItems.Item(7).Text)
            m_PPaymentAdvanceValue = CDbl(.SubItems.Item(7).Text)
            m_PPaymentAdvanceValueBefore = CDbl(.SubItems.Item(7).Text)
        End With
    End Sub

    Private Sub btnDeleteD2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD2.Click
        If m_PPaymentDId2 = 0 Then Exit Sub
        If CDbl(txtPPaymentAdvanceAmount.Text) - CDbl(ntbPPaymentAdvanceValue.Text) < CDbl(txtPPaymentTotalAdvance.Text) Then
            MsgBox("Total Payment Advance Allocated > Advance Payment to allocate - Advance Value Allocation", vbExclamation + vbOKOnly, Me.Text)
            Exit Sub
        End If
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_tr_ppayment_advance_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppayment_dtl_id2", SqlDbType.Int, 50)
            prm1.Value = m_PPaymentDId2
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int, 50)
            prm2.Value = m_SId
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@ppayment_advance_value", SqlDbType.Money)
            prm3.Value = m_PPaymentAdvanceValue

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw2()
            clear_objD()
            refresh_total()
        End If
    End Sub

    Private Sub ntbPPaymentAdvanceAllocation_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPPaymentAdvanceAllocation.LostFocus
        If m_PPaymentDId1 > 0 Then
            If ntbPPaymentAdvanceAllocation.Text = "" Then ntbPPaymentAdvanceAllocation.Text = "0"
            If CDbl(txtPInvoiceTotal.Text) > 0 Then
                If m_CurrId = m_PInvoiceCurrId Then
                    If CDbl(ntbPPaymentAdvanceAllocation.Text) > CDbl(txtPInvoiceTotal.Text) Then
                        ntbPPaymentAdvanceAllocation.Text = txtPInvoiceTotal.Text
                        ntbPPaymentDtlValue.Text = FormatNumber(0)
                    Else
                        ntbPPaymentDtlValue.Text = FormatNumber(CDbl(txtPInvoiceTotal.Text) - CDbl(ntbPPaymentAdvanceAllocation.Text))
                    End If
                End If
            Else
                If m_CurrId = m_PInvoiceCurrId Then
                    If CDbl(txtPInvoiceTotal.Text) < 0 And CDbl(ntbPPaymentAdvanceAllocation.Text) > 0 Then ntbPPaymentAdvanceAllocation.Text = ntbPPaymentAdvanceAllocation.Text * -1
                    If CDbl(ntbPPaymentAdvanceAllocation.Text) < CDbl(txtPInvoiceTotal.Text) Then
                        ntbPPaymentAdvanceAllocation.Text = txtPInvoiceTotal.Text
                        ntbPPaymentDtlValue.Text = FormatNumber(0)
                    Else
                        ntbPPaymentDtlValue.Text = FormatNumber(CDbl(txtPInvoiceTotal.Text) - CDbl(ntbPPaymentAdvanceAllocation.Text))
                    End If
                End If
            End If
            ntbPPaymentAdvanceAllocation.Text = FormatNumber(ntbPPaymentAdvanceAllocation.Text)
        End If
    End Sub

    Private Sub frmPPayment_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If CDbl(txtPPaymentAdvanceAmount.Text) > CDbl(txtPPaymentTotalAdvance.Text) Then
            MsgBox("Advance Payment to Allocate does not equal Total Advance Payment Allocated", vbExclamation + vbOKOnly, Me.Text)
            e.Cancel = True
        End If
    End Sub

    Private Sub btnAddD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD1.Click
        clear_objD()
    End Sub

    Private Sub btnAddD2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD2.Click
        clear_objD()
    End Sub

    Private Sub ntbPPaymentAdvanceValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPPaymentAdvanceValue.LostFocus
        If m_PPaymentDId2 > 0 Then
            If ntbPPaymentAdvanceValue.Text = "" Then ntbPPaymentAdvanceValue.Text = "0"
            If CDbl(txtPPaymentAdvanceTotal.Text) - CDbl(txtPPaymentPreviousAdvance.Text) - CDbl(ntbPPaymentAdvanceValue.Text) < 0 Then
                MsgBox("Advance value that you enter just now are higher than suppose to be. Please enter it with the same total or less.", vbInformation, Me.Text)
                ntbPPaymentAdvanceValue.Text = FormatNumber(m_PPaymentAdvanceValueBefore)
            Else
                ntbPPaymentAdvanceValue.Text = FormatNumber(ntbPPaymentAdvanceValue.Text)
            End If
        End If
    End Sub

    Private Sub chbIsPaymentBaseCurr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbIsPaymentBaseCurr.CheckedChanged
        txtBankCode.Text = ""
        If chbIsPaymentBaseCurr.Checked = True Then
            txtCurrCode.Text = m_CurrBaseCode
            ntbPPaymentCurrRate.Text = FormatNumber(1)
            m_CurrId = m_CurrBaseId
            ntbPPaymentCurrRate.ReadOnly = True
            ntbPPaymentDtlCurrRate.ReadOnly = False
            ntbPPaymentAdvanceAllocation.ReadOnly = True
        Else
            txtCurrCode.Text = m_CurrSuppCode
            ntbPPaymentCurrRate.Text = 1
            m_CurrId = m_CurrSuppId
            ntbPPaymentCurrRate.Text = m_CurrRate
            ntbPPaymentCurrRate.ReadOnly = False
            ntbPPaymentDtlCurrRate.ReadOnly = True
            ntbPPaymentAdvanceAllocation.ReadOnly = False
        End If
    End Sub

    Private Sub ntbPPaymentDtlCurrRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPPaymentDtlCurrRate.LostFocus
        If m_PPaymentDId1 > 0 Then
            ntbPPaymentDtlCurrRate.Text = FormatNumber(IIf(ntbPPaymentDtlCurrRate.Text = "", IIf(m_CurrId = m_PInvoiceCurrId, 1, txtPInvoiceCurrRate.Text), ntbPPaymentDtlCurrRate.Text))
            ntbPPaymentDtlValue.Text = IIf(m_CurrId <> m_PInvoiceCurrId, FormatNumber(CDbl(txtPInvoiceTotal.Text) * CDbl(ntbPPaymentDtlCurrRate.Text)), ntbPPaymentDtlValue.Text)
            txtPPaymentConversionValue.Text = IIf(m_CurrId <> m_PInvoiceCurrId, FormatNumber(CDbl(ntbPPaymentDtlValue.Text) / CDbl(ntbPPaymentDtlCurrRate.Text)), txtPPaymentConversionValue.Text)
        End If
    End Sub

    Private Sub btnBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBank.Click
        If txtCurrCode.Text <> "" Then
            Dim NewFormDialog As New fdlBank
            NewFormDialog.FrmCallerId = Me.Name
            NewFormDialog.ShowDialog()
        Else
            MsgBox("Please insert supplier code first !.", vbCritical + vbOKOnly, Me.Text)
            txtSCode.Focus()
        End If
    End Sub

    Private Sub txtPInvoiceTotal_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPInvoiceTotal.GotFocus
        If m_PPaymentDId1 > 0 Then
            txtPInvoiceTotal.Text = m_PInvoiceTotal
        End If
    End Sub

    Private Sub txtPInvoiceTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPInvoiceTotal.TextChanged

    End Sub

    Private Sub ntbPPaymentDtlValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbPPaymentDtlValue.TextChanged

    End Sub

    Private Sub ntbPPaymentCurrRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbPPaymentCurrRate.TextChanged

    End Sub

    Private Sub dtpPPaymentDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPPaymentDate.ValueChanged
        Dim isCheckIn As Boolean
        For i = 0 To m_PeriodArr.GetUpperBound(0)
            If dtpPPaymentDate.Value >= m_PeriodArr(i, 2) AndAlso dtpPPaymentDate.Value <= m_PeriodArr(i, 3) Then
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
        If Application.OpenForms().OfType(Of frmPPaymentList).Any Then
            Call frmPPaymentList.frmPPaymentListShow(Nothing, EventArgs.Empty)
        End If
    End Sub
End Class
