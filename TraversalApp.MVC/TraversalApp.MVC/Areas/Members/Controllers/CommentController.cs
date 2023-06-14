using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Services;
using TraversalApp.Service.Services;

namespace TraversalApp.MVC.Areas.Members.Controllers
{
    [Area("Members")]
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _commentService.GetListCommentWithAppUser(userId.Id);
            return View(values);
        }
    }
}
