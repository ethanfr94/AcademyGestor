using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcademyGestor.Modelos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AcademyGestor.ApiService
{
    internal class CtrlTutores
    {
        private HttpClient cli;

        public CtrlTutores()
        {
            cli = new HttpClient();

        }

        public async Task<List<Tutor>> getTutores()
        {
            try
            {
                List<Tutor> tutores = new List<Tutor>();                

                HttpResponseMessage resp = await cli.GetAsync("http://localhost:8080/escuela_circo/tutores");
                
                resp.EnsureSuccessStatusCode();

                string json = await resp.Content.ReadAsStringAsync();

                tutores = JsonConvert.DeserializeObject<List<Tutor>>(json);

                return tutores;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return new List<Tutor>();
            }
        }
    

        public async Task<Tutor> getTutor(int id)
        {
            try
            {
                Tutor tutor = new Tutor();
                HttpResponseMessage resp = await cli.GetAsync($"http://localhost:8080/escuela_circo/tutores/{id}");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                tutor = JsonConvert.DeserializeObject<Tutor>(json);
                return tutor;
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

        public async Task<Tutor> getTutorByDni(string dni)
        {
            try
            {
                Tutor tutor = new Tutor();
                HttpResponseMessage resp = await cli.GetAsync($"http://localhost:8080/escuela_circo/tutores/dni/{dni}");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                tutor = JsonConvert.DeserializeObject<Tutor>(json);
                return tutor;
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

        public async Task<bool> addTutor(Tutor tutor)
        {
            try
            {
                string json = JsonConvert.SerializeObject(tutor);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await cli.PostAsync("http://localhost:8080/escuela_circo/tutores/insertar", content);
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

        public async Task<bool> updateTutor(Tutor tutor)
        {
            try
            {
                string json = JsonConvert.SerializeObject(tutor);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await cli.PutAsync($"http://localhost:8080/escuela_circo/tutores/modificar/{tutor.id}", content);
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

        public async Task<bool> deleteTutor(int id)
        {
            try
            {
                HttpResponseMessage resp = await cli.DeleteAsync($"http://localhost:8080/escuela_circo/tutores/eliminar/{id}");
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
