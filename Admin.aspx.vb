Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Partial Class Admin
    Inherits System.Web.UI.Page

    ' ==== DBHelper privado para esta página ====
    Private Class DBHelper
        Private ReadOnly connectionString As String

        Public Sub New()
            connectionString = ConfigurationManager.ConnectionStrings("ClinicaDBConnectionString").ConnectionString
        End Sub

        Public Function ExecuteNonQuery(query As String, params As Dictionary(Of String, Object)) As Integer
            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(query, conn)
                    For Each p In params
                        cmd.Parameters.AddWithValue(p.Key, p.Value)
                    Next
                    conn.Open()
                    Return cmd.ExecuteNonQuery()
                End Using
            End Using
        End Function

        Public Function ExecuteQuery(query As String, params As Dictionary(Of String, Object)) As DataTable
            Dim dt As New DataTable()
            Using conn As New SqlConnection(connectionString)
                Using cmd As New SqlCommand(query, conn)
                    For Each p In params
                        cmd.Parameters.AddWithValue(p.Key, p.Value)
                    Next
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
            Return dt
        End Function
    End Class

    Private db As New DBHelper()

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarPacientes()
            CargarDoctores()
            CargarHorarios()
            CargarCitas()
            PoblarDropDowns()
        End If
    End Sub

    Private Sub PoblarDropDowns()
        Dim dtPacientes = db.ExecuteQuery("SELECT PacienteId, Nombre + ' ' + Apellidos AS NombreCompleto FROM Paciente", New Dictionary(Of String, Object))
        ddlPacienteCitaNuevo.DataSource = dtPacientes
        ddlPacienteCitaNuevo.DataTextField = "NombreCompleto"
        ddlPacienteCitaNuevo.DataValueField = "PacienteId"
        ddlPacienteCitaNuevo.DataBind()


        Dim dtDoctores = db.ExecuteQuery("SELECT DoctorId, Nombre FROM Doctor", New Dictionary(Of String, Object))
        ddlDoctorHorarioNuevo.DataSource = dtDoctores
        ddlDoctorHorarioNuevo.DataTextField = "Nombre"
        ddlDoctorHorarioNuevo.DataValueField = "DoctorId"
        ddlDoctorHorarioNuevo.DataBind()

        ddlDoctorCitaNuevo.DataSource = dtDoctores
        ddlDoctorCitaNuevo.DataTextField = "Nombre"
        ddlDoctorCitaNuevo.DataValueField = "DoctorId"
        ddlDoctorCitaNuevo.DataBind()
    End Sub

    ' ========================= PACIENTES =========================
    Protected Sub btnAgregarPaciente_Click(sender As Object, e As EventArgs)
        Dim query As String = "INSERT INTO Paciente (Cedula, Nombre, Apellidos, Telefono, FechaNacimiento) VALUES (@Cedula, @Nombre, @Apellidos, @Telefono, @FechaNacimiento)"
        Dim parametros As New Dictionary(Of String, Object) From {
            {"@Cedula", txtCedulaPaciente.Text},
            {"@Nombre", txtNombrePaciente.Text},
            {"@Apellidos", txtApellidosPaciente.Text},
            {"@Telefono", txtTelefonoPaciente.Text},
            {"@FechaNacimiento", DateTime.Parse(txtFechaNacimientoPaciente.Text)}
        }
        db.ExecuteNonQuery(query, parametros)
        CargarPacientes()
    End Sub

    Private Sub CargarPacientes()
        gvPacientes.DataSource = db.ExecuteQuery("SELECT * FROM Paciente", New Dictionary(Of String, Object))
        gvPacientes.DataBind()
    End Sub

    Protected Sub gvPacientes_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvPacientes.EditIndex = e.NewEditIndex
        CargarPacientes()
    End Sub

    Protected Sub gvPacientes_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvPacientes.EditIndex = -1
        CargarPacientes()
    End Sub

    Protected Sub gvPacientes_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim id As Integer = Convert.ToInt32(gvPacientes.DataKeys(e.RowIndex).Value)
        Dim row As GridViewRow = gvPacientes.Rows(e.RowIndex)

        Dim cedula As String = DirectCast(row.Cells(1).Controls(0), TextBox).Text
        Dim nombre As String = DirectCast(row.Cells(2).Controls(0), TextBox).Text
        Dim apellidos As String = DirectCast(row.Cells(3).Controls(0), TextBox).Text
        Dim telefono As String = DirectCast(row.Cells(4).Controls(0), TextBox).Text
        Dim fechaNacimiento As Date = Date.Parse(DirectCast(row.Cells(5).Controls(0), TextBox).Text)

        db.ExecuteNonQuery("UPDATE Paciente SET Cedula=@Cedula, Nombre=@Nombre, Apellidos=@Apellidos, Telefono=@Telefono, FechaNacimiento=@FechaNacimiento WHERE PacienteId=@Id",
            New Dictionary(Of String, Object) From {
                {"@Cedula", cedula},
                {"@Nombre", nombre},
                {"@Apellidos", apellidos},
                {"@Telefono", telefono},
                {"@FechaNacimiento", fechaNacimiento},
                {"@Id", id}
            })

        gvPacientes.EditIndex = -1
        CargarPacientes()
    End Sub

    Protected Sub gvPacientes_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim id As Integer = Convert.ToInt32(gvPacientes.DataKeys(e.RowIndex).Value)
        db.ExecuteNonQuery("DELETE FROM Paciente WHERE PacienteId=@Id", New Dictionary(Of String, Object) From {{"@Id", id}})
        CargarPacientes()
    End Sub

    ' ========================= DOCTORES =========================
    Protected Sub btnAgregarDoctor_Click(sender As Object, e As EventArgs)
        Dim query As String = "INSERT INTO Doctor (Nombre, Especialidad, Telefono) VALUES (@Nombre, @Especialidad, @Telefono)"
        Dim parametros As New Dictionary(Of String, Object) From {
            {"@Nombre", txtNombreDoctor.Text},
            {"@Especialidad", txtEspecialidadDoctor.Text},
            {"@Telefono", txtTelefonoDoctor.Text}
        }
        db.ExecuteNonQuery(query, parametros)
        CargarDoctores()
    End Sub

    Private Sub CargarDoctores()
        gvDoctores.DataSource = db.ExecuteQuery("SELECT * FROM Doctor", New Dictionary(Of String, Object))
        gvDoctores.DataBind()
    End Sub

    Protected Sub gvDoctores_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvDoctores.EditIndex = e.NewEditIndex
        CargarDoctores()
    End Sub

    Protected Sub gvDoctores_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvDoctores.EditIndex = -1
        CargarDoctores()
    End Sub

    Protected Sub gvDoctores_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim id As Integer = Convert.ToInt32(gvDoctores.DataKeys(e.RowIndex).Value)
        Dim row As GridViewRow = gvDoctores.Rows(e.RowIndex)

        Dim nombre As String = DirectCast(row.Cells(1).Controls(0), TextBox).Text
        Dim especialidad As String = DirectCast(row.Cells(2).Controls(0), TextBox).Text
        Dim telefono As String = DirectCast(row.Cells(3).Controls(0), TextBox).Text

        db.ExecuteNonQuery("UPDATE Doctor SET Nombre=@Nombre, Especialidad=@Especialidad, Telefono=@Telefono WHERE DoctorId=@Id",
            New Dictionary(Of String, Object) From {
                {"@Nombre", nombre},
                {"@Especialidad", especialidad},
                {"@Telefono", telefono},
                {"@Id", id}
            })

        gvDoctores.EditIndex = -1
        CargarDoctores()
    End Sub

    Protected Sub gvDoctores_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim id As Integer = Convert.ToInt32(gvDoctores.DataKeys(e.RowIndex).Value)
        db.ExecuteNonQuery("DELETE FROM Doctor WHERE DoctorId=@Id", New Dictionary(Of String, Object) From {{"@Id", id}})
        CargarDoctores()
    End Sub

    ' ========================= HORARIOS =========================
    Protected Sub btnAgregarHorario_Click(sender As Object, e As EventArgs)
        Dim query As String = "INSERT INTO DoctorHorario (DoctorId, DiaSemana, HoraInicio, HoraFin) VALUES (@DoctorId, @DiaSemana, @HoraInicio, @HoraFin)"
        Dim parametros As New Dictionary(Of String, Object) From {
            {"@DoctorId", ddlDoctorHorarioNuevo.SelectedValue},
            {"@DiaSemana", txtDiaSemanaHorario.Text},
            {"@HoraInicio", TimeSpan.Parse(txtHoraInicioHorario.Text)},
            {"@HoraFin", TimeSpan.Parse(txtHoraFinHorario.Text)}
        }
        db.ExecuteNonQuery(query, parametros)
        CargarHorarios()
    End Sub

    Private Sub CargarHorarios()
        gvHorarios.DataSource = db.ExecuteQuery("SELECT h.HorarioId, d.Nombre AS Doctor, h.DiaSemana, h.HoraInicio, h.HoraFin FROM DoctorHorario h INNER JOIN Doctores d ON h.DoctorId = d.DoctorId", New Dictionary(Of String, Object))
        gvHorarios.DataBind()
    End Sub

    Protected Sub gvHorarios_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvHorarios.EditIndex = e.NewEditIndex
        CargarHorarios()
    End Sub

    Protected Sub gvHorarios_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvHorarios.EditIndex = -1
        CargarHorarios()
    End Sub

    Protected Sub gvHorarios_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim id As Integer = Convert.ToInt32(gvHorarios.DataKeys(e.RowIndex).Value)
        Dim row As GridViewRow = gvHorarios.Rows(e.RowIndex)

        Dim diaSemana As String = DirectCast(row.Cells(2).Controls(0), TextBox).Text
        Dim horaInicio As TimeSpan = TimeSpan.Parse(DirectCast(row.Cells(3).Controls(0), TextBox).Text)
        Dim horaFin As TimeSpan = TimeSpan.Parse(DirectCast(row.Cells(4).Controls(0), TextBox).Text)

        db.ExecuteNonQuery("UPDATE DoctorHorario SET DiaSemana=@DiaSemana, HoraInicio=@HoraInicio, HoraFin=@HoraFin WHERE HorarioId=@Id",
            New Dictionary(Of String, Object) From {
                {"@DiaSemana", diaSemana},
                {"@HoraInicio", horaInicio},
                {"@HoraFin", horaFin},
                {"@Id", id}
            })

        gvHorarios.EditIndex = -1
        CargarHorarios()
    End Sub

    Protected Sub gvHorarios_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim id As Integer = Convert.ToInt32(gvHorarios.DataKeys(e.RowIndex).Value)
        db.ExecuteNonQuery("DELETE FROM DoctorHorario WHERE HorarioId=@Id", New Dictionary(Of String, Object) From {{"@Id", id}})
        CargarHorarios()
    End Sub

    ' ========================= CITAS =========================
    Protected Sub btnAgregarCita_Click(sender As Object, e As EventArgs)
        Dim query As String = "INSERT INTO Cita (PacienteId, DoctorId, FechaHora, Estado, Observaciones) VALUES (@PacienteId, @DoctorId, @FechaHora, @Estado, @Observaciones)"
        Dim parametros As New Dictionary(Of String, Object) From {
            {"@PacienteId", ddlPacienteCitaNuevo.SelectedValue},
            {"@DoctorId", ddlDoctorCitaNuevo.SelectedValue},
            {"@FechaHora", DateTime.Parse(txtFechaHoraCita.Text)},
            {"@Estado", txtEstadoCita.Text},
            {"@Observaciones", txtObservacionesCita.Text}
        }
        db.ExecuteNonQuery(query, parametros)
        CargarCitas()
    End Sub

    Private Sub CargarCitas()
        gvCitas.DataSource = db.ExecuteQuery("SELECT c.CitaId, p.Nombre + ' ' + p.Apellidos AS Paciente, d.Nombre AS Doctor, c.FechaHora, c.Estado, c.Observaciones FROM Cita c INNER JOIN Pacientes p ON c.PacienteId = p.PacienteId INNER JOIN Doctores d ON c.DoctorId = d.DoctorId", New Dictionary(Of String, Object))
        gvCitas.DataBind()
    End Sub

    Protected Sub gvCitas_RowEditing(sender As Object, e As GridViewEditEventArgs)
        gvCitas.EditIndex = e.NewEditIndex
        CargarCitas()
    End Sub

    Protected Sub gvCitas_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)
        gvCitas.EditIndex = -1
        CargarCitas()
    End Sub

    Protected Sub gvCitas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        Dim id As Integer = Convert.ToInt32(gvCitas.DataKeys(e.RowIndex).Value)
        Dim row As GridViewRow = gvCitas.Rows(e.RowIndex)

        Dim fechaHora As Date = Date.Parse(DirectCast(row.Cells(3).Controls(0), TextBox).Text)
        Dim estado As String = DirectCast(row.Cells(4).Controls(0), TextBox).Text
        Dim observaciones As String = DirectCast(row.Cells(5).Controls(0), TextBox).Text

        db.ExecuteNonQuery("UPDATE Cita SET FechaHora=@FechaHora, Estado=@Estado, Observaciones=@Observaciones WHERE CitaId=@Id",
            New Dictionary(Of String, Object) From {
                {"@FechaHora", fechaHora},
                {"@Estado", estado},
                {"@Observaciones", observaciones},
                {"@Id", id}
            })

        gvCitas.EditIndex = -1
        CargarCitas()
    End Sub

    Protected Sub gvCitas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)
        Dim id As Integer = Convert.ToInt32(gvCitas.DataKeys(e.RowIndex).Value)
        db.ExecuteNonQuery("DELETE FROM Cita WHERE CitaId=@Id", New Dictionary(Of String, Object) From {{"@Id", id}})
        CargarCitas()
    End Sub

End Class
