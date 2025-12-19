using Dominio;
using Negocio;
using System;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace TPC_ComercioRudo_CandelaP
{
    public partial class Compras : System.Web.UI.Page
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

            if (!IsPostBack)
                {
                cargarProveedores();
                ddlProducto.Items.Clear();
                ddlProducto.Items.Insert(0, new ListItem("Seleccione un proveedor", "0"));
                }
            }


        private void cargarProveedores()
        {
            NegocioProveedor negocio = new NegocioProveedor();

            ddlProveedor.DataSource = negocio.listar();
            ddlProveedor.DataTextField = "nombre";
            ddlProveedor.DataValueField = "id";
            ddlProveedor.DataBind();

            ddlProveedor.Items.Insert(0, new ListItem("Seleccione proveedor", "0"));
        }

        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProveedor = int.Parse(ddlProveedor.SelectedValue);

            if (idProveedor > 0)
            {
                NegocioProducto negocio = new NegocioProducto();

                ddlProducto.DataSource = negocio.listarPorProveedor(idProveedor);
                ddlProducto.DataTextField = "nombre";
                ddlProducto.DataValueField = "id";
                ddlProducto.DataBind();

                ddlProducto.Items.Insert(0, new ListItem("Seleccione producto", "0"));
            }
            else
            {
                ddlProducto.Items.Clear();
                ddlProducto.Items.Insert(0, new ListItem("Seleccione un proveedor", "0"));
            }
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ddlProveedor.SelectedValue == "0")
            {
                mostrarError("Seleccione un proveedor");
                return;
            }

            if (ddlProducto.SelectedValue == "0")
            {
                mostrarError("Seleccione un producto");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                mostrarError("Ingrese la cantidad");
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad < 0)
            {
                mostrarError("La cantidad debe ser un numero mayor a cero");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                mostrarError("Ingrese el precio del producto");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
            {
                mostrarError("El precio debe ser un numero mayor a cero");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtGanancia.Text))
            {
                mostrarError("Ingrese la ganancia");
                return;
            }

            if (!decimal.TryParse(txtGanancia.Text, out decimal ganancia) || ganancia < 0)
            {
                mostrarError("La ganancia debe ser un numero positivo");
                return;
            }

            Compra c = new Compra();

            c.proveedor = new Proveedor();
            c.proveedor.id = int.Parse(ddlProveedor.SelectedValue);

            c.vendedor = new Vendedor();
            c.vendedor.id = (int)Session["IdVendedor"];

            c.producto = new Producto();
            c.producto.id = int.Parse(ddlProducto.SelectedValue);

            c.cantidad = int.Parse(txtCantidad.Text);

            c.ganancia = decimal.Parse(txtGanancia.Text);

            c.precio = decimal.Parse(txtPrecio.Text);

            NegocioCompra negocio = new NegocioCompra();
            negocio.agregar(c);
            mostrarExito("Compra registrada correctamente.");

            limpiarFormulario();
        }

        private void limpiarFormulario()
        {        
            ddlProveedor.SelectedIndex = 0;
            ddlProducto.SelectedIndex = 0;
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtGanancia.Text = "";
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelVendedor.aspx");
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