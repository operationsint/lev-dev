Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class fdlWOConfirmTrans
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FrmCallerId As String
    Dim m_WorkOrderNo As String

    Public Property FrmCallerId() As String
        Get
            Return m_FrmCallerId
        End Get
        Set(ByVal Value As String)
            m_FrmCallerId = Value
        End Set
    End Property

    Public Property WorkOrderNo() As String
        Get
            Return m_WorkOrderNo
        End Get
        Set(ByVal Value As String)
            m_WorkOrderNo = Value
        End Set
    End Property

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub fdlWOConfirmTrans_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("stock_adj_dtl_id", "stock_adj_dtl_id", 0)
            .Columns.Add("stock_adj_no", "Confirm No.", 110)
            .Columns.Add("stock_adj_date", "Confirm Date", 100)
            .Columns.Add("sku_id", "sku_id", 0)
            .Columns.Add("sku_code", "Stock Code", 120)
            .Columns.Add("stock_adj_description", "Stock Name", 220)
            .Columns.Add("location_id", "location_id", 0)
            .Columns.Add("location_code", "Location", 80)
            .Columns.Add("stock_adj_qty", "Total Qty", 80, HorizontalAlignment.Right, vbNull)
            .Columns.Add("sku_uom", "UoM", 50)
            .Columns.Add("stock_adj_cost", "Unit Cost", 90, HorizontalAlignment.Right, vbNull)
            .Columns.Add("stock_adj_value", "Total Cost", 120, HorizontalAlignment.Right, vbNull)
        End With

        cmd = New SqlCommand("usp_tr_work_order_prod_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@wo_no", SqlDbType.NVarChar, 50)
        prm1.Value = m_WorkOrderNo

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 18, 1)
        Dim lvItem As ListViewItem
        Dim i As Integer, intCurrRow As Integer

        While myReader.Read


            lvItem = New ListViewItem(CStr(myReader.GetValue(myReader.GetOrdinal("stock_adj_dtl_id"))))
            lvItem.Tag = intCurrRow

            lvItem.SubItems.Add(myReader.GetValue(myReader.GetOrdinal("stock_adj_no")))
            lvItem.SubItems.Add(myReader.GetValue(myReader.GetOrdinal("stock_adj_date")))
            lvItem.SubItems.Add(myReader.GetValue(myReader.GetOrdinal("sku_id")))
            lvItem.SubItems.Add(myReader.GetString(myReader.GetOrdinal("sku_code")))
            lvItem.SubItems.Add(myReader.GetString(myReader.GetOrdinal("stock_adj_description")))
            lvItem.SubItems.Add(myReader.GetValue(myReader.GetOrdinal("location_id")))
            lvItem.SubItems.Add(myReader.GetString(myReader.GetOrdinal("location_code")))
            lvItem.SubItems.Add(FormatNumber(myReader.GetDecimal(myReader.GetOrdinal("stock_adj_qty"))))
            lvItem.SubItems.Add(myReader.GetString(myReader.GetOrdinal("sku_uom")))
            lvItem.SubItems.Add(FormatNumber(myReader.GetDecimal(myReader.GetOrdinal("stock_adj_cost"))))
            lvItem.SubItems.Add(FormatNumber(myReader.GetDecimal(myReader.GetOrdinal("stock_adj_value"))))


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


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

End Class