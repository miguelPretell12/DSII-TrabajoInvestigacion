<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Clinica_DSII.tecnico.paciente.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Pacientes</h1>
        <div class="mb-3">
            <a href="/tecnico/index" class="btn btn-outline-danger" >Dashboard</a>
            <a class="btn btn-primary d-inline" href="/tecnico/pacientes/create">Crear Pacientes</a>
        </div>
        <div class="table-responsive">
            <asp:GridView ID="grdPaciente" runat="server" CssClass="table table-striped table-hover" OnSelectedIndexChanged="grdPaciente_SelectedIndexChanged">
            </asp:GridView>
        </div>
    </div>
</asp:Content>
