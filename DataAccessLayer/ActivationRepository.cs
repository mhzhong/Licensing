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
    public class ActivationRepository : GenericRepository<Activation>, IActivationRepository
    {
        private LicensingContext _context;

        public ActivationRepository(LicensingContext context)
            : base(context)
        {
            _context = context;
        }

        public LicensingContext Context
        {
            set { _context = value; }
        }

        public Activation GetActivationByActivationKey(string activationKey)
        {
            var query = from a in _context.Activations where a.Key == activationKey select a;

            return query.FirstOrDefault();
        }

        //public bool Insert(Activation activation)
        //{
        //    Context.Entry(activation).State = EntityState.Modified;
        //    Context.Activations.Add(activation);

        //    if (Context.SaveChanges() > 0)
        //    {
        //        return true;
        //    }

        //    return false;
        //}
    }
}
