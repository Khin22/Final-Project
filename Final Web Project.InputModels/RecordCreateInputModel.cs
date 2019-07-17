using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Final_Web_Project.InputModels
{
    public class RecordCreateInputModel
    {
        [Required]
        public string AlbumName { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
