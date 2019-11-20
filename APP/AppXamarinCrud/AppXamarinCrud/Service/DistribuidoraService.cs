using MVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MVVM.Service
{
    public class DistribuidoraService
    {
        public ObservableCollection<Distribuidora> Distribuidoras { get; set; }
        private const string apiUrl = "http://192.168.103.68:40089/api/Distribuidoras";

        public DistribuidoraService()
        {
            if (Distribuidoras == null)
            {
                Distribuidoras = new ObservableCollection<Distribuidora>();
            }
        }
        
        public async System.Threading.Tasks.Task<ObservableCollection<Distribuidora>> Consultar(){
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigurationManager.AppSettings["token"].ToString());
                    client.Timeout = TimeSpan.FromMinutes(10);
                    client.Timeout = new TimeSpan(0, 0, 0, 0, -1);
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Distribuidoras = JsonConvert.DeserializeObject<ObservableCollection<Distribuidora>>(result);
                        for (int i = 0; i < Distribuidoras.Count; i++)
                        {
                            Console.WriteLine(string.Concat(Distribuidoras[i].Id, " _ ", Distribuidoras[i].Nombre, " _ ", Distribuidoras[i].NumeroJuegosPublicados, " _ ", Distribuidoras[i].Imagen, " _ "));
                        }
                    }
                }
                return Distribuidoras;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async System.Threading.Tasks.Task Guardar(Distribuidora modelo)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigurationManager.AppSettings["token"].ToString());
                    client.Timeout = TimeSpan.FromMinutes(10);
                    client.Timeout = new TimeSpan(0, 0, 0, 0, -1);
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = JsonConvert.SerializeObject(modelo);
                        Console.WriteLine(string.Concat(modelo.Id, " _ ", modelo.Nombre, " _ ", modelo.NumeroJuegosPublicados, " _ ", modelo.Imagen, " _ "));
                        await client.PostAsync(apiUrl, new StringContent(result));
                        Distribuidoras.Add(modelo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Modificar(Distribuidora modelo)
        {
            for (int i = 0; i < Distribuidoras.Count; i++)
            {
                if (Distribuidoras[i].Id == modelo.Id)
                {
                    Distribuidoras[i] = modelo;
                }
            }
        }

        public void Eliminar(string idDistribuidora)
        {
            Distribuidora model = Distribuidoras.FirstOrDefault(d => d.Id == idDistribuidora);
            Distribuidoras.Remove(model);
        }

    }
}
