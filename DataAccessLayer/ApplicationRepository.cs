using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interface;
using DataLayer;
using DataLayer.Entities;

namespace DataAccessLayer
{
    public class ApplicationRepository : GenericRepository<Application>, IApplicationRepository
    {
        private LicensingContext _context;

        public ApplicationRepository(LicensingContext context)
            : base(context)
        {
            _context = context;
        }

        public LicensingContext Context
        {
            set { _context = value; }
        }

    }
}
