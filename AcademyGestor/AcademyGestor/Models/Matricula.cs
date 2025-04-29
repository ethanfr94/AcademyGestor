using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGestor.Modelos
{
    public class Matricula
    {
        public int id { get; set; }
        public Alumno alumno { get; set; }
        public Curso curso { get; set; }
        public DateTime fechAlta { get; set; }
        public DateTime fechBaja { get; set; }
        public bool autorizacionFotos { get; set; }
        public bool beca { get; set; }

    }
}
