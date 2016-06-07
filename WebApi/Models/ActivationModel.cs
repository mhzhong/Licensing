using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;

namespace WebApi.Models
{
    public class ActivationModel
    {
        public int Id;
        public String LicenseName { get; set; }

        public String AuthorizationKey { get; set; }

        public String ActivationKey { get; set; }
        public String MachineIdentifier { get; set; }
        public DateTime BegEffDate { get; set; }
        public DateTime EndDateTime{ get; set; }
        public DataLayer.Enums.Status Status { get; set; }

    }
}