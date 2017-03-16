Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmCustomerD

    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand


    Private Sub frmCustomerD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Customer Code", 90)
            .Columns.Add("Customer Name", 250)
            .Columns.Add("c_category", 0)
            .Columns.Add("Address1", 0)
            .Columns.Add("Address2", 0)
            .Columns.Add("Contact", 0)
            .Columns.Add("Phone", 0)
            .Columns.Add("Fax", 0)
            .Columns.Add("Email", 0)
            .Columns.Add("Receipt Terms", 0)
        End With

        cmd = New SqlCommand("sp_mt_customer_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@c_name", SqlDbType.NVarChar, 50)
        prm1.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Call FillList(myReader, Me.ListView1, 10, 1)
        myReader.Close()
        cn.Close()
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Select Case DialogForm
            Case "frmCustomerR"
                With frmCustomerR
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

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If ListView1.SelectedItems.Count > 0 Then
            ListView1_DoubleClick(sender, e)
        Else
            MessageBox.Show("You didn't select any item yet. Please select an item.", Me.Text)
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            frmCustomerD_Load(sender, e)
        End If
    End Sub

   
End Class