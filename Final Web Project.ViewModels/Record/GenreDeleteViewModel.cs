using Final_Web_Project.Services.Mapping;
using Final_Web_Project.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.ViewModels.Record
{
    public class GenreDeleteViewModel : IMapFrom<GenreServiceModel>
    {
        public string Name { get; set; }
    }
}
