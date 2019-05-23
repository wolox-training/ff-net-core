using System;
using System.ComponentModel.DataAnnotations;
using MvcMovie.Models.Database;

namespace MvcMovie.Models.Views
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
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
