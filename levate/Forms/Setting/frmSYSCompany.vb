Option Explicit On
Option Strict On
Imports System.Data.SqlClient
Imports System.Data.OleDb


Public Class frmSYSCompany
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Private Sub frmSYSCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmd = New SqlCommand("usp_sys_company_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@company_id", SqlDbType.Int, 255)
        prm1.Value = 1

        cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        While myReader.Read
            txtCompanyCode.Text = myReader.GetString(1)
            txtCompanyName.Text = myReader.GetString(2)
            If Not myReader.IsDBNull(myReader.GetOrdinal("company_address1")) Then
                txtCompanyAddress1.Text = myReader.GetString(myReader.GetOrdinal("company_address1"))
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("company_address2")) Then
                txtCompanyAddress2.Text = myReader.GetString(myReader.GetOrdinal("company_address2"))
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("company_phone1")) Then
                txtCompanyPhone1.Text = myReader.GetString(myReader.GetOrdinal("company_phone1"))
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("company_phone2")) Then
                txtCompanyPhone2.Text = myReader.GetString(myReader.GetOrdinal("company_phone2"))
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("company_fax")) Then
                txtCompanyFax.Text = myReader.GetString(myReader.GetOrdinal("company_fax"))
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("company_web_address")) Then
                txtCompanyWebAddress.Text = myReader.GetString(myReader.GetOrdinal("company_web_address"))
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("company_email1")) Then
                txtCompanyEmail1.Text = myReader.GetString(myReader.GetOrdinal("company_email1"))
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("company_email2")) Then
                txtCompanyEmail2.Text = myReader.GetString(myReader.GetOrdinal("company_email2"))
            End If
            If Not myReader.IsDBNull(myReader.GetOrdinal("company_npwp")) Then
                txtCompanyNPWP.Text = myReader.GetString(myReader.GetOrdinal("company_npwp"))
            End If

            '20161026 - Bank Account Information
            If Not myReader.IsDBNull(myReader.GetOrdinal("company_bank_info")) Then
                txtCompanyBankInfo.Text = myReader.GetString(myReader.GetOrdinal("company_bank_info"))
            End If


        End While
        myReader.Close()
        cn.Close()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            cmd = New SqlCommand("usp_sys_company_UPD", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@company_id", SqlDbType.Int)
            prm1.Value = 1
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@company_code", SqlDbType.NVarChar)
            prm2.Value = txtCompanyCode.Text
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@company_name", SqlDbType.NVarChar)
            prm3.Value = txtCompanyName.Text
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@company_address1", SqlDbType.NVarChar)
            prm4.Value = IIf(txtCompanyAddress1.Text = "", DBNull.Value, txtCompanyAddress1.Text)
            Dim prm5 As SqlParameter = cmd.Parameters.Add("@company_address2", SqlDbType.NVarChar)
            prm5.Value = IIf(txtCompanyAddress2.Text = "", DBNull.Value, txtCompanyAddress2.Text)
            Dim prm6 As SqlParameter = cmd.Parameters.Add("@company_phone1", SqlDbType.NVarChar)
            prm6.Value = IIf(txtCompanyPhone1.Text = "", DBNull.Value, txtCompanyPhone1.Text)
            Dim prm7 As SqlParameter = cmd.Parameters.Add("@company_phone2", SqlDbType.NVarChar)
            prm7.Value = IIf(txtCompanyPhone1.Text = "", DBNull.Value, txtCompanyPhone2.Text)
            Dim prm8 As SqlParameter = cmd.Parameters.Add("@company_fax", SqlDbType.NVarChar)
            prm8.Value = IIf(txtCompanyFax.Text = "", DBNull.Value, txtCompanyFax.Text)
            Dim prm9 As SqlParameter = cmd.Parameters.Add("@company_web_address", SqlDbType.NVarChar)
            prm9.Value = IIf(txtCompanyWebAddress.Text = "", DBNull.Value, txtCompanyWebAddress.Text)
            Dim prm10 As SqlParameter = cmd.Parameters.Add("@company_email1", SqlDbType.NVarChar)
            prm10.Value = IIf(txtCompanyEmail1.Text = "", DBNull.Value, txtCompanyEmail1.Text)
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@company_email2", SqlDbType.NVarChar)
            prm11.Value = IIf(txtCompanyEmail2.Text = "", DBNull.Value, txtCompanyEmail2.Text)
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@company_npwp", SqlDbType.NVarChar)
            prm12.Value = IIf(txtCompanyNPWP.Text = "", DBNull.Value, txtCompanyNPWP.Text)
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar)
            prm13.Value = My.Settings.UserName

            '20161026 - Bank Account Information
            Dim prm14 As SqlParameter = cmd.Parameters.Add("@company_bank_info", SqlDbType.NVarChar)
            prm14.Value = IIf(txtCompanyBankInfo.Text = "", DBNull.Value, txtCompanyBankInfo.Text)

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            MsgBox("Successfully Saved", vbInformation, Me.Text)

        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub chbStockMinusSetting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ntbTaxPercent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class