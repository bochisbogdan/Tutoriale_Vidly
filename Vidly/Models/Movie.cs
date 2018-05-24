
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="The Name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="The Release Date field is required.")]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        public Genre Genre { get; set; }
        [Required(ErrorMessage ="The Genre field is required")]
        public int  GenreId { get; set; }
        [Range(1,20)]
        public int StockNumber { get; set; }
    }
}