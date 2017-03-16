Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlAccCat
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

    Private Sub fdlAccCat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Account Cat Code", 90)
            .Columns.Add("Account Cat Name", 90)
            .Columns.Add("Journal Line Type", 250)
        End With

        cmd = New SqlCommand("usp_mt_account_category_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 2, 1)
        'Dim lvItem As ListViewItem
        'Dim intCurrRow As Integer
        'intCurrRow = 0
        'While (myReader.Read)
        '    lvItem = New ListViewItem(CStr(myReader.Item(0))) 'Acc Cat Code
        '    lvItem.SubItems.Add(myReader.Item(1))
        '    lvItem.SubItems.Add(myReader.Item(2))

        '    If intCurrRow Mod 2 = 0 Then
        '        lvItem.BackColor = Color.Lavender
        '    Else
        '        lvItem.BackColor = Color.White
        '    End If
        '    lvItem.UseItemStyleForSubItems = True

        '    ListView1.Items.Add(lvItem)
        '    intCurrRow += 1
        'End While

        myReader.Close()
        cn.Close()
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Select Case m_FrmCallerId
            Case "rptGeneralLedgerReportFrom"
                With rptGeneralLedgerReport
                    .AccountCatCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptGeneralLedgerReportTo"
                With rptGeneralLedgerReport
                    .AccountCatCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptTrialBalanceReportFrom"
                With rptTrialBalanceReport
                    .AccountCatCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptTrialBalanceReportTo"
                With rptTrialBalanceReport
                    .AccountCatCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With

        End Select
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlAccCat_Load(sender, e)
        End If
    End Sub

    Private Sub fdlAccCat_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'Me.Dispose()
    End Sub
End Class
