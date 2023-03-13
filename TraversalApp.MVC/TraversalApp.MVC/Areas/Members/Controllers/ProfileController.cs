using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.DTOs;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Services;

namespace TraversalApp.MVC.Areas.Members.Controllers
{
    [Area("Members")]
    [Route("Members/[controller]/[action]")]

    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _service;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto editDto = new UserEditDto();

            editDto.Name = values.Name;
            editDto.Surname = values.Surname;
            editDto.UserName = values.UserName;
            editDto.Email = values.Email;
            editDto.PhoneNumber = values.PhoneNumber;

            return View(editDto);
        }


        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (userEditDto.Images != null)
            {
                var resources = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(userEditDto.Images.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resources + "/wwwroot/userImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await userEditDto.Images.CopyToAsync(stream);
                user.ImageUrl = imageName;
            }

            user.Name = userEditDto.Name;
            user.Surname = userEditDto.Surname;
            user.UserName = userEditDto.UserName;
            user.Email = userEditDto.Email;
            user.PhoneNumber = userEditDto.PhoneNumber;
            user.ConfirmPassword = userEditDto.ConfirmPassword;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDto.Password);

           


            if (userEditDto.Password != null && userEditDto.Password == userEditDto.ConfirmPassword)
            {
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }

            }

            return View();
        }


    }
}
