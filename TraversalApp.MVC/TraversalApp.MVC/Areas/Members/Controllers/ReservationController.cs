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

        public async Task<IActionResult> ActiveReservation()
        {
            var userId = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.GetApprovalReservationByAccepted(userId.Id);
            return View(values);
        }

        public async Task<IActionResult> OldReservation()
        {
            var userId = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.GetApprovalReservationByPrevious(userId.Id);
            return View(values);
        }   
        
        public async  Task<IActionResult> ApprovalReservation()
        {
            var userId = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.GetApprovalReservationByWaitApproval(userId.Id);
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
            //reservation.Status = "Onay Bekliyor !";
           var c = reservation.RStatusId = 1;
           reservation.RStatusId = 1;
        
            var userId = await _userManager.FindByNameAsync(User.Identity.Name);
            reservation.AppUserId = userId.Id;
            await _reservationService.AddAsync(reservation);
            
            return RedirectToAction("ActiveReservation","Members/Reservation", new { area = "" }); //BU alana girtmiyor ? url önünde members istiyor sanırım. çöz.
            //return RedirectToAction("ActiveReservation/Reservation");
        }
    }
}
