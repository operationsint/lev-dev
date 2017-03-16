Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlPOOut
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FrmCallerId As String
    Dim m_POStat1 As String, m_POStat2 As String

    Public Property FrmCallerId() As String
        Get
            Return m_FrmCallerId
        End Get
        Set(ByVal Value As String)
            m_FrmCallerId = Value
        End Set
    End Property

    Public Property SName() As String
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

    Private Sub fdlPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Purchase Order No.", 110)
            .Columns.Add("Date", 80)
            .Columns.Add("s_id", 0)
            .Columns.Add("Supplier Code", 0)
            .Columns.Add("Supplier Name", 200)
            .Columns.Add("payment_terms", 0)
            .Columns.Add("po_remarks", 0)
            .Columns.Add("pch_code_id", 0)
            .Columns.Add("pch_code", 0)
            .Columns.Add("curr_id", 0)
            .Columns.Add("curr_code", 0)
            .Columns.Add("po_curr_rate", 0)
            .Columns.Add("po_subtotal", 0)
            .Columns.Add("po_tax", 0)
            .Columns.Add("Total", IIf(m_FrmCallerId = "frmPInvoice", 100, 0), HorizontalAlignment.Right)
        End With

        cmd = New SqlCommand("sp_tr_po_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@po_no", SqlDbType.NVarChar, 50)
        prm1.Value = IIf(txtPONo.Text = "", DBNull.Value, txtPONo.Text)
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@po_date1", SqlDbType.DateTime)
        prm2.Value = IIf(m_FrmCallerId = "frmPReceive", frmPReceive.dtpPReceiveDate.Value, frmPInvoice.dtpPInvoiceDate.Value)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@po_date2", SqlDbType.DateTime)
        prm3.Value = DBNull.Value
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@s_name", SqlDbType.NVarChar, 50)
        prm4.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)

        Select Case m_FrmCallerId
            Case "frmPReceive"
                m_POStat1 = "O"
                m_POStat2 = "PR"
            Case "frmPInvoice"
                m_POStat1 = "PR"
                m_POStat2 = "FR"
            Case "frmPReturn"
                m_POStat1 = "I"
                m_POStat2 = "PP"
        End Select

        Dim prm5 As SqlParameter = cmd.Parameters.Add("@po_stat1", SqlDbType.NVarChar, 50)
        prm5.Value = m_POStat1
        Dim prm6 As SqlParameter = cmd.Parameters.Add("@po_stat2", SqlDbType.NVarChar, 50)
        prm6.Value = m_POStat2

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 16, 1)
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
            lvItem.SubItems.Add(myReader.Item(12))
            lvItem.SubItems.Add(IIf(myReader.Item(14) Is System.DBNull.Value, "", myReader.Item(14)))
            lvItem.SubItems.Add(myReader.GetInt32(15))
            lvItem.SubItems.Add(myReader.Item(16))
            lvItem.SubItems.Add(myReader.GetInt32(17))
            lvItem.SubItems.Add(myReader.Item(18))
            For i = 19 To 22
                lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
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
            Case "frmPReceive"
                With frmPReceive
                    .POId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .PONo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .SId = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                    .SCode = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
                    .SName = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
                    .PaymentDueDate = CStr(DateAdd(DateInterval.Day, CInt(ListView1.SelectedItems.Item(0).SubItems.Item(5).Text), .dtpPReceiveDate.Value))
                    .PRRemarks = ListView1.SelectedItems.Item(0).SubItems.Item(6).Text
                End With
            Case "frmPInvoice"
                With frmPInvoice
                    .POId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .PONo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .SId = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
                    .SCode = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
                    .SName = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
                    .PaymentTerms = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text
                    .PaymentDueDate = CStr(DateAdd(DateInterval.Day, CInt(ListView1.SelectedItems.Item(0).SubItems.Item(5).Text), .dtpPInvoiceDate.Value))
                    .PchCodeId = ListView1.SelectedItems.Item(0).SubItems.Item(7).Text
                    .PchCode = ListView1.SelectedItems.Item(0).SubItems.Item(8).Text
                    .CurrId = ListView1.SelectedItems.Item(0).SubItems.Item(9).Text
                    .CurrCode = ListView1.SelectedItems.Item(0).SubItems.Item(10).Text
                    .CurrRate = ListView1.SelectedItems.Item(0).SubItems.Item(11).Text
                    .PInvoiceRemarks = ListView1.SelectedItems.Item(0).SubItems.Item(6).Text
                End With
        End Select
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlPO_Load(sender, e)
        End If
    End Sub

    Private Sub txtPONo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPONo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlPO_Load(sender, e)
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
