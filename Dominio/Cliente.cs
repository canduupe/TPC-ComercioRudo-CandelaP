using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
        public class Cliente
        {
            public int IdCliente { get; set; }

            public string Nombre { get; set; }

            public string Apellido { get; set; }

            public string DNI { get; set; }

            public string Telefono { get; set; }

            public string Email { get; set; }

            public string Direccion { get; set; }

            public int Activo { get; set; }

            public Cliente()
            {
            }

            public Cliente(int idCliente, string nombre, string apellido, string dni,
                           string telefono, string email, string direccion, int activo)
            {
                IdCliente = idCliente;
                Nombre = nombre;
                Apellido = apellido;
                DNI = dni;
                Telefono = telefono;
                Email = email;
                Direccion = direccion;
                Activo = activo;
            }
        }
    }
