Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmUserAccess
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_UserLevelId As Integer
    Dim m_UserLevelDescription As String
    Dim m_UserAccessId As Integer
    Dim m_Flag As Integer
    Dim isAllowDelete As Boolean

    Private Sub frmUserAccess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isAllowDelete = canDelete("frmUserLevel")
        If m_Flag = 0 Then
            btnAdd_Click(sender, e)
        Else
            clear_objD()
            lock_obj(True)
            lock_objD(True)
            clear_lvw()
        End If
        m_UserAccessId = 0
        'view_record()
        'btnEdit_Click(sender, e)
    End Sub

    Public Property Flag() As Integer
        Get
            Return m_Flag
        End Get
        Set(ByVal Value As Integer)
            m_Flag = Value
        End Set
    End Property

    Public Property UserLevelId() As Integer
        Get
            Return txtUserLevelId.Text
        End Get
        Set(ByVal Value As Integer)
            txtUserLevelId.Text = Value
        End Set
    End Property

    Public Property UserLevelDescription() As String
        Get
            Return txtUserLevelDescription.Text
        End Get
        Set(ByVal Value As String)
            txtUserLevelDescription.Text = Value
        End Set
    End Property
    Sub clear_obj()
        m_Flag = 0
        txtUserLevelId.Text = ""
        txtUserLevelDescription.Text = ""
    End Sub

    Sub clear_objD()
        m_UserAccessId = 0
        txtFormDescription.Text = ""
        chbFormView.Checked = False
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtUserLevelId.ReadOnly = True
        txtUserLevelDescription.ReadOnly = isLock

        If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        btnAdd.Enabled = isLock
        btnEdit.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
    End Sub

    Sub lock_objD(ByVal isLock As Boolean)
        txtFormDescription.ReadOnly = True
        chbFormView.Enabled = Not isLock
        btnSaveD.Enabled = Not isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("form_name", 0)
            .Columns.Add("Form Description", 350)
            .Columns.Add("Form View", 80)
        End With

        cmd = New SqlCommand("usp_mt_user_access_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_level_id", SqlDbType.Int, 255)
        prm1.Value = txtUserLevelId.Text

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 3, 1)
        'Dim lvItem As ListViewItem
        'Dim i As Integer, intCurrRow As Integer

        'While myReader.Read
        '    lvItem = New ListViewItem(CStr(myReader.Item(1)))
        '    lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
        '    'lvItem.Tag = "v" & CStr(DR.Item(0))
        '    For i = 2 To 6
        '        If myReader.Item(i) Is System.DBNull.Value Then
        '            lvItem.SubItems.Add("")
        '        Else
        '            lvItem.SubItems.Add(myReader.Item(i))
        '        End If
        '    Next
        '    lvItem.SubItems.Add(myReader.GetInt32(7))
        '    If myReader.Item(8) Is System.DBNull.Value Then
        '        lvItem.SubItems.Add("")
        '    Else
        '        lvItem.SubItems.Add(myReader.Item(8))
        '    End If
        '    lvItem.SubItems.Add(FormatNumber(myReader.Item(9)))
        '    lvItem.SubItems.Add(FormatNumber(myReader.Item(10)))
        '    lvItem.SubItems.Add(FormatNumber(myReader.Item(11), 0))
        '    lvItem.SubItems.Add(FormatNumber(myReader.Item(12)))
        '    lvItem.SubItems.Add(FormatNumber(myReader.Item(13)))
        '    If intCurrRow Mod 2 = 0 Then
        '        lvItem.BackColor = Color.Lavender
        '    Else
        '        lvItem.BackColor = Color.White
        '    End If
        '    lvItem.UseItemStyleForSubItems = True

        '    ListView1.Items.Add(lvItem)
        '    intCurrRow += 1
        'End While

        myReader.Close()
        cn.Close()
    End Sub

    Sub view_record()
        cmd = New SqlCommand("usp_mt_user_level_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_level_id", SqlDbType.Int, 255)
        prm1.Value = m_UserLevelId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtUserLevelId.Text = myReader.GetInt32(0)
            txtUserLevelDescription.Text = myReader.GetString(1)
        End While

        myReader.Close()
        cn.Close()

    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1.SelectedItems.Item(0)
            m_UserAccessId = LeftSplitUF(.Tag)
            txtFormDescription.Text = .SubItems.Item(1).Text
            chbFormView.Checked = CBool(.SubItems.Item(2).Text)
        End With
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        clear_objD()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lock_obj(True)
        lock_objD(True)
        clear_objD()
        m_UserAccessId = 0
    End Sub

    Private Sub btnSaveD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveD.Click

        '20160611 daniel s : dont do if no active record
        If txtUserLevelId.TextLength <= 0 Then
            MessageBox.Show("Cant update, save first !", "ERROR")
            Return
        End If

        Try
            cmd = New SqlCommand("usp_mt_user_access_UPD", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_access_id", SqlDbType.Int, 255)
            prm1.Value = m_UserAccessId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@form_view", SqlDbType.Bit)
            prm2.Value = chbFormView.Checked
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm3.Value = My.Settings.UserName

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()

        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If txtUserLevelDescription.Text = "" Then
                MsgBox("Group Description are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
                txtUserLevelDescription.Focus()
                Exit Sub
            End If

            
            If m_Flag = 0 Then
                GetUserLastLevelID()
                cmd = New SqlCommand("usp_mt_user_level_INS", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_level_id", SqlDbType.Int)
                prm1.Value = CInt(txtUserLevelId.Text)
                Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_level_description", SqlDbType.NVarChar)
                prm2.Value = txtUserLevelDescription.Text
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                prm3.Value = My.Settings.UserName
            Else
                cmd = New SqlCommand("usp_mt_user_level_UPD", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_level_id", SqlDbType.Int)
                prm1.Value = CInt(txtUserLevelId.Text)
                Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_level_description", SqlDbType.NVarChar)
                prm2.Value = txtUserLevelDescription.Text
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
                prm3.Value = My.Settings.UserName
            End If

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            If m_Flag = 0 Then
                CopyUserAccessForm()
            End If
            'clear_lvw()

            m_Flag = 1
            lock_obj(True)
            lock_objD(True)

        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Sub CopyUserAccessForm()
        Try
            cmd = New SqlCommand("usp_mt_user_access_INS", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_level_id", SqlDbType.Int)
            prm1.Value = CInt(txtUserLevelId.Text)

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            clear_lvw()
            clear_objD()

        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        
    End Sub

    Sub GetUserLastLevelID()
        cmd = New SqlCommand("select top 1 user_level_id from mt_user_level order by user_level_id desc", cn)
        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtUserLevelId.Text = myReader.GetInt32(0) + 1
        End While

        myReader.Close()
        cn.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        clear_obj()
        clear_objD()
        lock_obj(False)
        lock_objD(False)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '20160611 daniel s : dont delete if no active record
        If txtUserLevelId.TextLength <= 0 Then
            MessageBox.Show("Cant delete !", "ERROR")
            Return
        End If

        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_mt_user_level_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_level_id", SqlDbType.Int)
            prm1.Value = CInt(txtUserLevelId.Text)
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm2.Value = My.Settings.UserName
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int)
            prm3.Direction = ParameterDirection.Output
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            If prm3.Value = 1 Then
                MsgBox("You can't delete this record because it's currently used in user card.", vbCritical, Me.Text)
            Else
                btnAdd_Click(sender, e)
            End If
        End If
    End Sub
End Class