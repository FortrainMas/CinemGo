using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaGo.Models
{
    public class FilmPage
    {
        public int id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public string TrailerLink {get;set;}
        public string FilmLink { get; set; }
        public string Discription { get; set; }
        public string Img { get; set; }
        public string Genre { get; set; }
        //public List<Coment> Coments { get; set; }
    }
}
