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

        //List<User> registeredUser = new List <User>();

        static void Main(string[] args)
        {
            //const int REGISTER = 1, LOGIN = 2, EXIT = 3;

            //User newUser1 = new User();
            //Movies newMovie = new Movies();


            ////newUser1.RegisterUser();
            //newUser1.LogIn();
            ////newMovie.ShowAllMovies();

            Menu();

            Console.ReadLine();
        }
        public static void Menu()
        {

            const int REGISTER = 1, LOGIN = 2, EXIT = 3;
            int option;
            Console.WriteLine("WELCOME to MyMovies");

            do
            {
                // Menú principal
                Console.WriteLine("Choose an option");
                Console.WriteLine("1- Register as a MymMovies user");
                Console.WriteLine("2- Log In");
                Console.WriteLine("3- Exit Menu");
                option = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();
                switch (option)
                {
                    case REGISTER:
                        RegisterUser();
                        break;
                    case LOGIN:
                        LogIn();
                        break;
                    case EXIT:
                        Console.WriteLine("You are out of MyMovies. Thanks for visiting!");
                        break;
                }
            } while (option!=3);
        }
        public static void RegisterUser()
        {
            string username, name, password;
            //change it
            string dateOfBirth;

            Console.WriteLine("Welcome to MyMovies!\nPlease, enter your Username: ");
            username = Console.ReadLine();
            Console.WriteLine("Enter your Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter your date of birth (dd/MM/YYYY): ");
            dateOfBirth = Console.ReadLine();
            //Console.WriteLine("Enter your month of birth (MM): ");
            //month = Console.ReadLine();
            //Console.WriteLine("Enter your year of birth (yyyy): ");
            //year = Console.ReadLine();
            //string yourDateOfBirth = day + "/" + month + "/" + year;
            //Console.WriteLine("Your date of birth is " + yourDateOfBirth);
            Console.WriteLine("Enter your password: ");
            password = Console.ReadLine();

            Console.WriteLine("You are successfully signed up. Enjoy MyMovies!");

            conexion.Open();

            cadena = "INSERT INTO CLIENT VALUES ('" + username + "','" + name + "','" + dateOfBirth + "','" + password + "')";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();



            conexion.Close();

        }
        public static  void LogIn()
        {
            string username, password;

            bool IsRegistered = false;

            List<User> registeredUser = new List<User>();

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

                    User newUser = new User();
                    newUser.SetUsername(registros["UserName"].ToString());
                    newUser.SetName(registros["Name"].ToString());
                    newUser.SetDateBirth(registros["DateBirth"].ToString());
                    newUser.SetPassword(registros["Password"].ToString());

                    registeredUser.Add(newUser);

                    conexion.Close();
                    registros.Close();
                }
                //check the boolean below
            } while (!IsRegistered);
            Console.WriteLine("You are successfully logged in!");
        }
    }
}
