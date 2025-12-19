using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Vendedor
    {
        public int id{ get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Usuario usuario { get; set; }
        public int activo { get; set; }
    }
}
