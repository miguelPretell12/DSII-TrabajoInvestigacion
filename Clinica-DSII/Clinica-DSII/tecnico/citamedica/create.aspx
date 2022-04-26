<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="create.aspx.cs" Inherits="Clinica_DSII.tecnico.citamedica.create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-3">

        <h1>Crear la Cita Médica</h1>

        <div class="row mt-3">
            <div class="col-sm">
                <asp:Label ID="Label3" runat="server" Text="Paciente"></asp:Label>
                <asp:DropDownList ID="ddlpaciente" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label2" runat="server" Text="Especialidad"></asp:Label>
                <asp:DropDownList ID="ddlMedEsp" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label1" runat="server" Text="Horario"></asp:Label>
                <asp:DropDownList ID="ddlhorario" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-sm">
                <asp:Label ID="Label4" runat="server" Text="Fecha de Cita"></asp:Label>
                <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label5" runat="server" Text="Estado"></asp:Label>
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="row mt-3">
            <div class="col-sm">
                <asp:Label ID="Label6" runat="server" Text="Peso (Kg)"></asp:Label>
                <asp:TextBox ID="txtPeso" runat="server" TextMode="Number" step="0.01" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label7" runat="server" Text="Estatura (m)"></asp:Label>
                <asp:TextBox ID="txtEstatura" runat="server" TextMode="Number" step="0.01" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label8" runat="server" Text="¿Es alergico a los medicamentos?"></asp:Label>
                <asp:DropDownList ID="ddlAler" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="mt-3">
            <a runat="server" href="~/tecnico/citamedica/index" class="btn btn-outline-success">Volver</a>
            <asp:Button ID="btnRegistro" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnRegistro_Click"/> <br />
        </div>
    </div>
</asp:Content>
