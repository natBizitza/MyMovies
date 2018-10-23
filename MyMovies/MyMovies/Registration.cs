using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies
{
    class Registration
    {
        private string username, name, password;
        private DateTime dateBirth;

        //constuctor
        public Registration(string username, string name, string password, DateTime dateBirth)
        {
            this.username = username;
            this.name = name;
            this.password = password;
            this.dateBirth = dateBirth;
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

        public string GetDateBirth()
        {
            return dateBirth.ToString();
        }

        public void SetDateBirth(DateTime dateBirth)
        {
            this.dateBirth = dateBirth.ToString();
        }

        password

        public static void RegisterClient()
        {
            Console.WriteLine("Welcome to MyMovies!\nPlease, introduce your data. Enter your user name: ");
            username = Console.ReadLine();
            Console.WriteLine("Enter client´s Name.");
            nameClient = Console.ReadLine();
            Console.WriteLine("Enter client´s surname.");
            surnameClient = Console.ReadLine();

            conexion.Open();

            cadena = "INSERT INTO CLIENT VALUES ('" + DNI + "','" + nameClient + "','" + surnameClient + "')";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();

            conexion.Close();

        }
    }
}
