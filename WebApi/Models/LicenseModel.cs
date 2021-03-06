﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Web;
using DataLayer.Entities;
using DataLayer.Enums;

namespace WebApi.Models
{
    public class LicenseModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String TitleOfHardware { get; set; }
        public DataLayer.Enums.LicenseType LicenseType { get; set; }
        public int Duration { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DataLayer.Enums.Status Status  { get; set; }
        public IEnumerable<Authorization> Authorizations { get; set; }

    }
}