using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface ILicenseRepository : IGenericRepository<License>
    {
        
        IEnumerable<License> GetLicensesByProductTypeId(int id);
        License GetLicenseByName(String name);
        //License GetLicenseByAuthorizationKey(String key);
        //License GetLicenseByActivationKey(String key);
       
        //IEnumerable<License> GetLicensesByProdectFamilyId(int id);
        //IEnumerable<License> GetLicensesByProdectFamilyName(string name);
        //IEnumerable<License> GetLicensesByProductId(int id);


    }
}
