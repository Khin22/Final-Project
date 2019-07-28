using Final_Web_Project.Services.Mapping;
using Final_Web_Project.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.ViewModels.Receipt.Details
{
    public class ReceiptDetailsOrderViewModel : IMapFrom<OrderServiceModel>
    {
        public string RecordAlbumName { get; set; }

        public decimal RecordPrice { get; set; }

        public int Quantity { get; set; }
    }
}
