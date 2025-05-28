using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGestor.Modelos
{
    public class Recibo
    {
        public int id { get; set; }
        public Matricula matricula { get; set; }
        public string detalle { get; set; }
        public DateTime fecha { get; set; }
        public double importe { get; set; }
        public byte descuento { get; set; }
        public byte pagado { get; set; }
    }
}
