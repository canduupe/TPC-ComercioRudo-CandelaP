using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class NegocioProducto
    {
        public void agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "INSERT INTO Producto (Nombre, Descripcion, Precio, Proveedor, Marca, Categoria, StockActual, StockMinimo, Activo) " +
                    "VALUES (@Nombre, @Descripcion, @Precio, @Proveedor, @Marca, @Categoria, @StockActual, @StockMinimo, 1)");

                datos.setearParametro("@Nombre", nuevo.nombre);
                datos.setearParametro("@Descripcion", nuevo.descripcion);
                datos.setearParametro("@Precio", nuevo.precio);
                datos.setearParametro("@Proveedor", nuevo.proveedor == 0 ? DBNull.Value : (object)nuevo.proveedor);
                datos.setearParametro("@Marca", nuevo.marca);
                datos.setearParametro("@Categoria", nuevo.categoria);
                datos.setearParametro("@StockActual", nuevo.stockActual);
                datos.setearParametro("@StockMinimo", nuevo.stockMinimo);

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
                    "UPDATE Producto SET Activo = 0 WHERE IdProducto = @Id");

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

        public void modificar(Producto prod)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "UPDATE Producto SET " +
                    "Nombre = @Nombre, " +
                    "Descripcion = @Descripcion, " +
                    "Precio = @Precio, " +
                    "Proveedor = @Proveedor, " +
                    "Marca = @Marca, " +
                    "Categoria = @Categoria, " +
                    "StockActual = @StockActual, " +
                    "StockMinimo = @StockMinimo " +
                    "WHERE IdProducto = @Id");

                datos.setearParametro("@Nombre", prod.nombre);
                datos.setearParametro("@Descripcion", prod.descripcion);
                datos.setearParametro("@Precio", prod.precio);
                datos.setearParametro("@Proveedor", prod.proveedor == 0 ? DBNull.Value : (object)prod.proveedor);
                datos.setearParametro("@Marca", prod.marca);
                datos.setearParametro("@Categoria", prod.categoria);
                datos.setearParametro("@StockActual", prod.stockActual);
                datos.setearParametro("@StockMinimo", prod.stockMinimo);
                datos.setearParametro("@Id", prod.id);

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

        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select IdProducto, Nombre, Descripcion, Precio, Proveedor, Marca, Categoria, StockActual, StockMinimo, Activo from Producto");

                datos.realizarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();

                    aux.id = (int)datos.Lector["IdProducto"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                    aux.proveedor = (int)datos.Lector["Proveedor"];
                    aux.marca = (int)datos.Lector["Marca"];
                    aux.categoria = (int)datos.Lector["Categoria"];
                    aux.stockActual = (int)datos.Lector["StockActual"];
                    aux.stockMinimo = (int)datos.Lector["StockMinimo"];
                    aux.activo = (int)datos.Lector["Activo"];

                    lista.Add(aux);
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

    }
}
