<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Clinica_DSII.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="">
        <div class="d-flex justify-content-center align-items-center flex-column" style="height: 80vh">
            
            <div class="card mw-500">
                <div class="card-header">
                    <h3>Login - Clinica</h3>
                </div>
                <div class="card-body">
                    <div class="form-group">
                         <asp:Label ID="Label3" runat="server" Text="Correo Electronico"></asp:Label>
                         <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server" oncomplete="false"></asp:TextBox>
                     </div>
                     <div class="form-group">
                         <asp:Label ID="Label4" runat="server" Text="Contraseña"></asp:Label>
                         <asp:TextBox ID="txtContrasenia" CssClass="form-control" runat="server"></asp:TextBox>
                     </div>
                     <div class="mt-3">
                         <asp:Button ID="btnInicio" runat="server" Text="Iniciar sesión" CssClass="btn btn-primary" OnClick="Button2_Click" />
                     </div>
                </div>
                <asp:Label ID="lblR" runat="server"></asp:Label>
            </div>
        </div>

    </div>
</asp:Content>
