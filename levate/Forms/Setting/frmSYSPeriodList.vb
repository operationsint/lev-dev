Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmSYSPeriodList
    Private ListView1Sorter As lvColumnSorter
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim isShowAll As Boolean = False
    Dim m_ClosedStatusArr(1, 1) As String

    Private Sub frmSYSPeriodList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Add item is_posted
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "is_closed"

        cn.Open()
        Dim myReader = cmd.ExecuteReader

        Dim i As Integer
        i = 0
        While myReader.Read
            m_ClosedStatusArr(i, 0) = myReader.GetString(0)
            m_ClosedStatusArr(i, 1) = myReader.GetString(1)
            i += 1
        End While

        myReader.Close()
        cn.Close()

        'btnFilter_Click(sender, e)
        clear_lvw()
    End Sub

    Private Sub ListView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.Click
        lblCurrentRecord.Text = "Selected record: " + CStr(CInt(RightSplitUF(ListView1.SelectedItems.Item(0).Tag) + 1))
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

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListView1Sorter = New lvColumnSorter()
        ListView1.ListViewItemSorter = ListView1Sorter
    End Sub

    Private Sub cmbStatus_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnPeriodSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodSetup.Click
        frmSYSPeriodYearly.ShowDialog()
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Period Name", 220)
            .Columns.Add("Start Date", 90)
            .Columns.Add("End Date", 90)
            .Columns.Add("sub_period_id", 0)
            .Columns.Add("Sub Period of", 150)
            .Columns.Add("period_type", 0)
            .Columns.Add("Closed Status", 90)
        End With

        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
        prm1.Value = 0
        Dim prm2 As SqlParameter = cmd.Parameters.Add("is_closed", SqlDbType.Bit)
        prm2.Value = DBNull.Value

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        'Call FillList(myReader, Me.ListView1, 7, 1)
        Dim lvItem As ListViewItem
        Dim intCurrRow As Integer

        While myReader.Read
            lvItem = New ListViewItem(CStr(myReader.Item(1)))
            lvItem.Tag = CStr(myReader.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            For i = 2 To 6
                lvItem.SubItems.Add(IIf(myReader.Item(i) Is DBNull.Value, "", myReader.Item(i)))
            Next
            lvItem.SubItems.Add(IIf(myReader.GetString(6) = "month_period", IIf(myReader.GetBoolean(7) = m_ClosedStatusArr(0, 0), m_ClosedStatusArr(0, 1), m_ClosedStatusArr(1, 1)), "")) 'is_closed
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
        If Not isDeletedRecord("usp_sys_period_SEL", "period_id", LeftSplitUF(ListView1.SelectedItems.Item(0).Tag), Me.Text) = False Then
            clear_lvw()
        ElseIf Not Application.OpenForms().OfType(Of frmSYSPeriod).Any Then
            With frmSYSPeriod
                .PeriodId = LeftSplitUF(ListView1.SelectedItems.Item(0).Tag)
                .SubPeriodId = ListView1.SelectedItems.Item(0).SubItems(3).Text
                .PeriodType = ListView1.SelectedItems.Item(0).SubItems(5).Text
                .MdiParent = frmMAIN
                .Show()
            End With
        Else
            frmSYSPeriod.BringToFront()
        End If
    End Sub

    'Autorefresh---Hendra
    Public Sub frmSYSPeriodListShow(ByVal sender As System.Object, ByVal e As System.EventArgs)
        clear_lvw()
    End Sub


End Class
