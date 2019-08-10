using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Final_Web_Project.Models;
using Final_Web_Project.Services;
using Final_Web_Project.ViewModels.Home.Index;
using Microsoft.EntityFrameworkCore;

namespace Final_Web_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecordService recordService;

        public HomeController(IRecordService recordService)
        {
            this.recordService = recordService;
        }

        
        public async Task<IActionResult> Index([FromQuery]string ordering = null)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                List<RecordHomeViewModel> records = await this.recordService.GetAllRecords(ordering)
                    .Select(record => new RecordHomeViewModel
                    {
                        Id = record.Id,
                        AlbumName = record.AlbumName,
                        Artist = record.Artist,
                        Price = record.Price,
                        Picture = record.Picture,
                        
                    }).ToListAsync();

                this.ViewData["ordering"] = ordering;

                return this.View(records);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
