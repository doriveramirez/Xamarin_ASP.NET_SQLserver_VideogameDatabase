//using HtmlAgilityPack;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;
using NLog.Internal;
//using NLog.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
//using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;

namespace MVVM.Model
{
    public class Conexion
    {

        private const string apiUrl = "http://192.168.103.68:40089/api/Distribuidoras?type=json";

            public async Task<ObservableCollection<Distribuidora>> ObtenerDistribuidora()
        {
            ObservableCollection<Distribuidora> Distribuidoras = null;

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
                        Distribuidora[] distribuidoras = Distribuidora.FromJson(result);
                        Distribuidoras = JsonConvert.DeserializeObject<ObservableCollection<Distribuidora>>(result);
                        Console.WriteLine(distribuidoras.ToString());
                    }
                }
                return Distribuidoras;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async void LlenarBicicletas()
        {
            HttpClient client = new HttpClient();

            String url = "http://192.168.103.86:40089/api/Values?type=json";
            Console.WriteLine("hola " + url);

            //var result = await client.GetStringAsync(url);

            Console.WriteLine("bobosoyysere");


            //var bicycles = JsonConvert.DeserializeObject<List<Bicycle>>(result);
            //Console.WriteLine("hola");


            var result = await client.GetAsync(url);
            var json = result.Content.ReadAsStringAsync().Result;
            Distribuidora[] distribuidoras = Distribuidora.FromJson(json);

            //LvDistribuidoras.ItemsSource = distribuidoras;

        }

        //public static void AgregarDistribuidora(Distribuidora distribuidora)
        //{
        //    string sql = "INSERT INTO Distribuidora (Nombre,NumeroJuegosPublicados) VALUES(@nombre, @NumeroJuegosPublicados)";
        //    using (SqlConnection con = new SqlConnection(cadenaConexion))
        //    {
        //        con.Open();
        //        using (SqlCommand comando = new SqlCommand(sql, con))
        //        {
        //            comando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = distribuidora.Nombre;
        //            comando.Parameters.Add("@NumeroJuegosPublicados", SqlDbType.Int).Value = distribuidora.NumeroJuegosPublicados;
        //            comando.CommandType = CommandType.Text;
        //            comando.ExecuteNonQuery();
        //        }
        //        con.Close();
        //    }
        //}

        //public static void ModificarDistribuidora(Distribuidora distribuidora)
        //{
        //    string sql = "UPDATE Distribuidora set Nombre = @nombre, NumeroJuegosPublicados = @NumeroJuegosPublicados WHERE ID = @id";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(cadenaConexion))
        //        {
        //            con.Open();
        //            using (SqlCommand comando = new SqlCommand(sql, con))
        //            {
        //                comando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = distribuidora.Nombre;
        //                comando.Parameters.Add("@salario", SqlDbType.Int).Value = distribuidora.NumeroJuegosPublicados;
        //                comando.Parameters.Add("@id", SqlDbType.Int).Value = distribuidora.Id;
        //                comando.CommandType = CommandType.Text;
        //                comando.ExecuteNonQuery();
        //            }
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //public static void EliminarDistribuidora(Distribuidora distribuidora)
        //{
        //    string sql = "DELETE FROM Distribuidora WHERE ID = @id";
        //    using (SqlConnection con = new SqlConnection(cadenaConexion))
        //    {
        //        con.Open();
        //        using (SqlCommand comando = new SqlCommand(sql, con))
        //        {
        //            comando.Parameters.Add("@id", SqlDbType.Int).Value = distribuidora.Id;
        //            comando.CommandType = CommandType.Text;
        //            comando.ExecuteNonQuery();
        //        }
        //        con.Close();
        //    }
        //}
    }
}
