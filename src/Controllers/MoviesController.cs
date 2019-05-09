using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Repositories.Interfaces;
using MvcMovie.Repositories.Database;
using MvcMovie.Models.Views;
using MvcMovie.Models.Database;

namespace MvcMovie.Controllers
{
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public IUnitOfWork UnitOfWork { get { return this._unitOfWork; } }

        public MoviesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("Create")]
        public IActionResult Create() => View();

        [HttpPost("Create")]
        public IActionResult Create(MovieViewModel mvm)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.Movies.Add(new Movie { Title = mvm.Title, ReleaseDate = mvm.ReleaseDate, Genre = mvm.Genre, Price = mvm.Price });
                UnitOfWork.Complete();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("Index")]
        public IActionResult Index() => View(UnitOfWork.Movies.GetAll().Select(m => new MovieViewModel { Id = m.Id, ReleaseDate = m.ReleaseDate, Title = m.Title, Genre = m.Genre, Price = m.Price } ).ToList());
    }
}
