using Dara_Store.Application.Services.Users.Command.RegisterUser;
using Dara_Store.Application.Services.Users.Queries.GetUsers;
using Dara_Store.Application.Services.Users.Queries.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        public UsersController(IGetUsersService getUsersService , IGetRolesService getRolesService , IRegisterUserService registerUserService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
        }    
        [Area("Admin")]
        public IActionResult Index(string searchKey , int page=1)
        {
            return View(_getUsersService.Execute(new RequsetGetUserDto
            {
                page = page,
                SearchKey = searchKey,
            }));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data , "Id" , "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,
                roles = new List<RolesInRegisterUserDto>()
                {
                    new RolesInRegisterUserDto
                    {
                        Id = RoleId
                    }
                },
                Password = Password,
                RePassword = RePassword,
            });
            return Json(result);

        }
    }
}
