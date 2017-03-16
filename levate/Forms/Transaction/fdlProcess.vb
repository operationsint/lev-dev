Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class fdlProcess
    Private ListView1Sorter As lvColumnSorter
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

    Private Sub fdlProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("process_id", "process_id", 0)
            .Columns.Add("process_code", "Process Code", 90)
            .Columns.Add("process_name", "Process Name", 250)
        End With

        cmd = New SqlCommand("usp_mt_process_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prmProcessName As SqlParameter = cmd.Parameters.Add("@process_name", SqlDbType.NVarChar, 100)
        prmProcessName.Value = IIf(txtFilter.Text = "", DBNull.Value, txtFilter.Text)
        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item("process_id")))
            lvItem.Tag = intCurrRow 'ID

            lvItem.SubItems.Add(myReader.Item("process_code"))
            lvItem.SubItems.Add(myReader.Item("process_name"))

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
            Case "frmSKUPackage"
                With frmSKUPackage
                    .ProcessId = ListView1.SelectedItems.Item(0).SubItems.Item(ListView1.Columns("process_id").Index).Text
                    .ProcessCode = ListView1.SelectedItems.Item(0).SubItems.Item(ListView1.Columns("process_code").Index).Text
                    .ProcessName = ListView1.SelectedItems.Item(0).SubItems.Item(ListView1.Columns("process_name").Index).Text
                End With
            Case "frmWorkOrder"
                With frmWorkOrder
                    .ProcessId = ListView1.SelectedItems.Item(0).SubItems.Item(ListView1.Columns("process_id").Index).Text
                    .ProcessCode = ListView1.SelectedItems.Item(0).SubItems.Item(ListView1.Columns("process_code").Index).Text
                    .ProcessName = ListView1.SelectedItems.Item(0).SubItems.Item(ListView1.Columns("process_name").Index).Text
                End With
            Case "rptWorkOrderProcessDetail"
                With rptWorkOrderProcessDetail
                    .txtProcess.Text = ListView1.SelectedItems.Item(0).SubItems.Item(ListView1.Columns("process_code").Index).Text
                End With
            Case "rptWorkOrderLabourDetail"
                With rptWorkOrderProcessLabour
                    .txtProcess.Text = ListView1.SelectedItems.Item(0).SubItems.Item(ListView1.Columns("process_code").Index).Text
                End With

        End Select
        Me.Close()
    End Sub

    Private Sub txtFilter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFilter.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            fdlProcess_Load(sender, e)
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
