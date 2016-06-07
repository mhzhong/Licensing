using DataLayer.Entities;
using DataLayer.Mappers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public partial class LicensingContext: DbContext
    {
        public LicensingContext() : base("Licensing")
        {
            Database.SetInitializer<LicensingContext>(null);//(new DropCreateDatabaseIfModelChanges<LicensingContext>());//(new CreateDatabaseIfNotExists<LicensingContext>()); //(null);
        }

        public virtual DbSet<Activation> Activations { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Authorization> Authorizations { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        //public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductFamily> ProductFamilys { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<SoftwareVersion> SoftwareVersions { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ActivationMapper());
            modelBuilder.Configurations.Add(new ApplicationMapper());
            modelBuilder.Configurations.Add(new AuthorizationMapper());
            modelBuilder.Configurations.Add(new LicenseMapper());
            modelBuilder.Configurations.Add(new OrderDetailMapper());
            modelBuilder.Configurations.Add(new OrderMapper());
            modelBuilder.Configurations.Add(new ProductFamilyMapper());
            //modelBuilder.Configurations.Add(new ProductMapper());
            modelBuilder.Configurations.Add(new ProductTypeMapper());
            modelBuilder.Configurations.Add(new SoftwareVersionMapper());
            modelBuilder.Configurations.Add(new SubscriptionMapper());
        }
    }
  
}
