Imports System.Runtime.CompilerServices
Module ModExtentions

    <Extension()>
    Public Function MsgBoxYes(Say As String)
        'If FrmMain.VoiceOut Then
        '    FrmMain.Speak(Say)
        'End If
        If MsgBox(Say, MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            Return MsgBoxResult.Yes
        Else
            Return MsgBoxResult.No
        End If
    End Function

    <Extension()>
    Public Function InsertQuote(aString As String)
        If aString = "" Then
            Return aString
        End If
        aString = aString.Replace("\", "")
        aString = aString.Replace("'", "\'")
        Return aString
    End Function

    <Extension()>
    Public Sub AddItemArray(Of T)(ByRef arr As T(), item As T)
        Array.Resize(arr, arr.Length + 1)
        arr(arr.Length - 1) = item
    End Sub
End Module
