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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMovie.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public MoviesController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get { return this._unitOfWork; } }

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
            return RedirectToAction("Index", "Movies");
        }

        [HttpGet("Index")]
        public IActionResult Index() => View(UnitOfWork.Movies.GetAll().Select(m => new MovieViewModel { Id = m.Id, ReleaseDate = m.ReleaseDate, Title = m.Title, Genre = m.Genre, Price = m.Price } ).ToList());

        [HttpGet("Edit")]
        public IActionResult Edit(int Id)
        {
            var movie = UnitOfWork.Movies.Get(Id);
            if (movie != null)
            {
                return View(new MovieViewModel { Id = movie.Id, Title = movie.Title, ReleaseDate = movie.ReleaseDate, Genre = movie.Genre, Price = movie.Price } );
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Edit")]
        public IActionResult Edit(MovieViewModel mvm)
        {
            if (ModelState.IsValid)
            {
                var movie = UnitOfWork.Movies.Get(mvm.Id);
                movie.Price = mvm.Price;
                movie.ReleaseDate = mvm.ReleaseDate;
                movie.Title = mvm.Title;
                movie.Genre = mvm.Genre;
                UnitOfWork.Complete();
            }
            return RedirectToAction("Index", "Movies");
        }

        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var movie = UnitOfWork.Movies.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(new MovieViewModel { Title = movie.Title, ReleaseDate = movie.ReleaseDate, Genre = movie.Genre, Price = movie.Price } );
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var movie = UnitOfWork.Movies.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(new MovieViewModel { Title = movie.Title, ReleaseDate = movie.ReleaseDate, Genre = movie.Genre, Price = movie.Price } );
        }

        [HttpPost("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            UnitOfWork.Movies.Remove(UnitOfWork.Movies.Get(id));
            UnitOfWork.Complete();
            return RedirectToAction("Index", "Movies");
        }
    }
}
