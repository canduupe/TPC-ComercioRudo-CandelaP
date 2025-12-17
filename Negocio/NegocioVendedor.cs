using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioVendedor
    {
        public Vendedor obtenerPorUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT IdVendedor, Nombre, Apellido " +
                                     "FROM Vendedor WHERE IdUsuario = @IdUsuario");

                datos.setearParametro("@IdUsuario", idUsuario);
                datos.realizarLectura();

                if (datos.Lector.Read())
                {
                    return new Vendedor
                    {
                        id = (int)datos.Lector["IdVendedor"],
                        nombre = datos.Lector["Nombre"].ToString(),
                        apellido = datos.Lector["Apellido"].ToString()
                    };
                }

                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
