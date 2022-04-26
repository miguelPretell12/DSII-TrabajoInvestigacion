<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Clinica_DSII.tecnico.citamedica.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Citas Médicas</h1>
        <div class="mb-3">
            <a href="/tecnico/index" class="btn btn-outline-danger" >Dashboard</a>
            <a class="btn btn-primary d-inline" href="/tecnico/citamedica/create">Crear Cita Medica</a>
        </div>
        <div class="table-responsive">
            <asp:GridView ID="grdCMedica" runat="server" CssClass="table table-striped table-hover">
            </asp:GridView>
        </div>
    </div>
</asp:Content>
