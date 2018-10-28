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

        //private int idMovie, age;
        private string movieName, director, country,synopsis, availab, idMovie, age;


        //constructor
        public Movies()
        {

        }

        //GEt & SEt

        public string GetName()
        {
            return movieName;
        }

        public void SetName(string movieName)
        {
            this.movieName = movieName;
        }

        public string GetDirector()
        {
            return director;
        }

        public void SetDirector(string director)
        {
            this.director = director;
        }

        public string GetCountry()
        {
            return country;
        }

        public void SetCountry(string country)
        {
            this.country = country;
        }

        public string GetSynopsis()
        {
            return synopsis;
        }

        public void SetSynopsis(string synopsis)
        {
            this.synopsis = synopsis;
        }

        public string GetAvailab()
        {
            return availab;
        }

        public void SetAvailab(string availab)
        {
            this.availab = availab;
        }

        public string GetIdMovie()
        {
            return idMovie;
        }

        public void SetIdMovie(string idMovie)
        {
            this.idMovie = idMovie;
        }

        public string GetAge()
        {
            return age;
        }

        public void SetAge(string age)
        {
            this.age = age;
        }

        //other methods

        public override string MostrarDatos()
        {
            string result = "";

            if (this.GetIdMovie() != "")
            {
                result += "ID: " + this.GetIdMovie() + " ";
            }
            if (this.GetName() != "")
            {
                result += "Name: " + this.GetName() + " ";
            }
            if (this.GetDirector() != "")
            {
                result += "Director: " + this.GetDirector() + " ";
            }
            if (this.GetName() != "")
            {
                result += "Name: " + this.GetName() + " ";
            }
            if (this.GetName() != "")
            {
                result += "Name: " + this.GetName() + " ";
            }
            if (this.GetName() != "")
            {
                result += "Name: " + this.GetName() + " ";
            }
            if (this.GetName() != "")
            {
                result += "Name: " + this.GetName() + " ";
            }
            return "FUTBOLISTA " + base.MostrarDatos() + result;
            }
        }
    }
