using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies
{
    class Rents
    {
        private string idRent, userName,  idMovie, rentDeadline;

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
    }
}
