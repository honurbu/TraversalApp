using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Services;

namespace TraversalApp.MVC.Areas.Adminss.Controllers
{
    [Area("Adminss")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var values = _commentService.GetListCommentWithDestination();
            return View(values);
        }

        public async Task<IActionResult> DeleteComment(int id)
        {
            var values = await _commentService.GetByIdAsync(id);
            await _commentService.RemoveAsync(values);
            return RedirectToAction("Index");
        }
    }
}
