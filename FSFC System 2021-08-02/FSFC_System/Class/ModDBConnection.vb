Imports MySql.Data.MySqlClient
Module Moddbconnection
    Public clsDBConn As New ClsDBConnection

    Public _ServerName As String = GetSetting("FSFC_System", "Connection", "ServerName")
    Public _DatabaseName As String = GetSetting("FSFC_System", "Connection", "DatabaseName")
    Public _UserID As String = GetSetting("FSFC_System", "Connection", "UserName")
    Public _Password As String = GetSetting("FSFC_System", "Connection", "Password")
    ReadOnly ConnectionString As String = String.Format("Data Source={0};Port=3308;Database={1};Uid={2};Pwd={3};CharSet=utf8mb4;pooling='false';", _ServerName, _DatabaseName, _UserID, _Password & Ext)
    Public cn As New MySqlConnection(ConnectionString)
    Public cn_email As New MySqlConnection(ConnectionString)
    Public cn_alert As New MySqlConnection(ConnectionString)
    Public cn_backup As New MySqlConnection(ConnectionString)
End Module
