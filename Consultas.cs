using System;
using MySql.Data.MySqlClient;
namespace consultas
{
    public class Consultas
    {
        public Consultas()
        {

        }

        public List<string> ObtenerProductos(MySqlConnection conexion)
        {
            List<string> productos = new List<string>();
            string query = "SELECT  nombre, precio, fecha FROM producto"; // Ajusta los campos según tus necesidades

            MySqlCommand cmd = new MySqlCommand(query, conexion);

            try
            {
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {

                        string nombreProducto = rdr.GetString("nombre");
                        double precio = rdr.GetDouble("precio");
                        DateTime fecha = rdr.GetDateTime("fecha");

                        string productoInfo = $"Nombre: {nombreProducto}, Precio: {precio}, Fecha: {fecha.ToShortDateString()}";
                        productos.Add(productoInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los productos: " + ex.Message);
            }

            return productos;
        }



        public bool AgregarProducto(string nombre, double precio, DateTime fecha, MySqlConnection conexion)
        {
            bool bandera = false;
            string query = "INSERT INTO producto (nombre, precio, fecha) VALUES (@nombre, @precio, @fecha)";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.Parameters.AddWithValue("@fecha", fecha);

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    bandera = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar el producto: " + ex.Message);
            }
            return bandera;
        }


        public string ObtenerProducto(int id, MySqlConnection conexion)
        {
            string producto = "";
            string query = "SELECT nombre, precio, fecha FROM producto WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        string nombre = rdr.GetString("nombre");
                        double precio = rdr.GetDouble("precio");
                        DateTime fecha = rdr.GetDateTime("fecha");

                        producto = $"Nombre: {nombre}, Precio: {precio}, Fecha: {fecha.ToShortDateString()}";
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró el producto con ID: {id}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el producto: " + ex.Message);
            }

            return producto;
        }



    }



}
