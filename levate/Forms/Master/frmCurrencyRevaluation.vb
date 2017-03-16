Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmCurrencyRevaluation
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_CurrPeriodId As Integer
    Dim m_CurrId As Integer
    Dim isAllowDelete As Boolean

    Dim m_PeriodId As Integer
    Dim m_PeriodArr(0, 0) As String
    Dim isPosted As Boolean

    Private Sub frmCurrencyRevaluation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim prm1 As SqlParameter
        Dim myReader As SqlDataReader
        Dim i As Integer = 0

        isAllowDelete = canDelete(Me.Name)

        'Add item cmbPeriodId
        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@period_type", SqlDbType.NVarChar, 50)
        prm1.Value = "month_period"

        cn.Open()
        myReader = cmd.ExecuteReader

        cmbPeriodId.Items.Clear()
        While myReader.Read
            cmbPeriodId.Items.Add(New clsMyListInt(myReader.GetString(1), myReader.GetInt32(0)))
            i += 1
        End While
        If cmbPeriodId.Items.Count > 0 Then cmbPeriodId.SelectedIndex = 0

        myReader.Close()
        cn.Close()

        'Add Period Array
        ReDim m_PeriodArr(i - 1, 2)

        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@period_type", SqlDbType.NVarChar, 50)
        prm1.Value = "month_period"

        cn.Open()
        myReader = cmd.ExecuteReader

        i = 0
        While myReader.Read
            m_PeriodArr(i, 0) = myReader.GetInt32(0)
            m_PeriodArr(i, 1) = myReader.GetDateTime(2)
            m_PeriodArr(i, 2) = myReader.GetDateTime(3)
            i += 1
        End While

        myReader.Close()
        cn.Close()

        clear_obj()
        'lock_obj(True)
        clear_lvw()
        btnCancel_Click(sender, e)
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
            Return txtCurrCode.Text
        End Get
        Set(ByVal Value As String)
            txtCurrCode.Text = Value
        End Set
    End Property

    Public Property CurrName() As String
        Get
            Return txtCurrName.Text
        End Get
        Set(ByVal Value As String)
            txtCurrName.Text = Value
        End Set
    End Property

    Sub clear_obj()
        m_CurrPeriodId = 0
        m_CurrId = 0
        txtCurrCode.Text = ""
        txtCurrName.Text = ""
        ntbPeriodRate.Text = FormatNumber("1")
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        ntbPeriodRate.ReadOnly = isLock
        If m_CurrPeriodId = 0 Then
            btnDelete.Enabled = isLock
            cmbPeriodId.Enabled = True
            btnCurrency.Enabled = True
        Else
            If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
            cmbPeriodId.Enabled = False
            btnCurrency.Enabled = False
        End If
        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("curr_period_id", 0)
            .Columns.Add("curr_id", 0)
            .Columns.Add("Currency Code", 80)
            .Columns.Add("Currency Name", 120)
            .Columns.Add("period_id", 0)
            .Columns.Add("period_name", 80)
            .Columns.Add("period_rate", 100)
        End With

        cmd = New SqlCommand("usp_mt_curr_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim i As Integer, intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0))) 'CurrPeriod id
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            For i = 1 To 5 'curr_id,curr_code,curr_name,period_id,period_name
                If myReader.Item(i) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(i))
                End If
            Next
            If myReader.Item(6) Is System.DBNull.Value Then
                lvItem.SubItems.Add(FormatNumber(0))
            Else
                lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
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
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        'If m_CurrId = 0 And btnAdd.Enabled = False Then lock_obj(True)
        With ListView1.SelectedItems.Item(0)
            lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1)) + " of " + ListView1.Items.Count.ToString
            m_CurrPeriodId = LeftSplitUF(.Tag)
            m_CurrId = .SubItems.Item(1).Text
            txtCurrCode.Text = .SubItems.Item(2).Text
            txtCurrName.Text = .SubItems.Item(3).Text
            ntbPeriodRate.Text = FormatNumber(.SubItems.Item(6).Text)
            m_PeriodId = .SubItems.Item(4).Text

            Dim nList As clsMyListInt
            For i = 1 To cmbPeriodId.Items.Count
                nList = cmbPeriodId.Items(i - 1)
                If m_PeriodId = nList.ItemData Then
                    cmbPeriodId.SelectedIndex = i - 1
                    Exit For
                End If
            Next

        End With
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        clear_obj()
        lock_obj(False)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
        If m_CurrId <> 0 Then txtCurrCode.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_CurrPeriodId = 0 And ListView1.Items.Count > 0 Then
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

        cmd = New SqlCommand(IIf(m_CurrPeriodId = 0, "usp_mt_curr_period_INS", "usp_mt_curr_period_UPD"), cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
        prm1.Value = m_CurrId
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
        prm2.Value = CInt(cmbPeriodId.Items(cmbPeriodId.SelectedIndex).ItemData)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@period_rate", SqlDbType.Money)
        prm3.Value = IIf(ntbPeriodRate.Text = "", 0, ntbPeriodRate.Text)
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
        prm4.Value = My.Settings.UserName
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@curr_period_id", SqlDbType.Int)

        If m_CurrPeriodId = 0 Then
            prm5.Direction = ParameterDirection.Output
            cn.Open()
            cmd.ExecuteReader()
            m_CurrPeriodId = prm5.Value
            cn.Close()
        Else
            prm5.Value = m_CurrPeriodId
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

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_mt_curr_period_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@curr_period_id", SqlDbType.Int, 255)
            prm1.Value = m_CurrPeriodId 'm_CurrId

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
           
            clear_lvw()
            clear_obj()
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

    Private Sub ntbCurrRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbPeriodRate.LostFocus
        If ntbPeriodRate.Text = "" Then ntbPeriodRate.Text = FormatNumber(1)
    End Sub

    Private Sub btnCurrency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCurrency.Click
        Dim NewFormDialog As New fdlCurrency
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub cmbPeriodId_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPeriodId.SelectedIndexChanged
        'MsgBox(CStr(cmbPeriodId.Items(cmbPeriodId.SelectedIndex).ItemData))
    End Sub
End Class