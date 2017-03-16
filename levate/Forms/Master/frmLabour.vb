Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmLabour
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_flag As Boolean
    Dim isAllowDelete As Boolean

    Private Sub frmLabour_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        'If m_PchCodeId = 0 And btnAdd.Enabled = False Then lock_obj(True)
        With ListView1.SelectedItems.Item(0)
            m_flag = 1
            txtLabourCode.Text = .SubItems.Item(0).Text
            txtLabourName.Text = .SubItems.Item(1).Text
            txtLabourRemarks.Text = .SubItems.Item(2).Text
        End With
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        clear_obj()
        lock_obj(False)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
        If m_flag <> 0 Then txtLabourCode.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_flag = 0 And ListView1.Items.Count > 0 Then
            ListView1.Items.Item(0).Selected = True
            ListView1_Click(sender, e)
        End If
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            If txtLabourCode.Text = "" Or txtLabourName.Text = "" Then
                MsgBox("Process Code and Description are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtLabourCode.Focus()
                Exit Sub
            End If

            cmd = New SqlCommand(IIf(m_flag = 0, "usp_mt_labour_INS", "usp_mt_labour_UPD"), cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prmCode As SqlParameter = cmd.Parameters.Add("@labour_code", SqlDbType.NVarChar, 50)
            prmCode.Value = txtLabourCode.Text
            Dim prmName As SqlParameter = cmd.Parameters.Add("@labour_name", SqlDbType.NVarChar, 100)
            prmName.Value = txtLabourName.Text
            Dim prmRemarks As SqlParameter = cmd.Parameters.Add("@labour_remarks", SqlDbType.NVarChar, 200)
            prmRemarks.Value = txtLabourRemarks.Text
            Dim prmUserName As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prmUserName.Value = My.Settings.UserName

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            lock_obj(True)
        Catch ex As Exception
            MsgBox("Error Message : " + ex.Message, vbCritical)
            If ConnectionState.Open = True Then cn.Close()
        End Try

    End Sub

    Sub clear_lvw()
        Try
            With ListView1
                .Clear()
                .View = View.Details
                .Columns.Add("labour_code", "Code", 90)
                .Columns.Add("labour_name", "Name", 200)
                .Columns.Add("labour_remarks", "Remarks", 0)
            End With

            cmd = New SqlCommand("usp_mt_labour_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            Dim lvItem As ListViewItem
            Dim intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item("labour_code"))) 'process_code
                lvItem.Tag = intCurrRow 'ID

                lvItem.SubItems.Add(myReader.Item("labour_name"))
                lvItem.SubItems.Add(myReader.Item("labour_remarks"))

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
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Sub clear_obj()
        m_flag = 0
        txtLabourCode.Text = ""
        txtLabourName.Text = ""
        txtLabourRemarks.Text = ""
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtLabourCode.ReadOnly = isLock
        txtLabourName.ReadOnly = isLock
        txtLabourRemarks.ReadOnly = isLock
        If m_flag = 0 Then
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
            cmd = New SqlCommand("usp_mt_labour_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prmCode As SqlParameter = cmd.Parameters.Add("@labour_code", SqlDbType.NVarChar, 50)
            prmCode.Value = txtLabourCode.Text
            Dim prmUserName As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prmUserName.Value = My.Settings.UserName
            Dim prmRowCount As SqlParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int)
            prmRowCount.Direction = ParameterDirection.Output
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            If prmRowCount.Value = 1 Then
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
End Class