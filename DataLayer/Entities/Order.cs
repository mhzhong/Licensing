using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Order
    {
        public Order()
        {
            Items = new List<OrderDetail>();
        }

        public int Id { get; set; }
        public String OrderNumber { get; set; }
        public DateTime DatePlacedOrder { get; set; }
        public Enums.Status Status { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public ICollection<OrderDetail> Items { get; set; }

    }
}
