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
    class ApplicationMapper : EntityTypeConfiguration<Application>
    {
        public ApplicationMapper()
        {
            this.HasKey(a => a.Id);
            this.Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(a => a.Id).IsRequired();

            this.Property(a => a.App).IsRequired();
            this.Property(a => a.App).HasMaxLength(50);
        }
    }
}
