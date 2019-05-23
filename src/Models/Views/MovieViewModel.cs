using System;
using System.ComponentModel.DataAnnotations;
using MvcMovie.Models.Database;

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
