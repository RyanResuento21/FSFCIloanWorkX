Public Class FrmAddCollection

    Public From_Cash As Boolean
    Public ExcludeID As String
    Private Sub FrmAddCollection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView3})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        Dim SQL As String
        If From_Cash Then
            SQL = "SELECT"
            SQL &= "    ID,"
            SQL &= "    DATE_FORMAT(DocumentDate, '%M %d, %Y') AS 'Document Date',"
            SQL &= "    DocumentNumber AS 'Document Number',"
            SQL &= "    Explanation,"
            SQL &= "    Payee AS 'Payor',"
            SQL &= "    Amount AS 'Amount', "
            SQL &= "    IF(DepositDate = '','ON HAND','DEPOSITED') AS 'Status' "
            SQL &= " FROM official_receipt WHERE `status` = 'ACTIVE' "
            SQL &= String.Format("    AND voucher_status = 'APPROVED' AND CollectionNumber = '' AND Type_Payment = 'Cash' AND Branch_ID = '{0}' AND DocumentNumber NOT IN ({1})", Branch_ID, If(ExcludeID = "", 1, ExcludeID))
            SQL &= " UNION ALL SELECT"
            SQL &= "    ID,"
            SQL &= "    DATE_FORMAT(DocumentDate, '%M %d, %Y') AS 'Document Date',"
            SQL &= "    DocumentNumber AS 'Document Number',"
            SQL &= "    Explanation,"
            SQL &= "    Payee AS 'Payor',"
            SQL &= "    Amount AS 'Amount', "
            SQL &= "    IF(DepositDate = '','ON HAND','DEPOSITED') AS 'Status' "
            SQL &= " FROM acknowledgement_receipt WHERE `status` = 'ACTIVE' "
            SQL &= String.Format("    AND voucher_status = 'APPROVED' AND CollectionNumber = '' AND Type_Payment = 'Cash' AND Branch_ID = '{0}' AND DocumentNumber NOT IN ({1});", Branch_ID, If(ExcludeID = "", 1, ExcludeID))
            GridColumn15.VisibleIndex = 5
            GridColumn16.VisibleIndex = 5
            GridColumn19.VisibleIndex = 5
            GridColumn22.VisibleIndex = 5
            GridColumn23.VisibleIndex = 5
            GridColumn1.VisibleIndex = 5
        Else
            SQL = "SELECT"
            SQL &= "    ID,"
            SQL &= "    DATE_FORMAT(DocumentDate, '%M %d, %Y') AS 'Document Date',"
            SQL &= "    DocumentNumber AS 'Document Number',"
            SQL &= "    CONCAT(IF(CheckNumber = '',CONCAT('[Deposit Number: ',DepositNumber, '] [Deposit Date: ', DATE_FORMAT(DepositDate, '%M %d, %Y'),']'),CONCAT('[Check Number: ',CheckNumber, '] [Check Date: ', DATE_FORMAT(CheckDate, '%M %d, %Y'),']')), ' ',Explanation) AS 'Explanation',"
            SQL &= "    Payee AS 'Payor',"
            SQL &= "    Amount AS 'Amount' "
            SQL &= " FROM official_receipt WHERE `status` = 'ACTIVE' "
            SQL &= String.Format("    AND voucher_status = 'APPROVED' AND CollectionNumber = '' AND Type_Payment != 'Cash' AND Branch_ID = '{0}' AND DocumentNumber NOT IN ({1})", Branch_ID, If(ExcludeID = "", 1, ExcludeID))
            SQL &= " UNION ALL SELECT"
            SQL &= "    ID,"
            SQL &= "    DATE_FORMAT(DocumentDate, '%M %d, %Y') AS 'Document Date',"
            SQL &= "    DocumentNumber AS 'Document Number',"
            SQL &= "    CONCAT(IF(CheckNumber = '',CONCAT('[Deposit Number: ',DepositNumber, '] [Deposit Date: ', DATE_FORMAT(DepositDate, '%M %d, %Y'),']'),CONCAT('[Check Number: ',CheckNumber, '] [Check Date: ', DATE_FORMAT(CheckDate, '%M %d, %Y'),']')), ' ',Explanation) AS 'Explanation',"
            SQL &= "    Payee AS 'Payor',"
            SQL &= "    Amount AS 'Amount' "
            SQL &= " FROM acknowledgement_receipt WHERE `status` = 'ACTIVE' "
            SQL &= String.Format("    AND voucher_status = 'APPROVED' AND CollectionNumber = '' AND Type_Payment != 'Cash' AND Branch_ID = '{0}' AND DocumentNumber NOT IN ({1});", Branch_ID, If(ExcludeID = "", 1, ExcludeID))
            GridColumn1.VisibleIndex = -1
        End If
        GridControl3.DataSource = DataSource(SQL)
        If GridView3.RowCount > 0 Then
            btnAdd.Enabled = True
        End If

        If From_Cash Then
            If GridView3.RowCount > 9 Then
                GridColumn19.Width = 486 - 17
            Else
                GridColumn19.Width = 486
            End If
        Else
            If GridView3.RowCount > 9 Then
                GridColumn19.Width = 486 + 90 - 17
            Else
                GridColumn19.Width = 486 + 90
            End If
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX11})

            GetButtonFontSettings({btnAdd, btnAdd, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Add Collection - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.A Then
            btnAdd.Focus()
            btnAdd.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If btnAdd.DialogResult = DialogResult.OK Then
        Else
            If MsgBox("Are you sure you want to add this collection?", MsgBoxStyle.YesNo, "Info") Then
                btnAdd.DialogResult = DialogResult.OK
                btnAdd.PerformClick()
            End If
        End If
    End Sub

    Private Sub GridView3_DoubleClick(sender As Object, e As EventArgs) Handles GridView3.DoubleClick
        btnAdd.PerformClick()
    End Sub
End Class