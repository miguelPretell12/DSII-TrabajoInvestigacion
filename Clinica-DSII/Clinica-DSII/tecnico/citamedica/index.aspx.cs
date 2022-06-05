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

namespace Clinica_DSII.tecnico.citamedica
{
    public partial class index : System.Web.UI.Page
    {
        private SqlConnection cone = new SqlConnection(@"Server=DESKTOP-AS63TOF\MSSQL; Database=clinicaDSII; Integrated Security=true");
        DaoCitaMedica dao = new DaoCitaMedica();
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
                grdCMedica.DataSource = ds;
                grdCMedica.DataBind();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = dao.consultarxpaciente(txtParam.Text);
            grdCMedica.DataSource = ds;
            grdCMedica.DataBind();
        }

        protected void btnRestaurar_Click(object sender, EventArgs e)
        {
            txtParam.Text = "";
            txtParamIni.Text = "";
            txtParamFi.Text = "";
            ds = dao.listar();
            grdCMedica.DataSource = ds;
            grdCMedica.DataBind();
        }

        protected void btnConsultarF_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = dao.consultarxfecha(DateTime.Parse(txtParamIni.Text),DateTime.Parse(txtParamFi.Text));
            grdCMedica.DataSource = ds;
            grdCMedica.DataBind();
        }

        protected void grdCMedica_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Borrar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdCMedica.Rows[indice];
                int id = int.Parse(row.Cells[1].Text);
                dao.eliminar(id);
                ds = dao.listar();
                grdCMedica.DataSource = ds;
                grdCMedica.DataBind();
            }
            else if (e.CommandName == "Editar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grdCMedica.Rows[indice];

                int idcitamedica = int.Parse(row.Cells[1].Text);
                Session["idcitamedica"] = idcitamedica;
                Response.Redirect("/tecnico/citamedica/update.aspx");
            }
        }
    }
}