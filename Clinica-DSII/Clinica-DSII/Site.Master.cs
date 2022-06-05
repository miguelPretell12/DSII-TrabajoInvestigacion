using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica_DSII
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cargo = Session["sessioncargo"] as string;

            if (cargo != null)
            {
                lnkAuth.Text = Session["sesionusuario"] + "<br/> Cargo: " + cargo;
            }else
            {
                lnkAuth.Text = "Login";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string cargo = Session["sessioncargo"] as string;
            if (cargo == "administrador")
            {
                Response.Redirect("/dashboard/admin");    
            }
            else if(cargo == "tecnico")
            {
                Response.Redirect("/tecnico/índex");
            }
            else if(cargo == "doctor")
            {
                Response.Redirect("/medico/índex");
            }
            else if(cargo == "paciente")
            {
                Response.Redirect("/paciente/index");
            }
            else
            {
                Response.Redirect("/login");
            }
        }

    }
}