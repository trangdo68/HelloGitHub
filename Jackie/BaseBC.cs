using System;
using System.Collections.Generic;
using System.Linq;
using CMHGAdminData.Models;
using CMHGAdminDataObjects;
using CMHGAdminDomain.Mapping;
using CMHGAdminDomain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


//Business Component: Get, List, Delete, Save, Search   
//Business Object: what is needed for presentation layer
//Mapper is to map an entity to a business object
namespace CMHGAdminDomain.BusinessComponents
{
    public class BaseBC<T> : IBaseBC<T> where T : class, new()
    {
        private readonly DHRIM_CMHGContext _context;       

        public BaseBC(DHRIM_CMHGContext context)
        {
            _context = context;           
            DbSet = _context.Set<T>();
        }
        

        protected DbSet<T> DbSet
        {
            get;
            set;
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual T Get(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll(T entity)
        {
           return DbSet;
        }

        public virtual List<T> List()
        {
            return DbSet.ToList();
        }

         public virtual List<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var list = DbSet.Where(predicate).ToList();
            return list;
        }      

        
        public virtual void Insert(T entity)
        {
            using (_context)
            {
                using (var dbTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var dbEntityEntry = _context.Entry(entity);
                        if (dbEntityEntry.State != EntityState.Detached)
                        {
                            dbEntityEntry.State = EntityState.Added;
                        }
                        else
                        {
                            DbSet.Add(entity);
                        }
                        dbEntityEntry.State = EntityState.Modified;
                        _context.SaveChanges();
                        dbTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                    }
                }
            }
        }


        public virtual void Update(T entity)
        {
            using (_context)
            {
                using (var dbTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var dbEntityEntry = _context.Entry(entity);
                        if (dbEntityEntry.State == EntityState.Detached)
                        {
                            DbSet.Attach(entity);
                        }

                        dbEntityEntry.State = EntityState.Modified;
                        _context.SaveChanges();
                        dbTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                    }                   
                }
            }
        }

        //First part of delete ... Find by Id ... Then delete entity in next method
        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        //Delete entity
        public virtual void Delete(T entity)
        {
            using (_context)
            {
                using (var dbTransaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var dbEntityEntry = _context.Entry(entity);
                        if (dbEntityEntry.State != EntityState.Deleted)
                        {
                            dbEntityEntry.State = EntityState.Deleted;
                            _context.SaveChanges();
                            dbTransaction.Commit();
                        }
                        else
                        {
                            DbSet.Attach(entity);//keep?
                            DbSet.Remove(entity);
                        }
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                    }
                }
            }
        }
                     
      

       


        //use to delete all records where Id equals id  ex use in controller "_baseBC.Delete(n => n.Id = id)" 
        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = DbSet.Where(predicate).AsQueryable();
            foreach (T obj in query)
            {
                DbSet.Remove(obj);
            }
        }
              



        public virtual T Save(T entity)
        {
            //obj.Validate();

            T retVal = new T();

            return retVal;
        }
       
        public virtual void DeleteSoft(int id)
        {
            throw new Exception("The method or operation is not implemented.");
        }

    }
}
