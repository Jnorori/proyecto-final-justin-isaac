<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Paciente.aspx.vb" Inherits="Proyecto_Progra_III_Justin_Isaac.Paciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">
        <div class="alert alert-info">
            <h2>¡Bienvenido, <asp:Label ID="lblUsuario" runat="server"></asp:Label>!</h2>
        </div>

        <div class="card mb-4">
            <div class="card-header bg-primary text-white">
                <h4>Mis Citas</h4>
            </div>
            <div class="card-body">
                <asp:GridView ID="gvCitas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover table-bordered">
                    <Columns>
                        <asp:BoundField DataField="Doctor" HeaderText="Doctor" />
                        <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="card">
            <div class="card-header bg-success text-white">
                <h4>Agendar Nueva Cita</h4>
            </div>
            <div class="card-body">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label><br /><br />

                <div class="mb-3">
                    <label for="ddlDoctores" class="form-label">Seleccionar Doctor</label>
                    <asp:DropDownList ID="ddlDoctores" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label for="txtFechaHora" class="form-label">Fecha y Hora</label>
                    <asp:TextBox ID="txtFechaHora" runat="server" CssClass="form-control" placeholder="AAAA-MM-DD HH:MM"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label for="txtObservaciones" class="form-label">Observaciones</label>
                    <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control" placeholder="Opcional" TextMode="MultiLine" Rows="3"></asp:TextBox>
                </div>

                <asp:Button ID="btnAgendarCita" runat="server" Text="Agendar Cita" CssClass="btn btn-success" OnClick="btnAgendarCita_Click" />
            </div>
        </div>
    </div>

</asp:Content>
