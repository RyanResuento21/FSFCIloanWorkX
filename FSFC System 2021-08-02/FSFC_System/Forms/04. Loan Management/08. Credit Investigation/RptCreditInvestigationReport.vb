﻿Public Class RptCreditInvestigationReport

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel17, XrLabel53, XrLabel54, XrLabel55, XrLabel68, XrLabel129, XrLabel182, XrLabel154, XrLabel155, XrLabel156, XrLabel157, XrLabel158, XrLabel159, XrLabel160, XrLabel197, XrLabel175, XrLabel176, XrLabel177, XrLabel178, XrLabel179, XrLabel204, XrLabel248, XrLabel227, XrLabel228, XrLabel229, XrLabel233, XrLabel230, XrLabel252, XrLabel251, XrLabel250, XrLabel249})
        ReportLabelFontSettings({XrLabel1, XrLabel2, XrLabel4, XrLabel5, XrLabel6, lblAmountApplied, lblTerms, lblCollateral, XrLabel8, lblDate, XrLabel11, lblCINumber, XrLabel12, lblCreditNumber, XrLabel19, lblBorrower, XrLabel22, lblSpouse, XrLabel25, lblCoMaker1, XrLabel28, XrLabel31, XrLabel34, XrLabel37, XrLabel40, XrLabel43, XrLabel50, lblCoMaker2, lblCoMaker3, lblCoMaker4, lblAddress, lblResidency, lblRent, lblConfirmed, XrLabel45, lblLength, XrLabel48, lblNeighborhood, lblBirthdate, XrLabel52, lblDependent1, lblAge1, lblGrade1, lblDependent2, lblAge2, lblGrade2, lblDependent3, lblAge3, lblGrade3, lblDependent4, lblAge4, lblGrade4, XrLabel70, XrLabel71, lblEmployer_B, XrLabel73, lblAddress_B, XrLabel76, lblDateHired_B, XrLabel79, XrLabel77, lblPosition_B, XrLabel83, lblMonthly_B, XrLabel85, XrLabel87, lblEmployer_S, XrLabel94, XrLabel90, lblAddress_S, XrLabel91, lblDateHired_S, XrLabel96, lblPosition_S, XrLabel98, lblMonthly_S, XrLabel78, XrLabel105, lblBusiness, XrLabel102, lblBusinessAddress, XrLabel101, lblStarted, XrLabel108, lblNatureBusiness, XrLabel111, lblCapital, XrLabel112, lblEmployees, XrLabel114, lblInventory, XrLabel117, lblBusinessVehicle, XrLabel120, lblBusinessIncome, XrLabel122, lblBusinessPermit, XrLabel125, lblOtherIncome, XrLabel128, lblOtherIncomeAmount, XrLabel131, XrLabel134, XrLabel137, XrLabel140, XrLabel143, XrLabel146, XrLabel149, XrLabel152, XrLabel132, XrLabel133, XrLabel138, XrLabel139, XrLabel144, XrLabel147, XrLabel150, XrLabel151, lblSalary_B, lblSalary_S, lblSalary_Business, lblSalary_C1, lblSalary_C2, lblSalary_C3, lblSalary_C4, lblSalary_T, XrLabel10, XrLabel7, XrLabel18, XrLabel29, XrLabel36, XrLabel46, XrLabel9, XrLabel56, lblBCapitalP, lblBFuelAndMaintenanceP, lblBUtilitiesP, lblBSalariesWagesP, lblBMiscellaneousP, lblBOthersP, lblTotalExpense, XrLabel58, XrLabel59, XrLabel60, XrLabel61, XrLabel62, XrLabel23, lblBCapital, lblBFuelAndMaintenance, lblBUtilities, lblBSalariesWages, lblBMiscellaneous, lblBOthers, lblCredit1, lblGranted1, lblTerms1, lblPrincipal1, lblOutstanding1, lblMonthlyPay1, lblCreditRemarks1, lblCredit2, lblGranted2, lblTerms2, lblPrincipal2, lblOutstanding2, lblMonthlyPay2, lblCreditRemarks2, lblBank1, lblBranch1, cbxAccountNum1, lblDaily1, lblOpened1, lblBank2, lblBranch2, cbxAccountNum2, lblDaily2, lblOpened2, XrLabel191, XrLabel192, XrLabel202, lblRecommendation, XrLabel193, lblApprovedAmount, XrLabel196, lblApprovedTerms, XrLabel201, XrLabel199, lblApprovedRate, XrLabel200, XrLabel206, XrLabel213, XrLabel220, XrLabel225, lblTitle, lblDateFilled, lblCaseStatus, lblOtherInfo, XrLabel215, lblCourtBranch, XrLabel223, lblFindings, XrLabel217, lblCaseNature, XrLabel208, lblCaseNumber, XrLabel211, lblAmountInvolved, lblLocation1, lblLocation2, lblTCT1, lblTCT2, lblArea1, lblArea2, lblRE_Remarks1, lblRE_Remarks2, lblVehicle1, lblVehicle2, lblModel1, lblModel2, lblAcquired1, lblAcquired2, lblVE_Remarks1, lblVE_Remarks2, XrLabel253, lblOtherProperty, XrLabel256, lblNarrative, XrLabel257, XrLabel259, XrLabel261, XrLabel263, XrLabel265, XrLabel266, XrLabel268, XrLabel271, XrLabel272, XrLabel274, lblCondition1, lblCondition2, lblCondition3, lblCondition4, lblCondition5, lblCondition6, lblCondition7, lblCondition8, lblCondition9, XrLabel276, XrLabel279, XrLabel281, XrLabel283, XrLabel286, XrLabel289, XrLabel292, XrLabel295, XrLabel298, XrLabel301, XrLabel304, XrLabel307, XrLabel310, XrLabel313, XrLabel316, XrLabel42, lblPreparedBy, XrLabel3, XrLabel278, lblIncome, XrLabel284, XrLabel285, XrLabel290, XrLabel291, XrLabel296, XrLabel297, XrLabel302, XrLabel303, XrLabel308, XrLabel309, XrLabel314, XrLabel315, XrLabel32, lblCheckedBy, XrLabel13, lblLivingExpense, lblClothing, lblEducation, lblTransportation, lblLight, lblInsurance, lblAmortazation, lblMiscellaneous, lblTotal, lblNetDisposable, lblTMFI, lblTMDI, XrLabel318, lblPurpose, XrLabel321, lblDeviations, XrLabel322})
        ReportCheckBoxFontSettings({cbxOwned, cbxFree, cbxRented, cbxSingle, cbxMarried, cbxSeparated, cbxWidowed, cbxCasual, cbxTemporary, cbxPermanent, cbxCasual_S, cbxTemporary_S, cbxPermanent_S, cbxSA1, cbxCA1, cbxSA2, cbxCA2, cbxGood, cbxFair, cbxPoor, cbxApproval, cbxDisapproval, cbxW_PDC, cbxNO_PDC, cbxPositive, cbxNegative, cbxUnestablied})
        ReportPageInfoFontSettings({XrPageInfo2})
    End Sub
End Class