Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptFixedAssetGenJournal
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand

    Private Sub rptFixedAssetGenJournal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim FACatFrom1 As String
        Dim FACatTo1 As String
        Dim FAMonth, FAYear As String
        Dim m_date As Date = dtpFrom.Value

        FAMonth = CStr(m_date.Month)
        FAYear = CStr(m_date.Year)

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

        strSQL = "exec RPT_Fixed_Asset_Generate_Journal_Report '" & FACatFrom1 & "', '" & FACatTo1 & "', '" & FAMonth & "', '" & FAYear & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "FAGenJour_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Fixed_Asset_Generate_Journal_Report.rpt"

        '20160627 load custom rpt if available
        Dim strReportPathCustom As String = strReportPath.Substring(0, strReportPath.Length - 4) & "_Custom.rpt"
        If IO.File.Exists(strReportPathCustom) Then
            strReportPath = strReportPathCustom
        End If

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If
        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Fixed Asset Generate Journal"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("FAGenJour_"))

        '-----------------MENAMBAH PARAMETER PCH--------------------------
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterscode As String
        Dim filterscat As String
        Dim filtersperiod As String

        If txtFixedAssetCatCodeFrom.Text = "" And txtFixedAssetCatCodeTo.Text = "" Then
            filterscat = "Fixed Asset Cat. Code : All"
        Else
            filterscat = "Fixed Asset Cat. Code :" + txtFixedAssetCatCodeFrom.Text + " - " + txtFixedAssetCatCodeTo.Text
        End If

        filtersperiod = "Period :" + CStr(m_date.Month) + " - " + CStr(m_date.Year)

        filterscode = filtersperiod + vbCrLf + filterscat

        crParameterDiscreteValue.Value = filterscode
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filter")
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