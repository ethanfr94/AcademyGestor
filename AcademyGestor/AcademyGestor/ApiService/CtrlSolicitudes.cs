using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcademyGestor.Modelos;
using Newtonsoft.Json;

namespace AcademyGestor.ApiService
{
    internal class CtrlSolicitudes
    {
        private HttpClient cli;

        public CtrlSolicitudes()
        {
            cli = new HttpClient();
        }

        public async Task<List<Solicitud>> getSolicitudes()
        {
            try
            {
                List<Solicitud> solicitudes = new List<Solicitud>();
                HttpResponseMessage resp = await cli.GetAsync("http://localhost:8080/escuela_circo/solicitudes");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                solicitudes = JsonConvert.DeserializeObject<List<Solicitud>>(json);
                return solicitudes;
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

        public async Task<Solicitud> getSolicitud(int id)
        {
            try
            {
                Solicitud solicitud = new Solicitud();
                HttpResponseMessage resp = await cli.GetAsync($"http://localhost:8080/escuela_circo/solicitudes/{id}");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                solicitud = JsonConvert.DeserializeObject<Solicitud>(json);
                return solicitud;
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

        public async Task<bool> addSolicitud(Solicitud solicitud)
        {
            try
            {
                string json = JsonConvert.SerializeObject(solicitud);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await cli.PostAsync("http://localhost:8080/escuela_circo/solicitudes/insertar", content);
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

        public async Task<bool> deleteSolicitud(int id)
        {
            try
            {
                HttpResponseMessage resp = await cli.DeleteAsync($"http://localhost:8080/escuela_circo/solicitudes/eliminar/{id}");
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
