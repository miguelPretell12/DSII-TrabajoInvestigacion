<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="create.aspx.cs" Inherits="Clinica_DSII.dashboard.horarios.create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-3">
        <h1>Horarios</h1>
            
        <div class="row">
            <div class="col-sm">
                <asp:Label ID="Label1" runat="server" Text="Hora Inicio"></asp:Label>
                <asp:TextBox ID="txtHoraI" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHoraI" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Campo Requerido</asp:RequiredFieldValidator>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label2" runat="server" Text="Hora Final"></asp:Label>
                <asp:TextBox ID="txtHoraF" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHoraF" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Campo Requerido</asp:RequiredFieldValidator>
            </div>
        </div>
         <asp:Label ID="lblr" runat="server" ></asp:Label>
        <div class="mt-3">
            <a runat="server" href="~/dashboard/admin.aspx" class="btn btn-outline-danger">Dashboard</a>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        </div>
        <div class="table-responsive mt-3">
            <asp:GridView ID="grdHorario" runat="server" CssClass="table table-striped table-hover"></asp:GridView>
        </div>
    </div>
</asp:Content>
