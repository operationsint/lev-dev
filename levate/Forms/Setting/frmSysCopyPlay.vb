Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmSysCopyPlay
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Try

            If GetSysInit("isPlay") = "True" Then
                MsgBox("Error : This is a play database !", vbExclamation)
                Me.Close()
                Return
            End If


            MsgBox("This action will copy database LEVATE to LEVATEPLAY !", vbInformation)

            cmd = New SqlCommand("LIVETOPLAY", cn)
            cmd.CommandType = CommandType.StoredProcedure

            cn.Open()
            cmd.CommandTimeout = CInt(GetSysInit("db_timeout"))
            cmd.ExecuteNonQuery()
            cn.Close()

            MsgBox("Done copying database LEVATE to LEVATEPLAY", vbInformation)
            Me.Close()
        Catch ex As Exception
            If ConnectionState.Open = 1 Then cn.Close()
            MsgBox("Error" + vbCrLf + ex.Message, vbInformation)
            Me.Close()
        End Try
    End Sub
End Class