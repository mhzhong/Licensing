﻿using DataLayer.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mappers
{
    class SubscriptionMapper: EntityTypeConfiguration<Subscription>
    {
        public SubscriptionMapper() 
        {
            this.HasKey(s => s.Id);
            this.Property(s => s.Id).IsRequired();
            this.Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(l => l.Name).IsRequired();
        }
    }
}