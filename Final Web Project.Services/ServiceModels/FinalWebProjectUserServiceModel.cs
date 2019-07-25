using Final_Web_Project.DataModels;
using Final_Web_Project.Services.Mapping;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.Services.ServiceModels
{
    public class FinalWebProjectUserServiceModel : IdentityUser, IMapFrom<FinalWebProjectUser>
    {
        public List<OrderServiceModel> Orders { get; set; }
    }
}
