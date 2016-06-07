using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;

namespace DataAccessLayer.Interface
{
    public interface IProductFamilyRepository: IGenericRepository<ProductFamily>
    {
        IEnumerable<ProductFamily> GetProductFamilyVersion();
    }
}
