using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioCompra
    {

        public void agregar(Compra compra)
        {
            AccesoDatos datos = new AccesoDatos();
            NegocioProducto prodNegocio = new NegocioProducto();

            try
            {
                datos.setearConsulta(
      "INSERT INTO Compra (IdProveedor, IdProducto, IdVendedor, Precio, Cantidad, Ganancia) " +
      "VALUES (@IdProveedor, @IdProducto, @IdVendedor, @Precio, @Cantidad, @Ganancia)");

                datos.setearParametro("@IdProveedor", compra.proveedor.id);
                datos.setearParametro("@IdProducto", compra.producto.id);
                datos.setearParametro("@IdVendedor", compra.vendedor.id);
                datos.setearParametro("@Precio", compra.precio);
                datos.setearParametro("@Cantidad", compra.cantidad);
                datos.setearParametro("@Ganancia", compra.ganancia);

                datos.realizarAccion();

                prodNegocio.actualizarStock(compra.producto.id, compra.cantidad);
                prodNegocio.actualizarPrecio(compra.producto.id, compra.precio, compra.ganancia);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Compra> listar()
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT C.IdCompra, C.Precio, C.Cantidad, C.Ganancia, " +
                    "P.IdProveedor, P.Nombre AS NombreProveedor, " +
                    "PR.IdProducto, PR.Nombre AS NombreProducto " +
                    "FROM Compra C " +
                    "INNER JOIN Proveedor P ON C.IdProveedor = P.IdProveedor " +
                    "INNER JOIN Producto PR ON C.IdProducto = PR.IdProducto");

                datos.realizarLectura();

                while (datos.Lector.Read())
                {
                    Compra compra = new Compra();
                    compra.id = (int)datos.Lector["IdCompra"];
                    compra.precio = (decimal)datos.Lector["Precio"];
                    compra.cantidad = (int)datos.Lector["Cantidad"];
                    compra.ganancia = (decimal)datos.Lector["Ganancia"];

                    compra.proveedor = new Proveedor();
                    compra.proveedor.id = (int)datos.Lector["IdProveedor"];
                    compra.proveedor.nombre = datos.Lector["NombreProveedor"].ToString();

                    compra.producto = new Producto();
                    compra.producto.id = (int)datos.Lector["IdProducto"];
                    compra.producto.nombre = datos.Lector["NombreProducto"].ToString();

                    lista.Add(compra);
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Compra> listarPorVendedor(int idVendedor)
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT C.IdCompra, C.Precio, C.Cantidad, C.Ganancia, " +
                    "P.Nombre AS Proveedor, PR.Nombre AS Producto " +
                    "FROM Compra C " +
                    "INNER JOIN Proveedor P ON C.IdProveedor = P.IdProveedor " +
                    "INNER JOIN Producto PR ON C.IdProducto = PR.IdProducto " +
                    "WHERE C.IdVendedor = @IdVendedor");

                datos.setearParametro("@IdVendedor", idVendedor);
                datos.realizarLectura();

                while (datos.Lector.Read())
                {
                    Compra c = new Compra();

                    c.id = (int)datos.Lector["IdCompra"];
                    c.precio = (decimal)datos.Lector["Precio"];
                    c.cantidad = (int)datos.Lector["Cantidad"];
                    c.ganancia = (decimal)datos.Lector["Ganancia"];

                    c.proveedor = new Proveedor
                    {
                        nombre = datos.Lector["Proveedor"].ToString()
                    };

                    c.producto = new Producto
                    {
                        nombre = datos.Lector["Producto"].ToString()
                    };

                    lista.Add(c);
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}