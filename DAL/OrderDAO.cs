using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class OrderDAO
    {
        private static ServiceOrdersEntities context = DbConnector.context;
        public static OrderCollection GetAll()
        {
            var oc = new OrderCollection();
            foreach (var item in FindAll())
                oc.Add(item);
            return oc;
        }
        public static List<Order> FindAll()
        {
            return context.Orders.ToList();
        }
        public static Order Find(long id)
        {
            return context.Orders.FirstOrDefault(order => order.id == id);
        }
        public static bool Save(Order order)
        { 
            context.Orders.AddOrUpdate(order);
            if (context.SaveChanges() > 0)
                return true;
            else
                return false;
        }
        public static bool Delete(long id)
        {
            Order order = Find(id);
            if (order != null)
            {
                context.Orders.Remove(order);
                if (context.SaveChanges() > 0)
                    return true;
            }
            return false;
        }
        public static bool ClearOrders()
        {
            foreach (Order order in context.Orders)
            {
                context.Orders.Remove(order);
            }
            if (context.SaveChanges() > 0)
                return true;
            else
                return false;
        }
    }
}
