Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlInvoice
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

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

    Private Sub fdlInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Invoice No", 90)
            .Columns.Add("Invoice Date", 80)
            .Columns.Add("c_id", 0)
            .Columns.Add("c_code", 0)
            .Columns.Add("Customer Name", 200)
            .Columns.Add("so_id", 0)
            .Columns.Add("so_no", 0)
            .Columns.Add("shipment_no", 0)
            .Columns.Add("shipment_date", 0)
            .Columns.Add("invoice_remarks", 0)
            .Columns.Add("invoice_gross", 0, HorizontalAlignment.Right)
            .Columns.Add("invoice_discount", 0, HorizontalAlignment.Right)
            .Columns.Add("invoice_subtotal", 0, HorizontalAlignment.Right)
            .Columns.Add("invoice_tax", 0, HorizontalAlignment.Right)
            .Columns.Add("Total", 100, HorizontalAlignment.Right)
            .Columns.Add("invoice_receipt", 0, HorizontalAlignment.Right)
            .Columns.Add("inv_outstanding", 0, HorizontalAlignment.Right)
            .Columns.Add("so_status", 0)
            .Columns.Add("c_contact", 0)
            .Columns.Add("delivery_date", 0)
            .Columns.Add("receipt_terms", 0)
            .Columns.Add("ref_no", 0)
        End With

        cmd = New SqlCommand("usp_tr_invoice_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@invoice_no", SqlDbType.NVarChar, 50)
        prm1.Value = IIf(txtInvoiceNo.Text = "", DBNull.Value, txtInvoiceNo.Text)
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@invoice_date1", SqlDbType.DateTime)
        prm2.Value = frmAR.dtpARDate.Value
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@invoice_date2", SqlDbType.DateTime)
        prm3.Value = DBNull.Value
        Dim prm4 As SqlParameter = cmd.Parameters.Add("@c_name", SqlDbType.NVarChar, 50)
        prm4.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        Dim prm5 As SqlParameter = cmd.Parameters.Add("@so_stat", SqlDbType.NVarChar, 50)
        prm5.Value = "I"

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 14, 1)
        Dim lvItem As ListViewItem
        Dim i As Integer, intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            For i = 2 To 10
                If myReader.Item(i) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(i))
                End If
            Next
            For i = 11 To 17
                lvItem.SubItems.Add(FormatNumber(myReader.Item(i)))
            Next
            For i = 18 To 22
                If myReader.Item(i) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(i))
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

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        With frmAR
            .InvoiceId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
            .InvoiceNo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
            .CId = ListView1.SelectedItems.Item(0).SubItems.Item(2).Text
            .CCode = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
            .CName = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
            .ARRemarks = ListView1.SelectedItems.Item(0).SubItems.Item(9).Text
            .InvoiceTotal = FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(14).Text)
            .InvoiceReceipt = FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(15).Text)
            .ARAmount1 = FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(16).Text)
            .ARAmount2 = FormatNumber(CDbl(ListView1.SelectedItems.Item(0).SubItems.Item(16).Text))
            .InvoiceBalance = FormatNumber(CDbl(ListView1.SelectedItems.Item(0).SubItems.Item(14).Text) - CDbl(ListView1.SelectedItems.Item(0).SubItems.Item(15).Text) - CDbl(ListView1.SelectedItems.Item(0).SubItems.Item(16).Text))
            .ARRefNo = ListView1.SelectedItems.Item(0).SubItems.Item(21).Text
            .clear_lvw()
        End With
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlInvoice_Load(sender, e)
        End If
    End Sub

    Private Sub txtInvoiceNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInvoiceNo.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlInvoice_Load(sender, e)
        End If
    End Sub

    Private Sub fdlInvoice_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'Me.Dispose()
    End Sub
End Class
