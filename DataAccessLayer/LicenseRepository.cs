using DataAccessLayer.Interface;
using DataLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;


namespace DataAccessLayer
{

    public class LicenseRepository: GenericRepository<License>, ILicenseRepository
    {
         private LicensingContext _context;

         public LicenseRepository(LicensingContext context)
            : base(context)
        {
            _context = context;
        }

        public LicensingContext Context
        {
            set { _context = value; }
        }

        //public IEnumerable<License> GetAll()
        //{
        //    return _context.Licenses
        //        .Include("ProductFamily")
        //        .Include("Subscription")
        //        .Include("SoftwareVersion")
        //        .Include("Application")
        //        .Include("ProductType")
        //        .Include("Authorization")
        //        .AsQueryable();
        //} 
        
        public override IEnumerable<License> GetAll()
        {
            List<License> licenseList = new List<License>();
            var licenses = _context.Licenses;
            foreach (License x in licenses)
            {
                licenseList.Add(x);
            }

            return licenseList;
        }


        public IEnumerable<License> GetLicensesByProductTypeId(int id)
        {
            var query = from x in _context.Licenses where x.ProductTypeId == id select x;
            return query.ToList();
        }


        public License GetLicenseByName(string name)
        {
            var query = from x in _context.Licenses where x.Name == name select x;
            return query.FirstOrDefault();
        }

        public IEnumerable<License> GetLicensesDetails()
        {
            return new List<License>();
            /*
            select Name,Description, TitleOfHardware, LicenseType, Duration, DateCreated, DateUpdate, Status, ProductFamily, Verion, Subscription, Application
            from Licenses as l, ProductFamily as pf, SoftwreVersion as sv, ProductType as pt, Subscription as s, Application as a,
            where l.ProductFamilyId == pf.Id AND 
          **/
        }

       
    }

}
