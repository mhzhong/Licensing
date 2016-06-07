using DataAccessLayer.Interface;
using DataLayer;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LicenseLookUp : GenericRepository<License>, ILicenseLookUp
    {
        public LicensingContext _context;

        public LicenseLookUp(LicensingContext context) : base(context)
        {
            _context = context;
        }

        public LicensingContext Context
        {
            set { _context = value; }
        }

       
        public IEnumerable<License> GetLicensesByApplication(string name)
        {
            

            var query = from x in _context.Licenses
                        where (x.App.App == name)
                        select x;

            return query.ToArray();
            
        }
        
    }
}
