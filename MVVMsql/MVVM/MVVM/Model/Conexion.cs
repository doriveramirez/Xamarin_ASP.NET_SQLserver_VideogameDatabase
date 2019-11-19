using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;
using NLog.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public class Conexion
    {

        private const string apiUrl = "http://192.168.103.68:40080/api/Distribuidoras";
        //private const string apiUrl = "http://tgconsulting.online/tg-rest/servicio.php/cursos";

        public async void Obtain()
        {
            HttpClient client = new HttpClient();

            String url = "http://192.168.103.68:40089/api/Values?type=json";

            Console.WriteLine("hola");

            var result = await client.GetStringAsync(url);

            Console.WriteLine("bobosoyysere");

            var resultAux = result;
        }

            public async Task<ObservableCollection<Distribuidora>> ObtenerDistribuidora()
        {
            ObservableCollection<Distribuidora> Distribuidores = null;
            HttpClient client = new HttpClient();

            String url = "http://192.168.103.68:40089/api/Values?type=json";

            Console.WriteLine("asdfg");

            var result = await client.GetStringAsync(url);

            Console.WriteLine("bobosoyysere");

            var resultAux = result;
            //Console.WriteLine(apiUrl);
            //Console.WriteLine("dos");
            ////List<Distribuidora> lista;
            //HttpClient client = new HttpClient();
            ////HttpResponseMessage result = await client.GetAsync("http://192.168.103.68:40080/api/Values");
            //var result = await client.GetStringAsync("http://192.168.103.68:40089/api/Values?type=json");
            //Console.WriteLine("adios");
            ////var json = result.Content.ReadAsStringAsync().Result;
            //Console.WriteLine("hola");
            return Distribuidores;
            //httpMethod = httpVerb.GET;
            //string strResponseValue = string.Empty;
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            //request.Method = httpMethod.ToString();
            //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //{
            //    if (response.StatusCode != HttpStatusCode.OK)
            //    {
            //        throw new ApplicationException("error code: " + response.StatusCode);
            //    }
            //    using(Stream responseStream = response.GetResponseStream())
            //    {
            //        if(responseStream != null)
            //        {
            //            using(StreamReader reader = new StreamReader(responseStream))
            //            {
            //                strResponseValue = reader.ReadToEnd();
            //                lista = JsonConvert
            //                    .DeserializeObject<List<Distribuidora>>(strResponseValue.ToString()
            //                    , new JsonSerializerSettings()
            //                    {
            //                        MissingMemberHandling =
            //                            MissingMemberHandling.Ignore
            //                    });
            //                Console.WriteLine("catorce");
            //                foreach (var item in lista)
            //                    Distribuidores.Add(item);
            //            }
            //        }
            //    }
            //}
            //Console.WriteLine("hola");

            //Console.WriteLine("uno");

            //Console.WriteLine("tres");
            //try
            //{
            //    using (HttpClient client = new HttpClient())
            //    {
            //        Console.WriteLine("cuatro");
            //        HttpResponseMessage response2 = await client.GetAsync("http://localhost:40080/api/Values");
            //        Console.WriteLine("cuatro2");
            //        using (HttpResponseMessage response = await client.GetAsync("http://localhost:40080/api/Distribuidoras"))
            //        {
            //            Console.WriteLine("cinco");
            //            using (HttpContent content = response.Content)
            //            {
            //                Console.WriteLine("seis");

            //                Console.WriteLine("quince");
            //            }
            //        }
            //    }
            //    Console.WriteLine("hola " + Distribuidores);

            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
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
