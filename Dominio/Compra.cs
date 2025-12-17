using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
            public int id { get; set; }
            public Proveedor proveedor { get; set; }
            public Producto producto { get; set; }   
            public decimal precio { get; set; }
            public decimal ganancia { get; set; }
            public int cantidad { get; set; }
    }
}

