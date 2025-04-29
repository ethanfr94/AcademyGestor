using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGestor.Modelos
{

    public enum Rol
    {
        Admin, User
    }

    public class Usuario
    {
        public int id { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        public Rol rol { get; set; }

    }
}
