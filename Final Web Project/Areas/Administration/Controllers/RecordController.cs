using System;
using System.Collections.Generic;
using System.Globalization;
using Final_Web_Project.Services.Mapping;
using System.Linq;
using System.Threading.Tasks;
using Final_Web_Project.Data;
using Final_Web_Project.InputModels;
using Final_Web_Project.Services;
using Final_Web_Project.Services.ServiceModels;
using Final_Web_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final_Web_Project.ViewModels.Record;
using Microsoft.AspNetCore.Authorization;

namespace Final_Web_Project.Areas.Administration.Controllers
{
    public class RecordController : AdminController
    {
        private readonly IRecordService recordService;
        private readonly ICloudinaryService cloudinaryService;

        public RecordController(IRecordService recordService, ICloudinaryService cloudinaryService)
        {
            this.recordService = recordService;
            this.cloudinaryService = cloudinaryService;
        }

        [HttpGet("/Administration/Record/Genre/Create")]
        public async Task<IActionResult> CreateGenre()
        {
            return this.View("Genre/Create");
        }

        [HttpPost("/Administration/Record/Genre/Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateGenre(GenreCreateInputModel genreTypeCreateInputModel)
        {

            if (!this.ModelState.IsValid)
            {
                return this.View(genreTypeCreateInputModel ?? new GenreCreateInputModel());
            }

            GenreServiceModel genreServiceModel = new GenreServiceModel
            {
                Name = genreTypeCreateInputModel.Name
            };

            await this.recordService.CreateGenre(genreServiceModel);

            return this.Redirect("/");
        }

        [HttpGet]
        [Route("/Administration/Record/Genre/Delete")]
        public async Task<IActionResult> DeleteGenre()
        {
            GenreDeleteViewModel genreDeleteModel = (await this.recordService.GetAllGenres().FirstAsync()).To<GenreDeleteViewModel>();

            if (genreDeleteModel == null)
            {
                return this.Redirect("/");
            }

            var allGenres = await this.recordService.GetAllGenres().ToListAsync();

            this.ViewData["types"] = allGenres.Select(genre => new GenreDeleteViewModel
            {
                Name = genre.Name
            })
                .ToList();

            return this.View("Genre/Delete", genreDeleteModel);
        }

        [HttpPost]
        [Route("/Administration/Record/Genre/Delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletedGenre(string name)
        {

            await this.recordService.DeleteGenre(name);

            return this.Redirect("/");
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            var allGenres = await this.recordService.GetAllGenres().ToListAsync();

            this.ViewData["types"] = allGenres.Select(genre => new GenreCreateViewModel
            {
                Name = genre.Name
            })
                .ToList();

            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(RecordCreateInputModel recordCreateInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                var allGenres = await this.recordService.GetAllGenres().ToListAsync();

                this.ViewData["types"] = allGenres.Select(genre => new GenreCreateViewModel
                {
                    Name = genre.Name
                })
                    .ToList();

                return this.View();
            }

            string pictureUrl = await this.cloudinaryService.UploadPictureAsync(recordCreateInputModel.Picture, recordCreateInputModel.AlbumName);

            RecordServiceModel recordCreate = AutoMapper.Mapper.Map<RecordServiceModel>(recordCreateInputModel);

            recordCreate.Picture = pictureUrl;

            await this.recordService.Create(recordCreate);

            return this.Redirect("/");
        }

        [HttpGet(Name = "Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            RecordEditInputModel recordEditInputModel = (await this.recordService.GetById(id)).To<RecordEditInputModel>();

            if (recordEditInputModel == null)
            {
                //error handlling
                return this.Redirect("/");
            }

            var allGenres = await this.recordService.GetAllGenres().ToListAsync();

            this.ViewData["types"] = allGenres.Select(genre => new GenreCreateViewModel
            {
                Name = genre.Name
            })
                .ToList();

            return this.View(recordEditInputModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id, RecordEditInputModel recordEditInputModel)
        {
            if (!this.ModelState.IsValid)
            {
                var allGenres = await this.recordService.GetAllGenres().ToListAsync();

                this.ViewData["types"] = allGenres.Select(genre => new GenreCreateViewModel
                {
                    Name = genre.Name
                })
                    .ToList();

                return this.View(recordEditInputModel);
            }

            string pictureUrl = await this.cloudinaryService.UploadPictureAsync(recordEditInputModel.Picture, recordEditInputModel.AlbumName);

            RecordServiceModel recordCreate = AutoMapper.Mapper.Map<RecordServiceModel>(recordEditInputModel);

            recordCreate.Picture = pictureUrl;

            await this.recordService.Edit(id, recordCreate);

            return this.Redirect("/");
        }

        [HttpGet(Name = "Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            RecordDeleteViewModel recordDeleteModel = (await this.recordService.GetById(id)).To<RecordDeleteViewModel>();

            if (recordDeleteModel == null)
            {
                //error handlling
                return this.Redirect("/");
            }

            var allGenres = await this.recordService.GetAllGenres().ToListAsync();

            this.ViewData["types"] = allGenres.Select(genre => new GenreDeleteViewModel
            {
                Name = genre.Name
            })
                .ToList();

            return this.View(recordDeleteModel);
        }

        [HttpPost]
        [Route("/Administration/Record/Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Deleted(string id)
        {
            await this.recordService.Delete(id);

            return this.Redirect("/");
        }
    }
}