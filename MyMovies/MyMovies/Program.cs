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
        static List<User> registeredUser;
        static List<Movies> allMoviesForUser;
        static List<Rents> rentsOfUser;
        static List<Movies> myMovies;
        static private User user;
        static private Movies movie;
        static private Rents rentedMovie;


        static void Main(string[] args)
        {
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
                Console.WriteLine("1- Register as a MyMovies user");
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
                        UserMenu();
                        break;
                    case EXIT:
                        Console.WriteLine("You are out of MyMovies. Thanks for visiting!");
                        break;
                }
            } while (option!= EXIT);
        }

        public static void UserMenu()
        {
            const int MYMOVIES = 1, ALLMOVIES = 2, RENTMOVIE = 3, LOGOUT = 4;
            int option;
            Console.WriteLine("WELCOME to MyMovies");

            do
            {
                // Menú principal
                Console.WriteLine("Choose an option");
                Console.WriteLine("1 - See the movies I am currently renting.");
                Console.WriteLine("2 - Available for me movies.");
                Console.WriteLine("3 - Rent a movie");
                Console.WriteLine("4 - Log Out");

                option = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();
                switch (option)
                {
                    case MYMOVIES:
                        MyRents();
                        break;
                    case ALLMOVIES:
                        ShowAllMovies();
                        //RentMovie();
                        break;
                    case RENTMOVIE:
                        RentMovie();
                        break;
                    case LOGOUT:
                        Console.WriteLine("You are back to the main menu.");
                        break;
                }
            } while (option!=LOGOUT);
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
            Console.WriteLine("Enter your password: ");
            password = Console.ReadLine();

            Console.WriteLine("You are successfully signed up. Enjoy MyMovies!");

            conexion.Open();

            cadena = "INSERT INTO CLIENT VALUES ('" + username + "','" + movie + "','" + dateOfBirth + "','" + password + "')";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();



            conexion.Close();

        }

        public static  void LogIn()
        {
            string username, password;

            bool IsRegistered = false;

            registeredUser = new List<User>();

            Console.WriteLine("**************** LOG IN **********************");
            do
            {
                Console.WriteLine("Username: ");
                username = Console.ReadLine();

                Console.WriteLine("Password: ");
                password = Console.ReadLine();

                SqlDataReader reg;
                //to check if the username and password are correct
                conexion.Open();
                cadena = "SELECT * from CLIENT where UserName LIKE '" + username + "' and Password LIKE '" + password + "'"; 
                comando = new SqlCommand(cadena, conexion);
                reg = comando.ExecuteReader();
                IsRegistered = reg.Read();
                if (!IsRegistered)
                {

                    Console.WriteLine("Username or password is not correct. Try again.");
                }
                else
                {
                    //create new object
                    user = new User();
                    user.SetUsername(reg["UserName"].ToString());
                    user.SetName(reg["Name"].ToString());
                    user.SetDateBirth(reg["DateBirth"].ToString());
                    user.SetPassword(reg["Password"].ToString());

                    //no idea  if it's necessary yet
                    //registeredUser.Add(user);
                }
                conexion.Close();
                reg.Close();
            } while (!IsRegistered);

            Console.WriteLine("You are successfully logged in!");

            //generate a list of movies for this user

            SqlDataReader age;
            int compareAge;
            //string username;
            conexion.Open();

            cadena = "SELECT DATEDIFF(year,DateBirth,GETDATE()) AS filter FROM CLIENT WHERE UserName LIKE '" + user.GetUsername() + "'";

            comando = new SqlCommand(cadena, conexion);
            age = comando.ExecuteReader();

            age.Read();
            // extracting from the query array the result from the column filter
            compareAge = Convert.ToInt32(age["filter"].ToString());

            conexion.Close();

            SqlDataReader registros;

            conexion.Open();

            cadena = "SELECT IdMovie, MovieName, Director, CountryOfOrigin, Synopsis, AgeRestriction, Availability FROM MOVIE where AgeRestriction<= " + compareAge;
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();

            allMoviesForUser = new List<Movies>();
         
            while (registros.Read())
            {
                Console.WriteLine("ID: " + registros["IdMovie"].ToString());
                Console.WriteLine("Name: " + registros["MovieName"].ToString());
                Console.WriteLine("Director: " + registros["Director"].ToString());
                Console.WriteLine("Country of Origin: " + registros["CountryOfOrigin"].ToString());
                Console.WriteLine("Synopsis: " + registros["Synopsis"].ToString());
                Console.WriteLine("Age Restriction: " + registros["AgeRestriction"].ToString());
                Console.WriteLine("Availability (A/N): " + registros["Availability"].ToString());

                movie = new Movies();

                movie.SetIdMovie(registros["IdMovie"].ToString());
                movie.SetName(registros["MovieName"].ToString());
                movie.SetDirector(registros["Director"].ToString());
                movie.SetCountry(registros["CountryOfOrigin"].ToString());
                movie.SetSynopsis(registros["Synopsis"].ToString());
                movie.SetAge(registros["AgeRestriction"].ToString());
                movie.SetAvailab(registros["Availability"].ToString());

                //adding all movies for this user in one list
                allMoviesForUser.Add(movie);
            }
            conexion.Close();
        }

        public static void ShowAllMovies()
        {

            Console.WriteLine("All movies availablefor you:\n");

            foreach (Movies movie in allMoviesForUser)
            {
                Console.WriteLine(movie.MostrarDatos() + "\n");

            }

        }

        public static void RentMovie()
        {
            string  answer = "";

            //the list with rents of the user
            rentsOfUser = new List<Rents>();
            myMovies = new List<Movies>();

            Console.WriteLine("************ YOU ARE ABOUT TO HAVE IT ***************\n");

            // to show all movies with availab= "A"
            foreach (Movies movie in allMoviesForUser)
            {
                if (movie.GetAvailab().Contains("A"))
                {
                    Console.WriteLine(movie.MostrarDatos() + "\n");
                }

            }

            do
            {
                Console.WriteLine("Choose a movie ID from the list above (ID): ");
               int  movieChoice = Convert.ToInt32(Console.ReadLine());

                if (Convert.ToInt32(movie.GetIdMovie())-1 == movieChoice)
                {
                    //update table MOVIE, change availability to N
                    conexion.Open();

                    cadena = "UPDATE MOVIE SET Availability = 'N' where IdMovie= '" + movieChoice + "'";
                    comando = new SqlCommand(cadena, conexion);
                    comando.ExecuteNonQuery();

                    conexion.Close();


                    //Update table RENTS
                    conexion.Open();

                    rentedMovie = new Rents();

                    cadena = "INSERT INTO RENTS (UserName, IdMovie, RentDeadline) VALUES ('" + user.GetUsername() + "','" + movieChoice + "','" + rentedMovie.GetDeadline().ToString("yyyy/mm/dd") + "')";
                    comando = new SqlCommand(cadena, conexion);                   
                    comando.ExecuteNonQuery();
                    conexion.Close();

                    Console.WriteLine("You are ready to watch " + movie.GetName() + " Your rent expires in 10 days. Enjoy!\n");
                    Console.ReadLine();
                };

                Console.WriteLine("Would you like to rent another movie? (S/N)");
                answer = Console.ReadLine();

            } while (answer.ToUpper() != "N") ;
                Console.WriteLine("Thanks for your order!");
        }

        public static void MyRents()
        {
            DateTime thisDay = DateTime.Now;
            SqlDataReader registros;
            conexion.Open();

            //joining two tables(RENTS & MOVIE)  
            cadena = "SELECT [IdRent],r.IdMovie, UserName, MovieName,[RentDeadline] FROM RENTS r, [MOVIE]c WHERE r.IdMovie=c.IdMovie and UserName Like '" + user.GetUsername() + "'";
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();

            // to show my rents
            while (registros.Read())
            {
                Console.WriteLine("Rent ID: " + registros["IdRent"].ToString());
                Console.WriteLine("Movie ID: " + registros["IdMovie"].ToString());
                Console.WriteLine("Username: " + registros["UserName"].ToString());
                Console.WriteLine("Movie: " + registros["MovieName"].ToString());

                if (Convert.ToDateTime(registros["RentDeadline"].ToString()) > thisDay)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(registros["RentDeadline"].ToString());
                    Console.ResetColor();

                    Console.WriteLine("Your rent is expired. See you soon!");
                }
                else
                {
                   
                    Console.WriteLine(registros["RentDeadline"].ToString());

                }
                Console.WriteLine();
            }
            conexion.Close();
        }

    }
}
