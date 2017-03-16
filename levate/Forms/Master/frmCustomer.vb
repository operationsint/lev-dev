Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmCustomer
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_CId As Integer
    Dim m_CurrId As Integer
    Dim isAllowDelete As Boolean

    Private Sub frmCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isAllowDelete = canDelete(Me.Name)

        clear_obj()

        cmbFilterBy.Items.Add("<All>")
        cmbFilterBy.Items.Add("Customer Code")
        cmbFilterBy.Items.Add("Customer Name")
        cmbFilterBy.SelectedIndex = 0

        If ListView1.Items.Count > 0 Then
            ListView1.Items.Item(0).Selected = True
            ListView1_Click(sender, e)
        End If
        DefineComboItem()
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
            Return txtCCurrCode.Text
        End Get
        Set(ByVal Value As String)
            txtCCurrCode.Text = Value
        End Set
    End Property

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        'If m_CId = 0 And btnAdd.Enabled = False Then lock_obj(True)
        With ListView1.SelectedItems.Item(0)
            'txtCID.Text = Strings.Mid(ListView1.SelectedItems(0).Tag, 2, Len(ListView1.SelectedItems(0).Tag) - 1)
            lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1)) + " of " + ListView1.Items.Count.ToString
            m_CId = LeftSplitUF(.Tag)
            txtCCode.Text = .SubItems.Item(0).Text
            txtCName.Text = .SubItems.Item(1).Text
            If .SubItems.Item(2).Text = "" Then
                cmbCCategory.SelectedIndex = -1
            Else
                For i = 1 To cmbCCategory.Items.Count
                    If cmbCCategory.Items(i - 1) = .SubItems.Item(2).Text Then
                        cmbCCategory.SelectedIndex = i - 1
                        Exit For
                    End If
                Next
            End If
            txtCNpwp.Text = .SubItems.Item(3).Text
            txtCAddress1.Text = .SubItems.Item(4).Text
            txtCAddress2.Text = .SubItems.Item(5).Text
            txtCContact.Text = .SubItems.Item(6).Text
            txtCPhone.Text = .SubItems.Item(7).Text
            txtCFax.Text = .SubItems.Item(8).Text
            txtCEmail.Text = .SubItems.Item(9).Text
            txtCTPBNo.Text = .SubItems.Item(10).Text
            txtCPaymentTerms.Text = .SubItems.Item(11).Text
            txtCRemarks.Text = .SubItems.Item(12).Text
            txtCInfo1.Text = .SubItems.Item(13).Text
            txtCInfo2.Text = .SubItems.Item(14).Text
            txtCInfo3.Text = .SubItems.Item(15).Text
            m_CurrId = .SubItems.Item(16).Text
            txtCCurrCode.Text = .SubItems.Item(17).Text
            txtCBalance.Text = FormatNumber(.SubItems.Item(19).Text)
            txtCLocalBalance.Text = FormatNumber(.SubItems.Item(20).Text)
            txtCAdvanceBalance.Text = FormatNumber(.SubItems.Item(21).Text)

            clear_lvw2()
        End With
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then clear_lvw()
    End Sub

    Private Sub cmbFilterBy_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbFilterBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFilterBy.SelectedIndexChanged
        If cmbFilterBy.SelectedItem.ToString = "<All>" Then
            txtFilter.Text = ""
            If m_CId <> 0 Then clear_obj()
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
        If m_CId <> 0 Then txtCCode.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_CId = 0 And ListView1.Items.Count > 0 Then
            ListView1.Items.Item(0).Selected = True
            ListView1_Click(sender, e)
        End If
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo err_btnSave_Click

        If txtCCode.Text = "" Or txtCName.Text = "" Or cmbCCategory.Text = "" Or txtCCurrCode.Text = "" Then
            MsgBox("Customer Code, Customer Name and Category are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtCCode.Focus()
            Exit Sub
        End If

        cmd = New SqlCommand(IIf(m_CId = 0, "sp_mt_customer_INS", "sp_mt_customer_UPD"), cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm2 As SqlParameter = cmd.Parameters.Add("@c_code", SqlDbType.NVarChar, 50)
        prm2.Value = txtCCode.Text
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@c_name", SqlDbType.NVarChar, 255)
        prm3.Value = txtCName.Text
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@c_category", SqlDbType.NVarChar, 50)
        prm4.Value = IIf(cmbCCategory.Text = "", DBNull.Value, cmbCCategory.Text)
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@c_npwp", SqlDbType.NVarChar, 255)
        prm5.Value = IIf(txtCNpwp.Text = "", DBNull.Value, txtCNpwp.Text)
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@c_address1", SqlDbType.NVarChar, 255)
        prm6.Value = IIf(txtCAddress1.Text = "", DBNull.Value, txtCAddress1.Text)
        Dim prm7 As SqlParameter = cmd.Parameters.Add("@c_address2", SqlDbType.NVarChar, 255)
        prm7.Value = IIf(txtCAddress2.Text = "", DBNull.Value, txtCAddress2.Text)
        Dim prm8 As SqlParameter = cmd.Parameters.Add("@c_contact", SqlDbType.NVarChar, 255)
        prm8.Value = IIf(txtCContact.Text = "", DBNull.Value, txtCContact.Text)
        Dim prm9 As SqlParameter = cmd.Parameters.Add("@c_phone", SqlDbType.NVarChar, 50)
        prm9.Value = IIf(txtCPhone.Text = "", DBNull.Value, txtCPhone.Text)
        Dim prm10 As SqlParameter = cmd.Parameters.Add("@c_fax", SqlDbType.NVarChar, 50)
        prm10.Value = IIf(txtCFax.Text = "", DBNull.Value, txtCFax.Text)
        Dim prm11 As SqlParameter = cmd.Parameters.Add("@c_email", SqlDbType.NVarChar, 50)
        prm11.Value = IIf(txtCEmail.Text = "", DBNull.Value, txtCEmail.Text)
        Dim prm12 As SqlParameter = cmd.Parameters.Add("@c_tpb_no", SqlDbType.NVarChar, 50)
        prm12.Value = IIf(txtCTPBNo.Text = "", DBNull.Value, txtCTPBNo.Text)
        Dim prm13 As SqlParameter = cmd.Parameters.Add("@c_payment_terms", SqlDbType.Int, 50)
        prm13.Value = IIf(txtCPaymentTerms.Text = "", 0, txtCPaymentTerms.Text)
        Dim prm14 As SqlParameter = cmd.Parameters.Add("@c_remarks", SqlDbType.NVarChar, 255)
        prm14.Value = IIf(txtCRemarks.Text = "", DBNull.Value, txtCRemarks.Text)
        Dim prm15 As SqlParameter = cmd.Parameters.Add("@c_info1", SqlDbType.NVarChar, 255)
        prm15.Value = IIf(txtCInfo1.Text = "", DBNull.Value, txtCInfo1.Text)
        Dim prm16 As SqlParameter = cmd.Parameters.Add("@c_info2", SqlDbType.NVarChar, 255)
        prm16.Value = IIf(txtCInfo2.Text = "", DBNull.Value, txtCInfo2.Text)
        Dim prm17 As SqlParameter = cmd.Parameters.Add("@c_info3", SqlDbType.NVarChar, 255)
        prm17.Value = IIf(txtCInfo3.Text = "", DBNull.Value, txtCInfo3.Text)
        Dim prm18 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
        prm18.Value = My.Settings.UserName
        Dim prm19 As SqlParameter = cmd.Parameters.Add("@c_curr_id", SqlDbType.Int)
        prm19.Value = m_CurrId
        Dim prm1 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int, 255)

        If m_CId = 0 Then
            prm1.Direction = ParameterDirection.Output
            cn.Open()
            cmd.ExecuteReader()
            m_CId = prm1.Value
            cn.Close()
        Else
            prm1.Value = m_CId
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
        End If
        clear_lvw()
        lock_obj(True)

exit_btnSave_Click:
        If ConnectionState.Open = 1 Then cn.Close()
        Exit Sub

err_btnSave_Click:
        'If Err.Number = 5 Then
        '    MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
        'Else
        MsgBox(Err.Description)
        'End If
        Resume exit_btnSave_Click
    End Sub

    Sub clear_lvw()
        DefineComboItem()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Customer Code", 90)
            .Columns.Add("Customer Name", 150)
            .Columns.Add("Category", 0)
            .Columns.Add("npwp_no", 0)
            .Columns.Add("Address1", 0)
            .Columns.Add("Address2", 0)
            .Columns.Add("Contact", 150)
            .Columns.Add("Phone", 90)
            .Columns.Add("Fax", 90)
            .Columns.Add("Email", 0)
            .Columns.Add("tpb_no", 0)
            .Columns.Add("payment_terms", 0)
            .Columns.Add("Remarks", 0)
            .Columns.Add("Other Info1", 0)
            .Columns.Add("Other Info2", 0)
            .Columns.Add("Other Info3", 0)
            .Columns.Add("curr_id", 0)
            .Columns.Add("curr_code", 0)
            .Columns.Add("curr_rate", 0)
            .Columns.Add("balance", 0)
            .Columns.Add("local_balance", 0)
            .Columns.Add("c_advance_balance", 0)
        End With

        cmd = New SqlCommand("sp_mt_customer_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int, 255)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@c_code", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(cmbFilterBy.Text = "Customer Code", txtFilter.Text, DBNull.Value)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@c_name", SqlDbType.NVarChar, 50)
        prm3.Value = IIf(cmbFilterBy.Text = "Customer Name", txtFilter.Text, DBNull.Value)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 22, 1)
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
        
        cmd = New SqlCommand("sp_mt_customer_balance_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int, 255)
        prm1.Value = m_CId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView2, 6, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1))) 'period_id
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'balance_id
            'lvItem.Tag = "v" & CStr(DR.Item(0))
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
        m_CId = 0
        m_CurrId = 0
        txtCCode.Text = ""
        txtCName.Text = ""
        txtCNpwp.Text = ""
        txtCAddress1.Text = ""
        txtCAddress2.Text = ""
        txtCContact.Text = ""
        txtCPhone.Text = ""
        txtCFax.Text = ""
        txtCEmail.Text = ""
        txtCTPBNo.Text = ""
        txtCPaymentTerms.Text = 0
        txtCRemarks.Text = ""
        txtCInfo1.Text = ""
        txtCInfo2.Text = ""
        txtCInfo3.Text = ""
        txtCCurrCode.Text = ""
        txtCLocalBalance.Text = ""
        txtCBalance.Text = ""
        txtCAdvanceBalance.Text = ""
        cmbCCategory.Text = ""
        cmbCCategory.SelectedIndex = -1
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtCCode.ReadOnly = isLock
        txtCName.ReadOnly = isLock
        cmbCCategory.Enabled = Not isLock
        txtCNpwp.ReadOnly = isLock
        txtCAddress1.ReadOnly = isLock
        txtCAddress2.ReadOnly = isLock
        txtCContact.ReadOnly = isLock
        txtCPhone.ReadOnly = isLock
        txtCFax.ReadOnly = isLock
        txtCEmail.ReadOnly = isLock
        txtCTPBNo.ReadOnly = isLock
        txtCPaymentTerms.ReadOnly = isLock
        txtCRemarks.ReadOnly = isLock
        txtCInfo1.ReadOnly = isLock
        txtCInfo2.ReadOnly = isLock
        txtCInfo3.ReadOnly = isLock

        If m_CId > 0 Then btnCurrency.Enabled = False Else btnCurrency.Enabled = Not isLock
        If m_CId = 0 Then
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
            cmd = New SqlCommand("sp_mt_customer_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int, 255)
            prm1.Value = m_CId
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

    Private Sub txtCPaymentTerm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCPaymentTerms.KeyPress
        Dim key As Integer = Asc(e.KeyChar)
        If Not ((key >= 48 And key <= 57) Or key = 8) Then
            e.Handled = True
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
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

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Sub DefineComboItem()
        cmbCCategory.Items.Clear()
        cmd = New SqlCommand("usp_mt_customerByCategory_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            cmbCCategory.Items.Add(myReader.GetString(0))
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Private Sub btnCurrency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCurrency.Click
        Dim NewFormDialog As New fdlCurrency
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub
End Class