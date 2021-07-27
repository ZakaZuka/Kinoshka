using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kinoshka.Models
{
    public class MovieRequest
    {
        public int Id { get; set; }

        [Required]
        public string Poster { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Starring")]
        public string Starring { get; set; }

        [Required]
        [Display(Name = "Director")]
        public string Director { get; set; }

        [Required]
        [Display(Name = "Genre(s)")]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string Type { get; set; }

        [Required]
        [Display(Name ="Rating")]
        public string Rating { get; set; }
        
        [Required]
        [Display(Name = "Summary")]
        public string Summary { get; set; }

    }
}
