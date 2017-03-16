Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmFixedAssetGenJournal
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Private Sub frmFixedAssetGenJournal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "MM/yyyy"
    End Sub

    Public Property FixedAssetCodeFrom() As String
        Get
            Return txtFixedAssetCatCodeFrom.Text
        End Get
        Set(ByVal Value As String)
            txtFixedAssetCatCodeFrom.Text = Value
        End Set
    End Property
    Public Property FixedAssetCodeTo() As String
        Get
            Return txtFixedAssetCatCodeTo.Text()
        End Get
        Set(ByVal Value As String)
            txtFixedAssetCatCodeTo.Text() = Value
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        dtpFrom.Value = System.DateTime.Now
        txtFixedAssetCatCodeFrom.Text = ""
        txtFixedAssetCatCodeTo.Text = ""
    End Sub

    Private Sub btnFixedAssetCatCodeFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFixedAssetCatCodeFrom.Click
        Dim NewFormDialog As New fdlFixedAssetCat
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnFixedAssetCatCodeTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFixedAssetCatCodeTo.Click
        Dim NewFormDialog As New fdlFixedAssetCat
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Dim m_date As Date = dtpFrom.Value
        With fdlFixedAssetGenJournal
            If txtFixedAssetCatCodeFrom.Text = "" And txtFixedAssetCatCodeTo.Text <> "" Then
                .FixedAssetCodeFrom = txtFixedAssetCatCodeTo.Text
                .FixedAssetCodeTo = txtFixedAssetCatCodeTo.Text
            ElseIf txtFixedAssetCatCodeFrom.Text <> "" And txtFixedAssetCatCodeTo.Text = "" Then
                .FixedAssetCodeFrom = txtFixedAssetCatCodeFrom.Text
                .FixedAssetCodeTo = txtFixedAssetCatCodeFrom.Text
            Else
                .FixedAssetCodeFrom = txtFixedAssetCatCodeFrom.Text
                .FixedAssetCodeTo = txtFixedAssetCatCodeTo.Text
            End If

            .Day = CStr(DateTime.DaysInMonth(m_date.Year, m_date.Month))
            .Month = m_date.Month
            .year = m_date.Year
            .MdiParent = frmMAIN
            .Show()
        End With
    End Sub

End Class