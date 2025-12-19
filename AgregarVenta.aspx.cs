using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_ComercioRudo_CandelaP
{
    public partial class AgregarVenta : Page
    {
        private List<DetalleVenta> DetallesVenta
        {
            get
            {
                if (Session["DetallesVenta"] == null)
                    Session["DetallesVenta"] = new List<DetalleVenta>();

                return (List<DetalleVenta>)Session["DetallesVenta"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TipoUsuario"] == null || (int)Session["TipoUsuario"] != 2)
            {
                Response.Redirect("Inicio.aspx");
                return;
            }

            if (!IsPostBack)
            {
                cargarVentas();
                cargarClientes();
                cargarProductos();
                ocultarPaneles();
            }
        }

        private void ocultarPaneles()
        {
            pnlVenta.Visible = false;
            pnlDetalleVenta.Visible = false;
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
            ddlClientes.DataTextField = "dni";
            ddlClientes.DataValueField = "id";
            ddlClientes.DataBind();
            ddlClientes.Items.Insert(0, new ListItem("Seleccione un cliente", "0"));
        }

        private void cargarProductos()
        {
            NegocioProducto negocio = new NegocioProducto();
            ddlProductos.DataSource = negocio.listar();
            ddlProductos.DataTextField = "nombre";
            ddlProductos.DataValueField = "id";
            ddlProductos.DataBind();
            ddlProductos.Items.Insert(0, new ListItem("Seleccione un producto", "0"));
        }

        protected void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            ocultarPaneles();
            pnlVenta.Visible = true;

            Session.Remove("DetallesVenta");
            dgvDetalle.DataSource = null;
            dgvDetalle.DataBind();

            limpiarFormulario();
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            dgvDetalle.DataSource = DetallesVenta;
            dgvDetalle.DataBind();
            limpiarFormulario();

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                mostrarError("Ingrese una cantidad válida.");
                return;
            }

            int idProducto = int.Parse(ddlProductos.SelectedValue);
            Producto producto = new NegocioProducto().obtenerPorId(idProducto);

            if (producto == null)
            {
                mostrarError("Producto no encontrado.");
                return;
            }

            if (producto.stockActual < cantidad)
            {
                mostrarError("Stock insuficiente.");
                return;
            }

            DetallesVenta.Add(new DetalleVenta
            {
                producto = producto,
                cantidad = cantidad,
                precioUnitario = producto.precio,
                subtotal = cantidad * producto.precio
            });

            dgvDetalle.DataSource = DetallesVenta;
            dgvDetalle.DataBind();

            txtCantidad.Text = "";
            ddlProductos.SelectedIndex = 0;
            mostrarExito("Producto agregado.");
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ddlClientes.SelectedValue == "0" || DetallesVenta.Count == 0 || Session["IdVendedor"] == null)
                return;

            decimal total = 0;
            foreach (var d in DetallesVenta)
                total += d.subtotal;

            Venta venta = new Venta
            {
                cliente = new Cliente { id = int.Parse(ddlClientes.SelectedValue) },
                vendedor = new Vendedor { id = (int)Session["IdVendedor"] },
                Detalles = DetallesVenta,
                total = total
            };

            new NegocioVenta().RegistrarVenta(venta);

            Session.Remove("DetallesVenta");
            ocultarPaneles();
            cargarVentas();
        }

        protected void dgvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalle")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idVenta = Convert.ToInt32(dgvVentas.DataKeys[index].Value);
                mostrarDetalleVenta(idVenta);
            }
        }

        private void mostrarDetalleVenta(int idVenta)
        {
            ocultarPaneles();

            dgvDetalleVenta.DataSource = new NegocioVenta().listarDetalle(idVenta);
            dgvDetalleVenta.DataBind();

            pnlDetalleVenta.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ocultarPaneles();
            Session.Remove("DetallesVenta");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelVendedor.aspx");
        }

        private void limpiarFormulario()
        {
            txtCantidad.Text = "";
            ddlClientes.SelectedIndex = 0;
            ddlProductos.SelectedIndex = 0;
        }

        private void mostrarError(string mensaje)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.CssClass = "alert alert-danger";
            lblMensaje.Visible = true;
        }

        private void mostrarExito(string mensaje)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.CssClass = "alert alert-success";
            lblMensaje.Visible = true;
        }
    }
}