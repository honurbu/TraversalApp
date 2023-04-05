using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Services;

namespace TraversalApp.MVC.Areas.Adminss.Controllers
{
    [Area("Adminss")]

    public class UsersController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;

        public UsersController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _appUserService.GetAllAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            var users = await _appUserService.GetByIdAsync(id);
            await _appUserService.RemoveAsync(users);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(int id)
        {
            var users = await _appUserService.GetByIdAsync(id);
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(AppUser appUser)
        {
            await _appUserService.UpdateAsync(appUser);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CommentUser(int id)
        {
            await _appUserService.GetAllAsync();
            return View();
        }

        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.GetApprovalReservationByAccepted(id);
            return View(values);
        }
    }
}
