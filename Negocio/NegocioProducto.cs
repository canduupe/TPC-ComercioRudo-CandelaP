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
