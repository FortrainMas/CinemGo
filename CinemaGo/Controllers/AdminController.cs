﻿using System;
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
        public async Task<IActionResult> AddFile(string name, string disc, IFormFile photo, string trailer, string filmLink) 
        {
            var link = "dfsdfsdfsd";
            string img;
            if (name != null) 
            {
                Random r = new Random();
                string Path = "/img/" + photo.FileName + r.Next(0, 9999999).ToString();
                using (var fs = new FileStream(_appEnviroment.WebRootPath + Path, FileMode.Create)) 
                {
                    await photo.CopyToAsync(fs);
                }
                img = Path;
                using (MyDbContext db = new MyDbContext()) 
                {
                    Film film = new Film() { Name = name, Disc = disc, Img = img, Link = link };
                    FilmPage fm = new FilmPage() { Name = name, Discription = disc, Img = img, FilmLink = filmLink, TrailerLink = trailer, Link = link };
                    db.Films.Add(film);
                    db.FilmPages.Add(fm);
                    db.SaveChanges();
                }
            }
           
            return RedirectToAction("Index");
        }
    }
}