using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Models
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

       public Movie Movie { get; set; }

    }
}


