using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mappers
{
    public class LicenseMapper: EntityTypeConfiguration<License> 
    {
         
        public LicenseMapper()
        {
            this.HasKey(l => l.Id);
            this.Property(l => l.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(l => l.Id).IsRequired();

            this.Property(l => l.Name).IsRequired();

            this.Property(l => l.Description).IsOptional();
            this.Property(l => l.Description).HasMaxLength(500);

            this.HasRequired<ProductFamily>(x => x.ProdFamily).WithMany(l => l.Licenses).HasForeignKey(fk => fk.ProdFamilyId);
            this.HasRequired<Subscription>(x => x.Subscription).WithMany(l => l.Licenses).HasForeignKey(fk => fk.SubscriptionId);
            this.HasRequired<SoftwareVersion>(x => x.Version).WithMany(l => l.Licenses).HasForeignKey(fk => fk.VersionId);
            this.HasRequired<ProductType>(x => x.ProdType).WithMany(l => l.Licenses).HasForeignKey(fk => fk.ProductTypeId);
            this.HasRequired<Application>(x => x.App).WithMany(l => l.Licenses).HasForeignKey(fk => fk.ApplicationId);


            //this.HasOptional(a => a.Authorization).WithRequired(l => l.License);

            //this.HasRequired(p => p.ProductFamilyId).WithMany().HasForeignKey(f => f.ProductFamilyId);

            //this.HasRequired(l => l.SubscriptionId).WithMany().HasForeignKey(f => f.SubscriptionId);

            //this.HasRequired(l => l.VerionId).WithMany().HasForeignKey(f => f.VerionId);

            //this.HasRequired(l => l.ApplicationId).WithMany().HasForeignKey(f => f.ApplicationId);
            
        }
    }
}
