Public NotInheritable Class LvtAboutBox

    Private Sub LvtAboutBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = fdlLogin.Label3.Text
        Label2.Text = "DB " & GetSysInit("db_version")
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
