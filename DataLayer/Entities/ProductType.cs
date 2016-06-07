﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class ProductType
    {
        //private int p1;
        //private string p2;

        public ProductType()
        {
            Licenses = new List<License>();
        }


        public int Id { get; set; }
        public String Type{ get; set; }

        public ICollection<License> Licenses { get; set; }
    }
}
