using AutoMapper;
using Final_Web_Project.Services.Mapping;
using Final_Web_Project.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.ViewModels.Receipt.Details
{
    public class ReceiptDetailsViewModel : IMapFrom<ReceiptServiceModel>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Recipient { get; set; }

        public DateTime IssuedOn { get; set; }

        public List<ReceiptDetailsOrderViewModel> Orders { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<ReceiptServiceModel, ReceiptDetailsViewModel>()
                .ForMember(destination => destination.Recipient,
                            opts => opts.MapFrom(origin => origin.Recipient.UserName));
        }
    }
}
