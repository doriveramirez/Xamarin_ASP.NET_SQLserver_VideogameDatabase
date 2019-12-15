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
    public class CompaniesService
    {
        public ObservableCollection<Company> Companies { get; set; }
        private string apiUrl;

        public CompaniesService()
        {
            using (var data = new DataAccess())
            {
                apiUrl = data.GetConnection().Url + "/api/Companies";
            }
            if (Companies == null)
            {
                Companies = new ObservableCollection<Company>();
            }
        } 

        public async System.Threading.Tasks.Task<ObservableCollection<Company>> Consult()
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
                        Companies = JsonConvert.DeserializeObject<ObservableCollection<Company>>(result);
                    }
                }
                return Companies;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObservableCollection<Company> ConsultLocal()
        {
            using (var data = new DataAccess())
            {
                var list = data.GetCompanies();
                foreach (var item in list)
                    Companies.Add(item);
            }
            return Companies;
        }

        public async void Save(Company model)
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

        public void SaveLocal(Company model)
        {
            using (var data = new DataAccess())
            {
                data.InsertCompany(model);
            }
        }

        public async void Modify(Company model)
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
                    Console.WriteLine(response.IsSuccessStatusCode);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModifyLocal(Company model)
        {
            using (var data = new DataAccess())
            {
                data.ModifyCompany(model);
            }
        }

        public async void Delete(string idCompany)
        {
            try
            {
                HttpClient client;
                using (client = new HttpClient())
                {
                    client = CreateClient();
                    HttpResponseMessage response = await client.DeleteAsync(apiUrl + "/" + idCompany);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteLocal(Company model)
        {
            using (var data = new DataAccess())
            {
                data.DeleteCompany(model);
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
