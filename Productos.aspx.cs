using Dominio;
using Negocio;
using System;
using System.Web.UI.WebControls;

namespace TPC_ComercioRudo_CandelaP
{
    public partial class Productos : System.Web.UI.Page
    {
        NegocioProducto negocio = new NegocioProducto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Usuario"] != null)
                {
                    string user = Request.QueryString["Usuario"].ToString();
                    lblCliente.Text = "Bienvenido/a " + user;
                }
                else
                {
                    lblCliente.Text = "No se reconoció el cliente";
                }

                cargarGrilla();
            }
        }

        private void cargarGrilla()
        {
            dgvProductos.DataSource = negocio.listar();
            dgvProductos.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
            pnlFormulario.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto();

            p.nombre = txtNombre.Text;
            p.descripcion = txtDescripcion.Text;
            p.precio = decimal.Parse(txtPrecio.Text);
            p.stockActual = int.Parse(txtStockActual.Text);
            p.stockMinimo = int.Parse(txtStockMinimo.Text);
            p.marca = int.Parse(txtMarca.Text);
            p.categoria = int.Parse(txtCategoria.Text);
            p.proveedor = 1;
            p.activo = 1;

            if (string.IsNullOrEmpty(hfIdProducto.Value))
            {
                negocio.agregar(p);
            }
            else
            {
                p.id = int.Parse(hfIdProducto.Value);
                negocio.modificar(p);
            }

            pnlFormulario.Visible = false;
            cargarGrilla();
        }

        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(dgvProductos.DataKeys[index].Value);
           
            if (e.CommandName == "Eliminar")
            {
                negocio.eliminar(id);
            }

            else if (e.CommandName == "Editar")
            {
                Producto p = negocio.listar().Find(x => x.id == id);

                hfIdProducto.Value = p.id.ToString();
                txtNombre.Text = p.nombre;
                txtPrecio.Text = p.precio.ToString();
                txtStockActual.Text = p.stockActual.ToString();
                txtStockMinimo.Text = p.stockMinimo.ToString();

                pnlFormulario.Visible = true;
            }
            cargarGrilla();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlFormulario.Visible = false;
            limpiarFormulario();
        }

        private void limpiarFormulario()
        {
            hfIdProducto.Value = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStockActual.Text = "";
            txtStockMinimo.Text = "";
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelAdmin.aspx");
        }
    }
}
