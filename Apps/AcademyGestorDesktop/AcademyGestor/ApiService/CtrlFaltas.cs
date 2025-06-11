using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AcademyGestor.Modelos;
using Newtonsoft.Json;

namespace AcademyGestor.ApiService
{
    internal class CtrlFaltas
    {
        private HttpClient cli;

        public CtrlFaltas()
        {
            cli = new HttpClient();
        }

        public async Task<List<Falta_Asistencia>> getFaltas()
        {
            try
            {
                List<Falta_Asistencia> faltas = new List<Falta_Asistencia>();
                HttpResponseMessage resp = await cli.GetAsync("http://localhost:8080/escuela_circo/faltas_asistencia");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                faltas = JsonConvert.DeserializeObject<List<Falta_Asistencia>>(json);
                return faltas;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return null;
            }
        }

        public async Task<List<Falta_Asistencia>> getFaltasAlumno(int id)
        {
            try
            {
                List<Falta_Asistencia> faltas = new List<Falta_Asistencia>();
                HttpResponseMessage resp = await cli.GetAsync($"http://localhost:8080/escuela_circo/faltas_asistencia/{id}");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                faltas = JsonConvert.DeserializeObject<List<Falta_Asistencia>>(json);
                return faltas;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return null;
            }
        }

        public async Task<bool> addFalta(Falta_Asistencia falta)
        {
            try
            {
                string json = JsonConvert.SerializeObject(falta);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await cli.PostAsync("http://localhost:8080/escuela_circo/faltas_asistencia/insertar", content);
                resp.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
        }

        public async Task<bool> deleteFalta(int id)
        {
            try
            {
                HttpResponseMessage resp = await cli.DeleteAsync($"http://localhost:8080/escuela_circo/faltas_asistencia/eliminar/{id}");
                resp.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
        }
    }
}
