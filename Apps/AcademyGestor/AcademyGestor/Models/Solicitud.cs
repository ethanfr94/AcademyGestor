using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGestor.Modelos
{
    public class Solicitud
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public Curso curso { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string dni { get; set; }
        public DateTime fechaNac { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public Tutor tutor { get; set; }
        public byte proteccionDatos { get; set; }
        public byte autorizacionFotos { get; set; }
        public byte grupoWhatsapp { get; set; }
        public byte comunicacionesComerciales { get; set; }
        public byte beca { get; set; }

    }
}
