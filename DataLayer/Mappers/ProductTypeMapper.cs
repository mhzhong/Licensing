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
    class ProductTypeMapper: EntityTypeConfiguration<ProductType>
    {
        public ProductTypeMapper()
        {
            this.HasKey(t => t.Id);
            this.Property(t => t.Id).IsRequired();
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(v => v.Type).IsRequired();
        }
    }
}
