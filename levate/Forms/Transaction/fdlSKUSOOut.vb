Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlSKUSOOut
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim isAllowStockMinus As Boolean = GetSysInit("sku_qty_minus")

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
        Dim SODtlType As String, m_SDeliveryQty As Double, m_LocationCode As String, m_LocationQty As Double
        If ListView1.CheckedItems.Count > 0 Then
            'Insert tr_sdelivery
            With frmSDelivery
                If .SDeliveryId = 0 Then .SaveSDeliveryHeader()
                If .SDeliveryId > 0 Then
                    Try
                        'tr_sdelivery_dtl
                        For i = 1 To ListView1.Items.Count
                            If ListView1.Items(i - 1).Checked = True Then
                                SODtlType = ListView1.Items(i - 1).SubItems.Item(2).Text
                                m_SDeliveryQty = CDbl(ListView1.Items(i - 1).SubItems.Item(6).Text)
                                m_LocationCode = ""
                                m_LocationQty = 0
                                'Check Location Qty Available
                                If SODtlType = "S" Then
                                    cmd = New SqlCommand("usp_mt_sku_location_SEL", cn)
                                    cmd.CommandType = CommandType.StoredProcedure

                                    Dim prm11 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
                                    prm11.Value = CInt(ListView1.Items(i - 1).SubItems.Item(3).Text)
                                    Dim prm12 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int)
                                    prm12.Value = CInt(ListView1.Items(i - 1).SubItems.Item(4).Text)

                                    cn.Open()
                                    Dim myReader As SqlDataReader = cmd.ExecuteReader()

                                    While myReader.Read
                                        m_LocationCode = myReader.GetString(5)
                                        m_LocationQty = myReader.GetValue(7)
                                    End While
                                    myReader.Close()
                                    cn.Close()
                                End If

                                'To get the delivered qty with the location qty available
                                'If SODtlType = "S" And isAllowStockMinus = False And m_SDeliveryQty > m_LocationQty Then
                                '    MsgBox(ListView1.Items(i - 1).SubItems.Item(1).Text & " has Delivered Qty > Location Qty. There is " & m_LocationQty & " at location " & m_LocationCode)
                                '    m_SDeliveryQty = m_LocationQty
                                'End if
                                If SODtlType = "S" And isAllowStockMinus = False And m_SDeliveryQty > m_LocationQty Then
                                    MsgBox(ListView1.Items(i - 1).SubItems.Item(1).Text & " has Delivered Qty > Location Qty. There is " & m_LocationQty & " at location " & m_LocationCode)
                                ElseIf (SODtlType = "S" And isAllowStockMinus = False And m_SDeliveryQty = m_LocationQty Or m_SDeliveryQty < m_LocationQty) Or isAllowStockMinus = True Or SODtlType <> "S" Then
                                    'If (isAllowStockMinus = False And SODtlType = "S" And m_SDeliveryQty > 0) Or isAllowStockMinus = True Or SODtlType <> "S" Then
                                    'Insert tr_sdelivery_dtl
                                    cmd = New SqlCommand("usp_tr_sdelivery_dtl_INS", cn)
                                    cmd.CommandType = CommandType.StoredProcedure

                                    Dim prm1 As SqlParameter = cmd.Parameters.Add("@sdelivery_id", SqlDbType.Int)
                                    prm1.Value = .SDeliveryId
                                    Dim prm2 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
                                    prm2.Value = .SOId
                                    Dim prm3 As SqlParameter = cmd.Parameters.Add("@so_dtl_id", SqlDbType.Int)
                                    prm3.Value = LeftSplitUF(ListView1.Items(i - 1).Tag)
                                    Dim prm4 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
                                    prm4.Value = CInt(ListView1.Items(i - 1).SubItems.Item(3).Text)
                                    Dim prm5 As SqlParameter = cmd.Parameters.Add("@location_id", SqlDbType.Int)
                                    prm5.Value = CInt(ListView1.Items(i - 1).SubItems.Item(4).Text)
                                    Dim prm6 As SqlParameter = cmd.Parameters.Add("@sdelivery_qty", SqlDbType.Decimal)
                                    prm6.Value = m_SDeliveryQty
                                    Dim prm7 As SqlParameter = cmd.Parameters.Add("@previous_qty", SqlDbType.Decimal)
                                    prm7.Value = CDbl(ListView1.Items(i - 1).SubItems.Item(9).Text)
                                    Dim prm8 As SqlParameter = cmd.Parameters.Add("@avg_cost", SqlDbType.Money)
                                    prm8.Value = CDbl(ListView1.Items(i - 1).SubItems.Item(12).Text)
                                    Dim prm13 As SqlParameter = cmd.Parameters.Add("@row_count", SqlDbType.Int)
                                    prm13.Direction = ParameterDirection.Output
                                    cn.Open()
                                    cmd.ExecuteReader()
                                    cn.Close()
                                    If prm13.Value = 1 Then
                                        MsgBox("This stock already inserted before!", vbCritical, Me.Text)
                                    End If
                                End If

                            End If
                        Next
                        .clear_lvw()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        If cn.State = ConnectionState.Open Then cn.Close()
                    End Try
                Else
                    MessageBox.Show("Can't insert to line items because error was happened before", Me.Text)
                End If
            End With
            Me.Close()
        Else
            MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        End If
        'If ListView1.SelectedItems.Count > 0 Then
        '    ListView1_DoubleClick(sender, e)
        'Else
        '    MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        'End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub fdlSKUSOOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Stock Code", 90)
            .Columns.Add("Stock Name", 250)
            .Columns.Add("so_dtl_type", 0)
            .Columns.Add("sku_id", 0)
            .Columns.Add("locationId", 0)
            .Columns.Add("Location Code", 90)
            .Columns.Add("Outstanding Qty", 90, HorizontalAlignment.Right)
            .Columns.Add("sku_uom", 0)
            .Columns.Add("so_qty", 0)
            .Columns.Add("sum_sdelivery_qty", 0)
            .Columns.Add("Lot Job No.", 90)
            .Columns.Add("Required Date", 90)
            .Columns.Add("avg_cost", 0)
        End With

        cmd = New SqlCommand("usp_tr_so_dtl_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_id", SqlDbType.Int)
        prm1.Value = frmSDelivery.SOId
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@sku_name", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@outstanding", SqlDbType.Bit)
        prm3.Value = 1
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@lot_job", SqlDbType.NVarChar, 50)
        prm4.Value = IIf(txtLotJob.Text = "", DBNull.Value, txtLotJob.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 5, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            Select Case myReader.GetString(2)
                Case "S"
                    lvItem = New ListViewItem(CStr(myReader.Item(5)))
                Case "I"
                    lvItem = New ListViewItem(CStr(myReader.Item(21)))
                Case Else
                    lvItem = New ListViewItem("")
            End Select
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            lvItem.SubItems.Add(myReader.Item(6)) 'sku_name
            lvItem.SubItems.Add(myReader.GetString(2)) 'so_dtl_type
            Select Case myReader.GetString(2)
                Case "S"
                    lvItem.SubItems.Add(myReader.GetInt32(4)) 'sku_id
                Case "I"
                    lvItem.SubItems.Add(myReader.GetInt32(20)) 'income_id
            End Select
            lvItem.SubItems.Add(myReader.GetInt32(7)) 'location_id
            lvItem.SubItems.Add(IIf(myReader.Item(8) Is System.DBNull.Value, "", myReader.Item(8))) 'location_code
            lvItem.SubItems.Add(myReader.GetValue(22)) 'stock_balance
            lvItem.SubItems.Add(IIf(myReader.Item(10) Is System.DBNull.Value, "", myReader.Item(10))) 'sku_uom
            lvItem.SubItems.Add(myReader.GetValue(9)) 'so_qty
            lvItem.SubItems.Add(myReader.GetValue(23)) 'sum_sdelivery_qty
            lvItem.SubItems.Add(IIf(myReader.Item(24) Is System.DBNull.Value, "", myReader.Item(24))) 'lot_job_no
            lvItem.SubItems.Add(IIf(myReader.Item(25) Is System.DBNull.Value, "", myReader.Item(25))) 'required_date
            lvItem.SubItems.Add(myReader.GetValue(11)) 'avg_cost
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
        With frmSDelivery
            .SODId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
            .SODtlType = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
            .SKUId = IIf(ListView1.SelectedItems.Item(0).SubItems.Item(2).Text = "S", ListView1.SelectedItems.Item(0).SubItems.Item(3).Text, 0)
            .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
            .SKUDescription = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
            .LocationId = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
            .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text
            .SOQty = ListView1.SelectedItems.Item(0).SubItems.Item(8).Text
            .PreviousQty = ListView1.SelectedItems.Item(0).SubItems.Item(9).Text
            .SDeliveryQty = ListView1.SelectedItems.Item(0).SubItems.Item(6).Text
            .SKUUoM = ListView1.SelectedItems.Item(0).SubItems.Item(7).Text
            .IncomeId = IIf(ListView1.SelectedItems.Item(0).SubItems.Item(2).Text = "I", ListView1.SelectedItems.Item(0).SubItems.Item(3).Text, 0)
            .SKUAverageCost = ListView1.SelectedItems.Item(0).SubItems.Item(12).Text
        End With
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSKUSOOut_Load(sender, e)
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

    Private Sub chbSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSelectAll.CheckedChanged
        If chbSelectAll.Checked = True Then
            With ListView1
                For i = 1 To .Items.Count
                    .Items.Item(i - 1).Checked = True
                Next
            End With
        Else
            With ListView1
                For i = 1 To .Items.Count
                    .Items.Item(i - 1).Checked = False
                Next
            End With
        End If
    End Sub

    Private Sub txtLotJob_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLotJob.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSKUSOOut_Load(sender, e)
        End If
    End Sub
End Class
