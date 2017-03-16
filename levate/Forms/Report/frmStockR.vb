﻿Imports System.Windows.Forms
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmStockR

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

        strSQL = " exec sp_sku_select '" & txtCodeFrom.Text & "','" & txtCodeTo.Text & "'; "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "Stock")

        Dim strReportPath As String = Application.StartupPath & "\Reports\rpt_stk_stock_list.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("Stock"))
        CrystalReportViewer1.ShowRefreshButton = False
        CrystalReportViewer1.ShowCloseButton = False
        CrystalReportViewer1.ShowGroupTreeButton = False
        CrystalReportViewer1.ReportSource = cr
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Call ShowReport()
    End Sub
End Class