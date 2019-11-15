using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CinemaGo.Controllers
{
    public class AdminController : Controller
    {
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
    }
}