using Dominio;
using Negocio;
using System;
using System.Web.UI.WebControls;

namespace TPC_ComercioRudo_CandelaP
{
    public partial class Marcas : System.Web.UI.Page
    {
        NegocioMarca negocio = new NegocioMarca();

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
            dgvMarcas.DataSource = negocio.listar();
            dgvMarcas.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            hfIdMarca.Value = "";
            txtNombre.Text = "";
            pnlFormulario.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                mostrarError("El nombre no puede estar vacío");
                return;
            }

            Marca marca = new Marca();
            marca.nombre = txtNombre.Text;
            try
            {
                if (string.IsNullOrEmpty(hfIdMarca.Value))
                {
                    negocio.agregar(marca);
                    mostrarExito("Marca agregada correctamente");
                }
                else
                {
                    marca.id = int.Parse(hfIdMarca.Value);
                    negocio.modificar(marca);
                    mostrarExito("Marca modificada correctamente");
                }

            pnlFormulario.Visible = false;
            cargarGrilla();
        }
              catch (Exception ex)
            {
                mostrarError("Ocurrió un error: " + ex.Message);
    }
}

protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlFormulario.Visible = false;
        }

        protected void dgvMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(dgvMarcas.DataKeys[index].Value);

            if (e.CommandName == "Editar")
            {
                Marca seleccionada = negocio.listar().Find(x => x.id == id);

                hfIdMarca.Value = seleccionada.id.ToString();
                txtNombre.Text = seleccionada.nombre;
                pnlFormulario.Visible = true;
            }

            if (e.CommandName == "Eliminar")
            {
                negocio.eliminar(id);
                mostrarExito("Marca eliminada correctamente");
                cargarGrilla();
            }
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
