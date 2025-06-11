using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGestor.Modelos
{
    public class Curso
    {
        public int? id { get; set; }
        public string cod_curso { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string horario { get; set; }
        public Tipo tipo { get; set; }
        public byte? activo { get; set; }
        



    }
}
