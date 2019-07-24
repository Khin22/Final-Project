using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.Services.ServiceModels
{
    public class FinalWebProjectUserServiceModel : IdentityUser
    {
        public List<OrderServiceModel> Orders { get; set; }
    }
}
