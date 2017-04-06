Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlCustomer
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

    Private Sub fdlCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        cmd = New SqlCommand("sp_mt_customer_SEL", cn)
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
        Select m_FrmCallerId
            Case "frmSO"
                With frmSO
                    .CId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .CCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .CName = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .CContact = ListView1.SelectedItems.Item(0).SubItems.Item(5).Text
                    .PaymentTerms = ListView1.SelectedItems.Item(0).SubItems.Item(11).Text
                    .CurrId = ListView1.SelectedItems.Item(0).SubItems.Item(16).Text
                    .CurrCode = ListView1.SelectedItems.Item(0).SubItems.Item(17).Text
                    If ListView1.SelectedItems.Item(0).SubItems.Item(17).Text = "IDR" Then
                        .ntbSOCurrRate.ReadOnly = True
                    Else
                        .ntbSOCurrRate.ReadOnly = False
                    End If
                    .CurrRate = FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(18).Text)
                End With
            Case "frmSInvoice"
                With frmSInvoice
                    .CId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .CCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .CName = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .CurrId = ListView1.SelectedItems.Item(0).SubItems.Item(16).Text
                    .CurrCode = ListView1.SelectedItems.Item(0).SubItems.Item(17).Text
                    If ListView1.SelectedItems.Item(0).SubItems.Item(17).Text = "IDR" Then
                        .ntbSInvCurrRate.ReadOnly = True
                    Else
                        .ntbSInvCurrRate.ReadOnly = False
                    End If
                    .CurrRate = FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(18).Text)
                    .SOId = 0
                    .SONo = ""
                    .PaymentTerms = ListView1.SelectedItems.Item(0).SubItems.Item(11).Text
                End With
            Case "frmSPayment"
                With frmSPayment
                    .CId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .CCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .CName = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .CurrId = ListView1.SelectedItems.Item(0).SubItems.Item(16).Text
                    .CurrCustId = ListView1.SelectedItems.Item(0).SubItems.Item(16).Text
                    .CurrCode = ListView1.SelectedItems.Item(0).SubItems.Item(17).Text
                    If ListView1.SelectedItems.Item(0).SubItems.Item(17).Text = "IDR" Then
                        .ntbSPaymentCurrRate.ReadOnly = True
                    Else
                        .ntbSPaymentCurrRate.ReadOnly = False
                    End If
                    .CurrCustCode = ListView1.SelectedItems.Item(0).SubItems.Item(17).Text
                    .CurrRate = FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(18).Text)
                    .CurrPaymentRate = FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(18).Text)
                    '.SAdvancePayment = IIf(frmPPayment.chbIsPaymentAdvance.Checked = True, FormatNumber("0"), FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(18).Text))
                End With
            Case "frmBC"
                With frmBC
                    .CId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .CCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .CName = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .CurrId = ListView1.SelectedItems.Item(0).SubItems.Item(16).Text
                    .CurrCode = ListView1.SelectedItems.Item(0).SubItems.Item(17).Text
                    .CurrRate = FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(18).Text)
                End With
            Case "frmSReturn"
                With frmSReturn
                    .CId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .CCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .CName = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .CurrId = ListView1.SelectedItems.Item(0).SubItems.Item(16).Text
                    .CurrCode = ListView1.SelectedItems.Item(0).SubItems.Item(17).Text
                    If ListView1.SelectedItems.Item(0).SubItems.Item(17).Text = "IDR" Then
                        .ntbSInvCurrRate.ReadOnly = True
                    Else
                        .ntbSInvCurrRate.ReadOnly = False
                    End If
                    .CurrRate = FormatNumber(ListView1.SelectedItems.Item(0).SubItems.Item(18).Text)
                End With
        End Select
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlCustomer_Load(sender, e)
        End If
    End Sub

    Private Sub fdlCustomer_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'Me.Dispose()
    End Sub
End Class
