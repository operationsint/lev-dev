Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptPOList
    Dim m_PchCodeIdFrom As Integer
    Dim m_PchCodeIdTo As Integer
    Dim m_CurrId As Integer
    Private Sub rptPOList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
        GroupBox1.Enabled = False

        cbStatus.Items.Insert(0, "All")
        cbStatus.Items.Insert(1, "Outstanding")
        cbStatus.Items.Insert(2, "Partially Received")
        cbStatus.Items.Insert(3, "Fully Received")
        cbStatus.Items.Insert(4, "Invoiced")
        cbStatus.Items.Insert(5, "Paid")
        cbStatus.SelectedIndex = 0
    End Sub
    Public Property PchCodeFrom() As String
        Get
            Return txtPchCodeFrom.Text
        End Get
        Set(ByVal Value As String)
            txtPchCodeFrom.Text = Value
        End Set
    End Property
    Public Property PchCodeTo() As String
        Get
            Return txtPchCodeTo.Text()
        End Get
        Set(ByVal Value As String)
            txtPchCodeTo.Text() = Value
        End Set
    End Property
    Public Property CurrCode() As String
        Get
            Return txtCurrCode.Text()
        End Get
        Set(ByVal Value As String)
            txtCurrCode.Text() = Value
        End Set
    End Property
    Public Property PchCodeIdFrom() As Integer
        Get
            Return m_PchCodeIdFrom
        End Get
        Set(ByVal Value As Integer)
            m_PchCodeIdFrom = Value
        End Set
    End Property
    Public Property PchCodeIdTo() As Integer
        Get
            Return m_PchCodeIdTo
        End Get
        Set(ByVal Value As Integer)
            m_PchCodeIdTo = Value
        End Set
    End Property
    Public Property CurrId() As Integer
        Get
            Return m_CurrId
        End Get
        Set(ByVal Value As Integer)
            m_CurrId = Value
        End Set
    End Property
    Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom As String
        Dim dateTo As String
        Dim pchCodeFrom As String
        Dim pchCodeTo As String
        Dim currCode As String
        Dim Status As String

        If rbAll.Checked = True Then
            dateFrom = ""
            dateTo = ""
            Status = ""
        Else
            dtpFrom.Format = DateTimePickerFormat.Custom
            dtpFrom.CustomFormat = "yyyy/MM/dd"
            dtpTo.Format = DateTimePickerFormat.Custom
            dtpTo.CustomFormat = "yyyy/MM/dd"
            dateFrom = dtpFrom.Text
            dateTo = dtpTo.Text
            If cbStatus.SelectedIndex = 0 Then
                Status = ""
            ElseIf cbStatus.SelectedIndex = 1 Then
                Status = "O"
            ElseIf cbStatus.SelectedIndex = 2 Then
                Status = "PR"
            ElseIf cbStatus.SelectedIndex = 3 Then
                Status = "FR"
            ElseIf cbStatus.SelectedIndex = 4 Then
                Status = "I"
            Else
                Status = "P"
            End If
        End If
        If txtPchCodeFrom.Text <> "" And txtPchCodeTo.Text <> "" Then
            pchCodeFrom = txtPchCodeFrom.Text
            pchCodeTo = txtPchCodeTo.Text
            If txtPchCodeFrom.Text = "" And txtPchCodeTo.Text <> "" Then
                pchCodeFrom = txtPchCodeTo.Text
                pchCodeTo = txtPchCodeTo.Text
            ElseIf txtPchCodeFrom.Text <> "" And txtPchCodeTo.Text = "" Then
                pchCodeFrom = txtPchCodeFrom.Text
                pchCodeTo = txtPchCodeFrom.Text
            End If
        Else
            pchCodeFrom = ""
            pchCodeTo = ""
        End If
        If txtCurrCode.Text = "" Then
            currCode = ""
        Else
            currCode = txtCurrCode.Text
        End If
        strSQL = "exec RPT_Pch_List_Report '" & dateFrom & "' , '" & dateTo & "', '" & pchCodeFrom & "', '" & pchCodeTo & "', '" & currCode & "', '" & Status & "' "

            Dim DA As New SqlDataAdapter(strSQL, Connection)
            Dim DS As New DataSet

            DA.Fill(DS, "POList_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Pch_List_Report.rpt"

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
        NewMDIChild.Text = "Purchase Order Report"
            NewMDIChild.Show()

            cr.Load(strReportPath)
            cr.SetDataSource(DS.Tables("POList_"))
        
        '-----------------MENAMBAH PARAMETER FILTER DATE--------------------------
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterdate As String
        Dim filterpch As String
        Dim filtercurr As String
        Dim filterstatus As String

        If rbAll.Checked = True Then
            filterdate = "Transaction Date : All"
            filterpch = "Purchase Code : All"
            filtercurr = "Currency Code : All"
            filterstatus = "Status : All"
        Else
            filterdate = "Transaction Date : " & dtpFrom.Text & "-" & dtpTo.Text
            If txtPchCodeFrom.Text = "" And txtPchCodeTo.Text = "" Then
                filterpch = "Purchase Code : All"
            Else
                filterpch = "Purchase Code : " & txtPchCodeFrom.Text & "-" & txtPchCodeTo.Text
            End If
            If txtCurrCode.Text = "" Then
                filtercurr = "Currency Code : All"
            Else
                filtercurr = "Currency Code : " & txtCurrCode.Text
            End If
            If cbStatus.SelectedIndex = 0 Then
                filterstatus = "Status : All"
            Else
                filterstatus = "Status : " & cbStatus.SelectedItem
            End If
        End If

        Dim filter As String = filterdate + vbCrLf + filterpch + vbCrLf + filtercurr + vbCrLf + filterstatus
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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtCurrCode.Text = ""
        txtPchCodeFrom.Text = ""
        txtPchCodeTo.Text = ""
        cbStatus.SelectedIndex = 0
    End Sub

    Private Sub btnPchCodeFrom_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPchCodeFrom.Click
        Dim NewFormDialog As New fdlPchCodeFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPchCodeTo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPchCodeTo.Click
        Dim NewFormDialog As New fdlPchCodeTo
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnCurrency_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCurrency.Click
        Dim NewFormDialog As New fdlCurrency
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub rbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAll.CheckedChanged
        GroupBox1.Enabled = False
    End Sub

    Private Sub rbPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPeriod.CheckedChanged
        GroupBox1.Enabled = True
    End Sub
End Class