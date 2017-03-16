Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmCurrency
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_CurrId As Integer
    Dim isAllowDelete As Boolean

    Private Sub frmCurrency_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isAllowDelete = canDelete(Me.Name)

        clear_obj()
        'lock_obj(True)
        clear_lvw()
        btnCancel_Click(sender, e)
        'If ListView1.Items.Count > 0 Then
        '    ListView1.Items.Item(0).Selected = True
        '    ListView1_Click(sender, e)
        'End If
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        'If m_CurrId = 0 And btnAdd.Enabled = False Then lock_obj(True)
        With ListView1.SelectedItems.Item(0)
            lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1)) + " of " + ListView1.Items.Count.ToString
            m_CurrId = LeftSplitUF(.Tag)
            txtCurrCode.Text = .SubItems.Item(0).Text
            txtCurrName.Text = .SubItems.Item(1).Text
            chbBaseCurr.Checked = CBool(.SubItems.Item(2).Text)
            ntbCurrRate.Text = FormatNumber(.SubItems.Item(3).Text)
            dtpEffectiveDate.Value = .SubItems.Item(4).Text
        End With
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        clear_obj()
        lock_obj(False)
        If ListView1.Items.Count = 0 Then
            MsgBox("Please setup base currency that you will use in the system.", vbInformation + vbOKOnly, Me.Text)
            chbBaseCurr.Checked = True
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
        If m_CurrId <> 0 Then txtCurrCode.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_CurrId = 0 And ListView1.Items.Count > 0 Then
            ListView1.Items.Item(0).Selected = True
            ListView1_Click(sender, e)
        End If
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo err_btnSave_Click

        If txtCurrCode.Text = "" Then
            MsgBox("Currency are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtCurrCode.Focus()
            Resume exit_btnSave_Click
        End If

        cmd = New SqlCommand(IIf(m_CurrId = 0, "usp_mt_curr_INS", "usp_mt_curr_UPD"), cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int, 255)
        prm1.Value = m_CurrId
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@curr_code", SqlDbType.NVarChar, 50)
        prm2.Value = txtCurrCode.Text
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@curr_name", SqlDbType.NVarChar, 50)
        prm3.Value = IIf(txtCurrName.Text = "", DBNull.Value, txtCurrName.Text)
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@base_curr", SqlDbType.Bit)
        prm4.Value = chbBaseCurr.Checked
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@exchange_curr_rate", SqlDbType.Money)
        prm5.Value = IIf(ntbCurrRate.Text = "", 0, ntbCurrRate.Text)
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@effective_date", SqlDbType.SmallDateTime)
        prm6.Value = dtpEffectiveDate.Value.Date
        Dim prm7 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
        prm7.Value = My.Settings.UserName

        If m_CurrId = 0 Then
            prm1.Direction = ParameterDirection.Output
            cn.Open()
            cmd.ExecuteReader()
            m_CurrId = prm1.Value
            cn.Close()
        Else
            prm1.Value = m_CurrId
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            'clear_lvw()
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
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Currency Code", 90)
            .Columns.Add("Currency Name", 200)
            .Columns.Add("Base Currency", 80)
            .Columns.Add("rate", 0)
            .Columns.Add("effective_date", 0)
        End With

        cmd = New SqlCommand("usp_mt_curr_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int, 255)
        prm1.Value = 0

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 5, 1)
        myReader.Close()
        cn.Close()
    End Sub

    Sub clear_obj()
        m_CurrId = 0
        txtCurrCode.Text = ""
        txtCurrName.Text = ""
        ntbCurrRate.Text = FormatNumber("1")
        chbBaseCurr.Checked = False
        dtpEffectiveDate.Value = Now.Date
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtCurrCode.ReadOnly = isLock
        txtCurrName.ReadOnly = isLock
        ntbCurrRate.ReadOnly = isLock
        'chbBaseCurr.Enabled = Not isLock
        dtpEffectiveDate.Enabled = Not isLock
        If m_CurrId = 0 Then
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
        If chbBaseCurr.Checked = True Then
            MsgBox("Base currency can't be deleted", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_mt_curr_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int, 255)
            prm1.Value = m_CurrId
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

    Private Sub ntbCurrRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbCurrRate.LostFocus
        If ntbCurrRate.Text = "" Then ntbCurrRate.Text = FormatNumber(1)
        If chbBaseCurr.Checked = True Then ntbCurrRate.Text = FormatNumber(1) Else ntbCurrRate.Text = FormatNumber(ntbCurrRate.Text)
    End Sub

    Private Sub ntbCurrRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbCurrRate.TextChanged

    End Sub
End Class