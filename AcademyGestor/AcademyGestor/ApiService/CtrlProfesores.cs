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
    internal class CtrlProfesores
    {
        private HttpClient cli;

        public CtrlProfesores()
        {
            cli = new HttpClient();
        }

        public async Task<List<Profesor>> getProfesores()
        {
            try
            {
                List<Profesor> profesores = new List<Profesor>();

                HttpResponseMessage resp = await cli.GetAsync("http://localhost:8080/escuela_circo/profesores");
               
                resp.EnsureSuccessStatusCode();

                string json = await resp.Content.ReadAsStringAsync();

                profesores = JsonConvert.DeserializeObject<List<Profesor>>(json);
                
                return profesores;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return new List<Profesor>(); ;
            }
        }

        public async Task<Profesor> getProfesor(int id)
        {
            try
            {
                Profesor profesor = new Profesor();
                HttpResponseMessage resp = await cli.GetAsync($"http://localhost:8080/escuela_circo/profesores/{id}");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                profesor = JsonConvert.DeserializeObject<Profesor>(json);
                return profesor;
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

        public async Task<bool> addProfesor(Profesor profesor)
        {
            try
            {
                string json = JsonConvert.SerializeObject(profesor);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await cli.PostAsync("http://localhost:8080/escuela_circo/profesores/insertar", content);
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

        public async Task<bool> updateProfesor(Profesor profesor)
        {
            try
            {
                string json = JsonConvert.SerializeObject(profesor);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await cli.PutAsync($"http://localhost:8080/escuela_circo/profesores/modificar/{profesor.id}", content);
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

        public async Task<bool> deleteProfesor(int id)
        {
            try
            {
                HttpResponseMessage resp = await cli.DeleteAsync($"http://localhost:8080/escuela_circo/profesores/eliminar/{id}");
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
