Public Class RptAmortizationCalculator

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({XrLabel20, lblCreditNumber_2, XrLabel16, lblCreditNumber, XrLabel6, lblTerms, XrLabel2, lblInterest_Rate, XrLabel4, lblRPPD_Rate, XrLabel7, lblPA, XrLabel9, lblUDI, XrLabel11, lblRPPD, XrLabel13, lblFA, XrLabel15, lblGMA, XrLabel17, lblMR, XrLabel19, lblNMA, XrLabel22, XrLabel21, lblTotalPF, XrLabel23, lblSC, XrLabel12, lblAppraisal, XrLabel18, lblCI, XrLabel27, lblInsurance, XrLabel25, lblPFandSC, XrLabel14, lblAdvancePayment, XrLabel8, lblDeductBalance, XrLabel29, lblTotalDeductions, XrLabel31, lblNetProceeds, XrLabel1, XrLabel33, lblTerms_2, XrLabel35, lblInterest_Rate_2, XrLabel37, lblRPPD_Rate_2, XrLabel39, lblPA_2, XrLabel41, lblUDI_2, XrLabel43, lblRPPD_2, XrLabel45, lblFA_2, XrLabel47, lblGMA_2, XrLabel49, lblMR_2, XrLabel51, lblNMA_2, XrLabel34, XrLabel53, lblTotalPF_2, XrLabel55, lblSC_2, XrLabel28, lblAppraisal_2, XrLabel32, lblCI_2, XrLabel59, lblInsurance_2, XrLabel57, lblPFandSC_2, XrLabel10, lblAdvancePayment_2, XrLabel5, lblDeductBalance_2, XrLabel61, lblTotalDeductions_2, XrLabel63, lblNetProceeds_2, XrLabel3})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
        ReportRichTextFontSettings({rNote, rNote_2})
        ReportTableCellFontSettings({XrTableCell4, XrTableCell5, XrTableCell6, tAmount, tTerms, tCollateral, XrTableCell38, XrTableCell39, XrTableCell40, tAmount_2, tTerms_2, tCollateral_2, XrTableCell1, XrTableCell2, XrTableCell3, XrTableCell7, XrTableCell18, XrTableCell19, XrTableCell22, XrTableCell23, XrTableCell20, XrTableCell21, XrTableCell8, XrTableCell9, XrTableCell16, XrTableCell17, XrTableCell26, XrTableCell27, XrTableCell24, XrTableCell25, XrTableCell28, XrTableCell29, XrTableCell14, XrTableCell15, XrTableCell12, XrTableCell13, XrTableCell44, XrTableCell45, XrTableCell46, XrTableCell47, XrTableCell48, XrTableCell49, XrTableCell50, XrTableCell51, XrTableCell52, XrTableCell53, XrTableCell54, XrTableCell55, XrTableCell56, XrTableCell57, XrTableCell58, XrTableCell59, XrTableCell60, XrTableCell61, XrTableCell62, XrTableCell63, XrTableCell64, XrTableCell65, XrTableCell66, XrTableCell67})
    End Sub
End Class