Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Paciente
    Inherits System.Web.UI.Page

    Private db As New DBHelper()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Usuario") IsNot Nothing AndAlso Session("UsuarioId") IsNot Nothing Then
                lblUsuario.Text = Session("Usuario").ToString()
                CargarCitas()
                CargarDoctores()
            Else
                Response.Redirect("~/Login.aspx")
            End If
        End If
    End Sub

    Private Sub CargarCitas()
        Dim pacienteId As Integer = Convert.ToInt32(Session("UsuarioId"))
        Dim query As String = "
            SELECT c.CitaId, d.Nombre + ' ' + d.Apellidos AS Doctor, c.FechaHora, c.Estado, c.Observaciones
            FROM Cita c
            INNER JOIN Doctor d ON c.DoctorId = d.DoctorId
            WHERE c.PacienteId=@PacienteId
            ORDER BY c.FechaHora DESC"

        Dim parametros As New Dictionary(Of String, Object) From {{"@PacienteId", pacienteId}}
        Dim dt As DataTable = db.ExecuteQuery(query, parametros)
        gvCitas.DataSource = dt
        gvCitas.DataBind()
    End Sub

    Private Sub CargarDoctores()
        Dim query As String = "
            SELECT DoctorId, Nombre + ' ' + Apellidos AS NombreCompleto
            FROM Doctor"

        Dim dt As DataTable = db.ExecuteQuery(query, Nothing)
        ddlDoctores.DataSource = dt
        ddlDoctores.DataTextField = "NombreCompleto"
        ddlDoctores.DataValueField = "DoctorId"
        ddlDoctores.DataBind()
        ddlDoctores.Items.Insert(0, New ListItem("--Seleccione Doctor--", "0"))
    End Sub

    Protected Sub btnAgendarCita_Click(sender As Object, e As EventArgs)
        lblMensaje.Text = ""
        lblMensaje.ForeColor = System.Drawing.Color.Red

        Dim pacienteId As Integer = Convert.ToInt32(Session("UsuarioId"))
        Dim doctorId As Integer = Convert.ToInt32(ddlDoctores.SelectedValue)
        Dim fechaHora As DateTime

        If doctorId = 0 Then
            lblMensaje.Text = "Seleccione un doctor."
            Return
        End If

        If Not DateTime.TryParse(txtFechaHora.Text.Trim(), fechaHora) Then
            lblMensaje.Text = "Ingrese una fecha y hora válidas."
            Return
        End If

        Dim queryVerificar As String = "
            SELECT COUNT(*) 
            FROM Cita 
            WHERE DoctorId=@DoctorId AND FechaHora=@FechaHora"

        Dim parametrosVerificar As New Dictionary(Of String, Object) From {
            {"@DoctorId", doctorId},
            {"@FechaHora", fechaHora}
        }

        Dim dtVerificar As DataTable = db.ExecuteQuery(queryVerificar, parametrosVerificar)

        If Convert.ToInt32(dtVerificar.Rows(0)(0)) > 0 Then
            lblMensaje.Text = "El doctor ya tiene una cita a esa hora, seleccione otro horario."
            Return
        End If

        Dim queryInsertar As String = "
            INSERT INTO Cita (PacienteId, DoctorId, FechaHora, Estado, Observaciones)
            VALUES (@PacienteId, @DoctorId, @FechaHora, 'Programada', @Observaciones)"

        Dim parametrosInsert As New Dictionary(Of String, Object) From {
            {"@PacienteId", pacienteId},
            {"@DoctorId", doctorId},
            {"@FechaHora", fechaHora},
            {"@Observaciones", txtObservaciones.Text.Trim()}
        }

        db.ExecuteNonQuery(queryInsertar, parametrosInsert)

        lblMensaje.ForeColor = System.Drawing.Color.Green
        lblMensaje.Text = "Cita agendada correctamente."

        ddlDoctores.SelectedIndex = 0
        txtFechaHora.Text = ""
        txtObservaciones.Text = ""

        CargarCitas()
    End Sub
End Class
