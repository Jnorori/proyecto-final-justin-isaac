Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class UsuarioDAL
    Private connectionString As String = ConfigurationManager.ConnectionStrings("ClinicaDB").ConnectionString


    Public Function ValidarUsuario(username As String, password As String) As Boolean
        Using con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("SELECT COUNT(*) FROM Usuario WHERE Username=@Username AND Password=@Password AND IsActive=1", con)
            cmd.Parameters.AddWithValue("@Username", username)
            cmd.Parameters.AddWithValue("@Password", password)

            con.Open()
            Dim result As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Return result > 0
        End Using
    End Function

    Public Function ObtenerRoles(username As String) As List(Of String)
        Dim roles As New List(Of String)
        Using con As New SqlConnection(connectionString)
            Dim cmd As New SqlCommand("
                SELECT r.Name 
                FROM Usuario u
                INNER JOIN UsuarioRol ur ON u.UserId = ur.UserId
                INNER JOIN Rol r ON ur.RoleId = r.RoleId
                WHERE u.Username=@Username", con)
            cmd.Parameters.AddWithValue("@Username", username)

            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                roles.Add(reader("Name").ToString())
            End While
        End Using
        Return roles
    End Function
End Class

