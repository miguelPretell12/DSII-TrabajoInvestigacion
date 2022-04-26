<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Clinica_DSII.dashboard.usuarios.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .table {
        border: 1px solid #808080;
    }

    .table tr:first-child {
        background-color: #000000!important;
    }

    .table tr:first-child th {
        color: #fff!important;
    }
</style>
    <div class="container mt-3">
        <h1>Usuarios</h1>
        <div class="mb-3">
            <a class="btn btn-primary d-inline" href="/dashboard/usuarios/create">Crear Usuarios</a>
        </div>
        <div class="row">
            <div class="col-sm">
                
            </div>
            <div class="col-sm">
                
            </div>
        </div>
        <div class="table-responsive">
            <asp:GridView ID="grdUsuario" runat="server" CssClass="table table-striped table-hover">
            </asp:GridView>
        </div>
    </div>
</asp:Content>
