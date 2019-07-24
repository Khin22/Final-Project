using Final_Web_Project.Domain;
using Final_Web_Project.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Web_Project.Services.ServiceModels
{
    public class GenreServiceModel : IMapFrom<Genre>, IMapTo<Genre>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
