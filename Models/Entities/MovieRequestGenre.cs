using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Kinoshka.Models.Entities
{
    public class MovieRequestGenre
    {
        public List<MovieRequest> MovieRequests { get; set; }
        public SelectList Genres { get; set; }
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}
