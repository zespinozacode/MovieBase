using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Data
{
    public enum Genre
    {
        Action = 0, Adventure, Comedy, Crime, Drama, Fanasy, Historical, Horror, Mystery, Romance, Satire, ScienceFiction, Thriller, Western
    }
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public string CoverPicture { get; set; }

        public string TrailerLink { get; set; }

        public Genre GenreName { get; set; }


    }
}
