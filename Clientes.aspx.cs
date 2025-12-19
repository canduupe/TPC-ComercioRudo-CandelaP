using Dominio;
using Negocio;
using System;
using System.Web.UI.WebControls;

namespace TPC_ComercioRudo_CandelaP
{
    public partial class Clientes : System.Web.UI.Page
    {
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
                configurarVistaPorRol();
            }
        }

        private void cargarGrilla()
        {
            NegocioCliente negocio = new NegocioCliente();
            dgvClientes.DataSource = negocio.listar();
            dgvClientes.DataBind();
        }

        private void configurarVistaPorRol()
        {
            Usuario usuario = (Usuario)Session["Usuario"];

            if (usuario.idTipoUsuario == 2)
            {
                btnNuevo.Visible = false;

                dgvClientes.Columns[6].Visible = false; 
                dgvClientes.Columns[7].Visible = false; 

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

        protected void dgvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(dgvClientes.DataKeys[index].Value);

            NegocioCliente negocio = new NegocioCliente();

            if (e.CommandName == "Eliminar")
            {
                negocio.eliminar(id);
                mostrarExito("Cliente eliminado correctamente");
                cargarGrilla();
            }

            if (e.CommandName == "Editar")
            {
                Cliente c = negocio.obtenerPorID(id);

                hfIdCliente.Value = c.id.ToString();
                txtNombre.Text = c.nombre;
                txtApellido.Text = c.apellido;
                txtDNI.Text = c.DNI;
                txtTelefono.Text = c.telefono;
                txtEmail.Text = c.email;
                txtDireccion.Text = c.direccion;

                pnlFormulario.Visible = true;
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {       
            Cliente cliente = new Cliente();
            NegocioCliente negocio = new NegocioCliente();

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                mostrarError("El nombre es obligatorio");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                mostrarError("El apellido es obligatorio");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                mostrarError("El DNI es obligatorio");
                return;
            }

            if (!long.TryParse(txtDNI.Text, out _))
            {
                mostrarError("El DNI debe ser numerico");
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                if (!long.TryParse(txtTelefono.Text, out _))
                {
                    mostrarError("El telefono debe contener solo numeros");
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                try
                {
                    var email = new System.Net.Mail.MailAddress(txtEmail.Text);
                }
                catch
                {
                    mostrarError("El email no tiene un formato valido");
                    return;
                }
            }

            cliente.nombre = txtNombre.Text;
            cliente.apellido = txtApellido.Text;
            cliente.DNI = txtDNI.Text;
            cliente.telefono = txtTelefono.Text;
            cliente.email = txtEmail.Text;
            cliente.direccion = txtDireccion.Text;

            if (string.IsNullOrEmpty(hfIdCliente.Value))
            {
                negocio.agregar(cliente);
                mostrarExito("Cliente agregado correctamente");
            }
            else
            {
                cliente.id = int.Parse(hfIdCliente.Value);
                negocio.modificar(cliente);
                mostrarExito("Cliente modificado correctamente");
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
            hfIdCliente.Value = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDNI.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtDireccion.Text = "";
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(ViewState["volver"].ToString());
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