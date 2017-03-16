Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmSYSPeriodYearly
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FirstFiscalMonth As Integer
    Dim m_FiscalYearEnd As Integer
    Dim m_MonthArr(12, 1) As String

    Private Sub frmSYSPeriodYearly_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'lock_obj(True)

        m_FiscalYearEnd = IIf(GetSysInit("fiscal_year_end") = "", 0, GetSysInit("fiscal_year_end"))
        m_FirstFiscalMonth = IIf(GetSysInit("first_fiscal_month") = "", 0, GetSysInit("first_fiscal_month"))
        If m_FirstFiscalMonth = 0 Then
            txtFirstFiscalMonth.Text = ""
        Else
            txtFirstFiscalMonth.Text = MonthName(m_FirstFiscalMonth)
        End If
        ntbFiscalYearEnd.Text = IIf(m_FiscalYearEnd = 0, Year(Now.Date), m_FiscalYearEnd + 1)

        'Add cmbFirstFiscalMonth item
        'For i = 1 To 12
        '    cmbFirstFiscalMonth.Items.Add(New clsMyListInt(MonthName(i), i))
        'Next

        'Dim mList As clsMyListInt
        'For i = 1 To cmbFirstFiscalMonth.Items.Count
        '    mList = cmbFirstFiscalMonth.Items(i - 1)
        '    If m_FirstFiscalMonth = mList.ItemData Then
        '        cmbFirstFiscalMonth.SelectedIndex = i - 1
        '        Exit For
        '    End If
        'Next

        btnSetup.Enabled = False
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetup.Click
        On Error GoTo err_btnSave_Click

        If ntbFiscalYearEnd.Text = "" Then
            MsgBox("Please enter Fiscal Year End", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If

        If txtFirstFiscalMonth.Text = "" Then
            MsgBox("Please set First Fiscal Month", vbCritical + vbOKOnly, Me.Text)
            Exit Sub
        End If

        If CDbl(ntbFiscalYearEnd.Text) < m_FiscalYearEnd Then
            MsgBox("You can't set up period less than FY" & m_FiscalYearEnd + 1, vbCritical + vbOKOnly, Me.Text)
            ntbFiscalYearEnd.Text = IIf(m_FiscalYearEnd = 0, "", m_FiscalYearEnd + 1)
            Exit Sub
        End If
        'cmd = New SqlCommand("usp_sys_period_CHECK", cn)
        'cmd.CommandType = CommandType.StoredProcedure
        'Dim prm1 As SqlParameter = cmd.Parameters.Add("@year_period", SqlDbType.NVarChar, 50)
        'prm1.Value = ntbFiscalYearEnd.Text
        'Dim prm2 As SqlParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int)
        'prm2.Direction = ParameterDirection.Output

        'cn.Open()
        'cmd.ExecuteReader()
        'cn.Close()

        If ntbFiscalYearEnd.Text = m_FiscalYearEnd Then
            MsgBox("This year period has been exist", vbCritical, Me.Text)
        Else
            cmd = New SqlCommand("usp_sys_period_AUTO", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm11 As SqlParameter = cmd.Parameters.Add("@fiscal_year_end", SqlDbType.NVarChar, 50)
            prm11.Value = ntbFiscalYearEnd.Text
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@first_fiscal_month", SqlDbType.NVarChar)
            prm12.Value = m_FirstFiscalMonth
            Dim prm13 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm13.Value = My.Settings.UserName

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            'For i = 1 To 12
            '    'prm11.Value = txtYearPeriod.Text + Format(i, "0#")
            '    prm12.Value = MonthName(i) & " " & txtYearPeriod.Text
            '    prm13.Value = DateSerial(txtYearPeriod.Text, i, 1)
            '    prm14.Value = DateAdd("d", -1, DateSerial(txtYearPeriod.Text, i + 1, 1))

            'Next i

            frmSYSPeriodList.clear_lvw()
            MsgBox("Period successfully added", vbInformation, Me.Text)
        End If

exit_btnSave_Click:
        If ConnectionState.Open Then cn.Close()
        Exit Sub

err_btnSave_Click:
        MsgBox(Err.Description)
        Resume exit_btnSave_Click
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        ntbFiscalYearEnd.ReadOnly = isLock
        btnSetup.Enabled = Not isLock
        btnClose.Enabled = Not isLock
    End Sub

    Private Sub ntbFiscalYearEnd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ntbFiscalYearEnd.KeyPress
        If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub ntbFiscalYearEnd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ntbFiscalYearEnd.TextChanged
        btnSetup.Enabled = True
    End Sub
End Class