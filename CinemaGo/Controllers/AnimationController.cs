using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaGo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaGo.Controllers
{
    public class AnimationController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new MyDbContext())
            {
                List<Film> films = db.Films.ToList<Film>();
                List<Film> AnimationFilms = new List<Film>();
                foreach (var film in films.Where(a => a.Genre == "Animation"))
                {
                    AnimationFilms.Add(film);
                }
                ViewData["Films"] = AnimationFilms;
            }
            return View();
        }
    }
}