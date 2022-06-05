using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clinica_DSII.Dao;
using Clinica_DSII.Entidades;
using Clinica_DSII.ViewClass;
using System.Web.Services;

namespace Clinica_DSII.dashboard.consultas
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<ViewConsultas> getConsultas()
        {
            DaoConsulta dao = new DaoConsulta();
            return dao.getConsultas();
        }

        [WebMethod]
        public static List<Horario> getHorarios()
        {
            DaoHorario dao = new DaoHorario();
            return dao.listar();
        }

        [WebMethod]
        public static List<ViewMedico> getMedicos()
        {
            DaoConsulta dao = new DaoConsulta();
            return dao.getMedicos();
        }

        [WebMethod]
        public static Especialidad getMedicoEsp(string idmedico)
        {
            DaoConsulta dao = new DaoConsulta();
            int idmed = int.Parse(idmedico);
            return dao.getMedEsp(idmed);
        }

        [WebMethod]
        public static int save(string idmed, string idesp , string idhor, string precio) {
            DaoConsulta dao = new DaoConsulta();
            Consulta cons = new Consulta();
            cons.idmedico = int.Parse(idmed);
            cons.especialidad = int.Parse(idesp);
            cons.horario = int.Parse(idhor);
            cons.precio = double.Parse(precio);

            return dao.save(cons);
        }
    }
}