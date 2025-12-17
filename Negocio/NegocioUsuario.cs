using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
        public class NegocioUsuario
        {
            public Usuario login(string usuario, string contraseña)
            {
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setearConsulta("SELECT U.Id, U.Usuario, U.IdTipoUsuario " +
                                         "FROM Usuarios U " +
                                         "WHERE U.Usuario = @usuario AND U.Contraseña = @pass AND U.Activo = 1");

                    datos.setearParametro("@usuario", usuario);
                    datos.setearParametro("@pass", contraseña);

                    datos.realizarLectura();

                    if (datos.Lector.Read())
                    {
                        Usuario u = new Usuario();
                        u.id = (int)datos.Lector["Id"];
                        u.usuario = datos.Lector["Usuario"].ToString();
                        u.idTipoUsuario = (int)datos.Lector["IdTipoUsuario"];
                        return u;
                    }

                    return null;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }
        }

    }

