Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class fdlSKUFrom
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
    Private Sub fdlSKUFrom_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("sku_cat_id", 0)
            .Columns.Add("Stock Code", 90)
            .Columns.Add("Stock Name", 250)
        End With

        cmd = New SqlCommand("sp_mt_sku_rpt_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_name", SqlDbType.NVarChar, 50)
        prm1.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@is_package", SqlDbType.Bit)
        prm2.Value = 0
        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 3, 1)
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
            Case "frmSKUPackage"
                With frmSKUPackage
                    .SKUId2 = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .SKUCode2 = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .SKUName2 = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                End With
            Case "rptStkMovement"
                With rptStkMovement
                    .StkCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
            Case "rptStkAdjustment"
                With rptStkAdjustment
                    .SCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
            Case "rptStkList"
                With rptStkList
                    .StkCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
            Case "rptPRequest"
                With rptPRequest
                    .SCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
            Case "rptStkTransaction"
                With rptStkTransaction
                    .StkCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
            Case "rptStkLocation"
                With rptStkLocation
                    .StkCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
            Case "rptStkPrice"
                With rptStkPrice
                    .StkCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
            Case "rptStkControlFrom"
                With rptStkControl
                    .StockCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
            Case "rptStkControlTo"
                With rptStkControl
                    .StockCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
            Case "rptWorkOrderControl"
                '20160510 daniel s
                With rptWorkOrderControl
                    .StkCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
            Case "rptSlsStockSalesFrom"
                '20160517 daniel s
                With rptSlsStockSales
                    .StockCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
            Case "rptSlsStockSalesTo"
                '20160517 daniel s
                With rptSlsStockSales
                    .StockCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With

        End Select
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSKUFrom_Load(sender, e)
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