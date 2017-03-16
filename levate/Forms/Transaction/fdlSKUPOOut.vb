Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlSKUPOOut
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
        If ListView1.CheckedItems.Count > 0 Then
            With frmPReceive
                If .PReceiveId = 0 Then .SavePReceiveHeader()
                If .PReceiveId > 0 Then
                    Try
                        For i = 1 To ListView1.Items.Count
                            If ListView1.Items(i - 1).Checked = True Then
                                cmd = New SqlCommand("usp_tr_preceive_dtl_INS", cn)
                                cmd.CommandType = CommandType.StoredProcedure

                                Dim prm1 As SqlParameter = cmd.Parameters.Add("@preceive_id", SqlDbType.Int)
                                prm1.Value = .PReceiveId
                                Dim prm2 As SqlParameter = cmd.Parameters.Add("@po_dtl_id", SqlDbType.Int)
                                prm2.Value = LeftSplitUF(ListView1.Items(i - 1).Tag)
                                Dim prm3 As SqlParameter = cmd.Parameters.Add("@preceive_qty", SqlDbType.Decimal)
                                prm3.Value = CDbl(ListView1.Items(i - 1).SubItems.Item(4).Text)
                                Dim prm5 As SqlParameter = cmd.Parameters.Add("@previous_qty", SqlDbType.Decimal)
                                prm5.Value = CDbl(ListView1.Items(i - 1).SubItems.Item(7).Text)
                                Dim prm6 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int)
                                prm6.Value = ListView1.Items(i - 1).SubItems.Item(2).Text
                                cn.Open()
                                cmd.ExecuteReader()
                                cn.Close()
                            End If
                        Next
                        .clear_lvw()
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
        'If ListView1.SelectedItems.Count > 0 Then
        '    ListView1_DoubleClick(sender, e)
        'Else
        '    MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        'End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub fdlSKUPOOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Stock Code", 90)
            .Columns.Add("Stock Name", 250)
            .Columns.Add("locationId", 0)
            .Columns.Add("Location Code", 90)
            .Columns.Add("Stock Balance", 90, HorizontalAlignment.Right)
            .Columns.Add("sku_uom", 0)
            .Columns.Add("po_qty", 0)
            .Columns.Add("sum_preceive_qty", 0)
        End With

        cmd = New SqlCommand("sp_tr_po_dtl_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int)
        prm1.Value = frmPReceive.POId
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@sku_name", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@outstanding", SqlDbType.Bit)
        prm3.Value = 1

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 5, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            Select Case myReader.GetString(2)
                Case "S"
                    lvItem = New ListViewItem(CStr(myReader.Item(7)))
                Case "E"
                    lvItem = New ListViewItem(CStr(myReader.Item(19)))
                Case Else
                    lvItem = New ListViewItem("")
            End Select
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            lvItem.SubItems.Add(myReader.Item(8))
            lvItem.SubItems.Add(myReader.GetInt32(9))
            If myReader.Item(10) Is System.DBNull.Value Then
                lvItem.SubItems.Add("")
            Else
                lvItem.SubItems.Add(myReader.Item(10))
            End If
            lvItem.SubItems.Add(myReader.GetValue(20)) 'stock_balance
            lvItem.SubItems.Add(IIf(myReader.Item(12) Is System.DBNull.Value, "", myReader.Item(12))) 'sku_uom
            lvItem.SubItems.Add(myReader.GetValue(11)) 'po_qty
            lvItem.SubItems.Add(myReader.GetValue(21)) 'sum_preceive_qty
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
        '    .PODId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
        '    .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
        '    .SKUDescription = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
        '    .PRQty = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
        '    .PreviousPRQty = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
        '    '.PRQtyOutstanding = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
        '    .SKUUoM = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
        '    .LocationId = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text
        '    .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(6).Text
        'End With
        'Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSKUPOOut_Load(sender, e)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

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
