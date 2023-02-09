using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbConnector _db = new DbConnector();

            var orders = _db.GetOrders();
            foreach (var order in orders)
            {
                Console.WriteLine(order.CustomerName);
            }
            Console.ReadLine();
        }
    }
}
