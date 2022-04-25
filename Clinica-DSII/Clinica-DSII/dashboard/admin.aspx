<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Clinica_DSII.dashboard.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="column mt-3">
            <div class="col-sm">
                <h1>Bienvenido: <span class="font-bold" style="text-transform: capitalize; font-weight: 400  ">
                <asp:Label ID="lblSNombre" runat="server" ></asp:Label></span>
                </h1>
            </div>
            <div class="col-sm">
                <h3>Cargo: 
                 <span class="font-bold" style="text-transform: capitalize;">
                     <asp:Label ID="lblScargo" runat="server" ></asp:Label>
                 </span>
                </h3>
            </div>
        </div>

        <div class="row">

        </div>
    </div>
</asp:Content>
