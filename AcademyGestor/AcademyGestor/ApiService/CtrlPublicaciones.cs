using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using AcademyGestor.Modelos;
using Newtonsoft.Json;

namespace AcademyGestor.ApiService
{
    internal class CtrlPublicaciones
    {

        private HttpClient cli;

        public CtrlPublicaciones()
        {
            cli = new HttpClient();
        }

        public async Task<List<Publicacion>> getPublicaciones()
        {
            try
            {
                List<Publicacion> publicaciones = new List<Publicacion>();
                HttpResponseMessage resp = await cli.GetAsync("http://localhost:8080/escuela_circo/publicaciones");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                publicaciones = JsonConvert.DeserializeObject<List<Publicacion>>(json);
                return publicaciones;
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

        public async Task<Publicacion> getPublicacion(int id)
        {
            try
            {
                Publicacion publicacion = new Publicacion();
                HttpResponseMessage resp = await cli.GetAsync($"http://localhost:8080/escuela_circo/publicaciones/{id}");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                publicacion = JsonConvert.DeserializeObject<Publicacion>(json);
                return publicacion;
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

        public async Task<bool> updatePublicacion(Publicacion publicacion)
        {
            try
            {
                string json = JsonConvert.SerializeObject(publicacion);
                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                Console.WriteLine("Publicacion: " + json);

                HttpResponseMessage resp = await cli.PutAsync($"http://localhost:8080/escuela_circo/publicaciones/modificar/{publicacion.id}", content);
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

        public async Task<bool> addPublicacion(Publicacion publicacion, MultipartFormDataContent file)
        {
            try
            {
                string json = JsonConvert.SerializeObject(publicacion);
                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await cli.PostAsync("http://localhost:8080/escuela_circo/publicaciones/insertar", content);
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

        public async Task<bool> AddPublicacionAsync(Publicacion publicacion, string rutaArchivo)
        {
            using (var form = new MultipartFormDataContent())
            {
                // Serializar el objeto Publicacion a JSON
                string jsonPublicacion = JsonConvert.SerializeObject(publicacion);
                form.Add(new StringContent(jsonPublicacion, System.Text.Encoding.UTF8, "application/json"), "publicacion");

                // Adjuntar el archivo
                var fileStream = File.OpenRead(rutaArchivo);
                var fileName = Path.GetFileName(rutaArchivo);
                form.Add(new StreamContent(fileStream), "fichero", fileName);

                // Realizar la petición POST
                string url = "http://localhost:8080/escuela_circo/publicaciones/insertar";
                HttpResponseMessage resp = await cli.PostAsync(url, form);

                fileStream.Close();

                if (resp.IsSuccessStatusCode)
                    return true;

                string error = await resp.Content.ReadAsStringAsync();
                MessageBox.Show($"Error: {resp.StatusCode}\n{error}");
                return false;
            }
        }

        public async Task<bool> deletePublicacion(int id)
        {
            try
            {
                HttpResponseMessage resp = await cli.DeleteAsync($"http://localhost:8080/escuela_circo/publicaciones/eliminar/{id}");
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
