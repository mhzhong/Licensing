using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interface;
using DataLayer.Entities;
using System.Data.Entity;
using System.Linq.Expressions;
using DataLayer;
using System.Reflection;
using System.Data.Entity.Core.Objects;

namespace DataAccessLayer
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        private readonly LicensingContext _dbContext;

        public GenericRepository(LicensingContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public IEnumerable<T> GetAll()
        //{
        //    IEnumerable<T> entities = _dbContext.Set<T>().AsEnumerable().ToList();

        //    return LoadNavigationFields<T>(entities);
        //}

        //private IEnumerable<T> LoadNavigationFields<T>(IEnumerable<T> entities)
        //{
        //    foreach (T entity in entities)
        //    {
        //        PerformEagerLoading<T>(entity, this._dbContext);
        //    }

        //    return entities;
        //}

        //private void PerformEagerLoading<T>(object entity, LicensingContext licensingContext)
        //{
        //    PropertyInfo[] properties = typeof(T).GetProperties();

        //    foreach (PropertyInfo property in properties)
        //    {
        //        object[] keys = property.GetCustomAttributes().ToArray();
        //        if (keys.Length > 0)
        //        {
        //            licensingContext.LoadProperty(entity, property.Name);
        //        }
        //    }
        //}

        public virtual IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        //public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        //{
        //    List<T> list;
        //    //using (var context = new LicensingContext())
        //    //{
        //    IQueryable<T> dbQuery = _dbContext.Set<T>();

        //        //Apply eager loading
        //        foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
        //            dbQuery = dbQuery.Include<T, object>(navigationProperty);

        //        list = dbQuery
        //            .AsNoTracking()
        //            .ToList<T>();
        //    //}
        //    return list;
        //}
        

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public bool Insert(T entity)
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
                Save();
                return true;
            }
            catch
            {

                return false;
            }
           
        }

        public bool Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            Save();
            return true;
        }

        public bool Save()
        {
            _dbContext.SaveChanges();
            return true;
        }

        
    }
 }



    //    //public bool Delete(T entity)
    //    //{

    //    //    Context.Set<T>().Remove(entity);
    //    //    Context.SaveChanges();

    //    //    return true;
    //    //}


