using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Enums;


namespace LicensingWeb.Models
{
    public class License
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String TitleOfHardware { get; set; }
        public DataLayer.Enums.LicenseType LicenseType { get; set; }
        public int Duration { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DataLayer.Enums.Status Status { get; set; }

        //public int? ProdFamilyId { get; set; }
        //public int? SubscriptionId { get; set; }
        //public int? VersionId { get; set; }
        //public int? ApplicationId { get; set; }
        //public int? ProductTypeId { get; set; }
        //public int AuthorizationId { get; set; }

        //public virtual ProductFamily ProdFamily { get; set; }
        //public virtual Subscription Subscription { get; set; }
        //public virtual SoftwareVersion Version { get; set; }
        //public virtual Application App { get; set; }
        //public virtual ProductType ProdType { get; set; }

        //public virtual ICollection<Authorization> Authorizations { get; set; }
    }
}