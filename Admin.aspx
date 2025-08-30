<%@ Page Title="Panel de Administración" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Admin.aspx.vb" Inherits="Proyecto_Progra_III_Justin_Isaac.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="mb-3">Panel de Administración</h2>
        <p>Bienvenido, <asp:Label ID="lblUsuario" runat="server" ForeColor="Green" CssClass="fw-bold"></asp:Label></p>
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" CssClass="mb-3 d-block"></asp:Label>
        <!-- PACIENTES -->
        <div class="card shadow mb-4">
            <div class="card-header bg-primary text-white">
                <h4 class="mb-0">Pacientes</h4>
            </div>
            <div class="card-body">
                <!-- Formulario para agregar paciente -->
                <div class="mb-3">
                    <asp:TextBox ID="txtCedulaPaciente" runat="server" Placeholder="Cédula" CssClass="form-control mb-1" />
                    <asp:TextBox ID="txtNombrePaciente" runat="server" Placeholder="Nombre" CssClass="form-control mb-1" />
                    <asp:TextBox ID="txtApellidosPaciente" runat="server" Placeholder="Apellidos" CssClass="form-control mb-1" />
                    <asp:TextBox ID="txtTelefonoPaciente" runat="server" Placeholder="Teléfono" CssClass="form-control mb-1" />
                    <asp:TextBox ID="txtFechaNacimientoPaciente" runat="server" TextMode="Date" CssClass="form-control mb-1" />
                    <asp:Button ID="btnAgregarPaciente" runat="server" Text="Agregar Paciente" CssClass="btn btn-success" OnClick="btnAgregarPaciente_Click" />
                </div>
                <asp:GridView ID="gvPacientes" runat="server" AutoGenerateColumns="False" DataKeyNames="PacienteId"
                    CssClass="table table-striped table-hover"
                    OnRowEditing="gvPacientes_RowEditing" OnRowCancelingEdit="gvPacientes_RowCancelingEdit"
                    OnRowUpdating="gvPacientes_RowUpdating" OnRowDeleting="gvPacientes_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="PacienteId" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="Cedula" HeaderText="Cédula" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nac." DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <!-- DOCTORES -->
        <div class="card shadow mb-4">
            <div class="card-header bg-success text-white">
                <h4 class="mb-0">Doctores</h4>
            </div>
            <div class="card-body">
                <!-- Formulario para agregar doctor -->
                <div class="mb-3">
                    <asp:TextBox ID="txtNombreDoctor" runat="server" Placeholder="Nombre Completo" CssClass="form-control mb-1" />
                    <asp:TextBox ID="txtEspecialidadDoctor" runat="server" Placeholder="Especialidad" CssClass="form-control mb-1" />
                    <asp:TextBox ID="txtTelefonoDoctor" runat="server" Placeholder="Teléfono" CssClass="form-control mb-1" />
                    <asp:Button ID="btnAgregarDoctor" runat="server" Text="Agregar Doctor" CssClass="btn btn-success" OnClick="btnAgregarDoctor_Click" />
                </div>
                <asp:GridView ID="gvDoctores" runat="server" AutoGenerateColumns="False" DataKeyNames="DoctorId"
                    CssClass="table table-striped table-hover"
                    OnRowEditing="gvDoctores_RowEditing" OnRowCancelingEdit="gvDoctores_RowCancelingEdit"
                    OnRowUpdating="gvDoctores_RowUpdating" OnRowDeleting="gvDoctores_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="DoctorId" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo" />
                        <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <!-- HORARIOS -->
        <div class="card shadow mb-4">
            <div class="card-header bg-warning text-dark">
                <h4 class="mb-0">Horarios</h4>
            </div>
            <div class="card-body">
                <!-- Formulario para agregar horario -->
                <div class="mb-3">
                    <asp:DropDownList ID="ddlDoctorHorarioNuevo" runat="server" CssClass="form-select mb-1" />
                    <asp:TextBox ID="txtDiaSemanaHorario" runat="server" Placeholder="Día Semana" CssClass="form-control mb-1" />
                    <asp:TextBox ID="txtHoraInicioHorario" runat="server" TextMode="Time" CssClass="form-control mb-1" />
                    <asp:TextBox ID="txtHoraFinHorario" runat="server" TextMode="Time" CssClass="form-control mb-1" />
                    <asp:Button ID="btnAgregarHorario" runat="server" Text="Agregar Horario" CssClass="btn btn-success" OnClick="btnAgregarHorario_Click" />
                </div>
                <asp:GridView ID="gvHorarios" runat="server" AutoGenerateColumns="False" DataKeyNames="HorarioId"
                    CssClass="table table-striped table-hover"
                    OnRowEditing="gvHorarios_RowEditing" OnRowCancelingEdit="gvHorarios_RowCancelingEdit"
                    OnRowUpdating="gvHorarios_RowUpdating" OnRowDeleting="gvHorarios_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="HorarioId" HeaderText="ID" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Doctor">
                            <ItemTemplate>
                                <%# Eval("DoctorId") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlDoctorHorario" runat="server" CssClass="form-select" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DiaSemana" HeaderText="Día Semana" />
                        <asp:BoundField DataField="HoraInicio" HeaderText="Hora Inicio" DataFormatString="{0:hh\\:mm}" />
                        <asp:BoundField DataField="HoraFin" HeaderText="Hora Fin" DataFormatString="{0:hh\\:mm}" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <!-- CITAS -->
        <div class="card shadow mb-4">
            <div class="card-header bg-info text-white">
                <h4 class="mb-0">Citas</h4>
            </div>
            <div class="card-body">
                <!-- Formulario para agregar cita -->
                <div class="mb-3">
                    <asp:DropDownList ID="ddlPacienteCitaNuevo" runat="server" CssClass="form-select mb-1" />
                    <asp:DropDownList ID="ddlDoctorCitaNuevo" runat="server" CssClass="form-select mb-1" />
                    <asp:TextBox ID="txtFechaHoraCita" runat="server" TextMode="DateTimeLocal" CssClass="form-control mb-1" />
                    <asp:TextBox ID="txtEstadoCita" runat="server" Placeholder="Estado" CssClass="form-control mb-1" />
                    <asp:TextBox ID="txtObservacionesCita" runat="server" Placeholder="Observaciones" CssClass="form-control mb-1" />
                    <asp:Button ID="btnAgregarCita" runat="server" Text="Agregar Cita" CssClass="btn btn-success" OnClick="btnAgregarCita_Click" />
                </div>
                <asp:GridView ID="gvCitas" runat="server" AutoGenerateColumns="False" DataKeyNames="CitaId"
                    CssClass="table table-striped table-hover"
                    OnRowEditing="gvCitas_RowEditing" OnRowCancelingEdit="gvCitas_RowCancelingEdit"
                    OnRowUpdating="gvCitas_RowUpdating" OnRowDeleting="gvCitas_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="CitaId" HeaderText="ID" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Paciente">
                            <ItemTemplate>
                                <%# Eval("PacienteId") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlPacienteCita" runat="server" CssClass="form-select" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Doctor">
                            <ItemTemplate>
                                <%# Eval("DoctorId") %>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlDoctorCita" runat="server" CssClass="form-select" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <!-- Bootstrap CSS & JS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>