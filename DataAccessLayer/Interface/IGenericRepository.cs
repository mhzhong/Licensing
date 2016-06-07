using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataAccessLayer.Interface
{

    public interface IGenericRepository<T> 
        where T : class 
    {

        IEnumerable<T> GetAll();
        //List<License> GetAll();
       // IEnumerable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

        T GetById(int id);
        
        bool Insert(T entity);

        bool Update(T entity);

        bool Save();
    }
}
