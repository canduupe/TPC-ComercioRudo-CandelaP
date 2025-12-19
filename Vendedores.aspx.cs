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
    public partial class Vendedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TipoUsuario"] == null || (int)Session["TipoUsuario"] != 1)
            {
                Response.Redirect("Inicio.aspx");
                return;
            }

            if (!IsPostBack)
            {
                cargarGrilla();
                pnlVendedor.Visible = false;
            }
        }

        private void cargarGrilla()
        {
            NegocioVendedor negocio = new NegocioVendedor();
            dgvVendedores.DataSource = negocio.listar();
            dgvVendedores.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
            pnlVendedor.Visible = true;
            dgvVendedores.Visible = false;
        }

        protected void dgvVendedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Editar" && e.CommandName != "Eliminar")
                return;

            int index = Convert.ToInt32(e.CommandArgument);
            int idVendedor = Convert.ToInt32(dgvVendedores.DataKeys[index].Value);

            NegocioVendedor negocio = new NegocioVendedor();
            Vendedor v = negocio.listar().Find(x => x.id == idVendedor);

            if (e.CommandName == "Editar")
            { 

                hfIdVendedor.Value = v.id.ToString();
                hfIdUsuario.Value = v.usuario.id.ToString();

                txtNombre.Text = v.nombre;
                txtApellido.Text = v.apellido;
                txtUsuario.Text = v.usuario.usuario;
                txtContraseña.Text = v.usuario.contraseña;

                pnlVendedor.Visible = true;
                dgvVendedores.Visible = false;

            }

            if (e.CommandName == "Eliminar")
            {
                negocio.bajaLogica(idVendedor, v.usuario.id);
                cargarGrilla();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            NegocioVendedor negocio = new NegocioVendedor();

            Vendedor vendedor = new Vendedor();
            vendedor.nombre = txtNombre.Text;
            vendedor.apellido = txtApellido.Text;

            vendedor.usuario = new Usuario();
            vendedor.usuario.usuario = txtUsuario.Text;
            vendedor.usuario.contraseña = txtContraseña.Text;
            vendedor.usuario.idTipoUsuario = 2; 
            vendedor.activo = 1;

            if (!string.IsNullOrEmpty(hfIdVendedor.Value))
            {
                vendedor.id = int.Parse(hfIdVendedor.Value);
                vendedor.usuario.id = int.Parse(hfIdUsuario.Value);

                negocio.modificar(vendedor);
            }
            else
            {
                negocio.agregar(vendedor);
            }

            limpiarFormulario();
            pnlVendedor.Visible = false;
            dgvVendedores.Visible = true;
            cargarGrilla();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
            pnlVendedor.Visible = false;
            dgvVendedores.Visible = true;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        private void limpiarFormulario()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";

            hfIdVendedor.Value = "";
            hfIdUsuario.Value = "";
        }
        protected void Volver_Click(object sender, EventArgs e)
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