Public Class FrmEncumbered

    Dim ID As Integer
    Dim FirstLoad As Boolean = True
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Private Sub FrmEncumbered_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        FirstLoad = True
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        DtpNotarial.Value = Date.Now
        DtpBIR.Value = Date.Now
        DtpRD.Value = Date.Now
        DtpLTO.Value = Date.Now
        LblCollateral.Enabled = False
        SuperTabControl1.SelectedTab = tabList

        LoadDropDownData()
        LoadData()
        FirstLoad = False
    End Sub

    Private Sub BtnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        LblTitle_Click(sender, e)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelNote, LabelX1, LabelX9, LblCollateral, LabelX10, LabelX3, LabelX2, LabelX5, LabelX5, LabelX12, LabelX4, LabelX8, LabelX15, LabelX17, LabelX13, LabelX16, LabelX21, LabelX7, LabelX23, LabelX18, LabelX22})

            GetTextBoxFontSettings({TxtNotarial, TxtBIR, TxtRD, TxtLTO, TxtNote})

            GetComboBoxFontSettings({CmbBorrower, CmbNotarial, CmbBIR, CmbLTO, CmbRD})

            GetDateTimeInputFontSettings({DtpBIR, DtpRD, DtpLTO, DtpNotarial})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetDoubleInputFontSettings({DblNotarial, DblBIR, DblRD, DblLTO})

            GetLabelWithBackgroundFontSettingsNoBorder({LblNotarial, LblBIR, LblRD, LblLTO})

            GetButtonFontSettings({BtnAdd, BtnSave, BtnRefresh, BtnCancel, BtnModify, BtnDelete, BtnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Encumbered/Annotation Monitoring - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub
#Region "Keydown"

    Private Sub CmbBorrower_KeyDown(sender As Object, e As KeyEventArgs) Handles CmbBorrower.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub DtpNotarial_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpNotarial.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DblNotarial_KeyDown(sender As Object, e As KeyEventArgs) Handles DblNotarial.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub CmbNotarial_KeyDown(sender As Object, e As KeyEventArgs) Handles CmbNotarial.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub TxtNotarial_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNotarial.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub DtpBIR_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpBIR.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub DblBIR_KeyDown(sender As Object, e As KeyEventArgs) Handles DblBIR.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtBIR_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtBIR.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DtpRD_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpRD.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub DblRD_KeyDown(sender As Object, e As KeyEventArgs) Handles DblRD.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub CmbRD_KeyDown(sender As Object, e As KeyEventArgs) Handles CmbRD.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtRD_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtRD.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DtpLTO_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpLTO.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DblLTO_KeyDown(sender As Object, e As KeyEventArgs) Handles DblLTO.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CmbLTO_KeyDown(sender As Object, e As KeyEventArgs) Handles CmbLTO.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtLTO_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLTO.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtNote_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNote.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
#End Region
    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Encumbered/Annotation Monitoring", lblTitle.Text)
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView1_DoubleClick(sender, e)
        End If
    End Sub
    Private Sub LoadEncumberedData()
        With CmbBorrower
            .DisplayMember = "Borrower"
            .ValueMember = "Credit Number"
            .DataSource = DataSource(String.Format("SELECT C.CreditNumber AS 'Credit Number', mortgage_id, CONCAT(IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)), ' [',CONCAT(IF(CompromiseAgreement > 0,'CA',''),IF(PaymentArrangement > 0,'PA',''), CreditNumber),']') AS 'Borrower' FROM credit_application C WHERE C.`status` = 'ACTIVE' AND C.`PaymentRequest` NOT IN ('CLOSED') AND Branch_ID IN ({0}) AND mortgage_ID IN (1,2) AND IF(mortgage_id = 1,loan_type='NEW',loan_type IN ('NEW','RELOAN')) AND encumbered_status = 'ENCUMBERED' ORDER BY `Borrower`", Branch_ID))
        End With
    End Sub

    Private Sub LoadDropDownData()
        With CmbBorrower
            .DisplayMember = "Borrower"
            .ValueMember = "Credit Number"
            .DataSource = DataSource(String.Format("SELECT C.CreditNumber AS 'Credit Number', mortgage_id, CONCAT(IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)), ' [',CONCAT(IF(CompromiseAgreement > 0,'CA',''),IF(PaymentArrangement > 0,'PA',''), CreditNumber),']') AS 'Borrower' FROM credit_application C WHERE C.`status` = 'ACTIVE' AND C.`PaymentRequest` NOT IN ('CLOSED') AND Branch_ID IN ({0}) AND mortgage_ID IN (1,2) AND IF(mortgage_id = 1,loan_type='NEW',loan_type IN ('NEW','RELOAN')) AND encumbered_status IS NULL ORDER BY `Borrower`", Branch_ID))
        End With

        With CmbNotarial
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With

        With CmbBIR
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With

        With CmbRD
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With

        With CmbLTO
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With
    End Sub
    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        LoadEncumberedData()
        Cursor = Cursors.WaitCursor
        PanelEx10.Enabled = False
        With GridView1
            CmbBorrower.Enabled = False
            ID = .GetFocusedRowCellValue("ID")
            CmbBorrower.SelectedValue = .GetFocusedRowCellValue("CreditNumber")
            CmbBorrower.Text = .GetFocusedRowCellValue("Borrower")
            CmbBorrower.Tag = .GetFocusedRowCellValue("Borrower")
            If IsDBNull(.GetFocusedRowCellValue("Notarial Date")) Then
                DtpNotarial.Value = Date.Now
                DtpNotarial.Tag = Date.Now
            Else
                DtpNotarial.Value = .GetFocusedRowCellValue("Notarial Date")
                DtpNotarial.Tag = .GetFocusedRowCellValue("Notarial Date")
            End If
            DblNotarial.Value = .GetFocusedRowCellValue("Notarial Amount")
            DblNotarial.Tag = .GetFocusedRowCellValue("Notarial Amount")
            CmbNotarial.Text = .GetFocusedRowCellValue("Notarial Processor ID")
            CmbNotarial.Tag = .GetFocusedRowCellValue("Notarial Processor ID")
            TxtNotarial.Text = .GetFocusedRowCellValue("NotarialRemarks")
            TxtNotarial.Tag = .GetFocusedRowCellValue("NotarialRemarks")
            If IsDBNull(.GetFocusedRowCellValue("BIR Date")) Then
                DtpBIR.Value = Date.Now
                DtpBIR.Tag = Date.Now
            Else
                DtpBIR.Value = .GetFocusedRowCellValue("BIR Date")
                DtpBIR.Tag = .GetFocusedRowCellValue("BIR Date")
            End If
            DblBIR.Value = .GetFocusedRowCellValue("BIR Amount")
            DblBIR.Tag = .GetFocusedRowCellValue("BIR Amount")
            CmbBIR.Text = .GetFocusedRowCellValue("BIR Processor ID")
            CmbBIR.Tag = .GetFocusedRowCellValue("BIR Processor ID")
            TxtBIR.Text = .GetFocusedRowCellValue("BIRRemarks")
            TxtBIR.Tag = .GetFocusedRowCellValue("BIRRemarks")
            If IsDBNull(.GetFocusedRowCellValue("RD Date")) Then
                DtpRD.Value = Date.Now
                DtpRD.Tag = Date.Now
            Else
                DtpRD.Value = .GetFocusedRowCellValue("RD Date")
                DtpRD.Tag = .GetFocusedRowCellValue("RD Date")
            End If
            DblRD.Value = .GetFocusedRowCellValue("RD Amount")
            DblRD.Tag = .GetFocusedRowCellValue("RD Amount")
            CmbRD.Text = .GetFocusedRowCellValue("RD Processor ID")
            CmbRD.Tag = .GetFocusedRowCellValue("RD Processor ID")
            TxtRD.Text = .GetFocusedRowCellValue("RDRemarks")
            TxtRD.Tag = .GetFocusedRowCellValue("RDRemarks")
            If IsDBNull(.GetFocusedRowCellValue("LTO Date")) Then
                DtpLTO.Value = Date.Now
                DtpLTO.Tag = Date.Now
            Else
                DtpLTO.Value = .GetFocusedRowCellValue("LTO Date")
                DtpLTO.Tag = .GetFocusedRowCellValue("LTO Date")
            End If
            DblLTO.Value = .GetFocusedRowCellValue("LTO Amount")
            DblLTO.Tag = .GetFocusedRowCellValue("LTO Amount")
            CmbLTO.Text = .GetFocusedRowCellValue("LTO Processor ID")
            CmbLTO.Tag = .GetFocusedRowCellValue("LTO Processor ID")
            TxtLTO.Text = .GetFocusedRowCellValue("LTORemarks")
            TxtLTO.Tag = .GetFocusedRowCellValue("LTORemarks")
            TxtNote.Text = .GetFocusedRowCellValue("Encumbered Note")
            TxtNote.Tag = .GetFocusedRowCellValue("Encumbered Note")
        End With

        SuperTabControl1.SelectedTab = tabSetup
        Dim EncumberedDateExist As Integer = DataObject(String.Format("SELECT ID FROM credit_encumbered WHERE ID = '{0}' AND `status` = 'ENCUMBERED';", ID))
        If EncumberedDateExist > 0 Then
            BtnModify.Enabled = False
            BtnEncumbered.Enabled = False
        Else
            BtnModify.Enabled = True
            BtnEncumbered.Enabled = True
        End If
        BtnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= " ce.ID,"
        SQL &= " ce.CreditNumber,"
        SQL &= " CONCAT(IF(ca.AssumptionCredit = '',CONCAT(IF(ca.FirstN_B = '','',CONCAT(ca.FirstN_B, ' ')),"
        SQL &= " IF(ca.MiddleN_B = '','',CONCAT(ca.MiddleN_B, ' ')), IF(ca.LastN_B = '','',CONCAT(ca.LastN_B, ' ')), ca.Suffix_B), CONCAT(IF(ca.FirstN_A = '','',CONCAT(ca.FirstN_A, ' ')),"
        SQL &= " IF(ca.MiddleN_A = '','',CONCAT(ca.MiddleN_A, ' ')), IF(ca.LastN_A = '','',CONCAT(ca.LastN_A, ' ')), ca.Suffix_A)), ' [',CONCAT(IF(ca.CompromiseAgreement > 0,'CA',''),"
        SQL &= " IF(ca.PaymentArrangement > 0,'PA',''), ce.CreditNumber),']') AS 'Borrower',"
        SQL &= " DATE_FORMAT(ce.NotarialDate, '%M %d, %Y') AS 'Notarial Date',"
        SQL &= " FORMAT(ce.NotarialAmount,2) AS 'Notarial Amount',"
        SQL &= " Employee(ce.NotarialProcessorID) AS 'Notarial Processor ID',"
        SQL &= " ce.NotarialRemarks,"
        SQL &= " DATE_FORMAT(ce.BIRDate, '%M %d, %Y') AS 'BIR Date',"
        SQL &= " FORMAT(ce.BIRAmount,2) AS 'BIR Amount',"
        SQL &= " Employee(ce.BIRProcessorID) AS 'BIR Processor ID',"
        SQL &= " ce.BIRRemarks,"
        SQL &= " DATE_FORMAT(ce.RDDate, '%M %d, %Y') AS 'RD Date',"
        SQL &= " FORMAT(ce.RDAmount,2) AS 'RD Amount',"
        SQL &= " Employee(ce.RDProcessorID) AS 'RD Processor ID',"
        SQL &= " ce.RDRemarks,"
        SQL &= " DATE_FORMAT(ce.LTODate, '%M %d, %Y') AS 'LTO Date',"
        SQL &= " FORMAT(ce.LTOAmount,2) AS 'LTO Amount',"
        SQL &= " Employee(ce.LTOProcessorID) AS 'LTO Processor ID',"
        SQL &= " ce.LTORemarks,"
        SQL &= " DATE_FORMAT(ce.EncumberedDate, '%M %d, %Y') AS 'Encumbered Date',"
        SQL &= " DATE_FORMAT(ca.Released, '%M %d, %Y') AS 'Released Date',"
        SQL &= " ce.EncumberedNote AS 'Encumbered Note',"
        SQL &= " Branch(ce.branch_id) AS 'Branch'"
        SQL &= String.Format("  FROM credit_encumbered ce INNER JOIN credit_application ca ON ce.`CreditNumber` = ca.`CreditNumber` WHERE ce.`status` in ('ACTIVE', 'ENCUMBERED') AND ce.branch_id IN ({0}) ORDER BY Borrower;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        GridControl1.DataSource = DataSource(SQL)
        If Multiple_ID.Contains(",") Then
            GridColumn21.Visible = True
            GridColumn21.VisibleIndex = 17
        End If
        GridView1.Columns("Borrower").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Borrower").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If Branch_ID = 0 Or (MultipleBranch And Multiple_ID <> "") Then
            GridColumn21.Visible = True
        Else
            GridColumn21.Visible = False
        End If

        If GridView1.RowCount > 22 Then
            GridColumn3.Width = 300 - 17
        Else
            GridColumn3.Width = 300
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CmbBorrower_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBorrower.SelectedIndexChanged
        Dim SQL As String
        If FirstLoad Or CmbBorrower.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(CmbBorrower.SelectedItem, DataRowView)
        If drv("mortgage_id") = 1 Then
            SQL = String.Format("SELECT CONCAT(Make, ' ', Model, ' ', PlateNum) AS 'Detail' FROM collateral_ve WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE' AND CINumber != '';", CmbBorrower.SelectedValue)
        Else
            SQL = String.Format("SELECT CONCAT(TCT, ' ', Location, ' (',`Area`,') sqm') AS 'Detail' FROM collateral_re WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE' AND CINumber != '';", CmbBorrower.SelectedValue)
        End If

        LblCollateral.Text = DataObject(SQL)

    End Sub

    Private Sub CmbBorrower_TextChanged(sender As Object, e As EventArgs) Handles CmbBorrower.TextChanged
        If CmbBorrower.Text = "" Or CmbBorrower.SelectedIndex = -1 Then
            LblCollateral.Text = ""
            DtpNotarial.Enabled = False
            DtpBIR.Enabled = False
            DtpRD.Enabled = False
            DtpLTO.Enabled = False
            DblNotarial.Enabled = False
            DblBIR.Enabled = False
            DblRD.Enabled = False
            DblLTO.Enabled = False
            CmbNotarial.Enabled = False
            CmbBIR.Enabled = False
            CmbRD.Enabled = False
            CmbLTO.Enabled = False
            TxtNotarial.Enabled = False
            TxtBIR.Enabled = False
            TxtRD.Enabled = False
            TxtLTO.Enabled = False
            TxtNote.Enabled = False
        Else
            DtpNotarial.Enabled = True
            DtpBIR.Enabled = True
            DtpRD.Enabled = True
            DtpLTO.Enabled = True
            DblNotarial.Enabled = True
            DblBIR.Enabled = True
            DblRD.Enabled = True
            DblLTO.Enabled = True
            CmbNotarial.Enabled = True
            CmbBIR.Enabled = True
            CmbRD.Enabled = True
            CmbLTO.Enabled = True
            TxtNotarial.Enabled = True
            TxtBIR.Enabled = True
            TxtRD.Enabled = True
            TxtLTO.Enabled = True
            TxtNote.Enabled = True
        End If
    End Sub

    Private Sub Clear(TriggerLoadData As Boolean)
        PanelEx10.Enabled = True
        CmbBorrower.SelectedIndex = -1
        LoadDropDownData()
        CmbBorrower.Enabled = True
        CmbNotarial.Text = ""
        CmbBIR.Text = ""
        CmbRD.Text = ""
        CmbLTO.Text = ""
        DblNotarial.Value = 0
        DblBIR.Value = 0
        DblLTO.Value = 0
        DblRD.Value = 0
        TxtNotarial.Text = ""
        TxtBIR.Text = ""
        TxtLTO.Text = ""
        TxtRD.Text = ""
        TxtNote.Text = ""
        DtpNotarial.Value = Date.Now
        DtpBIR.Value = Date.Now
        DtpRD.Value = Date.Now
        DtpLTO.Value = Date.Now
        BtnSave.Text = "&Save"
        BtnSave.Enabled = True
        BtnModify.Enabled = False
        BtnDelete.Enabled = False
        BtnEncumbered.Enabled = false

        If TriggerLoadData Then
            LoadData()
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
                Clear(False)
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            LoadData()
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles BtnBack.Click
        If SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabSetup
            LoadDropDownData()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SuperTabControl1.SelectedTab = tabList
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Then
            BtnBack.Enabled = False
            BtnAdd.Enabled = False
            BtnSave.Enabled = True
            BtnModify.Enabled = False
            BtnPrint.Enabled = False
            BtnDelete.Enabled = False
            BtnNext.Enabled = True
            BtnEncumbered.Enabled = False
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Clear(False)
            BtnBack.Enabled = True
            BtnAdd.Enabled = True
            BtnSave.Enabled = False
            BtnModify.Enabled = False
            BtnPrint.Enabled = True
            BtnDelete.Enabled = False
            BtnNext.Enabled = False
            BtnEncumbered.Enabled = False
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If BtnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim CreditAppStatus As String = DataObject(String.Format("SELECT PaymentRequest FROM credit_application WHERE CreditNumber = '{0}' AND  mortgage_ID IN (1,2) AND loan_type IN ('NEW', 'RELOAN') AND `status` = 'ACTIVE';", CmbBorrower.SelectedValue))
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM credit_encumbered WHERE CreditNumber = '{0}' and `status` = 'ACTIVE';", CmbBorrower.SelectedValue))
                If CreditAppStatus.Trim() = "RELEASED" And TxtNote.Text = "" Then
                    MsgBox("Payment Request is already released, Mandatory field to input a Note.", MsgBoxStyle.Information, "Info")
                    TxtNote.Select()
                Else
                    If Exist > 0 Then
                        MsgBox("Credit number already exist.", MsgBoxStyle.Information, "Info")
                    Else
                        Cursor = Cursors.WaitCursor
                        Dim SQL As String = "INSERT INTO credit_encumbered SET"
                        SQL &= String.Format(" CreditNumber = '{0}', ", CmbBorrower.SelectedValue)
                        If CmbNotarial.SelectedIndex = -1 Then
                            SQL &= String.Format(" NotarialDate = '{0}', ", DBNull.Value)
                        Else
                            SQL &= String.Format(" NotarialDate = '{0}', ", FormatDatePicker(DtpNotarial))
                        End If
                        SQL &= String.Format(" NotarialAmount = '{0}', ", DblNotarial.Value)
                        SQL &= String.Format(" NotarialProcessorID = '{0}', ", ValidateComboBox(CmbNotarial))
                        SQL &= String.Format(" NotarialRemarks = '{0}', ", TxtNotarial.Text)
                        If CmbBIR.SelectedIndex = -1 Then
                            SQL &= String.Format(" BIRDate = '{0}', ", DBNull.Value)
                        Else
                            SQL &= String.Format(" BIRDate = '{0}', ", FormatDatePicker(DtpBIR))
                        End If
                        SQL &= String.Format(" BIRAmount = '{0}', ", DblBIR.Value)
                        SQL &= String.Format(" BIRProcessorID = '{0}', ", ValidateComboBox(CmbBIR))
                        SQL &= String.Format(" BIRRemarks = '{0}', ", TxtBIR.Text)
                        If CmbRD.SelectedIndex = -1 Then
                            SQL &= String.Format(" RDDate = '{0}', ", DBNull.Value)
                        Else
                            SQL &= String.Format(" RDDate = '{0}', ", FormatDatePicker(DtpRD))
                        End If
                        SQL &= String.Format(" RDAmount = '{0}', ", DblRD.Value)
                        SQL &= String.Format(" RDProcessorID = '{0}', ", ValidateComboBox(CmbRD))
                        SQL &= String.Format(" RDRemarks = '{0}', ", TxtRD.Text)
                        If CmbLTO.SelectedIndex = -1 Then
                            SQL &= String.Format(" LTODate = '{0}', ", DBNull.Value)
                        Else
                            SQL &= String.Format(" LTODate = '{0}', ", FormatDatePicker(DtpLTO))
                        End If
                        SQL &= String.Format(" LTOAmount = '{0}', ", DblLTO.Value)
                        SQL &= String.Format(" LTOProcessorID = '{0}', ", ValidateComboBox(CmbLTO))
                        SQL &= String.Format(" LTORemarks = '{0}', ", TxtLTO.Text)
                        SQL &= String.Format(" EncumberedNote = '{0}', ", TxtNote.Text)
                        SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        DataObject(SQL)

                        Dim SQL1 As String = "UPDATE credit_application SET"
                        SQL1 &= String.Format(" encumbered_status = 'ENCUMBERED' ")
                        SQL1 &= String.Format(" WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE' AND encumbered_status is null;", CmbBorrower.SelectedValue)
                        DataObject(SQL1)

                        Logs("Encumbered/Annotation Monitoring", "Save", String.Format("Add new encumbered/annotation for {0}", CmbBorrower.Text), "", "", "", "")
                        LoadDropDownData()
                        Clear(True)
                        Cursor = Cursors.Default
                        MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                    End If
                End If
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE credit_encumbered SET"
                SQL &= String.Format(" CreditNumber = '{0}', ", CmbBorrower.SelectedValue)
                If CmbNotarial.SelectedIndex = -1 Then
                    SQL &= String.Format(" NotarialDate = '{0}', ", DBNull.Value)
                Else
                    SQL &= String.Format(" NotarialDate = '{0}', ", FormatDatePicker(DtpNotarial))
                End If
                SQL &= String.Format(" NotarialAmount = '{0}', ", DblNotarial.Value)
                SQL &= String.Format(" NotarialProcessorID = '{0}', ", ValidateComboBox(CmbNotarial))
                SQL &= String.Format(" NotarialRemarks = '{0}', ", TxtNotarial.Text)
                If CmbBIR.SelectedIndex = -1 Then
                    SQL &= String.Format(" BIRDate = '{0}', ", DBNull.Value)
                Else
                    SQL &= String.Format(" BIRDate = '{0}', ", FormatDatePicker(DtpBIR))
                End If
                SQL &= String.Format(" BIRAmount = '{0}', ", DblBIR.Value)
                SQL &= String.Format(" BIRProcessorID = '{0}', ", ValidateComboBox(CmbBIR))
                SQL &= String.Format(" BIRRemarks = '{0}', ", TxtBIR.Text)
                If CmbRD.SelectedIndex = -1 Then
                    SQL &= String.Format(" RDDate = '{0}', ", DBNull.Value)
                Else
                    SQL &= String.Format(" RDDate = '{0}', ", FormatDatePicker(DtpRD))
                End If
                SQL &= String.Format(" RDAmount = '{0}', ", DblRD.Value)
                SQL &= String.Format(" RDProcessorID = '{0}', ", ValidateComboBox(CmbRD))
                SQL &= String.Format(" RDRemarks = '{0}', ", TxtRD.Text)
                If CmbLTO.SelectedIndex = -1 Then
                    SQL &= String.Format(" LTODate = '{0}', ", DBNull.Value)
                Else
                    SQL &= String.Format(" LTODate = '{0}', ", FormatDatePicker(DtpLTO))
                End If
                SQL &= String.Format(" LTOAmount = '{0}', ", DblLTO.Value)
                SQL &= String.Format(" LTOProcessorID = '{0}', ", ValidateComboBox(CmbLTO))
                SQL &= String.Format(" LTORemarks = '{0}', ", TxtLTO.Text)
                SQL &= String.Format(" EncumberedNote = '{0}' ", TxtNote.Text)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)
                DataObject(SQL)

                Logs("Encumbered/Annotation Monitoring", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnModify_Click(sender As Object, e As EventArgs) Handles BtnModify.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mModify) = MsgBoxResult.Yes Then
            BtnSave.Text = "Update"
            BtnSave.Enabled = True
            BtnModify.Enabled = False
            BtnDelete.Enabled = True
            PanelEx10.Enabled = True
            DtpNotarial.Enabled = True
            DtpBIR.Enabled = True
            DtpRD.Enabled = True
            DtpLTO.Enabled = True
            DblNotarial.Enabled = True
            DblBIR.Enabled = True
            DblRD.Enabled = True
            DblLTO.Enabled = True
            CmbNotarial.Enabled = True
            CmbBIR.Enabled = True
            CmbRD.Enabled = True
            CmbLTO.Enabled = True
            TxtNotarial.Enabled = True
            TxtBIR.Enabled = True
            TxtRD.Enabled = True
            TxtLTO.Enabled = True
            TxtNote.Enabled = True
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If vDelete Then
        Else
            MsgBox(mBox_Delete, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            DataObject(String.Format("UPDATE credit_application SET encumbered_status = NULL WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", CmbBorrower.SelectedValue))
            DataObject(String.Format("UPDATE credit_encumbered SET `status` = 'DELETED' WHERE CreditNumber = '{0}' AND ID = '{1}';", CmbBorrower.SelectedValue, ID))
            Logs("Encumbered/Annotation Monitoring", "Cancel", Reason, String.Format("Cancel borrower {0}.", CmbBorrower.Text), "", "", "")
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        GridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting("ENCUMBERED/ANNOTATION MONITORING LIST", GridControl1)
        Logs("Encumbered/Annotation Monitoring", "Print", "[SENSITIVE] Print Encumbered/Annotation Monitoring List", "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If CmbBorrower.Text = CmbBorrower.Tag Then
            Else
                Change &= String.Format("Change Borrower from {0} to {1}. ", CmbBorrower.Tag.ToString.Trim.InsertQuote, CmbBorrower.Text.Trim.InsertQuote)
            End If
            If CmbNotarial.Text = CmbNotarial.Tag Then
            Else
                Change &= String.Format("Change Notarial Processor  from {0} to {1}. ", CmbNotarial.Tag.ToString.Trim.InsertQuote, CmbNotarial.Text.Trim.InsertQuote)
            End If
            If DtpNotarial.Text = DtpNotarial.Tag Then
            Else
                Change &= String.Format("Change Notarial Date from {0} to {1}. ", DtpNotarial.Tag, DtpNotarial.Text)
            End If
            If DblNotarial.Text = DblNotarial.Tag Then
            Else
                Change &= String.Format("Change Notarial Amount from {0} to {1}. ", DblNotarial.Tag, DblNotarial.Text)
            End If
            If TxtNotarial.Text = TxtNotarial.Tag Then
            Else
                Change &= String.Format("Change Notarial Remarks from {0} to {1}. ", TxtNotarial.Tag, TxtNotarial.Text)
            End If
            If CmbBIR.Text = CmbBIR.Tag Then
            Else
                Change &= String.Format("Change BIR Processor from {0} to {1}. ", CmbBIR.Tag.ToString.Trim.InsertQuote, CmbBIR.Text.Trim.InsertQuote)
            End If
            If DtpBIR.Text = DtpBIR.Tag Then
            Else
                Change &= String.Format("Change BIR Date from {0} to {1}. ", DtpBIR.Tag, DtpBIR.Text)
            End If
            If DblBIR.Text = DblBIR.Tag Then
            Else
                Change &= String.Format("Change BIR Amount from {0} to {1}. ", DblBIR.Tag, DblBIR.Text)
            End If
            If TxtBIR.Text = TxtBIR.Tag Then
            Else
                Change &= String.Format("Change BIR Remarks from {0} to {1}. ", TxtBIR.Tag, TxtBIR.Text)
            End If
            If CmbRD.Text = CmbRD.Tag Then
            Else
                Change &= String.Format("Change RD Processor from {0} to {1}. ", CmbRD.Tag.ToString.Trim.InsertQuote, CmbRD.Text.Trim.InsertQuote)
            End If
            If DtpRD.Text = DtpRD.Tag Then
            Else
                Change &= String.Format("Change RD Date from {0} to {1}. ", DtpRD.Tag, DtpRD.Text)
            End If
            If DblRD.Text = DblRD.Tag Then
            Else
                Change &= String.Format("Change RD Amount from {0} to {1}. ", DblRD.Tag, DblRD.Text)
            End If
            If TxtRD.Text = TxtRD.Tag Then
            Else
                Change &= String.Format("Change RD Remarks from {0} to {1}. ", TxtRD.Tag, TxtRD.Text)
            End If
            If CmbLTO.Text = CmbLTO.Tag Then
            Else
                Change &= String.Format("Change LTO Processor from {0} to {1}. ", CmbLTO.Tag.ToString.Trim.InsertQuote, CmbLTO.Text.Trim.InsertQuote)
            End If
            If DtpLTO.Text = DtpLTO.Tag Then
            Else
                Change &= String.Format("Change LTO Date from {0} to {1}. ", DtpLTO.Tag, DtpLTO.Text)
            End If
            If DblLTO.Text = DblLTO.Tag Then
            Else
                Change &= String.Format("Change LTO Amount from {0} to {1}. ", DblLTO.Tag, DblLTO.Text)
            End If
            If TxtLTO.Text = TxtLTO.Tag Then
            Else
                Change &= String.Format("Change LTO Remarks from {0} to {1}. ", TxtLTO.Tag, TxtLTO.Text)
            End If
            If TxtNote.Text = TxtNote.Tag Then
            Else
                Change &= String.Format("Change Encumbered Note from {0} to {1}. ", TxtNote.Tag, TxtNote.Text)
            End If

        Catch ex As Exception
            TriggerBugReport("Encumbered/Annotation Monitoring - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            BtnSave.Focus()
            BtnSave.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.B Then
            BtnBack.Focus()
            BtnBack.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.N Then
            BtnNext.Focus()
            BtnNext.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            BtnRefresh.Focus()
            BtnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            BtnCancel.Focus()
            BtnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            BtnPrint.Focus()
            BtnPrint.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            BtnDelete.Focus()
            BtnDelete.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.M Then
            BtnModify.Focus()
            BtnModify.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.A Then
            BtnAdd.Focus()
            BtnAdd.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.Left) Or (e.Control And e.KeyCode = Keys.Down) Then
            BtnBack.Focus()
            BtnBack.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.Right) Or (e.Control And e.KeyCode = Keys.Up) Then
            BtnNext.Focus()
            BtnNext.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub TxtNotarial_Leave(sender As Object, e As EventArgs) Handles TxtNotarial.Leave
        TxtNotarial.Text = ReplaceText(TxtNotarial.Text)
    End Sub

    Private Sub TxtBIR_Leave(sender As Object, e As EventArgs) Handles TxtBIR.Leave
        TxtBIR.Text = ReplaceText(TxtBIR.Text)
    End Sub

    Private Sub TxtRD_Leave(sender As Object, e As EventArgs) Handles TxtRD.Leave
        TxtRD.Text = ReplaceText(TxtRD.Text)
    End Sub

    Private Sub TxtLTO_Leave(sender As Object, e As EventArgs) Handles TxtLTO.Leave
        TxtLTO.Text = ReplaceText(TxtLTO.Text)
    End Sub

    Private Sub CmbNotarial_TextChanged(sender As Object, e As EventArgs) Handles CmbNotarial.TextChanged
        If CmbNotarial.SelectedIndex = -1 Then
            TxtNotarial.Enabled = False
        Else
            TxtNotarial.Enabled = True
        End If
    End Sub

    Private Sub CmbBIR_TextChanged(sender As Object, e As EventArgs) Handles CmbBIR.TextChanged
        If CmbBIR.SelectedIndex = -1 Then
            TxtBIR.Enabled = False
        Else
            TxtBIR.Enabled = True
        End If
    End Sub

    Private Sub CmbRD_TextChanged(sender As Object, e As EventArgs) Handles CmbRD.TextChanged
        If CmbRD.SelectedIndex = -1 Then
            TxtRD.Enabled = False
        Else
            TxtRD.Enabled = True
        End If
    End Sub

    Private Sub CmbLTO_TextChanged(sender As Object, e As EventArgs) Handles CmbLTO.TextChanged
        If CmbLTO.SelectedIndex = -1 Then
            TxtLTO.Enabled = False
        Else
            TxtLTO.Enabled = True
        End If
    End Sub

    Private Sub BtnEncumbered_Click(sender As Object, e As EventArgs) Handles BtnEncumbered.Click
        Dim encumberedDate As New FrmDate
        If CmbNotarial.SelectedIndex = -1 Or CmbBIR.SelectedIndex = -1 Or CmbRD.SelectedIndex = -1 Or CmbLTO.SelectedIndex = -1 Then
            If MsgBoxYes(String.Format("Some Documents are Lacking:{4}{4}Notarial: {0}{4}BIR: {1}{4}RD: {2}{4}LTO: {3}{4}{4}Would you like to process data to encumbered?", NotarialLack(), BIRLack(), RDLack(), LTOLack(), Environment.NewLine)) = MsgBoxResult.Yes Then
                With encumberedDate
                    .btnClear.Text = "Save"
                    .lblTitle.Text = "Encumbered/Annotation"
                    .lblDeposit.Text = "Encumbered Date"

                    If .ShowDialog() = DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        Dim SQL As String = "UPDATE credit_encumbered SET"
                        SQL &= String.Format(" EncumberedDate = '{0}', ", FormatDatePicker(.dtpClear))
                        SQL &= String.Format(" `status` = 'ENCUMBERED' ")
                        SQL &= String.Format(" WHERE CreditNumber = '{0}' AND ID = '{1}' AND `status` = 'ACTIVE';", CmbBorrower.SelectedValue, ID)
                        DataObject(SQL)

                        Cursor = Cursors.Default
                        Clear(True)
                        MsgBox("Date Encumbered Successfully!", MsgBoxStyle.Information, "Info")
                    End If
                End With

            End If
        Else
            With encumberedDate
                .btnClear.Text = "Save"
                .lblTitle.Text = "Encumbered/Annotation"
                .lblDeposit.Text = "Encumbered Date"

                If .ShowDialog() = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    Dim SQL As String = "UPDATE credit_encumbered SET"
                    SQL &= String.Format(" EncumberedDate = '{0}', ", FormatDatePicker(.dtpClear))
                    SQL &= String.Format(" `status` = 'ENCUMBERED' ")
                    SQL &= String.Format(" WHERE CreditNumber = '{0}' AND ID = '{1}' AND `status` = 'ACTIVE';", CmbBorrower.SelectedValue, ID)
                    DataObject(SQL)

                    Cursor = Cursors.Default
                    Clear(True)
                    MsgBox("Date Encumbered Successfully!", MsgBoxStyle.Information, "Info")
                End If

            End With
        End If
    End Sub

    Private Function NotarialLack()
        Dim Lacking As String = ""
        If CmbNotarial.SelectedIndex = -1 Then
            Lacking = "Lacking"
        Else
            Lacking = "Completed"
        End If
        Return Lacking
    End Function

    Private Function BIRLack()
        Dim Lacking As String = ""
        If CmbBIR.SelectedIndex = -1 Then
            Lacking = "Lacking"
        Else
            Lacking = "Completed"
        End If
        Return Lacking
    End Function

    Private Function RDLack()
        Dim Lacking As String = ""
        If CmbRD.SelectedIndex = -1 Then
            Lacking = "Lacking"
        Else
            Lacking = "Completed"
        End If
        Return Lacking
    End Function

    Private Function LTOLack()
        Dim Lacking As String = ""
        If CmbLTO.SelectedIndex = -1 Then
            Lacking = "Lacking"
        Else
            Lacking = "Completed"
        End If
        Return Lacking
    End Function

    Private Sub TxtNote_Leave(sender As Object, e As EventArgs) Handles TxtNote.Leave
        TxtNote.Text = ReplaceText(TxtNote.Text)
    End Sub

End Class