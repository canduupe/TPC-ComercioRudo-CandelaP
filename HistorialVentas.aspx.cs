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
    public partial class HistorialVentas : System.Web.UI.Page
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
            if (!IsPostBack)
                cargarGrilla();
        }
        private void cargarGrilla()
        {
            NegocioVenta negocio = new NegocioVenta();
            dgvVentas.DataSource = negocio.listar();
            dgvVentas.DataBind();
        }

        private List<DetalleVenta> DetallesVenta
        {
            get
            {
                if (Session["DetallesVenta"] == null)
                    Session["DetallesVenta"] = new List<DetalleVenta>();

                return (List<DetalleVenta>)Session["DetallesVenta"];
            }
        }
        protected void dgvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalle")
            {
                NegocioVenta negocio = new NegocioVenta();
                int index = Convert.ToInt32(e.CommandArgument);
                int idVenta = Convert.ToInt32(dgvVentas.DataKeys[index].Value);

                dgvDetalleVenta.DataSource = new NegocioVenta().listarDetalle(idVenta);
                dgvDetalleVenta.DataBind();

                pnlDetalleVenta.Visible = true;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelAdmin.aspx");
        }
    }
}