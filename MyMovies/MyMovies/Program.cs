using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MyMovies
{
    class Program
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["MOVIES"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;

        static void Main(string[] args)
        {
            User newUser1 = new User();
            Movies newMovie = new Movies();

            //newUser1.RegisterUser();
            //newUser1.LogIn();
            newMovie.ShowAllMovies();



            Console.ReadLine();
        }
    }
}
