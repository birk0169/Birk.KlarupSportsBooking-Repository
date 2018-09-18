using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Birk.KlarupSportsBooking.DAL.EF;

namespace Birk.KlarupSportsBooking.BIZ
{
    public class UnionHandler : BaseHandler
    {
        //Get
        /// <summary>
        /// Gets all unions from the database
        /// </summary>
        /// <returns>All unions from the database in a list</returns>
        public List<Union> GetAllUnions()
        {
            return Model.Unions.ToList();
        }
    
        //Add
        /// <summary>
        /// Adds a union to the database
        /// </summary>
        /// <param name="union">The union to be added</param>
        public void AddUnionToDB(Union union)
        {
            if (union == null || (union.Address == null && union.AddressId == 0))
            {
                throw new ArgumentNullException();
            }
            else
            {
                Model.Unions.Add(union);
                Model.SaveChanges();
            }
        }
    }
}
