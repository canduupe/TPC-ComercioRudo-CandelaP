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
            Marca marca = new Marca();
            marca.nombre = txtNombre.Text;

            if (hfIdMarca.Value == "")
            {
                negocio.agregar(marca);
            }
            else
            {
                marca.id = int.Parse(hfIdMarca.Value);
                negocio.modificar(marca);
            }

            pnlFormulario.Visible = false;
            cargarGrilla();
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
                cargarGrilla();
            }
        }
    }
}
