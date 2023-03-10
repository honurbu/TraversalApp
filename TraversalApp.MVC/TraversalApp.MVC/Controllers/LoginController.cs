using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.DTOs;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Services;
using TraversalApp.Service.Validations;

namespace TraversalApp.MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAppUserService _appUserService;


        public LoginController(UserManager<AppUser> userManager, IAppUserService appUserService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _appUserService = appUserService;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(AppUserDto appUserDto)
        {
            AppUserValidator validate = new AppUserValidator();


            var validateResult = validate.Validate(appUserDto);
            if (validateResult.IsValid) {
                AppUser user = new AppUser()
                {
                    Name = appUserDto.Name,
                    Surname = appUserDto.Surname,
                    Email = appUserDto.Email,
                    UserName = appUserDto.UserName,
                    ConfirmPassword = appUserDto.ConfirmPassword,
                };

                if (appUserDto.Password == appUserDto.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(user, appUserDto.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("SignIn");
                    }

                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
             }
            return View();
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(signInDto.UserName,signInDto.Password,false,true);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Profile", new {area = "Members"});
                }
                else
                {
                    return RedirectToAction("SignIn","Login");
                }
            }
            return View();
        }
    }
}
