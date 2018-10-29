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
        //static List<User> registeredUser;
        static List<Movies> allMoviesForUser;
        static List<Rents> rentsOfUser;
        static List<Movies> myMovies;
        static private User user;
        static private Movies movie;
        static private Rents rentedMovie;


        //static private string username, name, password;

        static void Main(string[] args)
        {
            //List<User> registeredUser = new List<User>();
            ////const int REGISTER = 1, LOGIN = 2, EXIT = 3;

            //User newUser = new User();
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

            cadena = "INSERT INTO CLIENT VALUES ('" + username + "','" + movie + "','" + dateOfBirth + "','" + password + "')";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();



            conexion.Close();

        }

        public static  void LogIn()
        {
            string username, password;

            bool IsRegistered = false;

            //List<User> registeredUser = new List<User>();

            Console.WriteLine("**************** LOG IN **********************");
            do
            {
                Console.WriteLine("Username: ");
                username = Console.ReadLine();

                Console.WriteLine("Password: ");
                password = Console.ReadLine();

                //TODO: add condition if password==pasword and username==username -> user menu
                conexion.Open();
                cadena = "SELECT * from CLIENT where UserName LIKE '" + username + "' and Password LIKE '" + password + "'"; 
                comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                IsRegistered = registros.Read();
                if (!IsRegistered)
                {

                    Console.WriteLine("Username or password is not correct. Try again.");
                }
                else
                {

                    user = new User();
                    user.SetUsername(registros["UserName"].ToString());
                    user.SetName(registros["Name"].ToString());
                    user.SetDateBirth(registros["DateBirth"].ToString());
                    user.SetPassword(registros["Password"].ToString());

                    //registeredUser.Add(user);

                    // to test the list of registereduser

                    //foreach (User person in registeredUser)
                    //{
                    //    Console.WriteLine(person.GetType().Name.ToUpper());
                    //    break;
                    //}

                    //conexion.Close();
                    //registros.Close();
                }
                conexion.Close();
                registros.Close();
                //check the boolean below
            } while (!IsRegistered);

            Console.WriteLine("You are successfully logged in!");

                //ShowAllMovies();
        }

        public static void ShowAllMovies()
        {
            SqlDataReader age;
            int compareAge;
            //string username;
            conexion.Open();

            //Console.WriteLine("Username:");
            //username = Console.ReadLine();

            cadena = "SELECT DATEDIFF(year,DateBirth,GETDATE()) AS filter FROM CLIENT WHERE UserName LIKE '" + user.GetUsername() + "'";
            //cadena = "SELECT DATEDIFF(year,DateBirth,GETDATE()) AS filter FROM CLIENT WHERE UserName LIKE 'Nat1994'";

            comando = new SqlCommand(cadena, conexion);
            age = comando.ExecuteReader();

            age.Read();
            // extracting from the query array the result from the column filter
            compareAge = Convert.ToInt32(age["filter"].ToString());



            conexion.Close();

            SqlDataReader registros;

            Console.WriteLine("Available Movies: ");
            Console.ReadLine();


            conexion.Open();

            cadena = "SELECT IdMovie, MovieName, Director, CountryOfOrigin, Synopsis, AgeRestriction, Availability FROM MOVIE where AgeRestriction<= " + compareAge;
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();

            allMoviesForUser = new List<Movies>();
            //TODO:MOVe IT OUT OF HERE, cause otherwise you can´trent a movie directly using the list allmovesFor User
            while (registros.Read())
            {
                Console.WriteLine("ID: "+registros["IdMovie"].ToString());
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

                //creating a list where we keep all the movies for this user
               
                //adding all movies for this user in one list
                allMoviesForUser.Add(movie);
                //foreach (Movies movie in allMoviesForUser)
                //{
                //    allMoviesForUser.Add(movie);
                //    Console.WriteLine(movie.MostrarDatos());
                //}


                ////allMoviesForUser.MostrarDatos(movie);
                //foreach (Movies movie in allMoviesForUser)
                //{
                //    Console.WriteLine("*****Checking the list******");
                //    Console.WriteLine(movie.MostrarDatos());
                //}
                //Console.WriteLine();
            }
            //foreach (Movies movie in allMoviesForUser)
            //{
            //    //allMoviesForUser.Add(movie);
            //    Console.WriteLine(movie.MostrarDatos());
            //}
            Console.ReadLine();
            conexion.Close();
        }

        public static void RentMovie()
        {
            string movieChoice, answer = "", idRent;
            //the list with rents of the user
            rentsOfUser = new List<Rents>();
            myMovies = new List<Movies>();

            Console.WriteLine("************ YOU ARE ABOUT TO HAVE IT ***************\n");

            // to show all movies with availab "A"
            foreach (Movies movie in allMoviesForUser)
            {
                //check later if it works
                if (movie.GetAvailab().Contains("A"))
                {
                    Console.WriteLine(movie.MostrarDatos() + "\n");
                }
            }

            do
            {
                Console.WriteLine("Choose a movie ID from the list above (ID): ");
                movieChoice = Console.ReadLine();

                if (movie.GetIdMovie() == movieChoice)
                {
                    //update table MOVIE, change availability to N
                    conexion.Open();

                    cadena = "UPDATE MOVIE SET Availability = 'N' where IdMovie= '" + movieChoice + "'";
                    comando = new SqlCommand(cadena, conexion);
                    comando.ExecuteNonQuery();

                    conexion.Close();


                    //Update table RENTS
                    conexion.Open();

                    idRent = movieChoice;
                    rentedMovie = new Rents();

                    idRent = movie.GetIdMovie();
                    cadena = "INSERT INTO RENTS VALUES ('" + idRent + "','" + user.GetUsername() + "','" + movie.GetIdMovie() + "','" + rentedMovie.GetDeadline() + "')";
                    comando = new SqlCommand(cadena, conexion);
                    SqlDataReader registros = comando.ExecuteReader();

                    rentedMovie.SetIdRent(registros["IdRent"].ToString());
                    rentedMovie.SetName(registros["UserName"].ToString());
                    rentedMovie.SetIdRent(registros["IdRent"].ToString());
                    rentedMovie.SetDeadline(DateTime.Parse(registros["RentDeadline"].ToString()));

                    rentsOfUser.Add(rentedMovie);
                    //myMovies.Add(movie);

                    conexion.Close();
                    //Console.WriteLine("You are ready to watch " + movie.GetName() + " Your rent expires in 10 days. Enjoy!");
                    //Console.ReadLine();
                };
                myMovies.Add(movie);
                Console.WriteLine("You are ready to watch " + movie.GetName() + " Your rent expires in 10 days. Enjoy!");
                Console.ReadLine();

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

            cadena = "SELECT [IdRent],r.IdMovie, UserName, MovieName,[RentDeadline] FROM RENTS r, [MOVIE]c WHERE r.IdMovie=c.IdMovie and UserName Like '" + user.GetUsername() + "'";
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();

            // to show the available rooms
            while (registros.Read())
            {
                Console.WriteLine("Rent ID: " + registros["IdRent"].ToString());
                Console.WriteLine("Movie ID: " + registros["IdMovie"].ToString());
                Console.WriteLine("Username: " + registros["UserName"].ToString());
                Console.WriteLine("Movie: " + registros["MovieName"].ToString());

                if (registros["RentDeadline"].ToString() == thisDay.ToString("yyyy-MM-dd"))
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
            //Console.ReadLine();
            conexion.Close();

            //foreach (Rents movie in rentsOfUser)
            //{
            //    Console.WriteLine(movie.GetIdMovie());
            //}
        }

    }
}
