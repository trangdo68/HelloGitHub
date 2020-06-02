using System;
using System.Collections.Generic;
using System.Linq;
using CMHGAdminData.Models;
using CMHGAdminDataObjects;
using CMHGAdminDomain.Mapping;
using CMHGAdminDomain.Interface;
using Microsoft.EntityFrameworkCore;


//Business Component: Get, List, Delete, Save, Search   
//Business Object: what is needed for presentation layer
//Mapper is to map an entity to a business object

namespace CMHGAdminDomain.BusinessComponents
{
    public class UserBC : BaseBC<TblUser>, IUserBC
    {
        private readonly DHRIM_CMHGContext _context;            

        public UserBC(DHRIM_CMHGContext context) : base(context)
        {
            _context = context;               
        }
               

        public TblUser GetUserRoleSiteById(int id)
        {
            TblUser userEF = new TblUser();
            try
            {
                userEF = _context.TblUser
                         .Include(b => b.UserRoles).ThenInclude(c => c.Role)
                         .Include(b => b.UserRoles).ThenInclude(c => c.Site)
                         .FirstOrDefault(m => m.UserId == id);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return userEF;
        }      
    }
}
