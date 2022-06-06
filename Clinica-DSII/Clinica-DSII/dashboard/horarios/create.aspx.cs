using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clinica_DSII.Dao;
using Clinica_DSII.Entidades;

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
                listar();
            }
        }

        public void listar()
        {
            ds = dao.listar();
            grdHorario.DataSource = ds;
            grdHorario.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
        }
    }
}