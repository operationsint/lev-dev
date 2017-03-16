Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmPReturn
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_PInvoiceId As Integer
    Dim m_SId As Integer
    'Dim m_POType As String
    'Dim m_PaymentMethod As String
    Dim m_PInvStatus As String
    Dim m_PInvStatusArr(2, 1) As String
    Dim m_PInvoiceDId As Integer
    Dim m_PODtlType As String
    Dim m_SKUId As Integer
    Dim m_LocationId As Integer
    Dim m_LocationIdBefore As Integer
    Dim m_PInvoiceTaxPercent As Single
    Dim m_CurrId As Integer
    Dim m_CurrBaseId As Integer
    Dim m_PchCodeId As Integer
    Dim m_POID As Integer
    Dim m_SKUQtyBalance As Double
    Dim m_LocationQty As Double
    Dim m_PInvoiceQtyBefore As Double
    Dim m_PInvoicePriceBefore As Double
    Dim m_PeriodId As Integer
    Dim m_PeriodArr(0, 0) As String
    Dim m_PeriodArrSelected As Integer
    Dim isGetNum As Boolean
    Dim isAllowDelete As Boolean
    Dim isAllowStockMinus As Boolean = GetSysInit("sku_qty_minus")
    Dim isPosted As Boolean
    Private docPO As ReportDocument
    Dim Dec As Integer = GetSysInit("decimal_digit")

    Private Sub frmPInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ToolTip1.SetToolTip(btnSupplier, "Search Supplier")
        ToolTip1.SetToolTip(btnSKU, "Search Stock")
        ToolTip1.SetToolTip(btnSaveD, "Save Line")
        ToolTip1.SetToolTip(btnDeleteD, "Delete Line")
        ToolTip1.SetToolTip(btnAddD, "Add Line")

        m_PInvoiceTaxPercent = GetSysInit("tax_percent") * 100

        isAllowDelete = canDelete(Me.Name + "List")

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
            'm_CurrBaseCode = myReader.GetString(1)
        End While

        myReader.Close()
        cn.Close()

        Dim i As Integer

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

        'Add item cmbPOStatus
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "pinvoice_status"

        cn.Open()
        myReader = cmd.ExecuteReader
        i = 0

        While myReader.Read
            m_PInvStatusArr(i, 0) = myReader.GetString(0)
            m_PInvStatusArr(i, 1) = myReader.GetString(1)
            i += 1
        End While

        myReader.Close()
        cn.Close()

        ''Add item cmbPaymentType
        'cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        'cmd.CommandType = CommandType.StoredProcedure

        'prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        'prm1.Value = "payment_type"

        'cn.Open()
        'myReader = cmd.ExecuteReader

        'cmbPaymentMethod.Items.Clear()
        'While myReader.Read
        '    cmbPaymentMethod.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        'End While
        'cmbPaymentMethod.SelectedIndex = 0

        'myReader.Close()
        'cn.Close()

        'Add item cmbPODtlType
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "po_dtl_type"

        cn.Open()
        myReader = cmd.ExecuteReader

        cmbPODtlType.Items.Clear()
        While myReader.Read
            cmbPODtlType.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While
        cmbPODtlType.SelectedIndex = 0

        myReader.Close()
        cn.Close()

        If m_PInvoiceId = 0 Then
            btnAdd_Click(sender, e)
        Else
            m_PInvoiceDId = 0
            view_record()
            clear_lvw()
            'btnEdit_Click(sender, e)
            clear_objD()
            lock_obj(True)
            lock_objD(True)
            cmbPODtlType.Enabled = False
        End If
    End Sub

    Private Sub btnSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplier.Click
        Dim NewFormDialog As New fdlSupplier
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Public Property PInvoiceId() As Integer
        Get
            Return m_PInvoiceId
        End Get
        Set(ByVal Value As Integer)
            m_PInvoiceId = Value
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

    Public Property SName() As String
        Get
            Return txtSName.Text
        End Get
        Set(ByVal Value As String)
            txtSName.Text = Value
        End Set
    End Property

    Public Property PchCodeId() As Integer
        Get
            Return m_PchCodeId
        End Get
        Set(ByVal Value As Integer)
            m_PchCodeId = Value
        End Set
    End Property

    Public Property PchCode() As String
        Get
            Return txtPchCode.Text
        End Get
        Set(ByVal Value As String)
            txtPchCode.Text = Value
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
            Return ntbPInvCurrRate.Text
        End Get
        Set(ByVal Value As String)
            ntbPInvCurrRate.Text = Value
        End Set
    End Property

    Public Property PODtlType() As String
        Get
            Return m_PODtlType
        End Get
        Set(ByVal Value As String)
            m_PODtlType = Value
            Dim mList As clsMyListStr
            Dim i As Integer
            For i = 1 To cmbPODtlType.Items.Count + 1
                mList = cmbPODtlType.Items(i - 1)
                If m_PODtlType = mList.ItemData Then
                    cmbPODtlType.SelectedIndex = i - 1
                    Exit For
                End If
            Next
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
            Return txtPInvoiceDtlDesc.Text
        End Get
        Set(ByVal Value As String)
            txtPInvoiceDtlDesc.Text = Value
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

    Public Property SKUQtyBalance() As Double
        Get
            Return m_SKUQtyBalance
        End Get
        Set(ByVal Value As Double)
            m_SKUQtyBalance = Value
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

    Public Property POPrice() As String
        Get
            Return ntbPInvoicePrice.Text
        End Get
        Set(ByVal Value As String)
            ntbPInvoicePrice.Text = Value
        End Set
    End Property

    Public Property POGross() As String
        Get
            Return txtPInvoiceGrossAmt.Text
        End Get
        Set(ByVal Value As String)
            txtPInvoiceGrossAmt.Text = Value
        End Set
    End Property

    Public Property POTaxPercent() As String
        Get
            Return ntbPInvoiceTaxPercent.Text
        End Get
        Set(ByVal Value As String)
            ntbPInvoiceTaxPercent.Text = Value
        End Set
    End Property

    Public Property POTax() As String
        Get
            Return txtPInvoiceTax.Text
        End Get
        Set(ByVal Value As String)
            txtPInvoiceTax.Text = Value
        End Set
    End Property

    Public Property PONet() As String
        Get
            Return txtPInvoiceNetAmt.Text
        End Get
        Set(ByVal Value As String)
            txtPInvoiceNetAmt.Text = Value
        End Set
    End Property

    Private Sub btnSKU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSKU.Click
        'Select Case cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData
        '    Case "S"
        Dim NewFormDialog As New fdlSKUPO
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
        '    Case "E"
        '        Dim NewFormDialog As New fdlExpense
        '        NewFormDialog.FrmCallerId = Me.Name
        '        NewFormDialog.ShowDialog()
        'End Select
    End Sub

    Sub clear_obj()
        m_PInvoiceId = 0
        m_SId = 0
        m_PchCodeId = 0
        m_CurrId = 0
        txtPInvoiceNo.Text = ""
        ntbPInvoiceTerms.Text = "0"
        dtpPInvoiceDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtSCode.Text = ""
        txtSName.Text = ""
        dtpPInvoiceDueDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtPchCode.Text = ""
        txtCurrCode.Text = ""
        ntbPInvCurrRate.Text = FormatNumber("1")
        txtRefNo.Text = ""
        txtPInvoiceRemarks.Text = ""
        'ntbPaymentTerms.Text = 0
        'cmbPaymentMethod.SelectedIndex = 0
        txtPInvoiceSubtotal.Text = FormatNumber("0")
        txtPInvoiceTax.Text = FormatNumber("0")
        txtPInvoiceTotal.Text = FormatNumber("0")
        txtLocalPInvoiceSubTotal.Text = FormatNumber("0")
        txtLocalPInvoiceTax.Text = FormatNumber("0")
        txtLocalPInvoiceTotal.Text = FormatNumber("0")
        m_PInvStatus = m_PInvStatusArr(0, 0)
        txtPOStatus.Text = m_PInvStatusArr(0, 1)
        isGetNum = True
        isPosted = False

        'Add item cmbCurrId
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
        '    ntbPInvCurrRate.Text = FormatNumber(myReader.Item(4))
        'End While
        'myReader.Close()
        'cn.Close()
    End Sub

    Sub clear_objD()
        m_PInvoiceDId = 0
        m_LocationId = 0
        m_SKUId = 0
        m_SKUQtyBalance = 0
        m_LocationQty = 0
        m_PInvoiceQtyBefore = 0
        m_PInvoicePriceBefore = 0
        m_LocationIdBefore = 0
        cmbPODtlType.SelectedIndex = 0
        txtSKUCode.Text = ""
        txtPInvoiceDtlDesc.Text = ""
        ntbPInvoiceQty.Text = FormatNumber(-1)
        txtSKUUoM.Text = ""
        ntbPInvoicePrice.Text = FormatNumber(0)
        ntbPInvoiceTaxPercent.Text = FormatNumber(m_PInvoiceTaxPercent, 0)
        txtPInvoiceTaxAmt.Text = FormatNumber(0)
        txtPInvoiceGrossAmt.Text = FormatNumber(0)
        txtPInvoiceNetAmt.Text = FormatNumber(0)
        txtLocationCode.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        dtpPInvoiceDate.Enabled = Not isLock
        dtpPInvoiceDueDate.Enabled = Not isLock
        txtRefNo.ReadOnly = isLock
        ntbPInvoiceTerms.ReadOnly = isLock
        txtPInvoiceRemarks.ReadOnly = isLock
        'cmbPaymentMethod.Enabled = Not isLock
        btnPchCode.Enabled = Not isLock
        'txtPOSubtotal.ReadOnly = isLock
        'txtPOTax.ReadOnly = isLock
        'txtPOTotal.ReadOnly = isLock

        If m_PInvStatus = "UP" Then btnEdit.Enabled = isLock Else btnEdit.Enabled = False
        If isPosted = True Then btnEdit.Enabled = False
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnPrint.Enabled = isLock

        If m_PInvoiceId = 0 Then
            txtPInvoiceNo.ReadOnly = False
            ntbPInvCurrRate.ReadOnly = False
            btnSupplier.Enabled = True
            btnDelete.Enabled = isLock
        Else
            txtPInvoiceNo.ReadOnly = True
            ntbPInvCurrRate.ReadOnly = True
            btnSupplier.Enabled = False
            'If p_UserLevel = 1 Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        'If m_PInvoiceDId = 0 Then cmbPODtlType.Enabled = True Else cmbPODtlType.Enabled = False
        txtPInvoiceDtlDesc.ReadOnly = isLock
        ntbPInvoiceQty.ReadOnly = isLock
        ntbPInvoicePrice.ReadOnly = isLock
        ntbPInvoiceTaxPercent.ReadOnly = isLock

        btnSKU.Enabled = Not isLock
        btnLocation.Enabled = Not isLock
        btnSaveD.Enabled = Not isLock
        btnDeleteD.Enabled = Not isLock
        btnAddD.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("po_dtl_type", 0)
            .Columns.Add("Line Type", 90)
            .Columns.Add("sku_id", 0)
            .Columns.Add("Code", 60)
            .Columns.Add("Line Description", 250)
            .Columns.Add("locationId", 0)
            .Columns.Add("Location", 90)
            .Columns.Add("Qty", 60, HorizontalAlignment.Right)
            .Columns.Add("stock_balance", 0)
            .Columns.Add("UoM", 60)
            .Columns.Add("Unit Price", 90, HorizontalAlignment.Right)
            .Columns.Add("Gross Amount", 120, HorizontalAlignment.Right)
            .Columns.Add("Tax %", 60, HorizontalAlignment.Right)
            .Columns.Add("Tax Amount", 90, HorizontalAlignment.Right)
            .Columns.Add("Net Amount", 120, HorizontalAlignment.Right)

            '.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize)
            '.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.HeaderSize)
            '.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.ColumnContent)
        End With

        If m_PInvoiceId <> 0 Then
            cmd = New SqlCommand("usp_tr_pinvoice_dtl_RET_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@pinvoice_id", SqlDbType.Int)
            prm2.Value = m_PInvoiceId

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(1))) 'po_dtl_type
                lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                lvItem.SubItems.Add(myReader.GetString(2)) 'line_type
                lvItem.SubItems.Add(myReader.GetInt32(3)) 'sku_id
                lvItem.SubItems.Add(myReader.GetString(4)) 'sku_code
                lvItem.SubItems.Add(myReader.GetString(5)) 'sku_name
                lvItem.SubItems.Add(myReader.GetInt32(6)) 'location_id
                lvItem.SubItems.Add(myReader.GetString(7)) 'location_code
                lvItem.SubItems.Add(myReader.GetValue(8)) 'pinvoice_qty
                lvItem.SubItems.Add(myReader.GetValue(9)) 'stock_balance
                If myReader.Item(10) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(10)) 'sku_uom
                End If
                lvItem.SubItems.Add(FormatNumber(myReader.Item(11), Dec))
                For i = 12 To 15
                    If i = 13 Then
                        lvItem.SubItems.Add(FormatNumber(myReader.Item(i), 0))
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

    Sub view_record()
        cmd = New SqlCommand("usp_tr_pinvoice_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@pinvoice_id", SqlDbType.Int)
        prm1.Value = m_PInvoiceId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtPInvoiceNo.Text = myReader.GetString(1)
            m_SId = myReader.GetInt32(3)
            txtSCode.Text = myReader.GetString(4)
            txtSName.Text = myReader.GetString(5)
            m_PchCodeId = myReader.GetInt32(8)
            txtPchCode.Text = myReader.GetString(9)
            ntbPInvoiceTerms.Text = myReader.GetInt32(10)
            dtpPInvoiceDate.Value = myReader.GetDateTime(2)
            dtpPInvoiceDueDate.Value = myReader.GetDateTime(11)
            If Not myReader.IsDBNull(myReader.GetOrdinal("ref_no")) Then
                txtRefNo.Text = myReader.GetString(myReader.GetOrdinal("ref_no"))
            Else
                txtRefNo.Text = ""
            End If
            'm_PaymentMethod = myReader.GetString(13)
            If Not myReader.IsDBNull(myReader.GetOrdinal("pinvoice_remarks")) Then
                txtPInvoiceRemarks.Text = myReader.GetString(myReader.GetOrdinal("pinvoice_remarks"))
            Else
                txtPInvoiceRemarks.Text = ""
            End If
            m_CurrId = myReader.GetInt32(14)
            txtCurrCode.Text = myReader.GetString(15)
            ntbPInvCurrRate.Text = FormatNumber(myReader.GetValue(16))
            txtPInvoiceSubtotal.Text = FormatNumber(myReader.GetValue(17))
            txtPInvoiceTax.Text = FormatNumber(myReader.GetValue(18))
            txtPInvoiceTotal.Text = FormatNumber(myReader.GetValue(19))
            txtLocalPInvoiceSubTotal.Text = FormatNumber(myReader.GetValue(23))
            txtLocalPInvoiceTax.Text = FormatNumber(myReader.GetValue(24))
            txtLocalPInvoiceTotal.Text = FormatNumber(myReader.GetValue(25))
            m_PInvStatus = myReader.GetString(26)
            isPosted = myReader.GetBoolean(28)
            m_PeriodId = myReader.GetInt32(29)
        End While

        myReader.Close()
        cn.Close()

        If isPosted = True Then txtPeriodId.Text = GetPeriodName(m_PeriodId)

        For i = 0 To m_PInvStatusArr.GetUpperBound(0)
            If m_PInvStatus = m_PInvStatusArr(i, 0) Then
                txtPOStatus.Text = m_PInvStatusArr(i, 1)
                Exit For
            End If
        Next

        'Dim mList As clsMyListStr
        'Dim i As Integer

        'For i = 1 To cmbPaymentMethod.Items.Count
        '    mList = cmbPaymentMethod.Items(i - 1)
        '    If m_PaymentMethod = mList.ItemData Then
        '        cmbPaymentMethod.SelectedIndex = i - 1
        '        Exit For
        '    End If
        'Next
    End Sub

    Sub refresh_total()
        cmd = New SqlCommand("usp_tr_pinvoice_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@pinvoice_id", SqlDbType.Int)
        prm1.Value = m_PInvoiceId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtPInvoiceSubtotal.Text = FormatNumber(myReader.GetValue(17))
            txtPInvoiceTax.Text = FormatNumber(myReader.GetValue(18))
            txtPInvoiceTotal.Text = FormatNumber(myReader.GetValue(19))
            txtLocalPInvoiceSubTotal.Text = FormatNumber(myReader.GetValue(23))
            txtLocalPInvoiceTax.Text = FormatNumber(myReader.GetValue(24))
            txtLocalPInvoiceTotal.Text = FormatNumber(myReader.GetValue(25))
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Sub refresh_totalD()
        txtPInvoiceGrossAmt.Text = FormatNumber((ntbPInvoiceQty.Text) * CDbl(ntbPInvoicePrice.Text))
        txtPInvoiceTaxAmt.Text = FormatNumber((ntbPInvoiceQty.Text) * CDbl(ntbPInvoicePrice.Text) * CDbl(ntbPInvoiceTaxPercent.Text) / 100)
        txtPInvoiceNetAmt.Text = FormatNumber(CDbl(txtPInvoiceGrossAmt.Text) + CDbl(txtPInvoiceTaxAmt.Text))
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_PInvoiceId = 0
        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_PInvoiceId = 0 Then
            Me.Close()
        Else
            lock_obj(True)
            lock_objD(True)
            clear_objD()
            m_PInvoiceDId = 0
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If m_SId = 0 Or m_PchCodeId = 0 Then
                MsgBox("Purchase Code & Supplier information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtSCode.Focus()
                Exit Sub
            End If

            If CDbl(txtPInvoiceTotal.Text) = 0 Then
                MsgBox("Warning,Purchase Return total is 0 !", vbInformation, Me.Text)
            End If

            If m_PInvoiceId = 0 Then
                If txtPInvoiceNo.Text.Trim = "" Then
                    txtPInvoiceNo.Text = GetSysNumber("pret", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If
            End If

            AppLock.GetLock()

            cmd = New SqlCommand(IIf(m_PInvoiceId = 0, "usp_tr_pinvoice_INS", "usp_tr_pinvoice_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@pinvoice_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtPInvoiceNo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@pinvoice_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpPInvoiceDate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
            prm3.Value = m_SId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)
            prm4.Value = m_POID
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@pch_code_id", SqlDbType.Int)
            prm5.Value = m_PchCodeId
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@pinvoice_period_id", SqlDbType.Int)
            prm6.Value = m_PeriodArr(m_PeriodArrSelected, 0)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@pinvoice_terms", SqlDbType.Int)
            prm7.Value = ntbPInvoiceTerms.Text
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@pinvoice_duedate", SqlDbType.SmallDateTime)
            prm8.Value = dtpPInvoiceDueDate.Value.Date
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
            prm9.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@pinvoice_remarks", SqlDbType.NVarChar, 255)
            prm10.Value = IIf(txtPInvoiceRemarks.Text = "", DBNull.Value, txtPInvoiceRemarks.Text)
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm11.Value = m_CurrId
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@pinvoice_curr_rate", SqlDbType.Money)
            prm12.Value = FormatNumber(ntbPInvCurrRate.Text)
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@is_return", SqlDbType.Bit)
            prm13.Value = 1
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm14.Value = My.Settings.UserName
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@pinvoice_id", SqlDbType.Int)

            If m_PInvoiceId = 0 Then
                prm16.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_PInvoiceId = prm16.Value
                'MessageBox.Show(m_PInvoiceId)
                cn.Close()
                If isGetNum = True Then UpdSysNumber("pret")
            Else
                prm16.Value = m_PInvoiceId
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                'clear_lvw()
            End If

            lock_obj(True)
            lock_objD(True)
            cmbPODtlType.Enabled = False

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

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        clear_objD()
        lock_obj(False)
        lock_objD(False)
        'If m_PInvStatus = "FP" Then
        '    btnSave.Enabled = False
        '    btnDelete.Enabled = False
        '    lock_objD(True)
        'End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then

            '20160625 applock
            AppLock.GetLock()

            cmd = New SqlCommand("usp_tr_pinvoice_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@pinvoice_id", SqlDbType.Int)
            prm1.Value = m_PInvoiceId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
            prm2.Value = m_SId
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)
            prm3.Value = m_POID
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@pinvoice_curr_rate", SqlDbType.Money)
            prm4.Value = ntbPInvCurrRate.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@pinvoice_total", SqlDbType.Money)
            prm5.Value = txtPInvoiceTotal.Text
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@is_return", SqlDbType.Bit)
            prm6.Value = 1
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm7.Value = My.Settings.UserName

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            AppLock.ReleaseLock()

            btnAdd_Click(sender, e)
        End If
        autoRefresh()
    End Sub

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        Try
            If m_PInvoiceId = 0 Then
                If m_SId = 0 Or m_PchCodeId = 0 Then
                    MsgBox("Purchase Code & Supplier information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                    txtSCode.Focus()
                    Exit Sub
                End If

                If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
                    MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                    Exit Sub
                End If

                SavePInvoiceHeader()
            End If

            If txtPInvoiceDtlDesc.Text = "" Then
                MsgBox("Line Description are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtPInvoiceDtlDesc.Focus()
                Exit Sub
            End If

            If cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "S" And (m_SKUId = 0 Or m_LocationId = 0) Then
                MsgBox("Stock and Location are primary fields that should be entered. Please select before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtPInvoiceDtlDesc.Focus()
                Exit Sub
            End If

            'Check stock location
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
            If isAllowStockMinus = False And (CDbl(ntbPInvoiceQty.Text) * -1 > m_LocationQty) Then
                MsgBox("Purchase Return Qty > Stock Location Balance", vbExclamation + vbOKOnly, Me.Text)
                ntbPInvoiceQty.Text = FormatNumber(m_LocationQty * -1)
                Exit Sub
            End If

            AppLock.GetLock()

            cmd = New SqlCommand(IIf(m_PInvoiceDId = 0, "usp_tr_pinvoice_dtl_RET_INS", "usp_tr_pinvoice_dtl_RET_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@pinvoice_id", SqlDbType.Int)
            prm1.Value = m_PInvoiceId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@pinvoice_dtl_type", SqlDbType.NVarChar, 50)
            prm2.Value = cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
            prm4.Value = IIf(cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "S", m_SKUId, 0)
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@pinvoice_dtl_desc", SqlDbType.NVarChar, 255)
            prm5.Value = IIf(txtPInvoiceDtlDesc.Text = "", DBNull.Value, txtPInvoiceDtlDesc.Text)
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@pinvoice_qty", SqlDbType.Decimal)
            prm6.Value = IIf(ntbPInvoiceQty.Text = "", 0, CDbl(ntbPInvoiceQty.Text))
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@pinvoice_price", SqlDbType.Decimal)
            prm7.Value = FormatNumber(ntbPInvoicePrice.Text, Dec)
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@tax_percent", SqlDbType.Decimal)
            prm8.Value = ntbPInvoiceTaxPercent.Text / 100
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int)
            prm9.Value = m_LocationId
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@expense_id", SqlDbType.Int)
            prm10.Value = IIf(cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "E", m_SKUId, 0)
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
            prm11.Value = SId
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@pinvoice_curr_rate", SqlDbType.Money)
            prm13.Value = ntbPInvCurrRate.Text

            If m_PInvoiceDId <> 0 Then
                Dim prm24 As SqlParameter = cmd.Parameters.Add("@pinvoice_dtl_id", SqlDbType.Int)
                prm24.Value = m_PInvoiceDId
                Dim prm25 As SqlParameter = cmd.Parameters.Add("@pinvoice_qty_before", SqlDbType.Decimal)
                prm25.Value = m_PInvoiceQtyBefore
                Dim prm26 As SqlParameter = cmd.Parameters.Add("@pinvoice_price_before", SqlDbType.Decimal)
                prm26.Value = m_PInvoicePriceBefore
                Dim prm27 As SqlParameter = cmd.Parameters.Add("@location_id_before", SqlDbType.Int)
                prm27.Value = m_LocationIdBefore
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
        Finally
            AppLock.ReleaseLock()
        End Try
    End Sub

    Sub SavePInvoiceHeader()
        Try
            If txtPInvoiceNo.Text.Trim = "" Then
                txtPInvoiceNo.Text = GetSysNumber("pret", Now.Date)
                isGetNum = True
            Else
                isGetNum = False
            End If

            AppLock.GetLock()

            cmd = New SqlCommand("usp_tr_pinvoice_INS", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@pinvoice_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtPInvoiceNo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@pinvoice_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpPInvoiceDate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
            prm3.Value = m_SId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)
            prm4.Value = m_POID
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@pch_code_id", SqlDbType.Int)
            prm5.Value = m_PchCodeId
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@pinvoice_period_id", SqlDbType.Int)
            prm6.Value = m_PeriodArr(m_PeriodArrSelected, 0)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@pinvoice_terms", SqlDbType.Int)
            prm7.Value = ntbPInvoiceTerms.Text
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@pinvoice_duedate", SqlDbType.SmallDateTime)
            prm8.Value = dtpPInvoiceDueDate.Value.Date
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
            prm9.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@pinvoice_remarks", SqlDbType.NVarChar, 255)
            prm10.Value = IIf(txtPInvoiceRemarks.Text = "", DBNull.Value, txtPInvoiceRemarks.Text)
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm11.Value = m_CurrId
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@pinvoice_curr_rate", SqlDbType.Money)
            prm12.Value = FormatNumber(ntbPInvCurrRate.Text)
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@is_return", SqlDbType.Bit)
            prm13.Value = 1
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm14.Value = My.Settings.UserName
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@pinvoice_id", SqlDbType.Int)
            prm16.Direction = ParameterDirection.Output

            cn.Open()
            cmd.ExecuteReader()
            m_PInvoiceId = prm16.Value
            cn.Close()
            If isGetNum = True Then UpdSysNumber("pret")
            txtPInvoiceNo.ReadOnly = True
            ntbPInvCurrRate.ReadOnly = True
            btnSupplier.Enabled = False

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

    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD.Click
        If m_PInvoiceDId = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then

            AppLock.GetLock()

            cmd = New SqlCommand("usp_tr_pinvoice_dtl_RET_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@pinvoice_dtl_id", SqlDbType.Int)
            prm1.Value = m_PInvoiceDId
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@pinvoice_dtl_net", SqlDbType.Money)
            prm3.Value = txtPInvoiceNetAmt.Text
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@pinvoice_curr_rate", SqlDbType.Money)
            prm4.Value = ntbPInvCurrRate.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
            prm5.Value = m_SId

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            AppLock.ReleaseLock()

            clear_lvw()
            clear_objD()
            refresh_total()

            btnSKU.Enabled = True
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        'cmbPODtlType.Enabled = False
        With ListView1.SelectedItems.Item(0)
            m_PInvoiceDId = LeftSplitUF(.Tag)
            m_PODtlType = .SubItems.Item(0).Text
            Dim mList As clsMyListStr
            Dim i As Integer
            For i = 1 To cmbPODtlType.Items.Count + 1
                mList = cmbPODtlType.Items(i - 1)
                If m_PODtlType = mList.ItemData Then
                    cmbPODtlType.SelectedIndex = i - 1
                    Exit For
                End If
            Next
            m_SKUId = .SubItems.Item(2).Text
            txtSKUCode.Text = .SubItems.Item(3).Text
            txtPInvoiceDtlDesc.Text = .SubItems.Item(4).Text
            m_LocationId = IIf(.SubItems.Item(5).Text = "", 0, .SubItems.Item(5).Text)
            m_LocationIdBefore = IIf(.SubItems.Item(5).Text = "", 0, .SubItems.Item(5).Text)
            txtLocationCode.Text = IIf(.SubItems.Item(6).Text = "", "", .SubItems.Item(6).Text)
            ntbPInvoiceQty.Text = .SubItems.Item(7).Text
            m_PInvoiceQtyBefore = .SubItems.Item(7).Text
            'm_SKUQtyBalance = .SubItems.Item(8).Text
            txtSKUUoM.Text = .SubItems.Item(9).Text
            ntbPInvoicePrice.Text = FormatNumber(.SubItems.Item(10).Text, Dec)
            m_PInvoicePriceBefore = .SubItems.Item(10).Text
            txtPInvoiceGrossAmt.Text = FormatNumber(.SubItems.Item(11).Text)
            ntbPInvoiceTaxPercent.Text = .SubItems.Item(12).Text
            txtPInvoiceTaxAmt.Text = FormatNumber(.SubItems.Item(13).Text)
            txtPInvoiceNetAmt.Text = FormatNumber(.SubItems.Item(14).Text)

            If btnSaveD.Enabled = True Then
                btnSKU.Enabled = False
            End If
        End With
    End Sub

    Private Sub cmbPODtlType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPODtlType.SelectedIndexChanged
        If Not btnAddD.Enabled = True Then Exit Sub
        Select Case cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData
            Case "S", "E"
                If Not btnCancel.Enabled = False Then
                    'btnSKU.Enabled = False
                    'txtPInvoiceDtlDesc.ReadOnly = False
                    ntbPInvoiceQty.ReadOnly = IIf(cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "S", False, True)
                    ntbPInvoicePrice.ReadOnly = IIf(cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "S", False, True)
                    ntbPInvoiceTaxPercent.ReadOnly = IIf(cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "S", False, True)
                End If

            Case "T"
                'txtSKUCode.ReadOnly = True
                'btnSKU.Enabled = False
                ntbPInvoiceQty.ReadOnly = True
                ntbPInvoicePrice.ReadOnly = True
                ntbPInvoiceTaxPercent.ReadOnly = True
        End Select
    End Sub

    Private Sub ntbPInvoicePrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPInvoicePrice.LostFocus
        If ntbPInvoicePrice.Text = "" Then ntbPInvoicePrice.Text = FormatNumber(0)
        refresh_totalD()
        ntbPInvoicePrice.Text = FormatNumber(ntbPInvoicePrice.Text, Dec)
    End Sub

    Private Sub ntbPInvoiceTaxPercent_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPInvoiceTaxPercent.LostFocus
        'ntbPOTax.Text = FormatPercent(CSng(ntbPOTax.Text.Replace("%", "")) / 100, 0)
        If ntbPInvoiceTaxPercent.Text = "" Then ntbPInvoiceTaxPercent.Text = FormatNumber(m_PInvoiceTaxPercent)
        refresh_totalD()
        ntbPInvoiceTaxPercent.Text = FormatNumber(ntbPInvoiceTaxPercent.Text, 0)
    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        clear_objD()

        '20160625 enable sku button
        btnSKU.Enabled = True

        cmbPODtlType.Enabled = True
    End Sub

    Private Sub ntbPInvoiceQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPInvoiceQty.LostFocus
        If ntbPInvoiceQty.Text = "" Then ntbPInvoiceQty.Text = FormatNumber(-1)
        If ntbPInvoiceQty.DecimalValue = 0 Then ntbPInvoiceQty.Text = FormatNumber(-1)
        If CDbl(ntbPInvoiceQty.Text) > 0 Then ntbPInvoiceQty.Text = CDbl(ntbPInvoiceQty.Text * -1)
        'If m_SKUQtyBalance > CDbl(ntbPInvoiceQty.Text) Then
        '    MsgBox("Stock Balance > Retur Qty", vbExclamation + vbOK, Me.Text)
        '    ntbPInvoiceQty.Text = m_SKUQtyBalance
        'End If
        refresh_totalD()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Pch_Return_Form '" & txtPInvoiceNo.Text & "'"
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "PReturn_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Pch_Return_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Purchase Return"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("PReturn_"))
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

    Private Sub ntbPInvCurrRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPInvCurrRate.LostFocus
        If ntbPInvCurrRate.Text.Length = 0 Then ntbPInvCurrRate.Undo()
        If m_PInvoiceId = 0 Then
            If m_CurrId = m_CurrBaseId Then
                ntbPInvCurrRate.Text = "1"
            Else
                If ntbPInvCurrRate.DecimalValue = 0 Then ntbPInvCurrRate.Undo()
            End If
        End If
        ntbPInvCurrRate.Text = FormatNumber(ntbPInvCurrRate.Text)
    End Sub

    Private Sub btnPchCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPchCode.Click
        Dim NewFormDialog As New fdlPchCode
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub ntbPInvoiceTerms_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPInvoiceTerms.LostFocus
        If ntbPInvoiceTerms.Text = "" Then ntbPInvoiceTerms.Text = "0" : dtpPInvoiceDueDate.Value = dtpPInvoiceDate.Value
        dtpPInvoiceDueDate.Value = DateAdd(DateInterval.Day, CInt(ntbPInvoiceTerms.Text), dtpPInvoiceDate.Value)
    End Sub

    Private Sub ntbPInvoiceTerms_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbPInvoiceTerms.TextChanged

    End Sub

    Private Sub dtpPInvoiceDueDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPInvoiceDueDate.ValueChanged
        If dtpPInvoiceDueDate.Value < dtpPInvoiceDate.Value Then dtpPInvoiceDate.Value = dtpPInvoiceDueDate.Value
        ntbPInvoiceTerms.Text = DateDiff(DateInterval.Day, dtpPInvoiceDate.Value, dtpPInvoiceDueDate.Value)
    End Sub

    Private Sub dtpPInvoiceDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPInvoiceDate.ValueChanged
        dtpPInvoiceDueDate.Value = DateAdd(DateInterval.Day, CInt(ntbPInvoiceTerms.Text), dtpPInvoiceDate.Value)
        Dim isCheckIn As Boolean
        For i = 0 To m_PeriodArr.GetUpperBound(0)
            If dtpPInvoiceDate.Value >= m_PeriodArr(i, 2) AndAlso dtpPInvoiceDate.Value <= m_PeriodArr(i, 3) Then
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

    Private Sub ntbPInvoiceQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbPInvoiceQty.TextChanged

    End Sub
    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmPReturnList).Any Then
            Call frmPReturnList.frmPReturnListShow(Nothing, EventArgs.Empty)
        End If
    End Sub
End Class
