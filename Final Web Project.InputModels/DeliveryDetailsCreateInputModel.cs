using AutoMapper;
using Final_Web_Project.Services.Mapping;
using Final_Web_Project.Services.ServiceModels;
using Final_Web_Project.ViewModels.Delivery;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Final_Web_Project.InputModels
{
    public class DeliveryDetailsCreateInputModel : IMapFrom<DeliveryDetailsServiceModel>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Required]
        public string TwoNames { get; set; }

        [Required]
        public string DeliveryAdderss { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string ReceiptId { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<DeliveryDetailsCreateInputModel, DeliveryDetailsServiceModel>();
        }
    }
}
