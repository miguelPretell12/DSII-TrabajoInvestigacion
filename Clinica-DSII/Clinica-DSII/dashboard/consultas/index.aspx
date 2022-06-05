<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Clinica_DSII.dashboard.consultas.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-3">
        <h1>Consulta - Medicos</h1>
        <div class="form-group">
            <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modalconsulta">
              Crear Consultas
            </button>
        </div>

        <div class="table-responsive">
            <table id="table-consultas" class="table">
                <thead>
                    <tr>
                        <th>Medico</th>
                        <th>Especialidad</th>
                        <th>Horario</th>
                        <th>Precio</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    </div>

    <div class="modal fade" id="modalconsulta" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Registrar consultas</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
              <div id="alerta">
              </div>
              <input type="hidden" id="idconsulta" />
            <div class="form-group">
                <label>Medico</label>
                <select class="form-control" id="medico">
                    <option>--seleccione</option>
                </select>
            </div>
            <div class="form-group">
                <label>Especialidad</label>
                <input type="hidden" id="idespecialidad" />
                <input type="text" class="form-control" disabled id="especialidad"/>
            </div>
            <div class="form-group">
                <label>Horario</label>
                <select class="form-control" id="horario">
                    <option>--seleccione--</option>
                </select> 
            </div>
            <div class="form-group">
                <label>Precio:</label>
                <input type="number" class="form-control" id="precio" min="0" step="0.01"/>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
            <button type="submit" class="btn btn-primary" id="save" >Guardar</button>
          </div>
        </div>
      </div>
    </div>

    <script type="text/javascript">
        const tableall = document.querySelector("#table-consultas tbody");
        const alertadiv = document.querySelector("#alerta");
        //
        document.addEventListener("DOMContentLoaded", function (e) {
            getMedicos();
            getHorarios();
            tableConsultas();
        })

        // obtener la especialidad con el evento change
        $(document).on("change", "#medico", function (e) {
            const data = {
                idmedico: e.target.value
            };

            getMedicoEsp(data);
        })

        // obtener los medicos
        function getMedicos() {
            const medicos = document.querySelector("#medico");
            $.ajax({
                type: 'POST',
                url: '/dashboard/consultas/index.aspx/getMedicos',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (e) {
                    const { d } = e;
                    d.forEach((med) => {
                        const { idmedico, medico} = med;
                        const option = document.createElement("option");
                        option.value = idmedico;
                        option.textContent = medico;

                        medicos.appendChild(option);
                    })
                }
            })
        }

        // obtener la especialidad del medico seleccionado en el primer campo
        function getMedicoEsp(data) {
            const idesp = document.querySelector("#idespecialidad");
            const esp = document.querySelector("#especialidad");
            $.ajax({
                type: 'POST',
                url: '/dashboard/consultas/index.aspx/getMedicoEsp',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(data),
                success: function (e) {
                    const { idespecialidad, nombre } = e.d;
                    idesp.value = idespecialidad;
                    esp.value = nombre;
                }
            })
        }

        // obtener todos los horarios para la asignacion de las consulta que se va a crear
        function getHorarios() {
            const horarios = document.querySelector("#horario")
            $.ajax({
                type: 'POST',
                url: '/dashboard/consultas/index.aspx/getHorarios',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (e) {
                    const { d } = e;
                    d.forEach((hor) => {
                        const { idhorario, horainicio, horafinal } = hor;
                        const option = document.createElement("option");
                        const inicioHour = (horainicio.Hours < 10 ? '0' + horainicio.Hours : horainicio.Hours) + ':' + (horainicio.Minutes < 10 ? '0' + horainicio.Minutes : horainicio.Minutes);
                        const finalHour = (horafinal.Hours < 10 ? '0' + horafinal.Hours : horafinal.Hours) + ':' + (horafinal.Minutes < 10 ? '0' + horafinal.Minutes : horafinal.Minutes)
                        option.value = idhorario;
                        option.innerHTML = `${inicioHour} - ${finalHour} `;
                        horarios.appendChild(option);
                    })
                }
            })
        }

        // guardar la consulta
        function save(data) {
            $.ajax({
                type: 'POST',
                url: '/dashboard/consultas/index.aspx/save',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(data),
                success: function (e) {
                    const { d } = e;
                    console.log(e)
                    if (d) {
                        swal("Exito!!!", "Se regsitro correctamente", "success");
                        $("#modalconsulta").modal('hide')
                        tableConsultas()
                    } else {
                        swal("Error!!", "La consulta que esta por registrar ya existe", "error")
                    }
                }
            })
        }

        // actualizar la consulta
        function update(data) {
            $.ajax({
                type: 'POST',
                url: '/dashboard/consultas/index.aspx/update',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(data),
                success: function (e) {
                    const { d } = e;
                }
            })
        }

        function getConsulta(data) {
            $.ajax({
                type: 'POST',
                url: '/dashboard/consultas/index.aspx/getConsulta',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(data),
                success: function (e) {
                    const {  } = e.d;
                }
            })
        }

        // llenar la tabla
        function tableConsultas() {
            $.ajax({
                type: 'POST',
                url: '/dashboard/consultas/index.aspx/getConsultas',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (e) {
                    const { d } = e;
                    limpiar();
                    if (d.length > 0) {
                        d.forEach((consul) => {
                            const { idconsulta, medico, especialidad, horainicio, horafinal, precio } = consul;
                            const tr = document.createElement("tr");
                            const inicioHour = (horainicio.Hours < 10 ? '0' + horainicio.Hours : horainicio.Hours) + ':' + (horainicio.Minutes < 10 ? '0' + horainicio.Minutes : horainicio.Minutes);
                            const finalHour = (horafinal.Hours < 10 ? '0' + horafinal.Hours : horafinal.Hours) + ':' + (horafinal.Minutes < 10 ? '0' + horafinal.Minutes : horafinal.Minutes)
                            tr.innerHTML = `
                                <td>${medico}</td>
                                <td>${especialidad}</td>
                                <td>${inicioHour} - ${finalHour}</td>
                                <td>S/. ${precio}</td>
                                <td>
                                    <button type="button" class="btn btn-warning" data-bs-toggle="modal" data-bs-target="#exampleModal" data-id="${idconsulta}" id="editar"> Editar</button>
                                    
                                </td>
                            `;
                            tableall.appendChild(tr);
                        })
                    } else {
                        const tr = document.querySelector("tr");
                        tr.innerHTML = `
                            <td col="5">No hay datos registrados aún</td>
                        `;
                        tableall.appendChild(tr);
                    }
                }
            })
        } 

        function limpiar() {
            while (tableall.firstChild) {
                tableall.removeChild(tableall.firstChild);
            }
        }


        $(document).on("click", "#save", function (e) {
            e.preventDefault();
            const medico = document.querySelector("#medico");
            const especialidad = document.querySelector("#idespecialidad");
            const horario = document.querySelector("#horario");
            const idconsulta = document.querySelector("#idconsulta");
            const precio = document.querySelector("#precio");

            const data = {
                idmed: medico.value, idesp: especialidad.value, idhor: horario.value, precio:precio.value
            };
            console.log(data)
            if (medico.value == "" || especialidad.value == "" || horario.value == "" || precio.value == "") {
               mostrarMensaje('Completar todos los campos', 'danger');
               return;
            }

            if (idconsulta.value == "") {
                save(data);
            } else {
                update(data)
            }
            
        })

        function mostrarMensaje(mensaje, tipo) {
            while (alertadiv.firstChild) { alertadiv.removeChild(alertadiv.firstChild); }
            const div = document.createElement("div");
            div.classList.add('alert', `alert-${tipo}`);
            div.innerHTML = `${mensaje}`;

            alertadiv.appendChild(div);
        }
    </script>

</asp:Content>
