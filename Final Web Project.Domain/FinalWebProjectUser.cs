using Microsoft.AspNetCore.Identity;
using System;

namespace Final_Web_Project.DataModels
{
    public class FinalWebProjectUser : IdentityUser
    {
        public FinalWebProjectUser()
        {

        }
        public FinalWebProjectUserRole UserRole { get; set; }
    }
}
