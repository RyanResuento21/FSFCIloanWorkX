Public Class FrmUnpostedList

    Public vDate As Date
    Public vBranchID As Integer
    Private Sub FrmUnpostedList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        LoadData()
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

            GetButtonFontSettings({btnCheck, btnCancel, btnPrint})
        Catch ex As Exception
            TriggerBugReport("Unposted - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Unposted Transactions", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Dim SQL As String = String.Format(" SELECT ID, Payee AS 'Name', DocumentNumber AS 'Document Number', DATE_FORMAT(DocumentDate,'%M %d, %Y') AS 'Document Date', DATE_FORMAT(PostingDate,'%M %d, %Y') AS 'Posting Date', 'Journal Voucher' AS 'From' FROM journal_voucher WHERE `status` = 'ACTIVE' AND voucher_status != 'APPROVED' AND Branch_ID = '{0}' AND MONTH(PostingDate) = '{1}'  AND YEAR(PostingDate) = '{2}' UNION ALL", vBranchID, Format(vDate, "MM"), Format(vDate, "yyyy"))
        SQL &= String.Format(" SELECT ID, Payee AS 'Name', DocumentNumber AS 'Document Number', DATE_FORMAT(DocumentDate,'%M %d, %Y') AS 'Document Date', DATE_FORMAT(PostingDate,'%M %d, %Y') AS 'Posting Date', 'Check Voucher' AS 'From' FROM check_voucher WHERE `status` = 'ACTIVE' AND voucher_status NOT IN ('APPROVED','RECEIVED') AND Branch_ID = '{0}' AND MONTH(PostingDate) = '{1}'  AND YEAR(PostingDate) = '{2}' UNION ALL", vBranchID, Format(vDate, "MM"), Format(vDate, "yyyy"))
        SQL &= String.Format(" SELECT ID, Payee AS 'Name', DocumentNumber AS 'Document Number', DATE_FORMAT(DocumentDate,'%M %d, %Y') AS 'Document Date', DATE_FORMAT(PostingDate,'%M %d, %Y') AS 'Posting Date', 'Acknowledgement Receipt' AS 'From' FROM acknowledgement_receipt WHERE `status` = 'ACTIVE' AND voucher_status != 'APPROVED' AND Branch_ID = '{0}' AND MONTH(PostingDate) = '{1}'  AND YEAR(PostingDate) = '{2}' UNION ALL", vBranchID, Format(vDate, "MM"), Format(vDate, "yyyy"))
        SQL &= String.Format(" SELECT ID, Payee AS 'Name', DocumentNumber AS 'Document Number', DATE_FORMAT(DocumentDate,'%M %d, %Y') AS 'Document Date', DATE_FORMAT(PostingDate,'%M %d, %Y') AS 'Posting Date', 'Official Receipt' AS 'From' FROM official_receipt WHERE `status` = 'ACTIVE' AND voucher_status != 'APPROVED' AND Branch_ID = '{0}' AND MONTH(PostingDate) = '{1}'  AND YEAR(PostingDate) = '{2}' UNION ALL", vBranchID, Format(vDate, "MM"), Format(vDate, "yyyy"))
        SQL &= String.Format(" SELECT ID, Payee AS 'Name', DocumentNumber AS 'Document Number', DATE_FORMAT(DocumentDate,'%M %d, %Y') AS 'Document Date', DATE_FORMAT(PostingDate,'%M %d, %Y') AS 'Posting Date', 'Accounts Payable' AS 'From' FROM accounts_payable WHERE `status` = 'ACTIVE' AND ap_status NOT IN ('APPROVED','PARTIALLY PAID','FULLY PAID') AND Branch_ID = '{0}' AND MONTH(PostingDate) = '{1}'  AND YEAR(PostingDate) = '{2}' UNION ALL", vBranchID, Format(vDate, "MM"), Format(vDate, "yyyy"))
        SQL &= String.Format(" SELECT ID, Payor AS 'Name', DocumentNumber AS 'Document Number', DATE_FORMAT(DocumentDate,'%M %d, %Y') AS 'Document Date', DATE_FORMAT(PostingDate,'%M %d, %Y') AS 'Posting Date', 'Accounts Receivable' AS 'From' FROM accounts_receivable WHERE `status` = 'ACTIVE' AND ar_status NOT IN ('APPROVED','PARTIALLY PAID','FULLY PAID') AND Branch_ID = '{0}' AND MONTH(PostingDate) = '{1}'  AND YEAR(PostingDate) = '{2}'", vBranchID, Format(vDate, "MM"), Format(vDate, "yyyy"))

        GridControl1.DataSource = DataSource(SQL)

        If GridView1.RowCount > 21 Then
            GridColumn2.Width = 296 - 17
        Else
            GridColumn2.Width = 296
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub BtnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.GetFocusedRowCellValue("From") = "Journal Voucher" Then
            'J O U R N A L   V O U C H E R ***************************************************************************************
            Dim JV As New FrmJournalVoucher
            With JV
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

                Logs("Unposted Transactions", "Check", "Journal Voucher", "", "", "", "")
                .From_GL = True
                .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("Document Number")
                .Skip_FilterLoadData = True
                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                End If
                .Dispose()
            End With
            'J O U R N A L   V O U C H E R ***************************************************************************************

        ElseIf GridView1.GetFocusedRowCellValue("From") = "Check Voucher" Then
            'C H E C K   V O U C H E R ***************************************************************************************
            Dim CV As New FrmCheckVoucher
            With CV
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

                Logs("Unposted Transactions", "Check", "Check Voucher", "", "", "", "")
                .From_GeneralLedger = True
                .AccountNumber = GridView1.GetFocusedRowCellValue("Document Number")
                .Skip_FilterLoadData = True
                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                End If
                .Dispose()
            End With
            'C H E C K   V O U C H E R ***************************************************************************************

        ElseIf GridView1.GetFocusedRowCellValue("From") = "Acknowledgement Receipt" Then
            'A C K N O W L E D G E M E N T   R E C E I P T ***************************************************************************************
            Dim ACR As New FrmAcknowledgement
            With ACR
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

                Logs("Unposted Transactions", "Check", "Acknowledgement Receipt", "", "", "", "")
                .From_GL = True
                .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("Document Number")
                .Skip_FilterLoadData = True
                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                End If
                .Dispose()
            End With
            'A C K N O W L E D G E M E N T   R E C E I P T ***************************************************************************************

        ElseIf GridView1.GetFocusedRowCellValue("From") = "Accounts Payable" Then
            'A C C O U N T S    P A Y A B L E ***************************************************************************************
            Dim AP As New FrmAccountsPayable
            With AP
                .Tag = 89
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

                Logs("Unposted Transactions", "Check", "Accounts Payable", "", "", "", "")
                .From_GL = True
                .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("Document Number")
                .Skip_FilterLoadData = True
                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                End If
                .Dispose()
            End With
            'A C C O U N T S    P A Y A B L E ***************************************************************************************

        ElseIf GridView1.GetFocusedRowCellValue("From") = "Accounts Receivable" Then
            'A C C O U N T S    R E C E I V A B L E ***************************************************************************************
            Dim AR As New FrmAccountsReceivable
            With AR
                .Tag = 90
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

                Logs("Unposted Transactions", "Check", "Accounts Receivable", "", "", "", "")
                .From_GL = True
                .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("Document Number")
                .Skip_FilterLoadData = True
                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                End If
                .Dispose()
            End With
            'A C C O U N T S  R E C E I V A B L E ***************************************************************************************
        ElseIf GridView1.GetFocusedRowCellValue("From") = "Official Receipt" Then
            'O F F I C I A L   R E C E I P T ***************************************************************************************
            Dim Official As New FrmOfficialReceipt
            With Official
                .Tag = 99
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

                Logs("Unposted Transactions", "Check", "Official Receipt", "", "", "", "")
                .From_GL = True
                .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("Document Number")
                .Skip_FilterLoadData = True
                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                End If
                .Dispose()
            End With
            'O F F I C I A L   R E C E I P T ***************************************************************************************

        ElseIf GridView1.GetFocusedRowCellValue("From") = "Due From" Then
            'D U E    F R O M ***************************************************************************************
            Dim AR As New FrmDueFrom
            With AR
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

                Logs("Unposted Transactions", "Check", "Due From", "", "", "", "")
                .From_GL = True
                .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("Document Number")
                .Skip_FilterLoadData = True
                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                End If
                .Dispose()
            End With
            'D U E    F R O M ***************************************************************************************
        ElseIf GridView1.GetFocusedRowCellValue("From") = "Due To" Then
            'D U E    T O ***************************************************************************************
            Dim AR As New FrmDueTo
            With AR
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

                Logs("Unposted Transactions", "Check", "Due To", "", "", "", "")
                .From_GL = True
                .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("Document Number")
                .Skip_FilterLoadData = True
                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                End If
                .Dispose()
            End With
            'D U E     T O ***************************************************************************************
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        GridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting("UNPOSTED TRANSACTION LIST FOR " & Format(vDate, "MMMM yyyy").ToUpper, GridControl1)
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.E Then
            btnCheck.Focus()
            btnCheck.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        btnCheck.PerformClick()
    End Sub
End Class