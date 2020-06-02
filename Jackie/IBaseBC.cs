using System.Collections.Generic;
using System.Linq;

namespace CMHGAdminDomain.Interface
{
    /// <summary>
    /// Contains virtual methods that can be used by extended classes. 
    /// Add a level of control and consistency to BC methods.
    /// </summary>
    /// <typeparam name="T">A Base Derived Class</typeparam>
    public interface IBaseBC<T> where T : class, new()
    {       
        #region Virtual Methods
        T GetById(int id);
        T Get(int id);
        IQueryable<T> GetAll(T entity);
        List<T> List();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Save(T entity);
       // int Delete(int id);
        void DeleteSoft(int id);

        #endregion
    }
}
