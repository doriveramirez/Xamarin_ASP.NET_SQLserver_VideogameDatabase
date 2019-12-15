using AppXamarinCrud.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VideogameDatabase.Model;
using VideogameDatabase.Service;
using Xamarin.Forms;

namespace AppXamarinCrud.Service
{
    class OptionsService
    {

        private Connection connection { get; set; }

        public OptionsService()
        {
            if (connection == null)
            {
                connection = new Connection();
            }
        }

        public Connection ConsultLocal()
        {
            using (var data = new DataAccess())
            {
                connection = data.GetConnection();
            }
            return connection;
        }

        public async System.Threading.Tasks.Task<bool> SaveLocalAsync(Connection con)
        {
            using (var data = new DataAccess())
            {
                data.InsertConnection(con);
            }
            try
            {
                HttpClient client;
                using (client = new HttpClient())
                {
                    client.GetAsync(con.Url).Result.EnsureSuccessStatusCode();
                    HttpResponseMessage response = await client.GetAsync(con.Url);
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }
    }
}
