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
    public class AuthorizationMapper: EntityTypeConfiguration<Authorization>
    {
        public AuthorizationMapper()
        {
            this.HasKey(a => a.Id);
            this.Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(a => a.Id).IsRequired();

            this.Property(a => a.Key).IsRequired();

            this.Property(a => a.Quantity).IsRequired();

            //one-to-zero or many relationship between license and authorization
            this.HasRequired<License>(a => a.License).WithMany(a => a.Authorizations).HasForeignKey(fk => fk.LicenseId);
            //one-to-zero or one relationship between authorization and activation
            this.HasOptional(a => a.Activation).WithRequired(au => au.Authorization);



        }
    }
}
