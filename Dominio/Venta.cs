using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int id { get; set; }
        public string nroFactura { get; set; }
        public Cliente cliente { get; set; }
        public Vendedor vendedor { get; set; }
        public DateTime fecha { get; set; }
        public decimal total { get; set; }

        public List<DetalleVenta> Detalles { get; set; }

    }
}
