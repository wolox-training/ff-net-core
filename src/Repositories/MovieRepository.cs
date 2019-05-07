using System.Linq;
using MvcMovie.Repositories.Interfaces;
using MvcMovie.Repositories.Database;
using MvcMovie.Models.Database;

namespace MvcMovie.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(DataBaseContext context) : base(context)
        {
        }

        public DataBaseContext DataBaseContext
        {
            get { return Context as DataBaseContext; }
        }
    }
}