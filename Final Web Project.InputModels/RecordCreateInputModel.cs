using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Final_Web_Project.InputModels
{
    public class RecordCreateInputModel
    {
        public string AlbumName { get; set; }

        public string Artist { get; set; }

        public decimal Price { get; set; }

        public IFormFile Picture { get; set; }

        public int Quantity { get; set; }
    }
}
