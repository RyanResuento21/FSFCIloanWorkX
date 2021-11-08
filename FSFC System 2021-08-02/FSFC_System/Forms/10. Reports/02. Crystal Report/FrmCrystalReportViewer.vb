Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmCrystalReportViewer

    Public Path As String
    Public WithP As Boolean = False 'With Parameter
    Public BranchID As Integer
    Public Branch As String
    Private Sub FrmCrystalReportViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        Try
            Dim cryRpt As New ReportDocument
            Dim crtableLogoninfos As New TableLogOnInfos
            Dim crtableLogoninfo As New TableLogOnInfo
            Dim crConnectionInfo As New ConnectionInfo
            Dim CrTables As Tables
            Dim CrTable As Table

            cryRpt.Load(Path)
            If WithP Then
                Dim crParameterDiscreteValue As New ParameterDiscreteValue
                Dim crParameterFieldDefinitions As ParameterFieldDefinitions
                Dim crParameterFieldLocation As ParameterFieldDefinition
                Dim crParameterValues As New ParameterValues

                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields

                crParameterFieldLocation = crParameterFieldDefinitions.Item("Branch ID")
                crParameterValues = crParameterFieldLocation.CurrentValues
                crParameterDiscreteValue.Value = BranchID
                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

                crParameterFieldLocation = crParameterFieldDefinitions.Item("Branch Header")
                crParameterValues = crParameterFieldLocation.CurrentValues
                crParameterDiscreteValue.Value = Branch
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

                CrystalReportViewer1.ReportSource = cryRpt
                CrystalReportViewer1.Refresh()
            End If

            With crConnectionInfo
                .ServerName = "iLoanWorkx"
                .DatabaseName = _DatabaseName
                .UserID = "reportuser"
                .Password = "reportuser"
            End With

            CrTables = cryRpt.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next

            CrystalReportViewer1.ReportSource = cryRpt
            CrystalReportViewer1.Refresh()
        Catch ex As Exception
            TriggerBugReport("Crystal Report Viewer - Loan", ex.Message.ToString)
        End Try
    End Sub
End Class