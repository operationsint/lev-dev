Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmSReturn
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_SInvoiceId As Integer
    Dim m_CId As Integer
    'Dim m_POType As String
    'Dim m_PaymentMethod As String
    Dim m_SInvStatus As String
    Dim m_SInvStatusArr(2, 1) As String
    Dim m_SInvoiceDId As Integer
    Dim m_SODtlType As String
    Dim m_SKUId As Integer
    Dim m_LocationId As Integer
    Dim m_LocationIdBefore As Integer
    Dim m_SInvoiceTaxPercent As Single
    Dim m_CurrId As Integer
    Dim m_CurrBaseId As Integer
    Dim m_SlsCodeId As Integer
    Dim m_POID As Integer
    Dim m_SInvoiceQtyBefore As Double
    Dim m_SInvoicePriceBefore As Double
    Dim m_PeriodId As Integer
    Dim m_PeriodArr(0, 0) As String
    Dim m_PeriodArrSelected As Integer
    Dim isGetNum As Boolean
    Dim isPosted As Boolean
    Dim isAllowDelete As Boolean
    Private docPO As ReportDocument
    Dim Dec As Integer = GetSysInit("decimal_digit")

    Private Sub frmPInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ToolTip1.SetToolTip(btnCustomer, "Search Customer")
        ToolTip1.SetToolTip(btnSKU, "Search Stock")
        ToolTip1.SetToolTip(btnSaveD, "Save Line")
        ToolTip1.SetToolTip(btnDeleteD, "Delete Line")
        ToolTip1.SetToolTip(btnAddD, "Add Line")

        isAllowDelete = canDelete(Me.Name + "List")

        m_SInvoiceTaxPercent = GetSysInit("tax_percent") * 100

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

        'Add item cmbPOStatus
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "sinvoice_status"

        cn.Open()
        myReader = cmd.ExecuteReader

        i = 0
        While myReader.Read
            m_SInvStatusArr(i, 0) = myReader.GetString(0)
            m_SInvStatusArr(i, 1) = myReader.GetString(1)
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
        prm1.Value = "so_dtl_type"

        cn.Open()
        myReader = cmd.ExecuteReader

        cmbSODtlType.Items.Clear()
        While myReader.Read
            cmbSODtlType.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While
        cmbSODtlType.SelectedIndex = 0

        myReader.Close()
        cn.Close()

        If m_SInvoiceId = 0 Then
            btnAdd_Click(sender, e)
        Else
            m_SInvoiceDId = 0
            view_record()
            clear_lvw()
            'btnEdit_Click(sender, e)
            clear_objD()
            lock_obj(True)
            lock_objD(True)
            cmbSODtlType.Enabled = False
        End If
    End Sub

    Private Sub btnCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomer.Click
        Dim NewFormDialog As New fdlCustomer
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Public Property SInvoiceId() As Integer
        Get
            Return m_SInvoiceId
        End Get
        Set(ByVal Value As Integer)
            m_SInvoiceId = Value
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
            Return txtSName.Text
        End Get
        Set(ByVal Value As String)
            txtSName.Text = Value
        End Set
    End Property

    Public Property SlsCodeId() As Integer
        Get
            Return m_SlsCodeId
        End Get
        Set(ByVal Value As Integer)
            m_SlsCodeId = Value
        End Set
    End Property

    Public Property SlsCode() As String
        Get
            Return txtSlsCode.Text
        End Get
        Set(ByVal Value As String)
            txtSlsCode.Text = Value
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
            Return ntbSInvCurrRate.Text
        End Get
        Set(ByVal Value As String)
            ntbSInvCurrRate.Text = Value
        End Set
    End Property

    Public Property SODtlType() As String
        Get
            Return m_SODtlType
        End Get
        Set(ByVal Value As String)
            m_SODtlType = Value
            Dim mList As clsMyListStr
            Dim i As Integer
            For i = 1 To cmbSODtlType.Items.Count + 1
                mList = cmbSODtlType.Items(i - 1)
                If m_SODtlType = mList.ItemData Then
                    cmbSODtlType.SelectedIndex = i - 1
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
            Return txtSInvoiceDtlDesc.Text
        End Get
        Set(ByVal Value As String)
            txtSInvoiceDtlDesc.Text = Value
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

    Public Property ReturnCost() As String
        Get
            Return ntbReturnCost.Text
        End Get
        Set(ByVal Value As String)
            ntbReturnCost.Text = Value
        End Set
    End Property

    Public Property SInvoicePrice() As String
        Get
            Return ntbSInvoicePrice.Text
        End Get
        Set(ByVal Value As String)
            ntbSInvoicePrice.Text = Value
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
            Return ntbSInvoicePrice.Text
        End Get
        Set(ByVal Value As String)
            ntbSInvoicePrice.Text = Value
        End Set
    End Property

    Public Property POGross() As String
        Get
            Return txtSInvoiceGrossAmt.Text
        End Get
        Set(ByVal Value As String)
            txtSInvoiceGrossAmt.Text = Value
        End Set
    End Property

    Public Property POTaxPercent() As String
        Get
            Return ntbSInvoiceTaxPercent.Text
        End Get
        Set(ByVal Value As String)
            ntbSInvoiceTaxPercent.Text = Value
        End Set
    End Property

    Public Property POTax() As String
        Get
            Return txtSInvoiceTax.Text
        End Get
        Set(ByVal Value As String)
            txtSInvoiceTax.Text = Value
        End Set
    End Property

    Public Property PONet() As String
        Get
            Return txtSInvoiceNetAmt.Text
        End Get
        Set(ByVal Value As String)
            txtSInvoiceNetAmt.Text = Value
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
        m_SInvoiceId = 0
        m_CId = 0
        m_SlsCodeId = 0
        m_CurrId = 0
        txtSInvoiceNo.Text = ""
        ntbSInvoiceTerms.Text = "0"
        dtpSInvoiceDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtCCode.Text = ""
        txtSName.Text = ""
        dtpSInvoiceDueDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtSlsCode.Text = ""
        txtCurrCode.Text = ""
        ntbSInvCurrRate.Text = FormatNumber("1")
        txtRefNo.Text = ""
        txtSInvoiceRemarks.Text = ""
        'ntbPaymentTerms.Text = 0
        'cmbPaymentMethod.SelectedIndex = 0
        txtSInvoiceSubtotal.Text = FormatNumber("0")
        txtSInvoiceTax.Text = FormatNumber("0")
        txtSInvoiceTotal.Text = FormatNumber("0")
        txtLocalSInvoiceSubTotal.Text = FormatNumber("0")
        txtLocalSInvoiceTax.Text = FormatNumber("0")
        txtLocalSInvoiceTotal.Text = FormatNumber("0")
        m_SInvStatus = m_SInvStatusArr(0, 0)
        txtSInvStatus.Text = m_SInvStatusArr(0, 1)
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
        m_SInvoiceDId = 0
        m_LocationId = 0
        m_SKUId = 0
        m_SInvoiceQtyBefore = 0
        m_SInvoicePriceBefore = 0
        m_LocationIdBefore = 0
        cmbSODtlType.SelectedIndex = 0
        txtSKUCode.Text = ""
        txtSInvoiceDtlDesc.Text = ""
        ntbSInvoiceQty.Text = FormatNumber(0)
        txtSKUUoM.Text = ""
        ntbReturnCost.Text = FormatNumber(0)
        ntbSInvoicePrice.Text = FormatNumber(0)
        ntbSInvoiceTaxPercent.Text = FormatNumber(m_SInvoiceTaxPercent, 0)
        txtSInvoiceTaxAmt.Text = FormatNumber(0)
        txtSInvoiceGrossAmt.Text = FormatNumber(0)
        txtSInvoiceNetAmt.Text = FormatNumber(0)
        txtLocationCode.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        dtpSInvoiceDate.Enabled = Not isLock
        dtpSInvoiceDueDate.Enabled = Not isLock
        txtRefNo.ReadOnly = isLock
        ntbSInvoiceTerms.ReadOnly = isLock
        txtSInvoiceRemarks.ReadOnly = isLock
        'cmbPaymentMethod.Enabled = Not isLock
        btnSlsCode.Enabled = Not isLock
        'txtPOSubtotal.ReadOnly = isLock
        'txtPOTax.ReadOnly = isLock
        'txtPOTotal.ReadOnly = isLock

        If m_SInvStatus = "UP" Then btnEdit.Enabled = isLock Else btnEdit.Enabled = False
        If isPosted = True Then btnEdit.Enabled = False
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnPrint.Enabled = isLock

        If m_SInvoiceId = 0 Then
            txtSInvoiceNo.ReadOnly = False
            ntbSInvCurrRate.ReadOnly = False
            btnCustomer.Enabled = True
            btnDelete.Enabled = isLock
        Else
            txtSInvoiceNo.ReadOnly = True
            ntbSInvCurrRate.ReadOnly = True
            btnCustomer.Enabled = False
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        'If m_SInvoiceDId = 0 Then cmbPODtlType.Enabled = True Else cmbPODtlType.Enabled = False
        txtSInvoiceDtlDesc.ReadOnly = isLock
        ntbSInvoiceQty.ReadOnly = isLock
        ntbSInvoicePrice.ReadOnly = isLock
        ntbSInvoiceTaxPercent.ReadOnly = isLock
        ntbReturnCost.ReadOnly = isLock

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
            .Columns.Add("Return Cost", 0, HorizontalAlignment.Right)

            '.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize)
            '.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.HeaderSize)
            '.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.ColumnContent)
        End With

        If m_SInvoiceId <> 0 Then
            cmd = New SqlCommand("usp_tr_sinvoice_dtl_RET_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int)
            prm2.Value = m_SInvoiceId

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
                lvItem.SubItems.Add(myReader.GetValue(8)) 'sinvoice_qty
                lvItem.SubItems.Add(myReader.GetValue(9)) 'stock_balance
                If myReader.Item(10) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(10)) 'sku_uom
                End If
                lvItem.SubItems.Add(FormatNumber(myReader.Item(11), Dec))
                For i = 12 To 16
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
        cmd = New SqlCommand("usp_tr_sinvoice_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int)
        prm1.Value = m_SInvoiceId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtSInvoiceNo.Text = myReader.GetString(1)
            m_CId = myReader.GetInt32(3)
            txtCCode.Text = myReader.GetString(4)
            txtSName.Text = myReader.GetString(5)
            m_SlsCodeId = myReader.GetInt32(6)
            txtSlsCode.Text = myReader.GetString(7)
            ntbSInvoiceTerms.Text = myReader.GetInt32(8)
            dtpSInvoiceDate.Value = myReader.GetDateTime(2)
            dtpSInvoiceDueDate.Value = myReader.GetDateTime(9)
            If Not myReader.IsDBNull(myReader.GetOrdinal("ref_no")) Then
                txtRefNo.Text = myReader.GetString(myReader.GetOrdinal("ref_no"))
            Else
                txtRefNo.Text = ""
            End If
            'm_PaymentMethod = myReader.GetString(13)
            If Not myReader.IsDBNull(myReader.GetOrdinal("sinvoice_remarks")) Then
                txtSInvoiceRemarks.Text = myReader.GetString(myReader.GetOrdinal("sinvoice_remarks"))
            Else
                txtSInvoiceRemarks.Text = ""
            End If
            m_CurrId = myReader.GetInt32(12)
            txtCurrCode.Text = myReader.GetString(13)
            ntbSInvCurrRate.Text = FormatNumber(myReader.GetValue(14))
            txtSInvoiceSubtotal.Text = FormatNumber(myReader.GetValue(17))
            txtSInvoiceTax.Text = FormatNumber(myReader.GetValue(18))
            txtSInvoiceTotal.Text = FormatNumber(myReader.GetValue(19))
            txtLocalSInvoiceSubTotal.Text = FormatNumber(myReader.GetValue(23))
            txtLocalSInvoiceTax.Text = FormatNumber(myReader.GetValue(24))
            txtLocalSInvoiceTotal.Text = FormatNumber(myReader.GetValue(25))
            m_SInvStatus = myReader.GetString(26)
            isPosted = myReader.GetBoolean(28)
            m_PeriodId = myReader.GetInt32(29)
        End While

        myReader.Close()
        cn.Close()

        If isPosted = True Then txtPeriodId.Text = GetPeriodName(m_PeriodId)

        For i = 0 To m_SInvStatusArr.GetUpperBound(0)
            If m_SInvStatus = m_SInvStatusArr(i, 0) Then
                txtSInvStatus.Text = m_SInvStatusArr(i, 1)
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
        cmd = New SqlCommand("usp_tr_sinvoice_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int)
        prm1.Value = m_SInvoiceId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtSInvoiceSubtotal.Text = FormatNumber(myReader.GetValue(17))
            txtSInvoiceTax.Text = FormatNumber(myReader.GetValue(18))
            txtSInvoiceTotal.Text = FormatNumber(myReader.GetValue(19))
            txtLocalSInvoiceSubTotal.Text = FormatNumber(myReader.GetValue(23))
            txtLocalSInvoiceTax.Text = FormatNumber(myReader.GetValue(24))
            txtLocalSInvoiceTotal.Text = FormatNumber(myReader.GetValue(25))
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Sub refresh_totalD()
        txtSInvoiceGrossAmt.Text = FormatNumber((ntbSInvoiceQty.Text) * CDbl(ntbSInvoicePrice.Text))
        txtSInvoiceTaxAmt.Text = FormatNumber((ntbSInvoiceQty.Text) * CDbl(ntbSInvoicePrice.Text) * CDbl(ntbSInvoiceTaxPercent.Text) / 100)
        txtSInvoiceNetAmt.Text = FormatNumber(CDbl(txtSInvoiceGrossAmt.Text) + CDbl(txtSInvoiceTaxAmt.Text))
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_SInvoiceId = 0
        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_SInvoiceId = 0 Then
            Me.Close()
        Else
            lock_obj(True)
            lock_objD(True)
            clear_objD()
            m_SInvoiceDId = 0
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If m_CId = 0 Or m_SlsCodeId = 0 Then
                MsgBox("Sales Code & Customer information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtCCode.Focus()
                Exit Sub
            End If

            If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
                MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                Exit Sub
            End If

            If CDbl(txtSInvoiceTotal.Text) = 0 Then
                MsgBox("Warning,Sales Return total is 0 !", vbInformation, Me.Text)
            End If

            If m_SInvoiceId = 0 Then
                If txtSInvoiceNo.Text = "" Then
                    txtSInvoiceNo.Text = GetSysNumber("sret", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If
            End If

            cmd = New SqlCommand(IIf(m_SInvoiceId = 0, "usp_tr_sinvoice_INS", "usp_tr_sinvoice_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinvoice_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtSInvoiceNo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@sinvoice_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpSInvoiceDate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm3.Value = m_CId
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@sls_code_id", SqlDbType.Int)
            prm5.Value = m_SlsCodeId
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@sinvoice_period_id", SqlDbType.Int)
            prm6.Value = m_PeriodArr(m_PeriodArrSelected, 0)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@sinvoice_terms", SqlDbType.Int, 50)
            prm7.Value = ntbSInvoiceTerms.Text
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@sinvoice_duedate", SqlDbType.SmallDateTime)
            prm8.Value = dtpSInvoiceDueDate.Value.Date
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
            prm9.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@sinvoice_remarks", SqlDbType.NVarChar)
            prm10.Value = IIf(txtSInvoiceRemarks.Text = "", DBNull.Value, txtSInvoiceRemarks.Text)
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm11.Value = m_CurrId
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@sinvoice_curr_rate", SqlDbType.Money)
            prm12.Value = FormatNumber(ntbSInvCurrRate.Text)
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@is_return", SqlDbType.Bit)
            prm13.Value = 1
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm14.Value = My.Settings.UserName
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int)

            If m_SInvoiceId = 0 Then
                prm16.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_SInvoiceId = prm16.Value
                'MessageBox.Show(m_SInvoiceId)
                cn.Close()
                If isGetNum = True Then UpdSysNumber("sret")
            Else
                prm16.Value = m_SInvoiceId
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                'clear_lvw()
            End If

            lock_obj(True)
            lock_objD(True)
            cmbSODtlType.Enabled = False
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
        'If m_SInvStatus = "FP" Then
        '    btnSave.Enabled = False
        '    btnDelete.Enabled = False
        '    lock_objD(True)
        'End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_tr_sinvoice_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int)
            prm1.Value = m_SInvoiceId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm2.Value = m_CId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@sinvoice_curr_rate", SqlDbType.Money)
            prm4.Value = ntbSInvCurrRate.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@sinvoice_total", SqlDbType.Money)
            prm5.Value = txtSInvoiceTotal.Text
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@is_return", SqlDbType.Bit)
            prm6.Value = 1
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm7.Value = My.Settings.UserName

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            btnAdd_Click(sender, e)
        End If
        autoRefresh()
    End Sub

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        Try
            If m_SInvoiceId = 0 Then
                If m_CId = 0 Or m_SlsCodeId = 0 Then
                    MsgBox("Sales Code & Customer information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                    txtCCode.Focus()
                    Exit Sub
                End If

                If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
                    MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                    Exit Sub
                End If

                SaveSInvoiceHeader()
            End If

            If txtSInvoiceDtlDesc.Text = "" Then
                MsgBox("Line Description are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtSInvoiceDtlDesc.Focus()
                Exit Sub
            End If

            If cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S" And (m_SKUId = 0 Or m_LocationId = 0) Then
                MsgBox("Stock and Location are primary fields that should be entered. Please select before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtSInvoiceDtlDesc.Focus()
                Exit Sub
            End If

            cmd = New SqlCommand(IIf(m_SInvoiceDId = 0, "usp_tr_sinvoice_dtl_RET_INS", "usp_tr_sinvoice_dtl_RET_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int)
            prm1.Value = m_SInvoiceId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@sinvoice_dtl_type", SqlDbType.NVarChar, 50)
            prm2.Value = cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
            prm4.Value = IIf(cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S", m_SKUId, 0)
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@sinvoice_dtl_desc", SqlDbType.NVarChar, 255)
            prm5.Value = IIf(txtSInvoiceDtlDesc.Text = "", DBNull.Value, txtSInvoiceDtlDesc.Text)
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@sinvoice_qty", SqlDbType.Decimal)
            prm6.Value = IIf(ntbSInvoiceQty.Text = "", 0, CDbl(ntbSInvoiceQty.Text))
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@sinvoice_price", SqlDbType.Decimal)
            prm7.Value = FormatNumber(ntbSInvoicePrice.Text, Dec)
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@tax_percent", SqlDbType.Decimal)
            prm8.Value = ntbSInvoiceTaxPercent.Text / 100
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@return_cost", SqlDbType.Decimal)
            prm9.Value = FormatNumber(ntbReturnCost.Text)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int)
            prm10.Value = m_LocationId
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@income_id", SqlDbType.Int)
            prm11.Value = IIf(cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "I", m_SKUId, 0)
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm12.Value = m_CId
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@sinvoice_curr_rate", SqlDbType.Money)
            prm13.Value = ntbSInvCurrRate.Text

            If m_SInvoiceDId <> 0 Then
                Dim prm24 As SqlParameter = cmd.Parameters.Add("@sinvoice_dtl_id", SqlDbType.Int)
                prm24.Value = m_SInvoiceDId
                Dim prm25 As SqlParameter = cmd.Parameters.Add("@sinvoice_qty_before", SqlDbType.Decimal)
                prm25.Value = m_SInvoiceQtyBefore
                Dim prm26 As SqlParameter = cmd.Parameters.Add("@sinvoice_price_before", SqlDbType.Decimal)
                prm26.Value = m_SInvoicePriceBefore
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
        End Try
    End Sub

    Sub SaveSInvoiceHeader()
        Try
            If txtSInvoiceNo.Text = "" Then
                txtSInvoiceNo.Text = GetSysNumber("sret", Now.Date)
                isGetNum = True
            Else
                isGetNum = False
            End If

            cmd = New SqlCommand("usp_tr_sinvoice_INS", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinvoice_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtSInvoiceNo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@sinvoice_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpSInvoiceDate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm3.Value = m_CId
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@sls_code_id", SqlDbType.Int)
            prm5.Value = m_SlsCodeId
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@sinvoice_period_id", SqlDbType.Int)
            prm6.Value = m_PeriodArr(m_PeriodArrSelected, 0)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@sinvoice_terms", SqlDbType.Int, 50)
            prm7.Value = ntbSInvoiceTerms.Text
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@sinvoice_duedate", SqlDbType.SmallDateTime)
            prm8.Value = dtpSInvoiceDueDate.Value.Date
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
            prm9.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@sinvoice_remarks", SqlDbType.NVarChar)
            prm10.Value = IIf(txtSInvoiceRemarks.Text = "", DBNull.Value, txtSInvoiceRemarks.Text)
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm11.Value = m_CurrId
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@sinvoice_curr_rate", SqlDbType.Money)
            prm12.Value = FormatNumber(ntbSInvCurrRate.Text)
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@is_return", SqlDbType.Bit)
            prm13.Value = 1
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm14.Value = My.Settings.UserName
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int)
            prm16.Direction = ParameterDirection.Output

            cn.Open()
            cmd.ExecuteReader()
            m_SInvoiceId = prm16.Value
            cn.Close()
            If isGetNum = True Then UpdSysNumber("sret")
            txtSInvoiceNo.ReadOnly = True
            ntbSInvCurrRate.ReadOnly = True
            btnCustomer.Enabled = False
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

    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD.Click
        If m_SInvoiceDId = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_tr_sinvoice_dtl_RET_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinvoice_dtl_id", SqlDbType.Int)
            prm1.Value = m_SInvoiceDId
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@sinvoice_dtl_net", SqlDbType.Money)
            prm3.Value = txtSInvoiceNetAmt.Text
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@sinvoice_curr_rate", SqlDbType.Money)
            prm4.Value = ntbSInvCurrRate.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm5.Value = m_CId

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()
            refresh_total()
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        'cmbPODtlType.Enabled = False
        With ListView1.SelectedItems.Item(0)
            m_SInvoiceDId = LeftSplitUF(.Tag)
            m_SODtlType = .SubItems.Item(0).Text
            Dim mList As clsMyListStr
            Dim i As Integer
            For i = 1 To cmbSODtlType.Items.Count + 1
                mList = cmbSODtlType.Items(i - 1)
                If m_SODtlType = mList.ItemData Then
                    cmbSODtlType.SelectedIndex = i - 1
                    Exit For
                End If
            Next
            m_SKUId = .SubItems.Item(2).Text
            txtSKUCode.Text = .SubItems.Item(3).Text
            txtSInvoiceDtlDesc.Text = .SubItems.Item(4).Text
            m_LocationId = IIf(.SubItems.Item(5).Text = "", 0, .SubItems.Item(5).Text)
            m_LocationIdBefore = IIf(.SubItems.Item(5).Text = "", 0, .SubItems.Item(5).Text)
            txtLocationCode.Text = IIf(.SubItems.Item(6).Text = "", "", .SubItems.Item(6).Text)
            ntbSInvoiceQty.Text = .SubItems.Item(7).Text
            m_SInvoiceQtyBefore = .SubItems.Item(7).Text
            txtSKUUoM.Text = .SubItems.Item(9).Text
            ntbSInvoicePrice.Text = FormatNumber(.SubItems.Item(10).Text, Dec)
            m_SInvoicePriceBefore = .SubItems.Item(10).Text
            txtSInvoiceGrossAmt.Text = FormatNumber(.SubItems.Item(11).Text)
            ntbSInvoiceTaxPercent.Text = .SubItems.Item(12).Text
            txtSInvoiceTaxAmt.Text = FormatNumber(.SubItems.Item(13).Text)
            txtSInvoiceNetAmt.Text = FormatNumber(.SubItems.Item(14).Text)
            ntbReturnCost.Text = FormatNumber(.SubItems.Item(15).Text)
        End With
    End Sub

    Private Sub cmbSODtlType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSODtlType.SelectedIndexChanged
        If Not btnAddD.Enabled = True Then Exit Sub
        Select Case cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData
            Case "S", "I"
                If Not btnCancel.Enabled = False Then
                    'btnSKU.Enabled = False
                    'txtPInvoiceDtlDesc.ReadOnly = False
                    ntbSInvoiceQty.ReadOnly = IIf(cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S", False, True)
                    ntbSInvoicePrice.ReadOnly = IIf(cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S", False, True)
                    ntbSInvoiceTaxPercent.ReadOnly = IIf(cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S", False, True)
                End If

            Case "T"
                'txtSKUCode.ReadOnly = True
                'btnSKU.Enabled = False
                ntbSInvoiceQty.ReadOnly = True
                ntbSInvoicePrice.ReadOnly = True
                ntbSInvoiceTaxPercent.ReadOnly = True
        End Select
    End Sub

    Private Sub ntbPInvoicePrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSInvoicePrice.LostFocus
        If ntbSInvoicePrice.Text = "" Then ntbSInvoicePrice.Text = FormatNumber(0)
        refresh_totalD()
        ntbSInvoicePrice.Text = FormatNumber(ntbSInvoicePrice.Text, Dec)
    End Sub

    Private Sub ntbPInvoiceTaxPercent_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSInvoiceTaxPercent.LostFocus
        'ntbPOTax.Text = FormatPercent(CSng(ntbPOTax.Text.Replace("%", "")) / 100, 0)
        If ntbSInvoiceTaxPercent.Text = "" Then ntbSInvoiceTaxPercent.Text = FormatNumber(m_SInvoiceTaxPercent)
        refresh_totalD()
        ntbSInvoiceTaxPercent.Text = FormatNumber(ntbSInvoiceTaxPercent.Text, 0)
    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        clear_objD()
        cmbSODtlType.Enabled = True
    End Sub

    Private Sub ntbPInvoiceQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSInvoiceQty.LostFocus
        If ntbSInvoiceQty.Text = "" Then ntbSInvoiceQty.Text = FormatNumber(-1)
        If ntbSInvoiceQty.DecimalValue = 0 Then ntbSInvoiceQty.Text = FormatNumber(-1)
        If CDbl(ntbSInvoiceQty.Text) > 0 Then ntbSInvoiceQty.Text = CDbl(ntbSInvoiceQty.Text * -1)
        refresh_totalD()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Sls_Return_Form '" & txtSInvoiceNo.Text & "'"
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SReturn_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_Return_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Sales Return"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("SReturn_"))
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

    Private Sub ntbPInvCurrRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSInvCurrRate.LostFocus
        If ntbSInvCurrRate.Text.Length = 0 Then ntbSInvCurrRate.Undo()
        If m_SInvoiceId = 0 Then
            If m_CurrId = m_CurrBaseId Then
                ntbSInvCurrRate.Text = "1"
            Else
                If ntbSInvCurrRate.DecimalValue = 0 Then ntbSInvCurrRate.Undo()
            End If
        End If
        ntbSInvCurrRate.Text = FormatNumber(ntbSInvCurrRate.Text)
    End Sub

    Private Sub btnSlsCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSlsCode.Click
        Dim NewFormDialog As New fdlSlsCode
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub ntbPInvoiceTerms_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSInvoiceTerms.LostFocus
        If ntbSInvoiceTerms.Text = "" Then ntbSInvoiceTerms.Text = "0" : dtpSInvoiceDueDate.Value = dtpSInvoiceDate.Value
        dtpSInvoiceDueDate.Value = DateAdd(DateInterval.Day, CInt(ntbSInvoiceTerms.Text), dtpSInvoiceDate.Value)
    End Sub

    Private Sub ntbPInvoiceTerms_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbSInvoiceTerms.TextChanged

    End Sub

    Private Sub dtpPInvoiceDueDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSInvoiceDueDate.ValueChanged
        If dtpSInvoiceDueDate.Value < dtpSInvoiceDate.Value Then dtpSInvoiceDate.Value = dtpSInvoiceDueDate.Value
        ntbSInvoiceTerms.Text = DateDiff(DateInterval.Day, dtpSInvoiceDate.Value, dtpSInvoiceDueDate.Value)
    End Sub

    Private Sub dtpSInvoiceDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSInvoiceDate.ValueChanged
        dtpSInvoiceDueDate.Value = DateAdd(DateInterval.Day, CInt(ntbSInvoiceTerms.Text), dtpSInvoiceDate.Value)
        Dim isCheckIn As Boolean
        For i As Integer = 0 To m_PeriodArr.GetUpperBound(0)
            If dtpSInvoiceDate.Value >= m_PeriodArr(i, 2) AndAlso dtpSInvoiceDate.Value <= m_PeriodArr(i, 3) Then
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

    Private Sub ntbPInvoiceQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbSInvoiceQty.TextChanged

    End Sub
    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmSReturnList).Any Then
            Call frmSReturnList.frmSReturnListShow(Nothing, EventArgs.Empty)
        End If
    End Sub
End Class
