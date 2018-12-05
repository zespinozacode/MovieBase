using MovieBase.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Models
{
    public class MovieCreate
    {
        public int MovieId { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        [Display(Name = "Box Art")]
        public string CoverPicture { get; set; }

        [Display(Name = "Trailer")]
        public string TrailerLink { get; set; }

        public Genre GenreName { get; set; }

        public override string ToString() => Title;
    }
}
