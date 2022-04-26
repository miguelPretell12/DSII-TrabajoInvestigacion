<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Clinica_DSII.tecnico.index" %>
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
        
        <hr />

        <div class="row row-cols-1 row-cols-md-2 g-4">
            <div class="col">
                <div class="card">
                    <div class="card-body">
                      <h5 class="card-title">Pacientes</h5>
                      <p class="card-text">Se vera el listado de pacientes, y registro de la misma</p>
                    </div>
                    <div class="card-footer">
                        <a class="btn btn-success" href="/tecnico/pacientes/index">Ver pacientes</a>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card">
                    <div class="card-body">
                      <h5 class="card-title">Cita Medica</h5>
                      <p class="card-text">Se vera el listado de cita medica, y registro de la misma</p>
                    </div>
                    <div class="card-footer">
                        <a class="btn btn-success" href="/tecnico/citamedica/index">Ver Citas médica</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
