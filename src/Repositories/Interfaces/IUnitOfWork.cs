using System;
using MvcMovie.Repositories.Database;

namespace MvcMovie.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository Movies { get; }
        int Complete();
    }
}
