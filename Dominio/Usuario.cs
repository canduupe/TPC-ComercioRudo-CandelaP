using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int id { get; set; }

        public string usuario { get; set; }

        public string contraseña { get; set; }

        public int idTipoUsuario { get; set; }

        public int activo { get; set; }
    }
}
