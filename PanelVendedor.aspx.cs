using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_ComercioRudo_CandelaP
{
    public partial class PanelVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TipoUsuario"] == null)
            {
                Response.Redirect("Inicio.aspx");
                return;
            }

            if ((int)Session["TipoUsuario"] != 2)
            {
                Response.Redirect("Inicio.aspx");
                return;
            }
        }

        protected void btnVenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ventas.aspx");
        }


        protected void btnClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes.aspx");
        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }

        protected void btnMisVentas_Click(object sender, EventArgs e)
        {
            Response.Redirect("MisVentas.aspx");
        }

        protected void btnCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("Compras.aspx");
        }

        protected void btnMisCompras_Click(object sender, EventArgs e)
        {
            Response.Redirect("HistorialCompras.aspx");
        }
    }
}