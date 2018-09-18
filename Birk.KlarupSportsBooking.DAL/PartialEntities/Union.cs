using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birk.KlarupSportsBooking.DAL.EF
{
    public partial class Union
    {
        /// <summary>
        /// Constuctor for the union class
        /// </summary>
        /// <param name="unionName">Name of the union</param>
        /// <param name="email">E-mail of the union</param>
        /// <param name="address">Address of the union</param>
        public Union(string unionName, string email, string password, Address address)
        {
            
            UnionName = unionName;
            Email = email;
            Password = password;
            Address = address;
        }
    }
}
