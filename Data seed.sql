INSERT INTO Rol(Name) VALUES ('Administrador'), ('Paciente');


INSERT INTO Doctor(Nombre, Apellidos, Especialidad, Telefono) VALUES
('María', 'González', 'Medicina General', '2222-2222'),
('Luis', 'Ramírez', 'Pediatría', '2222-3333');


INSERT INTO DoctorHorario(DoctorId, DiaSemana, HoraInicio, HoraFin) VALUES
(1, 2, '08:00', '12:00'),
(1, 4, '13:00', '17:00'),
(2, 3, '09:00', '15:00');