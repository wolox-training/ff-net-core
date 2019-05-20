using MvcMovie.Repositories.Database;
using MvcMovie.Repositories.Interfaces;

namespace MvcMovie.Repositories.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;

        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
            Movies = new MovieRepository(_context);
            Comments = new CommentRepository(_context);
        }

        public IMovieRepository Movies { get; private set; }
        public ICommentRepository Comments { get; private set; }

        public int Complete() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
