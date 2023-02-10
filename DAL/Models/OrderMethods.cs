using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Order
    {

        public Order(int id, string conpanyName, string description, DateTime createdAt, StatusEnum status)
        {
            this.id = id;
            this.CustomerName = conpanyName;
            this.Description = description;
            this.CreatedAt = createdAt;
            this.Status = (int)status;
        }
        public Order()
        {
            this._statusEnum = (StatusEnum)Status;
        }

        private StatusEnum _statusEnum;
        public StatusEnum StatusEnum
        {
            get => (StatusEnum)Status;
            set
            {
                _statusEnum = value;
                Status = (int)value;
            }
        }

        public override string ToString()
        {
            return this.CustomerName;
        }
    }
}
