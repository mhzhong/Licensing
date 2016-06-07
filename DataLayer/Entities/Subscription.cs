using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Subscription
    {
        public Subscription()
        {
            Licenses = new List<License>();
        }

        public int Id{ get; set; }

        public String Name{ get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}
