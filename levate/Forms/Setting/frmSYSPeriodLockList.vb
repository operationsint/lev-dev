Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmSYSPeriodLockList
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_PeriodId As Integer
    Dim isShowAll As Boolean = False
    Dim m_GainLossAccountId As Integer
    Dim m_APAccountId As Integer
    Dim m_ARAccountId As Integer

    Private Sub frmSYSPeriodLockListList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'btnFilter_Click(sender, e)
        With frmSYSPeriod
            txtPeriodName.Text = .txtPeriodName.Text
            txtStartDate.Text = .dtpPeriodStartDate.Value
            txtEndDate.Text = .dtpPeriodEndDate.Value
            m_PeriodId = .PeriodId
            txtAPLocked.Text = .txtLockedAP.Text
            txtARLocked.Text = .txtLockedAR.Text
            txtSKULocked.Text = .txtLockedSKU.Text
            txtBANKLocked.Text = .txtLockedBANK.Text
            txtGLLocked.Text = .txtLockedGL.Text

            clear_lvw1()
            clear_lvw2()
            clear_lvw3()
            clear_lvw4()

            lblRecordCountAP.Text = lblRecordCountAP.Text & " " & ListView1.Items.Count.ToString & " records found"
            lblRecordCountAR.Text = lblRecordCountAR.Text & " " & ListView2.Items.Count.ToString & " records found"
            lblRecordCountSKU.Text = lblRecordCountSKU.Text & " " & ListView3.Items.Count.ToString & " records found"
            lblRecordCountBANK.Text = lblRecordCountBANK.Text & " " & ListView4.Items.Count.ToString & " records found"

            If ListView1.Items.Count = 0 And .isLockedAP = False Then btnLockAP.Enabled = True Else btnLockAP.Enabled = False
            If ListView2.Items.Count = 0 And .isLockedAR = False Then btnLockAR.Enabled = True Else btnLockAR.Enabled = False
            'If ListView3.Items.Count = 0 And .isLockedSKU = False Then btnLockSKU.Enabled = True Else btnLockSKU.Enabled = False
            If ListView4.Items.Count = 0 And .isLockedBANK = False Then btnLockBANK.Enabled = True Else btnLockBANK.Enabled = False

            'If .isLockedAP = False And .isLockedAR = False Then btnLockSKU.Enabled = False Else btnLockSKU.Enabled = True
            If .isLockedAP = False And .isLockedAR = False Then btnLockBANK.Enabled = False Else btnLockBANK.Enabled = True

            If ListView3.Items.Count = 0 And .isLockedSKU = False And .isLockedAP = True And .isLockedAR = True Then
                btnLockSKU.Enabled = True
            Else
                btnLockSKU.Enabled = False
            End If

            If ListView4.Items.Count = 0 And .isLockedBANK = False And .isLockedAP = True And .isLockedAR = True Then
                btnLockBANK.Enabled = True
            Else
                btnLockBANK.Enabled = False
            End If

            If .isLockedSKU = True And .isLockedBANK = True Then btnLockGL.Enabled = True Else btnLockGL.Enabled = False
        End With
    End Sub

    Public Property PeriodId() As Integer
        Get
            Return m_PeriodId
        End Get
        Set(ByVal Value As Integer)
            m_PeriodId = Value
        End Set
    End Property

    Private Sub ListView1_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs)
        If (e.Column = ListView1Sorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending) Then
                ListView1Sorter.Order = Windows.Forms.SortOrder.Descending
            Else
                ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            ListView1Sorter.SortColumn = e.Column
            ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending
        End If

        ' Perform the sort with these new sort options.
        ListView1.Sort()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Sub clear_lvw1()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Trans No.", 90)
            .Columns.Add("Trans Date", 90)
            .Columns.Add("trans_type", 0)
            .Columns.Add("Trans Type", 90)
            .Columns.Add("Supplier Code", 90)
            .Columns.Add("Supplier Name", 200)
            .Columns.Add("Local Total", 120, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("usp_qry_trans_open_ap_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
        prm1.Value = m_PeriodId

        cn.Open()
        'Call FillList(myReader, Me.ListView1, 6, 0)
        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        Dim lvItem As ListViewItem
        Dim i As Integer, intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0))) 'trans_no
            For i = 1 To 5 'trans_date, trans_type, trans_type_name, s_code, s_name
                If myReader.Item(i) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(i))
                End If
            Next
            lvItem.SubItems.Add(FormatNumber(myReader.Item(6))) 'local_total
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
    End Sub

    Sub clear_lvw2()
        With ListView2
            .Clear()
            .View = View.Details
            .Columns.Add("Trans No.", 90)
            .Columns.Add("Trans Date", 90)
            .Columns.Add("trans_type", 0)
            .Columns.Add("Trans Type", 90)
            .Columns.Add("Customer Code", 90)
            .Columns.Add("Customer Name", 200)
            .Columns.Add("Local Total", 120, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("usp_qry_trans_open_ar_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
        prm1.Value = m_PeriodId

        cn.Open()
        'Call FillList(myReader, Me.ListView1, 6, 0)
        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        Dim lvItem As ListViewItem
        Dim i As Integer, intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0))) 'trans_no
            For i = 1 To 5 'trans_date, trans_type, trans_type_name, c_code, c_name
                If myReader.Item(i) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(i))
                End If
            Next
            lvItem.SubItems.Add(FormatNumber(myReader.Item(6))) 'local_total
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
    End Sub

    Sub clear_lvw3()
        With ListView3
            .Clear()
            .View = View.Details
            .Columns.Add("Trans No.", 90)
            .Columns.Add("Trans Date", 90)
            .Columns.Add("trans_type", 0)
            .Columns.Add("Trans Type", 90)
            .Columns.Add("Local Total", 120, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("usp_qry_trans_open_sku_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
        prm1.Value = m_PeriodId

        cn.Open()
        'Call FillList(myReader, Me.ListView1, 6, 0)
        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        Dim lvItem As ListViewItem
        Dim i As Integer, intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0))) 'trans_no
            For i = 1 To 3 'trans_date, trans_type, trans_type_name
                If myReader.Item(i) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(i))
                End If
            Next
            lvItem.SubItems.Add(FormatNumber(myReader.Item(4))) 'local_total
            If intCurrRow Mod 2 = 0 Then
                lvItem.BackColor = Color.Lavender
            Else
                lvItem.BackColor = Color.White
            End If
            lvItem.UseItemStyleForSubItems = True

            ListView3.Items.Add(lvItem)
            intCurrRow += 1
        End While
        myReader.Close()
        cn.Close()
    End Sub

    Sub clear_lvw4()
        With ListView4
            .Clear()
            .View = View.Details
            .Columns.Add("Trans No.", 90)
            .Columns.Add("Trans Date", 90)
            .Columns.Add("trans_type", 0)
            .Columns.Add("Trans Type", 90)
            .Columns.Add("Local Total", 120, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("usp_qry_trans_open_bank_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
        prm1.Value = m_PeriodId

        cn.Open()
        'Call FillList(myReader, Me.ListView1, 6, 0)
        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        Dim lvItem As ListViewItem
        Dim i As Integer, intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0))) 'trans_no
            For i = 1 To 3 'trans_date, trans_type, trans_type_name
                If myReader.Item(i) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(i))
                End If
            Next
            lvItem.SubItems.Add(FormatNumber(myReader.Item(4))) 'local_total
            If intCurrRow Mod 2 = 0 Then
                lvItem.BackColor = Color.Lavender
            Else
                lvItem.BackColor = Color.White
            End If
            lvItem.UseItemStyleForSubItems = True

            ListView4.Items.Add(lvItem)
            intCurrRow += 1
        End While
        myReader.Close()
        cn.Close()
    End Sub

    Private Sub btnLockAP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLockAP.Click
        If ListView1.Items.Count > 0 Then
            MsgBox("Please post transaction below!", vbCritical)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor 'change pointer/cursor into hourglass
        Try
            Dim is_lock_previous_period As Boolean
            'Check is_lock for previous period
            cmd = New SqlCommand("usp_sys_period_SEL_ByIsLock", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
            prm1.Value = m_PeriodId

            cn.Open()
            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            While myReader.Read
                is_lock_previous_period = myReader.GetBoolean(1) 'is_locked_ap
            End While
            cn.Close()

            If is_lock_previous_period = False Then
                MsgBox("Previous period open. Please close previous period before working on this one.", vbExclamation + vbOKOnly, Me.Text)
                Exit Sub
            Else
                cmd = New SqlCommand("usp_sys_period_lock_AP", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm6 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
                prm6.Value = m_PeriodId
                Dim prm7 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar)
                prm7.Value = My.Settings.UserName

                cn.Open()
                cmd.CommandTimeout = CInt(GetSysInit("db_timeout"))
                cmd.ExecuteReader()
                cn.Close()

                btnLockAP.Enabled = False
                With frmSYSPeriod
                    .isLockedAP = True
                    txtAPLocked.Text = .txtLockedAP.Text
                    If .isLockedAR = True And .isLockedAP = True And .isLockedSKU = False And ListView3.Items.Count = 0 Then btnLockSKU.Enabled = True
                    If .isLockedAR = True And .isLockedAP = True And .isLockedSKU = False And ListView4.Items.Count = 0 Then btnLockBANK.Enabled = True
                End With
                MsgBox("Closing purchase transaction success!", vbInformation)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub btnLockAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLockAR.Click
        If ListView2.Items.Count > 0 Then
            MsgBox("Please post transaction below!", vbCritical)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor 'change pointer/cursor into hourglass
        Try
            Dim is_lock_previous_period As Boolean
            'Check is_lock for previous period
            cmd = New SqlCommand("usp_sys_period_SEL_ByIsLock", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
            prm1.Value = m_PeriodId

            cn.Open()
            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            While myReader.Read
                is_lock_previous_period = myReader.GetBoolean(2) 'is_locked_ar
            End While
            cn.Close()

            If is_lock_previous_period = False Then
                MsgBox("Previous period open. Please close previous period before working on this one.", vbExclamation + vbOKOnly, Me.Text)
                Exit Sub
            Else
                cmd = New SqlCommand("usp_sys_period_lock_AR", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm6 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
                prm6.Value = m_PeriodId
                Dim prm7 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar)
                prm7.Value = My.Settings.UserName

                cn.Open()
                cmd.CommandTimeout = CInt(GetSysInit("db_timeout"))
                cmd.ExecuteReader()
                cn.Close()

                btnLockAR.Enabled = False
                With frmSYSPeriod
                    .isLockedAR = True
                    txtARLocked.Text = .txtLockedAR.Text
                    If .isLockedAR = True And .isLockedAP = True And .isLockedSKU = False And ListView3.Items.Count = 0 Then btnLockSKU.Enabled = True
                    If .isLockedAR = True And .isLockedAP = True And .isLockedBANK = False And ListView4.Items.Count = 0 Then btnLockBANK.Enabled = True
                End With
                MsgBox("Closing sales transaction success!", vbInformation)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub btnLockGL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLockGL.Click
        Cursor = Cursors.WaitCursor 'change pointer/cursor into hourglass
        Dim is_UnrealizedGainLoss As Boolean
        is_UnrealizedGainLoss = GetSysInit("unrealized_gain_loss")
        If GetSysInit("unrealized_gain_loss") = 1 Then
            m_GainLossAccountId = GetSysAccount("forex_gain_loss_unrealized")
            m_APAccountId = GetSysAccount("supplier_ap")
            m_ARAccountId = GetSysAccount("customer_ar")
        End If
        If is_UnrealizedGainLoss = True And (m_GainLossAccountId = 0 Or m_APAccountId = 0 Or m_ARAccountId = 0) Then
            MsgBox("Please make sure you have defined the Unrealized Gain/Loss account in System account.", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If
        Try
            Dim is_lock_previous_period As Boolean
            'Check is_lock for previous period
            cmd = New SqlCommand("usp_sys_period_SEL_ByIsLock", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
            prm1.Value = m_PeriodId

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            While myReader.Read
                is_lock_previous_period = myReader.GetBoolean(5) 'is_locked_gl
            End While
            cn.Close()

            If is_lock_previous_period = False Then
                MsgBox("Previous period open. Please close previous period before working on this one.", vbExclamation + vbOKOnly, Me.Text)
                Exit Sub
            Else
                cmd = New SqlCommand("usp_sys_period_lock_GL", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm6 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
                prm6.Value = m_PeriodId
                Dim prm7 As SqlParameter = cmd.Parameters.Add("@gainloss_account_id", SqlDbType.Int)
                prm7.Value = m_GainLossAccountId
                Dim prm8 As SqlParameter = cmd.Parameters.Add("@ap_account_id", SqlDbType.Int)
                prm8.Value = m_APAccountId
                Dim prm9 As SqlParameter = cmd.Parameters.Add("@ar_account_id", SqlDbType.Int)
                prm9.Value = m_ARAccountId
                Dim prm11 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar)
                prm11.Value = My.Settings.UserName

                cn.Open()
                cmd.CommandTimeout = CInt(GetSysInit("db_timeout"))
                cmd.ExecuteReader()
                cn.Close()

                btnLockGL.Enabled = False
                With frmSYSPeriod
                    .isLockedGL = True
                    txtGLLocked.Text = .txtLockedGL.Text
                    .isClosed = True
                End With
                MsgBox("Closing ledger transaction success!", vbInformation)
            End If

            autoRefresh()

        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub btnLockSKU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLockSKU.Click
        If ListView3.Items.Count > 0 Then
            MsgBox("Please post transaction below!", vbCritical)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor 'change pointer/cursor into hourglass
        Try
            Dim is_lock_previous_period As Boolean
            'Check is_lock for previous period
            cmd = New SqlCommand("usp_sys_period_SEL_ByIsLock", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
            prm1.Value = m_PeriodId

            cn.Open()
            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            While myReader.Read
                is_lock_previous_period = myReader.GetBoolean(3) 'is_locked_sku
            End While
            cn.Close()

            If is_lock_previous_period = False Then
                MsgBox("Previous period open. Please close previous period before working on this one.", vbExclamation + vbOKOnly, Me.Text)
                Exit Sub
            Else
                cmd = New SqlCommand("usp_sys_period_lock_SKU", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm6 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
                prm6.Value = m_PeriodId
                Dim prm7 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar)
                prm7.Value = My.Settings.UserName

                cn.Open()
                cmd.CommandTimeout = CInt(GetSysInit("db_timeout"))
                cmd.ExecuteReader()
                cn.Close()

                btnLockSKU.Enabled = False
                With frmSYSPeriod
                    .isLockedSKU = True
                    txtSKULocked.Text = .txtLockedSKU.Text
                End With
                'btnLockGL.Enabled = True
                Validation()
                MsgBox("Closing stock transaction success!", vbInformation)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub btnLockBANK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLockBANK.Click
        If ListView4.Items.Count > 0 Then
            MsgBox("Please post transaction below!", vbCritical)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor 'change pointer/cursor into hourglass
        Try
            Dim is_lock_previous_period As Boolean
            'Check is_lock for previous period
            cmd = New SqlCommand("usp_sys_period_SEL_ByIsLock", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
            prm1.Value = m_PeriodId

            cn.Open()
            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            While myReader.Read
                is_lock_previous_period = myReader.GetBoolean(4) 'is_locked_bank
            End While
            cn.Close()

            If is_lock_previous_period = False Then
                MsgBox("Previous period open. Please close previous period before working on this one.", vbExclamation + vbOKOnly, Me.Text)
                Exit Sub
            Else
                cmd = New SqlCommand("usp_sys_period_lock_BANK", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm6 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
                prm6.Value = m_PeriodId
                Dim prm7 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar)
                prm7.Value = My.Settings.UserName

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()

                btnLockBANK.Enabled = False
                With frmSYSPeriod
                    .isLockedBANK = True
                    txtBANKLocked.Text = .txtLockedBANK.Text
                End With
                'btnLockGL.Enabled = True
                Validation()
                MsgBox("Closing bank transaction success!", vbInformation)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        Cursor = Cursors.Default
    End Sub

    Sub Validation() 'For validation btnGL enabled or disabled (hendra)
        Dim lockSKU, lockBank As Boolean
        cmd = New SqlCommand("select is_locked_sku,is_locked_bank from sys_period where period_id = " + CStr(m_PeriodId), cn)

        cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            lockSKU = myReader.GetBoolean(0) 'sku
            lockBank = myReader.GetBoolean(1) 'bank
        End While
        cn.Close()

        If lockSKU = True And lockBank = True Then
            btnLockGL.Enabled = True
        Else
            btnLockGL.Enabled = False
        End If
    End Sub

    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmSYSPeriodList).Any Then
            Call frmSYSPeriodList.frmSYSPeriodListShow(Nothing, EventArgs.Empty)
        End If
    End Sub
End Class
