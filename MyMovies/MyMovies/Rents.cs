using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies
{
    class Rents
    {
        private string userName, idMovie;
        private int idRent;
        private DateTime rentDeadline;


        //constructor
        public Rents()
        {

        }

        //GEt & SEt

        public int GetIdRent()
        {
            //for(int x=1; x>0; x++)
            //{
            //    return idRent=x;
            //}
            return idRent;
        }

        public void SetIdRent(int idRent)
        {
            this.idRent = idRent;
        }

        //deadline for any rent is in 10 days
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
            this.rentDeadline = rentDeadline;
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
