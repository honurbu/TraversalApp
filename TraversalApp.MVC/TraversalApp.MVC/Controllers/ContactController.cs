using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.DTOs.ContactDTO;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Services;

namespace TraversalApp.MVC.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;
        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {
            _contactUsService = contactUsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Index(SendMessageDto sendMessageDto)
        {
            if (ModelState.IsValid)
            {
                await _contactUsService.AddAsync(new ContactUs
                {

                    Content = sendMessageDto.Content,
                    Mail = sendMessageDto.Mail,
                    Name = sendMessageDto.Name,
                    Subject = sendMessageDto.Subject,
                    MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    Status = true
                });


                return RedirectToAction("Index","Default");
            }


            return View(sendMessageDto);
        }
    }
}
