using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using conexion;  // Cambia esto por el namespace correcto de tu clase Conexion
using consultas;
using Microsoft.AspNetCore.Identity; // Cambia esto por el namespace correcto de tu clase Consultas
using iproductos;

namespace productos // Cambia esto por el namespace correcto
{
    public class Productos : iProductos
    {
        Conexion conexion = new Conexion();
        Consultas consultas = new Consultas();

        public List<string> historialProductos()
        {
            List<string> productos = new List<string>();

            using (MySqlConnection conexion = this.conexion.crearConexion())
            {
                productos = consultas.ObtenerProductos(conexion);
            }

            return productos;
        }

        public string agregarProducto(string nombre, double precio)
        {
            DateTime fechaActual = DateTime.Today;
            string bandera = "";

            using (MySqlConnection conexion = this.conexion.crearConexion())
            {
                if (consultas.AgregarProducto(nombre, (double)precio, fechaActual, conexion))
                {
                    bandera = "Producto agregado correctamente";
                }
                else
                {
                    bandera = "No se pudo agregar el producto";
                }
            }

            return bandera;
        }

         public string solicitarProducto(int id)
        {
            string productoInfo = "";

            try
            {
                using (MySqlConnection conexionBD = conexion.crearConexion())
                {
                    productoInfo = consultas.ObtenerProducto(id, conexionBD);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al solicitar el producto: " + ex.Message);
                productoInfo = "Error al solicitar el producto. Consulta el registro para más detalles.";
            }

            return productoInfo;
        }
    }
}

