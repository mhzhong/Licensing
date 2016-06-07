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
    class ProductFamilyMapper : EntityTypeConfiguration<ProductFamily>
    {
        public ProductFamilyMapper()
        {
            this.HasKey(pf => pf.Id);
            this.Property(pf => pf.Id).IsRequired();
            this.Property(pf => pf.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(pf => pf.Name).IsRequired();

            this.HasMany<SoftwareVersion>(v => v.Versions)
                .WithMany(pf => pf.ProductFamilies)
                .Map(m =>
                {
                    m.ToTable("Products");
                    m.MapLeftKey("ProductFamilyId");
                    m.MapRightKey("VersionId");
                });
        }
    }
}
