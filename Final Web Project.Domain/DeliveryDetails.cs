using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.Domain
{
    public class DeliveryDetails
    {
        public string Id { get; set; }

        public string TwoNames { get; set; }

        public string DeliveryAdderss { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string PhoneNumber { get; set; }

        public string ReceiptId { get; set; }

        public Receipt Receipt { get; set; }

        public DateTime IssuedOn { get; set; }

        public string RecipientId { get; set; }

        public FinalWebProjectUser Recipient { get; set; }


    }
}
