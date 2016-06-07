using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class ProductFamily
    {
        public ProductFamily()
        {
            Licenses = new List<License>();
            Versions = new List<SoftwareVersion>();
        }

    
        public int Id { get; set; }

        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated{ get; set; }

        public virtual ICollection<License> Licenses { get; set; }
        //Many-to-many relationship beween ProductFamily and SoftwareVersion
        public virtual ICollection<SoftwareVersion> Versions { get; set; }
    }
}
