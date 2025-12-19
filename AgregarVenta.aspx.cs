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
    public partial class AgregarVenta : System.Web.UI.Page
    {
        private List<DetalleVenta> DetallesVenta
        {
            get
            {
                if (Session["DetallesVenta"] == null)
                    Session["DetallesVenta"] = new List<DetalleVenta>();

                return (List<DetalleVenta>)Session["DetallesVenta"];
            }
            set
            {
                Session["DetallesVenta"] = value;
            }
        }
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

            if (!IsPostBack)
            {
                cargarVentas();
                cargarClientes();
                cargarProductos();
            }
        }

        private void cargarVentas()
        {
            NegocioVenta negocio = new NegocioVenta();
            dgvVentas.DataSource = negocio.listar();
            dgvVentas.DataBind();
        }

        private void cargarClientes()
        {
            NegocioCliente negocio = new NegocioCliente();
            ddlClientes.DataSource = negocio.listar();
            ddlClientes.DataTextField = "apellido";
            ddlClientes.DataValueField = "id";
            ddlClientes.DataBind();
        }

        private void cargarProductos()
        {
            NegocioProducto negocio = new NegocioProducto();
            ddlProductos.DataSource = negocio.listar();
            ddlProductos.DataTextField = "nombre";
            ddlProductos.DataValueField = "id";
            ddlProductos.DataBind();
        }

        protected void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            pnlVenta.Visible = true;
            DetallesVenta = new List<DetalleVenta>();
            dgvDetalle.DataSource = null;
            dgvDetalle.DataBind();
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            int idProducto = int.Parse(ddlProductos.SelectedValue);
            int cantidad = int.Parse(txtCantidad.Text);

            NegocioProducto negocioProducto = new NegocioProducto();
            Producto producto = negocioProducto.obtenerPorId(idProducto);

            DetalleVenta detalle = new DetalleVenta
            {
                producto = producto,
                cantidad = cantidad,
                precioUnitario = producto.precio,
                subtotal = cantidad * producto.precio
            };

            DetallesVenta.Add(detalle);

            dgvDetalle.DataSource = DetallesVenta;
            dgvDetalle.DataBind();

            txtCantidad.Text = "";
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            foreach (var det in DetallesVenta)
            {
                total += det.subtotal;
            }

            Venta venta = new Venta();
            venta.cliente = new Cliente();
            venta.cliente.id = int.Parse(ddlClientes.SelectedValue);

            venta.vendedor = new Vendedor();
            venta.vendedor.id = (int)Session["IdVendedor"];

            venta.Detalles = DetallesVenta;
            venta.total = total;

            NegocioVenta negocioVenta = new NegocioVenta();
            negocioVenta.RegistrarVenta(venta);

            pnlVenta.Visible = false;
            Session.Remove("DetallesVenta");

            cargarVentas();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlVenta.Visible = false;
            DetallesVenta = null;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelVendedor.aspx");
        }
    }
}