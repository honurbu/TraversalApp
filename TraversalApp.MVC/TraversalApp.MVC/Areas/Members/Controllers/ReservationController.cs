using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Services;

namespace TraversalApp.MVC.Areas.Members.Controllers
{
    [Area("Members")]
    public class ReservationController : Controller
    {

        private readonly IReservationService _reservationService;
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(IReservationService reservationService, IDestinationService destinationService, UserManager<AppUser> userManager)
        {
            _reservationService = reservationService;
            _destinationService = destinationService;
            _userManager = userManager;
        }

        public IActionResult ActiveReservation()
        {
            return View();
        }

        public IActionResult OldReservation()
        {
            return View();
        }   
        
        public async  Task<IActionResult> ApprovalReservation()
        {
            var userId = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.GetApprovalReservation(userId.Id);
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> NewReservation()
        {
            List<SelectListItem> values = (from x in await _destinationService.GetAllAsync() select new SelectListItem { Text = x.City,Value=x.Id.ToString()}).ToList();
            ViewBag.value = values;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> NewReservation(Reservation reservation)
        {
            reservation.Status = "Onay Bekliyor !";
            var userId = await _userManager.FindByNameAsync(User.Identity.Name);
            reservation.AppUserId = userId.Id;
            await _reservationService.AddAsync(reservation);
            
            return RedirectToAction("ActiveReservation","Reservation");
            //return RedirectToAction("ActiveReservation/Reservation");
        }
    }
}
