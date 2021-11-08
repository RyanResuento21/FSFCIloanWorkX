Public Class SplashScreen

    Public Delegate Sub SetProgressBarDelegate(max As Integer)
    Public Delegate Sub UpdateProgressBarDelegate(value As Integer)

    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        'BarLong(100)
        'Dim i As Integer = 0
        'While i <= 100
        '    ShowBar(i)
        '    i += 1
        '    Threading.Thread.Sleep(100)
        'End While
        Try
            lblNote.Visible = True
            Dim R As New Random()
            R.Next(0, Note.Rows.Count)
            'lblNote.Text = Note(R.Next(0, Note.Rows.Count))("note").ToString

            If BackgroundWorker1.IsBusy = False Then
                BackgroundWorker1.RunWorkerAsync()
            End If
        Catch ex As Exception
            lblNote.Visible = False
            BackgroundWorker1.CancelAsync()
        End Try
    End Sub

    Public Sub BarLong(MemCount As Integer)
        If InvokeRequired Then
            Invoke(New SetProgressBarDelegate(AddressOf BarLong), MemCount)
        Else
            ProgressBar1.Maximum = MemCount
        End If
    End Sub

    Public Sub ShowBar(SoFar As Integer)
        If InvokeRequired Then
            Invoke(New UpdateProgressBarDelegate(AddressOf ShowBar), SoFar)
        Else
            ProgressBar1.Value = SoFar
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'Dim SAPI
        'SAPI = CreateObject("SAPI.spvoice")
        'SAPI.Speak(lblNote.Text)
    End Sub
End Class