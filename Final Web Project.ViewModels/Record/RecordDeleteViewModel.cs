using Final_Web_Project.Services.Mapping;
using Final_Web_Project.Services.ServiceModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.ViewModels.Record
{
    public class RecordDeleteViewModel : IMapFrom<RecordServiceModel>
    {
        public string AlbumName { get; set; }

        public string Artist { get; set; }

        public DateTime DateProduced { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public int Quantity { get; set; }

        public GenreDeleteViewModel Genre { get; set; }
    }
}
