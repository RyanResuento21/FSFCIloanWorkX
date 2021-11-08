Public Class RptLoanApplication

    Public CompareFromBorrower As Boolean

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel3, XrLabel41, XrLabel42, XrLabel43, XrLabel56, XrLabel99, XrLabel100, XrLabel101, XrLabel102, XrLabel106, XrLabel108, XrLabel111, XrLabel124, XrLabel11, XrLabel125, XrLabel126, XrLabel127, XrLabel128, XrLabel129, XrLabel148, XrLabel149, XrLabel150, XrLabel151, XrLabel152, XrLabel153, XrLabel169, XrLabel170, XrLabel171, XrLabel172, XrLabel173, XrLabel189, XrLabel192, XrLabel193, XrLabel194, XrLabel195, XrLabel7, XrLabel13})
        ReportLabelFontSettings({XrLabel4, XrLabel6, XrLabel8, XrLabel10, XrLabel12, XrLabel14, XrLabel16, XrLabel18, XrLabel22, XrLabel24, XrLabel28, XrLabel33, XrLabel36, lblBorrowerID, XrLabel5, lblLoanNumber, lblBorrower, lblSpouse, lblCoMaker1, lblCoMakerII, lblCompleteAdd, lblProvincialAdd, lblBirthDate, XrLabel20, lblBirthPlace, XrLabel23, lblCitizenship, XrLabel26, lblTIN, lblTelephone, XrLabel30, lblSSS, lblMobile, XrLabel35, lblEmail, lblRent, lblDependent_1, lblBirthDate_1, lblGrade_1, lblDependent_2, lblBirthDate_2, lblGrade_2, lblDependent_3, lblBirthDate_3, lblGrade_3, lblDependent_4, lblBirthDate_4, lblGrade_4, XrLabel57, XrLabel63, XrLabel67, XrLabel15, XrLabel29, XrLabel45, XrLabel74, XrLabel81, XrLabel85, XrLabel89, XrLabel95, lblEmployer, lblPosition, lblDateHired, lblEmployer_S, lblPosition_S, lblDateHired_S, lblBusiness, lblNature, lblNoEmployees, lblCoverageArea, lblOtherIncome, XrLabel59, XrLabel65, XrLabel69, XrLabel19, XrLabel32, XrLabel37, XrLabel75, XrLabel79, XrLabel87, XrLabel91, XrLabel97, lblEmployerAddress, lblSupervisor, lblEmployerAddress_S, lblSupervisor_S, lblBusinessAddress, lblYearsOperation, lblCapital, lblExpiry, lblOtherMonthlyIncome, XrLabel61, lblEmployerTel, XrLabel71, lblMonthlyIncome, XrLabel25, lblEmployerTel_S, XrLabel47, lblMonthlyIncome_S, XrLabel77, lblBusinessTel, XrLabel83, lblBusinessIncome, XrLabel93, lblOutlet, lblCreditor_1, lblNature_1, lblAmount_1, lblTerm_1, lblBalance_1, lblRemarks_1, lblCreditor_2, lblNature_2, lblAmount_2, lblTerm_2, lblBalance_2, lblRemarks_2, lblCreditor_3, lblNature_3, lblAmount_3, lblTerm_3, lblBalance_3, lblRemarks_3, lblBank_1, lblBranch_1, lblSA_1, lblAverage_1, lblPresent_1, lblDateOpened_1, lblBankRemarks_1, lblBank_2, lblBranch_2, lblSA_2, lblAverage_2, lblPresent_2, lblDateOpened_2, lblBankRemarks_2, lblBank_3, lblBranch_3, lblSA_3, lblAverage_3, lblPresent_3, lblDateOpened_3, lblBankRemarks_3, lblLocation_1, lblTCT_1, lblArea_1, lblAcquired_1, lblEstateRemarks_1, lblLocation_2, lblTCT_2, lblArea_2, lblAcquired_2, lblEstateRemarks_2, lblLocation_3, lblTCT_3, lblArea_3, lblAcquired_3, lblEstateRemarks_3, lblVehicle_1, lblYear_1, lblWhom_1, lblWhen_1, lblVehicleRemarks_1, lblVehicle_2, lblYear_2, lblWhom_2, lblWhen_2, lblVehicleRemarks_2, lblVehicle_3, lblYear_3, lblWhom_3, lblWhen_3, lblVehicleRemarks_3, XrLabel202, lblAppliances_1, lblAppliances_2, lblReference_1, lblReferenceAdd_1, lblReferenceTel_1, lblReference_2, lblReferenceAdd_2, lblReferenceTel_2, lblReference_3, lblReferenceAdd_3, lblReferenceTel_3, txtAgent, txtMarketing, txtWalkIn, txtDealer, XrLabel206, XrLabel207, XrLabel9, lblDateSigned, lblSignature_1, lblSignature_2, XrLabel213, XrLabel210, XrLabel212, lblRemarks, XrLabel214, XrLabel215, XrLabel216})
        ReportCheckBoxFontSettings({cbxMale, cbxFemale, cbxSingle, cbxMarried, cbxSeparated, cbxWidowed, cbxOwned, cbxFree, cbxRented, cbxCasual, cbxTemporary, cbxPermanent, cbxCasual_S, cbxTemporary_S, cbxPermanent_S, cbxAgent, cbxMarketing, cbxWalkIn, cbxDealer})
        ReportTableCellFontSettings({XrTableCell4, tAmount, XrTableCell5, tTerms, XrTableCell6, tCollateral, XrTableCell1, tPurpose, XrTableCell2, tDate, XrTableCell9, XrTableCell10, XrTableCell12, tResidence, tPlaceIssue, tDateIssue})
        ReportPageInfoFontSettings({XrPageInfo2})

        If CompareFromBorrower Then
            With lblBorrower
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblSpouse
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblCompleteAdd
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblProvincialAdd
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblBirthDate
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblBirthPlace
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With cbxMale
                If .Checked <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With cbxFemale
                If .Checked <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With cbxSingle
                If .Checked <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With cbxMarried
                If .Checked <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With cbxSeparated
                If .Checked <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With cbxWidowed
                If .Checked <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblCitizenship
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblTIN
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblTelephone
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblSSS
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblMobile
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblEmail
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With cbxOwned
                If .Checked <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With cbxFree
                If .Checked <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With cbxRented
                If .Checked <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblEmployer
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblEmployerAddress
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblEmployerTel
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblPosition
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With cbxCasual
                If .Checked <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With cbxTemporary
                If .Checked <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With cbxPermanent
                If .Checked <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblDateHired
                If .Text = "" And .Tag = "" Then
                Else
                    If If(.Text = "", .Text, DateValue(.Text)).ToString <> If(.Tag = "", .Tag, DateValue(.Tag)).ToString Then
                        .ForeColor = Color.Red
                    End If
                End If
            End With
            With lblSupervisor
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblMonthlyIncome
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblBusiness
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblBusinessAddress
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblBusinessTel
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblNature
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblYearsOperation
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblBusinessIncome
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblNoEmployees
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblCapital
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblCoverageArea
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblExpiry
                If .Text = "" And .Tag = "" Then
                Else
                    If If(.Text = "", .Text, DateValue(.Text)).ToString <> If(.Tag = "", .Tag, DateValue(.Tag)).ToString Then
                        .ForeColor = Color.Red
                    End If
                End If
            End With
            With lblOutlet
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblOtherIncome
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
            With lblOtherMonthlyIncome
                If .Text <> .Tag Then
                    .ForeColor = Color.Red
                End If
            End With
        End If
    End Sub
End Class