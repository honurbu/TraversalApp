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

        public ReservationController(IReservationService reservationService, IDestinationService destinationService)
        {
            _reservationService = reservationService;
            _destinationService = destinationService;
        }

        public IActionResult ActiveReservation()
        {
            return View();
        }

        public IActionResult OldReservation()
        {
            return View();
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
            reservation.AppUserId = 19;
            await _reservationService.AddAsync(reservation);
            return RedirectToAction("ActiveReservation");
        }
    }
}
