Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class fdlBank
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

    Private Sub fdlBank_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Bank Code", 150)
            .Columns.Add("Bank Name", 200)
            .Columns.Add("Bank Account No", 0)
            .Columns.Add("curr_id", 0)
            .Columns.Add("Currency", 100)
            .Columns.Add("Bank Remarks", 0)
            .Columns.Add("Bank Info1", 0)
            .Columns.Add("Bank Info2", 0)
            .Columns.Add("Bank Info3", 0)
            .Columns.Add("balance", 0)
            .Columns.Add("local_balance", 0)
            .Columns.Add("base_currency", 0)
            .Columns.Add("rates", 0)
        End With

        cmd = New SqlCommand("sp_mt_bank_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@bank_id", SqlDbType.Int, 255)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@bank_name", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@curr_code", SqlDbType.NVarChar, 50)
        If m_FrmCallerId = "frmPPayment" Then
            prm3.Value = frmPPayment.txtCurrCode.Text
        ElseIf m_FrmCallerId = "frmSPayment" Then
            prm3.Value = frmSPayment.txtCurrCode.Text
        End If
        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 13, 1)
        'Call FillList(myReader, Me.ListView1, 11, 1)
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
            Case "frmPPayment"
                With frmPPayment
                    .BankId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .BankCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .BankBalance = ListView1.SelectedItems.Item(0).SubItems.Item(9).Text
                End With
            Case "frmSPayment"
                With frmSPayment
                    .BankId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .BankCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptBankListFrom"
                With rptBankList
                    .BankCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptBankListTo"
                With rptBankList
                    .BankCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptBankTransactionFrom"
                With rptBankTransaction
                    .BankCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptBankTransactionTo"
                With rptBankTransaction
                    .BankCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "frmBankAdj"
                With frmBankAdj
                    .BankCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .BankName = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .CurrId = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
                    .CurrCode = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
                    If ListView1.SelectedItems.Item(0).SubItems.Item(11).Text = "True" Then
                        .BankAdjRate = FormatNumber(1)
                        .ntbRate.ReadOnly = True
                    Else
                        .BankAdjRate = ListView1.SelectedItems.Item(0).SubItems.Item(12).Text
                        .ntbRate.ReadOnly = False
                    End If
                    .BankBalance = ListView1.SelectedItems.Item(0).SubItems.Item(9).Text
                End With
            Case "frmBankPayment"
                With frmBankPayment
                    .BankCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .BankName = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .CurrId = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
                    .CurrCode = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
                    If ListView1.SelectedItems.Item(0).SubItems.Item(11).Text = "True" Then
                        .BankAdjRate = FormatNumber(1)
                        .ntbRate.ReadOnly = True
                    Else
                        .BankAdjRate = ListView1.SelectedItems.Item(0).SubItems.Item(12).Text
                        .ntbRate.ReadOnly = False
                    End If
                    .BankBalance = ListView1.SelectedItems.Item(0).SubItems.Item(9).Text
                End With
            Case "frmBankReceipt"
                With frmBankReceipt
                    .BankCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .BankName = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                    .CurrId = ListView1.SelectedItems.Item(0).SubItems.Item(3).Text
                    .CurrCode = ListView1.SelectedItems.Item(0).SubItems.Item(4).Text
                    If ListView1.SelectedItems.Item(0).SubItems.Item(11).Text = "True" Then
                        .BankAdjRate = FormatNumber(1)
                        .ntbRate.ReadOnly = True
                    Else
                        .BankAdjRate = ListView1.SelectedItems.Item(0).SubItems.Item(12).Text
                        .ntbRate.ReadOnly = False
                    End If
                    .BankBalance = ListView1.SelectedItems.Item(0).SubItems.Item(9).Text
                End With
            Case "rptBankExpenseFrom"
                With rptBankExpense
                    .BankCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptBankExpenseTo"
                With rptBankExpense
                    .BankCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With

            Case "rptBankDetailFrom"
                With rptBankDetail
                    .BankCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptBankDetailTo"
                With rptBankDetail
                    .BankCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With

        End Select
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlBank_Load(sender, e)
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