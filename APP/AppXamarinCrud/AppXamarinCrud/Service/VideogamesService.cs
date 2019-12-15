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
using System.Threading.Tasks;
using VideogameDatabase.Service;

namespace MVVM.Service
{
    public class VideogamesService
    {
        public ObservableCollection<Videogame> Videogames { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Distributor> Distributors { get; set; }

        private string apiUrl, apiUrl3, apiUrl4;

        public VideogamesService()
        {
            using (var data = new DataAccess())
            {
                apiUrl = data.GetConnection().Url + "/api/Videogames";
                apiUrl3 = data.GetConnection().Url + "/api/Distributors";
                apiUrl4 = data.GetConnection().Url + "/api/Users";
            }
            if (Videogames == null)
            {
                Videogames = new ObservableCollection<Videogame>();
            }
            if (Users == null)
            {
                Users = new ObservableCollection<User>();
            }
            if (Distributors == null)
            {
                Distributors = new ObservableCollection<Distributor>();
            }
        }

        public async System.Threading.Tasks.Task<ObservableCollection<Videogame>> Consult()
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
                        Videogames = JsonConvert.DeserializeObject<ObservableCollection<Videogame>>(result);
                    }
                }
                return Videogames;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObservableCollection<Videogame> ConsultLocal()
        {
            using (var data = new DataAccess())
            {
                var list = data.GetVideogames();
                foreach (var item in list)
                    Videogames.Add(item);
            }
            return Videogames;
        }

        public async System.Threading.Tasks.Task<ObservableCollection<User>> ConsultUser()
        {
            try
            {
                HttpClient client;
                using (client = new HttpClient())
                {
                    client = CreateClient();
                    HttpResponseMessage response = await client.GetAsync(apiUrl4);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Users = JsonConvert.DeserializeObject<ObservableCollection<User>>(result);
                    }
                }
                return Users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObservableCollection<User> ConsultUserLocal()
        {
            using (var data = new DataAccess())
            {
                var list = data.GetUsers();
                foreach (var item in list)
                    Users.Add(item);
            }
            return Users;
        }

        public async Task<ObservableCollection<Distributor>> ConsultDistributor()
        {
            try
            {
                HttpClient client;
                using (client = new HttpClient())
                {
                    client = CreateClient();
                    HttpResponseMessage response = await client.GetAsync(apiUrl3);
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

        public ObservableCollection<Distributor> ConsultDistributorLocal()
        {
            using (var data = new DataAccess())
            {
                var list = data.GetDistributors();
                foreach (var item in list)
                    Distributors.Add(item);
            }
            return Distributors;
        }

        public async void Save(Videogame modelo)
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

        public void SaveLocal(Videogame model)
        {
            using (var data = new DataAccess())
            {
                data.InsertVideogame(model);
            }
        }

        public async void Modify(Videogame modelo)
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

        public void ModifyLocal(Videogame model)
        {
            using (var data = new DataAccess())
            {
                data.ModifyVideogame(model);
            }
        }

        public async void Delete(string idVideogame)
        {
            try
            {
                HttpClient client;
                using (client = new HttpClient())
                {
                    client = CreateClient();
                    HttpResponseMessage response = await client.DeleteAsync(apiUrl + "/" + idVideogame);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteLocal(Videogame model)
        {
            using (var data = new DataAccess())
            {
                data.DeleteVideogame(model);
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