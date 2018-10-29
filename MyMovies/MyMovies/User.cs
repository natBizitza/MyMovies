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
        private string username, name, password;
        private string dateBirth;

        //constuctors
        public User(string username, string name, string password, string dateBirth)
        {
            this.username = username;
            this.name = name;
            this.password = password;
            this.dateBirth = dateBirth;
        }

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
    }
}
