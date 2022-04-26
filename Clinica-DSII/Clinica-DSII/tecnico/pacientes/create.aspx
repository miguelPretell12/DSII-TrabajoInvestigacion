<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="create.aspx.cs" Inherits="Clinica_DSII.tecnico.paciente.create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-3">

        <h1>Registro de Paciente</h1>

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
                <asp:Label ID="Label5" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                <asp:TextBox ID="txtFechaNac" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
        </div>
        <div class="mt-3">
            <a runat="server" href="~/tecnico/pacientes/index" class="btn btn-outline-success">Volver</a>
            <asp:Button ID="btnRegistro" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnRegistro_Click" /> <br />
        </div>
    </div>
</asp:Content>
