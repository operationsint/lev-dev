Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmSupplierR

    Private Sub BtnFilterFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFilterFrom.Click
        FormDialogText(Me.Name, txtCodeFrom.Name)
    End Sub

    Private Sub BtnFilterTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFilterTo.Click
        FormDialogText(Me.Name, txtCodeTo.Name)
    End Sub

    Private Sub ShowReport()
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String

        strSQL = " exec sp_supplier_select '" & txtCodeFrom.Text & "','" & txtCodeTo.Text & "';"

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "Supplier")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Pch_Supplier_List.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("Supplier"))
        CrystalReportViewer1.ShowRefreshButton = False
        CrystalReportViewer1.ShowCloseButton = False
        CrystalReportViewer1.ShowGroupTreeButton = False
        CrystalReportViewer1.ReportSource = cr
    End Sub


    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        'If txtCodeFrom.Text = "" Then
        'MsgBox("Kode tidak boleh kosong !")
        'Call BtnFilterFrom_Click(sender, e)
        'ElseIf txtCodeFrom.Text = "" Then
        'MsgBox("Kode tidak boleh kosong !")
        'Call BtnFilterTo_Click(sender, e)
        'Else
        Call ShowReport()
        'End If
    End Sub
End Class