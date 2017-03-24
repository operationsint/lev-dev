Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmSO
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_SOId As Integer
    Dim m_CId As Integer
    Dim m_SOType As String
    Dim m_SOStatus As String
    Dim m_SOStatusArr(4, 1) As String
    Dim m_SODId As Integer
    Dim m_SODtlType As String
    Dim m_SKUId As Integer
    Dim isSKUPackage As Boolean
    Dim m_SOTaxPercent As Single
    Dim m_LocationId As Integer
    Dim m_SOQtyBefore As Integer
    Dim m_SumSDeliveryQty As Integer
    Dim m_SlsCodeId As Integer
    Dim m_CurrId As Integer
    Dim m_CurrBaseId As Integer
    Dim m_SOCurrRateBefore As Double
    Dim isGetNum As Boolean
    Dim isAllowDelete As Boolean
    Private docSO As ReportDocument
    Dim Dec As Integer = GetSysInit("decimal_digit")
    Dim SO_Edit_Price As Integer = GetSysInit("so_edit_price")
    Dim tempSave As Boolean = False
    Dim SO_Tier_Disc As Boolean = CBool(GetSysInit("so_tier_disc"))

    ' 20160505 daniel s : 0 = percent 1=amount
    Dim SO_Disc_Mode As Integer = 0


    Private Sub frmSO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolTip1.SetToolTip(btnCustomer, "Search Customer")
        ToolTip1.SetToolTip(btnSKU, "Search Stock")
        ToolTip1.SetToolTip(btnSaveD, "Save Line")
        ToolTip1.SetToolTip(btnDeleteD, "Delete Line")

        m_SOTaxPercent = GetSysInit("tax_percent") * 100

        isAllowDelete = canDelete(Me.Name + "List")

        Dim prm1 As SqlParameter
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

        'Add item cmbSOType
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "so_type"

        cn.Open()
        myReader = cmd.ExecuteReader

        cmbSOType.Items.Clear()
        While myReader.Read
            cmbSOType.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While
        cmbSOType.SelectedIndex = 0

        myReader.Close()
        cn.Close()

        'Add item cmbSOStatus
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "so_status"

        cn.Open()
        myReader = cmd.ExecuteReader
        Dim i As Integer = 0

        While myReader.Read
            m_SOStatusArr(i, 0) = myReader.GetString(0)
            m_SOStatusArr(i, 1) = myReader.GetString(1)
            i += 1
        End While

        myReader.Close()
        cn.Close()

        'Add item cmbSODtlType
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

        If m_SOId = 0 Then
            btnAdd_Click(sender, e)
        Else
            m_SODId = 0
            view_record()
            clear_lvw()
            'btnEdit_Click(sender, e)
            clear_objD()
            lock_obj(True)
            lock_objD(True)
        End If
    End Sub

    Private Sub btnCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomer.Click
        Dim NewFormDialog As New fdlCustomer
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Public Property SOId() As Integer
        Get
            Return m_SOId
        End Get
        Set(ByVal Value As Integer)
            m_SOId = Value
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

    Public Property CContact() As String
        Get
            Return txtCContact.Text
        End Get
        Set(ByVal Value As String)
            txtCContact.Text = Value
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
            Return ntbSOCurrRate.Text
        End Get
        Set(ByVal Value As String)
            ntbSOCurrRate.Text = Value
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
            Return txtSODtlDesc.Text
        End Get
        Set(ByVal Value As String)
            txtSODtlDesc.Text = Value
        End Set
    End Property

    Public Property SKUPackageCheck() As Boolean
        Get
            Return isSKUPackage
        End Get
        Set(ByVal Value As Boolean)
            isSKUPackage = Value
        End Set
    End Property

    Public Property PaymentTerms() As Integer
        Get
            Return ntbPaymentTerms.Text
        End Get
        Set(ByVal Value As Integer)
            ntbPaymentTerms.Text = Value
        End Set
    End Property

    Public Property SalesPrice() As String
        Get
            Return ntbSOPrice.Text
        End Get
        Set(ByVal Value As String)
            ntbSOPrice.Text = Value
        End Set
    End Property

    Public Property SalesDiscount() As String
        Get
            Return ntbSODiscPercent.Text
        End Get
        Set(ByVal Value As String)
            ntbSODiscPercent.Text = Value
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

    Private Sub btnSKU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSKU.Click
        If m_CId = 0 Or m_SlsCodeId = 0 Then
            MsgBox("Sales Code & Customer information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtCCode.Focus()
            Exit Sub
        End If
        Select Case cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData
            Case "S"
                Dim NewFormDialog As New fdlSKUSO
                NewFormDialog.FrmCallerId = Me.Name
                NewFormDialog.ShowDialog()
            Case "I"
                Dim NewFormDialog As New fdlIncome
                NewFormDialog.fdlIncomeMode = 0 'Search for Income Code Only
                NewFormDialog.FrmCallerId = Me.Name
                NewFormDialog.ShowDialog()
        End Select
    End Sub

    Sub clear_obj()
        m_SOId = 0
        m_CId = 0
        m_SlsCodeId = 0
        m_SOCurrRateBefore = 0
        txtSONo.Text = ""
        dtpSODate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        dtpDeliveryDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtCCode.Text = ""
        txtCName.Text = ""
        txtCContact.Text = ""
        txtSlsCode.Text = ""
        txtCurrCode.Text = ""
        ntbSOCurrRate.Text = FormatNumber(1)
        txtRefNo.Text = ""
        txtSInvoiceNo.Text = ""
        txtSORemarks.Text = ""
        ntbPaymentTerms.Text = 0
        cmbSOType.SelectedIndex = 0
        m_SOStatus = m_SOStatusArr(0, 0)
        txtSOStatus.Text = m_SOStatusArr(0, 1)
        txtSOGross.Text = FormatNumber(0)
        txtSODiscount.Text = FormatNumber(0)
        txtSOSubtotal.Text = FormatNumber(0)
        txtSOTax.Text = FormatNumber(0)
        txtSOTotal.Text = FormatNumber(0)
        txtLocalSOSubTotal.Text = FormatNumber(0)
        txtLocalSOTax.Text = FormatNumber(0)
        txtLocalSOTotal.Text = FormatNumber(0)
        lblClosedDescription.Visible = False
        isGetNum = True
    End Sub

    Sub clear_objD()
        m_SODId = 0
        m_LocationId = 0
        m_SOQtyBefore = 0
        m_SumSDeliveryQty = 0
        isSKUPackage = False
        cmbSODtlType.SelectedIndex = 0
        txtSKUCode.Text = ""
        txtSODtlDesc.Text = ""
        ntbSOQty.Text = FormatNumber(1)
        ntbSOPrice.Text = FormatNumber(0)
        ntbSOPriceIncludeTax.Text = FormatNumber(0)
        txtSOGrossAmt.Text = FormatNumber(0)
        ntbSODiscPercent.Text = FormatNumber(0, 2)
        ntbSODiscPercent2.Text = FormatNumber(0, 2)
        ntbSODiscAmt.Text = FormatNumber(0)
        txtSOGrossAfterDiscAmt.Text = FormatNumber(0)
        ntbSOTaxPercent.Text = FormatNumber(m_SOTaxPercent, 0)
        txtSOTaxAmt.Text = FormatNumber(0, 2)
        txtSONetAmt.Text = FormatNumber(0)
        txtLocationCode.Text = ""
        txtLotJobNo.Text = ""
        dtpRequiredDeliveryDate.Checked = False
        dtpRequiredDeliveryDate.Value = dtpDeliveryDate.Value

    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        dtpSODate.Enabled = Not isLock
        txtRefNo.ReadOnly = isLock
        ntbPaymentTerms.ReadOnly = isLock
        txtSORemarks.ReadOnly = isLock
        cmbSOType.Enabled = Not isLock
        btnCustomer.Enabled = Not isLock
        txtCContact.ReadOnly = isLock
        dtpDeliveryDate.Enabled = Not isLock
        ntbSOCurrRate.ReadOnly = isLock

        If m_SOStatus = "FD" Or m_SOStatus = "I" Or m_SOStatus = "P" Then btnEdit.Enabled = False Else btnEdit.Enabled = isLock
        If m_SOStatus = "PD" Then
            btnCloseSO.Enabled = Not isLock
            btnCustomer.Enabled = False
            btnSlsCode.Enabled = False
        Else
            btnCloseSO.Enabled = False
        End If
        If m_SOStatus = "O" And txtSInvoiceNo.Text = "" Then btnInvoiceNo.Enabled = Not isLock Else btnInvoiceNo.Enabled = False

        btnSlsCode.Enabled = Not isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnPrint.Enabled = isLock
        btnPrintSInv.Enabled = isLock

        If m_SOId = 0 Then
            txtSONo.ReadOnly = False
            btnDelete.Enabled = isLock
        Else
            txtSONo.ReadOnly = True
            If m_SOStatus = "O" And ListView1.Items.Count = 0 Then
                btnCustomer.Enabled = Not isLock
            Else
                btnCustomer.Enabled = False
            End If
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        If SO_Tier_Disc = True Then
            ntbSODiscPercent2.ReadOnly = False
            ntbSODiscAmt.ReadOnly = True
        Else
            ntbSODiscPercent2.ReadOnly = True
            ntbSODiscAmt.ReadOnly = False
        End If

        cmbSODtlType.Enabled = Not isLock
        txtSODtlDesc.ReadOnly = isLock
        ntbSOQty.ReadOnly = isLock
        ntbSOPrice.ReadOnly = isLock
        ntbSODiscPercent.ReadOnly = isLock
        ntbSODiscAmt.ReadOnly = isLock
        ntbSOTaxPercent.ReadOnly = isLock
        txtSKUBarcode.ReadOnly = isLock
        txtLotJobNo.ReadOnly = isLock
        dtpRequiredDeliveryDate.Enabled = Not isLock
        dtpRequiredDeliveryDate.Checked = isLock
        btnLocation.Enabled = Not isLock
        btnSKU.Enabled = Not isLock
        btnSaveD.Enabled = Not isLock
        btnDeleteD.Enabled = Not isLock
        btnAddD.Enabled = Not isLock

        '20160823 price include tax
        cbIncludeTax.Enabled = Not isLock
        ntbSOPriceIncludeTax.ReadOnly = isLock

        If cbIncludeTax.Enabled = True Then
            If cbIncludeTax.Checked = True Then
                ntbSOPrice.ReadOnly = True
                ntbSOPriceIncludeTax.ReadOnly = False
                ntbSODiscAmt.Enabled = False
                ntbSODiscPercent.Enabled = False
                ntbSODiscPercent2.Enabled = False
            Else
                ntbSOPrice.ReadOnly = False
                ntbSOPriceIncludeTax.ReadOnly = True
                ntbSODiscPercent.Enabled = True
                ntbSODiscPercent2.Enabled = True
                ntbSODiscAmt.Enabled = True
            End If
        End If



    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("so_id", 0)
            .Columns.Add("so_dtl_type", 0)
            .Columns.Add("Line Type", 70)
            .Columns.Add("SKU Id", 0)
            .Columns.Add("Code", 80)
            .Columns.Add("Line Description", 220)
            .Columns.Add("location_id", 0)
            .Columns.Add("Location", 80)
            .Columns.Add("Qty", 50, HorizontalAlignment.Right)
            .Columns.Add("UoM", 50)
            .Columns.Add("avg_cost", 0, HorizontalAlignment.Right)
            .Columns.Add("Unit Price", 90, HorizontalAlignment.Right)
            .Columns.Add("Gross Amount", 100, HorizontalAlignment.Right)
            .Columns.Add("Disc. %", 60, HorizontalAlignment.Right)
            .Columns.Add("Disc. Amount", 90, HorizontalAlignment.Right)
            .Columns.Add("Gross After Disc.", 100, HorizontalAlignment.Right)
            .Columns.Add("Tax %", 50, HorizontalAlignment.Right)
            .Columns.Add("Tax Amount", 90, HorizontalAlignment.Right)
            .Columns.Add("Net Amount", 120, HorizontalAlignment.Right)
            .Columns.Add("sum_sdelivery_qty", 0, HorizontalAlignment.Right)
            .Columns.Add("Lot Job No.", 80)
            .Columns.Add("Required Delivery Date", 120)
            .Columns.Add("Editable Price", 80)
            .Columns.Add("Tier Disc", 0, HorizontalAlignment.Right)
        End With

        If m_SOId <> 0 Then
            cmd = New SqlCommand("usp_tr_so_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
            prm1.Value = m_SOId

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(1))) 'so_id
                lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                For i = 2 To 3 'so_dtl_type, line_type
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next
                Select Case myReader.GetString(2) 'sku_id, sku_code
                    Case "S"
                        lvItem.SubItems.Add(myReader.GetInt32(4))
                        lvItem.SubItems.Add(myReader.GetString(5))
                    Case "I"
                        lvItem.SubItems.Add(myReader.GetInt32(20))
                        lvItem.SubItems.Add(myReader.GetString(21))
                    Case Else
                        lvItem.SubItems.Add("0")
                        lvItem.SubItems.Add("")
                End Select
                lvItem.SubItems.Add(myReader.GetString(6)) 'so_dtl_desc
                For i = 7 To 8 'location_id, location_code
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next
                lvItem.SubItems.Add(myReader.GetValue(9)) 'so_qty
                If myReader.Item(10) Is System.DBNull.Value Then 'sku_uom
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(10))
                End If
                lvItem.SubItems.Add(FormatNumber(myReader.Item(11)))
                lvItem.SubItems.Add(FormatNumber(myReader.Item(12), Dec))
                For i = 13 To 19

                    If i = 14 Or i = 17 Then
                        '20160505 daniel s : percent show 2 digit point
                        'lvItem.SubItems.Add(FormatNumber(myReader.Item(i), 0))
                        lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
                    Else
                        lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
                    End If

                Next
                lvItem.SubItems.Add(myReader.GetValue(23)) 'sum_sdelivery_qty
                For i = 24 To 25
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next
                lvItem.SubItems.Add(myReader.Item(26))
                lvItem.SubItems.Add(myReader.Item(27))

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
        cmd = New SqlCommand("usp_tr_so_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
        prm1.Value = m_SOId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtSONo.Text = myReader.GetString(1)
            dtpSODate.Value = myReader.GetDateTime(2)
            m_CId = myReader.GetInt32(3)
            txtCCode.Text = myReader.GetString(4)
            txtCName.Text = myReader.GetString(5)
            m_SOType = myReader.GetString(6)
            m_SOStatus = myReader.GetString(7)
            If Not myReader.IsDBNull(myReader.GetOrdinal("c_contact")) Then
                txtCContact.Text = myReader.GetString(myReader.GetOrdinal("c_contact"))
            Else
                txtCContact.Text = ""
            End If
            dtpDeliveryDate.Value = myReader.GetDateTime(10)
            If Not myReader.IsDBNull(myReader.GetOrdinal("ref_no")) Then
                txtRefNo.Text = myReader.GetString(myReader.GetOrdinal("ref_no"))
            Else
                txtRefNo.Text = ""
            End If
            ntbPaymentTerms.Text = myReader.GetInt32(12)
            If Not myReader.IsDBNull(myReader.GetOrdinal("so_remarks")) Then
                txtSORemarks.Text = myReader.GetString(myReader.GetOrdinal("so_remarks"))
            Else
                txtSORemarks.Text = ""
            End If
            m_SlsCodeId = myReader.GetInt32(14)
            txtSlsCode.Text = myReader.GetString(15)
            m_CurrId = myReader.GetInt32(16)
            txtCurrCode.Text = myReader.GetString(17)
            ntbSOCurrRate.Text = FormatNumber(myReader.GetValue(18))
            m_SOCurrRateBefore = myReader.GetValue(18)
            txtSOGross.Text = FormatNumber(myReader.GetValue(19))
            txtSODiscount.Text = FormatNumber(myReader.GetValue(20))
            txtSOSubtotal.Text = FormatNumber(myReader.GetValue(21))
            txtSOTax.Text = FormatNumber(myReader.GetValue(22))
            txtSOTotal.Text = FormatNumber(myReader.GetValue(23))
            txtLocalSOSubTotal.Text = FormatNumber(myReader.GetValue(25))
            txtLocalSOTax.Text = FormatNumber(myReader.GetValue(26))
            txtLocalSOTotal.Text = FormatNumber(myReader.GetValue(27))
            If myReader.GetBoolean(28) = True Then
                lblClosedDescription.Text = lblClosedDescription.Text & " " & myReader.GetString(31) & " on " & myReader.GetDateTime(30)
                lblClosedDescription.Visible = True
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("sinvoice_no_ref")) Then
                txtSInvoiceNo.Text = myReader.GetString(myReader.GetOrdinal("sinvoice_no_ref"))
            Else
                txtSInvoiceNo.Text = ""
            End If
        End While

        myReader.Close()
        cn.Close()

        Dim mList As clsMyListStr
        Dim i As Integer
        For i = 1 To cmbSOType.Items.Count
            mList = cmbSOType.Items(i - 1)
            If m_SOType = mList.ItemData Then
                cmbSOType.SelectedIndex = i - 1
                Exit For
            End If
        Next

        For i = 0 To m_SOStatusArr.GetUpperBound(0)
            If m_SOStatus = m_SOStatusArr(i, 0) Then
                txtSOStatus.Text = m_SOStatusArr(i, 1)
                Exit For
            End If
        Next
    End Sub

    Sub refresh_total()
        cmd = New SqlCommand("usp_tr_so_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
        prm1.Value = m_SOId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtSOGross.Text = FormatNumber(myReader.GetValue(19))
            txtSODiscount.Text = FormatNumber(myReader.GetValue(20))
            txtSOSubtotal.Text = FormatNumber(myReader.GetValue(21))
            txtSOTax.Text = FormatNumber(myReader.GetValue(22))
            txtSOTotal.Text = FormatNumber(myReader.GetValue(23))
            txtLocalSOSubTotal.Text = FormatNumber(myReader.GetValue(25))
            txtLocalSOTax.Text = FormatNumber(myReader.GetValue(26))
            txtLocalSOTotal.Text = FormatNumber(myReader.GetValue(27))
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Sub refresh_totalD()
        txtSOGrossAmt.Text = FormatNumber(CDbl(ntbSOQty.Text) * CDbl(ntbSOPrice.Text))

        txtSOGrossAfterDiscAmt.Text = FormatNumber(CDbl(txtSOGrossAmt.Text) + CDbl(ntbSODiscAmt.Text))

        ' 20160505 daniel s : use disc amt 
        If SO_Disc_Mode = 1 Then
            txtSOGrossAfterDiscAmt.Text = FormatNumber(CDbl(txtSOGrossAmt.Text) + CDbl(ntbSODiscAmt.Text))
        End If

        txtSOTaxAmt.Text = FormatNumber(CDbl(txtSOGrossAfterDiscAmt.Text) * CDbl(ntbSOTaxPercent.Text) / 100)
        txtSONetAmt.Text = FormatNumber(CDbl(txtSOGrossAfterDiscAmt.Text) + CDbl(txtSOTaxAmt.Text))

        '20160823 price include tax
        If cbIncludeTax.Checked = False Then
            txtSONetAmt.Text = FormatNumber(CDbl(txtSOGrossAfterDiscAmt.Text) + CDbl(txtSOTaxAmt.Text))
        Else
            ntbSODiscAmt.Text = "0"
            ntbSODiscPercent.Text = "0"
            ntbSODiscPercent2.Text = "0"
            txtSONetAmt.Text = FormatNumber(CDbl(ntbSOPriceIncludeTax.Text) * CDbl(ntbSOQty.Text))
        End If


    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_SOId = 0
        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_SOId = 0 Then
            Me.Close()
        Else
            lock_obj(True)
            lock_objD(True)
            clear_objD()
            m_SODId = 0
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If m_CId = 0 Or m_SlsCodeId = 0 Then
                MsgBox("Sales Code, Customer Code and Customer Name are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtCCode.Focus()
                Exit Sub
            End If

            If tempSave = False Then
                If CDbl(txtSOTotal.Text) = 0 Then
                    MsgBox("Warning,Sales Order total is 0 !", vbInformation, Me.Text)
                End If
                tempSave = False
            End If

            AppLock.GetLock()

            If m_SOId = 0 Then
                If txtSONo.Text.Trim = "" Then
                    txtSONo.Text = GetSysNumber("sord", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If
            End If

            cmd = New SqlCommand(IIf(m_SOId = 0, "usp_tr_so_INS", "usp_tr_so_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtSONo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@so_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpSODate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm3.Value = m_CId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm4.Value = m_CurrId
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@so_curr_rate", SqlDbType.Money)
            prm6.Value = FormatNumber(ntbSOCurrRate.Text)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@so_type", SqlDbType.NVarChar, 50)
            prm7.Value = cmbSOType.Items(cmbSOType.SelectedIndex).ItemData
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@sls_code_id", SqlDbType.Int)
            prm8.Value = m_SlsCodeId
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@c_contact", SqlDbType.NVarChar, 50)
            prm9.Value = IIf(txtCContact.Text = "", DBNull.Value, txtCContact.Text)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@delivery_date", SqlDbType.DateTime)
            prm10.Value = dtpDeliveryDate.Value
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
            prm11.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@payment_terms", SqlDbType.Int, 50)
            prm12.Value = IIf(ntbPaymentTerms.Text = "", 0, ntbPaymentTerms.Text)
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@so_remarks", SqlDbType.NVarChar, 255)
            prm13.Value = IIf(txtSORemarks.Text = "", DBNull.Value, txtSORemarks.Text)
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@sinvoice_no_ref", SqlDbType.NVarChar, 255)
            prm14.Value = IIf(txtSInvoiceNo.Text = "", DBNull.Value, txtSInvoiceNo.Text)
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm15.Value = My.Settings.UserName
            Dim prm17 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)

            If m_SOId = 0 Then
                prm17.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_SOId = prm17.Value
                'MessageBox.Show(m_SOId)
                cn.Close()
                If isGetNum = True Then UpdSysNumber("sord")
            Else
                prm17.Value = m_SOId
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                'clear_lvw()
                If CDbl(ntbSOCurrRate.Text) <> m_SOCurrRateBefore Then refresh_total()
            End If

            lock_obj(True)
            lock_objD(True)
            m_SOCurrRateBefore = CDbl(ntbSOCurrRate.Text)

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
        If m_SOStatus = "FD" Then
            btnSave.Enabled = False
            btnDelete.Enabled = False
            lock_objD(True)
        ElseIf m_SOStatus = "PD" Then
            lock_objD(True)
            ntbSOQty.ReadOnly = False
            btnSaveD.Enabled = True
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If txtSInvoiceNo.Text <> "" Then
            MsgBox("You can't delete this record because this SO has Invoice booked already.", vbOKOnly + vbExclamation, Me.Text)
            Exit Sub
        End If
        If m_SOStatus = "O" Then
            If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then

                AppLock.GetLock()

                cmd = New SqlCommand("usp_tr_so_DEL", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
                prm1.Value = m_SOId
                Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                prm2.Value = My.Settings.UserName

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()

                AppLock.ReleaseLock()

                btnAdd_Click(sender, e)
            End If
        Else
            MsgBox("You can't delete this transaction record", vbCritical, Me.Text)
        End If
        autoRefresh()
    End Sub

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        Try

            '20160728 protect net amt >= 0
            If txtSONetAmt.Text.Length > 0 Then
                Dim net_amt As Double = CDbl(txtSONetAmt.Text)
                If net_amt < 0 Then
                    MsgBox("Error : Net Amount < 0 !", vbCritical + vbOKOnly, Me.Text)
                    Exit Sub
                End If
            End If


            If m_SOId = 0 Then
                If m_CId = 0 Or m_SlsCodeId = 0 Then
                    MsgBox("Sales Code, Customer Code and Customer Name are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                    txtCCode.Focus()
                    Exit Sub
                End If
                SaveSOHeader()
            End If
            If txtSODtlDesc.Text = "" Then
                MsgBox("Line Description are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtSODtlDesc.Focus()
                Exit Sub
            End If

            If cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S" And (m_SKUId = 0 Or m_LocationId = 0) Then
                MsgBox("Stock and Location are primary fields that should be entered. Please select before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtSODtlDesc.Focus()
                Exit Sub
            End If

            AppLock.GetLock()

            cmd = New SqlCommand(IIf(m_SODId = 0, "usp_tr_so_dtl_INS", "usp_tr_so_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm12 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
            prm12.Value = m_SOId
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@so_dtl_type", SqlDbType.NVarChar, 50)
            prm13.Value = cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
            prm14.Value = IIf(cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "S", m_SKUId, 0)
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@so_dtl_desc", SqlDbType.NVarChar, 255)
            prm15.Value = IIf(txtSODtlDesc.Text = "", DBNull.Value, txtSODtlDesc.Text)
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@so_qty", SqlDbType.Decimal)
            prm16.Value = IIf(ntbSOQty.Text = "", 1, CDbl(ntbSOQty.Text))
            Dim prm17 As SqlParameter = cmd.Parameters.Add("@so_price", SqlDbType.Decimal)
            prm17.Value = FormatNumber(ntbSOPrice.Text, Dec)
            Dim prm18 As SqlParameter = cmd.Parameters.Add("@so_dtl_discpercent", SqlDbType.Money)
            '20160505 daniel s : dont divide by 100
            prm18.Value = CDbl(ntbSODiscPercent.Text) / 100
            'prm18.Value = CDbl(ntbSODiscPercent.Text)

            Dim prm19 As SqlParameter = cmd.Parameters.Add("@tax_percent", SqlDbType.Decimal)
            prm19.Value = CDbl(ntbSOTaxPercent.Text) / 100
            Dim prm20 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int)
            prm20.Value = m_LocationId
            Dim prm21 As SqlParameter = cmd.Parameters.Add("@income_id", SqlDbType.Int)
            prm21.Value = IIf(cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "I", m_SKUId, 0)
            Dim prm22 As SqlParameter = cmd.Parameters.Add("@lot_job_no", SqlDbType.NVarChar, 50)
            prm22.Value = IIf(txtLotJobNo.Text = "", System.DBNull.Value, txtLotJobNo.Text)
            Dim prm23 As SqlParameter = cmd.Parameters.Add("@required_delivery_date", SqlDbType.SmallDateTime)
            prm23.Value = IIf(dtpRequiredDeliveryDate.Checked = False, System.DBNull.Value, dtpRequiredDeliveryDate.Value)
            Dim prm24 As SqlParameter = cmd.Parameters.Add("@is_package", SqlDbType.Bit)
            prm24.Value = isSKUPackage

            If m_SODId <> 0 Then
                Dim prm25 As SqlParameter = cmd.Parameters.Add("@so_dtl_id", SqlDbType.Int)
                prm25.Value = m_SODId
            End If

            ' 20160505 daniel s : use disc amount
            Dim prm26 As SqlParameter = cmd.Parameters.Add("@so_dtl_discamount2", SqlDbType.Money)
            prm26.Value = CDbl(ntbSODiscAmt.Text)

            '20160827 : use tax amount
            Dim prm27 As SqlParameter = cmd.Parameters.Add("@so_dtl_tax2", SqlDbType.Money)
            prm27.Value = CDbl(txtSOTaxAmt.Text)

            '20170323 : disc tier
            Dim prm28 As SqlParameter = cmd.Parameters.Add("@so_dtl_tierdiscpercent", SqlDbType.Decimal)
            prm28.Value = CDbl(ntbSODiscPercent2.Text) / 100

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
        autoRefresh()
    End Sub

    Sub SaveSOHeader()
        Try

            AppLock.GetLock()

            If txtSONo.Text.Trim = "" Then
                txtSONo.Text = GetSysNumber("sord", Now.Date)
                isGetNum = True
            Else
                isGetNum = False
            End If


            cmd = New SqlCommand("usp_tr_so_INS", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtSONo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@so_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpSODate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm3.Value = m_CId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm4.Value = m_CurrId
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@so_curr_rate", SqlDbType.Money)
            prm6.Value = FormatNumber(ntbSOCurrRate.Text)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@so_type", SqlDbType.NVarChar, 50)
            prm7.Value = cmbSOType.Items(cmbSOType.SelectedIndex).ItemData
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@sls_code_id", SqlDbType.Int)
            prm8.Value = m_SlsCodeId
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@c_contact", SqlDbType.NVarChar, 50)
            prm9.Value = IIf(txtCContact.Text = "", DBNull.Value, txtCContact.Text)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@delivery_date", SqlDbType.DateTime)
            prm10.Value = dtpDeliveryDate.Value
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
            prm11.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@payment_terms", SqlDbType.Int, 50)
            prm12.Value = IIf(ntbPaymentTerms.Text = "", 0, ntbPaymentTerms.Text)
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@so_remarks", SqlDbType.NVarChar, 255)
            prm13.Value = IIf(txtSORemarks.Text = "", DBNull.Value, txtSORemarks.Text)
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@sinvoice_no_ref", SqlDbType.NVarChar, 255)
            prm14.Value = IIf(txtSInvoiceNo.Text = "", DBNull.Value, txtSInvoiceNo.Text)
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm15.Value = My.Settings.UserName
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
            prm16.Direction = ParameterDirection.Output

            cn.Open()
            cmd.ExecuteReader()
            m_SOId = prm16.Value

            cn.Close()
            If isGetNum = True Then UpdSysNumber("sord")
            txtSONo.ReadOnly = True
            m_SOCurrRateBefore = CDbl(ntbSOCurrRate.Text)
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
        If m_SODId = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Name) = vbYes Then

            AppLock.GetLock()

            cmd = New SqlCommand("usp_tr_so_dtl_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_dtl_id", SqlDbType.Int, 50)
            prm1.Value = m_SODId

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
        With ListView1.SelectedItems.Item(0)
            m_SODId = LeftSplitUF(.Tag)
            m_SODtlType = .SubItems.Item(1).Text

            Dim mList As clsMyListStr
            Dim i As Integer
            For i = 1 To cmbSODtlType.Items.Count
                mList = cmbSODtlType.Items(i - 1)
                If m_SODtlType = mList.ItemData Then
                    cmbSODtlType.SelectedIndex = i - 1
                    Exit For
                End If
            Next

            m_SKUId = .SubItems.Item(3).Text
            txtSKUCode.Text = .SubItems.Item(4).Text
            txtSODtlDesc.Text = .SubItems.Item(5).Text
            m_LocationId = .SubItems.Item(6).Text
            txtLocationCode.Text = .SubItems.Item(7).Text
            ntbSOQty.Text = .SubItems.Item(8).Text
            m_SOQtyBefore = .SubItems.Item(8).Text
            ntbSOPrice.Text = FormatNumber(.SubItems.Item(11).Text, Dec)
            txtSOGrossAmt.Text = FormatNumber(.SubItems.Item(12).Text)
            ntbSODiscPercent.Text = FormatNumber(.SubItems.Item(13).Text)
            ntbSODiscAmt.Text = FormatNumber(.SubItems.Item(14).Text)
            txtSOGrossAfterDiscAmt.Text = FormatNumber(.SubItems.Item(15).Text)
            ntbSOTaxPercent.Text = FormatNumber(.SubItems.Item(16).Text, 0)
            txtSOTaxAmt.Text = FormatNumber(.SubItems.Item(17).Text)
            txtSONetAmt.Text = FormatNumber(.SubItems.Item(18).Text)
            m_SumSDeliveryQty = .SubItems.Item(19).Text
            txtLotJobNo.Text = .SubItems.Item(20).Text
            If .SubItems.Item(21).Text = "" Then dtpRequiredDeliveryDate.Checked = False Else dtpRequiredDeliveryDate.Checked = True
            dtpRequiredDeliveryDate.Value = IIf(.SubItems.Item(21).Text = "", FormatDateTime(Now, DateFormat.ShortDate), .SubItems.Item(21).Text)
            If SO_Edit_Price = 1 Then
                If .SubItems.Item(22).Text = "Yes" Then
                    ntbSOPrice.ReadOnly = False
                Else
                    ntbSOPrice.ReadOnly = True
                End If
            End If

            If .SubItems.Item(22).Text = "Yes" Then
                dtpRequiredDeliveryDate.Enabled = True
            Else
                dtpRequiredDeliveryDate.Enabled = False
            End If

            ntbSODiscPercent2.Text = FormatNumber(.SubItems.Item(23).Text, 0)

        End With

    End Sub

    Private Sub cmbSODtlType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSODtlType.SelectedIndexChanged
        If Not btnAddD.Enabled = True Then Exit Sub
        Select Case cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData
            Case "T"
                'txtSKUCode.ReadOnly = True
                m_SKUId = 0
                txtSKUCode.Text = ""
                btnSKU.Enabled = False
                ntbSOQty.ReadOnly = True
                ntbSOQty.Text = IIf(cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "I", "1", "0")
                ntbSOPrice.ReadOnly = IIf(cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "T", True, False)
                ntbSODiscPercent.ReadOnly = IIf(cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "T", True, False)
                ntbSODiscAmt.ReadOnly = IIf(cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "T", True, False)
                ntbSOTaxPercent.ReadOnly = IIf(cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "T", True, False)
                ntbSOTaxPercent.Text = IIf(cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "T", "0", FormatNumber(m_SOTaxPercent, 0))
                '20160823 price include tax
                cbIncludeTax.Enabled = False
            Case "S", "I"
                If Not btnCancel.Enabled = False Then
                    'txtSKUCode.ReadOnly = False
                    btnSKU.Enabled = True
                    btnLocation.Enabled = True

                    '20160505 daniel s : enabled qty field for income
                    'If cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "I" Then ntbSOQty.ReadOnly = True Else ntbSOQty.ReadOnly = False

                    ntbSOPrice.ReadOnly = False
                    ntbSOTaxPercent.ReadOnly = False
                    ntbSODiscPercent.ReadOnly = False
                    ntbSODiscAmt.ReadOnly = False
                    ntbSOTaxPercent.ReadOnly = False
                    ntbSOTaxPercent.Text = FormatNumber(m_SOTaxPercent, 0)
                    If cmbSODtlType.Items(cmbSODtlType.SelectedIndex).ItemData = "I" Then ntbSOQty.Text = FormatNumber(1) Else ntbSOQty.Text = FormatNumber(0)

                    '20160823 price include tax
                    cbIncludeTax.Enabled = True
                End If
        End Select
    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        clear_objD()
    End Sub

    Private Sub ntbSOQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSOQty.LostFocus
        If ntbSOQty.Text = "" Then ntbSOQty.Text = FormatNumber(1)
        If ntbSOQty.DecimalValue = 0 Then ntbSOQty.Text = FormatNumber(1)
        If m_SODId > 0 And (CDbl(ntbSOQty.Text) < m_SumSDeliveryQty) Then
            MsgBox("Delivered quantity for this item has " & m_SumSDeliveryQty & ". Please edit the quantity with equal or more than the quantity received.", vbInformation, Me.Text)
            ntbSOQty.Text = m_SOQtyBefore
        Else
            ntbSOQty.Text = ntbSOQty.Text
        End If

        DetailCount()
    End Sub

    Private Sub ntbSOPrice_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSOPrice.LostFocus
        If ntbSOPrice.Text = "" Then ntbSOPrice.Text = FormatNumber(0)

        DetailCount()

        ntbSOPrice.Text = FormatNumber(ntbSOPrice.Text, Dec)
    End Sub

    Private Sub ntbSODiscAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSODiscAmt.LostFocus
        If ntbSODiscAmt.Text = "" Then ntbSODiscAmt.Text = FormatNumber(0)
        If SO_Tier_Disc = False Then
            If CDbl(ntbSODiscAmt.Text) > 0 Then ntbSODiscAmt.Text = CDbl(ntbSODiscAmt.Text) * -1
            If CDbl(ntbSODiscAmt.Text) < 0 Then
                ntbSODiscPercent.Text = FormatNumber(CDbl(ntbSODiscAmt.Text) * -1 / (CDbl(ntbSOQty.Text) * CDbl(ntbSOPrice.Text)) * 100, 2)
            Else
                ntbSODiscPercent.Text = FormatNumber(0, 2)
            End If

            SO_Disc_Mode = 1

            refresh_totalD()
        End If
        ntbSODiscAmt.Text = FormatNumber(ntbSODiscAmt.Text)
    End Sub

    Private Sub ntbSOTaxPercent_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSOTaxPercent.LostFocus
        If ntbSOTaxPercent.Text = "" Then ntbSOTaxPercent.Text = FormatNumber(m_SOTaxPercent)
        DetailCount()
    End Sub

    Private Sub ntbSODiscPercent_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSODiscPercent.LostFocus
        If ntbSODiscPercent.Text = "" Then ntbSODiscPercent.Text = FormatNumber(0)

        DetailCount()

        SO_Disc_Mode = 0

        ntbSODiscPercent.Text = FormatNumber(ntbSODiscPercent.Text, 2)
    End Sub

    Private Sub ntbSODiscPercent2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSODiscPercent2.LostFocus
        If ntbSODiscPercent2.Text = "" Then ntbSODiscPercent2.Text = FormatNumber(0)

        DetailCount()

        SO_Disc_Mode = 0

        ntbSODiscPercent2.Text = FormatNumber(ntbSODiscPercent2.Text, 2)
    End Sub

    Sub DetailCount()
        Dim jumlah0 As Decimal
        Dim jumlah1 As Decimal
        Dim jumlah2 As Decimal
        Dim jumlah3 As Decimal
        Dim jumlah4 As Decimal = 0

        If cbIncludeTax.Checked = True Then
            ntbSOPrice.Text = FormatNumber((CDbl(ntbSOPriceIncludeTax.Text) / ((CDbl(ntbSOTaxPercent.Text) + 100) / 100)), Dec)
        End If

        If CDbl(ntbSODiscPercent.Text) > 0 Or CDbl(ntbSODiscPercent2.Text) > 0 Then
            jumlah0 = FormatNumber(CDbl(ntbSOQty.Text) * CDbl(ntbSOPrice.Text))
            jumlah1 = FormatNumber((jumlah0 * CDbl(ntbSODiscPercent.Text) / 100) * -1)
            jumlah2 = FormatNumber(CDbl(ntbSOQty.Text) * CDbl(ntbSOPrice.Text) + jumlah1)
            jumlah3 = FormatNumber((jumlah2 * CDbl(ntbSODiscPercent2.Text) / 100) * -1)
            jumlah4 = jumlah1 + jumlah3
        End If

        If jumlah4 > 0 Then
            jumlah4 = jumlah4 * -1
        End If

        ntbSODiscAmt.Text = jumlah4

        refresh_totalD()
    End Sub
    

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Sls_Order_Form '" & txtSONo.Text & "' "
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SO_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_Order_Form.rpt"

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
        NewMDIChild.Text = "Sales Order"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("SO_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub txtSKUBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSKUBarcode.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) And txtSKUBarcode.Text <> "" Then
            cmd = New SqlCommand("sp_mt_sku_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_barcode", SqlDbType.NVarChar, 50)
            prm1.Value = txtSKUBarcode.Text

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            If Not myReader.HasRows Then
                MsgBox("There is no stock with barcode " & txtSKUBarcode.Text, vbCritical + vbOKOnly, Me.Text)
                myReader.Close()
                cn.Close()
            Else

                While myReader.Read
                    cmbSODtlType.SelectedIndex = 0
                    m_SKUId = myReader.GetInt32(0)
                    txtSODtlDesc.Text = myReader.GetString(3)
                    ntbSOQty.Text = FormatNumber(1)
                    ntbSODiscPercent.Text = FormatNumber(myReader.GetDecimal(6) * 100)
                    ntbSOPrice.Text = FormatNumber(myReader.GetValue(7), Dec)
                    ntbSOTaxPercent.Text = m_SOTaxPercent
                End While
                myReader.Close()
                cn.Close()
                btnSaveD_Click(sender, e)
                txtSKUBarcode.Text = ""
            End If
        End If
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

    Private Sub btnSlsCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSlsCode.Click
        Dim NewFormDialog As New fdlSlsCode
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub frmSO_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub btnCloseSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseSO.Click
        If MsgBox("Are you sure you want to close this Sales Order?", vbYesNo + vbCritical, Me.Text) = vbYes Then

            AppLock.GetLock()

            cmd = New SqlCommand("usp_tr_so_CLOSE", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
            prm1.Value = m_SOId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm2.Value = My.Settings.UserName

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            AppLock.ReleaseLock()

            btnAdd_Click(sender, e)
        End If
    End Sub

    Private Sub ntbSOCurrRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSOCurrRate.LostFocus
        If ntbSOCurrRate.Text.Length = 0 Then ntbSOCurrRate.Undo()
        If m_SOId = 0 Then
            If m_CurrId = m_CurrBaseId Then
                ntbSOCurrRate.Text = "1"
            Else
                If ntbSOCurrRate.DecimalValue = 0 Then ntbSOCurrRate.Undo()
            End If
        End If
        ntbSOCurrRate.Text = FormatNumber(ntbSOCurrRate.Text)
    End Sub

    Private Sub btnInvoiceNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvoiceNo.Click
        Try
            If m_CId = 0 Or m_SlsCodeId = 0 Then
                MsgBox("Sales Code, Customer Code and Customer Name are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtCCode.Focus()
                Exit Sub
            End If

            AppLock.GetLock()

            If txtSInvoiceNo.Text.Trim = "" Then

                txtSInvoiceNo.Text = GetSysNumber("sinv", Now.Date)

                cmd = New SqlCommand("usp_tr_sinvoice_INS", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinvoice_no", SqlDbType.NVarChar, 50)
                prm1.Value = txtSInvoiceNo.Text
                Dim prm2 As SqlParameter = cmd.Parameters.Add("@sinvoice_date", SqlDbType.SmallDateTime)
                prm2.Value = dtpSODate.Value.Date
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
                prm3.Value = m_CId
                Dim prm4 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
                prm4.Value = m_SOId
                Dim prm5 As SqlParameter = cmd.Parameters.Add("@sls_code_id", SqlDbType.Int)
                prm5.Value = m_SlsCodeId
                Dim prm6 As SqlParameter = cmd.Parameters.Add("@sinvoice_terms", SqlDbType.Int, 50)
                prm6.Value = CInt(ntbPaymentTerms.Text)
                Dim prm7 As SqlParameter = cmd.Parameters.Add("@sinvoice_duedate", SqlDbType.SmallDateTime)
                prm7.Value = DateAdd(DateInterval.Day, CInt(ntbPaymentTerms.Text), dtpSODate.Value.Date)
                Dim prm8 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
                prm8.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
                'Dim prm9 As SqlParameter = cmd.Parameters.Add("@shipment_date", SqlDbType.DateTime)
                'prm9.Value = dtpShipmentDate.Value
                Dim prm9 As SqlParameter = cmd.Parameters.Add("@sinvoice_remarks", SqlDbType.NVarChar, 255)
                prm9.Value = IIf(txtSORemarks.Text = "", DBNull.Value, txtSORemarks.Text)
                Dim prm10 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
                prm10.Value = m_CurrId
                Dim prm11 As SqlParameter = cmd.Parameters.Add("@sinvoice_curr_rate", SqlDbType.Money)
                prm11.Value = FormatNumber(ntbSOCurrRate.Text)
                Dim prm12 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                prm12.Value = My.Settings.UserName
                Dim prm13 As SqlParameter = cmd.Parameters.Add("@sinvoice_period_id", SqlDbType.Int)
                prm13.Value = 0
                Dim prm16 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int)
                prm16.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                UpdSysNumber("sinv")

            End If

            AppLock.ReleaseLock()

            btnSave_Click(sender, e)
        Catch ex As Exception
            'If Err.Number = 5 Then
            '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
            'Else
            MsgBox(ex.Message)
            'End If
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Private Sub btnPrintSInv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintSInv.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Sls_Order_Form '" & txtSONo.Text & "' "
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SOInv_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_OrderInv_Form.rpt"

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
        cr.SetDataSource(DS.Tables("SOInv_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub
    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmSOList).Any Then
            Call frmSOList.frmSOListShow(Nothing, EventArgs.Empty)
        End If
    End Sub

    Private Sub cbIncludeTax_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbIncludeTax.CheckedChanged
        '20160823 price include tax
        lock_objD(False)

        If cbIncludeTax.Checked = True Then
            ntbSOPriceIncludeTax.Text = FormatNumber("0")
        End If

        ntbSOPriceIncludeTax.Text = FormatNumber(ntbSOPriceIncludeTax.Text, Dec)

    End Sub

    Private Sub ntbSOPriceIncludeTax_LostFocus(sender As System.Object, e As System.EventArgs) Handles ntbSOPriceIncludeTax.LostFocus
        '20160823 price include tax
        If ntbSOPriceIncludeTax.Text = "" Then ntbSOPriceIncludeTax.Text = FormatNumber(0)

        ntbSODiscAmt.Text = "0"
        ntbSODiscPercent.Text = "0"
        ntbSODiscPercent2.Text = "0"

        DetailCount()

        ntbSOPriceIncludeTax.Text = FormatNumber(ntbSOPriceIncludeTax.Text, Dec)

    End Sub

    Private Sub btnPrintPackingSlip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPackingSlip.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Sls_Order_Packing_Slip_Form '" & txtSONo.Text & "' "
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SO_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_Order_Packing_Slip_Form.rpt"

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
        NewMDIChild.Text = "Packing Slip"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("SO_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub
End Class
