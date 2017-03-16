Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmCurrencyD
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

    Private Sub frmCurrencyD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Currency Code", 90)
            .Columns.Add("Currency Name", 150)
            .Columns.Add("base_curr", 0)
            .Columns.Add("Currency Rate", 90, HorizontalAlignment.Right)
            .Columns.Add("Effective Date", 90)
        End With

        cmd = New SqlCommand("usp_mt_curr_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("curr_code", SqlDbType.NVarChar)
        prm1.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        Dim prm2 As SqlParameter = cmd.Parameters.Add("s_or_c", SqlDbType.NVarChar)
        Dim prm3 As SqlParameter = cmd.Parameters.Add("@s_or_c_id", SqlDbType.Int)
        Select Case m_FrmCallerId
            Case "frmSupplier"
                prm2.Value = DBNull.Value
                prm3.Value = 0
            Case "frmPO"
                prm2.Value = "S"
                prm3.Value = frmPO.SId
            Case "frmPInvoice"
                prm2.Value = "S"
                prm3.Value = frmPInvoice.SId
            Case "frmPPayment"
                prm2.Value = "S"
                prm3.Value = frmPPayment.SId
        End Select

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim i As Integer, intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            For i = 2 To 3
                If myReader.Item(i) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(myReader.Item(i))
                End If
            Next
            lvItem.SubItems.Add(FormatNumber(myReader.Item(4)))
            lvItem.SubItems.Add(myReader.GetDateTime(5).Date)
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
        Select Case DialogForm
            Case "frmCurrencyR"
                With frmCurrencyR
                    If DialogText = "txtCodeFrom" Then
                        .txtCodeFrom.Text = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    Else
                        .txtCodeTo.Text = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                    End If

                    Me.Close()
                End With
            Case Else
                MsgBox(DialogForm)
        End Select
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            frmCurrencyD_Load(sender, e)
        End If
    End Sub

    Private Sub fdlCurrency_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'Me.Dispose()
    End Sub
End Class
