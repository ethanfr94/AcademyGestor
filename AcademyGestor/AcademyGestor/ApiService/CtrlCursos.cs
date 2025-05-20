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
    internal class CtrlCursos
    {

        private HttpClient cli;

        public CtrlCursos()
        {
            cli = new HttpClient();
        }

        public async Task<List<Curso>> getCursos()
        {
            try
            {
                List<Curso> cursos = new List<Curso>();
                HttpResponseMessage resp = await cli.GetAsync("http://localhost:8080/escuela_circo/cursos");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                cursos = JsonConvert.DeserializeObject<List<Curso>>(json);
                return cursos;
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

        public async Task<Curso> getCurso(int id)
        {
            try
            {
                Curso curso = new Curso();
                HttpResponseMessage resp = await cli.GetAsync($"http://localhost:8080/escuela_circo/cursos/{id}");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                curso = JsonConvert.DeserializeObject<Curso>(json);
                return curso;
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

        public async Task<bool> addCurso(Curso curso)
        {
            try
            {
                string json = JsonConvert.SerializeObject(curso);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await cli.PostAsync("http://localhost:8080/escuela_circo/cursos/insertar", content);
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

        public async Task<bool> updateCurso(Curso curso)
        {
            try
            {
                string json = JsonConvert.SerializeObject(curso);

                int id = (int)curso.id;

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await cli.PutAsync($"http://localhost:8080/escuela_circo/cursos/modificar/{id}", content);
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

        public async Task<bool> deleteCurso(int id)
        {
            try
            {
                HttpResponseMessage resp = await cli.DeleteAsync($"http://localhost:8080/escuela_circo/cursos/eliminar/{id}");
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
