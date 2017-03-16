Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlPROutByPO
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim isGetNum As Boolean

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
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

    Private Sub fdlPROutByPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Purchase Order No.", 130)
            .Columns.Add("Date", 80)
            .Columns.Add("sku_id", 0)
            .Columns.Add("Stock Code", 80)
            .Columns.Add("Stock Name", 80)
        End With

        cmd = New SqlCommand("sp_tr_po_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@s_name", SqlDbType.NVarChar)
        prm1.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@po_no", SqlDbType.NVarChar)
        prm2.Value = IIf(txtPONo.Text = "", DBNull.Value, txtPONo.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@po_date1", SqlDbType.SmallDateTime)
        prm3.Value = frmPInvoice.dtpPInvoiceDate.Value
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@po_invoice", SqlDbType.Bit)
        prm4.Value = 1

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 5, 1)
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
            fdlPROutByPO_Load(sender, e)
        End If
    End Sub

    Private Sub txtPONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPONo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlPROutByPO_Load(sender, e)
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
