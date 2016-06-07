using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class SoftwareVersion
    {
        public SoftwareVersion()
        {
            Licenses = new List<License>();
            ProductFamilies = new List<ProductFamily>();
        }
        public int Id { get; set; }

        public String Version { get; set; }
        public String Description { get; set; }
        public DateTime DateCreated{ get; set; }

        //One-to-many relationship between License and SoftwareVersion
        public virtual ICollection<License> Licenses { get; set; }
        //many-to-many relationships between ProductFamily and SoftwareVersion
        public virtual ICollection<ProductFamily> ProductFamilies { get; set; }
    }
}
