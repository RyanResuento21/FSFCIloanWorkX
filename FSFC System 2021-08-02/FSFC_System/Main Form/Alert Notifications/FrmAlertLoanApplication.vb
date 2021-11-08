Imports word = Microsoft.Office.Interop.Word

Public Class FrmAlertLoanApplication
    Public FromLogin As Boolean = False
    Dim CI As String = "Credit Investigation"
    Dim Head As Boolean
    Private WithEvents Bw As New ComponentModel.BackgroundWorker
    Private Sub FrmAlertLoanApplication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView10, GridView11, GridView12, GridView13, GridView14, GridView15, GridView16, GridView17, GridView18, GridView19, GridView20, GridView21, GridView22, GridView23, GridView24, GridView3, GridView4, GridView5, GridView6, GridView7, GridView8, GridView9})
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 6, 1, True)
        btnCancel.Enabled = False
        tabCI.Enabled = False
        tabRequest.Enabled = False
        tabRelease.Enabled = False
        tabForCollection.Enabled = False
        tabForPosting.Enabled = False
        tabROPOA_Verification.Enabled = False
        tabROPOA_Consolidation.Enabled = False
        tabROPOA_ImpairmentII.Enabled = False
        tabImpairmentDue.Enabled = False
        tabExpiredReservation.Enabled = False
        tabROPOA_Approval.Enabled = False
        tabSMS_Alert.Enabled = False
        tabEmailOutbox.Enabled = False
        tabCashAdvance.Enabled = False
        tabPettyCash.Enabled = False
        tabForLiquidation.Enabled = False
        tabITLMonitoring.Enabled = False
        tabNonLoans.Enabled = False
        tabForAcknowledgement.Enabled = False
        tabForCV.Enabled = False
        tabForJV.Enabled = False
        tabForRollOver.Enabled = False
        tabPromise.Enabled = False
        tabFinancial.Enabled = False
        Cursor = Cursors.WaitCursor

        If ComparePosition({"CREDIT INVESTIGATOR"}, False) Then
            CI = "For Credit Investigation"
        End If
        LoadCreditApplication()

        With bw
            .WorkerSupportsCancellation = True
            .WorkerReportsProgress = True
            If .IsBusy = False Then
                .RunWorkerAsync()
            End If
        End With

        If ComparePosition({"REGIONAL MANAGER"}, False) Then
        Else
            Timer.Start()
        End If

        If FrmMain.btnSettings.Enabled = False Then
            GridColumn137.Visible = False
            GridColumn138.Visible = False
            GridColumn139.Visible = False
            GridColumn140.Visible = False
            GridColumn141.Visible = False
            GridColumn142.Visible = False
            GridColumn144.Visible = False
            GridColumn145.Visible = False
            GridColumn146.Visible = False
            GridColumn147.Visible = False
            GridColumn148.Visible = False
            GridColumn162.Visible = False
            GridColumn166.Visible = False
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetButtonFontSettings({btnEmail, btnCheck, btnConsolidate, btnVerify, btnForfeit, btnCancelSMS, btnRefresh, btnCancel, btnPrint})

            GetContextMenuBarFontSettings({ContextMenuBar1, ContextMenuBar3})

            GetTabControlFontSettings({SuperTabControl1, SuperTabControl4, SuperTabControl2, SuperTabControl3, SuperTabControl5, SuperTabControl6})
        Catch ex As Exception
            TriggerBugReport("Alert Notification - Fix UI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        LblTitle_Click(sender, e)
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Alert Notification", lblTitle.Text)
    End Sub

    Private Sub LoadList()
        Try
            'SpecialAccessPosition(1)
            'If User_Type = "ADMIN" Or ComparePosition({"CREDIT INVESTIGATOR", "REGIONAL MANAGER", "DISTRICT MANAGER", "BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Then
            '    LoadCI()
            'End If
            If User_Type = "ADMIN" Or ComparePosition({"CREDIT INVESTIGATOR", "REGIONAL MANAGER", "DISTRICT MANAGER", "BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Then
                LoadCI()
            End If
            tabCI.Enabled = True
            If User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Or ComparePosition({"LOANS PROCESSOR", "CLIENT SOLUTIONS SPECIALIST", "REGIONAL MANAGER", "DISTRICT MANAGER", "BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Then
                LoadRequest()
            End If
            tabRequest.Enabled = True
            If User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Or ComparePosition({"CASHIER", "CLIENT SOLUTIONS SPECIALIST", "ACCOUNTS MONITORING", "REGIONAL MANAGER", "DISTRICT MANAGER", "BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Then
                LoadRelease()

                LoadCollection()

                LoadPosting()

                LoadPromise()
            End If
            tabRelease.Enabled = True
            tabForCollection.Enabled = True
            tabForPosting.Enabled = True
            If User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Or ComparePosition({"REGIONAL MANAGER", "DISTRICT MANAGER", "BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Then
                LoadROPOAVerification()

                LoadROPOAConsolidation()

                LoadROPOAImpairment()

                LoadImpairmentDue()

                If User_Type = "ADMIN" Or ComparePosition({"REGIONAL MANAGER", "DISTRICT MANAGER", "BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Then
                    tabExpiredReservation.Visible = True
                    LoadExpiredReservation()
                End If
            End If
            tabROPOA_Verification.Enabled = True
            tabROPOA_Consolidation.Enabled = True
            tabImpairmentDue.Enabled = True
            tabROPOA_ImpairmentII.Enabled = True
            tabExpiredReservation.Enabled = True
            tabROPOA_Approval.Enabled = True
            LoadSMS()
            LoadEmail()
            tabSMS_Alert.Enabled = True
            tabEmailOutbox.Enabled = True
            Head = DataObject(String.Format("SELECT Head FROM position_setup WHERE position_setup.`Position` = '{0}';", Empl_Position))
            If User_Type = "ADMIN" Or ComparePosition({"REGIONAL MANAGER", "DISTRICT MANAGER", "BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Or Head Or CompareDepartment({"FINANCE"}, False) Or Department.ToUpper.Contains("CREDIT AND COLLECTION") Or Department.ToUpper.Contains("ADMINISTRATIVE") Then
                LoadCashAdvance()
            End If
            tabCashAdvance.Enabled = True
            If User_Type = "ADMIN" Or ComparePosition({"REGIONAL MANAGER", "DISTRICT MANAGER", "BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER", "CASHIER", "CLIENT SOLUTIONS SPECIALIST", "ACCOUNTS MONITORING"}, False) Or Head Or Department.ToUpper.Contains("CREDIT AND COLLECTION") Or Department.ToUpper.Contains("ADMINISTRATIVE") Then
                LoadPettyCash()
            End If
            tabPettyCash.Enabled = True

            LoadLiquidation()
            tabForLiquidation.Enabled = True
            If User_Type = "ADMIN" Or ComparePosition({"REGIONAL MANAGER", "DISTRICT MANAGER", "BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER", "LEGAL CLERK", "CORPORATE LAWYER"}, False) Then
                LoadITLMonitoring()
            End If
            tabITLMonitoring.Enabled = True
            tabNonLoans.Enabled = True
            If ComparePosition({"CASHIER", "CLIENT SOLUTIONS SPECIALIST", "ACCOUNTS MONITORING"}, False) Or User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Then
                LoadAcknowledgement()
            End If
            tabForAcknowledgement.Enabled = True
            If User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Or ComparePosition({"REGIONAL MANAGER", "DISTRICT MANAGER", "BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Then
                LoadForCV()
                LoadForJV()
                LoadForRollOver()
            End If
            tabForCV.Enabled = True
            tabForJV.Enabled = True
            tabForRollOver.Enabled = True
            tabPromise.Enabled = True
            tabFinancial.Enabled = True

            If GridView1.RowCount = 0 And GridView10.RowCount = 0 And GridView11.RowCount = 0 And GridView12.RowCount = 0 And GridView13.RowCount = 0 And GridView14.RowCount = 0 And GridView3.RowCount = 0 And GridView4.RowCount = 0 And GridView5.RowCount = 0 And GridView6.RowCount = 0 And GridView7.RowCount = 0 And GridView8.RowCount = 0 And GridView9.RowCount = 0 And GridView15.RowCount = 0 And GridView16.RowCount = 0 And GridView17.RowCount = 0 And GridView18.RowCount = 0 And GridView19.RowCount = 0 And GridView20.RowCount = 0 And GridView22.RowCount = 0 And GridView21.RowCount = 0 And GridView23.RowCount = 0 And GridView24.RowCount = 0 And FromLogin Then
                CancelBW()
                Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CancelBW()
        With bw
            If .IsBusy Then
                If .WorkerSupportsCancellation Then
                    .CancelAsync()
                End If
            End If
        End With
    End Sub

    Private Sub Bw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Bw.DoWork
        LoadList()
    End Sub

    Private Sub Bw_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Bw.RunWorkerCompleted
        btnCancel.Enabled = True
    End Sub

    Private Sub LoadData()
        If SuperTabControl1.SelectedTabIndex = 0 And SuperTabControl4.SelectedTabIndex = 0 Then
            LoadCreditApplication()
        ElseIf SuperTabControl1.SelectedTabIndex = 0 And SuperTabControl4.SelectedTabIndex = 1 Then
            LoadCI()
        ElseIf SuperTabControl1.SelectedTabIndex = 0 And SuperTabControl4.SelectedTabIndex = 2 Then
            LoadRequest()
        ElseIf SuperTabControl1.SelectedTabIndex = 0 And SuperTabControl4.SelectedTabIndex = 3 Then
            LoadRelease()
        End If
    End Sub

    Private Sub LoadCreditApplication()
        Try
            GridControl1.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_CreditApplication('{0}','{1}')", If(Multiple_ID = "", Branch_ID, Multiple_ID), If(User_Type = "ADMIN" Or ComparePosition({"REGIONAL MANAGER", "BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False), "", User_Code)))
            If GridView1.RowCount > 11 Then
                GridColumn8.Width = 307 - 17
            Else
                GridColumn8.Width = 307
            End If

            If GridView1.RowCount > 0 Then
                tabCreditApp.Text = String.Format("[{0}] Credit Application", GridView1.RowCount)
            Else
                tabCreditApp.Text = "Credit Application"
            End If
            '******** C R E D I T   T O T A L ************
            If GridView1.RowCount + GridView10.RowCount + GridView11.RowCount + GridView12.RowCount + GridView13.RowCount + GridView14.RowCount > 0 Then
                tabLoanManagement.Text = String.Format("[{0}] Loans Management", GridView1.RowCount + GridView10.RowCount + GridView11.RowCount + GridView12.RowCount + GridView13.RowCount + GridView14.RowCount)
            Else
                tabLoanManagement.Text = "Loans Management"
            End If
            '******** C R E D I T   T O T A L ************
            With GridView1.Columns("Borrower").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadCI()
        Try
            If ComparePosition({"CREDIT INVESTIGATOR"}, False) Then
                GridColumn94.Visible = False
                GridColumn89.Visible = False
                GridColumn90.Visible = False
                GridColumn91.Visible = False
                GridColumn92.Visible = False
                GridColumn95.Visible = False

                GridColumn116.Visible = True
                GridColumn117.Visible = True
                GridColumn118.Visible = True
                GridColumn119.Visible = True

                GridColumn85.VisibleIndex = 0
                GridColumn86.VisibleIndex = 1
                GridColumn87.VisibleIndex = 2
                GridColumn88.VisibleIndex = 3
                GridColumn116.VisibleIndex = 4
                GridColumn117.VisibleIndex = 5
                GridColumn118.VisibleIndex = 6
                GridColumn119.VisibleIndex = 7
                GridColumn93.VisibleIndex = 8

                GridControl10.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_CreditInvestigation('{0}',{1})", If(Multiple_ID = "", Branch_ID, Multiple_ID), Empl_ID))
            Else
                GridColumn94.Visible = True
                GridColumn89.Visible = True
                GridColumn90.Visible = True
                GridColumn91.Visible = True
                GridColumn92.Visible = True
                GridColumn95.Visible = True

                GridColumn116.Visible = False
                GridColumn117.Visible = False
                GridColumn118.Visible = False
                GridColumn119.Visible = False

                GridColumn94.VisibleIndex = 0
                GridColumn85.VisibleIndex = 1
                GridColumn86.VisibleIndex = 2
                GridColumn87.VisibleIndex = 3
                GridColumn88.VisibleIndex = 4
                GridColumn89.VisibleIndex = 5
                GridColumn90.VisibleIndex = 6
                GridColumn91.VisibleIndex = 7
                GridColumn92.VisibleIndex = 8
                GridColumn95.VisibleIndex = 9
                GridColumn93.VisibleIndex = 10

                GridControl10.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_CreditInvestigationApproval('{0}','{1}')", If(Multiple_ID = "", Branch_ID, Multiple_ID), If(User_Type = "ADMIN" Or ComparePosition({"REGIONAL MANAGER", "BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False), "", User_Code)))
            End If
            If GridView10.RowCount > 11 Then
                GridColumn89.Width = 287 - 17
            Else
                GridColumn89.Width = 287
            End If
            If GridView10.RowCount > 0 Then
                tabCI.Text = String.Format("[{0}] {1}", GridView10.RowCount, CI)
            Else
                tabCI.Text = CI
            End If
            '******** C R E D I T   T O T A L ************
            If GridView1.RowCount + GridView10.RowCount + GridView11.RowCount + GridView12.RowCount + GridView13.RowCount + GridView14.RowCount > 0 Then
                tabLoanManagement.Text = String.Format("[{0}] Loans Management", GridView1.RowCount + GridView10.RowCount + GridView11.RowCount + GridView12.RowCount + GridView13.RowCount + GridView14.RowCount)
            Else
                tabLoanManagement.Text = "Loans Management"
            End If
            '******** C R E D I T   T O T A L ************
            With GridView10.Columns("Borrower").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadRequest()
        Try
            If ComparePosition({"LOANS PROCESSOR", "CLIENT SOLUTIONS SPECIALIST"}, False) Or User_Type = "ADMIN" Then
                GridControl11.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_CreditRequest('{0}')", If(Multiple_ID = "", Branch_ID, Multiple_ID)))

                If GridView11.RowCount > 0 Then
                    tabRequest.Text = String.Format("[{0}] For Payment Request", GridView11.RowCount)
                Else
                    tabRequest.Text = "For Payment Request"
                End If
            End If
            If GridView11.RowCount > 11 Then
                GridColumn104.Width = 307 - 17
            Else
                GridColumn104.Width = 307
            End If
            '******** C R E D I T   T O T A L ************
            If GridView1.RowCount + GridView10.RowCount + GridView11.RowCount + GridView12.RowCount + GridView13.RowCount + GridView14.RowCount > 0 Then
                tabLoanManagement.Text = String.Format("[{0}] Loans Management", GridView1.RowCount + GridView10.RowCount + GridView11.RowCount + GridView12.RowCount + GridView13.RowCount + GridView14.RowCount)
            Else
                tabLoanManagement.Text = "Loans Management"
            End If
            '******** C R E D I T   T O T A L ************
            With GridView11.Columns("Borrower").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadRelease()
        Try
            GridControl12.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_CreditReleased('{0}')", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            If GridView12.RowCount > 11 Then
                GridColumn114.Width = 307 - 17
            Else
                GridColumn114.Width = 307
            End If

            If GridView12.RowCount > 0 Then
                tabRelease.Text = String.Format("[{0}] For Payment Release", GridView12.RowCount)
            Else
                tabRelease.Text = "For Payment Release"
            End If
            '******** C R E D I T   T O T A L ************
            If GridView1.RowCount + GridView10.RowCount + GridView11.RowCount + GridView12.RowCount + GridView13.RowCount + GridView14.RowCount > 0 Then
                tabLoanManagement.Text = String.Format("[{0}] Loans Management", GridView1.RowCount + GridView10.RowCount + GridView11.RowCount + GridView12.RowCount + GridView13.RowCount + GridView14.RowCount)
            Else
                tabLoanManagement.Text = "Loans Management"
            End If
            '******** C R E D I T   T O T A L ************
            With GridView12.Columns("Borrower").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadCollection()
        Try
            GridControl13.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_CreditCollection('{0}')", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            If GridView13.RowCount > 11 Then
                GridColumn126.Width = 260 - 17
            Else
                GridColumn126.Width = 260
            End If

            If GridView13.RowCount > 0 Then
                tabForCollection.Text = String.Format("[{0}] Due Checks", GridView13.RowCount)
            Else
                tabForCollection.Text = "Due Checks"
            End If
            '******** C R E D I T   T O T A L ************
            If GridView1.RowCount + GridView10.RowCount + GridView11.RowCount + GridView12.RowCount + GridView13.RowCount + GridView14.RowCount > 0 Then
                tabLoanManagement.Text = String.Format("[{0}] Loans Management", GridView1.RowCount + GridView10.RowCount + GridView11.RowCount + GridView12.RowCount + GridView13.RowCount + GridView14.RowCount)
            Else
                tabLoanManagement.Text = "Loans Management"
            End If
            '******** C R E D I T   T O T A L ************
            With GridView13.Columns("Payee").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadPosting()
        Try
            GridControl14.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_CreditPosting('{0}')", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            If GridView14.RowCount > 11 Then
                GridColumn135.Width = 301 - 17
            Else
                GridColumn135.Width = 301
            End If

            If GridView14.RowCount > 0 Then
                tabForPosting.Text = String.Format("[{0}] For Posting", GridView14.RowCount)
            Else
                tabForPosting.Text = "For Posting"
            End If
            '******** C R E D I T   T O T A L ************
            If GridView1.RowCount + GridView10.RowCount + GridView11.RowCount + GridView12.RowCount + GridView13.RowCount + GridView14.RowCount > 0 Then
                tabLoanManagement.Text = String.Format("[{0}] Loans Management", GridView1.RowCount + GridView10.RowCount + GridView11.RowCount + GridView12.RowCount + GridView13.RowCount + GridView14.RowCount)
            Else
                tabLoanManagement.Text = "Loans Management"
            End If
            '******** C R E D I T   T O T A L ************
            With GridView14.Columns("Payee").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadROPOAVerification()
        Try
            GridControl3.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_ROPAVerification('{0}')", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            If GridView3.RowCount > 11 Then
                GridColumn28.Width = 352 - 17
            Else
                GridColumn28.Width = 352
            End If

            If GridView3.RowCount > 0 Then
                tabROPOA_Verification.Text = String.Format("[{0}] For Verification", GridView3.RowCount)
            Else
                tabROPOA_Verification.Text = "For Verification"
            End If
            '******** R O P O A   T O T A L ************
            If GridView3.RowCount + GridView4.RowCount + GridView5.RowCount + GridView6.RowCount + GridView7.RowCount > 0 Then
                tabROPOA_Approval.Text = String.Format("[{0}] Asset Management", GridView3.RowCount + GridView4.RowCount + GridView5.RowCount + GridView6.RowCount + GridView7.RowCount)
            Else
                tabROPOA_Approval.Text = "Asset Management"
            End If
            '******** R O P O A   T O T A L ************
            With GridView3.Columns("Description").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadROPOAConsolidation()
        Try
            GridControl4.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_ROPAConsolidation('{0}',{1})", If(Multiple_ID = "", Branch_ID, Multiple_ID), RedemptionMonth))
            If GridView4.RowCount > 11 Then
                GridColumn37.Width = 285 - 17
            Else
                GridColumn37.Width = 285
            End If

            If GridView4.RowCount > 0 Then
                tabROPOA_Consolidation.Text = String.Format("[{0}] For Consolidation", GridView4.RowCount)
            Else
                tabROPOA_Consolidation.Text = "For Consolidation"
            End If
            '******** R O P O A   T O T A L ************
            If GridView3.RowCount + GridView4.RowCount + GridView5.RowCount + GridView6.RowCount + GridView7.RowCount > 0 Then
                tabROPOA_Approval.Text = String.Format("[{0}] Asset Management", GridView3.RowCount + GridView4.RowCount + GridView5.RowCount + GridView6.RowCount + GridView7.RowCount)
            Else
                tabROPOA_Approval.Text = "Asset Management"
            End If
            '******** R O P O A   T O T A L ************
            With GridView4.Columns("Description").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadROPOAImpairment()
        Try
            GridControl5.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_ROPAImpairment('{0}')", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            If GridView5.RowCount > 10 Then
                GridColumn43.Width = 267 - 17
            Else
                GridColumn43.Width = 267
            End If

            If GridView5.RowCount > 0 Then
                tabROPOA_ImpairmentII.Text = String.Format("[{0}] ROPOA for Impairment", GridView5.RowCount)
            Else
                tabROPOA_ImpairmentII.Text = "ROPOA for Impairment"
            End If
            If GridView5.RowCount + GridView7.RowCount > 0 Then
                tabROPOA_Impairment.Text = String.Format("[{0}] For Impairment", GridView5.RowCount + GridView7.RowCount)
            Else
                tabROPOA_Impairment.Text = "For Impairment"
            End If
            '******** R O P O A   T O T A L ************
            If GridView3.RowCount + GridView4.RowCount + GridView5.RowCount + GridView6.RowCount + GridView7.RowCount > 0 Then
                tabROPOA_Approval.Text = String.Format("[{0}] Asset Management", GridView3.RowCount + GridView4.RowCount + GridView5.RowCount + GridView6.RowCount + GridView7.RowCount)
            Else
                tabROPOA_Approval.Text = "Asset Management"
            End If
            '******** R O P O A   T O T A L ************
            With GridView5.Columns("Description").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadImpairmentDue()
        Try
            GridControl7.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_ROPAImpairmentDue('{0}')", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            If GridView7.RowCount > 10 Then
                GridColumn62.Width = 487 - 17
            Else
                GridColumn62.Width = 487
            End If

            If GridView7.RowCount > 0 Then
                tabImpairmentDue.Text = String.Format("[{0}] Impairment Due", GridView7.RowCount)
            Else
                tabImpairmentDue.Text = "Impairment Due"
            End If
            If GridView5.RowCount + GridView7.RowCount > 0 Then
                tabROPOA_Impairment.Text = String.Format("[{0}] For Impairment", GridView5.RowCount + GridView7.RowCount)
            Else
                tabROPOA_Impairment.Text = "For Impairment"
            End If
            '******** R O P O A   T O T A L ************
            If GridView3.RowCount + GridView4.RowCount + GridView5.RowCount + GridView6.RowCount + GridView7.RowCount > 0 Then
                tabROPOA_Approval.Text = String.Format("[{0}] Asset Management", GridView3.RowCount + GridView4.RowCount + GridView5.RowCount + GridView6.RowCount + GridView7.RowCount)
            Else
                tabROPOA_Approval.Text = "Asset Management"
            End If
            '******** R O P O A   T O T A L ************
            With GridView7.Columns("TCT / Plate Number").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadExpiredReservation()
        Try
            GridControl6.DataSource = DataSourceAlertNotification("CALL AlertNotification_ExpiredReservation()")
            If GridView6.RowCount > 11 Then
                GridColumn50.Width = 237 - 17
            Else
                GridColumn50.Width = 237
            End If

            If GridView6.RowCount > 0 Then
                For x As Integer = 0 To GridView6.RowCount - 1
                    'POLICY : 30 Days limit then auto forfeit ang reservation.
                    If DateValue(GridView6.GetRowCellValue(x, "Posting Date").ToString).AddDays(30) <= Date.Now Then
                        Dim SQL_II As String = String.Format("UPDATE sold_ropoa SET `status` = 'FORFEITED' WHERE AssetNumber = '{0}' AND ID = '{1}';", GridView6.GetRowCellValue(x, "Asset Number"), GridView6.GetRowCellValue(x, "ID"))
                        If GridView6.GetRowCellValue(x, "Type") = "Vehicle" Then
                            SQL_II &= String.Format(" UPDATE ropoa_vehicle SET sell_status = 'SELL' WHERE AssetNumber = '{0}';", GridView6.GetRowCellValue(x, "Asset Number"))
                            DataObject(SQL_II)
                            With FrmVehicleROPOA
                                .iFrom.Value = 0
                                .iTo.Value = 0
                                .Clear()
                                .btnNext_2.Enabled = False
                                .btnBack_2.Enabled = False
                                .LoadData()
                                .LoadReserved()
                            End With
                            Logs("Alert Notification", "Auto Forfeit", String.Format("Auto Forfeit of transaction for Vehicle ROPOA {0} under OR Number {1}", GridView6.GetRowCellValue(x, "Asset Number"), GridView6.GetRowCellValue(x, "Document Number")), "", "", "", "")
                            With FrmMain
                                .VehicleCount = .VehicleCount + 1
                                .VehicleCount_Sold = .VehicleCount_Sold - 1
                            End With
                        Else
                            SQL_II &= String.Format(" UPDATE ropoa_realestate SET sell_status = 'SELL' WHERE AssetNumber = '{0}';", GridView6.GetRowCellValue(x, "Asset Number"))
                            DataObject(SQL_II)
                            With FrmRealEstateROPOA
                                .iFrom.Value = 0
                                .iTo.Value = 0
                                .Clear()
                                .btnNext_2.Enabled = False
                                .btnBack_2.Enabled = False
                                .LoadData()
                                .LoadReserved()
                            End With
                            Logs("Alert Notification", "Auto Forfeit", String.Format("Auto Forfeit of transaction for Real Estate ROPOA {0} under OR Number {1}", GridView6.GetRowCellValue(x, "Asset Number"), GridView6.GetRowCellValue(x, "Document Number")), "", "", "", "")
                            With FrmMain
                                .RealEstateCount = .RealEstateCount + 1
                                .RealEstateCount_Sold = .RealEstateCount_Sold - 1
                            End With
                        End If
                        Dim senderT As New Object
                        Dim eT As New EventArgs
                        FrmAssetDashboard.FrmAssetDashboard_Load(senderT, eT)
                    End If
                Next
                tabExpiredReservation.Text = String.Format("[{0}] Expired Reservation", GridView6.RowCount)
            Else
                tabExpiredReservation.Text = "Expired Reservation"
            End If
            '******** R O P O A   T O T A L ************
            If GridView3.RowCount + GridView4.RowCount + GridView5.RowCount + GridView6.RowCount + GridView7.RowCount > 0 Then
                tabROPOA_Approval.Text = String.Format("[{0}] Asset Management", GridView3.RowCount + GridView4.RowCount + GridView5.RowCount + GridView6.RowCount + GridView7.RowCount)
            Else
                tabROPOA_Approval.Text = "Asset Management"
            End If
            '******** R O P O A   T O T A L ************
            With GridView6.Columns("Buyer").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadSMS()
        Try
            GridControl9.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_SMS('{0}')", User_Code))
            If GridView9.RowCount > 11 Then
                GridColumn81.Width = 810 - 17
            Else
                GridColumn81.Width = 810
            End If

            If GridView9.RowCount > 0 Then
                tabSMS_Alert.Text = String.Format("[{0}] SMS Alert", GridView9.RowCount)
            Else
                tabSMS_Alert.Text = "SMS Alert"
            End If
            '******** N O N L O A N S   T O T A L ************
            If GridView9.RowCount + GridView15.RowCount + GridView16.RowCount + GridView17.RowCount + GridView18.RowCount + GridView22.RowCount > 0 Then
                tabNonLoans.Text = String.Format("[{0}] Non Loans Related", GridView9.RowCount + GridView15.RowCount + GridView16.RowCount + GridView17.RowCount + GridView18.RowCount + GridView22.RowCount)
            Else
                tabNonLoans.Text = "Non Loans Related"
            End If
            '******** N O N L O A N S   T O T A L ************
            With GridView9.Columns("Message").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadEmail()
        Try
            GridControl17.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_Email({0},'{1}')", Empl_ID, User_Type))
            If GridView17.RowCount > 13 Then
                GridColumn171.Width = 376 - 17
            Else
                GridColumn171.Width = 376
            End If

            If GridView17.RowCount > 0 Then
                tabEmailOutbox.Text = String.Format("[{0}] Email Outbox", GridView17.RowCount)
            Else
                tabEmailOutbox.Text = "Email Outbox"
            End If
            '******** N O N L O A N S   T O T A L ************
            If GridView9.RowCount + GridView15.RowCount + GridView16.RowCount + GridView17.RowCount + GridView18.RowCount + GridView22.RowCount > 0 Then
                tabNonLoans.Text = String.Format("[{0}] Non Loans Related", GridView9.RowCount + GridView15.RowCount + GridView16.RowCount + GridView17.RowCount + GridView18.RowCount + GridView22.RowCount)
            Else
                tabNonLoans.Text = "Non Loans Related"
            End If
            '******** N O N L O A N S   T O T A L ************
            With GridView17.Columns("Body").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadCashAdvance()
        Try
            GridControl15.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_CashAdvance('{0}','{1}')", If(Multiple_ID = "", Branch_ID, Multiple_ID), If(User_Type = "ADMIN" Or Head, "PENDING", "")))
            If GridView15.RowCount > 11 Then
                GridColumn153.Width = 487 - 17
            Else
                GridColumn153.Width = 487
            End If

            If GridView15.RowCount > 0 Then
                tabCashAdvance.Text = String.Format("[{0}] Cash Advance Slip", GridView15.RowCount)
            Else
                tabCashAdvance.Text = "Cash Advance Slip"
            End If
            '******** N O N L O A N S   T O T A L ************
            If GridView9.RowCount + GridView15.RowCount + GridView16.RowCount + GridView17.RowCount + GridView18.RowCount + GridView22.RowCount > 0 Then
                tabNonLoans.Text = String.Format("[{0}] Non Loans Related", GridView9.RowCount + GridView15.RowCount + GridView16.RowCount + GridView17.RowCount + GridView18.RowCount + GridView22.RowCount)
            Else
                tabNonLoans.Text = "Non Loans Related"
            End If
            '******** N O N L O A N S   T O T A L ************
            With GridView15.Columns("Payee").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadPettyCash()
        Try
            GridControl16.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_PettyCash('{0}','{1}')", If(Multiple_ID = "", Branch_ID, Multiple_ID), If(User_Type = "ADMIN" Or If(Branch_ID = 0, Head, ComparePosition({"REGIONAL MANAGER", "DISTRICT MANAGER", "BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False)), "PENDING", If(CompareDepartment({"FINANCE", "CREDIT AND COLLECTION", "ADMINISTRATIVE"}, False), "APPROVED", ""))))
            If GridView16.RowCount > 11 Then
                GridColumn158.Width = 487 - 17
            Else
                GridColumn158.Width = 487
            End If

            If GridView16.RowCount > 0 Then
                tabPettyCash.Text = String.Format("[{0}] Petty Cash Voucher", GridView16.RowCount)
            Else
                tabPettyCash.Text = "Petty Cash Voucher"
            End If
            '******** N O N L O A N S   T O T A L ************
            If GridView9.RowCount + GridView15.RowCount + GridView16.RowCount + GridView17.RowCount + GridView18.RowCount + GridView22.RowCount > 0 Then
                tabNonLoans.Text = String.Format("[{0}] Non Loans Related", GridView9.RowCount + GridView15.RowCount + GridView16.RowCount + GridView17.RowCount + GridView18.RowCount + GridView22.RowCount)
            Else
                tabNonLoans.Text = "Non Loans Related"
            End If
            '******** N O N L O A N S   T O T A L ************
            With GridView16.Columns("Payee").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadLiquidation()
        Try
            GridControl18.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_Liquidation({0},{1})", Branch_ID, If(CompareDepartment({"FINANCE"}, False) Or User_Type = "ADMIN" Or If(Branch_ID = 0, Head, ComparePosition({"REGIONAL MANAGER", "DISTRICT MANAGER", "BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False)), 0, Empl_ID)))
            If GridView18.RowCount > 11 Then
                GridColumn180.Width = 305 - 17
            Else
                GridColumn180.Width = 305
            End If

            If GridView18.RowCount > 0 Then
                tabForLiquidation.Text = String.Format("[{0}] For Liquidation", GridView18.RowCount)
            Else
                tabForLiquidation.Text = "For Liquidation"
            End If
            '******** N O N L O A N S   T O T A L ************
            If GridView9.RowCount + GridView15.RowCount + GridView16.RowCount + GridView17.RowCount + GridView18.RowCount + GridView22.RowCount > 0 Then
                tabNonLoans.Text = String.Format("[{0}] Non Loans Related", GridView9.RowCount + GridView15.RowCount + GridView16.RowCount + GridView17.RowCount + GridView18.RowCount + GridView22.RowCount)
            Else
                tabNonLoans.Text = "Non Loans Related"
            End If
            '******** N O N L O A N S   T O T A L ************
            With GridView18.Columns("Employee").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadITLMonitoring()
        Try
            GridControl22.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_ITLMonitoring({0})", Branch_ID))
            If GridView22.RowCount > 11 Then
                GridColumn206.Width = 256 - 17
            Else
                GridColumn206.Width = 256
            End If

            If GridView22.RowCount > 0 Then
                tabITLMonitoring.Text = String.Format("[{0}] ITL Monitoring", GridView22.RowCount)
            Else
                tabITLMonitoring.Text = "ITL Monitoring"
            End If
            '******** N O N L O A N S   T O T A L ************
            If GridView9.RowCount + GridView15.RowCount + GridView16.RowCount + GridView17.RowCount + GridView18.RowCount + GridView22.RowCount > 0 Then
                tabNonLoans.Text = String.Format("[{0}] Non Loans Related", GridView9.RowCount + GridView15.RowCount + GridView16.RowCount + GridView17.RowCount + GridView18.RowCount + GridView22.RowCount)
            Else
                tabNonLoans.Text = "Non Loans Related"
            End If
            '******** N O N L O A N S   T O T A L ************
            With GridView22.Columns("Defendant").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadAcknowledgement()
        Try
            GridControl19.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_Acknowledgement({0})", Branch_ID))
            If GridView19.RowCount > 11 Then
                GridColumn186.Width = 236 - 17
            Else
                GridColumn186.Width = 236
            End If

            If GridView19.RowCount > 0 Then
                tabForAcknowledgement.Text = String.Format("[{0}] Acknowledgement", GridView19.RowCount)
            Else
                tabForAcknowledgement.Text = "Acknowledgement"
            End If
            '******** F I N A N C I A L   T O T A L ************
            If GridView19.RowCount + GridView20.RowCount + GridView23.RowCount + GridView21.RowCount + GridView24.RowCount > 0 Then
                tabFinancial.Text = String.Format("[{0}] Financial Management", GridView19.RowCount + GridView20.RowCount + GridView23.RowCount + GridView21.RowCount + GridView24.RowCount)
            Else
                tabFinancial.Text = "Financial Management"
            End If
            '******** F I N A N C I A L   T O T A L ************
            With GridView19.Columns("Payee").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
            CancelBW()
        End Try
    End Sub

    Private Sub LoadForCV()
        Try
            GridControl20.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_CheckVoucher({0})", Branch_ID))
            If GridView20.RowCount > 11 Then
                GridColumn193.Width = 436 - 17
            Else
                GridColumn193.Width = 436
            End If

            If GridView20.RowCount > 0 Then
                tabForCV.Text = String.Format("[{0}] For Check Voucher", GridView20.RowCount)
            Else
                tabForCV.Text = "For Check Voucher"
            End If
            '******** F I N A N C I A L   T O T A L ************
            If GridView19.RowCount + GridView20.RowCount + GridView23.RowCount + GridView21.RowCount + GridView24.RowCount > 0 Then
                tabFinancial.Text = String.Format("[{0}] Financial Management", GridView19.RowCount + GridView20.RowCount + GridView23.RowCount + GridView21.RowCount + GridView24.RowCount)
            Else
                tabFinancial.Text = "Financial Management"
            End If
            '******** F I N A N C I A L   T O T A L ************
            With GridView20.Columns("Payee").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadForJV()
        Try
            GridControl23.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_JournalVoucher({0})", Branch_ID))
            If GridView23.RowCount > 11 Then
                GridColumn214.Width = 386 - 17
            Else
                GridColumn214.Width = 386
            End If

            If GridView23.RowCount > 0 Then
                tabForJV.Text = String.Format("[{0}] For Journal Voucher (Liquidation)", GridView23.RowCount)
            Else
                tabForJV.Text = "For Journal Voucher (Liquidation)"
            End If
            '******** F I N A N C I A L   T O T A L ************
            If GridView19.RowCount + GridView20.RowCount + GridView23.RowCount + GridView21.RowCount + GridView24.RowCount > 0 Then
                tabFinancial.Text = String.Format("[{0}] Financial Management", GridView19.RowCount + GridView20.RowCount + GridView23.RowCount + GridView21.RowCount + GridView24.RowCount)
            Else
                tabFinancial.Text = "Financial Management"
            End If
            '******** F I N A N C I A L   T O T A L ************
            With GridView23.Columns("Payee").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadForRollOver()
        Try
            GridControl21.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_RollOver({0})", Branch_ID))
            If GridView21.RowCount > 11 Then
                GridColumn200.Width = 396 - 17
            Else
                GridColumn200.Width = 396
            End If

            If GridView21.RowCount > 0 Then
                tabForRollOver.Text = String.Format("[{0}] For Roll Over", GridView21.RowCount)
            Else
                tabForRollOver.Text = "For Roll Over"
            End If
            '******** F I N A N C I A L   T O T A L ************
            If GridView19.RowCount + GridView20.RowCount + GridView23.RowCount + GridView21.RowCount + GridView24.RowCount > 0 Then
                tabFinancial.Text = String.Format("[{0}] Financial Management", GridView19.RowCount + GridView20.RowCount + GridView23.RowCount + GridView21.RowCount + GridView24.RowCount)
            Else
                tabFinancial.Text = "Financial Management"
            End If
            '******** F I N A N C I A L   T O T A L ************
            With GridView21.Columns("Payor").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadPromise()
        Try
            GridControl24.DataSource = DataSourceAlertNotification(String.Format("CALL AlertNotification_Promise({0})", Branch_ID))
            If GridView24.RowCount > 11 Then
                GridColumn230.Width = 446 - 17
            Else
                GridColumn230.Width = 446
            End If

            If GridView24.RowCount > 0 Then
                tabPromise.Text = String.Format("[{0}] Promise to Pay", GridView24.RowCount)
            Else
                tabPromise.Text = "Promise to Pay"
            End If
            '******** F I N A N C I A L   T O T A L ************
            If GridView19.RowCount + GridView20.RowCount + GridView23.RowCount + GridView21.RowCount + GridView24.RowCount > 0 Then
                tabFinancial.Text = String.Format("[{0}] Financial Management", GridView19.RowCount + GridView20.RowCount + GridView23.RowCount + GridView21.RowCount + GridView24.RowCount)
            Else
                tabFinancial.Text = "Financial Management"
            End If
            '******** F I N A N C I A L   T O T A L ************
            With GridView24.Columns("Borrower").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        CancelBW()
        Close()
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.C Then
            btnCheck.Focus()
            btnCheck.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            btnConsolidate.Focus()
            btnConsolidate.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.V Then
            btnVerify.Focus()
            btnVerify.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.E Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnForfeit.Focus()
            btnForfeit.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If btnCancel.Enabled = False Then
            Exit Sub
        End If

        If SuperTabControl1.SelectedTabIndex = 0 Then
            LoadData()
        ElseIf SuperTabControl1.SelectedTabIndex = 1 And SuperTabControl3.SelectedTabIndex = 0 Then
            LoadROPOAVerification()
        ElseIf SuperTabControl1.SelectedTabIndex = 1 And SuperTabControl3.SelectedTabIndex = 1 Then
            LoadROPOAConsolidation()
        ElseIf SuperTabControl1.SelectedTabIndex = 1 And SuperTabControl3.SelectedTabIndex = 2 Then
            If SuperTabControl2.SelectedTabIndex = 1 Then
                LoadROPOAImpairment()
            ElseIf SuperTabControl2.SelectedTabIndex = 2 Then
                LoadImpairmentDue()
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 And SuperTabControl3.SelectedTabIndex = 3 Then
            LoadExpiredReservation()
        ElseIf SuperTabControl1.SelectedTabIndex = 2 And SuperTabControl5.SelectedTabIndex = 0 Then
            LoadSMS()
        ElseIf SuperTabControl1.SelectedTabIndex = 2 And SuperTabControl5.SelectedTabIndex = 1 Then
            LoadEmail()
        ElseIf SuperTabControl1.SelectedTabIndex = 2 And SuperTabControl5.SelectedTabIndex = 2 Then
            LoadCashAdvance()
        ElseIf SuperTabControl1.SelectedTabIndex = 2 And SuperTabControl5.SelectedTabIndex = 3 Then
            LoadPettyCash()
        ElseIf SuperTabControl1.SelectedTabIndex = 2 And SuperTabControl5.SelectedTabIndex = 4 Then
            LoadLiquidation()
        ElseIf SuperTabControl1.SelectedTabIndex = 2 And SuperTabControl5.SelectedTabIndex = 5 Then
            LoadITLMonitoring()
        ElseIf SuperTabControl1.SelectedTabIndex = 3 And SuperTabControl6.SelectedTabIndex = 0 Then
            LoadAcknowledgement()
        ElseIf SuperTabControl1.SelectedTabIndex = 3 And SuperTabControl6.SelectedTabIndex = 1 Then
            LoadForCV()
        ElseIf SuperTabControl1.SelectedTabIndex = 3 And SuperTabControl6.SelectedTabIndex = 2 Then
            LoadForJV()
        ElseIf SuperTabControl1.SelectedTabIndex = 3 And SuperTabControl6.SelectedTabIndex = 3 Then
            LoadForRollOver()
        ElseIf SuperTabControl1.SelectedTabIndex = 3 And SuperTabControl6.SelectedTabIndex = 4 Then
            LoadPromise()
        End If
    End Sub

    Private Sub BtnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        If btnCheck.Visible = False Or btnCancel.Enabled = False Then
            Exit Sub
        End If

        If SuperTabControl1.SelectedTabIndex = 0 Then
            If SuperTabControl4.SelectedTabIndex = 0 Then
                'Credit Application
                Try
                    If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                If FrmMain.lblDate.Text.Contains("Disconnected") Then
                    MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                With FrmLoanApplication
                    .Tag = 18
                    FormRestriction(.Tag)
                    If allow_Access Then
                        .vSave = allow_Save
                        .vUpdate = allow_Update
                        .vDelete = allow_Delete
                        .vPrint = allow_Print
                    Else
                        MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If

                    Logs("Alert Notification", "Open", "Loan Application", "", "", "", "")
                    .lblTitle.Text = "CREDIT APPLICATION"
                    .tabBorrower.Visible = True
                    .tabFinancial_1.Visible = True
                    .tabFinancial_2.Visible = True
                    .tabRequirements.Visible = True
                    .tabList.Visible = True
                    .SuperTabControl1.SelectedTab = .tabList
                    .btnBack.Visible = True
                    .btnNext.Visible = True
                    .btnSave.Visible = True
                    .btnRefresh.Visible = True
                    .btnAttach.Visible = True
                    .btnSave_F.Visible = True
                    .btnModify.Visible = True
                    .btnDelete.Visible = True
                    .btnApprove.Visible = True
                    .btnBack.Location = New Point(2, 4)
                    .btnNext.Location = New Point(88, 4)
                    .btnSave.Location = New Point(174, 4)
                    .btnSave_F.Location = New Point(260, 4)
                    .btnRefresh.Location = New Point(346, 4)
                    .btnCancel.Location = New Point(432, 4)
                    .btnModify.Location = New Point(518, 4)
                    .btnDelete.Location = New Point(604, 4)
                    .btnAttach.Location = New Point(690, 4)
                    .btnPrint.Location = New Point(776, 4)
                    .btnPrint_II.Location = New Point(862, 4)
                    .btnEarly.Location = New Point(958, 4)
                    .btnApprove.Location = New Point(1054, 4)
                    Forms(FrmLoanApplication, FrmMain.PanelControl3)

                    .cbxAll.Checked = True
                    '.cbxDraft.Checked = True
                    '.cbxPending.Checked = True
                    '.cbxApproved.Checked = True
                    '.cbxDisapproved.Checked = True
                    If GridView1.GetFocusedRowCellValue("Purpose").ToString.Contains("[Assign]") Then
                        .cbxCI.Checked = True
                    End If
                    .LoadData()
                    Dim i As Integer = 0
                    For x As Integer = 0 To .GridView5.RowCount - 1
                        If .GridView5.GetRowCellValue(x, "Credit Number") = GridView1.GetFocusedRowCellValue("Credit Number") Then
                            i = x
                            Exit For
                        End If
                    Next
                    .GridView5.OptionsSelection.MultiSelect = False
                    .GridView5.FocusedRowHandle = i
                    .GridView5_DoubleClick(sender, e)
                End With
                CancelBW()
                Close()
            ElseIf SuperTabControl4.SelectedTabIndex = 1 Then
                'Credit Investigation
                Try
                    If GridView10.GetFocusedRowCellValue("ID").ToString = "" Or GridView10.RowCount = 0 Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                If FrmMain.lblDate.Text.Contains("Disconnected") Then
                    MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                With FrmCreditInvestigation
                    .Tag = 19
                    FormRestriction(.Tag)
                    If allow_Access Then
                        .vSave = allow_Save
                        .vUpdate = allow_Update
                        .vDelete = allow_Delete
                        .vPrint = allow_Print
                    Else
                        MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If

                    Logs("Alert Notification", "Open", "Credit Investigation", "", "", "", "")
                    Forms(FrmCreditInvestigation, FrmMain.PanelControl3)

                    If tabCI.Text.Contains("For") Then
                        '*** FOR CREDIT INVESTIGATOR
                        .SuperTabControl1.SelectedTabIndex = 0
                        .Clear()
                        .cbxApplication.SelectedValue = GridView10.GetFocusedRowCellValue("Credit Number")

                    Else
                        '*** FOR CREDIT INVESTIGATION APPROVAL
                        .cbxAll.Checked = True
                        .LoadData()
                        Dim i As Integer = 0
                        For x As Integer = 0 To .GridView5.RowCount - 1
                            If .GridView5.GetRowCellValue(x, "CI Number") = GridView10.GetFocusedRowCellValue("CI Number") Then
                                i = x
                                Exit For
                            End If
                        Next
                        .GridView5.OptionsSelection.MultiSelect = False
                        .GridView5.FocusedRowHandle = i
                        .GridView5_DoubleClick(sender, e)
                    End If
                    CancelBW()
                    Close()
                End With
            ElseIf SuperTabControl4.SelectedTabIndex = 2 Then
                'Payment Request
                Try
                    If GridView11.GetFocusedRowCellValue("ID").ToString = "" Or GridView11.RowCount = 0 Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                If FrmMain.lblDate.Text.Contains("Disconnected") Then
                    MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                With FrmPaymentRequest
                    .Tag = 20
                    FormRestriction(.Tag)
                    If allow_Access Then
                        .vSave = allow_Save
                        .vUpdate = allow_Update
                        .vDelete = allow_Delete
                        .vPrint = allow_Print
                    Else
                        MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If

                    Logs("Alert Notification", "Open", "Payment Request", "", "", "", "")
                    Forms(FrmPaymentRequest, FrmMain.PanelControl3)

                    .SuperTabControl1.SelectedTabIndex = 0
                    Hide()
                    If tabRequest.Text.Contains("For Payment Request") Then
                        'FOR PAYMENT REQUEST
                        .cbxApplication.SelectedValue = GridView11.GetFocusedRowCellValue("Credit Number")
                    ElseIf tabRequest.Text.Contains("Check Payment Request") Or tabRequest.Text.Contains("Approve Payment Request") Then
                        'FOR CHECK OR APPROVED PAYMENT REQUEST
                        .cbxAll.Checked = True
                        .LoadData()
                        Dim i As Integer = 0
                        For x As Integer = 0 To .GridView1.RowCount - 1
                            If .GridView1.GetRowCellValue(x, "Credit Number") = GridView11.GetFocusedRowCellValue("Credit Number") Then
                                i = x
                                Exit For
                            End If
                        Next
                        .GridView1.OptionsSelection.MultiSelect = False
                        .GridView1.FocusedRowHandle = i
                        .GridView1_DoubleClick(sender, e)
                        '.btnModify.PerformClick()
                        'Modify Mode
                        If .btnCheck.Enabled Then
                            If CompareDepartment({"FINANCE"}, False) Then
                                .btnSave.Enabled = False
                            Else
                                .btnSave.Enabled = True
                            End If
                        End If
                        .GridView2.OptionsBehavior.Editable = True
                        .btnModify.Enabled = False
                        .btnDelete.Enabled = True
                        .PanelEx10.Enabled = True
                    End If
                End With
                CancelBW()
                Close()
            ElseIf SuperTabControl4.SelectedTabIndex = 3 Then
                'Payment Release
                Try
                    If GridView12.GetFocusedRowCellValue("ID").ToString = "" Or GridView12.RowCount = 0 Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                If FrmMain.lblDate.Text.Contains("Disconnected") Then
                    MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                With FrmPaymentRelease
                    .Tag = 21
                    FormRestriction(.Tag)
                    If allow_Access Then
                        .vSave = allow_Save
                        .vUpdate = allow_Update
                        .vDelete = allow_Delete
                        .vPrint = allow_Print
                    Else
                        MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If

                    Logs("Alert Notification", "Open", "Payment Release", "", "", "", "")
                    Forms(FrmPaymentRelease, FrmMain.PanelControl3)

                    .SuperTabControl1.SelectedTabIndex = 0
                    .cbxApplication.SelectedValue = GridView12.GetFocusedRowCellValue("Credit Number")
                End With
                CancelBW()
                Close()
            ElseIf SuperTabControl4.SelectedTabIndex = 4 Then
                'Check Due
                Try
                    If GridView13.GetFocusedRowCellValue("ID").ToString = "" Or GridView13.RowCount = 0 Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                If FrmMain.lblDate.Text.Contains("Disconnected") Then
                    MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                With FrmPDCManagement
                    .Tag = 22
                    FormRestriction(.Tag)
                    If allow_Access Then
                        .vSave = allow_Save
                        .vUpdate = allow_Update
                        .vDelete = allow_Delete
                        .vPrint = allow_Print
                    Else
                        MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If

                    Logs("Alert Notification", "Open", "PDC Management", "", "", "", "")
                    Forms(FrmPDCManagement, FrmMain.PanelControl3)

                    If GridView13.GetFocusedRowCellValue("Check From") = "CREDIT" Then
                        .LoadApplication()
                        .SuperTabControl1.SelectedTabIndex = 0
                        .cbxApplication.SelectedValue = GridView13.GetFocusedRowCellValue("Reference Number")
                        Dim i As Integer = 0
                        For x As Integer = 0 To .GridView3.RowCount - 1
                            If .GridView3.GetRowCellValue(x, "Check No") = GridView13.GetFocusedRowCellValue("Check Number") Then
                                i = x
                                Exit For
                            End If
                        Next
                        .GridView3.OptionsSelection.MultiSelect = False
                        .GridView3.FocusedRowHandle = i
                    ElseIf GridView13.GetFocusedRowCellValue("Check From") = "DUE FROM" Then
                        .LoadDueFrom()
                        .SuperTabControl1.SelectedTabIndex = 2
                        .cbxPayor.SelectedValue = GridView13.GetFocusedRowCellValue("ID")
                        Dim i As Integer = 0
                        For x As Integer = 0 To .GridView2.RowCount - 1
                            If .GridView2.GetRowCellValue(x, "Check No") = GridView13.GetFocusedRowCellValue("Check Number") Then
                                i = x
                                Exit For
                            End If
                        Next
                        .GridView2.OptionsSelection.MultiSelect = False
                        .GridView2.FocusedRowHandle = i
                    ElseIf GridView13.GetFocusedRowCellValue("Check From") = "DUE TO" Then
                        .LoadDueTo()
                        .SuperTabControl1.SelectedTabIndex = 3
                        .cbxPayee.SelectedValue = GridView13.GetFocusedRowCellValue("ID")
                        Dim i As Integer = 0
                        For x As Integer = 0 To .GridView5.RowCount - 1
                            If .GridView5.GetRowCellValue(x, "Check No") = GridView13.GetFocusedRowCellValue("Check Number") Then
                                i = x
                                Exit For
                            End If
                        Next
                        .GridView5.OptionsSelection.MultiSelect = False
                        .GridView5.FocusedRowHandle = i
                    ElseIf GridView13.GetFocusedRowCellValue("Check From") = "LOANS PAYABLE" Then
                        .LoadLoansPayable()
                        .SuperTabControl1.SelectedTabIndex = 4
                        .cbxPayeeV5.SelectedValue = GridView13.GetFocusedRowCellValue("ID")
                        Dim i As Integer = 0
                        For x As Integer = 0 To .GridView11.RowCount - 1
                            If .GridView11.GetRowCellValue(x, "Check No") = GridView13.GetFocusedRowCellValue("Check Number") Then
                                i = x
                                Exit For
                            End If
                        Next
                        .GridView11.OptionsSelection.MultiSelect = False
                        .GridView11.FocusedRowHandle = i
                    ElseIf GridView13.GetFocusedRowCellValue("Check From") = "OTHERS" Then
                        .LoadOthers()
                        .SuperTabControl1.SelectedTabIndex = 5
                        .cbxPayorOthers.SelectedValue = GridView13.GetFocusedRowCellValue("ID")
                        Dim i As Integer = 0
                        For x As Integer = 0 To .GridView7.RowCount - 1
                            If .GridView7.GetRowCellValue(x, "Check No") = GridView13.GetFocusedRowCellValue("Check Number") Then
                                i = x
                                Exit For
                            End If
                        Next
                        .GridView7.OptionsSelection.MultiSelect = False
                        .GridView7.FocusedRowHandle = i
                    Else
                        .LoadAsset()
                        .SuperTabControl1.SelectedTabIndex = 1
                        .cbxAssetNumber.Text = GridView13.GetFocusedRowCellValue("Reference Number") & " - " & GridView13.GetFocusedRowCellValue("Details")
                        Dim i As Integer = 0
                        For x As Integer = 0 To .GridView1.RowCount - 1
                            If .GridView1.GetRowCellValue(x, "Check No") = GridView13.GetFocusedRowCellValue("Check Number") Then
                                i = x
                                Exit For
                            End If
                        Next
                        .GridView1.OptionsSelection.MultiSelect = False
                        .GridView1.FocusedRowHandle = i
                    End If
                End With
                CancelBW()
                Close()
            ElseIf SuperTabControl4.SelectedTabIndex = 5 Then
                'Check Due
                Try
                    If GridView14.GetFocusedRowCellValue("ID").ToString = "" Or GridView14.RowCount = 0 Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                If FrmMain.lblDate.Text.Contains("Disconnected") Then
                    MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                With FrmSubsidiaryLedger
                    .Tag = 34
                    FormRestriction(.Tag)
                    If allow_Access Then
                        .vPrint = allow_Print
                    Else
                        MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If

                    Logs("Alert Notification", "Open", "Subsidiary Ledger", "", "", "", "")
                    Forms(FrmSubsidiaryLedger, FrmMain.PanelControl3)

                    .cbxBusinessCenter.Text = ""
                    .cbxAllBank.Checked = True
                    .cbxAll.Checked = True
                    .LoadData()
                    Dim i As Integer = 0
                    For x As Integer = 0 To .GridView1.RowCount - 1
                        If .GridView1.GetRowCellValue(x, "Credit Number") = GridView14.GetFocusedRowCellValue("Reference Number") Then
                            i = x
                            Exit For
                        End If
                    Next
                    .GridView1.OptionsSelection.MultiSelect = False
                    .GridView1.FocusedRowHandle = i
                    Hide()
                    .GridView1_DoubleClick(sender, e)
                    CancelBW()
                    Close()
                End With
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 And SuperTabControl3.SelectedTabIndex = 2 Then
            If SuperTabControl2.SelectedTabIndex = 0 Then
                '*****ROPOA for Impairment
                Try
                    If GridView5.GetFocusedRowCellValue("ID").ToString = "" Or GridView5.RowCount = 0 Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                If FrmMain.lblDate.Text.Contains("Disconnected") Then
                    MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                '****Vehicle
                If GridView5.GetFocusedRowCellValue("Type") = "Vehicle" Then
                    With FrmVehicleROPOA
                        .Tag = 38
                        FormRestriction(.Tag)
                        If allow_Access Then
                            .vSave = allow_Save
                            .vUpdate = allow_Update
                            .vDelete = allow_Delete
                            .vPrint = allow_Print
                        Else
                            MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                            Exit Sub
                        End If

                        Logs("Alert Notification", "Check", "Vehicle ROPOA", "", "", "", "")
                        Forms(FrmVehicleROPOA, FrmMain.PanelControl3)

                        Dim i As Integer = 0
                        For x As Integer = 0 To .GridView2.RowCount - 1
                            If .GridView2.GetRowCellValue(x, "Asset Number") = GridView5.GetFocusedRowCellValue("Asset Number") Then
                                i = x
                                Exit For
                            End If
                        Next
                        .GridView2.OptionsSelection.MultiSelect = False
                        .GridView2.FocusedRowHandle = i
                        .GridView2_DoubleClick(sender, e)
                        If ComparePosition({"BRANCH MANAGER"}, False) And GridView5.GetFocusedRowCellValue("BM_Check") = 0 Then
                            DataObject(String.Format("UPDATE ropoa_vehicle SET BM_Check = 1 WHERE AssetNumber = '{0}'", GridView5.GetFocusedRowCellValue("Asset Number")))
                            GridView5.SetFocusedRowCellValue("BM_Check", 1)
                        End If
                        Hide()
                        .btnHistory.PerformClick()
                        CancelBW()
                        Close()
                    End With
                ElseIf GridView5.GetFocusedRowCellValue("Type") = "Real Estate" Then
                    '**** REAL ESTATE
                    With FrmRealEstateROPOA
                        .Tag = 39
                        FormRestriction(.Tag)
                        If allow_Access Then
                            .vSave = allow_Save
                            .vUpdate = allow_Update
                            .vDelete = allow_Delete
                            .vPrint = allow_Print
                        Else
                            MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                            Exit Sub
                        End If

                        btnCheck.DialogResult = DialogResult.OK

                        Logs("Alert Notification", "Check", "Real Estate ROPOA", "", "", "", "")
                        Forms(FrmRealEstateROPOA, FrmMain.PanelControl3)

                        Dim i As Integer = 0
                        For x As Integer = 0 To .GridView2.RowCount - 1
                            If .GridView2.GetRowCellValue(x, "Asset Number") = GridView5.GetFocusedRowCellValue("Asset Number") Then
                                i = x
                                Exit For
                            End If
                        Next
                        .GridView2.OptionsSelection.MultiSelect = False
                        .GridView2.FocusedRowHandle = i
                        .GridView2_DoubleClick(sender, e)
                        If ComparePosition({"BRANCH MANAGER"}, False) And GridView5.GetFocusedRowCellValue("BM_Check") = 0 Then
                            DataObject(String.Format("UPDATE ropoa_realestate SET BM_Check = 1 WHERE AssetNumber = '{0}'", GridView5.GetFocusedRowCellValue("Asset Number")))
                            GridView5.SetFocusedRowCellValue("BM_Check", 1)
                        End If
                        Hide()
                        .btnHistory.PerformClick()
                        CancelBW()
                        Close()
                    End With
                End If
            Else
                Try
                    If GridView7.GetFocusedRowCellValue("ID").ToString = "" Or GridView7.RowCount = 0 Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
                '*********IMPAIRMENT DUE
                With FrmImpairmentManagement
                    .Tag = 58
                    FormRestriction(.Tag)
                    If allow_Access Then
                        .vSave = allow_Save
                        .vUpdate = allow_Update
                        .vDelete = allow_Delete
                        .vPrint = allow_Print
                    Else
                        MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If

                    Logs("Alert Notification", "Check", "Impairment Schedule", "", "", "", "")
                    Forms(FrmImpairmentManagement, FrmMain.PanelControl3)

                    .cbxROPOA.Text = GridView7.GetFocusedRowCellValue("Account No.") & " - " & GridView7.GetFocusedRowCellValue("TCT / Plate Number")
                    Dim i As Integer = 0
                    For x As Integer = 0 To .GridView1.RowCount - 1
                        If .GridView1.GetRowCellValue(x, "ID") = GridView7.GetFocusedRowCellValue("ID") Then
                            i = x
                            Exit For
                        End If
                    Next
                    .GridView1.OptionsSelection.MultiSelect = False
                    .GridView1.FocusedRowHandle = i
                    Hide()
                    .btnPost.PerformClick()
                    CancelBW()
                    Close()
                End With
            End If

        ElseIf SuperTabControl1.SelectedTabIndex = 2 And SuperTabControl5.SelectedTabIndex = 2 Then
            Try
                If GridView15.GetFocusedRowCellValue("ID").ToString = "" Or GridView15.RowCount = 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try
            '*************************** CASH ADVANCE SLIP
            With FrmCashAdvanceSlip
                .Tag = 78
                FormRestriction(.Tag)
                If allow_Access Then
                    .vSave = allow_Save
                    .vUpdate = allow_Update
                    .vDelete = allow_Delete
                    .vPrint = allow_Print
                Else
                    MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Logs("Alert Notification", "Check", "Cash Advance Slip", "", "", "", "")
                Forms(FrmCashAdvanceSlip, FrmMain.PanelControl3)

                .cbxAll.Checked = True
                .LoadData()
                Dim i As Integer = 0
                For x As Integer = 0 To .GridView1.RowCount - 1
                    If .GridView1.GetRowCellValue(x, "Account Number") = GridView15.GetFocusedRowCellValue("Account Number") Then
                        i = x
                        Exit For
                    End If
                Next
                .GridView1.OptionsSelection.MultiSelect = False
                .GridView1.FocusedRowHandle = i
                .GridView1_DoubleClick(sender, e)
                CancelBW()
                Close()
            End With
        ElseIf SuperTabControl1.SelectedTabIndex = 2 And SuperTabControl5.SelectedTabIndex = 3 Then
            Try
                If GridView16.GetFocusedRowCellValue("ID").ToString = "" Or GridView16.RowCount = 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try
            '*************************** PETTY CASH VOUCHER
            With FrmPettyCashVoucher
                .Tag = 79
                FormRestriction(.Tag)
                If allow_Access Then
                    .vSave = allow_Save
                    .vUpdate = allow_Update
                    .vDelete = allow_Delete
                    .vPrint = allow_Print
                Else
                    MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Logs("Alert Notification", "Check", "Petty Cash Setup", "", "", "", "")
                Forms(FrmPettyCashVoucher, FrmMain.PanelControl3)

                .cbxAll.Checked = True
                .LoadData()
                Dim i As Integer = 0
                For x As Integer = 0 To .GridView1.RowCount - 1
                    If .GridView1.GetRowCellValue(x, "Account Number") = GridView16.GetFocusedRowCellValue("Account Number") Then
                        i = x
                        Exit For
                    End If
                Next
                .GridView1.OptionsSelection.MultiSelect = False
                .GridView1.FocusedRowHandle = i
                .GridView1_DoubleClick(sender, e)
                CancelBW()
                Close()
            End With
            '****************************************************************** END PETTY CASH VOUCHER
        ElseIf SuperTabControl1.SelectedTabIndex = 2 And SuperTabControl5.SelectedTabIndex = 4 Then
            Try
                If GridView18.GetFocusedRowCellValue("ID").ToString = "" Or GridView18.RowCount = 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try
            '*************************** FOR LIQUIDATION
            With FrmLiquidation
                .Tag = 85
                FormRestriction(.Tag)
                If allow_Access Then
                    .vSave = allow_Save
                    .vUpdate = allow_Update
                    .vDelete = allow_Delete
                    .vPrint = allow_Print
                Else
                    MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Logs("Alert Notification", "Check", "Liquidation of Expenses", "", "", "", "")
                Forms(FrmLiquidation, FrmMain.PanelControl3)

                .btnAdd.PerformClick()
                'Change SelectedValue to .Text kay if naay new nga for liquidation ang unahon pag select kay ang old bisag new ang focus
                '.cbxPayee.SelectedValue = GridView18.GetFocusedRowCellValue("ID")
                .cbxPayee.Text = GridView18.GetFocusedRowCellValue("Employee") & " [" & GridView18.GetFocusedRowCellValue("AccountNumber") & "]"
                CancelBW()
                Close()
            End With
            '****************************************************************** END FOR LIQUIDATION
        ElseIf SuperTabControl1.SelectedTabIndex = 2 And SuperTabControl5.SelectedTabIndex = 5 Then
            Try
                If GridView22.GetFocusedRowCellValue("ID").ToString = "" Or GridView22.RowCount = 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try
            '*************************** FOR ITL Monitoring
            With FrmCaseSetup
                .Tag = 74
                FormRestriction(.Tag)
                If allow_Access Then
                    .vSave = allow_Save
                    .vUpdate = allow_Update
                    .vDelete = allow_Delete
                    .vPrint = allow_Print
                Else
                    MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Logs("Alert Notification", "Check", "Case Setup", "", "", "", "")
                Forms(FrmCaseSetup, FrmMain.PanelControl3)

                Dim i As Integer = 0
                .cbxAll.Checked = True
                .btnSearch.PerformClick()
                For x As Integer = 0 To .GridView1.RowCount - 1
                    If .GridView1.GetRowCellValue(x, "Account Number") = GridView22.GetFocusedRowCellValue("Account Number") Then
                        i = x
                        Exit For
                    End If
                Next
                .GridView1.OptionsSelection.MultiSelect = False
                .GridView1.FocusedRowHandle = i
                Hide()
                .btnDetailed.RaiseClick()
                CancelBW()
                Close()
            End With
            '****************************************************************** END FOR ITL MONITORING
        ElseIf SuperTabControl1.SelectedTabIndex = 3 And SuperTabControl6.SelectedTabIndex = 0 Then
            Try
                If GridView19.GetFocusedRowCellValue("ID").ToString = "" Or GridView19.RowCount = 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try
            '*************************** FOR ACKNOWLEDGEMENT
            With FrmAcknowledgement
                .Tag = 84
                FormRestriction(.Tag)
                If allow_Access Then
                    .vSave = allow_Save
                    .vUpdate = allow_Update
                    .vDelete = allow_Delete
                    .vPrint = allow_Print
                Else
                    MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Logs("Alert Notification", "Check", "Acknowledgement Receipt", "", "", "", "")
                Forms(FrmAcknowledgement, FrmMain.PanelControl3)

                .btnAdd.PerformClick()
                .FirstLoad = True
                If GridView19.GetFocusedRowCellValue("Document Number").ToString.Contains("LOE") Then
                    .cbxLOE.Checked = True
                ElseIf GridView19.GetFocusedRowCellValue("Document Number").ToString.Contains("AR") Then
                    .cbxAR.Checked = True
                ElseIf GridView19.GetFocusedRowCellValue("Document Number").ToString.Contains("CA") Then
                    .cbxLA.Checked = True
                End If
                .FirstLoad = False
                .LoadPayee()
                .cbxPayee.Text = GridView19.GetFocusedRowCellValue("Payee")
                CancelBW()
                Close()
            End With
            '****************************************************************** END FOR ACKNOWLEDGEMENT
        ElseIf SuperTabControl1.SelectedTabIndex = 3 And SuperTabControl6.SelectedTabIndex = 1 Then
            Try
                If GridView20.GetFocusedRowCellValue("ID").ToString = "" Or GridView20.RowCount = 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try
            '*************************** FOR CHECK VOUCHER
            If GridView20.GetFocusedRowCellValue("From") = "Loans Application" Then
                With FrmPaymentRequest
                    .Tag = 20
                    FormRestriction(.Tag)
                    If allow_Access Then
                        .vSave = allow_Save
                        .vUpdate = allow_Update
                        .vDelete = allow_Delete
                        .vPrint = allow_Print
                    Else
                        MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If

                    Logs("Alert Notification", "Open", "Payment Request", "", "", "", "")
                    Forms(FrmPaymentRequest, FrmMain.PanelControl3)

                    .SuperTabControl1.SelectedTabIndex = 0
                    Hide()

                    .cbxAll.Checked = True
                    .LoadData()
                    Dim i As Integer = 0
                    For x As Integer = 0 To .GridView1.RowCount - 1
                        If .GridView1.GetRowCellValue(x, "Credit Number") = GridView20.GetFocusedRowCellValue("ID") Then
                            i = x
                            Exit For
                        End If
                    Next
                    .GridView1.OptionsSelection.MultiSelect = False
                    .GridView1.FocusedRowHandle = i
                    .GridView1_DoubleClick(sender, e)
                    For x As Integer = 0 To .GridView2.RowCount - 1
                        If .GridView2.GetRowCellValue(x, "Payee") = GridView20.GetFocusedRowCellValue("Payee") Then
                            i = x
                            Exit For
                        End If
                    Next
                    .GridView2.OptionsSelection.MultiSelect = False
                    .GridView2.FocusedRowHandle = i
                    .btnCheckVoucher.PerformClick()
                    .GridView2.OptionsBehavior.Editable = True
                    .btnModify.Enabled = False
                    .btnDelete.Enabled = True
                    .PanelEx10.Enabled = True
                End With
            Else
                With FrmCheckVoucher
                    .Tag = 80
                    FormRestriction(.Tag)
                    If allow_Access Then
                        .vSave = allow_Save
                        .vUpdate = allow_Update
                        .vDelete = allow_Delete
                        .vPrint = allow_Print
                    Else
                        MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If

                    Logs("Alert Notification", "Check", "Check Voucher", "", "", "", "")
                    Forms(FrmCheckVoucher, FrmMain.PanelControl3)

                    .btnAdd.PerformClick()
                    If GridView20.GetFocusedRowCellValue("From") = "Loans Application" Then
                        .cbxLA.Checked = True
                    ElseIf GridView20.GetFocusedRowCellValue("From") = "Cash Advance" Or GridView20.GetFocusedRowCellValue("From") = "Liquidation" Then
                        .cbxCAS.Checked = True
                    ElseIf GridView20.GetFocusedRowCellValue("From") = "Accounts Payable" Then
                        .cbxAP.Checked = True
                    ElseIf GridView20.GetFocusedRowCellValue("From") = "Replenishment" Then
                        .cbxRC.Checked = True
                    End If
                    .cbxPayee.Text = GridView20.GetFocusedRowCellValue("Payee")
                    .rExplanation.Text = .rExplanation.Text & " " & GridView20.GetFocusedRowCellValue("Payee")
                    CancelBW()
                    Close()
                End With
            End If
            '****************************************************************** END FOR CHECK VOUCHER
        ElseIf SuperTabControl1.SelectedTabIndex = 3 And SuperTabControl6.SelectedTabIndex = 2 Then
            Try
                If GridView23.GetFocusedRowCellValue("ID").ToString = "" Or GridView23.RowCount = 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try
            '*************************** FOR JOURNAL VOUCHER
            With FrmJournalVoucher
                .Tag = 25
                FormRestriction(.Tag)
                If allow_Access Then
                    .vSave = allow_Save
                    .vUpdate = allow_Update
                    .vDelete = allow_Delete
                    .vPrint = allow_Print
                Else
                    MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Logs("Alert Notification", "Check", "Journal Voucher", "", "", "", "")
                Forms(FrmJournalVoucher, FrmMain.PanelControl3)

                .btnAdd.PerformClick()
                If GridView23.GetFocusedRowCellValue("Origin") = "Liquidation" Then
                    .cbxLOE.Checked = True
                    .cbxPayee.Text = GridView23.GetFocusedRowCellValue("Payee") & "[" & GridView23.GetFocusedRowCellValue("Account Number") & "]"
                Else
                    .cbxUR.Checked = True
                    .cbxPayee.Text = GridView23.GetFocusedRowCellValue("Payee") & "[" & GridView23.GetFocusedRowCellValue("Account Number") & "]"
                End If
            End With
            CancelBW()
            Close()
            '****************************************************************** END FOR JOURNAL VOUCHER
        ElseIf SuperTabControl1.SelectedTabIndex = 3 And SuperTabControl6.SelectedTabIndex = 3 Then
            Try
                If GridView21.GetFocusedRowCellValue("ID").ToString = "" Or GridView21.RowCount = 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try
            '*************************** FOR ROLL OVER
            If GridView21.GetFocusedRowCellValue("DocumentNumber").Contains("DF") Then
                With FrmDueFrom
                    .Tag = 102
                    FormRestriction(.Tag)
                    If allow_Access Then
                        .vSave = allow_Save
                        .vUpdate = allow_Update
                        .vDelete = allow_Delete
                        .vPrint = allow_Print
                    Else
                        MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If

                    Logs("Alert Notification", "Check", "Due From", "", "", "", "")
                    Forms(FrmDueFrom, FrmMain.PanelControl3)

                    .cbxAll.Checked = True
                    .LoadData()
                    Dim i As Integer = 0
                    For x As Integer = 0 To .GridView1.RowCount - 1
                        If .GridView1.GetRowCellValue(x, "Document Number") = GridView21.GetFocusedRowCellValue("DocumentNumber") Then
                            i = x
                            Exit For
                        End If
                    Next
                    .GridView1.OptionsSelection.MultiSelect = False
                    .GridView1.FocusedRowHandle = i
                End With
            Else
                With FrmDueTo
                    .Tag = 101
                    FormRestriction(.Tag)
                    If allow_Access Then
                        .vSave = allow_Save
                        .vUpdate = allow_Update
                        .vDelete = allow_Delete
                        .vPrint = allow_Print
                    Else
                        MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If

                    Logs("Alert Notification", "Check", "Due To", "", "", "", "")
                    Forms(FrmDueTo, FrmMain.PanelControl3)

                    .cbxAll.Checked = True
                    .LoadData()
                    Dim i As Integer = 0
                    For x As Integer = 0 To .GridView1.RowCount - 1
                        If .GridView1.GetRowCellValue(x, "Document Number") = GridView21.GetFocusedRowCellValue("DocumentNumber") Then
                            i = x
                            Exit For
                        End If
                    Next
                    .GridView1.OptionsSelection.MultiSelect = False
                    .GridView1.FocusedRowHandle = i
                End With
            End If
            CancelBW()
            Close()
            '****************************************************************** END FOR ROLL OVER
        ElseIf SuperTabControl1.SelectedTabIndex = 3 And SuperTabControl6.SelectedTabIndex = 4 Then
            Try
                If GridView24.GetFocusedRowCellValue("Credit Number").ToString = "" Or GridView24.RowCount = 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            If MsgBoxYes("Are you sure that this Promise to Pay is already collected?") = MsgBoxResult.Yes Then
                DataObject(String.Format("UPDATE credit_application SET PromiseStatus = 'COLLECTED' WHERE CreditNumber = '{0}'", GridView24.GetFocusedRowCellValue("Credit Number")))
                Logs("Alert Notification", "Collected", GridView24.GetFocusedRowCellValue("Remarks"), String.Format("Collected the Promise to Pay for Credit Number {0} of {1} on {2} with amount of P{3}.", GridView24.GetFocusedRowCellValue("Credit Number"), GridView24.GetFocusedRowCellValue("Borrower"), GridView24.GetFocusedRowCellValue("Date"), GridView24.GetFocusedRowCellValue("Amount")), "", "", GridView24.GetFocusedRowCellValue("Credit Number"))
                LoadPromise()
                MsgBox("Successfully Collected!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Sub FrmAlert_LoanApplication_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CancelBW()
        If GridView1.RowCount = 0 And GridView10.RowCount = 0 And GridView11.RowCount = 0 And GridView12.RowCount = 0 And GridView13.RowCount = 0 And GridView14.RowCount = 0 And GridView3.RowCount = 0 And GridView4.RowCount = 0 And GridView5.RowCount = 0 And GridView6.RowCount = 0 And GridView7.RowCount = 0 And GridView8.RowCount = 0 And GridView9.RowCount = 0 And GridView15.RowCount = 0 And GridView16.RowCount = 0 And GridView17.RowCount = 0 And GridView18.RowCount = 0 And GridView19.RowCount = 0 And GridView20.RowCount = 0 And GridView22.RowCount = 0 And GridView21.RowCount = 0 And GridView23.RowCount = 0 And GridView24.RowCount = 0 Then
            PendingWork = False
        Else
            PendingWork = True
        End If
    End Sub

    Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        If btnVerify.Visible = False Or btnCancel.Enabled = False Then
            Exit Sub
        End If

        Try
            If GridView3.GetFocusedRowCellValue("ID").ToString = "" Or GridView3.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If FrmMain.lblDate.Text.Contains("Disconnected") Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        '****Vehicle
        If GridView3.GetFocusedRowCellValue("Type") = "Vehicle" Then
            With FrmVehicleROPOA
                .Tag = 38
                FormRestriction(.Tag)
                If allow_Access Then
                    .vSave = allow_Save
                    .vUpdate = allow_Update
                    .vDelete = allow_Delete
                    .vPrint = allow_Print
                Else
                    MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Logs("Alert Notification", "Verify", "Vehicle ROPOA", "", "", "", "")
                Forms(FrmVehicleROPOA, FrmMain.PanelControl3)

                Dim i As Integer = 0
                .LoadData()
                For x As Integer = 0 To .GridView2.RowCount - 1
                    If .GridView2.GetRowCellValue(x, "Asset Number") = GridView3.GetFocusedRowCellValue("Asset Number") Then
                        i = x
                        Exit For
                    End If
                Next
                .GridView2.OptionsSelection.MultiSelect = False
                .GridView2.FocusedRowHandle = i
                .GridView2_DoubleClick(sender, e)
                .btnVerify.Enabled = True
            End With
            CancelBW()
            Close()
        ElseIf GridView3.GetFocusedRowCellValue("Type") = "Real Estate" Then
            '**** REAL ESTATE
            With FrmRealEstateROPOA
                .Tag = 39
                FormRestriction(.Tag)
                If allow_Access Then
                    .vSave = allow_Save
                    .vUpdate = allow_Update
                    .vDelete = allow_Delete
                    .vPrint = allow_Print
                Else
                    MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Logs("Alert Notification", "Verify", "Real Estate ROPOA", "", "", "", "")
                Forms(FrmRealEstateROPOA, FrmMain.PanelControl3)

                Dim i As Integer = 0
                .LoadData()
                For x As Integer = 0 To .GridView2.RowCount - 1
                    If .GridView2.GetRowCellValue(x, "Asset Number") = GridView3.GetFocusedRowCellValue("Asset Number") Then
                        i = x
                        Exit For
                    End If
                Next
                .GridView2.OptionsSelection.MultiSelect = False
                .GridView2.FocusedRowHandle = i
                .GridView2_DoubleClick(sender, e)
                .btnVerify.Enabled = True
            End With
            CancelBW()
            Close()
        End If
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged, SuperTabControl5.SelectedTabChanged, SuperTabControl6.SelectedTabChanged, SuperTabControl3.SelectedTabChanged
        btnCheck.Text = "&Check"
        If SuperTabControl1.SelectedTabIndex = 0 Then
            btnCheck.Visible = True
            btnCancelSMS.Visible = False
            btnVerify.Visible = False
            btnConsolidate.Visible = False
            btnForfeit.Visible = False
            btnPrint.Visible = False
            btnEmail.Visible = False
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            If SuperTabControl3.SelectedTabIndex = 0 Then
                btnVerify.Visible = True
                btnCheck.Visible = False
                btnConsolidate.Visible = False
                btnForfeit.Visible = False
                btnCancelSMS.Visible = False
                btnPrint.Visible = False
                btnEmail.Visible = False
            ElseIf SuperTabControl3.SelectedTabIndex = 1 Then
                btnConsolidate.Visible = True
                btnVerify.Visible = False
                btnCheck.Visible = False
                btnForfeit.Visible = False
                btnCancelSMS.Visible = False
                btnPrint.Visible = True
                btnEmail.Visible = False
            ElseIf SuperTabControl3.SelectedTabIndex = 2 Then
                btnConsolidate.Visible = False
                btnVerify.Visible = False
                btnCheck.Visible = True
                btnForfeit.Visible = False
                btnCancelSMS.Visible = False
                btnPrint.Visible = False
                btnEmail.Visible = False
            ElseIf SuperTabControl3.SelectedTabIndex = 3 Then
                btnConsolidate.Visible = False
                btnVerify.Visible = False
                btnCheck.Visible = False
                btnForfeit.Visible = True
                btnCancelSMS.Visible = False
                btnPrint.Visible = False
                btnEmail.Visible = False
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            If SuperTabControl5.SelectedTabIndex = 0 Then
                btnCheck.Visible = False
                btnCancelSMS.Visible = True
                btnVerify.Visible = False
                btnConsolidate.Visible = False
                btnForfeit.Visible = False
                btnPrint.Visible = False
                btnEmail.Visible = False
            ElseIf SuperTabControl5.SelectedTabIndex = 1 Then
                btnCheck.Visible = False
                btnCancelSMS.Visible = False
                btnVerify.Visible = False
                btnConsolidate.Visible = False
                btnForfeit.Visible = False
                btnPrint.Visible = False
                btnEmail.Visible = True
            ElseIf SuperTabControl5.SelectedTabIndex = 2 Or SuperTabControl5.SelectedTabIndex = 3 Or SuperTabControl5.SelectedTabIndex = 4 Or SuperTabControl5.SelectedTabIndex = 5 Then
                btnCheck.Visible = True
                btnCancelSMS.Visible = False
                btnVerify.Visible = False
                btnConsolidate.Visible = False
                btnForfeit.Visible = False
                btnPrint.Visible = False
                btnEmail.Visible = False
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            btnCheck.Visible = True
            btnCancelSMS.Visible = False
            btnVerify.Visible = False
            btnConsolidate.Visible = False
            btnForfeit.Visible = False
            btnPrint.Visible = False
            btnEmail.Visible = False
            If SuperTabControl6.SelectedTabIndex = 4 Then
                btnCheck.Text = "&Collected"
            End If
        End If
    End Sub

    Private Sub BtnConsolidate_Click(sender As Object, e As EventArgs) Handles btnConsolidate.Click
        If btnConsolidate.Visible = False Or btnCancel.Enabled = False Then
            Exit Sub
        End If

        Try
            If GridView4.GetFocusedRowCellValue("ID").ToString = "" Or GridView4.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Redemption As New FrmRedemptionPeriod
        With Redemption
            .AssetNumber = GridView4.GetFocusedRowCellValue("Asset Number")
            .Type = GridView4.GetFocusedRowCellValue("Type")
            .dtpReceived.Enabled = False
            .dtpReceived.Value = DateValue(GridView4.GetFocusedRowCellValue("Received COS"))
            .dtpCOS.Enabled = False
            .dtpCOS.Value = DateValue(GridView4.GetFocusedRowCellValue("COS Annotation"))
            .LabelX3.Visible = True
            .dtpConsolidation.Visible = True
            .dtpConsolidation.MinDate = DateValue(GridView4.GetFocusedRowCellValue("COS Annotation"))
            .dtpConsolidation.Value = Date.Now
            .btnRefresh.Enabled = False
            .LabelX4.Visible = True
            .txtTCT.Visible = True
            .LabelX5.Visible = True
            .btnSave.Text = "Consolidate"

            If .ShowDialog = DialogResult.OK Then
                LoadROPOAConsolidation()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        'CREDIT APPLICATION ****************************************
        If GridView1.RowCount > 0 Then
            If tabCreditApp.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabCreditApp.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabCreditApp.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabCreditApp.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If

        'CREDIT INVESTIGATION ****************************************
        If GridView10.RowCount > 0 Then
            If tabCI.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabCI.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabCI.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabCI.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If

        'PAYMENT REQUEST ****************************************
        If GridView11.RowCount > 0 Then
            If tabRequest.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabRequest.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabRequest.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabRequest.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If

        'PAYMENT RELEASE ****************************************
        If GridView12.RowCount > 0 Then
            If tabRelease.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabRelease.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabRelease.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabRelease.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If

        'FOR CHECK DUE ****************************************
        If GridView13.RowCount > 0 Then
            If tabForCollection.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabForCollection.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabForCollection.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabForCollection.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If

        'FOR POSTING ****************************************
        If GridView14.RowCount > 0 Then
            If tabForPosting.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabForPosting.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabForPosting.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabForPosting.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If

        '******** C R E D I T   T O T A L ************
        If GridView1.RowCount + GridView10.RowCount + GridView11.RowCount + GridView12.RowCount + GridView13.RowCount + GridView14.RowCount > 0 Then
            If tabLoanManagement.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabLoanManagement.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabLoanManagement.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabLoanManagement.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If
        '******** C R E D I T   T O T A L ************

        If GridView3.RowCount > 0 Then
            If tabROPOA_Verification.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabROPOA_Verification.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabROPOA_Verification.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabROPOA_Verification.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If

        If GridView4.RowCount > 0 Then
            If tabROPOA_Consolidation.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabROPOA_Consolidation.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabROPOA_Consolidation.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabROPOA_Consolidation.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If

        If GridView5.RowCount > 0 Then
            If tabROPOA_ImpairmentII.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabROPOA_ImpairmentII.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabROPOA_ImpairmentII.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabROPOA_ImpairmentII.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If

        If GridView6.RowCount > 0 Then
            If tabExpiredReservation.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabExpiredReservation.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabExpiredReservation.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabExpiredReservation.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If

        If GridView7.RowCount > 0 Then
            If tabImpairmentDue.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabImpairmentDue.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabImpairmentDue.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabImpairmentDue.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If

        If GridView5.RowCount + GridView7.RowCount > 0 Then
            If tabROPOA_Impairment.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabROPOA_Impairment.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabROPOA_Impairment.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabROPOA_Impairment.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If

        '******** R O P O A   T O T A L ************
        If GridView3.RowCount + GridView4.RowCount + GridView5.RowCount + GridView6.RowCount + GridView7.RowCount > 0 Then
            If tabROPOA_Approval.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabROPOA_Approval.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabROPOA_Approval.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabROPOA_Approval.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If
        '******** R O P O A   T O T A L ************

        'SMS Alert ****************************************
        If GridView9.RowCount > 0 Then
            If tabSMS_Alert.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabSMS_Alert.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabSMS_Alert.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabSMS_Alert.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If
        'SMS Alert ****************************************

        'Email Outbox ****************************************
        If GridView17.RowCount > 0 Then
            If tabEmailOutbox.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabEmailOutbox.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabEmailOutbox.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabEmailOutbox.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If
        'Email Outbox ****************************************

        'Cash Advance ****************************************
        If GridView15.RowCount > 0 Then
            If tabCashAdvance.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabCashAdvance.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabCashAdvance.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabCashAdvance.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If
        'Cash Advance ****************************************

        'Petty Cash ****************************************
        If GridView16.RowCount > 0 Then
            If tabPettyCash.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabPettyCash.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabPettyCash.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabPettyCash.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If
        'Petty Cash ****************************************

        'For Liquidation ****************************************
        If GridView18.RowCount > 0 Then
            If tabForLiquidation.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabForLiquidation.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabForLiquidation.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabForLiquidation.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If
        'For Liquidation ****************************************

        'ITL Monitoring ****************************************
        If GridView22.RowCount > 0 Then
            If tabITLMonitoring.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabITLMonitoring.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabITLMonitoring.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabITLMonitoring.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If
        'ITL Monitoring ****************************************

        'For Acknowledgement ****************************************
        If GridView19.RowCount > 0 Then
            If tabForAcknowledgement.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabForAcknowledgement.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabForAcknowledgement.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabForAcknowledgement.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If
        'For Acknowledgement ****************************************

        'For Check Voucher ****************************************
        If GridView20.RowCount > 0 Then
            If tabForCV.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabForCV.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabForCV.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabForCV.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If
        'For Check Voucher ****************************************

        'N O N L O A N S   T O T A L ****************************************
        If GridView9.RowCount + GridView17.RowCount + GridView16.RowCount + GridView15.RowCount + GridView18.RowCount + GridView22.RowCount > 0 Then
            If tabNonLoans.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabNonLoans.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabNonLoans.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabNonLoans.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If
        'N O N L O A N S   T O T A L ****************************************

        'F I N A N C I A L   T O T A L ****************************************
        If GridView19.RowCount + GridView20.RowCount + GridView23.RowCount + GridView21.RowCount > 0 Then
            If tabFinancial.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabFinancial.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabFinancial.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabFinancial.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If
        'F I N A N C I A L   T O T A L ****************************************

        'For Journal Voucher ****************************************
        If GridView23.RowCount > 0 Then
            If tabForJV.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabForJV.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabForJV.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabForJV.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If
        'For Journal Entry ****************************************

        'For Roll Over ****************************************
        If GridView21.RowCount > 0 Then
            If tabForRollOver.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabForRollOver.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabForRollOver.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabForRollOver.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If
        'For Roll Over ****************************************

        'Promise to Pay ****************************************
        If GridView24.RowCount > 0 Then
            If tabPromise.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default Then
                tabPromise.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Red
            Else
                tabPromise.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
            End If
        Else
            tabPromise.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Default
        End If
        'Promise to Pay ****************************************
    End Sub

    Private Sub BtnForfeit_Click(sender As Object, e As EventArgs) Handles btnForfeit.Click
        If btnForfeit.Visible = False Or btnCancel.Enabled = False Then
            Exit Sub
        End If

        Try
            If GridView6.GetFocusedRowCellValue("ID").ToString = "" Or GridView6.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If FrmMain.lblDate.Text.Contains("Disconnected") Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim SQL_II As String = String.Format("UPDATE sold_ropoa SET `status` = 'FORFEITED' WHERE AssetNumber = '{0}' AND ID = '{1}';", GridView6.GetFocusedRowCellValue("Asset Number"), GridView6.GetFocusedRowCellValue("ID"))
        If GridView6.GetFocusedRowCellValue("Type") = "Vehicle" Then
            SQL_II &= String.Format(" UPDATE ropoa_vehicle SET sell_status = 'SELL' WHERE AssetNumber = '{0}';", GridView6.GetFocusedRowCellValue("Asset Number"))
            DataObject(SQL_II)
            With FrmVehicleROPOA
                .iFrom.Value = 0
                .iTo.Value = 0
                .Clear()
                .btnNext_2.Enabled = False
                .btnBack_2.Enabled = False
                .LoadData()
                .LoadReserved()
            End With
            Logs("Alert Notification", "Auto Forfeit", String.Format("Auto Forfeit of transaction for Vehicle ROPOA {0} under OR Number {1}", GridView6.GetFocusedRowCellValue("Asset Number"), GridView6.GetFocusedRowCellValue("Document Number")), "", "", "", "")
            With FrmMain
                .VehicleCount = .VehicleCount + 1
                .VehicleCount_Sold = .VehicleCount_Sold - 1
            End With
        Else
            SQL_II &= String.Format(" UPDATE ropoa_realestate SET sell_status = 'SELL' WHERE AssetNumber = '{0}';", GridView6.GetFocusedRowCellValue("Asset Number"))
            DataObject(SQL_II)
            With FrmRealEstateROPOA
                .iFrom.Value = 0
                .iTo.Value = 0
                .Clear()
                .btnNext_2.Enabled = False
                .btnBack_2.Enabled = False
                .LoadData()
                .LoadReserved()
            End With
            Logs("Alert Notification", "Auto Forfeit", String.Format("Auto Forfeit of transaction for Real Estate ROPOA {0} under OR Number {1}", GridView6.GetFocusedRowCellValue("Asset Number"), GridView6.GetFocusedRowCellValue("Document Number")), "", "", "", "")
            With FrmMain
                .RealEstateCount = .RealEstateCount + 1
                .RealEstateCount_Sold = .RealEstateCount_Sold - 1
            End With
        End If
        MsgBox("Successfully Forfeited!", MsgBoxStyle.Information, "Info")
    End Sub

    Private Sub GridView5_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView5.RowCellStyle
        If GridView5.RowCount > 0 And ComparePosition({"BRANCH MANAGER"}, False) Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Checked As Integer = View.GetRowCellValue(e.RowHandle, View.Columns("BM_Check"))
            Try
                If Checked = 0 Then
                    e.Appearance.ForeColor = OfficialColor2 'Color.Red
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BtnCancelSMS_Click(sender As Object, e As EventArgs) Handles btnCancelSMS.Click
        If btnCancelSMS.Visible = False Or btnCancel.Enabled = False Then
            Exit Sub
        End If

        Try
            If GridView9.GetFocusedRowCellValue("ID").ToString = "" Or GridView9.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If MsgBoxYes("Are you sure you want to cancel this SMS?") = MsgBoxResult.Yes Then
            DataObject(String.Format("UPDATE SMS_Outbox SET `status` = 'CANCELLED' WHERE ID = '{0}'", GridView9.GetFocusedRowCellValue("ID")))
            MsgBox("Successfully Cancelled!", MsgBoxStyle.Information, "Info")
            Logs("Alert Notification", "Cancel SMS", "Cancel SMS", "", "", "", "")
            LoadSMS()
        End If
    End Sub

    Private Sub GridView10_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView10.RowCellStyle
        If GridView10.RowCount > 0 And CI = "Credit Investigation" Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Recommendation"))
            If Status = "DRAFT" Then
                e.Appearance.ForeColor = Color.IndianRed
            Else
                If Status = "APPROVAL" Then
                    e.Appearance.ForeColor = Color.SeaGreen
                ElseIf Status = "DISAPPROVAL" Then
                    e.Appearance.ForeColor = Color.IndianRed
                Else
                    e.Appearance.ForeColor = Color.Black
                End If
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If btnCancel.Enabled = False Then
            Exit Sub
        End If

        If SuperTabControl1.SelectedTabIndex = 0 Then
            If SuperTabControl4.SelectedTabIndex = 0 Then
                GridView1.OptionsPrint.UsePrintStyles = False
                StandardPrinting("CREDIT APPLICATION", GridControl1)
            ElseIf SuperTabControl4.SelectedTabIndex = 1 Then
                GridView10.OptionsPrint.UsePrintStyles = False
                StandardPrinting("CREDIT INVESTIGATION", GridControl10)
            ElseIf SuperTabControl4.SelectedTabIndex = 2 Then
                GridView11.OptionsPrint.UsePrintStyles = False
                StandardPrinting("PAYMENT REQUEST", GridControl11)
            ElseIf SuperTabControl4.SelectedTabIndex = 3 Then
                GridView12.OptionsPrint.UsePrintStyles = False
                StandardPrinting("PAYMENT RELEASE", GridControl12)
            ElseIf SuperTabControl4.SelectedTabIndex = 4 Then
                GridView13.OptionsPrint.UsePrintStyles = False
                StandardPrinting("FOR CHECK DUE", GridControl13)
            ElseIf SuperTabControl4.SelectedTabIndex = 5 Then
                GridView14.OptionsPrint.UsePrintStyles = False
                StandardPrinting("ACCOUNTS FOR POSTING", GridControl14)
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            If SuperTabControl3.SelectedTabIndex = 0 Then
                GridView3.OptionsPrint.UsePrintStyles = False
                StandardPrinting("ROPOA FOR VERIFICATION", GridControl3)
            ElseIf SuperTabControl3.SelectedTabIndex = 1 Then
                Dim xPath As String = Application.StartupPath & "\Documents\Redemption Letter.docx"
                Dim PathName As String = IO.Path.GetFileName(xPath)
                Dim File_Directory As String = String.Format("{0}\{1}\{2}\Documents\{3}", RootFolder, MainFolder, Branch_Code, "Redemption Letter")
                If Not IO.Directory.Exists(File_Directory) Then
                    IO.Directory.CreateDirectory(File_Directory)
                End If
                Dim FileName As String = String.Format("{0}\{1}", File_Directory, PathName)

                For x As Integer = 2 To 1000
                    If IO.File.Exists(FileName) Then
                        FileName = String.Format("{0}\Redemption Letter of {1} ({2}).doc", File_Directory, "Name Here", x)
                    End If
                Next
                IO.File.Copy(xPath, FileName)

                Dim WordApp As New word.Application With {
                    .Visible = False
                }
                Dim Doc As word.Document = WordApp.Documents.Open(FileName)
                Doc = WordApp.ActiveDocument

                'REPLACE
                With Doc.Content.Find
                    .Execute(FindText:="@Date", ReplaceWith:=Format(Date.Now, "MMMM dd, yyyy"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                    .Execute(FindText:="@Name", ReplaceWith:=UpperCaseFirst(GridView4.GetFocusedRowCellValue("Account Name")), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                    .Execute(FindText:="@Address", ReplaceWith:=UpperCaseFirst(DataObject(String.Format("SELECT CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ', ')), AddressC_B) FROM profile_borrower WHERE BorrowerID = '{0}';", GridView4.GetFocusedRowCellValue("AccountID")))), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                    .Execute(FindText:="@TCT", ReplaceWith:=GridView4.GetFocusedRowCellValue("TCT"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                    .Execute(FindText:="@AnnotationD", ReplaceWith:=Format(CDate(GridView4.GetFocusedRowCellValue("COS Annotation")), "MMMM dd, yyyy"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                    .Execute(FindText:="@ExpireD", ReplaceWith:=Format(CDate(GridView4.GetFocusedRowCellValue("COS Annotation")).AddYears(1), "MMMM dd, yyyy"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                    .Execute(FindText:="@ContactBranch", ReplaceWith:=DataObject(String.Format("SELECT CONCAT(contactN1, IF(contactN2 = '','',CONCAT(' or ', contactN2)), IF(contactN3 = '','',CONCAT(' or ', contactN3))) FROM branch WHERE ID = '{0}';", Branch_ID)), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                    .Execute(FindText:="@User", ReplaceWith:=UpperCaseFirst(Empl_Name), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                    .Execute(FindText:="@Position", ReplaceWith:=UpperCaseFirst(Empl_Position), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                    .Execute(FindText:="@Branch", ReplaceWith:=UpperCaseFirst(Branch), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                End With

                With Doc
                    .Save()
                    .Close()
                End With
                Doc = Nothing
                WordApp.Quit()
                WordApp = Nothing
                Try
                    Process.Start(FileName)
                Catch ex As Exception
                    Try
                        Process.Start(FileName.Replace("\", "/"))
                    Catch ex1 As Exception
                        Process.Start(FileName.Replace("/", "\"))
                    End Try
                End Try
            ElseIf SuperTabControl3.SelectedTabIndex = 2 Then
                If SuperTabControl2.SelectedTabIndex = 0 Then
                    GridView5.OptionsPrint.UsePrintStyles = False
                    StandardPrinting("ROPOA FOR IMPAIRMENT", GridControl5)
                ElseIf SuperTabControl2.SelectedTabIndex = 0 Then
                    GridView7.OptionsPrint.UsePrintStyles = False
                    StandardPrinting("ROPOA FOR IMPAIRMENT DUE", GridControl7)
                End If
            ElseIf SuperTabControl3.SelectedTabIndex = 3 Then
                GridView6.OptionsPrint.UsePrintStyles = False
                StandardPrinting("ROPOA EXPIRED RESERVATION", GridControl6)
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            If SuperTabControl5.SelectedTabIndex = 0 Then
                GridView9.OptionsPrint.UsePrintStyles = False
                StandardPrinting("SMS ALERT", GridControl9)
            ElseIf SuperTabControl5.SelectedTabIndex = 1 Then
                GridView17.OptionsPrint.UsePrintStyles = False
                StandardPrinting("EMAIL OUTBOX", GridControl17)
            ElseIf SuperTabControl5.SelectedTabIndex = 2 Then
                GridView15.OptionsPrint.UsePrintStyles = False
                StandardPrinting("CASH ADVANCE SLIP", GridControl15)
            ElseIf SuperTabControl5.SelectedTabIndex = 3 Then
                GridView16.OptionsPrint.UsePrintStyles = False
                StandardPrinting("PETTY CASH VOUCHER", GridControl16)
            ElseIf SuperTabControl5.SelectedTabIndex = 4 Then
                GridView18.OptionsPrint.UsePrintStyles = False
                StandardPrinting("FOR LIQUIDATION LIST", GridControl18)
            ElseIf SuperTabControl5.SelectedTabIndex = 5 Then
                GridView19.OptionsPrint.UsePrintStyles = False
                StandardPrinting("FOR ACKNOWLEDGEMENT LIST", GridControl19)
            ElseIf SuperTabControl5.SelectedTabIndex = 6 Then
                GridView19.OptionsPrint.UsePrintStyles = False
                StandardPrinting("FOR CHECK VOUCHER LIST", GridControl19)
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            If SuperTabControl6.SelectedTabIndex = 0 Then
                GridView19.OptionsPrint.UsePrintStyles = False
                StandardPrinting("ACKNOWLEDGEMENT LIST", GridControl9)
            ElseIf SuperTabControl6.SelectedTabIndex = 1 Then
                GridView20.OptionsPrint.UsePrintStyles = False
                StandardPrinting("FOR CHECK VOUCHER LIST", GridControl17)
            ElseIf SuperTabControl6.SelectedTabIndex = 2 Then
                GridView23.OptionsPrint.UsePrintStyles = False
                StandardPrinting("FOR JOURNAL VOUCHER LIST", GridControl15)
            ElseIf SuperTabControl6.SelectedTabIndex = 3 Then
                GridView21.OptionsPrint.UsePrintStyles = False
                StandardPrinting("FOR ROLL OVER LIST", GridControl16)
            ElseIf SuperTabControl6.SelectedTabIndex = 4 Then
                GridView24.OptionsPrint.UsePrintStyles = False
                StandardPrinting("PROMISE TO PAY LIST", GridControl16)
            End If
        End If
    End Sub

    Private Sub BtnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        Try
            If GridView17.GetFocusedRowCellValue("ID").ToString = "" Or GridView17.RowCount = 0 Or btnCancel.Enabled = False Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If MsgBoxYes("Are you sure you want to send this email?") = MsgBoxResult.Yes Then
            AttachmentFiles = New ArrayList()
            With GridView17
                If .GetFocusedRowCellValue("Attachment_1") <> "" Then
                    AttachmentFiles.Add(.GetFocusedRowCellValue("Attachment_1"))
                End If
                If .GetFocusedRowCellValue("Attachment_2") <> "" Then
                    AttachmentFiles.Add(.GetFocusedRowCellValue("Attachment_2"))
                End If
                If .GetFocusedRowCellValue("Attachment_3") <> "" Then
                    AttachmentFiles.Add(.GetFocusedRowCellValue("Attachment_3"))
                End If
                If .GetFocusedRowCellValue("Attachment_4") <> "" Then
                    AttachmentFiles.Add(.GetFocusedRowCellValue("Attachment_4"))
                End If
                If .GetFocusedRowCellValue("Attachment_5") <> "" Then
                    AttachmentFiles.Add(.GetFocusedRowCellValue("Attachment_5"))
                End If
                If .GetFocusedRowCellValue("Attachment_6") <> "" Then
                    AttachmentFiles.Add(.GetFocusedRowCellValue("Attachment_6"))
                End If
                If .GetFocusedRowCellValue("Attachment_7") <> "" Then
                    AttachmentFiles.Add(.GetFocusedRowCellValue("Attachment_7"))
                End If
                If .GetFocusedRowCellValue("Attachment_8") <> "" Then
                    AttachmentFiles.Add(.GetFocusedRowCellValue("Attachment_8"))
                End If
                If .GetFocusedRowCellValue("Attachment_9") <> "" Then
                    AttachmentFiles.Add(.GetFocusedRowCellValue("Attachment_9"))
                End If
                If .GetFocusedRowCellValue("Attachment_10") <> "" Then
                    AttachmentFiles.Add(.GetFocusedRowCellValue("Attachment_10"))
                End If
                SendEmail(.GetFocusedRowCellValue("To"), .GetFocusedRowCellValue("Subject1"), .GetFocusedRowCellValue("Body1"), .GetFocusedRowCellValue("Confidential"), True, True, .GetFocusedRowCellValue("ID"), .GetFocusedRowCellValue("DocumentNumber"), .GetFocusedRowCellValue("CC"))
                Logs("Alert Notification", "Send Email", String.Format("Send Email From {0} to {1} with Subject {2}.", .GetFocusedRowCellValue("From"), .GetFocusedRowCellValue("To"), .GetFocusedRowCellValue("Subject")), "", "", "", "")
            End With
            LoadEmail()
        End If
    End Sub

    Private Sub ICancelEmail_Click(sender As Object, e As EventArgs) Handles iCancelEmail.Click
        Try
            If GridView17.GetFocusedRowCellValue("ID").ToString = "" Or GridView17.RowCount = 0 Or btnCancel.Enabled = False Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If MsgBoxYes("Are you sure you want to cancel this email?") = MsgBoxResult.Yes Then
            DataObject(String.Format("UPDATE Email_Outbox SET `status` = 'CANCELLED' WHERE ID = '{0}';", GridView17.GetFocusedRowCellValue("ID")))
            Logs("Alert Notification", "Cancel Email", String.Format("Cancel Email From {0} to {1} with Subject {2}.", GridView17.GetFocusedRowCellValue("From"), GridView17.GetFocusedRowCellValue("To"), GridView17.GetFocusedRowCellValue("Subject")), "", "", "", "")
            LoadEmail()
            MsgBox("Successfully Cancelled!", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnAddToNotification_Click(sender As Object, e As EventArgs) Handles btnAddToNotification.Click
        Dim Notification As New FrmAddToNotification
        Dim ExcludeID As String = ""
        For x As Integer = 0 To GridView13.RowCount - 1
            ExcludeID &= "'" & GridView13.GetRowCellValue(x, "Document Number") & "',"
        Next
        With Notification
            .From_PettyCash = True
            If ExcludeID = "" Then
            Else
                .ExcludeID = ExcludeID.Substring(0, ExcludeID.Length - 1)
            End If
            If .ShowDialog = DialogResult.OK Then
                LoadCollection()
                MsgBox("Successfully Added!", MsgBoxStyle.Information, "Info")
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnRemoveFromNotification_Click(sender As Object, e As EventArgs) Handles btnRemoveFromNotification.Click
        Try
            If GridView13.GetFocusedRowCellValue("ID").ToString = "" Or GridView13.RowCount = 0 Or btnCancel.Enabled = False Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If MsgBoxYes("Are you sure you want to remove this Notification of Check Due Date from the list?") = MsgBoxResult.Yes Then
            DataObject(String.Format("UPDATE check_received SET `Checked` = 1 WHERE ID = '{0}';", GridView13.GetFocusedRowCellValue("ID")))
            Logs("Alert Notification", "Remove Notification", String.Format("Remove From Notification of Check Number {0} from {1}.", GridView13.GetFocusedRowCellValue("Check Number"), GridView13.GetFocusedRowCellValue("Payee")), "", "", "", "")
            LoadCollection()
            MsgBox("Successfully Removed!", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub GridView_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick, GridView10.DoubleClick, GridView11.DoubleClick, GridView12.DoubleClick, GridView13.DoubleClick, GridView14.DoubleClick, GridView3.DoubleClick, GridView4.DoubleClick, GridView5.DoubleClick, GridView6.DoubleClick, GridView7.DoubleClick, GridView9.DoubleClick, GridView17.DoubleClick, GridView15.DoubleClick, GridView16.DoubleClick, GridView18.DoubleClick, GridView22.DoubleClick, GridView19.DoubleClick, GridView20.DoubleClick, GridView23.DoubleClick, GridView21.DoubleClick, GridView24.DoubleClick
        Trigger_DoubleClick()
    End Sub

    Private Sub Trigger_DoubleClick()
        If btnCancel.Enabled = False Then
            Exit Sub
        End If

        If SuperTabControl1.SelectedTabIndex = 0 Then
            btnCheck.PerformClick()
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            If SuperTabControl3.SelectedTabIndex = 0 Then
                btnVerify.PerformClick()
            ElseIf SuperTabControl3.SelectedTabIndex = 1 Then
                btnConsolidate.PerformClick()
            ElseIf SuperTabControl3.SelectedTabIndex = 2 Then
                btnCheck.PerformClick()
            ElseIf SuperTabControl3.SelectedTabIndex = 3 Then
                btnForfeit.PerformClick()
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            If SuperTabControl5.SelectedTabIndex = 0 Then
                btnCancelSMS.PerformClick()
            ElseIf SuperTabControl5.SelectedTabIndex = 1 Then
                btnEmail.PerformClick()
            ElseIf SuperTabControl5.SelectedTabIndex = 2 Or SuperTabControl5.SelectedTabIndex = 3 Or SuperTabControl5.SelectedTabIndex = 4 Or SuperTabControl5.SelectedTabIndex = 5 Then
                btnCheck.PerformClick()
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            btnCheck.PerformClick()
        End If
    End Sub

    Private Sub GridView13_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView13.SelectionChanged
        Try
            If GridView13.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView13.GetFocusedRowCellValue("Check From") = "CREDIT" Then
            btnAddToNotification.Enabled = True
            btnRemoveFromNotification.Enabled = True
        Else
            btnAddToNotification.Enabled = False
            btnRemoveFromNotification.Enabled = False
        End If
    End Sub
End Class