using System;
using System.ComponentModel.DataAnnotations;
using MvcMovie.Models.Views;

namespace MvcMovie.Models.Database
{
    public class Movie
    {
        public Movie(MovieViewModel movieVM)
        {
            this.Id = movieVM.Id;
            this.Title = movieVM.Title;
            this.ReleaseDate = movieVM.ReleaseDate;
            this.Genre = movieVM.Genre;
            this.Price = movieVM.Price;
            this.Rating = movieVM.Rating;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string Rating { get; set; }

        public Movie() {} 
    }
}
