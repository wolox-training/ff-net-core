using System;
using System.ComponentModel.DataAnnotations;
using MvcMovie.Models.Database;

namespace MvcMovie.Models.Views
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }

        public MovieViewModel(Movie movie)
        {
            this.Id = movie.Id;
            this.Title = movie.Title;
            this.ReleaseDate = movie.ReleaseDate;
            this.Genre = movie.Genre;
            this.Price = movie.Price;
            this.Rating = movie.Rating;
        }
    }
}
