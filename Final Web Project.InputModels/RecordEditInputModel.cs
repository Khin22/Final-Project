using AutoMapper;
using Final_Web_Project.Services.Mapping;
using Final_Web_Project.Services.ServiceModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Final_Web_Project.InputModels
{
    public class RecordEditInputModel : IMapFrom<RecordServiceModel>, IMapTo<RecordServiceModel>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Required]
        public string AlbumName { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public DateTime DateProduced { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<RecordServiceModel, RecordEditInputModel>()
                .ForMember(destination => destination.Picture,
                            opts => opts.Ignore())
                .ForMember(destination => destination.Genre,
                            opts => opts.MapFrom(origin => new GenreServiceModel { Name = origin.Genre.Name }));

            configuration
                .CreateMap<RecordEditInputModel, RecordServiceModel>()
                .ForMember(destination => destination.Genre,
                            opts => opts.MapFrom(origin => new GenreServiceModel { Name = origin.Genre }));
        }
    }
}
