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
        public DateTime fecha_nac { get; set; }
        public string direccion { get; set; }
        public string localidad { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }
        public Tutor tutor { get; set; }
        public bool prot_datos { get; set; }
        public bool aut_fotos { get; set; }
        public bool whatsapp { get; set; }
        public bool com_comerciales { get; set; }
        public bool beca { get; set; }

    }
}
