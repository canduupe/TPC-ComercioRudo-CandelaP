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
                    "INSERT INTO Compra (IdProveedor, IdProducto, Precio, Cantidad, Ganancia) " +
                    "VALUES (@IdProveedor, @IdProducto, @Precio, @Cantidad, @Ganancia)");

                datos.setearParametro("@IdProveedor", compra.proveedor.id);
                datos.setearParametro("@IdProducto", compra.producto.id);
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

    }
}

