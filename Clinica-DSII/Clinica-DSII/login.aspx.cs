using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clinica_DSII.Dao;
using Clinica_DSII.Entidades;
using System.Data.SqlClient;



namespace Clinica_DSII
{
    public partial class login : System.Web.UI.Page
    {
        Usuario usu = new Usuario();
        DaoUsuario dao = new DaoUsuario();

        DataTable dt = new DataTable();
        // Conexion de Base de datos - SQL Server
        private SqlConnection cone = new SqlConnection("Server=LAPTOP-OB4D3M28;Database=clinicaDSII;Integrated Security = true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string cargo = Session["sessioncargo"] as string;
                if (cargo != null)
                {
                    if (cargo == "administrador")
                    {
                        Response.Redirect("/dashboard/admin");
                    }
                    else if (cargo == "tecnico")
                    {
                        Response.Redirect("/tecnico/index");
                    }
                    else if (cargo == "doctor")
                    {
                        Response.Redirect("/medico/index");
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            usu.correo = txtCorreo.Text.ToLower().Trim();
            usu.contrasenia = txtContrasenia.Text.ToLower().Trim();

            dt = dao.IniciarSesion(usu);

            SqlCommand da = new SqlCommand("select c.Nombre as Cargos, u.Nombre as Nombre, u.Apellido as Apellido from usuarios u inner join cargos c on " +
                "c.idcargo = u.idcargo" +
                " where u.correo= @email and u.contrasenia=@cont and u.estado = 'A' ", cone);
            
            da.Parameters.AddWithValue("@email", usu.correo);
            da.Parameters.AddWithValue("@cont", usu.contrasenia);
            cone.Open();
            SqlDataReader getData = da.ExecuteReader();

            if (dt.Rows.Count == 0) {
                lblR.Text = "Error";
            } else {
                if (getData.Read()) {
                    Session["sesionusuario"] = getData["Apellido"].ToString().Trim() +", "+ getData["Nombre"].ToString().Trim() ;
                    Session["sessioncargo"] = getData["Cargos"].ToString().Trim();

                    string cargo = Session["sessioncargo"] as string;

                    if (cargo == "administrador")
                    {
                        Response.Redirect("/dashboard/admin");
                    }
                    else if (cargo == "user")
                    {
                        Response.Redirect("/tecnico/index");
                    }
                    else if (cargo == "doctor")
                    {
                        Response.Redirect("/medico/index");
                    }
                }
            }
            cone.Close();
        }
    }
}