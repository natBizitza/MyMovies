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
        public static  void LogIn()
        {
            string username, password;

            bool IsRegistered = false;

            Console.WriteLine("**************** LOG IN **********************");
            do
            {
                Console.WriteLine("Username: ");
                username = Console.ReadLine();

                Console.WriteLine("Password: ");
                password = Console.ReadLine();

                //TODO: add condition if password==pasword and username==username -> user menu
                conexion.Open();
                cadena = "SELECT * from CLIENT where UserName LIKE '" + username + "'";
                cadena = "SELECT * from CLIENT where Password LIKE '" + password + "'";
                comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                IsRegistered = registros.Read();
                if (!IsRegistered)
                {

                    Console.WriteLine("Username or password is not correct. Try again.");
                }
                else
                {
                    
                    User u1 = new User();
                    u1.SetName(registros["UserName"].ToString());
                    //all the attributes
                    u1.SetName

                conexion.Close();
                registros.Close();
                //check the boolean below
            } while (!IsRegistered);
            Console.WriteLine("You are successfully logged in!");
        }
    }
}
