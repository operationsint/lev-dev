Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmSDelivery
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_SDeliveryId As Integer
    Dim m_SDeliveryDId As Integer
    Dim m_SOId As Integer
    Dim m_SODId As Integer
    Dim m_CId As Integer
    Dim m_PeriodId As Integer
    Dim m_PeriodArr(0, 0) As String
    Dim m_PeriodArrSelected As Integer
    Dim m_SOStatus As String
    Dim m_SDeliveryStatus As String
    Dim m_SDeliveryStatusArr(1, 1) As String
    Dim m_SODtlType As String
    Dim m_SODtlTypeArr(2, 1) As String
    Dim m_SKUId As Integer
    Dim m_IncomeId As Integer
    Dim m_LocationId As Integer
    Dim m_LocationIdBefore As Integer
    Dim m_LocationQty As Double
    Dim m_SDeliveryQtyBefore As Double
    Dim m_SKUAverageCost As Double
    Dim isGetNum As Boolean
    Dim isAllowDelete As Boolean
    Dim isAllowStockMinus As Boolean = GetSysInit("sku_qty_minus")
    Dim isPosted As Boolean
    Private docPR As ReportDocument

    Private Sub frmSDelivery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim prm1 As SqlParameter
        Dim prm2 As SqlParameter
        Dim myReader As SqlDataReader

        isAllowDelete = canDelete(Me.Name + "List")

        'Add item cmbPOStatus
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "sdelivery_status"

        cn.Open()
        myReader = cmd.ExecuteReader
        Dim i As Integer = 0

        While myReader.Read
            m_SDeliveryStatusArr(i, 0) = myReader.GetString(0)
            m_SDeliveryStatusArr(i, 1) = myReader.GetString(1)
            i += 1
        End While

        myReader.Close()
        cn.Close()

        'Add item cmbSODtlType
        i = 0
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "so_dtl_type"

        cn.Open()
        myReader = cmd.ExecuteReader

        While myReader.Read
            m_SODtlTypeArr(i, 0) = myReader.GetString(0)
            m_SODtlTypeArr(i, 1) = myReader.GetString(1)
            i += 1
        End While

        myReader.Close()
        cn.Close()

        'Add item cmbPeriodId
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

        If m_SDeliveryId = 0 Then
            btnAdd_Click(sender, e)
        Else
            m_SDeliveryDId = 0
            view_record()
            clear_lvw()
            'btnEdit_Click(sender, e)
            clear_objD()
            lock_obj(True)
            lock_objD(True)
        End If

    End Sub

    Private Sub btnSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSO.Click
        Dim NewFormDialog As New fdlSOOut
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Public Property SDeliveryId() As Integer
        Get
            Return m_SDeliveryId
        End Get
        Set(ByVal Value As Integer)
            m_SDeliveryId = Value
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

    Public Property PaymentDueDate() As String
        Get
            Return txtPaymentDueDate.Text
        End Get
        Set(ByVal Value As String)
            txtPaymentDueDate.Text = Value
        End Set
    End Property

    Public Property PRRemarks() As String
        Get
            Return txtSDeliveryRemarks.Text
        End Get
        Set(ByVal Value As String)
            txtSDeliveryRemarks.Text = Value
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

    Public Property SODId() As Integer
        Get
            Return m_SODId
        End Get
        Set(ByVal Value As Integer)
            m_SODId = Value
        End Set
    End Property

    Public Property SODtlType() As String
        Get
            Return m_SODtlType
        End Get
        Set(ByVal Value As String)
            m_SODtlType = Value
            For i = 0 To m_SODtlTypeArr.GetUpperBound(0)
                If m_SODtlType = m_SODtlTypeArr(i, 0) Then
                    txtSODtlType.Text = m_SODtlTypeArr(i, 1)
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

    Public Property SKUDescription() As String
        Get
            Return txtSODtlDesc.Text
        End Get
        Set(ByVal Value As String)
            txtSODtlDesc.Text = Value
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

    Public Property LocationQty() As String
        Get
            Return m_LocationQty
        End Get
        Set(ByVal Value As String)
            m_LocationQty = Value
        End Set
    End Property

    Public Property SOQty() As String
        Get
            Return txtSOQty.Text
        End Get
        Set(ByVal Value As String)
            txtSOQty.Text = Value
        End Set
    End Property

    Public Property PreviousQty() As String
        Get
            Return txtPreviousQty.Text
        End Get
        Set(ByVal Value As String)
            txtPreviousQty.Text = Value
        End Set
    End Property

    Public Property SDeliveryQty() As String
        Get
            Return ntbSDeliveryQty.Text
        End Get
        Set(ByVal Value As String)
            ntbSDeliveryQty.Text = Value
        End Set
    End Property

    Public Property RemainQty() As Double
        Get
            Return txtRemainQty.Text
        End Get
        Set(ByVal Value As Double)
            txtRemainQty.Text = Value
        End Set
    End Property

    Public Property IncomeId() As Integer
        Get
            Return m_IncomeId
        End Get
        Set(ByVal Value As Integer)
            m_IncomeId = Value
        End Set
    End Property

    Public Property SKUAverageCost() As Double
        Get
            Return m_SKUAverageCost
        End Get
        Set(ByVal Value As Double)
            m_SKUAverageCost = Value
        End Set
    End Property

    Sub clear_obj()
        m_SDeliveryId = 0
        m_CId = 0
        txtSDeliveryNo.Text = ""
        dtpSDeliveryDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtPaymentDueDate.Text = dtpSDeliveryDate.Value
        txtSONo.Text = ""
        txtCCode.Text = ""
        txtCName.Text = ""
        txtSDeliveryRemarks.Text = ""
        m_SDeliveryStatus = m_SDeliveryStatusArr(0, 0)
        txtSDeliveryStatus.Text = m_SDeliveryStatusArr(0, 1)
        isGetNum = True
        isPosted = False
        txtVehicleNumber.Text = ""
    End Sub

    Sub clear_objD()
        m_SDeliveryDId = 0
        m_SODId = 0
        m_SKUId = 0
        m_IncomeId = 0
        m_LocationId = 0
        m_LocationIdBefore = 0
        m_LocationQty = 0
        m_SDeliveryQtyBefore = 0
        m_SKUAverageCost = 0
        txtSKUCode.Text = ""
        txtSODtlDesc.Text = ""
        txtSOQty.Text = FormatNumber(0)
        txtPreviousQty.Text = FormatNumber(0)
        ntbSDeliveryQty.Text = FormatNumber(0)
        txtRemainQty.Text = FormatNumber(0)
        txtSKUUoM.Text = ""
        txtLocationCode.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        dtpSDeliveryDate.Enabled = Not isLock
        txtSDeliveryRemarks.ReadOnly = isLock
        txtVehicleNumber.ReadOnly = isLock
        btnSO.Enabled = Not isLock
        If Not m_SDeliveryStatus = "I" Then btnEdit.Enabled = isLock Else btnEdit.Enabled = False
        If isPosted = True Then btnEdit.Enabled = False
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnPrint.Enabled = isLock

        If m_SDeliveryId = 0 Then
            txtSDeliveryNo.ReadOnly = False
            btnSO.Enabled = True
            btnDelete.Enabled = isLock
        Else
            txtSDeliveryNo.ReadOnly = True
            btnSO.Enabled = False
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        ntbSDeliveryQty.ReadOnly = isLock
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
            .Columns.Add("sdelivery_id", 0)
            .Columns.Add("so_dtl_type", 0)
            .Columns.Add("Line Type", 60)
            .Columns.Add("so_dtl_id", 0)
            .Columns.Add("sku_id", 0)
            .Columns.Add("Stock Code", 90)
            .Columns.Add("Line Description", 250)
            .Columns.Add("location_id", 0)
            .Columns.Add("Location Code", 90)
            .Columns.Add("Order Qty", 80, HorizontalAlignment.Right)
            .Columns.Add("Prior Delivery", 80, HorizontalAlignment.Right)
            .Columns.Add("Delivery Qty", 80, HorizontalAlignment.Right)
            .Columns.Add("Remaining", 80, HorizontalAlignment.Right)
            .Columns.Add("UoM", 80)
            .Columns.Add("Lot Job No", 150)
        End With

        If m_SDeliveryId <> 0 Then
            'cmd = New SqlCommand(IIf(m_SDeliveryId = 0 Or m_SOId <> m_SOIdTemp, "sp_tr_po_dtl_SEL", "usp_tr_pr_dtl_SEL"), cn)
            cmd = New SqlCommand("usp_tr_sdelivery_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            'Dim prm1 As SqlParameter = cmd.Parameters.Add(IIf(m_PRId = 0 Or m_POId <> m_POIdTemp, "@po_id", "@pr_id"), SqlDbType.Int)
            'prm1.Value = IIf(m_PRId = 0 Or m_POId <> m_POIdTemp, m_POId, m_PRId)

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sdelivery_id", SqlDbType.Int)
            prm1.Value = m_SDeliveryId

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(1)))
                lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                For i = 2 To 3 'so_dtl_type, line_type
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next
                lvItem.SubItems.Add(myReader.GetInt32(4)) 'so_dtl_id
                lvItem.SubItems.Add(myReader.GetInt32(5)) 'sku_id
                Select Case myReader.GetString(2)
                    Case "S"
                        lvItem.SubItems.Add(myReader.GetString(6)) 'sku_code
                    Case "I"
                        lvItem.SubItems.Add(myReader.GetString(22)) 'income_code
                    Case Else
                        lvItem.SubItems.Add("")
                End Select
                For i = 7 To 14
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next
                lvItem.SubItems.Add(IIf(myReader.Item(23) Is System.DBNull.Value, "", myReader.Item(23))) 'lot job
                'lvItem.SubItems.Add(myReader.GetInt32(9))
                'lvItem.SubItems.Add(myReader.GetInt32(10))
                'lvItem.SubItems.Add(myReader.GetInt32(11))
                'lvItem.SubItems.Add(myReader.GetInt32(12))
                'lvItem.SubItems.Add(IIf(myReader.Item(13) Is System.DBNull.Value, lvItem.SubItems.Add(""), lvItem.SubItems.Add(myReader.Item(13))))
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
        cmd = New SqlCommand("usp_tr_sdelivery_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sdelivery_id", SqlDbType.Int)
        prm1.Value = m_SDeliveryId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtSDeliveryNo.Text = myReader.GetString(1)
            dtpSDeliveryDate.Value = myReader.GetDateTime(2)
            m_SOId = myReader.GetInt32(3)
            'm_SOIdTemp = myReader.GetInt32(3)
            txtSONo.Text = myReader.GetString(4)
            m_CId = myReader.GetInt32(5)
            'm_CIdTemp = myReader.GetInt32(5)
            txtCCode.Text = myReader.GetString(6)
            'm_SCodeTemp = myReader.GetString(6)
            txtCName.Text = myReader.GetString(7)
            'm_SNameTemp = myReader.GetString(7)
            txtPaymentDueDate.Text = myReader.GetDateTime(9)
            If Not myReader.IsDBNull(myReader.GetOrdinal("sdelivery_remarks")) Then
                txtSDeliveryRemarks.Text = myReader.GetString(myReader.GetOrdinal("sdelivery_remarks"))
            Else
                txtSDeliveryRemarks.Text = ""
            End If
            'txtPRRemarks.Text = IIf(Not myReader.IsDBNull(myReader.GetOrdinal("pr_remarks")), myReader.GetString(myReader.GetOrdinal("pr_remarks")), "")
            m_SOStatus = myReader.GetString(11)
            m_SDeliveryStatus = myReader.GetString(12)
            txtVehicleNumber.Text = myReader.GetString(14) 'Vehicle Number
            isPosted = myReader.GetBoolean(15)
            m_PeriodId = myReader.GetInt32(16)
        End While

        myReader.Close()
        cn.Close()

        If isPosted = True Then txtPeriodId.Text = GetPeriodName(m_PeriodId)

        For i = 0 To m_SDeliveryStatusArr.GetUpperBound(0)
            If m_SDeliveryStatus = m_SDeliveryStatusArr(i, 0) Then
                txtSDeliveryStatus.Text = m_SDeliveryStatusArr(i, 1)
                Exit For
            End If
        Next
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_SDeliveryId = 0
        m_SOId = 0
        m_CId = 0

        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_SDeliveryId = 0 Then
            Me.Close()
        Else
            lock_obj(True)
            lock_objD(True)
            clear_objD()
            m_SDeliveryDId = 0
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If m_SOId = 0 Then
                MsgBox("SO # and Customer information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtSONo.Focus()
                Exit Sub
            End If

            If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
                MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                Exit Sub
            End If

            If ListView1.Items.Count = 0 Then
                MsgBox("This sales delivery has no detail rows!", vbInformation, "Warning")
            End If

            AppLock.GetLock()

            If m_SDeliveryId = 0 Then
                If txtSDeliveryNo.Text.Trim = "" Then
                    txtSDeliveryNo.Text = GetSysNumber("sdel", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If
            End If

            cmd = New SqlCommand(IIf(m_SDeliveryId = 0, "usp_tr_sdelivery_INS", "usp_tr_sdelivery_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter
            prm1 = cmd.Parameters.Add("@sdelivery_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtSDeliveryNo.Text
            Dim prm2 As SqlParameter
            prm2 = cmd.Parameters.Add("@sdelivery_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpSDeliveryDate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
            prm3.Value = m_SOId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm4.Value = m_CId
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@sdelivery_period_id", SqlDbType.Int)
            prm6.Value = m_PeriodArr(m_PeriodArrSelected, 0)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@sdelivery_remarks", SqlDbType.NVarChar, 255)
            prm10.Value = IIf(txtSDeliveryRemarks.Text = "", DBNull.Value, txtSDeliveryRemarks.Text)
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm15.Value = My.Settings.UserName
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@sdelivery_id", SqlDbType.Int)
            Dim prm17 As SqlParameter
            prm17 = cmd.Parameters.Add("@vehicle_number", SqlDbType.NVarChar, 50)
            prm17.Value = txtVehicleNumber.Text

            If m_SDeliveryId = 0 Then
                prm16.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_SDeliveryId = prm16.Value
                'MessageBox.Show(m_PRId)
                cn.Close()
                If isGetNum = True Then UpdSysNumber("sdel")
            Else
                prm16.Value = m_SDeliveryId
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                'clear_lvw()
            End If

            lock_obj(True)
            lock_objD(True)

        Catch ex As Exception
            'If Err.Number = 5 Then
            '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
            'Else
            '    MsgBox(ex.Message)
            'End If
            MsgBox(ex.Message)
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
        'If m_SDeliveryId <> 0 Then btnSO.Enabled = False
        'If m_SDeliveryStatus = "I" Then
        '    btnSave.Enabled = False
        '    btnDelete.Enabled = False
        '    lock_objD(True)
        'End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If m_SDeliveryStatus = "D" Then
            If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then

                AppLock.GetLock()

                cmd = New SqlCommand("usp_tr_sdelivery_DEL", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@sdelivery_id", SqlDbType.Int)
                prm1.Value = m_SDeliveryId
                Dim prm2 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
                prm2.Value = m_SOId
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                prm3.Value = My.Settings.UserName

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

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Sls_Del_Form '" & txtSDeliveryNo.Text & "' "
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SDel_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_Del_Form.rpt"

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
        NewMDIChild.Text = "Sales Delivery"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("SDel_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        Try
            If m_SDeliveryId = 0 Then
                If m_SOId = 0 Then
                    MsgBox("SO # and Supplier information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                    txtSONo.Focus()
                    Exit Sub
                End If

                If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
                    MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                    Exit Sub
                End If

                SaveSDeliveryHeader()
            End If

            If txtSODtlDesc.Text = "" Then
                MsgBox("Line Description are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtSODtlDesc.Focus()
                Exit Sub
            End If

            If m_SODId = 0 Then
                MsgBox("Please press the Stock button to select the Stock or at least select an item if you want to update.", vbCritical + vbOKOnly, Me.Text)
                txtSKUCode.Focus()
                Exit Sub
            End If

            'Check stock location
            If m_SODtlType = "S" Then
                If isAllowStockMinus = False And (m_SDeliveryQtyBefore <> CDbl(ntbSDeliveryQty.Text) Or m_LocationIdBefore <> m_LocationId) Then
                    cmd = New SqlCommand("usp_mt_sku_location_SEL", cn)
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim prm11 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
                    prm11.Value = m_SKUId
                    Dim prm12 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int)
                    prm12.Value = m_LocationId

                    cn.Open()
                    Dim myReader As SqlDataReader = cmd.ExecuteReader()

                    While myReader.Read
                        m_LocationQty = myReader.GetValue(7) 'sku_qty
                    End While
                    myReader.Close()
                    cn.Close()
                Else
                    m_LocationQty = m_SDeliveryQtyBefore
                End If
            End If
            If m_SODtlType = "S" And isAllowStockMinus = False And (CDbl(ntbSDeliveryQty.Text) > m_LocationQty Or m_LocationQty = 0) Then
                MsgBox("Delivered Qty > Location Qty")
                Exit Sub
            End If

            AppLock.GetLock()

            cmd = New SqlCommand(IIf(m_SDeliveryDId = 0, "usp_tr_sdelivery_dtl_INS", "usp_tr_sdelivery_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sdelivery_id", SqlDbType.Int)
            prm1.Value = m_SDeliveryId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
            prm2.Value = m_SOId
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@so_dtl_id", SqlDbType.Int)
            prm3.Value = m_SODId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
            prm4.Value = m_SKUId
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@sdelivery_qty", SqlDbType.Decimal)
            prm5.Value = ntbSDeliveryQty.Text
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@previous_qty", SqlDbType.Decimal)
            prm6.Value = txtPreviousQty.Text
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int)
            prm7.Value = m_LocationId

            If m_SDeliveryDId = 0 Then
                Dim prm10 As SqlParameter = cmd.Parameters.Add("@avg_cost", SqlDbType.Money)
                prm10.Value = m_SKUAverageCost
                Dim prm13 As SqlParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int)
                prm13.Direction = ParameterDirection.Output
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                If prm13.Value = 1 Then
                    MsgBox("This stock already inserted before!", vbCritical, Me.Text)
                End If
            Else
                Dim prm20 As SqlParameter = cmd.Parameters.Add("@sdelivery_dtl_id", SqlDbType.Int)
                prm20.Value = m_SDeliveryDId
                Dim prm21 As SqlParameter = cmd.Parameters.Add("@so_dtl_type", SqlDbType.NVarChar)
                prm21.Value = m_SODtlType
                Dim prm22 As SqlParameter = cmd.Parameters.Add("@sdelivery_qty_before", SqlDbType.Decimal)
                prm22.Value = m_SDeliveryQtyBefore
                Dim prm23 As SqlParameter = cmd.Parameters.Add("@location_id_before", SqlDbType.Int)
                prm23.Value = m_LocationIdBefore
                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
            End If

            clear_lvw()
            clear_objD()

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

    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD.Click
        If m_SDeliveryDId = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then

            AppLock.GetLock()

            cmd = New SqlCommand("usp_tr_sdelivery_dtl_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sdelivery_dtl_id", SqlDbType.Int)
            prm1.Value = m_SDeliveryDId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
            prm2.Value = m_SOId

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            AppLock.ReleaseLock()

            clear_lvw()
            clear_objD()
        End If
    End Sub

    Sub SaveSDeliveryHeader()
        Try
            AppLock.GetLock()

            If txtSDeliveryNo.Text.Trim = "" Then
                txtSDeliveryNo.Text = GetSysNumber("sdel", Now.Date)
                isGetNum = True
            Else
                isGetNum = False
            End If

            cmd = New SqlCommand("usp_tr_sdelivery_INS", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter
            prm1 = cmd.Parameters.Add("@sdelivery_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtSDeliveryNo.Text
            Dim prm2 As SqlParameter
            prm2 = cmd.Parameters.Add("@sdelivery_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpSDeliveryDate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
            prm3.Value = m_SOId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
            prm4.Value = m_CId
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@sdelivery_period_id", SqlDbType.Int)
            prm6.Value = m_PeriodArr(m_PeriodArrSelected, 0)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@sdelivery_remarks", SqlDbType.NVarChar, 255)
            prm10.Value = IIf(txtSDeliveryRemarks.Text = "", DBNull.Value, txtSDeliveryRemarks.Text)
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm15.Value = My.Settings.UserName
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@sdelivery_id", SqlDbType.Int)
            prm16.Direction = ParameterDirection.Output
            Dim prm17 As SqlParameter
            prm17 = cmd.Parameters.Add("@vehicle_number", SqlDbType.NVarChar, 50)
            prm17.Value = txtVehicleNumber.Text

            cn.Open()
            cmd.ExecuteReader()
            m_SDeliveryId = prm16.Value
            cn.Close()
            If isGetNum = True Then UpdSysNumber("sdel")
            txtSDeliveryNo.ReadOnly = True
            btnSO.Enabled = False

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

    Private Sub ListView1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1.SelectedItems.Item(0)
            m_SDeliveryDId = LeftSplitUF(.Tag)
            m_SODtlType = .SubItems.Item(1).Text
            txtSODtlType.Text = .SubItems.Item(2).Text
            m_SODId = .SubItems.Item(3).Text
            m_SKUId = .SubItems.Item(4).Text
            txtSKUCode.Text = .SubItems.Item(5).Text
            txtSODtlDesc.Text = .SubItems.Item(6).Text
            m_LocationId = IIf(.SubItems.Item(7).Text = "", 0, .SubItems.Item(7).Text)
            m_LocationIdBefore = IIf(.SubItems.Item(7).Text = "", 0, .SubItems.Item(7).Text)
            txtLocationCode.Text = IIf(.SubItems.Item(8).Text = "", "", .SubItems.Item(8).Text)
            txtSOQty.Text = .SubItems.Item(9).Text
            txtPreviousQty.Text = .SubItems.Item(10).Text
            m_SDeliveryQtyBefore = .SubItems.Item(11).Text
            ntbSDeliveryQty.Text = .SubItems.Item(11).Text
            txtRemainQty.Text = .SubItems.Item(12).Text
            txtSKUUoM.Text = .SubItems.Item(13).Text
        End With
    End Sub

    Private Sub btnSKU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSKU.Click
        If m_SOId = 0 Then
            MsgBox("SO # & Location information are primary fields that should be entered. Please enter those fields before you do the selection.", vbCritical + vbOKOnly, Me.Text)
            txtSONo.Focus()
            Exit Sub
        End If
        If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
            MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If
        Dim NewFormDialog As New fdlSKUSOOut
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocation.Click
        If m_SODId = 0 Then
            MsgBox("Stock information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            btnSKU.Focus()
            Exit Sub
        End If
        Dim NewFormDialog As New fdlLocation
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.SKUId = m_SKUId
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub ntbSDeliveryQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbSDeliveryQty.LostFocus
        If ntbSDeliveryQty.Text = "" Then ntbSDeliveryQty.Text = 1
        If ntbSDeliveryQty.DecimalValue = 0 Then ntbSDeliveryQty.Text = 1
        If CDbl(txtSOQty.Text) - CDbl(txtPreviousQty.Text) - CDbl(ntbSDeliveryQty.Text) < 0 Then
            MsgBox("The quantity entered is higher than quantity in Sales Order. Please enter as ordered or less.", vbInformation, Me.Text)
            ntbSDeliveryQty.Text = m_SDeliveryQtyBefore
        Else
            ntbSDeliveryQty.Text = ntbSDeliveryQty.Text
        End If
    End Sub
    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmSDeliveryList).Any Then
            Call frmSDeliveryList.frmSDeliveryListShow(Nothing, EventArgs.Empty)
        End If
    End Sub

    Private Sub dtpSDeliveryDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpSDeliveryDate.ValueChanged
        Dim isCheckIn As Boolean
        For i As Integer = 0 To m_PeriodArr.GetUpperBound(0)
            If dtpSDeliveryDate.Value >= m_PeriodArr(i, 2) AndAlso dtpSDeliveryDate.Value <= m_PeriodArr(i, 3) Then
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
End Class
