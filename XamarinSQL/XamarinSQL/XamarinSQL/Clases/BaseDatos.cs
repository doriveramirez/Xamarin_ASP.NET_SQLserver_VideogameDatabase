using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace XamarinSQL.Clases
{
    class BaseDatos
    {
        static string cadenaConexion = @"data source=localhost;initial catalog=Distribuidora;user id=admin;password=123456;Connect Timeout=60";

        public static List<Distribuidora> ObtenerDistribuidora()
        {
            List<Distribuidora> listaDistribuidora = new List<Distribuidora>();
            string sql = "SELECT * FROM Distribuidora";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Distribuidora distribuidora = new Distribuidora()
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                NumeroJuegosPublicados = reader.GetInt32(2)
                            };
                            listaDistribuidora.Add(distribuidora);
                        }
                    }
                }
                con.Close();
                return listaDistribuidora;
            }
        }

        public static void AgregarDistribuidora(Distribuidora distribuidora)
        {
            string sql = "INSERT INTO Distribuidora (Nombre,NumeroJuegosPublicados) VALUES(@nombre, @NumeroJuegosPublicados)";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    //comando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = distribuidora.Nombre;
                    //comando.Parameters.Add("@NumeroJuegosPublicados", SqlDbType.Int).Value = distribuidora.NumeroJuegosPublicados;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }
                con.Close();
            }
        }

        public static void ModificarDistribuidora(Distribuidora distribuidora)
        {
            string sql = "UPDATE Distribuidora set Nombre = @nombre, NumeroJuegosPublicados = @NumeroJuegosPublicados WHERE ID = @id";
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();
                    using (SqlCommand comando = new SqlCommand(sql, con))
                    {
                        //comando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = distribuidora.Nombre;
                        //comando.Parameters.Add("@salario", SqlDbType.Int).Value = distribuidora.NumeroJuegosPublicados;
                        //comando.Parameters.Add("@id", SqlDbType.Int).Value = distribuidora.Id;
                        comando.CommandType = CommandType.Text;
                        comando.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void EliminarDistribuidora(Distribuidora distribuidora)
        {
            string sql = "DELETE FROM Distribuidora WHERE ID = @id";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand(sql, con))
                {
                    //comando.Parameters.Add("@id", SqlDbType.Int).Value = distribuidora.Id;
                    comando.CommandType = CommandType.Text;
                    comando.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}
