﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Final_Web_Project.Domain
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "invalid")]
        public string Name { get; set; }
    }
}
