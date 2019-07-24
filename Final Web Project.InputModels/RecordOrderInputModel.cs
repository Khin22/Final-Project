using Final_Web_Project.Services.Mapping;
using Final_Web_Project.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.InputModels
{
    public class RecordOrderInputModel : IMapTo<OrderServiceModel>
    {
        public string RecordId { get; set; }

        public int Quantity { get; set; }
    }
}
