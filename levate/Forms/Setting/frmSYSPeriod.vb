Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmSYSPeriod
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_PeriodId As Integer
    Dim m_SubPeriodId As Integer
    Dim m_PeriodType As String
    Dim m_isLockedAP As Boolean
    Dim m_isLockedAR As Boolean
    Dim m_isLockedSKU As Boolean
    Dim m_isLockedBANK As Boolean
    Dim m_isLockedGL As Boolean
    Dim m_isClosed As Boolean
    Dim m_ClosedStatusArr(1, 1) As String

    Private Sub frmSYSPeriod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'lock_obj(True)
        Dim myReader As SqlDataReader
        Dim prm1 As SqlParameter
        Dim i As Integer

        'Add item Sub period of
        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@period_id", SqlDbType.Int)
        prm1.Value = m_SubPeriodId

        cn.Open()
        myReader = cmd.ExecuteReader

        cmbSubPeriodId.Items.Clear()
        While myReader.Read
            cmbSubPeriodId.Items.Add(New clsMyListInt(myReader.GetString(1), myReader.GetInt32(0)))
            i += 1
        End While

        myReader.Close()
        cn.Close()

        'Add item is_posted
        cmd = New SqlCommand("sp_sys_dropdown_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@sys_dropdown_whr", SqlDbType.NVarChar, 50)
        prm1.Value = "is_closed"

        cn.Open()
        myReader = cmd.ExecuteReader

        i = 0
        While myReader.Read
            m_ClosedStatusArr(i, 0) = myReader.GetString(0)
            m_ClosedStatusArr(i, 1) = myReader.GetString(1)
            i += 1
        End While

        myReader.Close()
        cn.Close()

        'Fill up the form
        cmd = New SqlCommand("usp_sys_period_SEL", cn)
        cmd.CommandType = CommandType.StoredProcedure

        prm1 = cmd.Parameters.Add("@period_id", SqlDbType.Int)
        prm1.Value = m_PeriodId

        cn.Open()
        myReader = cmd.ExecuteReader()

        While myReader.Read
            txtPeriodName.Text = myReader.GetString(1)
            dtpPeriodStartDate.Value = myReader.GetDateTime(2)
            dtpPeriodEndDate.Value = myReader.GetDateTime(3)
            m_SubPeriodId = myReader.GetInt32(4)
            m_PeriodType = myReader.GetString(6)
            m_isClosed = myReader.GetBoolean(7)

            If m_PeriodType = "month_period" Then
                m_isLockedAP = myReader.GetBoolean(8)
                m_isLockedAR = myReader.GetBoolean(9)
                m_isLockedSKU = myReader.GetBoolean(10)
                m_isLockedBANK = myReader.GetBoolean(11)
                m_isLockedGL = myReader.GetBoolean(12)
            Else
                m_isLockedAP = 0
                m_isLockedAR = 0
                m_isLockedSKU = 0
                m_isLockedBANK = 0
                m_isLockedGL = 0
            End If

            txtPeriodClose.Text = IIf(myReader.GetString(6) = "month_period", IIf(myReader.GetBoolean(7) = m_ClosedStatusArr(0, 0), m_ClosedStatusArr(0, 1), m_ClosedStatusArr(1, 1)), "")
            txtLockedAP.Text = IIf(myReader.GetString(6) = "month_period", IIf(myReader.GetBoolean(8) = m_ClosedStatusArr(0, 0), m_ClosedStatusArr(0, 1), m_ClosedStatusArr(1, 1)), "")
            txtLockedAR.Text = IIf(myReader.GetString(6) = "month_period", IIf(myReader.GetBoolean(9) = m_ClosedStatusArr(0, 0), m_ClosedStatusArr(0, 1), m_ClosedStatusArr(1, 1)), "")
            txtLockedSKU.Text = IIf(myReader.GetString(6) = "month_period", IIf(myReader.GetBoolean(10) = m_ClosedStatusArr(0, 0), m_ClosedStatusArr(0, 1), m_ClosedStatusArr(1, 1)), "")
            txtLockedBANK.Text = IIf(myReader.GetString(6) = "month_period", IIf(myReader.GetBoolean(11) = m_ClosedStatusArr(0, 0), m_ClosedStatusArr(0, 1), m_ClosedStatusArr(1, 1)), "")
            txtLockedGL.Text = IIf(myReader.GetString(6) = "month_period", IIf(myReader.GetBoolean(12) = m_ClosedStatusArr(0, 0), m_ClosedStatusArr(0, 1), m_ClosedStatusArr(1, 1)), "")
        End While

        myReader.Close()
        cn.Close()

        Dim mList As clsMyListInt
        For i = 1 To cmbSubPeriodId.Items.Count
            mList = cmbSubPeriodId.Items(i - 1)
            If m_SubPeriodId = mList.ItemData Then
                cmbSubPeriodId.SelectedIndex = i - 1
                Exit For
            End If
        Next

        If m_PeriodType = "month_period" And m_isClosed = False Then btnLockPeriod.Enabled = True Else btnLockPeriod.Enabled = False
    End Sub

    Public Property PeriodId() As Integer
        Get
            Return m_PeriodId
        End Get
        Set(ByVal Value As Integer)
            m_PeriodId = Value
        End Set
    End Property

    Public Property SubPeriodId() As Integer
        Get
            Return m_SubPeriodId
        End Get
        Set(ByVal Value As Integer)
            m_SubPeriodId = Value
        End Set
    End Property

    Public Property PeriodType() As String
        Get
            Return m_PeriodType
        End Get
        Set(ByVal Value As String)
            m_PeriodType = Value
        End Set
    End Property

    Public Property isLockedAP() As Boolean
        Get
            Return m_isLockedAP
            'Return txtLockedAP.Text
        End Get
        Set(ByVal Value As Boolean)
            m_isLockedAP = Value
            txtLockedAP.Text = IIf(m_isLockedAP = m_ClosedStatusArr(0, 0), m_ClosedStatusArr(0, 1), m_ClosedStatusArr(1, 1))
        End Set
    End Property

    Public Property isLockedAR() As Boolean
        Get
            Return m_isLockedAR
        End Get
        Set(ByVal Value As Boolean)
            m_isLockedAR = Value
            txtLockedAR.Text = IIf(m_isLockedAR = m_ClosedStatusArr(0, 0), m_ClosedStatusArr(0, 1), m_ClosedStatusArr(1, 1))
        End Set
    End Property

    Public Property isLockedSKU() As Boolean
        Get
            Return m_isLockedSKU
        End Get
        Set(ByVal Value As Boolean)
            m_isLockedSKU = Value
            txtLockedSKU.Text = IIf(m_isLockedSKU = m_ClosedStatusArr(0, 0), m_ClosedStatusArr(0, 1), m_ClosedStatusArr(1, 1))
        End Set
    End Property

    Public Property isLockedBANK() As Boolean 'Hendra
        Get
            Return m_isLockedBANK
        End Get
        Set(ByVal Value As Boolean)
            m_isLockedBANK = Value
            txtLockedBANK.Text = IIf(m_isLockedBANK = m_ClosedStatusArr(0, 0), m_ClosedStatusArr(0, 1), m_ClosedStatusArr(1, 1))
        End Set
    End Property

    Public Property isLockedGL() As Boolean
        Get
            Return m_isLockedGL
        End Get
        Set(ByVal Value As Boolean)
            m_isLockedGL = Value
            txtLockedGL.Text = IIf(m_isLockedGL = m_ClosedStatusArr(0, 0), m_ClosedStatusArr(0, 1), m_ClosedStatusArr(1, 1))
        End Set
    End Property

    Public Property isClosed() As Boolean
        Get
            Return m_isClosed
        End Get
        Set(ByVal Value As Boolean)
            m_isClosed = Value
            txtPeriodClose.Text = IIf(m_isClosed = m_ClosedStatusArr(0, 0), m_ClosedStatusArr(0, 1), m_ClosedStatusArr(1, 1))
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            cmd = New SqlCommand("usp_sys_period_UPD", cn)
            cmd.CommandType = CommandType.StoredProcedure
            Dim prm1 As SqlParameter = cmd.Parameters.Add("@period_name", SqlDbType.NVarChar, 50)
            prm1.Value = txtPeriodName.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@period_start_date", SqlDbType.DateTime)
            prm2.Value = dtpPeriodStartDate.Value
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@period_end_date", SqlDbType.DateTime)
            prm3.Value = dtpPeriodEndDate.Value
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@sub_period_id", SqlDbType.Int)
            prm4.Value = cmbSubPeriodId.Items(cmbSubPeriodId.SelectedIndex).ItemData
            Dim prm11 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm11.Value = My.Settings.UserName
            Dim prm12 As SqlParameter = cmd.Parameters.Add("@period_id", SqlDbType.Int)
            prm12.Value = m_PeriodId

            cn.Open()
            cmd.ExecuteReader()
            cn.Close()
            frmSYSPeriodList.clear_lvw()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        txtPeriodName.ReadOnly = isLock
        btnSave.Enabled = Not isLock
        btnClose.Enabled = Not isLock
    End Sub

    Private Sub txtPeriodName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPeriodName.TextChanged
        btnSave.Enabled = True
    End Sub

    Private Sub btnLockPeriod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLockPeriod.Click
        With frmSYSPeriodLockList
            .PeriodId = m_PeriodId
            .MdiParent = frmMAIN
            .Show()
        End With
    End Sub

    Sub autoRefresh()
        'Set autorefresh form 
        If Application.OpenForms().OfType(Of frmSYSPeriodList).Any Then
            Call frmSYSPeriodList.clear_lvw()
        End If
    End Sub
End Class