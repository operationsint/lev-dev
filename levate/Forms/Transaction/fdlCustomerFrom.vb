Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class fdlCustomerFrom
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

    Private Sub fdlCustomerFrom_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Customer Code", 90)
            .Columns.Add("Customer Name", 250)
            .Columns.Add("c_category", 0)
            .Columns.Add("c_npwp", 0)
            .Columns.Add("Address1", 0)
            .Columns.Add("Address2", 0)
            .Columns.Add("Contact", 0)
            .Columns.Add("Phone", 0)
            .Columns.Add("Fax", 0)
            .Columns.Add("Email", 0)
            .Columns.Add("c_tpb_no", 0)
            .Columns.Add("Payment Terms", 0)
            .Columns.Add("c_remarks", 0)
            .Columns.Add("c_info1", 0)
            .Columns.Add("c_info2", 0)
            .Columns.Add("c_info3", 0)
            .Columns.Add("c_curr_id", 0)
            .Columns.Add("curr_code", 0)
            .Columns.Add("curr_rate", 0)
            .Columns.Add("c_balance", 0)
            .Columns.Add("c_local_balance", 0)
        End With

        cmd = New SqlCommand("sp_mt_customer_rpt_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@c_name", SqlDbType.NVarChar, 50)
        prm1.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 21, 1)
        myReader.Close()
        cn.Close()
    End Sub
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Select Case m_FrmCallerId
            Case "rptCustomerList"
                With rptCustomerList
                    .CCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptSlsDel"
                With rptSlsDel
                    .CCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptSlsInvoice"
                With rptSlsInvoice
                    .CCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptSlsReturn"
                With rptSlsReturn
                    .CCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptSlsOrder"
                With rptSlsOrder
                    .CCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptSlsReceipt"
                With rptSlsReceipt
                    .SCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptSlsMonthlyStatementFrom"
                With rptSlsMonthlyStatement
                    .CustCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptSlsMonthlyStatementTo"
                With rptSlsMonthlyStatement
                    .CustCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptSlsCOGS"
                With rptSlsCOGS
                    .CCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptSlsARAgingFrom"
                With rptSlsARAging
                    .CCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptSlsARAgingTo"
                With rptSlsARAging
                    .CCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptSlsInvoiceSumFrom"
                With rptSlsInvoiceSum
                    .CCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptSlsInvoiceSumTo"
                With rptSlsInvoiceSum
                    .CCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptSlsTransaction"
                With rptSlsTransaction
                    .CCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With

                '20160809 bima request
            Case rptCustomerControl.Name
                With rptCustomerControl
                    .txtSCode.Text = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With

            Case "rptSlsCustomerBalanceReport"
                With rptSlsCustomerBalanceReport
                    .CCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With

        End Select
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlCustomerFrom_Load(sender, e)
        End If
    End Sub

    Private Sub fdlCustomer_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'Me.Dispose()
    End Sub
End Class