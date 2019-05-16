using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MvcMovie.Models.Database
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string Rating { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
