using Dominio;
using Negocio;
using System;
using System.Web.UI.WebControls;

namespace TPC_ComercioRudo_CandelaP
{
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarProveedores();
                cargarProductos();
            }
        }

        private void cargarProveedores()
        {
            ddlProveedor.DataSource = new NegocioProveedor().listar();
            ddlProveedor.DataValueField = "id";
            ddlProveedor.DataTextField = "nombre";
            ddlProveedor.DataBind();
            ddlProveedor.Items.Insert(0, new ListItem("Seleccione un proveedor", "0"));
        }


        private void cargarProductos()
        {
            ddlProducto.DataSource = new NegocioProducto().listar();
            ddlProducto.DataValueField = "id";
            ddlProducto.DataTextField = "nombre";
            ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, new ListItem("Seleccione un producto", "0"));
        }

        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProducto = int.Parse(ddlProducto.SelectedValue);
            Producto p = new NegocioProducto().listar().Find(x => x.id == idProducto);

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Compra c = new Compra();

            c.proveedor = new Proveedor();
            c.proveedor.id = int.Parse(ddlProveedor.SelectedValue);

            c.producto = new Producto();
            c.producto.id = int.Parse(ddlProducto.SelectedValue);

            c.cantidad = int.Parse(txtCantidad.Text);

            c.ganancia = decimal.Parse(txtGanancia.Text);

            c.precio = decimal.Parse(txtPrecio.Text);

            NegocioCompra negocio = new NegocioCompra();
            negocio.agregar(c);

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

    }
}