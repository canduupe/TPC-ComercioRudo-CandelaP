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
                datos.setearParametro("@Proveedor", nuevo.proveedor.id);
                datos.setearParametro("@Marca", nuevo.Marca.id);
                datos.setearParametro("@Categoria", nuevo.Categoria.id);
                datos.setearParametro("@StockActual", nuevo.stockActual);
                datos.setearParametro("@StockMinimo", nuevo.stockMinimo);

                datos.realizarAccion();
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
                datos.setearConsulta("DELETE FROM Producto WHERE IdProducto = @Id");

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
        
                datos.setearParametro("@Proveedor", prod.proveedor.id);

                datos.setearParametro("@Marca", prod.Marca.id);

                datos.setearParametro("@Categoria", prod.Categoria.id);

                datos.setearParametro("@StockActual", prod.stockActual);
                datos.setearParametro("@StockMinimo", prod.stockMinimo);
                datos.setearParametro("@Id", prod.id);

                datos.realizarAccion();
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
                datos.setearConsulta(@"SELECT 
            P.IdProducto, P.Nombre, P.Descripcion, P.Precio,
            P.StockActual, P.StockMinimo, P.Activo,
            PR.IdProveedor, PR.Nombre AS NombreProveedor,
            M.IdMarca, M.Nombre AS NombreMarca,
            C.IdCategoria, C.Nombre AS NombreCategoria
            FROM Producto P
            LEFT JOIN Proveedor PR ON PR.IdProveedor = P.Proveedor
            INNER JOIN Marca M ON M.IdMarca = P.Marca
            INNER JOIN Categoria C ON C.IdCategoria = P.Categoria");

                datos.realizarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();

                    aux.id = (int)datos.Lector["IdProducto"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                    aux.stockActual = (int)datos.Lector["StockActual"];
                    aux.stockMinimo = (int)datos.Lector["StockMinimo"];
                    aux.activo = (int)datos.Lector["Activo"];
             
                    aux.proveedor = new Proveedor();
                    aux.proveedor.id = (int)datos.Lector["IdProveedor"];
                    aux.proveedor.nombre = (string)datos.Lector["NombreProveedor"];

                    aux.Marca = new Marca();
                    aux.Marca.id = (int)datos.Lector["IdMarca"];
                    aux.Marca.nombre = (string)datos.Lector["NombreMarca"];

                    aux.Categoria = new Categoria();
                    aux.Categoria.id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.nombre = (string)datos.Lector["NombreCategoria"];

                    lista.Add(aux);
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void actualizarStock(int idProducto, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "UPDATE Producto " +
                    "SET StockActual = StockActual + @Cantidad " +
                    "WHERE IdProducto = @IdProducto");

                datos.setearParametro("@Cantidad", cantidad);
                datos.setearParametro("@IdProducto", idProducto);

                datos.realizarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void actualizarPrecio(int idProducto, decimal precio, decimal ganancia)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                decimal precioNuevo = precio + (precio * (ganancia*0.01m));

                datos.setearConsulta(
                    "UPDATE Producto SET Precio = @Precio WHERE IdProducto = @IdProducto");

                datos.setearParametro("@Precio", precioNuevo);
                datos.setearParametro("@IdProducto", idProducto);

                datos.realizarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}
