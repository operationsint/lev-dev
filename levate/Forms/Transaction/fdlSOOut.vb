Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlSOOut
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

    Public Property CName() As String
        Get
            Return txtFilter.Text
        End Get
        Set(ByVal Value As String)
            txtFilter.Text = Value
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

    Private Sub fdlSOOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Sales Order No.", 110)
            .Columns.Add("Date", 80)
            .Columns.Add("c_id", 0)
            .Columns.Add("Customer Code", 0)
            .Columns.Add("Customer Name", 200)
            .Columns.Add("payment_terms", 0)
            .Columns.Add("so_remarks", 0)
            .Columns.Add("sls_code_id", 0)
            .Columns.Add("sls_code", 0)
            .Columns.Add("curr_id", 0)
            .Columns.Add("curr_code", 0)
            .Columns.Add("so_curr_rate", 0)
            .Columns.Add("so_subtotal", 0)
            .Columns.Add("so_tax", 0)
            .Columns.Add("Total", IIf(m_FrmCallerId = "frmSInvoice", 100, 0), HorizontalAlignment.Right)
            .Columns.Add("SO Ref No", IIf(m_FrmCallerId = "frmSDelivery", 200, 0))
        End With

        cmd = New SqlCommand("usp_tr_so_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@so_no", SqlDbType.NVarChar, 50)
        prm1.Value = IIf(txtSONo.Text = "", DBNull.Value, txtSONo.Text)
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@so_date1", SqlDbType.DateTime)
        prm2.Value = IIf(m_FrmCallerId = "frmSDelivery", frmSDelivery.dtpSDeliveryDate.Value, frmSInvoice.dtpSInvoiceDate.Value)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@so_date2", SqlDbType.DateTime)
        prm3.Value = DBNull.Value
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@c_name", SqlDbType.NVarChar, 50)
        prm4.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@so_stat1", SqlDbType.NVarChar, 50)
        prm5.Value = IIf(m_FrmCallerId = "frmSDelivery", "O", "PD")
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@so_stat2", SqlDbType.NVarChar, 50)
        prm6.Value = IIf(m_FrmCallerId = "frmSDelivery", "PD", "FD")
        Dim prm7 As SqlParameter = cmd.Parameters.Add("@so_ref_no", SqlDbType.NVarChar, 50)
        prm7.Value = IIf(txtRefNo.Text = "", DBNull.Value, txtRefNo.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 18, 1)
        Dim lvItem As ListViewItem
        Dim i As Integer, intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            For i = 2 To 5 'so_date, c_id, c_code, c_name
                If myReader.Item(i) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(i))
                End If
            Next
            lvItem.SubItems.Add(myReader.Item(12)) 'payment_terms
            lvItem.SubItems.Add(IIf(myReader.Item(13) Is System.DBNull.Value, "", myReader.Item(13))) 'so_remarks
            lvItem.SubItems.Add(myReader.GetInt32(14)) 'sls_code_id
            lvItem.SubItems.Add(myReader.GetString(15)) 'sls_code
            lvItem.SubItems.Add(myReader.GetInt32(16)) 'curr_id
            lvItem.SubItems.Add(myReader.Item(17)) 'curr_code
            lvItem.SubItems.Add(FormatNumber(myReader.Item(18))) 'so_curr_rate
            For i = 21 To 23 'so_subtotal, so_tax, so_total
                lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
            Next
            lvItem.SubItems.Add(IIf(myReader.Item(11) Is System.DBNull.Value, "", myReader.Item(11))) 'SO Ref No
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
            Case "frmSDelivery"
                With frmSDelivery
                    .SOId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .SONo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .CId = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                    .CCode = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
                    .CName = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
                    .PaymentDueDate = CStr(DateAdd(DateInterval.Day, CDbl(ListView1.SelectedItems.Item(0).SubItems.Item(5).Text), .dtpSDeliveryDate.Value))
                    .PRRemarks = ListView1.SelectedItems.Item(0).SubItems.Item(6).Text
                    .clear_lvw()
                End With
            Case "frmSInvoice"
                With frmSInvoice
                    .SOId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .SONo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .CId = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                    .CCode = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
                    .CName = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
                    .SlsCodeId = ListView1.SelectedItems.Item(0).SubItems.Item(7).Text
                    .SlsCode = ListView1.SelectedItems.Item(0).SubItems.Item(8).Text
                    .CurrId = ListView1.SelectedItems.Item(0).SubItems.Item(9).Text
                    .CurrCode = ListView1.SelectedItems.Item(0).SubItems.Item(10).Text
                    .CurrRate = ListView1.SelectedItems.Item(0).SubItems.Item(11).Text
                End With
        End Select
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSOOut_Load(sender, e)
        End If
    End Sub

    Private Sub txtSONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSONo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSOOut_Load(sender, e)
        End If
    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub txtRefNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRefNo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSOOut_Load(sender, e)
        End If
    End Sub
End Class
