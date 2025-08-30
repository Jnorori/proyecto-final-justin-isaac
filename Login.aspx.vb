Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim usuarioDal As New UsuarioDAL()
        Dim username As String = txtUsuario.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        Dim usuarioId As Integer = usuarioDal.ValidarUsuario(username, password)

        If usuarioId > 0 Then
            Session("Usuario") = username
            Session("UsuarioId") = usuarioId

            Dim roles As List(Of String) = usuarioDal.ObtenerRoles(usuarioId)

            If roles.Contains("Administrador") Then
                Response.Redirect("~/Admin.aspx")
            ElseIf roles.Contains("Paciente") Then
                Response.Redirect("~/Paciente.aspx")
            Else
                lblError.Text = "No tiene permisos para acceder al sistema."
            End If
        Else
            lblError.Text = "Usuario o contraseña incorrectos."
        End If
    End Sub

    Public Class UsuarioDAL
        Private db As New DBHelper()

        Public Function ValidarUsuario(username As String, password As String) As Integer
            Dim query As String = "SELECT UserId FROM Usuario WHERE Username=@Username AND Password=@Password AND IsActive=1"
            Dim params As New Dictionary(Of String, Object) From {
                {"@Username", username},
                {"@Password", password}
            }
            Dim dt As DataTable = db.ExecuteQuery(query, params)
            If dt.Rows.Count > 0 Then
                Return Convert.ToInt32(dt.Rows(0)("UserId"))
            Else
                Return 0
            End If
        End Function

        Public Function ObtenerRoles(userId As Integer) As List(Of String)
            Dim roles As New List(Of String)
            Dim query As String = "
                SELECT r.Name
                FROM UsuarioRol ur
                INNER JOIN Rol r ON ur.RoleId = r.RoleId
                WHERE ur.UserId=@UserId"
            Dim params As New Dictionary(Of String, Object) From {
                {"@UserId", userId}
            }
            Dim dt As DataTable = db.ExecuteQuery(query, params)
            For Each row As DataRow In dt.Rows
                roles.Add(row("Name").ToString())
            Next
            Return roles
        End Function
    End Class
End Class
