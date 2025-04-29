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
    internal class CtrlMatriculas
    {
        private HttpClient cli;

        public CtrlMatriculas()
        {
            cli = new HttpClient();
        }

        public async Task<List<Matricula>> getMatriculas()
        {
            try
            {
                List<Matricula> matriculas = new List<Matricula>();
                HttpResponseMessage resp = await cli.GetAsync("http://localhost:8080/escuela_circo/matriculas");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                MessageBox.Show(json);
                matriculas = JsonConvert.DeserializeObject<List<Matricula>>(json);
                return matriculas;
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

        public async Task<Matricula> getMatricula(int id)
        {
            try
            {
                Matricula matricula = new Matricula();
                HttpResponseMessage resp = await cli.GetAsync($"http://localhost:8080/escuela_circo/matriculas/{id}");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                matricula = JsonConvert.DeserializeObject<Matricula>(json);
                return matricula;
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

        public async Task<bool> addMatricula(Matricula matricula)
        {
            try
            {
                string json = JsonConvert.SerializeObject(matricula);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await cli.PostAsync("http://localhost:8080/escuela_circo/matriculas/insertar", content);
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

        public async Task<bool> updateMatricula(Matricula matricula)
        {
            try
            {
                string json = JsonConvert.SerializeObject(matricula);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await cli.PutAsync($"http://localhost:8080/escuela_circo/matriculas/modificar/{matricula.id}", content);
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

        public async Task<bool> deleteMatricula(int id)
        {
            try
            {
                HttpResponseMessage resp = await cli.DeleteAsync($"http://localhost:8080/escuela_circo/matriculas/eliminar/{id}");
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
