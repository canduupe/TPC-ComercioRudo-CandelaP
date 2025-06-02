using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_ComercioRudo_CandelaP
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["Usuario"] != null)
            {
                string user = Request.QueryString["Usuario"].ToString();
                lblCliente.Text = "bienvenido/a " + user;
            }
            else
            {
                lblCliente.Text = "No se reconocio el cliente";
            }
        }
    }
}