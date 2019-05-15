using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models.Views
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
