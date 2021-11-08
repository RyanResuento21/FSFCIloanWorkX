Imports MySql.Data.MySqlClient

Public Class FrmDBConnection
    Public change_db As Boolean

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If txtDatabaseName.Tag = txtDatabaseName.Text And txtServerName.Tag = txtServerName.Text And txtUserName.Tag = txtUserName.Text And txtPassword.Tag = txtPassword.Text Then
            If MsgBoxYes("Nothing is changed from the previous connection, would you like to proceed?") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        Call Connect()
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX1, LabelX2, LabelX3, LabelX4})

            GetTextBoxFontSettings({txtServerName, txtDatabaseName, txtUserName, txtPassword})

            GetButtonFontSettings({btnTestDB, btnOnPremiseDB, btnAmazonDB, btnOK})
        Catch ex As Exception
            TriggerBugReport("DB Connection - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub Connect()
        Cursor = Cursors.WaitCursor

        If clsDBConn.IsDBConnected(txtServerName.Text, txtDatabaseName.Text, txtUserName.Text, txtPassword.Text) Then
            With clsDBConn
                .ServerName = txtServerName.Text
                .DatabaseName = txtDatabaseName.Text
                .UserID = txtUserName.Text
                .Password = txtPassword.Text
            End With
            SaveToRegistry()

            MessageBox.Show("Successfully connected to database '" & txtDatabaseName.Text & "'", "Successfully Connected!")
            _ServerName = GetSetting("FSFC_System", "Connection", "ServerName")
            _DatabaseName = GetSetting("FSFC_System", "Connection", "DatabaseName")
            _UserID = GetSetting("FSFC_System", "Connection", "UserName")
            _Password = GetSetting("FSFC_System", "Connection", "Password")
            cn = New MySqlConnection(String.Format("Data Source={0};Port=3308;Database={1};Uid={2};Pwd={3};CharSet=utf8mb4;pooling='false';", _ServerName, _DatabaseName, _UserID, _Password & Ext))
            cn_email = New MySqlConnection(String.Format("Data Source={0};Port=3308;Database={1};Uid={2};Pwd={3};CharSet=utf8mb4;pooling='false';", _ServerName, _DatabaseName, _UserID, _Password & Ext))
            cn_alert = New MySqlConnection(String.Format("Data Source={0};Port=3308;Database={1};Uid={2};Pwd={3};CharSet=utf8mb4;pooling='false';", _ServerName, _DatabaseName, _UserID, _Password & Ext))
            cn_backup = New MySqlConnection(String.Format("Data Source={0};Port=3308;Database={1};Uid={2};Pwd={3};CharSet=utf8mb4;pooling='false';", _ServerName, _DatabaseName, _UserID, _Password & Ext))

            With FrmLogin
                .Show()
                .WindowState = FormWindowState.Normal
                FrmMain.Close()
                .TriggerUserChange = True
                .txtPassword.Text = ""
            End With
            Dispose()
        Else
            Cursor = Cursors.Default
            Exit Sub
        End If

Here:
        For Each F As Form In My.Application.OpenForms
            If F.Name = "FrmMain" Or F.Name = "FrmLogin" Then
            Else
                F.Dispose()
                GoTo Here
            End If
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub SaveToRegistry()
        SaveSetting("FSFC_System", "Connection", "ServerName", txtServerName.Text)
        SaveSetting("FSFC_System", "Connection", "DatabaseName", txtDatabaseName.Text)
        SaveSetting("FSFC_System", "Connection", "UserName", txtUserName.Text)
        SaveSetting("FSFC_System", "Connection", "Password", txtPassword.Text)
    End Sub

    Private Sub GetRegistryEntries()
        txtServerName.Text = GetSetting("FSFC_System", "Connection", "ServerName")
        txtDatabaseName.Text = GetSetting("FSFC_System", "Connection", "DatabaseName")
        txtUserName.Text = GetSetting("FSFC_System", "Connection", "UserName")
        txtPassword.Text = GetSetting("FSFC_System", "Connection", "Password")

        If txtServerName.Text <> "" Then
            txtServerName.Tag = txtServerName.Text
            txtDatabaseName.Tag = txtDatabaseName.Text
            txtUserName.Tag = txtUserName.Text
            txtPassword.Tag = txtPassword.Text
        End If
    End Sub

    Private Sub FtDatabaseConnectionForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        GetRegistryEntries()
        If txtServerName.Text = "" Then
            txtServerName.Text = "AAWSSVR-DB2"
            txtDatabaseName.Text = "FSFC"
            btnOnPremiseDB.Visible = False
            btnTestDB.Visible = False
            btnAmazonDB.Visible = False
        End If
    End Sub

    Private Sub TxtServerName_TextChanged(sender As Object, e As EventArgs) Handles txtServerName.TextChanged
        change_db = True
    End Sub

    Private Sub TxtDatabaseName_TextChanged(sender As Object, e As EventArgs) Handles txtDatabaseName.TextChanged
        change_db = True
    End Sub

    Private Sub TxtUserName_TextChanged(sender As Object, e As EventArgs) Handles txtUserName.TextChanged
        change_db = True
    End Sub

    Private Sub TxtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        change_db = True
    End Sub

    '******************************************** E N T E R *******************************************************
    Private Sub TxtServerName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtServerName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDatabaseName.Focus()
        End If
    End Sub

    Private Sub TxtDatabaseName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDatabaseName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtUserName.Focus()
        End If
    End Sub

    Private Sub TxtUserName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUserName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub TxtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOK.Focus()
            btnOK.PerformClick()
        End If
    End Sub

    Private Sub FrmDBConnection_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
            If e.KeyCode = Keys.Escape Then
                Close()
            ElseIf e.KeyCode = Keys.F12 Then
                .btnReport_Click(sender, e)
            End If
        End With
    End Sub

    Private Sub BtnTestDB_Click(sender As Object, e As EventArgs) Handles btnTestDB.Click
        If Computer = "ARGOWSL-044" Then
            txtServerName.Text = "localhost"
            txtDatabaseName.Text = "fsfc_test"
            txtUserName.Text = "root"
            txtPassword.Text = "admin"
        Else
            txtServerName.Text = "AAWSSVR-DB2"
            txtDatabaseName.Text = "fsfc_migration"
        End If
    End Sub

    Private Sub BtnOnPremiseDB_Click(sender As Object, e As EventArgs) Handles btnOnPremiseDB.Click
        txtServerName.Text = "ACEBSVR-LMS"
        txtDatabaseName.Text = "testdb"
        txtUserName.Text = "testuser"
        txtPassword.Text = "T3stuser"
    End Sub

    Private Sub BtnAmazonDB_Click(sender As Object, e As EventArgs) Handles btnAmazonDB.Click
        txtServerName.Text = "AAWSSVR-DB2"
        txtDatabaseName.Text = "fsfc"
        If Computer = "ARGOWSL-044" Then
            'txtUserName.Text = "kgotico"
            'txtPassword.Text = "F$v)2$7a"
            txtUserName.Text = "fsfcasguser"
            txtPassword.Text = "fsfcASGuser"
        End If
    End Sub
End Class