Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlIncome
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_FrmCallerId As String
    Public fdlIncomeMode As Integer '0 = income only, 1 = expense only, 2= both


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

    Private Sub FillListView()
        '#RK - 20160209_01 - Enable Income/Expense/Both Code 
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Inc/Exp Code", 90)
            .Columns.Add("Inc/Exp Name", 250)
        End With

        cmd = New SqlCommand("usp_mt_expinc_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@expinc_type", SqlDbType.NVarChar)
        If cmbType.SelectedIndex = 0 Then
            prm1.Value = "I"
        Else
            prm1.Value = "E"
        End If
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@expinc_name", SqlDbType.NVarChar, 50)
        prm2.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 2, 1)
        myReader.Close()
        cn.Close()
        '#RK - 20160209_01 - End
    End Sub


    Private Sub fdlIncome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '#RK - 20160209_01 - Enable Income/Expense/Both Code 
        cmbType.Items.Clear()
        cmbType.Items.Add("Income")
        cmbType.Items.Add("Expense")
        If fdlIncomeMode = 0 Or fdlIncomeMode = 2 Then
            cmbType.SelectedIndex = 0
        Else
            cmbType.SelectedIndex = 1
        End If

        If fdlIncomeMode <> 2 Then
            cmbType.Enabled = False
        End If

        FillListView()
        '#RK - 20160209_01 - End

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
            Case "frmSO"
                With frmSO
                    .SKUId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .SKUName = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
            Case "frmSInvoice"
                With frmSInvoice
                    .SKUId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .SKUCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .SKUName = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
            Case "frmBankReceipt"
                With frmBankReceipt
                    .ExpincCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .ExpincName = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
        End Select

        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlIncome_Load(sender, e)
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub cmbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbType.SelectedIndexChanged
        FillListView()
    End Sub
End Class
