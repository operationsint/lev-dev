Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptSlsOrder
    Dim m_SlsCodeIdFrom As Integer
    Dim m_SlsCodeIdTo As Integer
    Dim m_CurrId As Integer

    Private Sub rptSlsOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"

        dtpReqDelDateFrom.Format = DateTimePickerFormat.Custom
        dtpReqDelDateFrom.CustomFormat = "dd/MM/yyyy"
        dtpReqDelDateTo.Format = DateTimePickerFormat.Custom
        dtpReqDelDateTo.CustomFormat = "dd/MM/yyyy"

        GroupBox1.Enabled = False

        cbStatus.Items.Insert(0, "All")
        cbStatus.Items.Insert(1, "Outstanding")
        cbStatus.Items.Insert(2, "Partially Delivered")
        cbStatus.Items.Insert(3, "Fully Delivered")
        cbStatus.Items.Insert(4, "Invoiced")
        cbStatus.SelectedIndex = 0

        cbReqDeliveryDate.Checked = False

        dtpReqDelDateFrom.Enabled = False
        dtpReqDelDateTo.Enabled = False

    End Sub
    Public Property SlsNoFrom() As String
        Get
            Return txtSONOFrom.Text
        End Get
        Set(ByVal Value As String)
            txtSONOFrom.Text = Value
        End Set
    End Property
    Public Property SlsNoTo() As String
        Get
            Return txtSONOTo.Text
        End Get
        Set(ByVal Value As String)
            txtSONOTo.Text = Value
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
    Public Property SlsCodeFrom() As String
        Get
            Return txtSlsCodeFrom.Text
        End Get
        Set(ByVal Value As String)
            txtSlsCodeFrom.Text = Value
        End Set
    End Property
    Public Property SlsCodeTo() As String
        Get
            Return txtSlsCodeTo.Text()
        End Get
        Set(ByVal Value As String)
            txtSlsCodeTo.Text() = Value
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
            Return m_SlsCodeIdFrom
        End Get
        Set(ByVal Value As Integer)
            m_SlsCodeIdFrom = Value
        End Set
    End Property
    Public Property PchCodeIdTo() As Integer
        Get
            Return m_SlsCodeIdTo
        End Get
        Set(ByVal Value As Integer)
            m_SlsCodeIdTo = Value
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
        Dim slsCodeFrom As String
        Dim slsCodeTo As String
        Dim currCode As String
        Dim Status As String
        Dim CustCodeFrom As String
        Dim CustCodeTo As String
        Dim SlsOrderFrom As String
        Dim SlsOrderTo As String
        Dim reqDelDateFrom As String
        Dim reqDelDateTo As String

        If rbAll.Checked = True Then
            dateFrom = ""
            dateTo = ""
            Status = ""
            CustCodeFrom = ""
            CustCodeTo = ""
            currCode = ""
            slsCodeFrom = ""
            slsCodeTo = ""
            SlsOrderFrom = ""
            SlsOrderTo = ""
            reqDelDateFrom = ""
            reqDelDateTo = ""
        Else
            dtpFrom.Format = DateTimePickerFormat.Custom
            dtpFrom.CustomFormat = "yyyy/MM/dd"
            dtpTo.Format = DateTimePickerFormat.Custom
            dtpTo.CustomFormat = "yyyy/MM/dd"

            dtpReqDelDateFrom.Format = DateTimePickerFormat.Custom
            dtpReqDelDateFrom.CustomFormat = "yyyy/MM/dd"
            dtpReqDelDateTo.Format = DateTimePickerFormat.Custom
            dtpReqDelDateTo.CustomFormat = "yyyy/MM/dd"

            dateFrom = dtpFrom.Text
            dateTo = dtpTo.Text

            If cbStatus.SelectedIndex = 0 Then
                Status = ""
            ElseIf cbStatus.SelectedIndex = 1 Then
                Status = "O"
            ElseIf cbStatus.SelectedIndex = 2 Then
                Status = "PD"
            ElseIf cbStatus.SelectedIndex = 3 Then
                Status = "FD"
            Else
                Status = "I"
            End If

            If txtCCodeFrom.Text <> "" And txtCCodeTo.Text <> "" Then
                CustCodeFrom = txtCCodeFrom.Text
                CustCodeTo = txtCCodeTo.Text
                If txtCCodeFrom.Text = "" And txtCCodeTo.Text <> "" Then
                    CustCodeFrom = txtCCodeTo.Text
                    CustCodeTo = txtCCodeTo.Text
                ElseIf txtCCodeFrom.Text <> "" And txtCCodeTo.Text = "" Then
                    CustCodeFrom = txtCCodeFrom.Text
                    CustCodeTo = txtCCodeFrom.Text
                End If
            Else
                CustCodeFrom = ""
                CustCodeTo = ""
            End If

            If txtSONOFrom.Text <> "" And txtSONOTo.Text <> "" Then
                SlsOrderFrom = txtSONOFrom.Text
                SlsOrderTo = txtSONOTo.Text
                If txtSONOFrom.Text = "" And txtSONOTo.Text <> "" Then
                    SlsOrderFrom = txtSONOTo.Text
                    SlsOrderTo = txtSONOTo.Text
                ElseIf txtSONOFrom.Text <> "" And txtSONOTo.Text = "" Then
                    SlsOrderFrom = txtSONOFrom.Text
                    SlsOrderTo = txtSONOFrom.Text
                End If
            Else
                SlsOrderFrom = ""
                SlsOrderTo = ""
            End If

            If txtSlsCodeFrom.Text <> "" And txtSlsCodeTo.Text <> "" Then
                slsCodeFrom = txtSlsCodeFrom.Text
                slsCodeTo = txtSlsCodeTo.Text
                If txtSlsCodeFrom.Text = "" And txtSlsCodeTo.Text <> "" Then
                    slsCodeFrom = txtSlsCodeTo.Text
                    slsCodeTo = txtSlsCodeTo.Text
                ElseIf txtSlsCodeFrom.Text <> "" And txtSlsCodeTo.Text = "" Then
                    slsCodeFrom = txtSlsCodeFrom.Text
                    slsCodeTo = txtSlsCodeFrom.Text
                End If
            Else
                slsCodeFrom = ""
                slsCodeTo = ""
            End If

            If txtCurrCode.Text = "" Then
                currCode = ""
            Else
                currCode = txtCurrCode.Text
            End If

            If cbReqDeliveryDate.Checked = True Then
                reqDelDateFrom = dtpReqDelDateFrom.Text
                reqDelDateTo = dtpReqDelDateTo.Text
            Else
                reqDelDateFrom = ""
                reqDelDateTo = ""
            End If

        End If

        strSQL = "exec RPT_Sls_Order_Report '" & SlsOrderFrom & "' , '" & SlsOrderTo & "' , '" & dateFrom & "' , '" & dateTo & "', '" & slsCodeFrom & "', '" & slsCodeTo & "', '" & currCode & "', '" & Status & "', '" & CustCodeFrom & "', '" & CustCodeTo & "', '" & reqDelDateFrom & "' , '" & reqDelDateTo & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SOReport_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_Order_Report.rpt"

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
        NewMDIChild.Text = "Sales Order Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("SOReport_"))

        '-----------------MENAMBAH PARAMETER FILTER DATE--------------------------
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"

        dtpReqDelDateFrom.Format = DateTimePickerFormat.Custom
        dtpReqDelDateFrom.CustomFormat = "dd/MM/yyyy"
        dtpReqDelDateTo.Format = DateTimePickerFormat.Custom
        dtpReqDelDateTo.CustomFormat = "dd/MM/yyyy"

        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterdate As String
        Dim filtersls As String
        Dim filtercurr As String
        Dim filterstatus As String
        Dim filtercustomer As String
        Dim filterslsno As String

        If rbAll.Checked = True Then
            filterdate = "Transaction Date : All"
            filterslsno = "Sales Order No : All"
            filtersls = "Sales Code : All"
            filtercurr = "Currency Code : All"
            filterstatus = "Status : All"
            filtercustomer = "Customer : All"
        Else
            filterdate = "Transaction Date : " & dtpFrom.Text & "-" & dtpTo.Text
            If txtSlsCodeFrom.Text = "" And txtSlsCodeTo.Text = "" Then
                filtersls = "Sales Code : All"
            Else
                filtersls = "Sales Code : " & txtSlsCodeFrom.Text & "-" & txtSlsCodeTo.Text
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
            If txtCCodeFrom.Text = "" And txtCCodeTo.Text = "" Then
                filtercustomer = "Customer Code : All"
            Else
                filtercustomer = "Customer Code : " & txtCCodeFrom.Text & "-" & txtCCodeTo.Text
            End If
            If txtSONOFrom.Text = "" And txtSONOTo.Text = "" Then
                filterslsno = "Sales Order No : All"
            Else
                filterslsno = "Sales Order No : " & txtSONOFrom.Text & "-" & txtSONOTo.Text
            End If
        End If


        Dim filter As String = filterdate + vbCrLf + filterslsno + vbCrLf + filtersls + vbCrLf + filtercurr + vbCrLf + filterstatus + vbCrLf + filtercustomer
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
        txtSlsCodeFrom.Text = ""
        txtSlsCodeTo.Text = ""
        txtCCodeFrom.Text = ""
        txtCCodeTo.Text = ""
        cbStatus.SelectedIndex = 0
    End Sub

    Private Sub btnPchCodeFrom_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSlsCodeFrom.Click
        Dim NewFormDialog As New fdlSlsCodeFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPchCodeTo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSlsCodeTo.Click
        Dim NewFormDialog As New fdlSlsCodeTo
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

   

    Private Sub btnCustFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustFrom.Click
        Dim NewFormDialog As New fdlCustomerFrom
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnCustTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustTo.Click
        Dim NewFormDialog As New fdlCustomerTo
        NewFormDialog.FrmCallerId = Me.Name
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnPrintDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintDetail.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim dateFrom As String
        Dim dateTo As String
        Dim slsCodeFrom As String
        Dim slsCodeTo As String
        Dim currCode As String
        Dim Status As String
        Dim CustCodeFrom As String
        Dim CustCodeTo As String
        Dim SlsOrderFrom As String
        Dim SlsOrderTo As String
        Dim reqDelDateFrom As String
        Dim reqDelDateTo As String

        If rbAll.Checked = True Then
            dateFrom = ""
            dateTo = ""
            Status = ""
            CustCodeFrom = ""
            CustCodeTo = ""
            currCode = ""
            slsCodeFrom = ""
            slsCodeTo = ""
            SlsOrderFrom = ""
            SlsOrderTo = ""
            reqDelDateFrom = ""
            reqDelDateTo = ""
        Else
            dtpFrom.Format = DateTimePickerFormat.Custom
            dtpFrom.CustomFormat = "yyyy/MM/dd"
            dtpTo.Format = DateTimePickerFormat.Custom
            dtpTo.CustomFormat = "yyyy/MM/dd"

            dtpReqDelDateFrom.Format = DateTimePickerFormat.Custom
            dtpReqDelDateFrom.CustomFormat = "yyyy/MM/dd"
            dtpReqDelDateTo.Format = DateTimePickerFormat.Custom
            dtpReqDelDateTo.CustomFormat = "yyyy/MM/dd"

            dateFrom = dtpFrom.Text
            dateTo = dtpTo.Text

            If cbStatus.SelectedIndex = 0 Then
                Status = ""
            ElseIf cbStatus.SelectedIndex = 1 Then
                Status = "O"
            ElseIf cbStatus.SelectedIndex = 2 Then
                Status = "PD"
            ElseIf cbStatus.SelectedIndex = 3 Then
                Status = "FD"
            Else
                Status = "I"
            End If

            If txtCCodeFrom.Text <> "" And txtCCodeTo.Text <> "" Then
                CustCodeFrom = txtCCodeFrom.Text
                CustCodeTo = txtCCodeTo.Text
                If txtCCodeFrom.Text = "" And txtCCodeTo.Text <> "" Then
                    CustCodeFrom = txtCCodeTo.Text
                    CustCodeTo = txtCCodeTo.Text
                ElseIf txtCCodeFrom.Text <> "" And txtCCodeTo.Text = "" Then
                    CustCodeFrom = txtCCodeFrom.Text
                    CustCodeTo = txtCCodeFrom.Text
                End If
            Else
                CustCodeFrom = ""
                CustCodeTo = ""
            End If

            If txtSONOFrom.Text <> "" And txtSONOTo.Text <> "" Then
                SlsOrderFrom = txtSONOFrom.Text
                SlsOrderTo = txtSONOTo.Text
                If txtSONOFrom.Text = "" And txtSONOTo.Text <> "" Then
                    SlsOrderFrom = txtSONOTo.Text
                    SlsOrderTo = txtSONOTo.Text
                ElseIf txtSONOFrom.Text <> "" And txtSONOTo.Text = "" Then
                    SlsOrderFrom = txtSONOFrom.Text
                    SlsOrderTo = txtSONOFrom.Text
                End If
            Else
                SlsOrderFrom = ""
                SlsOrderTo = ""
            End If

            If txtSlsCodeFrom.Text <> "" And txtSlsCodeTo.Text <> "" Then
                slsCodeFrom = txtSlsCodeFrom.Text
                slsCodeTo = txtSlsCodeTo.Text
                If txtSlsCodeFrom.Text = "" And txtSlsCodeTo.Text <> "" Then
                    slsCodeFrom = txtSlsCodeTo.Text
                    slsCodeTo = txtSlsCodeTo.Text
                ElseIf txtSlsCodeFrom.Text <> "" And txtSlsCodeTo.Text = "" Then
                    slsCodeFrom = txtSlsCodeFrom.Text
                    slsCodeTo = txtSlsCodeFrom.Text
                End If
            Else
                slsCodeFrom = ""
                slsCodeTo = ""
            End If

            If txtCurrCode.Text = "" Then
                currCode = ""
            Else
                currCode = txtCurrCode.Text
            End If

            If cbReqDeliveryDate.Checked = True Then
                reqDelDateFrom = dtpReqDelDateFrom.Text
                reqDelDateTo = dtpReqDelDateTo.Text
            Else
                reqDelDateFrom = ""
                reqDelDateTo = ""
            End If
        End If

        strSQL = "exec RPT_Sls_Order_Dtl_Report '" & SlsOrderFrom & "' , '" & SlsOrderTo & "' , '" & dateFrom & "' , '" & dateTo & "', '" & slsCodeFrom & "', '" & slsCodeTo & "', '" & currCode & "', '" & Status & "', '" & CustCodeFrom & "', '" & CustCodeTo & "', '" & reqDelDateFrom & "' , '" & reqDelDateTo & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "SOReportDetail_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Sls_Order_Dtl_Report.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Sales Order Detail Report"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("SOReportDetail_"))

        '-----------------MENAMBAH PARAMETER FILTER DATE--------------------------
        dtpFrom.Format = DateTimePickerFormat.Custom
        dtpFrom.CustomFormat = "dd/MM/yyyy"
        dtpTo.Format = DateTimePickerFormat.Custom
        dtpTo.CustomFormat = "dd/MM/yyyy"

        dtpReqDelDateFrom.Format = DateTimePickerFormat.Custom
        dtpReqDelDateFrom.CustomFormat = "dd/MM/yyyy"
        dtpReqDelDateTo.Format = DateTimePickerFormat.Custom
        dtpReqDelDateTo.CustomFormat = "dd/MM/yyyy"

        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim filterdate As String
        Dim filtersls As String
        Dim filtercurr As String
        Dim filterstatus As String
        Dim filtercustomer As String
        Dim filterslsno As String

        If rbAll.Checked = True Then
            filterdate = "Transaction Date : All"
            filterslsno = "Sales Order No : All"
            filtersls = "Sales Code : All"
            filtercurr = "Currency Code : All"
            filterstatus = "Status : All"
            filtercustomer = "Customer : All"
        Else
            filterdate = "Transaction Date : " & dtpFrom.Text & "-" & dtpTo.Text
            If txtSlsCodeFrom.Text = "" And txtSlsCodeTo.Text = "" Then
                filtersls = "Sales Code : All"
            Else
                filtersls = "Sales Code : " & txtSlsCodeFrom.Text & "-" & txtSlsCodeTo.Text
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
            If txtCCodeFrom.Text = "" And txtCCodeTo.Text = "" Then
                filtercustomer = "Customer Code : All"
            Else
                filtercustomer = "Customer Code : " & txtCCodeFrom.Text & "-" & txtCCodeTo.Text
            End If
            If txtSONOFrom.Text = "" And txtSONOTo.Text = "" Then
                filterslsno = "Sales Order No : All"
            Else
                filterslsno = "Sales Order No : " & txtSONOFrom.Text & "-" & txtSONOTo.Text
            End If
        End If


        Dim filter As String = filterdate + vbCrLf + filterslsno + vbCrLf + filtersls + vbCrLf + filtercurr + vbCrLf + filterstatus + vbCrLf + filtercustomer
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
    
    Private Sub btnSONOFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSONOFrom.Click
        Dim NewFormDialog As New fdlSOrderFrom
        NewFormDialog.FrmCallerId = Me.Name + "From"
        NewFormDialog.ShowDialog()
    End Sub

    Private Sub btnSONOTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSONOTo.Click
        Dim NewFormDialog As New fdlSOrderFrom
        NewFormDialog.FrmCallerId = Me.Name + "To"
        NewFormDialog.ShowDialog()
    End Sub

    
    Private Sub cbReqDeliveryDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbReqDeliveryDate.CheckedChanged
        If cbReqDeliveryDate.Checked = False Then
            dtpReqDelDateFrom.Enabled = False
            dtpReqDelDateTo.Enabled = False
        Else
            dtpReqDelDateFrom.Enabled = True
            dtpReqDelDateTo.Enabled = True
        End If
    End Sub
End Class