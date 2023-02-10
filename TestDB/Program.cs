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
            var orders = OrderDAO.FindAll();
            foreach (var order in orders)
            {
                Console.WriteLine(order.CustomerName);
            }
            Console.ReadLine();
        }
    }
}
