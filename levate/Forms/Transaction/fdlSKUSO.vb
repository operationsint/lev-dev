Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlSKUSO
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FrmCallerId As String
    Dim Dec As Integer = GetSysInit("decimal_digit")

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

    Private Sub fdlSKUSO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbSKUType.Items.Clear()
        cmbSKUType.Items.Add("Stock")
        cmbSKUType.Items.Add("Stock Set")

        cmd = New SqlCommand("sp_mt_sku_cat_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_cat_id", SqlDbType.Int)
        prm1.Value = 0

        cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader

        cmbSKUCategory.Items.Add(New clsMyListInt("All", 0))
        Do While myReader.Read
            cmbSKUCategory.Items.Add(New clsMyListInt(myReader.GetString(1), myReader.GetInt32(0)))
        Loop
        myReader.Close()
        cn.Close()

        cmbSKUCategory.SelectedIndex = 0
        cmbSKUType.SelectedIndex = 0
        clear_lvw()
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
        'If cmbSKUType.SelectedIndex = 0 Then
        With frmSO
            .SKUId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
            .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
            .SKUName = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
            .SalesDiscount = FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(5).Text * 100, Dec)
            '.SalesPrice = FormatNumber(CDbl(ListView1.SelectedItems.Item(0).SubItems.Item(6).Text) / .ntbSOCurrRate.DecimalValue, Dec)
            .SalesPrice = FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(6).Text, Dec)
            .SKUPackageCheck = ListView1.SelectedItems.Item(0).SubItems.Item(10).Text
        End With

        'Else
        'Insert Stock Set
        'Try
        '    If frmSO.SOId = 0 Then frmSO.SaveSOHeader()
        '    cmd = New SqlCommand("usp_tr_so_dtl_INS_ByPack", cn)
        '    cmd.CommandType = CommandType.StoredProcedure

        '    Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int, 255)
        '    prm1.Value = frmSO.SOId
        '    Dim prm2 As SqlParameter = cmd.Parameters.Add("@tax_percent", SqlDbType.Decimal)
        '    prm2.Value = frmSO.ntbSOTaxPercent.Text / 100
        '    Dim prm3 As SqlParameter = cmd.Parameters.Add("@sku_id1", SqlDbType.Int, 255)
        '    prm3.Value = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
        '    Dim prm4 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int, 255)
        '    prm4.Value = frmSO.LocationId
        '    cn.Open()
        '    cmd.ExecuteReader()
        '    cn.Close()
        '    frmSO.clear_lvw()
        '    frmSO.refresh_total()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        'End If
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            clear_lvw()
        End If
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
            .Columns.Add("sales_discount", 0)
            .Columns.Add("sales_price", 0, HorizontalAlignment.Right)
            .Columns.Add("last_cost", 0, HorizontalAlignment.Right)
            .Columns.Add("stock_value", 0, HorizontalAlignment.Right)
            .Columns.Add("Stock Balance", 90, HorizontalAlignment.Right)
            .Columns.Add("is_package", 0)
        End With

        cmd = New SqlCommand("sp_mt_sku_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@sku_name", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        If cmbSKUCategory.SelectedIndex > -1 Then
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@sku_cat_id", SqlDbType.Int)
            prm3.Value = cmbSKUCategory.Items(cmbSKUCategory.SelectedIndex).ItemData
        End If
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@is_package", SqlDbType.Bit)
        prm4.Value = IIf(cmbSKUType.SelectedIndex = 0, 0, 1)
        'Dim prm2 As SqlParameter = cmd.Parameters.Add(IIf(cmbSKUType.Text = "Barcode", "@sku_barcode", "@sku_name"), SqlDbType.NVarChar, 50)
        'prm2.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 7, 1)
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
            lvItem.SubItems.Add(FormatNumber(myReader.Item(6))) 'sales_discount
            lvItem.SubItems.Add(FormatNumber(myReader.Item(7), Dec)) 'sales_price
            lvItem.SubItems.Add(FormatNumber(myReader.Item(12))) 'last_cost
            lvItem.SubItems.Add(FormatNumber(myReader.Item(13))) 'stock_value
            lvItem.SubItems.Add(myReader.Item(14)) 'stock_balance
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

    Private Sub cmbFilterBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSKUType.SelectedIndexChanged
        clear_lvw()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub cmbSKUCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSKUCategory.SelectedIndexChanged
        clear_lvw()
    End Sub
End Class
