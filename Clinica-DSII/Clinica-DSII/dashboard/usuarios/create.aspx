<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="create.aspx.cs" Inherits="Clinica_DSII.dashboard.pacientes.create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

        <h1>Registro de Usuarios</h1>

        <div class="row mt-3">
            <div class="col-sm">
                <asp:Label ID="Label3" runat="server" Text="Nombres"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label2" runat="server" Text="Apellidos"></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label1" runat="server" Text="D.N.I"></asp:Label>
                <asp:TextBox ID="txtDni" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-sm">
                <asp:Label ID="Label4" runat="server" Text="Correo Electronico"></asp:Label>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label5" runat="server" Text="Contraseña"></asp:Label>
                <asp:TextBox ID="txtContrasenia" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label6" runat="server" Text="Cargos"></asp:Label>
                <asp:DropDownList ID="ddlCargo" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCargo_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        <div class="mt-3">
            <a runat="server" href="~/dashboard/admin">Volver</a>
            <asp:Button ID="btnRegistro" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnRegistro_Click" /> <br />
        </div>
    </div>
</asp:Content>
