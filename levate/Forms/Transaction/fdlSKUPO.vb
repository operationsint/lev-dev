Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlSKUPO
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FrmCallerId As String
    Dim m_loadFlag As Boolean = False

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

    Private Sub fdlSKUPRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbSKUType.Items.Clear()
        cmbSKUType.Items.Add("Stock")
        cmbSKUType.Items.Add("Stock Set")
        cmbSKUType.SelectedIndex = 0

        populateCbCategory()
        cbCategory.SelectedIndex = 0

        clear_lvw()
        m_loadFlag = True
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
        If cmbSKUType.SelectedIndex = 0 Then
            Select Case m_FrmCallerId
                Case "frmPRequest"
                    With frmPRequest
                        .SKUId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                        .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                        .SKUName = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                        .SKUUoM = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
                    End With

                Case "frmPRequestApproval"
                    With frmPRequestApproval
                        .SKUId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                        .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                        .SKUName = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                        .SKUUoM = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
                    End With

                Case "frmPO"
                    With frmPO
                        .SKUId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                        .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                        .SKUName = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                        .SKUUoM = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
                        .UnitPrice = FormatNumber(CDbl(ListView1.SelectedItems.Item(0).SubItems.Item(5).Text) / .ntbPOCurrRate.DecimalValue)
                    End With

                Case "frmPReturn"
                    With frmPReturn
                        .SKUId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                        .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                        .SKUName = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                        .SKUUoM = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
                        .SKUQtyBalance = CDbl(ListView1.SelectedItems.Item(0).SubItems.Item(7).Text) * -1
                    End With

                Case "frmSReturn"
                    With frmSReturn
                        .SKUId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                        .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                        .SKUName = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                        .SKUUoM = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
                        .ReturnCost = FormatNumber(CDbl(ListView1.SelectedItems.Item(0).SubItems.Item(8).Text) / .ntbSInvCurrRate.DecimalValue)
                        .SInvoicePrice = FormatNumber(CDbl(ListView1.SelectedItems.Item(0).SubItems.Item(9).Text) / .ntbSInvCurrRate.DecimalValue)
                    End With
                Case "frmWorkOrder"
                    With frmWorkOrder
                        .SKUId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                        .skuCode = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                        .skuName = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                        .UoM = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
                        .QtyHeader = "0"
                    End With
            End Select
        Else
            'Insert Stock Set
            Select Case m_FrmCallerId
                Case "frmWorkOrder"
                    With frmWorkOrder
                        .SKUId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                        .skuCode = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                        .skuName = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                        .UoM = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
                        .QtyHeader = "0"

                        .StockSetInsert = True
                    End With
            End Select
        End If
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            clear_lvw()
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

    Private Sub cmbSKUType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSKUType.SelectedIndexChanged
        clear_lvw()
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Category", 0)
            .Columns.Add("Stock Code", 90)
            .Columns.Add("Stock Name", 250)
            .Columns.Add("sku_barcode", 0)
            .Columns.Add("sku_uom", 0)
            .Columns.Add("last_cost", 0, HorizontalAlignment.Right)
            .Columns.Add("stock_value", 0, HorizontalAlignment.Right)
            .Columns.Add("Stock Balance", 90, HorizontalAlignment.Right)
            .Columns.Add("avg_cost", 0, HorizontalAlignment.Right)
            .Columns.Add("sales_price", 0, HorizontalAlignment.Right)
            .Columns.Add("is_package", 0)

            .AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.None)
        End With

        cmd = New SqlCommand("sp_mt_sku_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int, 255)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@sku_name", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@is_package", SqlDbType.Bit)
        prm3.Value = IIf(cmbSKUType.SelectedIndex = 0, 0, 1)
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@sku_cat_id", SqlDbType.Int)
        prm5.Value = cbCategory.SelectedValue

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 5, 1)
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
            lvItem.SubItems.Add(FormatNumber(myReader.Item(12))) 'last_cost
            lvItem.SubItems.Add(FormatNumber(myReader.Item(13))) 'stock_value
            lvItem.SubItems.Add(myReader.Item(14)) 'stock_balance
            lvItem.SubItems.Add(FormatNumber(myReader.Item(15))) 'avg_cost
            lvItem.SubItems.Add(myReader.Item(7)) 'sales_price
            lvItem.SubItems.Add(myReader.GetBoolean(20)) 'is_package
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

    Private _category As New List(Of clsMyListInt)

    Sub populateCbCategory()
        Try
            cmd = New SqlCommand("sp_mt_sku_cat_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_cat_id", SqlDbType.Int)
            prm1.Value = 0

            cn.Open()
            Dim myReader As SqlDataReader = cmd.ExecuteReader

            _category.Add(New clsMyListInt With {.Name = "All", .ItemData = 0})
            Do While myReader.Read
                _category.Add(New clsMyListInt(myReader.GetString(1), myReader.GetInt32(0)))
            Loop
            myReader.Close()
            cn.Close()


            cbCategory.DataSource = _category
            cbCategory.ValueMember = "ItemData"
            cbCategory.DisplayMember = "Name"
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try

    End Sub

    Private Sub cbCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCategory.SelectedIndexChanged
        If m_loadFlag = True Then
            clear_lvw()
        End If
    End Sub
End Class
