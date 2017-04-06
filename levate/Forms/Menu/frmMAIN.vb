Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmMAIN
    Dim timer As New Timer()
    Private Sub timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        If checkUserLog(My.Settings.UserName, My.Computer.Name) = False Then
            timer.Stop()
            MsgBox("Your username is logged in another workstation," + vbCrLf + "Please relogin!", vbCritical)
            Me.Text = "Levate"
            fdlLogin.ShowDialog()
        End If
    End Sub
    Sub timerStart()
        timer.Start()
    End Sub

    Private Sub frmMAIN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Auto check user log every 30 minutes
        timer.Interval = 1800000
        'timer.Interval = 30000
        AddHandler timer.Tick, AddressOf timer_Tick
        'timer.Start()
        Try
            Dim strConnection As String = My.Settings.ConnStr
            Dim cn As SqlConnection = New SqlConnection(strConnection)
            Dim cmd As SqlCommand
            Dim Path As String = Application.StartupPath & "\Levate.lic"
            Try
                If System.IO.File.Exists(Path) = True Then
                    Dim reader As New System.IO.StreamReader(Path)
                    Dim allLines As List(Of String) = New List(Of String)
                    Dim CName, UVal, SMac, JS As String
                    Dim ExpDate As Date
                    Do While Not reader.EndOfStream
                        allLines.Add(reader.ReadLine())
                    Loop
                    reader.Close()

                    '-------------------------DECRYPT FROM JS-------------------------------
                    Dim cipherText As String = CStr(ReadLine(3, allLines))
                    Dim password As String = "b119"
                    Dim wrapper As New Dencrypt(password)
                    JS = wrapper.DecryptData(cipherText)
                    '-------------------------END OF DECRYPT--------------------------------

                    '-------------------------DECRYPT FROM CName-------------------------------
                    Dim cipherText2 As String = CStr(ReadLine(0, allLines))
                    Dim password2 As String = JS
                    Dim wrapper2 As New Dencrypt(password2)
                    CName = wrapper2.DecryptData(cipherText2)
                    '-------------------------END OF DECRYPT--------------------------------

                    '-------------------------DECRYPT FROM UVal-------------------------------
                    Dim cipherText3 As String = CStr(ReadLine(1, allLines))
                    Dim password3 As String = JS
                    Dim wrapper3 As New Dencrypt(password3)
                    UVal = CInt(wrapper3.DecryptData(cipherText3))
                    '-------------------------END OF DECRYPT--------------------------------

                    '-------------------------DECRYPT FROM SMac-------------------------------
                    Dim cipherText4 As String = CStr(ReadLine(2, allLines))
                    Dim password4 As String = JS
                    Dim wrapper4 As New Dencrypt(password4)
                    SMac = wrapper4.DecryptData(cipherText4)
                    '-------------------------END OF DECRYPT--------------------------------

                    '-------------------------DECRYPT FROM License Expirated-------------------------------
                    Dim cipherText11 As String = CStr(ReadLine(4, allLines))
                    Dim password11 As String = JS
                    Dim wrapper11 As New Dencrypt(password11)

                    'ExpDate = wrapper11.DecryptData(cipherText11)
                    ' 2016 daniel s : date conv
                    Try
                        ExpDate = wrapper11.DecryptData(cipherText11)
                    Catch ex As Exception
                        Dim x() As String = wrapper11.DecryptData(cipherText11).Split("/".ToCharArray())
                        If x.Length = 3 Then
                            ExpDate = Date.Parse(x(2) & "-" & x(1) & "-" & x(0))
                        End If
                    End Try
                    '-------------------------END OF DECRYPT--------------------------------

                    '20161003 - Dikman: Module Rights
                    If allLines.Count >= 6 Then
                        Dim sModuleRightsEnc As String = CStr(ReadLine(5, allLines))
                        Dim sPassword As String = JS
                        Dim wrpModuleRights As New Dencrypt(sPassword)
                        p_ModuleRights = wrpModuleRights.DecryptData(sModuleRightsEnc)
                    End If

                    'MsgBox(CName + vbCrLf + UVal + vbCrLf + SMac + vbCrLf + JS)

                    'Get validate data and compare them
                    Dim userCount As Integer
                    Dim userEncrypt, userEncrypt3 As String
                    Dim userVal As Integer
                    Dim CName2, SMac2 As String

                    cmd = New SqlCommand("select COUNT(user_id) from mt_user a WHERE a.AC=0 and user_name <> 'admin' ", cn)

                    cn.Open()
                    Dim myReader = cmd.ExecuteReader

                    While myReader.Read
                        userCount = myReader.GetInt32(0)
                    End While
                    'MsgBox(CStr(userCount))
                    myReader.Close()
                    cn.Close()

                    cmd = New SqlCommand("SELECT user_val,company_name,(select sys_init_val from sys_init where sys_init_id='val') as val from sys_company", cn)
                    cn.Open()
                    Dim myReader1 = cmd.ExecuteReader

                    While myReader1.Read
                        userEncrypt = myReader1.GetString(0)
                        CName2 = myReader1.GetString(1)
                        userEncrypt3 = myReader1.GetString(2)
                    End While

                    myReader1.Close()
                    cn.Close()

                    '-------------------------DECRYPT FROM DB UserVal-------------------------------
                    Dim cipherText5 As String = userEncrypt
                    Dim password5 As String = JS
                    Dim wrapper5 As New Dencrypt(password5)
                    userVal = CInt(wrapper5.DecryptData(cipherText5))
                    '-------------------------END OF DECRYPT--------------------------------

                    '-------------------------DECRYPT FROM DB SMac2-------------------------------
                    Dim cipherText7 As String = userEncrypt3
                    Dim password7 As String = JS
                    Dim wrapper7 As New Dencrypt(password7)
                    SMac2 = wrapper7.DecryptData(cipherText7)
                    '-------------------------END OF DECRYPT--------------------------------

                    'MsgBox(CStr(userCount) + "<=" + CStr(userVal) + vbCrLf + _
                    '       CName + "=" + CName2 + vbCrLf + _
                    '       CStr(UVal) + "=" + CStr(userVal) + vbCrLf + _
                    '       SMac + "=" + SMac2)
                    'MsgBox(CStr(ExpDate) + "-" + CStr(System.DateTime.Today))

                    Dim dIntervalWarningDay As Integer
                    Dim dDateDiffWarningDay As Integer = 0
                    Dim bWarningExpired As Boolean = False
                    Dim sMessageWarningExpired As String = ""
                    dIntervalWarningDay = 30


                    If ExpDate < System.DateTime.Today Then
                        MsgBox("License is Expired, Please contact us for information at support@integralindo.com.", MsgBoxStyle.Critical)
                        frmSYSRegister.ShowDialog()
                    Else
                        dDateDiffWarningDay = DateDiff("d", System.DateTime.Today, ExpDate)
                        If dDateDiffWarningDay <= dIntervalWarningDay Then
                            bWarningExpired = True
                            'sMessageWarningExpired = "Your license will be expired in " & CStr(dDateDiffWarningDay) & " days!"
                            sMessageWarningExpired = "Your license is expiring in " & CStr(dDateDiffWarningDay) & " days, please contact Integral team to get the new license."
                        End If
                    End If

                    If userCount <= userVal Then
                        If CName = CName2 And UVal = userVal And SMac = SMac2 Then
                            If bWarningExpired = True Then
                                fdlLogin.lblWarningExpired.Visible = True
                                fdlLogin.lblWarningExpired.Text = sMessageWarningExpired
                            Else
                                fdlLogin.lblWarningExpired.Visible = False
                                fdlLogin.lblWarningExpired.Text = ""
                            End If

                            fdlLogin.ShowDialog()

                        Else
                            MsgBox("License is not valid, please contact support@integralindo.com!", MsgBoxStyle.Critical)
                            frmSYSRegister.ShowDialog()
                        End If

                    Else
                        MsgBox("Levate Registration is not valid" + vbCrLf + "Active Users are more than " + CStr(userVal) + " Please purchase additional user license and load valid Levate License registration.", MsgBoxStyle.Critical)
                        frmSYSRegister.ShowDialog()
                    End If
                Else
                    frmSYSRegister.ShowDialog()
                End If
            Catch ex As Exception
                MsgBox("Unable to start Levate, please check :" + vbCrLf + "1.License" + vbCrLf + "2.Connection to server" + vbCrLf + "3.Server database" + vbCrLf + "For help please contact us at support@integralindo.com" + vbCrLf + vbCrLf + "Error Message :" + vbCrLf + ex.Message + vbCrLf + ex.StackTrace, MsgBoxStyle.Critical)
                frmSYSRegister.ShowDialog()
            End Try

        Catch ex As Exception
            MsgBox("Unable to start Levate, please check :" + vbCrLf + "1.License" + vbCrLf + "2.Connection to server" + vbCrLf + "3.Server database" + vbCrLf + "For help please contact us at support@integralindo.com" + vbCrLf + vbCrLf + "Error Message :" + vbCrLf + ex.Message + vbCrLf + ex.StackTrace, MsgBoxStyle.Critical)
            End
        End Try
    End Sub

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripButton.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub


    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub frmMAIN_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Are you sure you want to exit?", vbCritical + vbOKCancel, Me.Text) = vbCancel Then
            e.Cancel = True
        End If
        userLogout(My.Settings.UserName, My.Computer.Name)
    End Sub

    Private Sub PurchaseOrderToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderToolStripMenuItem1.Click
        If Not GetPermission("frmPOList") = False Then
            frmPOList.MdiParent = Me
            frmPOList.Show()
            frmPOList.BringToFront()
        End If
    End Sub

    Private Sub PurchaseReceiptToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReceiptToolStripMenuItem1.Click
        If Not GetPermission("frmPReceiveList") = False Then
            frmPReceiveList.MdiParent = Me
            frmPReceiveList.Show()
            frmPReceiveList.BringToFront()
        End If
    End Sub

    Private Sub PaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentToolStripMenuItem.Click
        If Not GetPermission("frmPPaymentList") = False Then
            frmPPaymentList.MdiParent = Me
            frmPPaymentList.Show()
            frmPPaymentList.BringToFront()
        End If
    End Sub

    Private Sub SalesOrderToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesOrderToolStripMenuItem1.Click
        If Not GetPermission("frmSOList") = False Then
            frmSOList.MdiParent = Me
            frmSOList.Show()
            frmSOList.BringToFront()
        End If
    End Sub

    Private Sub SalesInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesInvoiceToolStripMenuItem.Click
        If Not GetPermission("frmSInvoiceList") = False Then
            frmSInvoiceList.MdiParent = Me
            frmSInvoiceList.Show()
            frmSInvoiceList.BringToFront()
        End If
    End Sub

    Private Sub SalesPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesPaymentToolStripMenuItem.Click
        If Not GetPermission("frmSPaymentList") = False Then
            With frmSPaymentList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SupplierMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierMasterToolStripMenuItem.Click
        If Not GetPermission("frmSupplier") = False Then
            frmSupplier.MdiParent = Me
            frmSupplier.Show()
            frmSupplier.BringToFront()
        Else
            frmSupplier.Visible = False
        End If
    End Sub

    Private Sub StockMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockMasterToolStripMenuItem.Click
        If Not GetPermission("frmSKU") = False Then
            frmSKU.MdiParent = Me
            frmSKU.Show()
            frmSKU.BringToFront()
        End If
    End Sub

    Private Sub StockCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockCategoryToolStripMenuItem.Click
        If Not GetPermission("frmSKUCat") = False Then
            frmSKUCat.MdiParent = Me
            frmSKUCat.Show()
            frmSKUCat.BringToFront()
        End If
    End Sub

    Private Sub CustomerMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerMasterToolStripMenuItem.Click
        If Not GetPermission("frmCustomer") = False Then
            frmCustomer.MdiParent = Me
            frmCustomer.Show()
            frmCustomer.BringToFront()
        End If
    End Sub

    Private Sub StockAdjToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockAdjToolStripMenuItem.Click
        If Not GetPermission("frmStockAdjList") = False Then
            frmStockAdjList.MdiParent = Me
            frmStockAdjList.Show()
            frmStockAdjList.BringToFront()
        End If
    End Sub

    Private Sub SystemNumberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransactionNumberToolStripMenuItem.Click
        If Not GetPermission("frmSYSNo") = False Then
            frmSYSNo.MdiParent = Me
            frmSYSNo.Show()
            frmSYSNo.BringToFront()
        End If
    End Sub

    Private Sub UserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserToolStripMenuItem.Click
        'Dim NewMDIChild As New frmUser()
        ''Set the Parent Form of the Child window.
        'NewMDIChild.MdiParent = Me
        ''Display the new form.
        'NewMDIChild.Show()
        If Not GetPermission("frmUser") = False Then
            frmUser.MdiParent = Me
            frmUser.Show()
            frmUser.BringToFront()
        End If
    End Sub

    Private Sub SignOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SignOutToolStripMenuItem.Click
        timer.Stop()
        userLogout(My.Settings.UserName, My.Computer.Name)
        Me.Text = "Levate"
        fdlLogin.ShowDialog()
    End Sub

    Private Sub UserLevelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserLevelToolStripMenuItem.Click
        If Not GetPermission("frmUserLevel") = False Then
            frmUserLevel.MdiParent = Me
            frmUserLevel.Show()
            frmUserLevel.BringToFront()
        End If
    End Sub

    Private Sub SupplierListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierListToolStripMenuItem.Click
        If Not GetPermission("rptSupplierList") = False Then
            With rptSupplierList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockListReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockListReportToolStripMenuItem.Click
        If Not GetPermission("rptStkList") = False Then
            With rptStkList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub CustomerListReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerListReportToolStripMenuItem.Click
        If Not GetPermission("rptCustomerList") = False Then
            With rptCustomerList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub CompanyProfileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyProfileToolStripMenuItem.Click
        If Not GetPermission("frmSYSCompany") = False Then
            frmSYSCompany.MdiParent = Me
            frmSYSCompany.Show()
            frmSYSCompany.BringToFront()
        End If
    End Sub

    Private Sub PurchaseRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseRequestToolStripMenuItem.Click
        If Not GetPermission("frmPRequestList") = False Then
            With frmPRequestList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub CurrencyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrencyToolStripMenuItem1.Click
        If Not GetPermission("frmCurrency") = False Then
            With frmCurrency
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub LocationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocationToolStripMenuItem.Click
        If Not GetPermission("frmLocation") = False Then
            With frmLocation
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseRequestApprovalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseRequestApprovalToolStripMenuItem.Click
        If Not GetPermission("frmPRequestApprovalList") = False Then
            With frmPRequestApprovalList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub ExpenseIncomeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpenseIncomeToolStripMenuItem.Click
        If Not GetPermission("frmExpInc") = False Then
            With frmExpInc
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockSetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockSetToolStripMenuItem.Click
        If Not GetPermission("frmSKUPackageList") = False Then
            With frmSKUPackageList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseInvoiceToolStripMenuItem.Click
        If Not GetPermission("frmPInvoiceList") = False Then
            With frmPInvoiceList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockLocationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockLocationToolStripMenuItem.Click
        If Not GetPermission("frmSKULocationList") = False Then
            With frmSKULocationList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesDeliveryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesDeliveryToolStripMenuItem.Click
        If Not GetPermission("frmSDeliveryList") = False Then
            With frmSDeliveryList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub CurrencyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrencyToolStripMenuItem.Click
        With frmCurrencyR
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub ExpenseIncomeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpenseIncomeToolStripMenuItem1.Click
        With frmExpenseR
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub StockLocationMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockLocationMasterToolStripMenuItem.Click
        If Not GetPermission("rptStkLocation") = False Then
            With rptStkLocation
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BC40ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BC40ToolStripMenuItem.Click
        If Not GetPermission("frmBCList") = False Then
            With frmBCList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReturnToolStripMenuItem.Click
        If Not GetPermission("frmPReturnList") = False Then
            With frmPReturnList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseOrderRecapToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderRecapToolStripMenuItem.Click
        If Not GetPermission("rptPORecap") = False Then
            With rptPORecap
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseOrderListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderListToolStripMenuItem.Click
        If Not GetPermission("rptPOList") = False Then
            With rptPOList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockPriceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockPriceToolStripMenuItem.Click
        If Not GetPermission("frmSKUPrice") = False Then
            With frmSKUPrice
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockMovementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockMovementToolStripMenuItem.Click
        If Not GetPermission("frmStockMovementList") = False Then
            With frmStockMovementList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseCodeStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseCodeStripMenuItem.Click
        If Not GetPermission("frmPurchaseCode") = False Then
            With frmPurchaseCode
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesCodeStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesCodeStripMenuItem.Click
        If Not GetPermission("frmSalesCode") = False Then
            With frmSalesCode
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReturnToolStripMenuItem.Click
        If Not GetPermission("frmSReturnList") = False Then
            With frmSReturnList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockTransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockTransactionToolStripMenuItem.Click
        If Not GetPermission("rptStkTransaction") = False Then
            With rptStkTransaction
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseIncomingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseIncomingReportToolStripMenuItem.Click
        If Not GetPermission("rptPIncoming") = False Then
            With rptPIncoming
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockMovementReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockMovementReportToolStripMenuItem.Click
        If Not GetPermission("rptStkMovement") = False Then
            With rptStkMovement
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseRequestReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseRequestReportToolStripMenuItem.Click
        If Not GetPermission("rptPRequest") = False Then
            With rptPRequest
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseInvoiceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseInvoiceReportToolStripMenuItem.Click
        If Not GetPermission("rptPInvoice") = False Then
            With rptPInvoice
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockAdjustmentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockAdjustmentReportToolStripMenuItem.Click
        If Not GetPermission("rptStkAdjustment") = False Then
            With rptStkAdjustment
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseReturnReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReturnReportToolStripMenuItem.Click
        If Not GetPermission("rptPReturn") = False Then
            With rptPReturn
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockSetListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockSetListToolStripMenuItem.Click
        If Not GetPermission("rptStkSet") = False Then
            With rptStkSet
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub LocationListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LocationListToolStripMenuItem.Click
        If Not GetPermission("rptLocation") = False Then
            Dim strConnection As String = My.Settings.ConnStr
            Dim Connection As New SqlConnection(strConnection)
            Dim strSQL As String


            strSQL = "exec RPT_Location_Report "

            Dim DA As New SqlDataAdapter(strSQL, Connection)
            Dim DS As New DataSet

            DA.Fill(DS, "Location_")

            Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Location_Report.rpt"

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
            NewMDIChild.Text = "Location"
            NewMDIChild.Show()

            cr.Load(strReportPath)
            cr.SetDataSource(DS.Tables("Location_"))
            With NewMDIChild
                .myCrystalReportViewer.ShowRefreshButton = False
                .myCrystalReportViewer.ShowCloseButton = False
                .myCrystalReportViewer.ShowGroupTreeButton = False
                .myCrystalReportViewer.ReportSource = cr
            End With
        End If
    End Sub

    Private Sub StockCategoryListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockCategoryListToolStripMenuItem.Click
        If Not GetPermission("rptStkCategory") = False Then
            Dim strConnection As String = My.Settings.ConnStr
            Dim Connection As New SqlConnection(strConnection)
            Dim strSQL As String


            strSQL = "exec RPT_Stk_Category_Report "

            Dim DA As New SqlDataAdapter(strSQL, Connection)
            Dim DS As New DataSet

            DA.Fill(DS, "StkCategory_")

            Dim strReportPath As String = Application.StartupPath & "\Reports\RPT_Stk_Category_Report.rpt"

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
            NewMDIChild.Text = "Stock Category"
            NewMDIChild.Show()

            cr.Load(strReportPath)
            cr.SetDataSource(DS.Tables("StkCategory_"))
            With NewMDIChild
                .myCrystalReportViewer.ShowRefreshButton = False
                .myCrystalReportViewer.ShowCloseButton = False
                .myCrystalReportViewer.ShowGroupTreeButton = False
                .myCrystalReportViewer.ReportSource = cr
            End With
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        LvtAboutBox.Show()
    End Sub

    Private Sub PeriodToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PeriodToolStripMenuItem.Click
        If Not GetPermission("frmSYSPeriodList") = False Then
            With frmSYSPeriodList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReportToolStripMenuItem.Click
        If Not GetPermission("rptSlsOrder") = False Then
            With rptSlsOrder
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesDeliveryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesDeliveryReportToolStripMenuItem.Click
        If Not GetPermission("rptSlsDel") = False Then
            With rptSlsDel
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesInvoiceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesInvoiceReportToolStripMenuItem.Click
        If Not GetPermission("rptSlsInvoice") = False Then
            With rptSlsInvoice
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesReturnReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReturnReportToolStripMenuItem.Click
        If Not GetPermission("rptSlsReturn") = False Then
            With rptSlsReturn
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseTransactionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseTransactionReportToolStripMenuItem.Click
        If Not GetPermission("rptPTransaction") = False Then
            With rptPTransaction
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesPriceListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesPriceListToolStripMenuItem.Click
        If Not GetPermission("rptStkPrice") = False Then
            With rptStkPrice
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesTransactionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTransactionReportToolStripMenuItem.Click
        If Not GetPermission("rptSlsTransaction") = False Then
            With rptSlsTransaction
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BankCardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankCardToolStripMenuItem.Click
        If Not GetPermission("frmBank") = False Then
            With frmBank
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub ExpenseIncomeReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpenseIncomeReportToolStripMenuItem.Click
        If Not GetPermission("rptExpInc") = False Then
            With rptExpInc
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub AccountMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountMasterToolStripMenuItem.Click
        If Not GetPermission("frmAccount") = False Then
            With frmAccount
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If

        'With frmSYSAccount
        '    .MdiParent = Me
        '    .Show()
        '    .BringToFront()
        'End With
    End Sub

    Private Sub JournalEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalEntryToolStripMenuItem.Click
        If Not GetPermission("frmJournalList") = False Then
            With frmJournalList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseIncomingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseIncomingToolStripMenuItem.Click
        If Not GetPermission("frmPReceivePostList") = False Then
            With frmPReceivePostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BankToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankToolStripMenuItem1.Click
        If Not GetPermission("rptBankList") = False Then
            With rptBankList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchasePaymentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchasePaymentReportToolStripMenuItem.Click
        If Not GetPermission("rptPPayment") = False Then
            With rptPPayment
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesReceiptReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReceiptReportToolStripMenuItem.Click
        If Not GetPermission("rptSlsReceipt") = False Then
            With rptSlsReceipt
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub GeneralLedgerAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerAccountSettingToolStripMenuItem.Click
        If Not GetPermission("frmSYSAccount") = False Then
            With frmSYSAccount
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseInvoiceToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseInvoiceToolStripMenuItem1.Click
        If Not GetPermission("frmPInvoicePostList") = False Then
            With frmPInvoicePostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    

    Private Sub BankTransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankTransactionToolStripMenuItem.Click
        If Not GetPermission("rptBankTransaction") = False Then
            With rptBankTransaction
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockControlReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockControlReportToolStripMenuItem.Click
        If Not GetPermission("rptStkControl") = False Then
            With rptStkControl
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub FakturPajakToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FakturPajakToolStripMenuItem.Click
        If Not GetPermission("rptFakturPajak") = False Then
            With rptFakturPajak
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub LedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerToolStripMenuItem.Click

    End Sub

    Private Sub MenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub

    Private Sub PurchasePaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchasePaymentToolStripMenuItem.Click
        If Not GetPermission("frmPPaymentPostList") = False Then
            With frmPPaymentPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BankAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankAdjustmentToolStripMenuItem.Click
        If Not GetPermission("frmBankAdjList") = False Then
            With frmBankAdjList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseReturnToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReturnToolStripMenuItem1.Click
        If Not GetPermission("frmPReturnPostList") = False Then
            With frmPReturnPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesMonthlyStatementReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesMonthlyStatementReportToolStripMenuItem.Click
        If Not GetPermission("rptSlsMonthlyStatement") = False Then
            With rptSlsMonthlyStatement
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BackgroundParameterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackgroundParameterToolStripMenuItem.Click
        If Not GetPermission("frmSYSSetting") = False Then
            With frmSYSSetting
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BankPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankPaymentToolStripMenuItem.Click
        If Not GetPermission("frmBankPaymentList") = False Then
            With frmBankPaymentList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BankReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankReceiptToolStripMenuItem.Click
        If Not GetPermission("frmBankReceiptList") = False Then
            With frmBankReceiptList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockCostAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockCostAdjustmentToolStripMenuItem.Click
        If Not GetPermission("frmStockCostAdjList") = False Then
            With frmStockCostAdjList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesDeliveryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesDeliveryToolStripMenuItem1.Click
        If Not GetPermission("frmSDeliveryPostList") = False Then
            With frmSDeliveryPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesInvoiceToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesInvoiceToolStripMenuItem1.Click
        If Not GetPermission("frmSInvoicePostList") = False Then
            With frmSInvoicePostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReceiptToolStripMenuItem.Click
        If Not GetPermission("frmSPaymentPostList") = False Then
            With frmSPaymentPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SupplierAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierAdjustmentToolStripMenuItem.Click
        If Not GetPermission("frmSupplierAdjList") = False Then
            With frmSupplierAdjList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesReturnToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReturnToolStripMenuItem1.Click
        If Not GetPermission("frmSReturnPostList") = False Then
            With frmSReturnPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseAPAgingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseAPAgingReportToolStripMenuItem.Click
        If Not GetPermission("rptPAPAging") = False Then
            With rptPAPAging
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesARAgingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesARAgingReportToolStripMenuItem.Click
        If Not GetPermission("rptSlSARAging") = False Then
            With rptSlsARAging
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub PurchaseInvoiceSummaryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseInvoiceSummaryReportToolStripMenuItem.Click
        If Not GetPermission("rptPInvoiceSum") = False Then
            With rptPInvoiceSum
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockAdjustmentToolStripMenuItem.Click
        If Not GetPermission("frmStockAdjPostList") = False Then
            With frmStockAdjPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub StockMovementToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockMovementToolStripMenuItem1.Click
        If Not GetPermission("frmStockMovementPostList") = False Then
            With frmStockMovementPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BankReceiptToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankReceiptToolStripMenuItem1.Click
        If Not GetPermission("frmBankReceiptPostList") = False Then
            With frmBankReceiptPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BankPaymentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankPaymentToolStripMenuItem1.Click
        If Not GetPermission("frmBankPaymentPostList") = False Then
            With frmBankPaymentPostList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub COGSReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COGSReportToolStripMenuItem.Click
        If Not GetPermission("rptSlsCOGS") = False Then
            With rptSlsCOGS
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub CurrencyRevaluationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CurrencyRevaluationToolStripMenuItem.Click
        If Not GetPermission("frmCurrencyRevaluation") = False Then
            With frmCurrencyRevaluation
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub JournalTransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalTransactionToolStripMenuItem.Click
        If Not GetPermission("rptGLJournalTrans") = False Then
            With rptGLJournalTrans
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesInvoiceSummaryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesInvoiceSummaryReportToolStripMenuItem.Click
        If Not GetPermission("rptSlsInvoiceSum") = False Then
            With rptSlsInvoiceSum
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub FixedAssetCardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FixedAssetCardToolStripMenuItem.Click
        If Not GetPermission("frmFixedAsset") = False Then
            With frmFixedAsset
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub FixedAssetCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FixedAssetCategoryToolStripMenuItem.Click
        If Not GetPermission("frmFixedAssetCat") = False Then
            With frmFixedAssetCat
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub GenerateFixedAssetDepreciationJournalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateFixedAssetDepreciationJournalToolStripMenuItem.Click
        If Not GetPermission("frmFixedAssetGenJournal") = False Then
            With frmFixedAssetGenJournal
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub FixedAssetListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FixedAssetListToolStripMenuItem.Click
        If Not GetPermission("rptFixedAssetList") = False Then
            With rptFixedAssetList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub CostToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CostToolStripMenuItem.Click
        If Not GetPermission("frmCost") = False Then
            With frmCost
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub WorkOrderToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkOrderToolStripMenuItem1.Click
        If Not GetPermission("frmWorkOrderList") = False Then
            With frmWorkOrderList
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub WorkOrderProductionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkOrderProductionReportToolStripMenuItem.Click
        If Not GetPermission("rptWorkOrder") = False Then
            With rptWorkOrder
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub LicenseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LicenseToolStripMenuItem.Click
        With frmSYSRegister
            .MdiParent = Me
            .Show()
            .BringToFront()
            .canClose = True
        End With
    End Sub

    Private Sub FixedAssetDepreciationJournalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FixedAssetDepreciationJournalToolStripMenuItem.Click
        If Not GetPermission("rptFixedAssetGenJournal") = False Then
            With rptFixedAssetGenJournal
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub CopyDatabasePLAYToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyDatabasePLAYToolStripMenuItem.Click
        With frmSysCopyPlay
            .MdiParent = Me
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub GeneralLedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneralLedgerToolStripMenuItem.Click
        If Not GetPermission("rptGeneralLedgerReport") = False Then
            With rptGeneralLedgerReport
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub ProfitLossToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfitLossToolStripMenuItem.Click
        If Not GetPermission("rptPnLReport") = False Then
            With rptPnLReport
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub TrialBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrialBalanceToolStripMenuItem.Click
        'If Not GetPermission("rptTrialBalanceReport") = False Then
        With rptTrialBalanceReport
            .MdiParent = Me
            .Show()
            .BringToFront()
        End With
        'End If
    End Sub

    Private Sub WorkOrderControlReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkOrderControlReportToolStripMenuItem.Click
        '20160510 daniel s
        If Not GetPermission("rptWorkOrderControl") = False Then
            With rptWorkOrderControl
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub SalesStockSalesReport_Click(sender As System.Object, e As System.EventArgs) Handles SalesStockSalesReport.Click
        'sales stock sales report 
        '20160517 daniel s
        If Not GetPermission("rptSlsStockSales") = False Then
            With rptSlsStockSales
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub BalanceSheetToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BalanceSheetToolStripMenuItem.Click
        '20160701 daniel s
        'report yg belum diproses dari ken
        If Not GetPermission("rptBalanceSheet") = False Then
            With rptBalanceSheet
                .MdiParent = Me
                .Show()
                .BringToFront()
            End With
        End If
    End Sub

    Private Sub JournalTransactionDetailToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles JournalTransactionDetailToolStripMenuItem.Click
        '20160714 daniel s
        'request bima

        If GetPermission("rptGLJournalTransDetail") = False Then Exit Sub

        With rptGLJournalTransDetail
            .MdiParent = Me
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub WorkOrderCostDetailReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles WorkOrderCostDetailReport.Click
        '20160724 daniel s
        'rune request
        If GetPermission("rptWorkOrderCostDetail") = False Then Exit Sub

        With rptWorkOrderCostDetail
            .MdiParent = Me
            .Show()
            .BringToFront()
        End With

    End Sub

    Private Sub ToolStripMenuSupplierControlReport_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuSupplierControlReport.Click
        '20160807 daniel s
        'bima request
        If GetPermission("rptSupplierControl") = False Then Exit Sub

        With rptSupplierControl
            .MdiParent = Me
            .Show()
            .BringToFront()
        End With

    End Sub

    Private Sub ToolStripMenuCustomerControl_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuCustomerControl.Click
        '20160807 daniel s
        'bima request
        If GetPermission("rptCustomerControl") = False Then Exit Sub

        With rptCustomerControl
            .MdiParent = Me
            .Show()
            .BringToFront()
        End With

    End Sub

    Private Sub SalesCustomerBalanceReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesCustomerBalanceReport.Click
        'If Not GetPermission("rptSlsCOGS") = False Then
        With rptSlsCustomerBalanceReport
            .MdiParent = Me
            .Show()
            .BringToFront()
        End With
        'End If
    End Sub

    Private Sub BankExpenseReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankExpenseReport.Click
        'If Not GetPermission("rptSlsCOGS") = False Then
        With rptBankExpense
            .MdiParent = Me
            .Show()
            .BringToFront()
        End With
        'End If
    End Sub

    Private Sub BankDetailReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankDetailReport.Click
        'If Not GetPermission("rptSlsCOGS") = False Then
        With rptBankDetail
            .MdiParent = Me
            .Show()
            .BringToFront()
        End With
        'End If
    End Sub

    Private Sub tsmProductionProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmProductionProcess.Click
        'If Not GetPermission("frmCustomer") = False Then
        frmProcessCode.MdiParent = Me
        frmProcessCode.Show()
        frmProcessCode.BringToFront()
        'End If
    End Sub

    Private Sub tsmLabour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmLabour.Click
        'If Not GetPermission("frmCustomer") = False Then
        frmLabour.MdiParent = Me
        frmLabour.Show()
        frmLabour.BringToFront()
        'End If
    End Sub


    'Private Sub CostToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CostToolStripMenuItem.Click

    'End Sub

    Private Sub BankAdjustmentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankAdjustmentToolStripMenuItem1.Click
        'If Not GetPermission("frmBankReceiptPostList") = False Then
        With frmBankAdjPostList
            .MdiParent = Me
            .Show()
            .BringToFront()
        End With
        'End If
    End Sub

    Private Sub WorkOrderProcessDetailReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkOrderProcessDetailReport.Click
        With rptWorkOrderProcessDetail
            .MdiParent = Me
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub WorkOrderProcessLabourReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkOrderProcessLabourReport.Click
        With rptWorkOrderProcessLabour
            .MdiParent = Me
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub CustomerCategoryCardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerCategoryCardToolStripMenuItem.Click
        If Not GetPermission("frmCustomerCat") = False Then
            frmCustomerCat.MdiParent = Me
            frmCustomerCat.Show()
            frmCustomerCat.BringToFront()
        End If
    End Sub
End Class
