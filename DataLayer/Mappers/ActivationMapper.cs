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
    class ActivationMapper : EntityTypeConfiguration<Activation>
    {
        public ActivationMapper()
        {
            this.HasKey(a => a.AuthorizationId);
            this.Property(a => a.AuthorizationId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(a => a.AuthorizationId).IsRequired();

            this.Property(a => a.Key).IsRequired();

        }
    }
}
