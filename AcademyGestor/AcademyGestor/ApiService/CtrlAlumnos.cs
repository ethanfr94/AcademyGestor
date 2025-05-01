using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcademyGestor.Modelos;
using Newtonsoft.Json;


namespace AcademyGestor.ApiService
{



    internal class CtrlAlumnos
    {

        private HttpClient cli;

        public CtrlAlumnos()
        {
            cli = new HttpClient();
        }

        public async Task<List<Alumno>> getAlumnos()
        {
            try
            {
                List<Alumno> alumnos = new List<Alumno>();

                HttpResponseMessage resp = await cli.GetAsync("http://localhost:8080/escuela_circo/alumnos");

                resp.EnsureSuccessStatusCode();

                string json = await resp.Content.ReadAsStringAsync();

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    DateFormatString = "yyyy-MM-dd"
                };

                alumnos = JsonConvert.DeserializeObject<List<Alumno>>(json, settings);

                return alumnos;

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
                return new List<Alumno>();

            }
        }

        public async Task<Alumno> getAlumno(int id)
        {
            try
            {
                Alumno alumno = new Alumno();

                HttpResponseMessage resp = await cli.GetAsync($"http://localhost:8080/escuela_circo/alumnos/{id}");

                resp.EnsureSuccessStatusCode();

                string json = await resp.Content.ReadAsStringAsync();

                alumno = JsonConvert.DeserializeObject<Alumno>(json);

                return alumno;
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

        public async Task<bool> addAlumno(Alumno alumno)
        {
            try
            {
                string json = JsonConvert.SerializeObject(alumno, Formatting.Indented);

                Console.WriteLine(json);
                MessageBox.Show(json);

                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage resp = await cli.PostAsync("http://localhost:8080/escuela_circo/alumnos/insertar", content);

                if (resp.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    string errorContent = await resp.Content.ReadAsStringAsync();
                   return false;
                }
            }
            catch (HttpRequestException e)
            {
                Console.Write("ErrorHttp: " + e.Message);
                return false;
            }
            catch (Exception e)
            {
                Console.Write("Errorsdag: " + e.Message);
                return false;
            }
        }

        public async Task<bool> updateAlumno(Alumno alumno)
        {
            try
            {
                string json = JsonConvert.SerializeObject(alumno);

                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage resp = await cli.PutAsync($"http://localhost:8080/escuela_circo/alumnos/modificar/{alumno.id}", content);

                if (resp.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: " + resp.StatusCode);
                    return false;
                }
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

        public async Task<bool> deleteAlumno(int id)
        {
            try
            {
                HttpResponseMessage resp = await cli.DeleteAsync($"http://localhost:8080/escuela_circo/alumnos/eliminar/{id}");
                if (resp.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: " + resp.StatusCode);
                    return false;
                }
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show("Error: " + e.Message);
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
                return false;
            }
        }
    }

}
