using Final_Web_Project.Services.Mapping;
using Final_Web_Project.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.ViewModels.Order
{
    public class OrderDeleteViewModel : IMapFrom<OrderServiceModel>
    {
        public string Id { get; set; }

        public string RecordPicture { get; set; }

        public decimal RecordPrice { get; set; }

        public string RecordAlbumName { get; set; }

        public int Quantity { get; set; }
    }
}
