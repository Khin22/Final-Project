using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.Services.ServiceModels
{
    public class RecordServiceModel
    {
        public string Id { get; set; }

        public string AlbumName { get; set; }

        public string Artist { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public int Quantity { get; set; }
    }
}
