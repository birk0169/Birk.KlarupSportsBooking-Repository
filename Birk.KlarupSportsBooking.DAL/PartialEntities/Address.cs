using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birk.KlarupSportsBooking.DAL.EF
{
    public partial class Address
    {
        /// <summary>
        /// Constructor for the address class
        /// </summary>
        /// <param name="city"></param>
        /// <param name="postNumber"></param>
        /// <param name="roadName"></param>
        /// <param name="houseName"></param>
        public Address(string city, string postNumber, string roadName, string houseName)
        {
            City = city;
            if (postNumber.Length != 4)
            {
                throw new ArgumentException();
            }
            else
            {
                PostNumber = postNumber;
            }
            
            RoadName = roadName;
            HouseName = houseName;
        }
    }
}
