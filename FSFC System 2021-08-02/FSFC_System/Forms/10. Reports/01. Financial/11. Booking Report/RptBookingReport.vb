Public Class RptBookingReport

    Private Sub Rpt_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'USER INTERFACE
        If AllowStandardUI = False Then
            Exit Sub
        End If
        ReportLabelWithBackgroundFontSettings({XrLabel1, XrLabel2, XrLabel3, XrLabel4, XrLabel5, XrLabel6, XrLabel7, XrLabel8, XrLabel9, XrLabel10, XrLabel11, XrLabel12, XrLabel19, XrLabel20, XrLabel13, XrLabel14, XrLabel15, XrLabel16, XrLabel22, XrLabel23, XrLabel24, XrLabel25, XrLabel26, XrLabel27, XrLabel28, XrLabel29, XrLabel17})
        ReportLabelFontSettings({lblTitle, lblAsOf, lblNo, lblDate, lblBorrower, lblAccountNumber, lblPrincipal, lblUDI, lblRPPD, lblFaceAmount, lblRate, lblTerms, lblMonthlyAmortization, lblRebate, lblProcessingFee, lblInterest, lblOtherFee, lblServiceCharge, lblInsurance, lblDeductBalance, lblAdvanceAmortization, lblNetProceeds, lblAccountNumber_1, lblPrincipal_1, lblUDI_1, lblRPPD_1, lblFaceAmount_1, lblRate_1, lblTerms_1, lblMonthlyAmortization_1, lblRebate_1, lblProcessingFee_1, lblInterest_1, lblOtherFee_1, lblServiceCharge_1, lblInsurance_1, lblDeductBalance_1, lblAdvanceAmortization_1, lblNetProceeds_1, lblAccountNumber_2, lblPrincipal_2, lblUDI_2, lblRPPD_2, lblFaceAmount_2, lblRate_2, lblTerms_2, lblMonthlyAmortization_2, lblRebate_2, lblProcessingFee_2, lblInterest_2, lblOtherFee_2, lblServiceCharge_2, lblInsurance_2, lblDeductBalance_2, lblAdvanceAmortization_2, lblNetProceeds_2, lblAccountNumber_3, lblPrincipal_3, lblUDI_3, lblRPPD_3, lblFaceAmount_3, lblRate_3, lblTerms_3, lblMonthlyAmortization_3, lblRebate_3, lblProcessingFee_3, lblInterest_3, lblOtherFee_3, lblServiceCharge_3, lblInsurance_3, lblDeductBalance_3, lblAdvanceAmortization_3, lblNetProceeds_3, lblCheckNumber, lblCollateral, lblProductType, lblLoanType, lblCI, lblAO, XrLabel42, XrLabel35, lblPreparedBy, lblVerifiedBy, lblPosition, lblPositionVerified})
        ReportPageInfoFontSettings({XrPageInfo1, XrPageInfo2})
    End Sub

    Private Sub Bold_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblBorrower.BeforePrint, lblPrincipal.BeforePrint, lblUDI.BeforePrint, lblRPPD.BeforePrint, lblFaceAmount.BeforePrint, lblMonthlyAmortization.BeforePrint, lblRebate.BeforePrint, lblProcessingFee.BeforePrint, lblInterest.BeforePrint, lblOtherFee.BeforePrint, lblServiceCharge.BeforePrint, lblInsurance.BeforePrint, lblDeductBalance.BeforePrint, lblAdvanceAmortization.BeforePrint, lblNetProceeds.BeforePrint
        If lblDate.Text = "" Then
            lblBorrower.Font = New Font(lblBorrower.Font.FontFamily, lblBorrower.Font.Size, FontStyle.Bold)
            lblPrincipal.Font = New Font(lblPrincipal.Font.FontFamily, lblPrincipal.Font.Size, FontStyle.Bold)
            lblUDI.Font = New Font(lblUDI.Font.FontFamily, lblUDI.Font.Size, FontStyle.Bold)
            lblRPPD.Font = New Font(lblRPPD.Font.FontFamily, lblRPPD.Font.Size, FontStyle.Bold)
            lblFaceAmount.Font = New Font(lblFaceAmount.Font.FontFamily, lblFaceAmount.Font.Size, FontStyle.Bold)
            lblMonthlyAmortization.Font = New Font(lblMonthlyAmortization.Font.FontFamily, lblMonthlyAmortization.Font.Size, FontStyle.Bold)
            lblRebate.Font = New Font(lblRebate.Font.FontFamily, lblRebate.Font.Size, FontStyle.Bold)
            lblProcessingFee.Font = New Font(lblProcessingFee.Font.FontFamily, lblProcessingFee.Font.Size, FontStyle.Bold)
            lblInterest.Font = New Font(lblInterest.Font.FontFamily, lblInterest.Font.Size, FontStyle.Bold)
            lblOtherFee.Font = New Font(lblOtherFee.Font.FontFamily, lblOtherFee.Font.Size, FontStyle.Bold)
            lblServiceCharge.Font = New Font(lblServiceCharge.Font.FontFamily, lblServiceCharge.Font.Size, FontStyle.Bold)
            lblInsurance.Font = New Font(lblInsurance.Font.FontFamily, lblInsurance.Font.Size, FontStyle.Bold)
            lblDeductBalance.Font = New Font(lblDeductBalance.Font.FontFamily, lblDeductBalance.Font.Size, FontStyle.Bold)
            lblAdvanceAmortization.Font = New Font(lblAdvanceAmortization.Font.FontFamily, lblAdvanceAmortization.Font.Size, FontStyle.Bold)
            lblNetProceeds.Font = New Font(lblNetProceeds.Font.FontFamily, lblNetProceeds.Font.Size, FontStyle.Bold)
        Else
            lblBorrower.Font = New Font(lblBorrower.Font.FontFamily, lblBorrower.Font.Size, FontStyle.Regular)
            lblPrincipal.Font = New Font(lblPrincipal.Font.FontFamily, lblPrincipal.Font.Size, FontStyle.Regular)
            lblUDI.Font = New Font(lblUDI.Font.FontFamily, lblUDI.Font.Size, FontStyle.Regular)
            lblRPPD.Font = New Font(lblRPPD.Font.FontFamily, lblRPPD.Font.Size, FontStyle.Regular)
            lblFaceAmount.Font = New Font(lblFaceAmount.Font.FontFamily, lblFaceAmount.Font.Size, FontStyle.Regular)
            lblMonthlyAmortization.Font = New Font(lblMonthlyAmortization.Font.FontFamily, lblMonthlyAmortization.Font.Size, FontStyle.Regular)
            lblRebate.Font = New Font(lblRebate.Font.FontFamily, lblRebate.Font.Size, FontStyle.Regular)
            lblProcessingFee.Font = New Font(lblProcessingFee.Font.FontFamily, lblProcessingFee.Font.Size, FontStyle.Regular)
            lblInterest.Font = New Font(lblInterest.Font.FontFamily, lblInterest.Font.Size, FontStyle.Regular)
            lblOtherFee.Font = New Font(lblOtherFee.Font.FontFamily, lblOtherFee.Font.Size, FontStyle.Regular)
            lblServiceCharge.Font = New Font(lblServiceCharge.Font.FontFamily, lblServiceCharge.Font.Size, FontStyle.Regular)
            lblInsurance.Font = New Font(lblInsurance.Font.FontFamily, lblInsurance.Font.Size, FontStyle.Regular)
            lblDeductBalance.Font = New Font(lblDeductBalance.Font.FontFamily, lblDeductBalance.Font.Size, FontStyle.Regular)
            lblAdvanceAmortization.Font = New Font(lblAdvanceAmortization.Font.FontFamily, lblAdvanceAmortization.Font.Size, FontStyle.Regular)
            lblNetProceeds.Font = New Font(lblNetProceeds.Font.FontFamily, lblNetProceeds.Font.Size, FontStyle.Regular)
        End If
    End Sub

    Private Sub LabelX_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles lblPrincipal.BeforePrint, lblUDI.BeforePrint, lblRPPD.BeforePrint, lblFaceAmount.BeforePrint, lblMonthlyAmortization.BeforePrint, lblRebate.BeforePrint, lblProcessingFee.BeforePrint, lblInterest.BeforePrint, lblOtherFee.BeforePrint, lblServiceCharge.BeforePrint, lblInsurance.BeforePrint, lblDeductBalance.BeforePrint, lblAdvanceAmortization.BeforePrint, lblNetProceeds.BeforePrint
        Dim LabelX As DevExpress.XtraReports.UI.XRLabel = sender
        With LabelX
            .Text = If(.Text = "" Or .Text = "0", "", FormatNumber(CDbl(.Text), 2))
        End With
    End Sub
End Class