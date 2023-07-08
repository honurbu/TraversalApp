using AutoMapper.Internal;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalApp.Core.DTOs.ResetPasswordDTO;
using TraversalApp.Core.Entites;

namespace TraversalApp.MVC.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordDto forgetPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgetPasswordDto.Mail);  //find emails user.
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user); //create token for user.
            var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", 
            new
            {
                userId=user.Id,
                token = passwordResetToken
            },HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("honurbu Traversall Admini", "honurbutraversall@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetPasswordDto.Mail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = passwordResetTokenLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Şifre Değişiklik Talebi";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("honurbutraversall@gmail.com", "wdsrwpyilmsnholl");

            client.Send(mimeMessage);
            client.Disconnect(true);



            return View();
        }



        [HttpGet]
        public IActionResult ResetPassword(string userid, string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(PasswordResetDto passwordResetDto)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];

            if (userid == null || token == null)
            { 
                //throw new ArgumentNullException(nameof(userid))
            };

            var user = await _userManager.FindByIdAsync(userid.ToString());

            var result = await _userManager.ResetPasswordAsync(user, token.ToString(),passwordResetDto.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("SignIn","Login");
            }

            return View();
        }


    }
}
