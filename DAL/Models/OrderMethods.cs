using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Order
    {
        public Order()
        {
            this.id = 0;
            this.CustomerName = String.Empty;
            this.Description = String.Empty;
            this.CreatedAt = DateTime.Now;
            this.Status = (int)StatusEnum.Abierto;
        }
        public Order(int id, string conpanyName, string description, DateTime createdAt, StatusEnum status)
        {
            this.id = id;
            this.CustomerName = conpanyName;
            this.Description = description;
            this.CreatedAt = createdAt;
            this.Status = (int)status;
        }

        public override string ToString()
        {
            return this.CustomerName;
        }
    }
}
