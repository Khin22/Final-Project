using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Final_Web_Project.Data;
using Final_Web_Project.InputModels;
using Final_Web_Project.Services;
using Final_Web_Project.Services.ServiceModels;
using Microsoft.AspNetCore.Mvc;

namespace Final_Web_Project.Areas.Administration.Controllers
{
    public class RecordController : AdminController
    {
        private readonly IRecordSerice recordSerice;
        private readonly FinalWebProjectDbContext context;
        private readonly ICloudinaryService cloudinaryService;

        public RecordController(IRecordSerice recordSerice, FinalWebProjectDbContext context, ICloudinaryService cloudinaryService)
        {
            this.recordSerice = recordSerice;
            this.context = context;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecordCreateInputModel recordCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            string pictureUrl = await this.cloudinaryService.UploadPictureAsync(recordCreateInputModel.Picture, recordCreateInputModel.AlbumName);

            RecordServiceModel recordCreate = AutoMapper.Mapper.Map<RecordServiceModel>(recordCreateInputModel);

            recordCreate.Picture = pictureUrl;

            await this.recordSerice.Create(recordCreate);

            return this.Redirect("/");
        }
    }
}