Public Class RptAmortizationCalculatorV2

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelFontSettings({XrLabel5, lblCreditNumber, XrLabel6, lblTerms, XrLabel2, lblInterest_Rate, XrLabel4, lblRPPD_Rate, XrLabel7, lblPA, XrLabel9, lblUDI, XrLabel11, lblRPPD, XrLabel13, lblFA, XrLabel15, lblGMA, XrLabel17, lblMR, XrLabel19, lblNMA, XrLabel22, XrLabel21, lblTotalPF, XrLabel23, lblSC, XrLabel12, lblAppraisal, XrLabel18, lblCI, XrLabel27, lblInsurance, XrLabel25, lblPFandSC, XrLabel14, lblAdvancePayment, XrLabel8, lblDeductBalance, XrLabel29, lblTotalDeductions, XrLabel31, lblNetProceeds, XrLabel1, XrLabel3, lblPA_2, XrLabel10, lblUDI_2, XrLabel20, lblSC_2, XrLabel26, lblTotalPF_2, XrLabel40, lblInsurance_2, XrLabel32, lblNetProceeds_2, lblMonthlyAmort, lblGMA_2, XrLabel36, lblTerms_2, XrLabel38, lblInterest_Rate_2})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
        ReportRichTextFontSettings({rNote})
        ReportTableCellFontSettings({XrTableCell4, XrTableCell5, XrTableCell6, tAmount, tTerms, tCollateral, XrTableCell1, XrTableCell2})
    End Sub
End Class