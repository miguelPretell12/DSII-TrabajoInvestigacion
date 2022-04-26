using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clinica_DSII.Dao;
using System.Data;


namespace Clinica_DSII.tecnico.paciente
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DaoPaciente dao = new DaoPaciente();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string sessioncargo = Session["sessioncargo"] as string;
                if (sessioncargo == null || sessioncargo != "tecnico")
                {
                    Response.Redirect("/login");
                }
                ds = dao.listar();
                grdPaciente.DataSource = ds;
                grdPaciente.DataBind();
            }
        }

        protected void grdPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}