using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPC_ComercioRudo_CandelaP
{
    public partial class Inicio : System.Web.UI.Page
    {
            protected void Page_Load(object sender, EventArgs e)
            {
            }
            protected void btnIniciar_Click(object sender, EventArgs e)
        {
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            Usuario usuario = negocioUsuario.login(txtUsuario.Text, txtContrasena.Text);

            if (usuario != null)
            {
                Session["Usuario"] = usuario;
                Session["TipoUsuario"] = usuario.idTipoUsuario;

                if (usuario.idTipoUsuario == 1)
                {
                    Response.Redirect("PanelAdmin.aspx");
                }
                else
                {
                    NegocioVendedor negocioVendedor = new NegocioVendedor();
                    Vendedor vendedor = negocioVendedor.obtenerPorUsuario(usuario.id);

                    if (vendedor != null)
                    {
                        Session["IdVendedor"] = vendedor.id;
                        Response.Redirect("PanelVendedor.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(
                            this.GetType(),
                            "alert",
                            "alert('El usuario no tiene vendedor asociado');",
                            true
                        );
                    }
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(
                    this.GetType(),
                    "alert",
                    "alert('Usuario o contraseña incorrectos');",
                    true
                );
            }
        }

    }
}

