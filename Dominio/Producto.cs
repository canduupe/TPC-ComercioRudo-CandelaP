using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal Precio { get; set; }
        public int proveedor { get; set; }
        public int marca { get; set; }
        public int categoria { get; set; }
        public int stockActual { get; set; }
        public int stockMinimo { get; set; }
        public bool activo { get; set; }
    }
}
