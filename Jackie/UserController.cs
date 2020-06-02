using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMHGAdminDomain.Interface;
using CMHGAdminDataObjects;
using Microsoft.Extensions.Localization;
using CMHGAdminDomain.BusinessComponents;

using AutoMapper;
using CMHGAdminData.Models;


namespace CMHGAdminCore.Controllers
{ 
    public class UserController : BaseController
    {
        private readonly DHRIM_CMHGContext _context;
        private readonly IUserBC _userBC; 
        private readonly IMapper _mapper;


        public UserController(DHRIM_CMHGContext context, IStringLocalizer<SharedResources> SharedLocalizer,  IMapper mapper, IUserBC userBC) : base(SharedLocalizer) 
        {
            _userBC = userBC;
            _context = context;
            _mapper = mapper;
        }
        
        // GET: User   
        public IActionResult Index()
        {           
            var users = _userBC.List().OrderBy(p => p.Firstname);
            return View(_mapper.Map<List<UserObj>>(users));
        }
        
        
        // GET: User/Details/5
        //public async Task<IActionResult> Details(int ? id)
        public IActionResult Details(int id)
        {          
            var user = _userBC.GetUserRoleSiteById(id);

            if (user == null)
                return NotFound();

            return View(_mapper.Map<UserObj>(user));
        }
        
        // GET: User/Create
        public IActionResult Create()
        {
            //var user = new UserObj();
            // return View(user);
            return RedirectToAction(nameof(Index));
        }
        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("UserId,LabelE,LabelF,DescriptionE,DescriptionF,EnvironmentId,AcronymE,AcronymF,Active,Precedence")] TblUser tblUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _UserRepo.AddAsync(tblUser);
        //       return RedirectToAction(nameof(Index));
        //    }
        //    return View(tblUser);
        //}

        //   GET: User/Edit/5
        public IActionResult Edit(int id)
        {
           
            var user = _userBC.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UserObj>(user));
        }


        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Edit(int id, [Bind(include: "UserId,Firstname,Lastname,EmailExchange,Phone,Fax,DateCreated,DateModified,CreatorId,ModifierId,Username,Password,EmailSmtp,DatePasswordModified, Active,siteid,roleid")] TblUser user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _userBC.Update(user);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            //return View("Details");
        }

        // GET: User/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _userBC.GetById((int)id);
            if (user == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<UserObj>(user));
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id, [Bind(include: "UserId,Firstname,Lastname,EmailExchange,Phone,Fax,DateCreated,DateModified,CreatorId,ModifierId,Username,Password,EmailSmtp,DatePasswordModified, Active,siteid,roleid")] TblUser user)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            _userBC.Delete(user);
            return RedirectToAction(nameof(Index));
        }
    }   
}
