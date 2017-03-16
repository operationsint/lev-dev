Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlPOReceipt
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
        ListView1_DoubleClick(sender, e)
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub fdlPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Purchase Order No.", 110)
            .Columns.Add("Date", 80)
            .Columns.Add("s_id", 0)
            .Columns.Add("Supplier Code", 0)
            .Columns.Add("Supplier Name", 200)
            .Columns.Add("po_type", 0)
            .Columns.Add("po_status", 0)
            .Columns.Add("po_status_val", 0)
            .Columns.Add("delivery_date", 0)
            .Columns.Add("ship_via", 0)
            .Columns.Add("ref_no", 0)
            .Columns.Add("payment_terms", 0)
            .Columns.Add("payment_method", 0)
            .Columns.Add("po_remarks", 0)
            .Columns.Add("po_subtotal", 0)
            .Columns.Add("po_tax", 0)
            .Columns.Add("Total", 100, HorizontalAlignment.Right)
            .Columns.Add("po_payment", 0)
            .Columns.Add("po_outstanding", 0)
        End With

        cmd = New SqlCommand("sp_tr_po_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        'Dim prm1 As SqlParameter = cmd.Parameters.Add("@po_no", SqlDbType.NVarChar, 50)
        'prm1.Value = IIf(txtPONo.Text = "", DBNull.Value, txtPONo.Text)
        'Dim prm2 As SqlParameter = cmd.Parameters.Add("@po_date1", SqlDbType.DateTime)
        'prm2.Value = frmAP.dtpAPDate.Value
        'Dim prm3 As SqlParameter = cmd.Parameters.Add("@po_date2", SqlDbType.DateTime)
        'prm3.Value = DBNull.Value
        'Dim prm4 As SqlParameter = cmd.Parameters.Add("@s_name", SqlDbType.NVarChar, 50)
        'prm4.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        'Dim prm5 As SqlParameter = cmd.Parameters.Add("@po_stat", SqlDbType.NVarChar, 50)
        'prm5.Value = "R"

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 17, 1)
        Dim lvItem As ListViewItem
        Dim i As Integer, intCurrRow As Integer
        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            For i = 2 To 14
                If myReader.Item(i) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(i))
                End If
            Next
            For i = 15 To 19
                lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
            Next
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
        'With frmAP
        '    .POId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
        '    .PONo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
        '    .SId = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
        '    .SCode = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
        '    .SName = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
        '    .PORefNo = ListView1.SelectedItems.Item(0).SubItems.Item(10).Text
        '    .APRemarks = ListView1.SelectedItems.Item(0).SubItems.Item(13).Text
        '    .POTotal = FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(16).Text)
        '    .POPayment = FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(17).Text)
        '    .APAmount1 = FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(18).Text)
        '    .APAmount2 = FormatNumber(CDbl(ListView1.SelectedItems.Item(0).SubItems.Item(18).Text))
        '    .POBalance = FormatNumber(CDbl(ListView1.SelectedItems.Item(0).SubItems.Item(16).Text) - CDbl(ListView1.SelectedItems.Item(0).SubItems.Item(17).Text) - CDbl(ListView1.SelectedItems.Item(0).SubItems.Item(18).Text))
        '    .clear_lvw()
        'End With
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlPO_Load(sender, e)
        End If
    End Sub

    Private Sub txtPONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPONo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlPO_Load(sender, e)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub
End Class
