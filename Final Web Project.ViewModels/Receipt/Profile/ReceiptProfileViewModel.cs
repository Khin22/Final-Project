using AutoMapper;
using Final_Web_Project.Domain;
using Final_Web_Project.Services.Mapping;
using Final_Web_Project.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Final_Web_Project.ViewModels.Receipt.Profile
{
    public class ReceiptProfileViewModel : IMapFrom<ReceiptServiceModel>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public decimal Total { get; set; }

        public int Records { get; set; }

        public int StatusId { get; set; }

        public ReceiptStatus ReceiptStatus { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ReceiptServiceModel, ReceiptProfileViewModel>()
                .ForMember(destination => destination.Total,
                            opts => opts.MapFrom(origin => origin.Orders.Sum(order => order.Record.Price * order.Quantity)))
                .ForMember(destination => destination.Records,
                            opts => opts.MapFrom(origin => origin.Orders.Sum(order => order.Quantity)));
        }
    }
}
