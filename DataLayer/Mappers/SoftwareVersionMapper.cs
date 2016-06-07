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
    class SoftwareVersionMapper: EntityTypeConfiguration<SoftwareVersion>
    {
        public SoftwareVersionMapper()
        {
            this.HasKey(v => v.Id);
            this.Property(v => v.Id).IsRequired();
            this.Property(v => v.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(v => v.Version).IsRequired();
        }
    }
}
