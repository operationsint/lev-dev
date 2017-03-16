Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptFixedAssetDepreciation
    Private Sub rptFixedAssetDepreciation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "MM/yyyy"
        cmbStatus.Items.Add("All")
        cmbStatus.Items.Add("Depreciated")
        cmbStatus.Items.Add("Not Depreciated")
    End Sub
    Public Property FixedAssetCodeFrom() As String
        Get
            Return txtFixedAssetCodeFrom.Text
        End Get
        Set(ByVal Value As String)
            txtFixedAssetCodeFrom.Text = Value
        End Set
    End Property
    Public Property FixedAssetCodeTo() As String
        Get
            Return txtFixedAssetCodeTo.Text()
        End Get
        Set(ByVal Value As String)
            txtFixedAssetCodeTo.Text() = Value
        End Set
    End Property

    Public Property FixedAssetCatFrom() As String
        Get
            Return txtFixedAssetCatCodeFrom.Text
        End Get
        Set(ByVal Value As String)
            txtFixedAssetCatCodeFrom.Text = Value
        End Set
    End Property
    Public Property FixedAssetCatTo() As String
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
        txtFixedAssetCodeFrom.Text = ""
        txtFixedAssetCodeTo.Text = ""
        txtFixedAssetCatCodeFrom.Text = ""
        txtFixedAssetCatCodeTo.Text = ""
        cmbStatus.SelectedIndex = 0
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

    Private Sub btnFixedAssetCodeFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFixedAssetCodeFrom.Click
        Dim NewFormDialog As New fdlFixedAsset
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnFixedAssetCodeTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFixedAssetCodeTo.Click
        Dim NewFormDialog As New fdlFixedAsset
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim FACodeFrom1 As String
        Dim FACodeTo1 As String
        Dim FACatFrom1 As String
        Dim FACatTo1 As String
        Dim FAMonth, FAYear, FlagJurnal As String
        Dim m_date As Date = dtpFrom.Value

        FAMonth = m_date.Month
        FAYear = m_date.Year

        If txtFixedAssetCodeFrom.Text = "" And txtFixedAssetCodeTo.Text = "" Then
            FACodeFrom1 = ""
            FACodeTo1 = ""
            If txtFixedAssetCodeFrom.Text = "" And txtFixedAssetCodeTo.Text <> "" Then
                FACodeFrom1 = txtFixedAssetCodeTo.Text
                FACodeTo1 = txtFixedAssetCodeTo.Text
            ElseIf txtFixedAssetCodeTo.Text = "" And txtFixedAssetCodeFrom.Text <> "" Then
                FACodeFrom1 = txtFixedAssetCodeFrom.Text
                FACodeTo1 = txtFixedAssetCodeFrom.Text
            End If
        Else
            FACodeFrom1 = txtFixedAssetCodeFrom.Text
            FACodeTo1 = txtFixedAssetCodeTo.Text
        End If

        If txtFixedAssetCatCodeFrom.Text = "" And txtFixedAssetCatCodeTo.Text = "" Then
            FACatFrom1 = ""
            FACatTo1 = ""
            If txtFixedAssetCatCodeFrom.Text = "" And txtFixedAssetCatCodeTo.Text <> "" Then
                FACatFrom1 = txtFixedAssetCatCodeTo.Text
                FACatTo1 = txtFixedAssetCatCodeTo.Text
            ElseIf txtFixedAssetCatCodeTo.Text = "" And txtFixedAssetCatCodeFrom.Text <> "" Then
                FACatFrom1 = txtFixedAssetCatCodeFrom.Text
                FACatTo1 = txtFixedAssetCatCodeFrom.Text
            End If
        Else
            FACatFrom1 = txtFixedAssetCatCodeFrom.Text
            FACatTo1 = txtFixedAssetCatCodeTo.Text
        End If

        strSQL = "exec RPT_Fixed_Asset_Depreciation_Report '" & FACodeFrom1 & "' , '" & FACodeTo1 & "', '" & FACatFrom1 & "', '" & FACatTo1 & "', '" & FAMonth & "', '" & FAYear & "', '" & FlagJurnal & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "FADepreciation_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Fixed_Asset_Depreciation_Report.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If
        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Fixed Asset Depreciation"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("FADepreciation_"))

        '-----------------MENAMBAH PARAMETER PCH--------------------------
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterscode As String
        Dim filtersfa As String
        Dim filterscat As String
        Dim filtersperiod, filtersflagjurnal As String

        If txtFixedAssetCodeFrom.Text = "" And txtFixedAssetCodeTo.Text = "" Then
            filtersfa = "Fixed Asset Code : All"
        Else
            filtersfa = "Fixed Asset Code : " + txtFixedAssetCodeFrom.Text + " - " + txtFixedAssetCodeTo.Text
        End If

        If txtFixedAssetCatCodeFrom.Text = "" And txtFixedAssetCatCodeTo.Text = "" Then
            filterscat = "Fixed Asset Cat. Code : All"
        Else
            filterscat = "Fixed Asset Cat. Code :" + txtFixedAssetCatCodeFrom.Text + " - " + txtFixedAssetCatCodeTo.Text
        End If

        filtersperiod = "Period :" + m_date.Month + " - " + m_date.Year

        If cmbStatus.SelectedIndex = 1 Then
            filtersflagjurnal = "Status : Depreciated"
        ElseIf cmbStatus.SelectedIndex = 2 Then
            filtersflagjurnal = "Status : Not Depreciated"
        Else
            filtersflagjurnal = "Status : All"
        End If
        filterscode = filtersperiod + vbCrLf + filtersfa + vbCrLf + filterscat + vbCrLf + filtersflagjurnal

        crParameterDiscreteValue.Value = filterscode
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filterscode")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
        '----------------------------------------------------------------------------------------

        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    
End Class