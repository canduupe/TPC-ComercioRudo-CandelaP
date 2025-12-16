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
    public partial class Categorias : System.Web.UI.Page
    {
        NegocioCategoria negocio = new NegocioCategoria();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                cargarGrilla();
        }

        private void cargarGrilla()
        {
            dgvCategoria.DataSource = negocio.listar();
            dgvCategoria.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            hfIdCategoria.Value = "";
            txtNombre.Text = "";
            pnlFormulario.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Categoria cate = new Categoria();
            cate.nombre = txtNombre.Text;

            if (hfIdCategoria.Value == "")
            {
                negocio.agregar(cate);
            }
            else
            {
                cate.id = int.Parse(hfIdCategoria.Value);
                negocio.modificar(cate);
            }

            pnlFormulario.Visible = false;
            cargarGrilla();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlFormulario.Visible = false;
        }

        protected void dgvCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(dgvCategoria.DataKeys[index].Value);

            if (e.CommandName == "Editar")
            {
                Marca seleccionada = negocio.listar().Find(x => x.id == id);

                hfIdCategoria.Value = seleccionada.id.ToString();
                txtNombre.Text = seleccionada.nombre;
                pnlFormulario.Visible = true;
            }

            if (e.CommandName == "Eliminar")
            {
                negocio.eliminar(id);
                cargarGrilla();
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelAdmin.aspx");
        }
    }
}
