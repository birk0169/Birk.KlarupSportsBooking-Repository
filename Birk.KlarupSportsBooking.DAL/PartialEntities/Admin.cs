using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birk.KlarupSportsBooking.DAL.EF
{
    public partial class Admin
    {
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
