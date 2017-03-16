Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net.NetworkInformation
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Module modFunction
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    'Function used to left split user fields
    Public Function LeftSplitUF(ByVal srcUF As String) As String
        If srcUF = "*~~~~~*" Then LeftSplitUF = "" : Exit Function
        Dim i As Integer
        Dim t As String = ""
        For i = 1 To Len(srcUF)
            If Mid$(srcUF, i, 7) = "*~~~~~*" Then
                Exit For
            Else
                t &= Mid$(srcUF, i, 1)
            End If
        Next i
        LeftSplitUF = t
        i = 0
        t = ""
    End Function
    'Function used to right split user fields
    Public Function RightSplitUF(ByVal srcUF As String) As String
        If srcUF = "*~~~~~*" Then RightSplitUF = "" : Exit Function
        Dim i As Integer
        Dim t As String = ""
        For i = (InStr(1, srcUF, "*~~~~~*", vbTextCompare) + 7) To Len(srcUF)
            t &= Mid$(srcUF, i, 1)
        Next i
        RightSplitUF = t
        i = 0
        t = ""
    End Function

    Function GetSysNumber(ByVal TrxType As String, ByVal m_Date As Date) As String
        GetSysNumber = ""
        cmd = New SqlCommand("sp_sys_no_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@trxtype", SqlDbType.NVarChar, 50)
        prm1.Value = TrxType

        cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        While myReader.Read()
            GetSysNumber = CStr(myReader.GetInt32(2))
            For i = 1 To myReader.GetInt32(4)
                If Len(GetSysNumber) < myReader.GetInt32(4) Then
                    GetSysNumber = "0" + GetSysNumber
                End If
            Next i
            If myReader.GetBoolean(5) = True Then
                GetSysNumber = m_Date.ToString("yy") + m_Date.ToString("MM") + GetSysNumber
            Else
                GetSysNumber = m_Date.ToString("yy") + GetSysNumber
            End If

            If Not myReader.IsDBNull(myReader.GetOrdinal("TrxPrefix")) Then
                GetSysNumber = myReader.GetString(myReader.GetOrdinal("TrxPrefix")) + GetSysNumber
            End If
        End While
        myReader.Close()
        cn.Close()
    End Function

    Function GetSysInit(ByVal sysInitId As String) As String
        GetSysInit = ""
        cmd = New SqlCommand("usp_sys_init_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sys_init_id", SqlDbType.NVarChar, 50)
        prm1.Value = sysInitId

        cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        While myReader.Read()
            GetSysInit = myReader.GetString(2)
        End While
        myReader.Close()
        cn.Close()
    End Function

    Function GetPermission(ByVal FormName As String) As Boolean
        Dim sMessage As String = ""

        GetPermission = False
        '-- From License
        GetPermission = fGetPermissionModuleRights(FormName, sMessage)

        If GetPermission = False Then
            MsgBox(sMessage, vbInformation)
            Exit Function
        End If

        '-- From User Access Level
        cmd = New SqlCommand("usp_mt_user_access_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_level_id", SqlDbType.Int, 50)
        prm1.Value = p_UserLevel
        Dim prm2 As SqlParameter = cmd.Parameters.Add("@form_name", SqlDbType.NVarChar, 50)
        prm2.Value = FormName

        cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        While myReader.Read()
            GetPermission = myReader.GetBoolean(3)
            If GetPermission = False Then
                MsgBox("You don't have authority to open the form. Please contact your administrator.", vbCritical + vbOKOnly, myReader.GetString(2))
            End If
        End While
        myReader.Close()
        cn.Close()
    End Function

    Function GetSysAccount(ByVal sysAccountType As String) As Integer
        GetSysAccount = 0
        cmd = New SqlCommand("usp_sys_account_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@sys_account_type", SqlDbType.NVarChar, 50)
        prm1.Value = sysAccountType

        cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        While myReader.Read()
            If myReader.Item(2) Is System.DBNull.Value Then
                GetSysAccount = 0
            Else
                GetSysAccount = myReader.Item(2)
            End If
        End While
        myReader.Close()
        cn.Close()
    End Function

    Function canDelete(ByVal form_name As String) As Boolean
        Dim formDelete As Boolean
        Try
            cmd = New SqlCommand("usp_mt_user_access_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@user_level_id", SqlDbType.Int, 50)
            prm1.Value = p_UserLevel
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@form_name", SqlDbType.NVarChar, 50)
            prm2.Value = form_name

            cn.Open()
            Dim myReader As SqlDataReader = cmd.ExecuteReader()
            While myReader.Read
                formDelete = myReader.GetBoolean(4)
            End While
            myReader.Close()
            cn.Close()
            If formDelete = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
            Return False
        End Try
    End Function

    Function isDeletedRecord(ByVal spName As String, ByVal fieldName As String, ByVal fieldId As Integer, ByVal formText As String) As Boolean
        isDeletedRecord = False
        cmd = New SqlCommand(spName, cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@" & fieldName, SqlDbType.Int)
        prm1.Value = fieldId

        cn.Open()

        Dim myReader As SqlDataReader = cmd.ExecuteReader()

        If myReader.HasRows = False Then
            MsgBox("This record has been deleted before.", vbCritical + vbOKOnly, formText)
            isDeletedRecord = True
        End If
        myReader.Close()
        cn.Close()
    End Function

    Function existingDocumentNo(ByVal tableName As String, ByVal fieldName As String, ByVal fieldValue As String) As Boolean
        Dim myReader As SqlDataReader

        cmd = New SqlCommand("select * from " + tableName + " where " + fieldName + "='" + fieldValue + "' ", cn)

        cn.Open()
        myReader = cmd.ExecuteReader

        If myReader.HasRows Then
            existingDocumentNo = True
        Else
            existingDocumentNo = False
        End If

        myReader.Close()
        cn.Close()
    End Function

    Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

        ' Convert the input string to a byte array and compute the hash. 
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes 
        ' and create a string. 
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data  
        ' and format each one as a hexadecimal string. 
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string. 
        Return sBuilder.ToString()

    End Function 'GetMd5Hash

    ' Verify a hash against a string. 
    Function VerifyMd5Hash(ByVal md5Hash As MD5, ByVal input As String, ByVal hash As String) As Boolean
        ' Hash the input. 
        Dim hashOfInput As String = GetMd5Hash(md5Hash, input)

        ' Create a StringComparer an compare the hashes. 
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If

    End Function 'VerifyMd5Hash
    'Program 
    ' This code example produces the following output: 
    ' 
    ' The MD5 hash of Hello World! is: ed076287532e86365e841e92bfc50d8c. 
    ' Verifying the hash... 
    ' The hashes are the same.

    Function getMacAddress()
        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
        Return nics(0).GetPhysicalAddress.ToString
    End Function

    'Check user log
    Function checkUserLog(ByVal userName As String, ByVal workStation As String) As Boolean
        Dim isLogged As Boolean
        Try
            cmd = New SqlCommand("usp_sys_SEL", cn)
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
            Dim myReader As SqlDataReader = cmd.ExecuteReader()
            If myReader.HasRows Then
                isLogged = True
            Else
                isLogged = False
            End If
            myReader.Close()
            cn.Close()
        Catch ex As Exception
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
        If isLogged = True Then
            Return True
        Else
            Return False
        End If
    End Function

    'return line frmMAIN license file
    Public Function ReadLine(ByVal lineNumber As Integer, ByVal lines As List(Of String)) As String
        Return lines(lineNumber)
    End Function

    Function GetPeriodName(ByVal PeriodId As Integer) As String
        GetPeriodName = ""
        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        Dim prm1 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
        prm1.Value = PeriodId

        cn.Open()
        Dim myReader As SqlDataReader = cmd.ExecuteReader()
        While myReader.Read()
            GetPeriodName = myReader.GetString(1)
        End While
        myReader.Close()
        cn.Close()
    End Function

    'Untuk image resize pada stock card -Hendra
    Public Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth,
        percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If
        Dim newImage As Image = New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function

    Public Function GetListDateFilterDays() As Integer
        Dim str As String = GetSysInit("list_date_filter_days")
        If str.Length = 0 Then
            str = "60"
        End If
        Return Convert.ToInt32(str)
    End Function

    Function fGetPermissionModuleRights(ByVal FormName As String, ByRef sMessage As String) As Boolean
        fGetPermissionModuleRights = False

        Dim sModuleName As String
        Dim sModuleRights As String
        sModuleName = ""

        'Get Module Name
        Try
            cmd = New SqlCommand("usp_sys_form_module_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sFormName", SqlDbType.NVarChar, 100)
            prm1.Value = FormName

            cn.Open()
            Dim myReader As SqlDataReader = cmd.ExecuteReader()
            While myReader.Read
                sModuleName = myReader.GetString(0)
            End While
            myReader.Close()
            cn.Close()

        Catch ex As Exception
            sMessage = ex.Message
            'MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
            Return False
            Exit Function
        End Try

        'Cek License Rights Module
        sModuleRights = "1"
        If Len(Trim(p_ModuleRights)) = 6 Then
            Select Case Trim(sModuleName)
                Case "Purchase"
                    sModuleRights = Mid(p_ModuleRights, 1, 1)
                Case "Stock"
                    sModuleRights = Mid(p_ModuleRights, 2, 1)
                Case "Sales"
                    sModuleRights = Mid(p_ModuleRights, 3, 1)
                Case "Bank"
                    sModuleRights = Mid(p_ModuleRights, 4, 1)
                Case "Fixed Asset"
                    sModuleRights = Mid(p_ModuleRights, 5, 1)
                Case "Ledger"
                    sModuleRights = Mid(p_ModuleRights, 6, 1)
                Case Else
                    sModuleRights = "1"
            End Select
        End If

        If sModuleRights = "0" Then
            fGetPermissionModuleRights = False
            sMessage = "Your license not include module " & sModuleName & "."
        Else
            fGetPermissionModuleRights = True
        End If

        Return fGetPermissionModuleRights
    End Function

End Module

