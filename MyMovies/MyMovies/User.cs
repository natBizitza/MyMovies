using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MyMovies
{
    class User
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["MOVIES"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;

        private string username, name, password;
        private string dateBirth;

        //constuctor
        //public User(string username, string name, string password, int year, int month, int day)
        //{
        //    this.username = username;
        //    this.name = name;
        //    this.password = password;
        //    //TODO: fix the date thing
        //    this.dateBirth = new DateTime(year, month, day);
        //    //this.dateBirth.Year;
        //    //this.dateBirth.Month;
        //}

        public User()
        {
            
        }
        // Get & Set() 
        public string GetUsername()
        {
            return username;
        }

        public void SetUsername(string username)
        {
            this.username = username;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        //TODO: change the codebelow
        public string GetDateBirth()    
        {
            return dateBirth.ToString();
        }

        public void  SetDateBirth(string dateBirth)
        {
            this.dateBirth = dateBirth;
        }

        public string GetPassword()
        {
            return password.ToString();
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        //public void RegisterUser()
        //{
        //    string username, name, password;
        //    //change it
        //    string dateOfBirth;

        //    Console.WriteLine("Welcome to MyMovies!\nPlease, introduce your data. Enter your Username: ");
        //    username = Console.ReadLine();
        //    Console.WriteLine("Enter your Name: ");
        //    name = Console.ReadLine();
        //    Console.WriteLine("Enter your date of birth (dd/MM/YYYY): ");
        //    dateOfBirth = Console.ReadLine();
        //    //Console.WriteLine("Enter your month of birth (MM): ");
        //    //month = Console.ReadLine();
        //    //Console.WriteLine("Enter your year of birth (yyyy): ");
        //    //year = Console.ReadLine();
        //    //string yourDateOfBirth = day + "/" + month + "/" + year;
        //    //Console.WriteLine("Your date of birth is " + yourDateOfBirth);
        //    Console.WriteLine("Enter your password: ");
        //    password = Console.ReadLine();

        //    Console.WriteLine("You are successfully signed up. Enjoy MyMovies!");

        //    conexion.Open();

        //    cadena = "INSERT INTO CLIENT VALUES ('" + username + "','" + name + "','" + dateOfBirth + "','"+password+"')";
        //    comando = new SqlCommand(cadena, conexion);
        //    comando.ExecuteNonQuery();

        //    conexion.Close();

        //}

        //public void LogIn()
        //{
        //    string username, password;

        //    bool IsRegistered = false;

        //    Console.WriteLine("**************** LOG IN **********************");
        //    do
        //    {
        //        Console.WriteLine("Username: ");
        //        username = Console.ReadLine();
               
        //        Console.WriteLine("Password: ");
        //        password = Console.ReadLine();

        //        //TODO: add condition if password==pasword and username==username -> user menu
        //        conexion.Open();
        //        cadena = "SELECT * from CLIENT where UserName LIKE '" + username + "'";
        //        cadena = "SELECT * from CLIENT where Password LIKE '" + password + "'";
        //        comando = new SqlCommand(cadena, conexion);
        //        SqlDataReader registros = comando.ExecuteReader();
        //        IsRegistered = registros.Read();
        //        conexion.Close();
        //        registros.Close();

        //        if(!IsRegistered)
        //        {
        //            Console.WriteLine("Username or password is not correct. Try again.");
        //        }
                
        //        //check the boolean below
        //    } while (!IsRegistered);

        //    Console.WriteLine("You are successfully logged in!");
        //}

        public void GetAge()
        {

        }
    }
}
