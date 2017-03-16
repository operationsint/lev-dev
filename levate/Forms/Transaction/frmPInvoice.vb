Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmPInvoice
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_PInvoiceId As Integer
    Dim m_SId As Integer
    Dim m_PeriodId As Integer
    'Dim m_POType As String
    'Dim m_PaymentMethod As String
    Dim m_PInvStatus As String
    Dim m_PInvStatusArr(2, 1) As String
    Dim m_PeriodArr(0, 0) As String
    Dim m_PeriodArrSelected As Integer
    Dim m_PInvoiceDId As Integer
    Dim m_PReceiveId As Integer
    Dim m_PReceiveDId As Integer
    Dim m_PODtlType As String
    Dim m_SKUId As Integer
    Dim m_LocationId As Integer
    Dim m_PInvoiceTaxPercent As Single
    Dim m_CurrId As Integer
    Dim m_CurrBaseId As Integer
    Dim m_PchCodeId As Integer
    Dim m_POID As Integer
    Dim m_PInvoiceNetAmt As Double
    Dim isGetNum As Boolean
    Dim isAllowDelete As Boolean
    Dim isPosted As Boolean
    Private docPO As ReportDocument
    Dim Dec As Integer = GetSysInit("decimal_digit")

    Dim isTruncatePurchaseVAT As Boolean = GetSysInit("truncate_purchase_VAT")


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

    Public Property POId() As Integer
        Get
            Return m_POId
        End Get
        Set(ByVal Value As Integer)
            m_POId = Value
        End Set
    End Property

    Public Property PONo() As String
        Get
            Return txtPONo.Text
        End Get
        Set(ByVal Value As String)
            txtPONo.Text = Value
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

    Public Property PaymentTerms() As Integer
        Get
            Return ntbPInvoiceTerms.Text
        End Get
        Set(ByVal Value As Integer)
            ntbPInvoiceTerms.Text = Value
        End Set
    End Property

    Public Property PaymentDueDate() As Date
        Get
            Return dtpPInvoiceDueDate.Value
        End Get
        Set(ByVal Value As Date)
            dtpPInvoiceDueDate.Value = Value
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

    Public Property POQty() As Integer
        Get
            Return ntbPInvoiceQty.Text
        End Get
        Set(ByVal Value As Integer)
            ntbPInvoiceQty.Text = Value
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

    Public Property PInvoiceRemarks() As String
        Get
            Return txtPInvoiceRemarks.Text
        End Get
        Set(ByVal Value As String)
            txtPInvoiceRemarks.Text = Value
        End Set
    End Property

    Private Sub btnSKU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSKU.Click
        'Select Case cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData
        '    Case "S"
        '        Dim NewFormDialog As New fdlSKUPO
        '        NewFormDialog.ShowDialog()
        '    Case "E"
        Dim NewFormDialog As New fdlExpense
        NewFormDialog.fdlExpenseMode = 1 'expense only
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
        'End Select
    End Sub

    Sub clear_obj()
        m_PInvoiceId = 0
        m_POID = 0
        m_SId = 0
        m_PchCodeId = 0
        m_CurrId = 0
        txtPInvoiceNo.Text = ""
        ntbPInvoiceTerms.Text = "0"
        dtpPInvoiceDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtPONo.Text = ""
        txtRefNo.Text = ""
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
        m_PReceiveDId = 0
        m_PReceiveId = 0
        m_LocationId = 0
        m_SKUId = 0
        m_PInvoiceNetAmt = 0
        cmbPODtlType.SelectedIndex = 0
        txtPReceiveNo.Text = ""
        txtSKUCode.Text = ""
        txtPInvoiceDtlDesc.Text = ""
        ntbPInvoiceQty.Text = FormatNumber(0)
        txtSKUUoM.Text = ""
        ntbPInvoicePrice.Text = FormatNumber(0, Dec)
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
        ntbPInvCurrRate.ReadOnly = isLock
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
            btnPO.Enabled = True
            btnSupplier.Enabled = True
            btnDelete.Enabled = isLock
        Else
            txtPInvoiceNo.ReadOnly = True
            ntbPInvCurrRate.ReadOnly = True
            btnPO.Enabled = False
            btnSupplier.Enabled = False
            'If p_UserLevel = 1 Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        If m_PInvoiceDId = 0 Then cmbPODtlType.Enabled = True Else cmbPODtlType.Enabled = False
        If cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "S" Then txtPInvoiceDtlDesc.ReadOnly = True Else txtPInvoiceDtlDesc.ReadOnly = isLock
        If cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "S" Then ntbPInvoiceQty.ReadOnly = True Else ntbPInvoiceQty.ReadOnly = isLock
        If cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "S" Then ntbPInvoicePrice.ReadOnly = True Else ntbPInvoicePrice.ReadOnly = isLock
        If cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "S" Then ntbPInvoiceTaxPercent.ReadOnly = True Else ntbPInvoiceTaxPercent.ReadOnly = isLock

        btnPReceive.Enabled = Not isLock
        If cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "S" Then btnSKU.Enabled = False Else btnSKU.Enabled = Not isLock
        btnSaveD.Enabled = Not isLock
        btnDeleteD.Enabled = Not isLock
        btnAddD.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("preceive_dtl_id", 0)
            .Columns.Add("pinvoice_dtl_type", 0)
            .Columns.Add("Line Type", 70)
            .Columns.Add("preceive_id", 0)
            .Columns.Add("Purchase Incoming No.", 130)
            .Columns.Add("sku_id", 0)
            .Columns.Add("Code", 60)
            .Columns.Add("Line Description", 250)
            .Columns.Add("locationId", 0)
            .Columns.Add("Location", 90)
            .Columns.Add("Qty", 60, HorizontalAlignment.Right)
            .Columns.Add("UoM", 60)
            .Columns.Add("Unit Price", 90, HorizontalAlignment.Right)
            .Columns.Add("Gross Amount", 120, HorizontalAlignment.Right)
            .Columns.Add("Tax %", 60, HorizontalAlignment.Right)
            .Columns.Add("Tax Amount", 90, HorizontalAlignment.Right)
            .Columns.Add("Net Amount", 120, HorizontalAlignment.Right)
            .Columns.Add("pinvoice_dtl_net", 0, HorizontalAlignment.Right)

            '.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize)
            '.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.HeaderSize)
            '.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.ColumnContent)
        End With

        If m_PInvoiceId <> 0 Then
            cmd = New SqlCommand("usp_tr_pinvoice_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm2 As SqlParameter = cmd.Parameters.Add("@pinvoice_id", SqlDbType.Int)
            prm2.Value = m_PInvoiceId

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(1))) 'preceive_dtl_id
                lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                For i = 2 To 3 'pinvoice_dtl_type, line_type
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next
                lvItem.SubItems.Add(IIf(myReader.Item(4) Is System.DBNull.Value, "0", myReader.Item(4))) 'preceive_id
                lvItem.SubItems.Add(IIf(myReader.Item(5) Is System.DBNull.Value, "", myReader.Item(5))) 'preceive_no
                Select Case myReader.GetString(2) 'sku_id, sku_code
                    Case "S"
                        lvItem.SubItems.Add(myReader.GetInt32(6))
                        lvItem.SubItems.Add(myReader.GetString(7))
                    Case "E"
                        lvItem.SubItems.Add(myReader.GetInt32(11))
                        lvItem.SubItems.Add(myReader.GetString(12))
                    Case Else
                        lvItem.SubItems.Add("0")
                        lvItem.SubItems.Add("")
                End Select
                lvItem.SubItems.Add(myReader.GetString(8)) 'pinvoice_dtl_desc
                lvItem.SubItems.Add(myReader.GetInt32(9)) 'location_id
                If myReader.Item(10) Is System.DBNull.Value Then 'location_code
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(10))
                End If
                lvItem.SubItems.Add(myReader.GetValue(13)) 'pinvoice_qty
                If myReader.Item(14) Is System.DBNull.Value Then 'sku_uom
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(14))
                End If
                lvItem.SubItems.Add(FormatNumber(myReader.Item(15), Dec))
                For i = 16 To 19
                    If i = 17 Then
                        lvItem.SubItems.Add(FormatNumber(myReader.Item(i), 0))
                    Else
                        lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
                    End If
                Next
                lvItem.SubItems.Add(myReader.Item(19)) 'pinvoice_dtl_net
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
            If Not myReader.IsDBNull(myReader.GetOrdinal("po_id")) Then
                m_POID = myReader.GetInt32(myReader.GetOrdinal("po_id"))
            Else
                m_POID = 0
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("po_no")) Then
                txtPONo.Text = myReader.GetString(myReader.GetOrdinal("po_no"))
            Else
                txtPONo.Text = ""
            End If
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

        If isTruncatePurchaseVAT = True Then
            txtPInvoiceTaxAmt.Text = FormatNumber(Math.Truncate((ntbPInvoiceQty.Text) * CDbl(ntbPInvoicePrice.Text) * CDbl(ntbPInvoiceTaxPercent.Text) / 100))
        Else
            txtPInvoiceTaxAmt.Text = FormatNumber((ntbPInvoiceQty.Text) * CDbl(ntbPInvoicePrice.Text) * CDbl(ntbPInvoiceTaxPercent.Text) / 100)
        End If

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
            cmbPODtlType.Enabled = False
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            If m_SId = 0 Or m_PchCodeId = 0 Then
                MsgBox("Purchase Code & Supplier information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtSCode.Focus()
                Exit Sub
            End If

            If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
                MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                Exit Sub
            End If

            '#RK - 20160205_01 - Validasi Invoice Date harus >= Receive Date dari detil invoice
            Dim myReader As SqlDataReader
            cmd = New SqlCommand("usp_tr_pinvoice_checkdate", cn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim prm_pinvoice_no As SqlParameter = cmd.Parameters.Add("@pinvoice_no", SqlDbType.NVarChar, 50)
            prm_pinvoice_no.Value = txtPInvoiceNo.Text
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
            '#RK - 20160205_01 - End 


            If CDbl(txtPInvoiceTotal.Text) = 0 Then
                MsgBox("Warning,Purchase Invoice total is 0 !", vbInformation, Me.Text)
            End If

            AppLock.GetLock()

            If m_PInvoiceId = 0 Then
                '20160623 daniel s : add trim
                If txtPInvoiceNo.Text.Trim = "" Then
                    txtPInvoiceNo.Text = GetSysNumber("pinv", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If
            End If

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
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@pinvoice_terms", SqlDbType.Int, 50)
            prm7.Value = ntbPInvoiceTerms.Text
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@pinvoice_duedate", SqlDbType.SmallDateTime)
            prm8.Value = dtpPInvoiceDueDate.Value.Date
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
            prm9.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@pinvoice_remarks", SqlDbType.NVarChar)
            prm10.Value = IIf(txtPInvoiceRemarks.Text = "", DBNull.Value, txtPInvoiceRemarks.Text)
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm11.Value = m_CurrId
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@pinvoice_curr_rate", SqlDbType.Money)
            prm12.Value = FormatNumber(ntbPInvCurrRate.Text)
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm15.Value = My.Settings.UserName
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@pinvoice_id", SqlDbType.Int)

            If m_PInvoiceId = 0 Then
                prm16.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_PInvoiceId = prm16.Value
                'MessageBox.Show(m_PInvoiceId)
                cn.Close()
                If isGetNum = True Then UpdSysNumber("pinv")
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
            prm5.Value = FormatNumber(txtPInvoiceTotal.Text)
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm6.Value = My.Settings.UserName

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

            If m_LocationId = 0 And txtPInvoiceDtlDesc.Text = "" Then
                MsgBox("Location and Line Description are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtPInvoiceDtlDesc.Focus()
                Exit Sub
            End If

            If (cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "S" Or cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "E") And m_SKUId = 0 Then
                MsgBox("Please select Stock or Expense before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtPInvoiceDtlDesc.Focus()
                Exit Sub
            End If

            AppLock.GetLock()

            cmd = New SqlCommand(IIf(m_PInvoiceDId = 0, "usp_tr_pinvoice_dtl_INS", "usp_tr_pinvoice_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@pinvoice_id", SqlDbType.Int)
            prm1.Value = m_PInvoiceId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@pinvoice_dtl_type", SqlDbType.NVarChar, 50)
            prm2.Value = cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@preceive_dtl_id", SqlDbType.Int)
            prm3.Value = m_PReceiveDId
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
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)
            prm12.Value = m_POID
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@pinvoice_curr_rate", SqlDbType.Money)
            prm13.Value = ntbPInvCurrRate.Text

            If m_PInvoiceDId <> 0 Then
                Dim prm24 As SqlParameter = cmd.Parameters.Add("@pinvoice_dtl_id", SqlDbType.Int)
                prm24.Value = m_PInvoiceDId
            End If

            '20161025 - Dikman, Error pinvoice_dtl_tax2
            Dim prm25 As SqlParameter = cmd.Parameters.Add("@pinvoice_dtl_tax2", SqlDbType.Decimal)
            prm25.Value = txtPInvoiceTaxAmt.Text

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

            AppLock.GetLock()

            If txtPInvoiceNo.Text.Trim = "" Then
                txtPInvoiceNo.Text = GetSysNumber("pinv", Now.Date)
                isGetNum = True
            Else
                isGetNum = False
            End If

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
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@pinvoice_terms", SqlDbType.Int, 50)
            prm7.Value = ntbPInvoiceTerms.Text
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@pinvoice_duedate", SqlDbType.SmallDateTime)
            prm8.Value = dtpPInvoiceDueDate.Value.Date
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
            prm9.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@pinvoice_remarks", SqlDbType.NVarChar)
            prm10.Value = IIf(txtPInvoiceRemarks.Text = "", DBNull.Value, txtPInvoiceRemarks.Text)
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm11.Value = m_CurrId
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@pinvoice_curr_rate", SqlDbType.Money)
            prm12.Value = FormatNumber(ntbPInvCurrRate.Text)
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm15.Value = My.Settings.UserName
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@pinvoice_id", SqlDbType.Int)
            prm16.Direction = ParameterDirection.Output

            cn.Open()
            cmd.ExecuteReader()
            m_PInvoiceId = prm16.Value
            cn.Close()

            If isGetNum = True Then UpdSysNumber("pinv")
            txtPInvoiceNo.ReadOnly = True
            ntbPInvCurrRate.ReadOnly = True

            If m_POID > 0 Then btnPO.Enabled = False
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

            cmd = New SqlCommand("usp_tr_pinvoice_dtl_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@pinvoice_dtl_id", SqlDbType.Int)
            prm1.Value = m_PInvoiceDId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
            prm2.Value = m_SKUId
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@pinvoice_dtl_net", SqlDbType.Money)
            prm3.Value = m_PInvoiceNetAmt
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@pinvoice_curr_rate", SqlDbType.Money)
            prm4.Value = ntbPInvCurrRate.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
            prm5.Value = m_SId
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@preceive_id", SqlDbType.Int)
            prm6.Value = m_PReceiveId
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)
            prm7.Value = m_POID

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            AppLock.ReleaseLock()

            clear_lvw()
            clear_objD()
            refresh_total()
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        cmbPODtlType.Enabled = False
        With ListView1.SelectedItems.Item(0)
            m_PInvoiceDId = LeftSplitUF(.Tag)
            m_PReceiveDId = IIf(.SubItems.Item(0).Text = "", 0, .SubItems.Item(0).Text)
            m_PODtlType = .SubItems.Item(1).Text
            Dim mList As clsMyListStr
            Dim i As Integer
            For i = 1 To cmbPODtlType.Items.Count + 1
                mList = cmbPODtlType.Items(i - 1)
                If m_PODtlType = mList.ItemData Then
                    cmbPODtlType.SelectedIndex = i - 1
                    Exit For
                End If
            Next
            m_PReceiveId = IIf(.SubItems.Item(3).Text = "", 0, .SubItems.Item(3).Text)
            txtPReceiveNo.Text = IIf(.SubItems.Item(4).Text = "", "", .SubItems.Item(4).Text)
            m_SKUId = .SubItems.Item(5).Text
            txtSKUCode.Text = .SubItems.Item(6).Text
            txtPInvoiceDtlDesc.Text = .SubItems.Item(7).Text
            m_LocationId = IIf(.SubItems.Item(8).Text = "", 0, .SubItems.Item(8).Text)
            txtLocationCode.Text = IIf(.SubItems.Item(9).Text = "", "", .SubItems.Item(9).Text)
            ntbPInvoiceQty.Text = .SubItems.Item(10).Text
            txtSKUUoM.Text = .SubItems.Item(11).Text
            ntbPInvoicePrice.Text = FormatNumber(.SubItems.Item(12).Text, Dec)
            txtPInvoiceGrossAmt.Text = FormatNumber(.SubItems.Item(13).Text)
            ntbPInvoiceTaxPercent.Text = .SubItems.Item(14).Text
            txtPInvoiceTaxAmt.Text = FormatNumber(.SubItems.Item(15).Text)
            txtPInvoiceNetAmt.Text = FormatNumber(.SubItems.Item(16).Text)
            m_PInvoiceNetAmt = CDbl(.SubItems.Item(17).Text)
        End With
    End Sub

    Private Sub cmbPODtlType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPODtlType.SelectedIndexChanged
        If Not btnAddD.Enabled = True Then Exit Sub
        Select Case cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData
            Case "S"
                If Not btnCancel.Enabled = False Then
                    btnSKU.Enabled = False
                    txtPInvoiceDtlDesc.ReadOnly = True
                    ntbPInvoiceQty.ReadOnly = True
                    ntbPInvoicePrice.ReadOnly = True
                    ntbPInvoiceTaxPercent.ReadOnly = True
                End If

            Case "E"
                If Not btnCancel.Enabled = False Then
                    'txtSKUCode.ReadOnly = False
                    btnSKU.Enabled = True
                    txtPInvoiceDtlDesc.ReadOnly = False
                    ntbPInvoiceQty.ReadOnly = True
                    ntbPInvoicePrice.ReadOnly = False
                    ntbPInvoiceTaxPercent.ReadOnly = False
                    ntbPInvoiceQty.Text = FormatNumber(1)
                    ntbPInvoiceTaxPercent.Text = FormatNumber(m_PInvoiceTaxPercent, 0)
                End If

            Case "T"
                'txtSKUCode.ReadOnly = True
                m_SKUId = 0
                txtSKUCode.Text = ""
                btnSKU.Enabled = False
                ntbPInvoiceQty.ReadOnly = True
                ntbPInvoiceQty.Text = IIf(cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "E", "1.00", "0.00")
                ntbPInvoicePrice.ReadOnly = IIf(cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "T", True, False)
                ntbPInvoiceTaxPercent.ReadOnly = IIf(cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "T", True, False)
                ntbPInvoiceTaxPercent.Text = IIf(cmbPODtlType.Items(cmbPODtlType.SelectedIndex).ItemData = "T", "0", FormatNumber(m_PInvoiceTaxPercent, 0))

            Case "P" 'Production Process
                If Not btnCancel.Enabled = False Then
                    btnSKU.Enabled = False
                    txtPInvoiceDtlDesc.ReadOnly = True
                    ntbPInvoiceQty.ReadOnly = True
                    ntbPInvoicePrice.ReadOnly = True
                    ntbPInvoiceTaxPercent.ReadOnly = True
                End If

        End Select
    End Sub

    Private Sub ntbPInvoicePrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPInvoicePrice.LostFocus
        refresh_totalD()
        ntbPInvoicePrice.Text = FormatNumber(ntbPInvoicePrice.Text, Dec)
    End Sub

    Private Sub ntbPInvoiceTaxPercent_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPInvoiceTaxPercent.LostFocus
        'ntbPOTax.Text = FormatPercent(CSng(ntbPOTax.Text.Replace("%", "")) / 100, 0)
        refresh_totalD()
        ntbPInvoiceTaxPercent.Text = FormatNumber(ntbPInvoiceTaxPercent.Text, 0)
    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        clear_objD()
        cmbPODtlType.Enabled = True
    End Sub

    Private Sub ntbPInvoiceQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPInvoiceQty.LostFocus
        If ntbPInvoiceQty.Text = "" Then ntbPInvoiceQty.Text = FormatNumber(1)
        If ntbPInvoiceQty.DecimalValue = 0 Then ntbPInvoiceQty.Text = FormatNumber(1)
        refresh_totalD()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Pch_Invoice_Form '" & txtPInvoiceNo.Text & "'"
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "PO_Invoice")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Pch_Invoice_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Purchase Invoice"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("PO_Invoice"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub btnPReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPReceive.Click
        If m_SId = 0 Or m_PchCodeId = 0 Then
            MsgBox("Purchase Code & Supplier information are primary fields that should be entered. Please enter those fields before you do the selection.", vbCritical + vbOKOnly, Me.Text)
            txtSCode.Focus()
            Exit Sub
        End If

        If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
            MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If

        Dim NewFormDialog As New fdlPReceiveOut
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim NewFormDialog As New fdlLocation
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPO.Click
        Dim NewFormDialog As New fdlPOOut
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.SName = txtSName.Text
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
        'If ntbPInvCurrRate.Text = "" Then ntbPInvCurrRate.Text = FormatNumber(1)
    End Sub

    Private Sub btnPchCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPchCode.Click
        Dim NewFormDialog As New fdlPchCode
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub ntbPInvCurrRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbPInvCurrRate.TextChanged

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

    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmPInvoiceList).Any Then
            Call frmPInvoiceList.frmPInvoiceListShow(Nothing, EventArgs.Empty)
        End If
    End Sub

    Private Sub btnWorkOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWorkOrder.Click
        'If m_SId = 0 Or m_PchCodeId = 0 Then
        '    MsgBox("Purchase Code & Supplier information are primary fields that should be entered. Please enter those fields before you do the selection.", vbCritical + vbOKOnly, Me.Text)
        '    txtSCode.Focus()
        '    Exit Sub
        'End If

        If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
            MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If

        Dim NewFormDialog As New fdlWOConfirmIn
        NewFormDialog.ShowDialog()
    End Sub
End Class
