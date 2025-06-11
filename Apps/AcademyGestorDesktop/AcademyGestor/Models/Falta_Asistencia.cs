using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGestor.Modelos
{
    public class Falta_Asistencia
    {
        public int id { get; set; }
        public Alumno alumno { get; set; }
        public Curso curso { get; set; }
        public DateTime fecha { get; set; }



    }
}
