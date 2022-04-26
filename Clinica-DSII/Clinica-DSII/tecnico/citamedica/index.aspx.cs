using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Clinica_DSII.Dao;

namespace Clinica_DSII.tecnico.citamedica
{
    public partial class index : System.Web.UI.Page
    {
        DaoCitaMedica dao = new DaoCitaMedica();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ds = dao.listar();
                grdCMedica.DataSource = ds;
                grdCMedica.DataBind();
            }
        }
    }
}