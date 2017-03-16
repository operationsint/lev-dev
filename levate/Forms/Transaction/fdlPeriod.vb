Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlPeriod
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

    Private Sub fdlPeriod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Period ID", 90)
            .Columns.Add("Period Name", 100)
            .Columns.Add("Date Start", 100)
            .Columns.Add("Date End", 100)

        End With

        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@Period_Id", SqlDbType.NVarChar, 50)
        prm1.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 4, 0)

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer
        intCurrRow = 0
        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(0))) 'Period ID
            lvItem.SubItems.Add(myReader.Item(1)) 'Period Name 
            lvItem.SubItems.Add(myReader.Item(2)) 'Start
            lvItem.SubItems.Add(myReader.Item(3)) 'End
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
        Select Case m_FrmCallerId
            Case "frmSYSAccount"
                With frmSYSAccount
                    .AccountId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .AccountCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "frmSKUCat"
                With frmSKUCat
                    .AccountId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .AccountCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "frmExpInc"
                With frmExpInc
                    .AccountId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .AccountCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "frmJournal"
                With frmJournal
                    .AccountId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                    .AccountCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    .AccountName = ListView1.SelectedItems.Item(0).SubItems.Item(1).Text
                End With
            Case "rptGLJournalTransFrom"
                With rptGLJournalTrans
                    .AccountCodeFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptGLJournalTransTo"
                With rptGLJournalTrans
                    .AccountCodeTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptGeneralLedgerReport"
                With rptGeneralLedgerReport
                    .Period = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptPnLReportFrom"
                With rptPnLReport
                    .PeriodFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptPnLReportTo"
                With rptPnLReport
                    .PeriodTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptTrialBalanceReport"
                With rptTrialBalanceReport
                    .Period = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "rptBalanceSheet"
                With rptBalanceSheet
                    .Period = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
                '20160714 
            Case rptGLJournalTransDetail.Name & "From"
                With rptGLJournalTransDetail
                    .PeriodFrom = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case rptGLJournalTransDetail.Name & "To"
                With rptGLJournalTransDetail
                    .PeriodTo = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With

                '20160807
            Case rptSupplierControl.Name & "From"
                With rptSupplierControl
                    .txtPeriodFrom.Text = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case rptSupplierControl.Name & "To"
                With rptSupplierControl
                    .txtPeriodTo.Text = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With

                '20160809 bima req
            Case rptCustomerControl.Name & "From"
                With rptCustomerControl
                    .txtPeriodFrom.Text = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case rptCustomerControl.Name & "To"
                With rptCustomerControl
                    .txtPeriodTo.Text = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With

        End Select
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlPeriod_Load(sender, e)
        End If
    End Sub

    Private Sub fdlPeriod_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'Me.Dispose()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class
