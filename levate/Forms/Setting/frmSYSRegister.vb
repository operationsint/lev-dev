Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmSYSRegister
    Dim m_canClose As Boolean = False
    Private Sub frmSYSRegister_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = fdlLogin.Label3.Text
        Label2.Text = "DB " & GetSysInit("db_version")
    End Sub

    Public Property canClose() As Boolean
        Get
            Return m_canClose
        End Get
        Set(ByVal Value As Boolean)
            m_canClose = Value
        End Set
    End Property

    Private Sub frmSYSRegister_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If m_canClose = False Then
            End
        End If
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        OFDLicense.ShowDialog()
    End Sub

    Private Sub OFDLicense_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OFDLicense.FileOk
        If OFDLicense.FileName <> "" Then
            Try
                Dim strConnection As String = My.Settings.ConnStr
                Dim cn As SqlConnection = New SqlConnection(strConnection)
                Dim cmd As SqlCommand
                Dim Path As String = Application.StartupPath & "\Levate.lic"
                Dim licensePath As String = OFDLicense.FileName
                Try
                    'read license file and insert license file
                    If System.IO.File.Exists(licensePath) = True Then
                        Dim reader As New System.IO.StreamReader(licensePath)
                        Dim allLines As List(Of String) = New List(Of String)
                        Dim CName, UVal, SMac, JS As String
                        Do While Not reader.EndOfStream
                            allLines.Add(reader.ReadLine())
                        Loop
                        reader.Close()
                        '-------------------------DECRYPT FROM JS-------------------------------
                        Dim cipherText As String = CStr(ReadLine(3, allLines))
                        Dim password As String = "b119"
                        Dim wrapper As New Dencrypt(password)
                        JS = CStr(wrapper.DecryptData(cipherText))
                        '-------------------------END OF DECRYPT--------------------------------

                        '-------------------------DECRYPT FROM CName-------------------------------
                        Dim cipherText2 As String = CStr(ReadLine(0, allLines))
                        Dim password2 As String = JS
                        Dim wrapper2 As New Dencrypt(password2)
                        CName = CStr(wrapper2.DecryptData(cipherText2))
                        '-------------------------END OF DECRYPT--------------------------------

                        UVal = CStr(ReadLine(1, allLines))
                        SMac = CStr(ReadLine(2, allLines))

                        UpdSysInitial("val", SMac)
                        cmd = New SqlCommand("update sys_company set user_val = '" + UVal + "',company_name = '" + CName + "' ", cn)
                        cn.Open()
                        cmd.ExecuteNonQuery()
                        cn.Close()
                    Else
                        MsgBox("Upload license failed please try again!", vbCritical)
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox("Upload license failed please try again!" + vbCrLf + "Error message :" + vbCrLf + ex.Message, vbCritical)
                    Exit Sub
                End Try

                'copy license to startup
                If System.IO.File.Exists(Path) Then
                    System.IO.File.Delete(Path)
                End If
                My.Computer.FileSystem.CopyFile(licensePath, Path)
                MsgBox("License load completed! Please restart Levate.", vbInformation)
                End
            Catch ex As Exception
                MsgBox("Upload license failed please try again!" + vbCrLf + "Error message :" + vbCrLf + ex.Message, vbCritical)
                Exit Sub
            End Try

        End If
    End Sub
End Class