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
        public decimal precio { get; set; }
        public Proveedor proveedor { get; set; }
        public Marca marca { get; set; }
        public Categoria categoria { get; set; }
        public int stockActual { get; set; }
        public int stockMinimo { get; set; }
        public int activo { get; set; }
    }
}
