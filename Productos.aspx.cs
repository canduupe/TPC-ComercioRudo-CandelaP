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
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Inicio.aspx");
                return;
            }

            if (!IsPostBack)
            {
                cargarGrilla();
                cargarProveedores();
                cargarMarcas();
                cargarCategorias();
                configurarVistaPorRol();
            }
        }

        private void cargarGrilla()
        {
            dgvProductos.DataSource = negocio.listar();
            dgvProductos.DataBind();
        }

        private void cargarProveedores()
        {
            NegocioProveedor negocio = new NegocioProveedor();

            ddlProveedor.DataSource = negocio.listar();
            ddlProveedor.DataValueField = "id";
            ddlProveedor.DataTextField = "nombre";
            ddlProveedor.DataBind();

            ddlProveedor.Items.Insert(0, new ListItem("Seleccione un proveedor", "0"));
        }

        private void cargarMarcas()
        {
            NegocioMarca negocio = new NegocioMarca();

            ddlMarca.DataSource = negocio.listar();
            ddlMarca.DataValueField = "id";   
            ddlMarca.DataTextField = "nombre"; 
            ddlMarca.DataBind();

            ddlMarca.Items.Insert(0, new ListItem("Seleccione una marca", "0"));
        }

        private void cargarCategorias()
        {
            NegocioCategoria negocio = new NegocioCategoria();

            ddlCategoria.DataSource = negocio.listar();
            ddlCategoria.DataValueField = "id";
            ddlCategoria.DataTextField = "nombre";
            ddlCategoria.DataBind();

            ddlCategoria.Items.Insert(0, new ListItem("Seleccione una categoria", "0"));
        }


        private void configurarVistaPorRol()
        {
            Usuario usuario = (Usuario)Session["Usuario"];

            if (usuario.idTipoUsuario == 2)
            {      
                ViewState["volver"] = "PanelVendedor.aspx";
            }
            else
            {
                ViewState["volver"] = "PanelAdmin.aspx";
            }
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

            p.proveedor = new Proveedor();
            p.proveedor.id = int.Parse(ddlProveedor.SelectedValue);

            p.marca = new Marca();
            p.marca.id = int.Parse(ddlMarca.SelectedValue);

            p.categoria = new Categoria();
            p.categoria.id = int.Parse(ddlCategoria.SelectedValue);
        
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
                txtDescripcion.Text = p.descripcion.ToString();
                ddlProveedor.SelectedValue = p.proveedor.id.ToString();
                ddlMarca.SelectedValue = p.marca.id.ToString();
                ddlCategoria.SelectedValue = p.categoria.id.ToString();
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
            txtDescripcion.Text = "";
            ddlProveedor.SelectedIndex = 0;
            ddlMarca.SelectedIndex = 0;
            ddlCategoria.SelectedIndex = 0;
            txtPrecio.Text = "";
            txtStockActual.Text = "";
            txtStockMinimo.Text = "";
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(ViewState["volver"].ToString());
        }
    }
}
