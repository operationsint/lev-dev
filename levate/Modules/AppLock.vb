Public Class AppLock
    Private Shared _TR As System.Data.SqlClient.SqlTransaction

    Public Shared Sub GetLock()

        If Not (_TR Is Nothing) Then ReleaseLock()
        Dim cn As New System.Data.SqlClient.SqlConnection(My.Settings.ConnStr)
        cn.Open()
        _TR = cn.BeginTransaction()
        Dim cm As New System.Data.SqlClient.SqlCommand("select * from APPLOCK with (updlock) ", cn, _TR)
        cm.CommandTimeout = 300
        Dim o As Object
        o = cm.ExecuteScalar()

    End Sub

    Public Shared Sub ReleaseLock()

        'release
        If _TR Is Nothing Then Exit Sub

        Dim cn As System.Data.SqlClient.SqlConnection = _TR.Connection
        _TR.Commit()
        cn.Close()
        _TR = Nothing
    End Sub

End Class
