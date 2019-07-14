using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Web_Project.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace Final_Web_Project.Areas.Administration.Controllers
{
    public class RecordController : AdminController
    {
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


            return this.Redirect("/");
        }
    }
}