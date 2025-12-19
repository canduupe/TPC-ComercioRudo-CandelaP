using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioVenta
    {
        private string obtenerProximoNumeroFactura()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT ISNULL(MAX(NroFactura), '0001-00000000') FROM Venta"
                );

                datos.realizarLectura();

                if (datos.Lector.Read())
                {
                    string ultimo = datos.Lector[0].ToString();

                    string puntoVenta = ultimo.Substring(0, 4);   
                    int numero = int.Parse(ultimo.Substring(5));

                    numero++;

                    return puntoVenta + "-" + numero.ToString("D8");
                }

                return "0001-00000001";
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void RegistrarVenta(Venta venta)
        {
            if (venta == null)
                throw new Exception("La venta es nula.");

            if (venta.cliente == null || venta.cliente.id <= 0)
                throw new Exception("Cliente inválido.");

            if (venta.vendedor == null || venta.vendedor.id <= 0)
                throw new Exception("Vendedor inválido.");

            if (venta.Detalles == null || venta.Detalles.Count == 0)
                throw new Exception("La venta no tiene productos.");

            AccesoDatos datos = new AccesoDatos();
            NegocioProducto negocioProducto = new NegocioProducto();

            try
            {
                venta.nroFactura = obtenerProximoNumeroFactura();

                decimal total = 0;
                foreach (DetalleVenta det in venta.Detalles)
                {
                    if (det.cantidad <= 0)
                        throw new Exception("Cantidad inválida.");

                    if (det.precioUnitario <= 0)
                        throw new Exception("Precio inválido.");

                    if (det.producto == null || det.producto.id <= 0)
                        throw new Exception("Producto inválido.");

                    Producto productoDB = negocioProducto.obtenerPorId(det.producto.id);

                    if (productoDB.stockActual < det.cantidad)
                        throw new Exception($"Stock insuficiente para {productoDB.nombre}");

                    det.subtotal = det.cantidad * det.precioUnitario;
                    total += det.subtotal;
                }

                if (total <= 0)throw new Exception("Total inválido.");

                venta.total = total;

                datos.setearConsulta(
                    "INSERT INTO Venta (NroFactura, IdCliente, IdVendedor, Fecha, Total) " +
                    "VALUES (@NroFactura, @IdCliente, @IdVendedor, GETDATE(), @Total); " +
                    "SELECT SCOPE_IDENTITY();"
                );

                datos.setearParametro("@NroFactura", venta.nroFactura);
                datos.setearParametro("@IdCliente", venta.cliente.id);
                datos.setearParametro("@IdVendedor", venta.vendedor.id);
                datos.setearParametro("@Total", venta.total);

                datos.realizarLectura();

                if (datos.Lector.Read())
                    venta.id = Convert.ToInt32(datos.Lector[0]);

                datos.cerrarConexion();

                foreach (var det in venta.Detalles)
                {
                    AccesoDatos datosDetalle = new AccesoDatos();

                    datosDetalle.setearConsulta(
                        "INSERT INTO DetalleVenta (IdVenta, IdProducto, Cantidad, PrecioUnitario, Subtotal) " +
                        "VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUnitario, @Subtotal)"
                    );

                    datosDetalle.setearParametro("@IdVenta", venta.id);
                    datosDetalle.setearParametro("@IdProducto", det.producto.id);
                    datosDetalle.setearParametro("@Cantidad", det.cantidad);
                    datosDetalle.setearParametro("@PrecioUnitario", det.precioUnitario);
                    datosDetalle.setearParametro("@Subtotal", det.subtotal);

                    datosDetalle.realizarAccion();
                    datosDetalle.cerrarConexion();

                    negocioProducto.actualizarStock(det.producto.id, -det.cantidad);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Venta> listar()
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT V.IdVenta, V.NroFactura, V.Fecha, V.Total, " +
                    "C.IdCliente, C.Nombre, C.Apellido, " +
                    "VE.IdVendedor, VE.Nombre AS NombreVendedor, VE.Apellido AS ApellidoVendedor " +
                    "FROM Venta V " +
                    "INNER JOIN Cliente C ON C.IdCliente = V.IdCliente " +
                    "INNER JOIN Vendedor VE ON VE.IdVendedor = V.IdVendedor " +
                    "ORDER BY V.Fecha DESC"
                );

                datos.realizarLectura();

                while (datos.Lector.Read())
                {
                    Venta venta = new Venta
                    {
                        id = (int)datos.Lector["IdVenta"],
                        nroFactura = (string)datos.Lector["NroFactura"],
                        fecha = (System.DateTime)datos.Lector["Fecha"],
                        total = (decimal)datos.Lector["Total"],

                        cliente = new Cliente
                        {
                            id = (int)datos.Lector["IdCliente"],
                            nombre = datos.Lector["Nombre"].ToString(),
                            apellido = datos.Lector["Apellido"].ToString()
                        },

                        vendedor = new Vendedor
                        {
                            id = (int)datos.Lector["IdVendedor"],
                            nombre = datos.Lector["NombreVendedor"].ToString(),
                            apellido = datos.Lector["ApellidoVendedor"].ToString()
                        }
                    };

                    lista.Add(venta);
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<DetalleVenta> listarDetalle(int idVenta)
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT DV.Cantidad, DV.PrecioUnitario, DV.Subtotal, " +
                    "P.Nombre " +
                    "FROM DetalleVenta DV " +
                    "INNER JOIN Producto P ON P.IdProducto = DV.IdProducto " +
                    "WHERE DV.IdVenta = @IdVenta"
                );

                datos.setearParametro("@IdVenta", idVenta);
                datos.realizarLectura();

                while (datos.Lector.Read())
                {
                    DetalleVenta det = new DetalleVenta();
                    det.producto = new Producto();
                    det.producto.nombre = (string)datos.Lector["Nombre"];
                    det.cantidad = (int)datos.Lector["Cantidad"];
                    det.precioUnitario = (decimal)datos.Lector["PrecioUnitario"];
                    det.subtotal = (decimal)datos.Lector["Subtotal"];

                    lista.Add(det);
                }
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }


    }
}
    
