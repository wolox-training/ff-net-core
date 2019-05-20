using MvcMovie.Models.Database;
using System.Collections.Generic;

namespace MvcMovie.Repositories.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Movie GetMovieWithComments(int id);
    }
}
