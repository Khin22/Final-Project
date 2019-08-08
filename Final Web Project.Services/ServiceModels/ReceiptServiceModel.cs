using Final_Web_Project.Domain;
using Final_Web_Project.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.Services.ServiceModels
{
    public class ReceiptServiceModel : IMapFrom<Receipt>
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public List<OrderServiceModel> Orders { get; set; }

        public string RecipientId { get; set; }

        public FinalWebProjectUserServiceModel Recipient { get; set; }

        public ReceiptStatus ReceiptStatus { get; set; }
    }
}
