using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clinica_DSII.Entidades;
using Clinica_DSII.Dao;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;

namespace Clinica_DSII.dashboard.usuarios
{
    public partial class index : System.Web.UI.Page
    {
        // Conexion a la BD - SQL Server
        private SqlConnection cone = new SqlConnection(@"Server=DESKTOP-AS63TOF\MSSQL; Database=clinicaDSII; Integrated Security=true");
        DataSet ds = new DataSet();
        DaoUsuario dao = new DaoUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sessioncargo = Session["sessioncargo"] as string;
                if (sessioncargo == null || sessioncargo != "administrador")
                {
                    Response.Redirect("/login");
                }
                
            }
        }

        [WebMethod]
        public static List<Usuario> listar()
        {
            DaoUsuario dao = new DaoUsuario();
            return dao.listarUsuario();
        }

        [WebMethod]
        public static Usuario status (string estado, string id)
        {
            DaoUsuario dao = new DaoUsuario();
            Usuario usu = new Usuario();
            usu.idusuarios = int.Parse(id);
            usu.estado = estado;
            Boolean resp = dao.updatestatus(usu);
            if(resp)
            {
                return usu;
            }else
            {
                return null;
            }
            
        }

        [WebMethod]
        public static List<Cargo> Cargos()
        {
            DaoUsuario dao = new DaoUsuario();
            return dao.Cargos();
        }

        [WebMethod]
        public static Usuario getUsuario(string id) {
            DaoUsuario dao = new DaoUsuario();
            int iduser = int.Parse(id);
            return dao.getUser(iduser);
        }

        [WebMethod]
        public static int insertar(string nombre, string apellido, string dni, string correo, string contrasenia, string cargos )
        {
            DaoUsuario dao = new DaoUsuario();
            Usuario usu = new Usuario();
            usu.nombre = nombre;
            usu.apellido = apellido;
            usu.dni = dni;
            usu.correo = correo;
            usu.contrasenia = contrasenia;
            usu.cargos = int.Parse(cargos);
            int response = dao.guardar(usu);
            return response;
        }

        [WebMethod]
        public static int actualizar(string nombre, string apellido, string dni, string correo, string contrasenia, string cargos, string idusuario) {
            DaoUsuario dao = new DaoUsuario();
            Usuario usu = new Usuario();
            usu.nombre = nombre;
            usu.apellido = apellido;
            usu.dni = dni;
            usu.correo = correo;
            usu.contrasenia = contrasenia;
            usu.cargos = int.Parse(cargos);
            usu.idusuarios = int.Parse(idusuario);
            int response = dao.actualizar(usu);
            return response;
        }

        [WebMethod]
        public static Usuario consultarEmail(string email)
        {
            DaoUsuario dao = new DaoUsuario();
            return dao.consultarEmail(email);
        }

        [WebMethod]
        public static int eliminar(string id) {
            DaoUsuario dao = new DaoUsuario();
            int iduser = int.Parse(id);
            return dao.eliminarUser(iduser);
        }
       
    }
}