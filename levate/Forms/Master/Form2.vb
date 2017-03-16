Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Form2
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For i = 1 To 9
            cmd = New SqlCommand("usp_mt_user_access_INS", cn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_level_id", SqlDbType.Int)
            prm1.Value = i
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
        Next
        MsgBox("Insert mt_user_access success!")
    End Sub
End Class