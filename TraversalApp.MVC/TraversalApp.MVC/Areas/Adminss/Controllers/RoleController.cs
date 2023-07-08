using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraversalApp.Core.DTOs;
using TraversalApp.Core.Entites;

namespace TraversalApp.MVC.Areas.Adminss.Controllers
{
    [Area("Adminss")]
    [Route("Adminss/Role")]

    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpGet]
        [Route("CreateRole")]

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateRole")]

        public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
        {
            AppRole appRole = new AppRole()
            {
                Name = createRoleDto.RoleName
            };

            var result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(createRoleDto);
            }

        }


        [Route("RemoveRole/{id}")]
        public async Task<IActionResult> RemoveRole(int id)
        {
            var values = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            await _roleManager.DeleteAsync(values);
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("UpdateRole/{id}")]

        public async Task<IActionResult> UpdateRole(int id)
        {
            var roles = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            UpdateRoleDto updateRoles = new UpdateRoleDto()
            {
                Id = roles.Id,
                RoleName = roles.Name
            };

            return View(updateRoles);

        }



        [HttpPost]
        [Route("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto roleDto)
        {
            var roles = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == roleDto.Id);
            roles.Name = roleDto.RoleName;
            await _roleManager.UpdateAsync(roles);
            return RedirectToAction("Index");

        }


        [HttpGet]
        [Route("UserList")]
        public async Task<IActionResult> UserList()
        {
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }


        [HttpGet]
        [Route("AssignRole/{id}")]

        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x=>x.Id==id);
            TempData["UserId"] = user.Id;
            var roles = await _roleManager.Roles.ToListAsync();

            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignDto> roleAssignDtos = new List<RoleAssignDto>();
            foreach(var item in roles)
            {
                RoleAssignDto roleModel = new RoleAssignDto();
                roleModel.Id = item.Id;
                roleModel.RoleName = item.Name;
                roleModel.RoleExist = userRoles.Contains(item.Name);
                roleAssignDtos.Add(roleModel);
            }
            return View(roleAssignDtos);
        }


        [HttpPost]
        [Route("AssignRole/{id}")]
        public async Task<IActionResult> AssignRole(List<RoleAssignDto> roleAssignDtos)
        {
            var userId = (int)TempData["UserId"];
            var user = await _userManager.Users.FirstOrDefaultAsync(x=>x.Id == userId);

            foreach(var item in roleAssignDtos)
            {
                if(item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return RedirectToAction("UserList");
        }

    }
}
