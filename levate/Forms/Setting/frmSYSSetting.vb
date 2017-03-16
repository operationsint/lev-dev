Option Explicit On
'Option Strict On
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmSYSSetting
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FirstFiscalMonth As Integer

    Private Sub frmSYSSetting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Add cmbFirstFiscalMonth item
        For i = 1 To 12
            cmbFirstFiscalMonth.Items.Add(New clsMyListInt(MonthName(i), i))
        Next

        ntbTaxPercent.Text = CStr(CDbl(GetSysInit("tax_percent")) * 100)
        chbStockMinusSetting.Checked = CBool(GetSysInit("sku_qty_minus"))
        cbAllowBankMinus.Checked = CBool(GetSysInit("bank_amount_minus"))
        cbDecimal.Items.Insert(0, "0")
        cbDecimal.Items.Insert(1, "1")
        cbDecimal.Items.Insert(2, "2")
        cbDecimal.Items.Insert(3, "3")
        cbDecimal.Items.Insert(4, "4")
        cbDecimal.Items.Insert(5, "5")
        cbDecimal.Items.Insert(6, "6")
        cbDecimal.SelectedIndex = CInt(GetSysInit("decimal_digit"))
        m_FirstFiscalMonth = IIf(GetSysInit("first_fiscal_month") = "", 0, GetSysInit("first_fiscal_month"))
        txtStockImagePath.Text = GetSysInit("stock_image_path")
        If GetSysInit("isPlay") = "True" Then
            cbPlay.Checked = True
        Else
            cbPlay.Checked = False
        End If

        Dim mList As clsMyListInt
        For i = 1 To cmbFirstFiscalMonth.Items.Count
            mList = cmbFirstFiscalMonth.Items(i - 1)
            If m_FirstFiscalMonth = mList.ItemData Then
                cmbFirstFiscalMonth.SelectedIndex = i - 1
                Exit For
            End If
        Next

        cmbRound.Items.Add("Normal")
        cmbRound.Items.Add("Down")

        If GetSysInit("rounding") = "down" Then
            cmbRound.SelectedIndex = 1
        Else
            cmbRound.SelectedIndex = 0
        End If

        '20161104
        cbTruncatePurchaseVAT.Checked = CBool(GetSysInit("truncate_purchase_VAT"))
        cbTruncateSalesVAT.Checked = CBool(GetSysInit("truncate_sales_VAT"))
        cbConfirmOutCheckRequiredDate.Checked = CBool(GetSysInit("confirm_out_date_check"))

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            UpdSysInitial("tax_percent", CStr(CDbl(ntbTaxPercent.Text) / 100))
            UpdSysInitial("sku_qty_minus", CStr(IIf(chbStockMinusSetting.Checked = True, 1, 0)))
            UpdSysInitial("bank_amount_minus", CStr(IIf(cbAllowBankMinus.Checked = True, 1, 0)))
            UpdSysInitial("decimal_digit", CStr(cbDecimal.SelectedIndex))
            UpdSysInitial("first_fiscal_month", cmbFirstFiscalMonth.Items(cmbFirstFiscalMonth.SelectedIndex).ItemData)
            If cmbRound.SelectedIndex = 1 Then
                UpdSysInitial("rounding", "down")
            Else
                UpdSysInitial("rounding", "normal")
            End If
            UpdSysInitial("stock_image_path", txtStockImagePath.Text)

            If cbPlay.Checked = True Then
                UpdSysInitial("isPlay", "True")
            Else
                UpdSysInitial("isPlay", "False")
            End If

            '20161104
            UpdSysInitial("truncate_purchase_VAT", CStr(IIf(cbTruncatePurchaseVAT.Checked = True, 1, 0)))
            UpdSysInitial("truncate_sales_VAT", CStr(IIf(cbTruncateSalesVAT.Checked = True, 1, 0)))
            UpdSysInitial("confirm_out_date_check", CStr(IIf(cbConfirmOutCheckRequiredDate.Checked = True, 1, 0)))

            MsgBox("Successfully Saved", vbInformation, Me.Text)
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class