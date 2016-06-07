using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Application
    {
        public Application()
        {
            Licenses = new List<License>();
        }
        public int Id { get; set; }
        public String App { get; set; }

        public virtual ICollection<License> Licenses { get; set; }


    }
}
