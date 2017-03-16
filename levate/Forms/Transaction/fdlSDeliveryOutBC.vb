Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlSDeliveryOutBC
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn1 As SqlConnection = New SqlConnection(strConnection)
    Dim cn2 As SqlConnection = New SqlConnection(strConnection)
    Dim cmd1 As SqlCommand
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
            Try
                With frmBC
                    If .BCId = 0 Then
                        'Save tr_sinvoice
                        .SaveBCHeader()
                    End If
                    If .BCId > 0 Then
                        For i = 1 To ListView1.Items.Count
                            If ListView1.Items(i - 1).Checked = True Then
                                'Insert Line Items
                                cmd1 = New SqlCommand("usp_tr_sdelivery_dtl_SEL_ByOutBC", cn1)
                                cmd1.CommandType = CommandType.StoredProcedure

                                Dim prm2 As SqlParameter = cmd1.Parameters.Add("@sdelivery_id", SqlDbType.Int)
                                prm2.Value = LeftSplitUF(ListView1.Items(i - 1).Tag)

                                cn1.Open()
                                Dim myReader As SqlDataReader = cmd1.ExecuteReader()

                                While myReader.Read
                                    cmd2 = New SqlCommand("usp_tr_bc_dtl_INS", cn2)
                                    cmd2.CommandType = CommandType.StoredProcedure

                                    Dim prm17 As SqlParameter = cmd2.Parameters.Add("@bc_id", SqlDbType.Int)
                                    prm17.Value = .BCId
                                    Dim prm18 As SqlParameter = cmd2.Parameters.Add("@sdelivery_dtl_id", SqlDbType.Int)
                                    prm18.Value = myReader.GetInt32(0)
                                    Dim prm19 As SqlParameter = cmd2.Parameters.Add("@bc_dtl_desc", SqlDbType.NVarChar, 255)
                                    prm19.Value = myReader.GetString(1)
                                    Dim prm20 As SqlParameter = cmd2.Parameters.Add("@bc_dtl_price", SqlDbType.Money)
                                    prm20.Value = myReader.GetValue(2)
                                    Dim prm21 As SqlParameter = cmd2.Parameters.Add("@bc_dtl_pack_qty", SqlDbType.Decimal)
                                    prm21.Value = myReader.GetValue(3)
                                    Dim prm22 As SqlParameter = cmd2.Parameters.Add("@bc_dtl_gross_weight", SqlDbType.Decimal)
                                    prm22.Value = myReader.GetValue(4)
                                    Dim prm23 As SqlParameter = cmd2.Parameters.Add("@bc_dtl_net_weight", SqlDbType.Decimal)
                                    prm23.Value = myReader.GetValue(5)

                                    cn2.Open()
                                    cmd2.ExecuteReader()
                                    cn2.Close()
                                End While
                                myReader.Close()
                                cn1.Close()
                            End If
                        Next
                        .clear_lvw()
                        .refresh_total()
                    Else
                        MessageBox.Show("Can't insert to line items because error was happened before", Me.Text)
                    End If
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
                If cn1.State = ConnectionState.Open Then cn1.Close()
                If cn2.State = ConnectionState.Open Then cn2.Close()
            End Try
            Me.Close()
        Else
            MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub fdlSDeliveryOutBC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Sales Delivery No.", 130)
            .Columns.Add("Date", 80)
        End With

        cmd1 = New SqlCommand("usp_tr_sdelivery_SEL_ByOutBC", cn1)
        cmd1.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd1.Parameters.Add("@c_id", SqlDbType.Int)
        prm1.Value = frmBC.CId
        Dim prm2 As SqlParameter = cmd1.Parameters.Add("@sdelivery_no", SqlDbType.NVarChar)
        prm2.Value = IIf(txtSDeliveryNo.Text = "", DBNull.Value, txtSDeliveryNo.Text)

        cn1.Open()

        Dim myReader As SqlDataReader = cmd1.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 16, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            lvItem.SubItems.Add(myReader.Item(2))

            'lvItem.SubItems.Add(myReader.Item(4))
            'lvItem.SubItems.Add(myReader.Item(5))
            'Select Case myReader.GetString(4)
            '    Case "S"
            '        lvItem.SubItems.Add(myReader.GetInt32(6))
            '        lvItem.SubItems.Add(myReader.GetString(7))
            '    Case "E"
            '        lvItem.SubItems.Add(myReader.GetInt32(21))
            '        lvItem.SubItems.Add(myReader.GetString(22))
            '    Case Else
            '        lvItem.SubItems.Add("")
            'End Select
            'lvItem.SubItems.Add(myReader.GetString(8))
            'lvItem.SubItems.Add(myReader.GetInt32(9))
            'lvItem.SubItems.Add(myReader.GetString(10))
            'lvItem.SubItems.Add(myReader.GetInt32(13))
            'If myReader.Item(15) Is System.DBNull.Value Then
            '    lvItem.SubItems.Add("")
            'Else
            '    lvItem.SubItems.Add(myReader.Item(15))
            'End If
            'For i = 16 To 20
            '    lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
            'Next
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
        cn1.Close()
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
            fdlSDeliveryOutBC_Load(sender, e)
        End If
    End Sub

    Private Sub txtSDeliveryNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSDeliveryNo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSDeliveryOutBC_Load(sender, e)
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
