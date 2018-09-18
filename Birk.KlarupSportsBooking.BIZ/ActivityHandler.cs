using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birk.KlarupSportsBooking.DAL.EF;

namespace Birk.KlarupSportsBooking.BIZ
{
    public class ActivityHandler : BaseHandler
    {
        //Get
        /// <summary>
        /// Gets all activities from the datebase and returns them in a list
        /// </summary>
        /// <returns>All Activities in a list</returns>
        public List<Activity> GetAllActivities()
        {
            return Model.Activities.ToList();
        }

        //Add
        public void AddActivityToDB(Activity activity)
        {
            if (activity == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                Model.Activities.Add(activity);
                Model.SaveChanges();
            }
        }
    }
}
