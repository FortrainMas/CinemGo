using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CinemaGo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaGo.Controllers
{
    public class AdminController : Controller
    {
        IWebHostEnvironment _appEnviroment;
        public AdminController(IWebHostEnvironment appEnviroment) 
        {
            _appEnviroment = appEnviroment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string login, string password)
        {
            if (login == "adminUser23" && password == "zqadfdfer34")
            {
                ViewData["IsAdmin"] = "True";
            }
            else 
            {
                ViewData["IsAdmin"] = "False";
            }
            return View();
        }
        public async Task<IActionResult> AddFile(string name, string disc, string genre, IFormFile photo, string trailer, string filmLink) 
        {
            Random r = new Random();
            var link = r.Next(-99999,99999).ToString()+name;
            string img;
            if (name != null)
            {           
                string Path = @"\img\" + r.Next(0, 9999999).ToString() + photo.FileName;
                using (var fs = new FileStream(_appEnviroment.WebRootPath + Path, FileMode.Create)) 
                {
                    await photo.CopyToAsync(fs);
                }
                img = Path;
                using (MyDbContext db = new MyDbContext()) 
                {
                    Film film = new Film() { Name = name, Disc = disc, Img = img, Genre=genre, Link = link };
                    FilmPage fm = new FilmPage() { Name = name, Discription = disc, Img = img, FilmLink = filmLink, TrailerLink = trailer, Link = link, Genre = genre };
                    db.Films.Add(film);
                    db.FilmPages.Add(fm);
                    db.SaveChanges();
                }
            }
           
            return RedirectToAction("Index");
        }
    }
}