Imports System.Data.OleDb
Imports System.Data.SqlClient

Module Parameter
    Public Rpt_SqlStr As String
    Public mReport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Public sqlDT As New DataTable
    Public CnString = My.Settings.ConnStr
    Public DialogText As String
    Public DialogForm As String


    Public Function DataSourceConnection_Report()
        mReport.DataSourceConnections(0).SetConnection(My.Settings.SvrName, My.Settings.DBName, True)
        Return 0
    End Function

    Public Function ExecuteSQLQuery(ByVal SQLQuery As String) As DataTable
        Try
            Dim sqlCon As New SqlConnection(CnString)
            Dim sqlDA As New SqlDataAdapter(SQLQuery, sqlCon)
            Dim sqlCB As New SqlCommandBuilder(sqlDA)
            sqlDT.Reset() ' refresh 
            sqlDA.Fill(sqlDT)
        Catch ex As Exception
            If Err.Number = 5 Then
                MsgBox("Database Setting is not Valid Check Admin !!", MsgBoxStyle.Information, "Report")
            End If
        End Try
        Return sqlDT
    End Function

    Public Sub FormDialogText(ByVal frmStr As String, ByVal txtStr As String)
        Select Case UCase(frmStr)
            Case UCase("frmCustomerR")
                DialogForm = frmStr
                DialogText = txtStr
                With frmCustomerD
                    .ShowDialog()
                End With
            Case UCase("frmStockR")
                DialogForm = frmStr
                DialogText = txtStr
                With frmSKUD
                    .ShowDialog()
                End With
            Case UCase("frmSupplierR")
                DialogForm = frmStr
                DialogText = txtStr
                With frmSupplierD
                    .ShowDialog()
                End With
            Case UCase("frmCurrencyR")
                DialogForm = frmStr
                DialogText = txtStr
                With frmCurrencyD
                    .ShowDialog()
                End With
            Case UCase("frmExpenseR")
                DialogForm = frmStr
                DialogText = txtStr
                With frmExpenseD
                    .ShowDialog()
                End With
            Case UCase("frmStockLocationR")
                DialogForm = frmStr
                DialogText = txtStr
                With frmSKUD
                    .ShowDialog()
                End With
            Case UCase("frmStockLocationRL")
                DialogForm = frmStr
                DialogText = txtStr
                With frmLocationD
                    .ShowDialog()
                End With
        End Select
    End Sub

End Module


