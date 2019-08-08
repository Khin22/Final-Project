using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.Domain
{
    public class Receipt : BaseModel<string>
    {
        public Receipt()
        {
            this.Orders = new List<Order>();
        }

        public DateTime IssuedOn { get; set; }

        public List<Order> Orders { get; set; }

        public string RecipientId { get; set; }

        public FinalWebProjectUser Recipient { get; set; }

        public int ReceiptStatusId { get; set; }

        public ReceiptStatus ReceiptStatus { get; set; }

        public string DeliveryId { get; set; }

        public DeliveryDetails DeliveryDetails { get; set; }
    }
}
