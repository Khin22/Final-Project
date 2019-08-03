using Final_Web_Project.Services.Mapping;
using Final_Web_Project.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.ViewModels.Record
{
    public class RecordDetailsViewModel : IMapFrom<RecordServiceModel>
    {
        public string Id { get; set; }

        public string AlbumName { get; set; }

        public string Artist { get; set; }

        public DateTime DateProduced { get; set; }

        public int Quantity { get; set; }

        public string GenreName { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }
    }
}
