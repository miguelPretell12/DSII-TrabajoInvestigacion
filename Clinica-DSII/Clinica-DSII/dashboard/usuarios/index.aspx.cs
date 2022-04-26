using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clinica_DSII.Entidades;
using Clinica_DSII.Dao;
using System.Data;

namespace Clinica_DSII.dashboard.usuarios
{
    public partial class index : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DaoUsuario dao = new DaoUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ds = dao.listar();
                grdUsuario.DataSource = ds;
                grdUsuario.DataBind();
            }
        }
    }
}