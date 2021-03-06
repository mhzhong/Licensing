﻿using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mappers
{
    class OrderDetailMapper: EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMapper()
        {
            this.HasKey(od => od.Id);
            this.Property(od => od.Id).IsRequired();
            this.Property(pf => pf.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(n => n.Item).IsRequired();

            //One-to-one relationship between orderDetail and license
            //this.HasRequired(l => l.License).WithMany().HasForeignKey(l => l.LicenseId);
            
            //One-to-many relationship between Order and OrderDetail
            this.HasRequired<Order>(n => n.Order).WithMany(od => od.Items).HasForeignKey(n => n.OrderId);

        }

    }
}
