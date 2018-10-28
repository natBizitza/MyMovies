using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies
{
    class Rents
    {
        private string idRent, userName, idMovie;
        private DateTime thisDay;
        private string rentDeadline;


        //constructor
        public Rents()
        {

        }

        //GEt & SEt

        public string GetIdRent()
        {
            return idRent;
        }

        public void SetIdRent(string idRent)
        {
            this.idRent = idRent;
        }

        public DateTime GetDeadline()
        {
            DateTime thisDay = DateTime.Now;
            DateTime rentDeadline = thisDay.AddDays(10);
            return rentDeadline;
        }

        public void SetDeadline(DateTime rentDeadline)
        {
            DateTime thisDay = DateTime.Now;
            rentDeadline = thisDay.AddDays(10);
            this.rentDeadline = rentDeadline.ToString();
        }

        public string GetName()
        {
            return userName;
        }

        public void SetName(string userName)
        {
            this.userName = userName;
        }

        public string GetIdMovie()
        {
            return idMovie;
        }

        public void SetIdMovie(string idMovie)
        {
            this.idMovie = idMovie;
        }

    }
}
