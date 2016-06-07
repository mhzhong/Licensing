using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class AuthorizationModel
    {
        public int Id { get; set; }
        public String Key { get; set; }
        public DataLayer.Enums.Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public int? LicenseId { get; set; }
        public int? OrderId { get; set; }
    }
}