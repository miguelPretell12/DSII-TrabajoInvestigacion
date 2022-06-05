<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Clinica_DSII.paciente.index" %>
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
                      <h5 class="card-title">Citas Médicas</h5>
                      <p class="card-text">Mostrara las citas qu asististe, y cuanto pagastes</p>
                    </div>
                    <div class="card-footer">
                        <a class="btn btn-success" href="/paciente/citasmedicas/index">Ver Citas Medicas</a>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card">
                    <div class="card-body">
                      <h5 class="card-title">Reserva tu cita</h5>
                      <p class="card-text">En este modulo se reservara la cita, a la vez que se pagara para la confirmacion de esta</p>
                    </div>
                    <div class="card-footer">
                        <a class="btn btn-success" href="/paciente/reserva/index">Crear Receta</a>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
