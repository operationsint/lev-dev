Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmPReceive
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_PReceiveId As Integer
    Dim m_PReceiveDId As Integer
    Dim m_POId As Integer
    Dim m_PODId As Integer
    Dim m_PeriodId As Integer
    Dim m_SId As Integer
    Dim m_POStatus As String
    Dim m_PReceiveStatus As String
    Dim m_PReceiveStatusArr(1, 1) As String
    Dim m_PeriodArr(0, 0) As String
    Dim m_PeriodArrSelected As Integer
    Dim m_PODtlType As String
    Dim m_LocationId As Integer
    Dim m_LocationIdBefore As Integer
    Dim m_PReceiveQtyBefore As Double
    Dim isAllowDelete As Boolean
    Dim isGetNum As Boolean
    Dim isPosted As Boolean
    Private docPR As ReportDocument

    Private Sub frmPReceive_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim prm1 As SqlParameter
        Dim prm2 As SqlParameter
        Dim myReader As SqlDataReader
        isAllowDelete = canDelete(Me.Name + "List")

        'Add item cmbPOStatus
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "preceive_status"

        cn.Open()
        myReader = cmd.ExecuteReader
        Dim i As Integer = 0

        While myReader.Read
            m_PReceiveStatusArr(i, 0) = myReader.GetString(0)
            m_PReceiveStatusArr(i, 1) = myReader.GetString(1)
            i += 1
        End While

        myReader.Close()
        cn.Close()

        'Add item cmbPeriodId
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

        If m_PReceiveId = 0 Then
            btnAdd_Click(sender, e)
        Else
            m_PReceiveDId = 0
            view_record()
            clear_lvw()
            'btnEdit_Click(sender, e)
            clear_objD()
            lock_obj(True)
            lock_objD(True)
        End If
    End Sub

    Private Sub btnPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPO.Click
        Dim NewFormDialog As New fdlPOOut
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Public Property PReceiveId() As Integer
        Get
            Return m_PReceiveId
        End Get
        Set(ByVal Value As Integer)
            m_PReceiveId = Value
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
            Return txtPReceiveRemarks.Text
        End Get
        Set(ByVal Value As String)
            txtPReceiveRemarks.Text = Value
        End Set
    End Property

    Public Property PODId() As Integer
        Get
            Return m_PODId
        End Get
        Set(ByVal Value As Integer)
            m_PODId = Value
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
            Return txtPODtlDesc.Text
        End Get
        Set(ByVal Value As String)
            txtPODtlDesc.Text = Value
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

    Public Property PreviousPRQty() As Integer
        Get
            Return txtPreviousQty.Text
        End Get
        Set(ByVal Value As Integer)
            txtPreviousQty.Text = Value
        End Set
    End Property

    Public Property PRQty() As Integer
        Get
            Return ntbPReceiveQty.Text
        End Get
        Set(ByVal Value As Integer)
            ntbPReceiveQty.Text = Value
        End Set
    End Property

    Public Property PRQtyOutstanding() As Integer
        Get
            Return txtPRRemainQty.Text
        End Get
        Set(ByVal Value As Integer)
            txtPRRemainQty.Text = Value
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

    Sub clear_obj()
        m_PReceiveId = 0
        m_SId = 0
        txtPReceiveNo.Text = ""
        dtpPReceiveDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtPaymentDueDate.Text = dtpPReceiveDate.Value
        txtPONo.Text = ""
        txtSCode.Text = ""
        txtSName.Text = ""
        txtPReceiveRemarks.Text = ""
        m_PReceiveStatus = m_PReceiveStatusArr(0, 0)
        txtPReceiveStatus.Text = m_PReceiveStatusArr(0, 1)
        isGetNum = True
        isPosted = False
        txtRefNo.Text = ""
    End Sub

    Sub clear_objD()
        m_PReceiveDId = 0
        m_PODId = 0
        m_LocationId = 0
        m_LocationIdBefore = 0
        m_PReceiveQtyBefore = 0
        txtSKUCode.Text = ""
        txtPODtlDesc.Text = ""
        txtPOQty.Text = FormatNumber(0)
        txtPreviousQty.Text = FormatNumber(0)
        ntbPReceiveQty.Text = FormatNumber(0)
        txtPRRemainQty.Text = FormatNumber(0)
        txtSKUUoM.Text = ""
        txtLocationCode.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        dtpPReceiveDate.Enabled = Not isLock
        txtPReceiveRemarks.ReadOnly = isLock
        If Not m_PReceiveStatus = "I" Then btnEdit.Enabled = isLock Else btnEdit.Enabled = False
        If isPosted = True Then btnEdit.Enabled = False
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnPrint.Enabled = isLock
        txtRefNo.ReadOnly = isLock

        If m_PReceiveId = 0 Then
            txtPReceiveNo.ReadOnly = False
            btnPO.Enabled = True
            btnDelete.Enabled = isLock
        Else
            txtPReceiveNo.ReadOnly = True
            btnPO.Enabled = False
            'If p_UserLevel = 1 Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        ntbPReceiveQty.ReadOnly = isLock
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
            .Columns.Add("preceive_id", 0)
            .Columns.Add("po_dtl_type", 0)
            .Columns.Add("Line Type", 90)
            .Columns.Add("po_dtl_id", 0)
            .Columns.Add("Stock Code", 90)
            .Columns.Add("Line Description", 250)
            .Columns.Add("location_id", 0)
            .Columns.Add("Location Code", 90)
            .Columns.Add("Order Qty", 80, HorizontalAlignment.Right)
            .Columns.Add("Prior Rec. Qty", 80, HorizontalAlignment.Right)
            .Columns.Add("Incoming Qty", 80, HorizontalAlignment.Right)
            .Columns.Add("Remaining Qty", 80, HorizontalAlignment.Right)
            .Columns.Add("UoM", 80)
        End With

        If m_PReceiveId <> 0 Then
            'cmd = New SqlCommand(IIf(m_PReceiveId = 0 Or m_POId <> m_POIdTemp, "sp_tr_po_dtl_SEL", "usp_tr_preceive_dtl_SEL"), cn)
            cmd = New SqlCommand("usp_tr_preceive_dtl_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            'Dim prm1 As SqlParameter = cmd.Parameters.Add(IIf(m_PReceiveId = 0 Or m_POId <> m_POIdTemp, "@po_id", "@preceive_id"), SqlDbType.Int)
            'prm1.Value = IIf(m_PReceiveId = 0 Or m_POId <> m_POIdTemp, m_POId, m_PReceiveId)
            Dim prm1 As SqlParameter = cmd.Parameters.Add("@preceive_id", SqlDbType.Int)
            prm1.Value = m_PReceiveId

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            'Call FillList(myReader, Me.ListView1, 12, 1)
            Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(1))) 'preceive_id
                lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
                'lvItem.Tag = "v" & CStr(DR.Item(0))
                For i = 2 To 3 'po_dtl_type, line_type
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next
                lvItem.SubItems.Add(myReader.GetInt32(4)) 'po_dtl_id
                Select Case myReader.GetString(2) 'sku_code
                    Case "S"
                        lvItem.SubItems.Add(myReader.GetString(6))
                    Case "E"
                        lvItem.SubItems.Add(myReader.GetString(21))
                    Case Else
                        lvItem.SubItems.Add("")
                End Select
                For i = 7 To 14 'po_dtl_description, location_id, location_code, po_qty, previous_qty, preceive_qty, remain_qty, sku_uom
                    If myReader.Item(i) Is System.DBNull.Value Then
                        lvItem.SubItems.Add("")
                    Else
                        lvItem.SubItems.Add(myReader.Item(i))
                    End If
                Next
                'lvItem.SubItems.Add(myReader.GetString(6))
                'lvItem.SubItems.Add(myReader.GetInt32(7))
                'lvItem.SubItems.Add(myReader.GetInt32(8))
                'lvItem.SubItems.Add(myReader.GetInt32(9))
                'lvItem.SubItems.Add(myReader.GetInt32(10))
                'For i = 11 To 13
                '    If myReader.Item(i) Is System.DBNull.Value Then
                '        lvItem.SubItems.Add("")
                '    Else
                '        lvItem.SubItems.Add(myReader.Item(i))
                '    End If
                'Next
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
        cmd = New SqlCommand("usp_tr_preceive_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@preceive_id", SqlDbType.Int)
        prm1.Value = m_PReceiveId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtPReceiveNo.Text = myReader.GetString(1)
            dtpPReceiveDate.Value = myReader.GetDateTime(2)
            m_POId = myReader.GetInt32(3)
            txtPONo.Text = myReader.GetString(4)
            m_SId = myReader.GetInt32(5)
            txtSCode.Text = myReader.GetString(6)
            txtSName.Text = myReader.GetString(7)
            txtPaymentDueDate.Text = myReader.GetDateTime(9)
            If Not myReader.IsDBNull(myReader.GetOrdinal("preceive_remarks")) Then
                txtPReceiveRemarks.Text = myReader.GetString(myReader.GetOrdinal("preceive_remarks"))
            Else
                txtPReceiveRemarks.Text = ""
            End If
            'txtPRRemarks.Text = IIf(Not myReader.IsDBNull(myReader.GetOrdinal("preceive_remarks")), myReader.GetString(myReader.GetOrdinal("preceive_remarks")), "")
            m_POStatus = myReader.GetString(11)
            m_PReceiveStatus = myReader.GetString(12)
            txtRefNo.Text = myReader.GetString(14)
            isPosted = myReader.GetBoolean(15)
            m_PeriodId = myReader.GetInt32(16)
        End While

        myReader.Close()
        cn.Close()

        If isPosted = True Then txtPeriodId.Text = GetPeriodName(m_PeriodId)

        For i = 0 To m_PReceiveStatusArr.GetUpperBound(0)
            If m_PReceiveStatus = m_PReceiveStatusArr(i, 0) Then
                txtPReceiveStatus.Text = m_PReceiveStatusArr(i, 1)
                Exit For
            End If
        Next
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_PReceiveId = 0
        m_POId = 0
        m_SId = 0

        clear_obj()
        clear_objD()
        clear_lvw()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_PReceiveId = 0 Then
            Me.Close()
        Else
            lock_obj(True)
            lock_objD(True)
            clear_objD()
            m_PReceiveDId = 0
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If m_POId = 0 Then
                MsgBox("PO # and Supplier information are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtPONo.Focus()
                Exit Sub
            End If

            If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
                MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                Exit Sub
            End If

            If m_PReceiveId = 0 Then
                If txtPReceiveNo.Text.Trim = "" Then
                    txtPReceiveNo.Text = GetSysNumber("prcv", Now.Date)
                    isGetNum = True
                Else
                    isGetNum = False
                End If
            End If

            AppLock.GetLock()

            cmd = New SqlCommand(IIf(m_PReceiveId = 0, "usp_tr_preceive_INS", "usp_tr_preceive_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter
            prm1 = cmd.Parameters.Add("@preceive_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtPReceiveNo.Text
            Dim prm2 As SqlParameter
            prm2 = cmd.Parameters.Add("@preceive_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpPReceiveDate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)
            prm3.Value = m_POId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
            prm4.Value = m_SId
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@preceive_period_id", SqlDbType.Int)
            prm6.Value = m_PeriodArr(m_PeriodArrSelected, 0)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@preceive_remarks", SqlDbType.NVarChar)
            prm10.Value = IIf(txtPReceiveRemarks.Text = "", DBNull.Value, txtPReceiveRemarks.Text)
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm15.Value = My.Settings.UserName
            Dim prm17 As SqlParameter
            prm17 = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
            prm17.Value = txtRefNo.Text
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@preceive_id", SqlDbType.Int)

            If m_PReceiveId = 0 Then
                prm16.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_PReceiveId = prm16.Value
                'MessageBox.Show(m_PReceiveId)
                cn.Close()
                If isGetNum = True Then UpdSysNumber("prcv")
            Else
                prm16.Value = m_PReceiveId
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
        'If m_PReceiveId <> 0 Then btnPO.Enabled = False
        'If m_PReceiveStatus = "I" Then
        '    btnSave.Enabled = False
        '    btnDelete.Enabled = False
        '    lock_objD(True)
        'End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then

            AppLock.GetLock()

            cmd = New SqlCommand("usp_tr_preceive_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@preceive_id", SqlDbType.Int)
            prm1.Value = m_PReceiveId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)
            prm2.Value = m_POId
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm3.Value = My.Settings.UserName

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            AppLock.ReleaseLock()

            btnAdd_Click(sender, e)
        End If
        autoRefresh()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Pch_Incoming_Form '" & txtPReceiveNo.Text & "'"
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "PO_Incoming")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Pch_Incoming_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Purchase Incoming"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("PO_Incoming"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub btnSKU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSKU.Click
        If m_POId = 0 Then
            MsgBox("PO # are primary fields that should be entered. Please enter those fields before you do the selection.", vbCritical + vbOKOnly, Me.Text)
            txtPONo.Focus()
            Exit Sub
        End If

        If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
            MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If

        Dim NewFormDialog As New fdlSKUPOOut
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click
        Try
            If m_PReceiveId = 0 Then
                If m_POId = 0 Then
                    MsgBox("PO #, Supplier Code and Supplier Name are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                    txtPONo.Focus()
                    Exit Sub
                End If

                If m_PeriodId <> m_PeriodArr(m_PeriodArrSelected, 0) Then
                    MsgBox("The transaction date you specified is not within the date range of your accounting period.", vbCritical + vbOKOnly, Me.Text)
                    Exit Sub
                End If

                SavePReceiveHeader()
            End If

            If txtPODtlDesc.Text = "" Then
                MsgBox("Line Description are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtPODtlDesc.Focus()
                Exit Sub
            End If

            If m_PReceiveDId = 0 Then
                MsgBox("Please press the Stock button to select the Stock or at least select an item if you want to update.", vbCritical + vbOKOnly, Me.Text)
                txtSKUCode.Focus()
                Exit Sub
            End If

            AppLock.GetLock()

            cmd = New SqlCommand(IIf(m_PReceiveDId = 0, "usp_tr_preceive_dtl_INS", "usp_tr_preceive_dtl_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@preceive_id", SqlDbType.Int)
            prm1.Value = m_PReceiveId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@po_dtl_id", SqlDbType.Int)
            prm2.Value = m_PODId
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@preceive_qty", SqlDbType.Decimal)
            prm3.Value = ntbPReceiveQty.Text
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@previous_qty", SqlDbType.Decimal)
            prm5.Value = txtPreviousQty.Text
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int)
            prm6.Value = m_LocationId

            If m_PReceiveDId <> 0 Then
                Dim prm10 As SqlParameter = cmd.Parameters.Add("@preceive_dtl_id", SqlDbType.Int)
                prm10.Value = m_PReceiveDId
                Dim prm11 As SqlParameter = cmd.Parameters.Add("@preceive_qty_before", SqlDbType.Decimal)
                prm11.Value = m_PReceiveQtyBefore
                Dim prm12 As SqlParameter = cmd.Parameters.Add("@location_id_before", SqlDbType.Int)
                prm12.Value = m_LocationIdBefore
            End If
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

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
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1.SelectedItems.Item(0)
            m_PReceiveDId = LeftSplitUF(.Tag)
            txtPODtlType.Text = .SubItems.Item(2).Text
            m_PODId = .SubItems.Item(3).Text
            txtSKUCode.Text = .SubItems.Item(4).Text
            txtPODtlDesc.Text = .SubItems.Item(5).Text
            m_LocationId = IIf(.SubItems.Item(6).Text = "", 0, .SubItems.Item(6).Text)
            m_LocationIdBefore = IIf(.SubItems.Item(6).Text = "", 0, .SubItems.Item(6).Text)
            txtLocationCode.Text = IIf(.SubItems.Item(7).Text = "", "", .SubItems.Item(7).Text)
            txtPOQty.Text = .SubItems.Item(8).Text
            txtPreviousQty.Text = .SubItems.Item(9).Text
            m_PReceiveQtyBefore = .SubItems.Item(10).Text
            ntbPReceiveQty.Text = .SubItems.Item(10).Text
            txtPRRemainQty.Text = .SubItems.Item(11).Text
            txtSKUUoM.Text = .SubItems.Item(12).Text

        End With
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub btnDeleteD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteD.Click
        If m_PReceiveDId = 0 Then Exit Sub
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then

            AppLock.GetLock()

            cmd = New SqlCommand("usp_tr_preceive_dtl_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@preceive_dtl_id", SqlDbType.Int)
            prm1.Value = m_PReceiveDId

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            AppLock.ReleaseLock()

            clear_lvw()
            clear_objD()
        End If
    End Sub

    Sub SavePReceiveHeader()
        Try
            AppLock.GetLock()

            If txtPReceiveNo.Text.Trim = "" Then
                txtPReceiveNo.Text = GetSysNumber("prcv", Now.Date)
                isGetNum = True
            Else
                isGetNum = False
            End If

            cmd = New SqlCommand("usp_tr_preceive_INS", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter
            prm1 = cmd.Parameters.Add("@preceive_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtPReceiveNo.Text
            Dim prm2 As SqlParameter
            prm2 = cmd.Parameters.Add("@preceive_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpPReceiveDate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)
            prm3.Value = m_POId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
            prm4.Value = m_SId
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@preceive_period_id", SqlDbType.Int)
            prm6.Value = m_PeriodArr(m_PeriodArrSelected, 0)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@preceive_remarks", SqlDbType.NVarChar)
            prm10.Value = IIf(txtPReceiveRemarks.Text = "", DBNull.Value, txtPReceiveRemarks.Text)
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm15.Value = My.Settings.UserName
            Dim prm17 As SqlParameter
            prm17 = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
            prm17.Value = txtRefNo.Text
            Dim prm16 As SqlParameter = cmd.Parameters.Add("@preceive_id", SqlDbType.Int)
            prm16.Direction = ParameterDirection.Output

            cn.Open()
            cmd.ExecuteReader()
            m_PReceiveId = prm16.Value
            cn.Close()
            If isGetNum = True Then UpdSysNumber("prcv")
            txtPReceiveNo.ReadOnly = True
            btnPO.Enabled = False

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

    Private Sub ntbPReceiveQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPReceiveQty.LostFocus
        If ntbPReceiveQty.Text = "" Then ntbPReceiveQty.Text = FormatNumber(0)
        If CDbl(txtPOQty.Text) - CDbl(txtPreviousQty.Text) - CDbl(ntbPReceiveQty.Text) < 0 Then
            MsgBox("The quantity entered is higher than quantity in Sales Order. Please enter as ordered or less.", vbInformation, Me.Text)
            ntbPReceiveQty.Text = m_PReceiveQtyBefore
        Else
            ntbPReceiveQty.Text = ntbPReceiveQty.Text
        End If
    End Sub

    Private Sub btnLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocation.Click
        Dim NewFormDialog As New fdlLocation
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub Label31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label31.Click

    End Sub

    Private Sub txtLocationCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLocationCode.TextChanged

    End Sub

    Private Sub ntbPReceiveQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbPReceiveQty.TextChanged

    End Sub
    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmPReceiveList).Any Then
            Call frmPReceiveList.frmPReceiveListShow(Nothing, EventArgs.Empty)
        End If
    End Sub

    Private Sub dtpPReceiveDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPReceiveDate.ValueChanged
        Dim isCheckIn As Boolean
        For i = 0 To m_PeriodArr.GetUpperBound(0)
            If dtpPReceiveDate.Value >= m_PeriodArr(i, 2) AndAlso dtpPReceiveDate.Value <= m_PeriodArr(i, 3) Then
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
