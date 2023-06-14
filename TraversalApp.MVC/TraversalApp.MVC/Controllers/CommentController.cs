using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Services;
using TraversalApp.Service.Services;

namespace TraversalApp.MVC.Controllers
{
    public class CommentController : Controller
    {

        private readonly ICommentService _comment;
        private readonly UserManager<AppUser> _userManager;


        public CommentController(ICommentService comment, UserManager<AppUser> userManager = null)
        {
            _comment = comment;
            _userManager = userManager;
        }

        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.i = id;
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            var userId = await _userManager.FindByNameAsync(User.Identity.Name);

            comment.AppUserID = userId.Id;
            comment.CommentUser = userId.UserName;
            //comment.AppUser.ImageUrl = userId.ImageUrl;
            comment.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            await _comment.AddAsync(comment);
            return RedirectToAction("Index","Destination");
        }
    }
}
