using AppXamarinCrud.Model;
using MVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using VideogameDatabase.Service;

namespace MVVM.Service
{
    public class PlatformsService
    {
        public ObservableCollection<Platform> Platforms { get; set; }
        private string apiUrl;

        public PlatformsService()
        {
            using (var data = new DataAccess())
            {
                apiUrl = data.GetConnection().Url + "/api/Distributors";
            }
            if (Platforms == null)
            {
                Platforms = new ObservableCollection<Platform>();
            }
        }

        public async System.Threading.Tasks.Task<ObservableCollection<Platform>> Consult()
        {
            try
            {
                HttpClient client;
                using (client = new HttpClient())
                {
                    client = CreateClient();
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Platforms = JsonConvert.DeserializeObject<ObservableCollection<Platform>>(result);
                    }
                }
                return Platforms;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObservableCollection<Platform> ConsultLocal()
        {
            using (var data = new DataAccess())
            {
                var list = data.GetPlatforms();
                foreach (var item in list)
                    Platforms.Add(item);
            }
            return Platforms;
        }

        public async void Save(Platform modelo)
        {
            try
            {
                HttpClient client;
                using (client = new HttpClient())
                {
                    client = CreateClient();
                    var send = Newtonsoft.Json.JsonConvert.SerializeObject(modelo,
                            Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "");
                    request.Content = new StringContent(send, Encoding.UTF8, "application/json");//CONTENT-TYPE header
                    HttpResponseMessage response = await client.SendAsync(request);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveLocal(Platform model)
        {
            using (var data = new DataAccess())
            {
                data.InsertPlatform(model);
            }
        }

        public async void Modify(Platform modelo)
        {
            try
            {
                HttpClient client;
                using (client = new HttpClient())
                {
                    client = CreateClient();
                    var json = JsonConvert.SerializeObject(modelo);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    Uri apiUrl2 = new Uri(string.Format(apiUrl + "/{0}", modelo.Id));
                    HttpResponseMessage response = await client.PutAsync(apiUrl2, content);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModifyLocal(Platform model)
        {
            using (var data = new DataAccess())
            {
                data.ModifyPlatform(model);
            }
        }

        public async void Delete(string idPlatform)
        {
            try
            {
                HttpClient client;
                using (client = new HttpClient())
                {
                    client = CreateClient();
                    HttpResponseMessage response = await client.DeleteAsync(apiUrl + "/" + idPlatform);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteLocal(Platform model)
        {
            using (var data = new DataAccess())
            {
                data.DeletePlatform(model);
            }
        }

        private HttpClient CreateClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ConfigurationManager.AppSettings["token"].ToString());
            client.Timeout = TimeSpan.FromMinutes(10);
            client.Timeout = new TimeSpan(0, 0, 0, 0, -1);
            return client;
        }

    }
}

