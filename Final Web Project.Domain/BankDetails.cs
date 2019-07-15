using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Final_Web_Project.Domain
{
    public class BankDetails
    {
        [Required]
        public string FullName { get; set; }

        public string LongCardNumber { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string CvcNumber { get; set; }

        public string CardHolderAddress { get; set; }

        public string PhoneNumber { get; set; }
    }
}
