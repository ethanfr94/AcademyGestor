using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGestor.Modelos
{
    public class Tutor
    {
        public int? id { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string email { get; set; }
        public string dni { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public string telefono { get; set; }

        public string nombreCompleto
        {
            get
            {
                return $"{nombre} {apellido1} {apellido2}";
            }
        }
    }
}
