Imports System.IO
Public Class frmLicense
    Dim SW As StreamWriter

    Private Sub frmLicense_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If txtCompanyName.Text = "" Or txtNumberUser.Text = "" Or txtServerMac.Text = "" Or txtJSCode.Text = "" Then
            MsgBox("Please insert the empty field!", vbCritical)
            Exit Sub
        End If

        sfdLicense.ShowDialog()
    End Sub

    Private Sub sfdLicense_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles sfdLicense.FileOk
        '------------------------ENCRYPTING COMPANY NAME----------------------------
        Dim plainText1 As String = txtCompanyName.Text
        Dim password1 As String = txtJSCode.Text

        Dim wrapper1 As New Dencrypt(password1)
        Dim Encrypt1 As String = wrapper1.EncryptData(plainText1)
        '------------------------END OF COMPANY NAME----------------------------

        '------------------------ENCRYPTING NUMBER USER----------------------------
        Dim plainText2 As String = txtNumberUser.Text
        Dim password2 As String = txtJSCode.Text

        Dim wrapper2 As New Dencrypt(password2)
        Dim Encrypt2 As String = wrapper2.EncryptData(plainText2)
        '------------------------END OF NUMBER USER----------------------------

        '------------------------ENCRYPTING SERVER MAC----------------------------
        Dim plainText3 As String = txtServerMac.Text
        Dim password3 As String = txtJSCode.Text

        Dim wrapper3 As New Dencrypt(password3)
        Dim Encrypt3 As String = wrapper3.EncryptData(plainText3)
        '------------------------END OF SERVER MAC----------------------------

        '------------------------ENCRYPTING JS CODE----------------------------
        Dim plainText4 As String = txtJSCode.Text
        Dim password4 As String = "b119"

        Dim wrapper4 As New Dencrypt(password4)
        Dim Encrypt4 As String = wrapper4.EncryptData(plainText4)
        '------------------------END OF JS CODE----------------------------

        '------------------------ENCRYPTING EXPIRED DATE----------------------------
        Dim plainText5 As String = dtpFrom.Text
        Dim password5 As String = txtJSCode.Text

        Dim wrapper5 As New Dencrypt(password5)
        Dim Encrypt5 As String = wrapper5.EncryptData(plainText5)
        '------------------------END OF EXPIRED DATE----------------------------

        SW = New StreamWriter(sfdLicense.FileName, False)

        SW.WriteLine(Encrypt1 + vbCrLf + Encrypt2 + vbCrLf + Encrypt3 + vbCrLf + Encrypt4 + vbCrLf + Encrypt5)
        SW.Close()
        MsgBox("License Generation Completed!", vbInformation)
        Me.Close()
    End Sub

    Private Sub txtNumberUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumberUser.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class