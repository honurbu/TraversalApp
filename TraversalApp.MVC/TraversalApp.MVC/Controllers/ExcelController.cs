using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using TraversalApp.Core.DTOs;
using TraversalApp.Core.Services;
using TraversalApp.Repository.Context;

namespace TraversalApp.MVC.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;
        private readonly AppDbContext _appDbContext;

        public ExcelController(IExcelService excelService, AppDbContext appDbContext)
        {
            _excelService = excelService;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<DestinationDto> DestinationList()
        {
            List<DestinationDto> destinationModels = new List<DestinationDto>();

            destinationModels = _appDbContext.Destinations.Select(x => new DestinationDto
            {
                City = x.City,
                DayNight = x.DayNight,
                Price = x.Price,
                Capacity = x.Capacity
            }).ToList();
            
            return destinationModels;
        }

        public IActionResult StaticExcelReport()
        {
            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniExcel.xlsx");
            //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
        }

        public IActionResult DestinationExcelReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

                int rowCount = 2;
                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.City;
                    workSheet.Cell(rowCount, 2).Value = item.DayNight;
                    workSheet.Cell(rowCount, 3).Value = item.Price;
                    workSheet.Cell(rowCount, 4).Value = item.Capacity;
                    rowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }
            }
        }
    }
}
