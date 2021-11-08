Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class ClsDBConnection

#Region "Constructor"

    Sub New()
        myConn = New MySqlConnection
        MeAdapter = New MySqlDataAdapter
    End Sub

#End Region

#Region "Declarations"
    Private _ServerName As String = ""
    Private _DatabaseName As String = ""
    Private _UserID As String = ""
    Private _Password As String = ""

    ReadOnly myConn As MySqlConnection = Nothing
    Private MeAdapter As MySqlDataAdapter

#End Region

#Region "Properties"
    Public Property ServerName() As String
        Get
            Return _ServerName
        End Get
        Set(value As String)
            _ServerName = value
        End Set
    End Property

    Public Property DatabaseName() As String
        Get
            Return _DatabaseName
        End Get
        Set(value As String)
            _DatabaseName = value
        End Set
    End Property

    Public Property UserID() As String
        Get
            Return _UserID
        End Get
        Set(value As String)
            _UserID = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(value As String)
            _Password = value
        End Set
    End Property

    Public ReadOnly Property Connection() As MySqlConnection
        Get
            Return myConn
        End Get
    End Property

#End Region

#Region "Subs And Methods"
    Private Sub GetConnSettingsFromRegistry()
        If GetSetting("FSFC_System", "Connection", "ServerName") = "" Then
            '_ServerName = HostPicker("H2ym19Tgy9pg2jdJh21lz1!gm2ol")
            _ServerName = "AAWSSVR-DB2"
            _DatabaseName = "fsfc"
            _UserID = "fsfccebuser"
            moddbconnection._UserID = _UserID
            _Password = Decrypt("H2ym19Tgy9pg2jdJh21lz1!gm2ol")
            With clsDBConn
                .ServerName = _ServerName
                .DatabaseName = _DatabaseName
                .UserID = _UserID
                .Password = _Password
            End With
            SaveSetting("FSFC_System", "Connection", "ServerName", _ServerName)
            SaveSetting("FSFC_System", "Connection", "DatabaseName", _DatabaseName)
            SaveSetting("FSFC_System", "Connection", "UserName", _UserID)
            SaveSetting("FSFC_System", "Connection", "Password", _Password)
            cn.Dispose()
            cn = New MySqlConnection(String.Format("Data Source={0};Port=3308;Database={1};Uid={2};Pwd={3};CharSet=utf8mb4;pooling='false';", _ServerName, _DatabaseName, _UserID, _Password & Ext))
            cn_email.Dispose()
            cn_email = New MySqlConnection(String.Format("Data Source={0};Port=3308;Database={1};Uid={2};Pwd={3};CharSet=utf8mb4;pooling='false';", _ServerName, _DatabaseName, _UserID, _Password & Ext))
            cn_alert.Dispose()
            cn_alert = New MySqlConnection(String.Format("Data Source={0};Port=3308;Database={1};Uid={2};Pwd={3};CharSet=utf8mb4;pooling='false';", _ServerName, _DatabaseName, _UserID, _Password & Ext))
            cn_backup.Dispose()
            cn_backup = New MySqlConnection(String.Format("Data Source={0};Port=3308;Database={1};Uid={2};Pwd={3};CharSet=utf8mb4;pooling='false';", _ServerName, _DatabaseName, _UserID, _Password & Ext))
        Else
            _ServerName = GetSetting("FSFC_System", "Connection", "ServerName")
            _DatabaseName = GetSetting("FSFC_System", "Connection", "DatabaseName")
            _UserID = GetSetting("FSFC_System", "Connection", "UserName")
            _Password = GetSetting("FSFC_System", "Connection", "Password")
        End If
    End Sub

    Public Function IsDBConnected(vServername As String, vDatabase As String, vUser As String, vPassword As String) As Boolean
        Dim Constring As String = ""
        'GetConnSettingsFromRegistry()
        If vServername = "" Then
            Return False
        End If
        Constring = String.Format("server={0};Port=3308;database={1};uid={2};pwd={3};CharSet=utf8mb4;pooling='false';", vServername, vDatabase, vUser, vPassword & Ext)

        With myConn
            .Close()
            .Dispose()
            .ConnectionString = Constring
            Try
                .Open()
                .Close()
                .Dispose()
                Return True
            Catch ex As Exception
                TriggerBugReport("DB Connection Class", ex.Message.ToString)
                Return False
            End Try
        End With
    End Function

    Public Function ExecQuery(SQLString As String) As DataTable
        Dim MeData As New DataTable
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        Try
            MeAdapter = New MySqlDataAdapter(SQLString, cn)
            MeAdapter.Fill(MeData)
            Return MeData
        Catch ex As Exception
            If Not String.IsNullOrEmpty(SQLString) Then
                Clipboard.SetText(SQLString)
            End If
            MsgBox("Database Error!", MsgBoxStyle.Exclamation, "Info")
            Return Nothing
        End Try
        MeData = Nothing
    End Function

    Public Function Execute(SQLString As String) As Boolean
        Dim mySQLCom As New MySqlCommand
        Try
            mySQLCom.Connection = myConn
            mySQLCom.CommandText = SQLString
            myConn.Open()
            mySQLCom.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        Finally
            myConn.Close()
        End Try
    End Function
#End Region
End Class
