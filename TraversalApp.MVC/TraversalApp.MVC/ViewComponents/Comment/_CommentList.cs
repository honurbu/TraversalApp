using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Services;

namespace TraversalApp.MVC.ViewComponents.Comment
{
    public class _CommentList : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CommentList(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.GetDestinationById(id);
            return View(values);
        }
    }
}
