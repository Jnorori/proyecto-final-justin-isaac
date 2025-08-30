Imports System.Data.SqlClient
Imports System.Configuration
Public Class DBHelper
    Private connectionString As String = ConfigurationManager.ConnectionStrings("ClinicaDBConnectionString").ConnectionString
    Public Function GetConnection() As SqlConnection
        Return New SqlConnection(connectionString)
    End Function
    Public Function ExecuteQuery(query As String, params As Dictionary(Of String, Object)) As DataTable
        Dim dt As New DataTable()
        Using conn As SqlConnection = GetConnection()
            Using cmd As New SqlCommand(query, conn)
                If params IsNot Nothing Then
                    For Each p In params
                        cmd.Parameters.AddWithValue(p.Key, p.Value)
                    Next
                End If
                conn.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                End Using
            End Using
        End Using
        Return dt
    End Function
    Public Sub ExecuteNonQuery(query As String, params As Dictionary(Of String, Object))
        Using conn As SqlConnection = GetConnection()
            Using cmd As New SqlCommand(query, conn)
                If params IsNot Nothing Then
                    For Each p In params
                        cmd.Parameters.AddWithValue(p.Key, p.Value)
                    Next
                End If
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    ' USUARIOS

    Public Function ObtenerUsuarios() As DataTable
        Dim query As String = "SELECT * FROM Usuario"
        Return ExecuteQuery(query, Nothing)
    End Function
    Public Sub InsertarUsuario(username As String, email As String, password As String, Optional isActive As Boolean = True)
        Dim query As String = "INSERT INTO Usuario (Username, Email, Password, IsActive) VALUES (@Username,@Email,@Password,@IsActive)"
        Dim params As New Dictionary(Of String, Object) From {
            {"@Username", username},
            {"@Email", email},
            {"@Password", password},
            {"@IsActive", isActive}
        }
        ExecuteNonQuery(query, params)
    End Sub
    Public Sub ActualizarUsuario(userId As Integer, username As String, email As String, password As String, Optional isActive As Boolean = True)
        Dim query As String = "UPDATE Usuario SET Username=@Username, Email=@Email, Password=@Password, IsActive=@IsActive WHERE UserId=@UserId"
        Dim params As New Dictionary(Of String, Object) From {
            {"@Username", username},
            {"@Email", email},
            {"@Password", password},
            {"@IsActive", isActive},
            {"@UserId", userId}
        }
        ExecuteNonQuery(query, params)
    End Sub
    Public Sub EliminarUsuario(userId As Integer)
        Dim query As String = "DELETE FROM Usuario WHERE UserId=@UserId"
        Dim params As New Dictionary(Of String, Object) From {{"@UserId", userId}}
        ExecuteNonQuery(query, params)
    End Sub
    ' PACIENTES
    Public Function ObtenerPacientes() As DataTable
        Dim query As String = "SELECT * FROM Paciente"
        Return ExecuteQuery(query, Nothing)
    End Function
    Public Sub InsertarPaciente(cedula As String, nombre As String, apellidos As String, telefono As String, fechaNacimiento As Date, Optional userId As Integer? = Nothing)
        Dim query As String = "INSERT INTO Paciente (UserId, Cedula, Nombre, Apellidos, Telefono, FechaNacimiento) VALUES (@UserId,@Cedula,@Nombre,@Apellidos,@Telefono,@FechaNacimiento)"
        Dim params As New Dictionary(Of String, Object) From {
            {"@UserId", If(userId, DBNull.Value)},
            {"@Cedula", cedula},
            {"@Nombre", nombre},
            {"@Apellidos", apellidos},
            {"@Telefono", telefono},
            {"@FechaNacimiento", fechaNacimiento}
        }
        ExecuteNonQuery(query, params)
    End Sub
    Public Sub ActualizarPaciente(pacienteId As Integer, cedula As String, nombre As String, apellidos As String, telefono As String, fechaNacimiento As Date)
        Dim query As String = "UPDATE Paciente SET Cedula=@Cedula, Nombre=@Nombre, Apellidos=@Apellidos, Telefono=@Telefono, FechaNacimiento=@FechaNacimiento WHERE PacienteId=@PacienteId"
        Dim params As New Dictionary(Of String, Object) From {
            {"@Cedula", cedula},
            {"@Nombre", nombre},
            {"@Apellidos", apellidos},
            {"@Telefono", telefono},
            {"@FechaNacimiento", fechaNacimiento},
            {"@PacienteId", pacienteId}
        }
        ExecuteNonQuery(query, params)
    End Sub
    Public Sub EliminarPaciente(pacienteId As Integer)
        Dim query As String = "DELETE FROM Paciente WHERE PacienteId=@PacienteId"
        Dim params As New Dictionary(Of String, Object) From {{"@PacienteId", pacienteId}}
        ExecuteNonQuery(query, params)
    End Sub
    ' DOCTORES
    Public Function ObtenerDoctores() As DataTable
        Dim query As String = "SELECT * FROM Doctor"
        Return ExecuteQuery(query, Nothing)
    End Function
    Public Sub InsertarDoctor(nombre As String, apellidos As String, especialidad As String, telefono As String)
        Dim query As String = "INSERT INTO Doctor (Nombre, Apellidos, Especialidad, Telefono) VALUES (@Nombre, @Apellidos, @Especialidad, @Telefono)"
        Dim params As New Dictionary(Of String, Object) From {
            {"@Nombre", nombre},
            {"@Apellidos", apellidos},
            {"@Especialidad", especialidad},
            {"@Telefono", telefono}
        }
        ExecuteNonQuery(query, params)
    End Sub
    Public Sub ActualizarDoctor(doctorId As Integer, nombre As String, apellidos As String, especialidad As String, telefono As String)
        Dim query As String = "UPDATE Doctor SET Nombre=@Nombre, Apellidos=@Apellidos, Especialidad=@Especialidad, Telefono=@Telefono WHERE DoctorId=@DoctorId"
        Dim params As New Dictionary(Of String, Object) From {
            {"@Nombre", nombre},
            {"@Apellidos", apellidos},
            {"@Especialidad", especialidad},
            {"@Telefono", telefono},
            {"@DoctorId", doctorId}
        }
        ExecuteNonQuery(query, params)
    End Sub
    Public Sub EliminarDoctor(doctorId As Integer)
        Dim query As String = "DELETE FROM Doctor WHERE DoctorId=@DoctorId"
        Dim params As New Dictionary(Of String, Object) From {{"@DoctorId", doctorId}}
        ExecuteNonQuery(query, params)
    End Sub
    ' CITAS

    Public Function ObtenerCitas() As DataTable
        Dim query As String = "SELECT C.CitaId, P.Nombre + ' ' + P.Apellidos AS Paciente, D.Nombre + ' ' + D.Apellidos AS Doctor, C.FechaHora, C.Estado, C.Observaciones FROM Cita C INNER JOIN Paciente P ON C.PacienteId = P.PacienteId INNER JOIN Doctor D ON C.DoctorId = D.DoctorId"
        Return ExecuteQuery(query, Nothing)
    End Function
    Public Function ObtenerCitasPorDoctor(doctorId As Integer) As DataTable
        Dim query As String = "SELECT C.CitaId, P.Nombre + ' ' + P.Apellidos AS Paciente, D.Nombre + ' ' + D.Apellidos AS Doctor, C.FechaHora, C.Estado, C.Observaciones FROM Cita C INNER JOIN Paciente P ON C.PacienteId = P.PacienteId INNER JOIN Doctor D ON C.DoctorId = D.DoctorId WHERE C.DoctorId=@DoctorId"
        Dim params As New Dictionary(Of String, Object) From {{"@DoctorId", doctorId}}
        Return ExecuteQuery(query, params)
    End Function
    Public Sub InsertarCita(pacienteId As Integer, doctorId As Integer, fechaHora As DateTime, estado As String, observaciones As String)
        Dim query As String = "INSERT INTO Cita (PacienteId, DoctorId, FechaHora, Estado, Observaciones) VALUES (@PacienteId,@DoctorId,@FechaHora,@Estado,@Observaciones)"
        Dim params As New Dictionary(Of String, Object) From {
            {"@PacienteId", pacienteId},
            {"@DoctorId", doctorId},
            {"@FechaHora", fechaHora},
            {"@Estado", estado},
            {"@Observaciones", observaciones}
        }
        ExecuteNonQuery(query, params)
    End Sub
    Public Sub ActualizarCita(citaId As Integer, pacienteId As Integer, doctorId As Integer, fechaHora As DateTime, estado As String, observaciones As String)
        Dim query As String = "UPDATE Cita SET PacienteId=@PacienteId, DoctorId=@DoctorId, FechaHora=@FechaHora, Estado=@Estado, Observaciones=@Observaciones WHERE CitaId=@CitaId"
        Dim params As New Dictionary(Of String, Object) From {
            {"@PacienteId", pacienteId},
            {"@DoctorId", doctorId},
            {"@FechaHora", fechaHora},
            {"@Estado", estado},
            {"@Observaciones", observaciones},
            {"@CitaId", citaId}
        }
        ExecuteNonQuery(query, params)
    End Sub
    Public Sub EliminarCita(citaId As Integer)
        Dim query As String = "DELETE FROM Cita WHERE CitaId=@CitaId"
        Dim params As New Dictionary(Of String, Object) From {{"@CitaId", citaId}}
        ExecuteNonQuery(query, params)
    End Sub
    ' HORARIOS DE DOCTORES

    Public Function ObtenerHorariosPorDoctor(doctorId As Integer) As DataTable
        Dim query As String = "SELECT * FROM DoctorHorario WHERE DoctorId=@DoctorId"
        Dim params As New Dictionary(Of String, Object) From {{"@DoctorId", doctorId}}
        Return ExecuteQuery(query, params)
    End Function
    Public Sub InsertarHorario(doctorId As Integer, diaSemana As Integer, horaInicio As TimeSpan, horaFin As TimeSpan)
        Dim query As String = "INSERT INTO DoctorHorario (DoctorId, DiaSemana, HoraInicio, HoraFin) VALUES (@DoctorId, @DiaSemana, @HoraInicio, @HoraFin)"
        Dim params As New Dictionary(Of String, Object) From {
            {"@DoctorId", doctorId},
            {"@DiaSemana", diaSemana},
            {"@HoraInicio", horaInicio},
            {"@HoraFin", horaFin}
        }
        ExecuteNonQuery(query, params)
    End Sub
    Public Sub ActualizarHorario(horarioId As Integer, doctorId As Integer, diaSemana As Integer, horaInicio As TimeSpan, horaFin As TimeSpan)
        Dim query As String = "UPDATE DoctorHorario SET DoctorId=@DoctorId, DiaSemana=@DiaSemana, HoraInicio=@HoraInicio, HoraFin=@HoraFin WHERE HorarioId=@HorarioId"
        Dim params As New Dictionary(Of String, Object) From {
            {"@DoctorId", doctorId},
            {"@DiaSemana", diaSemana},
            {"@HoraInicio", horaInicio},
            {"@HoraFin", horaFin},
            {"@HorarioId", horarioId}
        }
        ExecuteNonQuery(query, params)
    End Sub
    Public Sub EliminarHorario(horarioId As Integer)
        Dim query As String = "DELETE FROM DoctorHorario WHERE HorarioId=@HorarioId"
        Dim params As New Dictionary(Of String, Object) From {{"@HorarioId", horarioId}}
        ExecuteNonQuery(query, params)
    End Sub
End Class

