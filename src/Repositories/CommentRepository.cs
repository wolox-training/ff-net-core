using System.Linq;
using MvcMovie.Repositories.Interfaces;
using MvcMovie.Repositories.Database;
using MvcMovie.Models.Database;
using System.Collections.Generic;

namespace MvcMovie.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(DataBaseContext context) : base(context) {}

        public DataBaseContext DataBaseContext
        {
            get { return Context as DataBaseContext; }
        }
    }
}
