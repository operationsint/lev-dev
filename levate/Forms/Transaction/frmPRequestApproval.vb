Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmPRequestApproval
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_PRequestId As Integer
    Dim m_SId As Integer
    Dim m_PchCodeId As Integer
    Dim m_POType As String
    Dim m_PaymentMethod As String
    Dim m_PRequestStatus As String
    Dim m_PRequestStatusArr(4, 1) As String
    Dim m_PRequestDId As Integer
    Dim m_PRequestDtlType As String
    Dim m_SKUId As Integer
    Dim m_LocationId As Integer
    Dim m_POTaxPercent As Single
    Dim isAllowDelete As Boolean
    Dim isGetNum As Boolean
    Private docPO As ReportDocument

    Private Sub frmPRequestApproval_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ToolTip1.SetToolTip(btnSKU, "Search Stock")
        ToolTip1.SetToolTip(btnSaveD, "Save Line")
        ToolTip1.SetToolTip(btnDeleteD, "Delete Line")
        ToolTip1.SetToolTip(btnAddD, "Add Line")

        Dim prm1 As SqlParameter
        Dim myReader As SqlDataReader

        isAllowDelete = canDelete(Me.Name + "List")

        'Add item cmbRequester
        cmbPRequester.Items.Clear()
        cmd = New SqlCommand("usp_tr_prequest_SEL_ByRequester", cn)
        cmd.CommandType = CommandType.StoredProcedure

        cn.Open()
        myReader = cmd.ExecuteReader()

        While myReader.Read
            cmbPRequester.Items.Add(myReader.GetString(0))
        End While

        myReader.Close()
        cn.Close()

        'Add item cmbPRequestStatus
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "prequest_status"

        cn.Open()
        myReader = cmd.ExecuteReader
        Dim i As Integer = 0

        While myReader.Read
            m_PRequestStatusArr(i, 0) = myReader.GetString(0)
            m_PRequestStatusArr(i, 1) = myReader.GetString(1)
            i += 1
        End While

        myReader.Close()
        cn.Close()

        'Add item cmbPRequestDtlType
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "po_dtl_type"

        cn.Open()
        myReader = cmd.ExecuteReader

        cmbPRequestDtlType.Items.Clear()
        While myReader.Read
            cmbPRequestDtlType.Items.Add(New clsMyListStr(myReader.GetString(1), myReader.GetString(0)))
        End While
        cmbPRequestDtlType.SelectedIndex = 0

        myReader.Close()
        cn.Close()

        If m_PRequestId = 0 Then
            btnAdd_Click(sender, e)
        Else
            m_PRequestDId = 0
            view_record()
            clear_lvw()
            'btnEdit_Click(sender, e)
            clear_objD()
            lock_obj(True)
            lock_objD(True)
        End If
    End Sub

    Private Sub btnSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim NewFormDialog As New fdlSupplier
        NewFormDialog.ShowDialog()
    End Sub

    Public Property PRequestId() As Integer
        Get
            Return m_PRequestId
        End Get
        Set(ByVal Value As Integer)
            m_PRequestId = Value
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

    Public Property PRequester() As String
        Get
            Return cmbPRequester.Text
        End Get
        Set(ByVal Value As String)
            cmbPRequester.Text = Value
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
            Return txtPRequestDtlDesc.Text
        End Get
        Set(ByVal Value As String)
            txtPRequestDtlDesc.Text = Value
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

    Private Sub btnSKU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSKU.Click
        Select Case cmbPRequestDtlType.Items(cmbPRequestDtlType.SelectedIndex).ItemData
            Case "S"
                Dim NewFormDialog As New fdlSKUPO
                NewFormDialog.FrmCallerId = Me.Name
                NewFormDialog.ShowDialog()
            Case "E"
                Dim NewFormDialog As New fdlExpense
                NewFormDialog.FrmCallerId = Me.Name
                NewFormDialog.ShowDialog()
        End Select
    End Sub

    Sub clear_obj()
        m_PRequestId = 0
        m_SId = 0
        m_PchCodeId = 0
        txtPRequestNo.Text = ""
        dtpPRequestDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        cmbPRequester.SelectedIndex = -1
        txtPchCode.Text = ""
        txtPORemarks.Text = ""
        m_PRequestStatus = m_PRequestStatusArr(0, 0)
        txtPRequestStatus.Text = m_PRequestStatusArr(0, 1)
        isGetNum = True
    End Sub

    Sub clear_objD()
        m_PRequestDId = 0
        m_SKUId = 0
        m_LocationId = 0
        cmbPRequestDtlType.SelectedIndex = 0
        txtSKUCode.Text = ""
        txtPRequestDtlDesc.Text = ""
        txtLocationCode.Text = ""
        ntbPRequestQty.Text = 0
        txtSKUUoM.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        dtpPRequestDate.Enabled = Not isLock
        dtpDeliveryDate.Enabled = Not isLock
        cmbPRequester.Enabled = Not isLock
        cmbPRequester.Enabled = Not isLock
        txtPORemarks.ReadOnly = isLock

        btnPchCode.Enabled = Not isLock
        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnPrint.Enabled = isLock

        If m_PRequestId = 0 Then
            txtPRequestNo.ReadOnly = False
            btnDelete.Enabled = isLock
            btnReject.Enabled = isLock
            btnApprove.Enabled = isLock
        Else
            txtPRequestNo.ReadOnly = True
            'If p_UserLevel = 1 Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
            btnReject.Enabled = Not isLock
            btnApprove.Enabled = Not isLock
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        cmbPRequestDtlType.Enabled = Not isLock
        txtPRequestDtlDesc.ReadOnly = isLock
        ntbPRequestQty.ReadOnly = isLock

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
            .Columns.Add("PRequestId", 0)
            .Columns.Add("Type", 0)
            .Columns.Add("Line Type", 90)
            .Columns.Add("SKU Id", 0)
            .Columns.Add("Stock Code", 90)
            .Columns.Add("Line Description", 250)
            .Columns.Add("location_id", 0)
            .Columns.Add("Location", 90)
            .Columns.Add("Qty", 60, HorizontalAlignment.Right)
            .Columns.Add("UoM", 60)
        End With

        If m_PRequestId <> 0 Then
            cmd = New SqlCommand("usp_tr_prequest_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@prequest_dtl_id", SqlDbType.Int, 255)
            prm1.Value = 0
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@prequest_id", SqlDbType.Int, 255)
            prm2.Value = m_PRequestId

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(1)))
                lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                For i = 2 To 3
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next
                Select Case myReader.GetString(2)
                    Case "S"
                        lvItem.SubItems.Add(myReader.GetInt32(4))
                        lvItem.SubItems.Add(myReader.GetString(5))
                    Case "E"
                        lvItem.SubItems.Add(myReader.GetInt32(13))
                        lvItem.SubItems.Add(myReader.GetString(14))
                    Case Else
                        lvItem.SubItems.Add("0")
                        lvItem.SubItems.Add("")
                End Select
                lvItem.SubItems.Add(myReader.GetString(6))
                For i = 16 To 17 'location_id, location
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next
                lvItem.SubItems.Add(myReader.GetInt32(7))
                If myReader.Item(8) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(8))
                End If
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
        cmd = New SqlCommand("usp_tr_prequest_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@prequest_id", SqlDbType.Int, 255)
        prm1.Value = m_PRequestId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        Dim i As Integer

        While myReader.Read
            txtPRequestNo.Text = myReader.GetString(1)
            dtpPRequestDate.Value = myReader.GetDateTime(2)
            m_PchCodeId = myReader.GetInt32(3)
            txtPchCode.Text = myReader.GetString(4)
            For i = 1 To cmbPRequester.Items.Count
                If cmbPRequester.Items(i - 1) = myReader.GetString(5) Then
                    cmbPRequester.SelectedIndex = i - 1
                    Exit For
                End If
            Next
            dtpDeliveryDate.Value = myReader.GetDateTime(6)
            If Not myReader.IsDBNull(myReader.GetOrdinal("prequest_remarks")) Then
                txtPORemarks.Text = myReader.GetString(myReader.GetOrdinal("prequest_remarks"))
            Else
                txtPORemarks.Text = ""
            End If
            m_PRequestStatus = myReader.GetString(8)
        End While

        myReader.Close()
        cn.Close()

        For i = 0 To m_PRequestStatusArr.GetUpperBound(0)
            If m_PRequestStatus = m_PRequestStatusArr(i, 0) Then
                txtPRequestStatus.Text = m_PRequestStatusArr(i, 1)
                Exit For
            End If
        Next
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_PRequestId = 0
        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_PRequestId = 0 Then
            Me.Close()
        Else
            lock_obj(True)
            lock_objD(True)
            clear_objD()
            m_PRequestDId = 0
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If m_PchCodeId = 0 Or cmbPRequester.Text = "" Then
                MsgBox("Purchase Code & Requester information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                cmbPRequester.Focus()
                Exit Sub
            End If

            If m_PRequestId = 0 Then
                If txtPRequestNo.Text = "" Then
                    txtPRequestNo.Text = GetSysNumber("prequest", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If
            End If

            cmd = New SqlCommand(IIf(m_PRequestId = 0, "usp_tr_prequest_INS", "usp_tr_prequest_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@prequest_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtPRequestNo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@prequest_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpPRequestDate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@prequester", SqlDbType.NVarChar, 50)
            prm3.Value = cmbPRequester.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@delivery_date", SqlDbType.SmallDateTime)
            prm5.Value = dtpDeliveryDate.Value.Date
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@prequest_remarks", SqlDbType.NVarChar, 255)
            prm10.Value = IIf(txtPORemarks.Text = "", DBNull.Value, txtPORemarks.Text)
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@pch_code_id", SqlDbType.Int, 255)
            prm11.Value = m_PchCodeId
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm15.Value = My.Settings.UserName
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@prequest_id", SqlDbType.Int, 255)

            If m_PRequestId = 0 Then
                prm16.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_PRequestId = prm16.Value
                'MessageBox.Show(m_PRequestId)
                cn.Close()
                If isGetNum = True Then UpdSysNumber("prequest")
            Else
                prm16.Value = m_PRequestId
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
            MsgBox(ex.Message)
            'End If
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        autoRefresh()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        clear_objD()
        lock_obj(False)
        lock_objD(False)
        If m_PRequestStatus = "A" Or m_PRequestStatus = "V" Then
            btnSave.Enabled = False
            btnDelete.Enabled = False
            btnApprove.Enabled = False
            btnReject.Enabled = False
            lock_objD(True)
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Name) = vbYes Then
                cmd = New SqlCommand("usp_tr_prequest_DEL", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@prequest_id", SqlDbType.Int, 255)
                prm1.Value = m_PRequestId
                Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                prm2.Value = My.Settings.UserName

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                btnAdd_Click(sender, e)
            End If
        autoRefresh()
    End Sub

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        Try
            If m_PRequestId = 0 Then
                If m_PchCodeId = 0 Or cmbPRequester.Text = "" Then
                    MsgBox("Purchase Code & Requester information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                    cmbPRequester.Focus()
                    Exit Sub
                End If
                If txtPRequestNo.Text = "" Then
                    txtPRequestNo.Text = GetSysNumber("preq", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If

                cmd = New SqlCommand("usp_tr_prequest_INS", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@prequest_no", SqlDbType.NVarChar, 50)
                prm1.Value = txtPRequestNo.Text
                Dim prm2 As SqlParameter = cmd.Parameters.Add("@prequest_date", SqlDbType.SmallDateTime)
                prm2.Value = dtpPRequestDate.Value.Date
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@prequester", SqlDbType.NVarChar, 50)
                prm3.Value = cmbPRequester.Text
                Dim prm5 As SqlParameter = cmd.Parameters.Add("@delivery_date", SqlDbType.SmallDateTime)
                prm5.Value = dtpDeliveryDate.Value.Date
                Dim prm10 As SqlParameter = cmd.Parameters.Add("@prequest_remarks", SqlDbType.NVarChar, 255)
                prm10.Value = IIf(txtPORemarks.Text = "", DBNull.Value, txtPORemarks.Text)
                Dim prm11 As SqlParameter = cmd.Parameters.Add("@pch_code_id", SqlDbType.Int, 255)
                prm11.Value = m_PchCodeId
                Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                prm15.Value = My.Settings.UserName
                Dim prm16 As SqlParameter = cmd.Parameters.Add("@prequest_id", SqlDbType.Int, 255)
                prm16.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_PRequestId = prm16.Value
                cn.Close()
                If isGetNum = True Then UpdSysNumber("preq")
                txtPRequestNo.ReadOnly = True
            End If

            If txtPRequestDtlDesc.Text = "" Then
                MsgBox("Line Description are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtPRequestDtlDesc.Focus()
                Exit Sub
            End If

            If cmbPRequestDtlType.Items(cmbPRequestDtlType.SelectedIndex).ItemData = "S" And (m_SKUId = 0 Or m_LocationId = 0) Then
                MsgBox("Stock and Location are primary fields that should be entered. Please select before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtPRequestDtlDesc.Focus()
                Exit Sub
            End If

            cmd = New SqlCommand(IIf(m_PRequestDId = 0, "usp_tr_prequest_dtl_INS", "usp_tr_prequest_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm17 As SqlParameter = cmd.Parameters.Add("@prequest_id", SqlDbType.Int, 255)
            prm17.Value = m_PRequestId
            Dim prm18 As SqlParameter = cmd.Parameters.Add("@prequest_dtl_type", SqlDbType.NVarChar, 50)
            prm18.Value = cmbPRequestDtlType.Items(cmbPRequestDtlType.SelectedIndex).ItemData
            Dim prm19 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int, 255)
            prm19.Value = IIf(cmbPRequestDtlType.Items(cmbPRequestDtlType.SelectedIndex).ItemData = "S", m_SKUId, 0)
            Dim prm20 As SqlParameter = cmd.Parameters.Add("@prequest_dtl_desc", SqlDbType.NVarChar, 255)
            prm20.Value = IIf(txtPRequestDtlDesc.Text = "", DBNull.Value, txtPRequestDtlDesc.Text)
            Dim prm21 As SqlParameter = cmd.Parameters.Add("@prequest_qty", SqlDbType.Int, 255)
            prm21.Value = IIf(ntbPRequestQty.Text = "", 0, CInt(ntbPRequestQty.Text))
            Dim prm22 As SqlParameter = cmd.Parameters.Add("@expense_id", SqlDbType.Int, 255)
            prm22.Value = IIf(cmbPRequestDtlType.Items(cmbPRequestDtlType.SelectedIndex).ItemData = "E", m_SKUId, 0)
            Dim prm23 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int, 255)
            prm23.Value = m_LocationId

            If m_PRequestDId <> 0 Then
                Dim prm24 As SqlParameter = cmd.Parameters.Add("@prequest_dtl_id", SqlDbType.Int, 255)
                prm24.Value = m_PRequestDId
            End If
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()

            If btnApprove.Enabled = False Then btnApprove.Enabled = True

        Catch ex As Exception
            If Err.Number = 5 Then
                MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
            Else
                MsgBox(ex.Message)
            End If
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD.Click
        If m_PRequestDId = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_tr_prequest_dtl_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@prequest_dtl_id", SqlDbType.Int, 50)
            prm1.Value = m_PRequestDId

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()
        End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1.SelectedItems.Item(0)
            m_PRequestDId = LeftSplitUF(.Tag)
            m_PRequestDtlType = .SubItems.Item(1).Text
            Dim mList As clsMyListStr
            Dim i As Integer
            For i = 1 To cmbPRequestDtlType.Items.Count + 1
                mList = cmbPRequestDtlType.Items(i - 1)
                If m_PRequestDtlType = mList.ItemData Then
                    cmbPRequestDtlType.SelectedIndex = i - 1
                    Exit For
                End If
            Next

            m_SKUId = .SubItems.Item(3).Text
            txtSKUCode.Text = .SubItems.Item(4).Text
            txtPRequestDtlDesc.Text = .SubItems.Item(5).Text
            m_LocationId = .SubItems.Item(6).Text
            txtLocationCode.Text = .SubItems.Item(7).Text
            ntbPRequestQty.Text = .SubItems.Item(8).Text
            txtSKUUoM.Text = .SubItems.Item(9).Text
        End With
    End Sub

    Private Sub cmbPODtlType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPRequestDtlType.SelectedIndexChanged
        If Not btnAddD.Enabled = True Then Exit Sub
        Select Case cmbPRequestDtlType.Items(cmbPRequestDtlType.SelectedIndex).ItemData
            Case "T"
                'txtSKUCode.ReadOnly = True
                m_SKUId = 0
                txtSKUCode.Text = ""
                btnSKU.Enabled = False
                ntbPRequestQty.ReadOnly = True
                ntbPRequestQty.Text = IIf(cmbPRequestDtlType.Items(cmbPRequestDtlType.SelectedIndex).ItemData = "E", "1", "0")

            Case "S", "E"
                If Not btnCancel.Enabled = False Then
                    'txtSKUCode.ReadOnly = False
                    btnSKU.Enabled = True
                    btnLocation.Enabled = True
                    If cmbPRequestDtlType.Items(cmbPRequestDtlType.SelectedIndex).ItemData = "E" Then ntbPRequestQty.ReadOnly = True Else ntbPRequestQty.ReadOnly = False
                    If cmbPRequestDtlType.Items(cmbPRequestDtlType.SelectedIndex).ItemData = "E" Then ntbPRequestQty.Text = "1" Else ntbPRequestQty.Text = "0"
                End If
        End Select
    End Sub

    Private Sub btnAddD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddD.Click
        clear_objD()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Pch_Request_Form '" & txtPRequestNo.Text & "'"
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "PO_Request")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_PCH_Request_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Purchase Request"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("PO_Request"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        btnSave_Click(sender, e)
        m_PRequestStatus = "A"

        cmd = New SqlCommand("usp_tr_prequest_APPROVAL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@prequest_id", SqlDbType.Int)
        prm1.Value = m_PRequestId
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@prequest_status", SqlDbType.NVarChar, 50)
        prm2.Value = m_PRequestStatus
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
        prm3.Value = My.Settings.UserName

        cn.Open()
        cmd.ExecuteReader()
        cn.Close()

        For i = 0 To m_PRequestStatusArr.GetUpperBound(0)
            If m_PRequestStatus = m_PRequestStatusArr(i, 0) Then
                txtPRequestStatus.Text = m_PRequestStatusArr(i, 1)
                Exit For
            End If
        Next
        autoRefresh()
    End Sub

    Private Sub btnReject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReject.Click
        btnSave_Click(sender, e)
        m_PRequestStatus = "R"

        cmd = New SqlCommand("usp_tr_prequest_APPROVAL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@prequest_id", SqlDbType.Int)
        prm1.Value = m_PRequestId
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@prequest_status", SqlDbType.NVarChar, 50)
        prm2.Value = m_PRequestStatus
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
        prm3.Value = My.Settings.UserName

        cn.Open()
        cmd.ExecuteReader()
        cn.Close()

        For i = 0 To m_PRequestStatusArr.GetUpperBound(0)
            If m_PRequestStatus = m_PRequestStatusArr(i, 0) Then
                txtPRequestStatus.Text = m_PRequestStatusArr(i, 1)
                Exit For
            End If
        Next
        autoRefresh()
    End Sub

    Private Sub btnPchCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPchCode.Click
        Dim NewFormDialog As New fdlPchCode
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocation.Click
        Dim NewFormDialog As New fdlLocation
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmPRequestApprovalList).Any Then
            Call frmPRequestApprovalList.frmPRequestApprovalListShow(Nothing, EventArgs.Empty)
        End If
    End Sub

End Class
