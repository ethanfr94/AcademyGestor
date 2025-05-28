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
    internal class CtrlRecibos
    {
        private HttpClient cli;

        public CtrlRecibos()
        {
            cli = new HttpClient();
        }

        public async Task<List<Recibo>> getRecibos()
        {
            try
            {
                List<Recibo> recibos = new List<Recibo>();
                HttpResponseMessage resp = await cli.GetAsync("http://localhost:8080/escuela_circo/recibos");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                recibos = JsonConvert.DeserializeObject<List<Recibo>>(json);
                return recibos;
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

        public async Task<Recibo> getRecibo(int id)
        {
            try
            {
                Recibo recibo = new Recibo();
                HttpResponseMessage resp = await cli.GetAsync($"http://localhost:8080/escuela_circo/recibos/{id}");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                recibo = JsonConvert.DeserializeObject<Recibo>(json);
                return recibo;
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

        public async Task<bool> addRecibo(Recibo recibo)
        {
            try
            {
                string json = JsonConvert.SerializeObject(recibo);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await cli.PostAsync("http://localhost:8080/escuela_circo/recibos/insertar", content);
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

        public async Task<bool> updateRecibo(Recibo recibo)
        {
            try
            {
                string json = JsonConvert.SerializeObject(recibo);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await cli.PutAsync($"http://localhost:8080/escuela_circo/recibos/modificar/{recibo.id}", content);
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

        public async Task<bool> cobrar(Recibo recibo)
        {
            try
            {
                string json = JsonConvert.SerializeObject(recibo);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await cli.PutAsync($"http://localhost:8080/escuela_circo/recibos/cobrar", content);
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



        public async Task<bool> deleteRecibo(int id)
        {
            try
            {
                HttpResponseMessage resp = await cli.DeleteAsync($"http://localhost:8080/escuela_circo/recibos/eliminar/{id}");
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
