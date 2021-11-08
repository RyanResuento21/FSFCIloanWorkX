Imports MySql.Data.MySqlClient
Imports System.Net.Mail
Imports System.IO
Imports iTextSharp.text.pdf
Module clsCommon
    'For Conversion
    Dim mOnesArray(8) As String
    Dim mOneTensArray(9) As String
    Dim mTensArray(7) As String
    Dim mPlaceValues(4) As String
    'Public AppPassword As String = "app_supp0rt"
    'Public AppEmailAddress As String = "app_support@firststandardfinancecorp.com"
    Public AppPassword As String
    Public AppEmailAddress As String
    Public AttachmentFiles As New ArrayList
    Private WithEvents Bw As New ComponentModel.BackgroundWorker
    Private WithEvents Bw_Backup As New ComponentModel.BackgroundWorker
    ReadOnly DT_Email As New DataTable
    ReadOnly SMTP As New SmtpClient()
    ReadOnly SMTP_Backup As New SmtpClient()
    ReadOnly N As New Random()

    Public Function GenerateOTAC()
        If OTACwithAlphabet And OTACCaseSensitive Then
            Return GenerateRandomStrings(OTACLength)
        ElseIf OTACwithAlphabet Then
            Return GenerateRandomStrings(OTACLength).ToString.ToUpper
        Else
            Return GenerateNumeric(OTACLength)
        End If
    End Function

    Public Function GetTime(Time As Integer) As String
        Dim Hrs As Integer  'number of hours   '
        Dim Min As Integer  'number of Minutes '
        Dim Sec As Integer  'number of Sec     '

        'Seconds'
        Sec = Time Mod 60

        'Minutes'
        Min = ((Time - Sec) / 60) Mod 60

        'Hours'
        Hrs = ((Time - (Sec + (Min * 60))) / 3600) Mod 60

        Return Format(Hrs, "00") & ":" & Format(Min, "00") & ":" & Format(Sec, "00")
    End Function

    Public Property MOnesArray1 As String()
        Get
            Return mOnesArray
        End Get
        Set(value As String())
            mOnesArray = value
        End Set
    End Property

    Public Property MOneTensArray1 As String()
        Get
            Return mOneTensArray
        End Get
        Set(value As String())
            mOneTensArray = value
        End Set
    End Property

    Public Property MTensArray1 As String()
        Get
            Return mTensArray
        End Get
        Set(value As String())
            mTensArray = value
        End Set
    End Property

    Public Property MPlaceValues1 As String()
        Get
            Return mPlaceValues
        End Get
        Set(value As String())
            mPlaceValues = value
        End Set
    End Property

    Public Sub Forms(Form As Form, PANEL As DevExpress.XtraEditors.PanelControl)
        Try
            PANEL.Controls.Clear()
            Threading.Thread.Sleep(100)
            With Form
                .TopLevel = False
                PANEL.Controls.Add(Form)
                .Size = PANEL.Size
                .Show()
                .BringToFront()
                .Focus()
                .Refresh()
                .AutoScroll = True
                .FormBorderStyle = FormBorderStyle.FixedSingle
            End With

            PANEL.Controls.Clear()
            With Form
                .TopLevel = False
                PANEL.Controls.Add(Form)
                .Size = PANEL.Size
                .Show()
                .BringToFront()
                .Focus()
                .Refresh()
                .AutoScroll = True
                .FormBorderStyle = FormBorderStyle.FixedSingle
            End With
        Catch ex As Exception
        End Try
    End Sub

    Public Sub FormatN2(DInput As DevComponents.Editors.DoubleInput)
        DInput.Tag = DInput.Value
        DInput.DisplayFormat = "n2"
    End Sub

    Public Sub FormatN4(DInput As DevComponents.Editors.DoubleInput)
        DInput.DisplayFormat = "n4"
        DInput.Value = DInput.Tag
    End Sub

    Public Function GetNullFromAllTables()
        Dim SQL As String = ""
        Dim DT As DataTable
        Dim DT_Tables As DataTable = DataSource("SHOW TABLES")
        For z As Integer = 0 To DT_Tables.Rows.Count - 1
            SQL &= String.Format("SELECT * FROM {0}", DT_Tables(z)(0))
            DT = DataSource(String.Format("SELECT * FROM {0} LIMIT 0", DT_Tables(z)(0)))
            For x As Integer = 0 To DT.Columns.Count - 1
                If x = 0 Then
                    SQL &= String.Format(" WHERE `{0}` IS NULL ", DT.Columns(x).ColumnName)
                Else
                    SQL &= String.Format(" OR `{0}` IS NULL ", DT.Columns(x).ColumnName)
                End If
            Next
            SQL &= ";" & vbCrLf
        Next
        Return SQL
    End Function

    Sub New()
        MOnesArray1(0) = "one"
        MOnesArray1(1) = "two"
        MOnesArray1(2) = "three"
        MOnesArray1(3) = "four"
        MOnesArray1(4) = "five"
        MOnesArray1(5) = "six"
        MOnesArray1(6) = "seven"
        MOnesArray1(7) = "eight"
        MOnesArray1(8) = "nine"

        mOneTensArray(0) = "ten"
        mOneTensArray(1) = "eleven"
        mOneTensArray(2) = "twelve"
        mOneTensArray(3) = "thirteen"
        mOneTensArray(4) = "fourteen"
        mOneTensArray(5) = "fifteen"
        mOneTensArray(6) = "sixteen"
        mOneTensArray(7) = "seventeen"
        mOneTensArray(8) = "eightteen"
        mOneTensArray(9) = "nineteen"

        MTensArray1(0) = "twenty"
        MTensArray1(1) = "thirty"
        MTensArray1(2) = "forty"
        MTensArray1(3) = "fifty"
        MTensArray1(4) = "sixty"
        MTensArray1(5) = "seventy"
        MTensArray1(6) = "eighty"
        MTensArray1(7) = "ninety"

        MPlaceValues1(0) = "hundred"
        MPlaceValues1(1) = "thousand"
        MPlaceValues1(2) = "million"
        MPlaceValues1(3) = "billion"
        MPlaceValues1(4) = "trillion"
    End Sub

    Public Function GetOnes(OneDigit As Integer) As String
        GetOnes = ""
        If OneDigit = 0 Then
            Exit Function
        End If

        GetOnes = MOnesArray1(OneDigit - 1)
    End Function

    Public Function Alphabet(Position As Integer) As String
        Dim Alp As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Return Alp.Substring(Position, 1)
    End Function

    Public Sub LoadCompanyMode()
        CompanyMode = DataObject(String.Format("SELECT ComMode FROM company WHERE ID = '{0}';", Company_ID))
    End Sub

    Public Function GetTens(TensDigit As Integer) As String
        GetTens = ""
        If TensDigit = 0 Or TensDigit = 1 Then
            Exit Function
        End If

        GetTens = MTensArray1(TensDigit - 2)
    End Function

    Public Function ConvertNumberToWords(NumberValue As String, Money As Boolean, WithPeso As Boolean) As String
        Dim Delimiter As String = " "
        Dim TensDelimiter As String = "-"
        Dim mNumberValue As String
        Dim mNumbers As String
        Dim mNumWord As String = ""
        Dim mFraction As String = ""
        Dim mNumberStack() As String = {}
        Dim j As Integer
        Dim i As Integer
        Dim mOneTens As Boolean = False

        ' validate input
        Try
            j = CDbl(NumberValue)
        Catch ex As Exception
            ConvertNumberToWords = ""
            Exit Function
        End Try

        ' get fractional part {if any}
        If InStr(NumberValue, ".") = 0 Then
            ' no fraction
            mNumberValue = NumberValue
        Else
            mNumberValue = Left(NumberValue, InStr(NumberValue, ".") - 1)
            mFraction = Mid(NumberValue, InStr(NumberValue, ".")) ' + 1)
            mFraction = Math.Round(CSng(mFraction), 2) * 100

            If CInt(mFraction) = 0 Then
                mFraction = ""
            Else
                mFraction = "&& " & mFraction & "/100 "
            End If
        End If
        mNumbers = mNumberValue.ToCharArray

        ' move numbers to stack/array backwards
        For j = mNumbers.Length - 1 To 0 Step -1
            ReDim Preserve mNumberStack(i)

            mNumberStack(i) = mNumbers(j)
            i += 1
        Next

        For j = mNumbers.Length - 1 To 0 Step -1
            Select Case j
                Case 0, 3, 6, 9, 12
                    ' ones  value
                    If Not mOneTens Then
                        If Val(mNumberStack(j)) <> 0 Then
                            mNumWord &= GetOnes(Val(mNumberStack(j))) & Delimiter
                        End If
                    End If

                    Select Case j
                        Case 3
                            If mNumWord.Length > MPlaceValues1(2).Length + 1 Then
                                If mNumWord.Substring(mNumWord.Length - (MPlaceValues1(2).Length + 1)) = MPlaceValues1(2) & Delimiter Then
                                Else
                                    If mNumWord.Length > MPlaceValues1(3).Length + 1 Then
                                        If mNumWord.Substring(mNumWord.Length - (MPlaceValues1(3).Length + 1)) = MPlaceValues1(3) & Delimiter Then
                                        Else
                                            ' thousands
                                            mNumWord &= MPlaceValues1(1) & Delimiter
                                        End If
                                    Else
                                        ' thousands
                                        mNumWord &= MPlaceValues1(1) & Delimiter
                                    End If
                                End If
                            Else
                                ' thousands
                                mNumWord &= MPlaceValues1(1) & Delimiter
                            End If

                        Case 6
                            If mNumWord.Length > MPlaceValues1(3).Length + 1 Then
                                If mNumWord.Substring(mNumWord.Length - (MPlaceValues1(3).Length + 1)) = MPlaceValues1(3) & Delimiter Then
                                Else
                                    ' millions
                                    mNumWord &= MPlaceValues1(2) & Delimiter
                                End If
                            Else
                                ' millions
                                mNumWord &= MPlaceValues1(2) & Delimiter
                            End If

                        Case 9
                            If mNumWord.Length > MPlaceValues1(4).Length + 1 Then
                                If mNumWord.Substring(mNumWord.Length - (MPlaceValues1(4).Length + 1)) = MPlaceValues1(4) & Delimiter Then
                                Else
                                    ' billions
                                    mNumWord &= MPlaceValues1(3) & Delimiter
                                End If
                            Else
                                ' billions
                                mNumWord &= MPlaceValues1(3) & Delimiter
                            End If

                        Case 12
                            ' trillions
                            mNumWord &= MPlaceValues1(4) & Delimiter
                    End Select


                Case 1, 4, 7, 10, 13
                    ' tens value
                    If Val(mNumberStack(j)) = 0 Then
                        If Val(mNumberStack(j - 1)) <> 0 Then
                            mNumWord &= GetOnes(Val(mNumberStack(j - 1))) & Delimiter
                            mOneTens = True
                            Exit Select
                        End If
                    End If

                    If Val(mNumberStack(j)) = 1 Then
                        mNumWord &= mOneTensArray(Val(mNumberStack(j - 1))) & Delimiter
                        mOneTens = True
                        Exit Select
                    End If

                    mNumWord &= GetTens(Val(mNumberStack(j)))

                    ' this places the tensdelimiter; check for succeeding 0
                    If Val(mNumberStack(j - 1)) <> 0 Then
                        mNumWord &= TensDelimiter
                    End If
                    mOneTens = False

                Case Else
                    ' hundreds value 
                    If Val(mNumberStack(j)) <> 0 Then
                        mNumWord &= GetOnes(Val(mNumberStack(j))) & Delimiter

                        mNumWord &= MPlaceValues1(0) & Delimiter
                    End If
            End Select
        Next
        If Money Then
            Return "** " & mNumWord & mFraction & "ONLY **"
        Else
            If WithPeso Then
                Return mNumWord & mFraction & "PESOS ONLY"
            Else
                Return mNumWord
            End If
        End If
    End Function

    Public Function UpperCaseFirst(xString As String) As String
        Return Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(xString.ToLower)
    End Function

    Public Function NegativeNotAllowed(Amount As Double)
        Return If(Amount < 0, 0, Amount)
    End Function

    Public Sub GetTemporaryAppPW(Mail As String)
        If Mail = "" Then
            AppEmailAddress = "iloanworkx.noreply@firststandard.ph"
            AppPassword = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\Documents\Read Me.txt")
        End If
    End Sub

    Public Function MustBeNumeric(Amount As String)
        Return If(IsNumeric(Amount), Amount, 0)
    End Function

    Public Function GetBalanceLedger(CreditNumber As String)
        Dim Ledger As New FrmAccountLedger
        Dim BalanceLedger As Double
        With Ledger
            .From_GetBalanceLedgerFunction = True
            .CreditNumber = CreditNumber
            .WindowState = FormWindowState.Minimized
            .Show()
            BalanceLedger = .GridView1.GetRowCellValue(.GridView1.RowCount - 1, "Total")
            .Dispose()
            Return BalanceLedger
        End With
    End Function

    Public Function GetBalancePrincipalInterest(CreditNumber As String)
        Dim Ledger As New FrmAccountLedger
        Dim PrincipalBalance As Double
        Dim InterestBalance As Double
        Dim LastTransaction As String = ""
        With Ledger
            .From_GetBalanceLedgerFunction = True
            .CreditNumber = CreditNumber
            .WindowState = FormWindowState.Minimized
            .Show()
            PrincipalBalance = .GridView1.GetRowCellValue(.GridView1.RowCount - 1, "Principal B")
            InterestBalance = .GridView1.GetRowCellValue(.GridView1.RowCount - 1, "UDI B")
            For x As Integer = 1 To .GridView1.RowCount
                If .GridView1.GetRowCellValue(.GridView1.RowCount - x, "Date").ToString = "" Then
                Else
                    LastTransaction = .GridView1.GetRowCellValue(.GridView1.RowCount - x, "Date")
                    Exit For
                End If
            Next
            .Dispose()
            Return {PrincipalBalance, InterestBalance, LastTransaction}
        End With
    End Function

    Public Function GetPrincipalInterestDue(CreditNumber As String, FaceAmount As Double, TermType As String, FromDate As Date, Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim PaymentDT As DataTable
        Dim RPPD_Application As Double
        Dim TotalWaiveRPPD As Double
        Dim TotalWaivePenalty As Double
        Dim TotalWaive As Double
        Dim TotalRPPD As Double
        Dim TotalRPPD_Payable As Double
        Dim TotalInterest As Double
        Dim TotalPayment As Double
        Dim TotalUnpaidPenalty As Double
        Dim Availed As Boolean
        Dim dPenalty_P As Double
        Dim dRPPD_P As Double
        Dim dUDI_P As Double
        Dim dUDI_P_Month As Double
        Dim dPrincipal_P As Double
        'Dim Payable_Interest As Double

        PaymentDT = DataSource(String.Format("SELECT IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W') THEN IF(Remarks LIKE '%[Reversal]%' OR EntryType = 'DEBIT',0 - Amount,Amount) END),0) AS 'Total RPPD', IFNULL(SUM(CASE WHEN PaidFor IN ('Penalty-W') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Penalty Payment', IFNULL((SELECT PenaltyPayable FROM accounting_entry A WHERE A.PaidFor IN ('Penalty','Penalty-W') AND A.`status` = 'ACTIVE' AND A.ReferenceN = '{0}' AND A.JVNumber = '' ORDER BY ID DESC LIMIT 1),0) AS 'Total Unpaid Penalty', IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('RPPD-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived RPPD', IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('Penalty-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived Penalty', IFNULL(SUM(CASE WHEN PaidFor = 'Principal' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Principal', IFNULL(SUM(CASE WHEN PaidFor = 'UDI' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Interest', IFNULL((SELECT MAX(IF(ARDate = '',IF(RemittanceDate = '',ORDate,RemittanceDate),ARDate)) FROM official_receipt WHERE Payee_ID = '{0}' AND `status` = 'ACTIVE' AND JVNumber = ''),IFNULL(MAX((CASE WHEN JVNum = '' AND JVNumber = '' THEN ORDate END)),ReleasedDate('{0}'))) AS 'Last Payment' FROM accounting_entry WHERE `status` IN ('ACTIVE','PENDING') AND PaidFor != 'Accounts Receivable' AND ReferenceN = '{0}';", CreditNumber))
        If PaymentDT.Rows.Count > 0 Then
            TotalRPPD = PaymentDT(0)("Total RPPD")
            TotalInterest = PaymentDT(0)("Total Interest")
            TotalPayment = PaymentDT(0)("Total Principal")
            TotalWaivePenalty = PaymentDT(0)("Total Penalty Payment")
            TotalWaive = PaymentDT(0)("Total Waived Penalty")
            TotalWaiveRPPD = PaymentDT(0)("Total Waived RPPD")
            TotalUnpaidPenalty = PaymentDT(0)("Total Unpaid Penalty")
            If TotalRPPD + TotalInterest + TotalPayment = 0 Then
                Availed = False
            Else
                Availed = True
            End If
        End If

        'TotalRPPD_Payable = 0
        'dRPPD_P = 0
        'dUDI_P = 0
        'dUDI_P_Month = 0
        'dPrincipal_P = 0
        'Payable_Interest = 0
        'RPPD_Application = 0
        If Availed = False And (TotalRPPD + TotalInterest + TotalPayment) = 0 Then
            If If(IsDate(Grid.GetRowCellValue(1, "Due Date")), CDate(Grid.GetRowCellValue(1, "Due Date")).AddDays(BankingDays(0, CDate(Grid.GetRowCellValue(1, "Due Date")))), Date.Now) >= DateValue(FromDate) Then
                Availed = True
            Else
                Availed = False
            End If
        End If
        For x As Integer = 1 To Grid.RowCount - 1
            If Grid.GetRowCellValue(x, "Due Date") = "" Or Grid.GetRowCellValue(x, "Due Date") = "TOTAL" Then
            Else
                RPPD_Application += Grid.GetRowCellValue(x, "RPPD")
                If FromDate > CDate(Grid.GetRowCellValue(x, "Due Date")).AddDays(BankingDays(If(Availed And TotalRPPD_Payable < CDbl(Grid.GetRowCellValue(x, "RPPD")), AvailedRPPD + 0, 0), CDate(Grid.GetFocusedRowCellValue("Due Date")))) Then
                    TotalRPPD_Payable += Grid.GetRowCellValue(x, "RPPD")
                End If
            End If
        Next
        'Dim AsOf As Date = FromDate
        For x As Integer = 1 To Grid.RowCount - 1
            If Grid.GetRowCellValue(x, "Due Date") = "" Or Grid.GetRowCellValue(x, "Due Date") = "TOTAL" Then
            Else
                If FromDate >= CDate(Grid.GetRowCellValue(x, "Due Date")) Then
                    Grid.FocusedRowHandle = x
                    'AsOf = FromDate
                    dUDI_P += Grid.GetRowCellValue(x, "Interest Income")
                    dPrincipal_P += Grid.GetRowCellValue(x, "Principal Allocation")
                ElseIf x = Grid.RowCount - 2 And FromDate < CDate(Grid.GetRowCellValue(1, "Due Date")) Then
                    Grid.FocusedRowHandle = 1
                    'AsOf = FromDate
                    dUDI_P += Grid.GetRowCellValue(1, "Interest Income")
                    dPrincipal_P += Grid.GetRowCellValue(1, "Principal Allocation")
                ElseIf x <= Grid.FocusedRowHandle And FromDate = Format(CDate(Grid.GetRowCellValue(x, "Due Date")), "yyyy-MM") And TermType <> "Daily" And TermType <> "Weekly" Then
                    dUDI_P += Grid.GetRowCellValue(1, "Interest Income")
                    dPrincipal_P += Grid.GetRowCellValue(1, "Principal Allocation")
                ElseIf FromDate < CDate(Grid.GetRowCellValue(x, "Due Date")) And Format(FromDate, "MMMM, yyyy") = Format(CDate(Grid.GetRowCellValue(x, "Due Date")), "MMMM, yyyy") Then 'FOR DEFERRED INCOME
                    dUDI_P_Month = (dUDI_P + Grid.GetRowCellValue(x, "Interest Income"))
                End If
            End If
            If x > Grid.FocusedRowHandle Then
                Exit For
            End If
        Next

        If FromDate > CDate(Grid.GetFocusedRowCellValue("Due Date")).AddDays(If(FaceAmount - (TotalPayment + TotalRPPD + TotalInterest) <= CDbl(Grid.GetRowCellValue(Grid.FocusedRowHandle - 1, "Loans Receivable")), If(Grid.FocusedRowHandle = 1 And (dPrincipal_P + dUDI_P + dRPPD_P) > 0, 0, BankingDays(If(Availed, AvailedRPPD + 0, 0), CDate(Grid.GetFocusedRowCellValue("Due Date")))), 0)) Or (TotalRPPD = 0 And dRPPD_P > 0) Then
        Else
            If dPenalty_P = 0 Then
                'TotalRPPD_Payable = NegativeNotAllowed(TotalRPPD_Payable - Grid.GetRowCellValue(1, "RPPD"))
            End If
        End If
        'If CompanyMode = 0 Then
        '    dRPPD_P = 0
        'Else
        '    dRPPD_P = NegativeNotAllowed((TotalRPPD_Payable - TotalRPPD) - TotalWaiveRPPD)
        'End If

        Dim dUDI_A As Double
        Dim dPrincipal_A As Double
        dUDI_A = dUDI_P - TotalInterest
        dUDI_P = NegativeNotAllowed(dUDI_P - TotalInterest)
        'dUDI_P_Month = NegativeNotAllowed(dUDI_P_Month - TotalInterest)
        dPrincipal_A = dPrincipal_P - TotalPayment
        dPrincipal_P = NegativeNotAllowed(dPrincipal_P - TotalPayment)

        Return {dPrincipal_P, dUDI_P}
    End Function

    Public Function GetUnpaidTerms(CreditNumber As String, FromDate As Date)
        Dim SOA As New FrmSOA
        Dim UnpaidTerm As Integer
        Dim UnpaidTermDays As Integer
        With SOA
            .From_JV_DTS = True
            .CreditNumber = CreditNumber
            .dtpAsOf.Value = FromDate
            .WindowState = FormWindowState.Minimized
            .Show()
            UnpaidTerm = .GridView1.RowCount
            UnpaidTermDays = .iDaysD.Value
            .Dispose()
        End With
        Return {UnpaidTerm, UnpaidTermDays}
    End Function

    Public Function ComputePenalty(Principal As Double, FaceAmount As Double, Released As String, GMA As Double, TotalPayment As Double, LastPayment As Date, Terms As Integer, ORDate As Date, TotalInterest As Double, TotalRPPD As Double, TotalUnpaidPenalty As Double, ProductID As Integer, PenaltyP As Double, Availed As Boolean, with_Interest As Boolean, FDD As String, Product_Payment As String, Product As String, TotalWaivePenalty As Double, InterestPayable As Double, RPPD As Double, TotalWaive As Double, TotalWaiveRPPD As Double, Grid As DevExpress.XtraGrid.GridControl, AvailedBanking As Boolean, LDD As String, CreditNumber As String)
        Dim SOA As New FrmSOA
        Dim Penalty As Double
        With SOA
            .From_Payment = True
            .From_OR = True
            .WindowState = FormWindowState.Minimized
            .Show()
            .FirstLoad = True
            .CreditNumber = CreditNumber
            .GridControl3.DataSource = Grid.DataSource
            '.Availed = Availed
            .Penalty_Percent = PenaltyP / 100
            .txtAccount.SelectedValue = ProductID
            .dPrincipal.Value = Principal
            .dFaceAmount.Value = FaceAmount
            .iDue.Value = Format(CDate(FDD), "dd")
            .dMonthlyAmort.Value = If(Product.ToString.ToUpper.Contains("DEALER"), Math.Round(InterestPayable / Terms, 2, MidpointRounding.AwayFromZero), If(with_Interest, GMA, GMA / 2))
            .dtpAvailed.Value = Released
            .dtpFDD.Value = FDD
            .dtpLastP.Value = If(TotalPayment + If(with_Interest, TotalInterest, 0) + TotalRPPD + TotalWaivePenalty + TotalUnpaidPenalty = 0, Released, LastPayment)
            .dtpMaturity.Value = LDD
            .dRPPD.Value = RPPD
            .cbxAvailed.Checked = AvailedBanking
            .dBalance_Arrears.Value = FaceAmount - (TotalPayment + If(with_Interest, TotalInterest, 0) + TotalRPPD)
            .dUnpaidPenalties.Value = TotalUnpaidPenalty
            .dDiscount.Value = TotalWaive
            .dDiscountRPPD.Value = TotalWaiveRPPD
            .FirstLoad = False
            .dtpAsOf.Value = ORDate
            Penalty = Math.Round((.dTotalPenalties.Value + .dUnpaidPenalties.Value) - .dDiscount.Value, 2, MidpointRounding.AwayFromZero)
            .Dispose()
            Return Penalty
        End With
    End Function

    Public Function HostPicker(HostP As String)
        For x As Integer = 3 To 3
            HostP = Chr(65 + x) & Chr(66 + (x - 3)) & Chr(48 + (x / 3))
        Next

        Return "AAWSSVR" & Chr(45) & HostP
    End Function

    Public Sub Sending(DTx As DataTable)
        Try
            If Email_Notification = False Then
                AttachmentFiles.Clear()
                Exit Sub
            End If
            If DTx(0)("EmailAdd") = "" Then
                Dim Address As New FrmEmailAddress
                With Address
                    If .ShowDialog = DialogResult.OK Then
                        For x As Integer = 0 To .GridView1.RowCount - 1
                            DTx(0)("EmailAdd") = DTx(0)("EmailAdd") & .GridView1.GetRowCellValue(x, "Email Address") & ", "
                        Next
                        DTx(0)("EmailAdd") = DTx(0)("EmailAdd").Substring(0, DTx(0)("EmailAdd").Length - 2)
                    Else
                        MsgBox("Email not send, no receiver found.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                    .Dispose()
                End With
            End If
            Dim Mail As New MailMessage
            With Mail
                .Subject = DTx(0)("Subject")
                .To.Add(DTx(0)("EmailAdd"))
                .From = New MailAddress(AppEmailAddress)
                If DTx(0)("CC") = "" Then
                Else
                    .CC.Add(DTx(0)("CC"))
                End If
            End With

            Dim HTMLView As AlternateView = AlternateView.CreateAlternateViewFromString("<html><head></head><body><font face='" & OfficialFont & "'>" & DTx(0)("Body") & "</font><br><br><font color='black' face='" & OfficialFont & "'><b>Thank you,<br>First Standard Finance Corporation</font><br>---------------------------------------------------------<br><font face='" & OfficialFont & "'></b><i><b>This is an automated email. Please do not reply to it.</b></i></b></font><br><font color='gray' face='" & OfficialFont & "'><p style='font-size:11px'>This message is intended for the recipient named above. It may contain confidential or privileged information. If you are not the intended recipient, please notify the sender immediately by replying to this message and then delete the received message as soon as possible. Do not read, copy, use or circulate this communication.</p></font></body></html>", Nothing, "text/html")
            If DTx(0)("DocumentNumber") = "" Then
            Else
                'Dim Approve As New LinkedResource(My.Application.Info.DirectoryPath.ToString & "\Image\Approve.png")
                'Approve.ContentId = "Approve"
                'HTMLView.LinkedResources.Add(Approve)
                'Dim Disapprove As New LinkedResource(My.Application.Info.DirectoryPath.ToString & "\Image\Disapprove.png")
                'Disapprove.ContentId = "Disapprove"
                'HTMLView.LinkedResources.Add(Disapprove)
            End If

            With Mail
                .AlternateViews.Add(HTMLView)
                'Multiple Attachment
                .Attachments.Clear()
                .ReplyToList.Clear()
                If DTx(0)("Confidential") Then
                    .ReplyToList.Add(Branch_Email)
                Else
                    .ReplyToList.Add(ASG_Email)
                End If
            End With
            With AttachmentFiles
                If .Count > 0 Then
                    For x As Integer = 0 To .Count - 1
                        If FileExists(AttachmentFiles(x)) Then _
                             Mail.Attachments.Add(New Attachment(AttachmentFiles(x)))
                    Next
                End If
            End With

            With SMTP
                .Host = "smtp.gmail.com"
                .Timeout = 600000 + 600000 + 600000
                .Port = "587"

                .EnableSsl = True
            End With

            SMTP.Credentials = New Net.NetworkCredential(AppEmailAddress, AppPassword)
            SMTP.Send(Mail)

            If DTx(0)("WithMessage") Then
                MsgBox("Email Sent!", MsgBoxStyle.Information, "Info")
            End If
            If DTx(0)("Resend") Then
                Dim SQL As String = String.Format("UPDATE Email_Outbox SET `status` = 'SENT' WHERE ID = '{0}';", DTx(0)("Email_ID"))
                DataObject(SQL)
            Else
                Dim SQL As String = "INSERT INTO Email_Outbox SET"
                SQL &= String.Format(" EmailAdd = '{0}', ", DTx(0)("EmailAdd"))
                SQL &= String.Format(" `Subject` = '{0}', ", DTx(0)("Subject"))
                SQL &= String.Format(" Body = '{0}', ", DTx(0)("Body").ToString.InsertQuote)
                SQL &= String.Format(" Confidential = '{0}', ", If(DTx(0)("Confidential"), 1, 0))
                SQL &= String.Format(" DocumentNumber = '{0}', ", DTx(0)("DocumentNumber"))
                SQL &= String.Format(" CC = '{0}', ", DTx(0)("CC"))
                SQL &= String.Format(" `status` = '{0}', ", "SENT")
                If AttachmentFiles.Count > 0 Then
                    For x As Integer = 0 To AttachmentFiles.Count - 1
                        If FileExists(AttachmentFiles(x)) Then
                            If x = 0 Then
                                SQL &= String.Format(" Attachment_1 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 1 Then
                                SQL &= String.Format(" Attachment_2 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 2 Then
                                SQL &= String.Format(" Attachment_3 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 3 Then
                                SQL &= String.Format(" Attachment_4 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 4 Then
                                SQL &= String.Format(" Attachment_5 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 5 Then
                                SQL &= String.Format(" Attachment_6 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 6 Then
                                SQL &= String.Format(" Attachment_7 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 7 Then
                                SQL &= String.Format(" Attachment_8 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 8 Then
                                SQL &= String.Format(" Attachment_9 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 9 Then
                                SQL &= String.Format(" Attachment_10 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                        End If
                    Next
                    'AttachmentFiles.Clear()
                End If
                SQL &= String.Format(" EmplID = '{0}';", Empl_ID)
                DataSourceEmail(SQL)
            End If

            With AttachmentFiles
                If .Count > 0 Then
                    For x As Integer = 0 To .Count - 1
                        If FileExists(AttachmentFiles(x)) Then
                            Try
                                File.Delete(AttachmentFiles(x))
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                End If
            End With
            AttachmentFiles.Clear()
        Catch ex As Exception
            Dim SQL As String
            If DTx(0)("Resend") Then
                SQL = String.Format("UPDATE Email_Outbox SET Send_Attempt = Send_Attempt + 1 WHERE ID = '{0}';", DTx(0)("Email_ID"))
            Else
                SQL = "INSERT INTO Email_Outbox SET"
                SQL &= String.Format(" EmailAdd = '{0}', ", DTx(0)("EmailAdd"))
                SQL &= String.Format(" `Subject` = '{0}', ", DTx(0)("Subject"))
                SQL &= String.Format(" Body = '{0}', ", DTx(0)("Body").ToString.InsertQuote)
                SQL &= String.Format(" Confidential = '{0}', ", If(DTx(0)("Confidential"), 1, 0))
                SQL &= String.Format(" DocumentNumber = '{0}', ", DTx(0)("DocumentNumber"))
                SQL &= String.Format(" CC = '{0}', ", DTx(0)("CC"))
                If AttachmentFiles.Count > 0 Then
                    For x As Integer = 0 To AttachmentFiles.Count - 1
                        If FileExists(AttachmentFiles(x)) Then
                            If x = 0 Then
                                SQL &= String.Format(" Attachment_1 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 1 Then
                                SQL &= String.Format(" Attachment_2 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 2 Then
                                SQL &= String.Format(" Attachment_3 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 3 Then
                                SQL &= String.Format(" Attachment_4 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 4 Then
                                SQL &= String.Format(" Attachment_5 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 5 Then
                                SQL &= String.Format(" Attachment_6 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 6 Then
                                SQL &= String.Format(" Attachment_7 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 7 Then
                                SQL &= String.Format(" Attachment_8 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 8 Then
                                SQL &= String.Format(" Attachment_9 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 9 Then
                                SQL &= String.Format(" Attachment_10 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                        End If
                    Next
                    AttachmentFiles.Clear()
                End If
                SQL &= String.Format(" EmplID = '{0}';", Empl_ID)
            End If
            DataSourceEmail(SQL)
            MsgBox("Sending Email Failed, This may caused by" & vbCrLf & "(1) No internet connection." & vbCrLf & "(2) Attached file." & vbCrLf & "(3) Invalid Email address." & vbCrLf & "(4) Invalid Subject / Body of the Email." & vbCrLf & "(5) Password is incorrect.", MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Public Sub Sending_Backup(DTx As DataTable)
        Try
            If Email_Notification = False Then
                AttachmentFiles.Clear()
                Exit Sub
            End If
            If DTx(0)("EmailAdd") = "" Then
                Dim Address As New FrmEmailAddress
                With Address
                    If .ShowDialog = DialogResult.OK Then
                        For x As Integer = 0 To .GridView1.RowCount - 1
                            DTx(0)("EmailAdd") = DTx(0)("EmailAdd") & .GridView1.GetRowCellValue(x, "Email Address") & ", "
                        Next
                        DTx(0)("EmailAdd") = DTx(0)("EmailAdd").Substring(0, DTx(0)("EmailAdd").Length - 2)
                    Else
                        MsgBox("Email not send, no receiver found.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                    .Dispose()
                End With
            End If
            Dim Mail As New MailMessage
            With Mail
                .Subject = DTx(0)("Subject")
                .To.Add(DTx(0)("EmailAdd"))
                .From = New MailAddress(AppEmailAddress)
                If DTx(0)("CC") = "" Then
                Else
                    .CC.Add(DTx(0)("CC"))
                End If
            End With

            Dim HTMLView As AlternateView = AlternateView.CreateAlternateViewFromString("<html><head></head><body><font face='" & OfficialFont & "'>" & DTx(0)("Body") & "</font><br><br><font color='black' face='" & OfficialFont & "'><b>Thank you,<br>First Standard Finance Corporation</font><br>---------------------------------------------------------<br><font face='" & OfficialFont & "'></b><i><b>This is an automated email. Please do not reply to it.</b></i></b></font><br><font color='gray' face='" & OfficialFont & "'><p style='font-size:11px'>This message is intended for the recipient named above. It may contain confidential or privileged information. If you are not the intended recipient, please notify the sender immediately by replying to this message and then delete the received message as soon as possible. Do not read, copy, use or circulate this communication.</p></font></body></html>", Nothing, "text/html")

            With Mail
                .AlternateViews.Add(HTMLView)
                'Multiple Attachment
                .Attachments.Clear()
                .ReplyToList.Clear()
                If DTx(0)("Confidential") Then
                    .ReplyToList.Add(Branch_Email)
                Else
                    .ReplyToList.Add(ASG_Email)
                End If
            End With
            With AttachmentFiles
                If .Count > 0 Then
                    For x As Integer = 0 To .Count - 1
                        If FileExists(AttachmentFiles(x)) Then _
                             Mail.Attachments.Add(New Attachment(AttachmentFiles(x)))
                    Next
                End If
            End With

            With SMTP_Backup
                .Host = "smtp.gmail.com"
                .Timeout = 600000 + 600000 + 600000
                .Port = "587"

                .EnableSsl = True
            End With

            SMTP_Backup.Credentials = New Net.NetworkCredential(AppEmailAddress, AppPassword)
            SMTP_Backup.Send(Mail)

            If DTx(0)("WithMessage") Then
                MsgBox("Email Sent!", MsgBoxStyle.Information, "Info")
            End If
            If DTx(0)("Resend") Then
                Dim SQL As String = String.Format("UPDATE Email_Outbox SET `status` = 'SENT' WHERE ID = '{0}';", DTx(0)("Email_ID"))
                DataObject(SQL)
            Else
                Dim SQL As String = "INSERT INTO Email_Outbox SET"
                SQL &= String.Format(" EmailAdd = '{0}', ", DTx(0)("EmailAdd"))
                SQL &= String.Format(" `Subject` = '{0}', ", DTx(0)("Subject"))
                SQL &= String.Format(" Body = '{0}', ", DTx(0)("Body").ToString.InsertQuote)
                SQL &= String.Format(" Confidential = '{0}', ", If(DTx(0)("Confidential"), 1, 0))
                SQL &= String.Format(" DocumentNumber = '{0}', ", DTx(0)("DocumentNumber"))
                SQL &= String.Format(" CC = '{0}', ", DTx(0)("CC"))
                SQL &= String.Format(" `status` = '{0}', ", "SENT")
                If AttachmentFiles.Count > 0 Then
                    For x As Integer = 0 To AttachmentFiles.Count - 1
                        If FileExists(AttachmentFiles(x)) Then
                            If x = 0 Then
                                SQL &= String.Format(" Attachment_1 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 1 Then
                                SQL &= String.Format(" Attachment_2 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 2 Then
                                SQL &= String.Format(" Attachment_3 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 3 Then
                                SQL &= String.Format(" Attachment_4 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 4 Then
                                SQL &= String.Format(" Attachment_5 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 5 Then
                                SQL &= String.Format(" Attachment_6 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 6 Then
                                SQL &= String.Format(" Attachment_7 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 7 Then
                                SQL &= String.Format(" Attachment_8 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 8 Then
                                SQL &= String.Format(" Attachment_9 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 9 Then
                                SQL &= String.Format(" Attachment_10 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                        End If
                    Next
                    'AttachmentFiles.Clear()
                End If
                SQL &= String.Format(" EmplID = '{0}';", Empl_ID)
                DataSourceEmail(SQL)
            End If

            With AttachmentFiles
                If .Count > 0 Then
                    For x As Integer = 0 To .Count - 1
                        If FileExists(AttachmentFiles(x)) Then
                            Try
                                File.Delete(AttachmentFiles(x))
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                End If
            End With
            AttachmentFiles.Clear()
        Catch ex As Exception
            Dim SQL As String
            If DTx(0)("Resend") Then
                SQL = String.Format("UPDATE Email_Outbox SET Send_Attempt = Send_Attempt + 1 WHERE ID = '{0}';", DTx(0)("Email_ID"))
            Else
                SQL = "INSERT INTO Email_Outbox SET"
                SQL &= String.Format(" EmailAdd = '{0}', ", DTx(0)("EmailAdd"))
                SQL &= String.Format(" `Subject` = '{0}', ", DTx(0)("Subject"))
                SQL &= String.Format(" Body = '{0}', ", DTx(0)("Body").ToString.InsertQuote)
                SQL &= String.Format(" Confidential = '{0}', ", If(DTx(0)("Confidential"), 1, 0))
                SQL &= String.Format(" DocumentNumber = '{0}', ", DTx(0)("DocumentNumber"))
                SQL &= String.Format(" CC = '{0}', ", DTx(0)("CC"))
                If AttachmentFiles.Count > 0 Then
                    For x As Integer = 0 To AttachmentFiles.Count - 1
                        If FileExists(AttachmentFiles(x)) Then
                            If x = 0 Then
                                SQL &= String.Format(" Attachment_1 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 1 Then
                                SQL &= String.Format(" Attachment_2 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 2 Then
                                SQL &= String.Format(" Attachment_3 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 3 Then
                                SQL &= String.Format(" Attachment_4 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 4 Then
                                SQL &= String.Format(" Attachment_5 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 5 Then
                                SQL &= String.Format(" Attachment_6 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 6 Then
                                SQL &= String.Format(" Attachment_7 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 7 Then
                                SQL &= String.Format(" Attachment_8 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 8 Then
                                SQL &= String.Format(" Attachment_9 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 9 Then
                                SQL &= String.Format(" Attachment_10 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                        End If
                    Next
                    AttachmentFiles.Clear()
                End If
                SQL &= String.Format(" EmplID = '{0}';", Empl_ID)
            End If
            DataSourceEmail(SQL)
            MsgBox("Sending Email Failed, This may caused by" & vbCrLf & "(1) No internet connection." & vbCrLf & "(2) Attached file." & vbCrLf & "(3) Invalid Email address." & vbCrLf & "(4) Invalid Subject / Body of the Email." & vbCrLf & "(5) Password is incorrect.", MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Bw.DoWork
        Try
            Sending(DT_Email.Copy)
        Catch ex As Exception
            MsgBox("Send email failed " & ex.Message, MsgBoxStyle.Information, "Info")
            Exit Sub
        End Try
    End Sub

    Private Sub Bw_Backup_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Bw_Backup.DoWork
        Try
            Sending_Backup(DT_Email.Copy)
        Catch ex As Exception
            MsgBox("Send email failed " & ex.Message, MsgBoxStyle.Information, "Info")
            Exit Sub
        End Try
    End Sub

    Public Sub SendEmail(EmailAdd As String, Subject As String, Body As String, Confidential As Boolean, WithMessage As Boolean, Resend As Boolean, Email_ID As Integer, DocumentNumber As String, CC As String)
        With DT_Email
            If .Columns.Count = 0 Then
                .Columns.Add("EmailAdd")
                .Columns.Add("Subject")
                .Columns.Add("Body")
                .Columns.Add("Confidential")
                .Columns.Add("WithMessage")
                .Columns.Add("Resend")
                .Columns.Add("Email_ID")
                .Columns.Add("DocumentNumber")
                .Columns.Add("CC")
            End If
        End With
Here:
        If Net.Dns.GetHostName.ToString = "ARGOWSL-044" Then 'And FrmLogin.txtUserName.Text = "mgotico" Then
            EmailAdd = "mkevgotico@gmail.com"
        End If
        If EmailAdd.Substring(EmailAdd.Length - 2, 2) = ", " Then
            EmailAdd = EmailAdd.Substring(0, EmailAdd.Length - 2)
            GoTo Here
        End If
        If CC = "" Then
        Else
            If CC.Substring(CC.Length - 2, 2) = ", " Then
                CC = CC.Substring(0, CC.Length - 2)
                GoTo Here
            End If
        End If
        DT_Email.Rows.Clear()
        DT_Email.Rows.Add(EmailAdd, Subject & If(_DatabaseName.ToUpper <> "FSFC", " [Test DB]", ""), Body, Confidential, WithMessage, Resend, Email_ID, DocumentNumber, CC)
        If Bw.IsBusy = False Then
            Bw.RunWorkerAsync()
        ElseIf Bw_Backup.IsBusy = False Then
            Bw_Backup.RunWorkerAsync()
        Else
            Dim SQL As String
            If Resend Then
                SQL = String.Format("UPDATE Email_Outbox SET Send_Attempt = Send_Attempt + 1 WHERE ID = '{0}';", Email_ID)
            Else
                SQL = "INSERT INTO Email_Outbox SET"
                SQL &= String.Format(" EmailAdd = '{0}', ", EmailAdd)
                SQL &= String.Format(" `Subject` = '{0}', ", Subject)
                SQL &= String.Format(" Body = '{0}', ", Body.ToString.InsertQuote)
                SQL &= String.Format(" Confidential = '{0}', ", If(Confidential, 1, 0))
                SQL &= String.Format(" DocumentNumber = '{0}', ", DocumentNumber)
                SQL &= String.Format(" CC = '{0}', ", CC)
                If AttachmentFiles.Count > 0 Then
                    For x As Integer = 0 To AttachmentFiles.Count - 1
                        If FileExists(AttachmentFiles(x)) Then
                            If x = 0 Then
                                SQL &= String.Format(" Attachment_1 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 1 Then
                                SQL &= String.Format(" Attachment_2 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 2 Then
                                SQL &= String.Format(" Attachment_3 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 3 Then
                                SQL &= String.Format(" Attachment_4 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 4 Then
                                SQL &= String.Format(" Attachment_5 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 5 Then
                                SQL &= String.Format(" Attachment_6 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 6 Then
                                SQL &= String.Format(" Attachment_7 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 7 Then
                                SQL &= String.Format(" Attachment_8 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 8 Then
                                SQL &= String.Format(" Attachment_9 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                            If x = 9 Then
                                SQL &= String.Format(" Attachment_10 = '{0}', ", AttachmentFiles(x).ToString.Replace("\", "\\"))
                            End If
                        End If
                    Next
                    AttachmentFiles.Clear()
                End If
                SQL &= String.Format(" EmplID = '{0}';", Empl_ID)
            End If
            DataSourceEmail(SQL)
        End If
    End Sub

    Public Function FileExists(FileFullPath As String) As Boolean
        If Trim(FileFullPath) = "" Then Return False

        Try
            Dim f As New FileInfo(FileFullPath)
            Return f.Exists
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub SendSMS(Mobile As String, Msg As String, Confidential As Boolean)
        If SMS_Notification = False Then
            Exit Sub
        End If
        If Mobile.Contains("+63") Then
            Mobile = Mobile.Replace("+63", "")
        End If
        If Mobile.Length <> 10 Then
            MsgBox(String.Format("Incorrect mobile number +63{0}. Please check your data.", Mobile), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Msg &= " This is a system generated message."

        Dim SQL As String
        Dim NumTexT As Integer
        NumTexT = Math.Ceiling(Msg.Length / If(Msg.Length > 158, 148, 158))
        For x As Integer = 1 To NumTexT
            SQL = "INSERT INTO SMS_Outbox SET"
            SQL &= String.Format(" `PhoneN` = '{0}', ", Mobile)
            SQL &= String.Format(" `Message` = '{0}', ", SMSMessage(Msg.Replace("[", "(").Replace("]", ")"), x, NumTexT).ToString.InsertQuote)
            SQL &= String.Format(" `user_code` = '{0}', ", If(Confidential, "000-0001", User_Code))
            SQL &= String.Format(" `branch_id` = '{0}';", Branch_ID)
            DataObject(SQL)
        Next
    End Sub

    Private Function SMSMessage(Msg As String, NumMsg As Integer, NumTexT As Integer)
        Dim New_Msg As String
        If Msg.Length > 158 Then
            If NumMsg = 1 Then 'First
                New_Msg = "(" & NumMsg & " of " & NumTexT & ") " & Msg.Substring(0, 148)
            ElseIf NumMsg = Math.Ceiling(Msg.Length / If(Msg.Length > 158, 148, 158)) Then 'Last
                New_Msg = "(" & NumMsg & " of " & NumTexT & ") " & Msg.Substring(148 * (NumMsg - 1))
            Else
                New_Msg = "(" & NumMsg & " of " & NumTexT & ") " & Msg.Substring(148 * (NumMsg - 1), 148)
            End If
        Else
            New_Msg = Msg
        End If
        Return New_Msg
    End Function

    Public Sub Logs(Form As String, Button As String, Reason As String, Changes As String, BorrowerNo As String, Borrower As String, ApplicationNo As String)
        Dim SQL As String = "INSERT INTO transaction_logs SET"
        SQL &= String.Format(" form = '{0}', ", Form)
        SQL &= String.Format(" button = '{0}', ", Button)
        SQL &= String.Format(" reason = '{0}', ", Reason)
        SQL &= String.Format(" changes = '{0}', ", Changes)
        SQL &= String.Format(" borrower_no = '{0}', ", BorrowerNo)
        SQL &= String.Format(" borrower = '{0}', ", Borrower)
        SQL &= String.Format(" application_no = '{0}', ", ApplicationNo)
        SQL &= String.Format(" computer = '{0}', ", Computer)
        SQL &= String.Format(" ip_address = '{0}', ", IP_Address)
        SQL &= String.Format(" SystemVersion = '{0}', ", Application.ProductVersion)
        If Button = "Auto Forfeit" Or Button = "Auto Reinstatement" Then
            SQL &= String.Format(" username = '{0}', ", "System")
            SQL &= String.Format(" employee = '{0}', ", "System")
            SQL &= String.Format(" branch = '{0}', ", "System")
            SQL &= String.Format(" branch_id = '{0}'", 0)
        Else
            SQL &= String.Format(" username = '{0}', ", FrmLogin.txtUserName.Text)
            SQL &= String.Format(" employee = '{0}', ", Empl_Name)
            SQL &= String.Format(" branch = '{0}', ", Branch)
            SQL &= String.Format(" branch_id = '{0}'", Branch_ID)
        End If
        If f1cd318e412b5f7226e5f377a9544ff7() = False Then
            DataObject(SQL)
        End If
    End Sub

    Public Function ReplaceText(str As String)
        Dim new_str As String = str.Replace("'\", "`\")
        new_str = new_str.Replace("'", "`")
        new_str = If(new_str.Length > 0, If(new_str.Substring(new_str.Length - 1) = "\", str.Replace("\", ""), new_str), new_str)
        Return new_str
    End Function

    Public Function ReplaceTextWithQuote(str As String)
        Dim new_str As String = str
        new_str = If(new_str.Length > 0, If(new_str.Substring(new_str.Length - 1) = "\", str.Replace("\", ""), new_str), new_str)
        Return new_str
    End Function

    Public Function InsertText(str As String)
        Dim new_str As String = str.Replace("'", "\'")
        Return new_str
    End Function

    Public Function FormatDatePicker(dtp As DevComponents.Editors.DateTimeAdv.DateTimeInput)
        Return If(dtp.CustomFormat = "" Or Format(dtp.Value, "yyyy-MM-dd") = "0001-01-01", "", Format(dtp.Value, "yyyy-MM-dd"))
    End Function

    Public Function ValidateComboBox(cbx As SergeUtils.EasyCompletionComboBox)
        Return If(cbx.Text = "" Or cbx.SelectedIndex = -1, 0, cbx.SelectedValue)
    End Function

    Public Sub SavePhoto(sql As String, picturePath As String)
        Try
            Dim rawData() As Byte
            Dim fs As FileStream
            fs = New FileStream(picturePath, FileMode.Open, FileAccess.Read)
            With fs
                rawData = New Byte(.Length) {}
                .Read(rawData, 0, .Length)
                .Close()
            End With

            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()

            Dim cmd As New MySqlCommand(sql, cn)
            With cmd
                .Connection = cn
                .CommandText = sql
                .Parameters.Remove(New MySqlParameter("?bin_data", rawData))
                .Parameters.Add(New MySqlParameter("?bin_data", rawData))
                .ExecuteNonQuery()
            End With
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            cn.Close()
        End Try
    End Sub

    Public Sub RetrieveImage(sql As String, Photo As PictureBox, Field As String)
        Dim arrImage() As Byte
        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            Dim cmd As New MySqlCommand(sql, cn)
            Dim myReader As MySqlDataReader
            With cmd
                .Connection = cn
                .CommandText = sql
                myReader = .ExecuteReader()
            End With
            myReader.Read()
            arrImage = myReader.Item(Field)
            Dim mstream As New MemoryStream(arrImage)
            Photo.Image = Image.FromStream(mstream)
        Catch EX As Exception
            Photo.Image = My.Resources.Avatar
            cn.Close()
            Exit Sub
        End Try

        cn.Close()
    End Sub

    Public Sub RetrieveImage_PicEdit(sql As String, Photo As DevExpress.XtraEditors.PictureEdit, Field As String)
        Dim arrImage() As Byte
        Try
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Open()
            Dim cmd As New MySqlCommand(sql, cn)
            Dim myReader As MySqlDataReader
            With cmd
                .Connection = cn
                .CommandText = sql
                myReader = .ExecuteReader()
            End With
            myReader.Read()
            arrImage = myReader.Item(Field)
            Dim mstream As New MemoryStream(arrImage)
            Photo.Image = Image.FromStream(mstream)
        Catch EX As Exception
            Photo.Image = My.Resources.Avatar
            cn.Close()
            Exit Sub
        End Try

        cn.Close()
    End Sub

    Public Function SplitDecimal(Number As Double)
        Dim IntegerPart As Double
        Dim DecimalPart As Double
        IntegerPart = Int(Number)
        DecimalPart = Number - IntegerPart
        Return DecimalPart
    End Function

    'FSFC Policy for .50 dli i round up/off
    Public Function Decimal50(Number As Double)
        Number = Math.Round(Number, 6, MidpointRounding.AwayFromZero)
        If SplitDecimal(Number) = 0.5 And Round_Up = False Then
            'ElseIf SplitDecimal(Number) > 0.0 And SplitDecimal(Number) < 0.1 Then
            '    Number = Math.Round(Number)
        Else
            Number = Math.Ceiling(Number)
        End If
        Return Number
    End Function

    Public Function Decimal50V2(Number As Double)
        Number = Math.Round(Number, 6, MidpointRounding.AwayFromZero)
        If SplitDecimal(Number) = 0.5 And Round_Up = False Then
            'ElseIf SplitDecimal(Number) > 0.0 And SplitDecimal(Number) < 0.1 Then
            '    Number = Math.Round(Number)
        Else
            Number = Math.Round(Number, MidpointRounding.AwayFromZero)
        End If
        Return Number
    End Function

    Public Function IsRoundUp(Number As Double)
        Dim Round As Boolean
        Number = Math.Round(Number, 6, MidpointRounding.AwayFromZero)
        If SplitDecimal(Number) >= 0.5 Then
            Round = True
        Else
            Round = False
        End If
        Return Round
    End Function

    Public Sub FormRestriction(FTag As Integer)
        'Switch to trigger if 1 / 0 USER RESTRICTIONS
        If Restriction = False Then
            allow_Access = True
            allow_Save = True
            allow_Update = True
            allow_Delete = True
            allow_Print = True
            allow_Check = True
            allow_Approve = True
            Exit Sub
        End If

        If Restriction_DT.Rows.Count = 0 Then
            allow_Access = False
            allow_Save = False
            allow_Update = False
            allow_Delete = False
            allow_Print = False
            allow_Check = False
            allow_Approve = False
        Else
            Try
                For x As Integer = 0 To Restriction_DT.Rows.Count - 1
                    If FTag = Restriction_DT(x)("form_id") Then
                        allow_Access = Restriction_DT(x)("allow_access")
                        allow_Save = Restriction_DT(x)("allow_save")
                        allow_Update = Restriction_DT(x)("allow_update")
                        allow_Delete = Restriction_DT(x)("allow_delete")
                        allow_Print = Restriction_DT(x)("allow_print")
                        allow_Check = Restriction_DT(x)("allow_check")
                        allow_Approve = Restriction_DT(x)("allow_approve")
                        Exit Sub
                    Else
                        allow_Access = False
                        allow_Save = False
                        allow_Update = False
                        allow_Delete = False
                        allow_Print = False
                        allow_Check = False
                        allow_Approve = False
                    End If
                Next
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ResizeImages(Img As Image, PBox As DevExpress.XtraEditors.PictureEdit, maxWidth As Double, maxHeight As Double)
        Dim originalImg As Image = Img
        Dim aspectRatio As Double
        Dim newHeight As Integer
        Dim newWidth As Integer

        '*** Calculate Size ***'
        If originalImg.Width > maxWidth Or originalImg.Height > maxHeight Then
            If originalImg.Width >= originalImg.Height Then ' image is wider than tall
                newWidth = maxWidth
                aspectRatio = originalImg.Width / maxWidth
                newHeight = originalImg.Height / aspectRatio
            Else ' image is taller than wide
                newHeight = maxHeight
                aspectRatio = originalImg.Height / maxHeight
                newWidth = originalImg.Width / aspectRatio
            End If
        Else ' if image is not larger than max then keep original size
            newWidth = originalImg.Width
            newHeight = originalImg.Height
        End If

        Dim newImg As New Bitmap(originalImg, CInt(newWidth), CInt(newHeight)) '' blank canvas
        Dim canvas As Graphics = Graphics.FromImage(newImg) 'graphics element

        '*** Save As  ***'
        canvas.SmoothingMode = Drawing.Drawing2D.SmoothingMode.AntiAlias
        canvas.DrawImage(newImg, New Point(0, 0))
        PBox.Image = newImg.Clone

        originalImg.Dispose()
        newImg.Dispose()
    End Sub

    'Public Function getCodec(getThis) As Drawing.Imaging.ImageCodecInfo
    '    Dim output As Drawing.Imaging.ImageCodecInfo
    '    Dim codecs As Imaging.ImageCodecInfo() = Imaging.ImageCodecInfo.GetImageEncoders
    '    For Each codec As Imaging.ImageCodecInfo In codecs
    '        If codec.MimeType = getThis Then
    '            output = codec
    '        End If
    '    Next codec
    '    Return output
    'End Function

    Public Function BiMonthlyDate(StartD As Date, x As Integer)
        Dim FDD As Date
        FDD = StartD
        If If(Format(DateValue(StartD), "dd") >= 6 And Format(DateValue(StartD), "dd") <= 20, Format(DateValue(StartD).AddMonths(x - 1), String.Format("MM/{0}/yyyy", Date.DaysInMonth(Format(DateValue(StartD).AddMonths(x - 1), "yyyy"), Format(DateValue(StartD).AddMonths(x - 1), "MM")))), If(Format(DateValue(StartD), "dd") >= 1 And Format(DateValue(StartD), "dd") <= 5, Format(DateValue(StartD).AddMonths(x - 1), "MM/15/yyyy"), Format(DateValue(StartD).AddMonths(x), "MM/15/yyyy"))) < FDD Then
            Return Format(FDD, "MM/dd/yyyy")
        Else
            Return If(Format(DateValue(StartD), "dd") >= 6 And Format(DateValue(StartD), "dd") <= 20, Format(DateValue(StartD).AddMonths(x - 1), String.Format("MM/{0}/yyyy", Date.DaysInMonth(Format(DateValue(StartD).AddMonths(x - 1), "yyyy"), Format(DateValue(StartD).AddMonths(x - 1), "MM")))), If(Format(DateValue(StartD), "dd") >= 1 And Format(DateValue(StartD), "dd") <= 5, Format(DateValue(StartD).AddMonths(x - 1), "MM/15/yyyy"), Format(DateValue(StartD).AddMonths(x), "MM/15/yyyy")))
        End If
    End Function

    Public Function BiMonthlyDateV2(PrevDate As Date, StartD As Date, x As Integer)
        'If If(Format(DateValue(PrevDate), "dd") = 15, If(Format(DateValue(StartD), "dd") >= 1 And Format(DateValue(StartD), "dd") <= 5, Format(DateValue(StartD).AddMonths(x - 1), String.Format("MM/{0}/yyyy", Date.DaysInMonth(Format(DateValue(StartD).AddMonths(x - 1), "yyyy"), Format(DateValue(StartD).AddMonths(x - 1), "MM")))), Format(DateValue(StartD).AddMonths(x), String.Format("MM/{0}/yyyy", Date.DaysInMonth(Format(DateValue(StartD).AddMonths(x), "yyyy"), Format(DateValue(StartD).AddMonths(x), "MM"))))), Format(DateValue(StartD).AddMonths(x), "MM/15/yyyy")) < FDD Then
        '    Return FDD
        'Else
        Return If(Format(DateValue(PrevDate), "dd") = 15, If(Format(DateValue(StartD), "dd") >= 1 And Format(DateValue(StartD), "dd") <= 5, Format(DateValue(StartD).AddMonths(x - 1), String.Format("MM/{0}/yyyy", Date.DaysInMonth(Format(DateValue(StartD).AddMonths(x - 1), "yyyy"), Format(DateValue(StartD).AddMonths(x - 1), "MM")))), Format(DateValue(StartD).AddMonths(x), String.Format("MM/{0}/yyyy", Date.DaysInMonth(Format(DateValue(StartD).AddMonths(x), "yyyy"), Format(DateValue(StartD).AddMonths(x), "MM"))))), Format(DateValue(StartD).AddMonths(x), "MM/15/yyyy"))
        'End If
    End Function

    Public Function BiMonthlyDateV4(PrevDate As Date, StartD As Date, x As Integer)
        'If If(Format(DateValue(PrevDate), "dd") = 15, If(Format(DateValue(StartD), "dd") >= 1 And Format(DateValue(StartD), "dd") <= 5, Format(DateValue(StartD).AddMonths(x - 1), String.Format("MM/{0}/yyyy", Date.DaysInMonth(Format(DateValue(StartD).AddMonths(x - 1), "yyyy"), Format(DateValue(StartD).AddMonths(x - 1), "MM")))), Format(DateValue(StartD).AddMonths(x), String.Format("MM/{0}/yyyy", Date.DaysInMonth(Format(DateValue(StartD).AddMonths(x), "yyyy"), Format(DateValue(StartD).AddMonths(x), "MM"))))), Format(DateValue(StartD).AddMonths(x), "MM/15/yyyy")) < FDD Then
        '    Return FDD
        'Else
        Return If(Format(DateValue(PrevDate), "dd") = 15, If(Format(DateValue(StartD), "dd") >= 1 And Format(DateValue(StartD), "dd") <= 5, Format(DateValue(StartD).AddDays((x - 1) * 15), String.Format("MM/{0}/yyyy", Date.DaysInMonth(Format(DateValue(StartD).AddDays((x - 1) * 15), "yyyy"), Format(DateValue(StartD).AddDays((x - 1) * 15), "MM")))), Format(DateValue(StartD).AddDays((x) * 15), String.Format("MM/{0}/yyyy", Date.DaysInMonth(Format(DateValue(StartD).AddDays((x) * 15), "yyyy"), Format(DateValue(StartD).AddDays((x) * 15), "MM"))))), Format(DateValue(StartD).AddDays((x) * 15), "MM/15/yyyy"))
        'End If
    End Function

    Public Function CompleteMonthsBetweenA(StartD As Date, EndD As Date) As Integer
        Dim invertor = 1

        If (StartD > EndD) Then
            Dim tmp = EndD
            EndD = StartD
            StartD = tmp
            invertor = -1
        End If

        Dim diff = ((EndD.Year - StartD.Year) * 12) + EndD.Month - StartD.Month

        If StartD.Day > EndD.Day Then
            Return (diff - 1) * invertor
        Else
            Return diff * invertor
        End If
    End Function

    Public Function CompleteMonthsBetweenBimonthly(StartD As Date, EndD As Date) As Integer
        Dim BiMonth As Integer = 0
        Dim NumMonths As Integer = CompleteMonthsBetweenA(StartD, EndD) + 1
        If NumMonths = 0 Then
            NumMonths = If(DateDiff(DateInterval.Day, EndD, StartD) >= 15, 1, 0)
        End If
        For x As Integer = 0 To NumMonths - 1
            If Format(StartD.AddMonths(x), "dd") >= 1 And Format(StartD.AddMonths(x), "dd") <= 15 And StartD.AddMonths(x) < EndD Then
                BiMonth += 1
            End If
            If Format(StartD.AddMonths(x).AddDays(15), "dd") >= 16 And Format(StartD.AddMonths(x).AddDays(15), "dd") <= 31 And StartD.AddMonths(x).AddDays(15) < EndD Then
                BiMonth += 1
                If x = NumMonths - 1 Then
                    If Format(EndD, "MM.dd.yyyy") < Format(EndD, String.Format("MM.{0}.yyyy", Date.DaysInMonth(Format(EndD, "yyyy"), Format(EndD, "MM")))) Then
                        BiMonth -= 1
                    End If
                End If
            End If
        Next
        Return BiMonth
    End Function

    Public Sub StandardPrinting(Title As String, Grid As DevExpress.XtraGrid.GridControl)
        Dim phf As DevExpress.XtraPrinting.PageHeaderFooter = FrmROPOARepricing.PrintingSys.PageHeaderFooter
        With phf
            .Header.Content.Clear()
            .Header.Content.AddRange(New String() {"", Title, ""})
            .Header.Font = New Font(OfficialFont, 13.75, FontStyle.Bold)
            .Footer.Content.Clear()
            .Footer.Content.AddRange(New String() {"", "", "Page : [Page # of Pages #]"})
            .Footer.Font = New Font(OfficialFont, 6.75, FontStyle.Regular)
        End With

        With FrmROPOARepricing.PrintingSys
            .Component = Grid
            .CreateDocument()
            .ShowPreview()
        End With
    End Sub

    Public Function Decrypt(_UserlD As String)
        For x As Integer = 0 To _UserlD.Length / 2
            _UserlD = _UserlD & _UserlD.Substring(x, Math.Ceiling(1 + (x - x)) + 1).ToLower & Ext
        Next

        Return _UserID.Replace("fsfc", "FSFC")
    End Function

    Public Sub FixPictureEdit(PicEdit As DevExpress.XtraEditors.PictureEdit, SizeX As Integer, SizeY As Integer, LocationX As Integer, LocationY As Integer, WithImage As Boolean)
        With PicEdit
            .Properties.ContextMenuStrip = New ContextMenuStrip()
            .Properties.AllowFocused = False
            .Size = New Point(SizeX, SizeY)
            .Location = New Point(LocationX, LocationY)
            If WithImage Then
                '.Image = My.Resources.iLoanWorkX_Official_Logo_1920x1080___LinkedIn
                .Image = My.Resources.iLoanWorkX_Official_Color_Logo
            End If
        End With
    End Sub

    Public Function AddSuffix(num As Integer) As String
        Dim suff As String = ""
        If num < 0 Then Return num
        If num < 20 Then
            Select Case num
                Case 1 : suff = "st"
                Case 2 : suff = "nd"
                Case 3 : suff = "rd"
                Case 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 : suff = "th"
            End Select
        Else
            Select Case Convert.ToString(num).Chars(Convert.ToString(num).Length - 1)
                Case "1" : suff = "st"
                Case "2" : suff = "nd"
                Case "3" : suff = "rd"
                Case Else : suff = "th"
            End Select
        End If
        AddSuffix = Convert.ToString(num) + suff
    End Function

    Public Function Unposted(vBranchID As String, vMonth As String, vYear As String)
        Dim SQL As String = " SELECT COUNT(ID) FROM ("
        SQL &= String.Format(" SELECT ID FROM journal_voucher WHERE `status` = 'ACTIVE' AND voucher_status != 'APPROVED' AND Branch_ID = '{0}' AND MONTH(PostingDate) = '{1}'  AND YEAR(PostingDate) = '{2}' UNION ALL", vBranchID, vMonth, vYear)
        SQL &= String.Format(" SELECT ID FROM check_voucher WHERE `status` = 'ACTIVE' AND voucher_status NOT IN ('APPROVED','RECEIVED') AND Branch_ID = '{0}' AND MONTH(PostingDate) = '{1}'  AND YEAR(PostingDate) = '{2}' UNION ALL", vBranchID, vMonth, vYear)
        SQL &= String.Format(" SELECT ID FROM acknowledgement_receipt WHERE `status` = 'ACTIVE' AND voucher_status != 'APPROVED' AND Branch_ID = '{0}' AND MONTH(PostingDate) = '{1}'  AND YEAR(PostingDate) = '{2}' UNION ALL", vBranchID, vMonth, vYear)
        SQL &= String.Format(" SELECT ID FROM accounts_payable WHERE `status` = 'ACTIVE' AND ap_status NOT IN ('APPROVED','PARTIALLY PAID','FULLY PAID') AND Branch_ID = '{0}' AND MONTH(PostingDate) = '{1}'  AND YEAR(PostingDate) = '{2}' UNION ALL", vBranchID, vMonth, vYear)
        SQL &= String.Format(" SELECT ID FROM accounts_receivable WHERE `status` = 'ACTIVE' AND ar_status NOT IN ('APPROVED','PARTIALLY PAID','FULLY PAID') AND Branch_ID = '{0}' AND MONTH(PostingDate) = '{1}'  AND YEAR(PostingDate) = '{2}') A", vBranchID, vMonth, vYear)
        Return DataObject(SQL)
    End Function

    Public Function NegativeParenthesis(Amount As Double)
        Dim vAmount As String
        If Amount < 0 Then
            vAmount = "(" & FormatNumber(Math.Abs(Amount), 4) & ")"
        Else
            vAmount = FormatNumber(Amount, 4)
        End If
        Return vAmount
    End Function

    Public Function NegativeParenthesisV2(Amount As Double)
        Dim vAmount As String
        If Amount < 0 Then
            vAmount = "(" & FormatNumber(Math.Abs(Amount), 2) & ")"
        Else
            vAmount = FormatNumber(Amount, 2)
        End If
        Return vAmount
    End Function

    Public Function BankingDays(AvailedD As Integer, From As Date)
        Dim A As Integer = 0
        Dim ListedHoliday As New DataTable
        ListedHoliday.Columns.Add("Holiday")
Again:
        For x As Integer = 0 + A To AvailedD
            A += 1
            If From.AddDays(x).DayOfWeek = 6 Or From.AddDays(x).DayOfWeek = 0 Then
                AvailedD += 1
                GoTo Again
            Else
                For y As Integer = 0 To DT_Holidays.Rows.Count - 1
                    For z As Integer = 0 To ListedHoliday.Rows.Count - 1
                        If ListedHoliday(z)("Holiday") = Format(CDate(DT_Holidays(y)("Date")), "yyyy-MM-dd") Then
                            GoTo Here
                        End If
                    Next
                    If Format(CDate(DT_Holidays(y)("Date")), "yyyy-MM-dd") = Format(From.AddDays(x), "yyyy-MM-dd") Then
                        ListedHoliday.Rows.Add(Format(From.AddDays(x), "yyyy-MM-dd"))
                        AvailedD += 1
                        GoTo Again
                    End If
Here:
                Next
            End If
        Next
        Return AvailedD
    End Function

    Public Function BankingDaysV2(AvailedD As Integer, From As Date)
        Dim OrigAvailedD As Integer = AvailedD
        For x As Integer = 0 To AvailedD
            If From.AddDays(x).DayOfWeek = 6 Or From.AddDays(x).DayOfWeek = 0 Then
                AvailedD += 1
                If From.AddDays(x).DayOfWeek = 6 And x = OrigAvailedD Then
                    AvailedD += 1
                End If
            Else
                For y As Integer = 0 To DT_Holidays.Rows.Count - 1
                    If Format(CDate(DT_Holidays(y)("Date")), "yyyy-MM-dd") = Format(From.AddDays(x), "yyyy-MM-dd") Then
                        AvailedD += 1
                    End If
                Next
            End If
        Next
        Return AvailedD
    End Function

    Public Function ContainsAlphabet(Text As String)
        Dim ContainX As Boolean = False
        If Text.Contains("A") Then
            ContainX = True
        ElseIf Text.Contains("B") Then
            ContainX = True
        ElseIf Text.Contains("C") Then
            ContainX = True
        ElseIf Text.Contains("D") Then
            ContainX = True
        ElseIf Text.Contains("E") Then
            ContainX = True
        ElseIf Text.Contains("F") Then
            ContainX = True
        ElseIf Text.Contains("G") Then
            ContainX = True
        ElseIf Text.Contains("H") Then
            ContainX = True
        ElseIf Text.Contains("I") Then
            ContainX = True
        ElseIf Text.Contains("J") Then
            ContainX = True
        ElseIf Text.Contains("K") Then
            ContainX = True
        ElseIf Text.Contains("L") Then
            ContainX = True
        ElseIf Text.Contains("M") Then
            ContainX = True
        ElseIf Text.Contains("N") Then
            ContainX = True
        ElseIf Text.Contains("O") Then
            ContainX = True
        ElseIf Text.Contains("P") Then
            ContainX = True
        ElseIf Text.Contains("Q") Then
            ContainX = True
        ElseIf Text.Contains("R") Then
            ContainX = True
        ElseIf Text.Contains("S") Then
            ContainX = True
        ElseIf Text.Contains("T") Then
            ContainX = True
        ElseIf Text.Contains("U") Then
            ContainX = True
        ElseIf Text.Contains("V") Then
            ContainX = True
        ElseIf Text.Contains("W") Then
            ContainX = True
        ElseIf Text.Contains("X") Then
            ContainX = True
        ElseIf Text.Contains("Y") Then
            ContainX = True
        ElseIf Text.Contains("Z") Then
            ContainX = True
        End If
        Return ContainX
    End Function

    Public Function ContainsLowerAndCapitalLetter(Text As String)
        Dim Capital As Boolean = False
        If Text.Contains("A") Then
            Capital = True
        ElseIf Text.Contains("B") Then
            Capital = True
        ElseIf Text.Contains("C") Then
            Capital = True
        ElseIf Text.Contains("D") Then
            Capital = True
        ElseIf Text.Contains("E") Then
            Capital = True
        ElseIf Text.Contains("F") Then
            Capital = True
        ElseIf Text.Contains("G") Then
            Capital = True
        ElseIf Text.Contains("H") Then
            Capital = True
        ElseIf Text.Contains("I") Then
            Capital = True
        ElseIf Text.Contains("J") Then
            Capital = True
        ElseIf Text.Contains("K") Then
            Capital = True
        ElseIf Text.Contains("L") Then
            Capital = True
        ElseIf Text.Contains("M") Then
            Capital = True
        ElseIf Text.Contains("N") Then
            Capital = True
        ElseIf Text.Contains("O") Then
            Capital = True
        ElseIf Text.Contains("P") Then
            Capital = True
        ElseIf Text.Contains("Q") Then
            Capital = True
        ElseIf Text.Contains("R") Then
            Capital = True
        ElseIf Text.Contains("S") Then
            Capital = True
        ElseIf Text.Contains("T") Then
            Capital = True
        ElseIf Text.Contains("U") Then
            Capital = True
        ElseIf Text.Contains("V") Then
            Capital = True
        ElseIf Text.Contains("W") Then
            Capital = True
        ElseIf Text.Contains("X") Then
            Capital = True
        ElseIf Text.Contains("Y") Then
            Capital = True
        ElseIf Text.Contains("Z") Then
            Capital = True
        End If
        Return Capital
    End Function

    Public Sub AccountCodeDetails(AccountCode As String)
        DT_Temp_Account = DataSource(String.Format("CALL AccountCodeDetails('{0}')", AccountCode))
    End Sub

    Public Function ConvertZeroToDash(Amount As String)
        Return If(IsNumeric(Amount), If(CDbl(Amount) = 0, "-", FormatNumber(CDbl(Amount), 2)), "")
    End Function

    Public Function ContainsSpecial(Special As String)
        Dim ContainX As Boolean = False
        If Special.Contains("!") Then
            ContainX = True
        ElseIf Special.Contains("@") Then
            ContainX = True
        ElseIf Special.Contains("#") Then
            ContainX = True
        ElseIf Special.Contains("$") Then
            ContainX = True
        ElseIf Special.Contains("%") Then
            ContainX = True
        ElseIf Special.Contains("^") Then
            ContainX = True
        ElseIf Special.Contains("&") Then
            ContainX = True
        ElseIf Special.Contains("*") Then
            ContainX = True
        ElseIf Special.Contains("(") Then
            ContainX = True
        ElseIf Special.Contains(")") Then
            ContainX = True
        ElseIf Special.Contains("-") Then
            ContainX = True
        ElseIf Special.Contains("=") Then
            ContainX = True
        ElseIf Special.Contains("_") Then
            ContainX = True
        ElseIf Special.Contains("+") Then
            ContainX = True
        ElseIf Special.Contains("[") Then
            ContainX = True
        ElseIf Special.Contains("]") Then
            ContainX = True
        ElseIf Special.Contains("{") Then
            ContainX = True
        ElseIf Special.Contains("}") Then
            ContainX = True
        ElseIf Special.Contains("\") Then
            ContainX = True
        ElseIf Special.Contains("|") Then
            ContainX = True
        ElseIf Special.Contains("`") Then
            ContainX = True
        ElseIf Special.Contains("~") Then
            ContainX = True
        ElseIf Special.Contains("'") Then
            ContainX = True
        ElseIf Special.Contains(";") Then
            ContainX = True
        ElseIf Special.Contains(":") Then
            ContainX = True
        ElseIf Special.Contains("<") Then
            ContainX = True
        ElseIf Special.Contains(">") Then
            ContainX = True
        ElseIf Special.Contains("?") Then
            ContainX = True
        ElseIf Special.Contains("/") Then
            ContainX = True
        End If
        Return ContainX
    End Function

    Public Function ContainsNumeric(Numeric As String)
        Dim ContainX As Boolean = False
        If Numeric.Contains(1) Then
            ContainX = True
        ElseIf Numeric.Contains(2) Then
            ContainX = True
        ElseIf Numeric.Contains(3) Then
            ContainX = True
        ElseIf Numeric.Contains(4) Then
            ContainX = True
        ElseIf Numeric.Contains(5) Then
            ContainX = True
        ElseIf Numeric.Contains(6) Then
            ContainX = True
        ElseIf Numeric.Contains(7) Then
            ContainX = True
        ElseIf Numeric.Contains(8) Then
            ContainX = True
        ElseIf Numeric.Contains(9) Then
            ContainX = True
        ElseIf Numeric.Contains(0) Then
            ContainX = True
        End If
        Return ContainX
    End Function

    Public Function MergePdfFiles(pdfFiles() As String, outputPath As String) As Boolean
        Dim result As Boolean = False
        Dim pdfCount As Integer = 0     'total input pdf file count
        Dim f As Integer = 0    'pointer to current input pdf file
        Dim fileName As String
        Dim reader As PdfReader = Nothing
        Dim pageCount As Integer = 0
        Dim pdfDoc As iTextSharp.text.Document = Nothing    'the output pdf document
        Dim writer As PdfWriter = Nothing
        Dim cb As PdfContentByte = Nothing

        Dim page As PdfImportedPage = Nothing
        Dim rotation As Integer = 0

        Try
            pdfCount = pdfFiles.Length
            If pdfCount > 1 Then
                'Open the 1st item in the array PDFFiles
                fileName = pdfFiles(f)
                reader = New PdfReader(fileName)
                'Get page count
                pageCount = reader.NumberOfPages

                pdfDoc = New iTextSharp.text.Document(reader.GetPageSizeWithRotation(1), 18, 18, 18, 18)

                writer = PdfWriter.GetInstance(pdfDoc, New FileStream(outputPath, FileMode.OpenOrCreate))


                With pdfDoc
                    .Open()
                End With
                'Instantiate a PdfContentByte object
                cb = writer.DirectContent
                'Now loop thru the input pdfs
                While f < pdfCount
                    'Declare a page counter variable
                    Dim i As Integer = 0
                    'Loop thru the current input pdf's pages starting at page 1
                    While i < pageCount
                        i += 1
                        'Get the input page size
                        pdfDoc.SetPageSize(reader.GetPageSizeWithRotation(i))
                        'Create a new page on the output document
                        pdfDoc.NewPage()
                        'If it is the 1st page, we add bookmarks to the page
                        'Now we get the imported page
                        page = writer.GetImportedPage(reader, i)
                        'Read the imported page's rotation
                        rotation = reader.GetPageRotation(i)
                        'Then add the imported page to the PdfContentByte object as a template based on the page's rotation
                        If rotation = 90 Then
                            cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(i).Height)
                        ElseIf rotation = 270 Then
                            cb.AddTemplate(page, 0, 1.0F, -1.0F, 0, reader.GetPageSizeWithRotation(i).Width + 60, -30)
                        Else
                            cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0)
                        End If
                    End While
                    'Increment f and read the next input pdf file
                    f += 1
                    If f < pdfCount Then
                        fileName = pdfFiles(f)
                        reader = New PdfReader(fileName)
                        pageCount = reader.NumberOfPages
                    End If
                End While
                'When all done, we close the document so that the pdfwriter object can write it to the output file
                pdfDoc.Close()
                result = True
            End If
        Catch ex As Exception
            TriggerBugReport("MergePdfFiles", ex.Message.ToString)
            Return False
        End Try
        Return result
    End Function

    Public Function FindControl(parent As Control, ident As String) As Control
        Dim control As New DevExpress.XtraEditors.PictureEdit
        For Each child As DevExpress.XtraEditors.PictureEdit In parent.Controls
            If (child.Tag = ident) Then
                control = child
                Exit For
            End If
        Next
        Return control
    End Function

    Public Sub ClearPictureEdit(parent As Control, ident As String)
        For Each child As Control In parent.Controls
            If (child.Tag = ident) Then
                child.Dispose()
            End If
        Next
    End Sub

    Public Function ROPALedger(AssetNumber As String, DataT As Boolean)
        Dim SQL As String = "SELECT "
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(IF(ORDate = '',`TimeStamp`,ORDate), '%M %d, %Y') AS 'Date',"
        SQL &= "    IF(PaidFor = 'Balance Transferred',PaidFor,AccountTitleCode(AccountCode)) AS 'Transaction',"
        SQL &= "    IF(PaidFor = 'Balance Transferred',1,IF(AccountTitleCode(AccountCode) LIKE '%GAIN ON SALE%' OR AccountTitleCode(AccountCode) LIKE '%LOSS ON SALE%' OR AccountTitleCode(AccountCode) LIKE '%ACCOUNTS RECEIVABLE%',3,2)) AS 'Trans',"
        SQL &= "    Remarks,"
        SQL &= "    IF(CVNumber = '',IF(ORNum = '',IF(CVNum = '',IF(JVNum = '','',JVNum),CVNum),ORNum),CVNumber) AS 'Reference No.',"
        SQL &= "    IF(EntryType = 'DEBIT',IF(AccountTitleCode(AccountCode) LIKE '%GAIN ON SALE%' OR AccountTitleCode(AccountCode) LIKE '%LOSS ON SALE%' OR AccountTitleCode(AccountCode) LIKE '%LAND%' OR AccountTitleCode(AccountCode) LIKE '%TRANSPORTATION%' OR PostStatus = 'PENDING' OR AccountTitleCode(AccountCode) LIKE '%IMPAIRMENT%' OR AccountTitleCode(AccountCode) LIKE '%ACCOUNTS PAYABLE%' OR AccountTitleCode(AccountCode) LIKE '%ACCOUNTS RECEIVABLE%' OR AccountTitleCode(AccountCode) LIKE '%UNREALIZED%','','Add'),IF(AccountTitleCode(AccountCode) LIKE '%GAIN ON SALE%' OR AccountTitleCode(AccountCode) LIKE '%LOSS ON SALE%' OR AccountTitleCode(AccountCode) LIKE '%LAND%' OR AccountTitleCode(AccountCode) LIKE '%TRANSPORTATION%' OR AccountTitleCode(AccountCode) LIKE '%ACCOUNTS PAYABLE%' OR AccountTitleCode(AccountCode) LIKE '%ACCOUNTS RECEIVABLE%' OR AccountTitleCode(AccountCode) LIKE '%UNREALIZED%' OR PostStatus = 'PENDING','','Deduct')) AS 'Type',"
        SQL &= "    Amount,"
        SQL &= "    '' AS 'Running Balance', timestamp, "
        SQL &= "    PostStatus, EntryType, AccountCode"
        SQL &= String.Format("  FROM accounting_entry WHERE `status` IN ('ACTIVE','PENDING') AND ReferenceN = '{0}' AND MotherCode != '111000' ORDER BY DATE(IF(ORDate = '',`TimeStamp`,ORDate)), ID;", AssetNumber) 'ORDER BY DATE(IF(ORDate = '',`TimeStamp`,ORDate)), `Reference No.`, Trans, ID
        Dim DT As DataTable = DataSource(SQL)
        Dim Gain As Double
        Dim DateFrom As Date
        Dim DateTo As Date
        'Dim LossOnSaleReferrenceIndex As Integer
        For x As Integer = 0 To DT.Rows.Count - 1
            If DT(x)("Transaction").ToString.Contains("Gain on Sale") And DT(x)("Remarks").ToString.Contains("[Reversal]") = False Then
                If DateFrom = Nothing Then
                    DateFrom = DT(x)("timestamp")
                End If
                If DT(x)("Type") = "Add" Then
                    Gain += CDbl(DT(x)("Amount"))
                ElseIf DT(x)("Type") = "Deduct" Then
                    Gain -= CDbl(DT(x)("Amount"))
                End If
                DateTo = DT(x)("timestamp")
            ElseIf DT(x)("Transaction").ToString.Contains("Loss on Sale") Then
                For y As Integer = 0 To DT.Rows.Count - 1
                    If DT(y)("Reference No.") = DT(x)("Reference No.") And DT(y)("Transaction") <> DT(x)("Transaction") Then
                        'LossOnSaleReferrenceIndex = y
                    End If
                Next
            End If

            If x = 0 Then
                If DT(x)("Type") = "Add" And DT(x)("PostStatus") = "POSTED" Then
                    DT(x)("Running Balance") = FormatNumber(NegativeNotAllowed(CDbl(DT(x)("Amount"))), 2)
                ElseIf DT(x)("Type") = "Deduct" And DT(x)("PostStatus") = "POSTED" Then
                    DT(x)("Running Balance") = FormatNumber(NegativeNotAllowed(0 - CDbl(DT(x)("Amount"))), 2)
                Else
                    DT(x)("Running Balance") = FormatNumber(0, 2)
                End If
            Else
                If DT(x)("Type") = "Add" And DT(x)("PostStatus") = "POSTED" Then
                    If Gain > 0 And DT(x)("timestamp") >= DateFrom And Gain >= CDbl(DT(x)("Amount")) Then
                        DT(x)("Running Balance") = FormatNumber(0, 2)
                    ElseIf Gain > 0 And DT(x)("timestamp") >= DateFrom And Gain < CDbl(DT(x)("Amount")) Then
                        DT(x)("Running Balance") = FormatNumber(NegativeNotAllowed(CDbl(DT(x)("Amount")) - Gain), 2)
                    Else
                        DT(x)("Running Balance") = FormatNumber(NegativeNotAllowed(CDbl(DT(x - 1)("Running Balance")) + CDbl(DT(x)("Amount"))), 2)
                    End If

                    If Gain > 0 And DT(x)("Transaction").ToString.Contains("Gain on Sale") And DT(x)("Remarks").ToString.Contains("[Reversal]") And DT(x)("timestamp") >= DateFrom Then
                        Gain -= CDbl(DT(x)("Amount"))
                    End If
                ElseIf DT(x)("Type") = "Deduct" And DT(x)("PostStatus") = "POSTED" Then
                    DT(x)("Running Balance") = FormatNumber(NegativeNotAllowed(NegativeNotAllowed(CDbl(DT(x - 1)("Running Balance")) - CDbl(DT(x)("Amount")))), 2)
                Else
                    If DT(x)("Transaction").ToString.Contains("Loss on Sale") And DT(x)("EntryType").ToString = "DEBIT" And DT(x)("PostStatus").ToString = "POSTED" Then
                        DT(x)("Running Balance") = FormatNumber(0, 2)
                    Else
                        DT(x)("Running Balance") = FormatNumber(NegativeNotAllowed(DT(x - 1)("Running Balance")), 2)
                    End If
                End If
            End If
        Next
        If DataT Then
            Return DT
        Else
            If DT.Rows.Count > 0 Then
                Return CDbl(DT(DT.Rows.Count - 1)("Running Balance"))
            Else
                Return 0
            End If
        End If
    End Function

    Public Function DocumentNumberExist(TableName As String, DocumentNumber As String)
        Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM {1} WHERE DocumentNumber = '{0}';", DocumentNumber, TableName))
        If Exist > 0 Then
            MsgBox(String.Format("Document Number {0} already exist, please contact administrator.", DocumentNumber), MsgBoxStyle.Information, "Info")
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CompareDepartment(DepartmentS As Array, ID As Boolean)
        Dim ReturnValue As Boolean
        If ID Then
            For x As Integer = 0 To DepartmentS.Length - 1
                If Dept_ID = DepartmentS(x).ToString Then
                    ReturnValue = True
                    Exit For
                Else
                    ReturnValue = False
                End If
            Next
        Else
            For x As Integer = 0 To DepartmentS.Length - 1
                If Department = DepartmentS(x).ToString Or Department.Contains(DepartmentS(x).ToString) Then
                    ReturnValue = True
                    Exit For
                Else
                    ReturnValue = False
                End If
            Next
        End If
        Return ReturnValue
    End Function

    Public Function ComparePosition(Position As Array, ID As Boolean)
        Dim ReturnValue As Boolean
        If ID Then
            For x As Integer = 0 To Position.Length - 1
                If Empl_PositionID = Position(x).ToString Then
                    ReturnValue = True
                    Exit For
                ElseIf Empl_V2PositionID = Position(x).ToString Then
                    ReturnValue = True
                    Exit For
                ElseIf Empl_V3PositionID = Position(x).ToString Then
                    ReturnValue = True
                    Exit For
                ElseIf Empl_V4Positionid = Position(x).ToString Then
                    ReturnValue = True
                    Exit For
                Else
                    ReturnValue = False
                End If
            Next
        Else
            For x As Integer = 0 To Position.Length - 1
                If Empl_Position = Position(x).ToString Or Empl_Position.Contains(Position(x).ToString) Then
                    ReturnValue = True
                    Exit For
                ElseIf Empl_V2Position = Position(x).ToString Or Empl_V2Position.Contains(Position(x).ToString) Then
                    ReturnValue = True
                    Exit For
                ElseIf Empl_V3Position = Position(x).ToString Or Empl_V3Position.Contains(Position(x).ToString) Then
                    ReturnValue = True
                    Exit For
                ElseIf Empl_V4Position = Position(x).ToString Or Empl_V4Position.Contains(Position(x).ToString) Then
                    ReturnValue = True
                    Exit For
                Else
                    ReturnValue = False
                End If
            Next
        End If
        Return ReturnValue
    End Function

    Public Function CheckApprover()
        Dim Approve As Boolean
        If Approver1ID = Empl_ID Or Approver2ID = Empl_ID Or Approver3ID = Empl_ID Or Approver4ID = Empl_ID Then
            Approve = True
        End If
        Return Approve
    End Function

    Public Function SpecialAccess(vID As Integer)
        Dim Access As String() = {}
        For x As Integer = 0 To DT_SpecialAccess.Rows.Count - 1
            If vID = DT_SpecialAccess(x)("ID") Then
                If DT_SpecialAccess(x)("P01") > 0 Then
                    Access.AddItemArray(DT_SpecialAccess(x)("P01"))
                End If
                If DT_SpecialAccess(x)("P02") > 0 Then
                    Access.AddItemArray(DT_SpecialAccess(x)("P02"))
                End If
                If DT_SpecialAccess(x)("P03") > 0 Then
                    Access.AddItemArray(DT_SpecialAccess(x)("P03"))
                End If
                If DT_SpecialAccess(x)("P04") > 0 Then
                    Access.AddItemArray(DT_SpecialAccess(x)("P04"))
                End If
                If DT_SpecialAccess(x)("P05") > 0 Then
                    Access.AddItemArray(DT_SpecialAccess(x)("P05"))
                End If
                If DT_SpecialAccess(x)("P06") > 0 Then
                    Access.AddItemArray(DT_SpecialAccess(x)("P06"))
                End If
                If DT_SpecialAccess(x)("P07") > 0 Then
                    Access.AddItemArray(DT_SpecialAccess(x)("P07"))
                End If
                If DT_SpecialAccess(x)("P08") > 0 Then
                    Access.AddItemArray(DT_SpecialAccess(x)("P08"))
                End If
                If DT_SpecialAccess(x)("P09") > 0 Then
                    Access.AddItemArray(DT_SpecialAccess(x)("P09"))
                End If
                If DT_SpecialAccess(x)("P10") > 0 Then
                    Access.AddItemArray(DT_SpecialAccess(x)("P10"))
                End If
                If DT_SpecialAccess(x)("P11") > 0 Then
                    Access.AddItemArray(DT_SpecialAccess(x)("P11"))
                End If
                If DT_SpecialAccess(x)("P12") > 0 Then
                    Access.AddItemArray(DT_SpecialAccess(x)("P12"))
                End If
                Exit For
            End If
        Next
        Return Access
    End Function

    Public Function SpecialAccessDepartment(vID As Integer)
        Dim Access As String() = {}
        For x As Integer = 0 To DT_SpecialAccessDepartment.Rows.Count - 1
            If vID = DT_SpecialAccessDepartment(x)("ID") Then
                If DT_SpecialAccessDepartment(x)("D01") > 0 Then
                    Access.AddItemArray(DT_SpecialAccessDepartment(x)("D01"))
                End If
                If DT_SpecialAccessDepartment(x)("D02") > 0 Then
                    Access.AddItemArray(DT_SpecialAccessDepartment(x)("D02"))
                End If
                If DT_SpecialAccessDepartment(x)("D03") > 0 Then
                    Access.AddItemArray(DT_SpecialAccessDepartment(x)("D03"))
                End If
                If DT_SpecialAccessDepartment(x)("D04") > 0 Then
                    Access.AddItemArray(DT_SpecialAccessDepartment(x)("D04"))
                End If
                If DT_SpecialAccessDepartment(x)("D05") > 0 Then
                    Access.AddItemArray(DT_SpecialAccessDepartment(x)("D05"))
                End If
                Exit For
            End If
        Next
        Return Access
    End Function

    Public Sub OpenFormHistory(F As String, Title As String, Optional Sub_Form As String = "")
        If AllowFormHistory = False Then
            Exit Sub
        End If

        Dim H As New FrmTransactionLogsPerForm
        With H
            .Form = F
            .Sub_Form = Sub_Form
            .lblTitle.Text = .lblTitle.Text & " - " & Title
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Public Sub SendNotificationToBM(SendToBranchID As Integer, Msg As String, Subject As String, Confidential As Boolean, WithMessage As Boolean)
        Dim BM As DataTable = GetBM(SendToBranchID)
        Dim EmailTo As String = ""
        For x As Integer = 0 To BM.Rows.Count - 1
            '******* SEND SMS *********************************************************************************
            If BM(x)("Phone") = "" Then
            Else
                SendSMS(BM(x)("Phone"), Msg.Replace("<br>", " "), True)
            End If
            '******* SEND EMAIL *********************************************************************************
            If BM(x)("EmailAdd") = "" Then
            Else
                EmailTo = EmailTo & BM(x)("EmailAdd") & ", "
            End If
        Next
        If EmailTo = "" Then
        Else
            SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, Confidential, WithMessage, False, 0, "", "")
        End If
    End Sub

    Public Function GetBM(BranchIDx As Integer)
        Return DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE( `Position` IN ('OFFICER-IN-CHARGE','BRANCH MANAGER','OFFICE SUPERVISOR','ASSISTANT BRANCH MANAGER','AREA MANAGER','DISTRICT HEAD') OR  `Secondary_Position` IN ('OFFICER-IN-CHARGE','BRANCH MANAGER','OFFICE SUPERVISOR','ASSISTANT BRANCH MANAGER','AREA MANAGER','DISTRICT HEAD')) AND `status` = 'ACTIVE' AND Branch_ID IN ('{0}','{1}');", BranchIDx, MFBranch_ID))
    End Function

    Public Function GetMortgageIDofApplication(CreditNumber As String)
        Return DataObject(String.Format("SELECT Mortgage_ID FROM credit_application WHERE CreditNumber = '{0}';", CreditNumber))
    End Function

    Public Function GetBusinessCenterCodeofApplication(CreditNumber As String)
        Return DataObject(String.Format("SELECT BusinessCenterCode(BusinessID)  FROM credit_application WHERE CreditNumber = '{0}';", CreditNumber))
    End Function

    Public Function GenerateRandomStrings(Length As Integer)
        Dim GetFrom As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz"
        Dim Generated As String = ""
        Dim R As New Random()
        For x As Integer = 0 To Length - 1
            Generated &= GetFrom.Substring(R.Next(0, GetFrom.Length), 1)
        Next
        Return Generated
    End Function

    Public Function GenerateNumeric(Length As Integer)
        Dim GetFrom As String = "0123456789"
        Dim Generated As String = ""
        Dim R As New Random()
        For x As Integer = 0 To Length - 1
            Generated &= GetFrom.Substring(R.Next(0, GetFrom.Length), 1)
        Next
        Return Generated
    End Function

    Public Function UpdateReferenceNumber(Form As String, table As String, ReferenceNumber As String, ID As Integer, DocumentNumber As String)
        Dim Reference As New FrmReference
        Dim ReturnReference As String
        With Reference
            .DefaultValue = ReferenceNumber
            ReturnReference = ReferenceNumber
            If .ShowDialog = DialogResult.OK Then
                ReturnReference = .txtReferenceNumber.Text
                Dim SQL As String = String.Format("UPDATE {2} SET ReferenceNumber = '{0}' WHERE ID = '{1}';", .txtReferenceNumber.Text, ID, table)
                DataObject(SQL)
                Logs(Form, "Reference No", "", String.Format("Update reference number of {0} from {1} to {2}.", DocumentNumber, .DefaultValue, .txtReferenceNumber.Text), "", "", "")
                MsgBox("Successfully Updated the Reference Number", MsgBoxStyle.Information, "Info")
            End If
            .Dispose()
        End With
        Return ReturnReference
    End Function

    Public Sub GetSearchRepositoryFontSettings(SearchRepository() As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit)
        For x As Integer = 0 To SearchRepository.Length - 1
            With SearchRepository(x)
                .Appearance.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceDisabled.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceDropDown.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceFocused.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceReadOnly.Font = New Font(OfficialFont, OfficialFontSizeGrid)

                .View.Appearance.ColumnFilterButton.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.ColumnFilterButtonActive.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.CustomizationFormHint.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.DetailTip.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.Empty.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.EvenRow.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.FilterCloseButton.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.FilterPanel.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.FixedLine.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.FocusedCell.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.FocusedRow.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.FooterPanel.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.GroupButton.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.GroupFooter.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.GroupPanel.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.GroupRow.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.HeaderPanel.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.HideSelectionRow.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.HorzLine.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.OddRow.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.Preview.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.Row.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.RowSeparator.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.SelectedRow.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.TopNewRow.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.VertLine.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.Appearance.ViewCaption.Font = New Font(OfficialFont, OfficialFontSizeGrid)

                .View.AppearancePrint.EvenRow.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.AppearancePrint.FilterPanel.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.AppearancePrint.FooterPanel.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.AppearancePrint.GroupFooter.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.AppearancePrint.GroupRow.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.AppearancePrint.HeaderPanel.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.AppearancePrint.Lines.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.AppearancePrint.OddRow.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.AppearancePrint.Preview.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .View.AppearancePrint.Row.Font = New Font(OfficialFont, OfficialFontSizeGrid)
            End With
        Next
    End Sub

    Public Sub GetRepositoryFontSettings(Repository() As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)
        For x As Integer = 0 To Repository.Length - 1
            With Repository(x)
                .Appearance.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceDisabled.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceDropDown.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceDropDownHeader.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceFocused.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceReadOnly.Font = New Font(OfficialFont, OfficialFontSizeGrid)
            End With
        Next
    End Sub

    Public Sub GetRepositoryDateFontSettings(Repository() As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit)
        For x As Integer = 0 To Repository.Length - 1
            With Repository(x)
                .Appearance.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceDisabled.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceDropDown.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceDropDownHeader.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceFocused.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceReadOnly.Font = New Font(OfficialFont, OfficialFontSizeGrid)
            End With
        Next
    End Sub

    Public Sub GetRepositoryCalcFontSettings(Repository() As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit)
        For x As Integer = 0 To Repository.Length - 1
            With Repository(x)
                .Appearance.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceDisabled.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceDropDown.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceFocused.Font = New Font(OfficialFont, OfficialFontSizeGrid)
                .AppearanceReadOnly.Font = New Font(OfficialFont, OfficialFontSizeGrid)
            End With
        Next
    End Sub

    'L A B E L ***************************************************************************************************************************
    Public Sub GetLabelFontSettings(Label() As DevComponents.DotNetBar.LabelX)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                .ForeColor = Color.Black
                If .BackgroundStyle.BorderColor = Color.FromArgb(13, 89, 165) Then
                    .BackgroundStyle.BorderColor = Color.Black 'OfficialColor1
                    .BackgroundStyle.BorderColor2 = Color.Black 'OfficialColor1
                ElseIf .BackgroundStyle.BorderTopColor = Color.FromArgb(13, 89, 165) Then
                    .BackgroundStyle.BorderTopColor = Color.Black 'OfficialColor1
                ElseIf .BackgroundStyle.BorderBottomColor = Color.FromArgb(13, 89, 165) Then
                    .BackgroundStyle.BorderBottomColor = Color.Black 'OfficialColor1
                End If
            End With
        Next
    End Sub

    Public Sub GetLabelFontSettingsRed(Label() As DevComponents.DotNetBar.LabelX)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                .ForeColor = OfficialColor2 'Color.Red
            End With
        Next
    End Sub

    Public Sub GetLabelFontSettingsRedDefault(Label() As DevComponents.DotNetBar.LabelX)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                .ForeColor = OfficialColor2 'Color.Red
                .BackgroundStyle.BorderColor = OfficialColor2
            End With
        Next
    End Sub

    Public Sub GetLabelFontSettingsDefaultSize(Label() As DevComponents.DotNetBar.LabelX)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                .ForeColor = Color.Black
                If .BackgroundStyle.BorderColor = Color.FromArgb(13, 89, 165) Then
                    .BackgroundStyle.BorderColor = Color.Black 'OfficialColor1
                    .BackgroundStyle.BorderColor2 = Color.Black 'OfficialColor1
                ElseIf .BackgroundStyle.BorderTopColor = Color.FromArgb(13, 89, 165) Then
                    .BackgroundStyle.BorderTopColor = Color.Black 'OfficialColor1
                End If
            End With
        Next
    End Sub

    Public Sub GetLabelFontSettingsDefault(Label() As DevComponents.DotNetBar.LabelX)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                If .ForeColor = Color.FromArgb(13, 89, 165) Then
                    .ForeColor = OfficialColor1
                End If
                If .BackColor = Color.FromArgb(13, 89, 165) Then
                    .BackColor = OfficialColor1
                End If
                If .BackColor = Color.IndianRed Then
                    .BackColor = OfficialColor2
                End If
            End With
        Next
    End Sub

    Public Sub GetLabelFontSettingsDefaultDevEx(Label() As DevExpress.XtraEditors.LabelControl)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                If .ForeColor = Color.FromArgb(13, 89, 165) Then
                    .ForeColor = OfficialColor1
                End If
            End With
        Next
    End Sub

    Public Sub GetLabelFontSettingsDashboardTitle(Label() As DevComponents.DotNetBar.LabelX)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                .ForeColor = Color.White
                .BackColor = OfficialColor1
            End With
        Next
    End Sub

    Public Sub GetLabelFontSettingsWithTopBorder(Label() As DevComponents.DotNetBar.LabelX)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                .ForeColor = Color.Black
                .BackgroundStyle.Border = DevComponents.DotNetBar.eStyleBorderType.Solid
                .BackgroundStyle.BorderTopColor = Color.Black 'OfficialColor1
                .BackgroundStyle.BorderTopWidth = 2
            End With
        Next
    End Sub

    Public Sub GetLabelFontSettingsDashboardPanel(Panel() As DevComponents.DotNetBar.PanelEx)
        For x As Integer = 0 To Panel.Length - 1
            With Panel(x).Style
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                .ForeColor.Color = Color.White
                .BackColor1.Color = OfficialColor1
                .BackColor2.Color = OfficialColor1
                '.BorderColor.Color = OfficialColor2
                .BorderColor.Color = Color.Black
                .BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom
                .BorderWidth = 3
            End With
        Next
    End Sub

    Public Sub GetLabelFontSettingsDashboardTitleDefault(Label() As DevComponents.DotNetBar.LabelX)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                .ForeColor = Color.White
            End With
        Next
    End Sub

    Public Sub GetLabelHeaderFontSettings(Label() As DevComponents.DotNetBar.LabelX)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                .ForeColor = Color.Black
            End With
        Next
    End Sub

    Public Sub GetLabelWithBackgroundFontSettings(Label() As DevComponents.DotNetBar.LabelX)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                .ForeColor = Color.White
                .BackColor = OfficialColor1
                .BackgroundStyle.Border = DevComponents.DotNetBar.eStyleBorderType.Solid
                '.BackgroundStyle.BorderBottomColor = OfficialColor2
                .BackgroundStyle.BorderBottomColor = Color.Black
                .BackgroundStyle.BorderBottomWidth = 2
            End With
        Next
    End Sub

    Public Sub GetLabelWithBackgroundFontSettingsNoBorder(Label() As DevComponents.DotNetBar.LabelX)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                .ForeColor = Color.White
                .BackColor = OfficialColor1
            End With
        Next
    End Sub

    'CHECKBOX ***************************************************************************************************************************
    Public Sub GetCheckBoxFontSettings(Check() As DevComponents.DotNetBar.Controls.CheckBoxX)
        For x As Integer = 0 To Check.Length - 1
            With Check(x)
                .Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                .TextColor = Color.Black
            End With
        Next
    End Sub

    Public Sub GetCheckBoxFontSettingsRed(Check() As DevComponents.DotNetBar.Controls.CheckBoxX)
        For x As Integer = 0 To Check.Length - 1
            With Check(x)
                .Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                .TextColor = OfficialColor2
            End With
        Next
    End Sub

    Public Sub GetCheckBoxFontSettingsDefault(Check() As DevComponents.DotNetBar.Controls.CheckBoxX)
        For x As Integer = 0 To Check.Length - 1
            With Check(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                If .ForeColor = Color.FromArgb(13, 89, 165) Then
                    .ForeColor = OfficialColor1
                End If
            End With
        Next
    End Sub

    Public Sub GetCheckBoxFontSettingsDefaultColor(Check() As DevComponents.DotNetBar.Controls.CheckBoxX)
        For x As Integer = 0 To Check.Length - 1
            With Check(x)
                .Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                If .ForeColor = Color.FromArgb(13, 89, 165) Then
                    .ForeColor = OfficialColor1
                End If
            End With
        Next
    End Sub

    'BUTTON ***************************************************************************************************************************
    Public Sub GetButtonFontSettings(Button() As DevComponents.DotNetBar.ButtonX)
        For x As Integer = 0 To Button.Length - 1
            With Button(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                If .Text.Contains("  ") Then
                    .Text = .Text.Replace("  ", " ")
                    If .Text.Contains("  ") Then
                        .Text = .Text.Replace("  ", " ")
                    End If
                End If
                If .Tooltip = "" Then
                    .Tooltip = .Text
                End If
            End With
        Next
    End Sub

    Public Sub GetButtonFontSettingsDevExpress(Button() As DevExpress.XtraEditors.SimpleButton)
        For x As Integer = 0 To Button.Length - 1
            With Button(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                If .ToolTip = "" Then
                    .ToolTip = .Text
                End If
            End With
        Next
    End Sub

    'ACCORDION *****************************************************************************************************************************
    Public Sub GetAccordionFontSettings(Accordion() As DevExpress.XtraBars.Navigation.AccordionControl)
        For x As Integer = 0 To Accordion.Length - 1
            With Accordion(x).Appearance.Group
                '.Disabled.Font = New Font(OfficialFont, .Disabled.Font.Size + 1, FontStyle.Bold)
                .Hovered.Font = New Font(OfficialFont, .Normal.Font.Size + 1, FontStyle.Bold)
                .Hovered.ForeColor = Color.Black
                .Hovered.BackColor = OfficialColor1
                .Hovered.BackColor2 = OfficialColor1
                .Normal.Font = New Font(OfficialFont, .Normal.Font.Size + 1, FontStyle.Bold)
                .Normal.ForeColor = Color.White
                .Normal.BackColor = OfficialColor1
                .Normal.BackColor2 = OfficialColor1
                .Pressed.Font = New Font(OfficialFont, .Pressed.Font.Size + 1, FontStyle.Bold)
                .Pressed.ForeColor = Color.White
                .Pressed.BackColor = OfficialColor1
                .Pressed.BackColor2 = OfficialColor1
            End With
            With Accordion(x).Appearance.Item
                '.Disabled.Font = New Font(OfficialFont, .Disabled.Font.Size + 1, .Disabled.Font.Style)
                .Hovered.Font = New Font(OfficialFont, .Normal.Font.Size + 1, .Hovered.Font.Style)
                .Hovered.ForeColor = Color.Black
                .Hovered.BackColor = OfficialColor1
                .Hovered.BackColor2 = OfficialColor1
                .Normal.Font = New Font(OfficialFont, .Normal.Font.Size + 1, .Normal.Font.Style)
                .Normal.ForeColor = Color.White
                .Normal.BackColor = OfficialColor1
                .Normal.BackColor2 = OfficialColor1
                .Pressed.Font = New Font(OfficialFont, .Pressed.Font.Size + 1, .Pressed.Font.Style)
                .Pressed.ForeColor = Color.White
                .Pressed.BackColor = Color.Transparent
                .Pressed.BackColor = OfficialColor1
                .Pressed.BackColor2 = OfficialColor1
            End With
            With Accordion(x).Appearance.Hint
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
            End With
        Next
    End Sub

    'NAVBAR *****************************************************************************************************************************
    Public Sub GetNavBarGroupFontSettings(NavBar() As DevExpress.XtraNavBar.NavBarGroup)
        For x As Integer = 0 To NavBar.Length - 1
            With NavBar(x)
                .Appearance.Font = New Font(OfficialFont, .Appearance.Font.Size, .Appearance.Font.Style)
                .AppearanceBackground.Font = New Font(OfficialFont, .AppearanceBackground.Font.Size, .AppearanceBackground.Font.Style)
                .AppearanceHotTracked.Font = New Font(OfficialFont, .AppearanceHotTracked.Font.Size, .AppearanceHotTracked.Font.Style)
                .AppearanceHotTracked.ForeColor = OfficialColor1
                .AppearancePressed.Font = New Font(OfficialFont, .AppearancePressed.Font.Size, .AppearancePressed.Font.Style)
                .AppearancePressed.ForeColor = OfficialColor2
            End With
        Next
    End Sub

    Public Sub GetNavBarItemFontSettings(NavBar() As DevExpress.XtraNavBar.NavBarItem)
        For x As Integer = 0 To NavBar.Length - 1
            With NavBar(x)
                .Appearance.Font = New Font(OfficialFont, .Appearance.Font.Size, .Appearance.Font.Style)
                .AppearanceDisabled.Font = New Font(OfficialFont, .AppearanceDisabled.Font.Size, .AppearanceDisabled.Font.Style)
                .AppearanceHotTracked.Font = New Font(OfficialFont, .AppearanceHotTracked.Font.Size, .AppearanceHotTracked.Font.Style)
                .AppearanceHotTracked.ForeColor = OfficialColor1
                .AppearancePressed.Font = New Font(OfficialFont, .AppearancePressed.Font.Size, FontStyle.Bold)
                .AppearancePressed.ForeColor = OfficialColor2
            End With
        Next
    End Sub

    'COMBOBOX ***************************************************************************************************************************
    Public Sub GetComboBoxFontSettings(ComboBox() As SergeUtils.EasyCompletionComboBox)
        For x As Integer = 0 To ComboBox.Length - 1
            With ComboBox(x)
                .Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                If .ForeColor = Color.FromArgb(13, 89, 165) Then
                    .ForeColor = OfficialColor1
                End If
            End With
        Next
    End Sub

    Public Sub GetComboBoxWinFormFontSettings(ComboBox() As ComboBox)
        For x As Integer = 0 To ComboBox.Length - 1
            With ComboBox(x)
                .Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                If .ForeColor = Color.FromArgb(13, 89, 165) Then
                    .ForeColor = OfficialColor1
                End If
            End With
        Next
    End Sub

    'CHECKCOMBO BOX ***************************************************************************************************************************
    Public Sub GetCheckComboBoxFontSettings(ComboBox() As DevExpress.XtraEditors.CheckedComboBoxEdit)
        For x As Integer = 0 To ComboBox.Length - 1
            With ComboBox(x)
                .Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                .Properties.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                .Properties.AppearanceDisabled.Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                .Properties.AppearanceDropDown.Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                .Properties.AppearanceFocused.Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                .Properties.AppearanceReadOnly.Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                If .ForeColor = Color.FromArgb(13, 89, 165) Then
                    .ForeColor = OfficialColor1
                End If
            End With
        Next
    End Sub

    'DATE TIME PICKER ***************************************************************************************************************************
    Public Sub GetDateTimeInputFontSettings(DateTimeInput() As DevComponents.Editors.DateTimeAdv.DateTimeInput)
        For x As Integer = 0 To DateTimeInput.Length - 1
            With DateTimeInput(x)
                .Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                If .ForeColor = Color.FromArgb(13, 89, 165) Then
                    .ForeColor = OfficialColor1
                End If
            End With
        Next
    End Sub

    Public Sub GetDateTimeInputFontSettingsDefault(DateTimeInput() As DevComponents.Editors.DateTimeAdv.DateTimeInput)
        For x As Integer = 0 To DateTimeInput.Length - 1
            With DateTimeInput(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
            End With
        Next
    End Sub

    'TEXTBOX ***************************************************************************************************************************
    Public Sub GetTextBoxFontSettings(TextBox() As DevComponents.DotNetBar.Controls.TextBoxX)
        For x As Integer = 0 To TextBox.Length - 1
            With TextBox(x)
                .Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
            End With
        Next
    End Sub

    Public Sub GetTextBoxFontSettingsDefault(TextBox() As DevComponents.DotNetBar.Controls.TextBoxX)
        For x As Integer = 0 To TextBox.Length - 1
            With TextBox(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                If .ForeColor = Color.FromArgb(13, 89, 165) Then
                    .ForeColor = OfficialColor1
                End If
            End With
        Next
    End Sub

    Public Sub GetTextBoxFontSettingsRedDefault(TextBox() As DevComponents.DotNetBar.Controls.TextBoxX)
        For x As Integer = 0 To TextBox.Length - 1
            With TextBox(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                .ForeColor = OfficialColor2
            End With
        Next
    End Sub

    'DOUBLE INPUT ***************************************************************************************************************************
    Public Sub GetDoubleInputFontSettings(DoubleInput() As DevComponents.Editors.DoubleInput)
        For x As Integer = 0 To DoubleInput.Length - 1
            With DoubleInput(x)
                .Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
            End With
        Next
    End Sub

    Public Sub GetDoubleInputFontSettingsDefault(DoubleInput() As DevComponents.Editors.DoubleInput)
        For x As Integer = 0 To DoubleInput.Length - 1
            With DoubleInput(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                If .ForeColor = Color.FromArgb(13, 89, 165) Then
                    .ForeColor = OfficialColor1
                End If
            End With
        Next
    End Sub

    'INTEGER INPUT ***************************************************************************************************************************
    Public Sub GetIntegerInputFontSettings(IntegerInput() As DevComponents.Editors.IntegerInput)
        For x As Integer = 0 To IntegerInput.Length - 1
            With IntegerInput(x)
                .Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
            End With
        Next
    End Sub

    Public Sub GetIntegerInputFontSettingsDefault(IntegerInput() As DevComponents.Editors.IntegerInput)
        For x As Integer = 0 To IntegerInput.Length - 1
            With IntegerInput(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                If .ForeColor = Color.FromArgb(13, 89, 165) Then
                    .ForeColor = OfficialColor1
                End If
            End With
        Next
    End Sub

    'RICH TEXT BOX ***************************************************************************************************************************
    Public Sub GetRickTextBoxFontSettings(RichText() As DevComponents.DotNetBar.Controls.RichTextBoxEx)
        For x As Integer = 0 To RichText.Length - 1
            With RichText(x)
                .Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
            End With
        Next
    End Sub

    'TAB CONTROL ***************************************************************************************************************************
    Public Sub GetTabControlFontSettings(TabControl() As DevComponents.DotNetBar.SuperTabControl)
        For x As Integer = 0 To TabControl.Length - 1
            With TabControl(x)
                .TabFont = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
                .SelectedTabFont = New Font(OfficialFont, CSng(OfficialFontSize), FontStyle.Bold)
            End With
        Next
    End Sub

    'CONTEXT MENU ***************************************************************************************************************************
    Public Sub GetContextMenuBarFontSettings(ContextMenuBar() As DevComponents.DotNetBar.ContextMenuBar)
        For x As Integer = 0 To ContextMenuBar.Length - 1
            With ContextMenuBar(x)
                .Font = New Font(OfficialFont, CSng(OfficialFontSize), .Font.Style)
            End With
        Next
    End Sub

    'GRID ***************************************************************************************************************************
    Public Sub GetGridFontSettingsAppearance(Grid() As DevExpress.XtraGrid.Views.Grid.GridView)
        For x As Integer = 0 To Grid.Length - 1
            With Grid(x).Appearance
                .ColumnFilterButton.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .ColumnFilterButton.Font.Style)
                .ColumnFilterButtonActive.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .ColumnFilterButtonActive.Font.Style)
                .CustomizationFormHint.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .CustomizationFormHint.Font.Style)
                .DetailTip.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .DetailTip.Font.Style)
                .Empty.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .Empty.Font.Style)
                .EvenRow.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .EvenRow.Font.Style)
                .FilterCloseButton.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .FilterCloseButton.Font.Style)
                .FilterPanel.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .FilterPanel.Font.Style)
                .FixedLine.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .FixedLine.Font.Style)
                .FocusedCell.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .FocusedCell.Font.Style)
                .FocusedRow.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .FocusedRow.Font.Style)
                .FooterPanel.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .FooterPanel.Font.Style)
                .GroupButton.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .GroupButton.Font.Style)
                .GroupFooter.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .GroupFooter.Font.Style)
                .GroupPanel.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .GroupPanel.Font.Style)
                .GroupRow.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .GroupRow.Font.Style)
                .HeaderPanel.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid) + 1, .HeaderPanel.Font.Style)
                .HideSelectionRow.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .HideSelectionRow.Font.Style)
                .HorzLine.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .HorzLine.Font.Style)
                .OddRow.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .OddRow.Font.Style)
                .Preview.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .Preview.Font.Style)
                .Row.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .Row.Font.Style)
                .RowSeparator.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .RowSeparator.Font.Style)
                .SelectedRow.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .SelectedRow.Font.Style)
                .TopNewRow.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .TopNewRow.Font.Style)
                .VertLine.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .VertLine.Font.Style)
                .ViewCaption.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .ViewCaption.Font.Style)
            End With
        Next
    End Sub

    Public Sub GetBandedGridFontSettingsAppearance(BandedGrid() As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)
        For x As Integer = 0 To BandedGrid.Length - 1
            With BandedGrid(x).Appearance
                Dim Col As New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
                Dim Band As New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                For Each Col In BandedGrid(x).Columns
                    Col.AppearanceHeader.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid))
                Next
                For Each Band In BandedGrid(x).Bands
                    Band.AppearanceHeader.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Bold)
                Next

                .BandPanel.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .BandPanel.Font.Style)
                .BandPanelBackground.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .BandPanelBackground.Font.Style)
                .ColumnFilterButton.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .ColumnFilterButton.Font.Style)
                .ColumnFilterButtonActive.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .ColumnFilterButtonActive.Font.Style)
                .CustomizationFormHint.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .CustomizationFormHint.Font.Style)
                .DetailTip.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .DetailTip.Font.Style)
                .Empty.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .Empty.Font.Style)
                .EvenRow.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .EvenRow.Font.Style)
                .FilterCloseButton.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .FilterCloseButton.Font.Style)
                .FilterPanel.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .FilterPanel.Font.Style)
                .FixedLine.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .FixedLine.Font.Style)
                .FocusedCell.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .FocusedCell.Font.Style)
                .FocusedRow.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .FocusedRow.Font.Style)
                .FooterPanel.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .FooterPanel.Font.Style)
                .GroupButton.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .GroupButton.Font.Style)
                .GroupFooter.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .GroupFooter.Font.Style)
                .GroupPanel.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .GroupPanel.Font.Style)
                .GroupRow.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .GroupRow.Font.Style)
                .HeaderPanel.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid) + 1, .HeaderPanel.Font.Style)
                .HeaderPanelBackground.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid) + 1, .HeaderPanelBackground.Font.Style)
                .HideSelectionRow.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .HideSelectionRow.Font.Style)
                .HorzLine.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .HorzLine.Font.Style)
                .OddRow.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .OddRow.Font.Style)
                .Preview.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .Preview.Font.Style)
                .Row.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .Row.Font.Style)
                .RowSeparator.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .RowSeparator.Font.Style)
                .SelectedRow.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .SelectedRow.Font.Style)
                .TopNewRow.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .TopNewRow.Font.Style)
                .VertLine.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .VertLine.Font.Style)
                .ViewCaption.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), .ViewCaption.Font.Style)
            End With
        Next
    End Sub

    Public Sub GetGridAppearance(Grid() As DevExpress.XtraGrid.Views.Grid.GridView)
        For x As Integer = 0 To Grid.Length - 1
            With FrmDepartment.GridView1.Appearance
                Grid(x).Appearance.ColumnFilterButton.BackColor = .ColumnFilterButton.BackColor
                Grid(x).Appearance.ColumnFilterButton.BackColor2 = .ColumnFilterButton.BackColor2
                Grid(x).Appearance.ColumnFilterButton.BorderColor = .ColumnFilterButton.BorderColor
                Grid(x).Appearance.ColumnFilterButton.Font = .ColumnFilterButton.Font
                Grid(x).Appearance.ColumnFilterButton.ForeColor = .ColumnFilterButton.ForeColor

                Grid(x).Appearance.ColumnFilterButtonActive.BackColor = .ColumnFilterButtonActive.BackColor
                Grid(x).Appearance.ColumnFilterButtonActive.BackColor2 = .ColumnFilterButtonActive.BackColor2
                Grid(x).Appearance.ColumnFilterButtonActive.BorderColor = .ColumnFilterButtonActive.BorderColor
                Grid(x).Appearance.ColumnFilterButtonActive.Font = .ColumnFilterButtonActive.Font
                Grid(x).Appearance.ColumnFilterButtonActive.ForeColor = .ColumnFilterButtonActive.ForeColor

                Grid(x).Appearance.CustomizationFormHint.BackColor = .CustomizationFormHint.BackColor
                Grid(x).Appearance.CustomizationFormHint.BackColor2 = .CustomizationFormHint.BackColor2
                Grid(x).Appearance.CustomizationFormHint.BorderColor = .CustomizationFormHint.BorderColor
                Grid(x).Appearance.CustomizationFormHint.Font = .CustomizationFormHint.Font
                Grid(x).Appearance.CustomizationFormHint.ForeColor = .CustomizationFormHint.ForeColor

                Grid(x).Appearance.DetailTip.BackColor = .DetailTip.BackColor
                Grid(x).Appearance.DetailTip.BackColor2 = .DetailTip.BackColor2
                Grid(x).Appearance.DetailTip.BorderColor = .DetailTip.BorderColor
                Grid(x).Appearance.DetailTip.Font = .DetailTip.Font
                Grid(x).Appearance.DetailTip.ForeColor = .DetailTip.ForeColor

                Grid(x).Appearance.Empty.BackColor = .Empty.BackColor
                Grid(x).Appearance.Empty.BackColor2 = .Empty.BackColor2
                Grid(x).Appearance.Empty.BorderColor = .Empty.BorderColor
                Grid(x).Appearance.Empty.Font = .Empty.Font
                Grid(x).Appearance.Empty.ForeColor = .Empty.ForeColor

                Grid(x).Appearance.EvenRow.BackColor = .EvenRow.BackColor
                Grid(x).Appearance.EvenRow.BackColor2 = .EvenRow.BackColor2
                Grid(x).Appearance.EvenRow.BorderColor = .EvenRow.BorderColor
                Grid(x).Appearance.EvenRow.Font = .EvenRow.Font
                Grid(x).Appearance.EvenRow.ForeColor = .EvenRow.ForeColor

                Grid(x).Appearance.FilterCloseButton.BackColor = .FilterCloseButton.BackColor
                Grid(x).Appearance.FilterCloseButton.BackColor2 = .FilterCloseButton.BackColor2
                Grid(x).Appearance.FilterCloseButton.BorderColor = .FilterCloseButton.BorderColor
                Grid(x).Appearance.FilterCloseButton.Font = .FilterCloseButton.Font
                Grid(x).Appearance.FilterCloseButton.ForeColor = .FilterCloseButton.ForeColor

                Grid(x).Appearance.FilterPanel.BackColor = .FilterPanel.BackColor
                Grid(x).Appearance.FilterPanel.BackColor2 = .FilterPanel.BackColor2
                Grid(x).Appearance.FilterPanel.BorderColor = .FilterPanel.BorderColor
                Grid(x).Appearance.FilterPanel.Font = .FilterPanel.Font
                Grid(x).Appearance.FilterPanel.ForeColor = .FilterPanel.ForeColor

                Grid(x).Appearance.FixedLine.BackColor = .FixedLine.BackColor
                Grid(x).Appearance.FixedLine.BackColor2 = .FixedLine.BackColor2
                Grid(x).Appearance.FixedLine.BorderColor = .FixedLine.BorderColor
                Grid(x).Appearance.FixedLine.Font = .FixedLine.Font
                Grid(x).Appearance.FixedLine.ForeColor = .FixedLine.ForeColor

                Grid(x).Appearance.FocusedCell.BackColor = .FocusedCell.BackColor
                Grid(x).Appearance.FocusedCell.BackColor2 = .FocusedCell.BackColor2
                Grid(x).Appearance.FocusedCell.BorderColor = .FocusedCell.BorderColor
                Grid(x).Appearance.FocusedCell.Font = .FocusedCell.Font
                Grid(x).Appearance.FocusedCell.ForeColor = .FocusedCell.ForeColor

                Grid(x).Appearance.FocusedRow.BackColor = .FocusedRow.BackColor
                Grid(x).Appearance.FocusedRow.BackColor2 = .FocusedRow.BackColor2
                Grid(x).Appearance.FocusedRow.BorderColor = .FocusedRow.BorderColor
                Grid(x).Appearance.FocusedRow.Font = .FocusedRow.Font
                Grid(x).Appearance.FocusedRow.ForeColor = .FocusedRow.ForeColor

                Grid(x).Appearance.FooterPanel.BackColor = .FooterPanel.BackColor
                Grid(x).Appearance.FooterPanel.BackColor2 = .FooterPanel.BackColor2
                Grid(x).Appearance.FooterPanel.BorderColor = .FooterPanel.BorderColor
                Grid(x).Appearance.FooterPanel.Font = .FooterPanel.Font
                Grid(x).Appearance.FooterPanel.ForeColor = .FooterPanel.ForeColor

                Grid(x).Appearance.GroupButton.BackColor = .GroupButton.BackColor
                Grid(x).Appearance.GroupButton.BackColor2 = .GroupButton.BackColor2
                Grid(x).Appearance.GroupButton.BorderColor = .GroupButton.BorderColor
                Grid(x).Appearance.GroupButton.Font = .GroupButton.Font
                Grid(x).Appearance.GroupButton.ForeColor = .GroupButton.ForeColor

                Grid(x).Appearance.GroupFooter.BackColor = .GroupFooter.BackColor
                Grid(x).Appearance.GroupFooter.BackColor2 = .GroupFooter.BackColor2
                Grid(x).Appearance.GroupFooter.BorderColor = .GroupFooter.BorderColor
                Grid(x).Appearance.GroupFooter.Font = .GroupFooter.Font
                Grid(x).Appearance.GroupFooter.ForeColor = .GroupFooter.ForeColor

                Grid(x).Appearance.GroupPanel.BackColor = .GroupPanel.BackColor
                Grid(x).Appearance.GroupPanel.BackColor2 = .GroupPanel.BackColor2
                Grid(x).Appearance.GroupPanel.BorderColor = .GroupPanel.BorderColor
                Grid(x).Appearance.GroupPanel.Font = .GroupPanel.Font
                Grid(x).Appearance.GroupPanel.ForeColor = .GroupPanel.ForeColor

                Grid(x).Appearance.GroupRow.BackColor = .GroupRow.BackColor
                Grid(x).Appearance.GroupRow.BackColor2 = .GroupRow.BackColor2
                Grid(x).Appearance.GroupRow.BorderColor = .GroupRow.BorderColor
                Grid(x).Appearance.GroupRow.Font = .GroupRow.Font
                Grid(x).Appearance.GroupRow.ForeColor = .GroupRow.ForeColor

                Grid(x).Appearance.HeaderPanel.BackColor = .HeaderPanel.BackColor
                Grid(x).Appearance.HeaderPanel.BackColor2 = .HeaderPanel.BackColor2
                Grid(x).Appearance.HeaderPanel.BorderColor = .HeaderPanel.BorderColor
                Grid(x).Appearance.HeaderPanel.Font = .HeaderPanel.Font
                Grid(x).Appearance.HeaderPanel.ForeColor = .HeaderPanel.ForeColor

                Grid(x).Appearance.HideSelectionRow.BackColor = .HideSelectionRow.BackColor
                Grid(x).Appearance.HideSelectionRow.BackColor2 = .HideSelectionRow.BackColor2
                Grid(x).Appearance.HideSelectionRow.BorderColor = .HideSelectionRow.BorderColor
                Grid(x).Appearance.HideSelectionRow.Font = .HideSelectionRow.Font
                Grid(x).Appearance.HideSelectionRow.ForeColor = .HideSelectionRow.ForeColor

                Grid(x).Appearance.HorzLine.BackColor = .HorzLine.BackColor
                Grid(x).Appearance.HorzLine.BackColor2 = .HorzLine.BackColor2
                Grid(x).Appearance.HorzLine.BorderColor = .HorzLine.BorderColor
                Grid(x).Appearance.HorzLine.Font = .HorzLine.Font
                Grid(x).Appearance.HorzLine.ForeColor = .HorzLine.ForeColor

                Grid(x).Appearance.OddRow.BackColor = .OddRow.BackColor
                Grid(x).Appearance.OddRow.BackColor2 = .OddRow.BackColor2
                Grid(x).Appearance.OddRow.BorderColor = .OddRow.BorderColor
                Grid(x).Appearance.OddRow.Font = .OddRow.Font
                Grid(x).Appearance.OddRow.ForeColor = .OddRow.ForeColor

                Grid(x).Appearance.Preview.BackColor = .Preview.BackColor
                Grid(x).Appearance.Preview.BackColor2 = .Preview.BackColor2
                Grid(x).Appearance.Preview.BorderColor = .Preview.BorderColor
                Grid(x).Appearance.Preview.Font = .Preview.Font
                Grid(x).Appearance.Preview.ForeColor = .Preview.ForeColor

                Grid(x).Appearance.Row.BackColor = .Row.BackColor
                Grid(x).Appearance.Row.BackColor2 = .Row.BackColor2
                Grid(x).Appearance.Row.BorderColor = .Row.BorderColor
                Grid(x).Appearance.Row.Font = .Row.Font
                Grid(x).Appearance.Row.ForeColor = .Row.ForeColor

                Grid(x).Appearance.RowSeparator.BackColor = .RowSeparator.BackColor
                Grid(x).Appearance.RowSeparator.BackColor2 = .RowSeparator.BackColor2
                Grid(x).Appearance.RowSeparator.BorderColor = .RowSeparator.BorderColor
                Grid(x).Appearance.RowSeparator.Font = .RowSeparator.Font
                Grid(x).Appearance.RowSeparator.ForeColor = .RowSeparator.ForeColor

                Grid(x).Appearance.SelectedRow.BackColor = .SelectedRow.BackColor
                Grid(x).Appearance.SelectedRow.BackColor2 = .SelectedRow.BackColor2
                Grid(x).Appearance.SelectedRow.BorderColor = .SelectedRow.BorderColor
                Grid(x).Appearance.SelectedRow.Font = .SelectedRow.Font
                Grid(x).Appearance.SelectedRow.ForeColor = .SelectedRow.ForeColor

                Grid(x).Appearance.TopNewRow.BackColor = .TopNewRow.BackColor
                Grid(x).Appearance.TopNewRow.BackColor2 = .TopNewRow.BackColor2
                Grid(x).Appearance.TopNewRow.BorderColor = .TopNewRow.BorderColor
                Grid(x).Appearance.TopNewRow.Font = .TopNewRow.Font
                Grid(x).Appearance.TopNewRow.ForeColor = .TopNewRow.ForeColor

                Grid(x).Appearance.VertLine.BackColor = .VertLine.BackColor
                Grid(x).Appearance.VertLine.BackColor2 = .VertLine.BackColor2
                Grid(x).Appearance.VertLine.BorderColor = .VertLine.BorderColor
                Grid(x).Appearance.VertLine.Font = .VertLine.Font
                Grid(x).Appearance.VertLine.ForeColor = .VertLine.ForeColor

                Grid(x).Appearance.ViewCaption.BackColor = .ViewCaption.BackColor
                Grid(x).Appearance.ViewCaption.BackColor2 = .ViewCaption.BackColor2
                Grid(x).Appearance.ViewCaption.BorderColor = .ViewCaption.BorderColor
                Grid(x).Appearance.ViewCaption.Font = .ViewCaption.Font
                Grid(x).Appearance.ViewCaption.ForeColor = .ViewCaption.ForeColor
            End With
        Next
    End Sub

    Public Sub GetBandedGridApperance(BandedGrid() As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)
        For x As Integer = 0 To BandedGrid.Length - 1
            With FrmPerformanceReport.BandedGridView1.Appearance
                Dim Col As New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
                Dim Band As New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                For Each Col In BandedGrid(x).Columns
                    Col.AppearanceHeader.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid))
                Next
                For Each Band In BandedGrid(x).Bands
                    Band.AppearanceHeader.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Bold)
                Next

                BandedGrid(x).Appearance.BandPanel.BackColor = .BandPanel.BackColor
                BandedGrid(x).Appearance.BandPanel.BackColor2 = .BandPanel.BackColor2
                BandedGrid(x).Appearance.BandPanel.BorderColor = .BandPanel.BorderColor
                BandedGrid(x).Appearance.BandPanel.Font = .BandPanel.Font
                BandedGrid(x).Appearance.BandPanel.ForeColor = .BandPanel.ForeColor

                BandedGrid(x).Appearance.BandPanelBackground.BackColor = .BandPanelBackground.BackColor
                BandedGrid(x).Appearance.BandPanelBackground.BackColor2 = .BandPanelBackground.BackColor2
                BandedGrid(x).Appearance.BandPanelBackground.BorderColor = .BandPanelBackground.BorderColor
                BandedGrid(x).Appearance.BandPanelBackground.Font = .BandPanelBackground.Font
                BandedGrid(x).Appearance.BandPanelBackground.ForeColor = .BandPanelBackground.ForeColor

                BandedGrid(x).Appearance.ColumnFilterButton.BackColor = .ColumnFilterButton.BackColor
                BandedGrid(x).Appearance.ColumnFilterButton.BackColor2 = .ColumnFilterButton.BackColor2
                BandedGrid(x).Appearance.ColumnFilterButton.BorderColor = .ColumnFilterButton.BorderColor
                BandedGrid(x).Appearance.ColumnFilterButton.Font = .ColumnFilterButton.Font
                BandedGrid(x).Appearance.ColumnFilterButton.ForeColor = .ColumnFilterButton.ForeColor

                BandedGrid(x).Appearance.ColumnFilterButtonActive.BackColor = .ColumnFilterButtonActive.BackColor
                BandedGrid(x).Appearance.ColumnFilterButtonActive.BackColor2 = .ColumnFilterButtonActive.BackColor2
                BandedGrid(x).Appearance.ColumnFilterButtonActive.BorderColor = .ColumnFilterButtonActive.BorderColor
                BandedGrid(x).Appearance.ColumnFilterButtonActive.Font = .ColumnFilterButtonActive.Font
                BandedGrid(x).Appearance.ColumnFilterButtonActive.ForeColor = .ColumnFilterButtonActive.ForeColor

                BandedGrid(x).Appearance.CustomizationFormHint.BackColor = .CustomizationFormHint.BackColor
                BandedGrid(x).Appearance.CustomizationFormHint.BackColor2 = .CustomizationFormHint.BackColor2
                BandedGrid(x).Appearance.CustomizationFormHint.BorderColor = .CustomizationFormHint.BorderColor
                BandedGrid(x).Appearance.CustomizationFormHint.Font = .CustomizationFormHint.Font
                BandedGrid(x).Appearance.CustomizationFormHint.ForeColor = .CustomizationFormHint.ForeColor

                BandedGrid(x).Appearance.DetailTip.BackColor = .DetailTip.BackColor
                BandedGrid(x).Appearance.DetailTip.BackColor2 = .DetailTip.BackColor2
                BandedGrid(x).Appearance.DetailTip.BorderColor = .DetailTip.BorderColor
                BandedGrid(x).Appearance.DetailTip.Font = .DetailTip.Font
                BandedGrid(x).Appearance.DetailTip.ForeColor = .DetailTip.ForeColor

                BandedGrid(x).Appearance.Empty.BackColor = .Empty.BackColor
                BandedGrid(x).Appearance.Empty.BackColor2 = .Empty.BackColor2
                BandedGrid(x).Appearance.Empty.BorderColor = .Empty.BorderColor
                BandedGrid(x).Appearance.Empty.Font = .Empty.Font
                BandedGrid(x).Appearance.Empty.ForeColor = .Empty.ForeColor

                BandedGrid(x).Appearance.EvenRow.BackColor = .EvenRow.BackColor
                BandedGrid(x).Appearance.EvenRow.BackColor2 = .EvenRow.BackColor2
                BandedGrid(x).Appearance.EvenRow.BorderColor = .EvenRow.BorderColor
                BandedGrid(x).Appearance.EvenRow.Font = .EvenRow.Font
                BandedGrid(x).Appearance.EvenRow.ForeColor = .EvenRow.ForeColor

                BandedGrid(x).Appearance.FilterCloseButton.BackColor = .FilterCloseButton.BackColor
                BandedGrid(x).Appearance.FilterCloseButton.BackColor2 = .FilterCloseButton.BackColor2
                BandedGrid(x).Appearance.FilterCloseButton.BorderColor = .FilterCloseButton.BorderColor
                BandedGrid(x).Appearance.FilterCloseButton.Font = .FilterCloseButton.Font
                BandedGrid(x).Appearance.FilterCloseButton.ForeColor = .FilterCloseButton.ForeColor

                BandedGrid(x).Appearance.FilterPanel.BackColor = .FilterPanel.BackColor
                BandedGrid(x).Appearance.FilterPanel.BackColor2 = .FilterPanel.BackColor2
                BandedGrid(x).Appearance.FilterPanel.BorderColor = .FilterPanel.BorderColor
                BandedGrid(x).Appearance.FilterPanel.Font = .FilterPanel.Font
                BandedGrid(x).Appearance.FilterPanel.ForeColor = .FilterPanel.ForeColor

                BandedGrid(x).Appearance.FixedLine.BackColor = .FixedLine.BackColor
                BandedGrid(x).Appearance.FixedLine.BackColor2 = .FixedLine.BackColor2
                BandedGrid(x).Appearance.FixedLine.BorderColor = .FixedLine.BorderColor
                BandedGrid(x).Appearance.FixedLine.Font = .FixedLine.Font
                BandedGrid(x).Appearance.FixedLine.ForeColor = .FixedLine.ForeColor

                BandedGrid(x).Appearance.FocusedCell.BackColor = .FocusedCell.BackColor
                BandedGrid(x).Appearance.FocusedCell.BackColor2 = .FocusedCell.BackColor2
                BandedGrid(x).Appearance.FocusedCell.BorderColor = .FocusedCell.BorderColor
                BandedGrid(x).Appearance.FocusedCell.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid) + 1, FontStyle.Bold)
                BandedGrid(x).Appearance.FocusedCell.ForeColor = .FocusedCell.ForeColor

                BandedGrid(x).Appearance.FocusedRow.BackColor = .FocusedRow.BackColor
                BandedGrid(x).Appearance.FocusedRow.BackColor2 = .FocusedRow.BackColor2
                BandedGrid(x).Appearance.FocusedRow.BorderColor = .FocusedRow.BorderColor
                BandedGrid(x).Appearance.FocusedRow.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid) + 1, FontStyle.Bold)
                BandedGrid(x).Appearance.FocusedRow.ForeColor = .FocusedRow.ForeColor

                BandedGrid(x).Appearance.FooterPanel.BackColor = .FooterPanel.BackColor
                BandedGrid(x).Appearance.FooterPanel.BackColor2 = .FooterPanel.BackColor2
                BandedGrid(x).Appearance.FooterPanel.BorderColor = .FooterPanel.BorderColor
                BandedGrid(x).Appearance.FooterPanel.Font = .FooterPanel.Font
                BandedGrid(x).Appearance.FooterPanel.ForeColor = .FooterPanel.ForeColor

                BandedGrid(x).Appearance.GroupButton.BackColor = .GroupButton.BackColor
                BandedGrid(x).Appearance.GroupButton.BackColor2 = .GroupButton.BackColor2
                BandedGrid(x).Appearance.GroupButton.BorderColor = .GroupButton.BorderColor
                BandedGrid(x).Appearance.GroupButton.Font = .GroupButton.Font
                BandedGrid(x).Appearance.GroupButton.ForeColor = .GroupButton.ForeColor

                BandedGrid(x).Appearance.GroupFooter.BackColor = .GroupFooter.BackColor
                BandedGrid(x).Appearance.GroupFooter.BackColor2 = .GroupFooter.BackColor2
                BandedGrid(x).Appearance.GroupFooter.BorderColor = .GroupFooter.BorderColor
                BandedGrid(x).Appearance.GroupFooter.Font = .GroupFooter.Font
                BandedGrid(x).Appearance.GroupFooter.ForeColor = .GroupFooter.ForeColor

                BandedGrid(x).Appearance.GroupPanel.BackColor = .GroupPanel.BackColor
                BandedGrid(x).Appearance.GroupPanel.BackColor2 = .GroupPanel.BackColor2
                BandedGrid(x).Appearance.GroupPanel.BorderColor = .GroupPanel.BorderColor
                BandedGrid(x).Appearance.GroupPanel.Font = .GroupPanel.Font
                BandedGrid(x).Appearance.GroupPanel.ForeColor = .GroupPanel.ForeColor

                BandedGrid(x).Appearance.GroupRow.BackColor = .GroupRow.BackColor
                BandedGrid(x).Appearance.GroupRow.BackColor2 = .GroupRow.BackColor2
                BandedGrid(x).Appearance.GroupRow.BorderColor = .GroupRow.BorderColor
                BandedGrid(x).Appearance.GroupRow.Font = .GroupRow.Font
                BandedGrid(x).Appearance.GroupRow.ForeColor = .GroupRow.ForeColor

                BandedGrid(x).Appearance.HeaderPanel.BackColor = .HeaderPanel.BackColor
                BandedGrid(x).Appearance.HeaderPanel.BackColor2 = .HeaderPanel.BackColor2
                BandedGrid(x).Appearance.HeaderPanel.BorderColor = .HeaderPanel.BorderColor
                BandedGrid(x).Appearance.HeaderPanel.Font = .HeaderPanel.Font
                BandedGrid(x).Appearance.HeaderPanel.ForeColor = .HeaderPanel.ForeColor

                BandedGrid(x).Appearance.HeaderPanelBackground.BackColor = .HeaderPanelBackground.BackColor
                BandedGrid(x).Appearance.HeaderPanelBackground.BackColor2 = .HeaderPanelBackground.BackColor2
                BandedGrid(x).Appearance.HeaderPanelBackground.BorderColor = .HeaderPanelBackground.BorderColor
                BandedGrid(x).Appearance.HeaderPanelBackground.Font = .HeaderPanelBackground.Font
                BandedGrid(x).Appearance.HeaderPanelBackground.ForeColor = .HeaderPanelBackground.ForeColor

                BandedGrid(x).Appearance.HideSelectionRow.BackColor = .HideSelectionRow.BackColor
                BandedGrid(x).Appearance.HideSelectionRow.BackColor2 = .HideSelectionRow.BackColor2
                BandedGrid(x).Appearance.HideSelectionRow.BorderColor = .HideSelectionRow.BorderColor
                BandedGrid(x).Appearance.HideSelectionRow.Font = .HideSelectionRow.Font
                BandedGrid(x).Appearance.HideSelectionRow.ForeColor = .HideSelectionRow.ForeColor

                BandedGrid(x).Appearance.HorzLine.BackColor = .HorzLine.BackColor
                BandedGrid(x).Appearance.HorzLine.BackColor2 = .HorzLine.BackColor2
                BandedGrid(x).Appearance.HorzLine.BorderColor = .HorzLine.BorderColor
                BandedGrid(x).Appearance.HorzLine.Font = .HorzLine.Font
                BandedGrid(x).Appearance.HorzLine.ForeColor = .HorzLine.ForeColor

                BandedGrid(x).Appearance.OddRow.BackColor = .OddRow.BackColor
                BandedGrid(x).Appearance.OddRow.BackColor2 = .OddRow.BackColor2
                BandedGrid(x).Appearance.OddRow.BorderColor = .OddRow.BorderColor
                BandedGrid(x).Appearance.OddRow.Font = .OddRow.Font
                BandedGrid(x).Appearance.OddRow.ForeColor = .OddRow.ForeColor

                BandedGrid(x).Appearance.Preview.BackColor = .Preview.BackColor
                BandedGrid(x).Appearance.Preview.BackColor2 = .Preview.BackColor2
                BandedGrid(x).Appearance.Preview.BorderColor = .Preview.BorderColor
                BandedGrid(x).Appearance.Preview.Font = .Preview.Font
                BandedGrid(x).Appearance.Preview.ForeColor = .Preview.ForeColor

                BandedGrid(x).Appearance.Row.BackColor = .Row.BackColor
                BandedGrid(x).Appearance.Row.BackColor2 = .Row.BackColor2
                BandedGrid(x).Appearance.Row.BorderColor = .Row.BorderColor
                BandedGrid(x).Appearance.Row.Font = .Row.Font
                BandedGrid(x).Appearance.Row.ForeColor = .Row.ForeColor

                BandedGrid(x).Appearance.RowSeparator.BackColor = .RowSeparator.BackColor
                BandedGrid(x).Appearance.RowSeparator.BackColor2 = .RowSeparator.BackColor2
                BandedGrid(x).Appearance.RowSeparator.BorderColor = .RowSeparator.BorderColor
                BandedGrid(x).Appearance.RowSeparator.Font = .RowSeparator.Font
                BandedGrid(x).Appearance.RowSeparator.ForeColor = .RowSeparator.ForeColor

                BandedGrid(x).Appearance.SelectedRow.BackColor = .SelectedRow.BackColor
                BandedGrid(x).Appearance.SelectedRow.BackColor2 = .SelectedRow.BackColor2
                BandedGrid(x).Appearance.SelectedRow.BorderColor = .SelectedRow.BorderColor
                BandedGrid(x).Appearance.SelectedRow.Font = .SelectedRow.Font
                BandedGrid(x).Appearance.SelectedRow.ForeColor = .SelectedRow.ForeColor

                BandedGrid(x).Appearance.TopNewRow.BackColor = .TopNewRow.BackColor
                BandedGrid(x).Appearance.TopNewRow.BackColor2 = .TopNewRow.BackColor2
                BandedGrid(x).Appearance.TopNewRow.BorderColor = .TopNewRow.BorderColor
                BandedGrid(x).Appearance.TopNewRow.Font = .TopNewRow.Font
                BandedGrid(x).Appearance.TopNewRow.ForeColor = .TopNewRow.ForeColor

                BandedGrid(x).Appearance.VertLine.BackColor = .VertLine.BackColor
                BandedGrid(x).Appearance.VertLine.BackColor2 = .VertLine.BackColor2
                BandedGrid(x).Appearance.VertLine.BorderColor = .VertLine.BorderColor
                BandedGrid(x).Appearance.VertLine.Font = .VertLine.Font
                BandedGrid(x).Appearance.VertLine.ForeColor = .VertLine.ForeColor

                BandedGrid(x).Appearance.ViewCaption.BackColor = .ViewCaption.BackColor
                BandedGrid(x).Appearance.ViewCaption.BackColor2 = .ViewCaption.BackColor2
                BandedGrid(x).Appearance.ViewCaption.BorderColor = .ViewCaption.BorderColor
                BandedGrid(x).Appearance.ViewCaption.Font = .ViewCaption.Font
                BandedGrid(x).Appearance.ViewCaption.ForeColor = .ViewCaption.ForeColor
            End With
        Next
    End Sub

    'GROUP CONTROL ***************************************************************************************************************************
    Public Sub GetGroupControlFontSettings(Title() As DevExpress.XtraEditors.GroupControl)
        For x As Integer = 0 To Title.Length - 1
            With Title(x)
                .AppearanceCaption.Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                .AppearanceCaption.ForeColor = Color.Black
                '.Appearance.BorderColor = OfficialColor2
                .Appearance.BorderColor = Color.Black
            End With
        Next
    End Sub

    Public Sub GetGroupControlExpandableFontSettings(Title() As DevExpress.XtraEditors.GroupControl)
        For x As Integer = 0 To Title.Length - 1
            With Title(x)
                .AppearanceCaption.Font = New Font(OfficialFont, .Font.Size, FontStyle.Bold)
                .AppearanceCaption.BackColor = OfficialColor1
            End With
        Next
    End Sub

    'CHART **************************************************************************************************************************
    Public Sub GetChartTitleControlFontSettings(Chart() As DevExpress.XtraCharts.ChartControl)
        For x As Integer = 0 To Chart.Length - 1
            With Chart(x)
                '.BorderOptions.Color = OfficialColor2
                .BorderOptions.Color = Color.Black
                .BorderOptions.Thickness = 2
                .ForeColor = Color.Black
                If .Titles.Count > 0 Then
                    .Titles(0).Font = New Font(OfficialFont, .Titles(0).Font.Size, .Titles(0).Font.Style)
                    .Titles(0).TextColor = Color.Black
                End If
                .Legend.Font = New Font(OfficialFont, .Legend.Font.Size, .Legend.Font.Style)
            End With
        Next
    End Sub

    'LINE **************************************************************************************************************************
    Public Sub GetLineControlFontSettings(Line() As DevComponents.DotNetBar.Controls.Line)
        For x As Integer = 0 To Line.Length - 1
            With Line(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                .ForeColor = Color.Black ' OfficialColor1
            End With
        Next
    End Sub

    'ALERT ***************************************************************************************************************************
    Public Sub GetAlertControlFontSettings(Alert() As DevExpress.XtraBars.Alerter.AlertControl)
        For x As Integer = 0 To Alert.Length - 1
            With Alert(x)
                .AppearanceCaption.Font = New Font(OfficialFont, .AppearanceCaption.Font.Size, .AppearanceCaption.Font.Style)
                .AppearanceHotTrackedText.Font = New Font(OfficialFont, .AppearanceHotTrackedText.Font.Size, .AppearanceHotTrackedText.Font.Style)
                .AppearanceText.Font = New Font(OfficialFont, .AppearanceText.Font.Size, .AppearanceText.Font.Style)
            End With
        Next
    End Sub

    Public Sub GetToolTipFontSettings(ToolTip() As DevExpress.Utils.ToolTipController)
        For x As Integer = 0 To ToolTip.Length - 1
            With ToolTip(x)
                .Appearance.Font = New Font(OfficialFont, .Appearance.Font.Size, .Appearance.Font.Style)
                .AppearanceTitle.Font = New Font(OfficialFont, .AppearanceTitle.Font.Size, .AppearanceTitle.Font.Style)
            End With
        Next
    End Sub

    'REPORT
    Public Sub ReportLabelWithBackgroundFontSettings(Label() As DevExpress.XtraReports.UI.XRLabel)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
                '.ForeColor = Color.White
                .BackColor = OfficialColor1
            End With
        Next
    End Sub

    Public Sub ReportLabelFontSettings(Label() As DevExpress.XtraReports.UI.XRLabel)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
            End With
        Next
    End Sub

    Public Sub ReportPageInfoFontSettings(Label() As DevExpress.XtraReports.UI.XRPageInfo)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
            End With
        Next
    End Sub

    Public Sub ReportCheckBoxFontSettings(Label() As DevExpress.XtraReports.UI.XRCheckBox)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
            End With
        Next
    End Sub

    Public Sub ReportTableCellFontSettings(Label() As DevExpress.XtraReports.UI.XRTableCell)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, 7, .Font.Style)
            End With
        Next
    End Sub

    Public Sub ReportRichTextFontSettings(Label() As DevExpress.XtraReports.UI.XRRichText)
        For x As Integer = 0 To Label.Length - 1
            With Label(x)
                .Font = New Font(OfficialFont, .Font.Size, .Font.Style)
            End With
        Next
    End Sub

    Private Function F1cd318e412b5f7226e5f377a9544ff7()
        If Computer = "ARGOWSL-044" And _DatabaseName.ToLower = "fsfc" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub TriggerBugReport(Frm As String, M As String)
        If Auto_BugReport = False Then
            MsgBox(M, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Try
            FrmMain.PrintscreenActivate = True
            If Clipboard.ContainsImage = False Then
                SendKeys.Send("{PRTSC}")
            End If
            Dim Screenshot As Image = Clipboard.GetImage()
            Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\System Concern [" & Format(Date.Now, "yyyyMMddHHmmss") & "].jpg"
            If IsNothing(Screenshot) Then
                MsgBox(M, MsgBoxStyle.Information, "Info")
                Exit Sub
            Else
                Screenshot.Save(FName, Imaging.ImageFormat.Jpeg)
            End If
            Dim Report As New FrmReportProblem
            With Report
                .FName = FName
                .pbMain.Image = Screenshot.Clone
                .txtBody.Text = "[" & Frm & "] " & M
                .AutoSend = True
                .ShowDialog()
                .Dispose()
            End With
            If Clipboard.ContainsImage Then
                Clipboard.Clear()
            End If
            FrmMain.PrintscreenActivate = False
        Catch ex As Exception
        End Try
    End Sub

    Public Function CaptureScreen()
        Dim bounds As Rectangle
        Dim screenshot As Bitmap
        Dim graph As Graphics
        bounds = Screen.PrimaryScreen.Bounds
        screenshot = New Bitmap(bounds.Width, bounds.Height, Imaging.PixelFormat.Format32bppArgb)
        graph = Graphics.FromImage(screenshot)
        graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
        Return screenshot
    End Function

    Public Sub FixUnitStandard()
        Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "MM/dd/yyyy")
    End Sub

    Public Function CheckLoggedComputer()
        Dim NewLogged As Boolean = True
        For x As Integer = 0 To DTLoggedComputer.Rows.Count - 1
            If DTLoggedComputer(x)("computer") = Computer And DTLoggedComputer(x)("ip_address") = IP_Address Then
                NewLogged = False
                Exit For
            End If
        Next
        Return NewLogged
    End Function

    Public Sub PrintSchedule(AmountApplied As String, Terms As String, Product As String, Purpose As String, xDate As String, Fname As String, Grid As DevExpress.XtraGrid.GridControl)
        Dim Report As New RptAmortizationSchedule
        With Report
            .Name = "Amortization Scheduling"
            .lblAmountApplied.Text = AmountApplied
            .lblTerms.Text = Terms
            .lblProduct.Text = Product
            .lblPurpose.Text = Purpose
            .lblDate.Text = xDate

            .DataSource = Grid.DataSource
            .lblNo.DataBindings.Add("Text", Grid.DataSource, "No")
            .lblDue.DataBindings.Add("Text", Grid.DataSource, "Due Date")
            .lblMonthly.DataBindings.Add("Text", Grid.DataSource, "Monthly")
            .lblInterest.DataBindings.Add("Text", Grid.DataSource, "Interest Income")
            .lblRPPD.DataBindings.Add("Text", Grid.DataSource, "RPPD")
            .lblPrincipal.DataBindings.Add("Text", Grid.DataSource, "Principal Allocation")
            .lblOutstanding.DataBindings.Add("Text", Grid.DataSource, "Outstanding Principal")
            .lblUnearn.DataBindings.Add("Text", Grid.DataSource, "Unearn Income")
            .lblRPPD_2.DataBindings.Add("Text", Grid.DataSource, "Total_RPPD")
            .lblLoansReceivable.DataBindings.Add("Text", Grid.DataSource, "Loans Receivable")
            If CompanyMode = 0 Then
                .XrLabel15.Text = "Interest"
                .XrLabel11.Visible = False
                .XrLabel14.Visible = False

                .lblRPPD.Visible = False
                .lblRPPD_2.Visible = False

                .XrLabel9.SizeF = New SizeF(115 + 45, 30)
                .XrLabel10.SizeF = New SizeF(115 + 35, 30)
                .XrLabel12.SizeF = New SizeF(115 + 35, 30)
                .XrLabel13.SizeF = New SizeF(115 + 35, 30)
                .XrLabel15.SizeF = New SizeF(115 + 35, 30)
                .XrLabel16.SizeF = New SizeF(115 + 45, 30)

                .XrLabel10.Location = New Point(130 + 160, 135)
                .XrLabel12.Location = New Point(130 + 310, 135)
                .XrLabel13.Location = New Point(130 + 460, 135)
                .XrLabel15.Location = New Point(130 + 610, 135)
                .XrLabel16.Location = New Point(130 + 760, 135)

                .lblMonthly.SizeF = New SizeF(115 + 45, 30)
                .lblInterest.SizeF = New SizeF(115 + 35, 30)
                .lblPrincipal.SizeF = New SizeF(115 + 35, 30)
                .lblOutstanding.SizeF = New SizeF(115 + 35, 30)
                .lblUnearn.SizeF = New SizeF(115 + 35, 30)
                .lblLoansReceivable.SizeF = New SizeF(115 + 45, 30)

                .lblInterest.Location = New Point(130 + 160, 0)
                .lblPrincipal.Location = New Point(130 + 310, 0)
                .lblOutstanding.Location = New Point(130 + 460, 0)
                .lblUnearn.Location = New Point(130 + 610, 0)
                .lblLoansReceivable.Location = New Point(130 + 760, 0)
            End If
            .ExportToPdf(Fname)
        End With
    End Sub
End Module
