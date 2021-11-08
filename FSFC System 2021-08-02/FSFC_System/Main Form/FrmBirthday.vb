Public Class FrmBirthday
    'Public WithEvents recognizer As New System.Speech.Recognition.SpeechRecognitionEngine
    'Dim gram As New System.Speech.Recognition.DictationGrammar()
    'Public synth As New System.Speech.Synthesis.SpeechSynthesizer
    'Dim cmd As String
    Private Sub FrmBirthday_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
        End If

        'recognizer.LoadGrammar(gram)
        'recognizer.SetInputToDefaultAudioDevice()
        'recognizer.RecognizeAsync()
    End Sub

    Private Sub PictureEdit1_Click(sender As Object, e As EventArgs) Handles PictureEdit1.Click
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'Dim SAPI
        'SAPI = CreateObject("SAPI.spvoice")
        'SAPI.Speak(String.Format("Happy Birthday {0}!", Empl_Name))
    End Sub

    'Private Sub GotSpeech(sender As Object, phrase As System.Speech.Recognition.SpeechRecognizedEventArgs) Handles recognizer.SpeechRecognized
    '    cmd = phrase.Result.Text
    '    If cmd.IndexOf("Run") <> 0 Or cmd.IndexOf("run") <> 0 Then
    '        If cmd.Split(" ")(1) = "Notepad" Or cmd.Split(" ")(1) = "notepad" Then
    '            synth.Speak("Running Notepad.")
    '            Shell("notepad.exe", AppWinStyle.NormalFocus, False)
    '        End If
    '    End If
    'End Sub

    Private Sub FrmBirthday_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub
End Class