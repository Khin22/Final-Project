﻿using Final_Web_Project.Services.Mapping;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using Final_Web_Project.Services.ServiceModels;
using AutoMapper;

namespace Final_Web_Project.InputModels
{
    public class RecordCreateInputModel : IMapTo<RecordServiceModel>, IHaveCustomMappings
    {
        [Required]
        public string AlbumName { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string Genre { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<RecordCreateInputModel, RecordServiceModel>()
                .ForMember(destination => destination.Genre,
                            opts => opts.MapFrom(origin => new GenreServiceModel { Name = origin.Genre }));
        }
    }
}
