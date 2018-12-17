using MovieBase.Data;
using MovieBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Models
{
    public class MovieActorViewModel
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        public Movie Movie { get; set; }
        public ICollection<Actor> Actors { get; set; }
    }
}
