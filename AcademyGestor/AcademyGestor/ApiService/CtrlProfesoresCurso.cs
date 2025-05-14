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
    internal class CtrlProfesoresCurso
    {
        private HttpClient cli;
        public CtrlProfesoresCurso()
        {
            cli = new HttpClient();
        }
        public async Task<List<Profesor_Curso>> getProfesoresCurso()
        {
            try
            {
                List<Profesor_Curso> profesoresCurso = new List<Profesor_Curso>();
                HttpResponseMessage resp = await cli.GetAsync("http://localhost:8080/escuela_circo/profesoresCurso");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                profesoresCurso = JsonConvert.DeserializeObject<List<Profesor_Curso>>(json);
                return profesoresCurso;
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

        public async Task<Profesor_Curso> getProfesorCurso(int id)
        {
            try
            {
                Profesor_Curso profesorCurso = new Profesor_Curso();
                HttpResponseMessage resp = await cli.GetAsync($"http://localhost:8080/escuela_circo/profesoresCurso/{id}");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                profesorCurso = JsonConvert.DeserializeObject<Profesor_Curso>(json);
                return profesorCurso;
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

        public async Task<List<Profesor_Curso>> getProfesoresByCurso(int id)
        {
            try
            {
                List<Profesor_Curso> profesoresCurso = new List<Profesor_Curso>();
                HttpResponseMessage resp = await cli.GetAsync($"http://localhost:8080/escuela_circo/profesoresCurso/curso/{id}");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                profesoresCurso = JsonConvert.DeserializeObject<List<Profesor_Curso>>(json);
                return profesoresCurso;
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

        public async Task<Profesor_Curso> getByProfesoresByCurso(int cursoId, int profId)
        {
            try
            {
                Profesor_Curso profesoresCurso = new Profesor_Curso();
                HttpResponseMessage resp = await cli.GetAsync($"http://localhost:8080/escuela_circo/profesoresCurso/curso/profesor/{cursoId}/{profId}");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                profesoresCurso = JsonConvert.DeserializeObject<Profesor_Curso>(json);
                return profesoresCurso;
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

        public async Task<bool> addProfesorCurso(Profesor_Curso profesorCurso)
        {
            try
            {
                string json = JsonConvert.SerializeObject(profesorCurso);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await cli.PostAsync("http://localhost:8080/escuela_circo/profesoresCurso/insertar", content);
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

        public async Task<bool> updateProfesorCurso(Profesor_Curso profesorCurso)
        {
            try
            {
                string json = JsonConvert.SerializeObject(profesorCurso);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await cli.PutAsync($"http://localhost:8080/escuela_circo/profesoresCurso/modificar/{profesorCurso.id}", content);
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

        public async Task<bool> updateCoordinador(Profesor_Curso pc)
        {
            try
            {
                string json = JsonConvert.SerializeObject(new { pc });
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await cli.PutAsync($"http://localhost:8080/escuela_circo/profesoresCurso/modificar/coordinador/{pc.id}",content);
                resp.EnsureSuccessStatusCode();

                return true;
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show("Error: " + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
        }



        public async Task<bool> deleteProfesorCurso(int id)
        {
            try
            {
                HttpResponseMessage resp = await cli.DeleteAsync($"http://localhost:8080/escuela_circo/profesoresCurso/eliminar/{id}");
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

        public async Task<bool> deleteProfesorCursoByCursoYProfesor(int idCurso, int idProf)
        {
            try
            {
                HttpResponseMessage resp = await cli.DeleteAsync($"http://localhost:8080/escuela_circo/profesoresCurso/eliminar/curso/profesor/{idCurso}/{idProf}");
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
