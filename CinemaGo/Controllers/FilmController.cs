using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaGo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaGo.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index(string f)
        {
            using (var db = new MyDbContext()) 
            {
                List<FilmPage> Pages = db.FilmPages.ToList<FilmPage>();
                //Find db FilmPage film which link is filmlink
                FilmPage film = Pages.FirstOrDefault(a=>a.Link == f);
                film.FilmViews += 1;
                db.FilmPages.Update(film);
                db.SaveChanges();
                ViewData["Film"] = film;
            }
            return View();
        }
    }
}