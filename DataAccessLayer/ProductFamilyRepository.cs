using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interface;
using DataLayer;
using DataLayer.Entities;

namespace DataAccessLayer
{
    public class ProductFamilyRepository: GenericRepository<ProductFamily>, IProductFamilyRepository
    {
        private LicensingContext _context;

        public ProductFamilyRepository(LicensingContext context)
            : base(context)
        {
            _context = context;
        }

        public LicensingContext Context
        {
            set { _context = value; }
        }


        //public bool Update(ProductFamily prodFam)
        //{
        //    Context.Entry(prodFam).State = EntityState.Modified;
        //    Context.ProductFamilys.Attach(prodFam);
        //    Context.SaveChanges();
        //    return true;
        //}

        public bool Delete(int id)
        {
            var prodFam = _context.ProductFamilys.FirstOrDefault(x => x.Id == id);
            if (prodFam != null)
            {
                _context.Entry(prodFam).State = EntityState.Modified;
                _context.ProductFamilys.Remove(prodFam);
                _context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<ProductFamily> GetProductFamilyVersion()
        {
            var query = from x in _context.ProductFamilys
                from y in _context.SoftwareVersions
                where x.Id == 1
                select x;

            return query.ToList();
        }
    }
}
