using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies
{
    class User
    {
        private string username, name, password;
        private DateTime dateBirth;

        //constuctor
        public User(string username, string name, string password, int year, int month, int day)
        {
            this.username = username;
            this.name = name;
            this.password = password;
            //TODO: fix the date thing
            this.dateBirth = new DateTime(year, month, day);
            //this.dateBirth.Year;
            //this.dateBirth.Month;
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

        public void SetDateBirth(DateTime dateBirth)
        {
            this.dateBirth = DateTime.Today.ToString();
        }

        public string GetPassword()
        {
            return password.ToString();
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public static void RegisterClient()
        {
            string username, name, password;
            //change it
            DateTime dateBirth;

            Console.WriteLine("Welcome to MyMovies!\nPlease, introduce your data. Enter your user name: ");
            username = Console.ReadLine();
            Console.WriteLine("Enter your Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter your year of birth: ");
            dateBirth.Year = Console.ReadLine();
            Console.WriteLine("Enter your month of birth: ");
            dateBirth.Month = Console.ReadLine();
            Console.WriteLine("Enter your day of birth: ");
            dateBirth = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            password = Console.ReadLine();

            Console.WriteLine("You are successfully signed up. You are ready to enjoy MyMovies!");

            //conexion.Open();

            //cadena = "INSERT INTO CLIENT VALUES ('" + DNI + "','" + nameClient + "','" + surnameClient + "')";
            //comando = new SqlCommand(cadena, conexion);
            //comando.ExecuteNonQuery();

            //conexion.Close();

        }

        public static void LogIn()
        {
            string username, password;

            bool IsCorrect = false;

            Console.WriteLine("**************** LOG IN **********************");
            do
            { 
                Console.WriteLine("Username: ");
                username = Console.ReadLine();

                Console.WriteLine("Password: ");
                password = Console.ReadLine();
                //TODO: add condition if password==pasword and username==username -> user menu
                conexion.Open();
                cadena = "SELECT * from CLIENT where DNI LIKE '" + DNI + "'";
                comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                IsRegistered = registros.Read();
                conexion.Close();
                registros.Close();

                //check the boolean below
            } while (!IsCorrect);


        }


    }
}
