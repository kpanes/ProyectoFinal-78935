using System;
using MySql.Data.MySqlClient;

namespace conexion
{
    public class Conexion
    {
        public Conexion(){
  
        }
        public MySqlConnection crearConexion()
        {
             string connectionString = "server=viaduct.proxy.rlwy.net;port=19015;user=root;password=sewVLiNNaggTBwFleZittDMmykguuvqX;database=integracion";
            MySqlConnection conexion = new MySqlConnection(connectionString);
            try
            {
                conexion.Open();
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Conexión exitosa");
                }
                else
                {
                    Console.WriteLine("La conexión no se pudo abrir.");
                }
                return conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de dato: " + ex.Message);
                return null;
            }
        }
        public void cerrarConexion(MySqlConnection conexion){
            conexion.Close();
        }
    }
}