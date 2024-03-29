﻿using Final_Web_Project.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Final_Web_Project.Domain
{
    public class Record
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Album Name")]
        public string AlbumName { get; set; }

        [Required]
        [Display(Name = "Date Produced")]
        public DateTime DateProduced { get; set; }

        [Required]
        public string Artist { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0,00", "79228162514264337593543950335")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public int Quantity { get; set; }
    }
}
