using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models.Database;
using MvcMovie.Repositories.Interfaces;

namespace MvcMovie.Controllers
{
    [Authorize]
    [Route("/api/v1/[controller]")]
    public class CommentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public CommentsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get { return this._unitOfWork; } }

        [HttpPost("SendComment")]
        public IActionResult SendComment(string text, int id)
        {
            var movie = UnitOfWork.Movies.Get(id);
            Comment c = new Comment { Movie = movie, Text = text};
            UnitOfWork.Comments.Add(c);
            UnitOfWork.Complete();
            return StatusCode(200);
        }
    }
}
