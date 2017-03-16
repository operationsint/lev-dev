Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Module modProcedure
    Public str_user_name As String
    Public str_user_access As String
    Public p_UserLevel As Integer
    Public p_CompanyName As String
    Public p_ModuleRights As String = "111111"

    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Public Sub FillList(ByVal DR As SqlClient.SqlDataReader, ByVal lvw As ListView, ByVal intColCount As Integer, ByVal intFirstCol As Integer)
        Dim lvItem As ListViewItem
        Dim i As Integer, intCurrRow As Integer

        If intColCount = 0 Then intColCount = DR.FieldCount - 1
        If intColCount > DR.FieldCount Then intColCount = DR.FieldCount

        'To specify listview header column by table columns. No need to specify each column
        'lvw.Clear()
        'lvw.View = View.Details
        'For i = 1 To intColCount
        '    lvw.Columns.Add(DR.GetName(i))
        'Next

        While DR.Read
            If DR.Item(intFirstCol) Is System.DBNull.Value Then
                lvItem = New ListViewItem("")
            Else
                lvItem = New ListViewItem(CStr(DR.Item(intFirstCol)))
            End If

            lvItem.Tag = CStr(DR.Item(0)) & "*~~~~~*" & intCurrRow 'ID
            'lvItem.Tag = "v" & CStr(DR.Item(0))
            For i = 2 To intColCount
                If DR.Item(i) Is System.DBNull.Value Then
                    lvItem.SubItems.Add("")
                Else
                    lvItem.SubItems.Add(DR.Item(i))
                End If
            Next

            If intCurrRow Mod 2 = 0 Then
                lvItem.BackColor = Color.Lavender
            Else
                lvItem.BackColor = Color.White
            End If
            lvItem.UseItemStyleForSubItems = True

            lvw.Items.Add(lvItem)
            intCurrRow += 1
        End While
    End Sub

    Public Sub UpdSysNumber(ByVal TrxType As String)
        cmd = New SqlCommand("sp_sys_no_UPD", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@trxtype", SqlDbType.NVarChar, 50)
        prm1.Value = TrxType

        cn.Open()
        cmd.ExecuteReader()
        cn.Close()
    End Sub

    Public Sub UpdSysInitial(ByVal SysInitId As String, ByVal SysInitValue As String)
        cmd = New SqlCommand("usp_sys_init_UPD", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sys_init_id", SqlDbType.NVarChar, 50)
        prm1.Value = SysInitId
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@sys_init_val", SqlDbType.NVarChar, 50)
        prm2.Value = SysInitValue

        cn.Open()
        cmd.ExecuteReader()
        cn.Close()
    End Sub

    Public Sub SetDBLogonForReport(ByVal myConnectionInfo As ConnectionInfo, ByVal myReportDocument As ReportDocument)
        Dim myTables As Tables = myReportDocument.Database.Tables
        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            myTableLogonInfo.ConnectionInfo = myConnectionInfo
            myTable.ApplyLogOnInfo(myTableLogonInfo)
        Next
    End Sub
    Public Sub OpenExcel(ByVal FileToOpen As String) 'Hendra
        If System.IO.File.Exists(FileToOpen) = True Then
            Process.Start(FileToOpen)
        End If
    End Sub

    Public Sub DeleteExcel(ByVal FileToDelete As String) 'Hendra
        If System.IO.File.Exists(FileToDelete) = True Then
            System.IO.File.Delete(FileToDelete)
        End If
    End Sub
    Public Sub ExportDatasetToExcel(ByVal ds As DataSet, ByVal strExcelFile As String) 'Hendra
        Try
            If System.IO.File.Exists(strExcelFile) = True Then
                System.IO.File.Delete(strExcelFile)
            End If

            fdlExportExcel.Show()

            Dim conn As New OleDbConnection(String.Format("provider=Microsoft.Jet.OLEDB.4.0; Data Source='{0}';" & "Extended Properties='Excel 8.0;HDR=YES;'", strExcelFile))
            conn.Open()
            Dim strTableQ(ds.Tables.Count) As String
            Dim i As Integer = 0
            'making table query
            For i = 0 To ds.Tables.Count - 1
                strTableQ(i) = "CREATE TABLE [" & ds.Tables(i).TableName & "]("
                Dim j As Integer = 0
                For j = 0 To ds.Tables(i).Columns.Count - 1
                    Dim dCol As DataColumn
                    dCol = ds.Tables(i).Columns(j)
                    strTableQ(i) &= " [" & dCol.ColumnName & "] varchar(255) , "
                Next
                strTableQ(i) = strTableQ(i).Substring(0, strTableQ(i).Length - 2)
                strTableQ(i) &= ")"
                Dim cmd As New OleDbCommand(strTableQ(i), conn)
                cmd.ExecuteNonQuery()
            Next
            'making insert query
            Dim strInsertQ(ds.Tables.Count - 1) As String
            For i = 0 To ds.Tables.Count - 1
                strInsertQ(i) = "Insert Into " & ds.Tables(i).TableName & " Values ("
                For k As Integer = 0 To ds.Tables(i).Columns.Count - 1
                    strInsertQ(i) &= "@" & ds.Tables(i).Columns(k).ColumnName & " , "
                Next
                strInsertQ(i) = strInsertQ(i).Substring(0, strInsertQ(i).Length - 2)
                strInsertQ(i) &= ")"
            Next
            'Now inserting data
            For i = 0 To ds.Tables.Count - 1
                For j As Integer = 0 To ds.Tables(i).Rows.Count - 1
                    Dim cmd As New OleDbCommand(strInsertQ(i), conn)
                    For k As Integer = 0 To ds.Tables(i).Columns.Count - 1
                        cmd.Parameters.AddWithValue("@" & ds.Tables(i).Columns(k).ColumnName.ToString(), ds.Tables(i).Rows(j)(k).ToString())
                    Next
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                Next
            Next
            conn.Close()
            If conn.State = ConnectionState.Closed Then
                fdlExportExcel.Close()
                MsgBox("Export Done !, File path = " + strExcelFile)

                If System.IO.File.Exists(strExcelFile) = True Then
                    Process.Start(strExcelFile)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try

    End Sub

    'Log user login
    Public Sub userLogin(ByVal userName As String, ByVal workStation As String)
        Try
            cmd = New SqlCommand("usp_sys_LOGIN", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm1.Value = userName
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@workstation", SqlDbType.NVarChar, 100)
            prm2.Value = workStation

            'Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            ''------------------------ENCRYPTING PASSWORD----------------------------
            'Dim plainText As String = userName
            'Dim password As String = "b119"

            'Dim wrapper As New Dencrypt(password)
            'Dim EncryptPass As String = wrapper.EncryptData(plainText)
            ''------------------------END OF ENCRYPTING PASSWORD----------------------------
            'prm1.Value = EncryptPass

            'Dim prm2 As SqlParameter = cmd.Parameters.Add("@workstation", SqlDbType.NVarChar, 100)
            ''------------------------ENCRYPTING PASSWORD----------------------------
            'Dim plainText2 As String = workStation
            'Dim password2 As String = "b119"

            'Dim wrapper2 As New Dencrypt(password2)
            'Dim EncryptPass2 As String = wrapper2.EncryptData(plainText2)
            ''------------------------END OF ENCRYPTING PASSWORD----------------------------
            'prm2.Value = EncryptPass2

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

        Catch ex As Exception
            MsgBox("Cannot connect to the server,please try again!" + vbCrLf + ex.Message, vbCritical)
            If ConnectionState.Open = 1 Then cn.Close()
            End
        End Try
    End Sub

    'Log user logout/formClosing
    Public Sub userLogout(ByVal userName As String, ByVal workStation As String)
        Try
            cmd = New SqlCommand("usp_sys_LOGOUT", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm1.Value = userName
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@workstation", SqlDbType.NVarChar, 100)
            prm2.Value = workStation

            'Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            ''------------------------ENCRYPTING PASSWORD----------------------------
            'Dim plainText As String = userName
            'Dim password As String = "b119"

            'Dim wrapper As New Dencrypt(password)
            'Dim EncryptPass As String = wrapper.EncryptData(plainText)
            ''------------------------END OF ENCRYPTING PASSWORD----------------------------
            'prm1.Value = EncryptPass

            'Dim prm2 As SqlParameter = cmd.Parameters.Add("@workstation", SqlDbType.NVarChar, 100)
            ''------------------------ENCRYPTING PASSWORD----------------------------
            'Dim plainText2 As String = workStation
            'Dim password2 As String = "b119"

            'Dim wrapper2 As New Dencrypt(password2)
            'Dim EncryptPass2 As String = wrapper2.EncryptData(plainText2)
            ''------------------------END OF ENCRYPTING PASSWORD----------------------------
            'prm2.Value = EncryptPass2

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

        Catch ex As Exception
            MsgBox("Cannot connect to the server,please try again!" + vbCrLf + ex.Message, vbCritical)
            If ConnectionState.Open = 1 Then cn.Close()
            End
        End Try
    End Sub
    Public Sub cekMacAddress()
        'Try
        '    cmd = New SqlCommand("cekMacAddress", cn)
        '    cmd.CommandType = CommandType.StoredProcedure

        '    Dim myReader As SqlDataReader = cmd.ExecuteReader()
        '    While myReader.Read
        '        MsgBox(myReader.GetString(0))
        '    End While
        '    myReader.Close()

        'Catch ex As Exception
        '    MsgBox("Cannot connect to the server,please try again!" + vbCrLf + ex.Message, vbCritical)
        '    If ConnectionState.Open = 1 Then cn.Close()
        '    End
        'End Try
    End Sub



End Module
