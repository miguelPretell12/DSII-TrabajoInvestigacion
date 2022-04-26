using Clinica_DSII.Entidades;
using Clinica_DSII.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica_DSII.tecnico.paciente
{
    public partial class create : System.Web.UI.Page
    {
        DaoPaciente dao = new DaoPaciente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sessioncargo = Session["sessioncargo"] as string;
                if (sessioncargo == null || sessioncargo != "tecnico")
                {
                    Response.Redirect("/login");
                }
            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            string nombre, apellido, dni, correo;
            DateTime fechaNac;

            nombre = txtNombre.Text;
            apellido = txtApellido.Text;
            dni = txtDni.Text;
            correo = txtCorreo.Text;
            fechaNac = DateTime.Parse(txtFechaNac.Text);

            Paciente pac = new Paciente(nombre, apellido, dni, correo, fechaNac);

            if(dao.insertar(pac))
            {
                Response.Redirect("/tecnico/pacientes/index");
            } else
            {
                Response.Redirect("/tecnico/paciente/create");
            }

        }
    }
}