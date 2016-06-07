using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interface;
using DataLayer;
using DataLayer.Entities;

namespace DataAccessLayer
{
    public class AuthorizationRepository : GenericRepository<Authorization>, IAuthorizationRepository
    {
        private LicensingContext _context;

        public AuthorizationRepository(LicensingContext context)
            : base(context)
        {
            _context = context;
        }

        public LicensingContext Context
        {
            set { _context = value; }
        }


        public IEnumerable<Authorization> GetAuthorizationsByLicenseId(int id)
        {
            var query = from x in _context.Authorizations
                        where x.LicenseId == id
                        select x;
            return query.ToList();
        }


        public Authorization GetAuthorizationByOrderId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Authorization> GetAuthorizationByLicenseName(string name)
        {
            var query = from x in _context.Authorizations
                        where x.License.Name == name
                        select x;

            return query.ToList();
        }

    }
}
