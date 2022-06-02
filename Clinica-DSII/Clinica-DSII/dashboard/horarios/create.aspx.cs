using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clinica_DSII.Dao;
using Clinica_DSII.Entidades;
using System.Web.Services;

namespace Clinica_DSII.dashboard.horarios
{
    public partial class create : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DaoHorario dao = new DaoHorario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string sessioncargo = Session["sessioncargo"] as string;
                if (sessioncargo == null || sessioncargo != "administrador") {
                    Response.Redirect("/login");
                }
                //listar();
            }
        }

        [WebMethod]
        public static List<Horario> listar()
        {
            DaoHorario dao = new DaoHorario();
            return dao.listar();
        }
        [WebMethod]
        public static Horario obtenerHorario(string id) {
            int idhorario = int.Parse(id);
            DaoHorario dao = new DaoHorario();
            return dao.getHorario(idhorario);
        }

        [WebMethod]
        public static int filtroExist(string horainicio, string horafinal)
        {
            DaoHorario dao = new DaoHorario();
            return dao.filtro(horainicio, horafinal);
        }

        [WebMethod]
        public static int guardar(string horainicio, string horafinal)
        {
            
            Horario hor = new Horario();
            DaoHorario dao = new DaoHorario();
            hor.horainicio = TimeSpan.Parse(horainicio);
            hor.horafinal = TimeSpan.Parse(horafinal);

            return dao.guardar(hor);
        }

        [WebMethod]
        public static int actualizar(string horainicio, string horafinal, string idhorario) {
            Horario hor = new Horario();
            DaoHorario dao = new DaoHorario();
            hor.horainicio = TimeSpan.Parse(horainicio);
            hor.horafinal = TimeSpan.Parse(horafinal);
            hor.idhorario = int.Parse(idhorario);
            return dao.actualizar(hor);
        }

        [WebMethod]
        public static int eliminar(string idhorario)
        {
            Horario hor = new Horario();
            DaoHorario dao = new DaoHorario();
            hor.idhorario = int.Parse(idhorario);
            return dao.eliminar(hor);
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
        
        }
    }
}