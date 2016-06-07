using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Activation
    {
        public Activation()
        {
        }

        public int AuthorizationId { get; set; }

        //public int Id { get; set; }
        public String Key { get; set; }
        public Enums.Status Status { get; set; }
        public String MachineIdentifier { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime BegEffDate { get; set; }
        public DateTime EndEffDate { get; set; }

        public virtual Authorization Authorization { get; set; }

    }
}
