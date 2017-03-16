Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlPInvoiceOut
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim Dec As Integer = GetSysInit("decimal_digit")
    Dim isAllowBankMinus As Boolean = GetSysInit("bank_amount_minus")
    Dim m_BankBalance As Double

    Public Property BankBalance() As Double
        Get
            Return m_BankBalance
        End Get
        Set(ByVal Value As Double)
            m_BankBalance = Value
        End Set
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
        'If ListView1.SelectedItems.Count > 0 Then
        '    ListView1_DoubleClick(sender, e)
        'Else
        '    MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        'End If

        '---get total payment---
        Dim TotalSum As Double = 0
        Dim TempNode As ListViewItem
        Dim TempDbl As Double
        For Each TempNode In ListView1.CheckedItems
            If Double.TryParse(TempNode.SubItems.Item(11).Text, TempDbl) Then
                TotalSum += TempDbl
            End If
        Next
        '---end get total payment---
        If isAllowBankMinus = False Then
            If m_BankBalance - TotalSum < 0 Then
                MsgBox("Purchase payment amount > Bank balance amount!", vbCritical + vbOKOnly, Me.Text)
                Exit Sub
            End If
        End If
        If ListView1.CheckedItems.Count > 0 Then
            With frmPPayment
                If .PPaymentId = 0 Then .SavePPaymentHeader()
                If .PPaymentId > 0 Then
                    Try
                        For i = 1 To ListView1.Items.Count
                            If ListView1.Items(i - 1).Checked = True Then
                                cmd = New SqlCommand("usp_tr_ppayment_dtl_INS", cn)
                                cmd.CommandType = CommandType.StoredProcedure

                                Dim prm1 As SqlParameter = cmd.Parameters.Add("@ppayment_id", SqlDbType.Int)
                                prm1.Value = .PPaymentId
                                Dim prm2 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int)
                                prm2.Value = .CurrId
                                Dim prm3 As SqlParameter = cmd.Parameters.Add("@pinvoice_curr_id", SqlDbType.Int)
                                prm3.Value = ListView1.Items(i - 1).SubItems.Item(2).Text
                                Dim prm4 As SqlParameter = cmd.Parameters.Add("@outstanding_value", SqlDbType.Money)
                                prm4.Value = ListView1.Items(i - 1).SubItems.Item(11).Text
                                Dim prm5 As SqlParameter = cmd.Parameters.Add("@pinvoice_id", SqlDbType.Int)
                                prm5.Value = LeftSplitUF(ListView1.Items(i - 1).Tag)
                                Dim prm7 As SqlParameter = cmd.Parameters.Add("@ppayment_dtl_value", SqlDbType.Money)
                                prm7.Value = IIf(.CurrId = ListView1.Items(i - 1).SubItems.Item(2).Text, ListView1.Items(i - 1).SubItems.Item(11).Text, ListView1.Items(i - 1).SubItems.Item(12).Text)
                                Dim prm8 As SqlParameter = cmd.Parameters.Add("@local_outstanding_value", SqlDbType.Money)
                                prm8.Value = ListView1.Items(i - 1).SubItems.Item(12).Text
                                Dim prm9 As SqlParameter = cmd.Parameters.Add("@pinvoice_curr_rate", SqlDbType.Money)
                                prm9.Value = ListView1.Items(i - 1).SubItems.Item(4).Text
                                Dim prm10 As SqlParameter = cmd.Parameters.Add("@ppayment_curr_rate", SqlDbType.Money)
                                prm10.Value = .ntbPPaymentCurrRate.Text
                                Dim prm11 As SqlParameter = cmd.Parameters.Add("@ppayment_dtl_curr_rate", SqlDbType.Money)
                                prm11.Value = IIf(.CurrId <> ListView1.Items(i - 1).SubItems.Item(2).Text, ListView1.Items(i - 1).SubItems.Item(4).Text, 1)
                                Dim prm12 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
                                prm12.Value = .SId
                                Dim prm13 As SqlParameter = cmd.Parameters.Add("@bank_code", SqlDbType.NVarChar, 50)
                                prm13.Value = .txtBankCode.Text
                                cn.Open()
                                cmd.ExecuteReader()
                                cn.Close()
                            End If
                        Next
                        .clear_lvw()
                        .refresh_total()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        If cn.State = ConnectionState.Open Then cn.Close()
                    End Try
                Else
                    MessageBox.Show("Can't insert to line items because error was happened before", Me.Text)
                End If
            End With
            Me.Close()
        Else
            MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub fdlPInvoiceOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Purchase Invoice No.", 120)
            .Columns.Add("Date", 80)
            .Columns.Add("curr_id", 0)
            .Columns.Add("Currency", 80)
            .Columns.Add("curr_rate", 0)
            .Columns.Add("Total", 100, HorizontalAlignment.Right)
            .Columns.Add("Local Total", 110, HorizontalAlignment.Right)
            .Columns.Add("Outstanding", 100, HorizontalAlignment.Right)
            .Columns.Add("Local Outstanding", 110, HorizontalAlignment.Right)
            .Columns.Add("total", 0, HorizontalAlignment.Right)
            .Columns.Add("local_total", 0, HorizontalAlignment.Right)
            .Columns.Add("outstanding", 0, HorizontalAlignment.Right)
            .Columns.Add("local_outstanding", 0, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("usp_tr_pinvoice_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int)
        prm1.Value = frmPPayment.SId
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@pinvoice_no", SqlDbType.NVarChar)
        prm2.Value = IIf(txtPONo.Text = "", DBNull.Value, txtPONo.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@pinvoice_stat1", SqlDbType.NVarChar)
        prm3.Value = "UP"
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@pinvoice_stat2", SqlDbType.NVarChar)
        prm4.Value = "PP"

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 16, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            lvItem.SubItems.Add(myReader.Item(2))
            lvItem.SubItems.Add(myReader.GetInt32(14))
            lvItem.SubItems.Add(myReader.GetString(15))
            lvItem.SubItems.Add(FormatNumber(myReader.GetValue(16))) 'pinvoice_curr_rate
            lvItem.SubItems.Add(FormatNumber(myReader.GetValue(19))) 'pinvoice_total
            lvItem.SubItems.Add(FormatNumber(myReader.GetValue(25))) 'local_pinvoice_total
            lvItem.SubItems.Add(FormatNumber(myReader.GetValue(21))) 'pinvoice_outstanding
            lvItem.SubItems.Add(FormatNumber(myReader.GetValue(22))) 'local_pinvoice_outstanding
            lvItem.SubItems.Add(myReader.GetValue(19)) 'pinvoice_total
            lvItem.SubItems.Add(myReader.GetValue(25)) 'local_pinvoice_total
            lvItem.SubItems.Add(myReader.GetValue(21)) 'pinvoice_outstanding
            lvItem.SubItems.Add(myReader.GetValue(22)) 'local_pinvoice_outstanding

            If intCurrRow Mod 2 = 0 Then
                lvItem.BackColor = Color.Lavender
            Else
                lvItem.BackColor = Color.White
            End If
            lvItem.UseItemStyleForSubItems = True

            ListView1.Items.Add(lvItem)
            intCurrRow += 1
        End While
        myReader.Close()
        cn.Close()
    End Sub

    Private Sub ListView1_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        If (e.Column = ListView1Sorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending) Then
                ListView1Sorter.Order = Windows.Forms.SortOrder.Descending
            Else
                ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            ListView1Sorter.SortColumn = e.Column
            ListView1Sorter.Order = Windows.Forms.SortOrder.Ascending
        End If

        ' Perform the sort with these new sort options.
        ListView1.Sort()
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        'With frmPR
        '    .POId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
        '    .PONo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
        '    .SId = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
        '    .SCode = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
        '    .SName = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
        '    .PaymentDueDate = CStr(DateAdd(DateInterval.Day, CDbl(ListView1.SelectedItems.Item(0).SubItems.Item(11).Text), .dtpPRDate.Value))
        '    .PRRemarks = ListView1.SelectedItems.Item(0).SubItems.Item(13).Text
        'End With
        'Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlPInvoiceOut_Load(sender, e)
        End If
    End Sub

    Private Sub txtPONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPONo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlPInvoiceOut_Load(sender, e)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub chbSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSelectAll.CheckedChanged
        If chbSelectAll.Checked = True Then
            With ListView1
                For i = 1 To .Items.Count
                    .Items.Item(i - 1).Checked = True
                Next
            End With
        Else
            With ListView1
                For i = 1 To .Items.Count
                    .Items.Item(i - 1).Checked = False
                Next
            End With
        End If
    End Sub
End Class
