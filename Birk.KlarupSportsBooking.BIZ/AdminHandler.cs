using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birk.KlarupSportsBooking.DAL.EF;

namespace Birk.KlarupSportsBooking.BIZ
{
    class AdminHandler : BaseHandler
    {
        //Get
        /// <summary>
        /// Gets all admins from the database in a list
        /// </summary>
        /// <returns>All admins in database in list</returns>
        public List<Admin> GetAllAdmins()
        {
            return Model.Admins.ToList();
        }

        //Add
        /// <summary>
        /// Adds a admin to the database
        /// </summary>
        /// <param name="admin">The admin to be added to the database</param>
        public void AddAdminToDB(Admin admin)
        {
            if (admin == null || (admin.Address == null && admin.AddressId == 0))
            {
                throw new ArgumentNullException();
            }
            else
            {
                Model.Admins.Add(admin);
                Model.SaveChanges();
            }
        }
    }
}
