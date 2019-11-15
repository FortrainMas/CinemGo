using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaGo.Models
{
    public class MyDbContext:DbContext
    {
        public DbSet<Film> Films;
        public DbSet<User> Users;
        public DbSet<FilmPage> FilmPages;
        protected override void OnConfiguring(DbContextOptionsBuilder option) 
        {
            option.UseSqlServer("Server=(localdb)/mssqllocaldb;Database=CinemaGoDb;Trusted_Connection=True");
        }
    }
}
