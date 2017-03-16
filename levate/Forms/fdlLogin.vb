Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class fdlLogin
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim isPassed As Boolean

    Private Sub cmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim cn As SqlConnection = New SqlConnection(strConnection)

        Dim cmd As SqlCommand = New SqlCommand("usp_mt_user_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
        prm.Value = CStr(txtUserName.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        'Dim passwd As String
        If Not myReader.HasRows Then
            MsgBox("There is no username found. Please contact your administrator!", vbOKOnly + vbCritical, "Login")
        Else
            'Console.WriteLine("{0},{1}", myReader.GetName(1), myReader.GetName(2))
            myReader.Read()
            '-------------------------DECRYPT FROM DB-------------------------------
            Dim cipherText As String = myReader.GetString(2)
            Dim password As String = "1"
            Dim wrapper As New Dencrypt(password)
            Dim LoginPassword As String = wrapper.DecryptData(cipherText)
            '-------------------------END OF DECRYPT--------------------------------

            If txtPassword.Text <> LoginPassword Then
                MsgBox("Wrong password. Please contact your administrator!", vbOKOnly + vbCritical, "Login")
                txtPassword.Text = ""
            Else
                frmMAIN.ToolStripStatusLabel.Text = "User login: " & txtUserName.Text & "; User level: " & myReader.GetString(4)
                My.Settings.UserName = myReader.GetString(1)
                My.Settings.Save()
                p_UserLevel = myReader.GetInt32(3)
                'str_user_name = myReader.GetString(1)
                'str_user_access = myReader.GetString(3)
                isPassed = True
                Me.Close()

                myReader.Close()

                cmd = New SqlCommand("usp_sys_company_SEL", cn)
                cmd.CommandType = CommandType.StoredProcedure

                prm = cmd.Parameters.Add("@company_id", SqlDbType.Int)
                prm.Value = 1

                myReader = cmd.ExecuteReader()
                While myReader.Read
                    p_CompanyName = myReader.GetString(2)
                End While
                If GetSysInit("isPlay") = "True" Then
                    frmMAIN.Text = frmMAIN.Text & " *** PLAY *** "
                Else
                    frmMAIN.Text = frmMAIN.Text & " - " & p_CompanyName
                End If

                userLogin(My.Settings.UserName, My.Computer.Name)
                frmMAIN.timerStart()
            End If
            'Do While myReader.Read()
            'Console.WriteLine("{0},{1}", myReader.GetString(1), myReader.GetString(2))
            'passwd = myReader.GetString(2)
            'Loop

        End If
        myReader.Close()
        cn.Close()
    End Sub

    Private Sub fdlLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Label3.Text = "App " & GetSysInit("version_app")
        Label4.Text = "DB " & GetSysInit("db_version")
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        End
    End Sub

    Private Sub fdlLogin_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If isPassed = False Then End
        Me.Dispose()
        'End
    End Sub
End Class