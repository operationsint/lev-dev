Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmSYSNo
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Private Sub frmSYSNo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lock_obj(True)
        clear_lvw()
        ListView1.Items.Item(0).Selected = True
        ListView1_Click(sender, e)
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        With ListView1.SelectedItems.Item(0)
            txtTrxType.Text = .SubItems.Item(0).Text
            txtTrxDesc.Text = .SubItems.Item(1).Text
            txtTrxPrefix.Text = .SubItems.Item(2).Text
            ntbTrxDigit.Text = .SubItems.Item(3).Text
            ntbTrxNo.Text = .SubItems.Item(4).Text
            If .SubItems.Item(5).Text = "False" Then
                cbMonthPrefix.Checked = False
            Else
                cbMonthPrefix.Checked = True
            End If
        End With
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        lock_obj(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        On Error GoTo err_btnSave_Click

        If txtTrxPrefix.Text = "" Or ntbTrxDigit.Text = "" Or ntbTrxNo.Text = "" Then
            MsgBox("Prefix Number, Length, and Running Number are primary fields that should be entered. Please enter those fields before you save it.", vbCritical + vbOKOnly, Me.Text)
            txtTrxType.Focus()
            Exit Sub
        End If

        cmd = New SqlCommand("sp_sys_no_UPD", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@trxtype", SqlDbType.NVarChar)
        prm1.Value = txtTrxType.Text
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@trxdesc", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtTrxDesc.Text = "", DBNull.Value, txtTrxDesc.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@trxprefix", SqlDbType.NVarChar, 50)
        prm3.Value = txtTrxPrefix.Text
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@trxdigit", SqlDbType.Int)
        prm4.Value = ntbTrxDigit.Text
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@trxno", SqlDbType.Int)
        prm5.Value = IIf(CInt(ntbTrxNo.Text) = 0, 1, ntbTrxNo.Text)
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@monthprefix", SqlDbType.Bit)
        If cbMonthPrefix.Checked = True Then
            prm6.Value = True
        Else
            prm6.Value = False
        End If

        cn.Open()
        cmd.ExecuteReader()
        cn.Close()

        clear_lvw()
        lock_obj(True)

exit_btnSave_Click:
        If ConnectionState.Open Then cn.Close()
        Exit Sub

err_btnSave_Click:
        MsgBox(Err.Description)
        Resume exit_btnSave_Click
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Transaction Type", 100)
            .Columns.Add("Transaction Description", 150)
            .Columns.Add("Prefix Number", 100)
            .Columns.Add("Length", 100, HorizontalAlignment.Right)
            .Columns.Add("Running Number", 100, HorizontalAlignment.Right)
            .Columns.Add("Month Prefix", 100)
        End With

        cmd = New SqlCommand("sp_sys_no_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim i As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0)))
            For i = 1 To 5
                If myReader.Item(i) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(i))
                End If
            Next
            lvItem.UseItemStyleForSubItems = True
            ListView1.Items.Add(lvItem)
        End While
        myReader.Close()
        cn.Close()
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtTrxDesc.ReadOnly = isLock
        txtTrxPrefix.ReadOnly = isLock
        ntbTrxDigit.ReadOnly = isLock
        ntbTrxNo.ReadOnly = isLock
        cbMonthPrefix.Enabled = Not isLock
        btnEdit.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnCancel.Enabled = Not isLock
    End Sub
End Class