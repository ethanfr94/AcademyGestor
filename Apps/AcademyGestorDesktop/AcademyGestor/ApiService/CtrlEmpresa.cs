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
    internal class CtrlEmpresa
    {
        private HttpClient cli;

        public CtrlEmpresa()
        {
            cli = new HttpClient();
        }


        public async Task<Empresa> getEmpresa()
        {
            try
            {
                Empresa empresa = new Empresa();
                HttpResponseMessage resp = await cli.GetAsync($"http://localhost:8080/escuela_circo/empresa");
                resp.EnsureSuccessStatusCode();
                string json = await resp.Content.ReadAsStringAsync();
                empresa = JsonConvert.DeserializeObject<Empresa>(json);
                return empresa;
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
