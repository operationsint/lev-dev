Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class frmUser
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_UserId As Integer
    Dim isAllowDelete As Boolean

    Private Sub frmUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isAllowDelete = canDelete(Me.Name)

        'Add item cmbUserLevelID
        cmd = New SqlCommand("usp_mt_user_level_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        cn.Open()
        Dim myReader = cmd.ExecuteReader

        cmbUserLevelID.Items.Clear()
        While myReader.Read
            cmbUserLevelID.Items.Add(New clsMyListInt(myReader.GetString(1), myReader.GetInt32(0)))
        End While
        cmbUserLevelID.SelectedIndex = 0

        myReader.Close()
        cn.Close()

        clear_obj()
        lock_obj(True)
        clear_lvw()
        ListView1.Items.Item(0).Selected = True
        ListView1_Click(sender, e)
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        If m_UserId = 0 And btnAdd.Enabled = False Then lock_obj(True)
        With ListView1.SelectedItems.Item(0)
            '-------------------------DECRYPT FROM DB-------------------------------
            Dim cipherText As String = .SubItems.Item(1).Text
            Dim password As String = "1"
            Dim wrapper As New Dencrypt(password)
            Dim UserPassword As String = wrapper.DecryptData(cipherText)
            '-------------------------END OF DECRYPT--------------------------------
            lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1))
            m_UserId = LeftSplitUF(.Tag)
            txtUserName.Text = .SubItems.Item(0).Text
            txtUserPassword.Text = UserPassword

            Dim mList As clsMyListInt
            Dim i As Integer
            For i = 1 To cmbUserLevelID.Items.Count
                mList = cmbUserLevelID.Items(i - 1)
                If CInt(.SubItems.Item(2).Text) = mList.ItemData Then
                    cmbUserLevelID.SelectedIndex = i - 1
                    Exit For
                End If
            Next
        End With
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Dim strConnection As String = My.Settings.ConnStr
            Dim cn As SqlConnection = New SqlConnection(strConnection)
            Dim cmd As SqlCommand
            Dim userCount As Integer
            Dim userEncrypt As String
            Dim userVal As Integer

            cmd = New SqlCommand("select COUNT(user_id) from mt_user a WHERE a.AC=0 and user_name <> 'admin' ", cn)

            cn.Open()
            Dim myReader = cmd.ExecuteReader

            While myReader.Read
                userCount = myReader.GetInt32(0)
            End While

            myReader.Close()
            cn.Close()

            cmd = New SqlCommand("SELECT user_val,company_name,(select sys_init_val from sys_init where sys_init_id='val') as val from sys_company", cn)
            cn.Open()
            Dim myReader1 = cmd.ExecuteReader

            While myReader1.Read
                userEncrypt = myReader1.GetString(0)
            End While

            myReader1.Close()
            cn.Close()

            Dim Path As String = Application.StartupPath & "\Levate.lic"
            If System.IO.File.Exists(Path) = True Then
                Dim reader As New System.IO.StreamReader(Path)
                Dim allLines As List(Of String) = New List(Of String)
                Dim JS As String
                Do While Not reader.EndOfStream
                    allLines.Add(reader.ReadLine())
                Loop
                reader.Close()

                '-------------------------DECRYPT FROM JS-------------------------------
                Dim cipherText10 As String = CStr(ReadLine(3, allLines))
                Dim password10 As String = "b119"
                Dim wrapper10 As New Dencrypt(password10)
                JS = wrapper10.DecryptData(cipherText10)
                '-------------------------END OF DECRYPT--------------------------------

                '-------------------------DECRYPT FROM DB-------------------------------
                Dim cipherText As String = userEncrypt
                Dim password As String = JS
                Dim wrapper As New Dencrypt(password)
                userVal = CInt(wrapper.DecryptData(cipherText))
                '-------------------------END OF DECRYPT--------------------------------

                If userCount < userVal Then
                    clear_obj()
                    lock_obj(False)
                Else
                    MsgBox("Maximum Active Users reached, new user cannot be added." + vbCrLf + "Please purchase additional user license to add new user", MsgBoxStyle.Critical)
                End If
                'Else
                '    MsgBox("if path is not exists")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
        If m_UserId <> 0 Then txtUserName.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo err_btnSave_Click

        If txtUserName.Text = "" Then
            MsgBox("User Name, Password, and Role are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtUserName.Focus()
            Exit Sub
        End If

        If txtUserName.Text.Contains(" ") Then
            MsgBox("Your user name contain space. Remove the space and try again.", vbInformation, Me.Text)
            txtUserName.Focus()
            Exit Sub
        End If

        cmd = New SqlCommand(IIf(m_UserId = 0, "usp_mt_user_INS", "usp_mt_user_UPD"), cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter
        prm1 = cmd.Parameters.Add("@user_id", SqlDbType.Int, 255)
        Dim prm2 As SqlParameter
        prm2 = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@user_level_id", SqlDbType.NVarChar, 50)
        prm3.Value = cmbUserLevelID.Items(cmbUserLevelID.SelectedIndex).ItemData
        '------------------------ENCRYPTING PASSWORD----------------------------
        Dim plainText As String = txtUserPassword.Text
        Dim password As String = "1"

        Dim wrapper As New Dencrypt(password)
        Dim EncryptPass As String = wrapper.EncryptData(plainText)
        '------------------------END OF ENCRYPTING PASSWORD----------------------------
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@user_password", SqlDbType.NVarChar, 50)
        prm4.Value = EncryptPass

        If m_UserId = 0 Then
            prm1.Direction = ParameterDirection.Output
            prm2.Value = LCase(txtUserName.Text)

            Dim prm5 = cmd.Parameters.Add("@user_name2", SqlDbType.NVarChar)
            prm5.Value = My.Settings.UserName

            cn.Open()
            cmd.ExecuteReader()
            m_UserId = prm1.Value
            cn.Close()
        Else
            prm2.Value = My.Settings.UserName
            prm1.Value = m_UserId
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
        If Err.Number = 5 Then
            MsgBox("This primary code has been used (and deleted) previously. Please create with another code", vbExclamation + vbOKOnly, Me.Text)
        Else
            MsgBox(Err.Number)
        End If
        Resume exit_btnSave_Click
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("User Name", 300)
            .Columns.Add("no_name", 0)
            .Columns.Add("user_level_id", 0)
        End With

        cmd = New SqlCommand("usp_mt_user_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar)
        prm1.Value = DBNull.Value

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 3, 1)
        myReader.Close()
        cn.Close()
    End Sub

    Sub clear_obj()
        m_UserId = 0
        txtUserName.Text = ""
        txtUserPassword.Text = ""
        cmbUserLevelID.SelectedIndex = 0
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtUserName.ReadOnly = isLock
        txtUserPassword.ReadOnly = isLock
        cmbUserLevelID.Enabled = Not isLock
        If isAllowDelete = True Then btnDelete.Enabled = Not isLock Else btnDelete.Enabled = False
        btnEdit.Enabled = isLock
        btnAdd.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("usp_mt_user_DEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_id", SqlDbType.Int, 255)
            prm1.Value = m_UserId
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm2.Value = My.Settings.UserName

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
End Class