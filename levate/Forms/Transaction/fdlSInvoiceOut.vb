Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlSInvoiceOut
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
        'If ListView1.SelectedItems.Count > 0 Then
        '    ListView1_DoubleClick(sender, e)
        'Else
        '    MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        'End If
        If ListView1.CheckedItems.Count > 0 Then
            With frmSPayment
                If .SPaymentId = 0 Then .SaveSPaymentHeader()
                If .SPaymentId > 0 Then
                    Try
                        For i = 1 To ListView1.Items.Count
                            If ListView1.Items(i - 1).Checked = True Then
                                cmd = New SqlCommand("usp_tr_spayment_dtl_INS", cn)
                                cmd.CommandType = CommandType.StoredProcedure

                                Dim prm1 As SqlParameter = cmd.Parameters.Add("@spayment_id", SqlDbType.Int, 255)
                                prm1.Value = .SPaymentId
                                Dim prm2 As SqlParameter = cmd.Parameters.Add("@curr_id", SqlDbType.Int, 255)
                                prm2.Value = .CurrId
                                Dim prm3 As SqlParameter = cmd.Parameters.Add("@sinvoice_curr_id", SqlDbType.Int, 255)
                                prm3.Value = ListView1.Items(i - 1).SubItems.Item(2).Text
                                Dim prm4 As SqlParameter = cmd.Parameters.Add("@outstanding_value", SqlDbType.Money)
                                prm4.Value = ListView1.Items(i - 1).SubItems.Item(7).Text
                                Dim prm5 As SqlParameter = cmd.Parameters.Add("@sinvoice_id", SqlDbType.Int, 255)
                                prm5.Value = LeftSplitUF(ListView1.Items(i - 1).Tag)
                                Dim prm7 As SqlParameter = cmd.Parameters.Add("@spayment_dtl_value", SqlDbType.Money)
                                prm7.Value = IIf(.CurrId = ListView1.Items(i - 1).SubItems.Item(2).Text, ListView1.Items(i - 1).SubItems.Item(7).Text, ListView1.Items(i - 1).SubItems.Item(8).Text)
                                Dim prm8 As SqlParameter = cmd.Parameters.Add("@local_outstanding_value", SqlDbType.Money)
                                prm8.Value = ListView1.Items(i - 1).SubItems.Item(8).Text
                                Dim prm9 As SqlParameter = cmd.Parameters.Add("@sinvoice_curr_rate", SqlDbType.Money)
                                prm9.Value = ListView1.Items(i - 1).SubItems.Item(4).Text
                                Dim prm10 As SqlParameter = cmd.Parameters.Add("@spayment_curr_rate", SqlDbType.Money)
                                prm10.Value = .ntbSPaymentCurrRate.Text
                                Dim prm11 As SqlParameter = cmd.Parameters.Add("@spayment_dtl_curr_rate", SqlDbType.Money)
                                prm11.Value = IIf(.CurrId <> ListView1.Items(i - 1).SubItems.Item(2).Text, ListView1.Items(i - 1).SubItems.Item(4).Text, 1)
                                Dim prm12 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int, 255)
                                prm12.Value = .CId
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

    Private Sub fdlSInvoiceOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Sales Invoice No.", 120)
            .Columns.Add("Date", 80)
            .Columns.Add("curr_id", 0)
            .Columns.Add("Currency", 80)
            .Columns.Add("curr_rate", 0)
            .Columns.Add("Total", 100, HorizontalAlignment.Right)
            .Columns.Add("Local Total", 110, HorizontalAlignment.Right)
            .Columns.Add("Outstanding", 100, HorizontalAlignment.Right)
            .Columns.Add("Local Outstanding", 110, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("usp_tr_sinvoice_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int)
        prm1.Value = frmSPayment.CId
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@sinvoice_no", SqlDbType.NVarChar)
        prm2.Value = IIf(txtSInvoiceNo.Text = "", DBNull.Value, txtSInvoiceNo.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@sinvoice_stat1", SqlDbType.NVarChar)
        prm3.Value = "UP"
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@sinvoice_stat2", SqlDbType.NVarChar)
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
            lvItem.SubItems.Add(myReader.GetInt32(12)) 'curr_id
            lvItem.SubItems.Add(myReader.GetString(13)) 'curr_code
            lvItem.SubItems.Add(FormatNumber(myReader.GetValue(14))) 'curr_rate
            lvItem.SubItems.Add(FormatNumber(myReader.GetValue(19))) 'sinvoice_total
            lvItem.SubItems.Add(FormatNumber(myReader.GetValue(25))) 'local_total
            lvItem.SubItems.Add(FormatNumber(myReader.GetValue(21))) 'sinvoice_outstanding
            lvItem.SubItems.Add(FormatNumber(myReader.GetValue(22))) 'local_sinvoice_outstanding

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

    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSInvoiceOut_Load(sender, e)
        End If
    End Sub

    Private Sub txtSInvoiceNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSInvoiceNo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSInvoiceOut_Load(sender, e)
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
