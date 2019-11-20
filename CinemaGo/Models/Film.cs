using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaGo.Models
{
    public class Film
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Disc { get; set; }
        public string Img { get; set; }
        public string Link { get; set; }
        public string Genre { get; set; }
    }
}
