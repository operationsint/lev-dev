Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptSlsCOGS
    Private Sub rptSlsCOGS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
        GroupBox1.Enabled = False

        cbStatus.Items.Insert(0, "All")
        cbStatus.Items.Insert(1, "Unpaid")
        cbStatus.Items.Insert(2, "Fully Paid")
        cbStatus.SelectedIndex = 0
    End Sub
    Public Property SNoFrom() As String
        Get
            Return txtSNoFrom.Text
        End Get
        Set(ByVal Value As String)
            txtSNoFrom.Text = Value
        End Set
    End Property
    Public Property SNoTo() As String
        Get
            Return txtSNoTo.Text
        End Get
        Set(ByVal Value As String)
            txtSNoTo.Text = Value
        End Set
    End Property
    Public Property CCodeFrom() As String
        Get
            Return txtCCodeFrom.Text
        End Get
        Set(ByVal Value As String)
            txtCCodeFrom.Text = Value
        End Set
    End Property
    Public Property CCodeTo() As String
        Get
            Return txtCCodeTo.Text
        End Get
        Set(ByVal Value As String)
            txtCCodeTo.Text = Value
        End Set
    End Property
    Public Property SlsCode() As String
        Get
            Return txtSlsCode.Text
        End Get
        Set(ByVal Value As String)
            txtSlsCode.Text = Value
        End Set
    End Property

    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom1 As String
        Dim dateTo1 As String
        Dim SNoFrom1 As String
        Dim SNoTo1 As String
        Dim CCodeFrom1 As String
        Dim CCodeTo1 As String
        Dim slsCode1 As String
        Dim Status As String

        If rbAll.Checked = True Then
            dateFrom1 = ""
            dateTo1 = ""
            SNoFrom1 = ""
            SNoTo1 = ""
            CCodeFrom1 = ""
            CCodeTo1 = ""
            slsCode1 = ""
            Status = ""
        Else
            dtpFrom.Format = DateTimePickerFormat.Custom
            dtpFrom.CustomFormat = "yyyy/MM/dd"
            dtpTo.Format = DateTimePickerFormat.Custom
            dtpTo.CustomFormat = "yyyy/MM/dd"
            dateFrom1 = dtpFrom.Text
            dateTo1 = dtpTo.Text
            If cbStatus.SelectedIndex = 0 Then
                Status = ""
            ElseIf cbStatus.SelectedIndex = 1 Then
                Status = "UP"
            Else
                Status = "FP"
            End If
            If txtSNoFrom.Text <> "" And txtSNoTo.Text <> "" Then
                SNoFrom1 = txtCCodeFrom.Text
                SNoTo1 = txtCCodeTo.Text
                If txtSNoFrom.Text = "" And txtSNoTo.Text <> "" Then
                    SNoFrom1 = txtSNoTo.Text
                    SNoTo1 = txtSNoTo.Text
                ElseIf txtSNoFrom.Text <> "" And txtSNoTo.Text = "" Then
                    SNoFrom1 = txtSNoFrom.Text
                    SNoTo1 = txtSNoFrom.Text
                End If
            Else
                SNoFrom1 = ""
                SNoTo1 = ""
            End If
            If txtCCodeFrom.Text <> "" And txtCCodeTo.Text <> "" Then
                CCodeFrom1 = txtCCodeFrom.Text
                CCodeTo1 = txtCCodeTo.Text
                If txtCCodeFrom.Text = "" And txtCCodeTo.Text <> "" Then
                    CCodeFrom1 = txtCCodeTo.Text
                    CCodeTo1 = txtCCodeTo.Text
                ElseIf txtCCodeFrom.Text <> "" And txtCCodeTo.Text = "" Then
                    CCodeFrom1 = txtCCodeFrom.Text
                    CCodeTo1 = txtCCodeFrom.Text
                End If
            Else
                CCodeFrom1 = ""
                CCodeTo1 = ""
            End If
            If txtSlsCode.Text <> "" Then
                slsCode1 = txtSlsCode.Text
            Else
                slsCode1 = ""
            End If
        End If

        strSQL = "exec RPT_Sls_COGS_Report '" & dateFrom1 & "' , '" & dateTo1 & "', '" & SNoFrom1 & "', '" & SNoTo1 & "', '" & CCodeFrom1 & "', '" & CCodeTo1 & "', '" & slsCode1 & "', '" & Status & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SlsCOGSRpt_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_COGS_Report.rpt"

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
        NewMDIChild.Text = "COGS Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("SlsCOGSRpt_"))
        
        '-----------------MENAMBAH PARAMETER FILTER KE CR--------------------------
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterdate As String
        Dim filtersno As String
        Dim filterccode As String
        Dim filtersls As String
        Dim filterstatus As String

        If rbAll.Checked = True Then
            filterdate = "Transaction Date : All"
            filtersno = "Sales Delivery No. : All"
            filterccode = "Customer Code : All"
            filtersls = "Sales Code : All"
            filterstatus = "Status : All"
        Else
            filterdate = "Transaction Date : " & dtpFrom.Text & " - " & dtpTo.Text
            If txtSNoFrom.Text = "" And txtSNoTo.Text = "" Then
                filtersno = "Sales Invoice No. : All"
            Else
                filtersno = "Sales Invoice No. : " & txtSNoFrom.Text & " - " & txtSNoTo.Text
            End If
            If txtCCodeFrom.Text = "" And txtCCodeTo.Text = "" Then
                filterccode = "Customer Code : All"
            Else
                filterccode = "Customer Code : " & txtCCodeFrom.Text & " - " & txtCCodeTo.Text
            End If
            If txtSlsCode.Text = "" Then
                filtersls = "Sales Code : All"
            Else
                filtersls = "Sales Code : " & txtSlsCode.Text
            End If
            If cbStatus.SelectedIndex = 0 Then
                filterstatus = "Status : All"
            Else
                filterstatus = "Status : " & cbStatus.SelectedItem
            End If
        End If
        Dim filter As String = filterdate + vbCrLf + filtersno + vbCrLf + filterccode + vbCrLf + filtersls + vbCrLf + filterstatus

        crParameterDiscreteValue.Value = filter
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("filter")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub rbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAll.CheckedChanged
        GroupBox1.Enabled = False
    End Sub

    Private Sub rbPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPeriod.CheckedChanged
        GroupBox1.Enabled = True
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtCCodeFrom.Text = ""
        txtCCodeTo.Text = ""
        txtSlsCode.Text = ""
        txtSNoFrom.Text = ""
        txtSNoTo.Text = ""
        cbStatus.SelectedIndex = 0
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnCustCodeFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustCodeFrom.Click
        Dim NewFormDialog As New fdlCustomerFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnCustCodeTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustCodeTo.Click
        Dim NewFormDialog As New fdlCustomerTo
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSlsCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSlsCode.Click
        Dim NewFormDialog As New fdlSlsCodeFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSNoFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSNoFrom.Click
        Dim NewFormDialog As New fdlSInvoiceFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSNoTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSNoTo.Click
        Dim NewFormDialog As New fdlSInvoiceTo
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub
End Class