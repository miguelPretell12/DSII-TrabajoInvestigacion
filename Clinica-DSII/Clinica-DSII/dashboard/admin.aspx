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
                <asp:Button ID="btnCerrrar" CssClass="btn btn-danger" runat="server" Text="Cerrar Sesion" OnClick="btnCerrrar_Click" />
            </div>
        </div>
        <hr />

        <div class="row row-cols-1 row-cols-md-2 g-4">
            <div class="col">
                <div class="card">
                    <div class="card-body">
                      <h5 class="card-title">Usuarios</h5>
                      <p class="card-text">Se vera el listado de usuarios, y registro de la misma</p>
                    </div>
                    <div class="card-footer">
                        <a class="btn btn-success" href="/dashboard/usuarios/index">Ver Usuarios</a>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card">
                    <div class="card-body">
                      <h5 class="card-title">Horarios</h5>
                      <p class="card-text">Se vera el listado de horarios de los doctores, y registro de la misma</p>
                    </div>
                    <div class="card-footer">
                        <a class="btn btn-success" href="/dashboard/horarios/create">Ver Horarios</a>
                    </div>
                </div>
            </div>
        </div>
        <div class="row row-cols-1 row-cols-md-2 g-4 mt-2">
            <div class="col">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Especialidad - Medico</h5>
                        <p class="card-text">
                            En este modulo, se agregara a cada medico con su especialidad correspondiente, para la atencion de los pacientes
                        </p>
                    </div>
                    <div class="card-footer">
                        <a class="btn btn-success" href="/dashboard/especialidadMedico/index">
                            Ver Medicos
                        </a>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
