Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class fdlTenciaAccount
    Dim strConnection2 As String = My.Settings.ConnStr2
    Dim cn2 As SqlConnection = New SqlConnection(strConnection2)
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

    '    0, 
    'ACCOUNT_CODE,
    'ACCOUNT_NAME,
    'DEPARTMENT_DESCN
    Private Sub fdlTenciaAccount_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Account Code", 90)
            .Columns.Add("Account Name", 250)
            .Columns.Add("Department", 250)
        End With

        cmd = New SqlCommand("sp_tencia_account_SEL", cn2)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@account_name", SqlDbType.NVarChar, 50)
        prm1.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)

        cn2.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 3, 1)
        myReader.Close()
        cn2.Close()
    End Sub
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Select Case m_FrmCallerId
            Case "frmFixedAssetCat"
                With frmFixedAssetCat
                    .AccountCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
            Case "frmFixedAssetCatAccumulate"
                With frmFixedAssetCat
                    .AccumulateAccountCode = ListView1.SelectedItems.Item(0).SubItems.Item(0).Text
                End With
        End Select
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlTenciaAccount_Load(sender, e)
        End If
    End Sub

    Private Sub fdlAccount_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'Me.Dispose()
    End Sub
End Class