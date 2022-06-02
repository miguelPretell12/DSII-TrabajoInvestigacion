<%@ Page Title="Especialidad - Medico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Clinica_DSII.dashboard.especialidadMedico.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-3">
        <h1>Especialidad - Medico</h1>
        <div class="row row-cols-1 row-cols-lg-2">
            <div class="col">
                <div>
                    <label>Buscar DNI - Medico:</label>
                    <input type="text" id="dni" class="form-control mt-2" placeholder="DNI del medico" autocomplete="off"/>
                </div>
                <a href="/dashboard/admin" class="btn btn-secondary mt-3">Volver</a>
                <input type="submit" id="buscar" class="btn btn-primary mt-3" value="Buscar" />
            </div>
            <div class="col align-self-center mt-2">
                <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
                  Listado de Medicos con especialidad
                </button>
            </div>
        </div>
    </div>
    <%-- Modal - Listado de Medicos con especialidad --%>
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-scrollable">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Medicos - Especialidad</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
              <div class="form-group">
                  <label>Buscar por D.N.I. a medico con especialidad:</label>
                  <input type="text" placeholder="D.N.I. de medico" class="form-control" id="searchdni"/>
              </div>
              <hr />
            <ul class="list-group list-group-numbered" id="contenedorUL">
                
            </ul>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          </div>
        </div>
      </div>
    </div>

    <div id="mensaje">

    </div>
    <div class="mt-3" id="respuesta">
       <div class="row row-cols-1 row-cols-md-2 " style="margin-top: 15px">
                <input type="hidden"  id="idespmed"/>
                <input type="hidden"  id="idusuario" />
                <div class="col">
                    <label>Médico</label>
                    <input type="text" class="form-control" id="medico" disabled  style="text-transform: capitalize"/>
                </div>
                <div class="col">
                    <label>D.N.I.</label>
                    <input type="text" class="form-control" id="docdni" disabled  style="text-transform: capitalize"/>
                </div>
                <div class="col">
                    <label>Correo Electronico</label>
                    <input type="text" class="form-control" id="correo" disabled style="text-transform: capitalize" />
                </div>
            </div>
            <div class="row" style="margin-top: 15px">
                <div class="col">
                    <label>Especialidad</label>
                    <select id="especialidad" class="form-control" style="width: 50%">
                        <option value="">--SELECCIONE--</option>
                    </select>
                </div>
            </div>
        <input type="submit" class="btn btn-success mt-2" id="guardar" value="Guardar" />
    </div>
    <script type="text/javascript">
        const contenedorMensaje = document.querySelector("#mensaje");
        const contenedorUL = document.querySelector("#contenedorUL");
        $("#respuesta").hide()
        listar();
        $(document).on('click', '#buscar', function (e) {
            e.preventDefault();
            const dni = $("#dni").val();

            const data = { dni: dni };
            $.ajax({
                type: 'POST',
                url: '/dashboard/especialidadMedico/index.aspx/obtenerMedico',
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    const { correo, dni, idusuario, medico, idespecialidad, idespmed } = response.d;
                    console.log(response)
                    if (idusuario == 0) {
                        $("#respuesta").hide()
                        
                        mostrarMensaje('Médico no registrado o con otro cargo','danger')
                        
                    } else {
                        $("#respuesta").show()
                        $("#idespmed").val(idespmed)
                        $("#idusuario").val(idusuario)
                        $("#medico").val(medico)
                        $("#especialidad").val(idespecialidad)
                        $("#docdni").val(dni)
                        $("#correo").val(correo)
                    }
                    
                }
            })
        })

        function mostrarMensaje(mensaje, tipo) {
            limpiarMensaje()
            const div = document.createElement('div');
            div.classList.add('alert', `alert-${tipo}`, 'text-center','mt-3');
            div.innerHTML = `
                ${mensaje}
            `;
            contenedorMensaje.appendChild(div);
            setTimeout(() => {
                div.remove()
            }, 1500)
        }

        function listar() {
            //limpiarSelect();
            const contenedorSelect = document.querySelector("#especialidad");
            $.ajax({
                type: 'POST',
                url: '/dashboard/especialidadMedico/index.aspx/listarEspecialidad',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (e) {

                    const { d } = e;
                    d.forEach((esp) => {
                        const { idespecialidad, nombre } = esp;
                        const option = document.createElement('option');
                        option.value = idespecialidad;
                        option.textContent = nombre;
                        
                        contenedorSelect.appendChild(option);
                    })
                }
            })
        }

        $(document).on('click', '#guardar', function (e) {
            e.preventDefault()
            const id = $("#idespmed").val();
            const idusuario = $("#idusuario").val();
            const idespecialidad = $("#especialidad").val();

            const data = {
                idusuario: idusuario,
                idesp: idespecialidad
            };

            if (id != 0) {
                data.idespmed = id;
                actualizar(data);
            } else {
                guardar(data);
            }
        })

        function limpiarMensaje() {
            while (contenedorMensaje.firstChild) {
                contenedorMensaje.removeChild(contenedorMensaje.firstChild)
            }
        }

        function guardar(data) {
            $.ajax({
                type: 'POST',
                url: '/dashboard/especialidadMedico/index.aspx/save',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(data),
                success: function (e) {
                    const { d } = e
                    if (d == 1) {
                        $("#respuesta").hide()
                        swal('Exito!!', 'Se guardo los datos correctamente', 'success')
                    } else {
                        swal('Error', 'Hubo un error al guardar', 'error')
                    }
                }
            });
        }

        function actualizar(data) {
            $.ajax({
                type: 'POST',
                url: '/dashboard/especialidadMedico/index.aspx/update',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(data),
                success: function (e) {
                    const { d } = e
                    if (d == 1) {
                        $("#respuesta").hide()
                        swal('Exito!!','Se actualizo los datos correctamente','success')
                    } else {
                        swal('Error','Hubo un error al actualizar','error')
                    }
                }
            });
        }

        function searchEspMed(data) {
            $.ajax({
                type: 'POST',
                url: '/dashboard/especialidadMedico/index.aspx/searchEspMed',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(data),
                success: function (e) {
                    const { d } = e
                    
                    const countArray = d.length;
                    
                    if (countArray > 0) {
                        limpiarUL()
                        d.forEach((espmed) => {

                            const li = document.createElement('li');
                            li.classList.add('list-group-item', 'd-flex', 'justify-content-between', 'align-items-start')
                            const { idespmed, especialidad,dni, medico } = espmed;
                            li.innerHTML = `
                            <div class="ms-2 me-auto">
                                <div class="fw-bold">${medico}</div>
                                ${dni} - ${especialidad}
                            </div>
                            <button type="button" class="btn btn-danger" id="delete" data-espmed = "${idespmed}">X</button>
                            `;
                            contenedorUL.appendChild(li);
                        })
                        console.log(countArray)
                    } else {
                        limpiarUL()
                        const div = document.createElement('div');
                        div.classList.add('alert', 'alert-primary');
                        div.innerHTML = "No se encontraron registros coincidentes"
                        contenedorUL.appendChild(div)
                    }
                }
            })
        }

        $(document).on('keyup', '#searchdni', function (e) {
            const valuedni = e.target.value;
            const data = { dni: valuedni }
            searchEspMed(data)
        })

        function limpiarUL() {
            while (contenedorUL.firstChild) {
                contenedorUL.removeChild(contenedorUL.firstChild);
            }
        }

        function listarEspMedUl() {
            $.ajax({
                type: 'POST',
                url: '/dashboard/especialidadMedico/index.aspx/ListEspMed',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (e) {
                    const { d } = e

                    const countArray = d.length;

                    if (countArray > 0) {
                        limpiarUL()
                        d.forEach((espmed) => {

                            const li = document.createElement('li');
                            li.classList.add('list-group-item', 'd-flex', 'justify-content-between', 'align-items-start')
                            const { idespmed, especialidad, dni, medico } = espmed;
                            li.innerHTML = `
                            <div class="ms-2 me-auto">
                                <div class="fw-bold">${medico}</div>
                                ${dni} - ${especialidad}
                            </div>
                            <button type="button" class="btn btn-danger"  id="delete" data-espmed = "${idespmed}">X</button>
                            `;
                            contenedorUL.appendChild(li);
                        })
                        console.log(countArray)
                    } else {
                        limpiarUL()
                        const div = document.createElement('div');
                        div.classList.add('alert', 'alert-primary');
                        div.innerHTML = "No hay registros coincidentes"
                        contenedorUL.appendChild(div)
                    }
                }
            })
        }

        listarEspMedUl()

        $(document).on('click', '#delete', function (e) {
            const id = e.target.dataset.espmed;
            const data = {idespmed: id}
            swal({
                title: "¿Seguro que quieres eliminar este Medico con Especialidad?",
                text: "Una vez eliminado, ya no se podra recuperar los datos",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((resp) => {
                    if (resp) {
                        $.ajax({
                            type: 'POST',
                            url: '/dashboard/especialidadMedico/index.aspx/deleteEspMed',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            data: JSON.stringify(data),
                            success: function (e) {
                                console.log(e)
                                const { d } = e;
                                if (d) {
                                    swal('Exito!!', 'Se elimino el Medico-Especialidad con exito', 'success')
                                    listarEspMedUl()
                                } else {
                                    swal('Error!!', 'No se pudo eliminar al Medico-Especialidad, por motivo de estar registrado en otro servicio', 'error');
                                }
                            }
                        })
                    }
                });
        })
    </script>
</asp:Content>
