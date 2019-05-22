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
using System.Net;
using System.Net.Mail;
using MvcMovie;

namespace MvcMovie.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        protected const int DefaultPageNumber = 1;
        protected const int DefaultPageSize = 2; 
        
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
                UnitOfWork.Movies.Add(new Movie(mvm));
                UnitOfWork.Complete();
                return RedirectToAction("Index", "Movies");
            }
            return View(mvm);
        }

        [HttpGet("Index")]
        public IActionResult Index(string movieGenre, string searchString, string sortOrder, int? pageNumber = DefaultPageNumber, int? pageSize = DefaultPageSize) 
        {
            ViewData["TitleSortParam"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["ReleaseDateSortParam"] = sortOrder == "Release Date" ? "date_desc" : "ReleaseDate";
            ViewData["GenreSortParam"] = sortOrder == "Genre" ? "genre_desc" : "Genre";
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = movieGenre;
            var movies = UnitOfWork.Movies.GetAll().Select(m =>  new MovieViewModel(m)).ToList();
            var genresFound = movies.OrderBy(m => m.Genre).Select(m => m.Genre).ToList();
            if (!String.IsNullOrEmpty(searchString))
                movies = movies.Where(m => m.Title.ToLower().Contains(searchString.ToLower())).ToList();
            if (!String.IsNullOrEmpty(movieGenre))
                movies = movies.Where(m => m.Genre.Equals(movieGenre)).ToList();
            var movieGenreViewModel = new MovieGenreViewModel();
            movieGenreViewModel.Genres = genresFound.Distinct().Select(genre => new SelectListItem(genre, genre)).ToList();
            movieGenreViewModel.Movies = movies;
            switch(sortOrder)
            {
                case "title_desc":
                    movieGenreViewModel.Movies = movies.OrderByDescending(m => m.Title).ToList();
                    break;
                case "ReleaseDate":
                    movieGenreViewModel.Movies = movies.OrderBy(m => m.ReleaseDate).ToList();
                    break;
                case "date_desc":
                    movieGenreViewModel.Movies = movies.OrderByDescending(m => m.ReleaseDate).ToList();
                    break;
                case "Genre":
                    movieGenreViewModel.Movies = movies.OrderBy(m => m.Genre).ToList();
                    break;
                case "genre_desc":
                    movieGenreViewModel.Movies = movies.OrderByDescending(m=> m.Genre).ToList();
                    break;
                default:
                    movieGenreViewModel.Movies = movies.OrderBy(m => m.Title).ToList();
                    break;
            }
            movieGenreViewModel.pageSize = pageSize.Value;
            movieGenreViewModel.PagedList = PaginatedList<MovieViewModel>.CreatePaginatedList(movieGenreViewModel.Movies, pageNumber.Value, movieGenreViewModel.pageSize);
            return View(movieGenreViewModel);
        }

        [HttpGet("Edit")]
        public IActionResult Edit(int Id)
        {
            var movie = UnitOfWork.Movies.Get(Id);
            if (movie != null)
                return View(new MovieViewModel(movie));
            else
                return NotFound();
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
                movie.Rating = mvm.Rating;
                UnitOfWork.Complete();
                return RedirectToAction("Index", "Movies");
            }
            return View(mvm);
        }

        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var movie = UnitOfWork.Movies.GetMovieWithComments(id);
            if (movie == null)
                return NotFound();
            return View(new MovieViewModel(movie));
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var movie = UnitOfWork.Movies.Get(id);
            if (movie == null)
                return NotFound();
            return View(new MovieViewModel(movie));
        }

        [HttpPost("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            UnitOfWork.Movies.Remove(UnitOfWork.Movies.Get(id));
            UnitOfWork.Complete();
            return RedirectToAction("Index", "Movies");
        }

        [HttpGet("Email")]
        public IActionResult Email(int id)
        {
            var movie = UnitOfWork.Movies.Get(id);
            if (movie == null)
                return NotFound();
            return View(new MovieViewModel(movie));
        }

        [HttpPost("Email")]
        public IActionResult SendEmail(MovieViewModel mvm)
        {
            Movie m = UnitOfWork.Movies.Get(mvm.Id);
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("wnetcoretraining@gmail.com", "wtraining123");
            client.EnableSsl = true;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("wnetcoretraining@gmail.com");
            mailMessage.To.Add("wnetcoretraining@gmail.com");
            mailMessage.Body = "* Title: "+m.Title+" \n* Genre: "+m.Genre+" \n* Release date: "+m.ReleaseDate.ToString()+" \n* Price: "+m.Price.ToString()+" \n* Rating: "+m.Rating;
            mailMessage.Subject = "subject";
            client.Send(mailMessage);
            return RedirectToAction("Index", "Movies");
        }
    }
}
