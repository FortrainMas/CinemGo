using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaGo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaGo.Controllers
{
    public class GenreController : Controller
    {
        public IActionResult Index(string g)
        {
            if (g == "0")
            {

            }
            else if (g == "Comedy") 
            {
                using (var db = new MyDbContext())
                {
                    List<Film> films = db.Films.ToList<Film>();
                    List<Film> Comedies = new List<Film>();
                    foreach (var film in films.Where(a => a.Genre == "Comedy"))
                    {
                        Comedies.Add(film);
                    }
                    ViewData["Films"] = Comedies;
                }
            }
            else if (g == "Action")
            {
                using (var db = new MyDbContext())
                {
                    List<Film> films = db.Films.ToList<Film>();
                    List<Film> Comedies = new List<Film>();
                    foreach (var film in films.Where(a => a.Genre == "Action"))
                    {
                        Comedies.Add(film);
                    }
                    ViewData["Films"] = Comedies;
                }
            }
            else if (g == "Drama")
            {
                using (var db = new MyDbContext())
                {
                    List<Film> films = db.Films.ToList<Film>();
                    List<Film> Comedies = new List<Film>();
                    foreach (var film in films.Where(a => a.Genre == "Drama"))
                    {
                        Comedies.Add(film);
                    }
                    ViewData["Films"] = Comedies;
                }
            }
            else if (g == "Fantasy")
            {
                using (var db = new MyDbContext())
                {
                    List<Film> films = db.Films.ToList<Film>();
                    List<Film> Comedies = new List<Film>();
                    foreach (var film in films.Where(a => a.Genre == "Fantasy"))
                    {
                        Comedies.Add(film);
                    }
                    ViewData["Films"] = Comedies;
                }
            }
            return View();
        }
    }
}