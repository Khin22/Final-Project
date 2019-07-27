using Final_Web_Project.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Final_Web_Project.Domain
{
    public class FinalWebProjectUser : IdentityUser
    {
        public FinalWebProjectUser()
        {
            this.Orders = new List<Order>();
        }
        public FinalWebProjectUserRole UserRole { get; set; }

        public List<Order> Orders { get; set; }
    }
}
