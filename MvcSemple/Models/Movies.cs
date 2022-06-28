using System;
using System.ComponentModel.DataAnnotations;

namespace MvcSemple.Models
{
    public class Movies
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Required]

        public string Genre { get; set; }
        [Required]
        public int Price { get; set; }
       
    }
}
