using Dominio;
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
            if (Session["TipoUsuario"] == null)
            {
                Response.Redirect("Inicio.aspx");
                return;
            }

            if (!IsPostBack)
            {
                configurarVistaPorRol();
            }
        }

        private void configurarVistaPorRol()
        {
            Usuario usuario = (Usuario)Session["Usuario"];
            NegocioCompra negocio = new NegocioCompra();

            if (usuario.idTipoUsuario == 1)
            {
                dgvCompras.DataSource = negocio.listar();
                dgvCompras.DataBind();

                ViewState["volver"] = "PanelAdmin.aspx";
            }
            else
            {
                if (usuario.idTipoUsuario == 2)
                {
                    int idVendedor = Convert.ToInt32(Session["IdVendedor"]);

                dgvCompras.DataSource = negocio.listarPorVendedor(idVendedor);
                dgvCompras.DataBind();

                ViewState["volver"] = "PanelVendedor.aspx";
                }
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(ViewState["volver"].ToString());
        }

    }
}