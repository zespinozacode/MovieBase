using MovieBase.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Models
{
    //public enum Genre
    //{
    //    Action = 0, Adventure, Comedy, Crime, Drama, Fanasy, Historical, Horror, Mystery, Romance, Satire, ScienceFiction, Thriller, Western
    //}
    public class MovieListItem
    {
        public int MovieId { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Release Date")]
        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        [Display(Name = "Cover Art")]
        public string CoverPicture { get; set; }

        [Display(Name = "Trailer")]
        public string TrailerLink { get; set; }

        [Display(Name = "Genre")]
        public Genre GenreName { get; set; }

        public override string ToString() => Title;
    }
}
