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
    internal class CtrlTipos
    {
        private HttpClient cli;
        public CtrlTipos()
        {
            cli = new HttpClient();
        }
        public async Task<List<Tipo>> getTipos()
        {
            try
            {
                List<Tipo> tipos = new List<Tipo>();
                HttpResponseMessage resp = await cli.GetAsync("http://localhost:8080/escuela_circo/tipos");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                tipos = JsonConvert.DeserializeObject<List<Tipo>>(json);
                return tipos;
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
        public async Task<Tipo> getTipo(int id)
        {
            try
            {
                Tipo tipo = new Tipo();
                HttpResponseMessage resp = await cli.GetAsync($"http://localhost:8080/escuela_circo/tipos/{id}");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                tipo = JsonConvert.DeserializeObject<Tipo>(json);
                return tipo;
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
    }
}
