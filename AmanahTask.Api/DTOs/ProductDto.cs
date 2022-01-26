using AmanahTask.Core.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace AmanahTask.Api.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; } 
        [Required, MaxLength(180)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Color Color { get; set; }
        public double Price { get; set; }
        public string Comment { get; set; }
        public int CategoryId { get; set; }
    }
}
