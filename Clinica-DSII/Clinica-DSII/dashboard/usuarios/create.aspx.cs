using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clinica_DSII.Dao;
using Clinica_DSII.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Clinica_DSII.dashboard.pacientes
{
    public partial class create : System.Web.UI.Page
    {
        
        private SqlConnection cone = new SqlConnection(@"Server=DESKTOP-AS63TOF\MSSQL; Database=clinicaDSII; Integrated Security=true");
        DaoUsuario dao = new DaoUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string sessioncargo = Session["sessioncargo"] as string;
                if (sessioncargo == null || sessioncargo != "administrador")
                {
                    Response.Redirect("/login");
                }
                listarCargos();
            }
        }

        private void listarCargos()
        {
            DataSet ds = new DataSet();
            SqlCommand cm = new SqlCommand("select * from cargos", cone);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(ds);
            ddlCargo.DataSource = ds;
            ddlCargo.DataValueField = "Idcargo";
            ddlCargo.DataTextField = "Nombre";
            ddlCargo.DataBind();
        }

        protected void ddlCargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            string nombre, apellido, dni, correo, contra;
            int cargo;

            nombre = txtNombre.Text;
            apellido = txtApellido.Text;
            dni = txtDni.Text;
            correo = txtCorreo.Text;
            contra = txtContrasenia.Text;
            cargo = int.Parse(ddlCargo.Text);

            Usuario usu = new Usuario(nombre,apellido,dni,correo, contra,cargo, "A");
            //string ins = dao.guardar(usu);
            

            Response.Redirect("/dashboard");
        }
    }
}