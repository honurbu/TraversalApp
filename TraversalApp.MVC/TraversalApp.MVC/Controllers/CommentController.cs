using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Services;
using TraversalApp.Service.Services;

namespace TraversalApp.MVC.Controllers
{
    public class CommentController : Controller
    {

        private readonly ICommentService _comment;

        public CommentController(ICommentService comment)
        {
            _comment = comment;
        }

        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.i = id;
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            _comment.AddAsync(comment);
            return RedirectToAction("Index","Destination");
        }
    }
}
