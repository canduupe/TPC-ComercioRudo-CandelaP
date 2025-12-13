using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class NegocioProveedor
    {
        public void agregar(Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "INSERT INTO Proveedor (Nombre, Marca, Categoria, Activo) " +
                    "VALUES (@Nombre, @Marca, @Categoria, 1)");

                datos.setearParametro("@Nombre", proveedor.nombre);
                datos.setearParametro("@Marca", proveedor.marca.id);
                datos.setearParametro("@Categoria", proveedor.categoria.id);

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

        public void modificar(Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "UPDATE Proveedor SET " +
                    "Nombre = @Nombre, " +
                    "Marca = @Marca, " +
                    "Categoria = @Categoria " +
                    "WHERE IdProveedor = @Id");

                datos.setearParametro("@Nombre", proveedor.nombre);
                datos.setearParametro("@Marca", proveedor.marca.id);
                datos.setearParametro("@Categoria", proveedor.categoria.id);
                datos.setearParametro("@Id", proveedor.id);

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
                    "DELETE FROM Proveedor WHERE IdProveedor = @Id");

                datos.setearParametro("@Id", id);

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

        public List<Proveedor> listar()
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT " +
                    "P.IdProveedor, P.Nombre, " +
                    "M.IdMarca, M.Nombre AS MarcaNombre, " +
                    "C.IdCategoria, C.Nombre AS CategoriaNombre, " +
                    "P.Activo " +
                    "FROM Proveedor P " +
                    "INNER JOIN Marca M ON P.Marca = M.IdMarca " +
                    "INNER JOIN Categoria C ON P.Categoria = C.IdCategoria");

                datos.realizarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor p = new Proveedor();
                    p.id = (int)datos.Lector["IdProveedor"];
                    p.nombre = (string)datos.Lector["Nombre"];

                    p.marca = new Marca();
                    p.marca.id = (int)datos.Lector["IdMarca"];
                    p.marca.nombre = (string)datos.Lector["MarcaNombre"];

                    p.categoria = new Categoria();
                    p.categoria.id = (int)datos.Lector["IdCategoria"];
                    p.categoria.nombre = (string)datos.Lector["CategoriaNombre"];

                    lista.Add(p);
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

        public Proveedor obtenerPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Proveedor p = null;

            try
            {
                datos.setearConsulta(
                    "SELECT P.IdProveedor, P.Nombre, " +
                    "P.Marca, P.Categoria " +
                    "FROM Proveedor P " +
                    "WHERE P.IdProveedor = @Id");

                datos.setearParametro("@Id", id);
                datos.realizarLectura();

                if (datos.Lector.Read())
                {
                    p = new Proveedor();
                    p.id = (int)datos.Lector["IdProveedor"];
                    p.nombre = (string)datos.Lector["Nombre"];

                    p.marca = new Marca
                    {
                        id = (int)datos.Lector["Marca"]
                    };

                    p.categoria = new Categoria
                    {
                        id = (int)datos.Lector["Categoria"]
                    };
                }

                return p;
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

