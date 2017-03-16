Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class fdlSKUWO
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


    Private Sub fdlSKUWO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("sku_id", 0)
            .Columns.Add("Stock Code", 90)
            .Columns.Add("Stock Name", 250)
            .Columns.Add("UoM", 40)
            .Columns.Add("SO Outstanding Qty", 100)
            .Columns.Add("so_no", 0)
            .Columns.Add("wo_outstanding", 0)
            .Columns.Add("location_id", 0)
            .Columns.Add("Location Code", 0)
            .Columns.Add("Required Date", 100)
            .Columns.Add("so_dtl_id", 0)
            .Columns.Add("Is Formula", 100)
        End With

        cmd = New SqlCommand("sp_mt_sku_wo_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_no", SqlDbType.NVarChar, 50)
        prm1.Value = frmWorkOrder.txtSONo.Text
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@sku_name", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim i As Integer, intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            For i = 1 To 10
                If myReader.Item(i) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(i))
                End If
            Next

            If myReader.Item(11) Is System.DBNull.Value Then
                lvItem.SubItems.Add("0")
            Else
                lvItem.SubItems.Add(myReader.Item(11))
            End If

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
        Select Case m_FrmCallerId
            Case "frmWorkOrder"
                With frmWorkOrder
                    .SKUId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .skuName = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                    .UoM = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
                    .QtyHeader = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
                    .LocationId = ListView1.SelectedItems.Item(0).SubItems.Item(7).Text
                    .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(8).Text
                    If ListView1.SelectedItems.Item(0).SubItems.Item(9).Text = "" Then
                        .SODetailRequiredDate = System.DateTime.Now
                    Else
                        .SODetailRequiredDate = ListView1.SelectedItems.Item(0).SubItems.Item(9).Text
                    End If
                    .so_dtl_id = ListView1.SelectedItems.Item(0).SubItems.Item(10).Text

                    .StockSetInsert = IIf(Trim(ListView1.SelectedItems.Item(0).SubItems.Item(11).Text) = "True", True, False)
                End With
        End Select
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSKUWO_Load(sender, e)
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