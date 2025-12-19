using System;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_ComercioRudo_CandelaP
{
    public partial class Proveedores : System.Web.UI.Page
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
            {
                cargarGrilla();
                cargarCombos();
            }
        }

        private void cargarGrilla()
        {
            NegocioProveedor negocio = new NegocioProveedor();
            dgvProveedores.DataSource = negocio.listar();
            dgvProveedores.DataBind();
        }

        private void cargarCombos()
        {
            NegocioMarca negocioMarca = new NegocioMarca();
            ddlMarca.DataSource = negocioMarca.listar();
            ddlMarca.DataTextField = "nombre";
            ddlMarca.DataValueField = "id";
            ddlMarca.DataBind();

            NegocioCategoria negocioCategoria = new NegocioCategoria();
            ddlCategoria.DataSource = negocioCategoria.listar();
            ddlCategoria.DataTextField = "nombre";
            ddlCategoria.DataValueField = "id";
            ddlCategoria.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
            pnlFormulario.Visible = true;
        }

        protected void dgvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(dgvProveedores.DataKeys[index].Value);

            NegocioProveedor negocio = new NegocioProveedor();

            if (e.CommandName == "Eliminar")
            {
                negocio.eliminar(id);
                mostrarExito("Proveedor eliminado correctamente");
                cargarGrilla();
            }

            if (e.CommandName == "Editar")
            {
                Proveedor p = negocio.obtenerPorId(id);

                hfIdProveedor.Value = p.id.ToString();
                txtNombre.Text = p.nombre;
                ddlMarca.SelectedValue = p.marca.id.ToString();
                ddlCategoria.SelectedValue = p.categoria.id.ToString();

                pnlFormulario.Visible = true;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                mostrarError("El nombre del proveedor no puede estar vacio");
                return;
            }

            if (ddlMarca.SelectedValue == "0")
            {
                mostrarError("Seleccione una marca");
                return;
            }

            if (ddlCategoria.SelectedValue == "0")
            {
                mostrarError("Seleccione una categoria");
                return;
            }

            Proveedor proveedor = new Proveedor();
            NegocioProveedor negocio = new NegocioProveedor();

            proveedor.nombre = txtNombre.Text;
            proveedor.marca = new Marca { id = int.Parse(ddlMarca.SelectedValue) };
            proveedor.categoria = new Categoria { id = int.Parse(ddlCategoria.SelectedValue) };

            if (string.IsNullOrEmpty(hfIdProveedor.Value))
            {
                negocio.agregar(proveedor);
                mostrarExito("Proveedor agregado correctamente");
            }
            else
            {
                proveedor.id = int.Parse(hfIdProveedor.Value);
                negocio.modificar(proveedor);
                mostrarExito("Proveedor modificado correctamente");
            }
            pnlFormulario.Visible = false;
            cargarGrilla();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlFormulario.Visible = false;
        }

        private void limpiarFormulario()
        {
            hfIdProveedor.Value = "";
            txtNombre.Text = "";
            ddlMarca.SelectedIndex = 0;
            ddlCategoria.SelectedIndex = 0;
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelAdmin.aspx");
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
