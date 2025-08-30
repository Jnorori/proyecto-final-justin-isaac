<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="Login.aspx.vb" Inherits="Proyecto_Progra_III_Justin_Isaac.Login" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Login - Clínica</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="row justify-content-center">
                <div class="col-md-4">
                    <div class="card shadow">
                        <div class="card-body">
                            <h3 class="card-title text-center mb-4">Iniciar Sesión</h3>

                            <asp:Label ID="lblError" runat="server" CssClass="text-danger mb-3 d-block"></asp:Label>

                            <div class="mb-3">
                                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" Placeholder="Usuario"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" Placeholder="Contraseña"></asp:TextBox>
                            </div>
                            <div class="d-grid">
                                <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
    </form>
</body>
</html>
