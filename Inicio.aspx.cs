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
                NegocioUsuario negocio = new NegocioUsuario();

                Usuario usuario = negocio.login(txtUsuario.Text, txtContrasena.Text);

                if (usuario != null)
                {
                    Session["Usuario"] = usuario.usuario;
                    Session["TipoUsuario"] = usuario.idTipoUsuario;

                    if (usuario.idTipoUsuario == 1)
                    {
                        Response.Redirect("PanelAdmin.aspx");
                    }
                    else if (usuario.idTipoUsuario == 2)
                    {
                        Response.Redirect("PanelVendedor.aspx");
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
