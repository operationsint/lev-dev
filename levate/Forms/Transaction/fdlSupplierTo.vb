Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class fdlSupplierTo
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

    Private Sub fdlSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Supplier Code", 90)
            .Columns.Add("Supplier Name", 250)
            .Columns.Add("Address1", 0)
            .Columns.Add("Address2", 0)
            .Columns.Add("Contact", 0)
            .Columns.Add("Phone", 0)
            .Columns.Add("Fax", 0)
            .Columns.Add("Email", 0)
            .Columns.Add("Payment Terms", 0)
            .Columns.Add("s_remarks", 0)
            .Columns.Add("s_info1", 0)
            .Columns.Add("s_info2", 0)
            .Columns.Add("s_info3", 0)
            .Columns.Add("s_curr_id", 0)
            .Columns.Add("curr_code", 0)
            .Columns.Add("curr_rate", 0)
            .Columns.Add("s_balance", 0)
            .Columns.Add("s_local_balance", 0)
        End With

        cmd = New SqlCommand("sp_mt_supplier_rpt_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@s_id", SqlDbType.Int, 255)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@s_name", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 18, 1)
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
            Case "frmPO"
                With frmPO
                    .SId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .SCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .SName = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .CurrId = ListView1.SelectedItems.Item(0).SubItems.Item(13).Text
                    .CurrCode = ListView1.SelectedItems.Item(0).SubItems.Item(14).Text
                    .CurrRate = FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(15).Text)
                    .PaymentTerms = ListView1.SelectedItems.Item(0).SubItems.Item(8).Text
                End With
            Case "rptSupplierList"
                With rptSupplierList
                    .SCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptPIncoming"
                With rptPIncoming
                    .SCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptPInvoice"
                With rptPInvoice
                    .SCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptPReturn"
                With rptPReturn
                    .SCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptPPayment"
                With rptPPayment
                    .SCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
        End Select
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSupplier_Load(sender, e)
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