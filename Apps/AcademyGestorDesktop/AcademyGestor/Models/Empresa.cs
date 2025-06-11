using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGestor.Modelos
{
    public class Empresa
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string razon_fiscal { get; set; }
        public string cif { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public string provincia { get; set; }
        public string cp { get; set; }

    }
}
