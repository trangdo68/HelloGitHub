using CMHGAdminData.Models;
using CMHGAdminDomain.Interface;

//Business Components: Get, List, Delete, Save, Search are in the base class. This interface can extend the base class and also passes in the entity class value that the base class references ie. <T>  
//Business Object: what is needed for presentation layer

namespace CMHGAdminDomain.BusinessComponents
{
    public interface IUserBC : IBaseBC<TblUser> 
    {
        TblUser GetUserRoleSiteById(int id);    
    }
}
