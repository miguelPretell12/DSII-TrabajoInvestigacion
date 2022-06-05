using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica_DSII.paciente
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sessioncargo = Session["sessioncargo"] as string;
            if (sessioncargo == null || sessioncargo != "paciente")
            {
                Response.Redirect("/login");
            }
            lblScargo.Text = Session["sessioncargo"] as string;
            lblSNombre.Text = Session["sesionusuario"] as string;
        }

        protected void btnCerrrar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("/login");
        }
    }
}