Imports MySql.Data.MySqlClient

Public Class ClsSQLGeneric
    Public Function CustomCommandDataTable(command As String) As DataTable
        If cn.State = ConnectionState.Open Then
            If cn_backup.State = ConnectionState.Open Then
                cn.Close()
            Else
                Return CustomCommandDataTableBackUp(command)
            End If
        End If
        Try
            cn.Open()
        Catch ex As Exception
            cn.Close()
            Return Nothing
            Exit Function
        End Try
        Using cmd As New MySqlCommand(command, cn)
            cmd.CommandTimeout = 600 '10 Minutes
            Dim SA As New MySqlDataAdapter(cmd)
            'SA.SelectCommand.CommandTimeout = 120
            Dim DS As New DataSet("custom_command")

            Try
                SA.Fill(DS, "custom_command")
            Catch ex As Exception
                TriggerBugReport("Class SQL Generic - CustomCommandDataTable", ex.Message.ToString)
            End Try

            Return DS.Tables("custom_command")
            With cn
                .Dispose()
                .Close()
            End With
            SA.Dispose()
            cmd.Dispose()
            DS.Dispose()
        End Using
    End Function

    Public Function CustomCommandDataTableEmail(command As String) As DataTable
        If cn_email.State = ConnectionState.Open Then
            If cn_backup.State = ConnectionState.Open Then
                cn_email.Close()
            Else
                Return CustomCommandDataTableBackUp(command)
            End If
        End If
        Try
            cn_email.Open()
        Catch ex As Exception
            cn_email.Close()
            Return Nothing
            Exit Function
        End Try
        Using cmd As New MySqlCommand(command, cn_email)
            cmd.CommandTimeout = 600 '10 Minutes
            Dim SA As New MySqlDataAdapter(cmd)
            Dim DS As New DataSet("custom_command")

            Try
                SA.Fill(DS, "custom_command")
            Catch ex As Exception
                TriggerBugReport("Class SQL Generic - DataTableEmail", ex.Message.ToString)
            End Try

            Return DS.Tables("custom_command")
            With cn_email
                .Dispose()
                .Close()
            End With
            SA.Dispose()
            cmd.Dispose()
            DS.Dispose()
        End Using
    End Function

    Public Function CustomCommandDataTableAlert(command As String) As DataTable
        If cn_alert.State = ConnectionState.Open Then
            cn_alert.Close()
        End If
        Try
            cn_alert.Open()
        Catch ex As Exception
            cn_alert.Close()
            Return Nothing
            Exit Function
        End Try
        Using cmd As New MySqlCommand(command, cn_alert)
            cmd.CommandTimeout = 600 '10 Minutes
            Dim SA As New MySqlDataAdapter(cmd)
            Dim DS As New DataSet("custom_command")

            Try
                SA.Fill(DS, "custom_command")
            Catch ex As Exception
                TriggerBugReport("Class SQL Generic - DataTableAlert", ex.Message.ToString)
            End Try

            Return DS.Tables("custom_command")
            With cn_alert
                .Dispose()
                .Close()
            End With
            SA.Dispose()
            cmd.Dispose()
            DS.Dispose()
        End Using
    End Function

    Public Function CustomCommandDataTableBackUp(command As String) As DataTable
        Try
            cn_backup.Open()
        Catch ex As Exception
            cn_backup.Close()
            Return Nothing
            Exit Function
        End Try
        Using cmd As New MySqlCommand(command, cn_backup)
            cmd.CommandTimeout = 600 '10 Minutes
            Dim SA As New MySqlDataAdapter(cmd)
            Dim DS As New DataSet("custom_command")

            Try
                SA.Fill(DS, "custom_command")
            Catch ex As Exception
                TriggerBugReport("Class SQL Generic - DataTableBackUp", ex.Message.ToString)
            End Try

            Return DS.Tables("custom_command")
            With cn_backup
                .Dispose()
                .Close()
            End With
            SA.Dispose()
            cmd.Dispose()
            DS.Dispose()
        End Using
    End Function

    Public Function CustomCommandObjectFill(command As String) As Object
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Try
            cn.Open()
        Catch ex As Exception
            cn.Close()
            Return Nothing
            Exit Function
        End Try

        Using cmd As New MySqlCommand(command, cn)
            cmd.CommandTimeout = 600 '10 Minutes
            Dim myReader As MySqlDataReader
            myReader = cmd.ExecuteReader
            Dim DT As New DataTable

            If myReader.HasRows Then
                DT.Load(myReader)
            End If

            Return DT
            With cn
                .Dispose()
                .Close()
            End With
            myReader.Dispose()
            cmd.Dispose()
            DT.Dispose()
        End Using
    End Function

    Public Function CustomCommandObject(command As String, Optional columnIndex As Integer = 0) As Object
        Dim retval As Object = Nothing
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Try
            cn.Open()
        Catch ex As Exception
            cn.Close()
            Return Nothing
            Exit Function
        End Try

        Using cmd As New MySqlCommand(command, cn)
            cmd.CommandTimeout = 600 '10 Minutes
            Dim myReader As MySqlDataReader
            myReader = cmd.ExecuteReader

            If Not myReader.HasRows Then
                retval = Nothing
            Else
                While myReader.Read()
                    Try
                        retval = myReader(columnIndex)
                    Catch ex As Exception
                        retval = Nothing
                        TriggerBugReport("Class SQL Generic - CommandObject", ex.Message.ToString)
                    End Try
                End While
            End If

            Return retval
            With cn
                .Dispose()
                .Close()
            End With
            myReader.Dispose()
            cmd.Dispose()
        End Using
    End Function
End Class

'SQL Module
Module SQLModule
    ReadOnly SQL As New ClsSQLGeneric

    Public Function DataSource(command As String) As DataTable
        Return SQL.customCommandDataTable(command)
    End Function

    Public Function DataSourceEmail(command As String) As DataTable
        Return SQL.CustomCommandDataTableEmail(command)
    End Function

    Public Function DataSourceAlertNotification(command As String) As DataTable
        Return SQL.CustomCommandDataTableAlert(command)
    End Function

    'Public Function DataSourceBackUp(command As String) As DataTable
    '    Return SQL.CustomCommandDataTableAlert(command)
    'End Function

    Public Function DataObject(command As String, Optional column As Integer = 0) As Object
        DataObject = SQL.CustomCommandObject(command, column)
    End Function

    Public Function DataObjectFill(command As String) As Object
        DataObjectFill = SQL.CustomCommandObjectFill(command)
    End Function
End Module

