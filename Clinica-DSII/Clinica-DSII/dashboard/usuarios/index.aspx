<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Clinica_DSII.dashboard.usuarios.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container mt-3">
        <h1>Usuarios</h1>
        <div class="mb-3">
            <%--<a class="btn btn-primary d-inline" href="/dashboard/usuarios/create">Crear Usuarios</a>--%>
            <a href="/dashboard/admin" class="btn btn-secondary ">Volver</a>
            <button type="button" id="mostrar" class="btn btn-primary d-inline" data-bs-toggle="modal" data-bs-target="#modaluser">
               Crear Usuarios
            </button>
        </div>
        <div class="row">
            <div class="col-sm">
                
            </div>
            <div class="col-sm">
                
            </div>
        </div>

        <div class="table-responsive">
             <table id="tbl-user" class="table">
                 <thead>
                     <tr>
                         <th>Apellidos y Nombres</th>
                         <th>D.N.I.</th>
                         <th>Correo Electronico</th>
                         <th>Estado</th>
                         <th>Cargo</th>
                         <th></th>
                     </tr>
                 </thead>
                 <tbody>

                 </tbody>
             </table>
        </div>
    </div>

    <div class="modal fade" id="modaluser" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-scrollable">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <div id="mensaje-error"></div>
            <div class="mt-3">
                <input type="hidden" id="idusuarios"/>
                <div class="col-sm">
                    <asp:Label ID="Label3" runat="server" Text="Nombres"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Campo Requerido</asp:RequiredFieldValidator>
                </div>
                <div class="col-sm">
                    <asp:Label ID="Label2" runat="server" Text="Apellidos"></asp:Label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtApellido" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Campo Requerido</asp:RequiredFieldValidator>
                </div>
                <div class="col-sm">
                    <asp:Label ID="Label1" runat="server" Text="D.N.I"></asp:Label>
                    <asp:TextBox ID="txtDni" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDni" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Campo Requerido</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="mt-3">
                <div class="col-sm">
                    <asp:Label ID="Label4" runat="server" Text="Correo Electronico"></asp:Label>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCorreo" ErrorMessage="RegularExpressionValidator" ForeColor="RED" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*Ingrese correo electronico</asp:RegularExpressionValidator>
                    <div class="aler-msg"></div>
                </div>
                <div class="col-sm">
                    <asp:Label ID="Label5" runat="server" Text="Contraseña"></asp:Label>
                    <asp:TextBox ID="txtContrasenia" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtContrasenia" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*Campo Requerido</asp:RequiredFieldValidator>
                </div>
                <div class="col-sm">
                    <asp:Label ID="Label6" runat="server" Text="Cargos"></asp:Label>
                    <select id="cargos" class="form-control">
                        <option value="">--seleccione--</option>
                    </select>
                </div>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" />
          </div>
        </div>
      </div>
    </div>


    <script type="text/javascript">
        const tbluser = document.querySelector("#tbl-user tbody");
        const error = document.querySelector("#mensaje-error");
        const emailerror = document.querySelector(".aler-msg");
        const selectcargo = document.querySelector("#cargos");

        function listar() {
            $.ajax({
                type: 'POST',
                url: '/dashboard/usuarios/index.aspx/listar',
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).done(function (e) {
                const { d } = e;
                limpiarHTMLTbl();
                d.forEach((user) => {
                    const { idusuarios, nombre, apellido, correo, dni, cargo, estado } = user;
                    const tr = document.createElement('tr');
                    tr.innerHTML = `
                    <td>${apellido}, ${nombre} </td>
                    <td>${dni}</td>
                    <td>${correo}</td>
                    <td>
                        <button type="button" id="status" data-id="${idusuarios}" class="btn btn-${estado == 'A' ? 'success' : 'danger'}">${estado == 'A' ? 'Activo' : 'Inactivo'}</button>
                    </td>
                    <td style="text-transform: capitalize; font-weight: 700; text-align: center">
                        ${cargo}
                    </td>
                    <td>
                        <button type="button" class="btn btn-secondary d-inline" id="edit" data-bs-toggle="modal" data-id="${idusuarios}" data-bs-target="#modaluser">
                           Editar
                        </button>
                        <button type="button" class="btn btn-danger d-inline" id="delete" data-id="${idusuarios}">
                            Eliminar
                        </button>
                    </td>
                `;

                    tbluser.appendChild(tr);
                })
            })
        }

        $(document).on('click', '#status', function (e) {
            const id = e.target.dataset.id;
            const estado = e.target.textContent.toLowerCase();
            const data = {
                estado: estado == 'activo' ? 'I' : 'A',
                id: id
            }
            $.ajax({
                type: 'POST',
                url: '/dashboard/usuarios/index.aspx/status',
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                dataType: "json"
            }).done(function(r){
                const { estado } = r.d;
                e.target.classList.remove(`btn-${estado == 'I' ? 'success' : 'danger'}`);
                e.target.classList.add(`btn-${estado == 'I' ? 'danger' : 'success'}`);

                e.target.textContent = estado == 'A' ? 'Activo' : 'Inactivo';
            })

        })

        $(document).on('change', '#<%= txtCorreo.ClientID %>', function (e) {
            const data = {
                email: e.target.value
            }
            const id = $("#idusuarios").val();
            existCorreo(id, data)
        })

        function existCorreo(id, data = {}) {

            const btnSave = document.querySelector("#<%= btnGuardar.ClientID %>");
            const content = document.querySelector(".aler-msg");
            const p = document.createElement('p');

            if (id == '') {
                $.ajax({
                    type: 'POST',
                    url: '/dashboard/usuarios/index.aspx/consultarEmail',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify(data),
                    success: function (resp) {
                        limpiarHTMLEmail()
                        const { correo } = resp.d;
                        content.classList.add('color-red', 'm-0')
                        if (!correo) {
                            p.innerHTML = ``;
                            btnSave.disabled = false;
                        } else {
                            p.innerHTML = `<span style="color:red">*Correo ya registrado</span>`;
                            btnSave.disabled = true;
                        }
                        content.appendChild(p);
                    }
                })
            } else {
                limpiarHTMLEmail()
                btnSave.disabled = false;
                p.innerHTML = "";
                content.appendChild(p)

                $.ajax({
                    type: 'POST',
                    url: '/dashboard/usuarios/index.aspx/consultarEmail',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify(data),
                    success: function (resp) {
                        limpiarHTMLEmail()
                        const { correo, idusuarios } = resp.d;
                        content.classList.add('color-red', 'm-0')
                        if (idusuarios == id && correo == data.email) {
                            p.innerHTML = ``;
                            btnSave.disabled = false;
                        } else if (correo == data.email && idusuarios != id) {
                            p.innerHTML = `<span style="color:red">*Correo Ya existente en otro usuario</span>`;
                            btnSave.disabled = true;
                        }
                        content.appendChild(p);
                    }
                })
            }
        }

        $(document).on('click', '#delete', function (e) {
            const id = e.target.dataset.id;

            const data = { id }

            swal({
                title: "¿Seguro que quieres eliminar este usuario?",
                text: "Una vez eliminado, ya no se podra recuperar los datos",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((resp) => {
                    if (resp) {
                        $.ajax({
                            type: 'POST',
                            url: '/dashboard/usuarios/index.aspx/eliminar',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            data: JSON.stringify(data),
                            success: function (e) {
                                console.log(e)
                                const { d } = e;
                                if (d) {
                                    swal('Exito!!', 'Se elimino el usuario con exito', 'success')
                                    listar()
                                } else {
                                    swal('Error!!', 'No se pudo eliminar al usuario, por motivo de estar registrado en otro servicio', 'error');
                                }
                            }
                        })
                    } else {
                    }
                });

           
        })

        $(document).on('click', '#<%= btnGuardar.ClientID %>', function (e) {
            e.preventDefault();
            const id = $("#idusuarios").val()
            const nombre = $("#<%= txtNombre.ClientID %>").val();
            const apellido = $("#<%= txtApellido.ClientID %>").val();
            const dni = $("#<%= txtDni.ClientID %>").val();
            const correo = $("#<%= txtCorreo.ClientID %>").val();
            const password = $("#<%= txtContrasenia.ClientID %>").val();
            const cargo = $("#cargos").val();

            if (nombre == '' || apellido == '' || dni == '' || correo == '' || password == '' || cargo == '') {
                mostrarError('Completar todos los campos')
                return;
            }

            const data = {
              nombre: nombre,
              apellido: apellido,
              dni: dni,
              correo: correo,
              contrasenia: password,
              cargos: cargo,
              estado: 'A'       
            }
            if (id == '') {
                $.ajax({
                    type: 'POST',
                    url: '/dashboard/usuarios/index.aspx/insertar',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify(data),
                    success: function (e) {
                        console.log(e);
                        const { d } = e
                        if (d) {
                            limpiarForm();
                            swal('Exito!', 'Registro guardado con exito', "success")
                            $("#modaluser").modal('hide')
                            listar()
                        } else {
                            swal('Error!', 'Registro no fue guardado', "error")
                        }
                    }
                })
            } else {
                data.idusuario = id;
                $.ajax({
                    type: 'POST',
                    url: '/dashboard/usuarios/index.aspx/actualizar',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data: JSON.stringify(data),
                    success: function (e) {
                        console.log(e);
                        const { d } = e
                        if (d) {
                            limpiarForm();
                            swal('Exito!', 'Se actualizo con exito', "success")
                            $("#modaluser").modal('hide')
                            listar()
                        } else {
                            swal('Error!', 'Registro no fue guardado', "error")
                        }
                    }
                })
            }

        })

        $(document).on('click', '#mostrar', function (e) {
            limpiarForm();
        })

        $(document).on('click', '#edit', function (e) {
            // limpia la caja de texto
            limpiarForm();

            const id = e.target.dataset.id;

            const data = {
                id:id
            }
            console.log(data)
            $.ajax({
                type: 'POST',
                url: '/dashboard/usuarios/index.aspx/getUsuario',
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (e) {
                    const { nombre, apellido, correo, dni, idusuarios, contrasenia, estado, cargos } = e.d;
                    existCorreo(idusuarios, { email:correo})
                    console.log(e)
                    $("#idusuarios").val(idusuarios)
                    $("#<%= txtNombre.ClientID %>").val(nombre);
                    $("#<%= txtApellido.ClientID %>").val(apellido);
                    $("#<%= txtDni.ClientID %>").val(dni);
                    $("#<%= txtCorreo.ClientID %>").val(correo);
                    $("#<%= txtContrasenia.ClientID %>").val(contrasenia);
                    $("#cargos").val(cargos);
                }
            })
            console.log(id)
        });

        listar();
        // Ajax
        $.ajax({
            type: 'POST',
            url: '/dashboard/usuarios/index.aspx/Cargos',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (e) {
                const { d } = e;
                d.forEach((cargo) => {
                    const option = document.createElement('option');
                    option.value = cargo.idcargos;
                    option.innerHTML = cargo.nombre;

                    selectcargo.appendChild(option);
                })
            }
        })

        // Funciones
        function limpiarForm() {
            $("#idusuarios").val('')
            $("#<%= txtNombre.ClientID %>").val('');
            $("#<%= txtApellido.ClientID %>").val('');
            $("#<%= txtDni.ClientID %>").val('');
            $("#<%= txtCorreo.ClientID %>").val('');
            $("#<%= txtContrasenia.ClientID %>").val('');
            $("#cargos").val('');
        }

        function limpiarHTMLTbl() {
            while (tbluser.firstChild) {
                tbluser.removeChild(tbluser.firstChild);
            }
        }

        function limpiarHTMLError() {
            while (error.firstChild) {
                error.removeChild(error.firstChild);
            }
        }

        function limpiarHTMLEmail() {
            while (emailerror.firstChild) {
                emailerror.removeChild(emailerror.firstChild)
            }
        }

        function mostrarError(msg) {
            limpiarHTMLError();
            const div = document.createElement('div');
            div.classList.add('alert', 'alert-danger')
            div.innerHTML = `${msg}`;
            error.appendChild(div);
        }
    </script>
</asp:Content>
