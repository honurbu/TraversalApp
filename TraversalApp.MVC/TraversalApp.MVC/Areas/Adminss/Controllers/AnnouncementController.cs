using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.DTOs;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Services;

namespace TraversalApp.MVC.Areas.Adminss.Controllers
{
    [Area("Adminss")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var announcement = await _announcementService.GetAllAsync();
            var announcementDto = _mapper.Map<List<AnnouncementDto>>(announcement);

            return View(announcementDto);
        }


        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddAnnouncement(AnnouncementDto announcementDto)
        {
            if (ModelState.IsValid)
            {
                var announcement = await _announcementService.AddAsync(_mapper.Map<Announcement>(announcementDto));
                var announcementDtos = _mapper.Map<AnnouncementDto>(announcement);
                return View(announcementDtos);

            }
            return View();
        }


        public async Task<IActionResult> DeleteAnnouncement(int id)
        {
            var announcement = await _announcementService.GetByIdAsync(id);
            await _announcementService.RemoveAsync(announcement);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateAnnouncement(int id)
        {
            var announcement = await _announcementService.GetByIdAsync(id);
            var announcementDto = _mapper.Map<AnnouncementDto>(announcement);
            return View(announcementDto);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateAnnouncement(AnnouncementDto announcementDto)
        {
            if (ModelState.IsValid)
            {
                await _announcementService.UpdateAsync(_mapper.Map<Announcement>(announcementDto));
                return View();
            }

            return View("Index");

        }



    }
}
