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
    public class UsersService
    {
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Company> Companies { get; set; }

        private string apiUrl, apiUrl3;

        public UsersService()
        {
            using (var data = new DataAccess())
            {
                apiUrl = data.GetConnection().Url + "/api/Users";
                apiUrl3 = data.GetConnection().Url + "/api/Companies";
            }
            if (Users == null)
            {
                Users = new ObservableCollection<User>();
            }
            if (Companies == null)
            {
                Companies = new ObservableCollection<Company>();
            }
        }

        public async System.Threading.Tasks.Task<ObservableCollection<User>> Consult()
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

        public ObservableCollection<User> ConsultLocal()
        {
            using (var data = new DataAccess())
            {
                var list = data.GetUsers();
                foreach (var item in list)
                    Users.Add(item);
            }
            return Users;
        }

        public async System.Threading.Tasks.Task<ObservableCollection<Company>> ConsultCompany()
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

        public ObservableCollection<Company> ConsultCompanyLocal()
        {
            using (var data = new DataAccess())
            {
                var list = data.GetCompanies();
                foreach (var item in list)
                    Companies.Add(item);
            }
            return Companies;
        }

        public async void Save(User modelo)
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

        public void SaveLocal(User model)
        {
            using (var data = new DataAccess())
            {
                data.InsertUser(model);
            }
        }

        public async void Modify(User modelo)
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

        public void ModifyLocal(User model)
        {
            using (var data = new DataAccess())
            {
                data.ModifyUser(model);
            }
        }

        public async void Delete(string idUser)
        {
            try
            {
                HttpClient client;
                using (client = new HttpClient())
                {
                    client = CreateClient();
                    HttpResponseMessage response = await client.DeleteAsync(apiUrl + "/" + idUser);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteLocal(User model)
        {
            using (var data = new DataAccess())
            {
                data.DeleteUser(model);
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
