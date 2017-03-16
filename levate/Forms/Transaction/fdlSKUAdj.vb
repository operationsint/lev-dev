Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlSKUAdj
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FrmCallerId As String

    Public Property FrmCallerId() As String
        Get
            Return m_FrmCallerId
        End Get
        Set(ByVal Value As String)
            m_FrmCallerId = Value
        End Set
    End Property

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

    Private Sub fdlSKUAdj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("category", 0)
            .Columns.Add("Stock Code", 90)
            .Columns.Add("Stock Name", 250)
            .Columns.Add("sku_barcode", 0)
            .Columns.Add("sku_uom", 0)
            .Columns.Add("Stock Balance", 90, HorizontalAlignment.Right)
            '.Columns.Add("Average Cost", IIf(m_FrmCallerId = "frmStockAdj", 90, 0), HorizontalAlignment.Right)
            .Columns.Add("Average Cost", 90, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("sp_mt_sku_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_name", SqlDbType.NVarChar, 50)
        prm1.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@is_package", SqlDbType.Bit)
        prm3.Value = 0

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim i As Integer, intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            For i = 2 To 5
                If myReader.Item(i) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(i))
                End If
            Next

            lvItem.SubItems.Add(FormatNumber(myReader.Item(14), 2)) 'stock_balance 2 digit belakang koma 20160627 rune issue

            'lvItem.SubItems.Add(IIf(m_FrmCallerId = "frmStockAdj", FormatNumber(myReader.Item(15)), 0)) 'average_cost
            lvItem.SubItems.Add(FormatNumber(myReader.Item(15))) 'average_cost
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
        Select m_FrmCallerId
            Case "frmStockAdj"
                With frmStockAdj
                    .SKUId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .SKUName = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                    '.StockAdjQty = ListView1.SelectedItems.Item(0).SubItems.Item(9).Text
                    .SKUQtyBalance = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text
                    .StockAdjCost = ListView1.SelectedItems.Item(0).SubItems.Item(6).Text
                End With
            Case "frmStockMovement"
                With frmStockMovement
                    .SKUId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .SKUName = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                    '.StockAdjQty = ListView1.SelectedItems.Item(0).SubItems.Item(9).Text
                    .SKUQtyBalance = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text
                    .StockAdjCost = ListView1.SelectedItems.Item(0).SubItems.Item(6).Text
                End With
            Case "frmWorkOrder"
                With frmWorkOrder
                    .SKUId_detail = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .skuCodeDetail = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .skuNameDetail = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                    '.StockAdjQty = ListView1.SelectedItems.Item(0).SubItems.Item(9).Text
                    .SKUQtyBalance_detail = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text
                    .WorkOrderDetailCost = ListView1.SelectedItems.Item(0).SubItems.Item(6).Text
                End With
            Case "frmStockCostAdj"
                With frmStockCostAdj
                    .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .SKUName = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                End With
        End Select
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSKUAdj_Load(sender, e)
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
