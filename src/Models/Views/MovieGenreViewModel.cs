using MvcMovie.Models.Database;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models.Views
{
    public class MovieGenreViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<SelectListItem> Genres { get; set; }
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}
