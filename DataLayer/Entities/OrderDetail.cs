using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public string Item { get; set; } //license name.Get from user input and store seperately. Cannot reference to the license, because the license detail may change. e.g. price.
        //public int LicenseId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        //public virtual License License { get; set; }
       
    }
}
