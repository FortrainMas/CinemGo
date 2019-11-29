using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using CinemaGo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CinemaGo.Controllers
{
    public class UserPageController : Controller
    {
        private string Username { get; set; }
        private string Password { get; set; }
        private string PhoneNumber { get; set; }
        public IActionResult Index()
        {
            string UserMacAddress = GetMACAddress();
            using (MyDbContext db = new MyDbContext())
            {
                User user = db.Users.FirstOrDefault(a => a.Password == Password && a.Username == Username);
                if (db.Users.FirstOrDefault(a => a.Mac == UserMacAddress) != null)
                {
                    user = db.Users.FirstOrDefault(a => a.Mac == UserMacAddress);
                    
                    ViewData["Films"] = user.FavList;
                    return View();
                }               
                else if (user != null) 
                {
                    user.Mac = UserMacAddress;
                    db.Users.Update(user);
                    db.SaveChanges();
                    ViewData["Films"] = user.FavList;
                    return View();
                }
            }
            return RedirectToAction("LogIn");

        }
        public IActionResult Enter(string username, string password)
        {
            Password = password;
            Username = username;
            return RedirectToAction("Index");
        }
        public IActionResult LogIn() 
        {
            return View();
        }
        public IActionResult GetNewUser(string username, string password,string phoneNumber) 
        {
            using (var db = new MyDbContext()) 
            {
                //TODO:Make check is phone number already exist in data base
                Password = password;
                Username = username;
                PhoneNumber = phoneNumber;
                User user = new User(Username,Password,PhoneNumber);
                user.Password = Password;
                user.Username = Username;
                user.PhoneNumber = PhoneNumber;
                db.Users.Add(user);
                db.SaveChanges();
            }
            return RedirectToAction("LogIn");
        }
        public IActionResult SignIn() 
        {
            return View();
        }
        public string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }
    }
}