Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmSupplier
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_SId As Integer
    Dim m_CurrId As Integer
    Dim isAllowDelete As Boolean

    Private Sub frmSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isAllowDelete = canDelete(Me.Name)

        clear_obj()

        cmbFilterBy.Items.Add("<All>")
        cmbFilterBy.Items.Add("Supplier Code")
        cmbFilterBy.Items.Add("Supplier Name")
        cmbFilterBy.SelectedIndex = 0

        'If ListView1.Items.Count > 0 Then
        '    ListView1.Items.Item(0).Selected = True
        '    ListView1_Click(sender, e)
        'End If
    End Sub

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
            Return txtSCurrCode.Text
        End Get
        Set(ByVal Value As String)
            txtSCurrCode.Text = Value
        End Set
    End Property

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        'If m_SId = 0 And btnAdd.Enabled = False Then lock_obj(True)
        'txtSID.Text = Strings.Mid(ListView1.SelectedItems(0).Tag, 2, Len(ListView1.SelectedItems(0).Tag) - 1)
        With ListView1.SelectedItems.Item(0)
            lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1)) + " of " + ListView1.Items.Count.ToString
            m_SId = LeftSplitUF(.Tag)
            txtSCode.Text = .SubItems.Item(0).Text
            txtSName.Text = .SubItems.Item(1).Text
            txtSAddress1.Text = .SubItems.Item(2).Text
            txtSAddress2.Text = .SubItems.Item(3).Text
            txtSContact.Text = .SubItems.Item(4).Text
            txtSPhone.Text = .SubItems.Item(5).Text
            txtSFax.Text = .SubItems.Item(6).Text
            txtSEmail.Text = .SubItems.Item(7).Text
            txtSPaymentTerm.Text = .SubItems.Item(8).Text
            txtSRemarks.Text = .SubItems.Item(9).Text
            txtSInfo1.Text = .SubItems.Item(10).Text
            txtSInfo2.Text = .SubItems.Item(11).Text
            txtSInfo3.Text = .SubItems.Item(12).Text
            m_CurrId = .SubItems.Item(13).Text
            txtSCurrCode.Text = .SubItems.Item(14).Text
            txtSBalance.Text = FormatNumber(.SubItems.Item(16).Text)
            txtSLocalBalance.Text = FormatNumber(.SubItems.Item(17).Text)
            txtSAdvanceBalance.Text = FormatNumber(.SubItems.Item(18).Text)

            clear_lvw2()
        End With
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then clear_lvw()
    End Sub

    Private Sub cmbFilterBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFilterBy.SelectedIndexChanged
        If cmbFilterBy.SelectedItem.ToString = "<All>" Then
            txtFilter.Text = ""
            If m_SId <> 0 Then clear_obj()
            clear_lvw()
        End If
        btnCancel_Click(sender, e)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        clear_obj()
        lock_obj(False)
        clear_lvw2()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
        If m_SId <> 0 Then txtSCode.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_SId = 0 And ListView1.Items.Count > 0 Then
            ListView1.Items.Item(0).Selected = True
            ListView1_Click(sender, e)
        End If
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo err_cmdSave_Click

        If txtSCode.Text = "" Or txtSName.Text = "" Or txtSCurrCode.Text = "" Then
            MsgBox("Supplier Code, Supplier Name and Supplier Currency are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtSCode.Focus()
            Exit Sub
        End If

        cmd = New SqlCommand(IIf(m_SId = 0, "sp_mt_supplier_INS", "sp_mt_supplier_UPD"), cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm2 As SqlParameter = cmd.Parameters.Add("@s_code", SqlDbType.NVarChar, 50)
        prm2.Value = txtSCode.Text
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@s_name", SqlDbType.NVarChar, 255)
        prm3.Value = txtSName.Text
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@s_address1", SqlDbType.NVarChar, 255)
        prm4.Value = IIf(txtSAddress1.Text = "", DBNull.Value, txtSAddress1.Text)
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@s_address2", SqlDbType.NVarChar, 255)
        prm5.Value = IIf(txtSAddress2.Text = "", DBNull.Value, txtSAddress2.Text)
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@s_contact", SqlDbType.NVarChar, 255)
        prm6.Value = IIf(txtSContact.Text = "", DBNull.Value, txtSContact.Text)
        Dim prm7 As SqlParameter = cmd.Parameters.Add("@s_phone", SqlDbType.NVarChar, 50)
        prm7.Value = IIf(txtSPhone.Text = "", DBNull.Value, txtSPhone.Text)
        Dim prm8 As SqlParameter = cmd.Parameters.Add("@s_fax", SqlDbType.NVarChar, 50)
        prm8.Value = IIf(txtSFax.Text = "", DBNull.Value, txtSFax.Text)
        Dim prm9 As SqlParameter = cmd.Parameters.Add("@s_email", SqlDbType.NVarChar, 50)
        prm9.Value = IIf(txtSEmail.Text = "", DBNull.Value, txtSEmail.Text)
        Dim prm10 As SqlParameter = cmd.Parameters.Add("@s_payment_terms", SqlDbType.Int, 50)
        prm10.Value = IIf(txtSPaymentTerm.Text = "", 0, txtSPaymentTerm.Text)
        Dim prm11 As SqlParameter = cmd.Parameters.Add("@s_remarks", SqlDbType.NVarChar, 255)
        prm11.Value = IIf(txtSRemarks.Text = "", DBNull.Value, txtSRemarks.Text)
        Dim prm12 As SqlParameter = cmd.Parameters.Add("@s_info1", SqlDbType.NVarChar, 255)
        prm12.Value = IIf(txtSInfo1.Text = "", DBNull.Value, txtSInfo1.Text)
        Dim prm13 As SqlParameter = cmd.Parameters.Add("@s_info2", SqlDbType.NVarChar, 255)
        prm13.Value = IIf(txtSInfo2.Text = "", DBNull.Value, txtSInfo2.Text)
        Dim prm14 As SqlParameter = cmd.Parameters.Add("@s_info3", SqlDbType.NVarChar, 255)
        prm14.Value = IIf(txtSInfo3.Text = "", DBNull.Value, txtSInfo3.Text)
        Dim prm15 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
        prm15.Value = My.Settings.UserName
        Dim prm16 As SqlParameter = cmd.Parameters.Add("@s_curr_id", SqlDbType.Int)
        prm16.Value = m_CurrId
        Dim prm1 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int, 255)

        If m_SId = 0 Then
            prm1.Direction = ParameterDirection.Output
            cn.Open()
            cmd.ExecuteReader()
            m_SId = prm1.Value
            cn.Close()
        Else
            prm1.Value = m_SId
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
        End If
        clear_lvw()
        lock_obj(True)

exit_cmdSave_Click:
        If ConnectionState.Open = 1 Then cn.Close()
        Exit Sub

err_cmdSave_Click:
        If Err.Number = 5 Then
            MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
        Else
            MsgBox(Err.Number)
        End If
        Resume exit_cmdSave_Click
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Supplier Code", 90)
            .Columns.Add("Supplier Name", 150)
            .Columns.Add("Address1", 0)
            .Columns.Add("Address2", 0)
            .Columns.Add("Contact", 150)
            .Columns.Add("Phone", 90)
            .Columns.Add("Fax", 90)
            .Columns.Add("Email", 0)
            .Columns.Add("Payment Term", 0)
            .Columns.Add("Remark", 0)
            .Columns.Add("Other Info1", 0)
            .Columns.Add("Other Info2", 0)
            .Columns.Add("Other Info3", 0)
            .Columns.Add("s_curr_id", 0)
            .Columns.Add("curr_code", 0)
            .Columns.Add("curr_rate", 0)
            .Columns.Add("s_balance", 0)
            .Columns.Add("s_local_balance", 0)
            .Columns.Add("s_advance_balance", 0)
        End With

        cmd = New SqlCommand("sp_mt_supplier_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int, 255)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@s_code", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(cmbFilterBy.Text = "Supplier Code", txtFilter.Text, DBNull.Value)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@s_name", SqlDbType.NVarChar, 50)
        prm3.Value = IIf(cmbFilterBy.Text = "Supplier Name", txtFilter.Text, DBNull.Value)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 19, 1)
        myReader.Close()
        cn.Close()
    End Sub

    Sub clear_lvw2()
        With ListView2
            .Clear()
            .View = View.Details
            .Columns.Add("period_id", 0)
            .Columns.Add("Period Name", 120)
            .Columns.Add("Beginning Balance", 120, HorizontalAlignment.Right)
            .Columns.Add("Total Trans", 120, HorizontalAlignment.Right)
            .Columns.Add("Ending Balance", 120, HorizontalAlignment.Right)
            .Columns.Add("Base Beginning Balance", 120, HorizontalAlignment.Right)
            .Columns.Add("Base Total Trans", 120, HorizontalAlignment.Right)
            .Columns.Add("Base Ending Balance", 120, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("sp_mt_supplier_balance_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int, 255)
        prm1.Value = m_SId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView2, 6, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1))) 'period_id
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow ''s_balance_id
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            lvItem.SubItems.Add(myReader.Item(2)) 'period_name
            lvItem.SubItems.Add(myReader.Item(2)) 'period_name
            lvItem.SubItems.Add(FormatNumber(myReader.Item(3))) 'bal_begin
            lvItem.SubItems.Add(FormatNumber(myReader.Item(4))) 'total_trans
            lvItem.SubItems.Add(FormatNumber(myReader.Item(5))) 'bal_ending
            lvItem.SubItems.Add(FormatNumber(myReader.Item(6))) 'base_bal_ending
            lvItem.SubItems.Add(FormatNumber(myReader.Item(7))) 'base_total_trans
            lvItem.SubItems.Add(FormatNumber(myReader.Item(8))) 'base_bal_ending
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

    Sub clear_obj()
        m_SId = 0
        m_CurrId = 0
        txtSCode.Text = ""
        txtSName.Text = ""
        txtSAddress1.Text = ""
        txtSAddress2.Text = ""
        txtSContact.Text = ""
        txtSPhone.Text = ""
        txtSFax.Text = ""
        txtSEmail.Text = ""
        txtSPaymentTerm.Text = 0
        txtSRemarks.Text = ""
        txtSInfo1.Text = ""
        txtSInfo2.Text = ""
        txtSInfo3.Text = ""
        txtSCurrCode.Text = ""
        txtSLocalBalance.Text = ""
        txtSBalance.Text = ""
        txtSAdvanceBalance.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtSCode.ReadOnly = isLock
        txtSName.ReadOnly = isLock
        txtSAddress1.ReadOnly = isLock
        txtSAddress2.ReadOnly = isLock
        txtSContact.ReadOnly = isLock
        txtSPhone.ReadOnly = isLock
        txtSFax.ReadOnly = isLock
        txtSEmail.ReadOnly = isLock
        txtSPaymentTerm.ReadOnly = isLock
        txtSRemarks.ReadOnly = isLock
        txtSInfo1.ReadOnly = isLock
        txtSInfo2.ReadOnly = isLock
        txtSInfo3.ReadOnly = isLock

        If m_SId > 0 Then btnCurrency.Enabled = False Else btnCurrency.Enabled = Not isLock
        If m_SId = 0 Then
            btnDelete.Enabled = isLock
        Else
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        End If
        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("sp_mt_supplier_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int, 255)
            prm1.Value = m_SId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm2.Value = My.Settings.UserName
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int)
            prm3.Direction = ParameterDirection.Output
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            If prm3.Value = 1 Then
                MsgBox("You can't delete this record because it's already used in transaction.", vbCritical, Me.Text)
            Else
                clear_lvw()
                clear_obj()
            End If
            lock_obj(True)
        End If
    End Sub

    Private Sub txtSPaymentTerm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSPaymentTerm.KeyPress
        Dim key As Integer = Asc(e.KeyChar)
        If Not ((key >= 48 And key <= 57) Or key = 8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ListView1_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
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

    Private Sub btnCurrency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCurrency.Click
        Dim NewFormDialog As New fdlCurrency
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub


End Class