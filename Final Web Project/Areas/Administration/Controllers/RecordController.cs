using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Final_Web_Project.Data;
using Final_Web_Project.InputModels;
using Final_Web_Project.Services;
using Microsoft.AspNetCore.Mvc;

namespace Final_Web_Project.Areas.Administration.Controllers
{
    public class RecordController : AdminController
    {
        private readonly IRecordSerice recordSerice;
        private readonly FinalWebProjectDbContext context;

        public RecordController(IRecordSerice recordSerice, FinalWebProjectDbContext context)
        {
            this.recordSerice = recordSerice;
            this.context = context;
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecordCreateInputModel recordCreateInputModel)
        {
            RecordCreateInputModel recordCreate = new RecordCreateInputModel
            {
                AlbumName = recordCreateInputModel.AlbumName,
                Artist = recordCreateInputModel.Artist,
                Price = recordCreateInputModel.Price,
                Quantity = recordCreateInputModel.Quantity
            };

            await this.recordSerice.Create(recordCreate);

            return this.Redirect("/");
        }
    }
}