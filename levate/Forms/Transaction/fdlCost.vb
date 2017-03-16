Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class fdlCost
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FrmCallerId As String
    Dim z As Integer

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

    Private Sub fdlCost_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            With ListView1
                .Clear()
                .View = View.Details
                .Columns.Add("Cost Code", 90)
                .Columns.Add("Cost Name", 200)
            End With

            cmd = New SqlCommand("usp_mt_cost_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            'Dim prm1 As SqlParameter = cmd.Parameters.Add("@cost_code", SqlDbType.NVarChar, 50)
            'prm1.Value = ""
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@cost_name", SqlDbType.NVarChar, 50)
            prm2.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)

            cn.Open()

            Dim myReader As SqlDataReader = cmd.ExecuteReader()

            Dim lvItem As ListViewItem
            Dim intCurrRow As Integer

            While myReader.Read
                lvItem = New ListViewItem(CStr(myReader.Item(0))) 'sku_id
                lvItem.Tag = intCurrRow 'ID

                lvItem.SubItems.Add(myReader.Item(1))

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
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
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
                    '.SKUId_detail = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .skuCodeDetail = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .skuNameDetail = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .WorkOrderDetailCost = 0
                End With
            Case rptWorkOrderCostDetail.Name & "From"
                With rptWorkOrderCostDetail
                    .txtCostCodeFrom.Text = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case rptWorkOrderCostDetail.Name & "To"
                With rptWorkOrderCostDetail
                    .txtCostCodeTo.Text = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
        End Select
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlCost_Load(sender, e)
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