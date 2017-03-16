Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlSKUPRequest
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

    Private Sub fdlSKUPRequest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbSKUType.Items.Clear()
        cmbSKUType.Items.Add("Stock")
        cmbSKUType.Items.Add("Stock Set")
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
                        .UnitPrice = ListView1.SelectedItems.Item(0).SubItems.Item(7).Text
                    End With
            End Select
        Else
            'Insert Stock Set
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
            .Columns.Add("sales_discount", 0)
            .Columns.Add("sales_price", 0, HorizontalAlignment.Right)
            .Columns.Add("last_cost", 0, HorizontalAlignment.Right)
            .Columns.Add("stock_value", 0, HorizontalAlignment.Right)
            .Columns.Add("Stock Balance", 90, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("sp_mt_sku_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int, 255)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@sku_name", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@is_package", SqlDbType.Bit)
        prm3.Value = IIf(cmbSKUType.SelectedIndex = 0, 0, 1)

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
            For i = 6 To 10
                If i = 10 Then
                    lvItem.SubItems.Add(FormatNumber(myReader.Item(i), 0))
                Else
                    lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
                End If
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
End Class
