using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_ComercioRudo_CandelaP
{
    public partial class HistorialCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null || Session["IdVendedor"] == null)
            {
                Response.Redirect("Inicio.aspx");
                return;
            }

            if (!IsPostBack)
            {
                int idVendedor = Convert.ToInt32(Session["IdVendedor"]);

                NegocioCompra negocio = new NegocioCompra();
                dgvCompras.DataSource = negocio.listarPorVendedor(idVendedor);
                dgvCompras.DataBind();
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelVendedor.aspx");
        }
    }
}