Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class fdlFixedAssetDispose
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Private Sub fdlFixedAssetDispose_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Property FixedAssetCode() As String
        Get
            Return txtFixedAssetCode.Text
        End Get
        Set(ByVal Value As String)
            txtFixedAssetCode.Text = Value
        End Set
    End Property
    Public Property FixedAssetName() As String
        Get
            Return txtFixedAssetName.Text
        End Get
        Set(ByVal Value As String)
            txtFixedAssetName.Text = Value
        End Set
    End Property

    Public Property BookValue() As Decimal
        Get
            Return ntbBookValue.Text
        End Get
        Set(ByVal Value As Decimal)
            ntbBookValue.Text = FormatNumber(Value, 2)
        End Set
    End Property

    Public Property DisposeValue() As Decimal
        Get
            Return ntbDisposeValue.Text
        End Get
        Set(ByVal Value As Decimal)
            ntbDisposeValue.Text = FormatNumber(Value, 2)
        End Set
    End Property
    Private Sub btnDispose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDispose.Click
        If CInt(ntbDisposeValue.Text) = 0 Then
            If MsgBox("Are you sure you want to dispose this asset with 0 value?", vbYesNo + vbCritical, Me.Text) = vbNo Then
                ntbDisposeValue.Focus()
                Exit Sub
            End If
        End If

        If MsgBox("Are you sure you want to dispose this asset with dispose value " + ntbDisposeValue.Text + "?", vbYesNo + vbCritical, Me.Text) = vbYes Then
            cmd = New SqlCommand("sp_mt_fixed_asset_DISPOSE", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@fixed_asset_code", SqlDbType.NVarChar, 50)
            prm1.Value = txtFixedAssetCode.Text
            Dim prm2 As SqlParameter = cmd.Parameters.Add("@user_name", SqlDbType.NVarChar, 50)
            prm2.Value = My.Settings.UserName
            Dim prm3 As SqlParameter = cmd.Parameters.Add("@dispose_date", SqlDbType.SmallDateTime)
            prm3.Value = dtpDisposeDate.Value.Date
            Dim prm4 As SqlParameter = cmd.Parameters.Add("@dispose_value", SqlDbType.Decimal)
            prm4.Value = FormatNumber(ntbDisposeValue.Text, 2)
            cn.Open()
            cmd.ExecuteReader()
            cn.Close()

            autoRefresh()
            Me.Close()
        End If
    End Sub

    
    Private Sub ntbDisposeValue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ntbDisposeValue.LostFocus
        If ntbDisposeValue.Text = "" Then
            ntbDisposeValue.Text = 0
        End If

        If ntbDisposeValue.DecimalValue < 0 Then
            ntbDisposeValue.Text = ntbDisposeValue.DecimalValue * -1
        End If

        ntbDisposeValue.Text = FormatNumber(ntbDisposeValue.Text, 2)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    'Set autorefresh list---hendra
    Sub autoRefresh()
        If Application.OpenForms().OfType(Of frmFixedAsset).Any Then
            Call frmFixedAsset.frmFixedAssetShow(Nothing, EventArgs.Empty)
        End If
    End Sub
End Class