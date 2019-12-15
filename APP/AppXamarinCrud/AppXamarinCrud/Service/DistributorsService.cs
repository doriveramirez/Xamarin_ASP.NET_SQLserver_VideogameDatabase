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
    public class DistributorsService
    {
        private ObservableCollection<Distributor> Distributors;
        private string apiUrl;

        public DistributorsService()
        {
            using (var data = new DataAccess())
            {
                apiUrl = data.GetConnection().Url + "/api/Distributors";
            }
            if (Distributors == null)
            {
                Distributors = new ObservableCollection<Distributor>();
            }
        }

        public async System.Threading.Tasks.Task<ObservableCollection<Distributor>> Consult()
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
                        Distributors = JsonConvert.DeserializeObject<ObservableCollection<Distributor>>(result);
                    } 
                }
                return Distributors;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObservableCollection<Distributor> ConsultLocal()
        {
            using (var data = new DataAccess())
            {
                var list = data.GetDistributors();
                foreach (var item in list)
                    Distributors.Add(item);
            }
            return Distributors;
        }

        public async void Save(Distributor model)
        {
            try
            {
                HttpClient client;
                using (client = new HttpClient())
                {
                    client = CreateClient();
                    var send = Newtonsoft.Json.JsonConvert.SerializeObject(model,
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

        public void SaveLocal(Distributor model)
        {
            using (var data = new DataAccess())
            {
                data.InsertDistributor(model);
            }
        }

        public async void Modify(Distributor model)
        {
            try
            {
                HttpClient client;
                using (client = new HttpClient())
                {
                    client = CreateClient();
                    var json = JsonConvert.SerializeObject(model);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    Uri apiUrl2 = new Uri(string.Format(apiUrl + "/{0}", model.Id));
                    HttpResponseMessage response = await client.PutAsync(apiUrl2, content);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void ModifyLocal(Distributor model)
        {
            using (var data = new DataAccess())
            {
                data.ModifyDistributor(model);
            }
        }

        public async void Delete(string idDistributor)
        {
            try
            {
                HttpClient client;
                using (client = new HttpClient())
                {
                    client = CreateClient();
                    HttpResponseMessage response = await client.DeleteAsync(apiUrl + "/" + idDistributor);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteLocal(Distributor model)
        {
            using (var data = new DataAccess())
            {
                data.DeleteDistributor(model);
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

