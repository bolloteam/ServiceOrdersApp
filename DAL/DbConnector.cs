using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbConnector
    {
        ServiceOrdersEntities db = new ServiceOrdersEntities();
        public List<Order> GetOrders()
        {
            return db.Orders.ToList();
        }
    }
}
