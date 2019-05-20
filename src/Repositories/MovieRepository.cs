using System.Linq;
using MvcMovie.Repositories.Interfaces;
using MvcMovie.Repositories.Database;
using MvcMovie.Models.Database;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(DataBaseContext Context) : base(Context) {}

        public DataBaseContext DataBaseContext
        {
            get { return Context as DataBaseContext; }
        }

        public Movie GetMovieWithComments(int id)
        {
            return Context.Movies.Include(m => m.Comments).Where(m => m.Id == id).FirstOrDefault();
        }
    }
}
