using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFilmes.Models
{
    public class Filme
    {
        public string imdb { get; set; }
        public string titulo { get; set; }
        public string ano { get; set; }
        public string avaliacao { get; set; }
        public string tempo { get; set; }
        public string diretor { get; set; }
        public string poster { get; set; }
        public Genero genero { get; set; }



    }
}