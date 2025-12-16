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
                    "INSERT INTO Compra (IdProveedor, IdProducto, Precio, Cantidad) " +
                    "VALUES (@IdProveedor, @IdProducto, @Precio, @Cantidad)");

                datos.setearParametro("@IdProveedor", compra.proveedor.id);
                datos.setearParametro("@IdProducto", compra.producto.id);
                datos.setearParametro("@Precio", compra.precio);
                datos.setearParametro("@Cantidad", compra.cantidad);

                datos.realizarAccion();

                prodNegocio.actualizarStock(compra.producto.id, compra.cantidad);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}

