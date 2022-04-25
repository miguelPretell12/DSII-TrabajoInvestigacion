using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clinica_DSII.dashboard
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblScargo.Text = Session["sessioncargo"] as string;
            lblSNombre.Text = Session["sesionusuario"] as string;
        }
    }
}