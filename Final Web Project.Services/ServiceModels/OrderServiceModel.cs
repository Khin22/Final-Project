using Final_Web_Project.Domain;
using Final_Web_Project.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.Services.ServiceModels
{
    public class OrderServiceModel : IMapTo<Order>, IMapFrom<Order>
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public string RecordId { get; set; }

        public RecordServiceModel Record { get; set; }

        public int Quantity { get; set; }

        public string IssuerId { get; set; }

        public FinalWebProjectUserServiceModel Issuer { get; set; }

        public int StatusId { get; set; }

        public OrderStatusServiceModel Status { get; set; }
    }
}
