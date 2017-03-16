Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptFixedAssetList
    Private Sub rptFixedAssetList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btnFACodeFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFACodeFrom.Click
        Dim NewFormDialog As New fdlFixedAsset
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnFACodeTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFACodeTo.Click
        Dim NewFormDialog As New fdlFixedAsset
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub

    Public Property FixedAssetCodeFrom() As String
        Get
            Return txtFACodeFrom.Text
        End Get
        Set(ByVal Value As String)
            txtFACodeFrom.Text = Value
        End Set
    End Property
    Public Property FixedAssetCodeTo() As String
        Get
            Return txtFACodeTo.Text
        End Get
        Set(ByVal Value As String)
            txtFACodeTo.Text = Value
        End Set
    End Property

    Public Property FixedAssetCatFrom() As String
        Get
            Return txtFACatFrom.Text
        End Get
        Set(ByVal Value As String)
            txtFACatFrom.Text = Value
        End Set
    End Property

    Public Property FixedAssetCatTo() As String
        Get
            Return txtFACatTo.Text
        End Get
        Set(ByVal Value As String)
            txtFACatTo.Text = Value
        End Set
    End Property

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim FACodeFrom1 As String
        Dim FACodeTo1 As String
        Dim FACatFrom1 As String
        Dim FACatTo1 As String

        If txtFACodeFrom.Text = "" And txtFACodeTo.Text = "" Then
            FACodeFrom1 = ""
            FACodeTo1 = ""
            If txtFACodeFrom.Text = "" And txtFACodeTo.Text <> "" Then
                FACodeFrom1 = txtFACodeTo.Text
                FACodeTo1 = txtFACodeTo.Text
            ElseIf txtFACodeTo.Text = "" And txtFACodeFrom.Text <> "" Then
                FACodeFrom1 = txtFACodeFrom.Text
                FACodeTo1 = txtFACodeFrom.Text
            End If
        Else
            FACodeFrom1 = txtFACodeFrom.Text
            FACodeTo1 = txtFACodeTo.Text
        End If

        If txtFACatFrom.Text = "" And txtFACatTo.Text = "" Then
            FACatFrom1 = ""
            FACatTo1 = ""
            If txtFACatFrom.Text = "" And txtFACatTo.Text <> "" Then
                FACatFrom1 = txtFACatTo.Text
                FACatTo1 = txtFACatTo.Text
            ElseIf txtFACatTo.Text = "" And txtFACatFrom.Text <> "" Then
                FACatFrom1 = txtFACatFrom.Text
                FACatTo1 = txtFACatFrom.Text
            End If
        Else
            FACatFrom1 = txtFACatFrom.Text
            FACatTo1 = txtFACatTo.Text
        End If

        strSQL = "exec RPT_Fixed_Asset_List_Report '" & FACodeFrom1 & "' , '" & FACodeTo1 & "', '" & FACatFrom1 & "', '" & FACatTo1 & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "FAList_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Fixed_Asset_List_Report.rpt"

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
        NewMDIChild.Text = "Fixed Asset List"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("FAList_"))

        '-----------------MENAMBAH PARAMETER PCH--------------------------
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterscode As String
        Dim filtersfa As String
        Dim filterscat As String

        If txtFACodeFrom.Text = "" And txtFACodeTo.Text = "" Then
            filtersfa = "Fixed Asset Code : All"
        Else
            filtersfa = "Fixed Asset Code : " + txtFACodeFrom.Text + " - " + txtFACodeTo.Text
        End If

        If txtFACatFrom.Text = "" And txtFACatTo.Text = "" Then
            filterscat = "Fixed Asset Cat. Code : All"
        Else
            filterscat = "Fixed Asset Cat. Code :" + txtFACatFrom.Text + " - " + txtFACatTo.Text
        End If

        filterscode = filtersfa + vbCrLf + filterscat

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtFACodeFrom.Text = ""
        txtFACodeTo.Text = ""
        txtFACatFrom.Text = ""
        txtFACatTo.Text = ""
    End Sub

    Private Sub btnFACatFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFACatFrom.Click
        Dim NewFormDialog As New fdlFixedAssetCat
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnFACatTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFACatTo.Click
        Dim NewFormDialog As New fdlFixedAssetCat
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub

End Class