using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioVendedor
    {
        public void agregar(Vendedor vendedor)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "INSERT INTO Usuarios (Usuario, Contraseña, IdTipoUsuario, Activo) " +
                    "VALUES (@Usuario, @Contraseña, @IdTipoUsuario, 1)"
                );

                datos.setearParametro("@Usuario", vendedor.usuario.usuario);
                datos.setearParametro("@Contraseña", vendedor.usuario.contraseña);
                datos.setearParametro("@IdTipoUsuario", vendedor.usuario.idTipoUsuario);

                datos.realizarAccion();

                datos.cerrarConexion();

                datos.setearConsulta("SELECT Id FROM Usuarios WHERE Usuario = @Usuario");
                datos.setearParametro("@Usuario", vendedor.usuario.usuario);

                datos.realizarLectura();

                int idUsuario = 0;
                if (datos.Lector.Read())
                    idUsuario = (int)datos.Lector["Id"];

                datos.cerrarConexion();

                datos.setearConsulta(
                    "INSERT INTO Vendedor (Nombre, Apellido, IdUsuario, Activo) " +
                    "VALUES (@Nombre, @Apellido, @IdUsuario, 1)"
                );

                datos.setearParametro("@Nombre", vendedor.nombre);
                datos.setearParametro("@Apellido", vendedor.apellido);
                datos.setearParametro("@IdUsuario", idUsuario);

                datos.realizarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Vendedor vendedor)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "UPDATE Vendedor SET " +
                    "Nombre = @Nombre, " +
                    "Apellido = @Apellido " +
                    "WHERE IdVendedor = @IdVendedor"
                );

                datos.setearParametro("@Nombre", vendedor.nombre);
                datos.setearParametro("@Apellido", vendedor.apellido);
                datos.setearParametro("@IdVendedor", vendedor.id);

                datos.realizarAccion();

                datos.setearConsulta(
                    "UPDATE Usuarios SET " +
                    "Usuario = @Usuario, " +
                    "Contraseña = @Contraseña, " +
                    "TipoUsuario = @TipoUsuario " +
                    "WHERE IdUsuario = @IdUsuario"
                );

                datos.setearParametro("@Usuario", vendedor.usuario.usuario);
                datos.setearParametro("@Contraseña", vendedor.usuario.contraseña);
                datos.setearParametro("@TipoUsuario", vendedor.usuario.idTipoUsuario);
                datos.setearParametro("@IdUsuario", vendedor.usuario.id);

                datos.realizarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void bajaLogica(int idVendedor, int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "UPDATE Vendedor SET Activo = 0 WHERE IdVendedor = @IdVendedor"
                );
                datos.setearParametro("@IdVendedor", idVendedor);
                datos.realizarAccion();

                datos.setearConsulta(
                    "UPDATE Usuarios SET Activo = 0 WHERE IdUsuario = @IdUsuario"
                );
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.realizarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Vendedor> listar()
        {
            List<Vendedor> lista = new List<Vendedor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT V.IdVendedor, V.Nombre, V.Apellido, V.Activo, " +
                    "U.Id, U.Usuario, U.Contraseña, U.IdTipoUsuario " +
                    "FROM Vendedor V " +
                    "INNER JOIN Usuarios U ON U.Id = V.IdUsuario " +
                    "WHERE V.Activo = 1 AND U.Activo = 1"
                );

                datos.realizarLectura();

                while (datos.Lector.Read())
                {
                    Vendedor v = new Vendedor();
                    v.id = (int)datos.Lector["IdVendedor"];
                    v.nombre = (string)datos.Lector["Nombre"];
                    v.apellido = (string)datos.Lector["Apellido"];
                    v.activo = (int)datos.Lector["Activo"];

                    v.usuario = new Usuario();
                    v.usuario.id = (int)datos.Lector["Id"];
                    v.usuario.usuario = (string)datos.Lector["Usuario"];
                    v.usuario.contraseña = (string)datos.Lector["Contraseña"];
                    v.usuario.idTipoUsuario = (int)datos.Lector["IdTipoUsuario"];

                    lista.Add(v);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void reactivar(int idVendedor, int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "UPDATE Vendedor SET Activo = 1 WHERE IdVendedor = @IdVendedor"
                );
                datos.setearParametro("@IdVendedor", idVendedor);
                datos.realizarAccion();

                datos.setearConsulta(
                    "UPDATE Usuarios SET Activo = 1 WHERE IdUsuario = @IdUsuario"
                );
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.realizarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Vendedor obtenerPorUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT IdVendedor, Nombre, Apellido " +
                                     "FROM Vendedor WHERE IdUsuario = @IdUsuario");

                datos.setearParametro("@IdUsuario", idUsuario);
                datos.realizarLectura();

                if (datos.Lector.Read())
                {
                    return new Vendedor
                    {
                        id = (int)datos.Lector["IdVendedor"],
                        nombre = datos.Lector["Nombre"].ToString(),
                        apellido = datos.Lector["Apellido"].ToString()
                    };
                }

                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
