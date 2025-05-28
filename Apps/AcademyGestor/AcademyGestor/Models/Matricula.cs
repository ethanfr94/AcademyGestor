using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AcademyGestor.Modelos
{
    public class Matricula
    {
        public int? id { get; set; }
        public Alumno alumno { get; set; }
        public Curso curso { get; set; }
        public DateTime? fechAlta { get; set; }
        public DateTime? fechBaja { get; set; }
        public byte autorizacionFotos { get; set; }
        public byte beca { get; set; }

    }

    public class OnlyDateConverter : JsonConverter<DateTime>
    {
        private const string Format = "yyyy-MM-dd";
        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString(Format));
        }
        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return DateTime.ParseExact((string)reader.Value, Format, null);
        }
    }
}
