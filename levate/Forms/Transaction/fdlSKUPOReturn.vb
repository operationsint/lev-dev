Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlSKUPOReturn
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'If ListView1.CheckedItems.Count > 0 Then
        '    With frmPInvoice
        '        If .PInvoiceId = 0 Then .SavePInvoiceHeader()
        '        If .PInvoiceId > 0 Then
        '            For i = 1 To ListView1.Items.Count
        '                If ListView1.Items(i - 1).Checked = True Then
        '                    cmd = New SqlCommand("usp_tr_pinvoice_dtl_INS", cn)
        '                    cmd.CommandType = CommandType.StoredProcedure

        '                    Dim prm1 As SqlParameter = cmd.Parameters.Add("@pinvoice_id", SqlDbType.Int, 255)
        '                    prm1.Value = .PInvoiceId
        '                    Dim prm2 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int, 255)
        '                    prm2.Value = LeftSplitUF(ListView1.Items(i - 1).Tag)
        '                    Dim prm3 As SqlParameter = cmd.Parameters.Add("@po_qty", SqlDbType.Int, 255)
        '                    prm3.Value = CInt(ListView1.Items(i - 1).SubItems.Item(4).Text)
        '                    Dim prm5 As SqlParameter = cmd.Parameters.Add("@previous_qty", SqlDbType.Int, 255)
        '                    prm5.Value = CInt(ListView1.Items(i - 1).SubItems.Item(7).Text)
        '                    Dim prm6 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int, 255)
        '                    prm6.Value = ListView1.Items(i - 1).SubItems.Item(2).Text
        '                    cn.Open()
        '                    cmd.ExecuteReader()
        '                    cn.Close()
        '                End If
        '            Next
        '            fdlSKUPOReturn_Load(sender, e)
        '            .clear_lvw()
        '        Else
        '            MessageBox.Show("Can't insert to line items because error was happened before", Me.Text)
        '        End If
        '    End With
        'Else
        '    MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        'End If
        If ListView1.SelectedItems.Count > 0 Then
            ListView1_DoubleClick(sender, e)
        Else
            MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub fdlSKUPOReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("po_dtl_type", 0)
            .Columns.Add("Line Type", 90)
            .Columns.Add("sku_id", 0)
            .Columns.Add("Stock Code", 90)
            .Columns.Add("Stock Name", 250)
            .Columns.Add("location_id", 0)
            .Columns.Add("location_code", 0)
            .Columns.Add("Qty", 60, HorizontalAlignment.Right)
            .Columns.Add("sku_uom", 0)
            .Columns.Add("Price", 90, HorizontalAlignment.Right)
            .Columns.Add("po_dtl_gross", 0, HorizontalAlignment.Right)
            .Columns.Add("po_dtl_taxpercent", 0, HorizontalAlignment.Right)
            .Columns.Add("po_dtl_tax", 0, HorizontalAlignment.Right)
            .Columns.Add("po_dtl_net", 0, HorizontalAlignment.Right)
        End With

        'If frmPReturn.POId > 0 Then
        '    cmd = New SqlCommand("sp_tr_po_dtl_SEL", cn)
        '    cmd.CommandType = CommandType.StoredProcedure

        '    Dim prm1 As SqlParameter = cmd.Parameters.Add("@po_id", SqlDbType.Int, 255)
        '    prm1.Value = frmPReturn.POId
        '    Dim prm3 As SqlParameter = cmd.Parameters.Add("@sku_name", SqlDbType.NVarChar, 50)
        '    prm3.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)

        '    cn.Open()

        '    Dim myReader As SqlDataReader = cmd.ExecuteReader()

        '    'Call FillList(myReader, Me.ListView1, 5, 1)
        '    Dim lvItem As ListViewItem
        '    Dim intCurrRow As Integer

        '    While myReader.Read
        '        lvItem = New ListViewItem(CStr(myReader.Item(2))) 'po_dtl_type
        '        lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
        '        lvItem.SubItems.Add(myReader.Item(3)) 'line_type
        '        Select Case myReader.GetString(2) 'sku_id, sku_code
        '            Case "S"
        '                lvItem.SubItems.Add(myReader.GetInt32(6))
        '                lvItem.SubItems.Add(myReader.GetString(7))
        '            Case "E"
        '                lvItem.SubItems.Add(myReader.GetInt32(18))
        '                lvItem.SubItems.Add(myReader.GetString(19))
        '            Case Else
        '                lvItem.SubItems.Add("")
        '        End Select

        '        lvItem.SubItems.Add(myReader.Item(8)) 'sku_name
        '        For i = 9 To 10 'location_id, location
        '            If myReader.Item(i) Is System.DBNull.Value Then
        '                lvItem.SubItems.Add("")
        '            Else
        '                lvItem.SubItems.Add(myReader.Item(i))
        '            End If
        '        Next
        '        lvItem.SubItems.Add(FormatNumber(myReader.GetInt32(11) * -1, 0)) 'po_qty
        '        If myReader.Item(12) Is System.DBNull.Value Then
        '            lvItem.SubItems.Add("")
        '        Else
        '            lvItem.SubItems.Add(myReader.Item(12)) 'sku_uom
        '        End If
        '        For i = 13 To 17
        '            lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
        '        Next
        '        If intCurrRow Mod 2 = 0 Then
        '            lvItem.BackColor = Color.Lavender
        '        Else
        '            lvItem.BackColor = Color.White
        '        End If
        '        lvItem.UseItemStyleForSubItems = True

        '        ListView1.Items.Add(lvItem)
        '        intCurrRow += 1
        '    End While
        '    myReader.Close()
        '    cn.Close()
        'End If
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
        With frmPReturn
            .PODtlType = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
            .SKUId = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
            .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
            .SKUName = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
            .LocationId = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text
            .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(6).Text
            .POQty = ListView1.SelectedItems.Item(0).SubItems.Item(7).Text
            .SKUUoM = ListView1.SelectedItems.Item(0).SubItems.Item(8).Text
            .POPrice = ListView1.SelectedItems.Item(0).SubItems.Item(9).Text
            .POGross = ListView1.SelectedItems.Item(0).SubItems.Item(10).Text
            .POTaxPercent = ListView1.SelectedItems.Item(0).SubItems.Item(11).Text
            .POTax = ListView1.SelectedItems.Item(0).SubItems.Item(12).Text
            .PONet = ListView1.SelectedItems.Item(0).SubItems.Item(13).Text
        End With
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSKUPOReturn_Load(sender, e)
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
End Class
