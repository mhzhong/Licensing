using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface ILicenseLookUp : IGenericRepository<License>
    {
        IEnumerable<License> GetLicensesByApplication(string app);

    }
}
