Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmSInvoice
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_SInvoiceId As Integer
    Dim m_SInvoiceDId As Integer
    Dim m_SOId As Integer
    Dim m_CId As Integer
    Dim m_SInvStatus As String
    Dim m_SInvStatusArr(2, 1) As String
    Dim m_CIdTemp As Integer
    Dim m_SONoTemp As String
    Dim m_CCodeTemp As String
    Dim m_CNameTemp As String
    Dim m_invExpense As String
    Dim m_SOStatus As String
    Dim m_SODtlType As String
    Dim m_SDeliveryId As Integer
    Dim m_SDeliveryDId As Integer
    Dim m_SKUId As Integer
    Dim m_LocationId As Integer
    Dim m_SInvoiceTaxPercent As Single
    Dim m_CurrId As Integer
    Dim m_CurrBaseId As Integer
    Dim m_SlsCodeId As Integer
    Dim m_PeriodId As Integer
    Dim m_PeriodArr(0, 0) As String
    Dim m_PeriodArrSelected As Integer
    Dim isGetNum As Boolean
    Dim isAllowDelete As Boolean
    Dim isPosted As Boolean
    Private docInvoice As ReportDocument
    Dim Dec As Integer = GetSysInit("decimal_digit")

    Dim isTruncateSalesVAT As Boolean = GetSysInit("truncate_sales_VAT")

    Private Sub frmSInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

    Public Property SOId() As Integer
        Get
            Return m_SOId
        End Get
        Set(ByVal Value As Integer)
            m_SOId = Value
        End Set
    End Property

    Public Property SONo() As String
        Get
            Return txtSONo.Text
        End Get
        Set(ByVal Value As String)
            txtSONo.Text = Value
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

    Public Property GetNumCheck() As Boolean
        Get
            Return isGetNum
        End Get
        Set(ByVal Value As Boolean)
            isGetNum = Value
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

    Public Property invGross() As String
        Get
            Return txtSInvoiceGross.Text
        End Get
        Set(ByVal Value As String)
            txtSInvoiceGross.Text = Value
        End Set
    End Property

    Public Property invDiscount() As String
        Get
            Return txtSInvoiceDiscount.Text
        End Get
        Set(ByVal Value As String)
            txtSInvoiceDiscount.Text = Value
        End Set
    End Property

    Public Property invSubtotal() As String
        Get
            Return txtSInvoiceSubtotal.Text
        End Get
        Set(ByVal Value As String)
            txtSInvoiceSubtotal.Text = Value
        End Set
    End Property

    Public Property invTax() As String
        Get
            Return txtSInvoiceTax.Text
        End Get
        Set(ByVal Value As String)
            txtSInvoiceTax.Text = Value
        End Set
    End Property

    Public Property invTotal() As String
        Get
            Return txtSInvoiceTotal.Text
        End Get
        Set(ByVal Value As String)
            txtSInvoiceTotal.Text = Value
        End Set
    End Property

    Public Property invExpense() As String
        Get
            Return m_invExpense
        End Get
        Set(ByVal Value As String)
            m_invExpense = Value
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

    Public Property SInvoiceRemarks() As String
        Get
            Return txtSInvoiceRemarks.Text
        End Get
        Set(ByVal Value As String)
            txtSInvoiceRemarks.Text = Value
        End Set
    End Property

    Sub clear_obj()
        m_SInvoiceId = 0
        m_CId = 0
        m_SlsCodeId = 0
        m_CurrId = 0
        txtSInvoiceNo.Text = ""
        ntbSInvoiceTerms.Text = "0"
        dtpSInvoiceDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtCCode.Text = ""
        txtCName.Text = ""
        dtpSInvoiceDueDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtSlsCode.Text = ""
        txtRefNo.Text = ""
        txtSInvoiceRemarks.Text = ""
        txtCurrCode.Text = ""
        ntbSInvCurrRate.Text = FormatNumber(1)
        txtSInvoiceGross.Text = FormatNumber(0)
        txtSInvoiceDiscount.Text = FormatNumber(0)
        txtSInvoiceSubtotal.Text = FormatNumber(0)
        txtSInvoiceTax.Text = FormatNumber(0)
        txtSInvoiceTotal.Text = FormatNumber(0)
        txtLocalSInvoiceSubTotal.Text = FormatNumber(0)
        txtLocalSInvoiceTax.Text = FormatNumber(0)
        txtLocalSInvoiceTotal.Text = FormatNumber(0)
        m_SInvStatus = m_SInvStatusArr(0, 0)
        txtSInvoiceStatus.Text = m_SInvStatusArr(0, 1)
        isGetNum = True
        isPosted = False
    End Sub

    Sub clear_objD()
        m_SInvoiceDId = 0
        m_SOId = 0
        m_SDeliveryDId = 0
        m_SDeliveryId = 0
        m_LocationId = 0
        m_SKUId = 0
        cmbSODtlType.SelectedIndex = 0
        txtSONo.Text = ""
        txtSDeliveryNo.Text = ""
        txtSKUCode.Text = ""
        txtSInvoiceDtlDesc.Text = ""
        txtLocationCode.Text = ""
        ntbSInvoiceQty.Text = FormatNumber(0)
        ntbSInvoicePrice.Text = FormatNumber(0)
        ntbSInvoiceDiscPercent.Text = FormatNumber(0)
        ntbSInvoiceDiscAmt.Text = FormatNumber(0)
        txtSInvoiceGrossAfterDiscAmt.Text = FormatNumber(0)
        ntbSInvoiceTaxPercent.Text = FormatNumber(m_SInvoiceTaxPercent, 0)
        txtSInvoiceTaxAmt.Text = FormatNumber(0)
        txtSInvoiceGrossAmt.Text = FormatNumber(0)
        txtSInvoiceNetAmt.Text = FormatNumber(0)
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        dtpSInvoiceDate.Enabled = Not isLock
        ntbSInvoiceTerms.ReadOnly = isLock
        dtpSInvoiceDueDate.Enabled = Not isLock
        txtSInvoiceRemarks.ReadOnly = isLock
        txtRefNo.ReadOnly = isLock
        btnSlsCode.Enabled = Not isLock

        If m_SInvStatus = "UP" Then btnEdit.Enabled = isLock Else btnEdit.Enabled = False
        If isPosted = True Then btnEdit.Enabled = False
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnPrint.Enabled = isLock
        btnPrintGroup.Enabled = isLock

        If m_SInvoiceId = 0 Then
            txtSInvoiceNo.ReadOnly = False
            ntbSInvCurrRate.ReadOnly = False
            'btnSO.Enabled = True
            btnCustomer.Enabled = True
            btnDelete.Enabled = isLock
        Else
            txtSInvoiceNo.ReadOnly = True
            If m_SInvStatus = "UP" And ListView1.Items.Count = 0 Then
                ntbSInvCurrRate.ReadOnly = False
            Else
                ntbSInvCurrRate.ReadOnly = True
            End If
            'btnSO.Enabled = False
            btnCustomer.Enabled = False
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        If m_SInvoiceDId = 0 Then cmbSODtlType.Enabled = True Else cmbSODtlType.Enabled = False
        If cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S" Then txtSInvoiceDtlDesc.ReadOnly = True Else txtSInvoiceDtlDesc.ReadOnly = isLock
        If cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S" Then ntbSInvoiceQty.ReadOnly = True Else ntbSInvoiceQty.ReadOnly = isLock
        '---- modif by hendra untuk merubah price&tax yang belum dibayar-------------
        If m_SInvStatus = "UP" Then
            If cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S" Then ntbSInvoicePrice.ReadOnly = isLock Else ntbSInvoicePrice.ReadOnly = isLock
            If cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S" Then ntbSInvoiceTaxPercent.ReadOnly = isLock Else ntbSInvoiceTaxPercent.ReadOnly = isLock
        Else
            If cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S" Then ntbSInvoicePrice.ReadOnly = True Else ntbSInvoicePrice.ReadOnly = isLock
            If cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S" Then ntbSInvoiceTaxPercent.ReadOnly = True Else ntbSInvoiceTaxPercent.ReadOnly = isLock
        End If
        '---- end modify --------------------
        If cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S" Then ntbSInvoiceDiscPercent.ReadOnly = True Else ntbSInvoiceDiscPercent.ReadOnly = isLock
        If cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S" Then ntbSInvoiceDiscAmt.ReadOnly = True Else ntbSInvoiceDiscAmt.ReadOnly = isLock
        btnSO.Enabled = Not isLock
        btnSDelivery.Enabled = Not isLock
        If cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S" Then btnSKU.Enabled = False Else btnSKU.Enabled = Not isLock
        btnSaveD.Enabled = Not isLock
        btnDeleteD.Enabled = Not isLock
        btnAddD.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("sdelivery_dtl_id", 0)
            .Columns.Add("so_dtl_type", 0)
            .Columns.Add("Line Type", 70)
            .Columns.Add("sdelivery_id", 0)
            .Columns.Add("Sales Delivery No.", 110)
            .Columns.Add("SKU Id", 0)
            .Columns.Add("Code", 60)
            .Columns.Add("Line Description", 220)
            .Columns.Add("locationId", 0)
            .Columns.Add("Location", 90)
            .Columns.Add("Qty", 50, HorizontalAlignment.Right)
            .Columns.Add("UoM", 50)
            .Columns.Add("Unit Price", 90, HorizontalAlignment.Right)
            .Columns.Add("Gross Amount", 100, HorizontalAlignment.Right)
            .Columns.Add("Disc. %", 60, HorizontalAlignment.Right)
            .Columns.Add("Disc. Amount", 90, HorizontalAlignment.Right)
            .Columns.Add("Gross After Disc.", 100, HorizontalAlignment.Right)
            .Columns.Add("Tax %", 50, HorizontalAlignment.Right)
            .Columns.Add("Tax Amount", 90, HorizontalAlignment.Right)
            .Columns.Add("Net Amount", 120, HorizontalAlignment.Right)
            .Columns.Add("so_id", 0)
            .Columns.Add("Sales Order No.", 100)
        End With

        If m_SInvoiceId <> 0 Then
            cmd = New SqlCommand("usp_tr_sinvoice_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int)
            prm1.Value = m_SInvoiceId

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(1)))
                lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                lvItem.SubItems.Add(myReader.GetString(2)) 'so_dtl_type
                lvItem.SubItems.Add(myReader.GetString(3)) 'line_type
                lvItem.SubItems.Add(IIf(myReader.Item(4) Is System.DBNull.Value, "0", myReader.Item(4))) 'sdelivery_id
                lvItem.SubItems.Add(IIf(myReader.Item(5) Is System.DBNull.Value, "", myReader.Item(5))) 'sdelivery_no
                Select Case myReader.GetString(2)
                    Case "S"
                        lvItem.SubItems.Add(myReader.GetInt32(6)) 'sku_id
                        lvItem.SubItems.Add(myReader.GetString(7)) 'sku_code

                    Case "I"
                        lvItem.SubItems.Add(myReader.GetInt32(11)) 'income_id
                        lvItem.SubItems.Add(myReader.GetString(12)) 'income_code
                    Case Else
                        lvItem.SubItems.Add("0")
                        lvItem.SubItems.Add("")
                End Select
                lvItem.SubItems.Add(myReader.GetString(8)) 'sinvoice_dtl_desc
                lvItem.SubItems.Add(myReader.GetInt32(9)) 'location_id
                If myReader.Item(10) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(10)) 'location_code
                End If
                lvItem.SubItems.Add(myReader.GetValue(13)) 'sinvoice_qty
                If myReader.Item(14) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(14)) 'sku_uom
                End If
                lvItem.SubItems.Add(FormatNumber(myReader.Item(15), Dec))
                For i = 16 To 22
                    If i = 17 Or i = 20 Then
                        '20160722 dua koma belakang
                        lvItem.SubItems.Add(FormatNumber(CDec(myReader.Item(i)), 2)) 'sinvoice_dtl_discpercent, sinvoice_taxpercent
                    Else
                        lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
                    End If
                Next
                lvItem.SubItems.Add(IIf(myReader.Item(23) Is System.DBNull.Value, "0", myReader.Item(23))) 'so_id
                lvItem.SubItems.Add(IIf(myReader.Item(24) Is System.DBNull.Value, "", myReader.Item(24))) 'so_no
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
            txtCName.Text = myReader.GetString(5)
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
            If Not myReader.IsDBNull(myReader.GetOrdinal("sinvoice_remarks")) Then
                txtSInvoiceRemarks.Text = myReader.GetString(myReader.GetOrdinal("sinvoice_remarks"))
            Else
                txtSInvoiceRemarks.Text = ""
            End If
            m_CurrId = myReader.GetInt32(12)
            txtCurrCode.Text = myReader.GetString(13)
            ntbSInvCurrRate.Text = FormatNumber(myReader.GetValue(14))
            txtSInvoiceGross.Text = FormatNumber(myReader.GetValue(15))
            txtSInvoiceDiscount.Text = FormatNumber(myReader.GetValue(16))
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

        For i As Integer = 0 To m_SInvStatusArr.GetUpperBound(0)
            If m_SInvStatus = m_SInvStatusArr(i, 0) Then
                txtSInvoiceStatus.Text = m_SInvStatusArr(i, 1)
                Exit For
            End If
        Next
    End Sub

    Sub refresh_total()
        cmd = New SqlCommand("usp_tr_sinvoice_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int)
        prm1.Value = m_SInvoiceId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtSInvoiceGross.Text = FormatNumber(myReader.GetValue(15))
            txtSInvoiceDiscount.Text = FormatNumber(myReader.GetValue(16))
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
        txtSInvoiceGrossAfterDiscAmt.Text = FormatNumber((1 - CDbl(ntbSInvoiceDiscPercent.Text) / 100) * CDbl(txtSInvoiceGrossAmt.Text))

        If isTruncateSalesVAT = True Then
            txtSInvoiceTaxAmt.Text = FormatNumber(Math.Truncate((ntbSInvoiceQty.Text) * CDbl(ntbSInvoicePrice.Text) * CDbl(ntbSInvoiceTaxPercent.Text) / 100))
        Else
            txtSInvoiceTaxAmt.Text = FormatNumber((ntbSInvoiceQty.Text) * CDbl(ntbSInvoicePrice.Text) * CDbl(ntbSInvoiceTaxPercent.Text) / 100)
        End If

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
            cmbSODtlType.Enabled = False
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

            '#RK - 20160205_02 - Validasi Invoice Date harus >= Delivery Date dari detil invoice
            Dim myReader As SqlDataReader
            cmd = New SqlCommand("usp_tr_sinvoice_checkdate", cn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim prm_sinvoice_no As SqlParameter = cmd.Parameters.Add("@sinvoice_no", SqlDbType.NVarChar, 50)
            prm_sinvoice_no.Value = txtSInvoiceNo.Text
            cn.Open()
            myReader = cmd.ExecuteReader
            If myReader.HasRows = True Then
                myReader.Close()
                cn.Close()
                MsgBox("Invoice Date must be Greater Than or Equal to Receive Dates", vbCritical + vbOKOnly, Me.Text)
                Exit Sub
            End If

            myReader.Close()
            cn.Close()
            '#RK - 20160205_02 - End 

            If CDbl(txtSInvoiceTotal.Text) = 0 Then
                MsgBox("Warning,Sales Invoice total is 0 !", vbInformation, Me.Text)
            End If

            AppLock.GetLock()

            If m_SInvoiceId = 0 Then
                If txtSInvoiceNo.Text.Trim = "" Then
                    txtSInvoiceNo.Text = GetSysNumber("sinv", Now.Date)
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
            'Dim prm4 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
            'prm4.Value = m_SOId
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@sls_code_id", SqlDbType.Int)
            prm5.Value = m_SlsCodeId
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@sinvoice_period_id", SqlDbType.Int)
            prm6.Value = m_PeriodArr(m_PeriodArrSelected, 0)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@sinvoice_terms", SqlDbType.Int)
            prm7.Value = ntbSInvoiceTerms.Text
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@sinvoice_duedate", SqlDbType.SmallDateTime)
            prm8.Value = dtpSInvoiceDueDate.Value.Date
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
            prm9.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
            'Dim prm10 As SqlParameter = cmd.Parameters.Add("@shipment_date", SqlDbType.DateTime)
            'prm10.Value = dtpShipmentDate.Value
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@sinvoice_remarks", SqlDbType.NVarChar)
            prm11.Value = IIf(txtSInvoiceRemarks.Text = "", DBNull.Value, txtSInvoiceRemarks.Text)
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm12.Value = m_CurrId
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@sinvoice_curr_rate", SqlDbType.Money)
            prm13.Value = FormatNumber(ntbSInvCurrRate.Text)
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
                If isGetNum = True Then UpdSysNumber("sinv")
            Else
                prm16.Value = m_SInvoiceId
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                'clear_lvw()
            End If

            AppLock.ReleaseLock()

            lock_obj(True)
            lock_objD(True)
            cmbSODtlType.Enabled = False
            autoRefresh()

        Catch ex As Exception
            'If Err.Number = 5 Then
            '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
            'Else
            '    MsgBox(ex.Message)
            'End If
            MsgBox(ex.Message)
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

            AppLock.GetLock()

            cmd = New SqlCommand("usp_tr_sinvoice_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int)
            prm1.Value = m_SInvoiceId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm2.Value = m_CId
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@sinvoice_no", SqlDbType.NVarChar, 50)
            prm3.Value = txtSInvoiceNo.Text
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@sinvoice_curr_rate", SqlDbType.Money)
            prm4.Value = CDbl(ntbSInvCurrRate.Text)
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@sinvoice_total", SqlDbType.Money)
            prm5.Value = CDbl(txtSInvoiceTotal.Text)
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@is_return", SqlDbType.Bit)
            prm6.Value = 0
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm7.Value = My.Settings.UserName

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            AppLock.ReleaseLock()

            btnAdd_Click(sender, e)
            autoRefresh()
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Sls_Invoice_Form '" & txtSInvoiceNo.Text & "' "
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SInv_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_Invoice_Form.rpt"

        '20160629 load custom rpt if available
        Dim strReportPathCustom As String = strReportPath.Substring(0, strReportPath.Length - 4) & "_Custom.rpt"
        If IO.File.Exists(strReportPathCustom) Then
            strReportPath = strReportPathCustom
        End If

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Sales Invoice"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("SInv_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD.Click
        If m_SInvoiceDId = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then

            AppLock.GetLock()

            cmd = New SqlCommand("usp_tr_sinvoice_dtl_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinvoice_dtl_id", SqlDbType.Int)
            prm1.Value = m_SInvoiceDId
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@sinvoice_dtl_net", SqlDbType.Money)
            prm3.Value = txtSInvoiceNetAmt.Text
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@sinvoice_curr_rate", SqlDbType.Money)
            prm4.Value = ntbSInvCurrRate.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm5.Value = m_CId
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@sdelivery_id", SqlDbType.Int)
            prm6.Value = m_SDeliveryId
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
            prm7.Value = m_SOId

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            AppLock.ReleaseLock()

            clear_lvw()
            clear_objD()
            refresh_total()
            lock_obj(False)
        End If
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

            If m_LocationId = 0 And txtSInvoiceDtlDesc.Text = "" Then
                MsgBox("Location and Line Description are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtSInvoiceDtlDesc.Focus()
                Exit Sub
            End If

            If (cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S" Or cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "I") And m_SKUId = 0 Then
                MsgBox("Please select Stock or Income before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtSInvoiceDtlDesc.Focus()
                Exit Sub
            End If

            AppLock.GetLock()

            cmd = New SqlCommand(IIf(m_SInvoiceDId = 0, "usp_tr_sinvoice_dtl_INS", "usp_tr_sinvoice_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int)
            prm1.Value = m_SInvoiceId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@sinvoice_dtl_type", SqlDbType.NVarChar, 50)
            prm2.Value = cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@sdelivery_dtl_id", SqlDbType.Int)
            prm3.Value = m_SDeliveryDId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
            prm4.Value = IIf(cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S", m_SKUId, 0)
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@sinvoice_dtl_desc", SqlDbType.NVarChar, 255)
            prm5.Value = IIf(txtSInvoiceDtlDesc.Text = "", DBNull.Value, txtSInvoiceDtlDesc.Text)
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@sinvoice_qty", SqlDbType.Decimal)
            prm6.Value = IIf(ntbSInvoiceQty.Text = "", 0, CDbl(ntbSInvoiceQty.Text))
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@sinvoice_price", SqlDbType.Decimal)
            prm7.Value = FormatNumber(ntbSInvoicePrice.Text, Dec)
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@sinvoice_dtl_discpercent", SqlDbType.Decimal)
            prm8.Value = CDbl(ntbSInvoiceDiscPercent.Text) / 100
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@tax_percent", SqlDbType.Decimal)
            prm9.Value = CDbl(ntbSInvoiceTaxPercent.Text) / 100
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int)
            prm10.Value = m_LocationId
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@income_id", SqlDbType.Int)
            prm11.Value = IIf(cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "I", m_SKUId, 0)
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm12.Value = CId
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
            prm13.Value = m_SOId
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@sinvoice_curr_rate", SqlDbType.Money)
            prm14.Value = ntbSInvCurrRate.Text

            If m_SInvoiceDId <> 0 Then
                Dim prm24 As SqlParameter = cmd.Parameters.Add("@sinvoice_dtl_id", SqlDbType.Int)
                prm24.Value = m_SInvoiceDId
            End If

            '20160722 discamt2
            Dim prm25 As SqlParameter = cmd.Parameters.Add("@sinvoice_dtl_discamount2", SqlDbType.Decimal)
            prm25.Value = ntbSInvoiceDiscAmt.Text

            '20161025 - Dikman, Error sinvoice_dtl_tax2
            Dim prm26 As SqlParameter = cmd.Parameters.Add("@sinvoice_dtl_tax2", SqlDbType.Decimal)
            prm26.Value = txtSInvoiceTaxAmt.Text


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

    Sub SaveSInvoiceHeader()
        Try
            AppLock.GetLock()

            If txtSInvoiceNo.Text.Trim = "" Then
                txtSInvoiceNo.Text = GetSysNumber("sinv", Now.Date)
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
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
            prm4.Value = m_SOId
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@sls_code_id", SqlDbType.Int)
            prm5.Value = m_SlsCodeId
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@sinvoice_period_id", SqlDbType.Int)
            prm6.Value = m_PeriodArr(m_PeriodArrSelected, 0)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@sinvoice_terms", SqlDbType.Int)
            prm7.Value = ntbSInvoiceTerms.Text
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@sinvoice_duedate", SqlDbType.SmallDateTime)
            prm8.Value = dtpSInvoiceDueDate.Value.Date
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
            prm9.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
            'Dim prm10 As SqlParameter = cmd.Parameters.Add("@shipment_date", SqlDbType.DateTime)
            'prm10.Value = dtpShipmentDate.Value
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@sinvoice_remarks", SqlDbType.NVarChar)
            prm11.Value = IIf(txtSInvoiceRemarks.Text = "", DBNull.Value, txtSInvoiceRemarks.Text)
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm12.Value = m_CurrId
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@sinvoice_curr_rate", SqlDbType.Money)
            prm13.Value = FormatNumber(ntbSInvCurrRate.Text)
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm14.Value = My.Settings.UserName
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int)

            prm16.Direction = ParameterDirection.Output

            cn.Open()
            cmd.ExecuteReader()
            m_SInvoiceId = prm16.Value
            cn.Close()
            If isGetNum = True Then UpdSysNumber("sinv")
            txtSInvoiceNo.ReadOnly = True
            ntbSInvCurrRate.ReadOnly = True
            'btnSO.Enabled = False
            btnCustomer.Enabled = False
            autoRefresh()

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

    Private Sub btnSlsCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSlsCode.Click
        Dim NewFormDialog As New fdlSlsCode
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub frmSInvoice_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub btnSDelivery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSDelivery.Click
        If m_CId = 0 Or m_SlsCodeId = 0 Then
            MsgBox("Sales Code & Customer information are primary fields that should be entered. Please enter those fields before you do the selection.", vbCritical + vbOKOnly, Me.Text)
            txtCCode.Focus()
            Exit Sub
        End If
        If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
            MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If
        Dim NewFormDialog As New fdlSDeliveryOut
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSO.Click
        If m_CId = 0 Or m_SlsCodeId = 0 Then
            MsgBox("Sales Code & Customer information are primary fields that should be entered. Please enter those fields before you do the selection.", vbCritical + vbOKOnly, Me.Text)
            txtCCode.Focus()
            Exit Sub
        End If
        Dim NewFormDialog As New fdlSOOut
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.CName = txtCName.Text
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        cmbSODtlType.Enabled = False
        With ListView1.SelectedItems.Item(0)
            m_SInvoiceDId = LeftSplitUF(.Tag)
            m_SDeliveryDId = IIf(.SubItems.Item(0).Text = "", 0, .SubItems.Item(0).Text)
            m_SODtlType = .SubItems.Item(1).Text
            Dim mList As clsMyListStr
            Dim i As Integer
            For i = 1 To cmbSODtlType.Items.Count + 1
                mList = cmbSODtlType.Items(i - 1)
                If m_SODtlType = mList.ItemData Then
                    cmbSODtlType.SelectedIndex = i - 1
                    Exit For
                End If
            Next
            m_SDeliveryId = IIf(.SubItems.Item(3).Text = "", 0, .SubItems.Item(3).Text)
            txtSDeliveryNo.Text = IIf(.SubItems.Item(4).Text = "", "", .SubItems.Item(4).Text)
            m_SKUId = .SubItems.Item(5).Text
            txtSKUCode.Text = .SubItems.Item(6).Text
            txtSInvoiceDtlDesc.Text = .SubItems.Item(7).Text
            m_LocationId = IIf(.SubItems.Item(8).Text = "", 0, .SubItems.Item(8).Text)
            txtLocationCode.Text = IIf(.SubItems.Item(9).Text = "", "", .SubItems.Item(9).Text)
            ntbSInvoiceQty.Text = .SubItems.Item(10).Text
            ntbSInvoicePrice.Text = FormatNumber(.SubItems.Item(12).Text, Dec)
            txtSInvoiceGrossAmt.Text = FormatNumber(.SubItems.Item(13).Text)
            ntbSInvoiceDiscPercent.Text = .SubItems.Item(14).Text
            ntbSInvoiceDiscAmt.Text = FormatNumber(.SubItems.Item(15).Text)
            txtSInvoiceGrossAfterDiscAmt.Text = FormatNumber(.SubItems.Item(16).Text)
            ntbSInvoiceTaxPercent.Text = .SubItems.Item(17).Text
            txtSInvoiceTaxAmt.Text = FormatNumber(.SubItems.Item(18).Text)
            txtSInvoiceNetAmt.Text = FormatNumber(.SubItems.Item(19).Text)
            m_SOId = .SubItems.Item(20).Text
            txtSONo.Text = .SubItems.Item(21).Text
        End With
    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        clear_objD()
        cmbSODtlType.Enabled = True
    End Sub

    Private Sub cmbSODtlType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSODtlType.SelectedIndexChanged
        If Not btnAddD.Enabled = True Then Exit Sub
        Select Case cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData
            Case "S"
                If Not btnCancel.Enabled = False Then
                    btnSKU.Enabled = False
                    txtSInvoiceDtlDesc.ReadOnly = True
                    ntbSInvoiceQty.ReadOnly = True
                    ntbSInvoicePrice.ReadOnly = True
                    ntbSInvoiceDiscPercent.ReadOnly = True
                    ntbSInvoiceDiscAmt.ReadOnly = True
                    ntbSInvoiceTaxPercent.ReadOnly = True
                End If

            Case "I"
                If Not btnCancel.Enabled = False Then
                    'txtSKUCode.ReadOnly = False
                    btnSKU.Enabled = True
                    txtSInvoiceDtlDesc.ReadOnly = False
                    ntbSInvoiceQty.ReadOnly = True
                    ntbSInvoicePrice.ReadOnly = False
                    ntbSInvoiceDiscPercent.ReadOnly = True
                    ntbSInvoiceDiscAmt.ReadOnly = True
                    ntbSInvoiceTaxPercent.ReadOnly = False
                    ntbSInvoiceQty.Text = "1"
                    ntbSInvoiceTaxPercent.Text = FormatNumber(m_SInvoiceTaxPercent, 0)
                End If

            Case "T"
                'txtSKUCode.ReadOnly = True
                m_SKUId = 0
                txtSKUCode.Text = ""
                btnSKU.Enabled = False
                ntbSInvoiceQty.ReadOnly = True
                ntbSInvoiceQty.Text = "0"
                ntbSInvoicePrice.ReadOnly = True
                ntbSInvoiceDiscPercent.ReadOnly = True
                ntbSInvoiceDiscAmt.ReadOnly = True
                ntbSInvoiceTaxPercent.ReadOnly = True
                ntbSInvoiceTaxPercent.Text = "0"
        End Select
    End Sub

    Private Sub btnSKU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSKU.Click
        Dim NewFormDialog As New fdlIncome
        NewFormDialog.fdlIncomeMode = 0 'income only
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub ntbSInvoicePrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSInvoicePrice.LostFocus
        ntbSInvoicePrice.Text = FormatNumber(ntbSInvoicePrice.Text, Dec)
        If ntbSInvoicePrice.Text = "" Then ntbSInvoicePrice.Text = FormatNumber(0)
        ntbSInvoiceDiscAmt.Text = FormatNumber((CDbl(ntbSInvoiceQty.Text) * CDbl(ntbSInvoicePrice.Text) * CDbl(ntbSInvoiceDiscPercent.Text) / 100) * -1)
        refresh_totalD()
        ntbSInvoicePrice.Text = FormatNumber(ntbSInvoicePrice.Text, Dec)
    End Sub

    Private Sub ntbSInvoiceTaxPercent_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSInvoiceTaxPercent.LostFocus
        If ntbSInvoiceTaxPercent.Text = "" Or CDbl(ntbSInvoiceTaxPercent.Text) > 100 Then
            ntbSInvoiceTaxPercent.Text = FormatNumber(m_SInvoiceTaxPercent)
        Else
            ntbSInvoiceTaxPercent.Text = FormatNumber(ntbSInvoiceTaxPercent.Text, 0)
        End If
        refresh_totalD()
    End Sub

    Private Sub ntbSInvoiceDiscPercent_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSInvoiceDiscPercent.LostFocus
        If CDbl(ntbSInvoiceDiscPercent.Text) > 100 Then
            ntbSInvoiceDiscPercent.Text = "0"
        Else
            ntbSInvoiceDiscPercent.Text = FormatNumber(ntbSInvoiceDiscPercent.Text)
        End If
    End Sub

    Private Sub ntbSInvCurrRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSInvCurrRate.LostFocus
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

    Private Sub dtpSInvoiceDueDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSInvoiceDueDate.ValueChanged
        If dtpSInvoiceDueDate.Value < dtpSInvoiceDate.Value Then dtpSInvoiceDate.Value = dtpSInvoiceDueDate.Value
        ntbSInvoiceTerms.Text = DateDiff(DateInterval.Day, dtpSInvoiceDate.Value, dtpSInvoiceDueDate.Value)
    End Sub

    Private Sub ntbSInvoiceTerms_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSInvoiceTerms.LostFocus
        If ntbSInvoiceTerms.Text = "" Then ntbSInvoiceTerms.Text = "0" : dtpSInvoiceDueDate.Value = dtpSInvoiceDate.Value
        dtpSInvoiceDueDate.Value = DateAdd(DateInterval.Day, CInt(ntbSInvoiceTerms.Text), dtpSInvoiceDate.Value)
    End Sub

    Private Sub ntbSInvoiceTerms_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbSInvoiceTerms.TextChanged

    End Sub

    Private Sub ntbSInvoicePrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbSInvoicePrice.TextChanged

    End Sub

    Private Sub btnPrintGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintGroup.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Sls_Invoice_Form_Group '" & txtSInvoiceNo.Text & "' "
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SInvGroup_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_Invoice_Form_Group.rpt"

        '20160629 load custom rpt if available
        Dim strReportPathCustom As String = strReportPath.Substring(0, strReportPath.Length - 4) & "_Custom.rpt"
        If IO.File.Exists(strReportPathCustom) Then
            strReportPath = strReportPathCustom
        End If

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Sales Invoice"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("SInvGroup_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub btnFaktur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFaktur.Click
        With rptFakturPajak
            .Flag = 1
            .SInvoiceId = m_SInvoiceId
            .SInvoiceNo = txtSInvoiceNo.Text
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub ntbSInvoiceQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSInvoiceQty.LostFocus
        If ntbSInvoiceQty.Text = "" Then ntbSInvoiceQty.Text = FormatNumber(1)
        If ntbSInvoiceQty.DecimalValue = 0 Then ntbSInvoiceQty.Text = FormatNumber(1)
        refresh_totalD()
    End Sub

    Private Sub ntbSInvoiceQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbSInvoiceQty.TextChanged

    End Sub

    Private Sub txtSInvoiceNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSInvoiceNo.LostFocus
        If txtSInvoiceNo.ReadOnly = False Then
            If txtSInvoiceNo.Text <> "" Then
                If existingDocumentNo("tr_sinvoice", "sinvoice_no", txtSInvoiceNo.Text) = True Then
                    MsgBox("This document number has already been used!", vbCritical, Me.Text)
                    txtSInvoiceNo.Text = ""
                    txtSInvoiceNo.Focus()
                End If
            End If
        End If
    End Sub
    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmSInvoiceList).Any Then
            Call frmSInvoiceList.frmSInvoiceListShow(Nothing, EventArgs.Empty)
        End If
    End Sub


End Class
