using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NegocioCliente
    {
        public void agregar(Cliente c)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Cliente (Nombre, Apellido, DNI, Telefono, Email, Direccion, Activo) " +
                                     "VALUES (@n, @a, @dni, @t, @e, @d, 1)");

                datos.setearParametro("@n", c.nombre);
                datos.setearParametro("@a", c.apellido);
                datos.setearParametro("@dni", c.DNI);
                datos.setearParametro("@t", c.telefono);
                datos.setearParametro("@e", c.email);
                datos.setearParametro("@d", c.direccion);

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

        public void modificar(Cliente c)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Cliente SET Nombre=@n, Apellido=@a, DNI=@dni, " +
                                     "Telefono=@t, Email=@e, Direccion=@d WHERE IdCliente=@id");

                datos.setearParametro("@n", c.nombre);
                datos.setearParametro("@a", c.apellido);
                datos.setearParametro("@dni", c.DNI);
                datos.setearParametro("@t", c.telefono);
                datos.setearParametro("@e", c.email);
                datos.setearParametro("@d", c.direccion);
                datos.setearParametro("@id", c.id);

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

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Cliente SET Activo = 0 WHERE IdCliente = @id");

                datos.setearParametro("@id", id);
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

        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT * FROM Cliente WHERE Activo = 1");
                datos.realizarLectura();

                while (datos.Lector.Read())
                {
                    Cliente c = new Cliente();
                    c.id = (int)datos.Lector["IdCliente"];
                    c.nombre = datos.Lector["Nombre"].ToString();
                    c.apellido = datos.Lector["Apellido"].ToString();
                    c.DNI = datos.Lector["DNI"].ToString();
                    c.telefono = datos.Lector["Telefono"].ToString();
                    c.email = datos.Lector["Email"].ToString();
                    c.direccion = datos.Lector["Direccion"].ToString();
                    c.activo = (int)datos.Lector["Activo"];

                    lista.Add(c);
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

        public Cliente obtenerPorID(int id)
        {
            Cliente c = new Cliente();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT * FROM Cliente WHERE IdCliente = @id");
                datos.setearParametro("@id", id);
                datos.realizarLectura();

                if (datos.Lector.Read())
                {
                    c.id = (int)datos.Lector["IdCliente"];
                    c.nombre = datos.Lector["Nombre"].ToString();
                    c.apellido = datos.Lector["Apellido"].ToString();
                    c.DNI = datos.Lector["DNI"].ToString();
                    c.telefono = datos.Lector["Telefono"].ToString();
                    c.email = datos.Lector["Email"].ToString();
                    c.direccion = datos.Lector["Direccion"].ToString();
                    c.activo = (int)datos.Lector["Activo"];
                }

                return c;
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

    }

}

