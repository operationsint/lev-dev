Imports System.Windows.Forms
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.NetworkInformation
Public Class frmRegis
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Private Sub btnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegister.Click
        'This code is used to get the mac address of network card
        Try
            Dim nic As NetworkInterface = Nothing
            Dim mac_Address As String = ""

            For Each nic In NetworkInterface.GetAllNetworkInterfaces

                mac_Address = nic.GetPhysicalAddress().ToString
                '------------------------ENCRYPTING PASSWORD----------------------------
                Dim plainText As String = mac_Address
                Dim password As String = "b119"

                Dim wrapper As New Dencrypt(password)
                Dim EncryptPass As String = wrapper.EncryptData(plainText)
                '------------------------END OF ENCRYPTING PASSWORD----------------------------
                If mac_Address <> "" And mac_Address <> "00000000000000E0" Then
                    cmd = New SqlCommand("select * from sys_nic where nic ='" + EncryptPass + "' ", cn)
                    cn.Open()

                    Dim myReader As SqlDataReader = cmd.ExecuteReader()

                    If Not myReader.HasRows Then
                        myReader.Close()
                        
                        cmd = New SqlCommand("insert into sys_nic values ('" + EncryptPass + "','" + My.Computer.Name + "',GETDATE()) ", cn)
                        cmd.ExecuteNonQuery()
                    End If
                    cn.Close()
                End If
            Next
            nic = Nothing
            MsgBox("Finished", vbInformation)
            Me.Close()
        Catch ex As Exception
            MsgBox("Register failed please try again" + vbCrLf + vbCrLf + "Error Message : " + vbCrLf + ex.ToString, vbCritical)
        End Try

    End Sub

    Private Sub frmRegis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnRegister.Visible = False
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If txtUserID.Text = "ADMIN" And txtPassword.Text = "Integr4lindo" Then
            txtPassword.Visible = False
            txtUserID.Visible = False
            btnLogin.Visible = False
            Label1.Visible = False
            Label2.Visible = False
            btnRegister.Visible = True
        Else
            MsgBox("Invalid login", vbCritical)
            txtPassword.Clear()
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin_Click(sender, e)
        End If
    End Sub
End Class