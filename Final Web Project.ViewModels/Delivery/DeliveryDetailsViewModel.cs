using AutoMapper;
using Final_Web_Project.Services.Mapping;
using Final_Web_Project.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.ViewModels.Delivery
{
    public class DeliveryDetailsViewModel : IMapFrom<DeliveryDetailsServiceModel>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string TwoNames { get; set; }

        public DateTime IssuedOn { get; set; }

        public string DeliveryAdderss { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string PhoneNumber { get; set; }

        public string ReceiptId { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration   
                .CreateMap<DeliveryDetailsServiceModel, DeliveryDetailsViewModel>()
                .ForMember(destination => destination.ReceiptId,
                            opts => opts.MapFrom(origin => origin.Receipt.Id));
        }
    }
}
