using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birk.KlarupSportsBooking.DAL;
using Birk.KlarupSportsBooking.DAL.EF;

namespace Birk.KlarupSportsBooking.BIZ
{
    public abstract class BaseHandler
    {
        //Field
        private KlarupSportsBookingModel model;

        //Constructor
        public BaseHandler()
        {
            Model = new KlarupSportsBookingModel();
        }

        //Properties
        protected KlarupSportsBookingModel Model { get => model; set => model = value; }
    }
}
