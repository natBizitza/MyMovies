using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MyMovies
{
    class Movies
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["MOVIES"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;

        private string movie, rentals;

        public void ShowAllMovies()
        {
            SqlDataReader registros;

            Console.WriteLine("Available Movies: ");
            //Console.ReadLine();

            conexion.Open();
            
            cadena = "SELECT MovieName FROM MOVIE where Availability='A'";
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();

            // to show the available rooms
            while (registros.Read())
            {
                Console.WriteLine(registros["MovieName"].ToString());
                Console.WriteLine();
            }
            Console.ReadLine();
            conexion.Close();
        }

    }
}
