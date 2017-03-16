Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmSupplierAdj
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
    Dim m_PReceiveId As Integer
    Dim m_PReceiveDId As Integer
    Dim m_PODtlType As String
    Dim m_SKUId As Integer
    Dim m_LocationId As Integer
    Dim m_PInvoiceTaxPercent As Single
    Dim m_CurrId As Integer
    Dim m_CurrBaseId As Integer
    Dim m_PchCodeId As Integer = 0
    Dim m_POID As Integer
    Dim m_PInvoiceNetAmt As Double
    Dim isGetNum As Boolean
    Dim isAllowDelete As Boolean
    Private docPO As ReportDocument
    Dim Dec As Integer = GetSysInit("decimal_digit")
    Dim m_Amount_before, m_Amount_local_before, m_Local_Revaluation_before As Double

    '20160626 period id
    Dim m_Period_Id As Integer

    Private Sub frmSupplierAdj_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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


        If m_PInvoiceId = 0 Then
            btnAdd_Click(sender, e)
        Else
            view_record()
            lock_obj(True)
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

    Sub clear_obj()
        m_PInvoiceId = 0
        m_SId = 0
        m_CurrId = 0
        txtSupplierAdjNo.Text = ""
        dtpSupplierAdjDate.Value = FormatDateTime(Now, DateFormat.ShortDate)
        txtRefNo.Text = ""
        txtSCode.Text = ""
        txtSName.Text = ""
        txtCurrCode.Text = ""
        ntbPInvCurrRate.Text = FormatNumber("1")
        txtRefNo.Text = ""
        txtRemarks.Text = ""
        m_PInvStatus = m_PInvStatusArr(0, 0)
        ntbAmount.Text = FormatNumber(0, 2)
        ntbLocalAmount.Text = FormatNumber(0, 2)
        isGetNum = True
        cbRevaluation.Checked = False
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        dtpSupplierAdjDate.Enabled = Not isLock
        txtRefNo.ReadOnly = isLock
        ntbPInvCurrRate.ReadOnly = isLock
        txtRemarks.ReadOnly = isLock
        ntbAmount.ReadOnly = isLock
        ntbLocalAmount.ReadOnly = isLock

        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
        btnPrint.Enabled = isLock

        If m_PInvoiceId = 0 Then
            txtSupplierAdjNo.ReadOnly = False
            btnSupplier.Enabled = True
            btnDelete.Enabled = isLock
            cbRevaluation.Enabled = True
        Else
            txtSupplierAdjNo.ReadOnly = True
            btnSupplier.Enabled = False
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
            cbRevaluation.Enabled = False
        End If
    End Sub

    Sub view_record()
        cmd = New SqlCommand("usp_tr_supplier_adj_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@supplier_adj_id", SqlDbType.Int)
        prm1.Value = m_PInvoiceId

        cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtSupplierAdjNo.Text = myReader.GetString(1)
            dtpSupplierAdjDate.Value = myReader.GetDateTime(2)
            m_SId = myReader.GetInt32(7)
            txtSCode.Text = myReader.GetString(3)
            txtSName.Text = myReader.GetString(4)
            ntbAmount.Text = FormatNumber(myReader.GetValue(5))
            m_Amount_before = CDbl(myReader.GetValue(5))
            m_Amount_local_before = CDbl(myReader.GetValue(6))
            m_Local_Revaluation_before = CDbl(myReader.GetValue(14))
            'ntbLocalAmount.Text = IIf(CInt(myReader.GetValue(13)) < 2, FormatNumber(myReader.GetValue(6)), FormatNumber(myReader.GetValue(14)))
            If myReader.GetInt32(13) < 2 Then
                ntbLocalAmount.Text = FormatNumber(myReader.GetValue(6))
                cbRevaluation.Checked = False
            Else
                ntbLocalAmount.Text = FormatNumber(myReader.GetValue(14))
                cbRevaluation.Checked = True
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("ref_no")) Then
                txtRefNo.Text = myReader.GetString(myReader.GetOrdinal("ref_no"))
            Else
                txtRefNo.Text = ""
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("pinvoice_remarks")) Then
                txtRemarks.Text = myReader.GetString(myReader.GetOrdinal("pinvoice_remarks"))
            Else
                txtRemarks.Text = ""
            End If
            m_CurrId = myReader.GetInt32(10)
            txtCurrCode.Text = myReader.GetString(11)
            ntbPInvCurrRate.Text = FormatNumber(myReader.GetValue(12))
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        m_PInvoiceId = 0
        clear_obj()
        lock_obj(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_PInvoiceId = 0 Then
            Me.Close()
        Else
            lock_obj(True)
            m_PInvoiceDId = 0
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtSCode.Text = "" Then
            MsgBox("Please insert supplier code!", MsgBoxStyle.Critical)
            btnSupplier.Focus()
            Exit Sub
        End If

        '20160626 check and assign period_id
        m_Period_Id = 0
        cmd = New SqlCommand("select period_id from sys_period where period_type='month_period' and is_closed=0 and @dt between period_start_date and period_end_date", cn)
        cmd.Parameters.AddWithValue("@dt", dtpSupplierAdjDate.Value.Date)
        cn.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        If dr.Read Then
            m_Period_Id = dr.GetInt32(0)
        End If
        dr.Close()
        cn.Close()

        If m_Period_Id = 0 Then
            MsgBox("The transaction date you specified is not within the date range of your accounting period.", MsgBoxStyle.Critical)
            dtpSupplierAdjDate.Focus()
            Exit Sub
        End If

        SavePInvoiceHeader()
        autoRefresh()
    End Sub

    Sub SavePInvoiceHeader()
        Try

            AppLock.GetLock()

            If txtSupplierAdjNo.Text.Trim = "" Then
                txtSupplierAdjNo.Text = GetSysNumber("supplier_adj", Now.Date)
                isGetNum = True
            Else
                isGetNum = False
            End If

            cmd = New SqlCommand(IIf(m_PInvoiceId = 0, "usp_tr_supplier_adj_INS", "usp_tr_supplier_adj_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@pinvoice_no", SqlDbType.NVarChar, 50)
            prm1.Value = txtSupplierAdjNo.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@pinvoice_date", SqlDbType.SmallDateTime)
            prm2.Value = dtpSupplierAdjDate.Value.Date
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
            prm3.Value = m_SId
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)
            prm4.Value = 0
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@pch_code_id", SqlDbType.Int)
            prm5.Value = 0
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@pinvoice_terms", SqlDbType.Int, 50)
            prm6.Value = 0
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@pinvoice_duedate", SqlDbType.SmallDateTime)
            prm7.Value = dtpSupplierAdjDate.Value.Date
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@ref_no", SqlDbType.NVarChar, 50)
            prm8.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@pinvoice_remarks", SqlDbType.NVarChar)
            prm9.Value = IIf(txtRemarks.Text = "", DBNull.Value, txtRemarks.Text)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
            prm10.Value = m_CurrId
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@pinvoice_curr_rate", SqlDbType.Money)
            prm11.Value = FormatNumber(ntbPInvCurrRate.Text)
            Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm15.Value = My.Settings.UserName
            Dim prm17 As SqlParameter = cmd.Parameters.Add("@is_adjustment", SqlDbType.Int)
            Dim prm18 As SqlParameter = cmd.Parameters.Add("@local_revaluation", SqlDbType.Decimal)
            Dim prm19 As SqlParameter = cmd.Parameters.Add("@pinvoice_total", SqlDbType.Decimal)
            prm19.Value = CDec(ntbAmount.Text)
            Dim prm20 As SqlParameter = cmd.Parameters.Add("@pinvoice_status", SqlDbType.NVarChar, 50)
            If cbRevaluation.Checked = True Then
                prm17.Value = 2
                prm18.Value = CDec(ntbLocalAmount.Text)
                prm20.Value = ""
            Else
                prm17.Value = 1
                prm18.Value = 0.0
                prm20.Value = "UP"
            End If

            '20160626 add period id
            Dim prm16a As SqlParameter = cmd.Parameters.AddWithValue("@pinvoice_period_id", m_Period_Id)

            Dim prm16 As SqlParameter = cmd.Parameters.Add("@pinvoice_id", SqlDbType.Int)

            If m_PInvoiceId = 0 Then
                prm16.Direction = ParameterDirection.Output

                cn.Open()
                cmd.ExecuteReader()
                m_PInvoiceId = prm16.Value
                cn.Close()
                If isGetNum = True Then UpdSysNumber("supplier_adj")
            Else
                prm16.Value = m_PInvoiceId

                Dim prm25 As SqlParameter = cmd.Parameters.Add("@pinvoice_total_before", SqlDbType.Decimal)
                prm25.Value = m_Amount_before
                Dim prm26 As SqlParameter = cmd.Parameters.Add("@pinvoice_total_local_before", SqlDbType.Decimal)
                prm26.Value = m_Amount_local_before
                Dim prm27 As SqlParameter = cmd.Parameters.Add("@local_revaluation_before", SqlDbType.Decimal)
                prm27.Value = m_Local_Revaluation_before

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
            End If
            lock_obj(True)
            view_record()
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        Finally
            AppLock.ReleaseLock()
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            Try

                AppLock.GetLock()

                cmd = New SqlCommand("usp_tr_supplier_adj_DEL", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@pinvoice_id", SqlDbType.Int)
                prm1.Value = m_PInvoiceId
                Dim prm2 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
                prm2.Value = m_SId
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@pinvoice_curr_rate", SqlDbType.Money)
                prm3.Value = CDbl(ntbPInvCurrRate.Text)
                Dim prm4 As SqlParameter = cmd.Parameters.Add("@is_adjustment", SqlDbType.Int)
                Dim prm5 As SqlParameter = cmd.Parameters.Add("@pinvoice_total", SqlDbType.Decimal)
                prm5.Value = FormatNumber(ntbAmount.Text)
                Dim prm6 As SqlParameter = cmd.Parameters.Add("@local_revaluation", SqlDbType.Decimal)
                If cbRevaluation.Checked = True Then
                    prm4.Value = 2
                    prm6.Value = CDec(ntbLocalAmount.Text)
                Else
                    prm4.Value = 1
                    prm6.Value = 0.0
                End If
                Dim prm16 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                prm16.Value = My.Settings.UserName

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
                btnAdd_Click(sender, e)
            Catch ex As Exception
                MsgBox(ex.Message)
                If ConnectionState.Open = 1 Then cn.Close()
            Finally
                AppLock.ReleaseLock()
            End Try
        End If
        autoRefresh()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = "exec RPT_Sup_Adj_Form '" & txtSupplierAdjNo.Text & "'"
        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SupAdj_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sup_Adj_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Supplier Adjustment Balance"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("SupAdj_"))
        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub ntbPInvCurrRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPInvCurrRate.LostFocus
        If CDbl(ntbPInvCurrRate.Text) < 0 Then
            ntbPInvCurrRate.Text = CDbl(ntbPInvCurrRate.Text) * -1
        End If
        If ntbPInvCurrRate.Text.Length = 0 Then ntbPInvCurrRate.Undo()
        If m_PInvoiceId = 0 Then
            If m_CurrId = m_CurrBaseId Then
                ntbPInvCurrRate.Text = "1"
            Else
                If ntbPInvCurrRate.DecimalValue = 0 Then ntbPInvCurrRate.Undo()
            End If
        End If
        ntbPInvCurrRate.Text = FormatNumber(ntbPInvCurrRate.Text)
        refreshAmount()
    End Sub

    Private Sub ntbAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbAmount.LostFocus
        refreshAmount()
    End Sub

    Private Sub ntbLocalAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbLocalAmount.LostFocus
        refreshAmount()
    End Sub

    Private Sub cbRevaluation_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRevaluation.CheckedChanged
        refreshAmount()
    End Sub

    Sub refreshAmount()
        If cbRevaluation.Checked = False Then
            ntbLocalAmount.Text = CDbl(ntbAmount.Text) * CDbl(ntbPInvCurrRate.Text)
        Else
            ntbAmount.Text = 0
        End If
    End Sub

    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmSupplierAdjList).Any Then
            Call frmSupplierAdjList.frmSupplierAdjListShow(Nothing, EventArgs.Empty)
        End If
    End Sub
End Class