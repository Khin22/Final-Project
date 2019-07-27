using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.Domain
{
    public class Order
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public string RecordId { get; set; }

        public Record Record { get; set; }

        public int Quantity { get; set; }

        public string IssuerId { get; set; }

        public FinalWebProjectUser Issuer { get; set; }

        public  int StatusId { get; set; }

        public OrderStatus Status { get; set; }

    }
}
