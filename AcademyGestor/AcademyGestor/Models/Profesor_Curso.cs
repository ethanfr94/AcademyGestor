using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGestor.Modelos
{
    public class Profesor_Curso
    {
        public int id { get; set; }
        public Profesor profesor { get; set; }
        public Curso curso { get; set; }
        public byte coordinador { get; set; }
    }
}
