Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class rptFakturPajak
    Dim strConnection As String = My.Settings.ConnStr
    Dim cn As SqlConnection = New SqlConnection(strConnection)
    Dim cmd As SqlCommand
    Dim m_Flag As Integer
    Dim m_SInvoiceId As Integer
    Dim m_SInvoiceNo As String

    Public Property Flag() As Integer
        Get
            Return m_Flag
        End Get
        Set(ByVal Value As Integer)
            m_Flag = Value
        End Set
    End Property
    Public Property SInvoiceId() As Integer
        Get
            Return m_SInvoiceId
        End Get
        Set(ByVal Value As Integer)
            m_SInvoiceId = Value
        End Set
    End Property
    Public Property SInvoiceNo() As String
        Get
            Return m_SInvoiceNo
        End Get
        Set(ByVal Value As String)
            m_SInvoiceNo = Value
        End Set
    End Property
    Private Sub btnSInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSInvoice.Click
        fdlSInvoiceList.Show()
    End Sub

    Private Sub rptFakturPajak_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lock_obj(False)
        clear_lvw()
    End Sub

    Sub lock_obj(ByVal isLock As Boolean)
        btnEdit.Enabled = isLock
        btnSave.Enabled = Not isLock
        btnPrint.Enabled = isLock
        btnPrintGroup.Enabled = isLock
    End Sub

    Sub clear_lvw()
        With ListView1
            .Clear()
            .View = View.Details
            .Columns.Add("Sales Invoice No.", 100)
            .Columns.Add("Date", 80)
            .Columns.Add("Customer Code", 80)
            .Columns.Add("Customer Name", 250)
            .Columns.Add("Currency", 80)
            .Columns.Add("Total", 100, HorizontalAlignment.Right)
            .Columns.Add("Tax Inv No", 100)
            .Columns.Add("Multi Inv No", 100)
            .Columns.Add("Tax Notes", 350)
        End With

        If m_Flag <> 0 Then
            cmd = New SqlCommand("usp_tr_faktur_pajak_SEL", cn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinv_id", SqlDbType.NVarChar, 50)
            prm1.Value = m_SInvoiceId

                cn.Open()

                Dim myReader As SqlDataReader = cmd.ExecuteReader()

                Dim lvItem As ListViewItem
            Dim i As Integer, intCurrRow As Integer

                While myReader.Read
                    lvItem = New ListViewItem(CStr(myReader.Item(1)))
                lvItem.Tag = intCurrRow 'ID
                lvItem.SubItems.Add(myReader.GetValue(2))
                For i = 3 To 5
                    lvItem.SubItems.Add(myReader.GetString(i))
                Next
                lvItem.SubItems.Add(myReader.GetValue(6))
                For i = 7 To 9
                    lvItem.SubItems.Add(IIf(myReader.Item(i) Is System.DBNull.Value, "", myReader.Item(i)))
                Next
                txtFakturPajakNo.Text = IIf(myReader.Item(7) Is System.DBNull.Value, "", myReader.Item(7))
                txtFakturInvNo.Text = IIf(myReader.Item(8) Is System.DBNull.Value, "", myReader.Item(8))
                txtNotes.Text = IIf(myReader.Item(9) Is System.DBNull.Value, "", myReader.Item(9))
                    If intCurrRow Mod 2 = 0 Then
                        lvItem.BackColor = Color.Lavender
                    Else
                        lvItem.BackColor = Color.White
                    End If
                    lvItem.UseItemStyleForSubItems = True

                    ListView1.Items.Add(lvItem)
                    intCurrRow += 1
                End While
            myReader.Close()
            cn.Close()
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        m_Flag = 0
        txtFakturInvNo.Text = ""
        txtFakturPajakNo.Text = ""
        txtNotes.Text = ""
        clear_lvw()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim sinvoice_no As String

        Dim I As Integer
        Dim sinvoicearray As String
        sinvoicearray = ""
        Dim counter As Integer = 0
        For I = 0 To ListView1.Items.Count - 1
            sinvoicearray = sinvoicearray + ListView1.Items(I).SubItems(0).Text
            counter = counter + 1
            If counter <> ListView1.Items.Count Then
                sinvoicearray = sinvoicearray + "'',''"
            End If
        Next
        sinvoice_no = sinvoicearray

        strSQL = "exec RPT_Faktur_Pajak_Form '" & sinvoice_no & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "FakturPajak_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Faktur_Pajak_Form.rpt"

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
        NewMDIChild.Text = "Faktur Pajak"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("FakturPajak_"))

        '-----------------MENAMBAH PARAMETER FILTER KE CR--------------------------
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim NoFaktur As String
        If txtFakturPajakNo.Text <> "" Then
            NoFaktur = txtFakturPajakNo.Text
        Else
            NoFaktur = "-"
        End If

        crParameterDiscreteValue.Value = NoFaktur
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("NoFaktur")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
        '-----------------MENAMBAH PARAMETER FILTER KE CR--------------------------
        Dim crParameterFieldDefinitions2 As ParameterFieldDefinitions
        Dim crParameterFieldDefinition2 As ParameterFieldDefinition
        Dim crParameterValues2 As New ParameterValues
        Dim crParameterDiscreteValue2 As New ParameterDiscreteValue
        Dim NoInvoice As String
        If txtFakturInvNo.Text <> "" Then
            NoInvoice = txtFakturInvNo.Text
        Else
            NoInvoice = ListView1.Items(0).SubItems(0).Text
        End If

        crParameterDiscreteValue2.Value = NoInvoice
        crParameterFieldDefinitions2 = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition2 = crParameterFieldDefinitions2.Item("NoInvoice")
        crParameterValues2 = crParameterFieldDefinition2.CurrentValues

        crParameterValues2.Clear()
        crParameterValues2.Add(crParameterDiscreteValue2)
        crParameterFieldDefinition2.ApplyCurrentValues(crParameterValues2)
        '-----------------MENAMBAH PARAMETER FILTER KE CR--------------------------
        Dim crParameterFieldDefinitions3 As ParameterFieldDefinitions
        Dim crParameterFieldDefinition3 As ParameterFieldDefinition
        Dim crParameterValues3 As New ParameterValues
        Dim crParameterDiscreteValue3 As New ParameterDiscreteValue
        Dim Notes As String
        If txtNotes.Text <> "" Then
            Notes = txtNotes.Text
        Else
            Notes = "-"
        End If

        crParameterDiscreteValue3.Value = Notes
        crParameterFieldDefinitions3 = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition3 = crParameterFieldDefinitions3.Item("Notes")
        crParameterValues3 = crParameterFieldDefinition3.CurrentValues

        crParameterValues3.Clear()
        crParameterValues3.Add(crParameterDiscreteValue3)
        crParameterFieldDefinition3.ApplyCurrentValues(crParameterValues3)

        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtFakturPajakNo.Text = "" Then
            MsgBox("Please insert tax invoice number!", vbCritical)
            txtFakturPajakNo.Focus()
            Exit Sub
        End If
        If ListView1.Items.Count < 1 Then
            MsgBox("Please insert sales invoice!", vbCritical)
            btnSInvoice.Focus()
            Exit Sub
        End If
        Try
            For i = 1 To ListView1.Items.Count
                cmd = New SqlCommand("usp_tr_faktur_pajak_UPD", cn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim prm1 As SqlParameter = cmd.Parameters.Add("@sinv_no", SqlDbType.NVarChar, 50)
                prm1.Value = ListView1.Items(i - 1).SubItems(0).Text
                Dim prm2 As SqlParameter = cmd.Parameters.Add("@tax_inv_no", SqlDbType.NVarChar, 50)
                prm2.Value = txtFakturPajakNo.Text
                Dim prm3 As SqlParameter = cmd.Parameters.Add("@multi_inv_no", SqlDbType.NVarChar, 50)
                prm3.Value = txtFakturInvNo.Text
                Dim prm4 As SqlParameter = cmd.Parameters.Add("@tax_notes", SqlDbType.NVarChar, 100)
                prm4.Value = txtNotes.Text

                cn.Open()
                cmd.ExecuteReader()
                cn.Close()
            Next
            If m_Flag = 0 Then
                For i = 1 To ListView1.Items.Count
                    ListView1.Items(i - 1).SubItems(6).Text = txtFakturPajakNo.Text
                    ListView1.Items(i - 1).SubItems(7).Text = txtFakturInvNo.Text
                    ListView1.Items(i - 1).SubItems(8).Text = txtNotes.Text
                Next
            Else
                clear_lvw()
            End If
            lock_obj(True)
        Catch ex As Exception
            MsgBox(ex.Message)
            If ConnectionState.Open = 1 Then cn.Close()
        End Try
    End Sub

    Private Sub btnPrintGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintGroup.Click
        Dim strConnection As String = My.Settings.ConnStr
        Dim Connection As New SqlConnection(strConnection)
        Dim strSQL As String
        Dim sinvoice_no As String

        Dim I As Integer
        Dim sinvoicearray As String
        sinvoicearray = ""
        Dim counter As Integer = 0
        For I = 0 To ListView1.Items.Count - 1
            sinvoicearray = sinvoicearray + ListView1.Items(I).SubItems(0).Text
            counter = counter + 1
            If counter <> ListView1.Items.Count Then
                sinvoicearray = sinvoicearray + "'',''"
            End If
        Next
        sinvoice_no = sinvoicearray

        strSQL = "exec RPT_Faktur_Pajak_Form_Group '" & sinvoice_no & "' "

        Dim DA As New SqlDataAdapter(strSQL, Connection)
        Dim DS As New DataSet

        DA.Fill(DS, "FakturPajakGroup_")

        Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Faktur_Pajak_Form.rpt"

        If Not IO.File.Exists(strReportPath) Then
            Throw (New Exception("Unable to locate report file:" & _
              vbCrLf & strReportPath))
        End If

        Dim cr As New ReportDocument
        Dim NewMDIChild As New frmDocViewer()
        NewMDIChild.Text = "Faktur Pajak"
        NewMDIChild.Show()

        cr.Load(strReportPath)
        cr.SetDataSource(DS.Tables("FakturPajakGroup_"))

        '-----------------MENAMBAH PARAMETER FILTER KE CR--------------------------
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParameterValues As New ParameterValues
        Dim crParameterDiscreteValue As New ParameterDiscreteValue
        Dim NoFaktur As String
        If txtFakturPajakNo.Text <> "" Then
            NoFaktur = txtFakturPajakNo.Text
        Else
            NoFaktur = "-"
        End If

        crParameterDiscreteValue.Value = NoFaktur
        crParameterFieldDefinitions = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("NoFaktur")
        crParameterValues = crParameterFieldDefinition.CurrentValues

        crParameterValues.Clear()
        crParameterValues.Add(crParameterDiscreteValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
        '-----------------MENAMBAH PARAMETER FILTER KE CR--------------------------
        Dim crParameterFieldDefinitions2 As ParameterFieldDefinitions
        Dim crParameterFieldDefinition2 As ParameterFieldDefinition
        Dim crParameterValues2 As New ParameterValues
        Dim crParameterDiscreteValue2 As New ParameterDiscreteValue
        Dim NoInvoice As String
        If txtFakturInvNo.Text <> "" Then
            NoInvoice = txtFakturInvNo.Text
        Else
            NoInvoice = ListView1.Items(0).SubItems(0).Text
        End If

        crParameterDiscreteValue2.Value = NoInvoice
        crParameterFieldDefinitions2 = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition2 = crParameterFieldDefinitions2.Item("NoInvoice")
        crParameterValues2 = crParameterFieldDefinition2.CurrentValues

        crParameterValues2.Clear()
        crParameterValues2.Add(crParameterDiscreteValue2)
        crParameterFieldDefinition2.ApplyCurrentValues(crParameterValues2)
        '-----------------MENAMBAH PARAMETER FILTER KE CR--------------------------
        Dim crParameterFieldDefinitions3 As ParameterFieldDefinitions
        Dim crParameterFieldDefinition3 As ParameterFieldDefinition
        Dim crParameterValues3 As New ParameterValues
        Dim crParameterDiscreteValue3 As New ParameterDiscreteValue
        Dim Notes As String
        If txtNotes.Text <> "" Then
            Notes = txtNotes.Text
        Else
            Notes = "-"
        End If

        crParameterDiscreteValue3.Value = Notes
        crParameterFieldDefinitions3 = cr.DataDefinition.ParameterFields
        crParameterFieldDefinition3 = crParameterFieldDefinitions3.Item("Notes")
        crParameterValues3 = crParameterFieldDefinition3.CurrentValues

        crParameterValues3.Clear()
        crParameterValues3.Add(crParameterDiscreteValue3)
        crParameterFieldDefinition3.ApplyCurrentValues(crParameterValues3)

        With NewMDIChild
            .myCrystalReportViewer.ShowRefreshButton = False
            .myCrystalReportViewer.ShowCloseButton = False
            .myCrystalReportViewer.ShowGroupTreeButton = False
            .myCrystalReportViewer.ReportSource = cr
        End With
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lock_obj(False)
    End Sub
End Class