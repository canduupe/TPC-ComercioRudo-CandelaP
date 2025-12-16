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
                datos.setearConsulta(
                    "INSERT INTO Cliente (Nombre, Apellido, DNI, Telefono, Email, Direccion, Activo) " +
                    "VALUES (@n, @a, @dni, @t, @e, @d, 1)");

                datos.setearParametro("@n", c.Nombre);
                datos.setearParametro("@a", c.Apellido);
                datos.setearParametro("@dni", c.DNI);
                datos.setearParametro("@t", c.Telefono);
                datos.setearParametro("@e", c.Email);
                datos.setearParametro("@d", c.Direccion);

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
                datos.setearConsulta(
                    "UPDATE Cliente SET Nombre=@n, Apellido=@a, DNI=@dni, " +
                    "Telefono=@t, Email=@e, Direccion=@d WHERE IdCliente=@id");

                datos.setearParametro("@n", c.Nombre);
                datos.setearParametro("@a", c.Apellido);
                datos.setearParametro("@dni", c.DNI);
                datos.setearParametro("@t", c.Telefono);
                datos.setearParametro("@e", c.Email);
                datos.setearParametro("@d", c.Direccion);
                datos.setearParametro("@id", c.IdCliente);

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
                datos.setearConsulta(
                    "UPDATE Cliente SET Activo = 0 WHERE IdCliente = @id");

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
                    c.IdCliente = (int)datos.Lector["IdCliente"];
                    c.Nombre = datos.Lector["Nombre"].ToString();
                    c.Apellido = datos.Lector["Apellido"].ToString();
                    c.DNI = datos.Lector["DNI"].ToString();
                    c.Telefono = datos.Lector["Telefono"].ToString();
                    c.Email = datos.Lector["Email"].ToString();
                    c.Direccion = datos.Lector["Direccion"].ToString();
                    c.Activo = (int)datos.Lector["Activo"];

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
                    c.IdCliente = (int)datos.Lector["IdCliente"];
                    c.Nombre = datos.Lector["Nombre"].ToString();
                    c.Apellido = datos.Lector["Apellido"].ToString();
                    c.DNI = datos.Lector["DNI"].ToString();
                    c.Telefono = datos.Lector["Telefono"].ToString();
                    c.Email = datos.Lector["Email"].ToString();
                    c.Direccion = datos.Lector["Direccion"].ToString();
                    c.Activo = (int)datos.Lector["Activo"];
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

