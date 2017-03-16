Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlSPaymentAdvance
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cn2 As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim cmd2 As SqlCommand

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
                                cmd = New SqlCommand("usp_tr_spayment_advance_INS", cn)
                                cmd.CommandType = CommandType.StoredProcedure

                                Dim prm1 As SqlParameter = cmd.Parameters.Add("@spayment_id", SqlDbType.Int, 255)
                                prm1.Value = .SPaymentId
                                Dim prm2 As SqlParameter = cmd.Parameters.Add("@c_id", SqlDbType.Int, 255)
                                prm2.Value = .CId
                                Dim prm3 As SqlParameter = cmd.Parameters.Add("@spayment_advance_id", SqlDbType.Int, 255)
                                prm3.Value = LeftSplitUF(ListView1.Items(i - 1).Tag)
                                Dim prm4 As SqlParameter = cmd.Parameters.Add("@spayment_advance_value", SqlDbType.Money)
                                prm4.Value = CDbl(ListView1.Items(i - 1).SubItems.Item(7).Text)
                                Dim prm5 As SqlParameter = cmd.Parameters.Add("@spayment_previous_advance", SqlDbType.Money)
                                prm5.Value = CDbl(ListView1.Items(i - 1).SubItems.Item(6).Text)
                                cn.Open()
                                cmd.ExecuteReader()
                                cn.Close()
                            End If
                        Next
                        .clear_lvw2()
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

    Private Sub fdlSPaymentAdvance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Advance Payment No.")
            .Columns.Add("Advance Payment Date")
            .Columns.Add("curr_id", 0)
            .Columns.Add("Currency")
            .Columns.Add("Rate", 0, HorizontalAlignment.Right)
            .Columns.Add("Advance Payment", 0, HorizontalAlignment.Right)
            .Columns.Add("sum_spayment_advance", 0, HorizontalAlignment.Right)
            .Columns.Add("Available Advance Value", 0, HorizontalAlignment.Right)

            For i = 1 To 8
                If Not i = 3 And Not i = 7 Then .AutoResizeColumn(i - 1, ColumnHeaderAutoResizeStyle.HeaderSize)
            Next
        End With

        cmd = New SqlCommand("usp_tr_spayment_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@c_name", SqlDbType.NVarChar)
        prm1.Value = frmSPayment.txtCName.Text
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@is_payment_advance", SqlDbType.Bit)
        prm2.Value = 1

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 16, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            lvItem.SubItems.Add(myReader.Item(2)) 'spayment_date
            lvItem.SubItems.Add(myReader.GetInt32(11)) 'curr_id
            lvItem.SubItems.Add(myReader.GetString(12)) 'curr_code
            lvItem.SubItems.Add(FormatNumber(myReader.Item(13))) 'curr_rate
            lvItem.SubItems.Add(FormatNumber(myReader.Item(18))) 'total_paid
            lvItem.SubItems.Add(FormatNumber(myReader.Item(22))) 'sum_spayment_advance
            lvItem.SubItems.Add(FormatNumber(myReader.Item(23))) 'advance_available
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
            fdlSPaymentAdvance_Load(sender, e)
        End If
    End Sub

    Private Sub txtPONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSPaymentAdvance_Load(sender, e)
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
