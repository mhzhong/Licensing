using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataAccessLayer.Interface
{
    public interface IActivationRepository : IGenericRepository<Activation>
    {
        //Should return other things
        Activation GetActivationByActivationKey(string activationKey);
    }
}
