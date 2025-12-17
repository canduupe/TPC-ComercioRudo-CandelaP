using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_ComercioRudo_CandelaP
{
    public partial class PanelAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TipoUsuario"] == null)
            {
                Response.Redirect("Inicio.aspx");
                return;
            }

            if ((int)Session["TipoUsuario"] != 1)
            {
                Response.Redirect("Inicio.aspx");
                return;
            }

        }
    }
}