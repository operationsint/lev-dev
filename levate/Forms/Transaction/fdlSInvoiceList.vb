Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class fdlSInvoiceList
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If ListView1.CheckedItems.Count > 0 Then
            With rptFakturPajak
                    Try
                    For i = 1 To ListView1.Items.Count
                        If ListView1.Items(i - 1).Checked = True Then
                            .ListView1.Items.Add(ListView1.Items(i - 1).Clone())
                        End If
                    Next
                    For y = 1 To ListView1.Items.Count
                        If ListView1.Items(y - 1).Checked = True Then
                            .txtFakturPajakNo.Text = ListView1.Items(y - 1).SubItems(6).Text
                            .txtFakturInvNo.Text = ListView1.Items(y - 1).SubItems(7).Text
                            .txtNotes.Text = ListView1.Items(y - 1).SubItems(8).Text
                            Exit For
                        End If
                    Next

                    '.clear_lvw()
                Catch ex As Exception
                    MsgBox(ex.Message)
                    If cn.State = ConnectionState.Open Then cn.Close()
                End Try
            End With
            Me.Close()
        Else
            MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub fdlSInvoiceList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Sales Invoice No.", 120)
            .Columns.Add("Date", 80)
            .Columns.Add("Customer Code", 80)
            .Columns.Add("Customer Name", 250)
            .Columns.Add("Currency", 80)
            .Columns.Add("Total", 100, HorizontalAlignment.Right)
            .Columns.Add("Tax Inv No", 100)
            .Columns.Add("Multi Inv No", 100)
            .Columns.Add("Tax Notes", 350)
            
        End With

        cmd = New SqlCommand("usp_tr_sinvoice_list_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinvoice_no", SqlDbType.NVarChar)
        prm1.Value = IIf(txtSInvoiceNo.Text = "", DBNull.Value, txtSInvoiceNo.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 16, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            lvItem.SubItems.Add(myReader.Item(2)) 'sinvoice_date
            lvItem.SubItems.Add(myReader.Item(3)) 'customer_code
            lvItem.SubItems.Add(myReader.Item(4)) 'customer_name
            lvItem.SubItems.Add(myReader.GetString(5)) 'curr_code
            lvItem.SubItems.Add(FormatNumber(myReader.GetValue(6))) 'sinvoice_total
            lvItem.SubItems.Add(myReader.GetString(7)) 'tax inv no
            lvItem.SubItems.Add(myReader.GetString(8)) 'multi inv no
            lvItem.SubItems.Add(myReader.GetString(9)) 'tax notes

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

    End Sub

    Private Sub txtSInvoiceNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSInvoiceNo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlSInvoiceList_Load(sender, e)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
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
End Class