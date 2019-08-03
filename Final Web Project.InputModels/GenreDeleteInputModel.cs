using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Final_Web_Project.InputModels
{
    public class GenreDeleteInputModel
    {
        [Required]
        public string Name { get; set; }
    }
}
