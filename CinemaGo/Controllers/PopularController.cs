using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaGo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaGo.Controllers
{
    public class PopularController : Controller
    {
        public IActionResult Index()
        {
            List<Film> RecomendsList = new List<Film>();
            List<Film> FilmsList = new List<Film>();
            Film RecomendFilm = new Film { FilmViews = 0,InFavList=0 };
            using (MyDbContext db = new MyDbContext()) 
            {
                FilmsList = db.Films.ToList();
                for (int i = 0; i < FilmsList.Count; i++)
                {
                    foreach (var film in FilmsList)
                    {
                        //If film alredy exist in recomend list loop skip it
                        if (RecomendsList.FirstOrDefault(a => a == film) == null)
                        {
                            //If film in list has got more "PopularPoints" then film in RecomendFilm it becomes recomend film
                            //PopularPoint is views * (how many add this film in favourite list * 100)
                            //Second term multiplies to 100 because it's more important
                            if (film.FilmViews * (film.InFavList * 100) > RecomendFilm.FilmViews * (RecomendFilm.InFavList * 100))
                            {
                                RecomendFilm = film;
                            }
                            
                        }
                    }
                    RecomendsList.Add(RecomendFilm);
                    RecomendFilm = new Film { FilmViews = 0, InFavList = 0 };
                }
            }
            ViewData["Films"] = RecomendsList;
            return View();
        }
    }
}