Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlLocation
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FrmCallerId As String
    Dim m_SKUId As Integer

    Public Property FrmCallerId() As String
        Get
            Return m_FrmCallerId
        End Get
        Set(ByVal Value As String)
            m_FrmCallerId = Value
        End Set
    End Property

    Public Property SKUId() As Integer
        Get
            Return m_SKUId
        End Get
        Set(ByVal Value As Integer)
            m_SKUId = Value
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

    Private Sub fdlLocation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Location Code", 90)
            '    Select Case m_FrmCallerId
            '        Case "frmSO", "frmSDelivery", "frmStockMovement", "frmWorkOrderDetail", "frmPReturn"
            '            .Columns.Add("Location Name", 140)
            '            .Columns.Add("Location Qty", 90, HorizontalAlignment.Right)

            '            cmd = New SqlCommand("usp_mt_location_SEL_BySKU", cn)
            '            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
            '            prm1.Value = m_SKUId

            '        Case Else
            '            .Columns.Add("Location Name", 250)

            '            cmd = New SqlCommand("usp_mt_location_SEL", cn)
            '    End Select

            .Columns.Add("Location Name", 140)
            .Columns.Add("Location Qty", 90, HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("usp_mt_location_SEL_BySKU", cn)
        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sku_id", SqlDbType.Int)
        prm1.Value = m_SKUId

        cmd.CommandType = CommandType.StoredProcedure

        Dim prm6 As SqlParameter = cmd.Parameters.Add("@location_name", SqlDbType.NVarChar, 50)
        prm6.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            lvItem.SubItems.Add(myReader.Item(2)) 'location_name
            lvItem.SubItems.Add(myReader.Item(3)) 'stock_balance
            If intCurrRow Mod 2 = 0 Then
                lvItem.BackColor = Color.Lavender
            Else
                lvItem.BackColor = Color.White
            End If
            lvItem.UseItemStyleForSubItems = True

            ListView1.Items.Add(lvItem)
            intCurrRow += 1
        End While
        'Select Case m_FrmCallerId
        '    Case "frmSO", "frmSDelivery", "frmStockMovement", "frmWorkOrderDetail", "frmPReturn"

        '        Dim lvItem As ListViewItem
        '        Dim intCurrRow As Integer

        '        While myReader.Read
        '            lvItem = New ListViewItem(CStr(myReader.Item(1)))
        '            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
        '            'lvItem.Tag = "v" & CStr(DR.Item(0))
        '            lvItem.SubItems.Add(myReader.Item(2)) 'location_name
        '            lvItem.SubItems.Add(myReader.Item(3)) 'stock_balance
        '            If intCurrRow Mod 2 = 0 Then
        '                lvItem.BackColor = Color.Lavender
        '            Else
        '                lvItem.BackColor = Color.White
        '            End If
        '            lvItem.UseItemStyleForSubItems = True

        '            ListView1.Items.Add(lvItem)
        '            intCurrRow += 1
        '        End While
        '    Case Else
        '        Call FillList(myReader, Me.ListView1, 2, 1)
        'End Select

        myReader.Close()
        cn.Close()
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Select Case m_FrmCallerId
            Case "frmPRequest"
                With frmPRequest
                    .LocationId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "frmPO"
                With frmPO
                    .LocationId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "frmPReceive"
                With frmPReceive
                    .LocationId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "frmPInvoice"
                With frmPInvoice
                    .LocationId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "frmPReturn"
                With frmPReturn
                    .LocationId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "frmSO"
                With frmSO
                    .LocationId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "frmSDelivery"
                With frmSDelivery
                    .LocationId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .LocationQty = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                End With
            Case "frmSReturn"
                With frmSReturn
                    .LocationId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "frmStockAdj"
                With frmStockAdj
                    .LocationId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "frmStockMovement"
                With frmStockMovement
                    .LocationId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .LocationQty = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                End With
            Case "rptStkLocation"
                With rptStkLocation
                    .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptStkTransaction"
                With rptStkTransaction
                    .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "frmWorkOrderHeader"
                With frmWorkOrder
                    .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .LocationId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                End With
            Case "frmWorkOrderDetail"
                With frmWorkOrder
                    .LocationCodeDetail = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .LocationId_Detail = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .LocationQty_Detail = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                End With
            Case "rptWorkOrderControl"
                '20160510 daniel s : rptWorkOrderControl
                With rptWorkOrderControl
                    .LocationCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
        End Select
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlLocation_Load(sender, e)
        End If
    End Sub

    Private Sub fdlLocation_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'Me.Dispose()
    End Sub
End Class
