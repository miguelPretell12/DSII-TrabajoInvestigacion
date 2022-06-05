<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Clinica_DSII.tecnico.citamedica.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-3">
        <h1>Citas Médicas</h1>
        <div class="mb-3">
            <a href="/tecnico/index" class="btn btn-outline-danger" >Dashboard</a>
            <a href="/tecnico/citamedica/create" class="btn btn-primary d-inline">Crear Cita Medica</a>
        </div>
        <div class="row g-8">
            <div class="col-md-3">
                <p>
                    Consultar cita médica por paciente:
                </p>
                <p>
                    <asp:TextBox ID="txtParam" runat="server" CssClass="form-control"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-success" OnClick="btnConsultar_Click" />
                    <asp:Button ID="btnRestaurar" runat="server" Text="Limpiar" CssClass="btn btn-info" OnClick="btnRestaurar_Click" />
                </p>
            </div>
            <div class="col-md-8">
                Consultar cita médica por fecha:
                <div class="row g-10">
                    <div class="col-md-5">
                        <p>
                            <asp:Label ID="Label1" runat="server" Text="Desde:"></asp:Label>
                            <asp:TextBox ID="txtParamIni" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        </p>
                    </div>
                    <div class="col-md-5">
                        <asp:Label ID="Label2" runat="server" Text="Hasta:"></asp:Label>
                        <asp:TextBox ID="txtParamFi" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                    <p>
                        <asp:Button ID="btnConsultarF" runat="server" Text="Consultar" CssClass="btn btn-success" OnClick="btnConsultarF_Click" />
                    </p>
                </div>
            </div>
        </div>
        <div class="table-responsive">
            <asp:GridView ID="grdCMedica" runat="server" onRowCommand="grdCMedica_RowCommand" CssClass="table table-striped table-hover">
                <Columns>
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="lnkEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" class="btn btn-success" />
                            <asp:Button ID="lnkBorrar" runat="server" Text="Borrar" CommandName="Borrar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" class="btn btn-danger" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
