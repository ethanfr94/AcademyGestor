using System;

namespace AcademyGestor.Modelos
{
    public class Alumno
    {
        public int id { get; set; }
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
        public byte grupoWhatsapp { get; set; }
        public byte comunicacionesComerciales { get; set; }

        public string ToString()
        {
            return $"{nombre} {apellido1} {apellido2} {dni} {fechaNac.ToString("dd/MM/yyyy")} {direccion} {localidad} {email} {telefono} {tutor.nombreCompleto} {proteccionDatos} {grupoWhatsapp} {comunicacionesComerciales}";
        }


    }
}
