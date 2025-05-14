using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGestor.Modelos
{
    public enum TipoPublicacion
    {
        Texto, Foto
    }

    public class Publicacion
    {
        public int id { get; set; }
        public DateTime timeStamp { get; set; }
        public TipoPublicacion tipo { get; set; }
        public string url { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; } 
        public Profesor profesor { get; set; } 


    }
}
